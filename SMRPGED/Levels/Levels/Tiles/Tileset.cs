using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace SMRPGED
{
    public class Tileset
    {
        private Model model;
        private LevelMap levelMap;
        public PaletteSet paletteSet;
        private State state;

        private byte[][] tileSets = new byte[3][]; public byte[][] TileSets { get { return tileSets; } set { tileSets = value; } }
        private byte[] graphicSets; public byte[] GraphicSets { get { return graphicSets; } set { graphicSets = value; } }
        private byte[] graphicSet5; public byte[] GraphicSet5 { get { return graphicSet5; } set { graphicSet5 = value; } }

        Tile16x16[][] tilesetLayers = new Tile16x16[3][]; public Tile16x16[][] TileSetLayers { get { return tilesetLayers; } }

        private int[][] priority1Tint = new int[3][]; public int[][] Priority1Tint { get { return priority1Tint; } }

        public Tileset(LevelMap levelMap, PaletteSet paletteSet, Model model)
        {
            this.model = model; // grab the model
            this.levelMap = levelMap; // grab the current LevelMap
            this.paletteSet = paletteSet; // grab the current Palette Set
            state = State.Instance; // grab an instance of our state

            // Create our layers for the tilesets (256x512)
            tilesetLayers[0] = new Tile16x16[16 * 32];
            tilesetLayers[1] = new Tile16x16[16 * 32];
            tilesetLayers[2] = new Tile16x16[16 * 32];

            CreateLayers(); // Create inidividual tiles
            DecompressTileSetData(); // Decompress our required data

            DrawTilesetL1L2(tileSets[0], tilesetLayers[0]);
            DrawTilesetL1L2(tileSets[1], tilesetLayers[1]);
            if (levelMap.GraphicSetL3 != 0xFF)
                DrawTilesetL3(tileSets[2], tilesetLayers[2]);
        }

        private void CreateLayers()
        {
            int i;
            for (i = 0; i < tilesetLayers[0].Length; i++)
                tilesetLayers[0][i] = new Tile16x16(i);
            for (i = 0; i < tilesetLayers[1].Length; i++)
                tilesetLayers[1][i] = new Tile16x16(i);
            for (i = 0; i < tilesetLayers[2].Length; i++)
                tilesetLayers[2][i] = new Tile16x16(i);

        }
        private void DecompressTileSetData()
        {
            byte[] graphicSet0, graphicSet1, graphicSet2, graphicSet3, graphicSet4;

            // Decompress data at offsets
            tileSets[0] = model.TileSets[levelMap.TileSetL1 + 0x20];
            tileSets[1] = model.TileSets[levelMap.TileSetL2 + 0x20];
            tileSets[2] = model.TileSets[levelMap.TileSetL3];

            // Decompress graphic sets
            graphicSet0 = model.GraphicSets[levelMap.GraphicSetA + 0x48];
            graphicSet1 = model.GraphicSets[levelMap.GraphicSetB + 0x48];
            graphicSet2 = model.GraphicSets[levelMap.GraphicSetC + 0x48];
            graphicSet3 = model.GraphicSets[levelMap.GraphicSetD + 0x48];
            graphicSet4 = model.GraphicSets[levelMap.GraphicSetE + 0x48];
            if (levelMap.GraphicSetL3 != 0xFF) graphicSet5 = model.GraphicSets[levelMap.GraphicSetL3];

            // Create buffer the size of the combined graphicSets
            graphicSets = new byte[0x7000];
            int index = 0;
            graphicSet0.CopyTo(graphicSets, index); index += 0x2000;
            graphicSet1.CopyTo(graphicSets, index); index += 0x1000;
            graphicSet2.CopyTo(graphicSets, index); index += 0x1000;
            graphicSet3.CopyTo(graphicSets, index); index += 0x1000;
            graphicSet4.CopyTo(graphicSets, index); index += 0x1000;
        }

        public void DrawTilesetL1L2(byte[] tileset, Tile16x16[] tilesetLayer)
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
        public void DrawTilesetL3(byte[] tileset, Tile16x16[] tilesetLayer)
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
                    source = Draw2bppTile8x8(tile, temp);
                    tilesetLayer[i].SetSubtile(source, z);
                }
                offset += 60; // jump forward in buffer to grab correct 8x8 tiles
                for (int a = 2; a < 4; a++)
                {
                    tile = BitManager.GetByte(tileset, offset); offset++;
                    temp = BitManager.GetByte(tileset, offset); offset++;
                    source = Draw2bppTile8x8(tile, temp);
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
                DrawTilesetL1L2(tileSets[0], tilesetLayers[0]);
            if (layer == 1)// || layer == 3)
                DrawTilesetL1L2(tileSets[1], tilesetLayers[1]);
            if (layer == 2)// || layer == 3)
            {
                if (levelMap.GraphicSetL3 != 0xFF)
                    DrawTilesetL3(tileSets[2], tilesetLayers[2]);
            }
        }

        private Tile8x8 Draw2bppTile8x8(byte tile, byte temp)
        {
            byte paletteSetIndex;
            bool mirrored, inverted, priorityOne;
            bool twobpp = true;

            paletteSetIndex = (byte)((temp & 0x1F) / 4);
            paletteSetIndex -= 4;
            if ((temp & 0x80) == 0x80) inverted = true; else inverted = false;
            if ((temp & 0x40) == 0x40) mirrored = true; else mirrored = false;
            if ((temp & 0x20) == 0x20) priorityOne = true; else priorityOne = false;

            int tileDataOffset = (tile * 0x10);

            if (tileDataOffset >= graphicSet5.Length)
                tileDataOffset = 0;

            Tile8x8 tempTile = new Tile8x8(tile, graphicSet5, tileDataOffset, paletteSet.Get2bppPalette(paletteSetIndex), mirrored, inverted, priorityOne, twobpp);
            tempTile.PaletteSetIndex = (byte)(paletteSetIndex + 4);
            tempTile.GfxSetIndex = 4;
            return tempTile;
        }
        public Tile8x8 Draw4bppTile8x8(byte tile, byte temp)
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
                MessageBox.Show("Problem with Tileset Data: graphicSetIndex invalid, Please report this", "LAZY SHELL");
            }
            //else if (graphicSetIndex == 5) graphicSetData = graphicSet5; // only for layer 3

            int tileDataOffset = (tile * 0x20) + offsetChange;

            if (tileDataOffset >= graphicSets.Length)
                tileDataOffset = 0;

            Tile8x8 tempTile = new Tile8x8(tile, graphicSets, tileDataOffset, paletteSet.Get4bppPalette(paletteSetIndex), mirrored, inverted, priorityOne, twobpp);
            tempTile.GfxSetIndex = graphicSetIndex;
            tempTile.PaletteSetIndex = (byte)(paletteSetIndex + 1);
            return tempTile;

        }

        public void CopyOverTile16x16(Tile16x16 source, int[] dest, int destinationWidth, int x, int y, int layer)
        {
            x *= 16;
            y *= 16;

            CopyOverTile8x8(source.GetSubtile(0), dest, destinationWidth, x, y, layer);
            CopyOverTile8x8(source.GetSubtile(1), dest, destinationWidth, x + 8, y, layer);
            CopyOverTile8x8(source.GetSubtile(2), dest, destinationWidth, x, y + 8, layer);
            CopyOverTile8x8(source.GetSubtile(3), dest, destinationWidth, x + 8, y + 8, layer);
        }
        public void CopyOverTile8x8(Tile8x8 source, int[] dest, int destinationWidth, int x, int y, int layer)
        {
            int[] src = source.Pixels;
            int counter = 0;
            for (int i = 0; i < 64; i++)
            {
                dest[y * destinationWidth + x + counter] = src[i];

                if (src[i] != 0 && source.PriorityOne)
                    priority1Tint[layer][y * destinationWidth + x + counter] = Color.Blue.ToArgb();

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
                return tilesetLayers[layer][x + y * 16].TileNumber;
            else return 0;
        }
        public int[] GetTilesetPixelArray(Tile16x16[] tiles, int layer)
        {
            int[] pixels = new int[tiles.Length * 256];

            priority1Tint[layer] = new int[256 * 512];

            for (int y = 0; y < tiles.Length / 16; y++)
            {
                for (int x = 0; x < 16; x++)
                {
                    CopyOverTile16x16(tiles[y * 16 + x], pixels, 256, x, y, layer);
                }
            }
            return pixels;
        }

        public void Clear(int count)
        {
            if (count == 1)
            {
                model.TileSets[levelMap.TileSetL1 + 0x20] = new byte[0x2000];
                model.TileSets[levelMap.TileSetL2 + 0x20] = new byte[0x2000];
                model.TileSets[levelMap.TileSetL3] = new byte[0x1000];

                model.EditTileSets[levelMap.TileSetL1 + 0x20] = true;
                model.EditTileSets[levelMap.TileSetL2 + 0x20] = true;
                model.EditTileSets[levelMap.TileSetL3] = true;
            }
            else
            {
                for (int i = 0; i < count; i++)
                {
                    if (i < 0x20)
                        model.TileSets[i] = new byte[0x1000];
                    else
                        model.TileSets[i] = new byte[0x2000];

                    model.EditTileSets[i] = true;
                }
            }
            for (int i = 0; i < 3; i++) RedrawTilesets(i);
        }
    }
}
