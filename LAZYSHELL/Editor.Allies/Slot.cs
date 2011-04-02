using System;
using System.Collections.Generic;
using System.Text;

namespace LAZYSHELL
{
    [Serializable()]
    public class Slot : Element
    {
        [NonSerialized()]
        private byte[] data; 
        public override byte[] Data { get { return this.data; } set { this.data = value; } }
        public override int Index { get { return index; } set { index = value; } }
        private int index;

        private byte equipment; public byte Equipment { get { return this.equipment; } set { this.equipment = value; } }
        private byte item; public byte Item { get { return this.item; } set { this.item = value; } }
        private byte specialItem; public byte SpecialItem { get { return this.specialItem; } set { this.specialItem = value; } }

        public Slot(byte[] data, int index)
        {
            this.data = data;
            this.index = index;
            InitializeSlot();
        }

        private void InitializeSlot()
        {
            equipment = data[index + 0x3A0090];
            item = data[index + 0x3A00AE];
            if (index > 0x0E)
                specialItem = data[0x0F + 0x3A00CC];
            else specialItem = data[index + 0x3A00CC];
        }
        public void Assemble()
        {
            Bits.SetByte(data, index + 0x3A0090, equipment);
            Bits.SetByte(data, index + 0x3A00AE, item);
            if (index <= 0x0E)
                Bits.SetByte(data, index + 0x3A00CC, specialItem);
        }
        public override void Clear()
        {
            equipment = 0;
            item = 0;
            specialItem = 0;
        }
    }
}
