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
using LazyShell.Undo;

namespace LazyShell
{
    public partial class GraphicEditor : Controls.NewForm
    {
        #region Variables

        // Updating
        private GraphicUpdater updater;
        private Form targetForm
        {
            get { return this.Owner; }
            set { this.Owner = value; }
        }

        // Buffers
        private byte[] graphics;
        private byte[] graphicsBackup;
        public byte[] Graphics
        {
            get { return graphics; }
            set { graphics = value; }
        }
        public byte[] GraphicsBackup
        {
            get { return graphicsBackup; }
            set { graphicsBackup = value; }
        }
        private byte[] original;

        // Elements
        private Fonts.Glyph glyph;

        // Palette
        private int[] palette
        {
            get { return paletteSet.Palettes[currentPalette]; }
        }
        private PaletteSet paletteSet;
        private int startRow;
        /// <summary>
        /// Always 0, unless font triangle.
        /// </summary>
        private int startCol = 0;

        // Forms
        private int offset = 0;
        private int length = 0;
        private Color bgcolor
        {
            get { return Color.FromArgb(this.palette[0]); }
        }

        // Graphics
        private byte format;
        /// <summary>
        /// Current size, in 8x8 subtiles, of the graphics image.
        /// </summary>
        private Size size = new Size(16, 48);
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

        // Images
        private Bitmap graphicsImage;
        private Bitmap paletteImage;

        // Color editing
        private EditMode action;
        private int commandCount = 0;
        private UndoStack commandStack;
        private int drawSize = 1;
        private int eraseSize = 1;
        private int replaceSize = 1;

        // Mouse behavior
        private int mouseOverSubtile;
        private string mouseOverControl;
        private string mouseOverObject;
        private string mouseDownObject;
        private bool mouseEnter = false;
        public Point mousePosition;
        public Point mouseDownPosition;
        private bool mouseWithinSameBounds = false;
        private Point autoScrollPos = new Point();

        // Current indexes
        private int index;
        private int currentPixel = 0;
        private int currentColor = 0;
        private int currentColorBack = 0;
        private int currentPalette = 0;

        // Picture
        private int zoom
        {
            get { return pictureBoxGraphicSet.Zoom; }
            set { pictureBoxGraphicSet.Zoom = value; }
        }
        private int width
        {
            get { return pictureBoxGraphicSet.Width; }
            set { pictureBoxGraphicSet.Width = value; }
        }
        private int height
        {
            get { return pictureBoxGraphicSet.Height; }
            set { pictureBoxGraphicSet.Height = value; }
        }
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
        private Overlay overlay;

        // Selection editing
        private bool moving = false;
        private bool defloating = false;
        private Bitmap selection;
        private CopyBuffer draggedColors;
        private CopyBuffer copiedColors;

        #endregion

