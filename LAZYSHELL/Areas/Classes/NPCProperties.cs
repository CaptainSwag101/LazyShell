using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace LAZYSHELL.Areas
{
    [Serializable()]
    public class NPCProperties
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
        // Properties
        public ushort Sprite { get; set; }
        public bool Priority0 { get; set; }
        public bool Priority1 { get; set; }
        public bool Priority2 { get; set; }
        public byte YPixelShiftUp { get; set; }
        public bool Shift16pxDown { get; set; }
        public byte AcuteAxis { get; set; }
        public byte ObtuseAxis { get; set; }
        public byte Height { get; set; }
        public byte Shadow { get; set; }
        public byte Byte1a { get; set; }
        public byte Byte1b { get; set; }
        public bool B2b0 { get; set; }
        public bool B2b1 { get; set; }
        public bool B2b2 { get; set; }
        public bool B2b3 { get; set; }
        public bool B2b4 { get; set; }
        public bool ActiveVRAM { get; set; }
        public bool ShowShadow { get; set; }
        public bool B5b6 { get; set; }
        public bool B5b7 { get; set; }
        public bool B6b2 { get; set; }

        #endregion

        // Constructor
        public NPCProperties(int index)
        {
            this.Index = index;
            ReadFromROM();
        }

        #region Methods

        // Read/write
        private void ReadFromROM()
        {
            int offset = Index * 7 + 0x1DB800;
            ushort temp = Bits.GetShort(rom, offset++);
            //
            Sprite = (ushort)(temp & 0x03FF);
            Byte1a = (byte)((rom[offset] >> 2) & 7);
            Byte1b = (byte)(rom[offset++] >> 5);
            //
            Priority0 = (rom[offset] & 0x20) == 0x20;
            Priority1 = (rom[offset] & 0x40) == 0x40;
            Priority2 = (rom[offset] & 0x80) == 0x80;
            B2b0 = (rom[offset] & 0x01) == 0x01;
            B2b1 = (rom[offset] & 0x02) == 0x02;
            B2b2 = (rom[offset] & 0x04) == 0x04;
            B2b3 = (rom[offset] & 0x08) == 0x08;
            B2b4 = (rom[offset++] & 0x10) == 0x10;
            //
            YPixelShiftUp = (byte)(rom[offset] & 0x0F);
            Shift16pxDown = (rom[offset] & 0x10) == 0x10;
            Shadow = (byte)((rom[offset] & 0x60) >> 5);
            ActiveVRAM = (rom[offset++] & 0x80) == 0x80;
            //
            AcuteAxis = (byte)(rom[offset] & 0x0F);
            ObtuseAxis = (byte)((rom[offset++] & 0xF0) >> 4);
            //
            Height = (byte)(rom[offset] & 0x1F);
            ShowShadow = (rom[offset] & 0x20) == 0x20;
            B5b6 = (rom[offset] & 0x40) == 0x40;
            B5b7 = (rom[offset++] & 0x80) == 0x80;
            //
            B6b2 = (rom[offset] & 0x04) == 0x04;
        }
        public void WriteToROM()
        {
            int offset = Index * 7 + 0x1DB800;
            //
            Bits.SetShort(rom, offset++, Sprite);
            rom[offset] |= (byte)(Byte1a << 2);
            rom[offset++] |= (byte)(Byte1b << 5);
            //
            Bits.SetBit(rom, offset, 5, Priority0);
            Bits.SetBit(rom, offset, 6, Priority1);
            Bits.SetBit(rom, offset, 7, Priority2);
            Bits.SetBit(rom, offset, 0, B2b0);
            Bits.SetBit(rom, offset, 1, B2b1);
            Bits.SetBit(rom, offset, 2, B2b2);
            Bits.SetBit(rom, offset, 3, B2b3);
            Bits.SetBit(rom, offset++, 4, B2b4);
            //
            rom[offset] = YPixelShiftUp;
            Bits.SetBit(rom, offset, 4, Shift16pxDown);
            rom[offset] &= 0x9F;
            rom[offset] |= (byte)(Shadow << 5);
            Bits.SetBit(rom, offset++, 7, ActiveVRAM);
            //
            rom[offset] = AcuteAxis;
            rom[offset++] |= (byte)(ObtuseAxis << 4);
            //
            rom[offset] = Height;
            Bits.SetBit(rom, offset, 5, ShowShadow);
            Bits.SetBit(rom, offset, 6, B5b6);
            Bits.SetBit(rom, offset++, 7, B5b7);
            //
            Bits.SetBit(rom, offset, 2, B6b2);
        }

        // Spawning
        public NPCProperties Copy()
        {
            return new NPCProperties(this.Index);
        }

        // Override
        public override string ToString()
        {
            return "NPC ID #" + Index;
        }

        #endregion
    }
}
