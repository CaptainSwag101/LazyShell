using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace LazyShell.WorldMaps
{
    [Serializable()]
    public class Location
    {
        #region Variables

        // ROM buffer
        private byte[] rom
        {
            get { return Model.ROM; }
            set { Model.ROM = value; }
        }

        // Index
        public int Index { get; set; }

        // Name
        public char[] Name { get; set; }

        // Coordinate pair
        public byte X { get; set; }
        public byte Y { get; set; }

        // Misc properties
        public byte ShowCheckBit { get; set; }
        public ushort ShowCheckAddress { get; set; }
        public bool GoToLocation { get; set; }
        public ushort RunEvent { get; set; }
        public byte WhichLocationCheckBit { get; set; }
        public ushort WhichLocationCheckAddress { get; set; }
        public byte GoLocationA { get; set; }
        public byte GoLocationB { get; set; }

        // Paths : Enabled status
        public bool EnabledToEast { get; set; }
        public bool EnabledToSouth { get; set; }
        public bool EnabledToWest { get; set; }
        public bool EnabledToNorth { get; set; }

        // Paths : Check bits
        public byte CheckBitToEast { get; set; }
        public byte CheckBitToSouth { get; set; }
        public byte CheckBitToWest { get; set; }
        public byte CheckBitToNorth { get; set; }
        public ushort CheckAddressToEast { get; set; }
        public ushort CheckAddressToSouth { get; set; }
        public ushort CheckAddressToWest { get; set; }
        public ushort CheckAddressToNorth { get; set; }

        // Paths : Destinations
        public byte LocationToEast { get; set; }
        public byte LocationToSouth { get; set; }
        public byte LocationToWest { get; set; }
        public byte LocationToNorth { get; set; }

        #endregion

        // Constructor
        public Location(int index)
        {
            this.Index = index;
            ReadFromROM();
        }

        #region Methods

        // Read/write ROM
        private void ReadFromROM()
        {
            int offset = Index * 16 + 0x3EF830;
            X = (byte)rom[offset++];
            Y = (byte)rom[offset++];
            ShowCheckBit = (byte)(rom[offset] & 0x07);
            ShowCheckAddress = (ushort)(((Bits.GetShort(rom, offset++) & 0x1FF) >> 3) + 0x7045);
            GoToLocation = (rom[offset++] & 0x40) == 0x40;
            if (!GoToLocation)
            {
                RunEvent = Bits.GetShort(rom, offset);
                offset += 4;
            }
            else
            {
                WhichLocationCheckBit = (byte)(rom[offset] & 0x07);
                WhichLocationCheckAddress = (ushort)(((Bits.GetShort(rom, offset) & 0x1FF) >> 3) + 0x7045); offset += 2;
                GoLocationA = rom[offset++];
                GoLocationB = rom[offset++];
            }
            if (Bits.GetShort(rom, offset) == 0xFFFF)
            {
                EnabledToEast = false;
                CheckAddressToEast = 0x7045;
                offset += 2;
            }
            else
            {
                EnabledToEast = true;
                CheckBitToEast = (byte)(rom[offset] & 0x07);
                CheckAddressToEast = (ushort)(((Bits.GetShort(rom, offset) & 0x1FF) >> 3) + 0x7045); offset++;
                LocationToEast = (byte)(rom[offset] >> 1); offset++;
            }
            if (Bits.GetShort(rom, offset) == 0xFFFF)
            {
                EnabledToSouth = false;
                CheckAddressToSouth = 0x7045;
                offset += 2;
            }
            else
            {
                EnabledToSouth = true;
                CheckBitToSouth = (byte)(rom[offset] & 0x07);
                CheckAddressToSouth = (ushort)(((Bits.GetShort(rom, offset++) & 0x1FF) >> 3) + 0x7045);
                LocationToSouth = (byte)(rom[offset++] >> 1);
            }
            if (Bits.GetShort(rom, offset) == 0xFFFF)
            {
                EnabledToWest = false;
                CheckAddressToWest = 0x7045;
                offset += 2;
            }
            else
            {
                EnabledToWest = true;
                CheckBitToWest = (byte)(rom[offset] & 0x07);
                CheckAddressToWest = (ushort)(((Bits.GetShort(rom, offset++) & 0x1FF) >> 3) + 0x7045);
                LocationToWest = (byte)(rom[offset++] >> 1);
            }
            if (Bits.GetShort(rom, offset) == 0xFFFF)
            {
                EnabledToNorth = false;
                CheckAddressToNorth = 0x7045;
                offset += 2;
            }
            else
            {
                EnabledToNorth = true;
                CheckBitToNorth = (byte)(rom[offset] & 0x07);
                CheckAddressToNorth = (ushort)(((Bits.GetShort(rom, offset++) & 0x1FF) >> 3) + 0x7045);
                LocationToNorth = (byte)(rom[offset] >> 1);
            }
            
            // Read name text
            int pointer = Bits.GetShort(rom, Index * 2 + 0x3EFD00);
            offset = pointer + 0x3EFD80;
            List<char> symbols = new List<char>();
            for (int i = 0; rom[offset] != 0x06 && rom[offset] != 0x00; i++)
                symbols.Add((char)rom[offset++]);
            Name = new char[symbols.Count];
            int a = 0;
            foreach (char c in symbols)
                Name[a++] = c;
        }
        public void WriteToROM()
        {
            int offset = Index * 16 + 0x3EF830;
            rom[offset++] = X;
            rom[offset++] = Y;
            Bits.SetShort(rom, offset, (ushort)((ShowCheckAddress - 0x7045) << 3));
            rom[offset++] |= ShowCheckBit;
            Bits.SetBit(rom, offset++, 6, GoToLocation);
            if (!GoToLocation)
            {
                Bits.SetShort(rom, offset, RunEvent); offset += 2;
                Bits.SetShort(rom, offset, 0xFFFF); offset += 2;
            }
            else
            {
                Bits.SetShort(rom, offset, (ushort)((WhichLocationCheckAddress - 0x7045) << 3));
                rom[offset] |= WhichLocationCheckBit; offset += 2;
                rom[offset++] = GoLocationA;
                rom[offset++] = GoLocationB;
            }
            if (!EnabledToEast)
            {
                Bits.SetShort(rom, offset, 0xFFFF);
                offset += 2;
            }
            else
            {
                Bits.SetShort(rom, offset, (ushort)((CheckAddressToEast - 0x7045) << 3));
                rom[offset++] |= CheckBitToEast;
                rom[offset++] |= (byte)(LocationToEast << 1);
            }
            if (!EnabledToSouth)
            {
                Bits.SetShort(rom, offset, 0xFFFF);
                offset += 2;
            }
            else
            {
                Bits.SetShort(rom, offset, (ushort)((CheckAddressToSouth - 0x7045) << 3));
                rom[offset++] |= CheckBitToSouth;
                rom[offset++] |= (byte)(LocationToSouth << 1);
            }
            if (!EnabledToWest)
            {
                Bits.SetShort(rom, offset, 0xFFFF);
                offset += 2;
            }
            else
            {
                Bits.SetShort(rom, offset, (ushort)((CheckAddressToWest - 0x7045) << 3));
                rom[offset++] |= CheckBitToWest;
                rom[offset++] |= (byte)(LocationToWest << 1);
            }
            if (!EnabledToNorth)
            {
                Bits.SetShort(rom, offset, 0xFFFF);
                offset += 2;
            }
            else
            {
                Bits.SetShort(rom, offset, (ushort)((CheckAddressToNorth - 0x7045) << 3));
                rom[offset++] |= CheckBitToNorth;
                rom[offset++] |= (byte)(LocationToNorth << 1);
            }
        }

        // Universal functions
        public void Clear()
        {
            X = 0;
            Y = 0;
            ShowCheckBit = 0;
            ShowCheckAddress = 0x7045;
            GoToLocation = false;
            RunEvent = 0;
            WhichLocationCheckAddress = 0x7045;
            WhichLocationCheckBit = 0;
            GoLocationA = 0;
            GoLocationB = 0;
            EnabledToEast = false;
            EnabledToSouth = false;
            EnabledToWest = false;
            EnabledToNorth = false;
            Name = new char[0];
        }

        // Override
        public override string ToString()
        {
            return Do.RawToASCII(Name, Lists.Keystrokes);
        }

        #endregion
    }
}
