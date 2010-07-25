using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Forms;

namespace LAZYSHELL
{
    public partial class Title : Form
    {
        #region Variables
        // main
        private delegate void Function();
        private Model model;
        private PaletteSet paletteSet { get { return model.TitlePalettes; } set { model.TitlePalettes = value; } }
        private PaletteSet spritePaletteSet { get { return model.TitleSpritePalettes; } set { model.TitleSpritePalettes = value; } }
        private TitleTileset tileSet { get { return model.TitleTileSet; } set { model.TitleTileSet = value; } }
        private Overlay overlay;
        private int layer { get { return tabControl2.SelectedIndex; } set { tabControl2.SelectedIndex = value; } }
        private PictureBox pictureBoxTileset
        {
            get
            {
                if (layer == 0) return pictureBoxTitleL1;
                if (layer == 1) return pictureBoxTitleL2;
                return pictureBoxTitleLogo;
            }
        }
        private Bitmap[] tilesetImage = new Bitmap[3];
        // mouse
        private Point mousePosition;
        private Point mouseDownPosition;
        private string mouseDownObject;
        private string mouseOverObject;
        private int mouseDownTile = 0;
        public int MouseDownTile
        {
            get { return mouseDownTile; }
            set
            {
                mouseDownTile = value;
                pictureBoxTileset_MouseDown(null,
                    new MouseEventArgs(MouseButtons.Left, 1, value % 16 * 16, value / 16 * 16, 0));
                pictureBoxTileset.Invalidate();
            }
        }
        private bool mouseEnter = false;
        private bool moving = false;
        // buffers and stacks
        private Bitmap selection;
        private CopyBuffer copiedTiles;
        private CopyBuffer draggedTiles; public CopyBuffer DraggedTiles { get { return draggedTiles; } }
        // editors
        private PaletteEditor paletteEditor;
        private GraphicEditor graphicEditor;
        private PaletteEditor spritePaletteEditor;
        private GraphicEditor spriteGraphicEditor;
        private TileEditor tileEditor;
        #endregion
        #region Functions
        public Title(Model model)
        {
            this.model = model;
            this.overlay = new Overlay();
            InitializeComponent();
            Do.AddShortcut(toolStrip1, Keys.Control | Keys.S, new EventHandler(save_Click));
            SetTilesetImages();
            pictureBoxTitle.Invalidate();
            LoadPaletteEditor();
            LoadGraphicEditor();
            LoadTileEditor();
            LoadSpritePaletteEditor();
            LoadSpriteGraphicEditor();
            GC.Collect();
        }
        // set images
        private void SetTilesetImage()
        {
            int[] pixels = Do.TilesetToPixels(tileSet.TileSetLayers[layer], 16, tileSet.TileSetLayers[layer].Length / 16, 0, false);
            tilesetImage[layer] = new Bitmap(Do.PixelsToImage(pixels, 256, pictureBoxTileset.Height));
            pictureBoxTileset.Invalidate();
        }
        private void SetTilesetImages()
        {
            int[] pixels = Do.TilesetToPixels(tileSet.TileSetLayers[0], 16, 32, 0, false);
            tilesetImage[0] = new Bitmap(Do.PixelsToImage(pixels, 256, 512));
            pictureBoxTitleL1.Invalidate();
            pixels = Do.TilesetToPixels(tileSet.TileSetLayers[1], 16, 32, 0, false);
            tilesetImage[1] = new Bitmap(Do.PixelsToImage(pixels, 256, 512));
            pictureBoxTitleL2.Invalidate();
            pixels = Do.TilesetToPixels(tileSet.TileSetLayers[2], 16, 6, 0, false);
            tilesetImage[2] = new Bitmap(Do.PixelsToImage(pixels, 256, 96));
            pictureBoxTitleLogo.Invalidate();
        }
        // tile editor
        private void LoadTileEditor()
        {
            if (tileEditor == null)
            {
                tileEditor = new TileEditor(new Function(TileUpdate),
                    this.tileSet.TileSetLayers[layer][mouseDownTile], layer != 2 ? tileSet.Graphics : tileSet.GraphicsL3, paletteSet, 0x20);
                tileEditor.FormClosing += new FormClosingEventHandler(editor_FormClosing);
            }
            else
                tileEditor.Reload(new Function(TileUpdate),
                    this.tileSet.TileSetLayers[layer][mouseDownTile], layer != 2 ? tileSet.Graphics : tileSet.GraphicsL3, paletteSet, 0x20);
        }
        private void LoadPaletteEditor()
        {
            if (paletteEditor == null)
            {
                paletteEditor = new PaletteEditor(new Function(PaletteUpdate), paletteSet, 8, 0);
                paletteEditor.FormClosing += new FormClosingEventHandler(editor_FormClosing);
            }
            else
                paletteEditor.Reload(new Function(PaletteUpdate), paletteSet, 8, 0);
        }
        private void LoadGraphicEditor()
        {
            if (graphicEditor == null)
            {
                graphicEditor = new GraphicEditor(new Function(GraphicUpdate),
                    layer != 2 ? tileSet.Graphics : tileSet.GraphicsL3,
                    layer != 2 ? tileSet.Graphics.Length : tileSet.GraphicsL3.Length,
                    0, paletteSet, 0, 0x20);
                graphicEditor.FormClosing += new FormClosingEventHandler(editor_FormClosing);
            }
            else
                graphicEditor.Reload(new Function(GraphicUpdate),
                    layer != 2 ? tileSet.Graphics : tileSet.GraphicsL3,
                    layer != 2 ? tileSet.Graphics.Length : tileSet.GraphicsL3.Length,
                    0, paletteSet, 0, 0x20);
        }
        private void LoadSpritePaletteEditor()
        {
            if (spritePaletteEditor == null)
            {
                spritePaletteEditor = new PaletteEditor(new Function(SpritePaletteUpdate), spritePaletteSet, 5, 0);
                spritePaletteEditor.FormClosing += new FormClosingEventHandler(editor_FormClosing);
            }
            else
                spritePaletteEditor.Reload(new Function(SpritePaletteUpdate), spritePaletteSet, 5, 0);
        }
        private void LoadSpriteGraphicEditor()
        {
            if (spriteGraphicEditor == null)
            {
                spriteGraphicEditor = new GraphicEditor(new Function(SpriteGraphicUpdate),
                    model.TitleSpriteGraphics, model.TitleSpriteGraphics.Length, 0, spritePaletteSet, 0, 0x20);
                spriteGraphicEditor.FormClosing += new FormClosingEventHandler(editor_FormClosing);
            }
            else
                spriteGraphicEditor.Reload(new Function(SpriteGraphicUpdate),
                    model.TitleSpriteGraphics, model.TitleSpriteGraphics.Length, 0, spritePaletteSet, 0, 0x20);
        }
        private void TileUpdate()
        {
            this.tileSet.AssembleIntoModel(16, layer);
            SetTilesetImages();
        }
        private void PaletteUpdate()
        {
            tileSet = new TitleTileset(paletteSet, model);
            SetTilesetImages();
            pictureBoxTitle.Invalidate();
            LoadGraphicEditor();
            LoadTileEditor();
        }
        private void GraphicUpdate()
        {
            tileSet.AssembleIntoModel(16);
            tileSet = new TitleTileset(paletteSet, model);
            SetTilesetImages();
            pictureBoxTitle.Invalidate();
            LoadTileEditor();
        }
        private void SpritePaletteUpdate()
        {
            LoadSpriteGraphicEditor();
        }
        private void SpriteGraphicUpdate()
        {
        }
        // editing
        private void DrawHoverBox(Graphics g)
        {
            Rectangle r = new Rectangle(mousePosition.X / 16 * 16, mousePosition.Y / 16 * 16, 16, 16);
            g.FillRectangle(new SolidBrush(Color.FromArgb(96, 0, 0, 0)), r);
        }
        private void Copy()
        {
            if (overlay.SelectTS == null) return;
            if (draggedTiles != null)
            {
                this.copiedTiles = draggedTiles;
                return;
            }
            // make the copy
            int x_ = overlay.SelectTS.Location.X / 16;
            int y_ = overlay.SelectTS.Location.Y / 16;
            this.copiedTiles = new CopyBuffer(overlay.SelectTS.Width, overlay.SelectTS.Height);
            Tile16x16[] copiedTiles = new Tile16x16[(overlay.SelectTS.Width / 16) * (overlay.SelectTS.Height / 16)];
            for (int y = 0; y < overlay.SelectTS.Height / 16; y++)
            {
                for (int x = 0; x < overlay.SelectTS.Width / 16; x++)
                {
                    copiedTiles[y * (overlay.SelectTS.Width / 16) + x] =
                        tileSet.TileSetLayers[layer][(y + y_) * 16 + x + x_].Copy();
                }
            }
            this.copiedTiles.Tiles = copiedTiles;
        }
        /// <summary>
        /// Start dragging a selection.
        /// </summary>
        private void Drag()
        {
            if (overlay.SelectTS == null) return;
            // make the copy
            int x_ = overlay.SelectTS.Location.X / 16;
            int y_ = overlay.SelectTS.Location.Y / 16;
            this.draggedTiles = new CopyBuffer(overlay.SelectTS.Width, overlay.SelectTS.Height);
            Tile16x16[] draggedTiles = new Tile16x16[(overlay.SelectTS.Width / 16) * (overlay.SelectTS.Height / 16)];
            for (int y = 0; y < overlay.SelectTS.Height / 16; y++)
            {
                for (int x = 0; x < overlay.SelectTS.Width / 16; x++)
                {
                    draggedTiles[y * (overlay.SelectTS.Width / 16) + x] =
                        tileSet.TileSetLayers[layer][(y + y_) * 16 + x + x_].Copy();
                }
            }
            this.draggedTiles.Tiles = draggedTiles;
            selection = new Bitmap(this.draggedTiles.Image);
            Delete();
        }
        private void Cut()
        {
            Copy();
            Delete();
        }
        private void Paste(Point location, CopyBuffer buffer)
        {
            if (buffer == null) return;
            moving = true;
            // now dragging a new selection
            draggedTiles = buffer;
            selection = buffer.Image;
            overlay.SelectTS = new Overlay.Selection(16, location, buffer.Size);
            this.pictureBoxTileset.Invalidate();
        }
        /// <summary>
        /// "Cements" either a dragged selection or a newly pasted selection.
        /// </summary>
        /// <param name="buffer">The dragged selection or the newly pasted selection.</param>
        public void PasteFinal(CopyBuffer buffer)
        {
            if (buffer == null) return;
            selection = null;
            int x_ = overlay.SelectTS.X / 16;
            int y_ = overlay.SelectTS.Y / 16;
            for (int y = 0; y < buffer.Height / 16; y++)
            {
                for (int x = 0; x < buffer.Width / 16; x++)
                {
                    Tile16x16 tile = buffer.Tiles[y * (buffer.Width / 16) + x];
                    tileSet.TileSetLayers[layer][(y + y_) * 16 + x + x_] = tile.Copy();
                }
            }
            overlay.SelectTS = null;
            tileSet.DrawTileset(tileSet.TileSetLayers[layer], tileSet.TileSets[layer]);
            SetTilesetImage();
            pictureBoxTitle.Invalidate();
        }
        private void Delete()
        {
            if (overlay.SelectTS == null) return;
            int x_ = overlay.SelectTS.Location.X / 16;
            int y_ = overlay.SelectTS.Location.Y / 16;
            for (int y = 0; y < overlay.SelectTS.Height / 16; y++)
            {
                for (int x = 0; x < overlay.SelectTS.Width / 16; x++)
                    tileSet.TileSetLayers[layer][(y + y_) * 16 + x + x_].Clear();
            }
            tileSet.DrawTileset(tileSet.TileSetLayers[layer], tileSet.TileSets[layer]);
            SetTilesetImage();
            pictureBoxTitle.Invalidate();
        }
        private void Flip(string type)
        {
            if (draggedTiles != null)
                PasteFinal(draggedTiles);
            if (overlay.SelectTS == null) return;
            int x_ = overlay.SelectTS.Location.X / 16;
            int y_ = overlay.SelectTS.Location.Y / 16;
            CopyBuffer buffer = new CopyBuffer(overlay.SelectTS.Width, overlay.SelectTS.Height);
            Tile16x16[] copiedTiles = new Tile16x16[(overlay.SelectTS.Width / 16) * (overlay.SelectTS.Height / 16)];
            for (int y = 0; y < overlay.SelectTS.Height / 16; y++)
            {
                for (int x = 0; x < overlay.SelectTS.Width / 16; x++)
                {
                    copiedTiles[y * (overlay.SelectTS.Width / 16) + x] =
                        tileSet.TileSetLayers[layer][(y + y_) * 16 + x + x_].Copy();
                }
            }
            if (type == "mirror")
                Do.FlipHorizontal(copiedTiles, overlay.SelectTS.Width / 16, overlay.SelectTS.Height / 16);
            else if (type == "invert")
                Do.FlipVertical(copiedTiles, overlay.SelectTS.Width / 16, overlay.SelectTS.Height / 16);
            buffer.Tiles = copiedTiles;
            PasteFinal(buffer);
            tileSet.DrawTileset(tileSet.TileSetLayers[layer], tileSet.TileSets[layer]);
            SetTilesetImage();
            pictureBoxTitle.Invalidate();
        }
        // import/export
        private void ImportTitle()
        {
            tabControl2.SelectedIndex = 0;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = LAZYSHELL.Properties.Settings.Default.LastRomPath;
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
            tabControl2.SelectedIndex = 1;
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
                palettes[i] = paletteSet.Palettes[i];
            int[] paletteIndexes = Do.PixelsToBPP(
                importPixels, graphics,
                new Size(256 / 8, 1024 / 8), palettes, 0x20);
            if (paletteIndexes == null) return;
            byte[] tileset = new byte[0x2000];
            Do.CopyToTileset(graphics, tileset, palettes, paletteIndexes, true, false, 0x20, 2, new Size(256, 1024), 0);
            Buffer.BlockCopy(tileset, 0, model.TitleData, 0, 0x2000);
            Buffer.BlockCopy(graphics, 0, model.TitleData, 0x6C00, 0x4FE0);
            tileSet = new TitleTileset(paletteSet, model);
            SetTilesetImages();
            pictureBoxTitle.Invalidate();
        }
        private void ImportTitleLogo()
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = LAZYSHELL.Properties.Settings.Default.LastRomPath;
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

