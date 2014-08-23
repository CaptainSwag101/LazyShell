using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Forms;
using LAZYSHELL.Undo;

namespace LAZYSHELL.Effects
{
    public partial class MoldsForm : MapEditor
    {
        #region Variables

        // Forms
        private OwnerForm ownerForm;
        private PropertiesForm propertiesForm
        {
            get { return ownerForm.PropertiesForm; }
            set { ownerForm.PropertiesForm = value; }
        }
        private SequencesForm sequencesForm
        {
            get { return ownerForm.SequencesForm; }
            set { ownerForm.SequencesForm = value; }
        }
        public TileEditor tileEditor;
        private delegate void Function();

        // Index
        private int index
        {
            get { return listBox.SelectedIndex; }
            set { listBox.SelectedIndex = value; }
        }

        // Elements
        private Effect effect
        {
            get { return ownerForm.Effect; }
            set { ownerForm.Effect = value; }
        }
        private Animation animation
        {
            get { return ownerForm.Animation; }
            set { ownerForm.Animation = value; }
        }
        private Tileset tileset
        {
            get { return animation.Tileset_tiles; }
            set { animation.Tileset_tiles = value; }
        }
        private List<Mold> molds
        {
            get { return animation.Molds; }
        }
        private Mold mold
        {
            get { return animation.Molds[listBox.SelectedIndex]; }
        }
        private int freeBytes
        {
            get { return propertiesForm.FreeBytes; }
            set { propertiesForm.FreeBytes = value; }
        }
        public new PaletteSet PaletteSet
        {
            get { return animation.PaletteSet; }
            set { animation.PaletteSet = value; }
        }

        // Mouse behavior
        private bool mouseWithinSameBounds = false;
        private int mouseOverTile = 0;
        private int mouseDownTile = 0;
        private string mouseOverObject;
        private string mouseDownObject;
        private Point mouseDownPosition;
        private Point mousePosition;
        private bool mouseEnter = false;

        // Picture
        public PictureBox Picture
        {
            get { return pictureBoxMold; }
        }
        private Color bgcolor
        {
            get
            {
                return Color.FromArgb(animation.PaletteSet.Palettes[effect.PaletteIndex][0]);
            }
        }
        private Bitmap tilemapImage;
        private Bitmap tilesetImage;
        private Overlay overlay;
        private int zoom
        {
            get { return pictureBoxMold.Zoom; }
            set { pictureBoxMold.Zoom = value; }
        }
        private int width
        {
            get { return animation.Width * 16; }
        }
        private int height
        {
            get { return animation.Height * 16; }
        }
        public bool ShowBG
        {
            get { return toggleBG.Checked; }
        }

        // Tile editing
        private bool moving = false;
        private bool defloating = false;
        private CopyBuffer draggedTiles;
        private CopyBuffer copiedTiles;
        private CopyBuffer selectedTiles;
        private UndoStack commandStack;
        private int commandCount = 0;
        private Bitmap selection;

        #endregion

        // Constructors
        public MoldsForm(OwnerForm ownerForm)
        {
            this.ownerForm = ownerForm;
            this.Owner = ownerForm;
            InitializeComponent();
            InitializeVariables();
            BuildListBox(0);
            LoadProperties();
            SetTilesetImage();
            SetTilemapImage();
            LoadTileEditor();
        }
        public void Reload(OwnerForm ownerForm)
        {
            this.ownerForm = ownerForm;
            InitializeVariables();
            BuildListBox(0);
            LoadProperties();
            SetTilesetImage();
            SetTilemapImage();
            LoadTileEditor();
        }

        #region Methods

        #region Initialization

        private void InitializeVariables()
        {
            this.overlay = new Overlay();
            this.pictureBoxMold.ZoomBoxPosition = new Point(64, 0);
            this.commandStack = new UndoStack(true);
            this.selectedTiles = null;
            this.draggedTiles = null;
            this.copiedTiles = null;
            this.selection = null;
        }
        private void LoadProperties()
        {
            this.Updating = true;
            //
            moldWidth.Value = animation.Width;
            moldHeight.Value = animation.Height;
            tilesetSize.Value = animation.TilesetLength;
            //
            this.Updating = false;
        }
        private void BuildListBox(int selectedIndex)
        {
            this.Updating = true;
            //
            this.listBox.Items.Clear();
            for (int i = 0; i < animation.Molds.Count; i++)
                this.listBox.Items.Add("Mold " + i.ToString());
            if (selectedIndex >= 0 && this.listBox.Items.Count > selectedIndex)
                this.listBox.SelectedIndex = selectedIndex;
            else if (this.listBox.Items.Count > 0)
                this.listBox.SelectedIndex = 0;
            //
            this.Updating = false;
        }
        public void SetTilesetImage()
        {
            int[] pixels = Do.TilesetToPixels(tileset.Tiles, 8, 8, 0, false);
            tilesetImage = Do.PixelsToImage(pixels, 128, (int)tilesetSize.Value / 64 * 16);
            pictureBoxTileset.Size = tilesetImage.Size;
            pictureBoxTileset.Invalidate();
        }
        public void SetTilemapImage()
        {
            int[] pixels = mold.GetPixels(animation, tileset);
            tilemapImage = Do.PixelsToImage(pixels, animation.Width * 16, animation.Height * 16);
            pictureBoxMold.Size = new Size(tilemapImage.Width * zoom, tilemapImage.Height * zoom);
            pictureBoxMold.Invalidate();
        }

