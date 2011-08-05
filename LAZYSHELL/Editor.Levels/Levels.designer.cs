using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LAZYSHELL
{
    partial class Levels
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Levels));
            this.levelNum = new LAZYSHELL.ToolStripNumericUpDown();
            this.levelName = new System.Windows.Forms.ToolStripComboBox();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.npcInsertObject = new System.Windows.Forms.ToolStripButton();
            this.npcInsertInstance = new System.Windows.Forms.ToolStripButton();
            this.npcRemoveObject = new System.Windows.Forms.ToolStripButton();
            this.npcCopy = new System.Windows.Forms.ToolStripButton();
            this.npcPaste = new System.Windows.Forms.ToolStripButton();
            this.npcDuplicate = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.npcMoveUp = new System.Windows.Forms.ToolStripButton();
            this.npcMoveDown = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.findNPCNum = new System.Windows.Forms.ToolStripButton();
            this.openPartitions = new System.Windows.Forms.ToolStripButton();
            this.panel85 = new System.Windows.Forms.Panel();
            this.npcAttributes = new System.Windows.Forms.CheckedListBox();
            this.label65 = new System.Windows.Forms.Label();
            this.panel118 = new System.Windows.Forms.Panel();
            this.label52 = new System.Windows.Forms.Label();
            this.panel119 = new System.Windows.Forms.Panel();
            this.npcAfterBattle = new System.Windows.Forms.ComboBox();
            this.panel83 = new System.Windows.Forms.Panel();
            this.npcID = new System.Windows.Forms.NumericUpDown();
            this.label49 = new System.Windows.Forms.Label();
            this.npcMovement = new System.Windows.Forms.NumericUpDown();
            this.npcSpeedPlus = new System.Windows.Forms.NumericUpDown();
            this.npcEventORPack = new System.Windows.Forms.NumericUpDown();
            this.label54 = new System.Windows.Forms.Label();
            this.label117 = new System.Windows.Forms.Label();
            this.label70 = new System.Windows.Forms.Label();
            this.buttonGotoB = new System.Windows.Forms.Button();
            this.buttonGotoA = new System.Windows.Forms.Button();
            this.panel43 = new System.Windows.Forms.Panel();
            this.npcEngageType = new System.Windows.Forms.ComboBox();
            this.panel53 = new System.Windows.Forms.Panel();
            this.npcEngageTrigger = new System.Windows.Forms.ComboBox();
            this.panel80 = new System.Windows.Forms.Panel();
            this.label48 = new System.Windows.Forms.Label();
            this.npcMapHeader = new System.Windows.Forms.NumericUpDown();
            this.npcsBytesLeft = new System.Windows.Forms.Label();
            this.npcObjectTree = new System.Windows.Forms.TreeView();
            this.panel84 = new System.Windows.Forms.Panel();
            this.npcX = new System.Windows.Forms.NumericUpDown();
            this.npcY = new System.Windows.Forms.NumericUpDown();
            this.label29 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.npcZ = new System.Windows.Forms.NumericUpDown();
            this.label56 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.npcPropertyA = new System.Windows.Forms.NumericUpDown();
            this.label104 = new System.Windows.Forms.Label();
            this.npcPropertyB = new System.Windows.Forms.NumericUpDown();
            this.label31 = new System.Windows.Forms.Label();
            this.npcPropertyC = new System.Windows.Forms.NumericUpDown();
            this.label116 = new System.Windows.Forms.Label();
            this.npcZ_half = new System.Windows.Forms.CheckBox();
            this.panel42 = new System.Windows.Forms.Panel();
            this.npcFace = new System.Windows.Forms.ComboBox();
            this.npcVisible = new System.Windows.Forms.CheckBox();
            this.mapNum = new System.Windows.Forms.NumericUpDown();
            this.label33 = new System.Windows.Forms.Label();
            this.contextMenuStrip4 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addThisLevelToNotesDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage10 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.overlapFieldTree = new System.Windows.Forms.TreeView();
            this.overlapUnknownBits = new System.Windows.Forms.CheckedListBox();
            this.toolStrip4 = new System.Windows.Forms.ToolStrip();
            this.overlapFieldInsert = new System.Windows.Forms.ToolStripButton();
            this.overlapFieldDelete = new System.Windows.Forms.ToolStripButton();
            this.overlapFieldCopy = new System.Windows.Forms.ToolStripButton();
            this.overlapFieldPaste = new System.Windows.Forms.ToolStripButton();
            this.overlapFieldDuplicate = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator18 = new System.Windows.Forms.ToolStripSeparator();
            this.overlapsBytesLeft = new System.Windows.Forms.ToolStripLabel();
            this.panel99 = new System.Windows.Forms.Panel();
            this.overlapCoordZPlusHalf = new System.Windows.Forms.CheckBox();
            this.label109 = new System.Windows.Forms.Label();
            this.label103 = new System.Windows.Forms.Label();
            this.label107 = new System.Windows.Forms.Label();
            this.overlapType = new System.Windows.Forms.NumericUpDown();
            this.overlapX = new System.Windows.Forms.NumericUpDown();
            this.overlapY = new System.Windows.Forms.NumericUpDown();
            this.overlapZ = new System.Windows.Forms.NumericUpDown();
            this.label106 = new System.Windows.Forms.Label();
            this.panelOverlapTileset = new System.Windows.Forms.Panel();
            this.pictureBoxOverlaps = new System.Windows.Forms.PictureBox();
            this.tabPage9 = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel90 = new System.Windows.Forms.Panel();
            this.buttonGotoD = new System.Windows.Forms.Button();
            this.label62 = new System.Windows.Forms.Label();
            this.label127 = new System.Windows.Forms.Label();
            this.eventLength = new System.Windows.Forms.NumericUpDown();
            this.label129 = new System.Windows.Forms.Label();
            this.eventY = new System.Windows.Forms.NumericUpDown();
            this.eventsWidthYPlusHalf = new System.Windows.Forms.CheckBox();
            this.label131 = new System.Windows.Forms.Label();
            this.eventsWidthXPlusHalf = new System.Windows.Forms.CheckBox();
            this.eventX = new System.Windows.Forms.NumericUpDown();
            this.eventZ = new System.Windows.Forms.NumericUpDown();
            this.panel46 = new System.Windows.Forms.Panel();
            this.eventFace = new System.Windows.Forms.ComboBox();
            this.eventHeight = new System.Windows.Forms.NumericUpDown();
            this.label133 = new System.Windows.Forms.Label();
            this.label135 = new System.Windows.Forms.Label();
            this.label137 = new System.Windows.Forms.Label();
            this.eventEvent = new System.Windows.Forms.NumericUpDown();
            this.eventsList = new System.Windows.Forms.TreeView();
            this.toolStrip6 = new System.Windows.Forms.ToolStrip();
            this.eventsInsertField = new System.Windows.Forms.ToolStripButton();
            this.eventsDeleteField = new System.Windows.Forms.ToolStripButton();
            this.eventsCopyField = new System.Windows.Forms.ToolStripButton();
            this.eventsPasteField = new System.Windows.Forms.ToolStripButton();
            this.eventsDuplicateField = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator20 = new System.Windows.Forms.ToolStripSeparator();
            this.eventsBytesLeft = new System.Windows.Forms.ToolStripLabel();
            this.label63 = new System.Windows.Forms.Label();
            this.panel52 = new System.Windows.Forms.Panel();
            this.panel88 = new System.Windows.Forms.Panel();
            this.label66 = new System.Windows.Forms.Label();
            this.label59 = new System.Windows.Forms.Label();
            this.exitDestY = new System.Windows.Forms.NumericUpDown();
            this.marioZCoordPlusHalf = new System.Windows.Forms.CheckBox();
            this.label60 = new System.Windows.Forms.Label();
            this.exitDestX = new System.Windows.Forms.NumericUpDown();
            this.exitDestZ = new System.Windows.Forms.NumericUpDown();
            this.label122 = new System.Windows.Forms.Label();
            this.label124 = new System.Windows.Forms.Label();
            this.panel48 = new System.Windows.Forms.Panel();
            this.exitDestFace = new System.Windows.Forms.ComboBox();
            this.exitsFieldTree = new System.Windows.Forms.TreeView();
            this.panel87 = new System.Windows.Forms.Panel();
            this.label119 = new System.Windows.Forms.Label();
            this.exits135LengthPlusHalf = new System.Windows.Forms.CheckBox();
            this.label58 = new System.Windows.Forms.Label();
            this.exits45LengthPlusHalf = new System.Windows.Forms.CheckBox();
            this.exitLength = new System.Windows.Forms.NumericUpDown();
            this.label105 = new System.Windows.Forms.Label();
            this.exitZ = new System.Windows.Forms.NumericUpDown();
            this.exitY = new System.Windows.Forms.NumericUpDown();
            this.exitX = new System.Windows.Forms.NumericUpDown();
            this.exitsShowMessage = new System.Windows.Forms.CheckBox();
            this.exitHeight = new System.Windows.Forms.NumericUpDown();
            this.label37 = new System.Windows.Forms.Label();
            this.label55 = new System.Windows.Forms.Label();
            this.label57 = new System.Windows.Forms.Label();
            this.label120 = new System.Windows.Forms.Label();
            this.panel49 = new System.Windows.Forms.Panel();
            this.exitFace = new System.Windows.Forms.ComboBox();
            this.label47 = new System.Windows.Forms.Label();
            this.panel50 = new System.Windows.Forms.Panel();
            this.exitType = new System.Windows.Forms.ComboBox();
            this.panel51 = new System.Windows.Forms.Panel();
            this.exitDest = new System.Windows.Forms.ComboBox();
            this.panel68 = new System.Windows.Forms.Panel();
            this.toolStrip5 = new System.Windows.Forms.ToolStrip();
            this.exitsInsertField = new System.Windows.Forms.ToolStripButton();
            this.exitsDeleteField = new System.Windows.Forms.ToolStripButton();
            this.exitsCopyField = new System.Windows.Forms.ToolStripButton();
            this.exitsPasteField = new System.Windows.Forms.ToolStripButton();
            this.exitsDuplicateField = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator19 = new System.Windows.Forms.ToolStripSeparator();
            this.exitsBytesLeft = new System.Windows.Forms.ToolStripLabel();
            this.label61 = new System.Windows.Forms.Label();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.panel70 = new System.Windows.Forms.Panel();
            this.label89 = new System.Windows.Forms.Label();
            this.mapTilemapL1Num = new System.Windows.Forms.NumericUpDown();
            this.mapSetL3Priority = new System.Windows.Forms.CheckBox();
            this.mapTilemapL2Num = new System.Windows.Forms.NumericUpDown();
            this.panel35 = new System.Windows.Forms.Panel();
            this.mapBattlefieldName = new System.Windows.Forms.ComboBox();
            this.label43 = new System.Windows.Forms.Label();
            this.mapTilemapL3Num = new System.Windows.Forms.NumericUpDown();
            this.panel36 = new System.Windows.Forms.Panel();
            this.mapTilemapL3Name = new System.Windows.Forms.ComboBox();
            this.label42 = new System.Windows.Forms.Label();
            this.panel37 = new System.Windows.Forms.Panel();
            this.mapTilemapL1Name = new System.Windows.Forms.ComboBox();
            this.label41 = new System.Windows.Forms.Label();
            this.panel38 = new System.Windows.Forms.Panel();
            this.mapPhysicalMapName = new System.Windows.Forms.ComboBox();
            this.mapPhysicalMapNum = new System.Windows.Forms.NumericUpDown();
            this.label45 = new System.Windows.Forms.Label();
            this.panel39 = new System.Windows.Forms.Panel();
            this.mapTilemapL2Name = new System.Windows.Forms.ComboBox();
            this.label76 = new System.Windows.Forms.Label();
            this.mapBattlefieldNum = new System.Windows.Forms.NumericUpDown();
            this.panel69 = new System.Windows.Forms.Panel();
            this.label114 = new System.Windows.Forms.Label();
            this.panel40 = new System.Windows.Forms.Panel();
            this.mapPaletteSetName = new System.Windows.Forms.ComboBox();
            this.mapPaletteSetNum = new System.Windows.Forms.NumericUpDown();
            this.label46 = new System.Windows.Forms.Label();
            this.panel71 = new System.Windows.Forms.Panel();
            this.label88 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.mapTilesetL3Num = new System.Windows.Forms.NumericUpDown();
            this.mapTilesetL2Num = new System.Windows.Forms.NumericUpDown();
            this.mapTilesetL1Num = new System.Windows.Forms.NumericUpDown();
            this.panel32 = new System.Windows.Forms.Panel();
            this.mapTilesetL2Name = new System.Windows.Forms.ComboBox();
            this.label34 = new System.Windows.Forms.Label();
            this.panel33 = new System.Windows.Forms.Panel();
            this.mapTilesetL3Name = new System.Windows.Forms.ComboBox();
            this.panel34 = new System.Windows.Forms.Panel();
            this.mapTilesetL1Name = new System.Windows.Forms.ComboBox();
            this.panel72 = new System.Windows.Forms.Panel();
            this.label87 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.mapGFXSet1Num = new System.Windows.Forms.NumericUpDown();
            this.mapGFXSet2Num = new System.Windows.Forms.NumericUpDown();
            this.panel31 = new System.Windows.Forms.Panel();
            this.mapGFXSetL3Name = new System.Windows.Forms.ComboBox();
            this.panel29 = new System.Windows.Forms.Panel();
            this.mapGFXSet4Name = new System.Windows.Forms.ComboBox();
            this.mapGFXSet3Num = new System.Windows.Forms.NumericUpDown();
            this.panel12 = new System.Windows.Forms.Panel();
            this.mapGFXSet2Name = new System.Windows.Forms.ComboBox();
            this.panel30 = new System.Windows.Forms.Panel();
            this.mapGFXSet5Name = new System.Windows.Forms.ComboBox();
            this.mapGFXSet4Num = new System.Windows.Forms.NumericUpDown();
            this.panel13 = new System.Windows.Forms.Panel();
            this.mapGFXSet3Name = new System.Windows.Forms.ComboBox();
            this.mapGFXSetL3Num = new System.Windows.Forms.NumericUpDown();
            this.mapGFXSet5Num = new System.Windows.Forms.NumericUpDown();
            this.panel11 = new System.Windows.Forms.Panel();
            this.mapGFXSet1Name = new System.Windows.Forms.ComboBox();
            this.panel28 = new System.Windows.Forms.Panel();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.panel79 = new System.Windows.Forms.Panel();
            this.label110 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.panel22 = new System.Windows.Forms.Panel();
            this.layerL3Effects = new System.Windows.Forms.ComboBox();
            this.panel26 = new System.Windows.Forms.Panel();
            this.layerOBJEffects = new System.Windows.Forms.ComboBox();
            this.layerWaveEffect = new System.Windows.Forms.CheckBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label53 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.layerMessageBox = new System.Windows.Forms.ComboBox();
            this.panel73 = new System.Windows.Forms.Panel();
            this.panel86 = new System.Windows.Forms.Panel();
            this.label86 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.layerPrioritySet = new System.Windows.Forms.NumericUpDown();
            this.layerMainscreenL1 = new System.Windows.Forms.CheckBox();
            this.layerSubscreenL1 = new System.Windows.Forms.CheckBox();
            this.layerColorMathL1 = new System.Windows.Forms.CheckBox();
            this.layerMainscreenL2 = new System.Windows.Forms.CheckBox();
            this.layerSubscreenL2 = new System.Windows.Forms.CheckBox();
            this.layerColorMathL2 = new System.Windows.Forms.CheckBox();
            this.layerMainscreenL3 = new System.Windows.Forms.CheckBox();
            this.layerSubscreenL3 = new System.Windows.Forms.CheckBox();
            this.layerColorMathL3 = new System.Windows.Forms.CheckBox();
            this.layerMainscreenNPC = new System.Windows.Forms.CheckBox();
            this.layerSubscreenNPC = new System.Windows.Forms.CheckBox();
            this.panel17 = new System.Windows.Forms.Panel();
            this.layerColorMathMode = new System.Windows.Forms.ComboBox();
            this.layerColorMathNPC = new System.Windows.Forms.CheckBox();
            this.panel14 = new System.Windows.Forms.Panel();
            this.layerColorMathIntensity = new System.Windows.Forms.ComboBox();
            this.layerColorMathBG = new System.Windows.Forms.CheckBox();
            this.label96 = new System.Windows.Forms.Label();
            this.checkBox15 = new System.Windows.Forms.CheckBox();
            this.label95 = new System.Windows.Forms.Label();
            this.checkBox16 = new System.Windows.Forms.CheckBox();
            this.label22 = new System.Windows.Forms.Label();
            this.panel78 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label85 = new System.Windows.Forms.Label();
            this.label84 = new System.Windows.Forms.Label();
            this.label83 = new System.Windows.Forms.Label();
            this.label82 = new System.Windows.Forms.Label();
            this.panel21 = new System.Windows.Forms.Panel();
            this.layerL2ScrollDirection = new System.Windows.Forms.ComboBox();
            this.panel23 = new System.Windows.Forms.Panel();
            this.layerL2ScrollSpeed = new System.Windows.Forms.ComboBox();
            this.panel24 = new System.Windows.Forms.Panel();
            this.layerL3ScrollDirection = new System.Windows.Forms.ComboBox();
            this.layerInfiniteAutoscroll = new System.Windows.Forms.CheckBox();
            this.panel25 = new System.Windows.Forms.Panel();
            this.layerL3ScrollSpeed = new System.Windows.Forms.ComboBox();
            this.layerL2ScrollShift = new System.Windows.Forms.CheckBox();
            this.layerL3ScrollShift = new System.Windows.Forms.CheckBox();
            this.panel74 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.layerMaskHighX = new System.Windows.Forms.NumericUpDown();
            this.layerLockMask = new System.Windows.Forms.CheckBox();
            this.layerMaskLowX = new System.Windows.Forms.NumericUpDown();
            this.label25 = new System.Windows.Forms.Label();
            this.layerMaskHighY = new System.Windows.Forms.NumericUpDown();
            this.label24 = new System.Windows.Forms.Label();
            this.layerMaskLowY = new System.Windows.Forms.NumericUpDown();
            this.label15 = new System.Windows.Forms.Label();
            this.labeasdfasd = new System.Windows.Forms.Label();
            this.panel77 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel16 = new System.Windows.Forms.Panel();
            this.layerL2VSync = new System.Windows.Forms.ComboBox();
            this.panel19 = new System.Windows.Forms.Panel();
            this.layerL3VSync = new System.Windows.Forms.ComboBox();
            this.panel18 = new System.Windows.Forms.Panel();
            this.layerL2HSync = new System.Windows.Forms.ComboBox();
            this.panel20 = new System.Windows.Forms.Panel();
            this.layerL3HSync = new System.Windows.Forms.ComboBox();
            this.panel75 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.layerL2LeftShift = new System.Windows.Forms.NumericUpDown();
            this.layerL2UpShift = new System.Windows.Forms.NumericUpDown();
            this.label23 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.layerL3LeftShift = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.layerL3UpShift = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.panel76 = new System.Windows.Forms.Panel();
            this.label91 = new System.Windows.Forms.Label();
            this.layerScrollWrapping = new System.Windows.Forms.CheckedListBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel15 = new System.Windows.Forms.Panel();
            this.tileModsLayers = new System.Windows.Forms.CheckedListBox();
            this.label26 = new System.Windows.Forms.Label();
            this.tileModsY = new System.Windows.Forms.NumericUpDown();
            this.label27 = new System.Windows.Forms.Label();
            this.tileModsX = new System.Windows.Forms.NumericUpDown();
            this.tileModsHeight = new System.Windows.Forms.NumericUpDown();
            this.tileModsWidth = new System.Windows.Forms.NumericUpDown();
            this.label36 = new System.Windows.Forms.Label();
            this.label50 = new System.Windows.Forms.Label();
            this.tileModsFieldTree = new System.Windows.Forms.TreeView();
            this.toolStrip7 = new System.Windows.Forms.ToolStrip();
            this.tileModsInsertField = new System.Windows.Forms.ToolStripButton();
            this.tileModsInsertInstance = new System.Windows.Forms.ToolStripButton();
            this.tileModsDeleteField = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.tileModsMoveUp = new System.Windows.Forms.ToolStripButton();
            this.tileModsMoveDown = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.tileModsCopy = new System.Windows.Forms.ToolStripButton();
            this.tileModsPaste = new System.Windows.Forms.ToolStripButton();
            this.tileModsDuplicate = new System.Windows.Forms.ToolStripButton();
            this.label69 = new System.Windows.Forms.Label();
            this.panel55 = new System.Windows.Forms.Panel();
            this.panel27 = new System.Windows.Forms.Panel();
            this.panel44 = new System.Windows.Forms.Panel();
            this.label14 = new System.Windows.Forms.Label();
            this.solidModsY = new System.Windows.Forms.NumericUpDown();
            this.label51 = new System.Windows.Forms.Label();
            this.solidModsX = new System.Windows.Forms.NumericUpDown();
            this.solidModsHeight = new System.Windows.Forms.NumericUpDown();
            this.solidModsWidth = new System.Windows.Forms.NumericUpDown();
            this.label64 = new System.Windows.Forms.Label();
            this.label67 = new System.Windows.Forms.Label();
            this.solidModsFieldTree = new System.Windows.Forms.TreeView();
            this.toolStrip8 = new System.Windows.Forms.ToolStrip();
            this.solidModsInsert = new System.Windows.Forms.ToolStripButton();
            this.solidModsDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
            this.solidModsMoveUp = new System.Windows.Forms.ToolStripButton();
            this.solidModsMoveDown = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator14 = new System.Windows.Forms.ToolStripSeparator();
            this.solidModsCopy = new System.Windows.Forms.ToolStripButton();
            this.solidModsPaste = new System.Windows.Forms.ToolStripButton();
            this.solidModsDuplicate = new System.Windows.Forms.ToolStripButton();
            this.label68 = new System.Windows.Forms.Label();
            this.panel45 = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.nameTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.searchLevelNames = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.changeLevelName = new System.Windows.Forms.ToolStripButton();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator21 = new System.Windows.Forms.ToolStripSeparator();
            this.buttonGotoC = new System.Windows.Forms.ToolStripButton();
            this.eventExit = new LAZYSHELL.ToolStripNumericUpDown();
            this.toolStripSeparator16 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.eventMusic = new System.Windows.Forms.ToolStripComboBox();
            this.hexEditor = new System.Windows.Forms.ToolStripButton();
            this.propertiesButton = new System.Windows.Forms.ToolStripButton();
            this.openTileset = new System.Windows.Forms.ToolStripButton();
            this.openTilemap = new System.Windows.Forms.ToolStripButton();
            this.openSolidTileset = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.openPaletteEditor = new System.Windows.Forms.ToolStripButton();
            this.openGraphicEditor = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.openTemplates = new System.Windows.Forms.ToolStripButton();
            this.levelPreviewToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.spaceAnalyzer = new System.Windows.Forms.ToolStripButton();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panelLevels = new System.Windows.Forms.Panel();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.save = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.import = new System.Windows.Forms.ToolStripDropDownButton();
            this.allToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importArchitectureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator30 = new System.Windows.Forms.ToolStripSeparator();
            this.arraysToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.graphicSetsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.export = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.exportArchitectureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator28 = new System.Windows.Forms.ToolStripSeparator();
            this.arraysToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.graphicSetsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportLevelImagesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator32 = new System.Windows.Forms.ToolStripSeparator();
            this.dumpTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.resetLevelMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetLayerDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetNPCDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetEventDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetExitDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetOverlapDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetTilemapModsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetSolidityModsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.resetPaletteSetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetGraphicSetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetTilesetsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetTilemapsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetSolidityMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.resetAllComponentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clear = new System.Windows.Forms.ToolStripDropDownButton();
            this.clearLevelDataAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator38 = new System.Windows.Forms.ToolStripSeparator();
            this.clearTilesetsAll = new System.Windows.Forms.ToolStripMenuItem();
            this.clearTilemapsAll = new System.Windows.Forms.ToolStripMenuItem();
            this.clearPhysicalMapsAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator29 = new System.Windows.Forms.ToolStripSeparator();
            this.unusedGraphicSetsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unusedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unusedToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.unusedToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.unusedToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.clearAllComponentsAll = new System.Windows.Forms.ToolStripMenuItem();
            this.clearAllComponentsCurrent = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.levelInfo = new LAZYSHELL.ToolStripListView();
            this.help = new System.Windows.Forms.ToolStripButton();
            this.baseConversion = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator15 = new System.Windows.Forms.ToolStripSeparator();
            this.tileModsBytesLeft = new System.Windows.Forms.Label();
            this.solidModsBytesLeft = new System.Windows.Forms.Label();
            this.tabPage8.SuspendLayout();
            this.toolStrip3.SuspendLayout();
            this.panel85.SuspendLayout();
            this.panel118.SuspendLayout();
            this.panel119.SuspendLayout();
            this.panel83.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.npcID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.npcMovement)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.npcSpeedPlus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.npcEventORPack)).BeginInit();
            this.panel43.SuspendLayout();
            this.panel53.SuspendLayout();
            this.panel80.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.npcMapHeader)).BeginInit();
            this.panel84.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.npcX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.npcY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.npcZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.npcPropertyA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.npcPropertyB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.npcPropertyC)).BeginInit();
            this.panel42.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mapNum)).BeginInit();
            this.contextMenuStrip4.SuspendLayout();
            this.tabPage10.SuspendLayout();
            this.panel1.SuspendLayout();
            this.toolStrip4.SuspendLayout();
            this.panel99.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.overlapType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.overlapX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.overlapY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.overlapZ)).BeginInit();
            this.panelOverlapTileset.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOverlaps)).BeginInit();
            this.tabPage9.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel90.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eventLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eventY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eventX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eventZ)).BeginInit();
            this.panel46.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eventHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eventEvent)).BeginInit();
            this.toolStrip6.SuspendLayout();
            this.panel52.SuspendLayout();
            this.panel88.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.exitDestY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exitDestX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exitDestZ)).BeginInit();
            this.panel48.SuspendLayout();
            this.panel87.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.exitLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exitZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exitY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exitX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exitHeight)).BeginInit();
            this.panel49.SuspendLayout();
            this.panel50.SuspendLayout();
            this.panel51.SuspendLayout();
            this.toolStrip5.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.panel70.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mapTilemapL1Num)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mapTilemapL2Num)).BeginInit();
            this.panel35.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mapTilemapL3Num)).BeginInit();
            this.panel36.SuspendLayout();
            this.panel37.SuspendLayout();
            this.panel38.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mapPhysicalMapNum)).BeginInit();
            this.panel39.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mapBattlefieldNum)).BeginInit();
            this.panel69.SuspendLayout();
            this.panel40.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mapPaletteSetNum)).BeginInit();
            this.panel71.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mapTilesetL3Num)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mapTilesetL2Num)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mapTilesetL1Num)).BeginInit();
            this.panel32.SuspendLayout();
            this.panel33.SuspendLayout();
            this.panel34.SuspendLayout();
            this.panel72.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mapGFXSet1Num)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mapGFXSet2Num)).BeginInit();
            this.panel31.SuspendLayout();
            this.panel29.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mapGFXSet3Num)).BeginInit();
            this.panel12.SuspendLayout();
            this.panel30.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mapGFXSet4Num)).BeginInit();
            this.panel13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mapGFXSetL3Num)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mapGFXSet5Num)).BeginInit();
            this.panel11.SuspendLayout();
            this.panel28.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.panel79.SuspendLayout();
            this.panel22.SuspendLayout();
            this.panel26.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel73.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layerPrioritySet)).BeginInit();
            this.panel17.SuspendLayout();
            this.panel14.SuspendLayout();
            this.panel78.SuspendLayout();
            this.panel21.SuspendLayout();
            this.panel23.SuspendLayout();
            this.panel24.SuspendLayout();
            this.panel25.SuspendLayout();
            this.panel74.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layerMaskHighX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layerMaskLowX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layerMaskHighY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layerMaskLowY)).BeginInit();
            this.panel77.SuspendLayout();
            this.panel16.SuspendLayout();
            this.panel19.SuspendLayout();
            this.panel18.SuspendLayout();
            this.panel20.SuspendLayout();
            this.panel75.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layerL2LeftShift)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layerL2UpShift)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layerL3LeftShift)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layerL3UpShift)).BeginInit();
            this.panel76.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel15.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tileModsY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tileModsX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tileModsHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tileModsWidth)).BeginInit();
            this.toolStrip7.SuspendLayout();
            this.panel27.SuspendLayout();
            this.panel44.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.solidModsY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.solidModsX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.solidModsHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.solidModsWidth)).BeginInit();
            this.toolStrip8.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panelLevels.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // levelNum
            // 
            this.levelNum.AutoSize = false;
            this.levelNum.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.levelNum.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.levelNum.ForeColor = System.Drawing.SystemColors.Control;
            this.levelNum.Hexadecimal = false;
            this.levelNum.Location = new System.Drawing.Point(209, 2);
            this.levelNum.Maximum = new decimal(new int[] {
            509,
            0,
            0,
            0});
            this.levelNum.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.levelNum.Name = "levelNum";
            this.levelNum.Size = new System.Drawing.Size(60, 21);
            this.levelNum.Text = "0";
            this.levelNum.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.levelNum.ValueChanged += new System.EventHandler(this.levelNum_ValueChanged);
            // 
            // levelName
            // 
            this.levelName.AutoSize = false;
            this.levelName.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.levelName.DropDownHeight = 500;
            this.levelName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.levelName.DropDownWidth = 500;
            this.levelName.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.levelName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.levelName.ForeColor = System.Drawing.SystemColors.Control;
            this.levelName.IntegralHeight = false;
            this.levelName.Name = "levelName";
            this.levelName.Size = new System.Drawing.Size(200, 21);
            this.levelName.SelectedIndexChanged += new System.EventHandler(this.levelName_SelectedIndexChanged);
            // 
            // tabPage8
            // 
            this.tabPage8.Controls.Add(this.toolStrip3);
            this.tabPage8.Controls.Add(this.panel85);
            this.tabPage8.Controls.Add(this.panel118);
            this.tabPage8.Controls.Add(this.panel83);
            this.tabPage8.Controls.Add(this.panel80);
            this.tabPage8.Controls.Add(this.npcsBytesLeft);
            this.tabPage8.Controls.Add(this.npcObjectTree);
            this.tabPage8.Controls.Add(this.panel84);
            this.tabPage8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage8.Location = new System.Drawing.Point(4, 22);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Size = new System.Drawing.Size(260, 640);
            this.tabPage8.TabIndex = 2;
            this.tabPage8.Text = "NPCS";
            this.tabPage8.UseVisualStyleBackColor = true;
            // 
            // toolStrip3
            // 
            this.toolStrip3.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip3.CanOverflow = false;
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.npcInsertObject,
            this.npcInsertInstance,
            this.npcRemoveObject,
            this.npcCopy,
            this.npcPaste,
            this.npcDuplicate,
            this.toolStripSeparator10,
            this.npcMoveUp,
            this.npcMoveDown,
            this.toolStripSeparator9,
            this.findNPCNum,
            this.openPartitions});
            this.toolStrip3.Location = new System.Drawing.Point(0, 0);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip3.Size = new System.Drawing.Size(260, 25);
            this.toolStrip3.TabIndex = 486;
            this.toolStrip3.Text = "toolStrip3";
            // 
            // npcInsertObject
            // 
            this.npcInsertObject.AutoSize = false;
            this.npcInsertObject.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.npcInsertObject.Image = global::LAZYSHELL.Properties.Resources.new_small;
            this.npcInsertObject.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.npcInsertObject.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.npcInsertObject.Name = "npcInsertObject";
            this.npcInsertObject.Size = new System.Drawing.Size(23, 22);
            this.npcInsertObject.Text = "New NPC";
            this.npcInsertObject.Click += new System.EventHandler(this.npcInsertObject_Click);
            // 
            // npcInsertInstance
            // 
            this.npcInsertInstance.AutoSize = false;
            this.npcInsertInstance.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.npcInsertInstance.Image = global::LAZYSHELL.Properties.Resources.newInstance;
            this.npcInsertInstance.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.npcInsertInstance.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.npcInsertInstance.Name = "npcInsertInstance";
            this.npcInsertInstance.Size = new System.Drawing.Size(23, 22);
            this.npcInsertInstance.Text = "New NPC Instance";
            this.npcInsertInstance.Click += new System.EventHandler(this.npcInsertInstance_Click);
            // 
            // npcRemoveObject
            // 
            this.npcRemoveObject.AutoSize = false;
            this.npcRemoveObject.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.npcRemoveObject.Image = global::LAZYSHELL.Properties.Resources.delete_small;
            this.npcRemoveObject.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.npcRemoveObject.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.npcRemoveObject.Name = "npcRemoveObject";
            this.npcRemoveObject.Size = new System.Drawing.Size(23, 22);
            this.npcRemoveObject.Text = "Delete NPC";
            this.npcRemoveObject.Click += new System.EventHandler(this.npcRemoveObject_Click);
            // 
            // npcCopy
            // 
            this.npcCopy.AutoSize = false;
            this.npcCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.npcCopy.Image = global::LAZYSHELL.Properties.Resources.copy_small;
            this.npcCopy.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.npcCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.npcCopy.Name = "npcCopy";
            this.npcCopy.Size = new System.Drawing.Size(23, 22);
            this.npcCopy.Text = "Copy NPC";
            this.npcCopy.Click += new System.EventHandler(this.npcCopy_Click);
            // 
            // npcPaste
            // 
            this.npcPaste.AutoSize = false;
            this.npcPaste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.npcPaste.Image = global::LAZYSHELL.Properties.Resources.paste_small;
            this.npcPaste.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.npcPaste.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.npcPaste.Name = "npcPaste";
            this.npcPaste.Size = new System.Drawing.Size(23, 22);
            this.npcPaste.Text = "Paste NPC";
            this.npcPaste.Click += new System.EventHandler(this.npcPaste_Click);
            // 
            // npcDuplicate
            // 
            this.npcDuplicate.AutoSize = false;
            this.npcDuplicate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.npcDuplicate.Image = global::LAZYSHELL.Properties.Resources.duplicate_small;
            this.npcDuplicate.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.npcDuplicate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.npcDuplicate.Name = "npcDuplicate";
            this.npcDuplicate.Size = new System.Drawing.Size(23, 22);
            this.npcDuplicate.Text = "Duplicate NPC";
            this.npcDuplicate.Click += new System.EventHandler(this.npcDuplicate_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(6, 25);
            // 
            // npcMoveUp
            // 
            this.npcMoveUp.AutoSize = false;
            this.npcMoveUp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.npcMoveUp.Image = global::LAZYSHELL.Properties.Resources.moveup;
            this.npcMoveUp.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.npcMoveUp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.npcMoveUp.Name = "npcMoveUp";
            this.npcMoveUp.Size = new System.Drawing.Size(23, 22);
            this.npcMoveUp.Text = "Move NPC Up";
            this.npcMoveUp.Click += new System.EventHandler(this.npcMoveUp_Click);
            // 
            // npcMoveDown
            // 
            this.npcMoveDown.AutoSize = false;
            this.npcMoveDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.npcMoveDown.Image = global::LAZYSHELL.Properties.Resources.movedown;
            this.npcMoveDown.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.npcMoveDown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.npcMoveDown.Name = "npcMoveDown";
            this.npcMoveDown.Size = new System.Drawing.Size(23, 22);
            this.npcMoveDown.Text = "Move NPC Down";
            this.npcMoveDown.Click += new System.EventHandler(this.npcMoveDown_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(6, 25);
            // 
            // findNPCNum
            // 
            this.findNPCNum.AutoSize = false;
            this.findNPCNum.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.findNPCNum.Image = global::LAZYSHELL.Properties.Resources.openNPCs;
            this.findNPCNum.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.findNPCNum.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.findNPCNum.Name = "findNPCNum";
            this.findNPCNum.Size = new System.Drawing.Size(23, 22);
            this.findNPCNum.Click += new System.EventHandler(this.findNPCNum_Click);
            // 
            // openPartitions
            // 
            this.openPartitions.AutoSize = false;
            this.openPartitions.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openPartitions.Image = global::LAZYSHELL.Properties.Resources.openPartitions;
            this.openPartitions.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.openPartitions.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openPartitions.Name = "openPartitions";
            this.openPartitions.Size = new System.Drawing.Size(23, 22);
            this.openPartitions.Click += new System.EventHandler(this.openPartitions_Click);
            // 
            // panel85
            // 
            this.panel85.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel85.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel85.Controls.Add(this.npcAttributes);
            this.panel85.Controls.Add(this.label65);
            this.panel85.Location = new System.Drawing.Point(0, 413);
            this.panel85.Name = "panel85";
            this.panel85.Size = new System.Drawing.Size(260, 151);
            this.panel85.TabIndex = 485;
            // 
            // npcAttributes
            // 
            this.npcAttributes.BackColor = System.Drawing.SystemColors.Window;
            this.npcAttributes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.npcAttributes.CheckOnClick = true;
            this.npcAttributes.ColumnWidth = 126;
            this.npcAttributes.Items.AddRange(new object[] {
            "Face on trigger",
            "{B2,b4}",
            "{B2,b5}",
            "Sequence playback",
            "Can\'t float",
            "{B3,b0}",
            "Can\'t walk under",
            "Can\'t pass walls",
            "Can\'t jump through",
            "Can\'t pass NPCs",
            "{B3,b5}",
            "Can\'t walk through",
            "{B3,b7}",
            "Slidable along walls",
            "{B4,b1}"});
            this.npcAttributes.Location = new System.Drawing.Point(0, 19);
            this.npcAttributes.MultiColumn = true;
            this.npcAttributes.Name = "npcAttributes";
            this.npcAttributes.Size = new System.Drawing.Size(256, 128);
            this.npcAttributes.TabIndex = 487;
            this.npcAttributes.SelectedIndexChanged += new System.EventHandler(this.npcAttributes_SelectedIndexChanged);
            // 
            // label65
            // 
            this.label65.BackColor = System.Drawing.SystemColors.Control;
            this.label65.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label65.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label65.Location = new System.Drawing.Point(0, 0);
            this.label65.Name = "label65";
            this.label65.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label65.Size = new System.Drawing.Size(256, 17);
            this.label65.TabIndex = 475;
            this.label65.Text = "PROPERTIES...";
            this.label65.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel118
            // 
            this.panel118.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel118.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel118.Controls.Add(this.label52);
            this.panel118.Controls.Add(this.panel119);
            this.panel118.Location = new System.Drawing.Point(128, 371);
            this.panel118.Name = "panel118";
            this.panel118.Size = new System.Drawing.Size(132, 40);
            this.panel118.TabIndex = 479;
            // 
            // label52
            // 
            this.label52.BackColor = System.Drawing.SystemColors.Control;
            this.label52.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label52.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label52.Location = new System.Drawing.Point(0, 0);
            this.label52.Name = "label52";
            this.label52.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label52.Size = new System.Drawing.Size(128, 17);
            this.label52.TabIndex = 478;
            this.label52.Text = "AFTER BATTLE...";
            // 
            // panel119
            // 
            this.panel119.BackColor = System.Drawing.SystemColors.Window;
            this.panel119.Controls.Add(this.npcAfterBattle);
            this.panel119.Location = new System.Drawing.Point(0, 19);
            this.panel119.Name = "panel119";
            this.panel119.Size = new System.Drawing.Size(128, 17);
            this.panel119.TabIndex = 477;
            // 
            // npcAfterBattle
            // 
            this.npcAfterBattle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.npcAfterBattle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.npcAfterBattle.DropDownWidth = 350;
            this.npcAfterBattle.IntegralHeight = false;
            this.npcAfterBattle.Items.AddRange(new object[] {
            "remove permanently (from level memory)",
            "remove temporarily (return on level re-entry)",
            "do not remove at all (disable trigger)",
            "remove permanently (if ran away, can walk through while blinking)",
            "remove temporarily (if ran away, can walk through while blinking)"});
            this.npcAfterBattle.Location = new System.Drawing.Point(-2, -2);
            this.npcAfterBattle.Name = "npcAfterBattle";
            this.npcAfterBattle.Size = new System.Drawing.Size(132, 21);
            this.npcAfterBattle.TabIndex = 205;
            this.npcAfterBattle.SelectedIndexChanged += new System.EventHandler(this.npcAfterBattle_SelectedIndexChanged);
            // 
            // panel83
            // 
            this.panel83.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel83.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel83.Controls.Add(this.npcID);
            this.panel83.Controls.Add(this.label49);
            this.panel83.Controls.Add(this.npcMovement);
            this.panel83.Controls.Add(this.npcSpeedPlus);
            this.panel83.Controls.Add(this.npcEventORPack);
            this.panel83.Controls.Add(this.label54);
            this.panel83.Controls.Add(this.label117);
            this.panel83.Controls.Add(this.label70);
            this.panel83.Controls.Add(this.buttonGotoB);
            this.panel83.Controls.Add(this.buttonGotoA);
            this.panel83.Controls.Add(this.panel43);
            this.panel83.Controls.Add(this.panel53);
            this.panel83.Location = new System.Drawing.Point(128, 51);
            this.panel83.Name = "panel83";
            this.panel83.Size = new System.Drawing.Size(132, 151);
            this.panel83.TabIndex = 483;
            // 
            // npcID
            // 
            this.npcID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.npcID.Location = new System.Drawing.Point(68, 76);
            this.npcID.Maximum = new decimal(new int[] {
            511,
            0,
            0,
            0});
            this.npcID.Name = "npcID";
            this.npcID.Size = new System.Drawing.Size(60, 17);
            this.npcID.TabIndex = 98;
            this.npcID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.npcID.ValueChanged += new System.EventHandler(this.npcID_ValueChanged);
            // 
            // label49
            // 
            this.label49.BackColor = System.Drawing.SystemColors.Control;
            this.label49.Location = new System.Drawing.Point(0, 76);
            this.label49.Name = "label49";
            this.label49.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label49.Size = new System.Drawing.Size(67, 17);
            this.label49.TabIndex = 452;
            this.label49.Text = "NPC #";
            // 
            // npcMovement
            // 
            this.npcMovement.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.npcMovement.Location = new System.Drawing.Point(68, 112);
            this.npcMovement.Maximum = new decimal(new int[] {
            1023,
            0,
            0,
            0});
            this.npcMovement.Name = "npcMovement";
            this.npcMovement.Size = new System.Drawing.Size(60, 17);
            this.npcMovement.TabIndex = 101;
            this.npcMovement.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.npcMovement.ValueChanged += new System.EventHandler(this.npcMovement_ValueChanged);
            // 
            // npcSpeedPlus
            // 
            this.npcSpeedPlus.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.npcSpeedPlus.Location = new System.Drawing.Point(68, 130);
            this.npcSpeedPlus.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.npcSpeedPlus.Name = "npcSpeedPlus";
            this.npcSpeedPlus.Size = new System.Drawing.Size(60, 17);
            this.npcSpeedPlus.TabIndex = 103;
            this.npcSpeedPlus.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.npcSpeedPlus.ValueChanged += new System.EventHandler(this.npcSpeedPlus_ValueChanged);
            // 
            // npcEventORPack
            // 
            this.npcEventORPack.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.npcEventORPack.Location = new System.Drawing.Point(68, 94);
            this.npcEventORPack.Maximum = new decimal(new int[] {
            4095,
            0,
            0,
            0});
            this.npcEventORPack.Name = "npcEventORPack";
            this.npcEventORPack.Size = new System.Drawing.Size(60, 17);
            this.npcEventORPack.TabIndex = 100;
            this.npcEventORPack.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.npcEventORPack.ValueChanged += new System.EventHandler(this.npcEventORPack_ValueChanged);
            // 
            // label54
            // 
            this.label54.BackColor = System.Drawing.SystemColors.Control;
            this.label54.Location = new System.Drawing.Point(0, 130);
            this.label54.Name = "label54";
            this.label54.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label54.Size = new System.Drawing.Size(67, 17);
            this.label54.TabIndex = 460;
            this.label54.Text = "Speed +";
            // 
            // label117
            // 
            this.label117.BackColor = System.Drawing.SystemColors.Control;
            this.label117.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label117.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label117.Location = new System.Drawing.Point(0, 0);
            this.label117.Name = "label117";
            this.label117.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label117.Size = new System.Drawing.Size(128, 17);
            this.label117.TabIndex = 477;
            this.label117.Text = "NPC TYPE";
            // 
            // label70
            // 
            this.label70.BackColor = System.Drawing.SystemColors.Control;
            this.label70.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label70.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label70.Location = new System.Drawing.Point(0, 38);
            this.label70.Name = "label70";
            this.label70.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label70.Size = new System.Drawing.Size(128, 17);
            this.label70.TabIndex = 476;
            this.label70.Text = "TRIGGER";
            // 
            // buttonGotoB
            // 
            this.buttonGotoB.BackColor = System.Drawing.SystemColors.Control;
            this.buttonGotoB.FlatAppearance.BorderSize = 0;
            this.buttonGotoB.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonGotoB.Location = new System.Drawing.Point(0, 112);
            this.buttonGotoB.Name = "buttonGotoB";
            this.buttonGotoB.Size = new System.Drawing.Size(68, 18);
            this.buttonGotoB.TabIndex = 99;
            this.buttonGotoB.Text = "Action #";
            this.buttonGotoB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.buttonGotoB, "Edit NPC action...");
            this.buttonGotoB.UseCompatibleTextRendering = true;
            this.buttonGotoB.UseVisualStyleBackColor = false;
            this.buttonGotoB.Click += new System.EventHandler(this.buttonGotoB_Click);
            // 
            // buttonGotoA
            // 
            this.buttonGotoA.BackColor = System.Drawing.SystemColors.Control;
            this.buttonGotoA.FlatAppearance.BorderSize = 0;
            this.buttonGotoA.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonGotoA.Location = new System.Drawing.Point(0, 94);
            this.buttonGotoA.Name = "buttonGotoA";
            this.buttonGotoA.Size = new System.Drawing.Size(68, 18);
            this.buttonGotoA.TabIndex = 99;
            this.buttonGotoA.Text = "Event #";
            this.buttonGotoA.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.buttonGotoA, "Edit NPC event...");
            this.buttonGotoA.UseCompatibleTextRendering = true;
            this.buttonGotoA.UseVisualStyleBackColor = false;
            this.buttonGotoA.Click += new System.EventHandler(this.buttonGotoA_Click);
            // 
            // panel43
            // 
            this.panel43.BackColor = System.Drawing.SystemColors.Window;
            this.panel43.Controls.Add(this.npcEngageType);
            this.panel43.Location = new System.Drawing.Point(0, 19);
            this.panel43.Name = "panel43";
            this.panel43.Size = new System.Drawing.Size(128, 17);
            this.panel43.TabIndex = 96;
            // 
            // npcEngageType
            // 
            this.npcEngageType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.npcEngageType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.npcEngageType.Items.AddRange(new object[] {
            "Object",
            "Treasure",
            "Battle"});
            this.npcEngageType.Location = new System.Drawing.Point(-2, -2);
            this.npcEngageType.Name = "npcEngageType";
            this.npcEngageType.Size = new System.Drawing.Size(132, 21);
            this.npcEngageType.TabIndex = 206;
            this.npcEngageType.SelectedIndexChanged += new System.EventHandler(this.npcEngageType_SelectedIndexChanged);
            // 
            // panel53
            // 
            this.panel53.BackColor = System.Drawing.SystemColors.Window;
            this.panel53.Controls.Add(this.npcEngageTrigger);
            this.panel53.Location = new System.Drawing.Point(0, 57);
            this.panel53.Name = "panel53";
            this.panel53.Size = new System.Drawing.Size(128, 17);
            this.panel53.TabIndex = 97;
            // 
            // npcEngageTrigger
            // 
            this.npcEngageTrigger.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.npcEngageTrigger.DropDownHeight = 171;
            this.npcEngageTrigger.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.npcEngageTrigger.DropDownWidth = 210;
            this.npcEngageTrigger.IntegralHeight = false;
            this.npcEngageTrigger.Items.AddRange(new object[] {
            "(none)",
            "press A from any side",
            "press A from front",
            "do anything EXCEPT touch any side",
            "press A from any side / touch any side",
            "press A from front / touch from front",
            "do anything",
            "hit from below",
            "jump on",
            "jump on / hit from below",
            "touch any side",
            "touch from front",
            "do anything EXCEPT press A"});
            this.npcEngageTrigger.Location = new System.Drawing.Point(-2, -2);
            this.npcEngageTrigger.Name = "npcEngageTrigger";
            this.npcEngageTrigger.Size = new System.Drawing.Size(132, 21);
            this.npcEngageTrigger.TabIndex = 205;
            this.npcEngageTrigger.SelectedIndexChanged += new System.EventHandler(this.npcEngageTrigger_SelectedIndexChanged);
            // 
            // panel80
            // 
            this.panel80.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel80.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel80.Controls.Add(this.label48);
            this.panel80.Controls.Add(this.npcMapHeader);
            this.panel80.Location = new System.Drawing.Point(128, 28);
            this.panel80.Name = "panel80";
            this.panel80.Size = new System.Drawing.Size(132, 21);
            this.panel80.TabIndex = 480;
            // 
            // label48
            // 
            this.label48.BackColor = System.Drawing.SystemColors.Control;
            this.label48.Location = new System.Drawing.Point(0, 0);
            this.label48.Name = "label48";
            this.label48.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label48.Size = new System.Drawing.Size(67, 17);
            this.label48.TabIndex = 449;
            this.label48.Text = "Partition #";
            // 
            // npcMapHeader
            // 
            this.npcMapHeader.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.npcMapHeader.Location = new System.Drawing.Point(68, 0);
            this.npcMapHeader.Maximum = new decimal(new int[] {
            119,
            0,
            0,
            0});
            this.npcMapHeader.Name = "npcMapHeader";
            this.npcMapHeader.Size = new System.Drawing.Size(60, 17);
            this.npcMapHeader.TabIndex = 89;
            this.npcMapHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.npcMapHeader.ValueChanged += new System.EventHandler(this.npcMapHeader_ValueChanged);
            // 
            // npcsBytesLeft
            // 
            this.npcsBytesLeft.BackColor = System.Drawing.SystemColors.Control;
            this.npcsBytesLeft.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.npcsBytesLeft.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.npcsBytesLeft.Location = new System.Drawing.Point(0, 28);
            this.npcsBytesLeft.Name = "npcsBytesLeft";
            this.npcsBytesLeft.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.npcsBytesLeft.Size = new System.Drawing.Size(126, 21);
            this.npcsBytesLeft.TabIndex = 498;
            this.npcsBytesLeft.Text = "bytes left";
            this.npcsBytesLeft.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // npcObjectTree
            // 
            this.npcObjectTree.HideSelection = false;
            this.npcObjectTree.HotTracking = true;
            this.npcObjectTree.Location = new System.Drawing.Point(0, 51);
            this.npcObjectTree.Name = "npcObjectTree";
            this.npcObjectTree.ShowPlusMinus = false;
            this.npcObjectTree.ShowRootLines = false;
            this.npcObjectTree.Size = new System.Drawing.Size(126, 360);
            this.npcObjectTree.TabIndex = 91;
            this.npcObjectTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.npcObjectTree_AfterSelect);
            // 
            // panel84
            // 
            this.panel84.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel84.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel84.Controls.Add(this.npcX);
            this.panel84.Controls.Add(this.npcY);
            this.panel84.Controls.Add(this.label29);
            this.panel84.Controls.Add(this.label28);
            this.panel84.Controls.Add(this.npcZ);
            this.panel84.Controls.Add(this.label56);
            this.panel84.Controls.Add(this.label30);
            this.panel84.Controls.Add(this.npcPropertyA);
            this.panel84.Controls.Add(this.label104);
            this.panel84.Controls.Add(this.npcPropertyB);
            this.panel84.Controls.Add(this.label31);
            this.panel84.Controls.Add(this.npcPropertyC);
            this.panel84.Controls.Add(this.label116);
            this.panel84.Controls.Add(this.npcZ_half);
            this.panel84.Controls.Add(this.panel42);
            this.panel84.Controls.Add(this.npcVisible);
            this.panel84.Location = new System.Drawing.Point(128, 204);
            this.panel84.Name = "panel84";
            this.panel84.Size = new System.Drawing.Size(132, 165);
            this.panel84.TabIndex = 484;
            // 
            // npcX
            // 
            this.npcX.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.npcX.Location = new System.Drawing.Point(68, 72);
            this.npcX.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.npcX.Name = "npcX";
            this.npcX.Size = new System.Drawing.Size(60, 17);
            this.npcX.TabIndex = 108;
            this.npcX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.npcX.ValueChanged += new System.EventHandler(this.npcXCoord_ValueChanged);
            // 
            // npcY
            // 
            this.npcY.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.npcY.Location = new System.Drawing.Point(68, 90);
            this.npcY.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.npcY.Name = "npcY";
            this.npcY.Size = new System.Drawing.Size(60, 17);
            this.npcY.TabIndex = 109;
            this.npcY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.npcY.ValueChanged += new System.EventHandler(this.npcYCoord_ValueChanged);
            // 
            // label29
            // 
            this.label29.BackColor = System.Drawing.SystemColors.Control;
            this.label29.Location = new System.Drawing.Point(0, 72);
            this.label29.Name = "label29";
            this.label29.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label29.Size = new System.Drawing.Size(67, 17);
            this.label29.TabIndex = 463;
            this.label29.Text = "X Coord";
            // 
            // label28
            // 
            this.label28.BackColor = System.Drawing.SystemColors.Control;
            this.label28.Location = new System.Drawing.Point(0, 90);
            this.label28.Name = "label28";
            this.label28.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label28.Size = new System.Drawing.Size(67, 17);
            this.label28.TabIndex = 464;
            this.label28.Text = "Y Coord";
            // 
            // npcZ
            // 
            this.npcZ.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.npcZ.Location = new System.Drawing.Point(68, 108);
            this.npcZ.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.npcZ.Name = "npcZ";
            this.npcZ.Size = new System.Drawing.Size(60, 17);
            this.npcZ.TabIndex = 110;
            this.npcZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.npcZ.ValueChanged += new System.EventHandler(this.npcZCoord_ValueChanged);
            // 
            // label56
            // 
            this.label56.BackColor = System.Drawing.SystemColors.Control;
            this.label56.Location = new System.Drawing.Point(0, 108);
            this.label56.Name = "label56";
            this.label56.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label56.Size = new System.Drawing.Size(67, 17);
            this.label56.TabIndex = 466;
            this.label56.Text = "Z Coord";
            // 
            // label30
            // 
            this.label30.BackColor = System.Drawing.SystemColors.Control;
            this.label30.Location = new System.Drawing.Point(0, 144);
            this.label30.Name = "label30";
            this.label30.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label30.Size = new System.Drawing.Size(67, 17);
            this.label30.TabIndex = 467;
            this.label30.Text = "Facing";
            // 
            // npcPropertyA
            // 
            this.npcPropertyA.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.npcPropertyA.Location = new System.Drawing.Point(68, 18);
            this.npcPropertyA.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.npcPropertyA.Name = "npcPropertyA";
            this.npcPropertyA.Size = new System.Drawing.Size(60, 17);
            this.npcPropertyA.TabIndex = 105;
            this.npcPropertyA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.npcPropertyA.ValueChanged += new System.EventHandler(this.npcPropertyA_ValueChanged);
            // 
            // label104
            // 
            this.label104.BackColor = System.Drawing.SystemColors.Control;
            this.label104.Location = new System.Drawing.Point(0, 18);
            this.label104.Name = "label104";
            this.label104.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label104.Size = new System.Drawing.Size(67, 17);
            this.label104.TabIndex = 469;
            // 
            // npcPropertyB
            // 
            this.npcPropertyB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.npcPropertyB.Location = new System.Drawing.Point(68, 36);
            this.npcPropertyB.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.npcPropertyB.Name = "npcPropertyB";
            this.npcPropertyB.Size = new System.Drawing.Size(60, 17);
            this.npcPropertyB.TabIndex = 106;
            this.npcPropertyB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.npcPropertyB.ValueChanged += new System.EventHandler(this.npcPropertyB_ValueChanged);
            // 
            // label31
            // 
            this.label31.BackColor = System.Drawing.SystemColors.Control;
            this.label31.Location = new System.Drawing.Point(0, 36);
            this.label31.Name = "label31";
            this.label31.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label31.Size = new System.Drawing.Size(67, 17);
            this.label31.TabIndex = 473;
            // 
            // npcPropertyC
            // 
            this.npcPropertyC.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.npcPropertyC.Location = new System.Drawing.Point(68, 54);
            this.npcPropertyC.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.npcPropertyC.Name = "npcPropertyC";
            this.npcPropertyC.Size = new System.Drawing.Size(60, 17);
            this.npcPropertyC.TabIndex = 107;
            this.npcPropertyC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.npcPropertyC.ValueChanged += new System.EventHandler(this.npcPropertyC_ValueChanged);
            // 
            // label116
            // 
            this.label116.BackColor = System.Drawing.SystemColors.Control;
            this.label116.Location = new System.Drawing.Point(0, 54);
            this.label116.Name = "label116";
            this.label116.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label116.Size = new System.Drawing.Size(67, 17);
            this.label116.TabIndex = 472;
            this.label116.Text = "Action #+";
            // 
            // npcZ_half
            // 
            this.npcZ_half.Appearance = System.Windows.Forms.Appearance.Button;
            this.npcZ_half.BackColor = System.Drawing.SystemColors.Control;
            this.npcZ_half.FlatAppearance.BorderSize = 0;
            this.npcZ_half.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.npcZ_half.ForeColor = System.Drawing.Color.Gray;
            this.npcZ_half.Location = new System.Drawing.Point(0, 126);
            this.npcZ_half.Name = "npcZ_half";
            this.npcZ_half.Size = new System.Drawing.Size(128, 18);
            this.npcZ_half.TabIndex = 111;
            this.npcZ_half.Text = "Z COORD +½";
            this.npcZ_half.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.npcZ_half.UseCompatibleTextRendering = true;
            this.npcZ_half.UseVisualStyleBackColor = false;
            this.npcZ_half.CheckedChanged += new System.EventHandler(this.npcsZCoordPlusHalf_CheckedChanged);
            // 
            // panel42
            // 
            this.panel42.BackColor = System.Drawing.SystemColors.Window;
            this.panel42.Controls.Add(this.npcFace);
            this.panel42.Location = new System.Drawing.Point(68, 144);
            this.panel42.Name = "panel42";
            this.panel42.Size = new System.Drawing.Size(60, 17);
            this.panel42.TabIndex = 112;
            // 
            // npcFace
            // 
            this.npcFace.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.npcFace.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.npcFace.Items.AddRange(new object[] {
            "E",
            "SE",
            "S",
            "SW",
            "W",
            "NW",
            "N",
            "NE"});
            this.npcFace.Location = new System.Drawing.Point(-2, -2);
            this.npcFace.Name = "npcFace";
            this.npcFace.Size = new System.Drawing.Size(64, 21);
            this.npcFace.TabIndex = 193;
            this.npcFace.SelectedIndexChanged += new System.EventHandler(this.npcRadialPosition_SelectedIndexChanged);
            // 
            // npcVisible
            // 
            this.npcVisible.Appearance = System.Windows.Forms.Appearance.Button;
            this.npcVisible.BackColor = System.Drawing.SystemColors.Control;
            this.npcVisible.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.npcVisible.ForeColor = System.Drawing.Color.Gray;
            this.npcVisible.Location = new System.Drawing.Point(0, 0);
            this.npcVisible.Name = "npcVisible";
            this.npcVisible.Size = new System.Drawing.Size(128, 18);
            this.npcVisible.TabIndex = 104;
            this.npcVisible.Text = "SHOW NPC";
            this.npcVisible.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.npcVisible.UseCompatibleTextRendering = true;
            this.npcVisible.UseVisualStyleBackColor = false;
            this.npcVisible.CheckedChanged += new System.EventHandler(this.npcsShowNPC_CheckedChanged);
            // 
            // mapNum
            // 
            this.mapNum.BackColor = System.Drawing.SystemColors.ControlDark;
            this.mapNum.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.mapNum.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mapNum.ForeColor = System.Drawing.SystemColors.Control;
            this.mapNum.Location = new System.Drawing.Point(126, 0);
            this.mapNum.Maximum = new decimal(new int[] {
            155,
            0,
            0,
            0});
            this.mapNum.Name = "mapNum";
            this.mapNum.Size = new System.Drawing.Size(130, 17);
            this.mapNum.TabIndex = 50;
            this.mapNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.mapNum.ValueChanged += new System.EventHandler(this.mapNum_ValueChanged);
            // 
            // label33
            // 
            this.label33.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label33.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label33.ForeColor = System.Drawing.SystemColors.Control;
            this.label33.Location = new System.Drawing.Point(0, 0);
            this.label33.Name = "label33";
            this.label33.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label33.Size = new System.Drawing.Size(125, 17);
            this.label33.TabIndex = 15;
            this.label33.Text = "MAP #";
            // 
            // contextMenuStrip4
            // 
            this.contextMenuStrip4.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addThisLevelToNotesDatabaseToolStripMenuItem});
            this.contextMenuStrip4.Name = "contextMenuStrip4";
            this.contextMenuStrip4.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.contextMenuStrip4.ShowImageMargin = false;
            this.contextMenuStrip4.Size = new System.Drawing.Size(217, 26);
            // 
            // addThisLevelToNotesDatabaseToolStripMenuItem
            // 
            this.addThisLevelToNotesDatabaseToolStripMenuItem.Name = "addThisLevelToNotesDatabaseToolStripMenuItem";
            this.addThisLevelToNotesDatabaseToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.addThisLevelToNotesDatabaseToolStripMenuItem.Text = "Add this level to notes database...";
            this.addThisLevelToNotesDatabaseToolStripMenuItem.Click += new System.EventHandler(this.addThisLevelToNotesDatabaseToolStripMenuItem_Click);
            // 
            // label19
            // 
            this.label19.BackColor = System.Drawing.SystemColors.Control;
            this.label19.Location = new System.Drawing.Point(0, 91);
            this.label19.Name = "label19";
            this.label19.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label19.Size = new System.Drawing.Size(74, 17);
            this.label19.TabIndex = 9;
            this.label19.Text = "GFX Set 5";
            // 
            // label18
            // 
            this.label18.BackColor = System.Drawing.SystemColors.Control;
            this.label18.Location = new System.Drawing.Point(0, 73);
            this.label18.Name = "label18";
            this.label18.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label18.Size = new System.Drawing.Size(74, 17);
            this.label18.TabIndex = 8;
            this.label18.Text = "GFX Set 4";
            // 
            // label17
            // 
            this.label17.BackColor = System.Drawing.SystemColors.Control;
            this.label17.Location = new System.Drawing.Point(0, 55);
            this.label17.Name = "label17";
            this.label17.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label17.Size = new System.Drawing.Size(74, 17);
            this.label17.TabIndex = 7;
            this.label17.Text = "GFX Set 3";
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.SystemColors.Control;
            this.label16.Location = new System.Drawing.Point(0, 37);
            this.label16.Name = "label16";
            this.label16.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label16.Size = new System.Drawing.Size(74, 17);
            this.label16.TabIndex = 6;
            this.label16.Text = "GFX Set 2";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(0, 19);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label2.Size = new System.Drawing.Size(74, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "GFX Set 1";
            // 
            // tabPage10
            // 
            this.tabPage10.Controls.Add(this.panel1);
            this.tabPage10.Controls.Add(this.panelOverlapTileset);
            this.tabPage10.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage10.Location = new System.Drawing.Point(4, 22);
            this.tabPage10.Name = "tabPage10";
            this.tabPage10.Size = new System.Drawing.Size(260, 640);
            this.tabPage10.TabIndex = 4;
            this.tabPage10.Text = "OVERLAP";
            this.tabPage10.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.overlapFieldTree);
            this.panel1.Controls.Add(this.overlapUnknownBits);
            this.panel1.Controls.Add(this.toolStrip4);
            this.panel1.Controls.Add(this.panel99);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(260, 220);
            this.panel1.TabIndex = 496;
            // 
            // overlapFieldTree
            // 
            this.overlapFieldTree.Dock = System.Windows.Forms.DockStyle.Left;
            this.overlapFieldTree.HideSelection = false;
            this.overlapFieldTree.HotTracking = true;
            this.overlapFieldTree.Location = new System.Drawing.Point(0, 25);
            this.overlapFieldTree.Name = "overlapFieldTree";
            this.overlapFieldTree.ShowRootLines = false;
            this.overlapFieldTree.Size = new System.Drawing.Size(125, 195);
            this.overlapFieldTree.TabIndex = 456;
            this.overlapFieldTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.overlapFieldTree_AfterSelect);
            // 
            // overlapUnknownBits
            // 
            this.overlapUnknownBits.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.overlapUnknownBits.BackColor = System.Drawing.SystemColors.Window;
            this.overlapUnknownBits.CheckOnClick = true;
            this.overlapUnknownBits.ColumnWidth = 60;
            this.overlapUnknownBits.IntegralHeight = false;
            this.overlapUnknownBits.Items.AddRange(new object[] {
            "overlap tile edges",
            "{B2,b5}",
            "{B2,b6}",
            "{B2,b7}"});
            this.overlapUnknownBits.Location = new System.Drawing.Point(127, 124);
            this.overlapUnknownBits.Name = "overlapUnknownBits";
            this.overlapUnknownBits.Size = new System.Drawing.Size(133, 95);
            this.overlapUnknownBits.TabIndex = 123;
            this.overlapUnknownBits.SelectedIndexChanged += new System.EventHandler(this.overlapUnknownBits_SelectedIndexChanged);
            // 
            // toolStrip4
            // 
            this.toolStrip4.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip4.CanOverflow = false;
            this.toolStrip4.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip4.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.overlapFieldInsert,
            this.overlapFieldDelete,
            this.overlapFieldCopy,
            this.overlapFieldPaste,
            this.overlapFieldDuplicate,
            this.toolStripSeparator18,
            this.overlapsBytesLeft});
            this.toolStrip4.Location = new System.Drawing.Point(0, 0);
            this.toolStrip4.Name = "toolStrip4";
            this.toolStrip4.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip4.Size = new System.Drawing.Size(260, 25);
            this.toolStrip4.TabIndex = 496;
            this.toolStrip4.Text = "toolStrip4";
            // 
            // overlapFieldInsert
            // 
            this.overlapFieldInsert.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.overlapFieldInsert.Image = global::LAZYSHELL.Properties.Resources.new_small;
            this.overlapFieldInsert.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.overlapFieldInsert.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.overlapFieldInsert.Name = "overlapFieldInsert";
            this.overlapFieldInsert.Size = new System.Drawing.Size(23, 22);
            this.overlapFieldInsert.Text = "Insert overlap";
            this.overlapFieldInsert.Click += new System.EventHandler(this.overlapFieldInsert_Click);
            // 
            // overlapFieldDelete
            // 
            this.overlapFieldDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.overlapFieldDelete.Image = global::LAZYSHELL.Properties.Resources.delete_small;
            this.overlapFieldDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.overlapFieldDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.overlapFieldDelete.Name = "overlapFieldDelete";
            this.overlapFieldDelete.Size = new System.Drawing.Size(23, 22);
            this.overlapFieldDelete.Text = "Delete overlap";
            this.overlapFieldDelete.Click += new System.EventHandler(this.overlapFieldDelete_Click);
            // 
            // overlapFieldCopy
            // 
            this.overlapFieldCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.overlapFieldCopy.Image = global::LAZYSHELL.Properties.Resources.copy_small;
            this.overlapFieldCopy.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.overlapFieldCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.overlapFieldCopy.Name = "overlapFieldCopy";
            this.overlapFieldCopy.Size = new System.Drawing.Size(23, 22);
            this.overlapFieldCopy.Text = "Copy Overlap";
            this.overlapFieldCopy.Click += new System.EventHandler(this.overlapFieldCopy_Click);
            // 
            // overlapFieldPaste
            // 
            this.overlapFieldPaste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.overlapFieldPaste.Image = global::LAZYSHELL.Properties.Resources.paste_small;
            this.overlapFieldPaste.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.overlapFieldPaste.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.overlapFieldPaste.Name = "overlapFieldPaste";
            this.overlapFieldPaste.Size = new System.Drawing.Size(23, 22);
            this.overlapFieldPaste.Text = "Paste Overlap";
            this.overlapFieldPaste.Click += new System.EventHandler(this.overlapFieldPaste_Click);
            // 
            // overlapFieldDuplicate
            // 
            this.overlapFieldDuplicate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.overlapFieldDuplicate.Image = global::LAZYSHELL.Properties.Resources.duplicate_small;
            this.overlapFieldDuplicate.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.overlapFieldDuplicate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.overlapFieldDuplicate.Name = "overlapFieldDuplicate";
            this.overlapFieldDuplicate.Size = new System.Drawing.Size(23, 22);
            this.overlapFieldDuplicate.Text = "Duplicate Overlap";
            this.overlapFieldDuplicate.Click += new System.EventHandler(this.overlapFieldDuplicate_Click);
            // 
            // toolStripSeparator18
            // 
            this.toolStripSeparator18.Name = "toolStripSeparator18";
            this.toolStripSeparator18.Size = new System.Drawing.Size(6, 25);
            // 
            // overlapsBytesLeft
            // 
            this.overlapsBytesLeft.Name = "overlapsBytesLeft";
            this.overlapsBytesLeft.Size = new System.Drawing.Size(52, 22);
            this.overlapsBytesLeft.Text = "bytes left";
            // 
            // panel99
            // 
            this.panel99.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel99.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel99.Controls.Add(this.overlapCoordZPlusHalf);
            this.panel99.Controls.Add(this.label109);
            this.panel99.Controls.Add(this.label103);
            this.panel99.Controls.Add(this.label107);
            this.panel99.Controls.Add(this.overlapType);
            this.panel99.Controls.Add(this.overlapX);
            this.panel99.Controls.Add(this.overlapY);
            this.panel99.Controls.Add(this.overlapZ);
            this.panel99.Controls.Add(this.label106);
            this.panel99.Location = new System.Drawing.Point(127, 28);
            this.panel99.Name = "panel99";
            this.panel99.Size = new System.Drawing.Size(133, 94);
            this.panel99.TabIndex = 495;
            // 
            // overlapCoordZPlusHalf
            // 
            this.overlapCoordZPlusHalf.Appearance = System.Windows.Forms.Appearance.Button;
            this.overlapCoordZPlusHalf.BackColor = System.Drawing.SystemColors.Control;
            this.overlapCoordZPlusHalf.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.overlapCoordZPlusHalf.ForeColor = System.Drawing.Color.Gray;
            this.overlapCoordZPlusHalf.Location = new System.Drawing.Point(0, 72);
            this.overlapCoordZPlusHalf.Name = "overlapCoordZPlusHalf";
            this.overlapCoordZPlusHalf.Size = new System.Drawing.Size(129, 18);
            this.overlapCoordZPlusHalf.TabIndex = 493;
            this.overlapCoordZPlusHalf.Text = "Z COORD +½";
            this.overlapCoordZPlusHalf.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.overlapCoordZPlusHalf.UseCompatibleTextRendering = true;
            this.overlapCoordZPlusHalf.UseVisualStyleBackColor = false;
            this.overlapCoordZPlusHalf.CheckedChanged += new System.EventHandler(this.overlapCoordZPlusHalf_CheckedChanged);
            // 
            // label109
            // 
            this.label109.BackColor = System.Drawing.SystemColors.Control;
            this.label109.Location = new System.Drawing.Point(0, 0);
            this.label109.Name = "label109";
            this.label109.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label109.Size = new System.Drawing.Size(58, 17);
            this.label109.TabIndex = 489;
            this.label109.Text = "Tile #";
            // 
            // label103
            // 
            this.label103.BackColor = System.Drawing.SystemColors.Control;
            this.label103.Location = new System.Drawing.Point(0, 18);
            this.label103.Name = "label103";
            this.label103.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label103.Size = new System.Drawing.Size(58, 17);
            this.label103.TabIndex = 489;
            this.label103.Text = "X Coord";
            // 
            // label107
            // 
            this.label107.BackColor = System.Drawing.SystemColors.Control;
            this.label107.Location = new System.Drawing.Point(0, 54);
            this.label107.Name = "label107";
            this.label107.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label107.Size = new System.Drawing.Size(58, 17);
            this.label107.TabIndex = 491;
            this.label107.Text = "Z Coord";
            // 
            // overlapType
            // 
            this.overlapType.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.overlapType.Location = new System.Drawing.Point(59, 0);
            this.overlapType.Maximum = new decimal(new int[] {
            103,
            0,
            0,
            0});
            this.overlapType.Name = "overlapType";
            this.overlapType.Size = new System.Drawing.Size(70, 17);
            this.overlapType.TabIndex = 492;
            this.overlapType.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.overlapType.ValueChanged += new System.EventHandler(this.overlapType_ValueChanged);
            // 
            // overlapX
            // 
            this.overlapX.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.overlapX.Location = new System.Drawing.Point(59, 18);
            this.overlapX.Maximum = new decimal(new int[] {
            63,
            0,
            0,
            0});
            this.overlapX.Name = "overlapX";
            this.overlapX.Size = new System.Drawing.Size(70, 17);
            this.overlapX.TabIndex = 486;
            this.overlapX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.overlapX.ValueChanged += new System.EventHandler(this.overlapCoordX_ValueChanged);
            // 
            // overlapY
            // 
            this.overlapY.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.overlapY.Location = new System.Drawing.Point(59, 36);
            this.overlapY.Maximum = new decimal(new int[] {
            127,
            0,
            0,
            0});
            this.overlapY.Name = "overlapY";
            this.overlapY.Size = new System.Drawing.Size(70, 17);
            this.overlapY.TabIndex = 487;
            this.overlapY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.overlapY.ValueChanged += new System.EventHandler(this.overlapCoordY_ValueChanged);
            // 
            // overlapZ
            // 
            this.overlapZ.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.overlapZ.Location = new System.Drawing.Point(59, 54);
            this.overlapZ.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.overlapZ.Name = "overlapZ";
            this.overlapZ.Size = new System.Drawing.Size(70, 17);
            this.overlapZ.TabIndex = 488;
            this.overlapZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.overlapZ.ValueChanged += new System.EventHandler(this.overlapCoordZ_ValueChanged);
            // 
            // label106
            // 
            this.label106.BackColor = System.Drawing.SystemColors.Control;
            this.label106.Location = new System.Drawing.Point(0, 36);
            this.label106.Name = "label106";
            this.label106.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label106.Size = new System.Drawing.Size(58, 17);
            this.label106.TabIndex = 490;
            this.label106.Text = "Y Coord";
            // 
            // panelOverlapTileset
            // 
            this.panelOverlapTileset.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelOverlapTileset.Controls.Add(this.pictureBoxOverlaps);
            this.panelOverlapTileset.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelOverlapTileset.Enabled = false;
            this.panelOverlapTileset.Location = new System.Drawing.Point(0, 220);
            this.panelOverlapTileset.Name = "panelOverlapTileset";
            this.panelOverlapTileset.Size = new System.Drawing.Size(260, 420);
            this.panelOverlapTileset.TabIndex = 505;
            this.panelOverlapTileset.Visible = false;
            // 
            // pictureBoxOverlaps
            // 
            this.pictureBoxOverlaps.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBoxOverlaps.BackgroundImage = global::LAZYSHELL.Properties.Resources._transparent;
            this.pictureBoxOverlaps.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxOverlaps.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxOverlaps.Name = "pictureBoxOverlaps";
            this.pictureBoxOverlaps.Size = new System.Drawing.Size(256, 416);
            this.pictureBoxOverlaps.TabIndex = 0;
            this.pictureBoxOverlaps.TabStop = false;
            this.pictureBoxOverlaps.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxOverlaps_MouseDown);
            this.pictureBoxOverlaps.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxOverlaps_Paint);
            // 
            // tabPage9
            // 
            this.tabPage9.Controls.Add(this.panel2);
            this.tabPage9.Controls.Add(this.panel52);
            this.tabPage9.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage9.Location = new System.Drawing.Point(4, 22);
            this.tabPage9.Name = "tabPage9";
            this.tabPage9.Size = new System.Drawing.Size(260, 640);
            this.tabPage9.TabIndex = 3;
            this.tabPage9.Text = "FIELD";
            this.tabPage9.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel90);
            this.panel2.Controls.Add(this.eventsList);
            this.panel2.Controls.Add(this.toolStrip6);
            this.panel2.Controls.Add(this.label63);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(0, 363);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(260, 277);
            this.panel2.TabIndex = 498;
            // 
            // panel90
            // 
            this.panel90.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel90.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel90.Controls.Add(this.buttonGotoD);
            this.panel90.Controls.Add(this.label62);
            this.panel90.Controls.Add(this.label127);
            this.panel90.Controls.Add(this.eventLength);
            this.panel90.Controls.Add(this.label129);
            this.panel90.Controls.Add(this.eventY);
            this.panel90.Controls.Add(this.eventsWidthYPlusHalf);
            this.panel90.Controls.Add(this.label131);
            this.panel90.Controls.Add(this.eventsWidthXPlusHalf);
            this.panel90.Controls.Add(this.eventX);
            this.panel90.Controls.Add(this.eventZ);
            this.panel90.Controls.Add(this.panel46);
            this.panel90.Controls.Add(this.eventHeight);
            this.panel90.Controls.Add(this.label133);
            this.panel90.Controls.Add(this.label135);
            this.panel90.Controls.Add(this.label137);
            this.panel90.Controls.Add(this.eventEvent);
            this.panel90.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel90.Location = new System.Drawing.Point(125, 44);
            this.panel90.Name = "panel90";
            this.panel90.Size = new System.Drawing.Size(135, 233);
            this.panel90.TabIndex = 497;
            // 
            // buttonGotoD
            // 
            this.buttonGotoD.BackColor = System.Drawing.SystemColors.Control;
            this.buttonGotoD.FlatAppearance.BorderSize = 0;
            this.buttonGotoD.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonGotoD.Location = new System.Drawing.Point(0, 19);
            this.buttonGotoD.Name = "buttonGotoD";
            this.buttonGotoD.Size = new System.Drawing.Size(61, 18);
            this.buttonGotoD.TabIndex = 492;
            this.buttonGotoD.Text = "Event #";
            this.buttonGotoD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.buttonGotoD, "Edit event field event...");
            this.buttonGotoD.UseCompatibleTextRendering = true;
            this.buttonGotoD.UseVisualStyleBackColor = false;
            this.buttonGotoD.Click += new System.EventHandler(this.buttonGotoD_Click);
            // 
            // label62
            // 
            this.label62.BackColor = System.Drawing.SystemColors.Control;
            this.label62.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label62.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label62.Location = new System.Drawing.Point(0, 0);
            this.label62.Name = "label62";
            this.label62.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label62.Size = new System.Drawing.Size(131, 17);
            this.label62.TabIndex = 452;
            this.label62.Text = "FIELD PROPERTIES";
            this.label62.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label127
            // 
            this.label127.BackColor = System.Drawing.SystemColors.Control;
            this.label127.Location = new System.Drawing.Point(0, 37);
            this.label127.Name = "label127";
            this.label127.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label127.Size = new System.Drawing.Size(60, 17);
            this.label127.TabIndex = 473;
            this.label127.Text = "X Coord";
            // 
            // eventLength
            // 
            this.eventLength.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.eventLength.Location = new System.Drawing.Point(61, 91);
            this.eventLength.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.eventLength.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.eventLength.Name = "eventLength";
            this.eventLength.Size = new System.Drawing.Size(70, 17);
            this.eventLength.TabIndex = 153;
            this.eventLength.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.eventLength.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.eventLength.ValueChanged += new System.EventHandler(this.eventsFieldLength_ValueChanged);
            // 
            // label129
            // 
            this.label129.BackColor = System.Drawing.SystemColors.Control;
            this.label129.Location = new System.Drawing.Point(0, 55);
            this.label129.Name = "label129";
            this.label129.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label129.Size = new System.Drawing.Size(60, 17);
            this.label129.TabIndex = 477;
            this.label129.Text = "Y Coord";
            // 
            // eventY
            // 
            this.eventY.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.eventY.Location = new System.Drawing.Point(61, 55);
            this.eventY.Maximum = new decimal(new int[] {
            127,
            0,
            0,
            0});
            this.eventY.Name = "eventY";
            this.eventY.Size = new System.Drawing.Size(70, 17);
            this.eventY.TabIndex = 151;
            this.eventY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.eventY.ValueChanged += new System.EventHandler(this.eventsFieldYCoord_ValueChanged);
            // 
            // eventsWidthYPlusHalf
            // 
            this.eventsWidthYPlusHalf.Appearance = System.Windows.Forms.Appearance.Button;
            this.eventsWidthYPlusHalf.BackColor = System.Drawing.SystemColors.Control;
            this.eventsWidthYPlusHalf.FlatAppearance.BorderSize = 0;
            this.eventsWidthYPlusHalf.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eventsWidthYPlusHalf.ForeColor = System.Drawing.Color.Gray;
            this.eventsWidthYPlusHalf.Location = new System.Drawing.Point(61, 146);
            this.eventsWidthYPlusHalf.Name = "eventsWidthYPlusHalf";
            this.eventsWidthYPlusHalf.Size = new System.Drawing.Size(70, 17);
            this.eventsWidthYPlusHalf.TabIndex = 157;
            this.eventsWidthYPlusHalf.Text = "135°+½";
            this.eventsWidthYPlusHalf.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.eventsWidthYPlusHalf.UseCompatibleTextRendering = true;
            this.eventsWidthYPlusHalf.UseVisualStyleBackColor = false;
            this.eventsWidthYPlusHalf.CheckedChanged += new System.EventHandler(this.eventsWidthYPlusHalf_CheckedChanged);
            // 
            // label131
            // 
            this.label131.BackColor = System.Drawing.SystemColors.Control;
            this.label131.Location = new System.Drawing.Point(0, 91);
            this.label131.Name = "label131";
            this.label131.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label131.Size = new System.Drawing.Size(60, 17);
            this.label131.TabIndex = 471;
            this.label131.Text = "Length";
            // 
            // eventsWidthXPlusHalf
            // 
            this.eventsWidthXPlusHalf.Appearance = System.Windows.Forms.Appearance.Button;
            this.eventsWidthXPlusHalf.BackColor = System.Drawing.SystemColors.Control;
            this.eventsWidthXPlusHalf.FlatAppearance.BorderSize = 0;
            this.eventsWidthXPlusHalf.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eventsWidthXPlusHalf.ForeColor = System.Drawing.Color.Gray;
            this.eventsWidthXPlusHalf.Location = new System.Drawing.Point(0, 146);
            this.eventsWidthXPlusHalf.Name = "eventsWidthXPlusHalf";
            this.eventsWidthXPlusHalf.Size = new System.Drawing.Size(61, 17);
            this.eventsWidthXPlusHalf.TabIndex = 156;
            this.eventsWidthXPlusHalf.Text = "45°+½";
            this.eventsWidthXPlusHalf.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.eventsWidthXPlusHalf.UseCompatibleTextRendering = true;
            this.eventsWidthXPlusHalf.UseVisualStyleBackColor = false;
            this.eventsWidthXPlusHalf.CheckedChanged += new System.EventHandler(this.eventsWidthXPlusHalf_CheckedChanged);
            // 
            // eventX
            // 
            this.eventX.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.eventX.Location = new System.Drawing.Point(61, 37);
            this.eventX.Maximum = new decimal(new int[] {
            63,
            0,
            0,
            0});
            this.eventX.Name = "eventX";
            this.eventX.Size = new System.Drawing.Size(70, 17);
            this.eventX.TabIndex = 150;
            this.eventX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.eventX.ValueChanged += new System.EventHandler(this.eventsFieldXCoord_ValueChanged);
            // 
            // eventZ
            // 
            this.eventZ.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.eventZ.Location = new System.Drawing.Point(61, 73);
            this.eventZ.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.eventZ.Name = "eventZ";
            this.eventZ.Size = new System.Drawing.Size(70, 17);
            this.eventZ.TabIndex = 152;
            this.eventZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.eventZ.ValueChanged += new System.EventHandler(this.eventsFieldZCoord_ValueChanged);
            // 
            // panel46
            // 
            this.panel46.BackColor = System.Drawing.SystemColors.Window;
            this.panel46.Controls.Add(this.eventFace);
            this.panel46.Location = new System.Drawing.Point(61, 127);
            this.panel46.Name = "panel46";
            this.panel46.Size = new System.Drawing.Size(71, 17);
            this.panel46.TabIndex = 155;
            // 
            // eventFace
            // 
            this.eventFace.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.eventFace.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.eventFace.DropDownWidth = 60;
            this.eventFace.Items.AddRange(new object[] {
            "UR to DL",
            "DR to UL"});
            this.eventFace.Location = new System.Drawing.Point(-2, -2);
            this.eventFace.Name = "eventFace";
            this.eventFace.Size = new System.Drawing.Size(74, 21);
            this.eventFace.TabIndex = 211;
            this.eventFace.SelectedIndexChanged += new System.EventHandler(this.eventsFieldRadialPosition_SelectedIndexChanged);
            // 
            // eventHeight
            // 
            this.eventHeight.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.eventHeight.Location = new System.Drawing.Point(61, 109);
            this.eventHeight.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.eventHeight.Name = "eventHeight";
            this.eventHeight.Size = new System.Drawing.Size(70, 17);
            this.eventHeight.TabIndex = 154;
            this.eventHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.eventHeight.ValueChanged += new System.EventHandler(this.eventsFieldHeight_ValueChanged);
            // 
            // label133
            // 
            this.label133.BackColor = System.Drawing.SystemColors.Control;
            this.label133.Location = new System.Drawing.Point(0, 73);
            this.label133.Name = "label133";
            this.label133.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label133.Size = new System.Drawing.Size(60, 17);
            this.label133.TabIndex = 486;
            this.label133.Text = "Z Coord";
            // 
            // label135
            // 
            this.label135.BackColor = System.Drawing.SystemColors.Control;
            this.label135.Location = new System.Drawing.Point(0, 109);
            this.label135.Name = "label135";
            this.label135.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label135.Size = new System.Drawing.Size(60, 17);
            this.label135.TabIndex = 484;
            this.label135.Text = "Height";
            // 
            // label137
            // 
            this.label137.BackColor = System.Drawing.SystemColors.Control;
            this.label137.Location = new System.Drawing.Point(0, 127);
            this.label137.Name = "label137";
            this.label137.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label137.Size = new System.Drawing.Size(60, 17);
            this.label137.TabIndex = 489;
            this.label137.Text = "Facing";
            // 
            // eventEvent
            // 
            this.eventEvent.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.eventEvent.Location = new System.Drawing.Point(61, 19);
            this.eventEvent.Maximum = new decimal(new int[] {
            4095,
            0,
            0,
            0});
            this.eventEvent.Name = "eventEvent";
            this.eventEvent.Size = new System.Drawing.Size(70, 17);
            this.eventEvent.TabIndex = 149;
            this.eventEvent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.eventEvent.ValueChanged += new System.EventHandler(this.eventsRunEvent_ValueChanged);
            // 
            // eventsList
            // 
            this.eventsList.Dock = System.Windows.Forms.DockStyle.Left;
            this.eventsList.HideSelection = false;
            this.eventsList.HotTracking = true;
            this.eventsList.Location = new System.Drawing.Point(0, 44);
            this.eventsList.Name = "eventsList";
            this.eventsList.ShowRootLines = false;
            this.eventsList.Size = new System.Drawing.Size(125, 233);
            this.eventsList.TabIndex = 146;
            this.eventsList.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.eventsFieldTree_AfterSelect);
            // 
            // toolStrip6
            // 
            this.toolStrip6.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip6.CanOverflow = false;
            this.toolStrip6.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.eventsInsertField,
            this.eventsDeleteField,
            this.eventsCopyField,
            this.eventsPasteField,
            this.eventsDuplicateField,
            this.toolStripSeparator20,
            this.eventsBytesLeft});
            this.toolStrip6.Location = new System.Drawing.Point(0, 19);
            this.toolStrip6.Name = "toolStrip6";
            this.toolStrip6.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip6.Size = new System.Drawing.Size(260, 25);
            this.toolStrip6.TabIndex = 497;
            this.toolStrip6.Text = "toolStrip6";
            // 
            // eventsInsertField
            // 
            this.eventsInsertField.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.eventsInsertField.Image = global::LAZYSHELL.Properties.Resources.new_small;
            this.eventsInsertField.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.eventsInsertField.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.eventsInsertField.Name = "eventsInsertField";
            this.eventsInsertField.Size = new System.Drawing.Size(23, 22);
            this.eventsInsertField.Text = "New Event";
            this.eventsInsertField.Click += new System.EventHandler(this.eventsInsertField_Click);
            // 
            // eventsDeleteField
            // 
            this.eventsDeleteField.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.eventsDeleteField.Image = global::LAZYSHELL.Properties.Resources.delete_small;
            this.eventsDeleteField.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.eventsDeleteField.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.eventsDeleteField.Name = "eventsDeleteField";
            this.eventsDeleteField.Size = new System.Drawing.Size(23, 22);
            this.eventsDeleteField.Text = "Delete Event";
            this.eventsDeleteField.Click += new System.EventHandler(this.eventsDeleteField_Click);
            // 
            // eventsCopyField
            // 
            this.eventsCopyField.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.eventsCopyField.Image = global::LAZYSHELL.Properties.Resources.copy_small;
            this.eventsCopyField.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.eventsCopyField.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.eventsCopyField.Name = "eventsCopyField";
            this.eventsCopyField.Size = new System.Drawing.Size(23, 22);
            this.eventsCopyField.Text = "Copy Event";
            this.eventsCopyField.Click += new System.EventHandler(this.eventsCopyField_Click);
            // 
            // eventsPasteField
            // 
            this.eventsPasteField.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.eventsPasteField.Image = global::LAZYSHELL.Properties.Resources.paste_small;
            this.eventsPasteField.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.eventsPasteField.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.eventsPasteField.Name = "eventsPasteField";
            this.eventsPasteField.Size = new System.Drawing.Size(23, 22);
            this.eventsPasteField.Text = "Paste Event";
            this.eventsPasteField.Click += new System.EventHandler(this.eventsPasteField_Click);
            // 
            // eventsDuplicateField
            // 
            this.eventsDuplicateField.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.eventsDuplicateField.Image = global::LAZYSHELL.Properties.Resources.duplicate_small;
            this.eventsDuplicateField.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.eventsDuplicateField.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.eventsDuplicateField.Name = "eventsDuplicateField";
            this.eventsDuplicateField.Size = new System.Drawing.Size(23, 22);
            this.eventsDuplicateField.Text = "Duplicate Event";
            this.eventsDuplicateField.Click += new System.EventHandler(this.eventsDuplicateField_Click);
            // 
            // toolStripSeparator20
            // 
            this.toolStripSeparator20.Name = "toolStripSeparator20";
            this.toolStripSeparator20.Size = new System.Drawing.Size(6, 25);
            // 
            // eventsBytesLeft
            // 
            this.eventsBytesLeft.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eventsBytesLeft.Name = "eventsBytesLeft";
            this.eventsBytesLeft.Size = new System.Drawing.Size(52, 22);
            this.eventsBytesLeft.Text = "bytes left";
            // 
            // label63
            // 
            this.label63.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label63.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label63.Dock = System.Windows.Forms.DockStyle.Top;
            this.label63.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label63.ForeColor = System.Drawing.SystemColors.Control;
            this.label63.Location = new System.Drawing.Point(0, 0);
            this.label63.Name = "label63";
            this.label63.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label63.Size = new System.Drawing.Size(260, 19);
            this.label63.TabIndex = 456;
            this.label63.Text = "EVENT FIELDS";
            this.label63.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel52
            // 
            this.panel52.Controls.Add(this.panel88);
            this.panel52.Controls.Add(this.exitsFieldTree);
            this.panel52.Controls.Add(this.panel87);
            this.panel52.Controls.Add(this.panel68);
            this.panel52.Controls.Add(this.toolStrip5);
            this.panel52.Controls.Add(this.label61);
            this.panel52.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel52.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel52.Location = new System.Drawing.Point(0, 0);
            this.panel52.Name = "panel52";
            this.panel52.Size = new System.Drawing.Size(260, 363);
            this.panel52.TabIndex = 0;
            // 
            // panel88
            // 
            this.panel88.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel88.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel88.Controls.Add(this.label66);
            this.panel88.Controls.Add(this.label59);
            this.panel88.Controls.Add(this.exitDestY);
            this.panel88.Controls.Add(this.marioZCoordPlusHalf);
            this.panel88.Controls.Add(this.label60);
            this.panel88.Controls.Add(this.exitDestX);
            this.panel88.Controls.Add(this.exitDestZ);
            this.panel88.Controls.Add(this.label122);
            this.panel88.Controls.Add(this.label124);
            this.panel88.Controls.Add(this.panel48);
            this.panel88.Location = new System.Drawing.Point(127, 249);
            this.panel88.Name = "panel88";
            this.panel88.Size = new System.Drawing.Size(133, 112);
            this.panel88.TabIndex = 495;
            // 
            // label66
            // 
            this.label66.BackColor = System.Drawing.SystemColors.Control;
            this.label66.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label66.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label66.Location = new System.Drawing.Point(0, 0);
            this.label66.Name = "label66";
            this.label66.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label66.Size = new System.Drawing.Size(129, 17);
            this.label66.TabIndex = 457;
            this.label66.Text = "DEST. COORDS";
            this.label66.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label59
            // 
            this.label59.BackColor = System.Drawing.SystemColors.Control;
            this.label59.Location = new System.Drawing.Point(0, 19);
            this.label59.Name = "label59";
            this.label59.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label59.Size = new System.Drawing.Size(58, 17);
            this.label59.TabIndex = 474;
            this.label59.Text = "X Coord";
            // 
            // exitDestY
            // 
            this.exitDestY.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.exitDestY.Location = new System.Drawing.Point(59, 37);
            this.exitDestY.Maximum = new decimal(new int[] {
            127,
            0,
            0,
            0});
            this.exitDestY.Name = "exitDestY";
            this.exitDestY.Size = new System.Drawing.Size(70, 17);
            this.exitDestY.TabIndex = 139;
            this.exitDestY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.exitDestY.ValueChanged += new System.EventHandler(this.exitsMarioYCoord_ValueChanged);
            // 
            // marioZCoordPlusHalf
            // 
            this.marioZCoordPlusHalf.Appearance = System.Windows.Forms.Appearance.Button;
            this.marioZCoordPlusHalf.BackColor = System.Drawing.SystemColors.Control;
            this.marioZCoordPlusHalf.FlatAppearance.BorderSize = 0;
            this.marioZCoordPlusHalf.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.marioZCoordPlusHalf.ForeColor = System.Drawing.Color.Gray;
            this.marioZCoordPlusHalf.Location = new System.Drawing.Point(0, 91);
            this.marioZCoordPlusHalf.Name = "marioZCoordPlusHalf";
            this.marioZCoordPlusHalf.Size = new System.Drawing.Size(129, 17);
            this.marioZCoordPlusHalf.TabIndex = 142;
            this.marioZCoordPlusHalf.Text = "Z COORD +½";
            this.marioZCoordPlusHalf.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.marioZCoordPlusHalf.UseCompatibleTextRendering = true;
            this.marioZCoordPlusHalf.UseVisualStyleBackColor = false;
            this.marioZCoordPlusHalf.CheckedChanged += new System.EventHandler(this.marioZCoordPlusHalf_CheckedChanged);
            // 
            // label60
            // 
            this.label60.BackColor = System.Drawing.SystemColors.Control;
            this.label60.Location = new System.Drawing.Point(0, 37);
            this.label60.Name = "label60";
            this.label60.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label60.Size = new System.Drawing.Size(58, 17);
            this.label60.TabIndex = 476;
            this.label60.Text = "Y Coord";
            // 
            // exitDestX
            // 
            this.exitDestX.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.exitDestX.Location = new System.Drawing.Point(59, 19);
            this.exitDestX.Maximum = new decimal(new int[] {
            63,
            0,
            0,
            0});
            this.exitDestX.Name = "exitDestX";
            this.exitDestX.Size = new System.Drawing.Size(70, 17);
            this.exitDestX.TabIndex = 138;
            this.exitDestX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.exitDestX.ValueChanged += new System.EventHandler(this.exitsMarioXCoord_ValueChanged);
            // 
            // exitDestZ
            // 
            this.exitDestZ.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.exitDestZ.Location = new System.Drawing.Point(59, 55);
            this.exitDestZ.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.exitDestZ.Name = "exitDestZ";
            this.exitDestZ.Size = new System.Drawing.Size(70, 17);
            this.exitDestZ.TabIndex = 140;
            this.exitDestZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.exitDestZ.ValueChanged += new System.EventHandler(this.exitsMarioZCoord_ValueChanged);
            // 
            // label122
            // 
            this.label122.BackColor = System.Drawing.SystemColors.Control;
            this.label122.Location = new System.Drawing.Point(0, 55);
            this.label122.Name = "label122";
            this.label122.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label122.Size = new System.Drawing.Size(58, 17);
            this.label122.TabIndex = 487;
            this.label122.Text = "Z Coord";
            // 
            // label124
            // 
            this.label124.BackColor = System.Drawing.SystemColors.Control;
            this.label124.Location = new System.Drawing.Point(0, 73);
            this.label124.Name = "label124";
            this.label124.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label124.Size = new System.Drawing.Size(58, 17);
            this.label124.TabIndex = 488;
            this.label124.Text = "Facing";
            // 
            // panel48
            // 
            this.panel48.BackColor = System.Drawing.SystemColors.Window;
            this.panel48.Controls.Add(this.exitDestFace);
            this.panel48.Location = new System.Drawing.Point(59, 73);
            this.panel48.Name = "panel48";
            this.panel48.Size = new System.Drawing.Size(71, 17);
            this.panel48.TabIndex = 141;
            // 
            // exitDestFace
            // 
            this.exitDestFace.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.exitDestFace.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.exitDestFace.DropDownWidth = 70;
            this.exitDestFace.Items.AddRange(new object[] {
            "East",
            "Southeast",
            "South",
            "Southwest",
            "West",
            "Northwest",
            "North",
            "Northeast"});
            this.exitDestFace.Location = new System.Drawing.Point(-2, -2);
            this.exitDestFace.Name = "exitDestFace";
            this.exitDestFace.Size = new System.Drawing.Size(74, 21);
            this.exitDestFace.TabIndex = 210;
            this.exitDestFace.SelectedIndexChanged += new System.EventHandler(this.exitsMarioRadialPosition_SelectedIndexChanged);
            // 
            // exitsFieldTree
            // 
            this.exitsFieldTree.Dock = System.Windows.Forms.DockStyle.Left;
            this.exitsFieldTree.HideSelection = false;
            this.exitsFieldTree.HotTracking = true;
            this.exitsFieldTree.Location = new System.Drawing.Point(0, 44);
            this.exitsFieldTree.Name = "exitsFieldTree";
            this.exitsFieldTree.ShowRootLines = false;
            this.exitsFieldTree.Size = new System.Drawing.Size(125, 319);
            this.exitsFieldTree.TabIndex = 127;
            this.exitsFieldTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.exitsFieldTree_AfterSelect);
            // 
            // panel87
            // 
            this.panel87.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel87.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel87.Controls.Add(this.label119);
            this.panel87.Controls.Add(this.exits135LengthPlusHalf);
            this.panel87.Controls.Add(this.label58);
            this.panel87.Controls.Add(this.exits45LengthPlusHalf);
            this.panel87.Controls.Add(this.exitLength);
            this.panel87.Controls.Add(this.label105);
            this.panel87.Controls.Add(this.exitZ);
            this.panel87.Controls.Add(this.exitY);
            this.panel87.Controls.Add(this.exitX);
            this.panel87.Controls.Add(this.exitsShowMessage);
            this.panel87.Controls.Add(this.exitHeight);
            this.panel87.Controls.Add(this.label37);
            this.panel87.Controls.Add(this.label55);
            this.panel87.Controls.Add(this.label57);
            this.panel87.Controls.Add(this.label120);
            this.panel87.Controls.Add(this.panel49);
            this.panel87.Controls.Add(this.label47);
            this.panel87.Controls.Add(this.panel50);
            this.panel87.Controls.Add(this.panel51);
            this.panel87.Location = new System.Drawing.Point(127, 45);
            this.panel87.Name = "panel87";
            this.panel87.Size = new System.Drawing.Size(133, 202);
            this.panel87.TabIndex = 494;
            // 
            // label119
            // 
            this.label119.BackColor = System.Drawing.SystemColors.Control;
            this.label119.Location = new System.Drawing.Point(0, 72);
            this.label119.Name = "label119";
            this.label119.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label119.Size = new System.Drawing.Size(58, 17);
            this.label119.TabIndex = 472;
            this.label119.Text = "X Coord";
            // 
            // exits135LengthPlusHalf
            // 
            this.exits135LengthPlusHalf.Appearance = System.Windows.Forms.Appearance.Button;
            this.exits135LengthPlusHalf.BackColor = System.Drawing.SystemColors.Control;
            this.exits135LengthPlusHalf.FlatAppearance.BorderSize = 0;
            this.exits135LengthPlusHalf.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exits135LengthPlusHalf.ForeColor = System.Drawing.Color.Gray;
            this.exits135LengthPlusHalf.Location = new System.Drawing.Point(59, 181);
            this.exits135LengthPlusHalf.Name = "exits135LengthPlusHalf";
            this.exits135LengthPlusHalf.Size = new System.Drawing.Size(70, 17);
            this.exits135LengthPlusHalf.TabIndex = 138;
            this.exits135LengthPlusHalf.Text = "135°+½";
            this.exits135LengthPlusHalf.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.exits135LengthPlusHalf.UseCompatibleTextRendering = true;
            this.exits135LengthPlusHalf.UseVisualStyleBackColor = false;
            this.exits135LengthPlusHalf.CheckedChanged += new System.EventHandler(this.exits135LengthPlusHalf_CheckedChanged);
            // 
            // label58
            // 
            this.label58.BackColor = System.Drawing.SystemColors.Control;
            this.label58.Location = new System.Drawing.Point(0, 90);
            this.label58.Name = "label58";
            this.label58.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label58.Size = new System.Drawing.Size(58, 17);
            this.label58.TabIndex = 475;
            this.label58.Text = "Y Coord";
            // 
            // exits45LengthPlusHalf
            // 
            this.exits45LengthPlusHalf.Appearance = System.Windows.Forms.Appearance.Button;
            this.exits45LengthPlusHalf.BackColor = System.Drawing.SystemColors.Control;
            this.exits45LengthPlusHalf.FlatAppearance.BorderSize = 0;
            this.exits45LengthPlusHalf.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exits45LengthPlusHalf.ForeColor = System.Drawing.Color.Gray;
            this.exits45LengthPlusHalf.Location = new System.Drawing.Point(0, 181);
            this.exits45LengthPlusHalf.Name = "exits45LengthPlusHalf";
            this.exits45LengthPlusHalf.Size = new System.Drawing.Size(59, 17);
            this.exits45LengthPlusHalf.TabIndex = 137;
            this.exits45LengthPlusHalf.Text = "45°+½";
            this.exits45LengthPlusHalf.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.exits45LengthPlusHalf.UseCompatibleTextRendering = true;
            this.exits45LengthPlusHalf.UseVisualStyleBackColor = false;
            this.exits45LengthPlusHalf.CheckedChanged += new System.EventHandler(this.exits45LengthPlusHalf_CheckedChanged);
            // 
            // exitLength
            // 
            this.exitLength.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.exitLength.Location = new System.Drawing.Point(59, 126);
            this.exitLength.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.exitLength.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.exitLength.Name = "exitLength";
            this.exitLength.Size = new System.Drawing.Size(70, 17);
            this.exitLength.TabIndex = 134;
            this.exitLength.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.exitLength.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.exitLength.ValueChanged += new System.EventHandler(this.exitsFieldLength_ValueChanged);
            // 
            // label105
            // 
            this.label105.BackColor = System.Drawing.SystemColors.Control;
            this.label105.Location = new System.Drawing.Point(0, 126);
            this.label105.Name = "label105";
            this.label105.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label105.Size = new System.Drawing.Size(58, 17);
            this.label105.TabIndex = 470;
            this.label105.Text = "Length";
            // 
            // exitZ
            // 
            this.exitZ.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.exitZ.Location = new System.Drawing.Point(59, 108);
            this.exitZ.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.exitZ.Name = "exitZ";
            this.exitZ.Size = new System.Drawing.Size(70, 17);
            this.exitZ.TabIndex = 133;
            this.exitZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.exitZ.ValueChanged += new System.EventHandler(this.exitsZ_ValueChanged);
            // 
            // exitY
            // 
            this.exitY.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.exitY.Location = new System.Drawing.Point(59, 90);
            this.exitY.Maximum = new decimal(new int[] {
            127,
            0,
            0,
            0});
            this.exitY.Name = "exitY";
            this.exitY.Size = new System.Drawing.Size(70, 17);
            this.exitY.TabIndex = 132;
            this.exitY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.exitY.ValueChanged += new System.EventHandler(this.exitsY_ValueChanged);
            // 
            // exitX
            // 
            this.exitX.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.exitX.Location = new System.Drawing.Point(59, 72);
            this.exitX.Maximum = new decimal(new int[] {
            63,
            0,
            0,
            0});
            this.exitX.Name = "exitX";
            this.exitX.Size = new System.Drawing.Size(70, 17);
            this.exitX.TabIndex = 131;
            this.exitX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.exitX.ValueChanged += new System.EventHandler(this.exitsX_ValueChanged);
            // 
            // exitsShowMessage
            // 
            this.exitsShowMessage.Appearance = System.Windows.Forms.Appearance.Button;
            this.exitsShowMessage.BackColor = System.Drawing.SystemColors.Control;
            this.exitsShowMessage.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitsShowMessage.ForeColor = System.Drawing.Color.Gray;
            this.exitsShowMessage.Location = new System.Drawing.Point(0, 36);
            this.exitsShowMessage.Name = "exitsShowMessage";
            this.exitsShowMessage.Size = new System.Drawing.Size(129, 18);
            this.exitsShowMessage.TabIndex = 129;
            this.exitsShowMessage.Text = "SHOW MESSAGE";
            this.exitsShowMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.exitsShowMessage.UseCompatibleTextRendering = true;
            this.exitsShowMessage.UseVisualStyleBackColor = false;
            this.exitsShowMessage.CheckedChanged += new System.EventHandler(this.exitsShowMessage_CheckedChanged);
            // 
            // exitHeight
            // 
            this.exitHeight.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.exitHeight.Location = new System.Drawing.Point(59, 144);
            this.exitHeight.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.exitHeight.Name = "exitHeight";
            this.exitHeight.Size = new System.Drawing.Size(70, 17);
            this.exitHeight.TabIndex = 135;
            this.exitHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.exitHeight.ValueChanged += new System.EventHandler(this.exitsFieldHeight_ValueChanged);
            // 
            // label37
            // 
            this.label37.BackColor = System.Drawing.SystemColors.Control;
            this.label37.Location = new System.Drawing.Point(0, 54);
            this.label37.Name = "label37";
            this.label37.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label37.Size = new System.Drawing.Size(58, 17);
            this.label37.TabIndex = 458;
            this.label37.Text = "Exit Type";
            // 
            // label55
            // 
            this.label55.BackColor = System.Drawing.SystemColors.Control;
            this.label55.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label55.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label55.Location = new System.Drawing.Point(0, 0);
            this.label55.Name = "label55";
            this.label55.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label55.Size = new System.Drawing.Size(129, 17);
            this.label55.TabIndex = 460;
            this.label55.Text = "DESTINATION";
            // 
            // label57
            // 
            this.label57.BackColor = System.Drawing.SystemColors.Control;
            this.label57.Location = new System.Drawing.Point(0, 108);
            this.label57.Name = "label57";
            this.label57.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label57.Size = new System.Drawing.Size(58, 17);
            this.label57.TabIndex = 485;
            this.label57.Text = "Z Coord";
            // 
            // label120
            // 
            this.label120.BackColor = System.Drawing.SystemColors.Control;
            this.label120.Location = new System.Drawing.Point(0, 144);
            this.label120.Name = "label120";
            this.label120.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label120.Size = new System.Drawing.Size(58, 17);
            this.label120.TabIndex = 483;
            this.label120.Text = "Height";
            // 
            // panel49
            // 
            this.panel49.BackColor = System.Drawing.SystemColors.Window;
            this.panel49.Controls.Add(this.exitFace);
            this.panel49.Location = new System.Drawing.Point(59, 162);
            this.panel49.Name = "panel49";
            this.panel49.Size = new System.Drawing.Size(71, 17);
            this.panel49.TabIndex = 136;
            // 
            // exitFace
            // 
            this.exitFace.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.exitFace.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.exitFace.DropDownWidth = 60;
            this.exitFace.Items.AddRange(new object[] {
            "UR to DL",
            "DR to UL"});
            this.exitFace.Location = new System.Drawing.Point(-2, -2);
            this.exitFace.Name = "exitFace";
            this.exitFace.Size = new System.Drawing.Size(74, 21);
            this.exitFace.TabIndex = 212;
            this.exitFace.SelectedIndexChanged += new System.EventHandler(this.exitsFace_SelectedIndexChanged);
            // 
            // label47
            // 
            this.label47.BackColor = System.Drawing.SystemColors.Control;
            this.label47.Location = new System.Drawing.Point(0, 162);
            this.label47.Name = "label47";
            this.label47.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label47.Size = new System.Drawing.Size(58, 17);
            this.label47.TabIndex = 490;
            this.label47.Text = "Facing";
            // 
            // panel50
            // 
            this.panel50.BackColor = System.Drawing.SystemColors.Window;
            this.panel50.Controls.Add(this.exitType);
            this.panel50.Location = new System.Drawing.Point(59, 54);
            this.panel50.Name = "panel50";
            this.panel50.Size = new System.Drawing.Size(70, 17);
            this.panel50.TabIndex = 130;
            // 
            // exitType
            // 
            this.exitType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.exitType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.exitType.DropDownWidth = 80;
            this.exitType.Items.AddRange(new object[] {
            "Overworld",
            "Map Point"});
            this.exitType.Location = new System.Drawing.Point(-2, -2);
            this.exitType.Name = "exitType";
            this.exitType.Size = new System.Drawing.Size(74, 21);
            this.exitType.TabIndex = 197;
            this.exitType.SelectedIndexChanged += new System.EventHandler(this.exitsType_SelectedIndexChanged);
            // 
            // panel51
            // 
            this.panel51.BackColor = System.Drawing.SystemColors.Window;
            this.panel51.Controls.Add(this.exitDest);
            this.panel51.Location = new System.Drawing.Point(0, 18);
            this.panel51.Name = "panel51";
            this.panel51.Size = new System.Drawing.Size(129, 17);
            this.panel51.TabIndex = 128;
            // 
            // exitDest
            // 
            this.exitDest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.exitDest.DropDownHeight = 431;
            this.exitDest.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.exitDest.DropDownWidth = 490;
            this.exitDest.IntegralHeight = false;
            this.exitDest.Items.AddRange(new object[] {
            ""});
            this.exitDest.Location = new System.Drawing.Point(-2, -2);
            this.exitDest.Name = "exitDest";
            this.exitDest.Size = new System.Drawing.Size(133, 21);
            this.exitDest.TabIndex = 196;
            this.exitDest.SelectedIndexChanged += new System.EventHandler(this.exitsDestination_SelectedIndexChanged);
            // 
            // panel68
            // 
            this.panel68.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.panel68.BackgroundImage = global::LAZYSHELL.Properties.Resources._bg;
            this.panel68.Location = new System.Drawing.Point(119, 608);
            this.panel68.Name = "panel68";
            this.panel68.Size = new System.Drawing.Size(121, 36);
            this.panel68.TabIndex = 493;
            // 
            // toolStrip5
            // 
            this.toolStrip5.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip5.CanOverflow = false;
            this.toolStrip5.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitsInsertField,
            this.exitsDeleteField,
            this.exitsCopyField,
            this.exitsPasteField,
            this.exitsDuplicateField,
            this.toolStripSeparator19,
            this.exitsBytesLeft});
            this.toolStrip5.Location = new System.Drawing.Point(0, 19);
            this.toolStrip5.Name = "toolStrip5";
            this.toolStrip5.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip5.Size = new System.Drawing.Size(260, 25);
            this.toolStrip5.TabIndex = 496;
            this.toolStrip5.Text = "toolStrip5";
            // 
            // exitsInsertField
            // 
            this.exitsInsertField.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.exitsInsertField.Image = global::LAZYSHELL.Properties.Resources.new_small;
            this.exitsInsertField.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.exitsInsertField.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.exitsInsertField.Name = "exitsInsertField";
            this.exitsInsertField.Size = new System.Drawing.Size(23, 22);
            this.exitsInsertField.Text = "New Exit";
            this.exitsInsertField.Click += new System.EventHandler(this.exitsInsertField_Click);
            // 
            // exitsDeleteField
            // 
            this.exitsDeleteField.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.exitsDeleteField.Image = global::LAZYSHELL.Properties.Resources.delete_small;
            this.exitsDeleteField.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.exitsDeleteField.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.exitsDeleteField.Name = "exitsDeleteField";
            this.exitsDeleteField.Size = new System.Drawing.Size(23, 22);
            this.exitsDeleteField.Text = "Delete Exit";
            this.exitsDeleteField.Click += new System.EventHandler(this.exitsDeleteField_Click);
            // 
            // exitsCopyField
            // 
            this.exitsCopyField.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.exitsCopyField.Image = global::LAZYSHELL.Properties.Resources.copy_small;
            this.exitsCopyField.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.exitsCopyField.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.exitsCopyField.Name = "exitsCopyField";
            this.exitsCopyField.Size = new System.Drawing.Size(23, 22);
            this.exitsCopyField.Text = "Copy Exit";
            this.exitsCopyField.Click += new System.EventHandler(this.exitsCopyField_Click);
            // 
            // exitsPasteField
            // 
            this.exitsPasteField.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.exitsPasteField.Image = global::LAZYSHELL.Properties.Resources.paste_small;
            this.exitsPasteField.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.exitsPasteField.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.exitsPasteField.Name = "exitsPasteField";
            this.exitsPasteField.Size = new System.Drawing.Size(23, 22);
            this.exitsPasteField.Text = "Paste Exit";
            this.exitsPasteField.Click += new System.EventHandler(this.exitsPasteField_Click);
            // 
            // exitsDuplicateField
            // 
            this.exitsDuplicateField.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.exitsDuplicateField.Image = global::LAZYSHELL.Properties.Resources.duplicate_small;
            this.exitsDuplicateField.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.exitsDuplicateField.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.exitsDuplicateField.Name = "exitsDuplicateField";
            this.exitsDuplicateField.Size = new System.Drawing.Size(23, 22);
            this.exitsDuplicateField.Text = "Duplicate Exit";
            this.exitsDuplicateField.Click += new System.EventHandler(this.exitsDuplicateField_Click);
            // 
            // toolStripSeparator19
            // 
            this.toolStripSeparator19.Name = "toolStripSeparator19";
            this.toolStripSeparator19.Size = new System.Drawing.Size(6, 25);
            // 
            // exitsBytesLeft
            // 
            this.exitsBytesLeft.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Bold);
            this.exitsBytesLeft.Name = "exitsBytesLeft";
            this.exitsBytesLeft.Size = new System.Drawing.Size(52, 22);
            this.exitsBytesLeft.Text = "bytes left";
            // 
            // label61
            // 
            this.label61.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label61.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label61.Dock = System.Windows.Forms.DockStyle.Top;
            this.label61.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label61.ForeColor = System.Drawing.SystemColors.Control;
            this.label61.Location = new System.Drawing.Point(0, 0);
            this.label61.Name = "label61";
            this.label61.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label61.Size = new System.Drawing.Size(260, 19);
            this.label61.TabIndex = 453;
            this.label61.Text = "EXIT FIELDS";
            this.label61.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage4);
            this.tabControl.Controls.Add(this.tabPage3);
            this.tabControl.Controls.Add(this.tabPage8);
            this.tabControl.Controls.Add(this.tabPage9);
            this.tabControl.Controls.Add(this.tabPage10);
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Left;
            this.tabControl.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl.ItemSize = new System.Drawing.Size(44, 18);
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.Padding = new System.Drawing.Point(5, 4);
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(268, 666);
            this.tabControl.TabIndex = 6;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.panel70);
            this.tabPage4.Controls.Add(this.panel69);
            this.tabPage4.Controls.Add(this.panel71);
            this.tabPage4.Controls.Add(this.panel72);
            this.tabPage4.Controls.Add(this.panel28);
            this.tabPage4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(260, 640);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "MAPS";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // panel70
            // 
            this.panel70.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel70.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel70.Controls.Add(this.label89);
            this.panel70.Controls.Add(this.mapTilemapL1Num);
            this.panel70.Controls.Add(this.mapSetL3Priority);
            this.panel70.Controls.Add(this.mapTilemapL2Num);
            this.panel70.Controls.Add(this.panel35);
            this.panel70.Controls.Add(this.label43);
            this.panel70.Controls.Add(this.mapTilemapL3Num);
            this.panel70.Controls.Add(this.panel36);
            this.panel70.Controls.Add(this.label42);
            this.panel70.Controls.Add(this.panel37);
            this.panel70.Controls.Add(this.label41);
            this.panel70.Controls.Add(this.panel38);
            this.panel70.Controls.Add(this.mapPhysicalMapNum);
            this.panel70.Controls.Add(this.label45);
            this.panel70.Controls.Add(this.panel39);
            this.panel70.Controls.Add(this.label76);
            this.panel70.Controls.Add(this.mapBattlefieldNum);
            this.panel70.Location = new System.Drawing.Point(0, 233);
            this.panel70.Name = "panel70";
            this.panel70.Size = new System.Drawing.Size(260, 112);
            this.panel70.TabIndex = 443;
            // 
            // label89
            // 
            this.label89.BackColor = System.Drawing.SystemColors.Control;
            this.label89.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label89.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label89.Location = new System.Drawing.Point(0, 0);
            this.label89.Name = "label89";
            this.label89.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label89.Size = new System.Drawing.Size(126, 17);
            this.label89.TabIndex = 154;
            this.label89.Text = "TILEMAPS";
            this.label89.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mapTilemapL1Num
            // 
            this.mapTilemapL1Num.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.mapTilemapL1Num.Location = new System.Drawing.Point(75, 19);
            this.mapTilemapL1Num.Maximum = new decimal(new int[] {
            244,
            0,
            0,
            0});
            this.mapTilemapL1Num.Name = "mapTilemapL1Num";
            this.mapTilemapL1Num.Size = new System.Drawing.Size(51, 17);
            this.mapTilemapL1Num.TabIndex = 70;
            this.mapTilemapL1Num.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.mapTilemapL1Num.ValueChanged += new System.EventHandler(this.mapTilemapL1Num_ValueChanged);
            // 
            // mapSetL3Priority
            // 
            this.mapSetL3Priority.Appearance = System.Windows.Forms.Appearance.Button;
            this.mapSetL3Priority.BackColor = System.Drawing.SystemColors.Control;
            this.mapSetL3Priority.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mapSetL3Priority.ForeColor = System.Drawing.Color.Gray;
            this.mapSetL3Priority.Location = new System.Drawing.Point(127, 0);
            this.mapSetL3Priority.Name = "mapSetL3Priority";
            this.mapSetL3Priority.Size = new System.Drawing.Size(129, 18);
            this.mapSetL3Priority.TabIndex = 69;
            this.mapSetL3Priority.Text = "L3 PRIORITY 1";
            this.mapSetL3Priority.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.mapSetL3Priority.UseCompatibleTextRendering = true;
            this.mapSetL3Priority.UseVisualStyleBackColor = false;
            this.mapSetL3Priority.CheckedChanged += new System.EventHandler(this.mapSetL3Priority_CheckedChanged);
            // 
            // mapTilemapL2Num
            // 
            this.mapTilemapL2Num.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.mapTilemapL2Num.Location = new System.Drawing.Point(75, 37);
            this.mapTilemapL2Num.Maximum = new decimal(new int[] {
            244,
            0,
            0,
            0});
            this.mapTilemapL2Num.Name = "mapTilemapL2Num";
            this.mapTilemapL2Num.Size = new System.Drawing.Size(51, 17);
            this.mapTilemapL2Num.TabIndex = 72;
            this.mapTilemapL2Num.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.mapTilemapL2Num.ValueChanged += new System.EventHandler(this.mapTilemapL2Num_ValueChanged);
            // 
            // panel35
            // 
            this.panel35.BackColor = System.Drawing.SystemColors.Window;
            this.panel35.Controls.Add(this.mapBattlefieldName);
            this.panel35.Location = new System.Drawing.Point(127, 91);
            this.panel35.Name = "panel35";
            this.panel35.Size = new System.Drawing.Size(130, 17);
            this.panel35.TabIndex = 79;
            // 
            // mapBattlefieldName
            // 
            this.mapBattlefieldName.DropDownHeight = 200;
            this.mapBattlefieldName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mapBattlefieldName.IntegralHeight = false;
            this.mapBattlefieldName.Items.AddRange(new object[] {
            "Bowser\'s Keep",
            "Castle",
            "House",
            "Mushroom Kingdom",
            "Kero Sewers",
            "Mines",
            "Forest",
            "Underground",
            "Sea",
            "Sea Enclave",
            "Sunken Ship",
            "Forest",
            "Barrel Volcano",
            "Star Hill",
            "Castle",
            "Booster Tower",
            "Bowser\'s Keep",
            "Grasslands",
            "Mountains",
            "Plains",
            "Nimbus Land",
            "Nimbus Castle",
            "Count Down",
            "Smithy Factory",
            "Kero Sewers",
            "Bean Valley",
            "Land\'s End Desert",
            "Belome Temple",
            "Pipe Rooms",
            "Beanstalks",
            "Forest",
            "Forest",
            "Forest",
            "Forest",
            "House",
            "Forest",
            "Mines",
            "Forest",
            "Forest",
            "Forest",
            "Forest",
            "Forest",
            "Forest",
            "Forest",
            "Sunken Ship",
            "Forest",
            "Barrel Volcano",
            "Castle",
            "Kero Sewers",
            "Forest",
            "Booster Tower",
            "Forest",
            "Bowser\'s Keep",
            "Bowser\'s Keep",
            "Grasslands",
            "Mountains",
            "Forest",
            "Forest",
            "Forest",
            "Forest",
            "Forest",
            "Forest",
            "Forest",
            "Forest"});
            this.mapBattlefieldName.Location = new System.Drawing.Point(-2, -2);
            this.mapBattlefieldName.Name = "mapBattlefieldName";
            this.mapBattlefieldName.Size = new System.Drawing.Size(133, 21);
            this.mapBattlefieldName.TabIndex = 144;
            this.mapBattlefieldName.SelectedIndexChanged += new System.EventHandler(this.mapBattlefieldName_SelectedIndexChanged);
            // 
            // label43
            // 
            this.label43.BackColor = System.Drawing.SystemColors.Control;
            this.label43.Location = new System.Drawing.Point(0, 19);
            this.label43.Name = "label43";
            this.label43.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label43.Size = new System.Drawing.Size(74, 17);
            this.label43.TabIndex = 132;
            this.label43.Text = "L1 Tilemap";
            // 
            // mapTilemapL3Num
            // 
            this.mapTilemapL3Num.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.mapTilemapL3Num.Location = new System.Drawing.Point(75, 55);
            this.mapTilemapL3Num.Maximum = new decimal(new int[] {
            63,
            0,
            0,
            0});
            this.mapTilemapL3Num.Name = "mapTilemapL3Num";
            this.mapTilemapL3Num.Size = new System.Drawing.Size(51, 17);
            this.mapTilemapL3Num.TabIndex = 74;
            this.mapTilemapL3Num.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.mapTilemapL3Num.ValueChanged += new System.EventHandler(this.mapTilemapL3Num_ValueChanged);
            // 
            // panel36
            // 
            this.panel36.BackColor = System.Drawing.SystemColors.Window;
            this.panel36.Controls.Add(this.mapTilemapL3Name);
            this.panel36.Location = new System.Drawing.Point(127, 55);
            this.panel36.Name = "panel36";
            this.panel36.Size = new System.Drawing.Size(130, 17);
            this.panel36.TabIndex = 75;
            // 
            // mapTilemapL3Name
            // 
            this.mapTilemapL3Name.DropDownHeight = 200;
            this.mapTilemapL3Name.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mapTilemapL3Name.DropDownWidth = 200;
            this.mapTilemapL3Name.IntegralHeight = false;
            this.mapTilemapL3Name.Location = new System.Drawing.Point(-2, -2);
            this.mapTilemapL3Name.Name = "mapTilemapL3Name";
            this.mapTilemapL3Name.Size = new System.Drawing.Size(133, 21);
            this.mapTilemapL3Name.TabIndex = 140;
            this.mapTilemapL3Name.SelectedIndexChanged += new System.EventHandler(this.mapTilemapL3Name_SelectedIndexChanged);
            // 
            // label42
            // 
            this.label42.BackColor = System.Drawing.SystemColors.Control;
            this.label42.Location = new System.Drawing.Point(0, 37);
            this.label42.Name = "label42";
            this.label42.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label42.Size = new System.Drawing.Size(74, 17);
            this.label42.TabIndex = 136;
            this.label42.Text = "L2 Tilemap";
            // 
            // panel37
            // 
            this.panel37.BackColor = System.Drawing.SystemColors.Window;
            this.panel37.Controls.Add(this.mapTilemapL1Name);
            this.panel37.Location = new System.Drawing.Point(127, 19);
            this.panel37.Name = "panel37";
            this.panel37.Size = new System.Drawing.Size(130, 17);
            this.panel37.TabIndex = 71;
            // 
            // mapTilemapL1Name
            // 
            this.mapTilemapL1Name.DropDownHeight = 200;
            this.mapTilemapL1Name.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mapTilemapL1Name.DropDownWidth = 200;
            this.mapTilemapL1Name.IntegralHeight = false;
            this.mapTilemapL1Name.Location = new System.Drawing.Point(-2, -2);
            this.mapTilemapL1Name.Name = "mapTilemapL1Name";
            this.mapTilemapL1Name.Size = new System.Drawing.Size(133, 21);
            this.mapTilemapL1Name.TabIndex = 138;
            this.mapTilemapL1Name.SelectedIndexChanged += new System.EventHandler(this.mapTilemapL1Name_SelectedIndexChanged);
            // 
            // label41
            // 
            this.label41.BackColor = System.Drawing.SystemColors.Control;
            this.label41.Location = new System.Drawing.Point(0, 55);
            this.label41.Name = "label41";
            this.label41.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label41.Size = new System.Drawing.Size(74, 17);
            this.label41.TabIndex = 137;
            this.label41.Text = "L3 Tilemap";
            // 
            // panel38
            // 
            this.panel38.BackColor = System.Drawing.SystemColors.Window;
            this.panel38.Controls.Add(this.mapPhysicalMapName);
            this.panel38.Location = new System.Drawing.Point(127, 73);
            this.panel38.Name = "panel38";
            this.panel38.Size = new System.Drawing.Size(130, 17);
            this.panel38.TabIndex = 77;
            // 
            // mapPhysicalMapName
            // 
            this.mapPhysicalMapName.DropDownHeight = 200;
            this.mapPhysicalMapName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mapPhysicalMapName.DropDownWidth = 200;
            this.mapPhysicalMapName.IntegralHeight = false;
            this.mapPhysicalMapName.Location = new System.Drawing.Point(-2, -2);
            this.mapPhysicalMapName.Name = "mapPhysicalMapName";
            this.mapPhysicalMapName.Size = new System.Drawing.Size(133, 21);
            this.mapPhysicalMapName.TabIndex = 143;
            this.mapPhysicalMapName.SelectedIndexChanged += new System.EventHandler(this.mapPhysicalMapName_SelectedIndexChanged);
            // 
            // mapPhysicalMapNum
            // 
            this.mapPhysicalMapNum.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.mapPhysicalMapNum.Location = new System.Drawing.Point(75, 73);
            this.mapPhysicalMapNum.Maximum = new decimal(new int[] {
            119,
            0,
            0,
            0});
            this.mapPhysicalMapNum.Name = "mapPhysicalMapNum";
            this.mapPhysicalMapNum.Size = new System.Drawing.Size(51, 17);
            this.mapPhysicalMapNum.TabIndex = 76;
            this.mapPhysicalMapNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.mapPhysicalMapNum.ValueChanged += new System.EventHandler(this.mapPhysicalMapNum_ValueChanged);
            // 
            // label45
            // 
            this.label45.BackColor = System.Drawing.SystemColors.Control;
            this.label45.Location = new System.Drawing.Point(0, 73);
            this.label45.Name = "label45";
            this.label45.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label45.Size = new System.Drawing.Size(74, 17);
            this.label45.TabIndex = 152;
            this.label45.Text = "Solidity Map";
            // 
            // panel39
            // 
            this.panel39.BackColor = System.Drawing.SystemColors.Window;
            this.panel39.Controls.Add(this.mapTilemapL2Name);
            this.panel39.Location = new System.Drawing.Point(127, 37);
            this.panel39.Name = "panel39";
            this.panel39.Size = new System.Drawing.Size(130, 17);
            this.panel39.TabIndex = 73;
            // 
            // mapTilemapL2Name
            // 
            this.mapTilemapL2Name.DropDownHeight = 200;
            this.mapTilemapL2Name.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mapTilemapL2Name.DropDownWidth = 200;
            this.mapTilemapL2Name.IntegralHeight = false;
            this.mapTilemapL2Name.Location = new System.Drawing.Point(-2, -2);
            this.mapTilemapL2Name.Name = "mapTilemapL2Name";
            this.mapTilemapL2Name.Size = new System.Drawing.Size(133, 21);
            this.mapTilemapL2Name.TabIndex = 139;
            this.mapTilemapL2Name.SelectedIndexChanged += new System.EventHandler(this.mapTilemapL2Name_SelectedIndexChanged);
            // 
            // label76
            // 
            this.label76.BackColor = System.Drawing.SystemColors.Control;
            this.label76.Location = new System.Drawing.Point(0, 91);
            this.label76.Name = "label76";
            this.label76.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label76.Size = new System.Drawing.Size(74, 17);
            this.label76.TabIndex = 155;
            this.label76.Text = "Battlefield";
            // 
            // mapBattlefieldNum
            // 
            this.mapBattlefieldNum.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.mapBattlefieldNum.Location = new System.Drawing.Point(75, 91);
            this.mapBattlefieldNum.Maximum = new decimal(new int[] {
            54,
            0,
            0,
            0});
            this.mapBattlefieldNum.Name = "mapBattlefieldNum";
            this.mapBattlefieldNum.Size = new System.Drawing.Size(51, 17);
            this.mapBattlefieldNum.TabIndex = 78;
            this.mapBattlefieldNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.mapBattlefieldNum.ValueChanged += new System.EventHandler(this.mapBattlefieldNum_ValueChanged);
            // 
            // panel69
            // 
            this.panel69.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel69.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel69.Controls.Add(this.label114);
            this.panel69.Controls.Add(this.panel40);
            this.panel69.Controls.Add(this.mapPaletteSetNum);
            this.panel69.Controls.Add(this.label46);
            this.panel69.Location = new System.Drawing.Point(0, 347);
            this.panel69.Name = "panel69";
            this.panel69.Size = new System.Drawing.Size(260, 40);
            this.panel69.TabIndex = 442;
            // 
            // label114
            // 
            this.label114.BackColor = System.Drawing.SystemColors.Control;
            this.label114.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label114.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label114.Location = new System.Drawing.Point(0, 0);
            this.label114.Name = "label114";
            this.label114.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label114.Size = new System.Drawing.Size(256, 17);
            this.label114.TabIndex = 160;
            this.label114.Text = "PALETTES";
            this.label114.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel40
            // 
            this.panel40.BackColor = System.Drawing.SystemColors.Window;
            this.panel40.Controls.Add(this.mapPaletteSetName);
            this.panel40.Location = new System.Drawing.Point(127, 19);
            this.panel40.Name = "panel40";
            this.panel40.Size = new System.Drawing.Size(130, 17);
            this.panel40.TabIndex = 81;
            // 
            // mapPaletteSetName
            // 
            this.mapPaletteSetName.DropDownHeight = 200;
            this.mapPaletteSetName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mapPaletteSetName.DropDownWidth = 200;
            this.mapPaletteSetName.IntegralHeight = false;
            this.mapPaletteSetName.Location = new System.Drawing.Point(-2, -2);
            this.mapPaletteSetName.Name = "mapPaletteSetName";
            this.mapPaletteSetName.Size = new System.Drawing.Size(133, 21);
            this.mapPaletteSetName.TabIndex = 158;
            this.mapPaletteSetName.SelectedIndexChanged += new System.EventHandler(this.mapPaletteSetName_SelectedIndexChanged);
            // 
            // mapPaletteSetNum
            // 
            this.mapPaletteSetNum.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.mapPaletteSetNum.Location = new System.Drawing.Point(75, 19);
            this.mapPaletteSetNum.Maximum = new decimal(new int[] {
            93,
            0,
            0,
            0});
            this.mapPaletteSetNum.Name = "mapPaletteSetNum";
            this.mapPaletteSetNum.Size = new System.Drawing.Size(51, 17);
            this.mapPaletteSetNum.TabIndex = 80;
            this.mapPaletteSetNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.mapPaletteSetNum.ValueChanged += new System.EventHandler(this.mapPaletteSetNum_ValueChanged);
            // 
            // label46
            // 
            this.label46.BackColor = System.Drawing.SystemColors.Control;
            this.label46.Location = new System.Drawing.Point(0, 19);
            this.label46.Name = "label46";
            this.label46.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label46.Size = new System.Drawing.Size(74, 17);
            this.label46.TabIndex = 157;
            this.label46.Text = "Palette Set";
            // 
            // panel71
            // 
            this.panel71.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel71.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel71.Controls.Add(this.label88);
            this.panel71.Controls.Add(this.label40);
            this.panel71.Controls.Add(this.label35);
            this.panel71.Controls.Add(this.mapTilesetL3Num);
            this.panel71.Controls.Add(this.mapTilesetL2Num);
            this.panel71.Controls.Add(this.mapTilesetL1Num);
            this.panel71.Controls.Add(this.panel32);
            this.panel71.Controls.Add(this.label34);
            this.panel71.Controls.Add(this.panel33);
            this.panel71.Controls.Add(this.panel34);
            this.panel71.Location = new System.Drawing.Point(0, 155);
            this.panel71.Name = "panel71";
            this.panel71.Size = new System.Drawing.Size(260, 76);
            this.panel71.TabIndex = 444;
            // 
            // label88
            // 
            this.label88.BackColor = System.Drawing.SystemColors.Control;
            this.label88.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label88.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label88.Location = new System.Drawing.Point(0, 0);
            this.label88.Name = "label88";
            this.label88.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label88.Size = new System.Drawing.Size(256, 17);
            this.label88.TabIndex = 153;
            this.label88.Text = "TILESETS";
            this.label88.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label40
            // 
            this.label40.BackColor = System.Drawing.SystemColors.Control;
            this.label40.Location = new System.Drawing.Point(0, 55);
            this.label40.Name = "label40";
            this.label40.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label40.Size = new System.Drawing.Size(74, 17);
            this.label40.TabIndex = 128;
            this.label40.Text = "L3 Tileset";
            // 
            // label35
            // 
            this.label35.BackColor = System.Drawing.SystemColors.Control;
            this.label35.Location = new System.Drawing.Point(0, 37);
            this.label35.Name = "label35";
            this.label35.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label35.Size = new System.Drawing.Size(74, 17);
            this.label35.TabIndex = 127;
            this.label35.Text = "L2 Tileset";
            // 
            // mapTilesetL3Num
            // 
            this.mapTilesetL3Num.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.mapTilesetL3Num.Location = new System.Drawing.Point(75, 55);
            this.mapTilesetL3Num.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.mapTilesetL3Num.Name = "mapTilesetL3Num";
            this.mapTilesetL3Num.Size = new System.Drawing.Size(51, 17);
            this.mapTilesetL3Num.TabIndex = 67;
            this.mapTilesetL3Num.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.mapTilesetL3Num.ValueChanged += new System.EventHandler(this.mapTilesetL3Num_ValueChanged);
            // 
            // mapTilesetL2Num
            // 
            this.mapTilesetL2Num.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.mapTilesetL2Num.Location = new System.Drawing.Point(75, 37);
            this.mapTilesetL2Num.Maximum = new decimal(new int[] {
            92,
            0,
            0,
            0});
            this.mapTilesetL2Num.Name = "mapTilesetL2Num";
            this.mapTilesetL2Num.Size = new System.Drawing.Size(51, 17);
            this.mapTilesetL2Num.TabIndex = 65;
            this.mapTilesetL2Num.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.mapTilesetL2Num.ValueChanged += new System.EventHandler(this.mapTilesetL2Num_ValueChanged);
            // 
            // mapTilesetL1Num
            // 
            this.mapTilesetL1Num.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.mapTilesetL1Num.Location = new System.Drawing.Point(75, 19);
            this.mapTilesetL1Num.Maximum = new decimal(new int[] {
            92,
            0,
            0,
            0});
            this.mapTilesetL1Num.Name = "mapTilesetL1Num";
            this.mapTilesetL1Num.Size = new System.Drawing.Size(51, 17);
            this.mapTilesetL1Num.TabIndex = 63;
            this.mapTilesetL1Num.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.mapTilesetL1Num.ValueChanged += new System.EventHandler(this.mapTilesetL1Num_ValueChanged);
            // 
            // panel32
            // 
            this.panel32.BackColor = System.Drawing.SystemColors.Window;
            this.panel32.Controls.Add(this.mapTilesetL2Name);
            this.panel32.Location = new System.Drawing.Point(127, 37);
            this.panel32.Name = "panel32";
            this.panel32.Size = new System.Drawing.Size(130, 17);
            this.panel32.TabIndex = 66;
            // 
            // mapTilesetL2Name
            // 
            this.mapTilesetL2Name.DropDownHeight = 200;
            this.mapTilesetL2Name.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mapTilesetL2Name.DropDownWidth = 200;
            this.mapTilesetL2Name.IntegralHeight = false;
            this.mapTilesetL2Name.Location = new System.Drawing.Point(-2, -2);
            this.mapTilesetL2Name.Name = "mapTilesetL2Name";
            this.mapTilesetL2Name.Size = new System.Drawing.Size(133, 21);
            this.mapTilesetL2Name.TabIndex = 130;
            this.mapTilesetL2Name.SelectedIndexChanged += new System.EventHandler(this.mapTilesetL2Name_SelectedIndexChanged);
            // 
            // label34
            // 
            this.label34.BackColor = System.Drawing.SystemColors.Control;
            this.label34.Location = new System.Drawing.Point(0, 19);
            this.label34.Name = "label34";
            this.label34.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label34.Size = new System.Drawing.Size(74, 17);
            this.label34.TabIndex = 123;
            this.label34.Text = "L1 Tileset";
            // 
            // panel33
            // 
            this.panel33.BackColor = System.Drawing.SystemColors.Window;
            this.panel33.Controls.Add(this.mapTilesetL3Name);
            this.panel33.Location = new System.Drawing.Point(127, 55);
            this.panel33.Name = "panel33";
            this.panel33.Size = new System.Drawing.Size(130, 17);
            this.panel33.TabIndex = 68;
            // 
            // mapTilesetL3Name
            // 
            this.mapTilesetL3Name.DropDownHeight = 200;
            this.mapTilesetL3Name.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mapTilesetL3Name.IntegralHeight = false;
            this.mapTilesetL3Name.Location = new System.Drawing.Point(-2, -2);
            this.mapTilesetL3Name.Name = "mapTilesetL3Name";
            this.mapTilesetL3Name.Size = new System.Drawing.Size(133, 21);
            this.mapTilesetL3Name.TabIndex = 131;
            this.mapTilesetL3Name.SelectedIndexChanged += new System.EventHandler(this.mapTilesetL3Name_SelectedIndexChanged);
            // 
            // panel34
            // 
            this.panel34.BackColor = System.Drawing.SystemColors.Window;
            this.panel34.Controls.Add(this.mapTilesetL1Name);
            this.panel34.Location = new System.Drawing.Point(127, 19);
            this.panel34.Name = "panel34";
            this.panel34.Size = new System.Drawing.Size(130, 17);
            this.panel34.TabIndex = 64;
            // 
            // mapTilesetL1Name
            // 
            this.mapTilesetL1Name.DropDownHeight = 200;
            this.mapTilesetL1Name.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mapTilesetL1Name.DropDownWidth = 200;
            this.mapTilesetL1Name.IntegralHeight = false;
            this.mapTilesetL1Name.Location = new System.Drawing.Point(-2, -2);
            this.mapTilesetL1Name.Name = "mapTilesetL1Name";
            this.mapTilesetL1Name.Size = new System.Drawing.Size(133, 21);
            this.mapTilesetL1Name.TabIndex = 129;
            this.mapTilesetL1Name.SelectedIndexChanged += new System.EventHandler(this.mapTilesetL1Name_SelectedIndexChanged);
            // 
            // panel72
            // 
            this.panel72.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel72.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel72.Controls.Add(this.label87);
            this.panel72.Controls.Add(this.label44);
            this.panel72.Controls.Add(this.mapGFXSet1Num);
            this.panel72.Controls.Add(this.label19);
            this.panel72.Controls.Add(this.mapGFXSet2Num);
            this.panel72.Controls.Add(this.panel31);
            this.panel72.Controls.Add(this.label18);
            this.panel72.Controls.Add(this.panel29);
            this.panel72.Controls.Add(this.mapGFXSet3Num);
            this.panel72.Controls.Add(this.panel12);
            this.panel72.Controls.Add(this.label17);
            this.panel72.Controls.Add(this.panel30);
            this.panel72.Controls.Add(this.mapGFXSet4Num);
            this.panel72.Controls.Add(this.panel13);
            this.panel72.Controls.Add(this.label16);
            this.panel72.Controls.Add(this.mapGFXSetL3Num);
            this.panel72.Controls.Add(this.mapGFXSet5Num);
            this.panel72.Controls.Add(this.panel11);
            this.panel72.Controls.Add(this.label2);
            this.panel72.Location = new System.Drawing.Point(0, 23);
            this.panel72.Name = "panel72";
            this.panel72.Size = new System.Drawing.Size(260, 130);
            this.panel72.TabIndex = 445;
            // 
            // label87
            // 
            this.label87.BackColor = System.Drawing.SystemColors.Control;
            this.label87.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label87.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label87.Location = new System.Drawing.Point(0, 0);
            this.label87.Name = "label87";
            this.label87.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label87.Size = new System.Drawing.Size(256, 17);
            this.label87.TabIndex = 55;
            this.label87.Text = "GRAPHICS SETS";
            this.label87.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label44
            // 
            this.label44.BackColor = System.Drawing.SystemColors.Control;
            this.label44.Location = new System.Drawing.Point(0, 109);
            this.label44.Name = "label44";
            this.label44.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label44.Size = new System.Drawing.Size(74, 17);
            this.label44.TabIndex = 35;
            this.label44.Text = "L3 GFX Set";
            // 
            // mapGFXSet1Num
            // 
            this.mapGFXSet1Num.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.mapGFXSet1Num.Location = new System.Drawing.Point(75, 19);
            this.mapGFXSet1Num.Maximum = new decimal(new int[] {
            199,
            0,
            0,
            0});
            this.mapGFXSet1Num.Name = "mapGFXSet1Num";
            this.mapGFXSet1Num.Size = new System.Drawing.Size(51, 17);
            this.mapGFXSet1Num.TabIndex = 51;
            this.mapGFXSet1Num.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.mapGFXSet1Num.ValueChanged += new System.EventHandler(this.mapGFXSet1Num_ValueChanged);
            // 
            // mapGFXSet2Num
            // 
            this.mapGFXSet2Num.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.mapGFXSet2Num.Location = new System.Drawing.Point(75, 37);
            this.mapGFXSet2Num.Maximum = new decimal(new int[] {
            199,
            0,
            0,
            0});
            this.mapGFXSet2Num.Name = "mapGFXSet2Num";
            this.mapGFXSet2Num.Size = new System.Drawing.Size(51, 17);
            this.mapGFXSet2Num.TabIndex = 53;
            this.mapGFXSet2Num.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.mapGFXSet2Num.ValueChanged += new System.EventHandler(this.mapGFXSet2Num_ValueChanged);
            // 
            // panel31
            // 
            this.panel31.BackColor = System.Drawing.SystemColors.Window;
            this.panel31.Controls.Add(this.mapGFXSetL3Name);
            this.panel31.Location = new System.Drawing.Point(127, 109);
            this.panel31.Name = "panel31";
            this.panel31.Size = new System.Drawing.Size(130, 17);
            this.panel31.TabIndex = 62;
            // 
            // mapGFXSetL3Name
            // 
            this.mapGFXSetL3Name.DropDownHeight = 197;
            this.mapGFXSetL3Name.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mapGFXSetL3Name.IntegralHeight = false;
            this.mapGFXSetL3Name.Items.AddRange(new object[] {
            "Monstro Town",
            "Tower, interior",
            "Castle, interior",
            "Forest Maze",
            "Sunken Ship",
            "Sewers 1",
            "____",
            "Plains",
            "____",
            "Waterfall",
            "Nimbus clouds",
            "Yo\'ster Isle",
            "Town 2",
            "Sewers 2",
            "Houses, interior",
            "Keep throne",
            "____",
            "Maps",
            "Star Hill",
            "Marrymore Scene",
            "Nimbus houses",
            "Keep 2",
            "Temple",
            "Desert",
            "____",
            "Smithy Factory",
            "Smithy Pad",
            "Smithy 2",
            "{NONE}"});
            this.mapGFXSetL3Name.Location = new System.Drawing.Point(-2, -2);
            this.mapGFXSetL3Name.Name = "mapGFXSetL3Name";
            this.mapGFXSetL3Name.Size = new System.Drawing.Size(133, 21);
            this.mapGFXSetL3Name.TabIndex = 141;
            this.mapGFXSetL3Name.SelectedIndexChanged += new System.EventHandler(this.mapGFXSetL3Name_SelectedIndexChanged);
            // 
            // panel29
            // 
            this.panel29.BackColor = System.Drawing.SystemColors.Window;
            this.panel29.Controls.Add(this.mapGFXSet4Name);
            this.panel29.Location = new System.Drawing.Point(127, 73);
            this.panel29.Name = "panel29";
            this.panel29.Size = new System.Drawing.Size(130, 17);
            this.panel29.TabIndex = 58;
            // 
            // mapGFXSet4Name
            // 
            this.mapGFXSet4Name.DropDownHeight = 197;
            this.mapGFXSet4Name.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mapGFXSet4Name.DropDownWidth = 197;
            this.mapGFXSet4Name.IntegralHeight = false;
            this.mapGFXSet4Name.Location = new System.Drawing.Point(-2, -2);
            this.mapGFXSet4Name.Name = "mapGFXSet4Name";
            this.mapGFXSet4Name.Size = new System.Drawing.Size(133, 21);
            this.mapGFXSet4Name.TabIndex = 121;
            this.mapGFXSet4Name.SelectedIndexChanged += new System.EventHandler(this.mapGFXSet4Name_SelectedIndexChanged);
            // 
            // mapGFXSet3Num
            // 
            this.mapGFXSet3Num.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.mapGFXSet3Num.Location = new System.Drawing.Point(75, 55);
            this.mapGFXSet3Num.Maximum = new decimal(new int[] {
            199,
            0,
            0,
            0});
            this.mapGFXSet3Num.Name = "mapGFXSet3Num";
            this.mapGFXSet3Num.Size = new System.Drawing.Size(51, 17);
            this.mapGFXSet3Num.TabIndex = 55;
            this.mapGFXSet3Num.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.mapGFXSet3Num.ValueChanged += new System.EventHandler(this.mapGFXSet3Num_ValueChanged);
            // 
            // panel12
            // 
            this.panel12.BackColor = System.Drawing.SystemColors.Window;
            this.panel12.Controls.Add(this.mapGFXSet2Name);
            this.panel12.Location = new System.Drawing.Point(127, 37);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(130, 17);
            this.panel12.TabIndex = 54;
            // 
            // mapGFXSet2Name
            // 
            this.mapGFXSet2Name.DropDownHeight = 197;
            this.mapGFXSet2Name.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mapGFXSet2Name.DropDownWidth = 197;
            this.mapGFXSet2Name.IntegralHeight = false;
            this.mapGFXSet2Name.Location = new System.Drawing.Point(-2, -2);
            this.mapGFXSet2Name.Name = "mapGFXSet2Name";
            this.mapGFXSet2Name.Size = new System.Drawing.Size(133, 21);
            this.mapGFXSet2Name.TabIndex = 119;
            this.mapGFXSet2Name.SelectedIndexChanged += new System.EventHandler(this.mapGFXSet2Name_SelectedIndexChanged);
            // 
            // panel30
            // 
            this.panel30.BackColor = System.Drawing.SystemColors.Window;
            this.panel30.Controls.Add(this.mapGFXSet5Name);
            this.panel30.Location = new System.Drawing.Point(127, 91);
            this.panel30.Name = "panel30";
            this.panel30.Size = new System.Drawing.Size(130, 17);
            this.panel30.TabIndex = 60;
            // 
            // mapGFXSet5Name
            // 
            this.mapGFXSet5Name.DropDownHeight = 197;
            this.mapGFXSet5Name.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mapGFXSet5Name.DropDownWidth = 197;
            this.mapGFXSet5Name.IntegralHeight = false;
            this.mapGFXSet5Name.Location = new System.Drawing.Point(-2, -2);
            this.mapGFXSet5Name.Name = "mapGFXSet5Name";
            this.mapGFXSet5Name.Size = new System.Drawing.Size(133, 21);
            this.mapGFXSet5Name.TabIndex = 122;
            this.mapGFXSet5Name.SelectedIndexChanged += new System.EventHandler(this.mapGFXSet5Name_SelectedIndexChanged);
            // 
            // mapGFXSet4Num
            // 
            this.mapGFXSet4Num.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.mapGFXSet4Num.Location = new System.Drawing.Point(75, 73);
            this.mapGFXSet4Num.Maximum = new decimal(new int[] {
            199,
            0,
            0,
            0});
            this.mapGFXSet4Num.Name = "mapGFXSet4Num";
            this.mapGFXSet4Num.Size = new System.Drawing.Size(51, 17);
            this.mapGFXSet4Num.TabIndex = 57;
            this.mapGFXSet4Num.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.mapGFXSet4Num.ValueChanged += new System.EventHandler(this.mapGFXSet4Num_ValueChanged);
            // 
            // panel13
            // 
            this.panel13.BackColor = System.Drawing.SystemColors.Window;
            this.panel13.Controls.Add(this.mapGFXSet3Name);
            this.panel13.Location = new System.Drawing.Point(127, 55);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(130, 17);
            this.panel13.TabIndex = 56;
            // 
            // mapGFXSet3Name
            // 
            this.mapGFXSet3Name.DropDownHeight = 197;
            this.mapGFXSet3Name.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mapGFXSet3Name.DropDownWidth = 197;
            this.mapGFXSet3Name.IntegralHeight = false;
            this.mapGFXSet3Name.Location = new System.Drawing.Point(-2, -2);
            this.mapGFXSet3Name.Name = "mapGFXSet3Name";
            this.mapGFXSet3Name.Size = new System.Drawing.Size(133, 21);
            this.mapGFXSet3Name.TabIndex = 120;
            this.mapGFXSet3Name.SelectedIndexChanged += new System.EventHandler(this.mapGFXSet3Name_SelectedIndexChanged);
            // 
            // mapGFXSetL3Num
            // 
            this.mapGFXSetL3Num.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.mapGFXSetL3Num.Location = new System.Drawing.Point(75, 109);
            this.mapGFXSetL3Num.Maximum = new decimal(new int[] {
            28,
            0,
            0,
            0});
            this.mapGFXSetL3Num.Name = "mapGFXSetL3Num";
            this.mapGFXSetL3Num.Size = new System.Drawing.Size(51, 17);
            this.mapGFXSetL3Num.TabIndex = 61;
            this.mapGFXSetL3Num.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.mapGFXSetL3Num.ValueChanged += new System.EventHandler(this.mapGFXSetL3Num_ValueChanged);
            // 
            // mapGFXSet5Num
            // 
            this.mapGFXSet5Num.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.mapGFXSet5Num.Location = new System.Drawing.Point(75, 91);
            this.mapGFXSet5Num.Maximum = new decimal(new int[] {
            199,
            0,
            0,
            0});
            this.mapGFXSet5Num.Name = "mapGFXSet5Num";
            this.mapGFXSet5Num.Size = new System.Drawing.Size(51, 17);
            this.mapGFXSet5Num.TabIndex = 59;
            this.mapGFXSet5Num.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.mapGFXSet5Num.ValueChanged += new System.EventHandler(this.mapGFXSet5Num_ValueChanged);
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.SystemColors.Window;
            this.panel11.Controls.Add(this.mapGFXSet1Name);
            this.panel11.Location = new System.Drawing.Point(127, 19);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(130, 17);
            this.panel11.TabIndex = 52;
            // 
            // mapGFXSet1Name
            // 
            this.mapGFXSet1Name.DropDownHeight = 200;
            this.mapGFXSet1Name.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mapGFXSet1Name.DropDownWidth = 200;
            this.mapGFXSet1Name.IntegralHeight = false;
            this.mapGFXSet1Name.Location = new System.Drawing.Point(-2, -2);
            this.mapGFXSet1Name.Name = "mapGFXSet1Name";
            this.mapGFXSet1Name.Size = new System.Drawing.Size(133, 21);
            this.mapGFXSet1Name.TabIndex = 118;
            this.mapGFXSet1Name.SelectedIndexChanged += new System.EventHandler(this.mapGFXSet1Name_SelectedIndexChanged);
            // 
            // panel28
            // 
            this.panel28.BackColor = System.Drawing.SystemColors.ControlText;
            this.panel28.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel28.Controls.Add(this.label33);
            this.panel28.Controls.Add(this.mapNum);
            this.panel28.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel28.Location = new System.Drawing.Point(0, 0);
            this.panel28.Name = "panel28";
            this.panel28.Size = new System.Drawing.Size(260, 21);
            this.panel28.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.panel79);
            this.tabPage3.Controls.Add(this.panel4);
            this.tabPage3.Controls.Add(this.panel73);
            this.tabPage3.Controls.Add(this.panel78);
            this.tabPage3.Controls.Add(this.panel74);
            this.tabPage3.Controls.Add(this.panel77);
            this.tabPage3.Controls.Add(this.panel75);
            this.tabPage3.Controls.Add(this.panel76);
            this.tabPage3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(260, 640);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "LAYER";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // panel79
            // 
            this.panel79.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel79.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel79.Controls.Add(this.label110);
            this.panel79.Controls.Add(this.label39);
            this.panel79.Controls.Add(this.label38);
            this.panel79.Controls.Add(this.panel22);
            this.panel79.Controls.Add(this.panel26);
            this.panel79.Controls.Add(this.layerWaveEffect);
            this.panel79.Location = new System.Drawing.Point(0, 556);
            this.panel79.Name = "panel79";
            this.panel79.Size = new System.Drawing.Size(260, 58);
            this.panel79.TabIndex = 449;
            // 
            // label110
            // 
            this.label110.BackColor = System.Drawing.SystemColors.Control;
            this.label110.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label110.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label110.Location = new System.Drawing.Point(0, 0);
            this.label110.Name = "label110";
            this.label110.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label110.Size = new System.Drawing.Size(126, 17);
            this.label110.TabIndex = 122;
            this.label110.Text = "ANIMATION EFFECTS";
            this.label110.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label39
            // 
            this.label39.BackColor = System.Drawing.SystemColors.Control;
            this.label39.Location = new System.Drawing.Point(0, 19);
            this.label39.Name = "label39";
            this.label39.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label39.Size = new System.Drawing.Size(126, 17);
            this.label39.TabIndex = 189;
            this.label39.Text = "L3 Effects";
            // 
            // label38
            // 
            this.label38.BackColor = System.Drawing.SystemColors.Control;
            this.label38.Location = new System.Drawing.Point(0, 37);
            this.label38.Name = "label38";
            this.label38.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label38.Size = new System.Drawing.Size(126, 17);
            this.label38.TabIndex = 190;
            this.label38.Text = "Sprite Effects";
            // 
            // panel22
            // 
            this.panel22.BackColor = System.Drawing.SystemColors.Window;
            this.panel22.Controls.Add(this.layerL3Effects);
            this.panel22.Location = new System.Drawing.Point(127, 19);
            this.panel22.Name = "panel22";
            this.panel22.Size = new System.Drawing.Size(130, 17);
            this.panel22.TabIndex = 48;
            // 
            // layerL3Effects
            // 
            this.layerL3Effects.DropDownHeight = 160;
            this.layerL3Effects.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.layerL3Effects.DropDownWidth = 200;
            this.layerL3Effects.IntegralHeight = false;
            this.layerL3Effects.Items.AddRange(new object[] {
            "(none)",
            "spinning wall decor, outside",
            "glowing ship lanterns",
            "spinning mushrooms",
            "rippling pond water",
            "spinning wall decor, inside",
            "talking organ pipes",
            "burning torches",
            "moving conveyor belts",
            "flowing ground water",
            "rotating flowers",
            "boiling lava",
            "rippling sewer water",
            "???",
            "spinning Moleville decor",
            "flowing river water",
            "glowing stars",
            "still sea water",
            "moving conveyor belts",
            "spinning Nimbus decor",
            "hot springs",
            "Smelter\'s melted metal",
            "Toadofsky\'s singing choir"});
            this.layerL3Effects.Location = new System.Drawing.Point(-2, -2);
            this.layerL3Effects.Name = "layerL3Effects";
            this.layerL3Effects.Size = new System.Drawing.Size(133, 21);
            this.layerL3Effects.TabIndex = 119;
            this.layerL3Effects.SelectedIndexChanged += new System.EventHandler(this.layerL3Effects_SelectedIndexChanged);
            // 
            // panel26
            // 
            this.panel26.BackColor = System.Drawing.SystemColors.Window;
            this.panel26.Controls.Add(this.layerOBJEffects);
            this.panel26.Location = new System.Drawing.Point(127, 37);
            this.panel26.Name = "panel26";
            this.panel26.Size = new System.Drawing.Size(130, 17);
            this.panel26.TabIndex = 49;
            // 
            // layerOBJEffects
            // 
            this.layerOBJEffects.DropDownHeight = 160;
            this.layerOBJEffects.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.layerOBJEffects.DropDownWidth = 200;
            this.layerOBJEffects.IntegralHeight = false;
            this.layerOBJEffects.Items.AddRange(new object[] {
            "{NOTHING}",
            "waterfall",
            "???",
            "glowing save point (NPC #0)",
            "flashing chandelier",
            "glowing save point (NPC #1)",
            "___",
            "glowing save point (NPC #2)",
            "water tunnel",
            "glowing save point (NPC #3)",
            "___",
            "___",
            "___",
            "___",
            "___",
            "___",
            "glowing magma",
            "___",
            "___",
            "___",
            "___",
            "___",
            "___",
            "___",
            "___"});
            this.layerOBJEffects.Location = new System.Drawing.Point(-2, -2);
            this.layerOBJEffects.Name = "layerOBJEffects";
            this.layerOBJEffects.Size = new System.Drawing.Size(133, 21);
            this.layerOBJEffects.TabIndex = 119;
            this.layerOBJEffects.SelectedIndexChanged += new System.EventHandler(this.layerOBJEffects_SelectedIndexChanged);
            // 
            // layerWaveEffect
            // 
            this.layerWaveEffect.Appearance = System.Windows.Forms.Appearance.Button;
            this.layerWaveEffect.BackColor = System.Drawing.SystemColors.Control;
            this.layerWaveEffect.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layerWaveEffect.ForeColor = System.Drawing.Color.Gray;
            this.layerWaveEffect.Location = new System.Drawing.Point(127, 0);
            this.layerWaveEffect.Name = "layerWaveEffect";
            this.layerWaveEffect.Size = new System.Drawing.Size(129, 18);
            this.layerWaveEffect.TabIndex = 47;
            this.layerWaveEffect.Text = "RIPPLING WATER";
            this.layerWaveEffect.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.layerWaveEffect.UseCompatibleTextRendering = true;
            this.layerWaveEffect.UseVisualStyleBackColor = false;
            this.layerWaveEffect.CheckedChanged += new System.EventHandler(this.layerWaveEffect_CheckedChanged);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ControlText;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.label53);
            this.panel4.Controls.Add(this.panel6);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(260, 21);
            this.panel4.TabIndex = 0;
            // 
            // label53
            // 
            this.label53.BackColor = System.Drawing.SystemColors.Control;
            this.label53.Location = new System.Drawing.Point(0, 0);
            this.label53.Name = "label53";
            this.label53.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label53.Size = new System.Drawing.Size(74, 17);
            this.label53.TabIndex = 137;
            this.label53.Text = "Message";
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.SystemColors.Window;
            this.panel6.Controls.Add(this.layerMessageBox);
            this.panel6.Location = new System.Drawing.Point(75, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(181, 17);
            this.panel6.TabIndex = 7;
            // 
            // layerMessageBox
            // 
            this.layerMessageBox.BackColor = System.Drawing.SystemColors.Window;
            this.layerMessageBox.DropDownHeight = 301;
            this.layerMessageBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.layerMessageBox.DropDownWidth = 250;
            this.layerMessageBox.IntegralHeight = false;
            this.layerMessageBox.Location = new System.Drawing.Point(-2, -2);
            this.layerMessageBox.Name = "layerMessageBox";
            this.layerMessageBox.Size = new System.Drawing.Size(185, 21);
            this.layerMessageBox.TabIndex = 119;
            this.layerMessageBox.SelectedIndexChanged += new System.EventHandler(this.layerMessageBox_SelectedIndexChanged);
            // 
            // panel73
            // 
            this.panel73.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel73.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel73.Controls.Add(this.panel86);
            this.panel73.Controls.Add(this.label86);
            this.panel73.Controls.Add(this.label20);
            this.panel73.Controls.Add(this.label21);
            this.panel73.Controls.Add(this.label32);
            this.panel73.Controls.Add(this.layerPrioritySet);
            this.panel73.Controls.Add(this.layerMainscreenL1);
            this.panel73.Controls.Add(this.layerSubscreenL1);
            this.panel73.Controls.Add(this.layerColorMathL1);
            this.panel73.Controls.Add(this.layerMainscreenL2);
            this.panel73.Controls.Add(this.layerSubscreenL2);
            this.panel73.Controls.Add(this.layerColorMathL2);
            this.panel73.Controls.Add(this.layerMainscreenL3);
            this.panel73.Controls.Add(this.layerSubscreenL3);
            this.panel73.Controls.Add(this.layerColorMathL3);
            this.panel73.Controls.Add(this.layerMainscreenNPC);
            this.panel73.Controls.Add(this.layerSubscreenNPC);
            this.panel73.Controls.Add(this.panel17);
            this.panel73.Controls.Add(this.layerColorMathNPC);
            this.panel73.Controls.Add(this.panel14);
            this.panel73.Controls.Add(this.layerColorMathBG);
            this.panel73.Controls.Add(this.label96);
            this.panel73.Controls.Add(this.checkBox15);
            this.panel73.Controls.Add(this.label95);
            this.panel73.Controls.Add(this.checkBox16);
            this.panel73.Controls.Add(this.label22);
            this.panel73.Location = new System.Drawing.Point(0, 23);
            this.panel73.Name = "panel73";
            this.panel73.Size = new System.Drawing.Size(260, 112);
            this.panel73.TabIndex = 444;
            // 
            // panel86
            // 
            this.panel86.BackColor = System.Drawing.SystemColors.Control;
            this.panel86.Location = new System.Drawing.Point(147, 19);
            this.panel86.Name = "panel86";
            this.panel86.Size = new System.Drawing.Size(109, 17);
            this.panel86.TabIndex = 179;
            // 
            // label86
            // 
            this.label86.BackColor = System.Drawing.SystemColors.Control;
            this.label86.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label86.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label86.Location = new System.Drawing.Point(0, 0);
            this.label86.Name = "label86";
            this.label86.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label86.Size = new System.Drawing.Size(258, 17);
            this.label86.TabIndex = 141;
            this.label86.Text = "LAYER PRIORITIES";
            this.label86.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label20
            // 
            this.label20.BackColor = System.Drawing.SystemColors.Control;
            this.label20.Location = new System.Drawing.Point(0, 37);
            this.label20.Name = "label20";
            this.label20.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label20.Size = new System.Drawing.Size(74, 17);
            this.label20.TabIndex = 123;
            this.label20.Text = "Mainscreen";
            // 
            // label21
            // 
            this.label21.BackColor = System.Drawing.SystemColors.Control;
            this.label21.Location = new System.Drawing.Point(0, 55);
            this.label21.Name = "label21";
            this.label21.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label21.Size = new System.Drawing.Size(74, 17);
            this.label21.TabIndex = 138;
            this.label21.Text = "Subscreen";
            // 
            // label32
            // 
            this.label32.BackColor = System.Drawing.SystemColors.Control;
            this.label32.Location = new System.Drawing.Point(0, 19);
            this.label32.Name = "label32";
            this.label32.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label32.Size = new System.Drawing.Size(74, 17);
            this.label32.TabIndex = 137;
            this.label32.Text = "Priority Set";
            // 
            // layerPrioritySet
            // 
            this.layerPrioritySet.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.layerPrioritySet.Location = new System.Drawing.Point(75, 19);
            this.layerPrioritySet.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.layerPrioritySet.Name = "layerPrioritySet";
            this.layerPrioritySet.Size = new System.Drawing.Size(71, 17);
            this.layerPrioritySet.TabIndex = 8;
            this.layerPrioritySet.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.layerPrioritySet.ValueChanged += new System.EventHandler(this.layerPrioritySet_ValueChanged);
            // 
            // layerMainscreenL1
            // 
            this.layerMainscreenL1.Appearance = System.Windows.Forms.Appearance.Button;
            this.layerMainscreenL1.BackColor = System.Drawing.SystemColors.Control;
            this.layerMainscreenL1.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layerMainscreenL1.ForeColor = System.Drawing.Color.Gray;
            this.layerMainscreenL1.Location = new System.Drawing.Point(75, 37);
            this.layerMainscreenL1.Name = "layerMainscreenL1";
            this.layerMainscreenL1.Size = new System.Drawing.Size(36, 18);
            this.layerMainscreenL1.TabIndex = 10;
            this.layerMainscreenL1.Text = "L1";
            this.layerMainscreenL1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.layerMainscreenL1.UseCompatibleTextRendering = true;
            this.layerMainscreenL1.UseVisualStyleBackColor = false;
            this.layerMainscreenL1.CheckedChanged += new System.EventHandler(this.layerMainscreenL1_CheckedChanged);
            // 
            // layerSubscreenL1
            // 
            this.layerSubscreenL1.Appearance = System.Windows.Forms.Appearance.Button;
            this.layerSubscreenL1.BackColor = System.Drawing.SystemColors.Control;
            this.layerSubscreenL1.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layerSubscreenL1.ForeColor = System.Drawing.Color.Gray;
            this.layerSubscreenL1.Location = new System.Drawing.Point(75, 55);
            this.layerSubscreenL1.Name = "layerSubscreenL1";
            this.layerSubscreenL1.Size = new System.Drawing.Size(36, 18);
            this.layerSubscreenL1.TabIndex = 15;
            this.layerSubscreenL1.Text = "L1";
            this.layerSubscreenL1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.layerSubscreenL1.UseCompatibleTextRendering = true;
            this.layerSubscreenL1.UseVisualStyleBackColor = false;
            this.layerSubscreenL1.CheckedChanged += new System.EventHandler(this.layerSubscreenL1_CheckedChanged);
            // 
            // layerColorMathL1
            // 
            this.layerColorMathL1.Appearance = System.Windows.Forms.Appearance.Button;
            this.layerColorMathL1.BackColor = System.Drawing.SystemColors.Control;
            this.layerColorMathL1.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layerColorMathL1.ForeColor = System.Drawing.Color.Gray;
            this.layerColorMathL1.Location = new System.Drawing.Point(75, 73);
            this.layerColorMathL1.Name = "layerColorMathL1";
            this.layerColorMathL1.Size = new System.Drawing.Size(36, 18);
            this.layerColorMathL1.TabIndex = 20;
            this.layerColorMathL1.Text = "L1";
            this.layerColorMathL1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.layerColorMathL1.UseCompatibleTextRendering = true;
            this.layerColorMathL1.UseVisualStyleBackColor = false;
            this.layerColorMathL1.CheckedChanged += new System.EventHandler(this.layerColorMathL1_CheckedChanged);
            // 
            // layerMainscreenL2
            // 
            this.layerMainscreenL2.Appearance = System.Windows.Forms.Appearance.Button;
            this.layerMainscreenL2.BackColor = System.Drawing.SystemColors.Control;
            this.layerMainscreenL2.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layerMainscreenL2.ForeColor = System.Drawing.Color.Gray;
            this.layerMainscreenL2.Location = new System.Drawing.Point(111, 37);
            this.layerMainscreenL2.Name = "layerMainscreenL2";
            this.layerMainscreenL2.Size = new System.Drawing.Size(36, 18);
            this.layerMainscreenL2.TabIndex = 11;
            this.layerMainscreenL2.Text = "L2";
            this.layerMainscreenL2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.layerMainscreenL2.UseCompatibleTextRendering = true;
            this.layerMainscreenL2.UseVisualStyleBackColor = false;
            this.layerMainscreenL2.CheckedChanged += new System.EventHandler(this.layerMainscreenL2_CheckedChanged);
            // 
            // layerSubscreenL2
            // 
            this.layerSubscreenL2.Appearance = System.Windows.Forms.Appearance.Button;
            this.layerSubscreenL2.BackColor = System.Drawing.SystemColors.Control;
            this.layerSubscreenL2.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layerSubscreenL2.ForeColor = System.Drawing.Color.Gray;
            this.layerSubscreenL2.Location = new System.Drawing.Point(111, 55);
            this.layerSubscreenL2.Name = "layerSubscreenL2";
            this.layerSubscreenL2.Size = new System.Drawing.Size(36, 18);
            this.layerSubscreenL2.TabIndex = 16;
            this.layerSubscreenL2.Text = "L2";
            this.layerSubscreenL2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.layerSubscreenL2.UseCompatibleTextRendering = true;
            this.layerSubscreenL2.UseVisualStyleBackColor = false;
            this.layerSubscreenL2.CheckedChanged += new System.EventHandler(this.layerSubscreenL2_CheckedChanged);
            // 
            // layerColorMathL2
            // 
            this.layerColorMathL2.Appearance = System.Windows.Forms.Appearance.Button;
            this.layerColorMathL2.BackColor = System.Drawing.SystemColors.Control;
            this.layerColorMathL2.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layerColorMathL2.ForeColor = System.Drawing.Color.Gray;
            this.layerColorMathL2.Location = new System.Drawing.Point(111, 73);
            this.layerColorMathL2.Name = "layerColorMathL2";
            this.layerColorMathL2.Size = new System.Drawing.Size(36, 18);
            this.layerColorMathL2.TabIndex = 21;
            this.layerColorMathL2.Text = "L2";
            this.layerColorMathL2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.layerColorMathL2.UseCompatibleTextRendering = true;
            this.layerColorMathL2.UseVisualStyleBackColor = false;
            this.layerColorMathL2.CheckedChanged += new System.EventHandler(this.layerColorMathL2_CheckedChanged);
            // 
            // layerMainscreenL3
            // 
            this.layerMainscreenL3.Appearance = System.Windows.Forms.Appearance.Button;
            this.layerMainscreenL3.BackColor = System.Drawing.SystemColors.Control;
            this.layerMainscreenL3.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layerMainscreenL3.ForeColor = System.Drawing.Color.Gray;
            this.layerMainscreenL3.Location = new System.Drawing.Point(147, 37);
            this.layerMainscreenL3.Name = "layerMainscreenL3";
            this.layerMainscreenL3.Size = new System.Drawing.Size(36, 18);
            this.layerMainscreenL3.TabIndex = 12;
            this.layerMainscreenL3.Text = "L3";
            this.layerMainscreenL3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.layerMainscreenL3.UseCompatibleTextRendering = true;
            this.layerMainscreenL3.UseVisualStyleBackColor = false;
            this.layerMainscreenL3.CheckedChanged += new System.EventHandler(this.layerMainscreenL3_CheckedChanged);
            // 
            // layerSubscreenL3
            // 
            this.layerSubscreenL3.Appearance = System.Windows.Forms.Appearance.Button;
            this.layerSubscreenL3.BackColor = System.Drawing.SystemColors.Control;
            this.layerSubscreenL3.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layerSubscreenL3.ForeColor = System.Drawing.Color.Gray;
            this.layerSubscreenL3.Location = new System.Drawing.Point(147, 55);
            this.layerSubscreenL3.Name = "layerSubscreenL3";
            this.layerSubscreenL3.Size = new System.Drawing.Size(36, 18);
            this.layerSubscreenL3.TabIndex = 17;
            this.layerSubscreenL3.Text = "L3";
            this.layerSubscreenL3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.layerSubscreenL3.UseCompatibleTextRendering = true;
            this.layerSubscreenL3.UseVisualStyleBackColor = false;
            this.layerSubscreenL3.CheckedChanged += new System.EventHandler(this.layerSubscreenL3_CheckedChanged);
            // 
            // layerColorMathL3
            // 
            this.layerColorMathL3.Appearance = System.Windows.Forms.Appearance.Button;
            this.layerColorMathL3.BackColor = System.Drawing.SystemColors.Control;
            this.layerColorMathL3.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layerColorMathL3.ForeColor = System.Drawing.Color.Gray;
            this.layerColorMathL3.Location = new System.Drawing.Point(147, 73);
            this.layerColorMathL3.Name = "layerColorMathL3";
            this.layerColorMathL3.Size = new System.Drawing.Size(36, 18);
            this.layerColorMathL3.TabIndex = 22;
            this.layerColorMathL3.Text = "L3";
            this.layerColorMathL3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.layerColorMathL3.UseCompatibleTextRendering = true;
            this.layerColorMathL3.UseVisualStyleBackColor = false;
            this.layerColorMathL3.CheckedChanged += new System.EventHandler(this.layerColorMathL3_CheckedChanged);
            // 
            // layerMainscreenNPC
            // 
            this.layerMainscreenNPC.Appearance = System.Windows.Forms.Appearance.Button;
            this.layerMainscreenNPC.BackColor = System.Drawing.SystemColors.Control;
            this.layerMainscreenNPC.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layerMainscreenNPC.ForeColor = System.Drawing.Color.Gray;
            this.layerMainscreenNPC.Location = new System.Drawing.Point(183, 37);
            this.layerMainscreenNPC.Name = "layerMainscreenNPC";
            this.layerMainscreenNPC.Size = new System.Drawing.Size(38, 18);
            this.layerMainscreenNPC.TabIndex = 13;
            this.layerMainscreenNPC.Text = "NPC";
            this.layerMainscreenNPC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.layerMainscreenNPC.UseCompatibleTextRendering = true;
            this.layerMainscreenNPC.UseVisualStyleBackColor = false;
            this.layerMainscreenNPC.CheckedChanged += new System.EventHandler(this.layerMainscreenNPC_CheckedChanged);
            // 
            // layerSubscreenNPC
            // 
            this.layerSubscreenNPC.Appearance = System.Windows.Forms.Appearance.Button;
            this.layerSubscreenNPC.BackColor = System.Drawing.SystemColors.Control;
            this.layerSubscreenNPC.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layerSubscreenNPC.ForeColor = System.Drawing.Color.Gray;
            this.layerSubscreenNPC.Location = new System.Drawing.Point(183, 55);
            this.layerSubscreenNPC.Name = "layerSubscreenNPC";
            this.layerSubscreenNPC.Size = new System.Drawing.Size(38, 18);
            this.layerSubscreenNPC.TabIndex = 18;
            this.layerSubscreenNPC.Text = "NPC";
            this.layerSubscreenNPC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.layerSubscreenNPC.UseCompatibleTextRendering = true;
            this.layerSubscreenNPC.UseVisualStyleBackColor = false;
            this.layerSubscreenNPC.CheckedChanged += new System.EventHandler(this.layerSubscreenNPC_CheckedChanged);
            // 
            // panel17
            // 
            this.panel17.BackColor = System.Drawing.SystemColors.Window;
            this.panel17.Controls.Add(this.layerColorMathMode);
            this.panel17.Location = new System.Drawing.Point(189, 91);
            this.panel17.Name = "panel17";
            this.panel17.Size = new System.Drawing.Size(67, 17);
            this.panel17.TabIndex = 26;
            // 
            // layerColorMathMode
            // 
            this.layerColorMathMode.BackColor = System.Drawing.SystemColors.Window;
            this.layerColorMathMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.layerColorMathMode.Items.AddRange(new object[] {
            "Plus",
            "Minus"});
            this.layerColorMathMode.Location = new System.Drawing.Point(-1, -2);
            this.layerColorMathMode.Name = "layerColorMathMode";
            this.layerColorMathMode.Size = new System.Drawing.Size(70, 21);
            this.layerColorMathMode.TabIndex = 119;
            this.layerColorMathMode.SelectedIndexChanged += new System.EventHandler(this.layerColorMathMode_SelectedIndexChanged);
            // 
            // layerColorMathNPC
            // 
            this.layerColorMathNPC.Appearance = System.Windows.Forms.Appearance.Button;
            this.layerColorMathNPC.BackColor = System.Drawing.SystemColors.Control;
            this.layerColorMathNPC.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layerColorMathNPC.ForeColor = System.Drawing.Color.Gray;
            this.layerColorMathNPC.Location = new System.Drawing.Point(183, 73);
            this.layerColorMathNPC.Name = "layerColorMathNPC";
            this.layerColorMathNPC.Size = new System.Drawing.Size(38, 18);
            this.layerColorMathNPC.TabIndex = 23;
            this.layerColorMathNPC.Text = "NPC";
            this.layerColorMathNPC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.layerColorMathNPC.UseCompatibleTextRendering = true;
            this.layerColorMathNPC.UseVisualStyleBackColor = false;
            this.layerColorMathNPC.CheckedChanged += new System.EventHandler(this.layerColorMathNPC_CheckedChanged);
            // 
            // panel14
            // 
            this.panel14.BackColor = System.Drawing.SystemColors.Window;
            this.panel14.Controls.Add(this.layerColorMathIntensity);
            this.panel14.Location = new System.Drawing.Point(75, 91);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(62, 17);
            this.panel14.TabIndex = 25;
            // 
            // layerColorMathIntensity
            // 
            this.layerColorMathIntensity.BackColor = System.Drawing.SystemColors.Window;
            this.layerColorMathIntensity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.layerColorMathIntensity.Items.AddRange(new object[] {
            "Full",
            "Half"});
            this.layerColorMathIntensity.Location = new System.Drawing.Point(-2, -2);
            this.layerColorMathIntensity.Name = "layerColorMathIntensity";
            this.layerColorMathIntensity.Size = new System.Drawing.Size(66, 21);
            this.layerColorMathIntensity.TabIndex = 119;
            this.layerColorMathIntensity.SelectedIndexChanged += new System.EventHandler(this.layerColorMathIntensity_SelectedIndexChanged);
            // 
            // layerColorMathBG
            // 
            this.layerColorMathBG.Appearance = System.Windows.Forms.Appearance.Button;
            this.layerColorMathBG.BackColor = System.Drawing.SystemColors.Control;
            this.layerColorMathBG.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layerColorMathBG.ForeColor = System.Drawing.Color.Gray;
            this.layerColorMathBG.Location = new System.Drawing.Point(221, 73);
            this.layerColorMathBG.Name = "layerColorMathBG";
            this.layerColorMathBG.Size = new System.Drawing.Size(36, 18);
            this.layerColorMathBG.TabIndex = 24;
            this.layerColorMathBG.Text = "BG";
            this.layerColorMathBG.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.layerColorMathBG.UseCompatibleTextRendering = true;
            this.layerColorMathBG.UseVisualStyleBackColor = false;
            this.layerColorMathBG.CheckedChanged += new System.EventHandler(this.layerColorMathBG_CheckedChanged);
            // 
            // label96
            // 
            this.label96.BackColor = System.Drawing.SystemColors.Control;
            this.label96.Location = new System.Drawing.Point(138, 91);
            this.label96.Name = "label96";
            this.label96.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label96.Size = new System.Drawing.Size(51, 17);
            this.label96.TabIndex = 177;
            this.label96.Text = "Mode";
            // 
            // checkBox15
            // 
            this.checkBox15.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox15.BackColor = System.Drawing.SystemColors.Control;
            this.checkBox15.Enabled = false;
            this.checkBox15.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox15.ForeColor = System.Drawing.Color.Gray;
            this.checkBox15.Location = new System.Drawing.Point(221, 55);
            this.checkBox15.Name = "checkBox15";
            this.checkBox15.Size = new System.Drawing.Size(36, 18);
            this.checkBox15.TabIndex = 19;
            this.checkBox15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBox15.UseCompatibleTextRendering = true;
            this.checkBox15.UseVisualStyleBackColor = false;
            // 
            // label95
            // 
            this.label95.BackColor = System.Drawing.SystemColors.Control;
            this.label95.Location = new System.Drawing.Point(0, 91);
            this.label95.Name = "label95";
            this.label95.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label95.Size = new System.Drawing.Size(74, 17);
            this.label95.TabIndex = 178;
            this.label95.Text = "Intensity";
            // 
            // checkBox16
            // 
            this.checkBox16.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox16.BackColor = System.Drawing.SystemColors.Control;
            this.checkBox16.Enabled = false;
            this.checkBox16.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox16.ForeColor = System.Drawing.Color.Gray;
            this.checkBox16.Location = new System.Drawing.Point(221, 37);
            this.checkBox16.Name = "checkBox16";
            this.checkBox16.Size = new System.Drawing.Size(36, 18);
            this.checkBox16.TabIndex = 14;
            this.checkBox16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBox16.UseCompatibleTextRendering = true;
            this.checkBox16.UseVisualStyleBackColor = false;
            // 
            // label22
            // 
            this.label22.BackColor = System.Drawing.SystemColors.Control;
            this.label22.Location = new System.Drawing.Point(0, 73);
            this.label22.Name = "label22";
            this.label22.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label22.Size = new System.Drawing.Size(74, 17);
            this.label22.TabIndex = 176;
            this.label22.Text = "Color Math";
            // 
            // panel78
            // 
            this.panel78.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel78.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel78.Controls.Add(this.label7);
            this.panel78.Controls.Add(this.label85);
            this.panel78.Controls.Add(this.label84);
            this.panel78.Controls.Add(this.label83);
            this.panel78.Controls.Add(this.label82);
            this.panel78.Controls.Add(this.panel21);
            this.panel78.Controls.Add(this.panel23);
            this.panel78.Controls.Add(this.panel24);
            this.panel78.Controls.Add(this.layerInfiniteAutoscroll);
            this.panel78.Controls.Add(this.panel25);
            this.panel78.Controls.Add(this.layerL2ScrollShift);
            this.panel78.Controls.Add(this.layerL3ScrollShift);
            this.panel78.Location = new System.Drawing.Point(0, 442);
            this.panel78.Name = "panel78";
            this.panel78.Size = new System.Drawing.Size(260, 112);
            this.panel78.TabIndex = 448;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.SystemColors.Control;
            this.label7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label7.Location = new System.Drawing.Point(0, 0);
            this.label7.Name = "label7";
            this.label7.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label7.Size = new System.Drawing.Size(126, 17);
            this.label7.TabIndex = 108;
            this.label7.Text = "AUTOSCROLLING";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label85
            // 
            this.label85.BackColor = System.Drawing.SystemColors.Control;
            this.label85.Location = new System.Drawing.Point(0, 37);
            this.label85.Name = "label85";
            this.label85.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label85.Size = new System.Drawing.Size(126, 17);
            this.label85.TabIndex = 76;
            this.label85.Text = "L2 Scroll Direction";
            // 
            // label84
            // 
            this.label84.BackColor = System.Drawing.SystemColors.Control;
            this.label84.Location = new System.Drawing.Point(0, 55);
            this.label84.Name = "label84";
            this.label84.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label84.Size = new System.Drawing.Size(126, 17);
            this.label84.TabIndex = 78;
            this.label84.Text = "L2 Scroll Speed";
            // 
            // label83
            // 
            this.label83.BackColor = System.Drawing.SystemColors.Control;
            this.label83.Location = new System.Drawing.Point(0, 73);
            this.label83.Name = "label83";
            this.label83.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label83.Size = new System.Drawing.Size(126, 17);
            this.label83.TabIndex = 79;
            this.label83.Text = "L3 Scroll Direction";
            // 
            // label82
            // 
            this.label82.BackColor = System.Drawing.SystemColors.Control;
            this.label82.Location = new System.Drawing.Point(0, 91);
            this.label82.Name = "label82";
            this.label82.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label82.Size = new System.Drawing.Size(126, 17);
            this.label82.TabIndex = 81;
            this.label82.Text = "L3 Scroll Speed";
            // 
            // panel21
            // 
            this.panel21.BackColor = System.Drawing.SystemColors.Window;
            this.panel21.Controls.Add(this.layerL2ScrollDirection);
            this.panel21.Location = new System.Drawing.Point(127, 37);
            this.panel21.Name = "panel21";
            this.panel21.Size = new System.Drawing.Size(130, 17);
            this.panel21.TabIndex = 43;
            // 
            // layerL2ScrollDirection
            // 
            this.layerL2ScrollDirection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.layerL2ScrollDirection.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.layerL2ScrollDirection.Items.AddRange(new object[] {
            "Left",
            "Up-Left",
            "Up",
            "Up-Right",
            "Right",
            "Down-Right",
            "Down",
            "Down-Left"});
            this.layerL2ScrollDirection.Location = new System.Drawing.Point(-2, -2);
            this.layerL2ScrollDirection.Name = "layerL2ScrollDirection";
            this.layerL2ScrollDirection.Size = new System.Drawing.Size(133, 21);
            this.layerL2ScrollDirection.TabIndex = 64;
            this.layerL2ScrollDirection.SelectedIndexChanged += new System.EventHandler(this.layerL2ScrollDirection_SelectedIndexChanged);
            // 
            // panel23
            // 
            this.panel23.BackColor = System.Drawing.SystemColors.Window;
            this.panel23.Controls.Add(this.layerL2ScrollSpeed);
            this.panel23.Location = new System.Drawing.Point(127, 55);
            this.panel23.Name = "panel23";
            this.panel23.Size = new System.Drawing.Size(130, 17);
            this.panel23.TabIndex = 44;
            // 
            // layerL2ScrollSpeed
            // 
            this.layerL2ScrollSpeed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.layerL2ScrollSpeed.Items.AddRange(new object[] {
            "(none)",
            "Very Slow",
            "Slow",
            "Medium Slow",
            "Medium Fast",
            "Fast",
            "Very Fast"});
            this.layerL2ScrollSpeed.Location = new System.Drawing.Point(-2, -2);
            this.layerL2ScrollSpeed.Name = "layerL2ScrollSpeed";
            this.layerL2ScrollSpeed.Size = new System.Drawing.Size(133, 21);
            this.layerL2ScrollSpeed.TabIndex = 64;
            this.layerL2ScrollSpeed.SelectedIndexChanged += new System.EventHandler(this.layerL2ScrollSpeed_SelectedIndexChanged);
            // 
            // panel24
            // 
            this.panel24.BackColor = System.Drawing.SystemColors.Window;
            this.panel24.Controls.Add(this.layerL3ScrollDirection);
            this.panel24.Location = new System.Drawing.Point(127, 73);
            this.panel24.Name = "panel24";
            this.panel24.Size = new System.Drawing.Size(130, 17);
            this.panel24.TabIndex = 45;
            // 
            // layerL3ScrollDirection
            // 
            this.layerL3ScrollDirection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.layerL3ScrollDirection.Items.AddRange(new object[] {
            "Left",
            "Up-Left",
            "Up",
            "Up-Right",
            "Right",
            "Down-Right",
            "Down",
            "Down-Left"});
            this.layerL3ScrollDirection.Location = new System.Drawing.Point(-2, -2);
            this.layerL3ScrollDirection.Name = "layerL3ScrollDirection";
            this.layerL3ScrollDirection.Size = new System.Drawing.Size(133, 21);
            this.layerL3ScrollDirection.TabIndex = 64;
            this.layerL3ScrollDirection.SelectedIndexChanged += new System.EventHandler(this.layerL3ScrollDirection_SelectedIndexChanged);
            // 
            // layerInfiniteAutoscroll
            // 
            this.layerInfiniteAutoscroll.Appearance = System.Windows.Forms.Appearance.Button;
            this.layerInfiniteAutoscroll.BackColor = System.Drawing.SystemColors.Control;
            this.layerInfiniteAutoscroll.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layerInfiniteAutoscroll.ForeColor = System.Drawing.Color.Gray;
            this.layerInfiniteAutoscroll.Location = new System.Drawing.Point(127, 0);
            this.layerInfiniteAutoscroll.Name = "layerInfiniteAutoscroll";
            this.layerInfiniteAutoscroll.Size = new System.Drawing.Size(129, 18);
            this.layerInfiniteAutoscroll.TabIndex = 40;
            this.layerInfiniteAutoscroll.Text = "INFINITE";
            this.layerInfiniteAutoscroll.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.layerInfiniteAutoscroll.UseCompatibleTextRendering = true;
            this.layerInfiniteAutoscroll.UseVisualStyleBackColor = false;
            this.layerInfiniteAutoscroll.CheckedChanged += new System.EventHandler(this.layerInfiniteAutoscroll_CheckedChanged);
            // 
            // panel25
            // 
            this.panel25.BackColor = System.Drawing.SystemColors.Window;
            this.panel25.Controls.Add(this.layerL3ScrollSpeed);
            this.panel25.Location = new System.Drawing.Point(127, 91);
            this.panel25.Name = "panel25";
            this.panel25.Size = new System.Drawing.Size(130, 17);
            this.panel25.TabIndex = 46;
            // 
            // layerL3ScrollSpeed
            // 
            this.layerL3ScrollSpeed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.layerL3ScrollSpeed.Items.AddRange(new object[] {
            "(none)",
            "Very Slow",
            "Slow",
            "Medium Slow",
            "Medium Fast",
            "Fast",
            "Very Fast"});
            this.layerL3ScrollSpeed.Location = new System.Drawing.Point(-2, -2);
            this.layerL3ScrollSpeed.Name = "layerL3ScrollSpeed";
            this.layerL3ScrollSpeed.Size = new System.Drawing.Size(133, 21);
            this.layerL3ScrollSpeed.TabIndex = 64;
            this.layerL3ScrollSpeed.SelectedIndexChanged += new System.EventHandler(this.layerL3ScrollSpeed_SelectedIndexChanged);
            // 
            // layerL2ScrollShift
            // 
            this.layerL2ScrollShift.Appearance = System.Windows.Forms.Appearance.Button;
            this.layerL2ScrollShift.BackColor = System.Drawing.SystemColors.Control;
            this.layerL2ScrollShift.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layerL2ScrollShift.ForeColor = System.Drawing.Color.Gray;
            this.layerL2ScrollShift.Location = new System.Drawing.Point(0, 19);
            this.layerL2ScrollShift.Name = "layerL2ScrollShift";
            this.layerL2ScrollShift.Size = new System.Drawing.Size(127, 18);
            this.layerL2ScrollShift.TabIndex = 41;
            this.layerL2ScrollShift.Text = "L2 SCROLL SHIFT";
            this.layerL2ScrollShift.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.layerL2ScrollShift.UseCompatibleTextRendering = true;
            this.layerL2ScrollShift.UseVisualStyleBackColor = false;
            this.layerL2ScrollShift.CheckedChanged += new System.EventHandler(this.layerL2ScrollShift_CheckedChanged);
            // 
            // layerL3ScrollShift
            // 
            this.layerL3ScrollShift.Appearance = System.Windows.Forms.Appearance.Button;
            this.layerL3ScrollShift.BackColor = System.Drawing.SystemColors.Control;
            this.layerL3ScrollShift.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layerL3ScrollShift.ForeColor = System.Drawing.Color.Gray;
            this.layerL3ScrollShift.Location = new System.Drawing.Point(127, 19);
            this.layerL3ScrollShift.Name = "layerL3ScrollShift";
            this.layerL3ScrollShift.Size = new System.Drawing.Size(129, 18);
            this.layerL3ScrollShift.TabIndex = 42;
            this.layerL3ScrollShift.Text = "L3 SCROLL SHIFT";
            this.layerL3ScrollShift.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.layerL3ScrollShift.UseCompatibleTextRendering = true;
            this.layerL3ScrollShift.UseVisualStyleBackColor = false;
            this.layerL3ScrollShift.CheckedChanged += new System.EventHandler(this.layerL3ScrollShift_CheckedChanged);
            // 
            // panel74
            // 
            this.panel74.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel74.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel74.Controls.Add(this.label4);
            this.panel74.Controls.Add(this.layerMaskHighX);
            this.panel74.Controls.Add(this.layerLockMask);
            this.panel74.Controls.Add(this.layerMaskLowX);
            this.panel74.Controls.Add(this.label25);
            this.panel74.Controls.Add(this.layerMaskHighY);
            this.panel74.Controls.Add(this.label24);
            this.panel74.Controls.Add(this.layerMaskLowY);
            this.panel74.Controls.Add(this.label15);
            this.panel74.Controls.Add(this.labeasdfasd);
            this.panel74.Location = new System.Drawing.Point(0, 137);
            this.panel74.Name = "panel74";
            this.panel74.Size = new System.Drawing.Size(260, 58);
            this.panel74.TabIndex = 444;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.Control;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label4.Size = new System.Drawing.Size(129, 17);
            this.label4.TabIndex = 84;
            this.label4.Text = "LAYER MASK";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // layerMaskHighX
            // 
            this.layerMaskHighX.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.layerMaskHighX.Location = new System.Drawing.Point(75, 19);
            this.layerMaskHighX.Maximum = new decimal(new int[] {
            63,
            0,
            0,
            0});
            this.layerMaskHighX.Name = "layerMaskHighX";
            this.layerMaskHighX.Size = new System.Drawing.Size(54, 17);
            this.layerMaskHighX.TabIndex = 27;
            this.layerMaskHighX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.layerMaskHighX.ValueChanged += new System.EventHandler(this.layerMaskHighX_ValueChanged);
            // 
            // layerLockMask
            // 
            this.layerLockMask.Appearance = System.Windows.Forms.Appearance.Button;
            this.layerLockMask.BackColor = System.Drawing.SystemColors.Control;
            this.layerLockMask.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layerLockMask.ForeColor = System.Drawing.Color.Gray;
            this.layerLockMask.Location = new System.Drawing.Point(130, 0);
            this.layerLockMask.Name = "layerLockMask";
            this.layerLockMask.Size = new System.Drawing.Size(126, 19);
            this.layerLockMask.TabIndex = 26;
            this.layerLockMask.Text = "LOCK SCROLLING";
            this.layerLockMask.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.layerLockMask.UseCompatibleTextRendering = true;
            this.layerLockMask.UseVisualStyleBackColor = false;
            this.layerLockMask.CheckedChanged += new System.EventHandler(this.layerLockMask_CheckedChanged);
            // 
            // layerMaskLowX
            // 
            this.layerMaskLowX.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.layerMaskLowX.Location = new System.Drawing.Point(75, 37);
            this.layerMaskLowX.Maximum = new decimal(new int[] {
            63,
            0,
            0,
            0});
            this.layerMaskLowX.Name = "layerMaskLowX";
            this.layerMaskLowX.Size = new System.Drawing.Size(54, 17);
            this.layerMaskLowX.TabIndex = 29;
            this.layerMaskLowX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.layerMaskLowX.ValueChanged += new System.EventHandler(this.layerMaskLowX_ValueChanged);
            // 
            // label25
            // 
            this.label25.BackColor = System.Drawing.SystemColors.Control;
            this.label25.Location = new System.Drawing.Point(0, 19);
            this.label25.Name = "label25";
            this.label25.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label25.Size = new System.Drawing.Size(74, 17);
            this.label25.TabIndex = 96;
            this.label25.Text = "Right Edge";
            // 
            // layerMaskHighY
            // 
            this.layerMaskHighY.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.layerMaskHighY.Location = new System.Drawing.Point(205, 19);
            this.layerMaskHighY.Maximum = new decimal(new int[] {
            63,
            0,
            0,
            0});
            this.layerMaskHighY.Name = "layerMaskHighY";
            this.layerMaskHighY.Size = new System.Drawing.Size(51, 17);
            this.layerMaskHighY.TabIndex = 28;
            this.layerMaskHighY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.layerMaskHighY.ValueChanged += new System.EventHandler(this.layerMaskHighY_ValueChanged);
            // 
            // label24
            // 
            this.label24.BackColor = System.Drawing.SystemColors.Control;
            this.label24.Location = new System.Drawing.Point(0, 37);
            this.label24.Name = "label24";
            this.label24.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label24.Size = new System.Drawing.Size(74, 17);
            this.label24.TabIndex = 98;
            this.label24.Text = "Left Edge";
            // 
            // layerMaskLowY
            // 
            this.layerMaskLowY.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.layerMaskLowY.Location = new System.Drawing.Point(205, 37);
            this.layerMaskLowY.Maximum = new decimal(new int[] {
            63,
            0,
            0,
            0});
            this.layerMaskLowY.Name = "layerMaskLowY";
            this.layerMaskLowY.Size = new System.Drawing.Size(51, 17);
            this.layerMaskLowY.TabIndex = 30;
            this.layerMaskLowY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.layerMaskLowY.ValueChanged += new System.EventHandler(this.layerMaskLowY_ValueChanged);
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.SystemColors.Control;
            this.label15.Location = new System.Drawing.Point(130, 19);
            this.label15.Name = "label15";
            this.label15.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label15.Size = new System.Drawing.Size(74, 17);
            this.label15.TabIndex = 100;
            this.label15.Text = "Bottom Edge";
            // 
            // labeasdfasd
            // 
            this.labeasdfasd.BackColor = System.Drawing.SystemColors.Control;
            this.labeasdfasd.Location = new System.Drawing.Point(130, 37);
            this.labeasdfasd.Name = "labeasdfasd";
            this.labeasdfasd.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.labeasdfasd.Size = new System.Drawing.Size(74, 17);
            this.labeasdfasd.TabIndex = 103;
            this.labeasdfasd.Text = "Top Edge";
            // 
            // panel77
            // 
            this.panel77.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel77.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel77.Controls.Add(this.label6);
            this.panel77.Controls.Add(this.label12);
            this.panel77.Controls.Add(this.label13);
            this.panel77.Controls.Add(this.label11);
            this.panel77.Controls.Add(this.label3);
            this.panel77.Controls.Add(this.panel16);
            this.panel77.Controls.Add(this.panel19);
            this.panel77.Controls.Add(this.panel18);
            this.panel77.Controls.Add(this.panel20);
            this.panel77.Location = new System.Drawing.Point(0, 346);
            this.panel77.Name = "panel77";
            this.panel77.Size = new System.Drawing.Size(260, 94);
            this.panel77.TabIndex = 447;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.SystemColors.Control;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Name = "label6";
            this.label6.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label6.Size = new System.Drawing.Size(256, 17);
            this.label6.TabIndex = 106;
            this.label6.Text = "LAYER SCROLLING SYNCHRONIZATION";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.SystemColors.Control;
            this.label12.Location = new System.Drawing.Point(0, 19);
            this.label12.Name = "label12";
            this.label12.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label12.Size = new System.Drawing.Size(126, 17);
            this.label12.TabIndex = 181;
            this.label12.Text = "L2 Vertical Sync";
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.SystemColors.Control;
            this.label13.Location = new System.Drawing.Point(0, 37);
            this.label13.Name = "label13";
            this.label13.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label13.Size = new System.Drawing.Size(126, 17);
            this.label13.TabIndex = 182;
            this.label13.Text = "L2 Horizontal Sync";
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.SystemColors.Control;
            this.label11.Location = new System.Drawing.Point(0, 55);
            this.label11.Name = "label11";
            this.label11.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label11.Size = new System.Drawing.Size(126, 17);
            this.label11.TabIndex = 183;
            this.label11.Text = "L3 Vertical Sync";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(0, 73);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label3.Size = new System.Drawing.Size(126, 17);
            this.label3.TabIndex = 184;
            this.label3.Text = "L3 Horizontal Sync";
            // 
            // panel16
            // 
            this.panel16.BackColor = System.Drawing.SystemColors.Window;
            this.panel16.Controls.Add(this.layerL2VSync);
            this.panel16.Location = new System.Drawing.Point(127, 19);
            this.panel16.Name = "panel16";
            this.panel16.Size = new System.Drawing.Size(129, 17);
            this.panel16.TabIndex = 36;
            // 
            // layerL2VSync
            // 
            this.layerL2VSync.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.layerL2VSync.Items.AddRange(new object[] {
            "None",
            "Low",
            "Normal",
            "High"});
            this.layerL2VSync.Location = new System.Drawing.Point(-2, -2);
            this.layerL2VSync.Name = "layerL2VSync";
            this.layerL2VSync.Size = new System.Drawing.Size(133, 21);
            this.layerL2VSync.TabIndex = 64;
            this.layerL2VSync.SelectedIndexChanged += new System.EventHandler(this.layerL2VSync_SelectedIndexChanged);
            // 
            // panel19
            // 
            this.panel19.BackColor = System.Drawing.SystemColors.Window;
            this.panel19.Controls.Add(this.layerL3VSync);
            this.panel19.Location = new System.Drawing.Point(127, 55);
            this.panel19.Name = "panel19";
            this.panel19.Size = new System.Drawing.Size(129, 17);
            this.panel19.TabIndex = 38;
            // 
            // layerL3VSync
            // 
            this.layerL3VSync.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.layerL3VSync.Items.AddRange(new object[] {
            "None",
            "Low",
            "Normal",
            "High"});
            this.layerL3VSync.Location = new System.Drawing.Point(-2, -2);
            this.layerL3VSync.Name = "layerL3VSync";
            this.layerL3VSync.Size = new System.Drawing.Size(133, 21);
            this.layerL3VSync.TabIndex = 64;
            this.layerL3VSync.SelectedIndexChanged += new System.EventHandler(this.layerL3VSync_SelectedIndexChanged);
            // 
            // panel18
            // 
            this.panel18.BackColor = System.Drawing.SystemColors.Window;
            this.panel18.Controls.Add(this.layerL2HSync);
            this.panel18.Location = new System.Drawing.Point(127, 37);
            this.panel18.Name = "panel18";
            this.panel18.Size = new System.Drawing.Size(129, 17);
            this.panel18.TabIndex = 37;
            // 
            // layerL2HSync
            // 
            this.layerL2HSync.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.layerL2HSync.Items.AddRange(new object[] {
            "None",
            "Low",
            "Normal",
            "High"});
            this.layerL2HSync.Location = new System.Drawing.Point(-2, -2);
            this.layerL2HSync.Name = "layerL2HSync";
            this.layerL2HSync.Size = new System.Drawing.Size(133, 21);
            this.layerL2HSync.TabIndex = 64;
            this.layerL2HSync.SelectedIndexChanged += new System.EventHandler(this.layerL2HSync_SelectedIndexChanged);
            // 
            // panel20
            // 
            this.panel20.BackColor = System.Drawing.SystemColors.Window;
            this.panel20.Controls.Add(this.layerL3HSync);
            this.panel20.Location = new System.Drawing.Point(127, 73);
            this.panel20.Name = "panel20";
            this.panel20.Size = new System.Drawing.Size(129, 17);
            this.panel20.TabIndex = 39;
            // 
            // layerL3HSync
            // 
            this.layerL3HSync.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.layerL3HSync.Items.AddRange(new object[] {
            "None",
            "Low",
            "Normal",
            "High"});
            this.layerL3HSync.Location = new System.Drawing.Point(-2, -2);
            this.layerL3HSync.Name = "layerL3HSync";
            this.layerL3HSync.Size = new System.Drawing.Size(133, 21);
            this.layerL3HSync.TabIndex = 64;
            this.layerL3HSync.SelectedIndexChanged += new System.EventHandler(this.layerL3HSync_SelectedIndexChanged);
            // 
            // panel75
            // 
            this.panel75.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel75.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel75.Controls.Add(this.label5);
            this.panel75.Controls.Add(this.layerL2LeftShift);
            this.panel75.Controls.Add(this.layerL2UpShift);
            this.panel75.Controls.Add(this.label23);
            this.panel75.Controls.Add(this.label10);
            this.panel75.Controls.Add(this.layerL3LeftShift);
            this.panel75.Controls.Add(this.label9);
            this.panel75.Controls.Add(this.layerL3UpShift);
            this.panel75.Controls.Add(this.label8);
            this.panel75.Location = new System.Drawing.Point(0, 197);
            this.panel75.Name = "panel75";
            this.panel75.Size = new System.Drawing.Size(260, 58);
            this.panel75.TabIndex = 445;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.SystemColors.Control;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label5.Size = new System.Drawing.Size(256, 17);
            this.label5.TabIndex = 104;
            this.label5.Text = "LAYER SHIFTING";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // layerL2LeftShift
            // 
            this.layerL2LeftShift.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.layerL2LeftShift.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layerL2LeftShift.Location = new System.Drawing.Point(75, 19);
            this.layerL2LeftShift.Maximum = new decimal(new int[] {
            63,
            0,
            0,
            0});
            this.layerL2LeftShift.Name = "layerL2LeftShift";
            this.layerL2LeftShift.Size = new System.Drawing.Size(54, 17);
            this.layerL2LeftShift.TabIndex = 31;
            this.layerL2LeftShift.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.layerL2LeftShift.ValueChanged += new System.EventHandler(this.layerL2LeftShift_ValueChanged);
            // 
            // layerL2UpShift
            // 
            this.layerL2UpShift.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.layerL2UpShift.Location = new System.Drawing.Point(75, 37);
            this.layerL2UpShift.Maximum = new decimal(new int[] {
            63,
            0,
            0,
            0});
            this.layerL2UpShift.Name = "layerL2UpShift";
            this.layerL2UpShift.Size = new System.Drawing.Size(54, 17);
            this.layerL2UpShift.TabIndex = 33;
            this.layerL2UpShift.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.layerL2UpShift.ValueChanged += new System.EventHandler(this.layerL2UpShift_ValueChanged);
            // 
            // label23
            // 
            this.label23.BackColor = System.Drawing.SystemColors.Control;
            this.label23.Location = new System.Drawing.Point(0, 19);
            this.label23.Name = "label23";
            this.label23.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label23.Size = new System.Drawing.Size(74, 17);
            this.label23.TabIndex = 82;
            this.label23.Text = "L2 Left Shift";
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.SystemColors.Control;
            this.label10.Location = new System.Drawing.Point(0, 37);
            this.label10.Name = "label10";
            this.label10.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label10.Size = new System.Drawing.Size(74, 17);
            this.label10.TabIndex = 83;
            this.label10.Text = "L2 Up Shift";
            // 
            // layerL3LeftShift
            // 
            this.layerL3LeftShift.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.layerL3LeftShift.Location = new System.Drawing.Point(205, 19);
            this.layerL3LeftShift.Maximum = new decimal(new int[] {
            63,
            0,
            0,
            0});
            this.layerL3LeftShift.Name = "layerL3LeftShift";
            this.layerL3LeftShift.Size = new System.Drawing.Size(51, 17);
            this.layerL3LeftShift.TabIndex = 32;
            this.layerL3LeftShift.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.layerL3LeftShift.ValueChanged += new System.EventHandler(this.layerL3LeftShift_ValueChanged);
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.SystemColors.Control;
            this.label9.Location = new System.Drawing.Point(130, 19);
            this.label9.Name = "label9";
            this.label9.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label9.Size = new System.Drawing.Size(74, 17);
            this.label9.TabIndex = 85;
            this.label9.Text = "L3 Left Shift";
            // 
            // layerL3UpShift
            // 
            this.layerL3UpShift.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.layerL3UpShift.Location = new System.Drawing.Point(205, 37);
            this.layerL3UpShift.Maximum = new decimal(new int[] {
            63,
            0,
            0,
            0});
            this.layerL3UpShift.Name = "layerL3UpShift";
            this.layerL3UpShift.Size = new System.Drawing.Size(51, 17);
            this.layerL3UpShift.TabIndex = 34;
            this.layerL3UpShift.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.layerL3UpShift.ValueChanged += new System.EventHandler(this.layerL3UpShift_ValueChanged);
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.SystemColors.Control;
            this.label8.Location = new System.Drawing.Point(130, 37);
            this.label8.Name = "label8";
            this.label8.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label8.Size = new System.Drawing.Size(74, 17);
            this.label8.TabIndex = 86;
            this.label8.Text = "L3 Up Shift";
            // 
            // panel76
            // 
            this.panel76.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel76.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel76.Controls.Add(this.label91);
            this.panel76.Controls.Add(this.layerScrollWrapping);
            this.panel76.Location = new System.Drawing.Point(0, 257);
            this.panel76.Name = "panel76";
            this.panel76.Size = new System.Drawing.Size(260, 87);
            this.panel76.TabIndex = 446;
            // 
            // label91
            // 
            this.label91.BackColor = System.Drawing.SystemColors.Control;
            this.label91.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label91.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label91.Location = new System.Drawing.Point(0, 0);
            this.label91.Name = "label91";
            this.label91.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label91.Size = new System.Drawing.Size(256, 17);
            this.label91.TabIndex = 104;
            this.label91.Text = "SCROLL WRAPPING";
            this.label91.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // layerScrollWrapping
            // 
            this.layerScrollWrapping.BackColor = System.Drawing.SystemColors.Window;
            this.layerScrollWrapping.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.layerScrollWrapping.CheckOnClick = true;
            this.layerScrollWrapping.ColumnWidth = 118;
            this.layerScrollWrapping.Items.AddRange(new object[] {
            "L1 horizontal",
            "L1 vertical",
            "L2 horizontal",
            "L2 vertical",
            "L3 horizontal",
            "L3 vertical",
            "(used only Culex)",
            "(used only Culex)"});
            this.layerScrollWrapping.Location = new System.Drawing.Point(0, 19);
            this.layerScrollWrapping.MultiColumn = true;
            this.layerScrollWrapping.Name = "layerScrollWrapping";
            this.layerScrollWrapping.Size = new System.Drawing.Size(256, 64);
            this.layerScrollWrapping.TabIndex = 35;
            this.layerScrollWrapping.SelectedIndexChanged += new System.EventHandler(this.layerScrollWrapping_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel8);
            this.tabPage1.Controls.Add(this.panel27);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(260, 640);
            this.tabPage1.TabIndex = 5;
            this.tabPage1.Text = "MODS";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.panel15);
            this.panel8.Controls.Add(this.tileModsBytesLeft);
            this.panel8.Controls.Add(this.tileModsFieldTree);
            this.panel8.Controls.Add(this.toolStrip7);
            this.panel8.Controls.Add(this.label69);
            this.panel8.Controls.Add(this.panel55);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(260, 300);
            this.panel8.TabIndex = 1;
            // 
            // panel15
            // 
            this.panel15.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel15.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel15.Controls.Add(this.tileModsLayers);
            this.panel15.Controls.Add(this.label26);
            this.panel15.Controls.Add(this.tileModsY);
            this.panel15.Controls.Add(this.label27);
            this.panel15.Controls.Add(this.tileModsX);
            this.panel15.Controls.Add(this.tileModsHeight);
            this.panel15.Controls.Add(this.tileModsWidth);
            this.panel15.Controls.Add(this.label36);
            this.panel15.Controls.Add(this.label50);
            this.panel15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel15.Location = new System.Drawing.Point(125, 65);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(135, 235);
            this.panel15.TabIndex = 495;
            // 
            // tileModsLayers
            // 
            this.tileModsLayers.BackColor = System.Drawing.SystemColors.Window;
            this.tileModsLayers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tileModsLayers.CheckOnClick = true;
            this.tileModsLayers.ColumnWidth = 60;
            this.tileModsLayers.Items.AddRange(new object[] {
            "Layer 1",
            "Layer 2",
            "Layer 3",
            "B0b7"});
            this.tileModsLayers.Location = new System.Drawing.Point(0, 72);
            this.tileModsLayers.Name = "tileModsLayers";
            this.tileModsLayers.Size = new System.Drawing.Size(131, 64);
            this.tileModsLayers.TabIndex = 489;
            this.tileModsLayers.SelectedIndexChanged += new System.EventHandler(this.tileModsLayers_SelectedIndexChanged);
            // 
            // label26
            // 
            this.label26.BackColor = System.Drawing.SystemColors.Control;
            this.label26.Location = new System.Drawing.Point(0, 0);
            this.label26.Name = "label26";
            this.label26.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label26.Size = new System.Drawing.Size(58, 17);
            this.label26.TabIndex = 474;
            this.label26.Text = "X Coord";
            // 
            // tileModsY
            // 
            this.tileModsY.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tileModsY.Location = new System.Drawing.Point(59, 18);
            this.tileModsY.Maximum = new decimal(new int[] {
            63,
            0,
            0,
            0});
            this.tileModsY.Name = "tileModsY";
            this.tileModsY.Size = new System.Drawing.Size(72, 17);
            this.tileModsY.TabIndex = 139;
            this.tileModsY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tileModsY.ValueChanged += new System.EventHandler(this.tileModsY_ValueChanged);
            // 
            // label27
            // 
            this.label27.BackColor = System.Drawing.SystemColors.Control;
            this.label27.Location = new System.Drawing.Point(0, 18);
            this.label27.Name = "label27";
            this.label27.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label27.Size = new System.Drawing.Size(58, 17);
            this.label27.TabIndex = 476;
            this.label27.Text = "Y Coord";
            // 
            // tileModsX
            // 
            this.tileModsX.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tileModsX.Location = new System.Drawing.Point(59, 0);
            this.tileModsX.Maximum = new decimal(new int[] {
            63,
            0,
            0,
            0});
            this.tileModsX.Name = "tileModsX";
            this.tileModsX.Size = new System.Drawing.Size(72, 17);
            this.tileModsX.TabIndex = 138;
            this.tileModsX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tileModsX.ValueChanged += new System.EventHandler(this.tileModsX_ValueChanged);
            // 
            // tileModsHeight
            // 
            this.tileModsHeight.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tileModsHeight.Location = new System.Drawing.Point(59, 54);
            this.tileModsHeight.Maximum = new decimal(new int[] {
            63,
            0,
            0,
            0});
            this.tileModsHeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.tileModsHeight.Name = "tileModsHeight";
            this.tileModsHeight.Size = new System.Drawing.Size(72, 17);
            this.tileModsHeight.TabIndex = 140;
            this.tileModsHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tileModsHeight.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.tileModsHeight.ValueChanged += new System.EventHandler(this.tileModsHeight_ValueChanged);
            // 
            // tileModsWidth
            // 
            this.tileModsWidth.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tileModsWidth.Location = new System.Drawing.Point(59, 36);
            this.tileModsWidth.Maximum = new decimal(new int[] {
            63,
            0,
            0,
            0});
            this.tileModsWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.tileModsWidth.Name = "tileModsWidth";
            this.tileModsWidth.Size = new System.Drawing.Size(72, 17);
            this.tileModsWidth.TabIndex = 140;
            this.tileModsWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tileModsWidth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.tileModsWidth.ValueChanged += new System.EventHandler(this.tileModsWidth_ValueChanged);
            // 
            // label36
            // 
            this.label36.BackColor = System.Drawing.SystemColors.Control;
            this.label36.Location = new System.Drawing.Point(0, 36);
            this.label36.Name = "label36";
            this.label36.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label36.Size = new System.Drawing.Size(58, 17);
            this.label36.TabIndex = 487;
            this.label36.Text = "Width";
            // 
            // label50
            // 
            this.label50.BackColor = System.Drawing.SystemColors.Control;
            this.label50.Location = new System.Drawing.Point(0, 54);
            this.label50.Name = "label50";
            this.label50.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label50.Size = new System.Drawing.Size(58, 17);
            this.label50.TabIndex = 488;
            this.label50.Text = "Height";
            // 
            // tileModsFieldTree
            // 
            this.tileModsFieldTree.Dock = System.Windows.Forms.DockStyle.Left;
            this.tileModsFieldTree.HideSelection = false;
            this.tileModsFieldTree.HotTracking = true;
            this.tileModsFieldTree.Location = new System.Drawing.Point(0, 44);
            this.tileModsFieldTree.Name = "tileModsFieldTree";
            this.tileModsFieldTree.ShowRootLines = false;
            this.tileModsFieldTree.Size = new System.Drawing.Size(125, 256);
            this.tileModsFieldTree.TabIndex = 127;
            this.tileModsFieldTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tileModsFieldTree_AfterSelect);
            // 
            // toolStrip7
            // 
            this.toolStrip7.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip7.CanOverflow = false;
            this.toolStrip7.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tileModsInsertField,
            this.tileModsInsertInstance,
            this.tileModsDeleteField,
            this.toolStripSeparator11,
            this.tileModsMoveUp,
            this.tileModsMoveDown,
            this.toolStripSeparator12,
            this.tileModsCopy,
            this.tileModsPaste,
            this.tileModsDuplicate});
            this.toolStrip7.Location = new System.Drawing.Point(0, 19);
            this.toolStrip7.Name = "toolStrip7";
            this.toolStrip7.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip7.Size = new System.Drawing.Size(260, 25);
            this.toolStrip7.TabIndex = 496;
            this.toolStrip7.Text = "toolStrip7";
            // 
            // tileModsInsertField
            // 
            this.tileModsInsertField.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tileModsInsertField.Image = global::LAZYSHELL.Properties.Resources.new_small;
            this.tileModsInsertField.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tileModsInsertField.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tileModsInsertField.Name = "tileModsInsertField";
            this.tileModsInsertField.Size = new System.Drawing.Size(23, 22);
            this.tileModsInsertField.Text = "New Tilemap Mod";
            this.tileModsInsertField.Click += new System.EventHandler(this.tileModsInsertField_Click);
            // 
            // tileModsInsertInstance
            // 
            this.tileModsInsertInstance.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tileModsInsertInstance.Image = global::LAZYSHELL.Properties.Resources.newInstance;
            this.tileModsInsertInstance.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tileModsInsertInstance.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tileModsInsertInstance.Name = "tileModsInsertInstance";
            this.tileModsInsertInstance.Size = new System.Drawing.Size(23, 22);
            this.tileModsInsertInstance.Text = "New Alternate Tilemap Mod";
            this.tileModsInsertInstance.Click += new System.EventHandler(this.tileModsInsertInstance_Click);
            // 
            // tileModsDeleteField
            // 
            this.tileModsDeleteField.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tileModsDeleteField.Image = global::LAZYSHELL.Properties.Resources.delete_small;
            this.tileModsDeleteField.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tileModsDeleteField.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tileModsDeleteField.Name = "tileModsDeleteField";
            this.tileModsDeleteField.Size = new System.Drawing.Size(23, 22);
            this.tileModsDeleteField.Text = "Delete Tilemap Mod";
            this.tileModsDeleteField.Click += new System.EventHandler(this.tileModsDeleteField_Click);
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(6, 25);
            // 
            // tileModsMoveUp
            // 
            this.tileModsMoveUp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tileModsMoveUp.Image = global::LAZYSHELL.Properties.Resources.moveup;
            this.tileModsMoveUp.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tileModsMoveUp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tileModsMoveUp.Name = "tileModsMoveUp";
            this.tileModsMoveUp.Size = new System.Drawing.Size(23, 22);
            this.tileModsMoveUp.Text = "Move Tilemap Mod Up";
            this.tileModsMoveUp.Click += new System.EventHandler(this.tileModsMoveUp_Click);
            // 
            // tileModsMoveDown
            // 
            this.tileModsMoveDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tileModsMoveDown.Image = global::LAZYSHELL.Properties.Resources.movedown;
            this.tileModsMoveDown.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tileModsMoveDown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tileModsMoveDown.Name = "tileModsMoveDown";
            this.tileModsMoveDown.Size = new System.Drawing.Size(23, 22);
            this.tileModsMoveDown.Text = "Move Tilemap Mod Down";
            this.tileModsMoveDown.Click += new System.EventHandler(this.tileModsMoveDown_Click);
            // 
            // toolStripSeparator12
            // 
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            this.toolStripSeparator12.Size = new System.Drawing.Size(6, 25);
            // 
            // tileModsCopy
            // 
            this.tileModsCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tileModsCopy.Image = global::LAZYSHELL.Properties.Resources.copy_small;
            this.tileModsCopy.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tileModsCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tileModsCopy.Name = "tileModsCopy";
            this.tileModsCopy.Size = new System.Drawing.Size(23, 22);
            this.tileModsCopy.Text = "Copy Tilemap Mod";
            this.tileModsCopy.Click += new System.EventHandler(this.tileModsCopy_Click);
            // 
            // tileModsPaste
            // 
            this.tileModsPaste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tileModsPaste.Image = global::LAZYSHELL.Properties.Resources.paste_small;
            this.tileModsPaste.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tileModsPaste.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tileModsPaste.Name = "tileModsPaste";
            this.tileModsPaste.Size = new System.Drawing.Size(23, 22);
            this.tileModsPaste.Text = "Paste Tilemap Mod";
            this.tileModsPaste.Click += new System.EventHandler(this.tileModsPaste_Click);
            // 
            // tileModsDuplicate
            // 
            this.tileModsDuplicate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tileModsDuplicate.Image = global::LAZYSHELL.Properties.Resources.duplicate_small;
            this.tileModsDuplicate.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tileModsDuplicate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tileModsDuplicate.Name = "tileModsDuplicate";
            this.tileModsDuplicate.Size = new System.Drawing.Size(23, 22);
            this.tileModsDuplicate.Text = "Duplicate Tilemap Mod";
            this.tileModsDuplicate.Click += new System.EventHandler(this.tileModsDuplicate_Click);
            // 
            // label69
            // 
            this.label69.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label69.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label69.Dock = System.Windows.Forms.DockStyle.Top;
            this.label69.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label69.ForeColor = System.Drawing.SystemColors.Control;
            this.label69.Location = new System.Drawing.Point(0, 0);
            this.label69.Name = "label69";
            this.label69.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label69.Size = new System.Drawing.Size(260, 19);
            this.label69.TabIndex = 499;
            this.label69.Text = "TILEMAP MODS";
            this.label69.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel55
            // 
            this.panel55.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.panel55.BackgroundImage = global::LAZYSHELL.Properties.Resources._bg;
            this.panel55.Location = new System.Drawing.Point(119, 608);
            this.panel55.Name = "panel55";
            this.panel55.Size = new System.Drawing.Size(121, 124);
            this.panel55.TabIndex = 493;
            // 
            // panel27
            // 
            this.panel27.Controls.Add(this.panel44);
            this.panel27.Controls.Add(this.solidModsBytesLeft);
            this.panel27.Controls.Add(this.solidModsFieldTree);
            this.panel27.Controls.Add(this.toolStrip8);
            this.panel27.Controls.Add(this.label68);
            this.panel27.Controls.Add(this.panel45);
            this.panel27.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel27.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel27.Location = new System.Drawing.Point(0, 300);
            this.panel27.Name = "panel27";
            this.panel27.Size = new System.Drawing.Size(260, 340);
            this.panel27.TabIndex = 2;
            // 
            // panel44
            // 
            this.panel44.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel44.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel44.Controls.Add(this.label14);
            this.panel44.Controls.Add(this.solidModsY);
            this.panel44.Controls.Add(this.label51);
            this.panel44.Controls.Add(this.solidModsX);
            this.panel44.Controls.Add(this.solidModsHeight);
            this.panel44.Controls.Add(this.solidModsWidth);
            this.panel44.Controls.Add(this.label64);
            this.panel44.Controls.Add(this.label67);
            this.panel44.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel44.Location = new System.Drawing.Point(125, 65);
            this.panel44.Name = "panel44";
            this.panel44.Size = new System.Drawing.Size(135, 275);
            this.panel44.TabIndex = 495;
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.SystemColors.Control;
            this.label14.Location = new System.Drawing.Point(0, 0);
            this.label14.Name = "label14";
            this.label14.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label14.Size = new System.Drawing.Size(58, 17);
            this.label14.TabIndex = 474;
            this.label14.Text = "X Coord";
            // 
            // solidModsY
            // 
            this.solidModsY.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.solidModsY.Location = new System.Drawing.Point(59, 18);
            this.solidModsY.Maximum = new decimal(new int[] {
            127,
            0,
            0,
            0});
            this.solidModsY.Name = "solidModsY";
            this.solidModsY.Size = new System.Drawing.Size(72, 17);
            this.solidModsY.TabIndex = 139;
            this.solidModsY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.solidModsY.ValueChanged += new System.EventHandler(this.solidModsY_ValueChanged);
            // 
            // label51
            // 
            this.label51.BackColor = System.Drawing.SystemColors.Control;
            this.label51.Location = new System.Drawing.Point(0, 18);
            this.label51.Name = "label51";
            this.label51.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label51.Size = new System.Drawing.Size(58, 17);
            this.label51.TabIndex = 476;
            this.label51.Text = "Y Coord";
            // 
            // solidModsX
            // 
            this.solidModsX.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.solidModsX.Location = new System.Drawing.Point(59, 0);
            this.solidModsX.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.solidModsX.Name = "solidModsX";
            this.solidModsX.Size = new System.Drawing.Size(72, 17);
            this.solidModsX.TabIndex = 138;
            this.solidModsX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.solidModsX.ValueChanged += new System.EventHandler(this.solidModsX_ValueChanged);
            // 
            // solidModsHeight
            // 
            this.solidModsHeight.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.solidModsHeight.Location = new System.Drawing.Point(59, 54);
            this.solidModsHeight.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.solidModsHeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.solidModsHeight.Name = "solidModsHeight";
            this.solidModsHeight.Size = new System.Drawing.Size(72, 17);
            this.solidModsHeight.TabIndex = 140;
            this.solidModsHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.solidModsHeight.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.solidModsHeight.ValueChanged += new System.EventHandler(this.solidModsHeight_ValueChanged);
            // 
            // solidModsWidth
            // 
            this.solidModsWidth.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.solidModsWidth.Location = new System.Drawing.Point(59, 36);
            this.solidModsWidth.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.solidModsWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.solidModsWidth.Name = "solidModsWidth";
            this.solidModsWidth.Size = new System.Drawing.Size(72, 17);
            this.solidModsWidth.TabIndex = 140;
            this.solidModsWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.solidModsWidth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.solidModsWidth.ValueChanged += new System.EventHandler(this.solidModsWidth_ValueChanged);
            // 
            // label64
            // 
            this.label64.BackColor = System.Drawing.SystemColors.Control;
            this.label64.Location = new System.Drawing.Point(0, 36);
            this.label64.Name = "label64";
            this.label64.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label64.Size = new System.Drawing.Size(58, 17);
            this.label64.TabIndex = 487;
            this.label64.Text = "Width";
            // 
            // label67
            // 
            this.label67.BackColor = System.Drawing.SystemColors.Control;
            this.label67.Location = new System.Drawing.Point(0, 54);
            this.label67.Name = "label67";
            this.label67.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label67.Size = new System.Drawing.Size(58, 17);
            this.label67.TabIndex = 488;
            this.label67.Text = "Height";
            // 
            // solidModsFieldTree
            // 
            this.solidModsFieldTree.Dock = System.Windows.Forms.DockStyle.Left;
            this.solidModsFieldTree.HideSelection = false;
            this.solidModsFieldTree.HotTracking = true;
            this.solidModsFieldTree.Location = new System.Drawing.Point(0, 44);
            this.solidModsFieldTree.Name = "solidModsFieldTree";
            this.solidModsFieldTree.ShowRootLines = false;
            this.solidModsFieldTree.Size = new System.Drawing.Size(125, 296);
            this.solidModsFieldTree.TabIndex = 127;
            this.solidModsFieldTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.solidModsFieldTree_AfterSelect);
            // 
            // toolStrip8
            // 
            this.toolStrip8.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip8.CanOverflow = false;
            this.toolStrip8.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.solidModsInsert,
            this.solidModsDelete,
            this.toolStripSeparator13,
            this.solidModsMoveUp,
            this.solidModsMoveDown,
            this.toolStripSeparator14,
            this.solidModsCopy,
            this.solidModsPaste,
            this.solidModsDuplicate});
            this.toolStrip8.Location = new System.Drawing.Point(0, 19);
            this.toolStrip8.Name = "toolStrip8";
            this.toolStrip8.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip8.Size = new System.Drawing.Size(260, 25);
            this.toolStrip8.TabIndex = 496;
            this.toolStrip8.Text = "toolStrip8";
            // 
            // solidModsInsert
            // 
            this.solidModsInsert.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.solidModsInsert.Image = global::LAZYSHELL.Properties.Resources.new_small;
            this.solidModsInsert.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.solidModsInsert.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.solidModsInsert.Name = "solidModsInsert";
            this.solidModsInsert.Size = new System.Drawing.Size(23, 22);
            this.solidModsInsert.Text = "New Solidity Mod";
            this.solidModsInsert.Click += new System.EventHandler(this.solidModsInsert_Click);
            // 
            // solidModsDelete
            // 
            this.solidModsDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.solidModsDelete.Image = global::LAZYSHELL.Properties.Resources.delete_small;
            this.solidModsDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.solidModsDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.solidModsDelete.Name = "solidModsDelete";
            this.solidModsDelete.Size = new System.Drawing.Size(23, 22);
            this.solidModsDelete.Text = "Delete Solidity Mod";
            this.solidModsDelete.Click += new System.EventHandler(this.solidModsDelete_Click);
            // 
            // toolStripSeparator13
            // 
            this.toolStripSeparator13.Name = "toolStripSeparator13";
            this.toolStripSeparator13.Size = new System.Drawing.Size(6, 25);
            // 
            // solidModsMoveUp
            // 
            this.solidModsMoveUp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.solidModsMoveUp.Image = global::LAZYSHELL.Properties.Resources.moveup;
            this.solidModsMoveUp.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.solidModsMoveUp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.solidModsMoveUp.Name = "solidModsMoveUp";
            this.solidModsMoveUp.Size = new System.Drawing.Size(23, 22);
            this.solidModsMoveUp.Text = "Move Solidity Mod Up";
            this.solidModsMoveUp.Click += new System.EventHandler(this.solidModsMoveUp_Click);
            // 
            // solidModsMoveDown
            // 
            this.solidModsMoveDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.solidModsMoveDown.Image = global::LAZYSHELL.Properties.Resources.movedown;
            this.solidModsMoveDown.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.solidModsMoveDown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.solidModsMoveDown.Name = "solidModsMoveDown";
            this.solidModsMoveDown.Size = new System.Drawing.Size(23, 22);
            this.solidModsMoveDown.Text = "Move Solidity Mod Down";
            this.solidModsMoveDown.Click += new System.EventHandler(this.solidModsMoveDown_Click);
            // 
            // toolStripSeparator14
            // 
            this.toolStripSeparator14.Name = "toolStripSeparator14";
            this.toolStripSeparator14.Size = new System.Drawing.Size(6, 25);
            // 
            // solidModsCopy
            // 
            this.solidModsCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.solidModsCopy.Image = global::LAZYSHELL.Properties.Resources.copy_small;
            this.solidModsCopy.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.solidModsCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.solidModsCopy.Name = "solidModsCopy";
            this.solidModsCopy.Size = new System.Drawing.Size(23, 22);
            this.solidModsCopy.Text = "Copy Solidity Mod";
            this.solidModsCopy.Click += new System.EventHandler(this.solidModsCopy_Click);
            // 
            // solidModsPaste
            // 
            this.solidModsPaste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.solidModsPaste.Image = global::LAZYSHELL.Properties.Resources.paste_small;
            this.solidModsPaste.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.solidModsPaste.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.solidModsPaste.Name = "solidModsPaste";
            this.solidModsPaste.Size = new System.Drawing.Size(23, 22);
            this.solidModsPaste.Text = "Paste Solidity Mod";
            this.solidModsPaste.Click += new System.EventHandler(this.solidModsPaste_Click);
            // 
            // solidModsDuplicate
            // 
            this.solidModsDuplicate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.solidModsDuplicate.Image = global::LAZYSHELL.Properties.Resources.duplicate_small;
            this.solidModsDuplicate.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.solidModsDuplicate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.solidModsDuplicate.Name = "solidModsDuplicate";
            this.solidModsDuplicate.Size = new System.Drawing.Size(23, 22);
            this.solidModsDuplicate.Text = "Duplicate Solidity Mod";
            this.solidModsDuplicate.Click += new System.EventHandler(this.solidModsDuplicate_Click);
            // 
            // label68
            // 
            this.label68.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label68.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label68.Dock = System.Windows.Forms.DockStyle.Top;
            this.label68.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label68.ForeColor = System.Drawing.SystemColors.Control;
            this.label68.Location = new System.Drawing.Point(0, 0);
            this.label68.Name = "label68";
            this.label68.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label68.Size = new System.Drawing.Size(260, 19);
            this.label68.TabIndex = 498;
            this.label68.Text = "SOLIDITY MAP MODS";
            this.label68.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel45
            // 
            this.panel45.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.panel45.BackgroundImage = global::LAZYSHELL.Properties.Resources._bg;
            this.panel45.Location = new System.Drawing.Point(119, 608);
            this.panel45.Name = "panel45";
            this.panel45.Size = new System.Drawing.Size(121, 164);
            this.panel45.TabIndex = 493;
            // 
            // toolStrip1
            // 
            this.toolStrip1.CanOverflow = false;
            this.toolStrip1.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.levelName,
            this.levelNum,
            this.nameTextBox,
            this.searchLevelNames,
            this.toolStripSeparator7,
            this.changeLevelName,
            this.toolStripTextBox1,
            this.toolStripButton1,
            this.toolStripSeparator21,
            this.buttonGotoC,
            this.eventExit,
            this.toolStripSeparator16,
            this.toolStripLabel2,
            this.eventMusic});
            this.toolStrip1.Location = new System.Drawing.Point(0, 25);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(1020, 25);
            this.toolStrip1.TabIndex = 2;
            // 
            // nameTextBox
            // 
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(150, 25);
            // 
            // searchLevelNames
            // 
            this.searchLevelNames.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.searchLevelNames.Image = global::LAZYSHELL.Properties.Resources.search;
            this.searchLevelNames.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.searchLevelNames.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.searchLevelNames.Name = "searchLevelNames";
            this.searchLevelNames.Size = new System.Drawing.Size(23, 22);
            this.searchLevelNames.Text = "Search Level Names";
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 25);
            // 
            // changeLevelName
            // 
            this.changeLevelName.CheckOnClick = true;
            this.changeLevelName.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.changeLevelName.Image = global::LAZYSHELL.Properties.Resources.label;
            this.changeLevelName.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.changeLevelName.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.changeLevelName.Name = "changeLevelName";
            this.changeLevelName.Size = new System.Drawing.Size(23, 22);
            this.changeLevelName.Text = "Edit level name";
            this.changeLevelName.Click += new System.EventHandler(this.changeLevelName_Click);
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(160, 25);
            this.toolStripTextBox1.Visible = false;
            this.toolStripTextBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.toolStripTextBox1_KeyDown);
            this.toolStripTextBox1.TextChanged += new System.EventHandler(this.toolStripTextBox1_TextChanged);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = global::LAZYSHELL.Properties.Resources.reset;
            this.toolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.ToolTipText = "Reset";
            this.toolStripButton1.Visible = false;
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripSeparator21
            // 
            this.toolStripSeparator21.Name = "toolStripSeparator21";
            this.toolStripSeparator21.Size = new System.Drawing.Size(6, 25);
            // 
            // buttonGotoC
            // 
            this.buttonGotoC.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.buttonGotoC.Image = ((System.Drawing.Image)(resources.GetObject("buttonGotoC.Image")));
            this.buttonGotoC.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonGotoC.Name = "buttonGotoC";
            this.buttonGotoC.Size = new System.Drawing.Size(52, 22);
            this.buttonGotoC.Text = "EVENT #";
            this.buttonGotoC.ToolTipText = "Click to edit event";
            this.buttonGotoC.Click += new System.EventHandler(this.buttonGotoC_Click);
            // 
            // eventExit
            // 
            this.eventExit.AutoSize = false;
            this.eventExit.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eventExit.Hexadecimal = false;
            this.eventExit.Location = new System.Drawing.Point(531, 2);
            this.eventExit.Maximum = new decimal(new int[] {
            4095,
            0,
            0,
            0});
            this.eventExit.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.eventExit.Name = "eventExit";
            this.eventExit.Size = new System.Drawing.Size(60, 21);
            this.eventExit.Text = "0";
            this.eventExit.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.eventExit.ValueChanged += new System.EventHandler(this.eventsExitEvent_ValueChanged);
            // 
            // toolStripSeparator16
            // 
            this.toolStripSeparator16.Name = "toolStripSeparator16";
            this.toolStripSeparator16.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(39, 22);
            this.toolStripLabel2.Text = "MUSIC";
            // 
            // eventMusic
            // 
            this.eventMusic.DropDownHeight = 300;
            this.eventMusic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.eventMusic.DropDownWidth = 300;
            this.eventMusic.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.eventMusic.IntegralHeight = false;
            this.eventMusic.Name = "eventMusic";
            this.eventMusic.Size = new System.Drawing.Size(180, 25);
            this.eventMusic.SelectedIndexChanged += new System.EventHandler(this.eventsAreaMusic_SelectedIndexChanged);
            // 
            // hexEditor
            // 
            this.hexEditor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.hexEditor.Image = global::LAZYSHELL.Properties.Resources.hexEditor;
            this.hexEditor.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.hexEditor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.hexEditor.Name = "hexEditor";
            this.hexEditor.Size = new System.Drawing.Size(23, 22);
            this.hexEditor.Text = "Hex Editor";
            this.hexEditor.Click += new System.EventHandler(this.hexEditor_Click);
            // 
            // propertiesButton
            // 
            this.propertiesButton.Checked = true;
            this.propertiesButton.CheckOnClick = true;
            this.propertiesButton.CheckState = System.Windows.Forms.CheckState.Checked;
            this.propertiesButton.Image = global::LAZYSHELL.Properties.Resources.showMain;
            this.propertiesButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.propertiesButton.Name = "propertiesButton";
            this.propertiesButton.Size = new System.Drawing.Size(23, 22);
            this.propertiesButton.ToolTipText = "Main Properties Window";
            this.propertiesButton.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // openTileset
            // 
            this.openTileset.CheckOnClick = true;
            this.openTileset.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openTileset.Image = global::LAZYSHELL.Properties.Resources.openTilesets;
            this.openTileset.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.openTileset.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openTileset.Name = "openTileset";
            this.openTileset.Size = new System.Drawing.Size(23, 22);
            this.openTileset.ToolTipText = "Tileset";
            this.openTileset.Click += new System.EventHandler(this.openTileset_Click);
            // 
            // openTilemap
            // 
            this.openTilemap.CheckOnClick = true;
            this.openTilemap.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openTilemap.Image = global::LAZYSHELL.Properties.Resources.openMap;
            this.openTilemap.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.openTilemap.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openTilemap.Name = "openTilemap";
            this.openTilemap.Size = new System.Drawing.Size(23, 22);
            this.openTilemap.ToolTipText = "Tilemap";
            this.openTilemap.Click += new System.EventHandler(this.openTilemap_Click);
            // 
            // openSolidTileset
            // 
            this.openSolidTileset.CheckOnClick = true;
            this.openSolidTileset.Image = global::LAZYSHELL.Properties.Resources.buttonPhysicalTiles;
            this.openSolidTileset.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openSolidTileset.Name = "openSolidTileset";
            this.openSolidTileset.Size = new System.Drawing.Size(23, 22);
            this.openSolidTileset.ToolTipText = "Solid Tileset";
            this.openSolidTileset.Click += new System.EventHandler(this.openSolidTileset_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // openPaletteEditor
            // 
            this.openPaletteEditor.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openPaletteEditor.Image = global::LAZYSHELL.Properties.Resources.openPalettes;
            this.openPaletteEditor.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.openPaletteEditor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openPaletteEditor.Name = "openPaletteEditor";
            this.openPaletteEditor.Size = new System.Drawing.Size(23, 22);
            this.openPaletteEditor.ToolTipText = "Palettes";
            this.openPaletteEditor.Click += new System.EventHandler(this.openPaletteEditor_Click);
            // 
            // openGraphicEditor
            // 
            this.openGraphicEditor.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openGraphicEditor.Image = global::LAZYSHELL.Properties.Resources.openGraphics;
            this.openGraphicEditor.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.openGraphicEditor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openGraphicEditor.Name = "openGraphicEditor";
            this.openGraphicEditor.Size = new System.Drawing.Size(23, 22);
            this.openGraphicEditor.ToolTipText = "BPP Graphics";
            this.openGraphicEditor.Click += new System.EventHandler(this.openGraphicEditor_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // openTemplates
            // 
            this.openTemplates.CheckOnClick = true;
            this.openTemplates.Image = global::LAZYSHELL.Properties.Resources.openTemplates;
            this.openTemplates.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.openTemplates.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openTemplates.Name = "openTemplates";
            this.openTemplates.Size = new System.Drawing.Size(23, 22);
            this.openTemplates.ToolTipText = "Templates";
            this.openTemplates.Click += new System.EventHandler(this.openTemplates_Click);
            // 
            // levelPreviewToolStripButton
            // 
            this.levelPreviewToolStripButton.Image = global::LAZYSHELL.Properties.Resources.preview;
            this.levelPreviewToolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.levelPreviewToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.levelPreviewToolStripButton.Name = "levelPreviewToolStripButton";
            this.levelPreviewToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.levelPreviewToolStripButton.ToolTipText = "Previewer";
            this.levelPreviewToolStripButton.Click += new System.EventHandler(this.levelPreviewToolStripButton_Click);
            // 
            // spaceAnalyzer
            // 
            this.spaceAnalyzer.Image = global::LAZYSHELL.Properties.Resources.spaceAnalyzer;
            this.spaceAnalyzer.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.spaceAnalyzer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.spaceAnalyzer.Name = "spaceAnalyzer";
            this.spaceAnalyzer.Size = new System.Drawing.Size(23, 22);
            this.spaceAnalyzer.ToolTipText = "Space Analyzer";
            this.spaceAnalyzer.Click += new System.EventHandler(this.spaceAnalyzer_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem6.Text = "toolStripMenuItem6";
            // 
            // toolTip1
            // 
            this.toolTip1.Active = false;
            // 
            // panelLevels
            // 
            this.panelLevels.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panelLevels.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelLevels.Controls.Add(this.tabControl);
            this.panelLevels.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLevels.Location = new System.Drawing.Point(0, 50);
            this.panelLevels.Name = "panelLevels";
            this.panelLevels.Size = new System.Drawing.Size(1020, 670);
            this.panelLevels.TabIndex = 506;
            // 
            // toolStrip2
            // 
            this.toolStrip2.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.save,
            this.toolStripSeparator5,
            this.import,
            this.export,
            this.toolStripDropDownButton1,
            this.clear,
            this.toolStripSeparator6,
            this.toolStripDropDownButton2,
            this.help,
            this.baseConversion,
            this.hexEditor,
            this.toolStripSeparator15,
            this.propertiesButton,
            this.openTileset,
            this.openTilemap,
            this.openSolidTileset,
            this.toolStripSeparator1,
            this.openPaletteEditor,
            this.openGraphicEditor,
            this.toolStripSeparator2,
            this.openTemplates,
            this.levelPreviewToolStripButton,
            this.spaceAnalyzer});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip2.Size = new System.Drawing.Size(1020, 25);
            this.toolStrip2.TabIndex = 507;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // save
            // 
            this.save.Image = global::LAZYSHELL.Properties.Resources.save_small;
            this.save.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.save.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(23, 22);
            this.save.ToolTipText = "Save";
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // import
            // 
            this.import.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.allToolStripMenuItem,
            this.importArchitectureToolStripMenuItem,
            this.toolStripSeparator30,
            this.arraysToolStripMenuItem1,
            this.graphicSetsToolStripMenuItem1});
            this.import.Image = global::LAZYSHELL.Properties.Resources.import_small;
            this.import.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.import.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.import.Name = "import";
            this.import.Size = new System.Drawing.Size(26, 22);
            this.import.ToolTipText = "Import";
            // 
            // allToolStripMenuItem
            // 
            this.allToolStripMenuItem.Name = "allToolStripMenuItem";
            this.allToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.allToolStripMenuItem.Text = "Import Level Data...";
            this.allToolStripMenuItem.Click += new System.EventHandler(this.importLevelDataAll_Click);
            // 
            // importArchitectureToolStripMenuItem
            // 
            this.importArchitectureToolStripMenuItem.Name = "importArchitectureToolStripMenuItem";
            this.importArchitectureToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.importArchitectureToolStripMenuItem.Text = "Import Architecture...";
            this.importArchitectureToolStripMenuItem.Click += new System.EventHandler(this.importArchitectureToolStripMenuItem_Click);
            // 
            // toolStripSeparator30
            // 
            this.toolStripSeparator30.Name = "toolStripSeparator30";
            this.toolStripSeparator30.Size = new System.Drawing.Size(177, 6);
            // 
            // arraysToolStripMenuItem1
            // 
            this.arraysToolStripMenuItem1.Name = "arraysToolStripMenuItem1";
            this.arraysToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.arraysToolStripMenuItem1.Text = "Import Arrays...";
            this.arraysToolStripMenuItem1.Click += new System.EventHandler(this.arraysToolStripMenuItem1_Click);
            // 
            // graphicSetsToolStripMenuItem1
            // 
            this.graphicSetsToolStripMenuItem1.Name = "graphicSetsToolStripMenuItem1";
            this.graphicSetsToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.graphicSetsToolStripMenuItem1.Text = "Import Graphic Set...";
            this.graphicSetsToolStripMenuItem1.Click += new System.EventHandler(this.graphicSetsToolStripMenuItem1_Click);
            // 
            // export
            // 
            this.export.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.exportArchitectureToolStripMenuItem,
            this.toolStripSeparator28,
            this.arraysToolStripMenuItem,
            this.graphicSetsToolStripMenuItem,
            this.exportLevelImagesToolStripMenuItem1,
            this.toolStripSeparator32,
            this.dumpTextToolStripMenuItem});
            this.export.Image = global::LAZYSHELL.Properties.Resources.export_small;
            this.export.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.export.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.export.Name = "export";
            this.export.Size = new System.Drawing.Size(26, 22);
            this.export.ToolTipText = "Export";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(182, 22);
            this.toolStripMenuItem1.Text = "Export Level Data...";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.exportLevelDataAll_Click);
            // 
            // exportArchitectureToolStripMenuItem
            // 
            this.exportArchitectureToolStripMenuItem.Name = "exportArchitectureToolStripMenuItem";
            this.exportArchitectureToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.exportArchitectureToolStripMenuItem.Text = "Export Architecture...";
            this.exportArchitectureToolStripMenuItem.Click += new System.EventHandler(this.exportArchitectureToolStripMenuItem_Click);
            // 
            // toolStripSeparator28
            // 
            this.toolStripSeparator28.Name = "toolStripSeparator28";
            this.toolStripSeparator28.Size = new System.Drawing.Size(179, 6);
            // 
            // arraysToolStripMenuItem
            // 
            this.arraysToolStripMenuItem.Name = "arraysToolStripMenuItem";
            this.arraysToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.arraysToolStripMenuItem.Text = "Export Arrays...";
            this.arraysToolStripMenuItem.Click += new System.EventHandler(this.arraysToolStripMenuItem_Click);
            // 
            // graphicSetsToolStripMenuItem
            // 
            this.graphicSetsToolStripMenuItem.Name = "graphicSetsToolStripMenuItem";
            this.graphicSetsToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.graphicSetsToolStripMenuItem.Text = "Export Graphic Sets...";
            this.graphicSetsToolStripMenuItem.Click += new System.EventHandler(this.graphicSetsToolStripMenuItem_Click);
            // 
            // exportLevelImagesToolStripMenuItem1
            // 
            this.exportLevelImagesToolStripMenuItem1.Name = "exportLevelImagesToolStripMenuItem1";
            this.exportLevelImagesToolStripMenuItem1.Size = new System.Drawing.Size(182, 22);
            this.exportLevelImagesToolStripMenuItem1.Text = "Export Level Images...";
            this.exportLevelImagesToolStripMenuItem1.Click += new System.EventHandler(this.exportLevelImagesAll_Click);
            // 
            // toolStripSeparator32
            // 
            this.toolStripSeparator32.Name = "toolStripSeparator32";
            this.toolStripSeparator32.Size = new System.Drawing.Size(179, 6);
            // 
            // dumpTextToolStripMenuItem
            // 
            this.dumpTextToolStripMenuItem.Name = "dumpTextToolStripMenuItem";
            this.dumpTextToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.dumpTextToolStripMenuItem.Text = "Dump NPCs to Text...";
            this.dumpTextToolStripMenuItem.Click += new System.EventHandler(this.dumpTextToolStripMenuItem_Click);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.resetLevelMapToolStripMenuItem,
            this.resetLayerDataToolStripMenuItem,
            this.resetNPCDataToolStripMenuItem,
            this.resetEventDataToolStripMenuItem,
            this.resetExitDataToolStripMenuItem,
            this.resetOverlapDataToolStripMenuItem,
            this.resetTilemapModsToolStripMenuItem,
            this.resetSolidityModsToolStripMenuItem,
            this.toolStripSeparator3,
            this.resetPaletteSetToolStripMenuItem,
            this.resetGraphicSetToolStripMenuItem,
            this.resetTilesetsToolStripMenuItem,
            this.resetTilemapsToolStripMenuItem,
            this.resetSolidityMapToolStripMenuItem,
            this.toolStripSeparator4,
            this.resetAllComponentsToolStripMenuItem});
            this.toolStripDropDownButton1.Image = global::LAZYSHELL.Properties.Resources.reset;
            this.toolStripDropDownButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(27, 22);
            // 
            // resetLevelMapToolStripMenuItem
            // 
            this.resetLevelMapToolStripMenuItem.Name = "resetLevelMapToolStripMenuItem";
            this.resetLevelMapToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.resetLevelMapToolStripMenuItem.Text = "Reset level map";
            this.resetLevelMapToolStripMenuItem.Click += new System.EventHandler(this.resetLevelMapToolStripMenuItem_Click);
            // 
            // resetLayerDataToolStripMenuItem
            // 
            this.resetLayerDataToolStripMenuItem.Name = "resetLayerDataToolStripMenuItem";
            this.resetLayerDataToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.resetLayerDataToolStripMenuItem.Text = "Reset layer data";
            this.resetLayerDataToolStripMenuItem.Click += new System.EventHandler(this.resetLayerDataToolStripMenuItem_Click);
            // 
            // resetNPCDataToolStripMenuItem
            // 
            this.resetNPCDataToolStripMenuItem.Name = "resetNPCDataToolStripMenuItem";
            this.resetNPCDataToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.resetNPCDataToolStripMenuItem.Text = "Reset NPCs";
            this.resetNPCDataToolStripMenuItem.Click += new System.EventHandler(this.resetNPCDataToolStripMenuItem_Click);
            // 
            // resetEventDataToolStripMenuItem
            // 
            this.resetEventDataToolStripMenuItem.Name = "resetEventDataToolStripMenuItem";
            this.resetEventDataToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.resetEventDataToolStripMenuItem.Text = "Reset event fields";
            this.resetEventDataToolStripMenuItem.Click += new System.EventHandler(this.resetEventDataToolStripMenuItem_Click);
            // 
            // resetExitDataToolStripMenuItem
            // 
            this.resetExitDataToolStripMenuItem.Name = "resetExitDataToolStripMenuItem";
            this.resetExitDataToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.resetExitDataToolStripMenuItem.Text = "Reset exit fields";
            this.resetExitDataToolStripMenuItem.Click += new System.EventHandler(this.resetExitDataToolStripMenuItem_Click);
            // 
            // resetOverlapDataToolStripMenuItem
            // 
            this.resetOverlapDataToolStripMenuItem.Name = "resetOverlapDataToolStripMenuItem";
            this.resetOverlapDataToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.resetOverlapDataToolStripMenuItem.Text = "Reset overlaps";
            this.resetOverlapDataToolStripMenuItem.Click += new System.EventHandler(this.resetOverlapDataToolStripMenuItem_Click);
            // 
            // resetTilemapModsToolStripMenuItem
            // 
            this.resetTilemapModsToolStripMenuItem.Name = "resetTilemapModsToolStripMenuItem";
            this.resetTilemapModsToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.resetTilemapModsToolStripMenuItem.Text = "Reset tilemap mods";
            this.resetTilemapModsToolStripMenuItem.Click += new System.EventHandler(this.resetTilemapModsToolStripMenuItem_Click);
            // 
            // resetSolidityModsToolStripMenuItem
            // 
            this.resetSolidityModsToolStripMenuItem.Name = "resetSolidityModsToolStripMenuItem";
            this.resetSolidityModsToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.resetSolidityModsToolStripMenuItem.Text = "Reset solidity mods";
            this.resetSolidityModsToolStripMenuItem.Click += new System.EventHandler(this.resetSolidityModsToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(172, 6);
            // 
            // resetPaletteSetToolStripMenuItem
            // 
            this.resetPaletteSetToolStripMenuItem.Name = "resetPaletteSetToolStripMenuItem";
            this.resetPaletteSetToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.resetPaletteSetToolStripMenuItem.Text = "Reset palette set";
            this.resetPaletteSetToolStripMenuItem.Click += new System.EventHandler(this.resetPaletteSetToolStripMenuItem_Click);
            // 
            // resetGraphicSetToolStripMenuItem
            // 
            this.resetGraphicSetToolStripMenuItem.Name = "resetGraphicSetToolStripMenuItem";
            this.resetGraphicSetToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.resetGraphicSetToolStripMenuItem.Text = "Reset graphic set";
            this.resetGraphicSetToolStripMenuItem.Click += new System.EventHandler(this.resetGraphicSetToolStripMenuItem_Click);
            // 
            // resetTilesetsToolStripMenuItem
            // 
            this.resetTilesetsToolStripMenuItem.Name = "resetTilesetsToolStripMenuItem";
            this.resetTilesetsToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.resetTilesetsToolStripMenuItem.Text = "Reset tilesets";
            this.resetTilesetsToolStripMenuItem.Click += new System.EventHandler(this.resetTilesetsToolStripMenuItem_Click);
            // 
            // resetTilemapsToolStripMenuItem
            // 
            this.resetTilemapsToolStripMenuItem.Name = "resetTilemapsToolStripMenuItem";
            this.resetTilemapsToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.resetTilemapsToolStripMenuItem.Text = "Reset tilemaps";
            this.resetTilemapsToolStripMenuItem.Click += new System.EventHandler(this.resetTilemapsToolStripMenuItem_Click);
            // 
            // resetSolidityMapToolStripMenuItem
            // 
            this.resetSolidityMapToolStripMenuItem.Name = "resetSolidityMapToolStripMenuItem";
            this.resetSolidityMapToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.resetSolidityMapToolStripMenuItem.Text = "Reset solidity map";
            this.resetSolidityMapToolStripMenuItem.Click += new System.EventHandler(this.resetSolidityMapToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(172, 6);
            // 
            // resetAllComponentsToolStripMenuItem
            // 
            this.resetAllComponentsToolStripMenuItem.Name = "resetAllComponentsToolStripMenuItem";
            this.resetAllComponentsToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.resetAllComponentsToolStripMenuItem.Text = "Reset all components";
            this.resetAllComponentsToolStripMenuItem.Click += new System.EventHandler(this.resetAllComponentsToolStripMenuItem_Click);
            // 
            // clear
            // 
            this.clear.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearLevelDataAll,
            this.toolStripSeparator38,
            this.clearTilesetsAll,
            this.clearTilemapsAll,
            this.clearPhysicalMapsAll,
            this.toolStripSeparator29,
            this.unusedGraphicSetsToolStripMenuItem,
            this.unusedToolStripMenuItem,
            this.unusedToolStripMenuItem1,
            this.unusedToolStripMenuItem2,
            this.unusedToolStripMenuItem3,
            this.toolStripSeparator8,
            this.clearAllComponentsAll,
            this.clearAllComponentsCurrent});
            this.clear.Image = global::LAZYSHELL.Properties.Resources.clear_small;
            this.clear.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.clear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.clear.Name = "clear";
            this.clear.Size = new System.Drawing.Size(26, 22);
            this.clear.ToolTipText = "Clear";
            // 
            // clearLevelDataAll
            // 
            this.clearLevelDataAll.Name = "clearLevelDataAll";
            this.clearLevelDataAll.Size = new System.Drawing.Size(207, 22);
            this.clearLevelDataAll.Text = "Level Data...";
            this.clearLevelDataAll.Click += new System.EventHandler(this.clearLevelDataAll_Click);
            // 
            // toolStripSeparator38
            // 
            this.toolStripSeparator38.Name = "toolStripSeparator38";
            this.toolStripSeparator38.Size = new System.Drawing.Size(204, 6);
            // 
            // clearTilesetsAll
            // 
            this.clearTilesetsAll.Name = "clearTilesetsAll";
            this.clearTilesetsAll.Size = new System.Drawing.Size(207, 22);
            this.clearTilesetsAll.Text = "Tilesets...";
            this.clearTilesetsAll.Click += new System.EventHandler(this.clearTilesetsAll_Click);
            // 
            // clearTilemapsAll
            // 
            this.clearTilemapsAll.Name = "clearTilemapsAll";
            this.clearTilemapsAll.Size = new System.Drawing.Size(207, 22);
            this.clearTilemapsAll.Text = "Tilemaps...";
            this.clearTilemapsAll.Click += new System.EventHandler(this.clearTilemapsAll_Click);
            // 
            // clearPhysicalMapsAll
            // 
            this.clearPhysicalMapsAll.Name = "clearPhysicalMapsAll";
            this.clearPhysicalMapsAll.Size = new System.Drawing.Size(207, 22);
            this.clearPhysicalMapsAll.Text = "Solidity Maps...";
            this.clearPhysicalMapsAll.Click += new System.EventHandler(this.clearPhysicalMapsAll_Click);
            // 
            // toolStripSeparator29
            // 
            this.toolStripSeparator29.Name = "toolStripSeparator29";
            this.toolStripSeparator29.Size = new System.Drawing.Size(204, 6);
            // 
            // unusedGraphicSetsToolStripMenuItem
            // 
            this.unusedGraphicSetsToolStripMenuItem.Name = "unusedGraphicSetsToolStripMenuItem";
            this.unusedGraphicSetsToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.unusedGraphicSetsToolStripMenuItem.Text = "Unused graphic sets...";
            this.unusedGraphicSetsToolStripMenuItem.Click += new System.EventHandler(this.unusedGraphicSetsToolStripMenuItem_Click);
            // 
            // unusedToolStripMenuItem
            // 
            this.unusedToolStripMenuItem.Name = "unusedToolStripMenuItem";
            this.unusedToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.unusedToolStripMenuItem.Text = "Unused tilesets...";
            this.unusedToolStripMenuItem.Click += new System.EventHandler(this.unusedToolStripMenuItem_Click);
            // 
            // unusedToolStripMenuItem1
            // 
            this.unusedToolStripMenuItem1.Name = "unusedToolStripMenuItem1";
            this.unusedToolStripMenuItem1.Size = new System.Drawing.Size(207, 22);
            this.unusedToolStripMenuItem1.Text = "Unused tilemaps...";
            this.unusedToolStripMenuItem1.Click += new System.EventHandler(this.unusedToolStripMenuItem1_Click);
            // 
            // unusedToolStripMenuItem2
            // 
            this.unusedToolStripMenuItem2.Name = "unusedToolStripMenuItem2";
            this.unusedToolStripMenuItem2.Size = new System.Drawing.Size(207, 22);
            this.unusedToolStripMenuItem2.Text = "Unused solidity maps...";
            this.unusedToolStripMenuItem2.Click += new System.EventHandler(this.unusedToolStripMenuItem2_Click);
            // 
            // unusedToolStripMenuItem3
            // 
            this.unusedToolStripMenuItem3.Name = "unusedToolStripMenuItem3";
            this.unusedToolStripMenuItem3.Size = new System.Drawing.Size(207, 22);
            this.unusedToolStripMenuItem3.Text = "Unused (all components)...";
            this.unusedToolStripMenuItem3.Click += new System.EventHandler(this.unusedToolStripMenuItem3_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(204, 6);
            // 
            // clearAllComponentsAll
            // 
            this.clearAllComponentsAll.Name = "clearAllComponentsAll";
            this.clearAllComponentsAll.Size = new System.Drawing.Size(207, 22);
            this.clearAllComponentsAll.Text = "All Components (all)...";
            this.clearAllComponentsAll.Click += new System.EventHandler(this.clearAllComponentsAll_Click);
            // 
            // clearAllComponentsCurrent
            // 
            this.clearAllComponentsCurrent.Name = "clearAllComponentsCurrent";
            this.clearAllComponentsCurrent.Size = new System.Drawing.Size(207, 22);
            this.clearAllComponentsCurrent.Text = "All Components (current)...";
            this.clearAllComponentsCurrent.Click += new System.EventHandler(this.clearAllComponentsCurrent_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripDropDownButton2
            // 
            this.toolStripDropDownButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.levelInfo});
            this.toolStripDropDownButton2.Image = global::LAZYSHELL.Properties.Resources.about_small;
            this.toolStripDropDownButton2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
            this.toolStripDropDownButton2.Size = new System.Drawing.Size(27, 22);
            this.toolStripDropDownButton2.ToolTipText = "Level info";
            // 
            // levelInfo
            // 
            this.levelInfo.AutoSize = false;
            this.levelInfo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            new ColumnHeader(),
            new ColumnHeader()});
            this.levelInfo.Name = "levelInfo";
            this.levelInfo.Size = new System.Drawing.Size(140, 160);
            this.levelInfo.View = System.Windows.Forms.View.Details;
            // 
            // help
            // 
            this.help.CheckOnClick = true;
            this.help.Image = global::LAZYSHELL.Properties.Resources.help_small;
            this.help.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.help.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.help.Name = "help";
            this.help.Size = new System.Drawing.Size(23, 22);
            this.help.ToolTipText = "Help Tips";
            // 
            // baseConversion
            // 
            this.baseConversion.CheckOnClick = true;
            this.baseConversion.Image = global::LAZYSHELL.Properties.Resources.baseConversion;
            this.baseConversion.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.baseConversion.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.baseConversion.Name = "baseConversion";
            this.baseConversion.Size = new System.Drawing.Size(23, 22);
            this.baseConversion.ToolTipText = "Base Conversion";
            // 
            // toolStripSeparator15
            // 
            this.toolStripSeparator15.Name = "toolStripSeparator15";
            this.toolStripSeparator15.Size = new System.Drawing.Size(6, 25);
            // 
            // tileModsBytesLeft
            // 
            this.tileModsBytesLeft.BackColor = System.Drawing.SystemColors.Control;
            this.tileModsBytesLeft.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tileModsBytesLeft.Dock = System.Windows.Forms.DockStyle.Top;
            this.tileModsBytesLeft.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tileModsBytesLeft.Location = new System.Drawing.Point(125, 44);
            this.tileModsBytesLeft.Name = "tileModsBytesLeft";
            this.tileModsBytesLeft.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.tileModsBytesLeft.Size = new System.Drawing.Size(135, 21);
            this.tileModsBytesLeft.TabIndex = 500;
            this.tileModsBytesLeft.Text = "bytes left";
            this.tileModsBytesLeft.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // solidModsBytesLeft
            // 
            this.solidModsBytesLeft.BackColor = System.Drawing.SystemColors.Control;
            this.solidModsBytesLeft.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.solidModsBytesLeft.Dock = System.Windows.Forms.DockStyle.Top;
            this.solidModsBytesLeft.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.solidModsBytesLeft.Location = new System.Drawing.Point(125, 44);
            this.solidModsBytesLeft.Name = "solidModsBytesLeft";
            this.solidModsBytesLeft.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.solidModsBytesLeft.Size = new System.Drawing.Size(135, 21);
            this.solidModsBytesLeft.TabIndex = 501;
            this.solidModsBytesLeft.Text = "bytes left";
            this.solidModsBytesLeft.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Levels
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1020, 720);
            this.Controls.Add(this.panelLevels);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.toolStrip2);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Location = new System.Drawing.Point(5, 5);
            this.Name = "Levels";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "LEVELS - Lazy Shell";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Levels_FormClosed);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Levels_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Levels_KeyDown);
            this.tabPage8.ResumeLayout(false);
            this.tabPage8.PerformLayout();
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            this.panel85.ResumeLayout(false);
            this.panel118.ResumeLayout(false);
            this.panel119.ResumeLayout(false);
            this.panel83.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.npcID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.npcMovement)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.npcSpeedPlus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.npcEventORPack)).EndInit();
            this.panel43.ResumeLayout(false);
            this.panel53.ResumeLayout(false);
            this.panel80.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.npcMapHeader)).EndInit();
            this.panel84.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.npcX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.npcY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.npcZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.npcPropertyA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.npcPropertyB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.npcPropertyC)).EndInit();
            this.panel42.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mapNum)).EndInit();
            this.contextMenuStrip4.ResumeLayout(false);
            this.tabPage10.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip4.ResumeLayout(false);
            this.toolStrip4.PerformLayout();
            this.panel99.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.overlapType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.overlapX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.overlapY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.overlapZ)).EndInit();
            this.panelOverlapTileset.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOverlaps)).EndInit();
            this.tabPage9.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel90.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.eventLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eventY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eventX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eventZ)).EndInit();
            this.panel46.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.eventHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eventEvent)).EndInit();
            this.toolStrip6.ResumeLayout(false);
            this.toolStrip6.PerformLayout();
            this.panel52.ResumeLayout(false);
            this.panel52.PerformLayout();
            this.panel88.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.exitDestY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exitDestX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exitDestZ)).EndInit();
            this.panel48.ResumeLayout(false);
            this.panel87.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.exitLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exitZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exitY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exitX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exitHeight)).EndInit();
            this.panel49.ResumeLayout(false);
            this.panel50.ResumeLayout(false);
            this.panel51.ResumeLayout(false);
            this.toolStrip5.ResumeLayout(false);
            this.toolStrip5.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.panel70.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mapTilemapL1Num)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mapTilemapL2Num)).EndInit();
            this.panel35.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mapTilemapL3Num)).EndInit();
            this.panel36.ResumeLayout(false);
            this.panel37.ResumeLayout(false);
            this.panel38.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mapPhysicalMapNum)).EndInit();
            this.panel39.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mapBattlefieldNum)).EndInit();
            this.panel69.ResumeLayout(false);
            this.panel40.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mapPaletteSetNum)).EndInit();
            this.panel71.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mapTilesetL3Num)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mapTilesetL2Num)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mapTilesetL1Num)).EndInit();
            this.panel32.ResumeLayout(false);
            this.panel33.ResumeLayout(false);
            this.panel34.ResumeLayout(false);
            this.panel72.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mapGFXSet1Num)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mapGFXSet2Num)).EndInit();
            this.panel31.ResumeLayout(false);
            this.panel29.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mapGFXSet3Num)).EndInit();
            this.panel12.ResumeLayout(false);
            this.panel30.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mapGFXSet4Num)).EndInit();
            this.panel13.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mapGFXSetL3Num)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mapGFXSet5Num)).EndInit();
            this.panel11.ResumeLayout(false);
            this.panel28.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.panel79.ResumeLayout(false);
            this.panel22.ResumeLayout(false);
            this.panel26.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel73.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layerPrioritySet)).EndInit();
            this.panel17.ResumeLayout(false);
            this.panel14.ResumeLayout(false);
            this.panel78.ResumeLayout(false);
            this.panel21.ResumeLayout(false);
            this.panel23.ResumeLayout(false);
            this.panel24.ResumeLayout(false);
            this.panel25.ResumeLayout(false);
            this.panel74.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layerMaskHighX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layerMaskLowX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layerMaskHighY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layerMaskLowY)).EndInit();
            this.panel77.ResumeLayout(false);
            this.panel16.ResumeLayout(false);
            this.panel19.ResumeLayout(false);
            this.panel18.ResumeLayout(false);
            this.panel20.ResumeLayout(false);
            this.panel75.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layerL2LeftShift)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layerL2UpShift)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layerL3LeftShift)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layerL3UpShift)).EndInit();
            this.panel76.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel15.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tileModsY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tileModsX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tileModsHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tileModsWidth)).EndInit();
            this.toolStrip7.ResumeLayout(false);
            this.toolStrip7.PerformLayout();
            this.panel27.ResumeLayout(false);
            this.panel27.PerformLayout();
            this.panel44.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.solidModsY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.solidModsX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.solidModsHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.solidModsWidth)).EndInit();
            this.toolStrip8.ResumeLayout(false);
            this.toolStrip8.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panelLevels.ResumeLayout(false);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button buttonGotoA;
        private Button buttonGotoB;
        private Button buttonGotoD;
        private CheckBox checkBox15;
        private CheckBox checkBox16;
        private CheckBox eventsWidthXPlusHalf;
        private CheckBox eventsWidthYPlusHalf;
        private CheckBox exits135LengthPlusHalf;
        private CheckBox exits45LengthPlusHalf;
        private CheckBox exitsShowMessage;
        private CheckBox layerColorMathBG;
        private CheckBox layerColorMathL1;
        private CheckBox layerColorMathL2;
        private CheckBox layerColorMathL3;
        private CheckBox layerColorMathNPC;
        private CheckBox layerInfiniteAutoscroll;
        private CheckBox layerL2ScrollShift;
        private CheckBox layerL3ScrollShift;
        private CheckBox layerLockMask;
        private CheckBox layerMainscreenL1;
        private CheckBox layerMainscreenL2;
        private CheckBox layerMainscreenL3;
        private CheckBox layerMainscreenNPC;
        private CheckBox layerSubscreenL1;
        private CheckBox layerSubscreenL2;
        private CheckBox layerSubscreenL3;
        private CheckBox layerSubscreenNPC;
        private CheckBox layerWaveEffect;
        private CheckBox mapSetL3Priority;
        private CheckBox marioZCoordPlusHalf;
        private CheckBox npcVisible;
        private CheckBox npcZ_half;
        private CheckBox overlapCoordZPlusHalf;
        private CheckedListBox layerScrollWrapping;
        private CheckedListBox npcAttributes;
        private CheckedListBox overlapUnknownBits;
        private ComboBox eventFace;
        private ComboBox exitDest;
        private ComboBox exitFace;
        private ComboBox exitDestFace;
        private ComboBox exitType;
        private ComboBox layerColorMathIntensity;
        private ComboBox layerColorMathMode;
        private ComboBox layerL2HSync;
        private ComboBox layerL2ScrollDirection;
        private ComboBox layerL2ScrollSpeed;
        private ComboBox layerL2VSync;
        private ComboBox layerL3Effects;
        private ComboBox layerL3HSync;
        private ComboBox layerL3ScrollDirection;
        private ComboBox layerL3ScrollSpeed;
        private ComboBox layerL3VSync;
        private ComboBox layerMessageBox;
        private ComboBox layerOBJEffects;
        private ComboBox mapBattlefieldName;
        private ComboBox mapGFXSet1Name;
        private ComboBox mapGFXSet2Name;
        private ComboBox mapGFXSet3Name;
        private ComboBox mapGFXSet4Name;
        private ComboBox mapGFXSet5Name;
        private ComboBox mapGFXSetL3Name;
        private ComboBox mapPaletteSetName;
        private ComboBox mapPhysicalMapName;
        private ComboBox mapTilemapL1Name;
        private ComboBox mapTilemapL2Name;
        private ComboBox mapTilemapL3Name;
        private ComboBox mapTilesetL1Name;
        private ComboBox mapTilesetL2Name;
        private ComboBox mapTilesetL3Name;
        private ComboBox npcAfterBattle;
        private ComboBox npcEngageTrigger;
        private ComboBox npcEngageType;
        private ComboBox npcFace;
        private ContextMenuStrip contextMenuStrip4;
        private Label labeasdfasd;
        private Label label10;
        private Label label103;
        private Label label104;
        private Label label105;
        private Label label107;
        private Label label109;
        private Label label11;
        private Label label110;
        private Label label114;
        private Label label116;
        private Label label117;
        private Label label119;
        private Label label12;
        private Label label120;
        private Label label122;
        private Label label124;
        private Label label127;
        private Label label129;
        private Label label13;
        private Label label131;
        private Label label133;
        private Label label135;
        private Label label137;
        private Label label15;
        private Label label16;
        private Label label17;
        private Label label18;
        private Label label19;
        private Label label2;
        private Label label20;
        private Label label21;
        private Label label22;
        private Label label23;
        private Label label24;
        private Label label25;
        private Label label29;
        private Label label3;
        private Label label30;
        private Label label31;
        private Label label32;
        private Label label33;
        private Label label34;
        private Label label35;
        private Label label37;
        private Label label38;
        private Label label39;
        private Label label4;
        private Label label40;
        private Label label41;
        private Label label42;
        private Label label43;
        private Label label44;
        private Label label45;
        private Label label46;
        private Label label47;
        private Label label48;
        private Label label49;
        private Label label5;
        private Label label52;
        private Label label53;
        private Label label54;
        private Label label55;
        private Label label56;
        private Label label57;
        private Label label58;
        private Label label59;
        private Label label6;
        private Label label60;
        private Label label61;
        private Label label62;
        private Label label63;
        private Label label65;
        private Label label66;
        private Label label7;
        private Label label70;
        private Label label76;
        private Label label8;
        private Label label82;
        private Label label83;
        private Label label84;
        private Label label85;
        private Label label86;
        private Label label87;
        private Label label88;
        private Label label89;
        private Label label9;
        private Label label91;
        private Label label95;
        private Label label96;
        private NumericUpDown eventHeight;
        private NumericUpDown eventLength;
        private NumericUpDown eventX;
        private NumericUpDown eventY;
        private NumericUpDown eventZ;
        private NumericUpDown eventEvent;
        private NumericUpDown exitLength;
        private NumericUpDown exitHeight;
        private NumericUpDown exitDestX;
        private NumericUpDown exitDestY;
        private NumericUpDown exitDestZ;
        private NumericUpDown exitX;
        private NumericUpDown exitY;
        private NumericUpDown exitZ;
        private NumericUpDown layerL2LeftShift;
        private NumericUpDown layerL2UpShift;
        private NumericUpDown layerL3LeftShift;
        private NumericUpDown layerL3UpShift;
        private NumericUpDown layerMaskHighX;
        private NumericUpDown layerMaskHighY;
        private NumericUpDown layerMaskLowX;
        private NumericUpDown layerMaskLowY;
        private NumericUpDown layerPrioritySet;
        private NumericUpDown mapBattlefieldNum;
        private NumericUpDown mapGFXSet1Num;
        private NumericUpDown mapGFXSet2Num;
        private NumericUpDown mapGFXSet3Num;
        private NumericUpDown mapGFXSet4Num;
        private NumericUpDown mapGFXSet5Num;
        private NumericUpDown mapGFXSetL3Num;
        private NumericUpDown mapNum;
        private NumericUpDown mapPaletteSetNum;
        private NumericUpDown mapPhysicalMapNum;
        private NumericUpDown mapTilemapL1Num;
        private NumericUpDown mapTilemapL2Num;
        private NumericUpDown mapTilemapL3Num;
        private NumericUpDown mapTilesetL1Num;
        private NumericUpDown mapTilesetL2Num;
        private NumericUpDown mapTilesetL3Num;
        private NumericUpDown npcEventORPack;
        private NumericUpDown npcID;
        private NumericUpDown npcMapHeader;
        private NumericUpDown npcMovement;
        private NumericUpDown npcPropertyA;
        private NumericUpDown npcPropertyB;
        private NumericUpDown npcPropertyC;
        private NumericUpDown npcSpeedPlus;
        private NumericUpDown npcX;
        private NumericUpDown npcY;
        private NumericUpDown npcZ;
        private NumericUpDown overlapX;
        private NumericUpDown overlapY;
        private NumericUpDown overlapZ;
        private NumericUpDown overlapType;
        private Panel panel11;
        private Panel panel118;
        private Panel panel119;
        private Panel panel12;
        private Panel panel13;
        private Panel panel14;
        private Panel panel16;
        private Panel panel17;
        private Panel panel18;
        private Panel panel19;
        private Panel panel20;
        private Panel panel21;
        private Panel panel22;
        private Panel panel23;
        private Panel panel24;
        private Panel panel25;
        private Panel panel26;
        private Panel panel28;
        private Panel panel29;
        private Panel panel30;
        private Panel panel31;
        private Panel panel32;
        private Panel panel33;
        private Panel panel34;
        private Panel panel35;
        private Panel panel36;
        private Panel panel37;
        private Panel panel38;
        private Panel panel39;
        private Panel panel4;
        private Panel panel40;
        private Panel panel42;
        private Panel panel43;
        private Panel panel46;
        private Panel panel48;
        private Panel panel49;
        private Panel panel50;
        private Panel panel51;
        private Panel panel52;
        private Panel panel53;
        private Panel panel6;
        private Panel panel68;
        private Panel panel69;
        private Panel panel70;
        private Panel panel71;
        private Panel panel72;
        private Panel panel73;
        private Panel panel74;
        private Panel panel75;
        private Panel panel76;
        private Panel panel77;
        private Panel panel78;
        private Panel panel79;
        private Panel panel80;
        private Panel panel83;
        private Panel panel84;
        private Panel panel85;
        private Panel panel86;
        private Panel panel87;
        private Panel panel88;
        private Panel panel90;
        private Panel panel99;
        private TabControl tabControl;
        private TabPage tabPage10;
        private TabPage tabPage3;
        private TabPage tabPage4;
        private TabPage tabPage8;
        private TabPage tabPage9;
        private ToolStrip toolStrip1;
        private ToolStripButton levelPreviewToolStripButton;
        private ToolStripButton openGraphicEditor;
        private ToolStripButton openPaletteEditor;
        private ToolStripButton openTilemap;
        private ToolStripButton openTileset;
        private ToolStripMenuItem addThisLevelToNotesDatabaseToolStripMenuItem;
        private ToolStripMenuItem allToolStripMenuItem;
        private ToolStripMenuItem arraysToolStripMenuItem;
        private ToolStripMenuItem arraysToolStripMenuItem1;
        private ToolStripMenuItem clearAllComponentsAll;
        private ToolStripMenuItem clearAllComponentsCurrent;
        private ToolStripMenuItem clearLevelDataAll;
        private ToolStripMenuItem clearPhysicalMapsAll;
        private ToolStripMenuItem clearTilemapsAll;
        private ToolStripMenuItem clearTilesetsAll;
        private ToolStripMenuItem dumpTextToolStripMenuItem;
        private ToolStripMenuItem exportLevelImagesToolStripMenuItem1;
        private ToolStripMenuItem graphicSetsToolStripMenuItem;
        private ToolStripMenuItem graphicSetsToolStripMenuItem1;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem toolStripMenuItem6;
        private ToolStripMenuItem unusedToolStripMenuItem;
        private ToolStripMenuItem unusedToolStripMenuItem1;
        private ToolStripMenuItem unusedToolStripMenuItem2;
        private ToolStripMenuItem unusedToolStripMenuItem3;
        private ToolStripSeparator toolStripSeparator28;
        private ToolStripSeparator toolStripSeparator29;
        private ToolStripSeparator toolStripSeparator30;
        private ToolStripSeparator toolStripSeparator32;
        private ToolStripSeparator toolStripSeparator38;
        private ToolStripSeparator toolStripSeparator8;
        private ToolTip toolTip1;
        private TreeView eventsList;
        private TreeView exitsFieldTree;
        private TreeView npcObjectTree;
        private TreeView overlapFieldTree;
        private ToolStripButton openSolidTileset;
        private Panel panelOverlapTileset;
        private PictureBox pictureBoxOverlaps;
        private ToolStripButton openTemplates;
        private Panel panel2;
        private Panel panelLevels;
        private System.Windows.Forms.ToolStripComboBox levelName;
        private ToolStripButton changeLevelName;
        private ToolStripButton searchLevelNames;
        private ToolStripTextBox toolStripTextBox1;
        private ToolStripButton toolStripButton1;
        private ToolStripTextBox nameTextBox;
        private ToolStrip toolStrip2;
        private ToolStripButton save;
        private ToolStripDropDownButton import;
        private ToolStripDropDownButton export;
        private ToolStripDropDownButton clear;
        private ToolStripButton spaceAnalyzer;
        private ToolStripButton help;
        private ToolStripButton baseConversion;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton propertiesButton;
        private Label label28;
        private ToolStripNumericUpDown levelNum;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripSeparator toolStripSeparator6;
        private Panel panel1;
        private ToolStrip toolStrip3;
        private ToolStripButton npcMoveUp;
        private ToolStripButton npcMoveDown;
        private ToolStripButton npcCopy;
        private ToolStripButton npcPaste;
        private ToolStripButton npcDuplicate;
        private ToolStripSeparator toolStripSeparator9;
        private ToolStripButton npcInsertObject;
        private ToolStripButton npcRemoveObject;
        private ToolStripButton npcInsertInstance;
        private ToolStripSeparator toolStripSeparator10;
        private ToolStripButton findNPCNum;
        private ToolStripButton openPartitions;
        private ToolStrip toolStrip4;
        private ToolStripButton overlapFieldInsert;
        private ToolStripButton overlapFieldDelete;
        private Label label106;
        private ToolStrip toolStrip6;
        private ToolStripButton eventsDeleteField;
        private ToolStrip toolStrip5;
        private ToolStripButton exitsInsertField;
        private ToolStripButton exitsDeleteField;
        private ToolStripButton eventsInsertField;
        private ToolStripButton eventsCopyField;
        private ToolStripButton eventsPasteField;
        private ToolStripButton eventsDuplicateField;
        private ToolStripButton exitsCopyField;
        private ToolStripButton exitsPasteField;
        private ToolStripButton exitsDuplicateField;
        private ToolStripButton overlapFieldCopy;
        private ToolStripButton overlapFieldPaste;
        private ToolStripButton overlapFieldDuplicate;
        private TabPage tabPage1;
        private Panel panel8;
        private TreeView tileModsFieldTree;
        private ToolStrip toolStrip7;
        private Panel panel15;
        private Label label26;
        private Label label27;
        private NumericUpDown tileModsX;
        private Label label36;
        private Label label50;
        private Panel panel55;
        private Panel panel27;
        private TreeView solidModsFieldTree;
        private ToolStrip toolStrip8;
        private Panel panel44;
        private Label label14;
        private Label label51;
        private Label label64;
        private Label label67;
        private Panel panel45;
        private Label label68;
        private Label label69;
        private NumericUpDown solidModsY;
        private NumericUpDown solidModsX;
        private NumericUpDown solidModsHeight;
        private NumericUpDown solidModsWidth;
        private CheckedListBox tileModsLayers;
        private NumericUpDown tileModsY;
        private NumericUpDown tileModsHeight;
        private NumericUpDown tileModsWidth;
        private ToolStripButton solidModsInsert;
        private ToolStripButton solidModsDelete;
        private ToolStripButton solidModsCopy;
        private ToolStripButton solidModsPaste;
        private ToolStripButton solidModsDuplicate;
        private ToolStripButton tileModsInsertField;
        private ToolStripButton tileModsDeleteField;
        private ToolStripButton tileModsCopy;
        private ToolStripButton tileModsPaste;
        private ToolStripButton tileModsDuplicate;
        private ToolStripButton tileModsInsertInstance;
        private ToolStripSeparator toolStripSeparator11;
        private ToolStripButton tileModsMoveUp;
        private ToolStripButton tileModsMoveDown;
        private ToolStripSeparator toolStripSeparator12;
        private ToolStripSeparator toolStripSeparator13;
        private ToolStripButton solidModsMoveUp;
        private ToolStripButton solidModsMoveDown;
        private ToolStripSeparator toolStripSeparator14;
        private ToolStripSeparator toolStripSeparator16;
        private ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripComboBox eventMusic;
        private ToolStripSeparator toolStripSeparator15;
        private ToolStripButton buttonGotoC;
        private ToolStripNumericUpDown eventExit;
        private Label npcsBytesLeft;
        private ToolStripSeparator toolStripSeparator18;
        private ToolStripLabel overlapsBytesLeft;
        private ToolStripMenuItem unusedGraphicSetsToolStripMenuItem;
        private ToolStripMenuItem importArchitectureToolStripMenuItem;
        private ToolStripMenuItem exportArchitectureToolStripMenuItem;
        private ToolStripButton hexEditor;
        private ToolStripSeparator toolStripSeparator20;
        private ToolStripLabel eventsBytesLeft;
        private ToolStripSeparator toolStripSeparator19;
        private ToolStripLabel exitsBytesLeft;
        private ToolStripSeparator toolStripSeparator7;
        private ToolStripSeparator toolStripSeparator21;
        private ToolStripDropDownButton toolStripDropDownButton1;
        private ToolStripMenuItem resetLevelMapToolStripMenuItem;
        private ToolStripMenuItem resetNPCDataToolStripMenuItem;
        private ToolStripMenuItem resetEventDataToolStripMenuItem;
        private ToolStripMenuItem resetExitDataToolStripMenuItem;
        private ToolStripMenuItem resetOverlapDataToolStripMenuItem;
        private ToolStripMenuItem resetLayerDataToolStripMenuItem;
        private ToolStripMenuItem resetTilemapModsToolStripMenuItem;
        private ToolStripMenuItem resetSolidityModsToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem resetTilesetsToolStripMenuItem;
        private ToolStripMenuItem resetTilemapsToolStripMenuItem;
        private ToolStripMenuItem resetSolidityMapToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripMenuItem resetAllComponentsToolStripMenuItem;
        private ToolStripMenuItem resetPaletteSetToolStripMenuItem;
        private ToolStripMenuItem resetGraphicSetToolStripMenuItem;
        private ToolStripDropDownButton toolStripDropDownButton2;
        private LAZYSHELL.ToolStripListView levelInfo;
        private Label tileModsBytesLeft;
        private Label solidModsBytesLeft;
    }
}

