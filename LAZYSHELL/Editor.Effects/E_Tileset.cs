using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace LAZYSHELL
{
    [Serializable()]
    public class E_Tileset
    {
        private E_Animation animation;
        private int[] palette; public int[] Palette { get { return palette; } set { palette = value; } }
        private byte[] graphics; public byte[] Graphics { get { return graphics; } set { graphics = value; } }
        private Tile16x16[] tileset; public Tile16x16[] Tileset { get { return tileset; } set { tileset = value; } }

        public E_Tileset(E_Animation animation, int index)
        {
            this.animation = animation;
            this.graphics = animation.GraphicSet;
            this.palette = animation.PaletteSet.Palettes[index];

            tileset = new Tile16x16[8 * 8];
            for (int i = 0; i < tileset.Length; i++)
                tileset[i] = new Tile16x16(i);

            DrawTileset(tileset, animation.TileSet);
        }
        public void RedrawTileset(E_Animation animation, int length)
        {
            this.graphics = animation.GraphicSet;
            for (int i = 0; i < length / 8; i++)
            {
                for (int z = 0; z < 4; z++)
                {
                    Tile8x8 source;
                    if (animation.Codec == 1)
                        source = Do.DrawTile8x8((byte)tileset[i].Subtiles[z].TileIndex, 0, graphics, palette, 0x10);
                    else
                        source = Do.DrawTile8x8((byte)tileset[i].Subtiles[z].TileIndex, 0, graphics, palette, 0x20);

                    tileset[i].Subtiles[z] = source;
                }
            }
        }
        public void DrawTileset(Tile16x16[] dst, byte[] src)
        {
            byte temp;
            ushort tile;
            Tile8x8 source;
            int offset = 0;
            int i = 0;
            for (; i < 64; i++)
            {
                if (i > 0 && i % 8 == 0) offset += 32;
                if (Bits.GetShort(src, offset) == 0xFFFF) break;
                else
                {
                    for (int z = 0; z < 2; z++)
                    {
                        if (offset >= src.Length - 1) return;
                        tile = (ushort)(Bits.GetShort(src, offset++) & 0x03FF);
                        temp = src[offset++];
                        if (animation.Codec == 1)
                            source = Do.DrawTile8x8(tile, temp, graphics, palette, 0x10);
                        else
                            source = Do.DrawTile8x8(tile, temp, graphics, palette, 0x20);
                        dst[i].Subtiles[z] = source;
                    }
                    offset += 28; // jump forward in buffer to grab correct 8x8 tiles
                    for (int a = 2; a < 4; a++)
                    {
                        if (offset >= src.Length - 1) return;
                        tile = (ushort)(Bits.GetShort(src, offset++) & 0x03FF);
                        temp = src[offset++];
                        if (animation.Codec == 1)
                            source = Do.DrawTile8x8(tile, temp, graphics, palette, 0x10);
                        else
                            source = Do.DrawTile8x8(tile, temp, graphics, palette, 0x20);
                        dst[i].Subtiles[a] = source;
                    }
                    offset -= 32; // jump back in buffer so that we can start the next 16x16 tile
                }
            }
            for (; i < 64; i++) // fill up the rest with empty tiles
            {
                for (int z = 0; z < 4; z++)
                {
                    if (animation.Codec == 1)
                        source = Do.DrawTile8x8(0, 0, graphics, palette, 0x10);
                    else
                        source = Do.DrawTile8x8(0, 0, graphics, palette, 0x20);
                    dst[i].Subtiles[z] = source;
                }
            }
        }
        public void DrawTileset(byte[] dst, Tile16x16[] src)
        {
            ushort tile;
            Tile8x8 source;
            int offset = 0;
            int i = 0;
            for (; i < 64; i++)
            {
                if (i > 0 && i % 8 == 0) offset += 32;
                for (int z = 0; z < 2; z++)
                {
                    source = src[i].Subtiles[z];
                    tile = (ushort)source.TileIndex;
                    Bits.SetShort(dst, offset, tile); offset += 2;
                }
                offset += 28; // jump forward in buffer to grab correct 8x8 tiles
                for (int a = 2; a < 4; a++)
                {
                    source = src[i].Subtiles[a];
                    tile = (ushort)source.TileIndex;
                    Bits.SetShort(dst, offset, tile); offset += 2;
                }
                offset -= 32; // jump back in buffer so that we can start the next 16x16 tile
            }
        }
    }
}
