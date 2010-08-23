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
    public partial class ItemsEditor : Form
    {
        private Model model = State.Instance.Model;
        private Settings settings = Settings.Default;
        public Items itemsEditor;
        public Shops shopsEditor;
        public ItemsEditor()
        {
            settings.Keystrokes[0x20] = "\x20";
            settings.KeystrokesMenu[0x20] = "\x20";
            InitializeComponent();
            Do.AddShortcut(toolStrip3, Keys.Control | Keys.S, new EventHandler(save_Click));
            Do.AddShortcut(toolStrip3, Keys.F1, helpTips);
            Do.AddShortcut(toolStrip3, Keys.F2, baseConversion);
            this.toolTip1.InitialDelay = 0;
            // create editors
            shopsEditor = new Shops();
            shopsEditor.TopLevel = false;
            shopsEditor.Dock = DockStyle.Left;
            shopsEditor.SetToolTips(toolTip1);
            panel1.Controls.Add(shopsEditor);
            shopsEditor.Visible = true;
            itemsEditor = new Items(shopsEditor);
            itemsEditor.TopLevel = false;
            itemsEditor.Dock = DockStyle.Left;
            itemsEditor.SetToolTips(toolTip1);
            panel1.Controls.Add(itemsEditor);
            itemsEditor.Visible = true;
            new ToolTipLabel(this, toolTip1, baseConversion, helpTips);
        }
        public void Assemble()
        {
            // Assemble the model.Items
            int i;
            ushort len = 0x3120;
            for (i = 0; i < model.Items.Length && len + (model.Items[i].RawDescription != null ? model.Items[i].RawDescription.Length : 0) < 0x40f1; i++)
                len += model.Items[i].Assemble(len);
            len = 0xed44;
            for (; i < model.Items.Length && len + (model.Items[i].RawDescription != null ? model.Items[i].RawDescription.Length : 0) < 0xffff; i++)
                len += model.Items[i].Assemble(len);
            if (i != model.Items.Length)
                System.Windows.Forms.MessageBox.Show("Item Descriptions total length exceeds max size, decrease total size to save correctly.\nNote: not all text has been saved.");
            foreach (Shop shop in model.Shops)
                shop.Assemble();
        }
        private void ItemsEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Items and shops have not been saved.\n\nWould you like to save changes?", "LAZY SHELL",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
                Assemble();
            else if (result == DialogResult.No)
            {
                model.Items = null;
                model.Shops = null;
                model.ItemNames = null;
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
            new IOElements((Element[])model.Items, itemsEditor.Index, "IMPORT ITEMS...").ShowDialog();
            itemsEditor.RefreshItems();
        }
        private void importShopsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new IOElements((Element[])model.Shops, shopsEditor.Index, "IMPORT SHOPS...").ShowDialog();
            shopsEditor.RefreshShops();
        }
        private void exportItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new IOElements((Element[])model.Items, itemsEditor.Index, "EXPORT ITEMS...").ShowDialog();
        }
        private void exportShopsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new IOElements((Element[])model.Shops, shopsEditor.Index, "EXPORT SHOPS...").ShowDialog();
        }
        private void clearItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ClearElements(model.Items, itemsEditor.Index, "CLEAR ITEMS...").ShowDialog();
            itemsEditor.RefreshItems();
        }
        private void clearShopsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ClearElements(model.Shops, shopsEditor.Index, "CLEAR SHOPS...").ShowDialog();
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
    }
}
