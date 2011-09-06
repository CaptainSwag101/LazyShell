using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace LAZYSHELL
{
    public class TileSet
    {
        private LevelMap levelMap;
        private State state = State.Instance;
        //
        private byte[][] tileSets = new byte[3][]; public byte[][] TileSets { get { return tileSets; } set { tileSets = value; } }
        private byte[] graphics; public byte[] Graphics { get { return graphics; } set { graphics = value; } }
        private byte[] graphicsL3; public byte[] GraphicsL3 { get { return graphicsL3; } set { graphicsL3 = value; } }
        private Tile16x16[][] tilesetLayers = new Tile16x16[3][];
        public Tile16x16[][] TileSetLayers { get { return tilesetLayers; } set { tilesetLayers = value; } }
        public PaletteSet paletteSet;
        //
        public TileSet(LevelMap levelMap, PaletteSet paletteSet)
        {
            this.levelMap = levelMap; // grab the current LevelMap
            this.paletteSet = paletteSet; // grab the current Palette Set

            tileSets[0] = Model.TileSets[levelMap.TileSetL1 + 0x20];
            tileSets[1] = Model.TileSets[levelMap.TileSetL2 + 0x20];
            tileSets[2] = Model.TileSets[levelMap.TileSetL3];

            graphics = new byte[0x6000];
            Buffer.BlockCopy(Model.GraphicSets[levelMap.GraphicSetA + 0x48], 0, graphics, 0, 0x2000);
            Buffer.BlockCopy(Model.GraphicSets[levelMap.GraphicSetB + 0x48], 0, graphics, 0x2000, 0x1000);
            Buffer.BlockCopy(Model.GraphicSets[levelMap.GraphicSetC + 0x48], 0, graphics, 0x3000, 0x1000);
            Buffer.BlockCopy(Model.GraphicSets[levelMap.GraphicSetD + 0x48], 0, graphics, 0x4000, 0x1000);
            Buffer.BlockCopy(Model.GraphicSets[levelMap.GraphicSetE + 0x48], 0, graphics, 0x5000, 0x1000);
            if (levelMap.GraphicSetL3 != 0xFF)
                graphicsL3 = Model.GraphicSets[levelMap.GraphicSetL3];

            // Create our layers for the tilesets (256x512)
            tilesetLayers[0] = new Tile16x16[16 * 32];
            tilesetLayers[1] = new Tile16x16[16 * 32];
            if (levelMap.GraphicSetL3 != 0xFF)
                tilesetLayers[2] = new Tile16x16[16 * 32];
            CreateLayers(); // Create inidividual tiles

            DrawTileset(tileSets[0], tilesetLayers[0], 0);
            DrawTileset(tileSets[1], tilesetLayers[1], 1);
            if (levelMap.GraphicSetL3 != 0xFF)
                DrawTileset(tileSets[2], tilesetLayers[2], 2);
        }
        private void CreateLayers()
        {
            int i;
            if (tilesetLayers[0] != null)
            {
                for (i = 0; i < tilesetLayers[0].Length; i++)
                    tilesetLayers[0][i] = new Tile16x16(i);
            }
            if (tilesetLayers[1] != null)
            {
                for (i = 0; i < tilesetLayers[1].Length; i++)
                    tilesetLayers[1][i] = new Tile16x16(i);
            }
            if (tilesetLayers[2] != null)
            {
                for (i = 0; i < tilesetLayers[2].Length; i++)
                    tilesetLayers[2][i] = new Tile16x16(i);
            }
        }
        public void DrawTileset(byte[] src, Tile16x16[] dst, int layer)
        {
            byte[] graphics;
            byte temp, format;
            ushort tile;
            Tile8x8 source;
            int offset = 0;
            if (layer != 2)
            {
                format = 0x20;
                graphics = this.graphics;
            }
            else
            {
                format = 0x10;
                graphics = this.graphicsL3;
            }
            for (int i = 0; i < dst.Length; i++)
            {
                for (int z = 0; z < 2; z++)
                {
                    tile = (ushort)(Bits.GetShort(src, offset) & 0x03FF); offset++;
                    temp = src[offset]; offset++; // Palette Set?
                    source = Do.DrawTile8x8(tile, temp, graphics, paletteSet.Palettes, format);
                    dst[i].Subtiles[z] = source;
                }
                offset += 60; // jump forward in buffer to grab correct 8x8 tiles
                for (int a = 2; a < 4; a++)
                {
                    tile = (ushort)(Bits.GetShort(src, offset) & 0x03FF); offset++;
                    temp = src[offset]; offset++;
                    source = Do.DrawTile8x8(tile, temp, graphics, paletteSet.Palettes, format);
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
        public void RedrawTilesets()
        {
            if (tilesetLayers[0] != null)// || layer == 3)
                DrawTileset(tileSets[0], tilesetLayers[0], 0);
            if (tilesetLayers[1] != null)// || layer == 3)
                DrawTileset(tileSets[1], tilesetLayers[1], 1);
            if (tilesetLayers[2] != null)// || layer == 3)
                DrawTileset(tileSets[2], tilesetLayers[2], 2);
        }
        public void RedrawTilesets(int layer)
        {
            if (layer == 0 && tilesetLayers[0] != null)// || layer == 3)
                DrawTileset(tileSets[0], tilesetLayers[0], 0);
            if (layer == 1 && tilesetLayers[1] != null)// || layer == 3)
                DrawTileset(tileSets[1], tilesetLayers[1], 1);
            if (layer == 2 && tilesetLayers[2] != null)// || layer == 3)
                DrawTileset(tileSets[2], tilesetLayers[2], 2);
        }
        //
        public int GetTileNum(int layer, int x, int y)
        {
            if (layer < 3)
                return tilesetLayers[layer][x + y * 16].TileIndex;
            else return 0;
        }
        public void Clear(int count)
        {
            if (count == 1)
            {
                Model.TileSets[levelMap.TileSetL1 + 0x20] = new byte[0x2000];
                Model.TileSets[levelMap.TileSetL2 + 0x20] = new byte[0x2000];
                Model.TileSets[levelMap.TileSetL3] = new byte[0x1000];

                Model.EditTileSets[levelMap.TileSetL1 + 0x20] = true;
                Model.EditTileSets[levelMap.TileSetL2 + 0x20] = true;
                Model.EditTileSets[levelMap.TileSetL3] = true;
            }
            else
            {
                for (int i = 0; i < count; i++)
                {
                    if (i < 0x20)
                        Model.TileSets[i] = new byte[0x1000];
                    else
                        Model.TileSets[i] = new byte[0x2000];

                    Model.EditTileSets[i] = true;
                }
            }
            for (int i = 0; i < 3; i++) RedrawTilesets(i);
        }
        //
        public void AssembleIntoModel(int width, int layer)
        {
            if (tilesetLayers[layer] == null) return;

            int offset = 0;
            for (int y = 0; y < tilesetLayers[layer].Length / width; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Tile16x16 tile = tilesetLayers[layer][y * width + x];
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
            if (layer == 0)
                Model.EditTileSets[levelMap.TileSetL1 + 0x20] = true;
            if (layer == 1)
                Model.EditTileSets[levelMap.TileSetL2 + 0x20] = true;
            if (layer == 2)
                Model.EditTileSets[levelMap.TileSetL3] = true;

            Buffer.BlockCopy(graphics, 0, Model.GraphicSets[levelMap.GraphicSetA + 0x48], 0, 0x2000);
            Buffer.BlockCopy(graphics, 0x2000, Model.GraphicSets[levelMap.GraphicSetB + 0x48], 0, 0x1000);
            Buffer.BlockCopy(graphics, 0x3000, Model.GraphicSets[levelMap.GraphicSetC + 0x48], 0, 0x1000);
            Buffer.BlockCopy(graphics, 0x4000, Model.GraphicSets[levelMap.GraphicSetD + 0x48], 0, 0x1000);
            Buffer.BlockCopy(graphics, 0x5000, Model.GraphicSets[levelMap.GraphicSetE + 0x48], 0, 0x1000);

            Model.EditGraphicSets[levelMap.GraphicSetA + 0x48] = true;
            Model.EditGraphicSets[levelMap.GraphicSetB + 0x48] = true;
            Model.EditGraphicSets[levelMap.GraphicSetC + 0x48] = true;
            Model.EditGraphicSets[levelMap.GraphicSetD + 0x48] = true;
            Model.EditGraphicSets[levelMap.GraphicSetE + 0x48] = true;
        }
        public void AssembleIntoModel(int width)
        {
            int offset = 0;
            for (int l = 0; l < tilesetLayers.Length; l++)
            {
                if (tilesetLayers[l] == null) continue;
                for (int y = 0; y < tilesetLayers[l].Length / width; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        Tile16x16 tile = tilesetLayers[l][y * width + x];
                        for (int s = 0; s < 4; s++)
                        {
                            offset = y * (width * 2 * 2 * 2) + (x * 2 * 2);
                            offset += (s % 2) * 2;
                            offset += (s / 2) * (width * 2 * 2);
                            Tile8x8 subtile = tile.Subtiles[s];
                            if (subtile == null) continue;
                            Bits.SetShort(tileSets[l], offset, (ushort)subtile.TileIndex);
                            tileSets[l][offset + 1] |= (byte)(subtile.PaletteIndex << 2);
                            Bits.SetBit(tileSets[l], offset + 1, 5, subtile.PriorityOne);
                            Bits.SetBit(tileSets[l], offset + 1, 6, subtile.Mirror);
                            Bits.SetBit(tileSets[l], offset + 1, 7, subtile.Invert);
                        }
                    }
                }
            }
            Model.EditTileSets[levelMap.TileSetL1 + 0x20] = true;
            Model.EditTileSets[levelMap.TileSetL2 + 0x20] = true;
            Model.EditTileSets[levelMap.TileSetL3] = true;

            Buffer.BlockCopy(graphics, 0, Model.GraphicSets[levelMap.GraphicSetA + 0x48], 0, 0x2000);
            Buffer.BlockCopy(graphics, 0x2000, Model.GraphicSets[levelMap.GraphicSetB + 0x48], 0, 0x1000);
            Buffer.BlockCopy(graphics, 0x3000, Model.GraphicSets[levelMap.GraphicSetC + 0x48], 0, 0x1000);
            Buffer.BlockCopy(graphics, 0x4000, Model.GraphicSets[levelMap.GraphicSetD + 0x48], 0, 0x1000);
            Buffer.BlockCopy(graphics, 0x5000, Model.GraphicSets[levelMap.GraphicSetE + 0x48], 0, 0x1000);

            Model.EditGraphicSets[levelMap.GraphicSetA + 0x48] = true;
            Model.EditGraphicSets[levelMap.GraphicSetB + 0x48] = true;
            Model.EditGraphicSets[levelMap.GraphicSetC + 0x48] = true;
            Model.EditGraphicSets[levelMap.GraphicSetD + 0x48] = true;
            Model.EditGraphicSets[levelMap.GraphicSetE + 0x48] = true;
        }
    }
}
