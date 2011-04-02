using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace LAZYSHELL
{
    [Serializable()]
    public class FontCharacter
    {
        [NonSerialized()]
        private byte[] data;

        private int index; public int Index { get { return index; } }
        private int fontType; public int FontType { get { return fontType; } }

        private byte width; public byte Width { get { return width; } set { width = value; } }
        private byte height; public byte Height { get { return height; } }
        private byte[] graphics; public byte[] Graphics { get { return graphics; } set { graphics = value; } }

        private byte maxWidth; public byte MaxWidth { get { return maxWidth; } }

        public FontCharacter(byte[] data, int fontNum, int fontType)
        {
            this.data = data;
            this.index = fontNum;
            this.fontType = fontType;

            InitializeFontCharacter();
        }
        private void InitializeFontCharacter()
        {
            switch (fontType)
            {
                case 0: // menu font
                    width = (byte)data[index + 0x249300]; maxWidth = 8; height = 12;
                    graphics = Bits.GetByteArray(data, index * 0x18 + 0x249400, 0x18);
                    break;
                case 1: // dialogue font
                    width = (byte)data[index + 0x249280]; maxWidth = 16; height = 12;
                    graphics = Bits.GetByteArray(data, index * 0x30 + 0x37C000, 0x30);
                    break;
                case 2: // description font
                    width = (byte)data[index + 0x249380]; maxWidth = 8; height = 8;
                    graphics = Bits.GetByteArray(data, index * 0x10 + 0x37D800, 0x10);
                    break;
                case 3: // triangles
                    if (index < 7) { width = maxWidth = 8; height = 16; }
                    else { width = maxWidth = 16; height = 8; }
                    graphics = Bits.GetByteArray(data, index * 0x20 + 0x3DFA00, 0x20);
                    break;
            }
        }
        public int[] GetCharacterPixels(int[] palette)
        {
            byte b1, b2, t1, t2, col = 0;
            int offset = 0;

            int[] pixels = new int[maxWidth * height];

            for (int a = 0; a < maxWidth / 8; a++)
            {
                for (byte i = 0; i < height; i++)
                {
                    b1 = graphics[offset];
                    b2 = graphics[offset + 1];

                    for (byte z = 7; col < maxWidth; z--)
                    {
                        t1 = (byte)((b1 >> z) & 1);
                        t2 = (byte)((b2 >> z) & 1);

                        if (t2 * 2 + t1 != 0)
                        {
                            if (fontType != 3)
                                pixels[(i * maxWidth) + col] = palette[(t2 * 2) + t1];
                            else
                                pixels[(i * maxWidth) + col] = palette[(t2 * 2) + t1 + 4];
                        }
                        col++;
                    }
                    col = (byte)(a * 8);
                    offset += 2;
                }
                col += 8;
            }

            return pixels;
        }
        public int GetLeftMostPixel(int[] palette)
        {
            int[] pixels = GetCharacterPixels(palette);
            int right = 0;

            for (int x = 0; x < maxWidth; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if (pixels[y * maxWidth + x] != 0)
                    {
                        right = x;
                        return right;
                    }
                }
            }
            return 0;
        }
        public int GetRightMostPixel(int[] palette)
        {
            int[] pixels = GetCharacterPixels(palette);
            int left = maxWidth;

            for (int x = maxWidth - 1; x >= 0; x--)
            {
                for (int y = 0; y < height; y++)
                {
                    if (pixels[y * maxWidth + x] != 0 && x < left)
                    {
                        left = x;
                        return left;
                    }
                }
            }
            return 0;
        }
        public int GetTopMostPixel(int[] palette)
        {
            int[] pixels = GetCharacterPixels(palette);
            int bottom = 0;

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < maxWidth; x++)
                {
                    if (pixels[y * maxWidth + x] != 0)
                    {
                        bottom = y;
                        return bottom;
                    }
                }
            }
            return 0;
        }
        public int GetBottomMostPixel(int[] palette)
        {
            int[] pixels = GetCharacterPixels(palette);
            int top = height;

            for (int y = height - 1; y >= 0; y--)
            {
                for (int x = 0; x < maxWidth; x++)
                {
                    if (pixels[y * maxWidth + x] != 0 && y < top)
                    {
                        top = y;
                        return top;
                    }
                }
            }
            return 0;
        }
        public void Assemble()
        {
            switch (fontType)
            {
                case 0: // menu font
                    data[index + 0x249300] = width;
                    Bits.SetByteArray(data, index * 0x18 + 0x249400, graphics);
                    break;
                case 1: // dialogue font
                    data[index + 0x249280] = width;
                    Bits.SetByteArray(data, index * 0x30 + 0x37C000, graphics);
                    break;
                case 2: // description font
                    data[index + 0x249380] = width;
                    Bits.SetByteArray(data, index * 0x10 + 0x37D800, graphics);
                    break;
                case 3: // triangles
                    Bits.SetByteArray(data, index * 0x20 + 0x3DFA00, graphics);
                    break;
            }
        }
    }
}
