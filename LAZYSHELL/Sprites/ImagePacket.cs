using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace LazyShell.Sprites
{
    [Serializable()]
    public class ImagePacket
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
        public int PaletteOffset { get; set; }
        public int GraphicOffset { get; set; }
        public int PaletteNum { get; set; }

        #endregion

        // Constructor
        public ImagePacket(int index)
        {
            this.Index = index;
            ReadFromROM();
        }

        #region Methods

        // Read/write ROM
        private void ReadFromROM()
        {
            int offset = (Index * 4) + 0x251800;
            int bank = (int)(((rom[offset] & 0x0F) << 16) + 0x280000);
            GraphicOffset = (int)((Bits.GetShort(rom, offset) & 0xFFF0) + bank); offset += 2;
            PaletteOffset = (int)(Bits.GetShort(rom, offset) + 0x250000);
            //
            if (PaletteOffset < 0x253000)
                PaletteOffset = 0x253000;
            PaletteNum = (PaletteOffset - 0x253000) / 30;
        }
        public void WriteToROM()
        {
            int offset = (Index * 4) + 0x251800;
            byte bank = (byte)((GraphicOffset - 0x280000) >> 16);
            ushort pointer = (ushort)(GraphicOffset & 0xFFF0);
            Bits.SetShort(rom, offset, pointer);
            rom[offset] |= bank; offset += 2;
            //
            Bits.SetShort(rom, offset, (ushort)(PaletteNum * 30 + 0x3000));
        }

        // accessor functions
        public byte[] Graphics(byte[] spriteGraphics)
        {
            return Bits.GetBytes(spriteGraphics, GraphicOffset - 0x280000, 0x4000);
        }

        #endregion
    }
}
