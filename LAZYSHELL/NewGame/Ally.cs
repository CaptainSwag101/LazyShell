using System;
using System.Collections.Generic;
using System.Text;

namespace LAZYSHELL.NewGame
{
    [Serializable()]
    public class Ally : Element
    {
        #region Variables

        // ROM buffer
        private byte[] rom
        {
            get { return Model.ROM; }
            set { Model.ROM = value; }
        }

        // Index
        public override int Index { get; set; }

        // Properties
        public char[] Name { get; set; }
        public byte Level { get; set; }
        public ushort CurrentHP { get; set; }
        public ushort MaxHP { get; set; }
        public byte Speed { get; set; }
        public byte Attack { get; set; }
        public byte Defense { get; set; }
        public byte MgAttack { get; set; }
        public byte MgDefense { get; set; }
        public ushort Experience { get; set; }
        public byte Weapon { get; set; }
        public byte Armor { get; set; }
        public byte Accessory { get; set; }
        public bool[] Magic { get; set; }

        #endregion

        // Constructor
        public Ally(int index)
        {
            this.Index = index;
            ReadFromROM();
        }

        #region Methods

        // Read/write ROM
        private void ReadFromROM()
        {
            Name = new char[10];
            for (int i = 0; i < Name.Length; i++)
                Name[i] = (char)rom[(Index * 10) + 0x3A134D + i];
            //
            int offset = (Index * 20) + 0x3A002C;
            //
            Level = rom[offset++];
            CurrentHP = Bits.GetShort(rom, offset); offset += 2;
            MaxHP = Bits.GetShort(rom, offset); offset += 2;
            Speed = rom[offset++];
            Attack = rom[offset++];
            Defense = rom[offset++];
            MgAttack = rom[offset++];
            MgDefense = rom[offset++];
            Experience = Bits.GetShort(rom, offset); offset += 2;
            Weapon = rom[offset++];
            Armor = rom[offset++];
            Accessory = rom[offset]; offset += 2;
            //
            Magic = new bool[32];
            int a = 0;
            for (int o = 0; o < 4; o++, offset++)
                for (int i = 0; i < 8; i++)
                    Magic[a++] = Bits.GetBit(rom, offset, i);
        }
        public void WriteToROM()
        {
            Bits.SetChars(rom, 0x3A134D + (Index * 10), Name);
            //
            int offset = (Index * 20) + 0x3A002C;
            //
            rom[offset++] = Level;
            Bits.SetShort(rom, offset, CurrentHP); offset += 2;
            Bits.SetShort(rom, offset, MaxHP); offset += 2;
            rom[offset++] = Speed;
            rom[offset++] = Attack;
            rom[offset++] = Defense;
            rom[offset++] = MgAttack;
            rom[offset++] = MgDefense;
            Bits.SetShort(rom, offset, Experience); offset += 2;
            rom[offset++] = Weapon;
            rom[offset++] = Armor;
            Bits.SetByte(rom, offset, Accessory); offset += 2;
            //
            int a = 0;
            for (int o = 0; o < 4; o++, offset++)
                for (int i = 0; i < 8; i++)
                    Bits.SetBit(rom, offset, i, Magic[a++]);
        }

        // Inherited
        public override void Clear()
        {
            Bits.Fill(Name, '\x20');
            Level = 1;
            CurrentHP = 0;
            MaxHP = 0;
            Speed = 0;
            Attack = 0;
            Defense = 0;
            MgAttack = 0;
            MgDefense = 0;
            Experience = 0;
            Weapon = 0;
            Armor = 0;
            Accessory = 0;
            Magic = new bool[32];
        }

        // Override
        public override string ToString()
        {
            return new string(Name);
        }

        #endregion
    }
}
