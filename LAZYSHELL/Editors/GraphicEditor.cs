using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace LAZYSHELL
{
    public partial class GraphicEditor : Form
    {
        private Delegate update;
        private byte[] graphics;
        private byte[] graphicsBackup;
        private int offset = 0;
        private int length = 0;
        private int start;
        private int index;
        private Size size = new Size(16, 48);
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

        private int mouseOverSubtile;
        private string mouseOverControl;

        private int currentPixel = 0;
        private int currentColor = 0;
        private int currentColorBack = 0;
        private int currentPalette = 0;
        private int zoom = 2;
        private Bitmap graphicsImage, paletteImage;

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
        private void InitializeGraphicEditor(Delegate update, byte[] graphics, int length, int offset, PaletteSet paletteSet, int start, byte format)
        {
            this.update = update;
            this.offset = offset;
            this.length = length;
            this.start = start;
            this.currentPalette = start;
            this.graphics = graphics;
            this.graphicsBackup = new byte[graphics.Length];
            graphics.CopyTo(graphicsBackup, 0);
            this.paletteSet = paletteSet;
            this.format = format;
            this.overlay = new Overlay();

            InitializeComponent();

            panel110.Height = paletteSet.Palettes.Length * 8 + 4 - (start * 8);
            pictureBoxPalette.Height = paletteSet.Palettes.Length * 8 - (start * 8);
            pictureBoxGraphicSet.Height = maxHeight * zoom;
            panel110.Focus();
            size.Width = pictureBoxGraphicSet.Width / zoom / 8;
            size.Height = pictureBoxGraphicSet.Height / zoom / 8;

            sizeLabel.Text = size.Width.ToString() + "x" + size.Height.ToString();

            SetGraphicSetImage();
            SetPaletteImage();
            pictureBoxColor.Invalidate();
            pictureBoxColorBack.Invalidate();
            this.BringToFront();
        }
        public void Reload(Delegate update, byte[] graphics, int length, int offset, PaletteSet paletteSet, int start, byte format)
        {
            this.update = update;
            this.offset = offset;
            this.length = length;
            this.start = start;
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

            panel110.Height = paletteSet.Palettes.Length * 8 + 4 - (start * 8);
            pictureBoxPalette.Height = paletteSet.Palettes.Length * 8 - (start * 8);
            pictureBoxGraphicSet.Height = maxHeight * zoom;
            panel110.Focus();
            size.Width = pictureBoxGraphicSet.Width / zoom / 8;
            size.Height = pictureBoxGraphicSet.Height / zoom / 8;

            sizeLabel.Text = size.Width.ToString() + "x" + size.Height.ToString();

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
        private void SetGraphicSetImage()
        {
            int[] palette;
            if (format == 0x10)
            {
                palette = new int[16];
                for (int i = 0; i < 4; i++)
                    palette[i] = paletteSet.Palettes[currentPalette / 4][((currentPalette % 4) * 4) + i];
            }
            else
                palette = paletteSet.Palettes[currentPalette];

            int[] pixels = Do.GetPixelRegion(graphics, format, palette, size.Width, 0, 0, size.Width, size.Height, this.offset);
            graphicsImage = new Bitmap(Do.PixelsToImage(pixels, size.Width * 8, size.Height * 8));
            pictureBoxGraphicSet.Invalidate();
        }
        private void SetPaletteImage()
        {
            int[] palettePixels = Do.PaletteToPixels(paletteSet.Palettes, 8, 8, 16, paletteSet.Palettes.Length, start);
            paletteImage = new Bitmap(Do.PixelsToImage(palettePixels, 128, paletteSet.Palettes.Length * 8 - (start * 8)));
            pictureBoxPalette.Invalidate();
        }

        private void pictureBoxPalette_MouseClick(object sender, MouseEventArgs e)
        {
        }
        private void pictureBoxPalette_Paint(object sender, PaintEventArgs e)
        {
            if (paletteImage != null)
                e.Graphics.DrawImage(paletteImage, 0, 0);
            Point p = new Point(currentColor * 8, currentPalette * 8 - (start * 8));
            e.Graphics.DrawRectangle(new Pen(Color.Red), new Rectangle(p.X, p.Y, 7, 7));
        }

        private void pictureBoxGraphicSet_Paint(object sender, PaintEventArgs e)
        {
            if (graphicsImage == null) return;

            Rectangle rsrc = new Rectangle(0, 0, graphicsImage.Width, graphicsImage.Height);
            Rectangle rdst = new Rectangle(0, 0, graphicsImage.Width * zoom, graphicsImage.Height * zoom);
            e.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            if (e.ClipRectangle.Size != new Size(1 * zoom, 1 * zoom))
                e.Graphics.DrawImage(graphicsImage, rdst, rsrc, GraphicsUnit.Pixel);

            Size s = new Size(graphicsImage.Width * zoom, graphicsImage.Height * zoom);
            if (zoom >= 4 && graphicShowPixelGrid.Checked)
                overlay.DrawCartographicGrid(e.Graphics, Color.DarkRed, s, new Size(1, 1), zoom);
            if (graphicShowGrid.Checked)
                overlay.DrawCartographicGrid(e.Graphics, Color.Gray, s, new Size(8, 8), zoom);
        }
        private void pictureBoxGraphicSet_MouseDown(object sender, MouseEventArgs e)
        {
            Point p;
            if ((graphicZoomIn.Checked && e.Button == MouseButtons.Left) || (graphicZoomOut.Checked && e.Button == MouseButtons.Right))
            {
                if (zoom < 8)
                {
                    zoom *= 2;

                    p = new Point(Math.Abs(pictureBoxGraphicSet.Left), Math.Abs(pictureBoxGraphicSet.Top));
                    p.X += e.X;
                    p.Y += e.Y;

                    pictureBoxGraphicSet.Width = size.Width * 8 * zoom;
                    pictureBoxGraphicSet.Height = size.Height * 8 * zoom;
                    pictureBoxGraphicSet.Invalidate();
                    return;
                }
                return;
            }
            else if ((graphicZoomOut.Checked && e.Button == MouseButtons.Left) || (graphicZoomIn.Checked && e.Button == MouseButtons.Right))
            {
                if (zoom > 1)
                {
                    zoom /= 2;

                    p = new Point(Math.Abs(pictureBoxGraphicSet.Left), Math.Abs(pictureBoxGraphicSet.Top));
                    p.X -= e.X / 2;
                    p.Y -= e.Y / 2;

                    pictureBoxGraphicSet.Width = size.Width * 8 * zoom;
                    pictureBoxGraphicSet.Height = size.Height * 8 * zoom;
                    pictureBoxGraphicSet.Invalidate();
                    return;
                }
                return;
            }

            pictureBoxGraphicSet_MouseMove(sender, e);
        }
        private void pictureBoxGraphicSet_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (graphicZoomIn.Checked || graphicZoomOut.Checked)
                return;
        }
        private void pictureBoxGraphicSet_MouseMove(object sender, MouseEventArgs e)
        {
            int x = e.X; int y = e.Y;
            mouseOverControl = pictureBoxGraphicSet.Name;
            mouseOverSubtile = (y / (8 * zoom)) * size.Width + (x / (8 * zoom)); // Calculate tile number
            coordsLabel.Text = "subtile " + (mouseOverSubtile + index).ToString("d4");

            string action = "";
            if ((e.Button == MouseButtons.Left || e.Button == MouseButtons.Right) && subtileDraw.Checked)
                action = "draw";
            else if ((e.Button == MouseButtons.Left || e.Button == MouseButtons.Right) && subtileErase.Checked)
                action = "erase";
            else if ((e.Button == MouseButtons.Left || e.Button == MouseButtons.Right) && subtileDropper.Checked)
                action = "select";
            else if ((e.Button == MouseButtons.Left || e.Button == MouseButtons.Right) && subtileFill.Checked)
                action = contiguous.Checked ? "fill" : "replace";
            int color = currentColor;
            if (e.Button == MouseButtons.Right)
                color = currentColorBack;

            color = Do.EditPixelBPP(
                graphics, this.offset, paletteSet.Palettes[currentPalette],
                pictureBoxGraphicSet.CreateGraphics(), zoom, action,
                x, y, 0, color, size.Width, size.Height, format);
            if (action == "erase")
                pictureBoxGraphicSet.Invalidate(new Rectangle(x / zoom * zoom, y / zoom * zoom, 1 * zoom, 1 * zoom));

            currentPixel = (x / zoom) + (y / zoom);
            if (action == "select" && e.Button == MouseButtons.Left)
                currentColor = color;
            else if (action == "select" && e.Button == MouseButtons.Right)
                currentColorBack = color;
            pictureBoxPalette.Invalidate();
            pictureBoxColor.Invalidate();
            pictureBoxColorBack.Invalidate();
        }
        private void pictureBoxGraphicSet_MouseUp(object sender, MouseEventArgs e)
        {
            if (!subtileDraw.Checked && !subtileErase.Checked && !subtileFill.Checked) return;

            if (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right)
                SetGraphicSetImage();
            if (autoUpdate.Checked)
                update.DynamicInvoke();
        }

        // Graphic Set Editor context menu items
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
                    16, this.offset + (mouseOverSubtile * format), format);
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
        }

        // Graphic Set Editor toolstrip buttons
        private void graphicZoomIn_Click(object sender, EventArgs e)
        {
            subtileDraw.Checked = false;
            subtileErase.Checked = false;
            subtileDropper.Checked = false;
            subtileFill.Checked = false;
            graphicZoomOut.Checked = false;
            if (graphicZoomIn.Checked)
                pictureBoxGraphicSet.Cursor = new Cursor(GetType(), "CursorZoomIn.cur");
            else
                pictureBoxGraphicSet.Cursor = System.Windows.Forms.Cursors.Arrow;

            if (graphicZoomIn.Checked)
                pictureBoxGraphicSet.ContextMenuStrip = null;
            else
                pictureBoxGraphicSet.ContextMenuStrip = contextMenuStrip;
        }
        private void graphicZoomOut_Click(object sender, EventArgs e)
        {
            subtileDraw.Checked = false;
            subtileErase.Checked = false;
            subtileDropper.Checked = false;
            subtileFill.Checked = false;
            graphicZoomIn.Checked = false;
            if (graphicZoomOut.Checked)
                pictureBoxGraphicSet.Cursor = new Cursor(GetType(), "CursorZoomOut.cur");
            else
                pictureBoxGraphicSet.Cursor = System.Windows.Forms.Cursors.Arrow;

            if (graphicZoomOut.Checked)
                pictureBoxGraphicSet.ContextMenuStrip = null;
            else
                pictureBoxGraphicSet.ContextMenuStrip = contextMenuStrip;
        }
        private void graphicShowGrid_Click(object sender, EventArgs e)
        {
            pictureBoxGraphicSet.Invalidate();
        }
        private void graphicShowPixelGrid_Click(object sender, EventArgs e)
        {
            pictureBoxGraphicSet.Invalidate();
        }
        private void subtileDraw_Click(object sender, EventArgs e)
        {
            subtileErase.Checked = false;
            subtileDropper.Checked = false;
            subtileFill.Checked = false;
            graphicZoomIn.Checked = false;
            graphicZoomOut.Checked = false;

            if (!subtileDraw.Checked)
                pictureBoxGraphicSet.Cursor = Cursors.Arrow;
            else
                pictureBoxGraphicSet.Cursor = new System.Windows.Forms.Cursor(GetType(), "CursorDraw.cur");
        }
        private void subtileErase_Click(object sender, EventArgs e)
        {
            subtileDraw.Checked = false;
            subtileDropper.Checked = false;
            subtileFill.Checked = false;
            graphicZoomIn.Checked = false;
            graphicZoomOut.Checked = false;

            if (!subtileErase.Checked)
                pictureBoxGraphicSet.Cursor = Cursors.Arrow;
            else
                pictureBoxGraphicSet.Cursor = new System.Windows.Forms.Cursor(GetType(), "CursorErase.cur");
        }
        private void subtileDropper_Click(object sender, EventArgs e)
        {
            subtileDraw.Checked = false;
            subtileErase.Checked = false;
            subtileFill.Checked = false;
            graphicZoomIn.Checked = false;
            graphicZoomOut.Checked = false;

            if (!subtileDropper.Checked)
                pictureBoxGraphicSet.Cursor = Cursors.Arrow;
            else
                pictureBoxGraphicSet.Cursor = new System.Windows.Forms.Cursor(GetType(), "CursorDropper.cur");
        }
        private void subtileFill_Click(object sender, EventArgs e)
        {
            subtileDraw.Checked = false;
            subtileErase.Checked = false;
            subtileDropper.Checked = false;
            graphicZoomIn.Checked = false;
            graphicZoomOut.Checked = false;
            contiguous.Visible = subtileFill.Checked;

            if (!subtileFill.Checked)
                pictureBoxGraphicSet.Cursor = Cursors.Arrow;
            else
                pictureBoxGraphicSet.Cursor = new System.Windows.Forms.Cursor(GetType(), "CursorFill.cur");
        }

        private void GraphicEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            buttonReset_Click(null, null);
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
            graphicsBackup.CopyTo(graphics, 0);
            if (autoUpdate.Checked)
                update.DynamicInvoke();
            SetGraphicSetImage();
        }
        private void panel109_Scroll(object sender, ScrollEventArgs e)
        {
            pictureBoxGraphicSet.Invalidate();
            panel109.Invalidate();
        }

        private void widthDecrease_Click(object sender, EventArgs e)
        {
            if (size.Width == 1) return;
            size.Width--; pictureBoxGraphicSet.Width -= 8 * zoom;
            SetGraphicSetImage();

            sizeLabel.Text = size.Width.ToString() + "x" + size.Height.ToString();
        }
        private void widthIncrease_Click(object sender, EventArgs e)
        {
            if (size.Width == 64) return;
            size.Width++; pictureBoxGraphicSet.Width += 8 * zoom;
            SetGraphicSetImage();

            sizeLabel.Text = size.Width.ToString() + "x" + size.Height.ToString();
        }
        private void heightDecrease_Click(object sender, EventArgs e)
        {
            if (size.Height == 1) return;
            size.Height--; pictureBoxGraphicSet.Height -= 8 * zoom;
            SetGraphicSetImage();

            sizeLabel.Text = size.Width.ToString() + "x" + size.Height.ToString();
        }
        private void heightIncrease_Click(object sender, EventArgs e)
        {
            if (size.Height == 256) return;
            size.Height++; pictureBoxGraphicSet.Height += 8 * zoom;
            SetGraphicSetImage();

            sizeLabel.Text = size.Width.ToString() + "x" + size.Height.ToString();
        }
        private void pictureBoxGraphicSet_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
        }

        private void pictureBoxPalette_MouseDown(object sender, MouseEventArgs e)
        {
            if (format == 0x10 && e.X / 8 > 3)
                return;
            pictureBoxPalette.Focus();
            currentPalette = e.Y / 8 + start;
            if (e.Button == MouseButtons.Left)
                currentColor = e.X / 8;
            else if (e.Button == MouseButtons.Right)
                currentColorBack = e.X / 8;
            pictureBoxPalette.Invalidate();
            pictureBoxColor.Invalidate();
            pictureBoxColorBack.Invalidate();
            SetGraphicSetImage();
        }

        private void pictureBoxColor_Paint(object sender, PaintEventArgs e)
        {
            int color = paletteSet.Palettes[currentPalette][currentColor];
            SolidBrush brush = new SolidBrush(Color.FromArgb(color));
            e.Graphics.FillRectangle(brush, new Rectangle(0, 0, 62, 62));
        }
        private void pictureBoxColorBack_Paint(object sender, PaintEventArgs e)
        {
            int color = paletteSet.Palettes[currentPalette][currentColorBack];
            SolidBrush brush = new SolidBrush(Color.FromArgb(color));
            e.Graphics.FillRectangle(brush, new Rectangle(0, 0, 62, 62));
        }

        private void panel109_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == (Keys.Shift | Keys.Left))
                widthDecrease_Click(null, null);
            else if (e.KeyData == (Keys.Shift | Keys.Right))
                widthIncrease_Click(null, null);
            else if (e.KeyData == (Keys.Shift | Keys.Up))
                heightDecrease_Click(null, null);
            else if (e.KeyData == (Keys.Shift | Keys.Down))
                heightIncrease_Click(null, null);
        }

        private void panel109_MouseDown(object sender, MouseEventArgs e)
        {
            panel110.Focus();
        }

        private void contextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            if (subtileDraw.Checked || subtileErase.Checked || subtileDropper.Checked ||
                graphicZoomIn.Checked || graphicZoomOut.Checked)
                e.Cancel = true;
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            update.DynamicInvoke();
        }
    }
}
