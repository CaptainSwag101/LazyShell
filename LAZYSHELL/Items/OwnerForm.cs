using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LazyShell.Properties;

namespace LazyShell.Items
{
    public partial class OwnerForm : Controls.NewForm
    {
        #region Variables

        private Settings settings;

        // Index
        public int Index
        {
            get { return (int)num.Value; }
            set { num.Value = value; }
        }

        // Elements
        private Item[] items
        {
            get { return Model.Items; }
            set { Model.Items = value; }
        }
        public Item Item
        {
            get { return items[Index]; }
            set { items[Index] = value; }
        }
        private bool byteView
        {
            get { return !textView.Checked; }
            set { textView.Checked = !value; }
        }

        // Description
        private Bitmap descriptionBGEquip;
        private Bitmap descriptionBGItem;
        private Bitmap descriptionText;
        private MenuDescriptionPreview descriptionPreview;

        // Forms
        private EditLabel editLabelForm;
        private Dialogues.ParserReduced parser;

        #endregion

        // Constructor
        public OwnerForm()
        {
            InitializeComponent();
            InitializeVariables();
            InitializeListControls();
            InitializeNavigators();
            LoadProperties();
            //
            this.History = new History(this, name, num);
        }

        #region Methods

        private void InitializeNavigators()
        {
            this.Updating = true;
            //
            if (settings.RememberLastIndex)
                Index = settings.LastItem;
            //
            this.Updating = false;
        }
        private void InitializeListControls()
        {
            this.Updating = true;
            //
            this.name.Items.Clear();
            this.name.Items.AddRange(Model.Names.Names);
            string[] temp = new string[96];
            for (int i = 0; i < 96; i++)
                temp[i] = i.ToString();
            this.nameIcon.Items.Clear();
            this.nameIcon.Items.AddRange(temp);
            //
            this.name.BackgroundImage = Menus.Model.MenuBG_256x256;
            //
            this.Updating = false;
        }
        private void InitializeVariables()
        {
            settings = Settings.Default;
            descriptionPreview = new MenuDescriptionPreview();
            parser = Dialogues.ParserReduced.Instance;
        }
        private void CreateHelperForms()
        {
            editLabelForm = new EditLabel(name, num, "Items", false);
        }
        public void LoadProperties()
        {
            Cursor.Current = Cursors.WaitCursor;
            if (this.Updating)
                return;
            this.Updating = true;
            this.name.SelectedIndex = Model.Names.GetSortedIndex(Index);
            this.name.Invalidate();
            this.coinValue.Value = Item.Price;
            this.speed.Value = Item.Speed;
            this.attack.Value = Item.Attack;
            this.defense.Value = Item.Defense;
            this.magicAttack.Value = Item.MagicAttack;
            this.magicDefense.Value = Item.MagicDefense;
            this.attackRange.Value = Item.AttackRange;
            this.power.Value = Item.InflictionAmount;
            this.nameIcon.SelectedIndex = (int)(Item.Name[0] - 0x20);
            this.nameIcon.Invalidate();
            this.nameText.Text = Do.RawToASCII(Item.Name, Lists.KeystrokesMenu).Substring(1);
            if (this.num.Value > 0xB0)
            {
                this.description.Text = " This item[1] cannot have a[1] description";
                if (Item.RawDescription == null)
                    this.description_TextChanged(null, null);
                EnableTimingControls(false);
            }
            else
            {
                this.description.Text = Item.GetDescription(byteView);
                EnableTimingControls(true);
            }
            this.statusEffect.SetItemChecked(0, Item.EffectMute);
            this.statusEffect.SetItemChecked(1, Item.EffectSleep);
            this.statusEffect.SetItemChecked(2, Item.EffectPoison);
            this.statusEffect.SetItemChecked(3, Item.EffectFear);
            this.statusEffect.SetItemChecked(4, Item.EffectMushroom);
            this.statusEffect.SetItemChecked(5, Item.EffectScarecrow);
            this.statusEffect.SetItemChecked(6, Item.EffectInvincible);
            this.statusChange.SetItemChecked(0, Item.ChangeAttack);
            this.statusChange.SetItemChecked(1, Item.ChangeDefense);
            this.statusChange.SetItemChecked(2, Item.ChangeMagicAttack);
            this.statusChange.SetItemChecked(3, Item.ChangeMagicDefense);
            this.elemNull.SetItemChecked(0, Item.ElemNullIce);
            this.elemNull.SetItemChecked(1, Item.ElemNullFire);
            this.elemNull.SetItemChecked(2, Item.ElemNullThunder);
            this.elemNull.SetItemChecked(3, Item.ElemNullJump);
            this.elemWeak.SetItemChecked(0, Item.ElemWeakIce);
            this.elemWeak.SetItemChecked(1, Item.ElemWeakFire);
            this.elemWeak.SetItemChecked(2, Item.ElemWeakThunder);
            this.elemWeak.SetItemChecked(3, Item.ElemWeakJump);
            this.whoCanEquip.SetItemChecked(0, Item.EquipMario);
            this.whoCanEquip.SetItemChecked(1, Item.EquipToadstool);
            this.whoCanEquip.SetItemChecked(2, Item.EquipBowser);
            this.whoCanEquip.SetItemChecked(3, Item.EquipGeno);
            this.whoCanEquip.SetItemChecked(4, Item.EquipMallow);
            this.usage.SetItemChecked(0, Item.UsageInstantDeath);
            this.usage.SetItemChecked(1, Item.HideDigits);
            this.usage.SetItemChecked(2, Item.UsageBattleMenu);
            this.usage.SetItemChecked(3, Item.UsageOverworldMenu);
            this.usage.SetItemChecked(4, Item.UsageReusable);
            this.cursorRestoreFP.Checked = Item.RestoreFP;
            this.cursorRestoreHP.Checked = Item.RestoreHP;
            this.targetting.SetItemChecked(0, Item.TargetLiveAlly);
            this.targetting.SetItemChecked(1, Item.TargetEnemy);
            this.targetting.SetItemChecked(2, Item.TargetAll);
            this.targetting.SetItemChecked(3, Item.TargetWoundedOnly);
            this.targetting.SetItemChecked(4, Item.TargetOnePartyOnly);
            this.targetting.SetItemChecked(5, Item.TargetNotSelf);
            this.attackType.SelectedIndex = Item.AttackType;
            this.type.SelectedIndex = Item.ItemType;
            this.function.SelectedIndex = Item.InflictFunction;
            this.elemAttack.SelectedIndex = Item.ElemAttack;
            this.cursor.SelectedIndex = Item.CursorBehavior;
            SetAttackTypeLabels();

            // timing
            EnableTimingControls(Index < 37);
            if (Index < 37)
            {
                this.lvl1TimingStart.Value = Item.WeaponStartLevel1;
                this.lvl2TimingStart.Value = Item.WeaponStartLevel2;
                this.lvl2TimingEnd.Value = Item.WeaponEndLevel2;
                this.lvl1TimingEnd.Value = Item.WeaponEndLevel1;
            }
            this.Updating = false;
            Cursor.Current = Cursors.Arrow;
        }