        // Constructors
        /// <summary>
        /// Loads the BPP graphic editor.
        /// </summary>
        /// <param name="updater">The function to run when updating graphics.</param>
        /// <param name="graphics">The graphics.</param>
        /// <param name="length">The length of the graphics that will be accessed.</param>
        /// <param name="offset">The offset of the graphics to access from.</param>
        /// <param name="paletteSet">The palette set to use with the graphics.</param>
        /// <param name="startRow">The index of the first palette in the set.</param>
        /// <param name="format">0x10 or 0x20, 2bpp or 4bpp, respectively.</param>
        /// <param name="sender">The sender's name.</param>
        public GraphicEditor(GraphicUpdater updater, byte[] graphics, int length, int offset, PaletteSet paletteSet, int startRow, byte format)
        {
            Initialize(updater, graphics, length, offset, paletteSet, startRow, format);
        }
        public GraphicEditor(GraphicUpdater updater, byte[] graphics, int length, int offset, PaletteSet paletteSet, int startRow, byte format, int index)
        {
            this.index = index;
            Initialize(updater, graphics, length, offset, paletteSet, startRow, format);
        }
        public GraphicEditor(GraphicUpdater updater, Fonts.Glyph character, PaletteSet paletteSet, int startRow, int startCol, byte format)
        {
            Initialize(updater, character, paletteSet, startRow, startCol, format);
        }
        private void Initialize(GraphicUpdater updater, byte[] graphics, int length, int offset, PaletteSet paletteSet, int startRow, byte format)
        {
            this.KeyPreview = true;
            this.updater = updater;
            this.offset = offset;
            this.length = length;
            this.startRow = startRow;
            this.currentPalette = startRow;
            this.graphics = graphics;
            this.graphicsBackup = Bits.Copy(graphics);
            this.paletteSet = paletteSet;
            this.format = format;

            //
            InitializeVariables();
            InitializeComponent();

            //
            ResizePalettes();
            SetCoordsLabel();
            SetGraphicSetImage();
            SetPaletteImage();
            InvalidateColors();

            //
            this.BringToFront();

            //
            this.History = new History(this);
        }
        private void Initialize(GraphicUpdater updater, Fonts.Glyph character, PaletteSet paletteSet, int startRow, int startCol, byte format)
        {
            this.KeyPreview = true;
            this.updater = updater;
            this.startRow = startRow;
            this.startCol = startCol;
            this.currentPalette = startRow;
            this.glyph = character;
            this.graphics = character.Graphics;
            this.graphicsBackup = Bits.Copy(this.graphics);
            this.paletteSet = paletteSet;
            this.format = format;

            //
            InitializeVariables();
            InitializeComponent();
            CreateHelperForms();
            CreateShortcuts();
            //
            ResizePalettes();
            //
            SetCoordsLabel();
            SetGraphicSetImage();
            SetPaletteImage();
            InvalidateColors();

            //
            this.BringToFront();

            //
            this.History = new History(this);
        }
        public void Reload(byte[] graphics, int length, int offset, PaletteSet paletteSet, int startRow, byte format)
        {
            this.KeyPreview = true;
            this.offset = offset;
            this.length = length;
            this.startRow = startRow;
            this.currentPalette = startRow;
            if (!Bits.Compare(graphics, graphicsBackup))
                graphicsBackup = Bits.Copy(graphics);
            this.graphics = graphics;
            this.paletteSet = paletteSet;
            this.format = format;

            //
            InitializeVariables();
            ResizePalettes();
            SetCoordsLabel();
            SetGraphicSetImage();
            SetPaletteImage();
            InvalidateColors();

            //
            this.BringToFront();
        }
        public void Reload(byte[] graphics, int length, int offset, PaletteSet paletteSet, int startRow, byte format, int index)
        {
            this.index = index;
            Reload(graphics, length, offset, paletteSet, startRow, format);
        }
        public void Reload(Fonts.Glyph glyph, PaletteSet paletteSet, int startRow, int startCol, byte format)
        {
            this.KeyPreview = true;
            this.startRow = startRow;
            this.startCol = startCol;
            this.currentPalette = startRow;
            if (!Bits.Compare(glyph.Graphics, graphicsBackup))
                graphicsBackup = Bits.Copy(glyph.Graphics);
            this.glyph = glyph;
            this.graphics = glyph.Graphics;
            this.paletteSet = paletteSet;
            this.format = format;

            //
            InitializeVariables();
            ResizePalettes();
            //
            SetCoordsLabel();
            SetGraphicSetImage();
            SetPaletteImage();
            InvalidateColors();

            //
            this.BringToFront();
        }

        #region Methods

