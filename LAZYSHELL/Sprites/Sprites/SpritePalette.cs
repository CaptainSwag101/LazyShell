using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LAZYSHELL
{
    public class SpritePalette
    {
        private byte[] data;
        private int paletteNum;

        private int paletteOffset; public int PaletteOffset { get { return paletteOffset; } set { paletteOffset = value; } }

        private int[] paletteColorRed = new int[8 * 16]; public int[] PaletteColorRed { get { return paletteColorRed; } set { paletteColorRed = value; } }
        private int[] paletteColorGreen = new int[8 * 16]; public int[] PaletteColorGreen { get { return paletteColorGreen; } set { paletteColorGreen = value; } }
        private int[] paletteColorBlue = new int[8 * 16]; public int[] PaletteColorBlue { get { return paletteColorBlue; } set { paletteColorBlue = value; } }

        public SpritePalette(byte[] data, int paletteNum)
        {
            this.data = data;
            this.paletteNum = paletteNum;

            InitializeSpritePalette(data);
        }
        private void InitializeSpritePalette(byte[] data)
        {
            paletteOffset = 0x253000 + (paletteNum * 30);

            double multiplier = 8; // 8;
            ushort color = 0;

            for (int a = 0; a < 8; a++) // 4 palettes
            {
                for (int i = 0; i < 16; i++) // 16 colors in palette
                {
                    if (i == 0) color = 0;
                    else
                        color = BitManager.GetShort(data, (i * 2) + (a * 30) + paletteOffset - 2);

                    paletteColorRed[(a * 16) + i] = (byte)((color % 0x20) * multiplier);
                    paletteColorGreen[(a * 16) + i] = (byte)(((color >> 5) % 0x20) * multiplier);
                    paletteColorBlue[(a * 16) + i] = (byte)(((color >> 10) % 0x20) * multiplier);
                }
            }
        }
        public void Assemble()
        {
            ushort color = 0;
            int r, g, b;

            for (int i = 0; i < 16; i++) // 16 colors in palette
            {
                r = (int)(paletteColorRed[i] / 8);
                g = (int)(paletteColorGreen[i] / 8);
                b = (int)(paletteColorBlue[i] / 8);
                color = (ushort)((b << 10) | (g << 5) | r);
                if (i != 0)
                    BitManager.SetShort(data, paletteOffset + ((i - 1) * 2), color);
            }
        }
        public int[] Get4bppPalette()
        {
            int[] temp = new int[16];

            // read the 16 colors
            for (int i = 0; i < 16; i++)
                temp[i] = Color.FromArgb(255, paletteColorRed[i], paletteColorGreen[i], paletteColorBlue[i]).ToArgb();

            return temp;
        }
        public int[] GetPalettePixels()
        {
            int[] palettePixels = new int[256 * 128];

            for (int i = 0; i < 8; i++) // 4 palette blocks high
            {
                for (int j = 0; j < 16; j++) // 16 palette blocks wide
                {
                    for (int y = 0; y < 16; y++)
                    {
                        for (int x = 0; x < 16; x++)
                            palettePixels[x + (j * 16) + ((y + (i * 16)) * 256)] = Color.FromArgb(255, paletteColorRed[j + (i * 16)], paletteColorGreen[j + (i * 16)], paletteColorBlue[j + (i * 16)]).ToArgb();
                    }
                }
            }
            for (int y = 15; y < 128; y += 16)  // draw the horizontal gridlines
            {
                for (int x = 0; x < 256; x++)
                    palettePixels[y * 256 + x] = Color.Black.ToArgb();
            }
            for (int x = 15; x < 256; x += 16) // draw the vertical gridlines
            {
                for (int y = 0; y < 128; y++)
                    palettePixels[y * 256 + x] = Color.Black.ToArgb();
            }
            return palettePixels;
        }
        public void Clear()
        {
            paletteOffset = 0x253000;
            paletteColorRed = new int[8 * 16];
            paletteColorGreen = new int[8 * 16];
            paletteColorBlue = new int[8 * 16];
        }
    }
}
