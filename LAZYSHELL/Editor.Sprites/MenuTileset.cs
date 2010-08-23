using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LAZYSHELL
{
    class MenuTileset
    {
        private Model model = State.Instance.Model;
        public int[] palette;

        private byte[] tileSet; public byte[] TileSet { get { return tileSet; } set { tileSet = value; } }
        private byte[] graphicSet; public byte[] GraphicSet { get { return graphicSet; } set { graphicSet = value; } }

        Tile16x16[] tileset; public Tile16x16[] Tileset { get { return tileset; } }

        public MenuTileset(int[] palette)
        {
            this.palette = palette; // grab the current Palette Set

            // Create our layers for the tilesets (256x512)
            tileset = new Tile16x16[16 * 16];

            for (int i = 0; i < tileset.Length; i++)
                tileset[i] = new Tile16x16(i);
            DecompressTileSetData(); // Decompress our required data

            DrawTileset(tileSet, tileset);
        }
        private void DecompressTileSetData()
        {
            // Decompress data at offsets
            tileSet = model.MenuTileset;

            // Decompress graphic sets
            graphicSet = model.MenuGraphicSet;
        }

        public void DrawTileset(byte[] tileset, Tile16x16[] tileSet)
        {
            byte temp, tile;
            Tile8x8 source;
            int offset = 0;

            for (int i = 0; i < tileSet.Length; i++)
            {
                for (int z = 0; z < 2; z++)
                {
                    tile = tileset[offset]; offset++; // GFX set?
                    temp = tileset[offset]; offset++; // Palette Set?
                    source = Do.DrawTile8x8(tile, temp, graphicSet, palette, 0x20);
                    tileSet[i].Subtiles[z] = source;
                }
                offset += 60; // jump forward in buffer to grab correct 8x8 tiles
                for (int a = 2; a < 4; a++)
                {
                    tile = tileset[offset]; offset++;
                    temp = tileset[offset]; offset++;
                    source = Do.DrawTile8x8(tile, temp, graphicSet, palette, 0x20);
                    tileSet[i].Subtiles[a] = source;;
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
            model.EditMenuTileSet = true;
            RedrawTileset();
        }
    }
}
