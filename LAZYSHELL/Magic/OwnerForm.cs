using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LAZYSHELL.Properties;

namespace LAZYSHELL.Magic
{
    public partial class OwnerForm : Controls.NewForm
    {
        #region Variables

        // Index
        public int Index
        {
            get { return (int)num.Value; }
            set { num.Value = value; }
        }

        // Elements
        private Spell[] spells
        {
            get { return Model.Spells; }
            set { Model.Spells = value; }
        }
        private Spell spell
        {
            get { return spells[Index]; }
            set { spells[Index] = value; }
        }
        private Settings settings = Settings.Default;
        private Dialogues.ParserReduced parser = Dialogues.ParserReduced.Instance;
        private bool byteView
        {
            get { return !textView.Checked; }
            set { textView.Checked = !value; }
        }

        // Image
        private Bitmap descriptionFrameImage;
        private Bitmap descriptionTextImage;

        // Forms
        private EditLabel labelWindow;

        #endregion

        // Constructor
        public OwnerForm()
        {
            InitializeComponent();
            InitializeListControls();
            Do.AddShortcut(toolStrip3, Keys.Control | Keys.S, new EventHandler(save_Click));
            Do.AddShortcut(toolStrip3, Keys.F1, helpTips);
            Do.AddShortcut(toolStrip3, Keys.F2, baseConvertor);
            new ToolTipLabel(this, baseConvertor, helpTips);
            LoadProperties();
            LoadTimingTwo();
            if (settings.RememberLastIndex)
                Index = settings.LastSpell;
            labelWindow = new EditLabel(name, num, "Spells", false);
            //
            this.History = new History(this, name, num);
        }

        #region Methods

