using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace LazyShell
{
    /// <summary>
    /// Class for generic 8x8 subtile used universally.
    /// </summary>
    [Serializable()]
    public class Subtile
    {
        #region Variables

        public bool TwoBPP { get; set; }
        public bool Priority1 { get; set; }
        public bool Mirror { get; set; }
        public bool Invert { get; set; }
        public int Index { get; set; }
        public int Palette { get; set; }
        /// <summary>
        /// The subtile's RGB pixel array.
        /// </summary>
        public int[] Pixels { get; set; }
        /// <summary>
        /// The subtile's color indexes.
        /// </summary>
        public int[] Colors { get; set; }

        #endregion

        /// <summary>
        /// Creates a new instance of a generic 8x8 subtile.
        /// </summary>
        /// <param name="index">The index of the subtile in the BPP graphics.</param>
        /// <param name="graphics">The source BPP graphics to read from.</param>
        /// <param name="offset">The offset of the BPP graphics to start reading from.</param>
        /// <param name="palette">The RGB palette to use.</param>
        /// <param name="mirror">The subtile will be flipped horizontally.</param>
        /// <param name="invert">The subtile will be flipped vertically.</param>
        /// <param name="priority1">The subtile will have priority 1 status in a map's layers.</param>
        /// <param name="twoBPP">The source graphics are in 2bpp format.</param>
        public Subtile(int index, byte[] graphics, int offset, int[] palette,
            bool mirror, bool invert, bool priority1, bool twoBPP)
        {
            this.Mirror = mirror;
            this.Invert = invert;
            this.Priority1 = priority1;
            this.Index = index;
            this.TwoBPP = twoBPP;

            // Initialize RGB arrays
            this.Pixels = new int[64];
            this.Colors = new int[64];

            // Convert SNES 4bpp to pixel array
            if (twoBPP == false)
            {
                // Read all 8 rows of color indexes
                for (int r = 0; r < 8; r++)
                {
                    // Get 8 color indexes in a row
                    byte[] row = new byte[8];
                    for (int i = 7, b = 1; i >= 0; i--, b *= 2)
                        if ((graphics[offset + r * 2 + 0x11] & b) == b)
                            row[i] += 8;
                    for (int i = 7, b = 1; i >= 0; i--, b *= 2)
                        if ((graphics[offset + r * 2 + 0x10] & b) == b)
                            row[i] += 4;
                    for (int i = 7, b = 1; i >= 0; i--, b *= 2)
                        if ((graphics[offset + r * 2 + 1] & b) == b)
                            row[i] += 2;
                    for (int i = 7, b = 1; i >= 0; i--, b *= 2)
                        if ((graphics[offset + r * 2] & b) == b)
                            row[i]++;

                    // Paint pixels using RGB palette and color indexes
                    for (int c = 0; c < 8; c++) 
                    {
                        Colors[r * 8 + c] = row[c];

                        // Set RGB pixel value to RGB color in palette
                        if (row[c] != 0)
                            Pixels[r * 8 + c] = palette[row[c]]; // Color index in palette
                    }
                }
            }
            // Convert SNES 2bpp to pixel array
            else
            {
                byte b1, b2, t1, t2, col = 0;

                // Convert to 4-color palette
                int[] pal = new int[4];
                for (int i = 0; i < 4; i++)
                    pal[i] = palette[i];

                // Read all 8 rows of color indexes
                for (byte i = 0; i < 8; i++)
                {
                    b1 = graphics[offset];
                    b2 = graphics[offset + 1];

                    // Get 8 color indexes in a row
                    for (byte z = 7; col < 8; z--)
                    {
                        t1 = (byte)((b1 >> z) & 1);
                        t2 = (byte)((b2 >> z) & 1);
                        Colors[(i * 8) + col] = (t2 * 2) + t1;
                        if ((t2 * 2) + t1 != 0)
                            Pixels[(i * 8) + col] = pal[(t2 * 2) + t1];
                        col++;
                    }
                    col = 0;
                    offset += 2;
                }
            }

            // Flip subtile pixels if necessary
            if (mirror) Do.FlipHorizontal(Pixels, 8, 8);
            if (invert) Do.FlipVertical(Pixels, 8, 8);
        }
        /// <summary>
        /// Creates a new instance of a Mode7 8x8 subtile.
        /// </summary>
        /// <param name="index">The index of the subtile in the BPP graphics.</param>
        /// <param name="graphics">The source Mode7 graphics to read from.</param>
        /// <param name="offset">The offset of the Mode7 graphics to start reading from.</param>
        /// <param name="palette">The RGB palette to use.</param>
        public Subtile(int index, byte[] graphics, int offset, int[] palette)
        {
            this.Index = index;
            for (int i = 0; i < 64; i++)
            {
                if (i % 2 == 0)
                {
                    Pixels[i] = palette[graphics[offset + (i / 2)] & 0x0F];
                    Colors[i] = graphics[offset + (i / 2)] & 0x0F;
                }
                else
                {
                    Pixels[i] = palette[(graphics[offset + (i / 2)] & 0xF0) >> 4];
                    Colors[i] = (graphics[offset + (i / 2)] & 0xF0) >> 4;
                }
            }
        }
        private Subtile()
        {
        }

        #region Methods

        /// <summary>
        /// Creates a non-referenced copy of this instance.
        /// </summary>
        /// <returns></returns>
        public Subtile Copy()
        {
            var copy = new Subtile();
            copy.Pixels = Bits.Copy(this.Pixels);
            copy.Colors = Bits.Copy(this.Colors);
            copy.Priority1 = this.Priority1;
            copy.Mirror = this.Mirror;
            copy.Invert = this.Invert;
            copy.Index = this.Index;
            copy.Palette = this.Palette;
            return copy;
        }
        /// <summary>
        /// Copies this instance's properties to another Subtile.
        /// </summary>
        /// <param name="dst"></param>
        public void CopyTo(Subtile dst)
        {
            dst.Index = this.Index;
            dst.Palette = this.Palette;
            dst.Priority1 = this.Priority1;
            dst.Mirror = this.Mirror;
            dst.Invert = this.Invert;
            this.Pixels.CopyTo(dst.Pixels, 0);
            this.Colors.CopyTo(dst.Colors, 0);
        }
        
        // Clear
        public void Clear()
        {
            Mirror = false;
            Invert = false;
            Priority1 = false;
            Pixels = new int[64];
            Colors = new int[64];
            Index = 0;
            Palette = 0;
        }

        #endregion
    }
}
