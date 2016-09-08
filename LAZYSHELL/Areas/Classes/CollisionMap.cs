using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace LazyShell.Areas
{
    public class CollisionMap : Tilemap
    {
        #region Variables

        private Collision collision;
        // Properties
        public Map AreaMap { get; set; }
        public override byte[] Tilemap_bytes { get; set; }
        public override byte[][] Tilemaps_bytes
        {
            get { return null; }
            set { }
        }
        public override Tileset Tileset
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }
        public override Tile[] Tilemap_tiles
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }
        public override Tile[][] Tilemaps_tiles
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }
        public override int Width_p
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }
        public override int Height_p
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }
        public override int[] Pixels { get; set; }
        private Bitmap image;
        public override Bitmap Image
        {
            get
            {
                if (image == null)
                {
                    Pixels = collision.GetTilemapPixels(this);
                    image = Do.PixelsToImage(Pixels, 1024, 1024);
                }
                return image;
            }
            set { image = value; }
        }

        #endregion

        // Constructor
        public CollisionMap(Map areaMap)
        {
            this.AreaMap = areaMap;
            InitializeVariables();
            InitializeTilemapBytes();
        }
        
        #region Methods

        // Initialization
        private void InitializeVariables()
        {
            this.collision = Collision.Instance;
        }
        private void InitializeTilemapBytes()
        {
            this.Tilemap_bytes = Model.CollisionMaps[AreaMap.CollisionMap];
        }
        // Tilemap creation
        public override void ParseTilemap()
        {
            throw new NotImplementedException();
        }
        // External modification
        public override int GetTileNum(int index)
        {
            return Bits.GetShort(Tilemap_bytes, index * 2);
        }
        public override int GetTileNum(int layer, int x, int y)
        {
            int index = collision.PixelTiles[y * 1024 + x];
            return GetTileNum(index);
        }
        public override int GetTileNum(int layer, int x, int y, bool ignoretransparent)
        {
            return GetTileNum(layer, x, y);
        }
        public override void SetTileNum()
        {
            Model.Modify_CollisionMaps[AreaMap.CollisionMap] = true;
        }
        public override void SetTileNum(int tilenum, int layer, int x, int y)
        {
            int index = collision.PixelTiles[y * 1024 + x];
            Bits.SetShort(Tilemap_bytes, index * 2, tilenum);
        }
        public override int[] GetPixels(int layer, Point area, Size size)
        {
            return this.Pixels;
        }
        public override int[] GetPixels(Point area, Size size)
        {
            return this.Pixels;
        }
        public override int[] GetPriority1Pixels()
        {
            return collision.GetPriority1Pixels(this);
        }
        public override int GetPixelLayer(int x, int y)
        {
            return 0;
        }
        public override void RedrawTilemaps()
        {
            this.Pixels = collision.GetTilemapPixels(this);
        }
        // Inherited
        public void Clear(int count)
        {
            if (count == 1)
            {
                Model.CollisionMaps[AreaMap.CollisionMap] = Tilemap_bytes = new byte[0x20C2];
                Model.Modify_CollisionMaps[AreaMap.CollisionMap] = true;
            }
            else
            {
                Tilemap_bytes = new byte[0x20C2];
                for (int i = 0; i < count; i++)
                {
                    Model.CollisionMaps[i] = new byte[0x20C2];
                    Model.Modify_CollisionMaps[i] = true;
                }
            }
        }

        #endregion
    }
}
