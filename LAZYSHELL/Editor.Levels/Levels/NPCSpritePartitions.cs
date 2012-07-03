using System;
using System.Collections.Generic;
using System.Text;

namespace LAZYSHELL
{
    public class NPCSpritePartitions
    {
        private byte[] data; public byte[] Data { get { return this.data; } set { this.data = value; } }

        private int index; public int Index { get { return index; } set { index = value; } }

        private bool byte1bit0; public bool Byte1bit0 { get { return byte1bit0; } set { byte1bit0 = value; } }
        private bool byte1bit1; public bool Byte1bit1 { get { return byte1bit1; } set { byte1bit1 = value; } }
        private bool byte1bit2; public bool Byte1bit2 { get { return byte1bit2; } set { byte1bit2 = value; } }
        private bool byte1bit3; public bool Byte1bit3 { get { return byte1bit3; } set { byte1bit3 = value; } }
        private bool extraSprites; public bool ExtraSprites { get { return extraSprites; } set { extraSprites = value; } }
        private bool fullPaletteBuffer; public bool FullPaletteBuffer { get { return fullPaletteBuffer; } set { fullPaletteBuffer = value; } }
        private byte allySpriteBuffer; public byte AllySpriteBuffer { get { return allySpriteBuffer; } set { allySpriteBuffer = value; } }
        private byte extraSpriteBuffer; public byte ExtraSpriteBuffer { get { return extraSpriteBuffer; } set { extraSpriteBuffer = value; } }

        private byte cloneAsprite; public byte CloneASprite { get { return cloneAsprite; } set { cloneAsprite = value; } }
        private byte cloneAmain; public byte CloneAMain { get { return cloneAmain; } set { cloneAmain = value; } }
        private bool cloneAindexing; public bool Byte2bit7 { get { return cloneAindexing; } set { cloneAindexing = value; } }

        private byte cloneBsprite; public byte CloneBSprite { get { return cloneBsprite; } set { cloneBsprite = value; } }
        private byte cloneBmain; public byte CloneBMain { get { return cloneBmain; } set { cloneBmain = value; } }
        private bool cloneBindexing; public bool CloneBIndexing { get { return cloneBindexing; } set { cloneBindexing = value; } }

        private byte cloneCsprite; public byte CloneCSprite { get { return cloneCsprite; } set { cloneCsprite = value; } }
        private byte cloneCmain; public byte CloneCMain { get { return cloneCmain; } set { cloneCmain = value; } }
        private bool cloneCindexing; public bool CloneCIndexing { get { return cloneCindexing; } set { cloneCindexing = value; } }

        public NPCSpritePartitions(byte[] data, int index)
        {
            this.data = data;
            this.index = index;
            InitializeSpritePartitions(data);
        }
        private void InitializeSpritePartitions(byte[] data)
        {
            int offset = index * 4 + 0x1DDE00;
            byte temp = 0;

            temp = data[offset]; offset++;
            if ((temp & 0x10) == 0x10) extraSprites = true;
            if ((temp & 0x80) == 0x80) fullPaletteBuffer = true;
            allySpriteBuffer = (byte)((temp & 0x60) >> 5);
            extraSpriteBuffer = (byte)(temp & 0x0F);

            temp = data[offset]; offset++;
            cloneAsprite = (byte)(temp & 0x07);
            cloneAmain = (byte)((temp & 0x70) >> 4);
            if ((temp & 0x80) == 0x80) cloneAindexing = true;

            temp = data[offset]; offset++;
            cloneBsprite = (byte)(temp & 0x07);
            cloneBmain = (byte)((temp & 0x70) >> 4);
            if ((temp & 0x80) == 0x80) cloneBindexing = true;

            temp = data[offset]; offset++;
            cloneCsprite = (byte)(temp & 0x07);
            cloneCmain = (byte)((temp & 0x70) >> 4);
            if ((temp & 0x80) == 0x80) cloneCindexing = true;
        }
        public void Assemble()
        {
            int offset = index * 4 + 0x1DDE00;
            //
            data[offset] = 0;
            data[offset] = (byte)(allySpriteBuffer << 5);
            data[offset] |= extraSpriteBuffer;
            Bits.SetBit(data, offset, 4, extraSprites);
            Bits.SetBit(data, offset, 7, fullPaletteBuffer);
            offset++;
            //
            data[offset] = cloneAsprite;
            data[offset] |= (byte)(cloneAmain << 4);
            Bits.SetBit(data, offset, 7, cloneAindexing);
            offset++;
            //
            data[offset] = cloneBsprite;
            data[offset] |= (byte)(cloneBmain << 4);
            Bits.SetBit(data, offset, 7, cloneBindexing);
            offset++;
            //
            data[offset] = cloneCsprite;
            data[offset] |= (byte)(cloneCmain << 4);
            Bits.SetBit(data, offset, 7, cloneCindexing);
            offset++;
        }
    }
}
