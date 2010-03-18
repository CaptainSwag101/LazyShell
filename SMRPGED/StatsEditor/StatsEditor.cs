using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using SMRPGED.Properties;

namespace SMRPGED.StatsEditor
{
    public partial class StatsEditor : Form
    {
        /* Aug 3, 2008 updates
         * 
         * STATS
         * 
         * 1. added "updatingFormations" around code in InitializeFormationStrings method
         * because it would call the "formationNameList_SelectedIndexChanged" delegate and update
         * when it shouldn't (it does it later anyways)
         * 
         * 2. also finished the formations tab, the conditionals at the beginning are probably only 
         * necessary for some eventhandlers, but I put them there anyways. it doesn't reflect the
         * code that you've already done for the rest of the stats editor, but it's clean, so if 
         * you're not ok with it then let me know
         * 
         * 3. am thinking of putting zoom and pixel grid options for the formation image (to help with
         * dragging the sprites)
         * 
         * 4. haven't done anything to the formation packs so theyre still unfinished
         * 
         * 5. used paint event to draw psychopath bg and text images and formation image to controls
         * so now everything in all editors uses the paint event
         * 
         * 6. change the code in the levelNum_ValueChanged delegate from:         
         *    statsModel.Characters[(int)this.characterNum.Value].CurrentLevel = (byte)this.levelNum.Value;         
         *    to:         
         *    RefreshCharacterLevel();
         * 
         * 7. added formationSet_SelectedIndexChanged eventhandler for formation packs
         * 
         * 8. created a "RefreshFormationPackStrings" for when changing formation #'s in a formation pack
         * since it only needs to update the textboxes instead of updating the whole pack with 
         * RefreshFormationPacks()
         * 
         * 9. finished the formation packs, changed some code in FormationPack.cs to make it easier
         * to integrate into the controls and eventhandlers
         * 
         * LEVELS
         * 
         * 1. coded the priorities 1 button into the level editor, took like 10min
         * 
         * 2. added a drag/resize for the image graphics and mold image panels in sprites editor.
         * double-click the header label to maximize into window (do it again to reset location/size)
         * 
         * 3. ...same for the battlefield tileset image, you can drag it
         * 
         * 4. ...same thing for the tilesets tab in the level editor, except you can only maximize/minimize
         * 
         * essentially you can maximize the tilesets tabcontrol to make it appear as if the
         * battlefields has its own editor
         * 
         * still left: timing tab
         */

        private byte[] data; public byte[] Data { get { return this.data; } set { this.data = value; } }

        private Model model;
        private StatsModel statsModel;
        private Notes notes;
        private State state;
        private Settings settings;
        private UniversalVariables universal;

        private SMRPGED.Previewer.BattleDialoguePreview battleDialoguePreview;
        private SMRPGED.Previewer.MenuTextPreview menuTextPreview;
        private SMRPGED.Previewer.MenuDescriptionPreview menuDescPreview;
        private TextHelper textHelper;
        private TextHelperReduced textHelperReduced;
        private FontCharacter[] fontCharacters;
        private FontCharacter[] menuCharacters;
        private FontCharacter[] descCharacters;

        private Bitmap menuBGImage;
        private Bitmap menuFrameItemImage;
        private Bitmap menuFrameEquipImage;
        private Bitmap menuFrameSpellImage;

        private bool textCodeFormat = true;

        // gngrglo - these are used with the pictureBoxFormation
        private bool waitBothCoords = false;
        private int overFM = 0;
        private int diffX = 0;
        private int diffY = 0;
        private bool overTarget = false;

        public StatsEditor(Model model)
        {
            this.model = model;
            this.data = model.Data;
            this.notes = Notes.Instance;
            this.state = State.Instance;
            this.settings = Settings.Default;
            this.universal = state.Universal;

            settings.Keystrokes[0x20] = "\x20";
            
            //if (model.StatsModel == null)
            model.CreateStatsModel();
            //if (model.LevelModel == null)
            //    model.CreateLevelModel(); // why do we need the level model?

            this.statsModel = model.StatsModel;

            InitializeComponent();

            foreach (Control c in this.Controls)
            {
                c.MouseMove += new MouseEventHandler(controlMouseMove);
                SetEventHandlers(c);
            }

            SetToolTips();
            LoadNotes(); // Load note packages for window

            InitializeStatsEditor();
        }
        private void SetEventHandlers(Control control)
        {
            foreach (Control c in control.Controls)
            {
                c.MouseMove += new MouseEventHandler(controlMouseMove);
                SetEventHandlers(c);
            }
        }
        public void Assemble()
        {
            if (!model.AssembleStats)
                return;
            if (model.AssembleFinal)
                model.AssembleStats = false;

            SaveNotes();
            this.statsModel.Assemble();
        }
        private void InitializeStatsEditor()
        {
            InitializeStrings();
            InitializeStats();

            this.textHelper = TextHelper.Instance;
            this.textHelperReduced = TextHelperReduced.Instance;
            this.fontCharacters = statsModel.FontCharacters;    // gngrglo - needed for psycho msg
            this.menuCharacters = statsModel.MenuCharacters;
            this.descCharacters = statsModel.DescCharacters;
            this.battleDialoguePreview = new SMRPGED.Previewer.BattleDialoguePreview();
            this.menuTextPreview = new SMRPGED.Previewer.MenuTextPreview();
            this.menuDescPreview = new SMRPGED.Previewer.MenuDescriptionPreview();
            SetDialogueImages();
        }
        private void InitializeStrings()
        {
            InitializeMonsterStrings();
            InitializeFormationStrings();
            InitializeItemStrings();
            InitializeSpellStrings();
            InitializeAttackStrings();
            InitializeShopStrings();
            InitializeCharacterStrings();
            InitializeTimingStrings();
        }
        private void InitializeStats()
        {
            InitializeMonsters();
            InitializeFormations();
            InitializeItems();
            InitializeSpells();
            InitializeAttacks();
            InitializeShops();
            InitializeCharacters();
            InitializeTiming();
        }
        private void SetDialogueImages()
        {
            model.DialogueGraphics = BitManager.GetByteArray(model.Data, 0x3DF000, 0x700);
            model.BattleDialogueTileset = BitManager.GetByteArray(model.Data, 0x015943, 0x100);

            psychopathBGImage = new Bitmap(DrawImageFromIntArr(new BattleDialogueTileset(model, GetFontPalette()).GetTilesetPixelArray(), 256, 32));
            pictureBoxPsychopath.Invalidate();

            model.MenuGraphicSet = model.Decompress(0x3E0E69, 0x2000);
            model.MenuTileset = model.Decompress(0x3E286A, 0x2000);
            model.MenuFrame = model.Decompress(0x3E2607, 0x200);

            menuBGImage = new Bitmap(DrawImageFromIntArr(new MenuTileset(model, GetMenuBGPalette()).GetTilesetPixelArray(), 256, 256));
            menuFrameItemImage = new Bitmap(DrawImageFromIntArr(MenuFramePixels(new Size(15, 6)), 120, 48));
            menuFrameEquipImage = new Bitmap(DrawImageFromIntArr(MenuFramePixels(new Size(17, 8)), 136, 64));
            menuFrameSpellImage = new Bitmap(DrawImageFromIntArr(MenuFramePixels(new Size(15, 8)), 120, 64));
            pictureBoxSpellDesc.Invalidate();
            pictureBoxItemDesc.Invalidate();

            TextboxMonsterPsychoMsg_TextChanged(null, null);
            textBoxSpellDescription_TextChanged(null, null);
            textBoxItemDescription_TextChanged(null, null);
        }
        private void RefreshAll()
        {
            RefreshAttackTab();
            RefreshCharacterTab();
            RefreshFormationTab();
            RefreshItemTab();
            RefreshMonsterTab();
            RefreshShopsTab();
            RefreshSlotsTab();
            RefreshSpellTab();
            RefreshTimingTab();
        }
        #region Stats Editor Window Event Handlers
        private void StatsEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result;

            if (model.AssembleStats)
            {
                result = MessageBox.Show("Would you like to save changes?", "Save and quit Stats Editor?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                    this.statsModel.Assemble();
                else if (result == DialogResult.Cancel)
                {
                    e.Cancel = true;
                    return;
                }

            }
            model.AssembleStats = false;

        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private void saveStatsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statsModel.Assemble();
        }
        private void helpTopicsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = Application.ExecutablePath.Substring(0, Application.ExecutablePath.LastIndexOf('\\') + 1) + "helpTopics\\stats.html";
            try
            {
                System.Diagnostics.Process.Start(path);
            }
            catch
            {
                MessageBox.Show("ERROR: Could not load the stats help file. Visit the homepage and download the help files, or try unzipping the files again.", "ERROR: Could not load help topics.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form about = new About(this);
            about.ShowDialog(this);
        }
        private void importAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = GetDirectoryPath("Select the directory that contains the Battle Scripts to import.");
            if (path != null)
            {
                this.statsModel.ImportAllStats(this.model, path + "\\");
                RefreshAll();
            }
        }
        private void exportAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = GetDirectoryPath("Select the directory that you want to export the Event Scripts to.");
            if (path != null)
            {
                this.Assemble();
                this.statsModel.ExportAllStats(this.model, path);
            }
        }
        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            string tabName = this.tabControl1.TabPages[e.Index].Text;
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Near;
            Font f = new Font(e.Font, FontStyle.Bold);

