using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace LAZYSHELL
{
    public class MapPoint
    {
        private byte[] data;
        private int index; public int Index { get { return index; } }
        private char[] name; public char[] Name { get { return name; } set { name = value; } }

        private byte x; public byte X { get { return x; } set { x = value; } }
        private byte y; public byte Y { get { return y; } set { y = value; } }

        private byte showCheckBit; public byte ShowCheckBit { get { return showCheckBit; } set { showCheckBit = value; } }
        private ushort showCheckAddress; public ushort ShowCheckAddress { get { return showCheckAddress; } set { showCheckAddress = value; } }

        private bool goMapPoint; public bool GoMapPoint { get { return goMapPoint; } set { goMapPoint = value; } }

        private ushort runEvent; public ushort RunEvent { get { return runEvent; } set { runEvent = value; } }

        private byte whichPointCheckBit; public byte WhichPointCheckBit { get { return whichPointCheckBit; } set { whichPointCheckBit = value; } }
        private ushort whichPointCheckAddress; public ushort WhichPointCheckAddress { get { return whichPointCheckAddress; } set { whichPointCheckAddress = value; } }

        private byte goMapPointA; public byte GoMapPointA { get { return goMapPointA; } set { goMapPointA = value; } }
        private byte goMapPointB; public byte GoMapPointB { get { return goMapPointB; } set { goMapPointB = value; } }

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
        private byte toEastPoint; public byte ToEastPoint { get { return toEastPoint; } set { toEastPoint = value; } }
        private byte toSouthPoint; public byte ToSouthPoint { get { return toSouthPoint; } set { toSouthPoint = value; } }
        private byte toWestPoint; public byte ToWestPoint { get { return toWestPoint; } set { toWestPoint = value; } }
        private byte toNorthPoint; public byte ToNorthPoint { get { return toNorthPoint; } set { toNorthPoint = value; } }

        public MapPoint(byte[] data, int mapPointNum)
        {
            this.data = data;
            this.index = mapPointNum;

            InitializeMapPoint(data);
        }
        private void InitializeMapPoint(byte[] data)
        {
            int offset = index * 16 + 0x3EF830;

            x = (byte)data[offset]; offset++;
            y = (byte)data[offset]; offset++;

            showCheckBit = (byte)(data[offset] & 0x07);
            showCheckAddress = (ushort)(((Bits.GetShort(data, offset) & 0x1FF) >> 3) + 0x7045); offset++;

            goMapPoint = (data[offset] & 0x40) == 0x40; offset++;

            if (!goMapPoint)
            {
                runEvent = Bits.GetShort(data, offset);
                offset += 4;
            }
            else
            {
                whichPointCheckBit = (byte)(data[offset] & 0x07);
                whichPointCheckAddress = (ushort)(((Bits.GetShort(data, offset) & 0x1FF) >> 3) + 0x7045); offset += 2;
                goMapPointA = data[offset]; offset++;
                goMapPointB = data[offset]; offset++;
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
                toEastPoint = (byte)(data[offset] >> 1); offset++;
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
                toSouthPoint = (byte)(data[offset] >> 1); offset++;
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
                toWestPoint = (byte)(data[offset] >> 1); offset++;
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
                toNorthPoint = (byte)(data[offset] >> 1);
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

            Bits.SetBit(data, offset, 6, goMapPoint); offset++;

            if (!goMapPoint)
            {
                Bits.SetShort(data, offset, runEvent); offset += 2;
                Bits.SetShort(data, offset, 0xFFFF); offset += 2;
            }
            else
            {
                Bits.SetShort(data, offset, (ushort)((whichPointCheckAddress - 0x7045) << 3));
                data[offset] |= whichPointCheckBit; offset += 2;
                data[offset] = goMapPointA; offset++;
                data[offset] = goMapPointB; offset++;
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
                data[offset] |= (byte)(toEastPoint << 1); offset++;
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
                data[offset] |= (byte)(toSouthPoint << 1); offset++;
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
                data[offset] |= (byte)(toWestPoint << 1); offset++;
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
                data[offset] |= (byte)(toNorthPoint << 1); offset++;
            }
        }
        public void Clear()
        {
            x = 0;
            y = 0;
            showCheckBit = 0;
            showCheckAddress = 0x7045;
            goMapPoint = false;
            runEvent = 0;
            whichPointCheckAddress = 0x7045;
            whichPointCheckBit = 0;
            goMapPointA = 0;
            goMapPointB = 0;
            toEastEnabled = false;
            toSouthEnabled = false;
            toWestEnabled = false;
            toNorthEnabled = false;
            name = new char[0];
        }
    }
}
