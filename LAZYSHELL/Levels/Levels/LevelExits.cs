using System;
using System.Collections.Generic;
using System.Collections;
using System.Drawing;
using System.Text;

namespace LAZYSHELL
{
    [Serializable()]
    public class LevelExits
    {
        // Local Variables
        private byte[] data; public byte[] Data { get { return this.data; } set { this.data = value; } }

        private ArrayList exits = new ArrayList(); public ArrayList Exits { get { return exits; } }
        private int currentExit = 0;
        public int CurrentExit
        {
            get
            {
                return this.currentExit;
            }
            set
            {
                if (this.exits.Count > value)
                {
                    exit = (Exit)exits[value];
                    this.currentExit = value;
                }
            }
        }
        private int selectedExit; public int SelectedExit { get { return this.selectedExit; } set { selectedExit = value; } }

        private Exit exit;

        private int levelNum; public int LevelNum { get { return levelNum; } set { levelNum = value; } }

        public int NumberOfExits { get { return exits.Count; } }
        public void RemoveCurrentExit()
        {
            if (currentExit < exits.Count)
            {
                exits.Remove(exits[currentExit]);
                this.currentExit = 0;
            }
        }
        public void Clear()
        {
            exits.Clear();
            this.currentExit = 0;
        }
        public void AddNewExit(int index, Point p)
        {
            Exit e = new Exit();
            e.NullExit();
            e.FieldCoordX = (byte)p.X;
            e.FieldCoordY = (byte)p.Y;
            if (index < exits.Count)
                exits.Insert(index, e);
            else
                exits.Add(e);
        }
        public ushort Destination { get { return exit.Destination; } set { exit.Destination = value; } }
        public byte ExitType { get { return exit.ExitType; } set { exit.ExitType = value; } }
        public bool LengthOverOne { get { return exit.LengthOverOne; } set { exit.LengthOverOne = value; } }
        public bool ShowMessage { get { return exit.ShowMessage; } set { exit.ShowMessage = value; } }

        public byte FieldCoordX { get { return exit.FieldCoordX; } set { exit.FieldCoordX = value; } }
        public byte FieldCoordY { get { return exit.FieldCoordY; } set { exit.FieldCoordY = value; } }
        public byte FieldCoordZ { get { return exit.FieldCoordZ; } set { exit.FieldCoordZ = value; } }
        public byte FieldHeight { get { return exit.FieldHeight; } set { exit.FieldHeight = value; } }
        public bool FieldWidthXPlusHalf { get { return exit.FieldWidthXPlusHalf; } set { exit.FieldWidthXPlusHalf = value; } }
        public bool FieldWidthYPlusHalf { get { return exit.FieldWidthYPlusHalf; } set { exit.FieldWidthYPlusHalf = value; } }

        public byte MarioCoordX { get { return exit.MarioCoordX; } set { exit.MarioCoordX = value; } }
        public byte MarioCoordY { get { return exit.MarioCoordY; } set { exit.MarioCoordY = value; } }
        public byte MarioCoordZ { get { return exit.MarioCoordZ; } set { exit.MarioCoordZ = value; } }
        public byte MarioRadialPosition { get { return exit.MarioRadialPosition; } set { exit.MarioRadialPosition = value; } }
        public bool MarioCoordXBit7 { get { return exit.MarioCoordXBit7; } set { exit.MarioCoordXBit7 = value; } }
        public bool MarioCoordYBit7 { get { return exit.MarioCoordYBit7; } set { exit.MarioCoordYBit7 = value; } }

        public byte FieldWidth { get { return exit.FieldWidth; } set { exit.FieldWidth = value; } }
        public byte FieldRadialPosition { get { return exit.FieldRadialPosition; } set { exit.FieldRadialPosition = value; } }

