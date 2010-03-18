using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SMRPGED.StatsEditor
{
    public partial class StatsEditor
    {
        private bool updatingSpells = false;
        private void InitializeSpells()
        {
            this.spellName.SelectedIndex = universal.SpellNames.GetIndexFromNum(0);

            RefreshSpellTab();
        }
        private void InitializeSpellStrings()
        {
            universal.SpellNames = new DDlistName(statsModel.Spells);

            this.levelUpSpellLearned.Items.Clear();
            for (int i = 0; i < 32; i++)
                this.levelUpSpellLearned.Items.Add(statsModel.Spells[i].Name);
            this.levelUpSpellLearned.Items.Add("NOTHING");
            this.levelUpSpellLearned.SelectedIndex = statsModel.Characters[(int)this.characterNum.Value].LevelSpellLearned;

            this.startingMagic.Items.Clear();
            for (int i = 0; i < 27; i++)
                this.startingMagic.Items.Add(statsModel.Spells[i].Name);
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

            universal.SpellNames.SortAlpha();

            this.spellName.Items.Clear();
            this.spellName.Items.AddRange(universal.SpellNames.Names);
            this.spellName.SelectedIndex = universal.SpellNames.GetIndexFromNum((int)this.spellNum.Value);

            InitializeTimingStrings();
        }
        private void RefreshSpellTab()
        {
            if (!updatingSpells)
            {
                updatingSpells = true;

                this.spellName.SelectedIndex = universal.SpellNames.GetIndexFromNum((int)this.spellNum.Value);

                this.spellFPCost.Value = statsModel.Spells[(int)this.spellNum.Value].FPCost;
                this.spellMagPower.Value = statsModel.Spells[(int)this.spellNum.Value].MagicPower;
                this.spellHitRate.Value = statsModel.Spells[(int)this.spellNum.Value].HitRate;

                this.textBoxSpellName.Text = statsModel.Spells[(int)this.spellNum.Value].Name;
                if ((int)this.spellNum.Value > 0x1A)
                {
                    this.textBoxSpellDescription.Text = "This spell cannot have a description";
                    this.textBoxSpellDescription.Enabled = false;
                    this.button34.Enabled = false; // Break
                    this.button33.Enabled = false; // End
                }
                else
                {
                    if (this.textBoxSpellDescription.Enabled == false)
                    {
                        this.textBoxSpellDescription.Enabled = true;
                        this.button34.Enabled = true; // Break
                        this.button33.Enabled = true; // End
                    }

                    if (spellNum.Value <= 0x1A)
                    {
                        this.textBoxSpellDescription.Enabled = true;
                        this.button33.Enabled = true;
                        this.button34.Enabled = true;
                        this.textBoxSpellDescription.Text = statsModel.Spells[(int)this.spellNum.Value].GetDescription(textCodeFormat);
                    }
                    else
                    {
                        this.textBoxSpellDescription.Enabled = false;
                        this.button33.Enabled = false;
                        this.button34.Enabled = false;
                        this.textBoxSpellDescription.Text = "This spell cannot have a description";
                    }
                    /*
                    if (textCodeFormat)
                        this.textBoxSpellDescription.SelectionStart = statsModel.Spells[(int)this.spellNum.Value].CaretPositionSymbol;
                    else
                        this.textBoxSpellDescription.SelectionStart = statsModel.Spells[(int)this.spellNum.Value].CaretPositionNotSymbol;
                    */
                }

                this.spellAttackProp.SetItemChecked(0, statsModel.Spells[(int)this.spellNum.Value].CheckStats);
                this.spellAttackProp.SetItemChecked(1, statsModel.Spells[(int)this.spellNum.Value].IgnoreDefense);
                this.spellAttackProp.SetItemChecked(2, statsModel.Spells[(int)this.spellNum.Value].CheckMortality);
                this.spellAttackProp.SetItemChecked(3, statsModel.Spells[(int)this.spellNum.Value].UsableOverworld);
                this.spellAttackProp.SetItemChecked(4, statsModel.Spells[(int)this.spellNum.Value].MaxAttack);
                this.spellAttackProp.SetItemChecked(5, statsModel.Spells[(int)this.spellNum.Value].HideDigits);
                this.spellStatusEffect.SetItemChecked(0, statsModel.Spells[(int)this.spellNum.Value].EffectMute);
                this.spellStatusEffect.SetItemChecked(1, statsModel.Spells[(int)this.spellNum.Value].EffectSleep);
                this.spellStatusEffect.SetItemChecked(2, statsModel.Spells[(int)this.spellNum.Value].EffectPoison);
                this.spellStatusEffect.SetItemChecked(3, statsModel.Spells[(int)this.spellNum.Value].EffectFear);
                this.spellStatusEffect.SetItemChecked(4, statsModel.Spells[(int)this.spellNum.Value].EffectMushroom);
                this.spellStatusEffect.SetItemChecked(5, statsModel.Spells[(int)this.spellNum.Value].EffectScarecrow);
                this.spellStatusEffect.SetItemChecked(6, statsModel.Spells[(int)this.spellNum.Value].EffectInvincible);
                this.spellStatusChange.SetItemChecked(0, statsModel.Spells[(int)this.spellNum.Value].ChangeAttack);
                this.spellStatusChange.SetItemChecked(1, statsModel.Spells[(int)this.spellNum.Value].ChangeDefense);
                this.spellStatusChange.SetItemChecked(2, statsModel.Spells[(int)this.spellNum.Value].ChangeMagicAttack);
                this.spellStatusChange.SetItemChecked(3, statsModel.Spells[(int)this.spellNum.Value].ChangeMagicDefense);
                this.spellTargetting.SetItemChecked(0, statsModel.Spells[(int)this.spellNum.Value].TargetLiveAlly);
                this.spellTargetting.SetItemChecked(1, statsModel.Spells[(int)this.spellNum.Value].TargetEnemy);
                this.spellTargetting.SetItemChecked(2, statsModel.Spells[(int)this.spellNum.Value].TargetAll);
                this.spellTargetting.SetItemChecked(3, statsModel.Spells[(int)this.spellNum.Value].TargetWoundedOnly);
                this.spellTargetting.SetItemChecked(4, statsModel.Spells[(int)this.spellNum.Value].TargetOnePartyOnly);
                this.spellTargetting.SetItemChecked(5, statsModel.Spells[(int)this.spellNum.Value].TargetNotSelf);

                this.comboBox3.SelectedIndex = statsModel.Spells[(int)this.spellNum.Value].AttackType;
                this.comboBox4.SelectedIndex = statsModel.Spells[(int)this.spellNum.Value].EffectType;
                this.spellFunction.SelectedIndex = statsModel.Spells[(int)this.spellNum.Value].InflictFunction;
                this.comboBox5.SelectedIndex = statsModel.Spells[(int)this.spellNum.Value].InflictElement;

                if (statsModel.Spells[(int)this.spellNum.Value].EffectType == 0)
                {
                    this.label62.Text = "EFFECT <INFLICT>";
                    this.label61.Text = "STATUS <UP>";
                }
                else if (statsModel.Spells[(int)this.spellNum.Value].EffectType == 1)
                {
                    this.label62.Text = "EFFECT <NULLIFY>";
                    this.label61.Text = "STATUS <DOWN>";
                }
                else if (statsModel.Spells[(int)this.spellNum.Value].EffectType == 2)
                {
                    this.label62.Text = "EFFECT <. . . .>";
                    this.label61.Text = "STATUS <. . . .>";
                }

                updatingSpells = false;
            }
        }

        private void SaveSpellNotes()
        {
            try
            {
                this.richTextBox9.SaveFile(notes.GetPath() + "main-stats-spells.rtf");
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Error saving spell notes. Please report this");
            }
        }
        #region Event Handlers
        private void spellNum_ValueChanged(object sender, EventArgs e)
        {
            RefreshSpellTab();
        }
        private void spellName_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.spellNum.Value = universal.SpellNames.GetNumFromIndex(spellName.SelectedIndex);
        }
        private void spellName_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0 || e.Index > 127)
                return;

            char[] arr = statsModel.Spells[universal.SpellNames.GetNumFromIndex(e.Index)].Name.ToCharArray();
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == '.') arr[i] = (char)0x2A;
                if (arr[i] == '!') arr[i] = (char)0x7B;
                if (arr[i] == '-') arr[i] = (char)0x7D;
                if (arr[i] == '\'') arr[i] = (char)0x7E;
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
        private void textBoxSpellName_TextChanged(object sender, EventArgs e)
        {
            if (universal.SpellNames.GetNameByNum(statsModel.Spells[(int)this.spellNum.Value].SpellNum).CompareTo(this.textBoxSpellName.Text) != 0)
            {
                statsModel.Spells[(int)spellNum.Value].Name = this.textBoxSpellName.Text;

                universal.SpellNames.SwapName(statsModel.Spells[(int)spellNum.Value].SpellNum, statsModel.Spells[(int)spellNum.Value].Name);
                universal.SpellNames.SortAlpha();
                this.spellName.Items.Clear();
                this.spellName.Items.AddRange(universal.SpellNames.GetNames());

                this.spellName.SelectedIndex = universal.SpellNames.GetIndexFromNum(statsModel.Spells[(int)this.spellNum.Value].SpellNum);
            }
        }
        private void textBoxSpellName_Leave(object sender, EventArgs e)
        {
            spellName.Items.Clear();
            spellName.Items.AddRange(this.universal.SpellNames.GetNames());
            spellName.SelectedIndex = universal.SpellNames.GetIndexFromNum(statsModel.Spells[(int)spellNum.Value].SpellNum);
            InitializeSpellStrings();
            InitializeTimingStrings();
        }
        private void spellFPCost_ValueChanged(object sender, EventArgs e)
        {
            statsModel.Spells[(int)spellNum.Value].FPCost = (byte)this.spellFPCost.Value;
        }
        private void spellMagPower_ValueChanged(object sender, EventArgs e)
        {
            statsModel.Spells[(int)spellNum.Value].MagicPower = (byte)this.spellMagPower.Value;
        }
        private void spellHitRate_ValueChanged(object sender, EventArgs e)
        {
            statsModel.Spells[(int)spellNum.Value].HitRate = (byte)this.spellHitRate.Value;
        }
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            statsModel.Spells[(int)spellNum.Value].AttackType = (byte)this.comboBox3.SelectedIndex;
        }
        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            statsModel.Spells[(int)spellNum.Value].EffectType = (byte)this.comboBox4.SelectedIndex;

            if (statsModel.Spells[(int)this.spellNum.Value].EffectType == 0)
            {
                this.label62.Text = "EFFECT <INFLICT>";
                this.label61.Text = "STATUS <UP>";
            }
            else if (statsModel.Spells[(int)this.spellNum.Value].EffectType == 1)
            {
                this.label62.Text = "EFFECT <NULLIFY>";
                this.label61.Text = "STATUS <DOWN>";
            }
            else if (statsModel.Spells[(int)this.spellNum.Value].EffectType == 2)
            {
                this.label62.Text = "EFFECT <. . . .>";
                this.label61.Text = "STATUS <. . . .>";
            }
        }
        private void spellFunction_SelectedIndexChanged(object sender, EventArgs e)
        {
            statsModel.Spells[(int)spellNum.Value].InflictFunction = (byte)this.spellFunction.SelectedIndex;
        }
        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            statsModel.Spells[(int)spellNum.Value].InflictElement = (byte)this.comboBox5.SelectedIndex;
        }
        private void spellAttackProp_SelectedIndexChanged(object sender, EventArgs e)
        {
            statsModel.Spells[(int)spellNum.Value].CheckStats = this.spellAttackProp.GetItemChecked(0);
            statsModel.Spells[(int)spellNum.Value].IgnoreDefense = this.spellAttackProp.GetItemChecked(1);
            statsModel.Spells[(int)spellNum.Value].CheckMortality = this.spellAttackProp.GetItemChecked(2);
            statsModel.Spells[(int)spellNum.Value].UsableOverworld = this.spellAttackProp.GetItemChecked(3);
            statsModel.Spells[(int)spellNum.Value].MaxAttack = this.spellAttackProp.GetItemChecked(4);
            statsModel.Spells[(int)spellNum.Value].HideDigits = this.spellAttackProp.GetItemChecked(5);
        }
        private void spellStatusEffect_SelectedIndexChanged(object sender, EventArgs e)
        {
            statsModel.Spells[(int)spellNum.Value].EffectMute = this.spellStatusEffect.GetItemChecked(0);
            statsModel.Spells[(int)spellNum.Value].EffectSleep = this.spellStatusEffect.GetItemChecked(1);
            statsModel.Spells[(int)spellNum.Value].EffectPoison = this.spellStatusEffect.GetItemChecked(2);
            statsModel.Spells[(int)spellNum.Value].EffectFear = this.spellStatusEffect.GetItemChecked(3);
            statsModel.Spells[(int)spellNum.Value].EffectMushroom = this.spellStatusEffect.GetItemChecked(4);
            statsModel.Spells[(int)spellNum.Value].EffectScarecrow = this.spellStatusEffect.GetItemChecked(5);
            statsModel.Spells[(int)spellNum.Value].EffectInvincible = this.spellStatusEffect.GetItemChecked(6);
        }
        private void spellTargetting_SelectedIndexChanged(object sender, EventArgs e)
        {
            statsModel.Spells[(int)spellNum.Value].TargetLiveAlly = this.spellTargetting.GetItemChecked(0);
            statsModel.Spells[(int)spellNum.Value].TargetEnemy = this.spellTargetting.GetItemChecked(1);
            statsModel.Spells[(int)spellNum.Value].TargetAll = this.spellTargetting.GetItemChecked(2);
            statsModel.Spells[(int)spellNum.Value].TargetWoundedOnly = this.spellTargetting.GetItemChecked(3);
            statsModel.Spells[(int)spellNum.Value].TargetOnePartyOnly = this.spellTargetting.GetItemChecked(4);
            statsModel.Spells[(int)spellNum.Value].TargetNotSelf = this.spellTargetting.GetItemChecked(5);
        }
        private void spellStatusChange_SelectedIndexChanged(object sender, EventArgs e)
        {
            statsModel.Spells[(int)spellNum.Value].ChangeAttack = this.spellStatusChange.GetItemChecked(0);
            statsModel.Spells[(int)spellNum.Value].ChangeDefense = this.spellStatusChange.GetItemChecked(1);
            statsModel.Spells[(int)spellNum.Value].ChangeMagicAttack = this.spellStatusChange.GetItemChecked(2);
            statsModel.Spells[(int)spellNum.Value].ChangeMagicDefense = this.spellStatusChange.GetItemChecked(3);
        }
        private void textBoxSpellDescription_TextChanged(object sender, EventArgs e)
        {
            char[] text = textBoxSpellDescription.Text.ToCharArray();
            char[] swap;
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == '\n')
                {
                    int tempSel = textBoxSpellDescription.SelectionStart;
                    swap = new char[text.Length + 2];
                    for (int x = 0; x < i; x++)
                        swap[x] = text[x];
                    swap[i] = '[';
                    swap[i + 1] = '1';
                    swap[i + 2] = ']';
                    for (int x = i + 3; x < swap.Length; x++)
                        swap[x] = text[x - 2];
                    textBoxSpellDescription.Text = new string(swap);
                    text = textBoxSpellDescription.Text.ToCharArray();
                    i += 2;
                    textBoxSpellDescription.SelectionStart = tempSel + 2;
                }
            }

            bool flag = textHelper.VerifyCorrectSymbols(this.textBoxSpellDescription.Text.ToCharArray(), textCodeFormat);
            if (flag)
            {
                this.textBoxSpellDescription.BackColor = System.Drawing.Color.FromArgb(255, 255, 255, 255);
                statsModel.Spells[(int)spellNum.Value].SetDescription(this.textBoxSpellDescription.Text, textCodeFormat);
            }
            if (!flag || statsModel.Spells[(int)spellNum.Value].DescriptionError)
                this.textBoxSpellDescription.BackColor = System.Drawing.Color.Red;

            SetSpellDescImage();
        }
        private void button34_Click(object sender, EventArgs e)
        {
            // newline
            if (textCodeFormat)
                InsertIntoSpellDescriptionText("[1]");
            else
                InsertIntoSpellDescriptionText("[newLine]");
        }
        private void button33_Click(object sender, EventArgs e)
        {
            // end
            if (textCodeFormat)
                InsertIntoSpellDescriptionText("[0]");
            else
                InsertIntoSpellDescriptionText("[endInput]");
        }

        private void pictureBoxSpellDesc_Paint(object sender, PaintEventArgs e)
        {
            if (menuBGImage != null)
                e.Graphics.DrawImage(menuBGImage, 0, 0);
            if (spellDescImage != null)
                e.Graphics.DrawImage(spellDescImage, 0, 0);
            if (menuFrameSpellImage != null)
                e.Graphics.DrawImage(menuFrameSpellImage, 0, 0);
        }

        private int[] spellDescPixels;
        private Bitmap spellDescImage;
        private void SetSpellDescImage()
        {
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

            spellDescPixels = menuDescPreview.GetPreview(
                descCharacters, palette, statsModel.Spells[(int)spellNum.Value].RawDescription,
                new Size(120, 88), new Point(8, 8), 6);
            spellDescImage = new Bitmap(DrawImageFromIntArr(spellDescPixels, 120, 88));
            pictureBoxSpellDesc.Invalidate();
        }

        #endregion
        #region Text Helpers
        public void InsertIntoSpellDescriptionText(string toInsert)
        {
            char[] newText = new char[textBoxSpellDescription.Text.Length + toInsert.Length];

            textBoxSpellDescription.Text.CopyTo(0, newText, 0, textBoxSpellDescription.SelectionStart);
            toInsert.CopyTo(0, newText, textBoxSpellDescription.SelectionStart, toInsert.Length);
            textBoxSpellDescription.Text.CopyTo(textBoxSpellDescription.SelectionStart, newText, textBoxSpellDescription.SelectionStart + toInsert.Length, this.textBoxSpellDescription.Text.Length - this.textBoxSpellDescription.SelectionStart);

            if (textCodeFormat)
                statsModel.Spells[(int)spellNum.Value].CaretPositionSymbol = this.textBoxSpellDescription.SelectionStart + toInsert.Length;
            else
                statsModel.Spells[(int)spellNum.Value].CaretPositionNotSymbol = this.textBoxSpellDescription.SelectionStart + toInsert.Length;
            statsModel.Spells[(int)spellNum.Value].SetDescription(new string(newText), textCodeFormat);

            textBoxSpellDescription.Text = statsModel.Spells[(int)spellNum.Value].GetDescription(textCodeFormat);
        }
        #endregion

    }
}
