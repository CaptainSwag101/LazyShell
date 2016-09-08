using System;
using System.Collections.Generic;
using System.Text;

namespace LazyShell.Areas
{
    public class PrioritySet
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
        public bool MainscreenL1 { get; set; }
        public bool MainscreenL2 { get; set; }
        public bool MainscreenL3 { get; set; }
        public bool MainscreenOBJ { get; set; }
        public bool SubscreenL1 { get; set; }
        public bool SubscreenL2 { get; set; }
        public bool SubscreenL3 { get; set; }
        public bool SubscreenOBJ { get; set; }
        public bool ColorMathL1 { get; set; }
        public bool ColorMathL2 { get; set; }
        public bool ColorMathL3 { get; set; }
        public bool ColorMathOBJ { get; set; }
        public bool ColorMathBG { get; set; }
        public bool ColorMathHalfIntensity { get; set; }
        public bool ColorMathMinusSubscreen { get; set; }

        #endregion

        // Constructor
        public PrioritySet(int index)
        {
            this.Index = index;
            ReadFromROM();
        }

        #region Methods

        // Read/write
        private void ReadFromROM()
        {
            int layerPriorityOffset = (Index * 3) + 0x1D0000;
            int temp = rom[layerPriorityOffset]; layerPriorityOffset++;
            MainscreenL1 = (temp & 0x01) == 0x01;
            MainscreenL2 = (temp & 0x02) == 0x02;
            MainscreenL3 = (temp & 0x04) == 0x04;
            MainscreenOBJ = (temp & 0x10) == 0x10;
            temp = rom[layerPriorityOffset]; layerPriorityOffset++;
            SubscreenL1 = (temp & 0x01) == 0x01;
            SubscreenL2 = (temp & 0x02) == 0x02;
            SubscreenL3 = (temp & 0x04) == 0x04;
            SubscreenOBJ = (temp & 0x10) == 0x10;
            temp = rom[layerPriorityOffset]; layerPriorityOffset++;
            ColorMathL1 = (temp & 0x01) == 0x01;
            ColorMathL2 = (temp & 0x02) == 0x02;
            ColorMathL3 = (temp & 0x04) == 0x04;
            ColorMathOBJ = (temp & 0x10) == 0x10;
            ColorMathBG = (temp & 0x20) == 0x20;
            ColorMathHalfIntensity = (temp & 0x40) == 0x40;
            ColorMathMinusSubscreen = (temp & 0x80) == 0x80;
        }
        public void WriteToROM()
        {
            int offset = (Index * 3) + 0x1D0000;
            Bits.SetBit(rom, offset, 0, MainscreenL1);
            Bits.SetBit(rom, offset, 1, MainscreenL2);
            Bits.SetBit(rom, offset, 2, MainscreenL3);
            Bits.SetBit(rom, offset, 4, MainscreenOBJ);
            offset++;
            Bits.SetBit(rom, offset, 0, SubscreenL1);
            Bits.SetBit(rom, offset, 1, SubscreenL2);
            Bits.SetBit(rom, offset, 2, SubscreenL3);
            Bits.SetBit(rom, offset, 4, SubscreenOBJ);
            offset++;
            Bits.SetBit(rom, offset, 0, ColorMathL1);
            Bits.SetBit(rom, offset, 1, ColorMathL2);
            Bits.SetBit(rom, offset, 2, ColorMathL3);
            Bits.SetBit(rom, offset, 4, ColorMathOBJ);
            Bits.SetBit(rom, offset, 5, ColorMathBG);
            Bits.SetBit(rom, offset, 6, ColorMathHalfIntensity);
            Bits.SetBit(rom, offset, 7, ColorMathMinusSubscreen);
        }

        #endregion
    }
}