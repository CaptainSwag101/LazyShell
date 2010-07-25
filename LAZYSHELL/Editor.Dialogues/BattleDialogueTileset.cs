using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace LAZYSHELL
{
    public class BattleDialogueTileset
    {
        private Model model;
        private PaletteSet paletteSet;
        private byte[] graphicSet; public byte[] GraphicSet { get { return graphicSet; } set { graphicSet = value; } }
        private byte[] tileSet; public byte[] TileSet { get { return tileSet; } set { tileSet = value; } }
        private Tile16x16[] tilesetLayer; public Tile16x16[] TilesetLayer { get { return tilesetLayer; } }

        public BattleDialogueTileset(Model model, PaletteSet paletteSet)
        {
            this.model = model;
            this.graphicSet = model.DialogueGraphics;
            this.tileSet = model.BattleDialogueTileSet;
            this.paletteSet = paletteSet;

            tilesetLayer = new Tile16x16[16 * 2];
            for (int i = 0; i < tilesetLayer.Length; i++)
                tilesetLayer[i] = new Tile16x16(i);

            DrawTileset(tileSet, tilesetLayer);
        }
        public BattleDialogueTileset(byte[] graphics, byte[] tileSet, PaletteSet paletteSet)
        {
            this.graphicSet = graphics;
            this.tileSet = tileSet;
            this.paletteSet = paletteSet;

            tilesetLayer = new Tile16x16[16 * 2];
            for (int i = 0; i < tilesetLayer.Length; i++)
                tilesetLayer[i] = new Tile16x16(i);

            DrawTileset(tileSet, tilesetLayer);
        }
        public void RedrawTileset()
        {
            DrawTileset(tileSet, tilesetLayer);
        }
        private void DrawTileset(byte[] tileset, Tile16x16[] tilesetLayer)
        {
            byte temp;
            ushort tile;
            Tile8x8 source;
            int offset = 0;

            for (int i = 0; i < tilesetLayer.Length; i++)
            {
                for (int z = 0; z < 2; z++)
                {
                    tile = (ushort)(Bits.GetShort(tileset, offset) & 0x03FF); offset++;
                    temp = tileset[offset]; offset++;
                    source = Do.DrawTile8x8(tile, temp, graphicSet, paletteSet.Palettes, 0x20);
                    tilesetLayer[i].Subtiles[z] = source;
                }
                offset += 60; // jump forward in buffer to grab correct 8x8 tiles
                for (int a = 2; a < 4; a++)
                {
                    tile = (ushort)(Bits.GetShort(tileset, offset) & 0x03FF); offset++;
                    temp = tileset[offset]; offset++;
                    source = Do.DrawTile8x8(tile, temp, graphicSet, paletteSet.Palettes, 0x20);
                    tilesetLayer[i].Subtiles[a] = source;;
                }

                if ((i - 15) % 16 == 0)
                    offset += 64;
                offset -= 64; // jump back in buffer so that we can start the next 16x16 tile
            }
        }
        private void AssembleIntoModel()
        {
        }
    }
}
