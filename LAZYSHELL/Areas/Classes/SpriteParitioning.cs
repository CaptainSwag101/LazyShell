using System;
using System.Collections.Generic;
using System.Text;

namespace LazyShell.Areas
{
    public class SpritePartitioning
    {
        #region Variables

        // ROM buffer
        private byte[] rom
        {
            get { return Model.ROM; }
            set { Model.ROM = value; }
        }
        public int Index { get; set; }
        // Properties - main buffer
        public bool ExtraSprites { get; set; }
        public bool FullPaletteBuffer { get; set; }
        public byte AllySpriteBuffer { get; set; }
        public byte ExtraSpriteBuffer { get; set; }
        // Properties - reference buffers
        public byte CloneASprite { get; set; }
        public byte CloneAMain { get; set; }
        public bool CloneAIndexing { get; set; }
        public byte CloneBSprite { get; set; }
        public byte CloneBMain { get; set; }
        public bool CloneBIndexing { get; set; }
        public byte CloneCSprite { get; set; }
        public byte CloneCMain { get; set; }
        public bool CloneCIndexing { get; set; }
        // Properties - unknown
        public bool B1b0 { get; set; }
        public bool B1b1 { get; set; }
        public bool B1b2 { get; set; }
        public bool B1b3 { get; set; }

        #endregion

        // Constructor
        public SpritePartitioning(int index)
        {
            this.Index = index;
            ReadFromROM();
        }

        #region Methods

        // Read/write
        private void ReadFromROM()
        {
            int offset = Index * 4 + 0x1DDE00;
            byte temp = 0;
            temp = rom[offset++];
            ExtraSprites = (temp & 0x10) == 0x10;
            FullPaletteBuffer = (temp & 0x80) == 0x80;
            AllySpriteBuffer = (byte)((temp & 0x60) >> 5);
            ExtraSpriteBuffer = (byte)(temp & 0x0F);
            temp = rom[offset++];
            CloneASprite = (byte)(temp & 0x07);
            CloneAMain = (byte)((temp & 0x70) >> 4);
            CloneAIndexing = (temp & 0x80) == 0x80;
            temp = rom[offset++];
            CloneBSprite = (byte)(temp & 0x07);
            CloneBMain = (byte)((temp & 0x70) >> 4);
            CloneBIndexing = (temp & 0x80) == 0x80;
            temp = rom[offset++];
            CloneCSprite = (byte)(temp & 0x07);
            CloneCMain = (byte)((temp & 0x70) >> 4);
            CloneCIndexing = (temp & 0x80) == 0x80;
        }
        public void WriteToROM()
        {
            int offset = Index * 4 + 0x1DDE00;
            //
            rom[offset] = 0;
            rom[offset] = (byte)(AllySpriteBuffer << 5);
            rom[offset] |= ExtraSpriteBuffer;
            Bits.SetBit(rom, offset, 4, ExtraSprites);
            Bits.SetBit(rom, offset, 7, FullPaletteBuffer);
            offset++;
            //
            rom[offset] = CloneASprite;
            rom[offset] |= (byte)(CloneAMain << 4);
            Bits.SetBit(rom, offset, 7, CloneAIndexing);
            offset++;
            //
            rom[offset] = CloneBSprite;
            rom[offset] |= (byte)(CloneBMain << 4);
            Bits.SetBit(rom, offset, 7, CloneBIndexing);
            offset++;
            //
            rom[offset] = CloneCSprite;
            rom[offset] |= (byte)(CloneCMain << 4);
            Bits.SetBit(rom, offset, 7, CloneCIndexing);
            offset++;
        }

        #endregion
    }
}
