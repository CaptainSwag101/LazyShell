using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace LAZYSHELL
{
    public class LevelSolidMap : Map
    {
        private Model model = State.Instance.Model;
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
            tilemap = model.PhysicalMaps[levelMap.PhysicalMap];
        }
        public void MakeEdit()
        {
            model.EditPhysicalMaps[levelMap.PhysicalMap] = true;
        }
        public ushort GetTileNum(int physTileNum)
        {
            return Bits.GetShort(tilemap, physTileNum * 2);
        }
        public void Clear(int count)
        {
            if (count == 1)
            {
                model.PhysicalMaps[levelMap.PhysicalMap] = tilemap = new byte[0x20C2];
                model.EditPhysicalMaps[levelMap.PhysicalMap] = true;
            }
            else
            {
                tilemap = new byte[0x20C2];
                for (int i = 0; i < count; i++)
                {
                    model.PhysicalMaps[i] = new byte[0x20C2];
                    model.EditPhysicalMaps[i] = true;
                }
            }
        }
    }
}
