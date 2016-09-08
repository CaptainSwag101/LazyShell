using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LazyShell.Properties;

namespace LazyShell.Attacks
{
    public partial class OwnerForm : Controls.NewForm
    {
        #region Variables

        private Settings settings;
        private Attack[] attacks
        {
            get { return Model.Attacks; }
            set { Model.Attacks = value; }
        }
        private Attack attack
        {
            get { return attacks[index]; }
            set { attacks[index] = value; }
        }
        private int index
        {
            get { return (int)num.Value; }
            set { num.Value = value; }
        }
        public int Index
        {
            get { return index; }
            set { index = value; }
        }
        private EditLabel labelWindow;

        #endregion

        // Constructor
        public OwnerForm()
        {
            InitializeVariables();
            InitializeComponent();
            InitializeListControls();
            InitializeNavigationControls();
            //
            CreateShortcuts();
            CreateHelperForms();
            //
            LoadProperties();
            //
            this.History = new History(this, name, num);
        }

        #region Methods

        private void InitializeListControls()
        {
            this.name.Items.Clear();
            this.name.Items.AddRange(Model.Names.Names);
        }
        private void InitializeNavigationControls()
        {
            this.Updating = true;
            //
            if (settings.RememberLastIndex)
                Index = settings.LastAttack;
            //
            this.Updating = false;
        }
        private void InitializeVariables()
        {
            this.settings = Settings.Default;
        }
        //
        private void CreateShortcuts()
        {
            Do.AddShortcut(toolStrip3, Keys.Control | Keys.S, new EventHandler(save_Click));
            Do.AddShortcut(toolStrip3, Keys.F1, helpTips);
            Do.AddShortcut(toolStrip3, Keys.F2, baseConvertor);
        }
        private void CreateHelperForms()
        {
            new ToolTipLabel(this, baseConvertor, helpTips);
            labelWindow = new EditLabel(name, num, "Attacks", false);
        }
        //
        public void LoadProperties()
        {
            this.Updating = true;
            //
            this.name.SelectedIndex = Model.Names.GetSortedIndex(index);
            this.hitRate.Value = attacks[index].HitRate;
            this.attackLevel.Value = attacks[index].AttackLevel;
            this.nameText.Text = Do.RawToASCII(attacks[index].Name, Lists.Keystrokes);
            this.statusEffect.SetItemChecked(0, attacks[index].EffectMute);
            this.statusEffect.SetItemChecked(1, attacks[index].EffectSleep);
            this.statusEffect.SetItemChecked(2, attacks[index].EffectPoison);
            this.statusEffect.SetItemChecked(3, attacks[index].EffectFear);
            this.statusEffect.SetItemChecked(4, attacks[index].EffectMushroom);
            this.statusEffect.SetItemChecked(5, attacks[index].EffectScarecrow);
            this.statusEffect.SetItemChecked(6, attacks[index].EffectInvincible);
            this.statusUp.SetItemChecked(0, attacks[index].UpAttack);
            this.statusUp.SetItemChecked(1, attacks[index].UpDefense);
            this.statusUp.SetItemChecked(2, attacks[index].UpMagicAttack);
            this.statusUp.SetItemChecked(3, attacks[index].UpMagicDefense);
            this.attackType.SetItemChecked(0, attacks[index].InstantDeath);
            this.attackType.SetItemChecked(1, attacks[index].NoDamageA);
            this.attackType.SetItemChecked(2, attacks[index].HideDigits);
            this.attackType.SetItemChecked(3, attacks[index].NoDamageB);
            //
            this.Updating = false;
        }
        //
        public void WriteToROM()
        {
            foreach (var attack in Model.Attacks)
                attack.WriteToROM();
            this.Modified = false;
        }

        #endregion

        #region Event Handlers