        // Set controls
        private void SetAttackTypeLabels()
        {
            if (Item.AttackType == 0)
            {
                this.headerLabelEffects.Text = "Effect <INFLICT>";
                this.headerLabelStatus.Text = "Status <UP>";
            }
            else if (Item.AttackType == 1)
            {
                this.headerLabelEffects.Text = "Effect <PROTECT>";
                this.headerLabelStatus.Text = "Status <. . . .>";
            }
            else if (Item.AttackType == 2)
            {
                this.headerLabelEffects.Text = "Effect <NULLIFY>";
                this.headerLabelStatus.Text = "Status <DOWN>";
            }
            else if (Item.AttackType == 3)
            {
                this.headerLabelEffects.Text = "Effect <. . . .>";
                this.headerLabelStatus.Text = "Status <. . . .>";
            }
        }
        private void SetDescriptionImage()
        {
            if (Item.ItemType == 3)
            {
                int[] pixels = descriptionPreview.GetPreview(
                    Fonts.Model.Description, Fonts.Model.Palette_Menu.Palettes[0],
                    Item.RawDescription,
                    new Size(120, 48), new Point(8, 8), 4);
                descriptionText = Do.PixelsToImage(pixels, 120, 48);
                if (descriptionBGEquip == null)
                {
                    int[] bgPixels = Do.ImageToPixels(Menus.Model.MenuBG_256x256);
                    Do.DrawMenuFrame(bgPixels, 256, new Rectangle(0, 0, 15, 6), Menus.Model.Menu_Frame_Graphics, Fonts.Model.Palette_Menu.Palette);
                    descriptionBGEquip = Do.PixelsToImage(bgPixels, 256, 256);
                }
            }
            else
            {
                int[] pixels = descriptionPreview.GetPreview(
                    Fonts.Model.Description, Fonts.Model.Palette_Menu.Palettes[0],
                    Item.RawDescription,
                    new Size(136, 64), new Point(16, 16), 4);
                descriptionText = Do.PixelsToImage(pixels, 136, 64);
                if (descriptionBGItem == null)
                {
                    int[] bgPixels = Do.ImageToPixels(Menus.Model.MenuBG_256x256);
                    Do.DrawMenuFrame(bgPixels, 256, new Rectangle(0, 0, 17, 8), Menus.Model.Menu_Frame_Graphics, Fonts.Model.Palette_Menu.Palette);
                    descriptionBGItem = Do.PixelsToImage(bgPixels, 256, 256);
                }
            }
            pictureDescription.Invalidate();
        }
        private void EnableTimingControls(bool enabled)
        {
            this.lvl1TimingStart.Enabled = enabled;
            this.lvl2TimingStart.Enabled = enabled;
            this.lvl2TimingEnd.Enabled = enabled;
            this.lvl1TimingEnd.Enabled = enabled;
        }

