using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Media;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using LazyShell.Properties;
using LazyShell.EventScripts;

namespace LazyShell
{
    public static partial class Do
    {
        /// <summary>
        /// Applys a palette to a pixel array.
        /// </summary>
        /// <param name="array">The pixel array.</param>
        /// <param name="palette">The palette to apply.</param>
        /// <returns></returns>
        public static void ApplyPaletteToPixels(int[] array, int[] palette)
        {
            var colors = new Color[palette.Length];
            var newColors = new Color[palette.Length];
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
        /// <summary>
        /// Applys a palette to a region in a pixel array.
        /// </summary>
        /// <param name="array">The pixel array.</param>
        /// <param name="palette">The palette to apply.</param>
        /// <param name="src">The full region of the source.</param>
        /// <param name="dst">The region to modify.</param>
        public static void ApplyPaletteToPixels(int[] array, int[] palette, Rectangle src, Rectangle dst)
        {
            var colors = new Color[palette.Length];
            var newColors = new Color[palette.Length];
            double distance = 500.0;
            double temp;
            double r, g, b;
            double dbl_test_red;
            double dbl_test_green;
            double dbl_test_blue;
            for (int i = 0; i < palette.Length; i++)
                colors[i] = Color.FromArgb(palette[i]);
            for (int y = dst.Y; y < dst.Y + dst.Height; y++)
            {
                for (int x = dst.X; x < dst.X + dst.Width; x++)
                {
                    distance = 500;
                    r = Convert.ToDouble(Color.FromArgb(array[y * src.Width + x]).R);
                    g = Convert.ToDouble(Color.FromArgb(array[y * src.Width + x]).G);
                    b = Convert.ToDouble(Color.FromArgb(array[y * src.Width + x]).B);
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
                    if (array[y * src.Width + x] != 0)
                        array[y * src.Width + x] = nearest_color;
                }
            }
        }

        /// <summary>
        /// Converts the BPP data of an 8x8 subtile to a pixel array.
        /// </summary>
        /// <param name="subtile">The BPP data.</param>
        /// <param name="palette">The palette to use.</param>
        /// <param name="twobpp">Indicates whether to treat the data as 2bpp.</param>
        /// <returns></returns>
        public static int[] BPPtoPixels(byte[] subtile, int[] palette, bool twobpp)
        {
            int offset = 0;
            var pixels = new int[8 * 8];
            if (twobpp == false)
            {
                for (int r = 0; r < 8; r++) // Number of Rows in an 8x8 Tile
                {
                    // Get all the pixels in a row
                    byte[] row = new byte[8];
                    for (int i = 7, b = 1; i >= 0; i--, b *= 2)
                        if ((subtile[offset + r * 2 + 0x11] & b) == b)
                            row[i] += 8;
                    for (int i = 7, b = 1; i >= 0; i--, b *= 2)
                        if ((subtile[offset + r * 2 + 0x10] & b) == b)
                            row[i] += 4;
                    for (int i = 7, b = 1; i >= 0; i--, b *= 2)
                        if ((subtile[offset + r * 2 + 1] & b) == b)
                            row[i] += 2;
                    for (int i = 7, b = 1; i >= 0; i--, b *= 2)
                        if ((subtile[offset + r * 2] & b) == b)
                            row[i]++;
                    for (int c = 0; c < 8; c++) // Number of Columns in an 8x8 Tile
                    {
                        if (row[c] != 0)
                            pixels[r * 8 + c] = palette[row[c]]; // Set pixel in 8x8 tile
                    }
                }
            }
            else
            {
                byte b1, b2, t1, t2, col = 0;
                var pal = new int[4];
                for (int i = 0; i < 4; i++)
                    pal[i] = palette[i];
                for (byte i = 0; i < 8; i++)
                {
                    b1 = subtile[offset];
                    b2 = subtile[offset + 1];
                    for (byte z = 7; col < 8; z--)
                    {
                        t1 = (byte)((b1 >> z) & 1);
                        t2 = (byte)((b2 >> z) & 1);
                        if ((t2 * 2) + t1 != 0)
                            pixels[(i * 8) + col] = pal[(t2 * 2) + t1];
                        col++;
                    }
                    col = 0;
                    offset += 2;
                }
            }
            return pixels;
        }

        /// <summary>
        /// Resizes the canvas of a bitmap image.
        /// </summary>
        /// <param name="image">The image to modify.</param>
        /// <param name="width">The new width of the canvas.</param>
        /// <param name="height">The new height of the canvas.</param>
        /// <returns></returns>
        public static Bitmap CanvasSize(Bitmap image, int width, int height)
        {
            var resized = new Bitmap(width, height);
            var temp = Graphics.FromImage(resized);
            temp.DrawImage(image, 0, 0, image.Width, image.Height);
            return resized;
        }

        /// <summary>
        /// Combines an array of bitmaps into a sheet of rows with the specified dimensions.
        /// </summary>
        /// <param name="images">The array of bitmaps to combine.</param>
        /// <param name="maxwidth">The maximum width, in pixels, of each row in the combined image.</param>
        /// <param name="maxheight">The maximum height, in pixels, of the combined image.</param>
        /// <param name="tilesize">Indicates the theoretical size, in pixels, of the tiles in the images for determining the spacing between each image.</param>
        /// <param name="padedges">Indicates whether to add spacing between each image in the final output.</param>
        /// <returns></returns>
        public static Bitmap CombineImages(Bitmap[] images, int maxwidth, int maxheight, int tilesize, bool padedges)
        {
            if (images.Length == 0)
                return null;
            // pad dimensions to multiples of tilesize
            var sheet = new Bitmap(maxwidth, maxheight);
            int rowheight = 0;
            for (int i = 0, x = 0, y = 0; i < images.Length; i++)
            {
                // if need to move to a new row
                if (images[i].Width + x >= maxwidth)
                {
                    x = 0;
                    y += rowheight;
                    if (padedges && y % tilesize != 0)
                        y += tilesize - (y % tilesize);
                }
                // raise the row's height if needed
                if (images[i].Height > rowheight)
                    rowheight = images[i].Height;
                // draw image to sheet
                var temp = Graphics.FromImage(sheet);
                temp.DrawImage(images[i], x, y, Math.Min(256, images[i].Width), Math.Min(256, images[i].Height));
                //
                x += images[i].Width;
                if (padedges && x % tilesize != 0)
                    x += tilesize - (x % tilesize);
            }
            return sheet;
        }

        /// <summary>
        /// Copy a block of BPP graphics into a region in another block of BPP graphics.
        /// </summary>
        /// <param name="src">The source graphics to copy from.</param>
        /// <param name="dst">The destination graphics to copy to.</param>
        /// <param name="region">The region (in 8x8 tile units) in the destination graphics to draw to.</param>
        /// <param name="dstWidth">The width (in 8x8 tile units) of the destination graphics.</param>
        /// <param name="offset">The offset to start drawing at.</param>
        public static void CopyOverBPPGraphics(byte[] src, byte[] dst, Rectangle region, int dstWidth, int offset, byte format)
        {
            Point p;
            for (int b = 0; b < region.Height; b++)
            {
                for (int a = 0; a < region.Width; a++)
                {
                    p = new Point(region.X + a, region.Y + b);
                    for (int i = 0; i < format; i++)
                    {
                        if ((p.Y * dstWidth * format + (p.X * format) + i + offset) >= dst.Length)
                            continue;
                        if ((b * region.Width * format + (a * format) + i) >= src.Length)
                            continue;
                        dst[p.Y * dstWidth * format + (p.X * format) + i + offset] = src[b * region.Width * format + (a * format) + i];
                    }
                }
            }
        }
        /// <summary>
        /// Copy a block of 2bpp graphics into a 2bpp font table.
        /// </summary>
        /// <param name="src">The 2bpp graphics to copy from.</param>
        /// <param name="font">The font characters to copy to.</param>
        /// <param name="size">The size (in 8x8 tiles) of the 2bpp graphics to copy from.</param>
        /// <param name="palette">The palette of the font characters.</param>
        /// <returns></returns>
        public static void CopyOverFontTable(byte[] src, Fonts.Glyph[] font, Size size, int[] palette)
        {
            byte[] temp = new byte[src.Length];
            int o = 0;
            switch (font[0].Type)
            {
                case FontType.Menu: // menu
                    for (int y = 0; y < size.Height; y++)
                    {
                        if (y != 0 && y % 2 == 0) o += 0x100;
                        for (int x = 0; x < size.Width; x++)
                        {
                            if (y % 2 == 0)
                            {
                                for (int i = 0; i < 0x10; i++)
                                    temp[y * 0x180 + (x * 0x18) + i] = src[y * 0x100 + (x * 0x10) + i + o];
                                for (int i = 0; i < 0x08; i++)
                                    temp[y * 0x180 + (x * 0x18) + 0x10 + i] = src[y * 0x100 + (x * 0x10) + 0x100 + i + o];
                            }
                            else
                            {
                                for (int i = 0; i < 0x08; i++)
                                    temp[y * 0x180 + (x * 0x18) + i] = src[y * 0x100 + (x * 0x10) + i + o];
                                for (int i = 0; i < 0x10; i++)
                                    temp[y * 0x180 + (x * 0x18) + 0x08 + i] = src[y * 0x100 + (x * 0x10) + 0xF8 + i + o];
                            }
                        }
                        o ^= 8;
                    }
                    break;
                case FontType.Dialogue: // dialogue
                    for (int y = 0; y < size.Height; y++)
                    {
                        if (y != 0 && y % 2 == 0) o += 0x100;
                        for (int x = 0; x < size.Width; x++)
                        {
                            if (y % 2 == 0)
                            {
                                for (int i = 0; i < 0x10; i++)
                                    temp[y * 0x180 + (x * 0x30) + i] = src[y * 0x100 + (x * 0x20) + i + o];
                                for (int i = 0; i < 0x08; i++)
                                    temp[y * 0x180 + (x * 0x30) + 0x10 + i] = src[y * 0x100 + (x * 0x20) + 0x100 + i + o];
                                for (int i = 0; i < 0x10; i++)
                                    temp[y * 0x180 + (x * 0x30) + 0x18 + i] = src[y * 0x100 + (x * 0x20) + 0x10 + i + o];
                                for (int i = 0; i < 0x08; i++)
                                    temp[y * 0x180 + (x * 0x30) + 0x28 + i] = src[y * 0x100 + (x * 0x20) + 0x110 + i + o];
                            }
                            else
                            {
                                for (int i = 0; i < 0x08; i++)
                                    temp[y * 0x180 + (x * 0x30) + i] = src[y * 0x100 + (x * 0x20) + i + o];
                                for (int i = 0; i < 0x10; i++)
                                    temp[y * 0x180 + (x * 0x30) + 0x08 + i] = src[y * 0x100 + (x * 0x20) + 0xF8 + i + o];
                                for (int i = 0; i < 0x08; i++)
                                    temp[y * 0x180 + (x * 0x30) + 0x18 + i] = src[y * 0x100 + (x * 0x20) + 0x10 + i + o];
                                for (int i = 0; i < 0x10; i++)
                                    temp[y * 0x180 + (x * 0x30) + 0x20 + i] = src[y * 0x100 + (x * 0x20) + 0x108 + i + o];
                            }
                        }
                        o ^= 8;
                    }
                    break;
                case FontType.Description: // description
                    src.CopyTo(temp, 0);
                    break;
            }
            byte[] character;
            for (int i = 0; i * font[0].Graphics.Length < temp.Length && i < temp.Length; i++)
            {
                if (font[i].Type == FontType.Dialogue && (i == 59 || i == 61))    // skip [ and ]
                    continue;
                character = Bits.GetBytes(temp, i * font[i].Graphics.Length, font[i].Graphics.Length);
                CopyOverBPPGraphics(
                    character, font[i].Graphics,
                    new Rectangle(0, 0, font[i].MaxWidth, font[i].Height),
                    font[i].MaxWidth / 8, 0, 0x10);
                if (font[i].Type != FontType.Triangles)
                    font[i].Width = (byte)(font[i].GetRightMostPixel(palette) + 1);
            }
        }
        /// <summary>
        /// Copy a block of 4bpp graphics into a tileset.
        /// </summary>
        /// <param name="src">The raw graphics to copy from.</param>
        /// <param name="tileset">The raw tileset to copy to.</param>
        /// <param name="palettes">The set of palettes to apply.</param>
        /// <param name="paletteIndexes">The palette index of each 8x8 tile in the graphics.</param>
        /// <param name="checkIfFlipped">Check if 8x8 tiles are mirrors or inversions of another, and cull the graphics accordingly.</param>
        /// <param name="priority1">Sets whether or not the tiles in the tileset will be priority 1.</param>
        /// <param name="tileSize">The tile size, either 0x10 or 0x20 (2bpp and 4bpp, respectively).</param>
        /// <param name="tileLength">Length, in bytes, of an 8x8 tile in a tileset. Either one or two.</param>
        /// <param name="tilesetSize">Size, in pixels, of the tileset being drawn to.</param>
        /// <param name="tileIndexStart">The index to start writing tilenums to the tileset. Normally 0, 1, or 2</param>
        public static void CopyToTileset(byte[] src, byte[] tileset, int[][] palettes, int[] paletteIndexes,
            bool checkIfFlipped, bool priority1, byte tileSize, byte tileLength, Size tilesetSize, int tileIndexStart)
        {
            var tiles_a = new List<Subtile>();    // the tileset, essentially, in array form
            var tiles_b = new List<Subtile>();    // used for redrawing a culled 4bpp graphic block
            var tiles_c = new List<Subtile>();
            for (int i = 0; i < src.Length / tileSize; i++)
            {
                var temp = new Subtile(i, src, i * tileSize, palettes[paletteIndexes[i]], false, false, false, false);
                tiles_a.Add(temp);
                tiles_b.Add(temp);
                tiles_c.Add(temp);
            }
            // look through entire set of tiles for duplicates
            for (int a = 0; a < tiles_a.Count; a++)
            {
                var tile_a = (Subtile)tiles_a[a];
                if (tile_a.Index != a) continue;  // skip if already set as duplicate
                for (int b = a; b < tiles_a.Count; b++)
                {
                    var tile_b = (Subtile)tiles_a[b];
                    if (a == b) continue;   // cannot be duplicate of self
                    if (Bits.Compare(tile_a.Pixels, tile_b.Pixels)) // if a duplicate...
                    {
                        // first set the tile to the one that it's a duplicate of
                        tile_b.Index = a;
                        // then remove
                        tiles_b.Remove(tile_b);
                    }
                    if (checkIfFlipped)
                    {
                        byte status = GetFlippedStatus(tile_a.Pixels, tile_b.Pixels);
                        if ((status & 0x40) == 0x40)
                        {
                            tile_b.Mirror = true;
                            tile_b.Index = a;
                            tiles_b.Remove(tile_b);
                        }
                        if ((status & 0x80) == 0x80)
                        {
                            tile_b.Invert = true;
                            tile_b.Index = a;
                            tiles_b.Remove(tile_b);
                        }
                    }
                }
            }
            // redraw into newly culled graphic block, and reorganize tilenums
            int c = 0; byte[] culledGraphics = new byte[src.Length];
            foreach (var tile in tiles_b)
            {
                int orig = tile.Index;
                Buffer.BlockCopy(src, tile.Index * tileSize, culledGraphics, c * tileSize, tileSize);
                tile.Index = c;
                // check for other duplicates or mirrors/inversions of this current tile
                foreach (var check in tiles_a)
                {
                    if (check.Index == orig)
                        check.Index = c;
                }
                c++;
            }
            // now rewrite tileset data using tiles_a
            c = 0; byte[] culledTileset = new byte[tileset.Length];
            foreach (var tile in tiles_a)
            {
                culledTileset[c * tileLength] = (byte)(tile.Index + tileIndexStart);
                if (tileLength == 2)
                {
                    culledTileset[c * tileLength + 1] = (byte)(paletteIndexes[c] << 2);    // set the palette index
                    culledTileset[c * tileLength + 1] |= (byte)(tile.Index >> 8); // set the graphic index
                    Bits.SetBit(culledTileset, c * tileLength + 1, 5, priority1);
                    Bits.SetBit(culledTileset, c * tileLength + 1, 6, tile.Mirror);
                    Bits.SetBit(culledTileset, c * tileLength + 1, 7, tile.Invert);
                }
                c++;
            }
            Buffer.BlockCopy(culledTileset, 0, tileset, 0, tileset.Length);
            Buffer.BlockCopy(culledGraphics, 0, src, 0, src.Length);
        }
        /// <summary>
        /// Copy a block of 4bpp graphics into a tileset and returns the final size of the imported graphics.
        /// </summary>
        /// <param name="src">The raw graphics to copy from.</param>
        /// <param name="tileset">The raw tileset to copy to.</param>
        /// <param name="palette">The single palette to apply.</param>
        /// <param name="paletteIndex">The universal palette index of all 8x8 tiles in the graphics.</param>
        /// <param name="checkIfFlipped">Check if 8x8 tiles are mirrors or inversions of another, and cull the graphics accordingly.</param>
        /// <param name="priority1">Sets whether or not the tiles in the tileset will be priority 1.</param>
        /// <param name="format">The format, either 0x10 or 0x20 (2bpp and 4bpp, respectively).</param>
        /// <param name="tileLength">Length, in bytes, of an 8x8 tile in a tileset. Either one or two.</param>
        /// <param name="tilesetSize">Size, in pixels, of the tileset being drawn to.</param>
        /// <param name="tileIndexStart">The index to start writing tilenums to the tileset. Normally 0, 1, or 2</param>
        /// <returns></returns>
        public static int CopyToTileset(byte[] src, byte[] tileset, int[] palette, int paletteIndex,
            bool checkIfFlipped, bool priority1, byte format, byte tileLength, Size tilesetSize, int tileIndexStart)
        {
            var tiles_a = new List<Subtile>();    // the tileset, essentially, in array form
            var tiles_b = new List<Subtile>();    // used for redrawing a culled 4bpp graphic block
            for (int i = 0; i < src.Length / format; i++)
            {
                var temp = new Subtile(i, src, i * format, palette, false, false, false, format == 0x10);
                tiles_a.Add(temp);
                tiles_b.Add(temp);
            }
            // look through entire set of tiles for duplicates
            for (int a = 0; a < tiles_a.Count; a++)
            {
                var tile_a = tiles_a[a];
                if (tile_a.Index != a) continue;  // skip if already set as duplicate
                for (int b = a; b < tiles_a.Count; b++)
                {
                    var tile_b = tiles_a[b];
                    if (a == b) continue;   // cannot be duplicate of self
                    if (Bits.Compare(tile_a.Pixels, tile_b.Pixels)) // if a duplicate...
                    {
                        // first set the tile to the one that it's a duplicate of
                        tile_b.Index = a;
                        // then remove
                        tiles_b.Remove(tile_b);
                    }
                    if (checkIfFlipped) // if effect tileset, don't bother setting status
                    {
                        byte status = GetFlippedStatus(tile_a.Pixels, tile_b.Pixels);
                        if ((status & 0x40) == 0x40)
                        {
                            tile_b.Mirror = true;
                            tile_b.Index = a;
                            tiles_b.Remove(tile_b);
                        }
                        if ((status & 0x80) == 0x80)
                        {
                            tile_b.Invert = true;
                            tile_b.Index = a;
                            tiles_b.Remove(tile_b);
                        }
                    }
                }
            }
            // redraw into newly culled graphic block, and reorganize tilenums
            int c = 0; byte[] culledGraphics = new byte[src.Length];
            foreach (var tile in tiles_b)
            {
                int orig = tile.Index;
                Buffer.BlockCopy(src, tile.Index * format, culledGraphics, c * format, format);
                tile.Index = c;
                // check for other duplicates or mirrors/inversions of this current tile
                foreach (var check in tiles_a)
                {
                    if (check.Index == orig)
                        check.Index = c;
                }
                c++;
            }
            // now rewrite tileset data using tiles_a
            c = 0; byte[] culledTileset = new byte[tileset.Length];
            foreach (var tile in tiles_a)
            {
                if (c * tileLength >= culledTileset.Length)
                {
                    MessageBox.Show(
                        "Imported graphics were too large to fit into the tileset.",
                        "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                }
                Bits.SetShort(culledTileset, c * tileLength, (ushort)(tile.Index + tileIndexStart));
                if (tileLength == 2)
                {
                    culledTileset[c * tileLength + 1] |= (byte)(paletteIndex << 2);    // set the palette index
                    culledTileset[c * tileLength + 1] |= (byte)(tile.Index >> 8); // set the graphic index
                    Bits.SetBit(culledTileset, c * tileLength + 1, 5, priority1);
                    Bits.SetBit(culledTileset, c * tileLength + 1, 6, tile.Mirror);
                    Bits.SetBit(culledTileset, c * tileLength + 1, 7, tile.Invert);
                }
                c++;
            }
            Buffer.BlockCopy(culledTileset, 0, tileset, 0, tileset.Length);
            Buffer.BlockCopy(culledGraphics, 0, src, 0, src.Length);
            return tiles_b.Count * format;
        }

        /// <summary>
        /// Crops a pixel array to the boundaries of the pixel edges and returns the newly cropped region.
        /// </summary>
        /// <param name="src">The source array.</param>
        /// <param name="width">The width of the source array.</param>
        /// <param name="height">The height of the source array.</param>
        /// <returns></returns>
        public static Rectangle Crop(int[] src, int width, int height)
        {
            int leftEdge = 0, bottomEdge = 0, rightEdge = 0, topEdge = 0;
            // find top edge
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                    if (src[y * width + x] != 0)
                    {
                        topEdge = y;
                        goto FindBottomEdge;
                    }
            }
        FindBottomEdge:
            // find bottom edge
            for (int y = height - 1; y >= 0; y--)
            {
                for (int x = 0; x < width; x++)
                    if (src[y * width + x] != 0)
                    {
                        bottomEdge = y;
                        goto FindLeftEdge;
                    }
            }
        FindLeftEdge:
            // find left edge
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                    if (src[y * width + x] != 0)
                    {
                        leftEdge = x;
                        goto FindRightEdge;
                    }
            }
        FindRightEdge:
            // find right edge
            for (int x = width - 1; x >= 0; x--)
            {
                for (int y = 0; y < height; y++)
                    if (src[y * width + x] != 0)
                    {
                        rightEdge = x;
                        goto Done;
                    }
            }
        Done:
            if (rightEdge - leftEdge <= 0 ||
                bottomEdge - topEdge <= 0)
                return new Rectangle(0, 0, 1, 1);
            else
                return new Rectangle(leftEdge, topEdge, rightEdge - leftEdge + 1, bottomEdge - topEdge + 1);
        }
        /// <summary>
        /// Crops a pixel array to the boundaries of the pixel edges and returns the newly cropped region.
        /// </summary>
        /// <param name="src">The source array.</param>
        /// <param name="dst">The array to write the cropped region to.</param>
        /// <param name="width">The width of the source array.</param>
        /// <param name="height">The height of the source array.</param>
        /// <returns></returns>
        public static Rectangle Crop(int[] src, out int[] dst, int width, int height, bool left, bool bottom, bool right, bool top)
        {
            int leftEdge = 0, bottomEdge = 0, rightEdge = 0, topEdge = 0;
            // find top edge
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                    if (src[y * width + x] != 0)
                    {
                        topEdge = y;
                        goto FindBottomEdge;
                    }
            }
        FindBottomEdge:
            // find bottom edge
            for (int y = height - 1; y >= 0; y--)
            {
                for (int x = 0; x < width; x++)
                    if (src[y * width + x] != 0)
                    {
                        bottomEdge = y;
                        goto FindLeftEdge;
                    }
            }
        FindLeftEdge:
            // find left edge
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                    if (src[y * width + x] != 0)
                    {
                        leftEdge = x;
                        goto FindRightEdge;
                    }
            }
        FindRightEdge:
            // find right edge
            for (int x = width - 1; x >= 0; x--)
            {
                for (int y = 0; y < height; y++)
                    if (src[y * width + x] != 0)
                    {
                        rightEdge = x;
                        goto Done;
                    }
            }
        Done:
            if (!top) topEdge = 0;
            if (!bottom) bottomEdge = height;
            if (!left) leftEdge = 0;
            if (!right) rightEdge = width;
            //
            if (rightEdge - leftEdge <= 0 ||
                bottomEdge - topEdge <= 0)
            {
                dst = new int[1];
                return new Rectangle(0, 0, 1, 1);
            }
            else
            {
                dst = GetPixelRegion(src, width, height,
                    rightEdge - leftEdge + 1, bottomEdge - topEdge + 1, leftEdge, topEdge);
                return new Rectangle(leftEdge, topEdge, rightEdge - leftEdge + 1, bottomEdge - topEdge + 1);
            }
        }
        public static Rectangle Crop(int[] src, out int[] dst, int width, int height)
        {
            return Crop(src, out dst, width, height, true, true, true, true);
        }
        /// <summary>
        /// Crop several pixel arrays to the largest boundary of all arrays and returns the boundary.
        /// Assumes that all source arrays are the same width and height.
        /// </summary>
        /// <param name="src">The source array.</param>
        /// <param name="dst">The array to write the cropped region to.</param>
        /// <param name="width">The width of the source array.</param>
        /// <param name="height">The height of the source array.</param>
        /// <returns></returns>
        public static Rectangle Crop(int[][] src, out int[][] dst, int width, int height)
        {
            dst = new int[src.Length][];
            int leftEdge = 0, bottomEdge = 0, rightEdge = 0, topEdge = 0;
            for (int i = 0; i < src.Length; i++)
            {
                // find top edge
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                        if (src[i][y * width + x] != 0)
                        {
                            if (y < topEdge)
                                topEdge = y;
                            goto FindBottomEdge;
                        }
                }
            FindBottomEdge:
                // find bottom edge
                for (int y = height - 1; y >= 0; y--)
                {
                    for (int x = 0; x < width; x++)
                        if (src[i][y * width + x] != 0)
                        {
                            if (y > bottomEdge)
                                bottomEdge = y;
                            goto FindLeftEdge;
                        }
                }
            FindLeftEdge:
                // find left edge
                for (int x = 0; x < width; x++)
                {
                    for (int y = 0; y < height; y++)
                        if (src[i][y * width + x] != 0)
                        {
                            if (x < leftEdge)
                                leftEdge = x;
                            goto FindRightEdge;
                        }
                }
            FindRightEdge:
                // find right edge
                for (int x = width - 1; x >= 0; x--)
                {
                    for (int y = 0; y < height; y++)
                        if (src[i][y * width + x] != 0)
                        {
                            if (x > rightEdge)
                                rightEdge = x;
                            goto Done;
                        }
                }
            Done:
                continue;
            }
            for (int i = 0; i < dst.Length; i++)
            {
                if (rightEdge - leftEdge <= 0 || bottomEdge - topEdge <= 0)
                    dst[i] = new int[1];
                else
                    dst[i] = GetPixelRegion(src[i], width, height,
                        rightEdge - leftEdge + 1, bottomEdge - topEdge + 1, leftEdge, topEdge);
            }
            if (rightEdge - leftEdge <= 0 || bottomEdge - topEdge <= 0)
                return new Rectangle(0, 0, 1, 1);
            else
                return new Rectangle(leftEdge, topEdge, rightEdge - leftEdge + 1, bottomEdge - topEdge + 1);
        }
        /// <summary>
        /// Crops a tilemap, based on an empty tile index.
        /// </summary>
        /// <param name="src">The tilemap to crop.</param>
        /// <param name="width">The width, in 16x16 tiles, of the tilemap.</param>
        /// <param name="height">The height, in 16x16 tiles, of the tilemap.</param>
        /// <param name="emptyTileIndex">The index of the empty tile. Either 0xFF (used by effects) or 0.</param>
        /// <returns></returns>
        public static Rectangle Crop(byte[] src, int width, int height, byte emptyTileIndex)
        {
            int leftEdge = 0, bottomEdge = 0, rightEdge = 0, topEdge = 0;
            // find top edge
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                    if (src[y * width + x] != emptyTileIndex)
                    {
                        topEdge = y;
                        goto FindBottomEdge;
                    }
            }
        FindBottomEdge:
            // find bottom edge
            for (int y = height - 1; y >= 0; y--)
            {
                for (int x = 0; x < width; x++)
                    if (src[y * width + x] != emptyTileIndex)
                    {
                        bottomEdge = y;
                        goto FindLeftEdge;
                    }
            }
        FindLeftEdge:
            // find left edge
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                    if (src[y * width + x] != emptyTileIndex)
                    {
                        leftEdge = x;
                        goto FindRightEdge;
                    }
            }
        FindRightEdge:
            // find right edge
            for (int x = width - 1; x >= 0; x--)
            {
                for (int y = 0; y < height; y++)
                    if (src[y * width + x] != emptyTileIndex)
                    {
                        rightEdge = x;
                        goto Done;
                    }
            }
        Done:
            if (rightEdge - leftEdge <= 0 ||
                bottomEdge - topEdge <= 0)
            {
                for (int i = 0; i < src.Length; i++)
                    src[i] = emptyTileIndex;
                return new Rectangle(0, 0, 1, 1);
            }
            else
            {
                var temp = new byte[src.Length]; src.CopyTo(temp, 0); Bits.Fill(src, emptyTileIndex);
                var region = new Rectangle(leftEdge, topEdge, (rightEdge - leftEdge) + 1, (bottomEdge - topEdge) + 1);
                for (int y = 0, y_ = region.Top; y <= region.Height && y_ < region.Bottom; y++, y_++)
                {
                    for (int x = 0, x_ = region.Left; x <= region.Width && x_ < region.Right; x++, x_++)
                        src[y * region.Width + x] = temp[y_ * width + x_];
                }
                return region;
            }
        }

        /// <summary>
        /// Removes all recurring instances of the 8x8 subtiles in a BPP graphics array.
        /// </summary>
        /// <param name="src">The source array to analyze and write to.</param>
        /// <param name="palette">The palette to use.</param>
        /// <param name="format">The size of an 8x8 tile. 0x10 or 0x20 for 2bpp and 4bpp, respectively.</param>
        /// <param name="checkIfFlipped">Removes recurring subtiles that are flipped.</param>
        /// <returns></returns>
        public static byte[] CullGraphics(byte[] src, int[] palette, byte format, bool checkIfFlipped)
        {
            var tiles_a = new List<Subtile>();    // the tileset, essentially, in array form
            var tiles_b = new List<Subtile>();    // used for redrawing a culled 4bpp graphic block
            for (int i = 0; i < src.Length / format; i++)
            {
                var temp = new Subtile(i, src, i * format, palette, false, false, false, format == 0x10);
                tiles_a.Add(temp);
                tiles_b.Add(temp);
            }
            // look through entire set of tiles for duplicates
            for (int a = 0; a < tiles_a.Count; a++)
            {
                Subtile tile_a = tiles_a[a];
                if (tile_a.Index != a) continue;  // skip if already set as duplicate
                for (int b = a; b < tiles_a.Count; b++)
                {
                    Subtile tile_b = tiles_a[b];
                    // always remove if empty
                    if (Bits.Empty(tile_b.Pixels))
                        tiles_b.Remove(tile_b);
                    // cannot be duplicate of self
                    if (a == b)
                        continue;
                    // if a duplicate...
                    if (Bits.Compare(tile_a.Pixels, tile_b.Pixels))
                    {
                        // first set the tile to the one that it's a duplicate of
                        tile_b.Index = a;
                        // then remove
                        tiles_b.Remove(tile_b);
                    }
                    // if effect tileset, don't bother setting status
                    if (checkIfFlipped)
                    {
                        byte status = GetFlippedStatus(tile_a.Pixels, tile_b.Pixels);
                        if ((status & 0x40) == 0x40)
                        {
                            tile_b.Mirror = true;
                            tile_b.Index = a;
                            tiles_b.Remove(tile_b);
                        }
                        if ((status & 0x80) == 0x80)
                        {
                            tile_b.Invert = true;
                            tile_b.Index = a;
                            tiles_b.Remove(tile_b);
                        }
                    }
                }
            }
            // redraw into newly culled graphic block, and reorganize tilenums
            int c = 0; byte[] culledGraphics = new byte[src.Length];
            foreach (var tile in tiles_b)
            {
                int orig = tile.Index;
                Buffer.BlockCopy(src, tile.Index * format, culledGraphics, c * format, format);
                tile.Index = c;
                // check for other duplicates or mirrors/inversions of this current tile
                foreach (var check in tiles_a)
                {
                    if (check.Index == orig)
                        check.Index = c;
                }
                c++;
            }
            Array.Resize<byte>(ref culledGraphics, tiles_b.Count * format);
            return culledGraphics;
        }
        /// <summary>
        /// Reorder indexes of tiles in a tileset based on duplicates.
        /// </summary>
        /// <param name="tileset">The raw tileset to reduce the size of.</param>
        public static void CullTileset(ref Tile[] tileset)
        {
            // set duplicate tiles to originals
            var tilesetTiles = new List<Tile>();
            foreach (var tile in tileset)
            {
                int contains = Do.Contains(tile, tileset);
                if (tile.Index == contains)
                    tilesetTiles.Add(tile);
                else
                    tile.Index = contains;
            }
            // renumber tile indexes
            int c = 0;
            foreach (Tile tile in tilesetTiles)
                tile.Index = c++;
            // finally cull the original tileset
            c = 0;
            foreach (Tile tile in tilesetTiles)
                tileset[c++] = tile;
            Array.Resize<Tile>(ref tileset, c);
        }
        /// <summary>
        /// Reorder indexes of tiles in a tileset based on duplicates and draws to a tilemap.
        /// </summary>
        /// <param name="tileset">The raw tileset to reduce the size of.</param>
        /// <param name="tilemap">The tilemap to draw to.</param>
        /// <param name="width">The width, in 16x16 tiles, of the tilemap.</param>
        /// <param name="height">The height, in 16x16 tiles, of the tilemap.</param>
        public static void CullTileset(Tile[] tileset, byte[] tilemap, int width, int height)
        {
            // set duplicate tiles to originals
            List<Tile> tilesetTiles = new List<Tile>();
            foreach (var tile in tileset)
            {
                int contains = Do.Contains(tile, tileset);
                if (Bits.Empty(tile.Pixels))
                    tile.Index = 0xFF;
                else if (tile.Index == contains)
                    tilesetTiles.Add(tile);
                else
                    tile.Index = contains;
            }
            // renumber tile indexes
            int c = 0;
            foreach (var tile in tilesetTiles)
                tile.Index = c++;
            // draw to tilemap with culled indexes
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (y * width + x >= tileset.Length ||
                        y * width + x >= tilemap.Length)
                        continue;
                    tilemap[y * width + x] = (byte)tileset[y * width + x].Index;
                }
            }
            // finally cull the original tileset
            c = 0;
            foreach (var tile in tilesetTiles)
                tileset[c++] = tile;
            while (c < tileset.Length)
                tileset[c++] = new Tile(c);
        }

        #region Draw tiles

        /// <summary>
        /// Draws an overworld menu frame to a pixel array.
        /// </summary>
        /// <param name="dst">The pixel array to draw to.</param>
        /// <param name="dstWidth">The width of the pixel array.</param>
        /// <param name="r">The location (in pixels) and size (in 8x8 tiles) of the frame.</param>
        /// <returns></returns>
        public static void DrawMenuFrame(int[] dst, int dstWidth, Rectangle r, byte[] graphics, int[] palette)
        {
            // set tileset
            var frameTileset = new Subtile[16 * 2];
            var framePalette = Bits.GetInts(palette, 12, 4);
            for (int i = 0; i < frameTileset.Length; i++)
                frameTileset[i] = new Subtile(i, graphics, i * 0x10, framePalette, false, false, false, true);
            // draw tiles to pixels
            for (int x = 2; x < r.Width - 2; x++)
            {
                if (x * 8 + r.X < dstWidth)
                {
                    PixelsToPixels(frameTileset[0x02].Pixels, dst, dstWidth, new Rectangle(x * 8 + r.X, r.Y, 8, 8), true, true);
                    PixelsToPixels(frameTileset[0x19].Pixels, dst, dstWidth, new Rectangle(x * 8 + r.X, (r.Height - 1) * 8 + r.Y, 8, 8), true, true);
                }
            }
            for (int y = 2; y < r.Height - 3; y++)
            {
                PixelsToPixels(frameTileset[0x05].Pixels, dst, dstWidth, new Rectangle(r.X, y * 8 + r.Y, 8, 8), true, true);
                if ((r.Width - 1) * 8 + r.X < dstWidth)
                    PixelsToPixels(frameTileset[0x06].Pixels, dst, dstWidth, new Rectangle((r.Width - 1) * 8 + r.X, y * 8 + r.Y, 8, 8), true, true);
            }
            // top-left corner
            PixelsToPixels(frameTileset[0x00].Pixels, dst, dstWidth, new Rectangle(r.X, r.Y, 8, 8), true, true);
            PixelsToPixels(frameTileset[0x01].Pixels, dst, dstWidth, new Rectangle(r.X + 8, r.Y, 8, 8), true, true);
            PixelsToPixels(frameTileset[0x10].Pixels, dst, dstWidth, new Rectangle(r.X, r.Y + 8, 8, 8), true, true);
            // top-right corner
            if ((r.Width - 2) * 8 + r.X < dstWidth)
                PixelsToPixels(frameTileset[0x03].Pixels, dst, dstWidth, new Rectangle((r.Width - 2) * 8 + r.X, r.Y, 8, 8), true, true);
            if ((r.Width - 1) * 8 + r.X < dstWidth)
            {
                PixelsToPixels(frameTileset[0x04].Pixels, dst, dstWidth, new Rectangle((r.Width - 1) * 8 + r.X, r.Y, 8, 8), true, true);
                PixelsToPixels(frameTileset[0x14].Pixels, dst, dstWidth, new Rectangle((r.Width - 1) * 8 + r.X, r.Y + 8, 8, 8), true, true);
            }
            // bottom-left corner
            if (r.Height > 3)
                PixelsToPixels(frameTileset[0x15].Pixels, dst, dstWidth, new Rectangle(r.X, (r.Height - 3) * 8 + r.Y, 8, 8), true, true);
            PixelsToPixels(frameTileset[0x07].Pixels, dst, dstWidth, new Rectangle(r.X, (r.Height - 2) * 8 + r.Y, 8, 8), true, true);
            PixelsToPixels(frameTileset[0x17].Pixels, dst, dstWidth, new Rectangle(r.X, (r.Height - 1) * 8 + r.Y, 8, 8), true, true);
            PixelsToPixels(frameTileset[0x18].Pixels, dst, dstWidth, new Rectangle(r.X + 8, (r.Height - 1) * 8 + r.Y, 8, 8), true, true);
            // bottom-right corner
            if ((r.Width - 1) * 8 + r.X < dstWidth)
            {
                if (r.Height > 3)
                    PixelsToPixels(frameTileset[0x16].Pixels, dst, dstWidth, new Rectangle((r.Width - 1) * 8 + r.X, (r.Height - 3) * 8 + r.Y, 8, 8), true, true);
                PixelsToPixels(frameTileset[0x0B].Pixels, dst, dstWidth, new Rectangle((r.Width - 1) * 8 + r.X, (r.Height - 2) * 8 + r.Y, 8, 8), true, true);
                PixelsToPixels(frameTileset[0x1B].Pixels, dst, dstWidth, new Rectangle((r.Width - 1) * 8 + r.X, (r.Height - 1) * 8 + r.Y, 8, 8), true, true);
            }
            if ((r.Width - 2) * 8 + r.X < dstWidth)
                PixelsToPixels(frameTileset[0x1A].Pixels, dst, dstWidth, new Rectangle((r.Width - 2) * 8 + r.X, (r.Height - 1) * 8 + r.Y, 8, 8), true, true);
        }
        public static int[] DrawMenuFrame(Size dstSize, byte[] graphics, int[] palette)
        {
            int[] dst = new int[(dstSize.Width * 8) * (dstSize.Height * 8)];
            DrawMenuFrame(dst, dstSize.Width * 8, new Rectangle(new Point(0, 0), dstSize), graphics, palette);
            return dst;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tiles"></param>
        /// <param name="g"></param>
        /// <param name="region">The location (in pixels) and size (in 8x8 tiles) of the menu frame.</param>
        public static void DrawMenuFrame(Bitmap[] tiles, Graphics g, int x, int y, int width, int height)
        {
            width *= 8; height *= 8;
            // upper-left corner
            g.DrawImage(tiles[0 * 5 + 0], 0 + x, 0 + y, 8, 8);
            g.DrawImage(tiles[0 * 5 + 1], 8 + x, 0 + y, 8, 8);
            g.DrawImage(tiles[1 * 5 + 0], 0 + x, 8 + y, 8, 8);
            // upper-right corner
            g.DrawImage(tiles[0 * 5 + 3], width - 16 + x, 0 + y, 8, 8);
            g.DrawImage(tiles[0 * 5 + 4], width - 8 + x, 0 + y, 8, 8);
            g.DrawImage(tiles[1 * 5 + 4], width - 8 + x, 8 + y, 8, 8);
            // lower-left corner
            g.DrawImage(tiles[3 * 5 + 0], 0 + x, height - 16 + y, 8, 8);
            g.DrawImage(tiles[4 * 5 + 0], 0 + x, height - 8 + y, 8, 8);
            g.DrawImage(tiles[4 * 5 + 1], 8 + x, height - 8 + y, 8, 8);
            // lower-right corner
            g.DrawImage(tiles[3 * 5 + 4], width - 8 + x, height - 16 + y, 8, 8);
            g.DrawImage(tiles[4 * 5 + 4], width - 8 + x, height - 8 + y, 8, 8);
            g.DrawImage(tiles[4 * 5 + 3], width - 16 + x, height - 8 + y, 8, 8);
            // tiles between
            for (int a = 2; a < (width / 8) - 2; a++)
            {
                g.DrawImage(tiles[0 * 5 + 2], a * 8 + x, y);
                g.DrawImage(tiles[4 * 5 + 2], a * 8 + x, height - 8 + y);
            }
            for (int b = 2; b < (height / 8) - 2; b++)
            {
                g.DrawImage(tiles[2 * 5 + 0], x, b * 8 + y);
                g.DrawImage(tiles[2 * 5 + 4], width - 8 + x, b * 8 + y);
            }
        }
        /// <summary>
        /// Creates an 8x8 tile class.
        /// </summary>
        /// <param name="num">The tile's number or index.</param>
        /// <param name="status">The tile's status or properties.</param>
        /// <param name="graphics">The graphics to draw to the tile from.</param>
        /// <param name="palettes">The palette set used when drawing the tile.</param>
        /// <param name="tileSize">The byte size of the tile. Either 0x10 or 0x20 (2bpp and 4bpp, respectively).</param>
        /// <param name="paletteIndexOffset">The palette index to start reading at.</param>
        /// <returns></returns>
        public static Subtile DrawSubtile(ushort num, byte status, byte[] graphics, int[][] palettes, byte tileSize)
        {
            byte paletteIndex = (byte)((status >> 2) & 0x07);
            if (paletteIndex >= palettes.Length) paletteIndex = 0;
            bool priorityOne = (status & 0x20) == 0x20;
            bool mirrored = (status & 0x40) == 0x40;
            bool inverted = (status & 0x80) == 0x80;
            bool twobpp = tileSize == 0x10;
            int offset = num * tileSize;
            if (offset >= graphics.Length) offset = 0;
            int[] palette;
            if (tileSize == 0x10)
            {
                palette = new int[4];
                for (int i = 0; i < 4; i++)
                    palette[i] = palettes[paletteIndex / 4][((paletteIndex % 4) * 4) + i];
            }
            else
                palette = palettes[paletteIndex];
            var tile = new Subtile(num, graphics, offset, palette, mirrored, inverted, priorityOne, twobpp);
            tile.Palette = paletteIndex;
            return tile;
        }
        /// <summary>
        /// Creates an 8x8 tile class.
        /// </summary>
        /// <param name="num">The tile's number or index.</param>
        /// <param name="status">The tile's status or properties.</param>
        /// <param name="graphics">The graphics to draw to the tile from.</param>
        /// <param name="palette">The palette used when drawing the tile.</param>
        /// <param name="tileSize">The byte size of the tile. Either 0x10 or 0x20 (2bpp and 4bpp, respectively).</param>
        /// <param name="paletteIndexOffset">The palette index to start reading at.</param>
        /// <returns></returns>
        public static Subtile DrawSubtile(ushort num, byte status, byte[] graphics, int[] palette, byte tileSize)
        {
            byte paletteIndex = (byte)((status >> 2) & 0x07);
            bool priorityOne = (status & 0x20) == 0x20;
            bool mirrored = (status & 0x40) == 0x40;
            bool inverted = (status & 0x80) == 0x80;
            bool twobpp = tileSize == 0x10;
            int offset = num * tileSize;
            if (offset >= graphics.Length) offset = 0;
            var tile = new Subtile(num, graphics, offset, palette, mirrored, inverted, priorityOne, twobpp);
            tile.Palette = paletteIndex;
            return tile;
        }
        /// <summary>
        /// Creates an 8x8 tile class.
        /// </summary>
        /// <param name="num">The tile's number or index.</param>
        /// <param name="status">The tile's status or properties.</param>
        /// <param name="graphics">The graphics to draw to the tile from.</param>
        /// <param name="palettes">The palette set used when drawing the tile.</param>
        /// <param name="tileSize">The byte size of the tile. Either 0x10 or 0x20 (2bpp and 4bpp, respectively).</param>
        /// <param name="paletteIndexOffset">The palette index to start reading at.</param>
        /// <returns></returns>
        public static Subtile DrawSubtile(ushort num, byte paletteIndex, bool priorityOne, bool mirrored, bool inverted, byte[] graphics, int[][] palettes, byte tileSize)
        {
            if (paletteIndex >= palettes.Length) paletteIndex = 0;
            bool twobpp = tileSize == 0x10;
            int offset = num * tileSize;
            if (offset >= graphics.Length) offset = 0;
            int[] palette;
            if (tileSize == 0x10)
            {
                palette = new int[4];
                for (int i = 0; i < 4; i++)
                    palette[i] = palettes[paletteIndex / 4][((paletteIndex % 4) * 4) + i];
            }
            else
                palette = palettes[paletteIndex];
            var tile = new Subtile(num, graphics, offset, palette, mirrored, inverted, priorityOne, twobpp);
            tile.Palette = paletteIndex;
            return tile;
        }
        /// <summary>
        /// Creates an 8x8 tile class.
        /// </summary>
        /// <param name="num">The tile's number or index.</param>
        /// <param name="status">The tile's status or properties.</param>
        /// <param name="graphics">The graphics to draw to the tile from.</param>
        /// <param name="palette">The palette used when drawing the tile.</param>
        /// <param name="tileSize">The byte size of the tile. Either 0x10 or 0x20 (2bpp and 4bpp, respectively).</param>
        /// <param name="paletteIndexOffset">The palette index to start reading at.</param>
        /// <returns></returns>
        public static Subtile DrawSubtile(ushort num, byte paletteIndex, bool priorityOne, bool mirrored, bool inverted, byte[] graphics, int[] palette, byte tileSize)
        {
            bool twobpp = tileSize == 0x10;
            int offset = num * tileSize;
            if (offset >= graphics.Length) offset = 0;
            var tile = new Subtile(num, graphics, offset, palette, mirrored, inverted, priorityOne, twobpp);
            tile.Palette = paletteIndex;
            return tile;
        }
        public static Subtile DrawSubtileM7(ushort num, byte paletteIndex, byte[] graphics, int[][] palettes, byte tileSize)
        {
            if (paletteIndex >= palettes.Length) paletteIndex = 0;
            int offset = num * tileSize;
            if (offset >= graphics.Length) offset = 0;
            int[] palette;
            if (tileSize == 0x10)
            {
                palette = new int[4];
                for (int i = 0; i < 4; i++)
                    palette[i] = palettes[paletteIndex / 4][((paletteIndex % 4) * 4) + i];
            }
            else
                palette = palettes[paletteIndex];
            var tile = new Subtile(num, graphics, offset, palette);
            tile.Palette = paletteIndex;
            return tile;
        }
        public static int[] DrawFontTable(Fonts.Glyph[] font, int[] palette,
            int tableWidth, int tableHeight, int cellWidth, int cellHeight, int rowSize, int colSize)
        {
            return DrawFontTable(font, palette, 0, tableWidth, tableHeight, cellWidth, cellHeight, rowSize, colSize);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="font">The font character collection.</param>
        /// <param name="palette">The palette to draw with.</param>
        /// <param name="padding">Distance, in pixels, of letter from top-left of cell.</param>
        /// <param name="tableWidth">Width, in pixels, of the font table.</param>
        /// <param name="tableHeight">Height, in pixels, of the font table.</param>
        /// <param name="cellWidth">Width, in pixels, of each table cell.</param>
        /// <param name="cellHeight">Height, in pixels, of each table cell.</param>
        /// <param name="rowSize">Number of cells per row.</param>
        /// <param name="colSize">Number of cells per column.</param>
        /// <returns></returns>
        public static int[] DrawFontTable(Fonts.Glyph[] font, int[] palette, int padding,
            int tableWidth, int tableHeight, int cellWidth, int cellHeight, int rowSize, int colSize)
        {
            int[] pixels = new int[tableWidth * tableHeight];
            for (int y = 0; y < colSize; y++)
            {
                for (int x = 0; x < rowSize; x++)
                {
                    int index = y * rowSize + x;
                    Do.PixelsToPixels(font[index].GetPixels(palette), pixels, tableWidth,
                        x * cellWidth + padding, y * cellHeight + padding, font[index].MaxWidth, font[index].Height, true);
                }
            }
            return pixels;
        }

        #endregion

        #region BPP Graphics

        /// <summary>
        /// Modify a single pixel in a block of 2bpp or 4bpp graphics.
        /// Returns the color index of the new pixel, whether changed or unchanged.
        /// </summary>
        /// <param name="src">The graphics to modify.</param>
        /// <param name="srcOffset">The initial offset of the graphics to modify.</param>
        /// <param name="palette">The palette used by the graphics.</param>
        /// <param name="graphics">The picture box's graphics to paint to.</param>
        /// <param name="zoom">The current zoom level of the graphics image.</param>
        /// <param name="action">The type of modification: erase, draw, or select.</param>
        /// <param name="x">The X coord, in pixels, of the pixel to modify.</param>
        /// <param name="y">The Y coord, in pixels, of the pixel to modify.</param>
        /// <param name="offset">The base tile index to start from. Determined by current graphic set index.</param>
        /// <param name="color">The color index in the palette assigned to the pixel.</param>
        /// <param name="width">The width,in 8x8 tile units, of the graphic block.</param>
        /// <param name="height">The height,in 8x8 tile units, of the graphic block.</param>
        /// <param name="format">The format for 2bpp or 4bpp, 0x10 or 0x20, respectively.</param>
        public static int EditPixelBPP(byte[] src, int srcOffset, int[] palette, Graphics graphics, int zoom, EditMode action,
            int x, int y, int index, int color, int width, int height, byte format)
        {
            return EditPixelBPP(src, srcOffset, palette, graphics, zoom,
                action, x, y, index, color, color, width, height, format);
        }
        public static int EditPixelBPP(byte[] src, int srcOffset, int[] palette, Graphics graphics, int zoom, EditMode action,
            int x, int y, int index, int color, int colorBack, int width, int height, byte format)
        {
            return EditPixelBPP(src, srcOffset, palette, graphics, zoom,
                action, x, y, index, color, colorBack, width, height, format, null);
        }
        public static int EditPixelBPP(byte[] src, int srcOffset, int[] palette, Graphics graphics, int zoom, EditMode action,
            int x, int y, int index, int color, int colorBack, int width, int height, byte format, Fonts.Glyph glyph)
        {
            if (x < 0 || x >= (width * 8) * zoom ||
                y < 0 || y >= (height * 8) * zoom ||
                action == EditMode.None)
                return color;
            if (srcOffset < 0 || index < 0)
                return color;
            //
            int bit = 0;
            int offset = GetBPPOffset(x, y, srcOffset, index, zoom, format, ref bit, width, glyph);
            if (format == 0x20 && offset + 17 >= src.Length)
                return color;
            if (format == 0x10 && offset + 1 >= src.Length)
                return color;
            Rectangle c;
            switch (action)
            {
                case EditMode.Draw:
                    SetBPPColor(src, x, y, srcOffset, index, zoom, format, color, width, glyph);
                    break;
                case EditMode.Erase:
                    SetBPPColor(src, x, y, srcOffset, index, zoom, format, 0, width, glyph);
                    break;
                case EditMode.Dropper:
                    color = GetBPPColor(src, x, y, srcOffset, index, zoom, format, width, glyph);
                    break;
                case EditMode.ReplaceColor:
                    int selectColor = GetBPPColor(src, x, y, srcOffset, index, zoom, format, width, glyph);
                    // if pixel not color to replace, return
                    if (selectColor != colorBack)
                        return color;
                    c = new Rectangle(x / zoom * zoom, y / zoom * zoom, zoom, zoom);
                    if (graphics != null)
                        graphics.FillRectangle(new SolidBrush(Color.FromArgb(palette[color])), c);
                    SetBPPColor(src, x, y, srcOffset, index, zoom, format, color, width, glyph);
                    break;
                case EditMode.Fill:
                    int fillColor = color;
                    color = GetBPPColor(src, x, y, srcOffset, index, zoom, format, width, glyph);
                    if (color == fillColor) return color;
                    Fill(src, color, fillColor, x, y, width, height, "", srcOffset, index, zoom, format, glyph);
                    break;
                case EditMode.FillAll:
                    fillColor = color;
                    color = GetBPPColor(src, x, y, srcOffset, index, zoom, format, width, glyph);
                    if (color == fillColor) return color;
                    int thisWidth = glyph != null ? glyph.Width : width;
                    for (int b = 0; b < height * 8; b++)
                    {
                        for (int a = 0; a < thisWidth * 8; a++)
                        {
                            int seeColor = GetBPPColor(src, a, b, srcOffset, index, 1, format, width, glyph);
                            // if fillable, fill pixel and create spawn travelling west
                            if (seeColor == color)
                                SetBPPColor(src, a, b, srcOffset, index, 1, format, fillColor, width, glyph);
                        }
                    }
                    break;
            }
            return color;
        }
        public static void Fill(byte[] src, ushort value, ushort fillValue, int x, int y, int width, int height, string dir)
        {
            var collision = Areas.Collision.Instance;
            // first, fill this/these tile(s)
            Bits.SetShort(src, collision.PixelTiles[y * 1024 + x] * 2, fillValue);
            //
            int seeValue = 0;
            // look WEST, if not travelling east or at boundary
            if (dir != "east" && x >= 32)
            {
                // see what tile is to the west
                seeValue = Bits.GetShort(src, collision.PixelTiles[y * 1024 + x - 32] * 2);
                // if fillable, fill tile and create spawn travelling west
                if (seeValue == value)
                    Fill(src, value, fillValue, x - 32, y, width, height, "west");
            }
            //  look EAST, if not travelling west or at boundary, and at least 1st row all fillable
            if (dir != "west" && x < width - 32)
            {
                // see what color is to the east
                seeValue = Bits.GetShort(src, collision.PixelTiles[y * 1024 + x + 32] * 2);
                // if fillable, fill pixel and create spawn travelling east
                if (seeValue == value)
                    Fill(src, value, fillValue, x + 32, y, width, height, "east");
            }
            //  look NORTH, if not travelling south or at boundary
            if (dir != "south" && y >= 16)
            {
                // see what color is to the north
                seeValue = Bits.GetShort(src, collision.PixelTiles[(y - 16) * 1024 + x] * 2);
                // if fillable, fill pixel and create spawn travelling north
                if (seeValue == value)
                    Fill(src, value, fillValue, x, y - 16, width, height, "north");
            }
            //  look SOUTH, if not travelling north or at boundary, and at least 1st column all fillable
            if (dir != "north" && y < height - 16)
            {
                // see what color is to the south
                seeValue = Bits.GetShort(src, collision.PixelTiles[(y + 16) * 1024 + x] * 2);
                // if fillable, fill pixel and create spawn travelling south
                if (seeValue == value)
                    Fill(src, value, fillValue, x, y + 16, width, height, "south");
            }

            // look NORTHWEST, if not travelling southeast or at boundary
            if (dir != "southeast" && x >= 16 && y >= 8)
            {
                // see what tile is to the NORTHWEST
                seeValue = Bits.GetShort(src, collision.PixelTiles[(y - 8) * 1024 + x - 16] * 2);
                // if fillable, fill tile and create spawn travelling northwest
                if (seeValue == value)
                    Fill(src, value, fillValue, x - 16, y - 8, width, height, "northwest");
            }
            //  look NORTHEAST, if not travelling southwest or at boundary
            if (dir != "southwest" && x < width - 16 && y >= 8)
            {
                // see what color is to the NORTHEAST
                seeValue = Bits.GetShort(src, collision.PixelTiles[(y - 8) * 1024 + x + 16] * 2);
                // if fillable, fill pixel and create spawn travelling northeast
                if (seeValue == value)
                    Fill(src, value, fillValue, x + 16, y - 8, width, height, "northeast");
            }
            //  look SOUTHWEST, if not travelling northeast or at boundary
            if (dir != "northeast" && x >= 16 && y < height - 8)
            {
                // see what color is to the SOUTHWEST
                seeValue = Bits.GetShort(src, collision.PixelTiles[(y + 8) * 1024 + x - 16] * 2);
                // if fillable, fill pixel and create spawn travelling southwest
                if (seeValue == value)
                    Fill(src, value, fillValue, x - 16, y + 8, width, height, "southwest");
            }
            //  look SOUTHEAST, if not travelling northwest or at boundary
            if (dir != "northwest" && x < width - 16 && y < height - 8)
            {
                // see what color is to the SOUTHEAST
                seeValue = Bits.GetShort(src, collision.PixelTiles[(y + 8) * 1024 + x + 16] * 2);
                // if fillable, fill pixel and create spawn travelling southeast
                if (seeValue == value)
                    Fill(src, value, fillValue, x + 16, y + 8, width, height, "southeast");
            }
        }
        public static void Fill(int[][] src, int layer, bool chkall, int value, int[] fillValues, int x, int y, int width, int height, int vwidth, int vheight, string dir)
        {
            // first, fill this/these tile(s)
            int[] otherlayers;
            if (layer == 0)
                otherlayers = new int[] { 1, 2 };
            else if (layer == 1)
                otherlayers = new int[] { 0, 2 };
            else
                otherlayers = new int[] { 0, 1 };
            int a = 0;
            int b = 0;
            for (b = 0; b < vheight && y + b < height; b++)
            {
                if (src[layer][(y + b) * width + x] != value)
                    break;
                if (chkall &&
                    (src[otherlayers[0]][(y + b) * width + x] != 0 ||
                     src[otherlayers[1]][(y + b) * width + x] != 0))
                    break;
                for (a = 0; a < vwidth && x + a < width; a++)
                {
                    if (src[layer][(y + b) * width + x + a] != value)
                        break;
                    if (chkall &&
                        (src[otherlayers[0]][(y + b) * width + x] != 0 ||
                         src[otherlayers[1]][(y + b) * width + x] != 0))
                        break;
                    src[layer][(y + b) * width + x + a] = fillValues[b * vwidth + a];
                }
            }
            // look WEST, if not travelling east or at boundary
            if (dir != "east" && x - vwidth + 1 > 0)
            {
                // see what tile is to the west
                var fillable = new bool[] { true, true, true };
                for (int l = 0; l < 3; l++)
                {
                    if (src[l] == null)
                        continue;
                    for (int c = 0; c < vwidth && x - c > 0; c++)
                        if (l == layer && src[l][y * width + x - c - 1] != value)
                            fillable[l] = false;
                        else if (l != layer && src[l][y * width + x - c - 1] != 0)
                            fillable[l] = false;
                }
                // if fillable, fill tile and create spawn travelling west
                if (fillable[layer])
                    if (!chkall)
                        Fill(src, layer, chkall, value, fillValues, x - vwidth, y, width, height, vwidth, vheight, "west");
                    else if (fillable[otherlayers[0]] && fillable[otherlayers[1]])
                        Fill(src, layer, chkall, value, fillValues, x - vwidth, y, width, height, vwidth, vheight, "west");
            }
            //  look EAST, if not travelling west or at boundary, and at least 1st row all fillable
            if (dir != "west" && x < width - vwidth && a == vwidth)
            {
                // see what color is to the east
                var fillable = new bool[] { true, true, true };
                for (int l = 0; l < 3; l++)
                {
                    if (src[l] == null)
                        continue;
                    for (int c = 0; c < vwidth && x + c < width - vwidth; c++)
                        if (l == layer && src[l][y * width + x + c + vwidth] != value)
                            fillable[l] = false;
                        else if (l != layer && src[l][y * width + x + c + vwidth] != 0)
                            fillable[l] = false;
                }
                // if fillable, fill pixel and create spawn travelling east
                if (fillable[layer])
                    if (!chkall)
                        Fill(src, layer, chkall, value, fillValues, x + vwidth, y, width, height, vwidth, vheight, "east");
                    else if (fillable[otherlayers[0]] && fillable[otherlayers[1]])
                        Fill(src, layer, chkall, value, fillValues, x + vwidth, y, width, height, vwidth, vheight, "east");
            }
            //  look NORTH, if not travelling south or at boundary
            if (dir != "south" && y - vheight + 1 > 0)
            {
                // see what color is to the north
                var fillable = new bool[] { true, true, true };
                for (int l = 0; l < 3; l++)
                {
                    if (src[l] == null)
                        continue;
                    for (int d = 0; d < vheight && y - d > 0; d++)
                        if (l == layer && src[l][(y - d - 1) * width + x] != value)
                            fillable[l] = false;
                        else if (l != layer && src[l][(y - d - 1) * width + x] != 0)
                            fillable[l] = false;
                }
                // if fillable, fill pixel and create spawn travelling north
                if (fillable[layer])
                    if (!chkall)
                        Fill(src, layer, chkall, value, fillValues, x, y - vheight, width, height, vwidth, vheight, "north");
                    else if (fillable[otherlayers[0]] && fillable[otherlayers[1]])
                        Fill(src, layer, chkall, value, fillValues, x, y - vheight, width, height, vwidth, vheight, "north");
            }
            //  look SOUTH, if not travelling north or at boundary, and at least 1st column all fillable
            if (dir != "north" && y < height - vheight && b == vheight)
            {
                // see what color is to the south
                var fillable = new bool[] { true, true, true };
                for (int l = 0; l < 3; l++)
                {
                    if (src[l] == null)
                        continue;
                    for (int d = 0; d < vheight && y + d < height - vheight; d++)
                        if (l == layer && src[l][(y + d + vheight) * width + x] != value)
                            fillable[l] = false;
                        else if (l != layer && src[l][(y + d + vheight) * width + x] != 0)
                            fillable[l] = false;
                }
                // if fillable, fill pixel and create spawn travelling south
                if (fillable[layer])
                    if (!chkall)
                        Fill(src, layer, chkall, value, fillValues, x, y + vheight, width, height, vwidth, vheight, "south");
                    else if (fillable[otherlayers[0]] && fillable[otherlayers[1]])
                        Fill(src, layer, chkall, value, fillValues, x, y + vheight, width, height, vwidth, vheight, "south");
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="src">BPP graphics</param>
        /// <param name="color">Color to fill</param>
        /// <param name="fillColor">Color to fill with</param>
        /// <param name="x">X coord to start travelling from</param>
        /// <param name="y">Y coord to start travelling from</param>
        /// <param name="dir">Direction travelling from</param>
        private static void Fill(byte[] src, int color, int fillColor, int x, int y, int width, int height,
            string dir, int srcOffset, int index, int zoom, byte format, Fonts.Glyph glyph)
        {
            // the color seen when looking in a direction
            int seeColor = 0;
            // first, fill this pixel
            SetBPPColor(src, x, y, srcOffset, index, zoom, format, fillColor, width, glyph);
            // look WEST, if not travelling east or at boundary
            if (dir != "east" && x / zoom > 0)
            {
                // see what color is to the west
                seeColor = GetBPPColor(src, x - (1 * zoom), y, srcOffset, index, zoom, format, width, glyph);
                // if fillable, fill pixel and create spawn travelling west
                if (seeColor == color)
                    Fill(src, color, fillColor, x - (1 * zoom), y, width, height, "west", srcOffset, index, zoom, format, glyph);
            }
            //  look EAST, if not travelling west or at boundary
            if (dir != "west" && x < (width * 8 * zoom) - (1 * zoom))
            {
                // see what color is to the east
                seeColor = GetBPPColor(src, x + (1 * zoom), y, srcOffset, index, zoom, format, width, glyph);
                // if fillable, fill pixel and create spawn travelling east
                if (seeColor == color)
                    Fill(src, color, fillColor, x + (1 * zoom), y, width, height, "east", srcOffset, index, zoom, format, glyph);
            }
            //  look NORTH, if not travelling south or at boundary
            if (dir != "south" && y / zoom > 0)
            {
                // see what color is to the north
                seeColor = GetBPPColor(src, x, y - (1 * zoom), srcOffset, index, zoom, format, width, glyph);
                // if fillable, fill pixel and create spawn travelling north
                if (seeColor == color)
                    Fill(src, color, fillColor, x, y - (1 * zoom), width, height, "north", srcOffset, index, zoom, format, glyph);
            }
            //  look SOUTH, if not travelling north or at boundary
            if (dir != "north" && y < (height * 8 * zoom) - (1 * zoom))
            {
                // see what color is to the south
                seeColor = GetBPPColor(src, x, y + (1 * zoom), srcOffset, index, zoom, format, width, glyph);
                // if fillable, fill pixel and create spawn travelling south
                if (seeColor == color)
                    Fill(src, color, fillColor, x, y + (1 * zoom), width, height, "south", srcOffset, index, zoom, format, glyph);
            }
        }
        private static int GetBPPOffset(int x, int y, int srcOffset, int index, int zoom, byte format, ref int bit, int width)
        {
            return GetBPPOffset(x, y, srcOffset, index, zoom, format, ref bit, width, null);
        }
        private static int GetBPPOffset(int x, int y, int srcOffset, int index, int zoom, byte format, ref int bit, int width, Fonts.Glyph glyph)
        {
            if (glyph != null)
            {
                index = (y / zoom) / 8;
                srcOffset = ((x / zoom) / 8) * 24;
                x = ((x / zoom) & 7) * zoom;
                y = ((y / zoom) & 7) * zoom;
            }
            //
            int offset = (y / (8 * zoom)) * width + (x / (8 * zoom));
            byte row = (byte)(y / zoom % 8);
            byte col = (byte)(x / zoom % 8);
            bit = (byte)(col ^ 7);
            // for font dialogue characters only
            if (srcOffset == 0x18)
                x += (8 * zoom);
            if (index == 1)
                y += (8 * zoom);
            //
            offset *= format;
            offset += row * 2;
            offset += index * format;
            offset += srcOffset;
            return offset;
        }
        public static int GetBPPOffset(int x, int y, int width, byte format)
        {
            int bit = 0;
            return GetBPPOffset(x, y, 0, 0, 1, format, ref bit, width);
        }
        /// <summary>
        /// Returns the color index of the BPP pixel at a given coordinate.
        /// </summary>
        /// <param name="offset"></param>
        /// <param name="format"></param>
        /// <param name="bit"></param>
        public static int GetBPPColor(byte[] src, int x, int y, int srcOffset, int index, int zoom, byte format, int width)
        {
            return GetBPPColor(src, x, y, srcOffset, index, zoom, format, width, null);
        }
        public static int GetBPPColor(byte[] src, int x, int y, int srcOffset, int index, int zoom, byte format, int width, Fonts.Glyph glyph)
        {
            int color = 0, bit = 0;
            int offset = GetBPPOffset(x, y, srcOffset, index, zoom, format, ref bit, width, glyph);
            if (format == 0x20 && offset + 17 >= src.Length)
                return -1;
            if (format == 0x10 && offset + 1 >= src.Length)
                return -1;
            if (Bits.GetBit(src, offset, bit)) color |= 1;
            if (Bits.GetBit(src, offset + 1, bit)) color |= 2;
            if (format == 0x20)
            {
                if (Bits.GetBit(src, offset + 16, bit)) color |= 4;
                if (Bits.GetBit(src, offset + 17, bit)) color |= 8;
            }
            return color;
        }
        private static void SetBPPColor(byte[] src, int x, int y, int srcOffset, int index, int zoom, byte format, int color, int width)
        {
            SetBPPColor(src, x, y, srcOffset, index, zoom, format, color, width, null);
        }
        private static void SetBPPColor(byte[] src, int x, int y, int srcOffset, int index, int zoom, byte format, int color, int width, Fonts.Glyph glyph)
        {
            int bit = 0;
            int offset = GetBPPOffset(x, y, srcOffset, index, zoom, format, ref bit, width, glyph);
            if (format == 0x20 && offset + 17 >= src.Length)
                return;
            if (format == 0x10 && offset + 1 >= src.Length)
                return;
            Bits.SetBit(src, offset, bit, (color & 1) == 1);
            Bits.SetBit(src, offset + 1, bit, (color & 2) == 2);
            if (format == 0x20)
            {
                Bits.SetBit(src, offset + 16, bit, (color & 4) == 4);
                Bits.SetBit(src, offset + 17, bit, (color & 8) == 8);
            }
        }
        public static byte[] GetBPPRegion(byte[] src, int x, int y, int width, int height, int zoom, byte format)
        {
            byte[] buffer;
            if (format == 0x10)
                buffer = new byte[(width * height) / 4];
            else
                buffer = new byte[(width * height) / 2];
            for (int Y = y, y_ = 0; y_ < width; Y++, y_++)
            {
                for (int X = x, x_ = 0; x_ < height; X++, x_++)
                {
                    int offset = GetBPPOffset(X, Y, width, format);
                    int bufferOffset = GetBPPOffset(x_, y_, width, format);
                    buffer[bufferOffset] = src[offset];
                }
            }
            return buffer;
        }

        #endregion

        #region Flip element

        /// <summary>
        /// Flip horizontally an array of pixels.
        /// </summary>
        /// <param name="src">The pixels to flip horizontally.</param>
        /// <param name="srcWidth">The width of the pixel array.</param>
        /// <param name="srcHeight">The height of the pixel array.</param>
        public static void FlipHorizontal(int[] src, int srcWidth, int srcHeight)
        {
            int temp = 0;
            for (int y = 0; y < srcHeight; y++)
            {
                for (int a = 0, b = srcWidth - 1; a < srcWidth / 2; a++, b--)
                {
                    temp = src[(y * srcWidth) + a];
                    src[(y * srcWidth) + a] = src[(y * srcWidth) + b];
                    src[(y * srcWidth) + b] = temp;
                }
            }
        }
        public static void FlipHorizontal(byte[] src, int srcWidth, int srcHeight)
        {
            byte temp = 0;
            for (int y = 0; y < srcHeight; y++)
            {
                for (int a = 0, b = srcWidth - 1; a < srcWidth / 2; a++, b--)
                {
                    temp = src[(y * srcWidth) + a];
                    src[(y * srcWidth) + a] = src[(y * srcWidth) + b];
                    src[(y * srcWidth) + b] = temp;
                }
            }
        }
        /// <summary>
        /// Flip horizontally a region in a block of SNES graphics.
        /// </summary>
        /// <param name="src">The source SNES graphics.</param>
        /// <param name="srcWidth">The width of the graphics being read.</param>
        /// <param name="x">The X coord, in pixels, of the region being modified.</param>
        /// <param name="y">The Y coord, in pixels, of the region being modified.</param>
        /// <param name="width">The width, in pixels, of the region being modified.</param>
        /// <param name="height">The height, in pixels, of the region being modified.</param>
        /// <param name="zoom">The zoom factor.</param>
        /// <param name="format">The format, 2bpp or 4bpp (0x10 and 0x20), of the source graphics.</param>
        public static void FlipHorizontal(byte[] src, int srcWidth, int X, int Y, int width, int height, int zoom, byte format)
        {
            for (int y = Y; y < Y + height; y++)
            {
                for (int a = X, b = (width + X) - 1; a - X < width / 2; a++, b--)
                {
                    int tempA = GetBPPColor(src, a, y, 0, 0, zoom, format, srcWidth);
                    int tempB = GetBPPColor(src, b, y, 0, 0, zoom, format, srcWidth);
                    SetBPPColor(src, a, y, 0, 0, zoom, format, tempB, srcWidth);
                    SetBPPColor(src, b, y, 0, 0, zoom, format, tempA, srcWidth);
                }
            }
        }
        /// <summary>
        /// Flip vertically an array of pixels.
        /// </summary>
        /// <param name="src">The pixels to flip vertically.</param>
        /// <param name="srcWidth">The width of the pixel array.</param>
        /// <param name="srcHeight">The height of the pixel array.</param>
        public static void FlipVertical(int[] src, int srcWidth, int srcHeight)
        {
            int temp = 0;
            for (int x = 0; x < srcWidth; x++)
            {
                for (int a = 0, b = srcHeight - 1; a < srcHeight / 2; a++, b--)
                {
                    temp = src[(a * srcWidth) + x];
                    src[(a * srcWidth) + x] = src[(b * srcWidth) + x];
                    src[(b * srcWidth) + x] = temp;
                }
            }
        }
        public static void FlipVertical(byte[] src, int srcWidth, int srcHeight)
        {
            byte temp = 0;
            for (int x = 0; x < srcWidth; x++)
            {
                for (int a = 0, b = srcHeight - 1; a < srcHeight / 2; a++, b--)
                {
                    temp = src[(a * srcWidth) + x];
                    src[(a * srcWidth) + x] = src[(b * srcWidth) + x];
                    src[(b * srcWidth) + x] = temp;
                }
            }
        }
        /// <summary>
        /// Flip vertically a region in a block of SNES graphics.
        /// </summary>
        /// <param name="src"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="zoom"></param>
        /// <param name="format"></param>
        public static void FlipVertical(byte[] src, int srcWidth, int X, int Y, int width, int height, int zoom, byte format)
        {
            for (int x = X; x < X + width; x++)
            {
                for (int a = 0, b = (height + Y) - 1; a - Y < height / 2; a++, b--)
                {
                    int tempA = GetBPPColor(src, x, a, 0, 0, zoom, format, srcWidth);
                    int tempB = GetBPPColor(src, x, b, 0, 0, zoom, format, srcWidth);
                    SetBPPColor(src, x, a, 0, 0, zoom, format, tempB, srcWidth);
                    SetBPPColor(src, x, b, 0, 0, zoom, format, tempA, srcWidth);
                }
            }
        }
        /// <summary>
        /// Flip horizontally a region in an array of pixels.
        /// </summary>
        /// <param name="src">The pixels to flip horizontally.</param>
        /// <param name="srcWidth">The width of the entire pixel array.</param>
        /// <param name="regX">The X coord to start at.</param>
        /// <param name="regY">The Y coord to start at.</param>
        /// <param name="regWidth">The width of the region to modify.</param>
        /// <param name="regHeight">The height of the region to modify.</param>
        public static void FlipHorizontal(int[] src, int srcWidth, int regX, int regY, int regWidth, int regHeight)
        {
            int temp = 0;
            for (int y = regY; y < regY + regHeight; y++)
            {
                for (int a = regX, b = regX + (regWidth - 1); a < regX + (regWidth / 2); a++, b--)
                {
                    temp = src[(y * srcWidth) + a];
                    src[(y * srcWidth) + a] = src[(y * srcWidth) + b];
                    src[(y * srcWidth) + b] = temp;
                }
            }
        }
        /// <summary>
        /// Flip vertically a region in an array of pixels.
        /// </summary>
        /// <param name="src">The pixels to flip vertically.</param>
        /// <param name="srcWidth">The width of the pixel array.</param>
        /// <param name="regX">The X coord to start at.</param>
        /// <param name="regY">The Y coord to start at.</param>
        /// <param name="regWidth">The width of the region to modify.</param>
        /// <param name="regHeight">The height of the region to modify.</param>
        public static void FlipVertical(int[] src, int srcWidth, int regX, int regY, int regWidth, int regHeight)
        {
            int temp = 0;
            for (int x = regX; x < regX + regWidth; x++)
            {
                for (int a = regY, b = regY + (regHeight - 1); a < regY + (regHeight / 2); a++, b--)
                {
                    temp = src[(a * srcWidth) + x];
                    src[(a * srcWidth) + x] = src[(b * srcWidth) + x];
                    src[(b * srcWidth) + x] = temp;
                }
            }
        }
        /// <summary>
        /// Flip horizontally a 16x16 tile.
        /// </summary>
        /// <param name="tile">The tile to flip horizontally.</param>
        public static void FlipHorizontal(Tile tile)
        {
            for (int i = 0; i < 4; i++)
            {
                tile.Subtiles[i].Mirror = !tile.Subtiles[i].Mirror;
                FlipHorizontal(tile.Subtiles[i].Pixels, 8, 8);
                FlipHorizontal(tile.Subtiles[i].Colors, 8, 8);
            }
            var temp = tile.Subtiles[0].Copy();
            tile.Subtiles[1].CopyTo(tile.Subtiles[0]);
            temp.CopyTo(tile.Subtiles[1]);
            temp = tile.Subtiles[2].Copy();
            tile.Subtiles[3].CopyTo(tile.Subtiles[2]);
            temp.CopyTo(tile.Subtiles[3]);
        }
        /// <summary>
        /// Flip vertically a 16x16 tile.
        /// </summary>
        /// <param name="tile">The tile to flip vertically.</param>
        public static void FlipVertical(Tile tile)
        {
            for (int i = 0; i < 4; i++)
            {
                tile.Subtiles[i].Invert = !tile.Subtiles[i].Invert;
                FlipVertical(tile.Subtiles[i].Pixels, 8, 8);
                FlipVertical(tile.Subtiles[i].Colors, 8, 8);
            }
            var temp = tile.Subtiles[0].Copy();
            tile.Subtiles[2].CopyTo(tile.Subtiles[0]);
            temp.CopyTo(tile.Subtiles[2]);
            temp = tile.Subtiles[1].Copy();
            tile.Subtiles[3].CopyTo(tile.Subtiles[1]);
            temp.CopyTo(tile.Subtiles[3]);
        }
        /// <summary>
        /// Flip horizontally a 16x16 tile.
        /// </summary>
        /// <param name="tile">The tile to flip horizontally.</param>
        public static void FlipHorizontal(Sprites.Mold.Tile tile)
        {
            for (int i = 0; i < 4; i++)
            {
                tile.Subtile_tiles[i].Mirror = !tile.Subtile_tiles[i].Mirror;
                FlipHorizontal(tile.Subtile_tiles[i].Pixels, 8, 8);
                FlipHorizontal(tile.Subtile_tiles[i].Colors, 8, 8);
            }
            var temp = tile.Subtile_tiles[0].Copy();
            tile.Subtile_tiles[1].CopyTo(tile.Subtile_tiles[0]);
            temp.CopyTo(tile.Subtile_tiles[1]);
            temp = tile.Subtile_tiles[2].Copy();
            tile.Subtile_tiles[3].CopyTo(tile.Subtile_tiles[2]);
            temp.CopyTo(tile.Subtile_tiles[3]);
        }
        /// <summary>
        /// Flip vertically a 16x16 tile.
        /// </summary>
        /// <param name="tile">The tile to flip vertically.</param>
        public static void FlipVertical(Sprites.Mold.Tile tile)
        {
            for (int i = 0; i < 4; i++)
            {
                tile.Subtile_tiles[i].Invert = !tile.Subtile_tiles[i].Invert;
                FlipVertical(tile.Subtile_tiles[i].Pixels, 8, 8);
                FlipVertical(tile.Subtile_tiles[i].Colors, 8, 8);
            }
            var temp = tile.Subtile_tiles[0].Copy();
            tile.Subtile_tiles[2].CopyTo(tile.Subtile_tiles[0]);
            temp.CopyTo(tile.Subtile_tiles[2]);
            temp = tile.Subtile_tiles[1].Copy();
            tile.Subtile_tiles[3].CopyTo(tile.Subtile_tiles[1]);
            temp.CopyTo(tile.Subtile_tiles[3]);
        }
        /// <summary>
        /// Flip horizontally a set of 16x16 tiles.
        /// </summary>
        /// <param name="tiles">The tiles to flip horizontally.</param>
        /// <param name="width">The width, in 16x16 tile units, of the tile set.</param>
        /// <param name="height">The height, in 16x16 tile units, of the tile set.</param>
        public static void FlipHorizontal(Tile[] tiles, int width, int height)
        {
            Tile temp;
            for (int y = 0; y < height; y++)
            {
                int a = 0;
                for (int b = width - 1; a < width / 2; a++, b--)
                {
                    // first, flip the tiles
                    temp = tiles[(y * width) + a].Copy();
                    tiles[(y * width) + a] = tiles[(y * width) + b].Copy();
                    tiles[(y * width) + a].Index = (y * width) + a;
                    tiles[(y * width) + b] = temp.Copy();
                    tiles[(y * width) + b].Index = (y * width) + b;
                    // now flip subtiles in both tiles
                    var tile = tiles[(y * width) + a];
                    for (int c = 0; c < 2; c++)
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            tile.Subtiles[i].Mirror = !tile.Subtiles[i].Mirror;
                            FlipHorizontal(tile.Subtiles[i].Pixels, 8, 8);
                            FlipHorizontal(tile.Subtiles[i].Colors, 8, 8);
                        }
                        var subtile = tile.Subtiles[0].Copy();
                        tile.Subtiles[1].CopyTo(tile.Subtiles[0]);
                        subtile.CopyTo(tile.Subtiles[1]);
                        subtile = tile.Subtiles[2].Copy();
                        tile.Subtiles[3].CopyTo(tile.Subtiles[2]);
                        subtile.CopyTo(tile.Subtiles[3]);
                        // set to flip subtiles in the other one
                        tile = tiles[(y * width) + b];
                    }
                }
                // if width was odd, have to flip middle tile manually
                if (width % 2 == 1)
                {
                    temp = tiles[y * width + a];
                    FlipHorizontal(temp);
                }
            }
        }
        /// <summary>
        /// Flip vertically a set of 16x16 tiles.
        /// </summary>
        /// <param name="tiles">The tiles to flip vertically.</param>
        /// <param name="width">The width, in 16x16 tile units, of the tile set.</param>
        /// <param name="height">The height, in 16x16 tile units, of the tile set.</param>
        public static void FlipVertical(Tile[] tiles, int width, int height)
        {
            Tile temp;
            for (int x = 0; x < width; x++)
            {
                int a = 0;
                for (int b = height - 1; a < height / 2; a++, b--)
                {
                    // first, flip the tiles
                    temp = tiles[(a * width) + x];
                    tiles[(a * width) + x] = tiles[(b * width) + x];
                    tiles[(b * width) + x] = temp;
                    // now flip subtiles in both tiles
                    var tile = tiles[(a * width) + x];
                    for (int c = 0; c < 2; c++)
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            tile.Subtiles[i].Invert = !tile.Subtiles[i].Invert;
                            FlipVertical(tile.Subtiles[i].Pixels, 8, 8);
                            FlipVertical(tile.Subtiles[i].Colors, 8, 8);
                        }
                        var subtile = tile.Subtiles[0].Copy();
                        tile.Subtiles[2].CopyTo(tile.Subtiles[0]);
                        subtile.CopyTo(tile.Subtiles[2]);
                        subtile = tile.Subtiles[1].Copy();
                        tile.Subtiles[3].CopyTo(tile.Subtiles[1]);
                        subtile.CopyTo(tile.Subtiles[3]);
                        // set to flip subtiles in the other one
                        tile = tiles[(b * width) + x];
                    }
                }
                // if height was odd, have to flip middle tile manually
                if (height % 2 == 1)
                {
                    temp = tiles[(a * width) + x];
                    FlipVertical(temp);
                }
            }
        }

        #endregion

        /// <summary>
        /// Returns the closest palette to a pixel array's colors from a set of palettes.
        /// </summary>
        /// <param name="palettes">The palette set / palettes.</param>
        /// <param name="array">The pixel array.</param>
        /// <returns></returns>
        public static int GetClosestPaletteIndex(int[][] palettes, int[] array)
        {
            int closestAvg = 248;
            int closestIndex = 0;
            Color[] colors;
            int[] dst = new int[array.Length];
            int[] avgs = new int[palettes.Length];
            for (int index = 0; index < palettes.Length; index++)
            {
                colors = new Color[palettes[index].Length];
                double distance = 500.0;
                double temp;
                double r, g, b;
                double dbl_test_red;
                double dbl_test_green;
                double dbl_test_blue;
                for (int i = 0; i < palettes[index].Length; i++)
                    colors[i] = Color.FromArgb(palettes[index][i]);
                int[] diffs = new int[array.Length];
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
                    if (dst[i] != 0)
                    {
                        dst[i] = nearest_color;
                        diffs[i] = Math.Abs(dst[i] - array[i]);
                    }
                }
                // get the average color difference
                int mean = 0;
                foreach (int average in diffs)
                    mean += average;
                if (mean / diffs.Length < closestAvg)
                    closestIndex = index;
            }
            return closestIndex;
        }
        /// <summary>
        /// Returns the closest palette to a region in a pixel array's colors from a set of palettes.
        /// </summary>
        /// <param name="palettes">The palette set / palettes.</param>
        /// <param name="array">The pixel array.</param>
        /// <param name="region">The region to analyze.</param>
        /// <returns></returns>
        public static int GetClosestPaletteIndex(int[][] palettes, int[] src, Rectangle source, Rectangle destination)
        {
            int closestAvg = 248;
            int closestIndex = 0;
            Color[] colors;
            for (int index = 0; index < palettes.Length; index++)
            {
                colors = new Color[palettes[index].Length];
                double distance = 500.0;
                double temp = 500.0;
                double r, g, b;
                double dbl_test_red;
                double dbl_test_green;
                double dbl_test_blue;
                for (int i = 0; i < palettes[index].Length; i++)
                    colors[i] = Color.FromArgb(palettes[index][i]);
                int[] diffs = new int[destination.Width * destination.Height];
                for (int y = destination.Y, y_ = 0; y < destination.Y + destination.Height && y_ < destination.Height; y++, y_++)
                {
                    for (int x = destination.X, x_ = 0; x < destination.X + destination.Width && x_ < destination.Width; x++, x_++)
                    {
                        distance = 500;
                        r = Convert.ToDouble(Color.FromArgb(src[y * source.Width + x]).R);
                        g = Convert.ToDouble(Color.FromArgb(src[y * source.Width + x]).G);
                        b = Convert.ToDouble(Color.FromArgb(src[y * source.Width + x]).B);
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
                        // get the difference between applied snes palette color and original bitmap color
                        diffs[y_ * destination.Width + x_] = (int)temp;
                    }
                }
                // get the average color difference
                int dividend = 0; int divisor = 0;
                foreach (int difference in diffs)
                {
                    dividend += difference;
                    divisor++;
                }
                if (dividend / divisor < closestAvg)
                {
                    closestAvg = dividend / divisor;
                    closestIndex = index;
                }
            }
            return closestIndex;
        }
        /// <summary>
        /// Returns a byte that indicates whether or not a pixel array is a mirror and/or inversion of another.
        /// </summary>
        /// <param name="tile_a">The independent array being compared to.</param>
        /// <param name="tile_b">The dependent array being compared to.</param>
        /// <returns></returns>
        public static byte GetFlippedStatus(int[] tile_a, int[] tile_b)
        {
            if (tile_a.Length != tile_b.Length) return 0;
            byte status = 0;
            // first create a mirror of tile_a which will be checked later
            int[] tile_a_both = new int[tile_a.Length]; tile_a.CopyTo(tile_a_both, 0);
            int[] tile_a_mirrored = new int[tile_a.Length]; tile_a.CopyTo(tile_a_mirrored, 0);
            int temp = 0;
            for (int y = 0; y < 8; y++)
            {
                for (int a = 0, b = 7; a < 4; a++, b--)
                {
                    temp = tile_a_mirrored[(y * 8) + a];
                    tile_a_mirrored[(y * 8) + a] = tile_a_mirrored[(y * 8) + b];
                    tile_a_mirrored[(y * 8) + b] = temp;
                    // do the same for this one
                    temp = tile_a_both[(y * 8) + a];
                    tile_a_both[(y * 8) + a] = tile_a_both[(y * 8) + b];
                    tile_a_both[(y * 8) + b] = temp;
                }
            }
            // now create an inverted tile_a which will be checked later
            int[] tile_a_inverted = new int[tile_a.Length]; tile_a.CopyTo(tile_a_inverted, 0);
            temp = 0;
            for (int x = 0; x < 8; x++)
            {
                for (int a = 0, b = 7; a < 4; a++, b--)
                {
                    temp = tile_a_inverted[(a * 8) + x];
                    tile_a_inverted[(a * 8) + x] = tile_a_inverted[(b * 8) + x];
                    tile_a_inverted[(b * 8) + x] = temp;
                    // do the same for this one
                    temp = tile_a_both[(a * 8) + x];
                    tile_a_both[(a * 8) + x] = tile_a_both[(b * 8) + x];
                    tile_a_both[(b * 8) + x] = temp;
                }
            }
            // finally compare them
            if (Bits.Compare(tile_b, tile_a_mirrored))
                status |= 0x40;
            if (Bits.Compare(tile_b, tile_a_inverted))
                status |= 0x80;
            if (Bits.Compare(tile_b, tile_a_both))
                status |= 0xC0;
            return status;
        }

        #region Region analysis

        /// <summary>
        /// Returns a pixel array from a region in another pixel array.
        /// </summary>
        /// <param name="array">The array to get the region from.</param>
        /// <param name="region">The region of the array to get.</param>
        /// <param name="srcWidth">The width of the array being read.</param>
        /// <param name="srcHeight">The height of the array being read.</param>
        /// <returns></returns>
        public static int[] GetPixelRegion(int[] array, Rectangle region, int srcWidth, int srcHeight)
        {
            int[] temp = new int[region.Width * region.Height];
            for (int y = 0; y < region.Height; y++)
            {
                if (y + region.Y >= srcHeight) continue;
                for (int x = 0; x < region.Width; x++)
                {
                    if (x + region.X >= srcWidth) continue;
                    temp[y * region.Width + x] = array[(y + region.Y) * srcWidth + (x + region.X)];
                }
            }
            return temp;
        }
        /// <summary>
        /// Returns a pixel array from a region in another pixel array.
        /// </summary>
        /// <param name="array">The array to read.</param>
        /// <param name="dstWidth">The width of the array to read.</param>
        /// <param name="dstHeight">The height of the array to read.</param>
        /// <param name="regWidth">The width of the region to create.</param>
        /// <param name="regHeight">The height of the region to create.</param>
        /// <param name="regX">The X coord to read from in the array.</param>
        /// <param name="regY">The Y coord to read from in the array.</param>
        /// <returns></returns>
        public static int[] GetPixelRegion(int[] array, int dstWidth, int dstHeight, int regWidth, int regHeight, int regX, int regY)
        {
            int[] temp = new int[regWidth * regHeight];
            for (int y = 0; y < regHeight; y++)
            {
                if (y + regY >= dstHeight) continue;
                for (int x = 0; x < regWidth; x++)
                {
                    if (x + regX >= dstWidth) continue;
                    temp[y * regWidth + x] = array[(y + regY) * dstWidth + (x + regX)];
                }
            }
            return temp;
        }
        /// <summary>
        /// Returns a pixel array from a region in a block of 4bpp or 2bpp graphics.
        /// </summary>
        /// <param name="snes">The block of graphics.</param>
        /// <param name="format">The format of the graphics. 0x10 or 0x20 for 2bpp and 4bpp, respectively.</param>
        /// <param name="palette">The palette to apply to the pixel array.</param>
        /// <param name="srcWidth">The width, in 8x8 tile units, of the graphics to draw from.</param>
        /// <param name="regX">The X coord, in 8x8 tile units, in the graphics to start drawing from.</param>
        /// <param name="regY">The Y coord, in 8x8 tile units, in the graphics to start drawing from.</param>
        /// <param name="regWidth">The width, in 8x8 tile units, of the region to draw from.</param>
        /// <param name="regHeight">The height, in 8x8 tile units, of the region to draw from.</param>
        /// <param name="offset">The offset to start reading the SNES graphics from.</param>
        /// <returns></returns>
        public static int[] GetPixelRegion(byte[] snes, int format, int[] palette, int srcWidth, int regX, int regY, int regWidth, int regHeight, int offset)
        {
            Subtile temp;
            var pixels = new int[(regWidth * 8) * (regHeight * 8)];
            for (int y = regY, y_ = 0; y < regY + regHeight; y++, y_++)
            {
                for (int x = regX, x_ = 0; x < regX + regWidth; x++, x_++)
                {
                    int index = y * srcWidth + x;
                    if ((index * format) + offset >= snes.Length)
                        continue;
                    temp = new Subtile(index, snes, index * format + offset, palette, false, false, false, format == 0x10);
                    Do.PixelsToPixels(temp.Pixels, pixels, regWidth * 8, new Rectangle(x_ * 8, y_ * 8, 8, 8));
                }
            }
            return pixels;
        }
        public static void ImagesToMolds(List<Sprites.Mold> molds, List<Sprites.Mold.Tile> uniqueTiles, Bitmap[] images, ref int[] palette,
            ref byte[] graphics, int startingIndex, bool replaceMolds, bool replacePalette, CommonType targetType, bool alwaysTilemap)
        {
            var sheet = CombineImages(images, 128, 512, 8, true);
            int[] pixels = ImageToPixels(sheet);
            int[] rpalette;
            if (replacePalette)
                rpalette = Do.ReduceColorDepth(pixels, 16, palette[0]);
            else
                rpalette = palette;
            PixelsToBPP(pixels, graphics, new Size(16, 64), rpalette, 0x20);
            graphics = CullGraphics(graphics, rpalette, 0x20, false);
            // create pixel array of culled graphics for easy reading
            int[] pixels_graphics = GetPixelRegion(graphics, 0x20, rpalette, 16, 0, 0, 16, 32, 0);
            // create a mold of each image
            if (replaceMolds)
            {
                uniqueTiles.Clear();
                if (targetType == CommonType.Mold)
                    molds.Clear();
            }
            for (int i = 0; i < images.Length; i++)
            {
                var image = images[i];
                // set width/height
                int width = Math.Min(128, image.Width / 8 * 8);
                if (image.Width % 8 != 0)
                    width += 8;
                int height = Math.Min(256, image.Height / 8 * 8);
                if (image.Height % 8 != 0)
                    height += 8;
                // if to be tilemap, add another 8 if needed
                if (alwaysTilemap || width > 32 || height > 32)
                {
                    if (width % 16 != 0)
                        width += 8;
                    if (height % 16 != 0)
                        height += 8;
                }
                image = CanvasSize(image, width, height);
                // create mold from image
                var mold = new Sprites.Mold();
                // create pixel array of image for easy reading
                int[] pixels_image = ImageToPixels(image);
                byte[] temp = new byte[width * height * 0x20];
                PixelsToBPP(pixels_image, temp, new Size(width / 8, height / 8), rpalette, 0x20);
                pixels_image = GetPixelRegion(temp, 0x20, rpalette, width / 8, 0, 0, width / 8, height / 8, 0);
                //
                #region create tilemap mold
                if (alwaysTilemap || (width <= 16 && height <= 16) || width > 32 || height > 32)
                {
                    mold.Gridplane = false;
                    mold.Tiles = new List<Sprites.Mold.Tile>();
                    // read each 16x16 tile in mold image
                    for (int y = 0; y < height / 16; y++)
                    {
                        for (int x = 0; x < width / 16; x++)
                        {
                            var tile = new Sprites.Mold.Tile();
                            tile.Subtile_bytes = new ushort[4];
                            tile.X = (byte)(x * 16);
                            tile.Y = (byte)(y * 16);
                            // create pixel array of 16x16 tile
                            int[] dst_tile = GetPixelRegion(pixels_image, width, height, 16, 16, x * 16, y * 16);
                            // if no pixels in tile, skip
                            if (Bits.Empty(dst_tile))
                                continue;
                            // read each 8x8 subtile in tile
                            for (int s = 0; s < 4; s++)
                            {
                                int[] dst = GetPixelRegion(dst_tile, 16, 16, 8, 8, (s % 2) * 8, (s / 2) * 8);
                                if (Bits.Empty(dst))
                                {
                                    tile.Subtile_bytes[s] = 0;
                                    continue;
                                }
                                // read each 8x8 tile from culled graphic set and assign indexes
                                for (int b = 0; b < 32; b++)
                                {
                                    for (int a = 0; a < 16; a++)
                                    {
                                        int index = b * 16 + a;
                                        int[] src = GetPixelRegion(pixels_graphics, 128, 256, 8, 8, a * 8, b * 8);
                                        if (Bits.Compare(src, dst))
                                        {
                                            // set index of subtile
                                            tile.Subtile_bytes[s] = (ushort)Math.Min(512, index + 1 + startingIndex);
                                            // if index over 255, needs to be 16bit
                                            if (index > 255)
                                                tile.Format = 1;
                                        }
                                    }
                                }
                            }
                            mold.Tiles.Add(tile);
                            uniqueTiles.Add(tile);
                        }
                    }
                    // center mold in 256x256 map
                    foreach (var tile in mold.Tiles)
                    {
                        tile.X += (byte)((256 - image.Width) / 2);
                        tile.Y += (byte)((256 - image.Height) / 2);
                    }
                }
                #endregion
                #region create gridplane mold
                else
                {
                    mold.Gridplane = true;
                    mold.Tiles = new List<Sprites.Mold.Tile>();
                    // create tile and initialize properties
                    var tile = new Sprites.Mold.Tile();
                    tile.Gridplane = true;
                    tile.Length = (width / 8) * (height / 8) + 1;
                    tile.Subtile_bytes = new ushort[16];
                    if (width == 24 && height == 24) tile.Format = 0;
                    else if (width == 24 && height == 32) tile.Format = 1;
                    else if (width == 32 && height == 24) tile.Format = 2;
                    else if (width == 32 && height == 32) tile.Format = 3;
                    // read each 8x8 tile in mold image
                    for (int y = 0; y < height / 8; y++)
                    {
                        for (int x = 0; x < width / 8; x++)
                        {
                            int[] dst = GetPixelRegion(pixels_image, width, height, 8, 8, x * 8, y * 8);
                            if (Bits.Empty(dst))
                            {
                                tile.Subtile_bytes[y * (width / 8) + x] = 0;
                                continue;
                            }
                            // read each 8x8 tile from culled graphic set and assign indexes
                            for (int b = 0; b < 32; b++)
                            {
                                for (int a = 0; a < 16; a++)
                                {
                                    int index = b * 16 + a;
                                    int[] src = GetPixelRegion(pixels_graphics, 128, 256, 8, 8, a * 8, b * 8);
                                    if (Bits.Compare(src, dst))
                                    {
                                        // set index of subtile
                                        tile.Subtile_bytes[y * (width / 8) + x] = (ushort)Math.Min(512, index + 1 + startingIndex);
                                        // if index over 255, needs to be 16bit
                                        if (index > 255)
                                            tile.Is16bit = true;
                                    }
                                }
                            }
                        }
                    }
                    if (tile.Is16bit)
                        tile.Length += 2;
                    //
                    mold.Tiles.Add(tile);
                }
                #endregion
                if (targetType == CommonType.Mold)
                    molds.Add(mold);
            }
            // set new palette
            palette = rpalette;
        }
        /// <summary>
        /// Combines several bitmaps into a single bitmap.
        /// </summary>
        /// <param name="images">The collection of bitmaps.</param>
        /// <param name="maxwidth">The maximum width of the bitmap sheet.</param>
        /// <param name="maxheight">The maximum height of the bitmap sheet.</param>
        /// <param name="tilesize">The default tile size. Typically 8 or 16.</param>
        /// <param name="padedges">Each image will be padded to fit a multiple of the tile size.</param>
        /// <returns></returns>
        public static void ImagesToTilemaps(ref Bitmap[] images, ref int[] palette, int moldIndex, byte format,
            ref byte[] graphics_, ref Tile[] tiles_, ref byte[][] tilemaps_, bool newPalette)
        {
            int count = images.Length;
            int width = Math.Min(256, images[0].Width / 16 * 16);
            if (images[0].Width % 16 != 0) width += 16;
            int height = Math.Min(256, images[0].Height / 16 * 16);
            if (images[0].Height % 16 != 0) height += 16;
            // pad dimensions to multiples of 16
            var resized = new Bitmap[count];//(width, height);
            for (int i = 0; i < resized.Length; i++)
            {
                resized[i] = new Bitmap(width, height);
                var temp = Graphics.FromImage(resized[i]);
                temp.DrawImage(images[i], 0, 0, Math.Min(256, images[i].Width), Math.Min(256, images[i].Height));
            }
            // declare stuff
            var pixels = new int[count][];
            var graphics = new byte[count][];
            var graphicsCulled = new byte[count][];
            var tilesets = new byte[count][];
            var tiles = new Tile[count][];//[(width / 16) * (height / 16)];
            var tilemaps = new byte[count][];
            int graphicsLength = 0;
            int[] reducedPalette = null;
            if (moldIndex < count)
            {
                pixels[moldIndex] = ImageToPixels(resized[moldIndex]);
                // convert to BPP, create culled graphics
                graphics[moldIndex] = new byte[0x10000]; // a BPP format copy of the original image
                if (!newPalette)
                    reducedPalette = palette;
                else
                    reducedPalette = Do.ReduceColorDepth(pixels[moldIndex], format == 0x10 ? 4 : 16, palette[0]);
                PixelsToBPP(pixels[moldIndex], graphics[moldIndex], new Size(width / 8, height / 8), reducedPalette, format);
                graphicsCulled[moldIndex] = CullGraphics(graphics[moldIndex], palette, format, false);
                graphicsLength += graphicsCulled[moldIndex].Length;
            }
            for (int i = 0; i < count; i++)
            {
                if (i == moldIndex && moldIndex < count)
                    continue;
                // convert to pixels
                pixels[i] = ImageToPixels(resized[i]);
                // convert to BPP, create culled graphics
                graphics[i] = new byte[0x10000]; // a BPP format copy of the original image
                if (reducedPalette == null)
                    reducedPalette = Do.ReduceColorDepth(pixels[i], format == 0x10 ? 4 : 16, palette[0]);
                PixelsToBPP(pixels[i], graphics[i], new Size(width / 8, height / 8), reducedPalette, format);
                graphicsCulled[i] = CullGraphics(graphics[i], palette, format, false);
                graphicsLength += graphicsCulled[i].Length;
            }
            // combine all images' graphics into one array
            byte[] culledGraphics = new byte[graphicsLength];
            for (int i = 0, position = 0; i < graphicsCulled.Length; i++)
            {
                graphicsCulled[i].CopyTo(culledGraphics, position);
                position += graphicsCulled[i].Length;
            }
            // convert to raw tileset
            for (int i = 0; i < tilesets.Length; i++)
            {
                tilesets[i] = new byte[0x1000];
                for (int y = 0; y < height / 8; y++)
                {
                    for (int x = 0; x < width / 8; x++)
                    {
                        int index = y * (width / 8) + x;
                        var subtileA = DrawSubtile((ushort)index, 0x20, graphics[i], reducedPalette, format);
                        for (int a = 0; a < culledGraphics.Length / format; a++)
                        {
                            var subtileB = DrawSubtile((ushort)a, 0x20, culledGraphics, reducedPalette, format);
                            if (Bits.Compare(subtileA.Pixels, subtileB.Pixels))
                            {
                                tilesets[i][index * 2] = (byte)a;
                                break;
                            }
                        }
                    }
                }
            }
            // convert raw tileset data to array of Tile16x16[]
            for (int i = 0; i < tiles.Length; i++)
            {
                tiles[i] = new Tile[(width / 16) * (height / 16)];
                for (int a = 0; a < tiles[i].Length; a++)
                    tiles[i][a] = new Tile(a);
            }
            int tilesLength = 0;
            for (int i = 0; i < tiles.Length; i++)
            {
                for (int y = 0; y < height / 16; y++)
                {
                    for (int x = 0; x < width / 16; x++)
                    {
                        int index = y * (width / 16) + x;
                        for (int z = 0; z < 4; z++)
                        {
                            int offset = y * (width / 2) + (x * 4);
                            if (z % 2 == 1)
                                offset += 2;
                            if (z / 2 == 1)
                                offset += (width / 8) * 2;
                            ushort tile = tilesets[i][offset];
                            byte prop = tilesets[i][offset + 1];
                            var source = DrawSubtile(tile, prop, culledGraphics, reducedPalette, format);
                            tiles[i][index].Subtiles[z] = source;
                        }
                    }
                }
                // cull tileset
                CullTileset(ref tiles[i]);
                tilesLength += tiles[i].Length;
            }
            // combine into one tileset
            var culledTiles = new Tile[tilesLength];
            for (int i = 0, position = 0; i < tiles.Length; i++)
            {
                tiles[i].CopyTo(culledTiles, position);
                position += tiles[i].Length;
            }
            // draw tilemap
            for (int i = 0; i < tilemaps.Length; i++)
            {
                tilemaps[i] = new byte[(width / 16) * (height / 16)];
                //pixels[i] = ImageToPixels(resized[i]);
                for (int y = 0; y < height / 16; y++)
                {
                    for (int x = 0; x < width / 16; x++)
                    {
                        int index = y * (width / 16) + x;
                        var region = new Rectangle(x * 16, y * 16, 16, 16);
                        int[] regionA = GetPixelRegion(graphics[i], format, reducedPalette, width / 8, x * 2, y * 2, 2, 2, 0);
                        for (int a = 0; a < culledTiles.Length; a++)
                        {
                            if (Bits.Compare(regionA, culledTiles[a].Pixels))
                            {
                                tilemaps[i][index] = (byte)a;
                                break;
                            }
                        }
                    }
                }
            }
            images[0] = resized[0];
            palette = reducedPalette;
            graphics_ = culledGraphics;
            tiles_ = culledTiles;
            tilemaps_ = tilemaps;
        }
        /// <summary>
        /// Determines whether a rectangle is within the bounds of a source rectangle.
        /// </summary>
        /// <param name="src">The source rectangle.</param>
        /// <param name="var">The rectangle to check.</param>
        /// <returns></returns>
        public static bool WithinBounds(Rectangle regionA, Rectangle regionB)
        {
            if (regionB.Left < regionA.Left || regionB.Right > regionA.Right ||
                regionB.Top < regionA.Top || regionB.Bottom > regionA.Bottom)
                return false;
            return true;
        }
        public static bool WithinBounds(Rectangle regionA, Rectangle regionB, Sprites.Mold.Tile tile)
        {
            if (regionA.X > regionB.X + regionB.Width ||
                regionA.Y > regionB.Y + regionB.Height)
                return false;
            if (regionA.X + regionA.Width < regionB.X ||
                regionA.Y + regionA.Height < regionB.Y)
                return false;
            for (int b = 0; b < 2; b++)
            {
                for (int a = 0; a < 2; a++)
                {
                    Subtile subtile = tile.Subtile_tiles[b * 2 + a];
                    for (int y = 0; y < 8; y++)
                    {
                        for (int x = 0; x < 8; x++)
                        {
                            int x_ = a * 8 + x;
                            int y_ = b * 8 + y;
                            if (subtile.Pixels[y * 8 + x] != 0)
                            {
                                if (regionA.X < regionB.X + x_ + 1 &&
                                    regionA.Y < regionB.Y + y_ + 1 &&
                                    regionA.X + regionA.Width > regionB.X + x_ &&
                                    regionA.Y + regionA.Height > regionB.Y + y_)
                                    return true;
                            }
                        }
                    }
                }
            }
            return false;
        }

        #endregion

        #region Convert from pixels

        /// <summary>
        /// Converts a raw pixel array to either 4bpp or 2bpp format.
        /// Returns the respective palette indexes for the tiles it converted.
        /// </summary>
        /// <param name="src">The pixel array to convert.</param>
        /// <param name="dst">The data array to write the converted graphics to.</param>
        /// <param name="size">The size (in 8x8 tiles) of the image.</param>
        /// <param name="palette">The palettes to apply to the image.</param>
        /// <param name="format">The format of the graphics, either 0x10 or 0x20 (2bpp and 4bpp, respectively).</param>
        /// <returns></returns>
        public static int[] PixelsToBPP(int[] src, byte[] dst, Size size, int[][] palettes, byte format)
        {
            var indexes = new int[size.Width * size.Height];
            Do.PixelsToBPP_Worker = new BackgroundWorker();
            Do.PixelsToBPP_Worker.WorkerReportsProgress = true;
            Do.PixelsToBPP_Worker.WorkerSupportsCancellation = true;
            Do.PixelsToBPP_Worker.DoWork += (s, e) =>
                PixelsToBPP_Worker_DoWork(s, e, src, dst, size, palettes, format, indexes);
            Do.PixelsToBPP_Worker.ProgressChanged += new ProgressChangedEventHandler(PixelsToBPP_Worker_ProgressChanged);
            Do.PixelsToBPP_Worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(PixelsToBPP_Worker_RunWorkerCompleted);
            Do.ProgressBar = new ProgressBar("CONVERTING IMPORTED IMAGE TO BPP FORMAT...", size.Width * size.Height, PixelsToBPP_Worker);
            ProgressBar.Show();
            PixelsToBPP_Worker.RunWorkerAsync();
            while (PixelsToBPP_Worker.IsBusy)
            {
                if (PixelsToBPP_Worker.CancellationPending)
                    return null;
                Application.DoEvents();
            }
            return indexes;
        }
        private static void PixelsToBPP_Worker_DoWork(object sender, DoWorkEventArgs e, int[] src, byte[] dst, Size size, int[][] palettes, byte format, int[] indexes)
        {
            Point p;
            int offset;
            byte bit;
            for (int y_ = 0; y_ < size.Height; y_++)
            {
                for (int x_ = 0; x_ < size.Width; x_++)
                {
                    int i = y_ * size.Width + x_;
                    if (PixelsToBPP_Worker.CancellationPending)
                        return;
                    PixelsToBPP_Worker.ReportProgress(i);
                    var regionDest = new Rectangle(x_ * 8, y_ * 8, 8, 8);
                    var regionSrc = new Rectangle(0, 0, size.Width * 8, size.Height * 8);
                    indexes[i] = GetClosestPaletteIndex(palettes, src, regionSrc, regionDest);
                    ApplyPaletteToPixels(src, palettes[indexes[i]], regionSrc, regionDest);
                    for (int y = 0; y < 8; y++)
                    {
                        for (int x = 0; x < 8; x++)
                        {
                            p = new Point(i % size.Width * 8 + x, i / size.Width * 8 + y);
                            bit = (byte)(x ^ 7);
                            offset = (i * format) + (y * 2);
                            if (format == 0x20)
                            {
                                Bits.SetBit(dst, offset, bit, (src[p.Y * (size.Width * 8) + p.X] & 1) == 1);
                                Bits.SetBit(dst, offset + 1, bit, (src[p.Y * (size.Width * 8) + p.X] & 2) == 2);
                                Bits.SetBit(dst, offset + 16, bit, (src[p.Y * (size.Width * 8) + p.X] & 4) == 4);
                                Bits.SetBit(dst, offset + 17, bit, (src[p.Y * (size.Width * 8) + p.X] & 8) == 8);
                            }
                            else
                            {
                                Bits.SetBit(dst, offset, bit, (src[p.Y * (size.Width * 8) + p.X] & 1) == 1);
                                Bits.SetBit(dst, offset + 1, bit, (src[p.Y * (size.Width * 8) + p.X] & 2) == 2);
                            }
                        }
                    }
                }
            }
        }
        private static void PixelsToBPP_Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ProgressBar.PerformStep("CONVERTING TILE #" + e.ProgressPercentage);
        }
        private static void PixelsToBPP_Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ProgressBar.Close();
        }
        private static BackgroundWorker PixelsToBPP_Worker;
        /// <summary>
        /// Converts a raw pixel array to either 4bpp or 2bpp format.
        /// </summary>
        /// <param name="src">The pixel array to convert.</param>
        /// <param name="dst">The data array to write the converted graphics to.</param>
        /// <param name="size">The size (in 8x8 tiles) of the image.</param>
        /// <param name="palette">The palette to apply to the image.</param>
        /// <param name="format">The format of the graphics, either 0x10 or 0x20 (2bpp and 4bpp, respectively).</param>
        /// <returns></returns>
        public static void PixelsToBPP(int[] src, byte[] dst, Size size, int[] palette, byte format)
        {
            Point p;
            int offset;
            byte bit;
            for (int y_ = 0; y_ < size.Height; y_++)
            {
                for (int x_ = 0; x_ < size.Width; x_++)
                {
                    int i = y_ * size.Width + x_;
                    var regionDest = new Rectangle(x_ * 8, y_ * 8, 8, 8);
                    var regionSrc = new Rectangle(0, 0, size.Width * 8, size.Height * 8);
                    ApplyPaletteToPixels(src, palette, regionSrc, regionDest);
                    for (int y = 0; y < 8; y++)
                    {
                        for (int x = 0; x < 8; x++)
                        {
                            p = new Point(i % size.Width * 8 + x, i / size.Width * 8 + y);
                            bit = (byte)(x ^ 7);
                            offset = (i * format) + (y * 2);
                            if (format == 0x20)
                            {
                                Bits.SetBit(dst, offset, bit, (src[p.Y * (size.Width * 8) + p.X] & 1) == 1);
                                Bits.SetBit(dst, offset + 1, bit, (src[p.Y * (size.Width * 8) + p.X] & 2) == 2);
                                Bits.SetBit(dst, offset + 16, bit, (src[p.Y * (size.Width * 8) + p.X] & 4) == 4);
                                Bits.SetBit(dst, offset + 17, bit, (src[p.Y * (size.Width * 8) + p.X] & 8) == 8);
                            }
                            else
                            {
                                Bits.SetBit(dst, offset, bit, (src[p.Y * (size.Width * 8) + p.X] & 1) == 1);
                                Bits.SetBit(dst, offset + 1, bit, (src[p.Y * (size.Width * 8) + p.X] & 2) == 2);
                            }
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Converts a pixel array into an image.
        /// </summary>
        /// <param name="array">The pixel array.</param>
        /// <param name="imageWidth">The image width.</param>
        /// <param name="imageHeight">The image height.</param>
        /// <returns></returns>
        public static Bitmap PixelsToImage(int[] array, int imageWidth, int imageHeight)
        {
            var bitmap = new Bitmap(imageWidth, imageHeight, PixelFormat.Format32bppPArgb);
            var rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
            var bitmapData = bitmap.LockBits(rect, ImageLockMode.ReadWrite, bitmap.PixelFormat);
            var pNative = bitmapData.Scan0;
            Marshal.Copy(array, 0, pNative, imageWidth * imageHeight);
            bitmap.UnlockBits(bitmapData);
            return bitmap;
        }
        /// <summary>
        /// Converts a pixel array into an image.
        /// </summary>
        /// <param name="array">The pixel array.</param>
        /// <param name="width">The pixel array width.</param>
        /// <param name="height">The pixel array height.</param>
        /// <param name="imageWidth">The final image width.</param>
        /// <param name="imageHeight">The final image height.</param>
        /// <returns></returns>
        public static Bitmap PixelsToImage(int[] array, int width, int height, int imageWidth, int imageHeight)
        {
            // first transfer source pixels into larger pixel array
            var pixels = new int[imageWidth * imageHeight];
            PixelsToPixels(array, pixels, imageWidth, new Rectangle(0, 0, width, height));
            // convert to image and return value
            return PixelsToImage(pixels, imageWidth, imageHeight);
        }
        /// <summary>
        /// Transfers the RGB pixel data of one array to another, optionally ignoring empty values.
        /// </summary>
        /// <param name="src">The pixel array to read from.</param>
        /// <param name="dst">The pixel array to write to.</param>
        /// <param name="drawAsTransparent">Specifies whether or not to ignore empty pixels when drawing to the destination array.</param>
        public static void PixelsToPixels(int[] src, int[] dst, bool drawAsTransparent)
        {
            for (int i = 0; i < src.Length && i < dst.Length; i++)
                if (src[i] != 0 || !drawAsTransparent)
                    dst[i] = src[i];
        }
        /// <summary>
        /// Draws a pixel array to a region in another pixel array.
        /// </summary>
        /// <param name="src">The pixel array to draw from.</param>
        /// <param name="dst">The pixel array to draw to.</param>
        /// <param name="dstWidth">The width of the pixel array being drawn to.</param>
        /// <param name="region">The region of the pixel array to draw to.</param>
        public static void PixelsToPixels(int[] src, int[] dst, int dstWidth, Rectangle region)
        {
            PixelsToPixels(src, dst, dstWidth, region, false, false);
        }
        public static void PixelsToPixels(int[] src, int[] dst, int dstWidth, int srcX, int srcY, int srcWidth, int srcHeight, bool drawAsTransparent)
        {
            PixelsToPixels(src, dst, dstWidth, new Rectangle(srcX, srcY, srcWidth, srcHeight), drawAsTransparent, false);
        }
        public static void PixelsToPixels(int[] src, int[] dst, int dstWidth, int srcX, int srcY, int srcWidth, int srcHeight)
        {
            PixelsToPixels(src, dst, dstWidth, new Rectangle(srcX, srcY, srcWidth, srcHeight), false, false);
        }
        public static void PixelsToPixels(int[] src, int[] dst, int dstWidth, Rectangle region, bool drawAsTransparent)
        {
            PixelsToPixels(src, dst, dstWidth, region, true, false);
        }
        public static void PixelsToPixels(int[] src, int[] dst, int dstWidth, Rectangle region, bool drawAsTransparent, bool colorMath)
        {
            for (int y = region.Y, y_ = 0; y < region.Y + region.Height; y++, y_++)
            {
                for (int x = region.X, x_ = 0; x < region.X + region.Width; x++, x_++)
                {
                    if (y < 0 || x < 0) continue;
                    if (y * dstWidth + x >= dst.Length) continue;
                    if (y_ * region.Width + x_ >= src.Length) continue;
                    if (src[y_ * region.Width + x_] == 0 && drawAsTransparent) continue;
                    if (colorMath)
                        dst[y * dstWidth + x] = ColorMath(src[y_ * region.Width + x_], dst[y * dstWidth + x], false, false);
                    else
                        dst[y * dstWidth + x] = src[y_ * region.Width + x_];
                }
            }
        }
        /// <summary>
        /// Draws a region in a pixel array to a region in another pixel array.
        /// </summary>
        /// <param name="src">The pixel array to draw from.</param>
        /// <param name="dst">The pixel array to draw to.</param>
        /// <param name="srcWidth">The width of the pixel array being drawn from.</param>
        /// <param name="dstWidth">The width of the pixel array being drawn to.</param>
        /// <param name="srcRegion">The region of the pixel array being drawn from.</param>
        /// <param name="dstRegion">The region of the pixel array being drawn to.</param>
        public static void PixelsToPixels(int[] src, int[] dst, int srcWidth, int dstWidth, Rectangle srcRegion, Rectangle dstRegion)
        {
            int[] tempSrc = new int[src.Length]; src.CopyTo(tempSrc, 0);
            for (int y = dstRegion.Y, y_ = srcRegion.Y; y < dstRegion.Y + dstRegion.Height && y_ < srcRegion.Y + srcRegion.Height; y++, y_++)
            {
                for (int x = dstRegion.X, x_ = srcRegion.X; x < dstRegion.X + dstRegion.Width && x_ < srcRegion.X + srcRegion.Width; x++, x_++)
                {
                    if (y * dstWidth + x >= dst.Length) continue;
                    if (y_ * srcWidth + x_ >= tempSrc.Length) continue;
                    dst[y * dstWidth + x] = tempSrc[y_ * srcWidth + x_];
                }
            }
        }

        #endregion

        #region Convert to pixels

        /// <summary>
        /// Converts an image into a pixel array.
        /// </summary>
        /// <param name="image">The image to convert.</param>
        /// <returns></returns>
        public static int[] ImageToPixels(Bitmap image)
        {
            var size = image.Size;
            int w = image.Width / 8 * 8;
            int h = image.Height / 8 * 8;
            int[] temp = new int[w * h];
            for (int y = 0; y < size.Height && y < h; y++)
            {
                for (int x = 0; x < size.Width && x < w; x++)
                    temp[y * w + x] = image.GetPixel(x, y).ToArgb();
            }
            return temp;
        }
        /// <summary>
        /// Converts an image into a pixel array.
        /// </summary>
        /// <param name="image">The image to convert.</param>
        /// <param name="transparent">The color in the image that is transparent.</param>
        /// <returns></returns>
        public static int[] ImageToPixels(Bitmap image, Color transparent)
        {
            var size = image.Size;
            int w = image.Width / 8 * 8;
            int h = image.Height / 8 * 8;
            int[] temp = new int[w * h];
            for (int y = 0; y < size.Height && y < h; y++)
            {
                for (int x = 0; x < size.Width && x < w; x++)
                {
                    if (image.GetPixel(x, y).ToArgb() == transparent.ToArgb())
                        continue;
                    temp[y * w + x] = image.GetPixel(x, y).ToArgb();
                }
            }
            return temp;
        }
        /// <summary>
        /// Converts an image into a pixel array.
        /// </summary>
        /// <param name="image">The image to convert.</param>
        /// <param name="maximumSize">The size of the converted image.</param>
        /// <returns></returns>
        public static int[] ImageToPixels(Bitmap image, Size size)
        {
            int w = image.Width / 8 * 8;
            int h = image.Height / 8 * 8;
            int[] temp = new int[w * h];
            for (int y = 0; y < size.Height && y < h; y++)
            {
                for (int x = 0; x < size.Width && x < w; x++)
                    temp[y * w + x] = image.GetPixel(x, y).ToArgb();
            }
            return temp;
        }
        /// <summary>
        /// Converts a region of an image into a pixel array.
        /// </summary>
        /// <param name="image">The image to convert.</param>
        /// <param name="maximumSize">The size of the converted image.</param>
        /// <param name="region">The region of the image to convert.</param>
        /// <returns></returns>
        public static int[] ImageToPixels(Bitmap image, Size size, Rectangle region)
        {
            int[] temp = new int[region.Width * region.Height];
            for (int y = 0, y_ = region.Y; y < size.Height && y < region.Height && y_ < image.Height; y++, y_++)
            {
                for (int x = 0, x_ = region.X; x < size.Width && x < region.Width && x_ < image.Width; x++, x_++)
                    temp[y * region.Width + x] = image.GetPixel(x_, y_).ToArgb();
            }
            return temp;
        }
        /// <summary>
        /// Converts a 16x16 tileset into a pixel array.
        /// </summary>
        /// <param name="tileset">The tiles to draw from.</param>
        /// <param name="x">The X coordinate in the pixel array to begin drawing at.</param>
        /// <param name="y">The Y coordinate in the pixel array to begin drawing at.</param>
        /// <param name="width">The width, in 16x16 tile units, of the tileset.</param>
        /// <param name="height">The height, in 16x16 tile units, of the tileset.</param>
        /// <param name="startAtTile">The tile to start drawing from in the tileset</param>
        /// <param name="priority1">Sets whether to draw the tileset as a blue priority 1 silhouette.</param>
        /// <returns></returns>
        public static int[] TilesetToPixels(Tile[] tileset, int width, int height, int startAtTile, bool priority1)
        {
            var pixels = new int[(width * 16) * (height * 16)];
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    int index = (y * width + x) + startAtTile;
                    if (index >= tileset.Length)
                        continue;
                    if (!priority1)
                    {
                        for (int z = 0; z < 4; z++)
                        {
                            int X = (x * 16) + ((z % 2) * 8);
                            int Y = (y * 16) + ((z / 2) * 8);
                            Do.PixelsToPixels(tileset[index].Subtiles[z].Pixels,
                                pixels, width * 16, new Rectangle(X, Y, 8, 8));
                        }
                    }
                    else
                        Do.PixelsToPixels(tileset[index].Pixels_P1, pixels, width * 16,
                            new Rectangle(x * 16, y * 16, 16, 16));
                }
            }
            return pixels;
        }
        /// <summary>
        /// Converts a 32x32 tileset into a pixel array.
        /// </summary>
        /// <param name="tiles">The tiles to draw from.</param>
        /// <param name="x">The X coordinate in the pixel array to begin drawing at.</param>
        /// <param name="y">The Y coordinate in the pixel array to begin drawing at.</param>
        /// <param name="width">The width, in 32x32 tile units, of the tileset.</param>
        /// <param name="height">The height, in 32x32 tile units, of the tileset.</param>
        /// <param name="startAtTile">The tile to start drawing from in the tileset</param>
        /// <returns></returns>
        public static int[] TilesetToPixels(Areas.OverlapTile[] tileset, int width, int height, int startAtTile)
        {
            var pixels = new int[(width * 32) * (height * 32)];
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Do.PixelsToPixels(tileset[(y * width + x) + startAtTile].Pixels, pixels, width * 32,
                        new Rectangle(x * 32, y * 32, 32, 32));
                }
            }
            return pixels;
        }
        /// <summary>
        /// Draws a pixel array from a set of colors in a palette set.
        /// </summary>
        /// <param name="colorWidth">The width of each color block.</param>
        /// <param name="colorHeight">The height of each color block.</param>
        /// <param name="cols">The number of color rows the pixel array will have.</param>
        /// <param name="rows">The number of color columns the pixel array will have</param>
        /// <returns></returns>
        public static int[] PaletteToPixels(int[] palette, int colorWidth, int colorHeight, int cols, int rows, int startCol)
        {
            var size = new Size(colorWidth * cols, colorHeight * rows);
            var pixels = new int[size.Width * size.Height];
            for (int i = 0; i < rows; i++)
            {
                for (int a = startCol; a < cols; a++)
                {
                    for (int y = 0; y < colorHeight; y++)
                    {
                        for (int x = 0; x < colorWidth; x++)
                            pixels[((y + (i * colorHeight)) * size.Width) + x + (a * colorWidth)] = palette[i * cols + a];
                    }
                }
            }
            return pixels;
        }
        /// <summary>
        /// Draws a pixel array from a set of colors in a palette set.
        /// </summary>
        /// <param name="palette">The set of palettes.</param>
        /// <param name="colorWidth">The width of each color block.</param>
        /// <param name="colorHeight">The height of each color block.</param>
        /// <param name="cols">The number of color rows the pixel array will have.</param>
        /// <param name="rows">The number of color columns the pixel array will have</param>
        /// <param name="start">The palette to start drawing from</param>
        /// <param name="startColor">The column to start drawing from</param>
        /// <returns></returns>
        public static int[] PaletteToPixels(int[][] palette, int colorWidth, int colorHeight, int cols, int rows, int startRow, int startCol)
        {
            var size = new Size(colorWidth * cols, colorHeight * rows);
            var pixels = new int[size.Width * size.Height];
            for (int i = 0; i < rows - startRow && i < palette.Length; i++)
            {
                for (int a = startCol; a < cols; a++)
                {
                    for (int y = 0; y < colorHeight; y++)
                    {
                        for (int x = 0; x < colorWidth; x++)
                            pixels[((y + (i * colorHeight)) * size.Width) + x + (a * colorWidth)] = palette[i + startRow][a];
                    }
                }
            }
            return pixels;
        }

        #endregion

        #region RGB conversion

        /// <summary>
        /// Combines an array of reds, greens and blues into an array of colors.
        /// </summary>
        /// <param name="reds"></param>
        /// <param name="greens"></param>
        /// <param name="blues"></param>
        /// <returns></returns>
        public static int[] RGBToColors(int[] reds, int[] greens, int[] blues)
        {
            var palette = new int[reds.Length];
            for (int i = 0; i < palette.Length; i++)
            {
                palette[i] = Color.FromArgb(reds[i], greens[i], blues[i]).ToArgb();
            }
            return palette;
        }
        /// <summary>
        /// Combines an array of reds, greens and blues into an array of colors.
        /// </summary>
        /// <param name="reds"></param>
        /// <param name="greens"></param>
        /// <param name="blues"></param>
        /// <param name="count">The number of palettes in the set.</param>
        /// <param name="size">The number of colors in each palette.</param>
        /// <returns></returns>
        public static int[][] RGBToColors(int[] reds, int[] greens, int[] blues, int count, int size)
        {
            var palettes = new int[count][];
            for (int a = 0; a < palettes.Length; a++)
            {
                palettes[a] = new int[size];
                for (int i = 0; i < palettes[a].Length; i++)
                {
                    palettes[a][i] = Color.FromArgb(reds[a * size + i], greens[a * size + i], blues[a * size + i]).ToArgb();
                }
            }
            return palettes;
        }
        /// <summary>
        /// Converts an array of colors into a raw 15-bit SNES palette format.
        /// </summary>
        /// <param name="rgbPalette">The palette to convert</param>
        /// <param name="paletteSize">The number of colors in the palette.</param>
        /// <returns></returns>
        public static byte[] RGBToSnesPalette(int[] rgbPalette, int paletteSize)
        {
            byte[] snesPalette = new byte[paletteSize * 2];
            for (int i = 0; i < paletteSize; i++)
            {
                int r = (int)(Color.FromArgb(rgbPalette[i]).R / 8);
                int g = (int)(Color.FromArgb(rgbPalette[i]).G / 8);
                int b = (int)(Color.FromArgb(rgbPalette[i]).B / 8);
                ushort color = (ushort)((b << 10) | (g << 5) | r);
                Bits.SetShort(snesPalette, i * 2, color);
            }
            return snesPalette;
        }
        /// <summary>
        /// Converts a raw 15-bit SNES format palette into a set of RGB palettes.
        /// </summary>
        /// <param name="snesPalette">The raw SNES palette data.</param>
        /// <param name="paletteSize">The number of colors in each palette.</param>
        /// <param name="reds">The array of red values in each palette.</param>
        /// <param name="greens">The array of green values in each palette.</param>
        /// <param name="blues">The array of blue values in each palette.</param>
        public static void SnesPaletteToRGB(byte[] snesPalette, int index, int[] reds, int[] greens, int[] blues)
        {
            for (int i = 0; i < reds.Length; i++)
            {
                ushort color = Bits.GetShort(snesPalette, (index * reds.Length) + (i * 2));
                reds[i] = (color % 0x20) * 8;
                greens[i] = ((color >> 5) % 0x20) * 8;
                blues[i] = ((color >> 10) % 0x20) * 8;
            }
        }

        #endregion

        /// <summary>
        /// Draws a border around an RGB array of pixels.
        /// </summary>
        /// <param name="pixels">The pixels to write to.</param>
        /// <param name="rgbColor">The RGB color of the border.</param>
        public static void DrawBorder(int[] pixels, int width, int rgbColor)
        {
            int innerEdge = width - 1;
            int outerEdge = width + 1;
            int[] edges = {
                              -1, 1, 
                              -width, width, 
                              -outerEdge, outerEdge, 
                              -innerEdge, innerEdge 
                          };
            int height = pixels.Length / width;

            // Pixels that have a border drawn on them
            bool[] border = new bool[pixels.Length];

            // Draw the borders
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    // Don't draw border over existing pixels
                    if (pixels[y * width + x] != 0)
                        continue;

                    // Check surrounding pixels and draw border if any active
                    if ((x < width - 1 && !border[y * width + (x + 1)] && pixels[y * width + (x + 1)] != 0) ||

                        (x > 0 && !border[y * width + (x - 1)] && pixels[y * width + (x - 1)] != 0) ||

                        (y < height - 1 && !border[(y + 1) * width + x] && pixels[(y + 1) * width + x] != 0) ||

                        (y > 0 && !border[(y - 1) * width + x] && pixels[(y - 1) * width + x] != 0) ||

                        (x < width - 1 && y < height - 1 && !border[(y + 1) * width + (x + 1)] && pixels[(y + 1) * width + (x + 1)] != 0) ||

                        (x < width - 1 && y > 0 && !border[(y - 1) * width + (x + 1)] && pixels[(y - 1) * width + (x + 1)] != 0) ||

                        (x > 0 && y < height - 1 && !border[(y + 1) * width + (x - 1)] && pixels[(y + 1) * width + (x - 1)] != 0) ||

                        (x > 0 && y > 0 && !border[(y - 1) * width + (x - 1)] && pixels[(y - 1) * width + (x - 1)] != 0))
                    {
                        pixels[y * width + x] = rgbColor;
                        border[y * width + x] = true;
                    }
                }
            }
        }
        /// <summary>
        /// Draws a 1-pixel shadow in the lower-right region an RGB array of pixels.
        /// </summary>
        /// <param name="pixels">The pixels to write to.</param>
        /// <param name="rgbColor">The RGB color of the shadow.</param>
        public static void DrawShadow(int[] pixels, int width, int rgbColor)
        {
            for (int y = 0; y < 11; y++)
            {
                for (int x = 0; x < width - 1; x++)
                {
                    if (pixels[y * width + x] != 0 && pixels[y * width + x] != rgbColor) // Draw shadow if it is a set pixel, and not border color
                    {
                        if (pixels[(y + 1) * width + (x + 1)] == 0) // if shadow pixels are empty
                            pixels[(y + 1) * width + (x + 1)] = rgbColor; // fill pixel with shadow color
                    }
                }
            }
        }
    }
}