        #endregion

        #region Forms / Updating

        public void LoadTileEditor()
        {
            if (tileEditor == null)
            {
                tileEditor = new TileEditor(this, new TileUpdater(), tileset.Tiles[mouseDownTile], tileset.Graphics);
                tileEditor.FormClosing += new FormClosingEventHandler(editor_FormClosing);
            }
            else
                tileEditor.Reload(this.tileset.Tiles[mouseDownTile], tileset.Graphics);
        }
        public void UpdateTile()
        {
            SetTilesetImage();
            SetTilemapImage();
            sequencesForm.SetFrameImages();
            sequencesForm.RealignFrames();
        }

        #endregion

        #region Tile editing

        private void Draw(Graphics g, int x, int y)
        {
            x /= 16;
            y /= 16;
            // cancel if no selection in the tileset is made
            if (overlay.SelectTS.Empty)
                return;
            // check to see if overwriting same tile(s)
            bool noChange = true;
            for (int y_ = 0; y_ < overlay.SelectTS.Height / 16; y_++)
            {
                for (int x_ = 0; x_ < overlay.SelectTS.Width / 16; x_++)
                {
                    int index = ((overlay.SelectTS.Y / 16) + y_) * 8 + (overlay.SelectTS.X / 16) + x_;
                    int indexInMold = (y + y_) * (width / 16) + x + x_;
                    // cancel if overwriting same tile(s)
                    if (indexInMold < mold.Tiles.Length && mold.Tiles[indexInMold] != index)
                        noChange = false;
                }
            }
            if (noChange)
                return;
            commandStack.Push(new MoldEdit(
                mold.Tiles, width / 16, height / 16, selectedTiles.CopyBytes(), x, y,
                overlay.SelectTS.Width / 16, overlay.SelectTS.Height / 16));
            commandCount++;
            // draw the tile
            Point p = new Point(x * 16, y * 16);
            int[] pixels = Do.ImageToPixels(overlay.SelectTS.GetSelectionImage(tilesetImage));
            Bitmap image = Do.PixelsToImage(pixels, overlay.SelectTS.Width, overlay.SelectTS.Height);
            p.X *= zoom;
            p.Y *= zoom;
            Rectangle rsrc = new Rectangle(0, 0, image.Width, image.Height);
            Rectangle rdst = new Rectangle(p.X, p.Y, (int)(image.Width * zoom), (int)(image.Height * zoom));
            g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            g.DrawImage(image, rdst, rsrc, GraphicsUnit.Pixel);
        }
        private void Erase(int x, int y)
        {
            // cancel if writing same tile over itself
            if (mold.Tiles[(y / 16) * (width / 16) + (x / 16)] == 0xFF)
                return;
            commandStack.Push(new MoldEdit(
                mold.Tiles, width / 16, height / 16, new byte[] { 0xFF }, x / 16, y / 16, 1, 1));
            commandCount++;
        }
        private void Undo()
        {
            commandStack.UndoCommand();
            SetTilemapImage();
            if (sequencesForm != null)
            {
                sequencesForm.SetFrameImages();
                sequencesForm.RealignFrames();
            }
        }
        private void Redo()
        {
            commandStack.RedoCommand();
            SetTilemapImage();
            if (sequencesForm != null)
            {
                sequencesForm.SetFrameImages();
                sequencesForm.RealignFrames();
            }
        }

        #endregion

        #region Selection editing

