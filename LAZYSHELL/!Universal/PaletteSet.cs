using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace LAZYSHELL
{
    [Serializable()]
    public class PaletteSet
    {
        [NonSerialized()]
        private byte[] data; public byte[] Data { get { return this.data; } set { this.data = value; } }

        private int offset, index, count, size, length;
        private int[] reds, greens, blues;
        public int[] Reds { get { return reds; } set { reds = value; } }
        public int[] Greens { get { return greens; } set { greens = value; } }
        public int[] Blues { get { return blues; } set { blues = value; } }
        private int[] palette; public int[] Palette { get { return Do.RGBToColors(reds, greens, blues); } }
        private int[][] palettes; public int[][] Palettes { get { return Do.RGBToColors(reds, greens, blues, count, size); } }
        /// <summary>
        /// Creates a set of palettes from an offset in a byte array.
        /// </summary>
        /// <param name="data">The byte array.</param>
        /// <param name="index">The palette set's index.</param>
        /// <param name="offset">The palette set's offset.</param>
        /// <param name="count">The number of palettes in the set.</param>
        /// <param name="size">The number of colors in each palette.</param>
        /// <param name="length">The length, in raw 15-bit format, of each palette.</param>
        public PaletteSet(byte[] data, int index, int offset, int count, int size, int length)
        {
            this.data = data;
            this.index = index;
            this.offset = offset;
            this.count = count;
            this.size = size;
            this.length = length;
            InitializePaletteSet();
        }
        public PaletteSet()
        {
        }
        private void InitializePaletteSet()
        {
            reds = new int[count * size];
            greens = new int[count * size];
            blues = new int[count * size];
            for (int i = 0; i < count; i++)
            {
                for (int a = 0; a < size; a++)
                {
                    if ((i * length) + (a * 2) + offset + 1 >= data.Length)
                        continue;
                    ushort color = Bits.GetShort(data, (i * length) + (a * 2) + offset);
                    reds[i * size + a] = (color % 0x20) * 8;
                    greens[i * size + a] = ((color >> 5) % 0x20) * 8;
                    blues[i * size + a] = ((color >> 10) % 0x20) * 8;
                }
            }
            palette = Do.RGBToColors(reds, greens, blues);
            palettes = Do.RGBToColors(reds, greens, blues, count, size);
        }
        public void Clear()
        {
            reds = new int[count * size];
            greens = new int[count * size];
            blues = new int[count * size];
            palette = Do.RGBToColors(reds, greens, blues);
            palettes = Do.RGBToColors(reds, greens, blues, count, size);
        }
        public void Clear(int startIndex)
        {
            for (int i = startIndex; i < count; i++)
            {
                for (int a = 0; a < size; a++)
                {
                    reds[i * size + a] = 0;
                    greens[i * size + a] = 0;
                    blues[i * size + a] = 0;
                }
            }
            palette = Do.RGBToColors(reds, greens, blues);
            palettes = Do.RGBToColors(reds, greens, blues, count, size);
        }
        public void Assemble()
        {
            for (int i = 0; i < count; i++)
            {
                for (int a = 0; a < size; a++)
                {
                    int r = reds[i * size + a] / 8;
                    int g = greens[i * size + a] / 8;
                    int b = blues[i * size + a] / 8;
                    ushort color = (ushort)((b << 10) | (g << 5) | r);
                    Bits.SetShort(data, (i * length) + (a * 2) + offset, color);
                }
            }
        }
        public void Assemble(int startIndex)
        {
            for (int i = startIndex; i < count; i++)
            {
                for (int a = 0; a < size; a++)
                {
                    int r = reds[i * size + a] / 8;
                    int g = greens[i * size + a] / 8;
                    int b = blues[i * size + a] / 8;
                    ushort color = (ushort)((b << 10) | (g << 5) | r);
                    Bits.SetShort(data, (i * length) + (a * 2) + offset, color);
                }
            }
        }
        public void Assemble(byte[] data, int offset)
        {
            for (int i = 0; i < count; i++)
            {
                for (int a = 0; a < size; a++)
                {
                    int r = reds[i * size + a] / 8;
                    int g = greens[i * size + a] / 8;
                    int b = blues[i * size + a] / 8;
                    ushort color = (ushort)((b << 10) | (g << 5) | r);
                    Bits.SetShort(data, (i * length) + (a * 2) + offset, color);
                }
            }
        }
        public PaletteSet Copy()
        {
            PaletteSet copy = new PaletteSet(data, index, offset, count, size, length);
            copy.Data = data;
            reds.CopyTo(copy.Reds, 0);
            greens.CopyTo(copy.Greens, 0);
            blues.CopyTo(copy.Blues, 0);
            return copy;
        }
        public void CopyTo(PaletteSet copyTo)
        {
            reds.CopyTo(copyTo.Reds, 0);
            greens.CopyTo(copyTo.Greens, 0);
            blues.CopyTo(copyTo.Blues, 0);
        }
    }
}
