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
        private int[] palette;
        private Tile16x16[] tilesetLayer; public Tile16x16[] TilesetLayer { get { return tilesetLayer; } }

        public DialogueTileset(Model model, int[] palette)
        {
            this.model = model;
            this.graphicSet = model.DialogueGraphics;
            this.palette = palette;

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
                        temp = 0;
                        tile = (byte)(y * 16 + (x * 2) + (z % 2));
                        tile += z >= 2 ? (byte)8 : (byte)0;
                        source = Draw4bppTile8x8(tile, temp);
                        tilesetLayer[y * 16 + x].SetSubtile(source, z);
                        tilesetLayer[y * 16 + x + 8].SetSubtile(source, z);

                        temp = 0x40;
                        tile ^= 7;
                        source = Draw4bppTile8x8(tile, temp);
                        tilesetLayer[y * 16 + x + 4].SetSubtile(source, z);
                        tilesetLayer[y * 16 + x + 12].SetSubtile(source, z);
                    }
                }
            }
        }
        private Tile8x8 Draw4bppTile8x8(byte tile, byte temp)
        {
            byte graphicSetIndex, paletteSetIndex;
            bool mirrored, inverted, priorityOne;
            bool twobpp = false;

            inverted = (temp & 0x80) == 0x80 ? true : false;
            mirrored = (temp & 0x40) == 0x40 ? true : false;
            priorityOne = (temp & 0x20) == 0x20 ? true : false;

            temp &= 0x1F;
            paletteSetIndex = (byte)(temp >> 2);
            graphicSetIndex = (byte)(temp & 0x03);

            int tileDataOffset = tile * 0x20;

            if (tileDataOffset >= graphicSet.Length)
                tileDataOffset = 0;

            Tile8x8 tempTile = new Tile8x8(tile, graphicSet, tileDataOffset, palette, mirrored, inverted, priorityOne, twobpp);
            tempTile.GfxSetIndex = graphicSetIndex;
            tempTile.PaletteSetIndex = paletteSetIndex;
            return tempTile;
        }
        public int[] GetTilesetPixelArray()
        {
            Tile16x16[] tiles = tilesetLayer;
            int[] pixels = new int[256 * 64];

            for (int y = 0; y < 4; y++)
            {
                for (int x = 0; x < 16; x++)
                {
                    CopyOverTile8x8(tiles[y * 16 + x].GetSubtile(0), pixels, 256, x * 16, y * 16);
                    CopyOverTile8x8(tiles[y * 16 + x].GetSubtile(1), pixels, 256, x * 16 + 8, y * 16);
                    CopyOverTile8x8(tiles[y * 16 + x].GetSubtile(2), pixels, 256, x * 16, y * 16 + 8);
                    CopyOverTile8x8(tiles[y * 16 + x].GetSubtile(3), pixels, 256, x * 16 + 8, y * 16 + 8);
                }
            }
            return pixels;
        }
        private void CopyOverTile8x8(Tile8x8 source, int[] dest, int destinationWidth, int x, int y)
        {
            int[] src;
            if (source != null) src = source.Pixels;
            else src = new int[8 * 8];
            int counter = 0;
            for (int i = 0; i < 64; i++)
            {
                dest[(int)((y * destinationWidth) + x + counter)] = src[i];
                counter++;
                if (counter % 8 == 0)
                {
                    y++;
                    counter = 0;
                }
            }
        }
    }
}
