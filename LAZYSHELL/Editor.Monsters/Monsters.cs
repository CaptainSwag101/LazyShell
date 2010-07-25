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
        private bool updatingMonsters = false;
        private Model model;
        private Monster[] monsters { get { return model.Monsters; } set { model.Monsters = value; } }
        private Monster monster { get { return monsters[index]; } set { monsters[index] = value; } }
        private FontCharacter[] fontDialogue { get { return model.FontDialogue; } }
        private FontCharacter[] fontMenu { get { return model.FontMenu; } }
        private int[] fontPaletteBattle { get { return model.FontPaletteBattle.Palettes[0]; } }
        private int[] fontPaletteDialogue { get { return model.FontPaletteDialogue.Palettes[1]; } }
        private Bitmap monsterImage;
        private Bitmap psychopathBGImage { get { return model.BattleDialogueTilesetImage; } }
        private Bitmap psychopathTextImage;
        public int index { get { return (int)monsterNum.Value; } set { monsterNum.Value = value; } }
        private bool textCodeFormat { get { return !byteOrTextView.Checked; } set { byteOrTextView.Checked = !value; } }
        private Settings settings = Settings.Default;
        private State state = State.Instance;
        private BattleDialoguePreview battleDialoguePreview = new BattleDialoguePreview();
        private MenuTextPreview menuTextPreview = new MenuTextPreview();
        private bool waitBothCoords = false;
        private bool overTarget = false;
        private TextHelper textHelper = TextHelper.Instance;
        #endregion
        #region Functions
        public Monsters(Model model)
        {
            this.model = model;
            settings.Keystrokes[0x20] = "\x20";
            settings.KeystrokesMenu[0x20] = "\x20";
            InitializeComponent();
            Do.AddShortcut(toolStrip4, Keys.Control | Keys.S, new EventHandler(save_Click));
            Do.AddShortcut(toolStrip4, Keys.F1, helpTips);
            Do.AddShortcut(toolStrip4, Keys.F2, baseConversion);
            toolTip1.InitialDelay = 0;
            InitializeStrings();
            RefreshMonsterTab();
            SetDialogueImages();
            SetToolTips(toolTip1);
            new ToolTipLabel(this, toolTip1, baseConversion, helpTips);
        }
        private void InitializeStrings()
        {
            // monster names
            this.monsterName.Items.Clear();
            this.monsterName.Items.AddRange(model.MonsterNames.Names);
            // item names
            this.MonsterYoshiCookie.Items.Clear();
            this.MonsterYoshiCookie.Items.AddRange(this.model.ItemNames.Names);
            this.ItemWinA.Items.Clear();
            this.ItemWinA.Items.AddRange(this.model.ItemNames.Names);
            this.ItemWinB.Items.Clear();
            this.ItemWinB.Items.AddRange(this.model.ItemNames.Names);
        }
        private void RefreshMonsterTab()
        {
            if (!updatingMonsters)
            {
                Cursor.Current = Cursors.WaitCursor;
                updatingMonsters = true;
                this.monsterName.SelectedIndex = model.MonsterNames.GetIndexFromNum(index);
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
                this.CheckboxMonsterProp.SetItemChecked(1, monster.ProtectAgainstInstantDeath);
                this.CheckboxMonsterProp.SetItemChecked(2, monster.LetBattleScriptRemove);
                this.CheckboxMonsterProp.SetItemChecked(3, monster.UsedByCrystals);
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
                this.MonsterBehavior.SelectedIndex = monster.DeathAnimation;
                this.MonsterEntranceStyle.SelectedIndex = monster.EntranceStyle;
                this.MonsterSoundOther.SelectedIndex = monster.OtherSound;
                this.MonsterSoundStrike.SelectedIndex = monster.StrikeSound;
                this.MonsterYoshiCookie.SelectedIndex = model.ItemNames.GetIndexFromNum(monster.YoshiCookie);
                this.ItemWinA.SelectedIndex = model.ItemNames.GetIndexFromNum(monster.ItemWinA);
                this.ItemWinB.SelectedIndex = model.ItemNames.GetIndexFromNum(monster.ItemWinB);
                this.monsterTargetArrowX.Value = monster.CursorX;
                this.monsterTargetArrowY.Value = monster.CursorY;
                monsterImage = new Bitmap(monster.Image);
                pictureBoxMonster.Invalidate();
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

            toolTip1.SetToolTip(this.monsterTargetArrowX,
                "The number of 8-pixel units the red target arrow is offset\n" +
                "from the right.");
            toolTip1.SetToolTip(this.monsterTargetArrowY,
                "The number of 8-pixel units the red target arrow is offset\n" +
                "from the bottom.");

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
        }
        #endregion
        #region Event Handlers
        private void Monsters_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Monsters have not been saved.\n\nWould you like to save changes?", "LAZY SHELL",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
                Assemble();
            else if (result == DialogResult.No)
            {
                model.Monsters = null;
                model.MonsterNames = null;
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
        }
        private void monsterName_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.monsterNum.Value = model.MonsterNames.GetNumFromIndex(monsterName.SelectedIndex);
        }
        private void monsterName_DrawItem(object sender, DrawItemEventArgs e)
        {
            Do.DrawName(sender, e, menuTextPreview, model.MonsterNames, fontMenu, fontPaletteBattle, true);
        }
        private void TextBoxMonsterName_TextChanged(object sender, EventArgs e)
        {
            if (model.MonsterNames.GetNameByNum(monster.Index).CompareTo(this.TextBoxMonsterName.Text) != 0)
            {
                monster.Name = Do.ASCIIToRaw(this.TextBoxMonsterName.Text, settings.KeystrokesMenu, 13);

                model.MonsterNames.SwapName(
                    monster.Index,
                    new string(monster.Name));
                model.MonsterNames.SortAlpha();

                this.monsterName.Items.Clear();
                this.monsterName.Items.AddRange(model.MonsterNames.GetNames());
                this.monsterName.SelectedIndex = model.MonsterNames.GetIndexFromNum(monster.Index);
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
            Do.DrawName(sender, e, menuTextPreview, model.ItemNames, fontMenu, fontPaletteBattle, true);
        }
        private void ItemWinA_SelectedIndexChanged(object sender, EventArgs e)
        {
            monster.ItemWinA = (byte)model.ItemNames.GetNumFromIndex(ItemWinA.SelectedIndex);
        }
        private void ItemWinB_SelectedIndexChanged(object sender, EventArgs e)
        {
            monster.ItemWinB = (byte)model.ItemNames.GetNumFromIndex(ItemWinB.SelectedIndex);
        }
        private void MonsterYoshiCookie_SelectedIndexChanged(object sender, EventArgs e)
        {
            monster.YoshiCookie = (byte)model.ItemNames.GetNumFromIndex(MonsterYoshiCookie.SelectedIndex);
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
            monster.DeathAnimation = (byte)MonsterBehavior.SelectedIndex;
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
            monster.ProtectAgainstInstantDeath = CheckboxMonsterProp.GetItemChecked(1);
            monster.LetBattleScriptRemove = CheckboxMonsterProp.GetItemChecked(2);
            monster.UsedByCrystals = CheckboxMonsterProp.GetItemChecked(3);
        }
        private void MonsterFlowerBonus_SelectedIndexChanged(object sender, EventArgs e)
        {
            monster.FlowerBonus = (byte)MonsterFlowerBonus.SelectedIndex;
        }
        private void MonsterValFlowerOdds_ValueChanged(object sender, EventArgs e)
        {
            monster.FlowerOdds = (byte)MonsterValFlowerOdds.Value;
        }
        // image
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
            monsterImage = new Bitmap(monster.Image);
            pictureBoxMonster.Invalidate();
        }
        private void pictureBoxMonster_Paint(object sender, PaintEventArgs e)
        {
            if (monsterImage != null)
                e.Graphics.DrawImage(monsterImage, 0, 0);
        }
        private void monsterTargetArrowX_ValueChanged(object sender, EventArgs e)
        {
            monster.CursorX = (byte)monsterTargetArrowX.Value;

            if (waitBothCoords) return;
            monsterImage = new Bitmap(monster.Image);
            pictureBoxMonster.Invalidate();
        }
        private void monsterTargetArrowY_ValueChanged(object sender, EventArgs e)
        {
            monster.CursorY = (byte)monsterTargetArrowY.Value;

            if (waitBothCoords) return;
            monsterImage = new Bitmap(monster.Image);
            pictureBoxMonster.Invalidate();
        }
        private void buttonPreviousFrame_Click(object sender, EventArgs e)
        {
            monster.previousFrame();
            monsterImage = new Bitmap(monster.Image);
            pictureBoxMonster.Invalidate();
        }
        private void buttonNextFrame_Click(object sender, EventArgs e)
        {
            monster.nextFrame();
            monsterImage = new Bitmap(monster.Image);
            pictureBoxMonster.Invalidate();
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
            new IOElements(monsters, index, "IMPORT MONSTERS...", model).ShowDialog();
            RefreshMonsterTab();
        }
        private void export_Click(object sender, EventArgs e)
        {
            new IOElements(monsters, index, "EXPORT MONSTERS...", model).ShowDialog();
        }
        private void clear_Click(object sender, EventArgs e)
        {
            new ClearElements(monsters, index, "CLEAR MONSTERS...").ShowDialog();
            RefreshMonsterTab();
        }
        #endregion
    }
}