        // Initialization
        private void InitializeListControls()
        {
            this.name.Items.Clear();
            this.name.Items.AddRange(Model.Names.Names);
            this.name.SelectedIndex = Model.Names.GetSortedIndex(Index);
            string[] temp = new string[96];
            for (int i = 0; i < 96; i++)
                temp[i] = i.ToString();
            this.nameIcon.Items.Clear();
            this.nameIcon.Items.AddRange(temp);
        }
        public void LoadProperties()
        {
            Cursor.Current = Cursors.WaitCursor;
            if (this.Updating)
                return;
            this.Updating = true;
            this.name.SelectedIndex = Model.Names.GetSortedIndex(Index);
            this.fpCost.Value = spell.FPCost;
            this.magicPower.Value = spell.MagicPower;
            this.hitRate.Value = spell.HitRate;
            this.nameIcon.Visible = Index < 64;
            this.nameIcon.SelectedIndex = (int)(spell.Name[0] - 0x20);
            this.nameIcon.Invalidate();
            if (Index < 64)
                this.nameText.Text = Do.RawToASCII(spell.Name, Lists.KeystrokesMenu).Substring(1);
            else
                this.nameText.Text = Do.RawToASCII(spell.Name, Lists.Keystrokes).Substring(1);
            if (Index > 26)
            {
                this.description.Text = " THIS SPELL[1] CANNOT HAVE[1] A DESCRIPTION";
                if (spell.RawDescription == null)
                    this.description_TextChanged(null, null);
                this.description.Enabled = false;
                this.toolStrip2.Enabled = false;
            }
            else
            {
                this.description.Enabled = true;
                this.toolStrip2.Enabled = true;
                this.description.Text = spell.GetDescription(byteView);
            }
            this.attackProperties.SetItemChecked(0, spell.CheckStats);
            this.attackProperties.SetItemChecked(1, spell.IgnoreDefense);
            this.attackProperties.SetItemChecked(2, spell.CheckMortality);
            this.attackProperties.SetItemChecked(3, spell.UsableOverworld);
            this.attackProperties.SetItemChecked(4, spell.MaxAttack);
            this.attackProperties.SetItemChecked(5, spell.HideDigits);
            this.statusEffect.SetItemChecked(0, spell.EffectMute);
            this.statusEffect.SetItemChecked(1, spell.EffectSleep);
            this.statusEffect.SetItemChecked(2, spell.EffectPoison);
            this.statusEffect.SetItemChecked(3, spell.EffectFear);
            this.statusEffect.SetItemChecked(4, spell.EffectMushroom);
            this.statusEffect.SetItemChecked(5, spell.EffectScarecrow);
            this.statusEffect.SetItemChecked(6, spell.EffectInvincible);
            this.statusChange.SetItemChecked(0, spell.ChangeAttack);
            this.statusChange.SetItemChecked(1, spell.ChangeDefense);
            this.statusChange.SetItemChecked(2, spell.ChangeMagicAttack);
            this.statusChange.SetItemChecked(3, spell.ChangeMagicDefense);
            this.targetting.SetItemChecked(0, spell.TargetLiveAlly);
            this.targetting.SetItemChecked(1, spell.TargetEnemy);
            this.targetting.SetItemChecked(2, spell.TargetAll);
            this.targetting.SetItemChecked(3, spell.TargetWoundedOnly);
            this.targetting.SetItemChecked(4, spell.TargetOnePartyOnly);
            this.targetting.SetItemChecked(5, spell.TargetNotSelf);
            this.attackType.SelectedIndex = spell.AttackType;
            this.effectType.SelectedIndex = spell.EffectType;
            this.inflictFunction.SelectedIndex = spell.InflictFunction;
            this.inflictElement.SelectedIndex = spell.InflictElement;
            if (spell.EffectType == 0)
            {
                this.headerLabelEffects.Text = "Effect <INFLICT>";
                this.headerLabelStatus.Text = "Status <UP>";
            }
            else if (spell.EffectType == 1)
            {
                this.headerLabelEffects.Text = "Effect <NULLIFY>";
                this.headerLabelStatus.Text = "Status <DOWN>";
            }
            else if (spell.EffectType == 2)
            {
                this.headerLabelEffects.Text = "Effect <. . . .>";
                this.headerLabelStatus.Text = "Status <. . . .>";
            }
            // timing
            panelTimingMultiple.Visible = Index == 2 || Index == 4 || Index == 26;
            panelTimingOne.Visible = Index == 9 || Index == 17 || Index == 18 || Index == 21 || Index == 23;
            panelTimingTwo.Visible = Index == 0 || Index == 6 || Index == 7 || Index == 14 || Index == 22 || Index == 24;
            panelTimingGeno.Visible = Index == 16 || Index == 19 || Index == 20;
            panelTimingRotation.Visible = Index == 8 || Index == 10 || Index == 12 || Index == 13 || Index == 25;
            panelTimingRapid.Visible = Index == 11 || Index == 15;
            panelTimingFireball.Visible = Index == 1 || Index == 3 || Index == 5;
            if (Index == 2 || Index == 4 || Index == 26)
                LoadTimingMultiple();
            if (Index == 9 || Index == 17 || Index == 18 || Index == 21 || Index == 23)
                LoadTimingOne();
            if (Index == 0 || Index == 6 || Index == 7 || Index == 14 || Index == 22 || Index == 24)
                LoadTimingTwo();
            if (Index == 16 || Index == 19 || Index == 20)
                LoadTimingGeno();
            if (Index == 8 || Index == 10 || Index == 12 || Index == 13 || Index == 25)
                LoadTimingRotaion();
            if (Index == 11 || Index == 15)
                LoadTimingRapid();
            if (Index == 1 || Index == 3 || Index == 5)
                LoadTimingFireball();
            this.Updating = false;
            Cursor.Current = Cursors.Arrow;
        }
        private void LoadTimingOne()
        {
            this.timingOne.Value = spell.OneLevelSpellSpan;
        }
        private void LoadTimingTwo()
        {
            this.timingTwoStart.Value = spell.TwoLevelSpellStartLevel2;
            this.timingTwoEnd.Value = spell.TwoLevelSpellEndLevel2;
            this.timingOneEnd.Value = spell.TwoLevelSpellEndLevel1;
        }
        private void LoadTimingGeno()
        {
            this.timingGeno2Frame.Value = spell.ChargeSpellStartLevel2;
            this.timingGeno3Frame.Value = spell.ChargeSpellStartLevel3;
            this.timingGeno4Frame.Value = spell.ChargeSpellStartLevel4;
            this.timingGenoOverflow.Value = spell.ChargeSpellOverflow;
        }
        private void LoadTimingFireball()
        {
            this.timingFireballSpan.Value = spell.FireballSpellRange;
            this.timingFireballMax.Value = spell.FireballSpellOrbs;
        }
        private void LoadTimingRotaion()
        {
            this.timingRotationStart.Value = spell.RotationSpellStart;
            this.timingRotationMax.Value = spell.RotationSpellMax;
        }
        private void LoadTimingRapid()
        {
            this.timingRapid.Value = spell.RapidSpellMax;
        }
        private void LoadTimingMultiple()
        {
            this.timingInstanceNumber.Items.Clear();
            if (Index == 2 || Index == 4)
            {
                int count = (Index == 2) ? 14 : 17;
                for (int i = 0; i < count; i++)
                    this.timingInstanceNumber.Items.Add(
                        this.name.SelectedItem.ToString().Trim() + " " + i.ToString());
                this.timingInstanceNumber.SelectedIndex = 0;
                this.timingInstanceNumber.Enabled = true;
            }
            else
            {
                this.timingInstanceNumber.Items.Add("");
                this.timingInstanceNumber.SelectedIndex = 0;
                this.timingInstanceNumber.Enabled = false;
            }
            this.timingInstanceMax.Value = spell.MultipleSpellMax;
            this.timingInstanceSpan.Value = spell.MultipleSpellRanges[timingInstanceNumber.SelectedIndex];
        }

