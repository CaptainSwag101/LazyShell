using System;
using System.Collections.Generic;
using System.Text;

namespace SMRPGED
{
    public class Tile32x32
    {
        private int tileNumber; public int TileNumber { get { return tileNumber; } }
        private Tile16x16[] subtiles = new Tile16x16[4];
        private Tile16x16[] preview;

        public Tile16x16 GetSubtile(int placement)
        {
            if (this.isBeingModified)
                return preview[placement];
            return subtiles[placement];
        }
        private bool isBeingModified = false;
        public bool IsBeingModified
        {
            get
            {
                return this.isBeingModified;
            }
            set
            {
                this.isBeingModified = value;
                if (this.isBeingModified && this.preview == null)
                {
                    preview = new Tile16x16[4];
                    for (int i = 0; i < 4; i++)
                        preview[i] = subtiles[i];
                }
                else if (!this.isBeingModified)
                {
                    this.preview = null;
                }
            }
        }
        public Tile32x32(int tileNumber)
        {
            this.tileNumber = tileNumber; // set tile Number
        }
        public void SetSubtile(Tile16x16 tile, int placement)
        {
            //[0][1]
            //[2][3]
            if (isBeingModified)
                preview[placement] = tile;
            else
                subtiles[placement] = tile;
        }
        public void ConfirmChanges()
        {
            if (!this.isBeingModified)
                return;

            for (int i = 0; i < 4; i++)
                subtiles[i] = preview[i];

            this.IsBeingModified = false;
        }

        public int[] Pixels()
        {
            int[] pixels = new int[32 * 32];

            CopyOverTile16x16(GetSubtile(0).Pixels(), pixels, 32, 0, 0);
            CopyOverTile16x16(GetSubtile(1).Pixels(), pixels, 32, 16, 0);
            CopyOverTile16x16(GetSubtile(2).Pixels(), pixels, 32, 0, 16);
            CopyOverTile16x16(GetSubtile(3).Pixels(), pixels, 32, 16, 16);

            return pixels;
        }

        public void CopyOverTile16x16(int[] src, int[] dest, int destinationWidth, int x, int y)
        {
            int counter = 0;
            for (int i = 0; i < 256; i++)
            {
                dest[y * destinationWidth + x + counter] = src[i];

                counter++;
                if (counter % 16 == 0)
                {
                    y++;
                    counter = 0;
                }
            }
        }
    }
}
