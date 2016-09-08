using System;
using System.Collections.Generic;
using System.Collections;
using System.Drawing;
using System.Text;

namespace LazyShell.Areas
{
    /// <summary>
    /// Class for managing an area's event trigger collection.
    /// </summary>
    [Serializable()]
    public class EventTriggerCollection : IList<EventTrigger>
    {
        #region Variables

        // ROM buffer
        private byte[] rom
        {
            get { return Model.ROM; }
            set { Model.ROM = value; }
        }
        /// <summary>
        /// Index of the event trigger collection's area.
        /// </summary>
        public int AreaIndex { get; set; }
        /// <summary>
        /// The event triggers in the collection.
        /// </summary>
        public List<EventTrigger> Triggers { get; set; }
        /// <summary>
        /// The music (SPC track) that automatically starts playing when the area is loaded in-game.
        /// </summary>
        public byte StartMusic { get; set; }
        /// <summary>
        /// The event script that automatically runs when the area is loaded in-game.
        /// </summary>
        public ushort StartEvent { get; set; }

        #endregion

        // Constructor
        public EventTriggerCollection(int areaIndex)
        {
            this.AreaIndex = areaIndex;
            this.Triggers = new List<EventTrigger>();
            ReadFromROM();
        }

        #region Methods

        /// <summary>
        /// Builds the event trigger collection from it's data in the global ROM buffer.
        /// </summary>
        private void ReadFromROM()
        {
            int pointerOffset = (AreaIndex * 2) + 0x20E000;
            int offsetStart = Bits.GetShort(rom, pointerOffset);
            int offsetEnd = Bits.GetShort(rom, pointerOffset + 2);
            if (AreaIndex == 511) // The last area
                offsetEnd = 0;
            if (offsetStart >= offsetEnd) // No event triggers for area
                return;
            //
            int offset = offsetStart + 0x200000;
            StartMusic = rom[offset++];
            StartEvent = Bits.GetShort(rom, offset); offset += 2;
            // Start building the collection
            while (offset < offsetEnd + 0x200000)
            {
                var trigger = new EventTrigger();
                trigger.ReadFromROM(offset);
                this.Triggers.Add(trigger);
                offset += 5;
                if (trigger.Width > 0) // Widths greater than one isometric unit require an extra byte
                    offset += 1;
            }
        }
        /// <summary>
        /// Writes the properties of all event triggers in the collection to the global ROM buffer.
        /// </summary>
        /// <param name="offsetStart">The offset to begin writing to.</param>
        public void WriteToROM(ref int offsetStart)
        {
            int pointerOffset = (AreaIndex * 2) + 0x20E000;
            Bits.SetShort(rom, pointerOffset, offsetStart);
            int offset = offsetStart + 0x200000;
            rom[offset++] = StartMusic;
            Bits.SetShort(rom, offset, StartEvent); offset += 2;
            offsetStart = (ushort)(offset - 0x200000);
            // no exit fields for area
            if (Triggers.Count == 0)
                return;
            //
            foreach (var trigger in Triggers)
            {
                trigger.WriteToROM(offset);
                offset += 5;
                if (trigger.Width > 0)
                    offset++;
            }
            offsetStart = (ushort)(offset - 0x200000);
        }

        #endregion

        #region Enumeration

