using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace LAZYSHELL
{
    public class MenuTextPreview : Preview
    {
        private FontCharacter[] fontCharacters;
        private int[] palette;

        public int[] GetPreview(params object[] args)
        {
            return GetPreview((FontCharacter[])args[0], (int[])args[1], (char[])args[2], (bool)args[3]);
        }
        public int[] GetPreview(FontCharacter[] fontCharacters, int[] palette, char[] dlg, bool shadow)
        {
            this.fontCharacters = fontCharacters;
            this.palette = palette;

            int[] pixels = new int[256 * 16];

            int width, maxWidth, left;
            int[] font;

            for (int i = 0, c = 0; i < dlg.Length; i++) // while there is more characters to draw
            {
                if (dlg[i] >= 0x20 && dlg[i] <= 0x9F)
                {
                    width = fontCharacters[dlg[i] - 32].Width;
                    maxWidth = fontCharacters[dlg[i] - 32].MaxWidth;
                    font = fontCharacters[dlg[i] - 32].GetCharacterPixels(palette);
                    left = (maxWidth - width) / 2;

                    for (int y = 0, b = 1; y < 12; y++, b++) // 12 rows per character
                    {
                        for (int x = 0, a = shadow ? c + 1 : c + left + 1; x < 8; x++, a++) // # of pixels per row
                        {
                            if (pixels[b * 256 + a] == 0)
                                pixels[b * 256 + a] = font[y * maxWidth + x];
                        }
                    }
                    if (shadow)
                        c += Math.Max(fontCharacters[dlg[i] - 32].GetRightMostPixel(palette), width + 1);
                    else
                        c += 8;
                }
            }
            if (shadow)
                AddShadow(pixels);
            else
                AddBorder(pixels);

            return pixels;
        }
        private void AddBorder(int[] pixels)
        {
            int[] borderCalc = { -1, 1, -256, 256, -257, 257, -255, 255 };

            for (int i = 0; i < pixels.Length; i++) // for each pixel in image
            {
                if (pixels[i] != 0 && pixels[i] != palette[3]) // draw border if it is a set pixel, and not border color
                {
                    for (int z = 0; z < borderCalc.Length; z++) // for each of the border pixels
                    {
                        if (i + borderCalc[z] < pixels.Length && i + borderCalc[z] >= 0 &&
                            pixels[i + borderCalc[z]] == 0) // if border pixels are empty
                            pixels[i + borderCalc[z]] = palette[3]; // fill pixel with border color
                    }
                }
            }
        }
        private void AddShadow(int[] pixels)
        {
            for (int y = 0; y < 11; y++)
            {
                for (int x = 0; x < 255; x++)
                {
                    if (pixels[y * 256 + x] != 0 && pixels[y * 256 + x] != palette[3]) // draw shadow if it is a set pixel, and not border color
                    {
                        if (pixels[(y + 1) * 256 + (x + 1)] == 0) // if shadow pixels are empty
                            pixels[(y + 1) * 256 + (x + 1)] = palette[3]; // fill pixel with shadow color
                    }
                }
            }
        }
    }
}
