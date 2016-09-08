using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Runtime.InteropServices;

namespace LazyShell.Areas
{
    public class CollisionTile
    {
        #region Variables

        // ROM buffer
        private byte[] rom
        {
            get { return Model.ROM; }
            set { Model.ROM = value; }
        }
        // Index
        public int Index { get; set; }
        // Properties - size
        public int TotalHeight { get; set; }
        public byte BaseTileHeight { get; set; }
        public byte OverheadTileHeight { get; set; }
        public byte OverheadTileZ { get; set; }
        public byte WaterTileZ { get; set; }
        public bool BaseTileHeight_Half { get; set; }
        // Properties -solid edges
        public bool SolidEdgeNW { get; set; }
        public bool SolidEdgeNE { get; set; }
        public bool SolidEdgeSW { get; set; }
        public bool SolidEdgeSE { get; set; }
        // Properties - solid quadrants
        public bool SolidTile { get; set; }
        public bool SolidQuadW { get; set; }
        public bool SolidQuadE { get; set; }
        public bool SolidQuadN { get; set; }
        public bool SolidQuadS { get; set; }
        public bool SolidQuadrantFlag { get; set; }
        // Properties - priority 3
        public bool P3ObjectOnEdge { get; set; }
        public bool P3ObjectAboveEdge { get; set; }
        public bool P3ObjectOnTile { get; set; }
        // Properties - special
        public bool ConveyorBeltFast { get; set; }
        public bool ConveyorBeltNormal { get; set; }
        public byte ConveyorBeltDirection { get; set; }
        public byte StairsDirection { get; set; }
        public byte SpecialTileFormat { get; set; }
        public byte Door { get; set; }
        // Properties - unknown bits
        public bool B5b0 { get; set; }
        public bool B5b1 { get; set; }
        public bool B5b2 { get; set; }
        public bool B5b3 { get; set; }
        public bool B5b4 { get; set; }

        #endregion

        // Constructor
        public CollisionTile(int index)
        {
            this.Index = index;
            ReadFromROM();
        }

        #region Methods

