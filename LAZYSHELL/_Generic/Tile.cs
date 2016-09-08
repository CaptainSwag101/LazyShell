using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace LazyShell
{
    /// <summary>
    /// Class for a generic 16x16 tile used in a tilemap, containing 4 subtiles.
    /// </summary>
    [Serializable()]
    public class Tile
    {
        #region Variables

        public Subtile[] Subtiles { get; set; }
        public int Index { get; set; }
        public bool Mirror { get; set; }
        public bool Invert { get; set; }
        public bool TwoBPP
        {
            get { return Subtiles[0].TwoBPP; }
        }
        private int[] pixels = new int[256];
        /// <summary>
        /// The subtile's RGB pixel array.
        /// </summary>
        public int[] Pixels
        {
            get
            {
                int[] pixels = new int[16 * 16];
                if (Subtiles[0] != null)
                    Do.PixelsToPixels(Subtiles[0].Pixels, pixels, 16, new Rectangle(0, 0, 8, 8));
                if (Subtiles[1] != null)
                    Do.PixelsToPixels(Subtiles[1].Pixels, pixels, 16, new Rectangle(8, 0, 8, 8));
                if (Subtiles[2] != null)
                    Do.PixelsToPixels(Subtiles[2].Pixels, pixels, 16, new Rectangle(0, 8, 8, 8));
                if (Subtiles[3] != null)
                    Do.PixelsToPixels(Subtiles[3].Pixels, pixels, 16, new Rectangle(8, 8, 8, 8));
                if (Mirror)
                    Do.FlipHorizontal(pixels, 16, 16);
                if (Invert)
                    Do.FlipVertical(pixels, 16, 16);
                return pixels;
            }
            set
            {
                if (Subtiles[0] != null)
                    Subtiles[0].Pixels = Do.GetPixelRegion(value, new Rectangle(0, 0, 8, 8), 16, 16);
                if (Subtiles[1] != null)
                    Subtiles[1].Pixels = Do.GetPixelRegion(value, new Rectangle(8, 0, 8, 8), 16, 16);
                if (Subtiles[2] != null)
                    Subtiles[2].Pixels = Do.GetPixelRegion(value, new Rectangle(0, 8, 8, 8), 16, 16);
                if (Subtiles[3] != null)
                    Subtiles[3].Pixels = Do.GetPixelRegion(value, new Rectangle(8, 8, 8, 8), 16, 16);
            }
        }
        /// <summary>
        /// The tile's RGB pixels, limited to pixels of it's subtiles with priority 1 status.
        /// </summary>
        public int[] Pixels_P1
        {
            get
            {
                int[] pixels = new int[16 * 16];
                if (Subtiles[0] != null && Subtiles[0].Priority1)
                    Do.PixelsToPixels(Subtiles[0].Pixels, pixels, 16, new Rectangle(0, 0, 8, 8));
                if (Subtiles[1] != null && Subtiles[1].Priority1)
                    Do.PixelsToPixels(Subtiles[1].Pixels, pixels, 16, new Rectangle(8, 0, 8, 8));
                if (Subtiles[2] != null && Subtiles[2].Priority1)
                    Do.PixelsToPixels(Subtiles[2].Pixels, pixels, 16, new Rectangle(0, 8, 8, 8));
                if (Subtiles[3] != null && Subtiles[3].Priority1)
                    Do.PixelsToPixels(Subtiles[3].Pixels, pixels, 16, new Rectangle(8, 8, 8, 8));
                if (Mirror)
                    Do.FlipHorizontal(pixels, 16, 16);
                if (Invert)
                    Do.FlipVertical(pixels, 16, 16);
                for (int i = 0; i < 256; i++)
                    if (pixels[i] != 0) pixels[i] = Color.Blue.ToArgb();
                return pixels;
            }
        }

        #endregion

        // Constructors
        public Tile(int index)
        {
            this.Subtiles = new Subtile[4];
            this.Index = index; // set tile Number
            this.pixels = new int[16 * 16];
            for (int p = 0; p < 4; p++)
                Subtiles[p] = new Subtile(0, new byte[0x20], 0, new int[16], false, false, false, false);
        }

        #region Methods

        /// <summary>
        /// Creates a deep copy of this instance.
        /// </summary>
        /// <returns></returns>
        public Tile Copy()
        {
            var copy = new Tile(this.Index);
            for (int i = 0; i < 4; i++)
            {
                var source = Subtiles[i].Copy();
                copy.Subtiles[i] = source;
            }
            copy.Mirror = Mirror;
            copy.Invert = Invert;
            return copy;
        }

        // Clear
        public void Clear()
        {
            foreach (var tile in Subtiles)
                tile.Clear();
        }

        #endregion
    }
}
