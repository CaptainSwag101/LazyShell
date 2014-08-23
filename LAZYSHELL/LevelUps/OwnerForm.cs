using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LAZYSHELL.Properties;

namespace LAZYSHELL.LevelUps
{
    public partial class OwnerForm : Controls.NewForm
    {
        #region Variables

        // Index
        private int index
        {
            get { return (int)levelNum.Value; }
            set { levelNum.Value = value; }
        }
        // Settings
        private Settings settings;
        // Elements
        private LevelUp[] levelUps
        {
            get { return Model.LevelUps; }
            set { Model.LevelUps = value; }
        }
        private LevelUp levelUp
        {
            get { return levelUps[index]; }
            set { levelUps[index] = value; }
        }
        private LevelUp.Ally[] allies
        {
            get { return levelUp.Allies; }
            set { levelUp.Allies = value; }
        }
        private LevelUp.Ally ally
        {
            get { return allies[allyName.SelectedIndex]; }
            set { allies[allyName.SelectedIndex] = value; }
        }

        #endregion

        // Constructor
        public OwnerForm()
        {
            InitializeComponent();
            InitializeVariables();
            InitializeListControls();
            LoadProperties();
            //
            this.History = new History(this, null, null);
        }

        #region Methods

        private void InitializeVariables()
        {
            this.settings = Settings.Default;
        }
        private void InitializeListControls()
        {
            this.Updating = true;

            // Initialize ally list
            this.allyName.Items.Clear();
            for (int i = 0; i < allies.Length; i++)
                this.allyName.Items.Add(new string(NewGame.Model.Allies[i].Name));
            this.allyName.SelectedIndex = 0;

            // Initialize spell list
            this.spellLearned.Items.Clear();
            for (int i = 0; i < 32; i++)
                this.spellLearned.Items.Add(new string(Magic.Model.Spells[i].Name));
            this.spellLearned.Items.Add("{NOTHING}");

            // Finished
            this.Updating = false;
        }
        private void LoadProperties()
        {
            this.Updating = true;
            //
            this.expNeeded.Value = levelUp.ExpNeeded;
            LoadAllyProperties();
            //
            this.Updating = false;
        }
        private void LoadAllyProperties()
        {
            this.Updating = true;
            //
            this.hpPlus.Value = ally.HpPlus;
            this.attackPlus.Value = ally.AttackPlus;
            this.defensePlus.Value = ally.DefensePlus;
            this.mgAttackPlus.Value = ally.MgAttackPlus;
            this.mgDefensePlus.Value = ally.MgDefensePlus;
            this.hpPlusBonus.Value = ally.HpPlusBonus;
            this.attackPlusBonus.Value = ally.AttackPlusBonus;
            this.defensePlusBonus.Value = ally.DefensePlusBonus;
            this.mgAttackPlusBonus.Value = ally.MgAttackPlusBonus;
            this.mgDefensePlusBonus.Value = ally.MgDefensePlusBonus;
            this.spellLearned.SelectedIndex = ally.SpellLearned;
            this.allyName.Invalidate();
            //
            this.Updating = false;
        }
        //
        private void ResetLevelUp()
        {
            if (MessageBox.Show("You're about to undo all changes to the current level-up. Go ahead with reset?",
               "LAZY SHELL", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;
            levelUp = new LevelUp(index);
            LoadProperties();
        }

        // Read/write ROM
        public void WriteToROM()
        {
            foreach (var levelUp in levelUps)
                levelUp.WriteToROM();
        }

        #endregion

        #region Event Handlers

        // OwnerForm
        private void OwnerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!this.Modified)
                return;
            // Prompt user to save
            var result = MessageBox.Show("Level-ups have not been saved.\n\nWould you like to save changes?",
                "LAZY SHELL", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
                WriteToROM();
            else if (result == DialogResult.No)
                Model.LevelUps = null;
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
        }
        private void export_Click(object sender, EventArgs e)
        {
        }
        private void reset_Click(object sender, EventArgs e)
        {
            ResetLevelUp();
        }
        private void clear_Click(object sender, EventArgs e)
        {
        }

        // Navigators
        private void levelNum_ValueChanged(object sender, EventArgs e)
        {
            if (!this.Updating)
                LoadProperties();
        }

        // Properties
        private void expNeeded_ValueChanged(object sender, EventArgs e)
        {
            levelUp.ExpNeeded = (ushort)this.expNeeded.Value;
        }

        #region Ally properties

        // Navigators
        private void allyName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.Updating)
                LoadProperties();
        }
        private void allyName_DrawItem(object sender, DrawItemEventArgs e)
        {
            Do.DrawName(sender, e, new BattleDialoguePreview(), Lists.Convert(NewGame.Model.Allies),
                Fonts.Model.Menu, Fonts.Model.Palette_Menu.Palettes[0], 8, 10, 0, 0, false, false, Menus.Model.MenuBG_256x255);
        }

        // Properties : Status up
        private void hpPlus_ValueChanged(object sender, EventArgs e)
        {
            ally.HpPlus = (byte)this.hpPlus.Value;
        }
        private void attackPlus_ValueChanged(object sender, EventArgs e)
        {
            ally.AttackPlus = (byte)this.attackPlus.Value;
        }
        private void defensePlus_ValueChanged(object sender, EventArgs e)
        {
            ally.DefensePlus = (byte)this.defensePlus.Value;
        }
        private void mgAttackPlus_ValueChanged(object sender, EventArgs e)
        {
            ally.MgAttackPlus = (byte)this.mgAttackPlus.Value;
        }
        private void mgDefensePlus_ValueChanged(object sender, EventArgs e)
        {
            ally.MgDefensePlus = (byte)this.mgDefensePlus.Value;
        }

        // Properties : Bonus status up
        private void hpPlusBonus_ValueChanged(object sender, EventArgs e)
        {
            ally.HpPlusBonus = (byte)this.hpPlusBonus.Value;
        }
        private void attackPlusBonus_ValueChanged(object sender, EventArgs e)
        {
            ally.AttackPlusBonus = (byte)this.attackPlusBonus.Value;
        }
        private void defensePlusBonus_ValueChanged(object sender, EventArgs e)
        {
            ally.DefensePlusBonus = (byte)this.defensePlusBonus.Value;
        }
        private void mgAttackPlusBonus_ValueChanged(object sender, EventArgs e)
        {
            ally.MgAttackPlusBonus = (byte)this.mgAttackPlusBonus.Value;
        }
        private void mgDefensePlusBonus_ValueChanged(object sender, EventArgs e)
        {
            ally.MgDefensePlusBonus = (byte)this.mgDefensePlusBonus.Value;
        }

        // Properties : Spell learned
        private void spellLearned_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.Updating)
                ally.SpellLearned = (byte)this.spellLearned.SelectedIndex;
        }
        private void spellLearned_DrawItem(object sender, DrawItemEventArgs e)
        {
            Do.DrawName(
                sender, e, new BattleDialoguePreview(), Lists.Convert(Magic.Model.Spells, 33),
                Fonts.Model.Menu, Fonts.Model.Palette_Menu.Palettes[0], 8, 10, 0, 0, true, false, Menus.Model.MenuBG_256x255);
        }

        #endregion

        #endregion
    }
}
