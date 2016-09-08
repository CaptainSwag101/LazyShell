using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LazyShell.Properties;

namespace LazyShell.Shops
{
    public partial class OwnerForm : Controls.NewForm
    {
        #region Variables

        private Settings settings;
        private Shop[] shops
        {
            get { return Model.Shops; }
            set { Model.Shops = value; }
        }
        public Shop Shop
        {
            get { return shops[Index]; }
            set { shops[Index] = value; }
        }
        public int Index
        {
            get { return (int)name.SelectedIndex; }
            set { name.SelectedIndex = value; }
        }
        private int shopItem
        {
            get { return Shop.Items[shopItems.SelectedIndex]; }
            set { Shop.Items[shopItems.SelectedIndex] = (byte)value; }
        }
        private EditLabel labelWindow;

        #endregion

        // Constructor
        public OwnerForm()
        {
            InitializeComponent();
            InitializeVariables();
            InitializeListControls();
            CreateHelperForms();
            LoadProperties();
            //
            this.History = new History(this, name, null);
        }

        #region Methods

        // Initialization
        private void InitializeVariables()
        {
            this.settings = Settings.Default;
        }
        private void InitializeListControls()
        {
            this.Updating = true;
            //
            name.Items.AddRange(Lists.Shops);
            name.SelectedIndex = 0;
            shopItemName.Items.Clear();
            shopItemName.Items.AddRange(Items.Model.Names.Names);
            //
            this.Updating = false;
        }
        private void CreateHelperForms()
        {
            labelWindow = new EditLabel(name, null, "Shops", true);
        }
        public void LoadProperties()
        {
            this.Updating = true;
            shopItems.Items.Clear();
            for (int i = 0; i < 15; i++)
            {
                var itemName = Items.Model.Names.GetUnsortedName(Shop.Items[i]);
                shopItems.Items.Add(itemName.Trim());
            }
            shopItems.SelectedIndex = 0;
            shopItemName.SelectedIndex = Items.Model.Names.GetSortedIndex(shopItem);
            this.buyOptions.SetItemChecked(0, Shop.BuyFrogCoinOne);
            this.buyOptions.SetItemChecked(1, Shop.BuyFrogCoin);
            this.buyOptions.SetItemChecked(2, Shop.BuyOnlyA);
            this.buyOptions.SetItemChecked(3, Shop.BuyOnlyB);
            this.discount.SelectedIndex = Shop.Discount;
            this.Updating = false;
        }

        // Read/write ROM
        public void WriteToROM()
        {
            foreach (var shop in Model.Shops)
                shop.WriteToROM();
        }

        #endregion

        #region Event Handlers

        // OwnerForm
        private void OwnerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!this.Modified)
                return;
            var result = MessageBox.Show(
                "Shops have not been saved.\n\nWould you like to save changes?",
                "LAZY SHELL", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
                WriteToROM();
            else if (result == DialogResult.No)
                Model.ClearAll();
            else if (result == DialogResult.Cancel)
                e.Cancel = true;
        }

        // File management
        private void save_Click(object sender, EventArgs e)
        {
            WriteToROM();
        }
        private void import_Click(object sender, EventArgs e)
        {
            new IOElements(Model.Shops, IOMode.Import, Index, "IMPORT SHOPS...").ShowDialog();
            LoadProperties();
        }
        private void export_Click(object sender, EventArgs e)
        {
            new IOElements(Model.Shops, IOMode.Export, Index, "EXPORT SHOPS...").ShowDialog();
        }
        private void reset_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("You're about to undo all changes to the current shop. Go ahead with reset?",
                "LAZY SHELL", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;
            Shop = new Shop(Index);
            LoadProperties();
        }
        private void clear_Click(object sender, EventArgs e)
        {
            new ClearElements(Model.Shops, Index, "CLEAR SHOPS...").ShowDialog();
            LoadProperties();
        }

        // Navigators
        private void shopName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.Updating)
                LoadProperties();
        }
        private void shopName_DrawItem(object sender, DrawItemEventArgs e)
        {
            Do.DrawName(sender, e, new BattleDialoguePreview(), Lists.Shops, Fonts.Model.Dialogue,
                Fonts.Model.Palette_Menu.Palettes[0], 0, 10, 0, 0, false, false, Menus.Model.ShopBG);
        }

        // Properties
        private void shopItems_DrawItem(object sender, DrawItemEventArgs e)
        {
            Do.DrawName(sender, e, new BattleDialoguePreview(), Shop.ItemNames, Fonts.Model.Menu,
                Fonts.Model.Palette_Menu.Palettes[0], 0, 10, 0, 0, false, false, Menus.Model.ShopBG);
        }
        private void shopItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            shopItemName.SelectedIndex = Items.Model.Names.GetSortedIndex(shopItem);
        }
        private void moveUp_Click(object sender, EventArgs e)
        {
            if (shopItems.SelectedIndex < 0)
            {
                MessageBox.Show("Must select an item first.",
                    "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            int index = shopItems.SelectedIndex;
            if (index == 0)
                return;
            int temp = Shop.Items[index - 1];
            Shop.Items[index - 1] = Shop.Items[index];
            Shop.Items[index] = (byte)temp;
            LoadProperties();
        }
        private void moveDown_Click(object sender, EventArgs e)
        {
            if (shopItems.SelectedIndex < 0)
            {
                MessageBox.Show("Must select an item first.",
                    "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            int index = shopItems.SelectedIndex;
            if (index >= shopItems.Items.Count - 1)
                return;
            int temp = Shop.Items[index + 1];
            Shop.Items[index + 1] = Shop.Items[index];
            Shop.Items[index] = (byte)temp;
            LoadProperties();
        }
        private void shopItemName_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0)
                return;
            Do.DrawName(sender, e, new BattleDialoguePreview(), Items.Model.Names, Fonts.Model.Menu,
                Fonts.Model.Palette_Menu.Palettes[0], 8, 10, 0, 128, true, false, Menus.Model.ShopBG);
        }
        private void shopItemName_SelectedIndexChanged(object sender, EventArgs e)
        {
            shopItemNum.Value = Items.Model.Names.GetUnsortedIndex(shopItemName.SelectedIndex);
            shopItem = (byte)Items.Model.Names.GetUnsortedIndex(shopItemName.SelectedIndex);
            if (!this.Updating)
                shopItems.Invalidate(shopItems.GetItemRectangle(shopItems.SelectedIndex));
        }
        private void shopItemNum_ValueChanged(object sender, EventArgs e)
        {
            shopItemName.SelectedIndex = Items.Model.Names.GetSortedIndex((int)shopItemNum.Value);
        }
        private void buyOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            Shop.BuyFrogCoinOne = this.buyOptions.GetItemChecked(0);
            Shop.BuyFrogCoin = this.buyOptions.GetItemChecked(1);
            Shop.BuyOnlyA = this.buyOptions.GetItemChecked(2);
            Shop.BuyOnlyB = this.buyOptions.GetItemChecked(3);
        }
        private void discount_SelectedIndexChanged(object sender, EventArgs e)
        {
            Shop.Discount = (byte)discount.SelectedIndex;
        }

        #endregion
    }
}
