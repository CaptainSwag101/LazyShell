using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Forms;
using LazyShell.Areas;
using LazyShell.Undo;

namespace LazyShell
{
    public partial class TilesetForm : Controls.DockForm
    {
        #region Variables

        private MapEditor ownerForm;
        private Tileset Tileset
        {
            get { return ownerForm.Tileset; }
            set { ownerForm.Tileset = value; }
        }
        public PaletteSet PaletteSet
        {
            get { return ownerForm.PaletteSet; }
            set { ownerForm.PaletteSet = value; }
        }
        private Overlay overlay
        {
            get { return ownerForm.Overlay; }
            set { ownerForm.Overlay = value; }
        }
        private TilesetUpdater updater
        {
            get { return ownerForm.TilesetUpdater; }
            set { ownerForm.TilesetUpdater = value; }
        }

        // Main
        public int Layer { get; set; }
        public bool AutoUpdate
        {
            get { return autoUpdate.Checked; }
            set { autoUpdate.Checked = value; }
        }
        private Bitmap tilesetImage;
        private Bitmap priority1;
        public TileEditor TileEditor;
        private int height
        {
            get { return Tileset.Height * 16; }
        }
        public bool Rails;

        // Picture
        public PictureBox Picture
        {
            get { return pictureBoxTileset; }
            set { pictureBoxTileset = value; }
        }
        private int zoom = 1;

        // Mouse behavior
        private int mouseDownTile;
        private bool mouseEnter = false;
        private MapObject mouseOverObject;
        private MapObject mouseDownObject;
        private Point mouseDownPosition;
        private Point mousePosition;

        // Selection editing
        private bool moving = false;
        private Bitmap selection;
        private CopyBuffer copiedTiles;
        public CopyBuffer SelectedTiles { get; set; }
        public CopyBuffer DraggedTiles { get; set; }
        private UndoStack commandStack;

        #endregion

        // Constructor
        public TilesetForm(MapEditor ownerForm, int layer)
        {
            this.ownerForm = ownerForm;
            this.Layer = layer;
            //
            InitializeComponent();
            InitializeVariables();
            //
            this.Text = "Tileset L" + (layer + 1);
            this.pictureBoxTileset.Height = height;
            //
            LoadTileEditor();
            SetTilesetImage();
        }
        public void Reload(MapEditor ownerForm)
        {
            mouseDownTile = 0;
            this.pictureBoxTileset.Height = height;
            //
            this.ownerForm = ownerForm;
            //
            LoadTileEditor();
            SetTilesetImage();
        }

        #region Methods

        private void InitializeVariables()
        {
            this.commandStack = new UndoStack();
        }
        //
        public void SetTilesetImage()
        {
            if (Tileset.Tilesets_tiles[Layer] != null)
            {
                int height = Layer < 2 ? Tileset.Height : Tileset.HeightL3;
                int[] tileSetPixels = Do.TilesetToPixels(Tileset.Tilesets_tiles[Layer], 16, height, 0, false);
                int[] priority1Pixels = Do.TilesetToPixels(Tileset.Tilesets_tiles[Layer], 16, height, 0, true);
                tilesetImage = Do.PixelsToImage(tileSetPixels, 256, height * 16);
                priority1 = Do.PixelsToImage(priority1Pixels, 256, height * 16);
                Picture.Height = height * 16;
            }
            else
            {
                tilesetImage = null;
                priority1 = null;
                Picture.Height = 0;
            }
            Picture.Invalidate();
        }
        /// <summary>
        /// Selects a tile in the tileset and starts a zoom animation on the tile in the picture.
        /// </summary>
        /// <param name="tileNum">The tile's index in the tileset.</param>
        public void ActivateZoomRegion(int tileNum)
        {
            mouseDownTile = tileNum;
            MouseEventArgs mouseEventArgs = new MouseEventArgs(
                MouseButtons.Left, 1,
                mouseDownTile % 16 * 16,
                mouseDownTile / 16 * 16, 0);
            picture_MouseDown(null, mouseEventArgs);
            picture_MouseUp(null, mouseEventArgs);
            overlay.SelectTS.ZoomRegion(tilesetImage);
            Picture.Invalidate();
        }

