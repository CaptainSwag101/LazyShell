using System;
using System.Collections.Generic;
using System.Text;

namespace LAZYSHELL
{
    [Serializable()]
    public class FormationPack : Element
    {
        [NonSerialized()]
        private byte[] data;
        public override byte[] Data { get { return data; } set { data = value; } }
        public override int Index { get { return index; } set { index = value; } }

        #region Formation Pack stats
        private int index;
        private ushort[] packFormations = new ushort[3];
        public ushort[] PackFormations { get { return this.packFormations; } set { this.packFormations = value; } }
        #endregion

        public FormationPack(byte[] data, int index)
        {
            this.data = data;
            this.index = index;
            InitializePack(data);
        }

        private void InitializePack(byte[] data)
        {
            int offset = (index * 4) + 0x39222A;
            packFormations[0] = data[offset]; offset++;
            packFormations[1] = data[offset]; offset++;
            packFormations[2] = data[offset]; offset++;
            if ((data[offset] & 0x01) == 0x01)
                packFormations[0] += 0x100;
            if ((data[offset] & 0x02) == 0x02)
                packFormations[1] += 0x100;
            if ((data[offset] & 0x04) == 0x04)
                packFormations[2] += 0x100;
        }
        public void Assemble()
        {
            int offset = (index * 4) + 0x39222A;
            Bits.SetByte(data, offset, (byte)packFormations[0]); offset++;
            Bits.SetByte(data, offset, (byte)packFormations[1]); offset++;
            Bits.SetByte(data, offset, (byte)packFormations[2]); offset++;
            Bits.SetBit(data, offset, 0, packFormations[0] >= 0x100);
            Bits.SetBit(data, offset, 1, packFormations[1] >= 0x100);
            Bits.SetBit(data, offset, 2, packFormations[2] >= 0x100);
        }
        public override void Clear()
        {
            packFormations = new ushort[3];
        }
    }
}
