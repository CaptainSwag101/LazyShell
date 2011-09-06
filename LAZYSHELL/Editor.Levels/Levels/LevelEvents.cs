using System;
using System.Collections.Generic;
using System.Collections;
using System.Drawing;
using System.Text;

namespace LAZYSHELL
{
    [Serializable()]
    public class LevelEvents
    {
        // Local Variables
        [NonSerialized()]
        private byte[] data; public byte[] Data { get { return this.data; } set { this.data = value; } }

        private List<Event> events = new List<Event>(); public List<Event> Events { get { return events; } }
        private int currentEvent = 0;
        public int CurrentEvent
        {
            get
            {
                return this.currentEvent;
            }
            set
            {
                if (this.events.Count > value)
                {
                    event_ = events[value];
                    this.currentEvent = value;
                }
            }
        }
        private int selectedEvent; public int SelectedEvent { get { return this.selectedEvent; } set { selectedEvent = value; } }

        private Event event_;
        public Event Event_ { get { return event_; } set { event_ = value; } }

        private int index; public int Index { get { return index; } set { index = value; } }

        public int Count { get { return events.Count; } }
        public void RemoveCurrentEvent()
        {
            if (currentEvent < events.Count)
            {
                events.Remove(events[currentEvent]);
                this.currentEvent = 0;
            }
        }
        public void Clear()
        {
            events.Clear();
            this.currentEvent = 0;
        }
        public void AddNewEvent(int index, Point p)
        {
            Event e = new Event();
            e.X = (byte)p.X;
            e.Y = (byte)p.Y;
            if (index < events.Count)
                events.Insert(index, e);
            else
                events.Add(e);
        }
        public void AddNewEvent(int index, Event copy)
        {
            if (index < events.Count)
                events.Insert(index, copy);
            else
                events.Add(copy);
        }

        // these two do not belong to a specific event, they belong to the level
        private byte music; public byte Music { get { return music; } set { music = value; } }
        private ushort exitEvent; public ushort ExitEvent { get { return exitEvent; } set { exitEvent = value; } }

        public ushort RunEvent { get { return event_.RunEvent; } set { event_.RunEvent = value; } }
        public byte X { get { return event_.X; } set { event_.X = value; } }
        public byte Y { get { return event_.Y; } set { event_.Y = value; } }
        public byte Z { get { return event_.Z; } set { event_.Z = value; } }
        public byte Height { get { return event_.Height; } set { event_.Height = value; } }
        public bool WidthXPlusHalf { get { return event_.WidthXPlusHalf; } set { event_.WidthXPlusHalf = value; } }
        public bool WidthYPlusHalf { get { return event_.WidthYPlusHalf; } set { event_.WidthYPlusHalf = value; } }
        public byte Width { get { return event_.Width; } set { event_.Width = value; } }
        public byte Facing { get { return event_.Face; } set { event_.Face = value; } }

        public LevelEvents(byte[] data, int index)
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
            Event tEvent;

            int pointerOffset = (index * 2) + 0x20E000;

            offsetStart = Bits.GetShort(data, pointerOffset); pointerOffset += 2;
            offsetEnd = Bits.GetShort(data, pointerOffset);

            if (index == 0x1FF) offsetEnd = 0;

            if (offsetStart >= offsetEnd) return; // no event fields for level

            offset = offsetStart + 0x200000;

            music = data[offset]; offset++;
            exitEvent = Bits.GetShort(data, offset); offset += 2;

