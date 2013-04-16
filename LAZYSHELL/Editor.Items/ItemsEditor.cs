﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LAZYSHELL.Properties;

namespace LAZYSHELL
{
    public partial class ItemsEditor : Form
    {
        
        private long checksum;
        public long Checksum { get { return checksum; } set { checksum = value; } }
        private Settings settings = Settings.Default;
        public Items itemsEditor;
        public Shops shopsEditor;
        // constructor
        public ItemsEditor()
        {
            InitializeComponent();
            Do.AddShortcut(toolStrip3, Keys.Control | Keys.S, new EventHandler(save_Click));
            Do.AddShortcut(toolStrip3, Keys.F1, helpTips);
            Do.AddShortcut(toolStrip3, Keys.F2, baseConvertor);
            this.toolTip1.InitialDelay = 0;
            // create editors
            shopsEditor = new Shops(this);
            shopsEditor.TopLevel = false;
            shopsEditor.Dock = DockStyle.Left;
            panel1.Controls.Add(shopsEditor);
            shopsEditor.Visible = true;
            itemsEditor = new Items(shopsEditor);
            itemsEditor.TopLevel = false;
            itemsEditor.Dock = DockStyle.Left;
            panel1.Controls.Add(itemsEditor);
            itemsEditor.Visible = true;
            new ToolTipLabel(this, baseConvertor, helpTips);
            //
            new History(this);
            checksum = Do.GenerateChecksum(Model.Items, Model.ItemNames, Model.Shops);
        }
        // functions
        public void Assemble()
        {
            // Assemble the Model.Items
            int i;
            int length = 0x3120;
            for (i = 0; i < Model.Items.Length && length + (Model.Items[i].RawDescription != null ? Model.Items[i].RawDescription.Length : 0) < 0x40f1; i++)
                Model.Items[i].Assemble(ref length);
            length = 0xED44;
            for (; i < Model.Items.Length && length + (Model.Items[i].RawDescription != null ? Model.Items[i].RawDescription.Length : 0) < 0xffff; i++)
                Model.Items[i].Assemble(ref length);
            if (i != Model.Items.Length)
                MessageBox.Show("Not enough space to save all item descriptions.");
            foreach (Shop shop in Model.Shops)
                shop.Assemble();
            checksum = Do.GenerateChecksum(Model.Items, Model.ItemNames, Model.Shops);
        }
        #region Event handlers
        private void ItemsEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Do.GenerateChecksum(Model.Items, Model.ItemNames, Model.Shops) == checksum)
                return;
            DialogResult result = MessageBox.Show(
                "Items and shops have not been saved.\n\nWould you like to save changes?", "LAZY SHELL",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
                Assemble();
            else if (result == DialogResult.No)
            {
                Model.Items = null;
                Model.Shops = null;
                Model.ItemNames = null;
            }
            else if (result == DialogResult.Cancel)
            {
                e.Cancel = true;
                return;
            }
        }
        private void save_Click(object sender, EventArgs e)
        {
            Assemble();
        }
        private void importItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new IOElements((Element[])Model.Items, itemsEditor.Index, "IMPORT ITEMS...").ShowDialog();
            itemsEditor.RefreshItems();
        }
        private void importShopsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new IOElements((Element[])Model.Shops, shopsEditor.Index, "IMPORT SHOPS...").ShowDialog();
            shopsEditor.RefreshShops();
        }
        private void exportItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new IOElements((Element[])Model.Items, itemsEditor.Index, "EXPORT ITEMS...").ShowDialog();
        }
        private void exportShopsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new IOElements((Element[])Model.Shops, shopsEditor.Index, "EXPORT SHOPS...").ShowDialog();
        }
        private void clearItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ClearElements(Model.Items, itemsEditor.Index, "CLEAR ITEMS...").ShowDialog();
            itemsEditor.RefreshItems();
        }
        private void clearShopsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ClearElements(Model.Shops, shopsEditor.Index, "CLEAR SHOPS...").ShowDialog();
            shopsEditor.RefreshShops();
        }
        private void resetItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("You're about to undo all changes to the current item. Go ahead with reset?",
                "LAZY SHELL", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;
            itemsEditor.Item = new Item(itemsEditor.Index);
            itemsEditor.RefreshItems();
        }
        private void resetShopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("You're about to undo all changes to the current shop. Go ahead with reset?",
                "LAZY SHELL", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;
            shopsEditor.Shop = new Shop(shopsEditor.Index);
            shopsEditor.RefreshShops();
        }
        private void showItems_Click(object sender, EventArgs e)
        {
            itemsEditor.Visible = showItems.Checked;
        }
        private void showShops_Click(object sender, EventArgs e)
        {
            shopsEditor.Visible = showShops.Checked;
        }
        #endregion
    }
}
