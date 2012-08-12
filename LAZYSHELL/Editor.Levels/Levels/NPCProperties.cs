using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace LAZYSHELL
{
    [Serializable()]
    public class NPCProperties
    {
        [NonSerialized()]
        private byte[] data; public byte[] Data { get { return this.data; } set { this.data = value; } }

        private byte moldX; public byte MoldX { get { return moldX; } set { moldX = value; } }
        private byte moldY; public byte MoldY { get { return moldY; } set { moldY = value; } }
        private bool moldGridPlane; public bool MoldGridPlane { get { return moldGridPlane; } set { moldGridPlane = value; } }

        private int index; public int Index { get { return index; } set { index = value; } }

        private ushort sprite; public ushort Sprite { get { return sprite; } set { sprite = value; } }
        private bool priority0; public bool Priority0 { get { return priority0; } set { priority0 = value; } }
        private bool priority1; public bool Priority1 { get { return priority1; } set { priority1 = value; } }
        private bool priority2; public bool Priority2 { get { return priority2; } set { priority2 = value; } }
        private byte yPixelShiftUp; public byte YPixelShiftUp { get { return yPixelShiftUp; } set { yPixelShiftUp = value; } }
        private bool shift16pxDown; public bool Shift16pxDown { get { return shift16pxDown; } set { shift16pxDown = value; } }
        private byte acuteAxis; public byte AcuteAxis { get { return acuteAxis; } set { acuteAxis = value; } }
        private byte obtuseAxis; public byte ObtuseAxis { get { return obtuseAxis; } set { obtuseAxis = value; } }
        private byte height; public byte Height { get { return height; } set { height = value; } }
        private byte shadow; public byte Shadow { get { return shadow; } set { shadow = value; } }
        private byte byte1a; public byte Byte1a { get { return byte1a; } set { byte1a = value; } }
        private byte byte1b; public byte Byte1b { get { return byte1b; } set { byte1b = value; } }
        private bool b2b0; public bool B2b0 { get { return b2b0; } set { b2b0 = value; } }
        private bool b2b1; public bool B2b1 { get { return b2b1; } set { b2b1 = value; } }
        private bool b2b2; public bool B2b2 { get { return b2b2; } set { b2b2 = value; } }
        private bool b2b3; public bool B2b3 { get { return b2b3; } set { b2b3 = value; } }
        private bool b2b4; public bool B2b4 { get { return b2b4; } set { b2b4 = value; } }
        private bool activeVRAM; public bool ActiveVRAM { get { return activeVRAM; } set { activeVRAM = value; } }
        private bool showShadow; public bool ShowShadow { get { return showShadow; } set { showShadow = value; } }
        private bool b5b6; public bool B5b6 { get { return b5b6; } set { b5b6 = value; } }
        private bool b5b7; public bool B5b7 { get { return b5b7; } set { b5b7 = value; } }
        private bool b6b2; public bool B6b2 { get { return b6b2; } set { b6b2 = value; } }

        public NPCProperties(byte[] data, int index)
        {
            this.data = data;
            this.index = index;
            InitializeNPC(data);
        }

        private void InitializeNPC(byte[] data)
        {
            int offset = index * 7 + 0x1DB800;

            ushort temp = 0;

            temp = Bits.GetShort(data, offset);
            offset++;

            sprite = (ushort)(temp & 0x03FF);
            byte1a = (byte)((data[offset] >> 2) & 7);
            byte1b = (byte)(data[offset] >> 5);
            offset++;

            priority0 = (data[offset] & 0x20) == 0x20;
            priority1 = (data[offset] & 0x40) == 0x40;
            priority2 = (data[offset] & 0x80) == 0x80;
            b2b0 = (data[offset] & 0x01) == 0x01;
            b2b1 = (data[offset] & 0x02) == 0x02;
            b2b2 = (data[offset] & 0x04) == 0x04;
            b2b3 = (data[offset] & 0x08) == 0x08;
            b2b4 = (data[offset] & 0x10) == 0x10;
            offset++;

            yPixelShiftUp = (byte)(data[offset] & 0x0F);
            shift16pxDown = (data[offset] & 0x10) == 0x10;
            shadow = (byte)((data[offset] & 0x60) >> 5);
            activeVRAM = (data[offset] & 0x80) == 0x80;
            offset++;

            acuteAxis = (byte)(data[offset] & 0x0F);
            obtuseAxis = (byte)((data[offset] & 0xF0) >> 4);
            offset++;

            height = (byte)(data[offset] & 0x1F);
            showShadow = (data[offset] & 0x20) == 0x20;
            b5b6 = (data[offset] & 0x40) == 0x40;
            b5b7 = (data[offset] & 0x80) == 0x80;
            offset++;

            b6b2 = (data[offset] & 0x04) == 0x04;
        }
        public void Assemble()
        {
            int offset = index * 7 + 0x1DB800;

            Bits.SetShort(data, offset, sprite); offset++;
            data[offset] |= (byte)(byte1a << 2);
            data[offset] |= (byte)(byte1b << 5);
            offset++;

            Bits.SetBit(data, offset, 5, priority0);
            Bits.SetBit(data, offset, 6, priority1);
            Bits.SetBit(data, offset, 7, priority2);
            Bits.SetBit(data, offset, 0, b2b0);
            Bits.SetBit(data, offset, 1, b2b1);
            Bits.SetBit(data, offset, 2, b2b2);
            Bits.SetBit(data, offset, 3, b2b3);
            Bits.SetBit(data, offset, 4, b2b4);
            offset++;

            data[offset] = yPixelShiftUp;
            Bits.SetBit(data, offset, 4, shift16pxDown);
            data[offset] &= 0x9F;
            data[offset] |= (byte)(shadow << 5);
            Bits.SetBit(data, offset, 7, activeVRAM);
            offset++;

            data[offset] = acuteAxis;
            data[offset] |= (byte)(obtuseAxis << 4);
            offset++;

            data[offset] = height;
            Bits.SetBit(data, offset, 5, showShadow);
            Bits.SetBit(data, offset, 6, b5b6);
            Bits.SetBit(data, offset, 7, b5b7);
            offset++;

            Bits.SetBit(data, offset, 2, b6b2);
        }
        public NPCProperties Copy()
        {
            return new NPCProperties(this.data, this.index);
        }
    }
}
