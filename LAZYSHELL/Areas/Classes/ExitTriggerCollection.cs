using System;
using System.Collections.Generic;
using System.Collections;
using System.Drawing;
using System.Text;

namespace LAZYSHELL.Areas
{
    /// <summary>
    /// Class for managing an area's exit trigger collection.
    /// </summary>
    [Serializable()]
    public class ExitTriggerCollection : IList<ExitTrigger>
    {
        #region Variables

        // ROM buffer
        private byte[] rom
        {
            get { return Model.ROM; }
            set { Model.ROM = value; }
        }
        /// <summary>
        /// Index of the exit trigger collection's area.
        /// </summary>
        public int AreaIndex { get; set; }
        /// <summary>
        /// The exit triggers in the collection.
        /// </summary>
        public List<ExitTrigger> Triggers { get; set; }

        #endregion

        // Constructor
        public ExitTriggerCollection(int index)
        {
            this.AreaIndex = index;
            this.Triggers = new List<ExitTrigger>();
            ReadFromROM();
        }
        public ExitTriggerCollection() { }

        #region Methods

        /// <summary>
        /// Builds the exit trigger collection from it's data in the global ROM buffer.
        /// </summary>
        private void ReadFromROM()
        {
            int pointerOffset = (AreaIndex * 2) + 0x1D2D64;
            ushort offsetStart = Bits.GetShort(rom, pointerOffset);
            ushort offsetEnd = Bits.GetShort(rom, pointerOffset + 2);
            if (AreaIndex == 0x1FF)
                offsetEnd = 0;
            // no exit fields for area
            if (offsetStart >= offsetEnd)
                return;
            int offset = offsetStart + 0x1D0000;
            while (offset < offsetEnd + 0x1D0000)
            {
                var tExit = new ExitTrigger();
                tExit.ReadFromROM(offset);
                Triggers.Add(tExit);
                offset += 5;
                if (tExit.ExitType == 0)
                    offset += 3;
                if (tExit.Width > 0)
                    offset += 1;
            }
        }
        /// <summary>
        /// Writes the properties of all exit triggers in the collection to the global ROM buffer.
        /// </summary>
        /// <param name="offsetStart">The offset to begin writing to.</param>
        public void WriteToROM(ref int offsetStart)
        {
            int offset = 0;
            int pointerOffset = (AreaIndex * 2) + 0x1D2D64;
            // set the new pointer for the fields
            Bits.SetShort(rom, pointerOffset, offsetStart);
            // no exit fields for area
            if (Triggers.Count == 0)
                return;
            offset = offsetStart + 0x1D0000;
            foreach (var exit in Triggers)
            {
                exit.WriteToROM(offset);
                offset += 5;
                if (exit.ExitType == 0) offset += 3;
                if (exit.Width > 0) offset += 1;
            }
            offsetStart = (ushort)(offset - 0x1D0000);
        }

        #endregion

        #region Enumeration

