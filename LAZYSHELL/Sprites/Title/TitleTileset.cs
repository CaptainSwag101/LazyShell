using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;

namespace LAZYSHELL
{
    public class TitleTileset
    {
        private Model model;
        private TitlePalettes titlePalettes;
        private TitlePalettes spritePalettes;
        private byte[] graphicSets; public byte[] GraphicSets { get { return graphicSets; } }
        private byte[] logoGraphicSet; public byte[] LogoGraphicSet { get { return logoGraphicSet; } }
        private byte[][] tileSets = new byte[2][]; public byte[][] TileSets { get { return tileSets; } set { tileSets = value; } }
        private byte[] logoTileSet; public byte[] LogoTileSet { get { return logoTileSet; } set { logoTileSet = value; } }
        Tile16x16[][] tileSetLayers = new Tile16x16[2][]; public Tile16x16[][] TileSetLayers { get { return tileSetLayers; } }
        Tile16x16[] logoTileset; public Tile16x16[] LogoTileset { get { return logoTileset; } }

        public TitleTileset(TitlePalettes titlePalettes, Model model)
        {
            this.model = model;
            this.titlePalettes = titlePalettes;

            // Create our layers for the tilesets (256x512)
            tileSetLayers[0] = new Tile16x16[16 * 32];
            tileSetLayers[1] = new Tile16x16[16 * 32];
            logoTileset = new Tile16x16[16 * 6];

            CreateLayers(); // Create inidividual tiles
            DecompressTileSetData(); // Decompress our required data

            DrawTilesetL1L2(tileSets[0], tileSetLayers[0], graphicSets);
            DrawTilesetL1L2(tileSets[1], tileSetLayers[1], graphicSets);
            DrawTilesetL1L2(logoTileSet, logoTileset, logoGraphicSet);
        }

        private void CreateLayers()
        {
            int i;
            for (i = 0; i < tileSetLayers[0].Length; i++)
                tileSetLayers[0][i] = new Tile16x16(i);
            for (i = 0; i < tileSetLayers[1].Length; i++)
                tileSetLayers[1][i] = new Tile16x16(i);
            for (i = 0; i < logoTileset.Length; i++)
                logoTileset[i] = new Tile16x16(i);
        }
        private void DecompressTileSetData()
        {
            // Decompress data at offsets
            tileSets[0] = BitManager.GetByteArray(model.TitleData, 0x0000, 0x1000);
            tileSets[1] = BitManager.GetByteArray(model.TitleData, 0x1000, 0x1000);
            logoTileSet = BitManager.GetByteArray(model.TitleData, 0xBBE0, 0x300);

            // Create buffer the size of the combined graphicSets
            graphicSets = BitManager.GetByteArray(model.TitleData, 0x6C00, 0x4FE0);
            logoGraphicSet = BitManager.GetByteArray(model.TitleData, 0xBEA0, 0x1BC0);
        }
        public void DrawTilesetL1L2(byte[] tileset, Tile16x16[] tilesetLayer, byte[] gfx)
        {
            byte temp, tile;
            Tile8x8 source;
            int offset = 0;

            for (int i = 0; i < tilesetLayer.Length; i++)
            {
                for (int z = 0; z < 2; z++)
                {
                    tile = BitManager.GetByte(tileset, offset); offset++; // GFX set?
                    temp = BitManager.GetByte(tileset, offset); offset++; // Palette Set?
                    source = Draw4bppTile8x8(tile, temp, gfx);
                    tilesetLayer[i].SetSubtile(source, z);
                }
                offset += 60; // jump forward in buffer to grab correct 8x8 tiles
                for (int a = 2; a < 4; a++)
                {
                    tile = BitManager.GetByte(tileset, offset); offset++;
                    temp = BitManager.GetByte(tileset, offset); offset++;
                    source = Draw4bppTile8x8(tile, temp, gfx);
                    tilesetLayer[i].SetSubtile(source, a);
                }
                if ((i - 15) % 16 == 0)
                    offset += 64;
                offset -= 64; // jump back in buffer so that we can start the next 16x16 tile
            }
        }
        public void RedrawTilesets(int layer)
        {
            if (layer == 0)// || layer == 3)
                DrawTilesetL1L2(tileSets[0], tileSetLayers[0], graphicSets);
            if (layer == 1)// || layer == 3)
                DrawTilesetL1L2(tileSets[1], tileSetLayers[1], graphicSets);
            if (layer == 3) // the logo
                DrawTilesetL1L2(logoTileSet, logoTileset, logoGraphicSet);
        }
        public Tile8x8 Draw4bppTile8x8(byte tile, byte temp, byte[] gfx)
        {
            byte graphicSetIndex, paletteSetIndex;
            bool mirrored, inverted, priorityOne;
            bool twobpp = false;

            graphicSetIndex = (byte)(temp & 0x03);
            /* graphicSetIndex equals the graphic set to use
             * ie. if the answer is 3, then it uses graphicSet3 as the data buffer to read from
             * ie. if the answer is 0, then it uses graphicSet0 as the data buffer to read from
             * */
            paletteSetIndex = (byte)((temp & 0x1C) >> 2);
            if ((temp & 0x80) == 0x80) inverted = true; else inverted = false;
            if ((temp & 0x40) == 0x40) mirrored = true; else mirrored = false;
            if ((temp & 0x20) == 0x20) priorityOne = true; else priorityOne = false;

            int tileDataOffset = (tile * 0x20) + (graphicSetIndex * 0x2000);

            if (tileDataOffset >= gfx.Length)
                tileDataOffset = 0;

            Tile8x8 tempTile;
            tempTile = new Tile8x8(tile, gfx, tileDataOffset, titlePalettes.GetTitlePalette(paletteSetIndex), mirrored, inverted, priorityOne, twobpp);
            tempTile.GfxSetIndex = graphicSetIndex;
            tempTile.PaletteSetIndex = paletteSetIndex;
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

        public int GetTileNumber(int layer, int x, int y)
        {
            if (layer < 3)
                return tileSetLayers[layer][x + y * 16].TileNumber;
            else return 0;
        }
        public int[] GetTilesetPixelArray(Tile16x16[] tiles)
        {
            int[] pixels = new int[tiles.Length * 256];

            for (int y = 0; y < tiles.Length / 16; y++)
            {
                for (int x = 0; x < 16; x++)
                {
                    CopyOverTile16x16(tiles[y * 16 + x], pixels, 256, x, y);
                }
            }
            return pixels;
        }
        public int[] GetSpriteGraphics(int[] palette)
        {
            Tile8x8 temp;
            int[] pixels = new int[128 * 304];
            for (int y = 0; y < 38; y++)
            {
                for (int x = 0; x < 16; x++)
                {
                    int offset = ((y * 16 + x) * 0x20) + 0x2000;
                    temp = new Tile8x8(y * 16 + x, model.TitleData, offset, palette, false, false, false, false);
                    CopyOverTile8x8(temp, pixels, 128, x * 8, y * 8);
                }
            }
            return pixels;
        }
    }
}
