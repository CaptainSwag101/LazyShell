using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LazyShell.Menus
{
    class Tileset
    {
        #region Variables

        public PaletteSet PaletteSet { get; set; }
        public byte[] Tileset_bytes { get; set; }
        public Tile[] Tileset_tiles { get; set; }
        public byte[] Graphics { get; set; }

        #endregion

        // Constructor
        public Tileset(PaletteSet paletteSet, byte[] tileset_bytes, byte[] graphicSet)
        {
            this.PaletteSet = paletteSet;
            this.Tileset_bytes = tileset_bytes;
            this.Graphics = graphicSet;

            BuildTilesetTiles();
            ParseTileset(tileset_bytes, Tileset_tiles);
        }

        #region Methods

        private void BuildTilesetTiles()
        {
            Tileset_tiles = new Tile[16 * 16];
            for (int i = 0; i < Tileset_tiles.Length; i++)
                Tileset_tiles[i] = new Tile(i);
        }

        // Drawing functions
        public void ParseTileset(byte[] tileset_bytes, Tile[] tileset_tiles)
        {
            byte temp, tile;
            Subtile source;
            int offset = 0;
            for (int i = 0; i < tileset_tiles.Length; i++)
            {
                for (int z = 0; z < 2; z++)
                {
                    tile = tileset_bytes[offset++]; // GFX set?
                    temp = tileset_bytes[offset++]; // Palette Set?
                    source = Do.DrawSubtile(tile, temp, Graphics, PaletteSet.Palettes, 0x20);
                    tileset_tiles[i].Subtiles[z] = source;
                }
                offset += 60; // jump forward in buffer to grab correct 8x8 tiles
                for (int a = 2; a < 4; a++)
                {
                    tile = tileset_bytes[offset++];
                    temp = tileset_bytes[offset++];
                    source = Do.DrawSubtile(tile, temp, Graphics, PaletteSet.Palettes, 0x20);
                    tileset_tiles[i].Subtiles[a] = source; ;
                }
                if ((i - 15) % 16 == 0)
                    offset += 64;
                offset -= 64; // jump back in buffer so that we can start the next 16x16 tile
            }
        }
        public void RedrawTileset()
        {
            ParseTileset(Tileset_bytes, Tileset_tiles);
        }

        // accessor functions
        public int GetTileNumber(int x, int y)
        {
            return Tileset_tiles[x + y * 16].Index;
        }

        // Universal functions
        public void Clear(int count)
        {
            Model.Modify_MenuTileset = true;
            RedrawTileset();
        }

        #endregion
    }
}
