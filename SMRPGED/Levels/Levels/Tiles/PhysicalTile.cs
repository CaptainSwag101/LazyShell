using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Runtime.InteropServices;

namespace SMRPGED
{
    public class PhysicalTile
    {
        // Local Variables
        // All properties of this class should be private
        private byte[] data;

        private int physicalTileNum; public int PhysicalTileNum { get { return physicalTileNum; } set { physicalTileNum = value; } }
        //private int[] tilePixels; public int[] PhysicalTilePixels { get { return tilePixels; } }

        //this is only used for overlay tile selection:
        private int physicalTileTotalHeight; public int PhysicalTileTotalHeight { get { return physicalTileTotalHeight; } set { physicalTileTotalHeight = value; } }

        private byte baseTileHeight; public byte BaseTileHeight { get { return baseTileHeight; } set { baseTileHeight = value; } }
        private byte overheadTileHeight; public byte OverheadTileHeight { get { return overheadTileHeight; } set { overheadTileHeight = value; } }
        private byte overheadTileCoordZ; public byte OverheadTileCoordZ { get { return overheadTileCoordZ; } set { overheadTileCoordZ = value; } }
        private byte waterTileCoordZ; public byte WaterTileCoordZ { get { return waterTileCoordZ; } set { waterTileCoordZ = value; } }

        private bool conveyorBeltFast; public bool ConveyorBeltFast { get { return conveyorBeltFast; } set { conveyorBeltFast = value; } }
        private bool conveyorBeltNormal; public bool ConveyorBeltNormal { get { return conveyorBeltNormal; } set { conveyorBeltNormal = value; } }
        private bool baseTileHeightPlusHalf; public bool BaseTileHeightPlusHalf { get { return baseTileHeightPlusHalf; } set { baseTileHeightPlusHalf = value; } }
        private bool solidTile; public bool SolidTile { get { return solidTile; } set { solidTile = value; } }

        private bool solidUpperLeftEdge; public bool SolidUpperLeftEdge { get { return solidUpperLeftEdge; } set { solidUpperLeftEdge = value; } }
        private bool solidUpperRightEdge; public bool SolidUpperRightEdge { get { return solidUpperRightEdge; } set { solidUpperRightEdge = value; } }
        private bool solidLowerLeftEdge; public bool SolidLowerLeftEdge { get { return solidLowerLeftEdge; } set { solidLowerLeftEdge = value; } }
        private bool solidLowerRightEdge; public bool SolidLowerRightEdge { get { return solidLowerRightEdge; } set { solidLowerRightEdge = value; } }

        private bool solidLeftQuadrant; public bool SolidLeftQuadrant { get { return solidLeftQuadrant; } set { solidLeftQuadrant = value; } }
        private bool solidRightQuadrant; public bool SolidRightQuadrant { get { return solidRightQuadrant; } set { solidRightQuadrant = value; } }
        private bool solidTopQuadrant; public bool SolidTopQuadrant { get { return solidTopQuadrant; } set { solidTopQuadrant = value; } }
        private bool solidBottomQuadrant; public bool SolidBottomQuadrant { get { return solidBottomQuadrant; } set { solidBottomQuadrant = value; } }

        private bool objectOnEdgePriority3; public bool ObjectOnEdgePriority3 { get { return objectOnEdgePriority3; } set { objectOnEdgePriority3 = value; } }
        private bool objectAboveEdgePriority3; public bool ObjectAboveEdgePriority3 { get { return objectAboveEdgePriority3; } set { objectAboveEdgePriority3 = value; } }
        private bool objectOnTilePriority3; public bool ObjectOnTilePriority3 { get { return objectOnTilePriority3; } set { objectOnTilePriority3 = value; } }
        private bool solidQuadrantFlag; public bool SolidQuadrantFlag { get { return solidQuadrantFlag; } set { solidQuadrantFlag = value; } }

        private byte converyorBeltDirection; public byte ConveryorBeltDirection { get { return converyorBeltDirection; } set { converyorBeltDirection = value; } }
        private byte stairsDirection; public byte StairsDirection { get { return stairsDirection; } set { stairsDirection = value; } }
        private byte specialTileFormat; public byte SpecialTileFormat { get { return specialTileFormat; } set { specialTileFormat = value; } }

        private byte door; public byte Door { get { return door; } set { door = value; } }
        private bool byte5b0; public bool Byte5b0 { get { return byte5b0; } set { byte5b0 = value; } }
        private bool byte5b1; public bool Byte5b1 { get { return byte5b1; } set { byte5b1 = value; } }
        private bool byte5b2; public bool Byte5b2 { get { return byte5b2; } set { byte5b2 = value; } }
        private bool byte5b3; public bool Byte5b3 { get { return byte5b3; } set { byte5b3 = value; } }
        private bool byte5b4; public bool Byte5b4 { get { return byte5b4; } set { byte5b4 = value; } }

