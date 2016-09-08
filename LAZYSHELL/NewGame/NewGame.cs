using System;
using System.Collections.Generic;
using System.Text;

namespace LazyShell.NewGame
{
    [Serializable()]
    public class NewGame : Element
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

        // Properties : Inventory
        public ushort Coins { get; set; }
        public byte CurrentFP { get; set; }
        public byte MaximumFP { get; set; }
        public ushort FrogCoins { get; set; }
        public byte[] Equipment { get; set; }
        public byte[] Items { get; set; }
        public byte[] SpecialItems { get; set; }

        // Properties : Defense timing
        public byte DefenseStartL1 { get; set; }
        public byte DefenseStartL2 { get; set; }
        public byte DefenseEndL2 { get; set; }
        public byte DefenseEndL1 { get; set; }

        #endregion

        // Constructor
        public NewGame()
        {
            ReadFromROM();
        }

        #region Methods

        // Read/write ROM
        private void ReadFromROM()
        {
            // Status
            Coins = Bits.GetShort(rom, 0x3A00DB);
            CurrentFP = rom[0x3A00DD];
            MaximumFP = rom[0x3A00DE];
            FrogCoins = Bits.GetShort(rom, 0x3A00DF);
            // Inventory
            Equipment = new byte[30];
            for (int i = 0; i < Equipment.Length; i++)
                Equipment[i] = rom[i + 0x3A0090];
            Items = new byte[30];
            for (int i = 0; i < Items.Length; i++)
                Items[i] = rom[i + 0x3A00AE];
            SpecialItems = new byte[16];
            for (int i = 0; i < SpecialItems.Length; i++)
                SpecialItems[i] = rom[i + 0x3A00CC];
            // Defense timing
            DefenseStartL1 = rom[0x02C9B3];
            DefenseStartL2 = rom[0x02C9B9];
            DefenseEndL2 = rom[0x02C9BF];
            DefenseEndL1 = rom[0x02C9C5];
        }
        public void WriteToROM()
        {
            // Status
            Bits.SetShort(rom, 0x3A00DB, Coins);
            rom[0x3A00DD] = CurrentFP;
            rom[0x3A00DE] = MaximumFP;
            Bits.SetShort(rom, 0x3A00DF, FrogCoins);
            // Inventory
            for (int i = 0; i < Equipment.Length; i++)
                rom[i + 0x3A0090] = Equipment[i];
            for (int i = 0; i < Items.Length; i++)
                rom[i + 0x3A00AE] = Items[i];
            for (int i = 0; i < SpecialItems.Length; i++)
                rom[i + 0x3A00CC] = SpecialItems[i];
            // Defense timing
            rom[0x02C9B3] = DefenseStartL1;
            rom[0x02C9B9] = DefenseStartL2;
            rom[0x02C9BF] = DefenseEndL2;
            rom[0x02C9C5] = DefenseEndL1;
        }

        // Inherited
        public override void Clear()
        {
            // Status
            Coins = 0;
            CurrentFP = 0;
            MaximumFP = 0;
            FrogCoins = 0;
            // Inventory
            Equipment = new byte[30];
            Items = new byte[30];
            SpecialItems = new byte[16];
            // Defense timing
            DefenseEndL1 = 0;
            DefenseEndL2 = 0;
            DefenseStartL1 = 0;
            DefenseStartL2 = 0;
        }

        #endregion
    }
}
