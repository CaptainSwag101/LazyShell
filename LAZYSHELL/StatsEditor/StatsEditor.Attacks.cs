using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LAZYSHELL.StatsEditor
{
    public partial class StatsEditor
    {
        private bool updatingAttacks = false;

        private void InitializeAttacks()
        {
            this.attackName.SelectedIndex = universal.AttackNames.GetIndexFromNum(0);
            RefreshAttackTab();
        }
        private void InitializeAttackStrings()
        {
            universal.AttackNames = new DDlistName(statsModel.Attacks);
            universal.AttackNames.SortAlpha();

            this.attackName.Items.Clear();
            this.attackName.Items.AddRange(universal.AttackNames.Names);
            this.attackName.SelectedIndex = universal.AttackNames.GetIndexFromNum((int)this.attackNum.Value);
        }
        private void RefreshAttackTab()
        {
            if (!updatingAttacks)
            {
                updatingAttacks = true;

                this.attackName.SelectedIndex = universal.AttackNames.GetIndexFromNum((int)attackNum.Value);
                this.attackHitRate.Value = statsModel.Attacks[(int)attackNum.Value].HitRate;
                this.attackAtkLevel.Value = statsModel.Attacks[(int)attackNum.Value].AttackLevel;
                this.textBoxAttackName.Text = RawToASCII(statsModel.Attacks[(int)attackNum.Value].Name, settings.Keystrokes);
                this.attackStatusEffect.SetItemChecked(0, statsModel.Attacks[(int)attackNum.Value].EffectMute);
                this.attackStatusEffect.SetItemChecked(1, statsModel.Attacks[(int)attackNum.Value].EffectSleep);
                this.attackStatusEffect.SetItemChecked(2, statsModel.Attacks[(int)attackNum.Value].EffectPoison);
                this.attackStatusEffect.SetItemChecked(3, statsModel.Attacks[(int)attackNum.Value].EffectFear);
                this.attackStatusEffect.SetItemChecked(4, statsModel.Attacks[(int)attackNum.Value].EffectMushroom);
                this.attackStatusEffect.SetItemChecked(5, statsModel.Attacks[(int)attackNum.Value].EffectScarecrow);
                this.attackStatusEffect.SetItemChecked(6, statsModel.Attacks[(int)attackNum.Value].EffectInvincible);
                this.attackStatusUp.SetItemChecked(0, statsModel.Attacks[(int)attackNum.Value].ChangeAttack);
                this.attackStatusUp.SetItemChecked(1, statsModel.Attacks[(int)attackNum.Value].ChangeDefense);
                this.attackStatusUp.SetItemChecked(2, statsModel.Attacks[(int)attackNum.Value].ChangeMagicAttack);
                this.attackStatusUp.SetItemChecked(3, statsModel.Attacks[(int)attackNum.Value].ChangeMagicDefense);
                this.attackAtkType.SetItemChecked(0, statsModel.Attacks[(int)attackNum.Value].MaxAttack);
                this.attackAtkType.SetItemChecked(1, statsModel.Attacks[(int)attackNum.Value].NoDamageA);
                this.attackAtkType.SetItemChecked(2, statsModel.Attacks[(int)attackNum.Value].HideDigits);
                this.attackAtkType.SetItemChecked(3, statsModel.Attacks[(int)attackNum.Value].NoDamageB);

                updatingAttacks = false;
            }
        }
        private void SaveAttackNotes()
        {
        }

        #region Event Handlers
        private void attackNum_ValueChanged(object sender, EventArgs e)
        {
            RefreshAttackTab();
        }
        private void attackName_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.attackNum.Value = universal.AttackNames.GetNumFromIndex(attackName.SelectedIndex);
        }
        private void attackName_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0 || e.Index > 128)
                return;

            // set the palette
            int[] palette = new int[16];
            ushort color = 0; int r, g, b;
            for (int i = 0; i < 16; i++) // 16 colors in palette
            {
                color = BitManager.GetShort(data, i * 2 + 0x3E2D55);
                r = (byte)((color % 0x20) * 8);
                g = (byte)(((color >> 5) % 0x20) * 8);
                b = (byte)(((color >> 10) % 0x20) * 8);
                palette[i] = Color.FromArgb(r, g, b).ToArgb();
            }

            // set the pixels
            int[] temp = battleDialoguePreview.GetPreview(fontCharacters, palette, statsModel.Attacks[universal.AttackNames.GetNumFromIndex(e.Index)].Name, false);
            int[] pixels = new int[256 * 32];

            for (int y = 2, c = 10; c < 32; y++, c++)
            {
                for (int x = 2, a = 8; a < 256; x++, a++)
                    pixels[y * 256 + x] = temp[c * 256 + a];
            }

            Bitmap icon = new Bitmap(DrawImageFromIntArr(pixels, 256, 32));

            e.DrawBackground();
            e.Graphics.DrawImage(new Bitmap(icon), new Point(e.Bounds.X, e.Bounds.Y));
            e.DrawFocusRectangle();
        }
        private void textBoxAttackName_TextChanged(object sender, EventArgs e)
        {
            if (universal.AttackNames.GetNameByNum(statsModel.Attacks[(int)this.attackNum.Value].AttackNum).CompareTo(this.textBoxAttackName.Text) != 0)
            {
                statsModel.Attacks[(int)attackNum.Value].Name = ASCIIToRaw(this.textBoxAttackName.Text, settings.Keystrokes, 13);

                universal.AttackNames.SwapName(
                    statsModel.Attacks[(int)attackNum.Value].AttackNum, 
                    new string(statsModel.Attacks[(int)attackNum.Value].Name));
                universal.AttackNames.SortAlpha();
                this.attackName.Items.Clear();
                this.attackName.Items.AddRange(universal.AttackNames.GetNames());

                this.attackName.SelectedIndex = universal.AttackNames.GetIndexFromNum(statsModel.Attacks[(int)this.attackNum.Value].AttackNum);
            }
        }
        private void attackHitRate_ValueChanged(object sender, EventArgs e)
        {
            statsModel.Attacks[(int)attackNum.Value].HitRate = (byte)attackHitRate.Value;
        }
        private void attackAtkLevel_ValueChanged(object sender, EventArgs e)
        {
            statsModel.Attacks[(int)attackNum.Value].AttackLevel = (byte)attackAtkLevel.Value;
        }
        private void attackStatusEffect_SelectedIndexChanged(object sender, EventArgs e)
        {
            statsModel.Attacks[(int)attackNum.Value].EffectMute = this.attackStatusEffect.GetItemChecked(0);
            statsModel.Attacks[(int)attackNum.Value].EffectSleep = this.attackStatusEffect.GetItemChecked(1);
            statsModel.Attacks[(int)attackNum.Value].EffectPoison = this.attackStatusEffect.GetItemChecked(2);
            statsModel.Attacks[(int)attackNum.Value].EffectFear = this.attackStatusEffect.GetItemChecked(3);
            statsModel.Attacks[(int)attackNum.Value].EffectMushroom = this.attackStatusEffect.GetItemChecked(4);
            statsModel.Attacks[(int)attackNum.Value].EffectScarecrow = this.attackStatusEffect.GetItemChecked(5);
            statsModel.Attacks[(int)attackNum.Value].EffectInvincible = this.attackStatusEffect.GetItemChecked(6);
        }
        private void attackStatusUp_SelectedIndexChanged(object sender, EventArgs e)
        {
            statsModel.Attacks[(int)attackNum.Value].ChangeAttack = this.attackStatusUp.GetItemChecked(0);
            statsModel.Attacks[(int)attackNum.Value].ChangeDefense = this.attackStatusUp.GetItemChecked(1);
            statsModel.Attacks[(int)attackNum.Value].ChangeMagicAttack = this.attackStatusUp.GetItemChecked(2);
            statsModel.Attacks[(int)attackNum.Value].ChangeMagicDefense = this.attackStatusUp.GetItemChecked(3);
        }
        private void attackAtkType_SelectedIndexChanged(object sender, EventArgs e)
        {
            statsModel.Attacks[(int)attackNum.Value].MaxAttack = this.attackAtkType.GetItemChecked(0);
            statsModel.Attacks[(int)attackNum.Value].NoDamageA = this.attackAtkType.GetItemChecked(1);
            statsModel.Attacks[(int)attackNum.Value].HideDigits = this.attackAtkType.GetItemChecked(2);
            statsModel.Attacks[(int)attackNum.Value].NoDamageB = this.attackAtkType.GetItemChecked(3);
        }
        #endregion
    }
}
