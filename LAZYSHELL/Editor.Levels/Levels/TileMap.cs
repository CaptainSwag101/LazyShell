using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace LAZYSHELL
{
    public class TileMap
    {
        #region Variables
                private TileSet tileset;
        private LevelMap levelMap;
        private PaletteSet paletteSet;
        private LevelLayer levelLayer;
        private PrioritySet[] prioritySets;
        private State state = State.Instance;
        private string type = "";
        public Size Size { get { return new Size(width, height); } }
        public Size Size_p { get { return new Size(width_p, height_p); } }
        private int width = 64;
        private int height = 64;
        private int width_p { get { return width * 16; } }
        private int height_p { get { return height * 16; } }
        private byte[][] tileMaps = new byte[3][];
        public byte[][] TileMaps { get { return tileMaps; } set { tileMaps = value; } }
        private Tile16x16[][] layers = new Tile16x16[3][];
        public Tile16x16[][] Layers { get { return layers; } set { layers = value; } }
        private int[] mainscreen = new int[1024 * 1024];
        public int[] Mainscreen { get { return mainscreen; } }
        private int[] subscreen = null;
        private int[] colorMath = null;
        private int[] tile = new int[256];
        private int[] tileColorMath = new int[256];
        public int[]
            layer1Priority0 = new int[1024 * 1024],
            layer1Priority1 = new int[1024 * 1024],
            layer2Priority0 = new int[1024 * 1024],
            layer2Priority1 = new int[1024 * 1024],
            layer3Priority0 = new int[1024 * 1024],
            layer3Priority1 = new int[1024 * 1024];
        #endregion
        public TileMap(Level level, TileSet tileset)
        {
            this.tileset = tileset;
            this.levelMap = Model.LevelMaps[level.LevelMap];
            this.paletteSet = Model.PaletteSets[levelMap.PaletteSet];
            this.prioritySets = Model.PrioritySets;
            this.levelLayer = level.Layer;
            this.type = "level";
            tileMaps[0] = Model.TileMaps[levelMap.TileMapL1 + 0x40];
            tileMaps[1] = Model.TileMaps[levelMap.TileMapL2 + 0x40];
            tileMaps[2] = Model.TileMaps[levelMap.TileMapL3];
            for (int i = 0; i < 3; i++)
                CreateLayer(i); // Create any required layers
            DrawAllLayers();
            if ((prioritySets[levelLayer.PrioritySet].SubscreenL1 && state.Layer1) ||
                (prioritySets[levelLayer.PrioritySet].SubscreenL2 && state.Layer2) ||
                (prioritySets[levelLayer.PrioritySet].SubscreenL3 && state.Layer3) ||
                (prioritySets[levelLayer.PrioritySet].SubscreenOBJ && state.NPCs))
            {
                if (subscreen == null)
                    subscreen = new int[1024 * 1024];
                CreateSubscreen(); // Create the subscreen if needed
            }
            CreateMainscreen();
        }
        public TileMap(Level level, TileSet tileset, LevelTemplate template)
        {
            this.tileset = tileset;
            this.levelMap = Model.LevelMaps[level.LevelMap];
            this.paletteSet = Model.PaletteSets[levelMap.PaletteSet];
            this.prioritySets = Model.PrioritySets;
            this.levelLayer = level.Layer;
            this.type = "template";
            tileMaps[0] = new byte[0x2000];
            tileMaps[1] = new byte[0x2000];
            tileMaps[2] = new byte[0x1000];
            for (int y = 0; y < template.Size.Height / 16; y++)
            {
                for (int x = 0; x < template.Size.Width / 16; x++)
                {
                    Bits.SetShort(tileMaps[0], (y * 64 + x) * 2,
                        Bits.GetShort(template.Tilemaps[0], (y * (template.Size.Width / 16) + x) * 2));
                    Bits.SetShort(tileMaps[1], (y * 64 + x) * 2,
                        Bits.GetShort(template.Tilemaps[1], (y * (template.Size.Width / 16) + x) * 2));
                    tileMaps[2][y * 64 + x] = template.Tilemaps[2][y * (template.Size.Width / 16) + x];
                }
            }
            for (int i = 0; i < 3; i++)
                CreateLayer(i); // Create any required layers
            DrawAllLayers();
            if ((prioritySets[levelLayer.PrioritySet].SubscreenL1 && state.Layer1) ||
                (prioritySets[levelLayer.PrioritySet].SubscreenL2 && state.Layer2) ||
                (prioritySets[levelLayer.PrioritySet].SubscreenL3 && state.Layer3) ||
                (prioritySets[levelLayer.PrioritySet].SubscreenOBJ && state.NPCs))
            {
                if (subscreen == null)
                    subscreen = new int[1024 * 1024];
                CreateSubscreen(); // Create the subscreen if needed
            }
            CreateMainscreen();
        }
        public TileMap(Level level, TileSet tileset, LevelTileMods.Mod mod, bool set)
        {
            this.tileset = tileset;
            this.levelMap = Model.LevelMaps[level.LevelMap];
            this.paletteSet = Model.PaletteSets[levelMap.PaletteSet];
            this.prioritySets = Model.PrioritySets;
            this.levelLayer = level.Layer;
            this.type = "mod";
            this.width = mod.Width;
            this.height = mod.Height;
            layer1Priority0 = new int[width_p * height_p];
            layer1Priority1 = new int[width_p * height_p];
            layer2Priority0 = new int[width_p * height_p];
            layer2Priority1 = new int[width_p * height_p];
            layer3Priority0 = new int[width_p * height_p];
            layer3Priority1 = new int[width_p * height_p];
            mainscreen = new int[width_p * height_p];
            if (!set)
                this.tileMaps = mod.TilemapsA;
            else
                this.tileMaps = mod.TilemapsB;
            for (int i = 0; i < 3; i++)
                CreateLayer(i); // Create any required layers
            DrawAllLayers();
            if ((prioritySets[levelLayer.PrioritySet].SubscreenL1 && state.Layer1) ||
                (prioritySets[levelLayer.PrioritySet].SubscreenL2 && state.Layer2) ||
                (prioritySets[levelLayer.PrioritySet].SubscreenL3 && state.Layer3) ||
                (prioritySets[levelLayer.PrioritySet].SubscreenOBJ && state.NPCs))
            {
                if (subscreen == null)
                    subscreen = new int[width_p * height_p];
                CreateSubscreen(); // Create the subscreen if needed
            }
            CreateMainscreen();
        }
        private void DrawAllLayers()
        {
            if (prioritySets[levelLayer.PrioritySet].SubscreenL1 || prioritySets[levelLayer.PrioritySet].MainscreenL1)
            {
                DrawLayerByPriorityOne(layer1Priority0, 0, false);
                DrawLayerByPriorityOne(layer1Priority1, 0, true);
            }
            if (prioritySets[levelLayer.PrioritySet].SubscreenL2 || prioritySets[levelLayer.PrioritySet].MainscreenL2)
            {
                DrawLayerByPriorityOne(layer2Priority0, 1, false);
                DrawLayerByPriorityOne(layer2Priority1, 1, true);
            }
            if ((prioritySets[levelLayer.PrioritySet].SubscreenL3 || prioritySets[levelLayer.PrioritySet].MainscreenL3) && levelMap.GraphicSetL3 != 0xFF)
            {
                DrawLayerByPriorityOne(layer3Priority0, 2, false);
                DrawLayerByPriorityOne(layer3Priority1, 2, true);
            }
        }
        public int[] GetRangePixels(int layer, Point p, Size s)
        {
            int[] pixels = new int[s.Width * s.Height];
            switch (layer)
            {
                case 0:
                    for (int b = 0, y = p.Y; b < s.Height; b++, y++)
                    {
                        for (int a = 0, x = p.X; a < s.Width; a++, x++)
                        {
                            pixels[b * s.Width + a] = layer1Priority0[y * width_p + x];
                            if (layer1Priority1[y * width_p + x] != 0)
                                pixels[b * s.Width + a] = layer1Priority1[y * width_p + x];
                        }
                    }
                    break;
                case 1:
                    for (int b = 0, y = p.Y; b < s.Height; b++, y++)
                    {
                        for (int a = 0, x = p.X; a < s.Width; a++, x++)
                        {
                            pixels[b * s.Width + a] = layer2Priority0[y * width_p + x];
                            if (layer2Priority1[y * width_p + x] != 0)
                                pixels[b * s.Width + a] = layer2Priority1[y * width_p + x];
                        }
                    }
                    break;
                case 2:
                    for (int b = 0, y = p.Y; b < s.Height; b++, y++)
                    {
                        for (int a = 0, x = p.X; a < s.Width; a++, x++)
                        {
                            pixels[b * s.Width + a] = layer3Priority0[y * width_p + x];
                            if (layer3Priority1[y * width_p + x] != 0)
                                pixels[b * s.Width + a] = layer3Priority1[y * width_p + x];
                        }
                    }
                    break;
                default:
                    goto case 0;
            }
            return pixels;
        }
        public int[] GetRangePixels(Point p, Size s)
        {
            int[] pixels = new int[s.Width * s.Height];

            for (int b = 0, y = p.Y; b < s.Height; b++, y++)
            {
                for (int a = 0, x = p.X; a < s.Width; a++, x++)
                    pixels[b * s.Width + a] = Color.FromArgb(255, Color.FromArgb(mainscreen[y * width_p + x])).ToArgb();
            }
            return pixels;
        }
        /*
         * This method just redraws an existing tilemap
         */
        public void RedrawTileMap()
        {
            layer1Priority1 = new int[width_p * height_p];
            layer2Priority1 = new int[width_p * height_p];
            layer3Priority1 = new int[width_p * height_p];

            DrawAllLayers();

            Bits.Clear(mainscreen);
            if (subscreen != null)
                Bits.Clear(subscreen);

            if ((prioritySets[levelLayer.PrioritySet].SubscreenL1 && state.Layer1) ||
                    (prioritySets[levelLayer.PrioritySet].SubscreenL2 && state.Layer2) ||
                    (prioritySets[levelLayer.PrioritySet].SubscreenL3 && state.Layer3) ||
                    (prioritySets[levelLayer.PrioritySet].SubscreenOBJ && state.NPCs))
            {
                if (subscreen == null)
                    subscreen = new int[width_p * height_p];
                CreateSubscreen(); // Create the subscreen if needed
            }

            CreateMainscreen();
        }
        private void ChangeSingleTile(int layer, int placement, int tile, int x, int y)
        {
            layers[layer][placement] = tileset.TileSetLayers[layer][tile]; // Change the tile in the layer map

            Tile16x16 source = layers[layer][placement]; // Grab the new tile

            int[] layerA = null, layerB = null; // Just used to save space

            if (layer == 0)
            {
                layerA = layer1Priority0;
                layerB = layer1Priority1;
            }
            else if (layer == 1)
            {
                layerA = layer2Priority0;
                layerB = layer2Priority1;
            }
            else if (layer == 2)
            {
                layerA = layer3Priority0;
                layerB = layer3Priority1;
            }

            ClearSingleTile(layerA, x, y);
            ClearSingleTile(layerB, x, y);

            // Draw all 4 subtiles to the appropriate array based on priority
            if (!source.Subtiles[0].PriorityOne) // tile 0
                Do.PixelsToPixels(source.Subtiles[0].Pixels, layerA, width_p, new Rectangle(x, y, 8, 8));
            else
                Do.PixelsToPixels(source.Subtiles[0].Pixels, layerB, width_p, new Rectangle(x, y, 8, 8));
            if (!source.Subtiles[1].PriorityOne) // tile 1
                Do.PixelsToPixels(source.Subtiles[1].Pixels, layerA, width_p, new Rectangle((x + 8), y, 8, 8));
            else
                Do.PixelsToPixels(source.Subtiles[1].Pixels, layerB, width_p, new Rectangle((x + 8), y, 8, 8));
            if (!source.Subtiles[2].PriorityOne) // tile 2
                Do.PixelsToPixels(source.Subtiles[2].Pixels, layerA, width_p, new Rectangle(x, (y + 8), 8, 8));
            else
                Do.PixelsToPixels(source.Subtiles[2].Pixels, layerB, width_p, new Rectangle(x, (y + 8), 8, 8));
            if (!source.Subtiles[3].PriorityOne) // tile 3
                Do.PixelsToPixels(source.Subtiles[3].Pixels, layerA, width_p, new Rectangle((x + 8), (y + 8), 8, 8));
            else
                Do.PixelsToPixels(source.Subtiles[3].Pixels, layerB, width_p, new Rectangle((x + 8), (y + 8), 8, 8));

            // If we have a subscreen, draw the new tile to it
            if ((prioritySets[levelLayer.PrioritySet].SubscreenL1 && state.Layer1) ||
                (prioritySets[levelLayer.PrioritySet].SubscreenL2 && state.Layer2) ||
                (prioritySets[levelLayer.PrioritySet].SubscreenL3 && state.Layer3) ||
                (prioritySets[levelLayer.PrioritySet].SubscreenOBJ && state.NPCs))
            {
                ClearSingleTile(subscreen, x, y);
                DrawSingleSubscreenTile(x, y);
            }
            ClearSingleTile(mainscreen, x, y);
            DrawSingleMainscreenTile(x, y);
        }
        private void ClearSingleTile(int[] arr, int x, int y)
        {
            int counter = 0;
            for (int i = 0; i < 256; i++)
            {
                arr[y * width_p + x + counter] = 0;

                counter++;
                if (counter % 16 == 0)
                {
                    y++;
                    counter = 0;
                }
            }
        }
        private void DrawSingleSubscreenTile(int x, int y)
        {
            if (levelMap.TopPriorityL3) //[3,0][2,0][1,0][2,1][1,1][3,1]
            {
                if (prioritySets[levelLayer.PrioritySet].SubscreenL3 && state.Layer3 && levelMap.GraphicSetL3 != 0xFF)
                {
                    tile = GetTileFromPriorityArray(layer3Priority0, x, y);
                    CopySingleTileToArray(subscreen, tile, width_p, x, y);
                    Bits.Clear(tile);
                }
                if (prioritySets[levelLayer.PrioritySet].SubscreenL2 && state.Layer2)
                {
                    tile = GetTileFromPriorityArray(layer2Priority0, x, y);
                    CopySingleTileToArray(subscreen, tile, width_p, x, y);
                    Bits.Clear(tile);
                }
                if (prioritySets[levelLayer.PrioritySet].SubscreenL1 && state.Layer1)
                {
                    tile = GetTileFromPriorityArray(layer1Priority0, x, y);
                    CopySingleTileToArray(subscreen, tile, width_p, x, y);
                    Bits.Clear(tile);
                }
                if (prioritySets[levelLayer.PrioritySet].SubscreenL2 && state.Layer2)
                {
                    tile = GetTileFromPriorityArray(layer2Priority1, x, y);
                    CopySingleTileToArray(subscreen, tile, width_p, x, y);
                    Bits.Clear(tile);
                }
                if (prioritySets[levelLayer.PrioritySet].SubscreenL1 && state.Layer1)
                {
                    tile = GetTileFromPriorityArray(layer1Priority1, x, y);
                    CopySingleTileToArray(subscreen, tile, width_p, x, y);
                    Bits.Clear(tile);
                }
                if (prioritySets[levelLayer.PrioritySet].SubscreenL3 && state.Layer3 && levelMap.GraphicSetL3 != 0xFF)
                {
                    tile = GetTileFromPriorityArray(layer3Priority1, x, y);
                    CopySingleTileToArray(subscreen, tile, width_p, x, y);
                    Bits.Clear(tile);
                }
            }
            else if (!levelMap.TopPriorityL3) //[3,0][3,1][2,0][1,0][2,1][1,1]
            {
                if (prioritySets[levelLayer.PrioritySet].SubscreenL3 && state.Layer3 && levelMap.GraphicSetL3 != 0xFF)
                {
                    tile = GetTileFromPriorityArray(layer3Priority0, x, y);
                    CopySingleTileToArray(subscreen, tile, width_p, x, y);
                    Bits.Clear(tile);
                }
                if (prioritySets[levelLayer.PrioritySet].SubscreenL3 && state.Layer3 && levelMap.GraphicSetL3 != 0xFF)
                {
                    tile = GetTileFromPriorityArray(layer3Priority1, x, y);
                    CopySingleTileToArray(subscreen, tile, width_p, x, y);
                    Bits.Clear(tile);
                }
                if (prioritySets[levelLayer.PrioritySet].SubscreenL2 && state.Layer2)
                {
                    tile = GetTileFromPriorityArray(layer2Priority0, x, y);
                    CopySingleTileToArray(subscreen, tile, width_p, x, y);
                    Bits.Clear(tile);
                }
                if (prioritySets[levelLayer.PrioritySet].SubscreenL1 && state.Layer1)
                {
                    tile = GetTileFromPriorityArray(layer1Priority0, x, y);
                    CopySingleTileToArray(subscreen, tile, width_p, x, y);
                    Bits.Clear(tile);
                }
                if (prioritySets[levelLayer.PrioritySet].SubscreenL2 && state.Layer2)
                {
                    tile = GetTileFromPriorityArray(layer2Priority1, x, y);
                    CopySingleTileToArray(subscreen, tile, width_p, x, y);
                    Bits.Clear(tile);
                }
                if (prioritySets[levelLayer.PrioritySet].SubscreenL1 && state.Layer1)
                {
                    tile = GetTileFromPriorityArray(layer1Priority1, x, y);
                    CopySingleTileToArray(subscreen, tile, width_p, x, y);
                    Bits.Clear(tile);
                }
            }
        }
        private void CopySingleTileToArray(int[] dest, int[] source, int width, int x, int y)
        {
            int counter = 0;
            for (int i = 0; i < 256; i++)
            {
                if (source[i] != 0)
                    dest[y * width + x + counter] = source[i];

                counter++;
                if (counter % 16 == 0)
                {
                    y++;
                    counter = 0;
                }
            }

        }
        private void DrawSingleMainscreenTile(int x, int y)
        {
            int bgcolor = paletteSet.Palette[16];
            Bits.Clear(tile);
            Bits.Clear(tileColorMath);
            if (HaveSubscreen())
            {
                if (prioritySets[levelLayer.PrioritySet].ColorMathBG && state.BG)
                {
                    for (int i = 0; i < 256; i++)
                        tileColorMath[i] = bgcolor;
                    DoColorMathOnSingleTile(tileColorMath, x, y);
                    CopySingleTileToArray(mainscreen, tileColorMath, width_p, x, y);
                    Bits.Clear(tileColorMath);
                }
                else if (state.BG)
                {
                    for (int i = 0; i < 256; i++)
                        tileColorMath[i] = bgcolor;
                    CopySingleTileToArray(mainscreen, tileColorMath, width_p, x, y);
                    Bits.Clear(tileColorMath);
                }

                if (levelMap.TopPriorityL3) // [3,0][2,0][1,0][2,1][1,1][3,1]
                {
                    if (prioritySets[levelLayer.PrioritySet].MainscreenL3 && state.Layer3 && levelMap.GraphicSetL3 != 0xFF)
                    {
                        tileColorMath = GetTileFromPriorityArray(layer3Priority0, x, y);
                        if (prioritySets[levelLayer.PrioritySet].ColorMathL3)
                            DoColorMathOnSingleTile(tileColorMath, x, y);
                        CopySingleTileToArray(mainscreen, tileColorMath, width_p, x, y);
                        Bits.Clear(tileColorMath);
                    }
                    if (prioritySets[levelLayer.PrioritySet].MainscreenL2 && state.Layer2)
                    {
                        tileColorMath = GetTileFromPriorityArray(layer2Priority0, x, y);
                        if (prioritySets[levelLayer.PrioritySet].ColorMathL2)
                            DoColorMathOnSingleTile(tileColorMath, x, y);
                        CopySingleTileToArray(mainscreen, tileColorMath, width_p, x, y);
                        Bits.Clear(tileColorMath);
                    }
                    if (prioritySets[levelLayer.PrioritySet].MainscreenL1 && state.Layer1)
                    {
                        tileColorMath = GetTileFromPriorityArray(layer1Priority0, x, y);
                        if (prioritySets[levelLayer.PrioritySet].ColorMathL1)
                            DoColorMathOnSingleTile(tileColorMath, x, y);
                        CopySingleTileToArray(mainscreen, tileColorMath, width_p, x, y);
                        Bits.Clear(tileColorMath);
                    }
                    if (prioritySets[levelLayer.PrioritySet].MainscreenL2 && state.Layer2)
                    {
                        tileColorMath = GetTileFromPriorityArray(layer2Priority1, x, y);
                        if (prioritySets[levelLayer.PrioritySet].ColorMathL2)
                            DoColorMathOnSingleTile(tileColorMath, x, y);
                        CopySingleTileToArray(mainscreen, tileColorMath, width_p, x, y);
                        Bits.Clear(tileColorMath);
                    }
                    if (prioritySets[levelLayer.PrioritySet].MainscreenL1 && state.Layer1)
                    {
                        tileColorMath = GetTileFromPriorityArray(layer1Priority1, x, y);
                        if (prioritySets[levelLayer.PrioritySet].ColorMathL1)
                            DoColorMathOnSingleTile(tileColorMath, x, y);
                        CopySingleTileToArray(mainscreen, tileColorMath, width_p, x, y);
                        Bits.Clear(tileColorMath);
                    }
                    if (prioritySets[levelLayer.PrioritySet].MainscreenL3 && state.Layer3 && levelMap.GraphicSetL3 != 0xFF)
                    {
                        tileColorMath = GetTileFromPriorityArray(layer3Priority1, x, y);
                        if (prioritySets[levelLayer.PrioritySet].ColorMathL3)
                            DoColorMathOnSingleTile(tileColorMath, x, y);
                        CopySingleTileToArray(mainscreen, tileColorMath, width_p, x, y);
                        Bits.Clear(tileColorMath);
                    }
                }
                else if (!levelMap.TopPriorityL3) // [3,0][3,1][2,0][1,0][2,1][1,1]
                {
                    if (prioritySets[levelLayer.PrioritySet].MainscreenL3 && state.Layer3 && levelMap.GraphicSetL3 != 0xFF)
                    {
                        tileColorMath = GetTileFromPriorityArray(layer3Priority0, x, y);
                        if (prioritySets[levelLayer.PrioritySet].ColorMathL3)
                            DoColorMathOnSingleTile(tileColorMath, x, y);
                        CopySingleTileToArray(mainscreen, tileColorMath, width_p, x, y);
                        Bits.Clear(tileColorMath);
                    }
                    if (prioritySets[levelLayer.PrioritySet].MainscreenL3 && state.Layer3 && levelMap.GraphicSetL3 != 0xFF)
                    {
                        tileColorMath = GetTileFromPriorityArray(layer3Priority1, x, y);
                        if (prioritySets[levelLayer.PrioritySet].ColorMathL3)
                            DoColorMathOnSingleTile(tileColorMath, x, y);
                        CopySingleTileToArray(mainscreen, tileColorMath, width_p, x, y);
                        Bits.Clear(tileColorMath);
                    }
                    if (prioritySets[levelLayer.PrioritySet].MainscreenL2 && state.Layer2)
                    {
                        tileColorMath = GetTileFromPriorityArray(layer2Priority0, x, y);
                        if (prioritySets[levelLayer.PrioritySet].ColorMathL2)
                            DoColorMathOnSingleTile(tileColorMath, x, y);
                        CopySingleTileToArray(mainscreen, tileColorMath, width_p, x, y);
                        Bits.Clear(tileColorMath);
                    }
                    if (prioritySets[levelLayer.PrioritySet].MainscreenL1 && state.Layer1)
                    {
                        tileColorMath = GetTileFromPriorityArray(layer1Priority0, x, y);
                        if (prioritySets[levelLayer.PrioritySet].ColorMathL1)
                            DoColorMathOnSingleTile(tileColorMath, x, y);
                        CopySingleTileToArray(mainscreen, tileColorMath, width_p, x, y);
                        Bits.Clear(tileColorMath);
                    }
                    if (prioritySets[levelLayer.PrioritySet].MainscreenL2 && state.Layer2)
                    {
                        tileColorMath = GetTileFromPriorityArray(layer2Priority1, x, y);
                        if (prioritySets[levelLayer.PrioritySet].ColorMathL2)
                            DoColorMathOnSingleTile(tileColorMath, x, y);
                        CopySingleTileToArray(mainscreen, tileColorMath, width_p, x, y);
                        Bits.Clear(tileColorMath);
                    }
                    if (prioritySets[levelLayer.PrioritySet].MainscreenL1 && state.Layer1)
                    {
                        tileColorMath = GetTileFromPriorityArray(layer1Priority1, x, y);
                        if (prioritySets[levelLayer.PrioritySet].ColorMathL1)
                            DoColorMathOnSingleTile(tileColorMath, x, y);
                        CopySingleTileToArray(mainscreen, tileColorMath, width_p, x, y);
                        Bits.Clear(tileColorMath);
                    }
                }
            }
            else // No color math, we can go ahead and draw the mainscreen
            {
                if (levelMap.TopPriorityL3) // [3,0][2,0][1,0][2,1][1,1][3,1]
                {
                    if (prioritySets[levelLayer.PrioritySet].MainscreenL3 && state.Layer3 && levelMap.GraphicSetL3 != 0xFF)
                        CopySingleTileToArray(mainscreen, GetTileFromPriorityArray(layer3Priority0, x, y), width_p, x, y);
                    if (prioritySets[levelLayer.PrioritySet].MainscreenL2 && state.Layer2)
                        CopySingleTileToArray(mainscreen, GetTileFromPriorityArray(layer2Priority0, x, y), width_p, x, y);
                    if (prioritySets[levelLayer.PrioritySet].MainscreenL1 && state.Layer1)
                        CopySingleTileToArray(mainscreen, GetTileFromPriorityArray(layer1Priority0, x, y), width_p, x, y);
                    if (prioritySets[levelLayer.PrioritySet].MainscreenL2 && state.Layer2)
                        CopySingleTileToArray(mainscreen, GetTileFromPriorityArray(layer2Priority1, x, y), width_p, x, y);
                    if (prioritySets[levelLayer.PrioritySet].MainscreenL1 && state.Layer1)
                        CopySingleTileToArray(mainscreen, GetTileFromPriorityArray(layer1Priority1, x, y), width_p, x, y);
                    if (prioritySets[levelLayer.PrioritySet].MainscreenL3 && state.Layer3 && levelMap.GraphicSetL3 != 0xFF)
                        CopySingleTileToArray(mainscreen, GetTileFromPriorityArray(layer3Priority1, x, y), width_p, x, y);
                }
                else if (!levelMap.TopPriorityL3) // [3,0][3,1][2,0][1,0][2,1][1,1]
                {
                    if (prioritySets[levelLayer.PrioritySet].MainscreenL3 && state.Layer3 && levelMap.GraphicSetL3 != 0xFF)
                        CopySingleTileToArray(mainscreen, GetTileFromPriorityArray(layer3Priority0, x, y), width_p, x, y);
                    if (prioritySets[levelLayer.PrioritySet].MainscreenL3 && state.Layer3 && levelMap.GraphicSetL3 != 0xFF)
                        CopySingleTileToArray(mainscreen, GetTileFromPriorityArray(layer3Priority1, x, y), width_p, x, y);
                    if (prioritySets[levelLayer.PrioritySet].MainscreenL2 && state.Layer2)
                        CopySingleTileToArray(mainscreen, GetTileFromPriorityArray(layer2Priority0, x, y), width_p, x, y);
                    if (prioritySets[levelLayer.PrioritySet].MainscreenL1 && state.Layer1)
                        CopySingleTileToArray(mainscreen, GetTileFromPriorityArray(layer1Priority0, x, y), width_p, x, y);
                    if (prioritySets[levelLayer.PrioritySet].MainscreenL2 && state.Layer2)
                        CopySingleTileToArray(mainscreen, GetTileFromPriorityArray(layer2Priority1, x, y), width_p, x, y);
                    if (prioritySets[levelLayer.PrioritySet].MainscreenL1 && state.Layer1)
                        CopySingleTileToArray(mainscreen, GetTileFromPriorityArray(layer1Priority1, x, y), width_p, x, y);
                }

                // Apply BG color
                if (state.BG)
                {
                    for (int b = y; b < y + 16; b++)
                    {
                        for (int a = x; a < x + 16; a++)
                        {
                            if (mainscreen[b * width_p + a] == 0)
                                mainscreen[b * width_p + a] = bgcolor;
                        }
                    }
                }
            }
        }
        private int[] GetTileFromPriorityArray(int[] arr, int x, int y)
        {
            int counter = 0;
            for (int i = 0; i < 256; i++)
            {
                if (arr[y * width_p + x + counter] != 0)
                    tile[i] = arr[y * width_p + x + counter];

                counter++;
                if (counter % 16 == 0)
                {
                    y++;
                    counter = 0;
                }
            }
            return tile;

        }
        private void DoColorMathOnSingleTile(int[] tile, int x, int y)
        {
            // NEW CODE TEST
            int r, g, b;

            for (int w = 0; w < 16; w++)
            {
                for (int v = 0; v < 16; v++)
                {
                    if (subscreen[(y + w) * width_p + (x + v)] != 0 && tile[w * 16 + v] != 0)
                    {
                        r = Color.FromArgb(tile[w * 16 + v]).R;
                        g = Color.FromArgb(tile[w * 16 + v]).G;
                        b = Color.FromArgb(tile[w * 16 + v]).B;

                        if (prioritySets[levelLayer.PrioritySet].ColorMathMinusSubscreen == 0)
                        {
                            if (prioritySets[levelLayer.PrioritySet].ColorMathHalfIntensity == 1)
                            {
                                r /= 2; g /= 2; b /= 2;
                                r += Color.FromArgb(subscreen[(y + w) * width_p + (x + v)]).R / 2;
                                g += Color.FromArgb(subscreen[(y + w) * width_p + (x + v)]).G / 2;
                                b += Color.FromArgb(subscreen[(y + w) * width_p + (x + v)]).B / 2;
                            }
                            else
                            {
                                r += Color.FromArgb(subscreen[(y + w) * width_p + (x + v)]).R;
                                g += Color.FromArgb(subscreen[(y + w) * width_p + (x + v)]).G;
                                b += Color.FromArgb(subscreen[(y + w) * width_p + (x + v)]).B;
                            }

                            if (r > 255) r = 255; if (g > 255) g = 255; if (b > 255) b = 255;
                        }
                        else if (prioritySets[levelLayer.PrioritySet].ColorMathMinusSubscreen == 1)
                        {
                            if (prioritySets[levelLayer.PrioritySet].ColorMathHalfIntensity == 1)
                            {
                                r /= 2; g /= 2; b /= 2;
                                r -= Color.FromArgb(subscreen[(y + w) * width_p + (x + v)]).R / 2;
                                g -= Color.FromArgb(subscreen[(y + w) * width_p + (x + v)]).G / 2;
                                b -= Color.FromArgb(subscreen[(y + w) * width_p + (x + v)]).B / 2;
                            }
                            else
                            {
                                r -= Color.FromArgb(subscreen[(y + w) * width_p + (x + v)]).R;
                                g -= Color.FromArgb(subscreen[(y + w) * width_p + (x + v)]).G;
                                b -= Color.FromArgb(subscreen[(y + w) * width_p + (x + v)]).B;
                            }

                            if (r < 0) r = 0; if (g < 0) g = 0; if (b < 0) b = 0;
                        }

                        tile[w * 16 + v] = Color.FromArgb(255, r, g, b).ToArgb();

                    }
                }
            }
        }
        private bool HaveSubscreen()
        {
            if ((prioritySets[levelLayer.PrioritySet].SubscreenL1 && state.Layer1) ||
                (prioritySets[levelLayer.PrioritySet].SubscreenL2 && state.Layer2) ||
                (prioritySets[levelLayer.PrioritySet].SubscreenL3 && state.Layer3) ||
                (prioritySets[levelLayer.PrioritySet].SubscreenOBJ && state.NPCs))
                return true;

            return false;
        }
        private void CopyToPixelArray(int[] dest, int[] source)
        {
            try
            {
                for (int i = 0; i < source.Length; i++)
                    if (source[i] != 0)
                        dest[i] = source[i];
            }
            catch
            {
                // overflow
            }
        }
        /*
         * This method draws the mainscreen from the subscreen and all required layers
         * This method also handles the color math pixel by pixel
         */
        private void CreateMainscreen()
        {
            int bgcolor = paletteSet.Palette[16];

            if (HaveSubscreen()) // We are doing color math by the layer
            {

                if (colorMath == null)
                    colorMath = new int[width_p * height_p];
                else
                    Bits.Clear(colorMath);

                if (prioritySets[levelLayer.PrioritySet].ColorMathBG && state.BG)
                {
                    for (int i = 0; i < width_p * height_p; i++)
                        colorMath[i] = bgcolor;
                    DoColorMath(colorMath);
                    CopyToPixelArray(mainscreen, colorMath);
                    Bits.Clear(colorMath);
                }
                else if (state.BG)
                {
                    for (int i = 0; i < width_p * height_p; i++)
                    {
                        mainscreen[i] = bgcolor;
                    }
                }

                if (levelMap.TopPriorityL3) // [3,0][2,0][1,0][2,1][1,1][3,1]
                {
                    if (prioritySets[levelLayer.PrioritySet].MainscreenL3 && state.Layer3 && levelMap.GraphicSetL3 != 0xFF)
                    {
                        CopyToPixelArray(colorMath, layer3Priority0);
                        if (prioritySets[levelLayer.PrioritySet].ColorMathL3)
                            DoColorMath(colorMath);
                        CopyToPixelArray(mainscreen, colorMath);
                        Bits.Clear(colorMath);
                    }
                    if (prioritySets[levelLayer.PrioritySet].MainscreenL2 && state.Layer2)
                    {
                        CopyToPixelArray(colorMath, layer2Priority0);
                        if (prioritySets[levelLayer.PrioritySet].ColorMathL2)
                            DoColorMath(colorMath);
                        CopyToPixelArray(mainscreen, colorMath);
                        Bits.Clear(colorMath);
                    }
                    if (prioritySets[levelLayer.PrioritySet].MainscreenL1 && state.Layer1)
                    {
                        CopyToPixelArray(colorMath, layer1Priority0);
                        if (prioritySets[levelLayer.PrioritySet].ColorMathL1)
                            DoColorMath(colorMath);
                        CopyToPixelArray(mainscreen, colorMath);
                        Bits.Clear(colorMath);
                    }
                    if (prioritySets[levelLayer.PrioritySet].MainscreenL2 && state.Layer2)
                    {
                        CopyToPixelArray(colorMath, layer2Priority1);
                        if (prioritySets[levelLayer.PrioritySet].ColorMathL2)
                            DoColorMath(colorMath);
                        CopyToPixelArray(mainscreen, colorMath);
                        Bits.Clear(colorMath);
                    }
                    if (prioritySets[levelLayer.PrioritySet].MainscreenL1 && state.Layer1)
                    {
                        CopyToPixelArray(colorMath, layer1Priority1);
                        if (prioritySets[levelLayer.PrioritySet].ColorMathL1)
                            DoColorMath(colorMath);
                        CopyToPixelArray(mainscreen, colorMath);
                        Bits.Clear(colorMath);
                    }
                    if (prioritySets[levelLayer.PrioritySet].MainscreenL3 && state.Layer3 && levelMap.GraphicSetL3 != 0xFF)
                    {
                        CopyToPixelArray(colorMath, layer3Priority1);
                        if (prioritySets[levelLayer.PrioritySet].ColorMathL3)
                            DoColorMath(colorMath);
                        CopyToPixelArray(mainscreen, colorMath);
                        Bits.Clear(colorMath);
                    }
                }
                else if (!levelMap.TopPriorityL3) // [3,0][3,1][2,0][1,0][2,1][1,1]
                {
                    if (prioritySets[levelLayer.PrioritySet].MainscreenL3 && state.Layer3 && levelMap.GraphicSetL3 != 0xFF)
                    {
                        CopyToPixelArray(colorMath, layer3Priority0);
                        if (prioritySets[levelLayer.PrioritySet].ColorMathL3)
                            DoColorMath(colorMath);
                        CopyToPixelArray(mainscreen, colorMath);
                        Bits.Clear(colorMath);
                    }
                    if (prioritySets[levelLayer.PrioritySet].MainscreenL3 && state.Layer3 && levelMap.GraphicSetL3 != 0xFF)
                    {
                        CopyToPixelArray(colorMath, layer3Priority1);
                        if (prioritySets[levelLayer.PrioritySet].ColorMathL3)
                            DoColorMath(colorMath);
                        CopyToPixelArray(mainscreen, colorMath);
                        Bits.Clear(colorMath);
                    }
                    if (prioritySets[levelLayer.PrioritySet].MainscreenL2 && state.Layer2)
                    {
                        CopyToPixelArray(colorMath, layer2Priority0);
                        if (prioritySets[levelLayer.PrioritySet].ColorMathL2)
                            DoColorMath(colorMath);
                        CopyToPixelArray(mainscreen, colorMath);
                        Bits.Clear(colorMath);
                    }
                    if (prioritySets[levelLayer.PrioritySet].MainscreenL1 && state.Layer1)
                    {
                        CopyToPixelArray(colorMath, layer1Priority0);
                        if (prioritySets[levelLayer.PrioritySet].ColorMathL1)
                            DoColorMath(colorMath);
                        CopyToPixelArray(mainscreen, colorMath);
                        Bits.Clear(colorMath);
                    }
                    if (prioritySets[levelLayer.PrioritySet].MainscreenL2 && state.Layer2)
                    {
                        CopyToPixelArray(colorMath, layer2Priority1);
                        if (prioritySets[levelLayer.PrioritySet].ColorMathL2)
                            DoColorMath(colorMath);
                        CopyToPixelArray(mainscreen, colorMath);
                        Bits.Clear(colorMath);
                    }
                    if (prioritySets[levelLayer.PrioritySet].MainscreenL1 && state.Layer1)
                    {
                        CopyToPixelArray(colorMath, layer1Priority1);
                        if (prioritySets[levelLayer.PrioritySet].ColorMathL1)
                            DoColorMath(colorMath);
                        CopyToPixelArray(mainscreen, colorMath);
                        Bits.Clear(colorMath);
                    }
                }

            }
            else // No color math, we can go ahead and draw the mainscreen
            {


                if (levelMap.TopPriorityL3) // [3,0][2,0][1,0][2,1][1,1][3,1]
                {
                    if (prioritySets[levelLayer.PrioritySet].MainscreenL3 && state.Layer3 && levelMap.GraphicSetL3 != 0xFF)
                        CopyToPixelArray(mainscreen, layer3Priority0);
                    if (prioritySets[levelLayer.PrioritySet].MainscreenL2 && state.Layer2)
                        CopyToPixelArray(mainscreen, layer2Priority0);
                    if (prioritySets[levelLayer.PrioritySet].MainscreenL1 && state.Layer1)
                        CopyToPixelArray(mainscreen, layer1Priority0);
                    if (prioritySets[levelLayer.PrioritySet].MainscreenL2 && state.Layer2)
                        CopyToPixelArray(mainscreen, layer2Priority1);
                    if (prioritySets[levelLayer.PrioritySet].MainscreenL1 && state.Layer1)
                        CopyToPixelArray(mainscreen, layer1Priority1);
                    if (prioritySets[levelLayer.PrioritySet].MainscreenL3 && state.Layer3 && levelMap.GraphicSetL3 != 0xFF)
                        CopyToPixelArray(mainscreen, layer3Priority1);
                }
                else if (!levelMap.TopPriorityL3) // [3,0][3,1][2,0][1,0][2,1][1,1]
                {
                    if (prioritySets[levelLayer.PrioritySet].MainscreenL3 && state.Layer3 && levelMap.GraphicSetL3 != 0xFF)
                        CopyToPixelArray(mainscreen, layer3Priority0);
                    if (prioritySets[levelLayer.PrioritySet].MainscreenL3 && state.Layer3 && levelMap.GraphicSetL3 != 0xFF)
                        CopyToPixelArray(mainscreen, layer3Priority1);
                    if (prioritySets[levelLayer.PrioritySet].MainscreenL2 && state.Layer2)
                        CopyToPixelArray(mainscreen, layer2Priority0);
                    if (prioritySets[levelLayer.PrioritySet].MainscreenL1 && state.Layer1)
                        CopyToPixelArray(mainscreen, layer1Priority0);
                    if (prioritySets[levelLayer.PrioritySet].MainscreenL2 && state.Layer2)
                        CopyToPixelArray(mainscreen, layer2Priority1);
                    if (prioritySets[levelLayer.PrioritySet].MainscreenL1 && state.Layer1)
                        CopyToPixelArray(mainscreen, layer1Priority1);
                }

                // Apply BG color
                if (state.BG)
                {
                    for (int i = 0; i < width_p * height_p; i++)
                    {
                        if (mainscreen[i] == 0)
                            mainscreen[i] = bgcolor;
                    }
                }
            }
        }
        /*
         * This method creates the specified layer if it is being drawn
         * Done
         */
        private void CreateLayer(int layer)
        {
            if (tileMaps[layer] == null) return;
            if (tileset.TileSetLayers[layer] == null) return;

            int offset = 0;
            ushort tileNum;
            byte increment = 2;

            if (layer == 2)
                increment = 1;

            layers[layer] = new Tile16x16[width * height]; // Create our layer here
            if (layer != 2) // Layers 1 and 2
            {
                for (int i = 0; i < tileMaps[layer].Length / increment; i++)
                {
                    tileNum = Bits.GetShort(tileMaps[layer], offset);
                    if (tileNum > 0x1FF)
                        tileNum = 0;
                    offset += increment;
                    layers[layer][i] = tileset.TileSetLayers[layer][tileNum];
                }
            }
            else // Layer 3
            {
                for (int i = 0; i < tileMaps[layer].Length / increment; i++)
                {
                    tileNum = tileMaps[layer][offset];
                    if (tileNum > 0xFF)
                        tileNum = 0;
                    offset += increment;
                    layers[layer][i] = tileset.TileSetLayers[layer][tileNum];
                }
            }
        }
        /*
         * This method computes the color math using subscreenPixels and a layer
         * It is done on a pixel per pixel basis
         */
        private void DoColorMath(int[] layer)
        {
            // NEW CODE TEST
            int r, g, b;

            for (int y = 0; y < height_p; y++)
            {
                for (int x = 0; x < width_p; x++)
                {
                    if (subscreen[y * width_p + x] != 0 && layer[y * width_p + x] != 0)
                    {
                        r = Color.FromArgb(layer[y * width_p + x]).R;
                        g = Color.FromArgb(layer[y * width_p + x]).G;
                        b = Color.FromArgb(layer[y * width_p + x]).B;

                        if (prioritySets[levelLayer.PrioritySet].ColorMathMinusSubscreen == 0)
                        {
                            if (prioritySets[levelLayer.PrioritySet].ColorMathHalfIntensity == 1)
                            {
                                r /= 2; g /= 2; b /= 2;
                                r += Color.FromArgb(subscreen[y * width_p + x]).R / 2;
                                g += Color.FromArgb(subscreen[y * width_p + x]).G / 2;
                                b += Color.FromArgb(subscreen[y * width_p + x]).B / 2;
                            }
                            else
                            {
                                r += Color.FromArgb(subscreen[y * width_p + x]).R;
                                g += Color.FromArgb(subscreen[y * width_p + x]).G;
                                b += Color.FromArgb(subscreen[y * width_p + x]).B;
                            }

                            if (r > 255) r = 255; if (g > 255) g = 255; if (b > 255) b = 255;
                        }
                        else if (prioritySets[levelLayer.PrioritySet].ColorMathMinusSubscreen == 1)
                        {
                            if (prioritySets[levelLayer.PrioritySet].ColorMathHalfIntensity == 1)
                            {
                                r /= 2; g /= 2; b /= 2;
                                r -= Color.FromArgb(subscreen[y * width_p + x]).R / 2;
                                g -= Color.FromArgb(subscreen[y * width_p + x]).G / 2;
                                b -= Color.FromArgb(subscreen[y * width_p + x]).B / 2;
                            }
                            else
                            {
                                r -= Color.FromArgb(subscreen[y * width_p + x]).R;
                                g -= Color.FromArgb(subscreen[y * width_p + x]).G;
                                b -= Color.FromArgb(subscreen[y * width_p + x]).B;
                            }

                            if (r < 0) r = 0; if (g < 0) g = 0; if (b < 0) b = 0;
                        }

                        layer[y * width_p + x] = Color.FromArgb(255, r, g, b).ToArgb();

                    }
                }
            }
        }
        /*
         * This Method draws a specified priority for a specified layer
         * Dest must be an int[width_p * height_p]!
         */
        private int[] DrawLayerByPriorityOne(int[] dest, int layer, bool priority)
        {
            if (dest.Length != width_p * height_p || layers[layer] == null)
                return null;

            for (int i = 0; i < layers[layer].Length; i++)
            {
                for (int z = 0; z < 4; z++)
                {
                    if (layers[layer][i].Subtiles[z].PriorityOne == priority)
                    {
                        switch (z)
                        {
                            case 0:
                                Do.PixelsToPixels(layers[layer][i].Subtiles[z].Pixels, dest, width_p, new Rectangle((i % width) * 16, (i / width) * 16, 8, 8));
                                break;
                            case 1:
                                Do.PixelsToPixels(layers[layer][i].Subtiles[z].Pixels, dest, width_p, new Rectangle((i % width) * 16 + 8, (i / width) * 16, 8, 8));
                                break;
                            case 2:
                                Do.PixelsToPixels(layers[layer][i].Subtiles[z].Pixels, dest, width_p, new Rectangle((i % width) * 16, (i / width) * 16 + 8, 8, 8));
                                break;
                            case 3:
                                Do.PixelsToPixels(layers[layer][i].Subtiles[z].Pixels, dest, width_p, new Rectangle((i % width) * 16 + 8, (i / width) * 16 + 8, 8, 8));
                                break;
                            default:
                                break;
                        }
                    }
                }

            }

            return dest;

        }
        /*
         * This method fills the int[] subscreenPixels based on the decompressed tileMaps and the priority order.
         */
        private void CreateSubscreen()
        {
            // 2 possible cases
            if (levelMap.TopPriorityL3) //[3,0][2,0][1,0][2,1][1,1][3,1]
            {
                if (prioritySets[levelLayer.PrioritySet].SubscreenL3 && state.Layer3 && levelMap.GraphicSetL3 != 0xFF)
                    CopyToPixelArray(subscreen, layer3Priority0);//DrawLayerByPriorityOne(subscreenPixels, 2, false);
                if (prioritySets[levelLayer.PrioritySet].SubscreenL2 && state.Layer2)
                    CopyToPixelArray(subscreen, layer2Priority0);//DrawLayerByPriorityOne(subscreenPixels, 1, false);
                if (prioritySets[levelLayer.PrioritySet].SubscreenL1 && state.Layer1)
                    CopyToPixelArray(subscreen, layer1Priority0);//DrawLayerByPriorityOne(subscreenPixels, 0, false);
                if (prioritySets[levelLayer.PrioritySet].SubscreenL2 && state.Layer2)
                    CopyToPixelArray(subscreen, layer2Priority1);//DrawLayerByPriorityOne(subscreenPixels, 1, true);
                if (prioritySets[levelLayer.PrioritySet].SubscreenL1 && state.Layer1)
                    CopyToPixelArray(subscreen, layer1Priority1);//DrawLayerByPriorityOne(subscreenPixels, 0, true);
                if (prioritySets[levelLayer.PrioritySet].SubscreenL3 && state.Layer3 && levelMap.GraphicSetL3 != 0xFF)
                    CopyToPixelArray(subscreen, layer3Priority1);//DrawLayerByPriorityOne(subscreenPixels, 2, true);


            }
            else if (!levelMap.TopPriorityL3) //[3,0][3,1][2,0][1,0][2,1][1,1]
            {
                if (prioritySets[levelLayer.PrioritySet].SubscreenL3 && state.Layer3 && levelMap.GraphicSetL3 != 0xFF)
                    CopyToPixelArray(subscreen, layer3Priority0);//DrawLayerByPriorityOne(subscreenPixels, 2, false);
                if (prioritySets[levelLayer.PrioritySet].SubscreenL3 && state.Layer3 && levelMap.GraphicSetL3 != 0xFF)
                    CopyToPixelArray(subscreen, layer3Priority1);//DrawLayerByPriorityOne(subscreenPixels, 2, true);
                if (prioritySets[levelLayer.PrioritySet].SubscreenL2 && state.Layer2)
                    CopyToPixelArray(subscreen, layer2Priority0);//DrawLayerByPriorityOne(subscreenPixels, 1, false);
                if (prioritySets[levelLayer.PrioritySet].SubscreenL1 && state.Layer1)
                    CopyToPixelArray(subscreen, layer1Priority0);//DrawLayerByPriorityOne(subscreenPixels, 0, false);
                if (prioritySets[levelLayer.PrioritySet].SubscreenL2 && state.Layer2)
                    CopyToPixelArray(subscreen, layer2Priority1);//DrawLayerByPriorityOne(subscreenPixels, 1, true);
                if (prioritySets[levelLayer.PrioritySet].SubscreenL1 && state.Layer1)
                    CopyToPixelArray(subscreen, layer1Priority1);//DrawLayerByPriorityOne(subscreenPixels, 0, true);
            }
        }
        /*
        * This method fills the 16x16 pixel buf with the correct graphics from the
        * 8x8 tiles, but only if we have all the subtiles
        */
        public int[] GetPriority1Pixels()
        {
            int[] pixels = new int[width_p * height_p];

            for (int y = 0; y < height_p; y++)
            {
                for (int x = 0; x < width_p; x++)
                {
                    if (layer1Priority1[y * width_p + x] != 0 ||
                        layer2Priority1[y * width_p + x] != 0 ||
                        layer3Priority1[y * width_p + x] != 0)
                        pixels[y * width_p + x] = Color.Blue.ToArgb();
                }
            }

            return pixels;
        }
        public void MakeEdit(int tileNum, int layer, int x, int y)
        {
            if (x < 0) x = 0;
            if (y < 0) y = 0;
            if (x >= width_p) x = width_p - 1;
            if (y >= height_p) y = height_p - 1;
            y /= 16;
            x /= 16;
            int index = y * width + x;
            if (index < 0x1000)
                ChangeSingleTile(layer, index, tileNum, x * 16, y * 16);
            if (type == "mod")
            {
                if (layer < 2)
                    Bits.SetShort(tileMaps[layer], (y * width + x) * 2, (ushort)tileNum);
                else
                    tileMaps[layer][y * width + x] = (byte)tileNum;
                return;
            }
            switch (layer)
            {
                case 0: Model.EditTileMaps[levelMap.TileMapL1 + 0x40] = true; break;
                case 1: Model.EditTileMaps[levelMap.TileMapL2 + 0x40] = true; break;
                case 2: Model.EditTileMaps[levelMap.TileMapL3] = true; break;
            }
        }
        public int GetTileNum(int layer, int x, int y)
        {
            if (x < 0) x = 0;
            if (y < 0) y = 0;
            if (x >= width_p) x = width_p - 1;
            if (y >= height_p) y = height_p - 1;
            y /= 16;
            x /= 16;
            int placement = y * width + x;

            if (layer < 3 && layers[layer] != null)
                return layers[layer][placement].TileIndex;
            else return 0;
        }
        public void Clear(int count)
        {
            if (count == 1)
            {
                Model.TileMaps[levelMap.TileMapL1 + 0x40] = new byte[0x2000];
                Model.TileMaps[levelMap.TileMapL2 + 0x40] = new byte[0x2000];
                Model.TileMaps[levelMap.TileMapL3] = new byte[0x1000];

                Model.EditTileMaps[levelMap.TileMapL1 + 0x40] = true;
                Model.EditTileMaps[levelMap.TileMapL2 + 0x40] = true;
                Model.EditTileMaps[levelMap.TileMapL3] = true;
            }
            else
            {
                for (int i = 0; i < count; i++)
                {
                    if (i < 0x40)
                        Model.TileMaps[i] = new byte[0x1000];
                    else
                        Model.TileMaps[i] = new byte[0x2000];
                    Model.EditTileMaps[i] = true;
                }
            }
            RedrawTileMap();
        }
        public void AssembleIntoModel()
        {
            for (int l = 0; l < 3; l++)
            {
                if (layers[l] == null) continue;
                for (int i = 0; i < layers[l].Length; i++)
                {
                    if (l < 2)
                        Bits.SetShort(tileMaps[l], i * 2, (ushort)layers[l][i].TileIndex);
                    else
                        Bits.SetByte(tileMaps[2], i, (byte)layers[2][i].TileIndex);
                }
            }
        }
    }
}