        public LevelExits(byte[] data, int levelNum)
        {
            this.data = data;
            this.levelNum = levelNum;
            InitializeLevel(data);
        }
        public LevelExits(byte[] data)
        {
            // Used as storage for the Events Previewer
            this.data = data;
        }
        private void InitializeLevel(byte[] data)
        {
            int offset;
            ushort offsetStart = 0;
            ushort offsetEnd = 0;
            Exit tExit;

            int pointerOffset = (levelNum * 2) + 0x1D2D64;

            offsetStart = BitManager.GetShort(data, pointerOffset); pointerOffset += 2;
            offsetEnd = BitManager.GetShort(data, pointerOffset);

            if (levelNum == 0x1FF) offsetEnd = 0;

            if (offsetStart >= offsetEnd) return; // no exit fields for level

            offset = offsetStart + 0x1D0000;

            while (offset < offsetEnd + 0x1D0000)
            {
                tExit = new Exit();
                tExit.InitializeExit(data, offset);
                exits.Add(tExit);

                offset += 5;
                if (tExit.ExitType == 0) offset += 3;
                if (tExit.LengthOverOne) offset += 1;
            }
        }
        public ushort Assemble(ushort offsetStart)
        {
            int offset = 0;
            int pointerOffset = (levelNum * 2) + 0x1D2D64;

            BitManager.SetShort(data, pointerOffset, offsetStart);  // set the new pointer for the fields

            if (exits.Count == 0) return offsetStart; // no exit fields for level

            offset = offsetStart + 0x1D0000;

            for (int i = 0; i < exits.Count; i++)
            {
                this.CurrentExit = i;
                exit.AssembleExit(data, offset);

                offset += 5;
                if (exit.ExitType == 0) offset += 3;
                if (exit.LengthOverOne) offset += 1;
            }

            offsetStart = (ushort)(offset - 0x1D0000);

            return offsetStart;
        }

        [Serializable()]
        public class Exit
        {
            private ushort destination; public ushort Destination { get { return destination; } set { destination = value; } }
            private byte exitType; public byte ExitType { get { return exitType; } set { exitType = value; } }
            private bool lengthOverOne; public bool LengthOverOne { get { return lengthOverOne; } set { lengthOverOne = value; } }
            private bool showMessage; public bool ShowMessage { get { return showMessage; } set { showMessage = value; } }

            private byte fieldCoordX; public byte FieldCoordX { get { return fieldCoordX; } set { fieldCoordX = value; } }
            private byte fieldCoordY; public byte FieldCoordY { get { return fieldCoordY; } set { fieldCoordY = value; } }
            private byte fieldCoordZ; public byte FieldCoordZ { get { return fieldCoordZ; } set { fieldCoordZ = value; } }
            private byte fieldHeight; public byte FieldHeight { get { return fieldHeight; } set { fieldHeight = value; } }
            private bool fieldWidthXPlusHalf; public bool FieldWidthXPlusHalf { get { return fieldWidthXPlusHalf; } set { fieldWidthXPlusHalf = value; } }
            private bool fieldWidthYPlusHalf; public bool FieldWidthYPlusHalf { get { return fieldWidthYPlusHalf; } set { fieldWidthYPlusHalf = value; } }

            private byte marioCoordX; public byte MarioCoordX { get { return marioCoordX; } set { marioCoordX = value; } }
            private byte marioCoordY; public byte MarioCoordY { get { return marioCoordY; } set { marioCoordY = value; } }
            private byte marioCoordZ; public byte MarioCoordZ { get { return marioCoordZ; } set { marioCoordZ = value; } }
            private byte marioRadialPosition; public byte MarioRadialPosition { get { return marioRadialPosition; } set { marioRadialPosition = value; } }
            private bool marioCoordXBit7; public bool MarioCoordXBit7 { get { return marioCoordXBit7; } set { marioCoordXBit7 = value; } }
            private bool marioCoordYBit7; public bool MarioCoordYBit7 { get { return marioCoordYBit7; } set { marioCoordYBit7 = value; } }

