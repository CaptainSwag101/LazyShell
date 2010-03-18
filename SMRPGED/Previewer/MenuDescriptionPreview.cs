using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace SMRPGED.Previewer
{
    class MenuDescriptionPreview
    {
        private FontCharacter[] fontCharacters;
        private int[] palette;
        private Size size;

        public int[] GetPreview(FontCharacter[] fontCharacters, int[] palette, char[] dlg, Size s, Point t, int lines)
        {
            this.fontCharacters = fontCharacters;
            this.palette = palette;
            this.size = s;

            int charPtr = 0, line = 0;

            int[] pixels = new int[s.Width * s.Height];

            Point p = new Point(t.X, t.Y);

            int width, maxWidth;
            int[] font;

            while (charPtr != dlg.Length) // while there is more characters to draw
            {
                if (dlg[charPtr] >= 0x20 && dlg[charPtr] <= 0x9F)
                {
                    width = fontCharacters[dlg[charPtr] - 32].Width;
                    maxWidth = fontCharacters[dlg[charPtr] - 32].MaxWidth;
                    font = fontCharacters[dlg[charPtr] - 32].GetCharacterPixels(palette);

                    int m = 0;  // the counter for adding to the x coord
                    for (int x = 0, a = p.X; x < width; x++, a++, m++) // # of pixels per row
                    {
                        for (int y = 0, b = p.Y; y < 8; y++, b++) // 12 rows per character
                        {
                            // if past max width, start new line
                            if (p.X + x > s.Width - t.X)
                            {
                                p.Y += 8; b += 8;
                                p.X = t.X + 1; a = t.X + 1;
                                m = 0; line++;
                            }

                            // if past max lines, end drawing
                            if (line >= lines)
                            {
                                AddBorder(pixels);
                                return pixels;
                            }

                            pixels[b * s.Width + a] = font[y * maxWidth + x];
                        }
                    }
                    p.X += m;
                }
                else
                {
                    switch ((byte)dlg[charPtr])
                    {
                        case 0x00: // END (End string)
                            charPtr++;
                            AddBorder(pixels);
                            return pixels;
                        case 0x01: // BREAK (Line break)
                            line++;
                            p.Y += 8; p.X = t.X;
                            break;
                        default: break;
                    }
                }
                charPtr++;
            }

            AddBorder(pixels);

            return pixels;
        }
        private void AddBorder(int[] pixels)
        {
            int[] borderCalc = {   -1, 1, 
                                   -size.Width, size.Width, 
                                   -(size.Width + 1), size.Width + 1, 
                                   -(size.Width - 1), size.Width - 1 
                               };

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
    }
}
