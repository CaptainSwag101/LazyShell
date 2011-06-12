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
    public partial class LevelUps : Form
    {
        #region Variables
        private Settings settings = Settings.Default;
        private bool updating = false;
        private Character[] characters { get { return Model.Characters; } set { Model.Characters = value; } }
        private Character character { get { return characters[index]; } set { characters[index] = value; } }
        private Character character_;
        private int index { get { return characterName.SelectedIndex; } set { characterName.SelectedIndex = value; } }
        #endregion
        // constructor
        public LevelUps()
        {
            InitializeComponent();
            InitializeStrings();
            index = 0;
            RefreshLevel();
        }
        // functions
        private void InitializeStrings()
        {
            updating = true;
            this.characterName.Items.Clear();
            for (int i = 0; i < characters.Length; i++)
                this.characterName.Items.Add(new string(characters[i].Name));

            this.levelUpSpellLearned.Items.Clear();
            for (int i = 0; i < 32; i++)
                this.levelUpSpellLearned.Items.Add(new string(Model.Spells[i].Name));
            this.levelUpSpellLearned.Items.Add("{NOTHING}");
            updating = false;
        }
        public void RefreshLevel()
        {
            if (updating) return;
            character.CurrentLevel = (byte)levelNum.Value;
            this.hpPlus.Value = character.LevelHpPlus;
            this.attackPlus.Value = character.LevelAttackPlus;
            this.defensePlus.Value = character.LevelDefensePlus;
            this.mgAttackPlus.Value = character.LevelMgAttackPlus;
            this.mgDefensePlus.Value = character.LevelMgDefensePlus;
            this.hpPlusBonus.Value = character.LevelHpPlusBonus;
            this.attackPlusBonus.Value = character.LevelAttackPlusBonus;
            this.defensePlusBonus.Value = character.LevelDefensePlusBonus;
            this.mgAttackPlusBonus.Value = character.LevelMgAttackPlusBonus;
            this.mgDefensePlusBonus.Value = character.LevelMgDefensePlusBonus;
            this.expNeeded.Value = characters[0].LevelExpNeeded;
            this.levelUpSpellLearned.SelectedIndex = character.LevelSpellLearned;
            this.characterName.Invalidate();
            character_ = new Character(Model.Data, index);
        }
        public void SetToolTips(ToolTip toolTip1)
        {
            // Characters
            this.characterName.ToolTipText =
                "The character to edit by name.\n\n" +
                "The current character selected is the base index for all of \n" +
                "the properties in the level-ups editor.";
            toolTip1.SetToolTip(this.levelNum,
                "The character's level to edit by #. All 5 characters have a \n" +
                "total of 29 levels (levels 2 through 30) each.\n\n" +
                "The level selected is the base index for all of the properties \n" +
                "in the \"LEVEL STAT INCREMENTS\", \"LEVEL UP BONUS \n" +
                "INCREMENTS\" and \"LEVEL UP SPELL LEARNING\" panels.");
            toolTip1.SetToolTip(this.expNeeded,
                "The amount of experience the currently selected character \n" +
                "needs to reach the currently selected level.");
            toolTip1.SetToolTip(this.hpPlus,
                "The amount the currently selected character's HP will \n" +
                "automatically increase when the character reaches the \n" +
                "currently selected level during a level-up.");
            toolTip1.SetToolTip(this.attackPlus,
                "The amount the currently selected character's Attack \n" +
                "Power will automatically increase when the character \n" +
                "reaches the currently selected level during a level-up.");
            toolTip1.SetToolTip(this.defensePlus,
                "The amount the currently selected character's Defense \n" +
                "Power will automatically increase when the currently \n" +
                "selected character reaches the currently selected level \n" +
                "during a level-up.");
            toolTip1.SetToolTip(this.mgAttackPlus,
                "The amount the currently selected character's Magic Attack \n" +
                "Power will automatically increase when the currently \n" +
                "selected character reaches the currently selected level \n" +
                "during a level-up.");
            toolTip1.SetToolTip(this.mgDefensePlus,
                "The amount the currently selected character's Magic \n" +
                "Defense Power will automatically increase when the \n" +
                "currently selected character reaches the currently selected \n" +
                "level during a level-up.");
            toolTip1.SetToolTip(this.hpPlusBonus,
                "The amount the currently selected character's HP will \n" +
                "increase if the \"HP\" bonus option is chosen when the \n" +
                "currently selected character reaches the currently selected \n" +
                "level during a level-up.");
            toolTip1.SetToolTip(this.attackPlusBonus,
                "The amount the currently selected character's Attack \n" +
                "Power will increase if the \"POW\" bonus option is chosen \n" +
                "when the currently selected character reaches the \n" +
                "currently selected level during a level-up.");
            toolTip1.SetToolTip(this.defensePlusBonus,
                "The amount the currently selected character's Defense \n" +
                "Power will increase if the \"POW\" bonus option is chosen \n" +
                "when the currently selected character reaches the \n" +
                "currently selected level during a level-up.");
            toolTip1.SetToolTip(this.mgAttackPlusBonus,
                "The amount the currently selected character's Magic Attack \n" +
                "Power will increase if the \"S\" bonus option is chosen when \n" +
                "the currently selected character reaches the currently \n" +
                "selected level during a level-up.");
            toolTip1.SetToolTip(this.mgDefensePlusBonus,
                "The amount the currently selected character's Magic \n" +
                "Defense Power will increase if the \"S\" bonus option is \n" +
                "chosen when the currently selected character reaches the \n" +
                "currently selected level during a level-up.");
            toolTip1.SetToolTip(this.levelUpSpellLearned,
                "The spell learned when the currently selected character \n" +
                "reaches the currently selected level during a level-up.");
        }
        #region Event Handlers
        private void characterName_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshLevel();
        }
        private void characterName_DrawItem(object sender, DrawItemEventArgs e)
        {
            Do.DrawName(
                sender, e, new BattleDialoguePreview(), Lists.Convert(Model.Characters),
                Model.FontMenu, Model.FontPaletteMenu.Palette, 8, 10, 0, 0, false, false, Model.MenuBackground_);
        }
        private void levelNum_ValueChanged(object sender, EventArgs e)
        {
            foreach (Character character in characters)
                character.CurrentLevel = (byte)levelNum.Value;
            RefreshLevel();
        }
        private void expNeeded_ValueChanged(object sender, EventArgs e)
        {
            characters[0].LevelExpNeeded = (ushort)this.expNeeded.Value;
        }
        private void hpPlus_ValueChanged(object sender, EventArgs e)
        {
            character.LevelHpPlus = (byte)this.hpPlus.Value;
        }
        private void attackPlus_ValueChanged(object sender, EventArgs e)
        {
            character.LevelAttackPlus = (byte)this.attackPlus.Value;
        }
        private void defensePlus_ValueChanged(object sender, EventArgs e)
        {
            character.LevelDefensePlus = (byte)this.defensePlus.Value;
        }
        private void mgAttackPlus_ValueChanged(object sender, EventArgs e)
        {
            character.LevelMgAttackPlus = (byte)this.mgAttackPlus.Value;
        }
        private void mgDefensePlus_ValueChanged(object sender, EventArgs e)
        {
            character.LevelMgDefensePlus = (byte)this.mgDefensePlus.Value;
        }
        private void hpPlusBonus_ValueChanged(object sender, EventArgs e)
        {
            character.LevelHpPlusBonus = (byte)this.hpPlusBonus.Value;
        }
        private void attackPlusBonus_ValueChanged(object sender, EventArgs e)
        {
            character.LevelAttackPlusBonus = (byte)this.attackPlusBonus.Value;
        }
        private void defensePlusBonus_ValueChanged(object sender, EventArgs e)
        {
            character.LevelDefensePlusBonus = (byte)this.defensePlusBonus.Value;
        }
        private void mgAttackPlusBonus_ValueChanged(object sender, EventArgs e)
        {
            character.LevelMgAttackPlusBonus = (byte)this.mgAttackPlusBonus.Value;
        }
        private void mgDefensePlusBonus_ValueChanged(object sender, EventArgs e)
        {
            character.LevelMgDefensePlusBonus = (byte)this.mgDefensePlusBonus.Value;
        }
        private void levelUpSpellLearned_SelectedIndexChanged(object sender, EventArgs e)
        {
            character.LevelSpellLearned = (byte)this.levelUpSpellLearned.SelectedIndex;
        }
        private void levelUpSpellLearned_DrawItem(object sender, DrawItemEventArgs e)
        {
            Do.DrawName(
                sender, e, new BattleDialoguePreview(), Lists.Convert(Model.Spells, 33),
                Model.FontMenu, Model.FontPaletteMenu.Palette, 8, 10, 0, 0, true, false, Model.MenuBackground_);
        }
        //
        private void reset_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("You're about to undo all changes to the current character's level-up index. Go ahead with reset?",
                "LAZY SHELL", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
            character = new Character(Model.Data, index);
            characterName_SelectedIndexChanged(null, null);
        }
        #endregion
    }
}
