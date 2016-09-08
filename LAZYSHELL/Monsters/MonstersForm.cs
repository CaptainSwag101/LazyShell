using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LazyShell.Monsters
{
    public partial class MonstersForm : Controls.DockForm
    {
        #region Variables

        // Forms
        private OwnerForm ownerForm;

        // Index
        private int Index
        {
            get { return ownerForm.Index; }
            set { ownerForm.Index = value; }
        }

        // Controls
        private Controls.NewToolStripNumericUpDown num
        {
            get { return ownerForm.Num; }
            set { ownerForm.Num = value; }
        }
        private Controls.NewToolStripComboBox name
        {
            get { return ownerForm.MonsterName; }
            set { ownerForm.MonsterName = value; }
        }
        private ToolStripTextBox nameText
        {
            get { return ownerForm.NameText; }
            set { ownerForm.NameText = value; }
        }

        // Elements
        private Monster monster
        {
            get { return ownerForm.Monster; }
            set { ownerForm.Monster = value; }
        }
        private Monster[] monsters
        {
            get { return ownerForm.Monsters; }
            set { ownerForm.Monsters = value; }
        }
        private bool byteView
        {
            get { return !textView.Checked; }
            set { textView.Checked = !value; }
        }

        // Psychopath
        private Bitmap psychopathBGImage
        {
            get { return Dialogues.Model.TilesetImage; }
        }
        private Bitmap psychopathTextImage;
        private Dialogues.ParserMain parser = Dialogues.ParserMain.Instance;
        private BattleDialoguePreview battleDialoguePreview = new BattleDialoguePreview();
        private Fonts.Glyph[] fontDialogue
        {
            get { return Fonts.Model.Dialogue; }
        }
        private int[] fontPaletteDialogue
        {
            get { return Fonts.Model.Palette_Dialogue.Palettes[1]; }
        }

        #endregion

        // Constructor
        public MonstersForm(OwnerForm ownerForm)
        {
            this.ownerForm = ownerForm;
            //
            InitializeComponent();
            InitializeListControls();
            LoadProperties();
        }

        #region Methods

        // Initialization
        private void InitializeListControls()
        {
            // monster names
            this.name.Items.Clear();
            this.name.Items.AddRange(Model.Names.Names);
            // item names
            this.yoshiCookie.Items.Clear();
            this.yoshiCookie.Items.AddRange(Items.Model.Names.Names);
            this.itemWinA.Items.Clear();
            this.itemWinA.Items.AddRange(Items.Model.Names.Names);
            this.itemWinB.Items.Clear();
            this.itemWinB.Items.AddRange(Items.Model.Names.Names);
        }
        public void LoadProperties()
        {
            if (!this.Updating)
            {
                Cursor.Current = Cursors.WaitCursor;
                this.Updating = true;
                this.name.SelectedIndex = Model.Names.GetSortedIndex(Index);
                this.nameText.Text = Do.RawToASCII(monster.Name, Lists.KeystrokesMenu);
                this.hp.Value = monster.HP;
                this.speed.Value = monster.Speed;
                this.attack.Value = monster.Attack;
                this.mgDefense.Value = monster.MagicDefense;
                this.mgAttack.Value = monster.MagicAttack;
                this.defense.Value = monster.Defense;
                this.mgEvade.Value = monster.MagicEvade;
                this.evade.Value = monster.Evade;
                this.fp.Value = monster.FP;
                this.experience.Value = monster.Experience;
                this.coins.Value = monster.Coins;
                this.flowerOdds.Value = monster.FlowerOdds * 10;
                this.elementNullify.SetItemChecked(0, monster.ElemNullIce);
                this.elementNullify.SetItemChecked(1, monster.ElemNullFire);
                this.elementNullify.SetItemChecked(2, monster.ElemNullThunder);
                this.elementNullify.SetItemChecked(3, monster.ElemNullJump);
                this.specialStatus.SetItemChecked(0, monster.Invincible);
                this.specialStatus.SetItemChecked(1, monster.MortalityProtection);
                this.specialStatus.SetItemChecked(2, monster.DisableAutoDeath);
                this.specialStatus.SetItemChecked(3, monster.Palette2bpp);
                this.effectNullify.SetItemChecked(0, monster.EffectNullMute);
                this.effectNullify.SetItemChecked(1, monster.EffectNullSleep);
                this.effectNullify.SetItemChecked(2, monster.EffectNullPoison);
                this.effectNullify.SetItemChecked(3, monster.EffectNullFear);
                this.effectNullify.SetItemChecked(4, monster.EffectNullMushroom);
                this.effectNullify.SetItemChecked(5, monster.EffectNullScarecrow);
                this.effectNullify.SetItemChecked(6, monster.EffectNullInvincible);
                this.elementWeakness.SetItemChecked(0, monster.ElemWeakIce);
                this.elementWeakness.SetItemChecked(1, monster.ElemWeakFire);
                this.elementWeakness.SetItemChecked(2, monster.ElemWeakThunder);
                this.elementWeakness.SetItemChecked(3, monster.ElemWeakJump);
                this.flowerBonus.SelectedIndex = monster.FlowerBonus;
                this.morphSuccess.SelectedIndex = monster.MorphSuccess;
                this.soundOther.SelectedIndex = monster.OtherSound;
                this.soundStrike.SelectedIndex = monster.StrikeSound;
                this.yoshiCookie.SelectedIndex = Items.Model.Names.GetSortedIndex(monster.YoshiCookie);
                this.itemWinA.SelectedIndex = Items.Model.Names.GetSortedIndex(monster.ItemWinA);
                this.itemWinB.SelectedIndex = Items.Model.Names.GetSortedIndex(monster.ItemWinB);
                //
                this.psychopath.Text = monster.GetPsychopath(byteView);
                this.psychopath_TextChanged(null, null);
                SetFreeBytesLabel();
                SetPsychopathImage();
                //
                this.Updating = false;
                Cursor.Current = Cursors.Arrow;
            }
        }

        //
        private void InsertIntoText(string toInsert)
        {
            char[] newText = new char[psychopath.Text.Length + toInsert.Length];
            psychopath.Text.CopyTo(0, newText, 0, psychopath.SelectionStart);
            toInsert.CopyTo(0, newText, psychopath.SelectionStart, toInsert.Length);
            psychopath.Text.CopyTo(psychopath.SelectionStart, newText, psychopath.SelectionStart + toInsert.Length, this.psychopath.Text.Length - this.psychopath.SelectionStart);
            monster.SetPsychopath(new string(newText), byteView);
            this.psychopath.Text = monster.GetPsychopath(byteView);
        }
        private void SetFreeBytesLabel()
        {
            int freeBytes = Model.FreePsychopathSpace();
            freeBytesLabel.Text = freeBytes + " characters left";
        }
        private void SetPsychopathImage()
        {
            picturePsychopath.BackColor = Color.FromArgb(fontPaletteDialogue[0]);
            picturePsychopath.Invalidate();
            psychopath_TextChanged(null, null);
        }

        #endregion

        #region Event Handlers

        // Vital stats
        private void hp_ValueChanged(object sender, EventArgs e)
        {
            monster.HP = (ushort)hp.Value;
        }
        private void fp_ValueChanged(object sender, EventArgs e)
        {
            monster.FP = (byte)fp.Value;
        }
        private void attack_ValueChanged(object sender, EventArgs e)
        {
            monster.Attack = (byte)attack.Value;
        }
        private void defense_ValueChanged(object sender, EventArgs e)
        {
            monster.Defense = (byte)defense.Value;
        }
        private void mgAttack_ValueChanged(object sender, EventArgs e)
        {
            monster.MagicAttack = (byte)mgAttack.Value;
        }
        private void mgDefense_ValueChanged(object sender, EventArgs e)
        {
            monster.MagicDefense = (byte)mgDefense.Value;
        }
        private void speed_ValueChanged(object sender, EventArgs e)
        {
            monster.Speed = (byte)speed.Value;
        }
        private void evade_ValueChanged(object sender, EventArgs e)
        {
            monster.Evade = (byte)evade.Value;
        }
        private void mgEvade_ValueChanged(object sender, EventArgs e)
        {
            monster.MagicEvade = (byte)mgEvade.Value;
        }

        // Reward stats
        private void experience_ValueChanged(object sender, EventArgs e)
        {
            monster.Experience = (ushort)experience.Value;
        }
        private void coins_ValueChanged(object sender, EventArgs e)
        {
            monster.Coins = (byte)coins.Value;
        }
        private void itemName_DrawItem(object sender, DrawItemEventArgs e)
        {
            Do.DrawName(
                sender, e, new BattleDialoguePreview(), Items.Model.Names, Fonts.Model.Menu,
                Fonts.Model.Palette_Menu.Palettes[0], 8, 10, 0, 128, true, true, Menus.Model.MenuBG_256x255);
        }
        private void itemWinA_SelectedIndexChanged(object sender, EventArgs e)
        {
            monster.ItemWinA = (byte)Items.Model.Names.GetUnsortedIndex(itemWinA.SelectedIndex);
        }
        private void itemWinB_SelectedIndexChanged(object sender, EventArgs e)
        {
            monster.ItemWinB = (byte)Items.Model.Names.GetUnsortedIndex(itemWinB.SelectedIndex);
        }
        private void yoshiCookie_SelectedIndexChanged(object sender, EventArgs e)
        {
            monster.YoshiCookie = (byte)Items.Model.Names.GetUnsortedIndex(yoshiCookie.SelectedIndex);
        }

        // Other properties
        private void morphSuccess_SelectedIndexChanged(object sender, EventArgs e)
        {
            monster.MorphSuccess = (byte)morphSuccess.SelectedIndex;
        }
        private void soundStrike_SelectedIndexChanged(object sender, EventArgs e)
        {
            monster.StrikeSound = (byte)soundStrike.SelectedIndex;
        }
        private void soundOther_SelectedIndexChanged(object sender, EventArgs e)
        {
            monster.OtherSound = (byte)soundOther.SelectedIndex;
        }

        // Effects, elements
        private void effectNullify_SelectedIndexChanged(object sender, EventArgs e)
        {
            monster.EffectNullMute = effectNullify.GetItemChecked(0);
            monster.EffectNullSleep = effectNullify.GetItemChecked(1);
            monster.EffectNullPoison = effectNullify.GetItemChecked(2);
            monster.EffectNullFear = effectNullify.GetItemChecked(3);
            monster.EffectNullMushroom = effectNullify.GetItemChecked(4);
            monster.EffectNullScarecrow = effectNullify.GetItemChecked(5);
            monster.EffectNullInvincible = effectNullify.GetItemChecked(6);
        }
        private void elementWeakness_SelectedIndexChanged(object sender, EventArgs e)
        {
            monster.ElemWeakIce = elementWeakness.GetItemChecked(0);
            monster.ElemWeakFire = elementWeakness.GetItemChecked(1);
            monster.ElemWeakThunder = elementWeakness.GetItemChecked(2);
            monster.ElemWeakJump = elementWeakness.GetItemChecked(3);
        }
        private void elementNullify_SelectedIndexChanged(object sender, EventArgs e)
        {
            monster.ElemNullIce = elementNullify.GetItemChecked(0);
            monster.ElemNullFire = elementNullify.GetItemChecked(1);
            monster.ElemNullThunder = elementNullify.GetItemChecked(2);
            monster.ElemNullJump = elementNullify.GetItemChecked(3);
        }
        private void specialStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            monster.Invincible = specialStatus.GetItemChecked(0);
            monster.MortalityProtection = specialStatus.GetItemChecked(1);
            monster.DisableAutoDeath = specialStatus.GetItemChecked(2);
            monster.Palette2bpp = specialStatus.GetItemChecked(3);
        }
        private void flowerBonus_SelectedIndexChanged(object sender, EventArgs e)
        {
            monster.FlowerBonus = (byte)flowerBonus.SelectedIndex;
        }
        private void flowerOdds_ValueChanged(object sender, EventArgs e)
        {
            if (flowerOdds.Value % 10 != 0)
                flowerOdds.Value = (int)flowerOdds.Value / 10 * 10;
            else
                monster.FlowerOdds = (byte)(flowerOdds.Value / 10);
        }

        // Psychopath
        private void psychopath_TextChanged(object sender, EventArgs e)
        {
            char[] text = psychopath.Text.ToCharArray();
            char[] swap;
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == '\n')
                {
                    int tempSel = psychopath.SelectionStart;
                    swap = new char[text.Length + 2];
                    for (int x = 0; x < i; x++)
                        swap[x] = text[x];
                    swap[i] = '[';
                    swap[i + 1] = '1';
                    swap[i + 2] = ']';
                    for (int x = i + 3; x < swap.Length; x++)
                        swap[x] = text[x - 2];
                    psychopath.Text = new string(swap);
                    text = psychopath.Text.ToCharArray();
                    i += 2;
                    psychopath.SelectionStart = tempSel + 2;
                }
            }
            bool flag = parser.VerifySymbols(this.psychopath.Text.ToCharArray(), byteView);
            if (flag)
            {
                this.psychopath.BackColor = SystemColors.Window;
                monster.SetPsychopath(this.psychopath.Text, byteView);
                if (!monster.PsychopathError)
                {
                    monster.SetPsychopath(psychopath.Text, byteView);
                    int[] pixels = battleDialoguePreview.GetPreview(fontDialogue, fontPaletteDialogue, monster.RawPsychopath, false);
                    psychopathTextImage = Do.PixelsToImage(pixels, 256, 32);
                    picturePsychopath.Invalidate();
                }
            }
            if (!flag || monster.PsychopathError)
                this.psychopath.BackColor = Color.Red;
            SetFreeBytesLabel();
        }
        private void pictureBoxPsychopath_Paint(object sender, PaintEventArgs e)
        {
            if (psychopathBGImage != null)
                e.Graphics.DrawImage(psychopathBGImage, 0, 0);
            if (psychopathTextImage != null)
                e.Graphics.DrawImage(psychopathTextImage, 0, 0);
        }
        private void pageUp_Click(object sender, EventArgs e)
        {
            battleDialoguePreview.PageUp();
            psychopath_TextChanged(null, null);
        }
        private void pageDown_Click(object sender, EventArgs e)
        {
            battleDialoguePreview.PageDown();
            psychopath_TextChanged(null, null);
        }
        private void byteOrTextView_Click(object sender, EventArgs e)
        {
            psychopath.Text = monster.GetPsychopath(byteView);
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
                InsertIntoText("[end]");
        }
        private void pause60f_Click(object sender, EventArgs e)
        {
            if (byteView)
                InsertIntoText("[12]");
            else
                InsertIntoText("[delay]");
        }
        private void pauseA_Click(object sender, EventArgs e)
        {

        }
        private void pauseFrames_Click(object sender, EventArgs e)
        {
            if (byteView)
                InsertIntoText("[3]");
            else
                InsertIntoText("[delayInput]");
        }

        #endregion
    }
}
