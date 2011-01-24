using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Media;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Forms;
using LAZYSHELL.Properties;
using LAZYSHELL.Previewer;

namespace LAZYSHELL
{
    /// <summary>
    /// Provides a number of functions for drawing and modifying images and writing text.
    /// </summary>
    public static class Do
    {
        private static ProgressBar ProgressBar;
        #region Drawing
        /// <summary>
        /// Applys a palette to a pixel array.
        /// </summary>
        /// <param name="array">The pixel array.</param>
        /// <param name="palette">The palette to apply.</param>
        /// <returns></returns>
        public static void ApplyPaletteToPixels(int[] array, int[] palette)
        {
            Color[] colors = new Color[palette.Length];
            Color[] newColors = new Color[palette.Length];

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
            Color[] colors = new Color[palette.Length];
            Color[] newColors = new Color[palette.Length];

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
        /// <param name="fontCharacters">The font characters to copy to.</param>
        /// <param name="size">The size (in 8x8 tiles) of the 2bpp graphics to copy from.</param>
        /// <param name="palette">The palette of the font characters.</param>
        /// <returns></returns>
        public static void CopyOverFontTable(byte[] src, FontCharacter[] fontCharacters, Size size, int[] palette)
        {
            byte[] temp = new byte[src.Length];
            int o = 0;
            switch (fontCharacters[0].FontType)
            {
                case 0: // menu
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
                case 1: // dialogue
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
                case 2: // description
                    src.CopyTo(temp, 0);
                    break;
            }

            byte[] character;
            for (int i = 0; i * fontCharacters[0].Graphics.Length < temp.Length && i < temp.Length; i++)
            {
                if (fontCharacters[i].FontType == 1 && (i == 59 || i == 61))    // skip [ and ]
                    continue;
                character = Bits.GetByteArray(temp, i * fontCharacters[i].Graphics.Length, fontCharacters[i].Graphics.Length);
                CopyOverBPPGraphics(
                    character, fontCharacters[i].Graphics,
                    new Rectangle(0, 0, fontCharacters[i].MaxWidth, fontCharacters[i].Height),
                    fontCharacters[i].MaxWidth / 8, 0, 0x10);
                if (fontCharacters[i].FontType != 3)
                    fontCharacters[i].Width = (byte)(fontCharacters[i].GetRightMostPixel(palette) + 1);
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
        public static void CopyToTileset(byte[] src, byte[] tileset, int[][] palettes, int[] paletteIndexes, bool checkIfFlipped, bool priority1, byte tileSize, byte tileLength, Size tilesetSize, int tileIndexStart)
        {
            ArrayList tiles_a = new ArrayList();    // the tileset, essentially, in array form
            ArrayList tiles_b = new ArrayList();    // used for redrawing a culled 4bpp graphic block
            ArrayList tiles_c = new ArrayList();
            for (int i = 0; i < src.Length / tileSize; i++)
            {
                Tile8x8 temp = new Tile8x8(i, src, i * tileSize, palettes[paletteIndexes[i]], false, false, false, false);
                tiles_a.Add(temp);
                tiles_b.Add(temp);
                tiles_c.Add(temp);
            }
            // look through entire set of tiles for duplicates
            for (int a = 0; a < tiles_a.Count; a++)
            {
                Tile8x8 tile_a = (Tile8x8)tiles_a[a];
                if (tile_a.TileIndex != a) continue;  // skip if already set as duplicate
                for (int b = a; b < tiles_a.Count; b++)
                {
                    Tile8x8 tile_b = (Tile8x8)tiles_a[b];
                    if (a == b) continue;   // cannot be duplicate of self
                    if (Bits.Compare(tile_a.Pixels, tile_b.Pixels)) // if a duplicate...
                    {
                        // first set the tile to the one that it's a duplicate of
                        tile_b.TileIndex = a;
                        // then remove
                        tiles_b.Remove(tile_b);
                    }
                    if (checkIfFlipped)
                    {
                        byte status = GetFlippedStatus(tile_a.Pixels, tile_b.Pixels);
                        if ((status & 0x40) == 0x40)
                        {
                            tile_b.Mirror = true;
                            tile_b.TileIndex = a;
                            tiles_b.Remove(tile_b);
                        }
                        if ((status & 0x80) == 0x80)
                        {
                            tile_b.Invert = true;
                            tile_b.TileIndex = a;
                            tiles_b.Remove(tile_b);
                        }
                    }
                }
            }
            // redraw into newly culled graphic block, and reorganize tilenums
            int c = 0; byte[] culledGraphics = new byte[src.Length];
            foreach (Tile8x8 tile in tiles_b)
            {
                int orig = tile.TileIndex;
                Buffer.BlockCopy(src, tile.TileIndex * tileSize, culledGraphics, c * tileSize, tileSize);
                tile.TileIndex = c;
                // check for other duplicates or mirrors/inversions of this current tile
                foreach (Tile8x8 check in tiles_a)
                {
                    if (check.TileIndex == orig)
                        check.TileIndex = c;
                }
                c++;
            }
            // now rewrite tileset data using tiles_a
            c = 0; byte[] culledTileset = new byte[tileset.Length];

            foreach (Tile8x8 tile in tiles_a)
            {
                culledTileset[c * tileLength] = (byte)(tile.TileIndex + tileIndexStart);
                if (tileLength == 2)
                {
                    culledTileset[c * tileLength + 1] = (byte)(paletteIndexes[c] << 2);    // set the palette index
                    culledTileset[c * tileLength + 1] |= (byte)(tile.TileIndex >> 8); // set the graphic index
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
        /// Copy a block of 4bpp graphics into a tileset.
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
        /// <returns>Returns the final graphic size of the imported graphics.</returns>
        public static int CopyToTileset(byte[] src, byte[] tileset, int[] palette, int paletteIndex, bool checkIfFlipped, bool priority1, byte format, byte tileLength, Size tilesetSize, int tileIndexStart)
        {
            ArrayList tiles_a = new ArrayList();    // the tileset, essentially, in array form
            ArrayList tiles_b = new ArrayList();    // used for redrawing a culled 4bpp graphic block
            for (int i = 0; i < src.Length / format; i++)
            {
                Tile8x8 temp = new Tile8x8(i, src, i * format, palette, false, false, false, false);
                tiles_a.Add(temp);
                tiles_b.Add(temp);
            }
            // look through entire set of tiles for duplicates
            for (int a = 0; a < tiles_a.Count; a++)
            {
                Tile8x8 tile_a = (Tile8x8)tiles_a[a];
                if (tile_a.TileIndex != a) continue;  // skip if already set as duplicate
                for (int b = a; b < tiles_a.Count; b++)
                {
                    Tile8x8 tile_b = (Tile8x8)tiles_a[b];
                    if (a == b) continue;   // cannot be duplicate of self
                    if (Bits.Compare(tile_a.Pixels, tile_b.Pixels)) // if a duplicate...
                    {
                        // first set the tile to the one that it's a duplicate of
                        tile_b.TileIndex = a;
                        // then remove
                        tiles_b.Remove(tile_b);
                    }
                    if (checkIfFlipped) // if effect tileset, don't bother setting status
                    {
                        byte status = GetFlippedStatus(tile_a.Pixels, tile_b.Pixels);
                        if ((status & 0x40) == 0x40)
                        {
                            tile_b.Mirror = true;
                            tile_b.TileIndex = a;
                            tiles_b.Remove(tile_b);
                        }
                        if ((status & 0x80) == 0x80)
                        {
                            tile_b.Invert = true;
                            tile_b.TileIndex = a;
                            tiles_b.Remove(tile_b);
                        }
                    }
                }
            }
            // redraw into newly culled graphic block, and reorganize tilenums
            int c = 0; byte[] culledGraphics = new byte[src.Length];
            foreach (Tile8x8 tile in tiles_b)
            {
                int orig = tile.TileIndex;
                Buffer.BlockCopy(src, tile.TileIndex * format, culledGraphics, c * format, format);
                tile.TileIndex = c;
                // check for other duplicates or mirrors/inversions of this current tile
                foreach (Tile8x8 check in tiles_a)
                {
                    if (check.TileIndex == orig)
                        check.TileIndex = c;
                }
                c++;
            }

            // now rewrite tileset data using tiles_a
            c = 0; byte[] culledTileset = new byte[tileset.Length];

            foreach (Tile8x8 tile in tiles_a)
            {
                if (c * tileLength >= culledTileset.Length)
                {
                    MessageBox.Show(
                        "Imported graphics were too large to fit into the tileset.",
                        "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                }
                culledTileset[c * tileLength] = (byte)(tile.TileIndex + tileIndexStart);
                if (tileLength == 2)
                {
                    culledTileset[c * tileLength + 1] = (byte)(paletteIndex << 2);    // set the palette index
                    culledTileset[c * tileLength + 1] |= (byte)(tile.TileIndex >> 8); // set the graphic index
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
        public static Rectangle Crop(int[] src, out int[] dst, int width, int height)
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
                byte[] temp = new byte[src.Length]; src.CopyTo(temp, 0); Bits.Fill(src, emptyTileIndex);
                Rectangle region = new Rectangle(leftEdge, topEdge, (rightEdge - leftEdge) + 1, (bottomEdge - topEdge) + 1);
                for (int y = 0, y_ = region.Top; y <= region.Height && y_ < region.Bottom; y++, y_++)
                {
                    for (int x = 0, x_ = region.Left; x <= region.Width && x_ < region.Right; x++, x_++)
                        src[y * region.Width + x] = temp[y_ * width + x_];
                }
                return region;
            }
        }
        /// <summary>
        /// Reorder indexes of tiles in a tileset based on duplicates.
        /// </summary>
        /// <param name="tileset">The raw tileset to reduce the size of.</param>
        public static void CullTileset(Tile16x16[] tileset)
        {
            // set duplicate tiles to originals
            ArrayList tilesetTiles = new ArrayList();
            foreach (Tile16x16 tile in tileset)
            {
                int contains = Contains(tile, tileset);
                if (tile.TileIndex == contains)
                    tilesetTiles.Add(tile);
                else
                    tile.TileIndex = contains;
            }
            // renumber tile indexes
            int c = 0;
            foreach (Tile16x16 tile in tilesetTiles)
                tile.TileIndex = c++;
            // finally cull the original tileset
            c = 0;
            foreach (Tile16x16 tile in tilesetTiles)
                tileset[c++] = tile;
        }
        /// <summary>
        /// Reorder indexes of tiles in a tileset based on duplicates and draws to a tilemap.
        /// </summary>
        /// <param name="tileset">The raw tileset to reduce the size of.</param>
        /// <param name="tilemap">The tilemap to draw to.</param>
        /// <param name="width">The width, in 16x16 tiles, of the tilemap.</param>
        /// <param name="height">The height, in 16x16 tiles, of the tilemap.</param>
        public static void CullTileset(Tile16x16[] tileset, byte[] tilemap, int width, int height)
        {
            // set duplicate tiles to originals
            ArrayList tilesetTiles = new ArrayList();
            foreach (Tile16x16 tile in tileset)
            {
                int contains = Contains(tile, tileset);
                if (Bits.Compare(tile.Pixels, new int[16 * 16]))
                    tile.TileIndex = 0xFF;
                else if (tile.TileIndex == contains)
                    tilesetTiles.Add(tile);
                else
                    tile.TileIndex = contains;
            }
            // renumber tile indexes
            int c = 0;
            foreach (Tile16x16 tile in tilesetTiles)
                tile.TileIndex = c++;
            // draw to tilemap with culled indexes
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (y * width + x >= tileset.Length ||
                        y * width + x >= tilemap.Length)
                        continue;
                    tilemap[y * width + x] = (byte)tileset[y * width + x].TileIndex;
                }
            }
            // finally cull the original tileset
            c = 0;
            foreach (Tile16x16 tile in tilesetTiles)
                tileset[c++] = tile;
            while (c < tileset.Length)
                tileset[c++] = new Tile16x16(c);
        }
        /// <summary>
        /// Draws an overworld menu frame with a certain size.
        /// </summary>
        /// <param name="size">The size, in 8x8 tiles, of the menu frame.</param>
        /// <param name="graphics">The 2bpp menu frame graphics.</param>
        /// <param name="palette">The 16-color menu frame palette.</param>
        /// <returns></returns>
        public static int[] DrawMenuFrame(Size size, byte[] graphics, int[] palette)
        {
            int[] pixels = new int[(size.Width * 8) * (size.Height * 8)];
            // set tileset
            Tile8x8[] frameTileset = new Tile8x8[16 * 2];
            for (int i = 0; i < frameTileset.Length; i++)
                frameTileset[i] = new Tile8x8(i, graphics, i * 0x10, palette, false, false, false, true);
            // draw tiles to pixels
            PixelsToPixels(frameTileset[0x00].Pixels, pixels, size.Width * 8, new Rectangle(0, 0, 8, 8));
            PixelsToPixels(frameTileset[0x01].Pixels, pixels, size.Width * 8, new Rectangle(8, 0, 8, 8));
            PixelsToPixels(frameTileset[0x03].Pixels, pixels, size.Width * 8, new Rectangle((size.Width - 2) * 8, 0, 8, 8));
            PixelsToPixels(frameTileset[0x04].Pixels, pixels, size.Width * 8, new Rectangle((size.Width - 1) * 8, 0, 8, 8));
            PixelsToPixels(frameTileset[0x10].Pixels, pixels, size.Width * 8, new Rectangle(0, 8, 8, 8));
            PixelsToPixels(frameTileset[0x14].Pixels, pixels, size.Width * 8, new Rectangle((size.Width - 1) * 8, 8, 8, 8));

            PixelsToPixels(frameTileset[0x17].Pixels, pixels, size.Width * 8, new Rectangle(0, (size.Height - 1) * 8, 8, 8));
            PixelsToPixels(frameTileset[0x18].Pixels, pixels, size.Width * 8, new Rectangle(8, (size.Height - 1) * 8, 8, 8));
            PixelsToPixels(frameTileset[0x1A].Pixels, pixels, size.Width * 8, new Rectangle((size.Width - 2) * 8, (size.Height - 1) * 8, 8, 8));
            PixelsToPixels(frameTileset[0x1B].Pixels, pixels, size.Width * 8, new Rectangle((size.Width - 1) * 8, (size.Height - 1) * 8, 8, 8));
            PixelsToPixels(frameTileset[0x10].Pixels, pixels, size.Width * 8, new Rectangle(0, (size.Height - 2) * 8, 8, 8));
            PixelsToPixels(frameTileset[0x14].Pixels, pixels, size.Width * 8, new Rectangle((size.Width - 1) * 8, (size.Height - 2) * 8, 8, 8));
            for (int x = 2; x < size.Width - 2; x++)
            {
                PixelsToPixels(frameTileset[0x02].Pixels, pixels, size.Width * 8, new Rectangle(x * 8, 0, 8, 8));
                PixelsToPixels(frameTileset[0x19].Pixels, pixels, size.Width * 8, new Rectangle(x * 8, (size.Height - 1) * 8, 8, 8));
            }
            for (int y = 2; y < size.Height - 2; y++)
            {
                PixelsToPixels(frameTileset[0x05].Pixels, pixels, size.Width * 8, new Rectangle(0, y * 8, 8, 8));
                PixelsToPixels(frameTileset[0x06].Pixels, pixels, size.Width * 8, new Rectangle((size.Width - 1) * 8, y * 8, 8, 8));
            }
            return pixels;
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
        public static Tile8x8 DrawTile8x8(ushort num, byte status, byte[] graphics, int[][] palettes, byte tileSize)
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
            Tile8x8 tile = new Tile8x8(num, graphics, offset, palette, mirrored, inverted, priorityOne, twobpp);
            tile.PaletteIndex = paletteIndex;
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
        public static Tile8x8 DrawTile8x8(ushort num, byte status, byte[] graphics, int[] palette, byte tileSize)
        {
            byte paletteIndex = (byte)((status >> 2) & 0x07);
            bool priorityOne = (status & 0x20) == 0x20;
            bool mirrored = (status & 0x40) == 0x40;
            bool inverted = (status & 0x80) == 0x80;
            bool twobpp = tileSize == 0x10;

            int offset = num * tileSize;
            if (offset >= graphics.Length) offset = 0;

            Tile8x8 tile = new Tile8x8(num, graphics, offset, palette, mirrored, inverted, priorityOne, twobpp);
            tile.PaletteIndex = paletteIndex;
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
        public static Tile8x8 DrawTile8x8(ushort num, byte paletteIndex, bool priorityOne, bool mirrored, bool inverted, byte[] graphics, int[][] palettes, byte tileSize)
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
            Tile8x8 tile = new Tile8x8(num, graphics, offset, palette, mirrored, inverted, priorityOne, twobpp);
            tile.PaletteIndex = paletteIndex;
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
        public static Tile8x8 DrawTile8x8(ushort num, byte paletteIndex, bool priorityOne, bool mirrored, bool inverted, byte[] graphics, int[] palette, byte tileSize)
        {
            bool twobpp = tileSize == 0x10;

            int offset = num * tileSize;
            if (offset >= graphics.Length) offset = 0;

            Tile8x8 tile = new Tile8x8(num, graphics, offset, palette, mirrored, inverted, priorityOne, twobpp);
            tile.PaletteIndex = paletteIndex;
            return tile;
        }
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
        public static int EditPixelBPP(byte[] src, int srcOffset, int[] palette, Graphics graphics, int zoom, string action, int x, int y, int index, int color, int width, int height, byte format)
        {
            if (x < 0 || x >= (width * 8) * zoom || y < 0 || y >= (height * 8) * zoom)
                return color;
            if (action == "") return color;

            int offset = (y / (8 * zoom)) * 16 + (x / (8 * zoom));
            byte row = (byte)(y / zoom % 8);
            byte col = (byte)(x / zoom % 8);
            byte bit = (byte)(col ^ 7);
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
            if (format == 0x20 && offset + 17 >= src.Length)
                return color;
            if (format == 0x10 && offset + 1 >= src.Length)
                return color;
            Point p;
            Rectangle c;
            switch (action)
            {
                case "draw":
                    Rectangle n = new Rectangle(new Point(x - (x % zoom), y - (y % zoom)), new Size(zoom, zoom));
                    Bits.SetBit(src, offset, bit, (color & 1) == 1);
                    Bits.SetBit(src, offset + 1, bit, (color & 2) == 2);
                    if (format == 0x20)
                    {
                        Bits.SetBit(src, offset + 16, bit, (color & 4) == 4);
                        Bits.SetBit(src, offset + 17, bit, (color & 8) == 8);
                    }
                    p = new Point(x / zoom * zoom, y / zoom * zoom);
                    c = new Rectangle(p, new Size(zoom, zoom));
                    graphics.FillRectangle(new SolidBrush(Color.FromArgb(palette[color])), c);
                    break;
                case "erase":
                    Bits.SetBit(src, offset, bit, false);
                    Bits.SetBit(src, offset + 1, bit, false);
                    if (format == 0x20)
                    {
                        Bits.SetBit(src, offset + 16, bit, false);
                        Bits.SetBit(src, offset + 17, bit, false);
                    }
                    break;
                case "select":
                    color = 0;
                    if (Bits.GetBit(src, offset, bit)) color |= 1;
                    if (Bits.GetBit(src, offset + 1, bit)) color |= 2;
                    if (format == 0x20)
                    {
                        if (Bits.GetBit(src, offset + 16, bit)) color |= 4;
                        if (Bits.GetBit(src, offset + 17, bit)) color |= 8;
                    }
                    break;
            }
            return color;
        }
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
        public static void FlipHorizontal(Tile16x16 tile)
        {
            for (int i = 0; i < 4; i++)
            {
                tile.Subtiles[i].Mirror = !tile.Subtiles[i].Mirror;
                FlipHorizontal(tile.Subtiles[i].Pixels, 8, 8);
                FlipHorizontal(tile.Subtiles[i].Colors, 8, 8);
            }
            Tile8x8 temp = tile.Subtiles[0].Copy();
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
        public static void FlipVertical(Tile16x16 tile)
        {
            for (int i = 0; i < 4; i++)
            {
                tile.Subtiles[i].Invert = !tile.Subtiles[i].Invert;
                FlipVertical(tile.Subtiles[i].Pixels, 8, 8);
                FlipVertical(tile.Subtiles[i].Colors, 8, 8);
            }
            Tile8x8 temp = tile.Subtiles[0].Copy();
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
        public static void FlipHorizontal(Mold.Tile tile)
        {
            for (int i = 0; i < 4; i++)
            {
                tile.Subtiles[i].Mirror = !tile.Subtiles[i].Mirror;
                FlipHorizontal(tile.Subtiles[i].Pixels, 8, 8);
                FlipHorizontal(tile.Subtiles[i].Colors, 8, 8);
            }
            Tile8x8 temp = tile.Subtiles[0].Copy();
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
        public static void FlipVertical(Mold.Tile tile)
        {
            for (int i = 0; i < 4; i++)
            {
                tile.Subtiles[i].Invert = !tile.Subtiles[i].Invert;
                FlipVertical(tile.Subtiles[i].Pixels, 8, 8);
                FlipVertical(tile.Subtiles[i].Colors, 8, 8);
            }
            Tile8x8 temp = tile.Subtiles[0].Copy();
            tile.Subtiles[2].CopyTo(tile.Subtiles[0]);
            temp.CopyTo(tile.Subtiles[2]);
            temp = tile.Subtiles[1].Copy();
            tile.Subtiles[3].CopyTo(tile.Subtiles[1]);
            temp.CopyTo(tile.Subtiles[3]);
        }
        /// <summary>
        /// Flip horizontally a set of 16x16 tiles.
        /// </summary>
        /// <param name="tiles">The tiles to flip horizontally.</param>
        /// <param name="width">The width, in 16x16 tile units, of the tile set.</param>
        /// <param name="height">The height, in 16x16 tile units, of the tile set.</param>
        public static void FlipHorizontal(Tile16x16[] tiles, int width, int height)
        {
            Tile16x16 temp;
            for (int y = 0; y < height; y++)
            {
                int a = 0;
                for (int b = width - 1; a < width / 2; a++, b--)
                {
                    // first, flip the tiles
                    temp = tiles[(y * width) + a].Copy();
                    tiles[(y * width) + a] = tiles[(y * width) + b].Copy();
                    tiles[(y * width) + b] = temp.Copy();
                    // now flip subtiles in both tiles
                    Tile16x16 tile = tiles[(y * width) + a];
                    for (int c = 0; c < 2; c++)
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            tile.Subtiles[i].Mirror = !tile.Subtiles[i].Mirror;
                            FlipHorizontal(tile.Subtiles[i].Pixels, 8, 8);
                            FlipHorizontal(tile.Subtiles[i].Colors, 8, 8);
                        }
                        Tile8x8 subtile = tile.Subtiles[0].Copy();
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
        public static void FlipVertical(Tile16x16[] tiles, int width, int height)
        {
            Tile16x16 temp;
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
                    Tile16x16 tile = tiles[(a * width) + x];
                    for (int c = 0; c < 2; c++)
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            tile.Subtiles[i].Invert = !tile.Subtiles[i].Invert;
                            FlipVertical(tile.Subtiles[i].Pixels, 8, 8);
                            FlipVertical(tile.Subtiles[i].Colors, 8, 8);
                        }
                        Tile8x8 subtile = tile.Subtiles[0].Copy();
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
        /// <summary>
        /// Returns a pixel array from a region in another pixel array.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="src">The region of the pixel array to draw from.</param>
        /// <param name="dst">The region of the pixel array to draw to.</param>
        /// <returns></returns>
        public static int[] GetPixelRegion(int[] array, Rectangle src, Rectangle dst)
        {
            int[] temp = new int[dst.Width * dst.Height];
            for (int y = 0; y < dst.Width; y++)
            {
                if (y + src.Y >= src.Height) break;
                for (int x = 0; x < dst.Height; x++)
                {
                    if (x + src.X >= src.Width) break;
                    temp[y * dst.Width + x] = array[(y + src.Y) * src.Width + (x + src.X)];
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
            Tile8x8 temp;
            int[] pixels = new int[(regWidth * 8) * (regHeight * 8)];
            for (int y = regY; y < regY + regHeight; y++)
            {
                for (int x = regX; x < regX + regWidth; x++)
                {
                    int tileIndex = y * regWidth + x;
                    if ((tileIndex * format) + offset >= snes.Length)
                        continue;
                    temp = new Tile8x8(tileIndex, snes, tileIndex * format + offset, palette, false, false, false, format == 0x10);
                    Do.PixelsToPixels(temp.Pixels, pixels, regWidth * 8, new Rectangle(x * 8, y * 8, 8, 8));
                }
            }
            return pixels;
        }
        /// <summary>
        /// Converts an image into a pixel array.
        /// </summary>
        /// <param name="image">The image to convert.</param>
        /// <returns></returns>
        public static int[] ImageToPixels(Bitmap image)
        {
            Size size = image.Size;
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
            Size size = image.Size;
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
            for (int y = 0, y_ = region.Y; y < size.Height && y < region.Height && y_ < region.Y + region.Height; y++, y_++)
            {
                for (int x = 0, x_ = region.X; x < size.Width && x < region.Width && x_ < region.X + region.Width; x++, x_++)
                    temp[y * region.Width + x] = image.GetPixel(x_, y_).ToArgb();
            }
            return temp;
        }
        /// <summary>
        /// Draws a pixel array from a set of colors in a palette set.
        /// </summary>
        /// <param name="colorWidth">The width of each color block.</param>
        /// <param name="colorHeight">The height of each color block.</param>
        /// <param name="cols">The number of color rows the pixel array will have.</param>
        /// <param name="rows">The number of color columns the pixel array will have</param>
        /// <returns></returns>
        public static int[] PaletteToPixels(int[] palette, int colorWidth, int colorHeight, int cols, int rows)
        {
            Size size = new Size(colorWidth * cols, colorHeight * rows);
            int[] pixels = new int[size.Width * size.Height];
            for (int i = 0; i < rows; i++)
            {
                for (int a = 0; a < cols; a++)
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
        /// <returns></returns>
        public static int[] PaletteToPixels(int[][] palette, int colorWidth, int colorHeight, int cols, int rows, int start)
        {
            Size size = new Size(colorWidth * cols, colorHeight * rows);
            int[] pixels = new int[size.Width * size.Height];
            for (int i = 0; i < rows - start && i < palette.Length; i++)
            {
                for (int a = 0; a < cols; a++)
                {
                    for (int y = 0; y < colorHeight; y++)
                    {
                        for (int x = 0; x < colorWidth; x++)
                            pixels[((y + (i * colorHeight)) * size.Width) + x + (a * colorWidth)] = palette[i + start][a];
                    }
                }
            }
            return pixels;
        }
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
            int[] indexes = new int[size.Width * size.Height];

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

                    Rectangle regionDest = new Rectangle(x_ * 8, y_ * 8, 8, 8);
                    Rectangle regionSrc = new Rectangle(0, 0, size.Width * 8, size.Height * 8);
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
                    Rectangle regionDest = new Rectangle(x_ * 8, y_ * 8, 8, 8);
                    Rectangle regionSrc = new Rectangle(0, 0, size.Width * 8, size.Height * 8);
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
        /// <param name="width">The image width.</param>
        /// <param name="height">The image height.</param>
        /// <returns></returns>
        public static Bitmap PixelsToImage(int[] array, int width, int height)
        {
            Bitmap image = null;
            unsafe
            {
                fixed (void* firstPixel = &array[0])
                {
                    IntPtr ip = new IntPtr(firstPixel);
                    if (image != null)
                        image.Dispose();
                    image = new Bitmap(width, height, width * 4,
                        System.Drawing.Imaging.PixelFormat.Format32bppPArgb, ip);
                }
            }
            return new Bitmap(image);
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
            for (int y = region.Y, y_ = 0; y < region.Y + region.Height; y++, y_++)
            {
                for (int x = region.X, x_ = 0; x < region.X + region.Width; x++, x_++)
                {
                    if (y < 0 || x < 0) continue;
                    if (y * dstWidth + x >= dst.Length) continue;
                    if (y_ * region.Width + x_ >= src.Length) continue;
                    dst[y * dstWidth + x] = src[y_ * region.Width + x_];
                }
            }
        }
        public static void PixelsToPixels(int[] src, int[] dst, int dstWidth, Rectangle region, bool drawAsTransparent)
        {
            for (int y = region.Y, y_ = 0; y < region.Y + region.Height; y++, y_++)
            {
                for (int x = region.X, x_ = 0; x < region.X + region.Width; x++, x_++)
                {
                    if (y < 0 || x < 0) continue;
                    if (y * dstWidth + x >= dst.Length) continue;
                    if (y_ * region.Width + x_ >= src.Length) continue;
                    if (src[y_ * region.Width + x_] == 0 && drawAsTransparent) continue;
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
        /// <summary>
        /// Combines an array of reds, greens and blues into an array of colors.
        /// </summary>
        /// <param name="reds"></param>
        /// <param name="greens"></param>
        /// <param name="blues"></param>
        /// <returns></returns>
        public static int[] RGBToColors(int[] reds, int[] greens, int[] blues)
        {
            int[] palette = new int[reds.Length];
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
            int[][] palettes = new int[count][];
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
        public static int[] TilesetToPixels(Tile16x16[] tileset, int width, int height, int startAtTile, bool priority1)
        {
            int[] pixels = new int[(width * 16) * (height * 16)];
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (!priority1)
                        Do.PixelsToPixels(tileset[(y * width + x) + startAtTile].Pixels, pixels, width * 16,
                            new Rectangle(x * 16, y * 16, 16, 16));
                    else
                        Do.PixelsToPixels(tileset[(y * width + x) + startAtTile].Pixels_P1, pixels, width * 16,
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
        public static int[] TilesetToPixels(Tile32x32[] tileset, int width, int height, int startAtTile)
        {
            int[] pixels = new int[(width * 32) * (height * 32)];

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
        #endregion
        #region Coloring
        public static void RGBtoHSL(double r, double g, double b, out double h, out double s, out double l)
        {
            h = s = l = 0;
            double max = Math.Max(r, Math.Max(g, b));
            double min = Math.Min(r, Math.Min(g, b));
            l = (min + max) / 2.0;
            if (l <= 0.0) return;
            double dif = max - min; s = dif;
            if (s > 0.0)
                s /= (l <= 0.5) ? (max + min) : (2.0 - max - min);
            else return;
            double r2 = (max - r) / dif;
            double g2 = (max - g) / dif;
            double b2 = (max - b) / dif;
            if (r == max)
                h = (g == min ? 5.0 + b2 : 1.0 - g2);
            else if (g == max)
                h = (b == min ? 1.0 + r2 : 3.0 - b2);
            else
                h = (r == min ? 3.0 + g2 : 5.0 - r2);
            h /= 6.0;
        }
        public static void HSLtoRGB(double h, double s, double l, out double r, out double g, out double b)
        {
            r = g = b = l;   // default to gray
            double v = (l <= 0.5) ? (l * (1.0 + s)) : (l + s - l * s);
            if (v > 0)
            {
                double m = l + l - v;
                double sv = (v - m) / v;
                h *= 6.0;
                int sextant = (int)h;
                double fract = h - sextant;
                double vsf = v * sv * fract;
                double mid1 = m + vsf;
                double mid2 = v - vsf;
                switch (sextant)
                {
                    case 0:
                        r = v;
                        g = mid1;
                        b = m;
                        break;
                    case 1:
                        r = mid2;
                        g = v;
                        b = m;
                        break;
                    case 2:
                        r = m;
                        g = v;
                        b = mid1;
                        break;
                    case 3:
                        r = m;
                        g = mid2;
                        b = v;
                        break;
                    case 4:
                        r = mid1;
                        g = m;
                        b = v;
                        break;
                    case 5:
                        r = v;
                        g = m;
                        b = mid2;
                        break;
                }
            }
        }
        public static int HSLtoRGB(double h, double sl, double l)
        {
            double r = l;
            double g = l;
            double b = l;   // default to gray
            double v = (l <= 0.5) ? (l * (1.0 + sl)) : (l + sl - l * sl);
            if (v > 0)
            {
                double m = l + l - v;
                double sv = (v - m) / v;
                h *= 6.0;
                int sextant = (int)h;
                double fract = h - sextant;
                double vsf = v * sv * fract;
                double mid1 = m + vsf;
                double mid2 = v - vsf;
                switch (sextant)
                {
                    case 0:
                        r = v;
                        g = mid1;
                        b = m;
                        break;
                    case 1:
                        r = mid2;
                        g = v;
                        b = m;
                        break;
                    case 2:
                        r = m;
                        g = v;
                        b = mid1;
                        break;
                    case 3:
                        r = m;
                        g = mid2;
                        b = v;
                        break;
                    case 4:
                        r = mid1;
                        g = m;
                        b = v;
                        break;
                    case 5:
                        r = v;
                        g = m;
                        b = mid2;
                        break;
                }
            }
            return Color.FromArgb((int)r & 0xF8, (int)g & 0xF8, (int)b & 0xF8).ToArgb();
        }
        public static void RGBtoHSL(int[] r, int[] g, int[] b, out double[] h, out double[] s, out double[] l)
        {
            h = new double[r.Length];
            s = new double[r.Length];
            l = new double[r.Length];
            for (int i = 0; i < h.Length; i++)
            {
                double r_ = r[i];
                double g_ = g[i];
                double b_ = b[i];
                h[i] = s[i] = l[i] = 0;
                double max = Math.Max(r_, Math.Max(g_, b_));
                double min = Math.Min(r_, Math.Min(g_, b_));
                l[i] = (min + max) / 2.0;
                if (l[i] <= 0.0) return;
                double dif = max - min; s[i] = dif;
                if (s[i] > 0.0)
                    s[i] /= (l[i] <= 0.5) ? (max + min) : (2.0 - max - min);
                else return;
                double r2 = (max - r_) / dif;
                double g2 = (max - g_) / dif;
                double b2 = (max - b_) / dif;
                if (r_ == max)
                    h[i] = (g_ == min ? 5.0 + b2 : 1.0 - g2);
                else if (g[i] == max)
                    h[i] = (b_ == min ? 1.0 + r2 : 3.0 - b2);
                else
                    h[i] = (r_ == min ? 3.0 + g2 : 5.0 - r2);
                h[i] /= 6.0;
            }
        }
        /// <summary>
        /// Reduces the color depth of a pixel array. Returns a newly created palette.
        /// </summary>
        /// <param name="src"></param>
        /// <param name="depth"></param>
        /// <param name="transparent"></param>
        public static int[] ReduceColorDepth(int[] src, int depth, int transparent)
        {
            List<int> colors = new List<int>();
            Color darkest = Color.FromArgb(255, 255, 255, 255);
            Color lightest = Color.FromArgb(255, 0, 0, 0);
            foreach (int pixel in src)
            {
                Color color = Color.FromArgb(pixel);
                // skip if opacity not full
                if (color.A < 255)
                    continue;
                // find the brightest and darkest colors, the new palette needs them
                if (color.GetBrightness() > lightest.GetBrightness())
                    lightest = color;
                if (color.GetBrightness() < darkest.GetBrightness())
                    darkest = color;
                if (!colors.Contains(pixel))
                    colors.Add(color.ToArgb());
            }
            int[] palette = new int[depth];
            // if color amount less than depth, simply add all colors to palette and return
            if (colors.Count < depth)
            {
                palette[0] = transparent;
                for (int i = 1, a = 0; a < colors.Count; i++, a++)
                    palette[i] = colors[a];
                return palette;
            }
            // find the median colors in the list of colors for a total based on the depth
            colors.Sort();
            int increment = colors.Count / (depth - 1);
            for (int i = 0, p = 2; i < colors.Count && p < palette.Length - 1; i += increment, p++)
                palette[p] = colors[i];
            palette[0] = transparent;
            palette[1] = lightest.ToArgb();
            palette[depth - 1] = darkest.ToArgb();
            return palette;
        }
        #endregion
        #region Text
        /// <summary>
        /// Returns a value indicating whether a collection of objects contains a specific object.
        /// </summary>
        /// <param name="value">The object to search for.</param>
        /// <param name="collection">The collection of objects to search.</param>
        /// <returns></returns>
        public static bool Contains(object value, object[] collection)
        {
            foreach (object item in collection)
                if (item.GetType() == typeof(ArrayList))
                {
                    foreach (object arrayItem in (ArrayList)item)
                        if (arrayItem == value)
                            return true;
                }
                else if (item == value)
                    return true;
            return false;
        }
        public static bool Contains(object value, ArrayList collection)
        {
            foreach (object item in collection)
                if (item.GetType() == typeof(ArrayList))
                {
                    foreach (object arrayItem in (ArrayList)item)
                        if (arrayItem == value)
                            return true;
                }
                else if (item == value)
                    return true;
            return false;
        }
        public static bool Contains(string original, string value, StringComparison comparisionType)
        {
            return original.IndexOf(value, comparisionType) >= 0;
        }
        public static bool Contains(string original, string value, StringComparison comparisionType, out int index)
        {
            index = original.IndexOf(value, comparisionType);
            return index >= 0;
        }
        /// <summary>
        /// Searches for an occurrence of a tile within a tileset and returns the index of the occurrence if found.
        /// Otherwise it returns the index of the tile being searched for.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="collection"></param>
        /// <returns></returns>
        public static int Contains(Tile16x16 value, Tile16x16[] collection)
        {
            foreach (Tile16x16 item in collection)
                if (item == value)
                    return value.TileIndex;
                else if (Bits.Compare(item.Pixels, value.Pixels))
                    return item.TileIndex;
            return value.TileIndex;
        }
        /// <summary>
        /// Converts an ASCII format string into a raw char array using a keystroke table.
        /// </summary>
        /// <param name="text">The ASCII string to convert.</param>
        /// <param name="keystrokes">The keystroke table to use.</param>
        /// <param name="length">The maximum length of the converted char array.</param>
        /// <returns></returns>
        public static char[] ASCIIToRaw(string text, StringCollection keystrokes, int length)
        {
            char[] temp = new char[length];
            int i = 0;
            for (; i < temp.Length && i < text.Length; i++)
            {
                for (int a = 0; a < keystrokes.Count; a++)
                {
                    if (keystrokes[a] == text.Substring(i, 1))
                        temp[i] = (char)a;
                }
            }
            // pad with spaces
            for (; i < temp.Length; i++)
                temp[i] = '\x20';
            return temp;
        }
        /// <summary>
        /// Convert a raw char array to viewable ASCII format using a table of keystrokes.
        /// </summary>
        /// <param name="chars">The char array to convert.</param>
        /// <param name="keystrokes">The keystroke table to use.</param>
        /// <returns></returns>
        public static string RawToASCII(char[] chars, StringCollection keystrokes)
        {
            string temp = "";
            for (int i = 0; i < chars.Length; i++)
            {
                if (keystrokes[chars[i]] == "")
                    temp += "_";
                temp += keystrokes[chars[i]];
            }
            return temp;
        }
        /// <summary>
        /// Search for a string in an array of string, and add every instance to a specified listbox.
        /// Each item in the listbox will be tagged with the respective index;
        /// </summary>
        /// <param name="names">The list of names to search.</param>
        /// <param name="name">The string to search for.</param>
        /// <param name="listBox">The listbox to write to.</param>
        /// <param name="ignoreCase">Specifies whether to ignore case when searching.</param>
        public static void Search(ComboBox.ObjectCollection names, string name, ListBox listBox, bool ignoreCase)
        {
            listBox.BeginUpdate();
            listBox.Items.Clear();
            if (name == "")
            {
                listBox.EndUpdate();
                return;
            }
            for (int i = 0; i < names.Count; i++)
            {
                if (((string)names[i]).IndexOf(name, StringComparison.CurrentCultureIgnoreCase) >= 0)
                    listBox.Items.Add(names[i]);
            }
            listBox.EndUpdate();
            listBox.BringToFront();
        }
        public static void Search(object listControl, string name, bool ignoreCase)
        {
        }
        #endregion
        #region Data Managing
        private static BackgroundWorker Export_Worker;
        private static BackgroundWorker Import_Worker;
        /// <summary>
        /// Exports an element to a file.
        /// </summary>
        /// <param name="element">The element to export.</param>
        /// <param name="fileName">Ignored. Set this to null when passing parameter.</param>
        /// <param name="fullPath">The full local path, including the filename with the extension.</param>
        public static void Export(object element, string fileName, string fullPath)
        {
            if (element.GetType() == typeof(byte[]))
            {
                FileStream fs = new FileStream(fullPath, FileMode.Create, FileAccess.ReadWrite);
                BinaryWriter bw = new BinaryWriter(fs);
                bw.Write((byte[])element);
                bw.Close();
                fs.Close();
            }
            else if (element.GetType() == typeof(Bitmap))
                ((Bitmap)element).Save(fullPath, ImageFormat.Png);
            else
            {
                BinaryFormatter bf = new BinaryFormatter();
                Stream s = File.Create(fullPath);
                bf.Serialize(s, element);
                s.Close();
            }
        }
        /// <summary>
        /// Exports an element to a file.
        /// </summary>
        /// <param name="element">The element to export.</param>
        /// <param name="fileName">The filename to save as, with the extension.</param>
        public static void Export(object element, string fileName)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = fileName;
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.RestoreDirectory = true;
            if (element.GetType() == typeof(byte[]))
            {
                saveFileDialog.Filter = "Binary files (*.bin)|*.bin|All files (*.*)|*.*";
                saveFileDialog.Title = "Export";
                if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
                    return;
                FileStream fs = new FileStream(saveFileDialog.FileName, FileMode.Create, FileAccess.ReadWrite);
                BinaryWriter bw = new BinaryWriter(fs);
                bw.Write((byte[])element);
                bw.Close();
                fs.Close();
            }
            else if (element.GetType() == typeof(Bitmap))
            {
                saveFileDialog.Filter = "Image file (*.png)|*.png|All files (*.*)|*.*";
                saveFileDialog.Title = "Save Image";
                if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
                    return;
                ((Bitmap)element).Save(saveFileDialog.FileName, ImageFormat.Png);
            }
            else
            {
                saveFileDialog.Filter = "Data file (*.dat)|*.dat|All files (*.*)|*.*";
                saveFileDialog.Title = "Export";
                if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
                    return;
                BinaryFormatter bf = new BinaryFormatter();
                Stream s = File.Create(saveFileDialog.FileName + ".dat");
                bf.Serialize(s, element);
                s.Close();
            }
        }
        /// <summary>
        /// Exports a set of elements to files to a specified folder.
        /// </summary>
        /// <param name="elements">The elements to export.</param>
        /// <param name="fileName">The base filename to export as, without an extension.</param>
        /// <param name="folder">The folder to create.</param>
        /// <param name="type">The type of element. Preferably in all caps and singular form.</param>
        /// <param name="showProgressBar">Sets whether or not to show the progress bar when exporting.</param>
        public static void Export(object[] elements, string fileName, string folder, string type, bool showProgressBar)
        {
            // first, open and create directory
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            folderBrowserDialog1.SelectedPath = Settings.Default.LastDirectory;
            folderBrowserDialog1.Description = "Select directory to export to";
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                Settings.Default.LastDirectory = folderBrowserDialog1.SelectedPath;
            else
                return;
            string fullPath = folderBrowserDialog1.SelectedPath + "\\" + folder + "\\" + fileName;
            Export(elements, fullPath, type, showProgressBar);
        }
        /// <summary>
        /// Exports a set of elements to files to a specified full path of a local folder.
        /// </summary>
        /// <param name="elements">The elements to export.</param>
        /// <param name="fullPath">The local path of the folder to export to, plus the filename without the index or extension.</param>
        /// <param name="type">The type of element. Preferably in all caps and singular form.</param>
        /// <param name="showProgressBar">Sets whether or not to show the progress bar when exporting.</param>
        public static void Export(object[] elements, string fullPath, string type, bool showProgressBar)
        {
            FileInfo fi = new FileInfo(fullPath);
            DirectoryInfo di = new DirectoryInfo(fi.DirectoryName);
            if (!di.Exists)
                di.Create();
            // set the backgroundworker properties
            Do.Export_Worker = new BackgroundWorker();
            Do.Export_Worker.WorkerReportsProgress = true;
            Do.Export_Worker.WorkerSupportsCancellation = true;
            Do.Export_Worker.DoWork += (s, e) => Export_Worker_DoWork(s, e, elements, fullPath);
            Do.Export_Worker.ProgressChanged += (s, e) => Export_Worker_ProgressChanged(s, e, type);
            Do.Export_Worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(Export_Worker_RunWorkerCompleted);
            if (showProgressBar)
            {
                ProgressBar = new ProgressBar("EXPORTING " + type + "S...", elements.Length, Export_Worker);
                ProgressBar.Show();
            }
            Export_Worker.RunWorkerAsync();
            while (Export_Worker.IsBusy)
                Application.DoEvents();
        }
        private static void Export_Worker_DoWork(object sender, DoWorkEventArgs e, object[] elements, string fullPath)
        {
            // Create the files
            for (int i = 0; i < elements.Length; i++)
            {
                if (Export_Worker.CancellationPending)
                    return;
                Export_Worker.ReportProgress(i);
                object element = elements[i];
                // if saving images
                if (element.GetType() == typeof(Bitmap))
                {
                    ((Bitmap)element).Save(
                        fullPath + "." + i.ToString("d" + elements.Length.ToString().Length) + ".png", ImageFormat.Png);
                }
                // if a byte[] array, then export to .bin
                else if (element.GetType() == typeof(byte[]))
                {
                    FileStream fs = new FileStream(
                        fullPath + "." + i.ToString("d" + elements.Length.ToString().Length) + ".bin",
                        FileMode.Create, FileAccess.ReadWrite);
                    BinaryWriter bw = new BinaryWriter(fs);
                    bw.Write((byte[])elements[i]);
                    bw.Close();
                    fs.Close();
                }
                // otherwise, export to .dat
                else
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    Stream s = File.Create(
                        fullPath + "." + i.ToString("d" + elements.Length.ToString().Length) + ".dat");
                    bf.Serialize(s, element);
                    s.Close();
                }
            }
        }
        private static void Export_Worker_ProgressChanged(object sender, ProgressChangedEventArgs e, string type)
        {
            if (ProgressBar != null && ProgressBar.Visible)
                ProgressBar.PerformStep("EXPORTING " + type + " #" + e.ProgressPercentage);
        }
        private static void Export_Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (ProgressBar != null && ProgressBar.Visible)
                ProgressBar.Close();
        }
        /// <summary>
        /// Imports a file into an element.
        /// </summary>
        /// <param name="element">The element to import to.</param>
        /// <param name="fileName">Ignored. Set this to null when passing parameter.</param>
        /// <param name="fullPath">The full local path, including the filename.</param>
        public static object Import(object element, string fullPath)
        {
            if (element.GetType() == typeof(byte[]))
            {
                FileStream fs = File.OpenRead(fullPath);
                BinaryReader br = new BinaryReader(fs);
                element = br.ReadBytes((int)fs.Length);
                br.Close();
                fs.Close();
            }
            else if (element.GetType() == typeof(Bitmap))
            {
                element = new Bitmap(Image.FromFile(fullPath));
            }
            else
            {
                Stream s = File.OpenRead(fullPath);
                BinaryFormatter bf = new BinaryFormatter();
                element = bf.Deserialize(s);
                s.Close();
            }
            return element;
        }
        /// <summary>
        /// Imports a file into an element.
        /// </summary>
        /// <param name="element">The element to import to.</param>
        /// <param name="fileName">The file to import from.</param>
        public static object Import(object element)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (element.GetType() == typeof(byte[]))
                openFileDialog.Filter = "Binary files (*.bin)|*.bin|All files (*.*)|*.*";
            else if (element.GetType() == typeof(Bitmap))
                openFileDialog.Filter = "Image files (*.gif,*.jpg,*.png)|*.gif;*.jpg;*.png|All files (*.*)|*.*";
            else
                openFileDialog.Filter = "Data files (*.dat)|*.dat|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 0;
            openFileDialog.RestoreDirectory = true;
            openFileDialog.Title = "Import";
            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                return null;
            return Import(element, openFileDialog.FileName);
        }
        /// <summary>
        /// Imports a file into an element from a set of files in a specified folder.
        /// </summary>
        /// <param name="element">The elements to import to.</param>
        /// <param name="fileName">The base filename to import as, without an extension.</param>
        /// <param name="folder">The folder to import from.</param>
        /// <param name="type">The type of element. Preferably in all caps and singular form.</param>
        /// <param name="showProgressBar">Sets whether or not to show the progress bar when importing.</param>
        public static void Import(object[] elements, string fileName, string folder, string type, bool showProgressBar)
        {
            // first, open and create directory
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            folderBrowserDialog1.SelectedPath = Settings.Default.LastDirectory;
            folderBrowserDialog1.Description = "Select directory to import from";
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                Settings.Default.LastDirectory = folderBrowserDialog1.SelectedPath;
            else
                return;
            string fullPath = folderBrowserDialog1.SelectedPath + "\\" + folder + "\\" + fileName;
            Import(elements, fullPath, type, showProgressBar);
        }
        /// <summary>
        /// Imports files into a set of elements from a set of files in a specified full path of a local folder.
        /// </summary>
        /// <param name="element">The elements to import to.</param>
        /// <param name="fullPath">The local path of the folder to import from, plus the filename without the index or extension.</param>
        /// <param name="type">The type of element. Preferably in all caps and singular form.</param>
        /// <param name="showProgressBar">Sets whether or not to show the progress bar when importing.</param>
        public static void Import(object[] elements, string fullPath, string type, bool showProgressBar)
        {
            // set the backgroundworker properties
            Do.Import_Worker = new BackgroundWorker();
            Do.Import_Worker.WorkerReportsProgress = true;
            Do.Import_Worker.WorkerSupportsCancellation = true;
            Do.Import_Worker.DoWork += (s, e) => Import_Worker_DoWork(s, e, elements, fullPath);
            Do.Import_Worker.ProgressChanged += (s, e) => Import_Worker_ProgressChanged(s, e, type);
            Do.Import_Worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(Import_Worker_RunWorkerCompleted);
            if (showProgressBar)
            {
                ProgressBar = new ProgressBar("EXPORTING " + type + "S...", elements.Length, Export_Worker);
                ProgressBar.Show();
            }
            Import_Worker.RunWorkerAsync();
            while (Import_Worker.IsBusy)
                Application.DoEvents();
        }
        private static void Import_Worker_DoWork(object sender, DoWorkEventArgs e, object[] elements, string fullPath)
        {
            // Create the files
            for (int i = 0; i < elements.Length; i++)
            {
                if (Import_Worker.CancellationPending)
                    return;
                Import_Worker.ReportProgress(i);
                // if a byte[] array, then import as .bin
                if (elements[i].GetType() == typeof(byte[]))
                {
                    if (!File.Exists(fullPath + "." + i.ToString("d" + elements.Length.ToString().Length) + ".bin"))
                        continue;
                    FileStream fs =
                        File.OpenRead(fullPath + "." + i.ToString("d" + elements.Length.ToString().Length) + ".bin");
                    BinaryReader br = new BinaryReader(fs);
                    elements[i] = new byte[fs.Length];
                    br.ReadBytes((int)fs.Length).CopyTo((byte[])elements[i], 0);
                    br.Close();
                    fs.Close();
                }
                // otherwise, import as .dat
                else
                {
                    if (!File.Exists(fullPath + "." + i.ToString("d" + elements.Length.ToString().Length) + ".dat"))
                        continue;
                    Stream s =
                        File.OpenRead(fullPath + "." + i.ToString("d" + elements.Length.ToString().Length) + ".dat");
                    BinaryFormatter bf = new BinaryFormatter();
                    elements[i] = bf.Deserialize(s);
                    s.Close();
                }
            }
        }
        private static void Import_Worker_ProgressChanged(object sender, ProgressChangedEventArgs e, string type)
        {
            if (ProgressBar != null && ProgressBar.Visible)
                ProgressBar.PerformStep("IMPORTING " + type + " #" + e.ProgressPercentage);
        }
        private static void Import_Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (ProgressBar != null && ProgressBar.Visible)
                ProgressBar.Close();
        }
        #endregion
        #region .NET Controls
        public static void AddControl(Control parent, Form child)
        {
            child.TopLevel = false;
            parent.Controls.Add(child);
            //child.WindowState = FormWindowState.Maximized;
            child.Show();
            child.BringToFront();
        }
        public static void RemoveControl(Form child)
        {
            child.WindowState = FormWindowState.Normal;
            child.Parent = null;
            child.TopLevel = true;
            child.Location = new Point(5, 5);
        }
        /// <summary>
        /// Add a shortcut key to a toolstrip.
        /// </summary>
        /// <param name="toolStrip">The toolstrip to add to.</param>
        /// <param name="keys">The shortcut key.</param>
        /// <param name="eventHandler">The event handler to invoke when the shortcut is activated.</param>
        public static void AddShortcut(ToolStrip toolStrip, Keys keys, EventHandler eventHandler)
        {
            ToolStripMenuItem shortcut = new ToolStripMenuItem();
            shortcut.ShortcutKeys = keys;
            shortcut.Visible = false;
            shortcut.Click += eventHandler;
            toolStrip.Items.Add(shortcut);
        }
        public static void AddShortcut(ToolStrip toolStrip, Keys keys, ToolStripButton checkable)
        {
            ToolStripMenuItem shortcut = new ToolStripMenuItem();
            shortcut.ShortcutKeys = keys;
            shortcut.Visible = false;
            shortcut.Click += (s, e) => CheckButtonEvent(s, e, checkable);
            toolStrip.Items.Add(shortcut);
        }
        private static void CheckButtonEvent(object sender, EventArgs e, ToolStripButton button)
        {
            button.Checked = !button.Checked;
        }
        /// <summary>
        /// Resizes a label control to fit its text, since the .NET auto-sizing for label sucks.
        /// </summary>
        /// <param name="label">The label control to resize.</param>
        public static void AutoSizeLabel(Label label)
        {
            Size size = TextRenderer.MeasureText(label.Text, label.Font);
            label.Width = size.Width + 4;
            label.Height = size.Height + 4;
        }
        public static void DrawIcon(
            object sender, DrawItemEventArgs e, Preview preview, int iconIndex,
            FontCharacter[] fontCharacters, int[] palette, bool shadow)
        {
            // set the pixels
            int[] temp = preview.GetPreview(fontCharacters, palette,
                new char[] { (char)(e.Index + iconIndex) }, shadow);
            int[] pixels = new int[256 * 14];
            for (int y = 0, c = 0; y < 14; y++, c++)
            {
                for (int x = 2, a = 0; x < 256; x++, a++)
                    pixels[y * 256 + x] = temp[c * 256 + a];
            }
            e.DrawBackground();
            e.Graphics.DrawImage(new Bitmap(Do.PixelsToImage(pixels, 256, 14)), new Point(e.Bounds.X, e.Bounds.Y));
            e.DrawFocusRectangle();
        }
        /// <summary>
        /// Paints the items in a DDList collection to a list control. 
        /// This should be invoked within a list control's DrawItem event handler.
        /// </summary>
        /// <param name="sender">Passed from the event handler.</param>
        /// <param name="e">Passed from the event handler.</param>
        /// <param name="preview">The preview class that draws the items from a font.</param>
        /// <param name="names">The DDList collection containing the strings to draw.</param>
        /// <param name="fontCharacters">The font to draw with.</param>
        /// <param name="palette">The font's palette to draw with.</param>
        /// <param name="xOffset">X coord's offset of pixels drawn on item.</param>
        /// <param name="yOffset">Y coord's offset of pixels drawn on item.</param>
        /// <param name="startIndex">The index within the DDlist collection to start at.</param>
        /// <param name="endIndex">The index within the DDlist collection to stop at.</param>
        /// <param name="lastEmpty">Sets whether or not the final index should be displayed as {NOTHING}.</param>
        /// <param name="shadow">If set, a shadow will be drawn around the font characters instead of a border.
        /// This reflects the appearance of font characters in a battle menu.</param>
        public static void DrawName(
            object sender, DrawItemEventArgs e, Preview preview, DDlistName names,
            FontCharacter[] fontCharacters, int[] palette, int xOffset, int yOffset,
            int startIndex, int endIndex, bool lastEmpty, bool shadow)
        {
            if (e.Index < 0 || e.Index >= names.Names.Length)
                return;
            if (lastEmpty && names.GetNumFromIndex(e.Index) == names.Names.Length - 1)
            {
                e.DrawBackground();
                e.Graphics.DrawString("{NOTHING}", e.Font, new SolidBrush(SystemColors.Control), e.Bounds);
                e.DrawFocusRectangle();
                return;
            }
            // set the pixels
            int[] temp = preview.GetPreview(fontCharacters, palette, names.GetName(e.Index).ToCharArray(), shadow);
            int[] pixels = new int[256 * 32];
            for (int y = 0, c = yOffset; y < 14; y++, c++)
            {
                for (int x = 2, a = xOffset; x < 256; x++, a++)
                    pixels[y * 256 + x] = temp[c * 256 + a];
            }
            e.DrawBackground();
            e.Graphics.DrawImage(new Bitmap(Do.PixelsToImage(pixels, 256, 14)), new Point(e.Bounds.X, e.Bounds.Y));
            e.DrawFocusRectangle();
        }
        public static void DrawName(
            object sender, DrawItemEventArgs e, Preview preview, string[] names,
            FontCharacter[] fontCharacters, int[] palette, int xOffset, int yOffset,
            int startIndex, int endIndex, bool lastEmpty, bool shadow)
        {
            if (e.Index < 0 || e.Index >= names.Length)
                return;
            if (lastEmpty && e.Index == names.Length - 1)
            {
                e.DrawBackground();
                e.Graphics.DrawString("{NOTHING}", e.Font, new SolidBrush(SystemColors.Control), e.Bounds);
                e.DrawFocusRectangle();
                return;
            }
            // set the pixels
            int[] temp = preview.GetPreview(fontCharacters, palette, names[e.Index].ToCharArray(), shadow);
            int[] pixels = new int[256 * 32];
            for (int y = 0, c = yOffset; y < 14; y++, c++)
            {
                for (int x = 2, a = xOffset; x < 256; x++, a++)
                    pixels[y * 256 + x] = temp[c * 256 + a];
            }
            e.DrawBackground();
            e.Graphics.DrawImage(new Bitmap(Do.PixelsToImage(pixels, 256, 14)), new Point(e.Bounds.X, e.Bounds.Y));
            e.DrawFocusRectangle();
        }
        public static void DrawName(
            object sender, DrawItemEventArgs e, Preview preview, DDlistName names,
            FontCharacter[] fontCharacters, int[] palette, bool shadow)
        {
            DrawName(sender, e, preview, names, fontCharacters, palette, 0, 0, 0, names.Names.Length, false, shadow);
        }
        public static void DrawName(
            object sender, DrawItemEventArgs e, Preview preview, DDlistName names,
            FontCharacter[] fontCharacters, int[] palette)
        {
            DrawName(sender, e, preview, names, fontCharacters, palette, 0, 0, 0, names.Names.Length, false, false);
        }
        public static void SelectAllNodes(TreeNodeCollection nodes, bool selected)
        {
            foreach (TreeNode tn in nodes)
            {
                tn.Checked = selected;
                SelectAllNodes(tn.Nodes, selected);
            }
        }
        /// <summary>
        /// Enable or disable all or some controls within a parent control, starting at the parent control.
        /// Returns the controls that already have the enable status set.
        /// </summary>
        /// <param name="main">The main parent controls.</param>
        /// <param name="enable">Enable or disable the controls.</param>
        /// <param name="childOnly">If set to true, only controls that contain no child controls will be modified.</param>
        /// <param name="skip">The controls to ignore when changing enabled status.</param>
        public static ArrayList EnableControls(object main, bool enable, bool childOnly, bool firstLoop, params object[] skip)
        {
            if (firstLoop)
                set = new ArrayList();
            if (main.GetType() == typeof(ToolStrip))
                foreach (ToolStripItem item in ((ToolStrip)main).Items)
                {
                    if (!Contains(item, skip))
                        if (item.Enabled == enable)
                            set.Add(item);
                        else
                            item.Enabled = enable;
                }
            else
                foreach (Control parent in ((Control)main).Controls)
                {
                    if (parent.Controls.Count == 0 || !childOnly && !Contains(parent, skip))
                        if (parent.Enabled == enable)
                            set.Add(parent);
                        else
                            parent.Enabled = enable;
                    EnableControls(parent, enable, childOnly, false, skip);
                }
            return set;
        }
        private static ArrayList set = new ArrayList();
        public static bool GetNodeIndex(TreeNode node, TreeNodeCollection nodes, ref int index)
        {
            if (node == null)
                return false;
            foreach (TreeNode tn in nodes)
            {
                if (tn == node)
                    return true;
                index++;
                if (GetNodeIndex(node, tn.Nodes, ref index))
                    return true;
            }
            return false;
        }
        // Get / set the scrollbar position of the treeview
        [DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        public static extern int GetScrollPos(int hWnd, int nBar);
        [DllImport("user32.dll")]
        public static extern int SetScrollPos(IntPtr hWnd, int nBar, int nPos, bool bRedraw);
        private const int SB_HORZ = 0x0;
        private const int SB_VERT = 0x1;
        public static Point GetTreeViewScrollPos(TreeView treeView)
        {
            return new Point(
                GetScrollPos((int)treeView.Handle, SB_HORZ),
                GetScrollPos((int)treeView.Handle, SB_VERT));
        }
        public static void SetTreeViewScrollPos(TreeView treeView, Point scrollPosition)
        {
            SetScrollPos((IntPtr)treeView.Handle, SB_HORZ, scrollPosition.X, true);
            SetScrollPos((IntPtr)treeView.Handle, SB_VERT, scrollPosition.Y, true);
        }
        #endregion
        #region LAZYSHELL Functions
        public static bool Compare(Tile8x8 subtileA, Tile8x8 subtileB)
        {
            if (subtileA.Pixels == subtileB.Pixels &&
                subtileA.PaletteIndex == subtileB.PaletteIndex &&
                subtileA.TileIndex == subtileB.TileIndex &&
                subtileA.PriorityOne == subtileB.PriorityOne &&
                Bits.Compare(subtileA.Colors, subtileB.Colors) &&
                subtileA.Mirror == subtileB.Mirror &&
                subtileA.Invert == subtileB.Invert)
                return true;
            return false;
        }
        public static bool Compare(Tile16x16 tileA, Tile16x16 tileB)
        {
            for (int i = 0; i < 4; i++)
                if (!Compare(tileA.Subtiles[i], tileB.Subtiles[i]))
                    return false;
            return true;
        }
        public static void Play(SoundPlayer soundPlayer, byte[] wav, int rate)
        {
            if (wav == null) return;
            Stream s = new MemoryStream(wav);
            soundPlayer.Stream = s;
            soundPlayer.Play();
        }
        #endregion
        #region Math Functions
        public static double PercentIncrease(double percent, double value)
        {
            return value + (value * (percent / 100.0));
        }
        public static double PercentDecrease(double percent, double value)
        {
            return value - (value * (percent / 100.0));
        }
        #endregion
    }
}

