using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace LAZYSHELL
{
    public static class Drawing
    {
        /// <summary>
        /// Converts a pixel array into an image.
        /// </summary>
        /// <param name="array">The pixel array.</param>
        /// <param name="width">The image width.</param>
        /// <param name="height">The image height.</param>
        /// <returns></returns>
        public static Bitmap PixelArrayToImage(int[] array, int width, int height)
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
            return image;
        }
        /// <summary>
        /// Converts an image into a pixel array.
        /// </summary>
        /// <param name="image">The image to convert.</param>
        /// <param name="maximumSize">The size of the converted image.</param>
        /// <returns></returns>
        public static int[] ImageToPixelArray(Bitmap image, Size size)
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
        public static int[] ImageToPixelArray(Bitmap image, Size size, Rectangle region)
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
        /// Converts a raw pixel array to 4bpp format.
        /// Returns the respective palette indexes for the tiles it converted.
        /// </summary>
        /// <param name="array">The raw pixel array.</param>
        /// <param name="size">The size (in 8x8 tiles) of the image.</param>
        /// <param name="palette">The palette to apply to the image.</param>
        /// <returns></returns>
        public static int[] PixelArrayTo4bpp(int[] src, byte[] dst, Size size, int[][] palettes)
        {
            Point p;
            int offset;
            byte bit;
            int[] indexes = new int[size.Width * size.Height];

            for (int y_ = 0; y_ < size.Height; y_++)
            {
                for (int x_ = 0; x_ < size.Width; x_++)
                {
                    int i = y_ * size.Width + x_;
                    Rectangle regionDest = new Rectangle(x_ * 8, y_ * 8, 8, 8);
                    Rectangle regionSrc = new Rectangle(0, 0, size.Width * 8, size.Height * 8);
                    indexes[i] = GetClosestPaletteIndex(palettes, src, regionSrc, regionDest);
                    ApplyPaletteToPixelArray(src, palettes[indexes[i]], regionSrc, regionDest);
                    for (int y = 0; y < 8; y++)
                    {
                        for (int x = 0; x < 8; x++)
                        {
                            p = new Point(i % size.Width * 8 + x, i / size.Width * 8 + y);
                            bit = (byte)(x ^ 7);
                            offset = i * 0x20;
                            offset += y * 2;
                            BitManager.SetBit(dst, offset, bit, (src[p.Y * (size.Width * 8) + p.X] & 1) == 1);
                            BitManager.SetBit(dst, offset + 1, bit, (src[p.Y * (size.Width * 8) + p.X] & 2) == 2);
                            BitManager.SetBit(dst, offset + 16, bit, (src[p.Y * (size.Width * 8) + p.X] & 4) == 4);
                            BitManager.SetBit(dst, offset + 17, bit, (src[p.Y * (size.Width * 8) + p.X] & 8) == 8);
                        }
                    }
                }
            }
            return indexes;
        }
        /// <summary>
        /// Converts a raw pixel array to 2bpp format.
        /// </summary>
        /// <param name="array">The raw pixel array.</param>
        /// <param name="w">The width of the image.</param>
        /// <param name="h">The height of the image.</param>
        /// <param name="palette">The palette to apply to the image.</param>
        /// <returns></returns>
        public static int[] PixelArrayTo2bpp(int[] src, byte[] dst, Size size, int[][] palettes)
        {
            Point p;
            int offset;
            byte bit;
            int[] indexes = new int[size.Width * size.Height];

            for (int i = 0; i < size.Width * size.Height; i++)   // draw each 8x8 tile
            {
                Rectangle regionDest = new Rectangle(i % size.Width * 8, i / size.Width, 8, 8);
                Rectangle regionSrc = new Rectangle(0, 0, size.Width, size.Height);
                indexes[i] = GetClosestPaletteIndex(palettes, src, regionSrc, regionDest);
                ApplyPaletteToPixelArray(src, palettes[indexes[i]], regionSrc, regionDest);
                for (int y = 0; y < 8; y++)
                {
                    for (int x = 0; x < 8; x++)
                    {
                        p = new Point(i % size.Width * 8 + x, i / size.Width * 8 + y);
                        bit = (byte)(x ^ 7);
                        offset = i * 0x10;
                        offset += y * 2;
                        BitManager.SetBit(dst, offset, bit, (src[p.Y * (size.Width * 8) + p.X] & 1) == 1);
                        BitManager.SetBit(dst, offset + 1, bit, (src[p.Y * (size.Width * 8) + p.X] & 2) == 2);
                    }
                }
            }
            return indexes;
        }
        /// <summary>
        /// Converts a raw pixel array to 4bpp format.
        /// </summary>
        /// <param name="array">The raw pixel array.</param>
        /// <param name="size">The size (in 8x8 tiles) of the image.</param>
        /// <param name="palette">The palette to apply to the image.</param>
        /// <returns></returns>
        public static void PixelArrayTo4bpp(int[] src, byte[] dst, Size size, int[] palette)
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
                    ApplyPaletteToPixelArray(src, palette, regionSrc, regionDest);
                    for (int y = 0; y < 8; y++)
                    {
                        for (int x = 0; x < 8; x++)
                        {
                            p = new Point(i % size.Width * 8 + x, i / size.Width * 8 + y);
                            bit = (byte)(x ^ 7);
                            offset = i * 0x20;
                            offset += y * 2;
                            BitManager.SetBit(dst, offset, bit, (src[p.Y * (size.Width * 8) + p.X] & 1) == 1);
                            BitManager.SetBit(dst, offset + 1, bit, (src[p.Y * (size.Width * 8) + p.X] & 2) == 2);
                            BitManager.SetBit(dst, offset + 16, bit, (src[p.Y * (size.Width * 8) + p.X] & 4) == 4);
                            BitManager.SetBit(dst, offset + 17, bit, (src[p.Y * (size.Width * 8) + p.X] & 8) == 8);
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Converts a raw pixel array to 2bpp format.
        /// </summary>
        /// <param name="array">The raw pixel array.</param>
        /// <param name="w">The width of the image.</param>
        /// <param name="h">The height of the image.</param>
        /// <param name="palette">The palette to apply to the image.</param>
        /// <returns></returns>
        public static void PixelArrayTo2bpp(int[] src, byte[] dst, Size size, int[] palette)
        {
            Point p;
            int offset;
            byte bit;

            for (int i = 0; i < size.Width * size.Height; i++)   // draw each 8x8 tile
            {
                Rectangle regionDest = new Rectangle(i % size.Width * 8, i / size.Width, 8, 8);
                Rectangle regionSrc = new Rectangle(0, 0, size.Width, size.Height);
                ApplyPaletteToPixelArray(src, palette, regionSrc, regionDest);
                for (int y = 0; y < 8; y++)
                {
                    for (int x = 0; x < 8; x++)
                    {
                        p = new Point(i % size.Width * 8 + x, i / size.Width * 8 + y);
                        bit = (byte)(x ^ 7);
                        offset = i * 0x10;
                        offset += y * 2;
                        BitManager.SetBit(dst, offset, bit, (src[p.Y * (size.Width * 8) + p.X] & 1) == 1);
                        BitManager.SetBit(dst, offset + 1, bit, (src[p.Y * (size.Width * 8) + p.X] & 2) == 2);
                    }
                }
            }
        }
        /// <summary>
        /// Applys a palette to a pixel array.
        /// </summary>
        /// <param name="array">The pixel array.</param>
        /// <param name="palette">The palette to apply.</param>
        /// <returns></returns>
        public static void ApplyPaletteToPixelArray(int[] array, int[] palette)
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
        /// <summary>
        /// Applys a palette to a region in a pixel array.
        /// </summary>
        /// <param name="array">The pixel array.</param>
        /// <param name="palette">The palette to apply.</param>
        /// <param name="src">The full region of the source.</param>
        /// <param name="dst">The region to modify.</param>
        public static void ApplyPaletteToPixelArray(int[] array, int[] palette, Rectangle src, Rectangle dst)
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
        /// Copy an image into the tileset of a tileset class such as TitleTileset, etc.
        /// </summary>
        /// <param name="graphics">The raw graphics to copy from.</param>
        /// <param name="palette">The raw tileset to copy to.</param>
        /// <param name="palettes">The set of palettes to apply.</param>
        /// <param name="paletteIndexes">The palette index of each 8x8 tile in the graphics.</param>
        /// <param name="priority1">Sets whether or not the tiles in the tileset will be priority 1.</param>
        /// <param name="tileset">The tileset class being assessed.</param>
        /// <param name="tileSize">The tile size, either 0x10 or 0x20 (2bpp and 4bpp, respectively).</param>
        /// <param name="tileLength">Length, in bytes, of an 8x8 tile in a tileset. Either one or two.</param>
        /// <param name="tilesetWidth">Size, in pixels, of the tileset being drawn to.</param>
        /// <param name="tileIndexStart">The index to start writing tilenums to the tileset. Normally 0, 1, or 2</param>
        public static void CopyToTileset(byte[] graphics, byte[] tileset, int[][] palettes, int[] paletteIndexes, bool priority1, byte tileSize, byte tileLength, Size tilesetSize, int tileIndexStart)
        {
            ArrayList tiles_a = new ArrayList();    // the tileset, essentially, in array form
            ArrayList tiles_b = new ArrayList();    // used for redrawing a culled 4bpp graphic block
            ArrayList tiles_c = new ArrayList();
            for (int i = 0; i < graphics.Length / tileSize; i++)
            {
                Tile8x8 temp = new Tile8x8(i, graphics, i * tileSize, palettes[paletteIndexes[i]], false, false, false, false);
                tiles_a.Add(temp);
                tiles_b.Add(temp);
                tiles_c.Add(temp);
            }
            // look through entire set of tiles for duplicates
            for (int a = 0; a < tiles_a.Count; a++)
            {
                Tile8x8 tile_a = (Tile8x8)tiles_a[a];
                if (tile_a.TileNum != a) continue;  // skip if already set as duplicate
                for (int b = a; b < tiles_a.Count; b++)
                {
                    Tile8x8 tile_b = (Tile8x8)tiles_a[b];
                    if (a == b) continue;   // cannot be duplicate of self
                    if (BitManager.Compare(tile_a.Pixels, tile_b.Pixels)) // if a duplicate...
                    {
                        // first set the tile to the one that it's a duplicate of
                        tile_b.TileNum = a;
                        // then remove
                        tiles_b.Remove(tile_b);
                    }
                    byte status = GetFlippedStatus(tile_a.Pixels, tile_b.Pixels);
                    if ((status & 0x40) == 0x40)
                    {
                        tile_b.Mirrored = true;
                        tile_b.TileNum = a;
                        tiles_b.Remove(tile_b);
                    }
                    if ((status & 0x80) == 0x80)
                    {
                        tile_b.Inverted = true;
                        tile_b.TileNum = a;
                        tiles_b.Remove(tile_b);
                    }
                }
            }
            // redraw into newly culled graphic block, and reorganize tilenums
            int c = 0; byte[] culledGraphics = new byte[graphics.Length];
            foreach (Tile8x8 tile in tiles_b)
            {
                int orig = tile.TileNum;
                Buffer.BlockCopy(graphics, tile.TileNum * 0x20, culledGraphics, c * 0x20, 0x20);
                tile.TileNum = c; 
                // check for other duplicates or mirrors/inversions of this current tile
                foreach (Tile8x8 check in tiles_a)
                {
                    if (check.TileNum == orig)
                        check.TileNum = c;
                }
                c++;
            }
            // now rewrite tileset data using tiles_a
            c = 0; byte[] culledTileset = new byte[tileset.Length];

            foreach (Tile8x8 tile in tiles_a)
            {
                culledTileset[c * tileLength] = (byte)(tile.TileNum + tileIndexStart);
                if (tileLength == 2)
                {
                    culledTileset[c * tileLength + 1] = (byte)(paletteIndexes[c] << 2);    // set the palette index
                    culledTileset[c * tileLength + 1] |= (byte)(tile.TileNum >> 8); // set the graphic index
                    BitManager.SetBit(culledTileset, c * tileLength + 1, 5, priority1);
                    BitManager.SetBit(culledTileset, c * tileLength + 1, 6, tile.Mirrored);
                    BitManager.SetBit(culledTileset, c * tileLength + 1, 7, tile.Inverted);
                }
                c++;
            }
            Buffer.BlockCopy(culledTileset, 0, tileset, 0, tileset.Length);
            Buffer.BlockCopy(culledGraphics, 0, graphics, 0, graphics.Length);
        }
        /// <summary>
        /// Copy an image into the tileset of a tileset class such as TitleTileset, etc.
        /// </summary>
        /// <param name="graphics">The raw graphics to copy from.</param>
        /// <param name="palette">The raw tileset to copy to.</param>
        /// <param name="palette">The single palette to apply.</param>
        /// <param name="paletteIndex">The universal palette index of all 8x8 tiles in the graphics.</param>
        /// <param name="priority1">Sets whether or not the tiles in the tileset will be priority 1.</param>
        /// <param name="tileset">The tileset class being assessed.</param>
        /// <param name="tileSize">The tile size, either 0x10 or 0x20 (2bpp and 4bpp, respectively).</param>
        /// <param name="tileLength">Length, in bytes, of an 8x8 tile in a tileset. Either one or two.</param>
        /// <param name="tilesetWidth">Size, in pixels, of the tileset being drawn to.</param>
        /// <param name="tileIndexStart">The index to start writing tilenums to the tileset. Normally 0, 1, or 2</param>
        public static void CopyToTileset(byte[] graphics, byte[] tileset, int[] palette, int paletteIndex, bool priority1, byte tileSize, byte tileLength, Size tilesetSize, int tileIndexStart)
        {
            ArrayList tiles_a = new ArrayList();    // the tileset, essentially, in array form
            ArrayList tiles_b = new ArrayList();    // used for redrawing a culled 4bpp graphic block
            ArrayList tiles_c = new ArrayList();
            for (int i = 0; i < graphics.Length / tileSize; i++)
            {
                Tile8x8 temp = new Tile8x8(i, graphics, i * tileSize, palette, false, false, false, false);
                tiles_a.Add(temp);
                tiles_b.Add(temp);
                tiles_c.Add(temp);
            }
            // look through entire set of tiles for duplicates
            for (int a = 0; a < tiles_a.Count; a++)
            {
                Tile8x8 tile_a = (Tile8x8)tiles_a[a];
                if (tile_a.TileNum != a) continue;  // skip if already set as duplicate
                for (int b = a; b < tiles_a.Count; b++)
                {
                    Tile8x8 tile_b = (Tile8x8)tiles_a[b];
                    if (a == b) continue;   // cannot be duplicate of self
                    if (BitManager.Compare(tile_a.Pixels, tile_b.Pixels)) // if a duplicate...
                    {
                        // first set the tile to the one that it's a duplicate of
                        tile_b.TileNum = a;
                        // then remove
                        tiles_b.Remove(tile_b);
                    }
                    if (tileLength > 1) // if not 2, won't even have the extra byte so don't bother
                    {
                        byte status = GetFlippedStatus(tile_a.Pixels, tile_b.Pixels);
                        if ((status & 0x40) == 0x40)
                        {
                            tile_b.Mirrored = true;
                            tile_b.TileNum = a;
                            tiles_b.Remove(tile_b);
                        }
                        if ((status & 0x80) == 0x80)
                        {
                            tile_b.Inverted = true;
                            tile_b.TileNum = a;
                            tiles_b.Remove(tile_b);
                        }
                    }
                }
            }
            // redraw into newly culled graphic block, and reorganize tilenums
            int c = 0; byte[] culledGraphics = new byte[graphics.Length];
            foreach (Tile8x8 tile in tiles_b)
            {
                int orig = tile.TileNum;
                Buffer.BlockCopy(graphics, tile.TileNum * 0x20, culledGraphics, c * 0x20, 0x20);
                tile.TileNum = c;
                // check for other duplicates or mirrors/inversions of this current tile
                foreach (Tile8x8 check in tiles_a)
                {
                    if (check.TileNum == orig)
                        check.TileNum = c;
                }
                c++;
            }
            // now rewrite tileset data using tiles_a
            c = 0; byte[] culledTileset = new byte[tileset.Length];

            foreach (Tile8x8 tile in tiles_a)
            {
                culledTileset[c * tileLength] = (byte)(tile.TileNum + tileIndexStart);
                if (tileLength == 2)
                {
                    culledTileset[c * tileLength + 1] = (byte)(paletteIndex << 2);    // set the palette index
                    culledTileset[c * tileLength + 1] |= (byte)(tile.TileNum >> 8); // set the graphic index
                    BitManager.SetBit(culledTileset, c * tileLength + 1, 5, priority1);
                    BitManager.SetBit(culledTileset, c * tileLength + 1, 6, tile.Mirrored);
                    BitManager.SetBit(culledTileset, c * tileLength + 1, 7, tile.Inverted);
                }
                c++;
            }
            Buffer.BlockCopy(culledTileset, 0, tileset, 0, tileset.Length);
            Buffer.BlockCopy(culledGraphics, 0, graphics, 0, graphics.Length);
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
        /// Returns a pixel array from a region in another pixel array.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="src">The region of the pixel array to draw from.</param>
        /// <param name="dst">The region of the pixel array to draw to.</param>
        /// <returns></returns>
        public static int[] GetPixelArrayRegion(int[] array, Rectangle src, Rectangle dst)
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
        /// Draws a tile's pixels to a location in another pixel array.
        /// </summary>
        /// <param name="src">The tile's pixel array.</param>
        /// <param name="dst">The pixel array to draw to.</param>
        /// <param name="destinationWidth">The width of the pixel array to draw to.</param>
        /// <param name="x">The X coord to start drawing to.</param>
        /// <param name="y">The Y coord to start drawing to.</param>
        public static void DrawTileToPixelArray(int[] src, int[] dst, int dstWidth, int x, int y)
        {
            int counter = 0;
            for (int i = 0; i < 256; i++)
            {
                dst[y * dstWidth + x + counter] = src[i];
                counter++;
                if (counter % 16 == 0)
                {
                    y++;
                    counter = 0;
                }
            }
        }
        /// <summary>
        /// Copy a block of 4bpp graphics into a region in another block of 4bpp graphics.
        /// </summary>
        /// <param name="src">The source graphics to copy from.</param>
        /// <param name="dst">The destination graphics to copy to.</param>
        /// <param name="region">The region (in 8x8 tile units) in the destination graphics to draw to.</param>
        /// <param name="dstWidth">The width (in 8x8 tile units) of the destination graphics.</param>
        /// <param name="offset">The offset to start drawing at.</param>
        public static void CopyOver4bppGraphics(byte[] src, byte[] dst, Rectangle region, int dstWidth, int offset)
        {
            Point p;
            for (int b = 0; b < region.Height; b++)
            {
                for (int a = 0; a < region.Width; a++)
                {
                    p = new Point(region.X + a, region.Y + b);
                    for (int i = 0; i < 0x20; i++)
                    {
                        if ((p.Y * dstWidth * 0x20 + (p.X * 0x20) + i + offset) >= dst.Length) return;
                        dst[p.Y * dstWidth * 0x20 + (p.X * 0x20) + i + offset] = src[b * region.Width * 0x20 + (a * 0x20) + i];
                    }
                }
            }
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
            if (BitManager.Compare(tile_b, tile_a_mirrored))
                status |= 0x40;
            if (BitManager.Compare(tile_b, tile_a_inverted))
                status |= 0x80;
            if (BitManager.Compare(tile_b, tile_a_both))
                status |= 0xC0;

            return status;
        }

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
    }
}

