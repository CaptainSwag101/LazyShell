using System;
using System.Collections.Generic;
using System.Text;

namespace SMRPGED
{
    class BattlefieldTileSet
    {
        private Model model;
        private State state;
        private Battlefield battlefield;
        private PaletteSet paletteSet;
        private byte[] tileSet; public byte[] TileSet { get { return tileSet; } set { tileSet = value; } }
        private byte[] graphicSets; public byte[] GraphicSets { get { return graphicSets; } set { graphicSets = value; } }
        Tile16x16[] tilesetLayer;

        public Tile16x16[] TileSetLayer
        {
            get
            {
                return tilesetLayer;
            }
        }

        public BattlefieldTileSet(Battlefield map, PaletteSet paletteSet, Model model)
        {
            this.model = model; // grab the model
            this.battlefield = map; // grab the current LevelMap
            this.paletteSet = paletteSet; // grab the current Palette Set
            state = State.Instance; // grab an instance of our state

            DecompressTileSetData(); // Decompress our required data

            tilesetLayer = new Tile16x16[32 * 32];

            for (int i = 0; i < tilesetLayer.Length; i++)
                tilesetLayer[i] = new Tile16x16(i);

            DrawTileset(tileSet, tilesetLayer);
        }
        public void RedrawTileset()
        {
            DrawTileset(tileSet, tilesetLayer);
        }
        private void DecompressTileSetData()
        {
            byte[] graphicSet0, graphicSet1, graphicSet2, graphicSet3, graphicSet4;
            byte[] emptyA = new byte[0x2000];
            byte[] emptyB = new byte[0x1000];

            for (int i = 0; i < 0x2000; i++) emptyA[i] = 0;
            for (int i = 0; i < 0x1000; i++) emptyB[i] = 0;

            // Decompress data at offset
            tileSet = model.TileSetsBF[battlefield.TileSet];

            // Decompress graphic sets
            if (battlefield.GraphicSetA > 0xC7) graphicSet0 = emptyA;
            else graphicSet0 = model.GraphicSets[battlefield.GraphicSetA + 0x48];
            if (battlefield.GraphicSetB > 0xC7) graphicSet1 = emptyB;
            else graphicSet1 = model.GraphicSets[battlefield.GraphicSetB + 0x48];
            if (battlefield.GraphicSetC > 0xC7) graphicSet2 = emptyB;
            else graphicSet2 = model.GraphicSets[battlefield.GraphicSetC + 0x48];
            if (battlefield.GraphicSetD > 0xC7) graphicSet3 = emptyB;
            else graphicSet3 = model.GraphicSets[battlefield.GraphicSetD + 0x48];
            if (battlefield.GraphicSetE > 0xC7) graphicSet4 = emptyB;
            else graphicSet4 = model.GraphicSets[battlefield.GraphicSetE + 0x48];

            // Create buffer the size of the combined graphicSets
            graphicSets = new byte[0x7000];
            int index = 0;
            graphicSet0.CopyTo(graphicSets, index); index += 0x2000;
            graphicSet1.CopyTo(graphicSets, index); index += 0x1000;
            graphicSet2.CopyTo(graphicSets, index); index += 0x1000;
            graphicSet3.CopyTo(graphicSets, index); index += 0x1000;
            graphicSet4.CopyTo(graphicSets, index); index += 0x1000;
        }
        public void DrawTileset(byte[] tileset, Tile16x16[] tilesetLayer)
        {
            byte temp, tile;
            Tile8x8 source;
            int offset = 0;

            for (int i = 0; i < tilesetLayer.Length; i++)
            {
                for (int z = 0; z < 2; z++)
                {
                    tile = BitManager.GetByte(tileset, offset); offset++;
                    temp = BitManager.GetByte(tileset, offset); offset++;
                    source = Draw4bppTile8x8(tile, temp);
                    tilesetLayer[i].SetSubtile(source, z);
                }
                offset += 60; // jump forward in buffer to grab correct 8x8 tiles
                for (int a = 2; a < 4; a++)
                {
                    tile = BitManager.GetByte(tileset, offset); offset++;
                    temp = BitManager.GetByte(tileset, offset); offset++;
                    source = Draw4bppTile8x8(tile, temp);
                    tilesetLayer[i].SetSubtile(source, a);
                }

                if ((i - 15) % 16 == 0)
                    offset += 64;
                offset -= 64; // jump back in buffer so that we can start the next 16x16 tile
            }
        }
        private Tile8x8 Draw4bppTile8x8(byte tile, byte temp)
        {
            byte graphicSetIndex, paletteSetIndex;
            int offsetChange;
            bool mirrored, inverted, priorityOne;
            bool twobpp = false;

            graphicSetIndex = (byte)((temp & 0x1F) % 4);
            /* graphicSetIndex equals the graphic set to use
             * ie. if the answer is 3, then it uses graphicSet3 as the data buffer to read from
             * ie. if the answer is 0, then it uses graphicSet0 as the data buffer to read from
             * */
            paletteSetIndex = (byte)((temp & 0x1F) / 4);
            paletteSetIndex--;
            if ((temp & 0x80) == 0x80) inverted = true; else inverted = false;
            if ((temp & 0x40) == 0x40) mirrored = true; else mirrored = false;
            if ((temp & 0x20) == 0x20) priorityOne = true; else priorityOne = false;

            if (graphicSetIndex == 0) offsetChange = 0;
            else if (graphicSetIndex == 1) offsetChange = 0x2000;
            else if (graphicSetIndex == 2) offsetChange = 0x4000;
            else if (graphicSetIndex == 3) offsetChange = 0x6000;
            else if (graphicSetIndex == 4) offsetChange = 0x8000;
            else
            {
                offsetChange = 0;
                graphicSets = null;
                System.Windows.Forms.MessageBox.Show("Problem with Tileset Data: graphicSetIndex invalid, Please report this", "LAZY SHELL");
            }
            //else if (graphicSetIndex == 5) graphicSetData = graphicSet5; // only for layer 3

            int tileDataOffset = (tile * 0x20) + offsetChange;

            if (tileDataOffset >= graphicSets.Length)
                tileDataOffset = 0;


            Tile8x8 tempTile = new Tile8x8(tile, graphicSets, tileDataOffset, paletteSet.GetBattlefieldPalette(paletteSetIndex), mirrored, inverted, priorityOne, twobpp);

            tempTile.GfxSetIndex = graphicSetIndex;
            tempTile.PaletteSetIndex = (byte)(paletteSetIndex + 1);
            return tempTile;

        }

