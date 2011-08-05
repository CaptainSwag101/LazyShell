using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace LAZYSHELL
{
    public class LevelSolidMap : Map
    {
                private Solidity solidity = Solidity.Instance;
        private LevelMap levelMap; public LevelMap Levelmap { get { return levelMap; } }
        private int[] pixels;
        public override int[] Pixels
        {
            get
            {
                return pixels;
            }
            set { pixels = value; }
        }
        private Bitmap image;
        public override Bitmap Image
        {
            get
            {
                if (image == null)
                {
                    pixels = solidity.GetTilemapPixels(this);
                    image = Do.PixelsToImage(pixels, 1024, 1024);
                }
                return image;
            }
            set { image = value; }
        }
        private byte[] tilemap; public override byte[] Tilemap { get { return tilemap; } set { tilemap = value; } }

        public LevelSolidMap(LevelMap levelMap)
        {
            this.levelMap = levelMap;
            tilemap = Model.SolidityMaps[levelMap.SolidityMap];
        }
        public override void MakeEdit()
        {
            Model.EditSolidityMaps[levelMap.SolidityMap] = true;
        }
        public override int GetTileNum(int physTileNum)
        {
            return Bits.GetShort(tilemap, physTileNum * 2);
        }
        public void Clear(int count)
        {
            if (count == 1)
            {
                Model.SolidityMaps[levelMap.SolidityMap] = tilemap = new byte[0x20C2];
                Model.EditSolidityMaps[levelMap.SolidityMap] = true;
            }
            else
            {
                tilemap = new byte[0x20C2];
                for (int i = 0; i < count; i++)
                {
                    Model.SolidityMaps[i] = new byte[0x20C2];
                    Model.EditSolidityMaps[i] = true;
                }
            }
        }
    }
}
