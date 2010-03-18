using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace SMRPGED
{
    public class PaletteSet
    {
        private byte[] data; public byte[] Data { get { return this.data; } set { this.data = value; } }

        private int paletteSetOffset; public int PaletteSetOffset { get { return paletteSetOffset; } set { paletteSetOffset = value; } }
        private int paletteSetNum; public int PaletteSetNum { get { return paletteSetNum; } set { paletteSetNum = value; } }

        private int paletteSetOffsetBF; public int PaletteSetOffsetBF { get { return paletteSetOffsetBF; } set { paletteSetOffsetBF = value; } }
        private int paletteSetNumBF; public int PaletteSetNumBF { get { return paletteSetNumBF; } set { paletteSetNumBF = value; } }

        // every palette set has 112 (ie. 7 * 16) colors, a red green and blue for each
        private int[] paletteColorRed = new int[7 * 16]; public int[] PaletteColorRed { get { return paletteColorRed; } set { paletteColorRed = value; } }
        private int[] paletteColorGreen = new int[7 * 16]; public int[] PaletteColorGreen { get { return paletteColorGreen; } set { paletteColorGreen = value; } }
        private int[] paletteColorBlue = new int[7 * 16]; public int[] PaletteColorBlue { get { return paletteColorBlue; } set { paletteColorBlue = value; } }

        private int[] paletteColorRedBF = new int[7 * 16]; public int[] PaletteColorRedBF { get { return paletteColorRedBF; } set { paletteColorRedBF = value; } }
        private int[] paletteColorGreenBF = new int[7 * 16]; public int[] PaletteColorGreenBF { get { return paletteColorGreenBF; } set { paletteColorGreenBF = value; } }
        private int[] paletteColorBlueBF = new int[7 * 16]; public int[] PaletteColorBlueBF { get { return paletteColorBlueBF; } set { paletteColorBlueBF = value; } }

        public PaletteSet(byte[] data, int paletteSetNum, int paletteSetNumBF)
        {
            this.data = data;
            this.paletteSetNum = paletteSetNum;
            this.paletteSetNumBF = paletteSetNumBF;
            InitializePaletteSet(data);
        }

        private void InitializePaletteSet(byte[] data)
        {
            paletteSetOffset = (paletteSetNum * 0xD4) + 0x24A000;

            double multiplier = 8; // 8;
            ushort color = 0;

            for (int i = 0; i < 7; i++) // 7 palettes in set
            {
                for (int j = 0; j < 16; j++) // 16 colors in palette
                {
                    color = BitManager.GetShort(data, paletteSetOffset + (i * 30) + (j * 2));

                    paletteColorRed[(i * 16) + j] = (byte)((color % 0x20) * multiplier);
                    paletteColorGreen[(i * 16) + j] = (byte)(((color >> 5) % 0x20) * multiplier);
                    paletteColorBlue[(i * 16) + j] = (byte)(((color >> 10) % 0x20) * multiplier);
                }
            }

            paletteSetOffsetBF = (paletteSetNumBF * 0xB6) + 0x34D000 - 30;

            color = 0;

            for (int i = 0; i < 7; i++) // 7 palettes in set
            {
                for (int j = 0; j < 16; j++) // 16 colors in palette
                {
                    color = BitManager.GetShort(data, paletteSetOffsetBF + (i * 30) + (j * 2));

                    paletteColorRedBF[(i * 16) + j] = (byte)((color % 0x20) * multiplier);
                    paletteColorGreenBF[(i * 16) + j] = (byte)(((color >> 5) % 0x20) * multiplier);
                    paletteColorBlueBF[(i * 16) + j] = (byte)(((color >> 10) % 0x20) * multiplier);
                }
            }
        }
        public void Assemble()
        {
            paletteSetOffset = (paletteSetNum * 0xD4) + 0x24A000;

            ushort color = 0;
            int r, g, b;

            for (int i = 0; i < 7; i++) // 7 palettes in set
            {
                for (int j = 0; j < 16; j++) // 16 colors in palette
                {
                    r = (int)(paletteColorRed[(i * 16) + j] / 8);
                    g = (int)(paletteColorGreen[(i * 16) + j] / 8);
                    b = (int)(paletteColorBlue[(i * 16) + j] / 8);
                    color = (ushort)((b << 10) | (g << 5) | r);
                    BitManager.SetShort(data, paletteSetOffset + (i * 30) + (j * 2), color);
                }
            }

            if (paletteSetNumBF > 56) return;

            paletteSetOffsetBF = (paletteSetNumBF * 0xB6) + 0x34D000 - 30;

            for (int i = 1; i < 7; i++) // 7 palettes in set
            {
                for (int j = 0; j < 16; j++) // 16 colors in palette
                {
                    r = (int)(paletteColorRedBF[(i * 16) + j] / 8);
                    g = (int)(paletteColorGreenBF[(i * 16) + j] / 8);
                    b = (int)(paletteColorBlueBF[(i * 16) + j] / 8);
                    color = (ushort)((b << 10) | (g << 5) | r);
                    BitManager.SetShort(data, paletteSetOffsetBF + (i * 30) + (j * 2), color);
                }
            }
        }
        public int[] GetPaletteSetPixels()
        {
            int[] paletteSetPixels = new int[240 * 105];

            for (int i = 0; i < 7; i++) // 7 palette blocks high
            {
                for (int j = 0; j < 16; j++) // 16 palette blocks wide
                {
                    for (int y = 0; y < 15; y++)
                    {
                        for (int x = 0; x < 15; x++)
                            paletteSetPixels[x + (j * 15) + ((y + (i * 15)) * 240)] = Color.FromArgb(255, paletteColorRed[j + (i * 16)], paletteColorGreen[j + (i * 16)], paletteColorBlue[j + (i * 16)]).ToArgb();
                    }
                }
            }
            for (int y = 0; y < 105; y += 15)  // draw the horizontal gridlines
            {
                for (int x = 0; x < 240; x++)
                    paletteSetPixels[y * 240 + x] = Color.Black.ToArgb();
                if (y == 0) y--;
            }
            for (int x = 0; x < 240; x += 15) // draw the vertical gridlines
            {
                for (int y = 0; y < 105; y++)
                    paletteSetPixels[y * 240 + x] = Color.Black.ToArgb();
                if (x == 0) x--;
            }

            return paletteSetPixels;
        }
        public int[] GetBFPaletteSetPixels()
        {
            int[] paletteSetPixels = new int[256 * 112];

            for (int i = 0; i < 7; i++) // 7 palette blocks high
            {
                for (int j = 0; j < 16; j++) // 16 palette blocks wide
                {
                    for (int y = 0; y < 16; y++) // 16 pixels high each block
                    {
                        for (int x = 0; x < 16; x++) // 16 pixels wide each block
                            paletteSetPixels[x + (j * 16) + ((y + (i * 16)) * 256)] = Color.FromArgb(255, paletteColorRedBF[j + (i * 16)], paletteColorGreenBF[j + (i * 16)], paletteColorBlueBF[j + (i * 16)]).ToArgb();
                    }
                }
            }
            for (int y = 0; y < 112; y += 16)  // draw the horizontal gridlines
            {
                for (int x = 0; x < 256; x++)
                    paletteSetPixels[y * 256 + x] = Color.Black.ToArgb();
                if (y == 0) y--;
            }
            for (int x = 0; x < 256; x += 16) // draw the vertical gridlines
            {
                for (int y = 0; y < 112; y++)
                    paletteSetPixels[y * 256 + x] = Color.Black.ToArgb();
                if (x == 0) x--;
            }

            return paletteSetPixels;
        }
        public int GetBGColor()
        {
            return Color.FromArgb(255, paletteColorRed[0], paletteColorGreen[0], paletteColorBlue[0]).ToArgb();
        }
        public int GetBGColorBF()
        {
            return Color.FromArgb(255, paletteColorRedBF[0], paletteColorGreenBF[0], paletteColorBlueBF[0]).ToArgb();
        }
        public int[] Get2bppPalette(int paletteIndex)
        {
            int[] temp = new int[4];
            if (paletteIndex < 0 || paletteIndex > 7) paletteIndex = 0;
            paletteIndex *= 4;

            // read the 8 colors
            for (int i = 0; i < 4; i++)
                temp[i] = Color.FromArgb(255, paletteColorRed[i + paletteIndex], paletteColorGreen[i + paletteIndex], paletteColorBlue[i + paletteIndex]).ToArgb();

            return temp;
        }
        public int[] Get4bppPalette(int paletteIndex)
        {
            int[] temp = new int[16];
            if (paletteIndex < 0 || paletteIndex > 7) paletteIndex = 0;
            paletteIndex *= 16;

            // read the 16 colors
            for (int i = 0; i < 16; i++)
                temp[i] = Color.FromArgb(255, paletteColorRed[i + paletteIndex], paletteColorGreen[i + paletteIndex], paletteColorBlue[i + paletteIndex]).ToArgb();

            return temp;
        }
        public int[] GetBattlefieldPalette(int paletteIndex)
        {
            int[] temp = new int[16];
            if (paletteIndex < 0 || paletteIndex > 7) paletteIndex = 0;
            paletteIndex *= 16;

            // read the 16 colors
            for (int i = 0; i < 16; i++)
                temp[i] = Color.FromArgb(255, paletteColorRedBF[i + paletteIndex], paletteColorGreenBF[i + paletteIndex], paletteColorBlueBF[i + paletteIndex]).ToArgb();

            return temp;
        }
    }
}
