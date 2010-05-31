using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace LAZYSHELL
{
    public class WorldMapTileset
    {
        private Model model;
        private WorldMap worldMap;
        private WorldMapPalettes worldMapPalettes;
        private byte[] graphicSet;
        private byte[] tileSet; public byte[] TileSet { get { return tileSet; } set { tileSet = value; } }
        private Tile16x16[] tilesetLayer; public Tile16x16[] TilesetLayer { get { return tilesetLayer; } }

        public WorldMapTileset(WorldMap worldMap, WorldMapPalettes worldMapPalettes, Model model)
        {
            this.model = model;
            this.worldMap = worldMap;
            this.worldMapPalettes = worldMapPalettes;

            graphicSet = model.WorldMapGraphics;
            tileSet = model.WorldMapTileSets[worldMap.Tileset];

            tilesetLayer = new Tile16x16[16 * 16];
            for (int i = 0; i < tilesetLayer.Length; i++)
                tilesetLayer[i] = new Tile16x16(i);

            DrawTileset(tileSet, tilesetLayer);
        }
        public void RedrawTileset()
        {
            DrawTileset(tileSet, tilesetLayer);
        }
        public void DrawTileset(byte[] tileset, Tile16x16[] tilesetLayer)
        {
            byte temp, tile;
            Tile8x8 source;
            int offset = 0;

            for (int i = 0; i < tilesetLayer.Length; i++)
            {
                for (int z = 0; z < 2; z++)
                {
                    tile = BitManager.GetByte(tileset, offset); offset++;
                    temp = BitManager.GetByte(tileset, offset); offset++;
                    source = Draw4bppTile8x8(tile, temp);
                    tilesetLayer[i].SetSubtile(source, z);
                }
                offset += 60; // jump forward in buffer to grab correct 8x8 tiles
                for (int a = 2; a < 4; a++)
                {
                    tile = BitManager.GetByte(tileset, offset); offset++;
                    temp = BitManager.GetByte(tileset, offset); offset++;
                    source = Draw4bppTile8x8(tile, temp);
                    tilesetLayer[i].SetSubtile(source, a);
                }

                if ((i - 15) % 16 == 0)
                    offset += 64;
                offset -= 64; // jump back in buffer so that we can start the next 16x16 tile
            }
        }
        private Tile8x8 Draw4bppTile8x8(byte tile, byte temp)
        {
            byte graphicSetIndex, paletteSetIndex;
            bool mirrored, inverted, priorityOne;
            bool twobpp = false;
            int block;

            inverted = (temp & 0x80) == 0x80 ? true : false;
            mirrored = (temp & 0x40) == 0x40 ? true : false;
            priorityOne = (temp & 0x20) == 0x20 ? true : false;

            temp &= 0x1F;
            paletteSetIndex = (byte)(temp >> 2);
            graphicSetIndex = (byte)(temp & 0x03);

            block = graphicSetIndex * 0x2000;

            int tileDataOffset = tile * 0x20 + block;

            if (tileDataOffset >= graphicSet.Length)
                tileDataOffset = 0;

            Tile8x8 tempTile = new Tile8x8(tile, graphicSet, tileDataOffset, worldMapPalettes.GetWorldMapPalette(paletteSetIndex), mirrored, inverted, priorityOne, twobpp);
            tempTile.GfxSetIndex = graphicSetIndex;
            tempTile.PaletteSetIndex = paletteSetIndex;
            return tempTile;
        }

        public int[] GetTilesetPixelArray()
        {
            Tile16x16[] tiles = tilesetLayer;
            int[] pixels = new int[256 * 256];

            for (int y = 0; y < 16; y++)
            {
                for (int x = 0; x < 16; x++)
                    CopyOverTile16x16(tiles[y * 16 + x], pixels, 256, x, y);
            }
            return pixels;
        }

        private void CopyOverTile16x16(Tile16x16 source, int[] dest, int destinationWidth, int x, int y)
        {
            x *= 16; x += (sbyte)(worldMap.XCoord ^ 0xFF);
            y *= 16; y += (sbyte)(worldMap.YCoord ^ 0xFF);

            CopyOverTile8x8(source.GetSubtile(0), dest, destinationWidth, x, y);
            CopyOverTile8x8(source.GetSubtile(1), dest, destinationWidth, x + 8, y);
            CopyOverTile8x8(source.GetSubtile(2), dest, destinationWidth, x, y + 8);
            CopyOverTile8x8(source.GetSubtile(3), dest, destinationWidth, x + 8, y + 8);
        }

        /*
        * This method fills the 16x16 pixel buf with the correct graphics from the
        * 8x8 tiles, but only if we have all the subtiles
        */
        private void CopyOverTile8x8(Tile8x8 source, int[] dest, int destinationWidth, int x, int y)
        {
            int[] src = source.Pixels;
            int counter = 0;
            for (int i = 0; i < 64; i++)
            {
                if (y < 256 && y >= 0 && x + counter < 256 && x + counter >= 0)
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
