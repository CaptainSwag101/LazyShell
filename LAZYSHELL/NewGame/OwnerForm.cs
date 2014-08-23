using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Forms;
using LAZYSHELL.Properties;

namespace LAZYSHELL.NewGame
{
    public partial class OwnerForm : Controls.NewForm
    {
        #region Variables

        private Settings settings = Settings.Default;
        public int Index
        {
            get { return allyName.SelectedIndex; }
            set { allyName.SelectedIndex = value; }
        }
        private int slotIndex
        {
            get { return (int)slotNum.Value; }
            set { slotNum.Value = value; }
        }
        private NewGame newGame
        {
            get { return Model.NewGame; }
            set { Model.NewGame = value; }
        }
        private Ally[] allies
        {
            get { return Model.Allies; }
            set { Model.Allies = value; }
        }
        private Ally ally
        {
            get { return allies[Index]; }
            set { allies[Index] = value; }
        }
        
        #endregion

        // Constructor
        public OwnerForm()
        {
            InitializeComponent();
            // Add shortcuts to ToolStripButton controls
            Do.AddShortcut(toolStrip3, Keys.Control | Keys.S, new EventHandler(save_Click));
            Do.AddShortcut(toolStrip3, Keys.F1, helpTips);
            Do.AddShortcut(toolStrip3, Keys.F2, baseConvertor);
            // Set list control items using sorted lists
            InitializeListControls();
            // Set control values to class properties
            LoadAllyProperties();
            LoadInventoryProperties();
            // Set control values - Status
            this.coins.Value = newGame.Coins;
            this.frogCoins.Value = newGame.FrogCoins;
            this.currentFP.Value = newGame.CurrentFP;
            this.maximumFP.Value = newGame.MaximumFP;
            // Set control values - Defense timing
            this.defenseStartL1.Value = newGame.DefenseStartL1;
            this.defenseStartL2.Value = newGame.DefenseStartL2;
            this.defenseEndL2.Value = newGame.DefenseEndL2;
            this.defenseEndL1.Value = newGame.DefenseEndL1;
            // Create ToolTipLabel for form
            new ToolTipLabel(this, baseConvertor, helpTips);
            // Create history instance for form
            this.History = new History(this, allyName, null);
        }

        #region Methods

