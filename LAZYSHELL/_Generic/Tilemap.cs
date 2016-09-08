using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace LazyShell
{
    /// <summary>
    /// Base class for creating an instance of a tilemap.
    /// </summary>
    [Serializable()]
    public abstract class Tilemap
    {
        /// <summary>
        /// The width, in pixels, of the tilemap.
        /// </summary>
        public abstract int Width_p { get; set; }
        /// <summary>
        /// The height, in pixels, of the tilemap.
        /// </summary>
        public abstract int Height_p { get; set; }
        /// <summary>
        /// The tilemap's RGB pixels, including all active layers in the tilemap.
        /// </summary>
        public abstract int[] Pixels { get; set; }

        /// <summary>
        /// The tileset used to build the tilemap's tiles.
        /// </summary>
        public abstract Tileset Tileset { get; set; }

        /// <summary>
        /// The tiles in the tilemap, containing all of the properties associated with the Tile class.
        /// </summary>
        public abstract Tile[] Tilemap_tiles { get; set; }
        /// <summary>
        /// The tiles of each layer in the tilemap, containing all of the properties associated with the Tile class.
        /// </summary>
        public abstract Tile[][] Tilemaps_tiles { get; set; }
        /// <summary>
        /// The tilemap's raw, unclassified byte data.
        /// </summary>
        public abstract byte[] Tilemap_bytes { get; set; }
        /// <summary>
        /// The tilemap's raw, unclassified byte data, arranged into separate arrays for each layer in the tilemap.
        /// </summary>
        public abstract byte[][] Tilemaps_bytes { get; set; }

        /// <summary>
        /// The bitmap generated from the tilemap's tile data.
        /// </summary>
        public abstract Bitmap Image { get; set; }

        public abstract void SetTileNum();
        /// <summary>
        /// Sets the tile number in the tilemap's raw byte data, based on a set of 
        /// coordinates (in 16x16 tile units) in the final drawing area.
        /// </summary>
        /// <param name="tilenum">The new tile number.</param>
        /// <param name="layer">The layer containing the tile to modify in the raw byte data.</param>
        /// <param name="x">The X coordinate, in 16x16 tile units, of the tile to modify.</param>
        /// <param name="y">The Y coordinate, in 16x16 tile units, of the tile to modify.</param>
        public abstract void SetTileNum(int tilenum, int layer, int x, int y);
        public abstract int GetTileNum(int index);
        public abstract int GetTileNum(int layer, int x, int y);
        public abstract int GetTileNum(int layer, int x, int y, bool ignoretransparent);
        public abstract void RedrawTilemaps();
        public abstract int[] GetPixels(int layer, Point location, Size size);
        public abstract int[] GetPixels(Point location, Size size);
        public abstract int[] GetPriority1Pixels();
        public abstract void ParseTilemap();
        public abstract int GetPixelLayer(int x, int y);
    }
}
