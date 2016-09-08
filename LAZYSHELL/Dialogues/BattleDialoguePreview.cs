using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using LazyShell.Dialogues;
using LazyShell.Fonts;

namespace LazyShell
{
    public class BattleDialoguePreview : Preview
    {
        // class variables
        private int page = 0;
        private Point location;
        private int next;
        private int[] palette;
        private Glyph[] font;
        private Stack<int> pages = new Stack<int>();
        // Constructor
        public BattleDialoguePreview()
        {
            pages.Push(0);
        }
        private byte MinimumWidth(Glyph glyph)
        {
            byte width = glyph.Width;
            if (width <= glyph.GetRightMostPixel(palette))
                width = (byte)(glyph.GetRightMostPixel(palette) + 1);
            return width;
        }
        // public functions
        public void Reset()
        {
            next = 0;
            pages.Clear();
            pages.Push(0);
            location = new Point(0, 0);
        }
        public void Refresh()
        {
            int page = this.page;
            while (page-- >= 0)
                PageUp();
            page = 0;
            while (page++ <= this.page)
                PageDown();
        }
        public void PageUp()
        {
            if (pages.Count > 1)
            {
                page--;
                pages.Pop();
                location = new Point(0, 0);
            }
        }
        public void PageDown()
        {
            if (next != pages.Peek())
            {
                page++;
                pages.Push(next);
                location = new Point(0, 0);
            }
        }
        // public accessor functions
        public int[] GetPreview(params object[] args)
        {
            if (args.Length == 5)
                return GetPreview((Glyph[])args[0], (int[])args[1], (char[])args[2], (bool)args[3], (bool)args[4]);
            else
                return GetPreview((Glyph[])args[0], (int[])args[1], (char[])args[2], (bool)args[3], true);
        }
        public int[] GetPreview(Glyph[] font, int[] palette, char[] text, bool menu, bool allowclipping)
        {
            this.font = font;
            this.palette = palette;
            //
            int offset = GetOffset(text, menu);
            if (text.Length <= pages.Peek() + 1)
                PageUp();
            //
            location = new Point(9, 11);
            int[] pixels = new int[256 * 32];
            while (offset != text.Length)
            {
                if (text[offset] >= 0x20 && text[offset] <= 0x9F)
                {
                    if (location.X + font[text[offset] - 32].Width >= 256)
                    {
                        Do.DrawBorder(pixels, 256, palette[3]);
                        return pixels;
                    }
                    int width;
                    if (!allowclipping)
                        width = MinimumWidth(font[text[offset] - 32]);
                    else
                        width = font[text[offset] - 32].Width;
                    int maxWidth = font[text[offset] - 32].MaxWidth;
                    int[] glyphPixels = font[text[offset] - 32].GetPixels(palette);
                    for (int y = 0, b = location.Y; y < 12; y++, b++) // 12 rows per character
                    {
                        for (int x = 0, a = location.X; x < width; x++, a++) // # of pixels per row
                            pixels[b * 256 + a] = glyphPixels[y * maxWidth + x];
                    }
                    location.X += width + 1;
                }
                else if (!menu)
                {
                    switch ((byte)text[offset])
                    {
                        case 0x00: // END (End string)
                            offset++;
                            Do.DrawBorder(pixels, 256, palette[3]);
                            return pixels;
                        case 0x01: // BREAK (Line break)
                            offset++;
                            next = offset;
                            Do.DrawBorder(pixels, 256, palette[3]);
                            return pixels;
                        case 0x1C:
                            offset++;
                            break;
                        default: break;
                    }
                }
                offset++;
            }
            Do.DrawBorder(pixels, 256, palette[3]);
            return pixels;
        }
        public int GetOffset(char[] text, bool menu)
        {
            int page = 0;
            int offset = 0;
            while (offset != text.Length)
            {
                if (page == this.page)
                    return offset;
                if (!menu)
                {
                    switch ((byte)text[offset])
                    {
                        case 0x00: // END (End string)
                            offset++;
                            return offset;
                        case 0x01: // BREAK (Line break)
                            page++;
                            offset++;
                            next = offset;
                            continue;
                        case 0x1C:
                            offset++;
                            break;
                        default: break;
                    }
                }
                offset++;
            }
            return offset;
        }
    }
}
