﻿using System;
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
    public partial class LevelsTileset : Form
    {
        #region Variables
        // main
        private delegate void Function();
        private Delegate update;
        public int Layer { get { return tabControl1.SelectedIndex; } set { tabControl1.SelectedIndex = value; } }
        private PictureBox pictureBox
        {
            get
            {
                if (tabControl1.SelectedIndex == 0)
                    return pictureBoxTilesetL1;
                else if (tabControl1.SelectedIndex == 1)
                    return pictureBoxTilesetL2;
                else
                    return pictureBoxTilesetL3;
            }
            set
            {
                if (tabControl1.SelectedIndex == 0)
                    pictureBoxTilesetL1 = value;
                else if (tabControl1.SelectedIndex == 1)
                    pictureBoxTilesetL2 = value;
                else
                    pictureBoxTilesetL3 = value;
            }
        }
        public PictureBox PictureBox { get { return pictureBox; } set { pictureBox = value; } }
        private State state = State.Instance;
        private TileSet tileSet;
        private PaletteSet paletteSet;
        private Bitmap tileSetImage, priority1;
        private Overlay overlay;
        public TileEditor tileEditor;
        // mouse
        private int zoom = 1;
        private bool mouseEnter = false;
        private int mouseDownTile = 0;
        public int MouseDownTile
        {
            get { return mouseDownTile; }
            set
            {
                mouseDownTile = value;
                pictureBoxTileset_MouseDown(null,
                    new MouseEventArgs(MouseButtons.Left, 1, value % 16 * 16, value / 16 * 16, 0));
                pictureBox.Invalidate();
            }
        }
        private string mouseOverObject;
        private string mouseDownObject;
        private Point mouseDownPosition;
        private Point mousePosition;
        private bool moving = false;
        // buffers and stacks
        private Bitmap selection;
        private CopyBuffer copiedTiles;
        private CopyBuffer selectedTiles; public CopyBuffer SelectedTiles { get { return selectedTiles; } }
        private CopyBuffer draggedTiles; public CopyBuffer DraggedTiles { get { return draggedTiles; } }
        private CommandStack commandStack = new CommandStack();
        #endregion
        #region Functions
        // main
        public LevelsTileset(TileSet tileSet, Delegate update, PaletteSet paletteSet, Overlay overlay)
        {
            this.tileSet = tileSet;
            this.paletteSet = paletteSet;
            this.overlay = overlay;
            this.update = update;

            InitializeComponent();
            LoadTileEditor();

            SetTileSetImage();
        }
        public void Reload(TileSet tileSet, Delegate update, PaletteSet paletteSet, Overlay overlay)
        {
            this.tileSet = tileSet;
            this.paletteSet = paletteSet;
            this.overlay = overlay;
            this.update = update;
            LoadTileEditor();

            SetTileSetImage();
        }
        private void SetTileSetImage()
        {
            if (tileSet.TileSetLayers[Layer] != null)
            {
                int[] tileSetPixels = Do.TilesetToPixels(tileSet.TileSetLayers[Layer], 16, 32, 0, false);
                int[] priority1Pixels = Do.TilesetToPixels(tileSet.TileSetLayers[Layer], 16, 32, 0, true);
                tileSetImage = new Bitmap(Do.PixelsToImage(tileSetPixels, 256, 512));
                priority1 = new Bitmap(Do.PixelsToImage(priority1Pixels, 256, 512));
                pictureBox.Invalidate();
            }
        }
        // tile editor
        private void TileUpdate()
        {
            this.tileSet.AssembleIntoModel(16, Layer);
            SetTileSetImage();
            if (autoUpdate.Checked)
                update.DynamicInvoke();
        }
        private void LoadTileEditor()
        {
            switch (Layer)
            {
                case 2: // layer 3
                    if (tileEditor == null)
                    {
                        tileEditor = new TileEditor(new Function(TileUpdate),
                            this.tileSet.TileSetLayers[Layer][mouseDownTile],
                            tileSet.GraphicsL3, paletteSet, 0x10);
                        tileEditor.FormClosing += new FormClosingEventHandler(editor_FormClosing);
                    }
                    else
                        tileEditor.Reload(new Function(TileUpdate),
                            this.tileSet.TileSetLayers[Layer][mouseDownTile],
                            tileSet.GraphicsL3, paletteSet, 0x10);
                    break;
                default:
                    if (tileEditor == null)
                    {
                        tileEditor = new TileEditor(new Function(TileUpdate),
                        this.tileSet.TileSetLayers[Layer][mouseDownTile],
                        tileSet.Graphics, paletteSet, 0x20);
                        tileEditor.FormClosing += new FormClosingEventHandler(editor_FormClosing);
                    }
                    else
                        tileEditor.Reload(new Function(TileUpdate),
                        this.tileSet.TileSetLayers[Layer][mouseDownTile],
                        tileSet.Graphics, paletteSet, 0x20);
                    break;
            }
        }
        // editing
        private void DrawHoverBox(Graphics g)
        {
            Rectangle r = new Rectangle(mousePosition.X / 16 * 16 * zoom, mousePosition.Y / 16 * 16 * zoom, 16 * zoom, 16 * zoom);
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
                        tileSet.TileSetLayers[Layer][(y + y_) * 16 + x + x_].Copy();
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
                        tileSet.TileSetLayers[Layer][(y + y_) * 16 + x + x_].Copy();
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
            this.pictureBox.Invalidate();
        }
        /// <summary>
        /// "Cements" either a dragged selection or a newly pasted selection.
        /// </summary>
        /// <param name="buffer">The dragged selection or the newly pasted selection.</param>
        public void PasteFinal(CopyBuffer buffer)
        {
            if (buffer == null) return;
            if (overlay.SelectTS == null) return;
            selection = null;
            int x_ = overlay.SelectTS.X / 16;
            int y_ = overlay.SelectTS.Y / 16;
            for (int y = 0; y < buffer.Height / 16; y++)
            {
                for (int x = 0; x < buffer.Width / 16; x++)
                {
                    if (y + y_ < 0 || x + x_ < 0) continue;
                    int index = (y + y_) * 16 + x + x_;
                    Tile16x16 tile = buffer.Tiles[y * (buffer.Width / 16) + x];
                    tileSet.TileSetLayers[Layer][index] = tile.Copy();
                    tileSet.TileSetLayers[Layer][index].TileIndex = index;
                }
            }
            overlay.SelectTS = null;
            tileSet.DrawTileset(tileSet.TileSetLayers[Layer], tileSet.TileSets[Layer]);
            tileSet.AssembleIntoModel(16, Layer);
            SetTileSetImage();
            if (autoUpdate.Checked)
                update.DynamicInvoke();
        }
        private void Delete()
        {
            if (overlay.SelectTS == null) return;
            int x_ = overlay.SelectTS.Location.X / 16;
            int y_ = overlay.SelectTS.Location.Y / 16;
            for (int y = 0; y < overlay.SelectTS.Height / 16; y++)
            {
                for (int x = 0; x < overlay.SelectTS.Width / 16; x++)
                    tileSet.TileSetLayers[Layer][(y + y_) * 16 + x + x_].Clear();
            }
            tileSet.DrawTileset(tileSet.TileSetLayers[Layer], tileSet.TileSets[Layer]);
            tileSet.AssembleIntoModel(16, Layer);
            SetTileSetImage();
            if (autoUpdate.Checked)
                update.DynamicInvoke();
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
                        tileSet.TileSetLayers[Layer][(y + y_) * 16 + x + x_].Copy();
                }
            }
            if (type == "mirror")
                Do.FlipHorizontal(copiedTiles, overlay.SelectTS.Width / 16, overlay.SelectTS.Height / 16);
            else if (type == "invert")
                Do.FlipVertical(copiedTiles, overlay.SelectTS.Width / 16, overlay.SelectTS.Height / 16);
            buffer.Tiles = copiedTiles;
            PasteFinal(buffer);
        }
        private void Priority1(bool priority1)
        {
            if (draggedTiles != null)
                PasteFinal(draggedTiles);
            if (overlay.SelectTS == null) return;
            int x_ = overlay.SelectTS.Location.X / 16;
            int y_ = overlay.SelectTS.Location.Y / 16;
            for (int y = 0; y < overlay.SelectTS.Height / 16; y++)
            {
                for (int x = 0; x < overlay.SelectTS.Width / 16; x++)
                {
                    Tile16x16 tile = tileSet.TileSetLayers[Layer][(y + y_) * 16 + x + x_];
                    foreach (Tile8x8 subtile in tile.Subtiles)
                        subtile.PriorityOne = priority1;
                }
            }
            tileSet.DrawTileset(tileSet.TileSetLayers[Layer], tileSet.TileSets[Layer]);
            SetTileSetImage();
            if (autoUpdate.Checked)
                update.DynamicInvoke();
        }
        #endregion
        #region Event handlers
        // main
        private void tabControl1_Deselecting(object sender, TabControlCancelEventArgs e)
        {
            if (draggedTiles != null)
                PasteFinal(draggedTiles);
            else
                overlay.SelectTS = null;
        }
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetTileSetImage();
        }
        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            e.Cancel = tileSet.TileSetLayers[e.TabPageIndex] == null;
        }
        // image
        private void pictureBoxTileset_Paint(object sender, PaintEventArgs e)
        {
            if (tileSetImage == null) return;

            Rectangle rdst = new Rectangle(0, 0, 256, 512);

            if (buttonToggleBG.Checked)
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(paletteSet.Palette[16])), rdst);

            e.Graphics.DrawImage(tileSetImage, rdst, 0, 0, 256, 512, GraphicsUnit.Pixel);
            if (moving && selection != null)
            {
                Rectangle rsrc = new Rectangle(0, 0, overlay.SelectTS.Width, overlay.SelectTS.Height);
                rdst = new Rectangle(
                    overlay.SelectTS.X * zoom, overlay.SelectTS.Y * zoom,
                    rsrc.Width * zoom, rsrc.Height * zoom);
                e.Graphics.DrawImage(new Bitmap(selection), rdst, rsrc, GraphicsUnit.Pixel);
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

            if (priority1 != null && buttonToggleP1.Checked)
                e.Graphics.DrawImage(priority1, rdst, 0, 0, 256, 512, GraphicsUnit.Pixel, ia);

            if (mouseEnter)
                DrawHoverBox(e.Graphics);

            if (buttonToggleCartGrid.Checked)
                overlay.DrawCartesianGrid(e.Graphics, Color.Gray, pictureBox.Size, new Size(16, 16), 1);

            if (overlay.SelectTS != null)
                overlay.DrawSelectionBox(e.Graphics, overlay.SelectTS.Terminal, overlay.SelectTS.Location, 1);
        }
        private void pictureBoxTileset_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Clicks > 1) return;
            if (e.Button == MouseButtons.Right) return;
            mouseDownObject = null;
            // set a floor and ceiling for the coordinates
            int x = Math.Max(0, Math.Min(e.X, pictureBox.Width));
            int y = Math.Max(0, Math.Min(e.Y, pictureBox.Height));
            pictureBox.Focus();
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
            if (!lockEditing.Checked && e.Button == MouseButtons.Left && mouseOverObject == "selection")
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
            int x = Math.Max(0, Math.Min(e.X, pictureBox.Width));
            int y = Math.Max(0, Math.Min(e.Y, pictureBox.Height));
            mousePosition = new Point(x, y);
            // if making a new selection
            if (e.Button == MouseButtons.Left && mouseDownObject == null && overlay.SelectTS != null)
                overlay.SelectTS.Final = new Point(
                        Math.Min(x + 16, pictureBox.Width),
                        Math.Min(y + 16, pictureBox.Height));
            // if dragging the current selection
            if (e.Button == MouseButtons.Left && mouseDownObject == "selection")
                overlay.SelectTS.Location = new Point(
                    x / 16 * 16 - mouseDownPosition.X,
                    y / 16 * 16 - mouseDownPosition.Y);
            // check if over selection
            if (!lockEditing.Checked && e.Button == MouseButtons.None && overlay.SelectTS != null && overlay.SelectTS.MouseWithin(x, y))
            {
                mouseOverObject = "selection";
                pictureBox.Cursor = Cursors.SizeAll;
            }
            else
                pictureBox.Cursor = Cursors.Cross;
            pictureBox.Invalidate();
            int index = y / 16 * 16 + (x / 16);
            labelTileIndex.Text = "Tile index: " + index + " ($" + index.ToString("X2") + ")";
        }
        public void PictureBoxTileset_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBoxTileset_MouseUp(sender, e);
        }
        private void pictureBoxTileset_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) return;
            if (overlay.SelectTS == null) return;
            int x_ = overlay.SelectTS.Location.X / 16;
            int y_ = overlay.SelectTS.Location.Y / 16;
            if (this.selectedTiles == null)
                this.selectedTiles = new CopyBuffer(overlay.SelectTS.Width, overlay.SelectTS.Height);
            int[][] selectedTiles = new int[3][];
            selectedTiles[Layer] = new int[(overlay.SelectTS.Width / 16) * (overlay.SelectTS.Height / 16)];
            for (int y = 0; y < overlay.SelectTS.Height / 16; y++)
            {
                for (int x = 0; x < overlay.SelectTS.Width / 16; x++)
                    selectedTiles[Layer][y * (overlay.SelectTS.Width / 16) + x] = (y + y_) * 16 + x + x_;
            }
            this.selectedTiles.Copies = selectedTiles;
            pictureBox.Focus();
        }
        private void pictureBoxTileset_MouseClick(object sender, MouseEventArgs e)
        {

        }
        private void pictureBoxTileset_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }
        private void pictureBoxTileset_MouseEnter(object sender, EventArgs e)
        {
            mouseEnter = true;
            pictureBox.Invalidate();
        }
        private void pictureBoxTileset_MouseLeave(object sender, EventArgs e)
        {
            mouseEnter = false;
            pictureBox.Invalidate();
        }
        private void pictureBoxTileset_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == (Keys.Control | Keys.V) && !lockEditing.Checked)
                buttonEditPaste_Click(null, null);
            if (e.KeyData == (Keys.Control | Keys.C) && !lockEditing.Checked)
                buttonEditCopy_Click(null, null);
            if (e.KeyData == Keys.Delete && !lockEditing.Checked)
                buttonEditDelete_Click(null, null);
            if (e.KeyData == (Keys.Control | Keys.X) && !lockEditing.Checked)
                buttonEditCut_Click(null, null);
            if (e.KeyData == (Keys.Control | Keys.D))
            {
                if (draggedTiles != null)
                    PasteFinal(draggedTiles);
                else
                {
                    overlay.SelectTS = null;
                    pictureBox.Invalidate();
                }
            }
            if (e.KeyData == (Keys.Control | Keys.A))
            {
                overlay.SelectTS = new Overlay.Selection(16, 0, 0, 1024, 1024);
                pictureBox.Invalidate();
            }
        }
        // toolstrip
        private void buttonToggleTileEditor_Click(object sender, EventArgs e)
        {
            tileEditor.Visible = true;
        }
        private void buttonToggleCartGrid_Click(object sender, EventArgs e)
        {
            this.pictureBox.Invalidate();
        }
        private void buttonToggleBG_Click(object sender, EventArgs e)
        {
            this.pictureBox.Invalidate();
        }
        private void buttonToggleP1_Click(object sender, EventArgs e)
        {
            this.pictureBox.Invalidate();
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
        private void buttonEditUndo_Click(object sender, EventArgs e)
        {

        }
        private void buttonEditRedo_Click(object sender, EventArgs e)
        {

        }
        // contextmenustrip
        private void priority1SetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Priority1(true);
        }
        private void priority1ClearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Priority1(false);
        }
        private void mirrorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Flip("mirror");
        }
        private void invertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Flip("invert");
        }
        private void saveImageAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Do.Export(tileSetImage, "tileSet.png");
        }
        // editors
        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            update.DynamicInvoke();
        }
        private void editor_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            ((Form)sender).Hide();
        }
        #endregion
    }
}