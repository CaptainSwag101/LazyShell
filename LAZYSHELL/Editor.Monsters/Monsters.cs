using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using LAZYSHELL.Properties;

namespace LAZYSHELL
{
    public partial class Monsters : Form
    {
        #region Variables
        private long checksum;
        private bool updatingMonsters = false;
        private Monster[] monsters { get { return Model.Monsters; } set { Model.Monsters = value; } }
        private Monster monster { get { return monsters[Index]; } set { monsters[Index] = value; } }
        private FontCharacter[] fontDialogue { get { return Model.FontDialogue; } }
        private FontCharacter[] fontMenu { get { return Model.FontMenu; } }
        private int[] fontPaletteBattle { get { return Model.FontPaletteBattle.Palettes[0]; } }
        private int[] fontPaletteDialogue { get { return Model.FontPaletteDialogue.Palettes[1]; } }
        private Bitmap psychopathBGImage { get { return Model.BattleDialogueTilesetImage; } }
        private Bitmap psychopathTextImage;
        public int Index { get { return (int)monsterNum.Value; } set { monsterNum.Value = value; } }
        private bool textCodeFormat { get { return !byteOrTextView.Checked; } set { byteOrTextView.Checked = !value; } }
        private Settings settings = Settings.Default;
        private State state = State.Instance;
        private BattleDialoguePreview battleDialoguePreview = new BattleDialoguePreview();
        private MenuTextPreview menuTextPreview = new MenuTextPreview();
        private TextHelper textHelper = TextHelper.Instance;
        //
        private BattleScripts battleScriptsEditor;
        #endregion
        #region Functions
        public Monsters()
        {
            settings.Keystrokes[0x20] = "\x20";
            settings.KeystrokesMenu[0x20] = "\x20";
            InitializeComponent();
            Do.AddShortcut(toolStrip4, Keys.Control | Keys.S, new EventHandler(save_Click));
            Do.AddShortcut(toolStrip4, Keys.F1, helpTips);
            Do.AddShortcut(toolStrip4, Keys.F2, baseConversion);
            // create editors
            battleScriptsEditor = new BattleScripts(this);
            battleScriptsEditor.TopLevel = false;
            battleScriptsEditor.Dock = DockStyle.Fill;
            //battleScriptsEditor.SetToolTips(toolTip1);
            panel14.Controls.Add(battleScriptsEditor);
            battleScriptsEditor.BringToFront();
            battleScriptsEditor.Visible = true;

            toolTip1.InitialDelay = 0;
            InitializeStrings();
            RefreshMonsterTab();
            SetDialogueImages();
            SetToolTips(toolTip1);
            new ToolTipLabel(this, toolTip1, baseConversion, helpTips);
            checksum = Do.GenerateChecksum(monsters);
        }
        private void InitializeStrings()
        {
            // monster names
            this.monsterName.Items.Clear();
            this.monsterName.Items.AddRange(Model.MonsterNames.Names);
            // item names
            this.MonsterYoshiCookie.Items.Clear();
            this.MonsterYoshiCookie.Items.AddRange(Model.ItemNames.Names);
            this.ItemWinA.Items.Clear();
            this.ItemWinA.Items.AddRange(Model.ItemNames.Names);
            this.ItemWinB.Items.Clear();
            this.ItemWinB.Items.AddRange(Model.ItemNames.Names);
        }
        private void RefreshMonsterTab()
        {
            if (!updatingMonsters)
            {
                Cursor.Current = Cursors.WaitCursor;
                updatingMonsters = true;
                this.monsterName.SelectedIndex = Model.MonsterNames.GetIndexFromNum(Index);
                this.TextBoxMonsterName.Text = Do.RawToASCII(monster.Name, settings.KeystrokesMenu);
                this.MonsterValHP.Value = monster.HP;
                this.MonsterValSpeed.Value = monster.Speed;
                this.MonsterValAtk.Value = monster.Attack;
                this.MonsterValMgDef.Value = monster.MagicDefense;
                this.MonsterValMgAtk.Value = monster.MagicAttack;
                this.MonsterValDef.Value = monster.Defense;
                this.MonsterValMgEvd.Value = monster.MagicEvadePercent;
                this.MonsterValEvd.Value = monster.EvadePercent;
                this.MonsterValFP.Value = monster.FP;
                this.MonsterValExp.Value = monster.Experience;
                this.MonsterValCoins.Value = monster.Coins;
                this.MonsterValElevation.Value = monster.Elevation;
                this.MonsterValFlowerOdds.Value = monster.FlowerOdds;
                this.TextboxMonsterPsychoMsg.Text = monster.GetPsychoMsg(textCodeFormat);
                this.CheckboxMonsterElemNull.SetItemChecked(0, monster.ElemIceNull);
                this.CheckboxMonsterElemNull.SetItemChecked(1, monster.ElemFireNull);
                this.CheckboxMonsterElemNull.SetItemChecked(2, monster.ElemThunderNull);
                this.CheckboxMonsterElemNull.SetItemChecked(3, monster.ElemJumpNull);
                this.CheckboxMonsterProp.SetItemChecked(0, monster.Invincible);
                this.CheckboxMonsterProp.SetItemChecked(1, monster.MortalityProtection);
                this.CheckboxMonsterProp.SetItemChecked(2, monster.DisableAutoDeath);
                this.CheckboxMonsterProp.SetItemChecked(3, monster.Palette2bpp);
                this.CheckboxMonsterEfecNull.SetItemChecked(0, monster.EffectMuteNull);
                this.CheckboxMonsterEfecNull.SetItemChecked(1, monster.EffectSleepNull);
                this.CheckboxMonsterEfecNull.SetItemChecked(2, monster.EffectPoisonNull);
                this.CheckboxMonsterEfecNull.SetItemChecked(3, monster.EffectFearNull);
                this.CheckboxMonsterEfecNull.SetItemChecked(4, monster.EffectMushroomNull);
                this.CheckboxMonsterEfecNull.SetItemChecked(5, monster.EffectScarecrowNull);
                this.CheckboxMonsterEfecNull.SetItemChecked(6, monster.EffectInvincibleNull);
                this.CheckboxMonsterElemWeak.SetItemChecked(0, monster.ElemIceWeak);
                this.CheckboxMonsterElemWeak.SetItemChecked(1, monster.ElemFireWeak);
                this.CheckboxMonsterElemWeak.SetItemChecked(2, monster.ElemThunderWeak);
                this.CheckboxMonsterElemWeak.SetItemChecked(3, monster.ElemJumpWeak);
                this.MonsterFlowerBonus.SelectedIndex = monster.FlowerBonus;
                this.MonsterMorphSuccess.SelectedIndex = monster.MorphSuccessRate;
                this.MonsterCoinSize.SelectedIndex = monster.CoinSize;
                this.MonsterBehavior.SelectedIndex = monster.SpriteBehavior;
                this.MonsterEntranceStyle.SelectedIndex = monster.EntranceStyle;
                this.MonsterSoundOther.SelectedIndex = monster.OtherSound;
                this.MonsterSoundStrike.SelectedIndex = monster.StrikeSound;
                this.MonsterYoshiCookie.SelectedIndex = Model.ItemNames.GetIndexFromNum(monster.YoshiCookie);
                this.ItemWinA.SelectedIndex = Model.ItemNames.GetIndexFromNum(monster.ItemWinA);
                this.ItemWinB.SelectedIndex = Model.ItemNames.GetIndexFromNum(monster.ItemWinB);
                CalculateFreeSpace();
                updatingMonsters = false;
                Cursor.Current = Cursors.Arrow;
            }
        }
        private void SetDialogueImages()
        {
            pictureBoxPsychopath.BackColor = Color.FromArgb(fontPaletteDialogue[0]);
            pictureBoxPsychopath.Invalidate();
            TextboxMonsterPsychoMsg_TextChanged(null, null);
        }
        private void CalculateFreeSpace()
        {
            int used = 0; int size = 0xb641 + 0x2229;
            for (int i = 0; i < monsters.Length - 1; i++)
            {
                used += monsters[i].RawPsychoMsg.Length;
                if (used + monsters[i].RawPsychoMsg.Length > size)
                {
                    bool test = size >= used + monsters[i].RawPsychoMsg.Length;
                    if (!test)
                    {
                        freeBytes.Text = "Entry " + i++.ToString() + " Too Long - Cannot Save";
                        return;
                    }
                }
            }
            freeBytes.Text = ((double)(size - used)).ToString() + " characters left";
        }
        private void InsertIntoText(string toInsert)
        {
            char[] newText = new char[TextboxMonsterPsychoMsg.Text.Length + toInsert.Length];

            TextboxMonsterPsychoMsg.Text.CopyTo(0, newText, 0, TextboxMonsterPsychoMsg.SelectionStart);
            toInsert.CopyTo(0, newText, TextboxMonsterPsychoMsg.SelectionStart, toInsert.Length);
            TextboxMonsterPsychoMsg.Text.CopyTo(TextboxMonsterPsychoMsg.SelectionStart, newText, TextboxMonsterPsychoMsg.SelectionStart + toInsert.Length, this.TextboxMonsterPsychoMsg.Text.Length - this.TextboxMonsterPsychoMsg.SelectionStart);
            if (textCodeFormat)
                monster.CaretPositionSymbol = this.TextboxMonsterPsychoMsg.SelectionStart + toInsert.Length;
            else
                monster.CaretPositionNotSymbol = this.TextboxMonsterPsychoMsg.SelectionStart + toInsert.Length;
            monster.SetPsychoMsg(new string(newText), textCodeFormat);
            this.TextboxMonsterPsychoMsg.Text = monster.GetPsychoMsg(textCodeFormat);
            if (textCodeFormat)
                this.TextboxMonsterPsychoMsg.SelectionStart = monster.CaretPositionSymbol;
            else
                this.TextboxMonsterPsychoMsg.SelectionStart = monster.CaretPositionNotSymbol;
        }
        private bool FreeSpace(bool message)
        {
            int used = 0; int size = 0xb641 + 0x2229;
            for (int i = 0; i < monsters.Length - 1; i++)
                used += monsters[i].RawPsychoMsg.Length;
            return size - used < 0;
        }
        private void SetToolTips(ToolTip toolTip1)
        {
            this.monsterName.ToolTipText =
                "Select the monster to edit by name. These are all\n" +
                "exclusively in-battle properties.";
            this.monsterNum.ToolTipText =
                "Set the monster to edit by #. These are all exclusively in-\n" +
                "battle properties.";
            this.TextBoxMonsterName.ToolTipText =
                "The monster\'s displayed name when targetted.";

            toolTip1.SetToolTip(this.MonsterValHP,
                "The monster\'s total hit points.");
            toolTip1.SetToolTip(this.MonsterValFP,
                "The monster\'s total flower points.");
            toolTip1.SetToolTip(this.MonsterValAtk,
                "The monster\'s attack power, ie. the base damage caused\n" +
                "by the monster\'s non-magic-based attacks.");
            toolTip1.SetToolTip(this.MonsterValDef,
                "The monster\'s defense power, ie. the amount subtracted\n" +
                "from the base damage of a non-magic-based attack on the\n" +
                "monster.");
            toolTip1.SetToolTip(this.MonsterValMgAtk,
                "The monster\'s magic attack power, ie. the base damage\n" +
                "caused by the monster\'s magic-based attacks.");
            toolTip1.SetToolTip(this.MonsterValMgDef,
                "The monster\'s magic defense power, ie. the amount\n" +
                "subtracted from the base damage of a non-magic-based\n" +
                "attack on the monster.");
            toolTip1.SetToolTip(this.MonsterValSpeed,
                "The monster\'s speed, ie. the monster will have its turn\n" +
                "before anyone else with a lower speed.");
            toolTip1.SetToolTip(this.MonsterValEvd,
                "The monster\'s evade percent, ie. the probability out of 100\n" +
                "a non-magic-based attack on the monster will miss. An\n" +
                "evade% of 100 causes all non-magic-based attacks on the\n" +
                "monster to miss. An evade% of 0 causes all non-magic-\n" +
                "based attacks on the monster to hit. An evade% of 50 is a\n" +
                "50/50 equal chance that a non-magic-based attack on the\n" +
                "monster will miss or hit.");
            toolTip1.SetToolTip(this.MonsterValMgEvd,
                "The monster\'s magic evade percent, ie. the probability out\n" +
                "of 100 a magic-based attack on the monster will miss. An\n" +
                "evade% of 100 causes all magic-based attacks on the\n" +
                "monster to miss. An evade% of 0 causes all magic-based\n" +
                "attacks on the monster to hit. An evade of 50 is a 50/50\n" +
                "equal chance that a magic-based attack on the monster will\n" +
                "miss or hit.");

            toolTip1.SetToolTip(this.MonsterValExp,
                "The total experience gained from the monster when it is\n" +
                "defeated. This is divided evenly among all active party\n" +
                "members, ex. 500 experience points will be divided among\n" +
                "5 active party members as 100 points each.");
            toolTip1.SetToolTip(this.MonsterValCoins,
                "The total coins gained from the monster when it is\n" +
                "defeated.");
            toolTip1.SetToolTip(this.ItemWinA,
                "The item that has only a 5% chance of being won. If the\n" +
                "5% and 25% items are the same, then there is a 100%\n" +
                "chance of the item being won, ie. it is always rewarded.");
            toolTip1.SetToolTip(this.ItemWinB,
                "The item that has a 25% chance of being won. If the 5%\n" +
                "and 25% items are the same, then there is a 100% chance\n" +
                "of the item being won, ie. it is always rewarded.");
            toolTip1.SetToolTip(this.MonsterYoshiCookie,
                "The item rewarded from the successful use of a Yoshi\n" +
                "Cookie on the monster. The probability of a successful use\n" +
                "is determined by the \"Morph Success\" (see below).");

            toolTip1.SetToolTip(this.MonsterMorphSuccess,
                "The success rate of the Yoshi Cookie, Lamb's Lure and\n" +
                "Sheep Attack items. 100% success rate means the item\n" +
                "always works on the monster, 0% means the item never\n" +
                "works on the monster.");
            toolTip1.SetToolTip(this.MonsterCoinSize,
                "The coin that shows when the monster is defeated. This\n" +
                "property is ignored if the \"Sprite Behavior\" includes a \"fade-\n" +
                "out death\".");
            toolTip1.SetToolTip(this.MonsterEntranceStyle,
                "The behavior of the monster's initial animated entrance into\n" +
                "battle. Although it is hardly noticeable, this might offset the\n" +
                "exact initial coordinates of the monster in the formation by\n" +
                "a couple of pixels.");
            toolTip1.SetToolTip(this.MonsterBehavior,
                "The various behaviors of the monster's sprite in battle.\n" +
                "These include the sprite animations for the monster's\n" +
                "death, its floating status, its common attack and defense\n" +
                "animations, and more.");
            toolTip1.SetToolTip(this.MonsterSoundStrike,
                "The sound that plays when the monster does a common\n" +
                "physical attack. Usually, but not always used.");
            toolTip1.SetToolTip(this.MonsterSoundOther,
                "The optional sound that can be used for less common\n" +
                "physical attacks. These options are categorized by specific\n" +
                "monsters, due to their limited usage among all monsters.");
            toolTip1.SetToolTip(this.MonsterValElevation,
                "The number of 16-pixel units a monster is raised above the\n" +
                "ground.");

            toolTip1.SetToolTip(this.CheckboxMonsterEfecNull,
                "The effects that will have no effect if an effect-based\n" +
                "attack is used on the monster, eg. Poison Gas (Poison),\n" +
                "Terrorize (Fear), Bad Mushroom (Poison), etc.");
            toolTip1.SetToolTip(this.CheckboxMonsterElemWeak,
                "The elements that will double the damage done to the\n" +
                "monster by an element-based attack. These refer to magic-\n" +
                "based attacks or items, such as Snowy (Ice) or Fire Bomb\n" +
                "(Fire), eg. Fire Bomb will normally do 120 damage, but if\n" +
                "used on a monster with a weakness for Fire it will double it\n" +
                "to 240.");
            toolTip1.SetToolTip(this.CheckboxMonsterElemNull,
                "The elements that will have no effect if an element-based\n" +
                "attack is used on the monster, eg. Ice Bomb and Snowy will\n" +
                "have no effect on a monster with a nullification of Ice.");
            toolTip1.SetToolTip(this.CheckboxMonsterProp,
                "\"Invincible\" will nullify all damage done to the monster, ie.\n" +
                "all attacks, spells and items used on the monster will yield 0\n" +
                "damage.\n\n" +
                "\"Mortality Protection\" will nullify all instant-death attacks\n" +
                "such as Yoshi Cookie, Lamb's Lure, Geno Whirl, etc.\n\n" +
                "\"Disable Auto-Death\" is for battle-script purposes. If\n" +
                "checked, the monster will not be removed or set as\n" +
                "defeated until manually removed through a battle-script\n" +
                "command.\n\n" +
                "\"Share palette\" is only used by the four crystals and its\n" +
                "actual purpose is unknown.");
            toolTip1.SetToolTip(this.MonsterFlowerBonus,
                "The Flower Bonus rewarded when the monster is defeated,\n" +
                "based on the odds.");
            toolTip1.SetToolTip(this.MonsterValFlowerOdds,
                "The ratio to 15 that the Flower Bonus will be rewarded\n" +
                "when the monster is defeated. A value of 0 completely\n" +
                "disables the flower bonus and a value of 15 indicates a\n" +
                "100% success rate.");

            toolTip1.SetToolTip(this.TextboxMonsterPsychoMsg,
                "The message displayed when the Psychopath spell is used\n" +
                "on the monster.");
        }
        public void Assemble()
        {
            int i = 0;
            ushort len = 0xa1d1;
            for (; i < monsters.Length && len + monsters[i].RawPsychoMsg.Length < 0xb641; i++)
                len += monsters[i].Assemble(len);
            len = 0x1c2a;
            for (; i < monsters.Length && len + monsters[i].RawPsychoMsg.Length < 0x2229; i++)
                len += monsters[i].Assemble(len);
            if (i != monsters.Length)
                System.Windows.Forms.MessageBox.Show(
                    "The allotted space for psychopath dialogues has been exceeded. Not all psychopath dialogues have been saved.",
                    "LAZY SHELL");
            battleScriptsEditor.Assemble();
        }
        #endregion
        #region Event Handlers
        private void Monsters_FormClosing(object sender, FormClosingEventArgs e)
        {
            battleScriptsEditor.Close();
            if (!battleScriptsEditor.IsDisposed)
            {
                e.Cancel = true;
                return;
            }
            if (Do.GenerateChecksum(monsters) == checksum)
                return;
            DialogResult result = MessageBox.Show(
                "Monsters have not been saved.\n\nWould you like to save changes?", "LAZY SHELL",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
                Assemble();
            else if (result == DialogResult.No)
            {
                Model.Monsters = null;
                Model.MonsterNames = null;
                return;
            }
            else if (result == DialogResult.Cancel)
            {
                e.Cancel = true;
                return;
            }
        }
        // main
        private void monsterNum_ValueChanged(object sender, EventArgs e)
        {
            RefreshMonsterTab();
            battleScriptsEditor.InitializeBattleScriptsEditor();
        }
        private void monsterName_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.monsterNum.Value = Model.MonsterNames.GetNumFromIndex(monsterName.SelectedIndex);
        }
        private void monsterName_DrawItem(object sender, DrawItemEventArgs e)
        {
            Do.DrawName(sender, e, menuTextPreview, Model.MonsterNames, fontMenu, fontPaletteBattle, true, Model.MenuBackground_);
        }
        private void TextBoxMonsterName_TextChanged(object sender, EventArgs e)
        {
            if (Model.MonsterNames.GetNameByNum(monster.Index).CompareTo(this.TextBoxMonsterName.Text) != 0)
            {
                monster.Name = Do.ASCIIToRaw(this.TextBoxMonsterName.Text, settings.KeystrokesMenu, 13);

                Model.MonsterNames.SwapName(
                    monster.Index,
                    new string(monster.Name));
                Model.MonsterNames.SortAlpha();

                this.monsterName.Items.Clear();
                this.monsterName.Items.AddRange(Model.MonsterNames.GetNames());
                this.monsterName.SelectedIndex = Model.MonsterNames.GetIndexFromNum(monster.Index);
            }
        }
        // vital stats
        private void MonsterValHP_ValueChanged(object sender, EventArgs e)
        {
            monster.HP = (ushort)MonsterValHP.Value;
        }
        private void MonsterValFP_ValueChanged(object sender, EventArgs e)
        {
            monster.FP = (byte)MonsterValFP.Value;
        }
        private void MonsterValAtk_ValueChanged(object sender, EventArgs e)
        {
            monster.Attack = (byte)MonsterValAtk.Value;
        }
        private void MonsterValDef_ValueChanged(object sender, EventArgs e)
        {
            monster.Defense = (byte)MonsterValDef.Value;
        }
        private void MonsterValMgAtk_ValueChanged(object sender, EventArgs e)
        {
            monster.MagicAttack = (byte)MonsterValMgAtk.Value;
        }
        private void MonsterValMgDef_ValueChanged(object sender, EventArgs e)
        {
            monster.MagicDefense = (byte)MonsterValMgDef.Value;
        }
        private void MonsterValSpeed_ValueChanged(object sender, EventArgs e)
        {
            monster.Speed = (byte)MonsterValSpeed.Value;
        }
        private void MonsterValEvd_ValueChanged(object sender, EventArgs e)
        {
            monster.EvadePercent = (byte)MonsterValEvd.Value;
        }
        private void MonsterValMgEvd_ValueChanged(object sender, EventArgs e)
        {
            monster.MagicEvadePercent = (byte)MonsterValMgEvd.Value;
        }
        // reward stats
        private void MonsterValExp_ValueChanged(object sender, EventArgs e)
        {
            monster.Experience = (ushort)MonsterValExp.Value;
        }
        private void MonsterValCoins_ValueChanged(object sender, EventArgs e)
        {
            monster.Coins = (byte)MonsterValCoins.Value;
        }
        private void itemName_DrawItem(object sender, DrawItemEventArgs e)
        {
            Do.DrawName(
                sender, e, new BattleDialoguePreview(), Model.ItemNames, Model.FontMenu,
                Model.FontPaletteMenu.Palette, 8, 10, 0, 128, true, true, Model.MenuBackground_);
        }
        private void ItemWinA_SelectedIndexChanged(object sender, EventArgs e)
        {
            monster.ItemWinA = (byte)Model.ItemNames.GetNumFromIndex(ItemWinA.SelectedIndex);
        }
        private void ItemWinB_SelectedIndexChanged(object sender, EventArgs e)
        {
            monster.ItemWinB = (byte)Model.ItemNames.GetNumFromIndex(ItemWinB.SelectedIndex);
        }
        private void MonsterYoshiCookie_SelectedIndexChanged(object sender, EventArgs e)
        {
            monster.YoshiCookie = (byte)Model.ItemNames.GetNumFromIndex(MonsterYoshiCookie.SelectedIndex);
        }
        // other properties
        private void MonsterMorphSuccess_SelectedIndexChanged(object sender, EventArgs e)
        {
            monster.MorphSuccessRate = (byte)MonsterMorphSuccess.SelectedIndex;
        }
        private void MonsterCoinSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            monster.CoinSize = (byte)MonsterCoinSize.SelectedIndex;
        }
        private void MonsterEntranceStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            monster.EntranceStyle = (byte)MonsterEntranceStyle.SelectedIndex;
        }
        private void MonsterBehavior_SelectedIndexChanged(object sender, EventArgs e)
        {
            monster.SpriteBehavior = (byte)MonsterBehavior.SelectedIndex;
        }
        private void MonsterSoundStrike_SelectedIndexChanged(object sender, EventArgs e)
        {
            monster.StrikeSound = (byte)MonsterSoundStrike.SelectedIndex;
        }
        private void MonsterSoundOther_SelectedIndexChanged(object sender, EventArgs e)
        {
            monster.OtherSound = (byte)MonsterSoundOther.SelectedIndex;
        }
        private void MonsterValElevation_ValueChanged(object sender, EventArgs e)
        {
            monster.Elevation = (byte)MonsterValElevation.Value;
        }
        // effects, elements
        private void CheckboxMonsterEfecNull_SelectedIndexChanged(object sender, EventArgs e)
        {
            monster.EffectMuteNull = CheckboxMonsterEfecNull.GetItemChecked(0);
            monster.EffectSleepNull = CheckboxMonsterEfecNull.GetItemChecked(1);
            monster.EffectPoisonNull = CheckboxMonsterEfecNull.GetItemChecked(2);
            monster.EffectFearNull = CheckboxMonsterEfecNull.GetItemChecked(3);
            monster.EffectMushroomNull = CheckboxMonsterEfecNull.GetItemChecked(4);
            monster.EffectScarecrowNull = CheckboxMonsterEfecNull.GetItemChecked(5);
            monster.EffectInvincibleNull = CheckboxMonsterEfecNull.GetItemChecked(6);
        }
        private void CheckboxMonsterElemWeak_SelectedIndexChanged(object sender, EventArgs e)
        {
            monster.ElemIceWeak = CheckboxMonsterElemWeak.GetItemChecked(0);
            monster.ElemFireWeak = CheckboxMonsterElemWeak.GetItemChecked(1);
            monster.ElemThunderWeak = CheckboxMonsterElemWeak.GetItemChecked(2);
            monster.ElemJumpWeak = CheckboxMonsterElemWeak.GetItemChecked(3);
        }
        private void CheckboxMonsterElemNull_SelectedIndexChanged(object sender, EventArgs e)
        {
            monster.ElemIceNull = CheckboxMonsterElemNull.GetItemChecked(0);
            monster.ElemFireNull = CheckboxMonsterElemNull.GetItemChecked(1);
            monster.ElemThunderNull = CheckboxMonsterElemNull.GetItemChecked(2);
            monster.ElemJumpNull = CheckboxMonsterElemNull.GetItemChecked(3);
        }
        private void CheckboxMonsterProp_SelectedIndexChanged(object sender, EventArgs e)
        {
            monster.Invincible = CheckboxMonsterProp.GetItemChecked(0);
            monster.MortalityProtection = CheckboxMonsterProp.GetItemChecked(1);
            monster.DisableAutoDeath = CheckboxMonsterProp.GetItemChecked(2);
            monster.Palette2bpp = CheckboxMonsterProp.GetItemChecked(3);
        }
        private void MonsterFlowerBonus_SelectedIndexChanged(object sender, EventArgs e)
        {
            monster.FlowerBonus = (byte)MonsterFlowerBonus.SelectedIndex;
        }
        private void MonsterValFlowerOdds_ValueChanged(object sender, EventArgs e)
        {
            monster.FlowerOdds = (byte)MonsterValFlowerOdds.Value;
        }
        // psychopath dialogue
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
                this.TextboxMonsterPsychoMsg.BackColor = SystemColors.Window;
                monster.SetPsychoMsg(this.TextboxMonsterPsychoMsg.Text, textCodeFormat);

                if (!monster.PsychoMsgError)
                {
                    monster.SetPsychoMsg(TextboxMonsterPsychoMsg.Text, textCodeFormat);
                    int[] pixels = battleDialoguePreview.GetPreview(fontDialogue, fontPaletteDialogue, monster.RawPsychoMsg, false);

                    psychopathTextImage = new Bitmap(Do.PixelsToImage(pixels, 256, 32));
                    pictureBoxPsychopath.Invalidate();
                }
            }
            if (!flag || monster.PsychoMsgError)
                this.TextboxMonsterPsychoMsg.BackColor = Color.Red;
            CalculateFreeSpace();
        }
        private void pageUp_Click(object sender, EventArgs e)
        {
            battleDialoguePreview.PageUp();
            TextboxMonsterPsychoMsg_TextChanged(null, null);
        }
        private void pageDown_Click(object sender, EventArgs e)
        {
            battleDialoguePreview.PageDown(monster.RawPsychoMsg.Length);
            TextboxMonsterPsychoMsg_TextChanged(null, null);
        }
        private void byteOrTextView_Click(object sender, EventArgs e)
        {
            TextboxMonsterPsychoMsg.Text = monster.GetPsychoMsg(textCodeFormat);
        }
        private void newLine_Click(object sender, EventArgs e)
        {
            if (textCodeFormat)
                InsertIntoText("[1]");
            else
                InsertIntoText("[newLine]");
        }
        private void endString_Click(object sender, EventArgs e)
        {
            if (textCodeFormat)
                InsertIntoText("[0]");
            else
                InsertIntoText("[end]");
        }
        private void pause60f_Click(object sender, EventArgs e)
        {
            if (textCodeFormat)
                InsertIntoText("[12]");
            else
                InsertIntoText("[delay]");
        }
        private void pauseA_Click(object sender, EventArgs e)
        {
            if (textCodeFormat)
                InsertIntoText("[2]");
            else
                InsertIntoText("[pauseInput]");
        }
        private void pauseFrames_Click(object sender, EventArgs e)
        {
            if (textCodeFormat)
                InsertIntoText("[3]");
            else
                InsertIntoText("[delayInput]");
        }
        // menustrip
        private void save_Click(object sender, EventArgs e)
        {
            Assemble();
        }
        private void import_Click(object sender, EventArgs e)
        {
            new IOElements(monsters, Index, "IMPORT MONSTERS...").ShowDialog();
            RefreshMonsterTab();
        }
        private void export_Click(object sender, EventArgs e)
        {
            new IOElements(monsters, Index, "EXPORT MONSTERS...").ShowDialog();
        }
        private void clear_Click(object sender, EventArgs e)
        {
            new ClearElements(monsters, Index, "CLEAR MONSTERS...").ShowDialog();
            RefreshMonsterTab();
        }
        #endregion

        private void panel13_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder3D(e.Graphics, panel13.ClientRectangle, Border3DStyle.Raised, Border3DSide.All);
        }

        private void showMonster_Click(object sender, EventArgs e)
        {
            panel13.Visible = !panel13.Visible;
        }

        private void showBattleScripts_Click(object sender, EventArgs e)
        {
            battleScriptsEditor.Visible = !battleScriptsEditor.Visible;
        }

        private void importBattleScriptsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            battleScriptsEditor.Import();
        }
        private void exportBattleScriptsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            battleScriptsEditor.Export();
        }
        private void clearBattleScriptsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            battleScriptsEditor.Clear();
        }

        private delegate void Function();
        private void hackingTools_Click(object sender, EventArgs e)
        {
            new HackingTools(new Function(RefreshMonsterTab)).ShowDialog();
        }

        private void resetCurrentMonsterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("You're about to undo all changes to the current monster. Go ahead with reset?",
                "LAZY SHELL", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
            monster = new Monster(Model.Data, Index);
            monsterNum_ValueChanged(null, null);
        }
        private void resetCurrentBattleScriptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("You're about to undo all changes to the current battle script. Go ahead with reset?",
                "LAZY SHELL", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
            battleScriptsEditor.BattleScript = new LAZYSHELL.ScriptsEditor.BattleScript(Model.Data, battleScriptsEditor.index);
            monsterNum_ValueChanged(null, null);
        }
    }
}
