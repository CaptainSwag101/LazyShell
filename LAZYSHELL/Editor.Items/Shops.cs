using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LAZYSHELL.Properties;

namespace LAZYSHELL
{
    public partial class Shops : Form
    {
        private Settings settings = Settings.Default;
        private Shop[] shops { get { return Model.Shops; } set { Model.Shops = value; } }
        private Shop shop { get { return shops[index]; } set { shops[index] = value; } }
        public Shop Shop { get { return shop; } set { shop = value; } }
        private bool updating = false;
        private int index { get { return (int)shopName.SelectedIndex; } set { shopName.SelectedIndex = value; } }
        public int Index { get { return index; } set { index = value; } }
        private ComboBox selectedItem;
        // Constructor
        public Shops()
        {
            InitializeComponent();
            InitializeStrings();
            index = 0;
            RefreshShops();
        }
        // functions
        private void InitializeStrings()
        {
            for (int i = 0; i < settings.ShopNames.Count; i++)
                shopName.Items.Add(settings.ShopNames[i]);
            this.shopItem1.Items.Clear();
            this.shopItem2.Items.Clear();
            this.shopItem3.Items.Clear();
            this.shopItem4.Items.Clear();
            this.shopItem5.Items.Clear();
            this.shopItem6.Items.Clear();
            this.shopItem7.Items.Clear();
            this.shopItem8.Items.Clear();
            this.shopItem9.Items.Clear();
            this.shopItem10.Items.Clear();
            this.shopItem11.Items.Clear();
            this.shopItem12.Items.Clear();
            this.shopItem13.Items.Clear();
            this.shopItem14.Items.Clear();
            this.shopItem15.Items.Clear();
            this.shopItem1.Items.AddRange(Model.ItemNames.Names);
            this.shopItem2.Items.AddRange(Model.ItemNames.Names);
            this.shopItem3.Items.AddRange(Model.ItemNames.Names);
            this.shopItem4.Items.AddRange(Model.ItemNames.Names);
            this.shopItem5.Items.AddRange(Model.ItemNames.Names);
            this.shopItem6.Items.AddRange(Model.ItemNames.Names);
            this.shopItem7.Items.AddRange(Model.ItemNames.Names);
            this.shopItem8.Items.AddRange(Model.ItemNames.Names);
            this.shopItem9.Items.AddRange(Model.ItemNames.Names);
            this.shopItem10.Items.AddRange(Model.ItemNames.Names);
            this.shopItem11.Items.AddRange(Model.ItemNames.Names);
            this.shopItem12.Items.AddRange(Model.ItemNames.Names);
            this.shopItem13.Items.AddRange(Model.ItemNames.Names);
            this.shopItem14.Items.AddRange(Model.ItemNames.Names);
            this.shopItem15.Items.AddRange(Model.ItemNames.Names);
        }
        public void ResortStrings()
        {
            updating = true;
            this.shopItem1.SelectedIndex = Model.ItemNames.GetIndexFromNum(shop.Items[0]);
            this.shopItem2.SelectedIndex = Model.ItemNames.GetIndexFromNum(shop.Items[1]);
            this.shopItem3.SelectedIndex = Model.ItemNames.GetIndexFromNum(shop.Items[2]);
            this.shopItem4.SelectedIndex = Model.ItemNames.GetIndexFromNum(shop.Items[3]);
            this.shopItem5.SelectedIndex = Model.ItemNames.GetIndexFromNum(shop.Items[4]);
            this.shopItem6.SelectedIndex = Model.ItemNames.GetIndexFromNum(shop.Items[5]);
            this.shopItem7.SelectedIndex = Model.ItemNames.GetIndexFromNum(shop.Items[6]);
            this.shopItem8.SelectedIndex = Model.ItemNames.GetIndexFromNum(shop.Items[7]);
            this.shopItem9.SelectedIndex = Model.ItemNames.GetIndexFromNum(shop.Items[8]);
            this.shopItem10.SelectedIndex = Model.ItemNames.GetIndexFromNum(shop.Items[9]);
            this.shopItem11.SelectedIndex = Model.ItemNames.GetIndexFromNum(shop.Items[10]);
            this.shopItem12.SelectedIndex = Model.ItemNames.GetIndexFromNum(shop.Items[11]);
            this.shopItem13.SelectedIndex = Model.ItemNames.GetIndexFromNum(shop.Items[12]);
            this.shopItem14.SelectedIndex = Model.ItemNames.GetIndexFromNum(shop.Items[13]);
            this.shopItem15.SelectedIndex = Model.ItemNames.GetIndexFromNum(shop.Items[14]);
            updating = false;
        }
        public void RefreshShops()
        {
            if (updating) return;
            updating = true;
            this.shopLabel.Text = settings.ShopNames[index];
            this.shopItem1.SelectedIndex = Model.ItemNames.GetIndexFromNum(shop.Items[0]);
            this.shopItem2.SelectedIndex = Model.ItemNames.GetIndexFromNum(shop.Items[1]);
            this.shopItem3.SelectedIndex = Model.ItemNames.GetIndexFromNum(shop.Items[2]);
            this.shopItem4.SelectedIndex = Model.ItemNames.GetIndexFromNum(shop.Items[3]);
            this.shopItem5.SelectedIndex = Model.ItemNames.GetIndexFromNum(shop.Items[4]);
            this.shopItem6.SelectedIndex = Model.ItemNames.GetIndexFromNum(shop.Items[5]);
            this.shopItem7.SelectedIndex = Model.ItemNames.GetIndexFromNum(shop.Items[6]);
            this.shopItem8.SelectedIndex = Model.ItemNames.GetIndexFromNum(shop.Items[7]);
            this.shopItem9.SelectedIndex = Model.ItemNames.GetIndexFromNum(shop.Items[8]);
            this.shopItem10.SelectedIndex = Model.ItemNames.GetIndexFromNum(shop.Items[9]);
            this.shopItem11.SelectedIndex = Model.ItemNames.GetIndexFromNum(shop.Items[10]);
            this.shopItem12.SelectedIndex = Model.ItemNames.GetIndexFromNum(shop.Items[11]);
            this.shopItem13.SelectedIndex = Model.ItemNames.GetIndexFromNum(shop.Items[12]);
            this.shopItem14.SelectedIndex = Model.ItemNames.GetIndexFromNum(shop.Items[13]);
            this.shopItem15.SelectedIndex = Model.ItemNames.GetIndexFromNum(shop.Items[14]);
            this.shopBuyOptions.SetItemChecked(0, shop.BuyFrogCoinOne);
            this.shopBuyOptions.SetItemChecked(1, shop.BuyFrogCoin);
            this.shopBuyOptions.SetItemChecked(2, shop.BuyOnlyA);
            this.shopBuyOptions.SetItemChecked(3, shop.BuyOnlyB);
            this.shopDiscounts.SetItemChecked(0, shop.Discount6);
            this.shopDiscounts.SetItemChecked(1, shop.Discount12);
            this.shopDiscounts.SetItemChecked(2, shop.Discount25);
            this.shopDiscounts.SetItemChecked(3, shop.Discount50);
            updating = false;
        }
        public void SetToolTips(ToolTip toolTip1)
        {
            //Shops
            this.shopName.ToolTipText =
                "The shop to edit by label.\n" +
                "These shop \"names\" are simply labels used to identify the \n" +
                "shops. The user may change the label.";
            this.shopLabel.ToolTipText =
                "The currently selected shop's label. Use this to label / \n" +
                "identify a shop. This is not read from anywhere in the ROM \n" +
                "and is exclusively part of the editor. Changing this will have \n" +
                "no effect on the game.";
            toolTip1.SetToolTip(this.shopBuyOptions,
                "\"Buy with Frog Coins, one product each\" is used, for \n" +
                "example, by the \"Frog Disciple\" in Seaside Town. Only one \n" +
                "of each product can be bought with Frog Coins only.\n\n" +
                "\"Buy with Frog Coins\" is the same as above, only the \n" +
                "product(s) can be bought as many times as afforded. The \n" +
                "\"Frog Coin Emporium\" uses this property.\n\n" +
                "\"Buy only, no selling\" is obvious: only buying is allowed in \n" +
                "the shop, and items cannot be sold. Both of these \n" +
                "properties are exactly the same, there is no difference \n" +
                "(they are merely two separate bits that each have the \n" +
                "same property).");
            toolTip1.SetToolTip(this.shopDiscounts,
                "These will lower the prices of the items being sold, \n" +
                "according to their \"Coin Value\". For example, a Juice Bar \n" +
                "has a discount of 50%, which means the KeroKeroCola it \n" +
                "sells (which is normally 400 coins) is 50% less than 400 \n" +
                "coins, ie. 200 coins.\n" +
                "These can be combined, ie. if 50% and 25% are both \n" +
                "checked, then the discount is 75%.");
        }
        #region Event Handlers
        private void shopName_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshShops();
        }
        private void shopName_DrawItem(object sender, DrawItemEventArgs e)
        {
            Do.DrawName(
                sender, e, new BattleDialoguePreview(), Lists.Convert(settings.ShopNames),
                Model.FontDialogue, Model.FontPaletteMenu.Palette, 8, 10, 0, 0, false, false, Model.MenuBackground_);
        }
        private void shopLabel_TextChanged(object sender, EventArgs e)
        {
            int index = this.index;
            if (settings.ShopNames[index].CompareTo(shopLabel.Text) != 0)
            {
                settings.ShopNames[index] = this.shopLabel.Text;
                shopName.BeginUpdate();
                shopName.Items.Clear();
                for (int i = 0; i < settings.ShopNames.Count; i++)
                    shopName.Items.Add(settings.ShopNames[i]);
                shopName.SelectedIndex = index;
                shopName.EndUpdate();
            }
        }
        private void itemName_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;
            Do.DrawName(
                sender, e, new BattleDialoguePreview(), Model.ItemNames, Model.FontMenu,
                Model.FontPaletteMenu.Palette, 8, 10, 0, 128, false, false, Model.MenuBackground_);
        }
        private void shopItem1_SelectedIndexChanged(object sender, EventArgs e)
        {
            shop.Items[0] = (byte)Model.ItemNames.GetNumFromIndex(this.shopItem1.SelectedIndex);
        }
        private void shopItem2_SelectedIndexChanged(object sender, EventArgs e)
        {
            shop.Items[1] = (byte)Model.ItemNames.GetNumFromIndex(this.shopItem2.SelectedIndex);
        }
        private void shopItem3_SelectedIndexChanged(object sender, EventArgs e)
        {
            shop.Items[2] = (byte)Model.ItemNames.GetNumFromIndex(this.shopItem3.SelectedIndex);
        }
        private void shopItem4_SelectedIndexChanged(object sender, EventArgs e)
        {
            shop.Items[3] = (byte)Model.ItemNames.GetNumFromIndex(this.shopItem4.SelectedIndex);
        }
        private void shopItem5_SelectedIndexChanged(object sender, EventArgs e)
        {
            shop.Items[4] = (byte)Model.ItemNames.GetNumFromIndex(this.shopItem5.SelectedIndex);
        }
        private void shopItem6_SelectedIndexChanged(object sender, EventArgs e)
        {
            shop.Items[5] = (byte)Model.ItemNames.GetNumFromIndex(this.shopItem6.SelectedIndex);
        }
        private void shopItem7_SelectedIndexChanged(object sender, EventArgs e)
        {
            shop.Items[6] = (byte)Model.ItemNames.GetNumFromIndex(this.shopItem7.SelectedIndex);
        }
        private void shopItem8_SelectedIndexChanged(object sender, EventArgs e)
        {
            shop.Items[7] = (byte)Model.ItemNames.GetNumFromIndex(this.shopItem8.SelectedIndex);
        }
        private void shopItem9_SelectedIndexChanged(object sender, EventArgs e)
        {
            shop.Items[8] = (byte)Model.ItemNames.GetNumFromIndex(this.shopItem9.SelectedIndex);
        }
        private void shopItem10_SelectedIndexChanged(object sender, EventArgs e)
        {
            shop.Items[9] = (byte)Model.ItemNames.GetNumFromIndex(this.shopItem10.SelectedIndex);
        }
        private void shopItem11_SelectedIndexChanged(object sender, EventArgs e)
        {
            shop.Items[10] = (byte)Model.ItemNames.GetNumFromIndex(this.shopItem11.SelectedIndex);
        }
        private void shopItem12_SelectedIndexChanged(object sender, EventArgs e)
        {
            shop.Items[11] = (byte)Model.ItemNames.GetNumFromIndex(this.shopItem12.SelectedIndex);
        }
        private void shopItem13_SelectedIndexChanged(object sender, EventArgs e)
        {
            shop.Items[12] = (byte)Model.ItemNames.GetNumFromIndex(this.shopItem13.SelectedIndex);
        }
        private void shopItem14_SelectedIndexChanged(object sender, EventArgs e)
        {
            shop.Items[13] = (byte)Model.ItemNames.GetNumFromIndex(this.shopItem14.SelectedIndex);
        }
        private void shopItem15_SelectedIndexChanged(object sender, EventArgs e)
        {
            shop.Items[14] = (byte)Model.ItemNames.GetNumFromIndex(this.shopItem15.SelectedIndex);
        }
        private void shopBuyOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            shop.BuyFrogCoinOne = this.shopBuyOptions.GetItemChecked(0);
            shop.BuyFrogCoin = this.shopBuyOptions.GetItemChecked(1);
            shop.BuyOnlyA = this.shopBuyOptions.GetItemChecked(2);
            shop.BuyOnlyB = this.shopBuyOptions.GetItemChecked(3);
        }
        private void shopDiscounts_SelectedIndexChanged(object sender, EventArgs e)
        {
            shop.Discount6 = this.shopDiscounts.GetItemChecked(0);
            shop.Discount12 = this.shopDiscounts.GetItemChecked(1);
            shop.Discount25 = this.shopDiscounts.GetItemChecked(2);
            shop.Discount50 = this.shopDiscounts.GetItemChecked(3);
        }
        #endregion

        private void moveUp_Click(object sender, EventArgs e)
        {
            if (selectedItem == null)
            {
                MessageBox.Show("Must select an item first.", "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            int index = Convert.ToInt32(selectedItem.Name.Substring(8)) - 1;
            if (index == 0) return;
            int temp = shop.Items[index - 1];
            shop.Items[index - 1] = shop.Items[index];
            shop.Items[index] = (byte)temp;
            selectedItem = (ComboBox)this.Controls.Find("shopItem" + index.ToString(), true)[0];
            RefreshShops();
            selectedItem.Focus();
        }
        private void moveDown_Click(object sender, EventArgs e)
        {
            if (selectedItem == null)
            {
                MessageBox.Show("Must select an item first.", "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            int index = Convert.ToInt32(selectedItem.Name.Substring(8)) - 1;
            if (index == 14) return;
            int temp = shop.Items[index + 1];
            shop.Items[index + 1] = shop.Items[index];
            shop.Items[index] = (byte)temp;
            selectedItem = (ComboBox)this.Controls.Find("shopItem" + (index + 2).ToString(), true)[0];
            RefreshShops();
            selectedItem.Focus();
        }
        private void shopItem_Click(object sender, EventArgs e)
        {
            selectedItem = (ComboBox)sender;
        }
    }
}
