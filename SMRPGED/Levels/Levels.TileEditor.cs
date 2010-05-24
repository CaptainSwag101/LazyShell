using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using SMRPGED.Properties;

namespace SMRPGED
{
    public partial class Levels
    {
        #region Variables

        private bool updatingSubtile;
        private byte[] graphicSets;
        private byte[] graphicSet5;

        private int mouseOverSubTile;
        private string mouseOverControl;

        private int currentLayer;
        private int currentTile;
        private int currentSubtile;
        private int currentPixel;
        private int currentColorTE;
        private int zoomG = 1;

        private Bitmap graphicSetImage, tileImage, subtileImage, paletteImage;

        // moving panels
        private bool movingPanelTileEditor;
        private bool resizingPanelTileEditor;
        private bool panelTileEditorMax;

        private bool movingPanelImageGraphics;
        private bool resizingPanelImageGraphics;
        private bool panelImageGraphicsMax;

        private int rightEdge;

        #endregion

        #region Methods

        private void InitializeTileEditor()
        {
            currentLayer = tabControl2.SelectedIndex > 2 ? 0 : tabControl2.SelectedIndex;
            currentTile = overlay.TileSelected;
            currentSubtile = 0;
            currentPixel = 0;
            currentColorTE = 0;

            if (tabControl2.SelectedIndex != 4)
                panel106.Enabled = currentTile != 0;
            else
                panel106.Enabled = true;

            if (tabControl2.SelectedIndex != 4)
                this.tileSet.TileSetLayers[currentLayer][(ushort)currentTile].IsBeingModified = true;
            else
                this.bts.TileSetLayer[(ushort)currentTile].IsBeingModified = true;

            DecompressTileSetData();

            InitializeSubtile();
            SetTileImage();
            SetSubtileImage();
            SetGraphicSetImage();
            SetPaletteImage();
        }
        private void InitializeSubtile()
        {
            updatingSubtile = true;

            currentPixel = 0;

            if (tabControl2.SelectedIndex != 4)
            {
                tile8x8Tile.Value = tileSet.TileSetLayers[currentLayer][(ushort)currentTile].GetSubtile(currentSubtile).TileNum;
                if (currentLayer != 2)
                {
                    tileGFXSet.Enabled = true;
                    tileGFXSet.Value = tileSet.TileSetLayers[currentLayer][(ushort)currentTile].GetSubtile(currentSubtile).GfxSetIndex;
                }
                else
                {
                    tileGFXSet.Enabled = false;
                    tileGFXSet.Value = 0;
                }
                tilePalette.Value = tileSet.TileSetLayers[currentLayer][(ushort)currentTile].GetSubtile(currentSubtile).PaletteSetIndex;
                tileAttributes.SetItemChecked(0, tileSet.TileSetLayers[currentLayer][(ushort)currentTile].GetSubtile(currentSubtile).PriorityOne);
                tileAttributes.SetItemChecked(1, tileSet.TileSetLayers[currentLayer][(ushort)currentTile].GetSubtile(currentSubtile).Mirrored);
                tileAttributes.SetItemChecked(2, tileSet.TileSetLayers[currentLayer][(ushort)currentTile].GetSubtile(currentSubtile).Inverted);
            }
            else
            {
                tile8x8Tile.Value = bts.TileSetLayer[(ushort)currentTile].GetSubtile(currentSubtile).TileNum;
                tileGFXSet.Value = bts.TileSetLayer[(ushort)currentTile].GetSubtile(currentSubtile).GfxSetIndex;
                tilePalette.Value = bts.TileSetLayer[(ushort)currentTile].GetSubtile(currentSubtile).PaletteSetIndex;
                tileAttributes.SetItemChecked(0, bts.TileSetLayer[(ushort)currentTile].GetSubtile(currentSubtile).PriorityOne);
                tileAttributes.SetItemChecked(1, bts.TileSetLayer[(ushort)currentTile].GetSubtile(currentSubtile).Mirrored);
                tileAttributes.SetItemChecked(2, bts.TileSetLayer[(ushort)currentTile].GetSubtile(currentSubtile).Inverted);
            }

            updatingSubtile = false;
        }

        // set images
        private void SetTileImage()
        {
            int[] temp = new int[16 * 16];
            int[] pixels = new int[32 * 32];

            for (int y = 0; y < 2; y++)
            {
                for (int x = 0; x < 2; x++)
                {
                    if (tabControl2.SelectedIndex != 4)
                        CopyOverTile8x8(tileSet.TileSetLayers[currentLayer][currentTile].GetSubtile(y * 2 + x), temp, 16, x, y);
                    else
                        CopyOverTile8x8(bts.TileSetLayer[currentTile].GetSubtile(y * 2 + x), temp, 16, x, y);
                }
            }
            for (int y = 0; y < 32; y++)
            {
                for (int x = 0; x < 32; x++)
                {
                    if (showGrid.Checked && (x == 16 || y == 16))
                        pixels[y * 32 + x] = Color.Gray.ToArgb();
                    else
                        pixels[y * 32 + x] = temp[y / 2 * 16 + (x / 2)];
                }
            }
            tileImage = new Bitmap(DrawImageFromIntArr(pixels, 32, 32));
            pictureBoxTile.BackColor = Color.FromArgb(paletteSet.PaletteColorRed[0], paletteSet.PaletteColorGreen[0], paletteSet.PaletteColorBlue[0]);
            pictureBoxTile.Invalidate();
        }
        private void SetSubtileImage()
        {
            int[] temp = new int[8 * 8];
            int[] pixels = new int[32 * 32];

            if (tabControl2.SelectedIndex != 4)
                CopyOverTile8x8(tileSet.TileSetLayers[currentLayer][currentTile].GetSubtile(currentSubtile), temp, 8, 0, 0);
            else
                CopyOverTile8x8(bts.TileSetLayer[currentTile].GetSubtile(currentSubtile), temp, 8, 0, 0);

            for (int y = 0; y < 32; y++)
            {
                for (int x = 0; x < 32; x++)
                    pixels[y * 32 + x] = temp[y / 4 * 8 + (x / 4)];
            }
            subtileImage = new Bitmap(DrawImageFromIntArr(pixels, 32, 32));
            pictureBoxSubtile.BackColor = Color.FromArgb(paletteSet.PaletteColorRed[0], paletteSet.PaletteColorGreen[0], paletteSet.PaletteColorBlue[0]);
            pictureBoxSubtile.Invalidate();
        }
        private void SetGraphicSetImage()
        {
            int[] pixels = new int[128 * 128];
            Tile8x8 subtile;

            for (int y = 0; y < 16; y++)
            {
                for (int x = 0; x < 16; x++)
                {
                    subtile = Draw4bppTile8x8(
                        y * 16 + x,
                        (byte)tileGFXSet.Value,
                        (byte)tilePalette.Value,
                        false, false, false);
                    CopyOverTile8x8(subtile, pixels, 128, x, y);
                }
            }

            graphicSetImage = new Bitmap(DrawImageFromIntArr(pixels, 128, 128));
            pictureBoxGraphicSet.BackColor = Color.FromArgb(paletteSet.PaletteColorRed[0], paletteSet.PaletteColorGreen[0], paletteSet.PaletteColorBlue[0]);
            pictureBoxGraphicSet.Invalidate();
        }
        private void SetPaletteImage()
        {
            int[] palettePixels = new int[256 * 16];
            int[] paletteColors;

            if (tabControl2.SelectedIndex != 4) 
                paletteColors = paletteSet.Get4bppPalette((int)tilePalette.Value - 1);
            else
                paletteColors = paletteSetBF.GetBattlefieldPalette((int)tilePalette.Value - 1);

            for (int i = 0; i < 16; i++) // 16 palette blocks wide
            {
                for (int y = 0; y < 16; y++)
                {
                    for (int x = 0; x < 16; x++)
                        palettePixels[x + (i * 16) + (y * 256)] = paletteColors[i];
                }
            }
            for (int y = 0; y < 16; y += 16)  // draw the horizontal gridlines
            {
                for (int x = 0; x < 256; x++)
                    palettePixels[y * 256 + x] = Color.Black.ToArgb();
                if (y == 0) y--;
            }
            for (int x = 0; x < 256; x += 16) // draw the vertical gridlines
            {
                for (int y = 0; y < 16; y++)
                    palettePixels[y * 256 + x] = Color.Black.ToArgb();
                if (x == 0) x--;
            }
            paletteImage = new Bitmap(DrawImageFromIntArr(palettePixels, 256, 16));
            pictureBoxPalette.Invalidate();
        }

