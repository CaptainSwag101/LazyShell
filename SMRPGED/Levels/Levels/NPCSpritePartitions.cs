using System;
using System.Collections.Generic;
using System.Text;

namespace SMRPGED
{
    public class NPCSpritePartitions
    {
        private byte[] data; public byte[] Data { get { return this.data; } set { this.data = value; } }

        private int spritePartitionNum; public int SpritePartitionNum { get { return spritePartitionNum; } set { spritePartitionNum = value; } }

        private bool byte1bit0; public bool Byte1bit0 { get { return byte1bit0; } set { byte1bit0 = value; } }
        private bool byte1bit1; public bool Byte1bit1 { get { return byte1bit1; } set { byte1bit1 = value; } }
        private bool byte1bit2; public bool Byte1bit2 { get { return byte1bit2; } set { byte1bit2 = value; } }
        private bool byte1bit3; public bool Byte1bit3 { get { return byte1bit3; } set { byte1bit3 = value; } }
        private bool byte1bit4; public bool Byte1bit4 { get { return byte1bit4; } set { byte1bit4 = value; } }
        private bool byte1bit7; public bool Byte1bit7 { get { return byte1bit7; } set { byte1bit7 = value; } }
        private byte palIndexPlus; public byte PalIndexPlus { get { return palIndexPlus; } set { palIndexPlus = value; } }
        private byte vramIndex; public byte VramIndex { get { return vramIndex; } set { vramIndex = value; } }

        private byte byte2a; public byte Byte2a { get { return byte2a; } set { byte2a = value; } }
        private byte byte2b; public byte Byte2b { get { return byte2b; } set { byte2b = value; } }
        private bool byte2bit7; public bool Byte2bit7 { get { return byte2bit7; } set { byte2bit7 = value; } }

        private byte byte3a; public byte Byte3a { get { return byte3a; } set { byte3a = value; } }
        private byte byte3b; public byte Byte3b { get { return byte3b; } set { byte3b = value; } }
        private bool byte3bit7; public bool Byte3bit7 { get { return byte3bit7; } set { byte3bit7 = value; } }

        private byte byte4a; public byte Byte4a { get { return byte4a; } set { byte4a = value; } }
        private byte byte4b; public byte Byte4b { get { return byte4b; } set { byte4b = value; } }
        private bool byte4bit7; public bool Byte4bit7 { get { return byte4bit7; } set { byte4bit7 = value; } }

        public NPCSpritePartitions(byte[] data, int spritePartitionNum)
        {
            this.data = data;
            this.spritePartitionNum = spritePartitionNum;
            InitializeSpritePartitions(data);
        }

        private void InitializeSpritePartitions(byte[] data)
        {
            int offset = spritePartitionNum * 4 + 0x1DDE00;
            byte temp = 0;

            temp = BitManager.GetByte(data, offset); offset++;
            if ((temp & 0x10) == 0x10) byte1bit4 = true;
            if ((temp & 0x80) == 0x80) byte1bit7 = true;
            palIndexPlus = (byte)((temp & 0x60) >> 5);
            vramIndex = (byte)(temp & 0x0F);

            temp = BitManager.GetByte(data, offset); offset++;
            switch (temp & 0x07)
            {
                case 7: byte2a = 5; break;
                default: byte2a = (byte)(temp & 0x07); break;
            }
            byte2b = (byte)((temp & 0x70) >> 4);
            if ((temp & 0x80) == 0x80) byte2bit7 = true;

            temp = BitManager.GetByte(data, offset); offset++;
            switch (temp & 0x07)
            {
                case 7: byte3a = 5; break;
                default: byte3a = (byte)(temp & 0x07); break;
            }
            byte3b = (byte)((temp & 0x70) >> 4);
            if ((temp & 0x80) == 0x80) byte3bit7 = true;

            temp = BitManager.GetByte(data, offset); offset++;
            switch (temp & 0x07)
            {
                case 7: byte4a = 5; break;
                default: byte4a = (byte)(temp & 0x07); break;
            }
            byte4b = (byte)((temp & 0x70) >> 4);
            if ((temp & 0x80) == 0x80) byte4bit7 = true;
        }
    }
}
