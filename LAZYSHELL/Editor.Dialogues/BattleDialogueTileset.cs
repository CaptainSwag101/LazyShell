using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace LAZYSHELL
{
    [Serializable()]
    public class BattleDialogueTileset
    {
        [NonSerialized()]
                private PaletteSet palettes;
        private byte[] graphics; public byte[] GraphicSet { get { return graphics; } set { graphics = value; } }
        private byte[] tileSet; public byte[] TileSet { get { return tileSet; } set { tileSet = value; } }
        private Tile[] tileSetLayer; public Tile[] TileSetLayer { get { return tileSetLayer; } }

        public BattleDialogueTileset(PaletteSet paletteSet)
        {
            this.graphics = Model.DialogueGraphics;
            this.tileSet = Model.BattleDialogueTileSet;
            this.palettes = paletteSet;

            tileSetLayer = new Tile[16 * 2];
            for (int i = 0; i < tileSetLayer.Length; i++)
                tileSetLayer[i] = new Tile(i);

            DrawTileset(tileSet, tileSetLayer);
        }
        public BattleDialogueTileset(byte[] graphics, byte[] tileSet, PaletteSet paletteSet)
        {
            this.graphics = graphics;
            this.tileSet = tileSet;
            this.palettes = paletteSet;

            tileSetLayer = new Tile[16 * 2];
            for (int i = 0; i < tileSetLayer.Length; i++)
                tileSetLayer[i] = new Tile(i);

            DrawTileset(tileSet, tileSetLayer);
        }
        public void RedrawTileset()
        {
            DrawTileset(tileSet, tileSetLayer);
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
                    source = Do.DrawSubtile(tile, temp, graphics, palettes.Palettes, 0x20);
                    dst[i].Subtiles[z] = source;
                }
                offset += 60; // jump forward in buffer to grab correct 8x8 tiles
                for (int a = 2; a < 4; a++)
                {
                    tile = (ushort)(Bits.GetShort(src, offset) & 0x03FF); offset++;
                    temp = src[offset]; offset++;
                    source = Do.DrawSubtile(tile, temp, graphics, palettes.Palettes, 0x20);
                    dst[i].Subtiles[a] = source;
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
        private void Assemble()
        {
        }
    }
}
