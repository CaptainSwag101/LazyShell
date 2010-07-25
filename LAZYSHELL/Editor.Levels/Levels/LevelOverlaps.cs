using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace LAZYSHELL
{
    [Serializable()]
    public class LevelOverlaps
    {
        // Local Variables
        [NonSerialized()]
        private byte[] data; public byte[] Data { get { return this.data; } set { this.data = value; } }

        private ArrayList overlaps = new ArrayList(); public ArrayList Overlaps { get { return overlaps; } }
        private int currentOverlap = 0;
        public int CurrentOverlap
        {
            get
            {
                return this.currentOverlap;
            }
            set
            {
                if (this.overlaps.Count > value)
                {
                    overlap = (Overlap)overlaps[value];
                    this.currentOverlap = value;
                }
            }
        }
        private int selectedOverlap; public int SelectedOverlap { get { return this.selectedOverlap; } set { selectedOverlap = value; } }

        private Overlap overlap; public Overlap Overlap_ { get { return overlap; } }

        private int index; public int Index { get { return index; } set { index = value; } }

        public int NumberOfOverlaps { get { return overlaps.Count; } }
        public void RemoveCurrentOverlap()
        {
            if (currentOverlap < overlaps.Count)
            {
                overlaps.Remove(overlaps[currentOverlap]);
                this.currentOverlap = 0;
            }
        }
        public void Clear()
        {
            overlaps.Clear();
            this.currentOverlap = 0;
        }
        public void AddNewOverlap(int index, Point p)
        {
            Overlap e = new Overlap();
            e.NullOverlap();
            e.X = (byte)p.X;
            e.Y = (byte)p.Y;
            if (index < overlaps.Count)
                overlaps.Insert(index, e);
            else
                overlaps.Add(e);
        }
        public void AddNewOverlap(int index, Overlap copy)
        {
            if (index < overlaps.Count)
                overlaps.Insert(index, copy);
            else
                overlaps.Add(copy);
        }

        public byte X { get { return overlap.X; } set { overlap.X = value; } }
        public byte Y { get { return overlap.Y; } set { overlap.Y = value; } }
        public byte Z { get { return overlap.Z; } set { overlap.Z = value; } }
        public byte Type { get { return overlap.Type; } set { overlap.Type = value; } }
        public bool B0b7 { get { return overlap.B0b7; } set { overlap.B0b7 = value; } }
        public bool B1b7 { get { return overlap.B1b7; } set { overlap.B1b7 = value; } }
        public bool B2b5 { get { return overlap.B2b5; } set { overlap.B2b5 = value; } }
        public bool B2b6 { get { return overlap.B2b6; } set { overlap.B2b6 = value; } }
        public bool B2b7 { get { return overlap.B2b7; } set { overlap.B2b7 = value; } }

        public LevelOverlaps(byte[] data, int index)
        {
            this.data = data;
            this.index = index;
            InitializeLevel(data);
        }
        private void InitializeLevel(byte[] data)
        {
            int offset;
            ushort offsetStart = 0;
            ushort offsetEnd = 0;
            Overlap tOverlap;

            int pointerOffset = (index * 2) + 0x1D4905;

            offsetStart = Bits.GetShort(data, pointerOffset); pointerOffset += 2;
            offsetEnd = Bits.GetShort(data, pointerOffset);

            if (index == 0x1FF) offsetEnd = 0;

            if (offsetStart >= offsetEnd) return; // no overlaps for level

            offset = offsetStart + 0x1D0000;

            while (offset < offsetEnd + 0x1D0000)
            {
                tOverlap = new Overlap();
                tOverlap.InitializeOverlap(data, offset);
                overlaps.Add(tOverlap);

                offset += 4;
            }
        }
        public ushort Assemble(ushort offsetStart)
        {
            int offset = 0;
            int pointerOffset = (index * 2) + 0x1D4905;

            Bits.SetShort(data, pointerOffset, offsetStart);

            offset = offsetStart + 0x1D0000;

            offsetStart = (ushort)(offset - 0x1D0000);

            if (overlaps.Count == 0) return offsetStart; // no exit fields for level

            for (int i = 0; i < overlaps.Count; i++)
            {
                this.CurrentOverlap = i;
                overlap.AssembleOverlap(data, offset);

                offset += 4;
            }

            offsetStart = (ushort)(offset - 0x1D0000);

            return offsetStart;
        }

        [Serializable()]
        public class Overlap
        {
            private byte x; public byte X { get { return x; } set { x = value; } }
            private byte y; public byte Y { get { return y; } set { y = value; } }
            private byte z; public byte Z { get { return z; } set { z = value; } }
            private byte type; public byte Type { get { return type; } set { type = value; } }
            private bool b0b7; public bool B0b7 { get { return b0b7; } set { b0b7 = value; } }
            private bool b1b7; public bool B1b7 { get { return b1b7; } set { b1b7 = value; } }
            private bool b2b5; public bool B2b5 { get { return b2b5; } set { b2b5 = value; } }
            private bool b2b6; public bool B2b6 { get { return b2b6; } set { b2b6 = value; } }
            private bool b2b7; public bool B2b7 { get { return b2b7; } set { b2b7 = value; } }

            public Overlap()
            {

            }
            public void NullOverlap()
            {
                x = 0;
                y = 0;
                z = 0;
                type = 0;
                b0b7 = false;
                b1b7 = false;
                b2b5 = false;
                b2b6 = false;
                b2b7 = false;
            }

            public void InitializeOverlap(byte[] data, int offset)
            {
                x = (byte)(data[offset] & 0x7F);
                b0b7 = (data[offset] & 0x80) == 0x80; offset++;
                y = (byte)(data[offset] & 0x7F);
                b1b7 = (data[offset] & 0x80) == 0x80; offset++;
                z = data[offset];
                b2b5 = (data[offset] & 0x20) == 0x20;
                b2b6 = (data[offset] & 0x40) == 0x40;
                b2b7 = (data[offset] & 0x80) == 0x80; offset++;
                type = data[offset];
            }
            public void AssembleOverlap(byte[] data, int offset)
            {
                data[offset] = x;
                Bits.SetBit(data, offset, 7, b0b7); offset++;
                data[offset] = y;
                Bits.SetBit(data, offset, 7, b1b7); offset++;
                data[offset] = z;
                Bits.SetBit(data, offset, 5, b2b5);
                Bits.SetBit(data, offset, 6, b2b6);
                Bits.SetBit(data, offset, 7, b2b7); offset++;
                data[offset] = type;
            }
            public Overlap Copy()
            {
                Overlap copy = new Overlap();
                copy.B0b7 = b0b7;
                copy.B1b7 = b1b7;
                copy.B2b5 = b2b5;
                copy.B2b6 = b2b6;
                copy.B2b7 = b2b7;
                copy.X = x;
                copy.Y = y;
                copy.Z = z;
                copy.Type = type;
                return copy;
            }
        }
    }
}