        // Insert into text
        private void InsertIntoText(string value)
        {
            char[] newText = new char[description.Text.Length + value.Length];
            description.Text.CopyTo(0, newText, 0, description.SelectionStart);
            value.CopyTo(0, newText, description.SelectionStart, value.Length);
            description.Text.CopyTo(description.SelectionStart, newText, description.SelectionStart + value.Length, this.description.Text.Length - this.description.SelectionStart);
            if (byteView)
                spell.CaretPosByteView = this.description.SelectionStart + value.Length;
            else
                spell.CaretPosTextView = this.description.SelectionStart + value.Length;
            spell.SetDescription(new string(newText), byteView);
            description.Text = spell.GetDescription(byteView);
        }

        // Saving
        public void WriteToROM()
        {
            int i;
            int offset = 0x2BB6;
            int maxOffset = 0x2BB6 + 0x36A;
            for (i = 0; i < Model.Spells.Length; i++)
            {
                int descriptionLength = 0;
                if (Model.Spells[i].RawDescription != null)
                    descriptionLength = Model.Spells[i].RawDescription.Length;
                if (offset + descriptionLength >= maxOffset)
                    break;

                // Write spell and description data
                Model.Spells[i].WriteToROM(ref offset);
            }

            // Write description data to free space in ROM, if necessary
            offset = 0x55F0;
            maxOffset = 0x55F0 + 0xA10;
            for (; i < Model.Spells.Length; i++)
            {
                int descriptionLength = 0;
                if (Model.Spells[i].RawDescription != null)
                    descriptionLength = Model.Spells[i].RawDescription.Length;
                if (offset + descriptionLength >= maxOffset)
                    break;

                // Write spell and description data
                Model.Spells[i].WriteToROM(ref offset);
            }

            // Alert user of insufficient space
            if (i != Model.Spells.Length)
                MessageBox.Show("The total size of all spell descriptions has exceeded the maximum size. Not all descriptions have been saved.",
                    "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            // Finished
            this.Modified = false;
        }

        #endregion

        #region Event Handlers

        // OwnerForm
        private void OwnerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!this.Modified)
                return;
            var result = MessageBox.Show(
                "Spells have not been saved.\n\nWould you like to save changes?",
                "LAZY SHELL", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
                WriteToROM();
            else if (result == DialogResult.No)
                Model.ClearAll();
            else if (result == DialogResult.Cancel)
                e.Cancel = true;
        }

