using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace LAZYSHELL
{
    [Serializable()]
    public class DialogueTileset
    {
        [NonSerialized()]
                private byte[] graphicSet;
        private PaletteSet paletteSet;
        private Tile[] tilesetLayer; public Tile[] TilesetLayer { get { return tilesetLayer; } }

        public DialogueTileset(PaletteSet paletteSet)
        {
            this.graphicSet = Model.DialogueGraphics;
            this.paletteSet = paletteSet;

            tilesetLayer = new Tile[16 * 4];
            for (int i = 0; i < tilesetLayer.Length; i++)
                tilesetLayer[i] = new Tile(i);
            DrawTileset(tilesetLayer);
        }
        public void DrawTileset(Tile[] tilesetLayer)
        {
            byte temp, tile;
            Subtile source;
            for (int y = 0; y < 4; y++)
            {
                for (int x = 0; x < 4; x++)
                {
                    for (int z = 0; z < 4; z++)
                    {
                        temp = 0x04;    // for palette index 1
                        tile = (byte)(y * 16 + (x * 2) + (z % 2));
                        tile += z >= 2 ? (byte)8 : (byte)0;
                        source = Do.DrawSubtile(tile, temp, graphicSet, paletteSet.Palettes, 0x20);
                        tilesetLayer[y * 16 + x].Subtiles[z] = source;
                        tilesetLayer[y * 16 + x + 8].Subtiles[z] = source;

                        temp = 0x44;    // for palette index 1
                        tile ^= 7;
                        source = Do.DrawSubtile(tile, temp, graphicSet, paletteSet.Palettes, 0x20);
                        tilesetLayer[y * 16 + x + 4].Subtiles[z] = source;
                        tilesetLayer[y * 16 + x + 12].Subtiles[z] = source;
                    }
                }
            }
        }
        private void Assemble()
        {
        }
    }
}