        private void InitializeListControls()
        {
            this.Updating = true;
            //
            this.allyName.Items.Clear();
            for (int i = 0; i < allies.Length; i++)
                this.allyName.Items.Add(allies[i].ToString());
            this.allyName.SelectedIndex = 0;
            this.magic.Items.Clear();
            for (int i = 0; i < 32; i++)
                this.magic.Items.Add(new string(Magic.Model.Spells[i].Name));
            this.weapon.Items.Clear();
            this.weapon.Items.AddRange(Items.Model.Names.Names);
            this.accessory.Items.Clear();
            this.accessory.Items.AddRange(Items.Model.Names.Names);
            this.armor.Items.Clear();
            this.armor.Items.AddRange(Items.Model.Names.Names);
            this.item.Items.Clear();
            this.item.Items.AddRange(Items.Model.Names.Names);
            this.specialItem.Items.Clear();
            this.specialItem.Items.AddRange(Items.Model.Names.Names);
            this.equipment.Items.Clear();
            this.equipment.Items.AddRange(Items.Model.Names.Names);
            //
            this.Updating = false;
        }
        public void LoadAllyProperties()
        {
            if (this.Updating)
                return;
            this.Updating = true;

            // Navigator
            this.allyName.SelectedIndex = Index;
            this.allyNameText.Text = Do.RawToASCII(ally.Name, Lists.KeystrokesMenu);

            // Starting stats
            this.level.Value = ally.Level;
            this.attack.Value = ally.Attack;
            this.defense.Value = ally.Defense;
            this.mgAttack.Value = ally.MgAttack;
            this.mgDefense.Value = ally.MgDefense;
            this.speed.Value = ally.Speed;
            this.experience.Value = ally.Experience;
            this.currentHP.Value = ally.CurrentHP;
            this.maximumHP.Value = ally.MaxHP;

            // Starting equipment
            this.weapon.SelectedIndex = Items.Model.Names.GetSortedIndex(ally.Weapon);
            this.armor.SelectedIndex = Items.Model.Names.GetSortedIndex(ally.Armor);
            this.accessory.SelectedIndex = Items.Model.Names.GetSortedIndex(ally.Accessory);

            // Starting magic
            for (int i = 0; i < ally.Magic.Length; i++)
                this.magic.SetItemChecked(i, ally.Magic[i]);
            this.allyName.Invalidate();

            // Finished
            this.Updating = false;
        }
        private void LoadInventoryProperties()
        {
            this.Updating = true;
            //
            this.item.SelectedIndex = Items.Model.Names.GetSortedIndex(newGame.Items[slotIndex]);
            if (this.slotNum.Value <= 14)
            {
                this.specialItem.Enabled = true;
                this.specialItem.SelectedIndex = Items.Model.Names.GetSortedIndex(newGame.SpecialItems[slotIndex]);
            }
            else
            {
                this.specialItem.Enabled = false;
                this.specialItem.SelectedIndex = 0;
            }
            this.equipment.SelectedIndex = Items.Model.Names.GetSortedIndex(newGame.Equipment[slotIndex]);
            //
            this.Updating = false;
        }
        public void ResetAllyProperties()
        {
            if (MessageBox.Show("You're about to undo all changes to the current character. Go ahead with reset?",
                "LAZY SHELL", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;
            ally = new Ally(Index);
            LoadAllyProperties();
        }

        // Saving
        public void WriteToROM()
        {
            this.newGame.WriteToROM();
            this.Modified = false;
        }

        #endregion

        #region Event Handlers

        // OwnerForm
        private void OwnerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!this.Modified)
                return;
            // Prompt user to save
            var result = MessageBox.Show("New game stats have not been saved.\n\nWould you like to save changes?",
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
            new IOElements(Model.Allies, IOMode.Import, Index, "IMPORT ALLIES...").ShowDialog();
            LoadAllyProperties();
        }
        private void export_Click(object sender, EventArgs e)
        {
            new IOElements(Model.Allies, IOMode.Export, Index, "EXPORT ALLIES...").ShowDialog();
        }
        private void clear_Click(object sender, EventArgs e)
        {
            new ClearElements(Model.Allies as Element[], Index, "CLEAR ALLIES...").ShowDialog();
        }
        private void reset_Click(object sender, EventArgs e)
        {
            ResetAllyProperties();
        }
        private void itemName_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0)
                return;
            Do.DrawName(sender, e, new BattleDialoguePreview(), Items.Model.Names, Fonts.Model.Menu,
                Fonts.Model.Palette_Menu.Palettes[0], 8, 10, 0, 128, true, false, Menus.Model.MenuBG_256x255);
        }

        #region Allies

