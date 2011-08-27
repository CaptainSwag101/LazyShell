using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Forms;
using LAZYSHELL.Undo;

namespace LAZYSHELL
{
    public partial class SpriteMolds : Form
    {
        #region Variables
        
        private delegate void Function();
        // main editor accessed variables
        private Sprites spritesEditor;
        private Sprite sprite { get { return spritesEditor.Sprite; } set { spritesEditor.Sprite = value; } }
        private SpriteSequences sequences { get { return spritesEditor.Sequences; } set { spritesEditor.Sequences = value; } }
        private Animation animation { get { return spritesEditor.Animation; } set { spritesEditor.Animation = value; } }
        private GraphicPalette image { get { return spritesEditor.Image; } set { spritesEditor.Image = value; } }
        private int[] palette { get { return spritesEditor.Palette; } }
        private int availableBytes { get { return spritesEditor.AvailableBytes; } set { spritesEditor.AvailableBytes = value; } }
        private byte[] graphics { get { return spritesEditor.Graphics; } }
        private PaletteSet paletteSet { get { return spritesEditor.PaletteSet; } set { spritesEditor.PaletteSet = value; } }
        // local variables
        public bool ShowBG { get { return showBG.Checked; } }
        private List<Mold> molds { get { return animation.Molds; } }
        private Mold mold { get { return animation.Molds[listBoxMolds.SelectedIndex]; } }
        private int index { get { return listBoxMolds.SelectedIndex; } set { listBoxMolds.SelectedIndex = value; } }
        private int index_tile = 0;
        private int index_subtile = 0;
        private Mold.Tile tile { get { return mold.Tiles[index_tile]; } set { mold.Tiles[index_tile] = value; } }
        private List<Mold.Tile> tiles { get { return mold.Tiles; } }
        private Mold.Tile unique_tile { get { return animation.UniqueTiles[index_tile]; } set { animation.UniqueTiles[index_tile] = value; } }
        private Bitmap tilemapImage;
        private Bitmap tilesetImage;
        private bool updating = false;
        private Overlay overlay;
        private int zoom = 1;
        // mouse
        private bool move = false;
        private bool mouseWithinSameBounds = false;
        private int mouseOverTile = 0xFF;
        private int mouseDownTile = 0xFF;
        private string mouseOverObject;
        private string mouseDownObject;
        private Point mouseDownPosition = new Point(-1, -1);
        private Point mousePosition;
        //private bool mouseEnter = false;
        private ZoomPanel zoomPanel;
        private ZoomPanel zoomPanel_TS;
        // buffers
        private Stack<Mold> commandStack;
        private CopyBuffer selectedTiles;
        private CopyBuffer copiedTiles;
        // editors
        public TileEditor tileEditor;
        #endregion
        #region Functions
        public SpriteMolds(Sprites spritesEditor)
        {
            this.spritesEditor = spritesEditor;
            this.overlay = new Overlay();
            this.commandStack = new Stack<Mold>();
            InitializeComponent();
            this.zoomPanel = new ZoomPanel();
            this.zoomPanel.PictureBox = this.pictureBoxZoom;
            this.zoomPanel_TS = new ZoomPanel();
            this.zoomPanel_TS.Size = new Size(66, 66);
            this.zoomPanel_TS.PictureBox = this.pictureBoxZoom_TS;
            updating = true;
            this.listBoxMolds.Items.Clear();
            for (int i = 0; i < animation.Molds.Count; i++)
                this.listBoxMolds.Items.Add("Mold " + i.ToString());
            listBoxMolds.SelectedIndex = 0;
            updating = false;
            foreach (Mold mold in animation.Molds)
            {
                foreach (Mold.Tile tile in mold.Tiles)
                    tile.Set8x8Tiles(graphics, palette, tile.Gridplane);
            }
            RefreshMold();
        }
        public void Reload(Sprites spritesEditor)
        {
            this.commandStack = new Stack<Mold>();
            updating = true;
            this.listBoxMolds.Items.Clear();
            for (int i = 0; i < animation.Molds.Count; i++)
                this.listBoxMolds.Items.Add("Mold " + i.ToString());
            listBoxMolds.SelectedIndex = 0;
            updating = false;
            foreach (Mold mold in animation.Molds)
            {
                foreach (Mold.Tile tile in mold.Tiles)
                    tile.Set8x8Tiles(graphics, palette, tile.Gridplane);
            }
            RefreshMold();
        }
        public void SetToolTips(ToolTip toolTip1)
        {
            toolTip1.SetToolTip(this.listBoxMolds,
                "The collection of molds used by the sprite's animation. A \n" +
                "mold is a set of tiles arranged either dynamically or in a \n" +
                "predefined grid to create a complete image that can be \n" +
                "used by an animation sequence.");

            this.newMold.ToolTipText =
                "Insert a new mold after the currently selected mold.";

            this.deleteMold.ToolTipText =
                "Delete the currently selected mold.";

            toolTip1.SetToolTip(this.moldTileXCoord,
                "The absolute X coordinate of the 16x16 tile.\n" +
                "Only used by \"Tilemap\" format.");

            toolTip1.SetToolTip(this.moldTileYCoord,
                "The absolute Y coordinate of the 16x16 tile.\n" +
                "Only used by \"Tilemap\" format.");
        }
        // editors
        //public void LoadTileEditor()
        //{
        //    if (tileEditor == null)
        //    {
        //        tileEditor = new TileEditor(new Function(TileUpdate),
        //        tileset.Tileset[mouseDownTile], tileset.Graphics,
        //        spritesEditor.PaletteSet, 0x20);
        //        tileEditor.FormClosing += new FormClosingEventHandler(editor_FormClosing);
        //    }
        //    else
        //        tileEditor.Reload(new Function(TileUpdate),
        //        this.tileset.Tileset[mouseDownTile], tileset.Graphics,
        //        spritesEditor.PaletteSet, 0x20);
        //}
        //private void TileUpdate()
        //{
        //    SetTilesetImage();
        //    SetTilemapImage();
        //    sequences.SetSequenceFrameImages();
        //    sequences.RealignFrames();
        //}
        private void RefreshMold()
        {
            updating = true;
            index_tile = 0;
            index_subtile = 0;
            toolStrip4.Enabled = !this.mold.Gridplane;
            foreach (ToolStripItem item in contextMenuStrip1.Items)
                if (item != saveImageAsToolStripMenuItem)
                    item.Enabled = !this.mold.Gridplane;
            pictureBoxMold.Cursor = Cursors.Arrow;
            newTile.Enabled = !mold.Gridplane;
            deleteTile.Enabled = !mold.Gridplane;
            duplicateTile.Enabled = !mold.Gridplane;
            pictureBoxTileset.Cursor = this.mold.Gridplane ? Cursors.Arrow : Cursors.Cross;
            label13.Text = this.mold.Gridplane ? "Size" : "X,Y";
            if (mold.Gridplane)
            {
                moldTileXCoord.Enabled = mold.Tiles.Count != 0;
                moldTileYCoord.Enabled = mold.Tiles.Count != 0;
                moldTileProperties.Enabled = mold.Tiles.Count != 0;
            }
            else
            {
                moldTileXCoord.Enabled = mold.Tiles.Count != 0;
                moldTileYCoord.Enabled = mold.Tiles.Count != 0;
                moldTileProperties.Enabled = mold.Tiles.Count != 0;
            }
            moldTileXCoord.Maximum = this.mold.Gridplane ? 32 : 255;
            moldTileXCoord.Increment = this.mold.Gridplane ? 8 : 1;
            moldTileXCoord.Minimum = this.mold.Gridplane ? 24 : 0;
            moldTileYCoord.Maximum = this.mold.Gridplane ? 32 : 255;
            moldTileYCoord.Increment = this.mold.Gridplane ? 8 : 1;
            moldTileYCoord.Minimum = this.mold.Gridplane ? 24 : 0;
            moldTileProperties.BeginUpdate();
            moldTileProperties.Items.Clear();
            moldTileProperties.Items.AddRange(
                this.mold.Gridplane ?
                new string[] { "Mirror", "Invert", "Y++", "Y--" } :
                new string[] { "Mirror", "Invert" });
            moldTileProperties.EndUpdate();
            mouseDownTile = 0xFF;
            RefreshTile();
            updating = false;
        }
        private void RefreshTile()
        {
            updating = true;
            if (mold.Gridplane)
            {
                moldTileXCoord.Value = (mold.Tiles[0]).Width;
                moldTileYCoord.Value = (mold.Tiles[0]).Height;
                moldTileProperties.SetItemChecked(2, tile.YPlusOne == 1);
                moldTileProperties.SetItemChecked(3, tile.YMinusOne == 1);
                moldTileProperties.SetItemChecked(0, tile.Mirror);
                moldTileProperties.SetItemChecked(1, tile.Invert);
                subtile.Value = tile.SubTiles[index_subtile];
            }
            // if changing a mold's tile
            else if (mold.Tiles.Count != 0 && mouseDownTile != 0xFF)
            {
                panel3.Enabled = true;
                moldTileXCoord.Value = (mold.Tiles[mouseDownTile]).XCoord;
                moldTileYCoord.Value = (mold.Tiles[mouseDownTile]).YCoord;
                panel4.Enabled = false;
            }
            // if changing a tileset's tile and NOT a mold's tile
            else if (animation.UniqueTiles.Count != 0 && mouseDownTile == 0xFF)
            {
                panel3.Enabled = false;
                moldTileXCoord.Value = 0;
                moldTileYCoord.Value = 0;
                moldTileProperties.SetItemChecked(0, (animation.UniqueTiles[index_tile]).Mirror);
                moldTileProperties.SetItemChecked(1, (animation.UniqueTiles[index_tile]).Invert);
                subtile.Value = (animation.UniqueTiles[index_tile]).SubTiles[index_subtile];
                panel4.Enabled = true;
            }
            else
            {
                panel3.Enabled = false;
                moldTileXCoord.Value = 0;
                moldTileYCoord.Value = 0;
            }
            SetTilesetImage();
            SetTilemapImage();
            updating = false;
        }
        public void SetTilesetImage()
        {
            int[] pixels;
            if (mold.Gridplane)
            {
                pixels = (mold.Tiles[0]).GetGridplanePixels();
                tilesetImage = new Bitmap(Do.PixelsToImage(pixels, 32, 32));
                pictureBoxTileset.Size = new Size(128, 128);
            }
            else
            {
                pixels = animation.TilesetPixels();
                tilesetImage = new Bitmap(Do.PixelsToImage(pixels, 128, (((animation.UniqueTiles.Count - 1) / 8) + 1) * 16));
                pictureBoxTileset.Size = tilesetImage.Size;
            }
            pictureBoxTileset.Invalidate();
        }
        public void SetTilemapImage()
        {
            int[] pixels = mold.MoldPixels();
            tilemapImage = new Bitmap(Do.PixelsToImage(pixels, 256, 256));
            pictureBoxMold.Invalidate();
        }
        // drawing
        private void DrawHoverBox(Graphics g, int x, int y, int z, Mold.Tile tile)
        {
            Rectangle src = new Rectangle(0, 0, 16, 16);
            Rectangle dst = new Rectangle(x * z, y * z, 16 * z, 16 * z);
            g.DrawImage(Do.PixelsToImage(tile.Get16x16TilePixels(), 16, 16), dst, src, GraphicsUnit.Pixel);
            if (mouseDownPosition != new Point(-1, -1))
                return;
            Pen pen = new Pen(Color.Red); pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            g.FillRectangle(new SolidBrush(Color.FromArgb(64, Color.Black)), (x * z), (y * z), 16 * z, 16 * z);
            g.DrawRectangle(pen, (x * z), (y * z), 16 * z, 16 * z);
        }
        private void Drag()
        {
            ArrayList tiles = new ArrayList();
            for (int y = overlay.Select.Y; y < overlay.Select.Terminal.Y; y++)
            {
                for (int x = overlay.Select.X; x < overlay.Select.Terminal.X; x++)
                {
                    int index = mold.MoldTilesPerPixel[y * 256 + x];
                    if (index != 0xFF)
                    {
                        Mold.Tile tile = mold.Tiles[index];
                        if (tile.AddedToBuffer) continue;
                        tile.AddedToBuffer = true;
                        tiles.Add(tile);
                    }
                }
            }
            foreach (Mold.Tile tile in mold.Tiles)
                tile.AddedToBuffer = false;
            selectedTiles = new CopyBuffer(tiles);
        }
        private void Draw(int x, int y)
        {
            if (mold.Gridplane) return;
            // if over a tile, set new tile(s) to coords at the tile
            if (mouseOverTile != 0xFF)
            {
                x = (mold.Tiles[mouseOverTile]).XCoord;
                y = (mold.Tiles[mouseOverTile]).YCoord;
            }
            for (int y_ = 0; y_ < selectedTiles.Height / 16; y_++)
            {
                for (int x_ = 0; x_ < selectedTiles.Width / 16; x_++)
                {
                    int index = selectedTiles.Copy[y_ * (selectedTiles.Width / 16) + x_];
                    Mold.Tile tile = (animation.UniqueTiles[index]).Copy();
                    tile.XCoord = (byte)Math.Min(256, Math.Max(0, x + (x_ * 16)));
                    tile.YCoord = (byte)Math.Min(256, Math.Max(0, y + (y_ * 16)));
                    // if over a tile, replace it with new one
                    if (mouseOverTile != 0xFF)
                    {
                        // only replace if first one drawn
                        if (y_ == 0 && x_ == 0)
                            mold.Tiles[mouseOverTile] = tile;
                        // otherwise insert it
                        else
                            mold.Tiles.Insert(mouseOverTile + (y_ * (selectedTiles.Width / 16) + x_), tile);
                    }
                    else
                        mold.Tiles.Add(tile);
                    tile.Set8x8Tiles(graphics, palette, false);
                }
            }
            SetTilemapImage();
        }
        private void Delete()
        {
            if (mold.Gridplane) return;
            ArrayList removedTiles = new ArrayList();
            if (overlay.Select != null)
            {
                for (int y = overlay.Select.Y; y < overlay.Select.Terminal.Y; y++)
                {
                    for (int x = overlay.Select.X; x < overlay.Select.Terminal.X; x++)
                    {
                        if (mold.MoldTilesPerPixel[y * 256 + x] != 0xFF)
                        {
                            removedTiles.Add(mold.Tiles[mold.MoldTilesPerPixel[y * 256 + x]]);
                            mold.MoldTilesPerPixel[y * 256 + x] = 0xFF;
                        }
                    }
                }
                foreach (Mold.Tile removedTile in removedTiles)
                    mold.Tiles.Remove(removedTile);
            }
            else if (mouseOverTile != 0xFF)
                tiles.RemoveAt(mouseOverTile);
            SetTilemapImage();
        }
        private void Cut()
        {
            if (mold.Gridplane) return;
            Copy();
            Delete();
        }
        private void Copy()
        {
            if (mold.Gridplane) return;
            ArrayList mold_tiles = new ArrayList();
            if (overlay.Select != null)
            {
                for (int y = overlay.Select.Y; y < overlay.Select.Terminal.Y; y++)
                {
                    for (int x = overlay.Select.X; x < overlay.Select.Terminal.X; x++)
                    {
                        if (mold.MoldTilesPerPixel[y * 256 + x] != 0xFF &&
                            !(mold.Tiles[mold.MoldTilesPerPixel[y * 256 + x]]).AddedToBuffer)
                        {
                            mold_tiles.Add(mold.Tiles[mold.MoldTilesPerPixel[y * 256 + x]]);
                            (mold.Tiles[mold.MoldTilesPerPixel[y * 256 + x]]).AddedToBuffer = true;
                        }
                    }
                }
                copiedTiles = new CopyBuffer(mold_tiles, overlay.Select.Width, overlay.Select.Height);
            }
            else if (mouseOverTile != 0xFF)
            {
                mold_tiles.Add(mold.Tiles[mouseOverTile]);
                copiedTiles = new CopyBuffer(mold_tiles, 16, 16);
            }
            foreach (Mold.Tile tile in mold.Tiles)
                tile.AddedToBuffer = false;
        }
        private void Paste()
        {
            if (mold.Gridplane) return;
            foreach (Mold.Tile tile in copiedTiles.Mold_tiles)
            {
                Mold.Tile copy = tile.Copy();
                copy.XCoord -= 64;
                copy.YCoord -= 64;
                mold.Tiles.Add(copy);
                copy.Set8x8Tiles(graphics, palette, false);
            }
            overlay.Select = null;
            SetTilemapImage();
        }
        private void Flip(string type)
        {
            if (mold.Gridplane) return;
            // make a cropped selection
            Rectangle region = Do.Crop(mold.MoldPixels(), 256, 256);
            for (int y = region.Y; y < region.Bottom; y++)
            {
                for (int x = region.X; x < region.Right; x++)
                {
                    if (mold.MoldTilesPerPixel[y * 256 + x] == 0xFF)
                        continue;
                    Mold.Tile tile = mold.Tiles[mold.MoldTilesPerPixel[y * 256 + x]];
                    if (tile.AddedToBuffer)
                        continue;
                    if (type == "mirror")
                    {
                        tile.XCoord = (byte)((region.Width - (tile.XCoord - region.X)) + region.X - 16);
                        tile.Mirror = !tile.Mirror;
                    }
                    else if (type == "invert")
                    {
                        tile.YCoord = (byte)((region.Height - (tile.YCoord - region.Y)) + region.Y - 16);
                        tile.Invert = !tile.Invert;
                    }
                    tile.AddedToBuffer = true;
                }
            }
            foreach (Mold.Tile tile in mold.Tiles)
                tile.AddedToBuffer = false;
            SetTilemapImage();
        }
        #endregion
        #region Event Handlers
        // drawing
        private void pictureBoxMold_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            if (showBG.Checked)
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(palette[0])),
                    new Rectangle(new Point(0, 0), pictureBoxMold.Size));
            if (tilemapImage != null)
            {
                Rectangle src = new Rectangle(0, 0, tilemapImage.Width, tilemapImage.Height);
                Rectangle dst = new Rectangle(0, 0, tilemapImage.Width * zoom, tilemapImage.Height * zoom);
                e.Graphics.DrawImage(tilemapImage, dst, src, GraphicsUnit.Pixel);
            }
            if (!select.Checked && !mold.Gridplane && mouseOverTile != 0xFF)
            {
                Mold.Tile tile = mold.Tiles[mouseOverTile];
                DrawHoverBox(e.Graphics, tile.XCoord, tile.YCoord, zoom, tile);
            }
            if (showMoldPixelGrid.Checked && zoom > 2)
                overlay.DrawCartesianGrid(e.Graphics, Color.Gray, pictureBoxMold.Size, new Size(1, 1), zoom);
            if (select.Checked)
            {
                if (overlay.Select != null)
                {
                    overlay.DrawSelectionBox(e.Graphics, overlay.Select.Terminal, overlay.Select.Location, zoom);
                    for (int y = overlay.Select.Y; y < overlay.Select.Terminal.Y; y++)
                    {
                        for (int x = overlay.Select.X; x < overlay.Select.Terminal.X; x++)
                        {
                            if (y < 0 || x < 0) continue;
                            if (y >= 256 || x >= 256) continue;
                            if (mold.MoldTilesPerPixel[y * 256 + x] != 0xFF)
                            {
                                Mold.Tile tile = mold.Tiles[mold.MoldTilesPerPixel[y * 256 + x]];
                                DrawHoverBox(e.Graphics, tile.XCoord, tile.YCoord, zoom, tile);
                            }
                        }
                    }
                }
            }
        }
        private void pictureBoxMold_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDownTile = 0xFF;
            mouseDownPosition = new Point(-1, -1);
            // set a floor and ceiling for the coordinates
            int x = Math.Max(0, Math.Min(e.X / zoom, pictureBoxMold.Width));
            int y = Math.Max(0, Math.Min(e.Y / zoom, pictureBoxMold.Height));
            mouseDownObject = null;
            #region Zooming
            Point p = new Point();
            p.X = Math.Abs(panelMoldImage.AutoScrollPosition.X);
            p.Y = Math.Abs(panelMoldImage.AutoScrollPosition.Y);
            if ((moldZoomIn.Checked && e.Button == MouseButtons.Left) ||
                (moldZoomOut.Checked && e.Button == MouseButtons.Right))
            {
                if (zoom < 8)
                {
                    zoom *= 2;
                    p = new Point(Math.Abs(pictureBoxMold.Left), Math.Abs(pictureBoxMold.Top));
                    p.X += e.X;
                    p.Y += e.Y;
                    pictureBoxMold.Width = 256 * zoom;
                    pictureBoxMold.Height = 256 * zoom;
                    panelMoldImage.Focus();
                    panelMoldImage.AutoScrollPosition = p;
                    panelMoldImage.VerticalScroll.SmallChange *= 2;
                    panelMoldImage.HorizontalScroll.SmallChange *= 2;
                    panelMoldImage.VerticalScroll.LargeChange *= 2;
                    panelMoldImage.HorizontalScroll.LargeChange *= 2;
                    pictureBoxMold.Invalidate();
                    return;
                }
                return;
            }
            else if ((moldZoomOut.Checked && e.Button == MouseButtons.Left) ||
                (moldZoomIn.Checked && e.Button == MouseButtons.Right))
            {
                if (zoom > 1)
                {
                    zoom /= 2;

                    p = new Point(Math.Abs(pictureBoxMold.Left), Math.Abs(pictureBoxMold.Top));
                    p.X -= e.X / 2;
                    p.Y -= e.Y / 2;

                    pictureBoxMold.Width = 256 * zoom;
                    pictureBoxMold.Height = 256 * zoom;
                    panelMoldImage.Focus();
                    panelMoldImage.AutoScrollPosition = p;
                    panelMoldImage.VerticalScroll.SmallChange /= 2;
                    panelMoldImage.HorizontalScroll.SmallChange /= 2;
                    panelMoldImage.VerticalScroll.LargeChange /= 2;
                    panelMoldImage.HorizontalScroll.LargeChange /= 2;
                    pictureBoxMold.Invalidate();
                    return;
                }
                return;
            }
            #endregion
            if (mold.Gridplane) return;
            if (e.Button == MouseButtons.Right) return;
            #region Selecting
            if (select.Checked)
            {
                // if we're not inside a current selection to move it, create a new selection
                if (mouseOverObject != "selection")
                    overlay.Select = new Overlay.Selection(1, x, y, 1, 1);
                // otherwise, start dragging current selection
                else if (mouseOverObject == "selection")
                {
                    mouseDownObject = "selection";
                    mouseDownPosition = overlay.Select.MousePosition(x, y);
                    if (!move)    // only do this if the current selection has not been initially moved
                    {
                        move = true;
                        Drag();
                    }
                    foreach (Mold.Tile tile in selectedTiles.Mold_tiles)
                        tile.MouseDownPosition = new Point(
                            tile.XCoord - mousePosition.X,
                            tile.YCoord - mousePosition.Y);
                }
                return;
            }
            #endregion
            #region Drawing, Erasing, Moving Single Tile
            if (draw.Checked)
            {
                Draw(x, y);
                return;
            }
            if (erase.Checked && mouseOverTile != 0xFF)
            {
                mold.Tiles.RemoveAt(mouseOverTile);
                mouseOverTile = 0xFF;
                SetTilemapImage();
                return;
            }
            if (mouseOverTile != 0xFF)
            {
                mouseDownTile = mouseOverTile;
                Mold.Tile tile = mold.Tiles[mouseDownTile];
                mouseDownPosition = new Point(
                    mousePosition.X - tile.XCoord,
                    mousePosition.Y - tile.YCoord);

                index_tile = animation.UniqueTiles.IndexOf(tile);
                index_subtile = 0;
                // if making a new selection
                if (e.Button == MouseButtons.Left && mouseOverObject == null)
                    overlay.SelectTS = new Overlay.Selection(16, (index_tile % 8) * 16, (index_tile / 8) * 16, 16, 16);
                pictureBoxTileset.Invalidate();
                RefreshTile();
            }
            RefreshTile();
            #endregion
        }
        private void pictureBoxMold_MouseMove(object sender, MouseEventArgs e)
        {
            // set a floor and ceiling for the coordinates
            int x = Math.Max(0, Math.Min(e.X / zoom, pictureBoxMold.Width - 1));
            int y = Math.Max(0, Math.Min(e.Y / zoom, pictureBoxMold.Height - 1));
            mouseWithinSameBounds = mousePosition == new Point(x, y);
            mousePosition = new Point(x, y);
            mouseOverTile = 0xFF;
            mouseOverObject = null;
            #region Zooming
            // if either zoom button is checked, don't do anything else
            if (moldZoomIn.Checked || moldZoomOut.Checked)
            {
                pictureBoxMold.Invalidate();
                return;
            }
            #endregion
            // set zoom panel only if zoom not too high
            if (zoom < 4 && toggleZoomBox.Checked)
            {
                zoomPanel.Location = new Point(MousePosition.X + 64, MousePosition.Y);
                zoomPanel.Show();
                pictureBoxZoom.Invalidate();
                this.Focus();
            }
            else
                zoomPanel.Hide();
            if (mold.Gridplane) return;
            if (e.Button == MouseButtons.Right) return;
            #region Selecting
            if (select.Checked)
            {
                // if making a new selection
                if (e.Button == MouseButtons.Left && mouseDownObject == null && overlay.Select != null)
                {
                    // cancel if within same bounds as last call
                    if (overlay.Select.Final == new Point(x, y))
                        return;
                    // otherwise, set the lower right edge of the selection
                    overlay.Select.Final = new Point(
                        Math.Min(x, pictureBoxMold.Width),
                        Math.Min(y, pictureBoxMold.Height));
                }
                // if dragging the current selection
                else if (e.Button == MouseButtons.Left && mouseDownObject == "selection" && !mouseWithinSameBounds)
                {
                    overlay.Select.Location = new Point(
                        x - mouseDownPosition.X,
                        y - mouseDownPosition.Y);
                    foreach (Mold.Tile tile in selectedTiles.Mold_tiles)
                    {
                        tile.XCoord = (byte)(x + tile.MouseDownPosition.X);
                        tile.YCoord = (byte)(y + tile.MouseDownPosition.Y);
                    }
                    SetTilemapImage();
                    return;
                }
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
            #endregion
            #region Moving Single Tile
            if (mouseDownPosition != new Point(-1, -1) && !mouseWithinSameBounds)
            {
                Mold.Tile tile = mold.Tiles[mouseDownTile];
                updating = true;
                moldTileXCoord.Value = (byte)(x - mouseDownPosition.X);
                moldTileYCoord.Value = (byte)(y - mouseDownPosition.Y);
                updating = false;
                tile.XCoord = (byte)(x - mouseDownPosition.X);
                tile.YCoord = (byte)(y - mouseDownPosition.Y);
                SetTilemapImage();
            }
            else if (!select.Checked)
            {
                // set mouseOverTile
                if (mold.MoldTilesPerPixel == null) return;
                mouseOverTile = mold.MoldTilesPerPixel[y * 256 + x];
                if (!erase.Checked && !draw.Checked)
                    if (mouseOverTile != 0xFF)
                        pictureBoxMold.Cursor = Cursors.Hand;
                    else
                        pictureBoxMold.Cursor = Cursors.Arrow;
            }
            #endregion
            pictureBoxMold.Invalidate();
        }
        private void pictureBoxMold_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDownPosition = new Point(-1, -1);
            Point p = new Point(Math.Abs(pictureBoxMold.Left), Math.Abs(pictureBoxMold.Top));
            pictureBoxMold.Focus();
            panelMoldImage.AutoScrollPosition = p;
            animation.Assemble();
            spritesEditor.CalculateFreeSpace();
        }
        private void pictureBoxMold_MouseLeave(object sender, EventArgs e)
        {
            zoomPanel.Hide();
        }
        private void pictureBoxMold_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Control | Keys.V:
                    paste_Click(null, null);
                    break;
                case Keys.Control | Keys.C:
                    copy_Click(null, null);
                    break;
                case Keys.Delete:
                    delete_Click(null, null);
                    break;
                case Keys.Control | Keys.X:
                    cut_Click(null, null);
                    break;
                case Keys.Control | Keys.D:
                    overlay.Select = null;
                    mouseOverObject = null;
                    mouseDownObject = null;
                    pictureBoxMold_MouseMove(null, new MouseEventArgs(MouseButtons.None, 0, 0, 0, 0));
                    pictureBoxMold.Invalidate();
                    break;
                case Keys.Control | Keys.A:
                    selectAll_Click(null, null);
                    break;
                case Keys.Control | Keys.Z:
                    //undoButton_Click(null, null); 
                    break;
                case Keys.Control | Keys.Y:
                    //redoButton_Click(null, null); 
                    break;
            }
        }
        private void pictureBoxZoom_Paint(object sender, PaintEventArgs e)
        {
            if (tilemapImage != null)
            {
                int z = 4;
                RectangleF source, dest, clone;
                source = new RectangleF(0, 0, pictureBoxZoom.Width / 4, pictureBoxZoom.Height / 4);
                dest = new RectangleF(0, 0, pictureBoxZoom.Width / 4 * z, pictureBoxZoom.Height / 4 * z);
                clone = new RectangleF(
                    Math.Min(208, Math.Max(0, mousePosition.X - (pictureBoxZoom.Width / 8))),
                    Math.Min(208, Math.Max(0, mousePosition.Y - (pictureBoxZoom.Height / 8))),
                    pictureBoxZoom.Width / 4, pictureBoxZoom.Height / 4);
                e.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;
                e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                e.Graphics.DrawImage(
                    new Bitmap(tilemapImage.Clone(clone, PixelFormat.DontCare)),
                    dest, source, GraphicsUnit.Pixel);
                if (showMoldPixelGrid.Checked)
                {
                    Pen p = new Pen(new SolidBrush(Color.Gray));
                    Point h = new Point(0, (int)(z * 1 - (z * clone.Y)));
                    Point v = new Point((int)(z * 1 - (z * clone.X)), 0);
                    for (; h.Y < 256; h.Y += z * 1)
                        e.Graphics.DrawLine(p, h, new Point(h.X + pictureBoxZoom.Width, h.Y));
                    for (; v.X < 256; v.X += z * 1)
                        e.Graphics.DrawLine(p, v, new Point(v.X, v.Y + pictureBoxZoom.Height));
                }
                if (!mold.Gridplane && mouseOverTile != 0xFF)
                {
                    Mold.Tile tile = mold.Tiles[mouseOverTile];
                    DrawHoverBox(e.Graphics, (int)(tile.XCoord - clone.X), (int)(tile.YCoord - clone.Y), z, tile);
                }
                Rectangle cursorBounds;
                int size =
                    Cursor.Current == Cursors.Arrow ||
                    Cursor.Current == Cursors.Cross ||
                    Cursor.Current == Cursors.Hand ? 32 : 16;
                // if on the very edge of the image
                Point cursorOffset = new Point();
                if (mousePosition.X - (pictureBoxZoom.Width / 8) < 0)
                    cursorOffset.X = mousePosition.X - (pictureBoxZoom.Width / 8);
                else if (mousePosition.X - (pictureBoxZoom.Width / 8) - 208 > 0)
                    cursorOffset.X = mousePosition.X - (pictureBoxZoom.Width / 8) - 208;
                if (mousePosition.Y - (pictureBoxZoom.Height / 8) < 0)
                    cursorOffset.Y = mousePosition.Y - (pictureBoxZoom.Height / 8);
                else if (mousePosition.Y - (pictureBoxZoom.Height / 8) - 208 > 0)
                    cursorOffset.Y = mousePosition.Y - (pictureBoxZoom.Height / 8) - 208;
                cursorBounds = new Rectangle(
                        ((24 - Cursor.Current.HotSpot.X) * z) + (cursorOffset.X * z),
                        ((24 - Cursor.Current.HotSpot.Y) * z) + (cursorOffset.Y * z),
                        size * z, size * z);
                if (Cursor.Current != null)
                    Cursor.Current.DrawStretched(e.Graphics, cursorBounds);
            }
        }
        private void pictureBoxZoom_TS_Paint(object sender, PaintEventArgs e)
        {
            if (mousePosition.X >= tilesetImage.Width ||
                mousePosition.Y >= tilesetImage.Height)
                return;
            if (tilesetImage != null && !mold.Gridplane && animation.UniqueTiles.Count > 0)
            {
                int z = 4;
                RectangleF source, dest, clone;
                source = new RectangleF(0, 0, pictureBoxZoom_TS.Width / 4, pictureBoxZoom_TS.Height / 4);
                dest = new RectangleF(0, 0, pictureBoxZoom_TS.Width / 4 * z, pictureBoxZoom_TS.Height / 4 * z);

                clone = new RectangleF(mousePosition.X / 16 * 16, mousePosition.Y / 16 * 16,
                    pictureBoxZoom_TS.Width / 4, pictureBoxZoom_TS.Height / 4);
                e.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;
                e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                e.Graphics.DrawImage(
                    new Bitmap(tilesetImage.Clone(clone, PixelFormat.DontCare)),
                    dest, source, GraphicsUnit.Pixel);

                Rectangle cursorBounds;
                int size =
                    Cursor.Current == Cursors.Arrow ||
                    Cursor.Current == Cursors.Cross ||
                    Cursor.Current == Cursors.Hand ? 32 : 16;
                cursorBounds = new Rectangle(
                        (0 - (Cursor.Current.HotSpot.X * z) + (mousePosition.X % 16 * z)),
                        (0 - (Cursor.Current.HotSpot.Y * z) + (mousePosition.Y % 16 * z)),
                        size * z, size * z);
                if (Cursor.Current != null)
                    Cursor.Current.DrawStretched(e.Graphics, cursorBounds);
                overlay.DrawCartesianGrid(e.Graphics, Color.Gray, pictureBoxZoom_TS.Size, new Size(32, 32), 1);
            }
        }
        private void pictureBoxTileset_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            Rectangle dst = new Rectangle(0, 0, pictureBoxTileset.Width, pictureBoxTileset.Height);
            Rectangle src;
            if (mold.Gridplane)
                src = new Rectangle(0, 0, 32, 32);
            else
                src = dst;
            if (showBG.Checked)
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(palette[0])),
                    new Rectangle(new Point(0, 0), pictureBoxTileset.Size));
            if (tilesetImage != null)
                e.Graphics.DrawImage(tilesetImage, dst, src, GraphicsUnit.Pixel);
            if (showGrid.Checked)
                overlay.DrawCartesianGrid(e.Graphics, Color.Gray, pictureBoxTileset.Size,
                    mold.Gridplane ? new Size(32, 32) : new Size(16, 16), 1);
            if (!mold.Gridplane && overlay.SelectTS != null)
                overlay.DrawSelectionBox(e.Graphics, overlay.SelectTS.Terminal, overlay.SelectTS.Location, 1);
        }
        private void pictureBoxTileset_MouseDown(object sender, MouseEventArgs e)
        {
            updating = true;
            // set a floor and ceiling for the coordinates
            int x = Math.Max(0, Math.Min(e.X, pictureBoxTileset.Width));
            int y = Math.Max(0, Math.Min(e.Y, pictureBoxTileset.Height));
            mouseDownTile = 0xFF;
            if (mold.Gridplane)
            {
                index_tile = 0;
                // if beyond bounds of mold size
                if (x / 4 >= (mold.Tiles[0]).Width)
                {
                    index_subtile = 0;
                    subtile.Value = 0;
                    subtile.Enabled = false;
                }
                else
                {
                    index_subtile = (y / 32) * (tile.Width / 8) + (x / 32);
                    subtile.Value = tile.SubTiles[index_subtile];
                    subtile.Enabled = true;
                }
            }
            else
            {
                if ((y / 16) * 8 + (x / 16) < animation.UniqueTiles.Count)
                {
                    index_tile = (y / 16) * 8 + (x / 16);
                    index_subtile = (y % 16 / 8) * 2 + (x % 16 / 8);
                    subtile.Value = unique_tile.SubTiles[index_subtile];
                    updating = false;
                    // if making a new selection
                    if (e.Button == MouseButtons.Left && mouseOverObject == null)
                        overlay.SelectTS = new Overlay.Selection(16, x / 16 * 16, y / 16 * 16, 16, 16);
                    pictureBoxTileset.Invalidate();
                    RefreshTile();
                }
            }
            updating = false;
        }
        private void pictureBoxTileset_MouseMove(object sender, MouseEventArgs e)
        {
            if (mold.Gridplane) return;
            // set a floor and ceiling for the coordinates
            int x = Math.Max(0, Math.Min(e.X, pictureBoxTileset.Width));
            int y = Math.Max(0, Math.Min(e.Y, pictureBoxTileset.Height));
            mousePosition = new Point(x, y);
            // if making a new selection
            if (e.Button == MouseButtons.Left && mouseDownObject == null && overlay.SelectTS != null)
            {
                overlay.SelectTS.Final = new Point(
                        Math.Min(x + 16, pictureBoxTileset.Width),
                        Math.Min(y + 16, pictureBoxTileset.Height));
            }
            if (toggleZoomBox_TS.Checked)
            {
                zoomPanel_TS.Location = new Point(MousePosition.X - 96, MousePosition.Y + 16);
                zoomPanel_TS.Show();
                pictureBoxZoom_TS.Invalidate();
                this.Focus();
            }
            else
                zoomPanel_TS.Hide();
            pictureBoxTileset.Invalidate();
        }
        private void pictureBoxTileset_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) return;
            if (mold.Gridplane) return;
            if (overlay.SelectTS == null) return;
            int x_ = overlay.SelectTS.Location.X / 16;
            int y_ = overlay.SelectTS.Location.Y / 16;
            if (this.selectedTiles == null)
                this.selectedTiles = new CopyBuffer(overlay.SelectTS.Width, overlay.SelectTS.Height);
            int[] selectedTiles = new int[(overlay.SelectTS.Width / 16) * (overlay.SelectTS.Height / 16)];
            for (int y = 0; y < overlay.SelectTS.Height / 16; y++)
            {
                for (int x = 0; x < overlay.SelectTS.Width / 16; x++)
                    selectedTiles[y * (overlay.SelectTS.Width / 16) + x] = (y + y_) * 8 + x + x_;
            }
            this.selectedTiles.Copy = selectedTiles;
            pictureBoxTileset.Focus();
        }
        private void pictureBoxTileset_MouseLeave(object sender, EventArgs e)
        {
            zoomPanel_TS.Hide();
        }
        private void showMoldPixelGrid_Click(object sender, EventArgs e)
        {
            pictureBoxMold.Invalidate();
        }
        // drawing
        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (mouseOverTile != 0xFF)
                e.Cancel = true;
            if (moldZoomIn.Checked || moldZoomOut.Checked)
                e.Cancel = true;
        }
        private void select_Click(object sender, EventArgs e)
        {
            overlay.Select = null;
            erase.Checked = false;
            draw.Checked = false;
            moldZoomIn.Checked = false;
            moldZoomOut.Checked = false;
            pictureBoxMold.Cursor = select.Checked ? Cursors.Cross : Cursors.Arrow;
            pictureBoxMold.Invalidate();
        }
        private void erase_Click(object sender, EventArgs e)
        {
            overlay.Select = null;
            select.Checked = false;
            draw.Checked = false;
            moldZoomIn.Checked = false;
            moldZoomOut.Checked = false;
            pictureBoxMold.Cursor = erase.Checked ? new Cursor(GetType(), "CursorErase.cur") : Cursors.Arrow;
            pictureBoxMold.Invalidate();
        }
        private void draw_Click(object sender, EventArgs e)
        {
            overlay.Select = null;
            erase.Checked = false;
            select.Checked = false;
            moldZoomIn.Checked = false;
            moldZoomOut.Checked = false;
            pictureBoxMold.Cursor = draw.Checked ? new Cursor(GetType(), "CursorDraw.cur") : Cursors.Arrow;
            pictureBoxMold.Invalidate();
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
            Delete();
        }
        private void selectAll_Click(object sender, EventArgs e)
        {
            select.Checked = true;
            overlay.Select = new Overlay.Selection(1, 0, 0, 256, 256);
            pictureBoxMold.Invalidate();
        }
        private void mirror_Click(object sender, EventArgs e)
        {
            Flip("mirror");
        }
        private void invert_Click(object sender, EventArgs e)
        {
            Flip("invert");
        }
        private void saveImageAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
                "Would you like to crop the saved image to the bounds of the pixel edges?", "LAZY SHELL",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int[] cropped;
                Rectangle region = Do.Crop(mold.MoldPixels(), out cropped, 256, 256);
                Do.Export(
                    Do.PixelsToImage(cropped, region.Width, region.Height),
                    "animation." + animation.Index.ToString("d3") + ".Mold." + index.ToString("d2") + ".png");
            }
            else
                Do.Export(tilemapImage, "animation." + animation.Index.ToString("d3") + ".Mold." + index.ToString("d2") + ".png");
        }
        private void moldZoomIn_Click(object sender, EventArgs e)
        {
            overlay.Select = null;
            erase.Checked = false;
            draw.Checked = false;
            select.Checked = false;
            moldZoomOut.Checked = false;
            pictureBoxMold.Cursor = moldZoomIn.Checked ? new Cursor(GetType(), "CursorZoomIn.cur") : Cursors.Arrow;
        }
        private void moldZoomOut_Click(object sender, EventArgs e)
        {
            overlay.Select = null;
            erase.Checked = false;
            draw.Checked = false;
            moldZoomIn.Checked = false;
            select.Checked = false;
            pictureBoxMold.Cursor = moldZoomOut.Checked ? new Cursor(GetType(), "CursorZoomOut.cur") : Cursors.Arrow;
        }
        private void toggleZoomBox_Click(object sender, EventArgs e)
        {
            if (!toggleZoomBox.Checked)
                zoomPanel.Hide();
        }
        private void toggleZoomBox_TS_Click(object sender, EventArgs e)
        {
            if (!toggleZoomBox_TS.Checked)
                zoomPanel_TS.Hide();
        }
        private void showGrid_Click(object sender, EventArgs e)
        {
            pictureBoxTileset.Invalidate();
        }
        private void showBG_Click(object sender, EventArgs e)
        {
            pictureBoxMold.Invalidate();
            pictureBoxTileset.Invalidate();
            sequences.InvalidateImages();
        }
        private void duplicateTile_Click(object sender, EventArgs e)
        {
            animation.UniqueTiles.Add(this.unique_tile.Copy());
            foreach (Mold.Tile tile in animation.UniqueTiles)
                tile.Set8x8Tiles(graphics, paletteSet.Palette, tile.Gridplane);

            SetTilesetImage();
            SetTilemapImage();
            sequences.SetSequenceFrameImages();
            // update free space
            animation.Assemble();
            spritesEditor.CalculateFreeSpace();
        }
        private void deleteTile_Click(object sender, EventArgs e)
        {
            foreach (Mold mold in molds)
                if (mold.Tiles.Contains(unique_tile))
                    mold.Tiles.Remove(unique_tile);
            animation.UniqueTiles.Remove(unique_tile);

            foreach (Mold mold in animation.Molds)
            {
                foreach (Mold.Tile tile in mold.Tiles)
                    tile.Set8x8Tiles(graphics, paletteSet.Palette, tile.Gridplane);
            }

            SetTilesetImage();
            SetTilemapImage();
            sequences.SetSequenceFrameImages();
            // update free space
            animation.Assemble();
            spritesEditor.CalculateFreeSpace();
        }
        private void newTile_Click(object sender, EventArgs e)
        {
            animation.UniqueTiles.Add(this.unique_tile.New(false));
            foreach (Mold.Tile tile in animation.UniqueTiles)
                tile.Set8x8Tiles(graphics, paletteSet.Palette, tile.Gridplane);

            SetTilesetImage();
            SetTilemapImage();
            sequences.SetSequenceFrameImages();
            // update free space
            animation.Assemble();
            spritesEditor.CalculateFreeSpace();
        }
        private void contextMenuStrip2_Opening(object sender, CancelEventArgs e)
        {
            if (!mold.Gridplane)
                e.Cancel = true;
        }
        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap import = new Bitmap(1, 1); import = (Bitmap)Do.Import(import);
            if (import == null) return;
            int[] pixels = Do.ImageToPixels(import, new Size(32, 32), new Rectangle(0, 0, 32, 32));
            if (MessageBox.Show(
                "Would you like to create a new palette from the imported image?", "LAZY SHELL",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int[] palette = Do.ReduceColorDepth(pixels, 16, this.palette[0]);
                for (int i = 0; i < palette.Length; i++)
                {
                    paletteSet.Reds[i] = Color.FromArgb(palette[i]).R;
                    paletteSet.Greens[i] = Color.FromArgb(palette[i]).G;
                    paletteSet.Blues[i] = Color.FromArgb(palette[i]).B;
                }
            }
            byte[] graphics = new byte[0x200];
            Do.PixelsToBPP(pixels, graphics, new Size(4, 4), this.palette, (byte)0x20);
            for (int y = 0; y < tile.Height / 8; y++)
            {
                for (int x = 0; x < tile.Width / 8; x++)
                {
                    if (tile.SubTiles[y * (tile.Width / 8) + x] == 0)
                        continue;
                    int offset_src = (y * 4 + x) * 0x20;
                    Buffer.BlockCopy(graphics, offset_src, this.graphics,
                        (tile.SubTiles[y * (tile.Width / 8) + x] * 0x20) - 0x20, 0x20);
                }
            }
            spritesEditor.GraphicUpdate();
        }
        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Do.Export(tilesetImage, "animation." + animation.Index.ToString("d3") + ".Mold." + index.ToString("d2") + ".png");
        }
        // properties
        private void listBoxMolds_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updating) return;
            overlay.Select = null;
            RefreshMold();
        }
        private void moldTileXCoord_ValueChanged(object sender, EventArgs e)
        {
            if (updating) return;
            if (!mold.Gridplane)
                (mold.Tiles[mouseDownTile]).XCoord = (byte)moldTileXCoord.Value;
            else
                tile.Width = (int)moldTileXCoord.Value;
            if (mold.Gridplane)
                SetTilesetImage();
            SetTilemapImage();
            sequences.SetSequenceFrameImages();
            // update free space
            if (mold.Gridplane)
            {
                animation.Assemble();
                spritesEditor.CalculateFreeSpace();
            }
        }
        private void moldTileYCoord_ValueChanged(object sender, EventArgs e)
        {
            if (updating) return;
            if (!mold.Gridplane)
                (mold.Tiles[mouseDownTile]).YCoord = (byte)moldTileYCoord.Value;
            else
                tile.Height = (int)moldTileYCoord.Value;
            if (mold.Gridplane)
                SetTilesetImage();
            SetTilemapImage();
            sequences.SetSequenceFrameImages();
            // update free space
            if (mold.Gridplane)
            {
                animation.Assemble();
                spritesEditor.CalculateFreeSpace();
            }
        }
        private void moldTileProperties_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updating) return;
            if (mold.Gridplane)
            {
                tile.Mirror = moldTileProperties.GetItemChecked(0);
                tile.Invert = moldTileProperties.GetItemChecked(1);
                tile.YPlusOne = moldTileProperties.GetItemChecked(2) ? (byte)1 : (byte)0;
                tile.YMinusOne = moldTileProperties.GetItemChecked(3) ? (byte)1 : (byte)0;
            }
            // if changing a tileset's tile and NOT a mold's tile
            else if (mouseDownTile == 0xFF)
            {
                unique_tile.Mirror = moldTileProperties.GetItemChecked(0);
                unique_tile.Invert = moldTileProperties.GetItemChecked(1);
                unique_tile.Set8x8Tiles(graphics, palette, unique_tile.Gridplane);
            }
            SetTilesetImage();
            SetTilemapImage();
            sequences.SetSequenceFrameImages();
            // update free space
            animation.Assemble();
            spritesEditor.CalculateFreeSpace();
        }
        private void subtile_ValueChanged(object sender, EventArgs e)
        {
            if (updating) return;
            if (mold.Gridplane)
            {
                tile.SubTiles[index_subtile] = (ushort)subtile.Value;
                tile.SetTileSize();
                tile.Set8x8Tiles(graphics, palette, tile.Gridplane);
            }
            // if changing a tileset's tile and NOT a mold's tile
            else if (mouseDownTile == 0xFF)
            {
                unique_tile.SubTiles[index_subtile] = (ushort)subtile.Value;
                unique_tile.SetTileSize();
                unique_tile.Set8x8Tiles(graphics, palette, unique_tile.Gridplane);
            }
            SetTilesetImage();
            SetTilemapImage();
            sequences.SetSequenceFrameImages();
            // update free space
            animation.Assemble();
            spritesEditor.CalculateFreeSpace();
        }
        // adding,deleting
        private void newMold_Click(object sender, EventArgs e)
        {
            if (molds.Count == 32)
            {
                MessageBox.Show("Animations cannot contain more than 32 molds total.", "LAZY SHELL",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            int index = this.index;
            if (MessageBox.Show("Would you like the new mold to be in gridplane format?", "LAZY SHELL",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                molds.Insert(index + 1, this.mold.New(true));
            else
                molds.Insert(index + 1, this.mold.New(false));
            updating = true;
            listBoxMolds.BeginUpdate();
            listBoxMolds.Items.Clear();
            for (int i = 0; i < animation.Molds.Count; i++)
                this.listBoxMolds.Items.Add("Mold " + i.ToString());
            listBoxMolds.EndUpdate();
            updating = false;
            foreach (Mold mold in animation.Molds)
            {
                foreach (Mold.Tile tile in mold.Tiles)
                    tile.Set8x8Tiles(graphics, palette, tile.Gridplane);
            }
            this.index = index + 1;
            sequences.SetSequenceFrameImages();
            // update free space
            animation.Assemble();
            spritesEditor.CalculateFreeSpace();
        }
        private void deleteMold_Click(object sender, EventArgs e)
        {
            if (molds.Count == 1)
            {
                MessageBox.Show("Animations must contain at least 1 mold.", "LAZY SHELL",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            int index = this.index;
            molds.RemoveAt(index);
            updating = true;
            listBoxMolds.Items.RemoveAt(index);
            for (int i = 0; i < listBoxMolds.Items.Count; i++)
                listBoxMolds.Items[i] = "Mold " + i;
            updating = false;
            if (index >= molds.Count && molds.Count != 0)
                this.index = index - 1;
            else if (molds.Count != 0)
                this.index = index;
            RefreshMold();
            sequences.SetSequenceFrameImages();
            // update free space
            animation.Assemble();
            spritesEditor.CalculateFreeSpace();
        }
        private void duplicateMold_Click(object sender, EventArgs e)
        {
            if (molds.Count == 32)
            {
                MessageBox.Show("Animations cannot contain more than 32 molds total.", "LAZY SHELL",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            int index = this.index;
            molds.Insert(index + 1, this.mold.Copy());
            updating = true;
            listBoxMolds.BeginUpdate();
            listBoxMolds.Items.Clear();
            for (int i = 0; i < animation.Molds.Count; i++)
                this.listBoxMolds.Items.Add("Mold " + i.ToString());
            listBoxMolds.EndUpdate();
            updating = false;
            foreach (Mold mold in animation.Molds)
            {
                foreach (Mold.Tile tile in mold.Tiles)
                    tile.Set8x8Tiles(graphics, palette, tile.Gridplane);
            }
            this.index = index + 1;
            sequences.SetSequenceFrameImages();
            // update free space
            animation.Assemble();
            spritesEditor.CalculateFreeSpace();
        }
        // editors
        private void openTileEditor_Click(object sender, EventArgs e)
        {

        }
        private void editor_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            ((Form)sender).Hide();
        }
        #endregion
    }
}
