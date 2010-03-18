using System;
using System.Collections.Generic;
using System.Text;

namespace SMRPGED
{
    public class Tile16x16
    {
        private int tileNumber;
        private Tile8x8[] subtiles = new Tile8x8[4];
        private Tile8x8[] preview;
        private bool mirrored; public bool Mirrored { get { return mirrored; } set { mirrored = value; } }
        private bool inverted; public bool Inverted { get { return inverted; } set { inverted = value; } }
        private int[] pixels = new int[256];
        public bool GetPriority1(int placement)
        {
            if (this.isBeingModified)
                return preview[placement].PriorityOne;
            return subtiles[placement].PriorityOne;
        }
        public Tile8x8 GetSubtile(int placement)
        {
            if (this.isBeingModified)
                return preview[placement];
            return subtiles[placement];
        }
        public int TileNumber { get { return tileNumber; } set { tileNumber = value; } }
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
                    preview = new Tile8x8[4];
                    for (int i = 0; i < 4; i++)
                        preview[i] = subtiles[i];
                }
                else if (!this.isBeingModified)
                {
                    this.preview = null;
                }
            }
        }

        public Tile16x16(int tileNumber)
        {
            this.tileNumber = tileNumber; // set tile Number
        }
        public void SetSubtile(Tile8x8 tile, int placement)
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
            int[] pixels = new int[16 * 16];

            CopyOverTile8x8(GetSubtile(0), pixels, 16, 0, 0);
            CopyOverTile8x8(GetSubtile(1), pixels, 16, 8, 0);
            CopyOverTile8x8(GetSubtile(2), pixels, 16, 0, 8);
            CopyOverTile8x8(GetSubtile(3), pixels, 16, 8, 8);

            if (mirrored)
                Mirror(pixels);
            if (inverted)
                Invert(pixels);

            return pixels;
        }
        private void Mirror(int[] pixels)
        {
            int temp = 0;

            for (int y = 0; y < 16; y++)
            {
                for (int a = 0, b = 15; a < 8; a++, b--)
                {
                    temp = pixels[(y * 16) + a];
                    pixels[(y * 16) + a] = pixels[(y * 16) + b];
                    pixels[(y * 16) + b] = temp;
                }
            }
        }
        private void Invert(int[] pixels)
        {
            int temp = 0;

            for (int x = 0; x < 16; x++)
            {
                for (int a = 0, b = 15; a < 8; a++, b--)
                {
                    temp = pixels[(a * 16) + x];
                    pixels[(a * 16) + x] = pixels[(b * 16) + x];
                    pixels[(b * 16) + x] = temp;
                }
            }
        }
        public void CopyOverTile8x8(Tile8x8 source, int[] dest, int destinationWidth, int x, int y)
        {
            if (source == null) return;

            int[] src = source.Pixels;
            int counter = 0;
            for (int i = 0; i < 64; i++)
            {
                dest[y * destinationWidth + x + counter] = src[i];

                counter++;
                if (counter % 8 == 0)
                {
                    y++;
                    counter = 0;
                }
            }
        }
    }
}
