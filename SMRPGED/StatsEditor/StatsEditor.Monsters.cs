using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace SMRPGED.StatsEditor
{
    public partial class StatsEditor
    {
        private bool updatingMonsters = false;

        private Bitmap monsterImage;
        private Bitmap psychopathBGImage;
        private Bitmap psychopathTextImage;

        private void InitializeMonsters()
        {
            this.monsterName.SelectedIndex = universal.MonsterNames.GetIndexFromNum(0);

            RefreshMonsterTab();
        }
        private void InitializeMonsterStrings()
        {
            universal.MonsterNames = new DDlistName(statsModel.Monsters);
            universal.MonsterNames.SortAlpha();

            this.monsterName.Items.Clear();
            this.monsterName.Items.AddRange(universal.MonsterNames.Names);

            this.formationName1.Items.Clear();
            this.formationName2.Items.Clear();
            this.formationName3.Items.Clear();
            this.formationName4.Items.Clear();
            this.formationName5.Items.Clear();
            this.formationName6.Items.Clear();
            this.formationName7.Items.Clear();
            this.formationName8.Items.Clear();
            this.formationName1.Items.AddRange(universal.MonsterNames.Names);
            this.formationName2.Items.AddRange(universal.MonsterNames.Names);
            this.formationName3.Items.AddRange(universal.MonsterNames.Names);
            this.formationName4.Items.AddRange(universal.MonsterNames.Names);
            this.formationName5.Items.AddRange(universal.MonsterNames.Names);
            this.formationName6.Items.AddRange(universal.MonsterNames.Names);
            this.formationName7.Items.AddRange(universal.MonsterNames.Names);
            this.formationName8.Items.AddRange(universal.MonsterNames.Names);

        }
        private void RefreshMonsterTab()
        {
            if (!updatingMonsters)
            {
                updatingMonsters = true;

                this.monsterName.SelectedIndex = universal.MonsterNames.GetIndexFromNum((int)MonsterNumber.Value);
                this.TextboxMonsterName.Text = statsModel.Monsters[(int)MonsterNumber.Value].Name;
                this.MonsterValHP.Value = statsModel.Monsters[(int)MonsterNumber.Value].HP;
                this.MonsterValSpeed.Value = statsModel.Monsters[(int)MonsterNumber.Value].Speed;
                this.MonsterValAtk.Value = statsModel.Monsters[(int)MonsterNumber.Value].Attack;
                this.MonsterValMgDef.Value = statsModel.Monsters[(int)MonsterNumber.Value].MagicDefense;
                this.MonsterValMgAtk.Value = statsModel.Monsters[(int)MonsterNumber.Value].MagicAttack;
                this.MonsterValDef.Value = statsModel.Monsters[(int)MonsterNumber.Value].Defense;
                this.MonsterValMgEvd.Value = statsModel.Monsters[(int)MonsterNumber.Value].MagicEvadePercent;
                this.MonsterValEvd.Value = statsModel.Monsters[(int)MonsterNumber.Value].EvadePercent;
                this.MonsterValFP.Value = statsModel.Monsters[(int)MonsterNumber.Value].FP;
                this.MonsterValExp.Value = statsModel.Monsters[(int)MonsterNumber.Value].Experience;
                this.MonsterValCoins.Value = statsModel.Monsters[(int)MonsterNumber.Value].Coins;
                this.MonsterValElevation.Value = statsModel.Monsters[(int)MonsterNumber.Value].Elevation;
                this.MonsterValFlowerOdds.Value = statsModel.Monsters[(int)MonsterNumber.Value].FlowerOdds;
                this.TextboxMonsterPsychoMsg.Text = statsModel.Monsters[(int)MonsterNumber.Value].GetPsychoMsg(textCodeFormat);
                this.CheckboxMonsterElemNull.SetItemChecked(0, statsModel.Monsters[(int)MonsterNumber.Value].ElemIceNull);
                this.CheckboxMonsterElemNull.SetItemChecked(1, statsModel.Monsters[(int)MonsterNumber.Value].ElemFireNull);
                this.CheckboxMonsterElemNull.SetItemChecked(2, statsModel.Monsters[(int)MonsterNumber.Value].ElemThunderNull);
                this.CheckboxMonsterElemNull.SetItemChecked(3, statsModel.Monsters[(int)MonsterNumber.Value].ElemJumpNull);
                this.CheckboxMonsterProp.SetItemChecked(0, statsModel.Monsters[(int)MonsterNumber.Value].Invincible);
                this.CheckboxMonsterProp.SetItemChecked(1, statsModel.Monsters[(int)MonsterNumber.Value].ProtectAgainstInstantDeath);
                this.CheckboxMonsterProp.SetItemChecked(2, statsModel.Monsters[(int)MonsterNumber.Value].LetBattleScriptRemove);
                this.CheckboxMonsterProp.SetItemChecked(3, statsModel.Monsters[(int)MonsterNumber.Value].UsedByCrystals);
                this.CheckboxMonsterEfecNull.SetItemChecked(0, statsModel.Monsters[(int)MonsterNumber.Value].EffectMuteNull);
                this.CheckboxMonsterEfecNull.SetItemChecked(1, statsModel.Monsters[(int)MonsterNumber.Value].EffectSleepNull);
                this.CheckboxMonsterEfecNull.SetItemChecked(2, statsModel.Monsters[(int)MonsterNumber.Value].EffectPoisonNull);
                this.CheckboxMonsterEfecNull.SetItemChecked(3, statsModel.Monsters[(int)MonsterNumber.Value].EffectFearNull);
                this.CheckboxMonsterEfecNull.SetItemChecked(4, statsModel.Monsters[(int)MonsterNumber.Value].EffectMushroomNull);
                this.CheckboxMonsterEfecNull.SetItemChecked(5, statsModel.Monsters[(int)MonsterNumber.Value].EffectScarecrowNull);
                this.CheckboxMonsterEfecNull.SetItemChecked(6, statsModel.Monsters[(int)MonsterNumber.Value].EffectInvincibleNull);
                this.CheckboxMonsterElemWeak.SetItemChecked(0, statsModel.Monsters[(int)MonsterNumber.Value].ElemIceWeak);
                this.CheckboxMonsterElemWeak.SetItemChecked(1, statsModel.Monsters[(int)MonsterNumber.Value].ElemFireWeak);
                this.CheckboxMonsterElemWeak.SetItemChecked(2, statsModel.Monsters[(int)MonsterNumber.Value].ElemThunderWeak);
                this.CheckboxMonsterElemWeak.SetItemChecked(3, statsModel.Monsters[(int)MonsterNumber.Value].ElemJumpWeak);
                this.MonsterFlowerBonus.SelectedIndex = statsModel.Monsters[(int)MonsterNumber.Value].FlowerBonus;
                this.MonsterMorphSuccess.SelectedIndex = statsModel.Monsters[(int)MonsterNumber.Value].MorphSuccessRate;
                this.MonsterCoinSize.SelectedIndex = statsModel.Monsters[(int)MonsterNumber.Value].CoinSize;
                this.MonsterBehavior.SelectedIndex = statsModel.Monsters[(int)MonsterNumber.Value].DeathAnimation;
                this.MonsterEntranceStyle.SelectedIndex = statsModel.Monsters[(int)MonsterNumber.Value].EntranceStyle;
                this.MonsterSoundOther.SelectedIndex = statsModel.Monsters[(int)MonsterNumber.Value].OtherSound;
                this.MonsterSoundStrike.SelectedIndex = statsModel.Monsters[(int)MonsterNumber.Value].StrikeSound;
                this.MonsterYoshiCookie.SelectedIndex = universal.ItemNames.GetIndexFromNum(statsModel.Monsters[(int)MonsterNumber.Value].YoshiCookie);
                this.ItemWinA.SelectedIndex = universal.ItemNames.GetIndexFromNum(statsModel.Monsters[(int)MonsterNumber.Value].ItemWinA);
                this.ItemWinB.SelectedIndex = universal.ItemNames.GetIndexFromNum(statsModel.Monsters[(int)MonsterNumber.Value].ItemWinB);

                this.monsterTargetArrowX.Value = statsModel.Monsters[(int)MonsterNumber.Value].CursorX;
                this.monsterTargetArrowY.Value = statsModel.Monsters[(int)MonsterNumber.Value].CursorY;

                monsterImage = new Bitmap(statsModel.Monsters[(int)MonsterNumber.Value].Image);
                pictureBoxMonster.Invalidate();

                updatingMonsters = false;
            }

        }
        public void InsertIntoMonsterPsychoMsgText(string toInsert)
        {
            char[] newText = new char[this.TextboxMonsterPsychoMsg.Text.Length + toInsert.Length];

            TextboxMonsterPsychoMsg.Text.CopyTo(0, newText, 0, TextboxMonsterPsychoMsg.SelectionStart);
            toInsert.CopyTo(0, newText, TextboxMonsterPsychoMsg.SelectionStart, toInsert.Length);
            TextboxMonsterPsychoMsg.Text.CopyTo(TextboxMonsterPsychoMsg.SelectionStart, newText, TextboxMonsterPsychoMsg.SelectionStart + toInsert.Length, this.TextboxMonsterPsychoMsg.Text.Length - this.TextboxMonsterPsychoMsg.SelectionStart);

            // 2009-3-29 : psychopath message was being saved to the item description and vice versa, now fixed
            if (textCodeFormat)
                statsModel.Monsters[(int)MonsterNumber.Value].CaretPositionSymbol = this.TextboxMonsterPsychoMsg.SelectionStart + toInsert.Length;
            else
                statsModel.Monsters[(int)MonsterNumber.Value].CaretPositionNotSymbol = this.TextboxMonsterPsychoMsg.SelectionStart + toInsert.Length;
            statsModel.Monsters[(int)MonsterNumber.Value].SetPsychoMsg(new string(newText), textCodeFormat);

            TextboxMonsterPsychoMsg.Text = statsModel.Monsters[(int)MonsterNumber.Value].GetPsychoMsg(textCodeFormat);
        }

        private void SaveMonsterNotes()
        {
            try
            {
                this.monsterNotesTextBox.SaveFile(notes.GetPath() + "main-stats-monsters.rtf");
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Error saving monster notes. Please report this");
            }
        }

        #region Event Handlers

        private void MonsterNumber_ValueChanged(object sender, EventArgs e)
        {
            RefreshMonsterTab();
        }
        private void monsterName_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.MonsterNumber.Value = universal.MonsterNames.GetNumFromIndex(monsterName.SelectedIndex);
        }
        private void monsterName_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0 || e.Index > 255)
                return;

            char[] arr = statsModel.Monsters[universal.MonsterNames.GetNumFromIndex(e.Index)].Name.ToCharArray();
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
                color = BitManager.GetShort(data, i * 2 + 0x01EF40);
                r = (byte)((color % 0x20) * 8);
                g = (byte)(((color >> 5) % 0x20) * 8);
                b = (byte)(((color >> 10) % 0x20) * 8);
                palette[i] = Color.FromArgb(r, g, b).ToArgb();
            }

            // set the pixels
            int[] temp = menuTextPreview.GetPreview(menuCharacters, palette, arr, true);
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
        private void TextboxMonsterName_TextChanged(object sender, EventArgs e)
        {
            if (universal.MonsterNames.GetNameByNum(statsModel.Monsters[(int)MonsterNumber.Value].MonsterNum).CompareTo(this.TextboxMonsterName.Text) != 0)
            {
                statsModel.Monsters[(int)MonsterNumber.Value].Name = this.TextboxMonsterName.Text;

                universal.MonsterNames.SwapName(statsModel.Monsters[(int)MonsterNumber.Value].MonsterNum, statsModel.Monsters[(int)MonsterNumber.Value].Name);
                universal.MonsterNames.SortAlpha();

                this.monsterName.Items.Clear();
                this.monsterName.Items.AddRange(universal.MonsterNames.GetNames());
                this.monsterName.SelectedIndex = universal.MonsterNames.GetIndexFromNum(statsModel.Monsters[(int)MonsterNumber.Value].MonsterNum);
            }
        }
        private void TextboxMonsterName_Leave(object sender, EventArgs e)
        {
            InitializeMonsterStrings();
            monsterName.SelectedIndex = universal.MonsterNames.GetIndexFromNum(statsModel.Monsters[(int)MonsterNumber.Value].MonsterNum);
            formationName1.SelectedIndex = universal.MonsterNames.GetIndexFromNum(statsModel.Formations[(int)formationNum.Value].FormationMonster[0]);
            formationName2.SelectedIndex = universal.MonsterNames.GetIndexFromNum(statsModel.Formations[(int)formationNum.Value].FormationMonster[1]);
            formationName3.SelectedIndex = universal.MonsterNames.GetIndexFromNum(statsModel.Formations[(int)formationNum.Value].FormationMonster[2]);
            formationName4.SelectedIndex = universal.MonsterNames.GetIndexFromNum(statsModel.Formations[(int)formationNum.Value].FormationMonster[3]);
            formationName5.SelectedIndex = universal.MonsterNames.GetIndexFromNum(statsModel.Formations[(int)formationNum.Value].FormationMonster[4]);
            formationName6.SelectedIndex = universal.MonsterNames.GetIndexFromNum(statsModel.Formations[(int)formationNum.Value].FormationMonster[5]);
            formationName7.SelectedIndex = universal.MonsterNames.GetIndexFromNum(statsModel.Formations[(int)formationNum.Value].FormationMonster[6]);
            formationName8.SelectedIndex = universal.MonsterNames.GetIndexFromNum(statsModel.Formations[(int)formationNum.Value].FormationMonster[7]);

            InitializeFormationStrings();
            RefreshFormationPacks();
        }
        private void MonsterValHP_ValueChanged(object sender, EventArgs e)
        {
            statsModel.Monsters[(int)MonsterNumber.Value].HP = (ushort)MonsterValHP.Value;
        }
        private void MonsterValFP_ValueChanged(object sender, EventArgs e)
        {
            statsModel.Monsters[(int)MonsterNumber.Value].FP = (byte)MonsterValFP.Value;
        }
        private void MonsterValAtk_ValueChanged(object sender, EventArgs e)
        {
            statsModel.Monsters[(int)MonsterNumber.Value].Attack = (byte)MonsterValAtk.Value;
        }
        private void MonsterValDef_ValueChanged(object sender, EventArgs e)
        {
            statsModel.Monsters[(int)MonsterNumber.Value].Defense = (byte)MonsterValDef.Value;
        }
        private void MonsterValMgAtk_ValueChanged(object sender, EventArgs e)
        {
            statsModel.Monsters[(int)MonsterNumber.Value].MagicAttack = (byte)MonsterValMgAtk.Value;
        }
        private void MonsterValMgDef_ValueChanged(object sender, EventArgs e)
        {
            statsModel.Monsters[(int)MonsterNumber.Value].MagicDefense = (byte)MonsterValMgDef.Value;
        }
        private void MonsterValSpeed_ValueChanged(object sender, EventArgs e)
        {
            statsModel.Monsters[(int)MonsterNumber.Value].Speed = (byte)MonsterValSpeed.Value;
        }
        private void MonsterValEvd_ValueChanged(object sender, EventArgs e)
        {
            statsModel.Monsters[(int)MonsterNumber.Value].EvadePercent = (byte)MonsterValEvd.Value;
        }
        private void MonsterValMgEvd_ValueChanged(object sender, EventArgs e)
        {
            statsModel.Monsters[(int)MonsterNumber.Value].MagicEvadePercent = (byte)MonsterValMgEvd.Value;
        }
        private void MonsterValExp_ValueChanged(object sender, EventArgs e)
        {
            statsModel.Monsters[(int)MonsterNumber.Value].Experience = (ushort)MonsterValExp.Value;
        }
        private void MonsterValCoins_ValueChanged(object sender, EventArgs e)
        {
            statsModel.Monsters[(int)MonsterNumber.Value].Coins = (byte)MonsterValCoins.Value;
        }
        private void ItemWinA_SelectedIndexChanged(object sender, EventArgs e)
        {
            statsModel.Monsters[(int)MonsterNumber.Value].ItemWinA = (byte)universal.ItemNames.GetNumFromIndex(ItemWinA.SelectedIndex);
        }
        private void ItemWinB_SelectedIndexChanged(object sender, EventArgs e)
        {
            statsModel.Monsters[(int)MonsterNumber.Value].ItemWinB = (byte)universal.ItemNames.GetNumFromIndex(ItemWinB.SelectedIndex);
        }
        private void MonsterYoshiCookie_SelectedIndexChanged(object sender, EventArgs e)
        {
            statsModel.Monsters[(int)MonsterNumber.Value].YoshiCookie = (byte)universal.ItemNames.GetNumFromIndex(MonsterYoshiCookie.SelectedIndex);
        }
        private void MonsterMorphSuccess_SelectedIndexChanged(object sender, EventArgs e)
        {
            statsModel.Monsters[(int)MonsterNumber.Value].MorphSuccessRate = (byte)MonsterMorphSuccess.SelectedIndex;
        }
        private void MonsterCoinSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            statsModel.Monsters[(int)MonsterNumber.Value].CoinSize = (byte)MonsterCoinSize.SelectedIndex;
        }
        private void MonsterEntranceStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            statsModel.Monsters[(int)MonsterNumber.Value].EntranceStyle = (byte)MonsterEntranceStyle.SelectedIndex;
        }
        private void MonsterBehavior_SelectedIndexChanged(object sender, EventArgs e)
        {
            statsModel.Monsters[(int)MonsterNumber.Value].DeathAnimation = (byte)MonsterBehavior.SelectedIndex;
        }
        private void MonsterSoundStrike_SelectedIndexChanged(object sender, EventArgs e)
        {
            statsModel.Monsters[(int)MonsterNumber.Value].StrikeSound = (byte)MonsterSoundStrike.SelectedIndex;
        }
        private void MonsterSoundOther_SelectedIndexChanged(object sender, EventArgs e)
        {
            statsModel.Monsters[(int)MonsterNumber.Value].OtherSound = (byte)MonsterSoundOther.SelectedIndex;
        }
        private void MonsterValElevation_ValueChanged(object sender, EventArgs e)
        {
            statsModel.Monsters[(int)MonsterNumber.Value].Elevation = (byte)MonsterValElevation.Value;
        }
        private void CheckboxMonsterEfecNull_SelectedIndexChanged(object sender, EventArgs e)
        {
            statsModel.Monsters[(int)MonsterNumber.Value].EffectMuteNull = CheckboxMonsterEfecNull.GetItemChecked(0);
            statsModel.Monsters[(int)MonsterNumber.Value].EffectSleepNull = CheckboxMonsterEfecNull.GetItemChecked(1);
            statsModel.Monsters[(int)MonsterNumber.Value].EffectPoisonNull = CheckboxMonsterEfecNull.GetItemChecked(2);
            statsModel.Monsters[(int)MonsterNumber.Value].EffectFearNull = CheckboxMonsterEfecNull.GetItemChecked(3);
            statsModel.Monsters[(int)MonsterNumber.Value].EffectMushroomNull = CheckboxMonsterEfecNull.GetItemChecked(4);
            statsModel.Monsters[(int)MonsterNumber.Value].EffectScarecrowNull = CheckboxMonsterEfecNull.GetItemChecked(5);
            statsModel.Monsters[(int)MonsterNumber.Value].EffectInvincibleNull = CheckboxMonsterEfecNull.GetItemChecked(6);
        }
        private void CheckboxMonsterElemWeak_SelectedIndexChanged(object sender, EventArgs e)
        {
            statsModel.Monsters[(int)MonsterNumber.Value].ElemIceWeak = CheckboxMonsterElemWeak.GetItemChecked(0);
            statsModel.Monsters[(int)MonsterNumber.Value].ElemFireWeak = CheckboxMonsterElemWeak.GetItemChecked(1);
            statsModel.Monsters[(int)MonsterNumber.Value].ElemThunderWeak = CheckboxMonsterElemWeak.GetItemChecked(2);
            statsModel.Monsters[(int)MonsterNumber.Value].ElemJumpWeak = CheckboxMonsterElemWeak.GetItemChecked(3);
        }
        private void CheckboxMonsterElemNull_SelectedIndexChanged(object sender, EventArgs e)
        {
            statsModel.Monsters[(int)MonsterNumber.Value].ElemIceNull = CheckboxMonsterElemNull.GetItemChecked(0);
            statsModel.Monsters[(int)MonsterNumber.Value].ElemFireNull = CheckboxMonsterElemNull.GetItemChecked(1);
            statsModel.Monsters[(int)MonsterNumber.Value].ElemThunderNull = CheckboxMonsterElemNull.GetItemChecked(2);
            statsModel.Monsters[(int)MonsterNumber.Value].ElemJumpNull = CheckboxMonsterElemNull.GetItemChecked(3);
        }
        private void CheckboxMonsterProp_SelectedIndexChanged(object sender, EventArgs e)
        {
            statsModel.Monsters[(int)MonsterNumber.Value].Invincible = CheckboxMonsterProp.GetItemChecked(0);
            statsModel.Monsters[(int)MonsterNumber.Value].ProtectAgainstInstantDeath = CheckboxMonsterProp.GetItemChecked(1);
            statsModel.Monsters[(int)MonsterNumber.Value].LetBattleScriptRemove = CheckboxMonsterProp.GetItemChecked(2);
            statsModel.Monsters[(int)MonsterNumber.Value].UsedByCrystals = CheckboxMonsterProp.GetItemChecked(3);
        }
        private void MonsterFlowerBonus_SelectedIndexChanged(object sender, EventArgs e)
        {
            statsModel.Monsters[(int)MonsterNumber.Value].FlowerBonus = (byte)MonsterFlowerBonus.SelectedIndex;
        }
        private void MonsterValFlowerOdds_ValueChanged(object sender, EventArgs e)
        {
            statsModel.Monsters[(int)MonsterNumber.Value].FlowerOdds = (byte)MonsterValFlowerOdds.Value;
        }

        private void monsterTargetArrowX_ValueChanged(object sender, EventArgs e)
        {
            statsModel.Monsters[(int)MonsterNumber.Value].CursorX = (byte)monsterTargetArrowX.Value;

            if (waitBothCoords) return;
            monsterImage = new Bitmap(statsModel.Monsters[(int)MonsterNumber.Value].Image);
            pictureBoxMonster.Invalidate();
        }
        private void monsterTargetArrowY_ValueChanged(object sender, EventArgs e)
        {
            statsModel.Monsters[(int)MonsterNumber.Value].CursorY = (byte)monsterTargetArrowY.Value;

            if (waitBothCoords) return;
            monsterImage = new Bitmap(statsModel.Monsters[(int)MonsterNumber.Value].Image);
            pictureBoxMonster.Invalidate();
        }

        private void pictureBoxMonster_MouseDown(object sender, MouseEventArgs e)
        {
        }
        private void pictureBoxMonster_MouseMove(object sender, MouseEventArgs e)
        {
            int x = 15 - (e.X / 8); int y = 15 - (e.Y / 8);
            if (x > 15) x = 15; if (x < 0) x = 0;
            if (y > 15) y = 15; if (y < 0) y = 0;
            if (e.Button == MouseButtons.Left)
            {
                if (overTarget)
                {
                    if (monsterTargetArrowX.Value != x && monsterTargetArrowY.Value != y)
                        waitBothCoords = true;
                    monsterTargetArrowX.Value = x;
                    waitBothCoords = false;
                    monsterTargetArrowY.Value = y;
                }
            }
            else
            {
                if ((128 - (monsterTargetArrowX.Value * 8) > e.X && 128 - (monsterTargetArrowX.Value * 8) < e.X + 16) &&
                    (128 - (monsterTargetArrowY.Value * 8) > e.Y && 128 - (monsterTargetArrowY.Value * 8) < e.Y + 16))
                {
                    pictureBoxMonster.Cursor = Cursors.Hand;
                    overTarget = true;
                }
                else
                {
                    pictureBoxMonster.Cursor = Cursors.Arrow;
                    overTarget = false;
                }
            }
        }
        private void pictureBoxMonster_MouseUp(object sender, MouseEventArgs e)
        {
            monsterImage = new Bitmap(statsModel.Monsters[(int)MonsterNumber.Value].Image);
            pictureBoxMonster.Invalidate();
        }
        private void pictureBoxMonster_Paint(object sender, PaintEventArgs e)
        {
            if (monsterImage != null)
                e.Graphics.DrawImage(monsterImage, 0, 0);
        }
        private void pictureBoxPsychopath_Paint(object sender, PaintEventArgs e)
        {
            if (psychopathBGImage != null)
                e.Graphics.DrawImage(psychopathBGImage, 0, 0);
            if (psychopathTextImage != null)
                e.Graphics.DrawImage(psychopathTextImage, 0, 0);
        }

        private void TextboxMonsterPsychoMsg_TextChanged(object sender, EventArgs e)
        {
            char[] text = TextboxMonsterPsychoMsg.Text.ToCharArray();
            char[] swap;
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == '\n')
                {
                    int tempSel = TextboxMonsterPsychoMsg.SelectionStart;
                    swap = new char[text.Length + 2];
                    for (int x = 0; x < i; x++)
                        swap[x] = text[x];
                    swap[i] = '[';
                    swap[i + 1] = '1';
                    swap[i + 2] = ']';
                    for (int x = i + 3; x < swap.Length; x++)
                        swap[x] = text[x - 2];
                    TextboxMonsterPsychoMsg.Text = new string(swap);
                    text = TextboxMonsterPsychoMsg.Text.ToCharArray();
                    i += 2;
                    TextboxMonsterPsychoMsg.SelectionStart = tempSel + 2;
                }
            }

            bool flag = textHelper.VerifyCorrectSymbols(this.TextboxMonsterPsychoMsg.Text.ToCharArray(), textCodeFormat);
            if (flag)
            {
                this.TextboxMonsterPsychoMsg.BackColor = System.Drawing.Color.FromArgb(255, 255, 255, 255);
                statsModel.Monsters[(int)MonsterNumber.Value].SetPsychoMsg(this.TextboxMonsterPsychoMsg.Text, textCodeFormat);

                if (!statsModel.Monsters[(int)MonsterNumber.Value].PsychoMsgError)
                {
                    statsModel.Monsters[(int)MonsterNumber.Value].SetPsychoMsg(TextboxMonsterPsychoMsg.Text, textCodeFormat);
                    int[] pixels = battleDialoguePreview.GetPreview(fontCharacters, GetFontPalette(), statsModel.Monsters[(int)MonsterNumber.Value].RawPsychoMsg, false);

                    psychopathTextImage = new Bitmap(DrawImageFromIntArr(pixels, 256, 32));
                    pictureBoxPsychopath.Invalidate();
                }
            }
            if (!flag || statsModel.Monsters[(int)MonsterNumber.Value].PsychoMsgError)
                this.TextboxMonsterPsychoMsg.BackColor = System.Drawing.Color.Red;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            // up
            battleDialoguePreview.PageUp();
            TextboxMonsterPsychoMsg_TextChanged(null, null);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            // down
            battleDialoguePreview.PageDown(statsModel.Monsters[(int)MonsterNumber.Value].RawPsychoMsg.Length);
            TextboxMonsterPsychoMsg_TextChanged(null, null);
        }
        private void buttonPreviousFrame_Click(object sender, EventArgs e)
        {
            statsModel.Monsters[(int)MonsterNumber.Value].previousFrame();

            monsterImage = new Bitmap(statsModel.Monsters[(int)MonsterNumber.Value].Image);
            pictureBoxMonster.Invalidate();
        }
        private void buttonNextFrame_Click(object sender, EventArgs e)
        {
            statsModel.Monsters[(int)MonsterNumber.Value].nextFrame();

            monsterImage = new Bitmap(statsModel.Monsters[(int)MonsterNumber.Value].Image);
            pictureBoxMonster.Invalidate();
        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (listBox3.SelectedIndex)
            {
                case 0:
                    // end
                    if (textCodeFormat)
                        InsertIntoMonsterPsychoMsgText("[0]");
                    else
                        InsertIntoMonsterPsychoMsgText("[endInput]");
                    break;
                case 1:
                    // end
                    if (textCodeFormat)
                        InsertIntoMonsterPsychoMsgText("[1]");
                    else
                        InsertIntoMonsterPsychoMsgText("[newLine]");
                    break;
                case 2:
                    // pause (A)
                    if (textCodeFormat)
                        InsertIntoMonsterPsychoMsgText("[2]");
                    else
                        InsertIntoMonsterPsychoMsgText("[pauseInput]");
                    break;
                case 3:
                    // delay (A)
                    if (textCodeFormat)
                        InsertIntoMonsterPsychoMsgText("[3]");
                    else
                        InsertIntoMonsterPsychoMsgText("[delayInput]");
                    break;
                case 4:
                    // delay
                    if (textCodeFormat)
                        InsertIntoMonsterPsychoMsgText("[12]");
                    else
                        InsertIntoMonsterPsychoMsgText("[delay]");
                    break;
                default:
                    break;

            }

        }
        private void listBox3_Click(object sender, EventArgs e)
        {
            /*
            switch (listBox3.SelectedIndex)
            {
                case 0:
                    // end
                    if (textCodeFormat)
                        InsertIntoMonsterPsychoMsgText("[0]");
                    else
                        InsertIntoMonsterPsychoMsgText("[endInput]");
                    break;
                case 1:
                    // end
                    if (textCodeFormat)
                        InsertIntoMonsterPsychoMsgText("[1]");
                    else
                        InsertIntoMonsterPsychoMsgText("[newLine]");
                    break;
                case 2:
                    // pause (A)
                    if (textCodeFormat)
                        InsertIntoMonsterPsychoMsgText("[5]");
                    else
                        InsertIntoMonsterPsychoMsgText("[pauseInput]");
                    break;
                case 3:
                    // delay (A)
                    break;
                case 4:
                    // delay
                    if (textCodeFormat)
                        InsertIntoMonsterPsychoMsgText("[12]");
                    else
                        InsertIntoMonsterPsychoMsgText("[delay]"); 
                    break;
                default:
                    break;

            }
             * */
        }

        #endregion
    }
}
