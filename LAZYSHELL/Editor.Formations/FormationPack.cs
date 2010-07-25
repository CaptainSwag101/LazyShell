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
        public override int Index { get { return index;} set { index = value;} }

        #region Formation Pack stats
        private int index; 
        private byte formationPackSet; public byte FormationPackSet { get { return this.formationPackSet; } set { this.formationPackSet = value; } }
        private byte[] formationPackForm = new byte[3]; public byte[] FormationPackForm { get { return this.formationPackForm; } set { this.formationPackForm = value; } }
        #endregion

        public FormationPack(byte[] data, int index)
        {
            this.data = data;
            this.index = index;
            InitializePack(data);
        }

        private void InitializePack(byte[] data)
        {
            byte temp = 0;

            int formPackOffset = (index * 4) + 0x39222A;

            formationPackForm[0] = data[formPackOffset]; formPackOffset++;
            formationPackForm[1] = data[formPackOffset]; formPackOffset++;
            formationPackForm[2] = data[formPackOffset]; formPackOffset++;

            temp = data[formPackOffset]; formPackOffset++;

            formationPackSet = temp == 7 ? (byte)1 : (byte)0;
        }
        public void Assemble()
        {
            int formPackOffset = (index * 4) + 0x39222A;

            Bits.SetByte(data, formPackOffset, formationPackForm[0]); formPackOffset++;
            Bits.SetByte(data, formPackOffset, formationPackForm[1]); formPackOffset++;
            Bits.SetByte(data, formPackOffset, formationPackForm[2]); formPackOffset++;

            if (formationPackSet == 1)
                Bits.SetByte(data, formPackOffset, 0x07);
            else if (formationPackSet == 0)
                Bits.SetByte(data, formPackOffset, 0x00);
        }
        public override void Clear()
        {
            formationPackSet = 0;
            formationPackForm = new byte[3];
        }
    }
}
