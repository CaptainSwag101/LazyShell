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
    public partial class Spells : NewForm
    {
        #region Variables
        private Spell[] spells { get { return Model.Spells; } set { Model.Spells = value; } }
        private Spell spell { get { return spells[index]; } set { spells[index] = value; } }
        public Spell Spell { get { return spell; } set { spell = value; } }
        private int index { get { return (int)spellNum.Value; } set { spellNum.Value = value; } }
        public int Index { get { return index; } set { index = value; } }
        private Settings settings = Settings.Default;
        private TextHelperReduced textHelper = TextHelperReduced.Instance;
        private bool byteView { get { return !textView.Checked; } set { textView.Checked = !value; } }
        private Bitmap descriptionFrame;
        private Bitmap descriptionText;
        private EditLabel labelWindow;
        #endregion
        // constructor
        public Spells()
        {
            InitializeComponent();
            InitializeStrings();
            RefreshSpells();
            RefreshTimingSpellsTwo();
            labelWindow = new EditLabel(spellName, spellNum, "Spells", false);
            //
            this.History = new History(this, spellName, spellNum);
        }
        #region Functions
        public void RefreshSpells()
        {
            Cursor.Current = Cursors.WaitCursor;
            if (this.Updating)
                return;
            this.Updating = true;
            this.spellName.SelectedIndex = Model.SpellNames.GetSortedIndex(index);
            this.spellFPCost.Value = spell.FPCost;
            this.spellMagPower.Value = spell.MagicPower;
            this.spellHitRate.Value = spell.HitRate;
            this.spellNameIcon.Visible = index < 64;
            this.spellNameIcon.SelectedIndex = (int)(spell.Name[0] - 0x20);
            this.spellNameIcon.Invalidate();
            if (index < 64)
                this.textBoxSpellName.Text = Do.RawToASCII(spell.Name, Lists.KeystrokesMenu).Substring(1);
            else
                this.textBoxSpellName.Text = Do.RawToASCII(spell.Name, Lists.Keystrokes).Substring(1);
            if (index > 26)
            {
                this.textBoxSpellDescription.Text = " This spell[1] cannot have a[1] description";
                if (spell.RawDescription == null)
                    this.textBoxSpellDescription_TextChanged(null, null);
                this.textBoxSpellDescription.Enabled = false;
                this.toolStrip2.Enabled = false;
            }
            else
            {
                this.textBoxSpellDescription.Enabled = true;
                this.toolStrip2.Enabled = true;
                this.textBoxSpellDescription.Text = spell.GetDescription(byteView);
            }
            this.spellAttackProp.SetItemChecked(0, spell.CheckStats);
            this.spellAttackProp.SetItemChecked(1, spell.IgnoreDefense);
            this.spellAttackProp.SetItemChecked(2, spell.CheckMortality);
            this.spellAttackProp.SetItemChecked(3, spell.UsableOverworld);
            this.spellAttackProp.SetItemChecked(4, spell.MaxAttack);
            this.spellAttackProp.SetItemChecked(5, spell.HideDigits);
            this.spellStatusEffect.SetItemChecked(0, spell.EffectMute);
            this.spellStatusEffect.SetItemChecked(1, spell.EffectSleep);
            this.spellStatusEffect.SetItemChecked(2, spell.EffectPoison);
            this.spellStatusEffect.SetItemChecked(3, spell.EffectFear);
            this.spellStatusEffect.SetItemChecked(4, spell.EffectMushroom);
            this.spellStatusEffect.SetItemChecked(5, spell.EffectScarecrow);
            this.spellStatusEffect.SetItemChecked(6, spell.EffectInvincible);
            this.spellStatusChange.SetItemChecked(0, spell.ChangeAttack);
            this.spellStatusChange.SetItemChecked(1, spell.ChangeDefense);
            this.spellStatusChange.SetItemChecked(2, spell.ChangeMagicAttack);
            this.spellStatusChange.SetItemChecked(3, spell.ChangeMagicDefense);
            this.spellTargetting.SetItemChecked(0, spell.TargetLiveAlly);
            this.spellTargetting.SetItemChecked(1, spell.TargetEnemy);
            this.spellTargetting.SetItemChecked(2, spell.TargetAll);
            this.spellTargetting.SetItemChecked(3, spell.TargetWoundedOnly);
            this.spellTargetting.SetItemChecked(4, spell.TargetOnePartyOnly);
            this.spellTargetting.SetItemChecked(5, spell.TargetNotSelf);
            this.spellAttackType.SelectedIndex = spell.AttackType;
            this.spellEffectType.SelectedIndex = spell.EffectType;
            this.spellFunction.SelectedIndex = spell.InflictFunction;
            this.spellInflictElement.SelectedIndex = spell.InflictElement;
            if (spell.EffectType == 0)
            {
                this.groupBox8.Text = "Effect <INFLICT>";
                this.groupBox9.Text = "Status <UP>";
            }
            else if (spell.EffectType == 1)
            {
                this.groupBox8.Text = "Effect <NULLIFY>";
                this.groupBox9.Text = "Status <DOWN>";
            }
            else if (spell.EffectType == 2)
            {
                this.groupBox8.Text = "Effect <. . . .>";
                this.groupBox9.Text = "Status <. . . .>";
            }
            // timing
            panelTimingMultiple.Visible = index == 2 || index == 4 || index == 26;
            panelTimingOne.Visible = index == 9 || index == 17 || index == 18 || index == 21 || index == 23;
            panelTimingTwo.Visible = index == 0 || index == 6 || index == 7 || index == 14 || index == 22 || index == 24;
            panelTimingGeno.Visible = index == 16 || index == 19 || index == 20;
            panelTimingRotation.Visible = index == 8 || index == 10 || index == 12 || index == 13 || index == 25;
            panelTimingRapid.Visible = index == 11 || index == 15;
            panelTimingFireball.Visible = index == 1 || index == 3 || index == 5;
            if (index == 2 || index == 4 || index == 26)
                RefreshTimingMultipleTiming();
            if (index == 9 || index == 17 || index == 18 || index == 21 || index == 23)
                RefreshTimingSpellsOne();
            if (index == 0 || index == 6 || index == 7 || index == 14 || index == 22 || index == 24)
                RefreshTimingSpellsTwo();
            if (index == 16 || index == 19 || index == 20)
                RefreshTimingSpellsGeno();
            if (index == 8 || index == 10 || index == 12 || index == 13 || index == 25)
                RefreshTimingRotaionSpells();
            if (index == 11 || index == 15)
                RefreshTimingRapidSpellMax();
            if (index == 1 || index == 3 || index == 5)
                RefreshTimingFireballSpells();
            this.Updating = false;
            Cursor.Current = Cursors.Arrow;
        }
        private void RefreshTimingSpellsOne()
        {
            this.timingOne.Value = spell.OneLevelSpellSpan;
        }
        private void RefreshTimingSpellsTwo()
        {
            this.timingTwoStart.Value = spell.TwoLevelSpellStartLevel2;
            this.timingTwoEnd.Value = spell.TwoLevelSpellEndLevel2;
            this.timingOneEnd.Value = spell.TwoLevelSpellEndLevel1;
        }
        private void RefreshTimingSpellsGeno()
        {
            this.timingGeno2Frame.Value = spell.ChargeSpellStartLevel2;
            this.timingGeno3Frame.Value = spell.ChargeSpellStartLevel3;
            this.timingGeno4Frame.Value = spell.ChargeSpellStartLevel4;
            this.timingGenoOverflow.Value = spell.ChargeSpellOverflow;
        }
        private void RefreshTimingFireballSpells()
        {
            this.timingFireballSpan.Value = spell.FireballSpellRange;
            this.timingFireballMax.Value = spell.FireballSpellOrbs;
        }
        private void RefreshTimingRotaionSpells()
        {
            this.timingRotationStart.Value = spell.RotationSpellStart;
            this.timingRotationMax.Value = spell.RotationSpellMax;
        }
        private void RefreshTimingRapidSpellMax()
        {
            this.timingRapid.Value = spell.RapidSpellMax;
        }
        private void RefreshTimingMultipleTiming()
        {
            this.timingInstanceNumber.Items.Clear();
            if (index == 2 || index == 4)
            {
                int count = (index == 2) ? 14 : 17;
                for (int i = 0; i < count; i++)
                    this.timingInstanceNumber.Items.Add(
                        this.spellName.SelectedItem.ToString().Trim() + " " + i.ToString());
                this.timingInstanceNumber.SelectedIndex = 0;
                this.timingInstanceNumber.Enabled = true;
            }
            else
            {
                this.timingInstanceNumber.Items.Add("");
                this.timingInstanceNumber.SelectedIndex = 0;
                this.timingInstanceNumber.Enabled = false;
            }
            this.timingInstanceMax.Value = spell.MultipleSpellInstanceMax;
            this.timingInstanceSpan.Value = spell.MultipleSpellInstanceRange[timingInstanceNumber.SelectedIndex];
        }
        private void InitializeStrings()
        {
            this.spellName.Items.Clear();
            this.spellName.Items.AddRange(Model.SpellNames.Names);
            this.spellName.SelectedIndex = Model.SpellNames.GetSortedIndex(index);
            string[] temp = new string[96];
            for (int i = 0; i < 96; i++)
                temp[i] = i.ToString();
            this.spellNameIcon.Items.Clear();
            this.spellNameIcon.Items.AddRange(temp);
        }
        private void InsertIntoDescriptionText(string toInsert)
        {
            char[] newText = new char[textBoxSpellDescription.Text.Length + toInsert.Length];
            textBoxSpellDescription.Text.CopyTo(0, newText, 0, textBoxSpellDescription.SelectionStart);
            toInsert.CopyTo(0, newText, textBoxSpellDescription.SelectionStart, toInsert.Length);
            textBoxSpellDescription.Text.CopyTo(textBoxSpellDescription.SelectionStart, newText, textBoxSpellDescription.SelectionStart + toInsert.Length, this.textBoxSpellDescription.Text.Length - this.textBoxSpellDescription.SelectionStart);
            if (byteView)
                spell.CaretPosByteView = this.textBoxSpellDescription.SelectionStart + toInsert.Length;
            else
                spell.CaretPosTextView = this.textBoxSpellDescription.SelectionStart + toInsert.Length;
            spell.SetDescription(new string(newText), byteView);
            textBoxSpellDescription.Text = spell.GetDescription(byteView);
        }
        #endregion
        #region Event Handlers
        private void spellNum_ValueChanged(object sender, EventArgs e)
        {
            RefreshSpells();
            settings.LastSpell = index;
        }
        private void spellName_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.spellNum.Value = Model.SpellNames.GetUnsortedIndex(spellName.SelectedIndex);
        }
        private void spellName_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0)
                return;
            Do.DrawName(
                sender, e, new BattleDialoguePreview(), Model.SpellNames,
                Model.SpellNames.GetUnsortedIndex(e.Index) < 64 ? Model.FontMenu : Model.FontDialogue,
                Model.FontPaletteMenu.Palettes[0], 8, 10, 0, 128, false, false, Model.MenuBG_);
        }
        private void spellNameIcon_SelectedIndexChanged(object sender, EventArgs e)
        {
            spell.Name[0] = (char)(spellNameIcon.SelectedIndex + 0x20);
            if (Model.SpellNames.GetUnsortedName(index).CompareTo(this.textBoxSpellName.Text) != 0)
            {
                Model.SpellNames.SetName(
                    index, new string(spell.Name));
                Model.SpellNames.SortAlphabetically();
                this.spellName.Items.Clear();
                this.spellName.Items.AddRange(Model.SpellNames.Names);
                this.spellName.SelectedIndex = Model.SpellNames.GetSortedIndex(index);
            }
        }
        private void spellNameIcon_DrawItem(object sender, DrawItemEventArgs e)
        {
            Do.DrawIcon(sender, e, new MenuTextPreview(), 32, Model.FontMenu, Model.FontPaletteMenu.Palettes[0], false, Model.MenuBG_);
        }
        private void textBoxSpellName_TextChanged(object sender, EventArgs e)
        {
            char[] raw = new char[15];
            char[] temp;
            if (spellNum.Value < 64)
                temp = Do.ASCIIToRaw(this.textBoxSpellName.Text, Lists.KeystrokesMenu, 14);
            else
                temp = Do.ASCIIToRaw(this.textBoxSpellName.Text, Lists.Keystrokes, 14);
            for (int i = 0; i < 14; i++)
                raw[i + 1] = temp[i];
            raw[0] = (char)(spellNameIcon.SelectedIndex + 32);
            if (Model.SpellNames.GetUnsortedName(index).CompareTo(this.textBoxSpellName.Text) != 0)
            {
                spell.Name = raw;
                Model.SpellNames.SetName(
                    index, new string(spell.Name));
                Model.SpellNames.SortAlphabetically();
                this.spellName.Items.Clear();
                this.spellName.Items.AddRange(Model.SpellNames.Names);
                this.spellName.SelectedIndex = Model.SpellNames.GetSortedIndex(index);
            }
        }
        private void textBoxSpellName_Leave(object sender, EventArgs e)
        {
            spellName.Items.Clear();
            spellName.Items.AddRange(Model.SpellNames.Names);
            spellName.SelectedIndex = Model.SpellNames.GetSortedIndex(index);
            InitializeStrings();
        }
        private void spellFPCost_ValueChanged(object sender, EventArgs e)
        {
            spell.FPCost = (byte)this.spellFPCost.Value;
        }
        private void spellMagPower_ValueChanged(object sender, EventArgs e)
        {
            spell.MagicPower = (byte)this.spellMagPower.Value;
        }
        private void spellHitRate_ValueChanged(object sender, EventArgs e)
        {
            spell.HitRate = (byte)this.spellHitRate.Value;
        }
        private void spellAttackType_SelectedIndexChanged(object sender, EventArgs e)
        {
            spell.AttackType = (byte)this.spellAttackType.SelectedIndex;
        }
        private void spellEffectType_SelectedIndexChanged(object sender, EventArgs e)
        {
            spell.EffectType = (byte)this.spellEffectType.SelectedIndex;
            if (spell.EffectType == 0)
            {
                this.groupBox8.Text = "Effect <INFLICT>";
                this.groupBox9.Text = "Status <UP>";
            }
            else if (spell.EffectType == 1)
            {
                this.groupBox8.Text = "Effect <NULLIFY>";
                this.groupBox9.Text = "Status <DOWN>";
            }
            else if (spell.EffectType == 2)
            {
                this.groupBox8.Text = "Effect <. . . .>";
                this.groupBox9.Text = "Status <. . . .>";
            }
        }
        private void spellFunction_SelectedIndexChanged(object sender, EventArgs e)
        {
            spell.InflictFunction = (byte)this.spellFunction.SelectedIndex;
        }
        private void spellInflictElement_SelectedIndexChanged(object sender, EventArgs e)
        {
            spell.InflictElement = (byte)this.spellInflictElement.SelectedIndex;
        }
        private void spellAttackProp_SelectedIndexChanged(object sender, EventArgs e)
        {
            spell.CheckStats = this.spellAttackProp.GetItemChecked(0);
            spell.IgnoreDefense = this.spellAttackProp.GetItemChecked(1);
            spell.CheckMortality = this.spellAttackProp.GetItemChecked(2);
            spell.UsableOverworld = this.spellAttackProp.GetItemChecked(3);
            spell.MaxAttack = this.spellAttackProp.GetItemChecked(4);
            spell.HideDigits = this.spellAttackProp.GetItemChecked(5);
        }
        private void spellStatusEffect_SelectedIndexChanged(object sender, EventArgs e)
        {
            spell.EffectMute = this.spellStatusEffect.GetItemChecked(0);
            spell.EffectSleep = this.spellStatusEffect.GetItemChecked(1);
            spell.EffectPoison = this.spellStatusEffect.GetItemChecked(2);
            spell.EffectFear = this.spellStatusEffect.GetItemChecked(3);
            spell.EffectMushroom = this.spellStatusEffect.GetItemChecked(4);
            spell.EffectScarecrow = this.spellStatusEffect.GetItemChecked(5);
            spell.EffectInvincible = this.spellStatusEffect.GetItemChecked(6);
        }
        private void spellTargetting_SelectedIndexChanged(object sender, EventArgs e)
        {
            spell.TargetLiveAlly = this.spellTargetting.GetItemChecked(0);
            spell.TargetEnemy = this.spellTargetting.GetItemChecked(1);
            spell.TargetAll = this.spellTargetting.GetItemChecked(2);
            spell.TargetWoundedOnly = this.spellTargetting.GetItemChecked(3);
            spell.TargetOnePartyOnly = this.spellTargetting.GetItemChecked(4);
            spell.TargetNotSelf = this.spellTargetting.GetItemChecked(5);
        }
        private void spellStatusChange_SelectedIndexChanged(object sender, EventArgs e)
        {
            spell.ChangeAttack = this.spellStatusChange.GetItemChecked(0);
            spell.ChangeDefense = this.spellStatusChange.GetItemChecked(1);
            spell.ChangeMagicAttack = this.spellStatusChange.GetItemChecked(2);
            spell.ChangeMagicDefense = this.spellStatusChange.GetItemChecked(3);
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
            bool flag = textHelper.VerifySymbols(this.textBoxSpellDescription.Text.ToCharArray(), byteView);
            if (flag)
            {
                this.textBoxSpellDescription.BackColor = Color.FromArgb(255, 255, 255, 255);
                spell.SetDescription(this.textBoxSpellDescription.Text, byteView);
            }
            if (!flag || spell.DescriptionError)
                this.textBoxSpellDescription.BackColor = Color.Red;
            descriptionText = null;
            pictureBoxSpellDesc.Invalidate();
        }
        private void newLine_Click(object sender, EventArgs e)
        {
            if (byteView)
                InsertIntoDescriptionText("[1]");
            else
                InsertIntoDescriptionText("[newLine]");
        }
        private void endString_Click(object sender, EventArgs e)
        {
            if (byteView)
                InsertIntoDescriptionText("[0]");
            else
                InsertIntoDescriptionText("[endInput]");
        }
        private void pictureBoxSpellDesc_Paint(object sender, PaintEventArgs e)
        {
            if (spell.RawDescription == null)
                return;
            if (descriptionFrame == null)
            {
                int[] bgPixels = Do.ImageToPixels(Model.MenuBG);
                Do.DrawMenuFrame(bgPixels, 256, new Rectangle(0, 0, 15, 8), Model.MenuFrameGraphics, Model.FontPaletteMenu.Palette);
                descriptionFrame = Do.PixelsToImage(bgPixels, 256, 256);
            }
            e.Graphics.DrawImage(descriptionFrame, 0, 0);
            if (descriptionText == null)
                SetDescriptionText();
            e.Graphics.DrawImage(descriptionText, 0, 0);
        }
        private void SetDescriptionText()
        {
            int[] pixels = new MenuDescriptionPreview().GetPreview(
                Model.FontDescription, Model.FontPaletteMenu.Palettes[0], spell.RawDescription,
                new Size(120, 88), new Point(8, 8), 6);
            descriptionText = new Bitmap(Do.PixelsToImage(pixels, 120, 88));
            pictureBoxSpellDesc.Invalidate();
        }
        private void byteOrText_Click(object sender, EventArgs e)
        {
            this.textBoxSpellDescription.Text = spell.GetDescription(byteView);
        }
        // level 1 timing
        private void numericUpDown100_ValueChanged(object sender, EventArgs e)
        {
            this.spell.OneLevelSpellSpan = (byte)timingOne.Value;
        }
        // level 2 timing
        private void numericUpDown107_ValueChanged(object sender, EventArgs e)
        {
            this.spell.TwoLevelSpellStartLevel2 = (byte)timingTwoStart.Value;
            if (index == 6)
                this.spells[7].TwoLevelSpellStartLevel2 = (byte)timingTwoStart.Value;
            if (index == 7)
                this.spells[6].TwoLevelSpellStartLevel2 = (byte)timingTwoStart.Value;
        }
        private void numericUpDown110_ValueChanged(object sender, EventArgs e)
        {
            this.spell.TwoLevelSpellEndLevel2 = (byte)timingTwoEnd.Value;
            if (index == 6)
                this.spells[7].TwoLevelSpellEndLevel2 = (byte)timingTwoEnd.Value;
            if (index == 7)
                this.spells[6].TwoLevelSpellEndLevel2 = (byte)timingTwoEnd.Value;
        }
        private void numericUpDown108_ValueChanged(object sender, EventArgs e)
        {
            this.spell.TwoLevelSpellEndLevel1 = (byte)timingOneEnd.Value;
            if (index == 6)
                this.spells[7].TwoLevelSpellEndLevel1 = (byte)timingOneEnd.Value;
            if (index == 7)
                this.spells[6].TwoLevelSpellEndLevel1 = (byte)timingOneEnd.Value;
        }
        // charge spell timing
        private void timingGeno2Frame_ValueChanged(object sender, EventArgs e)
        {
            this.spells[16].ChargeSpellStartLevel2 = (byte)timingGeno2Frame.Value;
            this.spells[19].ChargeSpellStartLevel2 = (byte)timingGeno2Frame.Value;
            this.spells[20].ChargeSpellStartLevel2 = (byte)timingGeno2Frame.Value;
        }
        private void timingGeno3Frame_ValueChanged(object sender, EventArgs e)
        {
            this.spells[16].ChargeSpellStartLevel3 = (byte)timingGeno3Frame.Value;
            this.spells[19].ChargeSpellStartLevel3 = (byte)timingGeno3Frame.Value;
            this.spells[20].ChargeSpellStartLevel3 = (byte)timingGeno3Frame.Value;
        }
        private void numericUpDown114_ValueChanged(object sender, EventArgs e)
        {
            this.spells[16].ChargeSpellStartLevel4 = (byte)timingGeno4Frame.Value;
            this.spells[19].ChargeSpellStartLevel4 = (byte)timingGeno4Frame.Value;
            this.spells[20].ChargeSpellStartLevel4 = (byte)timingGeno4Frame.Value;
        }
        private void numericUpDown112_ValueChanged(object sender, EventArgs e)
        {
            this.spells[16].ChargeSpellOverflow = (byte)timingGenoOverflow.Value;
            this.spells[19].ChargeSpellOverflow = (byte)timingGenoOverflow.Value;
            this.spells[20].ChargeSpellOverflow = (byte)timingGenoOverflow.Value;
        }
        // fireball timing
        private void numericUpDown106_ValueChanged(object sender, EventArgs e)
        {
            this.spell.FireballSpellRange = (byte)timingFireballSpan.Value;
        }
        private void numericUpDown105_ValueChanged(object sender, EventArgs e)
        {
            this.spell.FireballSpellOrbs = (byte)timingFireballMax.Value;
        }
        // rotation timing
        private void numericUpDown104_ValueChanged(object sender, EventArgs e)
        {
            this.spell.RotationSpellStart = (byte)timingRotationStart.Value;
        }
        private void numericUpDown103_ValueChanged(object sender, EventArgs e)
        {
            this.spell.RotationSpellMax = (byte)timingRotationMax.Value;
        }
        // multiple instance timing
        private void numericUpDown7_ValueChanged(object sender, EventArgs e)
        {
            this.spell.MultipleSpellInstanceMax = (byte)timingInstanceMax.Value;
        }
        private void instanceNumberName_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.timingInstanceSpan.Value = spell.MultipleSpellInstanceRange[timingInstanceNumber.SelectedIndex];
        }
        private void instanceNumberName_DrawItem(object sender, DrawItemEventArgs e)
        {
            string[] array = Lists.Convert(timingInstanceNumber.Items);
            Do.DrawName(
                sender, e, new BattleDialoguePreview(), array, Model.FontMenu,
                Model.FontPaletteMenu.Palettes[0], 8, 10, 0, 128, false, false, Model.MenuBG_);
        }
        private void numericUpDown8_ValueChanged(object sender, EventArgs e)
        {
            this.spell.MultipleSpellInstanceRange[timingInstanceNumber.SelectedIndex] = (byte)timingInstanceSpan.Value;
        }
        // rapid spell timing
        private void numericUpDown102_ValueChanged(object sender, EventArgs e)
        {
            this.spells[11].RapidSpellMax = (byte)timingRapid.Value;
            this.spells[15].RapidSpellMax = (byte)timingRapid.Value;
        }
        #endregion
    }
}
