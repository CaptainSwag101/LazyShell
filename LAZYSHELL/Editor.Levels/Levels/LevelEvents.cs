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

        private ArrayList events = new ArrayList(); public ArrayList Events { get { return events; } }
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
                    theEvent = (Event)events[value];
                    this.currentEvent = value;
                }
            }
        }
        private int selectedEvent; public int SelectedEvent { get { return this.selectedEvent; } set { selectedEvent = value; } }

        private Event theEvent;
        public Event Event_ { get { return theEvent; } set { theEvent = value; } }

        private int index; public int Index { get { return index; } set { index = value; } }

        public int NumberOfEvents { get { return events.Count; } }
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

        public ushort RunEvent { get { return theEvent.RunEvent; } set { theEvent.RunEvent = value; } }
        public byte X { get { return theEvent.X; } set { theEvent.X = value; } }
        public byte Y { get { return theEvent.Y; } set { theEvent.Y = value; } }
        public byte FieldCoordZ { get { return theEvent.FieldCoordZ; } set { theEvent.FieldCoordZ = value; } }
        public byte FieldHeight { get { return theEvent.FieldHeight; } set { theEvent.FieldHeight = value; } }
        public bool FieldWidthXPlusHalf { get { return theEvent.FieldWidthXPlusHalf; } set { theEvent.FieldWidthXPlusHalf = value; } }
        public bool FieldWidthYPlusHalf { get { return theEvent.FieldWidthYPlusHalf; } set { theEvent.FieldWidthYPlusHalf = value; } }
        public byte FieldWidth { get { return theEvent.FieldWidth; } set { theEvent.FieldWidth = value; } }
        public byte FieldRadialPosition { get { return theEvent.FieldRadialPosition; } set { theEvent.FieldRadialPosition = value; } }

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
                if (tEvent.FieldWidth > 0) offset += 1;
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

            for (int i = 0; i < events.Count; i++)
            {
                this.CurrentEvent = i;
                theEvent.AssembleEvent(data, offset);

                offset += 5;
                if (theEvent.FieldWidth > 0) offset += 1;
            }

            offsetStart = (ushort)(offset - 0x200000);

            return offsetStart;
        }

        [Serializable()]
        public class Event
        {
            private ushort runEvent; public ushort RunEvent { get { return runEvent; } set { runEvent = value; } }
            private byte x; public byte X { get { return x; } set { x = value; } }
            private byte y; public byte Y { get { return y; } set { y = value; } }
            private byte fieldCoordZ; public byte FieldCoordZ { get { return fieldCoordZ; } set { fieldCoordZ = value; } }
            private byte fieldHeight; public byte FieldHeight { get { return fieldHeight; } set { fieldHeight = value; } }
            private bool fieldWidthXPlusHalf; public bool FieldWidthXPlusHalf { get { return fieldWidthXPlusHalf; } set { fieldWidthXPlusHalf = value; } }
            private bool fieldWidthYPlusHalf; public bool FieldWidthYPlusHalf { get { return fieldWidthYPlusHalf; } set { fieldWidthYPlusHalf = value; } }
            private byte fieldWidth; public byte FieldWidth { get { return fieldWidth; } set { fieldWidth = value; } }
            private byte fieldRadialPosition; public byte FieldRadialPosition { get { return fieldRadialPosition; } set { fieldRadialPosition = value; } }

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
                if ((temp & 0x80) == 0x80) fieldWidthXPlusHalf = true;
                x = (byte)(temp & 0x7F); offset++;
                temp = data[offset];
                if ((temp & 0x80) == 0x80) fieldWidthYPlusHalf = true;
                y = (byte)(temp & 0x7F); offset++;
                temp = data[offset]; offset++;
                fieldCoordZ = (byte)(temp & 0x1F);
                fieldHeight = (byte)((temp & 0xF0) >> 5);

                if (lengthOverOne)
                {
                    temp = data[offset];
                    fieldWidth = (byte)(temp & 0x0F);
                    fieldRadialPosition = (byte)((temp & 0x80) >> 7); offset++;
                }
            }
            public void AssembleEvent(byte[] data, int offset)
            {
                Bits.SetShort(data, offset, runEvent); offset++;
                Bits.SetBit(data, offset, 7, fieldWidth > 0); offset++;

                Bits.SetByte(data, offset, x);
                Bits.SetBit(data, offset, 7, fieldWidthXPlusHalf); offset++;
                Bits.SetByte(data, offset, y);
                Bits.SetBit(data, offset, 7, fieldWidthYPlusHalf); offset++;
                Bits.SetByte(data, offset, fieldCoordZ);
                Bits.SetBitsByByte(data, offset, (byte)(fieldHeight << 5), true); offset++;

                if (fieldWidth > 0)
                {
                    Bits.SetByte(data, offset, fieldWidth);
                    Bits.SetBitsByByte(data, offset, (byte)(fieldRadialPosition << 7), true); offset++;
                }
            }
            public Event Copy()
            {
                Event copy = new Event();
                copy.RunEvent = runEvent;
                copy.X = x;
                copy.Y = y;
                copy.FieldCoordZ = fieldCoordZ;
                copy.FieldHeight = fieldHeight;
                copy.FieldRadialPosition = fieldRadialPosition;
                copy.FieldWidth = fieldWidth;
                copy.FieldWidthXPlusHalf = fieldWidthXPlusHalf;
                copy.FieldWidthYPlusHalf = fieldWidthYPlusHalf;
                copy.FieldRadialPosition = fieldRadialPosition;
                return copy;
            }
        }
        public int GetEventLength()
        {
            int length = 5;
            if (FieldWidth > 0)
                length++;
            return length;
        }
    }
}