            SolidBrush s, b;
            if (e.Index == tabControl1.SelectedIndex)
            {
                s = new SolidBrush(SystemColors.ControlDarkDark);
                b = new SolidBrush(SystemColors.Control);
            }
            else
            {
                s = new SolidBrush(Color.FromArgb(236, 232, 224));
                b = new SolidBrush(SystemColors.ControlText);
            }
            Rectangle r = new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height);
            e.Graphics.FillRectangle(s, r);
            r.X += 3; r.Y += 3;
            e.Graphics.DrawString(tabName, f, b, r, sf);
            sf.Dispose();
        }
        #endregion

        private string GetDirectoryPath(string caption)
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();

            folderBrowserDialog1.SelectedPath = settings.LastDirectory;
            folderBrowserDialog1.Description = caption;

            // Display the openFile dialog.
            DialogResult result = folderBrowserDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                settings.LastDirectory = folderBrowserDialog1.SelectedPath;
                return folderBrowserDialog1.SelectedPath;
            }
            else
                return null;
        }
        private string SelectFile(string title, string filter)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = settings.LastRomPath;
            openFileDialog1.Title = title;
            openFileDialog1.Filter = filter;
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() != DialogResult.Cancel)
                return openFileDialog1.FileName;
            return null;
        }
        private void LoadNotes()
        {
            if (!notes.GetLoadNotes())
            {
                return;
            }
            try
            {
                // note packages to load
                this.monsterNotesTextBox.LoadFile(notes.GetPath() + "main-stats-monsters.rtf");
                this.richTextBox8.LoadFile(notes.GetPath() + "main-stats-formations.rtf");
                this.richTextBox9.LoadFile(notes.GetPath() + "main-stats-spells.rtf");
                this.textBoxAttackNotes.LoadFile(notes.GetPath() + "main-stats-attacks.rtf");

            }
            catch
            {


                if (MessageBox.Show("Could not load notes for this ROM, would you like to create a set of notes for it?\nThis will not overwrite any existing notes", "Create Notes?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (notes.CreateNoteSet())
                        LoadNotes();
                }
                else
                {
                    notes.SetLoadNotes(false);
                }

            }
        }
        private void SaveNotes()
        {
            if (notes.GetLoadNotes())
            {
                SaveAttackNotes();
                SaveFormationNotes();
                SaveMonsterNotes();
                SaveSpellNotes();
            }
        }
        private Bitmap DrawImageFromIntArr(int[] arr, int width, int height)
        {
            Bitmap image = null;

            unsafe
            {
                fixed (void* firstPixel = &arr[0])
                {
                    IntPtr ip = new IntPtr(firstPixel);
                    if (image != null)
                        image.Dispose();
                    image = new Bitmap(width, height, width * 4, System.Drawing.Imaging.PixelFormat.Format32bppPArgb, ip);

                }
            }

            return image;
        }
        private int[] GetFontPalette()
        {
            int[] palette = new int[16];
            double multiplier = 8; // 8;
            ushort color = 0;
            int r, g, b;

            for (int i = 0; i < 16; i++) // 16 colors in palette
            {
                color = BitManager.GetShort(data, i * 2 + 0x3DFF00);

                r = (byte)((color % 0x20) * multiplier);
                g = (byte)(((color >> 5) % 0x20) * multiplier);
                b = (byte)(((color >> 10) % 0x20) * multiplier);

                palette[i] = Color.FromArgb(r, g, b).ToArgb();
            }
            return palette;
        }
        private int[] GetMenuBGPalette()
        {
            int[] palette = new int[16];
            ushort color = 0;
            int r, g, b;

            for (int i = 0; i < 16; i++) // 16 colors in palette
            {
                color = BitManager.GetShort(data, i * 2 + 0x3E9A28);

                r = (byte)((color % 0x20) * 8);
                g = (byte)(((color >> 5) % 0x20) * 8);
                b = (byte)(((color >> 10) % 0x20) * 8);

                palette[i] = Color.FromArgb(r, g, b).ToArgb();
            }
            return palette;
        }

        private void SetToolTips()
        {
            this.toolTip1.InitialDelay = 0;
            //this.toolTip1.Popup += new PopupEventHandler(toolTip1_Popup);

            this.toolTip1.SetToolTip(this.monsterName,
                "Select the monster to edit by name. These are all\n" +
                "exclusively in-battle properties.");
            this.toolTip1.SetToolTip(this.MonsterNumber,
                "Set the monster to edit by #. These are all exclusively in-\n" +
                "battle properties.");
            this.toolTip1.SetToolTip(this.TextboxMonsterName,
                "The monster\'s displayed name when targetted.");

            this.toolTip1.SetToolTip(this.MonsterValHP,
                "The monster\'s total hit points.");
            this.toolTip1.SetToolTip(this.MonsterValFP,
                "The monster\'s total flower points.");
            this.toolTip1.SetToolTip(this.MonsterValAtk,
                "The monster\'s attack power, ie. the base damage caused\n" +
                "by the monster\'s non-magic-based attacks.");
            this.toolTip1.SetToolTip(this.MonsterValDef,
                "The monster\'s defense power, ie. the amount subtracted\n" +
                "from the base damage of a non-magic-based attack on the\n" +
                "monster.");
            this.toolTip1.SetToolTip(this.MonsterValMgAtk,
                "The monster\'s magic attack power, ie. the base damage\n" +
                "caused by the monster\'s magic-based attacks.");
            this.toolTip1.SetToolTip(this.MonsterValMgDef,
                "The monster\'s magic defense power, ie. the amount\n" +
                "subtracted from the base damage of a non-magic-based\n" +
                "attack on the monster.");
            this.toolTip1.SetToolTip(this.MonsterValSpeed,
                "The monster\'s speed, ie. the monster will have its turn\n" +
                "before anyone else with a lower speed.");
            this.toolTip1.SetToolTip(this.MonsterValEvd,
                "The monster\'s evade percent, ie. the probability out of 100\n" +
                "a non-magic-based attack on the monster will miss. An\n" +
                "evade% of 100 causes all non-magic-based attacks on the\n" +
                "monster to miss. An evade% of 0 causes all non-magic-\n" +
                "based attacks on the monster to hit. An evade% of 50 is a\n" +
                "50/50 equal chance that a non-magic-based attack on the\n" +
                "monster will miss or hit.");
            this.toolTip1.SetToolTip(this.MonsterValMgEvd,
                "The monster\'s magic evade percent, ie. the probability out\n" +
                "of 100 a magic-based attack on the monster will miss. An\n" +
                "evade% of 100 causes all magic-based attacks on the\n" +
                "monster to miss. An evade% of 0 causes all magic-based\n" +
                "attacks on the monster to hit. An evade of 50 is a 50/50\n" +
                "equal chance that a magic-based attack on the monster will\n" +
                "miss or hit.");

            this.toolTip1.SetToolTip(this.MonsterValExp,
                "The total experience gained from the monster when it is\n" +
                "defeated. This is divided evenly among all active party\n" +
                "members, ex. 500 experience points will be divided among\n" +
                "5 active party members as 100 points each.");
            this.toolTip1.SetToolTip(this.MonsterValCoins,
                "The total coins gained from the monster when it is\n" +
                "defeated.");
            this.toolTip1.SetToolTip(this.ItemWinA,
                "The item that has only a 5% chance of being won. If the\n" +
                "5% and 25% items are the same, then there is a 100%\n" +
                "chance of the item being won, ie. it is always rewarded.");
            this.toolTip1.SetToolTip(this.ItemWinB,
                "The item that has a 25% chance of being won. If the 5%\n" +
                "and 25% items are the same, then there is a 100% chance\n" +
                "of the item being won, ie. it is always rewarded.");
            this.toolTip1.SetToolTip(this.MonsterYoshiCookie,
                "The item rewarded from the successful use of a Yoshi\n" +
                "Cookie on the monster. The probability of a successful use\n" +
                "is determined by the \"Morph Success\" (see below).");

            this.toolTip1.SetToolTip(this.MonsterMorphSuccess,
                "The success rate of the Yoshi Cookie, Lamb's Lure and\n" +
                "Sheep Attack items. 100% success rate means the item\n" +
                "always works on the monster, 0% means the item never\n" +
                "works on the monster.");
            this.toolTip1.SetToolTip(this.MonsterCoinSize,
                "The coin that shows when the monster is defeated. This\n" +
                "property is ignored if the \"Sprite Behavior\" includes a \"fade-\n" +
                "out death\".");
            this.toolTip1.SetToolTip(this.MonsterEntranceStyle,
                "The behavior of the monster's initial animated entrance into\n" +
                "battle. Although it is hardly noticeable, this might offset the\n" +
                "exact initial coordinates of the monster in the formation by\n" +
                "a couple of pixels.");
            this.toolTip1.SetToolTip(this.MonsterBehavior,
                "The various behaviors of the monster's sprite in battle.\n" +
                "These include the sprite animations for the monster's\n" +
                "death, its floating status, its common attack and defense\n" +
                "animations, and more.");
            this.toolTip1.SetToolTip(this.MonsterSoundStrike,
                "The sound that plays when the monster does a common\n" +
                "physical attack. Usually, but not always used.");
            this.toolTip1.SetToolTip(this.MonsterSoundOther,
                "The optional sound that can be used for less common\n" +
                "physical attacks. These options are categorized by specific\n" +
                "monsters, due to their limited usage among all monsters.");
            this.toolTip1.SetToolTip(this.MonsterValElevation,
                "The number of 16-pixel units a monster is raised above the\n" +
                "ground.");

            this.toolTip1.SetToolTip(this.CheckboxMonsterEfecNull,
                "The effects that will have no effect if an effect-based\n" +
                "attack is used on the monster, eg. Poison Gas (Poison),\n" +
                "Terrorize (Fear), Bad Mushroom (Poison), etc.");
            this.toolTip1.SetToolTip(this.CheckboxMonsterElemWeak,
                "The elements that will double the damage done to the\n" +
                "monster by an element-based attack. These refer to magic-\n" +
                "based attacks or items, such as Snowy (Ice) or Fire Bomb\n" +
                "(Fire), eg. Fire Bomb will normally do 120 damage, but if\n" +
                "used on a monster with a weakness for Fire it will double it\n" +
                "to 240.");
            this.toolTip1.SetToolTip(this.CheckboxMonsterElemNull,
                "The elements that will have no effect if an element-based\n" +
                "attack is used on the monster, eg. Ice Bomb and Snowy will\n" +
                "have no effect on a monster with a nullification of Ice.");
            this.toolTip1.SetToolTip(this.CheckboxMonsterProp,
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
            this.toolTip1.SetToolTip(this.MonsterFlowerBonus,
                "The Flower Bonus rewarded when the monster is defeated,\n" +
                "based on the odds.");
            this.toolTip1.SetToolTip(this.MonsterValFlowerOdds,
                "The ratio to 15 that the Flower Bonus will be rewarded\n" +
                "when the monster is defeated. A value of 0 completely\n" +
                "disables the flower bonus and a value of 15 indicates a\n" +
                "100% success rate.");

            this.toolTip1.SetToolTip(this.monsterTargetArrowX,
                "The number of 8-pixel units the red target arrow is offset\n" +
                "from the right.");
            this.toolTip1.SetToolTip(this.monsterTargetArrowY,
                "The number of 8-pixel units the red target arrow is offset\n" +
                "from the bottom.");

            this.toolTip1.SetToolTip(this.TextboxMonsterPsychoMsg,
                "The message displayed when the Psychopath spell is used\n" +
                "on the monster.");
            this.toolTip1.SetToolTip(this.listBox3,
                "\"End string\" will terminate the string from the place it is\n" +
                "inserted and onward. All psychopath messages must have\n" +
                "a [0] (the \"End string\" value) at the end. Any characters or\n" +
                "values following a [0] will not be displayed.\n\n" +
                "\"New line\" will create a break and start a new line.\n" +
                "Generally preceded by a [2] (the \"Pause (A)\" value).\n\n" +
                "\"Pause (A)\" will pause the message and wait for a button\n" +
                "press to continue the message.\n\n" +
                "\"Delay (A)\" will pause the message until either exactly 1\n" +
                "second has passed or a button is pressed.\n\n" +
                "\"Delay\" will pause the message for exactly 1 second.");

            // FORMATIONS
            this.toolTip1.SetToolTip(this.formationNameList,
                "Select the formation to edit.\n\n" +
                "A formation is a set of monsters encountered in battle. A\n" +
                "formation is chosen when a battle is called through either\n" +
                "an event script or through the property of an NPC in a\n" +
                "level.");
            this.toolTip1.SetToolTip(this.formationNum,
                "Select the formation to edit by #.\n\n" +
                "A formation is a set of monsters encountered in battle. A\n" +
                "formation is chosen when a battle is called through either\n" +
                "an event script or through the property of an NPC in a\n" +
                "level.");

            this.toolTip1.SetToolTip(this.formationByte1,
                "The 1st monster in the formation by #.");
            this.toolTip1.SetToolTip(this.formationName1,
                "The 1st monster in the formation by name.");
            this.toolTip1.SetToolTip(this.formationCoordX1,
                "The 1st monster's X coordinate in the formation.");
            this.toolTip1.SetToolTip(this.formationCoordY1,
                "The 1st monster's Y coordinate in the formation.");
            this.toolTip1.SetToolTip(this.formationByte2,
                "The 2nd monster in the formation by #.");
            this.toolTip1.SetToolTip(this.formationName2,
                "The 2nd monster in the formation by name.");
            this.toolTip1.SetToolTip(this.formationCoordX2,
                "The 2nd monster's X coordinate in the formation.");
            this.toolTip1.SetToolTip(this.formationCoordY2,
                "The 2nd monster's Y coordinate in the formation.");
            this.toolTip1.SetToolTip(this.formationByte3,
                "The 3rd monster in the formation by #.");
            this.toolTip1.SetToolTip(this.formationName3,
                "The 3rd monster in the formation by name.");
            this.toolTip1.SetToolTip(this.formationCoordX3,
                "The 3rd monster's X coordinate in the formation.");
            this.toolTip1.SetToolTip(this.formationCoordY3,
                "The 3rd monster's Y coordinate in the formation.");
            this.toolTip1.SetToolTip(this.formationByte4,
                "The 4th monster in the formation by #.");
            this.toolTip1.SetToolTip(this.formationName4,
                "The 4th monster in the formation by name.");
            this.toolTip1.SetToolTip(this.formationCoordX4,
                "The 4th monster's X coordinate in the formation.");
            this.toolTip1.SetToolTip(this.formationCoordY4,
                "The 4th monster's Y coordinate in the formation.");
            this.toolTip1.SetToolTip(this.formationByte5,
                "The 5th monster in the formation by #.");
            this.toolTip1.SetToolTip(this.formationName5,
                "The 5th monster in the formation by name.");
            this.toolTip1.SetToolTip(this.formationCoordX5,
                "The 5th monster's X coordinate in the formation.");
            this.toolTip1.SetToolTip(this.formationCoordY5,
                "The 5th monster's Y coordinate in the formation.");
            this.toolTip1.SetToolTip(this.formationByte6,
                "The 6th monster in the formation by #.");
            this.toolTip1.SetToolTip(this.formationName6,
                "The 6th monster in the formation by name.");
            this.toolTip1.SetToolTip(this.formationCoordX6,
                "The 6th monster's X coordinate in the formation.");
            this.toolTip1.SetToolTip(this.formationCoordY6,
                "The 6th monster's Y coordinate in the formation.");
            this.toolTip1.SetToolTip(this.formationByte7,
                "The 7th monster in the formation by #.");
            this.toolTip1.SetToolTip(this.formationName7,
                "The 7th monster in the formation by name.");
            this.toolTip1.SetToolTip(this.formationCoordX7,
                "The 7th monster's X coordinate in the formation.");
            this.toolTip1.SetToolTip(this.formationCoordY7,
                "The 7th monster's Y coordinate in the formation.");
            this.toolTip1.SetToolTip(this.formationByte8,
                "The 8th monster in the formation by #.");
            this.toolTip1.SetToolTip(this.formationName8,
                "The 8th monster in the formation by name.");
            this.toolTip1.SetToolTip(this.formationCoordX8,
                "The 8th monster's X coordinate in the formation.");
            this.toolTip1.SetToolTip(this.formationCoordY8,
                "The 8th monster's Y coordinate in the formation.");
            this.toolTip1.SetToolTip(this.checkedListBox1,
                "The monsters enabled in the formation. This must be\n" +
                "checked for a monster that is to have any presence in the\n" +
                "battle at all.\n\n" +
                "WARNING: it is not recommended to have more than 6\n" +
                "monsters enabled in one formation, due to VRAM capacity.");
            this.toolTip1.SetToolTip(this.checkedListBox2,
                "The monsters not present in the formation at the start of\n" +
                "the battle. Monsters with this property checked can be\n" +
                "later called to battle through the battle-script.");

            this.toolTip1.SetToolTip(this.formationBattleEvent,
                "The battle event sequence that plays at the start of the\n" +
                "battle. These cannot be edited individually.");
            this.toolTip1.SetToolTip(this.formationUnknown,
                "Unknown formation property; it is recommended to leave it\n" +
                "alone. Only the Bowser, Kinlink formation has this value set\n" +
                "by default.");
            this.toolTip1.SetToolTip(this.formationMusic,
                "The music assigned to the formation that plays in battle.\n\n" + 
                "The music can be selected from 8 indexes or set to\n"+
                "{CURRENT}, which continues to play the current music\n"+
                "track in the overworld when the battle begins. To edit the\n"+
                "actual track that is assigned to the index, change the\n"+
                "\"Music Track\" property to the right.");
            this.toolTip1.SetToolTip(this.musicTrack,
                "The music track assigned to the currently selected \"INDEX\"\n"+
                "to the left. Note that changing this value will affect the music\n"+
                "for all formations that use the same \"INDEX\" as the currently\n"+
                "selected formation.");
            this.toolTip1.SetToolTip(this.formationCantRun,
                "If checked, it is impossible to run away from the formation\n" +
                "in battle.");

            this.toolTip1.SetToolTip(this.pictureBoxFormation,
                "Click and drag the monsters in the formation.");
            this.toolTip1.SetToolTip(this.battlefieldName,
                "Select the background to preview the formation in. This is\n" +
                "only for preview purposes; changing this will have no effect\n" +
                "on the ROM.");

            // FORMATION PACKS
            this.toolTip1.SetToolTip(this.packNum,
                "Set the formation pack to edit by #.\n\n" +
                "A pack is a set of three formations to either randomly or\n" +
                "selectively choose from when a battle is called, through an\n" +
                "event script or through an the property of an NPC in a level.");
            this.toolTip1.SetToolTip(this.formationSet,
                "The range of formations that are allowed in the pack. All 3\n" +
                "formations in a pack must be either within the range of 0-\n" +
                "255 or 256-511. Formations 256-511 generally include\n" +
                "bosses.");
            this.toolTip1.SetToolTip(this.packFormation1,
                "The 1st formation in the pack.");
            this.toolTip1.SetToolTip(this.packFormation2,
                "The 2nd formation in the pack.");
            this.toolTip1.SetToolTip(this.packFormation3,
                "The 3rd formation in the pack.");
            this.toolTip1.SetToolTip(this.packFormationButton1,
                "Load the 1st formation into the formation editor.");
            this.toolTip1.SetToolTip(this.packFormationButton2,
                "Load the 2nd formation into the formation editor.");
            this.toolTip1.SetToolTip(this.packFormationButton3,
                "Load the 3rd formation into the formation editor.");
            this.toolTip1.SetToolTip(this.richTextBox2,
                "The list of monsters in the 1st formation.");
            this.toolTip1.SetToolTip(this.richTextBox3,
                "The list of monsters in the 2nd formation.");
            this.toolTip1.SetToolTip(this.richTextBox4,
                "The list of monsters in the 3rd formation.");

            // SPELLS
            this.toolTip1.SetToolTip(this.spellNum,
                "Select the spell to edit by #. These properties are applied\n" +
                "to either in-battle usage, overworld usage or both.\n\n" +
                "Spell #0-31 are ally spells, while all other spells are monster\n" +
                "spells. Both are exclusively limited to usage by either allies\n" +
                "or monsters. Any attempts to assign monster spells to allies\n" +
                "or vice versa will most likely cause a glitch, and is not\n" +
                "recommended unless the user possesses in-depth\n" +
                "knowledge of spell animations and a willingness to modify\n" +
                "them first-hand through a hex editor.");
            this.toolTip1.SetToolTip(this.spellName,
                "Select the spell to edit by name. These properties are\n" +
                "to either in-battle usage, overworld usage or both.\n\n" +
                "Spell #0-31 are ally spells, while all other spells are monster\n" +
                "spells. Both are exclusively limited to usage by either allies\n" +
                "or monsters. Any attempts to assign monster spells to allies\n" +
                "or vice versa will most likely cause a glitch, and is not\n" +
                "recommended unless the user possesses in-depth\n" +
                "knowledge of spell animations and a willingness to modify\n" +
                "them first-hand through a hex editor.");
            this.toolTip1.SetToolTip(this.textBoxSpellName,
                "The spell's displayed name in all menus.");
            this.toolTip1.SetToolTip(this.spellFPCost,
                "The amount of FP subtracted from the user's current FP\n" +
                "when the spell is used.");
            this.toolTip1.SetToolTip(this.spellMagPower,
                "The base damage or heal amount caused by the spell.");
            this.toolTip1.SetToolTip(this.spellHitRate,
                "The spell's hit rate percent, ie. the probability out of 100\n" +
                "the spell will hit its target.");
            this.toolTip1.SetToolTip(this.comboBox3,
                "The spell's attack type, ie. the spell will either cause\n" +
                "damage or heal its target. This property can be ignored\n" +
                "depending on the value of \"Inflict Function\".");
            this.toolTip1.SetToolTip(this.comboBox4,
                "The effect type, ie. whether or not the spell will inflict or\n" +
                "nullify (an) effect(s). Example: Poison Gas inflicts the\n" +
                "Poison effect on the target(s) and Group Hug nullifies all\n" +
                "adverse effects on the target(s). If set to {NONE} then\n" +
                "anything checked under \"EFFECT\" is ignored. Likewise, this\n" +
                "property is ignored if nothing under \"EFFECT\" is checked.");
            this.toolTip1.SetToolTip(this.spellFunction,
                "The inflict functions are specialized to certain spells, eg.\n" +
                "\"Scan/Show HP\" is specialized to Psychopath and \"Jump\n" +
                "Power\" is specialized to Jump. Some of these will cause the\n" +
                "\"Attack Type\" to be ignored, ie. the spell will neither cause\n" +
                "damage nor heal (eg. Psychopath).");
            this.toolTip1.SetToolTip(this.comboBox5,
                "The element assigned to the spell. If the target has a\n" +
                "strength against the element, the base damage of the spell\n" +
                "will be halved. If the target has a weakness against the\n" +
                "element, the base damage will be doubled. If the target\n" +
                "has a nullification property against the element, it will yield\n" +
                "0 damage.");
            this.toolTip1.SetToolTip(this.spellAttackProp,
                "\"Check Caster/Target Atk/Def\" will add to or subtract from\n" +
                "the base damage or heal amount of the spell based on the\n" +
                "target's attack and defense power instead of its magic\n" +
                "attack and magic defense power. By default, no spells have\n" +
                "this property enabled.\n\n" +
                "\"Ignore Target\'s Defense\" will not subtract the target's\n" +
                "magic defense power from the spell's base damage or heal\n" +
                "amount (ie. the spell's magic power).\n\n" +
                "\"Check Mortality Protection\" is redundant because the\n" +
                "game engine always checks anyways. Only the dummied\n" +
                "Knock Out spell has this enabled by default.\n\n" +
                "\"Usable in overworld menu\" allows the spell to be used out\n" +
                "of battle, ie. the overworld menu. This is normally reserved\n" +
                "for healing spells.\n\n" +
                "\"9999 Damage/Heal\" will kill the target in one strike, if the\n" +
                "spell does not miss. Only the dummied Knock Out spell has\n" +
                "this enabled by default.\n\n" +
                "\"Hide Battle Numerals\" will hide the damage or heal amount\n" +
                "total (ie. the numbers shown after an attack). This is\n" +
                "generally used by spells that cause 0 damage and are only\n" +
                "effect-based spells such as Sleepy Time, to avoid a\n" +
                "redundant \"0\" appearing.");
            this.toolTip1.SetToolTip(this.textBoxSpellDescription,
                "The description that appears in the lower-right corner of\n" +
                "the overworld menu when the cursor is on the spell.");
            this.toolTip1.SetToolTip(this.button34,
                "Creates a break and starts a new line in the description.\n" +
                "These must be inserted to prevent the text from\n" +
                "overflowing past the sub-window's margins.\n\n" +
                "Value is [1].");
            this.toolTip1.SetToolTip(this.button33,
                "Terminates the string from the place it is inserted and\n" +
                "onward. All descriptions must end with a [0].\n\n" +
                "Value is [0].");
            this.toolTip1.SetToolTip(this.spellTargetting,
                "\"Other Targets\" will limit the target to a single ally or\n" +
                "enemy. This must NOT be checked with \"Entire Party\".\n\n" +
                "\"Enemy Party\" will allow the spell to target the opposing\n" +
                "party.\n\n" +
                "\"Entire Party\" will cause the spell to target all members of\n" +
                "either the ally party or enemy party. This must NOT be\n" +
                "checked with \"Other Targets\".\n\n" +
                "\"Wounded Only\" will limit the target to wounded members,\n" +
                "ie. members with currently 0 HP.\n\n" +
                "\"One Party Only\" will limit the target to only one party. By\n" +
                "default, all usable spells have this property enabled.\n" +
                "Uncheck at your own risk!\n\n" +
                "\"Not Self\" will limit the target to other allies only, and the\n" +
                "caster is untargettable. By default no spells have this\n" +
                "checked, although the Mushroom item that turns the user\n" +
                "into a mushroom has this property enabled.");
            this.toolTip1.SetToolTip(this.spellStatusEffect,
                "The effect inflicted or nullified on a target, eg. Poison Gas\n" +
                "inflicts Poison on a target, while Group Hug will nullify all\n" +
                "effects a target is afflicted with except \"Invincible\". These\n" +
                "properties are used based on the value for \"Effect Type\".");
            this.toolTip1.SetToolTip(this.spellStatusChange,
                "The status of a target is either lowered or raised by 50%,\n" +
                "depending on the value for \"Effect Type\". If the value for\n" +
                "\"Effect Type\" is set to \"Inflict\" then the target's stats will be\n" +
                "raised 50%. If \"Effect type is set to \"Nullify\" then the\n" +
                "target's stats will be lowered 50%.\n\n" +
                "Example: Geno Boost by default raises the target's Attack\n" +
                "and Defense power by 50% (eg. if the attack and/or\n" +
                "defense power of the target is 100, then it becomes 150).\n" +
                "Shredder by default lowers the target's Attack, Defense,\n" +
                "Magic Attack, and Magic Defense power by 50% (ie. it\n" +
                "halves them).");

            // ATTACKS
            this.toolTip1.SetToolTip(this.attackNum,
                "Select the attack to edit by #. These are all exclusively in-\n" +
                "battle monster attacks. Many monster attacks have no\n" +
                "name, and even if given one it will not be displayed\n" +
                "because the attack animation code (which can only be\n" +
                "edited through a hex editor) does not enable it.");
            this.toolTip1.SetToolTip(this.attackName,
                "Select the attack to edit by name. These are all exclusively\n" +
                "in-battle monster attacks. Many monster attacks have no\n" +
                "name, and even if given one it will not be displayed\n" +
                "because the attack animation code (which can only be\n" +
                "edited through a hex editor) does not enable it.");
            this.toolTip1.SetToolTip(this.textBoxAttackName,
                "The attack's name displayed at the top of the screen when\n" +
                "executed by the monster. Many monster attacks have no\n" +
                "name, and even if given one it will not be displayed\n" +
                "because the attack animation code (which can only be\n" +
                "edited through a hex editor) does not enable it.");
            this.toolTip1.SetToolTip(this.attackHitRate,
                "The attack's hit rate percent, ie. the probability out of 100\n" +
                "the attack will hit its target.");
            this.toolTip1.SetToolTip(this.attackAtkLevel,
                "The attack level multiplies the base damage of the attack\n" +
                "(ie. the monster's attack power) by a number.\n\n" +
                "An attack level of 0 will yield base damage.\n" +
                "An attack level of 1 will multiply the base damage by 1.5.\n" +
                "An attack level of 2 will multiply the base damage by 2.\n" +
                "An attack level of 3 will multiply the base damage by 4.\n" +
                "An attack level of 4 will multiply the base damage by 8.\n" +
                "An attack level of 5 will multiply the base damage by 16.\n" +
                "An attack level of 6 will multiply the base damage by 32.\n" +
                "An attack level of 7 will multiply the base damage by 64.\n\n" +
                "Example: if the monster's attack power is 6, and the attack\n" +
                "level of the attack is 7, then the damage will be increased\n" +
                "to 384 (ie. 6 x 64).");
            this.toolTip1.SetToolTip(this.attackStatusEffect,
                "The effect inflicted on a target, eg. S'crow Bell inflicts\n" +
                "Scarecrow on a target, Thornet inflicts Poison, etc.");
            this.toolTip1.SetToolTip(this.attackStatusUp,
                "The status of a target is raised by 50%.\n\n" +
                "Example: Valor Up by default raises the target's Defense\n" +
                "and Magic Defense power by 50% (eg. if the magic\n" +
                "defense and/or defense power of the target is 100, then it\n" +
                "becomes 150). Vigor up! by default raises the Magic Attack\n" +
                "and Attack power by 50%.");
            this.toolTip1.SetToolTip(this.attackAtkType,
                "\"9999 Damage\" will kill the target in one strike, if the attack\n" +
                "does not miss.\n\n" +
                "\"No damage\" will yield 0 damage to the target (both \"No\n" +
                "damage\" properties are exactly the same, but different\n" +
                "bits).\n\n" +
                "\"Hide Battle Numerals\" will hide the total damage (ie. the\n" +
                "numbers shown after an attack). This is generally used by\n" +
                "attacks that cause 0 damage and are only effect-based\n" +
                "attacks such as S'crow Bell or \"9999 damage\" enabled\n" +
                "attacks such as Scythe, to avoid a redundant \"0\" or \"9999\"\n" +
                "appearing.");

            //Items
            this.toolTip1.SetToolTip(this.itemNum,
                "Select the item to edit by #. These properties are applied\n" +
                "to either in-battle usage, overworld usage or both.");
            this.toolTip1.SetToolTip(this.itemName,
                "Select the item to edit by name. These properties are \n" +
                "applied to either in-battle usage, overworld usage or both.");
            this.toolTip1.SetToolTip(this.textBoxItemName,
                "The item's displayed name in all menus.");
            this.toolTip1.SetToolTip(this.itemNameIcon,
                "The item's icon as seen preceding its displayed name in all \n" +
                "menus.");
            this.toolTip1.SetToolTip(this.itemCoinValue,
                "The amount the item costs in a shop. Final costs varies \n" +
                "depending on the \"Purchase Discounts\" properties of the \n" +
                "shop selling the item. The resale value of the item is exactly \n" +
                "half the \"Coin Value\" (ie. how many coins you receive from \n" +
                "selling it in a shop).");
            this.toolTip1.SetToolTip(this.itemSpeed,
                "The wearer's total speed is increased by this amount.\n" +
                "This property is ignored for non-equipment items.");
            this.toolTip1.SetToolTip(this.itemAttackRange,
                "The attack range is the range of damage, plus and minus\n" +
                "the \"Attack\" value, done to the target. The final damage\n" +
                "will be a random value chosen from the \"Attack\" value plus\n" +
                "and minus the \"Attack Range\" value.\n" +
                "Example: if the \"Attack\" is 50, and the attack range is 25,\n" +
                "the final damage could be anywhere from 25 to 75.\n" +
                "This property is ignored for non-weapon items.");
            this.toolTip1.SetToolTip(this.itemPower,
                "The exact damage, heal or increment amount inflicted by \n" +
                "an item. This property will heal, damage or increment a \n" +
                "property depending on the value of \"Inflict Function\".\n" +
                "Example: Flower Box has an \"Infliction Amount\" of 5 and an\n" +
                "\"Inflict Function\" of Raise Max FP, which means it \n" +
                "increments the Max FP by 5. Ice Bomb has an \"Infliction\"\n" +
                "\"Amount\" of 140, which means it does 140 base damage.");
            this.toolTip1.SetToolTip(this.itemAttack,
                "The wearer's total Attack Power is increased by this \n" +
                "amount. This property is ignored for non-equipment items.");
            this.toolTip1.SetToolTip(this.itemDefense,
                "The wearer's total Defense Power is increased by this \n" +
                "amount. This property is ignored for non-equipment items.");
            this.toolTip1.SetToolTip(this.itemMagicAttack,
                "The wearer's total Magic Attack Power is increased by this \n" +
                "amount. This property is ignored for non-equipment items.");
            this.toolTip1.SetToolTip(this.itemMagicDefense,
                "The wearer's total Magic Defense Power is increased by this \n" +
                "amount. This property is ignored for non-equipment items.");
            this.toolTip1.SetToolTip(this.itemType,
                "The type of item will determine whether the item can be \n" +
                "equipped, what menu inventory it appears in, etc.");
            this.toolTip1.SetToolTip(this.itemAttackType,
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
            this.toolTip1.SetToolTip(this.itemFunction,
                "The inflict function is only used for non-equipment items, \n" +
                "such as the Mushroom which is set to \"Restore HP\" and \n" +
                "Maple Syrup which is set to \"Restore FP\", or the Flower \n" +
                "items that raise the maximum FP are set to \"Raise Max FP\".\n\n" +
                "Some functions read the \"Infliction Amount\" value to \n" +
                "determine how much HP, FP, etc. will be restored/raised.");
            this.toolTip1.SetToolTip(this.itemElemAttack,
                "The inflict element is only used with items that typically \n" +
                "cause damage to the target. By default, only the Fire and \n" +
                "Ice Bomb items have this set, although any item that can \n" +
                "cause damage will read from this.");
            this.toolTip1.SetToolTip(this.itemUsage,
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
            this.toolTip1.SetToolTip(this.textBoxItemDescription,
                "The item description as it appears in the lower-left corner of \n" +
                "the overworld menu when the cursor is on the item.\n" +
                "Click the arrow above to see the preview.");
            this.toolTip1.SetToolTip(this.itemStatusEffect,
                "The effect inflicted, protected against or nullified on a target. \n\n" +
                "Example: Red Essence inflicts Invincible on the target. \n" +
                "Super Suit protects against all effects (except Invincible). \n" +
                "Able Juice nullifies all effects (except Invincible).\n\n" +
                "These properties are used based on the value for \"Effect \n" +
                "Type\".");
            this.toolTip1.SetToolTip(this.itemElemNull,
                "All attacks with the following checked elemental properties \n" +
                "will always cause 0 damage to the wearer of the item. This \n" +
                "property only applies to equipment.");
            this.toolTip1.SetToolTip(this.itemElemWeak,
                "All attacks with the following checked elemental properties \n" +
                "will double the damage to the wearer of the item. This \n" +
                "property only applies to equipment.");
            this.toolTip1.SetToolTip(this.itemStatusChange,
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
            this.toolTip1.SetToolTip(this.itemWhoEquip,
                "Who can equip the item.\n" +
                "Example: Lazy Shell can be equipped by all 5 characters.\n" +
                "This property is ignored by non-equipment items.");
            this.toolTip1.SetToolTip(this.itemTargetting,
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
            this.toolTip1.SetToolTip(this.itemCursor,
                "The action of the cursor when the item is selected for use in \n" +
                "the overworld menu only.\n" +
                "Example: the Mushroom will direct the cursor to HP (ie. the \n" +
                "HP will be restored) and the Maple Syrup will direct the \n" +
                "cursor to FP (ie. the FP will be restored).");
            this.toolTip1.SetToolTip(this.itemCursorRestore,
                "\"Restore only if HP less than max\" will restore the HP only if \n" +
                "the target's current HP does not equal the maximum HP.\n" +
                "\"Restore only if FP less than max\" likewise, does similarly \n" +
                "for FP.");

            //Shops
            this.toolTip1.SetToolTip(this.shopNum,
                "The shop to edit by #.\n" +
                "Shops are called through event scripts, most often \n" +
                "triggered by talking to a \"store owner\" or an NPC.");
            this.toolTip1.SetToolTip(this.shopName,
                "The shop to edit by label.\n" +
                "These shop \"names\" are simply labels used to identify the \n" +
                "shops. The user may change the label.");
            this.toolTip1.SetToolTip(this.shopLabel,
                "The currently selected shop's label. Use this to label / \n" +
                "identify a shop. This is not read from anywhere in the ROM \n" +
                "and is exclusively part of the editor. Changing this will have \n" +
                "no effect on the game.");
            this.toolTip1.SetToolTip(this.shopBuyOptions,
                "\"Buy with Frog Coins, one product each\" is used, for \n" +
                "example, by the \"Frog Disciple\" in Seaside Town. Only one \n" +
                "of each product can be bought with Frog Coins only.\n\n" +
                "\"Buy with Frog Coins\" is the same as above, only the \n" +
                "product(s) can be bought as many times as afforded. The \n" +
                "\"Frog Coin Emporium\" uses this property.\n\n" +
                "\"Buy only, no selling\" is obvious: only buying is allowed in \n" +
                "the shop, and items cannot be sold. Both of these \n" +
                "properties are exactly the same, there is no difference \n" +
                "(they are merely two separate bits that each have the \n" +
                "same property).");
            this.toolTip1.SetToolTip(this.shopDiscounts,
                "These will lower the prices of the items being sold, \n" +
                "according to their \"Coin Value\". For example, a Juice Bar \n" +
                "has a discount of 50%, which means the KeroKeroCola it \n" +
                "sells (which is normally 400 coins) is 50% less than 400 \n" +
                "coins, ie. 200 coins.\n" +
                "These can be combined, ie. if 50% and 25% are both \n" +
                "checked, then the discount is 75%.");

            // Characters

            this.toolTip1.SetToolTip(this.characterNum,
                "The character to edit by #.\n\n" +
                "The current character selected is the base index for all of \n" +
                "the properties in the \"LEVEL-UPS / START STATS\" tab \n" +
                "except for those in the \"STARTING STATISTICS\" and \n" +
                "\"STARTING ITEMS\" panels.");
            this.toolTip1.SetToolTip(this.characterName,
                "The character to edit by name.\n\n" +
                "The current character selected is the base index for all of \n" +
                "the properties in the \"LEVEL-UPS / START STATS\" tab \n" +
                "except for those in the \"STARTING STATISTICS\" and \n" +
                "\"STARTING ITEMS\" panels.");
            this.toolTip1.SetToolTip(this.textBoxCharacterName,
                "The character's displayed name in all menus.");
            this.toolTip1.SetToolTip(this.levelNum,
                "The character's level to edit by #. All 5 characters have a \n" +
                "total of 29 levels (levels 2 through 30) each.\n\n" +
                "The level selected is the base index for all of the properties \n" +
                "in the \"LEVEL STAT INCREMENTS\", \"LEVEL UP BONUS \n" +
                "INCREMENTS\" and \"LEVEL UP SPELL LEARNING\" panels.");
            this.toolTip1.SetToolTip(this.expNeeded,
                "The amount of experience the currently selected character \n" +
                "needs to reach the currently selected level.");
            this.toolTip1.SetToolTip(this.hpPlus,
                "The amount the currently selected character's HP will \n" +
                "automatically increase when the character reaches the \n" +
                "currently selected level during a level-up.");
            this.toolTip1.SetToolTip(this.attackPlus,
                "The amount the currently selected character's Attack \n" +
                "Power will automatically increase when the character \n" +
                "reaches the currently selected level during a level-up.");
            this.toolTip1.SetToolTip(this.defensePlus,
                "The amount the currently selected character's Defense \n" +
                "Power will automatically increase when the currently \n" +
                "selected character reaches the currently selected level \n" +
                "during a level-up.");
            this.toolTip1.SetToolTip(this.mgAttackPlus,
                "The amount the currently selected character's Magic Attack \n" +
                "Power will automatically increase when the currently \n" +
                "selected character reaches the currently selected level \n" +
                "during a level-up.");
            this.toolTip1.SetToolTip(this.mgDefensePlus,
                "The amount the currently selected character's Magic \n" +
                "Defense Power will automatically increase when the \n" +
                "currently selected character reaches the currently selected \n" +
                "level during a level-up.");
            this.toolTip1.SetToolTip(this.hpPlusBonus,
                "The amount the currently selected character's HP will \n" +
                "increase if the \"HP\" bonus option is chosen when the \n" +
                "currently selected character reaches the currently selected \n" +
                "level during a level-up.");
            this.toolTip1.SetToolTip(this.attackPlusBonus,
                "The amount the currently selected character's Attack \n" +
                "Power will increase if the \"POW\" bonus option is chosen \n" +
                "when the currently selected character reaches the \n" +
                "currently selected level during a level-up.");
            this.toolTip1.SetToolTip(this.defensePlusBonus,
                "The amount the currently selected character's Defense \n" +
                "Power will increase if the \"POW\" bonus option is chosen \n" +
                "when the currently selected character reaches the \n" +
                "currently selected level during a level-up.");
            this.toolTip1.SetToolTip(this.mgAttackPlusBonus,
                "The amount the currently selected character's Magic Attack \n" +
                "Power will increase if the \"S\" bonus option is chosen when \n" +
                "the currently selected character reaches the currently \n" +
                "selected level during a level-up.");
            this.toolTip1.SetToolTip(this.mgDefensePlusBonus,
                "The amount the currently selected character's Magic \n" +
                "Defense Power will increase if the \"S\" bonus option is \n" +
                "chosen when the currently selected character reaches the \n" +
                "currently selected level during a level-up.");
            this.toolTip1.SetToolTip(this.levelUpSpellLearned,
                "The spell learned when the currently selected character \n" +
                "reaches the currently selected level during a level-up.");

            // Character starting stats
            this.toolTip1.SetToolTip(this.startingLevel,
                "The initial level of the currently selected character when (s)\n" +
                "he becomes active.");
            this.toolTip1.SetToolTip(this.startingAttack,
                "The initial attack power of the currently selected character \n" +
                "when (s)he becomes active.");
            this.toolTip1.SetToolTip(this.startingDefense,
                "The initial defense power of the currently selected \n" +
                "character when (s)he becomes active.");
            this.toolTip1.SetToolTip(this.startingMgAttack,
                "The initial magic attack power of the currently selected \n" +
                "character when (s)he becomes active.");
            this.toolTip1.SetToolTip(this.startingMgDefense,
                "The initial magic defense power of the currently selected \n" +
                "character when (s)he becomes active.");
            this.toolTip1.SetToolTip(this.startingSpeed,
                "The initial speed of the currently selected character when \n" +
                "(s)he becomes active.");
            this.toolTip1.SetToolTip(this.startingWeapon,
                "The initially equipped weapon of the currently selected \n" +
                "character when (s)he becomes active.");
            this.toolTip1.SetToolTip(this.startingArmor,
                "The initially equipped armor of the currently selected \n" +
                "character when (s)he becomes active.");
            this.toolTip1.SetToolTip(this.startingAccessory,
                "The initially equipped accessory of the currently selected \n" +
                "character when (s)he becomes active.");
            this.toolTip1.SetToolTip(this.startingExperience,
                "The initial experience of the currently selected character \n" +
                "when (s)he becomes active.");
            this.toolTip1.SetToolTip(this.startingCurrentHP,
                "The initial current HP of the currently selected character \n" +
                "when (s)he becomes active.");
            this.toolTip1.SetToolTip(this.startingMaximumHP,
                "The initial maximum HP of the currently selected character \n" +
                "when (s)he becomes active.");
            this.toolTip1.SetToolTip(this.startingMagic,
                "The initial spells known by the currently selected character \n" +
                "when (s)he becomes active.");

            // Starting stats
            this.toolTip1.SetToolTip(this.startingCoins,
                "The amount of coins in the inventory at the start of a new \n" +
                "game.");
            this.toolTip1.SetToolTip(this.startingFrogCoins,
                "The amount of frog coins in the inventory at the start of a \n" +
                "new game.");
            this.toolTip1.SetToolTip(this.startingCurrentFP,
                "The current FP at the start of a new game.");
            this.toolTip1.SetToolTip(this.startingMaximumFP,
                "The maximum FP at the start of a new game.");
            this.toolTip1.SetToolTip(this.slotNum,
                "The slot is the \"open slot\" in an inventory to store an item.\n\n" +
                "For example, the equipment and items have 30 slots, \n" +
                "therefore they can store 30 items in slots 0 to 29. By \n" +
                "default, there are actually 29 open slots in the game, due \n" +
                "to the default trash can occupying slot #29).");
            this.toolTip1.SetToolTip(this.startingItem,
                "The item in the currently selected slot of the item inventory \n" +
                "at the start of a new game.");
            this.toolTip1.SetToolTip(this.startingSpecialItem,
                "The item in the currently selected slot of the special item \n" +
                "inventory at the start of a new game.");
            this.toolTip1.SetToolTip(this.startingEquipment,
                "The item in the currently selected slot of the equipment \n" +
                "inventory at the start of a new game.");

            //Timing
            this.toolTip1.SetToolTip(this.weaponOrDefense,
                "Choose to either edit the timing properties for a \"WEAPON\" \n" +
                "(from which the user chooses which weapon to edit in the \n" +
                "control to the right) or \"DEFENSE\" (for which there is only \n" +
                "one index for its timing).");
            this.toolTip1.SetToolTip(this.weaponName,
                "The weapon by name to edit the timing properties for, if \n" +
                "\"WEAPON\" is selected to the left.");
            this.toolTip1.SetToolTip(this.numericUpDown6,
                "The weapon by # to edit the timing properties for, if \n" +
                "\"WEAPON\" is selected to the left.");
            this.toolTip1.SetToolTip(this.lvl1TimingStart,
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
            this.toolTip1.SetToolTip(this.numericUpDown118,
                this.toolTip1.GetToolTip(this.lvl1TimingStart));
            this.toolTip1.SetToolTip(this.lvl2TimingStart,
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
            this.toolTip1.SetToolTip(this.numericUpDown120,
                this.toolTip1.GetToolTip(this.lvl2TimingStart));
            this.toolTip1.SetToolTip(this.lvl2TimingEnd,
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
            this.toolTip1.SetToolTip(this.numericUpDown117,
                this.toolTip1.GetToolTip(this.lvl2TimingEnd));
            this.toolTip1.SetToolTip(this.lvl1TimingEnd,
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
            this.toolTip1.SetToolTip(this.numericUpDown119,
                this.toolTip1.GetToolTip(this.lvl1TimingEnd));

            this.toolTip1.SetToolTip(this.level1TimingSpellName,
                "Level 1 Timing Spells can only increase the damage / healing \n" +
                "by 50%, or, for spells like Psychopath supplement a \n" +
                "\"bonus\" to the spell (eg. Psychopath shows the monster's \n" +
                "\"Psychopath Message\" when timed).");
            this.toolTip1.SetToolTip(this.spell1TimingFrameSpan,
                "The # of frames from the start of the spell's animation \n" +
                "when the user can trigger level 1 timing. The spell's damage \n" +
                "will be increased by 50% if an ABXY button is pressed \n" +
                "within this range. ");
            this.toolTip1.SetToolTip(this.numericUpDown100,
                this.toolTip1.GetToolTip(this.spell1TimingFrameSpan));

            this.toolTip1.SetToolTip(this.level2TimingSpellName,
                "Level 2 Timing Spells will give the player the opportunity to \n" +
                "increase the damage by either 50% or 100% depending on \n" +
                "the timing values.");
            this.toolTip1.SetToolTip(this.spell2Level2FrameStart,
                "The frame # from the start of the spell animation where the \n" +
                "level 2 timing begins.\n" +
                "\n" +
                "Example: the default value for Jump is 39. This means that \n" +
                "if an ABXY button is pressed after 39 frames have passed \n" +
                "from the start of the Jump animation (ie. when Mario jumps \n" +
                "off the ground) the damage is increased by at least 100% \n" +
                "(ie. doubled).");
            this.toolTip1.SetToolTip(this.numericUpDown107,
                this.toolTip1.GetToolTip(this.spell2Level2FrameStart));
            this.toolTip1.SetToolTip(this.spell2Level2FrameEnd,
                "The frame # from the start of the spell animation when the \n" +
                "level 2 timing ends.\n" +
                "\n" +
                "Example: the default value for Jump is 44. This means that \n" +
                "if an ABXY button has NOT been pressed after 44 frames \n" +
                "have passed from the start of the Jump animation (ie. \n" +
                "when Mario jumps off the ground) the opportunity to \n" +
                "increase the damage by 100% (ie. doubled) is gone.");
            this.toolTip1.SetToolTip(this.numericUpDown110,
                this.toolTip1.GetToolTip(this.spell2Level2FrameEnd));
            this.toolTip1.SetToolTip(this.spell2Level1FrameEnd,
                "The frame # from the start of the spell animation where the \n" +
                "level 1 timing ends.\n" +
                "\n" +
                "Example: the default value for Jump is 45. This means that \n" +
                "if an ABXY button has NOT been pressed after 45 frames \n" +
                "have passed from the start of the Jump animation, the \n" +
                "opportunity to time the attack for any damage increase is \n" +
                "gone.");
            this.toolTip1.SetToolTip(this.numericUpDown108,
                this.toolTip1.GetToolTip(this.spell2Level1FrameEnd));

            this.toolTip1.SetToolTip(this.GenoLevel2Frame,
                "The frame # from the start of the spell animation when, if \n" +
                "the button is held to this point, the damage is increased by \n" +
                "at least 50%. This is by default around when the first red \n" +
                "star appears on screen.");
            this.toolTip1.SetToolTip(this.numericUpDown113,
                this.toolTip1.GetToolTip(this.GenoLevel2Frame));
            this.toolTip1.SetToolTip(this.GenoLevel3Frame,
                "The frame # from the start of the spell animation when, if \n" +
                "the button is held to this point, the damage is increased by \n" +
                "at least 75%. This is by default around when the second \n" +
                "red star appears on screen.");
            this.toolTip1.SetToolTip(this.numericUpDown111,
                this.toolTip1.GetToolTip(this.GenoLevel3Frame));
            this.toolTip1.SetToolTip(this.GenoLevel4Frame,
                "The frame # from the start of the spell animation when, if \n" +
                "the button is held to this point, the damage is increased by \n" +
                "at least 100%. This is by default around when the third red \n" +
                "star appears on screen.");
            this.toolTip1.SetToolTip(this.numericUpDown114,
                this.toolTip1.GetToolTip(this.GenoLevel4Frame));
            this.toolTip1.SetToolTip(this.GenoChargeOverflow,
                "The frame # from the start of the spell animation when, if \n" +
                "the button is held to this point and beyond, the damage \n" +
                "\"overflows\" and is reset to the base value, ie. no damage \n" +
                "increase.");
            this.toolTip1.SetToolTip(this.numericUpDown112,
                this.toolTip1.GetToolTip(this.GenoChargeOverflow));

            this.toolTip1.SetToolTip(this.fireballName,
                "Fireball Spells are those spells where the player can \"fire\" a \n" +
                "number of fireballs at a certain speed for a maximum \n" +
                "number of times.");
            this.toolTip1.SetToolTip(this.numericUpDown106,
                "The \"speed\" of the firing, or the # of frames the player \n" +
                "must wait between button presses in order to \"fire\" another \n" +
                "fireball.\n" +
                "NOTE: values less than the default may cause the game to \n" +
                "freeze if the button is consistently pressed for each frame \n" +
                "span between fireballs.");
            this.toolTip1.SetToolTip(this.numericUpDown105,
                "The maximum number of orbs the player can fire before the \n" +
                "spell is over. The accumulative damage is increased with \n" +
                "each fireball, so lowering/raising this value will affect the \n" +
                "maximum accumulative damage as well.");

            this.toolTip1.SetToolTip(this.padRotationSpellName,
                "Pad Rotation Spells are those spells that allow the player to \n" +
                "increase the total damage by rotating the control pad \n" +
                "clockwise for a maximum number of quarter rotations.");
            this.toolTip1.SetToolTip(this.numericUpDown104,
                "The frame # from the start of the spell animation when the \n" +
                "player has the opportunity to rotate the directional pad to \n" +
                "increase damage.");
            this.toolTip1.SetToolTip(this.numericUpDown103,
                "The maximum number of quarter rotations (a quarter \n" +
                "rotation would be, for example, from DOWN to DOWN-LEFT \n" +
                "to LEFT) allowed to increase damage. Raising/lowering this \n" +
                "value will affect the maximum accumulative damage.");

            this.toolTip1.SetToolTip(this.multipleTimingSpellName,
                "Multiple Timing Spells are those spells that allow the player \n" +
                "to perform multiple instances (eg. multiple jumps or star \n" +
                "rains) based on the timing values.");
            this.toolTip1.SetToolTip(this.numericUpDown7,
                "The maximum number of times the player can execute \n" +
                "another \"jump\" or \"star rain\" by timing it. Values above 127 \n" +
                "will likely cause anomalies (ie. the spell caster might only be \n" +
                "able to do 13 jumps, even if the maximum is set to 200 for \n" +
                "example).");
            this.toolTip1.SetToolTip(this.instanceNumberName,
                "The instance selected. The rest of the instances have the \n" +
                "same \"Instance Frame Duration\" as the last one in the list \n" +
                "of instances. For example, Super Jump instances 14 \n" +
                "through 199 will have the same \"Instance Frame Duration\" \n" +
                "as instance 13.\n" +
                "NOTE: star rain's \"Instance Frame Duration\" is the same for \n" +
                "all instances, so there isn't a list for them.");
            this.toolTip1.SetToolTip(this.numericUpDown8,
                "The # of frames before either Mario or the Star lands on \n" +
                "the target that the player is able to time the spell to \n" +
                "increment damage and allow another instance to be timed.\n" +
                "NOTE: star rain's \"Instance Frame Duration\" is the same for \n" +
                "all instances, so there isn't a list for them.");

            this.toolTip1.SetToolTip(this.numericUpDown102,
                "The maximum number of times the player can press an \n" +
                "ABXY button to increase damage during the spell animation.");
        }

        private int[] MenuFramePixels(Size s)
        {
            int[] pixels = new int[(s.Width * 8) * (s.Height * 8)];

            // set palette
            int[] palette = new int[16];
            ushort color = 0;
            int r, g, b;
            for (int i = 0; i < 16; i++) // 16 colors in palette
            {
                color = BitManager.GetShort(data, i * 2 + 0x24C83A);

                r = (byte)((color % 0x20) * 8);
                g = (byte)(((color >> 5) % 0x20) * 8);
                b = (byte)(((color >> 10) % 0x20) * 8);

                palette[i] = Color.FromArgb(r, g, b).ToArgb();
            }

            // set tileset
            Tile8x8[] frameTileset = new Tile8x8[16 * 2];
            for (int i = 0; i < frameTileset.Length; i++)
                frameTileset[i] = new Tile8x8(i, model.MenuFrame, i * 0x10, palette, false, false, false, true);

            // draw tiles to pixels
            CopyOverTile8x8(frameTileset[0x00], pixels, s.Width * 8, 0, 0);
            CopyOverTile8x8(frameTileset[0x01], pixels, s.Width * 8, 8, 0);
            CopyOverTile8x8(frameTileset[0x03], pixels, s.Width * 8, (s.Width - 2) * 8, 0);
            CopyOverTile8x8(frameTileset[0x04], pixels, s.Width * 8, (s.Width - 1) * 8, 0);
            CopyOverTile8x8(frameTileset[0x10], pixels, s.Width * 8, 0, 8);
            CopyOverTile8x8(frameTileset[0x14], pixels, s.Width * 8, (s.Width - 1) * 8, 8);

            CopyOverTile8x8(frameTileset[0x17], pixels, s.Width * 8, 0, (s.Height - 1) * 8);
            CopyOverTile8x8(frameTileset[0x18], pixels, s.Width * 8, 8, (s.Height - 1) * 8);
            CopyOverTile8x8(frameTileset[0x1A], pixels, s.Width * 8, (s.Width - 2) * 8, (s.Height - 1) * 8);
            CopyOverTile8x8(frameTileset[0x1B], pixels, s.Width * 8, (s.Width - 1) * 8, (s.Height - 1) * 8);
            CopyOverTile8x8(frameTileset[0x10], pixels, s.Width * 8, 0, (s.Height - 2) * 8);
            CopyOverTile8x8(frameTileset[0x14], pixels, s.Width * 8, (s.Width - 1) * 8, (s.Height - 2) * 8);
            for (int x = 2; x < s.Width - 2; x++)
            {
                CopyOverTile8x8(frameTileset[0x02], pixels, s.Width * 8, x * 8, 0);
                CopyOverTile8x8(frameTileset[0x19], pixels, s.Width * 8, x * 8, (s.Height - 1) * 8);
            }
            for (int y = 2; y < s.Height - 2; y++)
            {
                CopyOverTile8x8(frameTileset[0x05], pixels, s.Width * 8, 0, y * 8);
                CopyOverTile8x8(frameTileset[0x06], pixels, s.Width * 8, (s.Width - 1) * 8, y * 8);
            }
            return pixels;
        }
        public void CopyOverTile8x8(Tile8x8 source, int[] dest, int destinationWidth, int x, int y)
        {
            int[] src = source.Pixels;
            int counter = 0;
            for (int i = 0; i < 64; i++)
            {
                dest[y * destinationWidth + x + counter] = src[i];
                counter++;
                if (counter % 8 == 0)
                {
                    y++;
                    counter = 0;
                }
            }
        }

        private void controlMouseMove(object sender, MouseEventArgs e)
        {
            if (sender == this || !enableHelpTipsToolStripMenuItem.Checked)
            {
                labelToolTip.Visible = false;
                return;
            }

            Control control = (Control)sender;

            if (toolTip1.GetToolTip(control) != "")
            {
                Control parent = (Control)control.Parent;
                Point p = control.Location;
                Point l = new Point();
                while (parent.Parent != this)
                {
                    p.X += parent.Location.X;
                    p.Y += parent.Location.Y;
                    parent = parent.Parent;
                }

                labelToolTip.Text = toolTip1.GetToolTip(control);
                l = new Point(p.X + e.X + 50, p.Y + e.Y + 50);
                if (l.X + labelToolTip.Width + 50 > this.Width)
                    l.X -= labelToolTip.Width + 75;
                if (l.Y + labelToolTip.Height + 50 > this.Height)
                    l.Y -= labelToolTip.Height + 50;
                labelToolTip.Location = l;
                labelToolTip.BringToFront();
                labelToolTip.Visible = true;
            }
            else
            {
                labelToolTip.Visible = false;
            }
        }
    }
}