using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace LAZYSHELL.Areas
{
    public class OverlapTile
    {
        #region Variables

        public int Index { get; set; }
        public Tile[] Subtiles { get; set; }
        /// <summary>
        /// The overlap tile's RGB pixel array.
        /// </summary>
        public int[] Pixels
        {
            get
            {
                int[] pixels = new int[32 * 32];
                Do.PixelsToPixels(Subtiles[0].Pixels, pixels, 32, new Rectangle(0, 0, 16, 16));
                Do.PixelsToPixels(Subtiles[1].Pixels, pixels, 32, new Rectangle(16, 0, 16, 16));
                Do.PixelsToPixels(Subtiles[2].Pixels, pixels, 32, new Rectangle(0, 16, 16, 16));
                Do.PixelsToPixels(Subtiles[3].Pixels, pixels, 32, new Rectangle(16, 16, 16, 16));
                return pixels;
            }
            set
            {
                Subtiles[0].Pixels = Do.GetPixelRegion(value, new Rectangle(0, 0, 16, 16), 32, 32);
                Subtiles[1].Pixels = Do.GetPixelRegion(value, new Rectangle(16, 0, 16, 16), 32, 32);
                Subtiles[2].Pixels = Do.GetPixelRegion(value, new Rectangle(0, 16, 16, 16), 32, 32);
                Subtiles[3].Pixels = Do.GetPixelRegion(value, new Rectangle(16, 16, 16, 16), 32, 32);
            }
        }

        #endregion

        // Constructor
        public OverlapTile(int index)
        {
            this.Index = index; // set tile Number
            this.Subtiles = new Tile[4];
        }
    }
}
