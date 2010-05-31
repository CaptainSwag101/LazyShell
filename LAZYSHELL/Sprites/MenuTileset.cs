using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LAZYSHELL
{
    class MenuTileset
    {
        private Model model;
        public int[] palette;

        private byte[] tileSet; public byte[] TileSet { get { return tileSet; } set { tileSet = value; } }
        private byte[] graphicSet; public byte[] GraphicSet { get { return graphicSet; } set { graphicSet = value; } }

        Tile16x16[] tileset; public Tile16x16[] Tileset { get { return tileset; } }

        public MenuTileset(Model model, int[] palette)
        {
            this.model = model; // grab the model
            this.palette = palette; // grab the current Palette Set

            // Create our layers for the tilesets (256x512)
            tileset = new Tile16x16[16 * 16];

            for (int i = 0; i < tileset.Length; i++)
                tileset[i] = new Tile16x16(i);
            DecompressTileSetData(); // Decompress our required data

            DrawTileset(tileSet, tileset);
        }
        private void DecompressTileSetData()
        {
            // Decompress data at offsets
            tileSet = model.MenuTileset;

            // Decompress graphic sets
            graphicSet = model.MenuGraphicSet;
        }

        public void DrawTileset(byte[] tileset, Tile16x16[] tileSet)
        {
            byte temp, tile;
            Tile8x8 source;
            int offset = 0;

            for (int i = 0; i < tileSet.Length; i++)
            {
                for (int z = 0; z < 2; z++)
                {
                    tile = BitManager.GetByte(tileset, offset); offset++; // GFX set?
                    temp = BitManager.GetByte(tileset, offset); offset++; // Palette Set?
                    source = Draw4bppTile8x8(tile, temp);
                    tileSet[i].SetSubtile(source, z);
                }
                offset += 60; // jump forward in buffer to grab correct 8x8 tiles
                for (int a = 2; a < 4; a++)
                {
                    tile = BitManager.GetByte(tileset, offset); offset++;
                    temp = BitManager.GetByte(tileset, offset); offset++;
                    source = Draw4bppTile8x8(tile, temp);
                    tileSet[i].SetSubtile(source, a);
                }
                if ((i - 15) % 16 == 0)
                    offset += 64;
                offset -= 64; // jump back in buffer so that we can start the next 16x16 tile
            }
        }
        public void RedrawTileset()
        {
            DrawTileset(tileSet, tileset);
        }

        public Tile8x8 Draw4bppTile8x8(byte tile, byte temp)
        {
            byte paletteSetIndex;
            bool mirrored, inverted, priorityOne;
            bool twobpp = false;

            paletteSetIndex = (byte)((temp & 0x1F) / 4);
            paletteSetIndex--;
            if ((temp & 0x80) == 0x80) inverted = true; else inverted = false;
            if ((temp & 0x40) == 0x40) mirrored = true; else mirrored = false;
            if ((temp & 0x20) == 0x20) priorityOne = true; else priorityOne = false;

            int tileDataOffset = tile * 0x20;

            if (tileDataOffset >= graphicSet.Length)
                tileDataOffset = 0;

            Tile8x8 tempTile = new Tile8x8(tile, graphicSet, tileDataOffset, palette, mirrored, inverted, priorityOne, twobpp);
            tempTile.GfxSetIndex = 0;
            tempTile.PaletteSetIndex = (byte)(paletteSetIndex + 1);
            return tempTile;

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

        public int GetTileNumber(int x, int y)
        {
            return tileset[x + y * 16].TileNumber;
        }
        public int[] GetTilesetPixelArray()
        {
            int[] pixels = new int[256 * 256];

            for (int y = 0; y < 16; y++)
            {
                for (int x = 0; x < 16; x++)
                {
                    CopyOverTile16x16(tileset[y * 16 + x], pixels, 256, x, y);
                }
            }
            return pixels;
        }

        public void Clear(int count)
        {
            model.EditMenuTileSet = true;
            RedrawTileset();
        }
    }
}