        public PhysicalTile(byte[] data, int physicalTileNum)
        {
            this.data = data;
            this.physicalTileNum = physicalTileNum;
            InitializePhysicalTile(data);
        }

        // Dissasembler goes here
        // Initializes all local properties for this class
        private void InitializePhysicalTile(byte[] data)
        {
            byte temp = 0;

            int offset = (physicalTileNum * 6) + 0x3DC000;

            temp = BitManager.GetByte(data, offset); offset++;

            baseTileHeight = (byte)(temp & 0x0F);

            if ((temp & 0x10) == 0x10) conveyorBeltFast = true;
            if ((temp & 0x20) == 0x20) conveyorBeltNormal = true;
            if ((temp & 0x40) == 0x40) baseTileHeightPlusHalf = true;
            if ((temp & 0x80) == 0x80) solidTile = true;

            temp = BitManager.GetByte(data, offset); offset++;

            overheadTileCoordZ = (byte)(temp & 0x0F);

            if ((temp & 0x10) == 0x10) solidUpperLeftEdge = true;
            if ((temp & 0x20) == 0x20) solidUpperRightEdge = true;
            if ((temp & 0x40) == 0x40) solidLowerLeftEdge = true;
            if ((temp & 0x80) == 0x80) solidLowerRightEdge = true;

            switch (temp & 0xF0)
            {
                case 0x00: converyorBeltDirection = 0; break;
                case 0x10: converyorBeltDirection = 1; break;
                case 0x20: converyorBeltDirection = 2; break;
                case 0x30: converyorBeltDirection = 3; break;
                case 0x40: converyorBeltDirection = 4; break;
                case 0x50: converyorBeltDirection = 5; break;
                case 0x60: converyorBeltDirection = 6; break;
                case 0x70: converyorBeltDirection = 7; break;
                default: converyorBeltDirection = 0; break;
            }

            temp = BitManager.GetByte(data, offset); offset++;

            overheadTileHeight = (byte)(temp & 0x0F);

            switch (temp & 0xF0)
            {
                case 0x00: stairsDirection = 0; break;
                case 0x90: stairsDirection = 1; break;
                case 0xB0: stairsDirection = 2; break;
                default: stairsDirection = 0; break;
            }

            temp = BitManager.GetByte(data, offset); offset++;

            if ((temp & 0x01) == 0x01) solidTopQuadrant = true;
            if ((temp & 0x02) == 0x02) solidLeftQuadrant = true;
            if ((temp & 0x04) == 0x04) solidRightQuadrant = true;
            if ((temp & 0x08) == 0x08) solidBottomQuadrant = true;
            if ((temp & 0x10) == 0x10) objectOnEdgePriority3 = true;
            if ((temp & 0x20) == 0x20) objectAboveEdgePriority3 = true;
            if ((temp & 0x40) == 0x40) objectOnTilePriority3 = true;
            if ((temp & 0x80) == 0x80) solidQuadrantFlag = true;

            temp = BitManager.GetByte(data, offset); offset++;

            waterTileCoordZ = (byte)(temp & 0x0F);

            if ((temp & 0xF0) == 0x10) specialTileFormat = 1;
            else if ((temp & 0xF0) == 0x80) specialTileFormat = 2;
            else specialTileFormat = 0;

            physicalTileTotalHeight = (baseTileHeight + overheadTileCoordZ + overheadTileHeight + waterTileCoordZ) * 16;
            if (baseTileHeightPlusHalf) physicalTileTotalHeight += 8;
            if (stairsDirection > 0) physicalTileTotalHeight += 32;

            door = (byte)((data[offset] & 0xE0) >> 5);
            byte5b0 = (data[offset] & 0x01) == 0x01;
            byte5b1 = (data[offset] & 0x02) == 0x02;
            byte5b2 = (data[offset] & 0x04) == 0x04;
            byte5b3 = (data[offset] & 0x08) == 0x08;
            byte5b4 = (data[offset] & 0x10) == 0x10;
        }

