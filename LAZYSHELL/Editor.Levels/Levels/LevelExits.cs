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
        [NonSerialized()]
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

        private Exit exit; public Exit Exit_ { get { return exit; } }

        private int index; public int Index { get { return index; } set { index = value; } }

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
            e.X = (byte)p.X;
            e.Y = (byte)p.Y;
            if (index < exits.Count)
                exits.Insert(index, e);
            else
                exits.Add(e);
        }
        public void AddNewExit(int index, Exit copy)
        {
            if (index < exits.Count)
                exits.Insert(index, copy);
            else
                exits.Add(copy);
        }
        public ushort Destination { get { return exit.Destination; } set { exit.Destination = value; } }
        public byte ExitType { get { return exit.ExitType; } set { exit.ExitType = value; } }
        public bool ShowMessage { get { return exit.ShowMessage; } set { exit.ShowMessage = value; } }

        public byte X { get { return exit.X; } set { exit.X = value; } }
        public byte Y { get { return exit.Y; } set { exit.Y = value; } }
        public byte FieldCoordZ { get { return exit.Z; } set { exit.Z = value; } }
        public byte FieldHeight { get { return exit.Height; } set { exit.Height = value; } }
        public bool FieldWidthXPlusHalf { get { return exit.X_Half; } set { exit.X_Half = value; } }
        public bool FieldWidthYPlusHalf { get { return exit.Y_Half; } set { exit.Y_Half = value; } }

        public byte DestX { get { return exit.DestX; } set { exit.DestX = value; } }
        public byte DestY { get { return exit.DestY; } set { exit.DestY = value; } }
        public byte DestZ { get { return exit.DestZ; } set { exit.DestZ = value; } }
        public byte DestFace { get { return exit.DestFace; } set { exit.DestFace = value; } }
        public bool DestXb7 { get { return exit.DestXb7; } set { exit.DestXb7 = value; } }
        public bool DestYb7 { get { return exit.DestYb7; } set { exit.DestYb7 = value; } }

        public byte Width { get { return exit.Width; } set { exit.Width = value; } }
        public byte Face { get { return exit.Face; } set { exit.Face = value; } }

        public LevelExits(byte[] data, int index)
        {
            this.data = data;
            this.index = index;
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

            int pointerOffset = (index * 2) + 0x1D2D64;

            offsetStart = Bits.GetShort(data, pointerOffset); pointerOffset += 2;
            offsetEnd = Bits.GetShort(data, pointerOffset);

            if (index == 0x1FF) offsetEnd = 0;

            if (offsetStart >= offsetEnd) return; // no exit fields for level

            offset = offsetStart + 0x1D0000;

            while (offset < offsetEnd + 0x1D0000)
            {
                tExit = new Exit();
                tExit.InitializeExit(data, offset);
                exits.Add(tExit);

                offset += 5;
                if (tExit.ExitType == 0) offset += 3;
                if (tExit.Width > 0) offset += 1;
            }
        }
        public ushort Assemble(ushort offsetStart)
        {
            int offset = 0;
            int pointerOffset = (index * 2) + 0x1D2D64;

            Bits.SetShort(data, pointerOffset, offsetStart);  // set the new pointer for the fields

            if (exits.Count == 0) return offsetStart; // no exit fields for level

            offset = offsetStart + 0x1D0000;

            for (int i = 0; i < exits.Count; i++)
            {
                this.CurrentExit = i;
                exit.AssembleExit(data, offset);

                offset += 5;
                if (exit.ExitType == 0) offset += 3;
                if (exit.Width > 0) offset += 1;
            }

            offsetStart = (ushort)(offset - 0x1D0000);

            return offsetStart;
        }

        [Serializable()]
        public class Exit
        {
            private ushort destination; public ushort Destination { get { return destination; } set { destination = value; } }
            private byte exitType; public byte ExitType { get { return exitType; } set { exitType = value; } }
            private bool showMessage; public bool ShowMessage { get { return showMessage; } set { showMessage = value; } }

            private byte x; public byte X { get { return x; } set { x = value; } }
            private byte y; public byte Y { get { return y; } set { y = value; } }
            private byte z; public byte Z { get { return z; } set { z = value; } }
            private byte height; public byte Height { get { return height; } set { height = value; } }
            private bool x_half; public bool X_Half { get { return x_half; } set { x_half = value; } }
            private bool y_half; public bool Y_Half { get { return y_half; } set { y_half = value; } }

            private byte destX; public byte DestX { get { return destX; } set { destX = value; } }
            private byte destY; public byte DestY { get { return destY; } set { destY = value; } }
            private byte destZ; public byte DestZ { get { return destZ; } set { destZ = value; } }
            private byte destFace; public byte DestFace { get { return destFace; } set { destFace = value; } }
            private bool destXb7; public bool DestXb7 { get { return destXb7; } set { destXb7 = value; } }
            private bool destYb7; public bool DestYb7 { get { return destYb7; } set { destYb7 = value; } }

            private byte width; public byte Width { get { return width; } set { width = value; } }
            private byte face; public byte Face { get { return face; } set { face = value; } }

            public void NullExit()
            {
                destination = 0;
                exitType = 0;
                x = 0;
                y = 0;
                z = 0;
                height = 0;
                x_half = false;
                y_half = false;
                destX = 0;
                destY = 0;
                destZ = 0;
                destFace = 0;
                width = 0;
                face = 0;
            }

            public void InitializeExit(byte[] data, int offset)
            {
                byte temp = 0;
                ushort tempShort = 0;

                tempShort = Bits.GetShort(data, offset); offset++;
                destination = (ushort)(tempShort & 0x01FF);
                temp = data[offset]; offset++;
                if ((temp & 0x08) == 0x08) showMessage = true;
                exitType = (byte)((temp & 0x60) >> 6);
                bool lengthOverOne = (temp & 0x80) == 0x80;

                temp = data[offset];
                if ((temp & 0x80) == 0x80) x_half = true;
                x = (byte)(temp & 0x7F); offset++;
                temp = data[offset];
                if ((temp & 0x80) == 0x80) y_half = true;
                y = (byte)(temp & 0x7F); offset++;
                temp = data[offset]; offset++;
                z = (byte)(temp & 0x1F);
                height = (byte)((temp & 0xF0) >> 5);

                if (exitType == 0)
                {
                    temp = data[offset];
                    destX = (byte)(temp & 0x7F); offset++;
                    if ((temp & 0x80) == 0x80) destXb7 = true;
                    temp = data[offset];
                    destY = (byte)(temp & 0x7F); offset++;
                    if ((temp & 0x80) == 0x80) destYb7 = true;
                    temp = data[offset];
                    destZ = (byte)(temp & 0x1F);
                    destFace = (byte)((temp & 0xF0) >> 5); offset++;
                }
                else if (exitType == 1)
                    destination &= 0xFF;
                if (lengthOverOne)
                {
                    temp = data[offset];
                    width = (byte)(temp & 0x0F);
                    face = (byte)((temp & 0x80) >> 7); offset++;
                }
            }
            public void AssembleExit(byte[] data, int offset)
            {
                Bits.SetShort(data, offset, destination); offset++;
                Bits.SetBit(data, offset, 3, showMessage);
                if (exitType == 0) Bits.SetBit(data, offset, 5, true);
                else if (exitType == 1) Bits.SetBit(data, offset, 6, true);
                Bits.SetBit(data, offset, 7, width > 0); offset++;

                Bits.SetByte(data, offset, x);
                Bits.SetBit(data, offset, 7, x_half); offset++;
                Bits.SetByte(data, offset, y);
                Bits.SetBit(data, offset, 7, y_half); offset++;
                Bits.SetByte(data, offset, z);
                Bits.SetBitsByByte(data, offset, (byte)(height << 5), true); offset++;

                if (exitType == 0)
                {
                    Bits.SetByte(data, offset, destX);
                    Bits.SetBit(data, offset, 7, destXb7); offset++;
                    Bits.SetByte(data, offset, destY);
                    Bits.SetBit(data, offset, 7, destYb7); offset++;
                    Bits.SetByte(data, offset, destZ);
                    Bits.SetBitsByByte(data, offset, (byte)(destFace << 5), true); offset++;
                }
                if (width > 0)
                {
                    Bits.SetByte(data, offset, width);
                    Bits.SetBitsByByte(data, offset, (byte)(face << 7), true); offset++;
                }
            }
            public Exit Copy()
            {
                Exit copy = new Exit();
                copy.Destination = destination;
                copy.ExitType = exitType;
                copy.ShowMessage = showMessage;
                copy.X = x;
                copy.Y = y;
                copy.Z = z;
                copy.Height = height;
                copy.X_Half = x_half;
                copy.Y_Half = y_half;
                copy.DestX = destX;
                copy.DestY = destY;
                copy.DestZ = destZ;
                copy.DestFace = destFace;
                copy.DestXb7 = destXb7;
                copy.DestYb7 = destYb7;
                copy.Width = width;
                copy.Face = face;
                return copy;
            }
        }
        public int GetExitLength()
        {
            int length = 5;
            if (ExitType == 0)
                length += 3;
            if (Width > 0)
                length++;
            return length;
        }
    }
}
