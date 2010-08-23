using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using LAZYSHELL.Properties;

namespace LAZYSHELL
{
    public class Solidity
    {
        static Solidity instance = null;
        static readonly object padlock = new object();
        private int[] quadBasePixels = new int[16 * 8];
        private int[] quadBlockPixels = new int[16 * 24];
        private int[] halfQuadBlockPixels = new int[16 * 16];
        private int[] stairsUpRightLowPixels = new int[16 * 24];
        private int[] stairsUpRightHighPixels = new int[16 * 24];
        private int[] stairsUpLeftLowPixels = new int[16 * 24];
        private int[] stairsUpLeftHighPixels = new int[16 * 24];
        private int[] fieldBasePixels = new int[32 * 16];
        private int[] fieldBlockPixels = new int[32 * 32];
        public int[] QuadBasePixels { get { return quadBasePixels; } }
        public int[] QuadBlockPixels { get { return quadBlockPixels; } }
        public int[] HalfQuadBlockPixels { get { return halfQuadBlockPixels; } }
        public int[] StairsUpRightLowPixels { get { return stairsUpRightLowPixels; } }
        public int[] StairsUpRightHighPixels { get { return stairsUpRightHighPixels; } }
        public int[] StairsUpLeftLowPixels { get { return stairsUpLeftLowPixels; } }
        public int[] StairsUpLeftHighPixels { get { return stairsUpLeftHighPixels; } }
        public int[] FieldBasePixels { get { return fieldBasePixels; } }
        public int[] FieldBlockPixels { get { return fieldBlockPixels; } }
        // tile assignments
        private int[] pixelTiles = new int[1024 * 1024];
        /// <summary>
        /// A tile number is assigned to each pixel (used to display the tile # in the label).
        /// </summary> 
        public int[] PixelTiles { get { return pixelTiles; } set { pixelTiles = value; } }
        private Point[] pixelCoords = new Point[1024 * 1024];
        /// <summary>
        /// An orthographic coord for both X and Y is assigned to each pixel (used to display the Orth X and Y coords in the label).
        /// </summary>
        public Point[] PixelCoords { get { return pixelCoords; } set { pixelCoords = value; } }
        private Point[] tileCoords = new Point[4194];
        /// <summary>
        /// A pixel is assigned to each tile number (used for selecting an orthographic tile).
        /// </summary>
        public Point[] TileCoords { get { return tileCoords; } set { tileCoords = value; } }
        private SolidityTile tile;
        public Solidity()
        {
            quadBasePixels = Do.ImageToPixels(global::LAZYSHELL.Properties.Resources.quadBase, Color.White);
            quadBlockPixels = Do.ImageToPixels(global::LAZYSHELL.Properties.Resources.quadBlock, Color.White);
            halfQuadBlockPixels = Do.ImageToPixels(global::LAZYSHELL.Properties.Resources.halfQuadBlock, Color.White);
            stairsUpLeftLowPixels = Do.ImageToPixels(global::LAZYSHELL.Properties.Resources.stairsUpLeftLow, Color.White);
            stairsUpLeftHighPixels = Do.ImageToPixels(global::LAZYSHELL.Properties.Resources.stairsUpLeftHigh, Color.White);
            stairsUpRightLowPixels = Do.ImageToPixels(global::LAZYSHELL.Properties.Resources.stairsUpRightLow, Color.White);
            stairsUpRightHighPixels = Do.ImageToPixels(global::LAZYSHELL.Properties.Resources.stairsUpRightHigh, Color.White);
            fieldBasePixels = Do.ImageToPixels(global::LAZYSHELL.Properties.Resources.fieldBase, Color.White);
            fieldBlockPixels = Do.ImageToPixels(global::LAZYSHELL.Properties.Resources.fieldBlock, Color.White);
            SetIsometric();
        }
        public static Solidity Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new Solidity();
                    }
                    return instance;
                }
            }
        }
        public int[] GetTilePixels(SolidityTile tile)
        {
            this.tile = tile;
            int[] tilePixels = new int[32 * 784];
            int[] qBase = new int[16 * 8];
            int[] qBlock = new int[16 * 24];
            int[] hqBlock = new int[16 * 16];
            int[] stULLo = new int[16 * 24];
            int[] stULHi = new int[16 * 24];
            int[] stURLo = new int[16 * 24];
            int[] stURHi = new int[16 * 24];
            int hChange = 0;
            /******DRAW BASE TILES******/
            if (tile.BaseTileHeight == 0 && !tile.BaseTileHeightPlusHalf && tile.StairsDirection == 0)
            {
                qBase = ColorQuad(true, false, 0, quadBasePixels);
                if (tile.SolidTopQuadrant)             // draw top quadbase
                {
                    for (int y = (16 + 752); y < (24 + 752); y++)
                    {
                        for (int x = 8; x < 24; x++)
                        { if (qBase[(y - (16 + 752)) * 16 + (x - 8)] != 0) tilePixels[y * 32 + x] = qBase[(y - (16 + 752)) * 16 + (x - 8)]; }
                    }
                }
                if (tile.SolidLeftQuadrant)              // draw left quadbase
                {
                    for (int y = (20 + 752); y < (28 + 752); y++)
                    {
                        for (int x = 0; x < 16; x++)
                        { if (qBase[(y - (20 + 752)) * 16 + x] != 0) tilePixels[y * 32 + x] = qBase[(y - (20 + 752)) * 16 + x]; }
                    }
                }
                if (tile.SolidRightQuadrant)              // draw right quadbase
                {
                    for (int y = (20 + 752); y < (28 + 752); y++)
                    {
                        for (int x = 16; x < 32; x++)
                        { if (qBase[(y - (20 + 752)) * 16 + (x - 16)] != 0) tilePixels[y * 32 + x] = qBase[(y - (20 + 752)) * 16 + (x - 16)]; }
                    }
                }
                if (tile.SolidBottomQuadrant)              // draw bottom quadbase
                {
                    for (int y = (24 + 752); y < (32 + 752); y++)
                    {
                        for (int x = 8; x < 24; x++)
                        { if (qBase[(y - (24 + 752)) * 16 + (x - 8)] != 0) tilePixels[y * 32 + x] = qBase[(y - (24 + 752)) * 16 + (x - 8)]; }
                    }
                }
            }
            /******DRAW TILES THAT HAVE A HEIGHT PLUS 1/2 A TILE******/
            else if (tile.BaseTileHeight == 0 && tile.BaseTileHeightPlusHalf) // total height = 1/2
            {
                hqBlock = ColorQuad(true, false, 2, halfQuadBlockPixels);
                if (tile.SolidTopQuadrant)             // draw top quadblock
                {
                    for (int y = (8 + 752); y < (24 + 752); y++) // start 16 pixels above normal base start (ie. 240 - 16)
                    {
                        for (int x = 8; x < 24; x++)
                        { if (hqBlock[(y - (8 + 752)) * 16 + (x - 8)] != 0) tilePixels[y * 32 + x] = hqBlock[(y - (8 + 752)) * 16 + (x - 8)]; }
                    }
                }
                if (tile.SolidLeftQuadrant)              // draw left quadblock
                {
                    for (int y = (12 + 752); y < (28 + 752); y++)
                    {
                        for (int x = 0; x < 16; x++)
                        { if (hqBlock[(y - (12 + 752)) * 16 + x] != 0) tilePixels[y * 32 + x] = hqBlock[(y - (12 + 752)) * 16 + x]; }
                    }
                }
                if (tile.SolidRightQuadrant)              // draw right quadblock
                {
                    for (int y = (12 + 752); y < (28 + 752); y++)
                    {
                        for (int x = 16; x < 32; x++)
                        { if (hqBlock[(y - (12 + 752)) * 16 + (x - 16)] != 0) tilePixels[y * 32 + x] = hqBlock[(y - (12 + 752)) * 16 + (x - 16)]; }
                    }
                }
                if (tile.SolidBottomQuadrant)              // draw bottom quadblock
                {
                    for (int y = (16 + 752); y < (32 + 752); y++)
                    {
                        for (int x = 8; x < 24; x++)
                        { if (hqBlock[(y - (16 + 752)) * 16 + (x - 8)] != 0) tilePixels[y * 32 + x] = hqBlock[(y - (16 + 752)) * 16 + (x - 8)]; }
                    }
                }
            }
            /******DRAW STAIRS THAT LEAD UP-LEFT******/
            else if (tile.BaseTileHeight == 0 && tile.StairsDirection == 1)
            {
                if (tile.SolidTopQuadrant)             // draw top quadbase
                {
                    stULHi = ColorQuad(true, false, 1, stairsUpLeftHighPixels);
                    for (int y = (0 + 752); y < (24 + 752); y++)
                    {
                        for (int x = 8; x < 24; x++)
                        { if (stULHi[(y - (0 + 752)) * 16 + (x - 8)] != 0) tilePixels[y * 32 + x] = stULHi[(y - (0 + 752)) * 16 + (x - 8)]; }
                    }
                }
                if (tile.SolidLeftQuadrant)              // draw left quadbase
                {
                    stULHi = ColorQuad(true, false, 1, stairsUpLeftHighPixels);
                    for (int y = (4 + 752); y < (28 + 752); y++)
                    {
                        for (int x = 0; x < 16; x++)
                        { if (stULHi[(y - (4 + 752)) * 16 + x] != 0) tilePixels[y * 32 + x] = stULHi[(y - (4 + 752)) * 16 + x]; }
                    }
                }
                if (tile.SolidRightQuadrant)              // draw right quadbase
                {
                    stULLo = ColorQuad(true, false, 1, stairsUpLeftLowPixels);
                    for (int y = (4 + 752); y < (28 + 752); y++)
                    {
                        for (int x = 16; x < 32; x++)
                        { if (stULLo[(y - (4 + 752)) * 16 + (x - 16)] != 0) tilePixels[y * 32 + x] = stULLo[(y - (4 + 752)) * 16 + (x - 16)]; }
                    }
                }
                if (tile.SolidBottomQuadrant)              // draw bottom quadbase
                {
                    stULLo = ColorQuad(true, false, 1, stairsUpLeftLowPixels);
                    for (int y = (8 + 752); y < (32 + 752); y++)
                    {
                        for (int x = 8; x < 24; x++)
                        { if (stULLo[(y - (8 + 752)) * 16 + (x - 8)] != 0) tilePixels[y * 32 + x] = stULLo[(y - (8 + 752)) * 16 + (x - 8)]; }
                    }
                }
            }
            /******DRAW STAIRS THAT LEAD UP-RIGHT******/
            else if (tile.BaseTileHeight == 0 && tile.StairsDirection == 2)
            {
                if (tile.SolidTopQuadrant)             // draw top quadbase
                {
                    stURHi = ColorQuad(true, false, 1, stairsUpRightHighPixels);
                    for (int y = (0 + 752); y < (24 + 752); y++)
                    {
                        for (int x = 8; x < 24; x++)
                        { if (stURHi[(y - (0 + 752)) * 16 + (x - 8)] != 0) tilePixels[y * 32 + x] = stURHi[(y - (0 + 752)) * 16 + (x - 8)]; }
                    }
                }
                if (tile.SolidLeftQuadrant)              // draw left quadbase
                {
                    stURLo = ColorQuad(true, false, 1, stairsUpRightLowPixels);
                    for (int y = (4 + 752); y < (28 + 752); y++)
                    {
                        for (int x = 0; x < 16; x++)
                        { if (stURLo[(y - (4 + 752)) * 16 + x] != 0) tilePixels[y * 32 + x] = stURLo[(y - (4 + 752)) * 16 + x]; }
                    }
                }
                if (tile.SolidRightQuadrant)              // draw right quadbase
                {
                    stURHi = ColorQuad(true, false, 1, stairsUpRightHighPixels);
                    for (int y = (4 + 752); y < (28 + 752); y++)
                    {
                        for (int x = 16; x < 32; x++)
                        { if (stURHi[(y - (4 + 752)) * 16 + (x - 16)] != 0) tilePixels[y * 32 + x] = stURHi[(y - (4 + 752)) * 16 + (x - 16)]; }
                    }
                }
                if (tile.SolidBottomQuadrant)              // draw bottom quadbase
                {
                    stURLo = ColorQuad(true, false, 1, stairsUpRightLowPixels);
                    for (int y = (8 + 752); y < (32 + 752); y++)
                    {
                        for (int x = 8; x < 24; x++)
                        { if (stURLo[(y - (8 + 752)) * 16 + (x - 8)] != 0) tilePixels[y * 32 + x] = stURLo[(y - (8 + 752)) * 16 + (x - 8)]; }
                    }
                }
            }
            /******DRAW TILES THAT HAVE HEIGHT > 0******/
            else if (tile.BaseTileHeight > 0)
            {
                qBlock = ColorQuad(true, false, 1, quadBlockPixels);
                hqBlock = ColorQuad(true, false, 2, halfQuadBlockPixels);
                int b = 0;
                if (tile.SolidTopQuadrant)             // draw top quadblock
                {
                    for (b = 0; b < tile.BaseTileHeight; b++)    // draw a block for each unit (ie. a height of 6 would draw 6 blocks on top each other)
                    {
                        hChange = (b * 32) - (b * 16);
                        for (int y = (0 + 752) - hChange; y < (24 + 752) - hChange; y++) // start 16 pixels above normal base start (ie. 240 - 16)
                        {
                            for (int x = 8; x < 24; x++)
                            { if (qBlock[(y - ((0 + 752) - hChange)) * 16 + (x - 8)] != 0) tilePixels[y * 32 + x] = qBlock[(y - ((0 + 752) - hChange)) * 16 + (x - 8)]; }
                        }
                    }
                    if (tile.BaseTileHeightPlusHalf)
                    {
                        hChange = (b * 32) - (b * 16);
                        for (int y = (8 + 752) - hChange; y < (24 + 752) - hChange; y++) // start 16 pixels above normal base start (ie. 240 - 16)
                        {
                            for (int x = 8; x < 24; x++)
                            { if (hqBlock[(y - ((8 + 752) - hChange)) * 16 + (x - 8)] != 0) tilePixels[y * 32 + x] = hqBlock[(y - ((8 + 752) - hChange)) * 16 + (x - 8)]; }
                        }
                    }
                    if (tile.StairsDirection == 1)
                    {
                        hChange = (b * 32) - (b * 16);
                        stULHi = ColorQuad(true, false, 1, stairsUpLeftHighPixels);
                        for (int y = (0 + 752) - hChange; y < (24 + 752) - hChange; y++)
                        {
                            for (int x = 8; x < 24; x++)
                            { if (stULHi[(y - ((0 + 752) - hChange)) * 16 + (x - 8)] != 0) tilePixels[y * 32 + x] = stULHi[(y - ((0 + 752) - hChange)) * 16 + (x - 8)]; }
                        }
                    }
                    else if (tile.StairsDirection == 2)
                    {
                        hChange = (b * 32) - (b * 16);
                        stURHi = ColorQuad(true, false, 1, stairsUpRightHighPixels);
                        for (int y = (0 + 752) - hChange; y < (24 + 752) - hChange; y++)
                        {
                            for (int x = 8; x < 24; x++)
                            { if (stURHi[(y - ((0 + 752) - hChange)) * 16 + (x - 8)] != 0) tilePixels[y * 32 + x] = stURHi[(y - ((0 + 752) - hChange)) * 16 + (x - 8)]; }
                        }
                    }
                }
                if (tile.SolidLeftQuadrant)              // draw left quadblock
                {
                    for (b = 0; b < tile.BaseTileHeight; b++)    // draw a block for each unit (ie. a height of 6 would draw 6 blocks on top each other)
                    {
                        hChange = (b * 32) - (b * 16);
                        for (int y = (4 + 752) - hChange; y < (28 + 752) - hChange; y++)
                        {
                            for (int x = 0; x < 16; x++)
                            { if (qBlock[(y - ((4 + 752) - hChange)) * 16 + x] != 0) tilePixels[y * 32 + x] = qBlock[(y - ((4 + 752) - hChange)) * 16 + x]; }
                        }
                    }
                    if (tile.BaseTileHeightPlusHalf)
                    {
                        hChange = (b * 32) - (b * 16);
                        for (int y = (12 + 752) - hChange; y < (28 + 752) - hChange; y++)
                        {
                            for (int x = 0; x < 16; x++)
                            { if (hqBlock[(y - ((12 + 752) - hChange)) * 16 + x] != 0) tilePixels[y * 32 + x] = hqBlock[(y - ((12 + 752) - hChange)) * 16 + x]; }
                        }
                    }
                    if (tile.StairsDirection == 1)
                    {
                        hChange = (b * 32) - (b * 16);
                        stULHi = ColorQuad(true, false, 1, stairsUpLeftHighPixels);
                        for (int y = (4 + 752) - hChange; y < (28 + 752) - hChange; y++)
                        {
                            for (int x = 0; x < 16; x++)
                            { if (stULHi[(y - ((4 + 752) - hChange)) * 16 + x] != 0) tilePixels[y * 32 + x] = stULHi[(y - ((4 + 752) - hChange)) * 16 + x]; }
                        }
                    }
                    else if (tile.StairsDirection == 2)
                    {
                        hChange = (b * 32) - (b * 16);
                        stURLo = ColorQuad(true, false, 1, stairsUpRightLowPixels);
                        for (int y = (4 + 752) - hChange; y < (28 + 752) - hChange; y++)
                        {
                            for (int x = 0; x < 16; x++)
                            { if (stURLo[(y - ((4 + 752) - hChange)) * 16 + x] != 0) tilePixels[y * 32 + x] = stURLo[(y - ((4 + 752) - hChange)) * 16 + x]; }
                        }
                    }
                }
                if (tile.SolidRightQuadrant)              // draw right quadblock
                {
                    for (b = 0; b < tile.BaseTileHeight; b++)    // draw a block for each unit (ie. a height of 6 would draw 6 blocks on top each other)
                    {
                        hChange = (b * 32) - (b * 16);
                        for (int y = (4 + 752) - hChange; y < (28 + 752) - hChange; y++)
                        {
                            for (int x = 16; x < 32; x++)
                            { if (qBlock[(y - ((4 + 752) - hChange)) * 16 + (x - 16)] != 0) tilePixels[y * 32 + x] = qBlock[(y - ((4 + 752) - hChange)) * 16 + (x - 16)]; }
                        }
                    }
                    if (tile.BaseTileHeightPlusHalf)
                    {
                        hChange = (b * 32) - (b * 16);
                        for (int y = (12 + 752) - hChange; y < (28 + 752) - hChange; y++)
                        {
                            for (int x = 16; x < 32; x++)
                            { if (hqBlock[(y - ((12 + 752) - hChange)) * 16 + (x - 16)] != 0) tilePixels[y * 32 + x] = hqBlock[(y - ((12 + 752) - hChange)) * 16 + (x - 16)]; }
                        }
                    }
                    if (tile.StairsDirection == 1)
                    {
                        hChange = (b * 32) - (b * 16);
                        stULLo = ColorQuad(true, false, 1, stairsUpLeftLowPixels);
                        for (int y = (4 + 752) - hChange; y < (28 + 752) - hChange; y++)
                        {
                            for (int x = 16; x < 32; x++)
                            { if (stULLo[(y - ((4 + 752) - hChange)) * 16 + (x - 16)] != 0) tilePixels[y * 32 + x] = stULLo[(y - ((4 + 752) - hChange)) * 16 + (x - 16)]; }
                        }
                    }
                    else if (tile.StairsDirection == 2)
                    {
                        hChange = (b * 32) - (b * 16);
                        stURHi = ColorQuad(true, false, 1, stairsUpRightHighPixels);
                        for (int y = (4 + 752) - hChange; y < (28 + 752) - hChange; y++)
                        {
                            for (int x = 16; x < 32; x++)
                            { if (stURHi[(y - ((4 + 752) - hChange)) * 16 + (x - 16)] != 0) tilePixels[y * 32 + x] = stURHi[(y - ((4 + 752) - hChange)) * 16 + (x - 16)]; }
                        }
                    }
                }
                if (tile.SolidBottomQuadrant)              // draw bottom quadblock
                {
                    for (b = 0; b < tile.BaseTileHeight; b++)    // draw a block for each unit (ie. a height of 6 would draw 6 blocks on top each other)
                    {
                        hChange = (b * 32) - (b * 16);
                        for (int y = (8 + 752) - hChange; y < (32 + 752) - hChange; y++)
                        {
                            for (int x = 8; x < 24; x++)
                            { if (qBlock[(y - ((8 + 752) - hChange)) * 16 + (x - 8)] != 0) tilePixels[y * 32 + x] = qBlock[(y - ((8 + 752) - hChange)) * 16 + (x - 8)]; }
                        }
                    }
                    if (tile.BaseTileHeightPlusHalf)
                    {
                        hChange = (b * 32) - (b * 16);
                        for (int y = (16 + 752) - hChange; y < (32 + 752) - hChange; y++)
                        {
                            for (int x = 8; x < 24; x++)
                            { if (hqBlock[(y - ((16 + 752) - hChange)) * 16 + (x - 8)] != 0) tilePixels[y * 32 + x] = hqBlock[(y - ((16 + 752) - hChange)) * 16 + (x - 8)]; }
                        }
                    }
                    if (tile.StairsDirection == 1)
                    {
                        hChange = (b * 32) - (b * 16);
                        stULLo = ColorQuad(true, false, 1, stairsUpLeftLowPixels);
                        for (int y = (8 + 752) - hChange; y < (32 + 752) - hChange; y++)
                        {
                            for (int x = 8; x < 24; x++)
                            { if (stULLo[(y - ((8 + 752) - hChange)) * 16 + (x - 8)] != 0) tilePixels[y * 32 + x] = stULLo[(y - ((8 + 752) - hChange)) * 16 + (x - 8)]; }
                        }
                    }
                    else if (tile.StairsDirection == 2)
                    {
                        hChange = (b * 32) - (b * 16);
                        stURLo = ColorQuad(true, false, 1, stairsUpRightLowPixels);
                        for (int y = (8 + 752) - hChange; y < (32 + 752) - hChange; y++)
                        {
                            for (int x = 8; x < 24; x++)
                            { if (stURLo[(y - ((8 + 752) - hChange)) * 16 + (x - 8)] != 0) tilePixels[y * 32 + x] = stURLo[(y - ((8 + 752) - hChange)) * 16 + (x - 8)]; }
                        }
                    }
                }
            }
            /******DRAW OVERHEAD WATER TILES******/
            int overH = tile.WaterTileCoordZ * 16; int baseT = tile.BaseTileHeight * 16;
            if (tile.WaterTileCoordZ != 0)
            {
                qBase = ColorQuad(false, true, 0, quadBasePixels);
                if (tile.SolidTopQuadrant)             // draw top quadbase
                {
                    for (int y = (16 + 752) - overH - baseT; y < (24 + 752) - overH - baseT; y++)
                    {
                        for (int x = 8; x < 24; x++)
                        { if (qBase[(y - ((16 + 752) - overH - baseT)) * 16 + (x - 8)] != 0) tilePixels[y * 32 + x] = qBase[(y - ((16 + 752) - overH - baseT)) * 16 + (x - 8)]; }
                    }
                }
                if (tile.SolidLeftQuadrant)              // draw left quadbase
                {
                    for (int y = (20 + 752) - overH - baseT; y < (28 + 752) - overH - baseT; y++)
                    {
                        for (int x = 0; x < 16; x++)
                        { if (qBase[(y - ((20 + 752) - overH - baseT)) * 16 + x] != 0) tilePixels[y * 32 + x] = qBase[(y - ((20 + 752) - overH - baseT)) * 16 + x]; }
                    }
                }
                if (tile.SolidRightQuadrant)              // draw right quadbase
                {
                    for (int y = (20 + 752) - overH - baseT; y < (28 + 752) - overH - baseT; y++)
                    {
                        for (int x = 16; x < 32; x++)
                        { if (qBase[(y - ((20 + 752) - overH - baseT)) * 16 + (x - 16)] != 0) tilePixels[y * 32 + x] = qBase[(y - ((20 + 752) - overH - baseT)) * 16 + (x - 16)]; }
                    }
                }
                if (tile.SolidBottomQuadrant)              // draw bottom quadbase
                {
                    for (int y = (24 + 752) - overH - baseT; y < (32 + 752) - overH - baseT; y++)
                    {
                        for (int x = 8; x < 24; x++)
                        { if (qBase[(y - ((24 + 752) - overH - baseT)) * 16 + (x - 8)] != 0) tilePixels[y * 32 + x] = qBase[(y - ((24 + 752) - overH - baseT)) * 16 + (x - 8)]; }
                    }
                }
            }
            /******DRAW OVERHEAD TILES******/
            overH = tile.OverheadTileCoordZ * 16; baseT = tile.BaseTileHeight * 16;
            if (tile.OverheadTileHeight == 0 && tile.OverheadTileCoordZ != 0)
            {
                qBase = ColorQuad(false, false, 0, quadBasePixels);
                if (tile.SolidTopQuadrant)             // draw top quadbase
                {
                    for (int y = (16 + 752) - overH - baseT; y < (24 + 752) - overH - baseT; y++)
                    {
                        for (int x = 8; x < 24; x++)
                        { if (qBase[(y - ((16 + 752) - overH - baseT)) * 16 + (x - 8)] != 0) tilePixels[y * 32 + x] = qBase[(y - ((16 + 752) - overH - baseT)) * 16 + (x - 8)]; }
                    }
                }
                if (tile.SolidLeftQuadrant)              // draw left quadbase
                {
                    for (int y = (20 + 752) - overH - baseT; y < (28 + 752) - overH - baseT; y++)
                    {
                        for (int x = 0; x < 16; x++)
                        { if (qBase[(y - ((20 + 752) - overH - baseT)) * 16 + x] != 0) tilePixels[y * 32 + x] = qBase[(y - ((20 + 752) - overH - baseT)) * 16 + x]; }
                    }
                }
                if (tile.SolidRightQuadrant)              // draw right quadbase
                {
                    for (int y = (20 + 752) - overH - baseT; y < (28 + 752) - overH - baseT; y++)
                    {
                        for (int x = 16; x < 32; x++)
                        { if (qBase[(y - ((20 + 752) - overH - baseT)) * 16 + (x - 16)] != 0) tilePixels[y * 32 + x] = qBase[(y - ((20 + 752) - overH - baseT)) * 16 + (x - 16)]; }
                    }
                }
                if (tile.SolidBottomQuadrant)              // draw bottom quadbase
                {
                    for (int y = (24 + 752) - overH - baseT; y < (32 + 752) - overH - baseT; y++)
                    {
                        for (int x = 8; x < 24; x++)
                        { if (qBase[(y - ((24 + 752) - overH - baseT)) * 16 + (x - 8)] != 0) tilePixels[y * 32 + x] = qBase[(y - ((24 + 752) - overH - baseT)) * 16 + (x - 8)]; }
                    }
                }
            }
            /******DRAW OVERHEAD TILES THAT HAVE A HEIGHT > 0******/
            else if (tile.OverheadTileHeight != 0)
            {
                qBlock = ColorQuad(false, false, 1, quadBlockPixels); hqBlock = ColorQuad(false, false, 2, halfQuadBlockPixels);
                int b = 0;
                if (tile.SolidTopQuadrant)             // draw top quadblock
                {
                    for (b = 0; b < tile.OverheadTileHeight; b++)    // draw a block for each unit (ie. a height of 6 would draw 6 blocks on top each other)
                    {
                        hChange = (b * 32) - (b * 16);
                        for (int y = (0 + 752) - hChange - overH - baseT; y < (24 + 752) - hChange - overH - baseT; y++) // start 16 pixels above normal base start (ie. 240 - 16)
                        {
                            for (int x = 8; x < 24; x++)
                            { if (qBlock[(y - ((0 + 752) - hChange - overH - baseT)) * 16 + (x - 8)] != 0) tilePixels[y * 32 + x] = qBlock[(y - ((0 + 752) - hChange - overH - baseT)) * 16 + (x - 8)]; }
                        }
                    }
                }
                if (tile.SolidLeftQuadrant)              // draw left quadblock
                {
                    for (b = 0; b < tile.OverheadTileHeight; b++)    // draw a block for each unit (ie. a height of 6 would draw 6 blocks on top each other)
                    {
                        hChange = (b * 32) - (b * 16);
                        for (int y = (4 + 752) - hChange - overH - baseT; y < (28 + 752) - hChange - overH - baseT; y++)
                        {
                            for (int x = 0; x < 16; x++)
                            { if (qBlock[(y - ((4 + 752) - hChange - overH - baseT)) * 16 + x] != 0) tilePixels[y * 32 + x] = qBlock[(y - ((4 + 752) - hChange - overH - baseT)) * 16 + x]; }
                        }
                    }
                }
                if (tile.SolidRightQuadrant)              // draw right quadblock
                {
                    for (b = 0; b < tile.OverheadTileHeight; b++)    // draw a block for each unit (ie. a height of 6 would draw 6 blocks on top each other)
                    {
                        hChange = (b * 32) - (b * 16);
                        for (int y = (4 + 752) - hChange - overH - baseT; y < (28 + 752) - hChange - overH - baseT; y++)
                        {
                            for (int x = 16; x < 32; x++)
                            { if (qBlock[(y - ((4 + 752) - hChange - overH - baseT)) * 16 + (x - 16)] != 0) tilePixels[y * 32 + x] = qBlock[(y - ((4 + 752) - hChange - overH - baseT)) * 16 + (x - 16)]; }
                        }
                    }
                }
                if (tile.SolidBottomQuadrant)              // draw bottom quadblock
                {
                    for (b = 0; b < tile.OverheadTileHeight; b++)    // draw a block for each unit (ie. a height of 6 would draw 6 blocks on top each other)
                    {
                        hChange = (b * 32) - (b * 16);
                        for (int y = (8 + 752) - hChange - overH - baseT; y < (32 + 752) - hChange - overH - baseT; y++)
                        {
                            for (int x = 8; x < 24; x++)
                            { if (qBlock[(y - ((8 + 752) - hChange - overH - baseT)) * 16 + (x - 8)] != 0) tilePixels[y * 32 + x] = qBlock[(y - ((8 + 752) - hChange - overH - baseT)) * 16 + (x - 8)]; }
                        }
                    }
                }
            }
            return tilePixels;
        }
        public int[] GetTilemapPixels(Map map)
        {
            /*********DRAW THE PHYSICAL MAP FROM BUFFER*********/
            SolidityTile[] tiles = State.Instance.Model.PhysicalTiles;
            int[] pixels = new int[1024 * 1024];
            int[] tilePixels = new int[32 * 784];
            ushort tileNum;
            int currTilePosX = 0;
            int currTilePosY = 0;
            int offset = 0;
            int xPixel = 0;
            int yPixel = 0;
            while (offset < map.Tilemap.Length)
            {
                tileNum = Bits.GetShort(map.Tilemap, offset);
                currTilePosX = tileCoords[offset / 2].X;
                currTilePosY = tileCoords[offset / 2].Y;
                if (tileNum != 0)
                {
                    //tilePixels = physicalTiles[tileNum].PhysicalTilePixels;
                    tilePixels = GetTilePixels(tiles[tileNum]);
                    for (int a = 752 - tiles[tileNum].TotalHeight; a < 784; a++)
                    {
                        for (int b = 0; b < 32; b++)
                        {
                            xPixel = currTilePosX + b;
                            yPixel = currTilePosY + a - 768;
                            if (xPixel >= 0 && xPixel < 1024 && yPixel >= 0 && yPixel < 1024)
                            {
                                if (tilePixels[b + (a * 32)] != 0)
                                    pixels[xPixel + (yPixel * 1024)] = tilePixels[b + (a * 32)];
                            }
                        }
                    }
                }
                offset += 2;
            }
            return pixels;
        }
        public void RefreshTilemapImage(Map map, int offset)
        {
            SolidityTile[] tiles = State.Instance.Model.PhysicalTiles;
            int[] tilePixels = new int[32 * 784];
            ushort tileNum;
            int currTilePosX = 0;
            int currTilePosY = 0;
            int xPixel = 0;
            int yPixel = 0;

            bool twoTiles = false;
            // initialize offset based on column of tile to change
            offset /= 2;
            offset = offset % 65;
            // determine if we start with two or one tile
            if (offset >= 33 && offset <= 64)
            {
                offset -= 33;
                twoTiles = true;
            }
            offset *= 2;
            // do the loop
            while (offset < map.Tilemap.Length)
            {
                if (twoTiles)
                {
                    // ...draw eastern half of left tile
                    tileNum = Bits.GetShort(map.Tilemap, offset);
                    currTilePosX = tileCoords[offset / 2].X;
                    currTilePosY = tileCoords[offset / 2].Y;

                    if (tileNum != 0)
                    {
                        tilePixels = GetTilePixels(tiles[tileNum]);

                        for (int a = 752 - tiles[tileNum].TotalHeight; a < 784; a++)
                        {
                            for (int b = 16; b < 32; b++)    // b = 16, ie. start at eastern half
                            {
                                xPixel = currTilePosX + b;
                                yPixel = currTilePosY + a - 768;

                                if (xPixel >= 0 && xPixel < 1024 && yPixel >= 0 && yPixel < 1024)
                                {
                                    if (tilePixels[b + (a * 32)] != 0)
                                    {
                                        map.Pixels[xPixel + (yPixel * 1024)] = tilePixels[b + (a * 32)];
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        for (int b = Math.Max(currTilePosY, 0); b < Math.Min(Math.Max(currTilePosY, 0) + 16, 1023); b++)
                        {
                            for (int a = Math.Max(currTilePosX, 0) + 16; a < Math.Min(Math.Max(currTilePosX, 0) + 32, 1023); a++)
                            {
                                if (pixelTiles[b * 1024 + a] == offset / 2)
                                    map.Pixels[b * 1024 + a] = 0;
                            }
                        }
                    }

                    offset += 2;

                    if (offset >= map.Tilemap.Length) break;

                    // ...draw western half of right tile
                    tileNum = Bits.GetShort(map.Tilemap, offset);
                    currTilePosX = tileCoords[offset / 2].X;
                    currTilePosY = tileCoords[offset / 2].Y;

                    if (tileNum != 0)
                    {
                        tilePixels = GetTilePixels(tiles[tileNum]);

                        for (int a = 752 - tiles[tileNum].TotalHeight; a < 784; a++)
                        {
                            for (int b = 0; b < 16; b++)    // b < 16, ie. stop when western half done drawing
                            {
                                xPixel = currTilePosX + b;
                                yPixel = currTilePosY + a - 768;

                                if (xPixel >= 0 && xPixel < 1024 && yPixel >= 0 && yPixel < 1024)
                                {
                                    if (tilePixels[b + (a * 32)] != 0)
                                    {
                                        map.Pixels[xPixel + (yPixel * 1024)] = tilePixels[b + (a * 32)];
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        for (int b = Math.Max(currTilePosY, 0); b < Math.Min(Math.Max(currTilePosY, 0) + 16, 1023); b++)
                        {
                            for (int a = Math.Max(currTilePosX, 0); a < Math.Min(Math.Max(currTilePosX, 0) + 16, 1023); a++)
                            {
                                if (pixelTiles[b * 1024 + a] == offset / 2)
                                    map.Pixels[b * 1024 + a] = 0;
                            }
                        }
                    }

                    offset += 64;

                    if (offset >= map.Tilemap.Length) break;
                }
                else
                {
                    // ...draw full tile
                    tileNum = Bits.GetShort(map.Tilemap, offset);
                    currTilePosX = tileCoords[offset / 2].X;
                    currTilePosY = tileCoords[offset / 2].Y;

                    if (tileNum != 0)
                    {
                        tilePixels = GetTilePixels(tiles[tileNum]);

                        for (int a = 752 - tiles[tileNum].TotalHeight; a < 784; a++)
                        {
                            for (int b = 0; b < 32; b++)
                            {
                                xPixel = currTilePosX + b;
                                yPixel = currTilePosY + a - 768;

                                if (xPixel >= 0 && xPixel < 1024 && yPixel >= 0 && yPixel < 1024)
                                {
                                    if (tilePixels[b + (a * 32)] != 0)
                                    {
                                        map.Pixels[xPixel + (yPixel * 1024)] = tilePixels[b + (a * 32)];
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        for (int b = Math.Max(currTilePosY, 0); b < Math.Min(Math.Max(currTilePosY, 0) + 16, 1023); b++)
                        {
                            for (int a = Math.Max(currTilePosX, 0); a < Math.Min(Math.Max(currTilePosX, 0) + 32, 1023); a++)
                            {
                                if (pixelTiles[b * 1024 + a] == offset / 2)
                                    map.Pixels[b * 1024 + a] = 0;
                            }
                        }
                    }

                    offset += 64;

                    if (offset >= map.Tilemap.Length) break;
                }
                twoTiles = !twoTiles;
            }
        }
        private int[] ColorQuad(bool isBase, bool isWater, int type, int[] thePixels)
        {
            int[] somePixels = new int[16 * 24];
            int red = 0; int green = 0; int blue = 0;
            int theLighterColor; int theDarkerColor;

            if (!isBase && !isWater) // it is an overhead tile
            {
                if (tile.SpecialTileFormat == 1) { red = 64; green = 255; blue = 64; }
                else { red = 255; green = 255; blue = 255; }
            }
            else if (isBase && !isWater && tile.OverheadTileCoordZ != 0) // it is a base tile and there is something overhead
            {
                if (tile.SpecialTileFormat == 1) { red = 64; green = 128; blue = 64; }
                else if (tile.SpecialTileFormat == 2) { red = 64; green = 64; blue = 128; }
                else { red = 128; green = 128; blue = 128; }
            }
            else if (!isBase && isWater) // it is an overhead water tile
            {
                red = 64; green = 64; blue = 255;
            }
            else if (isBase && isWater && (tile.OverheadTileCoordZ != 0 || tile.WaterTileCoordZ != 0)) // it is a base water tile and there is something overhead
            {
                red = 64; green = 64; blue = 128;
            }
            else if (isBase && isWater) // it is a base water tile and there is nothing overhead
            {
                red = 64; green = 64; blue = 192;
            }
            else // it is a base tile and there is nothing overhead
            {
                if (tile.SpecialTileFormat == 1) { red = 64; green = 192; blue = 64; }
                else if (tile.SpecialTileFormat == 2) { red = 64; green = 64; blue = 192; }
                else { red = 192; green = 192; blue = 192; }
            }

            if (tile.SolidTile && !isBase && tile.OverheadTileCoordZ != 0) { red = 255; green = 64; blue = 64; }
            else if (tile.SolidTile && isBase && tile.OverheadTileCoordZ == 0) { red = 255; green = 64; blue = 64; }

            theLighterColor = Color.FromArgb(red, green, blue).ToArgb();
            theDarkerColor = Color.FromArgb(red - 64, green - 64, blue - 64).ToArgb();

            for (int y = 0; y < 24; y++)
            {
                for (int x = 0; x < 16; x++)
                {
                    if (y >= 8 && type == 0) return somePixels;
                    else if (y >= 16 && type == 2) return somePixels;

                    if (thePixels[y * 16 + x] == Color.FromArgb(192, 192, 192).ToArgb()) somePixels[y * 16 + x] = theLighterColor;
                    else if (thePixels[y * 16 + x] == Color.FromArgb(128, 128, 128).ToArgb()) somePixels[y * 16 + x] = theDarkerColor;
                    else somePixels[y * 16 + x] = thePixels[y * 16 + x];
                }
            }

            return somePixels;
        }
        private void SetIsometric()
        {
            /*********ASSIGN AN INITIAL TOP-LEFT PIXEL X,Y COORD TO EACH TILE NUMBER*********/
            int tileOffset = 0;
            int counter = 0;
            int xPixel = 0;
            int yPixel = 0;

            // Do the odd rows
            for (int y = 0; y < 65; y++)
            {
                for (int x = 0; x < 33; x++)
                {
                    xPixel = (x * 32) - 16;
                    yPixel = (y * 16) - 8;
                    tileCoords[tileOffset].X = xPixel;
                    tileCoords[tileOffset].Y = yPixel;

                    tileOffset++;
                }
                counter += 65;
                tileOffset = counter;
            }

            // Do the even rows
            tileOffset = 33;
            counter = 0;
            for (int y = 0; y < 64; y++)
            {
                for (int x = 0; x < 32; x++)
                {
                    xPixel = (x * 32);
                    yPixel = (y * 16);
                    tileCoords[tileOffset].X = xPixel;
                    tileCoords[tileOffset].Y = yPixel;

                    tileOffset++;
                }
                counter += 65;
                tileOffset = counter + 33;
            }

            int currTilePosX = 0;
            int currTilePosY = 0;
            int offset = 0;

            /*********ASSIGN EACH PIXEL (1024 * 1024) A TILE NUMBER*********/
            while (offset < 0x20C2)
            {
                currTilePosX = tileCoords[offset / 2].X;
                currTilePosY = tileCoords[offset / 2].Y;
                SetTileNum(offset, currTilePosX, currTilePosY);
                offset += 2;
            }

            /*********ASSIGN EACH PIXEL (1024 * 1024) X,Y ORTHOGRAPHIC COORDS*********/
            int[] orthCoord = new int[32 * 128];
            int[] orthCoordX = new int[32];
            int[] orthCoordY = new int[128];

            for (int y = 0; y < 128; y++)
            {
                for (int x = 0; x < 32; x++)
                {
                    orthCoordX[x] = (((x & 127) * 32) + (16 * (y & 1))) - 16;
                    orthCoordY[y] = (y * 8) - 8;
                    SetCoords(x, y, orthCoordX[x], orthCoordY[y]);
                }
            }
        }
        private void SetTileNum(int offset, int currTilePosX, int currTilePosY)
        {
            int leftEdge = 14;
            int rightEdge = 18;
            int temp = 0;

            for (int y = 0; y < 8; y++)
            {
                for (int x = leftEdge; x < rightEdge; x++)
                {
                    temp = x + currTilePosX + ((y + currTilePosY) * 1024);
                    if (temp >= 0 && temp < (1024 * 1024) &&
                        (x + currTilePosX) < 1024 &&
                        (x + currTilePosX) >= 0 &&
                        pixelTiles[temp] == 0)
                        pixelTiles[temp] = offset / 2;
                }

                leftEdge -= 2;
                rightEdge += 2;
            }

            leftEdge = 0;
            rightEdge = 32;

            for (int y = 8; y < 16; y++)
            {
                for (int x = leftEdge; x < rightEdge; x++)
                {
                    temp = x + currTilePosX + ((y + currTilePosY) * 1024);
                    if (temp >= 0 && temp < (1024 * 1024) &&
                        (x + currTilePosX) < 1024 &&
                        (x + currTilePosX) >= 0 &&
                        pixelTiles[temp] == 0)
                        pixelTiles[temp] = offset / 2;
                }

                leftEdge += 2;
                rightEdge -= 2;
            }
        }
        private void SetCoords(int orthX, int orthY, int currTilePosX, int currTilePosY)
        {
            int leftEdge = 14;
            int rightEdge = 18;
            int temp = 0;
            for (int y = 0; y < 8; y++)
            {
                for (int x = leftEdge; x < rightEdge; x++)
                {
                    temp = x + currTilePosX + ((y + currTilePosY) * 1024);
                    if (temp >= 0 && temp < (1024 * 1024) && (x + currTilePosX) < 1024 && (x + currTilePosX) >= 0)
                    {
                        pixelCoords[temp].X = orthX;
                        pixelCoords[temp].Y = orthY;
                    }
                }
                leftEdge -= 2;
                rightEdge += 2;
            }
            leftEdge = 0;
            rightEdge = 32;
            for (int y = 8; y < 16; y++)
            {
                for (int x = leftEdge; x < rightEdge; x++)
                {
                    temp = x + currTilePosX + ((y + currTilePosY) * 1024);
                    if (temp >= 0 && temp < (1024 * 1024) && (x + currTilePosX) < 1024 && (x + currTilePosX) >= 0)
                    {
                        pixelCoords[temp].X = orthX;
                        pixelCoords[temp].Y = orthY;
                    }
                }
                leftEdge += 2;
                rightEdge -= 2;
            }
        }
    }
}
