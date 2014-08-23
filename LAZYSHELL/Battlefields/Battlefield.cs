using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace LAZYSHELL.Battlefields
{
    [Serializable()]
    public class Battlefield
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
        public byte GraphicSetA { get; set; }
        public byte GraphicSetB { get; set; }
        public byte GraphicSetC { get; set; }
        public byte GraphicSetD { get; set; }
        public byte GraphicSetE { get; set; }
        public byte Tileset { get; set; }
        public byte PaletteSet { get; set; }

        #endregion

        // Constructor
        public Battlefield(int index)
        {
            this.Index = index;
            ReadFromROM();
        }

        #region Methods

        // Read/write ROM
        private void ReadFromROM()
        {
            int offset = (Index * 8) + 0x39B644;
            GraphicSetA = rom[offset++];
            GraphicSetB = rom[offset++];
            GraphicSetC = rom[offset++];
            GraphicSetD = rom[offset++];
            GraphicSetE = rom[offset]; offset += 2;
            if (GraphicSetA > 0xC7) GraphicSetA = 0xC8;
            if (GraphicSetB > 0xC7) GraphicSetB = 0xC8;
            if (GraphicSetC > 0xC7) GraphicSetC = 0xC8;
            if (GraphicSetD > 0xC7) GraphicSetD = 0xC8;
            if (GraphicSetE > 0xC7) GraphicSetE = 0xC8;
            Tileset = rom[offset++];
            PaletteSet = rom[offset++];
        }
        public void WriteToROM()
        {
            int offset = (Index * 8) + 0x39B644;
            if (GraphicSetA == 0xC8) rom[offset] = 0xFF;
            else rom[offset] = GraphicSetA; offset++;
            if (GraphicSetB == 0xC8) rom[offset] = 0xFF;
            else rom[offset] = GraphicSetB; offset++;
            if (GraphicSetC == 0xC8) rom[offset] = 0xFF;
            else rom[offset] = GraphicSetC; offset++;
            if (GraphicSetD == 0xC8) rom[offset] = 0xFF;
            else rom[offset] = GraphicSetD; offset++;
            if (GraphicSetE == 0xC8) rom[offset] = 0xFF;
            else rom[offset] = GraphicSetE; offset += 2;
            rom[offset] = Tileset; offset++;
            rom[offset] = PaletteSet; offset++;
        }

        #endregion
    }
}
