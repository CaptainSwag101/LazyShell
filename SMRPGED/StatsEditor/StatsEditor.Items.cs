using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SMRPGED.StatsEditor
{
    public partial class StatsEditor
    {
        private bool updatingItems = false;

        private void InitializeItems()
        {
            this.itemName.SelectedIndex = universal.ItemNames.GetIndexFromNum(0);

            RefreshItemTab();
        }
        private void InitializeItemStrings()
        {
            universal.ItemNames = new DDlistName(statsModel.Items);
            universal.ItemNames.SortAlpha();

            this.itemName.Items.Clear();
            this.itemName.Items.AddRange(this.universal.ItemNames.Names);

            string[] temp = new string[96];
            for (int i = 0; i < 96; i++)
                temp[i] = i.ToString();
            this.itemNameIcon.Items.Clear();
            this.itemNameIcon.Items.AddRange(temp);
            this.itemNameIcon.BackColor = System.Drawing.SystemColors.ControlDark;

            this.MonsterYoshiCookie.Items.Clear();
            this.MonsterYoshiCookie.Items.AddRange(this.universal.ItemNames.Names);

            this.ItemWinA.Items.Clear();
            this.ItemWinA.Items.AddRange(this.universal.ItemNames.Names);

            this.ItemWinB.Items.Clear();
            this.ItemWinB.Items.AddRange(this.universal.ItemNames.Names);

            this.shopItem1.Items.Clear();
            this.shopItem2.Items.Clear();
            this.shopItem3.Items.Clear();
            this.shopItem4.Items.Clear();
            this.shopItem5.Items.Clear();
            this.shopItem6.Items.Clear();
            this.shopItem7.Items.Clear();
            this.shopItem8.Items.Clear();
            this.shopItem9.Items.Clear();
            this.shopItem10.Items.Clear();
            this.shopItem11.Items.Clear();
            this.shopItem12.Items.Clear();
            this.shopItem13.Items.Clear();
            this.shopItem14.Items.Clear();
            this.shopItem15.Items.Clear();
            this.shopItem1.Items.AddRange(this.universal.ItemNames.Names);
            this.shopItem2.Items.AddRange(this.universal.ItemNames.Names);
            this.shopItem3.Items.AddRange(this.universal.ItemNames.Names);
            this.shopItem4.Items.AddRange(this.universal.ItemNames.Names);
            this.shopItem5.Items.AddRange(this.universal.ItemNames.Names);
            this.shopItem6.Items.AddRange(this.universal.ItemNames.Names);
            this.shopItem7.Items.AddRange(this.universal.ItemNames.Names);
            this.shopItem8.Items.AddRange(this.universal.ItemNames.Names);
            this.shopItem9.Items.AddRange(this.universal.ItemNames.Names);
            this.shopItem10.Items.AddRange(this.universal.ItemNames.Names);
            this.shopItem11.Items.AddRange(this.universal.ItemNames.Names);
            this.shopItem12.Items.AddRange(this.universal.ItemNames.Names);
            this.shopItem13.Items.AddRange(this.universal.ItemNames.Names);
            this.shopItem14.Items.AddRange(this.universal.ItemNames.Names);
            this.shopItem15.Items.AddRange(this.universal.ItemNames.Names);

            this.startingWeapon.Items.Clear();
            this.startingWeapon.Items.AddRange(this.universal.ItemNames.GetNames());
            this.startingAccessory.Items.Clear();
            this.startingAccessory.Items.AddRange(this.universal.ItemNames.GetNames());
            this.startingArmor.Items.Clear();
            this.startingArmor.Items.AddRange(this.universal.ItemNames.GetNames());
            this.startingItem.Items.Clear();
            this.startingItem.Items.AddRange(this.universal.ItemNames.GetNames());
            this.startingSpecialItem.Items.Clear();
            this.startingSpecialItem.Items.AddRange(this.universal.ItemNames.GetNames());
            this.startingEquipment.Items.Clear();
            this.startingEquipment.Items.AddRange(this.universal.ItemNames.GetNames());

        }
        private void RefreshItemTab()
        {
            if (!updatingItems)
            {
                updatingItems = true;

                this.itemName.SelectedIndex = universal.ItemNames.GetIndexFromNum((int)itemNum.Value);
                this.itemName.Invalidate();

                this.itemCoinValue.Value = statsModel.Items[(int)itemNum.Value].CoinValue;
                this.itemSpeed.Value = statsModel.Items[(int)itemNum.Value].Speed;
                this.itemAttack.Value = statsModel.Items[(int)itemNum.Value].Attack;
                this.itemDefense.Value = statsModel.Items[(int)itemNum.Value].Defense;
                this.itemMagicAttack.Value = statsModel.Items[(int)itemNum.Value].MagicAttack;
                this.itemMagicDefense.Value = statsModel.Items[(int)itemNum.Value].MagicDefense;
                this.itemAttackRange.Value = statsModel.Items[(int)itemNum.Value].AttackRange;
                this.itemPower.Value = statsModel.Items[(int)itemNum.Value].InflictionAmount;

                this.textBoxItemName.Text = statsModel.Items[(int)itemNum.Value].Name;

                if (this.itemNum.Value > 0xB0)
                {
                    this.textBoxItemDescription.Text = "This item cannot have a description";
                    this.textBoxItemDescription.Enabled = false;
                    this.buttonItemDescriptionBreak.Enabled = false;
                    this.buttonItemDescriptionEnd.Enabled = false;
                }
                else
                {
                    if (textBoxItemDescription.Enabled == false)
                    {
                        this.textBoxItemDescription.Enabled = true;
                        this.buttonItemDescriptionBreak.Enabled = true;
                        this.buttonItemDescriptionEnd.Enabled = true;
                    }

                    this.textBoxItemDescription.Text = statsModel.Items[(int)itemNum.Value].GetDescription(textCodeFormat);
                }

                this.itemStatusEffect.SetItemChecked(0, statsModel.Items[(int)itemNum.Value].EffectMute);
                this.itemStatusEffect.SetItemChecked(1, statsModel.Items[(int)itemNum.Value].EffectSleep);
                this.itemStatusEffect.SetItemChecked(2, statsModel.Items[(int)itemNum.Value].EffectPoison);
                this.itemStatusEffect.SetItemChecked(3, statsModel.Items[(int)itemNum.Value].EffectFear);
                this.itemStatusEffect.SetItemChecked(4, statsModel.Items[(int)itemNum.Value].EffectMushroom);
                this.itemStatusEffect.SetItemChecked(5, statsModel.Items[(int)itemNum.Value].EffectScarecrow);
                this.itemStatusEffect.SetItemChecked(6, statsModel.Items[(int)itemNum.Value].EffectInvincible);
                this.itemStatusChange.SetItemChecked(0, statsModel.Items[(int)itemNum.Value].ChangeAttack);
                this.itemStatusChange.SetItemChecked(1, statsModel.Items[(int)itemNum.Value].ChangeDefense);
                this.itemStatusChange.SetItemChecked(2, statsModel.Items[(int)itemNum.Value].ChangeMagicAttack);
                this.itemStatusChange.SetItemChecked(3, statsModel.Items[(int)itemNum.Value].ChangeMagicDefense);
                this.itemElemNull.SetItemChecked(0, statsModel.Items[(int)itemNum.Value].ElemIceNull);
                this.itemElemNull.SetItemChecked(1, statsModel.Items[(int)itemNum.Value].ElemFireNull);
                this.itemElemNull.SetItemChecked(2, statsModel.Items[(int)itemNum.Value].ElemThunderNull);
                this.itemElemNull.SetItemChecked(3, statsModel.Items[(int)itemNum.Value].ElemJumpNull);
                this.itemElemWeak.SetItemChecked(0, statsModel.Items[(int)itemNum.Value].ElemIceWeak);
                this.itemElemWeak.SetItemChecked(1, statsModel.Items[(int)itemNum.Value].ElemFireWeak);
                this.itemElemWeak.SetItemChecked(2, statsModel.Items[(int)itemNum.Value].ElemThunderWeak);
                this.itemElemWeak.SetItemChecked(3, statsModel.Items[(int)itemNum.Value].ElemJumpWeak);
                this.itemWhoEquip.SetItemChecked(0, statsModel.Items[(int)itemNum.Value].EquipMario);
                this.itemWhoEquip.SetItemChecked(1, statsModel.Items[(int)itemNum.Value].EquipToadstool);
                this.itemWhoEquip.SetItemChecked(2, statsModel.Items[(int)itemNum.Value].EquipBowser);
                this.itemWhoEquip.SetItemChecked(3, statsModel.Items[(int)itemNum.Value].EquipGeno);
                this.itemWhoEquip.SetItemChecked(4, statsModel.Items[(int)itemNum.Value].EquipMallow);
                this.itemUsage.SetItemChecked(0, statsModel.Items[(int)itemNum.Value].UsageInstantDeath);
                this.itemUsage.SetItemChecked(1, statsModel.Items[(int)itemNum.Value].HideDigits);
                this.itemUsage.SetItemChecked(2, statsModel.Items[(int)itemNum.Value].UsageBattleMenu);
                this.itemUsage.SetItemChecked(3, statsModel.Items[(int)itemNum.Value].UsageOverworldMenu);
                this.itemUsage.SetItemChecked(4, statsModel.Items[(int)itemNum.Value].UsageReusable);
                this.itemCursorRestore.SetItemChecked(0, statsModel.Items[(int)itemNum.Value].RestoreFP);
                this.itemCursorRestore.SetItemChecked(1, statsModel.Items[(int)itemNum.Value].RestoreHP);
                this.itemTargetting.SetItemChecked(0, statsModel.Items[(int)itemNum.Value].TargetLiveAlly);
                this.itemTargetting.SetItemChecked(1, statsModel.Items[(int)itemNum.Value].TargetEnemy);
                this.itemTargetting.SetItemChecked(2, statsModel.Items[(int)itemNum.Value].TargetAll);
                this.itemTargetting.SetItemChecked(3, statsModel.Items[(int)itemNum.Value].TargetWoundedOnly);
                this.itemTargetting.SetItemChecked(4, statsModel.Items[(int)itemNum.Value].TargetOnePartyOnly);
                this.itemTargetting.SetItemChecked(5, statsModel.Items[(int)itemNum.Value].TargetNotSelf);

                this.itemAttackType.SelectedIndex = statsModel.Items[(int)itemNum.Value].AttackType;
                this.itemType.SelectedIndex = statsModel.Items[(int)itemNum.Value].ItemType;
                this.itemFunction.SelectedIndex = statsModel.Items[(int)itemNum.Value].InflictFunction;
                this.itemElemAttack.SelectedIndex = statsModel.Items[(int)itemNum.Value].ElemAttack;
                this.itemCursor.SelectedIndex = statsModel.Items[(int)itemNum.Value].CursorBehavior;
                this.itemNameIcon.SelectedIndex = (int)(statsModel.Items[(int)itemNum.Value].Icon - 0x20);
                this.itemNameIcon.Invalidate();

                UpdateAttackType();
                updatingItems = false;
            }
        }
        private void UpdateAttackType()
        {
            if (statsModel.Items[(int)itemNum.Value].AttackType == 0)
            {
                this.label101.Text = "EFFECT <INFLICT>";
                this.label99.Text = "STATUS <UP>";
            }
            else if (statsModel.Items[(int)itemNum.Value].AttackType == 1)
            {
                this.label101.Text = "EFFECT <PROTECT>";
                this.label99.Text = "STATUS <. . . .>";
            }
            else if (statsModel.Items[(int)itemNum.Value].AttackType == 2)
            {
                this.label101.Text = "EFFECT <NULLIFY>";
                this.label99.Text = "STATUS <DOWN>";
            }
            else if (statsModel.Items[(int)itemNum.Value].AttackType == 3)
            {
                this.label101.Text = "EFFECT <. . . .>";
                this.label99.Text = "STATUS <. . . .>";
            }
        }

        #region Event Handlers
        private void itemNum_ValueChanged(object sender, EventArgs e)
        {
            RefreshItemTab();
        }
        private void itemName_SelectedIndexChanged(object sender, EventArgs e)
        {
            itemNum.Value = universal.ItemNames.GetNumFromIndex(itemName.SelectedIndex);
        }
        private void itemName_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0 || e.Index > 255)
                return;

            if (universal.ItemNames.GetNumFromIndex(e.Index) == 255)
            {
                e.DrawBackground();
                e.Graphics.DrawString("{NOTHING}", e.Font, new SolidBrush(levelUpSpellLearned.ForeColor), e.Bounds);
                e.DrawFocusRectangle();
                return;
            }

            char[] arr = new char[statsModel.Items[universal.ItemNames.GetNumFromIndex(e.Index)].Name.Length + 1];
            arr[0] = (char)statsModel.Items[universal.ItemNames.GetNumFromIndex(e.Index)].Icon;
            for (int i = 1; i < arr.Length; i++)
            {
                arr[i] = (char)statsModel.Items[universal.ItemNames.GetNumFromIndex(e.Index)].Name[i - 1];
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
            int[] pixels = new int[256 * 16];

            for (int y = 2, c = 0; y < 16; y++, c++)
            {
                for (int x = 2, a = 0; x < 256; x++, a++)
                    pixels[y * 256 + x] = temp[c * 256 + a];
            }

            Bitmap icon = new Bitmap(DrawImageFromIntArr(pixels, 256, 16));

            e.DrawBackground();
            e.Graphics.DrawImage(icon, new Point(e.Bounds.X, e.Bounds.Y));
            e.DrawFocusRectangle();
        }

        private void textBoxItemDescription_TextChanged(object sender, EventArgs e)
        {
            char[] text = textBoxItemDescription.Text.ToCharArray();
            char[] swap;
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == '\n')
                {
                    int tempSel = textBoxItemDescription.SelectionStart;
                    swap = new char[text.Length + 2];
                    for (int x = 0; x < i; x++)
                        swap[x] = text[x];
                    swap[i] = '[';
                    swap[i + 1] = '1';
                    swap[i + 2] = ']';
                    for (int x = i + 3; x < swap.Length; x++)
                        swap[x] = text[x - 2];
                    textBoxItemDescription.Text = new string(swap);
                    text = textBoxItemDescription.Text.ToCharArray();
                    i += 2;
                    textBoxItemDescription.SelectionStart = tempSel + 2;
                }
            }

            bool flag = textHelper.VerifyCorrectSymbols(this.textBoxItemDescription.Text.ToCharArray(), textCodeFormat);
            if (flag)
            {
                this.textBoxItemDescription.BackColor = System.Drawing.Color.FromArgb(255, 255, 255, 255);
                statsModel.Items[(int)itemNum.Value].SetDescription(this.textBoxItemDescription.Text, textCodeFormat);
            }
            if (!flag || statsModel.Items[(int)itemNum.Value].DescriptionError)
                this.textBoxItemDescription.BackColor = System.Drawing.Color.Red;

            SetItemDescImage();
        }
        private void buttonItemDescriptionBreak_Click(object sender, EventArgs e)
        {
            // newline
            if (textCodeFormat)
                InsertIntoItemDescriptionText("[1]");
            else
                InsertIntoItemDescriptionText("[newLine]");
        }
        private void buttonItemDescriptionEnd_Click(object sender, EventArgs e)
        {
            // end
            if (textCodeFormat)
                InsertIntoItemDescriptionText("[0]");
            else
                InsertIntoItemDescriptionText("[endInput]");
        }
        private void buttonPreviewItemDesc_Click(object sender, EventArgs e)
        {
            panelItemDesc.Visible = !panelItemDesc.Visible;
        }

        private void textBoxItemName_TextChanged(object sender, EventArgs e)
        {
            if (universal.ItemNames.GetNameByNum(statsModel.Items[(int)itemNum.Value].ItemNum).CompareTo(this.textBoxItemName.Text) != 0)
            {
                statsModel.Items[(int)itemNum.Value].Name = this.textBoxItemName.Text;

                universal.ItemNames.SwapName(statsModel.Items[(int)itemNum.Value].ItemNum, statsModel.Items[(int)itemNum.Value].Name);
                universal.ItemNames.SortAlpha();

                this.itemName.Items.Clear();
                this.itemName.Items.AddRange(universal.ItemNames.GetNames());
                this.itemName.SelectedIndex = universal.ItemNames.GetIndexFromNum(statsModel.Items[(int)itemNum.Value].ItemNum);
            }
        }
        private void textBoxItemName_Leave(object sender, EventArgs e)
        {
            this.MonsterYoshiCookie.Items.Clear();
            this.MonsterYoshiCookie.Items.AddRange(this.universal.ItemNames.GetNames());
            this.ItemWinA.Items.Clear();
            this.ItemWinA.Items.AddRange(this.universal.ItemNames.Names);
            this.ItemWinB.Items.Clear();
            this.ItemWinB.Items.AddRange(this.universal.ItemNames.Names);
            this.shopItem1.Items.Clear();
            this.shopItem2.Items.Clear();
            this.shopItem3.Items.Clear();
            this.shopItem4.Items.Clear();
            this.shopItem5.Items.Clear();
            this.shopItem6.Items.Clear();
            this.shopItem7.Items.Clear();
            this.shopItem8.Items.Clear();
            this.shopItem9.Items.Clear();
            this.shopItem10.Items.Clear();
            this.shopItem11.Items.Clear();
            this.shopItem12.Items.Clear();
            this.shopItem13.Items.Clear();
            this.shopItem14.Items.Clear();
            this.shopItem15.Items.Clear();
            this.shopItem1.Items.AddRange(this.universal.ItemNames.Names);
            this.shopItem2.Items.AddRange(this.universal.ItemNames.Names);
            this.shopItem3.Items.AddRange(this.universal.ItemNames.Names);
            this.shopItem4.Items.AddRange(this.universal.ItemNames.Names);
            this.shopItem5.Items.AddRange(this.universal.ItemNames.Names);
            this.shopItem6.Items.AddRange(this.universal.ItemNames.Names);
            this.shopItem7.Items.AddRange(this.universal.ItemNames.Names);
            this.shopItem8.Items.AddRange(this.universal.ItemNames.Names);
            this.shopItem9.Items.AddRange(this.universal.ItemNames.Names);
            this.shopItem10.Items.AddRange(this.universal.ItemNames.Names);
            this.shopItem11.Items.AddRange(this.universal.ItemNames.Names);
            this.shopItem12.Items.AddRange(this.universal.ItemNames.Names);
            this.shopItem13.Items.AddRange(this.universal.ItemNames.Names);
            this.shopItem14.Items.AddRange(this.universal.ItemNames.Names);
            this.shopItem15.Items.AddRange(this.universal.ItemNames.Names);
            this.startingWeapon.Items.Clear();
            this.startingWeapon.Items.AddRange(this.universal.ItemNames.GetNames());
            this.startingAccessory.Items.Clear();
            this.startingAccessory.Items.AddRange(this.universal.ItemNames.GetNames());
            this.startingArmor.Items.Clear();
            this.startingArmor.Items.AddRange(this.universal.ItemNames.GetNames());
            this.startingItem.Items.Clear();
            this.startingItem.Items.AddRange(this.universal.ItemNames.GetNames());
            this.startingSpecialItem.Items.Clear();
            this.startingSpecialItem.Items.AddRange(this.universal.ItemNames.GetNames());
            this.startingEquipment.Items.Clear();
            this.startingEquipment.Items.AddRange(this.universal.ItemNames.GetNames());

            this.MonsterYoshiCookie.SelectedIndex = universal.ItemNames.GetIndexFromNum(statsModel.Monsters[(int)MonsterNumber.Value].YoshiCookie);
            this.ItemWinA.SelectedIndex = universal.ItemNames.GetIndexFromNum(statsModel.Monsters[(int)MonsterNumber.Value].ItemWinA);
            this.ItemWinB.SelectedIndex = universal.ItemNames.GetIndexFromNum(statsModel.Monsters[(int)MonsterNumber.Value].ItemWinB);
            this.shopItem1.SelectedIndex = universal.ItemNames.GetIndexFromNum(statsModel.Shops[(int)shopNum.Value].Items[0]);
            this.shopItem2.SelectedIndex = universal.ItemNames.GetIndexFromNum(statsModel.Shops[(int)shopNum.Value].Items[1]);
            this.shopItem3.SelectedIndex = universal.ItemNames.GetIndexFromNum(statsModel.Shops[(int)shopNum.Value].Items[2]);
            this.shopItem4.SelectedIndex = universal.ItemNames.GetIndexFromNum(statsModel.Shops[(int)shopNum.Value].Items[3]);
            this.shopItem5.SelectedIndex = universal.ItemNames.GetIndexFromNum(statsModel.Shops[(int)shopNum.Value].Items[4]);
            this.shopItem6.SelectedIndex = universal.ItemNames.GetIndexFromNum(statsModel.Shops[(int)shopNum.Value].Items[5]);
            this.shopItem7.SelectedIndex = universal.ItemNames.GetIndexFromNum(statsModel.Shops[(int)shopNum.Value].Items[6]);
            this.shopItem8.SelectedIndex = universal.ItemNames.GetIndexFromNum(statsModel.Shops[(int)shopNum.Value].Items[7]);
            this.shopItem9.SelectedIndex = universal.ItemNames.GetIndexFromNum(statsModel.Shops[(int)shopNum.Value].Items[8]);
            this.shopItem10.SelectedIndex = universal.ItemNames.GetIndexFromNum(statsModel.Shops[(int)shopNum.Value].Items[9]);
            this.shopItem11.SelectedIndex = universal.ItemNames.GetIndexFromNum(statsModel.Shops[(int)shopNum.Value].Items[10]);
            this.shopItem12.SelectedIndex = universal.ItemNames.GetIndexFromNum(statsModel.Shops[(int)shopNum.Value].Items[11]);
            this.shopItem13.SelectedIndex = universal.ItemNames.GetIndexFromNum(statsModel.Shops[(int)shopNum.Value].Items[12]);
            this.shopItem14.SelectedIndex = universal.ItemNames.GetIndexFromNum(statsModel.Shops[(int)shopNum.Value].Items[13]);
            this.shopItem15.SelectedIndex = universal.ItemNames.GetIndexFromNum(statsModel.Shops[(int)shopNum.Value].Items[14]);
            this.startingWeapon.SelectedIndex = universal.ItemNames.GetIndexFromNum(statsModel.Characters[(int)characterNum.Value].StartingWeapon);
            this.startingAccessory.SelectedIndex = universal.ItemNames.GetIndexFromNum(statsModel.Characters[(int)characterNum.Value].StartingAccessory);
            this.startingArmor.SelectedIndex = universal.ItemNames.GetIndexFromNum(statsModel.Characters[(int)characterNum.Value].StartingArmor);
            this.startingItem.SelectedIndex = universal.ItemNames.GetIndexFromNum(statsModel.Slots[(int)slotNum.Value].Item);
            this.startingSpecialItem.SelectedIndex = universal.ItemNames.GetIndexFromNum(statsModel.Slots[(int)slotNum.Value].SpecialItem);
            this.startingEquipment.SelectedIndex = universal.ItemNames.GetIndexFromNum(statsModel.Slots[(int)slotNum.Value].Equipment);

            InitializeTimingStrings();
        }

        private void itemNameIcon_SelectedIndexChanged(object sender, EventArgs e)
        {
            statsModel.Items[(int)itemNum.Value].Icon = (byte)(itemNameIcon.SelectedIndex + 0x20);
            itemName.Invalidate();
        }
        private void itemNameIcon_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0 || e.Index > 95)
                return;

            char[] test = new char[] { (char)(e.Index + 0x20) };

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
            int[] pixels = new int[256 * 16];

            for (int y = 2, c = 0; y < 16; y++, c++)
            {
                for (int x = 2, a = 0; x < 256; x++, a++)
                    pixels[y * 256 + x] = temp[c * 256 + a];
            }

            Bitmap icon = new Bitmap(DrawImageFromIntArr(pixels, 256, 16));

            e.DrawBackground();
            e.Graphics.DrawImage(icon, new Point(e.Bounds.X, e.Bounds.Y));
            e.DrawFocusRectangle();
        }
        private void itemCoinValue_ValueChanged(object sender, EventArgs e)
        {
            statsModel.Items[(int)itemNum.Value].CoinValue = (ushort)this.itemCoinValue.Value;
        }
        private void itemSpeed_ValueChanged(object sender, EventArgs e)
        {
            statsModel.Items[(int)itemNum.Value].Speed = (sbyte)this.itemSpeed.Value;
        }
        private void itemAttackRange_ValueChanged(object sender, EventArgs e)
        {
            statsModel.Items[(int)itemNum.Value].AttackRange = (byte)this.itemAttackRange.Value;
        }
        private void itemPower_ValueChanged(object sender, EventArgs e)
        {
            statsModel.Items[(int)itemNum.Value].InflictionAmount = (byte)this.itemPower.Value;
        }
        private void itemAttack_ValueChanged(object sender, EventArgs e)
        {
            statsModel.Items[(int)itemNum.Value].Attack = (sbyte)this.itemAttack.Value;
        }
        private void itemDefense_ValueChanged(object sender, EventArgs e)
        {
            statsModel.Items[(int)itemNum.Value].Defense = (sbyte)this.itemDefense.Value;
        }
        private void itemMagicAttack_ValueChanged(object sender, EventArgs e)
        {
            statsModel.Items[(int)itemNum.Value].MagicAttack = (sbyte)this.itemMagicAttack.Value;
        }
        private void itemMagicDefense_ValueChanged(object sender, EventArgs e)
        {
            statsModel.Items[(int)itemNum.Value].MagicDefense = (sbyte)this.itemMagicDefense.Value;
        }
        private void itemType_SelectedIndexChanged(object sender, EventArgs e)
        {
            statsModel.Items[(int)itemNum.Value].ItemType = (byte)this.itemType.SelectedIndex;
        }
        private void itemAttackType_SelectedIndexChanged(object sender, EventArgs e)
        {
            statsModel.Items[(int)itemNum.Value].AttackType = (byte)this.itemAttackType.SelectedIndex;
            UpdateAttackType();
        }
        private void itemFunction_SelectedIndexChanged(object sender, EventArgs e)
        {
            statsModel.Items[(int)itemNum.Value].InflictFunction = (byte)this.itemFunction.SelectedIndex;
        }
        private void itemElemAttack_SelectedIndexChanged(object sender, EventArgs e)
        {
            statsModel.Items[(int)itemNum.Value].ElemAttack = (byte)this.itemElemAttack.SelectedIndex;
        }
        private void itemUsage_SelectedIndexChanged(object sender, EventArgs e)
        {
            statsModel.Items[(int)itemNum.Value].UsageInstantDeath = itemUsage.GetItemChecked(0);
            statsModel.Items[(int)itemNum.Value].HideDigits = itemUsage.GetItemChecked(1);
            statsModel.Items[(int)itemNum.Value].UsageBattleMenu = itemUsage.GetItemChecked(2);
            statsModel.Items[(int)itemNum.Value].UsageOverworldMenu = itemUsage.GetItemChecked(3);
            statsModel.Items[(int)itemNum.Value].UsageReusable = itemUsage.GetItemChecked(4);
        }
        private void itemStatusEffect_SelectedIndexChanged(object sender, EventArgs e)
        {
            statsModel.Items[(int)itemNum.Value].EffectMute = itemStatusEffect.GetItemChecked(0);
            statsModel.Items[(int)itemNum.Value].EffectSleep = itemStatusEffect.GetItemChecked(1);
            statsModel.Items[(int)itemNum.Value].EffectPoison = itemStatusEffect.GetItemChecked(2);
            statsModel.Items[(int)itemNum.Value].EffectFear = itemStatusEffect.GetItemChecked(3);
            statsModel.Items[(int)itemNum.Value].EffectMushroom = itemStatusEffect.GetItemChecked(4);
            statsModel.Items[(int)itemNum.Value].EffectScarecrow = itemStatusEffect.GetItemChecked(5);
            statsModel.Items[(int)itemNum.Value].EffectInvincible = itemStatusEffect.GetItemChecked(6);

        }
        private void itemElemNull_SelectedIndexChanged(object sender, EventArgs e)
        {
            statsModel.Items[(int)itemNum.Value].ElemIceNull = itemElemNull.GetItemChecked(0);
            statsModel.Items[(int)itemNum.Value].ElemFireNull = itemElemNull.GetItemChecked(1);
            statsModel.Items[(int)itemNum.Value].ElemThunderNull = itemElemNull.GetItemChecked(2);
            statsModel.Items[(int)itemNum.Value].ElemJumpNull = itemElemNull.GetItemChecked(3);
        }
        private void itemElemWeak_SelectedIndexChanged(object sender, EventArgs e)
        {
            statsModel.Items[(int)itemNum.Value].ElemIceWeak = itemElemWeak.GetItemChecked(0);
            statsModel.Items[(int)itemNum.Value].ElemFireWeak = itemElemWeak.GetItemChecked(1);
            statsModel.Items[(int)itemNum.Value].ElemThunderWeak = itemElemWeak.GetItemChecked(2);
            statsModel.Items[(int)itemNum.Value].ElemJumpWeak = itemElemWeak.GetItemChecked(3);
        }
        private void itemStatusChange_SelectedIndexChanged(object sender, EventArgs e)
        {
            statsModel.Items[(int)itemNum.Value].ChangeAttack = itemStatusChange.GetItemChecked(0);
            statsModel.Items[(int)itemNum.Value].ChangeDefense = itemStatusChange.GetItemChecked(1);
            statsModel.Items[(int)itemNum.Value].ChangeMagicAttack = itemStatusChange.GetItemChecked(2);
            statsModel.Items[(int)itemNum.Value].ChangeMagicDefense = itemStatusChange.GetItemChecked(3);
        }
        private void itemWhoEquip_SelectedIndexChanged(object sender, EventArgs e)
        {
            statsModel.Items[(int)itemNum.Value].EquipMario = itemWhoEquip.GetItemChecked(0);
            statsModel.Items[(int)itemNum.Value].EquipToadstool = itemWhoEquip.GetItemChecked(1);
            statsModel.Items[(int)itemNum.Value].EquipBowser = itemWhoEquip.GetItemChecked(2);
            statsModel.Items[(int)itemNum.Value].EquipGeno = itemWhoEquip.GetItemChecked(3);
            statsModel.Items[(int)itemNum.Value].EquipMallow = itemWhoEquip.GetItemChecked(4);
        }
        private void itemTargetting_SelectedIndexChanged(object sender, EventArgs e)
        {
            statsModel.Items[(int)itemNum.Value].TargetLiveAlly = itemTargetting.GetItemChecked(0);
            statsModel.Items[(int)itemNum.Value].TargetEnemy = itemTargetting.GetItemChecked(1);
            statsModel.Items[(int)itemNum.Value].TargetAll = itemTargetting.GetItemChecked(2);
            statsModel.Items[(int)itemNum.Value].TargetWoundedOnly = itemTargetting.GetItemChecked(3);
            statsModel.Items[(int)itemNum.Value].TargetOnePartyOnly = itemTargetting.GetItemChecked(4);
            statsModel.Items[(int)itemNum.Value].TargetNotSelf = itemTargetting.GetItemChecked(5);
        }
        private void itemCursor_SelectedIndexChanged(object sender, EventArgs e)
        {
            statsModel.Items[(int)itemNum.Value].CursorBehavior = (byte)itemCursor.SelectedIndex;
        }
        private void itemCursorRestore_SelectedIndexChanged(object sender, EventArgs e)
        {
            statsModel.Items[(int)itemNum.Value].RestoreFP = itemCursorRestore.GetItemChecked(0);
            statsModel.Items[(int)itemNum.Value].RestoreHP = itemCursorRestore.GetItemChecked(1);
        }

        private void pictureBoxItemDesc_Paint(object sender, PaintEventArgs e)
        {
            if (menuBGImage != null)
                e.Graphics.DrawImage(menuBGImage, 0, 0);
            if (itemDescImage != null)
                e.Graphics.DrawImage(itemDescImage, 0, 0);

            if (statsModel.Items[(int)itemNum.Value].ItemType == 3 && menuFrameItemImage != null)
                e.Graphics.DrawImage(menuFrameItemImage, 0, 0);
            else if (menuFrameEquipImage != null)
                e.Graphics.DrawImage(menuFrameEquipImage, 0, 0);
        }

        private int[] itemDescPixels;
        private Bitmap itemDescImage;
        private void SetItemDescImage()
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

            if (statsModel.Items[(int)itemNum.Value].ItemType == 3)
            {
                if (pictureBoxItemDesc.Size != new Size(120, 48))
                {
                    pictureBoxItemDesc.Size = new Size(120, 48);
                    panelItemDesc.Size = new Size(124, 71);
                    label195.Size = new Size(pictureBoxItemDesc.Width, 17);
                }
                itemDescPixels = menuDescPreview.GetPreview(
                    descCharacters, palette, statsModel.Items[(int)itemNum.Value].RawDescription,
                    new Size(120, 48), new Point(8, 8), 4);
                itemDescImage = new Bitmap(DrawImageFromIntArr(itemDescPixels, 120, 48));
            }
            else
            {
                if (pictureBoxItemDesc.Size != new Size(136, 64))
                {
                    pictureBoxItemDesc.Size = new Size(136, 64);
                    panelItemDesc.Size = new Size(140, 87);
                    label195.Size = new Size(pictureBoxItemDesc.Width, 17);
                }
                itemDescPixels = menuDescPreview.GetPreview(
                    descCharacters, palette, statsModel.Items[(int)itemNum.Value].RawDescription,
                    new Size(136, 64), new Point(16, 16), 4);
                itemDescImage = new Bitmap(DrawImageFromIntArr(itemDescPixels, 136, 64));
            }
            pictureBoxItemDesc.Invalidate();
        }
        #endregion
        #region Text Helpers
        public void InsertIntoItemDescriptionText(string toInsert)
        {
            char[] newText = new char[this.textBoxItemDescription.Text.Length + toInsert.Length];

            textBoxItemDescription.Text.CopyTo(0, newText, 0, textBoxItemDescription.SelectionStart);
            toInsert.CopyTo(0, newText, textBoxItemDescription.SelectionStart, toInsert.Length);
            textBoxItemDescription.Text.CopyTo(textBoxItemDescription.SelectionStart, newText, textBoxItemDescription.SelectionStart + toInsert.Length, this.textBoxItemDescription.Text.Length - this.textBoxItemDescription.SelectionStart);

            if (textCodeFormat)
                statsModel.Items[(int)itemNum.Value].CaretPositionSymbol = this.textBoxItemDescription.SelectionStart + toInsert.Length;
            else
                statsModel.Items[(int)itemNum.Value].CaretPositionNotSymbol = this.textBoxItemDescription.SelectionStart + toInsert.Length;
            statsModel.Items[(int)itemNum.Value].SetDescription(new string(newText), textCodeFormat);

            textBoxItemDescription.Text = statsModel.Items[(int)itemNum.Value].GetDescription(textCodeFormat);
        }
        #endregion

    }
}
