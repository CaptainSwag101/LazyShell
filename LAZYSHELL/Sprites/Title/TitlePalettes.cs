using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace LAZYSHELL
{
    public class TitlePalettes
    {
        private byte[] paletteSet; public byte[] PaletteSet { get { return paletteSet; } }

        private int[] paletteColorRed = new int[8 * 16]; public int[] PaletteColorRed { get { return paletteColorRed; } set { paletteColorRed = value; } }
        private int[] paletteColorGreen = new int[8 * 16]; public int[] PaletteColorGreen { get { return paletteColorGreen; } set { paletteColorGreen = value; } }
        private int[] paletteColorBlue = new int[8 * 16]; public int[] PaletteColorBlue { get { return paletteColorBlue; } set { paletteColorBlue = value; } }

        public TitlePalettes(byte[] paletteSet)
        {
            this.paletteSet = paletteSet;

            InitializeTitlePalettes(paletteSet);
        }
        private void InitializeTitlePalettes(byte[] paletteSet)
        {
            double multiplier = 8; // 8;
            ushort color = 0;

            for (int i = 0; i < paletteSet.Length / 32; i++) // 8 palettes in set
            {
                for (int j = 0; j < 16; j++) // 16 colors in palette
                {
                    color = BitManager.GetShort(paletteSet, (ushort)((i * 32) + (j * 2)));

                    paletteColorRed[(i * 16) + j] = (byte)((color % 0x20) * multiplier);
                    paletteColorGreen[(i * 16) + j] = (byte)(((color >> 5) % 0x20) * multiplier);
                    paletteColorBlue[(i * 16) + j] = (byte)(((color >> 10) % 0x20) * multiplier);
                }
            }
        }
        public int[] GetTitlePalette(int paletteIndex)
        {
            int[] temp = new int[16];
            if (paletteIndex < 0 || paletteIndex > 7) paletteIndex = 0;
            paletteIndex *= 16;

            // read the 16 colors
            for (int i = 0; i < 16; i++)
                temp[i] = Color.FromArgb(255, paletteColorRed[i + paletteIndex], paletteColorGreen[i + paletteIndex], paletteColorBlue[i + paletteIndex]).ToArgb();

            return temp;
        }
        public int[] GetPalettePixels()
        {
            int[] palettePixels = new int[256 * (paletteSet.Length / 2)];

            for (int i = 0; i < paletteSet.Length / 32; i++) // 8 palette blocks high
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
            for (int y = 15; y < paletteSet.Length / 2; y += 16)  // draw the horizontal gridlines
            {
                for (int x = 0; x < 256; x++)
                    palettePixels[y * 256 + x] = Color.Black.ToArgb();
            }
            for (int x = 15; x < 256; x += 16) // draw the vertical gridlines
            {
                for (int y = 0; y < paletteSet.Length / 2; y++)
                    palettePixels[y * 256 + x] = Color.Black.ToArgb();
            }
            return palettePixels;
        }
        public void Assemble()
        {
            ushort color = 0;
            int r, g, b;

            for (int i = 0; i < 8; i++) // 8 palettes in set
            {
                for (int j = 0; j < 16; j++) // 16 colors in palette
                {
                    r = (int)(paletteColorRed[(i * 16) + j] / 8);
                    g = (int)(paletteColorGreen[(i * 16) + j] / 8);
                    b = (int)(paletteColorBlue[(i * 16) + j] / 8);
                    color = (ushort)((b << 10) | (g << 5) | r);
                    BitManager.SetShort(paletteSet, (i * 32) + (j * 2), color);
                }
            }
        }
    }
}
