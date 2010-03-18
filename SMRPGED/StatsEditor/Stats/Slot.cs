using System;
using System.Collections.Generic;
using System.Text;

namespace SMRPGED.StatsEditor.Stats
{
    public class Slot
    {
        private byte[] data; public byte[] Data { get { return this.data; } set { this.data = value; } }
        private int slotNum;

        private byte equipment; public byte Equipment { get { return this.equipment; } set { this.equipment = value; } }
        private byte item; public byte Item { get { return this.item; } set { this.item = value; } }
        private byte specialItem; public byte SpecialItem { get { return this.specialItem; } set { this.specialItem = value; } }

        public Slot(byte[] data, int slotNum)
        {
            this.data = data;
            this.slotNum = slotNum;
            InitializeSlot();
        }

        private void InitializeSlot()
        {
            equipment = BitManager.GetByte(data, slotNum + 0x3A0090);
            item = BitManager.GetByte(data, slotNum + 0x3A00AE);
            if (slotNum > 0x0E)
                specialItem = BitManager.GetByte(data, 0x0F + 0x3A00CC);
            else specialItem = BitManager.GetByte(data, slotNum + 0x3A00CC);
        }
        public void Assemble()
        {
            BitManager.SetByte(data, slotNum + 0x3A0090, equipment);
            BitManager.SetByte(data, slotNum + 0x3A00AE, item);
            if (slotNum <= 0x0E)
                BitManager.SetByte(data, slotNum + 0x3A00CC, specialItem);
        }
        public void Clear()
        {
            equipment = 0;
            item = 0;
            specialItem = 0;
        }


    }
}