            int[] palette = paletteSet.Palettes[3];
            Do.PixelsToBPP(
                Do.ImageToPixels(import, new Size(256, 56), new Rectangle(0, 0, 256, 56)), gameTitle,
                new Size(256 / 8, 56 / 8), palette, 0x20);
            palette = paletteSet.Palettes[6];
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

            Buffer.BlockCopy(tileset, 0, model.TitleData, 0xBBE0, 0x300);
            Buffer.BlockCopy(graphics, 0, model.TitleData, 0xBEE0, 0x1B80);

            tileSet = new TitleTileset(paletteSet, model);

            SetTilesetImage();
            pictureBoxTitle.Invalidate();
        }
        public void Assemble()
        {
            // Palette set
            paletteSet.Assemble();
            spritePaletteSet.Assemble();
            tileSet.AssembleIntoModel(16);
            // Tilesets
            byte[] compressed = new byte[0xDA60];
            int size = model.Compress(model.TitleData, compressed);
            int totalSize = size + 1;
            if (totalSize > 0x7E91)
            {
                MessageBox.Show(
                    "Recompressed data exceeds allotted ROM space by " +
                    (totalSize - 0x7E91).ToString() + " bytes.\nMain title was not saved.",
                    "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Bits.SetByteArray(model.Data, 0x3F216F, compressed, 0, size - 1);
            }
        }
        #endregion
        #region Event Handlers
        private void Title_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Main Title has not been saved.\n\nWould you like to save changes?", "LAZY SHELL",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
                Assemble();
            else if (result == DialogResult.No)
            {
                model.TitleData = null;
                model.TitlePalettes = null;
                model.TitleSpriteGraphics = null;
                model.TitleSpritePalettes = null;
                model.TitleTileSet = null;
                return;
            }
            else if (result == DialogResult.Cancel)
            {
                e.Cancel = true;
                return;
            }
            if (paletteEditor != null && paletteEditor.Visible)
                paletteEditor.Close();
            if (graphicEditor != null && graphicEditor.Visible)
                graphicEditor.Close();
            if (spritePaletteEditor != null && spritePaletteEditor.Visible)
                spritePaletteEditor.Close();
            if (spriteGraphicEditor != null && spriteGraphicEditor.Visible)
                spriteGraphicEditor.Close();
            if (tileEditor != null && tileEditor.Visible)
                tileEditor.Close();
        }
        private void tabControl2_SelectedIndexChanged(object sender, EventArgs e)
        {
            mouseDownTile = 0;
            if (draggedTiles != null)
                PasteFinal(draggedTiles);
            else
                overlay.SelectTS = null;
            pictureBoxTileset.Invalidate();
            LoadGraphicEditor();
            LoadTileEditor();
        }
        private void pictureBoxTitle_Paint(object sender, PaintEventArgs e)
        {
            if (tilesetImage[0] != null && tilesetImage[1] != null && tilesetImage[2] != null)
            {
                Color bgcolor = Color.FromArgb(paletteSet.Palette[0]);
                e.Graphics.FillRectangle(new SolidBrush(bgcolor), new Rectangle(new Point(0, 0), pictureBoxTitle.Size));
                e.Graphics.DrawImage(tilesetImage[1], 0, 0);
                e.Graphics.DrawImage(tilesetImage[0], 0, 0);

                Rectangle upperPart = new Rectangle(0, 0, 256, 72);
                Rectangle lowerPart = new Rectangle(0, 72, 256, 24);
                e.Graphics.DrawImage(tilesetImage[2].Clone(upperPart, PixelFormat.DontCare), 0, 208);
                e.Graphics.DrawImage(tilesetImage[2].Clone(lowerPart, PixelFormat.DontCare), 0, 368);
            }
        }
        private void pictureBoxTileset_Paint(object sender, PaintEventArgs e)
        {
            if (tilesetImage == null) return;
            Rectangle rdst = new Rectangle(0, 0, pictureBoxTileset.Width, pictureBoxTileset.Height);
            if (showBG.Checked)
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(paletteSet.Palette[0])), rdst);
            e.Graphics.DrawImage(tilesetImage[layer], rdst, 0, 0, pictureBoxTileset.Width, pictureBoxTileset.Height, GraphicsUnit.Pixel);
            if (moving && selection != null)
            {
                Rectangle rsrc = new Rectangle(0, 0, overlay.SelectTS.Width, overlay.SelectTS.Height);
                rdst = new Rectangle(overlay.SelectTS.X, overlay.SelectTS.Y, rsrc.Width, rsrc.Height);
                e.Graphics.DrawImage(new Bitmap(selection), rdst, rsrc, GraphicsUnit.Pixel);
            }
            if (mouseEnter)
                DrawHoverBox(e.Graphics);
            if (showGrid.Checked)
                overlay.DrawCartographicGrid(e.Graphics, Color.Gray, pictureBoxTileset.Size, new Size(16, 16), 1);
            if (overlay.SelectTS != null)
                overlay.DrawSelectionBox(e.Graphics, overlay.SelectTS.Terminal, overlay.SelectTS.Location, 1);
        }
        private void pictureBoxTileset_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) return;
            mouseDownObject = null;
            // set a floor and ceiling for the coordinates
            int x = Math.Max(0, Math.Min(e.X, pictureBoxTileset.Width));
            int y = Math.Max(0, Math.Min(e.Y, pictureBoxTileset.Height));
            pictureBoxTileset.Focus();
            // if moving an object and outside of it, paste it
            if (moving && mouseOverObject != "selection")
            {
                // if copied tiles were pasted and not dragging a non-copied selection
                if (copiedTiles != null && draggedTiles == null)
                    PasteFinal(copiedTiles);
                if (draggedTiles != null)
                {
                    PasteFinal(draggedTiles);
                    draggedTiles = null;
                }
                selection = null;
                moving = false;
            }
            // if making a new selection
            if (e.Button == MouseButtons.Left && mouseOverObject == null)
                overlay.SelectTS = new Overlay.Selection(16, x / 16 * 16, y / 16 * 16, 16, 16);
            // if moving a current selection
            if (e.Button == MouseButtons.Left && mouseOverObject == "selection")
            {
                mouseDownObject = "selection";
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
        private void pictureBoxTileset_MouseMove(object sender, MouseEventArgs e)
        {
            mouseOverObject = null;
            // set a floor and ceiling for the coordinates
            int x = Math.Max(0, Math.Min(e.X, pictureBoxTileset.Width));
            int y = Math.Max(0, Math.Min(e.Y, pictureBoxTileset.Height));
            mousePosition = new Point(x, y);
            // if making a new selection
            if (e.Button == MouseButtons.Left && mouseDownObject == null && overlay.SelectTS != null)
                overlay.SelectTS.Final = new Point(
                        Math.Min(x + 16, pictureBoxTileset.Width),
                        Math.Min(y + 16, pictureBoxTileset.Height));
            // if dragging the current selection
            if (e.Button == MouseButtons.Left && mouseDownObject == "selection")
                overlay.SelectTS.Location = new Point(
                    x / 16 * 16 - mouseDownPosition.X,
                    y / 16 * 16 - mouseDownPosition.Y);
            // check if over selection
            if (e.Button == MouseButtons.None && overlay.SelectTS != null && overlay.SelectTS.MouseWithin(x, y))
            {
                mouseOverObject = "selection";
                pictureBoxTileset.Cursor = Cursors.SizeAll;
            }
            else
                pictureBoxTileset.Cursor = Cursors.Cross;
            pictureBoxTileset.Invalidate();
        }
        private void pictureBoxTileset_MouseEnter(object sender, EventArgs e)
        {
            mouseEnter = true;
            pictureBoxTileset.Invalidate();
        }
        private void pictureBoxTileset_MouseLeave(object sender, EventArgs e)
        {
            mouseEnter = false;
            pictureBoxTileset.Invalidate();
        }
        private void pictureBoxTileset_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == (Keys.Control | Keys.V))
                buttonEditPaste_Click(null, null);
            if (e.KeyData == (Keys.Control | Keys.C))
                buttonEditCopy_Click(null, null);
            if (e.KeyData == Keys.Delete)
                buttonEditDelete_Click(null, null);
            if (e.KeyData == (Keys.Control | Keys.X))
                buttonEditCut_Click(null, null);
            if (e.KeyData == (Keys.Control | Keys.D))
            {
                if (draggedTiles != null)
                    PasteFinal(draggedTiles);
                else
                {
                    overlay.SelectTS = null;
                    pictureBoxTileset.Invalidate();
                }
            }
            if (e.KeyData == (Keys.Control | Keys.A))
            {
                overlay.SelectTS = new Overlay.Selection(16, 0, 0, 1024, 1024);
                pictureBoxTileset.Invalidate();
            }
        }
        //
        private void openTileEditor_Click(object sender, EventArgs e)
        {
            tileEditor.Visible = true;
        }
        private void showGrid_Click(object sender, EventArgs e)
        {
            pictureBoxTileset.Invalidate();
        }
        private void showBG_Click(object sender, EventArgs e)
        {
            pictureBoxTileset.Invalidate();
        }
        private void buttonEditDelete_Click(object sender, EventArgs e)
        {
            Delete();
        }
        private void buttonEditCut_Click(object sender, EventArgs e)
        {
            Cut();
        }
        private void buttonEditCopy_Click(object sender, EventArgs e)
        {
            Copy();
        }
        private void buttonEditPaste_Click(object sender, EventArgs e)
        {
            if (draggedTiles != null)
                PasteFinal(draggedTiles);
            Paste(new Point(16, 16), copiedTiles);
        }
        // contextmenustrip
        private void mirrorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Flip("mirror");
        }
        private void invertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Flip("invert");
        }
        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (contextMenuStrip2.SourceControl == pictureBoxTitleL1 ||
                contextMenuStrip2.SourceControl == pictureBoxTitleL2)
                ImportTitle();
            else if (contextMenuStrip2.SourceControl == pictureBoxTitleLogo)
                ImportTitleLogo();
        }
        private void saveImageAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Do.Export(tilesetImage[layer], "titleTilesetL" + (layer + 1).ToString() + ".png");
        }
        //
        private void save_Click(object sender, EventArgs e)
        {
            Assemble();
        }
        // editors
        private void openPalettes_Click(object sender, EventArgs e)
        {
            paletteEditor.Show();
        }
        private void openGraphics_Click(object sender, EventArgs e)
        {
            graphicEditor.Show();
        }
        private void openSpritePalettes_Click(object sender, EventArgs e)
        {
            spritePaletteEditor.Show();
        }
        private void openSpriteGraphics_Click(object sender, EventArgs e)
        {
            spriteGraphicEditor.Show();
        }
        private void editor_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            ((Form)sender).Hide();
        }
        #endregion
    }
}
