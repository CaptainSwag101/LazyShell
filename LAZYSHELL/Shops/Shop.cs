using System;
using System.Collections.Generic;
using System.Text;

namespace LazyShell.Shops
{
    [Serializable()]
    public class Shop : Element
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
        public byte[] Items { get; set; }
        public string[] ItemNames
        {
            get
            {
                string[] names = new string[15];
                for (int i = 0; i < names.Length; i++)
                    names[i] = LazyShell.Items.Model.Names.GetUnsortedName(Items[i]);
                return names;
            }
        }
        public bool BuyFrogCoinOne { get; set; }
        public bool BuyFrogCoin { get; set; }
        public bool BuyOnlyA { get; set; }
        public bool BuyOnlyB { get; set; }
        public byte Discount { get; set; }

        #endregion

        // Constructor
        public Shop(int index)
        {
            this.Index = index;
            ReadFromROM();
        }

        #region Methods

        // Assemblers
        private void ReadFromROM()
        {
            int offset = (Index * 16) + 0x3A44DF;
            byte temp = rom[offset++];
            // shop options
            BuyFrogCoinOne = (temp & 0x01) == 0x01;  		// Buy with Frog Coins only once
            BuyFrogCoin = (temp & 0x02) == 0x02;		// Buy with Frog Coins
            BuyOnlyA = (temp & 0x04) == 0x04;		// Buy only, no selling
            BuyOnlyB = (temp & 0x08) == 0x08;		// Buy only, no selling
            // purchase discounts
            Discount = (byte)(temp >> 4);
            Items = new byte[15];
            for (int i = 0; i < 15; i++)
                Items[i] = rom[offset++];
        }
        public void WriteToROM()
        {
            int offset = (Index * 16) + 0x3A44DF;
            Bits.SetBit(rom, offset, 0, BuyFrogCoinOne);
            Bits.SetBit(rom, offset, 1, BuyFrogCoin);
            Bits.SetBit(rom, offset, 2, BuyOnlyA);
            Bits.SetBit(rom, offset, 3, BuyOnlyB);
            rom[offset] |= (byte)(Discount << 4);
            for (int i = 0; i < 15; i++)
                rom[offset++] = Items[i];
        }

        // Inherited
        public override void Clear()
        {
            BuyFrogCoinOne = false;
            BuyFrogCoin = false;
            BuyOnlyA = false;
            BuyOnlyB = false;
            Discount = 0;
            Items = new byte[15];
        }

        #endregion
    }
}