        // Initialization
        private void InitializeVariables()
        {
            this.overlay = new Overlay();
            this.commandStack = new UndoStack(true);
        }
        private void CreateHelperForms()
        {
            new ToolTipLabel(this, null, helpTips);
        }
        private void CreateShortcuts()
        {
            Do.AddShortcut(toolStrip2, Keys.F1, helpTips);
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

        // Control sizing
        private void ResizePalettes()
        {
            pictureBoxPalette.Left = 0 - (startCol * 12);
            pictureBoxPalette.Height = paletteSet.Palettes.Length * 12 - (startRow * 12);
            panelPaletteSet.Height = pictureBoxPalette.Height + 4;
            panelPaletteSet.Width = format == 0x10 ? 4 * 12 + 4 : 16 * 12 + 4;

            // Default
            if (glyph == null)
            {
                this.height = maxHeight * zoom;
                panelPaletteSet.Focus();
                size.Width = this.width / zoom / 8;
                size.Height = this.height / zoom / 8;
            }
            // Font glyphs
            else
            {
                if (currentColor < startCol || currentColor >= startCol + 4)
                    currentColor = startCol;
                if (currentColorBack < startCol || currentColorBack >= startCol + 4)
                    currentColorBack = startCol;
                //
                panelPaletteSet.Focus();
                //
                pictureBoxColor.Width = pictureBoxColor.Height = 12;
                pictureBoxColorBack.Width = pictureBoxColorBack.Height = 12;
                panelColor.Left = panelPaletteSet.Right + 10;
                panelColor.Width = panelColor.Height = 16;
                panelColorBack.Width = panelColorBack.Height = 16;
                switchColors.Top = panelColor.Top + panelColor.Height;
                switchColors.Left = panelColor.Left;
                panelColorBack.Left = switchColors.Right + 2;
                panelColorBack.Top = switchColors.Bottom - panelColorBack.Height;
                panelPalettes.Height = panelColorBack.Bottom + 4;
                alwaysOnTop.Visible = false;
            }
        }
        /// <summary>
        /// Docks the graphic editor into a panel.
        /// </summary>
        /// <param name="panel">The panel to dock to.</param>
        /// <param name="showPalette">Show the palette swatch.</param>
        /// <param name="showButtons">Show the buttons at the bottom.</param>
        public void DockToPanel(Panel panel, bool showPalette, bool showButtons)
        {
            panelPalettes.Dock = DockStyle.Top;
            panelGraphics.Dock = DockStyle.Fill;
            panelLabels.Dock = DockStyle.Bottom;
            panelButtons.Dock = DockStyle.Bottom;
            panelPalettes.BringToFront();
            panelLabels.BringToFront();
            panelButtons.BringToFront();
            panelGraphics.BringToFront();
            if (!showPalette)
                panelPalettes.Hide();
            if (!showButtons)
                panelButtons.Hide();
            this.ControlBox = false;
            this.Dock = DockStyle.Fill;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.Text = "";
            this.TopLevel = false;
            this.TopMost = false;
            panel.Controls.Add(this);
            this.Show();
        }
        /// <summary>
        /// Sets a fixed size for the graphics image.
        /// </summary>
        /// <param name="width">The width, in pixels, of the graphics image.</param>
        /// <param name="height">The height, in pixels, of the graphics image.</param>
        /// <param name="tileWidth">The width, in 8x8 tiles, of the graphics.</param>
        /// <param name="tileHeight">The height, in 8x8 tiles, of the graphics.</param>
        public void SetControlSizes(int width, int height, int tileWidth, int tileHeight)
        {
            size.Width = tileWidth;
            size.Height = tileHeight;
            this.width = width * zoom;
            this.height = height * zoom;
            //
            toolStripSeparator4.Visible = false;
            widthIncrease.Visible = false;
            widthDecrease.Visible = false;
            heightIncrease.Visible = false;
            heightDecrease.Visible = false;
        }

        // Set images
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
            int[] pixels;
            if (glyph == null)
            {
                pixels = Do.GetPixelRegion(graphics, format, palette, size.Width, 0, 0, size.Width, size.Height, this.offset);
                graphicsImage = Do.PixelsToImage(pixels, size.Width * 8, size.Height * 8);
            }
            else
            {
                pixels = glyph.GetPixels(paletteSet.Palettes[currentPalette]);
                graphicsImage = Do.PixelsToImage(pixels, glyph.MaxWidth, glyph.Height);
            }
            pictureBoxGraphicSet.Invalidate();
        }
        private void SetPaletteImage()
        {
            int[] palettePixels = Do.PaletteToPixels(paletteSet.Palettes, 12, 12, 16, paletteSet.Palettes.Length, startRow, startCol + 1);
            paletteImage = Do.PixelsToImage(palettePixels, 192, paletteSet.Palettes.Length * 12 - (startRow * 12));
            pictureBoxPalette.Invalidate();
        }
        private void SetSelectionImage(CopyBuffer buffer)
        {
            if (buffer == null)
                return;
            int[] pixels;
            if (glyph == null)
                pixels = Do.ColorsToPixels(buffer.Copy, this.palette);
            else
            {
                if (glyph.Type != FontType.Triangles)
                    pixels = Do.ColorsToPixels(buffer.Copy, paletteSet.Palettes[currentPalette]);
                else
                    pixels = Do.ColorsToPixels(buffer.Copy, paletteSet.Palettes[currentPalette], 4);
            }
            selection = Do.PixelsToImage(pixels, buffer.Width, buffer.Height);
        }
        private void InvalidateColors()
        {
            pictureBoxColor.Invalidate();
            pictureBoxColorBack.Invalidate();
        }

        // Pixel editing
        private int EditPixelBPP(Graphics g, int x, int y, int color, int colorBack, int zoom, EditMode action)
        {
            if (glyph == null)
                return Do.EditPixelBPP(
                    graphics, this.offset, paletteSet.Palettes[currentPalette], g, zoom, action,
                    x * zoom, y * zoom, 0, color, colorBack, size.Width, size.Height, format);
            else if (glyph.Type != FontType.Triangles)
                return Do.EditPixelBPP(
                    graphics, this.offset, palette, g, zoom, action, x * zoom, y * zoom, 0,
                    color, colorBack, glyph.MaxWidth, glyph.Height, format, glyph);
            else
                return Do.EditPixelBPP(
                    graphics, this.offset, palette, g, zoom, action, x * zoom, y * zoom, 0,
                    color, colorBack, size.Width, size.Height, format);
        }
        private void Draw(Graphics g, int x, int y, int color, int colorBack)
        {
            for (int Y = hoverBox.Y / zoom; Y < hoverBox.Bottom / zoom; Y++)
            {
                for (int X = hoverBox.X / zoom; X < hoverBox.Right / zoom; X++)
                    if (X >= 0 && X < this.width / zoom && Y >= 0 && Y < this.height / zoom)
                        EditPixelBPP(g, X, Y, color, colorBack, zoom, action);
            }
        }

