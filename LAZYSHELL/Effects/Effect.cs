using System;
using System.Collections.Generic;
using System.Text;

namespace LAZYSHELL.Effects
{
    [Serializable()]
    public class Effect
    {
        #region Variables

        // ROM buffer
        private byte[] rom
        {
            get { return Model.ROM; }
            set { Model.ROM = value; }
        }

        // Properties
        public int Index { get; set; }
        public byte PaletteIndex { get; set; }
        public byte ImageNum { get; set; }
        public byte X { get; set; }
        public byte Y { get; set; }

        #endregion

        // Constructor
        public Effect(int index)
        {
            this.Index = index;
            ReadFromROM();
        }

        #region Methods

        // Read/write ROM
        private void ReadFromROM()
        {
            int offset = (Index * 4) + 0x251000;
            PaletteIndex = (byte)(rom[offset] & 7); offset++;
            ImageNum = rom[offset++];
            X = (byte)(rom[offset] - 1 ^ 255); offset++;
            Y = (byte)(rom[offset] - 1 ^ 255); offset++;
        }
        public void WriteToROM()
        {
            int offset = (Index * 4) + 0x251000;
            rom[offset] = PaletteIndex; offset++;
            rom[offset] = ImageNum; offset++;
            rom[offset] = (byte)(X - 1 ^ 255); offset++;
            rom[offset] = (byte)(Y - 1 ^ 255); offset++;
        }

        #endregion
    }
}
