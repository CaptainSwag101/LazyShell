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
        private bool mirrored, inverted;

        private int tileNum; public int TileNum { get { return tileNum; } }
        private bool priorityOne; public bool PriorityOne { get { return priorityOne; } } // Tells us if this tile is a priority one tile
        public bool Mirrored { get { return mirrored; } set { mirrored = value; } }
        public bool Inverted { get { return inverted; } set { inverted = value; } }

        private int paletteSetIndex; public int PaletteSetIndex { get { return this.paletteSetIndex; } set { this.paletteSetIndex = value; } }
        private int gfxSetIndex; public int GfxSetIndex { get { return this.gfxSetIndex; } set { this.gfxSetIndex = value; } }

        public Tile8x8(int tileNum,
            byte[] tileData,
            int dataOffset,
            int[] palette,
            bool mirrored,
            bool inverted,
            bool priorityOne,
            bool twobpp)
        {
            this.mirrored = mirrored;
            this.inverted = inverted;
            this.priorityOne = priorityOne;
            this.tileNum = tileNum;

            if (twobpp == false)
            {
                byte[] row;

                for (int i = 0; i < 8; i++) // Number of Rows in an 8x8 Tile
                {
                    // Get all the pixels in a row
                    row = getPixelRow(tileData[dataOffset + i * 2], tileData[dataOffset + i * 2 + 1], tileData[dataOffset + i * 2 + 0x10], tileData[dataOffset + i * 2 + 0x11]);

                    for (int p = 0; p < 8; p++) // Number of Columns in an 8x8 Tile
                    {
                        colors[i * 8 + p] = row[p];

                        if (row[p] != 0)
                            pixels[i * 8 + p] = palette[row[p]]; // Set pixel in 8x8 tile
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
                    b1 = tileData[dataOffset];
                    b2 = tileData[dataOffset + 1];

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
                    dataOffset += 2;
                }
            }

            if (mirrored) Mirror();
            if (inverted) Invert();
        }

        private void Mirror()
        {
            int temp = 0, tempC = 0;

            for (int y = 0; y < 8; y++)
            {
                for (int a = 0, b = 7; a < 4; a++, b--)
                {
                    temp = pixels[(y * 8) + a];
                    pixels[(y * 8) + a] = pixels[(y * 8) + b];
                    pixels[(y * 8) + b] = temp;

                    tempC = colors[(y * 8) + a];
                    colors[(y * 8) + a] = colors[(y * 8) + b];
                    colors[(y * 8) + b] = tempC;
                }
            }
        }
        private void Invert()
        {
            int temp = 0, tempC = 0;

            for (int x = 0; x < 8; x++)
            {
                for (int a = 0, b = 7; a < 4; a++, b--)
                {
                    temp = pixels[(a * 8) + x];
                    pixels[(a * 8) + x] = pixels[(b * 8) + x];
                    pixels[(b * 8) + x] = temp;

                    tempC = colors[(a * 8) + x];
                    colors[(a * 8) + x] = colors[(b * 8) + x];
                    colors[(b * 8) + x] = tempC;
                }
            }
        }

        private byte[] getPixelRow(byte t1, byte t2, byte t3, byte t4)
        {
            byte[] row = new byte[8];

            for (int i = 7, b = 1; i >= 0; i--, b *= 2)
                if ((t4 & b) == b) row[i] += 8;
            for (int i = 7, b = 1; i >= 0; i--, b *= 2)
                if ((t3 & b) == b) row[i] += 4;
            for (int i = 7, b = 1; i >= 0; i--, b *= 2)
                if ((t2 & b) == b) row[i] += 2;
            for (int i = 7, b = 1; i >= 0; i--, b *= 2)
                if ((t1 & b) == b) row[i]++;
            return row;
        }

        private Color GetPaletteColor(ushort raw)
        {
            double multiplier = 8; // 8;

            byte red = (byte)((raw % 0x20) * multiplier); if (red != 0) red++;
            byte green = (byte)(((raw >> 5) % 0x20) * multiplier); if (green != 0) green++;
            byte blue = (byte)(((raw >> 10) % 0x20) * multiplier); if (blue != 0) blue++;


            return Color.FromArgb(red, green, blue);
        }

    }
}
