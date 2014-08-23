using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace LAZYSHELL.Fonts
{
    /// <summary>
    /// Class containing the properties of a font's glyph and the methods 
    /// for retrieving the RGB pixel data necessary for drawing to canvas.
    /// </summary>
    [Serializable()]
    public class Glyph
    {
        #region Variables

        // ROM buffer
        private byte[] rom
        {
            get { return Model.ROM; }
            set { Model.ROM = value; }
        }

        // Properties
        public int Index { get; set; }
        public FontType Type { get; set; }
        public byte Width { get; set; }
        public byte Height { get; set; }
        public byte[] Graphics { get; set; }
        public byte MaxWidth { get; set; }

        #endregion

        // Constructor
        public Glyph(int index, FontType type)
        {
            this.Index = index;
            this.Type = type;
            ReadFromROM();
        }

        #region Methods

        // Read/write ROM
        private void ReadFromROM()
        {
            switch (Type)
            {
                case FontType.Menu: // menu font
                    Width = (byte)rom[Index + 0x249300]; MaxWidth = 8; Height = 12;
                    Graphics = Bits.GetBytes(rom, Index * 0x18 + 0x249400, 0x18);
                    break;
                case FontType.Dialogue: // dialogue font
                    Width = (byte)rom[Index + 0x249280]; MaxWidth = 16; Height = 12;
                    Graphics = Bits.GetBytes(rom, Index * 0x30 + 0x37C000, 0x30);
                    break;
                case FontType.Description: // description font
                    Width = (byte)rom[Index + 0x249380]; MaxWidth = 8; Height = 8;
                    Graphics = Bits.GetBytes(rom, Index * 0x10 + 0x37D800, 0x10);
                    break;
                case FontType.Triangles: // triangles
                    if (Index < 7) { Width = MaxWidth = 8; Height = 16; }
                    else { Width = MaxWidth = 16; Height = 8; }
                    Graphics = Bits.GetBytes(rom, Index * 0x20 + 0x3DFA00, 0x20);
                    break;
                case FontType.BattleMenu: // battle menu font
                    Width = 8; MaxWidth = 8; Height = 8;
                    Graphics = Bits.GetBytes(Model.Graphics_BattleMenu, Index * 0x20, 0x20);
                    break;
                case FontType.FlowerBonus: // flower bonus font
                    Width = 8; MaxWidth = 8; Height = 8;
                    Graphics = Bits.GetBytes(Model.Graphics_Bonus, Index * 0x20, 0x20);
                    break;
            }
        }
        public void WriteToROM()
        {
            switch (Type)
            {
                case FontType.Menu: // menu font
                    rom[Index + 0x249300] = Width;
                    Bits.SetBytes(rom, Index * 0x18 + 0x249400, Graphics);
                    break;
                case FontType.Dialogue: // dialogue font
                    rom[Index + 0x249280] = Width;
                    Bits.SetBytes(rom, Index * 0x30 + 0x37C000, Graphics);
                    break;
                case FontType.Description: // description font
                    rom[Index + 0x249380] = Width;
                    Bits.SetBytes(rom, Index * 0x10 + 0x37D800, Graphics);
                    break;
                case FontType.Triangles: // triangles
                    Bits.SetBytes(rom, Index * 0x20 + 0x3DFA00, Graphics);
                    break;
                case FontType.BattleMenu: // battle menu font
                    Bits.SetBytes(rom, Index * 0x20, Graphics);
                    break;
            }
        }

        /// <summary>
        ///  Creates a RGB pixel array of this glyph using the specified RGB palette.
        /// </summary>
        /// <param name="palette">The RGB palette to use in the operation.</param>
        /// <returns></returns>
        public int[] GetPixels(int[] palette)
        {
            int offset = 0;
            int[] pixels = new int[MaxWidth * Height];
            if ((int)Type < 4)
            {
                byte b1, b2, t1, t2, col = 0;
                for (int a = 0; a < MaxWidth / 8; a++)
                {
                    for (byte i = 0; i < Height; i++)
                    {
                        b1 = Graphics[offset];
                        b2 = Graphics[offset + 1];
                        for (byte z = 7; col < MaxWidth; z--)
                        {
                            t1 = (byte)((b1 >> z) & 1);
                            t2 = (byte)((b2 >> z) & 1);
                            if (t2 * 2 + t1 != 0)
                            {
                                if (Type != FontType.Triangles)
                                    pixels[(i * MaxWidth) + col] = palette[(t2 * 2) + t1];
                                else
                                    pixels[(i * MaxWidth) + col] = palette[(t2 * 2) + t1 + 4];
                            }
                            col++;
                        }
                        col = (byte)(a * 8);
                        offset += 2;
                    }
                    col += 8;
                }
            }
            else
            {
                for (int r = 0; r < 8; r++) // Number of Rows in an 8x8 Tile
                {
                    // Get all the pixels in a row
                    byte[] row = new byte[8];
                    for (int i = 7, b = 1; i >= 0; i--, b *= 2)
                        if ((Graphics[offset + r * 2 + 0x11] & b) == b)
                            row[i] += 8;
                    for (int i = 7, b = 1; i >= 0; i--, b *= 2)
                        if ((Graphics[offset + r * 2 + 0x10] & b) == b)
                            row[i] += 4;
                    for (int i = 7, b = 1; i >= 0; i--, b *= 2)
                        if ((Graphics[offset + r * 2 + 1] & b) == b)
                            row[i] += 2;
                    for (int i = 7, b = 1; i >= 0; i--, b *= 2)
                        if ((Graphics[offset + r * 2] & b) == b)
                            row[i]++;
                    for (int c = 0; c < 8; c++) // Number of Columns in an 8x8 Tile
                    {
                        if (row[c] != 0)
                            pixels[r * 8 + c] = palette[row[c]]; // Set pixel in 8x8 tile
                    }
                }
            }
            return pixels;
        }
        /// <summary>
        /// Returns the X coordinate of the left-most pixel in the glyph's pixel data.
        /// </summary>
        /// <param name="palette">The RGB palette to use in the operation.</param>
        /// <returns></returns>
        public int GetLeftMostPixel(int[] palette)
        {
            int[] pixels = GetPixels(palette);
            int right = 0;
            for (int x = 0; x < MaxWidth; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    if (pixels[y * MaxWidth + x] != 0)
                    {
                        right = x;
                        return right;
                    }
                }
            }
            return 0;
        }
        /// <summary>
        /// Returns the X coordinate of the right-most pixel in the glyph's pixel data.
        /// </summary>
        /// <param name="palette">The RGB palette to use in the operation.</param>
        /// <returns></returns>
        public int GetRightMostPixel(int[] palette)
        {
            int[] pixels = GetPixels(palette);
            int left = MaxWidth;
            for (int x = MaxWidth - 1; x >= 0; x--)
            {
                for (int y = 0; y < Height; y++)
                {
                    if (pixels[y * MaxWidth + x] != 0 && x < left)
                    {
                        left = x;
                        return left;
                    }
                }
            }
            return 0;
        }
        /// <summary>
        /// Returns the Y coordinate of the top-most pixel in the glyph's pixel data.
        /// </summary>
        /// <param name="palette">The RGB palette to use in the operation.</param>
        /// <returns></returns>
        public int GetTopMostPixel(int[] palette)
        {
            int[] pixels = GetPixels(palette);
            int bottom = 0;
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < MaxWidth; x++)
                {
                    if (pixels[y * MaxWidth + x] != 0)
                    {
                        bottom = y;
                        return bottom;
                    }
                }
            }
            return 0;
        }
        /// <summary>
        /// Returns the Y coordinate of the bottom-most pixel in the glyph's pixel data.
        /// </summary>
        /// <param name="palette">The RGB palette to use in the operation.</param>
        /// <returns></returns>
        public int GetBottomMostPixel(int[] palette)
        {
            int[] pixels = GetPixels(palette);
            int top = Height;
            for (int y = Height - 1; y >= 0; y--)
            {
                for (int x = 0; x < MaxWidth; x++)
                {
                    if (pixels[y * MaxWidth + x] != 0 && y < top)
                    {
                        top = y;
                        return top;
                    }
                }
            }
            return 0;
        }

        /// <summary>
        /// Flips this glyph's pixel data horizontally.
        /// </summary>
        /// <param name="palette">The RGB palette to use in the operation.</param>
        /// <returns></returns>
        public void Mirror(int[] palette)
        {
            int maxY = GetBottomMostPixel(palette);
            int maxX = GetRightMostPixel(palette);
            int minY = GetTopMostPixel(palette);
            int minX = GetLeftMostPixel(palette);
            for (int y = minY; y < maxY + 1; y++)
            {
                for (int a = minX, b = maxX; a < b; a++, b--)
                {
                    byte rowA = (byte)y;
                    byte colA = (byte)a;
                    byte bitA = (byte)((colA & 7) ^ 7);
                    int offsetA = rowA * 2;
                    byte rowB = (byte)y;
                    byte colB = (byte)b;
                    byte bitB = (byte)((colB & 7) ^ 7);
                    int offsetB = rowB * 2;
                    switch (Type)
                    {
                        case FontType.Menu:
                        case FontType.Description:
                            bool tempM = Bits.GetBit(Graphics, offsetA, bitA);
                            bool tempN = Bits.GetBit(Graphics, offsetA + 1, bitA);
                            Bits.SetBit(Graphics, offsetA, bitA, Bits.GetBit(Graphics, offsetB, bitB));
                            Bits.SetBit(Graphics, offsetA + 1, bitA, Bits.GetBit(Graphics, offsetB + 1, bitB));
                            Bits.SetBit(Graphics, offsetB, bitB, tempM);
                            Bits.SetBit(Graphics, offsetB + 1, bitB, tempN);
                            break;
                        case FontType.Dialogue:
                            offsetA += colA >= 8 ? 24 : 0;
                            offsetB += colB >= 8 ? 24 : 0;
                            goto case 0;
                        case FontType.Triangles:
                            offsetA += colA >= 8 ? 16 : 0;
                            offsetB += colB >= 8 ? 16 : 0;
                            goto case 0;
                    }
                }
            }
        }
        /// <summary>
        /// Flips this glyph's pixel data vertically.
        /// </summary>
        /// <param name="palette">The RGB palette to use in the operation.</param>
        /// <returns></returns>
        public void Invert(int[] palette)
        {
            int maxY = GetBottomMostPixel(palette);
            int maxX = GetRightMostPixel(palette);
            int minY = GetTopMostPixel(palette);
            int minX = GetLeftMostPixel(palette);
            for (int x = minX; x < maxX + 1; x++)
            {
                for (int a = minY, b = maxY; a < b; a++, b--)
                {
                    byte rowA = (byte)a;
                    byte colA = (byte)x;
                    byte bitA = (byte)((colA & 7) ^ 7);
                    int offsetA = rowA * 2;
                    byte rowB = (byte)b;
                    byte colB = (byte)x;
                    byte bitB = (byte)((colB & 7) ^ 7);
                    int offsetB = rowB * 2;
                    switch (Type)
                    {
                        case FontType.Menu:
                        case FontType.Description:
                            bool tempM = Bits.GetBit(Graphics, offsetA, bitA);
                            bool tempN = Bits.GetBit(Graphics, offsetA + 1, bitA);
                            Bits.SetBit(Graphics, offsetA, bitA, Bits.GetBit(Graphics, offsetB, bitB));
                            Bits.SetBit(Graphics, offsetA + 1, bitA, Bits.GetBit(Graphics, offsetB + 1, bitB));
                            Bits.SetBit(Graphics, offsetB, bitB, tempM);
                            Bits.SetBit(Graphics, offsetB + 1, bitB, tempN);
                            break;
                        case FontType.Dialogue:
                            offsetA += colA >= 8 ? 24 : 0;
                            offsetB += colB >= 8 ? 24 : 0;
                            goto case 0;
                        case FontType.Triangles:
                            offsetA += colA >= 8 ? 16 : 0;
                            offsetB += colB >= 8 ? 16 : 0;
                            goto case 0;
                    }
                }
            }
        }

        #endregion
    }
}