        // Tile editor
        public void UpdateTile()
        {
            this.Tileset.WriteToModel(16, Layer);
            SetTilesetImage();
            if (autoUpdate.Checked)
                updater.UpdateTileset();
        }
        private void LoadTileEditor()
        {
            if (Tileset.Tilesets_tiles[Layer] == null)
                return;
            switch (Layer)
            {
                case 2: // layer 3
                    if (TileEditor == null)
                    {
                        TileEditor = new TileEditor(ownerForm, ownerForm.TileUpdater, this.Tileset.Tilesets_tiles[Layer][mouseDownTile], Tileset.GraphicsL3);
                        TileEditor.FormClosing += new FormClosingEventHandler(editor_FormClosing);
                    }
                    else
                        TileEditor.Reload(this.Tileset.Tilesets_tiles[Layer][mouseDownTile], Tileset.GraphicsL3);
                    break;
                default:
                    if (TileEditor == null)
                    {
                        TileEditor = new TileEditor(ownerForm, ownerForm.TileUpdater, this.Tileset.Tilesets_tiles[Layer][mouseDownTile], Tileset.Graphics);
                        TileEditor.FormClosing += new FormClosingEventHandler(editor_FormClosing);
                    }
                    else
                        TileEditor.Reload(this.Tileset.Tilesets_tiles[Layer][mouseDownTile], Tileset.Graphics);
                    break;
            }
        }

        #region Selection editing