        // Selection editing
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
            if (overlay.Select.Empty)
                return;
            int[] buffer = new int[overlay.Select.Width * overlay.Select.Height];
            for (int y = overlay.Select.Y, i = 0; y < overlay.Select.Terminal.Y; y++)
            {
                for (int x = overlay.Select.X; x < overlay.Select.Terminal.X; x++)
                {
                    if (glyph == null)
                        buffer[i++] = Do.GetBPPColor(graphics, x, y, this.offset, 0, 1, format, size.Width);
                    else
                        buffer[i++] = Do.GetBPPColor(graphics, x & 7, y & 7, (x / 8) * 24, y / 8, 1, format, glyph.MaxWidth);
                }
            }
            copiedColors = new CopyBuffer(overlay.Select.Width, overlay.Select.Height, buffer);
            SetSelectionImage(copiedColors);
        }
        private void Paste()
        {
            int x = Math.Max(0, Math.Min(Math.Abs(panelGraphicSet.AutoScrollPosition.X) / zoom / 16 * 16, this.width - 1));
            int y = Math.Max(0, Math.Min(Math.Abs(panelGraphicSet.AutoScrollPosition.Y) / zoom / 16 * 16, this.height - 1));
            Paste(new Point(x, y));
        }
        private void Paste(Point location)
        {
            if (copiedColors == null)
                return;
            moving = true;
            // now dragging a new selection
            overlay.Select.Set(1, location, copiedColors.Size, pictureBoxGraphicSet);
            pictureBoxGraphicSet.Invalidate();
            defloating = false;
        }
        private void Delete()
        {
            original = Bits.Copy(graphics);
            for (int y = overlay.Select.Y; y < overlay.Select.Terminal.Y; y++)
            {
                for (int x = overlay.Select.X; x < overlay.Select.Terminal.X; x++)
                    EditPixelBPP(null, x, y, 0, 0, 1, EditMode.Erase);
            }
            commandStack.Push(new GraphicEdit(original, graphics));
            commandCount++;
            //
            SetGraphicSetImage();
            if (autoUpdate.Checked)
                updater.UpdateGraphics();
            this.targetForm.Refresh();
            this.Activate();
        }
        private void Flip(FlipType flipType)
        {
            original = Bits.Copy(graphics);
            if (flipType == FlipType.Horizontal)
                Do.FlipHorizontal(graphics, size.Width, overlay.Select.X, overlay.Select.Y, overlay.Select.Width, overlay.Select.Height, 1, format);
            else if (flipType == FlipType.Vertical)
                Do.FlipVertical(graphics, size.Width, overlay.Select.X, overlay.Select.Y, overlay.Select.Width, overlay.Select.Height, 1, format);
            commandStack.Push(new GraphicEdit(original, graphics));
            commandStack.Push(1);
            //
            SetGraphicSetImage();
            if (autoUpdate.Checked)
                updater.UpdateGraphics();
            this.targetForm.Refresh();
            this.Activate();
        }
        private void Drag()
        {
            if (overlay.Select.Empty || overlay.Select.Size == new Size(0, 0))
                return;
            int[] buffer = new int[overlay.Select.Width * overlay.Select.Height];
            for (int y = overlay.Select.Y, i = 0; y < overlay.Select.Terminal.Y; y++)
            {
                for (int x = overlay.Select.X; x < overlay.Select.Terminal.X; x++)
                {
                    if (glyph == null)
                        buffer[i++] = Do.GetBPPColor(graphics, x, y, this.offset, 0, 1, format, size.Width);
                    else
                        buffer[i++] = Do.GetBPPColor(graphics, x & 7, y & 7, (x / 8) * 24, y / 8, 1, format, glyph.MaxWidth);
                }
            }
            draggedColors = new CopyBuffer(overlay.Select.Width, overlay.Select.Height, buffer);
            SetSelectionImage(draggedColors);
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
            original = Bits.Copy(graphics);
            for (int y = overlay.Select.Y, i = 0; y < overlay.Select.Terminal.Y; y++)
            {
                for (int x = overlay.Select.X; x < overlay.Select.Terminal.X; x++)
                {
                    int color = buffer.Copy[i++];
                    if (color == 0)
                        continue;
                    EditPixelBPP(null, x, y, color, 0, 1, EditMode.Draw);
                }
            }
            commandStack.Push(new GraphicEdit(original, graphics));
            commandStack.Push(commandCount + 1);
            commandCount = 0;
            //
            defloating = true;
            SetGraphicSetImage();
            if (autoUpdate.Checked)
                updater.UpdateGraphics();
            this.targetForm.Refresh();
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
            moving = false;
            overlay.Select.Clear();
        }

        // Zooming
        public void ZoomIn()
        {
            while (pictureBoxGraphicSet.Zoom < 8)
                pictureBoxGraphicSet.ZoomIn(0, 0);
        }
        public void ZoomOut()
        {
            while (pictureBoxGraphicSet.Zoom > 1)
                pictureBoxGraphicSet.ZoomOut(0, 0);
        }

        #endregion

        #region Event handlers

