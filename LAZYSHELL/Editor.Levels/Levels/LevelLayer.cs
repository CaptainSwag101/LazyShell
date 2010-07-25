using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace LAZYSHELL
{
    [Serializable()]
    public class LevelLayer
    {
        // Local Variables
        // All properties of this class should be private
        [NonSerialized()]
        private byte[] data; public byte[] Data { get { return this.data; } set { this.data = value; } }

        private int index; public int Index { get { return index; } set { index = value; } }

        private byte messageBox; public byte MessageBox { get { return messageBox; } set { messageBox = value; } }

        private byte maskLowX; public byte MaskLowX { get { return maskLowX; } set { maskLowX = value; } }
        private byte maskLowY; public byte MaskLowY { get { return maskLowY; } set { maskLowY = value; } }
        private byte maskHighX; public byte MaskHighX { get { return maskHighX; } set { maskHighX = value; } }
        private byte maskHighY; public byte MaskHighY { get { return maskHighY; } set { maskHighY = value; } }
        private bool maskLock; public bool MaskLock { get { return maskLock; } set { maskLock = value; } }

        private byte leftShiftL2; public byte LeftShiftL2 { get { return leftShiftL2; } set { leftShiftL2 = value; } }
        private byte upShiftL2; public byte UpShiftL2 { get { return upShiftL2; } set { upShiftL2 = value; } }
        private byte leftShiftL3; public byte LeftShiftL3 { get { return leftShiftL3; } set { leftShiftL3 = value; } }
        private byte upShiftL3; public byte UpShiftL3 { get { return upShiftL3; } set { upShiftL3 = value; } }
        private bool infiniteAutoscroll; public bool InfiniteAutoscroll { get { return infiniteAutoscroll; } set { infiniteAutoscroll = value; } }

        private bool horizontalScrollWrapL1; public bool HorizontalScrollWrapL1 { get { return horizontalScrollWrapL1; } set { horizontalScrollWrapL1 = value; } }
        private bool verticalScrollWrapL1; public bool VerticalScrollWrapL1 { get { return verticalScrollWrapL1; } set { verticalScrollWrapL1 = value; } }
        private bool culexA; public bool CulexA { get { return culexA; } set { culexA = value; } }
        private bool horizontalScrollWrapL2; public bool HorizontalScrollWrapL2 { get { return horizontalScrollWrapL2; } set { horizontalScrollWrapL2 = value; } }
        private bool verticalScrollWrapL2; public bool VerticalScrollWrapL2 { get { return verticalScrollWrapL2; } set { verticalScrollWrapL2 = value; } }
        private bool culexB; public bool CulexB { get { return culexB; } set { culexB = value; } }
        private bool horizontalScrollWrapL3; public bool HorizontalScrollWrapL3 { get { return horizontalScrollWrapL3; } set { horizontalScrollWrapL3 = value; } }
        private bool verticalScrollWrapL3; public bool VerticalScrollWrapL3 { get { return verticalScrollWrapL3; } set { verticalScrollWrapL3 = value; } }

        private byte verticalSyncL2; public byte VerticalSyncL2 { get { return verticalSyncL2; } set { verticalSyncL2 = value; } }
        private byte horizontalSyncL2; public byte HorizontalSyncL2 { get { return horizontalSyncL2; } set { horizontalSyncL2 = value; } }
        private byte verticalSyncL3; public byte VerticalSyncL3 { get { return verticalSyncL3; } set { verticalSyncL3 = value; } }
        private byte horizontalSyncL3; public byte HorizontalSyncL3 { get { return horizontalSyncL3; } set { horizontalSyncL3 = value; } }

        private byte scrollDirectionL2; public byte ScrollDirectionL2 { get { return scrollDirectionL2; } set { scrollDirectionL2 = value; } }
        private byte scrollDirectionL3; public byte ScrollDirectionL3 { get { return scrollDirectionL3; } set { scrollDirectionL3 = value; } }
        private byte scrollSpeedL2; public byte ScrollSpeedL2 { get { return scrollSpeedL2; } set { scrollSpeedL2 = value; } }
        private byte scrollSpeedL3; public byte ScrollSpeedL3 { get { return scrollSpeedL3; } set { scrollSpeedL3 = value; } }
        private bool scrollL2Bit7; public bool ScrollL2Bit7 { get { return scrollL2Bit7; } set { scrollL2Bit7 = value; } }
        private bool scrollL3Bit7; public bool ScrollL3Bit7 { get { return scrollL3Bit7; } set { scrollL3Bit7 = value; } }

        private byte layerPrioritySet; public byte LayerPrioritySet { get { return layerPrioritySet; } set { layerPrioritySet = value; } }

        private bool waveEffectL3; public bool WaveEffectL3 { get { return waveEffectL3; } set { waveEffectL3 = value; } }

        private byte animationEffectL3; public byte AnimationEffectL3 { get { return animationEffectL3; } set { animationEffectL3 = value; } }
        private byte extraEffects; public byte ExtraEffects { get { return extraEffects; } set { extraEffects = value; } }

        private byte levelMap; public byte LevelMap { get { return levelMap; } set { levelMap = value; } }

        public LevelLayer(byte[] data, int index)
        {
            this.data = data;
            this.index = index;
            InitializeLevel(data);
        }

        // Dissasembler goes here
        // Initializes all local properties for this class
        private void InitializeLevel(byte[] data)
        {
            byte temp = 0;

            int offset = (index * 18) + 0x1D0040; offset++;

            temp = data[offset]; offset++;

            messageBox = temp != 0xFE ? (byte)((temp >> 1) + 1) : (byte)0;

            temp = data[offset];

            if ((temp & 0x80) == 0x80) maskLock = true;

            maskLowX = (byte)(temp & 0x3F); offset++;
            maskLowY = (byte)(data[offset] & 0x3F); offset++;
            maskHighX = (byte)(data[offset] & 0x3F); offset++;
            maskHighY = (byte)(data[offset] & 0x3F); offset++;

            leftShiftL2 = data[offset]; offset++;
            upShiftL2 = data[offset]; offset++;
            leftShiftL3 = data[offset]; offset++;

            temp = data[offset];

            if ((temp & 0x80) == 0x80) infiniteAutoscroll = true;

            upShiftL3 = (byte)(temp & 0x7F); offset++;

            temp = data[offset]; offset++;

            if ((temp & 0x01) == 0x01) horizontalScrollWrapL1 = true;
            if ((temp & 0x02) == 0x02) verticalScrollWrapL1 = true;
            if ((temp & 0x04) == 0x04) culexA = true;
            if ((temp & 0x08) == 0x08) horizontalScrollWrapL2 = true;
            if ((temp & 0x10) == 0x10) verticalScrollWrapL2 = true;
            if ((temp & 0x20) == 0x20) culexB = true;
            if ((temp & 0x40) == 0x40) horizontalScrollWrapL3 = true;
            if ((temp & 0x80) == 0x80) verticalScrollWrapL3 = true;

            temp = data[offset]; offset++;

            if ((temp & 0x03) == 0x00) horizontalSyncL2 = 0;
            else if ((temp & 0x03) == 0x01) horizontalSyncL2 = 3;
            else if ((temp & 0x03) == 0x02) horizontalSyncL2 = 1;
            else if ((temp & 0x03) == 0x03) horizontalSyncL2 = 2;

            if ((temp & 0x0C) == 0x00) verticalSyncL2 = 0;
            else if ((temp & 0x0C) == 0x04) verticalSyncL2 = 3;
            else if ((temp & 0x0C) == 0x08) verticalSyncL2 = 1;
            else if ((temp & 0x0C) == 0x0C) verticalSyncL2 = 2;

            if ((temp & 0x30) == 0x00) horizontalSyncL3 = 0;
            else if ((temp & 0x30) == 0x10) horizontalSyncL3 = 3;
            else if ((temp & 0x30) == 0x20) horizontalSyncL3 = 1;
            else if ((temp & 0x30) == 0x30) horizontalSyncL3 = 2;

            if ((temp & 0xC0) == 0x00) verticalSyncL3 = 0;
            else if ((temp & 0xC0) == 0x40) verticalSyncL3 = 3;
            else if ((temp & 0xC0) == 0x80) verticalSyncL3 = 1;
            else if ((temp & 0xC0) == 0xC0) verticalSyncL3 = 2;

            temp = data[offset]; offset++;

            switch (temp & 0x38)
            {
                case 0x00: scrollDirectionL2 = 0; break;
                case 0x08: scrollDirectionL2 = 1; break;
                case 0x10: scrollDirectionL2 = 2; break;
                case 0x18: scrollDirectionL2 = 3; break;
                case 0x20: scrollDirectionL2 = 4; break;
                case 0x28: scrollDirectionL2 = 5; break;
                case 0x30: scrollDirectionL2 = 6; break;
                case 0x38: scrollDirectionL2 = 7; break;
            }

            switch (temp & 0x07)
            {
                case 0x00: scrollSpeedL2 = 0; break;
                case 0x01: scrollSpeedL2 = 4; break;
                case 0x02: scrollSpeedL2 = 2; break;
                case 0x03: scrollSpeedL2 = 1; break;
                case 0x04: scrollSpeedL2 = 3; break;
                case 0x05: scrollSpeedL2 = 5; break;
                case 0x06: scrollSpeedL2 = 5; break;
                case 0x07: scrollSpeedL2 = 6; break;
            }

            if ((temp & 0x80) == 0x80) scrollL2Bit7 = true;

            temp = data[offset]; offset++;

            switch (temp & 0x38)
            {
                case 0x00: scrollDirectionL3 = 0; break;
                case 0x08: scrollDirectionL3 = 1; break;
                case 0x10: scrollDirectionL3 = 2; break;
                case 0x18: scrollDirectionL3 = 3; break;
                case 0x20: scrollDirectionL3 = 4; break;
                case 0x28: scrollDirectionL3 = 5; break;
                case 0x30: scrollDirectionL3 = 6; break;
                case 0x38: scrollDirectionL3 = 7; break;
            }

            switch (temp & 0x07)
            {
                case 0x00: scrollSpeedL3 = 0; break;
                case 0x01: scrollSpeedL3 = 4; break;
                case 0x02: scrollSpeedL3 = 2; break;
                case 0x03: scrollSpeedL3 = 1; break;
                case 0x04: scrollSpeedL3 = 3; break;
                case 0x05: scrollSpeedL3 = 5; break;
                case 0x06: scrollSpeedL3 = 5; break;
                case 0x07: scrollSpeedL3 = 6; break;
            }

            if ((temp & 0x80) == 0x80) scrollL3Bit7 = true;

            temp = data[offset]; offset++;
            if ((temp & 0x10) == 0x10) waveEffectL3 = true;

            layerPrioritySet = (byte)(temp & 0x0F);

            temp = data[offset]; offset++;

            switch (temp)
            {
                case 0x00: animationEffectL3 = 0; break;
                case 0x01: animationEffectL3 = 1; break;
                case 0x02: animationEffectL3 = 2; break;
                case 0x03: animationEffectL3 = 3; break;
                case 0x05: animationEffectL3 = 4; break;
                case 0x06: animationEffectL3 = 5; break;
                case 0x07: animationEffectL3 = 6; break;
                case 0x08: animationEffectL3 = 7; break;
                case 0x09: animationEffectL3 = 8; break;
                case 0x0A: animationEffectL3 = 9; break;
                case 0x0B: animationEffectL3 = 10; break;
                case 0x0C: animationEffectL3 = 11; break;
                case 0x0D: animationEffectL3 = 12; break;
                case 0x0E: animationEffectL3 = 13; break;
                case 0x0F: animationEffectL3 = 14; break;
                case 0x10: animationEffectL3 = 15; break;
                case 0x11: animationEffectL3 = 16; break;
                case 0x12: animationEffectL3 = 17; break;
                case 0x14: animationEffectL3 = 18; break;
                case 0x15: animationEffectL3 = 19; break;
                case 0x16: animationEffectL3 = 20; break;
                case 0x17: animationEffectL3 = 21; break;
                case 0x18: animationEffectL3 = 22; break;
                default: animationEffectL3 = 0; break;
            }

            temp = data[offset]; offset++;

            switch (temp)
            {
                case 0x00: extraEffects = 0; break;
                case 0x05: extraEffects = 1; break;
                case 0x06: extraEffects = 2; break;
                case 0x07: extraEffects = 3; break;
                case 0x0A: extraEffects = 4; break;
                case 0x0B: extraEffects = 5; break;
                case 0x0C: extraEffects = 6; break;
                case 0x0D: extraEffects = 7; break;
                case 0x0F: extraEffects = 8; break;
                case 0x10: extraEffects = 9; break;
                case 0x12: extraEffects = 10; break;
                case 0x13: extraEffects = 11; break;
                case 0x15: extraEffects = 12; break;
                case 0x16: extraEffects = 13; break;
                case 0x17: extraEffects = 14; break;
                case 0x18: extraEffects = 15; break;
                case 0x19: extraEffects = 16; break;
                case 0x1A: extraEffects = 17; break;
                case 0x1B: extraEffects = 18; break;
                case 0x1D: extraEffects = 19; break;
                case 0x1E: extraEffects = 20; break;
                case 0x1F: extraEffects = 21; break;
                case 0x20: extraEffects = 22; break;
                case 0x21: extraEffects = 23; break;
                case 0x22: extraEffects = 24; break;
                default: extraEffects = 0; break;
            }

        }
        public void Assemble()
        {
            int offset = 0;

            offset = (index * 18) + 0x1D0040; offset++;

            data[offset] = messageBox != 0 ? (byte)((messageBox - 1) << 1) : (byte)0xFE;

            offset++;

            Bits.SetByte(data, offset, maskLowX);
            Bits.SetBit(data, offset, 7, maskLock); offset++;
            Bits.SetByte(data, offset, maskLowY); offset++;
            Bits.SetByte(data, offset, maskHighX); offset++;
            Bits.SetByte(data, offset, maskHighY); offset++;

            Bits.SetByte(data, offset, leftShiftL2); offset++;
            Bits.SetByte(data, offset, upShiftL2); offset++;
            Bits.SetByte(data, offset, leftShiftL3); offset++;
            Bits.SetByte(data, offset, upShiftL3);
            Bits.SetBit(data, offset, 7, infiniteAutoscroll); offset++;

            Bits.SetBit(data, offset, 0, horizontalScrollWrapL1);
            Bits.SetBit(data, offset, 1, verticalScrollWrapL1);
            Bits.SetBit(data, offset, 2, culexA);
            Bits.SetBit(data, offset, 3, horizontalScrollWrapL2);
            Bits.SetBit(data, offset, 4, verticalScrollWrapL2);
            Bits.SetBit(data, offset, 5, culexB);
            Bits.SetBit(data, offset, 6, horizontalScrollWrapL3);
            Bits.SetBit(data, offset, 7, verticalScrollWrapL3);

            offset++;

            Bits.SetByte(data, offset, 0);
            switch (horizontalSyncL2)
            {
                case 0: Bits.SetBitsByByte(data, offset, 0x03, false); break;
                case 1: Bits.SetBitsByByte(data, offset, 0x02, true); break;
                case 2: Bits.SetBitsByByte(data, offset, 0x03, true); break;
                case 3: Bits.SetBitsByByte(data, offset, 0x01, true); break;
            }
            switch (verticalSyncL2)
            {
                case 0: Bits.SetBitsByByte(data, offset, 0x0C, false); break;
                case 1: Bits.SetBitsByByte(data, offset, 0x08, true); break;
                case 2: Bits.SetBitsByByte(data, offset, 0x0C, true); break;
                case 3: Bits.SetBitsByByte(data, offset, 0x04, true); break;
            }
            switch (horizontalSyncL3)
            {
                case 0: Bits.SetBitsByByte(data, offset, 0x30, false); break;
                case 1: Bits.SetBitsByByte(data, offset, 0x20, true); break;
                case 2: Bits.SetBitsByByte(data, offset, 0x30, true); break;
                case 3: Bits.SetBitsByByte(data, offset, 0x10, true); break;
            }
            switch (verticalSyncL3)
            {
                case 0: Bits.SetBitsByByte(data, offset, 0xC0, false); break;
                case 1: Bits.SetBitsByByte(data, offset, 0x80, true); break;
                case 2: Bits.SetBitsByByte(data, offset, 0xC0, true); break;
                case 3: Bits.SetBitsByByte(data, offset, 0x40, true); break;
            }

            offset++;

            switch (scrollDirectionL2)
            {
                case 0: Bits.SetByte(data, offset, 0x00); break;
                case 1: Bits.SetByte(data, offset, 0x08); break;
                case 2: Bits.SetByte(data, offset, 0x10); break;
                case 3: Bits.SetByte(data, offset, 0x18); break;
                case 4: Bits.SetByte(data, offset, 0x20); break;
                case 5: Bits.SetByte(data, offset, 0x28); break;
                case 6: Bits.SetByte(data, offset, 0x30); break;
                case 7: Bits.SetByte(data, offset, 0x38); break;
            }

            switch (scrollSpeedL2)
            {
                case 0: Bits.SetBitsByByte(data, offset, 0x00, true); break;
                case 4: Bits.SetBitsByByte(data, offset, 0x01, true); break;
                case 2: Bits.SetBitsByByte(data, offset, 0x02, true); break;
                case 1: Bits.SetBitsByByte(data, offset, 0x03, true); break;
                case 3: Bits.SetBitsByByte(data, offset, 0x04, true); break;
                case 5: Bits.SetBitsByByte(data, offset, 0x05, true); break;
                case 6: Bits.SetBitsByByte(data, offset, 0x07, true); break;
            }

            Bits.SetBit(data, offset, 7, scrollL2Bit7);
            offset++;

            switch (scrollDirectionL3)
            {
                case 0: Bits.SetByte(data, offset, 0x00); break;
                case 1: Bits.SetByte(data, offset, 0x08); break;
                case 2: Bits.SetByte(data, offset, 0x10); break;
                case 3: Bits.SetByte(data, offset, 0x18); break;
                case 4: Bits.SetByte(data, offset, 0x20); break;
                case 5: Bits.SetByte(data, offset, 0x28); break;
                case 6: Bits.SetByte(data, offset, 0x30); break;
                case 7: Bits.SetByte(data, offset, 0x38); break;
            }

            switch (scrollSpeedL3)
            {
                case 0: Bits.SetBitsByByte(data, offset, 0x00, true); break;
                case 4: Bits.SetBitsByByte(data, offset, 0x01, true); break;
                case 2: Bits.SetBitsByByte(data, offset, 0x02, true); break;
                case 1: Bits.SetBitsByByte(data, offset, 0x03, true); break;
                case 3: Bits.SetBitsByByte(data, offset, 0x04, true); break;
                case 5: Bits.SetBitsByByte(data, offset, 0x05, true); break;
                case 6: Bits.SetBitsByByte(data, offset, 0x07, true); break;
            }

            Bits.SetBit(data, offset, 7, scrollL3Bit7);
            offset++;

            Bits.SetByte(data, offset, 0);
            Bits.SetBit(data, offset, 4, waveEffectL3);
            Bits.SetBitsByByte(data, offset, layerPrioritySet, true);

            offset++;

            switch (animationEffectL3)
            {
                case 0: Bits.SetByte(data, offset, 0x00); break;
                case 1: Bits.SetByte(data, offset, 0x01); break;
                case 2: Bits.SetByte(data, offset, 0x02); break;
                case 3: Bits.SetByte(data, offset, 0x03); break;
                case 4: Bits.SetByte(data, offset, 0x05); break;
                case 5: Bits.SetByte(data, offset, 0x06); break;
                case 6: Bits.SetByte(data, offset, 0x07); break;
                case 7: Bits.SetByte(data, offset, 0x08); break;
                case 8: Bits.SetByte(data, offset, 0x09); break;
                case 9: Bits.SetByte(data, offset, 0x0A); break;
                case 10: Bits.SetByte(data, offset, 0x0B); break;
                case 11: Bits.SetByte(data, offset, 0x0C); break;
                case 12: Bits.SetByte(data, offset, 0x0D); break;
                case 13: Bits.SetByte(data, offset, 0x0E); break;
                case 14: Bits.SetByte(data, offset, 0x0F); break;
                case 15: Bits.SetByte(data, offset, 0x10); break;
                case 16: Bits.SetByte(data, offset, 0x11); break;
                case 17: Bits.SetByte(data, offset, 0x12); break;
                case 18: Bits.SetByte(data, offset, 0x14); break;
                case 19: Bits.SetByte(data, offset, 0x15); break;
                case 20: Bits.SetByte(data, offset, 0x16); break;
                case 21: Bits.SetByte(data, offset, 0x17); break;
                case 22: Bits.SetByte(data, offset, 0x18); break;
            }

            offset++;

            switch (extraEffects)
            {
                case 0: Bits.SetByte(data, offset, 0x00); break;
                case 1: Bits.SetByte(data, offset, 0x05); break;
                case 2: Bits.SetByte(data, offset, 0x06); break;
                case 3: Bits.SetByte(data, offset, 0x07); break;
                case 4: Bits.SetByte(data, offset, 0x0A); break;
                case 5: Bits.SetByte(data, offset, 0x0B); break;
                case 6: Bits.SetByte(data, offset, 0x0C); break;
                case 7: Bits.SetByte(data, offset, 0x0D); break;
                case 8: Bits.SetByte(data, offset, 0x0F); break;
                case 9: Bits.SetByte(data, offset, 0x10); break;
                case 10: Bits.SetByte(data, offset, 0x12); break;
                case 11: Bits.SetByte(data, offset, 0x13); break;
                case 12: Bits.SetByte(data, offset, 0x15); break;
                case 13: Bits.SetByte(data, offset, 0x16); break;
                case 14: Bits.SetByte(data, offset, 0x17); break;
                case 15: Bits.SetByte(data, offset, 0x18); break;
                case 16: Bits.SetByte(data, offset, 0x19); break;
                case 17: Bits.SetByte(data, offset, 0x1A); break;
                case 18: Bits.SetByte(data, offset, 0x1B); break;
                case 19: Bits.SetByte(data, offset, 0x1D); break;
                case 20: Bits.SetByte(data, offset, 0x1E); break;
                case 21: Bits.SetByte(data, offset, 0x1F); break;
                case 22: Bits.SetByte(data, offset, 0x20); break;
                case 23: Bits.SetByte(data, offset, 0x21); break;
                case 24: Bits.SetByte(data, offset, 0x22); break;
            }
        }
        public void Clear()
        {
            int offset = 0;

            offset = (index * 18) + 0x1D0040; offset++;

            this.messageBox = 0;
            this.maskLock = false;

            this.maskLowX = 0;
            this.maskLowY = 0;
            this.maskHighX = 63;
            this.maskHighY = 63;

            this.leftShiftL2 = 0;
            this.upShiftL2 = 0;
            this.leftShiftL3 = 0;
            this.infiniteAutoscroll = false;
            this.upShiftL3 = 0;

            this.horizontalScrollWrapL1 = false;
            this.verticalScrollWrapL1 = false;
            this.culexA = false;
            this.culexB = false;
            this.horizontalScrollWrapL2 = false;
            this.verticalScrollWrapL2 = false;
            this.horizontalScrollWrapL3 = false;
            this.verticalScrollWrapL3 = false;

            this.horizontalSyncL2 = 0;
            this.verticalSyncL2 = 0;
            this.horizontalSyncL3 = 0;
            this.verticalSyncL3 = 0;

            this.scrollDirectionL2 = 0;
            this.scrollSpeedL2 = 0;
            this.scrollDirectionL3 = 0;
            this.scrollSpeedL3 = 0;
            this.waveEffectL3 = false;
            this.layerPrioritySet = 0;
            this.animationEffectL3 = 0;
            this.extraEffects = 0;
        }
    }
}