        private void Cut()
        {
            Copy();
            Delete();
        }
        private void Copy()
        {
            if (overlay.SelectTS.Empty)
                return;
            if (DraggedTiles != null)
            {
                this.copiedTiles = DraggedTiles;
                return;
            }
            // make the copy
            int x_ = overlay.SelectTS.Location.X / 16;
            int y_ = overlay.SelectTS.Location.Y / 16;
            this.copiedTiles = new CopyBuffer(overlay.SelectTS.Width, overlay.SelectTS.Height);
            Tile[] copiedTiles = new Tile[(overlay.SelectTS.Width / 16) * (overlay.SelectTS.Height / 16)];
            for (int y = 0; y < overlay.SelectTS.Height / 16; y++)
            {
                for (int x = 0; x < overlay.SelectTS.Width / 16; x++)
                {
                    copiedTiles[y * (overlay.SelectTS.Width / 16) + x] =
                        Tileset.Tilesets_tiles[Layer][(y + y_) * 16 + x + x_].Copy();
                }
            }
            this.copiedTiles.Tiles = copiedTiles;
        }
        private void Paste(Point area, CopyBuffer buffer)
        {
            if (buffer == null)
                return;
            moving = true;
            // now dragging a new selection
            DraggedTiles = buffer;
            selection = buffer.GetImage();
            overlay.SelectTS.Set(16, area, buffer.Size, Picture);
            this.Picture.Invalidate();
        }
        private void Delete()
        {
            if (overlay.SelectTS.Empty)
                return;
            int x_ = overlay.SelectTS.Location.X / 16;
            int y_ = overlay.SelectTS.Location.Y / 16;
            for (int y = 0; y < overlay.SelectTS.Height / 16; y++)
            {
                for (int x = 0; x < overlay.SelectTS.Width / 16; x++)
                    Tileset.Tilesets_tiles[Layer][(y + y_) * 16 + x + x_].Clear();
            }
            Tileset.ParseTileset(Tileset.Tilesets_tiles[Layer], Tileset.Tilesets_bytes[Layer]);
            Tileset.WriteToModel(16, Layer);
            SetTilesetImage();
            if (autoUpdate.Checked)
                updater.UpdateTileset();
        }
        private void Flip(FlipType flipType)
        {
            if (DraggedTiles != null)
                Defloat(DraggedTiles);
            if (overlay.SelectTS.Empty)
                return;
            int x_ = overlay.SelectTS.Location.X / 16;
            int y_ = overlay.SelectTS.Location.Y / 16;
            CopyBuffer buffer = new CopyBuffer(overlay.SelectTS.Width, overlay.SelectTS.Height);
            Tile[] copiedTiles = new Tile[(overlay.SelectTS.Width / 16) * (overlay.SelectTS.Height / 16)];
            for (int y = 0; y < overlay.SelectTS.Height / 16; y++)
            {
                for (int x = 0; x < overlay.SelectTS.Width / 16; x++)
                {
                    copiedTiles[y * (overlay.SelectTS.Width / 16) + x] =
                        Tileset.Tilesets_tiles[Layer][(y + y_) * 16 + x + x_].Copy();
                }
            }
            if (flipType == FlipType.Horizontal)
                Do.FlipHorizontal(copiedTiles, overlay.SelectTS.Width / 16, overlay.SelectTS.Height / 16);
            else if (flipType == FlipType.Vertical)
                Do.FlipVertical(copiedTiles, overlay.SelectTS.Width / 16, overlay.SelectTS.Height / 16);
            buffer.Tiles = copiedTiles;
            Defloat(buffer);
        }
        private void Priority1(bool priority1)
        {
            if (DraggedTiles != null)
                Defloat(DraggedTiles);
            if (overlay.SelectTS.Empty)
                return;
            int x_ = overlay.SelectTS.Location.X / 16;
            int y_ = overlay.SelectTS.Location.Y / 16;
            for (int y = 0; y < overlay.SelectTS.Height / 16; y++)
            {
                for (int x = 0; x < overlay.SelectTS.Width / 16; x++)
                {
                    var tile = Tileset.Tilesets_tiles[Layer][(y + y_) * 16 + x + x_];
                    foreach (var subtile in tile.Subtiles)
                        subtile.Priority1 = priority1;
                }
            }
            Tileset.ParseTileset(Tileset.Tilesets_tiles[Layer], Tileset.Tilesets_bytes[Layer]);
            SetTilesetImage();
            if (autoUpdate.Checked)
                updater.UpdateTileset();
        }
        /// <summary>
        /// Start dragging a selection.
        /// </summary>
        private void Drag()
        {
            if (overlay.SelectTS.Empty)
                return;
            // make the copy
            int x_ = overlay.SelectTS.Location.X / 16;
            int y_ = overlay.SelectTS.Location.Y / 16;
            this.DraggedTiles = new CopyBuffer(overlay.SelectTS.Width, overlay.SelectTS.Height);
            Tile[] draggedTiles = new Tile[(overlay.SelectTS.Width / 16) * (overlay.SelectTS.Height / 16)];
            for (int y = 0; y < overlay.SelectTS.Height / 16; y++)
            {
                for (int x = 0; x < overlay.SelectTS.Width / 16; x++)
                {
                    draggedTiles[y * (overlay.SelectTS.Width / 16) + x] =
                        Tileset.Tilesets_tiles[Layer][(y + y_) * 16 + x + x_].Copy();
                }
            }
            this.DraggedTiles.Tiles = draggedTiles;
            selection = new Bitmap(this.DraggedTiles.GetImage());
            Delete();
        }
        /// <summary>
        /// "Cements" either a dragged selection or a newly pasted selection.
        /// </summary>
        /// <param name="buffer">The dragged selection or the newly pasted selection.</param>
        public void Defloat(CopyBuffer buffer)
        {
            if (buffer == null)
                return;
            if (overlay.SelectTS.Empty)
                return;
            selection = null;
            int x_ = overlay.SelectTS.X / 16;
            int y_ = overlay.SelectTS.Y / 16;
            for (int y = 0; y < buffer.Height / 16; y++)
            {
                for (int x = 0; x < buffer.Width / 16; x++)
                {
                    if (y + y_ < 0 || y + y_ >= Tileset.Height ||
                        x + x_ < 0 || x + x_ >= 16)
                        continue;
                    int index = (y + y_) * 16 + x + x_;
                    Tile tile = buffer.Tiles[y * (buffer.Width / 16) + x];
                    Tileset.Tilesets_tiles[Layer][index] = tile.Copy();
                    Tileset.Tilesets_tiles[Layer][index].Index = index;
                }
            }
            Tileset.ParseTileset(Tileset.Tilesets_tiles[Layer], Tileset.Tilesets_bytes[Layer]);
            Tileset.WriteToModel(16, Layer);
            SetTilesetImage();
            if (autoUpdate.Checked)
                updater.UpdateTileset();
        }

        #endregion

        #region Import / Export