        // OwnerForm
        private void OwnerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!this.Modified)
                return;
            var result = MessageBox.Show("Attacks have not been saved.\n\nWould you like to save changes?",
                "LAZY SHELL", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
                WriteToROM();
            else if (result == DialogResult.No)
                Model.ClearAll();
            else if (result == DialogResult.Cancel)
                e.Cancel = true;
        }
        // ToolStrip
        private void save_Click(object sender, EventArgs e)
        {
            WriteToROM();
        }
        private void import_Click(object sender, EventArgs e)
        {
            new IOElements(Model.Attacks, IOMode.Import, Index, "IMPORT ATTACKS...").ShowDialog();
            LoadProperties();
        }
        private void export_Click(object sender, EventArgs e)
        {
            new IOElements(Model.Attacks, IOMode.Export, Index, "EXPORT ATTACKS...").ShowDialog();
        }
        private void reset_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("You're about to undo all changes to the current attack. Go ahead with reset?",
                "LAZY SHELL", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;
            attack = new Attack(Index);
            LoadProperties();
        }
        private void clear_Click(object sender, EventArgs e)
        {
            new ClearElements(Model.Attacks, Index, "CLEAR ATTACKS...").ShowDialog();
            LoadProperties();
        }
        private void damageCalculator_Click(object sender, EventArgs e)
        {
            var calculator = new StatusCalculator();
            calculator.Show();
        }
        // Navigator
        private void num_ValueChanged(object sender, EventArgs e)
        {
            this.name.SelectedIndex = Model.Names.GetSortedIndex((int)num.Value);
            if (!this.Updating)
            {
                LoadProperties();
                settings.LastAttack = index;
            }
        }
        private void name_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.num.Value = Model.Names.GetUnsortedIndex(name.SelectedIndex);
        }
        private void name_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0)
                return;
            Do.DrawName(
                sender, e, new BattleDialoguePreview(), Model.Names, Fonts.Model.Dialogue,
                Fonts.Model.Palette_Menu.Palettes[0], 8, 10, 0, 128, false, true, Menus.Model.MenuBG_256x255);
        }
        private void nameText_TextChanged(object sender, EventArgs e)
        {
            if (Model.Names.GetUnsortedName(index).CompareTo(this.nameText.Text) != 0)
            {
                attacks[index].Name = Do.ASCIIToRaw(this.nameText.Text, Lists.Keystrokes, 13);
                Model.Names.SetName(
                    index, new string(attacks[index].Name));
                Model.Names.SortAlphabetically();
                //
                this.Updating = true;
                //
                this.name.Items.Clear();
                this.name.Items.AddRange(Model.Names.Names);
                this.name.SelectedIndex = Model.Names.GetSortedIndex(index);
                //
                this.Updating = false;
            }
        }
        // Properties
        private void hitRate_ValueChanged(object sender, EventArgs e)
        {
            attacks[index].HitRate = (byte)hitRate.Value;
        }
        private void attackLevel_ValueChanged(object sender, EventArgs e)
        {
            attacks[index].AttackLevel = (byte)attackLevel.Value;
        }
        private void statusEffect_SelectedIndexChanged(object sender, EventArgs e)
        {
            attacks[index].EffectMute = this.statusEffect.GetItemChecked(0);
            attacks[index].EffectSleep = this.statusEffect.GetItemChecked(1);
            attacks[index].EffectPoison = this.statusEffect.GetItemChecked(2);
            attacks[index].EffectFear = this.statusEffect.GetItemChecked(3);
            attacks[index].EffectMushroom = this.statusEffect.GetItemChecked(4);
            attacks[index].EffectScarecrow = this.statusEffect.GetItemChecked(5);
            attacks[index].EffectInvincible = this.statusEffect.GetItemChecked(6);
        }
        private void statusUp_SelectedIndexChanged(object sender, EventArgs e)
        {
            attacks[index].UpAttack = this.statusUp.GetItemChecked(0);
            attacks[index].UpDefense = this.statusUp.GetItemChecked(1);
            attacks[index].UpMagicAttack = this.statusUp.GetItemChecked(2);
            attacks[index].UpMagicDefense = this.statusUp.GetItemChecked(3);
        }
        private void attackType_SelectedIndexChanged(object sender, EventArgs e)
        {
            attacks[index].InstantDeath = this.attackType.GetItemChecked(0);
            attacks[index].NoDamageA = this.attackType.GetItemChecked(1);
            attacks[index].HideDigits = this.attackType.GetItemChecked(2);
            attacks[index].NoDamageB = this.attackType.GetItemChecked(3);
        }

        #endregion
    }
}
