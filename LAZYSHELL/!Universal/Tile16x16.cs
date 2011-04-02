using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace LAZYSHELL
{
    [Serializable()]
    public class Tile16x16
    {
        private Tile8x8[] subtiles = new Tile8x8[4];
        public Tile8x8[] Subtiles { get { return subtiles; } set { subtiles = value; } }

        private int tileIndex;
        public int TileIndex { get { return tileIndex; } set { tileIndex = value; } }

        private bool mirror, invert;
        public bool Mirror { get { return mirror; } set { mirror = value; } }
        public bool Invert { get { return invert; } set { invert = value; } }

        private int[] pixels = new int[256];
        public int[] Pixels
        {
            get
            {
                int[] pixels = new int[16 * 16];
                if (subtiles[0] != null)
                    Do.PixelsToPixels(subtiles[0].Pixels, pixels, 16, new Rectangle(0, 0, 8, 8));
                if (subtiles[1] != null)
                    Do.PixelsToPixels(subtiles[1].Pixels, pixels, 16, new Rectangle(8, 0, 8, 8));
                if (subtiles[2] != null)
                    Do.PixelsToPixels(subtiles[2].Pixels, pixels, 16, new Rectangle(0, 8, 8, 8));
                if (subtiles[3] != null)
                    Do.PixelsToPixels(subtiles[3].Pixels, pixels, 16, new Rectangle(8, 8, 8, 8));
                if (mirror)
                    Do.FlipHorizontal(pixels, 16, 16);
                if (invert)
                    Do.FlipVertical(pixels, 16, 16);
                return pixels;
            }
            set
            {
                if (subtiles[0] != null)
                    subtiles[0].Pixels = Do.GetPixelRegion(value, new Rectangle(0, 0, 8, 8), 16, 16);
                if (subtiles[1] != null)
                    subtiles[1].Pixels = Do.GetPixelRegion(value, new Rectangle(8, 0, 8, 8), 16, 16);
                if (subtiles[2] != null)
                    subtiles[2].Pixels = Do.GetPixelRegion(value, new Rectangle(0, 8, 8, 8), 16, 16);
                if (subtiles[3] != null)
                    subtiles[3].Pixels = Do.GetPixelRegion(value, new Rectangle(8, 8, 8, 8), 16, 16);
            }
        }
        public int[] Pixels_P1
        {
            get
            {
                int[] pixels = new int[16 * 16];
                if (subtiles[0] != null && subtiles[0].PriorityOne)
                    Do.PixelsToPixels(subtiles[0].Pixels, pixels, 16, new Rectangle(0, 0, 8, 8));
                if (subtiles[1] != null && subtiles[1].PriorityOne)
                    Do.PixelsToPixels(subtiles[1].Pixels, pixels, 16, new Rectangle(8, 0, 8, 8));
                if (subtiles[2] != null && subtiles[2].PriorityOne)
                    Do.PixelsToPixels(subtiles[2].Pixels, pixels, 16, new Rectangle(0, 8, 8, 8));
                if (subtiles[3] != null && subtiles[3].PriorityOne)
                    Do.PixelsToPixels(subtiles[3].Pixels, pixels, 16, new Rectangle(8, 8, 8, 8));
                if (mirror)
                    Do.FlipHorizontal(pixels, 16, 16);
                if (invert)
                    Do.FlipVertical(pixels, 16, 16);
                for (int i = 0; i < 256; i++)
                    if (pixels[i] != 0) pixels[i] = Color.Blue.ToArgb();
                return pixels;
            }
        }

        public Tile16x16(int tileIndex)
        {
            this.tileIndex = tileIndex; // set tile Number
            this.pixels = new int[16 * 16];
            for (int p = 0; p < 4; p++)
                subtiles[p] = new Tile8x8(0, new byte[0x20], 0, new int[16], false, false, false, false);
        }

        public Tile16x16 Copy()
        {
            Tile16x16 copy = new Tile16x16(this.tileIndex);
            for (int i = 0; i < 4; i++)
            {
                Tile8x8 source = subtiles[i].Copy();
                copy.Subtiles[i] = source;
            }
            copy.Mirror = mirror;
            copy.Invert = invert;
            return copy;
        }
        public void Clear()
        {
            foreach (Tile8x8 tile in subtiles)
                tile.Clear();
        }
    }
}
