﻿using System;
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
    public partial class EffectMolds : Form
    {
        #region Variables
        // main
        private delegate void Function();
        // main editor accessed variables
        private Effects effectsEditor;
        private Effect effect { get { return effectsEditor.Effect; } set { effectsEditor.Effect = value; } }
        private EffectSequences sequences { get { return effectsEditor.Sequences; } set { effectsEditor.Sequences = value; } }
        private E_Animation animation { get { return effectsEditor.Animation; } set { effectsEditor.Animation = value; } }
        private int availableBytes { get { return effectsEditor.AvailableBytes; } set { effectsEditor.AvailableBytes = value; } }
        public bool ShowBG { get { return showBG.Checked; } }
        // local variables
        private E_Tileset tileset { get { return animation.Tileset; } set { animation.Tileset = value; } }
        private ArrayList molds { get { return animation.Molds; } }
        private E_Mold mold { get { return (E_Mold)animation.Molds[e_molds.SelectedIndex]; } }
        private int index { get { return e_molds.SelectedIndex; } set { e_molds.SelectedIndex = value; } }
        private Bitmap tilemapImage;
        private Bitmap tilesetImage;
        private bool updating = false;
        private Overlay overlay;
        private int zoom = 1;
        private int width { get { return animation.Width * 16; } }
        private int height { get { return animation.Height * 16; } }
        private bool move = false;
        // mouse
        private bool mouseWithinSameBounds = false;
        private int mouseOverTile = 0;
        private int mouseDownTile = 0;
        private string mouseOverObject;
        private string mouseDownObject;
        private Point mouseDownPosition;
        private Point mousePosition;
        private bool mouseEnter = false;
        // buffers
        private CopyBuffer draggedTiles;
        private CopyBuffer copiedTiles;
        private CopyBuffer selectedTiles;
        private CommandStack commandStack;
        private Bitmap selection;
        // editors
        public TileEditor tileEditor;
        // special controls
        #endregion
        #region Functions
        public EffectMolds(Effects effectsEditor)
        {
            this.effectsEditor = effectsEditor;
            this.overlay = new Overlay();
            this.commandStack = new CommandStack();
            InitializeComponent();
            updating = true;
            for (int i = 0; i < animation.Molds.Count; i++)
                this.e_molds.Items.Add("Mold " + i.ToString());
            this.e_molds.SelectedIndex = 0;
            e_moldWidth.Value = animation.Width;
            e_moldHeight.Value = animation.Height;
            e_tileSetSize.Value = animation.TileSetLength;
            updating = false;
            SetTilesetImage();
            SetTilemapImage();
            LoadTileEditor();
        }
        public void Reload(Effects effectsEditor)
        {
            this.effectsEditor = effectsEditor;
            this.commandStack = new CommandStack();
            this.overlay.Select = null;
            this.overlay.SelectTS = null;
            this.selectedTiles = null;
            this.draggedTiles = null;
            this.copiedTiles = null;
            updating = true;
            this.e_molds.Items.Clear();
            for (int i = 0; i < animation.Molds.Count; i++)
                this.e_molds.Items.Add("Mold " + i.ToString());
            this.e_molds.SelectedIndex = 0;
            e_moldWidth.Value = animation.Width;
            e_moldHeight.Value = animation.Height;
            e_tileSetSize.Value = animation.TileSetLength;
            updating = false;
            SetTilesetImage();
            SetTilemapImage();
            LoadTileEditor();
        }
        private void RefreshMold()
        {
            SetTilemapImage();
        }
        public void SetTilesetImage()
        {
            int[] pixels = Do.TilesetToPixels(tileset.Tileset, 8, 8, 0, false);
            tilesetImage = new Bitmap(Do.PixelsToImage(pixels, 128, (int)e_tileSetSize.Value / 64 * 16));
            pictureBoxEffectTileset.Size = tilesetImage.Size;
            pictureBoxEffectTileset.Invalidate();
        }
        public void SetTilemapImage()
        {
            int[] pixels = mold.MoldPixels(animation, tileset);
            tilemapImage = new Bitmap(Do.PixelsToImage(pixels, animation.Width * 16, animation.Height * 16));
            pictureBoxE_Mold.Size = new Size(tilemapImage.Width * zoom, tilemapImage.Height * zoom);
            pictureBoxE_Mold.Invalidate();
        }
        public void SetToolTips(ToolTip toolTip1)
        {
            this.e_moldWidth.ToolTipText =
                "The width of all spell effect animation molds, in 16x16 tiles.";

            this.e_moldHeight.ToolTipText =
                "The height of all spell effect animation molds, in 16x16 tiles.";

            toolTip1.SetToolTip(this.e_tileSetSize,
                "The size of the tileset in hexadecimal bytes. The total \n" +
                "number of tiles in the spell effect image's tileset equals the \n" +
                "size (in hexadecimal) divided by 8.");

            toolTip1.SetToolTip(this.e_molds,
                "The collection of molds used by the spell effect's animation. \n" +
                "A spell effect animation's mold is a set of tiles arranged in a \n" +
                "sequence, from left to right and top to bottom in rows \n" +
                "(much like how text wraps to the next line in your typical \n" +
                "text editor). The number of tiles in a row is the value set \n" +
                "for the \"Width\" property above.");

            this.newMold.ToolTipText =
                "Insert a new mold after the currently selected mold.";

            this.deleteMold.ToolTipText =
                "Delete the currently selected mold.";
        }
        // editors
        public void LoadTileEditor()
        {
            if (tileEditor == null)
            {
                tileEditor = new TileEditor(new Function(TileUpdate),
                tileset.Tileset[mouseDownTile], tileset.Graphics,
                animation.PaletteSet, animation.Codec == 1 ? (byte)0x10 : (byte)0x20);
                tileEditor.FormClosing += new FormClosingEventHandler(editor_FormClosing);
            }
            else
                tileEditor.Reload(new Function(TileUpdate),
                this.tileset.Tileset[mouseDownTile], tileset.Graphics,
                animation.PaletteSet, animation.Codec == 1 ? (byte)0x10 : (byte)0x20);
        }
        private void TileUpdate()
        {
            SetTilesetImage();
            SetTilemapImage();
            sequences.SetSequenceFrameImages();
            sequences.RealignFrames();
        }
        // drawing
        private void DrawHoverBox(Graphics g)
        {
            Rectangle r = new Rectangle(mousePosition.X / 16 * 16 * zoom, mousePosition.Y / 16 * 16 * zoom, 16 * zoom, 16 * zoom);
            g.FillRectangle(new SolidBrush(Color.FromArgb(96, 0, 0, 0)), r);
        }
        private void Draw(Graphics g, int x, int y)
        {
            x /= 16;
            y /= 16;
            // cancel if no selection in the tileset is made
            if (overlay.SelectTS == null) return;
            // check to see if overwriting same tile(s)
            for (int y_ = 0; y_ < overlay.SelectTS.Height / 16; y_++)
            {
                for (int x_ = 0; x_ < overlay.SelectTS.Width / 16; x_++)
                {
                    int index = ((overlay.SelectTS.Y / 16) + y_) * 8 + (overlay.SelectTS.X / 16) + x_;
                    int map = (y + y_) * (width / 16) + x + x_;
                    // cancel if overwriting same tile(s)
                    if (mold.Mold[map] == index)
                        return;
                }
            }
            commandStack.Push(new TilemapCommand(
                mold.Mold, width / 16, height / 16, selectedTiles.BYTE_copy, x, y,
                overlay.SelectTS.Width / 16, overlay.SelectTS.Height / 16));
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
            if (mold.Mold[(y / 16) * (width / 16) + (x / 16)] == 0xFF) return;
            commandStack.Push(new TilemapCommand(
                mold.Mold, width / 16, height / 16, new byte[] { 0xFF }, x / 16, y / 16, 1, 1));
        }
        private void Undo()
        {
            commandStack.UndoCommand();
            SetTilemapImage();
            if (sequences != null)
            {
                sequences.SetSequenceFrameImages();
                sequences.RealignFrames();
            }
        }
        private void Redo()
        {
            commandStack.RedoCommand();
            SetTilemapImage();
            if (sequences != null)
            {
                sequences.SetSequenceFrameImages();
                sequences.RealignFrames();
            }
        }
        private void Cut()
        {
            if (overlay.Select == null || overlay.Select.Size == new Size(0, 0)) return;
            Copy();
            Delete();
        }
        private void Copy()
        {
            if (overlay.Select == null || overlay.Select.Size == new Size(0, 0)) return;
            if (draggedTiles != null)
            {
                this.copiedTiles = draggedTiles;
                return;
            }
            selection = new Bitmap(tilemapImage.Clone(
                new Rectangle(overlay.Select.Location, overlay.Select.Size), PixelFormat.DontCare));
            selection.Save("image.png", ImageFormat.Png);
            int[] copiedTiles = new int[(overlay.Select.Width / 16) * (overlay.Select.Height / 16)];
            this.copiedTiles = new CopyBuffer(overlay.Select.Width, overlay.Select.Height);
            for (int y = 0, y_ = overlay.Select.Y / 16; y < overlay.Select.Height / 16; y++, y_++)
            {
                for (int x = 0, x_ = overlay.Select.X / 16; x < overlay.Select.Width / 16; x++, x_++)
                    copiedTiles[y * (overlay.Select.Width / 16) + x] = mold.Mold[y_ * (width / 16) + x_];
            }
            this.copiedTiles.Copy = copiedTiles;
        }
        /// <summary>
        /// Start dragging a current selection.
        /// </summary>
        private void Drag()
        {
            if (overlay.Select == null || overlay.Select.Size == new Size(0, 0)) return;
            selection = new Bitmap(tilemapImage.Clone(
                new Rectangle(overlay.Select.Location, overlay.Select.Size), PixelFormat.DontCare));
            selection.Save("image.png", ImageFormat.Png);
            int[] copiedTiles = new int[(overlay.Select.Width / 16) * (overlay.Select.Height / 16)];
            this.copiedTiles = new CopyBuffer(overlay.Select.Width, overlay.Select.Height);
            for (int y = 0, y_ = overlay.Select.Y / 16; y < overlay.Select.Height / 16; y++, y_++)
            {
                for (int x = 0, x_ = overlay.Select.X / 16; x < overlay.Select.Width / 16; x++, x_++)
                {
                    int tileX = overlay.Select.X + (x * 16);
                    int tileY = overlay.Select.Y + (y * 16);
                    copiedTiles[y * (overlay.Select.Width / 16) + x] = mold.Mold[y_ * (width / 16) + x_];
                }
            }
            this.copiedTiles.Copy = copiedTiles;
            Delete();
        }
        private void Paste(Point location, CopyBuffer buffer)
        {
            if (buffer == null) return;
            move = true;
            // now dragging a new selection
            draggedTiles = buffer;
            overlay.Select = new Overlay.Selection(16, location, buffer.Size);
            pictureBoxE_Mold.Invalidate();
        }
        /// <summary>
        /// "Cements" either a dragged selection or a newly pasted selection.
        /// </summary>
        /// <param name="buffer">The dragged selection or the newly pasted selection.</param>
        private void PasteFinal(CopyBuffer buffer)
        {
            if (buffer == null) return;
            Point location = new Point();
            location.X = overlay.Select.X / 16;
            location.Y = overlay.Select.Y / 16;
            commandStack.Push(new TilemapCommand(
                mold.Mold, width / 16, height / 16, buffer.BYTE_copy,
                location.X, location.Y, buffer.Width / 16, buffer.Height / 16));
            SetTilemapImage();
            if (sequences != null)
            {
                sequences.SetSequenceFrameImages();
                sequences.RealignFrames();
            }
        }
        private void Delete()
        {
            if (overlay.Select == null) return;
            if (tileset.Tileset == null || overlay.Select.Size == new Size(0, 0)) return;
            Point location = overlay.Select.Location;
            Point terminal = overlay.Select.Terminal;
            byte[] changes = new byte[(overlay.Select.Width / 16) * (overlay.Select.Height / 16)];
            Bits.SetByteArray(changes, 0xFF);
            commandStack.Push(new TilemapCommand(
                mold.Mold, width / 16, height / 16, changes,
                overlay.Select.X / 16, overlay.Select.Y / 16, overlay.Select.Width / 16, overlay.Select.Height / 16));
            SetTilemapImage();
            if (sequences != null)
            {
                sequences.SetSequenceFrameImages();
                sequences.RealignFrames();
            }
        }
        /// <summary>
        /// Flips the mold selection vertically or horizontally.
        /// </summary>
        /// <param name="type">Either "mirror" or "invert".</param>
        private void Flip(string type)
        {
            if (overlay.Select == null) return;
            if (tileset.Tileset == null || overlay.Select.Size == new Size(0, 0)) return;
            Point location = overlay.Select.Location;
            Point terminal = overlay.Select.Terminal;
            byte[] flippedTiles = new byte[(overlay.Select.Width / 16) * (overlay.Select.Height / 16)];
            for (int y = 0, y_ = overlay.Select.Y / 16; y < overlay.Select.Height / 16; y++, y_++)
            {
                for (int x = 0, x_ = overlay.Select.X / 16; x < overlay.Select.Width / 16; x++, x_++)
                {
                    flippedTiles[y * (overlay.Select.Width / 16) + x] = mold.Mold[y_ * (width / 16) + x_];
                    if (type == "mirror" && flippedTiles[y * (overlay.Select.Width / 16) + x] != 0xFF)
                        flippedTiles[y * (overlay.Select.Width / 16) + x] ^= 0x40;
                    if (type == "invert" && flippedTiles[y * (overlay.Select.Width / 16) + x] != 0xFF)
                        flippedTiles[y * (overlay.Select.Width / 16) + x] ^= 0x80;
                }
            }
            if (type == "mirror")
                Do.FlipHorizontal(flippedTiles, overlay.Select.Width / 16, overlay.Select.Height / 16);
            if (type == "invert")
                Do.FlipVertical(flippedTiles, overlay.Select.Width / 16, overlay.Select.Height / 16);
            commandStack.Push(new TilemapCommand(
                mold.Mold, width / 16, height / 16, flippedTiles,
                overlay.Select.X / 16, overlay.Select.Y / 16, overlay.Select.Width / 16, overlay.Select.Height / 16));
            SetTilemapImage();
            if (sequences != null)
            {
                sequences.SetSequenceFrameImages();
                sequences.RealignFrames();
            }
        }
        private class TilemapCommand : Command
        {
            private byte[] src;
            private Size srcSize;
            private byte[] changes;
            private Point location;
            private Size size;
            private bool autoRedo = false; public bool AutoRedo() { return this.autoRedo; }
            public TilemapCommand(byte[] src, int srcWidth, int srcHeight, byte[] changes, int x, int y, int width, int height)
            {
                this.src = src;
                this.changes = new byte[changes.Length];
                changes.CopyTo(this.changes, 0);
                this.srcSize = new Size(srcWidth, srcHeight);
                this.size = new Size(width, height);
                this.location = new Point(x, y);
                Execute();
            }
            public void Execute()
            {
                for (int y = location.Y, y_ = 0; y < location.Y + size.Height; y++, y_++)
                {
                    for (int x = location.X, x_ = 0; x < location.X + size.Width; x++, x_++)
                    {
                        if (x < 0 || y < 0 || x_ < 0 || y_ < 0) continue;
                        byte temp = src[y * srcSize.Width + x];
                        src[y * srcSize.Width + x] = changes[y_ * size.Width + x_];
                        changes[y_ * size.Width + x_] = temp;
                    }
                }
            }
        }
        #endregion
        #region Event Handlers
        private void pictureBoxEffectTileset_Paint(object sender, PaintEventArgs e)
        {
            if (showBG.Checked)
                e.Graphics.FillRectangle(
                    new SolidBrush(Color.FromArgb(animation.PaletteSet.Palettes[effect.PaletteIndex][0])),
                    new Rectangle(new Point(0, 0), pictureBoxEffectTileset.Size));
            if (tilesetImage != null)
                e.Graphics.DrawImage(tilesetImage, 0, 0, 128, (int)e_tileSetSize.Value / 64 * 16);
            if (e_moldShowGrid.Checked)
                overlay.DrawCartesianGrid(e.Graphics, Color.Gray, pictureBoxEffectTileset.Size, new Size(16, 16), 1);
            if (overlay.SelectTS != null)
                overlay.DrawSelectionBox(e.Graphics, overlay.SelectTS.Terminal, overlay.SelectTS.Location, 1);
        }
        private void pictureBoxEffectTileset_MouseDown(object sender, MouseEventArgs e)
        {
            // set a floor and ceiling for the coordinates
            int x = Math.Max(0, Math.Min(e.X, pictureBoxEffectTileset.Width));
            int y = Math.Max(0, Math.Min(e.Y, pictureBoxEffectTileset.Height));
            mouseDownTile = (y / 16) * 8 + (x / 16);
            // if making a new selection
            if (e.Button == MouseButtons.Left && mouseOverObject == null)
                overlay.SelectTS = new Overlay.Selection(16, x / 16 * 16, y / 16 * 16, 16, 16);
            pictureBoxEffectTileset.Invalidate();
            LoadTileEditor();
        }
        private void pictureBoxEffectTileset_MouseMove(object sender, MouseEventArgs e)
        {
            // set a floor and ceiling for the coordinates
            int x = Math.Max(0, Math.Min(e.X, pictureBoxEffectTileset.Width));
            int y = Math.Max(0, Math.Min(e.Y, pictureBoxEffectTileset.Height));
            // if making a new selection
            if (e.Button == MouseButtons.Left && mouseDownObject == null && overlay.SelectTS != null)
            {
                overlay.SelectTS.Final = new Point(
                        Math.Min(x + 16, pictureBoxEffectTileset.Width),
                        Math.Min(y + 16, pictureBoxEffectTileset.Height));
            }
            pictureBoxEffectTileset.Invalidate();
        }
        private void pictureBoxEffectTileset_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) return;
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
                    selectedTiles[y * (overlay.SelectTS.Width / 16) + x] = (y + y_) * 16 + x + x_;
                }
            }
            this.selectedTiles.Copy = selectedTiles;
            pictureBoxEffectTileset.Focus();
        }
        private void pictureBoxE_Mold_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            if (showBG.Checked)
                e.Graphics.FillRectangle(
                    new SolidBrush(Color.FromArgb(animation.PaletteSet.Palettes[effect.PaletteIndex][0])),
                    new Rectangle(new Point(0, 0), pictureBoxE_Mold.Size));
            if (tilemapImage != null && e.ClipRectangle.Size != new Size(16, 16))
            {
                Rectangle src = new Rectangle(0, 0, tilemapImage.Width, tilemapImage.Height);
                Rectangle dst = new Rectangle(0, 0, tilemapImage.Width * zoom, tilemapImage.Height * zoom);
                e.Graphics.DrawImage(tilemapImage, dst, src, GraphicsUnit.Pixel);
            }
            if (move && selection != null && overlay.Select != null)
            {
                Rectangle src = new Rectangle(0, 0, overlay.Select.Width, overlay.Select.Height);
                Rectangle dst = new Rectangle(
                    overlay.Select.X * zoom, overlay.Select.Y * zoom,
                    src.Width * zoom, src.Height * zoom);
                e.Graphics.DrawImage(new Bitmap(selection), dst, src, GraphicsUnit.Pixel);
            }
            if (mouseEnter && e.ClipRectangle.Size != new Size(16, 16))
                DrawHoverBox(e.Graphics);
            if (e_moldShowGrid.Checked)
                overlay.DrawCartesianGrid(e.Graphics, Color.Gray, pictureBoxE_Mold.Size, new Size(16, 16), zoom);
            if (select.Checked)
            {
                if (overlay.Select != null)
                    overlay.DrawSelectionBox(e.Graphics, overlay.Select.Terminal, overlay.Select.Location, zoom);
            }
        }
        private void pictureBoxE_Mold_MouseDown(object sender, MouseEventArgs e)
        {
            // set a floor and ceiling for the coordinates
            int x = Math.Max(0, Math.Min(e.X / zoom, width));
            int y = Math.Max(0, Math.Min(e.Y / zoom, height));
            #region Zooming
            Point p = new Point();
            p.X = Math.Abs(panel99.AutoScrollPosition.X);
            p.Y = Math.Abs(panel99.AutoScrollPosition.Y);
            if ((e_moldZoomIn.Checked && e.Button == MouseButtons.Left) || (e_moldZoomOut.Checked && e.Button == MouseButtons.Right))
            {
                if (zoom < 8)
                {
                    zoom *= 2;
                    p = new Point(Math.Abs(pictureBoxE_Mold.Left), Math.Abs(pictureBoxE_Mold.Top));
                    p.X += e.X;
                    p.Y += e.Y;
                    pictureBoxE_Mold.Width = width * zoom;
                    pictureBoxE_Mold.Height = height * zoom;
                    panel99.Focus();
                    panel99.AutoScrollPosition = p;
                    panel99.VerticalScroll.SmallChange *= 2;
                    panel99.HorizontalScroll.SmallChange *= 2;
                    panel99.VerticalScroll.LargeChange *= 2;
                    panel99.HorizontalScroll.LargeChange *= 2;
                    pictureBoxE_Mold.Invalidate();
                    return;
                }
                return;
            }
            else if ((e_moldZoomOut.Checked && e.Button == MouseButtons.Left) || (e_moldZoomIn.Checked && e.Button == MouseButtons.Right))
            {
                if (zoom > 1)
                {
                    zoom /= 2;

                    p = new Point(Math.Abs(pictureBoxE_Mold.Left), Math.Abs(pictureBoxE_Mold.Top));
                    p.X -= e.X / 2;
                    p.Y -= e.Y / 2;

                    pictureBoxE_Mold.Width = width * zoom;
                    pictureBoxE_Mold.Height = height * zoom;
                    panel99.Focus();
                    panel99.AutoScrollPosition = p;
                    panel99.VerticalScroll.SmallChange /= 2;
                    panel99.HorizontalScroll.SmallChange /= 2;
                    panel99.VerticalScroll.LargeChange /= 2;
                    panel99.HorizontalScroll.LargeChange /= 2;
                    pictureBoxE_Mold.Invalidate();
                    return;
                }
                return;
            }
            #endregion
            if (e.Button == MouseButtons.Right) return;
            #region Drawing, Erasing, Selecting
            // if moving an object and outside of it, paste it
            if (move && mouseOverObject != "selection")
            {
                // if copied tiles were pasted and not dragging a non-copied selection
                if (copiedTiles != null && draggedTiles == null)
                    PasteFinal(copiedTiles);
                if (draggedTiles != null)
                {
                    PasteFinal(draggedTiles);
                    draggedTiles = null;
                }
                move = false;
            }
            if (select.Checked)
            {
                // if we're not inside a current selection to move it, create a new selection
                if (mouseOverObject != "selection")
                    overlay.Select = new Overlay.Selection(16, x / 16 * 16, y / 16 * 16, 16, 16);
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
                }
            }
            if (e.Button == MouseButtons.Left)
            {
                if (draw.Checked)
                {
                    Draw(pictureBoxE_Mold.CreateGraphics(), x, y);
                    panel99.AutoScrollPosition = p;
                    return;
                }
                if (erase.Checked)
                {
                    Erase(x, y);
                    pictureBoxE_Mold.Invalidate(new Rectangle(x / 16 * 16, y / 16 * 16, 16, 16));
                    panel99.AutoScrollPosition = p;
                    return;
                }
            }
            #endregion
            panel99.AutoScrollPosition = p;
            pictureBoxE_Mold.Invalidate();
        }
        private void pictureBoxE_Mold_MouseMove(object sender, MouseEventArgs e)
        {
            // set a floor and ceiling for the coordinates
            int x = Math.Max(0, Math.Min(e.X / zoom, width));
            int y = Math.Max(0, Math.Min(e.Y / zoom, height));
            // must first check if within same bounds as last call of MouseMove event
            mouseWithinSameBounds = mouseOverTile == (y / 16 * 64) + (x / 16);
            // now set the properties
            mousePosition = new Point(x, y);
            mouseOverTile = (y / 16 * 64) + (x / 16);
            mouseOverObject = null;
            #region Zooming
            // if either zoom button is checked, don't do anything else
            if (e_moldZoomIn.Checked || e_moldZoomOut.Checked)
            {
                pictureBoxE_Mold.Invalidate();
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
                        Math.Min(x + 16, pictureBoxE_Mold.Width),
                        Math.Min(y + 16, pictureBoxE_Mold.Height));
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
                    pictureBoxE_Mold.Cursor = Cursors.SizeAll;
                }
                else
                    pictureBoxE_Mold.Cursor = Cursors.Cross;
                pictureBoxE_Mold.Invalidate();
                return;
            }
            if (draw.Checked && e.Button == MouseButtons.Left)
            {
                Draw(pictureBoxE_Mold.CreateGraphics(), x, y);
                return;
            }
            else if (erase.Checked && e.Button == MouseButtons.Left)
            {
                Erase(x, y);
                pictureBoxE_Mold.Invalidate(new Rectangle(x / 16 * 16, y / 16 * 16, 16, 16));
                return;
            }
            #endregion
            pictureBoxE_Mold.Invalidate();
        }
        private void pictureBoxE_Mold_MouseClick(object sender, MouseEventArgs e)
        {

        }
        private void pictureBoxE_Mold_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDownObject = null;
            if (draw.Checked || erase.Checked)
            {
                SetTilemapImage();
                if (sequences != null)
                {
                    sequences.SetSequenceFrameImages();
                    sequences.RealignFrames();
                }
            }
            Point p = new Point(Math.Abs(pictureBoxE_Mold.Left), Math.Abs(pictureBoxE_Mold.Top));
            pictureBoxE_Mold.Focus();
            panel99.AutoScrollPosition = p;
            // update free space
            animation.Assemble();
            effectsEditor.CalculateFreeSpace();
        }
        private void pictureBoxE_Mold_MouseEnter(object sender, EventArgs e)
        {
            mouseEnter = true;
            pictureBoxE_Mold.Invalidate();
        }
        private void pictureBoxE_Mold_MouseLeave(object sender, EventArgs e)
        {
            mouseEnter = false;
            pictureBoxE_Mold.Invalidate();
        }
        private void pictureBoxE_Mold_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Control | Keys.V:
                    paste_Click(null, null); break;
                case Keys.Control | Keys.C:
                    copy_Click(null, null); break;
                case Keys.Delete:
                    delete_Click(null, null); break;
                case Keys.Control | Keys.X:
                    cut_Click(null, null); break;
                case Keys.Control | Keys.D:
                    if (draggedTiles != null)
                        PasteFinal(draggedTiles);
                    else
                    {
                        overlay.Select = null;
                        pictureBoxE_Mold.Invalidate();
                    }
                    break;
                case Keys.Control | Keys.A:
                    selectAll_Click(null, null); break;
                case Keys.Control | Keys.Z:
                    undoButton_Click(null, null); break;
                case Keys.Control | Keys.Y:
                    redoButton_Click(null, null); break;
            }
        }
        private void e_molds_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updating) return;
            RefreshMold();
        }
        private void e_tileSetSize_ValueChanged(object sender, EventArgs e)
        {
            if (updating) return;
            if (animation.Codec == 0)
                e_tileSetSize.Value = (int)e_tileSetSize.Value & 0xFFE0;
            else
                e_tileSetSize.Value = (int)e_tileSetSize.Value & 0xFFF0;
            animation.TileSetLength = (int)e_tileSetSize.Value;
            SetTilesetImage();
            // update free space
            animation.Assemble();
            effectsEditor.CalculateFreeSpace();
        }
        private void e_moldWidth_ValueChanged(object sender, EventArgs e)
        {
            animation.Width = (byte)e_moldWidth.Value;
            SetTilemapImage();
            if (sequences != null)
            {
                sequences.SetSequenceFrameImages();
                sequences.RealignFrames();
            }
            // update free space
            animation.Assemble();
            effectsEditor.CalculateFreeSpace();
        }
        private void e_moldHeight_ValueChanged(object sender, EventArgs e)
        {
            animation.Height = (byte)e_moldHeight.Value;
            SetTilemapImage();
            if (sequences != null)
            {
                sequences.SetSequenceFrameImages();
                sequences.RealignFrames();
            }
            // update free space
            animation.Assemble();
            effectsEditor.CalculateFreeSpace();
        }
        private void newMold_Click(object sender, EventArgs e)
        {
            if (molds.Count == 32)
            {
                MessageBox.Show("Animations cannot contain more than 32 molds total.", "LAZY SHELL",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            int index = this.index;
            molds.Insert(index + 1, mold.New());
            updating = true;
            e_molds.BeginUpdate();
            e_molds.Items.Clear();
            for (int i = 0; i < animation.Molds.Count; i++)
                this.e_molds.Items.Add("Mold " + i.ToString());
            e_molds.EndUpdate();
            updating = false;
            this.index = index + 1;
            sequences.SetSequenceFrameImages();
            sequences.RealignFrames();
            // update free space
            animation.Assemble();
            effectsEditor.CalculateFreeSpace();
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
            e_molds.Items.RemoveAt(index);
            for (int i = 0; i < e_molds.Items.Count; i++)
                e_molds.Items[i] = "Mold " + i;
            updating = false;
            if (index >= molds.Count && molds.Count != 0)
                this.index = index - 1;
            else if (molds.Count != 0)
                this.index = index;
            RefreshMold();
            sequences.SetSequenceFrameImages();
            sequences.RealignFrames();
            // update free space
            animation.Assemble();
            effectsEditor.CalculateFreeSpace();
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
            molds.Insert(index + 1, mold.Copy());
            updating = true;
            e_molds.BeginUpdate();
            e_molds.Items.Clear();
            for (int i = 0; i < animation.Molds.Count; i++)
                this.e_molds.Items.Add("Mold " + i.ToString());
            e_molds.EndUpdate();
            updating = false;
            this.index = index + 1;
            sequences.SetSequenceFrameImages();
            sequences.RealignFrames();
            // update free space
            animation.Assemble();
            effectsEditor.CalculateFreeSpace();
        }
        // drawing
        private void e_moldShowGrid_Click(object sender, EventArgs e)
        {
            pictureBoxE_Mold.Invalidate();
            pictureBoxEffectTileset.Invalidate();
        }
        private void showBG_Click(object sender, EventArgs e)
        {
            pictureBoxE_Mold.Invalidate();
            pictureBoxEffectTileset.Invalidate();
            sequences.InvalidateImages();
        }
        private void draw_Click(object sender, EventArgs e)
        {
            select.Checked = false;
            erase.Checked = false;
            e_moldZoomIn.Checked = false;
            e_moldZoomOut.Checked = false;
            if (draw.Checked)
                this.pictureBoxE_Mold.Cursor = new Cursor(GetType(), "CursorDraw.cur");
            else if (!draw.Checked)
                this.pictureBoxE_Mold.Cursor = Cursors.Arrow;
            overlay.Select = null;
            pictureBoxE_Mold.Invalidate();
        }
        private void erase_Click(object sender, EventArgs e)
        {
            draw.Checked = false;
            select.Checked = false;
            e_moldZoomIn.Checked = false;
            e_moldZoomOut.Checked = false;
            if (erase.Checked)
                this.pictureBoxE_Mold.Cursor = new Cursor(GetType(), "CursorErase.cur");
            else if (!erase.Checked)
                this.pictureBoxE_Mold.Cursor = Cursors.Arrow;
            overlay.Select = null;
            pictureBoxE_Mold.Invalidate();
        }
        private void select_Click(object sender, EventArgs e)
        {
            draw.Checked = false;
            erase.Checked = false;
            e_moldZoomIn.Checked = false;
            e_moldZoomOut.Checked = false;
            if (select.Checked)
                this.pictureBoxE_Mold.Cursor = Cursors.Cross;
            else if (!select.Checked)
                this.pictureBoxE_Mold.Cursor = Cursors.Arrow;
            overlay.Select = null;
            pictureBoxE_Mold.Invalidate();
        }
        private void selectAll_Click(object sender, EventArgs e)
        {
            if (!select.Checked) return;
            if (draggedTiles != null)
                PasteFinal(draggedTiles);
            overlay.Select = new Overlay.Selection(16, 0, 0, width, height);
            pictureBoxE_Mold.Invalidate();
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
            if (draggedTiles != null)
                PasteFinal(draggedTiles);
            Paste(new Point(0, 0), copiedTiles);
        }
        private void delete_Click(object sender, EventArgs e)
        {
            Delete();
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
            Flip("mirror");
        }
        private void invert_Click(object sender, EventArgs e)
        {
            Flip("invert");
        }
        private void e_moldZoomIn_Click(object sender, EventArgs e)
        {
            draw.Checked = false;
            erase.Checked = false;
            select.Checked = false;
            e_moldZoomOut.Checked = false;
            if (e_moldZoomIn.Checked)
                this.pictureBoxE_Mold.Cursor = new Cursor(GetType(), "CursorZoomIn.cur");
            else if (!e_moldZoomIn.Checked)
                this.pictureBoxE_Mold.Cursor = Cursors.Arrow;
            overlay.Select = null;
            pictureBoxE_Mold.Invalidate();
        }
        private void e_moldZoomOut_Click(object sender, EventArgs e)
        {
            draw.Checked = false;
            erase.Checked = false;
            select.Checked = false;
            e_moldZoomIn.Checked = false;
            if (e_moldZoomOut.Checked)
                this.pictureBoxE_Mold.Cursor = new Cursor(GetType(), "CursorZoomOut.cur");
            else if (!e_moldZoomOut.Checked)
                this.pictureBoxE_Mold.Cursor = Cursors.Arrow;
            overlay.Select = null;
            pictureBoxE_Mold.Invalidate();
        }
        // contextmenustrip
        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (e_moldZoomIn.Checked || e_moldZoomOut.Checked)
                e.Cancel = true;
        }
        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cut();
        }
        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Copy();
        }
        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (draggedTiles != null)
                PasteFinal(draggedTiles);
            Paste(new Point(0, 0), copiedTiles);
        }
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Delete();
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
            Do.Export(tilemapImage,
                "effectAnimation." + animation.Index.ToString("d3") + ".Mold." + index.ToString("d2") + ".png");
        }
        // tileset contextmenustrip
        private void importIntoTilesetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap import = new Bitmap(1, 1); import = (Bitmap)Do.Import(import);
            if (import == null) return;
            if (import.Width != 128 || import.Height % 16 != 0 || import.Height > 256)
            {
                if (MessageBox.Show(
                    "The image does not have a width of 128 and a height a multiple of 16 and less than 256. " +
                    "It is recommended that an imported image possess these attributes for accuracy.\n\n" +
                    "Import into tileset anyways?", "LAZY SHELL",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                {
                    import.Dispose();
                    return;
                }
            }
            int height = Math.Min(256, import.Height / 16 * 16);
            int[] pixels = Do.ImageToPixels(import, new Size(128, height), new Rectangle(0, 0, 128, height));
            if (MessageBox.Show(
                "Would you like to create a new palette from the imported image?", "LAZY SHELL",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int[] palette = Do.ReduceColorDepth(pixels, 16, animation.PaletteSet.Palettes[effect.PaletteIndex][0]);
                for (int i = 0; i < palette.Length; i++)
                {
                    animation.PaletteSet.Reds[i + (effect.PaletteIndex * 16)] = Color.FromArgb(palette[i]).R;
                    animation.PaletteSet.Greens[i + (effect.PaletteIndex * 16)] = Color.FromArgb(palette[i]).G;
                    animation.PaletteSet.Blues[i + (effect.PaletteIndex * 16)] = Color.FromArgb(palette[i]).B;
                }
            }
            byte[] graphics = new byte[animation.Codec == 1 ? (byte)0x10 * 0x200 : (byte)0x20 * 0x200];
            byte[] tileset = new byte[animation.TileSet.Length * 2];
            Do.PixelsToBPP(
                pixels, graphics, new Size(16, height / 8),
                animation.PaletteSet.Palettes[effect.PaletteIndex],
                animation.Codec == 1 ? (byte)0x10 : (byte)0x20);
            if (Do.CopyToTileset(graphics, tileset, animation.PaletteSet.Palettes[effect.PaletteIndex],
                0, false, true, animation.Codec == 1 ? (byte)0x10 : (byte)0x20, 2, new Size(128, height), 0) >
                animation.GraphicSetLength)
                MessageBox.Show(
                    "Imported graphics exceed graphic set size. Increase the graphic set size to save all data.",
                    "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            import.Dispose();
            Buffer.BlockCopy(graphics, 0, animation.GraphicSet, 0, Math.Min(graphics.Length, animation.GraphicSet.Length));
            Buffer.BlockCopy(tileset, 0, animation.TileSet, 0, Math.Min(tileset.Length, animation.TileSet.Length));
            // redraw data
            animation.Tileset = new E_Tileset(animation, effect.PaletteIndex);
            // cull tileset
            if (MessageBox.Show("Would you like to redraw the current mold from the imported image?", "LAZY SHELL",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Do.CullTileset(this.tileset.Tileset, mold.Mold, 16, 16);
                Rectangle region = Do.Crop(mold.Mold, 8, 16, 0xFF);
                e_moldWidth.Value = region.Width;
                e_moldHeight.Value = region.Height;
            }
            else
                Do.CullTileset(this.tileset.Tileset);
            // set images
            //tileset.DrawTileset(animation.TileSet, tileset.Tileset);
            SetTilesetImage();
            SetTilemapImage();
            sequences.SetSequenceFrameImages();
            effectsEditor.LoadPaletteEditor();
            effectsEditor.LoadGraphicEditor();
        }
        private void saveImageAsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Do.Export(tilesetImage, "effectAnimation." + animation.Index.ToString("d2") + ".Tileset.png");
        }
        // editors
        private void openTileEditor_Click(object sender, EventArgs e)
        {
            tileEditor.Visible = true;
        }
        private void editor_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            ((Form)sender).Hide();
        }
        #endregion
    }
}