        // Tiles
        private void Cut()
        {
            if (overlay.Select.Empty || overlay.Select.Size == new Size(0, 0))
                return;
            Copy();
            Delete();
            if (commandCount > 0)
            {
                commandStack.Push(commandCount);
                commandCount = 0;
            }
        }
        private void Copy()
        {
            if (overlay.Select.Empty || overlay.Select.Size == new Size(0, 0))
                return;
            if (draggedTiles != null)
            {
                this.copiedTiles = draggedTiles;
                return;
            }
            selection = new Bitmap(tilemapImage.Clone(
                new Rectangle(overlay.Select.Location, overlay.Select.Size), PixelFormat.DontCare));
            int[] copiedTiles = new int[(overlay.Select.Width / 16) * (overlay.Select.Height / 16)];
            this.copiedTiles = new CopyBuffer(overlay.Select.Width, overlay.Select.Height);
            for (int y = 0, y_ = overlay.Select.Y / 16; y < overlay.Select.Height / 16; y++, y_++)
            {
                for (int x = 0, x_ = overlay.Select.X / 16; x < overlay.Select.Width / 16; x++, x_++)
                    copiedTiles[y * (overlay.Select.Width / 16) + x] = mold.Tiles[y_ * (width / 16) + x_];
            }
            this.copiedTiles.Copy = copiedTiles;
        }
        private void Paste()
        {
            if (draggedTiles != null)
            {
                Defloat(draggedTiles);
                draggedTiles = null;
            }
            Paste(new Point(0, 0), copiedTiles);
        }
        private void Paste(Point location, CopyBuffer buffer)
        {
            if (buffer == null)
                return;
            moving = true;
            // now dragging a new selection
            draggedTiles = buffer;
            overlay.Select.Set(16, location, buffer.Size, pictureBoxMold);
            pictureBoxMold.Invalidate();
            defloating = false;
        }
        private void Delete()
        {
            if (overlay.Select.Empty)
                return;
            if (tileset.Tiles == null || overlay.Select.Size == new Size(0, 0))
                return;
            Point location = overlay.Select.Location;
            Point terminal = overlay.Select.Terminal;
            byte[] changes = new byte[(overlay.Select.Width / 16) * (overlay.Select.Height / 16)];
            Bits.SetBytes(changes, 0xFF);
            commandStack.Push(new MoldEdit(
                mold.Tiles, width / 16, height / 16, changes,
                overlay.Select.X / 16, overlay.Select.Y / 16, overlay.Select.Width / 16, overlay.Select.Height / 16));
            commandCount++;
            SetTilemapImage();
            if (sequencesForm != null)
            {
                sequencesForm.SetFrameImages();
                sequencesForm.RealignFrames();
            }
            animation.WriteToBuffer();
        }
        /// <summary>
        /// Flips the mold selection vertically or horizontally.
        /// </summary>
        /// <param name="flipType">The direction to flip the mold selection.</param>
        private void Flip(FlipType flipType)
        {
            if (overlay.Select.Empty)
                return;
            if (tileset.Tiles == null || overlay.Select.Size == new Size(0, 0))
                return;
            Point location = overlay.Select.Location;
            Point terminal = overlay.Select.Terminal;
            byte[] flippedTiles = new byte[(overlay.Select.Width / 16) * (overlay.Select.Height / 16)];
            for (int y = 0, y_ = overlay.Select.Y / 16; y < overlay.Select.Height / 16; y++, y_++)
            {
                for (int x = 0, x_ = overlay.Select.X / 16; x < overlay.Select.Width / 16; x++, x_++)
                {
                    flippedTiles[y * (overlay.Select.Width / 16) + x] = mold.Tiles[y_ * (width / 16) + x_];
                    if (flipType == FlipType.Horizontal && flippedTiles[y * (overlay.Select.Width / 16) + x] != 0xFF)
                        flippedTiles[y * (overlay.Select.Width / 16) + x] ^= 0x40;
                    if (flipType == FlipType.Vertical && flippedTiles[y * (overlay.Select.Width / 16) + x] != 0xFF)
                        flippedTiles[y * (overlay.Select.Width / 16) + x] ^= 0x80;
                }
            }
            if (flipType == FlipType.Horizontal)
                Do.FlipHorizontal(flippedTiles, overlay.Select.Width / 16, overlay.Select.Height / 16);
            if (flipType == FlipType.Vertical)
                Do.FlipVertical(flippedTiles, overlay.Select.Width / 16, overlay.Select.Height / 16);
            commandStack.Push(new MoldEdit(
                mold.Tiles, width / 16, height / 16, flippedTiles,
                overlay.Select.X / 16, overlay.Select.Y / 16, overlay.Select.Width / 16, overlay.Select.Height / 16));
            commandStack.Push(1);
            SetTilemapImage();
            if (sequencesForm != null)
            {
                sequencesForm.SetFrameImages();
                sequencesForm.RealignFrames();
            }
            animation.WriteToBuffer();
        }

        // Moving
        /// <summary>
        /// Start dragging a current selection.
        /// </summary>
        private void Drag()
        {
            if (overlay.Select.Empty || overlay.Select.Size == new Size(0, 0))
                return;
            selection = new Bitmap(tilemapImage.Clone(
                new Rectangle(overlay.Select.Location, overlay.Select.Size), PixelFormat.DontCare));
            int[] copiedTiles = new int[(overlay.Select.Width / 16) * (overlay.Select.Height / 16)];
            this.draggedTiles = new CopyBuffer(overlay.Select.Width, overlay.Select.Height);
            for (int y = 0, y_ = overlay.Select.Y / 16; y < overlay.Select.Height / 16; y++, y_++)
            {
                for (int x = 0, x_ = overlay.Select.X / 16; x < overlay.Select.Width / 16; x++, x_++)
                {
                    int tileX = overlay.Select.X + (x * 16);
                    int tileY = overlay.Select.Y + (y * 16);
                    copiedTiles[y * (overlay.Select.Width / 16) + x] = mold.Tiles[y_ * (width / 16) + x_];
                }
            }
            this.draggedTiles.Copy = copiedTiles;
            Delete();
        }
        /// <summary>
        /// Defloats either a dragged selection or a newly pasted selection.
        /// </summary>
        /// <param name="buffer">The dragged selection or the newly pasted selection.</param>
        private void Defloat(CopyBuffer buffer)
        {
            if (buffer == null)
                return;
            if (overlay.Select.Empty)
                return;
            Point location = new Point();
            location.X = overlay.Select.X / 16;
            location.Y = overlay.Select.Y / 16;
            commandStack.Push(new MoldEdit(
                mold.Tiles, width / 16, height / 16, buffer.CopyBytes(),
                location.X, location.Y, buffer.Width / 16, buffer.Height / 16));
            commandStack.Push(commandCount + 1);
            commandCount = 0;
            SetTilemapImage();
            if (sequencesForm != null)
            {
                sequencesForm.SetFrameImages();
                sequencesForm.RealignFrames();
            }
            defloating = true;
            animation.WriteToBuffer();
        }
        private void Defloat()
        {
            if (copiedTiles != null && !defloating)
                Defloat(copiedTiles);
            if (draggedTiles != null)
            {
                Defloat(draggedTiles);
                draggedTiles = null;
            }
            moving = false;
            overlay.Select.Clear();
            Cursor.Position = Cursor.Position;
        }
        private void SelectAll()
        {
            Defloat();
            if (!select.Checked)
                select.PerformClick();
            overlay.Select.Reload(16, 0, 0, width, height, pictureBoxMold);
            pictureBoxMold.Invalidate();
        }