        // Description
        private void InsertIntoText(string toInsert)
        {
            char[] newText = new char[this.description.Text.Length + toInsert.Length];
            description.Text.CopyTo(0, newText, 0, description.SelectionStart);
            toInsert.CopyTo(0, newText, description.SelectionStart, toInsert.Length);
            description.Text.CopyTo(description.SelectionStart, newText, description.SelectionStart + toInsert.Length, this.description.Text.Length - this.description.SelectionStart);
            if (byteView)
                Item.CaretPositionByteView = this.description.SelectionStart + toInsert.Length;
            else
                Item.CaretPositionTextView = this.description.SelectionStart + toInsert.Length;
            Item.SetDescription(new string(newText), byteView);
            description.Text = Item.GetDescription(byteView);
        }

        // Saving
        public void WriteToROM()
        {
            int i;
            int offset = 0x3120;
            int maxOffset = 0x40F1;
            for (i = 0; i < Model.Items.Length; i++)
            {
                int descriptionLength = 0;
                if (Model.Items[i].RawDescription != null)
                    descriptionLength = Magic.Model.Spells[i].RawDescription.Length;
                if (offset + descriptionLength >= maxOffset)
                    break;
                //
                Model.Items[i].WriteToROM(ref offset);
            }
            offset = 0xED44;
            maxOffset = 0xFFFF;
            for (; i < Model.Items.Length; i++)
            {
                int descriptionLength = 0;
                if (Model.Items[i].RawDescription != null)
                    descriptionLength = Magic.Model.Spells[i].RawDescription.Length;
                if (offset + descriptionLength >= maxOffset)
                    break;
                //
                Model.Items[i].WriteToROM(ref offset);
            }
            if (i != Magic.Model.Spells.Length)
                MessageBox.Show("The total size of all item descriptions has exceeded the maximum size. Not all descriptions have been saved.",
                    "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                "Items have not been saved.\n\nWould you like to save changes?",
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
            WriteToROM();
        }
        private void import_Click(object sender, EventArgs e)
        {
            new IOElements(Model.Items, IOMode.Import, Index, "IMPORT ITEMS...").ShowDialog();
            LoadProperties();
        }
        private void export_Click(object sender, EventArgs e)
        {
            new IOElements(Model.Items, IOMode.Export, Index, "EXPORT ITEMS...").ShowDialog();
        }
        private void reset_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("You're about to undo all changes to the current item. Go ahead with reset?",
                "LAZY SHELL", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;
            Item = new Item(Index);
            LoadProperties();
        }
        private void clear_Click(object sender, EventArgs e)
        {
            new ClearElements(Model.Items, Index, "CLEAR ITEMS...").ShowDialog();
            LoadProperties();
        }

        // Navigators
        private void num_ValueChanged(object sender, EventArgs e)
        {
            LoadProperties();
            settings.LastItem = Index;
        }
        private void name_SelectedIndexChanged(object sender, EventArgs e)
        {
            num.Value = Model.Names.GetUnsortedIndex(name.SelectedIndex);
        }
        private void name_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0)
                return;
            Do.DrawName(
                sender, e, new BattleDialoguePreview(), Model.Names, Fonts.Model.Menu,
                Fonts.Model.Palette_Menu.Palettes[0], 8, 10, 0, 128, false, false, Menus.Model.MenuBG_256x255);
        }

