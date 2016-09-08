using System;
using System.Collections.Generic;
using System.Text;

namespace LazyShell.Formations
{
    [Serializable()]
    public class Pack : Element
    {
        #region Variables

        // ROM buffer
        private byte[] rom
        {
            get { return Model.ROM; }
            set { Model.ROM = value; }
        }

        // Index
        public override int Index { get; set; }

        // Properties
        public ushort[] Formations { get; set; }

        #endregion

        // Constructor
        public Pack(int index)
        {
            this.Index = index;
            ReadFromROM();
        }

        #region Methods

        // Read/write ROM
        private void ReadFromROM()
        {
            int offset = (Index * 4) + 0x39222A;
            Formations = new ushort[3];
            Formations[0] = rom[offset++];
            Formations[1] = rom[offset++];
            Formations[2] = rom[offset++];
            if ((rom[offset] & 0x01) == 0x01)
                Formations[0] += 0x100;
            if ((rom[offset] & 0x02) == 0x02)
                Formations[1] += 0x100;
            if ((rom[offset] & 0x04) == 0x04)
                Formations[2] += 0x100;
        }
        public void WriteToROM()
        {
            int offset = (Index * 4) + 0x39222A;
            rom[offset++] = (byte)Formations[0];
            rom[offset++] = (byte)Formations[1];
            rom[offset++] = (byte)Formations[2];
            Bits.SetBit(rom, offset, 0, Formations[0] >= 0x100);
            Bits.SetBit(rom, offset, 1, Formations[1] >= 0x100);
            Bits.SetBit(rom, offset, 2, Formations[2] >= 0x100);
        }

        // Inherited
        public override void Clear()
        {
            Formations = new ushort[3];
        }

        // Override
        public override string ToString()
        {
            return base.ToString();
        }

        #endregion
    }
}
