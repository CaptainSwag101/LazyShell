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
                Model.FontPaletteMenu.Palettes[0], 8, 10, 0, 128, false, true, Model.MenuBG_);
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
