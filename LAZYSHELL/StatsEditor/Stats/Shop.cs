using System;
using System.Collections.Generic;
using System.Text;

namespace LAZYSHELL.StatsEditor.Stats
{
    public class Shop
    {
        private byte[] data; public byte[] Data { get { return this.data; } set { this.data = value; } }
        
        #region Shop stats and accessors
        private int shopNum; public int ShopNum { get{ return this.shopNum; } set { this.shopNum = value; } }
        private bool buyFrogCoinOne; public bool BuyFrogCoinOne { get { return this.buyFrogCoinOne; } set { this.buyFrogCoinOne = value; } }
        private bool buyFrogCoin; public bool BuyFrogCoin { get { return this.buyFrogCoin; } set { this.buyFrogCoin = value; } }
        private bool buyOnlyA; public bool BuyOnlyA { get { return this.buyOnlyA; } set { this.buyOnlyA = value; } }
        private bool buyOnlyB; public bool BuyOnlyB { get{ return this.buyOnlyB; } set { this.buyOnlyB = value; } }
        private bool discount6; public bool Discount6 { get { return this.discount6; } set { this.discount6 = value; } }
        private bool discount12; public bool Discount12 { get { return this.discount12; } set { this.discount12 = value; } }
        private bool discount25; public bool Discount25 { get { return this.discount25; } set { this.discount25 = value; } }
        private bool discount50; public bool Discount50 { get { return this.discount50; } set { this.discount50 = value; } }
        private byte[] items = new byte[15]; public byte[] Items { get { return this.items; } set { this.items = value; } }
        #endregion
        
        public Shop(byte[] data, int shopNum)
        {
            this.data = data;
            this.shopNum = shopNum;
            InitializeShop();
        }
        
        private void InitializeShop()
        {
            byte temp = 0;
            int offset = 0;

            offset = (shopNum * 16) + 0x3A44DF;

            temp = BitManager.GetByte(data, offset); offset ++; 

            // SHOP OPTIONS
            buyFrogCoinOne = (temp & 0x01) == 0x01;  		// Buy with Frog Coins only once
            buyFrogCoin = (temp & 0x02) == 0x02;		// Buy with Frog Coins
            buyOnlyA = (temp & 0x04) == 0x04;		// Buy only, no selling
            buyOnlyB = (temp & 0x08) == 0x08;		// Buy only, no selling

            // PURCHASE DISCOUNTS
            discount6 = (temp & 0x10) == 0x10;			// 6% discount
            discount12 = (temp & 0x20) == 0x20;			// 12% discount
            discount25 = (temp & 0x40) == 0x40;			// 25% discount
            discount50 = (temp & 0x80) == 0x80;			// 50% discount

            for (int i = 0; i < 15; i++)
            {
                items[i] = BitManager.GetByte(data, offset);
                offset++;
            }
        }
        public void Assemble()
        {
            int offset = 0;

            offset = (shopNum * 16) + 0x3A44DF;

            BitManager.SetBit(data, offset, 0, buyFrogCoinOne);
            BitManager.SetBit(data, offset, 1, buyFrogCoin);
            BitManager.SetBit(data, offset, 2, buyOnlyA);
            BitManager.SetBit(data, offset, 3, buyOnlyB);
            BitManager.SetBit(data, offset, 4, discount6);
            BitManager.SetBit(data, offset, 5, discount12);
            BitManager.SetBit(data, offset, 6, discount25);
            BitManager.SetBit(data, offset, 7, discount50);
            offset++;

            for (int i = 0; i < 15; i++)
            {
                BitManager.SetByte(data, offset, items[i]);
                offset++;
            }
        }
        public void Clear()
        {
            buyFrogCoinOne = false;
            buyFrogCoin = false;
            buyOnlyA = false;
            buyOnlyB = false;
            discount6 = false;
            discount12 = false;
            discount25 = false;
            discount50 = false;
            items = new byte[15];
        }    
    }
}
