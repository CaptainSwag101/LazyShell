using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace LAZYSHELL
{
    [Serializable()]
    class BattlefieldTileSet
    {
        [NonSerialized()]
        private Battlefield battlefield;
        public Battlefield Battlefield { get { return battlefield; } set { battlefield = value; } }
        private PaletteSet paletteSet;
        public PaletteSet PaletteSet { get { return paletteSet; } set { paletteSet = value; } }
        private byte[] tileSet; public byte[] TileSet { get { return tileSet; } set { tileSet = value; } }
        private byte[] graphics; public byte[] Graphics { get { return graphics; } set { graphics = value; } }
        private Tile[] tilesetLayer;
        public Tile[] TileSetLayer { get { return tilesetLayer; } set { tilesetLayer = value; } }
        public BattlefieldTileSet(Battlefield map, PaletteSet paletteSet)
        {
            this.battlefield = map; // grab the current LevelMap
            this.paletteSet = paletteSet; // grab the current Palette Set

            tileSet = Model.TileSetsBF[battlefield.TileSet];

            graphics = new byte[0x6000];
            if (battlefield.GraphicSetA < 0xC8)
                Buffer.BlockCopy(Model.GraphicSets[battlefield.GraphicSetA + 0x48], 0, graphics, 0, 0x2000);
            if (battlefield.GraphicSetB < 0xC8)
                Buffer.BlockCopy(Model.GraphicSets[battlefield.GraphicSetB + 0x48], 0, graphics, 0x2000, 0x1000);
            if (battlefield.GraphicSetC < 0xC8)
                Buffer.BlockCopy(Model.GraphicSets[battlefield.GraphicSetC + 0x48], 0, graphics, 0x3000, 0x1000);
            if (battlefield.GraphicSetD < 0xC8)
                Buffer.BlockCopy(Model.GraphicSets[battlefield.GraphicSetD + 0x48], 0, graphics, 0x4000, 0x1000);
            if (battlefield.GraphicSetE < 0xC8)
                Buffer.BlockCopy(Model.GraphicSets[battlefield.GraphicSetE + 0x48], 0, graphics, 0x5000, 0x1000);

            tilesetLayer = new Tile[32 * 32];

            for (int i = 0; i < tilesetLayer.Length; i++)
                tilesetLayer[i] = new Tile(i);

            DrawTileset(tileSet, tilesetLayer);
        }
        public BattlefieldTileSet(Battlefield map, PaletteSet paletteSet, Tile[] tilesetLayer)
        {
            this.battlefield = map; // grab the current LevelMap
            this.paletteSet = paletteSet; // grab the current Palette Set
            this.tileSet = new byte[0x2000];
            this.tilesetLayer = tilesetLayer;
            graphics = new byte[0x6000];
            if (battlefield.GraphicSetA < 0xC8)
                Buffer.BlockCopy(Model.GraphicSets[battlefield.GraphicSetA + 0x48], 0, graphics, 0, 0x2000);
            if (battlefield.GraphicSetB < 0xC8)
                Buffer.BlockCopy(Model.GraphicSets[battlefield.GraphicSetB + 0x48], 0, graphics, 0x2000, 0x1000);
            if (battlefield.GraphicSetC < 0xC8)
                Buffer.BlockCopy(Model.GraphicSets[battlefield.GraphicSetC + 0x48], 0, graphics, 0x3000, 0x1000);
            if (battlefield.GraphicSetD < 0xC8)
                Buffer.BlockCopy(Model.GraphicSets[battlefield.GraphicSetD + 0x48], 0, graphics, 0x4000, 0x1000);
            if (battlefield.GraphicSetE < 0xC8)
                Buffer.BlockCopy(Model.GraphicSets[battlefield.GraphicSetE + 0x48], 0, graphics, 0x5000, 0x1000);
            DrawTileset(tilesetLayer, tileSet);
        }
        public BattlefieldTileSet()
        {
        }
        public void DrawTileset(byte[] src, Tile[] dst)
        {
            byte temp;
            ushort tile;
            Subtile source;
            int offset = 0;

            for (int i = 0; i < dst.Length; i++)
            {
                for (int z = 0; z < 2; z++)
                {
                    tile = (ushort)(Bits.GetShort(src, offset) & 0x03FF); offset++;
                    temp = src[offset]; offset++;
                    source = Do.DrawSubtile(tile, temp, graphics, paletteSet.Palettes, 0x20);
                    dst[i].Subtiles[z] = source;
                }
                offset += 60; // jump forward in buffer to grab correct 8x8 tiles
                for (int a = 2; a < 4; a++)
                {
                    tile = (ushort)(Bits.GetShort(src, offset) & 0x03FF); offset++;
                    temp = src[offset]; offset++;
                    source = Do.DrawSubtile(tile, temp, graphics, paletteSet.Palettes, 0x20);
                    dst[i].Subtiles[a] = source;;
                }
                if ((i - 15) % 16 == 0)
                    offset += 64;
                offset -= 64; // jump back in buffer so that we can start the next 16x16 tile
            }
        }
        public void DrawTileset(Tile[] src, byte[] dst)
        {
            ushort tile;
            Subtile source;
            int offset = 0;
            for (int i = 0; i < src.Length; i++)
            {
                for (int z = 0; z < 2; z++)
                {
                    source = src[i].Subtiles[z];
                    tile = (ushort)source.Index;
                    Bits.SetShort(dst, offset, tile); offset++;
                    dst[offset] |= (byte)(source.Palette << 2);
                    Bits.SetBit(dst, offset, 5, source.Priority1);
                    Bits.SetBit(dst, offset, 6, source.Mirror);
                    Bits.SetBit(dst, offset, 7, source.Invert); offset++;
                }
                offset += 60; // jump forward in buffer to grab correct 8x8 tiles
                for (int a = 2; a < 4; a++)
                {
                    source = src[i].Subtiles[a];
                    tile = (ushort)source.Index;
                    Bits.SetShort(dst, offset, tile); offset++;
                    dst[offset] |= (byte)(source.Palette << 2);
                    Bits.SetBit(dst, offset, 5, source.Priority1);
                    Bits.SetBit(dst, offset, 6, source.Mirror);
                    Bits.SetBit(dst, offset, 7, source.Invert); offset++;
                }
                if ((i - 15) % 16 == 0)
                    offset += 64;
                offset -= 64; // jump back in buffer so that we can start the next 16x16 tile
            }
        }
        public void RedrawTileset()
        {
            DrawTileset(tileSet, tilesetLayer);
        }
        public void Assemble(int width, int height)
        {
            int offset = 0;
            for (int q = 0; q < 4; q++)
            {
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        Tile tile = tilesetLayer[(y * width + x) + (q * 256)];
                        if (tile == null) continue;
                        for (int s = 0; s < 4; s++)
                        {
                            offset = y * (width * 2 * 2 * 2) + (x * 2 * 2);
                            offset += (s % 2) * 2;
                            offset += (s / 2) * (width * 2 * 2);
                            offset += (q * 256) * 8;
                            Subtile subtile = tile.Subtiles[s];
                            if (subtile == null) continue;
                            Bits.SetShort(tileSet, offset, (ushort)subtile.Index);
                            tileSet[offset + 1] |= (byte)(subtile.Palette << 2);
                            Bits.SetBit(tileSet, offset + 1, 5, subtile.Priority1);
                            Bits.SetBit(tileSet, offset + 1, 6, subtile.Mirror);
                            Bits.SetBit(tileSet, offset + 1, 7, subtile.Invert);
                        }
                    }
                }
            }
            Model.EditTileSetsBF[battlefield.TileSet] = true;
            if (battlefield.GraphicSetA < 0xC8)
                Buffer.BlockCopy(graphics, 0, Model.GraphicSets[battlefield.GraphicSetA + 0x48], 0, 0x2000);
            if (battlefield.GraphicSetB < 0xC8)
                Buffer.BlockCopy(graphics, 0x2000, Model.GraphicSets[battlefield.GraphicSetB + 0x48], 0, 0x1000);
            if (battlefield.GraphicSetC < 0xC8)
                Buffer.BlockCopy(graphics, 0x3000, Model.GraphicSets[battlefield.GraphicSetC + 0x48], 0, 0x1000);
            if (battlefield.GraphicSetD < 0xC8)
                Buffer.BlockCopy(graphics, 0x4000, Model.GraphicSets[battlefield.GraphicSetD + 0x48], 0, 0x1000);
            if (battlefield.GraphicSetE < 0xC8)
                Buffer.BlockCopy(graphics, 0x5000, Model.GraphicSets[battlefield.GraphicSetE + 0x48], 0, 0x1000);
        }
    }
}
