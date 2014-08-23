using System;
using System.Collections.Generic;
using System.Text;

namespace LAZYSHELL.Sprites
{
    [Serializable()]
    public class NPCPacket
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
        public byte Sprite { get; set; }
        public byte B0 { get; set; }
        public byte B1a { get; set; }
        public byte B1b { get; set; }
        public byte B1c { get; set; }
        public bool B2b2 { get; set; }
        public bool B2b3 { get; set; }
        public bool B2b4 { get; set; }
        public bool ShowShadow { get; set; }
        public byte B2 { get; set; }
        public ushort Action { get; set; }
        public byte B4 { get; set; }

        #endregion

        // Constructor
        public NPCPacket(int index)
        {
            this.Index = index;
            ReadFromROM();
        }

        #region Methods

        private void ReadFromROM()
        {
            int offset = Index * 5 + 0x1DB000;
            //
            Sprite = (byte)(rom[offset] & 0x3F);
            B0 = (byte)(rom[offset++] >> 6);
            B1a = (byte)(rom[offset] & 0x07);
            B1b = (byte)((rom[offset] >> 3) & 0x03);
            B1c = (byte)(rom[offset++] >> 5);
            B2b2 = Bits.GetBit(rom, offset, 2);
            B2b3 = Bits.GetBit(rom, offset, 3);
            B2b4 = Bits.GetBit(rom, offset, 4);
            ShowShadow = Bits.GetBit(rom, offset, 5);
            B2 = (byte)(rom[offset++] >> 6);
            Action = (ushort)(Bits.GetShort(rom, offset++) & 0x3FF);
            B4 = (byte)(rom[offset] >> 4);
        }
        public void WriteToROM()
        {
            int offset = Index * 5 + 0x1DB000;
            //
            rom[offset] = Sprite;
            rom[offset++] |= (byte)(B0 << 6);
            rom[offset] = B1a;
            rom[offset] |= (byte)(B1b << 3);
            rom[offset++] |= (byte)(B1c << 5);
            Bits.SetBit(rom, offset, 2, B2b2);
            Bits.SetBit(rom, offset, 3, B2b3);
            Bits.SetBit(rom, offset, 4, B2b4);
            Bits.SetBit(rom, offset, 5, ShowShadow);
            rom[offset++] |= (byte)(B2 << 6);
            Bits.SetShort(rom, offset++, Action);
            rom[offset] |= (byte)(B4 << 4);
        }

        #endregion
    }
}
