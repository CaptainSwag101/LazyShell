using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace LazyShell.Areas
{
    [Serializable()]
    public class OverlapCollection : IList<Overlap>
    {
        #region Variables

        // ROM buffer
        private byte[] rom
        {
            get { return Model.ROM; }
            set { Model.ROM = value; }
        }
        // Area index
        public int AreaIndex { get; set; }
        // Overlap collection
        public List<Overlap> Overlaps { get; set; }

        #endregion

        // Constructor
        public OverlapCollection(int index)
        {
            this.AreaIndex = index;
            this.Overlaps = new List<Overlap>();
            ReadFromROM();
        }

        #region Methods

        // Read/write ROM
        private void ReadFromROM()
        {
            int pointerOffset = (AreaIndex * 2) + 0x1D4905;
            int offsetStart = Bits.GetShort(rom, pointerOffset);
            int offsetEnd = Bits.GetShort(rom, pointerOffset + 2);
            if (this.AreaIndex == 511)
                offsetEnd = 0;
            if (offsetStart >= offsetEnd)
                return;
            int offset = offsetStart + 0x1D0000;
            while (offset < offsetEnd + 0x1D0000)
            {
                var overlap = new Overlap();
                overlap.ReadFromROM(offset);
                this.Overlaps.Add(overlap);
                offset += 4;
            }
        }
        public void WriteToROM(ref int offsetStart)
        {
            int pointerOffset = (AreaIndex * 2) + 0x1D4905;
            Bits.SetShort(rom, pointerOffset, offsetStart);
            int offset = offsetStart + 0x1D0000;
            offsetStart = (ushort)(offset - 0x1D0000);
            // no exit fields for area
            if (Overlaps.Count == 0)
                return;
            //
            foreach (var overlap in Overlaps)
            {
                overlap.WriteToROM(offset);
                offset += 4;
            }
            offsetStart = (ushort)(offset - 0x1D0000);
        }

        #endregion

        #region Enumeration

        public Overlap this[int index]
        {
            get { return this.Overlaps[index]; }
            set { this.Overlaps[index] = value; }
        }
        public void Add(Overlap value)
        {
            this.Overlaps.Add(value);
        }
        public void Clear()
        {
            Overlaps.Clear();
        }
        public bool Contains(Overlap value)
        {
            foreach (var trigger in Overlaps)
            {
                if (trigger == value)
                    return true;
            }
            return false;
        }
        public void CopyTo(Overlap[] triggers, int arrayIndex)
        {
            Overlaps.CopyTo(triggers, arrayIndex);
        }
        public int Count
        {
            get { return Overlaps.Count; }
        }
        public int IndexOf(Overlap value)
        {
            for (int i = 0; i < Overlaps.Count; i++)
            {
                if (Overlaps[i] == value)
                    return i;
            }
            return -1;
        }
        public void Insert(int index, Overlap value)
        {
            if (index < Overlaps.Count)
                Overlaps.Insert(index, value);
            else
                Overlaps.Add(value);
        }
        public void Insert(int index, Point p)
        {
            var e = new Overlap();
            e.X = (byte)p.X;
            e.Y = (byte)p.Y;
            if (index < Overlaps.Count)
                Overlaps.Insert(index, e);
            else
                Overlaps.Add(e);
        }
        public bool IsReadOnly
        {
            get { return false; }
        }
        public bool Remove(Overlap value)
        {
            for (int i = 0; i < Overlaps.Count; i++)
            {
                if (Overlaps[i] == value)
                {
                    Overlaps.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }
        public void RemoveAt(int index)
        {
            Overlaps.RemoveAt(index);
        }
        // Enumerator
        public IEnumerator<Overlap> GetEnumerator()
        {
            return new OverlapEnumerator(this);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return new OverlapEnumerator(this);
        }

        #endregion
    }
    [Serializable()]
    public class Overlap
    {
        #region Variables

        // ROM buffer
        private byte[] rom
        {
            get { return Model.ROM; }
            set { Model.ROM = value; }
        }
        // Properties
        public byte X { get; set; }
        public byte Y { get; set; }
        public byte Z { get; set; }
        public byte Type { get; set; }
        public bool B0b7 { get; set; }
        public bool B1b7 { get; set; }
        public bool B2b5 { get; set; }
        public bool B2b6 { get; set; }
        public bool B2b7 { get; set; }

        #endregion

        // Constructor
        public Overlap()
        {
        }

        #region Methods

        // Read/write ROM
        public void ReadFromROM(int offset)
        {
            X = (byte)(rom[offset] & 0x7F);
            B0b7 = (rom[offset++] & 0x80) == 0x80;
            Y = (byte)(rom[offset] & 0x7F);
            B1b7 = (rom[offset++] & 0x80) == 0x80;
            Z = rom[offset];
            B2b5 = (rom[offset] & 0x20) == 0x20;
            B2b6 = (rom[offset] & 0x40) == 0x40;
            B2b7 = (rom[offset++] & 0x80) == 0x80;
            Type = rom[offset];
        }
        public void WriteToROM(int offset)
        {
            rom[offset] = X;
            Bits.SetBit(rom, offset++, 7, B0b7);
            rom[offset] = Y;
            Bits.SetBit(rom, offset++, 7, B1b7);
            rom[offset] = Z;
            Bits.SetBit(rom, offset, 5, B2b5);
            Bits.SetBit(rom, offset, 6, B2b6);
            Bits.SetBit(rom, offset++, 7, B2b7);
            rom[offset] = Type;
        }
        // Spawning
        public Overlap Copy()
        {
            Overlap copy = new Overlap();
            copy.B0b7 = B0b7;
            copy.B1b7 = B1b7;
            copy.B2b5 = B2b5;
            copy.B2b6 = B2b6;
            copy.B2b7 = B2b7;
            copy.X = X;
            copy.Y = Y;
            copy.Z = Z;
            copy.Type = Type;
            return copy;
        }
        // Inherited
        public void Clear()
        {
            X = 0;
            Y = 0;
            Z = 0;
            Type = 0;
            B0b7 = false;
            B1b7 = false;
            B2b5 = false;
            B2b6 = false;
            B2b7 = false;
        }

        #endregion
    }
    public class OverlapEnumerator : IEnumerator<Overlap>
    {
        private OverlapCollection collection;
        private Overlap currentOverlap;
        private int currentIndex;
        public OverlapEnumerator(OverlapCollection collection)
        {
            this.collection = collection;
            this.currentOverlap = default(Overlap);
            this.currentIndex = -1;
        }
        public Overlap Current
        {
            get { return currentOverlap; }
        }
        object IEnumerator.Current
        {
            get { return Current; }
        }
        void IDisposable.Dispose() { }
        public bool MoveNext()
        {
            //Avoids going beyond the end of the collection. 
            if (++currentIndex >= collection.Count)
            {
                return false;
            }
            else
            {
                // Set current box to next item in collection.
                currentOverlap = collection[currentIndex];
            }
            return true;
        }
        public void Reset()
        {
            currentIndex = -1;
        }
    }
}