        private Tile8x8 CreateNewSubtile()
        {
            // The current 8x8 tile that we are going to draw all the options for
            Tile8x8 currentSubTile;
            if (tabControl2.SelectedIndex != 4) currentSubTile = tileSet.TileSetLayers[currentLayer][(ushort)currentTile].GetSubtile(currentSubtile);
            else currentSubTile = bts.TileSetLayer[(ushort)currentTile].GetSubtile(currentSubtile);

            if (currentLayer != 2)
                return Draw4bppTile8x8((byte)this.tile8x8Tile.Value,
                    (byte)this.tileGFXSet.Value,
                    (byte)this.tilePalette.Value,
                    this.tileAttributes.GetItemChecked(1),
                    this.tileAttributes.GetItemChecked(2),
                    this.tileAttributes.GetItemChecked(0));
            else
                return Draw2bppTile8x8((byte)this.tile8x8Tile.Value,
                    (byte)this.tilePalette.Value,
                    this.tileAttributes.GetItemChecked(1),
                    this.tileAttributes.GetItemChecked(2),
                    this.tileAttributes.GetItemChecked(0));

        }

        private Tile8x8 Draw4bppTile8x8(int tile, byte graphicSetIndex, byte paletteSetIndex, bool mirrored, bool inverted, bool priorityOne)
        {
            int offsetChange;
            bool twobpp = false;

            paletteSetIndex--;

            if (graphicSetIndex == 0) offsetChange = 0;
            else if (graphicSetIndex == 1) offsetChange = 0x2000;
            else if (graphicSetIndex == 2) offsetChange = 0x4000;
            else if (graphicSetIndex == 3) offsetChange = 0x6000;
            else if (graphicSetIndex == 4) offsetChange = 0x8000;
            else
            {
                offsetChange = 0;
                graphicSets = null;
                MessageBox.Show("Problem with Tileset Data: graphicSetIndex invalid, Please report this", "LAZY SHELL");
                return null;
            }

            int tileDataOffset = (tile * 0x20) + offsetChange;

            if (tileDataOffset >= graphicSets.Length)
                tileDataOffset = 0;

            Tile8x8 temp;
            if (tabControl2.SelectedIndex != 4) 
                temp = new Tile8x8(tile, graphicSets, tileDataOffset, paletteSet.Get4bppPalette(paletteSetIndex), mirrored, inverted, priorityOne, twobpp);
            else 
                temp = new Tile8x8(tile, graphicSets, tileDataOffset, paletteSetBF.GetBattlefieldPalette(paletteSetIndex), mirrored, inverted, priorityOne, twobpp);
            temp.GfxSetIndex = graphicSetIndex;
            temp.PaletteSetIndex = (byte)(paletteSetIndex + 1);
            return temp;
        }
        private Tile8x8 Draw2bppTile8x8(int tile, byte paletteSetIndex, bool mirrored, bool inverted, bool priorityOne)
        {
            bool twobpp = true;

            paletteSetIndex -= 4;

            int tileDataOffset = tile * 0x10;

            if (tileDataOffset >= graphicSet5.Length)
                tileDataOffset = 0;

            Tile8x8 temp = new Tile8x8(tile, graphicSet5, tileDataOffset, paletteSet.Get2bppPalette(paletteSetIndex), mirrored, inverted, priorityOne, twobpp);
            temp.PaletteSetIndex = (byte)(paletteSetIndex + 4);
            return temp;
        }

        private void DecompressTileSetData()
        {
            // Decompress graphic sets
            if (tabControl2.SelectedIndex != 4)
            {
                graphicSets = tileSet.GraphicSets;
                graphicSet5 = tileSet.GraphicSet5;
            }
            else
                graphicSets = bts.GraphicSets;
        }

