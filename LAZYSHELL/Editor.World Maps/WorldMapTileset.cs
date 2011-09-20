using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace LAZYSHELL
{
    [Serializable()]
    public class WorldMapTileSet
    {
        [NonSerialized()]
                private WorldMap worldMap;
        private PaletteSet palettes;
        private byte[] graphics; public byte[] Graphics { get { return graphics; } set { graphics = value; } }
        private byte[] tileSet; public byte[] TileSet { get { return tileSet; } set { tileSet = value; } }
        private Tile16x16[] tileSetLayer; public Tile16x16[] TileSetLayer { get { return tileSetLayer; } }

        public WorldMapTileSet(WorldMap worldMap, PaletteSet palettes)
        {
            this.worldMap = worldMap;
            this.palettes = palettes;

            graphics = Model.WorldMapGraphics;
            tileSet = Model.WorldMapTileSets[worldMap.Tileset];

            tileSetLayer = new Tile16x16[16 * 16];
            for (int i = 0; i < tileSetLayer.Length; i++)
                tileSetLayer[i] = new Tile16x16(i);

            DrawTileset(tileSet, tileSetLayer);
        }
        public void RedrawTileset()
        {
            DrawTileset(tileSet, tileSetLayer);
        }
        public void DrawTileset(byte[] src, Tile16x16[] dst)
        {
            byte temp;
            ushort tile;
            Tile8x8 source;
            int offset = 0;

            for (int i = 0; i < dst.Length; i++)
            {
                for (int z = 0; z < 2; z++)
                {
                    tile = (ushort)(Bits.GetShort(src, offset) & 0x03FF); offset++;
                    temp = src[offset]; offset++;
                    source = Do.DrawTile8x8(tile, temp, graphics, palettes.Palettes, 0x20);
                    dst[i].Subtiles[z] = source;
                }
                offset += 60; // jump forward in buffer to grab correct 8x8 tiles
                for (int a = 2; a < 4; a++)
                {
                    tile = (ushort)(Bits.GetShort(src, offset) & 0x03FF); offset++;
                    temp = src[offset]; offset++;
                    source = Do.DrawTile8x8(tile, temp, graphics, palettes.Palettes, 0x20);
                    dst[i].Subtiles[a] = source;
                }
                if ((i - 15) % 16 == 0)
                    offset += 64;
                offset -= 64; // jump back in buffer so that we can start the next 16x16 tile
            }
        }
        public void DrawTileset(Tile16x16[] src, byte[] dst)
        {
            ushort tile;
            Tile8x8 source;
            int offset = 0;
            for (int i = 0; i < src.Length; i++)
            {
                for (int z = 0; z < 2; z++)
                {
                    source = src[i].Subtiles[z];
                    tile = (ushort)source.TileIndex;
                    Bits.SetShort(dst, offset, tile); offset++;
                    dst[offset] |= (byte)(source.PaletteIndex << 2);
                    Bits.SetBit(dst, offset, 5, source.PriorityOne);
                    Bits.SetBit(dst, offset, 6, source.Mirror);
                    Bits.SetBit(dst, offset, 7, source.Invert); offset++;
                }
                offset += 60; // jump forward in buffer to grab correct 8x8 tiles
                for (int a = 2; a < 4; a++)
                {
                    source = src[i].Subtiles[a];
                    tile = (ushort)source.TileIndex;
                    Bits.SetShort(dst, offset, tile); offset++;
                    dst[offset] |= (byte)(source.PaletteIndex << 2);
                    Bits.SetBit(dst, offset, 5, source.PriorityOne);
                    Bits.SetBit(dst, offset, 6, source.Mirror);
                    Bits.SetBit(dst, offset, 7, source.Invert); offset++;
                }
                if ((i - 15) % 16 == 0)
                    offset += 64;
                offset -= 64; // jump back in buffer so that we can start the next 16x16 tile
            }
        }
        public void AssembleIntoModel(int width, int height)
        {
            int offset = 0;
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Tile16x16 tile = tileSetLayer[y * width + x];
                    for (int s = 0; s < 4; s++)
                    {
                        offset = y * (width * 2 * 2 * 2) + (x * 2 * 2);
                        offset += (s % 2) * 2;
                        offset += (s / 2) * (width * 2 * 2);
                        Tile8x8 subtile = tile.Subtiles[s];
                        if (subtile == null) continue;
                        Bits.SetShort(tileSet, offset, (ushort)subtile.TileIndex);
                        tileSet[offset + 1] |= (byte)(subtile.PaletteIndex << 2);
                        Bits.SetBit(tileSet, offset + 1, 5, subtile.PriorityOne);
                        Bits.SetBit(tileSet, offset + 1, 6, subtile.Mirror);
                        Bits.SetBit(tileSet, offset + 1, 7, subtile.Invert);
                    }
                }
            }
        }
    }
}
