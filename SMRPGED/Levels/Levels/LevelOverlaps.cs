using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace SMRPGED
{
    [Serializable()]
    public class LevelOverlaps
    {
        // Local Variables
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

        private Overlap overlap;

        private int levelNum; public int LevelNum { get { return levelNum; } set { levelNum = value; } }

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
            e.CoordX = (byte)p.X;
            e.CoordY = (byte)p.Y;
            if (index < overlaps.Count)
                overlaps.Insert(index, e);
            else
                overlaps.Add(e);
        }

        public byte CoordX { get { return overlap.CoordX; } set { overlap.CoordX = value; } }
        public byte CoordY { get { return overlap.CoordY; } set { overlap.CoordY = value; } }
        public byte CoordZ { get { return overlap.CoordZ; } set { overlap.CoordZ = value; } }
        public byte Type { get { return overlap.Type; } set { overlap.Type = value; } }
        public bool B0b7 { get { return overlap.B0b7; } set { overlap.B0b7 = value; } }
        public bool B1b7 { get { return overlap.B1b7; } set { overlap.B1b7 = value; } }
        public bool B2b5 { get { return overlap.B2b5; } set { overlap.B2b5 = value; } }
        public bool B2b6 { get { return overlap.B2b6; } set { overlap.B2b6 = value; } }
        public bool B2b7 { get { return overlap.B2b7; } set { overlap.B2b7 = value; } }

        public LevelOverlaps(byte[] data, int levelNum)
        {
            this.data = data;
            this.levelNum = levelNum;
            InitializeLevel(data);
        }
        private void InitializeLevel(byte[] data)
        {
            int offset;
            ushort offsetStart = 0;
            ushort offsetEnd = 0;
            Overlap tOverlap;

            int pointerOffset = (levelNum * 2) + 0x1D4905;

            offsetStart = BitManager.GetShort(data, pointerOffset); pointerOffset += 2;
            offsetEnd = BitManager.GetShort(data, pointerOffset);

            if (levelNum == 0x1FF) offsetEnd = 0;

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
            int pointerOffset = (levelNum * 2) + 0x1D4905;

            BitManager.SetShort(data, pointerOffset, offsetStart);

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
            private byte coordX; public byte CoordX { get { return coordX; } set { coordX = value; } }
            private byte coordY; public byte CoordY { get { return coordY; } set { coordY = value; } }
            private byte coordZ; public byte CoordZ { get { return coordZ; } set { coordZ = value; } }
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
                coordX = 0;
                coordY = 0;
                coordZ = 0;
                type = 0;
                b0b7 = false;
                b1b7 = false;
                b2b5 = false;
                b2b6 = false;
                b2b7 = false;
            }

            public void InitializeOverlap(byte[] data, int offset)
            {
                coordX = (byte)(data[offset] & 0x7F);
                b0b7 = (data[offset] & 0x80) == 0x80; offset++;
                coordY = (byte)(data[offset] & 0x7F);
                b1b7 = (data[offset] & 0x80) == 0x80; offset++;
                coordZ = data[offset];
                b2b5 = (data[offset] & 0x20) == 0x20;
                b2b6 = (data[offset] & 0x40) == 0x40;
                b2b7 = (data[offset] & 0x80) == 0x80; offset++;
                type = data[offset];
            }
            public void AssembleOverlap(byte[] data, int offset)
            {
                data[offset] = coordX;
                BitManager.SetBit(data, offset, 7, b0b7); offset++;
                data[offset] = coordY;
                BitManager.SetBit(data, offset, 7, b1b7); offset++;
                data[offset] = coordZ;
                BitManager.SetBit(data, offset, 5, b2b5);
                BitManager.SetBit(data, offset, 6, b2b6);
                BitManager.SetBit(data, offset, 7, b2b7); offset++;
                data[offset] = type;
            }
        }
    }
}
