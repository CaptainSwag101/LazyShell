using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace LazyShell
{
    /// <summary>
    /// Class for creating and managing a set of palettes from the SNES palette binary data in a buffer.
    /// </summary>
    [Serializable()]
    public class PaletteSet
    {
        #region Variables

        // Buffer
        public byte[] Buffer { get; set; }

        // Properties
        private int offset, index, count, size;
        public int Length { get; set; }

        // RGB arrays
        public int[] Reds { get; set; }
        public int[] Greens { get; set; }
        public int[] Blues { get; set; }

        // RGB palettes
        private int[] palette;
        private int[][] palettes;
        public int[] Palette
        {
            get { return Do.RGBToColors(Reds, Greens, Blues); }
        }
        public int[][] Palettes
        {
            get { return Do.RGBToColors(Reds, Greens, Blues, count, size); }
        }

        #endregion

        // Constructors
        /// <summary>
        /// Creates a set of palettes from an offset in a byte array.
        /// </summary>
        /// <param name="buffer">The byte array.</param>
        /// <param name="index">The palette set's index.</param>
        /// <param name="offset">The palette set's offset.</param>
        /// <param name="count">The number of palettes in the set.</param>
        /// <param name="size">The number of colors in each palette.</param>
        /// <param name="length">The length, in raw 15-bit format, of each palette.</param>
        public PaletteSet(byte[] buffer, int index, int offset, int count, int size, int length)
        {
            this.Buffer = buffer;
            this.index = index;
            this.offset = offset;
            this.count = count;
            this.size = size;
            this.Length = length;
            //
            ReadFromBuffer();
        }
        public PaletteSet()
        {
        }

        #region Methods

        // Read/write buffer
        private void ReadFromBuffer()
        {
            Reds = new int[count * size];
            Greens = new int[count * size];
            Blues = new int[count * size];
            for (int i = 0; i < count; i++)
            {
                for (int a = 0; a < size; a++)
                {
                    if ((i * Length) + (a * 2) + offset + 1 >= Buffer.Length)
                        continue;
                    ushort color = Bits.GetShort(Buffer, (i * Length) + (a * 2) + offset);
                    Reds[i * size + a] = (color % 0x20) * 8;
                    Greens[i * size + a] = ((color >> 5) % 0x20) * 8;
                    Blues[i * size + a] = ((color >> 10) % 0x20) * 8;
                }
            }
            palette = Do.RGBToColors(Reds, Greens, Blues);
            palettes = Do.RGBToColors(Reds, Greens, Blues, count, size);
        }
        public void WriteToBuffer()
        {
            for (int i = 0; i < count; i++)
            {
                for (int a = (32 - Length) / 2; a < size; a++)
                {
                    int r = Reds[i * size + a] / 8;
                    int g = Greens[i * size + a] / 8;
                    int b = Blues[i * size + a] / 8;
                    ushort color = (ushort)((b << 10) | (g << 5) | r);
                    Bits.SetShort(Buffer, (i * Length) + (a * 2) + offset, color);
                }
            }
        }
        public void WriteToBuffer(int startIndex)
        {
            for (int i = startIndex; i < count; i++)
            {
                for (int a = (32 - Length) / 2; a < size; a++)
                {
                    int r = Reds[i * size + a] / 8;
                    int g = Greens[i * size + a] / 8;
                    int b = Blues[i * size + a] / 8;
                    ushort color = (ushort)((b << 10) | (g << 5) | r);
                    Bits.SetShort(Buffer, (i * Length) + (a * 2) + offset, color);
                }
            }
        }
        public void WriteToBuffer(byte[] buffer, int offset)
        {
            for (int i = 0; i < count; i++)
            {
                for (int a = (32 - Length) / 2; a < size; a++)
                {
                    int r = Reds[i * size + a] / 8;
                    int g = Greens[i * size + a] / 8;
                    int b = Blues[i * size + a] / 8;
                    ushort color = (ushort)((b << 10) | (g << 5) | r);
                    Bits.SetShort(buffer, (i * Length) + (a * 2) + offset, color);
                }
            }
        }

        // Clear
        public void Clear()
        {
            Reds = new int[count * size];
            Greens = new int[count * size];
            Blues = new int[count * size];
            palette = Do.RGBToColors(Reds, Greens, Blues);
            palettes = Do.RGBToColors(Reds, Greens, Blues, count, size);
        }
        public void Clear(int startIndex)
        {
            for (int i = startIndex; i < count; i++)
            {
                for (int a = 0; a < size; a++)
                {
                    Reds[i * size + a] = 0;
                    Greens[i * size + a] = 0;
                    Blues[i * size + a] = 0;
                }
            }
            palette = Do.RGBToColors(Reds, Greens, Blues);
            palettes = Do.RGBToColors(Reds, Greens, Blues, count, size);
        }

        /// <summary>
        /// Creates a deep copy of this instance.
        /// </summary>
        /// <returns></returns>
        public PaletteSet Copy()
        {
            PaletteSet copy = new PaletteSet(Buffer, index, offset, count, size, Length);
            copy.Buffer = Bits.Copy(Buffer);
            copy.Reds = Bits.Copy(Reds);
            copy.Greens = Bits.Copy(Greens);
            copy.Blues = Bits.Copy(Blues);
            return copy;
        }
        /// <summary>
        /// Copies this instance's RGB arrays to the RGB arrays of another instance.
        /// </summary>
        /// <param name="copyTo"></param>
        public void CopyTo(PaletteSet copyTo)
        {
            Reds.CopyTo(copyTo.Reds, 0);
            Greens.CopyTo(copyTo.Greens, 0);
            Blues.CopyTo(copyTo.Blues, 0);
        }

        #endregion
    }
}
