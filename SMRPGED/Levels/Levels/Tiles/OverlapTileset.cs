using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace SMRPGED
{
    class OverlapTileset
    {
        private Model model;
        private Tile32x32[] overlapTiles; public Tile32x32[] OverlapTiles { get { return overlapTiles; } }
        public byte[] graphicSet;

        public OverlapTileset(Model model)
        {
            this.model = model; // grab the model

            overlapTiles = new Tile32x32[104];

            for (int i = 0; i < overlapTiles.Length; i++)
                overlapTiles[i] = new Tile32x32(i);

            DrawOverlapsGraphicSet();
            DrawOverlapsTileSet(overlapTiles);
        }

        public void DrawOverlapsGraphicSet()
        {
            graphicSet = new byte[128 * 96];

            int offset = 0x1DE000;
            int loc = 0;

            for (int o = 0; o < 96; o++)   // for all 104 overlap tiles
            {
                offset = (o * 0x20) + 0x1DE000;
                loc = (o / 8) * 0x400;
                loc += (o % 8) * 0x40;

                int a = 0, b = 0;
                for (int i = 0; i < 8; i++, a++, b += 2)
                {
                    graphicSet[b + loc] = model.Data[offset + a];
                    graphicSet[b + 1 + loc] = model.Data[offset + a];
                    graphicSet[b + 0x10 + loc] = model.Data[offset + a];
                    graphicSet[b + 0x11 + loc] = model.Data[offset + a];
                }
                for (int i = 0; i < 8; i++, a++, b += 2)
                {
                    graphicSet[b + 0x10 + loc] = model.Data[offset + a];
                    graphicSet[b + 0x11 + loc] = model.Data[offset + a];
                    graphicSet[b + 0x20 + loc] = model.Data[offset + a];
                    graphicSet[b + 0x21 + loc] = model.Data[offset + a];
                }
                for (int i = 0; i < 8; i++, a++, b += 2)
                {
                    graphicSet[b + 0x1E0 + loc] = model.Data[offset + a];
                    graphicSet[b + 0x1E1 + loc] = model.Data[offset + a];
                    graphicSet[b + 0x1F0 + loc] = model.Data[offset + a];
                    graphicSet[b + 0x1F1 + loc] = model.Data[offset + a];
                }
                for (int i = 0; i < 8; i++, a++, b += 2)
                {
                    graphicSet[b + 0x1F0 + loc] = model.Data[offset + a];
                    graphicSet[b + 0x1F1 + loc] = model.Data[offset + a];
                    graphicSet[b + 0x200 + loc] = model.Data[offset + a];
                    graphicSet[b + 0x201 + loc] = model.Data[offset + a];
                }
            }
        }
        public void DrawOverlapsTileSet(Tile32x32[] tileset)
        {
            int offset = 0x1CEA00;
            int index = 0, loc = 0, place = 0;
            int[] palette = new int[16];
            for (int i = 0; i < palette.Length; i++)
                palette[i] = Color.Black.ToArgb();
            Tile8x8 source;
            Tile16x16[] subtiles;

            for (int i = 0; i < 104; i++)   // for all 104 overlap tiles
            {
                subtiles = new Tile16x16[4];
                for (int o = 0; o < subtiles.Length; o++)
                    subtiles[o] = new Tile16x16(o);

                for (int a = 0; a < 4; a++) // the four 16x16 tiles in an overlap tile
                {
                    index = model.Data[i * 5 + a + offset];
                    place = (i / 8) * 32;
                    place += ((i % 8) * 2) + (a % 2) + ((a / 2) * 16);

                    subtiles[a].Mirrored = BitManager.GetBit(model.Data, i * 5 + 4 + offset, ((a * 2) + 1) ^ 7);
                    subtiles[a].Inverted = BitManager.GetBit(model.Data, i * 5 + 4 + offset, (a * 2) ^ 7);

                    if (index != 0)
                    {
                        index--;
                        loc = index % 8 * 0x40;
                        loc += index / 8 * 0x400;

                        source = new Tile8x8(index, graphicSet, loc, palette, false, false, false, false);
                        subtiles[a].SetSubtile(source, 0);
                        source = new Tile8x8(index, graphicSet, loc + 0x20, palette, false, false, false, false);
                        subtiles[a].SetSubtile(source, 1);
                        source = new Tile8x8(index, graphicSet, loc + 0x200, palette, false, false, false, false);
                        subtiles[a].SetSubtile(source, 2);
                        source = new Tile8x8(index, graphicSet, loc + 0x220, palette, false, false, false, false);
                        subtiles[a].SetSubtile(source, 3);
                    }
                    else
                    {
                        source = new Tile8x8(index, new byte[0x20], 0, palette, false, false, false, false);
                        subtiles[a].SetSubtile(source, 0);
                        subtiles[a].SetSubtile(source, 1);
                        subtiles[a].SetSubtile(source, 2);
                        subtiles[a].SetSubtile(source, 3);
                    }
                    tileset[i].SetSubtile(subtiles[a], a);
                }
            }
        }
        public int[] GetTilesetPixelArray(Tile32x32[] tiles)
        {
            int[] pixels = new int[256 * 416];

            for (int y = 0; y < tiles.Length / 8; y++)
            {
                for (int x = 0; x < 8; x++)
                {
                    CopyOverTile32x32(tiles[y * 8 + x], pixels, 256, x, y);
                }
            }
            return pixels;
        }
        public void CopyOverTile32x32(Tile32x32 source, int[] dest, int destinationWidth, int x, int y)
        {
            x *= 32; y *= 32;

            CopyOverTile16x16(source.GetSubtile(0).Pixels(), dest, destinationWidth, x, y);
            CopyOverTile16x16(source.GetSubtile(1).Pixels(), dest, destinationWidth, x + 16, y);
            CopyOverTile16x16(source.GetSubtile(2).Pixels(), dest, destinationWidth, x, y + 16);
            CopyOverTile16x16(source.GetSubtile(3).Pixels(), dest, destinationWidth, x + 16, y + 16);
        }
        public void CopyOverTile16x16(int[] src, int[] dest, int destinationWidth, int x, int y)
        {
            int counter = 0;
            for (int i = 0; i < 256; i++)
            {
                dest[y * destinationWidth + x + counter] = src[i];

                counter++;
                if (counter % 16 == 0)
                {
                    y++;
                    counter = 0;
                }
            }
        }
    }
}