        // Name
        private void nameText_TextChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            char[] raw = new char[15];
            char[] temp = Do.ASCIIToRaw(this.nameText.Text, Lists.KeystrokesMenu, 14);
            for (int i = 0; i < 14; i++)
                raw[i + 1] = temp[i];
            raw[0] = (char)(nameIcon.SelectedIndex + 32);
            if (Item.Name != raw)
            {
                Item.Name = raw;
                Model.Names.SetName(
                    Item.Index,
                    new string(Item.Name));
                Model.Names.SortAlphabetically();
                this.name.Items.Clear();
                this.name.Items.AddRange(Model.Names.Names);
                this.name.SelectedIndex = Model.Names.GetSortedIndex(Item.Index);
            }
        }
        private void nameIcon_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            Item.Name[0] = (char)(nameIcon.SelectedIndex + 0x20);
            if (Model.Names.GetUnsortedName(Index).CompareTo(this.nameText.Text) != 0)
            {
                Model.Names.SetName(
                    Item.Index, new string(Item.Name));
                Model.Names.SortAlphabetically();
                this.name.Items.Clear();
                this.name.Items.AddRange(Model.Names.Names);
                this.name.SelectedIndex = Model.Names.GetSortedIndex(Item.Index);
            }
        }
        private void nameIcon_DrawItem(object sender, DrawItemEventArgs e)
        {
            Do.DrawIcon(sender, e, new MenuTextPreview(), 32, Fonts.Model.Menu, Fonts.Model.Palette_Menu.Palettes[0], false, Menus.Model.MenuBG_256x255);
        }

        // Price
        private void coinValue_ValueChanged(object sender, EventArgs e)
        {
            Item.Price = (ushort)this.coinValue.Value;
        }

        // Status
        private void speed_ValueChanged(object sender, EventArgs e)
        {
            Item.Speed = (sbyte)this.speed.Value;
        }
        private void attackRange_ValueChanged(object sender, EventArgs e)
        {
            Item.AttackRange = (byte)this.attackRange.Value;
        }
        private void power_ValueChanged(object sender, EventArgs e)
        {
            Item.InflictionAmount = (byte)this.power.Value;
        }
        private void attack_ValueChanged(object sender, EventArgs e)
        {
            Item.Attack = (sbyte)this.attack.Value;
        }
        private void defense_ValueChanged(object sender, EventArgs e)
        {
            Item.Defense = (sbyte)this.defense.Value;
        }
        private void magicAttack_ValueChanged(object sender, EventArgs e)
        {
            Item.MagicAttack = (sbyte)this.magicAttack.Value;
        }
        private void magicDefense_ValueChanged(object sender, EventArgs e)
        {
            Item.MagicDefense = (sbyte)this.magicDefense.Value;
        }

        // Miscellaneous
        private void type_SelectedIndexChanged(object sender, EventArgs e)
        {
            Item.ItemType = (byte)this.type.SelectedIndex;
        }
        private void attackType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Item.AttackType = (byte)this.attackType.SelectedIndex;
            SetAttackTypeLabels();
        }
        private void usage_SelectedIndexChanged(object sender, EventArgs e)
        {
            Item.UsageInstantDeath = usage.GetItemChecked(0);
            Item.HideDigits = usage.GetItemChecked(1);
            Item.UsageBattleMenu = usage.GetItemChecked(2);
            Item.UsageOverworldMenu = usage.GetItemChecked(3);
            Item.UsageReusable = usage.GetItemChecked(4);
        }
        private void function_SelectedIndexChanged(object sender, EventArgs e)
        {
            Item.InflictFunction = (byte)this.function.SelectedIndex;
        }

        // Status effects
        private void elemAttack_SelectedIndexChanged(object sender, EventArgs e)
        {
            Item.ElemAttack = (byte)this.elemAttack.SelectedIndex;
        }
        private void statusEffect_SelectedIndexChanged(object sender, EventArgs e)
        {
            Item.EffectMute = statusEffect.GetItemChecked(0);
            Item.EffectSleep = statusEffect.GetItemChecked(1);
            Item.EffectPoison = statusEffect.GetItemChecked(2);
            Item.EffectFear = statusEffect.GetItemChecked(3);
            Item.EffectMushroom = statusEffect.GetItemChecked(4);
            Item.EffectScarecrow = statusEffect.GetItemChecked(5);
            Item.EffectInvincible = statusEffect.GetItemChecked(6);
        }
        private void elemNull_SelectedIndexChanged(object sender, EventArgs e)
        {
            Item.ElemNullIce = elemNull.GetItemChecked(0);
            Item.ElemNullFire = elemNull.GetItemChecked(1);
            Item.ElemNullThunder = elemNull.GetItemChecked(2);
            Item.ElemNullJump = elemNull.GetItemChecked(3);
        }
        private void elemWeak_SelectedIndexChanged(object sender, EventArgs e)
        {
            Item.ElemWeakIce = elemWeak.GetItemChecked(0);
            Item.ElemWeakFire = elemWeak.GetItemChecked(1);
            Item.ElemWeakThunder = elemWeak.GetItemChecked(2);
            Item.ElemWeakJump = elemWeak.GetItemChecked(3);
        }
        private void statusChange_SelectedIndexChanged(object sender, EventArgs e)
        {
            Item.ChangeAttack = statusChange.GetItemChecked(0);
            Item.ChangeDefense = statusChange.GetItemChecked(1);
            Item.ChangeMagicAttack = statusChange.GetItemChecked(2);
            Item.ChangeMagicDefense = statusChange.GetItemChecked(3);
        }

        // Who can equip
        private void whoCanEquip_SelectedIndexChanged(object sender, EventArgs e)
        {
            Item.EquipMario = whoCanEquip.GetItemChecked(0);
            Item.EquipToadstool = whoCanEquip.GetItemChecked(1);
            Item.EquipBowser = whoCanEquip.GetItemChecked(2);
            Item.EquipGeno = whoCanEquip.GetItemChecked(3);
            Item.EquipMallow = whoCanEquip.GetItemChecked(4);
        }

        // Targetting
        private void targetting_SelectedIndexChanged(object sender, EventArgs e)
        {
            Item.TargetLiveAlly = targetting.GetItemChecked(0);
            Item.TargetEnemy = targetting.GetItemChecked(1);
            Item.TargetAll = targetting.GetItemChecked(2);
            Item.TargetWoundedOnly = targetting.GetItemChecked(3);
            Item.TargetOnePartyOnly = targetting.GetItemChecked(4);
            Item.TargetNotSelf = targetting.GetItemChecked(5);
        }

        // Cursor
        private void cursor_SelectedIndexChanged(object sender, EventArgs e)
        {
            Item.CursorBehavior = (byte)cursor.SelectedIndex;
        }
        private void cursorRestoreFP_CheckedChanged(object sender, EventArgs e)
        {
            Item.RestoreFP = cursorRestoreFP.Checked;
        }
        private void cursorRestoreHP_CheckedChanged(object sender, EventArgs e)
        {
            Item.RestoreHP = cursorRestoreHP.Checked;
        }

        // Description
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
                this.description.BackColor = System.Drawing.Color.FromArgb(255, 255, 255, 255);
                Item.SetDescription(this.description.Text, byteView);
            }
            if (!flag || Item.DescriptionError)
                this.description.BackColor = System.Drawing.Color.Red;
            SetDescriptionImage();
        }
        private void pictureDescription_Paint(object sender, PaintEventArgs e)
        {
            if (Item.ItemType == 3 && descriptionBGEquip != null)
                e.Graphics.DrawImage(descriptionBGEquip, 0, 0);
            else if (descriptionBGItem != null)
                e.Graphics.DrawImage(descriptionBGItem, 0, 0);
            if (descriptionText == null)
                SetDescriptionImage();
            e.Graphics.DrawImage(descriptionText, 0, 0);
        }
        private void textView_Click(object sender, EventArgs e)
        {
            this.description.Text = Item.GetDescription(byteView);
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

        // Defense timing
        private void lvl1TimingStart_ValueChanged(object sender, EventArgs e)
        {
            Item.WeaponStartLevel1 = (byte)this.lvl1TimingStart.Value;
        }
        private void lvl2TimingStart_ValueChanged(object sender, EventArgs e)
        {
            Item.WeaponStartLevel2 = (byte)this.lvl2TimingStart.Value;
        }
        private void lvl2TimingEnd_ValueChanged(object sender, EventArgs e)
        {
            Item.WeaponEndLevel2 = (byte)this.lvl2TimingEnd.Value;
        }
        private void lvl1TimingEnd_ValueChanged(object sender, EventArgs e)
        {
            Item.WeaponEndLevel1 = (byte)this.lvl1TimingEnd.Value;
        }

        #endregion
    }
}