        // GraphicEditor
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
                case Keys.D: editDraw.PerformClick(); break;
                case Keys.E: editErase.PerformClick(); break;
                case Keys.S: editSelect.PerformClick(); break;
                case Keys.P: editDropper.PerformClick(); break;
                case Keys.R: editReplaceColor.PerformClick(); break;
                case Keys.F: editFill.PerformClick(); break;
                case Keys.Control | Keys.X: Cut(); break;
                case Keys.Control | Keys.C: Copy(); break;
                case Keys.Control | Keys.V: Paste(); break;
                case Keys.Delete: editDelete.PerformClick(); break;
                case Keys.Control | Keys.D: Defloat(); pictureBoxGraphicSet.Invalidate(); break;
                case Keys.Control | Keys.Z: undo.PerformClick(); break;
                case Keys.Control | Keys.Y: redo.PerformClick(); break;
            }
        }

        // Picture : Palette
        private void pictureBoxPalette_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; showBG.Checked && i < paletteSet.Palettes.Length - startRow; i++)
            {
                Brush brush = new SolidBrush(Color.FromArgb(paletteSet.Palettes[i + startRow][0]));
                e.Graphics.FillRectangle(brush, new Rectangle(0, i * 12, pictureBoxPalette.Width, 12));
            }
            if (paletteImage != null)
                e.Graphics.DrawImage(paletteImage, 0, 0);
            Point p = new Point(currentColor * 12, currentPalette * 12 - (startRow * 12));
            e.Graphics.DrawRectangle(new Pen(Color.Red), new Rectangle(p.X, p.Y, 11, 11));
        }
        private void pictureBoxPalette_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBoxPalette.Focus();
            int temp = currentPalette;
            currentPalette = e.Y / 12 + startRow;
            if (e.Button == MouseButtons.Left)
                currentColor = e.X / 12;
            else if (e.Button == MouseButtons.Right)
                currentColorBack = e.X / 12;
            pictureBoxPalette.Invalidate();
            pictureBoxColor.Invalidate();
            pictureBoxColorBack.Invalidate();
            SetGraphicSetImage();
            if (temp != currentPalette)
                SetSelectionImage(copiedColors);
        }

        // Picture : Graphics
        private void pictureBoxGraphicSet_Paint(object sender, PaintEventArgs e)
        {
            if (graphicsImage == null)
                return;
            //
            Rectangle rsrc = new Rectangle(0, 0, graphicsImage.Width, graphicsImage.Height);
            Rectangle rdst = new Rectangle(0, 0, graphicsImage.Width * zoom, graphicsImage.Height * zoom);
            e.Graphics.PixelOffsetMode = PixelOffsetMode.Half;
            e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
            //
            if (showBG.Checked)
                e.Graphics.FillRectangle(new SolidBrush(bgcolor), e.ClipRectangle);
            e.Graphics.DrawImage(graphicsImage, rdst, rsrc, GraphicsUnit.Pixel);
            //
            Size s = new Size(graphicsImage.Width * zoom, graphicsImage.Height * zoom);
            if (zoom >= 4 && graphicShowPixelGrid.Checked)
                overlay.DrawTileGrid(e.Graphics, Color.DarkRed, s, new Size(1, 1), zoom, false);
            if (graphicShowGrid.Checked)
                overlay.DrawTileGrid(e.Graphics, Color.Gray, s, new Size(8, 8), zoom, true);
            //
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
            if (editSelect.Checked)
            {
                if (overlay.Select != null)
                {
                    e.Graphics.PixelOffsetMode = PixelOffsetMode.Default;
                    overlay.Select.DrawSelectionBox(e.Graphics, zoom);
                    e.Graphics.PixelOffsetMode = PixelOffsetMode.Half;
                }
            }
            //
            e.Graphics.PixelOffsetMode = PixelOffsetMode.Default;
            if (!editSelect.Checked && !graphicZoomIn.Checked && !graphicZoomOut.Checked && this.hoverBox.Width > 2 && mouseEnter)
            {
                Rectangle hoverBox = this.hoverBox;
                if (!editErase.Checked && !editDraw.Checked && !editReplaceColor.Checked)
                {
                    int x = mousePosition.X * zoom;
                    int y = mousePosition.Y * zoom;
                    hoverBox = new Rectangle(x, y, zoom, zoom);
                }
                if (action != EditMode.ReplaceColor && action != EditMode.Erase &&
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
            if (moving && mouseOverObject != "selection")
            {
                // if copied tiles were pasted and not dragging a non-copied selection
                if (copiedColors != null && draggedColors == null)
                    Defloat(copiedColors);
                if (draggedColors != null)
                {
                    Defloat(draggedColors);
                    draggedColors = null;
                }
                moving = false;
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
            action = EditMode.None;
            if (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right)
            {
                if (Control.ModifierKeys == Keys.Control)
                    action = EditMode.Dropper;
                else if (editDraw.Checked)
                    action = color != startCol ? EditMode.Draw : EditMode.Erase;
                else if (editErase.Checked)
                    action = EditMode.Erase;
                else if (editDropper.Checked)
                    action = EditMode.Dropper;
                else if (editReplaceColor.Checked)
                    action = EditMode.ReplaceColor;
                else if (editFill.Checked)
                    action = contiguous.Checked ? EditMode.Fill : EditMode.FillAll;
                else if (editSelect.Checked)
                {
                    action = EditMode.Select;
                    // if we're not inside a current selection to move it, create a new selection
                    if (mouseOverObject != "selection")
                        overlay.Select.Reload(1, x, y, 1, 1, pictureBoxGraphicSet);
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
                    return;
                }
                if (action == EditMode.Draw || action == EditMode.Erase || action == EditMode.Fill ||
                    action == EditMode.FillAll || action == EditMode.ReplaceColor)
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
            if (action == EditMode.Draw)
            {
                Draw(g, x, y, color, colorBack);
                pictureBoxGraphicSet.Draw(hoverBox, Color.FromArgb(palette[color]));
            }
            else if (action == EditMode.Erase)
            {
                Draw(g, x, y, color, colorBack);
                if (!showBG.Checked)
                    pictureBoxGraphicSet.Erase(hoverBox);
                else
                    pictureBoxGraphicSet.Draw(hoverBox, bgcolor);
            }
            else if (action == EditMode.ReplaceColor)
                Draw(g, x, y, color, colorBack);
            else if (editSelect.Checked)
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
                else if (e.Button == MouseButtons.Left && mouseDownObject == "selection" && overlay.Select != null && !mouseWithinSameBounds)
                    overlay.Select.Location = new Point((x / zoom) - mouseDownPosition.X, (y / zoom) - mouseDownPosition.Y);
                // if mouse not clicked and within the current selection
                else if (e.Button == MouseButtons.None && overlay.Select != null && overlay.Select.MouseWithin(x / zoom, y / zoom))
                {
                    mouseOverObject = "selection";
                    pictureBoxGraphicSet.Cursor = Cursors.SizeAll;
                }
                else
                    pictureBoxGraphicSet.Cursor = Cursors.Cross;
                pictureBoxGraphicSet.Invalidate();
                return;
            }
            else if (action == EditMode.Dropper)
            {
                color = EditPixelBPP(g, x / zoom, y / zoom, color, colorBack, zoom, action);
                if (e.Button == MouseButtons.Left)
                    currentColor = color + startCol;
                else if (e.Button == MouseButtons.Right)
                    currentColorBack = color + startCol;
            }
            else if (action == EditMode.None)
                pictureBoxGraphicSet.Invalidate();
            else
                EditPixelBPP(g, x / zoom, y / zoom, color, colorBack, zoom, action);
            //
            currentPixel = (x / zoom) + (y / zoom);
            pictureBoxPalette.Invalidate();
            pictureBoxColor.Invalidate();
            pictureBoxColorBack.Invalidate();
        }
        private void pictureBoxGraphicSet_MouseUp(object sender, MouseEventArgs e)
        {
            action = EditMode.None;
            pictureBoxGraphicSet.Invalidate();
            if (!editDraw.Checked && !editErase.Checked &&
                !editReplaceColor.Checked && !editFill.Checked)
                return;
            if (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right)
                SetGraphicSetImage();
            if (autoUpdate.Checked)
                updater.UpdateGraphics();
            this.targetForm.Refresh();
            this.Activate();
            if (!moving && !Bits.Compare(original, graphics))
            {
                // params switched because changes are actually last instance
                this.commandStack.Push(new GraphicEdit(original, graphics));
                this.commandStack.Push(1);
            }
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

        // Picture : Color
        private void pictureBoxColor_Paint(object sender, PaintEventArgs e)
        {
            if (!showBG.Checked && currentColor == startCol)
                return;
            int color = paletteSet.Palettes[currentPalette][currentColor];
            SolidBrush brush = new SolidBrush(Color.FromArgb(color));
            e.Graphics.FillRectangle(brush, new Rectangle(0, 0, 62, 62));
        }
        private void pictureBoxColorBack_Paint(object sender, PaintEventArgs e)
        {
            if (!showBG.Checked && currentColorBack == startCol)
                return;
            int color = paletteSet.Palettes[currentPalette][currentColorBack];
            SolidBrush brush = new SolidBrush(Color.FromArgb(color));
            e.Graphics.FillRectangle(brush, new Rectangle(0, 0, 62, 62));
        }
        private void switchColors_MouseDown(object sender, MouseEventArgs e)
        {
            int currentColor = this.currentColor;
            this.currentColor = this.currentColorBack;
            this.currentColorBack = currentColor;
            pictureBoxColor.Invalidate();
            pictureBoxColorBack.Invalidate();
        }

        // Panel : Graphics
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
            panelPaletteSet.Focus();
        }

        // ContextMenuStrip
        private void setSubtileToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }
        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.gif,*.jpg,*.png)|*.gif;*.jpg;*.png|Binary files (*.bin)|*.bin|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 0;
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() != DialogResult.OK)
                return;
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
                updater.UpdateGraphics();
            this.targetForm.Refresh();
            this.Activate();
        }
        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Binary files (*.bin)|*.bin|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.FileName = "graphicSet";
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
            if (saveFileDialog.ShowDialog() != DialogResult.OK)
                return;
            graphicsImage.Save(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Png);
        }
        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Array.Clear(graphics, 0, graphics.Length);
            SetGraphicSetImage();
            if (autoUpdate.Checked)
                updater.UpdateGraphics();
            this.targetForm.Refresh();
            this.Activate();
        }

        // ToolStrip : Toggle
        private void graphicZoomIn_Click(object sender, EventArgs e)
        {
            editDraw.Checked = false;
            editErase.Checked = false;
            editDropper.Checked = false;
            editFill.Checked = false;
            editSelect.Checked = false;
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
            editDraw.Checked = false;
            editErase.Checked = false;
            editDropper.Checked = false;
            editFill.Checked = false;
            editSelect.Checked = false;
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
            if (size.Width == 1)
                return;
            size.Width--; this.width -= 8 * zoom;
            SetGraphicSetImage();
            SetCoordsLabel();
            Defloat();
            pictureBoxGraphicSet.Invalidate();
        }
        private void widthIncrease_Click(object sender, EventArgs e)
        {
            if (size.Width == 64)
                return;
            size.Width++; this.width += 8 * zoom;
            SetGraphicSetImage();
            SetCoordsLabel();
            Defloat();
            pictureBoxGraphicSet.Invalidate();
        }
        private void heightDecrease_Click(object sender, EventArgs e)
        {
            if (size.Height == 1)
                return;
            size.Height--; this.height -= 8 * zoom;
            SetGraphicSetImage();
            SetCoordsLabel();
            Defloat();
            pictureBoxGraphicSet.Invalidate();
        }
        private void heightIncrease_Click(object sender, EventArgs e)
        {
            if (size.Height == 256)
                return;
            size.Height++; this.height += 8 * zoom;
            SetGraphicSetImage();
            SetCoordsLabel();
            Defloat();
            pictureBoxGraphicSet.Invalidate();
        }
        private void brushSize_ValueChanged(object sender, EventArgs e)
        {
            if (editDraw.Checked)
                drawSize = (int)brushSize.Value;
            if (editErase.Checked)
                eraseSize = (int)brushSize.Value;
            if (editReplaceColor.Checked)
                replaceSize = (int)brushSize.Value;
        }

        // ToolStrip : Drawing
        private void editDraw_Click(object sender, EventArgs e)
        {
            editErase.Checked = false;
            editDropper.Checked = false;
            editReplaceColor.Checked = false;
            editFill.Checked = false;
            editSelect.Checked = false;
            graphicZoomIn.Checked = false;
            graphicZoomOut.Checked = false;
            contiguous.Visible = false;
            brushSize.Visible = editDraw.Checked;
            //
            if (editDraw.Checked) brushSize.Value = drawSize;
            if (!editDraw.Checked)
                pictureBoxGraphicSet.Cursor = Cursors.Arrow;
            else
                pictureBoxGraphicSet.Cursor = NewCursors.Draw;
            Defloat();
            pictureBoxGraphicSet.Invalidate();
        }
        private void editErase_Click(object sender, EventArgs e)
        {
            editDraw.Checked = false;
            editDropper.Checked = false;
            editReplaceColor.Checked = false;
            editFill.Checked = false;
            editSelect.Checked = false;
            graphicZoomIn.Checked = false;
            graphicZoomOut.Checked = false;
            contiguous.Visible = false;
            brushSize.Visible = editErase.Checked;
            //
            if (editErase.Checked) brushSize.Value = eraseSize;
            if (!editErase.Checked)
                pictureBoxGraphicSet.Cursor = Cursors.Arrow;
            else
                pictureBoxGraphicSet.Cursor = NewCursors.Erase;
            Defloat();
            pictureBoxGraphicSet.Invalidate();
        }
        private void editDropper_Click(object sender, EventArgs e)
        {
            editDraw.Checked = false;
            editErase.Checked = false;
            editReplaceColor.Checked = false;
            editFill.Checked = false;
            editSelect.Checked = false;
            graphicZoomIn.Checked = false;
            graphicZoomOut.Checked = false;
            contiguous.Visible = false;
            brushSize.Visible = false;
            //
            if (!editDropper.Checked)
                pictureBoxGraphicSet.Cursor = Cursors.Arrow;
            else
                pictureBoxGraphicSet.Cursor = NewCursors.Dropper;
            Defloat();
            pictureBoxGraphicSet.Invalidate();
        }
        private void editReplaceColor_Click(object sender, EventArgs e)
        {
            editDraw.Checked = false;
            editErase.Checked = false;
            editDropper.Checked = false;
            editFill.Checked = false;
            editSelect.Checked = false;
            graphicZoomIn.Checked = false;
            graphicZoomOut.Checked = false;
            contiguous.Visible = false;
            brushSize.Visible = editReplaceColor.Checked;
            //
            if (editReplaceColor.Checked) brushSize.Value = replaceSize;
            if (!editReplaceColor.Checked)
                pictureBoxGraphicSet.Cursor = Cursors.Arrow;
            else
                pictureBoxGraphicSet.Cursor = NewCursors.Draw;
            Defloat();
            pictureBoxGraphicSet.Invalidate();
        }
        private void editFill_Click(object sender, EventArgs e)
        {
            editDraw.Checked = false;
            editErase.Checked = false;
            editDropper.Checked = false;
            editReplaceColor.Checked = false;
            editSelect.Checked = false;
            graphicZoomIn.Checked = false;
            graphicZoomOut.Checked = false;
            brushSize.Visible = false;
            contiguous.Visible = editFill.Checked;
            //
            if (!editFill.Checked)
                pictureBoxGraphicSet.Cursor = Cursors.Arrow;
            else
                pictureBoxGraphicSet.Cursor = NewCursors.Fill;
            Defloat();
            pictureBoxGraphicSet.Invalidate();
        }
        private void editSelect_Click(object sender, EventArgs e)
        {
            editDraw.Checked = false;
            editErase.Checked = false;
            editDropper.Checked = false;
            editReplaceColor.Checked = false;
            editFill.Checked = false;
            graphicZoomIn.Checked = false;
            graphicZoomOut.Checked = false;
            contiguous.Visible = editFill.Checked;
            brushSize.Visible = false;
            //
            if (!editSelect.Checked)
                pictureBoxGraphicSet.Cursor = Cursors.Arrow;
            else
                pictureBoxGraphicSet.Cursor = Cursors.Cross;
            Defloat();
            pictureBoxGraphicSet.Invalidate();
        }
        private void editCut_Click(object sender, EventArgs e)
        {
            Cut();
        }
        private void editCopy_Click(object sender, EventArgs e)
        {
            Copy();
        }
        private void editPaste_Click(object sender, EventArgs e)
        {
            Paste();
        }
        private void editDelete_Click(object sender, EventArgs e)
        {
            if (!moving)
                Delete();
            else
            {
                moving = false;
                draggedColors = null;
                pictureBoxGraphicSet.Invalidate();
            }
            if (!moving && commandCount > 0)
            {
                commandStack.Push(commandCount);
                commandCount = 0;
            }
        }
        private void mirror_Click(object sender, EventArgs e)
        {
            if (!moving)
                Flip(FlipType.Horizontal);
            else
            {
                moving = false;
                draggedColors = null;
                pictureBoxGraphicSet.Invalidate();
            }
        }
        private void invert_Click(object sender, EventArgs e)
        {
            if (!moving)
                Flip(FlipType.Vertical);
            else
            {
                moving = false;
                draggedColors = null;
                pictureBoxGraphicSet.Invalidate();
            }
        }
        private void undo_Click(object sender, EventArgs e)
        {
            commandStack.UndoCommand();
            SetGraphicSetImage();
            if (autoUpdate.Checked)
                updater.UpdateGraphics();
            this.targetForm.Refresh();
            this.Activate();
        }
        private void redo_Click(object sender, EventArgs e)
        {
            commandStack.RedoCommand();
            SetGraphicSetImage();
            if (autoUpdate.Checked)
                updater.UpdateGraphics();
            this.targetForm.Refresh();
            this.Activate();
        }

        // Drawing options
        private void brushSize_VisibleChanged(object sender, EventArgs e)
        {
            toolStripSeparator33.Visible = brushSize.Visible;
            labelBrushSize.Visible = brushSize.Visible;
        }
        private void contiguous_VisibleChanged(object sender, EventArgs e)
        {
            toolStripSeparator33.Visible = contiguous.Visible;
        }
        private void contextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Control ||
                editDraw.Checked || editErase.Checked ||
                editDropper.Checked || editReplaceColor.Checked ||
                graphicZoomIn.Checked || graphicZoomOut.Checked)
                e.Cancel = true;
        }

        // Closing/saving
        private void buttonOK_Click(object sender, EventArgs e)
        {
            graphics.CopyTo(graphicsBackup, 0);
            this.Close();
            if (!autoUpdate.Checked)
                updater.UpdateGraphics();
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void buttonReset_Click(object sender, EventArgs e)
        {
            commandStack.Clear();
            graphicsBackup.CopyTo(graphics, 0);
            SetGraphicSetImage();
            if (autoUpdate.Checked)
                updater.UpdateGraphics();
            this.Owner.Refresh();
            this.Activate();
        }
        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            updater.UpdateGraphics();
            this.targetForm.Refresh();
            this.Activate();
        }
        private void alwaysOnTop_CheckedChanged(object sender, EventArgs e)
        {
            this.TopMost = alwaysOnTop.Checked;
        }

        #endregion
    }
}
