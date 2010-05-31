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

        private int levelNum; public int LevelNum { get { return levelNum; } set { levelNum = value; } }

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
            e.NullEvent();
            e.FieldCoordX = (byte)p.X;
            e.FieldCoordY = (byte)p.Y;
            if (index < events.Count)
                events.Insert(index, e);
            else
                events.Add(e);
        }

        // these two do not belong to a specific event, they belong to the level
        private byte music; public byte Music { get { return music; } set { music = value; } }
        private ushort exitEvent; public ushort ExitEvent { get { return exitEvent; } set { exitEvent = value; } }

        public ushort RunEvent { get { return theEvent.RunEvent; } set { theEvent.RunEvent = value; } }
        public bool LengthOverOne { get { return theEvent.LengthOverOne; } set { theEvent.LengthOverOne = value; } }
        public byte FieldCoordX { get { return theEvent.FieldCoordX; } set { theEvent.FieldCoordX = value; } }
        public byte FieldCoordY { get { return theEvent.FieldCoordY; } set { theEvent.FieldCoordY = value; } }
        public byte FieldCoordZ { get { return theEvent.FieldCoordZ; } set { theEvent.FieldCoordZ = value; } }
        public byte FieldHeight { get { return theEvent.FieldHeight; } set { theEvent.FieldHeight = value; } }
        public bool FieldWidthXPlusHalf { get { return theEvent.FieldWidthXPlusHalf; } set { theEvent.FieldWidthXPlusHalf = value; } }
        public bool FieldWidthYPlusHalf { get { return theEvent.FieldWidthYPlusHalf; } set { theEvent.FieldWidthYPlusHalf = value; } }
        public byte FieldWidth { get { return theEvent.FieldWidth; } set { theEvent.FieldWidth = value; } }
        public byte FieldRadialPosition { get { return theEvent.FieldRadialPosition; } set { theEvent.FieldRadialPosition = value; } }

        public LevelEvents(byte[] data, int levelNum)
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
            Event tEvent;

            int pointerOffset = (levelNum * 2) + 0x20E000;

            offsetStart = BitManager.GetShort(data, pointerOffset); pointerOffset += 2;
            offsetEnd = BitManager.GetShort(data, pointerOffset);

            if (levelNum == 0x1FF) offsetEnd = 0;

            if (offsetStart >= offsetEnd) return; // no event fields for level

            offset = offsetStart + 0x200000;

            music = BitManager.GetByte(data, offset); offset++;
            exitEvent = BitManager.GetShort(data, offset); offset += 2;

            while (offset < offsetEnd + 0x200000)
            {
                tEvent = new Event();
                tEvent.InitializeEvent(data, offset);
                events.Add(tEvent);

                offset += 5;
                if (tEvent.LengthOverOne) offset += 1;
            }
        }
        public ushort Assemble(ushort offsetStart)
        {
            int offset = 0;
            int pointerOffset = (levelNum * 2) + 0x20E000;

            BitManager.SetShort(data, pointerOffset, offsetStart);

            offset = offsetStart + 0x200000;

            BitManager.SetByte(data, offset, music); offset++;
            BitManager.SetShort(data, offset, exitEvent); offset += 2;

            offsetStart = (ushort)(offset - 0x200000);

            if (events.Count == 0) return offsetStart; // no exit fields for level

            for (int i = 0; i < events.Count; i++)
            {
                this.CurrentEvent = i;
                theEvent.AssembleEvent(data, offset);

                offset += 5;
                if (theEvent.LengthOverOne) offset += 1;
            }

            offsetStart = (ushort)(offset - 0x200000);

            return offsetStart;
        }

        [Serializable()]
        public class Event
        {
            private ushort runEvent; public ushort RunEvent { get { return runEvent; } set { runEvent = value; } }
            private bool lengthOverOne; public bool LengthOverOne { get { return lengthOverOne; } set { lengthOverOne = value; } }
            private byte fieldCoordX; public byte FieldCoordX { get { return fieldCoordX; } set { fieldCoordX = value; } }
            private byte fieldCoordY; public byte FieldCoordY { get { return fieldCoordY; } set { fieldCoordY = value; } }
            private byte fieldCoordZ; public byte FieldCoordZ { get { return fieldCoordZ; } set { fieldCoordZ = value; } }
            private byte fieldHeight; public byte FieldHeight { get { return fieldHeight; } set { fieldHeight = value; } }
            private bool fieldWidthXPlusHalf; public bool FieldWidthXPlusHalf { get { return fieldWidthXPlusHalf; } set { fieldWidthXPlusHalf = value; } }
            private bool fieldWidthYPlusHalf; public bool FieldWidthYPlusHalf { get { return fieldWidthYPlusHalf; } set { fieldWidthYPlusHalf = value; } }
            private byte fieldWidth; public byte FieldWidth { get { return fieldWidth; } set { fieldWidth = value; } }
            private byte fieldRadialPosition; public byte FieldRadialPosition { get { return fieldRadialPosition; } set { fieldRadialPosition = value; } }

            public Event()
            {

            }
            public void NullEvent()
            {
                runEvent = 0;
                lengthOverOne = false;
                fieldCoordX = 0;
                fieldCoordY = 0;
                fieldCoordZ = 0;
                fieldHeight = 0;
                fieldWidth = 0;
                fieldRadialPosition = 0;
            }

            public void InitializeEvent(byte[] data, int offset)
            {
                byte temp = 0;

                runEvent = (ushort)(BitManager.GetShort(data, offset) & 0x0FFF); offset++;
                temp = BitManager.GetByte(data, offset); offset++;
                if ((temp & 0x80) == 0x80) lengthOverOne = true;

                temp = BitManager.GetByte(data, offset);
                if ((temp & 0x80) == 0x80) fieldWidthXPlusHalf = true;
                fieldCoordX = (byte)(temp & 0x7F); offset++;
                temp = BitManager.GetByte(data, offset);
                if ((temp & 0x80) == 0x80) fieldWidthYPlusHalf = true;
                fieldCoordY = (byte)(temp & 0x7F); offset++;
                temp = BitManager.GetByte(data, offset); offset++;
                fieldCoordZ = (byte)(temp & 0x1F);
                fieldHeight = (byte)((temp & 0xF0) >> 5);

                if (lengthOverOne)
                {
                    temp = BitManager.GetByte(data, offset);
                    fieldWidth = (byte)(temp & 0x0F);
                    fieldRadialPosition = (byte)((temp & 0x80) >> 7); offset++;
                }
            }
            public void AssembleEvent(byte[] data, int offset)
            {
                BitManager.SetShort(data, offset, runEvent); offset++;
                BitManager.SetBit(data, offset, 7, lengthOverOne); offset++;

                BitManager.SetByte(data, offset, fieldCoordX);
                BitManager.SetBit(data, offset, 7, fieldWidthXPlusHalf); offset++;
                BitManager.SetByte(data, offset, fieldCoordY);
                BitManager.SetBit(data, offset, 7, fieldWidthYPlusHalf); offset++;
                BitManager.SetByte(data, offset, fieldCoordZ);
                BitManager.SetBitsByByte(data, offset, (byte)(fieldHeight << 5), true); offset++;

                if (lengthOverOne)
                {
                    BitManager.SetByte(data, offset, fieldWidth);
                    BitManager.SetBitsByByte(data, offset, (byte)(fieldRadialPosition << 7), true); offset++;
                }
            }
        }
        public int GetEventLength()
        {
            int length = 5;
            if (LengthOverOne)
                length++;
            return length;
        }
    }
}
