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
            System.Windows.Forms.ToolStripButton templateImport;
            System.Windows.Forms.ToolStripButton templateExport;
            System.Windows.Forms.ToolStripButton templateDelete;
            System.Windows.Forms.ToolStripButton templateCopy;
            System.Windows.Forms.ToolStripButton templatePaste;
            System.Windows.Forms.Panel panel444;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Levels));
            this.labelBattlefieldTileset = new System.Windows.Forms.Label();
            this.pictureBoxBattlefield = new System.Windows.Forms.PictureBox();
            this.colEditColors = new System.Windows.Forms.CheckedListBox();
            this.panel100 = new System.Windows.Forms.Panel();
            this.colEditComboBoxA = new System.Windows.Forms.ComboBox();
            this.panel101 = new System.Windows.Forms.Panel();
            this.coleditSelectCommand = new System.Windows.Forms.ComboBox();
            this.label139 = new System.Windows.Forms.Label();
            this.colEditLabelA = new System.Windows.Forms.Label();
            this.colEditLabelB = new System.Windows.Forms.Label();
            this.label134 = new System.Windows.Forms.Label();
            this.panel102 = new System.Windows.Forms.Panel();
            this.colEditComboBoxB = new System.Windows.Forms.ComboBox();
            this.label136 = new System.Windows.Forms.Label();
            this.colEditSelectAll = new System.Windows.Forms.Button();
            this.colEditLabelC = new System.Windows.Forms.Label();
            this.colEditValueA = new System.Windows.Forms.NumericUpDown();
            this.colEditReds = new System.Windows.Forms.CheckBox();
            this.colEditGreens = new System.Windows.Forms.CheckBox();
            this.colEditBlues = new System.Windows.Forms.CheckBox();
            this.colEditLabelD = new System.Windows.Forms.Label();
            this.colEditRowSelectAll = new System.Windows.Forms.CheckedListBox();
            this.label143 = new System.Windows.Forms.Label();
            this.colEditApply = new System.Windows.Forms.Button();
            this.colEditReset = new System.Windows.Forms.Button();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel65 = new System.Windows.Forms.Panel();
            this.npcCopy = new System.Windows.Forms.Button();
            this.npcPaste = new System.Windows.Forms.Button();
            this.npcMoveUp = new System.Windows.Forms.Button();
            this.npcMoveDown = new System.Windows.Forms.Button();
            this.panel85 = new System.Windows.Forms.Panel();
            this.npcAttributes = new System.Windows.Forms.CheckedListBox();
            this.label65 = new System.Windows.Forms.Label();
            this.panel84 = new System.Windows.Forms.Panel();
            this.label111 = new System.Windows.Forms.Label();
            this.npcXCoord = new System.Windows.Forms.NumericUpDown();
            this.npcYCoord = new System.Windows.Forms.NumericUpDown();
            this.label29 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.npcZCoord = new System.Windows.Forms.NumericUpDown();
            this.label56 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.npcPropertyA = new System.Windows.Forms.NumericUpDown();
            this.label104 = new System.Windows.Forms.Label();
            this.npcPropertyB = new System.Windows.Forms.NumericUpDown();
            this.label31 = new System.Windows.Forms.Label();
            this.npcPropertyC = new System.Windows.Forms.NumericUpDown();
            this.label116 = new System.Windows.Forms.Label();
            this.npcsZCoordPlusHalf = new System.Windows.Forms.CheckBox();
            this.panel42 = new System.Windows.Forms.Panel();
            this.npcRadialPosition = new System.Windows.Forms.ComboBox();
            this.npcsShowNPC = new System.Windows.Forms.CheckBox();
            this.panel83 = new System.Windows.Forms.Panel();
            this.label71 = new System.Windows.Forms.Label();
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
            this.findNPCNum = new System.Windows.Forms.Button();
            this.panel43 = new System.Windows.Forms.Panel();
            this.npcEngageType = new System.Windows.Forms.ComboBox();
            this.panel53 = new System.Windows.Forms.Panel();
            this.npcEngageTrigger = new System.Windows.Forms.ComboBox();
            this.panel82 = new System.Windows.Forms.Panel();
            this.label115 = new System.Windows.Forms.Label();
            this.npcRemoveInstance = new System.Windows.Forms.Button();
            this.npcInsertInstance = new System.Windows.Forms.Button();
            this.panel81 = new System.Windows.Forms.Panel();
            this.label113 = new System.Windows.Forms.Label();
            this.npcInsertObject = new System.Windows.Forms.Button();
            this.npcRemoveObject = new System.Windows.Forms.Button();
            this.panel80 = new System.Windows.Forms.Panel();
            this.label48 = new System.Windows.Forms.Label();
            this.npcMapHeader = new System.Windows.Forms.NumericUpDown();
            this.openPartitions = new System.Windows.Forms.Button();
            this.panel118 = new System.Windows.Forms.Panel();
            this.label52 = new System.Windows.Forms.Label();
            this.panel119 = new System.Windows.Forms.Panel();
            this.npcAfterBattle = new System.Windows.Forms.ComboBox();
            this.label112 = new System.Windows.Forms.Label();
            this.npcObjectTree = new System.Windows.Forms.TreeView();
            this.label36 = new System.Windows.Forms.Label();
            this.mapNum = new System.Windows.Forms.NumericUpDown();
            this.label33 = new System.Windows.Forms.Label();
            this.levelNum = new System.Windows.Forms.NumericUpDown();
            this.levelName = new System.Windows.Forms.ComboBox();
            this.contextMenuStrip4 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addThisLevelToNotesDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage10 = new System.Windows.Forms.TabPage();
            this.panel8 = new System.Windows.Forms.Panel();
            this.overlapShowTileset = new System.Windows.Forms.Button();
            this.panel99 = new System.Windows.Forms.Panel();
            this.overlapCoordZPlusHalf = new System.Windows.Forms.CheckBox();
            this.label130 = new System.Windows.Forms.Label();
            this.label109 = new System.Windows.Forms.Label();
            this.label103 = new System.Windows.Forms.Label();
            this.label107 = new System.Windows.Forms.Label();
            this.overlapType = new System.Windows.Forms.NumericUpDown();
            this.overlapCoordX = new System.Windows.Forms.NumericUpDown();
            this.overlapCoordY = new System.Windows.Forms.NumericUpDown();
            this.overlapCoordZ = new System.Windows.Forms.NumericUpDown();
            this.label106 = new System.Windows.Forms.Label();
            this.panel62 = new System.Windows.Forms.Panel();
            this.label132 = new System.Windows.Forms.Label();
            this.overlapUnknownBits = new System.Windows.Forms.CheckedListBox();
            this.overlapFieldDelete = new System.Windows.Forms.Button();
            this.overlapFieldInsert = new System.Windows.Forms.Button();
            this.overlapFieldTree = new System.Windows.Forms.TreeView();
            this.label51 = new System.Windows.Forms.Label();
            this.tabPage9 = new System.Windows.Forms.TabPage();
            this.panel52 = new System.Windows.Forms.Panel();
            this.panel90 = new System.Windows.Forms.Panel();
            this.buttonGotoD = new System.Windows.Forms.Button();
            this.label62 = new System.Windows.Forms.Label();
            this.label127 = new System.Windows.Forms.Label();
            this.eventsFieldLength = new System.Windows.Forms.NumericUpDown();
            this.label129 = new System.Windows.Forms.Label();
            this.eventsFieldYCoord = new System.Windows.Forms.NumericUpDown();
            this.eventsWidthYPlusHalf = new System.Windows.Forms.CheckBox();
            this.label131 = new System.Windows.Forms.Label();
            this.eventsWidthXPlusHalf = new System.Windows.Forms.CheckBox();
            this.eventsFieldXCoord = new System.Windows.Forms.NumericUpDown();
            this.eventsLengthOverOne = new System.Windows.Forms.CheckBox();
            this.eventsFieldZCoord = new System.Windows.Forms.NumericUpDown();
            this.panel46 = new System.Windows.Forms.Panel();
            this.eventsFieldRadialPosition = new System.Windows.Forms.ComboBox();
            this.eventsFieldHeight = new System.Windows.Forms.NumericUpDown();
            this.label133 = new System.Windows.Forms.Label();
            this.label135 = new System.Windows.Forms.Label();
            this.label137 = new System.Windows.Forms.Label();
            this.eventsRunEvent = new System.Windows.Forms.NumericUpDown();
            this.panel89 = new System.Windows.Forms.Panel();
            this.buttonGotoC = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label125 = new System.Windows.Forms.Label();
            this.eventsExitEvent = new System.Windows.Forms.NumericUpDown();
            this.panel47 = new System.Windows.Forms.Panel();
            this.eventsAreaMusic = new System.Windows.Forms.ComboBox();
            this.panel88 = new System.Windows.Forms.Panel();
            this.label66 = new System.Windows.Forms.Label();
            this.label59 = new System.Windows.Forms.Label();
            this.exitsMarioYCoord = new System.Windows.Forms.NumericUpDown();
            this.marioZCoordPlusHalf = new System.Windows.Forms.CheckBox();
            this.label60 = new System.Windows.Forms.Label();
            this.exitsMarioXCoord = new System.Windows.Forms.NumericUpDown();
            this.exitsMarioZCoord = new System.Windows.Forms.NumericUpDown();
            this.label122 = new System.Windows.Forms.Label();
            this.label124 = new System.Windows.Forms.Label();
            this.panel48 = new System.Windows.Forms.Panel();
            this.exitsMarioRadialPosition = new System.Windows.Forms.ComboBox();
            this.panel87 = new System.Windows.Forms.Panel();
            this.exitsLengthOverOne = new System.Windows.Forms.CheckBox();
            this.label119 = new System.Windows.Forms.Label();
            this.exits135LengthPlusHalf = new System.Windows.Forms.CheckBox();
            this.label58 = new System.Windows.Forms.Label();
            this.exits45LengthPlusHalf = new System.Windows.Forms.CheckBox();
            this.exitsFieldLength = new System.Windows.Forms.NumericUpDown();
            this.label105 = new System.Windows.Forms.Label();
            this.exitsFieldZCoord = new System.Windows.Forms.NumericUpDown();
            this.exitsFieldYCoord = new System.Windows.Forms.NumericUpDown();
            this.exitsFieldXCoord = new System.Windows.Forms.NumericUpDown();
            this.exitsShowMessage = new System.Windows.Forms.CheckBox();
            this.exitsFieldHeight = new System.Windows.Forms.NumericUpDown();
            this.label37 = new System.Windows.Forms.Label();
            this.label55 = new System.Windows.Forms.Label();
            this.label57 = new System.Windows.Forms.Label();
            this.label120 = new System.Windows.Forms.Label();
            this.panel49 = new System.Windows.Forms.Panel();
            this.exitsFieldRadialPosition = new System.Windows.Forms.ComboBox();
            this.label47 = new System.Windows.Forms.Label();
            this.panel50 = new System.Windows.Forms.Panel();
            this.exitsType = new System.Windows.Forms.ComboBox();
            this.panel51 = new System.Windows.Forms.Panel();
            this.exitsDestination = new System.Windows.Forms.ComboBox();
            this.panel68 = new System.Windows.Forms.Panel();
            this.eventsDeleteField = new System.Windows.Forms.Button();
            this.eventsInsertField = new System.Windows.Forms.Button();
            this.label63 = new System.Windows.Forms.Label();
            this.exitsDeleteField = new System.Windows.Forms.Button();
            this.exitsInsertField = new System.Windows.Forms.Button();
            this.exitsFieldTree = new System.Windows.Forms.TreeView();
            this.eventsFieldTree = new System.Windows.Forms.TreeView();
            this.label61 = new System.Windows.Forms.Label();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.panel66 = new System.Windows.Forms.Panel();
            this.panel67 = new System.Windows.Forms.Panel();
            this.pictureBoxTilesetL2 = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cutToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator27 = new System.Windows.Forms.ToolStripSeparator();
            this.priority1SetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.priority1ClearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator25 = new System.Windows.Forms.ToolStripSeparator();
            this.editToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator41 = new System.Windows.Forms.ToolStripSeparator();
            this.saveImageAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panelPhysicalTile = new System.Windows.Forms.Panel();
            this.pictureBoxPhysicalTile = new System.Windows.Forms.PictureBox();
            this.panel97 = new System.Windows.Forms.Panel();
            this.panel91 = new System.Windows.Forms.Panel();
            this.panel105 = new System.Windows.Forms.Panel();
            this.physicalTileDoorFormat = new System.Windows.Forms.ComboBox();
            this.label93 = new System.Windows.Forms.Label();
            this.physicalTileUnknownBits = new System.Windows.Forms.CheckedListBox();
            this.physicalTileBaseHeight = new System.Windows.Forms.NumericUpDown();
            this.physicalTileOverZCoord = new System.Windows.Forms.NumericUpDown();
            this.physicalTileOverHeight = new System.Windows.Forms.NumericUpDown();
            this.label140 = new System.Windows.Forms.Label();
            this.label92 = new System.Windows.Forms.Label();
            this.physicalTileQuadrant = new System.Windows.Forms.CheckedListBox();
            this.physicalTileWaterZCoord = new System.Windows.Forms.NumericUpDown();
            this.panel55 = new System.Windows.Forms.Panel();
            this.physicalTileSpecialTile = new System.Windows.Forms.ComboBox();
            this.label90 = new System.Windows.Forms.Label();
            this.panel54 = new System.Windows.Forms.Panel();
            this.physicalTileStairs = new System.Windows.Forms.ComboBox();
            this.physicalTileProperties = new System.Windows.Forms.CheckedListBox();
            this.label75 = new System.Windows.Forms.Label();
            this.panel44 = new System.Windows.Forms.Panel();
            this.physicalTileConveyor = new System.Windows.Forms.ComboBox();
            this.physicalTileEdges = new System.Windows.Forms.CheckedListBox();
            this.label68 = new System.Windows.Forms.Label();
            this.label74 = new System.Windows.Forms.Label();
            this.label72 = new System.Windows.Forms.Label();
            this.label73 = new System.Windows.Forms.Label();
            this.physicalTilePriority3 = new System.Windows.Forms.CheckedListBox();
            this.label94 = new System.Windows.Forms.Label();
            this.physicalTileSearchButton = new System.Windows.Forms.Button();
            this.physicalTileNum = new System.Windows.Forms.NumericUpDown();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.panel41 = new System.Windows.Forms.Panel();
            this.panel94 = new System.Windows.Forms.Panel();
            this.pictureBoxTilesetL3 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelColorBalance = new System.Windows.Forms.Panel();
            this.colEditBFPanel = new System.Windows.Forms.Panel();
            this.colEditApplyBF = new System.Windows.Forms.Button();
            this.colEditUndoBF = new System.Windows.Forms.Button();
            this.colEditResetBF = new System.Windows.Forms.Button();
            this.colEditRedoBF = new System.Windows.Forms.Button();
            this.colEditRedo = new System.Windows.Forms.Button();
            this.colEditUndo = new System.Windows.Forms.Button();
            this.panel104 = new System.Windows.Forms.Panel();
            this.panel103 = new System.Windows.Forms.Panel();
            this.label138 = new System.Windows.Forms.Label();
            this.colEditSelectNone = new System.Windows.Forms.Button();
            this.panelOverlapTileset = new System.Windows.Forms.Panel();
            this.pictureBoxOverlaps = new System.Windows.Forms.PictureBox();
            this.changeLevelName = new System.Windows.Forms.Button();
            this.searchLevelNames = new System.Windows.Forms.Button();
            this.panelChangeLevelName = new System.Windows.Forms.Panel();
            this.defaultName = new System.Windows.Forms.Button();
            this.panel98 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panelSearchLevelNames = new System.Windows.Forms.Panel();
            this.panel58 = new System.Windows.Forms.Panel();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.listBoxLevelNames = new System.Windows.Forms.ListBox();
            this.label26 = new System.Windows.Forms.Label();
            this.labelOrthCoords = new System.Windows.Forms.Label();
            this.panel27 = new System.Windows.Forms.Panel();
            this.panelLevelPicture = new System.Windows.Forms.Panel();
            this.pictureBoxLevel = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator20 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator24 = new System.Windows.Forms.ToolStripSeparator();
            this.saveImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.areaPropertiesPanel = new System.Windows.Forms.Panel();
            this.Priorities = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel79 = new System.Windows.Forms.Panel();
            this.label110 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.panel22 = new System.Windows.Forms.Panel();
            this.layerL3Effects = new System.Windows.Forms.ComboBox();
            this.panel26 = new System.Windows.Forms.Panel();
            this.layerOBJEffects = new System.Windows.Forms.ComboBox();
            this.layerWaveEffect = new System.Windows.Forms.CheckBox();
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
            this.panel76 = new System.Windows.Forms.Panel();
            this.label91 = new System.Windows.Forms.Label();
            this.layerScrollWrapping = new System.Windows.Forms.CheckedListBox();
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
            this.panel64 = new System.Windows.Forms.Panel();
            this.label53 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.layerMessageBox = new System.Windows.Forms.ComboBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.panel28 = new System.Windows.Forms.Panel();
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
            this.colorBalance = new System.Windows.Forms.Button();
            this.paletteUpdate = new System.Windows.Forms.Button();
            this.palettePictureBox = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip3 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.importPaletteSetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportPaletteSetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.paletteAutoUpdate = new System.Windows.Forms.CheckBox();
            this.mapPaletteRedNum = new System.Windows.Forms.NumericUpDown();
            this.label79 = new System.Windows.Forms.Label();
            this.panel40 = new System.Windows.Forms.Panel();
            this.mapPaletteSetName = new System.Windows.Forms.ComboBox();
            this.mapPaletteGreenNum = new System.Windows.Forms.NumericUpDown();
            this.label80 = new System.Windows.Forms.Label();
            this.mapPaletteBlueNum = new System.Windows.Forms.NumericUpDown();
            this.mapPaletteGreenBar = new System.Windows.Forms.TrackBar();
            this.label81 = new System.Windows.Forms.Label();
            this.mapPaletteSetNum = new System.Windows.Forms.NumericUpDown();
            this.label46 = new System.Windows.Forms.Label();
            this.mapPaletteRedBar = new System.Windows.Forms.TrackBar();
            this.mapPaletteBlueBar = new System.Windows.Forms.TrackBar();
            this.pictureBoxColor = new System.Windows.Forms.PictureBox();
            this.panel63 = new System.Windows.Forms.Panel();
            this.labelTileCoords = new System.Windows.Forms.Label();
            this.labelPixelCoords = new System.Windows.Forms.Label();
            this.panelTemplates = new System.Windows.Forms.Panel();
            this.templatesLoaded = new System.Windows.Forms.ListBox();
            this.panel114 = new System.Windows.Forms.Panel();
            this.pictureBoxTemplate = new System.Windows.Forms.PictureBox();
            this.panel115 = new System.Windows.Forms.Panel();
            this.templateRenameText = new System.Windows.Forms.TextBox();
            this.templateRename = new System.Windows.Forms.Button();
            this.labelTemplates = new System.Windows.Forms.Label();
            this.panelTemplatesSub = new System.Windows.Forms.Panel();
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator44 = new System.Windows.Forms.ToolStripSeparator();
            this.templateTransfer = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator45 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator43 = new System.Windows.Forms.ToolStripSeparator();
            this.panelTilesets = new System.Windows.Forms.Panel();
            this.labelTilesets = new System.Windows.Forms.Label();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel95 = new System.Windows.Forms.Panel();
            this.panel96 = new System.Windows.Forms.Panel();
            this.pictureBoxTilesetL1 = new System.Windows.Forms.PictureBox();
            this.tabPage12 = new System.Windows.Forms.TabPage();
            this.panelBattlefields = new System.Windows.Forms.Panel();
            this.panelBattlefieldTileset = new System.Windows.Forms.Panel();
            this.panelBattlefieldPalettes = new System.Windows.Forms.Panel();
            this.panel93 = new System.Windows.Forms.Panel();
            this.colorBalanceBF = new System.Windows.Forms.Button();
            this.labelBattlefieldPalettes = new System.Windows.Forms.Label();
            this.battlefieldPaletteSetNum = new System.Windows.Forms.NumericUpDown();
            this.label102 = new System.Windows.Forms.Label();
            this.bfPaletteGreenBar = new System.Windows.Forms.TrackBar();
            this.panel60 = new System.Windows.Forms.Panel();
            this.battlefieldPaletteSetName = new System.Windows.Forms.ComboBox();
            this.bfPaletteBlueBar = new System.Windows.Forms.TrackBar();
            this.bfPalettePictureBox = new System.Windows.Forms.PictureBox();
            this.bfPaletteRedBar = new System.Windows.Forms.TrackBar();
            this.bfPaletteRedNum = new System.Windows.Forms.NumericUpDown();
            this.label123 = new System.Windows.Forms.Label();
            this.label77 = new System.Windows.Forms.Label();
            this.bfPaletteBlueNum = new System.Windows.Forms.NumericUpDown();
            this.label78 = new System.Windows.Forms.Label();
            this.bfPaletteGreenNum = new System.Windows.Forms.NumericUpDown();
            this.pictureBoxColorBF = new System.Windows.Forms.PictureBox();
            this.panelBattlefieldProperties = new System.Windows.Forms.Panel();
            this.panel92 = new System.Windows.Forms.Panel();
            this.labelBattlefieldProperties = new System.Windows.Forms.Label();
            this.label97 = new System.Windows.Forms.Label();
            this.battlefieldGFXSet4Num = new System.Windows.Forms.NumericUpDown();
            this.battlefieldGFXSet5Num = new System.Windows.Forms.NumericUpDown();
            this.label98 = new System.Windows.Forms.Label();
            this.battlefieldGFXSet3Num = new System.Windows.Forms.NumericUpDown();
            this.panel57 = new System.Windows.Forms.Panel();
            this.battlefieldGFXSet1Name = new System.Windows.Forms.ComboBox();
            this.label99 = new System.Windows.Forms.Label();
            this.panel56 = new System.Windows.Forms.Panel();
            this.battlefieldGFXSet3Name = new System.Windows.Forms.ComboBox();
            this.battlefieldGFXSet2Num = new System.Windows.Forms.NumericUpDown();
            this.panel7 = new System.Windows.Forms.Panel();
            this.battlefieldGFXSet5Name = new System.Windows.Forms.ComboBox();
            this.label100 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.battlefieldGFXSet2Name = new System.Windows.Forms.ComboBox();
            this.battlefieldGFXSet1Num = new System.Windows.Forms.NumericUpDown();
            this.panel2 = new System.Windows.Forms.Panel();
            this.battlefieldGFXSet4Name = new System.Windows.Forms.ComboBox();
            this.label69 = new System.Windows.Forms.Label();
            this.battlefieldTilesetNum = new System.Windows.Forms.NumericUpDown();
            this.label101 = new System.Windows.Forms.Label();
            this.panel59 = new System.Windows.Forms.Panel();
            this.battlefieldTilesetName = new System.Windows.Forms.ComboBox();
            this.panel45 = new System.Windows.Forms.Panel();
            this.labelBattlefields = new System.Windows.Forms.Label();
            this.panel61 = new System.Windows.Forms.Panel();
            this.battlefieldName = new System.Windows.Forms.ComboBox();
            this.battlefieldNum = new System.Windows.Forms.NumericUpDown();
            this.panelLevelZoom = new System.Windows.Forms.Panel();
            this.panel117 = new System.Windows.Forms.Panel();
            this.pictureBoxLevelZoom = new System.Windows.Forms.PictureBox();
            this.contextMenuStripTE = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.setSubtileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator35 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveImageToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator36 = new System.Windows.Forms.ToolStripSeparator();
            this.clearToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.applyBorderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelTileEditor = new System.Windows.Forms.Panel();
            this.labelTileEditor = new System.Windows.Forms.Label();
            this.panel106 = new System.Windows.Forms.Panel();
            this.panel107 = new System.Windows.Forms.Panel();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.panelImageGraphics = new System.Windows.Forms.Panel();
            this.panel108 = new System.Windows.Forms.Panel();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator31 = new System.Windows.Forms.ToolStripSeparator();
            this.graphicShowGrid = new System.Windows.Forms.ToolStripButton();
            this.graphicShowPixelGrid = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator33 = new System.Windows.Forms.ToolStripSeparator();
            this.subtileDraw = new System.Windows.Forms.ToolStripButton();
            this.subtileErase = new System.Windows.Forms.ToolStripButton();
            this.subtileDropper = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator34 = new System.Windows.Forms.ToolStripSeparator();
            this.graphicZoomIn = new System.Windows.Forms.ToolStripButton();
            this.graphicZoomOut = new System.Windows.Forms.ToolStripButton();
            this.panel109 = new System.Windows.Forms.Panel();
            this.pictureBoxGraphicSet = new System.Windows.Forms.PictureBox();
            this.labelImageGraphics = new System.Windows.Forms.Label();
            this.panel110 = new System.Windows.Forms.Panel();
            this.pictureBoxPalette = new System.Windows.Forms.PictureBox();
            this.label50 = new System.Windows.Forms.Label();
            this.panel111 = new System.Windows.Forms.Panel();
            this.showGrid = new System.Windows.Forms.CheckBox();
            this.panel112 = new System.Windows.Forms.Panel();
            this.pictureBoxSubtile = new System.Windows.Forms.PictureBox();
            this.pictureBoxTile = new System.Windows.Forms.PictureBox();
            this.panel113 = new System.Windows.Forms.Panel();
            this.label141 = new System.Windows.Forms.Label();
            this.tilePalette = new System.Windows.Forms.NumericUpDown();
            this.tileGFXSet = new System.Windows.Forms.NumericUpDown();
            this.tile8x8Tile = new System.Windows.Forms.NumericUpDown();
            this.label142 = new System.Windows.Forms.Label();
            this.label144 = new System.Windows.Forms.Label();
            this.tileAttributes = new System.Windows.Forms.CheckedListBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator30 = new System.Windows.Forms.ToolStripSeparator();
            this.arraysToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.graphicSetsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator28 = new System.Windows.Forms.ToolStripSeparator();
            this.arraysToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.graphicSetsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportLevelImagesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator32 = new System.Windows.Forms.ToolStripSeparator();
            this.dumpTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearLevelDataAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator38 = new System.Windows.Forms.ToolStripSeparator();
            this.clearTilesetsAll = new System.Windows.Forms.ToolStripMenuItem();
            this.clearTilemapsAll = new System.Windows.Forms.ToolStripMenuItem();
            this.clearPhysicalMapsAll = new System.Windows.Forms.ToolStripMenuItem();
            this.clearBattlefieldsAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator29 = new System.Windows.Forms.ToolStripSeparator();
            this.unusedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unusedToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.unusedToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.unusedToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.clearAllComponentsAll = new System.Windows.Forms.ToolStripMenuItem();
            this.clearAllComponentsCurrent = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator21 = new System.Windows.Forms.ToolStripSeparator();
            this.SpaceAnalyzerMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator22 = new System.Windows.Forms.ToolStripSeparator();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearSelectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.replaceTilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator37 = new System.Windows.Forms.ToolStripSeparator();
            this.editAllLayersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cartesianGridToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.orthographicGridToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.maskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.layer1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.layer2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.layer3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.priority1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.physicalMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.npcsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitFieldsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eventFieldsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enableHelpTipsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showDecHexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator18 = new System.Windows.Forms.ToolStripSeparator();
            this.buttonToggleProperties = new System.Windows.Forms.ToolStripButton();
            this.buttonToggleTileEditor = new System.Windows.Forms.ToolStripButton();
            this.buttonToggleTemplates = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator17 = new System.Windows.Forms.ToolStripSeparator();
            this.buttonToggleCartGrid = new System.Windows.Forms.ToolStripButton();
            this.buttonToggleOrthGrid = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator16 = new System.Windows.Forms.ToolStripSeparator();
            this.buttonToggleMask = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator15 = new System.Windows.Forms.ToolStripSeparator();
            this.buttonToggleL1 = new System.Windows.Forms.ToolStripButton();
            this.buttonToggleL2 = new System.Windows.Forms.ToolStripButton();
            this.buttonToggleL3 = new System.Windows.Forms.ToolStripButton();
            this.buttonToggleBG = new System.Windows.Forms.ToolStripButton();
            this.buttonToggleP1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator14 = new System.Windows.Forms.ToolStripSeparator();
            this.buttonTogglePhys = new System.Windows.Forms.ToolStripButton();
            this.buttonToggleNPCs = new System.Windows.Forms.ToolStripButton();
            this.buttonToggleExits = new System.Windows.Forms.ToolStripButton();
            this.buttonToggleEvents = new System.Windows.Forms.ToolStripButton();
            this.buttonToggleOverlaps = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator19 = new System.Windows.Forms.ToolStripSeparator();
            this.buttonEditTemplate = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator46 = new System.Windows.Forms.ToolStripSeparator();
            this.buttonEditDraw = new System.Windows.Forms.ToolStripButton();
            this.buttonEditErase = new System.Windows.Forms.ToolStripButton();
            this.buttonEditSelect = new System.Windows.Forms.ToolStripButton();
            this.buttonEditDropper = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.buttonEditDelete = new System.Windows.Forms.ToolStripButton();
            this.buttonEditCut = new System.Windows.Forms.ToolStripButton();
            this.buttonEditCopy = new System.Windows.Forms.ToolStripButton();
            this.buttonEditPaste = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.buttonEditUndo = new System.Windows.Forms.ToolStripButton();
            this.buttonEditRedo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.buttonZoomIn = new System.Windows.Forms.ToolStripButton();
            this.buttonZoomOut = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.levelPreviewToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator26 = new System.Windows.Forms.ToolStripSeparator();
            this.opacityToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator23 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.overlayOpacity = new System.Windows.Forms.TrackBar();
            this.ExportLevelImages = new System.ComponentModel.BackgroundWorker();
            this.labelOverlayOpacity = new System.Windows.Forms.Label();
            this.label67 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.directorySearcher1 = new System.DirectoryServices.DirectorySearcher();
            this.panelOpacity = new System.Windows.Forms.Panel();
            this.panelTemplateName = new System.Windows.Forms.Panel();
            this.label64 = new System.Windows.Forms.Label();
            this.buttonTemplateOK = new System.Windows.Forms.Button();
            this.buttonTemplateCancel = new System.Windows.Forms.Button();
            this.panel116 = new System.Windows.Forms.Panel();
            this.templateName = new System.Windows.Forms.TextBox();
            this.labelToolTip = new System.Windows.Forms.Label();
            this.labelConvertor = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            templateImport = new System.Windows.Forms.ToolStripButton();
            templateExport = new System.Windows.Forms.ToolStripButton();
            templateDelete = new System.Windows.Forms.ToolStripButton();
            templateCopy = new System.Windows.Forms.ToolStripButton();
            templatePaste = new System.Windows.Forms.ToolStripButton();
            panel444 = new System.Windows.Forms.Panel();
            panel444.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBattlefield)).BeginInit();
            this.panel100.SuspendLayout();
            this.panel101.SuspendLayout();
            this.panel102.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.colEditValueA)).BeginInit();
            this.tabPage8.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel85.SuspendLayout();
            this.panel84.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.npcXCoord)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.npcYCoord)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.npcZCoord)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.npcPropertyA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.npcPropertyB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.npcPropertyC)).BeginInit();
            this.panel42.SuspendLayout();
            this.panel83.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.npcID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.npcMovement)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.npcSpeedPlus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.npcEventORPack)).BeginInit();
            this.panel43.SuspendLayout();
            this.panel53.SuspendLayout();
            this.panel82.SuspendLayout();
            this.panel81.SuspendLayout();
            this.panel80.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.npcMapHeader)).BeginInit();
            this.panel118.SuspendLayout();
            this.panel119.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mapNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.levelNum)).BeginInit();
            this.contextMenuStrip4.SuspendLayout();
            this.tabPage10.SuspendLayout();
            this.panel99.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.overlapType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.overlapCoordX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.overlapCoordY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.overlapCoordZ)).BeginInit();
            this.panel62.SuspendLayout();
            this.tabPage9.SuspendLayout();
            this.panel52.SuspendLayout();
            this.panel90.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eventsFieldLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eventsFieldYCoord)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eventsFieldXCoord)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eventsFieldZCoord)).BeginInit();
            this.panel46.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eventsFieldHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eventsRunEvent)).BeginInit();
            this.panel89.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eventsExitEvent)).BeginInit();
            this.panel47.SuspendLayout();
            this.panel88.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.exitsMarioYCoord)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exitsMarioXCoord)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exitsMarioZCoord)).BeginInit();
            this.panel48.SuspendLayout();
            this.panel87.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.exitsFieldLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exitsFieldZCoord)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exitsFieldYCoord)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exitsFieldXCoord)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exitsFieldHeight)).BeginInit();
            this.panel49.SuspendLayout();
            this.panel50.SuspendLayout();
            this.panel51.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.panel66.SuspendLayout();
            this.panel67.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTilesetL2)).BeginInit();
            this.contextMenuStrip2.SuspendLayout();
            this.tabPage7.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panelPhysicalTile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPhysicalTile)).BeginInit();
            this.panel97.SuspendLayout();
            this.panel91.SuspendLayout();
            this.panel105.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.physicalTileBaseHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.physicalTileOverZCoord)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.physicalTileOverHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.physicalTileWaterZCoord)).BeginInit();
            this.panel55.SuspendLayout();
            this.panel54.SuspendLayout();
            this.panel44.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.physicalTileNum)).BeginInit();
            this.tabPage6.SuspendLayout();
            this.panel41.SuspendLayout();
            this.panel94.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTilesetL3)).BeginInit();
            this.panel1.SuspendLayout();
            this.panelColorBalance.SuspendLayout();
            this.colEditBFPanel.SuspendLayout();
            this.panel104.SuspendLayout();
            this.panel103.SuspendLayout();
            this.panelOverlapTileset.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOverlaps)).BeginInit();
            this.panelChangeLevelName.SuspendLayout();
            this.panel98.SuspendLayout();
            this.panelSearchLevelNames.SuspendLayout();
            this.panel58.SuspendLayout();
            this.panel27.SuspendLayout();
            this.panelLevelPicture.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLevel)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.areaPropertiesPanel.SuspendLayout();
            this.Priorities.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel79.SuspendLayout();
            this.panel22.SuspendLayout();
            this.panel26.SuspendLayout();
            this.panel78.SuspendLayout();
            this.panel21.SuspendLayout();
            this.panel23.SuspendLayout();
            this.panel24.SuspendLayout();
            this.panel25.SuspendLayout();
            this.panel77.SuspendLayout();
            this.panel16.SuspendLayout();
            this.panel19.SuspendLayout();
            this.panel18.SuspendLayout();
            this.panel20.SuspendLayout();
            this.panel76.SuspendLayout();
            this.panel75.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layerL2LeftShift)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layerL2UpShift)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layerL3LeftShift)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layerL3UpShift)).BeginInit();
            this.panel74.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layerMaskHighX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layerMaskLowX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layerMaskHighY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layerMaskLowY)).BeginInit();
            this.panel73.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layerPrioritySet)).BeginInit();
            this.panel17.SuspendLayout();
            this.panel14.SuspendLayout();
            this.panel6.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.panel28.SuspendLayout();
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
            this.panel71.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mapTilesetL3Num)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mapTilesetL2Num)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mapTilesetL1Num)).BeginInit();
            this.panel32.SuspendLayout();
            this.panel33.SuspendLayout();
            this.panel34.SuspendLayout();
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
            ((System.ComponentModel.ISupportInitialize)(this.palettePictureBox)).BeginInit();
            this.contextMenuStrip3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mapPaletteRedNum)).BeginInit();
            this.panel40.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mapPaletteGreenNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mapPaletteBlueNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mapPaletteGreenBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mapPaletteSetNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mapPaletteRedBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mapPaletteBlueBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxColor)).BeginInit();
            this.panelTemplates.SuspendLayout();
            this.panel114.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTemplate)).BeginInit();
            this.panel115.SuspendLayout();
            this.panelTemplatesSub.SuspendLayout();
            this.toolStrip3.SuspendLayout();
            this.panelTilesets.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel95.SuspendLayout();
            this.panel96.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTilesetL1)).BeginInit();
            this.tabPage12.SuspendLayout();
            this.panelBattlefields.SuspendLayout();
            this.panelBattlefieldTileset.SuspendLayout();
            this.panelBattlefieldPalettes.SuspendLayout();
            this.panel93.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.battlefieldPaletteSetNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bfPaletteGreenBar)).BeginInit();
            this.panel60.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bfPaletteBlueBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bfPalettePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bfPaletteRedBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bfPaletteRedNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bfPaletteBlueNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bfPaletteGreenNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxColorBF)).BeginInit();
            this.panelBattlefieldProperties.SuspendLayout();
            this.panel92.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.battlefieldGFXSet4Num)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.battlefieldGFXSet5Num)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.battlefieldGFXSet3Num)).BeginInit();
            this.panel57.SuspendLayout();
            this.panel56.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.battlefieldGFXSet2Num)).BeginInit();
            this.panel7.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.battlefieldGFXSet1Num)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.battlefieldTilesetNum)).BeginInit();
            this.panel59.SuspendLayout();
            this.panel45.SuspendLayout();
            this.panel61.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.battlefieldNum)).BeginInit();
            this.panelLevelZoom.SuspendLayout();
            this.panel117.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLevelZoom)).BeginInit();
            this.contextMenuStripTE.SuspendLayout();
            this.panelTileEditor.SuspendLayout();
            this.panel106.SuspendLayout();
            this.panel107.SuspendLayout();
            this.panelImageGraphics.SuspendLayout();
            this.panel108.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.panel109.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGraphicSet)).BeginInit();
            this.panel110.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPalette)).BeginInit();
            this.panel111.SuspendLayout();
            this.panel112.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSubtile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTile)).BeginInit();
            this.panel113.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tilePalette)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tileGFXSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tile8x8Tile)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.overlayOpacity)).BeginInit();
            this.panelOpacity.SuspendLayout();
            this.panelTemplateName.SuspendLayout();
            this.panel116.SuspendLayout();
            this.SuspendLayout();
            // 
            // templateImport
            // 
            templateImport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            templateImport.Image = global::LAZYSHELL.Properties.Resources.open_small;
            templateImport.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            templateImport.ImageTransparentColor = System.Drawing.Color.Magenta;
            templateImport.Name = "templateImport";
            templateImport.Size = new System.Drawing.Size(23, 18);
            templateImport.Text = "Open template(s)";
            templateImport.Click += new System.EventHandler(this.templateImport_Click);
            // 
            // templateExport
            // 
            templateExport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            templateExport.Image = global::LAZYSHELL.Properties.Resources.save_small;
            templateExport.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            templateExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            templateExport.Name = "templateExport";
            templateExport.Size = new System.Drawing.Size(23, 18);
            templateExport.Text = "Save template(s)";
            templateExport.Click += new System.EventHandler(this.templateExport_Click);
            // 
            // templateDelete
            // 
            templateDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            templateDelete.Image = global::LAZYSHELL.Properties.Resources.delete_small;
            templateDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            templateDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            templateDelete.Name = "templateDelete";
            templateDelete.Size = new System.Drawing.Size(23, 18);
            templateDelete.Text = "Delete template";
            templateDelete.Click += new System.EventHandler(this.templateDelete_Click);
            // 
            // templateCopy
            // 
            templateCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            templateCopy.Image = global::LAZYSHELL.Properties.Resources.copy_small;
            templateCopy.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            templateCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            templateCopy.Name = "templateCopy";
            templateCopy.Size = new System.Drawing.Size(23, 18);
            templateCopy.Text = "Copy template";
            templateCopy.Click += new System.EventHandler(this.templateCopy_Click);
            // 
            // templatePaste
            // 
            templatePaste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            templatePaste.Image = global::LAZYSHELL.Properties.Resources.paste_small;
            templatePaste.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            templatePaste.ImageTransparentColor = System.Drawing.Color.Magenta;
            templatePaste.Name = "templatePaste";
            templatePaste.Size = new System.Drawing.Size(23, 18);
            templatePaste.Text = "Paste template";
            templatePaste.Click += new System.EventHandler(this.templatePaste_Click);
            // 
            // panel444
            // 
            panel444.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            panel444.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            panel444.Controls.Add(this.labelBattlefieldTileset);
            panel444.Controls.Add(this.pictureBoxBattlefield);
            panel444.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            panel444.Location = new System.Drawing.Point(2, 2);
            panel444.Name = "panel444";
            panel444.Size = new System.Drawing.Size(256, 216);
            panel444.TabIndex = 176;
            // 
            // labelBattlefieldTileset
            // 
            this.labelBattlefieldTileset.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.labelBattlefieldTileset.BackColor = System.Drawing.SystemColors.Control;
            this.labelBattlefieldTileset.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.labelBattlefieldTileset.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBattlefieldTileset.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.labelBattlefieldTileset.Location = new System.Drawing.Point(0, 0);
            this.labelBattlefieldTileset.Name = "labelBattlefieldTileset";
            this.labelBattlefieldTileset.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.labelBattlefieldTileset.Size = new System.Drawing.Size(256, 17);
            this.labelBattlefieldTileset.TabIndex = 192;
            this.labelBattlefieldTileset.Text = "BATTLEFIELD TILESET";
            this.toolTip1.SetToolTip(this.labelBattlefieldTileset, "Click to drag or double-click to maximize / restore");
            this.labelBattlefieldTileset.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.labelBattlefieldTileset_MouseDoubleClick);
            this.labelBattlefieldTileset.MouseDown += new System.Windows.Forms.MouseEventHandler(this.labelBattlefieldTileset_MouseDown);
            this.labelBattlefieldTileset.MouseUp += new System.Windows.Forms.MouseEventHandler(this.labelBattlefieldTileset_MouseUp);
            // 
            // pictureBoxBattlefield
            // 
            this.pictureBoxBattlefield.BackgroundImage = global::LAZYSHELL.Properties.Resources._transparent;
            this.pictureBoxBattlefield.Cursor = System.Windows.Forms.Cursors.Cross;
            this.pictureBoxBattlefield.Location = new System.Drawing.Point(0, 19);
            this.pictureBoxBattlefield.Name = "pictureBoxBattlefield";
            this.pictureBoxBattlefield.Size = new System.Drawing.Size(512, 512);
            this.pictureBoxBattlefield.TabIndex = 2;
            this.pictureBoxBattlefield.TabStop = false;
            this.pictureBoxBattlefield.MouseLeave += new System.EventHandler(this.pictureBoxBattlefield_MouseLeave);
            this.pictureBoxBattlefield.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.pictureBoxBattlefield_PreviewKeyDown);
            this.pictureBoxBattlefield.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxBattlefield_MouseMove);
            this.pictureBoxBattlefield.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pictureBoxBattlefield_MouseDoubleClick);
            this.pictureBoxBattlefield.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBoxBattlefield_MouseClick);
            this.pictureBoxBattlefield.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxBattlefield_MouseDown);
            this.pictureBoxBattlefield.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxBattlefield_Paint);
            this.pictureBoxBattlefield.MouseEnter += new System.EventHandler(this.pictureBoxBattlefield_MouseEnter);
            // 
            // colEditColors
            // 
            this.colEditColors.BackColor = System.Drawing.SystemColors.Window;
            this.colEditColors.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.colEditColors.CheckOnClick = true;
            this.colEditColors.ColumnWidth = 14;
            this.colEditColors.Items.AddRange(new object[] {
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            ""});
            this.colEditColors.Location = new System.Drawing.Point(31, 37);
            this.colEditColors.MultiColumn = true;
            this.colEditColors.Name = "colEditColors";
            this.colEditColors.Size = new System.Drawing.Size(241, 112);
            this.colEditColors.TabIndex = 156;
            // 
            // panel100
            // 
            this.panel100.BackColor = System.Drawing.SystemColors.Window;
            this.panel100.Controls.Add(this.colEditComboBoxA);
            this.panel100.Location = new System.Drawing.Point(62, 19);
            this.panel100.Name = "panel100";
            this.panel100.Size = new System.Drawing.Size(69, 17);
            this.panel100.TabIndex = 1;
            // 
            // colEditComboBoxA
            // 
            this.colEditComboBoxA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.colEditComboBoxA.IntegralHeight = false;
            this.colEditComboBoxA.Items.AddRange(new object[] {
            "reds",
            "greens",
            "blues"});
            this.colEditComboBoxA.Location = new System.Drawing.Point(-2, -2);
            this.colEditComboBoxA.Name = "colEditComboBoxA";
            this.colEditComboBoxA.Size = new System.Drawing.Size(73, 21);
            this.colEditComboBoxA.TabIndex = 139;
            // 
            // panel101
            // 
            this.panel101.BackColor = System.Drawing.SystemColors.Window;
            this.panel101.Controls.Add(this.coleditSelectCommand);
            this.panel101.Location = new System.Drawing.Point(93, 2);
            this.panel101.Name = "panel101";
            this.panel101.Size = new System.Drawing.Size(182, 17);
            this.panel101.TabIndex = 1;
            // 
            // coleditSelectCommand
            // 
            this.coleditSelectCommand.DropDownHeight = 200;
            this.coleditSelectCommand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.coleditSelectCommand.DropDownWidth = 200;
            this.coleditSelectCommand.IntegralHeight = false;
            this.coleditSelectCommand.Items.AddRange(new object[] {
            "switch color(s)",
            "add value to color(s)",
            "subtract value from color(s)",
            "multiply color(s) by value",
            "divide color(s) by value",
            "equate color(s)",
            "set color(s)",
            "greyscale"});
            this.coleditSelectCommand.Location = new System.Drawing.Point(-2, -2);
            this.coleditSelectCommand.Name = "coleditSelectCommand";
            this.coleditSelectCommand.Size = new System.Drawing.Size(186, 21);
            this.coleditSelectCommand.TabIndex = 0;
            this.coleditSelectCommand.SelectedIndexChanged += new System.EventHandler(this.coleditSelectCommand_SelectedIndexChanged);
            // 
            // label139
            // 
            this.label139.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label139.Location = new System.Drawing.Point(2, 2);
            this.label139.Name = "label139";
            this.label139.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label139.Size = new System.Drawing.Size(90, 17);
            this.label139.TabIndex = 151;
            this.label139.Text = "Select command";
            // 
            // colEditLabelA
            // 
            this.colEditLabelA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.colEditLabelA.Location = new System.Drawing.Point(0, 19);
            this.colEditLabelA.Name = "colEditLabelA";
            this.colEditLabelA.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.colEditLabelA.Size = new System.Drawing.Size(61, 17);
            this.colEditLabelA.TabIndex = 151;
            // 
            // colEditLabelB
            // 
            this.colEditLabelB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.colEditLabelB.Location = new System.Drawing.Point(132, 19);
            this.colEditLabelB.Name = "colEditLabelB";
            this.colEditLabelB.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.colEditLabelB.Size = new System.Drawing.Size(40, 17);
            this.colEditLabelB.TabIndex = 151;
            // 
            // label134
            // 
            this.label134.BackColor = System.Drawing.SystemColors.Control;
            this.label134.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label134.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label134.Location = new System.Drawing.Point(0, 0);
            this.label134.Name = "label134";
            this.label134.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label134.Size = new System.Drawing.Size(272, 17);
            this.label134.TabIndex = 160;
            this.label134.Text = "COMMAND OPTIONS";
            this.label134.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel102
            // 
            this.panel102.BackColor = System.Drawing.SystemColors.Window;
            this.panel102.Controls.Add(this.colEditComboBoxB);
            this.panel102.Location = new System.Drawing.Point(173, 19);
            this.panel102.Name = "panel102";
            this.panel102.Size = new System.Drawing.Size(100, 17);
            this.panel102.TabIndex = 73;
            // 
            // colEditComboBoxB
            // 
            this.colEditComboBoxB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.colEditComboBoxB.IntegralHeight = false;
            this.colEditComboBoxB.Items.AddRange(new object[] {
            "reds",
            "greens",
            "blues"});
            this.colEditComboBoxB.Location = new System.Drawing.Point(-2, -2);
            this.colEditComboBoxB.Name = "colEditComboBoxB";
            this.colEditComboBoxB.Size = new System.Drawing.Size(104, 21);
            this.colEditComboBoxB.TabIndex = 139;
            // 
            // label136
            // 
            this.label136.BackColor = System.Drawing.SystemColors.Control;
            this.label136.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label136.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label136.Location = new System.Drawing.Point(0, 0);
            this.label136.Name = "label136";
            this.label136.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label136.Size = new System.Drawing.Size(272, 17);
            this.label136.TabIndex = 160;
            this.label136.Text = "APPLY TO COLORS...";
            this.label136.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // colEditSelectAll
            // 
            this.colEditSelectAll.BackColor = System.Drawing.SystemColors.Control;
            this.colEditSelectAll.FlatAppearance.BorderSize = 0;
            this.colEditSelectAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colEditSelectAll.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colEditSelectAll.Location = new System.Drawing.Point(31, 19);
            this.colEditSelectAll.Name = "colEditSelectAll";
            this.colEditSelectAll.Size = new System.Drawing.Size(119, 17);
            this.colEditSelectAll.TabIndex = 153;
            this.colEditSelectAll.Text = "SELECT ALL";
            this.colEditSelectAll.UseCompatibleTextRendering = true;
            this.colEditSelectAll.UseVisualStyleBackColor = false;
            this.colEditSelectAll.Click += new System.EventHandler(this.colEditSelectAll_Click);
            // 
            // colEditLabelC
            // 
            this.colEditLabelC.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.colEditLabelC.Location = new System.Drawing.Point(0, 37);
            this.colEditLabelC.Name = "colEditLabelC";
            this.colEditLabelC.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.colEditLabelC.Size = new System.Drawing.Size(61, 17);
            this.colEditLabelC.TabIndex = 157;
            // 
            // colEditValueA
            // 
            this.colEditValueA.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.colEditValueA.Increment = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.colEditValueA.Location = new System.Drawing.Point(62, 37);
            this.colEditValueA.Maximum = new decimal(new int[] {
            248,
            0,
            0,
            0});
            this.colEditValueA.Name = "colEditValueA";
            this.colEditValueA.Size = new System.Drawing.Size(44, 17);
            this.colEditValueA.TabIndex = 80;
            this.colEditValueA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // colEditReds
            // 
            this.colEditReds.Appearance = System.Windows.Forms.Appearance.Button;
            this.colEditReds.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(220)))), ((int)(((byte)(212)))));
            this.colEditReds.FlatAppearance.BorderSize = 0;
            this.colEditReds.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(168)))), ((int)(((byte)(168)))));
            this.colEditReds.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colEditReds.ForeColor = System.Drawing.Color.Gray;
            this.colEditReds.Location = new System.Drawing.Point(132, 37);
            this.colEditReds.Name = "colEditReds";
            this.colEditReds.Size = new System.Drawing.Size(40, 17);
            this.colEditReds.TabIndex = 81;
            this.colEditReds.Text = "REDS";
            this.colEditReds.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.colEditReds.UseCompatibleTextRendering = true;
            this.colEditReds.UseVisualStyleBackColor = false;
            this.colEditReds.CheckedChanged += new System.EventHandler(this.colEditReds_CheckedChanged);
            // 
            // colEditGreens
            // 
            this.colEditGreens.Appearance = System.Windows.Forms.Appearance.Button;
            this.colEditGreens.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(220)))), ((int)(((byte)(212)))));
            this.colEditGreens.FlatAppearance.BorderSize = 0;
            this.colEditGreens.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(168)))), ((int)(((byte)(168)))));
            this.colEditGreens.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colEditGreens.ForeColor = System.Drawing.Color.Gray;
            this.colEditGreens.Location = new System.Drawing.Point(173, 37);
            this.colEditGreens.Name = "colEditGreens";
            this.colEditGreens.Size = new System.Drawing.Size(53, 17);
            this.colEditGreens.TabIndex = 82;
            this.colEditGreens.Text = "GREENS";
            this.colEditGreens.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.colEditGreens.UseCompatibleTextRendering = true;
            this.colEditGreens.UseVisualStyleBackColor = false;
            this.colEditGreens.CheckedChanged += new System.EventHandler(this.colEditGreens_CheckedChanged);
            // 
            // colEditBlues
            // 
            this.colEditBlues.Appearance = System.Windows.Forms.Appearance.Button;
            this.colEditBlues.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(220)))), ((int)(((byte)(212)))));
            this.colEditBlues.FlatAppearance.BorderSize = 0;
            this.colEditBlues.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(168)))), ((int)(((byte)(168)))));
            this.colEditBlues.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colEditBlues.ForeColor = System.Drawing.Color.Gray;
            this.colEditBlues.Location = new System.Drawing.Point(227, 37);
            this.colEditBlues.Name = "colEditBlues";
            this.colEditBlues.Size = new System.Drawing.Size(45, 17);
            this.colEditBlues.TabIndex = 84;
            this.colEditBlues.Text = "BLUES";
            this.colEditBlues.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.colEditBlues.UseCompatibleTextRendering = true;
            this.colEditBlues.UseVisualStyleBackColor = false;
            this.colEditBlues.CheckedChanged += new System.EventHandler(this.colEditBlues_CheckedChanged);
            // 
            // colEditLabelD
            // 
            this.colEditLabelD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.colEditLabelD.Location = new System.Drawing.Point(107, 37);
            this.colEditLabelD.Name = "colEditLabelD";
            this.colEditLabelD.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.colEditLabelD.Size = new System.Drawing.Size(24, 17);
            this.colEditLabelD.TabIndex = 157;
            // 
            // colEditRowSelectAll
            // 
            this.colEditRowSelectAll.BackColor = System.Drawing.SystemColors.Window;
            this.colEditRowSelectAll.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.colEditRowSelectAll.CheckOnClick = true;
            this.colEditRowSelectAll.ColumnWidth = 14;
            this.colEditRowSelectAll.Items.AddRange(new object[] {
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            ""});
            this.colEditRowSelectAll.Location = new System.Drawing.Point(0, 37);
            this.colEditRowSelectAll.MultiColumn = true;
            this.colEditRowSelectAll.Name = "colEditRowSelectAll";
            this.colEditRowSelectAll.Size = new System.Drawing.Size(30, 112);
            this.colEditRowSelectAll.TabIndex = 155;
            this.colEditRowSelectAll.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.colEditRowSelectAll_ItemCheck);
            // 
            // label143
            // 
            this.label143.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label143.Location = new System.Drawing.Point(0, 19);
            this.label143.Name = "label143";
            this.label143.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label143.Size = new System.Drawing.Size(15, 17);
            this.label143.TabIndex = 157;
            this.label143.Text = "o";
            this.label143.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // colEditApply
            // 
            this.colEditApply.BackColor = System.Drawing.SystemColors.Window;
            this.colEditApply.FlatAppearance.BorderSize = 0;
            this.colEditApply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colEditApply.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colEditApply.Location = new System.Drawing.Point(2, 228);
            this.colEditApply.Name = "colEditApply";
            this.colEditApply.Size = new System.Drawing.Size(112, 17);
            this.colEditApply.TabIndex = 4;
            this.colEditApply.Text = "APPLY";
            this.colEditApply.UseCompatibleTextRendering = true;
            this.colEditApply.UseVisualStyleBackColor = false;
            this.colEditApply.Click += new System.EventHandler(this.colEditApply_Click);
            // 
            // colEditReset
            // 
            this.colEditReset.BackColor = System.Drawing.SystemColors.Window;
            this.colEditReset.FlatAppearance.BorderSize = 0;
            this.colEditReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colEditReset.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colEditReset.Location = new System.Drawing.Point(115, 228);
            this.colEditReset.Name = "colEditReset";
            this.colEditReset.Size = new System.Drawing.Size(112, 17);
            this.colEditReset.TabIndex = 5;
            this.colEditReset.Text = "RESET";
            this.colEditReset.UseCompatibleTextRendering = true;
            this.colEditReset.UseVisualStyleBackColor = false;
            this.colEditReset.Click += new System.EventHandler(this.colEditReset_Click);
            // 
            // tabPage8
            // 
            this.tabPage8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPage8.Controls.Add(this.panel9);
            this.tabPage8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage8.Location = new System.Drawing.Point(4, 22);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Size = new System.Drawing.Size(244, 610);
            this.tabPage8.TabIndex = 2;
            this.tabPage8.Text = "NPC";
            this.tabPage8.UseVisualStyleBackColor = true;
            // 
            // panel9
            // 
            this.panel9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.panel9.BackColor = System.Drawing.SystemColors.ControlText;
            this.panel9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel9.Controls.Add(this.panel65);
            this.panel9.Controls.Add(this.npcCopy);
            this.panel9.Controls.Add(this.npcPaste);
            this.panel9.Controls.Add(this.npcMoveUp);
            this.panel9.Controls.Add(this.npcMoveDown);
            this.panel9.Controls.Add(this.panel85);
            this.panel9.Controls.Add(this.panel84);
            this.panel9.Controls.Add(this.panel83);
            this.panel9.Controls.Add(this.panel82);
            this.panel9.Controls.Add(this.panel81);
            this.panel9.Controls.Add(this.panel80);
            this.panel9.Controls.Add(this.panel118);
            this.panel9.Controls.Add(this.label112);
            this.panel9.Controls.Add(this.npcObjectTree);
            this.panel9.Location = new System.Drawing.Point(0, 0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(242, 608);
            this.panel9.TabIndex = 0;
            // 
            // panel65
            // 
            this.panel65.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.panel65.BackgroundImage = global::LAZYSHELL.Properties.Resources._bg;
            this.panel65.Location = new System.Drawing.Point(120, 541);
            this.panel65.Name = "panel65";
            this.panel65.Size = new System.Drawing.Size(120, 65);
            this.panel65.TabIndex = 486;
            // 
            // npcCopy
            // 
            this.npcCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.npcCopy.BackColor = System.Drawing.SystemColors.Window;
            this.npcCopy.FlatAppearance.BorderSize = 0;
            this.npcCopy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.npcCopy.Image = global::LAZYSHELL.Properties.Resources.copy_small;
            this.npcCopy.Location = new System.Drawing.Point(60, 328);
            this.npcCopy.Name = "npcCopy";
            this.npcCopy.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.npcCopy.Size = new System.Drawing.Size(29, 17);
            this.npcCopy.TabIndex = 92;
            this.toolTip1.SetToolTip(this.npcCopy, "Copy NPC");
            this.npcCopy.UseCompatibleTextRendering = true;
            this.npcCopy.UseVisualStyleBackColor = false;
            this.npcCopy.Click += new System.EventHandler(this.npcCopy_Click);
            // 
            // npcPaste
            // 
            this.npcPaste.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.npcPaste.BackColor = System.Drawing.SystemColors.Window;
            this.npcPaste.FlatAppearance.BorderSize = 0;
            this.npcPaste.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.npcPaste.Image = global::LAZYSHELL.Properties.Resources.paste_small;
            this.npcPaste.Location = new System.Drawing.Point(90, 328);
            this.npcPaste.Name = "npcPaste";
            this.npcPaste.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.npcPaste.Size = new System.Drawing.Size(28, 17);
            this.npcPaste.TabIndex = 93;
            this.toolTip1.SetToolTip(this.npcPaste, "Paste NPC");
            this.npcPaste.UseCompatibleTextRendering = true;
            this.npcPaste.UseVisualStyleBackColor = false;
            this.npcPaste.Click += new System.EventHandler(this.npcPaste_Click);
            // 
            // npcMoveUp
            // 
            this.npcMoveUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.npcMoveUp.BackColor = System.Drawing.SystemColors.Window;
            this.npcMoveUp.FlatAppearance.BorderSize = 0;
            this.npcMoveUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.npcMoveUp.Image = global::LAZYSHELL.Properties.Resources.moveup;
            this.npcMoveUp.Location = new System.Drawing.Point(0, 328);
            this.npcMoveUp.Name = "npcMoveUp";
            this.npcMoveUp.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.npcMoveUp.Size = new System.Drawing.Size(29, 17);
            this.npcMoveUp.TabIndex = 92;
            this.toolTip1.SetToolTip(this.npcMoveUp, "NPC Move Up");
            this.npcMoveUp.UseCompatibleTextRendering = true;
            this.npcMoveUp.UseVisualStyleBackColor = false;
            this.npcMoveUp.Click += new System.EventHandler(this.npcMoveUp_Click);
            // 
            // npcMoveDown
            // 
            this.npcMoveDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.npcMoveDown.BackColor = System.Drawing.SystemColors.Window;
            this.npcMoveDown.FlatAppearance.BorderSize = 0;
            this.npcMoveDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.npcMoveDown.Image = global::LAZYSHELL.Properties.Resources.movedown;
            this.npcMoveDown.Location = new System.Drawing.Point(30, 328);
            this.npcMoveDown.Name = "npcMoveDown";
            this.npcMoveDown.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.npcMoveDown.Size = new System.Drawing.Size(29, 17);
            this.npcMoveDown.TabIndex = 93;
            this.toolTip1.SetToolTip(this.npcMoveDown, "NPC Move Down");
            this.npcMoveDown.UseCompatibleTextRendering = true;
            this.npcMoveDown.UseVisualStyleBackColor = false;
            this.npcMoveDown.Click += new System.EventHandler(this.npcMoveDown_Click);
            // 
            // panel85
            // 
            this.panel85.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel85.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.panel85.Controls.Add(this.npcAttributes);
            this.panel85.Controls.Add(this.label65);
            this.panel85.Location = new System.Drawing.Point(0, 347);
            this.panel85.Name = "panel85";
            this.panel85.Size = new System.Drawing.Size(118, 259);
            this.panel85.TabIndex = 485;
            // 
            // npcAttributes
            // 
            this.npcAttributes.BackColor = System.Drawing.SystemColors.Window;
            this.npcAttributes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.npcAttributes.CheckOnClick = true;
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
            this.npcAttributes.Name = "npcAttributes";
            this.npcAttributes.Size = new System.Drawing.Size(118, 240);
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
            this.label65.Size = new System.Drawing.Size(118, 17);
            this.label65.TabIndex = 475;
            this.label65.Text = "PROPERTIES...";
            this.label65.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel84
            // 
            this.panel84.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.panel84.Controls.Add(this.label111);
            this.panel84.Controls.Add(this.npcXCoord);
            this.panel84.Controls.Add(this.npcYCoord);
            this.panel84.Controls.Add(this.label29);
            this.panel84.Controls.Add(this.label28);
            this.panel84.Controls.Add(this.npcZCoord);
            this.panel84.Controls.Add(this.label56);
            this.panel84.Controls.Add(this.label30);
            this.panel84.Controls.Add(this.npcPropertyA);
            this.panel84.Controls.Add(this.label104);
            this.panel84.Controls.Add(this.npcPropertyB);
            this.panel84.Controls.Add(this.label31);
            this.panel84.Controls.Add(this.npcPropertyC);
            this.panel84.Controls.Add(this.label116);
            this.panel84.Controls.Add(this.npcsZCoordPlusHalf);
            this.panel84.Controls.Add(this.panel42);
            this.panel84.Controls.Add(this.npcsShowNPC);
            this.panel84.Location = new System.Drawing.Point(120, 321);
            this.panel84.Name = "panel84";
            this.panel84.Size = new System.Drawing.Size(120, 180);
            this.panel84.TabIndex = 484;
            // 
            // label111
            // 
            this.label111.BackColor = System.Drawing.SystemColors.Control;
            this.label111.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label111.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label111.Location = new System.Drawing.Point(0, 0);
            this.label111.Name = "label111";
            this.label111.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label111.Size = new System.Drawing.Size(120, 17);
            this.label111.TabIndex = 475;
            this.label111.Text = "INSTANCE...";
            this.label111.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // npcXCoord
            // 
            this.npcXCoord.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.npcXCoord.Location = new System.Drawing.Point(68, 91);
            this.npcXCoord.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.npcXCoord.Name = "npcXCoord";
            this.npcXCoord.Size = new System.Drawing.Size(53, 17);
            this.npcXCoord.TabIndex = 108;
            this.npcXCoord.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.npcXCoord.ValueChanged += new System.EventHandler(this.npcXCoord_ValueChanged);
            // 
            // npcYCoord
            // 
            this.npcYCoord.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.npcYCoord.Location = new System.Drawing.Point(68, 109);
            this.npcYCoord.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.npcYCoord.Name = "npcYCoord";
            this.npcYCoord.Size = new System.Drawing.Size(53, 17);
            this.npcYCoord.TabIndex = 109;
            this.npcYCoord.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.npcYCoord.ValueChanged += new System.EventHandler(this.npcYCoord_ValueChanged);
            // 
            // label29
            // 
            this.label29.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label29.Location = new System.Drawing.Point(0, 91);
            this.label29.Name = "label29";
            this.label29.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label29.Size = new System.Drawing.Size(67, 17);
            this.label29.TabIndex = 463;
            this.label29.Text = "X Coord";
            // 
            // label28
            // 
            this.label28.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label28.Location = new System.Drawing.Point(0, 109);
            this.label28.Name = "label28";
            this.label28.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label28.Size = new System.Drawing.Size(67, 17);
            this.label28.TabIndex = 464;
            this.label28.Text = "Y Coord";
            // 
            // npcZCoord
            // 
            this.npcZCoord.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.npcZCoord.Location = new System.Drawing.Point(68, 127);
            this.npcZCoord.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.npcZCoord.Name = "npcZCoord";
            this.npcZCoord.Size = new System.Drawing.Size(53, 17);
            this.npcZCoord.TabIndex = 110;
            this.npcZCoord.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.npcZCoord.ValueChanged += new System.EventHandler(this.npcZCoord_ValueChanged);
            // 
            // label56
            // 
            this.label56.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label56.Location = new System.Drawing.Point(0, 127);
            this.label56.Name = "label56";
            this.label56.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label56.Size = new System.Drawing.Size(67, 17);
            this.label56.TabIndex = 466;
            this.label56.Text = "Z Coord";
            // 
            // label30
            // 
            this.label30.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label30.Location = new System.Drawing.Point(0, 163);
            this.label30.Name = "label30";
            this.label30.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label30.Size = new System.Drawing.Size(67, 17);
            this.label30.TabIndex = 467;
            this.label30.Text = "Facing";
            // 
            // npcPropertyA
            // 
            this.npcPropertyA.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.npcPropertyA.Location = new System.Drawing.Point(68, 37);
            this.npcPropertyA.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.npcPropertyA.Name = "npcPropertyA";
            this.npcPropertyA.Size = new System.Drawing.Size(53, 17);
            this.npcPropertyA.TabIndex = 105;
            this.npcPropertyA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.npcPropertyA.ValueChanged += new System.EventHandler(this.npcPropertyA_ValueChanged);
            // 
            // label104
            // 
            this.label104.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label104.Location = new System.Drawing.Point(0, 37);
            this.label104.Name = "label104";
            this.label104.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label104.Size = new System.Drawing.Size(67, 17);
            this.label104.TabIndex = 469;
            // 
            // npcPropertyB
            // 
            this.npcPropertyB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.npcPropertyB.Location = new System.Drawing.Point(68, 55);
            this.npcPropertyB.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.npcPropertyB.Name = "npcPropertyB";
            this.npcPropertyB.Size = new System.Drawing.Size(53, 17);
            this.npcPropertyB.TabIndex = 106;
            this.npcPropertyB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.npcPropertyB.ValueChanged += new System.EventHandler(this.npcPropertyB_ValueChanged);
            // 
            // label31
            // 
            this.label31.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label31.Location = new System.Drawing.Point(0, 55);
            this.label31.Name = "label31";
            this.label31.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label31.Size = new System.Drawing.Size(67, 17);
            this.label31.TabIndex = 473;
            // 
            // npcPropertyC
            // 
            this.npcPropertyC.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.npcPropertyC.Location = new System.Drawing.Point(68, 73);
            this.npcPropertyC.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.npcPropertyC.Name = "npcPropertyC";
            this.npcPropertyC.Size = new System.Drawing.Size(53, 17);
            this.npcPropertyC.TabIndex = 107;
            this.npcPropertyC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.npcPropertyC.ValueChanged += new System.EventHandler(this.npcPropertyC_ValueChanged);
            // 
            // label116
            // 
            this.label116.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label116.Location = new System.Drawing.Point(0, 73);
            this.label116.Name = "label116";
            this.label116.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label116.Size = new System.Drawing.Size(67, 17);
            this.label116.TabIndex = 472;
            this.label116.Text = "Action #+";
            // 
            // npcsZCoordPlusHalf
            // 
            this.npcsZCoordPlusHalf.Appearance = System.Windows.Forms.Appearance.Button;
            this.npcsZCoordPlusHalf.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(220)))), ((int)(((byte)(212)))));
            this.npcsZCoordPlusHalf.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.npcsZCoordPlusHalf.FlatAppearance.BorderSize = 0;
            this.npcsZCoordPlusHalf.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(168)))), ((int)(((byte)(168)))));
            this.npcsZCoordPlusHalf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.npcsZCoordPlusHalf.ForeColor = System.Drawing.Color.Gray;
            this.npcsZCoordPlusHalf.Location = new System.Drawing.Point(0, 145);
            this.npcsZCoordPlusHalf.Name = "npcsZCoordPlusHalf";
            this.npcsZCoordPlusHalf.Size = new System.Drawing.Size(120, 17);
            this.npcsZCoordPlusHalf.TabIndex = 111;
            this.npcsZCoordPlusHalf.Text = "Z Coord +½";
            this.npcsZCoordPlusHalf.UseCompatibleTextRendering = true;
            this.npcsZCoordPlusHalf.UseVisualStyleBackColor = false;
            this.npcsZCoordPlusHalf.CheckedChanged += new System.EventHandler(this.npcsZCoordPlusHalf_CheckedChanged);
            // 
            // panel42
            // 
            this.panel42.BackColor = System.Drawing.SystemColors.Window;
            this.panel42.Controls.Add(this.npcRadialPosition);
            this.panel42.Location = new System.Drawing.Point(68, 163);
            this.panel42.Name = "panel42";
            this.panel42.Size = new System.Drawing.Size(52, 17);
            this.panel42.TabIndex = 112;
            // 
            // npcRadialPosition
            // 
            this.npcRadialPosition.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.npcRadialPosition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.npcRadialPosition.Items.AddRange(new object[] {
            "E",
            "SE",
            "S",
            "SW",
            "W",
            "NW",
            "N",
            "NE"});
            this.npcRadialPosition.Location = new System.Drawing.Point(-2, -2);
            this.npcRadialPosition.Name = "npcRadialPosition";
            this.npcRadialPosition.Size = new System.Drawing.Size(57, 21);
            this.npcRadialPosition.TabIndex = 193;
            this.npcRadialPosition.SelectedIndexChanged += new System.EventHandler(this.npcRadialPosition_SelectedIndexChanged);
            // 
            // npcsShowNPC
            // 
            this.npcsShowNPC.Appearance = System.Windows.Forms.Appearance.Button;
            this.npcsShowNPC.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(220)))), ((int)(((byte)(212)))));
            this.npcsShowNPC.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.npcsShowNPC.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(168)))), ((int)(((byte)(168)))));
            this.npcsShowNPC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.npcsShowNPC.ForeColor = System.Drawing.Color.Gray;
            this.npcsShowNPC.Location = new System.Drawing.Point(-1, 18);
            this.npcsShowNPC.Name = "npcsShowNPC";
            this.npcsShowNPC.Size = new System.Drawing.Size(122, 19);
            this.npcsShowNPC.TabIndex = 104;
            this.npcsShowNPC.Text = "Show NPC Instance";
            this.npcsShowNPC.UseCompatibleTextRendering = true;
            this.npcsShowNPC.UseVisualStyleBackColor = false;
            this.npcsShowNPC.CheckedChanged += new System.EventHandler(this.npcsShowNPC_CheckedChanged);
            // 
            // panel83
            // 
            this.panel83.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.panel83.Controls.Add(this.label71);
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
            this.panel83.Controls.Add(this.findNPCNum);
            this.panel83.Controls.Add(this.panel43);
            this.panel83.Controls.Add(this.panel53);
            this.panel83.Location = new System.Drawing.Point(120, 133);
            this.panel83.Name = "panel83";
            this.panel83.Size = new System.Drawing.Size(120, 186);
            this.panel83.TabIndex = 483;
            // 
            // label71
            // 
            this.label71.BackColor = System.Drawing.SystemColors.Control;
            this.label71.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label71.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label71.Location = new System.Drawing.Point(0, 0);
            this.label71.Name = "label71";
            this.label71.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label71.Size = new System.Drawing.Size(120, 17);
            this.label71.TabIndex = 474;
            this.label71.Text = "PROPERTIES...";
            this.label71.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // npcID
            // 
            this.npcID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.npcID.Location = new System.Drawing.Point(68, 95);
            this.npcID.Maximum = new decimal(new int[] {
            511,
            0,
            0,
            0});
            this.npcID.Name = "npcID";
            this.npcID.Size = new System.Drawing.Size(53, 17);
            this.npcID.TabIndex = 98;
            this.npcID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.npcID.ValueChanged += new System.EventHandler(this.npcID_ValueChanged);
            // 
            // label49
            // 
            this.label49.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label49.Location = new System.Drawing.Point(0, 95);
            this.label49.Name = "label49";
            this.label49.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label49.Size = new System.Drawing.Size(67, 17);
            this.label49.TabIndex = 452;
            this.label49.Text = "NPC #";
            // 
            // npcMovement
            // 
            this.npcMovement.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.npcMovement.Location = new System.Drawing.Point(68, 151);
            this.npcMovement.Maximum = new decimal(new int[] {
            1023,
            0,
            0,
            0});
            this.npcMovement.Name = "npcMovement";
            this.npcMovement.Size = new System.Drawing.Size(53, 17);
            this.npcMovement.TabIndex = 101;
            this.npcMovement.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.npcMovement.ValueChanged += new System.EventHandler(this.npcMovement_ValueChanged);
            // 
            // npcSpeedPlus
            // 
            this.npcSpeedPlus.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.npcSpeedPlus.Location = new System.Drawing.Point(68, 169);
            this.npcSpeedPlus.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.npcSpeedPlus.Name = "npcSpeedPlus";
            this.npcSpeedPlus.Size = new System.Drawing.Size(53, 17);
            this.npcSpeedPlus.TabIndex = 103;
            this.npcSpeedPlus.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.npcSpeedPlus.ValueChanged += new System.EventHandler(this.npcSpeedPlus_ValueChanged);
            // 
            // npcEventORPack
            // 
            this.npcEventORPack.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.npcEventORPack.Location = new System.Drawing.Point(68, 133);
            this.npcEventORPack.Maximum = new decimal(new int[] {
            4095,
            0,
            0,
            0});
            this.npcEventORPack.Name = "npcEventORPack";
            this.npcEventORPack.Size = new System.Drawing.Size(53, 17);
            this.npcEventORPack.TabIndex = 100;
            this.npcEventORPack.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.npcEventORPack.ValueChanged += new System.EventHandler(this.npcEventORPack_ValueChanged);
            // 
            // label54
            // 
            this.label54.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label54.Location = new System.Drawing.Point(0, 169);
            this.label54.Name = "label54";
            this.label54.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label54.Size = new System.Drawing.Size(67, 17);
            this.label54.TabIndex = 460;
            this.label54.Text = "Speed +";
            // 
            // label117
            // 
            this.label117.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label117.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label117.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label117.Location = new System.Drawing.Point(0, 19);
            this.label117.Name = "label117";
            this.label117.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label117.Size = new System.Drawing.Size(120, 17);
            this.label117.TabIndex = 477;
            this.label117.Text = "NPC TYPE";
            // 
            // label70
            // 
            this.label70.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label70.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label70.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label70.Location = new System.Drawing.Point(0, 57);
            this.label70.Name = "label70";
            this.label70.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label70.Size = new System.Drawing.Size(120, 17);
            this.label70.TabIndex = 476;
            this.label70.Text = "TRIGGER";
            // 
            // buttonGotoB
            // 
            this.buttonGotoB.BackColor = System.Drawing.Color.Lime;
            this.buttonGotoB.FlatAppearance.BorderSize = 0;
            this.buttonGotoB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGotoB.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonGotoB.Location = new System.Drawing.Point(0, 151);
            this.buttonGotoB.Name = "buttonGotoB";
            this.buttonGotoB.Size = new System.Drawing.Size(67, 17);
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
            this.buttonGotoA.BackColor = System.Drawing.Color.Lime;
            this.buttonGotoA.FlatAppearance.BorderSize = 0;
            this.buttonGotoA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGotoA.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonGotoA.Location = new System.Drawing.Point(0, 133);
            this.buttonGotoA.Name = "buttonGotoA";
            this.buttonGotoA.Size = new System.Drawing.Size(67, 17);
            this.buttonGotoA.TabIndex = 99;
            this.buttonGotoA.Text = "Event #";
            this.buttonGotoA.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.buttonGotoA, "Edit NPC event...");
            this.buttonGotoA.UseCompatibleTextRendering = true;
            this.buttonGotoA.UseVisualStyleBackColor = false;
            this.buttonGotoA.Click += new System.EventHandler(this.buttonGotoA_Click);
            // 
            // findNPCNum
            // 
            this.findNPCNum.BackColor = System.Drawing.Color.Yellow;
            this.findNPCNum.FlatAppearance.BorderSize = 0;
            this.findNPCNum.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.findNPCNum.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.findNPCNum.Location = new System.Drawing.Point(0, 114);
            this.findNPCNum.Name = "findNPCNum";
            this.findNPCNum.Size = new System.Drawing.Size(120, 17);
            this.findNPCNum.TabIndex = 99;
            this.findNPCNum.Text = "Edit NPCs...";
            this.findNPCNum.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.findNPCNum.UseCompatibleTextRendering = true;
            this.findNPCNum.UseVisualStyleBackColor = false;
            this.findNPCNum.Click += new System.EventHandler(this.findNPCNum_Click);
            // 
            // panel43
            // 
            this.panel43.BackColor = System.Drawing.SystemColors.Window;
            this.panel43.Controls.Add(this.npcEngageType);
            this.panel43.Location = new System.Drawing.Point(0, 38);
            this.panel43.Name = "panel43";
            this.panel43.Size = new System.Drawing.Size(120, 17);
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
            this.npcEngageType.Size = new System.Drawing.Size(125, 21);
            this.npcEngageType.TabIndex = 206;
            this.npcEngageType.SelectedIndexChanged += new System.EventHandler(this.npcEngageType_SelectedIndexChanged);
            // 
            // panel53
            // 
            this.panel53.BackColor = System.Drawing.SystemColors.Window;
            this.panel53.Controls.Add(this.npcEngageTrigger);
            this.panel53.Location = new System.Drawing.Point(0, 76);
            this.panel53.Name = "panel53";
            this.panel53.Size = new System.Drawing.Size(120, 17);
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
            this.npcEngageTrigger.Size = new System.Drawing.Size(125, 21);
            this.npcEngageTrigger.TabIndex = 205;
            this.npcEngageTrigger.SelectedIndexChanged += new System.EventHandler(this.npcEngageTrigger_SelectedIndexChanged);
            // 
            // panel82
            // 
            this.panel82.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.panel82.Controls.Add(this.label115);
            this.panel82.Controls.Add(this.npcRemoveInstance);
            this.panel82.Controls.Add(this.npcInsertInstance);
            this.panel82.Location = new System.Drawing.Point(120, 95);
            this.panel82.Name = "panel82";
            this.panel82.Size = new System.Drawing.Size(120, 36);
            this.panel82.TabIndex = 482;
            // 
            // label115
            // 
            this.label115.BackColor = System.Drawing.SystemColors.Control;
            this.label115.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label115.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label115.Location = new System.Drawing.Point(0, 0);
            this.label115.Name = "label115";
            this.label115.Padding = new System.Windows.Forms.Padding(1, 1, 0, 2);
            this.label115.Size = new System.Drawing.Size(120, 17);
            this.label115.TabIndex = 450;
            this.label115.Text = "NPC INSTANCE...";
            // 
            // npcRemoveInstance
            // 
            this.npcRemoveInstance.BackColor = System.Drawing.SystemColors.Window;
            this.npcRemoveInstance.FlatAppearance.BorderSize = 0;
            this.npcRemoveInstance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.npcRemoveInstance.Location = new System.Drawing.Point(60, 19);
            this.npcRemoveInstance.Name = "npcRemoveInstance";
            this.npcRemoveInstance.Size = new System.Drawing.Size(60, 17);
            this.npcRemoveInstance.TabIndex = 95;
            this.npcRemoveInstance.Text = "DELETE";
            this.npcRemoveInstance.UseCompatibleTextRendering = true;
            this.npcRemoveInstance.UseVisualStyleBackColor = false;
            this.npcRemoveInstance.Click += new System.EventHandler(this.npcRemoveInstance_Click);
            // 
            // npcInsertInstance
            // 
            this.npcInsertInstance.BackColor = System.Drawing.SystemColors.Window;
            this.npcInsertInstance.FlatAppearance.BorderSize = 0;
            this.npcInsertInstance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.npcInsertInstance.Location = new System.Drawing.Point(0, 19);
            this.npcInsertInstance.Name = "npcInsertInstance";
            this.npcInsertInstance.Size = new System.Drawing.Size(59, 17);
            this.npcInsertInstance.TabIndex = 94;
            this.npcInsertInstance.Text = "INSERT";
            this.npcInsertInstance.UseCompatibleTextRendering = true;
            this.npcInsertInstance.UseVisualStyleBackColor = false;
            this.npcInsertInstance.Click += new System.EventHandler(this.npcInsertInstance_Click);
            // 
            // panel81
            // 
            this.panel81.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.panel81.Controls.Add(this.label113);
            this.panel81.Controls.Add(this.npcInsertObject);
            this.panel81.Controls.Add(this.npcRemoveObject);
            this.panel81.Location = new System.Drawing.Point(120, 57);
            this.panel81.Name = "panel81";
            this.panel81.Size = new System.Drawing.Size(120, 36);
            this.panel81.TabIndex = 481;
            // 
            // label113
            // 
            this.label113.BackColor = System.Drawing.SystemColors.Control;
            this.label113.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label113.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label113.Location = new System.Drawing.Point(0, 0);
            this.label113.Name = "label113";
            this.label113.Padding = new System.Windows.Forms.Padding(1, 0, 0, 2);
            this.label113.Size = new System.Drawing.Size(120, 17);
            this.label113.TabIndex = 448;
            this.label113.Text = "NPC...";
            this.label113.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // npcInsertObject
            // 
            this.npcInsertObject.BackColor = System.Drawing.SystemColors.Window;
            this.npcInsertObject.FlatAppearance.BorderSize = 0;
            this.npcInsertObject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.npcInsertObject.Location = new System.Drawing.Point(0, 19);
            this.npcInsertObject.Name = "npcInsertObject";
            this.npcInsertObject.Size = new System.Drawing.Size(59, 17);
            this.npcInsertObject.TabIndex = 92;
            this.npcInsertObject.Text = "INSERT";
            this.npcInsertObject.UseCompatibleTextRendering = true;
            this.npcInsertObject.UseVisualStyleBackColor = false;
            this.npcInsertObject.Click += new System.EventHandler(this.npcInsertObject_Click);
            // 
            // npcRemoveObject
            // 
            this.npcRemoveObject.BackColor = System.Drawing.SystemColors.Window;
            this.npcRemoveObject.FlatAppearance.BorderSize = 0;
            this.npcRemoveObject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.npcRemoveObject.Location = new System.Drawing.Point(60, 19);
            this.npcRemoveObject.Name = "npcRemoveObject";
            this.npcRemoveObject.Size = new System.Drawing.Size(60, 17);
            this.npcRemoveObject.TabIndex = 93;
            this.npcRemoveObject.Text = "DELETE";
            this.npcRemoveObject.UseCompatibleTextRendering = true;
            this.npcRemoveObject.UseVisualStyleBackColor = false;
            this.npcRemoveObject.Click += new System.EventHandler(this.npcRemoveObject_Click);
            // 
            // panel80
            // 
            this.panel80.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.panel80.Controls.Add(this.label48);
            this.panel80.Controls.Add(this.npcMapHeader);
            this.panel80.Controls.Add(this.openPartitions);
            this.panel80.Location = new System.Drawing.Point(120, 19);
            this.panel80.Name = "panel80";
            this.panel80.Size = new System.Drawing.Size(120, 36);
            this.panel80.TabIndex = 480;
            // 
            // label48
            // 
            this.label48.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
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
            this.npcMapHeader.Size = new System.Drawing.Size(53, 17);
            this.npcMapHeader.TabIndex = 89;
            this.npcMapHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.npcMapHeader.ValueChanged += new System.EventHandler(this.npcMapHeader_ValueChanged);
            // 
            // openPartitions
            // 
            this.openPartitions.BackColor = System.Drawing.Color.Yellow;
            this.openPartitions.FlatAppearance.BorderSize = 0;
            this.openPartitions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.openPartitions.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openPartitions.Location = new System.Drawing.Point(0, 19);
            this.openPartitions.Name = "openPartitions";
            this.openPartitions.Size = new System.Drawing.Size(120, 17);
            this.openPartitions.TabIndex = 90;
            this.openPartitions.Text = "Find Partition...";
            this.openPartitions.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.openPartitions.UseCompatibleTextRendering = true;
            this.openPartitions.UseVisualStyleBackColor = false;
            this.openPartitions.Click += new System.EventHandler(this.openPartitions_Click);
            // 
            // panel118
            // 
            this.panel118.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.panel118.Controls.Add(this.label52);
            this.panel118.Controls.Add(this.panel119);
            this.panel118.Location = new System.Drawing.Point(120, 503);
            this.panel118.Name = "panel118";
            this.panel118.Size = new System.Drawing.Size(120, 36);
            this.panel118.TabIndex = 479;
            // 
            // label52
            // 
            this.label52.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label52.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label52.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label52.Location = new System.Drawing.Point(0, 0);
            this.label52.Name = "label52";
            this.label52.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label52.Size = new System.Drawing.Size(120, 17);
            this.label52.TabIndex = 478;
            this.label52.Text = "AFTER BATTLE...";
            // 
            // panel119
            // 
            this.panel119.BackColor = System.Drawing.SystemColors.Window;
            this.panel119.Controls.Add(this.npcAfterBattle);
            this.panel119.Location = new System.Drawing.Point(0, 19);
            this.panel119.Name = "panel119";
            this.panel119.Size = new System.Drawing.Size(120, 17);
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
            this.npcAfterBattle.Size = new System.Drawing.Size(125, 21);
            this.npcAfterBattle.TabIndex = 205;
            this.npcAfterBattle.SelectedIndexChanged += new System.EventHandler(this.npcAfterBattle_SelectedIndexChanged);
            // 
            // label112
            // 
            this.label112.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label112.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label112.ForeColor = System.Drawing.SystemColors.Control;
            this.label112.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label112.Location = new System.Drawing.Point(0, 0);
            this.label112.Name = "label112";
            this.label112.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label112.Size = new System.Drawing.Size(240, 17);
            this.label112.TabIndex = 478;
            this.label112.Text = "NPCS";
            this.label112.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // npcObjectTree
            // 
            this.npcObjectTree.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.npcObjectTree.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.npcObjectTree.HideSelection = false;
            this.npcObjectTree.HotTracking = true;
            this.npcObjectTree.Location = new System.Drawing.Point(0, 19);
            this.npcObjectTree.Name = "npcObjectTree";
            this.npcObjectTree.ShowPlusMinus = false;
            this.npcObjectTree.ShowRootLines = false;
            this.npcObjectTree.Size = new System.Drawing.Size(118, 307);
            this.npcObjectTree.TabIndex = 91;
            this.npcObjectTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.npcObjectTree_AfterSelect);
            // 
            // label36
            // 
            this.label36.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label36.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label36.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label36.ForeColor = System.Drawing.SystemColors.Control;
            this.label36.Location = new System.Drawing.Point(327, 1);
            this.label36.Name = "label36";
            this.label36.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label36.Size = new System.Drawing.Size(88, 17);
            this.label36.TabIndex = 137;
            this.label36.Text = "LEVEL #";
            // 
            // mapNum
            // 
            this.mapNum.BackColor = System.Drawing.SystemColors.ControlDark;
            this.mapNum.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.mapNum.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mapNum.ForeColor = System.Drawing.SystemColors.Control;
            this.mapNum.Location = new System.Drawing.Point(119, 0);
            this.mapNum.Maximum = new decimal(new int[] {
            155,
            0,
            0,
            0});
            this.mapNum.Name = "mapNum";
            this.mapNum.Size = new System.Drawing.Size(122, 17);
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
            this.label33.Size = new System.Drawing.Size(118, 17);
            this.label33.TabIndex = 15;
            this.label33.Text = "MAP #";
            // 
            // levelNum
            // 
            this.levelNum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.levelNum.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.levelNum.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.levelNum.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.levelNum.ForeColor = System.Drawing.SystemColors.Control;
            this.levelNum.Location = new System.Drawing.Point(416, 1);
            this.levelNum.Maximum = new decimal(new int[] {
            509,
            0,
            0,
            0});
            this.levelNum.Name = "levelNum";
            this.levelNum.Size = new System.Drawing.Size(105, 17);
            this.levelNum.TabIndex = 5;
            this.levelNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.levelNum.ValueChanged += new System.EventHandler(this.levelNum_ValueChanged);
            // 
            // levelName
            // 
            this.levelName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.levelName.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.levelName.ContextMenuStrip = this.contextMenuStrip4;
            this.levelName.DropDownHeight = 626;
            this.levelName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.levelName.DropDownWidth = 550;
            this.levelName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.levelName.ForeColor = System.Drawing.SystemColors.Control;
            this.levelName.IntegralHeight = false;
            this.levelName.Location = new System.Drawing.Point(-2, -2);
            this.levelName.Name = "levelName";
            this.levelName.Size = new System.Drawing.Size(257, 21);
            this.levelName.TabIndex = 116;
            this.levelName.SelectedIndexChanged += new System.EventHandler(this.levelName_SelectedIndexChanged);
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
            this.label19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label19.Location = new System.Drawing.Point(0, 91);
            this.label19.Name = "label19";
            this.label19.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label19.Size = new System.Drawing.Size(74, 17);
            this.label19.TabIndex = 9;
            this.label19.Text = "GFX Set 5";
            // 
            // label18
            // 
            this.label18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label18.Location = new System.Drawing.Point(0, 73);
            this.label18.Name = "label18";
            this.label18.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label18.Size = new System.Drawing.Size(74, 17);
            this.label18.TabIndex = 8;
            this.label18.Text = "GFX Set 4";
            // 
            // label17
            // 
            this.label17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label17.Location = new System.Drawing.Point(0, 55);
            this.label17.Name = "label17";
            this.label17.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label17.Size = new System.Drawing.Size(74, 17);
            this.label17.TabIndex = 7;
            this.label17.Text = "GFX Set 3";
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label16.Location = new System.Drawing.Point(0, 37);
            this.label16.Name = "label16";
            this.label16.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label16.Size = new System.Drawing.Size(74, 17);
            this.label16.TabIndex = 6;
            this.label16.Text = "GFX Set 2";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label2.Location = new System.Drawing.Point(0, 19);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label2.Size = new System.Drawing.Size(74, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "GFX Set 1";
            // 
            // tabPage10
            // 
            this.tabPage10.BackColor = System.Drawing.SystemColors.ControlText;
            this.tabPage10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPage10.Controls.Add(this.panel8);
            this.tabPage10.Controls.Add(this.overlapShowTileset);
            this.tabPage10.Controls.Add(this.panel99);
            this.tabPage10.Controls.Add(this.panel62);
            this.tabPage10.Controls.Add(this.overlapFieldDelete);
            this.tabPage10.Controls.Add(this.overlapFieldInsert);
            this.tabPage10.Controls.Add(this.overlapFieldTree);
            this.tabPage10.Controls.Add(this.label51);
            this.tabPage10.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage10.Location = new System.Drawing.Point(4, 22);
            this.tabPage10.Name = "tabPage10";
            this.tabPage10.Size = new System.Drawing.Size(244, 610);
            this.tabPage10.TabIndex = 4;
            this.tabPage10.Text = "OVERLAP";
            this.tabPage10.UseVisualStyleBackColor = true;
            // 
            // panel8
            // 
            this.panel8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.panel8.BackgroundImage = global::LAZYSHELL.Properties.Resources._bg;
            this.panel8.Location = new System.Drawing.Point(1, 341);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(240, 266);
            this.panel8.TabIndex = 496;
            // 
            // overlapShowTileset
            // 
            this.overlapShowTileset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.overlapShowTileset.FlatAppearance.BorderSize = 0;
            this.overlapShowTileset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.overlapShowTileset.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.overlapShowTileset.Location = new System.Drawing.Point(120, 20);
            this.overlapShowTileset.Name = "overlapShowTileset";
            this.overlapShowTileset.Size = new System.Drawing.Size(121, 17);
            this.overlapShowTileset.TabIndex = 493;
            this.overlapShowTileset.Text = "OVERLAP TILESET";
            this.overlapShowTileset.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.overlapShowTileset, "Show / Hide Overlap Tiles");
            this.overlapShowTileset.UseCompatibleTextRendering = true;
            this.overlapShowTileset.UseVisualStyleBackColor = false;
            this.overlapShowTileset.Click += new System.EventHandler(this.overlapShowTileset_Click);
            // 
            // panel99
            // 
            this.panel99.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.panel99.Controls.Add(this.overlapCoordZPlusHalf);
            this.panel99.Controls.Add(this.label130);
            this.panel99.Controls.Add(this.label109);
            this.panel99.Controls.Add(this.label103);
            this.panel99.Controls.Add(this.label107);
            this.panel99.Controls.Add(this.overlapType);
            this.panel99.Controls.Add(this.overlapCoordX);
            this.panel99.Controls.Add(this.overlapCoordY);
            this.panel99.Controls.Add(this.overlapCoordZ);
            this.panel99.Controls.Add(this.label106);
            this.panel99.Location = new System.Drawing.Point(120, 39);
            this.panel99.Name = "panel99";
            this.panel99.Size = new System.Drawing.Size(121, 108);
            this.panel99.TabIndex = 495;
            // 
            // overlapCoordZPlusHalf
            // 
            this.overlapCoordZPlusHalf.Appearance = System.Windows.Forms.Appearance.Button;
            this.overlapCoordZPlusHalf.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(220)))), ((int)(((byte)(212)))));
            this.overlapCoordZPlusHalf.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.overlapCoordZPlusHalf.FlatAppearance.BorderSize = 0;
            this.overlapCoordZPlusHalf.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(168)))), ((int)(((byte)(168)))));
            this.overlapCoordZPlusHalf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.overlapCoordZPlusHalf.ForeColor = System.Drawing.Color.Gray;
            this.overlapCoordZPlusHalf.Location = new System.Drawing.Point(0, 91);
            this.overlapCoordZPlusHalf.Name = "overlapCoordZPlusHalf";
            this.overlapCoordZPlusHalf.Size = new System.Drawing.Size(121, 17);
            this.overlapCoordZPlusHalf.TabIndex = 493;
            this.overlapCoordZPlusHalf.Text = "Z Coord +½";
            this.overlapCoordZPlusHalf.UseCompatibleTextRendering = true;
            this.overlapCoordZPlusHalf.UseVisualStyleBackColor = false;
            this.overlapCoordZPlusHalf.CheckedChanged += new System.EventHandler(this.overlapCoordZPlusHalf_CheckedChanged);
            // 
            // label130
            // 
            this.label130.BackColor = System.Drawing.SystemColors.Control;
            this.label130.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label130.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label130.Location = new System.Drawing.Point(0, 0);
            this.label130.Name = "label130";
            this.label130.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label130.Size = new System.Drawing.Size(121, 17);
            this.label130.TabIndex = 475;
            this.label130.Text = "PROPERTIES...";
            this.label130.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label109
            // 
            this.label109.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label109.Location = new System.Drawing.Point(0, 19);
            this.label109.Name = "label109";
            this.label109.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label109.Size = new System.Drawing.Size(58, 17);
            this.label109.TabIndex = 489;
            this.label109.Text = "Tile #";
            // 
            // label103
            // 
            this.label103.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label103.Location = new System.Drawing.Point(0, 37);
            this.label103.Name = "label103";
            this.label103.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label103.Size = new System.Drawing.Size(58, 17);
            this.label103.TabIndex = 489;
            this.label103.Text = "X Coord";
            // 
            // label107
            // 
            this.label107.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label107.Location = new System.Drawing.Point(0, 73);
            this.label107.Name = "label107";
            this.label107.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label107.Size = new System.Drawing.Size(58, 17);
            this.label107.TabIndex = 491;
            this.label107.Text = "Z Coord";
            // 
            // overlapType
            // 
            this.overlapType.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.overlapType.Location = new System.Drawing.Point(59, 19);
            this.overlapType.Maximum = new decimal(new int[] {
            103,
            0,
            0,
            0});
            this.overlapType.Name = "overlapType";
            this.overlapType.Size = new System.Drawing.Size(63, 17);
            this.overlapType.TabIndex = 492;
            this.overlapType.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.overlapType.ValueChanged += new System.EventHandler(this.overlapType_ValueChanged);
            // 
            // overlapCoordX
            // 
            this.overlapCoordX.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.overlapCoordX.Location = new System.Drawing.Point(59, 37);
            this.overlapCoordX.Maximum = new decimal(new int[] {
            63,
            0,
            0,
            0});
            this.overlapCoordX.Name = "overlapCoordX";
            this.overlapCoordX.Size = new System.Drawing.Size(63, 17);
            this.overlapCoordX.TabIndex = 486;
            this.overlapCoordX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.overlapCoordX.ValueChanged += new System.EventHandler(this.overlapCoordX_ValueChanged);
            // 
            // overlapCoordY
            // 
            this.overlapCoordY.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.overlapCoordY.Location = new System.Drawing.Point(59, 55);
            this.overlapCoordY.Maximum = new decimal(new int[] {
            127,
            0,
            0,
            0});
            this.overlapCoordY.Name = "overlapCoordY";
            this.overlapCoordY.Size = new System.Drawing.Size(63, 17);
            this.overlapCoordY.TabIndex = 487;
            this.overlapCoordY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.overlapCoordY.ValueChanged += new System.EventHandler(this.overlapCoordY_ValueChanged);
            // 
            // overlapCoordZ
            // 
            this.overlapCoordZ.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.overlapCoordZ.Location = new System.Drawing.Point(59, 73);
            this.overlapCoordZ.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.overlapCoordZ.Name = "overlapCoordZ";
            this.overlapCoordZ.Size = new System.Drawing.Size(63, 17);
            this.overlapCoordZ.TabIndex = 488;
            this.overlapCoordZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.overlapCoordZ.ValueChanged += new System.EventHandler(this.overlapCoordZ_ValueChanged);
            // 
            // label106
            // 
            this.label106.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label106.Location = new System.Drawing.Point(0, 55);
            this.label106.Name = "label106";
            this.label106.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label106.Size = new System.Drawing.Size(58, 17);
            this.label106.TabIndex = 490;
            this.label106.Text = "Y Coord";
            // 
            // panel62
            // 
            this.panel62.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.panel62.Controls.Add(this.label132);
            this.panel62.Controls.Add(this.overlapUnknownBits);
            this.panel62.Location = new System.Drawing.Point(120, 149);
            this.panel62.Name = "panel62";
            this.panel62.Size = new System.Drawing.Size(121, 190);
            this.panel62.TabIndex = 494;
            // 
            // label132
            // 
            this.label132.BackColor = System.Drawing.SystemColors.Control;
            this.label132.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label132.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label132.Location = new System.Drawing.Point(0, 0);
            this.label132.Name = "label132";
            this.label132.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label132.Size = new System.Drawing.Size(121, 17);
            this.label132.TabIndex = 475;
            this.label132.Text = "UNKNOWN BITS...";
            this.label132.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // overlapUnknownBits
            // 
            this.overlapUnknownBits.BackColor = System.Drawing.SystemColors.Window;
            this.overlapUnknownBits.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.overlapUnknownBits.CheckOnClick = true;
            this.overlapUnknownBits.ColumnWidth = 60;
            this.overlapUnknownBits.IntegralHeight = false;
            this.overlapUnknownBits.Items.AddRange(new object[] {
            "overlap tile edges",
            "{B2,b5}",
            "{B2,b6}",
            "{B2,b7}"});
            this.overlapUnknownBits.Location = new System.Drawing.Point(0, 19);
            this.overlapUnknownBits.Name = "overlapUnknownBits";
            this.overlapUnknownBits.Size = new System.Drawing.Size(121, 171);
            this.overlapUnknownBits.TabIndex = 123;
            this.overlapUnknownBits.SelectedIndexChanged += new System.EventHandler(this.overlapUnknownBits_SelectedIndexChanged);
            // 
            // overlapFieldDelete
            // 
            this.overlapFieldDelete.BackColor = System.Drawing.SystemColors.Window;
            this.overlapFieldDelete.FlatAppearance.BorderSize = 0;
            this.overlapFieldDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.overlapFieldDelete.Location = new System.Drawing.Point(60, 322);
            this.overlapFieldDelete.Name = "overlapFieldDelete";
            this.overlapFieldDelete.Size = new System.Drawing.Size(58, 17);
            this.overlapFieldDelete.TabIndex = 455;
            this.overlapFieldDelete.Text = "DELETE";
            this.overlapFieldDelete.UseCompatibleTextRendering = true;
            this.overlapFieldDelete.UseVisualStyleBackColor = false;
            this.overlapFieldDelete.Click += new System.EventHandler(this.overlapFieldDelete_Click);
            // 
            // overlapFieldInsert
            // 
            this.overlapFieldInsert.BackColor = System.Drawing.SystemColors.Window;
            this.overlapFieldInsert.FlatAppearance.BorderSize = 0;
            this.overlapFieldInsert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.overlapFieldInsert.Location = new System.Drawing.Point(1, 322);
            this.overlapFieldInsert.Name = "overlapFieldInsert";
            this.overlapFieldInsert.Size = new System.Drawing.Size(58, 17);
            this.overlapFieldInsert.TabIndex = 454;
            this.overlapFieldInsert.Text = "INSERT";
            this.overlapFieldInsert.UseCompatibleTextRendering = true;
            this.overlapFieldInsert.UseVisualStyleBackColor = false;
            this.overlapFieldInsert.Click += new System.EventHandler(this.overlapFieldInsert_Click);
            // 
            // overlapFieldTree
            // 
            this.overlapFieldTree.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.overlapFieldTree.HideSelection = false;
            this.overlapFieldTree.HotTracking = true;
            this.overlapFieldTree.Location = new System.Drawing.Point(1, 20);
            this.overlapFieldTree.Name = "overlapFieldTree";
            this.overlapFieldTree.ShowRootLines = false;
            this.overlapFieldTree.Size = new System.Drawing.Size(117, 300);
            this.overlapFieldTree.TabIndex = 456;
            this.overlapFieldTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.overlapFieldTree_AfterSelect);
            // 
            // label51
            // 
            this.label51.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label51.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label51.ForeColor = System.Drawing.SystemColors.Control;
            this.label51.Location = new System.Drawing.Point(1, 1);
            this.label51.Name = "label51";
            this.label51.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label51.Size = new System.Drawing.Size(240, 17);
            this.label51.TabIndex = 457;
            this.label51.Text = "OVERLAP OBJECTS";
            this.label51.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabPage9
            // 
            this.tabPage9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPage9.Controls.Add(this.panel52);
            this.tabPage9.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage9.Location = new System.Drawing.Point(4, 22);
            this.tabPage9.Name = "tabPage9";
            this.tabPage9.Size = new System.Drawing.Size(244, 610);
            this.tabPage9.TabIndex = 3;
            this.tabPage9.Text = "FIELD";
            this.tabPage9.UseVisualStyleBackColor = true;
            // 
            // panel52
            // 
            this.panel52.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.panel52.BackColor = System.Drawing.SystemColors.ControlText;
            this.panel52.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel52.Controls.Add(this.panel90);
            this.panel52.Controls.Add(this.panel89);
            this.panel52.Controls.Add(this.panel88);
            this.panel52.Controls.Add(this.panel87);
            this.panel52.Controls.Add(this.panel68);
            this.panel52.Controls.Add(this.eventsDeleteField);
            this.panel52.Controls.Add(this.eventsInsertField);
            this.panel52.Controls.Add(this.label63);
            this.panel52.Controls.Add(this.exitsDeleteField);
            this.panel52.Controls.Add(this.exitsInsertField);
            this.panel52.Controls.Add(this.exitsFieldTree);
            this.panel52.Controls.Add(this.eventsFieldTree);
            this.panel52.Controls.Add(this.label61);
            this.panel52.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel52.Location = new System.Drawing.Point(0, 0);
            this.panel52.Name = "panel52";
            this.panel52.Size = new System.Drawing.Size(242, 608);
            this.panel52.TabIndex = 0;
            // 
            // panel90
            // 
            this.panel90.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.panel90.Controls.Add(this.buttonGotoD);
            this.panel90.Controls.Add(this.label62);
            this.panel90.Controls.Add(this.label127);
            this.panel90.Controls.Add(this.eventsFieldLength);
            this.panel90.Controls.Add(this.label129);
            this.panel90.Controls.Add(this.eventsFieldYCoord);
            this.panel90.Controls.Add(this.eventsWidthYPlusHalf);
            this.panel90.Controls.Add(this.label131);
            this.panel90.Controls.Add(this.eventsWidthXPlusHalf);
            this.panel90.Controls.Add(this.eventsFieldXCoord);
            this.panel90.Controls.Add(this.eventsLengthOverOne);
            this.panel90.Controls.Add(this.eventsFieldZCoord);
            this.panel90.Controls.Add(this.panel46);
            this.panel90.Controls.Add(this.eventsFieldHeight);
            this.panel90.Controls.Add(this.label133);
            this.panel90.Controls.Add(this.label135);
            this.panel90.Controls.Add(this.label137);
            this.panel90.Controls.Add(this.eventsRunEvent);
            this.panel90.Location = new System.Drawing.Point(119, 424);
            this.panel90.Name = "panel90";
            this.panel90.Size = new System.Drawing.Size(121, 182);
            this.panel90.TabIndex = 497;
            // 
            // buttonGotoD
            // 
            this.buttonGotoD.BackColor = System.Drawing.Color.Lime;
            this.buttonGotoD.FlatAppearance.BorderSize = 0;
            this.buttonGotoD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGotoD.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonGotoD.Location = new System.Drawing.Point(0, 38);
            this.buttonGotoD.Name = "buttonGotoD";
            this.buttonGotoD.Size = new System.Drawing.Size(58, 17);
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
            this.label62.Size = new System.Drawing.Size(121, 17);
            this.label62.TabIndex = 452;
            this.label62.Text = "FIELD PROPERTIES";
            this.label62.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label127
            // 
            this.label127.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label127.Location = new System.Drawing.Point(0, 56);
            this.label127.Name = "label127";
            this.label127.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label127.Size = new System.Drawing.Size(58, 17);
            this.label127.TabIndex = 473;
            this.label127.Text = "X Coord";
            // 
            // eventsFieldLength
            // 
            this.eventsFieldLength.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.eventsFieldLength.Location = new System.Drawing.Point(59, 110);
            this.eventsFieldLength.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.eventsFieldLength.Name = "eventsFieldLength";
            this.eventsFieldLength.Size = new System.Drawing.Size(63, 17);
            this.eventsFieldLength.TabIndex = 153;
            this.eventsFieldLength.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.eventsFieldLength.ValueChanged += new System.EventHandler(this.eventsFieldLength_ValueChanged);
            // 
            // label129
            // 
            this.label129.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label129.Location = new System.Drawing.Point(0, 74);
            this.label129.Name = "label129";
            this.label129.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label129.Size = new System.Drawing.Size(58, 17);
            this.label129.TabIndex = 477;
            this.label129.Text = "Y Coord";
            // 
            // eventsFieldYCoord
            // 
            this.eventsFieldYCoord.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.eventsFieldYCoord.Location = new System.Drawing.Point(59, 74);
            this.eventsFieldYCoord.Maximum = new decimal(new int[] {
            127,
            0,
            0,
            0});
            this.eventsFieldYCoord.Name = "eventsFieldYCoord";
            this.eventsFieldYCoord.Size = new System.Drawing.Size(63, 17);
            this.eventsFieldYCoord.TabIndex = 151;
            this.eventsFieldYCoord.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.eventsFieldYCoord.ValueChanged += new System.EventHandler(this.eventsFieldYCoord_ValueChanged);
            // 
            // eventsWidthYPlusHalf
            // 
            this.eventsWidthYPlusHalf.Appearance = System.Windows.Forms.Appearance.Button;
            this.eventsWidthYPlusHalf.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(220)))), ((int)(((byte)(212)))));
            this.eventsWidthYPlusHalf.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.eventsWidthYPlusHalf.FlatAppearance.BorderSize = 0;
            this.eventsWidthYPlusHalf.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(168)))), ((int)(((byte)(168)))));
            this.eventsWidthYPlusHalf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.eventsWidthYPlusHalf.ForeColor = System.Drawing.Color.Gray;
            this.eventsWidthYPlusHalf.Location = new System.Drawing.Point(59, 165);
            this.eventsWidthYPlusHalf.Name = "eventsWidthYPlusHalf";
            this.eventsWidthYPlusHalf.Size = new System.Drawing.Size(62, 17);
            this.eventsWidthYPlusHalf.TabIndex = 157;
            this.eventsWidthYPlusHalf.Text = "135°+½";
            this.eventsWidthYPlusHalf.UseCompatibleTextRendering = true;
            this.eventsWidthYPlusHalf.UseVisualStyleBackColor = false;
            this.eventsWidthYPlusHalf.CheckedChanged += new System.EventHandler(this.eventsWidthYPlusHalf_CheckedChanged);
            // 
            // label131
            // 
            this.label131.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label131.Location = new System.Drawing.Point(0, 110);
            this.label131.Name = "label131";
            this.label131.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label131.Size = new System.Drawing.Size(58, 17);
            this.label131.TabIndex = 471;
            this.label131.Text = "Length";
            // 
            // eventsWidthXPlusHalf
            // 
            this.eventsWidthXPlusHalf.Appearance = System.Windows.Forms.Appearance.Button;
            this.eventsWidthXPlusHalf.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(220)))), ((int)(((byte)(212)))));
            this.eventsWidthXPlusHalf.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.eventsWidthXPlusHalf.FlatAppearance.BorderSize = 0;
            this.eventsWidthXPlusHalf.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(168)))), ((int)(((byte)(168)))));
            this.eventsWidthXPlusHalf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.eventsWidthXPlusHalf.ForeColor = System.Drawing.Color.Gray;
            this.eventsWidthXPlusHalf.Location = new System.Drawing.Point(0, 165);
            this.eventsWidthXPlusHalf.Name = "eventsWidthXPlusHalf";
            this.eventsWidthXPlusHalf.Size = new System.Drawing.Size(58, 17);
            this.eventsWidthXPlusHalf.TabIndex = 156;
            this.eventsWidthXPlusHalf.Text = "45°+½";
            this.eventsWidthXPlusHalf.UseCompatibleTextRendering = true;
            this.eventsWidthXPlusHalf.UseVisualStyleBackColor = false;
            this.eventsWidthXPlusHalf.CheckedChanged += new System.EventHandler(this.eventsWidthXPlusHalf_CheckedChanged);
            // 
            // eventsFieldXCoord
            // 
            this.eventsFieldXCoord.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.eventsFieldXCoord.Location = new System.Drawing.Point(59, 56);
            this.eventsFieldXCoord.Maximum = new decimal(new int[] {
            63,
            0,
            0,
            0});
            this.eventsFieldXCoord.Name = "eventsFieldXCoord";
            this.eventsFieldXCoord.Size = new System.Drawing.Size(63, 17);
            this.eventsFieldXCoord.TabIndex = 150;
            this.eventsFieldXCoord.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.eventsFieldXCoord.ValueChanged += new System.EventHandler(this.eventsFieldXCoord_ValueChanged);
            // 
            // eventsLengthOverOne
            // 
            this.eventsLengthOverOne.Appearance = System.Windows.Forms.Appearance.Button;
            this.eventsLengthOverOne.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(220)))), ((int)(((byte)(212)))));
            this.eventsLengthOverOne.FlatAppearance.BorderSize = 0;
            this.eventsLengthOverOne.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(168)))), ((int)(((byte)(168)))));
            this.eventsLengthOverOne.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.eventsLengthOverOne.ForeColor = System.Drawing.Color.Gray;
            this.eventsLengthOverOne.Location = new System.Drawing.Point(0, 19);
            this.eventsLengthOverOne.Name = "eventsLengthOverOne";
            this.eventsLengthOverOne.Size = new System.Drawing.Size(121, 17);
            this.eventsLengthOverOne.TabIndex = 145;
            this.eventsLengthOverOne.Text = "LENGTH > 1";
            this.eventsLengthOverOne.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.eventsLengthOverOne.UseCompatibleTextRendering = true;
            this.eventsLengthOverOne.UseVisualStyleBackColor = false;
            this.eventsLengthOverOne.CheckedChanged += new System.EventHandler(this.eventsLengthOverOne_CheckedChanged);
            // 
            // eventsFieldZCoord
            // 
            this.eventsFieldZCoord.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.eventsFieldZCoord.Location = new System.Drawing.Point(59, 92);
            this.eventsFieldZCoord.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.eventsFieldZCoord.Name = "eventsFieldZCoord";
            this.eventsFieldZCoord.Size = new System.Drawing.Size(63, 17);
            this.eventsFieldZCoord.TabIndex = 152;
            this.eventsFieldZCoord.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.eventsFieldZCoord.ValueChanged += new System.EventHandler(this.eventsFieldZCoord_ValueChanged);
            // 
            // panel46
            // 
            this.panel46.BackColor = System.Drawing.SystemColors.Window;
            this.panel46.Controls.Add(this.eventsFieldRadialPosition);
            this.panel46.Location = new System.Drawing.Point(59, 146);
            this.panel46.Name = "panel46";
            this.panel46.Size = new System.Drawing.Size(63, 17);
            this.panel46.TabIndex = 155;
            // 
            // eventsFieldRadialPosition
            // 
            this.eventsFieldRadialPosition.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.eventsFieldRadialPosition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.eventsFieldRadialPosition.DropDownWidth = 60;
            this.eventsFieldRadialPosition.Items.AddRange(new object[] {
            "UR to DL",
            "DR to UL"});
            this.eventsFieldRadialPosition.Location = new System.Drawing.Point(-2, -2);
            this.eventsFieldRadialPosition.Name = "eventsFieldRadialPosition";
            this.eventsFieldRadialPosition.Size = new System.Drawing.Size(67, 21);
            this.eventsFieldRadialPosition.TabIndex = 211;
            this.eventsFieldRadialPosition.SelectedIndexChanged += new System.EventHandler(this.eventsFieldRadialPosition_SelectedIndexChanged);
            // 
            // eventsFieldHeight
            // 
            this.eventsFieldHeight.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.eventsFieldHeight.Location = new System.Drawing.Point(59, 128);
            this.eventsFieldHeight.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.eventsFieldHeight.Name = "eventsFieldHeight";
            this.eventsFieldHeight.Size = new System.Drawing.Size(63, 17);
            this.eventsFieldHeight.TabIndex = 154;
            this.eventsFieldHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.eventsFieldHeight.ValueChanged += new System.EventHandler(this.eventsFieldHeight_ValueChanged);
            // 
            // label133
            // 
            this.label133.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label133.Location = new System.Drawing.Point(0, 92);
            this.label133.Name = "label133";
            this.label133.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label133.Size = new System.Drawing.Size(58, 17);
            this.label133.TabIndex = 486;
            this.label133.Text = "Z Coord";
            // 
            // label135
            // 
            this.label135.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label135.Location = new System.Drawing.Point(0, 128);
            this.label135.Name = "label135";
            this.label135.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label135.Size = new System.Drawing.Size(58, 17);
            this.label135.TabIndex = 484;
            this.label135.Text = "Height";
            // 
            // label137
            // 
            this.label137.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label137.Location = new System.Drawing.Point(0, 146);
            this.label137.Name = "label137";
            this.label137.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label137.Size = new System.Drawing.Size(58, 17);
            this.label137.TabIndex = 489;
            this.label137.Text = "Facing";
            // 
            // eventsRunEvent
            // 
            this.eventsRunEvent.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.eventsRunEvent.Location = new System.Drawing.Point(59, 38);
            this.eventsRunEvent.Maximum = new decimal(new int[] {
            4095,
            0,
            0,
            0});
            this.eventsRunEvent.Name = "eventsRunEvent";
            this.eventsRunEvent.Size = new System.Drawing.Size(63, 17);
            this.eventsRunEvent.TabIndex = 149;
            this.eventsRunEvent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.eventsRunEvent.ValueChanged += new System.EventHandler(this.eventsRunEvent_ValueChanged);
            // 
            // panel89
            // 
            this.panel89.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.panel89.Controls.Add(this.buttonGotoC);
            this.panel89.Controls.Add(this.label1);
            this.panel89.Controls.Add(this.label125);
            this.panel89.Controls.Add(this.eventsExitEvent);
            this.panel89.Controls.Add(this.panel47);
            this.panel89.Location = new System.Drawing.Point(119, 368);
            this.panel89.Name = "panel89";
            this.panel89.Size = new System.Drawing.Size(121, 54);
            this.panel89.TabIndex = 496;
            // 
            // buttonGotoC
            // 
            this.buttonGotoC.BackColor = System.Drawing.Color.Lime;
            this.buttonGotoC.FlatAppearance.BorderSize = 0;
            this.buttonGotoC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGotoC.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonGotoC.Location = new System.Drawing.Point(0, 37);
            this.buttonGotoC.Name = "buttonGotoC";
            this.buttonGotoC.Size = new System.Drawing.Size(58, 17);
            this.buttonGotoC.TabIndex = 492;
            this.buttonGotoC.Text = "Event #";
            this.buttonGotoC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.buttonGotoC, "Edit level entrance event...");
            this.buttonGotoC.UseCompatibleTextRendering = true;
            this.buttonGotoC.UseVisualStyleBackColor = false;
            this.buttonGotoC.Click += new System.EventHandler(this.buttonGotoC_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label1.Size = new System.Drawing.Size(121, 17);
            this.label1.TabIndex = 452;
            this.label1.Text = "LEVEL PROPERTIES";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label125
            // 
            this.label125.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label125.Location = new System.Drawing.Point(0, 19);
            this.label125.Name = "label125";
            this.label125.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label125.Size = new System.Drawing.Size(58, 17);
            this.label125.TabIndex = 491;
            this.label125.Text = "Music";
            // 
            // eventsExitEvent
            // 
            this.eventsExitEvent.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.eventsExitEvent.Location = new System.Drawing.Point(59, 37);
            this.eventsExitEvent.Maximum = new decimal(new int[] {
            4095,
            0,
            0,
            0});
            this.eventsExitEvent.Name = "eventsExitEvent";
            this.eventsExitEvent.Size = new System.Drawing.Size(63, 17);
            this.eventsExitEvent.TabIndex = 148;
            this.eventsExitEvent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.eventsExitEvent.ValueChanged += new System.EventHandler(this.eventsExitEvent_ValueChanged);
            // 
            // panel47
            // 
            this.panel47.BackColor = System.Drawing.SystemColors.Window;
            this.panel47.Controls.Add(this.eventsAreaMusic);
            this.panel47.Location = new System.Drawing.Point(59, 19);
            this.panel47.Name = "panel47";
            this.panel47.Size = new System.Drawing.Size(64, 17);
            this.panel47.TabIndex = 147;
            // 
            // eventsAreaMusic
            // 
            this.eventsAreaMusic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.eventsAreaMusic.DropDownHeight = 327;
            this.eventsAreaMusic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.eventsAreaMusic.DropDownWidth = 250;
            this.eventsAreaMusic.IntegralHeight = false;
            this.eventsAreaMusic.Items.AddRange(new object[] {
            "[00]  {CURRENT}",
            "[01]  Dodo\'s Coming",
            "[02]  Mushroom Kingdom",
            "[03]  Fight Against Stronger Monster",
            "[04]  Yo\'ster Island",
            "[05]  Seaside Town",
            "[06]  Fight Against Monsters",
            "[07]  Pipe Vault",
            "[08]  Invincible Star",
            "[09]  Victory",
            "[10]  In The Flower Garden",
            "[11]  Bowser\'s Castle (1st time)",
            "[12]  Fight Against Bowser",
            "[13]  Road Is Full Of Dangers",
            "[14]  Mario\'s Pad",
            "[15]  Here\'s Some Weapons",
            "[16]  Let\'s Race",
            "[17]  Tadpole Pond",
            "[18]  Rose Town",
            "[19]  Race Training",
            "[20]  Shock!",
            "[21]  Sad Song",
            "[22]  Midas River",
            "[23]  Got A Star Piece (part 1)",
            "[24]  Got A Star Piece (part 2)",
            "[25]  Fight Against An Armed Boss",
            "[26]  Forest Maze",
            "[27]  Dungeon Is Full Of Monsters",
            "[28]  Let\'s Play Geno",
            "[29]  Start Slot Menu",
            "[30]  Long Long Ago",
            "[31]  Booster\'s Tower",
            "[32]  And My Name\'s Booster",
            "[33]  Moleville",
            "[34]  Star Hill",
            "[35]  Mountain Railroad",
            "[36]  Explanation",
            "[37]  Booster Hill (start)",
            "[38]  Booster Hill",
            "[39]  Marrymore",
            "[40]  New Partner",
            "[41]  Sunken Ship",
            "[42]  Still The Road Is Full Of Monsters",
            "[43]  {SILENCE}",
            "[44]  Sea",
            "[45]  Heart Beating A Little Faster (part 1)",
            "[46]  Heart Beating A Little Faster (part 2)",
            "[47]  Grate Guy\'s Casino",
            "[48]  Geno Awakens",
            "[49]  Celebrational",
            "[50]  Nimbus Land",
            "[51]  Monstro Town",
            "[52]  Toadofsky",
            "[53]  {SILENCE}",
            "[54]  Happy Adventure, Delighful Adventure",
            "[55]  World Map",
            "[56]  Factory",
            "[57]  Sword Crashes And Stars Scatter",
            "[58]  Conversation With Culex",
            "[59]  Fight Against Culex",
            "[60]  Victory Against Culex",
            "[61]  Valentina",
            "[62]  Barrel Volcano",
            "[63]  Axem Rangers Drop In",
            "[64]  The End",
            "[65]  Gate",
            "[66]  Bowser\'s Castle (2nd time)",
            "[67]  Weapons Factory",
            "[68]  Fight Against Smithy 1",
            "[69]  Fight Against Smithy 2",
            "[70]  Ending Part 1",
            "[71]  Ending Part 2",
            "[72]  Ending Part 3",
            "[73]  Ending Part 4",
            "[74]  {SILENCE}",
            "[75]  {SILENCE}",
            "[76]  {SILENCE}",
            "[77]  {SILENCE}",
            "[78]  {SILENCE}",
            "[79]  {SILENCE}"});
            this.eventsAreaMusic.Location = new System.Drawing.Point(-3, -2);
            this.eventsAreaMusic.Name = "eventsAreaMusic";
            this.eventsAreaMusic.Size = new System.Drawing.Size(68, 21);
            this.eventsAreaMusic.TabIndex = 234;
            this.eventsAreaMusic.SelectedIndexChanged += new System.EventHandler(this.eventsAreaMusic_SelectedIndexChanged);
            // 
            // panel88
            // 
            this.panel88.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.panel88.Controls.Add(this.label66);
            this.panel88.Controls.Add(this.label59);
            this.panel88.Controls.Add(this.exitsMarioYCoord);
            this.panel88.Controls.Add(this.marioZCoordPlusHalf);
            this.panel88.Controls.Add(this.label60);
            this.panel88.Controls.Add(this.exitsMarioXCoord);
            this.panel88.Controls.Add(this.exitsMarioZCoord);
            this.panel88.Controls.Add(this.label122);
            this.panel88.Controls.Add(this.label124);
            this.panel88.Controls.Add(this.panel48);
            this.panel88.Location = new System.Drawing.Point(119, 238);
            this.panel88.Name = "panel88";
            this.panel88.Size = new System.Drawing.Size(121, 109);
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
            this.label66.Size = new System.Drawing.Size(121, 17);
            this.label66.TabIndex = 457;
            this.label66.Text = "DEST. COORDS";
            this.label66.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label59
            // 
            this.label59.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label59.Location = new System.Drawing.Point(0, 19);
            this.label59.Name = "label59";
            this.label59.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label59.Size = new System.Drawing.Size(58, 17);
            this.label59.TabIndex = 474;
            this.label59.Text = "X Coord";
            // 
            // exitsMarioYCoord
            // 
            this.exitsMarioYCoord.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.exitsMarioYCoord.Location = new System.Drawing.Point(59, 37);
            this.exitsMarioYCoord.Maximum = new decimal(new int[] {
            127,
            0,
            0,
            0});
            this.exitsMarioYCoord.Name = "exitsMarioYCoord";
            this.exitsMarioYCoord.Size = new System.Drawing.Size(63, 17);
            this.exitsMarioYCoord.TabIndex = 139;
            this.exitsMarioYCoord.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.exitsMarioYCoord.ValueChanged += new System.EventHandler(this.exitsMarioYCoord_ValueChanged);
            // 
            // marioZCoordPlusHalf
            // 
            this.marioZCoordPlusHalf.Appearance = System.Windows.Forms.Appearance.Button;
            this.marioZCoordPlusHalf.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(220)))), ((int)(((byte)(212)))));
            this.marioZCoordPlusHalf.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.marioZCoordPlusHalf.FlatAppearance.BorderSize = 0;
            this.marioZCoordPlusHalf.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(168)))), ((int)(((byte)(168)))));
            this.marioZCoordPlusHalf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.marioZCoordPlusHalf.ForeColor = System.Drawing.Color.Gray;
            this.marioZCoordPlusHalf.Location = new System.Drawing.Point(0, 92);
            this.marioZCoordPlusHalf.Name = "marioZCoordPlusHalf";
            this.marioZCoordPlusHalf.Size = new System.Drawing.Size(121, 17);
            this.marioZCoordPlusHalf.TabIndex = 142;
            this.marioZCoordPlusHalf.Text = "Z Coord +½";
            this.marioZCoordPlusHalf.UseCompatibleTextRendering = true;
            this.marioZCoordPlusHalf.UseVisualStyleBackColor = false;
            this.marioZCoordPlusHalf.CheckedChanged += new System.EventHandler(this.marioZCoordPlusHalf_CheckedChanged);
            // 
            // label60
            // 
            this.label60.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label60.Location = new System.Drawing.Point(0, 37);
            this.label60.Name = "label60";
            this.label60.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label60.Size = new System.Drawing.Size(58, 17);
            this.label60.TabIndex = 476;
            this.label60.Text = "Y Coord";
            // 
            // exitsMarioXCoord
            // 
            this.exitsMarioXCoord.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.exitsMarioXCoord.Location = new System.Drawing.Point(59, 19);
            this.exitsMarioXCoord.Maximum = new decimal(new int[] {
            63,
            0,
            0,
            0});
            this.exitsMarioXCoord.Name = "exitsMarioXCoord";
            this.exitsMarioXCoord.Size = new System.Drawing.Size(63, 17);
            this.exitsMarioXCoord.TabIndex = 138;
            this.exitsMarioXCoord.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.exitsMarioXCoord.ValueChanged += new System.EventHandler(this.exitsMarioXCoord_ValueChanged);
            // 
            // exitsMarioZCoord
            // 
            this.exitsMarioZCoord.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.exitsMarioZCoord.Location = new System.Drawing.Point(59, 55);
            this.exitsMarioZCoord.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.exitsMarioZCoord.Name = "exitsMarioZCoord";
            this.exitsMarioZCoord.Size = new System.Drawing.Size(63, 17);
            this.exitsMarioZCoord.TabIndex = 140;
            this.exitsMarioZCoord.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.exitsMarioZCoord.ValueChanged += new System.EventHandler(this.exitsMarioZCoord_ValueChanged);
            // 
            // label122
            // 
            this.label122.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label122.Location = new System.Drawing.Point(0, 55);
            this.label122.Name = "label122";
            this.label122.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label122.Size = new System.Drawing.Size(58, 17);
            this.label122.TabIndex = 487;
            this.label122.Text = "Z Coord";
            // 
            // label124
            // 
            this.label124.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
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
            this.panel48.Controls.Add(this.exitsMarioRadialPosition);
            this.panel48.Location = new System.Drawing.Point(59, 73);
            this.panel48.Name = "panel48";
            this.panel48.Size = new System.Drawing.Size(63, 17);
            this.panel48.TabIndex = 141;
            // 
            // exitsMarioRadialPosition
            // 
            this.exitsMarioRadialPosition.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.exitsMarioRadialPosition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.exitsMarioRadialPosition.DropDownWidth = 70;
            this.exitsMarioRadialPosition.Items.AddRange(new object[] {
            "East",
            "Southeast",
            "South",
            "Southwest",
            "West",
            "Northwest",
            "North",
            "Northeast"});
            this.exitsMarioRadialPosition.Location = new System.Drawing.Point(-2, -2);
            this.exitsMarioRadialPosition.Name = "exitsMarioRadialPosition";
            this.exitsMarioRadialPosition.Size = new System.Drawing.Size(67, 21);
            this.exitsMarioRadialPosition.TabIndex = 210;
            this.exitsMarioRadialPosition.SelectedIndexChanged += new System.EventHandler(this.exitsMarioRadialPosition_SelectedIndexChanged);
            // 
            // panel87
            // 
            this.panel87.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.panel87.Controls.Add(this.exitsLengthOverOne);
            this.panel87.Controls.Add(this.label119);
            this.panel87.Controls.Add(this.exits135LengthPlusHalf);
            this.panel87.Controls.Add(this.label58);
            this.panel87.Controls.Add(this.exits45LengthPlusHalf);
            this.panel87.Controls.Add(this.exitsFieldLength);
            this.panel87.Controls.Add(this.label105);
            this.panel87.Controls.Add(this.exitsFieldZCoord);
            this.panel87.Controls.Add(this.exitsFieldYCoord);
            this.panel87.Controls.Add(this.exitsFieldXCoord);
            this.panel87.Controls.Add(this.exitsShowMessage);
            this.panel87.Controls.Add(this.exitsFieldHeight);
            this.panel87.Controls.Add(this.label37);
            this.panel87.Controls.Add(this.label55);
            this.panel87.Controls.Add(this.label57);
            this.panel87.Controls.Add(this.label120);
            this.panel87.Controls.Add(this.panel49);
            this.panel87.Controls.Add(this.label47);
            this.panel87.Controls.Add(this.panel50);
            this.panel87.Controls.Add(this.panel51);
            this.panel87.Location = new System.Drawing.Point(119, 19);
            this.panel87.Name = "panel87";
            this.panel87.Size = new System.Drawing.Size(121, 217);
            this.panel87.TabIndex = 494;
            // 
            // exitsLengthOverOne
            // 
            this.exitsLengthOverOne.Appearance = System.Windows.Forms.Appearance.Button;
            this.exitsLengthOverOne.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(220)))), ((int)(((byte)(212)))));
            this.exitsLengthOverOne.FlatAppearance.BorderSize = 0;
            this.exitsLengthOverOne.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(168)))), ((int)(((byte)(168)))));
            this.exitsLengthOverOne.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitsLengthOverOne.ForeColor = System.Drawing.Color.Gray;
            this.exitsLengthOverOne.Location = new System.Drawing.Point(0, 0);
            this.exitsLengthOverOne.Name = "exitsLengthOverOne";
            this.exitsLengthOverOne.Size = new System.Drawing.Size(121, 17);
            this.exitsLengthOverOne.TabIndex = 126;
            this.exitsLengthOverOne.Text = "LENGTH > 1";
            this.exitsLengthOverOne.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.exitsLengthOverOne.UseCompatibleTextRendering = true;
            this.exitsLengthOverOne.UseVisualStyleBackColor = false;
            this.exitsLengthOverOne.CheckedChanged += new System.EventHandler(this.exitsLengthOverOne_CheckedChanged);
            // 
            // label119
            // 
            this.label119.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label119.Location = new System.Drawing.Point(0, 91);
            this.label119.Name = "label119";
            this.label119.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label119.Size = new System.Drawing.Size(58, 17);
            this.label119.TabIndex = 472;
            this.label119.Text = "X Coord";
            // 
            // exits135LengthPlusHalf
            // 
            this.exits135LengthPlusHalf.Appearance = System.Windows.Forms.Appearance.Button;
            this.exits135LengthPlusHalf.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(220)))), ((int)(((byte)(212)))));
            this.exits135LengthPlusHalf.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.exits135LengthPlusHalf.FlatAppearance.BorderSize = 0;
            this.exits135LengthPlusHalf.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(168)))), ((int)(((byte)(168)))));
            this.exits135LengthPlusHalf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exits135LengthPlusHalf.ForeColor = System.Drawing.Color.Gray;
            this.exits135LengthPlusHalf.Location = new System.Drawing.Point(59, 200);
            this.exits135LengthPlusHalf.Name = "exits135LengthPlusHalf";
            this.exits135LengthPlusHalf.Size = new System.Drawing.Size(62, 17);
            this.exits135LengthPlusHalf.TabIndex = 138;
            this.exits135LengthPlusHalf.Text = "135°+½";
            this.exits135LengthPlusHalf.UseCompatibleTextRendering = true;
            this.exits135LengthPlusHalf.UseVisualStyleBackColor = false;
            this.exits135LengthPlusHalf.CheckedChanged += new System.EventHandler(this.exits135LengthPlusHalf_CheckedChanged);
            // 
            // label58
            // 
            this.label58.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label58.Location = new System.Drawing.Point(0, 109);
            this.label58.Name = "label58";
            this.label58.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label58.Size = new System.Drawing.Size(58, 17);
            this.label58.TabIndex = 475;
            this.label58.Text = "Y Coord";
            // 
            // exits45LengthPlusHalf
            // 
            this.exits45LengthPlusHalf.Appearance = System.Windows.Forms.Appearance.Button;
            this.exits45LengthPlusHalf.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(220)))), ((int)(((byte)(212)))));
            this.exits45LengthPlusHalf.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.exits45LengthPlusHalf.FlatAppearance.BorderSize = 0;
            this.exits45LengthPlusHalf.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(168)))), ((int)(((byte)(168)))));
            this.exits45LengthPlusHalf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exits45LengthPlusHalf.ForeColor = System.Drawing.Color.Gray;
            this.exits45LengthPlusHalf.Location = new System.Drawing.Point(0, 200);
            this.exits45LengthPlusHalf.Name = "exits45LengthPlusHalf";
            this.exits45LengthPlusHalf.Size = new System.Drawing.Size(58, 17);
            this.exits45LengthPlusHalf.TabIndex = 137;
            this.exits45LengthPlusHalf.Text = "45°+½";
            this.exits45LengthPlusHalf.UseCompatibleTextRendering = true;
            this.exits45LengthPlusHalf.UseVisualStyleBackColor = false;
            this.exits45LengthPlusHalf.CheckedChanged += new System.EventHandler(this.exits45LengthPlusHalf_CheckedChanged);
            // 
            // exitsFieldLength
            // 
            this.exitsFieldLength.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.exitsFieldLength.Location = new System.Drawing.Point(59, 145);
            this.exitsFieldLength.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.exitsFieldLength.Name = "exitsFieldLength";
            this.exitsFieldLength.Size = new System.Drawing.Size(63, 17);
            this.exitsFieldLength.TabIndex = 134;
            this.exitsFieldLength.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.exitsFieldLength.ValueChanged += new System.EventHandler(this.exitsFieldLength_ValueChanged);
            // 
            // label105
            // 
            this.label105.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label105.Location = new System.Drawing.Point(0, 145);
            this.label105.Name = "label105";
            this.label105.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label105.Size = new System.Drawing.Size(58, 17);
            this.label105.TabIndex = 470;
            this.label105.Text = "Length";
            // 
            // exitsFieldZCoord
            // 
            this.exitsFieldZCoord.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.exitsFieldZCoord.Location = new System.Drawing.Point(59, 127);
            this.exitsFieldZCoord.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.exitsFieldZCoord.Name = "exitsFieldZCoord";
            this.exitsFieldZCoord.Size = new System.Drawing.Size(63, 17);
            this.exitsFieldZCoord.TabIndex = 133;
            this.exitsFieldZCoord.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.exitsFieldZCoord.ValueChanged += new System.EventHandler(this.exitsFieldZCoord_ValueChanged);
            // 
            // exitsFieldYCoord
            // 
            this.exitsFieldYCoord.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.exitsFieldYCoord.Location = new System.Drawing.Point(59, 109);
            this.exitsFieldYCoord.Maximum = new decimal(new int[] {
            127,
            0,
            0,
            0});
            this.exitsFieldYCoord.Name = "exitsFieldYCoord";
            this.exitsFieldYCoord.Size = new System.Drawing.Size(63, 17);
            this.exitsFieldYCoord.TabIndex = 132;
            this.exitsFieldYCoord.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.exitsFieldYCoord.ValueChanged += new System.EventHandler(this.exitsFieldYCoord_ValueChanged);
            // 
            // exitsFieldXCoord
            // 
            this.exitsFieldXCoord.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.exitsFieldXCoord.Location = new System.Drawing.Point(59, 91);
            this.exitsFieldXCoord.Maximum = new decimal(new int[] {
            63,
            0,
            0,
            0});
            this.exitsFieldXCoord.Name = "exitsFieldXCoord";
            this.exitsFieldXCoord.Size = new System.Drawing.Size(63, 17);
            this.exitsFieldXCoord.TabIndex = 131;
            this.exitsFieldXCoord.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.exitsFieldXCoord.ValueChanged += new System.EventHandler(this.exitsFieldXCoord_ValueChanged);
            // 
            // exitsShowMessage
            // 
            this.exitsShowMessage.Appearance = System.Windows.Forms.Appearance.Button;
            this.exitsShowMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(220)))), ((int)(((byte)(212)))));
            this.exitsShowMessage.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.exitsShowMessage.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(168)))), ((int)(((byte)(168)))));
            this.exitsShowMessage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitsShowMessage.ForeColor = System.Drawing.Color.Gray;
            this.exitsShowMessage.Location = new System.Drawing.Point(-1, 54);
            this.exitsShowMessage.Name = "exitsShowMessage";
            this.exitsShowMessage.Size = new System.Drawing.Size(123, 19);
            this.exitsShowMessage.TabIndex = 129;
            this.exitsShowMessage.Text = "SHOW MESSAGE";
            this.exitsShowMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.exitsShowMessage.UseCompatibleTextRendering = true;
            this.exitsShowMessage.UseVisualStyleBackColor = false;
            this.exitsShowMessage.CheckedChanged += new System.EventHandler(this.exitsShowMessage_CheckedChanged);
            // 
            // exitsFieldHeight
            // 
            this.exitsFieldHeight.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.exitsFieldHeight.Location = new System.Drawing.Point(59, 163);
            this.exitsFieldHeight.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.exitsFieldHeight.Name = "exitsFieldHeight";
            this.exitsFieldHeight.Size = new System.Drawing.Size(63, 17);
            this.exitsFieldHeight.TabIndex = 135;
            this.exitsFieldHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.exitsFieldHeight.ValueChanged += new System.EventHandler(this.exitsFieldHeight_ValueChanged);
            // 
            // label37
            // 
            this.label37.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label37.Location = new System.Drawing.Point(0, 73);
            this.label37.Name = "label37";
            this.label37.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label37.Size = new System.Drawing.Size(58, 17);
            this.label37.TabIndex = 458;
            this.label37.Text = "Exit Type";
            // 
            // label55
            // 
            this.label55.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label55.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label55.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label55.Location = new System.Drawing.Point(0, 19);
            this.label55.Name = "label55";
            this.label55.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label55.Size = new System.Drawing.Size(121, 17);
            this.label55.TabIndex = 460;
            this.label55.Text = "DESTINATION";
            // 
            // label57
            // 
            this.label57.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label57.Location = new System.Drawing.Point(0, 127);
            this.label57.Name = "label57";
            this.label57.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label57.Size = new System.Drawing.Size(58, 17);
            this.label57.TabIndex = 485;
            this.label57.Text = "Z Coord";
            // 
            // label120
            // 
            this.label120.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label120.Location = new System.Drawing.Point(0, 163);
            this.label120.Name = "label120";
            this.label120.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label120.Size = new System.Drawing.Size(58, 17);
            this.label120.TabIndex = 483;
            this.label120.Text = "Height";
            // 
            // panel49
            // 
            this.panel49.BackColor = System.Drawing.SystemColors.Window;
            this.panel49.Controls.Add(this.exitsFieldRadialPosition);
            this.panel49.Location = new System.Drawing.Point(59, 181);
            this.panel49.Name = "panel49";
            this.panel49.Size = new System.Drawing.Size(63, 17);
            this.panel49.TabIndex = 136;
            // 
            // exitsFieldRadialPosition
            // 
            this.exitsFieldRadialPosition.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.exitsFieldRadialPosition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.exitsFieldRadialPosition.DropDownWidth = 60;
            this.exitsFieldRadialPosition.Items.AddRange(new object[] {
            "UR to DL",
            "DR to UL"});
            this.exitsFieldRadialPosition.Location = new System.Drawing.Point(-2, -2);
            this.exitsFieldRadialPosition.Name = "exitsFieldRadialPosition";
            this.exitsFieldRadialPosition.Size = new System.Drawing.Size(67, 21);
            this.exitsFieldRadialPosition.TabIndex = 212;
            this.exitsFieldRadialPosition.SelectedIndexChanged += new System.EventHandler(this.exitsFieldRadialPosition_SelectedIndexChanged);
            // 
            // label47
            // 
            this.label47.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label47.Location = new System.Drawing.Point(0, 181);
            this.label47.Name = "label47";
            this.label47.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label47.Size = new System.Drawing.Size(58, 17);
            this.label47.TabIndex = 490;
            this.label47.Text = "Facing";
            // 
            // panel50
            // 
            this.panel50.BackColor = System.Drawing.SystemColors.Window;
            this.panel50.Controls.Add(this.exitsType);
            this.panel50.Location = new System.Drawing.Point(59, 73);
            this.panel50.Name = "panel50";
            this.panel50.Size = new System.Drawing.Size(62, 17);
            this.panel50.TabIndex = 130;
            // 
            // exitsType
            // 
            this.exitsType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.exitsType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.exitsType.DropDownWidth = 80;
            this.exitsType.Items.AddRange(new object[] {
            "Overworld",
            "World Map"});
            this.exitsType.Location = new System.Drawing.Point(-2, -2);
            this.exitsType.Name = "exitsType";
            this.exitsType.Size = new System.Drawing.Size(67, 21);
            this.exitsType.TabIndex = 197;
            this.exitsType.SelectedIndexChanged += new System.EventHandler(this.exitsType_SelectedIndexChanged);
            // 
            // panel51
            // 
            this.panel51.BackColor = System.Drawing.SystemColors.Window;
            this.panel51.Controls.Add(this.exitsDestination);
            this.panel51.Location = new System.Drawing.Point(0, 37);
            this.panel51.Name = "panel51";
            this.panel51.Size = new System.Drawing.Size(121, 17);
            this.panel51.TabIndex = 128;
            // 
            // exitsDestination
            // 
            this.exitsDestination.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.exitsDestination.DropDownHeight = 431;
            this.exitsDestination.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.exitsDestination.DropDownWidth = 490;
            this.exitsDestination.IntegralHeight = false;
            this.exitsDestination.Items.AddRange(new object[] {
            ""});
            this.exitsDestination.Location = new System.Drawing.Point(-2, -2);
            this.exitsDestination.Name = "exitsDestination";
            this.exitsDestination.Size = new System.Drawing.Size(126, 21);
            this.exitsDestination.TabIndex = 196;
            this.exitsDestination.SelectedIndexChanged += new System.EventHandler(this.exitsDestination_SelectedIndexChanged);
            // 
            // panel68
            // 
            this.panel68.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.panel68.BackgroundImage = global::LAZYSHELL.Properties.Resources._bg;
            this.panel68.Location = new System.Drawing.Point(119, 608);
            this.panel68.Name = "panel68";
            this.panel68.Size = new System.Drawing.Size(121, 0);
            this.panel68.TabIndex = 493;
            // 
            // eventsDeleteField
            // 
            this.eventsDeleteField.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.eventsDeleteField.BackColor = System.Drawing.SystemColors.Window;
            this.eventsDeleteField.FlatAppearance.BorderSize = 0;
            this.eventsDeleteField.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.eventsDeleteField.Location = new System.Drawing.Point(59, 589);
            this.eventsDeleteField.Name = "eventsDeleteField";
            this.eventsDeleteField.Size = new System.Drawing.Size(58, 17);
            this.eventsDeleteField.TabIndex = 144;
            this.eventsDeleteField.Text = "DELETE";
            this.eventsDeleteField.UseCompatibleTextRendering = true;
            this.eventsDeleteField.UseVisualStyleBackColor = false;
            this.eventsDeleteField.Click += new System.EventHandler(this.eventsDeleteField_Click);
            // 
            // eventsInsertField
            // 
            this.eventsInsertField.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.eventsInsertField.BackColor = System.Drawing.SystemColors.Window;
            this.eventsInsertField.FlatAppearance.BorderSize = 0;
            this.eventsInsertField.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.eventsInsertField.Location = new System.Drawing.Point(0, 589);
            this.eventsInsertField.Name = "eventsInsertField";
            this.eventsInsertField.Size = new System.Drawing.Size(58, 17);
            this.eventsInsertField.TabIndex = 143;
            this.eventsInsertField.Text = "INSERT";
            this.eventsInsertField.UseCompatibleTextRendering = true;
            this.eventsInsertField.UseVisualStyleBackColor = false;
            this.eventsInsertField.Click += new System.EventHandler(this.eventsInsertField_Click);
            // 
            // label63
            // 
            this.label63.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label63.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label63.ForeColor = System.Drawing.SystemColors.Control;
            this.label63.Location = new System.Drawing.Point(0, 349);
            this.label63.Name = "label63";
            this.label63.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label63.Size = new System.Drawing.Size(240, 17);
            this.label63.TabIndex = 456;
            this.label63.Text = "EVENT FIELDS";
            this.label63.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // exitsDeleteField
            // 
            this.exitsDeleteField.BackColor = System.Drawing.SystemColors.Window;
            this.exitsDeleteField.FlatAppearance.BorderSize = 0;
            this.exitsDeleteField.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitsDeleteField.Location = new System.Drawing.Point(59, 330);
            this.exitsDeleteField.Name = "exitsDeleteField";
            this.exitsDeleteField.Size = new System.Drawing.Size(58, 17);
            this.exitsDeleteField.TabIndex = 125;
            this.exitsDeleteField.Text = "DELETE";
            this.exitsDeleteField.UseCompatibleTextRendering = true;
            this.exitsDeleteField.UseVisualStyleBackColor = false;
            this.exitsDeleteField.Click += new System.EventHandler(this.exitsDeleteField_Click);
            // 
            // exitsInsertField
            // 
            this.exitsInsertField.BackColor = System.Drawing.SystemColors.Window;
            this.exitsInsertField.FlatAppearance.BorderSize = 0;
            this.exitsInsertField.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitsInsertField.Location = new System.Drawing.Point(0, 330);
            this.exitsInsertField.Name = "exitsInsertField";
            this.exitsInsertField.Size = new System.Drawing.Size(58, 17);
            this.exitsInsertField.TabIndex = 124;
            this.exitsInsertField.Text = "INSERT";
            this.exitsInsertField.UseCompatibleTextRendering = true;
            this.exitsInsertField.UseVisualStyleBackColor = false;
            this.exitsInsertField.Click += new System.EventHandler(this.exitsInsertField_Click);
            // 
            // exitsFieldTree
            // 
            this.exitsFieldTree.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.exitsFieldTree.HideSelection = false;
            this.exitsFieldTree.HotTracking = true;
            this.exitsFieldTree.Location = new System.Drawing.Point(0, 19);
            this.exitsFieldTree.Name = "exitsFieldTree";
            this.exitsFieldTree.ShowRootLines = false;
            this.exitsFieldTree.Size = new System.Drawing.Size(117, 310);
            this.exitsFieldTree.TabIndex = 127;
            this.exitsFieldTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.exitsFieldTree_AfterSelect);
            // 
            // eventsFieldTree
            // 
            this.eventsFieldTree.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.eventsFieldTree.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.eventsFieldTree.HideSelection = false;
            this.eventsFieldTree.HotTracking = true;
            this.eventsFieldTree.Location = new System.Drawing.Point(0, 368);
            this.eventsFieldTree.Name = "eventsFieldTree";
            this.eventsFieldTree.ShowRootLines = false;
            this.eventsFieldTree.Size = new System.Drawing.Size(117, 220);
            this.eventsFieldTree.TabIndex = 146;
            this.eventsFieldTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.eventsFieldTree_AfterSelect);
            // 
            // label61
            // 
            this.label61.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label61.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label61.ForeColor = System.Drawing.SystemColors.Control;
            this.label61.Location = new System.Drawing.Point(0, 0);
            this.label61.Name = "label61";
            this.label61.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label61.Size = new System.Drawing.Size(240, 17);
            this.label61.TabIndex = 453;
            this.label61.Text = "EXIT FIELDS";
            this.label61.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabPage5
            // 
            this.tabPage5.BackColor = System.Drawing.SystemColors.ControlText;
            this.tabPage5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPage5.Controls.Add(this.panel66);
            this.tabPage5.Location = new System.Drawing.Point(4, 23);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(260, 609);
            this.tabPage5.TabIndex = 1;
            this.tabPage5.Text = "L2";
            // 
            // panel66
            // 
            this.panel66.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel66.BackgroundImage = global::LAZYSHELL.Properties.Resources._bg;
            this.panel66.Controls.Add(this.panel67);
            this.panel66.Location = new System.Drawing.Point(1, 1);
            this.panel66.Name = "panel66";
            this.panel66.Size = new System.Drawing.Size(256, 605);
            this.panel66.TabIndex = 440;
            // 
            // panel67
            // 
            this.panel67.Controls.Add(this.pictureBoxTilesetL2);
            this.panel67.Location = new System.Drawing.Point(-2, 0);
            this.panel67.Name = "panel67";
            this.panel67.Size = new System.Drawing.Size(260, 514);
            this.panel67.TabIndex = 441;
            // 
            // pictureBoxTilesetL2
            // 
            this.pictureBoxTilesetL2.BackgroundImage = global::LAZYSHELL.Properties.Resources._transparent;
            this.pictureBoxTilesetL2.ContextMenuStrip = this.contextMenuStrip2;
            this.pictureBoxTilesetL2.Cursor = System.Windows.Forms.Cursors.Cross;
            this.pictureBoxTilesetL2.Location = new System.Drawing.Point(2, 0);
            this.pictureBoxTilesetL2.Name = "pictureBoxTilesetL2";
            this.pictureBoxTilesetL2.Size = new System.Drawing.Size(256, 512);
            this.pictureBoxTilesetL2.TabIndex = 2;
            this.pictureBoxTilesetL2.TabStop = false;
            this.pictureBoxTilesetL2.MouseLeave += new System.EventHandler(this.pictureBoxTilesetL2_MouseLeave);
            this.pictureBoxTilesetL2.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.pictureBoxTilesetL2_PreviewKeyDown);
            this.pictureBoxTilesetL2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxTilesetL2_MouseMove);
            this.pictureBoxTilesetL2.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pictureBoxTilesetL2_MouseDoubleClick);
            this.pictureBoxTilesetL2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBoxTilesetL2_MouseClick);
            this.pictureBoxTilesetL2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxTilesetL2_MouseDown);
            this.pictureBoxTilesetL2.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxTilesetL2_Paint);
            this.pictureBoxTilesetL2.MouseEnter += new System.EventHandler(this.pictureBoxTilesetL2_MouseEnter);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cutToolStripMenuItem2,
            this.copyToolStripMenuItem2,
            this.pasteToolStripMenuItem2,
            this.deleteToolStripMenuItem2,
            this.toolStripSeparator27,
            this.priority1SetToolStripMenuItem,
            this.priority1ClearToolStripMenuItem,
            this.toolStripSeparator25,
            this.editToolStripMenuItem1,
            this.toolStripSeparator41,
            this.saveImageAsToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.contextMenuStrip2.ShowImageMargin = false;
            this.contextMenuStrip2.Size = new System.Drawing.Size(131, 198);
            // 
            // cutToolStripMenuItem2
            // 
            this.cutToolStripMenuItem2.Name = "cutToolStripMenuItem2";
            this.cutToolStripMenuItem2.Size = new System.Drawing.Size(130, 22);
            this.cutToolStripMenuItem2.Text = "Cut";
            this.cutToolStripMenuItem2.Click += new System.EventHandler(this.cutToolStripMenuItem2_Click);
            // 
            // copyToolStripMenuItem2
            // 
            this.copyToolStripMenuItem2.Name = "copyToolStripMenuItem2";
            this.copyToolStripMenuItem2.Size = new System.Drawing.Size(130, 22);
            this.copyToolStripMenuItem2.Text = "Copy";
            this.copyToolStripMenuItem2.Click += new System.EventHandler(this.copyToolStripMenuItem2_Click);
            // 
            // pasteToolStripMenuItem2
            // 
            this.pasteToolStripMenuItem2.Name = "pasteToolStripMenuItem2";
            this.pasteToolStripMenuItem2.Size = new System.Drawing.Size(130, 22);
            this.pasteToolStripMenuItem2.Text = "Paste";
            this.pasteToolStripMenuItem2.Click += new System.EventHandler(this.pasteToolStripMenuItem2_Click);
            // 
            // deleteToolStripMenuItem2
            // 
            this.deleteToolStripMenuItem2.Name = "deleteToolStripMenuItem2";
            this.deleteToolStripMenuItem2.Size = new System.Drawing.Size(130, 22);
            this.deleteToolStripMenuItem2.Text = "Delete";
            this.deleteToolStripMenuItem2.Click += new System.EventHandler(this.deleteToolStripMenuItem2_Click);
            // 
            // toolStripSeparator27
            // 
            this.toolStripSeparator27.Name = "toolStripSeparator27";
            this.toolStripSeparator27.Size = new System.Drawing.Size(127, 6);
            // 
            // priority1SetToolStripMenuItem
            // 
            this.priority1SetToolStripMenuItem.Name = "priority1SetToolStripMenuItem";
            this.priority1SetToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.priority1SetToolStripMenuItem.Text = "Priority 1 set";
            this.priority1SetToolStripMenuItem.Click += new System.EventHandler(this.priority1SetToolStripMenuItem_Click);
            // 
            // priority1ClearToolStripMenuItem
            // 
            this.priority1ClearToolStripMenuItem.Name = "priority1ClearToolStripMenuItem";
            this.priority1ClearToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.priority1ClearToolStripMenuItem.Text = "Priority 1 clear";
            this.priority1ClearToolStripMenuItem.Click += new System.EventHandler(this.priority1ClearToolStripMenuItem_Click);
            // 
            // toolStripSeparator25
            // 
            this.toolStripSeparator25.Name = "toolStripSeparator25";
            this.toolStripSeparator25.Size = new System.Drawing.Size(127, 6);
            // 
            // editToolStripMenuItem1
            // 
            this.editToolStripMenuItem1.Name = "editToolStripMenuItem1";
            this.editToolStripMenuItem1.Size = new System.Drawing.Size(130, 22);
            this.editToolStripMenuItem1.Text = "Edit...";
            this.editToolStripMenuItem1.Click += new System.EventHandler(this.editToolStripMenuItem1_Click);
            // 
            // toolStripSeparator41
            // 
            this.toolStripSeparator41.Name = "toolStripSeparator41";
            this.toolStripSeparator41.Size = new System.Drawing.Size(127, 6);
            // 
            // saveImageAsToolStripMenuItem
            // 
            this.saveImageAsToolStripMenuItem.Name = "saveImageAsToolStripMenuItem";
            this.saveImageAsToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.saveImageAsToolStripMenuItem.Text = "Save image as...";
            this.saveImageAsToolStripMenuItem.Click += new System.EventHandler(this.saveImageAsToolStripMenuItem_Click);
            // 
            // tabPage7
            // 
            this.tabPage7.BackColor = System.Drawing.SystemColors.ControlText;
            this.tabPage7.Controls.Add(this.panel3);
            this.tabPage7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage7.Location = new System.Drawing.Point(4, 23);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Size = new System.Drawing.Size(260, 609);
            this.tabPage7.TabIndex = 3;
            this.tabPage7.Text = "PHYS";
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackgroundImage = global::LAZYSHELL.Properties.Resources._bg;
            this.panel3.Controls.Add(this.panelPhysicalTile);
            this.panel3.Controls.Add(this.panel97);
            this.panel3.Location = new System.Drawing.Point(2, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(256, 605);
            this.panel3.TabIndex = 440;
            // 
            // panelPhysicalTile
            // 
            this.panelPhysicalTile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.panelPhysicalTile.Controls.Add(this.pictureBoxPhysicalTile);
            this.panelPhysicalTile.Location = new System.Drawing.Point(222, 0);
            this.panelPhysicalTile.Name = "panelPhysicalTile";
            this.panelPhysicalTile.Size = new System.Drawing.Size(36, 605);
            this.panelPhysicalTile.TabIndex = 173;
            // 
            // pictureBoxPhysicalTile
            // 
            this.pictureBoxPhysicalTile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBoxPhysicalTile.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pictureBoxPhysicalTile.Location = new System.Drawing.Point(2, -179);
            this.pictureBoxPhysicalTile.Name = "pictureBoxPhysicalTile";
            this.pictureBoxPhysicalTile.Size = new System.Drawing.Size(32, 784);
            this.pictureBoxPhysicalTile.TabIndex = 0;
            this.pictureBoxPhysicalTile.TabStop = false;
            this.pictureBoxPhysicalTile.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.pictureBoxPhysicalTile_PreviewKeyDown);
            this.pictureBoxPhysicalTile.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxPhysicalTile_MouseDown);
            this.pictureBoxPhysicalTile.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxPhysicalTile_Paint);
            // 
            // panel97
            // 
            this.panel97.Controls.Add(this.panel91);
            this.panel97.Controls.Add(this.label94);
            this.panel97.Controls.Add(this.physicalTileSearchButton);
            this.panel97.Controls.Add(this.physicalTileNum);
            this.panel97.Location = new System.Drawing.Point(0, 0);
            this.panel97.Name = "panel97";
            this.panel97.Size = new System.Drawing.Size(224, 495);
            this.panel97.TabIndex = 441;
            // 
            // panel91
            // 
            this.panel91.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.panel91.Controls.Add(this.panel105);
            this.panel91.Controls.Add(this.label93);
            this.panel91.Controls.Add(this.physicalTileUnknownBits);
            this.panel91.Controls.Add(this.physicalTileBaseHeight);
            this.panel91.Controls.Add(this.physicalTileOverZCoord);
            this.panel91.Controls.Add(this.physicalTileOverHeight);
            this.panel91.Controls.Add(this.label140);
            this.panel91.Controls.Add(this.label92);
            this.panel91.Controls.Add(this.physicalTileQuadrant);
            this.panel91.Controls.Add(this.physicalTileWaterZCoord);
            this.panel91.Controls.Add(this.panel55);
            this.panel91.Controls.Add(this.label90);
            this.panel91.Controls.Add(this.panel54);
            this.panel91.Controls.Add(this.physicalTileProperties);
            this.panel91.Controls.Add(this.label75);
            this.panel91.Controls.Add(this.panel44);
            this.panel91.Controls.Add(this.physicalTileEdges);
            this.panel91.Controls.Add(this.label68);
            this.panel91.Controls.Add(this.label74);
            this.panel91.Controls.Add(this.label72);
            this.panel91.Controls.Add(this.label73);
            this.panel91.Controls.Add(this.physicalTilePriority3);
            this.panel91.Location = new System.Drawing.Point(0, 38);
            this.panel91.Name = "panel91";
            this.panel91.Size = new System.Drawing.Size(222, 455);
            this.panel91.TabIndex = 496;
            // 
            // panel105
            // 
            this.panel105.BackColor = System.Drawing.SystemColors.Window;
            this.panel105.Controls.Add(this.physicalTileDoorFormat);
            this.panel105.Location = new System.Drawing.Point(136, 438);
            this.panel105.Name = "panel105";
            this.panel105.Size = new System.Drawing.Size(87, 17);
            this.panel105.TabIndex = 497;
            // 
            // physicalTileDoorFormat
            // 
            this.physicalTileDoorFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.physicalTileDoorFormat.Enabled = false;
            this.physicalTileDoorFormat.Items.AddRange(new object[] {
            "(none)",
            "{unknown}",
            "{unknown}",
            "{unknown}",
            "{unknown}",
            "NW / SE",
            "{unknown}",
            "NE / SW"});
            this.physicalTileDoorFormat.Location = new System.Drawing.Point(-2, -2);
            this.physicalTileDoorFormat.Name = "physicalTileDoorFormat";
            this.physicalTileDoorFormat.Size = new System.Drawing.Size(91, 21);
            this.physicalTileDoorFormat.TabIndex = 371;
            // 
            // label93
            // 
            this.label93.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label93.BackColor = System.Drawing.SystemColors.Control;
            this.label93.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label93.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label93.Location = new System.Drawing.Point(0, 0);
            this.label93.Name = "label93";
            this.label93.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label93.Size = new System.Drawing.Size(222, 17);
            this.label93.TabIndex = 361;
            this.label93.Text = "PHYSICAL TILE PROPETIES";
            this.label93.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // physicalTileUnknownBits
            // 
            this.physicalTileUnknownBits.BackColor = System.Drawing.SystemColors.Window;
            this.physicalTileUnknownBits.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.physicalTileUnknownBits.CheckOnClick = true;
            this.physicalTileUnknownBits.ColumnWidth = 70;
            this.physicalTileUnknownBits.Enabled = false;
            this.physicalTileUnknownBits.Items.AddRange(new object[] {
            "{B5,b0}",
            "{B5,b1}",
            "{B5,b2}",
            "{B5,b3}",
            "{B5,b4}"});
            this.physicalTileUnknownBits.Location = new System.Drawing.Point(0, 405);
            this.physicalTileUnknownBits.MultiColumn = true;
            this.physicalTileUnknownBits.Name = "physicalTileUnknownBits";
            this.physicalTileUnknownBits.Size = new System.Drawing.Size(222, 32);
            this.physicalTileUnknownBits.TabIndex = 499;
            // 
            // physicalTileBaseHeight
            // 
            this.physicalTileBaseHeight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.physicalTileBaseHeight.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.physicalTileBaseHeight.Enabled = false;
            this.physicalTileBaseHeight.Location = new System.Drawing.Point(136, 19);
            this.physicalTileBaseHeight.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.physicalTileBaseHeight.Name = "physicalTileBaseHeight";
            this.physicalTileBaseHeight.Size = new System.Drawing.Size(87, 17);
            this.physicalTileBaseHeight.TabIndex = 161;
            this.physicalTileBaseHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.physicalTileBaseHeight.ValueChanged += new System.EventHandler(this.physicalTileBaseHeight_ValueChanged);
            // 
            // physicalTileOverZCoord
            // 
            this.physicalTileOverZCoord.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.physicalTileOverZCoord.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.physicalTileOverZCoord.Enabled = false;
            this.physicalTileOverZCoord.Location = new System.Drawing.Point(136, 55);
            this.physicalTileOverZCoord.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.physicalTileOverZCoord.Name = "physicalTileOverZCoord";
            this.physicalTileOverZCoord.Size = new System.Drawing.Size(87, 17);
            this.physicalTileOverZCoord.TabIndex = 163;
            this.physicalTileOverZCoord.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.physicalTileOverZCoord.ValueChanged += new System.EventHandler(this.physicalTileOverZCoord_ValueChanged);
            // 
            // physicalTileOverHeight
            // 
            this.physicalTileOverHeight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.physicalTileOverHeight.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.physicalTileOverHeight.Enabled = false;
            this.physicalTileOverHeight.Location = new System.Drawing.Point(136, 37);
            this.physicalTileOverHeight.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.physicalTileOverHeight.Name = "physicalTileOverHeight";
            this.physicalTileOverHeight.Size = new System.Drawing.Size(87, 17);
            this.physicalTileOverHeight.TabIndex = 162;
            this.physicalTileOverHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.physicalTileOverHeight.ValueChanged += new System.EventHandler(this.physicalTileOverHeight_ValueChanged);
            // 
            // label140
            // 
            this.label140.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label140.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label140.Location = new System.Drawing.Point(0, 438);
            this.label140.Name = "label140";
            this.label140.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label140.Size = new System.Drawing.Size(135, 17);
            this.label140.TabIndex = 356;
            this.label140.Text = "Door format";
            // 
            // label92
            // 
            this.label92.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label92.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label92.Location = new System.Drawing.Point(0, 387);
            this.label92.Name = "label92";
            this.label92.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label92.Size = new System.Drawing.Size(135, 17);
            this.label92.TabIndex = 356;
            this.label92.Text = "Special tile format";
            // 
            // physicalTileQuadrant
            // 
            this.physicalTileQuadrant.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.physicalTileQuadrant.BackColor = System.Drawing.SystemColors.Window;
            this.physicalTileQuadrant.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.physicalTileQuadrant.CheckOnClick = true;
            this.physicalTileQuadrant.ColumnWidth = 118;
            this.physicalTileQuadrant.Enabled = false;
            this.physicalTileQuadrant.Items.AddRange(new object[] {
            "N quadrant is solid",
            "W quadrant is solid",
            "E quadrant is solid",
            "S quadrant is solid"});
            this.physicalTileQuadrant.Location = new System.Drawing.Point(0, 257);
            this.physicalTileQuadrant.Name = "physicalTileQuadrant";
            this.physicalTileQuadrant.Size = new System.Drawing.Size(222, 64);
            this.physicalTileQuadrant.TabIndex = 169;
            this.physicalTileQuadrant.SelectedIndexChanged += new System.EventHandler(this.physicalTileQuadrant_SelectedIndexChanged);
            // 
            // physicalTileWaterZCoord
            // 
            this.physicalTileWaterZCoord.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.physicalTileWaterZCoord.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.physicalTileWaterZCoord.Enabled = false;
            this.physicalTileWaterZCoord.Location = new System.Drawing.Point(136, 73);
            this.physicalTileWaterZCoord.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.physicalTileWaterZCoord.Name = "physicalTileWaterZCoord";
            this.physicalTileWaterZCoord.Size = new System.Drawing.Size(87, 17);
            this.physicalTileWaterZCoord.TabIndex = 164;
            this.physicalTileWaterZCoord.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.physicalTileWaterZCoord.ValueChanged += new System.EventHandler(this.physicalTileWaterZCoord_ValueChanged);
            // 
            // panel55
            // 
            this.panel55.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel55.BackColor = System.Drawing.SystemColors.Window;
            this.panel55.Controls.Add(this.physicalTileSpecialTile);
            this.panel55.Location = new System.Drawing.Point(136, 387);
            this.panel55.Name = "panel55";
            this.panel55.Size = new System.Drawing.Size(87, 17);
            this.panel55.TabIndex = 171;
            // 
            // physicalTileSpecialTile
            // 
            this.physicalTileSpecialTile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.physicalTileSpecialTile.Enabled = false;
            this.physicalTileSpecialTile.Items.AddRange(new object[] {
            "(normal)",
            "Vines",
            "Water"});
            this.physicalTileSpecialTile.Location = new System.Drawing.Point(-2, -2);
            this.physicalTileSpecialTile.Name = "physicalTileSpecialTile";
            this.physicalTileSpecialTile.Size = new System.Drawing.Size(91, 21);
            this.physicalTileSpecialTile.TabIndex = 371;
            this.physicalTileSpecialTile.SelectedIndexChanged += new System.EventHandler(this.physicalTileSpecialTile_SelectedIndexChanged);
            // 
            // label90
            // 
            this.label90.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label90.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label90.Location = new System.Drawing.Point(0, 239);
            this.label90.Name = "label90";
            this.label90.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label90.Size = new System.Drawing.Size(135, 17);
            this.label90.TabIndex = 357;
            this.label90.Text = "Stairs lead";
            // 
            // panel54
            // 
            this.panel54.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel54.BackColor = System.Drawing.SystemColors.Window;
            this.panel54.Controls.Add(this.physicalTileStairs);
            this.panel54.Location = new System.Drawing.Point(136, 239);
            this.panel54.Name = "panel54";
            this.panel54.Size = new System.Drawing.Size(87, 17);
            this.panel54.TabIndex = 168;
            // 
            // physicalTileStairs
            // 
            this.physicalTileStairs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.physicalTileStairs.Enabled = false;
            this.physicalTileStairs.Items.AddRange(new object[] {
            "(no stairs)",
            "Up-left",
            "Up-right"});
            this.physicalTileStairs.Location = new System.Drawing.Point(-2, -2);
            this.physicalTileStairs.Name = "physicalTileStairs";
            this.physicalTileStairs.Size = new System.Drawing.Size(91, 21);
            this.physicalTileStairs.TabIndex = 372;
            this.physicalTileStairs.SelectedIndexChanged += new System.EventHandler(this.physicalTileStairs_SelectedIndexChanged);
            // 
            // physicalTileProperties
            // 
            this.physicalTileProperties.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.physicalTileProperties.BackColor = System.Drawing.SystemColors.Window;
            this.physicalTileProperties.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.physicalTileProperties.CheckOnClick = true;
            this.physicalTileProperties.ColumnWidth = 118;
            this.physicalTileProperties.Enabled = false;
            this.physicalTileProperties.Items.AddRange(new object[] {
            "Conveyor belt, fast",
            "Conveyor belt, normal",
            "Z Coord + 0.5",
            "Solid tile"});
            this.physicalTileProperties.Location = new System.Drawing.Point(0, 91);
            this.physicalTileProperties.Name = "physicalTileProperties";
            this.physicalTileProperties.Size = new System.Drawing.Size(222, 64);
            this.physicalTileProperties.TabIndex = 165;
            this.physicalTileProperties.SelectedIndexChanged += new System.EventHandler(this.physicalTileProperties_SelectedIndexChanged);
            // 
            // label75
            // 
            this.label75.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label75.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label75.Location = new System.Drawing.Point(0, 156);
            this.label75.Name = "label75";
            this.label75.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label75.Size = new System.Drawing.Size(135, 17);
            this.label75.TabIndex = 354;
            this.label75.Text = "Conveyor belt runs";
            // 
            // panel44
            // 
            this.panel44.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel44.BackColor = System.Drawing.SystemColors.Window;
            this.panel44.Controls.Add(this.physicalTileConveyor);
            this.panel44.Location = new System.Drawing.Point(136, 156);
            this.panel44.Name = "panel44";
            this.panel44.Size = new System.Drawing.Size(87, 17);
            this.panel44.TabIndex = 166;
            // 
            // physicalTileConveyor
            // 
            this.physicalTileConveyor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.physicalTileConveyor.Enabled = false;
            this.physicalTileConveyor.Items.AddRange(new object[] {
            "Right",
            "Down-right",
            "Down",
            "Down-left",
            "Left",
            "Up-left",
            "Up",
            "Up-right"});
            this.physicalTileConveyor.Location = new System.Drawing.Point(-2, -2);
            this.physicalTileConveyor.Name = "physicalTileConveyor";
            this.physicalTileConveyor.Size = new System.Drawing.Size(91, 21);
            this.physicalTileConveyor.TabIndex = 370;
            this.physicalTileConveyor.SelectedIndexChanged += new System.EventHandler(this.physicalTileConveyor_SelectedIndexChanged);
            // 
            // physicalTileEdges
            // 
            this.physicalTileEdges.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.physicalTileEdges.BackColor = System.Drawing.SystemColors.Window;
            this.physicalTileEdges.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.physicalTileEdges.CheckOnClick = true;
            this.physicalTileEdges.ColumnWidth = 118;
            this.physicalTileEdges.Enabled = false;
            this.physicalTileEdges.Items.AddRange(new object[] {
            "NW edge is solid",
            "NE edge is solid",
            "SW edge is solid",
            "SE edge is solid"});
            this.physicalTileEdges.Location = new System.Drawing.Point(0, 174);
            this.physicalTileEdges.Name = "physicalTileEdges";
            this.physicalTileEdges.Size = new System.Drawing.Size(222, 64);
            this.physicalTileEdges.TabIndex = 167;
            this.physicalTileEdges.SelectedIndexChanged += new System.EventHandler(this.physicalTileEdges_SelectedIndexChanged);
            // 
            // label68
            // 
            this.label68.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label68.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label68.Location = new System.Drawing.Point(0, 19);
            this.label68.Name = "label68";
            this.label68.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label68.Size = new System.Drawing.Size(135, 17);
            this.label68.TabIndex = 358;
            this.label68.Text = "Height of base tile";
            // 
            // label74
            // 
            this.label74.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label74.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label74.Location = new System.Drawing.Point(0, 73);
            this.label74.Name = "label74";
            this.label74.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label74.Size = new System.Drawing.Size(135, 17);
            this.label74.TabIndex = 355;
            this.label74.Text = "Z Coord of water tile";
            // 
            // label72
            // 
            this.label72.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label72.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label72.Location = new System.Drawing.Point(0, 37);
            this.label72.Name = "label72";
            this.label72.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label72.Size = new System.Drawing.Size(135, 17);
            this.label72.TabIndex = 360;
            this.label72.Text = "Height of overhead tile";
            // 
            // label73
            // 
            this.label73.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label73.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label73.Location = new System.Drawing.Point(0, 55);
            this.label73.Name = "label73";
            this.label73.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label73.Size = new System.Drawing.Size(135, 17);
            this.label73.TabIndex = 359;
            this.label73.Text = "Z Coord of overhead tile";
            // 
            // physicalTilePriority3
            // 
            this.physicalTilePriority3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.physicalTilePriority3.BackColor = System.Drawing.SystemColors.Window;
            this.physicalTilePriority3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.physicalTilePriority3.CheckOnClick = true;
            this.physicalTilePriority3.ColumnWidth = 118;
            this.physicalTilePriority3.Enabled = false;
            this.physicalTilePriority3.Items.AddRange(new object[] {
            "Priority 3 for npcs on tile edge",
            "Priority 3 for npcs above tile edge",
            "Priority 3 for npcs on tile",
            "Solid quadrant flag"});
            this.physicalTilePriority3.Location = new System.Drawing.Point(0, 322);
            this.physicalTilePriority3.Name = "physicalTilePriority3";
            this.physicalTilePriority3.Size = new System.Drawing.Size(222, 64);
            this.physicalTilePriority3.TabIndex = 170;
            this.physicalTilePriority3.SelectedIndexChanged += new System.EventHandler(this.physicalTilePriority3_SelectedIndexChanged);
            // 
            // label94
            // 
            this.label94.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label94.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label94.ForeColor = System.Drawing.SystemColors.Control;
            this.label94.Location = new System.Drawing.Point(0, 0);
            this.label94.Name = "label94";
            this.label94.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label94.Size = new System.Drawing.Size(135, 17);
            this.label94.TabIndex = 374;
            this.label94.Text = "PHYSICAL TILE #";
            this.label94.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // physicalTileSearchButton
            // 
            this.physicalTileSearchButton.BackColor = System.Drawing.Color.Yellow;
            this.physicalTileSearchButton.FlatAppearance.BorderSize = 0;
            this.physicalTileSearchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.physicalTileSearchButton.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.physicalTileSearchButton.Location = new System.Drawing.Point(0, 19);
            this.physicalTileSearchButton.Name = "physicalTileSearchButton";
            this.physicalTileSearchButton.Size = new System.Drawing.Size(222, 17);
            this.physicalTileSearchButton.TabIndex = 172;
            this.physicalTileSearchButton.Text = "SEARCH FOR PHYSICAL TILE...";
            this.physicalTileSearchButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.physicalTileSearchButton.UseCompatibleTextRendering = true;
            this.physicalTileSearchButton.UseVisualStyleBackColor = false;
            this.physicalTileSearchButton.Click += new System.EventHandler(this.physicalTileSearchButton_Click);
            // 
            // physicalTileNum
            // 
            this.physicalTileNum.BackColor = System.Drawing.SystemColors.ControlDark;
            this.physicalTileNum.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.physicalTileNum.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.physicalTileNum.ForeColor = System.Drawing.SystemColors.Control;
            this.physicalTileNum.Location = new System.Drawing.Point(136, 0);
            this.physicalTileNum.Maximum = new decimal(new int[] {
            1023,
            0,
            0,
            0});
            this.physicalTileNum.Name = "physicalTileNum";
            this.physicalTileNum.Size = new System.Drawing.Size(87, 17);
            this.physicalTileNum.TabIndex = 160;
            this.physicalTileNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.physicalTileNum.ValueChanged += new System.EventHandler(this.physicalTileNum_ValueChanged);
            // 
            // tabPage6
            // 
            this.tabPage6.BackColor = System.Drawing.SystemColors.ControlText;
            this.tabPage6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPage6.Controls.Add(this.panel41);
            this.tabPage6.Location = new System.Drawing.Point(4, 23);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(260, 609);
            this.tabPage6.TabIndex = 2;
            this.tabPage6.Text = "L3";
            // 
            // panel41
            // 
            this.panel41.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel41.BackgroundImage = global::LAZYSHELL.Properties.Resources._bg;
            this.panel41.Controls.Add(this.panel94);
            this.panel41.Location = new System.Drawing.Point(1, 1);
            this.panel41.Name = "panel41";
            this.panel41.Size = new System.Drawing.Size(256, 605);
            this.panel41.TabIndex = 439;
            // 
            // panel94
            // 
            this.panel94.Controls.Add(this.pictureBoxTilesetL3);
            this.panel94.Location = new System.Drawing.Point(-2, 0);
            this.panel94.Name = "panel94";
            this.panel94.Size = new System.Drawing.Size(260, 514);
            this.panel94.TabIndex = 440;
            // 
            // pictureBoxTilesetL3
            // 
            this.pictureBoxTilesetL3.BackgroundImage = global::LAZYSHELL.Properties.Resources._transparent;
            this.pictureBoxTilesetL3.ContextMenuStrip = this.contextMenuStrip2;
            this.pictureBoxTilesetL3.Cursor = System.Windows.Forms.Cursors.Cross;
            this.pictureBoxTilesetL3.Location = new System.Drawing.Point(2, 0);
            this.pictureBoxTilesetL3.Name = "pictureBoxTilesetL3";
            this.pictureBoxTilesetL3.Size = new System.Drawing.Size(256, 512);
            this.pictureBoxTilesetL3.TabIndex = 2;
            this.pictureBoxTilesetL3.TabStop = false;
            this.pictureBoxTilesetL3.MouseLeave += new System.EventHandler(this.pictureBoxTilesetL3_MouseLeave);
            this.pictureBoxTilesetL3.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.pictureBoxTilesetL3_PreviewKeyDown);
            this.pictureBoxTilesetL3.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxTilesetL3_MouseMove);
            this.pictureBoxTilesetL3.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pictureBoxTilesetL3_MouseDoubleClick);
            this.pictureBoxTilesetL3.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBoxTilesetL3_MouseClick);
            this.pictureBoxTilesetL3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxTilesetL3_MouseDown);
            this.pictureBoxTilesetL3.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxTilesetL3_Paint);
            this.pictureBoxTilesetL3.MouseEnter += new System.EventHandler(this.pictureBoxTilesetL3_MouseEnter);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.ControlText;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panelColorBalance);
            this.panel1.Controls.Add(this.panelOverlapTileset);
            this.panel1.Controls.Add(this.changeLevelName);
            this.panel1.Controls.Add(this.searchLevelNames);
            this.panel1.Controls.Add(this.panelChangeLevelName);
            this.panel1.Controls.Add(this.panelSearchLevelNames);
            this.panel1.Controls.Add(this.label36);
            this.panel1.Controls.Add(this.levelNum);
            this.panel1.Controls.Add(this.label26);
            this.panel1.Controls.Add(this.labelOrthCoords);
            this.panel1.Controls.Add(this.panel27);
            this.panel1.Controls.Add(this.panelLevelPicture);
            this.panel1.Controls.Add(this.areaPropertiesPanel);
            this.panel1.Controls.Add(this.labelTileCoords);
            this.panel1.Controls.Add(this.labelPixelCoords);
            this.panel1.Controls.Add(this.panelTemplates);
            this.panel1.Controls.Add(this.panelTilesets);
            this.panel1.Location = new System.Drawing.Point(12, 54);
            this.panel1.MinimumSize = new System.Drawing.Size(990, 659);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(990, 659);
            this.panel1.TabIndex = 2;
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // panelColorBalance
            // 
            this.panelColorBalance.BackColor = System.Drawing.SystemColors.ControlText;
            this.panelColorBalance.Controls.Add(this.colEditBFPanel);
            this.panelColorBalance.Controls.Add(this.colEditApply);
            this.panelColorBalance.Controls.Add(this.colEditReset);
            this.panelColorBalance.Controls.Add(this.colEditRedo);
            this.panelColorBalance.Controls.Add(this.colEditUndo);
            this.panelColorBalance.Controls.Add(this.panel104);
            this.panelColorBalance.Controls.Add(this.panel103);
            this.panelColorBalance.Controls.Add(this.panel101);
            this.panelColorBalance.Controls.Add(this.label139);
            this.panelColorBalance.Location = new System.Drawing.Point(247, 348);
            this.panelColorBalance.Name = "panelColorBalance";
            this.panelColorBalance.Size = new System.Drawing.Size(276, 247);
            this.panelColorBalance.TabIndex = 439;
            this.panelColorBalance.Visible = false;
            // 
            // colEditBFPanel
            // 
            this.colEditBFPanel.Controls.Add(this.colEditApplyBF);
            this.colEditBFPanel.Controls.Add(this.colEditUndoBF);
            this.colEditBFPanel.Controls.Add(this.colEditResetBF);
            this.colEditBFPanel.Controls.Add(this.colEditRedoBF);
            this.colEditBFPanel.Location = new System.Drawing.Point(2, 228);
            this.colEditBFPanel.Name = "colEditBFPanel";
            this.colEditBFPanel.Size = new System.Drawing.Size(274, 17);
            this.colEditBFPanel.TabIndex = 152;
            // 
            // colEditApplyBF
            // 
            this.colEditApplyBF.BackColor = System.Drawing.SystemColors.Window;
            this.colEditApplyBF.FlatAppearance.BorderSize = 0;
            this.colEditApplyBF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colEditApplyBF.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colEditApplyBF.Location = new System.Drawing.Point(0, 0);
            this.colEditApplyBF.Name = "colEditApplyBF";
            this.colEditApplyBF.Size = new System.Drawing.Size(112, 17);
            this.colEditApplyBF.TabIndex = 4;
            this.colEditApplyBF.Text = "APPLY";
            this.colEditApplyBF.UseCompatibleTextRendering = true;
            this.colEditApplyBF.UseVisualStyleBackColor = false;
            this.colEditApplyBF.Click += new System.EventHandler(this.colEditApplyBF_Click);
            // 
            // colEditUndoBF
            // 
            this.colEditUndoBF.BackColor = System.Drawing.SystemColors.Window;
            this.colEditUndoBF.FlatAppearance.BorderSize = 0;
            this.colEditUndoBF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colEditUndoBF.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colEditUndoBF.Image = global::LAZYSHELL.Properties.Resources.undo_small;
            this.colEditUndoBF.Location = new System.Drawing.Point(227, 0);
            this.colEditUndoBF.Name = "colEditUndoBF";
            this.colEditUndoBF.Size = new System.Drawing.Size(22, 17);
            this.colEditUndoBF.TabIndex = 6;
            this.colEditUndoBF.UseCompatibleTextRendering = true;
            this.colEditUndoBF.UseVisualStyleBackColor = false;
            this.colEditUndoBF.Click += new System.EventHandler(this.colEditUndoBF_Click);
            // 
            // colEditResetBF
            // 
            this.colEditResetBF.BackColor = System.Drawing.SystemColors.Window;
            this.colEditResetBF.FlatAppearance.BorderSize = 0;
            this.colEditResetBF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colEditResetBF.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colEditResetBF.Location = new System.Drawing.Point(113, 0);
            this.colEditResetBF.Name = "colEditResetBF";
            this.colEditResetBF.Size = new System.Drawing.Size(112, 17);
            this.colEditResetBF.TabIndex = 5;
            this.colEditResetBF.Text = "RESET";
            this.colEditResetBF.UseCompatibleTextRendering = true;
            this.colEditResetBF.UseVisualStyleBackColor = false;
            this.colEditResetBF.Click += new System.EventHandler(this.colEditResetBF_Click);
            // 
            // colEditRedoBF
            // 
            this.colEditRedoBF.BackColor = System.Drawing.SystemColors.Window;
            this.colEditRedoBF.FlatAppearance.BorderSize = 0;
            this.colEditRedoBF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colEditRedoBF.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colEditRedoBF.Image = global::LAZYSHELL.Properties.Resources.redo_small;
            this.colEditRedoBF.Location = new System.Drawing.Point(250, 0);
            this.colEditRedoBF.Name = "colEditRedoBF";
            this.colEditRedoBF.Size = new System.Drawing.Size(22, 17);
            this.colEditRedoBF.TabIndex = 7;
            this.colEditRedoBF.UseCompatibleTextRendering = true;
            this.colEditRedoBF.UseVisualStyleBackColor = false;
            this.colEditRedoBF.Click += new System.EventHandler(this.colEditRedoBF_Click);
            // 
            // colEditRedo
            // 
            this.colEditRedo.BackColor = System.Drawing.SystemColors.Window;
            this.colEditRedo.FlatAppearance.BorderSize = 0;
            this.colEditRedo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colEditRedo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colEditRedo.Image = global::LAZYSHELL.Properties.Resources.redo_small;
            this.colEditRedo.Location = new System.Drawing.Point(252, 228);
            this.colEditRedo.Name = "colEditRedo";
            this.colEditRedo.Size = new System.Drawing.Size(22, 17);
            this.colEditRedo.TabIndex = 7;
            this.toolTip1.SetToolTip(this.colEditRedo, "Redo");
            this.colEditRedo.UseCompatibleTextRendering = true;
            this.colEditRedo.UseVisualStyleBackColor = false;
            this.colEditRedo.Click += new System.EventHandler(this.colEditRedo_Click);
            // 
            // colEditUndo
            // 
            this.colEditUndo.BackColor = System.Drawing.SystemColors.Window;
            this.colEditUndo.FlatAppearance.BorderSize = 0;
            this.colEditUndo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colEditUndo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colEditUndo.Image = global::LAZYSHELL.Properties.Resources.undo_small;
            this.colEditUndo.Location = new System.Drawing.Point(229, 228);
            this.colEditUndo.Name = "colEditUndo";
            this.colEditUndo.Size = new System.Drawing.Size(22, 17);
            this.colEditUndo.TabIndex = 6;
            this.toolTip1.SetToolTip(this.colEditUndo, "Undo");
            this.colEditUndo.UseCompatibleTextRendering = true;
            this.colEditUndo.UseVisualStyleBackColor = false;
            this.colEditUndo.Click += new System.EventHandler(this.colEditUndo_Click);
            // 
            // panel104
            // 
            this.panel104.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.panel104.Controls.Add(this.label134);
            this.panel104.Controls.Add(this.colEditLabelA);
            this.panel104.Controls.Add(this.colEditLabelB);
            this.panel104.Controls.Add(this.panel100);
            this.panel104.Controls.Add(this.panel102);
            this.panel104.Controls.Add(this.colEditBlues);
            this.panel104.Controls.Add(this.colEditLabelC);
            this.panel104.Controls.Add(this.colEditGreens);
            this.panel104.Controls.Add(this.colEditLabelD);
            this.panel104.Controls.Add(this.colEditReds);
            this.panel104.Controls.Add(this.colEditValueA);
            this.panel104.Location = new System.Drawing.Point(2, 21);
            this.panel104.Name = "panel104";
            this.panel104.Size = new System.Drawing.Size(272, 54);
            this.panel104.TabIndex = 2;
            // 
            // panel103
            // 
            this.panel103.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.panel103.Controls.Add(this.label136);
            this.panel103.Controls.Add(this.colEditColors);
            this.panel103.Controls.Add(this.colEditRowSelectAll);
            this.panel103.Controls.Add(this.colEditSelectAll);
            this.panel103.Controls.Add(this.label138);
            this.panel103.Controls.Add(this.label143);
            this.panel103.Controls.Add(this.colEditSelectNone);
            this.panel103.Location = new System.Drawing.Point(2, 77);
            this.panel103.Name = "panel103";
            this.panel103.Size = new System.Drawing.Size(272, 149);
            this.panel103.TabIndex = 3;
            // 
            // label138
            // 
            this.label138.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label138.Location = new System.Drawing.Point(14, 19);
            this.label138.Name = "label138";
            this.label138.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label138.Size = new System.Drawing.Size(16, 17);
            this.label138.TabIndex = 157;
            this.label138.Text = "x";
            this.label138.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // colEditSelectNone
            // 
            this.colEditSelectNone.BackColor = System.Drawing.SystemColors.Control;
            this.colEditSelectNone.FlatAppearance.BorderSize = 0;
            this.colEditSelectNone.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colEditSelectNone.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colEditSelectNone.Location = new System.Drawing.Point(151, 19);
            this.colEditSelectNone.Name = "colEditSelectNone";
            this.colEditSelectNone.Size = new System.Drawing.Size(121, 17);
            this.colEditSelectNone.TabIndex = 154;
            this.colEditSelectNone.Text = "SELECT NONE";
            this.colEditSelectNone.UseCompatibleTextRendering = true;
            this.colEditSelectNone.UseVisualStyleBackColor = false;
            this.colEditSelectNone.Click += new System.EventHandler(this.colEditSelectNone_Click);
            // 
            // panelOverlapTileset
            // 
            this.panelOverlapTileset.Controls.Add(this.pictureBoxOverlaps);
            this.panelOverlapTileset.Location = new System.Drawing.Point(247, 61);
            this.panelOverlapTileset.Name = "panelOverlapTileset";
            this.panelOverlapTileset.Size = new System.Drawing.Size(260, 420);
            this.panelOverlapTileset.TabIndex = 449;
            this.panelOverlapTileset.Visible = false;
            // 
            // pictureBoxOverlaps
            // 
            this.pictureBoxOverlaps.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBoxOverlaps.BackgroundImage = global::LAZYSHELL.Properties.Resources._transparent;
            this.pictureBoxOverlaps.Location = new System.Drawing.Point(2, 2);
            this.pictureBoxOverlaps.Name = "pictureBoxOverlaps";
            this.pictureBoxOverlaps.Size = new System.Drawing.Size(256, 416);
            this.pictureBoxOverlaps.TabIndex = 0;
            this.pictureBoxOverlaps.TabStop = false;
            this.pictureBoxOverlaps.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBoxOverlaps_MouseClick);
            this.pictureBoxOverlaps.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxOverlaps_Paint);
            // 
            // changeLevelName
            // 
            this.changeLevelName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.changeLevelName.BackColor = System.Drawing.SystemColors.ControlDark;
            this.changeLevelName.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.changeLevelName.FlatAppearance.BorderSize = 0;
            this.changeLevelName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.changeLevelName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.changeLevelName.ForeColor = System.Drawing.SystemColors.Control;
            this.changeLevelName.Location = new System.Drawing.Point(277, 1);
            this.changeLevelName.Name = "changeLevelName";
            this.changeLevelName.Size = new System.Drawing.Size(49, 17);
            this.changeLevelName.TabIndex = 447;
            this.changeLevelName.Text = "LABEL";
            this.changeLevelName.UseCompatibleTextRendering = true;
            this.changeLevelName.UseVisualStyleBackColor = false;
            this.changeLevelName.Click += new System.EventHandler(this.changeLevelName_Click);
            // 
            // searchLevelNames
            // 
            this.searchLevelNames.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.searchLevelNames.BackColor = System.Drawing.SystemColors.ControlDark;
            this.searchLevelNames.BackgroundImage = global::LAZYSHELL.Properties.Resources.search;
            this.searchLevelNames.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.searchLevelNames.FlatAppearance.BorderSize = 0;
            this.searchLevelNames.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.searchLevelNames.Location = new System.Drawing.Point(255, 1);
            this.searchLevelNames.Name = "searchLevelNames";
            this.searchLevelNames.Size = new System.Drawing.Size(20, 17);
            this.searchLevelNames.TabIndex = 192;
            this.toolTip1.SetToolTip(this.searchLevelNames, "Search for level name");
            this.searchLevelNames.UseCompatibleTextRendering = true;
            this.searchLevelNames.UseVisualStyleBackColor = false;
            this.searchLevelNames.Click += new System.EventHandler(this.searchLevelNames_Click);
            // 
            // panelChangeLevelName
            // 
            this.panelChangeLevelName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelChangeLevelName.Controls.Add(this.defaultName);
            this.panelChangeLevelName.Controls.Add(this.panel98);
            this.panelChangeLevelName.Location = new System.Drawing.Point(275, 18);
            this.panelChangeLevelName.Name = "panelChangeLevelName";
            this.panelChangeLevelName.Size = new System.Drawing.Size(454, 21);
            this.panelChangeLevelName.TabIndex = 448;
            this.panelChangeLevelName.Visible = false;
            this.panelChangeLevelName.VisibleChanged += new System.EventHandler(this.panelChangeLevelName_VisibleChanged);
            // 
            // defaultName
            // 
            this.defaultName.BackColor = System.Drawing.SystemColors.Control;
            this.defaultName.FlatAppearance.BorderSize = 0;
            this.defaultName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.defaultName.Location = new System.Drawing.Point(384, 2);
            this.defaultName.Name = "defaultName";
            this.defaultName.Size = new System.Drawing.Size(68, 17);
            this.defaultName.TabIndex = 456;
            this.defaultName.Text = "DEFAULT";
            this.defaultName.UseCompatibleTextRendering = true;
            this.defaultName.UseVisualStyleBackColor = false;
            this.defaultName.Click += new System.EventHandler(this.defaultName_Click);
            // 
            // panel98
            // 
            this.panel98.BackColor = System.Drawing.SystemColors.Window;
            this.panel98.Controls.Add(this.textBox1);
            this.panel98.Location = new System.Drawing.Point(2, 2);
            this.panel98.Name = "panel98";
            this.panel98.Size = new System.Drawing.Size(380, 17);
            this.panel98.TabIndex = 457;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Location = new System.Drawing.Point(4, 2);
            this.textBox1.MaxLength = 128;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(372, 14);
            this.textBox1.TabIndex = 4;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            this.textBox1.Leave += new System.EventHandler(this.textBox1_Leave);
            // 
            // panelSearchLevelNames
            // 
            this.panelSearchLevelNames.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelSearchLevelNames.BackColor = System.Drawing.SystemColors.ControlText;
            this.panelSearchLevelNames.Controls.Add(this.panel58);
            this.panelSearchLevelNames.Controls.Add(this.listBoxLevelNames);
            this.panelSearchLevelNames.Location = new System.Drawing.Point(253, 18);
            this.panelSearchLevelNames.Name = "panelSearchLevelNames";
            this.panelSearchLevelNames.Size = new System.Drawing.Size(454, 426);
            this.panelSearchLevelNames.TabIndex = 446;
            this.panelSearchLevelNames.Visible = false;
            this.panelSearchLevelNames.VisibleChanged += new System.EventHandler(this.panelSearchLevelNames_VisibleChanged);
            // 
            // panel58
            // 
            this.panel58.BackColor = System.Drawing.SystemColors.Window;
            this.panel58.Controls.Add(this.nameTextBox);
            this.panel58.Location = new System.Drawing.Point(2, 2);
            this.panel58.Name = "panel58";
            this.panel58.Size = new System.Drawing.Size(450, 17);
            this.panel58.TabIndex = 193;
            // 
            // nameTextBox
            // 
            this.nameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.nameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.nameTextBox.Location = new System.Drawing.Point(4, 2);
            this.nameTextBox.MaxLength = 128;
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(444, 14);
            this.nameTextBox.TabIndex = 4;
            this.nameTextBox.TextChanged += new System.EventHandler(this.nameTextBox_TextChanged);
            this.nameTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nameTextBox_KeyDown);
            // 
            // listBoxLevelNames
            // 
            this.listBoxLevelNames.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBoxLevelNames.FormattingEnabled = true;
            this.listBoxLevelNames.Location = new System.Drawing.Point(2, 21);
            this.listBoxLevelNames.Name = "listBoxLevelNames";
            this.listBoxLevelNames.Size = new System.Drawing.Size(450, 403);
            this.listBoxLevelNames.TabIndex = 194;
            this.listBoxLevelNames.SelectedIndexChanged += new System.EventHandler(this.listBoxLevelNames_SelectedIndexChanged);
            this.listBoxLevelNames.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listBoxLevelNames_KeyDown);
            // 
            // label26
            // 
            this.label26.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label26.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label26.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.ForeColor = System.Drawing.SystemColors.Control;
            this.label26.Location = new System.Drawing.Point(522, 1);
            this.label26.Name = "label26";
            this.label26.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label26.Size = new System.Drawing.Size(195, 17);
            this.label26.TabIndex = 161;
            this.label26.Text = "EDITING: LAYER 1";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelOrthCoords
            // 
            this.labelOrthCoords.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelOrthCoords.BackColor = System.Drawing.SystemColors.Control;
            this.labelOrthCoords.Location = new System.Drawing.Point(409, 618);
            this.labelOrthCoords.Name = "labelOrthCoords";
            this.labelOrthCoords.Padding = new System.Windows.Forms.Padding(0, 0, 2, 2);
            this.labelOrthCoords.Size = new System.Drawing.Size(153, 18);
            this.labelOrthCoords.TabIndex = 160;
            this.labelOrthCoords.Text = "(0, 0)  Isometric Coords";
            this.labelOrthCoords.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel27
            // 
            this.panel27.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel27.BackColor = System.Drawing.SystemColors.Window;
            this.panel27.Controls.Add(this.levelName);
            this.panel27.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel27.Location = new System.Drawing.Point(1, 1);
            this.panel27.Name = "panel27";
            this.panel27.Size = new System.Drawing.Size(252, 17);
            this.panel27.TabIndex = 3;
            // 
            // panelLevelPicture
            // 
            this.panelLevelPicture.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelLevelPicture.AutoScroll = true;
            this.panelLevelPicture.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelLevelPicture.BackColor = System.Drawing.SystemColors.Control;
            this.panelLevelPicture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelLevelPicture.Controls.Add(this.pictureBoxLevel);
            this.panelLevelPicture.Location = new System.Drawing.Point(254, 19);
            this.panelLevelPicture.Name = "panelLevelPicture";
            this.panelLevelPicture.Size = new System.Drawing.Size(464, 598);
            this.panelLevelPicture.TabIndex = 191;
            this.panelLevelPicture.Scroll += new System.Windows.Forms.ScrollEventHandler(this.panelLevelPicture_Scroll);
            // 
            // pictureBoxLevel
            // 
            this.pictureBoxLevel.BackgroundImage = global::LAZYSHELL.Properties.Resources._transparent;
            this.pictureBoxLevel.ContextMenuStrip = this.contextMenuStrip1;
            this.pictureBoxLevel.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxLevel.Name = "pictureBoxLevel";
            this.pictureBoxLevel.Size = new System.Drawing.Size(1024, 1024);
            this.pictureBoxLevel.TabIndex = 0;
            this.pictureBoxLevel.TabStop = false;
            this.pictureBoxLevel.MouseLeave += new System.EventHandler(this.pictureBoxLevel_MouseLeave);
            this.pictureBoxLevel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxLevel_MouseMove);
            this.pictureBoxLevel.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pictureBoxLevel_MouseDoubleClick);
            this.pictureBoxLevel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxLevel_MouseDown);
            this.pictureBoxLevel.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxLevel_Paint);
            this.pictureBoxLevel.LostFocus += new System.EventHandler(this.pictureBoxLevel_LostFocus);
            this.pictureBoxLevel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBoxLevel_MouseUp);
            this.pictureBoxLevel.MouseEnter += new System.EventHandler(this.pictureBoxLevel_MouseEnter);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cutToolStripMenuItem1,
            this.copyToolStripMenuItem1,
            this.pasteToolStripMenuItem1,
            this.deleteToolStripMenuItem1,
            this.toolStripSeparator20,
            this.toolStripMenuItem5,
            this.toolStripSeparator24,
            this.saveImageToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.contextMenuStrip1.ShowImageMargin = false;
            this.contextMenuStrip1.Size = new System.Drawing.Size(131, 148);
            // 
            // cutToolStripMenuItem1
            // 
            this.cutToolStripMenuItem1.Name = "cutToolStripMenuItem1";
            this.cutToolStripMenuItem1.Size = new System.Drawing.Size(130, 22);
            this.cutToolStripMenuItem1.Text = "Cut";
            this.cutToolStripMenuItem1.Click += new System.EventHandler(this.cutToolStripMenuItem_Click);
            // 
            // copyToolStripMenuItem1
            // 
            this.copyToolStripMenuItem1.Name = "copyToolStripMenuItem1";
            this.copyToolStripMenuItem1.Size = new System.Drawing.Size(130, 22);
            this.copyToolStripMenuItem1.Text = "Copy";
            this.copyToolStripMenuItem1.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // pasteToolStripMenuItem1
            // 
            this.pasteToolStripMenuItem1.Name = "pasteToolStripMenuItem1";
            this.pasteToolStripMenuItem1.Size = new System.Drawing.Size(130, 22);
            this.pasteToolStripMenuItem1.Text = "Paste";
            this.pasteToolStripMenuItem1.Click += new System.EventHandler(this.pasteToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem1
            // 
            this.deleteToolStripMenuItem1.Name = "deleteToolStripMenuItem1";
            this.deleteToolStripMenuItem1.Size = new System.Drawing.Size(130, 22);
            this.deleteToolStripMenuItem1.Text = "Delete";
            this.deleteToolStripMenuItem1.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // toolStripSeparator20
            // 
            this.toolStripSeparator20.Name = "toolStripSeparator20";
            this.toolStripSeparator20.Size = new System.Drawing.Size(127, 6);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(130, 22);
            this.toolStripMenuItem5.Text = "Select in tileset";
            this.toolStripMenuItem5.Click += new System.EventHandler(this.toolStripMenuItem5_Click);
            // 
            // toolStripSeparator24
            // 
            this.toolStripSeparator24.Name = "toolStripSeparator24";
            this.toolStripSeparator24.Size = new System.Drawing.Size(127, 6);
            // 
            // saveImageToolStripMenuItem
            // 
            this.saveImageToolStripMenuItem.Name = "saveImageToolStripMenuItem";
            this.saveImageToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.saveImageToolStripMenuItem.Text = "Save image as...";
            this.saveImageToolStripMenuItem.Click += new System.EventHandler(this.exportLevelImagesCurrent_Click);
            // 
            // areaPropertiesPanel
            // 
            this.areaPropertiesPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.areaPropertiesPanel.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.areaPropertiesPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.areaPropertiesPanel.Controls.Add(this.Priorities);
            this.areaPropertiesPanel.Location = new System.Drawing.Point(0, 19);
            this.areaPropertiesPanel.Name = "areaPropertiesPanel";
            this.areaPropertiesPanel.Size = new System.Drawing.Size(254, 638);
            this.areaPropertiesPanel.TabIndex = 138;
            // 
            // Priorities
            // 
            this.Priorities.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.Priorities.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.Priorities.Controls.Add(this.tabPage3);
            this.Priorities.Controls.Add(this.tabPage4);
            this.Priorities.Controls.Add(this.tabPage8);
            this.Priorities.Controls.Add(this.tabPage9);
            this.Priorities.Controls.Add(this.tabPage10);
            this.Priorities.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Priorities.ItemSize = new System.Drawing.Size(44, 18);
            this.Priorities.Location = new System.Drawing.Point(0, 0);
            this.Priorities.Name = "Priorities";
            this.Priorities.Padding = new System.Drawing.Point(5, 4);
            this.Priorities.SelectedIndex = 0;
            this.Priorities.Size = new System.Drawing.Size(252, 636);
            this.Priorities.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.Priorities.TabIndex = 6;
            this.Priorities.SelectedIndexChanged += new System.EventHandler(this.Priorities_SelectedIndexChanged);
            // 
            // tabPage3
            // 
            this.tabPage3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPage3.Controls.Add(this.panel4);
            this.tabPage3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(244, 610);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "LAYER";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.panel4.BackColor = System.Drawing.SystemColors.ControlText;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.panel79);
            this.panel4.Controls.Add(this.panel78);
            this.panel4.Controls.Add(this.panel77);
            this.panel4.Controls.Add(this.panel76);
            this.panel4.Controls.Add(this.panel75);
            this.panel4.Controls.Add(this.panel74);
            this.panel4.Controls.Add(this.panel73);
            this.panel4.Controls.Add(this.panel64);
            this.panel4.Controls.Add(this.label53);
            this.panel4.Controls.Add(this.panel6);
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(242, 608);
            this.panel4.TabIndex = 0;
            // 
            // panel79
            // 
            this.panel79.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.panel79.Controls.Add(this.label110);
            this.panel79.Controls.Add(this.label39);
            this.panel79.Controls.Add(this.label38);
            this.panel79.Controls.Add(this.panel22);
            this.panel79.Controls.Add(this.panel26);
            this.panel79.Controls.Add(this.layerWaveEffect);
            this.panel79.Location = new System.Drawing.Point(0, 528);
            this.panel79.Name = "panel79";
            this.panel79.Size = new System.Drawing.Size(240, 54);
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
            this.label110.Size = new System.Drawing.Size(118, 17);
            this.label110.TabIndex = 122;
            this.label110.Text = "ANIMATION EFFECTS";
            this.label110.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label39
            // 
            this.label39.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label39.Location = new System.Drawing.Point(0, 19);
            this.label39.Name = "label39";
            this.label39.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label39.Size = new System.Drawing.Size(118, 17);
            this.label39.TabIndex = 189;
            this.label39.Text = "L3 Effects";
            // 
            // label38
            // 
            this.label38.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label38.Location = new System.Drawing.Point(0, 37);
            this.label38.Name = "label38";
            this.label38.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label38.Size = new System.Drawing.Size(118, 17);
            this.label38.TabIndex = 190;
            this.label38.Text = "Sprite Effects";
            // 
            // panel22
            // 
            this.panel22.BackColor = System.Drawing.SystemColors.Window;
            this.panel22.Controls.Add(this.layerL3Effects);
            this.panel22.Location = new System.Drawing.Point(119, 19);
            this.panel22.Name = "panel22";
            this.panel22.Size = new System.Drawing.Size(122, 17);
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
            this.layerL3Effects.Size = new System.Drawing.Size(126, 21);
            this.layerL3Effects.TabIndex = 119;
            this.layerL3Effects.SelectedIndexChanged += new System.EventHandler(this.layerL3Effects_SelectedIndexChanged);
            // 
            // panel26
            // 
            this.panel26.BackColor = System.Drawing.SystemColors.Window;
            this.panel26.Controls.Add(this.layerOBJEffects);
            this.panel26.Location = new System.Drawing.Point(119, 37);
            this.panel26.Name = "panel26";
            this.panel26.Size = new System.Drawing.Size(122, 17);
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
            this.layerOBJEffects.Size = new System.Drawing.Size(126, 21);
            this.layerOBJEffects.TabIndex = 119;
            this.layerOBJEffects.SelectedIndexChanged += new System.EventHandler(this.layerOBJEffects_SelectedIndexChanged);
            // 
            // layerWaveEffect
            // 
            this.layerWaveEffect.Appearance = System.Windows.Forms.Appearance.Button;
            this.layerWaveEffect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(220)))), ((int)(((byte)(212)))));
            this.layerWaveEffect.FlatAppearance.BorderSize = 0;
            this.layerWaveEffect.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(168)))), ((int)(((byte)(168)))));
            this.layerWaveEffect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.layerWaveEffect.ForeColor = System.Drawing.Color.Gray;
            this.layerWaveEffect.Location = new System.Drawing.Point(119, 0);
            this.layerWaveEffect.Name = "layerWaveEffect";
            this.layerWaveEffect.Size = new System.Drawing.Size(121, 17);
            this.layerWaveEffect.TabIndex = 47;
            this.layerWaveEffect.Text = "RIPPLING WATER";
            this.layerWaveEffect.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.layerWaveEffect.UseCompatibleTextRendering = true;
            this.layerWaveEffect.UseVisualStyleBackColor = false;
            this.layerWaveEffect.CheckedChanged += new System.EventHandler(this.layerWaveEffect_CheckedChanged);
            // 
            // panel78
            // 
            this.panel78.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
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
            this.panel78.Location = new System.Drawing.Point(0, 418);
            this.panel78.Name = "panel78";
            this.panel78.Size = new System.Drawing.Size(240, 108);
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
            this.label7.Size = new System.Drawing.Size(118, 17);
            this.label7.TabIndex = 108;
            this.label7.Text = "AUTOSCROLLING";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label85
            // 
            this.label85.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label85.Location = new System.Drawing.Point(0, 37);
            this.label85.Name = "label85";
            this.label85.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label85.Size = new System.Drawing.Size(118, 17);
            this.label85.TabIndex = 76;
            this.label85.Text = "L2 Scroll Direction";
            // 
            // label84
            // 
            this.label84.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label84.Location = new System.Drawing.Point(0, 55);
            this.label84.Name = "label84";
            this.label84.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label84.Size = new System.Drawing.Size(118, 17);
            this.label84.TabIndex = 78;
            this.label84.Text = "L2 Scroll Speed";
            // 
            // label83
            // 
            this.label83.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label83.Location = new System.Drawing.Point(0, 73);
            this.label83.Name = "label83";
            this.label83.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label83.Size = new System.Drawing.Size(118, 17);
            this.label83.TabIndex = 79;
            this.label83.Text = "L3 Scroll Direction";
            // 
            // label82
            // 
            this.label82.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label82.Location = new System.Drawing.Point(0, 91);
            this.label82.Name = "label82";
            this.label82.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label82.Size = new System.Drawing.Size(118, 17);
            this.label82.TabIndex = 81;
            this.label82.Text = "L3 Scroll Speed";
            // 
            // panel21
            // 
            this.panel21.BackColor = System.Drawing.SystemColors.Window;
            this.panel21.Controls.Add(this.layerL2ScrollDirection);
            this.panel21.Location = new System.Drawing.Point(119, 37);
            this.panel21.Name = "panel21";
            this.panel21.Size = new System.Drawing.Size(122, 17);
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
            this.layerL2ScrollDirection.Size = new System.Drawing.Size(126, 21);
            this.layerL2ScrollDirection.TabIndex = 64;
            this.layerL2ScrollDirection.SelectedIndexChanged += new System.EventHandler(this.layerL2ScrollDirection_SelectedIndexChanged);
            // 
            // panel23
            // 
            this.panel23.BackColor = System.Drawing.SystemColors.Window;
            this.panel23.Controls.Add(this.layerL2ScrollSpeed);
            this.panel23.Location = new System.Drawing.Point(119, 55);
            this.panel23.Name = "panel23";
            this.panel23.Size = new System.Drawing.Size(122, 17);
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
            this.layerL2ScrollSpeed.Size = new System.Drawing.Size(126, 21);
            this.layerL2ScrollSpeed.TabIndex = 64;
            this.layerL2ScrollSpeed.SelectedIndexChanged += new System.EventHandler(this.layerL2ScrollSpeed_SelectedIndexChanged);
            // 
            // panel24
            // 
            this.panel24.BackColor = System.Drawing.SystemColors.Window;
            this.panel24.Controls.Add(this.layerL3ScrollDirection);
            this.panel24.Location = new System.Drawing.Point(119, 73);
            this.panel24.Name = "panel24";
            this.panel24.Size = new System.Drawing.Size(122, 17);
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
            this.layerL3ScrollDirection.Size = new System.Drawing.Size(126, 21);
            this.layerL3ScrollDirection.TabIndex = 64;
            this.layerL3ScrollDirection.SelectedIndexChanged += new System.EventHandler(this.layerL3ScrollDirection_SelectedIndexChanged);
            // 
            // layerInfiniteAutoscroll
            // 
            this.layerInfiniteAutoscroll.Appearance = System.Windows.Forms.Appearance.Button;
            this.layerInfiniteAutoscroll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(220)))), ((int)(((byte)(212)))));
            this.layerInfiniteAutoscroll.FlatAppearance.BorderSize = 0;
            this.layerInfiniteAutoscroll.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(168)))), ((int)(((byte)(168)))));
            this.layerInfiniteAutoscroll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.layerInfiniteAutoscroll.ForeColor = System.Drawing.Color.Gray;
            this.layerInfiniteAutoscroll.Location = new System.Drawing.Point(119, 0);
            this.layerInfiniteAutoscroll.Name = "layerInfiniteAutoscroll";
            this.layerInfiniteAutoscroll.Size = new System.Drawing.Size(121, 17);
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
            this.panel25.Location = new System.Drawing.Point(119, 91);
            this.panel25.Name = "panel25";
            this.panel25.Size = new System.Drawing.Size(122, 17);
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
            this.layerL3ScrollSpeed.Size = new System.Drawing.Size(126, 21);
            this.layerL3ScrollSpeed.TabIndex = 64;
            this.layerL3ScrollSpeed.SelectedIndexChanged += new System.EventHandler(this.layerL3ScrollSpeed_SelectedIndexChanged);
            // 
            // layerL2ScrollShift
            // 
            this.layerL2ScrollShift.Appearance = System.Windows.Forms.Appearance.Button;
            this.layerL2ScrollShift.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(220)))), ((int)(((byte)(212)))));
            this.layerL2ScrollShift.FlatAppearance.BorderSize = 0;
            this.layerL2ScrollShift.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(168)))), ((int)(((byte)(168)))));
            this.layerL2ScrollShift.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.layerL2ScrollShift.ForeColor = System.Drawing.Color.Gray;
            this.layerL2ScrollShift.Location = new System.Drawing.Point(0, 19);
            this.layerL2ScrollShift.Name = "layerL2ScrollShift";
            this.layerL2ScrollShift.Size = new System.Drawing.Size(118, 17);
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
            this.layerL3ScrollShift.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(220)))), ((int)(((byte)(212)))));
            this.layerL3ScrollShift.FlatAppearance.BorderSize = 0;
            this.layerL3ScrollShift.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(168)))), ((int)(((byte)(168)))));
            this.layerL3ScrollShift.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.layerL3ScrollShift.ForeColor = System.Drawing.Color.Gray;
            this.layerL3ScrollShift.Location = new System.Drawing.Point(119, 19);
            this.layerL3ScrollShift.Name = "layerL3ScrollShift";
            this.layerL3ScrollShift.Size = new System.Drawing.Size(121, 17);
            this.layerL3ScrollShift.TabIndex = 42;
            this.layerL3ScrollShift.Text = "L3 SCROLL SHIFT";
            this.layerL3ScrollShift.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.layerL3ScrollShift.UseCompatibleTextRendering = true;
            this.layerL3ScrollShift.UseVisualStyleBackColor = false;
            this.layerL3ScrollShift.CheckedChanged += new System.EventHandler(this.layerL3ScrollShift_CheckedChanged);
            // 
            // panel77
            // 
            this.panel77.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.panel77.Controls.Add(this.label6);
            this.panel77.Controls.Add(this.label12);
            this.panel77.Controls.Add(this.label13);
            this.panel77.Controls.Add(this.label11);
            this.panel77.Controls.Add(this.label3);
            this.panel77.Controls.Add(this.panel16);
            this.panel77.Controls.Add(this.panel19);
            this.panel77.Controls.Add(this.panel18);
            this.panel77.Controls.Add(this.panel20);
            this.panel77.Location = new System.Drawing.Point(0, 326);
            this.panel77.Name = "panel77";
            this.panel77.Size = new System.Drawing.Size(240, 90);
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
            this.label6.Size = new System.Drawing.Size(240, 17);
            this.label6.TabIndex = 106;
            this.label6.Text = "LAYER SCROLLING SYNCHRONIZATION";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label12.Location = new System.Drawing.Point(0, 19);
            this.label12.Name = "label12";
            this.label12.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label12.Size = new System.Drawing.Size(118, 17);
            this.label12.TabIndex = 181;
            this.label12.Text = "L2 Vertical Sync";
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label13.Location = new System.Drawing.Point(0, 37);
            this.label13.Name = "label13";
            this.label13.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label13.Size = new System.Drawing.Size(118, 17);
            this.label13.TabIndex = 182;
            this.label13.Text = "L2 Horizontal Sync";
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label11.Location = new System.Drawing.Point(0, 55);
            this.label11.Name = "label11";
            this.label11.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label11.Size = new System.Drawing.Size(118, 17);
            this.label11.TabIndex = 183;
            this.label11.Text = "L3 Vertical Sync";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label3.Location = new System.Drawing.Point(0, 73);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label3.Size = new System.Drawing.Size(118, 17);
            this.label3.TabIndex = 184;
            this.label3.Text = "L3 Horizontal Sync";
            // 
            // panel16
            // 
            this.panel16.BackColor = System.Drawing.SystemColors.Window;
            this.panel16.Controls.Add(this.layerL2VSync);
            this.panel16.Location = new System.Drawing.Point(119, 19);
            this.panel16.Name = "panel16";
            this.panel16.Size = new System.Drawing.Size(121, 17);
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
            this.layerL2VSync.Size = new System.Drawing.Size(126, 21);
            this.layerL2VSync.TabIndex = 64;
            this.layerL2VSync.SelectedIndexChanged += new System.EventHandler(this.layerL2VSync_SelectedIndexChanged);
            // 
            // panel19
            // 
            this.panel19.BackColor = System.Drawing.SystemColors.Window;
            this.panel19.Controls.Add(this.layerL3VSync);
            this.panel19.Location = new System.Drawing.Point(119, 55);
            this.panel19.Name = "panel19";
            this.panel19.Size = new System.Drawing.Size(121, 17);
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
            this.layerL3VSync.Size = new System.Drawing.Size(126, 21);
            this.layerL3VSync.TabIndex = 64;
            this.layerL3VSync.SelectedIndexChanged += new System.EventHandler(this.layerL3VSync_SelectedIndexChanged);
            // 
            // panel18
            // 
            this.panel18.BackColor = System.Drawing.SystemColors.Window;
            this.panel18.Controls.Add(this.layerL2HSync);
            this.panel18.Location = new System.Drawing.Point(119, 37);
            this.panel18.Name = "panel18";
            this.panel18.Size = new System.Drawing.Size(121, 17);
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
            this.layerL2HSync.Size = new System.Drawing.Size(126, 21);
            this.layerL2HSync.TabIndex = 64;
            this.layerL2HSync.SelectedIndexChanged += new System.EventHandler(this.layerL2HSync_SelectedIndexChanged);
            // 
            // panel20
            // 
            this.panel20.BackColor = System.Drawing.SystemColors.Window;
            this.panel20.Controls.Add(this.layerL3HSync);
            this.panel20.Location = new System.Drawing.Point(119, 73);
            this.panel20.Name = "panel20";
            this.panel20.Size = new System.Drawing.Size(121, 17);
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
            this.layerL3HSync.Size = new System.Drawing.Size(126, 21);
            this.layerL3HSync.TabIndex = 64;
            this.layerL3HSync.SelectedIndexChanged += new System.EventHandler(this.layerL3HSync_SelectedIndexChanged);
            // 
            // panel76
            // 
            this.panel76.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.panel76.Controls.Add(this.label91);
            this.panel76.Controls.Add(this.layerScrollWrapping);
            this.panel76.Location = new System.Drawing.Point(0, 241);
            this.panel76.Name = "panel76";
            this.panel76.Size = new System.Drawing.Size(240, 83);
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
            this.label91.Size = new System.Drawing.Size(240, 17);
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
            this.layerScrollWrapping.Size = new System.Drawing.Size(240, 64);
            this.layerScrollWrapping.TabIndex = 35;
            this.layerScrollWrapping.SelectedIndexChanged += new System.EventHandler(this.layerScrollWrapping_SelectedIndexChanged);
            // 
            // panel75
            // 
            this.panel75.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.panel75.Controls.Add(this.label5);
            this.panel75.Controls.Add(this.layerL2LeftShift);
            this.panel75.Controls.Add(this.layerL2UpShift);
            this.panel75.Controls.Add(this.label23);
            this.panel75.Controls.Add(this.label10);
            this.panel75.Controls.Add(this.layerL3LeftShift);
            this.panel75.Controls.Add(this.label9);
            this.panel75.Controls.Add(this.layerL3UpShift);
            this.panel75.Controls.Add(this.label8);
            this.panel75.Location = new System.Drawing.Point(0, 185);
            this.panel75.Name = "panel75";
            this.panel75.Size = new System.Drawing.Size(240, 54);
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
            this.label5.Size = new System.Drawing.Size(240, 17);
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
            this.layerL2LeftShift.Size = new System.Drawing.Size(46, 17);
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
            this.layerL2UpShift.Size = new System.Drawing.Size(46, 17);
            this.layerL2UpShift.TabIndex = 33;
            this.layerL2UpShift.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.layerL2UpShift.ValueChanged += new System.EventHandler(this.layerL2UpShift_ValueChanged);
            // 
            // label23
            // 
            this.label23.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label23.Location = new System.Drawing.Point(0, 19);
            this.label23.Name = "label23";
            this.label23.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label23.Size = new System.Drawing.Size(74, 17);
            this.label23.TabIndex = 82;
            this.label23.Text = "L2 Left Shift";
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
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
            this.layerL3LeftShift.Location = new System.Drawing.Point(197, 19);
            this.layerL3LeftShift.Maximum = new decimal(new int[] {
            63,
            0,
            0,
            0});
            this.layerL3LeftShift.Name = "layerL3LeftShift";
            this.layerL3LeftShift.Size = new System.Drawing.Size(44, 17);
            this.layerL3LeftShift.TabIndex = 32;
            this.layerL3LeftShift.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.layerL3LeftShift.ValueChanged += new System.EventHandler(this.layerL3LeftShift_ValueChanged);
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label9.Location = new System.Drawing.Point(122, 19);
            this.label9.Name = "label9";
            this.label9.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label9.Size = new System.Drawing.Size(74, 17);
            this.label9.TabIndex = 85;
            this.label9.Text = "L3 Left Shift";
            // 
            // layerL3UpShift
            // 
            this.layerL3UpShift.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.layerL3UpShift.Location = new System.Drawing.Point(197, 37);
            this.layerL3UpShift.Maximum = new decimal(new int[] {
            63,
            0,
            0,
            0});
            this.layerL3UpShift.Name = "layerL3UpShift";
            this.layerL3UpShift.Size = new System.Drawing.Size(44, 17);
            this.layerL3UpShift.TabIndex = 34;
            this.layerL3UpShift.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.layerL3UpShift.ValueChanged += new System.EventHandler(this.layerL3UpShift_ValueChanged);
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label8.Location = new System.Drawing.Point(122, 37);
            this.label8.Name = "label8";
            this.label8.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label8.Size = new System.Drawing.Size(74, 17);
            this.label8.TabIndex = 86;
            this.label8.Text = "L3 Up Shift";
            // 
            // panel74
            // 
            this.panel74.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
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
            this.panel74.Location = new System.Drawing.Point(0, 129);
            this.panel74.Name = "panel74";
            this.panel74.Size = new System.Drawing.Size(240, 54);
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
            this.label4.Size = new System.Drawing.Size(121, 17);
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
            this.layerMaskHighX.Size = new System.Drawing.Size(46, 17);
            this.layerMaskHighX.TabIndex = 27;
            this.layerMaskHighX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.layerMaskHighX.ValueChanged += new System.EventHandler(this.layerMaskHighX_ValueChanged);
            // 
            // layerLockMask
            // 
            this.layerLockMask.Appearance = System.Windows.Forms.Appearance.Button;
            this.layerLockMask.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(220)))), ((int)(((byte)(212)))));
            this.layerLockMask.FlatAppearance.BorderSize = 0;
            this.layerLockMask.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(168)))), ((int)(((byte)(168)))));
            this.layerLockMask.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.layerLockMask.ForeColor = System.Drawing.Color.Gray;
            this.layerLockMask.Location = new System.Drawing.Point(122, 0);
            this.layerLockMask.Name = "layerLockMask";
            this.layerLockMask.Size = new System.Drawing.Size(118, 17);
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
            this.layerMaskLowX.Size = new System.Drawing.Size(46, 17);
            this.layerMaskLowX.TabIndex = 29;
            this.layerMaskLowX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.layerMaskLowX.ValueChanged += new System.EventHandler(this.layerMaskLowX_ValueChanged);
            // 
            // label25
            // 
            this.label25.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
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
            this.layerMaskHighY.Location = new System.Drawing.Point(197, 19);
            this.layerMaskHighY.Maximum = new decimal(new int[] {
            63,
            0,
            0,
            0});
            this.layerMaskHighY.Name = "layerMaskHighY";
            this.layerMaskHighY.Size = new System.Drawing.Size(44, 17);
            this.layerMaskHighY.TabIndex = 28;
            this.layerMaskHighY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.layerMaskHighY.ValueChanged += new System.EventHandler(this.layerMaskHighY_ValueChanged);
            // 
            // label24
            // 
            this.label24.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
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
            this.layerMaskLowY.Location = new System.Drawing.Point(197, 37);
            this.layerMaskLowY.Maximum = new decimal(new int[] {
            63,
            0,
            0,
            0});
            this.layerMaskLowY.Name = "layerMaskLowY";
            this.layerMaskLowY.Size = new System.Drawing.Size(44, 17);
            this.layerMaskLowY.TabIndex = 30;
            this.layerMaskLowY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.layerMaskLowY.ValueChanged += new System.EventHandler(this.layerMaskLowY_ValueChanged);
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label15.Location = new System.Drawing.Point(122, 19);
            this.label15.Name = "label15";
            this.label15.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label15.Size = new System.Drawing.Size(74, 17);
            this.label15.TabIndex = 100;
            this.label15.Text = "Bottom Edge";
            // 
            // labeasdfasd
            // 
            this.labeasdfasd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.labeasdfasd.Location = new System.Drawing.Point(122, 37);
            this.labeasdfasd.Name = "labeasdfasd";
            this.labeasdfasd.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.labeasdfasd.Size = new System.Drawing.Size(74, 17);
            this.labeasdfasd.TabIndex = 103;
            this.labeasdfasd.Text = "Top Edge";
            // 
            // panel73
            // 
            this.panel73.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
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
            this.panel73.Location = new System.Drawing.Point(0, 19);
            this.panel73.Name = "panel73";
            this.panel73.Size = new System.Drawing.Size(240, 108);
            this.panel73.TabIndex = 444;
            // 
            // panel86
            // 
            this.panel86.BackColor = System.Drawing.SystemColors.Control;
            this.panel86.Location = new System.Drawing.Point(122, 19);
            this.panel86.Name = "panel86";
            this.panel86.Size = new System.Drawing.Size(118, 17);
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
            this.label86.Size = new System.Drawing.Size(240, 17);
            this.label86.TabIndex = 141;
            this.label86.Text = "LAYER PRIORITIES";
            this.label86.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label20
            // 
            this.label20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label20.Location = new System.Drawing.Point(0, 37);
            this.label20.Name = "label20";
            this.label20.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label20.Size = new System.Drawing.Size(74, 17);
            this.label20.TabIndex = 123;
            this.label20.Text = "Mainscreen";
            // 
            // label21
            // 
            this.label21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label21.Location = new System.Drawing.Point(0, 55);
            this.label21.Name = "label21";
            this.label21.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label21.Size = new System.Drawing.Size(74, 17);
            this.label21.TabIndex = 138;
            this.label21.Text = "Subscreen";
            // 
            // label32
            // 
            this.label32.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
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
            this.layerPrioritySet.Size = new System.Drawing.Size(46, 17);
            this.layerPrioritySet.TabIndex = 8;
            this.layerPrioritySet.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.layerPrioritySet.ValueChanged += new System.EventHandler(this.layerPrioritySet_ValueChanged);
            // 
            // layerMainscreenL1
            // 
            this.layerMainscreenL1.Appearance = System.Windows.Forms.Appearance.Button;
            this.layerMainscreenL1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(220)))), ((int)(((byte)(212)))));
            this.layerMainscreenL1.FlatAppearance.BorderSize = 0;
            this.layerMainscreenL1.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(168)))), ((int)(((byte)(168)))));
            this.layerMainscreenL1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.layerMainscreenL1.ForeColor = System.Drawing.Color.Gray;
            this.layerMainscreenL1.Location = new System.Drawing.Point(75, 37);
            this.layerMainscreenL1.Name = "layerMainscreenL1";
            this.layerMainscreenL1.Size = new System.Drawing.Size(32, 17);
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
            this.layerSubscreenL1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(220)))), ((int)(((byte)(212)))));
            this.layerSubscreenL1.FlatAppearance.BorderSize = 0;
            this.layerSubscreenL1.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(168)))), ((int)(((byte)(168)))));
            this.layerSubscreenL1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.layerSubscreenL1.ForeColor = System.Drawing.Color.Gray;
            this.layerSubscreenL1.Location = new System.Drawing.Point(75, 55);
            this.layerSubscreenL1.Name = "layerSubscreenL1";
            this.layerSubscreenL1.Size = new System.Drawing.Size(32, 17);
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
            this.layerColorMathL1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(220)))), ((int)(((byte)(212)))));
            this.layerColorMathL1.FlatAppearance.BorderSize = 0;
            this.layerColorMathL1.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(168)))), ((int)(((byte)(168)))));
            this.layerColorMathL1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.layerColorMathL1.ForeColor = System.Drawing.Color.Gray;
            this.layerColorMathL1.Location = new System.Drawing.Point(75, 73);
            this.layerColorMathL1.Name = "layerColorMathL1";
            this.layerColorMathL1.Size = new System.Drawing.Size(32, 17);
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
            this.layerMainscreenL2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(220)))), ((int)(((byte)(212)))));
            this.layerMainscreenL2.FlatAppearance.BorderSize = 0;
            this.layerMainscreenL2.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(168)))), ((int)(((byte)(168)))));
            this.layerMainscreenL2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.layerMainscreenL2.ForeColor = System.Drawing.Color.Gray;
            this.layerMainscreenL2.Location = new System.Drawing.Point(108, 37);
            this.layerMainscreenL2.Name = "layerMainscreenL2";
            this.layerMainscreenL2.Size = new System.Drawing.Size(32, 17);
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
            this.layerSubscreenL2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(220)))), ((int)(((byte)(212)))));
            this.layerSubscreenL2.FlatAppearance.BorderSize = 0;
            this.layerSubscreenL2.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(168)))), ((int)(((byte)(168)))));
            this.layerSubscreenL2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.layerSubscreenL2.ForeColor = System.Drawing.Color.Gray;
            this.layerSubscreenL2.Location = new System.Drawing.Point(108, 55);
            this.layerSubscreenL2.Name = "layerSubscreenL2";
            this.layerSubscreenL2.Size = new System.Drawing.Size(32, 17);
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
            this.layerColorMathL2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(220)))), ((int)(((byte)(212)))));
            this.layerColorMathL2.FlatAppearance.BorderSize = 0;
            this.layerColorMathL2.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(168)))), ((int)(((byte)(168)))));
            this.layerColorMathL2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.layerColorMathL2.ForeColor = System.Drawing.Color.Gray;
            this.layerColorMathL2.Location = new System.Drawing.Point(108, 73);
            this.layerColorMathL2.Name = "layerColorMathL2";
            this.layerColorMathL2.Size = new System.Drawing.Size(32, 17);
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
            this.layerMainscreenL3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(220)))), ((int)(((byte)(212)))));
            this.layerMainscreenL3.FlatAppearance.BorderSize = 0;
            this.layerMainscreenL3.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(168)))), ((int)(((byte)(168)))));
            this.layerMainscreenL3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.layerMainscreenL3.ForeColor = System.Drawing.Color.Gray;
            this.layerMainscreenL3.Location = new System.Drawing.Point(141, 37);
            this.layerMainscreenL3.Name = "layerMainscreenL3";
            this.layerMainscreenL3.Size = new System.Drawing.Size(32, 17);
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
            this.layerSubscreenL3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(220)))), ((int)(((byte)(212)))));
            this.layerSubscreenL3.FlatAppearance.BorderSize = 0;
            this.layerSubscreenL3.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(168)))), ((int)(((byte)(168)))));
            this.layerSubscreenL3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.layerSubscreenL3.ForeColor = System.Drawing.Color.Gray;
            this.layerSubscreenL3.Location = new System.Drawing.Point(141, 55);
            this.layerSubscreenL3.Name = "layerSubscreenL3";
            this.layerSubscreenL3.Size = new System.Drawing.Size(32, 17);
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
            this.layerColorMathL3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(220)))), ((int)(((byte)(212)))));
            this.layerColorMathL3.FlatAppearance.BorderSize = 0;
            this.layerColorMathL3.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(168)))), ((int)(((byte)(168)))));
            this.layerColorMathL3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.layerColorMathL3.ForeColor = System.Drawing.Color.Gray;
            this.layerColorMathL3.Location = new System.Drawing.Point(141, 73);
            this.layerColorMathL3.Name = "layerColorMathL3";
            this.layerColorMathL3.Size = new System.Drawing.Size(32, 17);
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
            this.layerMainscreenNPC.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(220)))), ((int)(((byte)(212)))));
            this.layerMainscreenNPC.FlatAppearance.BorderSize = 0;
            this.layerMainscreenNPC.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(168)))), ((int)(((byte)(168)))));
            this.layerMainscreenNPC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.layerMainscreenNPC.ForeColor = System.Drawing.Color.Gray;
            this.layerMainscreenNPC.Location = new System.Drawing.Point(174, 37);
            this.layerMainscreenNPC.Name = "layerMainscreenNPC";
            this.layerMainscreenNPC.Size = new System.Drawing.Size(35, 17);
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
            this.layerSubscreenNPC.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(220)))), ((int)(((byte)(212)))));
            this.layerSubscreenNPC.FlatAppearance.BorderSize = 0;
            this.layerSubscreenNPC.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(168)))), ((int)(((byte)(168)))));
            this.layerSubscreenNPC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.layerSubscreenNPC.ForeColor = System.Drawing.Color.Gray;
            this.layerSubscreenNPC.Location = new System.Drawing.Point(174, 55);
            this.layerSubscreenNPC.Name = "layerSubscreenNPC";
            this.layerSubscreenNPC.Size = new System.Drawing.Size(35, 17);
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
            this.panel17.Location = new System.Drawing.Point(173, 91);
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
            this.layerColorMathMode.Size = new System.Drawing.Size(71, 21);
            this.layerColorMathMode.TabIndex = 119;
            this.layerColorMathMode.SelectedIndexChanged += new System.EventHandler(this.layerColorMathMode_SelectedIndexChanged);
            // 
            // layerColorMathNPC
            // 
            this.layerColorMathNPC.Appearance = System.Windows.Forms.Appearance.Button;
            this.layerColorMathNPC.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(220)))), ((int)(((byte)(212)))));
            this.layerColorMathNPC.FlatAppearance.BorderSize = 0;
            this.layerColorMathNPC.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(168)))), ((int)(((byte)(168)))));
            this.layerColorMathNPC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.layerColorMathNPC.ForeColor = System.Drawing.Color.Gray;
            this.layerColorMathNPC.Location = new System.Drawing.Point(174, 73);
            this.layerColorMathNPC.Name = "layerColorMathNPC";
            this.layerColorMathNPC.Size = new System.Drawing.Size(35, 17);
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
            this.panel14.Size = new System.Drawing.Size(46, 17);
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
            this.layerColorMathIntensity.Size = new System.Drawing.Size(50, 21);
            this.layerColorMathIntensity.TabIndex = 119;
            this.layerColorMathIntensity.SelectedIndexChanged += new System.EventHandler(this.layerColorMathIntensity_SelectedIndexChanged);
            // 
            // layerColorMathBG
            // 
            this.layerColorMathBG.Appearance = System.Windows.Forms.Appearance.Button;
            this.layerColorMathBG.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(220)))), ((int)(((byte)(212)))));
            this.layerColorMathBG.FlatAppearance.BorderSize = 0;
            this.layerColorMathBG.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(168)))), ((int)(((byte)(168)))));
            this.layerColorMathBG.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.layerColorMathBG.ForeColor = System.Drawing.Color.Gray;
            this.layerColorMathBG.Location = new System.Drawing.Point(210, 73);
            this.layerColorMathBG.Name = "layerColorMathBG";
            this.layerColorMathBG.Size = new System.Drawing.Size(30, 17);
            this.layerColorMathBG.TabIndex = 24;
            this.layerColorMathBG.Text = "BG";
            this.layerColorMathBG.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.layerColorMathBG.UseCompatibleTextRendering = true;
            this.layerColorMathBG.UseVisualStyleBackColor = false;
            this.layerColorMathBG.CheckedChanged += new System.EventHandler(this.layerColorMathBG_CheckedChanged);
            // 
            // label96
            // 
            this.label96.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label96.Location = new System.Drawing.Point(122, 91);
            this.label96.Name = "label96";
            this.label96.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label96.Size = new System.Drawing.Size(51, 17);
            this.label96.TabIndex = 177;
            this.label96.Text = "Mode";
            // 
            // checkBox15
            // 
            this.checkBox15.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(220)))), ((int)(((byte)(212)))));
            this.checkBox15.Enabled = false;
            this.checkBox15.FlatAppearance.BorderSize = 0;
            this.checkBox15.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(168)))), ((int)(((byte)(168)))));
            this.checkBox15.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox15.ForeColor = System.Drawing.Color.Gray;
            this.checkBox15.Location = new System.Drawing.Point(210, 55);
            this.checkBox15.Name = "checkBox15";
            this.checkBox15.Size = new System.Drawing.Size(30, 17);
            this.checkBox15.TabIndex = 19;
            this.checkBox15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBox15.UseCompatibleTextRendering = true;
            this.checkBox15.UseVisualStyleBackColor = false;
            // 
            // label95
            // 
            this.label95.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
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
            this.checkBox16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(220)))), ((int)(((byte)(212)))));
            this.checkBox16.Enabled = false;
            this.checkBox16.FlatAppearance.BorderSize = 0;
            this.checkBox16.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(168)))), ((int)(((byte)(168)))));
            this.checkBox16.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox16.ForeColor = System.Drawing.Color.Gray;
            this.checkBox16.Location = new System.Drawing.Point(210, 37);
            this.checkBox16.Name = "checkBox16";
            this.checkBox16.Size = new System.Drawing.Size(30, 17);
            this.checkBox16.TabIndex = 14;
            this.checkBox16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBox16.UseCompatibleTextRendering = true;
            this.checkBox16.UseVisualStyleBackColor = false;
            // 
            // label22
            // 
            this.label22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label22.Location = new System.Drawing.Point(0, 73);
            this.label22.Name = "label22";
            this.label22.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label22.Size = new System.Drawing.Size(74, 17);
            this.label22.TabIndex = 176;
            this.label22.Text = "Color Math";
            // 
            // panel64
            // 
            this.panel64.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.panel64.BackgroundImage = global::LAZYSHELL.Properties.Resources._bg;
            this.panel64.Location = new System.Drawing.Point(0, 584);
            this.panel64.Name = "panel64";
            this.panel64.Size = new System.Drawing.Size(240, 22);
            this.panel64.TabIndex = 441;
            // 
            // label53
            // 
            this.label53.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
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
            this.panel6.Size = new System.Drawing.Size(165, 17);
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
            this.layerMessageBox.Size = new System.Drawing.Size(170, 21);
            this.layerMessageBox.TabIndex = 119;
            this.layerMessageBox.SelectedIndexChanged += new System.EventHandler(this.layerMessageBox_SelectedIndexChanged);
            // 
            // tabPage4
            // 
            this.tabPage4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPage4.Controls.Add(this.panel28);
            this.tabPage4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(244, 610);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "MAP";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // panel28
            // 
            this.panel28.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.panel28.BackColor = System.Drawing.SystemColors.ControlText;
            this.panel28.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel28.Controls.Add(this.panel72);
            this.panel28.Controls.Add(this.panel71);
            this.panel28.Controls.Add(this.panel70);
            this.panel28.Controls.Add(this.panel69);
            this.panel28.Controls.Add(this.panel63);
            this.panel28.Controls.Add(this.label33);
            this.panel28.Controls.Add(this.mapNum);
            this.panel28.Location = new System.Drawing.Point(0, 0);
            this.panel28.Name = "panel28";
            this.panel28.Size = new System.Drawing.Size(242, 608);
            this.panel28.TabIndex = 0;
            // 
            // panel72
            // 
            this.panel72.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
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
            this.panel72.Location = new System.Drawing.Point(0, 19);
            this.panel72.Name = "panel72";
            this.panel72.Size = new System.Drawing.Size(240, 126);
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
            this.label87.Size = new System.Drawing.Size(240, 17);
            this.label87.TabIndex = 55;
            this.label87.Text = "GRAPHICS SETS";
            this.label87.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label44
            // 
            this.label44.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
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
            this.mapGFXSet1Num.Size = new System.Drawing.Size(43, 17);
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
            this.mapGFXSet2Num.Size = new System.Drawing.Size(43, 17);
            this.mapGFXSet2Num.TabIndex = 53;
            this.mapGFXSet2Num.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.mapGFXSet2Num.ValueChanged += new System.EventHandler(this.mapGFXSet2Num_ValueChanged);
            // 
            // panel31
            // 
            this.panel31.BackColor = System.Drawing.SystemColors.Window;
            this.panel31.Controls.Add(this.mapGFXSetL3Name);
            this.panel31.Location = new System.Drawing.Point(119, 109);
            this.panel31.Name = "panel31";
            this.panel31.Size = new System.Drawing.Size(122, 17);
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
            this.mapGFXSetL3Name.Size = new System.Drawing.Size(126, 21);
            this.mapGFXSetL3Name.TabIndex = 141;
            this.mapGFXSetL3Name.SelectedIndexChanged += new System.EventHandler(this.mapGFXSetL3Name_SelectedIndexChanged);
            // 
            // panel29
            // 
            this.panel29.BackColor = System.Drawing.SystemColors.Window;
            this.panel29.Controls.Add(this.mapGFXSet4Name);
            this.panel29.Location = new System.Drawing.Point(119, 73);
            this.panel29.Name = "panel29";
            this.panel29.Size = new System.Drawing.Size(122, 17);
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
            this.mapGFXSet4Name.Size = new System.Drawing.Size(126, 21);
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
            this.mapGFXSet3Num.Size = new System.Drawing.Size(43, 17);
            this.mapGFXSet3Num.TabIndex = 55;
            this.mapGFXSet3Num.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.mapGFXSet3Num.ValueChanged += new System.EventHandler(this.mapGFXSet3Num_ValueChanged);
            // 
            // panel12
            // 
            this.panel12.BackColor = System.Drawing.SystemColors.Window;
            this.panel12.Controls.Add(this.mapGFXSet2Name);
            this.panel12.Location = new System.Drawing.Point(119, 37);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(122, 17);
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
            this.mapGFXSet2Name.Size = new System.Drawing.Size(126, 21);
            this.mapGFXSet2Name.TabIndex = 119;
            this.mapGFXSet2Name.SelectedIndexChanged += new System.EventHandler(this.mapGFXSet2Name_SelectedIndexChanged);
            // 
            // panel30
            // 
            this.panel30.BackColor = System.Drawing.SystemColors.Window;
            this.panel30.Controls.Add(this.mapGFXSet5Name);
            this.panel30.Location = new System.Drawing.Point(119, 91);
            this.panel30.Name = "panel30";
            this.panel30.Size = new System.Drawing.Size(122, 17);
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
            this.mapGFXSet5Name.Size = new System.Drawing.Size(126, 21);
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
            this.mapGFXSet4Num.Size = new System.Drawing.Size(43, 17);
            this.mapGFXSet4Num.TabIndex = 57;
            this.mapGFXSet4Num.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.mapGFXSet4Num.ValueChanged += new System.EventHandler(this.mapGFXSet4Num_ValueChanged);
            // 
            // panel13
            // 
            this.panel13.BackColor = System.Drawing.SystemColors.Window;
            this.panel13.Controls.Add(this.mapGFXSet3Name);
            this.panel13.Location = new System.Drawing.Point(119, 55);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(122, 17);
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
            this.mapGFXSet3Name.Size = new System.Drawing.Size(126, 21);
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
            this.mapGFXSetL3Num.Size = new System.Drawing.Size(43, 17);
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
            this.mapGFXSet5Num.Size = new System.Drawing.Size(43, 17);
            this.mapGFXSet5Num.TabIndex = 59;
            this.mapGFXSet5Num.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.mapGFXSet5Num.ValueChanged += new System.EventHandler(this.mapGFXSet5Num_ValueChanged);
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.SystemColors.Window;
            this.panel11.Controls.Add(this.mapGFXSet1Name);
            this.panel11.Location = new System.Drawing.Point(119, 19);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(122, 17);
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
            this.mapGFXSet1Name.Size = new System.Drawing.Size(126, 21);
            this.mapGFXSet1Name.TabIndex = 118;
            this.mapGFXSet1Name.SelectedIndexChanged += new System.EventHandler(this.mapGFXSet1Name_SelectedIndexChanged);
            // 
            // panel71
            // 
            this.panel71.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
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
            this.panel71.Location = new System.Drawing.Point(0, 147);
            this.panel71.Name = "panel71";
            this.panel71.Size = new System.Drawing.Size(240, 72);
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
            this.label88.Size = new System.Drawing.Size(240, 17);
            this.label88.TabIndex = 153;
            this.label88.Text = "TILESETS";
            this.label88.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label40
            // 
            this.label40.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label40.Location = new System.Drawing.Point(0, 55);
            this.label40.Name = "label40";
            this.label40.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label40.Size = new System.Drawing.Size(74, 17);
            this.label40.TabIndex = 128;
            this.label40.Text = "L3 Tileset";
            // 
            // label35
            // 
            this.label35.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
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
            this.mapTilesetL3Num.Size = new System.Drawing.Size(43, 17);
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
            this.mapTilesetL2Num.Size = new System.Drawing.Size(43, 17);
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
            this.mapTilesetL1Num.Size = new System.Drawing.Size(43, 17);
            this.mapTilesetL1Num.TabIndex = 63;
            this.mapTilesetL1Num.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.mapTilesetL1Num.ValueChanged += new System.EventHandler(this.mapTilesetL1Num_ValueChanged);
            // 
            // panel32
            // 
            this.panel32.BackColor = System.Drawing.SystemColors.Window;
            this.panel32.Controls.Add(this.mapTilesetL2Name);
            this.panel32.Location = new System.Drawing.Point(119, 37);
            this.panel32.Name = "panel32";
            this.panel32.Size = new System.Drawing.Size(122, 17);
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
            this.mapTilesetL2Name.Size = new System.Drawing.Size(126, 21);
            this.mapTilesetL2Name.TabIndex = 130;
            this.mapTilesetL2Name.SelectedIndexChanged += new System.EventHandler(this.mapTilesetL2Name_SelectedIndexChanged);
            // 
            // label34
            // 
            this.label34.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
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
            this.panel33.Location = new System.Drawing.Point(119, 55);
            this.panel33.Name = "panel33";
            this.panel33.Size = new System.Drawing.Size(122, 17);
            this.panel33.TabIndex = 68;
            // 
            // mapTilesetL3Name
            // 
            this.mapTilesetL3Name.DropDownHeight = 200;
            this.mapTilesetL3Name.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mapTilesetL3Name.IntegralHeight = false;
            this.mapTilesetL3Name.Items.AddRange(new object[] {
            "{NOTHING}",
            "Booster Tower",
            "Mansion, inside",
            "Forest Maze",
            "Sunken Ship",
            "Kero Sewers",
            "--------",
            "Water",
            "Grasslands",
            "River",
            "--------",
            "Waterfall",
            "Clouds",
            "Yo\'ster Isle",
            "Maps",
            "Towns 2",
            "Sewers",
            "Houses, inside",
            "Grasslands 2",
            "Keep, throne",
            "Booster Hill",
            "Star Hill",
            "Marrymore Scene",
            "Nimbus Land",
            "Keep, inside",
            "Temples",
            "Desert",
            "--------",
            "Smithy Factory",
            "--------",
            "Smithy 2",
            "--------",
            "--------",
            "--------"});
            this.mapTilesetL3Name.Location = new System.Drawing.Point(-2, -2);
            this.mapTilesetL3Name.Name = "mapTilesetL3Name";
            this.mapTilesetL3Name.Size = new System.Drawing.Size(126, 21);
            this.mapTilesetL3Name.TabIndex = 131;
            this.mapTilesetL3Name.SelectedIndexChanged += new System.EventHandler(this.mapTilesetL3Name_SelectedIndexChanged);
            // 
            // panel34
            // 
            this.panel34.BackColor = System.Drawing.SystemColors.Window;
            this.panel34.Controls.Add(this.mapTilesetL1Name);
            this.panel34.Location = new System.Drawing.Point(119, 19);
            this.panel34.Name = "panel34";
            this.panel34.Size = new System.Drawing.Size(122, 17);
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
            this.mapTilesetL1Name.Size = new System.Drawing.Size(126, 21);
            this.mapTilesetL1Name.TabIndex = 129;
            this.mapTilesetL1Name.SelectedIndexChanged += new System.EventHandler(this.mapTilesetL1Name_SelectedIndexChanged);
            // 
            // panel70
            // 
            this.panel70.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
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
            this.panel70.Location = new System.Drawing.Point(0, 221);
            this.panel70.Name = "panel70";
            this.panel70.Size = new System.Drawing.Size(240, 108);
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
            this.label89.Size = new System.Drawing.Size(118, 17);
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
            this.mapTilemapL1Num.Size = new System.Drawing.Size(43, 17);
            this.mapTilemapL1Num.TabIndex = 70;
            this.mapTilemapL1Num.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.mapTilemapL1Num.ValueChanged += new System.EventHandler(this.mapTilemapL1Num_ValueChanged);
            // 
            // mapSetL3Priority
            // 
            this.mapSetL3Priority.Appearance = System.Windows.Forms.Appearance.Button;
            this.mapSetL3Priority.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(220)))), ((int)(((byte)(212)))));
            this.mapSetL3Priority.FlatAppearance.BorderSize = 0;
            this.mapSetL3Priority.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(168)))), ((int)(((byte)(168)))));
            this.mapSetL3Priority.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mapSetL3Priority.ForeColor = System.Drawing.Color.Gray;
            this.mapSetL3Priority.Location = new System.Drawing.Point(119, 0);
            this.mapSetL3Priority.Name = "mapSetL3Priority";
            this.mapSetL3Priority.Size = new System.Drawing.Size(121, 17);
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
            this.mapTilemapL2Num.Size = new System.Drawing.Size(43, 17);
            this.mapTilemapL2Num.TabIndex = 72;
            this.mapTilemapL2Num.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.mapTilemapL2Num.ValueChanged += new System.EventHandler(this.mapTilemapL2Num_ValueChanged);
            // 
            // panel35
            // 
            this.panel35.BackColor = System.Drawing.SystemColors.Window;
            this.panel35.Controls.Add(this.mapBattlefieldName);
            this.panel35.Location = new System.Drawing.Point(119, 91);
            this.panel35.Name = "panel35";
            this.panel35.Size = new System.Drawing.Size(122, 17);
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
            this.mapBattlefieldName.Size = new System.Drawing.Size(126, 21);
            this.mapBattlefieldName.TabIndex = 144;
            this.mapBattlefieldName.SelectedIndexChanged += new System.EventHandler(this.mapBattlefieldName_SelectedIndexChanged);
            // 
            // label43
            // 
            this.label43.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
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
            this.mapTilemapL3Num.Size = new System.Drawing.Size(43, 17);
            this.mapTilemapL3Num.TabIndex = 74;
            this.mapTilemapL3Num.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.mapTilemapL3Num.ValueChanged += new System.EventHandler(this.mapTilemapL3Num_ValueChanged);
            // 
            // panel36
            // 
            this.panel36.BackColor = System.Drawing.SystemColors.Window;
            this.panel36.Controls.Add(this.mapTilemapL3Name);
            this.panel36.Location = new System.Drawing.Point(119, 55);
            this.panel36.Name = "panel36";
            this.panel36.Size = new System.Drawing.Size(122, 17);
            this.panel36.TabIndex = 75;
            // 
            // mapTilemapL3Name
            // 
            this.mapTilemapL3Name.DropDownHeight = 200;
            this.mapTilemapL3Name.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mapTilemapL3Name.DropDownWidth = 200;
            this.mapTilemapL3Name.IntegralHeight = false;
            this.mapTilemapL3Name.Items.AddRange(new object[] {
            "{NOTHING}",
            "Booster\'s Tower 1 ",
            "Tadpole Pond 2 ",
            "Mushroom Kingdom Castle ",
            "Forest Maze 1",
            "Forest Maze 2",
            "Sunken Ship 1 ",
            "Kero Sewers 1",
            "Sunken Ship 2 ",
            "Booster\'s Tower 2 ",
            "--------",
            "Seashore",
            "Midas River ",
            "--------",
            "Waterfall ",
            "--------",
            "various areas…",
            "Sea",
            "Tadpole Pond 1 ",
            "Nimbus Clouds",
            "Chapel, main hall ",
            "Plains",
            "Yo\'ster Isle ",
            "Maps",
            "Mushroom Kingdom",
            "Sewers",
            "Pipehouse ",
            "Houses 1",
            "Bowser\'s Keep Throne",
            "Rose Way, area 1 ",
            "Houses 2",
            "--------",
            "Rose Way",
            "Moleville shacks ",
            "Houses 3",
            "Suite",
            "Sunken Ship 3",
            "Star Hill 2",
            "Vista Hill ",
            "Seaside Town beach ",
            "Grasslands 2",
            "Marrymore Scene",
            "--------",
            "Nimbus Land houses ",
            "Jinx\'s Dojo ",
            "Monstro Town houses",
            "Bowser\'s Keep 6-doors 1",
            "Pipe Rooms",
            "Culex\'s Room ",
            "Bowser\'s Keep 6-doors 2",
            "Bowser\'s Keep 2",
            "Bowser\'s Keep 3",
            "Bowser\'s Keep 6-doors 3",
            "Bowser\'s Keep 6-doors 4",
            "Belome Temple",
            "Land\'s End Desert",
            "Bowser\'s Keep 4",
            "Nimbus Land springs ",
            "Smithy Factory",
            "--------",
            "Smithy 2",
            "___nothing",
            "Star Hill 1",
            "--------"});
            this.mapTilemapL3Name.Location = new System.Drawing.Point(-2, -2);
            this.mapTilemapL3Name.Name = "mapTilemapL3Name";
            this.mapTilemapL3Name.Size = new System.Drawing.Size(126, 21);
            this.mapTilemapL3Name.TabIndex = 140;
            this.mapTilemapL3Name.SelectedIndexChanged += new System.EventHandler(this.mapTilemapL3Name_SelectedIndexChanged);
            // 
            // label42
            // 
            this.label42.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
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
            this.panel37.Location = new System.Drawing.Point(119, 19);
            this.panel37.Name = "panel37";
            this.panel37.Size = new System.Drawing.Size(122, 17);
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
            this.mapTilemapL1Name.Size = new System.Drawing.Size(126, 21);
            this.mapTilemapL1Name.TabIndex = 138;
            this.mapTilemapL1Name.SelectedIndexChanged += new System.EventHandler(this.mapTilemapL1Name_SelectedIndexChanged);
            // 
            // label41
            // 
            this.label41.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
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
            this.panel38.Location = new System.Drawing.Point(119, 73);
            this.panel38.Name = "panel38";
            this.panel38.Size = new System.Drawing.Size(122, 17);
            this.panel38.TabIndex = 77;
            // 
            // mapPhysicalMapName
            // 
            this.mapPhysicalMapName.DropDownHeight = 200;
            this.mapPhysicalMapName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mapPhysicalMapName.DropDownWidth = 200;
            this.mapPhysicalMapName.IntegralHeight = false;
            this.mapPhysicalMapName.Items.AddRange(new object[] {
            "Debug Room",
            "{NOTHING}",
            "Kero Sewers 1",
            "Bowser\'s Keep 1",
            "--------",
            "Mushroom Kingdom Castle",
            "--------",
            "--------",
            "Gardener\'s House",
            "Seaside Town",
            "--------",
            "Forest Maze 3",
            "Midas River, waterfall",
            "Forest Maze 4",
            "Rose Town",
            "--------",
            "Forest Maze 2",
            "___underground areas",
            "Sunken Ship 1",
            "Sunken Ship 2",
            "Tadpole Pond 2",
            "--------",
            "--------",
            "Mushroom Kingdom",
            "Mushroom Kingdom houses",
            "Bowser\'s Keep Throne",
            "Booster\'s Tower 2",
            "Booster\'s Tower 1",
            "Booster\'s Tower entrance",
            "Rose Way",
            "Moleville Mines 1",
            "Moleville Mines 2",
            "Moleville Mines 3",
            "Seaside Town houses",
            "--------",
            "Barrel Volcano 1",
            "Barrel Volcano 2",
            "Mario\'s Pad",
            "Rose Town houses",
            "Moleville shacks",
            "Kero Sewers 2",
            "--------",
            "--------",
            "Bowser\'s Keep 3",
            "Grate Guy\'s Casino",
            "Midas River",
            "Plains",
            "Grasslands",
            "Forest Maze Underground",
            "Forest Maze, area 7",
            "Land\'s End Underground",
            "Suite",
            "--------",
            "Nimbus clouds",
            "Nimbus Castle 1",
            "Nimbus Castle 2",
            "Barrel Volcano 3",
            "--------",
            "Sea",
            "Pipe Vault",
            "Seashore",
            "--------",
            "Smithy Factory 2",
            "Smithy Factory 3",
            "Smithy Factory 1",
            "Tadpole Pond 1",
            "Nimbus Land houses",
            "Star Hill 2",
            "Pipe Rooms",
            "--------",
            "--------",
            "Chapel, main hall",
            "Chapel sanctuary",
            "Bowser\'s Keep Bridge",
            "Belome\'s Temple 1",
            "--------",
            "--------",
            "Bandit\'s Way 1",
            "Bandit\'s Way 2",
            "Pipehouse",
            "Mushroom Way 1",
            "--------",
            "Kero Sewers 1",
            "Rose Way 1",
            "Waterfall tunnels",
            "Booster Pass 1",
            "Moleville",
            "Marrymore",
            "Marrymore houses",
            "Volcano map",
            "Sunken Ship 2",
            "Vista Hill",
            "Booster Hill",
            "Seaside Town beach",
            "Seaside Town",
            "Land\'s End 1",
            "Land\'s End 2",
            "Bean Valley",
            "Beanstalks",
            "--------",
            "Land\'s End 3",
            "Land\'s End desert",
            "Monstro Town houses",
            "Monstro Town",
            "Jinx\'s Dojo",
            "Bowser’s Keep 6-door 1",
            "--------",
            "Booster Pass secret",
            "Bowser\'s Keep 4",
            "Bowser\'s Keep 6-door 2",
            "Bowser\'s Keep Magikoopa",
            "Bowser\'s Keep 6-door 3",
            "Bowser\'s Keep 6-door 4",
            "Bowser\'s Keep 6-door 5",
            "Factory Grounds 1",
            "Factory Grounds 2",
            "Bowser\'s Keep 5",
            "Nimbus Clouds 2",
            "Smithy Factory 4",
            "Star Hill 1"});
            this.mapPhysicalMapName.Location = new System.Drawing.Point(-2, -2);
            this.mapPhysicalMapName.Name = "mapPhysicalMapName";
            this.mapPhysicalMapName.Size = new System.Drawing.Size(126, 21);
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
            this.mapPhysicalMapNum.Size = new System.Drawing.Size(43, 17);
            this.mapPhysicalMapNum.TabIndex = 76;
            this.mapPhysicalMapNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.mapPhysicalMapNum.ValueChanged += new System.EventHandler(this.mapPhysicalMapNum_ValueChanged);
            // 
            // label45
            // 
            this.label45.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label45.Location = new System.Drawing.Point(0, 73);
            this.label45.Name = "label45";
            this.label45.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label45.Size = new System.Drawing.Size(74, 17);
            this.label45.TabIndex = 152;
            this.label45.Text = "Physical Map";
            // 
            // panel39
            // 
            this.panel39.BackColor = System.Drawing.SystemColors.Window;
            this.panel39.Controls.Add(this.mapTilemapL2Name);
            this.panel39.Location = new System.Drawing.Point(119, 37);
            this.panel39.Name = "panel39";
            this.panel39.Size = new System.Drawing.Size(122, 17);
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
            this.mapTilemapL2Name.Size = new System.Drawing.Size(126, 21);
            this.mapTilemapL2Name.TabIndex = 139;
            this.mapTilemapL2Name.SelectedIndexChanged += new System.EventHandler(this.mapTilemapL2Name_SelectedIndexChanged);
            // 
            // label76
            // 
            this.label76.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
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
            this.mapBattlefieldNum.Size = new System.Drawing.Size(43, 17);
            this.mapBattlefieldNum.TabIndex = 78;
            this.mapBattlefieldNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.mapBattlefieldNum.ValueChanged += new System.EventHandler(this.mapBattlefieldNum_ValueChanged);
            // 
            // panel69
            // 
            this.panel69.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.panel69.Controls.Add(this.label114);
            this.panel69.Controls.Add(this.colorBalance);
            this.panel69.Controls.Add(this.paletteUpdate);
            this.panel69.Controls.Add(this.palettePictureBox);
            this.panel69.Controls.Add(this.paletteAutoUpdate);
            this.panel69.Controls.Add(this.mapPaletteRedNum);
            this.panel69.Controls.Add(this.label79);
            this.panel69.Controls.Add(this.panel40);
            this.panel69.Controls.Add(this.mapPaletteGreenNum);
            this.panel69.Controls.Add(this.label80);
            this.panel69.Controls.Add(this.mapPaletteBlueNum);
            this.panel69.Controls.Add(this.mapPaletteGreenBar);
            this.panel69.Controls.Add(this.label81);
            this.panel69.Controls.Add(this.mapPaletteSetNum);
            this.panel69.Controls.Add(this.label46);
            this.panel69.Controls.Add(this.mapPaletteRedBar);
            this.panel69.Controls.Add(this.mapPaletteBlueBar);
            this.panel69.Controls.Add(this.pictureBoxColor);
            this.panel69.Location = new System.Drawing.Point(0, 331);
            this.panel69.Name = "panel69";
            this.panel69.Size = new System.Drawing.Size(240, 234);
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
            this.label114.Size = new System.Drawing.Size(240, 17);
            this.label114.TabIndex = 160;
            this.label114.Text = "PALETTES";
            this.label114.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // colorBalance
            // 
            this.colorBalance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.colorBalance.FlatAppearance.BorderSize = 0;
            this.colorBalance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colorBalance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colorBalance.Location = new System.Drawing.Point(0, 198);
            this.colorBalance.Name = "colorBalance";
            this.colorBalance.Size = new System.Drawing.Size(240, 17);
            this.colorBalance.TabIndex = 89;
            this.colorBalance.Text = "COLOR MATH COMMANDS...";
            this.colorBalance.UseCompatibleTextRendering = true;
            this.colorBalance.UseVisualStyleBackColor = false;
            this.colorBalance.Click += new System.EventHandler(this.colorBalance_Click);
            // 
            // paletteUpdate
            // 
            this.paletteUpdate.BackColor = System.Drawing.SystemColors.Control;
            this.paletteUpdate.FlatAppearance.BorderSize = 0;
            this.paletteUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.paletteUpdate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paletteUpdate.Location = new System.Drawing.Point(119, 217);
            this.paletteUpdate.Name = "paletteUpdate";
            this.paletteUpdate.Size = new System.Drawing.Size(121, 17);
            this.paletteUpdate.TabIndex = 91;
            this.paletteUpdate.Text = "Update Level";
            this.paletteUpdate.UseCompatibleTextRendering = true;
            this.paletteUpdate.UseVisualStyleBackColor = false;
            this.paletteUpdate.Click += new System.EventHandler(this.paletteUpdate_Click);
            // 
            // palettePictureBox
            // 
            this.palettePictureBox.BackColor = System.Drawing.SystemColors.Control;
            this.palettePictureBox.ContextMenuStrip = this.contextMenuStrip3;
            this.palettePictureBox.Location = new System.Drawing.Point(0, 37);
            this.palettePictureBox.Name = "palettePictureBox";
            this.palettePictureBox.Size = new System.Drawing.Size(240, 105);
            this.palettePictureBox.TabIndex = 145;
            this.palettePictureBox.TabStop = false;
            this.palettePictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.palettePictureBox_MouseClick);
            this.palettePictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.palettePictureBox_Paint);
            // 
            // contextMenuStrip3
            // 
            this.contextMenuStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importPaletteSetToolStripMenuItem,
            this.exportPaletteSetToolStripMenuItem});
            this.contextMenuStrip3.Name = "contextMenuStrip3";
            this.contextMenuStrip3.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.contextMenuStrip3.ShowImageMargin = false;
            this.contextMenuStrip3.Size = new System.Drawing.Size(149, 48);
            // 
            // importPaletteSetToolStripMenuItem
            // 
            this.importPaletteSetToolStripMenuItem.Name = "importPaletteSetToolStripMenuItem";
            this.importPaletteSetToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.importPaletteSetToolStripMenuItem.Text = "Import palette set...";
            this.importPaletteSetToolStripMenuItem.Click += new System.EventHandler(this.importPaletteSetToolStripMenuItem_Click);
            // 
            // exportPaletteSetToolStripMenuItem
            // 
            this.exportPaletteSetToolStripMenuItem.Name = "exportPaletteSetToolStripMenuItem";
            this.exportPaletteSetToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.exportPaletteSetToolStripMenuItem.Text = "Export palette set...";
            this.exportPaletteSetToolStripMenuItem.Click += new System.EventHandler(this.exportPaletteSetToolStripMenuItem_Click);
            // 
            // paletteAutoUpdate
            // 
            this.paletteAutoUpdate.BackColor = System.Drawing.SystemColors.Control;
            this.paletteAutoUpdate.Checked = true;
            this.paletteAutoUpdate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.paletteAutoUpdate.Location = new System.Drawing.Point(0, 217);
            this.paletteAutoUpdate.Name = "paletteAutoUpdate";
            this.paletteAutoUpdate.Padding = new System.Windows.Forms.Padding(3, 1, 0, 0);
            this.paletteAutoUpdate.Size = new System.Drawing.Size(118, 17);
            this.paletteAutoUpdate.TabIndex = 90;
            this.paletteAutoUpdate.Text = "Auto Update";
            this.paletteAutoUpdate.UseCompatibleTextRendering = true;
            this.paletteAutoUpdate.UseVisualStyleBackColor = false;
            // 
            // mapPaletteRedNum
            // 
            this.mapPaletteRedNum.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.mapPaletteRedNum.Increment = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.mapPaletteRedNum.Location = new System.Drawing.Point(72, 143);
            this.mapPaletteRedNum.Maximum = new decimal(new int[] {
            248,
            0,
            0,
            0});
            this.mapPaletteRedNum.Name = "mapPaletteRedNum";
            this.mapPaletteRedNum.Size = new System.Drawing.Size(46, 17);
            this.mapPaletteRedNum.TabIndex = 83;
            this.mapPaletteRedNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.mapPaletteRedNum.ValueChanged += new System.EventHandler(this.mapPaletteRedNum_ValueChanged);
            // 
            // label79
            // 
            this.label79.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label79.Location = new System.Drawing.Point(54, 143);
            this.label79.Name = "label79";
            this.label79.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label79.Size = new System.Drawing.Size(17, 17);
            this.label79.TabIndex = 147;
            this.label79.Text = "R";
            this.label79.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel40
            // 
            this.panel40.BackColor = System.Drawing.SystemColors.Window;
            this.panel40.Controls.Add(this.mapPaletteSetName);
            this.panel40.Location = new System.Drawing.Point(119, 19);
            this.panel40.Name = "panel40";
            this.panel40.Size = new System.Drawing.Size(122, 17);
            this.panel40.TabIndex = 81;
            // 
            // mapPaletteSetName
            // 
            this.mapPaletteSetName.DropDownHeight = 200;
            this.mapPaletteSetName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mapPaletteSetName.DropDownWidth = 200;
            this.mapPaletteSetName.IntegralHeight = false;
            this.mapPaletteSetName.Items.AddRange(new object[] {
            "Bowser\'s Keep Throne",
            "____",
            "Moleville shacks",
            "Rose Town",
            "____",
            "____",
            "Grasslands 1",
            "____",
            "Bowser\'s Keep Lava",
            "Bowser\'s Keep, outside",
            "Mushroom Kingdom Castle",
            "Forest Maze",
            "Sunken Ship",
            "Sewers",
            "Mountains",
            "Mushroom Kingdom",
            "Marrymore",
            "____",
            "Booster Tower 1",
            "Underground",
            "Bowser\'s Keep 1",
            "Houses",
            "____",
            "____",
            "____",
            "Seaside Town",
            "Booster Tower entrance",
            "Seashore",
            "____",
            "Booster Hill",
            "Rose Way",
            "Nimbus Clouds",
            "Grasslands 2",
            "Culex\'s Room",
            "Plains 1",
            "Plains 2",
            "Nimbus Castle",
            "Grasslands 3",
            "Smithy Factory",
            "____",
            "Sea",
            "Tadpole Pond",
            "Yo\'ster Isle",
            "____",
            "Count Down",
            "Chapel Sanctuary",
            "Bowser\'s Keep Lava",
            "Pipe Rooms",
            "____",
            "Mushroom Kingdom dark",
            "Pipehouse",
            "Waterfall tunnels",
            "Rose Town houses",
            "Rose Town houses",
            "Sewers Gate",
            "Rose Town dark",
            "Booster Tower 2",
            "Suite",
            "Volcano Map",
            "Houses",
            "Star Hill",
            "Marrymore houses",
            "Sunken Ship 2",
            "Vista Hill",
            "Johnny\'s Room",
            "Marrymore Scene",
            "Booster Tower Balcony",
            "Bean Valley",
            "Nimbus Land houses",
            "Jinx\'s Dojo",
            "Monstro Town houses",
            "Monstro Town",
            "Bowser\'s Keep puzzles",
            "Beanstalks",
            "Land\'s End Desert",
            "Seashore sunset",
            "Belome Temple",
            "Nimbus Land",
            "Factory Grounds 2",
            "Factory Grounds 1",
            "Bowser\'s Keep repairs",
            "Nimbus Castle 2",
            "Ending: Toadofsky",
            "Nimbus Land springs",
            "Nimbus Land clouds",
            "Smithy 2",
            "____",
            "Ending: Yo\'ster Isle",
            "Smithy Pad",
            "____",
            "Ending: Nimbus Land",
            "Casino entrance",
            "Casino, inside",
            "Count Down"});
            this.mapPaletteSetName.Location = new System.Drawing.Point(-2, -2);
            this.mapPaletteSetName.Name = "mapPaletteSetName";
            this.mapPaletteSetName.Size = new System.Drawing.Size(126, 21);
            this.mapPaletteSetName.TabIndex = 158;
            this.mapPaletteSetName.SelectedIndexChanged += new System.EventHandler(this.mapPaletteSetName_SelectedIndexChanged);
            // 
            // mapPaletteGreenNum
            // 
            this.mapPaletteGreenNum.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.mapPaletteGreenNum.Increment = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.mapPaletteGreenNum.Location = new System.Drawing.Point(72, 161);
            this.mapPaletteGreenNum.Maximum = new decimal(new int[] {
            248,
            0,
            0,
            0});
            this.mapPaletteGreenNum.Name = "mapPaletteGreenNum";
            this.mapPaletteGreenNum.Size = new System.Drawing.Size(46, 17);
            this.mapPaletteGreenNum.TabIndex = 84;
            this.mapPaletteGreenNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.mapPaletteGreenNum.ValueChanged += new System.EventHandler(this.mapPaletteGreenNum_ValueChanged);
            // 
            // label80
            // 
            this.label80.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label80.Location = new System.Drawing.Point(54, 161);
            this.label80.Name = "label80";
            this.label80.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label80.Size = new System.Drawing.Size(17, 17);
            this.label80.TabIndex = 149;
            this.label80.Text = "G";
            this.label80.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // mapPaletteBlueNum
            // 
            this.mapPaletteBlueNum.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.mapPaletteBlueNum.Increment = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.mapPaletteBlueNum.Location = new System.Drawing.Point(72, 179);
            this.mapPaletteBlueNum.Maximum = new decimal(new int[] {
            248,
            0,
            0,
            0});
            this.mapPaletteBlueNum.Name = "mapPaletteBlueNum";
            this.mapPaletteBlueNum.Size = new System.Drawing.Size(46, 17);
            this.mapPaletteBlueNum.TabIndex = 85;
            this.mapPaletteBlueNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.mapPaletteBlueNum.ValueChanged += new System.EventHandler(this.mapPaletteBlueNum_ValueChanged);
            // 
            // mapPaletteGreenBar
            // 
            this.mapPaletteGreenBar.AutoSize = false;
            this.mapPaletteGreenBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.mapPaletteGreenBar.Location = new System.Drawing.Point(119, 161);
            this.mapPaletteGreenBar.Maximum = 248;
            this.mapPaletteGreenBar.Name = "mapPaletteGreenBar";
            this.mapPaletteGreenBar.Size = new System.Drawing.Size(121, 17);
            this.mapPaletteGreenBar.SmallChange = 8;
            this.mapPaletteGreenBar.TabIndex = 87;
            this.mapPaletteGreenBar.TickFrequency = 8;
            this.mapPaletteGreenBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.mapPaletteGreenBar.Scroll += new System.EventHandler(this.mapPaletteGreenBar_Scroll);
            // 
            // label81
            // 
            this.label81.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label81.Location = new System.Drawing.Point(54, 179);
            this.label81.Name = "label81";
            this.label81.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label81.Size = new System.Drawing.Size(17, 17);
            this.label81.TabIndex = 151;
            this.label81.Text = "B";
            this.label81.TextAlign = System.Drawing.ContentAlignment.TopCenter;
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
            this.mapPaletteSetNum.Size = new System.Drawing.Size(43, 17);
            this.mapPaletteSetNum.TabIndex = 80;
            this.mapPaletteSetNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.mapPaletteSetNum.ValueChanged += new System.EventHandler(this.mapPaletteSetNum_ValueChanged);
            // 
            // label46
            // 
            this.label46.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label46.Location = new System.Drawing.Point(0, 19);
            this.label46.Name = "label46";
            this.label46.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label46.Size = new System.Drawing.Size(74, 17);
            this.label46.TabIndex = 157;
            this.label46.Text = "Palette Set";
            // 
            // mapPaletteRedBar
            // 
            this.mapPaletteRedBar.AutoSize = false;
            this.mapPaletteRedBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.mapPaletteRedBar.Location = new System.Drawing.Point(119, 143);
            this.mapPaletteRedBar.Maximum = 248;
            this.mapPaletteRedBar.Name = "mapPaletteRedBar";
            this.mapPaletteRedBar.Size = new System.Drawing.Size(121, 17);
            this.mapPaletteRedBar.SmallChange = 8;
            this.mapPaletteRedBar.TabIndex = 86;
            this.mapPaletteRedBar.TickFrequency = 8;
            this.mapPaletteRedBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.mapPaletteRedBar.Scroll += new System.EventHandler(this.mapPaletteRedBar_Scroll);
            // 
            // mapPaletteBlueBar
            // 
            this.mapPaletteBlueBar.AutoSize = false;
            this.mapPaletteBlueBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.mapPaletteBlueBar.Location = new System.Drawing.Point(119, 179);
            this.mapPaletteBlueBar.Maximum = 248;
            this.mapPaletteBlueBar.Name = "mapPaletteBlueBar";
            this.mapPaletteBlueBar.Size = new System.Drawing.Size(121, 17);
            this.mapPaletteBlueBar.SmallChange = 8;
            this.mapPaletteBlueBar.TabIndex = 88;
            this.mapPaletteBlueBar.TickFrequency = 8;
            this.mapPaletteBlueBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.mapPaletteBlueBar.Scroll += new System.EventHandler(this.mapPaletteBlueBar_Scroll);
            // 
            // pictureBoxColor
            // 
            this.pictureBoxColor.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBoxColor.Location = new System.Drawing.Point(0, 143);
            this.pictureBoxColor.Name = "pictureBoxColor";
            this.pictureBoxColor.Size = new System.Drawing.Size(53, 53);
            this.pictureBoxColor.TabIndex = 438;
            this.pictureBoxColor.TabStop = false;
            // 
            // panel63
            // 
            this.panel63.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.panel63.BackgroundImage = global::LAZYSHELL.Properties.Resources._bg;
            this.panel63.Location = new System.Drawing.Point(0, 567);
            this.panel63.Name = "panel63";
            this.panel63.Size = new System.Drawing.Size(240, 39);
            this.panel63.TabIndex = 441;
            // 
            // labelTileCoords
            // 
            this.labelTileCoords.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTileCoords.BackColor = System.Drawing.SystemColors.Control;
            this.labelTileCoords.Location = new System.Drawing.Point(255, 618);
            this.labelTileCoords.Name = "labelTileCoords";
            this.labelTileCoords.Padding = new System.Windows.Forms.Padding(0, 0, 2, 2);
            this.labelTileCoords.Size = new System.Drawing.Size(152, 18);
            this.labelTileCoords.TabIndex = 122;
            this.labelTileCoords.Text = "(0, 0)  Tile Coords";
            this.labelTileCoords.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelPixelCoords
            // 
            this.labelPixelCoords.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPixelCoords.BackColor = System.Drawing.SystemColors.Control;
            this.labelPixelCoords.Location = new System.Drawing.Point(564, 618);
            this.labelPixelCoords.Name = "labelPixelCoords";
            this.labelPixelCoords.Padding = new System.Windows.Forms.Padding(0, 0, 2, 2);
            this.labelPixelCoords.Size = new System.Drawing.Size(153, 18);
            this.labelPixelCoords.TabIndex = 122;
            this.labelPixelCoords.Text = "(0, 0)  Pixel Coords";
            this.labelPixelCoords.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panelTemplates
            // 
            this.panelTemplates.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelTemplates.BackColor = System.Drawing.SystemColors.ControlText;
            this.panelTemplates.Controls.Add(this.templatesLoaded);
            this.panelTemplates.Controls.Add(this.panel114);
            this.panelTemplates.Controls.Add(this.panel115);
            this.panelTemplates.Controls.Add(this.templateRename);
            this.panelTemplates.Controls.Add(this.labelTemplates);
            this.panelTemplates.Controls.Add(this.panelTemplatesSub);
            this.panelTemplates.Location = new System.Drawing.Point(719, -1);
            this.panelTemplates.Name = "panelTemplates";
            this.panelTemplates.Size = new System.Drawing.Size(268, 659);
            this.panelTemplates.TabIndex = 448;
            this.panelTemplates.Visible = false;
            // 
            // templatesLoaded
            // 
            this.templatesLoaded.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.templatesLoaded.FormattingEnabled = true;
            this.templatesLoaded.Location = new System.Drawing.Point(0, 42);
            this.templatesLoaded.Name = "templatesLoaded";
            this.templatesLoaded.Size = new System.Drawing.Size(268, 156);
            this.templatesLoaded.TabIndex = 501;
            this.templatesLoaded.SelectedIndexChanged += new System.EventHandler(this.templatesLoaded_SelectedIndexChanged);
            // 
            // panel114
            // 
            this.panel114.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel114.AutoScroll = true;
            this.panel114.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel114.Controls.Add(this.pictureBoxTemplate);
            this.panel114.Location = new System.Drawing.Point(0, 219);
            this.panel114.Name = "panel114";
            this.panel114.Size = new System.Drawing.Size(268, 438);
            this.panel114.TabIndex = 498;
            this.panel114.Scroll += new System.Windows.Forms.ScrollEventHandler(this.panel109_Scroll);
            // 
            // pictureBoxTemplate
            // 
            this.pictureBoxTemplate.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBoxTemplate.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxTemplate.Name = "pictureBoxTemplate";
            this.pictureBoxTemplate.Size = new System.Drawing.Size(100, 50);
            this.pictureBoxTemplate.TabIndex = 450;
            this.pictureBoxTemplate.TabStop = false;
            this.pictureBoxTemplate.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxTemplate_Paint);
            // 
            // panel115
            // 
            this.panel115.BackColor = System.Drawing.SystemColors.Window;
            this.panel115.Controls.Add(this.templateRenameText);
            this.panel115.Location = new System.Drawing.Point(0, 200);
            this.panel115.Name = "panel115";
            this.panel115.Size = new System.Drawing.Size(198, 17);
            this.panel115.TabIndex = 500;
            // 
            // templateRenameText
            // 
            this.templateRenameText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.templateRenameText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.templateRenameText.Enabled = false;
            this.templateRenameText.Location = new System.Drawing.Point(4, 2);
            this.templateRenameText.MaxLength = 128;
            this.templateRenameText.Name = "templateRenameText";
            this.templateRenameText.Size = new System.Drawing.Size(190, 14);
            this.templateRenameText.TabIndex = 4;
            // 
            // templateRename
            // 
            this.templateRename.BackColor = System.Drawing.SystemColors.Control;
            this.templateRename.Enabled = false;
            this.templateRename.FlatAppearance.BorderSize = 0;
            this.templateRename.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.templateRename.Location = new System.Drawing.Point(200, 200);
            this.templateRename.Name = "templateRename";
            this.templateRename.Size = new System.Drawing.Size(68, 17);
            this.templateRename.TabIndex = 456;
            this.templateRename.Text = "RENAME";
            this.templateRename.UseCompatibleTextRendering = true;
            this.templateRename.UseVisualStyleBackColor = false;
            this.templateRename.Click += new System.EventHandler(this.templateRename_Click);
            // 
            // labelTemplates
            // 
            this.labelTemplates.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTemplates.BackColor = System.Drawing.SystemColors.ControlDark;
            this.labelTemplates.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.labelTemplates.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTemplates.ForeColor = System.Drawing.SystemColors.Control;
            this.labelTemplates.Location = new System.Drawing.Point(0, 2);
            this.labelTemplates.Name = "labelTemplates";
            this.labelTemplates.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.labelTemplates.Size = new System.Drawing.Size(268, 17);
            this.labelTemplates.TabIndex = 498;
            this.labelTemplates.Text = "TEMPLATES";
            // 
            // panelTemplatesSub
            // 
            this.panelTemplatesSub.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panelTemplatesSub.Controls.Add(this.toolStrip3);
            this.panelTemplatesSub.Location = new System.Drawing.Point(0, 21);
            this.panelTemplatesSub.Name = "panelTemplatesSub";
            this.panelTemplatesSub.Size = new System.Drawing.Size(268, 19);
            this.panelTemplatesSub.TabIndex = 448;
            // 
            // toolStrip3
            // 
            this.toolStrip3.AutoSize = false;
            this.toolStrip3.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel4,
            this.toolStripSeparator44,
            this.templateTransfer,
            this.toolStripSeparator45,
            templateImport,
            templateExport,
            this.toolStripSeparator43,
            templateDelete,
            templateCopy,
            templatePaste});
            this.toolStrip3.Location = new System.Drawing.Point(0, 0);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip3.Size = new System.Drawing.Size(268, 21);
            this.toolStrip3.TabIndex = 0;
            this.toolStrip3.Text = "toolStrip3";
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripLabel4.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel4.Margin = new System.Windows.Forms.Padding(3, 1, 0, 2);
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(53, 18);
            this.toolStripLabel4.Text = "OPTIONS";
            // 
            // toolStripSeparator44
            // 
            this.toolStripSeparator44.Name = "toolStripSeparator44";
            this.toolStripSeparator44.Size = new System.Drawing.Size(6, 21);
            // 
            // templateTransfer
            // 
            this.templateTransfer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.templateTransfer.Image = global::LAZYSHELL.Properties.Resources.transfer_small;
            this.templateTransfer.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.templateTransfer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.templateTransfer.Name = "templateTransfer";
            this.templateTransfer.Size = new System.Drawing.Size(23, 18);
            this.templateTransfer.Text = "Create new template from selection";
            this.templateTransfer.Click += new System.EventHandler(this.templateTransfer_Click);
            // 
            // toolStripSeparator45
            // 
            this.toolStripSeparator45.Name = "toolStripSeparator45";
            this.toolStripSeparator45.Size = new System.Drawing.Size(6, 21);
            // 
            // toolStripSeparator43
            // 
            this.toolStripSeparator43.Name = "toolStripSeparator43";
            this.toolStripSeparator43.Size = new System.Drawing.Size(6, 21);
            // 
            // panelTilesets
            // 
            this.panelTilesets.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelTilesets.BackColor = System.Drawing.SystemColors.ControlText;
            this.panelTilesets.Controls.Add(this.labelTilesets);
            this.panelTilesets.Controls.Add(this.tabControl2);
            this.panelTilesets.Location = new System.Drawing.Point(719, 1);
            this.panelTilesets.Name = "panelTilesets";
            this.panelTilesets.Size = new System.Drawing.Size(270, 656);
            this.panelTilesets.TabIndex = 139;
            // 
            // labelTilesets
            // 
            this.labelTilesets.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTilesets.BackColor = System.Drawing.SystemColors.ControlDark;
            this.labelTilesets.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.labelTilesets.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTilesets.ForeColor = System.Drawing.SystemColors.Control;
            this.labelTilesets.Location = new System.Drawing.Point(0, 0);
            this.labelTilesets.Name = "labelTilesets";
            this.labelTilesets.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.labelTilesets.Size = new System.Drawing.Size(268, 17);
            this.labelTilesets.TabIndex = 162;
            this.labelTilesets.Text = "TILESETS...";
            this.labelTilesets.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.labelTilesets, "Double-click to maximize / restore");
            this.labelTilesets.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.labelTilesets_MouseDoubleClick);
            // 
            // tabControl2
            // 
            this.tabControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl2.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl2.ContextMenuStrip = this.contextMenuStrip2;
            this.tabControl2.Controls.Add(this.tabPage2);
            this.tabControl2.Controls.Add(this.tabPage5);
            this.tabControl2.Controls.Add(this.tabPage6);
            this.tabControl2.Controls.Add(this.tabPage7);
            this.tabControl2.Controls.Add(this.tabPage12);
            this.tabControl2.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl2.Location = new System.Drawing.Point(0, 19);
            this.tabControl2.Multiline = true;
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(268, 636);
            this.tabControl2.TabIndex = 159;
            this.tabControl2.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabControl2_Selecting);
            this.tabControl2.SelectedIndexChanged += new System.EventHandler(this.tabControl2_SelectedIndexChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.ControlText;
            this.tabPage2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPage2.Controls.Add(this.panel95);
            this.tabPage2.Location = new System.Drawing.Point(4, 23);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(260, 609);
            this.tabPage2.TabIndex = 0;
            this.tabPage2.Text = "L1";
            // 
            // panel95
            // 
            this.panel95.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel95.BackgroundImage = global::LAZYSHELL.Properties.Resources._bg;
            this.panel95.Controls.Add(this.panel96);
            this.panel95.Location = new System.Drawing.Point(1, 1);
            this.panel95.Name = "panel95";
            this.panel95.Size = new System.Drawing.Size(256, 605);
            this.panel95.TabIndex = 441;
            // 
            // panel96
            // 
            this.panel96.Controls.Add(this.pictureBoxTilesetL1);
            this.panel96.Location = new System.Drawing.Point(-2, 0);
            this.panel96.Name = "panel96";
            this.panel96.Size = new System.Drawing.Size(260, 514);
            this.panel96.TabIndex = 441;
            // 
            // pictureBoxTilesetL1
            // 
            this.pictureBoxTilesetL1.BackgroundImage = global::LAZYSHELL.Properties.Resources._transparent;
            this.pictureBoxTilesetL1.ContextMenuStrip = this.contextMenuStrip2;
            this.pictureBoxTilesetL1.Cursor = System.Windows.Forms.Cursors.Cross;
            this.pictureBoxTilesetL1.Location = new System.Drawing.Point(2, 0);
            this.pictureBoxTilesetL1.Name = "pictureBoxTilesetL1";
            this.pictureBoxTilesetL1.Size = new System.Drawing.Size(256, 512);
            this.pictureBoxTilesetL1.TabIndex = 1;
            this.pictureBoxTilesetL1.TabStop = false;
            this.pictureBoxTilesetL1.MouseLeave += new System.EventHandler(this.pictureBoxTilesetL1_MouseLeave);
            this.pictureBoxTilesetL1.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.pictureBoxTilesetL1_PreviewKeyDown);
            this.pictureBoxTilesetL1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxTilesetL1_MouseMove);
            this.pictureBoxTilesetL1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pictureBoxTilesetL1_MouseDoubleClick);
            this.pictureBoxTilesetL1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBoxTilesetL1_MouseClick);
            this.pictureBoxTilesetL1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxTilesetL1_MouseDown);
            this.pictureBoxTilesetL1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxTilesetL1_Paint);
            this.pictureBoxTilesetL1.MouseEnter += new System.EventHandler(this.pictureBoxTilesetL1_MouseEnter);
            // 
            // tabPage12
            // 
            this.tabPage12.BackColor = System.Drawing.SystemColors.ControlText;
            this.tabPage12.Controls.Add(this.panelBattlefields);
            this.tabPage12.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage12.Location = new System.Drawing.Point(4, 23);
            this.tabPage12.Name = "tabPage12";
            this.tabPage12.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage12.Size = new System.Drawing.Size(260, 609);
            this.tabPage12.TabIndex = 4;
            this.tabPage12.Text = "BATTLEFIELD";
            // 
            // panelBattlefields
            // 
            this.panelBattlefields.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelBattlefields.BackgroundImage = global::LAZYSHELL.Properties.Resources._bg;
            this.panelBattlefields.Controls.Add(this.panelBattlefieldTileset);
            this.panelBattlefields.Controls.Add(this.panelBattlefieldPalettes);
            this.panelBattlefields.Controls.Add(this.panelBattlefieldProperties);
            this.panelBattlefields.Controls.Add(this.panel45);
            this.panelBattlefields.Location = new System.Drawing.Point(2, 2);
            this.panelBattlefields.Name = "panelBattlefields";
            this.panelBattlefields.Size = new System.Drawing.Size(256, 605);
            this.panelBattlefields.TabIndex = 442;
            this.panelBattlefields.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelBattlefields_MouseMove);
            this.panelBattlefields.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelBattlefields_MouseUp);
            // 
            // panelBattlefieldTileset
            // 
            this.panelBattlefieldTileset.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.panelBattlefieldTileset.BackColor = System.Drawing.SystemColors.ControlText;
            this.panelBattlefieldTileset.Controls.Add(panel444);
            this.panelBattlefieldTileset.Location = new System.Drawing.Point(-2, 36);
            this.panelBattlefieldTileset.Name = "panelBattlefieldTileset";
            this.panelBattlefieldTileset.Size = new System.Drawing.Size(260, 220);
            this.panelBattlefieldTileset.TabIndex = 442;
            this.panelBattlefieldTileset.MouseLeave += new System.EventHandler(this.panelBattlefieldTileset_MouseLeave);
            this.panelBattlefieldTileset.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelBattlefieldTileset_MouseMove);
            this.panelBattlefieldTileset.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelBattlefieldTileset_MouseDown);
            // 
            // panelBattlefieldPalettes
            // 
            this.panelBattlefieldPalettes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panelBattlefieldPalettes.BackColor = System.Drawing.SystemColors.ControlText;
            this.panelBattlefieldPalettes.Controls.Add(this.panel93);
            this.panelBattlefieldPalettes.Location = new System.Drawing.Point(-2, 382);
            this.panelBattlefieldPalettes.Name = "panelBattlefieldPalettes";
            this.panelBattlefieldPalettes.Size = new System.Drawing.Size(260, 225);
            this.panelBattlefieldPalettes.TabIndex = 444;
            // 
            // panel93
            // 
            this.panel93.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.panel93.Controls.Add(this.colorBalanceBF);
            this.panel93.Controls.Add(this.labelBattlefieldPalettes);
            this.panel93.Controls.Add(this.battlefieldPaletteSetNum);
            this.panel93.Controls.Add(this.label102);
            this.panel93.Controls.Add(this.bfPaletteGreenBar);
            this.panel93.Controls.Add(this.panel60);
            this.panel93.Controls.Add(this.bfPaletteBlueBar);
            this.panel93.Controls.Add(this.bfPalettePictureBox);
            this.panel93.Controls.Add(this.bfPaletteRedBar);
            this.panel93.Controls.Add(this.bfPaletteRedNum);
            this.panel93.Controls.Add(this.label123);
            this.panel93.Controls.Add(this.label77);
            this.panel93.Controls.Add(this.bfPaletteBlueNum);
            this.panel93.Controls.Add(this.label78);
            this.panel93.Controls.Add(this.bfPaletteGreenNum);
            this.panel93.Controls.Add(this.pictureBoxColorBF);
            this.panel93.Location = new System.Drawing.Point(2, 2);
            this.panel93.Name = "panel93";
            this.panel93.Size = new System.Drawing.Size(256, 221);
            this.panel93.TabIndex = 497;
            // 
            // colorBalanceBF
            // 
            this.colorBalanceBF.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.colorBalanceBF.FlatAppearance.BorderSize = 0;
            this.colorBalanceBF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colorBalanceBF.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colorBalanceBF.Location = new System.Drawing.Point(0, 150);
            this.colorBalanceBF.Name = "colorBalanceBF";
            this.colorBalanceBF.Size = new System.Drawing.Size(256, 17);
            this.colorBalanceBF.TabIndex = 456;
            this.colorBalanceBF.Text = "COLOR MATH COMMANDS...";
            this.colorBalanceBF.UseCompatibleTextRendering = true;
            this.colorBalanceBF.UseVisualStyleBackColor = false;
            this.colorBalanceBF.Click += new System.EventHandler(this.colorBalanceBF_Click);
            // 
            // labelBattlefieldPalettes
            // 
            this.labelBattlefieldPalettes.BackColor = System.Drawing.SystemColors.Control;
            this.labelBattlefieldPalettes.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBattlefieldPalettes.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.labelBattlefieldPalettes.Location = new System.Drawing.Point(0, 0);
            this.labelBattlefieldPalettes.Name = "labelBattlefieldPalettes";
            this.labelBattlefieldPalettes.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.labelBattlefieldPalettes.Size = new System.Drawing.Size(256, 17);
            this.labelBattlefieldPalettes.TabIndex = 454;
            this.labelBattlefieldPalettes.Text = "PALETTES";
            this.labelBattlefieldPalettes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // battlefieldPaletteSetNum
            // 
            this.battlefieldPaletteSetNum.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.battlefieldPaletteSetNum.Location = new System.Drawing.Point(77, 19);
            this.battlefieldPaletteSetNum.Maximum = new decimal(new int[] {
            56,
            0,
            0,
            0});
            this.battlefieldPaletteSetNum.Name = "battlefieldPaletteSetNum";
            this.battlefieldPaletteSetNum.Size = new System.Drawing.Size(50, 17);
            this.battlefieldPaletteSetNum.TabIndex = 189;
            this.battlefieldPaletteSetNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.battlefieldPaletteSetNum.ValueChanged += new System.EventHandler(this.battlefieldPaletteSetNum_ValueChanged);
            // 
            // label102
            // 
            this.label102.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label102.Location = new System.Drawing.Point(0, 19);
            this.label102.Name = "label102";
            this.label102.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label102.Size = new System.Drawing.Size(76, 17);
            this.label102.TabIndex = 190;
            this.label102.Text = "Palette Set";
            // 
            // bfPaletteGreenBar
            // 
            this.bfPaletteGreenBar.AutoSize = false;
            this.bfPaletteGreenBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.bfPaletteGreenBar.Location = new System.Drawing.Point(119, 186);
            this.bfPaletteGreenBar.Maximum = 248;
            this.bfPaletteGreenBar.Name = "bfPaletteGreenBar";
            this.bfPaletteGreenBar.Size = new System.Drawing.Size(137, 17);
            this.bfPaletteGreenBar.SmallChange = 8;
            this.bfPaletteGreenBar.TabIndex = 445;
            this.bfPaletteGreenBar.TickFrequency = 8;
            this.bfPaletteGreenBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.bfPaletteGreenBar.Scroll += new System.EventHandler(this.bfPaletteGreenBar_Scroll);
            // 
            // panel60
            // 
            this.panel60.BackColor = System.Drawing.SystemColors.Window;
            this.panel60.Controls.Add(this.battlefieldPaletteSetName);
            this.panel60.Location = new System.Drawing.Point(128, 19);
            this.panel60.Name = "panel60";
            this.panel60.Size = new System.Drawing.Size(129, 17);
            this.panel60.TabIndex = 190;
            // 
            // battlefieldPaletteSetName
            // 
            this.battlefieldPaletteSetName.DropDownHeight = 200;
            this.battlefieldPaletteSetName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.battlefieldPaletteSetName.IntegralHeight = false;
            this.battlefieldPaletteSetName.Items.AddRange(new object[] {
            "Forest Maze",
            "Bowyer\'s Pad",
            "Beanstalks",
            "Sunken Ship Cellar",
            "Sunken Ship",
            "Underground",
            "Bowser\'s Keep",
            "Barrel Volcano",
            "Grasslands",
            "Mountains",
            "House",
            "Booster Tower",
            "Castle",
            "Kero Sewers Water",
            "____",
            "Exor",
            "Booster Tower Balcony",
            "Smithy Factory",
            "Kero Sewers",
            "____",
            "Nimbus Castle",
            "Birdo",
            "Nimbus Land",
            "___castle",
            "___forest",
            "Mushroom Kingdom",
            "Chandeliers",
            "Castle",
            "____",
            "Forest Maze Path",
            "____",
            "Plateaus",
            "Sea Enclave",
            "Marrymore Chapel",
            "Level Up",
            "Star Hill",
            "Seaside Town Beach",
            "Axem Rangers",
            "Domino & Cloaker",
            "Sea",
            "Bean Valley",
            "Land\'s End Desert",
            "Smithys\' Pad",
            "Smithy\'s Final Form",
            "Culex",
            "Jinx\'s Dojo",
            "Factory Grounds",
            "____",
            "____",
            "____",
            "____",
            "____",
            "____",
            "____",
            "____",
            "____",
            "____"});
            this.battlefieldPaletteSetName.Location = new System.Drawing.Point(-2, -2);
            this.battlefieldPaletteSetName.Name = "battlefieldPaletteSetName";
            this.battlefieldPaletteSetName.Size = new System.Drawing.Size(133, 21);
            this.battlefieldPaletteSetName.TabIndex = 158;
            this.battlefieldPaletteSetName.SelectedIndexChanged += new System.EventHandler(this.battlefieldPaletteSetName_SelectedIndexChanged);
            // 
            // bfPaletteBlueBar
            // 
            this.bfPaletteBlueBar.AutoSize = false;
            this.bfPaletteBlueBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.bfPaletteBlueBar.Location = new System.Drawing.Point(119, 204);
            this.bfPaletteBlueBar.Maximum = 248;
            this.bfPaletteBlueBar.Name = "bfPaletteBlueBar";
            this.bfPaletteBlueBar.Size = new System.Drawing.Size(137, 17);
            this.bfPaletteBlueBar.SmallChange = 8;
            this.bfPaletteBlueBar.TabIndex = 447;
            this.bfPaletteBlueBar.TickFrequency = 8;
            this.bfPaletteBlueBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.bfPaletteBlueBar.Scroll += new System.EventHandler(this.bfPaletteBlueBar_Scroll);
            // 
            // bfPalettePictureBox
            // 
            this.bfPalettePictureBox.BackColor = System.Drawing.SystemColors.Control;
            this.bfPalettePictureBox.ContextMenuStrip = this.contextMenuStrip3;
            this.bfPalettePictureBox.Location = new System.Drawing.Point(0, 37);
            this.bfPalettePictureBox.Name = "bfPalettePictureBox";
            this.bfPalettePictureBox.Size = new System.Drawing.Size(256, 112);
            this.bfPalettePictureBox.TabIndex = 448;
            this.bfPalettePictureBox.TabStop = false;
            this.bfPalettePictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.bfPalettePictureBox_MouseClick);
            this.bfPalettePictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.bfPalettePictureBox_Paint);
            // 
            // bfPaletteRedBar
            // 
            this.bfPaletteRedBar.AutoSize = false;
            this.bfPaletteRedBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.bfPaletteRedBar.Location = new System.Drawing.Point(119, 168);
            this.bfPaletteRedBar.Maximum = 248;
            this.bfPaletteRedBar.Name = "bfPaletteRedBar";
            this.bfPaletteRedBar.Size = new System.Drawing.Size(137, 17);
            this.bfPaletteRedBar.SmallChange = 8;
            this.bfPaletteRedBar.TabIndex = 443;
            this.bfPaletteRedBar.TickFrequency = 8;
            this.bfPaletteRedBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.bfPaletteRedBar.Scroll += new System.EventHandler(this.bfPaletteRedBar_Scroll);
            // 
            // bfPaletteRedNum
            // 
            this.bfPaletteRedNum.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.bfPaletteRedNum.Increment = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.bfPaletteRedNum.Location = new System.Drawing.Point(72, 168);
            this.bfPaletteRedNum.Maximum = new decimal(new int[] {
            248,
            0,
            0,
            0});
            this.bfPaletteRedNum.Name = "bfPaletteRedNum";
            this.bfPaletteRedNum.Size = new System.Drawing.Size(46, 17);
            this.bfPaletteRedNum.TabIndex = 442;
            this.bfPaletteRedNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.bfPaletteRedNum.ValueChanged += new System.EventHandler(this.bfPaletteRedNum_ValueChanged);
            // 
            // label123
            // 
            this.label123.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label123.Location = new System.Drawing.Point(54, 168);
            this.label123.Name = "label123";
            this.label123.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label123.Size = new System.Drawing.Size(17, 17);
            this.label123.TabIndex = 450;
            this.label123.Text = "R";
            this.label123.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label77
            // 
            this.label77.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label77.Location = new System.Drawing.Point(54, 204);
            this.label77.Name = "label77";
            this.label77.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label77.Size = new System.Drawing.Size(17, 17);
            this.label77.TabIndex = 452;
            this.label77.Text = "B";
            this.label77.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // bfPaletteBlueNum
            // 
            this.bfPaletteBlueNum.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.bfPaletteBlueNum.Increment = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.bfPaletteBlueNum.Location = new System.Drawing.Point(72, 204);
            this.bfPaletteBlueNum.Maximum = new decimal(new int[] {
            248,
            0,
            0,
            0});
            this.bfPaletteBlueNum.Name = "bfPaletteBlueNum";
            this.bfPaletteBlueNum.Size = new System.Drawing.Size(46, 17);
            this.bfPaletteBlueNum.TabIndex = 446;
            this.bfPaletteBlueNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.bfPaletteBlueNum.ValueChanged += new System.EventHandler(this.bfPaletteBlueNum_ValueChanged);
            // 
            // label78
            // 
            this.label78.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label78.Location = new System.Drawing.Point(54, 186);
            this.label78.Name = "label78";
            this.label78.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label78.Size = new System.Drawing.Size(17, 17);
            this.label78.TabIndex = 451;
            this.label78.Text = "G";
            this.label78.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // bfPaletteGreenNum
            // 
            this.bfPaletteGreenNum.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.bfPaletteGreenNum.Increment = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.bfPaletteGreenNum.Location = new System.Drawing.Point(72, 186);
            this.bfPaletteGreenNum.Maximum = new decimal(new int[] {
            248,
            0,
            0,
            0});
            this.bfPaletteGreenNum.Name = "bfPaletteGreenNum";
            this.bfPaletteGreenNum.Size = new System.Drawing.Size(46, 17);
            this.bfPaletteGreenNum.TabIndex = 444;
            this.bfPaletteGreenNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.bfPaletteGreenNum.ValueChanged += new System.EventHandler(this.bfPaletteGreenNum_ValueChanged);
            // 
            // pictureBoxColorBF
            // 
            this.pictureBoxColorBF.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBoxColorBF.Location = new System.Drawing.Point(0, 168);
            this.pictureBoxColorBF.Name = "pictureBoxColorBF";
            this.pictureBoxColorBF.Size = new System.Drawing.Size(53, 53);
            this.pictureBoxColorBF.TabIndex = 455;
            this.pictureBoxColorBF.TabStop = false;
            // 
            // panelBattlefieldProperties
            // 
            this.panelBattlefieldProperties.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panelBattlefieldProperties.BackColor = System.Drawing.SystemColors.ControlText;
            this.panelBattlefieldProperties.Controls.Add(this.panel92);
            this.panelBattlefieldProperties.Location = new System.Drawing.Point(-2, 254);
            this.panelBattlefieldProperties.Name = "panelBattlefieldProperties";
            this.panelBattlefieldProperties.Size = new System.Drawing.Size(260, 130);
            this.panelBattlefieldProperties.TabIndex = 443;
            // 
            // panel92
            // 
            this.panel92.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.panel92.Controls.Add(this.labelBattlefieldProperties);
            this.panel92.Controls.Add(this.label97);
            this.panel92.Controls.Add(this.battlefieldGFXSet4Num);
            this.panel92.Controls.Add(this.battlefieldGFXSet5Num);
            this.panel92.Controls.Add(this.label98);
            this.panel92.Controls.Add(this.battlefieldGFXSet3Num);
            this.panel92.Controls.Add(this.panel57);
            this.panel92.Controls.Add(this.label99);
            this.panel92.Controls.Add(this.panel56);
            this.panel92.Controls.Add(this.battlefieldGFXSet2Num);
            this.panel92.Controls.Add(this.panel7);
            this.panel92.Controls.Add(this.label100);
            this.panel92.Controls.Add(this.panel5);
            this.panel92.Controls.Add(this.battlefieldGFXSet1Num);
            this.panel92.Controls.Add(this.panel2);
            this.panel92.Controls.Add(this.label69);
            this.panel92.Controls.Add(this.battlefieldTilesetNum);
            this.panel92.Controls.Add(this.label101);
            this.panel92.Controls.Add(this.panel59);
            this.panel92.Location = new System.Drawing.Point(2, 2);
            this.panel92.Name = "panel92";
            this.panel92.Size = new System.Drawing.Size(256, 126);
            this.panel92.TabIndex = 496;
            // 
            // labelBattlefieldProperties
            // 
            this.labelBattlefieldProperties.BackColor = System.Drawing.SystemColors.Control;
            this.labelBattlefieldProperties.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBattlefieldProperties.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.labelBattlefieldProperties.Location = new System.Drawing.Point(0, 0);
            this.labelBattlefieldProperties.Name = "labelBattlefieldProperties";
            this.labelBattlefieldProperties.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.labelBattlefieldProperties.Size = new System.Drawing.Size(256, 17);
            this.labelBattlefieldProperties.TabIndex = 456;
            this.labelBattlefieldProperties.Text = "BATTLEFIELD PROPERTIES";
            this.labelBattlefieldProperties.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label97
            // 
            this.label97.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label97.Location = new System.Drawing.Point(0, 37);
            this.label97.Name = "label97";
            this.label97.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label97.Size = new System.Drawing.Size(76, 17);
            this.label97.TabIndex = 171;
            this.label97.Text = "GFX Set 2";
            // 
            // battlefieldGFXSet4Num
            // 
            this.battlefieldGFXSet4Num.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.battlefieldGFXSet4Num.Location = new System.Drawing.Point(77, 73);
            this.battlefieldGFXSet4Num.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.battlefieldGFXSet4Num.Name = "battlefieldGFXSet4Num";
            this.battlefieldGFXSet4Num.Size = new System.Drawing.Size(50, 17);
            this.battlefieldGFXSet4Num.TabIndex = 183;
            this.battlefieldGFXSet4Num.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.battlefieldGFXSet4Num.ValueChanged += new System.EventHandler(this.battlefieldGFXSet4Num_ValueChanged);
            // 
            // battlefieldGFXSet5Num
            // 
            this.battlefieldGFXSet5Num.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.battlefieldGFXSet5Num.Location = new System.Drawing.Point(77, 91);
            this.battlefieldGFXSet5Num.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.battlefieldGFXSet5Num.Name = "battlefieldGFXSet5Num";
            this.battlefieldGFXSet5Num.Size = new System.Drawing.Size(50, 17);
            this.battlefieldGFXSet5Num.TabIndex = 185;
            this.battlefieldGFXSet5Num.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.battlefieldGFXSet5Num.ValueChanged += new System.EventHandler(this.battlefieldGFXSet5Num_ValueChanged);
            // 
            // label98
            // 
            this.label98.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label98.Location = new System.Drawing.Point(0, 55);
            this.label98.Name = "label98";
            this.label98.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label98.Size = new System.Drawing.Size(76, 17);
            this.label98.TabIndex = 172;
            this.label98.Text = "GFX Set 3";
            // 
            // battlefieldGFXSet3Num
            // 
            this.battlefieldGFXSet3Num.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.battlefieldGFXSet3Num.Location = new System.Drawing.Point(77, 55);
            this.battlefieldGFXSet3Num.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.battlefieldGFXSet3Num.Name = "battlefieldGFXSet3Num";
            this.battlefieldGFXSet3Num.Size = new System.Drawing.Size(50, 17);
            this.battlefieldGFXSet3Num.TabIndex = 181;
            this.battlefieldGFXSet3Num.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.battlefieldGFXSet3Num.ValueChanged += new System.EventHandler(this.battlefieldGFXSet3Num_ValueChanged);
            // 
            // panel57
            // 
            this.panel57.BackColor = System.Drawing.SystemColors.Window;
            this.panel57.Controls.Add(this.battlefieldGFXSet1Name);
            this.panel57.Location = new System.Drawing.Point(128, 19);
            this.panel57.Name = "panel57";
            this.panel57.Size = new System.Drawing.Size(129, 17);
            this.panel57.TabIndex = 178;
            // 
            // battlefieldGFXSet1Name
            // 
            this.battlefieldGFXSet1Name.DropDownHeight = 200;
            this.battlefieldGFXSet1Name.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.battlefieldGFXSet1Name.IntegralHeight = false;
            this.battlefieldGFXSet1Name.Location = new System.Drawing.Point(-2, -2);
            this.battlefieldGFXSet1Name.Name = "battlefieldGFXSet1Name";
            this.battlefieldGFXSet1Name.Size = new System.Drawing.Size(133, 21);
            this.battlefieldGFXSet1Name.TabIndex = 118;
            this.battlefieldGFXSet1Name.SelectedIndexChanged += new System.EventHandler(this.battlefieldGFXSet1Name_SelectedIndexChanged);
            // 
            // label99
            // 
            this.label99.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label99.Location = new System.Drawing.Point(0, 73);
            this.label99.Name = "label99";
            this.label99.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label99.Size = new System.Drawing.Size(76, 17);
            this.label99.TabIndex = 173;
            this.label99.Text = "GFX Set 4";
            // 
            // panel56
            // 
            this.panel56.BackColor = System.Drawing.SystemColors.Window;
            this.panel56.Controls.Add(this.battlefieldGFXSet3Name);
            this.panel56.Location = new System.Drawing.Point(128, 55);
            this.panel56.Name = "panel56";
            this.panel56.Size = new System.Drawing.Size(129, 17);
            this.panel56.TabIndex = 182;
            // 
            // battlefieldGFXSet3Name
            // 
            this.battlefieldGFXSet3Name.DropDownHeight = 200;
            this.battlefieldGFXSet3Name.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.battlefieldGFXSet3Name.IntegralHeight = false;
            this.battlefieldGFXSet3Name.Location = new System.Drawing.Point(-2, -2);
            this.battlefieldGFXSet3Name.Name = "battlefieldGFXSet3Name";
            this.battlefieldGFXSet3Name.Size = new System.Drawing.Size(133, 21);
            this.battlefieldGFXSet3Name.TabIndex = 120;
            this.battlefieldGFXSet3Name.SelectedIndexChanged += new System.EventHandler(this.battlefieldGFXSet3Name_SelectedIndexChanged);
            // 
            // battlefieldGFXSet2Num
            // 
            this.battlefieldGFXSet2Num.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.battlefieldGFXSet2Num.Location = new System.Drawing.Point(77, 37);
            this.battlefieldGFXSet2Num.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.battlefieldGFXSet2Num.Name = "battlefieldGFXSet2Num";
            this.battlefieldGFXSet2Num.Size = new System.Drawing.Size(50, 17);
            this.battlefieldGFXSet2Num.TabIndex = 179;
            this.battlefieldGFXSet2Num.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.battlefieldGFXSet2Num.ValueChanged += new System.EventHandler(this.battlefieldGFXSet2Num_ValueChanged);
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.SystemColors.Window;
            this.panel7.Controls.Add(this.battlefieldGFXSet5Name);
            this.panel7.Location = new System.Drawing.Point(128, 91);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(129, 17);
            this.panel7.TabIndex = 186;
            // 
            // battlefieldGFXSet5Name
            // 
            this.battlefieldGFXSet5Name.DropDownHeight = 200;
            this.battlefieldGFXSet5Name.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.battlefieldGFXSet5Name.IntegralHeight = false;
            this.battlefieldGFXSet5Name.Location = new System.Drawing.Point(-2, -2);
            this.battlefieldGFXSet5Name.Name = "battlefieldGFXSet5Name";
            this.battlefieldGFXSet5Name.Size = new System.Drawing.Size(133, 21);
            this.battlefieldGFXSet5Name.TabIndex = 122;
            this.battlefieldGFXSet5Name.SelectedIndexChanged += new System.EventHandler(this.battlefieldGFXSet5Name_SelectedIndexChanged);
            // 
            // label100
            // 
            this.label100.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label100.Location = new System.Drawing.Point(0, 91);
            this.label100.Name = "label100";
            this.label100.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label100.Size = new System.Drawing.Size(76, 17);
            this.label100.TabIndex = 174;
            this.label100.Text = "GFX Set 5";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.Window;
            this.panel5.Controls.Add(this.battlefieldGFXSet2Name);
            this.panel5.Location = new System.Drawing.Point(128, 37);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(129, 17);
            this.panel5.TabIndex = 180;
            // 
            // battlefieldGFXSet2Name
            // 
            this.battlefieldGFXSet2Name.DropDownHeight = 200;
            this.battlefieldGFXSet2Name.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.battlefieldGFXSet2Name.IntegralHeight = false;
            this.battlefieldGFXSet2Name.Location = new System.Drawing.Point(-2, -2);
            this.battlefieldGFXSet2Name.Name = "battlefieldGFXSet2Name";
            this.battlefieldGFXSet2Name.Size = new System.Drawing.Size(133, 21);
            this.battlefieldGFXSet2Name.TabIndex = 119;
            this.battlefieldGFXSet2Name.SelectedIndexChanged += new System.EventHandler(this.battlefieldGFXSet2Name_SelectedIndexChanged);
            // 
            // battlefieldGFXSet1Num
            // 
            this.battlefieldGFXSet1Num.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.battlefieldGFXSet1Num.Location = new System.Drawing.Point(77, 19);
            this.battlefieldGFXSet1Num.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.battlefieldGFXSet1Num.Name = "battlefieldGFXSet1Num";
            this.battlefieldGFXSet1Num.Size = new System.Drawing.Size(50, 17);
            this.battlefieldGFXSet1Num.TabIndex = 177;
            this.battlefieldGFXSet1Num.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.battlefieldGFXSet1Num.ValueChanged += new System.EventHandler(this.battlefieldGFXSet1Num_ValueChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Window;
            this.panel2.Controls.Add(this.battlefieldGFXSet4Name);
            this.panel2.Location = new System.Drawing.Point(128, 73);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(129, 17);
            this.panel2.TabIndex = 184;
            // 
            // battlefieldGFXSet4Name
            // 
            this.battlefieldGFXSet4Name.DropDownHeight = 200;
            this.battlefieldGFXSet4Name.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.battlefieldGFXSet4Name.IntegralHeight = false;
            this.battlefieldGFXSet4Name.Location = new System.Drawing.Point(-2, -2);
            this.battlefieldGFXSet4Name.Name = "battlefieldGFXSet4Name";
            this.battlefieldGFXSet4Name.Size = new System.Drawing.Size(133, 21);
            this.battlefieldGFXSet4Name.TabIndex = 121;
            this.battlefieldGFXSet4Name.SelectedIndexChanged += new System.EventHandler(this.battlefieldGFXSet4Name_SelectedIndexChanged);
            // 
            // label69
            // 
            this.label69.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label69.Location = new System.Drawing.Point(0, 19);
            this.label69.Name = "label69";
            this.label69.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label69.Size = new System.Drawing.Size(76, 17);
            this.label69.TabIndex = 170;
            this.label69.Text = "GFX Set 1";
            // 
            // battlefieldTilesetNum
            // 
            this.battlefieldTilesetNum.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.battlefieldTilesetNum.Location = new System.Drawing.Point(77, 109);
            this.battlefieldTilesetNum.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.battlefieldTilesetNum.Name = "battlefieldTilesetNum";
            this.battlefieldTilesetNum.Size = new System.Drawing.Size(50, 17);
            this.battlefieldTilesetNum.TabIndex = 187;
            this.battlefieldTilesetNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.battlefieldTilesetNum.ValueChanged += new System.EventHandler(this.battlefieldTilesetNum_ValueChanged);
            // 
            // label101
            // 
            this.label101.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label101.Location = new System.Drawing.Point(0, 109);
            this.label101.Name = "label101";
            this.label101.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label101.Size = new System.Drawing.Size(76, 17);
            this.label101.TabIndex = 185;
            this.label101.Text = "Tileset";
            // 
            // panel59
            // 
            this.panel59.BackColor = System.Drawing.SystemColors.Window;
            this.panel59.Controls.Add(this.battlefieldTilesetName);
            this.panel59.Location = new System.Drawing.Point(128, 109);
            this.panel59.Name = "panel59";
            this.panel59.Size = new System.Drawing.Size(129, 17);
            this.panel59.TabIndex = 188;
            // 
            // battlefieldTilesetName
            // 
            this.battlefieldTilesetName.DropDownHeight = 200;
            this.battlefieldTilesetName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.battlefieldTilesetName.IntegralHeight = false;
            this.battlefieldTilesetName.Items.AddRange(new object[] {
            "Forest Maze",
            "Bowyer\'s Pad",
            "Beanstalks",
            "Sunken Ship Cellar",
            "Sunken Ship",
            "Moleville Mines",
            "___mines",
            "Bowser\'s Keep",
            "Czar Dragon\'s Pad",
            "Grasslands",
            "Mountains",
            "House",
            "Booster Tower",
            "Castle",
            "Kero Sewers Water",
            "____",
            "Exor",
            "Booster Tower Balcony",
            "Count Down",
            "Smithy Factory",
            "Barrel Volcano",
            "Kero Sewers",
            "____",
            "____",
            "____",
            "____",
            "____",
            "____",
            "Nimbus Castle",
            "Birdo",
            "Nimbus Land",
            "Underground",
            "___castle",
            "___forest",
            "Mushroom Kingdom",
            "Chandeliers",
            "____",
            "____",
            "Forest Maze Path",
            "Level Up foreground",
            "Level Up background",
            "Plateaus",
            "Sea Enclave",
            "Marrymore Chapel",
            "Star Hill",
            "Seaside Town Beach",
            "Axem Rangers",
            "Domino & Cloaker",
            "Belome Temple",
            "Land\'s End Desert",
            "____",
            "Smithys\' Pad",
            "Smithy\'s Final Form",
            "Culex",
            "Jinx\'s Dojo",
            "_____",
            "_____",
            "_____",
            "_____",
            "Factory Grounds",
            "Bean Valley: Pipe Room"});
            this.battlefieldTilesetName.Location = new System.Drawing.Point(-2, -2);
            this.battlefieldTilesetName.Name = "battlefieldTilesetName";
            this.battlefieldTilesetName.Size = new System.Drawing.Size(133, 21);
            this.battlefieldTilesetName.TabIndex = 129;
            this.battlefieldTilesetName.SelectedIndexChanged += new System.EventHandler(this.battlefieldTilesetName_SelectedIndexChanged);
            // 
            // panel45
            // 
            this.panel45.BackColor = System.Drawing.SystemColors.ControlText;
            this.panel45.Controls.Add(this.labelBattlefields);
            this.panel45.Controls.Add(this.panel61);
            this.panel45.Controls.Add(this.battlefieldNum);
            this.panel45.Location = new System.Drawing.Point(-2, -2);
            this.panel45.Name = "panel45";
            this.panel45.Size = new System.Drawing.Size(260, 40);
            this.panel45.TabIndex = 443;
            // 
            // labelBattlefields
            // 
            this.labelBattlefields.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.labelBattlefields.BackColor = System.Drawing.SystemColors.ControlDark;
            this.labelBattlefields.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBattlefields.ForeColor = System.Drawing.SystemColors.Control;
            this.labelBattlefields.Location = new System.Drawing.Point(2, 2);
            this.labelBattlefields.Name = "labelBattlefields";
            this.labelBattlefields.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.labelBattlefields.Size = new System.Drawing.Size(128, 17);
            this.labelBattlefields.TabIndex = 192;
            this.labelBattlefields.Text = "BATTLEFIELD #";
            // 
            // panel61
            // 
            this.panel61.BackColor = System.Drawing.SystemColors.Window;
            this.panel61.Controls.Add(this.battlefieldName);
            this.panel61.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel61.Location = new System.Drawing.Point(2, 21);
            this.panel61.Name = "panel61";
            this.panel61.Size = new System.Drawing.Size(256, 17);
            this.panel61.TabIndex = 175;
            // 
            // battlefieldName
            // 
            this.battlefieldName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.battlefieldName.BackColor = System.Drawing.SystemColors.ControlDark;
            this.battlefieldName.DropDownHeight = 561;
            this.battlefieldName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.battlefieldName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.battlefieldName.ForeColor = System.Drawing.SystemColors.Control;
            this.battlefieldName.IntegralHeight = false;
            this.battlefieldName.Items.AddRange(new object[] {
            "Forest Maze",
            "Forest Maze: Bowyer\'s Pad",
            "Bean Valley: Beanstalks",
            "Sunken Ship: King Calamari\'s Cellar",
            "Sunken Ship",
            "Moleville Mines",
            "___mines",
            "Bowser\'s Keep",
            "Barrel Volcano: Czar Dragon\'s Pad",
            "Grasslands",
            "Mountains",
            "Mushroom Kingdom House",
            "Booster Tower",
            "Mushroom Kingdom Castle",
            "Kero Sewers: Underwater",
            "Mushroom Kingdom Castle",
            "Bowser\'s Keep Turret: Exor",
            "Booster Tower: Balcony",
            "Smithy Factory: Count Down\'s Pad",
            "Smithy Factory",
            "Barrel Volcano",
            "Kero Sewers",
            "Nimbus Castle",
            "Nimbus Castle: Birdo\'s Room",
            "Nimbus Land",
            "Underground",
            "___uses Mushroom Kingdom tiles",
            "___forested area with unique trees",
            "Mushroom Kingdom",
            "Bowser\'s Keep: Chandeliers",
            "Forest Maze: Path to Bowyer",
            "Level Up foreground",
            "Level Up background",
            "Plateaus",
            "___sea enclave",
            "Marrymore Chapel Sanctuary",
            "Star Hill",
            "Seaside Town Beach",
            "Sea",
            "Blade: Axem Rangers",
            "Smithy Factory: Domino & Cloaker\'s Pad",
            "Bean Valley: Grasslands",
            "Belome Temple",
            "Land\'s End Desert",
            "Factory Grounds: Smithy\'s Pad",
            "Smithy\'s Final Form",
            "Jinx\'s Dojo",
            "Culex",
            "Factory Grounds",
            "Bean Valley: Pipe Room",
            "_____",
            "_____",
            "_____",
            "_____",
            "_____",
            "_____",
            "_____",
            "_____",
            "_____",
            "_____",
            "_____",
            "_____",
            "_____",
            "_____"});
            this.battlefieldName.Location = new System.Drawing.Point(-2, -2);
            this.battlefieldName.Name = "battlefieldName";
            this.battlefieldName.Size = new System.Drawing.Size(261, 21);
            this.battlefieldName.TabIndex = 116;
            this.battlefieldName.SelectedIndexChanged += new System.EventHandler(this.battlefieldName_SelectedIndexChanged);
            // 
            // battlefieldNum
            // 
            this.battlefieldNum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.battlefieldNum.BackColor = System.Drawing.SystemColors.ControlDark;
            this.battlefieldNum.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.battlefieldNum.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.battlefieldNum.ForeColor = System.Drawing.SystemColors.Control;
            this.battlefieldNum.Location = new System.Drawing.Point(131, 2);
            this.battlefieldNum.Maximum = new decimal(new int[] {
            63,
            0,
            0,
            0});
            this.battlefieldNum.Name = "battlefieldNum";
            this.battlefieldNum.Size = new System.Drawing.Size(128, 17);
            this.battlefieldNum.TabIndex = 174;
            this.battlefieldNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.battlefieldNum.ValueChanged += new System.EventHandler(this.battlefieldNum_ValueChanged);
            // 
            // panelLevelZoom
            // 
            this.panelLevelZoom.BackColor = System.Drawing.SystemColors.ControlText;
            this.panelLevelZoom.Controls.Add(this.panel117);
            this.panelLevelZoom.Location = new System.Drawing.Point(267, 4);
            this.panelLevelZoom.Name = "panelLevelZoom";
            this.panelLevelZoom.Size = new System.Drawing.Size(132, 132);
            this.panelLevelZoom.TabIndex = 503;
            this.panelLevelZoom.Visible = false;
            // 
            // panel117
            // 
            this.panel117.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel117.Controls.Add(this.pictureBoxLevelZoom);
            this.panel117.Location = new System.Drawing.Point(1, 1);
            this.panel117.Name = "panel117";
            this.panel117.Size = new System.Drawing.Size(130, 130);
            this.panel117.TabIndex = 503;
            // 
            // pictureBoxLevelZoom
            // 
            this.pictureBoxLevelZoom.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBoxLevelZoom.Location = new System.Drawing.Point(1, 1);
            this.pictureBoxLevelZoom.Name = "pictureBoxLevelZoom";
            this.pictureBoxLevelZoom.Size = new System.Drawing.Size(128, 128);
            this.pictureBoxLevelZoom.TabIndex = 450;
            this.pictureBoxLevelZoom.TabStop = false;
            this.pictureBoxLevelZoom.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxLevelZoom_Paint);
            // 
            // contextMenuStripTE
            // 
            this.contextMenuStripTE.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setSubtileToolStripMenuItem,
            this.toolStripSeparator35,
            this.toolStripMenuItem7,
            this.exportToolStripMenuItem,
            this.saveImageToolStripMenuItem1,
            this.toolStripSeparator36,
            this.clearToolStripMenuItem1,
            this.applyBorderToolStripMenuItem});
            this.contextMenuStripTE.Name = "contextMenuStrip1";
            this.contextMenuStripTE.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.contextMenuStripTE.ShowImageMargin = false;
            this.contextMenuStripTE.Size = new System.Drawing.Size(117, 148);
            // 
            // setSubtileToolStripMenuItem
            // 
            this.setSubtileToolStripMenuItem.Name = "setSubtileToolStripMenuItem";
            this.setSubtileToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.setSubtileToolStripMenuItem.Text = "Set Subtile";
            this.setSubtileToolStripMenuItem.Click += new System.EventHandler(this.setSubtileToolStripMenuItem_Click);
            // 
            // toolStripSeparator35
            // 
            this.toolStripSeparator35.Name = "toolStripSeparator35";
            this.toolStripSeparator35.Size = new System.Drawing.Size(113, 6);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(116, 22);
            this.toolStripMenuItem7.Text = "Import...";
            this.toolStripMenuItem7.Click += new System.EventHandler(this.toolStripMenuItem7_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.exportToolStripMenuItem.Text = "Export...";
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
            // 
            // saveImageToolStripMenuItem1
            // 
            this.saveImageToolStripMenuItem1.Name = "saveImageToolStripMenuItem1";
            this.saveImageToolStripMenuItem1.Size = new System.Drawing.Size(116, 22);
            this.saveImageToolStripMenuItem1.Text = "Save image...";
            this.saveImageToolStripMenuItem1.Click += new System.EventHandler(this.saveImageToolStripMenuItem1_Click);
            // 
            // toolStripSeparator36
            // 
            this.toolStripSeparator36.Name = "toolStripSeparator36";
            this.toolStripSeparator36.Size = new System.Drawing.Size(113, 6);
            // 
            // clearToolStripMenuItem1
            // 
            this.clearToolStripMenuItem1.Name = "clearToolStripMenuItem1";
            this.clearToolStripMenuItem1.Size = new System.Drawing.Size(116, 22);
            this.clearToolStripMenuItem1.Text = "Clear";
            this.clearToolStripMenuItem1.Click += new System.EventHandler(this.clearToolStripMenuItem1_Click);
            // 
            // applyBorderToolStripMenuItem
            // 
            this.applyBorderToolStripMenuItem.Enabled = false;
            this.applyBorderToolStripMenuItem.Name = "applyBorderToolStripMenuItem";
            this.applyBorderToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.applyBorderToolStripMenuItem.Text = "Apply border";
            this.applyBorderToolStripMenuItem.Click += new System.EventHandler(this.applyBorderToolStripMenuItem_Click);
            // 
            // panelTileEditor
            // 
            this.panelTileEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelTileEditor.BackColor = System.Drawing.SystemColors.ControlText;
            this.panelTileEditor.Controls.Add(this.labelTileEditor);
            this.panelTileEditor.Controls.Add(this.panel106);
            this.panelTileEditor.Location = new System.Drawing.Point(478, 98);
            this.panelTileEditor.Name = "panelTileEditor";
            this.panelTileEditor.Size = new System.Drawing.Size(260, 426);
            this.panelTileEditor.TabIndex = 447;
            this.panelTileEditor.Visible = false;
            this.panelTileEditor.MouseLeave += new System.EventHandler(this.panelTileEditor_MouseLeave);
            this.panelTileEditor.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelTileEditor_MouseMove);
            this.panelTileEditor.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTileEditor_MouseDown);
            this.panelTileEditor.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelTileEditor_MouseUp);
            // 
            // labelTileEditor
            // 
            this.labelTileEditor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTileEditor.BackColor = System.Drawing.SystemColors.ControlDark;
            this.labelTileEditor.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.labelTileEditor.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTileEditor.ForeColor = System.Drawing.SystemColors.Control;
            this.labelTileEditor.Location = new System.Drawing.Point(2, 2);
            this.labelTileEditor.Name = "labelTileEditor";
            this.labelTileEditor.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.labelTileEditor.Size = new System.Drawing.Size(256, 17);
            this.labelTileEditor.TabIndex = 497;
            this.labelTileEditor.Text = "TILE EDITOR";
            this.labelTileEditor.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.labelTileEditor_MouseDoubleClick);
            this.labelTileEditor.MouseDown += new System.Windows.Forms.MouseEventHandler(this.labelTileEditor_MouseDown);
            this.labelTileEditor.MouseUp += new System.Windows.Forms.MouseEventHandler(this.labelTileEditor_MouseUp);
            // 
            // panel106
            // 
            this.panel106.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel106.BackgroundImage = global::LAZYSHELL.Properties.Resources._bg;
            this.panel106.Controls.Add(this.panel107);
            this.panel106.Controls.Add(this.panelImageGraphics);
            this.panel106.Controls.Add(this.panel110);
            this.panel106.Controls.Add(this.panel111);
            this.panel106.Location = new System.Drawing.Point(2, 21);
            this.panel106.Name = "panel106";
            this.panel106.Size = new System.Drawing.Size(256, 403);
            this.panel106.TabIndex = 498;
            // 
            // panel107
            // 
            this.panel107.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel107.Controls.Add(this.buttonOK);
            this.panel107.Controls.Add(this.buttonCancel);
            this.panel107.Location = new System.Drawing.Point(-2, 384);
            this.panel107.Name = "panel107";
            this.panel107.Size = new System.Drawing.Size(260, 21);
            this.panel107.TabIndex = 499;
            // 
            // buttonOK
            // 
            this.buttonOK.BackColor = System.Drawing.SystemColors.Window;
            this.buttonOK.FlatAppearance.BorderSize = 0;
            this.buttonOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonOK.Location = new System.Drawing.Point(2, 2);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(127, 17);
            this.buttonOK.TabIndex = 5;
            this.buttonOK.Text = "APPLY";
            this.buttonOK.UseCompatibleTextRendering = true;
            this.buttonOK.UseVisualStyleBackColor = false;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.BackColor = System.Drawing.SystemColors.Window;
            this.buttonCancel.FlatAppearance.BorderSize = 0;
            this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancel.Location = new System.Drawing.Point(130, 2);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(128, 17);
            this.buttonCancel.TabIndex = 6;
            this.buttonCancel.Text = "CANCEL";
            this.buttonCancel.UseCompatibleTextRendering = true;
            this.buttonCancel.UseVisualStyleBackColor = false;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // panelImageGraphics
            // 
            this.panelImageGraphics.Controls.Add(this.panel108);
            this.panelImageGraphics.Controls.Add(this.panel109);
            this.panelImageGraphics.Controls.Add(this.labelImageGraphics);
            this.panelImageGraphics.Location = new System.Drawing.Point(-2, 90);
            this.panelImageGraphics.Name = "panelImageGraphics";
            this.panelImageGraphics.Size = new System.Drawing.Size(260, 296);
            this.panelImageGraphics.TabIndex = 498;
            this.panelImageGraphics.MouseLeave += new System.EventHandler(this.panelImageGraphics_MouseLeave);
            this.panelImageGraphics.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelImageGraphics_MouseMove);
            this.panelImageGraphics.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelImageGraphics_MouseDown);
            // 
            // panel108
            // 
            this.panel108.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel108.BackColor = System.Drawing.SystemColors.Control;
            this.panel108.Controls.Add(this.toolStrip2);
            this.panel108.Location = new System.Drawing.Point(2, 20);
            this.panel108.Name = "panel108";
            this.panel108.Size = new System.Drawing.Size(256, 18);
            this.panel108.TabIndex = 499;
            // 
            // toolStrip2
            // 
            this.toolStrip2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.toolStrip2.AutoSize = false;
            this.toolStrip2.CanOverflow = false;
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel3,
            this.toolStripSeparator31,
            this.graphicShowGrid,
            this.graphicShowPixelGrid,
            this.toolStripSeparator33,
            this.subtileDraw,
            this.subtileErase,
            this.subtileDropper,
            this.toolStripSeparator34,
            this.graphicZoomIn,
            this.graphicZoomOut});
            this.toolStrip2.Location = new System.Drawing.Point(0, -1);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Padding = new System.Windows.Forms.Padding(0);
            this.toolStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip2.Size = new System.Drawing.Size(256, 20);
            this.toolStrip2.TabIndex = 51;
            this.toolStrip2.TabStop = true;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.toolStripLabel3.Margin = new System.Windows.Forms.Padding(4, 1, 0, 2);
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(33, 17);
            this.toolStripLabel3.Text = "EDIT";
            // 
            // toolStripSeparator31
            // 
            this.toolStripSeparator31.Margin = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStripSeparator31.Name = "toolStripSeparator31";
            this.toolStripSeparator31.Size = new System.Drawing.Size(6, 20);
            // 
            // graphicShowGrid
            // 
            this.graphicShowGrid.CheckOnClick = true;
            this.graphicShowGrid.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.graphicShowGrid.Image = global::LAZYSHELL.Properties.Resources.buttonToggleGrid;
            this.graphicShowGrid.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.graphicShowGrid.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.graphicShowGrid.Name = "graphicShowGrid";
            this.graphicShowGrid.Size = new System.Drawing.Size(23, 17);
            this.graphicShowGrid.Text = "Grid";
            this.graphicShowGrid.Click += new System.EventHandler(this.graphicShowGrid_Click);
            // 
            // graphicShowPixelGrid
            // 
            this.graphicShowPixelGrid.CheckOnClick = true;
            this.graphicShowPixelGrid.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.graphicShowPixelGrid.Image = global::LAZYSHELL.Properties.Resources.buttonTogglePixelGrid;
            this.graphicShowPixelGrid.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.graphicShowPixelGrid.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.graphicShowPixelGrid.Name = "graphicShowPixelGrid";
            this.graphicShowPixelGrid.Size = new System.Drawing.Size(23, 17);
            this.graphicShowPixelGrid.Text = "Pixel Grid";
            this.graphicShowPixelGrid.Click += new System.EventHandler(this.graphicShowPixelGrid_Click);
            // 
            // toolStripSeparator33
            // 
            this.toolStripSeparator33.Margin = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStripSeparator33.Name = "toolStripSeparator33";
            this.toolStripSeparator33.Size = new System.Drawing.Size(6, 20);
            // 
            // subtileDraw
            // 
            this.subtileDraw.CheckOnClick = true;
            this.subtileDraw.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.subtileDraw.Image = global::LAZYSHELL.Properties.Resources.draw_small;
            this.subtileDraw.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.subtileDraw.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.subtileDraw.Name = "subtileDraw";
            this.subtileDraw.Size = new System.Drawing.Size(23, 17);
            this.subtileDraw.Text = "Draw";
            this.subtileDraw.Click += new System.EventHandler(this.subtileDraw_Click);
            // 
            // subtileErase
            // 
            this.subtileErase.CheckOnClick = true;
            this.subtileErase.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.subtileErase.Image = global::LAZYSHELL.Properties.Resources.erase_small;
            this.subtileErase.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.subtileErase.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.subtileErase.Name = "subtileErase";
            this.subtileErase.Size = new System.Drawing.Size(23, 17);
            this.subtileErase.Text = "Erase";
            this.subtileErase.Click += new System.EventHandler(this.subtileErase_Click);
            // 
            // subtileDropper
            // 
            this.subtileDropper.CheckOnClick = true;
            this.subtileDropper.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.subtileDropper.Image = global::LAZYSHELL.Properties.Resources.dropper_small;
            this.subtileDropper.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.subtileDropper.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.subtileDropper.Name = "subtileDropper";
            this.subtileDropper.Size = new System.Drawing.Size(23, 17);
            this.subtileDropper.Text = "Choose Color";
            this.subtileDropper.Click += new System.EventHandler(this.subtileDropper_Click);
            // 
            // toolStripSeparator34
            // 
            this.toolStripSeparator34.Margin = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStripSeparator34.Name = "toolStripSeparator34";
            this.toolStripSeparator34.Size = new System.Drawing.Size(6, 20);
            // 
            // graphicZoomIn
            // 
            this.graphicZoomIn.CheckOnClick = true;
            this.graphicZoomIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.graphicZoomIn.Image = global::LAZYSHELL.Properties.Resources.zoomin_small;
            this.graphicZoomIn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.graphicZoomIn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.graphicZoomIn.Name = "graphicZoomIn";
            this.graphicZoomIn.Size = new System.Drawing.Size(23, 17);
            this.graphicZoomIn.Text = "Zoom In";
            this.graphicZoomIn.Click += new System.EventHandler(this.graphicZoomIn_Click);
            // 
            // graphicZoomOut
            // 
            this.graphicZoomOut.CheckOnClick = true;
            this.graphicZoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.graphicZoomOut.Image = global::LAZYSHELL.Properties.Resources.zoomout_small;
            this.graphicZoomOut.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.graphicZoomOut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.graphicZoomOut.Name = "graphicZoomOut";
            this.graphicZoomOut.Size = new System.Drawing.Size(23, 17);
            this.graphicZoomOut.Text = "Zoom Out";
            this.graphicZoomOut.Click += new System.EventHandler(this.graphicZoomOut_Click);
            // 
            // panel109
            // 
            this.panel109.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel109.AutoScroll = true;
            this.panel109.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel109.Controls.Add(this.pictureBoxGraphicSet);
            this.panel109.Location = new System.Drawing.Point(2, 38);
            this.panel109.Name = "panel109";
            this.panel109.Size = new System.Drawing.Size(256, 256);
            this.panel109.TabIndex = 498;
            this.panel109.Scroll += new System.Windows.Forms.ScrollEventHandler(this.panel109_Scroll);
            // 
            // pictureBoxGraphicSet
            // 
            this.pictureBoxGraphicSet.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBoxGraphicSet.ContextMenuStrip = this.contextMenuStripTE;
            this.pictureBoxGraphicSet.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxGraphicSet.Name = "pictureBoxGraphicSet";
            this.pictureBoxGraphicSet.Size = new System.Drawing.Size(128, 128);
            this.pictureBoxGraphicSet.TabIndex = 450;
            this.pictureBoxGraphicSet.TabStop = false;
            this.pictureBoxGraphicSet.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxGraphicSet_MouseMove);
            this.pictureBoxGraphicSet.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pictureBoxGraphicSet_MouseDoubleClick);
            this.pictureBoxGraphicSet.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxGraphicSet_MouseDown);
            this.pictureBoxGraphicSet.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxGraphicSet_Paint);
            this.pictureBoxGraphicSet.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBoxGraphicSet_MouseUp);
            // 
            // labelImageGraphics
            // 
            this.labelImageGraphics.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.labelImageGraphics.BackColor = System.Drawing.SystemColors.Control;
            this.labelImageGraphics.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.labelImageGraphics.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelImageGraphics.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.labelImageGraphics.Location = new System.Drawing.Point(2, 2);
            this.labelImageGraphics.Name = "labelImageGraphics";
            this.labelImageGraphics.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.labelImageGraphics.Size = new System.Drawing.Size(256, 17);
            this.labelImageGraphics.TabIndex = 497;
            this.labelImageGraphics.Text = "GRAPHIC SET";
            this.labelImageGraphics.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.labelImageGraphics_MouseDoubleClick);
            this.labelImageGraphics.MouseDown += new System.Windows.Forms.MouseEventHandler(this.labelImageGraphics_MouseDown);
            this.labelImageGraphics.MouseUp += new System.Windows.Forms.MouseEventHandler(this.labelImageGraphics_MouseUp);
            // 
            // panel110
            // 
            this.panel110.Controls.Add(this.pictureBoxPalette);
            this.panel110.Controls.Add(this.label50);
            this.panel110.Location = new System.Drawing.Point(-2, 53);
            this.panel110.Name = "panel110";
            this.panel110.Size = new System.Drawing.Size(260, 39);
            this.panel110.TabIndex = 497;
            // 
            // pictureBoxPalette
            // 
            this.pictureBoxPalette.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBoxPalette.Location = new System.Drawing.Point(2, 21);
            this.pictureBoxPalette.Name = "pictureBoxPalette";
            this.pictureBoxPalette.Size = new System.Drawing.Size(256, 16);
            this.pictureBoxPalette.TabIndex = 450;
            this.pictureBoxPalette.TabStop = false;
            this.pictureBoxPalette.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBoxPalette_MouseClick);
            this.pictureBoxPalette.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxPalette_Paint);
            // 
            // label50
            // 
            this.label50.BackColor = System.Drawing.SystemColors.Control;
            this.label50.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label50.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label50.Location = new System.Drawing.Point(2, 2);
            this.label50.Name = "label50";
            this.label50.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.label50.Size = new System.Drawing.Size(256, 17);
            this.label50.TabIndex = 497;
            this.label50.Text = "SELECT PALETTE COLOR...";
            // 
            // panel111
            // 
            this.panel111.Controls.Add(this.showGrid);
            this.panel111.Controls.Add(this.panel112);
            this.panel111.Controls.Add(this.panel113);
            this.panel111.Location = new System.Drawing.Point(-2, -2);
            this.panel111.Name = "panel111";
            this.panel111.Size = new System.Drawing.Size(260, 57);
            this.panel111.TabIndex = 497;
            // 
            // showGrid
            // 
            this.showGrid.Appearance = System.Windows.Forms.Appearance.Button;
            this.showGrid.BackColor = System.Drawing.SystemColors.Control;
            this.showGrid.FlatAppearance.BorderSize = 0;
            this.showGrid.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(168)))), ((int)(((byte)(168)))));
            this.showGrid.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.showGrid.ForeColor = System.Drawing.Color.Gray;
            this.showGrid.Location = new System.Drawing.Point(2, 2);
            this.showGrid.Name = "showGrid";
            this.showGrid.Size = new System.Drawing.Size(65, 17);
            this.showGrid.TabIndex = 452;
            this.showGrid.Text = "GRID";
            this.showGrid.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.showGrid.UseCompatibleTextRendering = true;
            this.showGrid.UseVisualStyleBackColor = false;
            this.showGrid.Click += new System.EventHandler(this.showGrid_Click);
            // 
            // panel112
            // 
            this.panel112.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.panel112.Controls.Add(this.pictureBoxSubtile);
            this.panel112.Controls.Add(this.pictureBoxTile);
            this.panel112.Location = new System.Drawing.Point(2, 22);
            this.panel112.Name = "panel112";
            this.panel112.Size = new System.Drawing.Size(65, 32);
            this.panel112.TabIndex = 448;
            // 
            // pictureBoxSubtile
            // 
            this.pictureBoxSubtile.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBoxSubtile.Location = new System.Drawing.Point(33, 0);
            this.pictureBoxSubtile.Name = "pictureBoxSubtile";
            this.pictureBoxSubtile.Size = new System.Drawing.Size(32, 32);
            this.pictureBoxSubtile.TabIndex = 446;
            this.pictureBoxSubtile.TabStop = false;
            this.pictureBoxSubtile.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxSubtile_Paint);
            // 
            // pictureBoxTile
            // 
            this.pictureBoxTile.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBoxTile.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxTile.Name = "pictureBoxTile";
            this.pictureBoxTile.Size = new System.Drawing.Size(32, 32);
            this.pictureBoxTile.TabIndex = 446;
            this.pictureBoxTile.TabStop = false;
            this.pictureBoxTile.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBoxTile_MouseClick);
            this.pictureBoxTile.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxTile_Paint);
            // 
            // panel113
            // 
            this.panel113.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.panel113.Controls.Add(this.label141);
            this.panel113.Controls.Add(this.tilePalette);
            this.panel113.Controls.Add(this.tileGFXSet);
            this.panel113.Controls.Add(this.tile8x8Tile);
            this.panel113.Controls.Add(this.label142);
            this.panel113.Controls.Add(this.label144);
            this.panel113.Controls.Add(this.tileAttributes);
            this.panel113.Location = new System.Drawing.Point(68, 2);
            this.panel113.Name = "panel113";
            this.panel113.Size = new System.Drawing.Size(190, 53);
            this.panel113.TabIndex = 496;
            // 
            // label141
            // 
            this.label141.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label141.Location = new System.Drawing.Point(0, 0);
            this.label141.Name = "label141";
            this.label141.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.label141.Size = new System.Drawing.Size(63, 17);
            this.label141.TabIndex = 442;
            this.label141.Text = "Subtile";
            // 
            // tilePalette
            // 
            this.tilePalette.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tilePalette.Location = new System.Drawing.Point(64, 36);
            this.tilePalette.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.tilePalette.Name = "tilePalette";
            this.tilePalette.Size = new System.Drawing.Size(43, 17);
            this.tilePalette.TabIndex = 441;
            this.tilePalette.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tilePalette.ValueChanged += new System.EventHandler(this.tilePalette_ValueChanged);
            // 
            // tileGFXSet
            // 
            this.tileGFXSet.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tileGFXSet.Location = new System.Drawing.Point(64, 18);
            this.tileGFXSet.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.tileGFXSet.Name = "tileGFXSet";
            this.tileGFXSet.Size = new System.Drawing.Size(43, 17);
            this.tileGFXSet.TabIndex = 3;
            this.tileGFXSet.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tileGFXSet.ValueChanged += new System.EventHandler(this.tileGFXSet_ValueChanged);
            // 
            // tile8x8Tile
            // 
            this.tile8x8Tile.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tile8x8Tile.Location = new System.Drawing.Point(64, 0);
            this.tile8x8Tile.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.tile8x8Tile.Name = "tile8x8Tile";
            this.tile8x8Tile.Size = new System.Drawing.Size(43, 17);
            this.tile8x8Tile.TabIndex = 2;
            this.tile8x8Tile.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tile8x8Tile.ValueChanged += new System.EventHandler(this.tile8x8Tile_ValueChanged);
            // 
            // label142
            // 
            this.label142.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label142.Location = new System.Drawing.Point(0, 36);
            this.label142.Name = "label142";
            this.label142.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.label142.Size = new System.Drawing.Size(63, 17);
            this.label142.TabIndex = 444;
            this.label142.Text = "Palette";
            // 
            // label144
            // 
            this.label144.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label144.Location = new System.Drawing.Point(0, 18);
            this.label144.Name = "label144";
            this.label144.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.label144.Size = new System.Drawing.Size(63, 17);
            this.label144.TabIndex = 445;
            this.label144.Text = "GFX Set";
            // 
            // tileAttributes
            // 
            this.tileAttributes.BackColor = System.Drawing.SystemColors.Window;
            this.tileAttributes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tileAttributes.CheckOnClick = true;
            this.tileAttributes.ColumnWidth = 60;
            this.tileAttributes.IntegralHeight = false;
            this.tileAttributes.Items.AddRange(new object[] {
            "Priority 1",
            "Mirror",
            "Invert"});
            this.tileAttributes.Location = new System.Drawing.Point(108, 0);
            this.tileAttributes.Name = "tileAttributes";
            this.tileAttributes.Size = new System.Drawing.Size(82, 53);
            this.tileAttributes.TabIndex = 4;
            this.tileAttributes.SelectedIndexChanged += new System.EventHandler(this.tileAttributes_SelectedIndexChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip1.Size = new System.Drawing.Size(1014, 24);
            this.menuStrip1.TabIndex = 1;
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.toolStripSeparator1,
            this.importToolStripMenuItem,
            this.exportToolStripMenuItem1,
            this.clearToolStripMenuItem,
            this.toolStripSeparator21,
            this.SpaceAnalyzerMenuItem,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.saveToolStripMenuItem.Text = "Save Levels";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveLevels_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(166, 6);
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.allToolStripMenuItem,
            this.toolStripSeparator30,
            this.arraysToolStripMenuItem1,
            this.graphicSetsToolStripMenuItem1});
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.importToolStripMenuItem.Text = "Import";
            // 
            // allToolStripMenuItem
            // 
            this.allToolStripMenuItem.Name = "allToolStripMenuItem";
            this.allToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.allToolStripMenuItem.Text = "Level Data...";
            this.allToolStripMenuItem.Click += new System.EventHandler(this.importLevelDataAll_Click);
            // 
            // toolStripSeparator30
            // 
            this.toolStripSeparator30.Name = "toolStripSeparator30";
            this.toolStripSeparator30.Size = new System.Drawing.Size(138, 6);
            // 
            // arraysToolStripMenuItem1
            // 
            this.arraysToolStripMenuItem1.Name = "arraysToolStripMenuItem1";
            this.arraysToolStripMenuItem1.Size = new System.Drawing.Size(141, 22);
            this.arraysToolStripMenuItem1.Text = "Arrays...";
            this.arraysToolStripMenuItem1.Click += new System.EventHandler(this.arraysToolStripMenuItem1_Click);
            // 
            // graphicSetsToolStripMenuItem1
            // 
            this.graphicSetsToolStripMenuItem1.Name = "graphicSetsToolStripMenuItem1";
            this.graphicSetsToolStripMenuItem1.Size = new System.Drawing.Size(141, 22);
            this.graphicSetsToolStripMenuItem1.Text = "Graphic Set...";
            this.graphicSetsToolStripMenuItem1.Click += new System.EventHandler(this.graphicSetsToolStripMenuItem1_Click);
            // 
            // exportToolStripMenuItem1
            // 
            this.exportToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripSeparator28,
            this.arraysToolStripMenuItem,
            this.graphicSetsToolStripMenuItem,
            this.exportLevelImagesToolStripMenuItem1,
            this.toolStripSeparator32,
            this.dumpTextToolStripMenuItem});
            this.exportToolStripMenuItem1.Name = "exportToolStripMenuItem1";
            this.exportToolStripMenuItem1.Size = new System.Drawing.Size(169, 22);
            this.exportToolStripMenuItem1.Text = "Export";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(149, 22);
            this.toolStripMenuItem1.Text = "Level Data...";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.exportLevelDataAll_Click);
            // 
            // toolStripSeparator28
            // 
            this.toolStripSeparator28.Name = "toolStripSeparator28";
            this.toolStripSeparator28.Size = new System.Drawing.Size(146, 6);
            // 
            // arraysToolStripMenuItem
            // 
            this.arraysToolStripMenuItem.Name = "arraysToolStripMenuItem";
            this.arraysToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.arraysToolStripMenuItem.Text = "Arrays...";
            this.arraysToolStripMenuItem.Click += new System.EventHandler(this.arraysToolStripMenuItem_Click);
            // 
            // graphicSetsToolStripMenuItem
            // 
            this.graphicSetsToolStripMenuItem.Name = "graphicSetsToolStripMenuItem";
            this.graphicSetsToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.graphicSetsToolStripMenuItem.Text = "Graphic Sets...";
            this.graphicSetsToolStripMenuItem.Click += new System.EventHandler(this.graphicSetsToolStripMenuItem_Click);
            // 
            // exportLevelImagesToolStripMenuItem1
            // 
            this.exportLevelImagesToolStripMenuItem1.Name = "exportLevelImagesToolStripMenuItem1";
            this.exportLevelImagesToolStripMenuItem1.Size = new System.Drawing.Size(149, 22);
            this.exportLevelImagesToolStripMenuItem1.Text = "Level Images...";
            this.exportLevelImagesToolStripMenuItem1.Click += new System.EventHandler(this.exportLevelImagesAll_Click);
            // 
            // toolStripSeparator32
            // 
            this.toolStripSeparator32.Name = "toolStripSeparator32";
            this.toolStripSeparator32.Size = new System.Drawing.Size(146, 6);
            // 
            // dumpTextToolStripMenuItem
            // 
            this.dumpTextToolStripMenuItem.Name = "dumpTextToolStripMenuItem";
            this.dumpTextToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.dumpTextToolStripMenuItem.Text = "NPCs to Text...";
            this.dumpTextToolStripMenuItem.Click += new System.EventHandler(this.dumpTextToolStripMenuItem_Click);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearLevelDataAll,
            this.toolStripSeparator38,
            this.clearTilesetsAll,
            this.clearTilemapsAll,
            this.clearPhysicalMapsAll,
            this.clearBattlefieldsAll,
            this.toolStripSeparator29,
            this.unusedToolStripMenuItem,
            this.unusedToolStripMenuItem1,
            this.unusedToolStripMenuItem2,
            this.unusedToolStripMenuItem3,
            this.toolStripSeparator8,
            this.clearAllComponentsAll,
            this.clearAllComponentsCurrent});
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.clearToolStripMenuItem.Text = "Clear";
            // 
            // clearLevelDataAll
            // 
            this.clearLevelDataAll.Name = "clearLevelDataAll";
            this.clearLevelDataAll.Size = new System.Drawing.Size(206, 22);
            this.clearLevelDataAll.Text = "Level Data...";
            this.clearLevelDataAll.Click += new System.EventHandler(this.clearLevelDataAll_Click);
            // 
            // toolStripSeparator38
            // 
            this.toolStripSeparator38.Name = "toolStripSeparator38";
            this.toolStripSeparator38.Size = new System.Drawing.Size(203, 6);
            // 
            // clearTilesetsAll
            // 
            this.clearTilesetsAll.Name = "clearTilesetsAll";
            this.clearTilesetsAll.Size = new System.Drawing.Size(206, 22);
            this.clearTilesetsAll.Text = "Tilesets...";
            this.clearTilesetsAll.Click += new System.EventHandler(this.clearTilesetsAll_Click);
            // 
            // clearTilemapsAll
            // 
            this.clearTilemapsAll.Name = "clearTilemapsAll";
            this.clearTilemapsAll.Size = new System.Drawing.Size(206, 22);
            this.clearTilemapsAll.Text = "Tilemaps...";
            this.clearTilemapsAll.Click += new System.EventHandler(this.clearTilemapsAll_Click);
            // 
            // clearPhysicalMapsAll
            // 
            this.clearPhysicalMapsAll.Name = "clearPhysicalMapsAll";
            this.clearPhysicalMapsAll.Size = new System.Drawing.Size(206, 22);
            this.clearPhysicalMapsAll.Text = "Physical Maps...";
            this.clearPhysicalMapsAll.Click += new System.EventHandler(this.clearPhysicalMapsAll_Click);
            // 
            // clearBattlefieldsAll
            // 
            this.clearBattlefieldsAll.Name = "clearBattlefieldsAll";
            this.clearBattlefieldsAll.Size = new System.Drawing.Size(206, 22);
            this.clearBattlefieldsAll.Text = "Battlefields...";
            this.clearBattlefieldsAll.Click += new System.EventHandler(this.clearBattlefieldsAll_Click);
            // 
            // toolStripSeparator29
            // 
            this.toolStripSeparator29.Name = "toolStripSeparator29";
            this.toolStripSeparator29.Size = new System.Drawing.Size(203, 6);
            // 
            // unusedToolStripMenuItem
            // 
            this.unusedToolStripMenuItem.Name = "unusedToolStripMenuItem";
            this.unusedToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.unusedToolStripMenuItem.Text = "Unused tilesets...";
            this.unusedToolStripMenuItem.Click += new System.EventHandler(this.unusedToolStripMenuItem_Click);
            // 
            // unusedToolStripMenuItem1
            // 
            this.unusedToolStripMenuItem1.Name = "unusedToolStripMenuItem1";
            this.unusedToolStripMenuItem1.Size = new System.Drawing.Size(206, 22);
            this.unusedToolStripMenuItem1.Text = "Unused tilemaps...";
            this.unusedToolStripMenuItem1.Click += new System.EventHandler(this.unusedToolStripMenuItem1_Click);
            // 
            // unusedToolStripMenuItem2
            // 
            this.unusedToolStripMenuItem2.Name = "unusedToolStripMenuItem2";
            this.unusedToolStripMenuItem2.Size = new System.Drawing.Size(206, 22);
            this.unusedToolStripMenuItem2.Text = "Unused physical maps...";
            this.unusedToolStripMenuItem2.Click += new System.EventHandler(this.unusedToolStripMenuItem2_Click);
            // 
            // unusedToolStripMenuItem3
            // 
            this.unusedToolStripMenuItem3.Name = "unusedToolStripMenuItem3";
            this.unusedToolStripMenuItem3.Size = new System.Drawing.Size(206, 22);
            this.unusedToolStripMenuItem3.Text = "Unused (all components)...";
            this.unusedToolStripMenuItem3.Click += new System.EventHandler(this.unusedToolStripMenuItem3_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(203, 6);
            // 
            // clearAllComponentsAll
            // 
            this.clearAllComponentsAll.Name = "clearAllComponentsAll";
            this.clearAllComponentsAll.Size = new System.Drawing.Size(206, 22);
            this.clearAllComponentsAll.Text = "All Components (all)...";
            this.clearAllComponentsAll.Click += new System.EventHandler(this.clearAllComponentsAll_Click);
            // 
            // clearAllComponentsCurrent
            // 
            this.clearAllComponentsCurrent.Name = "clearAllComponentsCurrent";
            this.clearAllComponentsCurrent.Size = new System.Drawing.Size(206, 22);
            this.clearAllComponentsCurrent.Text = "All Components (current)...";
            this.clearAllComponentsCurrent.Click += new System.EventHandler(this.clearAllComponentsCurrent_Click);
            // 
            // toolStripSeparator21
            // 
            this.toolStripSeparator21.Name = "toolStripSeparator21";
            this.toolStripSeparator21.Size = new System.Drawing.Size(166, 6);
            // 
            // SpaceAnalyzerMenuItem
            // 
            this.SpaceAnalyzerMenuItem.Name = "SpaceAnalyzerMenuItem";
            this.SpaceAnalyzerMenuItem.Size = new System.Drawing.Size(169, 22);
            this.SpaceAnalyzerMenuItem.Text = "Space Analyzer...";
            this.SpaceAnalyzerMenuItem.Click += new System.EventHandler(this.SpaceAnalyzerMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(166, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitLevels_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem,
            this.toolStripSeparator6,
            this.cutToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.toolStripSeparator22,
            this.selectAllToolStripMenuItem,
            this.clearSelectionToolStripMenuItem,
            this.toolStripSeparator9,
            this.replaceTilesToolStripMenuItem,
            this.toolStripSeparator37,
            this.editAllLayersToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.undoToolStripMenuItem.Text = "Undo";
            this.undoToolStripMenuItem.Click += new System.EventHandler(this.undoToolStripMenuItem_Click);
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.redoToolStripMenuItem.Text = "Redo";
            this.redoToolStripMenuItem.Click += new System.EventHandler(this.redoToolStripMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(184, 6);
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.cutToolStripMenuItem.Text = "Cut";
            this.cutToolStripMenuItem.Click += new System.EventHandler(this.cutToolStripMenuItem_Click);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.pasteToolStripMenuItem.Text = "Paste";
            this.pasteToolStripMenuItem.Click += new System.EventHandler(this.pasteToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // toolStripSeparator22
            // 
            this.toolStripSeparator22.Name = "toolStripSeparator22";
            this.toolStripSeparator22.Size = new System.Drawing.Size(184, 6);
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.selectAllToolStripMenuItem.Text = "Select All";
            this.selectAllToolStripMenuItem.Click += new System.EventHandler(this.selectAllToolStripMenuItem_Click);
            // 
            // clearSelectionToolStripMenuItem
            // 
            this.clearSelectionToolStripMenuItem.Name = "clearSelectionToolStripMenuItem";
            this.clearSelectionToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.clearSelectionToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.clearSelectionToolStripMenuItem.Text = "Clear Selection";
            this.clearSelectionToolStripMenuItem.Click += new System.EventHandler(this.clearSelectionToolStripMenuItem_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(184, 6);
            // 
            // replaceTilesToolStripMenuItem
            // 
            this.replaceTilesToolStripMenuItem.Name = "replaceTilesToolStripMenuItem";
            this.replaceTilesToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
            this.replaceTilesToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.replaceTilesToolStripMenuItem.Text = "Replace Tiles...";
            this.replaceTilesToolStripMenuItem.Click += new System.EventHandler(this.replaceTilesToolStripMenuItem_Click);
            // 
            // toolStripSeparator37
            // 
            this.toolStripSeparator37.Name = "toolStripSeparator37";
            this.toolStripSeparator37.Size = new System.Drawing.Size(184, 6);
            // 
            // editAllLayersToolStripMenuItem
            // 
            this.editAllLayersToolStripMenuItem.CheckOnClick = true;
            this.editAllLayersToolStripMenuItem.Name = "editAllLayersToolStripMenuItem";
            this.editAllLayersToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.editAllLayersToolStripMenuItem.Text = "Edit All Layers";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cartesianGridToolStripMenuItem,
            this.orthographicGridToolStripMenuItem,
            this.toolStripSeparator3,
            this.maskToolStripMenuItem,
            this.toolStripSeparator4,
            this.layer1ToolStripMenuItem,
            this.layer2ToolStripMenuItem,
            this.layer3ToolStripMenuItem,
            this.priority1ToolStripMenuItem,
            this.backgroundToolStripMenuItem,
            this.toolStripSeparator5,
            this.physicalMapToolStripMenuItem,
            this.npcsToolStripMenuItem,
            this.exitFieldsToolStripMenuItem,
            this.eventFieldsToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // cartesianGridToolStripMenuItem
            // 
            this.cartesianGridToolStripMenuItem.CheckOnClick = true;
            this.cartesianGridToolStripMenuItem.Name = "cartesianGridToolStripMenuItem";
            this.cartesianGridToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.G)));
            this.cartesianGridToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.cartesianGridToolStripMenuItem.Text = "Cartesian Grid";
            this.cartesianGridToolStripMenuItem.Click += new System.EventHandler(this.cartesianGridToolStripMenuItem_Click);
            // 
            // orthographicGridToolStripMenuItem
            // 
            this.orthographicGridToolStripMenuItem.CheckOnClick = true;
            this.orthographicGridToolStripMenuItem.Name = "orthographicGridToolStripMenuItem";
            this.orthographicGridToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.orthographicGridToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.orthographicGridToolStripMenuItem.Text = "Isometric Grid";
            this.orthographicGridToolStripMenuItem.Click += new System.EventHandler(this.orthographicGridToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(196, 6);
            // 
            // maskToolStripMenuItem
            // 
            this.maskToolStripMenuItem.CheckOnClick = true;
            this.maskToolStripMenuItem.Name = "maskToolStripMenuItem";
            this.maskToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.M)));
            this.maskToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.maskToolStripMenuItem.Text = "Mask";
            this.maskToolStripMenuItem.Click += new System.EventHandler(this.maskToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(196, 6);
            // 
            // layer1ToolStripMenuItem
            // 
            this.layer1ToolStripMenuItem.CheckOnClick = true;
            this.layer1ToolStripMenuItem.Name = "layer1ToolStripMenuItem";
            this.layer1ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D1)));
            this.layer1ToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.layer1ToolStripMenuItem.Text = "Layer 1";
            this.layer1ToolStripMenuItem.Click += new System.EventHandler(this.layer1ToolStripMenuItem_Click);
            // 
            // layer2ToolStripMenuItem
            // 
            this.layer2ToolStripMenuItem.CheckOnClick = true;
            this.layer2ToolStripMenuItem.Name = "layer2ToolStripMenuItem";
            this.layer2ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D2)));
            this.layer2ToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.layer2ToolStripMenuItem.Text = "Layer 2";
            this.layer2ToolStripMenuItem.Click += new System.EventHandler(this.layer2ToolStripMenuItem_Click);
            // 
            // layer3ToolStripMenuItem
            // 
            this.layer3ToolStripMenuItem.CheckOnClick = true;
            this.layer3ToolStripMenuItem.Name = "layer3ToolStripMenuItem";
            this.layer3ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D3)));
            this.layer3ToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.layer3ToolStripMenuItem.Text = "Layer 3";
            this.layer3ToolStripMenuItem.Click += new System.EventHandler(this.layer3ToolStripMenuItem_Click);
            // 
            // priority1ToolStripMenuItem
            // 
            this.priority1ToolStripMenuItem.CheckOnClick = true;
            this.priority1ToolStripMenuItem.Name = "priority1ToolStripMenuItem";
            this.priority1ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D4)));
            this.priority1ToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.priority1ToolStripMenuItem.Text = "Highlight Priority 1";
            this.priority1ToolStripMenuItem.Click += new System.EventHandler(this.priority1ToolStripMenuItem_Click);
            // 
            // backgroundToolStripMenuItem
            // 
            this.backgroundToolStripMenuItem.Name = "backgroundToolStripMenuItem";
            this.backgroundToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D5)));
            this.backgroundToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.backgroundToolStripMenuItem.Text = "Background";
            this.backgroundToolStripMenuItem.Click += new System.EventHandler(this.backgroundToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(196, 6);
            // 
            // physicalMapToolStripMenuItem
            // 
            this.physicalMapToolStripMenuItem.CheckOnClick = true;
            this.physicalMapToolStripMenuItem.Name = "physicalMapToolStripMenuItem";
            this.physicalMapToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
            this.physicalMapToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.physicalMapToolStripMenuItem.Text = "Physical Map";
            this.physicalMapToolStripMenuItem.Click += new System.EventHandler(this.physicalMapToolStripMenuItem_Click);
            // 
            // npcsToolStripMenuItem
            // 
            this.npcsToolStripMenuItem.CheckOnClick = true;
            this.npcsToolStripMenuItem.Name = "npcsToolStripMenuItem";
            this.npcsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.npcsToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.npcsToolStripMenuItem.Text = "NPCs";
            this.npcsToolStripMenuItem.Click += new System.EventHandler(this.npcsToolStripMenuItem_Click);
            // 
            // exitFieldsToolStripMenuItem
            // 
            this.exitFieldsToolStripMenuItem.CheckOnClick = true;
            this.exitFieldsToolStripMenuItem.Name = "exitFieldsToolStripMenuItem";
            this.exitFieldsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.exitFieldsToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.exitFieldsToolStripMenuItem.Text = "Exit Fields";
            this.exitFieldsToolStripMenuItem.Click += new System.EventHandler(this.exitFieldsToolStripMenuItem_Click);
            // 
            // eventFieldsToolStripMenuItem
            // 
            this.eventFieldsToolStripMenuItem.CheckOnClick = true;
            this.eventFieldsToolStripMenuItem.Name = "eventFieldsToolStripMenuItem";
            this.eventFieldsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.eventFieldsToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.eventFieldsToolStripMenuItem.Text = "Event Fields";
            this.eventFieldsToolStripMenuItem.Click += new System.EventHandler(this.eventFieldsToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.enableHelpTipsToolStripMenuItem,
            this.showDecHexToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // enableHelpTipsToolStripMenuItem
            // 
            this.enableHelpTipsToolStripMenuItem.CheckOnClick = true;
            this.enableHelpTipsToolStripMenuItem.Name = "enableHelpTipsToolStripMenuItem";
            this.enableHelpTipsToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.enableHelpTipsToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.enableHelpTipsToolStripMenuItem.Text = "Enable Help Tips";
            // 
            // showDecHexToolStripMenuItem
            // 
            this.showDecHexToolStripMenuItem.CheckOnClick = true;
            this.showDecHexToolStripMenuItem.Name = "showDecHexToolStripMenuItem";
            this.showDecHexToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.showDecHexToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.showDecHexToolStripMenuItem.Text = "Show Dec <> Hex";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.aboutToolStripMenuItem.Text = "About...";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripSeparator18,
            this.buttonToggleProperties,
            this.buttonToggleTileEditor,
            this.buttonToggleTemplates,
            this.toolStripSeparator17,
            this.buttonToggleCartGrid,
            this.buttonToggleOrthGrid,
            this.toolStripSeparator16,
            this.buttonToggleMask,
            this.toolStripSeparator15,
            this.buttonToggleL1,
            this.buttonToggleL2,
            this.buttonToggleL3,
            this.buttonToggleBG,
            this.buttonToggleP1,
            this.toolStripSeparator14,
            this.buttonTogglePhys,
            this.buttonToggleNPCs,
            this.buttonToggleExits,
            this.buttonToggleEvents,
            this.buttonToggleOverlaps,
            this.toolStripSeparator13,
            this.toolStripLabel2,
            this.toolStripSeparator19,
            this.buttonEditTemplate,
            this.toolStripSeparator46,
            this.buttonEditDraw,
            this.buttonEditErase,
            this.buttonEditSelect,
            this.buttonEditDropper,
            this.toolStripSeparator10,
            this.buttonEditDelete,
            this.buttonEditCut,
            this.buttonEditCopy,
            this.buttonEditPaste,
            this.toolStripSeparator11,
            this.buttonEditUndo,
            this.buttonEditRedo,
            this.toolStripSeparator12,
            this.buttonZoomIn,
            this.buttonZoomOut,
            this.toolStripSeparator7,
            this.levelPreviewToolStripButton,
            this.toolStripSeparator26,
            this.opacityToolStripButton,
            this.toolStripSeparator23});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(8, 0, 1, 0);
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(1014, 25);
            this.toolStrip1.TabIndex = 2;
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(46, 22);
            this.toolStripLabel1.Text = "TOGGLE";
            // 
            // toolStripSeparator18
            // 
            this.toolStripSeparator18.Margin = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStripSeparator18.Name = "toolStripSeparator18";
            this.toolStripSeparator18.Size = new System.Drawing.Size(6, 25);
            // 
            // buttonToggleProperties
            // 
            this.buttonToggleProperties.CheckOnClick = true;
            this.buttonToggleProperties.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonToggleProperties.Image = global::LAZYSHELL.Properties.Resources.buttonToggleProperties;
            this.buttonToggleProperties.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.buttonToggleProperties.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonToggleProperties.Name = "buttonToggleProperties";
            this.buttonToggleProperties.Size = new System.Drawing.Size(23, 22);
            this.buttonToggleProperties.Text = "Level Properties";
            this.buttonToggleProperties.Click += new System.EventHandler(this.buttonToggleProperties_Click);
            // 
            // buttonToggleTileEditor
            // 
            this.buttonToggleTileEditor.CheckOnClick = true;
            this.buttonToggleTileEditor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonToggleTileEditor.Image = global::LAZYSHELL.Properties.Resources.buttonToggleTileEditor;
            this.buttonToggleTileEditor.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.buttonToggleTileEditor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonToggleTileEditor.Name = "buttonToggleTileEditor";
            this.buttonToggleTileEditor.Size = new System.Drawing.Size(23, 22);
            this.buttonToggleTileEditor.Text = "Tile Editor";
            this.buttonToggleTileEditor.Click += new System.EventHandler(this.buttonToggleTileEditor_Click);
            // 
            // buttonToggleTemplates
            // 
            this.buttonToggleTemplates.CheckOnClick = true;
            this.buttonToggleTemplates.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonToggleTemplates.Image = global::LAZYSHELL.Properties.Resources.buttonToggleTemplates;
            this.buttonToggleTemplates.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.buttonToggleTemplates.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonToggleTemplates.Name = "buttonToggleTemplates";
            this.buttonToggleTemplates.Size = new System.Drawing.Size(23, 22);
            this.buttonToggleTemplates.Text = "Templates";
            this.buttonToggleTemplates.Click += new System.EventHandler(this.buttonToggleTemplates_Click);
            // 
            // toolStripSeparator17
            // 
            this.toolStripSeparator17.Margin = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStripSeparator17.Name = "toolStripSeparator17";
            this.toolStripSeparator17.Size = new System.Drawing.Size(6, 25);
            // 
            // buttonToggleCartGrid
            // 
            this.buttonToggleCartGrid.CheckOnClick = true;
            this.buttonToggleCartGrid.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonToggleCartGrid.Image = global::LAZYSHELL.Properties.Resources.buttonToggleGrid;
            this.buttonToggleCartGrid.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.buttonToggleCartGrid.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonToggleCartGrid.Name = "buttonToggleCartGrid";
            this.buttonToggleCartGrid.Size = new System.Drawing.Size(23, 22);
            this.buttonToggleCartGrid.Text = "Cartesian Grid";
            this.buttonToggleCartGrid.Click += new System.EventHandler(this.buttonToggleCartGrid_Click);
            // 
            // buttonToggleOrthGrid
            // 
            this.buttonToggleOrthGrid.CheckOnClick = true;
            this.buttonToggleOrthGrid.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonToggleOrthGrid.Image = global::LAZYSHELL.Properties.Resources.buttonToggleOrthGrid;
            this.buttonToggleOrthGrid.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.buttonToggleOrthGrid.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonToggleOrthGrid.Name = "buttonToggleOrthGrid";
            this.buttonToggleOrthGrid.Size = new System.Drawing.Size(23, 22);
            this.buttonToggleOrthGrid.Text = "Isometric Grid";
            this.buttonToggleOrthGrid.Click += new System.EventHandler(this.buttonToggleOrthGrid_Click);
            // 
            // toolStripSeparator16
            // 
            this.toolStripSeparator16.Margin = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStripSeparator16.Name = "toolStripSeparator16";
            this.toolStripSeparator16.Size = new System.Drawing.Size(6, 25);
            // 
            // buttonToggleMask
            // 
            this.buttonToggleMask.CheckOnClick = true;
            this.buttonToggleMask.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonToggleMask.Image = global::LAZYSHELL.Properties.Resources.buttonToggleMask;
            this.buttonToggleMask.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.buttonToggleMask.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonToggleMask.Name = "buttonToggleMask";
            this.buttonToggleMask.Size = new System.Drawing.Size(23, 22);
            this.buttonToggleMask.Text = "Mask";
            this.buttonToggleMask.Click += new System.EventHandler(this.buttonToggleMask_Click);
            // 
            // toolStripSeparator15
            // 
            this.toolStripSeparator15.Margin = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStripSeparator15.Name = "toolStripSeparator15";
            this.toolStripSeparator15.Size = new System.Drawing.Size(6, 25);
            // 
            // buttonToggleL1
            // 
            this.buttonToggleL1.CheckOnClick = true;
            this.buttonToggleL1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.buttonToggleL1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonToggleL1.Name = "buttonToggleL1";
            this.buttonToggleL1.Size = new System.Drawing.Size(23, 22);
            this.buttonToggleL1.Text = "L1";
            this.buttonToggleL1.ToolTipText = "Layer 1";
            this.buttonToggleL1.Click += new System.EventHandler(this.buttonToggleL1_Click);
            // 
            // buttonToggleL2
            // 
            this.buttonToggleL2.CheckOnClick = true;
            this.buttonToggleL2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.buttonToggleL2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonToggleL2.Name = "buttonToggleL2";
            this.buttonToggleL2.Size = new System.Drawing.Size(23, 22);
            this.buttonToggleL2.Text = "L2";
            this.buttonToggleL2.ToolTipText = "Layer 2";
            this.buttonToggleL2.Click += new System.EventHandler(this.buttonToggleL2_Click);
            // 
            // buttonToggleL3
            // 
            this.buttonToggleL3.CheckOnClick = true;
            this.buttonToggleL3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.buttonToggleL3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonToggleL3.Name = "buttonToggleL3";
            this.buttonToggleL3.Size = new System.Drawing.Size(23, 22);
            this.buttonToggleL3.Text = "L3";
            this.buttonToggleL3.ToolTipText = "Layer 3";
            this.buttonToggleL3.Click += new System.EventHandler(this.buttonToggleL3_Click);
            // 
            // buttonToggleBG
            // 
            this.buttonToggleBG.CheckOnClick = true;
            this.buttonToggleBG.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.buttonToggleBG.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonToggleBG.Name = "buttonToggleBG";
            this.buttonToggleBG.Size = new System.Drawing.Size(24, 22);
            this.buttonToggleBG.Text = "BG";
            this.buttonToggleBG.ToolTipText = "Background";
            this.buttonToggleBG.Click += new System.EventHandler(this.buttonToggleBG_Click);
            // 
            // buttonToggleP1
            // 
            this.buttonToggleP1.CheckOnClick = true;
            this.buttonToggleP1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonToggleP1.Image = global::LAZYSHELL.Properties.Resources.buttonToggleP1;
            this.buttonToggleP1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.buttonToggleP1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonToggleP1.Name = "buttonToggleP1";
            this.buttonToggleP1.Size = new System.Drawing.Size(23, 22);
            this.buttonToggleP1.ToolTipText = "Highlight Priority 1";
            this.buttonToggleP1.Click += new System.EventHandler(this.buttonToggleP1_Click);
            // 
            // toolStripSeparator14
            // 
            this.toolStripSeparator14.Margin = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStripSeparator14.Name = "toolStripSeparator14";
            this.toolStripSeparator14.Size = new System.Drawing.Size(6, 25);
            // 
            // buttonTogglePhys
            // 
            this.buttonTogglePhys.CheckOnClick = true;
            this.buttonTogglePhys.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonTogglePhys.Image = global::LAZYSHELL.Properties.Resources.buttonPhysical;
            this.buttonTogglePhys.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.buttonTogglePhys.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonTogglePhys.Name = "buttonTogglePhys";
            this.buttonTogglePhys.Size = new System.Drawing.Size(23, 22);
            this.buttonTogglePhys.Text = "Physical Field";
            this.buttonTogglePhys.Click += new System.EventHandler(this.buttonTogglePhys_Click);
            // 
            // buttonToggleNPCs
            // 
            this.buttonToggleNPCs.CheckOnClick = true;
            this.buttonToggleNPCs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonToggleNPCs.Image = global::LAZYSHELL.Properties.Resources.buttonNPC;
            this.buttonToggleNPCs.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.buttonToggleNPCs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonToggleNPCs.Name = "buttonToggleNPCs";
            this.buttonToggleNPCs.Size = new System.Drawing.Size(23, 22);
            this.buttonToggleNPCs.Text = "NPCs";
            this.buttonToggleNPCs.Click += new System.EventHandler(this.buttonToggleNPCs_Click);
            // 
            // buttonToggleExits
            // 
            this.buttonToggleExits.CheckOnClick = true;
            this.buttonToggleExits.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonToggleExits.Image = global::LAZYSHELL.Properties.Resources.buttonExitField;
            this.buttonToggleExits.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.buttonToggleExits.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonToggleExits.Name = "buttonToggleExits";
            this.buttonToggleExits.Size = new System.Drawing.Size(23, 22);
            this.buttonToggleExits.Text = "Exits";
            this.buttonToggleExits.Click += new System.EventHandler(this.buttonToggleExits_Click);
            // 
            // buttonToggleEvents
            // 
            this.buttonToggleEvents.CheckOnClick = true;
            this.buttonToggleEvents.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonToggleEvents.Image = global::LAZYSHELL.Properties.Resources.buttonEventField;
            this.buttonToggleEvents.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.buttonToggleEvents.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonToggleEvents.Name = "buttonToggleEvents";
            this.buttonToggleEvents.Size = new System.Drawing.Size(23, 22);
            this.buttonToggleEvents.Text = "Events";
            this.buttonToggleEvents.Click += new System.EventHandler(this.buttonToggleEvents_Click);
            // 
            // buttonToggleOverlaps
            // 
            this.buttonToggleOverlaps.CheckOnClick = true;
            this.buttonToggleOverlaps.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonToggleOverlaps.Image = global::LAZYSHELL.Properties.Resources.buttonOverlaps;
            this.buttonToggleOverlaps.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.buttonToggleOverlaps.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonToggleOverlaps.Name = "buttonToggleOverlaps";
            this.buttonToggleOverlaps.Size = new System.Drawing.Size(23, 22);
            this.buttonToggleOverlaps.Text = "Overlaps";
            this.buttonToggleOverlaps.Click += new System.EventHandler(this.buttonToggleOverlaps_Click);
            // 
            // toolStripSeparator13
            // 
            this.toolStripSeparator13.Margin = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStripSeparator13.Name = "toolStripSeparator13";
            this.toolStripSeparator13.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(30, 22);
            this.toolStripLabel2.Text = "EDIT";
            // 
            // toolStripSeparator19
            // 
            this.toolStripSeparator19.Margin = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStripSeparator19.Name = "toolStripSeparator19";
            this.toolStripSeparator19.Size = new System.Drawing.Size(6, 25);
            // 
            // buttonEditTemplate
            // 
            this.buttonEditTemplate.CheckOnClick = true;
            this.buttonEditTemplate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonEditTemplate.Image = global::LAZYSHELL.Properties.Resources.template_small;
            this.buttonEditTemplate.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.buttonEditTemplate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonEditTemplate.Name = "buttonEditTemplate";
            this.buttonEditTemplate.Size = new System.Drawing.Size(23, 22);
            this.buttonEditTemplate.Text = "Paint Template";
            this.buttonEditTemplate.Click += new System.EventHandler(this.buttonEditTemplate_Click);
            // 
            // toolStripSeparator46
            // 
            this.toolStripSeparator46.Name = "toolStripSeparator46";
            this.toolStripSeparator46.Size = new System.Drawing.Size(6, 25);
            // 
            // buttonEditDraw
            // 
            this.buttonEditDraw.CheckOnClick = true;
            this.buttonEditDraw.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonEditDraw.Image = global::LAZYSHELL.Properties.Resources.draw_small;
            this.buttonEditDraw.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.buttonEditDraw.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonEditDraw.Name = "buttonEditDraw";
            this.buttonEditDraw.Size = new System.Drawing.Size(23, 22);
            this.buttonEditDraw.Text = "Draw Tile";
            this.buttonEditDraw.Click += new System.EventHandler(this.buttonEditDraw_Click);
            // 
            // buttonEditErase
            // 
            this.buttonEditErase.CheckOnClick = true;
            this.buttonEditErase.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonEditErase.Image = global::LAZYSHELL.Properties.Resources.erase_small;
            this.buttonEditErase.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.buttonEditErase.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonEditErase.Name = "buttonEditErase";
            this.buttonEditErase.Size = new System.Drawing.Size(23, 22);
            this.buttonEditErase.Text = "Erase Tile";
            this.buttonEditErase.Click += new System.EventHandler(this.buttonEditErase_Click);
            // 
            // buttonEditSelect
            // 
            this.buttonEditSelect.CheckOnClick = true;
            this.buttonEditSelect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonEditSelect.Image = global::LAZYSHELL.Properties.Resources.select_small;
            this.buttonEditSelect.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.buttonEditSelect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonEditSelect.Name = "buttonEditSelect";
            this.buttonEditSelect.Size = new System.Drawing.Size(23, 22);
            this.buttonEditSelect.Text = "Select Tile(s)";
            this.buttonEditSelect.Click += new System.EventHandler(this.buttonEditSelect_Click);
            // 
            // buttonEditDropper
            // 
            this.buttonEditDropper.CheckOnClick = true;
            this.buttonEditDropper.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonEditDropper.Image = global::LAZYSHELL.Properties.Resources.dropper_small;
            this.buttonEditDropper.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.buttonEditDropper.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonEditDropper.Name = "buttonEditDropper";
            this.buttonEditDropper.Size = new System.Drawing.Size(23, 22);
            this.buttonEditDropper.Text = "Select Color";
            this.buttonEditDropper.Click += new System.EventHandler(this.buttonEditDropper_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Margin = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(6, 25);
            // 
            // buttonEditDelete
            // 
            this.buttonEditDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonEditDelete.Image = global::LAZYSHELL.Properties.Resources.delete_small;
            this.buttonEditDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.buttonEditDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonEditDelete.Name = "buttonEditDelete";
            this.buttonEditDelete.Size = new System.Drawing.Size(23, 22);
            this.buttonEditDelete.Text = "Delete";
            this.buttonEditDelete.Click += new System.EventHandler(this.buttonEditDelete_Click);
            // 
            // buttonEditCut
            // 
            this.buttonEditCut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonEditCut.Image = global::LAZYSHELL.Properties.Resources.cut_small;
            this.buttonEditCut.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.buttonEditCut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonEditCut.Name = "buttonEditCut";
            this.buttonEditCut.Size = new System.Drawing.Size(23, 22);
            this.buttonEditCut.Text = "Cut";
            this.buttonEditCut.Click += new System.EventHandler(this.buttonEditCut_Click);
            // 
            // buttonEditCopy
            // 
            this.buttonEditCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonEditCopy.Image = global::LAZYSHELL.Properties.Resources.copy_small;
            this.buttonEditCopy.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.buttonEditCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonEditCopy.Name = "buttonEditCopy";
            this.buttonEditCopy.Size = new System.Drawing.Size(23, 22);
            this.buttonEditCopy.Text = "Copy";
            this.buttonEditCopy.Click += new System.EventHandler(this.buttonEditCopy_Click);
            // 
            // buttonEditPaste
            // 
            this.buttonEditPaste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonEditPaste.Image = global::LAZYSHELL.Properties.Resources.paste_small;
            this.buttonEditPaste.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.buttonEditPaste.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonEditPaste.Name = "buttonEditPaste";
            this.buttonEditPaste.Size = new System.Drawing.Size(23, 22);
            this.buttonEditPaste.Text = "Paste";
            this.buttonEditPaste.Click += new System.EventHandler(this.buttonEditPaste_Click);
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Margin = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(6, 25);
            // 
            // buttonEditUndo
            // 
            this.buttonEditUndo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonEditUndo.Image = global::LAZYSHELL.Properties.Resources.undo_small;
            this.buttonEditUndo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.buttonEditUndo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonEditUndo.Name = "buttonEditUndo";
            this.buttonEditUndo.Size = new System.Drawing.Size(23, 22);
            this.buttonEditUndo.Text = "Undo";
            this.buttonEditUndo.Click += new System.EventHandler(this.buttonEditUndo_Click);
            // 
            // buttonEditRedo
            // 
            this.buttonEditRedo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonEditRedo.Image = global::LAZYSHELL.Properties.Resources.redo_small;
            this.buttonEditRedo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.buttonEditRedo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonEditRedo.Name = "buttonEditRedo";
            this.buttonEditRedo.Size = new System.Drawing.Size(23, 22);
            this.buttonEditRedo.Text = "Redo";
            this.buttonEditRedo.Click += new System.EventHandler(this.buttonEditRedo_Click);
            // 
            // toolStripSeparator12
            // 
            this.toolStripSeparator12.Margin = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            this.toolStripSeparator12.Size = new System.Drawing.Size(6, 25);
            // 
            // buttonZoomIn
            // 
            this.buttonZoomIn.CheckOnClick = true;
            this.buttonZoomIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonZoomIn.Image = global::LAZYSHELL.Properties.Resources.zoomin_small;
            this.buttonZoomIn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.buttonZoomIn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonZoomIn.Name = "buttonZoomIn";
            this.buttonZoomIn.Size = new System.Drawing.Size(23, 22);
            this.buttonZoomIn.Text = "Zoom In";
            this.buttonZoomIn.CheckedChanged += new System.EventHandler(this.buttonZoomIn_CheckedChanged);
            this.buttonZoomIn.Click += new System.EventHandler(this.buttonZoomIn_Click);
            // 
            // buttonZoomOut
            // 
            this.buttonZoomOut.CheckOnClick = true;
            this.buttonZoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonZoomOut.Image = global::LAZYSHELL.Properties.Resources.zoomout_small;
            this.buttonZoomOut.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.buttonZoomOut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonZoomOut.Name = "buttonZoomOut";
            this.buttonZoomOut.Size = new System.Drawing.Size(23, 22);
            this.buttonZoomOut.Text = "Zoom Out";
            this.buttonZoomOut.CheckedChanged += new System.EventHandler(this.buttonZoomOut_CheckedChanged);
            this.buttonZoomOut.Click += new System.EventHandler(this.buttonZoomOut_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Margin = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 25);
            // 
            // levelPreviewToolStripButton
            // 
            this.levelPreviewToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.levelPreviewToolStripButton.Image = global::LAZYSHELL.Properties.Resources.preview;
            this.levelPreviewToolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.levelPreviewToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.levelPreviewToolStripButton.Name = "levelPreviewToolStripButton";
            this.levelPreviewToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.levelPreviewToolStripButton.Text = "Level Preview";
            this.levelPreviewToolStripButton.Click += new System.EventHandler(this.levelPreviewToolStripButton_Click);
            // 
            // toolStripSeparator26
            // 
            this.toolStripSeparator26.Margin = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStripSeparator26.Name = "toolStripSeparator26";
            this.toolStripSeparator26.Size = new System.Drawing.Size(6, 25);
            // 
            // opacityToolStripButton
            // 
            this.opacityToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.opacityToolStripButton.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.opacityToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("opacityToolStripButton.Image")));
            this.opacityToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.opacityToolStripButton.Name = "opacityToolStripButton";
            this.opacityToolStripButton.Size = new System.Drawing.Size(58, 22);
            this.opacityToolStripButton.Text = "OPACITY";
            this.opacityToolStripButton.Click += new System.EventHandler(this.opacityToolStripButton_Click);
            // 
            // toolStripSeparator23
            // 
            this.toolStripSeparator23.Name = "toolStripSeparator23";
            this.toolStripSeparator23.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem6.Text = "toolStripMenuItem6";
            // 
            // overlayOpacity
            // 
            this.overlayOpacity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.overlayOpacity.AutoSize = false;
            this.overlayOpacity.BackColor = System.Drawing.SystemColors.Control;
            this.overlayOpacity.Location = new System.Drawing.Point(2, 2);
            this.overlayOpacity.Maximum = 100;
            this.overlayOpacity.Name = "overlayOpacity";
            this.overlayOpacity.Size = new System.Drawing.Size(152, 17);
            this.overlayOpacity.TabIndex = 443;
            this.overlayOpacity.TickStyle = System.Windows.Forms.TickStyle.None;
            this.overlayOpacity.Value = 100;
            this.overlayOpacity.Scroll += new System.EventHandler(this.overlayOpacity_Scroll);
            // 
            // ExportLevelImages
            // 
            this.ExportLevelImages.WorkerReportsProgress = true;
            this.ExportLevelImages.WorkerSupportsCancellation = true;
            this.ExportLevelImages.DoWork += new System.ComponentModel.DoWorkEventHandler(this.ExportLevelImages_DoWork);
            this.ExportLevelImages.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.ExportLevelImages_RunWorkerCompleted);
            this.ExportLevelImages.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.ExportLevelImages_ProgressChanged);
            // 
            // labelOverlayOpacity
            // 
            this.labelOverlayOpacity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelOverlayOpacity.BackColor = System.Drawing.SystemColors.Control;
            this.labelOverlayOpacity.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOverlayOpacity.Location = new System.Drawing.Point(154, 2);
            this.labelOverlayOpacity.Name = "labelOverlayOpacity";
            this.labelOverlayOpacity.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.labelOverlayOpacity.Size = new System.Drawing.Size(44, 17);
            this.labelOverlayOpacity.TabIndex = 444;
            this.labelOverlayOpacity.Text = "100%";
            // 
            // label67
            // 
            this.label67.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label67.BackColor = System.Drawing.SystemColors.Control;
            this.label67.Location = new System.Drawing.Point(268, 693);
            this.label67.Name = "label67";
            this.label67.Padding = new System.Windows.Forms.Padding(0, 0, 2, 2);
            this.label67.Size = new System.Drawing.Size(462, 18);
            this.label67.TabIndex = 160;
            this.label67.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // toolTip1
            // 
            this.toolTip1.Active = false;
            // 
            // directorySearcher1
            // 
            this.directorySearcher1.ClientTimeout = System.TimeSpan.Parse("-00:00:01");
            this.directorySearcher1.ServerPageTimeLimit = System.TimeSpan.Parse("-00:00:01");
            this.directorySearcher1.ServerTimeLimit = System.TimeSpan.Parse("-00:00:01");
            // 
            // panelOpacity
            // 
            this.panelOpacity.BackColor = System.Drawing.SystemColors.ControlText;
            this.panelOpacity.Controls.Add(this.overlayOpacity);
            this.panelOpacity.Controls.Add(this.labelOverlayOpacity);
            this.panelOpacity.Location = new System.Drawing.Point(717, 49);
            this.panelOpacity.Name = "panelOpacity";
            this.panelOpacity.Size = new System.Drawing.Size(200, 21);
            this.panelOpacity.TabIndex = 446;
            this.panelOpacity.Visible = false;
            // 
            // panelTemplateName
            // 
            this.panelTemplateName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panelTemplateName.BackColor = System.Drawing.SystemColors.ControlText;
            this.panelTemplateName.Controls.Add(this.label64);
            this.panelTemplateName.Controls.Add(this.buttonTemplateOK);
            this.panelTemplateName.Controls.Add(this.buttonTemplateCancel);
            this.panelTemplateName.Controls.Add(this.panel116);
            this.panelTemplateName.Location = new System.Drawing.Point(540, 200);
            this.panelTemplateName.Name = "panelTemplateName";
            this.panelTemplateName.Size = new System.Drawing.Size(412, 40);
            this.panelTemplateName.TabIndex = 501;
            this.panelTemplateName.Visible = false;
            // 
            // label64
            // 
            this.label64.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label64.Location = new System.Drawing.Point(2, 2);
            this.label64.Name = "label64";
            this.label64.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label64.Size = new System.Drawing.Size(408, 17);
            this.label64.TabIndex = 458;
            this.label64.Text = "Please give this template a name...";
            // 
            // buttonTemplateOK
            // 
            this.buttonTemplateOK.BackColor = System.Drawing.SystemColors.Control;
            this.buttonTemplateOK.FlatAppearance.BorderSize = 0;
            this.buttonTemplateOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTemplateOK.Location = new System.Drawing.Point(272, 21);
            this.buttonTemplateOK.Name = "buttonTemplateOK";
            this.buttonTemplateOK.Size = new System.Drawing.Size(68, 17);
            this.buttonTemplateOK.TabIndex = 456;
            this.buttonTemplateOK.Text = "OK";
            this.buttonTemplateOK.UseCompatibleTextRendering = true;
            this.buttonTemplateOK.UseVisualStyleBackColor = false;
            this.buttonTemplateOK.Click += new System.EventHandler(this.buttonTemplateOK_Click);
            // 
            // buttonTemplateCancel
            // 
            this.buttonTemplateCancel.BackColor = System.Drawing.SystemColors.Control;
            this.buttonTemplateCancel.FlatAppearance.BorderSize = 0;
            this.buttonTemplateCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTemplateCancel.Location = new System.Drawing.Point(342, 21);
            this.buttonTemplateCancel.Name = "buttonTemplateCancel";
            this.buttonTemplateCancel.Size = new System.Drawing.Size(68, 17);
            this.buttonTemplateCancel.TabIndex = 456;
            this.buttonTemplateCancel.Text = "CANCEL";
            this.buttonTemplateCancel.UseCompatibleTextRendering = true;
            this.buttonTemplateCancel.UseVisualStyleBackColor = false;
            this.buttonTemplateCancel.Click += new System.EventHandler(this.buttonTemplateCancel_Click);
            // 
            // panel116
            // 
            this.panel116.BackColor = System.Drawing.SystemColors.Window;
            this.panel116.Controls.Add(this.templateName);
            this.panel116.Location = new System.Drawing.Point(2, 21);
            this.panel116.Name = "panel116";
            this.panel116.Size = new System.Drawing.Size(268, 17);
            this.panel116.TabIndex = 457;
            // 
            // templateName
            // 
            this.templateName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.templateName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.templateName.Location = new System.Drawing.Point(4, 2);
            this.templateName.MaxLength = 128;
            this.templateName.Name = "templateName";
            this.templateName.Size = new System.Drawing.Size(260, 14);
            this.templateName.TabIndex = 4;
            this.templateName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.templateName_KeyDown);
            // 
            // labelToolTip
            // 
            this.labelToolTip.AutoSize = true;
            this.labelToolTip.BackColor = System.Drawing.SystemColors.Info;
            this.labelToolTip.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelToolTip.Location = new System.Drawing.Point(194, 0);
            this.labelToolTip.Name = "labelToolTip";
            this.labelToolTip.Size = new System.Drawing.Size(2, 15);
            this.labelToolTip.TabIndex = 502;
            this.labelToolTip.Visible = false;
            // 
            // labelConvertor
            // 
            this.labelConvertor.AutoSize = true;
            this.labelConvertor.BackColor = System.Drawing.Color.White;
            this.labelConvertor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelConvertor.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelConvertor.Location = new System.Drawing.Point(214, 0);
            this.labelConvertor.Name = "labelConvertor";
            this.labelConvertor.Size = new System.Drawing.Size(2, 15);
            this.labelConvertor.TabIndex = 504;
            this.labelConvertor.Visible = false;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            // 
            // Levels
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoScrollMinSize = new System.Drawing.Size(1014, 723);
            this.ClientSize = new System.Drawing.Size(1014, 724);
            this.Controls.Add(this.labelConvertor);
            this.Controls.Add(this.panelLevelZoom);
            this.Controls.Add(this.labelToolTip);
            this.Controls.Add(this.panelTemplateName);
            this.Controls.Add(this.panelTileEditor);
            this.Controls.Add(this.label67);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.panelOpacity);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Location = new System.Drawing.Point(5, 5);
            this.Name = "Levels";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "LEVELS - Lazy Shell";
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Levels_MouseUp);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Levels_FormClosed);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Levels_FormClosing);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Levels_MouseMove);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Levels_KeyDown);
            panel444.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBattlefield)).EndInit();
            this.panel100.ResumeLayout(false);
            this.panel101.ResumeLayout(false);
            this.panel102.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.colEditValueA)).EndInit();
            this.tabPage8.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel85.ResumeLayout(false);
            this.panel84.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.npcXCoord)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.npcYCoord)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.npcZCoord)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.npcPropertyA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.npcPropertyB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.npcPropertyC)).EndInit();
            this.panel42.ResumeLayout(false);
            this.panel83.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.npcID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.npcMovement)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.npcSpeedPlus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.npcEventORPack)).EndInit();
            this.panel43.ResumeLayout(false);
            this.panel53.ResumeLayout(false);
            this.panel82.ResumeLayout(false);
            this.panel81.ResumeLayout(false);
            this.panel80.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.npcMapHeader)).EndInit();
            this.panel118.ResumeLayout(false);
            this.panel119.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mapNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.levelNum)).EndInit();
            this.contextMenuStrip4.ResumeLayout(false);
            this.tabPage10.ResumeLayout(false);
            this.panel99.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.overlapType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.overlapCoordX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.overlapCoordY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.overlapCoordZ)).EndInit();
            this.panel62.ResumeLayout(false);
            this.tabPage9.ResumeLayout(false);
            this.panel52.ResumeLayout(false);
            this.panel90.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.eventsFieldLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eventsFieldYCoord)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eventsFieldXCoord)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eventsFieldZCoord)).EndInit();
            this.panel46.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.eventsFieldHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eventsRunEvent)).EndInit();
            this.panel89.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.eventsExitEvent)).EndInit();
            this.panel47.ResumeLayout(false);
            this.panel88.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.exitsMarioYCoord)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exitsMarioXCoord)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exitsMarioZCoord)).EndInit();
            this.panel48.ResumeLayout(false);
            this.panel87.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.exitsFieldLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exitsFieldZCoord)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exitsFieldYCoord)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exitsFieldXCoord)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exitsFieldHeight)).EndInit();
            this.panel49.ResumeLayout(false);
            this.panel50.ResumeLayout(false);
            this.panel51.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.panel66.ResumeLayout(false);
            this.panel67.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTilesetL2)).EndInit();
            this.contextMenuStrip2.ResumeLayout(false);
            this.tabPage7.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panelPhysicalTile.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPhysicalTile)).EndInit();
            this.panel97.ResumeLayout(false);
            this.panel91.ResumeLayout(false);
            this.panel105.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.physicalTileBaseHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.physicalTileOverZCoord)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.physicalTileOverHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.physicalTileWaterZCoord)).EndInit();
            this.panel55.ResumeLayout(false);
            this.panel54.ResumeLayout(false);
            this.panel44.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.physicalTileNum)).EndInit();
            this.tabPage6.ResumeLayout(false);
            this.panel41.ResumeLayout(false);
            this.panel94.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTilesetL3)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panelColorBalance.ResumeLayout(false);
            this.colEditBFPanel.ResumeLayout(false);
            this.panel104.ResumeLayout(false);
            this.panel103.ResumeLayout(false);
            this.panelOverlapTileset.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOverlaps)).EndInit();
            this.panelChangeLevelName.ResumeLayout(false);
            this.panel98.ResumeLayout(false);
            this.panel98.PerformLayout();
            this.panelSearchLevelNames.ResumeLayout(false);
            this.panel58.ResumeLayout(false);
            this.panel58.PerformLayout();
            this.panel27.ResumeLayout(false);
            this.panelLevelPicture.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLevel)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.areaPropertiesPanel.ResumeLayout(false);
            this.Priorities.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel79.ResumeLayout(false);
            this.panel22.ResumeLayout(false);
            this.panel26.ResumeLayout(false);
            this.panel78.ResumeLayout(false);
            this.panel21.ResumeLayout(false);
            this.panel23.ResumeLayout(false);
            this.panel24.ResumeLayout(false);
            this.panel25.ResumeLayout(false);
            this.panel77.ResumeLayout(false);
            this.panel16.ResumeLayout(false);
            this.panel19.ResumeLayout(false);
            this.panel18.ResumeLayout(false);
            this.panel20.ResumeLayout(false);
            this.panel76.ResumeLayout(false);
            this.panel75.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layerL2LeftShift)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layerL2UpShift)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layerL3LeftShift)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layerL3UpShift)).EndInit();
            this.panel74.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layerMaskHighX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layerMaskLowX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layerMaskHighY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layerMaskLowY)).EndInit();
            this.panel73.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layerPrioritySet)).EndInit();
            this.panel17.ResumeLayout(false);
            this.panel14.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.panel28.ResumeLayout(false);
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
            this.panel71.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mapTilesetL3Num)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mapTilesetL2Num)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mapTilesetL1Num)).EndInit();
            this.panel32.ResumeLayout(false);
            this.panel33.ResumeLayout(false);
            this.panel34.ResumeLayout(false);
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
            ((System.ComponentModel.ISupportInitialize)(this.palettePictureBox)).EndInit();
            this.contextMenuStrip3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mapPaletteRedNum)).EndInit();
            this.panel40.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mapPaletteGreenNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mapPaletteBlueNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mapPaletteGreenBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mapPaletteSetNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mapPaletteRedBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mapPaletteBlueBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxColor)).EndInit();
            this.panelTemplates.ResumeLayout(false);
            this.panel114.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTemplate)).EndInit();
            this.panel115.ResumeLayout(false);
            this.panel115.PerformLayout();
            this.panelTemplatesSub.ResumeLayout(false);
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            this.panelTilesets.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.panel95.ResumeLayout(false);
            this.panel96.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTilesetL1)).EndInit();
            this.tabPage12.ResumeLayout(false);
            this.panelBattlefields.ResumeLayout(false);
            this.panelBattlefieldTileset.ResumeLayout(false);
            this.panelBattlefieldPalettes.ResumeLayout(false);
            this.panel93.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.battlefieldPaletteSetNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bfPaletteGreenBar)).EndInit();
            this.panel60.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bfPaletteBlueBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bfPalettePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bfPaletteRedBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bfPaletteRedNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bfPaletteBlueNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bfPaletteGreenNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxColorBF)).EndInit();
            this.panelBattlefieldProperties.ResumeLayout(false);
            this.panel92.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.battlefieldGFXSet4Num)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.battlefieldGFXSet5Num)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.battlefieldGFXSet3Num)).EndInit();
            this.panel57.ResumeLayout(false);
            this.panel56.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.battlefieldGFXSet2Num)).EndInit();
            this.panel7.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.battlefieldGFXSet1Num)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.battlefieldTilesetNum)).EndInit();
            this.panel59.ResumeLayout(false);
            this.panel45.ResumeLayout(false);
            this.panel61.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.battlefieldNum)).EndInit();
            this.panelLevelZoom.ResumeLayout(false);
            this.panel117.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLevelZoom)).EndInit();
            this.contextMenuStripTE.ResumeLayout(false);
            this.panelTileEditor.ResumeLayout(false);
            this.panel106.ResumeLayout(false);
            this.panel107.ResumeLayout(false);
            this.panelImageGraphics.ResumeLayout(false);
            this.panel108.ResumeLayout(false);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.panel109.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGraphicSet)).EndInit();
            this.panel110.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPalette)).EndInit();
            this.panel111.ResumeLayout(false);
            this.panel112.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSubtile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTile)).EndInit();
            this.panel113.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tilePalette)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tileGFXSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tile8x8Tile)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.overlayOpacity)).EndInit();
            this.panelOpacity.ResumeLayout(false);
            this.panelTemplateName.ResumeLayout(false);
            this.panel116.ResumeLayout(false);
            this.panel116.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabPage tabPage8;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.NumericUpDown mapNum;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.NumericUpDown levelNum;
        private System.Windows.Forms.ComboBox levelName;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabPage10;
        private System.Windows.Forms.TabPage tabPage9;
        private System.Windows.Forms.PictureBox pictureBoxTilesetL2;
        private System.Windows.Forms.PictureBox pictureBoxTilesetL3;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panelLevelPicture;
        private System.Windows.Forms.PictureBox pictureBoxLevel;
        private System.Windows.Forms.Panel areaPropertiesPanel;
        private System.Windows.Forms.TabControl Priorities;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label82;
        private System.Windows.Forms.Label label83;
        private System.Windows.Forms.Label label84;
        private System.Windows.Forms.Label label85;
        private System.Windows.Forms.Label label86;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.NumericUpDown layerPrioritySet;
        private System.Windows.Forms.Label label110;
        private System.Windows.Forms.CheckedListBox layerScrollWrapping;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label91;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox layerL2ScrollDirection;
        private System.Windows.Forms.NumericUpDown layerL3UpShift;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label labeasdfasd;
        private System.Windows.Forms.NumericUpDown layerL3LeftShift;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.NumericUpDown layerL2UpShift;
        private System.Windows.Forms.NumericUpDown layerMaskLowY;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.NumericUpDown layerMaskHighY;
        private System.Windows.Forms.NumericUpDown layerL2LeftShift;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.NumericUpDown layerMaskLowX;
        private System.Windows.Forms.NumericUpDown layerMaskHighX;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Label label87;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.NumericUpDown mapGFXSetL3Num;
        private System.Windows.Forms.NumericUpDown mapGFXSet5Num;
        private System.Windows.Forms.NumericUpDown mapGFXSet4Num;
        private System.Windows.Forms.NumericUpDown mapGFXSet3Num;
        private System.Windows.Forms.NumericUpDown mapGFXSet2Num;
        private System.Windows.Forms.NumericUpDown mapGFXSet1Num;
        private System.Windows.Forms.Label label114;
        private System.Windows.Forms.NumericUpDown mapBattlefieldNum;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.NumericUpDown mapPaletteSetNum;
        private System.Windows.Forms.Label label76;
        private System.Windows.Forms.Label label89;
        private System.Windows.Forms.Label label88;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.Label label81;
        private System.Windows.Forms.NumericUpDown mapPaletteBlueNum;
        private System.Windows.Forms.Label label80;
        private System.Windows.Forms.NumericUpDown mapPaletteGreenNum;
        private System.Windows.Forms.Label label79;
        private System.Windows.Forms.NumericUpDown mapPaletteRedNum;
        private System.Windows.Forms.PictureBox palettePictureBox;
        private System.Windows.Forms.NumericUpDown mapPhysicalMapNum;
        private System.Windows.Forms.ComboBox mapGFXSetL3Name;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.NumericUpDown mapTilemapL3Num;
        private System.Windows.Forms.NumericUpDown mapTilemapL2Num;
        private System.Windows.Forms.NumericUpDown mapTilemapL1Num;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.NumericUpDown mapTilesetL3Num;
        private System.Windows.Forms.NumericUpDown mapTilesetL2Num;
        private System.Windows.Forms.NumericUpDown mapTilesetL1Num;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.ComboBox mapGFXSet5Name;
        private System.Windows.Forms.ComboBox mapGFXSet4Name;
        private System.Windows.Forms.ComboBox mapGFXSet3Name;
        private System.Windows.Forms.ComboBox mapGFXSet2Name;
        private System.Windows.Forms.ComboBox mapBattlefieldName;
        private System.Windows.Forms.ComboBox mapPhysicalMapName;
        private System.Windows.Forms.ComboBox mapTilemapL3Name;
        private System.Windows.Forms.ComboBox mapTilemapL2Name;
        private System.Windows.Forms.ComboBox mapTilemapL1Name;
        private System.Windows.Forms.ComboBox mapTilesetL3Name;
        private System.Windows.Forms.ComboBox mapTilesetL2Name;
        private System.Windows.Forms.ComboBox mapTilesetL1Name;
        private System.Windows.Forms.ComboBox mapPaletteSetName;
        private System.Windows.Forms.PictureBox pictureBoxTilesetL1;
        private System.Windows.Forms.Label label53;
        private System.Windows.Forms.Label label94;
        private System.Windows.Forms.NumericUpDown physicalTileNum;
        private System.Windows.Forms.CheckedListBox physicalTilePriority3;
        private System.Windows.Forms.CheckedListBox physicalTileQuadrant;
        private System.Windows.Forms.CheckedListBox physicalTileEdges;
        private System.Windows.Forms.CheckedListBox physicalTileProperties;
        private System.Windows.Forms.NumericUpDown physicalTileWaterZCoord;
        private System.Windows.Forms.NumericUpDown physicalTileOverHeight;
        private System.Windows.Forms.NumericUpDown physicalTileOverZCoord;
        private System.Windows.Forms.NumericUpDown physicalTileBaseHeight;
        private System.Windows.Forms.ComboBox physicalTileSpecialTile;
        private System.Windows.Forms.ComboBox physicalTileStairs;
        private System.Windows.Forms.ComboBox physicalTileConveyor;
        private System.Windows.Forms.Label label92;
        private System.Windows.Forms.Label label90;
        private System.Windows.Forms.Label label75;
        private System.Windows.Forms.Label label74;
        private System.Windows.Forms.Label label72;
        private System.Windows.Forms.Label label73;
        private System.Windows.Forms.Button physicalTileSearchButton;
        private System.Windows.Forms.Label label68;
        private System.Windows.Forms.Label label93;
        private System.Windows.Forms.Label labelTileCoords;
        private System.Windows.Forms.Label labelPixelCoords;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.ComboBox layerMessageBox;
        private System.Windows.Forms.Panel panel25;
        private System.Windows.Forms.ComboBox layerL3ScrollSpeed;
        private System.Windows.Forms.Panel panel24;
        private System.Windows.Forms.ComboBox layerL3ScrollDirection;
        private System.Windows.Forms.Panel panel23;
        private System.Windows.Forms.ComboBox layerL2ScrollSpeed;
        private System.Windows.Forms.Panel panel21;
        private System.Windows.Forms.Panel panel27;
        private System.Windows.Forms.Panel panel28;
        private System.Windows.Forms.Panel panel52;
        private System.Windows.Forms.Panel panel44;
        private System.Windows.Forms.Panel panel35;
        private System.Windows.Forms.Panel panel40;
        private System.Windows.Forms.Panel panel31;
        private System.Windows.Forms.Panel panel36;
        private System.Windows.Forms.TrackBar mapPaletteGreenBar;
        private System.Windows.Forms.Panel panel37;
        private System.Windows.Forms.Panel panel38;
        private System.Windows.Forms.Panel panel29;
        private System.Windows.Forms.Panel panel39;
        private System.Windows.Forms.TrackBar mapPaletteBlueBar;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Panel panel32;
        private System.Windows.Forms.TrackBar mapPaletteRedBar;
        private System.Windows.Forms.Panel panel33;
        private System.Windows.Forms.Panel panel30;
        private System.Windows.Forms.Panel panel34;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.ComboBox mapGFXSet1Name;
        private System.Windows.Forms.Panel panel55;
        private System.Windows.Forms.Panel panel54;
        private System.Windows.Forms.Label labelOrthCoords;
        private System.Windows.Forms.TabPage tabPage12;
        private System.Windows.Forms.NumericUpDown battlefieldNum;
        private System.Windows.Forms.Panel panel60;
        private System.Windows.Forms.ComboBox battlefieldPaletteSetName;
        private System.Windows.Forms.Label label102;
        private System.Windows.Forms.NumericUpDown battlefieldPaletteSetNum;
        private System.Windows.Forms.Panel panel59;
        private System.Windows.Forms.ComboBox battlefieldTilesetName;
        private System.Windows.Forms.Label label101;
        private System.Windows.Forms.NumericUpDown battlefieldTilesetNum;
        private System.Windows.Forms.Label label69;
        private System.Windows.Forms.PictureBox pictureBoxBattlefield;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox battlefieldGFXSet4Name;
        private System.Windows.Forms.NumericUpDown battlefieldGFXSet1Num;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.ComboBox battlefieldGFXSet2Name;
        private System.Windows.Forms.Label label100;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.ComboBox battlefieldGFXSet5Name;
        private System.Windows.Forms.NumericUpDown battlefieldGFXSet2Num;
        private System.Windows.Forms.Panel panel56;
        private System.Windows.Forms.ComboBox battlefieldGFXSet3Name;
        private System.Windows.Forms.Label label99;
        private System.Windows.Forms.Panel panel57;
        private System.Windows.Forms.ComboBox battlefieldGFXSet1Name;
        private System.Windows.Forms.NumericUpDown battlefieldGFXSet3Num;
        private System.Windows.Forms.Label label98;
        private System.Windows.Forms.NumericUpDown battlefieldGFXSet5Num;
        private System.Windows.Forms.NumericUpDown battlefieldGFXSet4Num;
        private System.Windows.Forms.Label label97;
        private System.Windows.Forms.Panel panel61;
        private System.Windows.Forms.ComboBox battlefieldName;
        private System.Windows.Forms.PictureBox pictureBoxColor;
        private System.Windows.Forms.Panel panelPhysicalTile;
        private System.Windows.Forms.PictureBox pictureBoxPhysicalTile;
        private ToolStrip toolStrip1;
        private ToolStripSeparator toolStripSeparator13;
        private ToolStripButton buttonEditSelect;
        private ToolStripButton buttonEditDraw;
        private ToolStripButton buttonEditErase;
        private ToolStripSeparator toolStripSeparator10;
        private ToolStripButton buttonEditDelete;
        private ToolStripButton buttonEditCut;
        private ToolStripButton buttonEditCopy;
        private ToolStripButton buttonEditPaste;
        private ToolStripSeparator toolStripSeparator11;
        private ToolStripButton buttonEditUndo;
        private ToolStripButton buttonEditRedo;
        private ToolStripSeparator toolStripSeparator12;
        private ToolStripButton buttonTogglePhys;
        private ToolStripButton buttonToggleNPCs;
        private ToolStripButton buttonToggleExits;
        private ToolStripButton buttonToggleEvents;
        private ToolStripSeparator toolStripSeparator15;
        private ToolStripSeparator toolStripSeparator14;
        private ToolStripButton buttonToggleMask;
        private ToolStripButton buttonToggleCartGrid;
        private ToolStripButton buttonToggleOrthGrid;
        private ToolStripButton buttonToggleL1;
        private ToolStripButton buttonToggleL2;
        private ToolStripButton buttonToggleL3;
        private ToolStripButton buttonToggleBG;
        private ToolStripSeparator toolStripSeparator16;
        private ToolStripButton buttonToggleProperties;
        private ToolStripSeparator toolStripSeparator17;
        private ToolStripLabel toolStripLabel1;
        private ToolStripSeparator toolStripSeparator18;
        private ToolStripLabel toolStripLabel2;
        private ToolStripSeparator toolStripSeparator19;
        private CheckBox npcsZCoordPlusHalf;
        private CheckBox npcsShowNPC;
        private Panel panel53;
        private ComboBox npcEngageTrigger;
        private Panel panel43;
        private ComboBox npcEngageType;
        private Label label111;
        private Button openPartitions;
        private Button npcRemoveObject;
        private Button npcInsertObject;
        private Button npcInsertInstance;
        private Button npcRemoveInstance;
        private Label label112;
        private Label label70;
        private Panel panel42;
        private ComboBox npcRadialPosition;
        private Label label117;
        private Label label71;
        private Label label116;
        private NumericUpDown npcPropertyC;
        private Label label31;
        private NumericUpDown npcPropertyB;
        private Label label104;
        private NumericUpDown npcPropertyA;
        private Label label30;
        private Label label56;
        private NumericUpDown npcZCoord;
        private Label label28;
        private Label label29;
        private NumericUpDown npcYCoord;
        private NumericUpDown npcXCoord;
        private Label label54;
        private NumericUpDown npcEventORPack;
        private NumericUpDown npcSpeedPlus;
        private NumericUpDown npcMovement;
        private Label label49;
        private NumericUpDown npcID;
        private Label label115;
        private Label label113;
        private Label label48;
        private NumericUpDown npcMapHeader;
        private TreeView npcObjectTree;
        private CheckBox marioZCoordPlusHalf;
        private CheckBox eventsLengthOverOne;
        private CheckBox exitsLengthOverOne;
        private Panel panel46;
        private ComboBox eventsFieldRadialPosition;
        private Panel panel47;
        private ComboBox eventsAreaMusic;
        private Panel panel48;
        private ComboBox exitsMarioRadialPosition;
        private Panel panel49;
        private ComboBox exitsFieldRadialPosition;
        private Panel panel50;
        private ComboBox exitsType;
        private Panel panel51;
        private ComboBox exitsDestination;
        private Button eventsDeleteField;
        private Button eventsInsertField;
        private Label label63;
        private Button exitsDeleteField;
        private Button exitsInsertField;
        private NumericUpDown eventsRunEvent;
        private NumericUpDown eventsExitEvent;
        private Label label125;
        private Label label124;
        private Label label137;
        private TreeView exitsFieldTree;
        private Label label47;
        private Label label135;
        private TreeView eventsFieldTree;
        private Label label120;
        private Label label62;
        private Label label122;
        private Label label66;
        private Label label133;
        private Label label57;
        private Label label55;
        private NumericUpDown eventsFieldHeight;
        private Label label37;
        private NumericUpDown exitsFieldHeight;
        private NumericUpDown exitsFieldXCoord;
        private NumericUpDown exitsMarioZCoord;
        private NumericUpDown eventsFieldZCoord;
        private NumericUpDown exitsFieldYCoord;
        private NumericUpDown exitsFieldZCoord;
        private NumericUpDown eventsFieldXCoord;
        private Label label131;
        private NumericUpDown exitsMarioXCoord;
        private Label label105;
        private NumericUpDown eventsFieldYCoord;
        private Label label129;
        private NumericUpDown exitsFieldLength;
        private Label label60;
        private NumericUpDown exitsMarioYCoord;
        private Label label58;
        private NumericUpDown eventsFieldLength;
        private Label label59;
        private Label label127;
        private Label label119;
        private Label label61;
        private CheckBox layerLockMask;
        private CheckBox layerWaveEffect;
        private CheckBox layerInfiniteAutoscroll;
        private Panel panel26;
        private ComboBox layerOBJEffects;
        private Panel panel22;
        private ComboBox layerL3Effects;
        private Label label38;
        private Label label39;
        private Panel panel20;
        private ComboBox layerL3HSync;
        private Panel panel18;
        private ComboBox layerL2HSync;
        private Panel panel19;
        private ComboBox layerL3VSync;
        private Panel panel16;
        private ComboBox layerL2VSync;
        private Label label3;
        private Label label11;
        private Label label13;
        private Label label12;
        private Panel panel17;
        private ComboBox layerColorMathMode;
        private Panel panel14;
        private ComboBox layerColorMathIntensity;
        private Label label96;
        private Label label95;
        private Label label22;
        private CheckBox checkBox16;
        private CheckBox checkBox15;
        private CheckBox layerColorMathBG;
        private CheckBox layerColorMathNPC;
        private CheckBox layerSubscreenNPC;
        private CheckBox layerMainscreenNPC;
        private CheckBox layerColorMathL3;
        private CheckBox layerSubscreenL3;
        private CheckBox layerMainscreenL3;
        private CheckBox layerColorMathL2;
        private CheckBox layerSubscreenL2;
        private CheckBox layerMainscreenL2;
        private CheckBox layerColorMathL1;
        private CheckBox layerSubscreenL1;
        private CheckBox layerMainscreenL1;
        private CheckBox mapSetL3Priority;
        private CheckBox exits135LengthPlusHalf;
        private CheckBox exits45LengthPlusHalf;
        private CheckBox eventsWidthYPlusHalf;
        private CheckBox eventsWidthXPlusHalf;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem cutToolStripMenuItem1;
        private ToolStripMenuItem copyToolStripMenuItem1;
        private ToolStripMenuItem pasteToolStripMenuItem1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem importToolStripMenuItem;
        private ToolStripMenuItem exportToolStripMenuItem1;
        private ToolStripMenuItem exportLevelImagesToolStripMenuItem1;
        private ToolStripMenuItem clearToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem undoToolStripMenuItem;
        private ToolStripMenuItem redoToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator6;
        private ToolStripMenuItem cutToolStripMenuItem;
        private ToolStripMenuItem copyToolStripMenuItem;
        private ToolStripMenuItem pasteToolStripMenuItem;
        private ToolStripMenuItem deleteToolStripMenuItem;
        private ToolStripMenuItem viewToolStripMenuItem;
        private ToolStripMenuItem cartesianGridToolStripMenuItem;
        private ToolStripMenuItem orthographicGridToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem maskToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripMenuItem layer1ToolStripMenuItem;
        private ToolStripMenuItem layer2ToolStripMenuItem;
        private ToolStripMenuItem layer3ToolStripMenuItem;
        private ToolStripMenuItem backgroundToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripMenuItem physicalMapToolStripMenuItem;
        private ToolStripMenuItem npcsToolStripMenuItem;
        private ToolStripMenuItem exitFieldsToolStripMenuItem;
        private ToolStripMenuItem eventFieldsToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ContextMenuStrip contextMenuStrip2;
        private ToolStripMenuItem editToolStripMenuItem1;
        private ToolStripMenuItem toolStripMenuItem5;
        private ToolStripSeparator toolStripSeparator20;
        private Label label26;
        private CheckBox layerL3ScrollShift;
        private CheckBox layerL2ScrollShift;
        private CheckBox exitsShowMessage;
        private ToolStripMenuItem SpaceAnalyzerMenuItem;
        private ToolStripSeparator toolStripSeparator21;
        private Button findNPCNum;
        private Panel panel41;
        private PictureBox pictureBoxColorBF;
        private TrackBar bfPaletteGreenBar;
        private TrackBar bfPaletteBlueBar;
        private TrackBar bfPaletteRedBar;
        private Label label77;
        private NumericUpDown bfPaletteBlueNum;
        private Label label78;
        private NumericUpDown bfPaletteGreenNum;
        private Label label123;
        private NumericUpDown bfPaletteRedNum;
        private PictureBox bfPalettePictureBox;
        private Button paletteUpdate;
        private CheckBox paletteAutoUpdate;
        private ToolStripMenuItem graphicSetsToolStripMenuItem1;
        private ToolStripSeparator toolStripSeparator22;
        private ToolStripMenuItem clearSelectionToolStripMenuItem;
        private ToolStripMenuItem dumpTextToolStripMenuItem;
        private ToolStripMenuItem saveImageToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator24;
        private ToolStripButton levelPreviewToolStripButton;
        private ToolStripSeparator toolStripSeparator26;
        private ToolStripMenuItem cutToolStripMenuItem2;
        private ToolStripMenuItem copyToolStripMenuItem2;
        private ToolStripMenuItem pasteToolStripMenuItem2;
        private ToolStripMenuItem deleteToolStripMenuItem2;
        private ToolStripSeparator toolStripSeparator27;
        private ToolStripMenuItem toolStripMenuItem6;
        private TrackBar overlayOpacity;
        private Label label65;
        private Panel panel68;
        private Label label1;
        private Panel panel3;
        private Panel panel64;
        private Panel panel63;
        private Panel panel79;
        private Panel panel78;
        private Panel panel77;
        private Panel panel76;
        private Panel panel75;
        private Panel panel74;
        private Panel panel73;
        private Panel panel72;
        private Panel panel71;
        private Panel panel70;
        private Panel panel69;
        private Panel panel85;
        private Panel panel84;
        private Panel panel83;
        private Panel panel82;
        private Panel panel81;
        private Panel panel80;
        private Panel panel90;
        private Panel panel89;
        private Panel panel88;
        private Panel panel87;
        private Panel panel91;
        private Panel panel93;
        private Panel panel92;
        private BackgroundWorker ExportLevelImages;
        private Label labelOverlayOpacity;
        private ToolStripButton buttonToggleP1;
        private Label label67;
        private ToolStripButton buttonZoomIn;
        private ToolStripButton buttonZoomOut;
        private ToolStripSeparator toolStripSeparator7;
        private Panel panel94;
        private Panel panel66;
        private Panel panel67;
        private Panel panel97;
        private Panel panelTilesets;
        private Label labelTilesets;
        private Panel panel95;
        private Panel panel96;
        private Panel panelBattlefieldPalettes;
        private Panel panel45;
        private Panel panelBattlefieldProperties;
        private Label labelBattlefieldProperties;
        private Label labelBattlefieldPalettes;
        private Label labelBattlefields;
        private Label labelBattlefieldTileset;
        private Panel panelBattlefields;
        private Panel panelBattlefieldTileset;
        private ToolStripMenuItem priority1ToolStripMenuItem;
        private ToolStripMenuItem selectAllToolStripMenuItem;
        private ToolStripMenuItem deleteToolStripMenuItem1;
        private ContextMenuStrip contextMenuStrip3;
        private ToolStripMenuItem importPaletteSetToolStripMenuItem;
        private ToolStripMenuItem exportPaletteSetToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator9;
        private ToolStripMenuItem replaceTilesToolStripMenuItem;
        private ToolTip toolTip1;
        private Button searchLevelNames;
        private Panel panelSearchLevelNames;
        private ListBox listBoxLevelNames;
        private Panel panel58;
        private TextBox nameTextBox;
        private System.DirectoryServices.DirectorySearcher directorySearcher1;
        private Button changeLevelName;
        private Button defaultName;
        private Panel panel98;
        private TextBox textBox1;
        private Panel panelChangeLevelName;
        private ToolStripSeparator toolStripSeparator30;
        private ToolStripSeparator toolStripSeparator29;
        private ToolStripSeparator toolStripSeparator32;
        private Panel panel62;
        private Label label130;
        private NumericUpDown overlapType;
        private Label label103;
        private Label label106;
        private NumericUpDown overlapCoordZ;
        private NumericUpDown overlapCoordY;
        private NumericUpDown overlapCoordX;
        private Label label107;
        private TreeView overlapFieldTree;
        private Label label51;
        private Panel panel99;
        private Label label132;
        private CheckedListBox overlapUnknownBits;
        private Button overlapFieldDelete;
        private Button overlapFieldInsert;
        private ToolStripButton buttonToggleOverlaps;
        private Button colorBalance;
        private Panel panelColorBalance;
        private Button npcMoveUp;
        private Button npcMoveDown;
        private ComboBox coleditSelectCommand;
        private CheckedListBox colEditColors;
        private Panel panel100;
        private ComboBox colEditComboBoxA;
        private Panel panel101;
        private Label label139;
        private Label colEditLabelA;
        private Label colEditLabelB;
        private Label label134;
        private Panel panel102;
        private ComboBox colEditComboBoxB;
        private Label label136;
        private Button colEditSelectAll;
        private Label colEditLabelC;
        private NumericUpDown colEditValueA;
        private CheckBox colEditReds;
        private CheckBox colEditGreens;
        private CheckBox colEditBlues;
        private Label colEditLabelD;
        private CheckedListBox colEditRowSelectAll;
        private Label label143;
        private Button colEditApply;
        private Button colEditUndo;
        private Button colEditRedo;
        private Button colEditReset;
        private Button colEditSelectNone;
        private Panel panel104;
        private Panel panel103;
        private Label label138;
        private PictureBox pictureBoxOverlaps;
        private Button overlapShowTileset;
        private Panel panelOverlapTileset;
        private Label label109;
        private Panel panel105;
        private ComboBox physicalTileDoorFormat;
        private CheckedListBox physicalTileUnknownBits;
        private Label label140;
        private ToolStripSeparator toolStripSeparator28;
        private ToolStripMenuItem graphicSetsToolStripMenuItem;
        private Button buttonGotoB;
        private Button buttonGotoA;
        private ToolStripMenuItem priority1SetToolStripMenuItem;
        private ToolStripMenuItem priority1ClearToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator25;
        private Panel panelOpacity;
        private ToolStripButton opacityToolStripButton;
        private ToolStripSeparator toolStripSeparator23;
        private Panel panelTileEditor;
        private Panel panel106;
        private Panel panel107;
        private Button buttonOK;
        private Button buttonCancel;
        private Panel panelImageGraphics;
        private Panel panel108;
        private ToolStrip toolStrip2;
        private ToolStripLabel toolStripLabel3;
        private ToolStripSeparator toolStripSeparator31;
        private ToolStripButton graphicShowGrid;
        private ToolStripButton graphicShowPixelGrid;
        private ToolStripSeparator toolStripSeparator33;
        private ToolStripButton subtileDraw;
        private ToolStripButton subtileErase;
        private ToolStripButton subtileDropper;
        private ToolStripSeparator toolStripSeparator34;
        private ToolStripButton graphicZoomIn;
        private ToolStripButton graphicZoomOut;
        private Panel panel109;
        private PictureBox pictureBoxGraphicSet;
        private Label labelImageGraphics;
        private Panel panel110;
        private PictureBox pictureBoxPalette;
        private Label label50;
        private Panel panel111;
        private Label labelTileEditor;
        private CheckBox showGrid;
        private Panel panel112;
        private PictureBox pictureBoxSubtile;
        private PictureBox pictureBoxTile;
        private Panel panel113;
        private Label label141;
        private NumericUpDown tilePalette;
        private NumericUpDown tileGFXSet;
        private NumericUpDown tile8x8Tile;
        private Label label142;
        private Label label144;
        private CheckedListBox tileAttributes;
        private ContextMenuStrip contextMenuStripTE;
        private ToolStripMenuItem setSubtileToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator35;
        private ToolStripMenuItem toolStripMenuItem7;
        private ToolStripMenuItem exportToolStripMenuItem;
        private ToolStripMenuItem saveImageToolStripMenuItem1;
        private ToolStripSeparator toolStripSeparator36;
        private ToolStripMenuItem clearToolStripMenuItem1;
        private ToolStripButton buttonToggleTileEditor;
        private ToolStripSeparator toolStripSeparator37;
        private ToolStripMenuItem editAllLayersToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator41;
        private ToolStripMenuItem saveImageAsToolStripMenuItem;
        private CheckBox overlapCoordZPlusHalf;
        private Button buttonGotoD;
        private Button buttonGotoC;
        private Panel panelTemplates;
        private Label labelTemplates;
        private Panel panelTemplatesSub;
        private ToolStrip toolStrip3;
        private ToolStripSeparator toolStripSeparator45;
        private ToolStripSeparator toolStripSeparator43;
        private ToolStripButton templateTransfer;
        private ToolStripSeparator toolStripSeparator46;
        private ToolStripButton buttonEditTemplate;
        private Panel panel116;
        private Label label64;
        private Button buttonTemplateOK;
        private Button buttonTemplateCancel;
        private TextBox templateName;
        private Panel panelTemplateName;
        private ToolStripLabel toolStripLabel4;
        private ToolStripSeparator toolStripSeparator44;
        private Panel panel115;
        private TextBox templateRenameText;
        private Button templateRename;
        private ToolStripButton buttonToggleTemplates;
        private ListBox templatesLoaded;
        private Panel panel114;
        private PictureBox pictureBoxTemplate;
        private CheckedListBox npcAttributes;
        private Panel panel86;
        private Label labelToolTip;
        private ToolStripButton buttonEditDropper;
        private Panel panel117;
        private Panel panelLevelZoom;
        private PictureBox pictureBoxLevelZoom;
        private ToolStripMenuItem enableHelpTipsToolStripMenuItem;
        private ToolStripMenuItem arraysToolStripMenuItem;
        private ToolStripMenuItem arraysToolStripMenuItem1;
        private Button colEditApplyBF;
        private Button colEditResetBF;
        private Button colEditUndoBF;
        private Button colEditRedoBF;
        private Panel panel118;
        private Panel panel65;
        private Button npcCopy;
        private Button npcPaste;
        private Label labelConvertor;
        private ToolStripMenuItem showDecHexToolStripMenuItem;
        private Label label52;
        private Panel panel119;
        private ComboBox npcAfterBattle;
        private ToolStripSeparator toolStripSeparator8;
        private ToolStripMenuItem clearLevelDataAll;
        private ToolStripMenuItem clearTilesetsAll;
        private ToolStripMenuItem clearTilemapsAll;
        private ToolStripMenuItem clearPhysicalMapsAll;
        private ToolStripMenuItem clearBattlefieldsAll;
        private ToolStripMenuItem unusedToolStripMenuItem;
        private ToolStripMenuItem unusedToolStripMenuItem1;
        private ToolStripMenuItem unusedToolStripMenuItem2;
        private ToolStripMenuItem unusedToolStripMenuItem3;
        private ToolStripMenuItem clearAllComponentsAll;
        private ToolStripMenuItem clearAllComponentsCurrent;
        private ToolStripSeparator toolStripSeparator38;
        private ToolStripMenuItem allToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem1;
        private Panel panel8;
        private ContextMenuStrip contextMenuStrip4;
        private ToolStripMenuItem addThisLevelToNotesDatabaseToolStripMenuItem;
        private BackgroundWorker backgroundWorker1;
        private ToolStripMenuItem applyBorderToolStripMenuItem;
        private Panel colEditBFPanel;
        private Button colorBalanceBF;
    }
}