        public int[] GetTilesetPixelArray(bool useFormationBG)
        {
            Tile16x16[] tiles = tilesetLayer;
            int[] pixels = new int[tiles.Length * 256];

            // Quadrant 1

            for (int y = 0; y < tiles.Length / 64; y++)
            {
                for (int x = 0; x < 16; x++)
                {
                    CopyOverTile16x16(tiles[y * 16 + x], pixels, 512, x, y, useFormationBG);
                }
            }

            for (int y = 0; y < tiles.Length / 64; y++)
            {
                for (int x = 0; x < 16; x++)
                {
                    CopyOverTile16x16(tiles[y * 16 + (x + 256)], pixels, 512, x + 16, y, useFormationBG);
                }
            }
            for (int y = 0; y < tiles.Length / 64; y++)
            {
                for (int x = 0; x < 16; x++)
                {
                    CopyOverTile16x16(tiles[y * 16 + x + 512], pixels, 512, x, y + 16, useFormationBG);
                }
            }

            for (int y = 0; y < tiles.Length / 64; y++)
            {
                for (int x = 0; x < 16; x++)
                {
                    CopyOverTile16x16(tiles[y * 16 + (x + 256) + 512], pixels, 512, x + 16, y + 16, useFormationBG);
                }
            }
            return pixels;
        }

        private void CopyOverTile16x16(Tile16x16 source, int[] dest, int destinationWidth, int x, int y, bool useFormationBG)
        {
            x *= 16;
            y *= 16;

            CopyOverTile8x8(source.GetSubtile(0), dest, destinationWidth, x, y, useFormationBG);
            CopyOverTile8x8(source.GetSubtile(1), dest, destinationWidth, x + 8, y, useFormationBG);
            CopyOverTile8x8(source.GetSubtile(2), dest, destinationWidth, x, y + 8, useFormationBG);
            CopyOverTile8x8(source.GetSubtile(3), dest, destinationWidth, x + 8, y + 8, useFormationBG);

        }

        /*
        * This method fills the 16x16 pixel buf with the correct graphics from the
        * 8x8 tiles, but only if we have all the subtiles
        */
        private void CopyOverTile8x8(Tile8x8 source, int[] dest, int destinationWidth, int x, int y, bool useFormationBG)
        {

            int[] src = source.Pixels;
            int counter = 0;
            for (int i = 0; i < 64; i++)
            {
                if (!useFormationBG)
                    dest[(int)((y * destinationWidth) + x + counter)] = src[i];
                else if (useFormationBG && y + 26 < 256 && x - 8 >= 0)
                    dest[(int)(((y + 26) * destinationWidth) + x - 8 + counter)] = src[i];
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
