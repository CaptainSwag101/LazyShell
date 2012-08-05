using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace LAZYSHELL
{
    [Serializable()]
    public class Tileset
    {
        private LevelMap levelMap;
        public int Width;
        public int Height;
        public int HeightL3;
        public string Type;
        private int tilesize;
        //
        private byte[][] tilesets_Bytes = new byte[3][];
        public PaletteSet paletteSet;
        private byte[] graphics;
        private byte[] graphicsL3;
        private Tile[][] tilesets_Tiles = new Tile[3][];
        public byte[] Tileset_Bytes { get { return tilesets_Bytes[0]; } set { tilesets_Bytes[0] = value; } }
        public byte[][] Tilesets_Bytes { get { return tilesets_Bytes; } set { tilesets_Bytes = value; } }
        public byte[] Graphics { get { return graphics; } set { graphics = value; } }
        public byte[] GraphicsL3 { get { return graphicsL3; } set { graphicsL3 = value; } }
        public Tile[] Tileset_Tiles { get { return tilesets_Tiles[0]; } set { tilesets_Tiles[0] = value; } }
        public Tile[][] Tilesets_Tiles { get { return tilesets_Tiles; } set { tilesets_Tiles = value; } }
        // Minecart Mode7 variables
        private byte[] subtile_bytes;
        private byte[] palette_bytes;
        public byte[] Subtile_Bytes { get { return subtile_bytes; } set { subtile_bytes = value; } }
        public byte[] Palette_Bytes { get { return palette_bytes; } set { palette_bytes = value; } }
        //
        public Tileset(byte[] tileset_Bytes, byte[] graphics, PaletteSet paletteSet, int width, int height, string type)
        {
            this.paletteSet = paletteSet;
            this.Tileset_Bytes = tileset_Bytes;
            this.Width = width;
            this.Height = height;
            this.tilesize = 2;
            this.Type = type;
            //
            this.graphics = graphics;
            //
            Tileset_Tiles = new Tile[Width * Height];
            for (int i = 0; i < Tileset_Tiles.Length; i++)
                Tileset_Tiles[i] = new Tile(i);
            DrawTileset(Tileset_Bytes, Tileset_Tiles, graphics, 0x20);
            this.tilesets_Bytes[0] = this.Tileset_Bytes;
            this.tilesets_Tiles[0] = this.Tileset_Tiles;
        }
        public Tileset(LevelMap levelMap, PaletteSet paletteSet)
        {
            this.levelMap = levelMap; // grab the current LevelMap
            this.paletteSet = paletteSet; // grab the current Palette Set
            this.Width = 16;
            this.Height = 32;
            this.HeightL3 = 8;
            this.tilesize = 2;
            this.Type = "level";
            // set tileset byte arrays
            tilesets_Bytes[0] = Model.Tilesets[levelMap.TilesetL1 + 0x20];
            tilesets_Bytes[1] = Model.Tilesets[levelMap.TilesetL2 + 0x20];
            tilesets_Bytes[2] = Model.Tilesets[levelMap.TilesetL3];
            // combine graphic sets into one array
            graphics = new byte[0x6000];
            Buffer.BlockCopy(Model.GraphicSets[levelMap.GraphicSetA + 0x48], 0, graphics, 0, 0x2000);
            Buffer.BlockCopy(Model.GraphicSets[levelMap.GraphicSetB + 0x48], 0, graphics, 0x2000, 0x1000);
            Buffer.BlockCopy(Model.GraphicSets[levelMap.GraphicSetC + 0x48], 0, graphics, 0x3000, 0x1000);
            Buffer.BlockCopy(Model.GraphicSets[levelMap.GraphicSetD + 0x48], 0, graphics, 0x4000, 0x1000);
            Buffer.BlockCopy(Model.GraphicSets[levelMap.GraphicSetE + 0x48], 0, graphics, 0x5000, 0x1000);
            if (levelMap.GraphicSetL3 != 0xFF)
                graphicsL3 = Model.GraphicSets[levelMap.GraphicSetL3];
            // initialize 16x16 tile arrays
            tilesets_Tiles[0] = new Tile[Width * Height];
            tilesets_Tiles[1] = new Tile[Width * Height];
            if (levelMap.GraphicSetL3 != 0xFF)
                tilesets_Tiles[2] = new Tile[Width * HeightL3];
            for (int l = 0; l < 3; l++)
            {
                if (tilesets_Tiles[l] == null)
                    continue;
                for (int i = 0; i < tilesets_Tiles[l].Length; i++)
                    tilesets_Tiles[l][i] = new Tile(i);
            }
            // draw all 16x16 tiles
            DrawTileset(tilesets_Bytes[0], tilesets_Tiles[0], graphics, 0x20);
            DrawTileset(tilesets_Bytes[1], tilesets_Tiles[1], graphics, 0x20);
            if (levelMap.GraphicSetL3 != 0xFF)
                DrawTileset(tilesets_Bytes[2], tilesets_Tiles[2], graphicsL3, 0x10);
        }
        public Tileset(PaletteSet paletteSet, string type)
        {
            this.paletteSet = paletteSet;
            this.Width = 16;
            this.Height = 32;
            this.HeightL3 = 6;
            this.tilesize = 2;
            this.Type = "title";
            // Decompress data at offsets
            tilesets_Bytes[0] = Bits.GetByteArray(Model.TitleData, 0x0000, 0x1000);
            tilesets_Bytes[1] = Bits.GetByteArray(Model.TitleData, 0x1000, 0x1000);
            tilesets_Bytes[2] = Bits.GetByteArray(Model.TitleData, 0xBBE0, 0x300);
            // Create buffer the size of the combined graphicSets
            graphics = Bits.GetByteArray(Model.TitleData, 0x6C00, 0x4FE0);
            graphicsL3 = Bits.GetByteArray(Model.TitleData, 0xBEA0, 0x1BC0);
            //
            tilesets_Tiles[0] = new Tile[16 * 32];
            tilesets_Tiles[1] = new Tile[16 * 32];
            tilesets_Tiles[2] = new Tile[16 * 6];
            for (int i = 0; i < tilesets_Tiles[0].Length; i++)
                tilesets_Tiles[0][i] = new Tile(i);
            for (int i = 0; i < tilesets_Tiles[1].Length; i++)
                tilesets_Tiles[1][i] = new Tile(i);
            for (int i = 0; i < tilesets_Tiles[2].Length; i++)
                tilesets_Tiles[2][i] = new Tile(i);
            DrawTileset(tilesets_Bytes[0], tilesets_Tiles[0], graphics, 0x20);
            DrawTileset(tilesets_Bytes[1], tilesets_Tiles[1], graphics, 0x20);
            DrawTileset(tilesets_Bytes[2], tilesets_Tiles[2], graphicsL3, 0x20);
        }
        public Tileset(PaletteSet paletteSet)
        {
            this.paletteSet = paletteSet; // grab the current Palette Set
            this.Width = 16;
            this.Height = 16;
            this.tilesize = 1;
            this.Type = "mode7";
            //
            subtile_bytes = Model.MinecartM7TilesetSubtiles;
            palette_bytes = Model.MinecartM7TilesetPalettes;
            graphics = Model.MinecartM7Graphics;
            // Create our layers for the tilesets (256x512)
            Tileset_Tiles = new Tile[Width * Height];
            for (int i = 0; i < Tileset_Tiles.Length; i++)
                Tileset_Tiles[i] = new Tile(i);
            DrawTileset(subtile_bytes, Tileset_Tiles, graphics, 0x20);
        }
        //
        private void DrawTileset(byte[] src, Tile[] dst, byte[] graphics, byte format)
        {
            byte status = 0;
            ushort tilenum = 0;
            Subtile subtile;
            int offset = 0;
            for (int i = 0; i < Width / 16; i++)
            {
                for (int y = 0; y < Height; y++)
                {
                    for (int x = i * 16; x < i * 16 + 16; x++)
                    {
                        int index = y * Width + x;
                        if (index >= dst.Length)
                            continue;
                        for (int z = 0; z < 4; z++)
                        {
                            if (z == 2)
                                offset += tilesize * 30;
                            if (tilesize == 2)
                            {
                                tilenum = (ushort)(Bits.GetShort(src, offset++) & 0x03FF);
                                status = src[offset++];
                            }
                            else
                            {
                                tilenum = src[offset++];
                                status = (byte)(palette_bytes[tilenum] << 2);
                            }
                            subtile = Do.DrawSubtile(tilenum, status, graphics, paletteSet.Palettes, format);
                            dst[index].Subtiles[z] = subtile;
                        }
                        if (x < i * 16 + 15)
                            offset -= tilesize * 32;
                    }
                }
            }
        }
        public void DrawTileset(Tile[] src, byte[] dst)
        {
            ushort tilenum = 0;
            Subtile subtile;
            int offset = 0;
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < 16; x++)
                {
                    int index = y * Width + x;
                    if (index >= src.Length)
                        continue;
                    for (int z = 0; z < 4; z++)
                    {
                        if (z == 2)
                            offset += tilesize * 30;
                        subtile = src[index].Subtiles[z];
                        if (tilesize == 2)
                        {
                            tilenum = (ushort)subtile.Index;
                            Bits.SetShort(dst, offset, tilenum); offset++;
                            dst[offset] |= (byte)(subtile.Palette << 2);
                            Bits.SetBit(dst, offset, 5, subtile.Priority1);
                            Bits.SetBit(dst, offset, 6, subtile.Mirror);
                            Bits.SetBit(dst, offset, 7, subtile.Invert); offset++;
                        }
                        else
                        {
                            tilenum = (byte)subtile.Index;
                            subtile_bytes[offset++] = (byte)tilenum;
                            palette_bytes[tilenum] = (byte)subtile.Palette;
                        }
                    }
                    if (x < 15)
                        offset -= tilesize * 32;
                }
            }
        }
        public void RedrawTilesets()
        {
            for (int l = 0; l < 3; l++)
            {
                if (tilesets_Tiles[l] != null)
                {
                    byte format = (byte)(l != 2 || Type == "title" ? 0x20 : 0x10);
                    byte[] graphics = l != 2 ? this.graphics : this.graphicsL3;
                    //
                    if (tilesize == 2)
                        DrawTileset(tilesets_Bytes[l], tilesets_Tiles[l], graphics, format);
                    else
                        DrawTileset(subtile_bytes, tilesets_Tiles[l], graphics, format);
                }
            }
        }
        public void RedrawTilesets(int layer)
        {
            byte format = (byte)(layer != 2 || Type == "title" ? 0x20 : 0x10);
            byte[] graphics = layer != 2 ? this.graphics : this.graphicsL3;
            //
            if (tilesets_Tiles[layer] != null)
                DrawTileset(tilesets_Bytes[layer], tilesets_Tiles[layer], graphics, format);
        }
        //
        public int GetTileNum(int layer, int x, int y)
        {
            if (layer < 3)
                return tilesets_Tiles[layer][y * Width + x].TileIndex;
            else return 0;
        }
        public void Clear(int count)
        {
            if (Type == "level")
            {
                if (count == 1)
                {
                    Model.Tilesets[levelMap.TilesetL1 + 0x20] = new byte[0x2000];
                    Model.Tilesets[levelMap.TilesetL2 + 0x20] = new byte[0x2000];
                    Model.Tilesets[levelMap.TilesetL3] = new byte[0x1000];
                    Model.EditTileSets[levelMap.TilesetL1 + 0x20] = true;
                    Model.EditTileSets[levelMap.TilesetL2 + 0x20] = true;
                    Model.EditTileSets[levelMap.TilesetL3] = true;
                }
                else
                {
                    for (int i = 0; i < count; i++)
                    {
                        if (i < 0x20)
                            Model.Tilesets[i] = new byte[0x1000];
                        else
                            Model.Tilesets[i] = new byte[0x2000];
                        Model.EditTileSets[i] = true;
                    }
                }
            }
            else if (Type == "mode7")
            {
                // Minecart tileset
                for (int i = 0; i < 0x400; i++)
                    subtile_bytes[i] = Model.MinecartM7TilesetSubtiles[i] = 0;
                for (int i = 0; i < 0x100; i++)
                    palette_bytes[i] = Model.MinecartM7TilesetPalettes[i] = 0;
            }
            //
            RedrawTilesets();
        }
        //
        public void Assemble(int width, int layer)
        {
            if (tilesets_Tiles[layer] == null) return;
            //
            int offset = 0;
            if (Type == "level" || Type == "title")
            {
                for (int y = 0; y < tilesets_Tiles[layer].Length / width; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        int index = y * width + x;
                        if (index >= tilesets_Tiles[layer].Length)
                            continue;
                        Tile tile = tilesets_Tiles[layer][index];
                        for (int s = 0; s < 4; s++)
                        {
                            offset = y * (width * 8) + (x * 4);
                            offset += (s % 2) * 2;
                            offset += (s / 2) * (width * 4);
                            Subtile subtile = tile.Subtiles[s];
                            if (subtile == null) continue;
                            Bits.SetShort(tilesets_Bytes[layer], offset, (ushort)subtile.Index);
                            tilesets_Bytes[layer][offset + 1] |= (byte)(subtile.Palette << 2);
                            Bits.SetBit(tilesets_Bytes[layer], offset + 1, 5, subtile.Priority1);
                            Bits.SetBit(tilesets_Bytes[layer], offset + 1, 6, subtile.Mirror);
                            Bits.SetBit(tilesets_Bytes[layer], offset + 1, 7, subtile.Invert);
                        }
                    }
                }
                if (Type == "level")
                {
                    if (layer == 0)
                        Model.EditTileSets[levelMap.TilesetL1 + 0x20] = true;
                    if (layer == 1)
                        Model.EditTileSets[levelMap.TilesetL2 + 0x20] = true;
                    if (layer == 2)
                        Model.EditTileSets[levelMap.TilesetL3] = true;
                    //
                    Buffer.BlockCopy(graphics, 0, Model.GraphicSets[levelMap.GraphicSetA + 0x48], 0, 0x2000);
                    Buffer.BlockCopy(graphics, 0x2000, Model.GraphicSets[levelMap.GraphicSetB + 0x48], 0, 0x1000);
                    Buffer.BlockCopy(graphics, 0x3000, Model.GraphicSets[levelMap.GraphicSetC + 0x48], 0, 0x1000);
                    Buffer.BlockCopy(graphics, 0x4000, Model.GraphicSets[levelMap.GraphicSetD + 0x48], 0, 0x1000);
                    Buffer.BlockCopy(graphics, 0x5000, Model.GraphicSets[levelMap.GraphicSetE + 0x48], 0, 0x1000);
                    //
                    Model.EditGraphicSets[levelMap.GraphicSetA + 0x48] = true;
                    Model.EditGraphicSets[levelMap.GraphicSetB + 0x48] = true;
                    Model.EditGraphicSets[levelMap.GraphicSetC + 0x48] = true;
                    Model.EditGraphicSets[levelMap.GraphicSetD + 0x48] = true;
                    Model.EditGraphicSets[levelMap.GraphicSetE + 0x48] = true;
                }
                else if (Type == "title")
                {
                    Buffer.BlockCopy(tilesets_Bytes[0], 0, Model.TitleData, 0, 0x1000);
                    Buffer.BlockCopy(tilesets_Bytes[1], 0, Model.TitleData, 0x1000, 0x1000);
                    Buffer.BlockCopy(tilesets_Bytes[2], 0, Model.TitleData, 0xBBE0, 0x300);
                    Buffer.BlockCopy(graphics, 0, Model.TitleData, 0x6C00, 0x4FE0);
                    Buffer.BlockCopy(graphicsL3, 0x40, Model.TitleData, 0xBEE0, 0x1B80);
                }
            }
            else
                Assemble(width);
        }
        public void Assemble(int width)
        {
            int offset = 0;
            if (Type != "mode7")
            {
                for (int l = 0; l < tilesets_Tiles.Length; l++)
                {
                    if (tilesets_Tiles[l] == null) continue;
                    for (int y = 0; y < tilesets_Tiles[l].Length / width; y++)
                    {
                        for (int x = 0; x < width; x++)
                        {
                            Tile tile = tilesets_Tiles[l][y * width + x];
                            for (int s = 0; s < 4; s++)
                            {
                                offset = y * (width * 8) + (x * 4);
                                offset += (s % 2) * 2;
                                offset += (s / 2) * (width * 4);
                                Subtile subtile = tile.Subtiles[s];
                                if (subtile == null) continue;
                                Bits.SetShort(tilesets_Bytes[l], offset, (ushort)subtile.Index);
                                tilesets_Bytes[l][offset + 1] |= (byte)(subtile.Palette << 2);
                                Bits.SetBit(tilesets_Bytes[l], offset + 1, 5, subtile.Priority1);
                                Bits.SetBit(tilesets_Bytes[l], offset + 1, 6, subtile.Mirror);
                                Bits.SetBit(tilesets_Bytes[l], offset + 1, 7, subtile.Invert);
                            }
                        }
                    }
                }
                if (Type == "level")
                {
                    Model.EditTileSets[levelMap.TilesetL1 + 0x20] = true;
                    Model.EditTileSets[levelMap.TilesetL2 + 0x20] = true;
                    Model.EditTileSets[levelMap.TilesetL3] = true;
                    //
                    Buffer.BlockCopy(graphics, 0, Model.GraphicSets[levelMap.GraphicSetA + 0x48], 0, 0x2000);
                    Buffer.BlockCopy(graphics, 0x2000, Model.GraphicSets[levelMap.GraphicSetB + 0x48], 0, 0x1000);
                    Buffer.BlockCopy(graphics, 0x3000, Model.GraphicSets[levelMap.GraphicSetC + 0x48], 0, 0x1000);
                    Buffer.BlockCopy(graphics, 0x4000, Model.GraphicSets[levelMap.GraphicSetD + 0x48], 0, 0x1000);
                    Buffer.BlockCopy(graphics, 0x5000, Model.GraphicSets[levelMap.GraphicSetE + 0x48], 0, 0x1000);
                    //
                    Model.EditGraphicSets[levelMap.GraphicSetA + 0x48] = true;
                    Model.EditGraphicSets[levelMap.GraphicSetB + 0x48] = true;
                    Model.EditGraphicSets[levelMap.GraphicSetC + 0x48] = true;
                    Model.EditGraphicSets[levelMap.GraphicSetD + 0x48] = true;
                    Model.EditGraphicSets[levelMap.GraphicSetE + 0x48] = true;
                }
                else if (Type == "side")
                {
                    Buffer.BlockCopy(graphics, 0, Model.MinecartSSGraphics, 0, graphics.Length);
                }
                else if (Type == "title")
                {
                    Buffer.BlockCopy(tilesets_Bytes[0], 0, Model.TitleData, 0, 0x1000);
                    Buffer.BlockCopy(tilesets_Bytes[1], 0, Model.TitleData, 0x1000, 0x1000);
                    Buffer.BlockCopy(tilesets_Bytes[2], 0, Model.TitleData, 0xBBE0, 0x300);
                    Buffer.BlockCopy(graphics, 0, Model.TitleData, 0x6C00, 0x4FE0);
                    Buffer.BlockCopy(graphicsL3, 0x40, Model.TitleData, 0xBEE0, 0x1B80);
                }
            }
            else
            {
                if (Tileset_Tiles == null) return;
                for (int y = 0; y < 16; y++)
                {
                    for (int x = 0; x < 16; x++)
                    {
                        int i = y * 16 + x;
                        for (int z = 0; z < 4; z++)
                        {
                            offset = y * (width * 4) + (x * 2);
                            offset += z % 2;
                            offset += (z / 2) * (width * 2);
                            Subtile subtile = Tileset_Tiles[i].Subtiles[z];
                            byte tilenum = (byte)subtile.Index;
                            subtile_bytes[offset] = tilenum;
                            palette_bytes[tilenum] = (byte)subtile.Palette;
                        }
                    }
                }
                Buffer.BlockCopy(graphics, 0, Model.MinecartM7Graphics, 0, graphics.Length);
            }
        }
    }
}