        private void ImportTitle()
        {
            Layer = 0;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = LazyShell.Properties.Settings.Default.LastRomPath;
            openFileDialog1.Title = "Import Layer 1";
            openFileDialog1.Filter = "Image files (*.gif,*.jpg,*.png)|*.gif;*.jpg;*.png";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() != DialogResult.OK)
                return;
            if (openFileDialog1.FileName == null)
                return;
            Bitmap importL1 = new Bitmap(Image.FromFile(openFileDialog1.FileName));
            if (importL1.Width != 256 || importL1.Height != 512)
            {
                MessageBox.Show(
                    "The dimensions of the imported image must be exactly 256 x 512.",
                    "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            int[] importL1pixels = Do.ImageToPixels(importL1, new Size(256, 512), new Rectangle(0, 0, 256, 512));
            Layer = 1;
            openFileDialog1.Title = "Import Layer 2";
            if (openFileDialog1.ShowDialog() != DialogResult.OK)
                return;
            if (openFileDialog1.FileName == null)
                return;
            Bitmap importL2 = new Bitmap(Image.FromFile(openFileDialog1.FileName));
            if (importL2.Width != 256 || importL2.Height != 512)
            {
                MessageBox.Show(
                    "The dimensions of the imported image must be exactly 256 x 512.",
                    "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            int[] importL2pixels = Do.ImageToPixels(importL2, new Size(256, 512), new Rectangle(0, 0, 256, 512));
            // now combine the two into one pixel array
            int[] importPixels = new int[256 * 1024];
            for (int y = 0; y < 512; y++)
            {
                for (int x = 0; x < 256; x++)
                {
                    importPixels[y * 256 + x] = importL1pixels[y * 256 + x];
                    importPixels[(y + 512) * 256 + x] = importL2pixels[y * 256 + x];
                }
            }
            byte[] graphics = new byte[0x20000];
            int[][] palettes = new int[8][];
            for (int i = 0; i < 8; i++)
                palettes[i] = PaletteSet.Palettes[i];
            int[] paletteIndexes = Do.PixelsToBPP(
                importPixels, graphics,
                new Size(256 / 8, 1024 / 8), palettes, 0x20);
            if (paletteIndexes == null)
                return;
            byte[] tileset = new byte[0x2000];
            Do.CopyToTileset(graphics, tileset, palettes, paletteIndexes, true, false, 0x20, 2, new Size(256, 1024), 0);
            Buffer.BlockCopy(tileset, 0, Intro.Model.Title_Data, 0, 0x2000);
            Buffer.BlockCopy(graphics, 0, Intro.Model.Title_Data, 0x6C00, 0x4FE0);
            Intro.Model.Title_Tileset = new Tileset(PaletteSet, TilesetType.Title);
            this.Tileset = Intro.Model.Title_Tileset;
        }
        private void ImportTitleLogo()
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = LazyShell.Properties.Settings.Default.LastRomPath;
            openFileDialog1.Title = "Import title logo";
            openFileDialog1.Filter = "Image files (*.gif,*.jpg,*.png)|*.gif;*.jpg;*.png";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() != DialogResult.OK)
                return;
            if (openFileDialog1.FileName == null)
                return;
            Bitmap import = new Bitmap(Image.FromFile(openFileDialog1.FileName));
            if (import.Width != 256 || import.Height != 96)
            {
                MessageBox.Show(
                    "The dimensions of the imported image must be 256 x 96.",
                    "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            byte[] graphics = new byte[0x3000];
            byte[] gameTitle = new byte[0x1C00];
            byte[] gameCopyright = new byte[0x1400];
            int[] palette = PaletteSet.Palettes[3];
            Do.PixelsToBPP(
                Do.ImageToPixels(import, new Size(256, 56), new Rectangle(0, 0, 256, 56)), gameTitle,
                new Size(256 / 8, 56 / 8), palette, 0x20);
            palette = PaletteSet.Palettes[6];
            Do.PixelsToBPP(
                Do.ImageToPixels(import, new Size(256, 56), new Rectangle(0, 56, 256, 40)), gameCopyright,
                new Size(256 / 8, 40 / 8), palette, 0x20);
            Buffer.BlockCopy(gameTitle, 0, graphics, 0, 0x1C00);
            Buffer.BlockCopy(gameCopyright, 0, graphics, 0x1C00, 0x1400);
            byte[] tileset = new byte[0x300];
            byte[] tilesetTitle = new byte[0x300];
            byte[] tilesetCopyright = new byte[0x300];
            byte[] temp = new byte[graphics.Length]; graphics.CopyTo(temp, 0);
            Do.CopyToTileset(graphics, tilesetTitle, palette, 3, true, true, 0x20, 2, new Size(256, 96), 2);
            Do.CopyToTileset(temp, tilesetCopyright, palette, 6, true, true, 0x20, 2, new Size(256, 96), 2);
            Buffer.BlockCopy(tilesetTitle, 0, tileset, 0, 0x300);
            Buffer.BlockCopy(tilesetCopyright, 0x1C0, tileset, 0x1C0, 0x140);
            Buffer.BlockCopy(tileset, 0, Intro.Model.Title_Data, 0xBBE0, 0x300);
            Buffer.BlockCopy(graphics, 0, Intro.Model.Title_Data, 0xBEE0, 0x1B80);
            Intro.Model.Title_Tileset = new Tileset(PaletteSet, TilesetType.Title);
            this.Tileset = Intro.Model.Title_Tileset;
        }

        #endregion

        #endregion

        #region Event handlers

        // TilesetForm
        private void TilesetForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.overlay.SelectTS.Clear();
        }
        private void TilesetForm_VisibleChanged(object sender, EventArgs e)
        {
            this.overlay.SelectTS.Clear();
        }

        // Picture
        private void picture_Paint(object sender, PaintEventArgs e)
        {
            this.ownerForm.Layer = this.Layer;
            if (tilesetImage == null)
                return;
            e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
            Rectangle rdst = new Rectangle(0, 0, 256, height);
            if (toggleBG.Checked)
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(PaletteSet.Palette[16])), rdst);
            e.Graphics.DrawImage(tilesetImage, rdst, 0, 0, 256, height, GraphicsUnit.Pixel);
            if (moving && selection != null)
            {
                Rectangle rsrc = new Rectangle(0, 0, overlay.SelectTS.Width, overlay.SelectTS.Height);
                rdst = new Rectangle(
                    overlay.SelectTS.X * zoom, overlay.SelectTS.Y * zoom,
                    rsrc.Width * zoom, rsrc.Height * zoom);
                e.Graphics.DrawImage(new Bitmap(selection), rdst, rsrc, GraphicsUnit.Pixel);
                Do.DrawString(e.Graphics, new Point(rdst.X, rdst.Y + rdst.Height),
                    "click/drag", Color.White, Color.Black, new Font("Tahoma", 6.75F, FontStyle.Bold));
            }
            float[][] matrixItems ={ 
               new float[] {1, 0, 0, 0, 0},
               new float[] {0, 1, 0, 0, 0},
               new float[] {0, 0, 1, 0, 0},
               new float[] {0, 0, 0, 0.50F, 0}, 
               new float[] {0, 0, 0, 0, 1}};
            ColorMatrix cm = new ColorMatrix(matrixItems);
            ImageAttributes ia = new ImageAttributes();
            ia.SetColorMatrix(cm, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
            if (priority1 != null && toggleP1.Checked)
                e.Graphics.DrawImage(priority1, rdst, 0, 0, 256, height, GraphicsUnit.Pixel, ia);
            if (mouseEnter)
            {
                Point location = new Point(mousePosition.X / 16 * 16 * zoom, mousePosition.Y / 16 * 16 * zoom);
                overlay.DrawHoverBox(e.Graphics, location, new Size(16 * zoom, 16 * zoom), zoom, true);
            }
            if (Rails)
                overlay.DrawRailProperties(null, 16, 16, e.Graphics, 1);
            if (toggleTileGrid.Checked)
                overlay.DrawTileGrid(e.Graphics, Color.Gray, Picture.Size, new Size(16, 16), 1, true);
            if (overlay.SelectTS != null)
                overlay.SelectTS.DrawSelectionBox(e.Graphics, 1);
        }
        private void picture_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Clicks > 1)
                return;
            if (e.Button == MouseButtons.Right)
                return;
            mouseDownObject = MapObject.None;
            this.ownerForm.Layer = this.Layer;