        // Navigator
        private void allyName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            Index = allyName.SelectedIndex;
            LoadAllyProperties();
        }
        private void allyName_DrawItem(object sender, DrawItemEventArgs e)
        {
            Do.DrawName(
                sender, e, new BattleDialoguePreview(), Lists.Convert(Model.Allies),
                Fonts.Model.Menu, Fonts.Model.Palette_Menu.Palettes[0], 8, 10, 0, 0, false, false, Menus.Model.MenuBG_256x255);
        }

        // Name
        private void allyNameText_TextChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            ally.Name = Do.ASCIIToRaw(allyNameText.Text, Lists.KeystrokesMenu, 10);
            this.Updating = true;
            this.allyName.Items.Clear();
            for (int i = 0; i < allies.Length; i++)
                this.allyName.Items.Add(new string(allies[i].Name));
            this.allyName.SelectedIndex = Index;
            this.Updating = false;
        }
        private void allyNameText_Leave(object sender, EventArgs e)
        {
            InitializeListControls();
        }

        // Starting stats
        private void level_ValueChanged(object sender, EventArgs e)
        {
            ally.Level = (byte)this.level.Value;
        }
        private void attack_ValueChanged(object sender, EventArgs e)
        {
            ally.Attack = (byte)this.attack.Value;
        }
        private void defense_ValueChanged(object sender, EventArgs e)
        {
            ally.Defense = (byte)this.defense.Value;
        }
        private void mgAttack_ValueChanged(object sender, EventArgs e)
        {
            ally.MgAttack = (byte)this.mgAttack.Value;
        }
        private void mgDefense_ValueChanged(object sender, EventArgs e)
        {
            ally.MgDefense = (byte)this.mgDefense.Value;
        }
        private void speed_ValueChanged(object sender, EventArgs e)
        {
            ally.Speed = (byte)this.speed.Value;
        }
        private void experience_ValueChanged(object sender, EventArgs e)
        {
            ally.Experience = (ushort)this.experience.Value;
        }
        private void currentHP_ValueChanged(object sender, EventArgs e)
        {
            ally.CurrentHP = (ushort)this.currentHP.Value;
        }
        private void maxmumHP_ValueChanged(object sender, EventArgs e)
        {
            ally.MaxHP = (ushort)this.maximumHP.Value;
        }

        // Starting equipment
        private void weapon_SelectedIndexChanged(object sender, EventArgs e)
        {
            ally.Weapon = (byte)Items.Model.Names.GetUnsortedIndex(this.weapon.SelectedIndex);
        }
        private void armor_SelectedIndexChanged(object sender, EventArgs e)
        {
            ally.Armor = (byte)Items.Model.Names.GetUnsortedIndex(this.armor.SelectedIndex);
        }
        private void accessory_SelectedIndexChanged(object sender, EventArgs e)
        {
            ally.Accessory = (byte)Items.Model.Names.GetUnsortedIndex(this.accessory.SelectedIndex);
        }

        // Starting magic
        private void magic_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < ally.Magic.Length; i++)
                ally.Magic[i] = this.magic.GetItemChecked(i);
        }
        private void magic_DrawItem(object sender, DrawItemEventArgs e)
        {
            Do.DrawName(
                sender, e, new BattleDialoguePreview(), Lists.Convert(Magic.Model.Spells, 32, 1),
                Fonts.Model.Menu, Fonts.Model.Palette_Menu.Palettes[0], -8, 10, 0, 0, false, false,
                Menus.Model.MenuBG(256, 255));
        }

        #endregion

        // Status
        private void coins_ValueChanged(object sender, EventArgs e)
        {
            newGame.Coins = (ushort)this.coins.Value;
        }
        private void frogCoins_ValueChanged(object sender, EventArgs e)
        {
            newGame.FrogCoins = (ushort)this.frogCoins.Value;
        }
        private void currentFP_ValueChanged(object sender, EventArgs e)
        {
            newGame.CurrentFP = (byte)this.currentFP.Value;
        }
        private void maximumFP_ValueChanged(object sender, EventArgs e)
        {
            newGame.MaximumFP = (byte)this.maximumFP.Value;
        }

        // Inventory
        private void slotNum_ValueChanged(object sender, EventArgs e)
        {
            LoadInventoryProperties();
        }
        private void startingItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            newGame.Items[slotIndex] = (byte)Items.Model.Names.GetUnsortedIndex(this.item.SelectedIndex);
        }
        private void startingSpecialItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            newGame.SpecialItems[slotIndex] = (byte)Items.Model.Names.GetUnsortedIndex(this.specialItem.SelectedIndex);
        }
        private void startingEquipment_SelectedIndexChanged(object sender, EventArgs e)
        {
            newGame.Equipment[slotIndex] = (byte)Items.Model.Names.GetUnsortedIndex(this.equipment.SelectedIndex);
        }

        // Defense timing
        private void defenseStartL1_ValueChanged(object sender, EventArgs e)
        {
            newGame.DefenseStartL1 = (byte)this.defenseStartL1.Value;
        }
        private void defenseStartL2_ValueChanged(object sender, EventArgs e)
        {
            newGame.DefenseStartL2 = (byte)this.defenseStartL2.Value;
        }
        private void defenseEndL2_ValueChanged(object sender, EventArgs e)
        {
            newGame.DefenseEndL2 = (byte)this.defenseEndL2.Value;
        }
        private void defenseEndL1_ValueChanged(object sender, EventArgs e)
        {
            newGame.DefenseEndL1 = (byte)this.defenseEndL1.Value;
        }

        #endregion
    }
}