        // Read/write ROM
        private void ReadFromROM()
        {
            int offset = (Index * 6) + 0x3DC000;
            //
            byte temp = rom[offset++];
            BaseTileHeight = (byte)(temp & 0x0F);
            ConveyorBeltFast = (temp & 0x10) == 0x10;
            ConveyorBeltNormal = (temp & 0x20) == 0x20;
            BaseTileHeight_Half = (temp & 0x40) == 0x40;
            SolidTile = (temp & 0x80) == 0x80;
            //
            temp = rom[offset++];
            OverheadTileZ = (byte)(temp & 0x0F);
            SolidEdgeNW = (temp & 0x10) == 0x10;
            SolidEdgeNE = (temp & 0x20) == 0x20;
            SolidEdgeSW = (temp & 0x40) == 0x40;
            SolidEdgeSE = (temp & 0x80) == 0x80;
            ConveyorBeltDirection = (byte)((temp >> 4) & 7);
            //
            temp = rom[offset++];
            OverheadTileHeight = (byte)(temp & 0x0F);
            switch (temp & 0xF0)
            {
                case 0x00: StairsDirection = 0; break;
                case 0x90: StairsDirection = 1; break;
                case 0xB0: StairsDirection = 2; break;
                default: StairsDirection = 0; break;
            }
            //
            temp = rom[offset++];
            SolidQuadN = (temp & 0x01) == 0x01;
            SolidQuadW = (temp & 0x02) == 0x02;
            SolidQuadE = (temp & 0x04) == 0x04;
            SolidQuadS = (temp & 0x08) == 0x08;
            P3ObjectOnEdge = (temp & 0x10) == 0x10;
            P3ObjectAboveEdge = (temp & 0x20) == 0x20;
            P3ObjectOnTile = (temp & 0x40) == 0x40;
            SolidQuadrantFlag = (temp & 0x80) == 0x80;
            //
            temp = rom[offset++];
            WaterTileZ = (byte)(temp & 0x0F);
            if ((temp & 0xF0) == 0x10)
                SpecialTileFormat = 1;
            else if ((temp & 0xF0) == 0x80)
                SpecialTileFormat = 2;
            else
                SpecialTileFormat = 0;
            //
            TotalHeight = (BaseTileHeight + OverheadTileZ + OverheadTileHeight + WaterTileZ) * 16;
            if (BaseTileHeight_Half)
                TotalHeight += 8;
            if (StairsDirection > 0)
                TotalHeight += 32;
            //
            Door = (byte)((rom[offset] & 0xE0) >> 5);
            B5b0 = (rom[offset] & 0x01) == 0x01;
            B5b1 = (rom[offset] & 0x02) == 0x02;
            B5b2 = (rom[offset] & 0x04) == 0x04;
            B5b3 = (rom[offset] & 0x08) == 0x08;
            B5b4 = (rom[offset] & 0x10) == 0x10;
        }
        public void WriteToROM()
        {
            int offset = (Index * 6) + 0x3DC000;
            //
            rom[offset] = BaseTileHeight;
            Bits.SetBit(rom, offset, 4, ConveyorBeltFast);
            Bits.SetBit(rom, offset, 5, ConveyorBeltNormal);
            Bits.SetBit(rom, offset, 6, BaseTileHeight_Half);
            Bits.SetBit(rom, offset++, 7, SolidTile);
            //
            rom[offset] = OverheadTileZ;
            Bits.SetBit(rom, offset, 4, SolidEdgeNW);
            Bits.SetBit(rom, offset, 5, SolidEdgeNE);
            Bits.SetBit(rom, offset, 6, SolidEdgeSW);
            Bits.SetBit(rom, offset, 7, SolidEdgeSE);
            if (ConveyorBeltFast || ConveyorBeltNormal)
                rom[offset] = (byte)(ConveyorBeltDirection << 4);
            offset++;
            rom[offset] = OverheadTileHeight;
            switch (StairsDirection)
            {
                case 1: rom[offset] |= 0x90; break;
                case 2: rom[offset] |= 0xB0; break;
            }
            offset++;
            Bits.SetBit(rom, offset, 0, SolidQuadN);
            Bits.SetBit(rom, offset, 1, SolidQuadW);
            Bits.SetBit(rom, offset, 2, SolidQuadE);
            Bits.SetBit(rom, offset, 3, SolidQuadS);
            Bits.SetBit(rom, offset, 4, P3ObjectOnEdge);
            Bits.SetBit(rom, offset, 5, P3ObjectAboveEdge);
            Bits.SetBit(rom, offset, 6, P3ObjectOnTile);
            Bits.SetBit(rom, offset++, 7, SolidQuadrantFlag);
            //
            rom[offset] = WaterTileZ;
            if (SpecialTileFormat == 1)
                rom[offset] |= 0x10;
            else if (SpecialTileFormat == 2)
                rom[offset] |= 0x80;
            offset++;
            rom[offset] = (byte)(Door << 5);
            Bits.SetBit(rom, offset, 0, B5b0);
            Bits.SetBit(rom, offset, 1, B5b1);
            Bits.SetBit(rom, offset, 2, B5b2);
            Bits.SetBit(rom, offset, 3, B5b3);
            Bits.SetBit(rom, offset, 4, B5b4);
        }
        //
        public Bitmap GetHighlightedImage()
        {
            int[] pixels = Collision.Instance.GetTilePixels(this);
            for (int y = 768 - TotalHeight; y < 784; y++)
            {
                for (int x = 0; x < 32; x++)
                {
                    if (pixels[y * 32 + x] == 0) continue;
                    Color color = Color.FromArgb(pixels[y * 32 + x]);
                    int r = color.R;
                    int n = 255;
                    int b = 192;
                    if (Index == 0)
                        pixels[y * 32 + x] = Color.FromArgb(96, 0, 0, 0).ToArgb();
                    else
                        pixels[y * 32 + x] = Color.FromArgb(255, r, n, b).ToArgb();
                }
            }
            return Do.PixelsToImage(pixels, 32, 784);
        }
        // Override
        public override string ToString()
        {
            return "Collision Tile #" + Index;
        }

        #endregion
    }
}
