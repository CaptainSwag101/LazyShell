using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LAZYSHELL
{
    public partial class Formations : Form
    {
        #region Variables
        
        private bool updating = false;
        private bool waitBothCoords = false;
        private int overFM = 0;
        private int diffX, diffY;
        private Bitmap formationImage;
        private Bitmap formationBGImage;
        private Battlefield[] battlefields { get { return Model.Battlefields; } }
        private PaletteSet[] paletteSets { get { return Model.PaletteSetsBF; } }
        private Formation[] formations { get { return Model.Formations; } set { Model.Formations = value; } }
        private Formation formation { get { return formations[Index]; } set { formations[Index] = value; } }
        public Formation Formation { get { return formation; } set { formation = value; } }
        private DDlistName monsterNames { get { return Model.MonsterNames; } set { Model.MonsterNames = value; } }
        private FontCharacter[] fontMenu { get { return Model.FontMenu; } }
        private int[] palette { get { return Model.FontPaletteBattle.Palette; } }
        private Monster[] monsters { get { return Model.Monsters; } }
        public int Index { get { return (int)formationNum.Value; } set { formationNum.Value = value; } }
        public ToolStripTextBox FormationName { get { return nameTextBox; } }
        public System.Windows.Forms.ToolStripComboBox FormationNames { get { return formationNameList; } }
        public Search searchWindow;
        #endregion
        // Constructor
        public Formations()
        {
            Model.MonsterNames = new DDlistName(monsters);
            Model.MonsterNames.SortAlpha();
            InitializeComponent();
            searchWindow = new Search(formationNum, nameTextBox, searchFormationNames, formationNameList.Items);
            InitializeStrings();
            this.formationNameList.SelectedIndex = 0;
            battlefieldName.SelectedIndex = 7;
            RefreshFormations();
        }
        // functions
        public void SetToolTips(ToolTip toolTip1)
        {
            // FORMATIONS
            this.formationNameList.ToolTipText =
                "Select the formation to edit.\n\n" +
                "A formation is a set of monsters encountered in battle. A\n" +
                "formation is chosen when a battle is called through either\n" +
                "an event script or through the property of an NPC in a\n" +
                "level.";
            this.formationNum.ToolTipText =
                "Select the formation to edit by #.\n\n" +
                "A formation is a set of monsters encountered in battle. A\n" +
                "formation is chosen when a battle is called through either\n" +
                "an event script or through the property of an NPC in a\n" +
                "level.";

            toolTip1.SetToolTip(this.formationByte1,
                "The 1st monster in the formation by #.");
            toolTip1.SetToolTip(this.formationName1,
                "The 1st monster in the formation by name.");
            toolTip1.SetToolTip(this.formationCoordX1,
                "The 1st monster's X coordinate in the formation.");
            toolTip1.SetToolTip(this.formationCoordY1,
                "The 1st monster's Y coordinate in the formation.");
            toolTip1.SetToolTip(this.formationByte2,
                "The 2nd monster in the formation by #.");
            toolTip1.SetToolTip(this.formationName2,
                "The 2nd monster in the formation by name.");
            toolTip1.SetToolTip(this.formationCoordX2,
                "The 2nd monster's X coordinate in the formation.");
            toolTip1.SetToolTip(this.formationCoordY2,
                "The 2nd monster's Y coordinate in the formation.");
            toolTip1.SetToolTip(this.formationByte3,
                "The 3rd monster in the formation by #.");
            toolTip1.SetToolTip(this.formationName3,
                "The 3rd monster in the formation by name.");
            toolTip1.SetToolTip(this.formationCoordX3,
                "The 3rd monster's X coordinate in the formation.");
            toolTip1.SetToolTip(this.formationCoordY3,
                "The 3rd monster's Y coordinate in the formation.");
            toolTip1.SetToolTip(this.formationByte4,
                "The 4th monster in the formation by #.");
            toolTip1.SetToolTip(this.formationName4,
                "The 4th monster in the formation by name.");
            toolTip1.SetToolTip(this.formationCoordX4,
                "The 4th monster's X coordinate in the formation.");
            toolTip1.SetToolTip(this.formationCoordY4,
                "The 4th monster's Y coordinate in the formation.");
            toolTip1.SetToolTip(this.formationByte5,
                "The 5th monster in the formation by #.");
            toolTip1.SetToolTip(this.formationName5,
                "The 5th monster in the formation by name.");
            toolTip1.SetToolTip(this.formationCoordX5,
                "The 5th monster's X coordinate in the formation.");
            toolTip1.SetToolTip(this.formationCoordY5,
                "The 5th monster's Y coordinate in the formation.");
            toolTip1.SetToolTip(this.formationByte6,
                "The 6th monster in the formation by #.");
            toolTip1.SetToolTip(this.formationName6,
                "The 6th monster in the formation by name.");
            toolTip1.SetToolTip(this.formationCoordX6,
                "The 6th monster's X coordinate in the formation.");
            toolTip1.SetToolTip(this.formationCoordY6,
                "The 6th monster's Y coordinate in the formation.");
            toolTip1.SetToolTip(this.formationByte7,
                "The 7th monster in the formation by #.");
            toolTip1.SetToolTip(this.formationName7,
                "The 7th monster in the formation by name.");
            toolTip1.SetToolTip(this.formationCoordX7,
                "The 7th monster's X coordinate in the formation.");
            toolTip1.SetToolTip(this.formationCoordY7,
                "The 7th monster's Y coordinate in the formation.");
            toolTip1.SetToolTip(this.formationByte8,
                "The 8th monster in the formation by #.");
            toolTip1.SetToolTip(this.formationName8,
                "The 8th monster in the formation by name.");
            toolTip1.SetToolTip(this.formationCoordX8,
                "The 8th monster's X coordinate in the formation.");
            toolTip1.SetToolTip(this.formationCoordY8,
                "The 8th monster's Y coordinate in the formation.");
            toolTip1.SetToolTip(this.checkedListBox1,
                "The monsters enabled in the formation. This must be\n" +
                "checked for a monster that is to have any presence in the\n" +
                "battle at all.\n\n" +
                "it is not recommended to have more than 6\n" +
                "monsters enabled in one formation, due to VRAM capacity.");
            toolTip1.SetToolTip(this.checkedListBox2,
                "The monsters not present in the formation at the start of\n" +
                "the battle. Monsters with this property checked can be\n" +
                "later called to battle through the battle-script.");

            toolTip1.SetToolTip(this.formationBattleEvent,
                "The battle event sequence that plays at the start of the\n" +
                "battle. These can be edited in the animations editor.");
            toolTip1.SetToolTip(this.formationUnknown,
                "Unknown formation property; it is recommended to leave it\n" +
                "alone. Only the Bowser, Kinlink formation has this value set\n" +
                "by default.");
            toolTip1.SetToolTip(this.formationMusic,
                "The music assigned to the formation that plays in battle.\n\n" +
                "The music can be selected from 8 indexes or set to\n" +
                "{CURRENT}, which continues to play the current music\n" +
                "track in the overworld when the battle begins. To edit the\n" +
                "actual track that is assigned to the index, change the\n" +
                "\"Music Track\" property to the right.");
            toolTip1.SetToolTip(this.musicTrack,
                "The music track assigned to the currently selected \"INDEX\"\n" +
                "to the left. Note that changing this value will affect the music\n" +
                "for all formations that use the same \"INDEX\" as the currently\n" +
                "selected formation.");
            toolTip1.SetToolTip(this.formationCantRun,
                "If checked, it is impossible to run away from the formation\n" +
                "in battle.");

            toolTip1.SetToolTip(this.pictureBoxFormation,
                "Click and drag the monsters in the formation.");
            toolTip1.SetToolTip(this.battlefieldName,
                "Select the background to preview the formation in. This is\n" +
                "only for preview purposes; changing this will have no effect\n" +
                "on the ROM.");
        }
        private void InitializeStrings()
        {
            updating = true;
            this.formationNameList.Items.Clear();
            this.formationNameList.Items.AddRange(Lists.Numerize(formations));
            this.formationNameList.SelectedIndex = Index;
            this.formationName1.Items.AddRange(Model.MonsterNames.Names);
            this.formationName2.Items.AddRange(Model.MonsterNames.Names);
            this.formationName3.Items.AddRange(Model.MonsterNames.Names);
            this.formationName4.Items.AddRange(Model.MonsterNames.Names);
            this.formationName5.Items.AddRange(Model.MonsterNames.Names);
            this.formationName6.Items.AddRange(Model.MonsterNames.Names);
            this.formationName7.Items.AddRange(Model.MonsterNames.Names);
            this.formationName8.Items.AddRange(Model.MonsterNames.Names);
            this.battlefieldName.Items.AddRange(Lists.BattlefieldNames);
            this.musicTrack.Items.AddRange(Lists.MusicNames);
            updating = false;
        }
        public void RefreshFormations()
        {
            Cursor.Current = Cursors.WaitCursor;
            if (updating) return;
            updating = true;
            this.formationNameList.SelectedIndex = Index;
            this.formationByte1.Value = formation.FormationMonster[0];
            this.formationByte2.Value = formation.FormationMonster[1];
            this.formationByte3.Value = formation.FormationMonster[2];
            this.formationByte4.Value = formation.FormationMonster[3];
            this.formationByte5.Value = formation.FormationMonster[4];
            this.formationByte6.Value = formation.FormationMonster[5];
            this.formationByte7.Value = formation.FormationMonster[6];
            this.formationByte8.Value = formation.FormationMonster[7];
            this.formationName1.SelectedIndex = monsterNames.GetIndexFromNum(formation.FormationMonster[0]);
            this.formationName2.SelectedIndex = monsterNames.GetIndexFromNum(formation.FormationMonster[1]);
            this.formationName3.SelectedIndex = monsterNames.GetIndexFromNum(formation.FormationMonster[2]);
            this.formationName4.SelectedIndex = monsterNames.GetIndexFromNum(formation.FormationMonster[3]);
            this.formationName5.SelectedIndex = monsterNames.GetIndexFromNum(formation.FormationMonster[4]);
            this.formationName6.SelectedIndex = monsterNames.GetIndexFromNum(formation.FormationMonster[5]);
            this.formationName7.SelectedIndex = monsterNames.GetIndexFromNum(formation.FormationMonster[6]);
            this.formationName8.SelectedIndex = monsterNames.GetIndexFromNum(formation.FormationMonster[7]);
            this.formationCoordX1.Value = formation.FormationCoordX[0];
            this.formationCoordX2.Value = formation.FormationCoordX[1];
            this.formationCoordX3.Value = formation.FormationCoordX[2];
            this.formationCoordX4.Value = formation.FormationCoordX[3];
            this.formationCoordX5.Value = formation.FormationCoordX[4];
            this.formationCoordX6.Value = formation.FormationCoordX[5];
            this.formationCoordX7.Value = formation.FormationCoordX[6];
            this.formationCoordX8.Value = formation.FormationCoordX[7];
            this.formationCoordY1.Value = formation.FormationCoordY[0];
            this.formationCoordY2.Value = formation.FormationCoordY[1];
            this.formationCoordY3.Value = formation.FormationCoordY[2];
            this.formationCoordY4.Value = formation.FormationCoordY[3];
            this.formationCoordY5.Value = formation.FormationCoordY[4];
            this.formationCoordY6.Value = formation.FormationCoordY[5];
            this.formationCoordY7.Value = formation.FormationCoordY[6];
            this.formationCoordY8.Value = formation.FormationCoordY[7];
            this.formationMusic.SelectedIndex = formation.FormationMusic;
            this.formationBattleEvent.Value = formation.FormationBattleEvent;
            this.formationUnknown.Value = formation.FormationUnknown;
            this.formationCantRun.Checked = formation.FormationCantRun;
            for (int i = 0; i < 8; i++)
            {
                this.checkedListBox1.SetItemChecked(i, formation.FormationUse[i]);
                this.checkedListBox2.SetItemChecked(i, formation.FormationHide[i]);
            }
            this.musicTrack.Enabled = formationMusic.SelectedIndex != 8;
            if (formationMusic.SelectedIndex != 8)
                this.musicTrack.SelectedIndex = Model.FormationMusics[formationMusic.SelectedIndex];
            else
                this.musicTrack.SelectedIndex = 0;
            formationImage = new Bitmap(formation.FormationImage);
            pictureBoxFormation.Invalidate();
            updating = false;
            Cursor.Current = Cursors.Arrow;
        }
        private void RefreshFormationBattlefield()
        {
            PaletteSet paletteSet = paletteSets[battlefields[battlefieldName.SelectedIndex].PaletteSet];
            BattlefieldTileSet tileSet = new BattlefieldTileSet(battlefields[battlefieldName.SelectedIndex], paletteSet);
            int[] quadrant1 = Do.TilesetToPixels(tileSet.TileSetLayer, 16, 16, 0, false);
            int[] quadrant2 = Do.TilesetToPixels(tileSet.TileSetLayer, 16, 16, 256, false);
            int[] quadrant3 = Do.TilesetToPixels(tileSet.TileSetLayer, 16, 16, 512, false);
            int[] quadrant4 = Do.TilesetToPixels(tileSet.TileSetLayer, 16, 16, 768, false);
            int[] pixels = new int[512 * 512];
            Do.PixelsToPixels(quadrant1, pixels, 512, new Rectangle(0, 0, 256, 256));
            Do.PixelsToPixels(quadrant2, pixels, 512, new Rectangle(256, 0, 256, 256));
            Do.PixelsToPixels(quadrant3, pixels, 512, new Rectangle(0, 256, 256, 256));
            Do.PixelsToPixels(quadrant4, pixels, 512, new Rectangle(256, 256, 256, 256));
            formationBGImage = new Bitmap(Do.PixelsToImage(pixels, 512, 512));
            pictureBoxFormation.Invalidate();
        }
        #region Event Handlers
        private void formationNameList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updating) return;
            this.formationNum.Value = this.formationNameList.SelectedIndex;
        }
        private void formationNum_ValueChanged(object sender, EventArgs e)
        {
            if (updating) return;
            RefreshFormations();
        }
        private void formationByte1_ValueChanged(object sender, EventArgs e)
        {
            if (updating) return;

            this.formation.FormationMonster[0] = (byte)this.formationByte1.Value;
            this.formationName1.SelectedIndex = this.monsterNames.GetIndexFromNum((byte)formationByte1.Value);
            this.formationNameList.Items[formationNameList.SelectedIndex] = formation;

            formationImage = new Bitmap(this.formation.FormationImage);
            pictureBoxFormation.Invalidate();
        }
        private void formationByte2_ValueChanged(object sender, EventArgs e)
        {
            if (updating) return;

            this.formation.FormationMonster[1] = (byte)this.formationByte2.Value;
            this.formationName2.SelectedIndex = this.monsterNames.GetIndexFromNum((byte)formationByte2.Value);
            this.formationNameList.Items[formationNameList.SelectedIndex] = formation;

            formationImage = new Bitmap(this.formation.FormationImage);
            pictureBoxFormation.Invalidate();
        }
        private void formationByte3_ValueChanged(object sender, EventArgs e)
        {
            if (updating) return;

            this.formation.FormationMonster[2] = (byte)this.formationByte3.Value;
            this.formationName3.SelectedIndex = this.monsterNames.GetIndexFromNum((byte)formationByte3.Value);
            this.formationNameList.Items[formationNameList.SelectedIndex] = formation;

            formationImage = new Bitmap(this.formation.FormationImage);
            pictureBoxFormation.Invalidate();
        }
        private void formationByte4_ValueChanged(object sender, EventArgs e)
        {
            if (updating) return;

            this.formation.FormationMonster[3] = (byte)this.formationByte4.Value;
            this.formationName4.SelectedIndex = this.monsterNames.GetIndexFromNum((byte)formationByte4.Value);
            this.formationNameList.Items[formationNameList.SelectedIndex] = formation;

            formationImage = new Bitmap(this.formation.FormationImage);
            pictureBoxFormation.Invalidate();
        }
        private void formationByte5_ValueChanged(object sender, EventArgs e)
        {
            if (updating) return;

            this.formation.FormationMonster[4] = (byte)this.formationByte5.Value;
            this.formationName5.SelectedIndex = this.monsterNames.GetIndexFromNum((byte)formationByte5.Value);
            this.formationNameList.Items[formationNameList.SelectedIndex] = formation;

            formationImage = new Bitmap(this.formation.FormationImage);
            pictureBoxFormation.Invalidate();
        }
        private void formationByte6_ValueChanged(object sender, EventArgs e)
        {
            if (updating) return;

            this.formation.FormationMonster[5] = (byte)this.formationByte6.Value;
            this.formationName6.SelectedIndex = this.monsterNames.GetIndexFromNum((byte)formationByte6.Value);
            this.formationNameList.Items[formationNameList.SelectedIndex] = formation;

            formationImage = new Bitmap(this.formation.FormationImage);
            pictureBoxFormation.Invalidate();
        }
        private void formationByte7_ValueChanged(object sender, EventArgs e)
        {
            if (updating) return;

            this.formation.FormationMonster[6] = (byte)this.formationByte7.Value;
            this.formationName7.SelectedIndex = this.monsterNames.GetIndexFromNum((byte)formationByte7.Value);
            this.formationNameList.Items[formationNameList.SelectedIndex] = formation;

            formationImage = new Bitmap(this.formation.FormationImage);
            pictureBoxFormation.Invalidate();
        }
        private void formationByte8_ValueChanged(object sender, EventArgs e)
        {
            if (updating) return;

            this.formation.FormationMonster[7] = (byte)this.formationByte8.Value;
            this.formationName8.SelectedIndex = this.monsterNames.GetIndexFromNum((byte)formationByte8.Value);
            this.formationNameList.Items[formationNameList.SelectedIndex] = formation;

            formationImage = new Bitmap(this.formation.FormationImage);
            pictureBoxFormation.Invalidate();
        }
        private void monsterName_DrawItem(object sender, DrawItemEventArgs e)
        {
            Do.DrawName(sender, e, new MenuTextPreview(), monsterNames, fontMenu, palette, true, Model.MenuBackground_);
        }
        private void formationName1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updating) return;

            this.formationByte1.Value = this.monsterNames.GetNumFromIndex(this.formationName1.SelectedIndex);
        }
        private void formationName2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updating) return;

            this.formationByte2.Value = this.monsterNames.GetNumFromIndex(this.formationName2.SelectedIndex);
        }
        private void formationName3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updating) return;

            this.formationByte3.Value = this.monsterNames.GetNumFromIndex(this.formationName3.SelectedIndex);
        }
        private void formationName4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updating) return;

            this.formationByte4.Value = this.monsterNames.GetNumFromIndex(this.formationName4.SelectedIndex);
        }
        private void formationName5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updating) return;

            this.formationByte5.Value = this.monsterNames.GetNumFromIndex(this.formationName5.SelectedIndex);
        }
        private void formationName6_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updating) return;

            this.formationByte6.Value = this.monsterNames.GetNumFromIndex(this.formationName6.SelectedIndex);
        }
        private void formationName7_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updating) return;

            this.formationByte7.Value = this.monsterNames.GetNumFromIndex(this.formationName7.SelectedIndex);
        }
        private void formationName8_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updating) return;

            this.formationByte8.Value = this.monsterNames.GetNumFromIndex(this.formationName8.SelectedIndex);
        }
        private void formationCoordX1_ValueChanged(object sender, EventArgs e)
        {
            if (updating) return;

            this.formation.FormationCoordX[0] = (byte)this.formationCoordX1.Value;

            if (waitBothCoords) return;
            formationImage = new Bitmap(this.formation.FormationImage);
            pictureBoxFormation.Invalidate();
        }
        private void formationCoordX2_ValueChanged(object sender, EventArgs e)
        {
            if (updating) return;

            this.formation.FormationCoordX[1] = (byte)this.formationCoordX2.Value;

            if (waitBothCoords) return;
            formationImage = new Bitmap(this.formation.FormationImage);
            pictureBoxFormation.Invalidate();
        }
        private void formationCoordX3_ValueChanged(object sender, EventArgs e)
        {
            if (updating) return;

            this.formation.FormationCoordX[2] = (byte)this.formationCoordX3.Value;

            if (waitBothCoords) return;
            formationImage = new Bitmap(this.formation.FormationImage);
            pictureBoxFormation.Invalidate();
        }
        private void formationCoordX4_ValueChanged(object sender, EventArgs e)
        {
            if (updating) return;

            this.formation.FormationCoordX[3] = (byte)this.formationCoordX4.Value;

            if (waitBothCoords) return;
            formationImage = new Bitmap(this.formation.FormationImage);
            pictureBoxFormation.Invalidate();
        }
        private void formationCoordX5_ValueChanged(object sender, EventArgs e)
        {
            if (updating) return;

            this.formation.FormationCoordX[4] = (byte)this.formationCoordX5.Value;

            if (waitBothCoords) return;
            formationImage = new Bitmap(this.formation.FormationImage);
            pictureBoxFormation.Invalidate();
        }
        private void formationCoordX6_ValueChanged(object sender, EventArgs e)
        {
            if (updating) return;

            this.formation.FormationCoordX[5] = (byte)this.formationCoordX6.Value;

            if (waitBothCoords) return;
            formationImage = new Bitmap(this.formation.FormationImage);
            pictureBoxFormation.Invalidate();
        }
        private void formationCoordX7_ValueChanged(object sender, EventArgs e)
        {
            if (updating) return;

            this.formation.FormationCoordX[6] = (byte)this.formationCoordX7.Value;

            if (waitBothCoords) return;
            formationImage = new Bitmap(this.formation.FormationImage);
            pictureBoxFormation.Invalidate();
        }
        private void formationCoordX8_ValueChanged(object sender, EventArgs e)
        {
            if (updating) return;

            this.formation.FormationCoordX[7] = (byte)this.formationCoordX8.Value;

            if (waitBothCoords) return;
            formationImage = new Bitmap(this.formation.FormationImage);
            pictureBoxFormation.Invalidate();
        }
        private void formationCoordY1_ValueChanged(object sender, EventArgs e)
        {
            if (updating) return;

            this.formation.FormationCoordY[0] = (byte)this.formationCoordY1.Value;

            if (waitBothCoords) return;
            formationImage = new Bitmap(this.formation.FormationImage);
            pictureBoxFormation.Invalidate();
        }
        private void formationCoordY2_ValueChanged(object sender, EventArgs e)
        {
            if (updating) return;

            this.formation.FormationCoordY[1] = (byte)this.formationCoordY2.Value;

            if (waitBothCoords) return;
            formationImage = new Bitmap(this.formation.FormationImage);
            pictureBoxFormation.Invalidate();
        }
        private void formationCoordY3_ValueChanged(object sender, EventArgs e)
        {
            if (updating) return;

            this.formation.FormationCoordY[2] = (byte)this.formationCoordY3.Value;

            if (waitBothCoords) return;
            formationImage = new Bitmap(this.formation.FormationImage);
            pictureBoxFormation.Invalidate();
        }
        private void formationCoordY4_ValueChanged(object sender, EventArgs e)
        {
            if (updating) return;

            this.formation.FormationCoordY[3] = (byte)this.formationCoordY4.Value;

            if (waitBothCoords) return;
            formationImage = new Bitmap(this.formation.FormationImage);
            pictureBoxFormation.Invalidate();
        }
        private void formationCoordY5_ValueChanged(object sender, EventArgs e)
        {
            if (updating) return;

            this.formation.FormationCoordY[4] = (byte)this.formationCoordY5.Value;

            if (waitBothCoords) return;
            formationImage = new Bitmap(this.formation.FormationImage);
            pictureBoxFormation.Invalidate();
        }
        private void formationCoordY6_ValueChanged(object sender, EventArgs e)
        {
            if (updating) return;

            this.formation.FormationCoordY[5] = (byte)this.formationCoordY6.Value;

            if (waitBothCoords) return;
            formationImage = new Bitmap(this.formation.FormationImage);
            pictureBoxFormation.Invalidate();
        }
        private void formationCoordY7_ValueChanged(object sender, EventArgs e)
        {
            if (updating) return;

            this.formation.FormationCoordY[6] = (byte)this.formationCoordY7.Value;

            if (waitBothCoords) return;
            formationImage = new Bitmap(this.formation.FormationImage);
            pictureBoxFormation.Invalidate();
        }
        private void formationCoordY8_ValueChanged(object sender, EventArgs e)
        {
            if (updating) return;

            this.formation.FormationCoordY[7] = (byte)this.formationCoordY8.Value;

            if (waitBothCoords) return;
            formationImage = new Bitmap(this.formation.FormationImage);
            pictureBoxFormation.Invalidate();
        }
        //
        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updating) return;

            for (int i = 0; i < 8; i++)
                this.formation.FormationUse[i] = checkedListBox1.GetItemChecked(i);

            formationImage = new Bitmap(this.formation.FormationImage);
            pictureBoxFormation.Invalidate();
        }
        private void checkedListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updating) return;

            for (int i = 0; i < 8; i++)
                this.formation.FormationHide[i] = checkedListBox2.GetItemChecked(i);
        }
        private void formationMusic_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updating) return;

            formation.FormationMusic = (byte)formationMusic.SelectedIndex;

            updating = true;
            this.musicTrack.Enabled = formationMusic.SelectedIndex != 8;
            if (formationMusic.SelectedIndex != 8)
                this.musicTrack.SelectedIndex = Model.FormationMusics[formationMusic.SelectedIndex];
            else
                this.musicTrack.SelectedIndex = 0;
            updating = false;
        }
        private void formationUnknown_ValueChanged(object sender, EventArgs e)
        {
            if (updating) return;

            formation.FormationUnknown = (byte)formationUnknown.Value;
        }
        private void formationCantRun_CheckedChanged(object sender, EventArgs e)
        {
            formationCantRun.ForeColor = formationCantRun.Checked ? Color.Black : SystemColors.ControlDark;

            if (updating) return;

            formation.FormationCantRun = formationCantRun.Checked;
        }
        private void battlefieldName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updating) return;

            RefreshFormationBattlefield();
        }
        private void formationBattleEvent_ValueChanged(object sender, EventArgs e)
        {
            if (updating) return;

            formation.FormationBattleEvent = (byte)formationBattleEvent.Value;
        }
        private void musicTrack_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updating) return;

            Model.FormationMusics[formationMusic.SelectedIndex] = (byte)musicTrack.SelectedIndex;
        }
        //
        private void pictureBoxFormation_MouseDown(object sender, MouseEventArgs e)
        {
            int x = e.X; int y = e.Y;
            switch (overFM)
            {
                case 1: diffX = (int)(x - formationCoordX1.Value); diffY = (int)(y - formationCoordY1.Value); break;
                case 2: diffX = (int)(x - formationCoordX2.Value); diffY = (int)(y - formationCoordY2.Value); break;
                case 3: diffX = (int)(x - formationCoordX3.Value); diffY = (int)(y - formationCoordY3.Value); break;
                case 4: diffX = (int)(x - formationCoordX4.Value); diffY = (int)(y - formationCoordY4.Value); break;
                case 5: diffX = (int)(x - formationCoordX5.Value); diffY = (int)(y - formationCoordY5.Value); break;
                case 6: diffX = (int)(x - formationCoordX6.Value); diffY = (int)(y - formationCoordY6.Value); break;
                case 7: diffX = (int)(x - formationCoordX7.Value); diffY = (int)(y - formationCoordY7.Value); break;
                case 8: diffX = (int)(x - formationCoordX8.Value); diffY = (int)(y - formationCoordY8.Value); break;
            }
        }
        private void pictureBoxFormation_MouseMove(object sender, MouseEventArgs e)
        {
            int x = e.X - diffX; int y = e.Y - diffY;
            if (x > 255) x = 255; if (x < 0) x = 0;
            if (y > 255) y = 255; if (y < 0) y = 0;
            if (e.Button == MouseButtons.Left)
            {
                switch (overFM)
                {
                    case 1:
                        if (formationCoordX1.Value != x && formationCoordY1.Value != y) waitBothCoords = true;
                        formationCoordX1.Value = x;
                        waitBothCoords = false;
                        formationCoordY1.Value = y; break;
                    case 2:
                        if (formationCoordX2.Value != x && formationCoordY2.Value != y) waitBothCoords = true;
                        formationCoordX2.Value = x;
                        waitBothCoords = false;
                        formationCoordY2.Value = y; break;
                    case 3:
                        if (formationCoordX3.Value != x && formationCoordY3.Value != y) waitBothCoords = true;
                        formationCoordX3.Value = x;
                        waitBothCoords = false;
                        formationCoordY3.Value = y; break;
                    case 4:
                        if (formationCoordX4.Value != x && formationCoordY4.Value != y) waitBothCoords = true;
                        formationCoordX4.Value = x;
                        waitBothCoords = false;
                        formationCoordY4.Value = y; break;
                    case 5:
                        if (formationCoordX5.Value != x && formationCoordY5.Value != y) waitBothCoords = true;
                        formationCoordX5.Value = x;
                        waitBothCoords = false;
                        formationCoordY5.Value = y; break;
                    case 6:
                        if (formationCoordX6.Value != x && formationCoordY6.Value != y) waitBothCoords = true;
                        formationCoordX6.Value = x;
                        waitBothCoords = false;
                        formationCoordY6.Value = y; break;
                    case 7:
                        if (formationCoordX7.Value != x && formationCoordY7.Value != y) waitBothCoords = true;
                        formationCoordX7.Value = x;
                        waitBothCoords = false;
                        formationCoordY7.Value = y; break;
                    case 8:
                        if (formationCoordX8.Value != x && formationCoordY8.Value != y) waitBothCoords = true;
                        formationCoordX8.Value = x;
                        waitBothCoords = false;
                        formationCoordY8.Value = y; break;
                }
            }
            else
            {
                for (int j = 0; j < 8; j++)
                {
                    if (e.X > 0 && e.X < 256 && e.Y > 0 && e.Y < 256 &&
                        this.formation.PixelAssn[e.Y * 256 + e.X] == (int)(j + 1))
                    {
                        pictureBoxFormation.Cursor = Cursors.Hand;
                        overFM = j + 1;
                        break;
                    }
                    else
                    {
                        pictureBoxFormation.Cursor = Cursors.Arrow;
                        overFM = 0;
                    }
                }
            }
        }
        private void pictureBoxFormation_MouseUp(object sender, MouseEventArgs e)
        {
            formationImage = new Bitmap(this.formation.FormationImage);
            pictureBoxFormation.Invalidate();
        }
        private void pictureBoxFormation_Paint(object sender, PaintEventArgs e)
        {
            if (formationBGImage != null)
                e.Graphics.DrawImage(formationBGImage, -8, 26);
            if (formationImage != null)
                e.Graphics.DrawImage(formationImage, 0, 0);
        }
        #endregion
    }
}
