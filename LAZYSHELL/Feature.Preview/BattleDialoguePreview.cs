using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace LAZYSHELL
{
    class BattleDialoguePreview : Preview
    {
        // class variables
        private Point p;
        private int next;
        private int[] palette;
        private FontCharacter[] fontCharacters;
        private Stack<int> pages = new Stack<int>();
        // constructor
        public BattleDialoguePreview()
        {
            pages.Push(0);
        }
        // class functions
        private void AddBorder(int[] pixels)
        {
            int[] borderCalc = { -1, 1, -256, 256, -257, 257, -255, 255 };

            for (int i = 0; i < pixels.Length; i++) // for each pixel in image
            {
                if (pixels[i] != 0 && pixels[i] != palette[3]) // draw border if it is a set pixel, and not border color
                {
                    for (int z = 0; z < borderCalc.Length; z++) // for each of the border pixels
                    {
                        if (pixels[i + borderCalc[z]] == 0) // if border pixels are empty
                            pixels[i + borderCalc[z]] = palette[3]; // fill pixel with border color
                    }
                }
            }
        }
        private byte MinimumWidth(FontCharacter fontCharacter)
        {
            byte width = fontCharacter.Width;
            if (width <= fontCharacter.GetRightMostPixel(palette))
                width = (byte)(fontCharacter.GetRightMostPixel(palette) + 1);
            return width;
        }
        // public functions
        public void Reset()
        {
            next = 0;
            pages.Clear();
            pages.Push(0);
            p = new Point(0, 0);
        }
        public void PageUp()
        {
            if (pages.Count > 1)
            {
                pages.Pop();
                p = new Point(0, 0);
            }
        }
        public void PageDown(int maxLen)
        {
            if (next != pages.Peek())
            {
                pages.Push(next);
                p = new Point(0, 0);
            }
        }
        // public accessor functions
        public int[] GetPreview(params object[] args)
        {
            if (args.Length == 5)
                return GetPreview((FontCharacter[])args[0], (int[])args[1], (char[])args[2], (bool)args[3], (bool)args[4]);
            else
                return GetPreview((FontCharacter[])args[0], (int[])args[1], (char[])args[2], (bool)args[3], true);
        }
        public int[] GetPreview(FontCharacter[] fontCharacters, int[] palette, char[] dlg, bool menu, bool allowclipping)
        {
            this.fontCharacters = fontCharacters;
            this.palette = palette;

            if (dlg.Length < pages.Peek())
                Reset();
            int charPtr = pages.Peek();

            int[] pixels = new int[256 * 32];

            p = new Point(9, 11);

            int width, maxWidth;
            int[] font;

            while (charPtr != dlg.Length) // while there is more characters to draw
            {
                if (dlg[charPtr] >= 0x20 && dlg[charPtr] <= 0x9F)
                {
                    if (p.X + fontCharacters[dlg[charPtr] - 32].Width >= 256)
                    {
                        AddBorder(pixels);
                        return pixels;
                    }

                    if (!allowclipping)
                        width = MinimumWidth(fontCharacters[dlg[charPtr] - 32]);
                    else
                        width = fontCharacters[dlg[charPtr] - 32].Width;
                    maxWidth = fontCharacters[dlg[charPtr] - 32].MaxWidth;
                    font = fontCharacters[dlg[charPtr] - 32].GetPixels(palette);

                    for (int y = 0, b = p.Y; y < 12; y++, b++) // 12 rows per character
                    {
                        for (int x = 0, a = p.X; x < width; x++, a++) // # of pixels per row
                            pixels[b * 256 + a] = font[y * maxWidth + x];
                    }
                    p.X += width + 1;
                }
                else if (!menu)
                {
                    switch ((byte)dlg[charPtr])
                    {
                        case 0x00: // END (End string)
                            charPtr++;
                            AddBorder(pixels);
                            return pixels;
                        case 0x01: // BREAK (Line break)
                            charPtr++;
                            next = charPtr;
                            AddBorder(pixels);
                            return pixels;
                        case 0x1C:
                            charPtr++;
                            break;
                        default: break;
                    }
                }
                charPtr++;
            }
            AddBorder(pixels);

            return pixels;
        }
    }
}
