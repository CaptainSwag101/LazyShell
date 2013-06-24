using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Windows.Forms;
using LAZYSHELL.Undo;

namespace LAZYSHELL
{
    public partial class GraphicEditor : Form
    {
        #region Variables
        private Delegate update;
        private byte[] graphics;
        private byte[] graphicsBackup;
        private int offset = 0;
        private int length = 0;
        private int startRow;
        private int index;
        private Size size = new Size(16, 48);
        private int[] palette
        {
            get
            {
                return paletteSet.Palettes[currentPalette];
            }
        }
        private PaletteSet paletteSet;
        private byte format;
        private Overlay overlay;
        private int maxHeight
        {
            get
            {
                int length = this.length;
                if ((length / format) % 16 != 0)
                    length += format * 16;
                if (format == 0x10)
                    length &= 0xFFFF00;
                else
                    length &= 0xFFFE00;
                return length / format / 2;
            }
        }
        private Bitmap graphicsImage, paletteImage;
        // check variables
        private Drawing action;
        private int mouseOverSubtile;
        private string mouseOverControl;
        private string mouseOverObject;
        private string mouseDownObject;
        private bool mouseEnter = false;
        public Point mousePosition;
        public Point mouseDownPosition;
        private bool mouseWithinSameBounds = false;
        private Point autoScrollPos = new Point();
        private int currentPixel = 0;
        private int currentColor = 0;
        private int currentColorBack = 0;
        private int currentPalette = 0;
        private int zoom { get { return pictureBoxGraphicSet.Zoom; } set { pictureBoxGraphicSet.Zoom = value; } }
        private int width { get { return pictureBoxGraphicSet.Width; } set { pictureBoxGraphicSet.Width = value; } }
        private int height { get { return pictureBoxGraphicSet.Height; } set { pictureBoxGraphicSet.Height = value; } }
        private bool move = false;
        private bool defloating = false;
        private int drawSize = 1;
        private int eraseSize = 1;
        private int replaceSize = 1;
        private Bitmap selection;
        private CopyBuffer draggedColors;
        private CopyBuffer copiedColors;
        private int commandCount = 0;
        private byte[] original;
        private Rectangle hoverBox
        {
            get
            {
                int size = (int)brushSize.Value;
                int x = mousePosition.X - (size / 2); if (size % 2 == 0) x++;
                int y = mousePosition.Y - (size / 2); if (size % 2 == 0) y++;
                return new Rectangle(x * zoom, y * zoom, size * zoom, size * zoom);
            }
        }
        private CommandStack commandStack;
        #endregion
        // constructor
        /// <summary>
        /// Loads the BPP graphic editor.
        /// </summary>
        /// <param name="update">The function to run when updating graphics.</param>
        /// <param name="graphics">The graphics.</param>
        /// <param name="length">The length of the graphics that will be accessed.</param>
        /// <param name="offset">The offset of the graphics to access from.</param>
        /// <param name="paletteSet">The palette set to use with the graphics.</param>
        /// <param name="start">The index of the first palette in the set.</param>
        /// <param name="format">0x10 or 0x20, 2bpp or 4bpp, respectively.</param>
        /// <param name="sender">The sender's name.</param>
        public GraphicEditor(Delegate update, byte[] graphics, int length, int offset, PaletteSet paletteSet, int start, byte format)
        {
            InitializeGraphicEditor(update, graphics, length, offset, paletteSet, start, format);
        }
        public GraphicEditor(Delegate update, byte[] graphics, int length, int offset, PaletteSet paletteSet, int start, byte format, int index)
        {
            this.index = index;
            InitializeGraphicEditor(update, graphics, length, offset, paletteSet, start, format);
        }
        public void Reload(Delegate update, byte[] graphics, int length, int offset, PaletteSet paletteSet, int start, byte format)
        {
            this.KeyPreview = true;
            this.update = update;
            this.offset = offset;
            this.length = length;
            this.startRow = start;
            this.currentPalette = start;
            if (!Bits.Compare(graphics, graphicsBackup))
            {
                graphicsBackup = new byte[graphics.Length];
                graphics.CopyTo(graphicsBackup, 0);
            }
            this.graphics = graphics;
            this.paletteSet = paletteSet;
            this.format = format;
            this.overlay = new Overlay();
            this.commandStack = new CommandStack(true);

            panel110.Height = paletteSet.Palettes.Length * 8 + 4 - (start * 8);
            pictureBoxPalette.Height = paletteSet.Palettes.Length * 8 - (start * 8);
            this.height = maxHeight * zoom;
            panel110.Focus();
            size.Width = this.width / zoom / 8;
            size.Height = this.height / zoom / 8;

            SetCoordsLabel();

            SetGraphicSetImage();
            SetPaletteImage();
            pictureBoxColor.Invalidate();
            pictureBoxColorBack.Invalidate();
            this.BringToFront();
        }
        public void Reload(Delegate update, byte[] graphics, int length, int offset, PaletteSet paletteSet, int start, byte format, int index)
        {
            this.index = index;
            Reload(update, graphics, length, offset, paletteSet, start, format);
        }
        #region Functions
        private void InitializeGraphicEditor(Delegate update, byte[] graphics, int length, int offset, PaletteSet paletteSet, int startRow, byte format)
        {
            this.KeyPreview = true;
            this.update = update;
            this.offset = offset;
            this.length = length;
            this.startRow = startRow;
            this.currentPalette = startRow;
            this.graphics = graphics;
            this.graphicsBackup = new byte[graphics.Length];
            graphics.CopyTo(graphicsBackup, 0);
            this.paletteSet = paletteSet;
            this.format = format;
            this.overlay = new Overlay();
            this.commandStack = new CommandStack(true);

            InitializeComponent();

            panel110.Height = paletteSet.Palettes.Length * 8 + 4 - (startRow * 8);
            pictureBoxPalette.Height = paletteSet.Palettes.Length * 8 - (startRow * 8);
            this.height = maxHeight * zoom;
            panel110.Focus();
            size.Width = this.width / zoom / 8;
            size.Height = this.height / zoom / 8;

            coordsLabel.Text = size.Width.ToString() + "x" + size.Height.ToString();

            SetGraphicSetImage();
            SetPaletteImage();
            pictureBoxColor.Invalidate();
            pictureBoxColorBack.Invalidate();
            this.BringToFront();
            Do.AddShortcut(toolStrip2, Keys.F1, helpTips);
            new ToolTipLabel(this, null, helpTips);
            new History(this);
        }
        private void SetGraphicSetImage()
        {
            int[] palette;
            if (format == 0x10)
            {
                palette = new int[16];
                int index = currentColor / 4 * 4;
                for (int i = 0; i < 4; i++)
                    palette[i] = paletteSet.Palettes[currentPalette / 4][((currentPalette % 4) * 4) + i + index];
            }
            else
                palette = this.palette;

            int[] pixels = Do.GetPixelRegion(graphics, format, palette, size.Width, 0, 0, size.Width, size.Height, this.offset);
            graphicsImage = new Bitmap(Do.PixelsToImage(pixels, size.Width * 8, size.Height * 8));
            pictureBoxGraphicSet.Invalidate();
        }
        private void SetPaletteImage()
        {
            int[] palettePixels = Do.PaletteToPixels(paletteSet.Palettes, 8, 8, 16, paletteSet.Palettes.Length, startRow, 1);
            paletteImage = new Bitmap(Do.PixelsToImage(palettePixels, 128, paletteSet.Palettes.Length * 8 - (startRow * 8)));
            pictureBoxPalette.Invalidate();
        }
        private void SetSelectionImage(CopyBuffer buffer)
        {
            if (buffer == null)
                return;
            int[] pixels = Do.ColorsToPixels(buffer.Copy, this.palette);
            selection = Do.PixelsToImage(pixels, buffer.Width, buffer.Height);
        }
        private void SetCoordsLabel()
        {
            sizeLabel.Text = "Size: " + size.Width.ToString() + "x" + size.Height.ToString();
            if (mouseEnter)
            {
                coordsLabel.Text = "Subtile index: " + (mouseOverSubtile + index).ToString("d4") + " | ";
                coordsLabel.Text += "(x: " + mousePosition.X / 8 + ", y: " + mousePosition.Y / 8 + ") Subtile | ";
                coordsLabel.Text += "(x: " + mousePosition.X + ", y: " + mousePosition.Y + ") Pixel";
            }
            else
                coordsLabel.Text = "";
        }
        //
        private void Draw(Graphics g, int x, int y, int color, int colorBack)
        {
            for (int Y = hoverBox.Y / zoom; Y < hoverBox.Bottom / zoom; Y++)
            {
                for (int X = hoverBox.X / zoom; X < hoverBox.Right / zoom; X++)
                    color = Do.EditPixelBPP(
                        graphics, this.offset, paletteSet.Palettes[currentPalette], g, zoom, action,
                        X * zoom, Y * zoom, 0, color, colorBack, size.Width, size.Height, format);
            }
        }
        private void Drag()
        {
            if (overlay.Select == null || overlay.Select.Size == new Size(0, 0))
                return;
            int[] buffer = new int[overlay.Select.Width * overlay.Select.Height];
            for (int y = overlay.Select.Y, i = 0; y < overlay.Select.Terminal.Y; y++)
            {
                for (int x = overlay.Select.X; x < overlay.Select.Terminal.X; x++)
                    buffer[i++] = Do.GetBPPColor(graphics, x, y, this.offset, 0, 1, format, size.Width);
            }
            draggedColors = new CopyBuffer(overlay.Select.Width, overlay.Select.Height, buffer);
            SetSelectionImage(draggedColors);
            Delete();
        }
        private void Cut()
        {
            if (overlay.Select == null || overlay.Select.Size == new Size(0, 0)) return;
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
            if (overlay.Select == null)
                return;
            int[] buffer = new int[overlay.Select.Width * overlay.Select.Height];
            for (int y = overlay.Select.Y, i = 0; y < overlay.Select.Terminal.Y; y++)
            {
                for (int x = overlay.Select.X; x < overlay.Select.Terminal.X; x++)
                    buffer[i++] = Do.GetBPPColor(graphics, x, y, this.offset, 0, 1, format, size.Width);
            }
            copiedColors = new CopyBuffer(overlay.Select.Width, overlay.Select.Height, buffer);
            SetSelectionImage(copiedColors);
        }
        private void Paste(Point location)
        {
            if (copiedColors == null) return;
            move = true;
            // now dragging a new selection
            overlay.Select = new Overlay.Selection(1, location, copiedColors.Size);
            pictureBoxGraphicSet.Invalidate();
            defloating = false;
        }
        /// <summary>
        /// Defloats either a dragged selection or a newly pasted selection.
        /// </summary>
        /// <param name="buffer">The dragged selection or the newly pasted selection.</param>
        private void Defloat(CopyBuffer buffer)
        {
            if (buffer == null) return;
            if (overlay.Select == null) return;
            original = Bits.Copy(graphics);
            for (int y = overlay.Select.Y, i = 0; y < overlay.Select.Terminal.Y; y++)
            {
                for (int x = overlay.Select.X; x < overlay.Select.Terminal.X; x++)
                {
                    int color = buffer.Copy[i++];
                    if (color == 0) continue;
                    Do.EditPixelBPP(
                        graphics, this.offset, paletteSet.Palettes[currentPalette], null, zoom,
                        Drawing.Draw, x * zoom, y * zoom, 0, color, 0, size.Width, size.Height, format);
                }
            }
            commandStack.Push(new GraphicEdit(original, graphics));
            commandStack.Push(commandCount + 1);
            commandCount = 0;
            //
            defloating = true;
            SetGraphicSetImage();
            if (autoUpdate.Checked)
                update.DynamicInvoke();
            this.Activate();
        }
        private void Defloat()
        {
            if (copiedColors != null && !defloating)
                Defloat(copiedColors);
            if (draggedColors != null)
            {
                Defloat(draggedColors);
                draggedColors = null;
            }
            move = false;
            overlay.Select = null;
        }
        private void Delete()
        {
            original = Bits.Copy(graphics);
            for (int y = overlay.Select.Y; y < overlay.Select.Terminal.Y; y++)
            {
                for (int x = overlay.Select.X; x < overlay.Select.Terminal.X; x++)
                    Do.EditPixelBPP(
                        graphics, this.offset, paletteSet.Palettes[currentPalette], null, 1,
                        Drawing.Erase, x, y, 0, 0, 0, size.Width, size.Height, format);
            }
            commandStack.Push(new GraphicEdit(original, graphics));
            commandCount++;
            //
            SetGraphicSetImage();
            if (autoUpdate.Checked)
                update.DynamicInvoke();
            this.Activate();
        }
        private void Flip(string type)
        {
            original = Bits.Copy(graphics);
            if (type == "mirror")
                Do.FlipHorizontal(graphics, size.Width, overlay.Select.X, overlay.Select.Y, overlay.Select.Width, overlay.Select.Height, 1, format);
            else if (type == "invert")
                Do.FlipVertical(graphics, size.Width, overlay.Select.X, overlay.Select.Y, overlay.Select.Width, overlay.Select.Height, 1, format);
            commandStack.Push(new GraphicEdit(original, graphics));
            commandStack.Push(1);
            //
            SetGraphicSetImage();
            if (autoUpdate.Checked)
                update.DynamicInvoke();
            this.Activate();
        }
        //
        #endregion
        #region Event handlers
        // picture boxes
        private void pictureBoxPalette_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; showBG.Checked && i < paletteSet.Palettes.Length - startRow; i++)
            {
                Brush brush = new SolidBrush(Color.FromArgb(paletteSet.Palettes[i + startRow][0]));
                e.Graphics.FillRectangle(brush, new Rectangle(0, i * 8, pictureBoxPalette.Width, 8));
            }
            if (paletteImage != null)
                e.Graphics.DrawImage(paletteImage, 0, 0);
            Point p = new Point(currentColor * 8, currentPalette * 8 - (startRow * 8));
            e.Graphics.DrawRectangle(new Pen(Color.Red), new Rectangle(p.X, p.Y, 7, 7));
        }
        private void pictureBoxPalette_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBoxPalette.Focus();
            int temp = currentPalette;
            currentPalette = e.Y / 8 + startRow;
            if (e.Button == MouseButtons.Left)
                currentColor = e.X / 8;
            else if (e.Button == MouseButtons.Right)
                currentColorBack = e.X / 8;
            pictureBoxPalette.Invalidate();
            pictureBoxColor.Invalidate();
            pictureBoxColorBack.Invalidate();
            SetGraphicSetImage();
            if (temp != currentPalette)
                SetSelectionImage(copiedColors);
        }
        private void pictureBoxGraphicSet_Paint(object sender, PaintEventArgs e)
        {
            if (graphicsImage == null) return;

            Rectangle rsrc = new Rectangle(0, 0, graphicsImage.Width, graphicsImage.Height);
            Rectangle rdst = new Rectangle(0, 0, graphicsImage.Width * zoom, graphicsImage.Height * zoom);
            e.Graphics.PixelOffsetMode = PixelOffsetMode.Half;
            e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
            //
            if (showBG.Checked)
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(this.palette[0])), e.ClipRectangle);
            // only paint area if not erasing it, or the zoom box has moved over it
            if (action != Drawing.Erase && !Do.WithinBounds(this.hoverBox, e.ClipRectangle))
                e.Graphics.DrawImage(graphicsImage, rdst, rsrc, GraphicsUnit.Pixel);
            else if (e.ClipRectangle == Do.GetVisibleBounds(pictureBoxGraphicSet))
                e.Graphics.DrawImage(graphicsImage, rdst, rsrc, GraphicsUnit.Pixel);
            //
            Size s = new Size(graphicsImage.Width * zoom, graphicsImage.Height * zoom);
            if (zoom >= 4 && graphicShowPixelGrid.Checked)
                overlay.DrawCartesianGrid(e.Graphics, Color.DarkRed, s, new Size(1, 1), zoom, false);
            if (graphicShowGrid.Checked)
                overlay.DrawCartesianGrid(e.Graphics, Color.Gray, s, new Size(8, 8), zoom, true);
            //
            if (move && selection != null && overlay.Select != null)
            {
                Rectangle src = new Rectangle(0, 0, overlay.Select.Width, overlay.Select.Height);
                Rectangle dst = new Rectangle(
                    overlay.Select.X * zoom, overlay.Select.Y * zoom,
                    src.Width * zoom, src.Height * zoom);
                e.Graphics.DrawImage(new Bitmap(selection), dst, src, GraphicsUnit.Pixel);
                Do.DrawString(e.Graphics, new Point(dst.X, dst.Y + dst.Height),
                    "click/drag", Color.White, Color.Black, new Font("Tahoma", 6.75F, FontStyle.Bold));
            }
            if (subtileSelect.Checked)
            {
                if (overlay.Select != null)
                {
                    e.Graphics.PixelOffsetMode = PixelOffsetMode.Default;
                    if (graphicShowPixelGrid.Checked && zoom >= 4)
                        overlay.DrawSelectionBox(e.Graphics, overlay.Select.Terminal, overlay.Select.Location, zoom, Color.Yellow);
                    else
                        overlay.DrawSelectionBox(e.Graphics, overlay.Select.Terminal, overlay.Select.Location, zoom);
                    e.Graphics.PixelOffsetMode = PixelOffsetMode.Half;
                }
            }
            //
            e.Graphics.PixelOffsetMode = PixelOffsetMode.Default;
            if (!subtileSelect.Checked && !graphicZoomIn.Checked && !graphicZoomOut.Checked && this.hoverBox.Width > 2 && mouseEnter)
            {
                Rectangle hoverBox = this.hoverBox;
                if (!subtileErase.Checked && !subtileDraw.Checked && !subtileReplaceColor.Checked)
                {
                    int x = mousePosition.X * zoom;
                    int y = mousePosition.Y * zoom;
                    hoverBox = new Rectangle(x, y, zoom, zoom);
                }
                if (action != Drawing.ReplaceColor && action != Drawing.Erase &&
                    e.ClipRectangle == Do.GetVisibleBounds(pictureBoxGraphicSet))
                    overlay.DrawHoverBox(e.Graphics, hoverBox.Location, hoverBox.Size, 1, false);
            }
        }
        private void pictureBoxGraphicSet_MouseDown(object sender, MouseEventArgs e)
        {
            int x = Math.Max(0, Math.Min(e.X / zoom, this.width / zoom));
            int y = Math.Max(0, Math.Min(e.Y / zoom, this.height / zoom));
            mouseDownPosition = new Point(-1, -1);
            mouseDownObject = null;
            // if moving an object and outside of it, paste it
            if (move && mouseOverObject != "selection")
            {
                // if copied tiles were pasted and not dragging a non-copied selection
                if (copiedColors != null && draggedColors == null)
                    Defloat(copiedColors);
                if (draggedColors != null)
                {
                    Defloat(draggedColors);
                    draggedColors = null;
                }
                move = false;
            }
            //
            if ((graphicZoomIn.Checked && e.Button == MouseButtons.Left) ||
                (graphicZoomOut.Checked && e.Button == MouseButtons.Right))
            {
                pictureBoxGraphicSet.ZoomIn(e.X, e.Y);
                return;
            }
            else if ((graphicZoomOut.Checked && e.Button == MouseButtons.Left) ||
                (graphicZoomIn.Checked && e.Button == MouseButtons.Right))
            {
                pictureBoxGraphicSet.ZoomOut(e.X, e.Y);
                return;
            }
            //
            original = Bits.Copy(graphics);
            int color = currentColor;
            int colorBack = currentColorBack;
            if (e.Button == MouseButtons.Right)
            {
                color = currentColorBack;
                colorBack = currentColor;
            }
            action = Drawing.None;
            if (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right)
            {
                if (Control.ModifierKeys == Keys.Control)
                    action = Drawing.Dropper;
                else if (subtileDraw.Checked)
                    action = color != 0 ? Drawing.Draw : Drawing.Erase;
                else if (subtileErase.Checked)
                    action = Drawing.Erase;
                else if (subtileDropper.Checked)
                    action = Drawing.Dropper;
                else if (subtileReplaceColor.Checked)
                    action = Drawing.ReplaceColor;
                else if (subtileFill.Checked)
                    action = contiguous.Checked ? Drawing.Fill : Drawing.FillAll;
                else if (subtileSelect.Checked)
                {
                    action = Drawing.Select;
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
                    }
                    return;
                }
                if (action == Drawing.Draw || action == Drawing.Erase || action == Drawing.Fill ||
                    action == Drawing.FillAll || action == Drawing.ReplaceColor)
                    commandCount++;
            }
            //
            pictureBoxGraphicSet.CallMouseMove(e);
        }
        private void pictureBoxGraphicSet_MouseMove(object sender, MouseEventArgs e)
        {
            int x = e.X; int y = e.Y;
            mouseWithinSameBounds = mousePosition == new Point(x, y);
            mouseOverControl = pictureBoxGraphicSet.Name;
            mouseOverSubtile = (y / (8 * zoom)) * size.Width + (x / (8 * zoom)); // Calculate tile number
            mousePosition = new Point(x / zoom, y / zoom);
            mouseOverObject = null;
            SetCoordsLabel();
            //
            int color = currentColor;
            int colorBack = currentColorBack;
            if (e.Button == MouseButtons.Right)
            {
                color = currentColorBack;
                colorBack = currentColor;
            }
            //
            Graphics g = pictureBoxGraphicSet.CreateGraphics();
            if (action == Drawing.Draw)
                Draw(g, x, y, color, colorBack);
            else if (action == Drawing.Erase)
            {
                Draw(g, x, y, color, colorBack);
                pictureBoxGraphicSet.Invalidate(hoverBox);
            }
            else if (action == Drawing.ReplaceColor)
                Draw(g, x, y, color, colorBack);
            else if (subtileSelect.Checked && overlay.Select != null)
            {
                // if making a new selection
                if (e.Button == MouseButtons.Left && mouseDownObject == null && overlay.Select != null)
                {
                    // cancel if within same bounds as last call
                    if (overlay.Select.Final == new Point(x, y))
                        return;
                    // otherwise, set the lower right edge of the selection
                    overlay.Select.Final = new Point(
                        Math.Max(0, Math.Min(e.X / zoom, this.width / zoom)),
                        Math.Max(0, Math.Min(e.Y / zoom, this.height / zoom)));
                }
                // if dragging the current selection
                else if (e.Button == MouseButtons.Left && mouseDownObject == "selection" && !mouseWithinSameBounds)
                    overlay.Select.Location = new Point((x / zoom) - mouseDownPosition.X, (y / zoom) - mouseDownPosition.Y);
                // if mouse not clicked and within the current selection
                else if (e.Button == MouseButtons.None && overlay.Select != null &&
                    overlay.Select.MouseWithin(x / zoom, y / zoom))
                {
                    mouseOverObject = "selection";
                    pictureBoxGraphicSet.Cursor = Cursors.SizeAll;
                }
                else
                    pictureBoxGraphicSet.Cursor = Cursors.Cross;
                pictureBoxGraphicSet.Invalidate();
                return;
            }
            else if (action == Drawing.Dropper)
            {
                color = Do.EditPixelBPP(
                    graphics, this.offset, paletteSet.Palettes[currentPalette], g, zoom,
                    action, x, y, 0, color, colorBack, size.Width, size.Height, format);
                if (e.Button == MouseButtons.Left)
                    currentColor = color;
                else if (e.Button == MouseButtons.Right)
                    currentColorBack = color;
            }
            else if (action == Drawing.None)
                pictureBoxGraphicSet.Invalidate();
            else
            {
                Do.EditPixelBPP(
                    graphics, this.offset, paletteSet.Palettes[currentPalette], g, zoom,
                    action, x, y, 0, color, colorBack, size.Width, size.Height, format);
            }
            //
            currentPixel = (x / zoom) + (y / zoom);
            pictureBoxPalette.Invalidate();
            pictureBoxColor.Invalidate();
            pictureBoxColorBack.Invalidate();
        }
        private void pictureBoxGraphicSet_MouseUp(object sender, MouseEventArgs e)
        {
            action = Drawing.None;
            pictureBoxGraphicSet.Invalidate();
            if (!subtileDraw.Checked && !subtileErase.Checked &&
                !subtileReplaceColor.Checked && !subtileFill.Checked) return;
            if (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right)
                SetGraphicSetImage();
            if (autoUpdate.Checked)
                update.DynamicInvoke();
            this.Activate();
            if (!move)
            {
                // params switched because changes are actually last instance
                this.commandStack.Push(new GraphicEdit(original, graphics));
                this.commandStack.Push(1);
            }
        }
        private void pictureBoxGraphicSet_MouseHover(object sender, EventArgs e)
        {
            pictureBoxGraphicSet.Invalidate();
        }
        private void pictureBoxGraphicSet_MouseEnter(object sender, EventArgs e)
        {
            mouseEnter = true;
            this.TopMost = false;
            pictureBoxGraphicSet.Focus();
            pictureBoxGraphicSet.Invalidate();
        }
        private void pictureBoxGraphicSet_MouseLeave(object sender, EventArgs e)
        {
            mouseEnter = false;
            this.TopMost = alwaysOnTop.Checked;
            SetCoordsLabel();
            pictureBoxGraphicSet.Focus();
            pictureBoxGraphicSet.Invalidate();
        }
        private void switchColors_MouseDown(object sender, MouseEventArgs e)
        {
            int currentColor = this.currentColor;
            this.currentColor = this.currentColorBack;
            this.currentColorBack = currentColor;
            pictureBoxColor.Invalidate();
            pictureBoxColorBack.Invalidate();
        }
        private void pictureBoxColor_Paint(object sender, PaintEventArgs e)
        {
            if (!showBG.Checked && currentColor == 0)
                return;
            int color = paletteSet.Palettes[currentPalette][currentColor];
            SolidBrush brush = new SolidBrush(Color.FromArgb(color));
            e.Graphics.FillRectangle(brush, new Rectangle(0, 0, 62, 62));
        }
        private void pictureBoxColorBack_Paint(object sender, PaintEventArgs e)
        {
            if (!showBG.Checked && currentColorBack == 0)
                return;
            int color = paletteSet.Palettes[currentPalette][currentColorBack];
            SolidBrush brush = new SolidBrush(Color.FromArgb(color));
            e.Graphics.FillRectangle(brush, new Rectangle(0, 0, 62, 62));
        }
        private void panelGraphicSet_Scroll(object sender, ScrollEventArgs e)
        {
            if ((Control.ModifierKeys & Keys.Control) != 0)
            {
                e.NewValue = e.OldValue;
                return;
            }
            autoScrollPos.X = Math.Abs(panelGraphicSet.AutoScrollPosition.X);
            autoScrollPos.Y = Math.Abs(panelGraphicSet.AutoScrollPosition.Y);
            pictureBoxGraphicSet.Invalidate();
            pictureBoxGraphicSet.Invalidate();
        }
        private void panelGraphicSet_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == (Keys.Shift | Keys.Left))
                widthDecrease.PerformClick();
            else if (e.KeyData == (Keys.Shift | Keys.Right))
                widthIncrease.PerformClick();
            else if (e.KeyData == (Keys.Shift | Keys.Up))
                heightDecrease.PerformClick();
            else if (e.KeyData == (Keys.Shift | Keys.Down))
                heightIncrease.PerformClick();
        }
        private void panelGraphicSet_MouseDown(object sender, MouseEventArgs e)
        {
            panel110.Focus();
        }
        // context menu items
        private void setSubtileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.gif,*.jpg,*.png)|*.gif;*.jpg;*.png|Binary files (*.bin)|*.bin|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 0;
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() != DialogResult.OK) return;

            byte[] graphics = new byte[0x6000];
            if (Path.GetExtension(openFileDialog.FileName) == ".jpg" ||
                Path.GetExtension(openFileDialog.FileName) == ".gif" ||
                Path.GetExtension(openFileDialog.FileName) == ".png")
            {
                Bitmap import = new Bitmap(Image.FromFile(openFileDialog.FileName));
                Do.PixelsToBPP(
                    Do.ImageToPixels(import, new Size(import.Width / 8 * 8, import.Height / 8 * 8)),
                    graphics, new Size(import.Width / 8, import.Height / 8), paletteSet.Palettes[currentPalette], format);
                Do.CopyOverBPPGraphics(graphics, this.graphics,
                    new Rectangle(mouseOverSubtile % 16, mouseOverSubtile / 16, import.Width / 8, import.Height / 8),
                    size.Width, this.offset, format);
            }
            else
            {
                FileStream fs = File.OpenRead(openFileDialog.FileName);
                BinaryReader br = new BinaryReader(fs);
                graphics = br.ReadBytes((int)fs.Length);
                Buffer.BlockCopy(graphics, 0, this.graphics,
                    this.offset + (mouseOverSubtile * format),
                    Math.Min(length - (mouseOverSubtile * format), this.graphics.Length - (mouseOverSubtile * format)));
                br.Close();
                fs.Close();
            }
            SetGraphicSetImage();
            if (autoUpdate.Checked)
                update.DynamicInvoke();
            this.Activate();
        }
        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Binary files (*.bin)|*.bin|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.FileName = "graphicSet.bin";
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() != DialogResult.OK)
                return;

            FileStream fs;
            BinaryWriter bw;
            try
            {
                // Create the file to store the level data
                fs = new FileStream(saveFileDialog.FileName + ".bin", FileMode.Create, FileAccess.ReadWrite);
                bw = new BinaryWriter(fs);
                bw.Write(graphics, this.offset, this.length);
                bw.Close();
                fs.Close();
            }
            catch
            {
                MessageBox.Show("There was a problem exporting the graphic block.", "LAZY SHELL");
            }
        }
        private void saveImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Image files (*.png)|*.png|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.FileName = "graphicSet.png";
            saveFileDialog.RestoreDirectory = true;
            if (saveFileDialog.ShowDialog() != DialogResult.OK) return;
            graphicsImage.Save(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Png);
        }
        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Array.Clear(graphics, 0, graphics.Length);
            SetGraphicSetImage();
            if (autoUpdate.Checked)
                update.DynamicInvoke();
            this.Activate();
        }
        // toolstrip buttons
        private void graphicZoomIn_Click(object sender, EventArgs e)
        {
            subtileDraw.Checked = false;
            subtileErase.Checked = false;
            subtileDropper.Checked = false;
            subtileFill.Checked = false;
            subtileSelect.Checked = false;
            graphicZoomOut.Checked = false;
            contiguous.Visible = false;
            brushSize.Visible = false;
            //
            if (graphicZoomIn.Checked)
                pictureBoxGraphicSet.Cursor = NewCursors.ZoomIn;
            else
                pictureBoxGraphicSet.Cursor = Cursors.Arrow;

            if (graphicZoomIn.Checked)
                pictureBoxGraphicSet.ContextMenuStrip = null;
            else
                pictureBoxGraphicSet.ContextMenuStrip = contextMenuStrip;
            Defloat();
            pictureBoxGraphicSet.Invalidate();
        }
        private void graphicZoomOut_Click(object sender, EventArgs e)
        {
            subtileDraw.Checked = false;
            subtileErase.Checked = false;
            subtileDropper.Checked = false;
            subtileFill.Checked = false;
            subtileSelect.Checked = false;
            graphicZoomIn.Checked = false;
            contiguous.Visible = false;
            brushSize.Visible = false;
            //
            if (graphicZoomOut.Checked)
                pictureBoxGraphicSet.Cursor = NewCursors.ZoomOut;
            else
                pictureBoxGraphicSet.Cursor = Cursors.Arrow;

            if (graphicZoomOut.Checked)
                pictureBoxGraphicSet.ContextMenuStrip = null;
            else
                pictureBoxGraphicSet.ContextMenuStrip = contextMenuStrip;
            Defloat();
            pictureBoxGraphicSet.Invalidate();
        }
        private void toggleZoomBox_Click(object sender, EventArgs e)
        {
            pictureBoxGraphicSet.ZoomBoxEnabled = toggleZoomBox.Checked;
        }
        private void graphicShowGrid_Click(object sender, EventArgs e)
        {
            pictureBoxGraphicSet.Invalidate();
        }
        private void graphicShowPixelGrid_Click(object sender, EventArgs e)
        {
            pictureBoxGraphicSet.Invalidate();
        }
        private void showBG_Click(object sender, EventArgs e)
        {
            pictureBoxGraphicSet.Invalidate();
            pictureBoxPalette.Invalidate();
            pictureBoxColor.Invalidate();
            pictureBoxColorBack.Invalidate();
        }
        private void widthDecrease_Click(object sender, EventArgs e)
        {
            if (size.Width == 1) return;
            size.Width--; this.width -= 8 * zoom;
            SetGraphicSetImage();
            SetCoordsLabel();
            Defloat();
            pictureBoxGraphicSet.Invalidate();
        }
        private void widthIncrease_Click(object sender, EventArgs e)
        {
            if (size.Width == 64) return;
            size.Width++; this.width += 8 * zoom;
            SetGraphicSetImage();
            SetCoordsLabel();
            Defloat();
            pictureBoxGraphicSet.Invalidate();
        }
        private void heightDecrease_Click(object sender, EventArgs e)
        {
            if (size.Height == 1) return;
            size.Height--; this.height -= 8 * zoom;
            SetGraphicSetImage();
            SetCoordsLabel();
            Defloat();
            pictureBoxGraphicSet.Invalidate();
        }
        private void heightIncrease_Click(object sender, EventArgs e)
        {
            if (size.Height == 256) return;
            size.Height++; this.height += 8 * zoom;
            SetGraphicSetImage();
            SetCoordsLabel();
            Defloat();
            pictureBoxGraphicSet.Invalidate();
        }
        private void brushSize_ValueChanged(object sender, EventArgs e)
        {
            if (subtileDraw.Checked)
                drawSize = (int)brushSize.Value;
            if (subtileErase.Checked)
                eraseSize = (int)brushSize.Value;
            if (subtileReplaceColor.Checked)
                replaceSize = (int)brushSize.Value;
        }
        // toolstrip drawing
        private void subtileDraw_Click(object sender, EventArgs e)
        {
            subtileErase.Checked = false;
            subtileDropper.Checked = false;
            subtileReplaceColor.Checked = false;
            subtileFill.Checked = false;
            subtileSelect.Checked = false;
            graphicZoomIn.Checked = false;
            graphicZoomOut.Checked = false;
            contiguous.Visible = false;
            brushSize.Visible = subtileDraw.Checked;
            //
            if (subtileDraw.Checked) brushSize.Value = drawSize;
            if (!subtileDraw.Checked)
                pictureBoxGraphicSet.Cursor = Cursors.Arrow;
            else
                pictureBoxGraphicSet.Cursor = NewCursors.Draw;
            Defloat();
            pictureBoxGraphicSet.Invalidate();
        }
        private void subtileErase_Click(object sender, EventArgs e)
        {
            subtileDraw.Checked = false;
            subtileDropper.Checked = false;
            subtileReplaceColor.Checked = false;
            subtileFill.Checked = false;
            subtileSelect.Checked = false;
            graphicZoomIn.Checked = false;
            graphicZoomOut.Checked = false;
            contiguous.Visible = false;
            brushSize.Visible = subtileErase.Checked;
            //
            if (subtileErase.Checked) brushSize.Value = eraseSize;
            if (!subtileErase.Checked)
                pictureBoxGraphicSet.Cursor = Cursors.Arrow;
            else
                pictureBoxGraphicSet.Cursor = NewCursors.Erase;
            Defloat();
            pictureBoxGraphicSet.Invalidate();
        }
        private void subtileDropper_Click(object sender, EventArgs e)
        {
            subtileDraw.Checked = false;
            subtileErase.Checked = false;
            subtileReplaceColor.Checked = false;
            subtileFill.Checked = false;
            subtileSelect.Checked = false;
            graphicZoomIn.Checked = false;
            graphicZoomOut.Checked = false;
            contiguous.Visible = false;
            brushSize.Visible = false;
            //
            if (!subtileDropper.Checked)
                pictureBoxGraphicSet.Cursor = Cursors.Arrow;
            else
                pictureBoxGraphicSet.Cursor = NewCursors.Dropper;
            Defloat();
            pictureBoxGraphicSet.Invalidate();
        }
        private void subtileReplaceColor_Click(object sender, EventArgs e)
        {
            subtileDraw.Checked = false;
            subtileErase.Checked = false;
            subtileDropper.Checked = false;
            subtileFill.Checked = false;
            subtileSelect.Checked = false;
            graphicZoomIn.Checked = false;
            graphicZoomOut.Checked = false;
            contiguous.Visible = false;
            brushSize.Visible = subtileReplaceColor.Checked;
            //
            if (subtileReplaceColor.Checked) brushSize.Value = replaceSize;
            if (!subtileReplaceColor.Checked)
                pictureBoxGraphicSet.Cursor = Cursors.Arrow;
            else
                pictureBoxGraphicSet.Cursor = NewCursors.Draw;
            Defloat();
            pictureBoxGraphicSet.Invalidate();
        }
        private void subtileFill_Click(object sender, EventArgs e)
        {
            subtileDraw.Checked = false;
            subtileErase.Checked = false;
            subtileDropper.Checked = false;
            subtileReplaceColor.Checked = false;
            subtileSelect.Checked = false;
            graphicZoomIn.Checked = false;
            graphicZoomOut.Checked = false;
            brushSize.Visible = false;
            contiguous.Visible = subtileFill.Checked;
            //
            if (!subtileFill.Checked)
                pictureBoxGraphicSet.Cursor = Cursors.Arrow;
            else
                pictureBoxGraphicSet.Cursor = NewCursors.Fill;
            Defloat();
            pictureBoxGraphicSet.Invalidate();
        }
        private void subtileSelect_Click(object sender, EventArgs e)
        {
            subtileDraw.Checked = false;
            subtileErase.Checked = false;
            subtileDropper.Checked = false;
            subtileReplaceColor.Checked = false;
            subtileFill.Checked = false;
            graphicZoomIn.Checked = false;
            graphicZoomOut.Checked = false;
            contiguous.Visible = subtileFill.Checked;
            brushSize.Visible = false;
            //
            if (!subtileSelect.Checked)
                pictureBoxGraphicSet.Cursor = Cursors.Arrow;
            else
                pictureBoxGraphicSet.Cursor = Cursors.Cross;
            Defloat();
            pictureBoxGraphicSet.Invalidate();
        }
        private void subtileCut_Click(object sender, EventArgs e)
        {
            Cut();
        }
        private void subtileCopy_Click(object sender, EventArgs e)
        {
            Copy();
        }
        private void subtilePaste_Click(object sender, EventArgs e)
        {
            int x = Math.Max(0, Math.Min(Math.Abs(panelGraphicSet.AutoScrollPosition.X) / zoom / 16 * 16, this.width - 1));
            int y = Math.Max(0, Math.Min(Math.Abs(panelGraphicSet.AutoScrollPosition.Y) / zoom / 16 * 16, this.height - 1));
            Paste(new Point(x + 24, y + 24));
        }
        private void subtileDelete_Click(object sender, EventArgs e)
        {
            if (!move)
                Delete();
            else
            {
                move = false;
                draggedColors = null;
                pictureBoxGraphicSet.Invalidate();
            }
            if (!move && commandCount > 0)
            {
                commandStack.Push(commandCount);
                commandCount = 0;
            }
        }
        private void mirror_Click(object sender, EventArgs e)
        {
            if (!move)
                Flip("mirror");
            else
            {
                move = false;
                draggedColors = null;
                pictureBoxGraphicSet.Invalidate();
            }
        }
        private void invert_Click(object sender, EventArgs e)
        {
            if (!move)
                Flip("invert");
            else
            {
                move = false;
                draggedColors = null;
                pictureBoxGraphicSet.Invalidate();
            }
        }
        private void undo_Click(object sender, EventArgs e)
        {
            commandStack.UndoCommand();
            SetGraphicSetImage();
            if (autoUpdate.Checked)
                update.DynamicInvoke();
            this.Activate();
        }
        private void redo_Click(object sender, EventArgs e)
        {
            commandStack.RedoCommand();
            SetGraphicSetImage();
            if (autoUpdate.Checked)
                update.DynamicInvoke();
            this.Activate();
        }
        //
        private void brushSize_VisibleChanged(object sender, EventArgs e)
        {
            toolStripSeparator33.Visible = brushSize.Visible;
            toolStripLabel1.Visible = brushSize.Visible;
        }
        private void contiguous_VisibleChanged(object sender, EventArgs e)
        {
            toolStripSeparator33.Visible = contiguous.Visible;
        }
        private void contextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Control ||
                subtileDraw.Checked || subtileErase.Checked ||
                subtileDropper.Checked || subtileReplaceColor.Checked ||
                graphicZoomIn.Checked || graphicZoomOut.Checked)
                e.Cancel = true;
        }
        // closing/saving
        private void GraphicEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            buttonReset.PerformClick();
        }
        private void GraphicEditor_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Z: toggleZoomBox.PerformClick(); break;
                case Keys.T: graphicShowPixelGrid.PerformClick(); break;
                case Keys.G: graphicShowGrid.PerformClick(); break;
                case Keys.B: showBG.PerformClick(); break;
                case Keys.D: subtileDraw.PerformClick(); break;
                case Keys.E: subtileErase.PerformClick(); break;
                case Keys.S: subtileSelect.PerformClick(); break;
                case Keys.P: subtileDropper.PerformClick(); break;
                case Keys.R: subtileReplaceColor.PerformClick(); break;
                case Keys.F: subtileFill.PerformClick(); break;
                case Keys.Control | Keys.X: Cut(); break;
                case Keys.Control | Keys.C: Copy(); break;
                case Keys.Control | Keys.V: subtilePaste.PerformClick(); break;
                case Keys.Delete: subtileDelete.PerformClick(); break;
                case Keys.Control | Keys.D: Defloat(); pictureBoxGraphicSet.Invalidate(); break;
                case Keys.Control | Keys.Z: undo.PerformClick(); break;
                case Keys.Control | Keys.Y: redo.PerformClick(); break;
            }
        }
        private void buttonOK_Click(object sender, EventArgs e)
        {
            graphics.CopyTo(graphicsBackup, 0);
            this.Close();
            if (!autoUpdate.Checked)
                update.DynamicInvoke();
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void buttonReset_Click(object sender, EventArgs e)
        {
            commandStack.Clear();
            graphicsBackup.CopyTo(graphics, 0);
            if (autoUpdate.Checked)
                update.DynamicInvoke();
            SetGraphicSetImage();
            this.Activate();
        }
        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            update.DynamicInvoke();
        }
        private void alwaysOnTop_CheckedChanged(object sender, EventArgs e)
        {
            this.TopMost = alwaysOnTop.Checked;
        }
        #endregion
    }
}
