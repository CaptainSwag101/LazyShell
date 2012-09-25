using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace LAZYSHELL
{
    [Serializable()]
    public class Location
    {
        [NonSerialized()]
        private byte[] data;
        private int index; public int Index { get { return index; } }
        private char[] name; public char[] Name { get { return name; } set { name = value; } }

        private byte x; public byte X { get { return x; } set { x = value; } }
        private byte y; public byte Y { get { return y; } set { y = value; } }

        private byte showCheckBit; public byte ShowCheckBit { get { return showCheckBit; } set { showCheckBit = value; } }
        private ushort showCheckAddress; public ushort ShowCheckAddress { get { return showCheckAddress; } set { showCheckAddress = value; } }

        private bool goLocation; public bool GoLocation { get { return goLocation; } set { goLocation = value; } }

        private ushort runEvent; public ushort RunEvent { get { return runEvent; } set { runEvent = value; } }

        private byte whichLocationCheckBit; public byte WhichLocationCheckBit { get { return whichLocationCheckBit; } set { whichLocationCheckBit = value; } }
        private ushort whichLocationCheckAddress; public ushort WhichLocationCheckAddress { get { return whichLocationCheckAddress; } set { whichLocationCheckAddress = value; } }

        private byte goLocationA; public byte GoLocationA { get { return goLocationA; } set { goLocationA = value; } }
        private byte goLocationB; public byte GoLocationB { get { return goLocationB; } set { goLocationB = value; } }

        private bool toEastEnabled; public bool ToEastEnabled { get { return toEastEnabled; } set { toEastEnabled = value; } }
        private bool toSouthEnabled; public bool ToSouthEnabled { get { return toSouthEnabled; } set { toSouthEnabled = value; } }
        private bool toWestEnabled; public bool ToWestEnabled { get { return toWestEnabled; } set { toWestEnabled = value; } }
        private bool toNorthEnabled; public bool ToNorthEnabled { get { return toNorthEnabled; } set { toNorthEnabled = value; } }

        private byte toEastCheckBit; public byte ToEastCheckBit { get { return toEastCheckBit; } set { toEastCheckBit = value; } }
        private byte toSouthCheckBit; public byte ToSouthCheckBit { get { return toSouthCheckBit; } set { toSouthCheckBit = value; } }
        private byte toWestCheckBit; public byte ToWestCheckBit { get { return toWestCheckBit; } set { toWestCheckBit = value; } }
        private byte toNorthCheckBit; public byte ToNorthCheckBit { get { return toNorthCheckBit; } set { toNorthCheckBit = value; } }
        private ushort toEastCheckAddress; public ushort ToEastCheckAddress { get { return toEastCheckAddress; } set { toEastCheckAddress = value; } }
        private ushort toSouthCheckAddress; public ushort ToSouthCheckAddress { get { return toSouthCheckAddress; } set { toSouthCheckAddress = value; } }
        private ushort toWestCheckAddress; public ushort ToWestCheckAddress { get { return toWestCheckAddress; } set { toWestCheckAddress = value; } }
        private ushort toNorthCheckAddress; public ushort ToNorthCheckAddress { get { return toNorthCheckAddress; } set { toNorthCheckAddress = value; } }
        private byte toEastLocation; public byte ToEastLocation { get { return toEastLocation; } set { toEastLocation = value; } }
        private byte toSouthLocation; public byte ToSouthLocation { get { return toSouthLocation; } set { toSouthLocation = value; } }
        private byte toWestLocation; public byte ToWestLocation { get { return toWestLocation; } set { toWestLocation = value; } }
        private byte toNorthLocation; public byte ToNorthLocation { get { return toNorthLocation; } set { toNorthLocation = value; } }

        public Location(byte[] data, int index)
        {
            this.data = data;
            this.index = index;

            InitializeLocation(data);
        }
        private void InitializeLocation(byte[] data)
        {
            int offset = index * 16 + 0x3EF830;

            x = (byte)data[offset]; offset++;
            y = (byte)data[offset]; offset++;

            showCheckBit = (byte)(data[offset] & 0x07);
            showCheckAddress = (ushort)(((Bits.GetShort(data, offset) & 0x1FF) >> 3) + 0x7045); offset++;

            goLocation = (data[offset] & 0x40) == 0x40; offset++;

            if (!goLocation)
            {
                runEvent = Bits.GetShort(data, offset);
                offset += 4;
            }
            else
            {
                whichLocationCheckBit = (byte)(data[offset] & 0x07);
                whichLocationCheckAddress = (ushort)(((Bits.GetShort(data, offset) & 0x1FF) >> 3) + 0x7045); offset += 2;
                goLocationA = data[offset]; offset++;
                goLocationB = data[offset]; offset++;
            }

            if (Bits.GetShort(data, offset) == 0xFFFF)
            {
                toEastEnabled = false;
                toEastCheckAddress = 0x7045;
                offset += 2;
            }
            else
            {
                toEastEnabled = true;
                toEastCheckBit = (byte)(data[offset] & 0x07);
                toEastCheckAddress = (ushort)(((Bits.GetShort(data, offset) & 0x1FF) >> 3) + 0x7045); offset++;
                toEastLocation = (byte)(data[offset] >> 1); offset++;
            }

            if (Bits.GetShort(data, offset) == 0xFFFF)
            {
                toSouthEnabled = false;
                toSouthCheckAddress = 0x7045;
                offset += 2;
            }
            else
            {
                toSouthEnabled = true;
                toSouthCheckBit = (byte)(data[offset] & 0x07);
                toSouthCheckAddress = (ushort)(((Bits.GetShort(data, offset) & 0x1FF) >> 3) + 0x7045); offset++;
                toSouthLocation = (byte)(data[offset] >> 1); offset++;
            }

            if (Bits.GetShort(data, offset) == 0xFFFF)
            {
                toWestEnabled = false;
                toWestCheckAddress = 0x7045;
                offset += 2;
            }
            else
            {
                toWestEnabled = true;
                toWestCheckBit = (byte)(data[offset] & 0x07);
                toWestCheckAddress = (ushort)(((Bits.GetShort(data, offset) & 0x1FF) >> 3) + 0x7045); offset++;
                toWestLocation = (byte)(data[offset] >> 1); offset++;
            }

            if (Bits.GetShort(data, offset) == 0xFFFF)
            {
                toNorthEnabled = false;
                toNorthCheckAddress = 0x7045;
                offset += 2;
            }
            else
            {
                toNorthEnabled = true;
                toNorthCheckBit = (byte)(data[offset] & 0x07);
                toNorthCheckAddress = (ushort)(((Bits.GetShort(data, offset) & 0x1FF) >> 3) + 0x7045); offset++;
                toNorthLocation = (byte)(data[offset] >> 1);
            }

            int pointer = Bits.GetShort(data, index * 2 + 0x3EFD00);
            offset = pointer + 0x3EFD80;
            ArrayList temp = new ArrayList();

            for (int i = 0; data[offset] != 0x06 && data[offset] != 0x00; i++)
            {
                temp.Add((char)data[offset]); offset++;
            }
            name = new char[temp.Count];
            int a = 0;
            foreach (char c in temp)
                name[a++] = c;
        }
        public void Assemble()
        {
            int offset = index * 16 + 0x3EF830;

            data[offset] = x; offset++;
            data[offset] = y; offset++;

            Bits.SetShort(data, offset, (ushort)((showCheckAddress - 0x7045) << 3));
            data[offset] |= showCheckBit; offset++;

            Bits.SetBit(data, offset, 6, goLocation); offset++;

            if (!goLocation)
            {
                Bits.SetShort(data, offset, runEvent); offset += 2;
                Bits.SetShort(data, offset, 0xFFFF); offset += 2;
            }
            else
            {
                Bits.SetShort(data, offset, (ushort)((whichLocationCheckAddress - 0x7045) << 3));
                data[offset] |= whichLocationCheckBit; offset += 2;
                data[offset] = goLocationA; offset++;
                data[offset] = goLocationB; offset++;
            }

            if (!toEastEnabled)
            {
                Bits.SetShort(data, offset, 0xFFFF);
                offset += 2;
            }
            else
            {
                Bits.SetShort(data, offset, (ushort)((toEastCheckAddress - 0x7045) << 3));
                data[offset] |= toEastCheckBit; offset++;
                data[offset] |= (byte)(toEastLocation << 1); offset++;
            }

            if (!toSouthEnabled)
            {
                Bits.SetShort(data, offset, 0xFFFF);
                offset += 2;
            }
            else
            {
                Bits.SetShort(data, offset, (ushort)((toSouthCheckAddress - 0x7045) << 3));
                data[offset] |= toSouthCheckBit; offset++;
                data[offset] |= (byte)(toSouthLocation << 1); offset++;
            }

            if (!toWestEnabled)
            {
                Bits.SetShort(data, offset, 0xFFFF);
                offset += 2;
            }
            else
            {
                Bits.SetShort(data, offset, (ushort)((toWestCheckAddress - 0x7045) << 3));
                data[offset] |= toWestCheckBit; offset++;
                data[offset] |= (byte)(toWestLocation << 1); offset++;
            }

            if (!toNorthEnabled)
            {
                Bits.SetShort(data, offset, 0xFFFF);
                offset += 2;
            }
            else
            {
                Bits.SetShort(data, offset, (ushort)((toNorthCheckAddress - 0x7045) << 3));
                data[offset] |= toNorthCheckBit; offset++;
                data[offset] |= (byte)(toNorthLocation << 1); offset++;
            }
        }
        public void Clear()
        {
            x = 0;
            y = 0;
            showCheckBit = 0;
            showCheckAddress = 0x7045;
            goLocation = false;
            runEvent = 0;
            whichLocationCheckAddress = 0x7045;
            whichLocationCheckBit = 0;
            goLocationA = 0;
            goLocationB = 0;
            toEastEnabled = false;
            toSouthEnabled = false;
            toWestEnabled = false;
            toNorthEnabled = false;
            name = new char[0];
        }
        public override string ToString()
        {
            return Do.RawToASCII(name, LAZYSHELL.Properties.Settings.Default.Keystrokes);
        }
    }
}
