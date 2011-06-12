using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Forms;
using LAZYSHELL.Properties;

namespace LAZYSHELL
{
    public partial class Allies : Form
    {
        #region Variables
        private Settings settings = Settings.Default;
        private Character[] characters { get { return Model.Characters; } set { Model.Characters = value; } }
        private Character character { get { return characters[index]; } set { characters[index] = value; } }
        private Slot[] slots { get { return Model.Slots; } set { Model.Slots = value; } }
        private Slot slot { get { return slots[(int)slotNum.Value]; } set { slots[(int)slotNum.Value] = value; } }
        //
        private bool updating = false;
        private int index = 0; public int Index { get { return index; } }
        #endregion
        #region Functions
        public Allies()
        {
            this.settings.KeystrokesMenu[0x20] = "\x20";
            InitializeComponent();
            InitializeStrings();
            RefreshCharacter();
            RefreshSlots();
            this.startingCoins.Value = characters[0].StartingCoins;
            this.startingFrogCoins.Value = characters[0].StartingFrogCoins;
            this.startingCurrentFP.Value = characters[0].StartingCurrentFP;
            this.startingMaximumFP.Value = characters[0].StartingMaximumFP;
            this.lvl1TimingStart.Value = characters[0].DefenseStartLevel1;
            this.lvl2TimingStart.Value = characters[0].DefenseStartLevel2;
            this.lvl2TimingEnd.Value = characters[0].DefenseEndLevel2;
            this.lvl1TimingEnd.Value = characters[0].DefenseEndLevel1;
        }
        private void InitializeStrings()
        {
            updating = true;
            this.characterName.Items.Clear();
            for (int i = 0; i < characters.Length; i++)
                this.characterName.Items.Add(new string(characters[i].Name));
            this.characterName.SelectedIndex = index;

            this.startingMagic.Items.Clear();
            for (int i = 0; i < 32; i++)
                this.startingMagic.Items.Add(new string(Model.Spells[i].Name));

            this.startingWeapon.Items.Clear();
            this.startingWeapon.Items.AddRange(Model.ItemNames.GetNames());
            this.startingAccessory.Items.Clear();
            this.startingAccessory.Items.AddRange(Model.ItemNames.GetNames());
            this.startingArmor.Items.Clear();
            this.startingArmor.Items.AddRange(Model.ItemNames.GetNames());
            this.startingItem.Items.Clear();
            this.startingItem.Items.AddRange(Model.ItemNames.GetNames());
            this.startingSpecialItem.Items.Clear();
            this.startingSpecialItem.Items.AddRange(Model.ItemNames.GetNames());
            this.startingEquipment.Items.Clear();
            this.startingEquipment.Items.AddRange(Model.ItemNames.GetNames());
            updating = false;
        }
        public void RefreshCharacter()
        {
            if (updating) return;
            updating = true;

            this.characterName.SelectedIndex = index;
            this.textBoxCharacterName.Text = Do.RawToASCII(character.Name, settings.KeystrokesMenu);

            this.startingLevel.Value = character.StartingLevel;
            this.startingAttack.Value = character.StartingAttack;
            this.startingDefense.Value = character.StartingDefense;
            this.startingMgAttack.Value = character.StartingMgAttack;
            this.startingMgDefense.Value = character.StartingMgDefense;
            this.startingSpeed.Value = character.StartingSpeed;

            this.startingWeapon.SelectedIndex = Model.ItemNames.GetIndexFromNum(character.StartingWeapon);
            this.startingArmor.SelectedIndex = Model.ItemNames.GetIndexFromNum(character.StartingArmor);
            this.startingAccessory.SelectedIndex = Model.ItemNames.GetIndexFromNum(character.StartingAccessory);

            this.startingExperience.Value = character.StartingExperience;
            this.startingCurrentHP.Value = character.StartingCurrentHP;
            this.startingMaximumHP.Value = character.StartingMaxHP;
            // All selected Magic
            this.startingMagic.SetItemChecked(0, character.Jump);
            this.startingMagic.SetItemChecked(1, character.FireOrb);
            this.startingMagic.SetItemChecked(2, character.SuperJump);
            this.startingMagic.SetItemChecked(3, character.SuperFlame);
            this.startingMagic.SetItemChecked(4, character.UltraJump);
            this.startingMagic.SetItemChecked(5, character.UltraFlame);
            this.startingMagic.SetItemChecked(6, character.Therapy);
            this.startingMagic.SetItemChecked(7, character.GroupHug);
            this.startingMagic.SetItemChecked(8, character.SleepyTime);
            this.startingMagic.SetItemChecked(9, character.ComeBack);
            this.startingMagic.SetItemChecked(10, character.Mute);
            this.startingMagic.SetItemChecked(11, character.PsychBomb);
            this.startingMagic.SetItemChecked(12, character.Terrorize);
            this.startingMagic.SetItemChecked(13, character.PoisonGas);
            this.startingMagic.SetItemChecked(14, character.Crusher);
            this.startingMagic.SetItemChecked(15, character.BowserCrush);
            this.startingMagic.SetItemChecked(16, character.GenoBeam);
            this.startingMagic.SetItemChecked(17, character.GenoBoost);
            this.startingMagic.SetItemChecked(18, character.GenoWhirl);
            this.startingMagic.SetItemChecked(19, character.GenoBlast);
            this.startingMagic.SetItemChecked(20, character.GenoFlash);
            this.startingMagic.SetItemChecked(21, character.Thunderbolt);
            this.startingMagic.SetItemChecked(22, character.HPRain);
            this.startingMagic.SetItemChecked(23, character.Psychopath);
            this.startingMagic.SetItemChecked(24, character.Shocker);
            this.startingMagic.SetItemChecked(25, character.Snowy);
            this.startingMagic.SetItemChecked(26, character.StarRain);
            this.startingMagic.SetItemChecked(27, character.Dummy27);
            this.startingMagic.SetItemChecked(28, character.Dummy28);
            this.startingMagic.SetItemChecked(29, character.Dummy29);
            this.startingMagic.SetItemChecked(30, character.Dummy30);
            this.startingMagic.SetItemChecked(31, character.Dummy31);
            this.characterName.Invalidate();

            updating = false;
        }
        private void RefreshSlots()
        {
            this.startingItem.SelectedIndex = Model.ItemNames.GetIndexFromNum(slot.Item);
            if (this.slotNum.Value <= 14)
            {
                this.startingSpecialItem.Enabled = true;
                this.startingSpecialItem.SelectedIndex = Model.ItemNames.GetIndexFromNum(slot.SpecialItem);
            }
            else
            {
                this.startingSpecialItem.Enabled = false;
                this.startingSpecialItem.SelectedIndex = 0;
            }
            this.startingEquipment.SelectedIndex = Model.ItemNames.GetIndexFromNum(slot.Equipment);
        }
        public void SetToolTips(ToolTip toolTip1)
        {
            // Characters
            this.characterName.ToolTipText =
                "The character to edit by name.\n\n" +
                "The current character selected is the base index for all of \n" +
                "the properties in the \"LEVEL-UPS / START STATS\" tab \n" +
                "except for those in the \"STARTING STATISTICS\" and \n" +
                "\"STARTING ITEMS\" panels.";
            this.textBoxCharacterName.ToolTipText =
                "The character's displayed name in all menus.";
            toolTip1.SetToolTip(this.startingLevel,
                "The initial level of the currently selected character when (s)\n" +
                "he becomes active.");
            toolTip1.SetToolTip(this.startingAttack,
                "The initial attack power of the currently selected character \n" +
                "when (s)he becomes active.");
            toolTip1.SetToolTip(this.startingDefense,
                "The initial defense power of the currently selected \n" +
                "character when (s)he becomes active.");
            toolTip1.SetToolTip(this.startingMgAttack,
                "The initial magic attack power of the currently selected \n" +
                "character when (s)he becomes active.");
            toolTip1.SetToolTip(this.startingMgDefense,
                "The initial magic defense power of the currently selected \n" +
                "character when (s)he becomes active.");
            toolTip1.SetToolTip(this.startingSpeed,
                "The initial speed of the currently selected character when \n" +
                "(s)he becomes active.");
            toolTip1.SetToolTip(this.startingWeapon,
                "The initially equipped weapon of the currently selected \n" +
                "character when (s)he becomes active.");
            toolTip1.SetToolTip(this.startingArmor,
                "The initially equipped armor of the currently selected \n" +
                "character when (s)he becomes active.");
            toolTip1.SetToolTip(this.startingAccessory,
                "The initially equipped accessory of the currently selected \n" +
                "character when (s)he becomes active.");
            toolTip1.SetToolTip(this.startingExperience,
                "The initial experience of the currently selected character \n" +
                "when (s)he becomes active.");
            toolTip1.SetToolTip(this.startingCurrentHP,
                "The initial current HP of the currently selected character \n" +
                "when (s)he becomes active.");
            toolTip1.SetToolTip(this.startingMaximumHP,
                "The initial maximum HP of the currently selected character \n" +
                "when (s)he becomes active.");
            toolTip1.SetToolTip(this.startingMagic,
                "The initial spells known by the currently selected character \n" +
                "when (s)he becomes active.");

            // Starting stats
            toolTip1.SetToolTip(this.startingCoins,
                "The amount of coins in the inventory at the start of a new \n" +
                "game.");
            toolTip1.SetToolTip(this.startingFrogCoins,
                "The amount of frog coins in the inventory at the start of a \n" +
                "new game.");
            toolTip1.SetToolTip(this.startingCurrentFP,
                "The current FP at the start of a new game.");
            toolTip1.SetToolTip(this.startingMaximumFP,
                "The maximum FP at the start of a new game.");
            toolTip1.SetToolTip(this.slotNum,
                "The slot is the \"open slot\" in an inventory to store an item.\n\n" +
                "For example, the equipment and items have 30 slots, \n" +
                "therefore they can store 30 items in slots 0 to 29. By \n" +
                "default, there are actually 29 open slots in the game, due \n" +
                "to the default trash can occupying slot #29).");
            toolTip1.SetToolTip(this.startingItem,
                "The item in the currently selected slot of the item inventory \n" +
                "at the start of a new game.");
            toolTip1.SetToolTip(this.startingSpecialItem,
                "The item in the currently selected slot of the special item \n" +
                "inventory at the start of a new game.");
            toolTip1.SetToolTip(this.startingEquipment,
                "The item in the currently selected slot of the equipment \n" +
                "inventory at the start of a new game.");

            //Timing
            toolTip1.SetToolTip(this.lvl1TimingStart,
                "The frame # from the start of the monster's attack \n" +
                "animation where the level 1 timing begins. This is a highly \n" +
                "relative universal value based on the monster's animation \n" +
                "script.\n" +
                "\n" +
                "The Level 1 timing range is when the player is able to \n" +
                "decrease the damage (for defense) by 50% by pressing an \n" +
                "ABXY button.");
            toolTip1.SetToolTip(this.numericUpDown118,
                toolTip1.GetToolTip(this.lvl1TimingStart));
            toolTip1.SetToolTip(this.lvl2TimingStart,
                "The frame # from the start of the monster's attack \n" +
                "animation where the level 2 timing begins. This is a highly \n" +
                "relative universal value based on the monster's animation \n" +
                "script.\n" +
                "\n" +
                "The Level 2 timing range is when the player is able to \n" +
                "decrease the damage (for defense) by 100% (ie. 0 damage)\n" +
                "by pressing an ABXY button.");
            toolTip1.SetToolTip(this.numericUpDown120,
                toolTip1.GetToolTip(this.lvl2TimingStart));
            toolTip1.SetToolTip(this.lvl2TimingEnd,
                "The frame # from the start of the monster's attack \n" +
                "animation where the level 2 timing ends. This is a highly \n" +
                "relative universal value based on the monster's animation \n" +
                "script.\n" +
                "\n" +
                "The Level 2 timing range is when the player is able to \n" +
                "decrease the damage (for defense) by 100% (ie. 0 damage)\n" +
                "by pressing an ABXY button.");
            toolTip1.SetToolTip(this.numericUpDown117,
                toolTip1.GetToolTip(this.lvl2TimingEnd));
            toolTip1.SetToolTip(this.lvl1TimingEnd,
                "The frame # from the start of the monster's attack \n" +
                "animation where the level 1 timing ends. This is a highly \n" +
                "relative universal value based on the monster's animation \n" +
                "script.\n" +
                "\n" +
                "The Level 1 timing range is when the player is able to \n" +
                "decrease the damage (for defense) by 50% by pressing an\n" +
                "ABXY button.");
            toolTip1.SetToolTip(this.numericUpDown119,
                toolTip1.GetToolTip(this.lvl1TimingEnd));
        }
        #endregion
        #region Event Handlers
        private void characterName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updating) return;
            index = characterName.SelectedIndex;
            RefreshCharacter();
        }
        private void characterName_DrawItem(object sender, DrawItemEventArgs e)
        {
            Do.DrawName(
                sender, e, new BattleDialoguePreview(), Lists.Convert(Model.Characters),
                Model.FontMenu, Model.FontPaletteMenu.Palette, 8, 10, 0, 0, false, false, Model.MenuBackground_);
        }
        private void itemName_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;
            Do.DrawName(
                sender, e, new BattleDialoguePreview(), Model.ItemNames, Model.FontMenu,
                Model.FontPaletteMenu.Palette, 8, 10, 0, 128, true, false, Model.MenuBackground_);
        }
        private void textBoxCharacterName_TextChanged(object sender, EventArgs e)
        {
            if (updating) return;
            character.Name = Do.ASCIIToRaw(textBoxCharacterName.Text, settings.KeystrokesMenu, 10);
            updating = true;
            this.characterName.Items.Clear();
            for (int i = 0; i < characters.Length; i++)
                this.characterName.Items.Add(new string(characters[i].Name));
            this.characterName.SelectedIndex = index;
            updating = false;
        }
        private void textBoxCharacterName_Leave(object sender, EventArgs e)
        {
            InitializeStrings();
        }
        private void startingLevel_ValueChanged(object sender, EventArgs e)
        {
            character.StartingLevel = (byte)this.startingLevel.Value;
        }
        private void startingAttack_ValueChanged(object sender, EventArgs e)
        {
            character.StartingAttack = (byte)this.startingAttack.Value;
        }
        private void startingDefense_ValueChanged(object sender, EventArgs e)
        {
            character.StartingDefense = (byte)this.startingDefense.Value;
        }
        private void startingMgAttack_ValueChanged(object sender, EventArgs e)
        {
            character.StartingMgAttack = (byte)this.startingMgAttack.Value;
        }
        private void startingMgDefense_ValueChanged(object sender, EventArgs e)
        {
            character.StartingMgDefense = (byte)this.startingMgDefense.Value;
        }
        private void startingSpeed_ValueChanged(object sender, EventArgs e)
        {
            character.StartingSpeed = (byte)this.startingSpeed.Value;
        }
        private void startingWeapon_SelectedIndexChanged(object sender, EventArgs e)
        {
            character.StartingWeapon = (byte)Model.ItemNames.GetNumFromIndex(this.startingWeapon.SelectedIndex);
        }
        private void startingArmor_SelectedIndexChanged(object sender, EventArgs e)
        {
            character.StartingArmor = (byte)Model.ItemNames.GetNumFromIndex(this.startingArmor.SelectedIndex);
        }
        private void startingAccessory_SelectedIndexChanged(object sender, EventArgs e)
        {
            character.StartingAccessory = (byte)Model.ItemNames.GetNumFromIndex(this.startingAccessory.SelectedIndex);
        }
        private void startingExperience_ValueChanged(object sender, EventArgs e)
        {
            character.StartingExperience = (ushort)this.startingExperience.Value;
        }
        private void startingCurrentHP_ValueChanged(object sender, EventArgs e)
        {
            character.StartingCurrentHP = (ushort)this.startingCurrentHP.Value;
        }
        private void startingMaximumHP_ValueChanged(object sender, EventArgs e)
        {
            character.StartingMaxHP = (ushort)this.startingMaximumHP.Value;
        }
        private void startingMagic_SelectedIndexChanged(object sender, EventArgs e)
        {
            character.Jump = this.startingMagic.GetItemChecked(0);
            character.FireOrb = this.startingMagic.GetItemChecked(1);
            character.SuperJump = this.startingMagic.GetItemChecked(2);
            character.SuperFlame = this.startingMagic.GetItemChecked(3);
            character.UltraJump = this.startingMagic.GetItemChecked(4);
            character.UltraFlame = this.startingMagic.GetItemChecked(5);
            character.Therapy = this.startingMagic.GetItemChecked(6);
            character.GroupHug = this.startingMagic.GetItemChecked(7);
            character.SleepyTime = this.startingMagic.GetItemChecked(8);
            character.ComeBack = this.startingMagic.GetItemChecked(9);
            character.Mute = this.startingMagic.GetItemChecked(10);
            character.PsychBomb = this.startingMagic.GetItemChecked(11);
            character.Terrorize = this.startingMagic.GetItemChecked(12);
            character.PoisonGas = this.startingMagic.GetItemChecked(13);
            character.Crusher = this.startingMagic.GetItemChecked(14);
            character.BowserCrush = this.startingMagic.GetItemChecked(15);
            character.GenoBeam = this.startingMagic.GetItemChecked(16);
            character.GenoBoost = this.startingMagic.GetItemChecked(17);
            character.GenoWhirl = this.startingMagic.GetItemChecked(18);
            character.GenoBlast = this.startingMagic.GetItemChecked(19);
            character.GenoFlash = this.startingMagic.GetItemChecked(20);
            character.Thunderbolt = this.startingMagic.GetItemChecked(21);
            character.HPRain = this.startingMagic.GetItemChecked(22);
            character.Psychopath = this.startingMagic.GetItemChecked(23);
            character.Shocker = this.startingMagic.GetItemChecked(24);
            character.Snowy = this.startingMagic.GetItemChecked(25);
            character.StarRain = this.startingMagic.GetItemChecked(26);
            character.Dummy27 = this.startingMagic.GetItemChecked(27);
            character.Dummy28 = this.startingMagic.GetItemChecked(28);
            character.Dummy29 = this.startingMagic.GetItemChecked(29);
            character.Dummy30 = this.startingMagic.GetItemChecked(30);
            character.Dummy31 = this.startingMagic.GetItemChecked(31);
        }
        private void startingMagic_DrawItem(object sender, DrawItemEventArgs e)
        {
            Do.DrawName(
                sender, e, new BattleDialoguePreview(), Lists.Convert(Model.Spells, 32, 1),
                Model.FontMenu, Model.FontPaletteMenu.Palette, -8, 10, 0, 0, false, false,
                Model.MenuBackground__(109, 255));
        }
        private void startingCoins_ValueChanged(object sender, EventArgs e)
        {
            characters[0].StartingCoins = (ushort)this.startingCoins.Value;
        }
        private void startingFrogCoins_ValueChanged(object sender, EventArgs e)
        {
            characters[0].StartingFrogCoins = (ushort)this.startingFrogCoins.Value;
        }
        private void startingCurrentFP_ValueChanged(object sender, EventArgs e)
        {
            characters[0].StartingCurrentFP = (byte)this.startingCurrentFP.Value;
        }
        private void startingMaximumFP_ValueChanged(object sender, EventArgs e)
        {
            characters[0].StartingMaximumFP = (byte)this.startingMaximumFP.Value;
        }
        // defense timing
        private void numericUpDown118_ValueChanged(object sender, EventArgs e)
        {
            characters[0].DefenseStartLevel1 = (byte)this.numericUpDown118.Value;
            this.lvl1TimingStart.Value = (int)this.numericUpDown118.Value;
        }
        private void lvl1TimingStart_ValueChanged(object sender, EventArgs e)
        {
            this.numericUpDown118.Value = this.lvl1TimingStart.Value;
        }
        private void numericUpDown120_ValueChanged(object sender, EventArgs e)
        {
            characters[0].DefenseStartLevel2 = (byte)this.numericUpDown120.Value;
            this.lvl2TimingStart.Value = (int)this.numericUpDown120.Value;
        }
        private void lvl2TimingStart_ValueChanged(object sender, EventArgs e)
        {
            this.numericUpDown120.Value = this.lvl2TimingStart.Value;
        }
        private void numericUpDown117_ValueChanged(object sender, EventArgs e)
        {
            characters[0].DefenseEndLevel2 = (byte)this.numericUpDown117.Value;
            this.lvl2TimingEnd.Value = (int)this.numericUpDown117.Value;
        }
        private void lvl2TimingEnd_ValueChanged(object sender, EventArgs e)
        {
            this.numericUpDown117.Value = this.lvl2TimingEnd.Value;
        }
        private void numericUpDown119_ValueChanged(object sender, EventArgs e)
        {
            characters[0].DefenseEndLevel1 = (byte)this.numericUpDown119.Value;
            this.lvl1TimingEnd.Value = (int)this.numericUpDown119.Value;
        }
        private void lvl1TimingEnd_ValueChanged(object sender, EventArgs e)
        {
            this.numericUpDown119.Value = this.lvl1TimingEnd.Value;
        }
        // slots
        private void slotNum_ValueChanged(object sender, EventArgs e)
        {
            RefreshSlots();
        }
        private void startingItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            slot.Item = (byte)Model.ItemNames.GetNumFromIndex(this.startingItem.SelectedIndex);
        }
        private void startingSpecialItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            slot.SpecialItem = (byte)Model.ItemNames.GetNumFromIndex(this.startingSpecialItem.SelectedIndex);
        }
        private void startingEquipment_SelectedIndexChanged(object sender, EventArgs e)
        {
            slot.Equipment = (byte)Model.ItemNames.GetNumFromIndex(this.startingEquipment.SelectedIndex);
        }
        //
        private void reset_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("You're about to undo all changes to the current character. Go ahead with reset?",
                "LAZY SHELL", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
            character = new Character(Model.Data, index);
            characterName_SelectedIndexChanged(null, null);
        }
        #endregion
    }
}
