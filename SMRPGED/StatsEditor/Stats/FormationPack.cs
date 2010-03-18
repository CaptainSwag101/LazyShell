using System;
using System.Collections.Generic;
using System.Text;

namespace SMRPGED.StatsEditor.Stats
{
    public class FormationPack
    {
        private byte[] data; public byte[] Data { get { return this.data; } set { this.data = value; } }

        #region Formation Pack stats
        private int formationPackNum; public int FormationPackNum { get { return this.formationPackNum; } }
        private byte formationPackSet; public byte FormationPackSet { get { return this.formationPackSet; } set { this.formationPackSet = value; } }
        private byte[] formationPackForm = new byte[3]; public byte[] FormationPackForm { get { return this.formationPackForm; } set { this.formationPackForm = value; } }
        #endregion

        public FormationPack(byte[] data, int formationPackNum)
        {
            this.data = data;
            this.formationPackNum = formationPackNum;
            InitializePack(data);
        }

        private void InitializePack(byte[] data)
        {
            byte temp = 0;

            int formPackOffset = (formationPackNum * 4) + 0x39222A;

            formationPackForm[0] = BitManager.GetByte(data, formPackOffset); formPackOffset++;
            formationPackForm[1] = BitManager.GetByte(data, formPackOffset); formPackOffset++;
            formationPackForm[2] = BitManager.GetByte(data, formPackOffset); formPackOffset++;

            temp = BitManager.GetByte(data, formPackOffset); formPackOffset++;

            formationPackSet = temp == 7 ? (byte)1 : (byte)0;
        }
        public void Assemble()
        {
            int formPackOffset = (formationPackNum * 4) + 0x39222A;

            BitManager.SetByte(data, formPackOffset, formationPackForm[0]); formPackOffset++;
            BitManager.SetByte(data, formPackOffset, formationPackForm[1]); formPackOffset++;
            BitManager.SetByte(data, formPackOffset, formationPackForm[2]); formPackOffset++;

            if (formationPackSet == 1)
                BitManager.SetByte(data, formPackOffset, 0x07);
            else if (formationPackSet == 0)
                BitManager.SetByte(data, formPackOffset, 0x00);
        }
        public void Clear()
        {
            formationPackSet = 0;
            formationPackForm = new byte[3];
        }
    }
}
