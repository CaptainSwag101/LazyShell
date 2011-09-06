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
    public partial class Attacks : Form
    {
        // variables
        
        private Settings settings = Settings.Default;
        private bool updating = false;
        private Attack[] attacks { get { return Model.Attacks; } set { Model.Attacks = value; } }
        public Attack Attack { get { return attacks[index]; } set { attacks[index] = value; } }
        private int index { get { return (int)attackNum.Value; } set { attackNum.Value = value; } }
        public int Index { get { return index; } set { index = value; } }
        // constructor
        public Attacks()
        {
            this.settings.KeystrokesMenu[0x20] = "\x20";
            InitializeComponent();
            InitializeStrings();
            RefreshAttacks();
        }
        // functions
        private void InitializeStrings()
        {
            this.attackName.Items.Clear();
            this.attackName.Items.AddRange(Model.AttackNames.Names);
        }
        public void RefreshAttacks()
        {
            if (updating) return;
            updating = true;
            this.attackName.SelectedIndex = Model.AttackNames.GetIndexFromNum(index);
            this.attackHitRate.Value = attacks[index].HitRate;
            this.attackAtkLevel.Value = attacks[index].AttackLevel;
            this.textBoxAttackName.Text = Do.RawToASCII(attacks[index].Name, settings.Keystrokes);
            this.attackStatusEffect.SetItemChecked(0, attacks[index].EffectMute);
            this.attackStatusEffect.SetItemChecked(1, attacks[index].EffectSleep);
            this.attackStatusEffect.SetItemChecked(2, attacks[index].EffectPoison);
            this.attackStatusEffect.SetItemChecked(3, attacks[index].EffectFear);
            this.attackStatusEffect.SetItemChecked(4, attacks[index].EffectMushroom);
            this.attackStatusEffect.SetItemChecked(5, attacks[index].EffectScarecrow);
            this.attackStatusEffect.SetItemChecked(6, attacks[index].EffectInvincible);
            this.attackStatusUp.SetItemChecked(0, attacks[index].ChangeAttack);
            this.attackStatusUp.SetItemChecked(1, attacks[index].ChangeDefense);
            this.attackStatusUp.SetItemChecked(2, attacks[index].ChangeMagicAttack);
            this.attackStatusUp.SetItemChecked(3, attacks[index].ChangeMagicDefense);
            this.attackAtkType.SetItemChecked(0, attacks[index].MaxAttack);
            this.attackAtkType.SetItemChecked(1, attacks[index].NoDamageA);
            this.attackAtkType.SetItemChecked(2, attacks[index].HideDigits);
            this.attackAtkType.SetItemChecked(3, attacks[index].NoDamageB);
            updating = false;
        }
        public void SetToolTips(ToolTip toolTip1)
        {
            // ATTACKS
            this.attackNum.ToolTipText =
                "Select the attack to edit by #. These are all exclusively in-\n" +
                "battle monster attacks. Many monster attacks have no\n" +
                "name, and even if given one it will not be displayed\n" +
                "because the attack animation code does not enable it.";
            this.attackName.ToolTipText =
                "Select the attack to edit by name. These are all exclusively\n" +
                "in-battle monster attacks. Many monster attacks have no\n" +
                "name, and even if given one it will not be displayed\n" +
                "because the attack animation code does not enable it.";
            this.textBoxAttackName.ToolTipText =
                "The attack's name displayed at the top of the screen when\n" +
                "executed by the monster. Many monster attacks have no\n" +
                "name, and even if given one it will not be displayed\n" +
                "because the attack animation code does not enable it.";
            toolTip1.SetToolTip(this.attackHitRate,
                "The attack's hit rate percent, ie. the probability out of 100\n" +
                "the attack will hit its target.");
            toolTip1.SetToolTip(this.attackAtkLevel,
                "The attack level multiplies the base damage of the attack\n" +
                "(ie. the monster's attack power) by a number.\n\n" +
                "An attack level of 0 will yield base damage.\n" +
                "An attack level of 1 will multiply the base damage by 1.5.\n" +
                "An attack level of 2 will multiply the base damage by 2.\n" +
                "An attack level of 3 will multiply the base damage by 4.\n" +
                "An attack level of 4 will multiply the base damage by 8.\n" +
                "An attack level of 5 will multiply the base damage by 16.\n" +
                "An attack level of 6 will multiply the base damage by 32.\n" +
                "An attack level of 7 will multiply the base damage by 64.\n\n" +
                "Example: if the monster's attack power is 6, and the attack\n" +
                "level of the attack is 7, then the damage will be increased\n" +
                "to 384 (ie. 6 x 64).");
            toolTip1.SetToolTip(this.attackStatusEffect,
                "The effect inflicted on a target, eg. S'crow Bell inflicts\n" +
                "Scarecrow on a target, Thornet inflicts Poison, etc.");
            toolTip1.SetToolTip(this.attackStatusUp,
                "The status of a target is raised by 50%.\n\n" +
                "Example: Valor Up by default raises the target's Defense\n" +
                "and Magic Defense power by 50% (eg. if the magic\n" +
                "defense and/or defense power of the target is 100, then it\n" +
                "becomes 150). Vigor up! by default raises the Magic Attack\n" +
                "and Attack power by 50%.");
            toolTip1.SetToolTip(this.attackAtkType,
                "\"9999 Damage\" will kill the target in one strike, if the attack\n" +
                "does not miss.\n\n" +
                "\"No damage\" will yield 0 damage to the target (both \"No\n" +
                "damage\" properties are exactly the same, but different\n" +
                "bits).\n\n" +
                "\"Hide Battle Numerals\" will hide the total damage (ie. the\n" +
                "numbers shown after an attack). This is generally used by\n" +
                "attacks that cause 0 damage and are only effect-based\n" +
                "attacks such as S'crow Bell or \"9999 damage\" enabled\n" +
                "attacks such as Scythe, to avoid a redundant \"0\" or \"9999\"\n" +
                "appearing.");
        }
        #region Event Handlers
        private void attackNum_ValueChanged(object sender, EventArgs e)
        {
            RefreshAttacks();
            settings.LastAttack = index;
        }
        private void attackName_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.attackNum.Value = Model.AttackNames.GetNumFromIndex(attackName.SelectedIndex);
        }
        private void attackName_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;
            Do.DrawName(
                sender, e, new BattleDialoguePreview(), Model.AttackNames, Model.FontDialogue,
                Model.FontPaletteMenu.Palette, 8, 10, 0, 128, false, true, Model.MenuBackground_);
        }
        private void textBoxAttackName_TextChanged(object sender, EventArgs e)
        {
            if (Model.AttackNames.GetNameByNum(index).CompareTo(this.textBoxAttackName.Text) != 0)
            {
                attacks[index].Name = Do.ASCIIToRaw(this.textBoxAttackName.Text, settings.Keystrokes, 13);
                Model.AttackNames.SwapName(
                    index, new string(attacks[index].Name));
                Model.AttackNames.SortAlpha();
                this.attackName.Items.Clear();
                this.attackName.Items.AddRange(Model.AttackNames.GetNames());
                this.attackName.SelectedIndex = Model.AttackNames.GetIndexFromNum(index);
            }
        }
        private void attackHitRate_ValueChanged(object sender, EventArgs e)
        {
            attacks[index].HitRate = (byte)attackHitRate.Value;
        }
        private void attackAtkLevel_ValueChanged(object sender, EventArgs e)
        {
            attacks[index].AttackLevel = (byte)attackAtkLevel.Value;
        }
        private void attackStatusEffect_SelectedIndexChanged(object sender, EventArgs e)
        {
            attacks[index].EffectMute = this.attackStatusEffect.GetItemChecked(0);
            attacks[index].EffectSleep = this.attackStatusEffect.GetItemChecked(1);
            attacks[index].EffectPoison = this.attackStatusEffect.GetItemChecked(2);
            attacks[index].EffectFear = this.attackStatusEffect.GetItemChecked(3);
            attacks[index].EffectMushroom = this.attackStatusEffect.GetItemChecked(4);
            attacks[index].EffectScarecrow = this.attackStatusEffect.GetItemChecked(5);
            attacks[index].EffectInvincible = this.attackStatusEffect.GetItemChecked(6);
        }
        private void attackStatusUp_SelectedIndexChanged(object sender, EventArgs e)
        {
            attacks[index].ChangeAttack = this.attackStatusUp.GetItemChecked(0);
            attacks[index].ChangeDefense = this.attackStatusUp.GetItemChecked(1);
            attacks[index].ChangeMagicAttack = this.attackStatusUp.GetItemChecked(2);
            attacks[index].ChangeMagicDefense = this.attackStatusUp.GetItemChecked(3);
        }
        private void attackAtkType_SelectedIndexChanged(object sender, EventArgs e)
        {
            attacks[index].MaxAttack = this.attackAtkType.GetItemChecked(0);
            attacks[index].NoDamageA = this.attackAtkType.GetItemChecked(1);
            attacks[index].HideDigits = this.attackAtkType.GetItemChecked(2);
            attacks[index].NoDamageB = this.attackAtkType.GetItemChecked(3);
        }
        #endregion
    }
}
