using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;

namespace LAZYSHELL
{
    [Serializable()]
    public class TitleTileset
    {
        [NonSerialized()]
                private PaletteSet titlePalettes;
        private byte[] graphics; public byte[] Graphics { get { return graphics; } set { graphics = value; } }
        private byte[] graphicsL3; public byte[] GraphicsL3 { get { return graphicsL3; } set { graphicsL3 = value; } }
        private byte[][] tileSets = new byte[3][]; public byte[][] TileSets { get { return tileSets; } set { tileSets = value; } }
        Tile16x16[][] tileSetLayers = new Tile16x16[3][]; public Tile16x16[][] TileSetLayers { get { return tileSetLayers; } }

        public TitleTileset(PaletteSet titlePalettes)
        {
            this.titlePalettes = titlePalettes;

            // Create our layers for the tilesets (256x512)
            tileSetLayers[0] = new Tile16x16[16 * 32];
            tileSetLayers[1] = new Tile16x16[16 * 32];
            tileSetLayers[2] = new Tile16x16[16 * 6];

            CreateLayers(); // Create inidividual tiles
            DecompressTileSetData(); // Decompress our required data

            DrawTileset(tileSets[0], tileSetLayers[0], graphics);
            DrawTileset(tileSets[1], tileSetLayers[1], graphics);
            DrawTileset(tileSets[2], tileSetLayers[2], graphicsL3);
        }

        private void CreateLayers()
        {
            int i;
            for (i = 0; i < tileSetLayers[0].Length; i++)
                tileSetLayers[0][i] = new Tile16x16(i);
            for (i = 0; i < tileSetLayers[1].Length; i++)
                tileSetLayers[1][i] = new Tile16x16(i);
            for (i = 0; i < tileSetLayers[2].Length; i++)
                tileSetLayers[2][i] = new Tile16x16(i);
        }
        private void DecompressTileSetData()
        {
            // Decompress data at offsets
            tileSets[0] = Bits.GetByteArray(Model.TitleData, 0x0000, 0x1000);
            tileSets[1] = Bits.GetByteArray(Model.TitleData, 0x1000, 0x1000);
            tileSets[2] = Bits.GetByteArray(Model.TitleData, 0xBBE0, 0x300);

            // Create buffer the size of the combined graphicSets
            graphics = Bits.GetByteArray(Model.TitleData, 0x6C00, 0x4FE0);
            graphicsL3 = Bits.GetByteArray(Model.TitleData, 0xBEA0, 0x1BC0);
        }
        public void DrawTileset(byte[] tileset, Tile16x16[] tilesetLayer, byte[] gfx)
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
                    temp = tileset[offset]; offset++; // Palette Set?
                    source = Do.DrawTile8x8(tile, temp, gfx, titlePalettes.Palettes, 0x20);
                    tilesetLayer[i].Subtiles[z] = source;
                }
                offset += 60; // jump forward in buffer to grab correct 8x8 tiles
                for (int a = 2; a < 4; a++)
                {
                    tile = (ushort)(Bits.GetShort(tileset, offset) & 0x03FF); offset++;
                    temp = tileset[offset]; offset++;
                    source = Do.DrawTile8x8(tile, temp, gfx, titlePalettes.Palettes, 0x20);
                    tilesetLayer[i].Subtiles[a] = source;;
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
        public void RedrawTilesets(int layer)
        {
            if (layer == 0)// || layer == 3)
                DrawTileset(tileSets[0], tileSetLayers[0], graphics);
            if (layer == 1)// || layer == 3)
                DrawTileset(tileSets[1], tileSetLayers[1], graphics);
            if (layer == 3) // the logo
                DrawTileset(tileSets[2], tileSetLayers[2], graphicsL3);
        }
        public int GetTileNumber(int layer, int x, int y)
        {
            if (layer < 3)
                return tileSetLayers[layer][x + y * 16].TileIndex;
            else return 0;
        }
        public void AssembleIntoModel(int width, int layer)
        {
            int offset = 0;
            for (int y = 0; y < tileSetLayers[layer].Length / width; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Tile16x16 tile = tileSetLayers[layer][y * width + x];
                    for (int s = 0; s < 4; s++)
                    {
                        offset = y * (width * 2 * 2 * 2) + (x * 2 * 2);
                        offset += (s % 2) * 2;
                        offset += (s / 2) * (width * 2 * 2);
                        Tile8x8 subtile = tile.Subtiles[s];
                        if (subtile == null) continue;
                        Bits.SetShort(tileSets[layer], offset, (ushort)subtile.TileIndex);
                        tileSets[layer][offset + 1] |= (byte)(subtile.PaletteIndex << 2);
                        Bits.SetBit(tileSets[layer], offset + 1, 5, subtile.PriorityOne);
                        Bits.SetBit(tileSets[layer], offset + 1, 6, subtile.Mirror);
                        Bits.SetBit(tileSets[layer], offset + 1, 7, subtile.Invert);
                    }
                }
            }
            Buffer.BlockCopy(tileSets[0], 0, Model.TitleData, 0, 0x1000);
            Buffer.BlockCopy(tileSets[1], 0, Model.TitleData, 0x1000, 0x1000);
            Buffer.BlockCopy(tileSets[2], 0, Model.TitleData, 0xBBE0, 0x300);
            Buffer.BlockCopy(graphics, 0, Model.TitleData, 0x6C00, 0x4FE0);
            Buffer.BlockCopy(graphicsL3, 0x40, Model.TitleData, 0xBEE0, 0x1B80);
        }
        public void AssembleIntoModel(int width)
        {
            int offset = 0;
            for (int layer = 0; layer < 3; layer++)
            {
                for (int y = 0; y < tileSetLayers[layer].Length / width; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        Tile16x16 tile = tileSetLayers[layer][y * width + x];
                        for (int s = 0; s < 4; s++)
                        {
                            offset = y * (width * 2 * 2 * 2) + (x * 2 * 2);
                            offset += (s % 2) * 2;
                            offset += (s / 2) * (width * 2 * 2);
                            Tile8x8 subtile = tile.Subtiles[s];
                            if (subtile == null) continue;
                            Bits.SetShort(tileSets[layer], offset, (ushort)subtile.TileIndex);
                            tileSets[layer][offset + 1] |= (byte)(subtile.PaletteIndex << 2);
                            Bits.SetBit(tileSets[layer], offset + 1, 5, subtile.PriorityOne);
                            Bits.SetBit(tileSets[layer], offset + 1, 6, subtile.Mirror);
                            Bits.SetBit(tileSets[layer], offset + 1, 7, subtile.Invert);
                        }
                    }
                }
            }
            Buffer.BlockCopy(tileSets[0], 0, Model.TitleData, 0, 0x1000);
            Buffer.BlockCopy(tileSets[1], 0, Model.TitleData, 0x1000, 0x1000);
            Buffer.BlockCopy(tileSets[2], 0, Model.TitleData, 0xBBE0, 0x300);
            Buffer.BlockCopy(graphics, 0, Model.TitleData, 0x6C00, 0x4FE0);
            Buffer.BlockCopy(graphicsL3, 0x40, Model.TitleData, 0xBEE0, 0x1B80);
        }
    }
}