        // Collection members
        public ExitTrigger this[int index]
        {
            get { return this.Triggers[index]; }
            set { this.Triggers[index] = value; }
        }
        public void Add(ExitTrigger value)
        {
            this.Triggers.Add(value);
        }
        public void Clear()
        {
            Triggers.Clear();
        }
        public bool Contains(ExitTrigger value)
        {
            foreach (var eventField in Triggers)
            {
                if (eventField == value)
                    return true;
            }
            return false;
        }
        public void CopyTo(ExitTrigger[] triggers, int arrayIndex)
        {
            Triggers.CopyTo(triggers, arrayIndex);
        }
        public int Count
        {
            get { return Triggers.Count; }
        }
        public int IndexOf(ExitTrigger value)
        {
            for (int i = 0; i < Triggers.Count; i++)
            {
                if (Triggers[i] == value)
                    return i;
            }
            return -1;
        }
        public void Insert(int index, ExitTrigger value)
        {
            if (index < Triggers.Count)
                Triggers.Insert(index, value);
            else
                Triggers.Add(value);
        }
        public void Insert(int index, Point p)
        {
            var e = new ExitTrigger();
            e.X = (byte)p.X;
            e.Y = (byte)p.Y;
            if (index < Triggers.Count)
                Triggers.Insert(index, e);
            else
                Triggers.Add(e);
        }
        public bool IsReadOnly
        {
            get { return false; }
        }
        public bool Remove(ExitTrigger value)
        {
            for (int i = 0; i < Triggers.Count; i++)
            {
                if (Triggers[i] == value)
                {
                    Triggers.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }
        public void RemoveAt(int index)
        {
            Triggers.RemoveAt(index);
        }
        // Enumerator
        public IEnumerator<ExitTrigger> GetEnumerator()
        {
            return new ExitEnumerator(this);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return new ExitEnumerator(this);
        }

        #endregion
    }
    [Serializable()]
    public class ExitTrigger
    {
        #region Variables

        // ROM buffer
        private byte[] rom
        {
            get { return Model.ROM; }
            set { Model.ROM = value; }
        }
        /// <summary>
        /// The size of the trigger data, in bytes.
        /// </summary>
        public int Size
        {
            get
            {
                int length = 5;
                if (ExitType == 0)
                    length += 3;
                if (Width > 0)
                    length++;
                return length;
            }
        }
        /// <summary>
        /// The area loaded in-game when the trigger is activated on the tilemap.
        /// </summary>
        public ushort Destination { get; set; }
        public byte ExitType { get; set; }
        public bool ShowBanner { get; set; }
        /// <summary>
        /// The isometric X coord of the trigger on the tilemap.
        /// </summary>
        public byte X { get; set; }
        /// <summary>
        /// The isometric Y coord of the trigger on the tilemap.
        /// </summary>
        public byte Y { get; set; }
        /// <summary>
        /// The isometric Z coord of the trigger on the tilemap.
        /// </summary>
        public byte Z { get; set; }
        /// <summary>
        /// The isometric F coord, or facing direction, of the trigger on the tilemap.
        /// </summary>
        public byte F { get; set; }
        /// <summary>
        /// The isometric width of the trigger.
        /// </summary>
        public byte Width { get; set; }
        /// <summary>
        /// The isometric height of the trigger.
        /// </summary>
        public byte Height { get; set; }
        /// <summary>
        /// The NE and SW edges on the trigger are active.
        /// </summary>
        public bool EnableEdgeX { get; set; }
        /// <summary>
        /// The NW and SE edges on the trigger are active.
        /// </summary>
        public bool EnableEdgeY { get; set; }
        /// <summary>
        /// The initial isometric X coord of the player-controlled 
        /// Mario sprite when the destination area is loaded in-game.
        /// </summary>
        public byte DstX { get; set; }
        /// <summary>
        /// The initial isometric Y coord of the player-controlled 
        /// Mario sprite when the destination area is loaded in-game.
        /// </summary>
        public byte DstY { get; set; }
        /// <summary>
        /// The initial isometric Z coord of the player-controlled 
        /// Mario sprite when the destination area is loaded in-game.
        /// </summary>
        public byte DstZ { get; set; }
        /// <summary>
        /// The initial isometric F coord, or facing direction, of the player-controlled 
        /// Mario sprite when the destination area is loaded in-game.
        /// </summary>
        public byte DstF { get; set; }
        public bool DstXb7 { get; set; }
        public bool DstYb7 { get; set; }

        #endregion

        #region Methods

        /// <summary>
        ///  Reads all of the trigger's properties from the global ROM buffer.
        /// </summary>
        /// <param name="offset">The offset to begin reading from.</param>
        public void ReadFromROM(int offset)
        {
            byte temp = 0;
            Destination = (ushort)(Bits.GetShort(rom, offset++) & 0x01FF);
            temp = rom[offset++];
            ShowBanner = (temp & 0x08) == 0x08;
            ExitType = (byte)((temp & 0x60) >> 6);
            bool lengthOverOne = (temp & 0x80) == 0x80;
            //
            temp = rom[offset++];
            EnableEdgeX = (temp & 0x80) == 0x80;
            X = (byte)(temp & 0x7F);
            temp = rom[offset++];
            EnableEdgeY = (temp & 0x80) == 0x80;
            Y = (byte)(temp & 0x7F);
            temp = rom[offset++];
            Z = (byte)(temp & 0x1F);
            Height = (byte)((temp & 0xF0) >> 5);
            //
            if (ExitType == 0)
            {
                temp = rom[offset++];
                DstX = (byte)(temp & 0x7F);
                DstXb7 = (temp & 0x80) == 0x80;
                temp = rom[offset++];
                DstY = (byte)(temp & 0x7F);
                DstYb7 = (temp & 0x80) == 0x80;
                temp = rom[offset++];
                DstZ = (byte)(temp & 0x1F);
                DstF = (byte)((temp & 0xF0) >> 5);
            }
            else if (ExitType == 1)
                Destination &= 0xFF;
            if (lengthOverOne)
            {
                temp = rom[offset++];
                Width = (byte)(temp & 0x0F);
                F = (byte)((temp & 0x80) >> 7);
            }
        }
        /// <summary>
        /// Writes all of the trigger's properties to the global ROM buffer.
        /// </summary>
        /// <param name="offset">The offset to begin writing to.</param>
        public void WriteToROM(int offset)
        {
            Bits.SetShort(rom, offset++, Destination);
            Bits.SetBit(rom, offset, 3, ShowBanner);
            if (ExitType == 0)
                Bits.SetBit(rom, offset, 5, true);
            else if (ExitType == 1)
                Bits.SetBit(rom, offset, 6, true);
            Bits.SetBit(rom, offset++, 7, Width > 0);
            rom[offset] = X;
            Bits.SetBit(rom, offset++, 7, EnableEdgeX);
            rom[offset] = Y;
            Bits.SetBit(rom, offset++, 7, EnableEdgeY);
            rom[offset] = Z;
            Bits.SetBitsByByte(rom, offset++, (byte)(Height << 5), true);
            if (ExitType == 0)
            {
                rom[offset] = DstX;
                Bits.SetBit(rom, offset++, 7, DstXb7);
                rom[offset] = DstY;
                Bits.SetBit(rom, offset++, 7, DstYb7);
                rom[offset] = DstZ;
                Bits.SetBitsByByte(rom, offset++, (byte)(DstF << 5), true);
            }
            if (Width > 0)
            {
                rom[offset] = Width;
                Bits.SetBitsByByte(rom, offset++, (byte)(F << 7), true);
            }
        }

        /// <summary>
        /// Creates a deep copy of this instance.
        /// </summary>
        /// <returns></returns>
        public ExitTrigger Copy()
        {
            ExitTrigger copy = new ExitTrigger();
            copy.Destination = Destination;
            copy.ExitType = ExitType;
            copy.ShowBanner = ShowBanner;
            copy.X = X;
            copy.Y = Y;
            copy.Z = Z;
            copy.Height = Height;
            copy.EnableEdgeX = EnableEdgeX;
            copy.EnableEdgeY = EnableEdgeY;
            copy.DstX = DstX;
            copy.DstY = DstY;
            copy.DstZ = DstZ;
            copy.DstF = DstF;
            copy.DstXb7 = DstXb7;
            copy.DstYb7 = DstYb7;
            copy.Width = Width;
            copy.F = F;
            return copy;
        }

        #endregion
    }
    public class ExitEnumerator : IEnumerator<ExitTrigger>
    {
        private ExitTriggerCollection collection;
        private ExitTrigger currentExit;
        private int currentIndex;
        public ExitEnumerator(ExitTriggerCollection collection)
        {
            this.collection = collection;
            this.currentExit = default(ExitTrigger);
            this.currentIndex = -1;
        }
        public ExitTrigger Current
        {
            get { return currentExit; }
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
                currentExit = collection[currentIndex];
            }
            return true;
        }
        public void Reset()
        {
            currentIndex = -1;
        }
    }
}