            // set a floor and ceiling for the coordinates
            int x = Math.Max(0, Math.Min(e.X, Picture.Width));
            int y = Math.Max(0, Math.Min(e.Y, Picture.Height));
            Picture.Focus();

            // if moving an object and outside of it, paste it
            if (moving && mouseOverObject != MapObject.Selection)
            {
                // if copied tiles were pasted and not dragging a non-copied selection
                if (copiedTiles != null && DraggedTiles == null)
                    Defloat(copiedTiles);
                if (DraggedTiles != null)
                {
                    Defloat(DraggedTiles);
                    DraggedTiles = null;
                }
                selection = null;
                moving = false;
            }

            // if making a new selection
            if (e.Button == MouseButtons.Left && mouseOverObject == MapObject.None)
                overlay.SelectTS.Reload(16, x / 16 * 16, y / 16 * 16, 16, 16, Picture);

            // if moving a current selection
            if (!lockEditing.Checked && e.Button == MouseButtons.Left && mouseOverObject == MapObject.Selection)
            {
                mouseDownObject = MapObject.Selection;
                mouseDownPosition = overlay.SelectTS.MousePosition(x, y);
                if (!moving)    // only do this if the current selection has not been initially moved
                {
                    moving = true;
                    Drag();
                }
            }
            mouseDownTile = y / 16 * 16 + (x / 16);
            LoadTileEditor();
        }
        private void picture_MouseMove(object sender, MouseEventArgs e)
        {
            mouseOverObject = MapObject.None;

            // set a floor and ceiling for the coordinates
            int x = Math.Max(0, Math.Min(e.X, Picture.Width));
            int y = Math.Max(0, Math.Min(e.Y, Picture.Height));
            mousePosition = new Point(x, y);

            // if making a new selection
            if (e.Button == MouseButtons.Left && mouseDownObject == MapObject.None && overlay.SelectTS != null)
                overlay.SelectTS.Final = new Point(
                        Math.Min(x + 16, Picture.Width),
                        Math.Min(y + 16, Picture.Height));

            // if dragging the current selection
            if (e.Button == MouseButtons.Left && mouseDownObject == MapObject.Selection)
                overlay.SelectTS.Location = new Point(
                    x / 16 * 16 - mouseDownPosition.X,
                    y / 16 * 16 - mouseDownPosition.Y);

            // check if over selection
            if (!lockEditing.Checked && e.Button == MouseButtons.None && overlay.SelectTS != null && overlay.SelectTS.MouseWithin(x, y))
            {
                mouseOverObject = MapObject.Selection;
                Picture.Cursor = Cursors.SizeAll;
            }
            else
                Picture.Cursor = Cursors.Cross;
            Picture.Invalidate();
            int index = y / 16 * 16 + (x / 16);
            labelTileIndex.Text = "Tile index: " + index + " ($" + index.ToString("X2") + ")";
        }
        private void picture_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                return;
            if (overlay.SelectTS.Empty)
                return;
            int x_ = overlay.SelectTS.Location.X / 16;
            int y_ = overlay.SelectTS.Location.Y / 16;
            if (this.SelectedTiles == null)
                this.SelectedTiles = new CopyBuffer(overlay.SelectTS.Width, overlay.SelectTS.Height);
            int[][] selectedTiles = new int[3][];
            selectedTiles[Layer] = new int[(overlay.SelectTS.Width / 16) * (overlay.SelectTS.Height / 16)];
            for (int y = 0; y < overlay.SelectTS.Height / 16; y++)
            {
                for (int x = 0; x < overlay.SelectTS.Width / 16; x++)
                    selectedTiles[Layer][y * (overlay.SelectTS.Width / 16) + x] = (y + y_) * 16 + x + x_;
            }
            this.SelectedTiles.Copies = selectedTiles;
            Picture.Focus();
        }
        private void picture_MouseEnter(object sender, EventArgs e)
        {
            mouseEnter = true;
            Picture.Invalidate();
        }
        private void picture_MouseLeave(object sender, EventArgs e)
        {
            mouseEnter = false;
            Picture.Invalidate();
        }
        private void picture_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == (Keys.Control | Keys.V) && !lockEditing.Checked)
                editPaste.PerformClick();
            if (e.KeyData == (Keys.Control | Keys.C) && !lockEditing.Checked)
                editCopy.PerformClick();
            if (e.KeyData == Keys.Delete && !lockEditing.Checked)
                editDelete.PerformClick();
            if (e.KeyData == (Keys.Control | Keys.X) && !lockEditing.Checked)
                editCut.PerformClick();
            if (e.KeyData == (Keys.Control | Keys.D))
            {
                if (DraggedTiles != null)
                    Defloat(DraggedTiles);
                else
                {
                    overlay.SelectTS.Clear();
                    Cursor.Position = Cursor.Position;
                    Picture.Invalidate();
                }
            }
            if (e.KeyData == (Keys.Control | Keys.A))
            {
                overlay.SelectTS.Reload(16, 0, 0, 1024, 1024, Picture);
                Picture.Invalidate();
            }
        }

        // ToolStrip - Toggle
        private void toggleTileEditor_Click(object sender, EventArgs e)
        {
            TileEditor.Visible = true;
        }
        private void toggleTileGrid_Click(object sender, EventArgs e)
        {
            this.Picture.Invalidate();
        }
        private void toggleBG_Click(object sender, EventArgs e)
        {
            this.Picture.Invalidate();
        }
        private void toggleP1_Click(object sender, EventArgs e)
        {
            this.Picture.Invalidate();
        }

        // ToolStrip - Editing
        private void editDelete_Click(object sender, EventArgs e)
        {
            if (lockEditing.Checked)
                return;
            Delete();
        }
        private void editCut_Click(object sender, EventArgs e)
        {
            if (lockEditing.Checked)
                return;
            Cut();
        }
        private void editCopy_Click(object sender, EventArgs e)
        {
            if (lockEditing.Checked)
                return;
            Copy();
        }
        private void editPaste_Click(object sender, EventArgs e)
        {
            if (lockEditing.Checked)
                return;
            if (DraggedTiles != null)
                Defloat(DraggedTiles);
            Paste(new Point(16, 16), copiedTiles);
        }
        private void editUndo_Click(object sender, EventArgs e)
        {
        }
        private void editRedo_Click(object sender, EventArgs e)
        {
        }

        // ContextMenuStrip
        private void contextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            menuCut.Enabled = !lockEditing.Checked;
            menuCopy.Enabled = !lockEditing.Checked;
            menuPaste.Enabled = !lockEditing.Checked;
            menuDelete.Enabled = !lockEditing.Checked;
            menuP1Set.Enabled = !lockEditing.Checked;
            menuP1Clear.Enabled = !lockEditing.Checked;
            menuMirror.Enabled = !lockEditing.Checked;
            menuInvert.Enabled = !lockEditing.Checked;
            menuImportImage.Visible = Tileset.Type == TilesetType.Title;
        }
        private void menuP1Set_Click(object sender, EventArgs e)
        {
            if (lockEditing.Checked)
                return;
            Priority1(true);
        }
        private void menuP1Clear_Click(object sender, EventArgs e)
        {
            if (lockEditing.Checked)
                return;
            Priority1(false);
        }
        private void menuMirror_Click(object sender, EventArgs e)
        {
            if (lockEditing.Checked)
                return;
            Flip(FlipType.Horizontal);
        }
        private void menuInvert_Click(object sender, EventArgs e)
        {
            if (lockEditing.Checked)
                return;
            Flip(FlipType.Vertical);
        }
        private void menuSaveImageAs_Click(object sender, EventArgs e)
        {
            Do.Export(tilesetImage, "tileset.png");
        }
        private void menuImportImage_Click(object sender, EventArgs e)
        {
            if (Layer < 2)
                ImportTitle();
            else
                ImportTitleLogo();
            //
            SetTilesetImage();
            if (autoUpdate.Checked)
                updater.UpdateTileset();
        }

        // Editing
        private void lockEditing_CheckedChanged(object sender, EventArgs e)
        {
            editDelete.Enabled = !lockEditing.Checked;
            editCut.Enabled = !lockEditing.Checked;
            editCopy.Enabled = !lockEditing.Checked;
            editPaste.Enabled = !lockEditing.Checked;
            editMirror.Enabled = !lockEditing.Checked;
            editInvert.Enabled = !lockEditing.Checked;
        }
        private void updateTilemap_Click(object sender, EventArgs e)
        {
            updater.UpdateTileset();
        }
        private void editor_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            (sender as Form).Hide();
        }

        #endregion
    }
}
