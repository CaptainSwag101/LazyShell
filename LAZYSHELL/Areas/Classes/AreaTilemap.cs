using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace LazyShell.Areas
{
    public class AreaTilemap : Tilemap
    {
        #region Variables

        // Properties
        private TilemapType type;
        private Area area;
        private Chunk chunk;
        private bool drawAlternateTileSwitch;
        private TileSwitch tileSwitch;
        private Layering layering
        {
            get { return area.Layering; }
            set { area.Layering = value; }
        }
        private PrioritySet[] prioritySets
        {
            get { return Model.PrioritySets; }
            set { Model.PrioritySets = value; }
        }
        private PrioritySet prioritySet
        {
            get { return prioritySets[layering.PrioritySet]; }
            set { prioritySets[layering.PrioritySet] = value; }
        }
        private PaletteSet paletteSet
        {
            get { return Model.PaletteSets[map.PaletteSet]; }
            set { Model.PaletteSets[map.PaletteSet] = value; }
        }
        private Map map
        {
            get { return Model.Maps[area.Map]; }
            set { Model.Maps[area.Map] = value; }
        }
        private int bgColor
        {
            get { return paletteSet.Palette[16]; }
        }
        // Source tiles
        public override Tileset Tileset { get; set; }
        public override byte[][] Tilemaps_bytes { get; set; }
        public override Tile[][] Tilemaps_tiles { get; set; }
        public override Tile[] Tilemap_tiles
        {
            get { return Tilemaps_tiles[0]; }
            set { Tilemaps_tiles[0] = value; }
        }
        public override byte[] Tilemap_bytes
        {
            get { return Tilemaps_bytes[0]; }
            set { Tilemaps_bytes[0] = value; }
        }
        // Tilemap dimensions
        public int Width { get; set; }
        public int Height { get; set; }
        public override int Width_p
        {
            get { return Width * 16; }
            set { Width = value / 16; }
        }
        public override int Height_p
        {
            get { return Height * 16; }
            set { Height = value / 16; }
        }
        public Size Size
        {
            get { return new Size(Width, Height); }
        }
        public Size Size_p
        {
            get { return new Size(Width_p, Height_p); }
        }
        // Pixel arrays
        private int[] subscreen;
        private int[] tile;
        /// <summary>
        /// Pixel maps are divided into six arrays -- two priority-based layers for each of the three layers.
        /// </summary>
        private int[] L1Priority0, L1Priority1;
        private int[] L2Priority0, L2Priority1;
        private int[] L3Priority0, L3Priority1;
        /// <summary>
        /// The final pixel map generated after all layering and drawing operations.
        /// </summary>
        public override int[] Pixels { get; set; }
        public override Bitmap Image
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }
        // Overlay state
        private State state = State.Instance;

        #endregion

        // Constructors
        public AreaTilemap(Area area, Tileset tileset)
        {
            this.area = area;
            this.Tileset = tileset;
            //
            this.type = TilemapType.Area;
            this.Width = 64;
            this.Height = 64;
            //
            InitializeVariables();
            InitializePixelMaps();
            InitializeTilemapTiles();
            InitializeTilemapBytes();
            BuildTilemapTiles();
            CreatePixelMaps();
            CreateSubscreen();
            CreateMainscreen();
        }
        public AreaTilemap(Area area, Tileset tileset, Chunk chunk)
        {
            this.area = area;
            this.Tileset = tileset;
            this.chunk = chunk;
            //
            this.type = TilemapType.Chunk;
            //
            InitializeVariables();
            InitializeTilemapTiles();
            InitializeTilemapBytes();
            BuildTilemapTiles();
            CreatePixelMaps();
            CreateSubscreen();
            CreateMainscreen();
        }
        public AreaTilemap(Area area, Tileset tileset, TileSwitch tileSwitch, bool drawAlternateTileSwitch)
        {
            this.area = area;
            this.Tileset = tileset;
            this.tileSwitch = tileSwitch;
            this.drawAlternateTileSwitch = drawAlternateTileSwitch;
            //
            this.type = TilemapType.TileSwitch;
            this.Width = tileSwitch.Width;
            this.Height = tileSwitch.Height;
            //
            InitializeVariables();
            InitializeTilemapTiles();
            InitializeTilemapBytes();
            InitializePixelMaps();
            // Build the tilemap and draw pixels
            BuildTilemapTiles();
            CreatePixelMaps();
            CreateSubscreen();
            CreateMainscreen();
        }

        #region Methods

        #region Tilemap Creation

        private void InitializeVariables()
        {
            this.state = State.Instance;
            this.subscreen = null;
            this.tile = new int[256];
        }
        private void InitializeTilemapBytes()
        {
            Tilemaps_bytes = new byte[3][];
            if (this.type == TilemapType.Area)
            {
                Tilemaps_bytes[0] = Model.Tilemaps[map.TilemapL1 + 0x40];
                Tilemaps_bytes[1] = Model.Tilemaps[map.TilemapL2 + 0x40];
                Tilemaps_bytes[2] = Model.Tilemaps[map.TilemapL3];
            }
            else if (this.type == TilemapType.Chunk)
            {
                for (int y = 0; y < chunk.Size.Height / 16; y++)
                {
                    for (int x = 0; x < chunk.Size.Width / 16; x++)
                    {
                        int tileLayer0 = Bits.GetShort(chunk.Tilemaps_bytes[0], (y * (chunk.Size.Width / 16) + x) * 2);
                        int tileLayer1 = Bits.GetShort(chunk.Tilemaps_bytes[1], (y * (chunk.Size.Width / 16) + x) * 2);
                        Bits.SetShort(Tilemaps_bytes[0], (y * 64 + x) * 2, tileLayer0);
                        Bits.SetShort(Tilemaps_bytes[1], (y * 64 + x) * 2, tileLayer1);
                        Tilemaps_bytes[2][y * 64 + x] = chunk.Tilemaps_bytes[2][y * (chunk.Size.Width / 16) + x];
                    }
                }
            }
            else if (this.type == TilemapType.TileSwitch)
            {
                if (!drawAlternateTileSwitch)
                    this.Tilemaps_bytes = tileSwitch.Tilemaps_bytesA;
                else
                    this.Tilemaps_bytes = tileSwitch.Tilemaps_bytesB;
            }
        }
        private void InitializeTilemapTiles()
        {
            Tilemaps_tiles = new Tile[3][];
            Tilemaps_tiles[0] = new Tile[Width * Height];
            Tilemaps_tiles[1] = new Tile[Width * Height];
            Tilemaps_tiles[2] = new Tile[Width * Height];
        }
        private void InitializePixelMaps()
        {
            L1Priority0 = new int[Width_p * Height_p];
            L1Priority1 = new int[Width_p * Height_p];
            L2Priority0 = new int[Width_p * Height_p];
            L2Priority1 = new int[Width_p * Height_p];
            L3Priority0 = new int[Width_p * Height_p];
            L3Priority1 = new int[Width_p * Height_p];
            Pixels = new int[Width_p * Height_p];
        }
        /// <summary>
        /// Creates the tile collections of each tilemap out of their binary data using the tiles of this instance's tileset.
        /// </summary>
        private void BuildTilemapTiles()
        {
            BuildTilemapTiles(Tilemaps_bytes[0], Tilemaps_tiles[0], Tileset.Tilesets_tiles[0], 2);
            BuildTilemapTiles(Tilemaps_bytes[1], Tilemaps_tiles[1], Tileset.Tilesets_tiles[1], 2);
            BuildTilemapTiles(Tilemaps_bytes[2], Tilemaps_tiles[2], Tileset.Tilesets_tiles[2], 1);
        }
        /// <summary>
        /// Creates a tilemap's tile collection out of its binary data using the tiles of a specified tileset.
        /// </summary>
        /// <param name="tilemap_bytes">The tilemap's binary data.</param>
        /// <param name="tilemap_tiles">The tilemap's Tile collection to store the output to. 
        /// The tiles in this collection can be, and usually are, null.</param>
        /// <param name="tileset_tiles">The tileset's tiles to use for building the tilemap's Tile collection.</param>
        /// <param name="tileSize">The size of a single tile's binary data in the tilemap.</param>
        private void BuildTilemapTiles(byte[] tilemap_bytes, Tile[] tilemap_tiles, Tile[] tileset_tiles, int tileSize)
        {
            if (tilemap_bytes == null ||
                tilemap_tiles == null ||
                tileset_tiles == null)
                return;
            int offset = 0;
            for (int i = 0; i < tilemap_bytes.Length / tileSize; i++)
            {
                int tileNum = 0;
                if (tileSize == 2)
                    tileNum = Bits.GetShort(tilemap_bytes, offset);
                else
                    tileNum = tilemap_bytes[offset];
                if (tileNum > tileset_tiles.Length)
                    tileNum = 0;
                offset += tileSize;
                tilemap_tiles[i] = tileset_tiles[tileNum];
            }
        }
        /// <summary>
        /// Creates the pixel maps for all six layers to be used for layering and drawing the final pixel map.
        /// </summary>
        private void CreatePixelMaps()
        {
            if (prioritySet.SubscreenL1 || prioritySet.MainscreenL1)
            {
                L1Priority0 = TilemapToPixels(Tilemaps_tiles[0], 64, 64, false);
                L1Priority1 = TilemapToPixels(Tilemaps_tiles[0], 64, 64, true);
            }
            if (prioritySet.SubscreenL2 || prioritySet.MainscreenL2)
            {
                L2Priority0 = TilemapToPixels(Tilemaps_tiles[1], 64, 64, false);
                L2Priority1 = TilemapToPixels(Tilemaps_tiles[1], 64, 64, true);
            }
            if ((prioritySet.SubscreenL3 || prioritySet.MainscreenL3) && map.GraphicSetL3 != 0xFF)
            {
                L3Priority0 = TilemapToPixels(Tilemaps_tiles[2], 64, 64, false);
                L3Priority1 = TilemapToPixels(Tilemaps_tiles[2], 64, 64, true);
            }
        }
        /// <summary>
        /// Generates a pixel map of a tilemap's tiles. The output is filtered to subtiles with a specified priority 1 status.
        /// </summary>
        /// <param name="tilemap">The tilemap's tiles.</param>
        /// <param name="width">The width, in 16x16 tile units, of the tilemap.</param>
        /// <param name="height">The height, in 16x16 tile units, of the tilemap.</param>
        /// <param name="priority1">Specifies whether to filter the output to priority 1 subtiles or non-priority 1 subtiles.</param>
        /// <returns></returns>
        private int[] TilemapToPixels(Tile[] tilemap, int width, int height, bool priority1)
        {
            if (tilemap == null)
                return null;
            int[] output = new int[(width * 16) * (height * 16)];
            // Transfer each tile's pixels to destination array
            for (int i = 0; i < tilemap.Length; i++)
            {
                Tile tile = tilemap[i];
                int tileX = (i % width) * 16; // tile's X coord on the pixel map
                int tileY = (i / width) * 16; // tile's Y coord on the pixel map
                // Transfer each subtile's pixels to destination array
                for (int z = 0; z < 4; z++)
                {
                    Subtile subtile = tile.Subtiles[z];
                    if (subtile.Priority1 == priority1)
                    {
                        var subtilePixels = subtile.Pixels;
                        switch (z)
                        {
                            case 0:
                                Do.PixelsToPixels(subtilePixels, output, Width_p, new Rectangle(tileX, tileY, 8, 8));
                                break;
                            case 1:
                                Do.PixelsToPixels(subtilePixels, output, Width_p, new Rectangle(tileX + 8, tileY, 8, 8));
                                break;
                            case 2:
                                Do.PixelsToPixels(subtilePixels, output, Width_p, new Rectangle(tileX, tileY + 8, 8, 8));
                                break;
                            case 3:
                                Do.PixelsToPixels(subtilePixels, output, Width_p, new Rectangle(tileX + 8, tileY + 8, 8, 8));
                                break;
                        }
                    }
                }
            }
            return output;
        }
        /// <summary>
        /// Returns a value indicating whether the subscreen is enabled for any visible layers.
        /// </summary>
        /// <returns></returns>
        private bool HaveSubscreen()
        {
            if ((prioritySet.SubscreenL1 && state.Layer1) ||
                (prioritySet.SubscreenL2 && state.Layer2) ||
                (prioritySet.SubscreenL3 && state.Layer3) ||
                (prioritySet.SubscreenOBJ && state.NPCs))
                return true;
            return false;
        }
        /// <summary>
        /// Creates the subscreen's pixel map by superimposing the six layer pixel maps 
        /// on top of one another using the settings of this area's priority set.
        /// </summary>
        private void CreateSubscreen()
        {
            // Cancel if subscreen not enabled for any layers
            if (!HaveSubscreen())
                return;
            this.subscreen = new int[Width_p * Height_p];
            if (map.TopPriorityL3)
            {
                if (prioritySet.SubscreenL3 && state.Layer3 && map.GraphicSetL3 != 0xFF)
                    Do.PixelsToPixels(L3Priority0, subscreen, true);
                if (prioritySet.SubscreenL2 && state.Layer2)
                    Do.PixelsToPixels(L2Priority0, subscreen, true);
                if (prioritySet.SubscreenL1 && state.Layer1)
                    Do.PixelsToPixels(L1Priority0, subscreen, true);
                if (prioritySet.SubscreenL2 && state.Layer2)
                    Do.PixelsToPixels(L2Priority1, subscreen, true);
                if (prioritySet.SubscreenL1 && state.Layer1)
                    Do.PixelsToPixels(L1Priority1, subscreen, true);
                if (prioritySet.SubscreenL3 && state.Layer3 && map.GraphicSetL3 != 0xFF)
                    Do.PixelsToPixels(L3Priority1, subscreen, true);
            }
            else if (!map.TopPriorityL3)
            {
                if (prioritySet.SubscreenL3 && state.Layer3 && map.GraphicSetL3 != 0xFF)
                    Do.PixelsToPixels(L3Priority0, subscreen, true);
                if (prioritySet.SubscreenL3 && state.Layer3 && map.GraphicSetL3 != 0xFF)
                    Do.PixelsToPixels(L3Priority1, subscreen, true);
                if (prioritySet.SubscreenL2 && state.Layer2)
                    Do.PixelsToPixels(L2Priority0, subscreen, true);
                if (prioritySet.SubscreenL1 && state.Layer1)
                    Do.PixelsToPixels(L1Priority0, subscreen, true);
                if (prioritySet.SubscreenL2 && state.Layer2)
                    Do.PixelsToPixels(L2Priority1, subscreen, true);
                if (prioritySet.SubscreenL1 && state.Layer1)
                    Do.PixelsToPixels(L1Priority1, subscreen, true);
            }
        }
        /// <summary>
        /// Performs all of the necessary color math operations on the mainscreen pixels using the subscreen pixels.
        /// This is the final step in drawing the tilemap's pixels for viewing on canvas.
        /// </summary>
        private void CreateMainscreen()
        {
            bool haveSubscreen = HaveSubscreen();
            this.Pixels = new int[Width_p * Height_p];
            int[] pixels = new int[Width_p * Height_p];
            bool halfIntensity = prioritySet.ColorMathHalfIntensity;
            bool minusSubscreen = prioritySet.ColorMathMinusSubscreen;
            // Draw BG pixels before anything else
            if (state.BG)
            {
                if (prioritySet.ColorMathBG && haveSubscreen)
                {
                    Bits.Fill(pixels, bgColor);
                    Do.ColorMath(subscreen, pixels, Width_p, Height_p, halfIntensity, minusSubscreen);
                    Do.PixelsToPixels(pixels, this.Pixels, true);
                    pixels = new int[pixels.Length];
                }
                else
                    Bits.Fill(this.Pixels, bgColor);
            }

            #region Draw layer 3's priority 1 tiles first

            if (map.TopPriorityL3)
            {
                // Layers at the bottom are drawn first
                if (prioritySet.MainscreenL3 && state.Layer3 && map.GraphicSetL3 != 0xFF)
                {
                    // Apply subscreen to priority layer pixels using color math
                    if (prioritySet.ColorMathL3 && haveSubscreen)
                        Do.ColorMath(subscreen, L3Priority0, this.Pixels, Width_p, Height_p, halfIntensity, minusSubscreen);
                    else
                        Do.PixelsToPixels(L3Priority0, this.Pixels, true);
                }
                if (prioritySet.MainscreenL2 && state.Layer2)
                {
                    if (prioritySet.ColorMathL2 && haveSubscreen)
                        Do.ColorMath(subscreen, L2Priority0, this.Pixels, Width_p, Height_p, halfIntensity, minusSubscreen);
                    else
                        Do.PixelsToPixels(L2Priority0, this.Pixels, true);
                }
                if (prioritySet.MainscreenL1 && state.Layer1)
                {
                    if (prioritySet.ColorMathL1 && haveSubscreen)
                        Do.ColorMath(subscreen, L1Priority0, this.Pixels, Width_p, Height_p, halfIntensity, minusSubscreen);
                    else
                        Do.PixelsToPixels(L1Priority0, this.Pixels, true);
                }
                if (prioritySet.MainscreenL2 && state.Layer2)
                {
                    if (prioritySet.ColorMathL2 && haveSubscreen)
                        Do.ColorMath(subscreen, L2Priority1, this.Pixels, Width_p, Height_p, halfIntensity, minusSubscreen);
                    else
                        Do.PixelsToPixels(L2Priority1, this.Pixels, true);
                }
                if (prioritySet.MainscreenL1 && state.Layer1)
                {
                    if (prioritySet.ColorMathL1 && haveSubscreen)
                        Do.ColorMath(subscreen, L1Priority1, this.Pixels, Width_p, Height_p, halfIntensity, minusSubscreen);
                    else
                        Do.PixelsToPixels(L1Priority1, this.Pixels, true);
                }
                // Draw layer 3 priority 1 pixel map over others
                if (prioritySet.MainscreenL3 && state.Layer3 && map.GraphicSetL3 != 0xFF)
                {
                    if (prioritySet.ColorMathL3 && haveSubscreen)
                        Do.ColorMath(subscreen, L3Priority1, this.Pixels, Width_p, Height_p, halfIntensity, minusSubscreen);
                    else
                        Do.PixelsToPixels(L3Priority1, this.Pixels, true);
                }
            }

            #endregion

            #region Draw layers in default order

            else if (!map.TopPriorityL3)
            {
                // Layers at the bottom are drawn first
                if (prioritySet.MainscreenL3 && state.Layer3 && map.GraphicSetL3 != 0xFF)
                {
                    if (prioritySet.ColorMathL3 && haveSubscreen)
                        Do.ColorMath(subscreen, L3Priority0, this.Pixels, Width_p, Height_p, halfIntensity, minusSubscreen);
                    else
                        Do.PixelsToPixels(L3Priority0, this.Pixels, true);
                }
                if (prioritySet.MainscreenL3 && state.Layer3 && map.GraphicSetL3 != 0xFF)
                {
                    if (prioritySet.ColorMathL3 && haveSubscreen)
                        Do.ColorMath(subscreen, L3Priority1, this.Pixels, Width_p, Height_p, halfIntensity, minusSubscreen);
                    else
                        Do.PixelsToPixels(L3Priority1, this.Pixels, true);
                }
                if (prioritySet.MainscreenL2 && state.Layer2)
                {
                    if (prioritySet.ColorMathL2 && haveSubscreen)
                        Do.ColorMath(subscreen, L2Priority0, this.Pixels, Width_p, Height_p, halfIntensity, minusSubscreen);
                    else
                        Do.PixelsToPixels(L2Priority0, this.Pixels, true);
                }
                if (prioritySet.MainscreenL1 && state.Layer1)
                {
                    if (prioritySet.ColorMathL1 && haveSubscreen)
                        Do.ColorMath(subscreen, L1Priority0, this.Pixels, Width_p, Height_p, halfIntensity, minusSubscreen);
                    else
                        Do.PixelsToPixels(L1Priority0, this.Pixels, true);
                }
                if (prioritySet.MainscreenL2 && state.Layer2)
                {
                    if (prioritySet.ColorMathL2 && haveSubscreen)
                        Do.ColorMath(subscreen, L2Priority1, this.Pixels, Width_p, Height_p, halfIntensity, minusSubscreen);
                    else
                        Do.PixelsToPixels(L2Priority1, this.Pixels, true);
                }
                if (prioritySet.MainscreenL1 && state.Layer1)
                {
                    if (prioritySet.ColorMathL1 && haveSubscreen)
                        Do.ColorMath(subscreen, L1Priority1, this.Pixels, Width_p, Height_p, halfIntensity, minusSubscreen);
                    else
                        Do.PixelsToPixels(L1Priority1, this.Pixels, true);
                }
            }

            #endregion
        }

        #endregion

        #region External Modification

        private void DrawSingleMainscreenTile(int x, int y)
        {
            int bgcolor = paletteSet.Palette[16];
            Bits.Clear(tile);
            int[] tileColorMath = new int[16 * 16];
            if (HaveSubscreen())
            {
                if (prioritySet.ColorMathBG && state.BG)
                {
                    for (int i = 0; i < 256; i++)
                        tileColorMath[i] = bgcolor;
                    DoColorMathOnSingleTile(tileColorMath, x, y);
                    CopySingleTileToArray(this.Pixels, tileColorMath, Width_p, x, y);
                    Bits.Clear(tileColorMath);
                }
                else if (state.BG)
                {
                    for (int i = 0; i < 256; i++)
                        tileColorMath[i] = bgcolor;
                    CopySingleTileToArray(this.Pixels, tileColorMath, Width_p, x, y);
                    Bits.Clear(tileColorMath);
                }
                if (map.TopPriorityL3) // [3,0][2,0][1,0][2,1][1,1][3,1]
                {
                    if (prioritySet.MainscreenL3 && state.Layer3 && map.GraphicSetL3 != 0xFF)
                    {
                        tileColorMath = GetTilePixels(L3Priority0, x, y);
                        if (prioritySet.ColorMathL3)
                            DoColorMathOnSingleTile(tileColorMath, x, y);
                        CopySingleTileToArray(this.Pixels, tileColorMath, Width_p, x, y);
                        Bits.Clear(tileColorMath);
                    }
                    if (prioritySet.MainscreenL2 && state.Layer2)
                    {
                        tileColorMath = GetTilePixels(L2Priority0, x, y);
                        if (prioritySet.ColorMathL2)
                            DoColorMathOnSingleTile(tileColorMath, x, y);
                        CopySingleTileToArray(this.Pixels, tileColorMath, Width_p, x, y);
                        Bits.Clear(tileColorMath);
                    }
                    if (prioritySet.MainscreenL1 && state.Layer1)
                    {
                        tileColorMath = GetTilePixels(L1Priority0, x, y);
                        if (prioritySet.ColorMathL1)
                            DoColorMathOnSingleTile(tileColorMath, x, y);
                        CopySingleTileToArray(this.Pixels, tileColorMath, Width_p, x, y);
                        Bits.Clear(tileColorMath);
                    }
                    if (prioritySet.MainscreenL2 && state.Layer2)
                    {
                        tileColorMath = GetTilePixels(L2Priority1, x, y);
                        if (prioritySet.ColorMathL2)
                            DoColorMathOnSingleTile(tileColorMath, x, y);
                        CopySingleTileToArray(this.Pixels, tileColorMath, Width_p, x, y);
                        Bits.Clear(tileColorMath);
                    }
                    if (prioritySet.MainscreenL1 && state.Layer1)
                    {
                        tileColorMath = GetTilePixels(L1Priority1, x, y);
                        if (prioritySet.ColorMathL1)
                            DoColorMathOnSingleTile(tileColorMath, x, y);
                        CopySingleTileToArray(this.Pixels, tileColorMath, Width_p, x, y);
                        Bits.Clear(tileColorMath);
                    }
                    if (prioritySet.MainscreenL3 && state.Layer3 && map.GraphicSetL3 != 0xFF)
                    {
                        tileColorMath = GetTilePixels(L3Priority1, x, y);
                        if (prioritySet.ColorMathL3)
                            DoColorMathOnSingleTile(tileColorMath, x, y);
                        CopySingleTileToArray(this.Pixels, tileColorMath, Width_p, x, y);
                        Bits.Clear(tileColorMath);
                    }
                }
                else if (!map.TopPriorityL3) // [3,0][3,1][2,0][1,0][2,1][1,1]
                {
                    if (prioritySet.MainscreenL3 && state.Layer3 && map.GraphicSetL3 != 0xFF)
                    {
                        tileColorMath = GetTilePixels(L3Priority0, x, y);
                        if (prioritySet.ColorMathL3)
                            DoColorMathOnSingleTile(tileColorMath, x, y);
                        CopySingleTileToArray(this.Pixels, tileColorMath, Width_p, x, y);
                        Bits.Clear(tileColorMath);
                    }
                    if (prioritySet.MainscreenL3 && state.Layer3 && map.GraphicSetL3 != 0xFF)
                    {
                        tileColorMath = GetTilePixels(L3Priority1, x, y);
                        if (prioritySet.ColorMathL3)
                            DoColorMathOnSingleTile(tileColorMath, x, y);
                        CopySingleTileToArray(this.Pixels, tileColorMath, Width_p, x, y);
                        Bits.Clear(tileColorMath);
                    }
                    if (prioritySet.MainscreenL2 && state.Layer2)
                    {
                        tileColorMath = GetTilePixels(L2Priority0, x, y);
                        if (prioritySet.ColorMathL2)
                            DoColorMathOnSingleTile(tileColorMath, x, y);
                        CopySingleTileToArray(this.Pixels, tileColorMath, Width_p, x, y);
                        Bits.Clear(tileColorMath);
                    }
                    if (prioritySet.MainscreenL1 && state.Layer1)
                    {
                        tileColorMath = GetTilePixels(L1Priority0, x, y);
                        if (prioritySet.ColorMathL1)
                            DoColorMathOnSingleTile(tileColorMath, x, y);
                        CopySingleTileToArray(this.Pixels, tileColorMath, Width_p, x, y);
                        Bits.Clear(tileColorMath);
                    }
                    if (prioritySet.MainscreenL2 && state.Layer2)
                    {
                        tileColorMath = GetTilePixels(L2Priority1, x, y);
                        if (prioritySet.ColorMathL2)
                            DoColorMathOnSingleTile(tileColorMath, x, y);
                        CopySingleTileToArray(this.Pixels, tileColorMath, Width_p, x, y);
                        Bits.Clear(tileColorMath);
                    }
                    if (prioritySet.MainscreenL1 && state.Layer1)
                    {
                        tileColorMath = GetTilePixels(L1Priority1, x, y);
                        if (prioritySet.ColorMathL1)
                            DoColorMathOnSingleTile(tileColorMath, x, y);
                        CopySingleTileToArray(this.Pixels, tileColorMath, Width_p, x, y);
                        Bits.Clear(tileColorMath);
                    }
                }
            }
            else // No color math, we can go ahead and draw the mainscreen
            {
                if (map.TopPriorityL3) // [3,0][2,0][1,0][2,1][1,1][3,1]
                {
                    if (prioritySet.MainscreenL3 && state.Layer3 && map.GraphicSetL3 != 0xFF)
                        CopySingleTileToArray(this.Pixels, GetTilePixels(L3Priority0, x, y), Width_p, x, y);
                    if (prioritySet.MainscreenL2 && state.Layer2)
                        CopySingleTileToArray(this.Pixels, GetTilePixels(L2Priority0, x, y), Width_p, x, y);
                    if (prioritySet.MainscreenL1 && state.Layer1)
                        CopySingleTileToArray(this.Pixels, GetTilePixels(L1Priority0, x, y), Width_p, x, y);
                    if (prioritySet.MainscreenL2 && state.Layer2)
                        CopySingleTileToArray(this.Pixels, GetTilePixels(L2Priority1, x, y), Width_p, x, y);
                    if (prioritySet.MainscreenL1 && state.Layer1)
                        CopySingleTileToArray(this.Pixels, GetTilePixels(L1Priority1, x, y), Width_p, x, y);
                    if (prioritySet.MainscreenL3 && state.Layer3 && map.GraphicSetL3 != 0xFF)
                        CopySingleTileToArray(this.Pixels, GetTilePixels(L3Priority1, x, y), Width_p, x, y);
                }
                else if (!map.TopPriorityL3) // [3,0][3,1][2,0][1,0][2,1][1,1]
                {
                    if (prioritySet.MainscreenL3 && state.Layer3 && map.GraphicSetL3 != 0xFF)
                        CopySingleTileToArray(this.Pixels, GetTilePixels(L3Priority0, x, y), Width_p, x, y);
                    if (prioritySet.MainscreenL3 && state.Layer3 && map.GraphicSetL3 != 0xFF)
                        CopySingleTileToArray(this.Pixels, GetTilePixels(L3Priority1, x, y), Width_p, x, y);
                    if (prioritySet.MainscreenL2 && state.Layer2)
                        CopySingleTileToArray(this.Pixels, GetTilePixels(L2Priority0, x, y), Width_p, x, y);
                    if (prioritySet.MainscreenL1 && state.Layer1)
                        CopySingleTileToArray(this.Pixels, GetTilePixels(L1Priority0, x, y), Width_p, x, y);
                    if (prioritySet.MainscreenL2 && state.Layer2)
                        CopySingleTileToArray(this.Pixels, GetTilePixels(L2Priority1, x, y), Width_p, x, y);
                    if (prioritySet.MainscreenL1 && state.Layer1)
                        CopySingleTileToArray(this.Pixels, GetTilePixels(L1Priority1, x, y), Width_p, x, y);
                }
                // Apply BG color
                if (state.BG)
                {
                    for (int b = y; b < y + 16; b++)
                    {
                        for (int a = x; a < x + 16; a++)
                        {
                            if (this.Pixels[b * Width_p + a] == 0)
                                this.Pixels[b * Width_p + a] = bgcolor;
                        }
                    }
                }
            }
        }
        private void DrawSingleSubscreenTile(int x, int y)
        {
            if (map.TopPriorityL3)
            {
                if (prioritySet.SubscreenL3 && state.Layer3 && map.GraphicSetL3 != 0xFF)
                {
                    tile = GetTilePixels(L3Priority0, x, y);
                    CopySingleTileToArray(subscreen, tile, Width_p, x, y);
                    Bits.Clear(tile);
                }
                if (prioritySet.SubscreenL2 && state.Layer2)
                {
                    tile = GetTilePixels(L2Priority0, x, y);
                    CopySingleTileToArray(subscreen, tile, Width_p, x, y);
                    Bits.Clear(tile);
                }
                if (prioritySet.SubscreenL1 && state.Layer1)
                {
                    tile = GetTilePixels(L1Priority0, x, y);
                    CopySingleTileToArray(subscreen, tile, Width_p, x, y);
                    Bits.Clear(tile);
                }
                if (prioritySet.SubscreenL2 && state.Layer2)
                {
                    tile = GetTilePixels(L2Priority1, x, y);
                    CopySingleTileToArray(subscreen, tile, Width_p, x, y);
                    Bits.Clear(tile);
                }
                if (prioritySet.SubscreenL1 && state.Layer1)
                {
                    tile = GetTilePixels(L1Priority1, x, y);
                    CopySingleTileToArray(subscreen, tile, Width_p, x, y);
                    Bits.Clear(tile);
                }
                if (prioritySet.SubscreenL3 && state.Layer3 && map.GraphicSetL3 != 0xFF)
                {
                    tile = GetTilePixels(L3Priority1, x, y);
                    CopySingleTileToArray(subscreen, tile, Width_p, x, y);
                    Bits.Clear(tile);
                }
            }
            else if (!map.TopPriorityL3) //[3,0][3,1][2,0][1,0][2,1][1,1]
            {
                if (prioritySet.SubscreenL3 && state.Layer3 && map.GraphicSetL3 != 0xFF)
                {
                    tile = GetTilePixels(L3Priority0, x, y);
                    CopySingleTileToArray(subscreen, tile, Width_p, x, y);
                    Bits.Clear(tile);
                }
                if (prioritySet.SubscreenL3 && state.Layer3 && map.GraphicSetL3 != 0xFF)
                {
                    tile = GetTilePixels(L3Priority1, x, y);
                    CopySingleTileToArray(subscreen, tile, Width_p, x, y);
                    Bits.Clear(tile);
                }
                if (prioritySet.SubscreenL2 && state.Layer2)
                {
                    tile = GetTilePixels(L2Priority0, x, y);
                    CopySingleTileToArray(subscreen, tile, Width_p, x, y);
                    Bits.Clear(tile);
                }
                if (prioritySet.SubscreenL1 && state.Layer1)
                {
                    tile = GetTilePixels(L1Priority0, x, y);
                    CopySingleTileToArray(subscreen, tile, Width_p, x, y);
                    Bits.Clear(tile);
                }
                if (prioritySet.SubscreenL2 && state.Layer2)
                {
                    tile = GetTilePixels(L2Priority1, x, y);
                    CopySingleTileToArray(subscreen, tile, Width_p, x, y);
                    Bits.Clear(tile);
                }
                if (prioritySet.SubscreenL1 && state.Layer1)
                {
                    tile = GetTilePixels(L1Priority1, x, y);
                    CopySingleTileToArray(subscreen, tile, Width_p, x, y);
                    Bits.Clear(tile);
                }
            }
        }

        // Single tile
        private void ChangeSingleTile(int layer, int placement, int tile, int x, int y)
        {
            Tilemaps_tiles[layer][placement] = Tileset.Tilesets_tiles[layer][tile]; // Change the tile in the layer map
            Tile source = Tilemaps_tiles[layer][placement]; // Grab the new tile
            int[] layerA = null, layerB = null; // Just used to save space
            if (layer == 0)
            {
                layerA = L1Priority0;
                layerB = L1Priority1;
            }
            else if (layer == 1)
            {
                layerA = L2Priority0;
                layerB = L2Priority1;
            }
            else if (layer == 2)
            {
                layerA = L3Priority0;
                layerB = L3Priority1;
            }
            ClearSingleTile(layerA, x, y);
            ClearSingleTile(layerB, x, y);
            // Draw all 4 subtiles to the appropriate array based on priority
            if (!source.Subtiles[0].Priority1) // tile 0
                Do.PixelsToPixels(source.Subtiles[0].Pixels, layerA, Width_p, new Rectangle(x, y, 8, 8));
            else
                Do.PixelsToPixels(source.Subtiles[0].Pixels, layerB, Width_p, new Rectangle(x, y, 8, 8));
            if (!source.Subtiles[1].Priority1) // tile 1
                Do.PixelsToPixels(source.Subtiles[1].Pixels, layerA, Width_p, new Rectangle((x + 8), y, 8, 8));
            else
                Do.PixelsToPixels(source.Subtiles[1].Pixels, layerB, Width_p, new Rectangle((x + 8), y, 8, 8));
            if (!source.Subtiles[2].Priority1) // tile 2
                Do.PixelsToPixels(source.Subtiles[2].Pixels, layerA, Width_p, new Rectangle(x, (y + 8), 8, 8));
            else
                Do.PixelsToPixels(source.Subtiles[2].Pixels, layerB, Width_p, new Rectangle(x, (y + 8), 8, 8));
            if (!source.Subtiles[3].Priority1) // tile 3
                Do.PixelsToPixels(source.Subtiles[3].Pixels, layerA, Width_p, new Rectangle((x + 8), (y + 8), 8, 8));
            else
                Do.PixelsToPixels(source.Subtiles[3].Pixels, layerB, Width_p, new Rectangle((x + 8), (y + 8), 8, 8));
            // If we have a subscreen, draw the new tile to it
            if (HaveSubscreen())
            {
                ClearSingleTile(subscreen, x, y);
                DrawSingleSubscreenTile(x, y);
            }
            ClearSingleTile(this.Pixels, x, y);
            DrawSingleMainscreenTile(x, y);
        }
        private void ClearSingleTile(int[] src, int x, int y)
        {
            int counter = 0;
            for (int i = 0; i < 256; i++)
            {
                src[y * Width_p + x + counter] = 0;
                counter++;
                if (counter % 16 == 0)
                {
                    y++;
                    counter = 0;
                }
            }
        }
        public override int GetTileNum(int layer, int x, int y, bool ignoreTransparent)
        {
            if (x < 0) x = 0;
            if (y < 0) y = 0;
            if (x >= Width_p) x = Width_p - 1;
            if (y >= Height_p) y = Height_p - 1;
            Point p = new Point(x % 16, y % 16);
            y /= 16;
            x /= 16;
            int placement = y * Width + x;
            if (layer < 3 && Tilemaps_tiles[layer] != null)
            {
                if (Tilemaps_tiles[layer][placement] == null)
                    return 0;
                if (!ignoreTransparent)
                    return Tilemaps_tiles[layer][placement].Index;
                else if (Tilemaps_tiles[layer][placement].Pixels[p.Y * 16 + p.X] != 0)
                    return Tilemaps_tiles[layer][placement].Index;
                else
                    return 0;
            }
            else
                return 0;
        }
        public override int GetTileNum(int layer, int x, int y)
        {
            return GetTileNum(layer, x, y, false);
        }
        public override int GetTileNum(int index)
        {
            return 0;
        }
        private int[] GetTilePixels(int[] src, int x, int y)
        {
            int counter = 0;
            for (int i = 0; i < 256; i++)
            {
                if (src[y * Width_p + x + counter] != 0)
                    tile[i] = src[y * Width_p + x + counter];
                counter++;
                if (counter % 16 == 0)
                {
                    y++;
                    counter = 0;
                }
            }
            return tile;
        }
        public override void SetTileNum(int tilenum, int layer, int x, int y)
        {
            if (x < 0 || y < 0 || x >= Width_p || y >= Height_p)
                return;
            y /= 16;
            x /= 16;
            int index = y * Width + x;
            if (index < 0x1000)
                ChangeSingleTile(layer, index, tilenum, x * 16, y * 16);
            if (type == TilemapType.TileSwitch)
            {
                if (layer < 2)
                    Bits.SetShort(Tilemaps_bytes[layer], (y * Width + x) * 2, (ushort)tilenum);
                else
                    Tilemaps_bytes[layer][y * Width + x] = (byte)tilenum;
                return;
            }
            switch (layer)
            {
                case 0: Model.Modify_Tilemaps[map.TilemapL1 + 0x40] = true; break;
                case 1: Model.Modify_Tilemaps[map.TilemapL2 + 0x40] = true; break;
                case 2: Model.Modify_Tilemaps[map.TilemapL3] = true; break;
            }
        }
        public override void SetTileNum()
        {
        }

        // Pixels
        private void CopySingleTileToArray(int[] dst, int[] src, int width, int x, int y)
        {
            int counter = 0;
            for (int i = 0; i < 256; i++)
            {
                if (src[i] != 0)
                    dst[y * width + x + counter] = src[i];
                counter++;
                if (counter % 16 == 0)
                {
                    y++;
                    counter = 0;
                }
            }
        }
        public override int GetPixelLayer(int x, int y)
        {
            if (map.TopPriorityL3)
            {
                if (prioritySet.MainscreenL3 && L3Priority1[y * Width_p + x] != 0) return 2;
                else if (prioritySet.MainscreenL1 && L1Priority1[y * Width_p + x] != 0) return 0;
                else if (prioritySet.MainscreenL2 && L2Priority1[y * Width_p + x] != 0) return 1;
                else if (prioritySet.MainscreenL1 && L1Priority0[y * Width_p + x] != 0) return 0;
                else if (prioritySet.MainscreenL2 && L2Priority0[y * Width_p + x] != 0) return 1;
                else if (prioritySet.MainscreenL3 && L3Priority0[y * Width_p + x] != 0) return 2;
            }
            else
            {
                if (prioritySet.MainscreenL1 && L1Priority1[y * Width_p + x] != 0) return 0;
                else if (prioritySet.MainscreenL2 && L2Priority1[y * Width_p + x] != 0) return 1;
                else if (prioritySet.MainscreenL1 && L1Priority0[y * Width_p + x] != 0) return 0;
                else if (prioritySet.MainscreenL2 && L2Priority0[y * Width_p + x] != 0) return 1;
                else if (prioritySet.MainscreenL3 && L3Priority1[y * Width_p + x] != 0) return 2;
                else if (prioritySet.MainscreenL3 && L3Priority0[y * Width_p + x] != 0) return 2;
            }
            return 0;
        }
        public override int[] GetPixels(int layer, Point p, Size s)
        {
            int[] pixels = new int[s.Width * s.Height];
            switch (layer)
            {
                case 0:
                    for (int b = 0, y = p.Y; b < s.Height; b++, y++)
                    {
                        for (int a = 0, x = p.X; a < s.Width; a++, x++)
                        {
                            pixels[b * s.Width + a] = L1Priority0[y * Width_p + x];
                            if (L1Priority1[y * Width_p + x] != 0)
                                pixels[b * s.Width + a] = L1Priority1[y * Width_p + x];
                        }
                    }
                    break;
                case 1:
                    for (int b = 0, y = p.Y; b < s.Height; b++, y++)
                    {
                        for (int a = 0, x = p.X; a < s.Width; a++, x++)
                        {
                            pixels[b * s.Width + a] = L2Priority0[y * Width_p + x];
                            if (L2Priority1[y * Width_p + x] != 0)
                                pixels[b * s.Width + a] = L2Priority1[y * Width_p + x];
                        }
                    }
                    break;
                case 2:
                    for (int b = 0, y = p.Y; b < s.Height; b++, y++)
                    {
                        for (int a = 0, x = p.X; a < s.Width; a++, x++)
                        {
                            pixels[b * s.Width + a] = L3Priority0[y * Width_p + x];
                            if (L3Priority1[y * Width_p + x] != 0)
                                pixels[b * s.Width + a] = L3Priority1[y * Width_p + x];
                        }
                    }
                    break;
                default:
                    goto case 0;
            }
            return pixels;
        }
        public override int[] GetPixels(Point p, Size s)
        {
            int[] pixels = new int[s.Width * s.Height];
            int bgcolor = paletteSet.Palette[16];
            for (int b = 0, y = p.Y; b < s.Height; b++, y++)
            {
                for (int a = 0, x = p.X; a < s.Width; a++, x++)
                {
                    int srcIndex = y * Width_p + x;
                    int dstIndex = b * s.Width + a;
                    if (srcIndex >= this.Pixels.Length || dstIndex >= pixels.Length)
                        continue;
                    if (this.Pixels[srcIndex] != 0)
                        pixels[dstIndex] = Color.FromArgb(this.Pixels[srcIndex]).ToArgb();
                    else if (state.BG)
                        pixels[dstIndex] = Color.FromArgb(bgcolor).ToArgb();
                }
            }
            return pixels;
        }
        public override int[] GetPriority1Pixels()
        {
            int[] pixels = new int[Width_p * Height_p];
            for (int y = 0; y < Height_p; y++)
            {
                for (int x = 0; x < Width_p; x++)
                {
                    if (L1Priority1[y * Width_p + x] != 0 ||
                        L2Priority1[y * Width_p + x] != 0 ||
                        L3Priority1[y * Width_p + x] != 0)
                        pixels[y * Width_p + x] = Color.Blue.ToArgb();
                }
            }
            return pixels;
        }
        private void DoColorMathOnSingleTile(int[] tile, int x, int y)
        {
            for (int w = 0; w < 16; w++)
            {
                for (int v = 0; v < 16; v++)
                {
                    if (subscreen[(y + w) * Width_p + (x + v)] != 0 && tile[w * 16 + v] != 0)
                    {
                        tile[w * 16 + v] = Do.ColorMath(tile[w * 16 + v], subscreen[(y + w) * Width_p + (x + v)],
                            prioritySet.ColorMathHalfIntensity,
                            prioritySet.ColorMathMinusSubscreen);
                    }
                }
            }
        }

        // Parsing
        private void ParseTilemap(Tile[] src, byte[] dst, int tileSize)
        {
            if (src == null)
                return;
            for (int i = 0; i < src.Length; i++)
            {
                if (src[i] == null)
                    continue;
                if (tileSize == 2)
                    Bits.SetShort(dst, i * 2, src[i].Index);
                else
                    dst[i] = (byte)src[i].Index;
            }
        }

        // Inherited
        public override void ParseTilemap()
        {
            ParseTilemap(Tilemaps_tiles[0], Tilemaps_bytes[0], 2);
            ParseTilemap(Tilemaps_tiles[1], Tilemaps_bytes[1], 2);
            ParseTilemap(Tilemaps_tiles[2], Tilemaps_bytes[2], 1);
        }
        public override void RedrawTilemaps()
        {
            // Reset the pixel maps
            InitializeTilemapBytes();
            InitializeTilemapTiles();
            InitializePixelMaps();
            BuildTilemapTiles();

            // Redraw the pixels
            CreatePixelMaps();
            CreateSubscreen();
            CreateMainscreen();
        }
        public void RebuildTilemaps()
        {
            // Reset the pixel maps
            InitializeTilemapBytes();
            InitializeTilemapTiles();
            InitializePixelMaps();
            BuildTilemapTiles();
            // Redraw the pixels
            CreatePixelMaps();
            CreateSubscreen();
            CreateMainscreen();
        }
        public void Clear(int count)
        {
            if (count == 1)
            {
                Model.Tilemaps[map.TilemapL1 + 0x40] = new byte[0x2000];
                Model.Tilemaps[map.TilemapL2 + 0x40] = new byte[0x2000];
                Model.Tilemaps[map.TilemapL3] = new byte[0x1000];
                Model.Modify_Tilemaps[map.TilemapL1 + 0x40] = true;
                Model.Modify_Tilemaps[map.TilemapL2 + 0x40] = true;
                Model.Modify_Tilemaps[map.TilemapL3] = true;
            }
            else
            {
                for (int i = 0; i < count; i++)
                {
                    if (i < 0x40)
                        Model.Tilemaps[i] = new byte[0x1000];
                    else
                        Model.Tilemaps[i] = new byte[0x2000];
                    Model.Modify_Tilemaps[i] = true;
                }
            }
            RedrawTilemaps();
        }

        #endregion

        #endregion
    }
}
