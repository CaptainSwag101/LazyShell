using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace LAZYSHELL.Effects
{
    [Serializable()]
    public class Tileset
    {
        #region Variables

        // Parent animation
        private Animation animation;

        // Properties
        public int[] Palette { get; set; }
        public byte[] Graphics { get; set; }
        public Tile[] Tiles { get; set; }
        
        #endregion

        // Constructor
        public Tileset(Animation animation, int index)
        {
            this.animation = animation;
            this.Graphics = animation.GraphicSet;
            this.Palette = animation.PaletteSet.Palettes[index];

            // Build tileset tiles
            InitializeTilesetTiles();
            ParseTileset(Tiles, animation.Tileset_bytes);
        }

        #region Methods

        private void InitializeTilesetTiles()
        {
            Tiles = new Tile[16 * 16];
            for (int i = 0; i < Tiles.Length; i++)
                Tiles[i] = new Tile(i);
        }
        /// <summary>
        /// Refreshes the tileset's Tile array using the updated data from an animation.
        /// </summary>
        /// <param name="animation">The animation containing the updated data to analyze.</param>
        /// <param name="length">The length of the tileset's binary data.</param>
        public void RefreshTileset(Animation animation, int length)
        {
            this.Graphics = animation.GraphicSet;
            for (int i = 0; i < length / 8; i++)
            {
                for (int z = 0; z < 4; z++)
                {
                    Subtile source;
                    if (animation.Codec == 1)
                        source = Do.DrawSubtile((byte)Tiles[i].Subtiles[z].Index, 0, Graphics, Palette, 0x10);
                    else
                        source = Do.DrawSubtile((byte)Tiles[i].Subtiles[z].Index, 0, Graphics, Palette, 0x20);
                    Tiles[i].Subtiles[z] = source;
                }
            }
        }
        /// <summary>
        /// Converts a tileset's binary data to a manageable array of Tile instances.
        /// </summary>
        /// <param name="dst"></param>
        /// <param name="src"></param>
        public void ParseTileset(Tile[] dst, byte[] src)
        {
            byte temp;
            ushort tile;
            Subtile source;
            int offset = 0;
            int i = 0;
            for (; i < dst.Length; i++)
            {
                if (i > 0 && i % 8 == 0) offset += 32;
                if (Bits.GetShort(src, offset) == 0xFFFF) break;
                else
                {
                    for (int z = 0; z < 2; z++)
                    {
                        if (offset >= src.Length - 1)
                            return;
                        tile = (ushort)(Bits.GetShort(src, offset++) & 0x03FF);
                        temp = src[offset++];
                        if (animation.Codec == 1)
                            source = Do.DrawSubtile(tile, temp, Graphics, Palette, 0x10);
                        else
                            source = Do.DrawSubtile(tile, temp, Graphics, Palette, 0x20);
                        dst[i].Subtiles[z] = source;
                    }
                    offset += 28; // jump forward in buffer to grab correct 8x8 tiles
                    for (int a = 2; a < 4; a++)
                    {
                        if (offset >= src.Length - 1)
                            return;
                        tile = (ushort)(Bits.GetShort(src, offset++) & 0x03FF);
                        temp = src[offset++];
                        if (animation.Codec == 1)
                            source = Do.DrawSubtile(tile, temp, Graphics, Palette, 0x10);
                        else
                            source = Do.DrawSubtile(tile, temp, Graphics, Palette, 0x20);
                        dst[i].Subtiles[a] = source;
                    }
                    offset -= 32; // jump back in buffer so that we can start the next 16x16 tile
                }
            }
            for (; i < 64; i++) // fill up the rest with empty tiles
            {
                for (int z = 0; z < 4; z++)
                {
                    if (animation.Codec == 1)
                        source = Do.DrawSubtile(0, 0, Graphics, Palette, 0x10);
                    else
                        source = Do.DrawSubtile(0, 0, Graphics, Palette, 0x20);
                    dst[i].Subtiles[z] = source;
                }
            }
        }
        /// <summary>
        /// Converts a tileset's Tile array to binary format.
        /// </summary>
        /// <param name="dst">The byte array to store the converted binary data to.</param>
        /// <param name="src">The source Tile array to convert to binary.</param>
        public void ParseTileset(byte[] dst, Tile[] src)
        {
            ushort tile;
            Subtile source;
            int offset = 0;
            int i = 0;
            for (; i < src.Length; i++)
            {
                if (i > 0 && i % 8 == 0) offset += 32;
                for (int z = 0; z < 2; z++)
                {
                    source = src[i].Subtiles[z];
                    tile = (ushort)source.Index;
                    Bits.SetShort(dst, offset, tile); offset += 2;
                }
                offset += 28; // jump forward in buffer to grab correct 8x8 tiles
                for (int a = 2; a < 4; a++)
                {
                    source = src[i].Subtiles[a];
                    tile = (ushort)source.Index;
                    Bits.SetShort(dst, offset, tile); offset += 2;
                }
                offset -= 32; // jump back in buffer so that we can start the next 16x16 tile
            }
        }
        
        #endregion
    }
}