        public int[] DrawPhysicalTile(
            int[] qBaseOrig,
            int[] qBlockOrig,
            int[] hqBlockOrig,
            int[] stULLoOrig,
            int[] stULHiOrig,
            int[] stURLoOrig,
            int[] stURHiOrig)
        {
            //tilePixels = new int[32 * 784];
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
            if (baseTileHeight == 0 && !baseTileHeightPlusHalf && stairsDirection == 0)
            {
                qBase = ColorQuad(true, false, 0, qBaseOrig);
                if (solidTopQuadrant)             // draw top quadbase
                {
                    for (int y = (16 + 752); y < (24 + 752); y++)
                    {
                        for (int x = 8; x < 24; x++)
                        { if (qBase[(y - (16 + 752)) * 16 + (x - 8)] != 0) tilePixels[y * 32 + x] = qBase[(y - (16 + 752)) * 16 + (x - 8)]; }
                    }
                }
                if (solidLeftQuadrant)              // draw left quadbase
                {
                    for (int y = (20 + 752); y < (28 + 752); y++)
                    {
                        for (int x = 0; x < 16; x++)
                        { if (qBase[(y - (20 + 752)) * 16 + x] != 0) tilePixels[y * 32 + x] = qBase[(y - (20 + 752)) * 16 + x]; }
                    }
                }
                if (solidRightQuadrant)              // draw right quadbase
                {
                    for (int y = (20 + 752); y < (28 + 752); y++)
                    {
                        for (int x = 16; x < 32; x++)
                        { if (qBase[(y - (20 + 752)) * 16 + (x - 16)] != 0) tilePixels[y * 32 + x] = qBase[(y - (20 + 752)) * 16 + (x - 16)]; }
                    }
                }
                if (solidBottomQuadrant)              // draw bottom quadbase
                {
                    for (int y = (24 + 752); y < (32 + 752); y++)
                    {
                        for (int x = 8; x < 24; x++)
                        { if (qBase[(y - (24 + 752)) * 16 + (x - 8)] != 0) tilePixels[y * 32 + x] = qBase[(y - (24 + 752)) * 16 + (x - 8)]; }
                    }
                }
            }
            /******DRAW TILES THAT HAVE A HEIGHT PLUS 1/2 A TILE******/
            else if (baseTileHeight == 0 && baseTileHeightPlusHalf) // total height = 1/2
            {
                hqBlock = ColorQuad(true, false, 2, hqBlockOrig);
                if (solidTopQuadrant)             // draw top quadblock
                {
                    for (int y = (8 + 752); y < (24 + 752); y++) // start 16 pixels above normal base start (ie. 240 - 16)
                    {
                        for (int x = 8; x < 24; x++)
                        { if (hqBlock[(y - (8 + 752)) * 16 + (x - 8)] != 0) tilePixels[y * 32 + x] = hqBlock[(y - (8 + 752)) * 16 + (x - 8)]; }
                    }
                }
                if (solidLeftQuadrant)              // draw left quadblock
                {
                    for (int y = (12 + 752); y < (28 + 752); y++)
                    {
                        for (int x = 0; x < 16; x++)
                        { if (hqBlock[(y - (12 + 752)) * 16 + x] != 0) tilePixels[y * 32 + x] = hqBlock[(y - (12 + 752)) * 16 + x]; }
                    }
                }
                if (solidRightQuadrant)              // draw right quadblock
                {
                    for (int y = (12 + 752); y < (28 + 752); y++)
                    {
                        for (int x = 16; x < 32; x++)
                        { if (hqBlock[(y - (12 + 752)) * 16 + (x - 16)] != 0) tilePixels[y * 32 + x] = hqBlock[(y - (12 + 752)) * 16 + (x - 16)]; }
                    }
                }
                if (solidBottomQuadrant)              // draw bottom quadblock
                {
                    for (int y = (16 + 752); y < (32 + 752); y++)
                    {
                        for (int x = 8; x < 24; x++)
                        { if (hqBlock[(y - (16 + 752)) * 16 + (x - 8)] != 0) tilePixels[y * 32 + x] = hqBlock[(y - (16 + 752)) * 16 + (x - 8)]; }
                    }
                }
            }
            /******DRAW STAIRS THAT LEAD UP-LEFT******/
            else if (baseTileHeight == 0 && stairsDirection == 1)
            {
                if (solidTopQuadrant)             // draw top quadbase
                {
                    stULHi = ColorQuad(true, false, 1, stULHiOrig);
                    for (int y = (0 + 752); y < (24 + 752); y++)
                    {
                        for (int x = 8; x < 24; x++)
                        { if (stULHi[(y - (0 + 752)) * 16 + (x - 8)] != 0) tilePixels[y * 32 + x] = stULHi[(y - (0 + 752)) * 16 + (x - 8)]; }
                    }
                }
                if (solidLeftQuadrant)              // draw left quadbase
                {
                    stULHi = ColorQuad(true, false, 1, stULHiOrig);
                    for (int y = (4 + 752); y < (28 + 752); y++)
                    {
                        for (int x = 0; x < 16; x++)
                        { if (stULHi[(y - (4 + 752)) * 16 + x] != 0) tilePixels[y * 32 + x] = stULHi[(y - (4 + 752)) * 16 + x]; }
                    }
                }
                if (solidRightQuadrant)              // draw right quadbase
                {
                    stULLo = ColorQuad(true, false, 1, stULLoOrig);
                    for (int y = (4 + 752); y < (28 + 752); y++)
                    {
                        for (int x = 16; x < 32; x++)
                        { if (stULLo[(y - (4 + 752)) * 16 + (x - 16)] != 0) tilePixels[y * 32 + x] = stULLo[(y - (4 + 752)) * 16 + (x - 16)]; }
                    }
                }
                if (solidBottomQuadrant)              // draw bottom quadbase
                {
                    stULLo = ColorQuad(true, false, 1, stULLoOrig);
                    for (int y = (8 + 752); y < (32 + 752); y++)
                    {
                        for (int x = 8; x < 24; x++)
                        { if (stULLo[(y - (8 + 752)) * 16 + (x - 8)] != 0) tilePixels[y * 32 + x] = stULLo[(y - (8 + 752)) * 16 + (x - 8)]; }
                    }
                }
            }
            /******DRAW STAIRS THAT LEAD UP-RIGHT******/
            else if (baseTileHeight == 0 && stairsDirection == 2)
            {
                if (solidTopQuadrant)             // draw top quadbase
                {
                    stURHi = ColorQuad(true, false, 1, stURHiOrig);
                    for (int y = (0 + 752); y < (24 + 752); y++)
                    {
                        for (int x = 8; x < 24; x++)
                        { if (stURHi[(y - (0 + 752)) * 16 + (x - 8)] != 0) tilePixels[y * 32 + x] = stURHi[(y - (0 + 752)) * 16 + (x - 8)]; }
                    }
                }
                if (solidLeftQuadrant)              // draw left quadbase
                {
                    stURLo = ColorQuad(true, false, 1, stURLoOrig);
                    for (int y = (4 + 752); y < (28 + 752); y++)
                    {
                        for (int x = 0; x < 16; x++)
                        { if (stURLo[(y - (4 + 752)) * 16 + x] != 0) tilePixels[y * 32 + x] = stURLo[(y - (4 + 752)) * 16 + x]; }
                    }
                }
                if (solidRightQuadrant)              // draw right quadbase
                {
                    stURHi = ColorQuad(true, false, 1, stURHiOrig);
                    for (int y = (4 + 752); y < (28 + 752); y++)
                    {
                        for (int x = 16; x < 32; x++)
                        { if (stURHi[(y - (4 + 752)) * 16 + (x - 16)] != 0) tilePixels[y * 32 + x] = stURHi[(y - (4 + 752)) * 16 + (x - 16)]; }
                    }
                }
                if (solidBottomQuadrant)              // draw bottom quadbase
                {
                    stURLo = ColorQuad(true, false, 1, stURLoOrig);
                    for (int y = (8 + 752); y < (32 + 752); y++)
                    {
                        for (int x = 8; x < 24; x++)
                        { if (stURLo[(y - (8 + 752)) * 16 + (x - 8)] != 0) tilePixels[y * 32 + x] = stURLo[(y - (8 + 752)) * 16 + (x - 8)]; }
                    }
                }
            }
            /******DRAW TILES THAT HAVE HEIGHT > 0******/
            else if (baseTileHeight > 0)
            {
                qBlock = ColorQuad(true, false, 1, qBlockOrig);
                hqBlock = ColorQuad(true, false, 2, hqBlockOrig);
                int b = 0;
                if (solidTopQuadrant)             // draw top quadblock
                {
                    for (b = 0; b < baseTileHeight; b++)    // draw a block for each unit (ie. a height of 6 would draw 6 blocks on top each other)
                    {
                        hChange = (b * 32) - (b * 16);
                        for (int y = (0 + 752) - hChange; y < (24 + 752) - hChange; y++) // start 16 pixels above normal base start (ie. 240 - 16)
                        {
                            for (int x = 8; x < 24; x++)
                            { if (qBlock[(y - ((0 + 752) - hChange)) * 16 + (x - 8)] != 0) tilePixels[y * 32 + x] = qBlock[(y - ((0 + 752) - hChange)) * 16 + (x - 8)]; }
                        }
                    }
                    if (baseTileHeightPlusHalf)
                    {
                        hChange = (b * 32) - (b * 16);
                        for (int y = (8 + 752) - hChange; y < (24 + 752) - hChange; y++) // start 16 pixels above normal base start (ie. 240 - 16)
                        {
                            for (int x = 8; x < 24; x++)
                            { if (hqBlock[(y - ((8 + 752) - hChange)) * 16 + (x - 8)] != 0) tilePixels[y * 32 + x] = hqBlock[(y - ((8 + 752) - hChange)) * 16 + (x - 8)]; }
                        }
                    }
                    if (stairsDirection == 1)
                    {
                        hChange = (b * 32) - (b * 16);
                        stULHi = ColorQuad(true, false, 1, stULHiOrig);
                        for (int y = (0 + 752) - hChange; y < (24 + 752) - hChange; y++)
                        {
                            for (int x = 8; x < 24; x++)
                            { if (stULHi[(y - ((0 + 752) - hChange)) * 16 + (x - 8)] != 0) tilePixels[y * 32 + x] = stULHi[(y - ((0 + 752) - hChange)) * 16 + (x - 8)]; }
                        }
                    }
                    else if (stairsDirection == 2)
                    {
                        hChange = (b * 32) - (b * 16);
                        stURHi = ColorQuad(true, false, 1, stURHiOrig);
                        for (int y = (0 + 752) - hChange; y < (24 + 752) - hChange; y++)
                        {
                            for (int x = 8; x < 24; x++)
                            { if (stURHi[(y - ((0 + 752) - hChange)) * 16 + (x - 8)] != 0) tilePixels[y * 32 + x] = stURHi[(y - ((0 + 752) - hChange)) * 16 + (x - 8)]; }
                        }
                    }
                }
                if (solidLeftQuadrant)              // draw left quadblock
                {
                    for (b = 0; b < baseTileHeight; b++)    // draw a block for each unit (ie. a height of 6 would draw 6 blocks on top each other)
                    {
                        hChange = (b * 32) - (b * 16);
                        for (int y = (4 + 752) - hChange; y < (28 + 752) - hChange; y++)
                        {
                            for (int x = 0; x < 16; x++)
                            { if (qBlock[(y - ((4 + 752) - hChange)) * 16 + x] != 0) tilePixels[y * 32 + x] = qBlock[(y - ((4 + 752) - hChange)) * 16 + x]; }
                        }
                    }
                    if (baseTileHeightPlusHalf)
                    {
                        hChange = (b * 32) - (b * 16);
                        for (int y = (12 + 752) - hChange; y < (28 + 752) - hChange; y++)
                        {
                            for (int x = 0; x < 16; x++)
                            { if (hqBlock[(y - ((12 + 752) - hChange)) * 16 + x] != 0) tilePixels[y * 32 + x] = hqBlock[(y - ((12 + 752) - hChange)) * 16 + x]; }
                        }
                    }
                    if (stairsDirection == 1)
                    {
                        hChange = (b * 32) - (b * 16);
                        stULHi = ColorQuad(true, false, 1, stULHiOrig);
                        for (int y = (4 + 752) - hChange; y < (28 + 752) - hChange; y++)
                        {
                            for (int x = 0; x < 16; x++)
                            { if (stULHi[(y - ((4 + 752) - hChange)) * 16 + x] != 0) tilePixels[y * 32 + x] = stULHi[(y - ((4 + 752) - hChange)) * 16 + x]; }
                        }
                    }
                    else if (stairsDirection == 2)
                    {
                        hChange = (b * 32) - (b * 16);
                        stURLo = ColorQuad(true, false, 1, stURLoOrig);
                        for (int y = (4 + 752) - hChange; y < (28 + 752) - hChange; y++)
                        {
                            for (int x = 0; x < 16; x++)
                            { if (stURLo[(y - ((4 + 752) - hChange)) * 16 + x] != 0) tilePixels[y * 32 + x] = stURLo[(y - ((4 + 752) - hChange)) * 16 + x]; }
                        }
                    }
                }
                if (solidRightQuadrant)              // draw right quadblock
                {
                    for (b = 0; b < baseTileHeight; b++)    // draw a block for each unit (ie. a height of 6 would draw 6 blocks on top each other)
                    {
                        hChange = (b * 32) - (b * 16);
                        for (int y = (4 + 752) - hChange; y < (28 + 752) - hChange; y++)
                        {
                            for (int x = 16; x < 32; x++)
                            { if (qBlock[(y - ((4 + 752) - hChange)) * 16 + (x - 16)] != 0) tilePixels[y * 32 + x] = qBlock[(y - ((4 + 752) - hChange)) * 16 + (x - 16)]; }
                        }
                    }
                    if (baseTileHeightPlusHalf)
                    {
                        hChange = (b * 32) - (b * 16);
                        for (int y = (12 + 752) - hChange; y < (28 + 752) - hChange; y++)
                        {
                            for (int x = 16; x < 32; x++)
                            { if (hqBlock[(y - ((12 + 752) - hChange)) * 16 + (x - 16)] != 0) tilePixels[y * 32 + x] = hqBlock[(y - ((12 + 752) - hChange)) * 16 + (x - 16)]; }
                        }
                    }
                    if (stairsDirection == 1)
                    {
                        hChange = (b * 32) - (b * 16);
                        stULLo = ColorQuad(true, false, 1, stULLoOrig);
                        for (int y = (4 + 752) - hChange; y < (28 + 752) - hChange; y++)
                        {
                            for (int x = 16; x < 32; x++)
                            { if (stULLo[(y - ((4 + 752) - hChange)) * 16 + (x - 16)] != 0) tilePixels[y * 32 + x] = stULLo[(y - ((4 + 752) - hChange)) * 16 + (x - 16)]; }
                        }
                    }
                    else if (stairsDirection == 2)
                    {
                        hChange = (b * 32) - (b * 16);
                        stURHi = ColorQuad(true, false, 1, stURHiOrig);
                        for (int y = (4 + 752) - hChange; y < (28 + 752) - hChange; y++)
                        {
                            for (int x = 16; x < 32; x++)
                            { if (stURHi[(y - ((4 + 752) - hChange)) * 16 + (x - 16)] != 0) tilePixels[y * 32 + x] = stURHi[(y - ((4 + 752) - hChange)) * 16 + (x - 16)]; }
                        }
                    }
                }
                if (solidBottomQuadrant)              // draw bottom quadblock
                {
                    for (b = 0; b < baseTileHeight; b++)    // draw a block for each unit (ie. a height of 6 would draw 6 blocks on top each other)
                    {
                        hChange = (b * 32) - (b * 16);
                        for (int y = (8 + 752) - hChange; y < (32 + 752) - hChange; y++)
                        {
                            for (int x = 8; x < 24; x++)
                            { if (qBlock[(y - ((8 + 752) - hChange)) * 16 + (x - 8)] != 0) tilePixels[y * 32 + x] = qBlock[(y - ((8 + 752) - hChange)) * 16 + (x - 8)]; }
                        }
                    }
                    if (baseTileHeightPlusHalf)
                    {
                        hChange = (b * 32) - (b * 16);
                        for (int y = (16 + 752) - hChange; y < (32 + 752) - hChange; y++)
                        {
                            for (int x = 8; x < 24; x++)
                            { if (hqBlock[(y - ((16 + 752) - hChange)) * 16 + (x - 8)] != 0) tilePixels[y * 32 + x] = hqBlock[(y - ((16 + 752) - hChange)) * 16 + (x - 8)]; }
                        }
                    }
                    if (stairsDirection == 1)
                    {
                        hChange = (b * 32) - (b * 16);
                        stULLo = ColorQuad(true, false, 1, stULLoOrig);
                        for (int y = (8 + 752) - hChange; y < (32 + 752) - hChange; y++)
                        {
                            for (int x = 8; x < 24; x++)
                            { if (stULLo[(y - ((8 + 752) - hChange)) * 16 + (x - 8)] != 0) tilePixels[y * 32 + x] = stULLo[(y - ((8 + 752) - hChange)) * 16 + (x - 8)]; }
                        }
                    }
                    else if (stairsDirection == 2)
                    {
                        hChange = (b * 32) - (b * 16);
                        stURLo = ColorQuad(true, false, 1, stURLoOrig);
                        for (int y = (8 + 752) - hChange; y < (32 + 752) - hChange; y++)
                        {
                            for (int x = 8; x < 24; x++)
                            { if (stURLo[(y - ((8 + 752) - hChange)) * 16 + (x - 8)] != 0) tilePixels[y * 32 + x] = stURLo[(y - ((8 + 752) - hChange)) * 16 + (x - 8)]; }
                        }
                    }
                }
            }
            /******DRAW OVERHEAD WATER TILES******/
            int overH = waterTileCoordZ * 16; int baseT = baseTileHeight * 16;
            if (waterTileCoordZ != 0)
            {
                qBase = ColorQuad(false, true, 0, qBaseOrig);
                if (solidTopQuadrant)             // draw top quadbase
                {
                    for (int y = (16 + 752) - overH - baseT; y < (24 + 752) - overH - baseT; y++)
                    {
                        for (int x = 8; x < 24; x++)
                        { if (qBase[(y - ((16 + 752) - overH - baseT)) * 16 + (x - 8)] != 0) tilePixels[y * 32 + x] = qBase[(y - ((16 + 752) - overH - baseT)) * 16 + (x - 8)]; }
                    }
                }
                if (solidLeftQuadrant)              // draw left quadbase
                {
                    for (int y = (20 + 752) - overH - baseT; y < (28 + 752) - overH - baseT; y++)
                    {
                        for (int x = 0; x < 16; x++)
                        { if (qBase[(y - ((20 + 752) - overH - baseT)) * 16 + x] != 0) tilePixels[y * 32 + x] = qBase[(y - ((20 + 752) - overH - baseT)) * 16 + x]; }
                    }
                }
                if (solidRightQuadrant)              // draw right quadbase
                {
                    for (int y = (20 + 752) - overH - baseT; y < (28 + 752) - overH - baseT; y++)
                    {
                        for (int x = 16; x < 32; x++)
                        { if (qBase[(y - ((20 + 752) - overH - baseT)) * 16 + (x - 16)] != 0) tilePixels[y * 32 + x] = qBase[(y - ((20 + 752) - overH - baseT)) * 16 + (x - 16)]; }
                    }
                }
                if (solidBottomQuadrant)              // draw bottom quadbase
                {
                    for (int y = (24 + 752) - overH - baseT; y < (32 + 752) - overH - baseT; y++)
                    {
                        for (int x = 8; x < 24; x++)
                        { if (qBase[(y - ((24 + 752) - overH - baseT)) * 16 + (x - 8)] != 0) tilePixels[y * 32 + x] = qBase[(y - ((24 + 752) - overH - baseT)) * 16 + (x - 8)]; }
                    }
                }
            }
            /******DRAW OVERHEAD TILES******/
            overH = overheadTileCoordZ * 16; baseT = baseTileHeight * 16;
            if (overheadTileHeight == 0 && overheadTileCoordZ != 0)
            {
                qBase = ColorQuad(false, false, 0, qBaseOrig);
                if (solidTopQuadrant)             // draw top quadbase
                {
                    for (int y = (16 + 752) - overH - baseT; y < (24 + 752) - overH - baseT; y++)
                    {
                        for (int x = 8; x < 24; x++)
                        { if (qBase[(y - ((16 + 752) - overH - baseT)) * 16 + (x - 8)] != 0) tilePixels[y * 32 + x] = qBase[(y - ((16 + 752) - overH - baseT)) * 16 + (x - 8)]; }
                    }
                }
                if (solidLeftQuadrant)              // draw left quadbase
                {
                    for (int y = (20 + 752) - overH - baseT; y < (28 + 752) - overH - baseT; y++)
                    {
                        for (int x = 0; x < 16; x++)
                        { if (qBase[(y - ((20 + 752) - overH - baseT)) * 16 + x] != 0) tilePixels[y * 32 + x] = qBase[(y - ((20 + 752) - overH - baseT)) * 16 + x]; }
                    }
                }
                if (solidRightQuadrant)              // draw right quadbase
                {
                    for (int y = (20 + 752) - overH - baseT; y < (28 + 752) - overH - baseT; y++)
                    {
                        for (int x = 16; x < 32; x++)
                        { if (qBase[(y - ((20 + 752) - overH - baseT)) * 16 + (x - 16)] != 0) tilePixels[y * 32 + x] = qBase[(y - ((20 + 752) - overH - baseT)) * 16 + (x - 16)]; }
                    }
                }
                if (solidBottomQuadrant)              // draw bottom quadbase
                {
                    for (int y = (24 + 752) - overH - baseT; y < (32 + 752) - overH - baseT; y++)
                    {
                        for (int x = 8; x < 24; x++)
                        { if (qBase[(y - ((24 + 752) - overH - baseT)) * 16 + (x - 8)] != 0) tilePixels[y * 32 + x] = qBase[(y - ((24 + 752) - overH - baseT)) * 16 + (x - 8)]; }
                    }
                }
            }
            /******DRAW OVERHEAD TILES THAT HAVE A HEIGHT > 0******/
            else if (overheadTileHeight != 0)
            {
                qBlock = ColorQuad(false, false, 1, qBlockOrig); hqBlock = ColorQuad(false, false, 2, hqBlockOrig);
                int b = 0;
                if (solidTopQuadrant)             // draw top quadblock
                {
                    for (b = 0; b < overheadTileHeight; b++)    // draw a block for each unit (ie. a height of 6 would draw 6 blocks on top each other)
                    {
                        hChange = (b * 32) - (b * 16);
                        for (int y = (0 + 752) - hChange - overH - baseT; y < (24 + 752) - hChange - overH - baseT; y++) // start 16 pixels above normal base start (ie. 240 - 16)
                        {
                            for (int x = 8; x < 24; x++)
                            { if (qBlock[(y - ((0 + 752) - hChange - overH - baseT)) * 16 + (x - 8)] != 0) tilePixels[y * 32 + x] = qBlock[(y - ((0 + 752) - hChange - overH - baseT)) * 16 + (x - 8)]; }
                        }
                    }
                }
                if (solidLeftQuadrant)              // draw left quadblock
                {
                    for (b = 0; b < overheadTileHeight; b++)    // draw a block for each unit (ie. a height of 6 would draw 6 blocks on top each other)
                    {
                        hChange = (b * 32) - (b * 16);
                        for (int y = (4 + 752) - hChange - overH - baseT; y < (28 + 752) - hChange - overH - baseT; y++)
                        {
                            for (int x = 0; x < 16; x++)
                            { if (qBlock[(y - ((4 + 752) - hChange - overH - baseT)) * 16 + x] != 0) tilePixels[y * 32 + x] = qBlock[(y - ((4 + 752) - hChange - overH - baseT)) * 16 + x]; }
                        }
                    }
                }
                if (solidRightQuadrant)              // draw right quadblock
                {
                    for (b = 0; b < overheadTileHeight; b++)    // draw a block for each unit (ie. a height of 6 would draw 6 blocks on top each other)
                    {
                        hChange = (b * 32) - (b * 16);
                        for (int y = (4 + 752) - hChange - overH - baseT; y < (28 + 752) - hChange - overH - baseT; y++)
                        {
                            for (int x = 16; x < 32; x++)
                            { if (qBlock[(y - ((4 + 752) - hChange - overH - baseT)) * 16 + (x - 16)] != 0) tilePixels[y * 32 + x] = qBlock[(y - ((4 + 752) - hChange - overH - baseT)) * 16 + (x - 16)]; }
                        }
                    }
                }
                if (solidBottomQuadrant)              // draw bottom quadblock
                {
                    for (b = 0; b < overheadTileHeight; b++)    // draw a block for each unit (ie. a height of 6 would draw 6 blocks on top each other)
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
        private int[] ColorQuad(bool isBase, bool isWater, int type, int[] thePixels)
        {
            int[] somePixels = new int[16 * 24];
            int red = 0; int green = 0; int blue = 0;
            int theLighterColor; int theDarkerColor;

            if (!isBase && !isWater) // it is an overhead tile
            {
                if (specialTileFormat == 1) { red = 64; green = 255; blue = 64; }
                else { red = 255; green = 255; blue = 255; }
            }
            else if (isBase && !isWater && overheadTileCoordZ != 0) // it is a base tile and there is something overhead
            {
                if (specialTileFormat == 1) { red = 64; green = 128; blue = 64; }
                else if (specialTileFormat == 2) { red = 64; green = 64; blue = 128; }
                else { red = 128; green = 128; blue = 128; }
            }
            else if (!isBase && isWater) // it is an overhead water tile
            {
                red = 64; green = 64; blue = 255;
            }
            else if (isBase && isWater && (overheadTileCoordZ != 0 || waterTileCoordZ != 0)) // it is a base water tile and there is something overhead
            {
                red = 64; green = 64; blue = 128;
            }
            else if (isBase && isWater) // it is a base water tile and there is nothing overhead
            {
                red = 64; green = 64; blue = 192;
            }
            else // it is a base tile and there is nothing overhead
            {
                if (specialTileFormat == 1) { red = 64; green = 192; blue = 64; }
                else if (specialTileFormat == 2) { red = 64; green = 64; blue = 192; }
                else { red = 192; green = 192; blue = 192; }
            }

            if (solidTile && !isBase && overheadTileCoordZ != 0) { red = 255; green = 64; blue = 64; }
            else if (solidTile && isBase && overheadTileCoordZ == 0) { red = 255; green = 64; blue = 64; }

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

                    //if (solidUpperLeftEdge && thePixels[y * 16 + x] == Color.FromArgb(16, 16, 16).ToArgb()) somePixels[y * 16 + x] = Color.FromArgb(255, 0, 0).ToArgb();
                    //if (solidUpperRightEdge && thePixels[y * 16 + x] == Color.FromArgb(32, 32, 32).ToArgb()) somePixels[y * 16 + x] = Color.FromArgb(255, 0, 0).ToArgb();
                    //if (solidLowerLeftEdge && thePixels[y * 16 + x] == Color.FromArgb(48, 48, 48).ToArgb()) somePixels[y * 16 + x] = Color.FromArgb(255, 0, 0).ToArgb();
                    //if (solidLowerRightEdge && thePixels[y * 16 + x] == Color.FromArgb(64, 64, 64).ToArgb()) somePixels[y * 16 + x] = Color.FromArgb(255, 0, 0).ToArgb();
                }
            }

            return somePixels;
        }
    }
}
