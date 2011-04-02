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
    public partial class Items : Form
    {
        private Settings settings = Settings.Default;
        private bool updating = false;
        private Item[] items { get { return Model.Items; } set { Model.Items = value; } }
        private Item item { get { return items[index]; } set { items[index] = value; } }
        public Item Item { get { return item; } set { item = value; } }
        private int index { get { return (int)itemNum.Value; } set { itemNum.Value = value; } }
        public int Index { get { return index; } set { index = value; } }
        private bool textCodeFormat { get { return !byteOrText.Checked; } set { byteOrText.Checked = !value; } }
        private Bitmap descriptionFrame;
        private Bitmap descriptionText;
        private MenuDescriptionPreview menuDescPreview = new MenuDescriptionPreview();
        private TextHelperReduced textHelper = TextHelperReduced.Instance;
        private Shops shopsEditor;
        public Items(Shops shopsEditor)
        {
            this.shopsEditor = shopsEditor;
            this.settings.KeystrokesMenu[0x20] = "\x20";
            this.settings.KeystrokesDesc[0x20] = "\x20";
            InitializeComponent();
            itemName.BackgroundImage = Model.MenuBackground;
            InitializeStrings();
            RefreshItems();
        }
        private void InitializeStrings()
        {
            this.itemName.Items.Clear();
            this.itemName.Items.AddRange(Model.ItemNames.Names);
            string[] temp = new string[96];
            for (int i = 0; i < 96; i++)
                temp[i] = i.ToString();
            this.itemNameIcon.Items.Clear();
            this.itemNameIcon.Items.AddRange(temp);
        }
        public void RefreshItems()
        {
            Cursor.Current = Cursors.WaitCursor;
            if (updating) return;
            updating = true;
            this.itemName.SelectedIndex = Model.ItemNames.GetIndexFromNum(index);
            this.itemName.Invalidate();
            this.itemCoinValue.Value = item.CoinValue;
            this.itemSpeed.Value = item.Speed;
            this.itemAttack.Value = item.Attack;
            this.itemDefense.Value = item.Defense;
            this.itemMagicAttack.Value = item.MagicAttack;
            this.itemMagicDefense.Value = item.MagicDefense;
            this.itemAttackRange.Value = item.AttackRange;
            this.itemPower.Value = item.InflictionAmount;
            this.itemNameIcon.SelectedIndex = (int)(item.Name[0] - 0x20);
            this.itemNameIcon.Invalidate();
            this.textBoxItemName.Text = Do.RawToASCII(item.Name, settings.KeystrokesMenu).Substring(1);
            if (this.itemNum.Value > 0xB0)
            {
                this.textBoxItemDescription.Text = " This item[1] cannot have a[1] description";
                this.panelItemDesc.Enabled = false;
            }
            else
            {
                this.textBoxItemDescription.Text = item.GetDescription(textCodeFormat);
                this.panelItemDesc.Enabled = true;
            }
            this.itemStatusEffect.SetItemChecked(0, item.EffectMute);
            this.itemStatusEffect.SetItemChecked(1, item.EffectSleep);
            this.itemStatusEffect.SetItemChecked(2, item.EffectPoison);
            this.itemStatusEffect.SetItemChecked(3, item.EffectFear);
            this.itemStatusEffect.SetItemChecked(4, item.EffectMushroom);
            this.itemStatusEffect.SetItemChecked(5, item.EffectScarecrow);
            this.itemStatusEffect.SetItemChecked(6, item.EffectInvincible);
            this.itemStatusChange.SetItemChecked(0, item.ChangeAttack);
            this.itemStatusChange.SetItemChecked(1, item.ChangeDefense);
            this.itemStatusChange.SetItemChecked(2, item.ChangeMagicAttack);
            this.itemStatusChange.SetItemChecked(3, item.ChangeMagicDefense);
            this.itemElemNull.SetItemChecked(0, item.ElemIceNull);
            this.itemElemNull.SetItemChecked(1, item.ElemFireNull);
            this.itemElemNull.SetItemChecked(2, item.ElemThunderNull);
            this.itemElemNull.SetItemChecked(3, item.ElemJumpNull);
            this.itemElemWeak.SetItemChecked(0, item.ElemIceWeak);
            this.itemElemWeak.SetItemChecked(1, item.ElemFireWeak);
            this.itemElemWeak.SetItemChecked(2, item.ElemThunderWeak);
            this.itemElemWeak.SetItemChecked(3, item.ElemJumpWeak);
            this.itemWhoEquip.SetItemChecked(0, item.EquipMario);
            this.itemWhoEquip.SetItemChecked(1, item.EquipToadstool);
            this.itemWhoEquip.SetItemChecked(2, item.EquipBowser);
            this.itemWhoEquip.SetItemChecked(3, item.EquipGeno);
            this.itemWhoEquip.SetItemChecked(4, item.EquipMallow);
            this.itemUsage.SetItemChecked(0, item.UsageInstantDeath);
            this.itemUsage.SetItemChecked(1, item.HideDigits);
            this.itemUsage.SetItemChecked(2, item.UsageBattleMenu);
            this.itemUsage.SetItemChecked(3, item.UsageOverworldMenu);
            this.itemUsage.SetItemChecked(4, item.UsageReusable);
            this.itemCursorRestore.SetItemChecked(0, item.RestoreFP);
            this.itemCursorRestore.SetItemChecked(1, item.RestoreHP);
            this.itemTargetting.SetItemChecked(0, item.TargetLiveAlly);
            this.itemTargetting.SetItemChecked(1, item.TargetEnemy);
            this.itemTargetting.SetItemChecked(2, item.TargetAll);
            this.itemTargetting.SetItemChecked(3, item.TargetWoundedOnly);
            this.itemTargetting.SetItemChecked(4, item.TargetOnePartyOnly);
            this.itemTargetting.SetItemChecked(5, item.TargetNotSelf);
            this.itemAttackType.SelectedIndex = item.AttackType;
            this.itemType.SelectedIndex = item.ItemType;
            this.itemFunction.SelectedIndex = item.InflictFunction;
            this.itemElemAttack.SelectedIndex = item.ElemAttack;
            this.itemCursor.SelectedIndex = item.CursorBehavior;
            UpdateAttackType();
            // timing
            panel1.Visible = index < 37;
            if (index < 37)
            {
                this.lvl1TimingStart.Value = item.WeaponStartLevel1;
                this.lvl2TimingStart.Value = item.WeaponStartLevel2;
                this.lvl2TimingEnd.Value = item.WeaponEndLevel2;
                this.lvl1TimingEnd.Value = item.WeaponEndLevel1;
            }
            updating = false;
            Cursor.Current = Cursors.Arrow;
        }
        private void UpdateAttackType()
        {
            if (item.AttackType == 0)
            {
                this.label101.Text = "EFFECT <INFLICT>";
                this.label99.Text = "STATUS <UP>";
            }
            else if (item.AttackType == 1)
            {
                this.label101.Text = "EFFECT <PROTECT>";
                this.label99.Text = "STATUS <. . . .>";
            }
            else if (item.AttackType == 2)
            {
                this.label101.Text = "EFFECT <NULLIFY>";
                this.label99.Text = "STATUS <DOWN>";
            }
            else if (item.AttackType == 3)
            {
                this.label101.Text = "EFFECT <. . . .>";
                this.label99.Text = "STATUS <. . . .>";
            }
        }
        private void SetDescriptionImage()
        {
            if (item.ItemType == 3)
            {
                int[] pixels = menuDescPreview.GetPreview(
                    Model.FontDescription, Model.FontPaletteMenu.Palette,
                    item.RawDescription,
                    new Size(120, 48), new Point(8, 8), 4);
                descriptionText = new Bitmap(Do.PixelsToImage(pixels, 120, 48));
                descriptionFrame = Do.PixelsToImage(
                    Do.DrawMenuFrame(new Size(15, 6), Model.MenuFrame, Model.MenuFramePalette.Palette), 120, 48);
            }
            else
            {
                int[] pixels = menuDescPreview.GetPreview(
                    Model.FontDescription, Model.FontPaletteMenu.Palette,
                    item.RawDescription,
                    new Size(136, 64), new Point(16, 16), 4);
                descriptionText = new Bitmap(Do.PixelsToImage(pixels, 136, 64));
                descriptionFrame = Do.PixelsToImage(
                    Do.DrawMenuFrame(new Size(17, 8), Model.MenuFrame, Model.MenuFramePalette.Palette), 136, 64);
            }
            pictureBoxItemDesc.Invalidate();
        }
        private void InsertIntoDescriptionText(string toInsert)
        {
            char[] newText = new char[this.textBoxItemDescription.Text.Length + toInsert.Length];

            textBoxItemDescription.Text.CopyTo(0, newText, 0, textBoxItemDescription.SelectionStart);
            toInsert.CopyTo(0, newText, textBoxItemDescription.SelectionStart, toInsert.Length);
            textBoxItemDescription.Text.CopyTo(textBoxItemDescription.SelectionStart, newText, textBoxItemDescription.SelectionStart + toInsert.Length, this.textBoxItemDescription.Text.Length - this.textBoxItemDescription.SelectionStart);

            if (textCodeFormat)
                item.CaretPositionSymbol = this.textBoxItemDescription.SelectionStart + toInsert.Length;
            else
                item.CaretPositionNotSymbol = this.textBoxItemDescription.SelectionStart + toInsert.Length;
            item.SetDescription(new string(newText), textCodeFormat);

            textBoxItemDescription.Text = item.GetDescription(textCodeFormat);
        }
        public void SetToolTips(ToolTip toolTip1)
        {
            //Items
            this.itemNum.ToolTipText =
                "Select the item to edit by #. These properties are applied\n" +
                "to either in-battle usage, overworld usage or both.";
            this.itemName.ToolTipText =
                "Select the item to edit by name. These properties are \n" +
                "applied to either in-battle usage, overworld usage or both.";
            this.textBoxItemName.ToolTipText =
                "The item's displayed name in all menus.";
            this.itemNameIcon.ToolTipText =
                "The item's icon as seen preceding its displayed name in all \n" +
                "menus.";
            toolTip1.SetToolTip(this.itemCoinValue,
                "The amount the item costs in a shop. Final costs varies \n" +
                "depending on the \"Purchase Discounts\" properties of the \n" +
                "shop selling the item. The resale value of the item is exactly \n" +
                "half the \"Coin Value\" (ie. how many coins you receive from \n" +
                "selling it in a shop).\n\n" +
                "NOTE: to make item a \"Special Item\", set coin value to 0.");
            toolTip1.SetToolTip(this.itemSpeed,
                "The wearer's total speed is increased by this amount.\n" +
                "This property is ignored for non-equipment items.");
            toolTip1.SetToolTip(this.itemAttackRange,
                "The attack range is the range of damage, plus and minus\n" +
                "the \"Attack\" value, done to the target. The final damage\n" +
                "will be a random value chosen from the \"Attack\" value plus\n" +
                "and minus the \"Attack Range\" value.\n" +
                "Example: if the \"Attack\" is 50, and the attack range is 25,\n" +
                "the final damage could be anywhere from 25 to 75.\n" +
                "This property is ignored for non-weapon items.");
            toolTip1.SetToolTip(this.itemPower,
                "The exact damage, heal or increment amount inflicted by \n" +
                "an item. This property will heal, damage or increment a \n" +
                "property depending on the value of \"Inflict Function\".\n" +
                "Example: Flower Box has an \"Infliction Amount\" of 5 and an\n" +
                "\"Inflict Function\" of Raise Max FP, which means it \n" +
                "increments the Max FP by 5. Ice Bomb has an \"Infliction\"\n" +
                "\"Amount\" of 140, which means it does 140 base damage.");
            toolTip1.SetToolTip(this.itemAttack,
                "The wearer's total Attack Power is increased by this \n" +
                "amount. This property is ignored for non-equipment items.");
            toolTip1.SetToolTip(this.itemDefense,
                "The wearer's total Defense Power is increased by this \n" +
                "amount. This property is ignored for non-equipment items.");
            toolTip1.SetToolTip(this.itemMagicAttack,
                "The wearer's total Magic Attack Power is increased by this \n" +
                "amount. This property is ignored for non-equipment items.");
            toolTip1.SetToolTip(this.itemMagicDefense,
                "The wearer's total Magic Defense Power is increased by this \n" +
                "amount. This property is ignored for non-equipment items.");
            toolTip1.SetToolTip(this.itemType,
                "The type of item will determine whether the item can be \n" +
                "equipped, what menu inventory it appears in, etc.");
            toolTip1.SetToolTip(this.itemAttackType,
                "The effect type, ie. whether or not the item will inflict, \n" +
                "nullify or protect against (an) effect(s).\n\n" +
                "\"Protection\" should only be used for equipment, such as the \n" +
                "Super Suit which protects against all adverse effects.\n\n" +
                "\"Infliction\" will inflict anything under \"EFFECT\" on the \n" +
                "target, or raise any stats under \"STATS\". Set only for items \n" +
                "that are used in battle.\n\n" +
                "\"Nullification\" will remove the effects under \"EFFECT\" on the \n" +
                "target, or lower the stats under \"STATS\". Set only for items \n" +
                "that are used in battle.\n\n" +
                "If set to {NONE} then anything checked under \"EFFECT\" \n" +
                "and \"STATUS\" is ignored. Likewise, this property is ignored \n" +
                "if nothing under \"EFFECT\" and \"STATUS\" is checked.");
            toolTip1.SetToolTip(this.itemFunction,
                "The inflict function is only used for non-equipment items, \n" +
                "such as the Mushroom which is set to \"Restore HP\" and \n" +
                "Maple Syrup which is set to \"Restore FP\", or the Flower \n" +
                "items that raise the maximum FP are set to \"Raise Max FP\".\n\n" +
                "Some functions read the \"Infliction Amount\" value to \n" +
                "determine how much HP, FP, etc. will be restored/raised.");
            toolTip1.SetToolTip(this.itemElemAttack,
                "The inflict element is only used with items that typically \n" +
                "cause damage to the target. By default, only the Fire and \n" +
                "Ice Bomb items have this set, although any item that can \n" +
                "cause damage will read from this.");
            toolTip1.SetToolTip(this.itemUsage,
                "\"Mortality Protection\" is only used with equipment and \n" +
                "causes all instant death attacks to always miss.\n\n" +
                "\"Hide Battle Numerals\" is only used with items in battle, \n" +
                "typically those that cause 0 or 9999 damage to avoid the\n" +
                "redundant \"0\" or \"9999\" appearing.\n\n" +
                "\"Usable in Battle Menu\" and \"Usable in Overworld Menu\" \n" +
                "indicate whether the item can be used in and/or out of \n" +
                "battle in the menu.\n\n" +
                "\"Reusable\" gives the item infinite usage, eg. the \"Star Egg\" \n" +
                "can be used repeatedly and never run out.\n" +
                "NOTE: the Lucky Jewel can has this set, but the CPU reads \n" +
                "a RAM address to limit the usage to 10 times. That cannot \n" +
                "be changed here.");
            toolTip1.SetToolTip(this.textBoxItemDescription,
                "The item description as it appears in the lower-left corner of \n" +
                "the overworld menu when the cursor is on the item.");
            toolTip1.SetToolTip(this.itemStatusEffect,
                "The effect inflicted, protected against or nullified on a target. \n\n" +
                "Example: Red Essence inflicts Invincible on the target. \n" +
                "Super Suit protects against all effects (except Invincible). \n" +
                "Able Juice nullifies all effects (except Invincible).\n\n" +
                "These properties are used based on the value for \"Effect \n" +
                "Type\".");
            toolTip1.SetToolTip(this.itemElemNull,
                "All attacks with the following checked elemental properties \n" +
                "will always cause 0 damage to the wearer of the item. This \n" +
                "property only applies to equipment.");
            toolTip1.SetToolTip(this.itemElemWeak,
                "All attacks with the following checked elemental properties \n" +
                "will double the damage to the wearer of the item. This \n" +
                "property only applies to equipment.");
            toolTip1.SetToolTip(this.itemStatusChange,
                "The status of a target is either lowered or raised by 50%, \n" +
                "depending on the value for \"Effect Type\". If the value for \n" +
                "\"Effect Type\" is set to \"Infliction\" then the target's stats will \n" +
                "be raised 50%. If \"Effect type is set to \"Nullification\" then \n" +
                "the target's stats will be lowered 50%.\n\n" +
                "Example: Power Blast by default raises the target's Attack \n" +
                "and Magic Attack power by 50% (eg. if the attack and/or \n" +
                "defense power of the target is 100, then it becomes 150). \n" +
                "If the item is equipment, then the wearer's stats (in-battle) \n" +
                "will be raised/lowered 50%. If the item is a usable item in-\n" +
                "battle, then the target's stats will be raised/lowered 50%.");
            toolTip1.SetToolTip(this.itemWhoEquip,
                "Who can equip the item.\n" +
                "Example: Lazy Shell can be equipped by all 5 characters.\n" +
                "This property is ignored by non-equipment items.");
            toolTip1.SetToolTip(this.itemTargetting,
                "\"Other Targets\" will limit the target to a single ally or \n" +
                "enemy. This must NOT be checked with \"Entire Party\".\n\n" +
                "\"Enemy Party\" will allow the spell to target the opposing \n" +
                "party.\n\n" +
                "\"Entire Party\" will cause the spell to target all members of \n" +
                "either the ally party or enemy party. This must NOT be \n" +
                "checked with \"Other Targets\".\n\n" +
                "\"Wounded Only\" will limit the target to wounded members, \n" +
                "ie. members with currently 0 HP.\n\n" +
                "\"One Party Only\" will limit the target to only one party. By \n" +
                "default, all usable spells have this property enabled. \n" +
                "Uncheck at your own risk!\n\n" +
                "\"Not Self\" will limit the target to other allies only, and the \n" +
                "caster is untargettable. By default no spells have this \n" +
                "checked, although the Mushroom item that turns the user \n" +
                "into a mushroom has this property enabled.\n\n" +
                "NOTE: these properties are ignored by items that cannot \n" +
                "be used in battle.");
            toolTip1.SetToolTip(this.itemCursor,
                "The action of the cursor when the item is selected for use in \n" +
                "the overworld menu only.\n" +
                "Example: the Mushroom will direct the cursor to HP (ie. the \n" +
                "HP will be restored) and the Maple Syrup will direct the \n" +
                "cursor to FP (ie. the FP will be restored).");
            toolTip1.SetToolTip(this.itemCursorRestore,
                "\"Restore only if HP less than max\" will restore the HP only if \n" +
                "the target's current HP does not equal the maximum HP.\n" +
                "\"Restore only if FP less than max\" likewise, does similarly \n" +
                "for FP.");
            // weapon timing
            toolTip1.SetToolTip(this.lvl1TimingStart,
                "For WEAPONS:\n" +
                "The frame # from the start of the weapon animation (ie. \n" +
                "the time the character runs up to the target and starts \n" +
                "wielding the weapon) where the level 1 timing begins.\n" +
                "\n" +
                "Example: the default value for Hammer is 8. This means \n" +
                "that if an ABXY button is pressed after 8 frames have \n" +
                "passed from the start of the Hammer animation (ie. when \n" +
                "Mario starts to lift the hammer) the damage is increased by \n" +
                "at least 50%.\n" +
                "\n" +
                "For DEFENSE:\n" +
                "The frame # from the start of the monster's attack \n" +
                "animation where the level 1 timing begins. This is a highly \n" +
                "relative universal value based on the monster's animation \n" +
                "script.\n" +
                "\n" +
                "The Level 1 timing range is when the player is able to \n" +
                "increase the damage (for weapons) or decrease the \n" +
                "damage (for defense) by 50% by pressing an ABXY button.");
            toolTip1.SetToolTip(this.numericUpDown118,
                toolTip1.GetToolTip(this.lvl1TimingStart));
            toolTip1.SetToolTip(this.lvl2TimingStart,
                "For WEAPONS:\n" +
                "The frame # from the start of the weapon animation (ie. \n" +
                "the time the character runs up to the target and starts \n" +
                "wielding the weapon) where the level 2 timing begins.\n" +
                "\n" +
                "Example: the default value for Hammer is 14. This means \n" +
                "that if an ABXY button is pressed after 14 frames have \n" +
                "passed from the start of the Hammer animation (ie. when \n" +
                "Mario starts to lift the hammer) the damage is increased by \n" +
                "at least 100% (ie. doubled).\n" +
                "\n" +
                "For DEFENSE:\n" +
                "The frame # from the start of the monster's attack \n" +
                "animation where the level 2 timing begins. This is a highly \n" +
                "relative universal value based on the monster's animation \n" +
                "script.\n" +
                "\n" +
                "The Level 2 timing range is when the player is able to \n" +
                "increase the damage (for weapons) or decrease the \n" +
                "damage (for defense) by 100% (ie. 0 damage) by pressing \n" +
                "an ABXY button.");
            toolTip1.SetToolTip(this.numericUpDown120,
                toolTip1.GetToolTip(this.lvl2TimingStart));
            toolTip1.SetToolTip(this.lvl2TimingEnd,
                "For WEAPONS:\n" +
                "The frame # from the start of the weapon animation (ie. \n" +
                "the time the character runs up to the target and starts \n" +
                "wielding the weapon) where the level 2 timing ends.\n" +
                "\n" +
                "Example: the default value for Hammer is 20. This means \n" +
                "that if an ABXY button has NOT been pressed after 20 \n" +
                "frames have passed from the start of the Hammer \n" +
                "animation (ie. when Mario starts to lift the hammer) the \n" +
                "opportunity to increase the damage by 100% (ie. doubled) \n" +
                "is gone.\n" +
                "\n" +
                "For DEFENSE:\n" +
                "The frame # from the start of the monster's attack \n" +
                "animation where the level 2 timing ends. This is a highly \n" +
                "relative universal value based on the monster's animation \n" +
                "script.\n" +
                "\n" +
                "The Level 2 timing range is when the player is able to \n" +
                "increase the damage (for weapons) or decrease the \n" +
                "damage (for defense) by 100% (ie. 0 damage) by pressing \n" +
                "an ABXY button.");
            toolTip1.SetToolTip(this.numericUpDown117,
                toolTip1.GetToolTip(this.lvl2TimingEnd));
            toolTip1.SetToolTip(this.lvl1TimingEnd,
                "For WEAPONS:\n" +
                "The frame # from the start of the weapon animation (ie. \n" +
                "the time the character runs up to the target and starts \n" +
                "wielding the weapon) where the level 1 timing ends.\n" +
                "\n" +
                "Example: the default value for Hammer is 38. This means \n" +
                "that if an ABXY button has NOT been pressed after 38 \n" +
                "frames have passed from the start of the Hammer \n" +
                "animation (ie. when Mario starts to lift the hammer) the \n" +
                "opportunity to time the attack for any damage increase is \n" +
                "gone.\n" +
                "\n" +
                "For DEFENSE:\n" +
                "The frame # from the start of the monster's attack \n" +
                "animation where the level 1 timing ends. This is a highly \n" +
                "relative universal value based on the monster's animation \n" +
                "script.\n" +
                "\n" +
                "The Level 1 timing range is when the player is able to \n" +
                "increase the damage (for weapons) or decrease the \n" +
                "damage (for defense) by 50% by pressing an ABXY button.");
            toolTip1.SetToolTip(this.numericUpDown119,
                toolTip1.GetToolTip(this.lvl1TimingEnd));
        }
        #region Event Handlers
        private void itemNum_ValueChanged(object sender, EventArgs e)
        {
            RefreshItems();
        }
        private void itemName_SelectedIndexChanged(object sender, EventArgs e)
        {
            itemNum.Value = Model.ItemNames.GetNumFromIndex(itemName.SelectedIndex);
        }
        private void itemName_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;
            Do.DrawName(
                sender, e, new BattleDialoguePreview(), Model.ItemNames, Model.FontMenu,
                Model.FontPaletteMenu.Palette, 8, 10, 0, 128, false, false, Model.MenuBackground_);
        }
        private void textBoxItemName_TextChanged(object sender, EventArgs e)
        {
            char[] raw = new char[15];
            char[] temp = Do.ASCIIToRaw(this.textBoxItemName.Text, settings.KeystrokesMenu, 14);
            for (int i = 0; i < 14; i++)
                raw[i + 1] = temp[i];
            raw[0] = (char)(itemNameIcon.SelectedIndex + 32);
            if (item.Name != raw)
            {
                item.Name = raw;
                Model.ItemNames.SwapName(
                    item.Index,
                    new string(item.Name));
                Model.ItemNames.SortAlpha();
                this.itemName.Items.Clear();
                this.itemName.Items.AddRange(Model.ItemNames.GetNames());
                this.itemName.SelectedIndex = Model.ItemNames.GetIndexFromNum(item.Index);
                shopsEditor.ResortStrings();
            }
        }
        private void itemNameIcon_SelectedIndexChanged(object sender, EventArgs e)
        {
            item.Name[0] = (char)(itemNameIcon.SelectedIndex + 0x20);
            if (Model.ItemNames.GetNameByNum(index).CompareTo(this.textBoxItemName.Text) != 0)
            {
                Model.ItemNames.SwapName(
                    item.Index, new string(item.Name));
                Model.ItemNames.SortAlpha();
                this.itemName.Items.Clear();
                this.itemName.Items.AddRange(Model.ItemNames.GetNames());
                this.itemName.SelectedIndex = Model.ItemNames.GetIndexFromNum(item.Index);
            }
        }
        private void itemNameIcon_DrawItem(object sender, DrawItemEventArgs e)
        {
            Do.DrawIcon(sender, e, new MenuTextPreview(), 32, Model.FontMenu, Model.FontPaletteMenu.Palette, false, Model.MenuBackground_);
        }
        private void itemCoinValue_ValueChanged(object sender, EventArgs e)
        {
            item.CoinValue = (ushort)this.itemCoinValue.Value;
        }
        private void itemSpeed_ValueChanged(object sender, EventArgs e)
        {
            item.Speed = (sbyte)this.itemSpeed.Value;
        }
        private void itemAttackRange_ValueChanged(object sender, EventArgs e)
        {
            item.AttackRange = (byte)this.itemAttackRange.Value;
        }
        private void itemPower_ValueChanged(object sender, EventArgs e)
        {
            item.InflictionAmount = (byte)this.itemPower.Value;
        }
        private void itemAttack_ValueChanged(object sender, EventArgs e)
        {
            item.Attack = (sbyte)this.itemAttack.Value;
        }
        private void itemDefense_ValueChanged(object sender, EventArgs e)
        {
            item.Defense = (sbyte)this.itemDefense.Value;
        }
        private void itemMagicAttack_ValueChanged(object sender, EventArgs e)
        {
            item.MagicAttack = (sbyte)this.itemMagicAttack.Value;
        }
        private void itemMagicDefense_ValueChanged(object sender, EventArgs e)
        {
            item.MagicDefense = (sbyte)this.itemMagicDefense.Value;
        }
        private void itemType_SelectedIndexChanged(object sender, EventArgs e)
        {
            item.ItemType = (byte)this.itemType.SelectedIndex;
        }
        private void itemAttackType_SelectedIndexChanged(object sender, EventArgs e)
        {
            item.AttackType = (byte)this.itemAttackType.SelectedIndex;
            UpdateAttackType();
        }
        private void itemFunction_SelectedIndexChanged(object sender, EventArgs e)
        {
            item.InflictFunction = (byte)this.itemFunction.SelectedIndex;
        }
        private void itemElemAttack_SelectedIndexChanged(object sender, EventArgs e)
        {
            item.ElemAttack = (byte)this.itemElemAttack.SelectedIndex;
        }
        private void itemUsage_SelectedIndexChanged(object sender, EventArgs e)
        {
            item.UsageInstantDeath = itemUsage.GetItemChecked(0);
            item.HideDigits = itemUsage.GetItemChecked(1);
            item.UsageBattleMenu = itemUsage.GetItemChecked(2);
            item.UsageOverworldMenu = itemUsage.GetItemChecked(3);
            item.UsageReusable = itemUsage.GetItemChecked(4);
        }
        private void itemStatusEffect_SelectedIndexChanged(object sender, EventArgs e)
        {
            item.EffectMute = itemStatusEffect.GetItemChecked(0);
            item.EffectSleep = itemStatusEffect.GetItemChecked(1);
            item.EffectPoison = itemStatusEffect.GetItemChecked(2);
            item.EffectFear = itemStatusEffect.GetItemChecked(3);
            item.EffectMushroom = itemStatusEffect.GetItemChecked(4);
            item.EffectScarecrow = itemStatusEffect.GetItemChecked(5);
            item.EffectInvincible = itemStatusEffect.GetItemChecked(6);

        }
        private void itemElemNull_SelectedIndexChanged(object sender, EventArgs e)
        {
            item.ElemIceNull = itemElemNull.GetItemChecked(0);
            item.ElemFireNull = itemElemNull.GetItemChecked(1);
            item.ElemThunderNull = itemElemNull.GetItemChecked(2);
            item.ElemJumpNull = itemElemNull.GetItemChecked(3);
        }
        private void itemElemWeak_SelectedIndexChanged(object sender, EventArgs e)
        {
            item.ElemIceWeak = itemElemWeak.GetItemChecked(0);
            item.ElemFireWeak = itemElemWeak.GetItemChecked(1);
            item.ElemThunderWeak = itemElemWeak.GetItemChecked(2);
            item.ElemJumpWeak = itemElemWeak.GetItemChecked(3);
        }
        private void itemStatusChange_SelectedIndexChanged(object sender, EventArgs e)
        {
            item.ChangeAttack = itemStatusChange.GetItemChecked(0);
            item.ChangeDefense = itemStatusChange.GetItemChecked(1);
            item.ChangeMagicAttack = itemStatusChange.GetItemChecked(2);
            item.ChangeMagicDefense = itemStatusChange.GetItemChecked(3);
        }
        private void itemWhoEquip_SelectedIndexChanged(object sender, EventArgs e)
        {
            item.EquipMario = itemWhoEquip.GetItemChecked(0);
            item.EquipToadstool = itemWhoEquip.GetItemChecked(1);
            item.EquipBowser = itemWhoEquip.GetItemChecked(2);
            item.EquipGeno = itemWhoEquip.GetItemChecked(3);
            item.EquipMallow = itemWhoEquip.GetItemChecked(4);
        }
        private void itemTargetting_SelectedIndexChanged(object sender, EventArgs e)
        {
            item.TargetLiveAlly = itemTargetting.GetItemChecked(0);
            item.TargetEnemy = itemTargetting.GetItemChecked(1);
            item.TargetAll = itemTargetting.GetItemChecked(2);
            item.TargetWoundedOnly = itemTargetting.GetItemChecked(3);
            item.TargetOnePartyOnly = itemTargetting.GetItemChecked(4);
            item.TargetNotSelf = itemTargetting.GetItemChecked(5);
        }
        private void itemCursor_SelectedIndexChanged(object sender, EventArgs e)
        {
            item.CursorBehavior = (byte)itemCursor.SelectedIndex;
        }
        private void itemCursorRestore_SelectedIndexChanged(object sender, EventArgs e)
        {
            item.RestoreFP = itemCursorRestore.GetItemChecked(0);
            item.RestoreHP = itemCursorRestore.GetItemChecked(1);
        }
        // description
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
                item.SetDescription(this.textBoxItemDescription.Text, textCodeFormat);
            }
            if (!flag || item.DescriptionError)
                this.textBoxItemDescription.BackColor = System.Drawing.Color.Red;
            SetDescriptionImage();
        }
        private void pictureBoxItemDesc_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(Model.MenuBackground, 0, 0);
            if (descriptionText == null)
                SetDescriptionImage();
            e.Graphics.DrawImage(descriptionText, 0, 0);
            if (descriptionFrame == null)
                SetDescriptionImage();
            e.Graphics.DrawImage(descriptionFrame, 0, 0);
        }
        private void byteOrText_Click(object sender, EventArgs e)
        {
            this.textBoxItemDescription.Text = item.GetDescription(textCodeFormat);
        }
        private void newLine_Click(object sender, EventArgs e)
        {
            if (textCodeFormat)
                InsertIntoDescriptionText("[1]");
            else
                InsertIntoDescriptionText("[newLine]");
        }
        private void endString_Click(object sender, EventArgs e)
        {
            if (textCodeFormat)
                InsertIntoDescriptionText("[0]");
            else
                InsertIntoDescriptionText("[endInput]");
        }
        // defense timing
        private void numericUpDown118_ValueChanged(object sender, EventArgs e)
        {
            item.WeaponStartLevel1 = (byte)this.numericUpDown118.Value;
            this.lvl1TimingStart.Value = (int)this.numericUpDown118.Value;
        }
        private void lvl1TimingStart_ValueChanged(object sender, EventArgs e)
        {
            this.numericUpDown118.Value = this.lvl1TimingStart.Value;
        }
        private void numericUpDown120_ValueChanged(object sender, EventArgs e)
        {
            item.WeaponStartLevel2 = (byte)this.numericUpDown120.Value;
            this.lvl2TimingStart.Value = (int)this.numericUpDown120.Value;
        }
        private void lvl2TimingStart_ValueChanged(object sender, EventArgs e)
        {
            this.numericUpDown120.Value = this.lvl2TimingStart.Value;
        }
        private void numericUpDown117_ValueChanged(object sender, EventArgs e)
        {
            item.WeaponEndLevel2 = (byte)this.numericUpDown117.Value;
            this.lvl2TimingEnd.Value = (int)this.numericUpDown117.Value;
        }
        private void lvl2TimingEnd_ValueChanged(object sender, EventArgs e)
        {
            this.numericUpDown117.Value = this.lvl2TimingEnd.Value;
        }
        private void numericUpDown119_ValueChanged(object sender, EventArgs e)
        {
            item.WeaponEndLevel1 = (byte)this.numericUpDown119.Value;
            this.lvl1TimingEnd.Value = (int)this.numericUpDown119.Value;
        }
        private void lvl1TimingEnd_ValueChanged(object sender, EventArgs e)
        {
            this.numericUpDown119.Value = this.lvl1TimingEnd.Value;
        }
        #endregion
    }
}
