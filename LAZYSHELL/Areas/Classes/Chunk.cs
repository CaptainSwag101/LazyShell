using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace LazyShell.Areas
{
    [Serializable]
    public class Chunk
    {
        #region Variables

        [NonSerialized()]
        private Collision collision;
        // Properties
        public string Name { get; set; }
        public byte[] CollisionMap_bytes { get; set; }
        public byte[][] Tilemaps_bytes { get; set; }
        public Point Start { get; set; }
        public Size Size { get; set; }
        /// <summary>
        /// Checks if the chunk's width value is an even number so the 
        /// paint operation starts drawing at the correct isometric coord.
        /// </summary> 
        public bool IsEven
        {
            get { return (Size.Width / 16) % 2 == 0; }
        }

        #endregion

        // Constructor
        public Chunk()
        {
            Tilemaps_bytes = new byte[3][];
            CollisionMap_bytes = new byte[0x20C2];
            this.collision = Collision.Instance;
        }

        #region Methods

        public void Transfer(byte[][] tilemaps, Map areaMap, CollisionMap collisionMap, Point start, Point stop)
        {
            this.Start = start;
            int offset = 0, o = 0, p = 0;
            Size = new Size(stop.X - start.X, stop.Y - start.Y);
            this.Tilemaps_bytes[0] = new byte[(Size.Width * Size.Height) / 128];
            this.Tilemaps_bytes[1] = new byte[(Size.Width * Size.Height) / 128];
            this.Tilemaps_bytes[2] = new byte[(Size.Width * Size.Height) / 256];
            for (int y = start.Y / 16, b = 0; y < stop.Y / 16; y++, b++)
            {
                for (int x = start.X / 16, a = 0; x < stop.X / 16; x++, a++, o++)
                {
                    offset = (x * 2) + (y * 128);
                    this.Tilemaps_bytes[0][o * 2] = tilemaps[0][offset];
                    this.Tilemaps_bytes[0][o * 2 + 1] = tilemaps[0][offset + 1];
                    this.Tilemaps_bytes[1][o * 2] = tilemaps[1][offset];
                    this.Tilemaps_bytes[1][o * 2 + 1] = tilemaps[1][offset + 1];
                    this.Tilemaps_bytes[2][o] = tilemaps[2][y * 64 + x];
                }
            }
            for (int y = start.Y; y < stop.Y; y++)
            {
                for (int x = start.X; x < stop.X; x++)
                {
                    p = collision.PixelTiles[y * 1024 + x] * 2;
                    CollisionMap_bytes[p] = collisionMap.Tilemap_bytes[p];
                    CollisionMap_bytes[p + 1] = collisionMap.Tilemap_bytes[p + 1];
                }
            }
        }
        /// <summary>
        /// Creates an RGB pixel map of the chunk's tilemap data using a specified tileset.
        /// </summary>
        /// <param name="area">The area containing the tilemap properties.</param>
        /// <param name="tileset">The tileset to use.</param>
        /// <returns></returns>
        public int[] GetPixels(Area area, Tileset tileset)
        {
            AreaTilemap tilemap = new AreaTilemap(area, tileset, this);
            int[] pixels = tilemap.Pixels;
            int[] temp = new int[Size.Width * Size.Height];
            for (int y = 0; y < Size.Height; y++)
            {
                for (int x = 0; x < Size.Width; x++)
                    temp[y * Size.Width + x] = pixels[y * 1024 + x];
            }
            return temp;
        }

        #endregion
    }
}
