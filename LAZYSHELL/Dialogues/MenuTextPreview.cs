using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using LAZYSHELL.Fonts;

namespace LAZYSHELL
{
    public class MenuTextPreview : Preview
    {
        #region Variables

        private Glyph[] font;
        private int[] palette;

        #endregion

        // Constructors
        public int[] GetPreview(params object[] args)
        {
            return GetPreview((Glyph[])args[0], (int[])args[1], (char[])args[2], (bool)args[3]);
        }
        public int[] GetPreview(Glyph[] font, int[] palette, char[] text, bool shadow)
        {
            this.font = font;
            this.palette = palette;
            int[] pixels = new int[256 * 16];

            // While there are more characters to draw
            for (int i = 0, c = 0; i < text.Length; i++)
            {
                if (text[i] >= 0x20 && text[i] <= 0x9F)
                {
                    int width = font[text[i] - 32].Width;
                    int maxWidth = font[text[i] - 32].MaxWidth;
                    int[] glyphPixels = font[text[i] - 32].GetPixels(palette);
                    int left = (maxWidth - width) / 2;

                    // 12 rows per character
                    for (int y = 0, b = 1; y < 12; y++, b++)
                    {
                        for (int x = 0, a = shadow ? c + 1 : c + left + 1; x < 8; x++, a++) // # of pixels per row
                        {
                            if (pixels[b * 256 + a] == 0)
                                pixels[b * 256 + a] = glyphPixels[y * maxWidth + x];
                        }
                    }
                    if (shadow)
                        c += Math.Max(font[text[i] - 32].GetRightMostPixel(palette), width + 1);
                    else
                        c += 8;
                }
            }
            if (shadow)
                Do.DrawShadow(pixels, 256, palette[3]);
            else
                Do.DrawBorder(pixels, 256, palette[3]);

            // Finished
            return pixels;
        }
    }
}
