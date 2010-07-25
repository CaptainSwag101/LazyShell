using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace LAZYSHELL
{
    [Serializable()]
    public class Tile8x8
    {
        private int[] pixels = new int[64]; public int[] Pixels { get { return pixels; } set { pixels = value; } }
        private int[] colors = new int[64]; public int[] Colors { get { return colors; } set { colors = value; } }
        private bool twobpp;

        private bool priorityOne, mirror, invert;
        public bool PriorityOne { get { return priorityOne; } set { priorityOne = value; } }
        public bool Mirror { get { return mirror; } set { mirror = value; } }
        public bool Invert { get { return invert; } set { invert = value; } }

        private int tileIndex, paletteIndex;
        public int TileIndex { get { return tileIndex; } set { tileIndex = value; } }
        public int PaletteIndex { get { return this.paletteIndex; } set { this.paletteIndex = value; } }

        public Tile8x8(int tileIndex, byte[] tileData, int offset, int[] palette,
            bool mirror, bool invert, bool priorityOne, bool twobpp)
        {
            this.mirror = mirror;
            this.invert = invert;
            this.priorityOne = priorityOne;
            this.tileIndex = tileIndex;
            this.twobpp = twobpp;

            if (twobpp == false)
            {
                for (int r = 0; r < 8; r++) // Number of Rows in an 8x8 Tile
                {
                    // Get all the pixels in a row
                    byte[] row = new byte[8];

                    for (int i = 7, b = 1; i >= 0; i--, b *= 2)
                        if ((tileData[offset + r * 2 + 0x11] & b) == b)
                            row[i] += 8;
                    for (int i = 7, b = 1; i >= 0; i--, b *= 2)
                        if ((tileData[offset + r * 2 + 0x10] & b) == b)
                            row[i] += 4;
                    for (int i = 7, b = 1; i >= 0; i--, b *= 2)
                        if ((tileData[offset + r * 2 + 1] & b) == b)
                            row[i] += 2;
                    for (int i = 7, b = 1; i >= 0; i--, b *= 2)
                        if ((tileData[offset + r * 2] & b) == b)
                            row[i]++;

                    for (int c = 0; c < 8; c++) // Number of Columns in an 8x8 Tile
                    {
                        colors[r * 8 + c] = row[c];
                        if (row[c] != 0)
                            pixels[r * 8 + c] = palette[row[c]]; // Set pixel in 8x8 tile
                    }
                }
            }
            else
            {
                byte b1, b2, t1, t2, col = 0;
                int[] pal = new int[4];
                for (int i = 0; i < 4; i++)
                    pal[i] = palette[i];
                for (byte i = 0; i < 8; i++)
                {
                    b1 = tileData[offset];
                    b2 = tileData[offset + 1];
                    for (byte z = 7; col < 8; z--)
                    {
                        t1 = (byte)((b1 >> z) & 1);
                        t2 = (byte)((b2 >> z) & 1);
                        colors[(i * 8) + col] = (t2 * 2) + t1;
                        if ((t2 * 2) + t1 != 0)
                            pixels[(i * 8) + col] = pal[(t2 * 2) + t1];
                        col++;
                    }
                    col = 0;
                    offset += 2;
                }
            }
            if (mirror) Do.FlipHorizontal(pixels, 8, 8);
            if (invert) Do.FlipVertical(pixels, 8, 8);
        }
        private Tile8x8()
        {

        }
        public Tile8x8 Copy()
        {
            Tile8x8 copy = new Tile8x8();

            copy.Pixels = new int[this.pixels.Length]; this.Pixels.CopyTo(copy.Pixels, 0);
            copy.Colors = new int[this.colors.Length]; this.Colors.CopyTo(copy.Colors, 0);
            copy.PriorityOne = this.priorityOne;
            copy.Mirror = this.mirror;
            copy.Invert = this.invert;
            copy.TileIndex = this.tileIndex;
            copy.PaletteIndex = this.paletteIndex;

            return copy;
        }
        public void CopyTo(Tile8x8 dest)
        {
            dest.TileIndex = this.tileIndex;
            dest.PaletteIndex = this.paletteIndex;
            dest.PriorityOne = this.priorityOne;
            dest.Mirror = this.mirror;
            dest.Invert = this.invert;
            this.pixels.CopyTo(dest.Pixels, 0);
            this.colors.CopyTo(dest.Colors, 0);
        }
        public void Clear()
        {
            mirror = false;
            invert = false;
            priorityOne = false;
            pixels = new int[64];
            colors = new int[64];
            tileIndex = 0;
            paletteIndex = 0;
        }
    }
}
