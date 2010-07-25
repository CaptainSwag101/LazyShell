using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace LAZYSHELL
{
    public class DialogueTileset
    {
        private Model model;
        private byte[] graphicSet;
        private PaletteSet paletteSet;
        private Tile16x16[] tilesetLayer; public Tile16x16[] TilesetLayer { get { return tilesetLayer; } }

        public DialogueTileset(Model model, PaletteSet paletteSet)
        {
            this.model = model;
            this.graphicSet = model.DialogueGraphics;
            this.paletteSet = paletteSet;

            tilesetLayer = new Tile16x16[16 * 4];
            for (int i = 0; i < tilesetLayer.Length; i++)
                tilesetLayer[i] = new Tile16x16(i);
            DrawTileset(tilesetLayer);
        }
        public void DrawTileset(Tile16x16[] tilesetLayer)
        {
            byte temp, tile;
            Tile8x8 source;
            for (int y = 0; y < 4; y++)
            {
                for (int x = 0; x < 4; x++)
                {
                    for (int z = 0; z < 4; z++)
                    {
                        temp = 0x04;    // for palette index 1
                        tile = (byte)(y * 16 + (x * 2) + (z % 2));
                        tile += z >= 2 ? (byte)8 : (byte)0;
                        source = Do.DrawTile8x8(tile, temp, graphicSet, paletteSet.Palettes, 0x20);
                        tilesetLayer[y * 16 + x].Subtiles[z] = source;
                        tilesetLayer[y * 16 + x + 8].Subtiles[z] = source;

                        temp = 0x44;    // for palette index 1
                        tile ^= 7;
                        source = Do.DrawTile8x8(tile, temp, graphicSet, paletteSet.Palettes, 0x20);
                        tilesetLayer[y * 16 + x + 4].Subtiles[z] = source;
                        tilesetLayer[y * 16 + x + 12].Subtiles[z] = source;
                    }
                }
            }
        }
        private void AssembleIntoModel()
        {
        }
    }
}