        // importing graphic sets
        private int[] ImageToArray(Bitmap image, Size max)
        {
            int w = image.Width / 8 * 8;
            int h = image.Height / 8 * 8;
            int[] temp = new int[w * h];
            for (int y = 0; y < max.Height && y < h; y++)
            {
                for (int x = 0; x < max.Width && x < w; x++)
                    temp[y * w + x] = image.GetPixel(x, y).ToArgb();
            }
            return temp;
        }
        private byte[] ArrayTo4bppTile(int[] array, int w, int h, int[] palette)
        {
            byte[] temp = new byte[(w * h) * 0x20];
            Point p;
            int offset;
            byte bit;

            ArrayToSnesPalette(array, palette);

            for (int i = 0; i < w * h; i++)   // draw each 8x8 tile
            {
                for (int y = 0; y < 8; y++)
                {
                    for (int x = 0; x < 8; x++)
                    {
                        p = new Point(i % w * 8 + x, i / w * 8 + y);
                        bit = (byte)(x ^ 7);
                        offset = i * 0x20;
                        offset += y * 2;
                        BitManager.SetBit(temp, offset, bit, (array[p.Y * (w * 8) + p.X] & 1) == 1);
                        BitManager.SetBit(temp, offset + 1, bit, (array[p.Y * (w * 8) + p.X] & 2) == 2);
                        BitManager.SetBit(temp, offset + 16, bit, (array[p.Y * (w * 8) + p.X] & 4) == 4);
                        BitManager.SetBit(temp, offset + 17, bit, (array[p.Y * (w * 8) + p.X] & 8) == 8);
                    }
                }
            }
            return temp;
        }
        private byte[] ArrayTo2bppTile(int[] array, int w, int h, int[] palette)
        {
            byte[] temp = new byte[(w * h) * 0x20];
            Point p;
            int offset;
            byte bit;

            ArrayToSnesPalette(array, palette);

            for (int i = 0; i < w * h; i++)   // draw each 8x8 tile
            {
                for (int y = 0; y < 8; y++)
                {
                    for (int x = 0; x < 8; x++)
                    {
                        p = new Point(i % w * 8 + x, i / w * 8 + y);
                        bit = (byte)(x ^ 7);
                        offset = i * 0x10;
                        offset += y * 2;
                        BitManager.SetBit(temp, offset, bit, (array[p.Y * (w * 8) + p.X] & 1) == 1);
                        BitManager.SetBit(temp, offset + 1, bit, (array[p.Y * (w * 8) + p.X] & 2) == 2);
                    }
                }
            }
            return temp;
        }
        private void ArrayToSnesPalette(int[] array, int[] palette)
        {
            Color[] colors = new Color[palette.Length];

            double distance = 500.0;
            double temp;

            double r, g, b;
            double dbl_test_red;
            double dbl_test_green;
            double dbl_test_blue;

            for (int i = 0; i < palette.Length; i++)
                colors[i] = Color.FromArgb(palette[i]);

            for (int i = 0; i < array.Length; i++)
            {
                distance = 500;
                r = Convert.ToDouble(Color.FromArgb(array[i]).R);
                g = Convert.ToDouble(Color.FromArgb(array[i]).G);
                b = Convert.ToDouble(Color.FromArgb(array[i]).B);
                int nearest_color = 0;
                Color o;

                for (int v = 1; v < colors.Length; v++)
                {
                    o = colors[v];

                    dbl_test_red = Math.Pow(Convert.ToDouble(((Color)o).R) - r, 2.0);
                    dbl_test_green = Math.Pow(Convert.ToDouble(((Color)o).G) - g, 2.0);
                    dbl_test_blue = Math.Pow(Convert.ToDouble(((Color)o).B) - b, 2.0);

                    temp = Math.Sqrt(dbl_test_blue + dbl_test_green + dbl_test_red);

                    // explore the result and store the nearest color
                    if (temp == 0.0)
                    {
                        nearest_color = v;
                        break;
                    }
                    else if (temp < distance)
                    {
                        distance = temp;
                        nearest_color = v;
                    }
                }
                if (array[i] != 0)
                    array[i] = nearest_color;
            }
        }
        private void CopyOverGraphicBlock(byte[] src, byte[] dest, Size s, int colspan, int tileSize, int x, int y, int offset)
        {
            Point p;
            for (int b = 0; b < s.Height; b++)
            {
                for (int a = 0; a < s.Width; a++)
                {
                    p = new Point(x + a, y + b);

                    for (int i = 0; i < tileSize; i++)
                    {
                        if ((p.Y * colspan * tileSize + (p.X * tileSize) + i + offset) >= dest.Length) return;

                        dest[p.Y * colspan * tileSize + (p.X * tileSize) + i + offset] = src[b * s.Width * tileSize + (a * tileSize) + i];
                    }
                }
            }
        }

        #endregion

        #region Event Handlers

        private void tileGFXSet_ValueChanged(object sender, EventArgs e)
        {
            if (updatingSubtile) return;

            if (tabControl2.SelectedIndex != 4)
            {
                this.tileSet.TileSetLayers[currentLayer][(ushort)currentTile].IsBeingModified = true;
                this.tileSet.TileSetLayers[currentLayer][(ushort)currentTile].SetSubtile(CreateNewSubtile(), currentSubtile);
            }
            else
                this.bts.TileSetLayer[(ushort)currentTile].SetSubtile(CreateNewSubtile(), currentSubtile);

            SetTileImage();
            SetSubtileImage();
            SetGraphicSetImage();
        }
        private void tilePalette_ValueChanged(object sender, EventArgs e)
        {
            if (updatingSubtile) return;

            if (tabControl2.SelectedIndex != 4)
            {
                this.tileSet.TileSetLayers[currentLayer][(ushort)currentTile].IsBeingModified = true;
                this.tileSet.TileSetLayers[currentLayer][(ushort)currentTile].SetSubtile(CreateNewSubtile(), currentSubtile);
            }
            else
                this.bts.TileSetLayer[(ushort)currentTile].SetSubtile(CreateNewSubtile(), currentSubtile);
            SetTileImage();
            SetSubtileImage();
            SetGraphicSetImage();
            SetPaletteImage();
        }
        private void tileAttributes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updatingSubtile) return;