        public EventTrigger this[int index]
        {
            get { return this.Triggers[index]; }
            set { this.Triggers[index] = value; }
        }
        public void Add(EventTrigger value)
        {
            this.Triggers.Add(value);
        }
        public void Clear()
        {
            Triggers.Clear();
        }
        public bool Contains(EventTrigger value)
        {
            foreach (var trigger in Triggers)
            {
                if (trigger == value)
                    return true;
            }
            return false;
        }
        public void CopyTo(EventTrigger[] triggers, int arrayIndex)
        {
            Triggers.CopyTo(triggers, arrayIndex);
        }
        public int Count
        {
            get { return Triggers.Count; }
        }
        public int IndexOf(EventTrigger value)
        {
            for (int i = 0; i < Triggers.Count; i++)
            {
                if (Triggers[i] == value)
                    return i;
            }
            return -1;
        }
        public void Insert(int index, EventTrigger value)
        {
            if (index < Triggers.Count)
                Triggers.Insert(index, value);
            else
                Triggers.Add(value);
        }
        public void Insert(int index, Point p)
        {
            var e = new EventTrigger();
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
        public bool Remove(EventTrigger value)
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
        public IEnumerator<EventTrigger> GetEnumerator()
        {
            return new EventTriggerEnumerator(this);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return new EventTriggerEnumerator(this);
        }

        #endregion
    }
    [Serializable()]
    public class EventTrigger
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
                int size = 5;
                if (Width > 0)
                    size++;
                return size;
            }
        }
        // Properties
        /// <summary>
        /// The event script associated with the trigger.
        /// </summary>
        public ushort RunEvent { get; set; }
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
        /// The isometric F coord, or facing direction, of the trigger.
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

        #endregion 

        // Constructor
        public EventTrigger()
        {
        }

        #region Methods

        /// <summary>
        ///  Reads all of the trigger's properties from the global ROM buffer.
        /// </summary>
        /// <param name="offset">The offset to begin reading from.</param>
        public void ReadFromROM(int offset)
        {
            RunEvent = (ushort)(Bits.GetShort(rom, offset++) & 0x0FFF);
            byte temp = rom[offset++];
            bool lengthOverOne = (temp & 0x80) == 0x80;
            //
            temp = rom[offset++];
            if ((temp & 0x80) == 0x80)
                EnableEdgeX = true;
            X = (byte)(temp & 0x7F);
            temp = rom[offset++];
            if ((temp & 0x80) == 0x80)
                EnableEdgeY = true;
            Y = (byte)(temp & 0x7F);
            temp = rom[offset++];
            Z = (byte)(temp & 0x1F);
            Height = (byte)((temp & 0xF0) >> 5);
            //
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
            Bits.SetShort(rom, offset, RunEvent); offset++;
            Bits.SetBit(rom, offset, 7, Width > 0); offset++;
            rom[offset] = X;
            Bits.SetBit(rom, offset, 7, EnableEdgeX); offset++;
            rom[offset] = Y;
            Bits.SetBit(rom, offset, 7, EnableEdgeY); offset++;
            rom[offset] = Z;
            Bits.SetBitsByByte(rom, offset, (byte)(Height << 5), true); offset++;
            if (Width > 0)
            {
                rom[offset] = Width;
                Bits.SetBitsByByte(rom, offset, (byte)(F << 7), true); offset++;
            }
        }
        /// <summary>
        /// Creates a deep copy of the current instance.
        /// </summary>
        /// <returns></returns>
        public EventTrigger Copy()
        {
            EventTrigger copy = new EventTrigger();
            copy.RunEvent = RunEvent;
            copy.X = X;
            copy.Y = Y;
            copy.Z = Z;
            copy.F = F;
            copy.Width = Width;
            copy.Height = Height;
            copy.EnableEdgeX = EnableEdgeX;
            copy.EnableEdgeY = EnableEdgeY;
            return copy;
        }

        #endregion
    }
    public class EventTriggerEnumerator : IEnumerator<EventTrigger>
    {
        private EventTriggerCollection collection;
        private EventTrigger currentEvent;
        private int currentIndex;
        public EventTriggerEnumerator(EventTriggerCollection collection)
        {
            this.collection = collection;
            this.currentEvent = default(EventTrigger);
            this.currentIndex = -1;
        }
        public EventTrigger Current
        {
            get { return currentEvent; }
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
                currentEvent = collection[currentIndex];
            }
            return true;
        }
        public void Reset()
        {
            currentIndex = -1;
        }
    }
}
