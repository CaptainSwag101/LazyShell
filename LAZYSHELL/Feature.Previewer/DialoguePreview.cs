using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace LAZYSHELL
{
    class DialoguePreview
    {
        private FontCharacter[] fontCharacters;
        private FontCharacter[] fontTriangles;
        private int[] palette;
        private int[] palette_t;
        private DialogueTable[] tables { get { return Model.DialogueTables; } }
        private Point p;
        private int next = 0;
        private bool drawPageBreak;
        private bool[] drawOptions;
        private int[] lineNext = new int[3];
        private Stack<int> pages = new Stack<int>();
        // main
        public DialoguePreview()
        {
            pages.Push(0);
        }
        public int[] GetPreview(FontCharacter[] fontCharacters, FontCharacter[] fontTriangles, int[] palette, int[] palette_t, char[] dlg, int left)
        {
            this.fontCharacters = fontCharacters;
            this.fontTriangles = fontTriangles;
            this.palette = palette;
            this.palette_t = palette_t;
            int line = 0;
            int charPtr = pages.Peek();
            int[] pixels = new int[256 * 56];

            drawOptions = new bool[3];
            drawPageBreak = false;
            p = new Point(left + 1, 6);

            int height, width, maxWidth, wordWidth;
            int[] font;

            dlg = ConvertSpecialCases(dlg);
            if (dlg.Length <= pages.Peek() + 1)
                PageUp();

            ArrayList words = new ArrayList();
            AddWords(words, dlg, charPtr);

            foreach (ArrayList word in words)
            {
                wordWidth = WordWidth(word);

                if (p.X + wordWidth >= 256 - left)
                {
                    if (line == 2)
                    {
                        next = lineNext[1];
                        AddBorder(pixels);
                        AddTriangles(pixels);
                        return pixels;
                    }
                    line++;
                    lineNext[line] = charPtr + 1;
                    p.X = left + 1; p.Y += 16;
                }
                foreach (char l in word)
                {
                    if (l >= 0x20 && l <= 0x9F)
                    {
                        height = fontCharacters[l - 32].Height;
                        width = fontCharacters[l - 32].Width;
                        maxWidth = fontCharacters[l - 32].MaxWidth;
                        font = fontCharacters[l - 32].GetCharacterPixels(palette);

                        if (p.X + width >= 256 - left)
                        {
                            if (line == 2)
                            {
                                next = lineNext[1];
                                AddBorder(pixels);
                                AddTriangles(pixels);
                                return pixels;
                            }
                            line++;
                            lineNext[line] = charPtr + 1;
                            p.X = left + 1; p.Y += 16;
                            break;
                        }

                        for (int y = 0, b = p.Y; y < height; y++, b++) // 12 rows per character
                        {
                            for (int x = 0, a = p.X; x < width; x++, a++) // # of pixels per row
                                pixels[b * 256 + a] = font[y * maxWidth + x];
                        }
                        p.X += width + 1;
                    }
                    else
                    {
                        switch ((byte)l)
                        {
                            case 0x00: goto case 0x06; // End String Press A
                            case 0x06:
                                AddBorder(pixels);
                                AddTriangles(pixels);
                                return pixels;
                            case 0x01: // Line Break
                            case 0x02:
                                if (line == 2)
                                {
                                    next = lineNext[1];
                                    AddBorder(pixels);
                                    AddTriangles(pixels);
                                    return pixels;
                                }
                                line++;
                                lineNext[line] = charPtr + 1;
                                p.X = left + 1; p.Y += 16;
                                break;
                            case 0x03:  // Page Break Press A
                                drawPageBreak = true;
                                goto case 0x04;
                            case 0x04:
                                charPtr++;
                                next = charPtr;
                                AddBorder(pixels);
                                AddTriangles(pixels);
                                return pixels;
                            case 0x07: drawOptions[line] = true; break;
                            default: break;
                        }
                    }
                    charPtr++;
                }
            }
            AddBorder(pixels);
            AddTriangles(pixels);

            return pixels;
        }
        private char[] ConvertSpecialCases(char[] dlg)
        {
            ArrayList n = new ArrayList();
            for (int i = 0; i < dlg.Length; i++)
            {
                if (dlg[i] >= 0x0E && dlg[i] <= 0x19)
                {
                    n.AddRange(tables[dlg[i] - 0x0E].RawDialogue);
                    continue;
                }
                switch ((byte)dlg[i])
                {
                    // eliminate, will NOT affect drawing
                    case 0x05: break;
                    case 0x0C: break;
                    case 0x0D: i++; break;
                    case 0x1A: break;
                    case 0x1C: i++; break;

                    // 2 or more characters
                    case 0x08: n.AddRange("  ".ToCharArray()); break;
                    case 0x09: n.AddRange("   ".ToCharArray()); break;
                    case 0x0A: n.AddRange("    ".ToCharArray()); break;
                    case 0x0B:
                        i++;
                        for (int a = 0; i < dlg.Length && a < dlg[i]; a++)
                            n.Add((char)0x20);
                        break;
                    // 1 regular character >= 0x20
                    default: n.Add(dlg[i]); break;
                }
            }
            dlg = new char[n.Count];
            n.CopyTo(dlg); return dlg;
        }
        private int WordWidth(ArrayList word)
        {
            int width = 0;
            foreach (char l in word)
            {
                if (l >= 0x20 && l <= 0x9F)
                    width += fontCharacters[l - 32].Width + 1;
            }
            return width;
        }
        // draw dialogue attributes
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
        private void AddTriangles(int[] pixels)
        {
            Point t = new Point(17, 4);
            int[] triangle = fontTriangles[0].GetCharacterPixels(palette_t);
            for (int i = 0; i < 3; i++)
            {
                t.Y = i * 16 + 4;
                if (drawOptions[i])
                {
                    for (int y = 0, b = t.Y; y < 16; y++, b++) // # of rows
                    {
                        for (int x = 0, a = t.X; x < 8; x++, a++) // 1 row6
                            pixels[b * 256 + a] = triangle[y * 8 + x];
                    }
                }
            }
            if (drawPageBreak)
            {
                triangle = fontTriangles[7].GetCharacterPixels(palette_t);
                t = new Point(224, 44);
                for (int y = 0, b = t.Y; y < 8; y++, b++) // # of rows
                {
                    for (int x = 0, a = t.X; x < 16; x++, a++) // 1 row6
                        pixels[b * 256 + a] = triangle[y * 16 + x];
                }
            }
        }
        private void AddWords(ArrayList words, char[] dlg, int charPtr)
        {
            ArrayList letters;

            while (charPtr < dlg.Length)
            {
                letters = new ArrayList();

                if (dlg[charPtr] <= 0x20)   // create a single word from special case or 1 space
                {
                    letters.Add(dlg[charPtr]); charPtr++;
                }
                else   // create word from regular characters
                {
                    for (; charPtr < dlg.Length; charPtr++)
                    {
                        // stop adding characters if next character is...
                        if (dlg[charPtr] >= 0x00 && dlg[charPtr] <= 0x04) break;
                        if (dlg[charPtr] == 0x06) break;
                        if (dlg[charPtr] >= 0x0E && dlg[charPtr] <= 0x19) break;
                        if (dlg[charPtr] == 0x1B) break;
                        if (dlg[charPtr] == 0x20) break;

                        // ...otherwise add next character
                        letters.Add(dlg[charPtr]);
                    }
                }
                words.Add(letters);
            }
        }
        // moving between pages
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
    }
}