            if (tabControl2.SelectedIndex != 4)
                this.tileSet.TileSetLayers[currentLayer][(ushort)currentTile].SetSubtile(CreateNewSubtile(), currentSubtile);
            else
                this.bts.TileSetLayer[(ushort)currentTile].SetSubtile(CreateNewSubtile(), currentSubtile);
            SetTileImage();
            SetSubtileImage();
        }
        private void tile8x8Tile_ValueChanged(object sender, EventArgs e)
        {
            if (updatingSubtile) return;

            if (tabControl2.SelectedIndex != 4)
                this.tileSet.TileSetLayers[currentLayer][(ushort)currentTile].SetSubtile(CreateNewSubtile(), currentSubtile);
            else
                this.bts.TileSetLayer[(ushort)currentTile].SetSubtile(CreateNewSubtile(), currentSubtile);
            SetTileImage();
            SetSubtileImage();
        }

        private void pictureBoxSubtile_Paint(object sender, PaintEventArgs e)
        {
            if (subtileImage != null)
                e.Graphics.DrawImage(subtileImage, 0, 0);
        }
        private void pictureBoxTile_MouseClick(object sender, MouseEventArgs e)
        {
            currentSubtile = e.X / 16 + ((e.Y / 16) * 2);

            InitializeSubtile();
            SetSubtileImage();
            SetGraphicSetImage();
            SetPaletteImage();
        }
        private void pictureBoxTile_Paint(object sender, PaintEventArgs e)
        {
            if (tileImage != null)
                e.Graphics.DrawImage(tileImage, 0, 0);

            if (showGrid.Checked)
            {
                Color c = Color.Gray;
                Pen p = new Pen(new SolidBrush(c));
                Point h = new Point();
                Point v = new Point();
                for (h.Y = 16; h.Y < 32; h.Y += 16)
                    e.Graphics.DrawLine(p, h, new Point(h.X + 256, h.Y));
                for (v.X = 16; v.X < 32; v.X += 16)
                    e.Graphics.DrawLine(p, v, new Point(v.X, v.Y + 256));
            }
        }

        private void pictureBoxPalette_MouseClick(object sender, MouseEventArgs e)
        {
            pictureBoxPalette.Focus();

            currentColorTE = e.X / 16;

            pictureBoxPalette.Invalidate();
        }
        private void pictureBoxPalette_Paint(object sender, PaintEventArgs e)
        {
            if (paletteImage != null)
                e.Graphics.DrawImage(paletteImage, 0, 0);

            Point p = new Point(currentColorTE % 16 * 16, currentColorTE / 16 * 16);
            if (p.Y == 0) p.Y++;
            overlay.DrawSelectionBox(e.Graphics, new Point(p.X + 15, p.Y + 15 - (p.Y % 16)), p, 1);
        }

        private void pictureBoxGraphicSet_Paint(object sender, PaintEventArgs e)
        {
            if (graphicSetImage == null) return;

            Rectangle rsrc = new Rectangle(0, 0, graphicSetImage.Width, graphicSetImage.Height);
            Rectangle rdst = new Rectangle(0, 0, graphicSetImage.Width * zoomG, graphicSetImage.Height * zoomG);
            e.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            e.Graphics.DrawImage(graphicSetImage, rdst, rsrc, GraphicsUnit.Pixel);

            Size s = new Size(graphicSetImage.Width * zoomG, graphicSetImage.Height * zoomG);
            if (zoomG >= 4 && graphicShowPixelGrid.Checked)
                overlay.DrawCartographicGrid(e.Graphics, Color.DarkRed, s, new Size(1, 1), zoomG);
            if (graphicShowGrid.Checked)
                overlay.DrawCartographicGrid(e.Graphics, Color.Gray, s, new Size(8, 8), zoomG);
        }
        private void pictureBoxGraphicSet_MouseDown(object sender, MouseEventArgs e)
        {
            Point p;
            if ((graphicZoomIn.Checked && e.Button == MouseButtons.Left) || (graphicZoomOut.Checked && e.Button == MouseButtons.Right))
            {
                if (zoomG < 8)
                {
                    zoomG *= 2;

                    p = new Point(Math.Abs(pictureBoxGraphicSet.Left), Math.Abs(pictureBoxGraphicSet.Top));
                    p.X += e.X;
                    p.Y += e.Y;

                    pictureBoxGraphicSet.Width = 128 * zoomG;
                    pictureBoxGraphicSet.Height = 128 * zoomG;
                    panel6.AutoScrollPosition = p;
                    pictureBoxGraphicSet.Invalidate();
                    return;
                }
                return;
            }
            else if ((graphicZoomOut.Checked && e.Button == MouseButtons.Left) || (graphicZoomIn.Checked && e.Button == MouseButtons.Right))
            {
                if (zoomG > 1)
                {
                    zoomG /= 2;

                    p = new Point(Math.Abs(pictureBoxGraphicSet.Left), Math.Abs(pictureBoxGraphicSet.Top));
                    p.X -= e.X / 2;
                    p.Y -= e.Y / 2;

                    pictureBoxGraphicSet.Width = 128 * zoomG;
                    pictureBoxGraphicSet.Height = 128 * zoomG;
                    panel6.AutoScrollPosition = p;
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

            tile8x8Tile.Value = mouseOverSubTile;
        }
        private void pictureBoxGraphicSet_MouseMove(object sender, MouseEventArgs e)
        {
            mouseOverControl = pictureBoxGraphicSet.Name;
            mouseOverSubTile = (e.Y / (8 * zoomG)) * 16 + (e.X / (8 * zoomG)); // Calculate tile number

            // editing
            byte[] graphics = currentLayer != 2 ? graphicSets : graphicSet5;

            if (e.X > pictureBoxGraphicSet.Width || e.Y > pictureBoxGraphicSet.Height || e.X < 0 || e.Y < 0) return;

            byte row = (byte)(e.Y / zoomG % 8);
            byte col = (byte)(e.X / zoomG % 8);
            byte bit = (byte)(col ^ 7);
            int offset = mouseOverSubTile * 0x20;
            switch ((int)tileGFXSet.Value)
            {
                case 1: offset += 0x2000; break;
                case 2: offset += 0x4000; break;
                default: break;
            }
            offset += row * 2;

            int index = (int)(tilePalette.Value - 1);
            int r, g, b;
            int temp = 0;
            if (e.Button == MouseButtons.Left)
            {
                //if (currentPixel == (e.X / zoomG) + (e.Y / zoomG)) 
                //    return;
                if (subtileDraw.Checked)
                {
                    if (tabControl2.SelectedIndex != 4)
                    {
                        r = paletteSet.PaletteColorRed[(int)(currentColorTE + (index * 16))];
                        g = paletteSet.PaletteColorGreen[(int)(currentColorTE + (index * 16))];
                        b = paletteSet.PaletteColorBlue[(int)(currentColorTE + (index * 16))];
                    }
                    else
                    {
                        r = paletteSet.PaletteColorRedBF[(int)(currentColorTE + (index * 16))];
                        g = paletteSet.PaletteColorGreenBF[(int)(currentColorTE + (index * 16))];
                        b = paletteSet.PaletteColorBlueBF[(int)(currentColorTE + (index * 16))];
                    }
                    Rectangle n = new Rectangle(new Point(e.X - (e.X % zoomG), e.Y - (e.Y % zoomG)), new Size(zoomG, zoomG));
                    BitManager.SetBit(graphics, offset, bit, (currentColorTE & 1) == 1);
                    BitManager.SetBit(graphics, offset + 1, bit, (currentColorTE & 2) == 2);
                    BitManager.SetBit(graphics, offset + 16, bit, (currentColorTE & 4) == 4);
                    BitManager.SetBit(graphics, offset + 17, bit, (currentColorTE & 8) == 8);

                    Point p = new Point(e.X / zoomG * zoomG, e.Y / zoomG * zoomG);
                    Rectangle c;
                    if (zoomG >= 4 && graphicShowPixelGrid.Checked)
                        c = new Rectangle(p, new Size(zoomG - 1, zoomG - 1));
                    else
                        c = new Rectangle(p, new Size(zoomG, zoomG));
                    pictureBoxGraphicSet.CreateGraphics().FillRectangle(new SolidBrush(Color.FromArgb(r, g, b)), c);
                }
                else if (subtileErase.Checked)
                {
                    if (tabControl2.SelectedIndex != 4)
                    {
                        r = paletteSet.PaletteColorRed[0];
                        g = paletteSet.PaletteColorGreen[0];
                        b = paletteSet.PaletteColorBlue[0];
                    }
                    else
                    {
                        r = paletteSet.PaletteColorRedBF[0];
                        g = paletteSet.PaletteColorGreenBF[0];
                        b = paletteSet.PaletteColorBlueBF[0];
                    }
                    BitManager.SetBit(graphics, offset, bit, false);
                    BitManager.SetBit(graphics, offset + 1, bit, false);
                    BitManager.SetBit(graphics, offset + 16, bit, false);
                    BitManager.SetBit(graphics, offset + 17, bit, false);

                    Point p = new Point(e.X / zoomG * zoomG, e.Y / zoomG * zoomG);
                    Rectangle c;
                    if (zoomG >= 4 && graphicShowPixelGrid.Checked)
                        c = new Rectangle(p, new Size(zoomG - 1, zoomG - 1));
                    else
                        c = new Rectangle(p, new Size(zoomG, zoomG));
                    pictureBoxGraphicSet.CreateGraphics().FillRectangle(new SolidBrush(Color.FromArgb(r, g, b)), c);
                }
                else if (subtileDropper.Checked)
                {
                    if (BitManager.GetBit(graphics, offset, bit)) temp |= 1;
                    if (BitManager.GetBit(graphics, offset + 1, bit)) temp |= 2;
                    if (BitManager.GetBit(graphics, offset + 16, bit)) temp |= 4;
                    if (BitManager.GetBit(graphics, offset + 17, bit)) temp |= 8;
                    currentColorTE = temp;
                    pictureBoxPalette.Invalidate();
                }
                currentPixel = (e.X / zoomG) + (e.Y / zoomG);
            }
            else if (e.Button == MouseButtons.Right)
            {
                if (currentPixel == (e.X / zoomG) + (e.Y / zoomG)) return;
                if (subtileDraw.Checked)
                {
                    if (tabControl2.SelectedIndex != 4)
                    {
                        r = paletteSet.PaletteColorRed[0];
                        g = paletteSet.PaletteColorGreen[0];
                        b = paletteSet.PaletteColorBlue[0];
                    }
                    else
                    {
                        r = paletteSet.PaletteColorRedBF[0];
                        g = paletteSet.PaletteColorGreenBF[0];
                        b = paletteSet.PaletteColorBlueBF[0];
                    }
                    BitManager.SetBit(graphics, offset, bit, false);
                    BitManager.SetBit(graphics, offset + 1, bit, false);
                    BitManager.SetBit(graphics, offset + 16, bit, false);
                    BitManager.SetBit(graphics, offset + 17, bit, false);

                    Point p = new Point(e.X / zoomG * zoomG, e.Y / zoomG * zoomG);
                    Rectangle c;
                    if (zoomG >= 4 && graphicShowPixelGrid.Checked)
                        c = new Rectangle(p, new Size(zoomG - 1, zoomG - 1));
                    else
                        c = new Rectangle(p, new Size(zoomG, zoomG));
                    pictureBoxGraphicSet.CreateGraphics().FillRectangle(new SolidBrush(Color.FromArgb(r, g, b)), c);
                }
                else if (subtileDropper.Checked)
                {
                    if (BitManager.GetBit(graphics, offset, bit)) temp |= 1;
                    if (BitManager.GetBit(graphics, offset + 1, bit)) temp |= 2;
                    if (BitManager.GetBit(graphics, offset + 16, bit)) temp |= 4;
                    if (BitManager.GetBit(graphics, offset + 17, bit)) temp |= 8;
                    currentColorTE = temp;
                    pictureBoxPalette.Invalidate();
                }
                currentPixel = (e.X / zoomG) + (e.Y / zoomG);
            }
        }
        private void pictureBoxGraphicSet_MouseUp(object sender, MouseEventArgs e)
        {
            if (!subtileDraw.Checked && !subtileErase.Checked) return;

            if (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right)
            {
                if (tabControl2.SelectedIndex != 4)
                    this.tileSet.TileSetLayers[currentLayer][(ushort)currentTile].SetSubtile(CreateNewSubtile(), currentSubtile);
                else
                    this.bts.TileSetLayer[(ushort)currentTile].SetSubtile(CreateNewSubtile(), currentSubtile);

                SetTileImage();
                SetSubtileImage();
                SetGraphicSetImage();
            }
        }

        private void showGrid_Click(object sender, EventArgs e)
        {
            showGrid.ForeColor = showGrid.Checked ? Color.Black : Color.Gray;

            SetTileImage();
        }

        // Graphic Set Editor context menu items
        private void setSubtileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.tile8x8Tile.Value = mouseOverSubTile;
        }
        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            string path = SelectFile("Select the graphic block to import", "Image files (*.bmp,*.png,*.gif,*.jpg)|*.bmp;*.png;*.gif;*.jpg|Binary files (*.bin)|*.bin|All files (*.*)|*.*");

            if (path == null) return;

            FileStream fs;
            BinaryReader br;
            Bitmap import;

            byte[] graphicBlock = new byte[0x4000];
            int offset;
            switch ((int)tileGFXSet.Value)
            {
                case 0: offset = 0; break;
                case 1: offset = 0x2000; break;
                case 2: offset = 0x3000; break;
                default: offset = 0; break;
            }
            int[] palette;
            if (tabControl2.SelectedIndex != 4)
                palette = paletteSet.Get4bppPalette((int)(tilePalette.Value - 1));
            else
                palette = paletteSetBF.GetBattlefieldPalette((int)(tilePalette.Value - 1));

            try
            {
                fs = File.OpenRead(path);

                if (Path.GetExtension(path) == ".jpg" || Path.GetExtension(path) == ".gif" || Path.GetExtension(path) == ".png")
                {
                    import = new Bitmap(Image.FromFile(path));
                    graphicBlock = ArrayTo4bppTile(ImageToArray(import, new Size(128, 128)), import.Width / 8, import.Height / 8, palette);
                    CopyOverGraphicBlock(
                        graphicBlock, graphicSets, new Size(import.Width / 8, import.Height / 8), 16, 0x20,
                        (mouseOverSubTile - 1) % 16,
                        (mouseOverSubTile - 1) / 16,
                        offset);
                }
                else
                {
                    br = new BinaryReader(fs);
                    graphicBlock = br.ReadBytes((int)fs.Length);
                    graphicBlock.CopyTo(graphicSets, offset + (mouseOverSubTile - 1 * 0x20));
                    br.Close();
                }

                fs.Close();
                SetTileImage();
                SetSubtileImage();
                SetGraphicSetImage();
            }
            catch
            {
                MessageBox.Show("There was a problem loading the file.", "LAZY SHELL");
                return;
            }
        }
        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Binary files (*.bin)|*.bin|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 0;
            if (tabControl2.SelectedIndex != 4)
            {
                if (currentLayer != 2)
                    saveFileDialog.FileName = "graphicSet." + (levelMap.GraphicSetA + 0x48).ToString("d3") + "-" + levelMap.GraphicSetE.ToString("d3");
                else
                    saveFileDialog.FileName = "graphicSet." + (battlefields[(int)battlefieldNum.Value].GraphicSetA + 0x48).ToString("d3") + "-" + battlefields[(int)battlefieldNum.Value].GraphicSetE.ToString("d3");
            }
            else
                saveFileDialog.FileName = "graphicSet." + levelMap.GraphicSetL3.ToString("d3");
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() != DialogResult.OK)
                return;

            byte[] graphicBlock;

            switch ((int)tileGFXSet.Value)
            {
                default: graphicBlock = BitManager.GetByteArray(graphicSets, 0, 0x2000); break;
                case 1: graphicBlock = BitManager.GetByteArray(graphicSets, 0x2000, 0x2000); break;
                case 2: graphicBlock = BitManager.GetByteArray(graphicSets, 0x3000, 0x2000); break;
            }

            FileStream fs;
            BinaryWriter bw;
            try
            {
                // Create the file to store the level data
                fs = new FileStream(saveFileDialog.FileName + ".bin", FileMode.Create, FileAccess.ReadWrite);
                bw = new BinaryWriter(fs);
                bw.Write(graphicBlock);
                bw.Close();
                fs.Close();
            }
            catch
            {
                MessageBox.Show("There was a problem exporting the graphic block.", "LAZY SHELL");
            }
        }
        private void saveImageToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PNG files (*.png)|*.png|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.FileName = "graphicSet.Screen.png";
            saveFileDialog.RestoreDirectory = true;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
                graphicSetImage.Save(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Png);
        }
        private void clearToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            byte[] temp;
            if (currentLayer != 2)
            {
                temp = new byte[0x2000];
                switch ((int)tileGFXSet.Value)
                {
                    case 0:
                        temp.CopyTo(graphicSets, 0);
                        break;
                    case 1:
                        temp.CopyTo(graphicSets, 0x2000);
                        break;
                    case 2:
                        temp.CopyTo(graphicSets, 0x3000);
                        break;
                }
            }
            else
            {
                temp = new byte[model.GraphicSets[levelMap.GraphicSetL3].Length];
                temp.CopyTo(graphicSet5, temp.Length);
            }

            SetTileImage();
            SetSubtileImage();
            SetGraphicSetImage();
        }

        // Graphic Set Editor toolstrip buttons
        private void graphicZoomIn_Click(object sender, EventArgs e)
        {
            graphicZoomOut.Checked = false;
            if (graphicZoomIn.Checked)
                pictureBoxGraphicSet.Cursor = new Cursor(GetType(), "CursorZoomIn.cur");
            else
                pictureBoxGraphicSet.Cursor = System.Windows.Forms.Cursors.Arrow;

            if (graphicZoomIn.Checked)
                pictureBoxGraphicSet.ContextMenuStrip = null;
            else
                pictureBoxGraphicSet.ContextMenuStrip = contextMenuStripTE;
        }
        private void graphicZoomOut_Click(object sender, EventArgs e)
        {
            graphicZoomIn.Checked = false;
            if (graphicZoomOut.Checked)
                pictureBoxGraphicSet.Cursor = new Cursor(GetType(), "CursorZoomOut.cur");
            else
                pictureBoxGraphicSet.Cursor = System.Windows.Forms.Cursors.Arrow;

            if (graphicZoomOut.Checked)
                pictureBoxGraphicSet.ContextMenuStrip = null;
            else
                pictureBoxGraphicSet.ContextMenuStrip = contextMenuStripTE;
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
            graphicZoomIn.Checked = false;
            graphicZoomOut.Checked = false;

            if (!subtileDropper.Checked)
                pictureBoxGraphicSet.Cursor = Cursors.Arrow;
            else
                pictureBoxGraphicSet.Cursor = new System.Windows.Forms.Cursor(GetType(), "CursorDropper.cur");
        }

        // moving the panels
        private void labelTileEditor_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            panelTileEditor.BringToFront();
            panelTileEditorMax = !panelTileEditorMax;

            if (!panelTileEditorMax)
            {
                label67.Visible = true;
                panelTileEditor.Size = new Size(260, 426);
                panelTileEditor.Location = new Point(rightEdge - panelTileEditor.Width, 98);
                panelTileEditor.Anchor = (AnchorStyles)(AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right);
            }
            else
            {
                Size s = panel1.Size;
                label67.Visible = false;
                panelTileEditor.Location = panel1.Location;
                panelTileEditor.Size = new Size(s.Width, s.Height);
                panelTileEditor.Anchor = (AnchorStyles)(AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
            }
        }
        private void labelTileEditor_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Clicks > 1)
                return;

            mousePos.X = e.X;
            mousePos.Y = e.Y;

            panelTileEditor.BringToFront();
            movingPanelTileEditor = true;

            this.Capture = true;
        }
        private void labelTileEditor_MouseUp(object sender, MouseEventArgs e)
        {
            movingPanelTileEditor = false;
        }
        private void panelTileEditor_MouseDown(object sender, MouseEventArgs e)
        {
            resizingPanelTileEditor = true;
            SizeRight = SizeBottom = SizeBottomRight = false;

            Size s = panelTileEditor.Size;

            if (e.X > s.Width - 4 && e.Y > s.Height - 4)
                SizeBottomRight = true;
            else if (e.X > s.Width - 4)
                SizeRight = true;
            else if (e.Y > s.Height - 4)
                SizeBottom = true;
            else
            {
                resizingPanelTileEditor = false;
                return;
            }

            panelTileEditor.BringToFront();
        }
        private void panelTileEditor_MouseMove(object sender, MouseEventArgs e)
        {
            if (movingPanelImageGraphics)
            {
                panelImageGraphics.Left = e.X - mousePos.X - 2;
                panelImageGraphics.Top = e.Y - mousePos.Y - 2;
                pictureBoxGraphicSet.Invalidate();
                return;
            }

            Point newMousePosition = new Point(e.X, e.Y);
            if (e.Button == MouseButtons.Left && resizingPanelTileEditor)
            {
                int deltaX = newMousePosition.X - oldMousePosition.X;
                int deltaY = newMousePosition.Y - oldMousePosition.Y;

                // resize bottom
                if (SizeBottom || SizeBottomRight)
                    panelTileEditor.Height += deltaY;
                // resize right
                if (SizeRight || SizeBottomRight)
                    panelTileEditor.Width += deltaX;

                pictureBoxGraphicSet.Invalidate();
            }
            else
                resizingPanelTileEditor = false;

            oldMousePosition = newMousePosition;

            if (resizingPanelTileEditor)
                return;

            Size s = panelTileEditor.Size;

            if (e.X > s.Width - 4 && e.Y > s.Height - 4)
                panelTileEditor.Cursor = Cursors.SizeNWSE;
            else if (e.X > s.Width - 4 && e.Y < 4)
                panelTileEditor.Cursor = Cursors.SizeNESW;
            else if (e.X > s.Width - 4)
                panelTileEditor.Cursor = Cursors.SizeWE;
            else if (e.Y > s.Height - 4)
                panelTileEditor.Cursor = Cursors.SizeNS;
            else
                panelTileEditor.Cursor = Cursors.Arrow;
        }
        private void panelTileEditor_MouseLeave(object sender, EventArgs e)
        {
            panelTileEditor.Cursor = Cursors.Arrow;
            resizingPanelTileEditor = false;
            movingPanelTileEditor = false;
            SizeRight = SizeBottom = SizeBottomRight = false;
        }
        private void panelTileEditor_MouseUp(object sender, MouseEventArgs e)
        {
            movingPanelImageGraphics = false;
        }

        private void panelImageGraphics_MouseDown(object sender, MouseEventArgs e)
        {
            resizingPanelImageGraphics = true;
            SizeRight = SizeBottom = SizeBottomRight = false;

            Size s = panelImageGraphics.Size;

            if (e.X > s.Width - 4 && e.Y > s.Height - 4)
                SizeBottomRight = true;
            else if (e.X > s.Width - 4)
                SizeRight = true;
            else if (e.Y > s.Height - 4)
                SizeBottom = true;
            else
            {
                resizingPanelImageGraphics = false;
                return;
            }

            panelImageGraphics.BringToFront();
        }
        private void panelImageGraphics_MouseLeave(object sender, EventArgs e)
        {
            panelImageGraphics.Cursor = Cursors.Arrow;
            resizingPanelImageGraphics = false;
            movingPanelImageGraphics = false;
            SizeRight = SizeBottom = SizeBottomRight = false;
        }
        private void panelImageGraphics_MouseMove(object sender, MouseEventArgs e)
        {
            Point newMousePosition = new Point(e.X, e.Y);
            if (e.Button == MouseButtons.Left && resizingPanelImageGraphics)
            {
                int deltaX = newMousePosition.X - oldMousePosition.X;
                int deltaY = newMousePosition.Y - oldMousePosition.Y;

                // resize bottom
                if (SizeBottom || SizeBottomRight)
                    panelImageGraphics.Height += deltaY;
                // resize right
                if (SizeRight || SizeBottomRight)
                    panelImageGraphics.Width += deltaX;

                pictureBoxGraphicSet.Invalidate();
            }
            else
                resizingPanelImageGraphics = false;

            oldMousePosition = newMousePosition;

            if (resizingPanelImageGraphics)
                return;

            Size s = panelImageGraphics.Size;

            if (e.X > s.Width - 4 && e.Y > s.Height - 4)
                panelImageGraphics.Cursor = Cursors.SizeNWSE;
            else if (e.X > s.Width - 4 && e.Y < 4)
                panelImageGraphics.Cursor = Cursors.SizeNESW;
            else if (e.X > s.Width - 4)
                panelImageGraphics.Cursor = Cursors.SizeWE;
            else if (e.Y > s.Height - 4)
                panelImageGraphics.Cursor = Cursors.SizeNS;
            else
                panelImageGraphics.Cursor = Cursors.Arrow;
        }
        private void labelImageGraphics_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            panelImageGraphics.BringToFront();
            panelImageGraphicsMax = !panelImageGraphicsMax;

            if (!panelImageGraphicsMax)
            {
                panelImageGraphics.Location = new Point(-2, 109);
                panelImageGraphics.Size = new Size(260, 296);
                panelImageGraphics.Anchor = (AnchorStyles)(AnchorStyles.Top | AnchorStyles.Left);
            }
            else
            {
                Size s = panelTileEditor.Size;
                panelImageGraphics.Location = new Point(-2, -2);
                panelImageGraphics.Size = new Size(s.Width + 4, s.Height + 4);
                panelImageGraphics.Anchor = (AnchorStyles)(AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
            }
        }
        private void labelImageGraphics_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Clicks > 1)
                return;

            mousePos.X = e.X;
            mousePos.Y = e.Y;

            panelImageGraphics.BringToFront();
            movingPanelImageGraphics = true;

            panelTileEditor.Capture = true;
        }
        private void labelImageGraphics_MouseUp(object sender, MouseEventArgs e)
        {
            movingPanelImageGraphics = false;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            int offset = 0;
            int tileSubTile = 0;
            int tilePaletteIndex = 0;
            int tileGraphicSet = 0;
            bool tilePriorityOne = false;
            bool tileMirrored = false;
            bool tileInverted = false;

            if (tabControl2.SelectedIndex != 4)
            {
                tileSet.TileSetLayers[currentLayer][(ushort)currentTile].ConfirmChanges();
                for (int i = 0; i < 4; i++)
                {
                    tileSubTile = tileSet.TileSetLayers[currentLayer][(ushort)currentTile].GetSubtile(i).TileNum;
                    if (currentLayer != 2)
                        tileGraphicSet = tileSet.TileSetLayers[currentLayer][(ushort)currentTile].GetSubtile(i).GfxSetIndex;
                    tilePaletteIndex = tileSet.TileSetLayers[currentLayer][(ushort)currentTile].GetSubtile(i).PaletteSetIndex;
                    tilePriorityOne = tileSet.TileSetLayers[currentLayer][(ushort)currentTile].GetSubtile(i).PriorityOne;
                    tileMirrored = tileSet.TileSetLayers[currentLayer][(ushort)currentTile].GetSubtile(i).Mirrored;
                    tileInverted = tileSet.TileSetLayers[currentLayer][(ushort)currentTile].GetSubtile(i).Inverted;

                    offset = currentTile * 4;
                    if (i % 2 == 1) offset += 2;
                    if (i / 2 == 1) offset += 64;
                    offset += (currentTile / 16) * 64;

                    BitManager.SetShort(tileSet.TileSets[currentLayer], offset, (ushort)tileSubTile);
                    BitManager.SetByte(tileSet.TileSets[currentLayer], offset + 1, (byte)((tilePaletteIndex * 4) + tileGraphicSet));
                    BitManager.SetBit(tileSet.TileSets[currentLayer], offset + 1, 5, tilePriorityOne);
                    BitManager.SetBit(tileSet.TileSets[currentLayer], offset + 1, 6, tileMirrored);
                    BitManager.SetBit(tileSet.TileSets[currentLayer], offset + 1, 7, tileInverted);
                }

                // edit flag
                switch (currentLayer)
                {
                    case 0: model.EditTileSets[levelMap.TileSetL1 + 0x20] = true; break;
                    case 1: model.EditTileSets[levelMap.TileSetL2 + 0x20] = true; break;
                    case 2: model.EditTileSets[levelMap.TileSetL3] = true; break;
                }

                if (currentLayer != 2)
                {
                    Buffer.BlockCopy(graphicSets, 0, model.GraphicSets[levelMap.GraphicSetA + 0x48], 0, 0x2000);
                    Buffer.BlockCopy(graphicSets, 0x2000, model.GraphicSets[levelMap.GraphicSetB + 0x48], 0, 0x1000);
                    Buffer.BlockCopy(graphicSets, 0x3000, model.GraphicSets[levelMap.GraphicSetC + 0x48], 0, 0x1000);
                    Buffer.BlockCopy(graphicSets, 0x4000, model.GraphicSets[levelMap.GraphicSetD + 0x48], 0, 0x1000);
                    Buffer.BlockCopy(graphicSets, 0x5000, model.GraphicSets[levelMap.GraphicSetE + 0x48], 0, 0x1000);

                    model.EditGraphicSets[levelMap.GraphicSetA + 0x48] = true;
                    model.EditGraphicSets[levelMap.GraphicSetB + 0x48] = true;
                    model.EditGraphicSets[levelMap.GraphicSetC + 0x48] = true;
                    model.EditGraphicSets[levelMap.GraphicSetD + 0x48] = true;
                    model.EditGraphicSets[levelMap.GraphicSetE + 0x48] = true;
                }
                else
                {
                    model.GraphicSets[levelMap.GraphicSetL3] = graphicSet5;
                    graphicSet5.CopyTo(tileSet.GraphicSet5, 0);

                    model.EditGraphicSets[levelMap.GraphicSetL3] = true;
                }

            }
            else
            {
                bts.TileSetLayer[(ushort)currentTile].ConfirmChanges();
                for (int i = 0; i < 4; i++)
                {
                    tileSubTile = bts.TileSetLayer[(ushort)currentTile].GetSubtile(i).TileNum;
                    tileGraphicSet = bts.TileSetLayer[(ushort)currentTile].GetSubtile(i).GfxSetIndex;
                    tilePaletteIndex = bts.TileSetLayer[(ushort)currentTile].GetSubtile(i).PaletteSetIndex;
                    tilePriorityOne = bts.TileSetLayer[(ushort)currentTile].GetSubtile(i).PriorityOne;
                    tileMirrored = bts.TileSetLayer[(ushort)currentTile].GetSubtile(i).Mirrored;
                    tileInverted = bts.TileSetLayer[(ushort)currentTile].GetSubtile(i).Inverted;

                    offset = currentTile * 4;
                    if (i % 2 == 1) offset += 2;
                    if (i / 2 == 1) offset += 64;
                    offset += (currentTile / 16) * 64;
                    //offset += currentTile > 511 ? 0x800 : 0;

                    BitManager.SetShort(bts.TileSet, offset, (ushort)tileSubTile);
                    BitManager.SetByte(bts.TileSet, offset + 1, (byte)((tilePaletteIndex * 4) + tileGraphicSet));
                    BitManager.SetBit(bts.TileSet, offset + 1, 5, tilePriorityOne);
                    BitManager.SetBit(bts.TileSet, offset + 1, 6, tileMirrored);
                    BitManager.SetBit(bts.TileSet, offset + 1, 7, tileInverted);
                }

                model.EditTileSetsBF[battlefields[(int)battlefieldNum.Value].TileSet] = true;
                RefreshBattlefield();

                Buffer.BlockCopy(graphicSets, 0, model.GraphicSets[battlefields[(int)battlefieldNum.Value].GraphicSetA + 0x48], 0, 0x2000);
                Buffer.BlockCopy(graphicSets, 0x2000, model.GraphicSets[battlefields[(int)battlefieldNum.Value].GraphicSetB + 0x48], 0, 0x1000);
                Buffer.BlockCopy(graphicSets, 0x3000, model.GraphicSets[battlefields[(int)battlefieldNum.Value].GraphicSetC + 0x48], 0, 0x1000);
                Buffer.BlockCopy(graphicSets, 0x4000, model.GraphicSets[battlefields[(int)battlefieldNum.Value].GraphicSetD + 0x48], 0, 0x1000);
                Buffer.BlockCopy(graphicSets, 0x5000, model.GraphicSets[battlefields[(int)battlefieldNum.Value].GraphicSetE + 0x48], 0, 0x1000);

                model.EditGraphicSets[battlefields[(int)battlefieldNum.Value].GraphicSetA + 0x48] = true;
                model.EditGraphicSets[battlefields[(int)battlefieldNum.Value].GraphicSetB + 0x48] = true;
                model.EditGraphicSets[battlefields[(int)battlefieldNum.Value].GraphicSetC + 0x48] = true;
                model.EditGraphicSets[battlefields[(int)battlefieldNum.Value].GraphicSetD + 0x48] = true;
                model.EditGraphicSets[battlefields[(int)battlefieldNum.Value].GraphicSetE + 0x48] = true;
            }
            UpdateLevel();
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            if (tabControl2.SelectedIndex != 4)
                tileSet.TileSetLayers[currentLayer][(ushort)currentTile].IsBeingModified = false;
            else
                bts.TileSetLayer[(ushort)currentTile].IsBeingModified = false;

            InitializeTileEditor();
        }

        private void panel109_Scroll(object sender, ScrollEventArgs e)
        {
            pictureBoxGraphicSet.Invalidate();
        }

        #endregion
    }
}