            private byte fieldWidth; public byte FieldWidth { get { return fieldWidth; } set { fieldWidth = value; } }
            private byte fieldRadialPosition; public byte FieldRadialPosition { get { return fieldRadialPosition; } set { fieldRadialPosition = value; } }

            public void NullExit()
            {
                destination = 0;
                exitType = 0;
                lengthOverOne = false;
                fieldCoordX = 0;
                fieldCoordY = 0;
                fieldCoordZ = 0;
                fieldHeight = 0;
                fieldWidthXPlusHalf = false;
                fieldWidthYPlusHalf = false;
                marioCoordX = 0;
                marioCoordY = 0;
                marioCoordZ = 0;
                marioRadialPosition = 0;
                fieldWidth = 0;
                fieldRadialPosition = 0;
            }

            public void InitializeExit(byte[] data, int offset)
            {
                byte temp = 0;
                ushort tempShort = 0;

                tempShort = BitManager.GetShort(data, offset); offset++;
                destination = (ushort)(tempShort & 0x01FF);
                temp = BitManager.GetByte(data, offset); offset++;
                if ((temp & 0x08) == 0x08) showMessage = true;
                exitType = (byte)((temp & 0x60) >> 6);
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

                if (exitType == 0)
                {
                    temp = BitManager.GetByte(data, offset);
                    marioCoordX = (byte)(temp & 0x7F); offset++;
                    if ((temp & 0x80) == 0x80) marioCoordXBit7 = true;
                    temp = BitManager.GetByte(data, offset);
                    marioCoordY = (byte)(temp & 0x7F); offset++;
                    if ((temp & 0x80) == 0x80) marioCoordYBit7 = true;
                    temp = BitManager.GetByte(data, offset);
                    marioCoordZ = (byte)(temp & 0x1F);
                    marioRadialPosition = (byte)((temp & 0xF0) >> 5); offset++;
                }
                else if (exitType == 1)
                    destination &= 0xFF;
                if (lengthOverOne)
                {
                    temp = BitManager.GetByte(data, offset);
                    fieldWidth = (byte)(temp & 0x0F);
                    fieldRadialPosition = (byte)((temp & 0x80) >> 7); offset++;
                }
            }
            public void AssembleExit(byte[] data, int offset)
            {
                BitManager.SetShort(data, offset, destination); offset++;
                BitManager.SetBit(data, offset, 3, showMessage);
                if (exitType == 0) BitManager.SetBit(data, offset, 5, true);
                else if (exitType == 1) BitManager.SetBit(data, offset, 6, true);
                BitManager.SetBit(data, offset, 7, lengthOverOne); offset++;

                BitManager.SetByte(data, offset, fieldCoordX);
                BitManager.SetBit(data, offset, 7, fieldWidthXPlusHalf); offset++;
                BitManager.SetByte(data, offset, fieldCoordY);
                BitManager.SetBit(data, offset, 7, fieldWidthYPlusHalf); offset++;
                BitManager.SetByte(data, offset, fieldCoordZ);
                BitManager.SetBitsByByte(data, offset, (byte)(fieldHeight << 5), true); offset++;

                if (exitType == 0)
                {
                    BitManager.SetByte(data, offset, marioCoordX);
                    BitManager.SetBit(data, offset, 7, marioCoordXBit7); offset++;
                    BitManager.SetByte(data, offset, marioCoordY);
                    BitManager.SetBit(data, offset, 7, marioCoordYBit7); offset++;
                    BitManager.SetByte(data, offset, marioCoordZ);
                    BitManager.SetBitsByByte(data, offset, (byte)(marioRadialPosition << 5), true); offset++;
                }
                if (lengthOverOne)
                {
                    BitManager.SetByte(data, offset, fieldWidth);
                    BitManager.SetBitsByByte(data, offset, (byte)(fieldRadialPosition << 7), true); offset++;
                }
            }
        }
        public int GetExitLength()
        {
            int length = 5;
            if (ExitType == 0)
                length += 3;
            if (LengthOverOne)
                length++;
            return length;
        }
    }
}