        #endregion

        private void ImportTilemaps()
        {
            // First, import images into array
            Bitmap[] imports = new Bitmap[1];
            imports = Do.Import(imports) as Bitmap[];

            // Check if null, too big/small
            if (imports == null)
                return;
            if (imports.Length == 0)
                return;
            if (imports.Length > 32)
            {
                MessageBox.Show("The maximum number of imported images must not exceed 32.", "LAZY SHELL");
                return;
            }

            // Create buffers for new mold data
            byte[] graphics = new byte[0x10000];
            int[] palette = animation.PaletteSet.Palettes[effect.PaletteIndex];
            Tile[] tiles = new Tile[16 * 16];
            byte[][] tilemaps = new byte[imports.Length][];

            // Prompt option for new palette
            bool newPalette = false;
            if (MessageBox.Show("Would you like to create a new palette from the imported image(s)?", "LAZY SHELL",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                newPalette = true;

            // Convert the bitmaps to tilemaps and store to the buffers
            Do.ImagesToTilemaps(ref imports, ref palette, index, animation.Codec == 1 ? (byte)0x10 : (byte)0x20,
                ref graphics, ref tiles, ref tilemaps, newPalette);

            // Write the RGB palette buffer to the palette set data
            for (int i = 0; i < palette.Length; i++)
            {
                animation.PaletteSet.Reds[i + (effect.PaletteIndex * 16)] = Color.FromArgb(palette[i]).R;
                animation.PaletteSet.Greens[i + (effect.PaletteIndex * 16)] = Color.FromArgb(palette[i]).G;
                animation.PaletteSet.Blues[i + (effect.PaletteIndex * 16)] = Color.FromArgb(palette[i]).B;
            }

            // Write graphics buffer to animation's graphics buffer
            Buffer.BlockCopy(graphics, 0, animation.GraphicSet, 0, Math.Min(graphics.Length, animation.GraphicSet.Length));

            // Set graphic set size to size of new graphics
            propertiesForm.GraphicSetSize.Value = Math.Min(graphics.Length, 8192);
            if (graphics.Length > 8192)
                MessageBox.Show("Not enough space to store the necessary amount of SNES graphics data for the imported images. The total required space (" +
                    graphics.Length + " bytes) for the new SNES graphics data exceeds 8192 bytes.",
                    "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Set tileset size to size of new tileset data
            int temp = tiles.Length * 8;
            animation.TilesetLength = Math.Min(tiles.Length * 8, 512);
            animation.TilesetLength = animation.TilesetLength / 64 * 64;
            if (animation.TilesetLength == 0)
                animation.TilesetLength += 64;
            else if (animation.TilesetLength <= 512 - 64 && temp % 64 != 0)
                animation.TilesetLength += 64;
            tilesetSize.Value = animation.TilesetLength;
            if (tiles.Length * 8 > 512)
                MessageBox.Show("Not enough space to draw the necessary amount of tiles in the tileset for the imported images. " +
                    "The total required space (" + (tiles.Length * 8).ToString() + " bytes) for the new tileset exceeds 512 bytes.",
                    "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Rebuild tile collection from new tileset data
            animation.Tileset_tiles.ParseTileset(animation.Tileset_bytes, tiles);
            animation.Tileset_tiles = new Tileset(animation, effect.PaletteIndex);

            // Write new tilemap buffers to mold tilemap buffers
            for (int i = 0; i < tilemaps.Length; i++)
            {
                if (i >= molds.Count) // Add another mold if not enough
                {
                    index = molds.Count - 1;
                    newMold.PerformClick();
                }
                Bits.Fill(molds[i].Tiles, (byte)0xFF);
                Buffer.BlockCopy(tilemaps[i], 0, molds[i].Tiles, 0, Math.Min(tilemaps[i].Length, molds[i].Tiles.Length));
            }

            // Set mold collection properties to fit new mold data
            animation.Width = (byte)Math.Min(16, imports[0].Width / 16);
            animation.Height = (byte)Math.Min(16, imports[0].Height / 16);
            moldWidth.Value = Math.Min(16, imports[0].Width / 16);
            moldHeight.Value = Math.Min(16, imports[0].Height / 16);

            // Update animation buffer
            animation.WriteToBuffer();

            // Refresh images and forms
            SetTilesetImage();
            SetTilemapImage();
            sequencesForm.SetFrameImages();
            sequencesForm.RealignFrames();
            ownerForm.LoadPaletteEditor();
            ownerForm.LoadGraphicEditor();
        }

        #endregion

        #region Event Handlers

        // Picture : Tileset
        private void pictureBoxTileset_Paint(object sender, PaintEventArgs e)
        {
            if (toggleBG.Checked)
                e.Graphics.FillRectangle(
                    new SolidBrush(Color.FromArgb(animation.PaletteSet.Palettes[effect.PaletteIndex][0])),
                    new Rectangle(new Point(0, 0), pictureBoxTileset.Size));
            if (tilesetImage != null)
                e.Graphics.DrawImage(tilesetImage, 0, 0, 128, (int)tilesetSize.Value / 64 * 16);
            if (toggleTileGrid.Checked)
                overlay.DrawTileGrid(e.Graphics, Color.Gray, pictureBoxTileset.Size, new Size(16, 16), 1, true);
            if (overlay.SelectTS != null)
                overlay.SelectTS.DrawSelectionBox(e.Graphics, 1);
        }
        private void pictureBoxTileset_MouseDown(object sender, MouseEventArgs e)
        {
            // set a floor and ceiling for the coordinates
            int x = Math.Max(0, Math.Min(e.X, pictureBoxTileset.Width));
            int y = Math.Max(0, Math.Min(e.Y, pictureBoxTileset.Height));
            mouseDownTile = (y / 16) * 8 + (x / 16);
            // if making a new selection
            if (e.Button == MouseButtons.Left && mouseOverObject == null)
                overlay.SelectTS.Reload(16, x / 16 * 16, y / 16 * 16, 16, 16, pictureBoxTileset);
            pictureBoxTileset.Invalidate();
            LoadTileEditor();
        }
        private void pictureBoxTileset_MouseMove(object sender, MouseEventArgs e)
        {
            // set a floor and ceiling for the coordinates
            int x = Math.Max(0, Math.Min(e.X, pictureBoxTileset.Width));
            int y = Math.Max(0, Math.Min(e.Y, pictureBoxTileset.Height));
            // if making a new selection
            if (e.Button == MouseButtons.Left && mouseDownObject == null && overlay.SelectTS != null)
            {
                overlay.SelectTS.Final = new Point(
                        Math.Min(x + 16, pictureBoxTileset.Width),
                        Math.Min(y + 16, pictureBoxTileset.Height));
            }
            pictureBoxTileset.Invalidate();
        }
        private void pictureBoxTileset_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                return;
            int x_ = overlay.SelectTS.Location.X / 16;
            int y_ = overlay.SelectTS.Location.Y / 16;
            if (this.selectedTiles == null)
                this.selectedTiles = new CopyBuffer(overlay.SelectTS.Width, overlay.SelectTS.Height);
            int[] selectedTiles = new int[(overlay.SelectTS.Width / 16) * (overlay.SelectTS.Height / 16)];
            for (int y = 0; y < overlay.SelectTS.Height / 16; y++)
            {
                for (int x = 0; x < overlay.SelectTS.Width / 16; x++)
                {
                    int tileX = overlay.SelectTS.X + (x * 16);
                    int tileY = overlay.SelectTS.Y + (y * 16);
                    selectedTiles[y * (overlay.SelectTS.Width / 16) + x] = (y + y_) * 8 + x + x_;
                }
            }
            this.selectedTiles.Copy = selectedTiles;
            pictureBoxTileset.Focus();
        }

        // Picture : Mold
        private void pictureBoxMold_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.PixelOffsetMode = PixelOffsetMode.Half;
            e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
            if (toggleBG.Checked)
                e.Graphics.FillRectangle(new SolidBrush(bgcolor), new Rectangle(new Point(0, 0), pictureBoxMold.Size));
            if (tilemapImage != null && e.ClipRectangle.Size != new Size(16, 16))
            {
                Rectangle src = new Rectangle(0, 0, tilemapImage.Width, tilemapImage.Height);
                Rectangle dst = new Rectangle(0, 0, tilemapImage.Width * zoom, tilemapImage.Height * zoom);
                e.Graphics.DrawImage(tilemapImage, dst, src, GraphicsUnit.Pixel);
            }
            if (moving && selection != null && overlay.Select != null)
            {
                Rectangle src = new Rectangle(0, 0, overlay.Select.Width, overlay.Select.Height);
                Rectangle dst = new Rectangle(
                    overlay.Select.X * zoom, overlay.Select.Y * zoom,
                    src.Width * zoom, src.Height * zoom);
                e.Graphics.DrawImage(new Bitmap(selection), dst, src, GraphicsUnit.Pixel);
                Do.DrawString(e.Graphics, new Point(dst.X, dst.Y + dst.Height),
                    "click/drag", Color.White, Color.Black, new Font("Tahoma", 6.75F, FontStyle.Bold));
            }
            if (mouseEnter && e.ClipRectangle.Size != new Size(16, 16))
            {
                Point location = new Point(mousePosition.X / 16 * 16 * zoom, mousePosition.Y / 16 * 16 * zoom);
                overlay.DrawHoverBox(e.Graphics, location, new Size(16 * zoom, 16 * zoom), zoom, true);
            }
            if (toggleTileGrid.Checked)
                overlay.DrawTileGrid(e.Graphics, Color.Gray, pictureBoxMold.Size, new Size(16, 16), zoom, true);
            if (select.Checked && overlay.Select != null)
            {
                e.Graphics.PixelOffsetMode = PixelOffsetMode.Default;
                overlay.Select.DrawSelectionBox(e.Graphics, zoom);
            }
        }
        private void pictureBoxMold_MouseDown(object sender, MouseEventArgs e)
        {
            // set a floor and ceiling for the coordinates
            int x = Math.Max(0, Math.Min(e.X / zoom, width));
            int y = Math.Max(0, Math.Min(e.Y / zoom, height));

            #region Zooming

            Point p = new Point();
            p.X = Math.Abs(panelMoldImage.AutoScrollPosition.X);
            p.Y = Math.Abs(panelMoldImage.AutoScrollPosition.Y);
            if ((zoomIn.Checked && e.Button == MouseButtons.Left) || (zoomOut.Checked && e.Button == MouseButtons.Right))
            {
                pictureBoxMold.ZoomIn(e.X, e.Y);
                return;
            }
            else if ((zoomOut.Checked && e.Button == MouseButtons.Left) || (zoomIn.Checked && e.Button == MouseButtons.Right))
            {
                pictureBoxMold.ZoomOut(e.X, e.Y);
                return;
            }

            #endregion

            if (e.Button == MouseButtons.Right)
                return;

            #region Drawing, Erasing, Selecting

            // if moving an object and outside of it, paste it
            if (moving && mouseOverObject != "selection")
            {
                // if copied tiles were pasted and not dragging a non-copied selection
                if (copiedTiles != null && draggedTiles == null)
                    Defloat(copiedTiles);
                if (draggedTiles != null)
                {
                    Defloat(draggedTiles);
                    draggedTiles = null;
                }
                moving = false;
            }
            if (select.Checked)
            {
                // if we're not inside a current selection to move it, create a new selection
                if (mouseOverObject != "selection")
                    overlay.Select.Reload(16, x / 16 * 16, y / 16 * 16, 16, 16, pictureBoxMold);
                // otherwise, start dragging current selection
                else if (mouseOverObject == "selection")
                {
                    mouseDownObject = "selection";
                    mouseDownPosition = overlay.Select.MousePosition(x, y);
                    if (!moving)    // only do this if the current selection has not been initially moved
                    {
                        moving = true;
                        Drag();
                    }
                }
            }
            if (e.Button == MouseButtons.Left)
            {
                if (draw.Checked)
                {
                    Draw(pictureBoxMold.CreateGraphics(), x, y);
                    panelMoldImage.AutoScrollPosition = p;
                    return;
                }
                if (erase.Checked)
                {
                    Erase(x, y);
                    if (!toggleBG.Checked)
                        pictureBoxMold.Erase(x / 16 * 16, y / 16 * 16, 16, 16);
                    else
                        pictureBoxMold.Draw(x / 16 * 16, y / 16 * 16, 16, 16, bgcolor);
                    panelMoldImage.AutoScrollPosition = p;
                    return;
                }
            }

            #endregion

            panelMoldImage.AutoScrollPosition = p;
            pictureBoxMold.Invalidate();
        }
        private void pictureBoxMold_MouseMove(object sender, MouseEventArgs e)
        {
            // set a floor and ceiling for the coordinates
            int x = Math.Max(0, Math.Min(e.X / zoom, width));
            int y = Math.Max(0, Math.Min(e.Y / zoom, height));
            labelCoords.Text = "(x: " + x + ", y: " + y + ") Pixel";
            // must first check if within same bounds as last call of MouseMove event
            mouseWithinSameBounds = mouseOverTile == (y / 16 * 64) + (x / 16);
            // now set the properties
            mousePosition = new Point(x, y);
            mouseOverTile = (y / 16 * 64) + (x / 16);
            mouseOverObject = null;

            #region Zooming

            // if either zoom button is checked, don't do anything else
            if (zoomIn.Checked || zoomOut.Checked)
            {
                pictureBoxMold.Invalidate();
                return;
            }

            #endregion

            #region Drawing, erasing, selecting

            if (select.Checked)
            {
                // if making a new selection
                if (e.Button == MouseButtons.Left && mouseDownObject == null && overlay.Select != null)
                {
                    // cancel if within same bounds as last call
                    if (overlay.Select.Final == new Point(x + 16, y + 16))
                        return;
                    // otherwise, set the lower right edge of the selection
                    overlay.Select.Final = new Point(
                        Math.Min(x + 16, pictureBoxMold.Width),
                        Math.Min(y + 16, pictureBoxMold.Height));
                }
                // if dragging the current selection
                else if (e.Button == MouseButtons.Left && mouseDownObject == "selection")
                    overlay.Select.Location = new Point(
                        x / 16 * 16 - mouseDownPosition.X,
                        y / 16 * 16 - mouseDownPosition.Y);
                // if mouse not clicked and within the current selection
                else if (e.Button == MouseButtons.None && overlay.Select != null && overlay.Select.MouseWithin(x, y))
                {
                    mouseOverObject = "selection";
                    pictureBoxMold.Cursor = Cursors.SizeAll;
                }
                else
                    pictureBoxMold.Cursor = Cursors.Cross;
                pictureBoxMold.Invalidate();
                return;
            }
            if (draw.Checked && e.Button == MouseButtons.Left)
            {
                Draw(pictureBoxMold.CreateGraphics(), x, y);
                return;
            }
            else if (erase.Checked && e.Button == MouseButtons.Left)
            {
                Erase(x, y);
                if (!toggleBG.Checked)
                    pictureBoxMold.Erase(x / 16 * 16, y / 16 * 16, 16, 16);
                else
                    pictureBoxMold.Draw(x / 16 * 16, y / 16 * 16, 16, 16, bgcolor);
                return;
            }

            #endregion

            pictureBoxMold.Invalidate();
            pictureBoxMold.Focus(ownerForm);
        }
        private void pictureBoxMold_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDownObject = null;
            if (draw.Checked || erase.Checked)
            {
                SetTilemapImage();
                if (sequencesForm != null)
                {
                    sequencesForm.SetFrameImages();
                    sequencesForm.RealignFrames();
                }
            }
            if (!moving && commandCount > 0)
            {
                this.commandStack.Push(commandCount);
                commandCount = 0;
            }
            //
            Point p = new Point(Math.Abs(pictureBoxMold.Left), Math.Abs(pictureBoxMold.Top));
            pictureBoxMold.Focus();
            panelMoldImage.AutoScrollPosition = p;
            // update free space
            animation.WriteToBuffer();
            propertiesForm.SetFreeBytesLabel();
        }
        private void pictureBoxMold_MouseEnter(object sender, EventArgs e)
        {
            mouseEnter = true;
            pictureBoxMold.Focus(ownerForm);
            pictureBoxMold.Invalidate();
        }
        private void pictureBoxMold_MouseLeave(object sender, EventArgs e)
        {
            mouseEnter = false;
            pictureBoxMold.Invalidate();
        }
        private void pictureBoxMold_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Z: toggleZoomBox.PerformClick(); break;
                case Keys.G: toggleTileGrid.PerformClick(); break;
                case Keys.B: toggleBG.PerformClick(); break;
                case Keys.D: draw.PerformClick(); break;
                case Keys.E: erase.PerformClick(); break;
                case Keys.S: select.PerformClick(); break;
                case Keys.Control | Keys.V: Paste(); break;
                case Keys.Control | Keys.C: Copy(); break;
                case Keys.Delete: delete.PerformClick(); break;
                case Keys.Control | Keys.X: Cut(); break;
                case Keys.Control | Keys.D: Defloat(); break;
                case Keys.Control | Keys.A: SelectAll(); break;
                case Keys.Control | Keys.Z: Undo(); break;
                case Keys.Control | Keys.Y: Redo(); break;
            }
        }

