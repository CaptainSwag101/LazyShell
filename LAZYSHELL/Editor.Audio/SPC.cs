using System;
using System.Collections.Generic;
using System.Text;

namespace LAZYSHELL
{
    public class SPC
    {
        private byte[] data;
        private int index;
        public int Index { get { return index; } set { index = value; } }
        private byte[] spcData;
        public byte[] SPCData { get { return spcData; } set { spcData = value; } }
        public SPC(byte[] data, int index)
        {
            this.data = data;
            this.index = index;

            int offset = Bits.Get32Bit(data, index * 3 + 0x042748) - 0xC00000;
            int size = Bits.Get32Bit(data, (index + 1) * 3 + 0x042748) - 0xC00000 - offset;
        }
    }
}
