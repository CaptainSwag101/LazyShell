using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace LazyShell.Areas
{
    [Serializable()]
    public class Layering
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

        #region Properties

        // Area properties
        public byte Map { get; set; }
        public byte Banner { get; set; }
        public byte PrioritySet { get; set; }
        // Mask
        public byte MaskLowX { get; set; }
        public byte MaskLowY { get; set; }
        public byte MaskHighX { get; set; }
        public byte MaskHighY { get; set; }
        public bool MaskLock { get; set; }
        // Layer shifting
        public byte XNegL2 { get; set; }
        public byte YNegL2 { get; set; }
        public byte XNegL3 { get; set; }
        public byte YNegL3 { get; set; }
        // Layer scrolling
        public bool InfiniteScrolling { get; set; }
        public bool ScrollWrapL1_HZ { get; set; }
        public bool ScrollWrapL1_VT { get; set; }
        public bool ScrollWrapL2_HZ { get; set; }
        public bool ScrollWrapL2_VT { get; set; }
        public bool ScrollWrapL3_HZ { get; set; }
        public bool ScrollWrapL3_VT { get; set; }
        public byte ScrollDirectionL2 { get; set; }
        public byte ScrollDirectionL3 { get; set; }
        public byte ScrollSpeedL2 { get; set; }
        public byte ScrollSpeedL3 { get; set; }
        public bool ScrollL2Bit7 { get; set; }
        public bool ScrollL3Bit7 { get; set; }
        // Culex
        public bool CulexA { get; set; }
        public bool CulexB { get; set; }
        // Layer synchronization
        public byte SyncL2_VT { get; set; }
        public byte SyncL2_HZ { get; set; }
        public byte SyncL3_VT { get; set; }
        public byte SyncL3_HZ { get; set; }
        // Animation effects
        public bool RipplingWater { get; set; }
        public byte EffectsL3 { get; set; }
        public byte EffectsNPC { get; set; }

        #endregion

        #endregion

        // Constructor
        public Layering(int index)
        {
            this.Index = index;
            ReadFromROM();
        }

        #region Methods

        // Read/write ROM
        private void ReadFromROM()
        {
            int offset = (Index * 18) + 0x1D0040; offset++;
            byte temp = rom[offset++];
            Banner = temp != 0xFE ? (byte)((temp >> 1) + 1) : (byte)0;
            //
            temp = rom[offset++];
            MaskLock = (temp & 0x80) == 0x80;
            MaskLowX = (byte)(temp & 0x3F);
            MaskLowY = (byte)(rom[offset++] & 0x3F);
            MaskHighX = (byte)(rom[offset++] & 0x3F);
            MaskHighY = (byte)(rom[offset++] & 0x3F);
            //
            XNegL2 = rom[offset++];
            YNegL2 = rom[offset++];
            XNegL3 = rom[offset++];
            //
            temp = rom[offset++];
            InfiniteScrolling = (temp & 0x80) == 0x80;
            YNegL3 = (byte)(temp & 0x7F);
            //
            temp = rom[offset++];
            ScrollWrapL1_HZ = (temp & 0x01) == 0x01;
            ScrollWrapL1_VT = (temp & 0x02) == 0x02;
            CulexA = (temp & 0x04) == 0x04;
            ScrollWrapL2_HZ = (temp & 0x08) == 0x08;
            ScrollWrapL2_VT = (temp & 0x10) == 0x10;
            CulexB = (temp & 0x20) == 0x20;
            ScrollWrapL3_HZ = (temp & 0x40) == 0x40;
            ScrollWrapL3_VT = (temp & 0x80) == 0x80;
            //
            temp = rom[offset++];
            if ((temp & 0x03) == 0x00) SyncL2_HZ = 0;
            else if ((temp & 0x03) == 0x01) SyncL2_HZ = 3;
            else if ((temp & 0x03) == 0x02) SyncL2_HZ = 1;
            else if ((temp & 0x03) == 0x03) SyncL2_HZ = 2;
            if ((temp & 0x0C) == 0x00) SyncL2_VT = 0;
            else if ((temp & 0x0C) == 0x04) SyncL2_VT = 3;
            else if ((temp & 0x0C) == 0x08) SyncL2_VT = 1;
            else if ((temp & 0x0C) == 0x0C) SyncL2_VT = 2;
            if ((temp & 0x30) == 0x00) SyncL3_HZ = 0;
            else if ((temp & 0x30) == 0x10) SyncL3_HZ = 3;
            else if ((temp & 0x30) == 0x20) SyncL3_HZ = 1;
            else if ((temp & 0x30) == 0x30) SyncL3_HZ = 2;
            if ((temp & 0xC0) == 0x00) SyncL3_VT = 0;
            else if ((temp & 0xC0) == 0x40) SyncL3_VT = 3;
            else if ((temp & 0xC0) == 0x80) SyncL3_VT = 1;
            else if ((temp & 0xC0) == 0xC0) SyncL3_VT = 2;
            //
            temp = rom[offset++];
            switch (temp & 0x38)
            {
                case 0x00: ScrollDirectionL2 = 0; break;
                case 0x08: ScrollDirectionL2 = 1; break;
                case 0x10: ScrollDirectionL2 = 2; break;
                case 0x18: ScrollDirectionL2 = 3; break;
                case 0x20: ScrollDirectionL2 = 4; break;
                case 0x28: ScrollDirectionL2 = 5; break;
                case 0x30: ScrollDirectionL2 = 6; break;
                case 0x38: ScrollDirectionL2 = 7; break;
            }
            switch (temp & 0x07)
            {
                case 0x00: ScrollSpeedL2 = 0; break;
                case 0x01: ScrollSpeedL2 = 4; break;
                case 0x02: ScrollSpeedL2 = 2; break;
                case 0x03: ScrollSpeedL2 = 1; break;
                case 0x04: ScrollSpeedL2 = 3; break;
                case 0x05: ScrollSpeedL2 = 5; break;
                case 0x06: ScrollSpeedL2 = 5; break;
                case 0x07: ScrollSpeedL2 = 6; break;
            }
            ScrollL2Bit7 = (temp & 0x80) == 0x80;
            //
            temp = rom[offset++];
            switch (temp & 0x38)
            {
                case 0x00: ScrollDirectionL3 = 0; break;
                case 0x08: ScrollDirectionL3 = 1; break;
                case 0x10: ScrollDirectionL3 = 2; break;
                case 0x18: ScrollDirectionL3 = 3; break;
                case 0x20: ScrollDirectionL3 = 4; break;
                case 0x28: ScrollDirectionL3 = 5; break;
                case 0x30: ScrollDirectionL3 = 6; break;
                case 0x38: ScrollDirectionL3 = 7; break;
            }
            switch (temp & 0x07)
            {
                case 0x00: ScrollSpeedL3 = 0; break;
                case 0x01: ScrollSpeedL3 = 4; break;
                case 0x02: ScrollSpeedL3 = 2; break;
                case 0x03: ScrollSpeedL3 = 1; break;
                case 0x04: ScrollSpeedL3 = 3; break;
                case 0x05: ScrollSpeedL3 = 5; break;
                case 0x06: ScrollSpeedL3 = 5; break;
                case 0x07: ScrollSpeedL3 = 6; break;
            }
            ScrollL3Bit7 = (temp & 0x80) == 0x80;
            //
            temp = rom[offset++];
            RipplingWater = (temp & 0x10) == 0x10;
            PrioritySet = (byte)(temp & 0x0F);
            //
            temp = rom[offset++];
            switch (temp)
            {
                case 0x00: EffectsL3 = 0; break;
                case 0x01: EffectsL3 = 1; break;
                case 0x02: EffectsL3 = 2; break;
                case 0x03: EffectsL3 = 3; break;
                case 0x05: EffectsL3 = 4; break;
                case 0x06: EffectsL3 = 5; break;
                case 0x07: EffectsL3 = 6; break;
                case 0x08: EffectsL3 = 7; break;
                case 0x09: EffectsL3 = 8; break;
                case 0x0A: EffectsL3 = 9; break;
                case 0x0B: EffectsL3 = 10; break;
                case 0x0C: EffectsL3 = 11; break;
                case 0x0D: EffectsL3 = 12; break;
                case 0x0E: EffectsL3 = 13; break;
                case 0x0F: EffectsL3 = 14; break;
                case 0x10: EffectsL3 = 15; break;
                case 0x11: EffectsL3 = 16; break;
                case 0x12: EffectsL3 = 17; break;
                case 0x14: EffectsL3 = 18; break;
                case 0x15: EffectsL3 = 19; break;
                case 0x16: EffectsL3 = 20; break;
                case 0x17: EffectsL3 = 21; break;
                case 0x18: EffectsL3 = 22; break;
                default: EffectsL3 = 0; break;
            }
            //
            temp = rom[offset++];
            switch (temp)
            {
                case 0x00: EffectsNPC = 0; break;
                case 0x05: EffectsNPC = 1; break;
                case 0x06: EffectsNPC = 2; break;
                case 0x07: EffectsNPC = 3; break;
                case 0x0A: EffectsNPC = 4; break;
                case 0x0B: EffectsNPC = 5; break;
                case 0x0C: EffectsNPC = 6; break;
                case 0x0D: EffectsNPC = 7; break;
                case 0x0F: EffectsNPC = 8; break;
                case 0x10: EffectsNPC = 9; break;
                case 0x12: EffectsNPC = 10; break;
                case 0x13: EffectsNPC = 11; break;
                case 0x15: EffectsNPC = 12; break;
                case 0x16: EffectsNPC = 13; break;
                case 0x17: EffectsNPC = 14; break;
                case 0x18: EffectsNPC = 15; break;
                case 0x19: EffectsNPC = 16; break;
                case 0x1A: EffectsNPC = 17; break;
                case 0x1B: EffectsNPC = 18; break;
                case 0x1D: EffectsNPC = 19; break;
                case 0x1E: EffectsNPC = 20; break;
                case 0x1F: EffectsNPC = 21; break;
                case 0x20: EffectsNPC = 22; break;
                case 0x21: EffectsNPC = 23; break;
                case 0x22: EffectsNPC = 24; break;
                default: EffectsNPC = 0; break;
            }
        }
        public void WriteToROM()
        {
            int offset = 0;
            offset = (Index * 18) + 0x1D0040; offset++;
            rom[offset] = Banner != 0 ? (byte)((Banner - 1) << 1) : (byte)0xFE;
            offset++;
            rom[offset] = MaskLowX;
            Bits.SetBit(rom, offset, 7, MaskLock); offset++;
            rom[offset] = MaskLowY; offset++;
            rom[offset] = MaskHighX; offset++;
            rom[offset] = MaskHighY; offset++;
            rom[offset] = XNegL2; offset++;
            rom[offset] = YNegL2; offset++;
            rom[offset] = XNegL3; offset++;
            rom[offset] = YNegL3;
            Bits.SetBit(rom, offset, 7, InfiniteScrolling); offset++;
            Bits.SetBit(rom, offset, 0, ScrollWrapL1_HZ);
            Bits.SetBit(rom, offset, 1, ScrollWrapL1_VT);
            Bits.SetBit(rom, offset, 2, CulexA);
            Bits.SetBit(rom, offset, 3, ScrollWrapL2_HZ);
            Bits.SetBit(rom, offset, 4, ScrollWrapL2_VT);
            Bits.SetBit(rom, offset, 5, CulexB);
            Bits.SetBit(rom, offset, 6, ScrollWrapL3_HZ);
            Bits.SetBit(rom, offset, 7, ScrollWrapL3_VT);
            offset++;
            rom[offset] = 0;
            switch (SyncL2_HZ)
            {
                case 0: Bits.SetBitsByByte(rom, offset, 0x03, false); break;
                case 1: Bits.SetBitsByByte(rom, offset, 0x02, true); break;
                case 2: Bits.SetBitsByByte(rom, offset, 0x03, true); break;
                case 3: Bits.SetBitsByByte(rom, offset, 0x01, true); break;
            }
            switch (SyncL2_VT)
            {
                case 0: Bits.SetBitsByByte(rom, offset, 0x0C, false); break;
                case 1: Bits.SetBitsByByte(rom, offset, 0x08, true); break;
                case 2: Bits.SetBitsByByte(rom, offset, 0x0C, true); break;
                case 3: Bits.SetBitsByByte(rom, offset, 0x04, true); break;
            }
            switch (SyncL3_HZ)
            {
                case 0: Bits.SetBitsByByte(rom, offset, 0x30, false); break;
                case 1: Bits.SetBitsByByte(rom, offset, 0x20, true); break;
                case 2: Bits.SetBitsByByte(rom, offset, 0x30, true); break;
                case 3: Bits.SetBitsByByte(rom, offset, 0x10, true); break;
            }
            switch (SyncL3_VT)
            {
                case 0: Bits.SetBitsByByte(rom, offset, 0xC0, false); break;
                case 1: Bits.SetBitsByByte(rom, offset, 0x80, true); break;
                case 2: Bits.SetBitsByByte(rom, offset, 0xC0, true); break;
                case 3: Bits.SetBitsByByte(rom, offset, 0x40, true); break;
            }
            offset++;
            switch (ScrollDirectionL2)
            {
                case 0: rom[offset] = 0x00; break;
                case 1: rom[offset] = 0x08; break;
                case 2: rom[offset] = 0x10; break;
                case 3: rom[offset] = 0x18; break;
                case 4: rom[offset] = 0x20; break;
                case 5: rom[offset] = 0x28; break;
                case 6: rom[offset] = 0x30; break;
                case 7: rom[offset] = 0x38; break;
            }
            switch (ScrollSpeedL2)
            {
                case 0: Bits.SetBitsByByte(rom, offset, 0x00, true); break;
                case 4: Bits.SetBitsByByte(rom, offset, 0x01, true); break;
                case 2: Bits.SetBitsByByte(rom, offset, 0x02, true); break;
                case 1: Bits.SetBitsByByte(rom, offset, 0x03, true); break;
                case 3: Bits.SetBitsByByte(rom, offset, 0x04, true); break;
                case 5: Bits.SetBitsByByte(rom, offset, 0x05, true); break;
                case 6: Bits.SetBitsByByte(rom, offset, 0x07, true); break;
            }
            Bits.SetBit(rom, offset, 7, ScrollL2Bit7);
            offset++;
            switch (ScrollDirectionL3)
            {
                case 0: rom[offset] = 0x00; break;
                case 1: rom[offset] = 0x08; break;
                case 2: rom[offset] = 0x10; break;
                case 3: rom[offset] = 0x18; break;
                case 4: rom[offset] = 0x20; break;
                case 5: rom[offset] = 0x28; break;
                case 6: rom[offset] = 0x30; break;
                case 7: rom[offset] = 0x38; break;
            }
            switch (ScrollSpeedL3)
            {
                case 0: Bits.SetBitsByByte(rom, offset, 0x00, true); break;
                case 4: Bits.SetBitsByByte(rom, offset, 0x01, true); break;
                case 2: Bits.SetBitsByByte(rom, offset, 0x02, true); break;
                case 1: Bits.SetBitsByByte(rom, offset, 0x03, true); break;
                case 3: Bits.SetBitsByByte(rom, offset, 0x04, true); break;
                case 5: Bits.SetBitsByByte(rom, offset, 0x05, true); break;
                case 6: Bits.SetBitsByByte(rom, offset, 0x07, true); break;
            }
            Bits.SetBit(rom, offset, 7, ScrollL3Bit7);
            offset++;
            rom[offset] = 0;
            Bits.SetBit(rom, offset, 4, RipplingWater);
            Bits.SetBitsByByte(rom, offset, PrioritySet, true);
            offset++;
            switch (EffectsL3)
            {
                case 0: rom[offset] = 0x00; break;
                case 1: rom[offset] = 0x01; break;
                case 2: rom[offset] = 0x02; break;
                case 3: rom[offset] = 0x03; break;
                case 4: rom[offset] = 0x05; break;
                case 5: rom[offset] = 0x06; break;
                case 6: rom[offset] = 0x07; break;
                case 7: rom[offset] = 0x08; break;
                case 8: rom[offset] = 0x09; break;
                case 9: rom[offset] = 0x0A; break;
                case 10: rom[offset] = 0x0B; break;
                case 11: rom[offset] = 0x0C; break;
                case 12: rom[offset] = 0x0D; break;
                case 13: rom[offset] = 0x0E; break;
                case 14: rom[offset] = 0x0F; break;
                case 15: rom[offset] = 0x10; break;
                case 16: rom[offset] = 0x11; break;
                case 17: rom[offset] = 0x12; break;
                case 18: rom[offset] = 0x14; break;
                case 19: rom[offset] = 0x15; break;
                case 20: rom[offset] = 0x16; break;
                case 21: rom[offset] = 0x17; break;
                case 22: rom[offset] = 0x18; break;
            }
            offset++;
            switch (EffectsNPC)
            {
                case 0: rom[offset] = 0x00; break;
                case 1: rom[offset] = 0x05; break;
                case 2: rom[offset] = 0x06; break;
                case 3: rom[offset] = 0x07; break;
                case 4: rom[offset] = 0x0A; break;
                case 5: rom[offset] = 0x0B; break;
                case 6: rom[offset] = 0x0C; break;
                case 7: rom[offset] = 0x0D; break;
                case 8: rom[offset] = 0x0F; break;
                case 9: rom[offset] = 0x10; break;
                case 10: rom[offset] = 0x12; break;
                case 11: rom[offset] = 0x13; break;
                case 12: rom[offset] = 0x15; break;
                case 13: rom[offset] = 0x16; break;
                case 14: rom[offset] = 0x17; break;
                case 15: rom[offset] = 0x18; break;
                case 16: rom[offset] = 0x19; break;
                case 17: rom[offset] = 0x1A; break;
                case 18: rom[offset] = 0x1B; break;
                case 19: rom[offset] = 0x1D; break;
                case 20: rom[offset] = 0x1E; break;
                case 21: rom[offset] = 0x1F; break;
                case 22: rom[offset] = 0x20; break;
                case 23: rom[offset] = 0x21; break;
                case 24: rom[offset] = 0x22; break;
            }
        }
        // Inherited
        public void Clear()
        {
            int offset = 0;
            offset = (Index * 18) + 0x1D0040; offset++;
            this.Banner = 0;
            this.MaskLock = false;
            this.MaskLowX = 0;
            this.MaskLowY = 0;
            this.MaskHighX = 63;
            this.MaskHighY = 63;
            this.XNegL2 = 0;
            this.YNegL2 = 0;
            this.XNegL3 = 0;
            this.InfiniteScrolling = false;
            this.YNegL3 = 0;
            this.ScrollWrapL1_HZ = false;
            this.ScrollWrapL1_VT = false;
            this.CulexA = false;
            this.CulexB = false;
            this.ScrollWrapL2_HZ = false;
            this.ScrollWrapL2_VT = false;
            this.ScrollWrapL3_HZ = false;
            this.ScrollWrapL3_VT = false;
            this.SyncL2_HZ = 0;
            this.SyncL2_VT = 0;
            this.SyncL3_HZ = 0;
            this.SyncL3_VT = 0;
            this.ScrollDirectionL2 = 0;
            this.ScrollSpeedL2 = 0;
            this.ScrollDirectionL3 = 0;
            this.ScrollSpeedL3 = 0;
            this.RipplingWater = false;
            this.PrioritySet = 0;
            this.EffectsL3 = 0;
            this.EffectsNPC = 0;
        }

        #endregion
    }
}