            while (offset < offsetEnd + 0x200000)
            {
                tEvent = new Event();
                tEvent.InitializeEvent(data, offset);
                events.Add(tEvent);

                offset += 5;
                if (tEvent.Width > 0) offset += 1;
            }
        }
        public ushort Assemble(ushort offsetStart)
        {
            int offset = 0;
            int pointerOffset = (index * 2) + 0x20E000;

            Bits.SetShort(data, pointerOffset, offsetStart);

            offset = offsetStart + 0x200000;

            Bits.SetByte(data, offset, music); offset++;
            Bits.SetShort(data, offset, exitEvent); offset += 2;

            offsetStart = (ushort)(offset - 0x200000);

            if (events.Count == 0) return offsetStart; // no exit fields for level

            foreach (Event event_ in events)
            {
                event_.AssembleEvent(data, offset);
                offset += 5;
                if (event_.Width > 0) offset += 1;
            }

            offsetStart = (ushort)(offset - 0x200000);

            return offsetStart;
        }
        public int GetEventLength()
        {
            int length = 5;
            if (Width > 0)
                length++;
            return length;
        }
    }
    [Serializable()]
    public class Event
    {
        private ushort runEvent; public ushort RunEvent { get { return runEvent; } set { runEvent = value; } }
        private byte x; public byte X { get { return x; } set { x = value; } }
        private byte y; public byte Y { get { return y; } set { y = value; } }
        private byte z; public byte Z { get { return z; } set { z = value; } }
        private byte height; public byte Height { get { return height; } set { height = value; } }
        private bool widthXPlusHalf; public bool WidthXPlusHalf { get { return widthXPlusHalf; } set { widthXPlusHalf = value; } }
        private bool widthYPlusHalf; public bool WidthYPlusHalf { get { return widthYPlusHalf; } set { widthYPlusHalf = value; } }
        private byte width; public byte Width { get { return width; } set { width = value; } }
        private byte facing; public byte Face { get { return facing; } set { facing = value; } }
        public int Index = 0;
        public bool Hilite = false;

        public Event()
        {

        }

        public void InitializeEvent(byte[] data, int offset)
        {
            byte temp = 0;

            runEvent = (ushort)(Bits.GetShort(data, offset) & 0x0FFF); offset++;
            temp = data[offset]; offset++;
            bool lengthOverOne = (temp & 0x80) == 0x80;

            temp = data[offset];
            if ((temp & 0x80) == 0x80) widthXPlusHalf = true;
            x = (byte)(temp & 0x7F); offset++;
            temp = data[offset];
            if ((temp & 0x80) == 0x80) widthYPlusHalf = true;
            y = (byte)(temp & 0x7F); offset++;
            temp = data[offset]; offset++;
            z = (byte)(temp & 0x1F);
            height = (byte)((temp & 0xF0) >> 5);

            if (lengthOverOne)
            {
                temp = data[offset];
                width = (byte)(temp & 0x0F);
                facing = (byte)((temp & 0x80) >> 7); offset++;
            }
        }
        public void AssembleEvent(byte[] data, int offset)
        {
            Bits.SetShort(data, offset, runEvent); offset++;
            Bits.SetBit(data, offset, 7, width > 0); offset++;

            Bits.SetByte(data, offset, x);
            Bits.SetBit(data, offset, 7, widthXPlusHalf); offset++;
            Bits.SetByte(data, offset, y);
            Bits.SetBit(data, offset, 7, widthYPlusHalf); offset++;
            Bits.SetByte(data, offset, z);
            Bits.SetBitsByByte(data, offset, (byte)(height << 5), true); offset++;

            if (width > 0)
            {
                Bits.SetByte(data, offset, width);
                Bits.SetBitsByByte(data, offset, (byte)(facing << 7), true); offset++;
            }
        }
        public Event Copy()
        {
            Event copy = new Event();
            copy.RunEvent = runEvent;
            copy.X = x;
            copy.Y = y;
            copy.Z = z;
            copy.Height = height;
            copy.Face = facing;
            copy.Width = width;
            copy.WidthXPlusHalf = widthXPlusHalf;
            copy.WidthYPlusHalf = widthYPlusHalf;
            copy.Face = facing;
            return copy;
        }
        public int GetEventLength()
        {
            int length = 5;
            if (width > 0)
                length++;
            return length;
        }
    }
}
