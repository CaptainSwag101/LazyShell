using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace LazyShell.Dialogues
{
    [Serializable()]
    public class Tileset
    {
        #region Variables

        // Elements
        [NonSerialized()]
        private PaletteSet paletteSet;
        public byte[] Graphics { get; set; }
        public byte[] Tileset_bytes { get; set; }
        public Tile[] Tileset_tiles { get; set; }

        #endregion

        // Constructor
        public Tileset()
        {
            InitializeTilesetPaletteSet();
            InitializeTilesetGraphics();
            InitializeTilesetBytes();
            InitializeTilesetTiles();
            BuildTilesetTiles(Tileset_bytes, Tileset_tiles);
        }

        #region Methods

        // Initialization
        private void InitializeTilesetPaletteSet()
        {
            this.paletteSet = Fonts.Model.Palette_Dialogue;
        }
        private void InitializeTilesetGraphics()
        {
            this.Graphics = Model.Graphics;
        }
        private void InitializeTilesetBytes()
        {
            this.Tileset_bytes = Model.Tileset_bytes;
        }
        private void InitializeTilesetTiles()
        {
            this.Tileset_tiles = new Tile[16 * 2];
            for (int i = 0; i < Tileset_tiles.Length; i++)
                Tileset_tiles[i] = new Tile(i);
        }

        // Write to model
        private void WriteToModel()
        {
        }

        // Tileset creation
        public void BuildTilesetTiles(byte[] src, Tile[] dst)
        {
            int offset = 0;
            for (int i = 0; i < dst.Length; i++)
            {
                for (int z = 0; z < 2; z++)
                {
                    ushort tile = (ushort)(Bits.GetShort(src, offset) & 0x03FF); offset++;
                    byte temp = src[offset++];
                    var source = Do.DrawSubtile(tile, temp, Graphics, paletteSet.Palettes, 0x20);
                    dst[i].Subtiles[z] = source;
                }
                offset += 60; // jump forward in buffer to grab correct 8x8 tiles
                for (int a = 2; a < 4; a++)
                {
                    ushort tile = (ushort)(Bits.GetShort(src, offset) & 0x03FF); offset++;
                    byte temp = src[offset++];
                    var source = Do.DrawSubtile(tile, temp, Graphics, paletteSet.Palettes, 0x20);
                    dst[i].Subtiles[a] = source;
                }
                if ((i - 15) % 16 == 0)
                    offset += 64;
                offset -= 64; // jump back in buffer so that we can start the next 16x16 tile
            }
        }

        // Tileset modification
        public void ParseTileset(Tile[] src, byte[] dst)
        {
            ushort tile;
            Subtile source;
            int offset = 0;
            for (int i = 0; i < src.Length; i++)
            {
                for (int z = 0; z < 2; z++)
                {
                    source = src[i].Subtiles[z];
                    tile = (ushort)source.Index;
                    Bits.SetShort(dst, offset, tile); offset++;
                    dst[offset] |= (byte)(source.Palette << 2);
                    Bits.SetBit(dst, offset, 5, source.Priority1);
                    Bits.SetBit(dst, offset, 6, source.Mirror);
                    Bits.SetBit(dst, offset, 7, source.Invert); offset++;
                }
                offset += 60; // jump forward in buffer to grab correct 8x8 tiles
                for (int a = 2; a < 4; a++)
                {
                    source = src[i].Subtiles[a];
                    tile = (ushort)source.Index;
                    Bits.SetShort(dst, offset, tile); offset++;
                    dst[offset] |= (byte)(source.Palette << 2);
                    Bits.SetBit(dst, offset, 5, source.Priority1);
                    Bits.SetBit(dst, offset, 6, source.Mirror);
                    Bits.SetBit(dst, offset, 7, source.Invert); offset++;
                }
                if ((i - 15) % 16 == 0)
                    offset += 64;
                offset -= 64; // jump back in buffer so that we can start the next 16x16 tile
            }
        }
        /// <summary>
        /// Reinitializes the tileset's source data and rebuilds the tile collections.
        /// </summary>
        public void RedrawTileset()
        {
            InitializeTilesetBytes();
            InitializeTilesetTiles();
            BuildTilesetTiles(Tileset_bytes, Tileset_tiles);
        }

        #endregion
    }
}
