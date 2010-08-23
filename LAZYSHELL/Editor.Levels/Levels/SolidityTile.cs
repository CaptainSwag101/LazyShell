using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Runtime.InteropServices;

namespace LAZYSHELL
{
    public class SolidityTile
    {
        // Local Variables
        // All properties of this class should be private
        private byte[] data;

        private int index; public int Index { get { return index; } set { index = value; } }
        //private int[] tilePixels; public int[] PhysicalTilePixels { get { return tilePixels; } }

        //this is only used for overlay tile selection:
        private int totalHeight; public int TotalHeight { get { return totalHeight; } set { totalHeight = value; } }

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

        public SolidityTile(byte[] data, int index)
        {
            this.data = data;
            this.index = index;
            InitializePhysicalTile(data);
        }
        // Dissasembler goes here
        // Initializes all local properties for this class
        private void InitializePhysicalTile(byte[] data)
        {
            byte temp = 0;

            int offset = (index * 6) + 0x3DC000;

            temp = data[offset]; offset++;

            baseTileHeight = (byte)(temp & 0x0F);

            if ((temp & 0x10) == 0x10) conveyorBeltFast = true;
            if ((temp & 0x20) == 0x20) conveyorBeltNormal = true;
            if ((temp & 0x40) == 0x40) baseTileHeightPlusHalf = true;
            if ((temp & 0x80) == 0x80) solidTile = true;

            temp = data[offset]; offset++;

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

            temp = data[offset]; offset++;

            overheadTileHeight = (byte)(temp & 0x0F);

            switch (temp & 0xF0)
            {
                case 0x00: stairsDirection = 0; break;
                case 0x90: stairsDirection = 1; break;
                case 0xB0: stairsDirection = 2; break;
                default: stairsDirection = 0; break;
            }

            temp = data[offset]; offset++;

            if ((temp & 0x01) == 0x01) solidTopQuadrant = true;
            if ((temp & 0x02) == 0x02) solidLeftQuadrant = true;
            if ((temp & 0x04) == 0x04) solidRightQuadrant = true;
            if ((temp & 0x08) == 0x08) solidBottomQuadrant = true;
            if ((temp & 0x10) == 0x10) objectOnEdgePriority3 = true;
            if ((temp & 0x20) == 0x20) objectAboveEdgePriority3 = true;
            if ((temp & 0x40) == 0x40) objectOnTilePriority3 = true;
            if ((temp & 0x80) == 0x80) solidQuadrantFlag = true;

            temp = data[offset]; offset++;

            waterTileCoordZ = (byte)(temp & 0x0F);

            if ((temp & 0xF0) == 0x10) specialTileFormat = 1;
            else if ((temp & 0xF0) == 0x80) specialTileFormat = 2;
            else specialTileFormat = 0;

            totalHeight = (baseTileHeight + overheadTileCoordZ + overheadTileHeight + waterTileCoordZ) * 16;
            if (baseTileHeightPlusHalf) totalHeight += 8;
            if (stairsDirection > 0) totalHeight += 32;

            door = (byte)((data[offset] & 0xE0) >> 5);
            byte5b0 = (data[offset] & 0x01) == 0x01;
            byte5b1 = (data[offset] & 0x02) == 0x02;
            byte5b2 = (data[offset] & 0x04) == 0x04;
            byte5b3 = (data[offset] & 0x08) == 0x08;
            byte5b4 = (data[offset] & 0x10) == 0x10;
        }
    }
}
