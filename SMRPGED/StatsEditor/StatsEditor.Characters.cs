using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SMRPGED.StatsEditor
{
    public partial class StatsEditor
    {
        private bool updatingCharacters = false;

        private void InitializeCharacters()
        {
            this.characterName.SelectedIndex = 0;
            RefreshCharacterTab();
            RefreshSlotsTab();
        }
        private void InitializeCharacterStrings()
        {
            this.characterName.Items.Clear();
            for (int i = 0; i < statsModel.Characters.Length; i++)
            {
                this.characterName.Items.Add(statsModel.Characters[i].Name);
            }
            this.characterName.SelectedIndex = (int)characterNum.Value;
        }
        private void RefreshCharacterLevel()
        {
            statsModel.Characters[(int)characterNum.Value].CurrentLevel = (byte)this.levelNum.Value; // Set current level

            this.hpPlus.Value = statsModel.Characters[(int)characterNum.Value].LevelHpPlus;
            this.attackPlus.Value = statsModel.Characters[(int)characterNum.Value].LevelAttackPlus;
            this.defensePlus.Value = statsModel.Characters[(int)characterNum.Value].LevelDefensePlus;
            this.mgAttackPlus.Value = statsModel.Characters[(int)characterNum.Value].LevelMgAttackPlus;
            this.mgDefensePlus.Value = statsModel.Characters[(int)characterNum.Value].LevelMgDefensePlus;
            this.hpPlusBonus.Value = statsModel.Characters[(int)characterNum.Value].LevelHpPlusBonus;
            this.attackPlusBonus.Value = statsModel.Characters[(int)characterNum.Value].LevelAttackPlusBonus;
            this.defensePlusBonus.Value = statsModel.Characters[(int)characterNum.Value].LevelDefensePlusBonus;
            this.mgAttackPlusBonus.Value = statsModel.Characters[(int)characterNum.Value].LevelMgAttackPlusBonus;
            this.mgDefensePlusBonus.Value = statsModel.Characters[(int)characterNum.Value].LevelMgDefensePlusBonus;
            this.expNeeded.Value = statsModel.Characters[(int)characterNum.Value].LevelExpNeeded;

            this.levelUpSpellLearned.SelectedIndex = statsModel.Characters[(int)characterNum.Value].LevelSpellLearned;
        }
        private void RefreshCharacterTab()
        {
            if (!updatingCharacters)
            {
                updatingCharacters = true;
                this.characterName.SelectedIndex = (int)characterNum.Value;

                RefreshCharacterLevel();

                this.textBoxCharacterName.Text = statsModel.Characters[(int)characterNum.Value].Name;

                this.startingLevel.Value = statsModel.Characters[(int)characterNum.Value].StartingLevel;
                this.startingAttack.Value = statsModel.Characters[(int)characterNum.Value].StartingAttack;
                this.startingDefense.Value = statsModel.Characters[(int)characterNum.Value].StartingDefense;
                this.startingMgAttack.Value = statsModel.Characters[(int)characterNum.Value].StartingMgAttack;
                this.startingMgDefense.Value = statsModel.Characters[(int)characterNum.Value].StartingMgDefense;
                this.startingSpeed.Value = statsModel.Characters[(int)characterNum.Value].StartingSpeed;

                this.startingWeapon.SelectedIndex = universal.ItemNames.GetIndexFromNum(statsModel.Characters[(int)characterNum.Value].StartingWeapon);
                this.startingArmor.SelectedIndex = universal.ItemNames.GetIndexFromNum(statsModel.Characters[(int)characterNum.Value].StartingArmor);
                this.startingAccessory.SelectedIndex = universal.ItemNames.GetIndexFromNum(statsModel.Characters[(int)characterNum.Value].StartingAccessory);

                this.startingExperience.Value = statsModel.Characters[(int)characterNum.Value].StartingExperience;
                this.startingCurrentHP.Value = statsModel.Characters[(int)characterNum.Value].StartingCurrentHP;
                this.startingMaximumHP.Value = statsModel.Characters[(int)characterNum.Value].StartingMaxHP;
                // All selected Magic
                this.startingMagic.SetItemChecked(0, statsModel.Characters[(int)characterNum.Value].Jump);
                this.startingMagic.SetItemChecked(1, statsModel.Characters[(int)characterNum.Value].FireOrb);
                this.startingMagic.SetItemChecked(2, statsModel.Characters[(int)characterNum.Value].SuperJump);
                this.startingMagic.SetItemChecked(3, statsModel.Characters[(int)characterNum.Value].SuperFlame);
                this.startingMagic.SetItemChecked(4, statsModel.Characters[(int)characterNum.Value].UltraJump);
                this.startingMagic.SetItemChecked(5, statsModel.Characters[(int)characterNum.Value].UltraFlame);
                this.startingMagic.SetItemChecked(6, statsModel.Characters[(int)characterNum.Value].Therapy);
                this.startingMagic.SetItemChecked(7, statsModel.Characters[(int)characterNum.Value].GroupHug);
                this.startingMagic.SetItemChecked(8, statsModel.Characters[(int)characterNum.Value].SleepyTime);
                this.startingMagic.SetItemChecked(9, statsModel.Characters[(int)characterNum.Value].ComeBack);
                this.startingMagic.SetItemChecked(10, statsModel.Characters[(int)characterNum.Value].Mute);
                this.startingMagic.SetItemChecked(11, statsModel.Characters[(int)characterNum.Value].PsychBomb);
                this.startingMagic.SetItemChecked(12, statsModel.Characters[(int)characterNum.Value].Terrorize);
                this.startingMagic.SetItemChecked(13, statsModel.Characters[(int)characterNum.Value].PoisonGas);
                this.startingMagic.SetItemChecked(14, statsModel.Characters[(int)characterNum.Value].Crusher);
                this.startingMagic.SetItemChecked(15, statsModel.Characters[(int)characterNum.Value].BowserCrush);
                this.startingMagic.SetItemChecked(16, statsModel.Characters[(int)characterNum.Value].GenoBeam);
                this.startingMagic.SetItemChecked(17, statsModel.Characters[(int)characterNum.Value].GenoBoost);
                this.startingMagic.SetItemChecked(18, statsModel.Characters[(int)characterNum.Value].GenoWhirl);
                this.startingMagic.SetItemChecked(19, statsModel.Characters[(int)characterNum.Value].GenoBlast);
                this.startingMagic.SetItemChecked(20, statsModel.Characters[(int)characterNum.Value].GenoFlash);
                this.startingMagic.SetItemChecked(21, statsModel.Characters[(int)characterNum.Value].Thunderbolt);
                this.startingMagic.SetItemChecked(22, statsModel.Characters[(int)characterNum.Value].HPRain);
                this.startingMagic.SetItemChecked(23, statsModel.Characters[(int)characterNum.Value].Psychopath);
                this.startingMagic.SetItemChecked(24, statsModel.Characters[(int)characterNum.Value].Shocker);
                this.startingMagic.SetItemChecked(25, statsModel.Characters[(int)characterNum.Value].Snowy);
                this.startingMagic.SetItemChecked(26, statsModel.Characters[(int)characterNum.Value].StarRain);

                this.startingCoins.Value = statsModel.Characters[0].StartingCoins;
                this.startingFrogCoins.Value = statsModel.Characters[0].StartingFrogCoins;
                this.startingCurrentFP.Value = statsModel.Characters[0].StartingCurrentFP;
                this.startingMaximumFP.Value = statsModel.Characters[0].StartingMaximumFP;
                updatingCharacters = false;
            }
        }
        private void RefreshSlotsTab()
        {
            this.startingItem.SelectedIndex = universal.ItemNames.GetIndexFromNum(statsModel.Slots[(int)this.slotNum.Value].Item);
            if (this.slotNum.Value <= 14)
            {
                this.startingSpecialItem.Enabled = true;
                this.startingSpecialItem.SelectedIndex = universal.ItemNames.GetIndexFromNum(statsModel.Slots[(int)this.slotNum.Value].SpecialItem);
            }
            else
            {
                this.startingSpecialItem.Enabled = false;
                this.startingSpecialItem.SelectedIndex = 0;
            }
            this.startingEquipment.SelectedIndex = universal.ItemNames.GetIndexFromNum(statsModel.Slots[(int)this.slotNum.Value].Equipment);
        }
        #region Character Event Handlers
        private void characterNum_ValueChanged(object sender, EventArgs e)
        {
            RefreshCharacterTab();
        }
        private void characterName_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.characterNum.Value = this.characterName.SelectedIndex;
        }
        private void characterName_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0 || e.Index > 4)
                return;

            char[] arr = statsModel.Characters[e.Index].Name.ToCharArray();
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == '.') arr[i] = (char)0x2A;
                if (arr[i] == ' ' && i == 0) arr[i] = (char)0x7F;
                if (arr[i] == '_') arr[i] = i == 0 ? (char)0x7F : (char)0x20;
                if (arr[i] == '&') arr[i] = (char)0x9C;
            }

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
            int[] temp = menuTextPreview.GetPreview(menuCharacters, palette, arr, false);
            int[] pixels = new int[256 * 14];

            for (int y = 2, c = 0; y < 14; y++, c++)
            {
                for (int x = 2, a = 0; x < 256; x++, a++)
                    pixels[y * 256 + x] = temp[c * 256 + a];
            }

            Bitmap icon = new Bitmap(DrawImageFromIntArr(pixels, 256, 14));

            e.DrawBackground();
            e.Graphics.DrawImage(icon, new Point(e.Bounds.X, e.Bounds.Y));
            e.DrawFocusRectangle();
        }
        private void textBoxCharacterName_TextChanged(object sender, EventArgs e)
        {
            statsModel.Characters[(int)characterNum.Value].Name = textBoxCharacterName.Text;

            InitializeCharacterStrings();
        }
        private void textBoxCharacterName_Leave(object sender, EventArgs e)
        {
            InitializeCharacterStrings();
        }
        private void levelNum_ValueChanged(object sender, EventArgs e)
        {
            RefreshCharacterLevel();
        }
        private void expNeeded_ValueChanged(object sender, EventArgs e)
        {
            statsModel.Characters[(int)this.characterNum.Value].LevelExpNeeded = (ushort)this.expNeeded.Value;
        }
        private void hpPlus_ValueChanged(object sender, EventArgs e)
        {
            statsModel.Characters[(int)this.characterNum.Value].LevelHpPlus = (byte)this.hpPlus.Value;
        }
        private void attackPlus_ValueChanged(object sender, EventArgs e)
        {
            statsModel.Characters[(int)this.characterNum.Value].LevelAttackPlus = (byte)this.attackPlus.Value;
        }
        private void defensePlus_ValueChanged(object sender, EventArgs e)
        {
            statsModel.Characters[(int)this.characterNum.Value].LevelDefensePlus = (byte)this.defensePlus.Value;
        }
        private void mgAttackPlus_ValueChanged(object sender, EventArgs e)
        {
            statsModel.Characters[(int)this.characterNum.Value].LevelMgAttackPlus = (byte)this.mgAttackPlus.Value;
        }
        private void mgDefensePlus_ValueChanged(object sender, EventArgs e)
        {
            statsModel.Characters[(int)this.characterNum.Value].LevelMgDefensePlus = (byte)this.mgDefensePlus.Value;
        }
        private void hpPlusBonus_ValueChanged(object sender, EventArgs e)
        {
            statsModel.Characters[(int)this.characterNum.Value].LevelHpPlusBonus = (byte)this.hpPlusBonus.Value;
        }
        private void attackPlusBonus_ValueChanged(object sender, EventArgs e)
        {
            statsModel.Characters[(int)this.characterNum.Value].LevelAttackPlusBonus = (byte)this.attackPlusBonus.Value;
        }
        private void defensePlusBonus_ValueChanged(object sender, EventArgs e)
        {
            statsModel.Characters[(int)this.characterNum.Value].LevelDefensePlusBonus = (byte)this.defensePlusBonus.Value;
        }
        private void mgAttackPlusBonus_ValueChanged(object sender, EventArgs e)
        {
            statsModel.Characters[(int)this.characterNum.Value].LevelMgAttackPlusBonus = (byte)this.mgAttackPlusBonus.Value;
        }
        private void mgDefensePlusBonus_ValueChanged(object sender, EventArgs e)
        {
            statsModel.Characters[(int)this.characterNum.Value].LevelMgDefensePlusBonus = (byte)this.mgDefensePlusBonus.Value;
        }
        private void levelUpSpellLearned_SelectedIndexChanged(object sender, EventArgs e)
        {
            statsModel.Characters[(int)this.characterNum.Value].LevelSpellLearned = (byte)this.levelUpSpellLearned.SelectedIndex;
        }
        private void levelUpSpellLearned_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0 || e.Index > 32)
                return;

            if (e.Index == 32)
            {
                e.DrawBackground();
                e.Graphics.DrawString("{NOTHING}", e.Font, new SolidBrush(levelUpSpellLearned.ForeColor), e.Bounds);
                e.DrawFocusRectangle();
                return;
            }

            char[] test = levelUpSpellLearned.Items[e.Index].ToString().ToCharArray();
            for (int i = 0; i < test.Length; i++)
            {
                if (test[i] == 0x2E) test[i] = (char)0x2A;
                if (test[i] == 0x21) test[i] = (char)0x7B;
                if (test[i] == 0x2D) test[i] = (char)0x7D;
                if (test[i] == 0x27) test[i] = (char)0x7E;
                if (test[i] == 0x5F) test[i] = (char)0x7F;
            }

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
            int[] temp = menuTextPreview.GetPreview(menuCharacters, palette, test, false);
            int[] pixels = new int[256 * 14];

            for (int y = 2, c = 0; y < 14; y++, c++)
            {
                for (int x = 2, a = 0; x < 256; x++, a++)
                    pixels[y * 256 + x] = temp[c * 256 + a];
            }

            Bitmap icon = new Bitmap(DrawImageFromIntArr(pixels, 256, 14));

            e.DrawBackground();
            e.Graphics.DrawImage(icon, new Point(e.Bounds.X, e.Bounds.Y));
            e.DrawFocusRectangle();
        }
        private void startingLevel_ValueChanged(object sender, EventArgs e)
        {
            statsModel.Characters[(int)this.characterNum.Value].StartingLevel = (byte)this.startingLevel.Value;
        }
        private void startingAttack_ValueChanged(object sender, EventArgs e)
        {
            statsModel.Characters[(int)this.characterNum.Value].StartingAttack = (byte)this.startingAttack.Value;
        }
        private void startingDefense_ValueChanged(object sender, EventArgs e)
        {
            statsModel.Characters[(int)this.characterNum.Value].StartingDefense = (byte)this.startingDefense.Value;
        }
        private void startingMgAttack_ValueChanged(object sender, EventArgs e)
        {
            statsModel.Characters[(int)this.characterNum.Value].StartingMgAttack = (byte)this.startingMgAttack.Value;
        }
        private void startingMgDefense_ValueChanged(object sender, EventArgs e)
        {
            statsModel.Characters[(int)this.characterNum.Value].StartingMgDefense = (byte)this.startingMgDefense.Value;
        }
        private void startingSpeed_ValueChanged(object sender, EventArgs e)
        {
            statsModel.Characters[(int)this.characterNum.Value].StartingSpeed = (byte)this.startingSpeed.Value;
        }
        private void startingWeapon_SelectedIndexChanged(object sender, EventArgs e)
        {
            statsModel.Characters[(int)this.characterNum.Value].StartingWeapon = (byte)universal.ItemNames.GetNumFromIndex(this.startingWeapon.SelectedIndex);
        }
        private void startingArmor_SelectedIndexChanged(object sender, EventArgs e)
        {
            statsModel.Characters[(int)this.characterNum.Value].StartingArmor = (byte)universal.ItemNames.GetNumFromIndex(this.startingArmor.SelectedIndex);
        }
        private void startingAccessory_SelectedIndexChanged(object sender, EventArgs e)
        {
            statsModel.Characters[(int)this.characterNum.Value].StartingAccessory = (byte)universal.ItemNames.GetNumFromIndex(this.startingAccessory.SelectedIndex);
        }
        private void startingExperience_ValueChanged(object sender, EventArgs e)
        {
            statsModel.Characters[(int)this.characterNum.Value].StartingExperience = (ushort)this.startingExperience.Value;
        }
        private void startingCurrentHP_ValueChanged(object sender, EventArgs e)
        {
            statsModel.Characters[(int)this.characterNum.Value].StartingCurrentHP = (ushort)this.startingCurrentHP.Value;
        }
        private void startingMaximumHP_ValueChanged(object sender, EventArgs e)
        {
            statsModel.Characters[(int)this.characterNum.Value].StartingMaxHP = (ushort)this.startingMaximumHP.Value;
        }
        private void startingMagic_SelectedIndexChanged(object sender, EventArgs e)
        {
            statsModel.Characters[(int)characterNum.Value].Jump = this.startingMagic.GetItemChecked(0);
            statsModel.Characters[(int)characterNum.Value].FireOrb = this.startingMagic.GetItemChecked(1);
            statsModel.Characters[(int)characterNum.Value].SuperJump = this.startingMagic.GetItemChecked(2);
            statsModel.Characters[(int)characterNum.Value].SuperFlame = this.startingMagic.GetItemChecked(3);
            statsModel.Characters[(int)characterNum.Value].UltraJump = this.startingMagic.GetItemChecked(4);
            statsModel.Characters[(int)characterNum.Value].UltraFlame = this.startingMagic.GetItemChecked(5);
            statsModel.Characters[(int)characterNum.Value].Therapy = this.startingMagic.GetItemChecked(6);
            statsModel.Characters[(int)characterNum.Value].GroupHug = this.startingMagic.GetItemChecked(7);
            statsModel.Characters[(int)characterNum.Value].SleepyTime = this.startingMagic.GetItemChecked(8);
            statsModel.Characters[(int)characterNum.Value].ComeBack = this.startingMagic.GetItemChecked(9);
            statsModel.Characters[(int)characterNum.Value].Mute = this.startingMagic.GetItemChecked(10);
            statsModel.Characters[(int)characterNum.Value].PsychBomb = this.startingMagic.GetItemChecked(11);
            statsModel.Characters[(int)characterNum.Value].Terrorize = this.startingMagic.GetItemChecked(12);
            statsModel.Characters[(int)characterNum.Value].PoisonGas = this.startingMagic.GetItemChecked(13);
            statsModel.Characters[(int)characterNum.Value].Crusher = this.startingMagic.GetItemChecked(14);
            statsModel.Characters[(int)characterNum.Value].BowserCrush = this.startingMagic.GetItemChecked(15);
            statsModel.Characters[(int)characterNum.Value].GenoBeam = this.startingMagic.GetItemChecked(16);
            statsModel.Characters[(int)characterNum.Value].GenoBoost = this.startingMagic.GetItemChecked(17);
            statsModel.Characters[(int)characterNum.Value].GenoWhirl = this.startingMagic.GetItemChecked(18);
            statsModel.Characters[(int)characterNum.Value].GenoBlast = this.startingMagic.GetItemChecked(19);
            statsModel.Characters[(int)characterNum.Value].GenoFlash = this.startingMagic.GetItemChecked(20);
            statsModel.Characters[(int)characterNum.Value].Thunderbolt = this.startingMagic.GetItemChecked(21);
            statsModel.Characters[(int)characterNum.Value].HPRain = this.startingMagic.GetItemChecked(22);
            statsModel.Characters[(int)characterNum.Value].Psychopath = this.startingMagic.GetItemChecked(23);
            statsModel.Characters[(int)characterNum.Value].Shocker = this.startingMagic.GetItemChecked(24);
            statsModel.Characters[(int)characterNum.Value].Snowy = this.startingMagic.GetItemChecked(25);
            statsModel.Characters[(int)characterNum.Value].StarRain = this.startingMagic.GetItemChecked(26);
        }
        private void startingCoins_ValueChanged(object sender, EventArgs e)
        {
            statsModel.Characters[(int)this.characterNum.Value].StartingCoins = (ushort)this.startingCoins.Value;
        }
        private void startingFrogCoins_ValueChanged(object sender, EventArgs e)
        {
            statsModel.Characters[(int)this.characterNum.Value].StartingFrogCoins = (ushort)this.startingFrogCoins.Value;
        }
        private void startingCurrentFP_ValueChanged(object sender, EventArgs e)
        {
            statsModel.Characters[(int)this.characterNum.Value].StartingCurrentFP = (byte)this.startingCurrentFP.Value;
        }
        private void startingMaximumFP_ValueChanged(object sender, EventArgs e)
        {
            statsModel.Characters[(int)this.characterNum.Value].StartingMaximumFP = (byte)this.startingMaximumFP.Value;
        }
        #endregion
        #region Slot Event Handlers
        private void slotNum_ValueChanged(object sender, EventArgs e)
        {
            RefreshSlotsTab();
        }
        private void startingItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            statsModel.Slots[(int)slotNum.Value].Item = (byte)universal.ItemNames.GetNumFromIndex(this.startingItem.SelectedIndex);
        }
        private void startingSpecialItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            statsModel.Slots[(int)slotNum.Value].SpecialItem = (byte)universal.ItemNames.GetNumFromIndex(this.startingSpecialItem.SelectedIndex);
        }
        private void startingEquipment_SelectedIndexChanged(object sender, EventArgs e)
        {
            statsModel.Slots[(int)slotNum.Value].Equipment = (byte)universal.ItemNames.GetNumFromIndex(this.startingEquipment.SelectedIndex);
        }
        #endregion

    }
}