        // Data management
        private void save_Click(object sender, EventArgs e)
        {
        }
        private void import_Click(object sender, EventArgs e)
        {
            new IOElements(Model.Spells, IOMode.Import, Index, "IMPORT SPELLS...").ShowDialog();
            LoadProperties();
        }
        private void export_Click(object sender, EventArgs e)
        {
            new IOElements(Model.Spells, IOMode.Export, Index, "EXPORT SPELLS...").ShowDialog();
        }
        private void reset_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("You're about to undo all changes to the current spell. Go ahead with reset?",
                "LAZY SHELL", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;
            spell = new Spell(Index);
            LoadProperties();
        }
        private void clear_Click(object sender, EventArgs e)
        {
            new ClearElements(Model.Spells, Index, "CLEAR SPELLS...").ShowDialog();
            LoadProperties();
        }

        // Damage calculator
        private void damageCalculator_Click(object sender, EventArgs e)
        {
            var calculator = new StatusCalculator();
            calculator.Show();
        }

        // Navigators
        private void num_ValueChanged(object sender, EventArgs e)
        {
            LoadProperties();
            settings.LastSpell = Index;
        }
        private void name_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.num.Value = Model.Names.GetUnsortedIndex(name.SelectedIndex);
        }
        private void name_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0)
                return;
            Do.DrawName(
                sender, e, new BattleDialoguePreview(), Model.Names,
                Model.Names.GetUnsortedIndex(e.Index) < 64 ? Fonts.Model.Menu : Fonts.Model.Dialogue,
                Fonts.Model.Palette_Menu.Palettes[0], 8, 10, 0, 128, false, false, Menus.Model.MenuBG_256x255);
        }
        private void nameIcon_SelectedIndexChanged(object sender, EventArgs e)
        {
            spell.Name[0] = (char)(nameIcon.SelectedIndex + 0x20);
            if (Model.Names.GetUnsortedName(Index).CompareTo(this.nameText.Text) != 0)
            {
                Model.Names.SetName(Index, new string(spell.Name));
                Model.Names.SortAlphabetically();
                this.name.Items.Clear();
                this.name.Items.AddRange(Model.Names.Names);
                this.name.SelectedIndex = Model.Names.GetSortedIndex(Index);
            }
        }
        private void nameIcon_DrawItem(object sender, DrawItemEventArgs e)
        {
            Do.DrawIcon(sender, e, new MenuTextPreview(), 32, Fonts.Model.Menu, Fonts.Model.Palette_Menu.Palettes[0], false, Menus.Model.MenuBG_256x255);
        }

        // Name
        private void nameText_TextChanged(object sender, EventArgs e)
        {
            char[] raw = new char[15];
            char[] temp;
            if (num.Value < 64)
                temp = Do.ASCIIToRaw(this.nameText.Text, Lists.KeystrokesMenu, 14);
            else
                temp = Do.ASCIIToRaw(this.nameText.Text, Lists.Keystrokes, 14);
            for (int i = 0; i < 14; i++)
                raw[i + 1] = temp[i];
            raw[0] = (char)(nameIcon.SelectedIndex + 32);
            if (Model.Names.GetUnsortedName(Index).CompareTo(this.nameText.Text) != 0)
            {
                spell.Name = raw;
                Model.Names.SetName(
                    Index, new string(spell.Name));
                Model.Names.SortAlphabetically();
                this.name.Items.Clear();
                this.name.Items.AddRange(Model.Names.Names);
                this.name.SelectedIndex = Model.Names.GetSortedIndex(Index);
            }
        }
        private void nameText_Leave(object sender, EventArgs e)
        {
            name.Items.Clear();
            name.Items.AddRange(Model.Names.Names);
            name.SelectedIndex = Model.Names.GetSortedIndex(Index);
            InitializeListControls();
        }

        #region Statistics

        private void fpCost_ValueChanged(object sender, EventArgs e)
        {
            spell.FPCost = (byte)this.fpCost.Value;
        }
        private void magicPower_ValueChanged(object sender, EventArgs e)
        {
            spell.MagicPower = (byte)this.magicPower.Value;
        }
        private void hitRate_ValueChanged(object sender, EventArgs e)
        {
            spell.HitRate = (byte)this.hitRate.Value;
        }
        private void attackType_SelectedIndexChanged(object sender, EventArgs e)
        {
            spell.AttackType = (byte)this.attackType.SelectedIndex;
        }
        private void effectType_SelectedIndexChanged(object sender, EventArgs e)
        {
            spell.EffectType = (byte)this.effectType.SelectedIndex;
            if (spell.EffectType == 0)
            {
                this.headerLabelEffects.Text = "Effect <INFLICT>";
                this.headerLabelStatus.Text = "Status <UP>";
            }
            else if (spell.EffectType == 1)
            {
                this.headerLabelEffects.Text = "Effect <NULLIFY>";
                this.headerLabelStatus.Text = "Status <DOWN>";
            }
            else if (spell.EffectType == 2)
            {
                this.headerLabelEffects.Text = "Effect <. . . .>";
                this.headerLabelStatus.Text = "Status <. . . .>";
            }
        }
        private void inflictFunction_SelectedIndexChanged(object sender, EventArgs e)
        {
            spell.InflictFunction = (byte)this.inflictFunction.SelectedIndex;
        }
        private void inflictElement_SelectedIndexChanged(object sender, EventArgs e)
        {
            spell.InflictElement = (byte)this.inflictElement.SelectedIndex;
        }
        private void attackProperties_SelectedIndexChanged(object sender, EventArgs e)
        {
            spell.CheckStats = this.attackProperties.GetItemChecked(0);
            spell.IgnoreDefense = this.attackProperties.GetItemChecked(1);
            spell.CheckMortality = this.attackProperties.GetItemChecked(2);
            spell.UsableOverworld = this.attackProperties.GetItemChecked(3);
            spell.MaxAttack = this.attackProperties.GetItemChecked(4);
            spell.HideDigits = this.attackProperties.GetItemChecked(5);
        }
        private void statusEffect_SelectedIndexChanged(object sender, EventArgs e)
        {
            spell.EffectMute = this.statusEffect.GetItemChecked(0);
            spell.EffectSleep = this.statusEffect.GetItemChecked(1);
            spell.EffectPoison = this.statusEffect.GetItemChecked(2);
            spell.EffectFear = this.statusEffect.GetItemChecked(3);
            spell.EffectMushroom = this.statusEffect.GetItemChecked(4);
            spell.EffectScarecrow = this.statusEffect.GetItemChecked(5);
            spell.EffectInvincible = this.statusEffect.GetItemChecked(6);
        }
        private void targetting_SelectedIndexChanged(object sender, EventArgs e)
        {
            spell.TargetLiveAlly = this.targetting.GetItemChecked(0);
            spell.TargetEnemy = this.targetting.GetItemChecked(1);
            spell.TargetAll = this.targetting.GetItemChecked(2);
            spell.TargetWoundedOnly = this.targetting.GetItemChecked(3);
            spell.TargetOnePartyOnly = this.targetting.GetItemChecked(4);
            spell.TargetNotSelf = this.targetting.GetItemChecked(5);
        }
        private void statusChange_SelectedIndexChanged(object sender, EventArgs e)
        {
            spell.ChangeAttack = this.statusChange.GetItemChecked(0);
            spell.ChangeDefense = this.statusChange.GetItemChecked(1);
            spell.ChangeMagicAttack = this.statusChange.GetItemChecked(2);
            spell.ChangeMagicDefense = this.statusChange.GetItemChecked(3);
        }
        private void description_TextChanged(object sender, EventArgs e)
        {
            char[] text = description.Text.ToCharArray();
            char[] swap;
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == '\n')
                {
                    int tempSel = description.SelectionStart;
                    swap = new char[text.Length + 2];
                    for (int x = 0; x < i; x++)
                        swap[x] = text[x];
                    swap[i] = '[';
                    swap[i + 1] = '1';
                    swap[i + 2] = ']';
                    for (int x = i + 3; x < swap.Length; x++)
                        swap[x] = text[x - 2];
                    description.Text = new string(swap);
                    text = description.Text.ToCharArray();
                    i += 2;
                    description.SelectionStart = tempSel + 2;
                }
            }
            bool flag = parser.VerifySymbols(this.description.Text.ToCharArray(), byteView);
            if (flag)
            {
                this.description.BackColor = Color.FromArgb(255, 255, 255, 255);
                spell.SetDescription(this.description.Text, byteView);
            }
            if (!flag || spell.DescriptionError)
                this.description.BackColor = Color.Red;
            descriptionTextImage = null;
            pictureBoxSpellDesc.Invalidate();
        }
        private void newLine_Click(object sender, EventArgs e)
        {
            if (byteView)
                InsertIntoText("[1]");
            else
                InsertIntoText("[newLine]");
        }
        private void endString_Click(object sender, EventArgs e)
        {
            if (byteView)
                InsertIntoText("[0]");
            else
                InsertIntoText("[endInput]");
        }
        private void pictureBoxDescription_Paint(object sender, PaintEventArgs e)
        {
            if (spell.RawDescription == null)
                return;
            if (descriptionFrameImage == null)
            {
                int[] bgPixels = Do.ImageToPixels(Menus.Model.MenuBG_256x256);
                Do.DrawMenuFrame(bgPixels, 256, new Rectangle(0, 0, 15, 8), Menus.Model.Menu_Frame_Graphics, Fonts.Model.Palette_Menu.Palette);
                descriptionFrameImage = Do.PixelsToImage(bgPixels, 256, 256);
            }
            e.Graphics.DrawImage(descriptionFrameImage, 0, 0);
            if (descriptionTextImage == null)
                SetDescriptionText();
            e.Graphics.DrawImage(descriptionTextImage, 0, 0);
        }
        private void SetDescriptionText()
        {
            int[] pixels = new MenuDescriptionPreview().GetPreview(
                Fonts.Model.Description, Fonts.Model.Palette_Menu.Palettes[0], spell.RawDescription,
                new Size(120, 88), new Point(8, 8), 6);
            descriptionTextImage = Do.PixelsToImage(pixels, 120, 88);
            pictureBoxSpellDesc.Invalidate();
        }
        private void byteOrText_Click(object sender, EventArgs e)
        {
            this.description.Text = spell.GetDescription(byteView);
        }

        #endregion

        #region Timing

        // Level 1 timing
        private void timingOne_ValueChanged(object sender, EventArgs e)
        {
            this.spell.OneLevelSpellSpan = (byte)timingOne.Value;
        }

        // Level 2 timing
        private void timingTwoStart_ValueChanged(object sender, EventArgs e)
        {
            this.spell.TwoLevelSpellStartLevel2 = (byte)timingTwoStart.Value;
            if (Index == 6)
                this.spells[7].TwoLevelSpellStartLevel2 = (byte)timingTwoStart.Value;
            if (Index == 7)
                this.spells[6].TwoLevelSpellStartLevel2 = (byte)timingTwoStart.Value;
        }
        private void timingTwoEnd_ValueChanged(object sender, EventArgs e)
        {
            this.spell.TwoLevelSpellEndLevel2 = (byte)timingTwoEnd.Value;
            if (Index == 6)
                this.spells[7].TwoLevelSpellEndLevel2 = (byte)timingTwoEnd.Value;
            if (Index == 7)
                this.spells[6].TwoLevelSpellEndLevel2 = (byte)timingTwoEnd.Value;
        }
        private void timingOneEnd_ValueChanged(object sender, EventArgs e)
        {
            this.spell.TwoLevelSpellEndLevel1 = (byte)timingOneEnd.Value;
            if (Index == 6)
                this.spells[7].TwoLevelSpellEndLevel1 = (byte)timingOneEnd.Value;
            if (Index == 7)
                this.spells[6].TwoLevelSpellEndLevel1 = (byte)timingOneEnd.Value;
        }

        // Charge spell timing
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
        private void timingGeno4Frame_ValueChanged(object sender, EventArgs e)
        {
            this.spells[16].ChargeSpellStartLevel4 = (byte)timingGeno4Frame.Value;
            this.spells[19].ChargeSpellStartLevel4 = (byte)timingGeno4Frame.Value;
            this.spells[20].ChargeSpellStartLevel4 = (byte)timingGeno4Frame.Value;
        }
        private void timingGenoOverflow_ValueChanged(object sender, EventArgs e)
        {
            this.spells[16].ChargeSpellOverflow = (byte)timingGenoOverflow.Value;
            this.spells[19].ChargeSpellOverflow = (byte)timingGenoOverflow.Value;
            this.spells[20].ChargeSpellOverflow = (byte)timingGenoOverflow.Value;
        }

        // Fireball timing
        private void timingFireballSpan_ValueChanged(object sender, EventArgs e)
        {
            this.spell.FireballSpellRange = (byte)timingFireballSpan.Value;
        }
        private void timingFireballMax_ValueChanged(object sender, EventArgs e)
        {
            this.spell.FireballSpellOrbs = (byte)timingFireballMax.Value;
        }

        // Rotation timing
        private void timingRotationStart_ValueChanged(object sender, EventArgs e)
        {
            this.spell.RotationSpellStart = (byte)timingRotationStart.Value;
        }
        private void timingRotationMax_ValueChanged(object sender, EventArgs e)
        {
            this.spell.RotationSpellMax = (byte)timingRotationMax.Value;
        }

        // Multiple instance timing
        private void timingInstanceMax_ValueChanged(object sender, EventArgs e)
        {
            this.spell.MultipleSpellMax = (byte)timingInstanceMax.Value;
        }
        private void timingInstanceNumberName_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.timingInstanceSpan.Value = spell.MultipleSpellRanges[timingInstanceNumber.SelectedIndex];
        }
        private void timingInstanceNumberName_DrawItem(object sender, DrawItemEventArgs e)
        {
            string[] array = Lists.Convert(timingInstanceNumber.Items);
            Do.DrawName(
                sender, e, new BattleDialoguePreview(), array, Fonts.Model.Menu,
                Fonts.Model.Palette_Menu.Palettes[0], 8, 10, 0, 128, false, false, Menus.Model.MenuBG_256x255);
        }
        private void timingInstanceSpan_ValueChanged(object sender, EventArgs e)
        {
            this.spell.MultipleSpellRanges[timingInstanceNumber.SelectedIndex] = (byte)timingInstanceSpan.Value;
        }

        // Rapid spell timing
        private void timingRapid_ValueChanged(object sender, EventArgs e)
        {
            this.spells[11].RapidSpellMax = (byte)timingRapid.Value;
            this.spells[15].RapidSpellMax = (byte)timingRapid.Value;
        }

        #endregion

        #endregion
    }
}