        // ListBox
        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            int index = listBox.SelectedIndex;
            if (draggedTiles != null && listBox.LastSelectedIndex != -1)
            {
                this.Updating = true;
                listBox.BeginUpdate();
                //
                listBox.SelectedIndex = listBox.LastSelectedIndex;
                Defloat();
                listBox.SelectedIndex = index;
                //
                listBox.EndUpdate();
                this.Updating = false;
            }
            listBox.LastSelectedIndex = index;
            SetTilemapImage();
        }

        // Tileset
        private void tileSetSize_ValueChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            overlay.SelectTS.Clear();
            if (animation.Codec == 0)
                tilesetSize.Value = (int)tilesetSize.Value & 0xFFE0;
            else
                tilesetSize.Value = (int)tilesetSize.Value & 0xFFF0;
            animation.TilesetLength = (int)tilesetSize.Value;
            SetTilesetImage();
            // update free space
            animation.WriteToBuffer();
            propertiesForm.SetFreeBytesLabel();
        }

        // Collection properties
        private void importIntoTilemap_Click(object sender, EventArgs e)
        {
            ImportTilemaps();
        }
        private void moldWidth_ValueChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            Defloat();
            int width = animation.Width;
            animation.Width = (byte)moldWidth.Value;
            animation.ResizeTilemaps(width);
            SetTilemapImage();
            if (sequencesForm != null)
            {
                sequencesForm.SetFrameImages();
                sequencesForm.RealignFrames();
                sequencesForm.RealignFrames();
            }
            // update free space
            animation.WriteToBuffer();
            propertiesForm.SetFreeBytesLabel();
        }
        private void moldHeight_ValueChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            Defloat();
            animation.Height = (byte)moldHeight.Value;
            SetTilemapImage();
            if (sequencesForm != null)
            {
                sequencesForm.SetFrameImages();
                sequencesForm.RealignFrames();
                sequencesForm.RealignFrames();
            }
            // update free space
            animation.WriteToBuffer();
            propertiesForm.SetFreeBytesLabel();
        }
        private void newMold_Click(object sender, EventArgs e)
        {
            if (molds.Count == 32)
            {
                MessageBox.Show("Animations cannot contain more than 32 molds total.",
                    "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            int index = this.index;
            molds.Insert(index + 1, mold.New());
            BuildListBox(index + 1);
            sequencesForm.SetFrameImages();
            sequencesForm.RealignFrames();
            // update free space
            animation.WriteToBuffer();
            propertiesForm.SetFreeBytesLabel();
        }
        private void deleteMold_Click(object sender, EventArgs e)
        {
            if (molds.Count == 1)
            {
                MessageBox.Show("Animations must contain at least 1 mold.",
                    "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            int index = this.index;
            molds.RemoveAt(index);
            if (index >= molds.Count && molds.Count != 0)
                index--;
            BuildListBox(index);
            SetTilemapImage();
            sequencesForm.SetFrameImages();
            sequencesForm.RealignFrames();
            // update free space
            animation.WriteToBuffer();
            propertiesForm.SetFreeBytesLabel();
        }
        private void duplicateMold_Click(object sender, EventArgs e)
        {
            if (molds.Count == 32)
            {
                MessageBox.Show("Animations cannot contain more than 32 molds total.",
                   "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            int index = this.index;
            molds.Insert(index + 1, mold.Copy());
            BuildListBox(index + 1);
            sequencesForm.SetFrameImages();
            sequencesForm.RealignFrames();
            // update free space
            animation.WriteToBuffer();
            propertiesForm.SetFreeBytesLabel();
        }

        // Toggle
        private void toggleTileGrid_Click(object sender, EventArgs e)
        {
            pictureBoxMold.Invalidate();
            pictureBoxTileset.Invalidate();
        }
        private void toggleBG_Click(object sender, EventArgs e)
        {
            pictureBoxMold.Invalidate();
            pictureBoxTileset.Invalidate();
            sequencesForm.InvalidateFrameImages();
        }

        // Tile editing
        private void draw_Click(object sender, EventArgs e)
        {
            Do.ResetToolStripButtons(toolStrip6, sender as ToolStripButton);
            zoomIn.Checked = false;
            zoomOut.Checked = false;
            if (draw.Checked)
                this.pictureBoxMold.Cursor = NewCursors.Draw;
            else if (!draw.Checked)
                this.pictureBoxMold.Cursor = Cursors.Arrow;
            Defloat();
            pictureBoxMold.Invalidate();
        }
        private void erase_Click(object sender, EventArgs e)
        {
            Do.ResetToolStripButtons(toolStrip6, sender as ToolStripButton);
            zoomIn.Checked = false;
            zoomOut.Checked = false;
            if (erase.Checked)
                this.pictureBoxMold.Cursor = NewCursors.Erase;
            else if (!erase.Checked)
                this.pictureBoxMold.Cursor = Cursors.Arrow;
            Defloat();
            pictureBoxMold.Invalidate();
        }
        private void select_Click(object sender, EventArgs e)
        {
            Do.ResetToolStripButtons(toolStrip6, sender as ToolStripButton);
            zoomIn.Checked = false;
            zoomOut.Checked = false;
            if (select.Checked)
                this.pictureBoxMold.Cursor = Cursors.Cross;
            else if (!select.Checked)
                this.pictureBoxMold.Cursor = Cursors.Arrow;
            Defloat();
            pictureBoxMold.Invalidate();
        }
        private void selectAll_Click(object sender, EventArgs e)
        {
            SelectAll();
        }
        private void cut_Click(object sender, EventArgs e)
        {
            Cut();
        }
        private void copy_Click(object sender, EventArgs e)
        {
            Copy();
        }
        private void paste_Click(object sender, EventArgs e)
        {
            Paste();
        }
        private void delete_Click(object sender, EventArgs e)
        {
            if (!moving)
                Delete();
            else
            {
                moving = false;
                draggedTiles = null;
                pictureBoxMold.Invalidate();
            }
            if (!moving && commandCount > 0)
            {
                commandStack.Push(commandCount);
                commandCount = 0;
            }
        }
        private void undoButton_Click(object sender, EventArgs e)
        {
            Undo();
        }
        private void redoButton_Click(object sender, EventArgs e)
        {
            Redo();
        }
        private void mirror_Click(object sender, EventArgs e)
        {
            Flip(FlipType.Horizontal);
        }
        private void invert_Click(object sender, EventArgs e)
        {
            Flip(FlipType.Vertical);
        }

        // Zooming
        private void zoomIn_Click(object sender, EventArgs e)
        {
            Do.ResetToolStripButtons(toolStrip6, sender as ToolStripButton);
            zoomOut.Checked = false;
            if (zoomIn.Checked)
                this.pictureBoxMold.Cursor = NewCursors.ZoomIn;
            else if (!zoomIn.Checked)
                this.pictureBoxMold.Cursor = Cursors.Arrow;
            Defloat();
            pictureBoxMold.Invalidate();
        }
        private void zoomOut_Click(object sender, EventArgs e)
        {
            Do.ResetToolStripButtons(toolStrip6, sender as ToolStripButton);
            zoomIn.Checked = false;
            if (zoomOut.Checked)
                this.pictureBoxMold.Cursor = NewCursors.ZoomOut;
            else if (!zoomOut.Checked)
                this.pictureBoxMold.Cursor = Cursors.Arrow;
            Defloat();
            pictureBoxMold.Invalidate();
        }
        private void toggleZoomBox_Click(object sender, EventArgs e)
        {
            pictureBoxMold.ZoomBoxEnabled = toggleZoomBox.Checked;
        }

        // ContextMenuStrip : Mold
        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (zoomIn.Checked || zoomOut.Checked)
                e.Cancel = true;
        }
        private void menuSaveImageAs_Click(object sender, EventArgs e)
        {
            Do.Export(tilemapImage,
                "effect-animation-" + animation.Index.ToString("d3") + ".mold-" + index.ToString("d2") + ".png");
        }

        // ContextMenuStrip : Tileset
        private void menuTilesetSaveImageAs_Click(object sender, EventArgs e)
        {
            Do.Export(tilesetImage, "effect-animation-" + animation.Index.ToString("d2") + ".tileset.png");
        }

        // Forms
        private void openTileEditor_Click(object sender, EventArgs e)
        {
            tileEditor.Visible = true;
        }
        private void editor_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            (sender as Form).Hide();
        }

        #endregion
    }
}
