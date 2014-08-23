using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using LAZYSHELL.Fonts;

namespace LAZYSHELL
{
    class MenuDescriptionPreview
    {
        // class variables
        private Glyph[] font;
        private int[] palette;
        private Size size;

        // Constructor
        public int[] GetPreview(Glyph[] font, int[] palette, char[] dlg, Size size, Point location, int lines)
        {
            this.font = font;
            this.palette = palette;
            this.size = size;
            int charPtr = 0, line = 0;
            Point point = new Point(location.X, location.Y);
            int[] pixels = new int[size.Width * size.Height];
            while (charPtr != dlg.Length) // while there is more characters to draw
            {
                if (dlg[charPtr] >= 0x20 && dlg[charPtr] <= 0x9F)
                {
                    int width = font[dlg[charPtr] - 32].Width;
                    int maxWidth = font[dlg[charPtr] - 32].MaxWidth;
                    int[] glyphPixels = font[dlg[charPtr] - 32].GetPixels(palette);
                    int m = 0;  // the counter for adding to the x coord
                    for (int x = 0, a = point.X; x < width; x++, a++, m++) // # of pixels per row
                    {
                        for (int y = 0, b = point.Y; y < 8; y++, b++) // 12 rows per character
                        {
                            // if past max width, start new line
                            if (point.X + x > size.Width - location.X)
                            {
                                point.Y += 8; b += 8;
                                point.X = location.X + 1; a = location.X + 1;
                                m = 0; line++;
                            }
                            // if past max lines, end drawing
                            if (line >= lines)
                            {
                                Do.DrawBorder(pixels, size.Width, palette[3]);
                                return pixels;
                            }
                            pixels[b * size.Width + a] = glyphPixels[y * maxWidth + x];
                        }
                    }
                    point.X += m;
                }
                else
                {
                    switch ((byte)dlg[charPtr])
                    {
                        case 0x00: // END (End string)
                            charPtr++;
                            Do.DrawBorder(pixels, size.Width, palette[3]);
                            return pixels;
                        case 0x01: // BREAK (Line break)
                            line++;
                            point.Y += 8; point.X = location.X;
                            break;
                        default: break;
                    }
                }
                charPtr++;
            }
            Do.DrawBorder(pixels, size.Width, palette[3]);
            return pixels;
        }
    }
}
