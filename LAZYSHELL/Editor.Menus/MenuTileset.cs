using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LAZYSHELL
{
    class MenuTileset
    {
        public PaletteSet paletteSet;
        private byte[] tileSet; public byte[] TileSet { get { return tileSet; } set { tileSet = value; } }
        private byte[] graphicSet; public byte[] GraphicSet { get { return graphicSet; } set { graphicSet = value; } }

        Tile[] tileset; public Tile[] Tileset { get { return tileset; } }

        public MenuTileset(PaletteSet paletteSet, byte[] tileSet, byte[] graphicSet)
        {
            this.paletteSet = paletteSet; // grab the current Palette Set

            // Create our layers for the tilesets (256x512)
            tileset = new Tile[16 * 16];

            for (int i = 0; i < tileset.Length; i++)
                tileset[i] = new Tile(i);
            this.tileSet = tileSet;
            this.graphicSet = graphicSet;

            DrawTileset(tileSet, tileset);
        }

        public void DrawTileset(byte[] tileset, Tile[] tileSet)
        {
            byte temp, tile;
            Subtile source;
            int offset = 0;

            for (int i = 0; i < tileSet.Length; i++)
            {
                for (int z = 0; z < 2; z++)
                {
                    tile = tileset[offset]; offset++; // GFX set?
                    temp = tileset[offset]; offset++; // Palette Set?
                    source = Do.DrawSubtile(tile, temp, graphicSet, paletteSet.Palettes, 0x20);
                    tileSet[i].Subtiles[z] = source;
                }
                offset += 60; // jump forward in buffer to grab correct 8x8 tiles
                for (int a = 2; a < 4; a++)
                {
                    tile = tileset[offset]; offset++;
                    temp = tileset[offset]; offset++;
                    source = Do.DrawSubtile(tile, temp, graphicSet, paletteSet.Palettes, 0x20);
                    tileSet[i].Subtiles[a] = source; ;
                }
                if ((i - 15) % 16 == 0)
                    offset += 64;
                offset -= 64; // jump back in buffer so that we can start the next 16x16 tile
            }
        }
        public void RedrawTileset()
        {
            DrawTileset(tileSet, tileset);
        }
        public int GetTileNumber(int x, int y)
        {
            return tileset[x + y * 16].TileIndex;
        }
        public void Clear(int count)
        {
            Model.EditMenuTileSet = true;
            RedrawTileset();
        }
    }
}
