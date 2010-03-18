using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace SMRPGED
{
    public class E_Tileset
    {
        private E_Animation animation;
        private int paletteSetIndex;

        private byte[] graphicSet;
        private Tile16x16[] tileset; public Tile16x16[] Tileset { get { return tileset; } set { tileset = value; } }

        public E_Tileset(E_Animation animation, int paletteSetIndex)
        {
            this.animation = animation;
            this.graphicSet = animation.GraphicSet;
            this.paletteSetIndex = paletteSetIndex;

            tileset = new Tile16x16[8 * 8];
            for (int i = 0; i < tileset.Length; i++)
                tileset[i] = new Tile16x16(i);

            DrawTileset(tileset);
        }
        public void RedrawTileset(byte[] graphicSet, int paletteSetIndex, int length)
        {
            this.graphicSet = graphicSet;
            this.paletteSetIndex = paletteSetIndex;

            Tile8x8 source;

            for (int i = 0; i < length / 8; i++)
            {
                for (int z = 0; z < 4; z++)
                {
                    if (animation.Codec == 1)
                        source = Draw2bppTile8x8((byte)tileset[i].GetSubtile(z).TileNum, 0);
                    else
                        source = Draw4bppTile8x8((byte)tileset[i].GetSubtile(z).TileNum, 0);

                    tileset[i].SetSubtile(source, z);
                }
            }
        }
        public void DrawTileset(Tile16x16[] tileset)
        {
            byte prop, tile;
            Tile8x8 source;

            int offset = animation.TileSetPointer;
            int i = 0;
            for (; i < 64; i++)
            {
                if (i > 0 && i % 8 == 0)
                    offset += 32;

                if (BitManager.GetShort(animation.SM, offset) == 0xFFFF)
                    break;

                else
                {
                    for (int z = 0; z < 2; z++)
                    {
                        if (offset >= animation.SM.Length - 1) return;

                        tile = BitManager.GetByte(animation.SM, offset); offset++;
                        prop = BitManager.GetByte(animation.SM, offset); offset++;
                        if (animation.Codec == 1)
                            source = Draw2bppTile8x8(tile, prop);
                        else
                            source = Draw4bppTile8x8(tile, prop);

                        tileset[i].SetSubtile(source, z);
                    }
                    offset += 28; // jump forward in buffer to grab correct 8x8 tiles
                    for (int a = 2; a < 4; a++)
                    {
                        if (offset >= animation.SM.Length - 1) return;

                        tile = BitManager.GetByte(animation.SM, offset); offset++;
                        prop = BitManager.GetByte(animation.SM, offset); offset++;
                        if (animation.Codec == 1)
                            source = Draw2bppTile8x8(tile, prop);
                        else
                            source = Draw4bppTile8x8(tile, prop);

                        tileset[i].SetSubtile(source, a);
                    }

                    offset -= 32; // jump back in buffer so that we can start the next 16x16 tile
                }
            }
            for (; i < 64; i++) // fill up the rest with empty tiles
            {
                for (int z = 0; z < 4; z++)
                {
                    if (animation.Codec == 1)
                        source = Draw2bppTile8x8(0, 0);
                    else
                        source = Draw4bppTile8x8(0, 0);

                    tileset[i].SetSubtile(source, z);
                }
            }
        }
        private Tile8x8 Draw2bppTile8x8(byte tile, byte temp)
        {
            int offset = tile * 0x10;

            Tile8x8 tempTile;

            if (tile != 0xFF)
            {
                if (offset + 0x10 > graphicSet.Length)
                    tempTile = new Tile8x8(tile, new byte[0x10], 0, animation.GetPaletteSet(paletteSetIndex), false, false, false, true);
                else
                    tempTile = new Tile8x8(tile, graphicSet, offset, animation.GetPaletteSet(paletteSetIndex), false, false, false, true);
            }
            else
                tempTile = new Tile8x8(tile, new byte[0x10], 0, animation.GetPaletteSet(paletteSetIndex), false, false, false, true);

            tempTile.PaletteSetIndex = paletteSetIndex;
            return tempTile;
        }
        private Tile8x8 Draw4bppTile8x8(byte tile, byte temp)
        {
            int offset = tile * 0x20;

            Tile8x8 tempTile;

            if (tile != 0xFF)
            {
                if (offset + 0x20 > graphicSet.Length)
                    tempTile = new Tile8x8(tile, new byte[0x20], 0, animation.GetPaletteSet(paletteSetIndex), false, false, false, false);
                else
                    tempTile = new Tile8x8(tile, graphicSet, offset, animation.GetPaletteSet(paletteSetIndex), false, false, false, false);
            }
            else
                tempTile = new Tile8x8(tile, new byte[0x20], 0, animation.GetPaletteSet(paletteSetIndex), false, false, false, false);

            tempTile.PaletteSetIndex = paletteSetIndex;
            return tempTile;
        }
        public int[] TilesetPixels(Tile16x16[] tiles, int length)
        {
            int[] pixels = new int[128 * 128];

            for (int y = 0; y < length / 64; y++)
            {
                for (int x = 0; x < 8; x++)
                {
                    CopyOverTile16x16(tiles[y * 8 + x], pixels, 128, x, y);
                }
            }
            return pixels;
        }
        public void CopyOverTile16x16(Tile16x16 source, int[] dest, int destinationWidth, int x, int y)
        {
            x *= 16;
            y *= 16;

            CopyOverTile8x8(source.GetSubtile(0), dest, destinationWidth, x, y);
            CopyOverTile8x8(source.GetSubtile(1), dest, destinationWidth, x + 8, y);
            CopyOverTile8x8(source.GetSubtile(2), dest, destinationWidth, x, y + 8);
            CopyOverTile8x8(source.GetSubtile(3), dest, destinationWidth, x + 8, y + 8);
        }
        public void CopyOverTile8x8(Tile8x8 source, int[] dest, int destinationWidth, int x, int y)
        {
            int[] src = source.Pixels;
            int counter = 0;
            for (int i = 0; i < 64; i++)
            {
                dest[y * destinationWidth + x + counter] = src[i];

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
