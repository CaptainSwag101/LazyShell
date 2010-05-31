using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LAZYSHELL
{
    partial class Sprites
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
            System.Windows.Forms.Panel panel72;
            System.Windows.Forms.Label label62;
            System.Windows.Forms.Label label75;
            System.Windows.Forms.Panel panel2;
            System.Windows.Forms.Label label27;
            System.Windows.Forms.Label label74;
            System.Windows.Forms.Label label53;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Sprites));
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.fontBold = new System.Windows.Forms.ToolStripButton();
            this.fontItalics = new System.Windows.Forms.ToolStripButton();
            this.fontUnderline = new System.Windows.Forms.ToolStripButton();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.fontShowGrid = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator24 = new System.Windows.Forms.ToolStripSeparator();
            this.fontEditZoomIn = new System.Windows.Forms.ToolStripButton();
            this.fontEditZoomOut = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator25 = new System.Windows.Forms.ToolStripSeparator();
            this.fontEditDraw = new System.Windows.Forms.ToolStripButton();
            this.fontEditErase = new System.Windows.Forms.ToolStripButton();
            this.fontEditChoose = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator26 = new System.Windows.Forms.ToolStripSeparator();
            this.fontEditDelete = new System.Windows.Forms.ToolStripButton();
            this.fontEditCopy = new System.Windows.Forms.ToolStripButton();
            this.fontEditPaste = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator27 = new System.Windows.Forms.ToolStripSeparator();
            this.fontEditMirror = new System.Windows.Forms.ToolStripButton();
            this.fontEditInvert = new System.Windows.Forms.ToolStripButton();
            this.panelInsertTile = new System.Windows.Forms.Panel();
            this.label68 = new System.Windows.Forms.Label();
            this.panel116 = new System.Windows.Forms.Panel();
            this.insertTileType = new System.Windows.Forms.ComboBox();
            this.insertTileHeight = new System.Windows.Forms.NumericUpDown();
            this.insertTileWidth = new System.Windows.Forms.NumericUpDown();
            this.insertTileAmount = new System.Windows.Forms.NumericUpDown();
            this.label117 = new System.Windows.Forms.Label();
            this.label115 = new System.Windows.Forms.Label();
            this.label87 = new System.Windows.Forms.Label();
            this.panel117 = new System.Windows.Forms.Panel();
            this.comboBox5 = new System.Windows.Forms.ComboBox();
            this.insertTileCancel = new System.Windows.Forms.Button();
            this.label110 = new System.Windows.Forms.Label();
            this.insertTileOK = new System.Windows.Forms.Button();
            this.contextMenuStripCH = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiZoomInCH = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiZoomOutCH = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiCutCH = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCopyCH = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPasteCH = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDeleteCH = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripGR = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.setAsSubtileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveImageToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.clearToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.applyBorderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.contextMenuStripSI = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.saveImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PlaybackSequence = new System.ComponentModel.BackgroundWorker();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allPaletteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.animationsallToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allEffectsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dialoguesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allMapsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allMapPointsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enableHelpTipsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.allAnimationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allEffectAnimationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allDialoguesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.allEffectAnimationsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.allDialoguesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showDecHexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panelDialogues = new System.Windows.Forms.Panel();
            this.characterNumLabel = new System.Windows.Forms.Label();
            this.panelSearchDialogue = new System.Windows.Forms.Panel();
            this.panel82 = new System.Windows.Forms.Panel();
            this.labelSearchDialogue = new System.Windows.Forms.Label();
            this.panel76 = new System.Windows.Forms.Panel();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.panel77 = new System.Windows.Forms.Panel();
            this.searchResults = new System.Windows.Forms.RichTextBox();
            this.panel65 = new System.Windows.Forms.Panel();
            this.panel66 = new System.Windows.Forms.Panel();
            this.panel47 = new System.Windows.Forms.Panel();
            this.label76 = new System.Windows.Forms.Label();
            this.padding = new System.Windows.Forms.NumericUpDown();
            this.autoSetWidths = new System.Windows.Forms.CheckBox();
            this.panel13 = new System.Windows.Forms.Panel();
            this.label28 = new System.Windows.Forms.Label();
            this.fontSize = new System.Windows.Forms.NumericUpDown();
            this.panel70 = new System.Windows.Forms.Panel();
            this.fontFamily = new System.Windows.Forms.ComboBox();
            this.panel32 = new System.Windows.Forms.Panel();
            this.label61 = new System.Windows.Forms.Label();
            this.characterHeight = new System.Windows.Forms.NumericUpDown();
            this.shiftTableLeft = new System.Windows.Forms.Button();
            this.shiftTableRight = new System.Windows.Forms.Button();
            this.shiftTableDown = new System.Windows.Forms.Button();
            this.resetTable = new System.Windows.Forms.Button();
            this.shiftTableUp = new System.Windows.Forms.Button();
            this.generateFontTableImage = new System.Windows.Forms.Button();
            this.panel73 = new System.Windows.Forms.Panel();
            this.panel71 = new System.Windows.Forms.Panel();
            this.fontTable = new System.Windows.Forms.Panel();
            this.label60 = new System.Windows.Forms.Label();
            this.panel203 = new System.Windows.Forms.Panel();
            this.label119 = new System.Windows.Forms.Label();
            this.dialogueNum = new System.Windows.Forms.NumericUpDown();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addThisToNotesDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel202 = new System.Windows.Forms.Panel();
            this.panel60 = new System.Windows.Forms.Panel();
            this.byteOrTextView = new System.Windows.Forms.CheckBox();
            this.panel69 = new System.Windows.Forms.Panel();
            this.pictureBoxDialogue = new System.Windows.Forms.PictureBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.dialoguePreviewPageDown = new System.Windows.Forms.Button();
            this.label196 = new System.Windows.Forms.Label();
            this.dialoguePreviewPageUp = new System.Windows.Forms.Button();
            this.panel61 = new System.Windows.Forms.Panel();
            this.dialogueTextBox = new System.Windows.Forms.RichTextBox();
            this.panelDialogueInsert = new System.Windows.Forms.Panel();
            this.panelDialogueMemory = new System.Windows.Forms.Panel();
            this.dialogueMemory = new System.Windows.Forms.ComboBox();
            this.buttonInsertVAR = new System.Windows.Forms.Button();
            this.buttonInsertFD = new System.Windows.Forms.Button();
            this.dialogueByteValue = new System.Windows.Forms.NumericUpDown();
            this.label118 = new System.Windows.Forms.Label();
            this.labelDialogueInsert = new System.Windows.Forms.Label();
            this.panel201 = new System.Windows.Forms.Panel();
            this.panel62 = new System.Windows.Forms.Panel();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.pictureBoxBattleDialogue = new System.Windows.Forms.PictureBox();
            this.battleDialoguePageUp = new System.Windows.Forms.Button();
            this.panel63 = new System.Windows.Forms.Panel();
            this.battleDialogueTextBox = new System.Windows.Forms.RichTextBox();
            this.label187 = new System.Windows.Forms.Label();
            this.battleDialoguePageDown = new System.Windows.Forms.Button();
            this.panel200 = new System.Windows.Forms.Panel();
            this.panel113 = new System.Windows.Forms.Panel();
            this.battleDlgType = new System.Windows.Forms.ComboBox();
            this.panel126 = new System.Windows.Forms.Panel();
            this.battleDialogueName = new System.Windows.Forms.ComboBox();
            this.battleDialogueNum = new System.Windows.Forms.NumericUpDown();
            this.panel59 = new System.Windows.Forms.Panel();
            this.panel58 = new System.Windows.Forms.Panel();
            this.panel12 = new System.Windows.Forms.Panel();
            this.panel24 = new System.Windows.Forms.Panel();
            this.pictureBoxDialogueTile = new System.Windows.Forms.PictureBox();
            this.dialogueSubtile = new System.Windows.Forms.NumericUpDown();
            this.panel22 = new System.Windows.Forms.Panel();
            this.dialogueProperties = new System.Windows.Forms.CheckedListBox();
            this.pictureBoxDialogueSubtile = new System.Windows.Forms.PictureBox();
            this.label25 = new System.Windows.Forms.Label();
            this.pictureBoxDialogueBG = new System.Windows.Forms.PictureBox();
            this.pictureBoxBattle = new System.Windows.Forms.PictureBox();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel30 = new System.Windows.Forms.Panel();
            this.panel114 = new System.Windows.Forms.Panel();
            this.toolStrip7 = new System.Windows.Forms.ToolStrip();
            this.openKeystrokes = new System.Windows.Forms.ToolStripButton();
            this.saveKeystrokes = new System.Windows.Forms.ToolStripButton();
            this.panel112 = new System.Windows.Forms.Panel();
            this.charKeystroke = new System.Windows.Forms.TextBox();
            this.label34 = new System.Windows.Forms.Label();
            this.pictureBoxFont = new System.Windows.Forms.PictureBox();
            this.panel25 = new System.Windows.Forms.Panel();
            this.pictureBoxFontEditor = new System.Windows.Forms.PictureBox();
            this.label33 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.panel15 = new System.Windows.Forms.Panel();
            this.fontType = new System.Windows.Forms.ComboBox();
            this.fontWidth = new System.Windows.Forms.NumericUpDown();
            this.panel46 = new System.Windows.Forms.Panel();
            this.panel23 = new System.Windows.Forms.Panel();
            this.label35 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.pictureBoxFontPalette = new System.Windows.Forms.PictureBox();
            this.fontPaletteRedBar = new System.Windows.Forms.TrackBar();
            this.label32 = new System.Windows.Forms.Label();
            this.fontPaletteGreenNum = new System.Windows.Forms.NumericUpDown();
            this.label31 = new System.Windows.Forms.Label();
            this.fontPaletteBlueBar = new System.Windows.Forms.TrackBar();
            this.fontPaletteRedNum = new System.Windows.Forms.NumericUpDown();
            this.fontPaletteBlueNum = new System.Windows.Forms.NumericUpDown();
            this.label29 = new System.Windows.Forms.Label();
            this.fontPaletteGreenBar = new System.Windows.Forms.TrackBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.fontPalette = new System.Windows.Forms.ComboBox();
            this.panelColorBalance = new System.Windows.Forms.Panel();
            this.colEditApply = new System.Windows.Forms.Button();
            this.colEditReset = new System.Windows.Forms.Button();
            this.colEditRedo = new System.Windows.Forms.Button();
            this.colEditUndo = new System.Windows.Forms.Button();
            this.panel36 = new System.Windows.Forms.Panel();
            this.label134 = new System.Windows.Forms.Label();
            this.colEditLabelA = new System.Windows.Forms.Label();
            this.colEditLabelB = new System.Windows.Forms.Label();
            this.panel108 = new System.Windows.Forms.Panel();
            this.colEditComboBoxA = new System.Windows.Forms.ComboBox();
            this.panel109 = new System.Windows.Forms.Panel();
            this.colEditComboBoxB = new System.Windows.Forms.ComboBox();
            this.colEditBlues = new System.Windows.Forms.CheckBox();
            this.colEditLabelC = new System.Windows.Forms.Label();
            this.colEditGreens = new System.Windows.Forms.CheckBox();
            this.colEditLabelD = new System.Windows.Forms.Label();
            this.colEditReds = new System.Windows.Forms.CheckBox();
            this.colEditValueA = new System.Windows.Forms.NumericUpDown();
            this.panel110 = new System.Windows.Forms.Panel();
            this.label136 = new System.Windows.Forms.Label();
            this.colEditColors = new System.Windows.Forms.CheckedListBox();
            this.colEditRowSelectAll = new System.Windows.Forms.CheckedListBox();
            this.colEditSelectAll = new System.Windows.Forms.Button();
            this.label138 = new System.Windows.Forms.Label();
            this.label143 = new System.Windows.Forms.Label();
            this.colEditSelectNone = new System.Windows.Forms.Button();
            this.panel111 = new System.Windows.Forms.Panel();
            this.coleditSelectCommand = new System.Windows.Forms.ComboBox();
            this.label139 = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panelSprites = new System.Windows.Forms.Panel();
            this.labelTileOffset = new System.Windows.Forms.Label();
            this.panelMoldImage = new System.Windows.Forms.Panel();
            this.moldCoordLabel = new System.Windows.Forms.Label();
            this.labelMoldImage = new System.Windows.Forms.Label();
            this.panel84 = new System.Windows.Forms.Panel();
            this.toolStrip4 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
            this.showMoldPixelGrid = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator14 = new System.Windows.Forms.ToolStripSeparator();
            this.moldZoomIn = new System.Windows.Forms.ToolStripButton();
            this.moldZoomOut = new System.Windows.Forms.ToolStripButton();
            this.panel52 = new System.Windows.Forms.Panel();
            this.pictureBoxMold = new System.Windows.Forms.PictureBox();
            this.panel54 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.colorBalance = new System.Windows.Forms.Button();
            this.label88 = new System.Windows.Forms.Label();
            this.mapPaletteBlueBar = new System.Windows.Forms.TrackBar();
            this.pictureBoxColor = new System.Windows.Forms.PictureBox();
            this.pictureBoxPalette = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip3 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.importPaletteSetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportPaletteSetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label80 = new System.Windows.Forms.Label();
            this.mapPaletteBlueNum = new System.Windows.Forms.NumericUpDown();
            this.mapPaletteColor = new System.Windows.Forms.NumericUpDown();
            this.mapPaletteRedNum = new System.Windows.Forms.NumericUpDown();
            this.mapPaletteGreenBar = new System.Windows.Forms.TrackBar();
            this.label17 = new System.Windows.Forms.Label();
            this.label79 = new System.Windows.Forms.Label();
            this.mapPaletteGreenNum = new System.Windows.Forms.NumericUpDown();
            this.label81 = new System.Windows.Forms.Label();
            this.mapPaletteRedBar = new System.Windows.Forms.TrackBar();
            this.label23 = new System.Windows.Forms.Label();
            this.paletteOffset = new System.Windows.Forms.NumericUpDown();
            this.panel43 = new System.Windows.Forms.Panel();
            this.label72 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.animationVRAM = new System.Windows.Forms.NumericUpDown();
            this.panel8 = new System.Windows.Forms.Panel();
            this.sequences = new System.Windows.Forms.ListBox();
            this.insertSequence = new System.Windows.Forms.Button();
            this.deleteSequence = new System.Windows.Forms.Button();
            this.label22 = new System.Windows.Forms.Label();
            this.buttonPlay = new System.Windows.Forms.Button();
            this.animationPacket = new System.Windows.Forms.NumericUpDown();
            this.buttonStop = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.buttonBack = new System.Windows.Forms.Button();
            this.panel29 = new System.Windows.Forms.Panel();
            this.sequenceFrames = new System.Windows.Forms.ListBox();
            this.label8 = new System.Windows.Forms.Label();
            this.frameMold = new System.Windows.Forms.NumericUpDown();
            this.frameDuration = new System.Windows.Forms.NumericUpDown();
            this.label16 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.frameMoveDown = new System.Windows.Forms.Button();
            this.insertFrame = new System.Windows.Forms.Button();
            this.deleteFrame = new System.Windows.Forms.Button();
            this.frameMoveUp = new System.Windows.Forms.Button();
            this.buttonFoward = new System.Windows.Forms.Button();
            this.animationAvailableBytes = new System.Windows.Forms.Label();
            this.pictureBoxSequence = new System.Windows.Forms.PictureBox();
            this.panel42 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.molds = new System.Windows.Forms.ListBox();
            this.label24 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.moldFormat = new System.Windows.Forms.ComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.deleteMold = new System.Windows.Forms.Button();
            this.insertMold = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.panel56 = new System.Windows.Forms.Panel();
            this.panel38 = new System.Windows.Forms.Panel();
            this.panel33 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.moldTileProperties = new System.Windows.Forms.CheckedListBox();
            this.label19 = new System.Windows.Forms.Label();
            this.panel11 = new System.Windows.Forms.Panel();
            this.moldTileSize = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label70 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.quadrantNW = new System.Windows.Forms.CheckBox();
            this.moldTileCopies = new System.Windows.Forms.NumericUpDown();
            this.moldSubtile = new System.Windows.Forms.NumericUpDown();
            this.moldTileYCoord = new System.Windows.Forms.NumericUpDown();
            this.quadrantSW = new System.Windows.Forms.CheckBox();
            this.moldTileCopiesOffset = new System.Windows.Forms.NumericUpDown();
            this.pictureBoxMoldSubtile = new System.Windows.Forms.PictureBox();
            this.panel10 = new System.Windows.Forms.Panel();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.quadrantNE = new System.Windows.Forms.CheckBox();
            this.moldTileXCoord = new System.Windows.Forms.NumericUpDown();
            this.pictureBoxMoldTile = new System.Windows.Forms.PictureBox();
            this.quadrantSE = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBoxMoldTileset = new System.Windows.Forms.PictureBox();
            this.deleteTile = new System.Windows.Forms.Button();
            this.insertTile = new System.Windows.Forms.Button();
            this.panel45 = new System.Windows.Forms.Panel();
            this.searchSpriteNames = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.spriteName = new System.Windows.Forms.ComboBox();
            this.spriteNum = new System.Windows.Forms.NumericUpDown();
            this.graphicPalettePacket = new System.Windows.Forms.NumericUpDown();
            this.graphicPalettePacketShift = new System.Windows.Forms.NumericUpDown();
            this.label71 = new System.Windows.Forms.Label();
            this.label73 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panelImageGraphics = new System.Windows.Forms.Panel();
            this.panelImageGraphicsSub = new System.Windows.Forms.Panel();
            this.coordsLabel = new System.Windows.Forms.Label();
            this.panel31 = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.graphicShowGrid = new System.Windows.Forms.ToolStripButton();
            this.graphicShowPixelGrid = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.subtileDraw = new System.Windows.Forms.ToolStripButton();
            this.subtileErase = new System.Windows.Forms.ToolStripButton();
            this.subtileDropper = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.graphicZoomIn = new System.Windows.Forms.ToolStripButton();
            this.graphicZoomOut = new System.Windows.Forms.ToolStripButton();
            this.labelImageGraphics = new System.Windows.Forms.Label();
            this.graphicOffset = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.panel37 = new System.Windows.Forms.Panel();
            this.pictureBoxGraphics = new System.Windows.Forms.PictureBox();
            this.panelSearchSpriteNames = new System.Windows.Forms.Panel();
            this.listBoxSpriteNames = new System.Windows.Forms.ListBox();
            this.panel28 = new System.Windows.Forms.Panel();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.panelEffects = new System.Windows.Forms.Panel();
            this.panel106 = new System.Windows.Forms.Panel();
            this.searchEffectNames = new System.Windows.Forms.Button();
            this.e_availableBytes = new System.Windows.Forms.Label();
            this.label57 = new System.Windows.Forms.Label();
            this.panel44 = new System.Windows.Forms.Panel();
            this.effectName = new System.Windows.Forms.ComboBox();
            this.effectNum = new System.Windows.Forms.NumericUpDown();
            this.panel103 = new System.Windows.Forms.Panel();
            this.label108 = new System.Windows.Forms.Label();
            this.e_playSequence = new System.Windows.Forms.Button();
            this.e_pauseSequence = new System.Windows.Forms.Button();
            this.label111 = new System.Windows.Forms.Label();
            this.e_moveBack = new System.Windows.Forms.Button();
            this.panel107 = new System.Windows.Forms.Panel();
            this.e_frames = new System.Windows.Forms.ListBox();
            this.label112 = new System.Windows.Forms.Label();
            this.e_frameMold = new System.Windows.Forms.NumericUpDown();
            this.e_duration = new System.Windows.Forms.NumericUpDown();
            this.label113 = new System.Windows.Forms.Label();
            this.label114 = new System.Windows.Forms.Label();
            this.e_moveFrameDown = new System.Windows.Forms.Button();
            this.e_insertFrame = new System.Windows.Forms.Button();
            this.e_deleteFrame = new System.Windows.Forms.Button();
            this.e_moveFrameUp = new System.Windows.Forms.Button();
            this.e_moveFoward = new System.Windows.Forms.Button();
            this.pictureBoxE_Sequence = new System.Windows.Forms.PictureBox();
            this.panel105 = new System.Windows.Forms.Panel();
            this.panel102 = new System.Windows.Forms.Panel();
            this.label100 = new System.Windows.Forms.Label();
            this.pictureBoxE_Subtile = new System.Windows.Forms.PictureBox();
            this.pictureBoxE_Tile = new System.Windows.Forms.PictureBox();
            this.panel104 = new System.Windows.Forms.Panel();
            this.panel96 = new System.Windows.Forms.Panel();
            this.e_tileSubtile = new System.Windows.Forms.NumericUpDown();
            this.label99 = new System.Windows.Forms.Label();
            this.label97 = new System.Windows.Forms.Label();
            this.pictureBoxEffectTileset = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.setMoldTileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator29 = new System.Windows.Forms.ToolStripSeparator();
            this.importImageAsTilesetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label86 = new System.Windows.Forms.Label();
            this.e_tileSetSize = new System.Windows.Forms.NumericUpDown();
            this.panel99 = new System.Windows.Forms.Panel();
            this.label103 = new System.Windows.Forms.Label();
            this.label104 = new System.Windows.Forms.Label();
            this.panel100 = new System.Windows.Forms.Panel();
            this.toolStrip6 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator20 = new System.Windows.Forms.ToolStripSeparator();
            this.e_moldShowGrid = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator21 = new System.Windows.Forms.ToolStripSeparator();
            this.e_moldZoomIn = new System.Windows.Forms.ToolStripButton();
            this.e_moldZoomOut = new System.Windows.Forms.ToolStripButton();
            this.panel101 = new System.Windows.Forms.Panel();
            this.pictureBoxE_Mold = new System.Windows.Forms.PictureBox();
            this.panel90 = new System.Windows.Forms.Panel();
            this.panel91 = new System.Windows.Forms.Panel();
            this.label91 = new System.Windows.Forms.Label();
            this.e_molds = new System.Windows.Forms.ListBox();
            this.e_deleteMold = new System.Windows.Forms.Button();
            this.e_insertMold = new System.Windows.Forms.Button();
            this.label93 = new System.Windows.Forms.Label();
            this.panel94 = new System.Windows.Forms.Panel();
            this.e_moveTileDown = new System.Windows.Forms.Button();
            this.e_moveTileUp = new System.Windows.Forms.Button();
            this.e_tiles = new System.Windows.Forms.ListBox();
            this.contextMenuStripMD = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.insertTilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearAllTilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel95 = new System.Windows.Forms.Panel();
            this.moldTileEmpty = new System.Windows.Forms.CheckBox();
            this.moldTileProp = new System.Windows.Forms.CheckedListBox();
            this.label101 = new System.Windows.Forms.Label();
            this.panel92 = new System.Windows.Forms.Panel();
            this.moldTileFormat = new System.Windows.Forms.ComboBox();
            this.moldFillAmount = new System.Windows.Forms.NumericUpDown();
            this.moldTileIndex = new System.Windows.Forms.NumericUpDown();
            this.label106 = new System.Windows.Forms.Label();
            this.label94 = new System.Windows.Forms.Label();
            this.panel93 = new System.Windows.Forms.Panel();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.label92 = new System.Windows.Forms.Label();
            this.label102 = new System.Windows.Forms.Label();
            this.moldDeleteTile = new System.Windows.Forms.Button();
            this.moldInsertTile = new System.Windows.Forms.Button();
            this.label105 = new System.Windows.Forms.Label();
            this.e_moldHeight = new System.Windows.Forms.NumericUpDown();
            this.label95 = new System.Windows.Forms.Label();
            this.e_moldWidth = new System.Windows.Forms.NumericUpDown();
            this.panelEffectGraphics = new System.Windows.Forms.Panel();
            this.panel87 = new System.Windows.Forms.Panel();
            this.panel97 = new System.Windows.Forms.Panel();
            this.e_codec = new System.Windows.Forms.ComboBox();
            this.panel98 = new System.Windows.Forms.Panel();
            this.comboBox6 = new System.Windows.Forms.ComboBox();
            this.e_coordsLabel = new System.Windows.Forms.Label();
            this.panel88 = new System.Windows.Forms.Panel();
            this.toolStrip5 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator17 = new System.Windows.Forms.ToolStripSeparator();
            this.e_graphicShowGrid = new System.Windows.Forms.ToolStripButton();
            this.e_graphicShowPixelGrid = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator18 = new System.Windows.Forms.ToolStripSeparator();
            this.e_subtileDraw = new System.Windows.Forms.ToolStripButton();
            this.e_subtileErase = new System.Windows.Forms.ToolStripButton();
            this.e_subtileDropper = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator19 = new System.Windows.Forms.ToolStripSeparator();
            this.e_graphicZoomIn = new System.Windows.Forms.ToolStripButton();
            this.e_graphicZoomOut = new System.Windows.Forms.ToolStripButton();
            this.labelEffectGraphics = new System.Windows.Forms.Label();
            this.e_graphicSetSize = new System.Windows.Forms.NumericUpDown();
            this.label90 = new System.Windows.Forms.Label();
            this.label89 = new System.Windows.Forms.Label();
            this.panel89 = new System.Windows.Forms.Panel();
            this.pictureBoxE_Graphics = new System.Windows.Forms.PictureBox();
            this.panel80 = new System.Windows.Forms.Panel();
            this.panel85 = new System.Windows.Forms.Panel();
            this.label63 = new System.Windows.Forms.Label();
            this.e_paletteBlueBar = new System.Windows.Forms.TrackBar();
            this.label109 = new System.Windows.Forms.Label();
            this.pictureBoxE_Color = new System.Windows.Forms.PictureBox();
            this.pictureBoxE_Palette = new System.Windows.Forms.PictureBox();
            this.label82 = new System.Windows.Forms.Label();
            this.e_paletteSetSize = new System.Windows.Forms.NumericUpDown();
            this.e_paletteBlueNum = new System.Windows.Forms.NumericUpDown();
            this.e_paletteColor = new System.Windows.Forms.NumericUpDown();
            this.label107 = new System.Windows.Forms.Label();
            this.e_paletteRedNum = new System.Windows.Forms.NumericUpDown();
            this.e_paletteGreenBar = new System.Windows.Forms.TrackBar();
            this.label83 = new System.Windows.Forms.Label();
            this.label84 = new System.Windows.Forms.Label();
            this.e_paletteGreenNum = new System.Windows.Forms.NumericUpDown();
            this.label85 = new System.Windows.Forms.Label();
            this.e_paletteRedBar = new System.Windows.Forms.TrackBar();
            this.panel41 = new System.Windows.Forms.Panel();
            this.e_ColorBalance = new System.Windows.Forms.Button();
            this.label116 = new System.Windows.Forms.Label();
            this.label98 = new System.Windows.Forms.Label();
            this.yNegShift = new System.Windows.Forms.NumericUpDown();
            this.label96 = new System.Windows.Forms.Label();
            this.xNegShift = new System.Windows.Forms.NumericUpDown();
            this.e_animation = new System.Windows.Forms.NumericUpDown();
            this.e_paletteIndex = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panelSearchEffectNames = new System.Windows.Forms.Panel();
            this.listBoxEffectNames = new System.Windows.Forms.ListBox();
            this.panel86 = new System.Windows.Forms.Panel();
            this.nameTextBoxEffects = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.panel57 = new System.Windows.Forms.Panel();
            this.panel79 = new System.Windows.Forms.Panel();
            this.panel35 = new System.Windows.Forms.Panel();
            this.enableNorthPath = new System.Windows.Forms.CheckBox();
            this.enableWestPath = new System.Windows.Forms.CheckBox();
            this.enableSouthPath = new System.Windows.Forms.CheckBox();
            this.enableEastPath = new System.Windows.Forms.CheckBox();
            this.label54 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label51 = new System.Windows.Forms.Label();
            this.toSouthCheckAddress = new System.Windows.Forms.NumericUpDown();
            this.toWestCheckAddress = new System.Windows.Forms.NumericUpDown();
            this.toNorthCheckAddress = new System.Windows.Forms.NumericUpDown();
            this.toEastCheckAddress = new System.Windows.Forms.NumericUpDown();
            this.panel18 = new System.Windows.Forms.Panel();
            this.toEastPoint = new System.Windows.Forms.ComboBox();
            this.toEastCheckBit = new System.Windows.Forms.NumericUpDown();
            this.panel20 = new System.Windows.Forms.Panel();
            this.toWestPoint = new System.Windows.Forms.ComboBox();
            this.toWestCheckBit = new System.Windows.Forms.NumericUpDown();
            this.panel19 = new System.Windows.Forms.Panel();
            this.toSouthPoint = new System.Windows.Forms.ComboBox();
            this.toSouthCheckBit = new System.Windows.Forms.NumericUpDown();
            this.toNorthCheckBit = new System.Windows.Forms.NumericUpDown();
            this.panel21 = new System.Windows.Forms.Panel();
            this.toNorthPoint = new System.Windows.Forms.ComboBox();
            this.panel78 = new System.Windows.Forms.Panel();
            this.panel34 = new System.Windows.Forms.Panel();
            this.label37 = new System.Windows.Forms.Label();
            this.leadToMapPoint = new System.Windows.Forms.CheckBox();
            this.label55 = new System.Windows.Forms.Label();
            this.label56 = new System.Windows.Forms.Label();
            this.whichPointCheckAddress = new System.Windows.Forms.NumericUpDown();
            this.whichPointCheckBit = new System.Windows.Forms.NumericUpDown();
            this.label52 = new System.Windows.Forms.Label();
            this.panel17 = new System.Windows.Forms.Panel();
            this.runEventEdit = new System.Windows.Forms.Button();
            this.runEvent = new System.Windows.Forms.NumericUpDown();
            this.goMapPointA = new System.Windows.Forms.ComboBox();
            this.panel27 = new System.Windows.Forms.Panel();
            this.goMapPointB = new System.Windows.Forms.ComboBox();
            this.panel48 = new System.Windows.Forms.Panel();
            this.label39 = new System.Windows.Forms.Label();
            this.panel26 = new System.Windows.Forms.Panel();
            this.showMapPoints = new System.Windows.Forms.CheckBox();
            this.panel40 = new System.Windows.Forms.Panel();
            this.pictureBoxWorldMap = new System.Windows.Forms.PictureBox();
            this.label40 = new System.Windows.Forms.Label();
            this.worldMapNum = new System.Windows.Forms.NumericUpDown();
            this.worldMapYCoord = new System.Windows.Forms.NumericUpDown();
            this.worldMapTileset = new System.Windows.Forms.NumericUpDown();
            this.worldMapXCoord = new System.Windows.Forms.NumericUpDown();
            this.pointCount = new System.Windows.Forms.NumericUpDown();
            this.label47 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label46 = new System.Windows.Forms.Label();
            this.panel214 = new System.Windows.Forms.Panel();
            this.panel215 = new System.Windows.Forms.Panel();
            this.panel51 = new System.Windows.Forms.Panel();
            this.label36 = new System.Windows.Forms.Label();
            this.panel50 = new System.Windows.Forms.Panel();
            this.label66 = new System.Windows.Forms.Label();
            this.wmPaletteRedBar = new System.Windows.Forms.TrackBar();
            this.wmPaletteGreenNum = new System.Windows.Forms.NumericUpDown();
            this.label65 = new System.Windows.Forms.Label();
            this.wmPaletteBlueBar = new System.Windows.Forms.TrackBar();
            this.label64 = new System.Windows.Forms.Label();
            this.pictureBoxWMPaletteColor = new System.Windows.Forms.PictureBox();
            this.wmPaletteGreenBar = new System.Windows.Forms.TrackBar();
            this.pictureBoxWMPalette = new System.Windows.Forms.PictureBox();
            this.wmPaletteRedNum = new System.Windows.Forms.NumericUpDown();
            this.label38 = new System.Windows.Forms.Label();
            this.wmPaletteColor = new System.Windows.Forms.NumericUpDown();
            this.wmPaletteBlueNum = new System.Windows.Forms.NumericUpDown();
            this.panel49 = new System.Windows.Forms.Panel();
            this.label43 = new System.Windows.Forms.Label();
            this.panel14 = new System.Windows.Forms.Panel();
            this.panel81 = new System.Windows.Forms.Panel();
            this.label50 = new System.Windows.Forms.Label();
            this.label49 = new System.Windows.Forms.Label();
            this.label59 = new System.Windows.Forms.Label();
            this.showCheckAddress = new System.Windows.Forms.NumericUpDown();
            this.label58 = new System.Windows.Forms.Label();
            this.showCheckBit = new System.Windows.Forms.NumericUpDown();
            this.panel64 = new System.Windows.Forms.Panel();
            this.textBoxMapPoint = new System.Windows.Forms.TextBox();
            this.mapPointYCoord = new System.Windows.Forms.NumericUpDown();
            this.LabelMonsterName = new System.Windows.Forms.Label();
            this.label48 = new System.Windows.Forms.Label();
            this.panel16 = new System.Windows.Forms.Panel();
            this.mapPointName = new System.Windows.Forms.ComboBox();
            this.label45 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.mapPointNum = new System.Windows.Forms.NumericUpDown();
            this.mapPointXCoord = new System.Windows.Forms.NumericUpDown();
            this.panel53 = new System.Windows.Forms.Panel();
            this.panel39 = new System.Windows.Forms.Panel();
            this.wmShowGrid = new System.Windows.Forms.CheckBox();
            this.label78 = new System.Windows.Forms.Label();
            this.pictureBoxSubtile = new System.Windows.Forms.PictureBox();
            this.wmSubtilePalette = new System.Windows.Forms.NumericUpDown();
            this.pictureBoxWMGraphics = new System.Windows.Forms.PictureBox();
            this.wmGraphicSet = new System.Windows.Forms.NumericUpDown();
            this.wmSubtile = new System.Windows.Forms.NumericUpDown();
            this.wmSubtileProperties = new System.Windows.Forms.CheckedListBox();
            this.label77 = new System.Windows.Forms.Label();
            this.pictureBoxTile = new System.Windows.Forms.PictureBox();
            this.label69 = new System.Windows.Forms.Label();
            this.label67 = new System.Windows.Forms.Label();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.panel55 = new System.Windows.Forms.Panel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.PlaybackE_Sequence = new System.ComponentModel.BackgroundWorker();
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.labelToolTip = new System.Windows.Forms.Label();
            this.labelConvertor = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            panel72 = new System.Windows.Forms.Panel();
            label62 = new System.Windows.Forms.Label();
            label75 = new System.Windows.Forms.Label();
            panel2 = new System.Windows.Forms.Panel();
            label27 = new System.Windows.Forms.Label();
            label74 = new System.Windows.Forms.Label();
            label53 = new System.Windows.Forms.Label();
            panel72.SuspendLayout();
            this.toolStrip3.SuspendLayout();
            panel2.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.panelInsertTile.SuspendLayout();
            this.panel116.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.insertTileHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.insertTileWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.insertTileAmount)).BeginInit();
            this.panel117.SuspendLayout();
            this.contextMenuStripCH.SuspendLayout();
            this.contextMenuStripGR.SuspendLayout();
            this.contextMenuStripSI.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panelDialogues.SuspendLayout();
            this.panelSearchDialogue.SuspendLayout();
            this.panel82.SuspendLayout();
            this.panel76.SuspendLayout();
            this.panel77.SuspendLayout();
            this.panel65.SuspendLayout();
            this.panel66.SuspendLayout();
            this.panel47.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.padding)).BeginInit();
            this.panel13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fontSize)).BeginInit();
            this.panel70.SuspendLayout();
            this.panel32.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.characterHeight)).BeginInit();
            this.panel71.SuspendLayout();
            this.panel203.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dialogueNum)).BeginInit();
            this.contextMenuStrip2.SuspendLayout();
            this.panel202.SuspendLayout();
            this.panel60.SuspendLayout();
            this.panel69.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDialogue)).BeginInit();
            this.panel61.SuspendLayout();
            this.panelDialogueInsert.SuspendLayout();
            this.panelDialogueMemory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dialogueByteValue)).BeginInit();
            this.panel201.SuspendLayout();
            this.panel62.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBattleDialogue)).BeginInit();
            this.panel63.SuspendLayout();
            this.panel200.SuspendLayout();
            this.panel113.SuspendLayout();
            this.panel126.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.battleDialogueNum)).BeginInit();
            this.panel59.SuspendLayout();
            this.panel58.SuspendLayout();
            this.panel12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDialogueTile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dialogueSubtile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDialogueSubtile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDialogueBG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBattle)).BeginInit();
            this.panel9.SuspendLayout();
            this.panel30.SuspendLayout();
            this.panel114.SuspendLayout();
            this.toolStrip7.SuspendLayout();
            this.panel112.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFont)).BeginInit();
            this.panel25.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFontEditor)).BeginInit();
            this.panel15.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fontWidth)).BeginInit();
            this.panel46.SuspendLayout();
            this.panel23.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFontPalette)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fontPaletteRedBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fontPaletteGreenNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fontPaletteBlueBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fontPaletteRedNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fontPaletteBlueNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fontPaletteGreenBar)).BeginInit();
            this.panel1.SuspendLayout();
            this.panelColorBalance.SuspendLayout();
            this.panel36.SuspendLayout();
            this.panel108.SuspendLayout();
            this.panel109.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.colEditValueA)).BeginInit();
            this.panel110.SuspendLayout();
            this.panel111.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panelSprites.SuspendLayout();
            this.panelMoldImage.SuspendLayout();
            this.panel84.SuspendLayout();
            this.toolStrip4.SuspendLayout();
            this.panel52.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMold)).BeginInit();
            this.panel54.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mapPaletteBlueBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPalette)).BeginInit();
            this.contextMenuStrip3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mapPaletteBlueNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mapPaletteColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mapPaletteRedNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mapPaletteGreenBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mapPaletteGreenNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mapPaletteRedBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.paletteOffset)).BeginInit();
            this.panel43.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.animationVRAM)).BeginInit();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.animationPacket)).BeginInit();
            this.panel29.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.frameMold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.frameDuration)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSequence)).BeginInit();
            this.panel42.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel56.SuspendLayout();
            this.panel38.SuspendLayout();
            this.panel11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.moldTileCopies)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.moldSubtile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.moldTileYCoord)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.moldTileCopiesOffset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMoldSubtile)).BeginInit();
            this.panel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.moldTileXCoord)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMoldTile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMoldTileset)).BeginInit();
            this.panel45.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spriteNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.graphicPalettePacket)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.graphicPalettePacketShift)).BeginInit();
            this.panelImageGraphics.SuspendLayout();
            this.panelImageGraphicsSub.SuspendLayout();
            this.panel31.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.graphicOffset)).BeginInit();
            this.panel37.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGraphics)).BeginInit();
            this.panelSearchSpriteNames.SuspendLayout();
            this.panel28.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.panelEffects.SuspendLayout();
            this.panel106.SuspendLayout();
            this.panel44.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.effectNum)).BeginInit();
            this.panel103.SuspendLayout();
            this.panel107.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.e_frameMold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.e_duration)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxE_Sequence)).BeginInit();
            this.panel105.SuspendLayout();
            this.panel102.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxE_Subtile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxE_Tile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.e_tileSubtile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEffectTileset)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.e_tileSetSize)).BeginInit();
            this.panel99.SuspendLayout();
            this.panel100.SuspendLayout();
            this.toolStrip6.SuspendLayout();
            this.panel101.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxE_Mold)).BeginInit();
            this.panel90.SuspendLayout();
            this.panel91.SuspendLayout();
            this.panel94.SuspendLayout();
            this.contextMenuStripMD.SuspendLayout();
            this.panel95.SuspendLayout();
            this.panel92.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.moldFillAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.moldTileIndex)).BeginInit();
            this.panel93.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.e_moldHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.e_moldWidth)).BeginInit();
            this.panelEffectGraphics.SuspendLayout();
            this.panel87.SuspendLayout();
            this.panel97.SuspendLayout();
            this.panel98.SuspendLayout();
            this.panel88.SuspendLayout();
            this.toolStrip5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.e_graphicSetSize)).BeginInit();
            this.panel89.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxE_Graphics)).BeginInit();
            this.panel80.SuspendLayout();
            this.panel85.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.e_paletteBlueBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxE_Color)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxE_Palette)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.e_paletteSetSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.e_paletteBlueNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.e_paletteColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.e_paletteRedNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.e_paletteGreenBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.e_paletteGreenNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.e_paletteRedBar)).BeginInit();
            this.panel41.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.yNegShift)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xNegShift)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.e_animation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.e_paletteIndex)).BeginInit();
            this.panelSearchEffectNames.SuspendLayout();
            this.panel86.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.panel57.SuspendLayout();
            this.panel79.SuspendLayout();
            this.panel35.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.toSouthCheckAddress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toWestCheckAddress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toNorthCheckAddress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toEastCheckAddress)).BeginInit();
            this.panel18.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.toEastCheckBit)).BeginInit();
            this.panel20.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.toWestCheckBit)).BeginInit();
            this.panel19.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.toSouthCheckBit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toNorthCheckBit)).BeginInit();
            this.panel21.SuspendLayout();
            this.panel78.SuspendLayout();
            this.panel34.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.whichPointCheckAddress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.whichPointCheckBit)).BeginInit();
            this.panel17.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.runEvent)).BeginInit();
            this.panel27.SuspendLayout();
            this.panel48.SuspendLayout();
            this.panel26.SuspendLayout();
            this.panel40.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWorldMap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.worldMapNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.worldMapYCoord)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.worldMapTileset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.worldMapXCoord)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pointCount)).BeginInit();
            this.panel214.SuspendLayout();
            this.panel51.SuspendLayout();
            this.panel50.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wmPaletteRedBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wmPaletteGreenNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wmPaletteBlueBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWMPaletteColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wmPaletteGreenBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWMPalette)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wmPaletteRedNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wmPaletteColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wmPaletteBlueNum)).BeginInit();
            this.panel49.SuspendLayout();
            this.panel14.SuspendLayout();
            this.panel81.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.showCheckAddress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.showCheckBit)).BeginInit();
            this.panel64.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mapPointYCoord)).BeginInit();
            this.panel16.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mapPointNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mapPointXCoord)).BeginInit();
            this.panel53.SuspendLayout();
            this.panel39.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSubtile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wmSubtilePalette)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWMGraphics)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wmGraphicSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wmSubtile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTile)).BeginInit();
            this.SuspendLayout();
            // 
            // panel72
            // 
            panel72.BackColor = System.Drawing.SystemColors.Control;
            panel72.Controls.Add(this.toolStrip3);
            panel72.Location = new System.Drawing.Point(0, 37);
            panel72.Name = "panel72";
            panel72.Size = new System.Drawing.Size(79, 17);
            panel72.TabIndex = 63;
            // 
            // toolStrip3
            // 
            this.toolStrip3.AutoSize = false;
            this.toolStrip3.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip3.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip3.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fontBold,
            this.fontItalics,
            this.fontUnderline});
            this.toolStrip3.Location = new System.Drawing.Point(0, -1);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip3.Size = new System.Drawing.Size(80, 20);
            this.toolStrip3.TabIndex = 0;
            this.toolStrip3.TabStop = true;
            this.toolStrip3.Text = "toolStrip3";
            // 
            // fontBold
            // 
            this.fontBold.AutoSize = false;
            this.fontBold.CheckOnClick = true;
            this.fontBold.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.fontBold.Image = global::LAZYSHELL.Properties.Resources.fontBold;
            this.fontBold.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.fontBold.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.fontBold.Name = "fontBold";
            this.fontBold.Size = new System.Drawing.Size(26, 17);
            this.fontBold.Text = "Bold";
            this.fontBold.Click += new System.EventHandler(this.fontBold_Click);
            // 
            // fontItalics
            // 
            this.fontItalics.AutoSize = false;
            this.fontItalics.CheckOnClick = true;
            this.fontItalics.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.fontItalics.Image = global::LAZYSHELL.Properties.Resources.fontItalics;
            this.fontItalics.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.fontItalics.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.fontItalics.Name = "fontItalics";
            this.fontItalics.Size = new System.Drawing.Size(26, 17);
            this.fontItalics.Text = "Italic";
            this.fontItalics.Click += new System.EventHandler(this.fontItalics_Click);
            // 
            // fontUnderline
            // 
            this.fontUnderline.AutoSize = false;
            this.fontUnderline.CheckOnClick = true;
            this.fontUnderline.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.fontUnderline.Image = global::LAZYSHELL.Properties.Resources.fontUnderline;
            this.fontUnderline.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.fontUnderline.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.fontUnderline.Name = "fontUnderline";
            this.fontUnderline.Size = new System.Drawing.Size(26, 17);
            this.fontUnderline.Text = "Underline";
            this.fontUnderline.Click += new System.EventHandler(this.fontUnderline_Click);
            // 
            // label62
            // 
            label62.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            label62.Location = new System.Drawing.Point(0, 37);
            label62.Name = "label62";
            label62.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            label62.Size = new System.Drawing.Size(79, 17);
            label62.TabIndex = 445;
            label62.Text = "Padding";
            // 
            // label75
            // 
            label75.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            label75.Location = new System.Drawing.Point(0, 19);
            label75.Name = "label75";
            label75.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            label75.Size = new System.Drawing.Size(79, 17);
            label75.TabIndex = 445;
            label75.Text = "Unit Height";
            // 
            // panel2
            // 
            panel2.BackColor = System.Drawing.SystemColors.Control;
            panel2.Controls.Add(this.toolStrip2);
            panel2.Location = new System.Drawing.Point(0, 55);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(256, 18);
            panel2.TabIndex = 65;
            // 
            // toolStrip2
            // 
            this.toolStrip2.AutoSize = false;
            this.toolStrip2.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fontShowGrid,
            this.toolStripSeparator24,
            this.fontEditZoomIn,
            this.fontEditZoomOut,
            this.toolStripSeparator25,
            this.fontEditDraw,
            this.fontEditErase,
            this.fontEditChoose,
            this.toolStripSeparator26,
            this.fontEditDelete,
            this.fontEditCopy,
            this.fontEditPaste,
            this.toolStripSeparator27,
            this.fontEditMirror,
            this.fontEditInvert});
            this.toolStrip2.Location = new System.Drawing.Point(0, -1);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip2.Size = new System.Drawing.Size(256, 21);
            this.toolStrip2.TabIndex = 0;
            this.toolStrip2.TabStop = true;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // fontShowGrid
            // 
            this.fontShowGrid.AutoSize = false;
            this.fontShowGrid.CheckOnClick = true;
            this.fontShowGrid.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.fontShowGrid.Image = global::LAZYSHELL.Properties.Resources.buttonTogglePixelGrid;
            this.fontShowGrid.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.fontShowGrid.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.fontShowGrid.Name = "fontShowGrid";
            this.fontShowGrid.Size = new System.Drawing.Size(21, 17);
            this.fontShowGrid.Text = "Pixel Grid";
            this.fontShowGrid.Click += new System.EventHandler(this.fontShowGrid_Click);
            // 
            // toolStripSeparator24
            // 
            this.toolStripSeparator24.Name = "toolStripSeparator24";
            this.toolStripSeparator24.Size = new System.Drawing.Size(6, 21);
            // 
            // fontEditZoomIn
            // 
            this.fontEditZoomIn.AutoSize = false;
            this.fontEditZoomIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.fontEditZoomIn.Image = global::LAZYSHELL.Properties.Resources.zoomin_small;
            this.fontEditZoomIn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.fontEditZoomIn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.fontEditZoomIn.Name = "fontEditZoomIn";
            this.fontEditZoomIn.Size = new System.Drawing.Size(21, 17);
            this.fontEditZoomIn.Text = "Zoom In";
            this.fontEditZoomIn.Click += new System.EventHandler(this.fontEditZoomIn_Click);
            // 
            // fontEditZoomOut
            // 
            this.fontEditZoomOut.AutoSize = false;
            this.fontEditZoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.fontEditZoomOut.Image = global::LAZYSHELL.Properties.Resources.zoomout_small;
            this.fontEditZoomOut.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.fontEditZoomOut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.fontEditZoomOut.Name = "fontEditZoomOut";
            this.fontEditZoomOut.Size = new System.Drawing.Size(21, 17);
            this.fontEditZoomOut.Text = "Zoom Out";
            this.fontEditZoomOut.Click += new System.EventHandler(this.fontEditZoomOut_Click);
            // 
            // toolStripSeparator25
            // 
            this.toolStripSeparator25.Name = "toolStripSeparator25";
            this.toolStripSeparator25.Size = new System.Drawing.Size(6, 21);
            // 
            // fontEditDraw
            // 
            this.fontEditDraw.AutoSize = false;
            this.fontEditDraw.CheckOnClick = true;
            this.fontEditDraw.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.fontEditDraw.Image = global::LAZYSHELL.Properties.Resources.draw_small;
            this.fontEditDraw.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.fontEditDraw.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.fontEditDraw.Name = "fontEditDraw";
            this.fontEditDraw.Size = new System.Drawing.Size(21, 17);
            this.fontEditDraw.Text = "Draw";
            this.fontEditDraw.Click += new System.EventHandler(this.fontEditDraw_Click);
            // 
            // fontEditErase
            // 
            this.fontEditErase.AutoSize = false;
            this.fontEditErase.CheckOnClick = true;
            this.fontEditErase.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.fontEditErase.Image = global::LAZYSHELL.Properties.Resources.erase_small;
            this.fontEditErase.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.fontEditErase.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.fontEditErase.Name = "fontEditErase";
            this.fontEditErase.Size = new System.Drawing.Size(21, 17);
            this.fontEditErase.Text = "Erase";
            this.fontEditErase.Click += new System.EventHandler(this.fontEditErase_Click);
            // 
            // fontEditChoose
            // 
            this.fontEditChoose.AutoSize = false;
            this.fontEditChoose.CheckOnClick = true;
            this.fontEditChoose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.fontEditChoose.Image = global::LAZYSHELL.Properties.Resources.dropper_small;
            this.fontEditChoose.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.fontEditChoose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.fontEditChoose.Name = "fontEditChoose";
            this.fontEditChoose.Size = new System.Drawing.Size(21, 17);
            this.fontEditChoose.Text = "Choose Color";
            this.fontEditChoose.Click += new System.EventHandler(this.fontEditChoose_Click);
            // 
            // toolStripSeparator26
            // 
            this.toolStripSeparator26.Name = "toolStripSeparator26";
            this.toolStripSeparator26.Size = new System.Drawing.Size(6, 21);
            // 
            // fontEditDelete
            // 
            this.fontEditDelete.AutoSize = false;
            this.fontEditDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.fontEditDelete.Image = global::LAZYSHELL.Properties.Resources.delete_small;
            this.fontEditDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.fontEditDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.fontEditDelete.Name = "fontEditDelete";
            this.fontEditDelete.Size = new System.Drawing.Size(21, 17);
            this.fontEditDelete.Text = "Clear Character";
            this.fontEditDelete.ToolTipText = "Clear Character";
            this.fontEditDelete.Click += new System.EventHandler(this.fontEditDelete_Click);
            // 
            // fontEditCopy
            // 
            this.fontEditCopy.AutoSize = false;
            this.fontEditCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.fontEditCopy.Image = global::LAZYSHELL.Properties.Resources.copy_small;
            this.fontEditCopy.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.fontEditCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.fontEditCopy.Name = "fontEditCopy";
            this.fontEditCopy.Size = new System.Drawing.Size(21, 17);
            this.fontEditCopy.Text = "Copy Character";
            this.fontEditCopy.ToolTipText = "Copy Character";
            this.fontEditCopy.Click += new System.EventHandler(this.fontEditCopy_Click);
            // 
            // fontEditPaste
            // 
            this.fontEditPaste.AutoSize = false;
            this.fontEditPaste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.fontEditPaste.Image = global::LAZYSHELL.Properties.Resources.paste_small;
            this.fontEditPaste.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.fontEditPaste.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.fontEditPaste.Name = "fontEditPaste";
            this.fontEditPaste.Size = new System.Drawing.Size(21, 17);
            this.fontEditPaste.Text = "Paste Character";
            this.fontEditPaste.Click += new System.EventHandler(this.fontEditPaste_Click);
            // 
            // toolStripSeparator27
            // 
            this.toolStripSeparator27.Name = "toolStripSeparator27";
            this.toolStripSeparator27.Size = new System.Drawing.Size(6, 21);
            // 
            // fontEditMirror
            // 
            this.fontEditMirror.AutoSize = false;
            this.fontEditMirror.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.fontEditMirror.Image = global::LAZYSHELL.Properties.Resources.mirror_small;
            this.fontEditMirror.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.fontEditMirror.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.fontEditMirror.Name = "fontEditMirror";
            this.fontEditMirror.Size = new System.Drawing.Size(21, 18);
            this.fontEditMirror.Text = "Mirror Character";
            this.fontEditMirror.Click += new System.EventHandler(this.fontEditMirror_Click);
            // 
            // fontEditInvert
            // 
            this.fontEditInvert.AutoSize = false;
            this.fontEditInvert.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.fontEditInvert.Image = global::LAZYSHELL.Properties.Resources.flip_small;
            this.fontEditInvert.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.fontEditInvert.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.fontEditInvert.Name = "fontEditInvert";
            this.fontEditInvert.Size = new System.Drawing.Size(21, 18);
            this.fontEditInvert.Text = "Invert Character";
            this.fontEditInvert.Click += new System.EventHandler(this.fontEditInvert_Click);
            // 
            // label27
            // 
            label27.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            label27.Location = new System.Drawing.Point(129, 37);
            label27.Name = "label27";
            label27.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            label27.Size = new System.Drawing.Size(64, 17);
            label27.TabIndex = 445;
            label27.Text = "Width";
            // 
            // label74
            // 
            label74.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            label74.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label74.ForeColor = System.Drawing.SystemColors.Control;
            label74.Location = new System.Drawing.Point(2, 2);
            label74.Name = "label74";
            label74.Padding = new System.Windows.Forms.Padding(2, 2, 0, 0);
            label74.Size = new System.Drawing.Size(256, 17);
            label74.TabIndex = 461;
            label74.Text = "FONTS";
            // 
            // label53
            // 
            label53.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            label53.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label53.ForeColor = System.Drawing.SystemColors.Control;
            label53.Location = new System.Drawing.Point(2, 2);
            label53.Name = "label53";
            label53.Padding = new System.Windows.Forms.Padding(2, 2, 0, 0);
            label53.Size = new System.Drawing.Size(256, 17);
            label53.TabIndex = 461;
            label53.Text = "DIALOGUE BACKGROUNDS";
            // 
            // panelInsertTile
            // 
            this.panelInsertTile.Controls.Add(this.label68);
            this.panelInsertTile.Controls.Add(this.panel116);
            this.panelInsertTile.Controls.Add(this.insertTileHeight);
            this.panelInsertTile.Controls.Add(this.insertTileWidth);
            this.panelInsertTile.Controls.Add(this.insertTileAmount);
            this.panelInsertTile.Controls.Add(this.label117);
            this.panelInsertTile.Controls.Add(this.label115);
            this.panelInsertTile.Controls.Add(this.label87);
            this.panelInsertTile.Controls.Add(this.panel117);
            this.panelInsertTile.Controls.Add(this.insertTileCancel);
            this.panelInsertTile.Controls.Add(this.label110);
            this.panelInsertTile.Controls.Add(this.insertTileOK);
            this.panelInsertTile.Location = new System.Drawing.Point(538, 367);
            this.panelInsertTile.Name = "panelInsertTile";
            this.panelInsertTile.Size = new System.Drawing.Size(138, 113);
            this.panelInsertTile.TabIndex = 521;
            this.panelInsertTile.Visible = false;
            // 
            // label68
            // 
            this.label68.BackColor = System.Drawing.SystemColors.Control;
            this.label68.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label68.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label68.Location = new System.Drawing.Point(2, 2);
            this.label68.Name = "label68";
            this.label68.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.label68.Size = new System.Drawing.Size(134, 17);
            this.label68.TabIndex = 413;
            this.label68.Text = "INSERT TILES...";
            // 
            // panel116
            // 
            this.panel116.Controls.Add(this.insertTileType);
            this.panel116.Location = new System.Drawing.Point(69, 21);
            this.panel116.Name = "panel116";
            this.panel116.Size = new System.Drawing.Size(68, 17);
            this.panel116.TabIndex = 412;
            // 
            // insertTileType
            // 
            this.insertTileType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.insertTileType.FormattingEnabled = true;
            this.insertTileType.Items.AddRange(new object[] {
            "empty",
            "ordered",
            "pattern",
            "wallpaper"});
            this.insertTileType.Location = new System.Drawing.Point(-2, -2);
            this.insertTileType.Name = "insertTileType";
            this.insertTileType.Size = new System.Drawing.Size(72, 21);
            this.insertTileType.TabIndex = 38;
            this.insertTileType.SelectedIndexChanged += new System.EventHandler(this.insertTileType_SelectedIndexChanged);
            // 
            // insertTileHeight
            // 
            this.insertTileHeight.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.insertTileHeight.Location = new System.Drawing.Point(69, 75);
            this.insertTileHeight.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.insertTileHeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.insertTileHeight.Name = "insertTileHeight";
            this.insertTileHeight.Size = new System.Drawing.Size(68, 17);
            this.insertTileHeight.TabIndex = 408;
            this.insertTileHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.insertTileHeight.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.insertTileHeight.ValueChanged += new System.EventHandler(this.insertTileAmount_ValueChanged);
            // 
            // insertTileWidth
            // 
            this.insertTileWidth.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.insertTileWidth.Location = new System.Drawing.Point(69, 57);
            this.insertTileWidth.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.insertTileWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.insertTileWidth.Name = "insertTileWidth";
            this.insertTileWidth.Size = new System.Drawing.Size(68, 17);
            this.insertTileWidth.TabIndex = 408;
            this.insertTileWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.insertTileWidth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.insertTileWidth.ValueChanged += new System.EventHandler(this.insertTileAmount_ValueChanged);
            // 
            // insertTileAmount
            // 
            this.insertTileAmount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.insertTileAmount.Location = new System.Drawing.Point(69, 39);
            this.insertTileAmount.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.insertTileAmount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.insertTileAmount.Name = "insertTileAmount";
            this.insertTileAmount.Size = new System.Drawing.Size(68, 17);
            this.insertTileAmount.TabIndex = 408;
            this.insertTileAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.insertTileAmount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.insertTileAmount.ValueChanged += new System.EventHandler(this.insertTileAmount_ValueChanged);
            // 
            // label117
            // 
            this.label117.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label117.Location = new System.Drawing.Point(2, 75);
            this.label117.Name = "label117";
            this.label117.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label117.Size = new System.Drawing.Size(66, 17);
            this.label117.TabIndex = 409;
            this.label117.Text = "Height";
            // 
            // label115
            // 
            this.label115.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label115.Location = new System.Drawing.Point(2, 57);
            this.label115.Name = "label115";
            this.label115.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label115.Size = new System.Drawing.Size(66, 17);
            this.label115.TabIndex = 409;
            this.label115.Text = "Width";
            // 
            // label87
            // 
            this.label87.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label87.Location = new System.Drawing.Point(2, 39);
            this.label87.Name = "label87";
            this.label87.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label87.Size = new System.Drawing.Size(66, 17);
            this.label87.TabIndex = 409;
            this.label87.Text = "Amount";
            // 
            // panel117
            // 
            this.panel117.Controls.Add(this.comboBox5);
            this.panel117.Location = new System.Drawing.Point(69, 21);
            this.panel117.Name = "panel117";
            this.panel117.Size = new System.Drawing.Size(68, 17);
            this.panel117.TabIndex = 411;
            // 
            // comboBox5
            // 
            this.comboBox5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox5.FormattingEnabled = true;
            this.comboBox5.Items.AddRange(new object[] {
            "Gridplane",
            "16x16 mapped"});
            this.comboBox5.Location = new System.Drawing.Point(-2, -2);
            this.comboBox5.Name = "comboBox5";
            this.comboBox5.Size = new System.Drawing.Size(53, 21);
            this.comboBox5.TabIndex = 400;
            // 
            // insertTileCancel
            // 
            this.insertTileCancel.BackColor = System.Drawing.SystemColors.Window;
            this.insertTileCancel.FlatAppearance.BorderSize = 0;
            this.insertTileCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.insertTileCancel.Location = new System.Drawing.Point(69, 94);
            this.insertTileCancel.Name = "insertTileCancel";
            this.insertTileCancel.Size = new System.Drawing.Size(67, 17);
            this.insertTileCancel.TabIndex = 40;
            this.insertTileCancel.Text = "CANCEL";
            this.insertTileCancel.UseCompatibleTextRendering = true;
            this.insertTileCancel.UseVisualStyleBackColor = false;
            this.insertTileCancel.Click += new System.EventHandler(this.insertTileCancel_Click);
            // 
            // label110
            // 
            this.label110.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label110.Location = new System.Drawing.Point(2, 21);
            this.label110.Name = "label110";
            this.label110.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label110.Size = new System.Drawing.Size(66, 17);
            this.label110.TabIndex = 410;
            this.label110.Text = "Type";
            // 
            // insertTileOK
            // 
            this.insertTileOK.BackColor = System.Drawing.SystemColors.Window;
            this.insertTileOK.FlatAppearance.BorderSize = 0;
            this.insertTileOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.insertTileOK.Location = new System.Drawing.Point(2, 94);
            this.insertTileOK.Name = "insertTileOK";
            this.insertTileOK.Size = new System.Drawing.Size(66, 17);
            this.insertTileOK.TabIndex = 39;
            this.insertTileOK.Text = "OK";
            this.insertTileOK.UseCompatibleTextRendering = true;
            this.insertTileOK.UseVisualStyleBackColor = false;
            this.insertTileOK.Click += new System.EventHandler(this.insertTileOK_Click);
            // 
            // contextMenuStripCH
            // 
            this.contextMenuStripCH.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiZoomInCH,
            this.tsmiZoomOutCH,
            this.toolStripSeparator9,
            this.tsmiCutCH,
            this.tsmiCopyCH,
            this.tsmiPasteCH,
            this.tsmiDeleteCH});
            this.contextMenuStripCH.Name = "contextMenuStripGR";
            this.contextMenuStripCH.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.contextMenuStripCH.ShowImageMargin = false;
            this.contextMenuStripCH.Size = new System.Drawing.Size(97, 142);
            // 
            // tsmiZoomInCH
            // 
            this.tsmiZoomInCH.Name = "tsmiZoomInCH";
            this.tsmiZoomInCH.Size = new System.Drawing.Size(96, 22);
            this.tsmiZoomInCH.Text = "Zoom In";
            this.tsmiZoomInCH.Click += new System.EventHandler(this.fontEditZoomIn_Click);
            // 
            // tsmiZoomOutCH
            // 
            this.tsmiZoomOutCH.Name = "tsmiZoomOutCH";
            this.tsmiZoomOutCH.Size = new System.Drawing.Size(96, 22);
            this.tsmiZoomOutCH.Text = "Zoom Out";
            this.tsmiZoomOutCH.Click += new System.EventHandler(this.fontEditZoomOut_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(93, 6);
            // 
            // tsmiCutCH
            // 
            this.tsmiCutCH.Name = "tsmiCutCH";
            this.tsmiCutCH.Size = new System.Drawing.Size(96, 22);
            this.tsmiCutCH.Text = "Cut";
            this.tsmiCutCH.Click += new System.EventHandler(this.tsmiCutCH_Click);
            // 
            // tsmiCopyCH
            // 
            this.tsmiCopyCH.Name = "tsmiCopyCH";
            this.tsmiCopyCH.Size = new System.Drawing.Size(96, 22);
            this.tsmiCopyCH.Text = "Copy";
            this.tsmiCopyCH.Click += new System.EventHandler(this.tsmiCopyCH_Click);
            // 
            // tsmiPasteCH
            // 
            this.tsmiPasteCH.Name = "tsmiPasteCH";
            this.tsmiPasteCH.Size = new System.Drawing.Size(96, 22);
            this.tsmiPasteCH.Text = "Paste";
            this.tsmiPasteCH.Click += new System.EventHandler(this.tsmiPasteCH_Click);
            // 
            // tsmiDeleteCH
            // 
            this.tsmiDeleteCH.Name = "tsmiDeleteCH";
            this.tsmiDeleteCH.Size = new System.Drawing.Size(96, 22);
            this.tsmiDeleteCH.Text = "Delete";
            this.tsmiDeleteCH.Click += new System.EventHandler(this.tsmiDeleteCH_Click);
            // 
            // contextMenuStripGR
            // 
            this.contextMenuStripGR.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setAsSubtileToolStripMenuItem,
            this.toolStripSeparator4,
            this.importToolStripMenuItem,
            this.exportToolStripMenuItem,
            this.saveImageToolStripMenuItem1,
            this.toolStripSeparator2,
            this.clearToolStripMenuItem1,
            this.applyBorderToolStripMenuItem});
            this.contextMenuStripGR.Name = "contextMenuStripGR";
            this.contextMenuStripGR.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.contextMenuStripGR.ShowImageMargin = false;
            this.contextMenuStripGR.Size = new System.Drawing.Size(117, 148);
            this.contextMenuStripGR.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStripGR_Opening);
            // 
            // setAsSubtileToolStripMenuItem
            // 
            this.setAsSubtileToolStripMenuItem.Name = "setAsSubtileToolStripMenuItem";
            this.setAsSubtileToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.setAsSubtileToolStripMenuItem.Text = "Set subtile";
            this.setAsSubtileToolStripMenuItem.Click += new System.EventHandler(this.setAsSubtileToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(113, 6);
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.importToolStripMenuItem.Text = "Import...";
            this.importToolStripMenuItem.Click += new System.EventHandler(this.importToolStripMenuItem_Click);
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
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(113, 6);
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
            this.applyBorderToolStripMenuItem.Name = "applyBorderToolStripMenuItem";
            this.applyBorderToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.applyBorderToolStripMenuItem.Text = "Apply border";
            this.applyBorderToolStripMenuItem.Click += new System.EventHandler(this.applyBorderToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(169, 6);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(169, 6);
            // 
            // contextMenuStripSI
            // 
            this.contextMenuStripSI.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveImageToolStripMenuItem});
            this.contextMenuStripSI.Name = "contextMenuStripSI";
            this.contextMenuStripSI.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.contextMenuStripSI.ShowImageMargin = false;
            this.contextMenuStripSI.Size = new System.Drawing.Size(131, 26);
            // 
            // saveImageToolStripMenuItem
            // 
            this.saveImageToolStripMenuItem.Name = "saveImageToolStripMenuItem";
            this.saveImageToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.saveImageToolStripMenuItem.Text = "Save image as...";
            this.saveImageToolStripMenuItem.Click += new System.EventHandler(this.saveImageToolStripMenuItem_Click);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cutToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStripGR";
            this.contextMenuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.contextMenuStrip.ShowImageMargin = false;
            this.contextMenuStrip.Size = new System.Drawing.Size(81, 92);
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(80, 22);
            this.cutToolStripMenuItem.Text = "Cut";
            this.cutToolStripMenuItem.Click += new System.EventHandler(this.cutToolStripMenuItem_Click);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(80, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(80, 22);
            this.pasteToolStripMenuItem.Text = "Paste";
            this.pasteToolStripMenuItem.Click += new System.EventHandler(this.pasteToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(80, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // PlaybackSequence
            // 
            this.PlaybackSequence.WorkerReportsProgress = true;
            this.PlaybackSequence.WorkerSupportsCancellation = true;
            this.PlaybackSequence.DoWork += new System.ComponentModel.DoWorkEventHandler(this.PlaybackSequence_DoWork);
            this.PlaybackSequence.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.PlaybackSequence_RunWorkerCompleted);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Padding = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.toolStripMenuItem1.Size = new System.Drawing.Size(31, 20);
            this.toolStripMenuItem1.Text = "File";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(149, 6);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(149, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.saveToolStripMenuItem.Text = "Save Sprites";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(149, 6);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.allPaletteToolStripMenuItem,
            this.animationsallToolStripMenuItem,
            this.allEffectsToolStripMenuItem,
            this.dialoguesToolStripMenuItem,
            this.allMapsToolStripMenuItem,
            this.allMapPointsToolStripMenuItem});
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.clearToolStripMenuItem.Text = "Clear";
            // 
            // allPaletteToolStripMenuItem
            // 
            this.allPaletteToolStripMenuItem.Name = "allPaletteToolStripMenuItem";
            this.allPaletteToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.allPaletteToolStripMenuItem.Text = "Palettes...";
            this.allPaletteToolStripMenuItem.Click += new System.EventHandler(this.allPaletteToolStripMenuItem_Click);
            // 
            // animationsallToolStripMenuItem
            // 
            this.animationsallToolStripMenuItem.Name = "animationsallToolStripMenuItem";
            this.animationsallToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.animationsallToolStripMenuItem.Text = "Animations...";
            this.animationsallToolStripMenuItem.Click += new System.EventHandler(this.animationsallToolStripMenuItem_Click);
            // 
            // allEffectsToolStripMenuItem
            // 
            this.allEffectsToolStripMenuItem.Name = "allEffectsToolStripMenuItem";
            this.allEffectsToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.allEffectsToolStripMenuItem.Text = "Effects...";
            this.allEffectsToolStripMenuItem.Click += new System.EventHandler(this.allEffectsToolStripMenuItem_Click);
            // 
            // dialoguesToolStripMenuItem
            // 
            this.dialoguesToolStripMenuItem.Name = "dialoguesToolStripMenuItem";
            this.dialoguesToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.dialoguesToolStripMenuItem.Text = "Dialogues...";
            this.dialoguesToolStripMenuItem.Click += new System.EventHandler(this.dialoguesToolStripMenuItem_Click);
            // 
            // allMapsToolStripMenuItem
            // 
            this.allMapsToolStripMenuItem.Name = "allMapsToolStripMenuItem";
            this.allMapsToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.allMapsToolStripMenuItem.Text = "World Maps...";
            this.allMapsToolStripMenuItem.Click += new System.EventHandler(this.allMapsToolStripMenuItem_Click);
            // 
            // allMapPointsToolStripMenuItem
            // 
            this.allMapPointsToolStripMenuItem.Name = "allMapPointsToolStripMenuItem";
            this.allMapPointsToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.allMapPointsToolStripMenuItem.Text = "Map Points...";
            this.allMapPointsToolStripMenuItem.Click += new System.EventHandler(this.allMapPointsToolStripMenuItem_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(149, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // enableHelpTipsToolStripMenuItem
            // 
            this.enableHelpTipsToolStripMenuItem.CheckOnClick = true;
            this.enableHelpTipsToolStripMenuItem.Name = "enableHelpTipsToolStripMenuItem";
            this.enableHelpTipsToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.enableHelpTipsToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.enableHelpTipsToolStripMenuItem.Text = "Enable Help Tips";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.aboutToolStripMenuItem.Text = "About...";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.toolStripSeparator3,
            this.importToolStripMenuItem1,
            this.exportToolStripMenuItem1,
            this.clearToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // importToolStripMenuItem1
            // 
            this.importToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.allAnimationsToolStripMenuItem,
            this.allEffectAnimationsToolStripMenuItem,
            this.allDialoguesToolStripMenuItem1});
            this.importToolStripMenuItem1.Name = "importToolStripMenuItem1";
            this.importToolStripMenuItem1.Size = new System.Drawing.Size(172, 22);
            this.importToolStripMenuItem1.Text = "Import";
            // 
            // allAnimationsToolStripMenuItem
            // 
            this.allAnimationsToolStripMenuItem.Name = "allAnimationsToolStripMenuItem";
            this.allAnimationsToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.allAnimationsToolStripMenuItem.Text = "Sprite Animations...";
            this.allAnimationsToolStripMenuItem.Click += new System.EventHandler(this.allAnimationsToolStripMenuItem_Click);
            // 
            // allEffectAnimationsToolStripMenuItem
            // 
            this.allEffectAnimationsToolStripMenuItem.Name = "allEffectAnimationsToolStripMenuItem";
            this.allEffectAnimationsToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.allEffectAnimationsToolStripMenuItem.Text = "Effect Animations...";
            this.allEffectAnimationsToolStripMenuItem.Click += new System.EventHandler(this.allEffectAnimationsToolStripMenuItem_Click);
            // 
            // allDialoguesToolStripMenuItem1
            // 
            this.allDialoguesToolStripMenuItem1.Name = "allDialoguesToolStripMenuItem1";
            this.allDialoguesToolStripMenuItem1.Size = new System.Drawing.Size(170, 22);
            this.allDialoguesToolStripMenuItem1.Text = "Dialogues...";
            this.allDialoguesToolStripMenuItem1.Click += new System.EventHandler(this.allDialoguesToolStripMenuItem1_Click);
            // 
            // exportToolStripMenuItem1
            // 
            this.exportToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem5,
            this.allEffectAnimationsToolStripMenuItem1,
            this.allDialoguesToolStripMenuItem});
            this.exportToolStripMenuItem1.Name = "exportToolStripMenuItem1";
            this.exportToolStripMenuItem1.Size = new System.Drawing.Size(172, 22);
            this.exportToolStripMenuItem1.Text = "Export";
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(170, 22);
            this.toolStripMenuItem5.Text = "Sprite Animations...";
            this.toolStripMenuItem5.Click += new System.EventHandler(this.toolStripMenuItem5_Click);
            // 
            // allEffectAnimationsToolStripMenuItem1
            // 
            this.allEffectAnimationsToolStripMenuItem1.Name = "allEffectAnimationsToolStripMenuItem1";
            this.allEffectAnimationsToolStripMenuItem1.Size = new System.Drawing.Size(170, 22);
            this.allEffectAnimationsToolStripMenuItem1.Text = "Effect Animations...";
            this.allEffectAnimationsToolStripMenuItem1.Click += new System.EventHandler(this.allEffectAnimationsToolStripMenuItem1_Click);
            // 
            // allDialoguesToolStripMenuItem
            // 
            this.allDialoguesToolStripMenuItem.Name = "allDialoguesToolStripMenuItem";
            this.allDialoguesToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.allDialoguesToolStripMenuItem.Text = "Dialogues...";
            this.allDialoguesToolStripMenuItem.Click += new System.EventHandler(this.allDialoguesToolStripMenuItem_Click);
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
            // showDecHexToolStripMenuItem
            // 
            this.showDecHexToolStripMenuItem.CheckOnClick = true;
            this.showDecHexToolStripMenuItem.Name = "showDecHexToolStripMenuItem";
            this.showDecHexToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.showDecHexToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.showDecHexToolStripMenuItem.Text = "Show Dec <> Hex";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip1.Size = new System.Drawing.Size(1006, 24);
            this.menuStrip1.TabIndex = 450;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.ControlText;
            this.tabPage2.Controls.Add(this.panelDialogues);
            this.tabPage2.Location = new System.Drawing.Point(175, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(809, 658);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "DIALOGUE / FONTS";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panelDialogues
            // 
            this.panelDialogues.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelDialogues.BackgroundImage = global::LAZYSHELL.Properties.Resources._bg;
            this.panelDialogues.Controls.Add(this.characterNumLabel);
            this.panelDialogues.Controls.Add(this.panelSearchDialogue);
            this.panelDialogues.Controls.Add(this.panel65);
            this.panelDialogues.Controls.Add(this.panel203);
            this.panelDialogues.Controls.Add(this.panel202);
            this.panelDialogues.Controls.Add(this.panel201);
            this.panelDialogues.Controls.Add(this.panel200);
            this.panelDialogues.Controls.Add(this.panel59);
            this.panelDialogues.Controls.Add(this.panel9);
            this.panelDialogues.Controls.Add(this.panel46);
            this.panelDialogues.Location = new System.Drawing.Point(2, 2);
            this.panelDialogues.Name = "panelDialogues";
            this.panelDialogues.Size = new System.Drawing.Size(805, 654);
            this.panelDialogues.TabIndex = 3;
            this.panelDialogues.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelDialogues_MouseMove);
            this.panelDialogues.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelDialogues_MouseUp);
            // 
            // characterNumLabel
            // 
            this.characterNumLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.characterNumLabel.BackColor = System.Drawing.SystemColors.Info;
            this.characterNumLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.characterNumLabel.Location = new System.Drawing.Point(779, 138);
            this.characterNumLabel.Name = "characterNumLabel";
            this.characterNumLabel.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.characterNumLabel.Size = new System.Drawing.Size(0, 18);
            this.characterNumLabel.TabIndex = 526;
            this.characterNumLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.characterNumLabel.Visible = false;
            // 
            // panelSearchDialogue
            // 
            this.panelSearchDialogue.Controls.Add(this.panel82);
            this.panelSearchDialogue.Location = new System.Drawing.Point(272, 6);
            this.panelSearchDialogue.Name = "panelSearchDialogue";
            this.panelSearchDialogue.Size = new System.Drawing.Size(260, 642);
            this.panelSearchDialogue.TabIndex = 2;
            this.panelSearchDialogue.MouseLeave += new System.EventHandler(this.panelSearchDialogue_MouseLeave);
            this.panelSearchDialogue.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelSearchDialogue_MouseMove);
            this.panelSearchDialogue.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelSearchDialogue_MouseDown);
            // 
            // panel82
            // 
            this.panel82.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel82.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.panel82.Controls.Add(this.labelSearchDialogue);
            this.panel82.Controls.Add(this.panel76);
            this.panel82.Controls.Add(this.searchButton);
            this.panel82.Controls.Add(this.panel77);
            this.panel82.Location = new System.Drawing.Point(2, 2);
            this.panel82.Name = "panel82";
            this.panel82.Size = new System.Drawing.Size(256, 638);
            this.panel82.TabIndex = 560;
            // 
            // labelSearchDialogue
            // 
            this.labelSearchDialogue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.labelSearchDialogue.BackColor = System.Drawing.SystemColors.Control;
            this.labelSearchDialogue.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.labelSearchDialogue.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSearchDialogue.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.labelSearchDialogue.Location = new System.Drawing.Point(0, 0);
            this.labelSearchDialogue.Name = "labelSearchDialogue";
            this.labelSearchDialogue.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.labelSearchDialogue.Size = new System.Drawing.Size(256, 17);
            this.labelSearchDialogue.TabIndex = 558;
            this.labelSearchDialogue.Text = "SEARCH DIALOGUE...";
            this.labelSearchDialogue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.labelSearchDialogue, "Click to drag or double-click to maximize / restore");
            this.labelSearchDialogue.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.labelSearchDialogue_MouseDoubleClick);
            this.labelSearchDialogue.MouseDown += new System.Windows.Forms.MouseEventHandler(this.labelSearchDialogue_MouseDown);
            this.labelSearchDialogue.MouseUp += new System.Windows.Forms.MouseEventHandler(this.labelSearchDialogue_MouseUp);
            // 
            // panel76
            // 
            this.panel76.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel76.BackColor = System.Drawing.SystemColors.Window;
            this.panel76.Controls.Add(this.textBoxSearch);
            this.panel76.Location = new System.Drawing.Point(0, 19);
            this.panel76.Name = "panel76";
            this.panel76.Size = new System.Drawing.Size(179, 17);
            this.panel76.TabIndex = 554;
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxSearch.Location = new System.Drawing.Point(4, 2);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(171, 14);
            this.textBoxSearch.TabIndex = 324;
            this.textBoxSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxSearch_KeyDown);
            // 
            // searchButton
            // 
            this.searchButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.searchButton.BackColor = System.Drawing.SystemColors.Window;
            this.searchButton.FlatAppearance.BorderSize = 0;
            this.searchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.searchButton.Location = new System.Drawing.Point(180, 19);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(76, 17);
            this.searchButton.TabIndex = 555;
            this.searchButton.Text = "SEARCH";
            this.searchButton.UseCompatibleTextRendering = true;
            this.searchButton.UseVisualStyleBackColor = false;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // panel77
            // 
            this.panel77.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel77.BackColor = System.Drawing.SystemColors.Window;
            this.panel77.Controls.Add(this.searchResults);
            this.panel77.Location = new System.Drawing.Point(0, 37);
            this.panel77.Name = "panel77";
            this.panel77.Size = new System.Drawing.Size(256, 601);
            this.panel77.TabIndex = 556;
            // 
            // searchResults
            // 
            this.searchResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.searchResults.BackColor = System.Drawing.SystemColors.Window;
            this.searchResults.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.searchResults.Location = new System.Drawing.Point(4, 4);
            this.searchResults.Name = "searchResults";
            this.searchResults.ReadOnly = true;
            this.searchResults.Size = new System.Drawing.Size(248, 593);
            this.searchResults.TabIndex = 557;
            this.searchResults.Text = "";
            // 
            // panel65
            // 
            this.panel65.Controls.Add(this.panel66);
            this.panel65.Location = new System.Drawing.Point(538, 419);
            this.panel65.Name = "panel65";
            this.panel65.Size = new System.Drawing.Size(260, 229);
            this.panel65.TabIndex = 7;
            // 
            // panel66
            // 
            this.panel66.BackColor = System.Drawing.SystemColors.ControlText;
            this.panel66.Controls.Add(this.panel47);
            this.panel66.Controls.Add(this.panel13);
            this.panel66.Controls.Add(this.panel32);
            this.panel66.Controls.Add(this.generateFontTableImage);
            this.panel66.Controls.Add(this.panel73);
            this.panel66.Controls.Add(this.panel71);
            this.panel66.Controls.Add(this.label60);
            this.panel66.Location = new System.Drawing.Point(2, 2);
            this.panel66.Name = "panel66";
            this.panel66.Size = new System.Drawing.Size(256, 225);
            this.panel66.TabIndex = 540;
            // 
            // panel47
            // 
            this.panel47.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.panel47.Controls.Add(this.label76);
            this.panel47.Controls.Add(this.padding);
            this.panel47.Controls.Add(label62);
            this.panel47.Controls.Add(this.autoSetWidths);
            this.panel47.Location = new System.Drawing.Point(129, 131);
            this.panel47.Name = "panel47";
            this.panel47.Size = new System.Drawing.Size(127, 54);
            this.panel47.TabIndex = 565;
            // 
            // label76
            // 
            this.label76.BackColor = System.Drawing.SystemColors.Control;
            this.label76.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label76.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label76.Location = new System.Drawing.Point(0, 0);
            this.label76.Name = "label76";
            this.label76.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label76.Size = new System.Drawing.Size(127, 17);
            this.label76.TabIndex = 530;
            this.label76.Text = "IMAGE GENERATION";
            // 
            // padding
            // 
            this.padding.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.padding.Location = new System.Drawing.Point(80, 37);
            this.padding.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.padding.Name = "padding";
            this.padding.Size = new System.Drawing.Size(48, 17);
            this.padding.TabIndex = 64;
            this.padding.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.padding.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // autoSetWidths
            // 
            this.autoSetWidths.Appearance = System.Windows.Forms.Appearance.Button;
            this.autoSetWidths.BackColor = System.Drawing.SystemColors.Control;
            this.autoSetWidths.Checked = true;
            this.autoSetWidths.CheckState = System.Windows.Forms.CheckState.Checked;
            this.autoSetWidths.FlatAppearance.BorderSize = 0;
            this.autoSetWidths.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(168)))), ((int)(((byte)(168)))));
            this.autoSetWidths.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.autoSetWidths.Location = new System.Drawing.Point(0, 19);
            this.autoSetWidths.Name = "autoSetWidths";
            this.autoSetWidths.Size = new System.Drawing.Size(127, 17);
            this.autoSetWidths.TabIndex = 66;
            this.autoSetWidths.Text = "AUTO-SET WIDTHS";
            this.autoSetWidths.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.autoSetWidths.UseCompatibleTextRendering = true;
            this.autoSetWidths.UseVisualStyleBackColor = false;
            this.autoSetWidths.Click += new System.EventHandler(this.autoSetWidths_Click);
            // 
            // panel13
            // 
            this.panel13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.panel13.Controls.Add(this.label28);
            this.panel13.Controls.Add(panel72);
            this.panel13.Controls.Add(this.fontSize);
            this.panel13.Controls.Add(this.panel70);
            this.panel13.Location = new System.Drawing.Point(129, 19);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(127, 54);
            this.panel13.TabIndex = 564;
            // 
            // label28
            // 
            this.label28.BackColor = System.Drawing.SystemColors.Control;
            this.label28.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label28.Location = new System.Drawing.Point(0, 0);
            this.label28.Name = "label28";
            this.label28.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label28.Size = new System.Drawing.Size(127, 17);
            this.label28.TabIndex = 452;
            this.label28.Text = "FONT STYLE";
            // 
            // fontSize
            // 
            this.fontSize.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.fontSize.Location = new System.Drawing.Point(80, 37);
            this.fontSize.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.fontSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.fontSize.Name = "fontSize";
            this.fontSize.Size = new System.Drawing.Size(48, 17);
            this.fontSize.TabIndex = 64;
            this.fontSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.fontSize.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.fontSize.ValueChanged += new System.EventHandler(this.fontSize_ValueChanged);
            // 
            // panel70
            // 
            this.panel70.Controls.Add(this.fontFamily);
            this.panel70.Location = new System.Drawing.Point(0, 19);
            this.panel70.Name = "panel70";
            this.panel70.Size = new System.Drawing.Size(128, 17);
            this.panel70.TabIndex = 62;
            // 
            // fontFamily
            // 
            this.fontFamily.DropDownHeight = 392;
            this.fontFamily.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fontFamily.DropDownWidth = 176;
            this.fontFamily.FormattingEnabled = true;
            this.fontFamily.IntegralHeight = false;
            this.fontFamily.Location = new System.Drawing.Point(-2, -2);
            this.fontFamily.Name = "fontFamily";
            this.fontFamily.Size = new System.Drawing.Size(132, 21);
            this.fontFamily.TabIndex = 400;
            this.fontFamily.SelectedIndexChanged += new System.EventHandler(this.fontFamily_SelectedIndexChanged);
            // 
            // panel32
            // 
            this.panel32.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.panel32.Controls.Add(this.label61);
            this.panel32.Controls.Add(this.characterHeight);
            this.panel32.Controls.Add(this.shiftTableLeft);
            this.panel32.Controls.Add(label75);
            this.panel32.Controls.Add(this.shiftTableRight);
            this.panel32.Controls.Add(this.shiftTableDown);
            this.panel32.Controls.Add(this.resetTable);
            this.panel32.Controls.Add(this.shiftTableUp);
            this.panel32.Location = new System.Drawing.Point(129, 75);
            this.panel32.Name = "panel32";
            this.panel32.Size = new System.Drawing.Size(127, 54);
            this.panel32.TabIndex = 564;
            // 
            // label61
            // 
            this.label61.BackColor = System.Drawing.SystemColors.Control;
            this.label61.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label61.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label61.Location = new System.Drawing.Point(0, 0);
            this.label61.Name = "label61";
            this.label61.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label61.Size = new System.Drawing.Size(127, 17);
            this.label61.TabIndex = 530;
            this.label61.Text = "TABLE PROPERTIES";
            // 
            // characterHeight
            // 
            this.characterHeight.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.characterHeight.Location = new System.Drawing.Point(80, 19);
            this.characterHeight.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.characterHeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.characterHeight.Name = "characterHeight";
            this.characterHeight.Size = new System.Drawing.Size(48, 17);
            this.characterHeight.TabIndex = 64;
            this.characterHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.characterHeight.Value = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.characterHeight.ValueChanged += new System.EventHandler(this.characterHeight_ValueChanged);
            // 
            // shiftTableLeft
            // 
            this.shiftTableLeft.BackColor = System.Drawing.SystemColors.Window;
            this.shiftTableLeft.FlatAppearance.BorderSize = 0;
            this.shiftTableLeft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.shiftTableLeft.Image = global::LAZYSHELL.Properties.Resources.back;
            this.shiftTableLeft.Location = new System.Drawing.Point(40, 37);
            this.shiftTableLeft.Name = "shiftTableLeft";
            this.shiftTableLeft.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.shiftTableLeft.Size = new System.Drawing.Size(19, 17);
            this.shiftTableLeft.TabIndex = 528;
            this.toolTip1.SetToolTip(this.shiftTableLeft, "Shift font table left");
            this.shiftTableLeft.UseCompatibleTextRendering = true;
            this.shiftTableLeft.UseVisualStyleBackColor = false;
            this.shiftTableLeft.Click += new System.EventHandler(this.shiftTableLeft_Click);
            // 
            // shiftTableRight
            // 
            this.shiftTableRight.BackColor = System.Drawing.SystemColors.Window;
            this.shiftTableRight.FlatAppearance.BorderSize = 0;
            this.shiftTableRight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.shiftTableRight.Image = global::LAZYSHELL.Properties.Resources.foward;
            this.shiftTableRight.Location = new System.Drawing.Point(60, 37);
            this.shiftTableRight.Name = "shiftTableRight";
            this.shiftTableRight.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.shiftTableRight.Size = new System.Drawing.Size(19, 17);
            this.shiftTableRight.TabIndex = 529;
            this.toolTip1.SetToolTip(this.shiftTableRight, "Shift font table right");
            this.shiftTableRight.UseCompatibleTextRendering = true;
            this.shiftTableRight.UseVisualStyleBackColor = false;
            this.shiftTableRight.Click += new System.EventHandler(this.shiftTableRight_Click);
            // 
            // shiftTableDown
            // 
            this.shiftTableDown.BackColor = System.Drawing.SystemColors.Window;
            this.shiftTableDown.FlatAppearance.BorderSize = 0;
            this.shiftTableDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.shiftTableDown.Image = global::LAZYSHELL.Properties.Resources.movedown;
            this.shiftTableDown.Location = new System.Drawing.Point(20, 37);
            this.shiftTableDown.Name = "shiftTableDown";
            this.shiftTableDown.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.shiftTableDown.Size = new System.Drawing.Size(19, 17);
            this.shiftTableDown.TabIndex = 529;
            this.toolTip1.SetToolTip(this.shiftTableDown, "Shift font table down");
            this.shiftTableDown.UseCompatibleTextRendering = true;
            this.shiftTableDown.UseVisualStyleBackColor = false;
            this.shiftTableDown.Click += new System.EventHandler(this.shiftTableDown_Click);
            // 
            // resetTable
            // 
            this.resetTable.BackColor = System.Drawing.SystemColors.Window;
            this.resetTable.FlatAppearance.BorderSize = 0;
            this.resetTable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.resetTable.Location = new System.Drawing.Point(80, 37);
            this.resetTable.Name = "resetTable";
            this.resetTable.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.resetTable.Size = new System.Drawing.Size(47, 17);
            this.resetTable.TabIndex = 528;
            this.resetTable.Text = "RESET";
            this.toolTip1.SetToolTip(this.resetTable, "Reset the font table properties.");
            this.resetTable.UseCompatibleTextRendering = true;
            this.resetTable.UseVisualStyleBackColor = false;
            this.resetTable.Click += new System.EventHandler(this.resetTable_Click);
            // 
            // shiftTableUp
            // 
            this.shiftTableUp.BackColor = System.Drawing.SystemColors.Window;
            this.shiftTableUp.FlatAppearance.BorderSize = 0;
            this.shiftTableUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.shiftTableUp.Image = global::LAZYSHELL.Properties.Resources.moveup;
            this.shiftTableUp.Location = new System.Drawing.Point(0, 37);
            this.shiftTableUp.Name = "shiftTableUp";
            this.shiftTableUp.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.shiftTableUp.Size = new System.Drawing.Size(19, 17);
            this.shiftTableUp.TabIndex = 528;
            this.toolTip1.SetToolTip(this.shiftTableUp, "Shift font table up");
            this.shiftTableUp.UseCompatibleTextRendering = true;
            this.shiftTableUp.UseVisualStyleBackColor = false;
            this.shiftTableUp.Click += new System.EventHandler(this.shiftTableUp_Click);
            // 
            // generateFontTableImage
            // 
            this.generateFontTableImage.BackColor = System.Drawing.SystemColors.Control;
            this.generateFontTableImage.FlatAppearance.BorderSize = 0;
            this.generateFontTableImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.generateFontTableImage.Location = new System.Drawing.Point(129, 187);
            this.generateFontTableImage.Name = "generateFontTableImage";
            this.generateFontTableImage.Size = new System.Drawing.Size(127, 17);
            this.generateFontTableImage.TabIndex = 65;
            this.generateFontTableImage.Text = "GENERATE IMAGE";
            this.generateFontTableImage.UseCompatibleTextRendering = true;
            this.generateFontTableImage.UseVisualStyleBackColor = false;
            this.generateFontTableImage.Click += new System.EventHandler(this.generateFontTableImage_Click);
            // 
            // panel73
            // 
            this.panel73.BackColor = System.Drawing.SystemColors.Control;
            this.panel73.Location = new System.Drawing.Point(129, 206);
            this.panel73.Name = "panel73";
            this.panel73.Size = new System.Drawing.Size(127, 19);
            this.panel73.TabIndex = 527;
            // 
            // panel71
            // 
            this.panel71.BackColor = System.Drawing.SystemColors.Control;
            this.panel71.Controls.Add(this.fontTable);
            this.panel71.Location = new System.Drawing.Point(0, 19);
            this.panel71.Name = "panel71";
            this.panel71.Size = new System.Drawing.Size(128, 192);
            this.panel71.TabIndex = 525;
            // 
            // fontTable
            // 
            this.fontTable.BackColor = System.Drawing.Color.Transparent;
            this.fontTable.Location = new System.Drawing.Point(0, 0);
            this.fontTable.Name = "fontTable";
            this.fontTable.Size = new System.Drawing.Size(128, 192);
            this.fontTable.TabIndex = 523;
            // 
            // label60
            // 
            this.label60.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label60.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label60.ForeColor = System.Drawing.SystemColors.Control;
            this.label60.Location = new System.Drawing.Point(0, 0);
            this.label60.Name = "label60";
            this.label60.Padding = new System.Windows.Forms.Padding(2, 2, 0, 0);
            this.label60.Size = new System.Drawing.Size(256, 17);
            this.label60.TabIndex = 461;
            this.label60.Text = "CREATE FONT TABLE";
            // 
            // panel203
            // 
            this.panel203.Controls.Add(this.label119);
            this.panel203.Controls.Add(this.dialogueNum);
            this.panel203.Location = new System.Drawing.Point(6, 6);
            this.panel203.Name = "panel203";
            this.panel203.Size = new System.Drawing.Size(260, 21);
            this.panel203.TabIndex = 0;
            // 
            // label119
            // 
            this.label119.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label119.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label119.ForeColor = System.Drawing.SystemColors.Control;
            this.label119.Location = new System.Drawing.Point(2, 2);
            this.label119.Name = "label119";
            this.label119.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.label119.Size = new System.Drawing.Size(179, 17);
            this.label119.TabIndex = 517;
            this.label119.Text = "DIALOGUE #";
            // 
            // dialogueNum
            // 
            this.dialogueNum.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dialogueNum.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dialogueNum.ContextMenuStrip = this.contextMenuStrip2;
            this.dialogueNum.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dialogueNum.ForeColor = System.Drawing.SystemColors.Control;
            this.dialogueNum.Location = new System.Drawing.Point(182, 2);
            this.dialogueNum.Maximum = new decimal(new int[] {
            4095,
            0,
            0,
            0});
            this.dialogueNum.Name = "dialogueNum";
            this.dialogueNum.Size = new System.Drawing.Size(77, 17);
            this.dialogueNum.TabIndex = 1;
            this.dialogueNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.dialogueNum.ValueChanged += new System.EventHandler(this.dialogueNum_ValueChanged);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addThisToNotesDatabaseToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.contextMenuStrip2.ShowImageMargin = false;
            this.contextMenuStrip2.Size = new System.Drawing.Size(192, 26);
            // 
            // addThisToNotesDatabaseToolStripMenuItem
            // 
            this.addThisToNotesDatabaseToolStripMenuItem.Name = "addThisToNotesDatabaseToolStripMenuItem";
            this.addThisToNotesDatabaseToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.addThisToNotesDatabaseToolStripMenuItem.Text = "Add this to notes database...";
            this.addThisToNotesDatabaseToolStripMenuItem.Click += new System.EventHandler(this.addThisToNotesDatabaseToolStripMenuItem_Click);
            // 
            // panel202
            // 
            this.panel202.Controls.Add(this.panel60);
            this.panel202.Controls.Add(this.panelDialogueInsert);
            this.panel202.Location = new System.Drawing.Point(6, 33);
            this.panel202.Name = "panel202";
            this.panel202.Size = new System.Drawing.Size(260, 259);
            this.panel202.TabIndex = 1;
            // 
            // panel60
            // 
            this.panel60.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.panel60.Controls.Add(this.byteOrTextView);
            this.panel60.Controls.Add(this.panel69);
            this.panel60.Controls.Add(this.listBox1);
            this.panel60.Controls.Add(this.dialoguePreviewPageDown);
            this.panel60.Controls.Add(this.label196);
            this.panel60.Controls.Add(this.dialoguePreviewPageUp);
            this.panel60.Controls.Add(this.panel61);
            this.panel60.Location = new System.Drawing.Point(2, 2);
            this.panel60.Name = "panel60";
            this.panel60.Size = new System.Drawing.Size(256, 218);
            this.panel60.TabIndex = 216;
            // 
            // byteOrTextView
            // 
            this.byteOrTextView.Appearance = System.Windows.Forms.Appearance.Button;
            this.byteOrTextView.BackColor = System.Drawing.SystemColors.Control;
            this.byteOrTextView.FlatAppearance.BorderSize = 0;
            this.byteOrTextView.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(168)))), ((int)(((byte)(168)))));
            this.byteOrTextView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.byteOrTextView.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.byteOrTextView.Location = new System.Drawing.Point(180, 58);
            this.byteOrTextView.Name = "byteOrTextView";
            this.byteOrTextView.Size = new System.Drawing.Size(76, 16);
            this.byteOrTextView.TabIndex = 3;
            this.byteOrTextView.Text = "TEXT VIEW";
            this.byteOrTextView.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.byteOrTextView.UseCompatibleTextRendering = true;
            this.byteOrTextView.UseVisualStyleBackColor = false;
            this.byteOrTextView.Click += new System.EventHandler(this.byteOrTextView_Click);
            // 
            // panel69
            // 
            this.panel69.BackColor = System.Drawing.SystemColors.Control;
            this.panel69.Controls.Add(this.pictureBoxDialogue);
            this.panel69.Location = new System.Drawing.Point(0, 0);
            this.panel69.Name = "panel69";
            this.panel69.Size = new System.Drawing.Size(240, 56);
            this.panel69.TabIndex = 537;
            // 
            // pictureBoxDialogue
            // 
            this.pictureBoxDialogue.BackColor = System.Drawing.Color.Black;
            this.pictureBoxDialogue.Location = new System.Drawing.Point(-8, 0);
            this.pictureBoxDialogue.Name = "pictureBoxDialogue";
            this.pictureBoxDialogue.Size = new System.Drawing.Size(256, 56);
            this.pictureBoxDialogue.TabIndex = 521;
            this.pictureBoxDialogue.TabStop = false;
            this.pictureBoxDialogue.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxDialogue_Paint);
            // 
            // listBox1
            // 
            this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Items.AddRange(new object[] {
            "End string (A)",
            "End string",
            "New line (A)",
            "New line",
            "New page (A)",
            "New page",
            "Pause (A)",
            "Delay",
            "Option"});
            this.listBox1.Location = new System.Drawing.Point(180, 75);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(76, 143);
            this.listBox1.TabIndex = 5;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // dialoguePreviewPageDown
            // 
            this.dialoguePreviewPageDown.BackColor = System.Drawing.SystemColors.Control;
            this.dialoguePreviewPageDown.FlatAppearance.BorderSize = 0;
            this.dialoguePreviewPageDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dialoguePreviewPageDown.Image = global::LAZYSHELL.Properties.Resources.movedown;
            this.dialoguePreviewPageDown.Location = new System.Drawing.Point(241, 29);
            this.dialoguePreviewPageDown.Name = "dialoguePreviewPageDown";
            this.dialoguePreviewPageDown.Padding = new System.Windows.Forms.Padding(0, 0, 1, 0);
            this.dialoguePreviewPageDown.Size = new System.Drawing.Size(15, 28);
            this.dialoguePreviewPageDown.TabIndex = 2;
            this.toolTip1.SetToolTip(this.dialoguePreviewPageDown, "Move down");
            this.dialoguePreviewPageDown.UseCompatibleTextRendering = true;
            this.dialoguePreviewPageDown.UseVisualStyleBackColor = false;
            this.dialoguePreviewPageDown.Click += new System.EventHandler(this.dialoguePreviewPageDown_Click);
            // 
            // label196
            // 
            this.label196.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label196.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label196.ForeColor = System.Drawing.SystemColors.Control;
            this.label196.Location = new System.Drawing.Point(0, 58);
            this.label196.Name = "label196";
            this.label196.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label196.Size = new System.Drawing.Size(179, 16);
            this.label196.TabIndex = 536;
            // 
            // dialoguePreviewPageUp
            // 
            this.dialoguePreviewPageUp.BackColor = System.Drawing.SystemColors.Control;
            this.dialoguePreviewPageUp.FlatAppearance.BorderSize = 0;
            this.dialoguePreviewPageUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dialoguePreviewPageUp.Image = global::LAZYSHELL.Properties.Resources.moveup;
            this.dialoguePreviewPageUp.Location = new System.Drawing.Point(241, 0);
            this.dialoguePreviewPageUp.Name = "dialoguePreviewPageUp";
            this.dialoguePreviewPageUp.Padding = new System.Windows.Forms.Padding(0, 0, 1, 0);
            this.dialoguePreviewPageUp.Size = new System.Drawing.Size(15, 28);
            this.dialoguePreviewPageUp.TabIndex = 1;
            this.toolTip1.SetToolTip(this.dialoguePreviewPageUp, "Move up");
            this.dialoguePreviewPageUp.UseCompatibleTextRendering = true;
            this.dialoguePreviewPageUp.UseVisualStyleBackColor = false;
            this.dialoguePreviewPageUp.Click += new System.EventHandler(this.dialoguePreviewPageUp_Click);
            // 
            // panel61
            // 
            this.panel61.BackColor = System.Drawing.SystemColors.Window;
            this.panel61.Controls.Add(this.dialogueTextBox);
            this.panel61.Location = new System.Drawing.Point(0, 75);
            this.panel61.Name = "panel61";
            this.panel61.Size = new System.Drawing.Size(179, 143);
            this.panel61.TabIndex = 4;
            // 
            // dialogueTextBox
            // 
            this.dialogueTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dialogueTextBox.Location = new System.Drawing.Point(4, 4);
            this.dialogueTextBox.Name = "dialogueTextBox";
            this.dialogueTextBox.Size = new System.Drawing.Size(171, 135);
            this.dialogueTextBox.TabIndex = 178;
            this.dialogueTextBox.Text = "";
            this.dialogueTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dialogueTextBox_KeyDown);
            this.dialogueTextBox.Enter += new System.EventHandler(this.dialogueTextBox_Enter);
            this.dialogueTextBox.Leave += new System.EventHandler(this.dialogueTextBox_Leave);
            this.dialogueTextBox.TextChanged += new System.EventHandler(this.dialogueTextBox_TextChanged);
            // 
            // panelDialogueInsert
            // 
            this.panelDialogueInsert.Controls.Add(this.panelDialogueMemory);
            this.panelDialogueInsert.Controls.Add(this.buttonInsertVAR);
            this.panelDialogueInsert.Controls.Add(this.buttonInsertFD);
            this.panelDialogueInsert.Controls.Add(this.dialogueByteValue);
            this.panelDialogueInsert.Controls.Add(this.label118);
            this.panelDialogueInsert.Controls.Add(this.labelDialogueInsert);
            this.panelDialogueInsert.Location = new System.Drawing.Point(0, 220);
            this.panelDialogueInsert.Name = "panelDialogueInsert";
            this.panelDialogueInsert.Size = new System.Drawing.Size(259, 37);
            this.panelDialogueInsert.TabIndex = 563;
            // 
            // panelDialogueMemory
            // 
            this.panelDialogueMemory.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panelDialogueMemory.Controls.Add(this.dialogueMemory);
            this.panelDialogueMemory.Location = new System.Drawing.Point(157, 20);
            this.panelDialogueMemory.Name = "panelDialogueMemory";
            this.panelDialogueMemory.Size = new System.Drawing.Size(100, 17);
            this.panelDialogueMemory.TabIndex = 139;
            // 
            // dialogueMemory
            // 
            this.dialogueMemory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dialogueMemory.DropDownWidth = 140;
            this.dialogueMemory.FormattingEnabled = true;
            this.dialogueMemory.Items.AddRange(new object[] {
            "Item name at 00:70A7",
            "Value at 00:7000",
            "Value at 00:7024"});
            this.dialogueMemory.Location = new System.Drawing.Point(-3, -2);
            this.dialogueMemory.Name = "dialogueMemory";
            this.dialogueMemory.Size = new System.Drawing.Size(106, 21);
            this.dialogueMemory.TabIndex = 119;
            // 
            // buttonInsertVAR
            // 
            this.buttonInsertVAR.BackColor = System.Drawing.SystemColors.Window;
            this.buttonInsertVAR.FlatAppearance.BorderSize = 0;
            this.buttonInsertVAR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonInsertVAR.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonInsertVAR.Location = new System.Drawing.Point(2, 20);
            this.buttonInsertVAR.Name = "buttonInsertVAR";
            this.buttonInsertVAR.Size = new System.Drawing.Size(52, 17);
            this.buttonInsertVAR.TabIndex = 140;
            this.buttonInsertVAR.Text = "INSERT";
            this.buttonInsertVAR.UseCompatibleTextRendering = true;
            this.buttonInsertVAR.UseVisualStyleBackColor = false;
            this.buttonInsertVAR.Click += new System.EventHandler(this.buttonInsertVAR_Click);
            // 
            // buttonInsertFD
            // 
            this.buttonInsertFD.BackColor = System.Drawing.SystemColors.Window;
            this.buttonInsertFD.FlatAppearance.BorderSize = 0;
            this.buttonInsertFD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonInsertFD.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonInsertFD.Location = new System.Drawing.Point(2, 2);
            this.buttonInsertFD.Name = "buttonInsertFD";
            this.buttonInsertFD.Size = new System.Drawing.Size(52, 17);
            this.buttonInsertFD.TabIndex = 140;
            this.buttonInsertFD.Text = "INSERT";
            this.buttonInsertFD.UseCompatibleTextRendering = true;
            this.buttonInsertFD.UseVisualStyleBackColor = false;
            this.buttonInsertFD.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // dialogueByteValue
            // 
            this.dialogueByteValue.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dialogueByteValue.Location = new System.Drawing.Point(157, 2);
            this.dialogueByteValue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.dialogueByteValue.Name = "dialogueByteValue";
            this.dialogueByteValue.Size = new System.Drawing.Size(101, 17);
            this.dialogueByteValue.TabIndex = 138;
            this.dialogueByteValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label118
            // 
            this.label118.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label118.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label118.Location = new System.Drawing.Point(55, 20);
            this.label118.Name = "label118";
            this.label118.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label118.Size = new System.Drawing.Size(101, 17);
            this.label118.TabIndex = 142;
            this.label118.Text = "Variable";
            // 
            // labelDialogueInsert
            // 
            this.labelDialogueInsert.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.labelDialogueInsert.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelDialogueInsert.Location = new System.Drawing.Point(55, 2);
            this.labelDialogueInsert.Name = "labelDialogueInsert";
            this.labelDialogueInsert.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.labelDialogueInsert.Size = new System.Drawing.Size(101, 17);
            this.labelDialogueInsert.TabIndex = 142;
            this.labelDialogueInsert.Text = "Frame delay";
            // 
            // panel201
            // 
            this.panel201.Controls.Add(this.panel62);
            this.panel201.Location = new System.Drawing.Point(6, 347);
            this.panel201.Name = "panel201";
            this.panel201.Size = new System.Drawing.Size(260, 122);
            this.panel201.TabIndex = 4;
            // 
            // panel62
            // 
            this.panel62.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.panel62.Controls.Add(this.listBox2);
            this.panel62.Controls.Add(this.pictureBoxBattleDialogue);
            this.panel62.Controls.Add(this.battleDialoguePageUp);
            this.panel62.Controls.Add(this.panel63);
            this.panel62.Controls.Add(this.label187);
            this.panel62.Controls.Add(this.battleDialoguePageDown);
            this.panel62.Location = new System.Drawing.Point(2, 2);
            this.panel62.Name = "panel62";
            this.panel62.Size = new System.Drawing.Size(256, 118);
            this.panel62.TabIndex = 257;
            // 
            // listBox2
            // 
            this.listBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Items.AddRange(new object[] {
            "End string",
            "New line",
            "Pause (A)",
            "Delay (A)",
            "Delay"});
            this.listBox2.Location = new System.Drawing.Point(180, 53);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(76, 65);
            this.listBox2.TabIndex = 4;
            this.listBox2.SelectedIndexChanged += new System.EventHandler(this.listBox2_SelectedIndexChanged);
            // 
            // pictureBoxBattleDialogue
            // 
            this.pictureBoxBattleDialogue.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxBattleDialogue.Name = "pictureBoxBattleDialogue";
            this.pictureBoxBattleDialogue.Size = new System.Drawing.Size(256, 32);
            this.pictureBoxBattleDialogue.TabIndex = 520;
            this.pictureBoxBattleDialogue.TabStop = false;
            this.pictureBoxBattleDialogue.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxBattleDialogue_Paint);
            // 
            // battleDialoguePageUp
            // 
            this.battleDialoguePageUp.BackColor = System.Drawing.SystemColors.Control;
            this.battleDialoguePageUp.FlatAppearance.BorderSize = 0;
            this.battleDialoguePageUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.battleDialoguePageUp.Image = global::LAZYSHELL.Properties.Resources.back;
            this.battleDialoguePageUp.Location = new System.Drawing.Point(-1, 34);
            this.battleDialoguePageUp.Name = "battleDialoguePageUp";
            this.battleDialoguePageUp.Padding = new System.Windows.Forms.Padding(0, 0, 1, 0);
            this.battleDialoguePageUp.Size = new System.Drawing.Size(22, 17);
            this.battleDialoguePageUp.TabIndex = 1;
            this.toolTip1.SetToolTip(this.battleDialoguePageUp, "Move back");
            this.battleDialoguePageUp.UseCompatibleTextRendering = true;
            this.battleDialoguePageUp.UseVisualStyleBackColor = false;
            this.battleDialoguePageUp.Click += new System.EventHandler(this.battleDialoguePageUp_Click);
            // 
            // panel63
            // 
            this.panel63.BackColor = System.Drawing.SystemColors.Window;
            this.panel63.Controls.Add(this.battleDialogueTextBox);
            this.panel63.Location = new System.Drawing.Point(0, 53);
            this.panel63.Name = "panel63";
            this.panel63.Size = new System.Drawing.Size(179, 65);
            this.panel63.TabIndex = 3;
            // 
            // battleDialogueTextBox
            // 
            this.battleDialogueTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.battleDialogueTextBox.Location = new System.Drawing.Point(4, 4);
            this.battleDialogueTextBox.Name = "battleDialogueTextBox";
            this.battleDialogueTextBox.Size = new System.Drawing.Size(171, 57);
            this.battleDialogueTextBox.TabIndex = 1;
            this.battleDialogueTextBox.Text = "";
            this.battleDialogueTextBox.Leave += new System.EventHandler(this.battleDialogueTextBox_Leave);
            this.battleDialogueTextBox.TextChanged += new System.EventHandler(this.battleDialogueTextBox_TextChanged);
            // 
            // label187
            // 
            this.label187.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label187.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label187.ForeColor = System.Drawing.SystemColors.Control;
            this.label187.Location = new System.Drawing.Point(22, 34);
            this.label187.Name = "label187";
            this.label187.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label187.Size = new System.Drawing.Size(211, 17);
            this.label187.TabIndex = 536;
            // 
            // battleDialoguePageDown
            // 
            this.battleDialoguePageDown.BackColor = System.Drawing.SystemColors.Control;
            this.battleDialoguePageDown.FlatAppearance.BorderSize = 0;
            this.battleDialoguePageDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.battleDialoguePageDown.Image = global::LAZYSHELL.Properties.Resources.foward;
            this.battleDialoguePageDown.Location = new System.Drawing.Point(234, 34);
            this.battleDialoguePageDown.Name = "battleDialoguePageDown";
            this.battleDialoguePageDown.Size = new System.Drawing.Size(22, 17);
            this.battleDialoguePageDown.TabIndex = 2;
            this.toolTip1.SetToolTip(this.battleDialoguePageDown, "Move forward");
            this.battleDialoguePageDown.UseCompatibleTextRendering = true;
            this.battleDialoguePageDown.UseVisualStyleBackColor = false;
            this.battleDialoguePageDown.Click += new System.EventHandler(this.battleDialoguePageDown_Click);
            // 
            // panel200
            // 
            this.panel200.Controls.Add(this.panel113);
            this.panel200.Controls.Add(this.panel126);
            this.panel200.Controls.Add(this.battleDialogueNum);
            this.panel200.Location = new System.Drawing.Point(6, 301);
            this.panel200.Name = "panel200";
            this.panel200.Size = new System.Drawing.Size(260, 40);
            this.panel200.TabIndex = 3;
            // 
            // panel113
            // 
            this.panel113.Controls.Add(this.battleDlgType);
            this.panel113.Location = new System.Drawing.Point(2, 2);
            this.panel113.Name = "panel113";
            this.panel113.Size = new System.Drawing.Size(179, 17);
            this.panel113.TabIndex = 3;
            // 
            // battleDlgType
            // 
            this.battleDlgType.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.battleDlgType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.battleDlgType.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.battleDlgType.ForeColor = System.Drawing.SystemColors.Control;
            this.battleDlgType.IntegralHeight = false;
            this.battleDlgType.Items.AddRange(new object[] {
            "BATTLE DIALOGUE",
            "BATTLE MESSAGES"});
            this.battleDlgType.Location = new System.Drawing.Point(-2, -2);
            this.battleDlgType.Name = "battleDlgType";
            this.battleDlgType.Size = new System.Drawing.Size(183, 21);
            this.battleDlgType.TabIndex = 359;
            this.battleDlgType.SelectedIndexChanged += new System.EventHandler(this.battleDlgType_SelectedIndexChanged);
            // 
            // panel126
            // 
            this.panel126.Controls.Add(this.battleDialogueName);
            this.panel126.Location = new System.Drawing.Point(2, 21);
            this.panel126.Name = "panel126";
            this.panel126.Size = new System.Drawing.Size(257, 17);
            this.panel126.TabIndex = 2;
            // 
            // battleDialogueName
            // 
            this.battleDialogueName.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.battleDialogueName.DropDownHeight = 392;
            this.battleDialogueName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.battleDialogueName.DropDownWidth = 300;
            this.battleDialogueName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.battleDialogueName.ForeColor = System.Drawing.SystemColors.Control;
            this.battleDialogueName.IntegralHeight = false;
            this.battleDialogueName.Location = new System.Drawing.Point(-2, -2);
            this.battleDialogueName.Name = "battleDialogueName";
            this.battleDialogueName.Size = new System.Drawing.Size(261, 21);
            this.battleDialogueName.TabIndex = 359;
            this.battleDialogueName.SelectedIndexChanged += new System.EventHandler(this.battleDialogueName_SelectedIndexChanged);
            // 
            // battleDialogueNum
            // 
            this.battleDialogueNum.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.battleDialogueNum.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.battleDialogueNum.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.battleDialogueNum.ForeColor = System.Drawing.SystemColors.Control;
            this.battleDialogueNum.Location = new System.Drawing.Point(182, 2);
            this.battleDialogueNum.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.battleDialogueNum.Name = "battleDialogueNum";
            this.battleDialogueNum.Size = new System.Drawing.Size(77, 17);
            this.battleDialogueNum.TabIndex = 1;
            this.battleDialogueNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.battleDialogueNum.ValueChanged += new System.EventHandler(this.battleDialogueNum_ValueChanged);
            // 
            // panel59
            // 
            this.panel59.Controls.Add(this.panel58);
            this.panel59.Controls.Add(label53);
            this.panel59.Location = new System.Drawing.Point(6, 479);
            this.panel59.Name = "panel59";
            this.panel59.Size = new System.Drawing.Size(260, 169);
            this.panel59.TabIndex = 9;
            // 
            // panel58
            // 
            this.panel58.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.panel58.Controls.Add(this.panel12);
            this.panel58.Controls.Add(this.pictureBoxBattle);
            this.panel58.Location = new System.Drawing.Point(2, 21);
            this.panel58.Name = "panel58";
            this.panel58.Size = new System.Drawing.Size(256, 146);
            this.panel58.TabIndex = 526;
            // 
            // panel12
            // 
            this.panel12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.panel12.Controls.Add(this.panel24);
            this.panel12.Controls.Add(this.pictureBoxDialogueTile);
            this.panel12.Controls.Add(this.dialogueSubtile);
            this.panel12.Controls.Add(this.panel22);
            this.panel12.Controls.Add(this.dialogueProperties);
            this.panel12.Controls.Add(this.pictureBoxDialogueSubtile);
            this.panel12.Controls.Add(this.label25);
            this.panel12.Controls.Add(this.pictureBoxDialogueBG);
            this.panel12.Location = new System.Drawing.Point(0, 34);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(256, 112);
            this.panel12.TabIndex = 529;
            // 
            // panel24
            // 
            this.panel24.BackColor = System.Drawing.SystemColors.Control;
            this.panel24.Location = new System.Drawing.Point(0, 101);
            this.panel24.Name = "panel24";
            this.panel24.Size = new System.Drawing.Size(127, 11);
            this.panel24.TabIndex = 522;
            // 
            // pictureBoxDialogueTile
            // 
            this.pictureBoxDialogueTile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.pictureBoxDialogueTile.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxDialogueTile.Name = "pictureBoxDialogueTile";
            this.pictureBoxDialogueTile.Size = new System.Drawing.Size(32, 32);
            this.pictureBoxDialogueTile.TabIndex = 521;
            this.pictureBoxDialogueTile.TabStop = false;
            this.pictureBoxDialogueTile.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBoxDialogueTile_MouseClick);
            this.pictureBoxDialogueTile.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxDialogueTile_Paint);
            // 
            // dialogueSubtile
            // 
            this.dialogueSubtile.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dialogueSubtile.Location = new System.Drawing.Point(66, 34);
            this.dialogueSubtile.Maximum = new decimal(new int[] {
            55,
            0,
            0,
            0});
            this.dialogueSubtile.Name = "dialogueSubtile";
            this.dialogueSubtile.Size = new System.Drawing.Size(61, 17);
            this.dialogueSubtile.TabIndex = 67;
            this.dialogueSubtile.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.dialogueSubtile.ValueChanged += new System.EventHandler(this.dialogueSubtile_ValueChanged);
            // 
            // panel22
            // 
            this.panel22.BackColor = System.Drawing.SystemColors.Control;
            this.panel22.Location = new System.Drawing.Point(66, 0);
            this.panel22.Name = "panel22";
            this.panel22.Size = new System.Drawing.Size(61, 32);
            this.panel22.TabIndex = 522;
            // 
            // dialogueProperties
            // 
            this.dialogueProperties.BackColor = System.Drawing.SystemColors.Window;
            this.dialogueProperties.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dialogueProperties.CheckOnClick = true;
            this.dialogueProperties.ColumnWidth = 60;
            this.dialogueProperties.Items.AddRange(new object[] {
            "Priority 1",
            "Mirror",
            "Invert"});
            this.dialogueProperties.Location = new System.Drawing.Point(0, 52);
            this.dialogueProperties.Name = "dialogueProperties";
            this.dialogueProperties.Size = new System.Drawing.Size(127, 48);
            this.dialogueProperties.TabIndex = 68;
            this.dialogueProperties.SelectedIndexChanged += new System.EventHandler(this.dialogueProperties_SelectedIndexChanged);
            // 
            // pictureBoxDialogueSubtile
            // 
            this.pictureBoxDialogueSubtile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.pictureBoxDialogueSubtile.Location = new System.Drawing.Point(33, 0);
            this.pictureBoxDialogueSubtile.Name = "pictureBoxDialogueSubtile";
            this.pictureBoxDialogueSubtile.Size = new System.Drawing.Size(32, 32);
            this.pictureBoxDialogueSubtile.TabIndex = 521;
            this.pictureBoxDialogueSubtile.TabStop = false;
            this.pictureBoxDialogueSubtile.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxDialogueSubtile_Paint);
            // 
            // label25
            // 
            this.label25.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label25.Location = new System.Drawing.Point(0, 34);
            this.label25.Name = "label25";
            this.label25.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.label25.Size = new System.Drawing.Size(65, 17);
            this.label25.TabIndex = 516;
            this.label25.Text = "Subtile";
            // 
            // pictureBoxDialogueBG
            // 
            this.pictureBoxDialogueBG.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.pictureBoxDialogueBG.ContextMenuStrip = this.contextMenuStripGR;
            this.pictureBoxDialogueBG.Location = new System.Drawing.Point(128, 0);
            this.pictureBoxDialogueBG.Name = "pictureBoxDialogueBG";
            this.pictureBoxDialogueBG.Size = new System.Drawing.Size(128, 112);
            this.pictureBoxDialogueBG.TabIndex = 468;
            this.pictureBoxDialogueBG.TabStop = false;
            this.pictureBoxDialogueBG.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxDialogueBG_MouseMove);
            this.pictureBoxDialogueBG.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pictureBoxDialogueBG_MouseDoubleClick);
            this.pictureBoxDialogueBG.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxDialogueBG_Paint);
            // 
            // pictureBoxBattle
            // 
            this.pictureBoxBattle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.pictureBoxBattle.ContextMenuStrip = this.contextMenuStrip;
            this.pictureBoxBattle.Cursor = System.Windows.Forms.Cursors.Cross;
            this.pictureBoxBattle.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxBattle.Name = "pictureBoxBattle";
            this.pictureBoxBattle.Size = new System.Drawing.Size(256, 32);
            this.pictureBoxBattle.TabIndex = 467;
            this.pictureBoxBattle.TabStop = false;
            this.pictureBoxBattle.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.pictureBoxBattle_PreviewKeyDown);
            this.pictureBoxBattle.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxBattle_MouseMove);
            this.pictureBoxBattle.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBoxBattle_MouseClick);
            this.pictureBoxBattle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxBattle_MouseDown);
            this.pictureBoxBattle.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxBattle_Paint);
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.panel30);
            this.panel9.Location = new System.Drawing.Point(538, 143);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(260, 270);
            this.panel9.TabIndex = 6;
            // 
            // panel30
            // 
            this.panel30.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.panel30.Controls.Add(this.panel114);
            this.panel30.Controls.Add(this.panel112);
            this.panel30.Controls.Add(this.label34);
            this.panel30.Controls.Add(this.pictureBoxFont);
            this.panel30.Controls.Add(this.panel25);
            this.panel30.Controls.Add(panel2);
            this.panel30.Controls.Add(this.label33);
            this.panel30.Controls.Add(this.label42);
            this.panel30.Controls.Add(this.panel15);
            this.panel30.Controls.Add(this.fontWidth);
            this.panel30.Controls.Add(label27);
            this.panel30.Location = new System.Drawing.Point(2, 2);
            this.panel30.Name = "panel30";
            this.panel30.Size = new System.Drawing.Size(256, 266);
            this.panel30.TabIndex = 61;
            // 
            // panel114
            // 
            this.panel114.BackColor = System.Drawing.SystemColors.Control;
            this.panel114.Controls.Add(this.toolStrip7);
            this.panel114.Location = new System.Drawing.Point(86, 37);
            this.panel114.Name = "panel114";
            this.panel114.Size = new System.Drawing.Size(42, 17);
            this.panel114.TabIndex = 528;
            // 
            // toolStrip7
            // 
            this.toolStrip7.AutoSize = false;
            this.toolStrip7.CanOverflow = false;
            this.toolStrip7.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip7.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip7.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openKeystrokes,
            this.saveKeystrokes});
            this.toolStrip7.Location = new System.Drawing.Point(0, -2);
            this.toolStrip7.Name = "toolStrip7";
            this.toolStrip7.Padding = new System.Windows.Forms.Padding(0);
            this.toolStrip7.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip7.Size = new System.Drawing.Size(42, 21);
            this.toolStrip7.TabIndex = 51;
            this.toolStrip7.TabStop = true;
            this.toolStrip7.Text = "toolStrip1";
            // 
            // openKeystrokes
            // 
            this.openKeystrokes.AutoSize = false;
            this.openKeystrokes.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openKeystrokes.Image = global::LAZYSHELL.Properties.Resources.open_small;
            this.openKeystrokes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.openKeystrokes.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openKeystrokes.Name = "openKeystrokes";
            this.openKeystrokes.Size = new System.Drawing.Size(21, 17);
            this.openKeystrokes.Text = "Open keystroke table...";
            this.openKeystrokes.Click += new System.EventHandler(this.openKeystrokes_Click);
            // 
            // saveKeystrokes
            // 
            this.saveKeystrokes.AutoSize = false;
            this.saveKeystrokes.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveKeystrokes.Image = global::LAZYSHELL.Properties.Resources.save_small;
            this.saveKeystrokes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.saveKeystrokes.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveKeystrokes.Name = "saveKeystrokes";
            this.saveKeystrokes.Size = new System.Drawing.Size(21, 17);
            this.saveKeystrokes.Text = "Save keystroke table...";
            this.saveKeystrokes.Click += new System.EventHandler(this.saveKeystrokes_Click);
            // 
            // panel112
            // 
            this.panel112.BackColor = System.Drawing.SystemColors.Window;
            this.panel112.Controls.Add(this.charKeystroke);
            this.panel112.Location = new System.Drawing.Point(59, 37);
            this.panel112.Name = "panel112";
            this.panel112.Size = new System.Drawing.Size(26, 17);
            this.panel112.TabIndex = 527;
            // 
            // charKeystroke
            // 
            this.charKeystroke.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.charKeystroke.Location = new System.Drawing.Point(4, 2);
            this.charKeystroke.MaxLength = 1;
            this.charKeystroke.Name = "charKeystroke";
            this.charKeystroke.Size = new System.Drawing.Size(18, 14);
            this.charKeystroke.TabIndex = 4;
            this.charKeystroke.TextChanged += new System.EventHandler(this.charKeystroke_TextChanged);
            this.charKeystroke.Leave += new System.EventHandler(this.charKeystroke_Leave);
            // 
            // label34
            // 
            this.label34.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label34.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label34.Location = new System.Drawing.Point(0, 37);
            this.label34.Name = "label34";
            this.label34.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label34.Size = new System.Drawing.Size(58, 17);
            this.label34.TabIndex = 526;
            this.label34.Text = "Keystroke";
            // 
            // pictureBoxFont
            // 
            this.pictureBoxFont.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.pictureBoxFont.ContextMenuStrip = this.contextMenuStripGR;
            this.pictureBoxFont.Location = new System.Drawing.Point(0, 74);
            this.pictureBoxFont.Name = "pictureBoxFont";
            this.pictureBoxFont.Size = new System.Drawing.Size(128, 192);
            this.pictureBoxFont.TabIndex = 447;
            this.pictureBoxFont.TabStop = false;
            this.pictureBoxFont.MouseLeave += new System.EventHandler(this.pictureBoxFont_MouseLeave);
            this.pictureBoxFont.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxFont_MouseMove);
            this.pictureBoxFont.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBoxFont_MouseClick);
            this.pictureBoxFont.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxFont_Paint);
            this.pictureBoxFont.MouseEnter += new System.EventHandler(this.pictureBoxFont_MouseEnter);
            // 
            // panel25
            // 
            this.panel25.AutoScroll = true;
            this.panel25.BackColor = System.Drawing.SystemColors.Control;
            this.panel25.Controls.Add(this.pictureBoxFontEditor);
            this.panel25.Location = new System.Drawing.Point(129, 74);
            this.panel25.Name = "panel25";
            this.panel25.Size = new System.Drawing.Size(127, 192);
            this.panel25.TabIndex = 523;
            this.panel25.Scroll += new System.Windows.Forms.ScrollEventHandler(this.panel25_Scroll);
            // 
            // pictureBoxFontEditor
            // 
            this.pictureBoxFontEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.pictureBoxFontEditor.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxFontEditor.Name = "pictureBoxFontEditor";
            this.pictureBoxFontEditor.Size = new System.Drawing.Size(16, 12);
            this.pictureBoxFontEditor.TabIndex = 447;
            this.pictureBoxFontEditor.TabStop = false;
            this.pictureBoxFontEditor.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.pictureBoxFontEditor_PreviewKeyDown);
            this.pictureBoxFontEditor.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxFontEditor_MouseMove);
            this.pictureBoxFontEditor.Click += new System.EventHandler(this.pictureBoxFontEditor_Click);
            this.pictureBoxFontEditor.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxFontEditor_MouseDown);
            this.pictureBoxFontEditor.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxFontEditor_Paint);
            this.pictureBoxFontEditor.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBoxFontEditor_MouseUp);
            // 
            // label33
            // 
            this.label33.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label33.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label33.ForeColor = System.Drawing.SystemColors.Control;
            this.label33.Location = new System.Drawing.Point(0, 0);
            this.label33.Name = "label33";
            this.label33.Padding = new System.Windows.Forms.Padding(2, 2, 0, 0);
            this.label33.Size = new System.Drawing.Size(256, 17);
            this.label33.TabIndex = 461;
            this.label33.Text = "FONT GRAPHICS";
            // 
            // label42
            // 
            this.label42.BackColor = System.Drawing.SystemColors.Control;
            this.label42.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label42.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label42.Location = new System.Drawing.Point(0, 19);
            this.label42.Name = "label42";
            this.label42.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label42.Size = new System.Drawing.Size(128, 17);
            this.label42.TabIndex = 452;
            this.label42.Text = "FONT TYPE";
            // 
            // panel15
            // 
            this.panel15.Controls.Add(this.fontType);
            this.panel15.Location = new System.Drawing.Point(129, 19);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(128, 17);
            this.panel15.TabIndex = 62;
            // 
            // fontType
            // 
            this.fontType.BackColor = System.Drawing.SystemColors.Control;
            this.fontType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fontType.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fontType.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.fontType.FormattingEnabled = true;
            this.fontType.Items.AddRange(new object[] {
            "Menu",
            "Dialogue",
            "Descriptions",
            "Triangles"});
            this.fontType.Location = new System.Drawing.Point(-2, -2);
            this.fontType.Name = "fontType";
            this.fontType.Size = new System.Drawing.Size(132, 21);
            this.fontType.TabIndex = 400;
            this.fontType.SelectedIndexChanged += new System.EventHandler(this.fontType_SelectedIndexChanged);
            // 
            // fontWidth
            // 
            this.fontWidth.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.fontWidth.Location = new System.Drawing.Point(194, 37);
            this.fontWidth.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.fontWidth.Name = "fontWidth";
            this.fontWidth.Size = new System.Drawing.Size(63, 17);
            this.fontWidth.TabIndex = 63;
            this.fontWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.fontWidth.ValueChanged += new System.EventHandler(this.fontWidth_ValueChanged);
            // 
            // panel46
            // 
            this.panel46.Controls.Add(this.panel23);
            this.panel46.Controls.Add(label74);
            this.panel46.Location = new System.Drawing.Point(538, 6);
            this.panel46.Name = "panel46";
            this.panel46.Size = new System.Drawing.Size(260, 131);
            this.panel46.TabIndex = 5;
            // 
            // panel23
            // 
            this.panel23.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.panel23.Controls.Add(this.label35);
            this.panel23.Controls.Add(this.label30);
            this.panel23.Controls.Add(this.pictureBoxFontPalette);
            this.panel23.Controls.Add(this.fontPaletteRedBar);
            this.panel23.Controls.Add(this.label32);
            this.panel23.Controls.Add(this.fontPaletteGreenNum);
            this.panel23.Controls.Add(this.label31);
            this.panel23.Controls.Add(this.fontPaletteBlueBar);
            this.panel23.Controls.Add(this.fontPaletteRedNum);
            this.panel23.Controls.Add(this.fontPaletteBlueNum);
            this.panel23.Controls.Add(this.label29);
            this.panel23.Controls.Add(this.fontPaletteGreenBar);
            this.panel23.Controls.Add(this.panel1);
            this.panel23.Location = new System.Drawing.Point(2, 21);
            this.panel23.Name = "panel23";
            this.panel23.Size = new System.Drawing.Size(256, 108);
            this.panel23.TabIndex = 53;
            // 
            // label35
            // 
            this.label35.BackColor = System.Drawing.SystemColors.Control;
            this.label35.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label35.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label35.Location = new System.Drawing.Point(0, 19);
            this.label35.Name = "label35";
            this.label35.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label35.Size = new System.Drawing.Size(128, 17);
            this.label35.TabIndex = 465;
            this.label35.Text = "PALETTE";
            // 
            // label30
            // 
            this.label30.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label30.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.ForeColor = System.Drawing.SystemColors.Control;
            this.label30.Location = new System.Drawing.Point(0, 0);
            this.label30.Name = "label30";
            this.label30.Padding = new System.Windows.Forms.Padding(2, 2, 0, 0);
            this.label30.Size = new System.Drawing.Size(256, 17);
            this.label30.TabIndex = 461;
            this.label30.Text = "FONT PALETTES";
            // 
            // pictureBoxFontPalette
            // 
            this.pictureBoxFontPalette.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.pictureBoxFontPalette.Location = new System.Drawing.Point(0, 37);
            this.pictureBoxFontPalette.Name = "pictureBoxFontPalette";
            this.pictureBoxFontPalette.Size = new System.Drawing.Size(256, 16);
            this.pictureBoxFontPalette.TabIndex = 447;
            this.pictureBoxFontPalette.TabStop = false;
            this.pictureBoxFontPalette.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBoxFontPalette_MouseClick);
            this.pictureBoxFontPalette.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxFontPalette_Paint);
            // 
            // fontPaletteRedBar
            // 
            this.fontPaletteRedBar.AutoSize = false;
            this.fontPaletteRedBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.fontPaletteRedBar.LargeChange = 32;
            this.fontPaletteRedBar.Location = new System.Drawing.Point(98, 55);
            this.fontPaletteRedBar.Maximum = 248;
            this.fontPaletteRedBar.Name = "fontPaletteRedBar";
            this.fontPaletteRedBar.Size = new System.Drawing.Size(158, 17);
            this.fontPaletteRedBar.SmallChange = 8;
            this.fontPaletteRedBar.TabIndex = 58;
            this.fontPaletteRedBar.TickFrequency = 8;
            this.fontPaletteRedBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.fontPaletteRedBar.Scroll += new System.EventHandler(this.fontPaletteRedBar_Scroll);
            // 
            // label32
            // 
            this.label32.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label32.Location = new System.Drawing.Point(0, 91);
            this.label32.Name = "label32";
            this.label32.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label32.Size = new System.Drawing.Size(46, 17);
            this.label32.TabIndex = 456;
            this.label32.Text = "Blue";
            // 
            // fontPaletteGreenNum
            // 
            this.fontPaletteGreenNum.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.fontPaletteGreenNum.Increment = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.fontPaletteGreenNum.Location = new System.Drawing.Point(47, 73);
            this.fontPaletteGreenNum.Maximum = new decimal(new int[] {
            248,
            0,
            0,
            0});
            this.fontPaletteGreenNum.Name = "fontPaletteGreenNum";
            this.fontPaletteGreenNum.Size = new System.Drawing.Size(50, 17);
            this.fontPaletteGreenNum.TabIndex = 56;
            this.fontPaletteGreenNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.fontPaletteGreenNum.ValueChanged += new System.EventHandler(this.fontPaletteGreenNum_ValueChanged);
            // 
            // label31
            // 
            this.label31.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label31.Location = new System.Drawing.Point(0, 55);
            this.label31.Name = "label31";
            this.label31.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label31.Size = new System.Drawing.Size(46, 17);
            this.label31.TabIndex = 452;
            this.label31.Text = "Red";
            // 
            // fontPaletteBlueBar
            // 
            this.fontPaletteBlueBar.AutoSize = false;
            this.fontPaletteBlueBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.fontPaletteBlueBar.LargeChange = 32;
            this.fontPaletteBlueBar.Location = new System.Drawing.Point(98, 91);
            this.fontPaletteBlueBar.Maximum = 248;
            this.fontPaletteBlueBar.Name = "fontPaletteBlueBar";
            this.fontPaletteBlueBar.Size = new System.Drawing.Size(158, 17);
            this.fontPaletteBlueBar.SmallChange = 8;
            this.fontPaletteBlueBar.TabIndex = 60;
            this.fontPaletteBlueBar.TickFrequency = 8;
            this.fontPaletteBlueBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.fontPaletteBlueBar.Scroll += new System.EventHandler(this.fontPaletteBlueBar_Scroll);
            // 
            // fontPaletteRedNum
            // 
            this.fontPaletteRedNum.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.fontPaletteRedNum.Increment = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.fontPaletteRedNum.Location = new System.Drawing.Point(47, 55);
            this.fontPaletteRedNum.Maximum = new decimal(new int[] {
            248,
            0,
            0,
            0});
            this.fontPaletteRedNum.Name = "fontPaletteRedNum";
            this.fontPaletteRedNum.Size = new System.Drawing.Size(50, 17);
            this.fontPaletteRedNum.TabIndex = 55;
            this.fontPaletteRedNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.fontPaletteRedNum.ValueChanged += new System.EventHandler(this.fontPaletteRedNum_ValueChanged);
            // 
            // fontPaletteBlueNum
            // 
            this.fontPaletteBlueNum.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.fontPaletteBlueNum.Increment = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.fontPaletteBlueNum.Location = new System.Drawing.Point(47, 91);
            this.fontPaletteBlueNum.Maximum = new decimal(new int[] {
            248,
            0,
            0,
            0});
            this.fontPaletteBlueNum.Name = "fontPaletteBlueNum";
            this.fontPaletteBlueNum.Size = new System.Drawing.Size(50, 17);
            this.fontPaletteBlueNum.TabIndex = 57;
            this.fontPaletteBlueNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.fontPaletteBlueNum.ValueChanged += new System.EventHandler(this.fontPaletteBlueNum_ValueChanged);
            // 
            // label29
            // 
            this.label29.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label29.Location = new System.Drawing.Point(0, 73);
            this.label29.Name = "label29";
            this.label29.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label29.Size = new System.Drawing.Size(46, 17);
            this.label29.TabIndex = 454;
            this.label29.Text = "Green";
            // 
            // fontPaletteGreenBar
            // 
            this.fontPaletteGreenBar.AutoSize = false;
            this.fontPaletteGreenBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.fontPaletteGreenBar.LargeChange = 32;
            this.fontPaletteGreenBar.Location = new System.Drawing.Point(98, 73);
            this.fontPaletteGreenBar.Maximum = 248;
            this.fontPaletteGreenBar.Name = "fontPaletteGreenBar";
            this.fontPaletteGreenBar.Size = new System.Drawing.Size(158, 17);
            this.fontPaletteGreenBar.SmallChange = 8;
            this.fontPaletteGreenBar.TabIndex = 59;
            this.fontPaletteGreenBar.TickFrequency = 8;
            this.fontPaletteGreenBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.fontPaletteGreenBar.Scroll += new System.EventHandler(this.fontPaletteGreenBar_Scroll);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.fontPalette);
            this.panel1.Location = new System.Drawing.Point(129, 19);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(128, 17);
            this.panel1.TabIndex = 53;
            // 
            // fontPalette
            // 
            this.fontPalette.BackColor = System.Drawing.SystemColors.Control;
            this.fontPalette.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fontPalette.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fontPalette.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.fontPalette.FormattingEnabled = true;
            this.fontPalette.Items.AddRange(new object[] {
            "Dialogue",
            "Menu"});
            this.fontPalette.Location = new System.Drawing.Point(-2, -2);
            this.fontPalette.Name = "fontPalette";
            this.fontPalette.Size = new System.Drawing.Size(132, 21);
            this.fontPalette.TabIndex = 400;
            this.fontPalette.SelectedIndexChanged += new System.EventHandler(this.fontPalette_SelectedIndexChanged);
            // 
            // panelColorBalance
            // 
            this.panelColorBalance.BackColor = System.Drawing.SystemColors.ControlText;
            this.panelColorBalance.Controls.Add(this.colEditApply);
            this.panelColorBalance.Controls.Add(this.colEditReset);
            this.panelColorBalance.Controls.Add(this.colEditRedo);
            this.panelColorBalance.Controls.Add(this.colEditUndo);
            this.panelColorBalance.Controls.Add(this.panel36);
            this.panelColorBalance.Controls.Add(this.panel110);
            this.panelColorBalance.Controls.Add(this.panel111);
            this.panelColorBalance.Controls.Add(this.label139);
            this.panelColorBalance.Location = new System.Drawing.Point(449, 107);
            this.panelColorBalance.Name = "panelColorBalance";
            this.panelColorBalance.Size = new System.Drawing.Size(276, 151);
            this.panelColorBalance.TabIndex = 517;
            this.panelColorBalance.Visible = false;
            // 
            // colEditApply
            // 
            this.colEditApply.BackColor = System.Drawing.SystemColors.Window;
            this.colEditApply.FlatAppearance.BorderSize = 0;
            this.colEditApply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colEditApply.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colEditApply.Location = new System.Drawing.Point(2, 132);
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
            this.colEditReset.Location = new System.Drawing.Point(115, 132);
            this.colEditReset.Name = "colEditReset";
            this.colEditReset.Size = new System.Drawing.Size(112, 17);
            this.colEditReset.TabIndex = 5;
            this.colEditReset.Text = "RESET";
            this.colEditReset.UseCompatibleTextRendering = true;
            this.colEditReset.UseVisualStyleBackColor = false;
            this.colEditReset.Click += new System.EventHandler(this.colEditReset_Click);
            // 
            // colEditRedo
            // 
            this.colEditRedo.BackColor = System.Drawing.SystemColors.Window;
            this.colEditRedo.FlatAppearance.BorderSize = 0;
            this.colEditRedo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colEditRedo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colEditRedo.Image = global::LAZYSHELL.Properties.Resources.redo_small;
            this.colEditRedo.Location = new System.Drawing.Point(252, 132);
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
            this.colEditUndo.Location = new System.Drawing.Point(229, 132);
            this.colEditUndo.Name = "colEditUndo";
            this.colEditUndo.Size = new System.Drawing.Size(22, 17);
            this.colEditUndo.TabIndex = 6;
            this.toolTip1.SetToolTip(this.colEditUndo, "Undo");
            this.colEditUndo.UseCompatibleTextRendering = true;
            this.colEditUndo.UseVisualStyleBackColor = false;
            this.colEditUndo.Click += new System.EventHandler(this.colEditUndo_Click);
            // 
            // panel36
            // 
            this.panel36.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.panel36.Controls.Add(this.label134);
            this.panel36.Controls.Add(this.colEditLabelA);
            this.panel36.Controls.Add(this.colEditLabelB);
            this.panel36.Controls.Add(this.panel108);
            this.panel36.Controls.Add(this.panel109);
            this.panel36.Controls.Add(this.colEditBlues);
            this.panel36.Controls.Add(this.colEditLabelC);
            this.panel36.Controls.Add(this.colEditGreens);
            this.panel36.Controls.Add(this.colEditLabelD);
            this.panel36.Controls.Add(this.colEditReds);
            this.panel36.Controls.Add(this.colEditValueA);
            this.panel36.Location = new System.Drawing.Point(2, 21);
            this.panel36.Name = "panel36";
            this.panel36.Size = new System.Drawing.Size(272, 54);
            this.panel36.TabIndex = 2;
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
            // panel108
            // 
            this.panel108.BackColor = System.Drawing.SystemColors.Window;
            this.panel108.Controls.Add(this.colEditComboBoxA);
            this.panel108.Location = new System.Drawing.Point(62, 19);
            this.panel108.Name = "panel108";
            this.panel108.Size = new System.Drawing.Size(69, 17);
            this.panel108.TabIndex = 1;
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
            // panel109
            // 
            this.panel109.BackColor = System.Drawing.SystemColors.Window;
            this.panel109.Controls.Add(this.colEditComboBoxB);
            this.panel109.Location = new System.Drawing.Point(173, 19);
            this.panel109.Name = "panel109";
            this.panel109.Size = new System.Drawing.Size(100, 17);
            this.panel109.TabIndex = 73;
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
            // colEditLabelC
            // 
            this.colEditLabelC.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.colEditLabelC.Location = new System.Drawing.Point(0, 37);
            this.colEditLabelC.Name = "colEditLabelC";
            this.colEditLabelC.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.colEditLabelC.Size = new System.Drawing.Size(61, 17);
            this.colEditLabelC.TabIndex = 157;
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
            // colEditLabelD
            // 
            this.colEditLabelD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.colEditLabelD.Location = new System.Drawing.Point(107, 37);
            this.colEditLabelD.Name = "colEditLabelD";
            this.colEditLabelD.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.colEditLabelD.Size = new System.Drawing.Size(24, 17);
            this.colEditLabelD.TabIndex = 157;
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
            // colEditValueA
            // 
            this.colEditValueA.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.colEditValueA.Location = new System.Drawing.Point(62, 37);
            this.colEditValueA.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.colEditValueA.Name = "colEditValueA";
            this.colEditValueA.Size = new System.Drawing.Size(44, 17);
            this.colEditValueA.TabIndex = 80;
            this.colEditValueA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // panel110
            // 
            this.panel110.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.panel110.Controls.Add(this.label136);
            this.panel110.Controls.Add(this.colEditColors);
            this.panel110.Controls.Add(this.colEditRowSelectAll);
            this.panel110.Controls.Add(this.colEditSelectAll);
            this.panel110.Controls.Add(this.label138);
            this.panel110.Controls.Add(this.label143);
            this.panel110.Controls.Add(this.colEditSelectNone);
            this.panel110.Location = new System.Drawing.Point(2, 77);
            this.panel110.Name = "panel110";
            this.panel110.Size = new System.Drawing.Size(272, 53);
            this.panel110.TabIndex = 3;
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
            ""});
            this.colEditColors.Location = new System.Drawing.Point(31, 37);
            this.colEditColors.MultiColumn = true;
            this.colEditColors.Name = "colEditColors";
            this.colEditColors.Size = new System.Drawing.Size(241, 16);
            this.colEditColors.TabIndex = 156;
            // 
            // colEditRowSelectAll
            // 
            this.colEditRowSelectAll.BackColor = System.Drawing.SystemColors.Window;
            this.colEditRowSelectAll.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.colEditRowSelectAll.CheckOnClick = true;
            this.colEditRowSelectAll.ColumnWidth = 14;
            this.colEditRowSelectAll.Items.AddRange(new object[] {
            "",
            ""});
            this.colEditRowSelectAll.Location = new System.Drawing.Point(0, 37);
            this.colEditRowSelectAll.MultiColumn = true;
            this.colEditRowSelectAll.Name = "colEditRowSelectAll";
            this.colEditRowSelectAll.Size = new System.Drawing.Size(30, 16);
            this.colEditRowSelectAll.TabIndex = 155;
            this.colEditRowSelectAll.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.colEditRowSelectAll_ItemCheck);
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
            // panel111
            // 
            this.panel111.BackColor = System.Drawing.SystemColors.Window;
            this.panel111.Controls.Add(this.coleditSelectCommand);
            this.panel111.Location = new System.Drawing.Point(93, 2);
            this.panel111.Name = "panel111";
            this.panel111.Size = new System.Drawing.Size(182, 17);
            this.panel111.TabIndex = 1;
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
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.ControlText;
            this.tabPage1.Controls.Add(this.panelSprites);
            this.tabPage1.Location = new System.Drawing.Point(175, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(809, 658);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "SPRITES";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panelSprites
            // 
            this.panelSprites.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelSprites.BackgroundImage = global::LAZYSHELL.Properties.Resources._bg;
            this.panelSprites.Controls.Add(this.labelTileOffset);
            this.panelSprites.Controls.Add(this.panelMoldImage);
            this.panelSprites.Controls.Add(this.panel54);
            this.panelSprites.Controls.Add(this.panel43);
            this.panelSprites.Controls.Add(this.panel42);
            this.panelSprites.Controls.Add(this.panel45);
            this.panelSprites.Controls.Add(this.panelImageGraphics);
            this.panelSprites.Controls.Add(this.panelSearchSpriteNames);
            this.panelSprites.Location = new System.Drawing.Point(2, 2);
            this.panelSprites.Name = "panelSprites";
            this.panelSprites.Size = new System.Drawing.Size(805, 654);
            this.panelSprites.TabIndex = 2;
            this.panelSprites.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelSprites_MouseMove);
            this.panelSprites.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelSprites_MouseUp);
            // 
            // labelTileOffset
            // 
            this.labelTileOffset.BackColor = System.Drawing.SystemColors.Info;
            this.labelTileOffset.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelTileOffset.Location = new System.Drawing.Point(410, 350);
            this.labelTileOffset.Name = "labelTileOffset";
            this.labelTileOffset.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.labelTileOffset.Size = new System.Drawing.Size(82, 17);
            this.labelTileOffset.TabIndex = 457;
            this.labelTileOffset.Visible = false;
            // 
            // panelMoldImage
            // 
            this.panelMoldImage.Controls.Add(this.moldCoordLabel);
            this.panelMoldImage.Controls.Add(this.labelMoldImage);
            this.panelMoldImage.Controls.Add(this.panel84);
            this.panelMoldImage.Controls.Add(this.panel52);
            this.panelMoldImage.Location = new System.Drawing.Point(538, 329);
            this.panelMoldImage.Name = "panelMoldImage";
            this.panelMoldImage.Size = new System.Drawing.Size(260, 319);
            this.panelMoldImage.TabIndex = 515;
            this.panelMoldImage.MouseLeave += new System.EventHandler(this.panelMoldImage_MouseLeave);
            this.panelMoldImage.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelMoldImage_MouseMove);
            this.panelMoldImage.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelMoldImage_MouseDown);
            // 
            // moldCoordLabel
            // 
            this.moldCoordLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.moldCoordLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.moldCoordLabel.Location = new System.Drawing.Point(131, 21);
            this.moldCoordLabel.Name = "moldCoordLabel";
            this.moldCoordLabel.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.moldCoordLabel.Size = new System.Drawing.Size(127, 17);
            this.moldCoordLabel.TabIndex = 526;
            this.moldCoordLabel.Text = "(0, 0)  Pixel Coord";
            this.moldCoordLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelMoldImage
            // 
            this.labelMoldImage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.labelMoldImage.BackColor = System.Drawing.SystemColors.Control;
            this.labelMoldImage.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.labelMoldImage.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMoldImage.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.labelMoldImage.Location = new System.Drawing.Point(2, 2);
            this.labelMoldImage.Name = "labelMoldImage";
            this.labelMoldImage.Padding = new System.Windows.Forms.Padding(2, 2, 0, 0);
            this.labelMoldImage.Size = new System.Drawing.Size(256, 17);
            this.labelMoldImage.TabIndex = 375;
            this.labelMoldImage.Text = "MOLD IMAGE";
            this.toolTip1.SetToolTip(this.labelMoldImage, "Click to drag or double-click to maximize / restore");
            this.labelMoldImage.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.labelMoldImage_MouseDoubleClick);
            this.labelMoldImage.MouseDown += new System.Windows.Forms.MouseEventHandler(this.labelMoldImage_MouseDown);
            this.labelMoldImage.MouseUp += new System.Windows.Forms.MouseEventHandler(this.labelMoldImage_MouseUp);
            // 
            // panel84
            // 
            this.panel84.BackColor = System.Drawing.SystemColors.Control;
            this.panel84.Controls.Add(this.toolStrip4);
            this.panel84.Location = new System.Drawing.Point(2, 21);
            this.panel84.Name = "panel84";
            this.panel84.Size = new System.Drawing.Size(128, 17);
            this.panel84.TabIndex = 51;
            // 
            // toolStrip4
            // 
            this.toolStrip4.AutoSize = false;
            this.toolStrip4.CanOverflow = false;
            this.toolStrip4.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip4.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip4.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel2,
            this.toolStripSeparator13,
            this.showMoldPixelGrid,
            this.toolStripSeparator14,
            this.moldZoomIn,
            this.moldZoomOut});
            this.toolStrip4.Location = new System.Drawing.Point(0, -1);
            this.toolStrip4.Name = "toolStrip4";
            this.toolStrip4.Padding = new System.Windows.Forms.Padding(0);
            this.toolStrip4.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip4.Size = new System.Drawing.Size(133, 20);
            this.toolStrip4.TabIndex = 51;
            this.toolStrip4.TabStop = true;
            this.toolStrip4.Text = "toolStrip1";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.toolStripLabel2.Margin = new System.Windows.Forms.Padding(4, 1, 0, 2);
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(36, 17);
            this.toolStripLabel2.Text = "VIEW";
            // 
            // toolStripSeparator13
            // 
            this.toolStripSeparator13.Margin = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStripSeparator13.Name = "toolStripSeparator13";
            this.toolStripSeparator13.Size = new System.Drawing.Size(6, 20);
            // 
            // showMoldPixelGrid
            // 
            this.showMoldPixelGrid.CheckOnClick = true;
            this.showMoldPixelGrid.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.showMoldPixelGrid.Image = global::LAZYSHELL.Properties.Resources.buttonTogglePixelGrid;
            this.showMoldPixelGrid.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.showMoldPixelGrid.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.showMoldPixelGrid.Name = "showMoldPixelGrid";
            this.showMoldPixelGrid.Size = new System.Drawing.Size(23, 17);
            this.showMoldPixelGrid.Text = "Pixel Grid";
            this.showMoldPixelGrid.Click += new System.EventHandler(this.showMoldPixelGrid_Click);
            // 
            // toolStripSeparator14
            // 
            this.toolStripSeparator14.Margin = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStripSeparator14.Name = "toolStripSeparator14";
            this.toolStripSeparator14.Size = new System.Drawing.Size(6, 20);
            // 
            // moldZoomIn
            // 
            this.moldZoomIn.CheckOnClick = true;
            this.moldZoomIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.moldZoomIn.Image = global::LAZYSHELL.Properties.Resources.zoomin_small;
            this.moldZoomIn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.moldZoomIn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.moldZoomIn.Name = "moldZoomIn";
            this.moldZoomIn.Size = new System.Drawing.Size(23, 17);
            this.moldZoomIn.Text = "Zoom In";
            this.moldZoomIn.Click += new System.EventHandler(this.moldZoomIn_Click);
            // 
            // moldZoomOut
            // 
            this.moldZoomOut.CheckOnClick = true;
            this.moldZoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.moldZoomOut.Image = global::LAZYSHELL.Properties.Resources.zoomout_small;
            this.moldZoomOut.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.moldZoomOut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.moldZoomOut.Name = "moldZoomOut";
            this.moldZoomOut.Size = new System.Drawing.Size(23, 17);
            this.moldZoomOut.Text = "Zoom Out";
            this.moldZoomOut.Click += new System.EventHandler(this.moldZoomOut_Click);
            // 
            // panel52
            // 
            this.panel52.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel52.AutoScroll = true;
            this.panel52.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel52.Controls.Add(this.pictureBoxMold);
            this.panel52.Location = new System.Drawing.Point(2, 39);
            this.panel52.Name = "panel52";
            this.panel52.Size = new System.Drawing.Size(256, 278);
            this.panel52.TabIndex = 515;
            this.panel52.Scroll += new System.Windows.Forms.ScrollEventHandler(this.panel52_Scroll);
            // 
            // pictureBoxMold
            // 
            this.pictureBoxMold.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pictureBoxMold.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBoxMold.BackgroundImage")));
            this.pictureBoxMold.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxMold.Name = "pictureBoxMold";
            this.pictureBoxMold.Size = new System.Drawing.Size(256, 256);
            this.pictureBoxMold.TabIndex = 396;
            this.pictureBoxMold.TabStop = false;
            this.pictureBoxMold.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxMold_MouseMove);
            this.pictureBoxMold.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxMold_MouseDown);
            this.pictureBoxMold.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxMold_Paint);
            this.pictureBoxMold.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBoxMold_MouseUp);
            // 
            // panel54
            // 
            this.panel54.BackColor = System.Drawing.SystemColors.ControlText;
            this.panel54.Controls.Add(this.panel5);
            this.panel54.Location = new System.Drawing.Point(6, 71);
            this.panel54.Name = "panel54";
            this.panel54.Size = new System.Drawing.Size(260, 177);
            this.panel54.TabIndex = 3;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.panel5.Controls.Add(this.colorBalance);
            this.panel5.Controls.Add(this.label88);
            this.panel5.Controls.Add(this.mapPaletteBlueBar);
            this.panel5.Controls.Add(this.pictureBoxColor);
            this.panel5.Controls.Add(this.pictureBoxPalette);
            this.panel5.Controls.Add(this.label80);
            this.panel5.Controls.Add(this.mapPaletteBlueNum);
            this.panel5.Controls.Add(this.mapPaletteColor);
            this.panel5.Controls.Add(this.mapPaletteRedNum);
            this.panel5.Controls.Add(this.mapPaletteGreenBar);
            this.panel5.Controls.Add(this.label17);
            this.panel5.Controls.Add(this.label79);
            this.panel5.Controls.Add(this.mapPaletteGreenNum);
            this.panel5.Controls.Add(this.label81);
            this.panel5.Controls.Add(this.mapPaletteRedBar);
            this.panel5.Controls.Add(this.label23);
            this.panel5.Controls.Add(this.paletteOffset);
            this.panel5.Location = new System.Drawing.Point(2, 2);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(256, 173);
            this.panel5.TabIndex = 7;
            // 
            // colorBalance
            // 
            this.colorBalance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.colorBalance.FlatAppearance.BorderSize = 0;
            this.colorBalance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colorBalance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colorBalance.Location = new System.Drawing.Point(129, 0);
            this.colorBalance.Name = "colorBalance";
            this.colorBalance.Size = new System.Drawing.Size(127, 17);
            this.colorBalance.TabIndex = 425;
            this.colorBalance.Text = "COLOR MATH...";
            this.colorBalance.UseCompatibleTextRendering = true;
            this.colorBalance.UseVisualStyleBackColor = false;
            this.colorBalance.Click += new System.EventHandler(this.colorBalance_Click);
            // 
            // label88
            // 
            this.label88.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label88.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label88.ForeColor = System.Drawing.SystemColors.Control;
            this.label88.Location = new System.Drawing.Point(0, 0);
            this.label88.Name = "label88";
            this.label88.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.label88.Size = new System.Drawing.Size(128, 17);
            this.label88.TabIndex = 417;
            this.label88.Text = "IMAGE PALETTE...";
            this.label88.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mapPaletteBlueBar
            // 
            this.mapPaletteBlueBar.AutoSize = false;
            this.mapPaletteBlueBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.mapPaletteBlueBar.LargeChange = 32;
            this.mapPaletteBlueBar.Location = new System.Drawing.Point(98, 156);
            this.mapPaletteBlueBar.Maximum = 248;
            this.mapPaletteBlueBar.Name = "mapPaletteBlueBar";
            this.mapPaletteBlueBar.Size = new System.Drawing.Size(158, 17);
            this.mapPaletteBlueBar.SmallChange = 8;
            this.mapPaletteBlueBar.TabIndex = 15;
            this.mapPaletteBlueBar.TickFrequency = 8;
            this.mapPaletteBlueBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.mapPaletteBlueBar.Scroll += new System.EventHandler(this.mapPaletteBlueBar_Scroll);
            // 
            // pictureBoxColor
            // 
            this.pictureBoxColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.pictureBoxColor.Location = new System.Drawing.Point(98, 102);
            this.pictureBoxColor.Name = "pictureBoxColor";
            this.pictureBoxColor.Size = new System.Drawing.Size(158, 17);
            this.pictureBoxColor.TabIndex = 416;
            this.pictureBoxColor.TabStop = false;
            // 
            // pictureBoxPalette
            // 
            this.pictureBoxPalette.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pictureBoxPalette.ContextMenuStrip = this.contextMenuStrip3;
            this.pictureBoxPalette.Location = new System.Drawing.Point(0, 37);
            this.pictureBoxPalette.Name = "pictureBoxPalette";
            this.pictureBoxPalette.Size = new System.Drawing.Size(256, 64);
            this.pictureBoxPalette.TabIndex = 416;
            this.pictureBoxPalette.TabStop = false;
            this.pictureBoxPalette.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBoxPalette_MouseClick);
            this.pictureBoxPalette.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxPalette_Paint);
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
            // label80
            // 
            this.label80.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label80.Location = new System.Drawing.Point(0, 138);
            this.label80.Name = "label80";
            this.label80.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label80.Size = new System.Drawing.Size(46, 17);
            this.label80.TabIndex = 422;
            this.label80.Text = "Green";
            // 
            // mapPaletteBlueNum
            // 
            this.mapPaletteBlueNum.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.mapPaletteBlueNum.Increment = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.mapPaletteBlueNum.Location = new System.Drawing.Point(47, 156);
            this.mapPaletteBlueNum.Maximum = new decimal(new int[] {
            248,
            0,
            0,
            0});
            this.mapPaletteBlueNum.Name = "mapPaletteBlueNum";
            this.mapPaletteBlueNum.Size = new System.Drawing.Size(50, 17);
            this.mapPaletteBlueNum.TabIndex = 12;
            this.mapPaletteBlueNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.mapPaletteBlueNum.ValueChanged += new System.EventHandler(this.mapPaletteBlueNum_ValueChanged);
            // 
            // mapPaletteColor
            // 
            this.mapPaletteColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.mapPaletteColor.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.mapPaletteColor.Location = new System.Drawing.Point(47, 102);
            this.mapPaletteColor.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.mapPaletteColor.Name = "mapPaletteColor";
            this.mapPaletteColor.Size = new System.Drawing.Size(50, 17);
            this.mapPaletteColor.TabIndex = 9;
            this.mapPaletteColor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.mapPaletteColor.ValueChanged += new System.EventHandler(this.mapPaletteColor_ValueChanged);
            // 
            // mapPaletteRedNum
            // 
            this.mapPaletteRedNum.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.mapPaletteRedNum.Increment = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.mapPaletteRedNum.Location = new System.Drawing.Point(47, 120);
            this.mapPaletteRedNum.Maximum = new decimal(new int[] {
            248,
            0,
            0,
            0});
            this.mapPaletteRedNum.Name = "mapPaletteRedNum";
            this.mapPaletteRedNum.Size = new System.Drawing.Size(50, 17);
            this.mapPaletteRedNum.TabIndex = 10;
            this.mapPaletteRedNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.mapPaletteRedNum.ValueChanged += new System.EventHandler(this.mapPaletteRedNum_ValueChanged);
            // 
            // mapPaletteGreenBar
            // 
            this.mapPaletteGreenBar.AutoSize = false;
            this.mapPaletteGreenBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.mapPaletteGreenBar.LargeChange = 32;
            this.mapPaletteGreenBar.Location = new System.Drawing.Point(98, 138);
            this.mapPaletteGreenBar.Maximum = 248;
            this.mapPaletteGreenBar.Name = "mapPaletteGreenBar";
            this.mapPaletteGreenBar.Size = new System.Drawing.Size(158, 17);
            this.mapPaletteGreenBar.SmallChange = 8;
            this.mapPaletteGreenBar.TabIndex = 14;
            this.mapPaletteGreenBar.TickFrequency = 8;
            this.mapPaletteGreenBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.mapPaletteGreenBar.Scroll += new System.EventHandler(this.mapPaletteGreenBar_Scroll);
            // 
            // label17
            // 
            this.label17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label17.Location = new System.Drawing.Point(0, 102);
            this.label17.Name = "label17";
            this.label17.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label17.Size = new System.Drawing.Size(46, 17);
            this.label17.TabIndex = 420;
            this.label17.Text = "Color";
            // 
            // label79
            // 
            this.label79.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label79.Location = new System.Drawing.Point(0, 120);
            this.label79.Name = "label79";
            this.label79.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label79.Size = new System.Drawing.Size(46, 17);
            this.label79.TabIndex = 420;
            this.label79.Text = "Red";
            // 
            // mapPaletteGreenNum
            // 
            this.mapPaletteGreenNum.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.mapPaletteGreenNum.Increment = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.mapPaletteGreenNum.Location = new System.Drawing.Point(47, 138);
            this.mapPaletteGreenNum.Maximum = new decimal(new int[] {
            248,
            0,
            0,
            0});
            this.mapPaletteGreenNum.Name = "mapPaletteGreenNum";
            this.mapPaletteGreenNum.Size = new System.Drawing.Size(50, 17);
            this.mapPaletteGreenNum.TabIndex = 11;
            this.mapPaletteGreenNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.mapPaletteGreenNum.ValueChanged += new System.EventHandler(this.mapPaletteGreenNum_ValueChanged);
            // 
            // label81
            // 
            this.label81.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label81.Location = new System.Drawing.Point(0, 156);
            this.label81.Name = "label81";
            this.label81.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label81.Size = new System.Drawing.Size(46, 17);
            this.label81.TabIndex = 424;
            this.label81.Text = "Blue";
            // 
            // mapPaletteRedBar
            // 
            this.mapPaletteRedBar.AutoSize = false;
            this.mapPaletteRedBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.mapPaletteRedBar.LargeChange = 32;
            this.mapPaletteRedBar.Location = new System.Drawing.Point(98, 120);
            this.mapPaletteRedBar.Maximum = 248;
            this.mapPaletteRedBar.Name = "mapPaletteRedBar";
            this.mapPaletteRedBar.Size = new System.Drawing.Size(158, 17);
            this.mapPaletteRedBar.SmallChange = 8;
            this.mapPaletteRedBar.TabIndex = 13;
            this.mapPaletteRedBar.TickFrequency = 8;
            this.mapPaletteRedBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.mapPaletteRedBar.Scroll += new System.EventHandler(this.mapPaletteRedBar_Scroll);
            // 
            // label23
            // 
            this.label23.BackColor = System.Drawing.SystemColors.Control;
            this.label23.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label23.Location = new System.Drawing.Point(0, 19);
            this.label23.Name = "label23";
            this.label23.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label23.Size = new System.Drawing.Size(128, 17);
            this.label23.TabIndex = 394;
            this.label23.Text = "PALETTE #";
            // 
            // paletteOffset
            // 
            this.paletteOffset.BackColor = System.Drawing.SystemColors.Control;
            this.paletteOffset.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.paletteOffset.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paletteOffset.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.paletteOffset.Location = new System.Drawing.Point(129, 19);
            this.paletteOffset.Maximum = new decimal(new int[] {
            818,
            0,
            0,
            0});
            this.paletteOffset.Name = "paletteOffset";
            this.paletteOffset.Size = new System.Drawing.Size(128, 17);
            this.paletteOffset.TabIndex = 8;
            this.paletteOffset.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.paletteOffset.ValueChanged += new System.EventHandler(this.paletteOffset_ValueChanged);
            // 
            // panel43
            // 
            this.panel43.Controls.Add(this.label72);
            this.panel43.Controls.Add(this.label18);
            this.panel43.Controls.Add(this.label3);
            this.panel43.Controls.Add(this.animationVRAM);
            this.panel43.Controls.Add(this.panel8);
            this.panel43.Controls.Add(this.buttonPlay);
            this.panel43.Controls.Add(this.animationPacket);
            this.panel43.Controls.Add(this.buttonStop);
            this.panel43.Controls.Add(this.label10);
            this.panel43.Controls.Add(this.buttonBack);
            this.panel43.Controls.Add(this.panel29);
            this.panel43.Controls.Add(this.buttonFoward);
            this.panel43.Controls.Add(this.animationAvailableBytes);
            this.panel43.Controls.Add(this.pictureBoxSequence);
            this.panel43.Location = new System.Drawing.Point(272, 6);
            this.panel43.Name = "panel43";
            this.panel43.Size = new System.Drawing.Size(526, 298);
            this.panel43.TabIndex = 5;
            // 
            // label72
            // 
            this.label72.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label72.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label72.ForeColor = System.Drawing.SystemColors.Control;
            this.label72.Location = new System.Drawing.Point(2, 2);
            this.label72.Name = "label72";
            this.label72.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label72.Size = new System.Drawing.Size(135, 17);
            this.label72.TabIndex = 394;
            this.label72.Text = "ANIMATION #";
            // 
            // label18
            // 
            this.label18.BackColor = System.Drawing.SystemColors.Control;
            this.label18.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label18.Location = new System.Drawing.Point(425, 2);
            this.label18.Name = "label18";
            this.label18.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label18.Size = new System.Drawing.Size(45, 17);
            this.label18.TabIndex = 394;
            this.label18.Text = "VRAM Size";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(2, 21);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(2, 2, 0, 0);
            this.label3.Size = new System.Drawing.Size(264, 17);
            this.label3.TabIndex = 375;
            this.label3.Text = "ANIMATION SEQUENCES...";
            // 
            // animationVRAM
            // 
            this.animationVRAM.BackColor = System.Drawing.SystemColors.Control;
            this.animationVRAM.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.animationVRAM.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.animationVRAM.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.animationVRAM.Increment = new decimal(new int[] {
            2048,
            0,
            0,
            0});
            this.animationVRAM.Location = new System.Drawing.Point(471, 2);
            this.animationVRAM.Maximum = new decimal(new int[] {
            8192,
            0,
            0,
            0});
            this.animationVRAM.Minimum = new decimal(new int[] {
            2048,
            0,
            0,
            0});
            this.animationVRAM.Name = "animationVRAM";
            this.animationVRAM.Size = new System.Drawing.Size(54, 17);
            this.animationVRAM.TabIndex = 6;
            this.animationVRAM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.animationVRAM.Value = new decimal(new int[] {
            2048,
            0,
            0,
            0});
            this.animationVRAM.ValueChanged += new System.EventHandler(this.animationVRAM_ValueChanged);
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.panel8.Controls.Add(this.sequences);
            this.panel8.Controls.Add(this.insertSequence);
            this.panel8.Controls.Add(this.deleteSequence);
            this.panel8.Controls.Add(this.label22);
            this.panel8.Location = new System.Drawing.Point(2, 40);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(134, 256);
            this.panel8.TabIndex = 18;
            // 
            // sequences
            // 
            this.sequences.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.sequences.FormattingEnabled = true;
            this.sequences.IntegralHeight = false;
            this.sequences.Location = new System.Drawing.Point(0, 19);
            this.sequences.Name = "sequences";
            this.sequences.Size = new System.Drawing.Size(134, 219);
            this.sequences.TabIndex = 19;
            this.sequences.SelectedIndexChanged += new System.EventHandler(this.sequences_SelectedIndexChanged);
            // 
            // insertSequence
            // 
            this.insertSequence.BackColor = System.Drawing.SystemColors.Window;
            this.insertSequence.FlatAppearance.BorderSize = 0;
            this.insertSequence.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.insertSequence.Location = new System.Drawing.Point(0, 239);
            this.insertSequence.Name = "insertSequence";
            this.insertSequence.Size = new System.Drawing.Size(66, 17);
            this.insertSequence.TabIndex = 20;
            this.insertSequence.Text = "INSERT";
            this.toolTip1.SetToolTip(this.insertSequence, "Insert new sequence");
            this.insertSequence.UseCompatibleTextRendering = true;
            this.insertSequence.UseVisualStyleBackColor = false;
            this.insertSequence.Click += new System.EventHandler(this.insertSequence_Click);
            // 
            // deleteSequence
            // 
            this.deleteSequence.BackColor = System.Drawing.SystemColors.Window;
            this.deleteSequence.FlatAppearance.BorderSize = 0;
            this.deleteSequence.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteSequence.Location = new System.Drawing.Point(67, 239);
            this.deleteSequence.Name = "deleteSequence";
            this.deleteSequence.Size = new System.Drawing.Size(67, 17);
            this.deleteSequence.TabIndex = 21;
            this.deleteSequence.Text = "DELETE";
            this.toolTip1.SetToolTip(this.deleteSequence, "Delete selected sequence");
            this.deleteSequence.UseCompatibleTextRendering = true;
            this.deleteSequence.UseVisualStyleBackColor = false;
            this.deleteSequence.Click += new System.EventHandler(this.deleteSequence_Click);
            // 
            // label22
            // 
            this.label22.BackColor = System.Drawing.SystemColors.Control;
            this.label22.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label22.Location = new System.Drawing.Point(0, 0);
            this.label22.Name = "label22";
            this.label22.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.label22.Size = new System.Drawing.Size(134, 17);
            this.label22.TabIndex = 407;
            this.label22.Text = "SEQUENCES";
            // 
            // buttonPlay
            // 
            this.buttonPlay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.buttonPlay.FlatAppearance.BorderSize = 0;
            this.buttonPlay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPlay.Image = global::LAZYSHELL.Properties.Resources.play;
            this.buttonPlay.Location = new System.Drawing.Point(268, 279);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.buttonPlay.Size = new System.Drawing.Size(22, 17);
            this.buttonPlay.TabIndex = 30;
            this.toolTip1.SetToolTip(this.buttonPlay, "Play animation");
            this.buttonPlay.UseCompatibleTextRendering = true;
            this.buttonPlay.UseVisualStyleBackColor = false;
            this.buttonPlay.Click += new System.EventHandler(this.buttonPlay_Click);
            // 
            // animationPacket
            // 
            this.animationPacket.BackColor = System.Drawing.SystemColors.ControlDark;
            this.animationPacket.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.animationPacket.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.animationPacket.ForeColor = System.Drawing.SystemColors.Control;
            this.animationPacket.Location = new System.Drawing.Point(138, 2);
            this.animationPacket.Maximum = new decimal(new int[] {
            443,
            0,
            0,
            0});
            this.animationPacket.Name = "animationPacket";
            this.animationPacket.Size = new System.Drawing.Size(129, 17);
            this.animationPacket.TabIndex = 5;
            this.animationPacket.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.animationPacket.ValueChanged += new System.EventHandler(this.animationPacket_ValueChanged);
            // 
            // buttonStop
            // 
            this.buttonStop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.buttonStop.FlatAppearance.BorderSize = 0;
            this.buttonStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStop.Image = global::LAZYSHELL.Properties.Resources.stop;
            this.buttonStop.Location = new System.Drawing.Point(291, 279);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.buttonStop.Size = new System.Drawing.Size(22, 17);
            this.buttonStop.TabIndex = 31;
            this.toolTip1.SetToolTip(this.buttonStop, "Pause animation");
            this.buttonStop.UseCompatibleTextRendering = true;
            this.buttonStop.UseVisualStyleBackColor = false;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.SystemColors.Control;
            this.label10.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label10.Location = new System.Drawing.Point(268, 21);
            this.label10.Name = "label10";
            this.label10.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label10.Size = new System.Drawing.Size(256, 17);
            this.label10.TabIndex = 375;
            this.label10.Text = "SEQUENCE PREVIEW";
            // 
            // buttonBack
            // 
            this.buttonBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.buttonBack.FlatAppearance.BorderSize = 0;
            this.buttonBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBack.Image = global::LAZYSHELL.Properties.Resources.back;
            this.buttonBack.Location = new System.Drawing.Point(314, 279);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Padding = new System.Windows.Forms.Padding(0, 0, 1, 1);
            this.buttonBack.Size = new System.Drawing.Size(22, 17);
            this.buttonBack.TabIndex = 32;
            this.toolTip1.SetToolTip(this.buttonBack, "Frame backward");
            this.buttonBack.UseCompatibleTextRendering = true;
            this.buttonBack.UseVisualStyleBackColor = false;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // panel29
            // 
            this.panel29.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.panel29.Controls.Add(this.sequenceFrames);
            this.panel29.Controls.Add(this.label8);
            this.panel29.Controls.Add(this.frameMold);
            this.panel29.Controls.Add(this.frameDuration);
            this.panel29.Controls.Add(this.label16);
            this.panel29.Controls.Add(this.label11);
            this.panel29.Controls.Add(this.frameMoveDown);
            this.panel29.Controls.Add(this.insertFrame);
            this.panel29.Controls.Add(this.deleteFrame);
            this.panel29.Controls.Add(this.frameMoveUp);
            this.panel29.Location = new System.Drawing.Point(138, 40);
            this.panel29.Name = "panel29";
            this.panel29.Size = new System.Drawing.Size(128, 256);
            this.panel29.TabIndex = 22;
            // 
            // sequenceFrames
            // 
            this.sequenceFrames.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.sequenceFrames.FormattingEnabled = true;
            this.sequenceFrames.IntegralHeight = false;
            this.sequenceFrames.Location = new System.Drawing.Point(0, 19);
            this.sequenceFrames.Name = "sequenceFrames";
            this.sequenceFrames.Size = new System.Drawing.Size(128, 183);
            this.sequenceFrames.TabIndex = 1;
            this.sequenceFrames.SelectedIndexChanged += new System.EventHandler(this.sequenceFrames_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.SystemColors.Control;
            this.label8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label8.Location = new System.Drawing.Point(0, 0);
            this.label8.Name = "label8";
            this.label8.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.label8.Size = new System.Drawing.Size(130, 17);
            this.label8.TabIndex = 407;
            this.label8.Text = "SEQUENCE FRAMES";
            // 
            // frameMold
            // 
            this.frameMold.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.frameMold.Location = new System.Drawing.Point(64, 221);
            this.frameMold.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.frameMold.Name = "frameMold";
            this.frameMold.Size = new System.Drawing.Size(44, 17);
            this.frameMold.TabIndex = 24;
            this.frameMold.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.frameMold.ValueChanged += new System.EventHandler(this.frameMold_ValueChanged);
            // 
            // frameDuration
            // 
            this.frameDuration.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.frameDuration.Location = new System.Drawing.Point(64, 239);
            this.frameDuration.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.frameDuration.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.frameDuration.Name = "frameDuration";
            this.frameDuration.Size = new System.Drawing.Size(44, 17);
            this.frameDuration.TabIndex = 25;
            this.frameDuration.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.frameDuration.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.frameDuration.ValueChanged += new System.EventHandler(this.frameDuration_ValueChanged);
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label16.Location = new System.Drawing.Point(0, 239);
            this.label16.Name = "label16";
            this.label16.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label16.Size = new System.Drawing.Size(63, 17);
            this.label16.TabIndex = 439;
            this.label16.Text = "Duration";
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label11.Location = new System.Drawing.Point(0, 221);
            this.label11.Name = "label11";
            this.label11.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label11.Size = new System.Drawing.Size(63, 17);
            this.label11.TabIndex = 440;
            this.label11.Text = "Mold";
            // 
            // frameMoveDown
            // 
            this.frameMoveDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.frameMoveDown.FlatAppearance.BorderSize = 0;
            this.frameMoveDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.frameMoveDown.Image = global::LAZYSHELL.Properties.Resources.movedown;
            this.frameMoveDown.Location = new System.Drawing.Point(109, 239);
            this.frameMoveDown.Name = "frameMoveDown";
            this.frameMoveDown.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.frameMoveDown.Size = new System.Drawing.Size(19, 17);
            this.frameMoveDown.TabIndex = 27;
            this.frameMoveDown.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.frameMoveDown, "Move frame down");
            this.frameMoveDown.UseCompatibleTextRendering = true;
            this.frameMoveDown.UseVisualStyleBackColor = false;
            this.frameMoveDown.Click += new System.EventHandler(this.frameMoveDown_Click);
            // 
            // insertFrame
            // 
            this.insertFrame.BackColor = System.Drawing.SystemColors.Window;
            this.insertFrame.FlatAppearance.BorderSize = 0;
            this.insertFrame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.insertFrame.Location = new System.Drawing.Point(0, 203);
            this.insertFrame.Name = "insertFrame";
            this.insertFrame.Size = new System.Drawing.Size(63, 17);
            this.insertFrame.TabIndex = 2;
            this.insertFrame.Text = "INSERT";
            this.toolTip1.SetToolTip(this.insertFrame, "Insert new frame");
            this.insertFrame.UseCompatibleTextRendering = true;
            this.insertFrame.UseVisualStyleBackColor = false;
            this.insertFrame.Click += new System.EventHandler(this.insertFrame_Click);
            // 
            // deleteFrame
            // 
            this.deleteFrame.BackColor = System.Drawing.SystemColors.Window;
            this.deleteFrame.FlatAppearance.BorderSize = 0;
            this.deleteFrame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteFrame.Location = new System.Drawing.Point(64, 203);
            this.deleteFrame.Name = "deleteFrame";
            this.deleteFrame.Size = new System.Drawing.Size(64, 17);
            this.deleteFrame.TabIndex = 3;
            this.deleteFrame.Text = "DELETE";
            this.toolTip1.SetToolTip(this.deleteFrame, "Delete selected frame");
            this.deleteFrame.UseCompatibleTextRendering = true;
            this.deleteFrame.UseVisualStyleBackColor = false;
            this.deleteFrame.Click += new System.EventHandler(this.deleteFrame_Click);
            // 
            // frameMoveUp
            // 
            this.frameMoveUp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.frameMoveUp.FlatAppearance.BorderSize = 0;
            this.frameMoveUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.frameMoveUp.Image = global::LAZYSHELL.Properties.Resources.moveup;
            this.frameMoveUp.Location = new System.Drawing.Point(109, 221);
            this.frameMoveUp.Name = "frameMoveUp";
            this.frameMoveUp.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.frameMoveUp.Size = new System.Drawing.Size(19, 17);
            this.frameMoveUp.TabIndex = 26;
            this.frameMoveUp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.frameMoveUp, "Move frame up");
            this.frameMoveUp.UseCompatibleTextRendering = true;
            this.frameMoveUp.UseVisualStyleBackColor = false;
            this.frameMoveUp.Click += new System.EventHandler(this.frameMoveUp_Click);
            // 
            // buttonFoward
            // 
            this.buttonFoward.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.buttonFoward.FlatAppearance.BorderSize = 0;
            this.buttonFoward.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonFoward.Image = global::LAZYSHELL.Properties.Resources.foward;
            this.buttonFoward.Location = new System.Drawing.Point(337, 279);
            this.buttonFoward.Name = "buttonFoward";
            this.buttonFoward.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.buttonFoward.Size = new System.Drawing.Size(22, 17);
            this.buttonFoward.TabIndex = 33;
            this.toolTip1.SetToolTip(this.buttonFoward, "Frame forward");
            this.buttonFoward.UseCompatibleTextRendering = true;
            this.buttonFoward.UseVisualStyleBackColor = false;
            this.buttonFoward.Click += new System.EventHandler(this.buttonFoward_Click);
            // 
            // animationAvailableBytes
            // 
            this.animationAvailableBytes.BackColor = System.Drawing.SystemColors.Control;
            this.animationAvailableBytes.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.animationAvailableBytes.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.animationAvailableBytes.Location = new System.Drawing.Point(268, 2);
            this.animationAvailableBytes.Name = "animationAvailableBytes";
            this.animationAvailableBytes.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.animationAvailableBytes.Size = new System.Drawing.Size(155, 17);
            this.animationAvailableBytes.TabIndex = 451;
            this.animationAvailableBytes.Text = "AVAILABLE BYTES: ";
            // 
            // pictureBoxSequence
            // 
            this.pictureBoxSequence.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pictureBoxSequence.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBoxSequence.BackgroundImage")));
            this.pictureBoxSequence.ContextMenuStrip = this.contextMenuStripSI;
            this.pictureBoxSequence.Location = new System.Drawing.Point(268, 40);
            this.pictureBoxSequence.Name = "pictureBoxSequence";
            this.pictureBoxSequence.Size = new System.Drawing.Size(256, 256);
            this.pictureBoxSequence.TabIndex = 396;
            this.pictureBoxSequence.TabStop = false;
            this.pictureBoxSequence.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxSequence_Paint);
            // 
            // panel42
            // 
            this.panel42.Controls.Add(this.panel7);
            this.panel42.Controls.Add(this.label5);
            this.panel42.Controls.Add(this.panel56);
            this.panel42.Location = new System.Drawing.Point(272, 310);
            this.panel42.Name = "panel42";
            this.panel42.Size = new System.Drawing.Size(526, 338);
            this.panel42.TabIndex = 6;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.panel7.Controls.Add(this.molds);
            this.panel7.Controls.Add(this.label24);
            this.panel7.Controls.Add(this.panel6);
            this.panel7.Controls.Add(this.panel3);
            this.panel7.Controls.Add(this.label15);
            this.panel7.Controls.Add(this.deleteMold);
            this.panel7.Controls.Add(this.insertMold);
            this.panel7.Location = new System.Drawing.Point(2, 21);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(134, 315);
            this.panel7.TabIndex = 34;
            // 
            // molds
            // 
            this.molds.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.molds.FormattingEnabled = true;
            this.molds.IntegralHeight = false;
            this.molds.Location = new System.Drawing.Point(0, 19);
            this.molds.Name = "molds";
            this.molds.Size = new System.Drawing.Size(134, 260);
            this.molds.TabIndex = 35;
            this.molds.SelectedIndexChanged += new System.EventHandler(this.molds_SelectedIndexChanged);
            // 
            // label24
            // 
            this.label24.BackColor = System.Drawing.SystemColors.Control;
            this.label24.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label24.Location = new System.Drawing.Point(0, 0);
            this.label24.Name = "label24";
            this.label24.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.label24.Size = new System.Drawing.Size(134, 17);
            this.label24.TabIndex = 407;
            this.label24.Text = "MOLDS";
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.moldFormat);
            this.panel6.Location = new System.Drawing.Point(67, 298);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(68, 17);
            this.panel6.TabIndex = 405;
            // 
            // moldFormat
            // 
            this.moldFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.moldFormat.FormattingEnabled = true;
            this.moldFormat.Items.AddRange(new object[] {
            "Gridplane",
            "Tilemap"});
            this.moldFormat.Location = new System.Drawing.Point(-2, -2);
            this.moldFormat.Name = "moldFormat";
            this.moldFormat.Size = new System.Drawing.Size(72, 21);
            this.moldFormat.TabIndex = 38;
            this.moldFormat.SelectedIndexChanged += new System.EventHandler(this.moldFormat_SelectedIndexChanged);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.comboBox2);
            this.panel3.Location = new System.Drawing.Point(67, 298);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(68, 17);
            this.panel3.TabIndex = 405;
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Gridplane",
            "16x16 mapped"});
            this.comboBox2.Location = new System.Drawing.Point(-2, -2);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(53, 21);
            this.comboBox2.TabIndex = 400;
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label15.Location = new System.Drawing.Point(0, 298);
            this.label15.Name = "label15";
            this.label15.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label15.Size = new System.Drawing.Size(66, 17);
            this.label15.TabIndex = 404;
            this.label15.Text = "Format";
            // 
            // deleteMold
            // 
            this.deleteMold.BackColor = System.Drawing.SystemColors.Window;
            this.deleteMold.FlatAppearance.BorderSize = 0;
            this.deleteMold.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteMold.Location = new System.Drawing.Point(67, 280);
            this.deleteMold.Name = "deleteMold";
            this.deleteMold.Size = new System.Drawing.Size(67, 17);
            this.deleteMold.TabIndex = 37;
            this.deleteMold.Text = "DELETE";
            this.toolTip1.SetToolTip(this.deleteMold, "Delete selected mold");
            this.deleteMold.UseCompatibleTextRendering = true;
            this.deleteMold.UseVisualStyleBackColor = false;
            this.deleteMold.Click += new System.EventHandler(this.deleteMold_Click);
            // 
            // insertMold
            // 
            this.insertMold.BackColor = System.Drawing.SystemColors.Window;
            this.insertMold.FlatAppearance.BorderSize = 0;
            this.insertMold.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.insertMold.Location = new System.Drawing.Point(0, 280);
            this.insertMold.Name = "insertMold";
            this.insertMold.Size = new System.Drawing.Size(66, 17);
            this.insertMold.TabIndex = 36;
            this.insertMold.Text = "INSERT";
            this.toolTip1.SetToolTip(this.insertMold, "Insert new mold");
            this.insertMold.UseCompatibleTextRendering = true;
            this.insertMold.UseVisualStyleBackColor = false;
            this.insertMold.Click += new System.EventHandler(this.insertMold_Click);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.Control;
            this.label5.Location = new System.Drawing.Point(2, 2);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(2, 2, 0, 0);
            this.label5.Size = new System.Drawing.Size(522, 17);
            this.label5.TabIndex = 375;
            this.label5.Text = "ANIMATION MOLDS...";
            // 
            // panel56
            // 
            this.panel56.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.panel56.Controls.Add(this.panel38);
            this.panel56.Controls.Add(this.label4);
            this.panel56.Controls.Add(this.pictureBoxMoldTileset);
            this.panel56.Controls.Add(this.deleteTile);
            this.panel56.Controls.Add(this.insertTile);
            this.panel56.Location = new System.Drawing.Point(138, 21);
            this.panel56.Name = "panel56";
            this.panel56.Size = new System.Drawing.Size(128, 315);
            this.panel56.TabIndex = 35;
            // 
            // panel38
            // 
            this.panel38.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.panel38.Controls.Add(this.panel33);
            this.panel38.Controls.Add(this.label6);
            this.panel38.Controls.Add(this.moldTileProperties);
            this.panel38.Controls.Add(this.label19);
            this.panel38.Controls.Add(this.panel11);
            this.panel38.Controls.Add(this.label13);
            this.panel38.Controls.Add(this.label20);
            this.panel38.Controls.Add(this.label14);
            this.panel38.Controls.Add(this.label70);
            this.panel38.Controls.Add(this.label41);
            this.panel38.Controls.Add(this.quadrantNW);
            this.panel38.Controls.Add(this.moldTileCopies);
            this.panel38.Controls.Add(this.moldSubtile);
            this.panel38.Controls.Add(this.moldTileYCoord);
            this.panel38.Controls.Add(this.quadrantSW);
            this.panel38.Controls.Add(this.moldTileCopiesOffset);
            this.panel38.Controls.Add(this.pictureBoxMoldSubtile);
            this.panel38.Controls.Add(this.panel10);
            this.panel38.Controls.Add(this.quadrantNE);
            this.panel38.Controls.Add(this.moldTileXCoord);
            this.panel38.Controls.Add(this.pictureBoxMoldTile);
            this.panel38.Controls.Add(this.quadrantSE);
            this.panel38.Location = new System.Drawing.Point(0, 103);
            this.panel38.Name = "panel38";
            this.panel38.Size = new System.Drawing.Size(128, 212);
            this.panel38.TabIndex = 41;
            // 
            // panel33
            // 
            this.panel33.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel33.Location = new System.Drawing.Point(66, 199);
            this.panel33.Name = "panel33";
            this.panel33.Size = new System.Drawing.Size(62, 13);
            this.panel33.TabIndex = 514;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label6.Location = new System.Drawing.Point(0, 19);
            this.label6.Name = "label6";
            this.label6.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label6.Size = new System.Drawing.Size(63, 17);
            this.label6.TabIndex = 416;
            this.label6.Text = "Format";
            // 
            // moldTileProperties
            // 
            this.moldTileProperties.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.moldTileProperties.CheckOnClick = true;
            this.moldTileProperties.ColumnWidth = 63;
            this.moldTileProperties.FormattingEnabled = true;
            this.moldTileProperties.Items.AddRange(new object[] {
            "Mirror",
            "Invert",
            "Y++",
            "Y––"});
            this.moldTileProperties.Location = new System.Drawing.Point(0, 55);
            this.moldTileProperties.MultiColumn = true;
            this.moldTileProperties.Name = "moldTileProperties";
            this.moldTileProperties.Size = new System.Drawing.Size(128, 32);
            this.moldTileProperties.TabIndex = 46;
            this.moldTileProperties.SelectedIndexChanged += new System.EventHandler(this.moldTileProperties_SelectedIndexChanged);
            // 
            // label19
            // 
            this.label19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label19.Location = new System.Drawing.Point(0, 124);
            this.label19.Name = "label19";
            this.label19.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label19.Size = new System.Drawing.Size(65, 17);
            this.label19.TabIndex = 416;
            this.label19.Text = "Copies";
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.moldTileSize);
            this.panel11.Location = new System.Drawing.Point(64, 19);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(65, 17);
            this.panel11.TabIndex = 41;
            // 
            // moldTileSize
            // 
            this.moldTileSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.moldTileSize.FormattingEnabled = true;
            this.moldTileSize.Items.AddRange(new object[] {
            "Normal",
            "16-bit",
            "Copy"});
            this.moldTileSize.Location = new System.Drawing.Point(-2, -2);
            this.moldTileSize.Name = "moldTileSize";
            this.moldTileSize.Size = new System.Drawing.Size(69, 21);
            this.moldTileSize.TabIndex = 41;
            this.moldTileSize.SelectedIndexChanged += new System.EventHandler(this.moldTileSize_SelectedIndexChanged);
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label13.Location = new System.Drawing.Point(0, 88);
            this.label13.Name = "label13";
            this.label13.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label13.Size = new System.Drawing.Size(65, 17);
            this.label13.TabIndex = 423;
            this.label13.Text = "X coord";
            // 
            // label20
            // 
            this.label20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label20.Location = new System.Drawing.Point(0, 142);
            this.label20.Name = "label20";
            this.label20.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label20.Size = new System.Drawing.Size(65, 17);
            this.label20.TabIndex = 415;
            this.label20.Text = "Offset";
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label14.Location = new System.Drawing.Point(0, 106);
            this.label14.Name = "label14";
            this.label14.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label14.Size = new System.Drawing.Size(65, 17);
            this.label14.TabIndex = 421;
            this.label14.Text = "Y coord";
            // 
            // label70
            // 
            this.label70.BackColor = System.Drawing.SystemColors.Control;
            this.label70.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label70.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label70.Location = new System.Drawing.Point(0, 161);
            this.label70.Name = "label70";
            this.label70.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.label70.Size = new System.Drawing.Size(130, 17);
            this.label70.TabIndex = 407;
            this.label70.Text = "SUBTILES...";
            // 
            // label41
            // 
            this.label41.BackColor = System.Drawing.SystemColors.Control;
            this.label41.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label41.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label41.Location = new System.Drawing.Point(0, 0);
            this.label41.Name = "label41";
            this.label41.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.label41.Size = new System.Drawing.Size(128, 17);
            this.label41.TabIndex = 407;
            this.label41.Text = "TILE PROPERTIES...";
            // 
            // quadrantNW
            // 
            this.quadrantNW.Appearance = System.Windows.Forms.Appearance.Button;
            this.quadrantNW.BackColor = System.Drawing.SystemColors.Control;
            this.quadrantNW.FlatAppearance.BorderSize = 0;
            this.quadrantNW.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(168)))), ((int)(((byte)(168)))));
            this.quadrantNW.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.quadrantNW.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.quadrantNW.Location = new System.Drawing.Point(0, 37);
            this.quadrantNW.Name = "quadrantNW";
            this.quadrantNW.Size = new System.Drawing.Size(31, 17);
            this.quadrantNW.TabIndex = 42;
            this.quadrantNW.Text = "NW";
            this.quadrantNW.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.quadrantNW.UseCompatibleTextRendering = true;
            this.quadrantNW.UseVisualStyleBackColor = false;
            this.quadrantNW.CheckedChanged += new System.EventHandler(this.quadrantNW_CheckedChanged);
            // 
            // moldTileCopies
            // 
            this.moldTileCopies.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.moldTileCopies.Location = new System.Drawing.Point(66, 124);
            this.moldTileCopies.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.moldTileCopies.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.moldTileCopies.Name = "moldTileCopies";
            this.moldTileCopies.Size = new System.Drawing.Size(63, 17);
            this.moldTileCopies.TabIndex = 49;
            this.moldTileCopies.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.moldTileCopies.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.moldTileCopies.ValueChanged += new System.EventHandler(this.moldTileCopies_ValueChanged);
            // 
            // moldSubtile
            // 
            this.moldSubtile.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.moldSubtile.Location = new System.Drawing.Point(66, 180);
            this.moldSubtile.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.moldSubtile.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.moldSubtile.Name = "moldSubtile";
            this.moldSubtile.Size = new System.Drawing.Size(63, 17);
            this.moldSubtile.TabIndex = 52;
            this.moldSubtile.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.moldSubtile.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.moldSubtile.ValueChanged += new System.EventHandler(this.moldSubtile_ValueChanged);
            // 
            // moldTileYCoord
            // 
            this.moldTileYCoord.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.moldTileYCoord.Location = new System.Drawing.Point(66, 106);
            this.moldTileYCoord.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.moldTileYCoord.Name = "moldTileYCoord";
            this.moldTileYCoord.Size = new System.Drawing.Size(63, 17);
            this.moldTileYCoord.TabIndex = 48;
            this.moldTileYCoord.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.moldTileYCoord.ValueChanged += new System.EventHandler(this.moldTileYCoord_ValueChanged);
            // 
            // quadrantSW
            // 
            this.quadrantSW.Appearance = System.Windows.Forms.Appearance.Button;
            this.quadrantSW.BackColor = System.Drawing.SystemColors.Control;
            this.quadrantSW.FlatAppearance.BorderSize = 0;
            this.quadrantSW.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(168)))), ((int)(((byte)(168)))));
            this.quadrantSW.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.quadrantSW.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.quadrantSW.Location = new System.Drawing.Point(64, 37);
            this.quadrantSW.Name = "quadrantSW";
            this.quadrantSW.Size = new System.Drawing.Size(31, 17);
            this.quadrantSW.TabIndex = 44;
            this.quadrantSW.Text = "SW";
            this.quadrantSW.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.quadrantSW.UseCompatibleTextRendering = true;
            this.quadrantSW.UseVisualStyleBackColor = false;
            this.quadrantSW.CheckedChanged += new System.EventHandler(this.quadrantSW_CheckedChanged);
            // 
            // moldTileCopiesOffset
            // 
            this.moldTileCopiesOffset.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.moldTileCopiesOffset.Hexadecimal = true;
            this.moldTileCopiesOffset.Location = new System.Drawing.Point(66, 142);
            this.moldTileCopiesOffset.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.moldTileCopiesOffset.Name = "moldTileCopiesOffset";
            this.moldTileCopiesOffset.Size = new System.Drawing.Size(63, 17);
            this.moldTileCopiesOffset.TabIndex = 50;
            this.moldTileCopiesOffset.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.moldTileCopiesOffset.ValueChanged += new System.EventHandler(this.moldTileCopiesOffset_ValueChanged);
            // 
            // pictureBoxMoldSubtile
            // 
            this.pictureBoxMoldSubtile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.pictureBoxMoldSubtile.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBoxMoldSubtile.BackgroundImage")));
            this.pictureBoxMoldSubtile.Location = new System.Drawing.Point(33, 180);
            this.pictureBoxMoldSubtile.Name = "pictureBoxMoldSubtile";
            this.pictureBoxMoldSubtile.Size = new System.Drawing.Size(32, 32);
            this.pictureBoxMoldSubtile.TabIndex = 450;
            this.pictureBoxMoldSubtile.TabStop = false;
            this.pictureBoxMoldSubtile.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxMoldSubtile_Paint);
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.comboBox3);
            this.panel10.Location = new System.Drawing.Point(64, 19);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(65, 17);
            this.panel10.TabIndex = 405;
            // 
            // comboBox3
            // 
            this.comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Items.AddRange(new object[] {
            "Gridplane",
            "16x16 mapped"});
            this.comboBox3.Location = new System.Drawing.Point(-2, -2);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(53, 21);
            this.comboBox3.TabIndex = 400;
            // 
            // quadrantNE
            // 
            this.quadrantNE.Appearance = System.Windows.Forms.Appearance.Button;
            this.quadrantNE.BackColor = System.Drawing.SystemColors.Control;
            this.quadrantNE.FlatAppearance.BorderSize = 0;
            this.quadrantNE.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(168)))), ((int)(((byte)(168)))));
            this.quadrantNE.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.quadrantNE.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.quadrantNE.Location = new System.Drawing.Point(32, 37);
            this.quadrantNE.Name = "quadrantNE";
            this.quadrantNE.Size = new System.Drawing.Size(31, 17);
            this.quadrantNE.TabIndex = 43;
            this.quadrantNE.Text = "NE";
            this.quadrantNE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.quadrantNE.UseCompatibleTextRendering = true;
            this.quadrantNE.UseVisualStyleBackColor = false;
            this.quadrantNE.CheckedChanged += new System.EventHandler(this.quadrantNE_CheckedChanged);
            // 
            // moldTileXCoord
            // 
            this.moldTileXCoord.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.moldTileXCoord.Location = new System.Drawing.Point(66, 88);
            this.moldTileXCoord.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.moldTileXCoord.Name = "moldTileXCoord";
            this.moldTileXCoord.Size = new System.Drawing.Size(63, 17);
            this.moldTileXCoord.TabIndex = 47;
            this.moldTileXCoord.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.moldTileXCoord.ValueChanged += new System.EventHandler(this.moldTileXCoord_ValueChanged);
            // 
            // pictureBoxMoldTile
            // 
            this.pictureBoxMoldTile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.pictureBoxMoldTile.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBoxMoldTile.BackgroundImage")));
            this.pictureBoxMoldTile.Location = new System.Drawing.Point(0, 180);
            this.pictureBoxMoldTile.Name = "pictureBoxMoldTile";
            this.pictureBoxMoldTile.Size = new System.Drawing.Size(32, 32);
            this.pictureBoxMoldTile.TabIndex = 449;
            this.pictureBoxMoldTile.TabStop = false;
            this.pictureBoxMoldTile.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBoxMoldTile_MouseClick);
            this.pictureBoxMoldTile.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxMoldTile_Paint);
            // 
            // quadrantSE
            // 
            this.quadrantSE.Appearance = System.Windows.Forms.Appearance.Button;
            this.quadrantSE.BackColor = System.Drawing.SystemColors.Control;
            this.quadrantSE.FlatAppearance.BorderSize = 0;
            this.quadrantSE.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(168)))), ((int)(((byte)(168)))));
            this.quadrantSE.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.quadrantSE.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.quadrantSE.Location = new System.Drawing.Point(96, 37);
            this.quadrantSE.Name = "quadrantSE";
            this.quadrantSE.Size = new System.Drawing.Size(31, 17);
            this.quadrantSE.TabIndex = 45;
            this.quadrantSE.Text = "SE";
            this.quadrantSE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.quadrantSE.UseCompatibleTextRendering = true;
            this.quadrantSE.UseVisualStyleBackColor = false;
            this.quadrantSE.CheckedChanged += new System.EventHandler(this.quadrantSE_CheckedChanged);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.Control;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.label4.Size = new System.Drawing.Size(128, 17);
            this.label4.TabIndex = 407;
            this.label4.Text = "MOLD TILES...";
            // 
            // pictureBoxMoldTileset
            // 
            this.pictureBoxMoldTileset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.pictureBoxMoldTileset.BackgroundImage = global::LAZYSHELL.Properties.Resources._transparent;
            this.pictureBoxMoldTileset.Location = new System.Drawing.Point(0, 19);
            this.pictureBoxMoldTileset.Name = "pictureBoxMoldTileset";
            this.pictureBoxMoldTileset.Size = new System.Drawing.Size(128, 64);
            this.pictureBoxMoldTileset.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxMoldTileset.TabIndex = 397;
            this.pictureBoxMoldTileset.TabStop = false;
            this.pictureBoxMoldTileset.MouseLeave += new System.EventHandler(this.pictureBoxMoldTileset_MouseLeave);
            this.pictureBoxMoldTileset.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxMoldTileset_MouseMove);
            this.pictureBoxMoldTileset.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxMoldTileset_MouseDown);
            this.pictureBoxMoldTileset.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxMoldTileset_Paint);
            this.pictureBoxMoldTileset.MouseEnter += new System.EventHandler(this.pictureBoxMoldTileset_MouseEnter);
            // 
            // deleteTile
            // 
            this.deleteTile.BackColor = System.Drawing.SystemColors.Window;
            this.deleteTile.FlatAppearance.BorderSize = 0;
            this.deleteTile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteTile.Location = new System.Drawing.Point(64, 84);
            this.deleteTile.Name = "deleteTile";
            this.deleteTile.Size = new System.Drawing.Size(64, 17);
            this.deleteTile.TabIndex = 40;
            this.deleteTile.Text = "DELETE";
            this.toolTip1.SetToolTip(this.deleteTile, "Delete selected tile");
            this.deleteTile.UseCompatibleTextRendering = true;
            this.deleteTile.UseVisualStyleBackColor = false;
            this.deleteTile.Click += new System.EventHandler(this.deleteTile_Click);
            // 
            // insertTile
            // 
            this.insertTile.BackColor = System.Drawing.SystemColors.Window;
            this.insertTile.FlatAppearance.BorderSize = 0;
            this.insertTile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.insertTile.Location = new System.Drawing.Point(0, 84);
            this.insertTile.Name = "insertTile";
            this.insertTile.Size = new System.Drawing.Size(63, 17);
            this.insertTile.TabIndex = 39;
            this.insertTile.Text = "INSERT";
            this.toolTip1.SetToolTip(this.insertTile, "Insert new tile");
            this.insertTile.UseCompatibleTextRendering = true;
            this.insertTile.UseVisualStyleBackColor = false;
            this.insertTile.Click += new System.EventHandler(this.insertTile_Click);
            // 
            // panel45
            // 
            this.panel45.Controls.Add(this.searchSpriteNames);
            this.panel45.Controls.Add(this.panel4);
            this.panel45.Controls.Add(this.spriteNum);
            this.panel45.Controls.Add(this.graphicPalettePacket);
            this.panel45.Controls.Add(this.graphicPalettePacketShift);
            this.panel45.Controls.Add(this.label71);
            this.panel45.Controls.Add(this.label73);
            this.panel45.Controls.Add(this.label1);
            this.panel45.Location = new System.Drawing.Point(6, 6);
            this.panel45.Name = "panel45";
            this.panel45.Size = new System.Drawing.Size(260, 59);
            this.panel45.TabIndex = 2;
            // 
            // searchSpriteNames
            // 
            this.searchSpriteNames.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.searchSpriteNames.BackColor = System.Drawing.SystemColors.ControlDark;
            this.searchSpriteNames.BackgroundImage = global::LAZYSHELL.Properties.Resources.search;
            this.searchSpriteNames.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.searchSpriteNames.FlatAppearance.BorderSize = 0;
            this.searchSpriteNames.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.searchSpriteNames.Location = new System.Drawing.Point(2, 2);
            this.searchSpriteNames.Name = "searchSpriteNames";
            this.searchSpriteNames.Size = new System.Drawing.Size(19, 17);
            this.searchSpriteNames.TabIndex = 395;
            this.toolTip1.SetToolTip(this.searchSpriteNames, "Search for sprite name");
            this.searchSpriteNames.UseCompatibleTextRendering = true;
            this.searchSpriteNames.UseVisualStyleBackColor = false;
            this.searchSpriteNames.Click += new System.EventHandler(this.searchSpriteNames_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.spriteName);
            this.panel4.Location = new System.Drawing.Point(23, 2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(236, 17);
            this.panel4.TabIndex = 1;
            // 
            // spriteName
            // 
            this.spriteName.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.spriteName.ContextMenuStrip = this.contextMenuStrip2;
            this.spriteName.DropDownHeight = 613;
            this.spriteName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.spriteName.DropDownWidth = 340;
            this.spriteName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spriteName.ForeColor = System.Drawing.SystemColors.Control;
            this.spriteName.FormattingEnabled = true;
            this.spriteName.IntegralHeight = false;
            this.spriteName.Location = new System.Drawing.Point(-2, -2);
            this.spriteName.Name = "spriteName";
            this.spriteName.Size = new System.Drawing.Size(240, 21);
            this.spriteName.TabIndex = 291;
            this.spriteName.SelectedIndexChanged += new System.EventHandler(this.spriteName_SelectedIndexChanged);
            // 
            // spriteNum
            // 
            this.spriteNum.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.spriteNum.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.spriteNum.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spriteNum.ForeColor = System.Drawing.SystemColors.Control;
            this.spriteNum.Location = new System.Drawing.Point(131, 21);
            this.spriteNum.Maximum = new decimal(new int[] {
            1023,
            0,
            0,
            0});
            this.spriteNum.Name = "spriteNum";
            this.spriteNum.Size = new System.Drawing.Size(128, 17);
            this.spriteNum.TabIndex = 2;
            this.spriteNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.spriteNum.ValueChanged += new System.EventHandler(this.spriteNum_ValueChanged);
            // 
            // graphicPalettePacket
            // 
            this.graphicPalettePacket.BackColor = System.Drawing.SystemColors.ControlDark;
            this.graphicPalettePacket.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.graphicPalettePacket.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.graphicPalettePacket.ForeColor = System.Drawing.SystemColors.Control;
            this.graphicPalettePacket.Location = new System.Drawing.Point(67, 40);
            this.graphicPalettePacket.Maximum = new decimal(new int[] {
            511,
            0,
            0,
            0});
            this.graphicPalettePacket.Name = "graphicPalettePacket";
            this.graphicPalettePacket.Size = new System.Drawing.Size(63, 17);
            this.graphicPalettePacket.TabIndex = 3;
            this.graphicPalettePacket.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.graphicPalettePacket.ValueChanged += new System.EventHandler(this.graphicPalettePacket_ValueChanged);
            // 
            // graphicPalettePacketShift
            // 
            this.graphicPalettePacketShift.BackColor = System.Drawing.SystemColors.ControlDark;
            this.graphicPalettePacketShift.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.graphicPalettePacketShift.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.graphicPalettePacketShift.ForeColor = System.Drawing.SystemColors.Control;
            this.graphicPalettePacketShift.Location = new System.Drawing.Point(200, 40);
            this.graphicPalettePacketShift.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.graphicPalettePacketShift.Name = "graphicPalettePacketShift";
            this.graphicPalettePacketShift.Size = new System.Drawing.Size(59, 17);
            this.graphicPalettePacketShift.TabIndex = 4;
            this.graphicPalettePacketShift.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.graphicPalettePacketShift.ValueChanged += new System.EventHandler(this.graphicPalettePacketShift_ValueChanged);
            // 
            // label71
            // 
            this.label71.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label71.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label71.ForeColor = System.Drawing.SystemColors.Control;
            this.label71.Location = new System.Drawing.Point(2, 40);
            this.label71.Name = "label71";
            this.label71.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label71.Size = new System.Drawing.Size(64, 17);
            this.label71.TabIndex = 394;
            this.label71.Text = "IMAGE #";
            // 
            // label73
            // 
            this.label73.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label73.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label73.ForeColor = System.Drawing.SystemColors.Control;
            this.label73.Location = new System.Drawing.Point(131, 40);
            this.label73.Name = "label73";
            this.label73.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label73.Size = new System.Drawing.Size(68, 17);
            this.label73.TabIndex = 394;
            this.label73.Text = "PALETTE +";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(2, 21);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label1.Size = new System.Drawing.Size(128, 17);
            this.label1.TabIndex = 290;
            this.label1.Text = "SPRITE #";
            // 
            // panelImageGraphics
            // 
            this.panelImageGraphics.Controls.Add(this.panelImageGraphicsSub);
            this.panelImageGraphics.Location = new System.Drawing.Point(6, 254);
            this.panelImageGraphics.Name = "panelImageGraphics";
            this.panelImageGraphics.Size = new System.Drawing.Size(260, 394);
            this.panelImageGraphics.TabIndex = 4;
            this.panelImageGraphics.MouseLeave += new System.EventHandler(this.panelImageGraphics_MouseLeave);
            this.panelImageGraphics.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelImageGraphics_MouseMove);
            this.panelImageGraphics.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelImageGraphics_MouseDown);
            // 
            // panelImageGraphicsSub
            // 
            this.panelImageGraphicsSub.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelImageGraphicsSub.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.panelImageGraphicsSub.Controls.Add(this.coordsLabel);
            this.panelImageGraphicsSub.Controls.Add(this.panel31);
            this.panelImageGraphicsSub.Controls.Add(this.labelImageGraphics);
            this.panelImageGraphicsSub.Controls.Add(this.graphicOffset);
            this.panelImageGraphicsSub.Controls.Add(this.label9);
            this.panelImageGraphicsSub.Controls.Add(this.panel37);
            this.panelImageGraphicsSub.Location = new System.Drawing.Point(2, 2);
            this.panelImageGraphicsSub.Name = "panelImageGraphicsSub";
            this.panelImageGraphicsSub.Size = new System.Drawing.Size(256, 390);
            this.panelImageGraphicsSub.TabIndex = 513;
            // 
            // coordsLabel
            // 
            this.coordsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.coordsLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.coordsLabel.Location = new System.Drawing.Point(129, 19);
            this.coordsLabel.Name = "coordsLabel";
            this.coordsLabel.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.coordsLabel.Size = new System.Drawing.Size(127, 17);
            this.coordsLabel.TabIndex = 525;
            this.coordsLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // panel31
            // 
            this.panel31.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel31.BackColor = System.Drawing.SystemColors.Control;
            this.panel31.Controls.Add(this.toolStrip1);
            this.panel31.Location = new System.Drawing.Point(0, 37);
            this.panel31.Name = "panel31";
            this.panel31.Size = new System.Drawing.Size(256, 18);
            this.panel31.TabIndex = 51;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.CanOverflow = false;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripSeparator10,
            this.graphicShowGrid,
            this.graphicShowPixelGrid,
            this.toolStripSeparator11,
            this.subtileDraw,
            this.subtileErase,
            this.subtileDropper,
            this.toolStripSeparator12,
            this.graphicZoomIn,
            this.graphicZoomOut});
            this.toolStrip1.Location = new System.Drawing.Point(0, -1);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0);
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(256, 20);
            this.toolStrip1.TabIndex = 51;
            this.toolStrip1.TabStop = true;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.toolStripLabel1.Margin = new System.Windows.Forms.Padding(4, 1, 0, 2);
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(33, 17);
            this.toolStripLabel1.Text = "EDIT";
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Margin = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(6, 20);
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
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Margin = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(6, 20);
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
            // toolStripSeparator12
            // 
            this.toolStripSeparator12.Margin = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            this.toolStripSeparator12.Size = new System.Drawing.Size(6, 20);
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
            // labelImageGraphics
            // 
            this.labelImageGraphics.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.labelImageGraphics.BackColor = System.Drawing.SystemColors.ControlDark;
            this.labelImageGraphics.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.labelImageGraphics.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelImageGraphics.ForeColor = System.Drawing.SystemColors.Control;
            this.labelImageGraphics.Location = new System.Drawing.Point(0, 0);
            this.labelImageGraphics.Name = "labelImageGraphics";
            this.labelImageGraphics.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.labelImageGraphics.Size = new System.Drawing.Size(256, 17);
            this.labelImageGraphics.TabIndex = 417;
            this.labelImageGraphics.Text = "IMAGE GRAPHICS...";
            this.labelImageGraphics.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.labelImageGraphics, "Click to drag or double-click to maximize / restore");
            this.labelImageGraphics.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.labelImageGraphics_MouseDoubleClick);
            this.labelImageGraphics.MouseDown += new System.Windows.Forms.MouseEventHandler(this.labelImageGraphics_MouseDown);
            this.labelImageGraphics.MouseUp += new System.Windows.Forms.MouseEventHandler(this.labelImageGraphics_MouseUp);
            // 
            // graphicOffset
            // 
            this.graphicOffset.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.graphicOffset.Hexadecimal = true;
            this.graphicOffset.Increment = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.graphicOffset.Location = new System.Drawing.Point(65, 19);
            this.graphicOffset.Maximum = new decimal(new int[] {
            3342320,
            0,
            0,
            0});
            this.graphicOffset.Minimum = new decimal(new int[] {
            2621440,
            0,
            0,
            0});
            this.graphicOffset.Name = "graphicOffset";
            this.graphicOffset.Size = new System.Drawing.Size(63, 17);
            this.graphicOffset.TabIndex = 16;
            this.graphicOffset.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.graphicOffset.Value = new decimal(new int[] {
            2621440,
            0,
            0,
            0});
            this.graphicOffset.ValueChanged += new System.EventHandler(this.graphicOffset_ValueChanged);
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label9.Location = new System.Drawing.Point(0, 19);
            this.label9.Name = "label9";
            this.label9.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label9.Size = new System.Drawing.Size(64, 17);
            this.label9.TabIndex = 394;
            this.label9.Text = "Offset";
            // 
            // panel37
            // 
            this.panel37.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel37.AutoScroll = true;
            this.panel37.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel37.Controls.Add(this.pictureBoxGraphics);
            this.panel37.Location = new System.Drawing.Point(0, 55);
            this.panel37.Name = "panel37";
            this.panel37.Size = new System.Drawing.Size(256, 335);
            this.panel37.TabIndex = 524;
            this.panel37.Scroll += new System.Windows.Forms.ScrollEventHandler(this.panel37_Scroll);
            // 
            // pictureBoxGraphics
            // 
            this.pictureBoxGraphics.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pictureBoxGraphics.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBoxGraphics.BackgroundImage")));
            this.pictureBoxGraphics.ContextMenuStrip = this.contextMenuStripGR;
            this.pictureBoxGraphics.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxGraphics.Name = "pictureBoxGraphics";
            this.pictureBoxGraphics.Size = new System.Drawing.Size(128, 256);
            this.pictureBoxGraphics.TabIndex = 396;
            this.pictureBoxGraphics.TabStop = false;
            this.pictureBoxGraphics.MouseLeave += new System.EventHandler(this.pictureBoxGraphics_MouseLeave);
            this.pictureBoxGraphics.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.pictureBoxGraphics_PreviewKeyDown);
            this.pictureBoxGraphics.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxGraphics_MouseMove);
            this.pictureBoxGraphics.Click += new System.EventHandler(this.pictureBoxGraphics_Click);
            this.pictureBoxGraphics.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pictureBoxGraphics_MouseDoubleClick);
            this.pictureBoxGraphics.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxGraphics_MouseDown);
            this.pictureBoxGraphics.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxGraphics_Paint);
            this.pictureBoxGraphics.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBoxGraphics_MouseUp);
            this.pictureBoxGraphics.MouseEnter += new System.EventHandler(this.pictureBoxGraphics_MouseEnter);
            // 
            // panelSearchSpriteNames
            // 
            this.panelSearchSpriteNames.BackColor = System.Drawing.SystemColors.ControlText;
            this.panelSearchSpriteNames.Controls.Add(this.listBoxSpriteNames);
            this.panelSearchSpriteNames.Controls.Add(this.panel28);
            this.panelSearchSpriteNames.Location = new System.Drawing.Point(6, 25);
            this.panelSearchSpriteNames.Name = "panelSearchSpriteNames";
            this.panelSearchSpriteNames.Size = new System.Drawing.Size(454, 426);
            this.panelSearchSpriteNames.TabIndex = 516;
            this.panelSearchSpriteNames.Visible = false;
            // 
            // listBoxSpriteNames
            // 
            this.listBoxSpriteNames.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBoxSpriteNames.FormattingEnabled = true;
            this.listBoxSpriteNames.Location = new System.Drawing.Point(2, 21);
            this.listBoxSpriteNames.Name = "listBoxSpriteNames";
            this.listBoxSpriteNames.Size = new System.Drawing.Size(450, 403);
            this.listBoxSpriteNames.TabIndex = 194;
            this.listBoxSpriteNames.SelectedIndexChanged += new System.EventHandler(this.listBoxSpriteNames_SelectedIndexChanged);
            this.listBoxSpriteNames.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listBoxSpriteNames_KeyDown);
            // 
            // panel28
            // 
            this.panel28.BackColor = System.Drawing.SystemColors.Window;
            this.panel28.Controls.Add(this.nameTextBox);
            this.panel28.Location = new System.Drawing.Point(2, 2);
            this.panel28.Name = "panel28";
            this.panel28.Size = new System.Drawing.Size(450, 17);
            this.panel28.TabIndex = 193;
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
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabControl1.ItemSize = new System.Drawing.Size(26, 166);
            this.tabControl1.Location = new System.Drawing.Point(8, 30);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(988, 666);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 1;
            this.tabControl1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabControl1_DrawItem);
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.SystemColors.ControlText;
            this.tabPage4.Controls.Add(this.panelEffects);
            this.tabPage4.Location = new System.Drawing.Point(175, 4);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(809, 658);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "SPELL EFFECTS";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // panelEffects
            // 
            this.panelEffects.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelEffects.BackgroundImage = global::LAZYSHELL.Properties.Resources._bg;
            this.panelEffects.Controls.Add(this.panelInsertTile);
            this.panelEffects.Controls.Add(this.panel106);
            this.panelEffects.Controls.Add(this.panel103);
            this.panelEffects.Controls.Add(this.panel105);
            this.panelEffects.Controls.Add(this.panel99);
            this.panelEffects.Controls.Add(this.panel90);
            this.panelEffects.Controls.Add(this.panelEffectGraphics);
            this.panelEffects.Controls.Add(this.panel80);
            this.panelEffects.Controls.Add(this.panel41);
            this.panelEffects.Controls.Add(this.panelSearchEffectNames);
            this.panelEffects.Location = new System.Drawing.Point(2, 2);
            this.panelEffects.Name = "panelEffects";
            this.panelEffects.Size = new System.Drawing.Size(805, 654);
            this.panelEffects.TabIndex = 0;
            this.panelEffects.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelEffects_MouseMove);
            this.panelEffects.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelEffects_MouseUp);
            // 
            // panel106
            // 
            this.panel106.Controls.Add(this.searchEffectNames);
            this.panel106.Controls.Add(this.e_availableBytes);
            this.panel106.Controls.Add(this.label57);
            this.panel106.Controls.Add(this.panel44);
            this.panel106.Controls.Add(this.effectNum);
            this.panel106.Location = new System.Drawing.Point(6, 6);
            this.panel106.Name = "panel106";
            this.panel106.Size = new System.Drawing.Size(260, 59);
            this.panel106.TabIndex = 519;
            // 
            // searchEffectNames
            // 
            this.searchEffectNames.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.searchEffectNames.BackColor = System.Drawing.SystemColors.ControlDark;
            this.searchEffectNames.BackgroundImage = global::LAZYSHELL.Properties.Resources.search;
            this.searchEffectNames.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.searchEffectNames.FlatAppearance.BorderSize = 0;
            this.searchEffectNames.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.searchEffectNames.Location = new System.Drawing.Point(2, 2);
            this.searchEffectNames.Name = "searchEffectNames";
            this.searchEffectNames.Size = new System.Drawing.Size(19, 17);
            this.searchEffectNames.TabIndex = 452;
            this.toolTip1.SetToolTip(this.searchEffectNames, "Search for sprite name");
            this.searchEffectNames.UseCompatibleTextRendering = true;
            this.searchEffectNames.UseVisualStyleBackColor = false;
            this.searchEffectNames.Click += new System.EventHandler(this.searchEffectNames_Click);
            // 
            // e_availableBytes
            // 
            this.e_availableBytes.BackColor = System.Drawing.SystemColors.Control;
            this.e_availableBytes.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.e_availableBytes.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.e_availableBytes.Location = new System.Drawing.Point(2, 40);
            this.e_availableBytes.Name = "e_availableBytes";
            this.e_availableBytes.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.e_availableBytes.Size = new System.Drawing.Size(256, 17);
            this.e_availableBytes.TabIndex = 451;
            this.e_availableBytes.Text = "AVAILABLE BYTES: ";
            // 
            // label57
            // 
            this.label57.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label57.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label57.ForeColor = System.Drawing.SystemColors.Control;
            this.label57.Location = new System.Drawing.Point(2, 21);
            this.label57.Name = "label57";
            this.label57.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label57.Size = new System.Drawing.Size(128, 17);
            this.label57.TabIndex = 290;
            this.label57.Text = "EFFECT #";
            // 
            // panel44
            // 
            this.panel44.Controls.Add(this.effectName);
            this.panel44.Location = new System.Drawing.Point(23, 2);
            this.panel44.Name = "panel44";
            this.panel44.Size = new System.Drawing.Size(236, 17);
            this.panel44.TabIndex = 1;
            // 
            // effectName
            // 
            this.effectName.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.effectName.ContextMenuStrip = this.contextMenuStrip2;
            this.effectName.DropDownHeight = 613;
            this.effectName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.effectName.DropDownWidth = 200;
            this.effectName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.effectName.ForeColor = System.Drawing.SystemColors.Control;
            this.effectName.FormattingEnabled = true;
            this.effectName.IntegralHeight = false;
            this.effectName.Items.AddRange(new object[] {
            "[000]  ___DUMMY",
            "[001]  ___DUMMY",
            "[002]  Thundershock",
            "[003]  Thundershock (BG mask)",
            "[004]  Crusher",
            "[005]  Meteor Blast",
            "[006]  Bolt",
            "[007]  Star Rain",
            "[008]  Flame (fire engulf)",
            "[009]  Mute (balloon)",
            "[010]  Flame Stone",
            "[011]  Bowser Crush",
            "[012]  spell cast spade",
            "[013]  spell cast heart",
            "[014]  spell cast club",
            "[015]  spell cast diamond",
            "[016]  spell cast star",
            "[017]  Terrorize",
            "[018]  Snowy (snow BG, 4bpp)",
            "[019]  Snowy (snow FG, 2bpp)",
            "[020]  Endobubble (black ball/orb)",
            "[021]  ___DUMMY",
            "[022]  Solidify",
            "[023]  ___DUMMY",
            "[024]  ___DUMMY",
            "[025]  Psych Bomb (BG)",
            "[026]  ___DUMMY",
            "[027]  Dark Star",
            "[028]  Willy Wisp (blue orb/ball BG)",
            "[029]  ___DUMMY",
            "[030]  ___DUMMY",
            "[031]  ___DUMMY",
            "[032]  Geno Whirl",
            "[033]  ___DUMMY",
            "[034]  ___DUMMY",
            "[035]  ___DUMMY",
            "[036]  blank white flash (2bpp)",
            "[037]  blank white flash (4bpp)",
            "[038]  Boulder",
            "[039]  black ball/orb",
            "[040]  blank blue flash (2bpp)",
            "[041]  blank red flash (2bpp)",
            "[042]  blank blue flash (4bpp)",
            "[043]  blank red flash (4bpp)",
            "[044]  ___DUMMY",
            "[045]  black flash (2bpp)",
            "[046]  black flash (4bpp)",
            "[047]  Meteor Shower (snow/confetti)",
            "[048]  purple/violet flash (4bpp)",
            "[049]  brown flash (4bpp)",
            "[050]  dark red blast",
            "[051]  dark blue blast",
            "[052]  snow/confetti, green",
            "[053]  light blue blast",
            "[054]  black ball/orb",
            "[055]  red ball/orb",
            "[056]  green ball/orb",
            "[057]  snow/confetti, slate green",
            "[058]  snow/confetti, red",
            "[059]  orange/red blast (Fire Bomb)",
            "[060]  Ice bomb/Solidify BG (blue freeze)",
            "[061]  Static E! (electric blast)",
            "[062]  green star bunches",
            "[063]  blue star bunches",
            "[064]  pink star bunches",
            "[065]  yellow star bunches",
            "[066]  Aurora Flash",
            "[067]  Storm",
            "[068]  Electroshock",
            "[069]  Smithy Treasure Head spell, red",
            "[070]  Smithy Treasure Head spell, green",
            "[071]  Smithy Treasure Head spell, blue",
            "[072]  Smithy Treasure Head spell, yellow",
            "[073]  ___DUMMY",
            "[074]  ___DUMMY",
            "[075]  ___DUMMY",
            "[076]  Flame Wall (orange/red fire)",
            "[077]  Petal Blast 1",
            "[078]  Petal Blast 2",
            "[079]  Drain Beam BG (4bpp)",
            "[080]  Drain Beam FG (2bpp)",
            "[081]  ___DUMMY",
            "[082]  electric bolt",
            "[083]  black flash (2bpp)",
            "[084]  ___DUMMY",
            "[085]  Pollen Nap (yellow pollen)",
            "[086]  Geno Beam, blue",
            "[087]  Geno Beam, red",
            "[088]  Geno Beam, gold",
            "[089]  Geno Beam, yellow",
            "[090]  Geno Beam, green",
            "[091]  Thunderbolt",
            "[092]  Light Beam",
            "[093]  Meteor Shower",
            "[094]  S\'Crow Dust (purple pollen)",
            "[095]  HP Rain BG",
            "[096]  HP Rain FG",
            "[097]  wavy dark blue lines",
            "[098]  wavy blue lines",
            "[099]  wavy red lines",
            "[100]  wavy brown lines",
            "[101]  Sand Storm",
            "[102]  Sledge",
            "[103]  Arrow Rain",
            "[104]  Spear Rain",
            "[105]  Sword Rain",
            "[106]  Lightning Orb (BG waves)",
            "[107]  Echofinder",
            "[108]  Poison Gas FG 1",
            "[109]  Poison Gas FG 2",
            "[110]  Poison Gas BG",
            "[111]  Smithy Transforms (beam effect)",
            "[112]  Smelter\'s molten metal",
            "[113]  ___DUMMY",
            "[114]  ___DUMMY",
            "[115]  ___DUMMY",
            "[116]  ___DUMMY",
            "[117]  ___DUMMY",
            "[118]  ___DUMMY",
            "[119]  ___DUMMY",
            "[120]  ___DUMMY",
            "[121]  ___DUMMY",
            "[122]  ___DUMMY",
            "[123]  ___DUMMY",
            "[124]  ___DUMMY",
            "[125]  ___DUMMY",
            "[126]  ___DUMMY",
            "[127]  ___DUMMY"});
            this.effectName.Location = new System.Drawing.Point(-2, -2);
            this.effectName.Name = "effectName";
            this.effectName.Size = new System.Drawing.Size(240, 21);
            this.effectName.TabIndex = 291;
            this.effectName.SelectedIndexChanged += new System.EventHandler(this.effectName_SelectedIndexChanged);
            // 
            // effectNum
            // 
            this.effectNum.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.effectNum.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.effectNum.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.effectNum.ForeColor = System.Drawing.SystemColors.Control;
            this.effectNum.Location = new System.Drawing.Point(131, 21);
            this.effectNum.Maximum = new decimal(new int[] {
            127,
            0,
            0,
            0});
            this.effectNum.Name = "effectNum";
            this.effectNum.Size = new System.Drawing.Size(128, 17);
            this.effectNum.TabIndex = 2;
            this.effectNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.effectNum.ValueChanged += new System.EventHandler(this.effectNum_ValueChanged);
            // 
            // panel103
            // 
            this.panel103.Controls.Add(this.label108);
            this.panel103.Controls.Add(this.e_playSequence);
            this.panel103.Controls.Add(this.e_pauseSequence);
            this.panel103.Controls.Add(this.label111);
            this.panel103.Controls.Add(this.e_moveBack);
            this.panel103.Controls.Add(this.panel107);
            this.panel103.Controls.Add(this.e_moveFoward);
            this.panel103.Controls.Add(this.pictureBoxE_Sequence);
            this.panel103.Location = new System.Drawing.Point(410, 6);
            this.panel103.Name = "panel103";
            this.panel103.Size = new System.Drawing.Size(388, 298);
            this.panel103.TabIndex = 518;
            // 
            // label108
            // 
            this.label108.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label108.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label108.ForeColor = System.Drawing.SystemColors.Control;
            this.label108.Location = new System.Drawing.Point(2, 2);
            this.label108.Name = "label108";
            this.label108.Padding = new System.Windows.Forms.Padding(2, 2, 0, 0);
            this.label108.Size = new System.Drawing.Size(384, 17);
            this.label108.TabIndex = 375;
            this.label108.Text = "ANIMATION SEQUENCE...";
            // 
            // e_playSequence
            // 
            this.e_playSequence.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.e_playSequence.FlatAppearance.BorderSize = 0;
            this.e_playSequence.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.e_playSequence.Image = global::LAZYSHELL.Properties.Resources.play;
            this.e_playSequence.Location = new System.Drawing.Point(130, 279);
            this.e_playSequence.Name = "e_playSequence";
            this.e_playSequence.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.e_playSequence.Size = new System.Drawing.Size(22, 17);
            this.e_playSequence.TabIndex = 30;
            this.toolTip1.SetToolTip(this.e_playSequence, "Play animation");
            this.e_playSequence.UseCompatibleTextRendering = true;
            this.e_playSequence.UseVisualStyleBackColor = false;
            this.e_playSequence.Click += new System.EventHandler(this.e_playSequence_Click);
            // 
            // e_pauseSequence
            // 
            this.e_pauseSequence.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.e_pauseSequence.FlatAppearance.BorderSize = 0;
            this.e_pauseSequence.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.e_pauseSequence.Image = global::LAZYSHELL.Properties.Resources.stop;
            this.e_pauseSequence.Location = new System.Drawing.Point(153, 279);
            this.e_pauseSequence.Name = "e_pauseSequence";
            this.e_pauseSequence.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.e_pauseSequence.Size = new System.Drawing.Size(22, 17);
            this.e_pauseSequence.TabIndex = 31;
            this.toolTip1.SetToolTip(this.e_pauseSequence, "Pause animation");
            this.e_pauseSequence.UseCompatibleTextRendering = true;
            this.e_pauseSequence.UseVisualStyleBackColor = false;
            this.e_pauseSequence.Click += new System.EventHandler(this.e_pauseSequence_Click);
            // 
            // label111
            // 
            this.label111.BackColor = System.Drawing.SystemColors.Control;
            this.label111.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label111.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label111.Location = new System.Drawing.Point(130, 21);
            this.label111.Name = "label111";
            this.label111.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label111.Size = new System.Drawing.Size(256, 17);
            this.label111.TabIndex = 375;
            this.label111.Text = "SEQUENCE PREVIEW";
            // 
            // e_moveBack
            // 
            this.e_moveBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.e_moveBack.FlatAppearance.BorderSize = 0;
            this.e_moveBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.e_moveBack.Image = global::LAZYSHELL.Properties.Resources.back;
            this.e_moveBack.Location = new System.Drawing.Point(176, 279);
            this.e_moveBack.Name = "e_moveBack";
            this.e_moveBack.Padding = new System.Windows.Forms.Padding(0, 0, 1, 1);
            this.e_moveBack.Size = new System.Drawing.Size(22, 17);
            this.e_moveBack.TabIndex = 32;
            this.toolTip1.SetToolTip(this.e_moveBack, "Frame backward");
            this.e_moveBack.UseCompatibleTextRendering = true;
            this.e_moveBack.UseVisualStyleBackColor = false;
            this.e_moveBack.Click += new System.EventHandler(this.e_moveBack_Click);
            // 
            // panel107
            // 
            this.panel107.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.panel107.Controls.Add(this.e_frames);
            this.panel107.Controls.Add(this.label112);
            this.panel107.Controls.Add(this.e_frameMold);
            this.panel107.Controls.Add(this.e_duration);
            this.panel107.Controls.Add(this.label113);
            this.panel107.Controls.Add(this.label114);
            this.panel107.Controls.Add(this.e_moveFrameDown);
            this.panel107.Controls.Add(this.e_insertFrame);
            this.panel107.Controls.Add(this.e_deleteFrame);
            this.panel107.Controls.Add(this.e_moveFrameUp);
            this.panel107.Location = new System.Drawing.Point(2, 21);
            this.panel107.Name = "panel107";
            this.panel107.Size = new System.Drawing.Size(126, 275);
            this.panel107.TabIndex = 22;
            // 
            // e_frames
            // 
            this.e_frames.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.e_frames.FormattingEnabled = true;
            this.e_frames.IntegralHeight = false;
            this.e_frames.Location = new System.Drawing.Point(0, 19);
            this.e_frames.Name = "e_frames";
            this.e_frames.Size = new System.Drawing.Size(126, 202);
            this.e_frames.TabIndex = 1;
            this.e_frames.SelectedIndexChanged += new System.EventHandler(this.e_frames_SelectedIndexChanged);
            // 
            // label112
            // 
            this.label112.BackColor = System.Drawing.SystemColors.Control;
            this.label112.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label112.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label112.Location = new System.Drawing.Point(0, 0);
            this.label112.Name = "label112";
            this.label112.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.label112.Size = new System.Drawing.Size(130, 17);
            this.label112.TabIndex = 407;
            this.label112.Text = "SEQUENCE FRAMES";
            // 
            // e_frameMold
            // 
            this.e_frameMold.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.e_frameMold.Location = new System.Drawing.Point(63, 240);
            this.e_frameMold.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.e_frameMold.Name = "e_frameMold";
            this.e_frameMold.Size = new System.Drawing.Size(43, 17);
            this.e_frameMold.TabIndex = 24;
            this.e_frameMold.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.e_frameMold.ValueChanged += new System.EventHandler(this.e_frameMold_ValueChanged);
            // 
            // e_duration
            // 
            this.e_duration.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.e_duration.Location = new System.Drawing.Point(63, 258);
            this.e_duration.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.e_duration.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.e_duration.Name = "e_duration";
            this.e_duration.Size = new System.Drawing.Size(43, 17);
            this.e_duration.TabIndex = 25;
            this.e_duration.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.e_duration.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.e_duration.ValueChanged += new System.EventHandler(this.e_duration_ValueChanged);
            // 
            // label113
            // 
            this.label113.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label113.Location = new System.Drawing.Point(0, 258);
            this.label113.Name = "label113";
            this.label113.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label113.Size = new System.Drawing.Size(62, 17);
            this.label113.TabIndex = 439;
            this.label113.Text = "Duration";
            // 
            // label114
            // 
            this.label114.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label114.Location = new System.Drawing.Point(0, 240);
            this.label114.Name = "label114";
            this.label114.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label114.Size = new System.Drawing.Size(62, 17);
            this.label114.TabIndex = 440;
            this.label114.Text = "Mold";
            // 
            // e_moveFrameDown
            // 
            this.e_moveFrameDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.e_moveFrameDown.FlatAppearance.BorderSize = 0;
            this.e_moveFrameDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.e_moveFrameDown.Image = global::LAZYSHELL.Properties.Resources.movedown;
            this.e_moveFrameDown.Location = new System.Drawing.Point(107, 258);
            this.e_moveFrameDown.Name = "e_moveFrameDown";
            this.e_moveFrameDown.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.e_moveFrameDown.Size = new System.Drawing.Size(19, 17);
            this.e_moveFrameDown.TabIndex = 27;
            this.e_moveFrameDown.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.e_moveFrameDown, "Move frame down");
            this.e_moveFrameDown.UseCompatibleTextRendering = true;
            this.e_moveFrameDown.UseVisualStyleBackColor = false;
            this.e_moveFrameDown.Click += new System.EventHandler(this.e_moveFrameDown_Click);
            // 
            // e_insertFrame
            // 
            this.e_insertFrame.BackColor = System.Drawing.SystemColors.Window;
            this.e_insertFrame.FlatAppearance.BorderSize = 0;
            this.e_insertFrame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.e_insertFrame.Location = new System.Drawing.Point(0, 222);
            this.e_insertFrame.Name = "e_insertFrame";
            this.e_insertFrame.Size = new System.Drawing.Size(62, 17);
            this.e_insertFrame.TabIndex = 2;
            this.e_insertFrame.Text = "INSERT";
            this.toolTip1.SetToolTip(this.e_insertFrame, "Insert new frame");
            this.e_insertFrame.UseCompatibleTextRendering = true;
            this.e_insertFrame.UseVisualStyleBackColor = false;
            this.e_insertFrame.Click += new System.EventHandler(this.e_insertFrame_Click);
            // 
            // e_deleteFrame
            // 
            this.e_deleteFrame.BackColor = System.Drawing.SystemColors.Window;
            this.e_deleteFrame.FlatAppearance.BorderSize = 0;
            this.e_deleteFrame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.e_deleteFrame.Location = new System.Drawing.Point(63, 222);
            this.e_deleteFrame.Name = "e_deleteFrame";
            this.e_deleteFrame.Size = new System.Drawing.Size(63, 17);
            this.e_deleteFrame.TabIndex = 3;
            this.e_deleteFrame.Text = "DELETE";
            this.toolTip1.SetToolTip(this.e_deleteFrame, "Delete selected frame");
            this.e_deleteFrame.UseCompatibleTextRendering = true;
            this.e_deleteFrame.UseVisualStyleBackColor = false;
            this.e_deleteFrame.Click += new System.EventHandler(this.e_deleteFrame_Click);
            // 
            // e_moveFrameUp
            // 
            this.e_moveFrameUp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.e_moveFrameUp.FlatAppearance.BorderSize = 0;
            this.e_moveFrameUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.e_moveFrameUp.Image = global::LAZYSHELL.Properties.Resources.moveup;
            this.e_moveFrameUp.Location = new System.Drawing.Point(107, 240);
            this.e_moveFrameUp.Name = "e_moveFrameUp";
            this.e_moveFrameUp.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.e_moveFrameUp.Size = new System.Drawing.Size(19, 17);
            this.e_moveFrameUp.TabIndex = 26;
            this.e_moveFrameUp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.e_moveFrameUp, "Move frame up");
            this.e_moveFrameUp.UseCompatibleTextRendering = true;
            this.e_moveFrameUp.UseVisualStyleBackColor = false;
            this.e_moveFrameUp.Click += new System.EventHandler(this.e_moveFrameUp_Click);
            // 
            // e_moveFoward
            // 
            this.e_moveFoward.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.e_moveFoward.FlatAppearance.BorderSize = 0;
            this.e_moveFoward.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.e_moveFoward.Image = global::LAZYSHELL.Properties.Resources.foward;
            this.e_moveFoward.Location = new System.Drawing.Point(199, 279);
            this.e_moveFoward.Name = "e_moveFoward";
            this.e_moveFoward.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.e_moveFoward.Size = new System.Drawing.Size(22, 17);
            this.e_moveFoward.TabIndex = 33;
            this.toolTip1.SetToolTip(this.e_moveFoward, "Frame forward");
            this.e_moveFoward.UseCompatibleTextRendering = true;
            this.e_moveFoward.UseVisualStyleBackColor = false;
            this.e_moveFoward.Click += new System.EventHandler(this.e_moveFoward_Click);
            // 
            // pictureBoxE_Sequence
            // 
            this.pictureBoxE_Sequence.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pictureBoxE_Sequence.BackgroundImage = global::LAZYSHELL.Properties.Resources._transparent;
            this.pictureBoxE_Sequence.ContextMenuStrip = this.contextMenuStripSI;
            this.pictureBoxE_Sequence.Location = new System.Drawing.Point(130, 40);
            this.pictureBoxE_Sequence.Name = "pictureBoxE_Sequence";
            this.pictureBoxE_Sequence.Size = new System.Drawing.Size(256, 256);
            this.pictureBoxE_Sequence.TabIndex = 396;
            this.pictureBoxE_Sequence.TabStop = false;
            this.pictureBoxE_Sequence.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxE_Sequence_Paint);
            // 
            // panel105
            // 
            this.panel105.Controls.Add(this.panel102);
            this.panel105.Controls.Add(this.label97);
            this.panel105.Controls.Add(this.pictureBoxEffectTileset);
            this.panel105.Controls.Add(this.label86);
            this.panel105.Controls.Add(this.e_tileSetSize);
            this.panel105.Location = new System.Drawing.Point(272, 6);
            this.panel105.Name = "panel105";
            this.panel105.Size = new System.Drawing.Size(132, 298);
            this.panel105.TabIndex = 517;
            // 
            // panel102
            // 
            this.panel102.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.panel102.Controls.Add(this.label100);
            this.panel102.Controls.Add(this.pictureBoxE_Subtile);
            this.panel102.Controls.Add(this.pictureBoxE_Tile);
            this.panel102.Controls.Add(this.panel104);
            this.panel102.Controls.Add(this.panel96);
            this.panel102.Controls.Add(this.e_tileSubtile);
            this.panel102.Controls.Add(this.label99);
            this.panel102.Location = new System.Drawing.Point(2, 169);
            this.panel102.Name = "panel102";
            this.panel102.Size = new System.Drawing.Size(128, 127);
            this.panel102.TabIndex = 409;
            // 
            // label100
            // 
            this.label100.BackColor = System.Drawing.SystemColors.Control;
            this.label100.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label100.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label100.Location = new System.Drawing.Point(0, 0);
            this.label100.Name = "label100";
            this.label100.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.label100.Size = new System.Drawing.Size(134, 17);
            this.label100.TabIndex = 407;
            this.label100.Text = "SELECTED TILE";
            // 
            // pictureBoxE_Subtile
            // 
            this.pictureBoxE_Subtile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.pictureBoxE_Subtile.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBoxE_Subtile.BackgroundImage")));
            this.pictureBoxE_Subtile.Location = new System.Drawing.Point(33, 19);
            this.pictureBoxE_Subtile.Name = "pictureBoxE_Subtile";
            this.pictureBoxE_Subtile.Size = new System.Drawing.Size(32, 32);
            this.pictureBoxE_Subtile.TabIndex = 450;
            this.pictureBoxE_Subtile.TabStop = false;
            this.pictureBoxE_Subtile.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxE_Subtile_Paint);
            // 
            // pictureBoxE_Tile
            // 
            this.pictureBoxE_Tile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.pictureBoxE_Tile.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBoxE_Tile.BackgroundImage")));
            this.pictureBoxE_Tile.Location = new System.Drawing.Point(0, 19);
            this.pictureBoxE_Tile.Name = "pictureBoxE_Tile";
            this.pictureBoxE_Tile.Size = new System.Drawing.Size(32, 32);
            this.pictureBoxE_Tile.TabIndex = 449;
            this.pictureBoxE_Tile.TabStop = false;
            this.pictureBoxE_Tile.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxE_Tile_MouseDown);
            this.pictureBoxE_Tile.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxE_Tile_Paint);
            // 
            // panel104
            // 
            this.panel104.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel104.Location = new System.Drawing.Point(0, 72);
            this.panel104.Name = "panel104";
            this.panel104.Size = new System.Drawing.Size(128, 55);
            this.panel104.TabIndex = 514;
            // 
            // panel96
            // 
            this.panel96.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel96.Location = new System.Drawing.Point(66, 19);
            this.panel96.Name = "panel96";
            this.panel96.Size = new System.Drawing.Size(62, 32);
            this.panel96.TabIndex = 514;
            // 
            // e_tileSubtile
            // 
            this.e_tileSubtile.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.e_tileSubtile.Location = new System.Drawing.Point(66, 53);
            this.e_tileSubtile.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.e_tileSubtile.Name = "e_tileSubtile";
            this.e_tileSubtile.Size = new System.Drawing.Size(62, 17);
            this.e_tileSubtile.TabIndex = 52;
            this.e_tileSubtile.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.e_tileSubtile.ValueChanged += new System.EventHandler(this.e_tileSubtile_ValueChanged);
            // 
            // label99
            // 
            this.label99.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label99.Location = new System.Drawing.Point(0, 53);
            this.label99.Name = "label99";
            this.label99.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label99.Size = new System.Drawing.Size(65, 17);
            this.label99.TabIndex = 404;
            this.label99.Text = "Subtile";
            // 
            // label97
            // 
            this.label97.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label97.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label97.ForeColor = System.Drawing.SystemColors.Control;
            this.label97.Location = new System.Drawing.Point(2, 2);
            this.label97.Name = "label97";
            this.label97.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.label97.Size = new System.Drawing.Size(128, 17);
            this.label97.TabIndex = 408;
            this.label97.Text = "IMAGE TILESET...";
            // 
            // pictureBoxEffectTileset
            // 
            this.pictureBoxEffectTileset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.pictureBoxEffectTileset.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBoxEffectTileset.BackgroundImage")));
            this.pictureBoxEffectTileset.ContextMenuStrip = this.contextMenuStrip1;
            this.pictureBoxEffectTileset.Location = new System.Drawing.Point(2, 39);
            this.pictureBoxEffectTileset.Name = "pictureBoxEffectTileset";
            this.pictureBoxEffectTileset.Size = new System.Drawing.Size(128, 128);
            this.pictureBoxEffectTileset.TabIndex = 397;
            this.pictureBoxEffectTileset.TabStop = false;
            this.pictureBoxEffectTileset.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxEffectTileset_MouseMove);
            this.pictureBoxEffectTileset.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pictureBoxEffectTileset_MouseDoubleClick);
            this.pictureBoxEffectTileset.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxEffectTileset_MouseDown);
            this.pictureBoxEffectTileset.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxEffectTileset_Paint);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setMoldTileToolStripMenuItem,
            this.toolStripSeparator29,
            this.importImageAsTilesetToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.contextMenuStrip1.ShowImageMargin = false;
            this.contextMenuStrip1.Size = new System.Drawing.Size(178, 54);
            // 
            // setMoldTileToolStripMenuItem
            // 
            this.setMoldTileToolStripMenuItem.Name = "setMoldTileToolStripMenuItem";
            this.setMoldTileToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.setMoldTileToolStripMenuItem.Text = "Set mold tile";
            this.setMoldTileToolStripMenuItem.Click += new System.EventHandler(this.setMoldTileToolStripMenuItem_Click);
            // 
            // toolStripSeparator29
            // 
            this.toolStripSeparator29.Name = "toolStripSeparator29";
            this.toolStripSeparator29.Size = new System.Drawing.Size(174, 6);
            // 
            // importImageAsTilesetToolStripMenuItem
            // 
            this.importImageAsTilesetToolStripMenuItem.Name = "importImageAsTilesetToolStripMenuItem";
            this.importImageAsTilesetToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.importImageAsTilesetToolStripMenuItem.Text = "Import image into tileset...";
            this.importImageAsTilesetToolStripMenuItem.Click += new System.EventHandler(this.importImageAsTilesetToolStripMenuItem_Click);
            // 
            // label86
            // 
            this.label86.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label86.Location = new System.Drawing.Point(2, 21);
            this.label86.Name = "label86";
            this.label86.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label86.Size = new System.Drawing.Size(64, 17);
            this.label86.TabIndex = 394;
            this.label86.Text = "Size";
            // 
            // e_tileSetSize
            // 
            this.e_tileSetSize.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.e_tileSetSize.Increment = new decimal(new int[] {
            64,
            0,
            0,
            0});
            this.e_tileSetSize.Location = new System.Drawing.Point(67, 21);
            this.e_tileSetSize.Maximum = new decimal(new int[] {
            512,
            0,
            0,
            0});
            this.e_tileSetSize.Minimum = new decimal(new int[] {
            64,
            0,
            0,
            0});
            this.e_tileSetSize.Name = "e_tileSetSize";
            this.e_tileSetSize.Size = new System.Drawing.Size(64, 17);
            this.e_tileSetSize.TabIndex = 16;
            this.e_tileSetSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.e_tileSetSize.Value = new decimal(new int[] {
            64,
            0,
            0,
            0});
            this.e_tileSetSize.ValueChanged += new System.EventHandler(this.e_tileSetSize_ValueChanged);
            // 
            // panel99
            // 
            this.panel99.Controls.Add(this.label103);
            this.panel99.Controls.Add(this.label104);
            this.panel99.Controls.Add(this.panel100);
            this.panel99.Controls.Add(this.panel101);
            this.panel99.Location = new System.Drawing.Point(538, 329);
            this.panel99.Name = "panel99";
            this.panel99.Size = new System.Drawing.Size(260, 319);
            this.panel99.TabIndex = 516;
            // 
            // label103
            // 
            this.label103.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label103.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label103.Location = new System.Drawing.Point(131, 21);
            this.label103.Name = "label103";
            this.label103.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label103.Size = new System.Drawing.Size(127, 17);
            this.label103.TabIndex = 526;
            // 
            // label104
            // 
            this.label104.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label104.BackColor = System.Drawing.SystemColors.Control;
            this.label104.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label104.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label104.Location = new System.Drawing.Point(2, 2);
            this.label104.Name = "label104";
            this.label104.Padding = new System.Windows.Forms.Padding(2, 2, 0, 0);
            this.label104.Size = new System.Drawing.Size(256, 17);
            this.label104.TabIndex = 375;
            this.label104.Text = "MOLD IMAGE";
            this.toolTip1.SetToolTip(this.label104, "Click to drag or double-click to maximize / restore");
            // 
            // panel100
            // 
            this.panel100.BackColor = System.Drawing.SystemColors.Control;
            this.panel100.Controls.Add(this.toolStrip6);
            this.panel100.Location = new System.Drawing.Point(2, 21);
            this.panel100.Name = "panel100";
            this.panel100.Size = new System.Drawing.Size(128, 17);
            this.panel100.TabIndex = 51;
            // 
            // toolStrip6
            // 
            this.toolStrip6.AutoSize = false;
            this.toolStrip6.CanOverflow = false;
            this.toolStrip6.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip6.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip6.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel4,
            this.toolStripSeparator20,
            this.e_moldShowGrid,
            this.toolStripSeparator21,
            this.e_moldZoomIn,
            this.e_moldZoomOut});
            this.toolStrip6.Location = new System.Drawing.Point(0, -1);
            this.toolStrip6.Name = "toolStrip6";
            this.toolStrip6.Padding = new System.Windows.Forms.Padding(0);
            this.toolStrip6.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip6.Size = new System.Drawing.Size(133, 20);
            this.toolStrip6.TabIndex = 51;
            this.toolStrip6.TabStop = true;
            this.toolStrip6.Text = "toolStrip1";
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.toolStripLabel4.Margin = new System.Windows.Forms.Padding(4, 1, 0, 2);
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(36, 17);
            this.toolStripLabel4.Text = "VIEW";
            // 
            // toolStripSeparator20
            // 
            this.toolStripSeparator20.Margin = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStripSeparator20.Name = "toolStripSeparator20";
            this.toolStripSeparator20.Size = new System.Drawing.Size(6, 20);
            // 
            // e_moldShowGrid
            // 
            this.e_moldShowGrid.CheckOnClick = true;
            this.e_moldShowGrid.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.e_moldShowGrid.Image = global::LAZYSHELL.Properties.Resources.buttonToggleGrid;
            this.e_moldShowGrid.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.e_moldShowGrid.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.e_moldShowGrid.Name = "e_moldShowGrid";
            this.e_moldShowGrid.Size = new System.Drawing.Size(23, 17);
            this.e_moldShowGrid.Text = "Pixel Grid";
            this.e_moldShowGrid.Click += new System.EventHandler(this.e_moldShowGrid_Click);
            // 
            // toolStripSeparator21
            // 
            this.toolStripSeparator21.Margin = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStripSeparator21.Name = "toolStripSeparator21";
            this.toolStripSeparator21.Size = new System.Drawing.Size(6, 20);
            // 
            // e_moldZoomIn
            // 
            this.e_moldZoomIn.CheckOnClick = true;
            this.e_moldZoomIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.e_moldZoomIn.Image = global::LAZYSHELL.Properties.Resources.zoomin_small;
            this.e_moldZoomIn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.e_moldZoomIn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.e_moldZoomIn.Name = "e_moldZoomIn";
            this.e_moldZoomIn.Size = new System.Drawing.Size(23, 17);
            this.e_moldZoomIn.Text = "Zoom In";
            this.e_moldZoomIn.Click += new System.EventHandler(this.e_moldZoomIn_Click);
            // 
            // e_moldZoomOut
            // 
            this.e_moldZoomOut.CheckOnClick = true;
            this.e_moldZoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.e_moldZoomOut.Image = global::LAZYSHELL.Properties.Resources.zoomout_small;
            this.e_moldZoomOut.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.e_moldZoomOut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.e_moldZoomOut.Name = "e_moldZoomOut";
            this.e_moldZoomOut.Size = new System.Drawing.Size(23, 17);
            this.e_moldZoomOut.Text = "Zoom Out";
            this.e_moldZoomOut.Click += new System.EventHandler(this.e_moldZoomOut_Click);
            // 
            // panel101
            // 
            this.panel101.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel101.AutoScroll = true;
            this.panel101.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel101.Controls.Add(this.pictureBoxE_Mold);
            this.panel101.Location = new System.Drawing.Point(2, 39);
            this.panel101.Name = "panel101";
            this.panel101.Size = new System.Drawing.Size(256, 278);
            this.panel101.TabIndex = 515;
            this.panel101.Scroll += new System.Windows.Forms.ScrollEventHandler(this.panel101_Scroll);
            // 
            // pictureBoxE_Mold
            // 
            this.pictureBoxE_Mold.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pictureBoxE_Mold.BackgroundImage = global::LAZYSHELL.Properties.Resources._transparent;
            this.pictureBoxE_Mold.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxE_Mold.Name = "pictureBoxE_Mold";
            this.pictureBoxE_Mold.Size = new System.Drawing.Size(256, 256);
            this.pictureBoxE_Mold.TabIndex = 399;
            this.pictureBoxE_Mold.TabStop = false;
            this.pictureBoxE_Mold.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxE_Mold_MouseDown);
            this.pictureBoxE_Mold.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxE_Mold_Paint);
            // 
            // panel90
            // 
            this.panel90.Controls.Add(this.panel91);
            this.panel90.Controls.Add(this.label93);
            this.panel90.Controls.Add(this.panel94);
            this.panel90.Controls.Add(this.label105);
            this.panel90.Controls.Add(this.e_moldHeight);
            this.panel90.Controls.Add(this.label95);
            this.panel90.Controls.Add(this.e_moldWidth);
            this.panel90.Location = new System.Drawing.Point(272, 310);
            this.panel90.Name = "panel90";
            this.panel90.Size = new System.Drawing.Size(526, 338);
            this.panel90.TabIndex = 402;
            // 
            // panel91
            // 
            this.panel91.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.panel91.Controls.Add(this.label91);
            this.panel91.Controls.Add(this.e_molds);
            this.panel91.Controls.Add(this.e_deleteMold);
            this.panel91.Controls.Add(this.e_insertMold);
            this.panel91.Location = new System.Drawing.Point(2, 40);
            this.panel91.Name = "panel91";
            this.panel91.Size = new System.Drawing.Size(128, 296);
            this.panel91.TabIndex = 34;
            // 
            // label91
            // 
            this.label91.BackColor = System.Drawing.SystemColors.Control;
            this.label91.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label91.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label91.Location = new System.Drawing.Point(0, 0);
            this.label91.Name = "label91";
            this.label91.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.label91.Size = new System.Drawing.Size(128, 17);
            this.label91.TabIndex = 407;
            this.label91.Text = "MOLDS";
            // 
            // e_molds
            // 
            this.e_molds.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.e_molds.ContextMenuStrip = this.contextMenuStrip;
            this.e_molds.FormattingEnabled = true;
            this.e_molds.IntegralHeight = false;
            this.e_molds.Location = new System.Drawing.Point(0, 19);
            this.e_molds.Name = "e_molds";
            this.e_molds.Size = new System.Drawing.Size(128, 259);
            this.e_molds.TabIndex = 398;
            this.e_molds.SelectedIndexChanged += new System.EventHandler(this.e_molds_SelectedIndexChanged);
            // 
            // e_deleteMold
            // 
            this.e_deleteMold.BackColor = System.Drawing.SystemColors.Window;
            this.e_deleteMold.FlatAppearance.BorderSize = 0;
            this.e_deleteMold.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.e_deleteMold.Location = new System.Drawing.Point(64, 279);
            this.e_deleteMold.Name = "e_deleteMold";
            this.e_deleteMold.Size = new System.Drawing.Size(64, 17);
            this.e_deleteMold.TabIndex = 37;
            this.e_deleteMold.Text = "DELETE";
            this.toolTip1.SetToolTip(this.e_deleteMold, "Delete selected mold");
            this.e_deleteMold.UseCompatibleTextRendering = true;
            this.e_deleteMold.UseVisualStyleBackColor = false;
            this.e_deleteMold.Click += new System.EventHandler(this.e_deleteMold_Click);
            // 
            // e_insertMold
            // 
            this.e_insertMold.BackColor = System.Drawing.SystemColors.Window;
            this.e_insertMold.FlatAppearance.BorderSize = 0;
            this.e_insertMold.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.e_insertMold.Location = new System.Drawing.Point(0, 279);
            this.e_insertMold.Name = "e_insertMold";
            this.e_insertMold.Size = new System.Drawing.Size(63, 17);
            this.e_insertMold.TabIndex = 36;
            this.e_insertMold.Text = "INSERT";
            this.toolTip1.SetToolTip(this.e_insertMold, "Insert new mold");
            this.e_insertMold.UseCompatibleTextRendering = true;
            this.e_insertMold.UseVisualStyleBackColor = false;
            this.e_insertMold.Click += new System.EventHandler(this.e_insertMold_Click);
            // 
            // label93
            // 
            this.label93.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label93.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label93.ForeColor = System.Drawing.SystemColors.Control;
            this.label93.Location = new System.Drawing.Point(2, 2);
            this.label93.Name = "label93";
            this.label93.Padding = new System.Windows.Forms.Padding(2, 2, 0, 0);
            this.label93.Size = new System.Drawing.Size(522, 17);
            this.label93.TabIndex = 375;
            this.label93.Text = "ANIMATION MOLDS...";
            // 
            // panel94
            // 
            this.panel94.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.panel94.Controls.Add(this.e_moveTileDown);
            this.panel94.Controls.Add(this.e_moveTileUp);
            this.panel94.Controls.Add(this.e_tiles);
            this.panel94.Controls.Add(this.panel95);
            this.panel94.Controls.Add(this.label102);
            this.panel94.Controls.Add(this.moldDeleteTile);
            this.panel94.Controls.Add(this.moldInsertTile);
            this.panel94.Location = new System.Drawing.Point(132, 40);
            this.panel94.Name = "panel94";
            this.panel94.Size = new System.Drawing.Size(134, 296);
            this.panel94.TabIndex = 35;
            // 
            // e_moveTileDown
            // 
            this.e_moveTileDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.e_moveTileDown.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.e_moveTileDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.e_moveTileDown.Image = global::LAZYSHELL.Properties.Resources.movedown;
            this.e_moveTileDown.Location = new System.Drawing.Point(116, -1);
            this.e_moveTileDown.Name = "e_moveTileDown";
            this.e_moveTileDown.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.e_moveTileDown.Size = new System.Drawing.Size(19, 19);
            this.e_moveTileDown.TabIndex = 409;
            this.e_moveTileDown.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.e_moveTileDown, "Move tile down");
            this.e_moveTileDown.UseCompatibleTextRendering = true;
            this.e_moveTileDown.UseVisualStyleBackColor = false;
            this.e_moveTileDown.Click += new System.EventHandler(this.e_moveTileDown_Click);
            // 
            // e_moveTileUp
            // 
            this.e_moveTileUp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.e_moveTileUp.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.e_moveTileUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.e_moveTileUp.Image = global::LAZYSHELL.Properties.Resources.moveup;
            this.e_moveTileUp.Location = new System.Drawing.Point(98, -1);
            this.e_moveTileUp.Name = "e_moveTileUp";
            this.e_moveTileUp.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.e_moveTileUp.Size = new System.Drawing.Size(19, 19);
            this.e_moveTileUp.TabIndex = 408;
            this.e_moveTileUp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.e_moveTileUp, "Move tile up");
            this.e_moveTileUp.UseCompatibleTextRendering = true;
            this.e_moveTileUp.UseVisualStyleBackColor = false;
            this.e_moveTileUp.Click += new System.EventHandler(this.e_moveTileUp_Click);
            // 
            // e_tiles
            // 
            this.e_tiles.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.e_tiles.ContextMenuStrip = this.contextMenuStripMD;
            this.e_tiles.FormattingEnabled = true;
            this.e_tiles.IntegralHeight = false;
            this.e_tiles.Location = new System.Drawing.Point(0, 19);
            this.e_tiles.Name = "e_tiles";
            this.e_tiles.Size = new System.Drawing.Size(134, 149);
            this.e_tiles.TabIndex = 398;
            this.e_tiles.SelectedIndexChanged += new System.EventHandler(this.e_tiles_SelectedIndexChanged);
            // 
            // contextMenuStripMD
            // 
            this.contextMenuStripMD.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.insertTilesToolStripMenuItem,
            this.clearAllTilesToolStripMenuItem});
            this.contextMenuStripMD.Name = "contextMenuStripMD";
            this.contextMenuStripMD.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.contextMenuStripMD.ShowImageMargin = false;
            this.contextMenuStripMD.Size = new System.Drawing.Size(113, 48);
            // 
            // insertTilesToolStripMenuItem
            // 
            this.insertTilesToolStripMenuItem.Name = "insertTilesToolStripMenuItem";
            this.insertTilesToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.insertTilesToolStripMenuItem.Text = "Insert tiles...";
            this.insertTilesToolStripMenuItem.Click += new System.EventHandler(this.insertTilesToolStripMenuItem_Click);
            // 
            // clearAllTilesToolStripMenuItem
            // 
            this.clearAllTilesToolStripMenuItem.Name = "clearAllTilesToolStripMenuItem";
            this.clearAllTilesToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.clearAllTilesToolStripMenuItem.Text = "Clear all tiles";
            this.clearAllTilesToolStripMenuItem.Click += new System.EventHandler(this.clearAllTilesToolStripMenuItem_Click);
            // 
            // panel95
            // 
            this.panel95.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.panel95.Controls.Add(this.moldTileEmpty);
            this.panel95.Controls.Add(this.moldTileProp);
            this.panel95.Controls.Add(this.label101);
            this.panel95.Controls.Add(this.panel92);
            this.panel95.Controls.Add(this.moldFillAmount);
            this.panel95.Controls.Add(this.moldTileIndex);
            this.panel95.Controls.Add(this.label106);
            this.panel95.Controls.Add(this.label94);
            this.panel95.Controls.Add(this.panel93);
            this.panel95.Controls.Add(this.label92);
            this.panel95.Location = new System.Drawing.Point(0, 188);
            this.panel95.Name = "panel95";
            this.panel95.Size = new System.Drawing.Size(134, 108);
            this.panel95.TabIndex = 41;
            // 
            // moldTileEmpty
            // 
            this.moldTileEmpty.Appearance = System.Windows.Forms.Appearance.Button;
            this.moldTileEmpty.BackColor = System.Drawing.SystemColors.Control;
            this.moldTileEmpty.FlatAppearance.BorderSize = 0;
            this.moldTileEmpty.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(168)))), ((int)(((byte)(168)))));
            this.moldTileEmpty.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.moldTileEmpty.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.moldTileEmpty.Location = new System.Drawing.Point(0, 74);
            this.moldTileEmpty.Name = "moldTileEmpty";
            this.moldTileEmpty.Size = new System.Drawing.Size(134, 17);
            this.moldTileEmpty.TabIndex = 408;
            this.moldTileEmpty.Text = "EMPTY TILE";
            this.moldTileEmpty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.moldTileEmpty.UseCompatibleTextRendering = true;
            this.moldTileEmpty.UseVisualStyleBackColor = false;
            this.moldTileEmpty.CheckedChanged += new System.EventHandler(this.moldTileEmpty_CheckedChanged);
            // 
            // moldTileProp
            // 
            this.moldTileProp.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.moldTileProp.CheckOnClick = true;
            this.moldTileProp.ColumnWidth = 63;
            this.moldTileProp.FormattingEnabled = true;
            this.moldTileProp.Items.AddRange(new object[] {
            "Mirror",
            "Invert"});
            this.moldTileProp.Location = new System.Drawing.Point(0, 92);
            this.moldTileProp.MultiColumn = true;
            this.moldTileProp.Name = "moldTileProp";
            this.moldTileProp.Size = new System.Drawing.Size(134, 16);
            this.moldTileProp.TabIndex = 46;
            this.moldTileProp.SelectedIndexChanged += new System.EventHandler(this.moldTileProp_SelectedIndexChanged);
            // 
            // label101
            // 
            this.label101.BackColor = System.Drawing.SystemColors.Control;
            this.label101.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label101.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label101.Location = new System.Drawing.Point(0, 0);
            this.label101.Name = "label101";
            this.label101.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.label101.Size = new System.Drawing.Size(134, 17);
            this.label101.TabIndex = 407;
            this.label101.Text = "TILE PROPERTIES...";
            // 
            // panel92
            // 
            this.panel92.Controls.Add(this.moldTileFormat);
            this.panel92.Location = new System.Drawing.Point(67, 19);
            this.panel92.Name = "panel92";
            this.panel92.Size = new System.Drawing.Size(68, 17);
            this.panel92.TabIndex = 405;
            // 
            // moldTileFormat
            // 
            this.moldTileFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.moldTileFormat.FormattingEnabled = true;
            this.moldTileFormat.Items.AddRange(new object[] {
            "normal",
            "filler"});
            this.moldTileFormat.Location = new System.Drawing.Point(-2, -2);
            this.moldTileFormat.Name = "moldTileFormat";
            this.moldTileFormat.Size = new System.Drawing.Size(72, 21);
            this.moldTileFormat.TabIndex = 38;
            this.moldTileFormat.SelectedIndexChanged += new System.EventHandler(this.moldTileFormat_SelectedIndexChanged);
            // 
            // moldFillAmount
            // 
            this.moldFillAmount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.moldFillAmount.Location = new System.Drawing.Point(67, 55);
            this.moldFillAmount.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.moldFillAmount.Name = "moldFillAmount";
            this.moldFillAmount.Size = new System.Drawing.Size(68, 17);
            this.moldFillAmount.TabIndex = 52;
            this.moldFillAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.moldFillAmount.ValueChanged += new System.EventHandler(this.moldFillAmount_ValueChanged);
            // 
            // moldTileIndex
            // 
            this.moldTileIndex.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.moldTileIndex.Location = new System.Drawing.Point(67, 37);
            this.moldTileIndex.Maximum = new decimal(new int[] {
            63,
            0,
            0,
            0});
            this.moldTileIndex.Name = "moldTileIndex";
            this.moldTileIndex.Size = new System.Drawing.Size(68, 17);
            this.moldTileIndex.TabIndex = 52;
            this.moldTileIndex.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.moldTileIndex.ValueChanged += new System.EventHandler(this.moldTileIndex_ValueChanged);
            // 
            // label106
            // 
            this.label106.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label106.Location = new System.Drawing.Point(0, 55);
            this.label106.Name = "label106";
            this.label106.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label106.Size = new System.Drawing.Size(66, 17);
            this.label106.TabIndex = 394;
            this.label106.Text = "Fill amount";
            // 
            // label94
            // 
            this.label94.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label94.Location = new System.Drawing.Point(0, 37);
            this.label94.Name = "label94";
            this.label94.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label94.Size = new System.Drawing.Size(66, 17);
            this.label94.TabIndex = 394;
            this.label94.Text = "Tile #";
            // 
            // panel93
            // 
            this.panel93.Controls.Add(this.comboBox4);
            this.panel93.Location = new System.Drawing.Point(67, 19);
            this.panel93.Name = "panel93";
            this.panel93.Size = new System.Drawing.Size(68, 17);
            this.panel93.TabIndex = 405;
            // 
            // comboBox4
            // 
            this.comboBox4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Items.AddRange(new object[] {
            "Gridplane",
            "16x16 mapped"});
            this.comboBox4.Location = new System.Drawing.Point(-2, -2);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(53, 21);
            this.comboBox4.TabIndex = 400;
            // 
            // label92
            // 
            this.label92.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label92.Location = new System.Drawing.Point(0, 19);
            this.label92.Name = "label92";
            this.label92.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label92.Size = new System.Drawing.Size(66, 17);
            this.label92.TabIndex = 404;
            this.label92.Text = "Format";
            // 
            // label102
            // 
            this.label102.BackColor = System.Drawing.SystemColors.Control;
            this.label102.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label102.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label102.Location = new System.Drawing.Point(0, 0);
            this.label102.Name = "label102";
            this.label102.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.label102.Size = new System.Drawing.Size(98, 17);
            this.label102.TabIndex = 407;
            this.label102.Text = "MOLD TILES";
            // 
            // moldDeleteTile
            // 
            this.moldDeleteTile.BackColor = System.Drawing.SystemColors.Window;
            this.moldDeleteTile.FlatAppearance.BorderSize = 0;
            this.moldDeleteTile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.moldDeleteTile.Location = new System.Drawing.Point(67, 169);
            this.moldDeleteTile.Name = "moldDeleteTile";
            this.moldDeleteTile.Size = new System.Drawing.Size(67, 17);
            this.moldDeleteTile.TabIndex = 40;
            this.moldDeleteTile.Text = "DELETE";
            this.toolTip1.SetToolTip(this.moldDeleteTile, "Delete selected tile");
            this.moldDeleteTile.UseCompatibleTextRendering = true;
            this.moldDeleteTile.UseVisualStyleBackColor = false;
            this.moldDeleteTile.Click += new System.EventHandler(this.moldDeleteTile_Click);
            // 
            // moldInsertTile
            // 
            this.moldInsertTile.BackColor = System.Drawing.SystemColors.Window;
            this.moldInsertTile.FlatAppearance.BorderSize = 0;
            this.moldInsertTile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.moldInsertTile.Location = new System.Drawing.Point(0, 169);
            this.moldInsertTile.Name = "moldInsertTile";
            this.moldInsertTile.Size = new System.Drawing.Size(66, 17);
            this.moldInsertTile.TabIndex = 39;
            this.moldInsertTile.Text = "INSERT";
            this.toolTip1.SetToolTip(this.moldInsertTile, "Insert new tile");
            this.moldInsertTile.UseCompatibleTextRendering = true;
            this.moldInsertTile.UseVisualStyleBackColor = false;
            this.moldInsertTile.Click += new System.EventHandler(this.moldInsertTile_Click);
            // 
            // label105
            // 
            this.label105.BackColor = System.Drawing.SystemColors.Control;
            this.label105.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label105.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label105.Location = new System.Drawing.Point(132, 21);
            this.label105.Name = "label105";
            this.label105.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label105.Size = new System.Drawing.Size(67, 17);
            this.label105.TabIndex = 396;
            this.label105.Text = "Height";
            // 
            // e_moldHeight
            // 
            this.e_moldHeight.BackColor = System.Drawing.SystemColors.Control;
            this.e_moldHeight.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.e_moldHeight.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.e_moldHeight.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.e_moldHeight.Location = new System.Drawing.Point(200, 21);
            this.e_moldHeight.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.e_moldHeight.Name = "e_moldHeight";
            this.e_moldHeight.Size = new System.Drawing.Size(67, 17);
            this.e_moldHeight.TabIndex = 395;
            this.e_moldHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.e_moldHeight.ValueChanged += new System.EventHandler(this.e_moldHeight_ValueChanged);
            // 
            // label95
            // 
            this.label95.BackColor = System.Drawing.SystemColors.Control;
            this.label95.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label95.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label95.Location = new System.Drawing.Point(2, 21);
            this.label95.Name = "label95";
            this.label95.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label95.Size = new System.Drawing.Size(64, 17);
            this.label95.TabIndex = 396;
            this.label95.Text = "Width";
            // 
            // e_moldWidth
            // 
            this.e_moldWidth.BackColor = System.Drawing.SystemColors.Control;
            this.e_moldWidth.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.e_moldWidth.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.e_moldWidth.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.e_moldWidth.Location = new System.Drawing.Point(67, 21);
            this.e_moldWidth.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.e_moldWidth.Name = "e_moldWidth";
            this.e_moldWidth.Size = new System.Drawing.Size(64, 17);
            this.e_moldWidth.TabIndex = 395;
            this.e_moldWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.e_moldWidth.ValueChanged += new System.EventHandler(this.e_moldWidth_ValueChanged);
            // 
            // panelEffectGraphics
            // 
            this.panelEffectGraphics.Controls.Add(this.panel87);
            this.panelEffectGraphics.Location = new System.Drawing.Point(6, 382);
            this.panelEffectGraphics.Name = "panelEffectGraphics";
            this.panelEffectGraphics.Size = new System.Drawing.Size(260, 266);
            this.panelEffectGraphics.TabIndex = 401;
            this.panelEffectGraphics.MouseLeave += new System.EventHandler(this.panelEffectGraphics_MouseLeave);
            this.panelEffectGraphics.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelEffectGraphics_MouseMove);
            this.panelEffectGraphics.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelEffectGraphics_MouseDown);
            // 
            // panel87
            // 
            this.panel87.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel87.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.panel87.Controls.Add(this.panel97);
            this.panel87.Controls.Add(this.panel98);
            this.panel87.Controls.Add(this.e_coordsLabel);
            this.panel87.Controls.Add(this.panel88);
            this.panel87.Controls.Add(this.labelEffectGraphics);
            this.panel87.Controls.Add(this.e_graphicSetSize);
            this.panel87.Controls.Add(this.label90);
            this.panel87.Controls.Add(this.label89);
            this.panel87.Controls.Add(this.panel89);
            this.panel87.Location = new System.Drawing.Point(2, 2);
            this.panel87.Name = "panel87";
            this.panel87.Size = new System.Drawing.Size(256, 262);
            this.panel87.TabIndex = 513;
            // 
            // panel97
            // 
            this.panel97.Controls.Add(this.e_codec);
            this.panel97.Location = new System.Drawing.Point(194, 19);
            this.panel97.Name = "panel97";
            this.panel97.Size = new System.Drawing.Size(62, 17);
            this.panel97.TabIndex = 526;
            // 
            // e_codec
            // 
            this.e_codec.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.e_codec.FormattingEnabled = true;
            this.e_codec.Items.AddRange(new object[] {
            "4bpp",
            "2bpp"});
            this.e_codec.Location = new System.Drawing.Point(-2, -2);
            this.e_codec.Name = "e_codec";
            this.e_codec.Size = new System.Drawing.Size(66, 21);
            this.e_codec.TabIndex = 41;
            this.e_codec.SelectedIndexChanged += new System.EventHandler(this.e_codec_SelectedIndexChanged);
            // 
            // panel98
            // 
            this.panel98.Controls.Add(this.comboBox6);
            this.panel98.Location = new System.Drawing.Point(194, 19);
            this.panel98.Name = "panel98";
            this.panel98.Size = new System.Drawing.Size(62, 17);
            this.panel98.TabIndex = 527;
            // 
            // comboBox6
            // 
            this.comboBox6.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox6.FormattingEnabled = true;
            this.comboBox6.Items.AddRange(new object[] {
            "Gridplane",
            "16x16 mapped"});
            this.comboBox6.Location = new System.Drawing.Point(-2, -2);
            this.comboBox6.Name = "comboBox6";
            this.comboBox6.Size = new System.Drawing.Size(53, 21);
            this.comboBox6.TabIndex = 400;
            // 
            // e_coordsLabel
            // 
            this.e_coordsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.e_coordsLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.e_coordsLabel.Location = new System.Drawing.Point(0, 37);
            this.e_coordsLabel.Name = "e_coordsLabel";
            this.e_coordsLabel.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.e_coordsLabel.Size = new System.Drawing.Size(256, 17);
            this.e_coordsLabel.TabIndex = 525;
            this.e_coordsLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // panel88
            // 
            this.panel88.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel88.BackColor = System.Drawing.SystemColors.Control;
            this.panel88.Controls.Add(this.toolStrip5);
            this.panel88.Location = new System.Drawing.Point(0, 55);
            this.panel88.Name = "panel88";
            this.panel88.Size = new System.Drawing.Size(256, 18);
            this.panel88.TabIndex = 51;
            // 
            // toolStrip5
            // 
            this.toolStrip5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.toolStrip5.AutoSize = false;
            this.toolStrip5.CanOverflow = false;
            this.toolStrip5.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip5.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip5.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel3,
            this.toolStripSeparator17,
            this.e_graphicShowGrid,
            this.e_graphicShowPixelGrid,
            this.toolStripSeparator18,
            this.e_subtileDraw,
            this.e_subtileErase,
            this.e_subtileDropper,
            this.toolStripSeparator19,
            this.e_graphicZoomIn,
            this.e_graphicZoomOut});
            this.toolStrip5.Location = new System.Drawing.Point(0, -1);
            this.toolStrip5.Name = "toolStrip5";
            this.toolStrip5.Padding = new System.Windows.Forms.Padding(0);
            this.toolStrip5.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip5.Size = new System.Drawing.Size(256, 20);
            this.toolStrip5.TabIndex = 51;
            this.toolStrip5.TabStop = true;
            this.toolStrip5.Text = "toolStrip5";
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.toolStripLabel3.Margin = new System.Windows.Forms.Padding(4, 1, 0, 2);
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(33, 17);
            this.toolStripLabel3.Text = "EDIT";
            // 
            // toolStripSeparator17
            // 
            this.toolStripSeparator17.Margin = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStripSeparator17.Name = "toolStripSeparator17";
            this.toolStripSeparator17.Size = new System.Drawing.Size(6, 20);
            // 
            // e_graphicShowGrid
            // 
            this.e_graphicShowGrid.CheckOnClick = true;
            this.e_graphicShowGrid.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.e_graphicShowGrid.Image = global::LAZYSHELL.Properties.Resources.buttonToggleGrid;
            this.e_graphicShowGrid.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.e_graphicShowGrid.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.e_graphicShowGrid.Name = "e_graphicShowGrid";
            this.e_graphicShowGrid.Size = new System.Drawing.Size(23, 17);
            this.e_graphicShowGrid.Text = "Grid";
            this.e_graphicShowGrid.Click += new System.EventHandler(this.e_graphicShowGrid_Click);
            // 
            // e_graphicShowPixelGrid
            // 
            this.e_graphicShowPixelGrid.CheckOnClick = true;
            this.e_graphicShowPixelGrid.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.e_graphicShowPixelGrid.Image = global::LAZYSHELL.Properties.Resources.buttonTogglePixelGrid;
            this.e_graphicShowPixelGrid.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.e_graphicShowPixelGrid.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.e_graphicShowPixelGrid.Name = "e_graphicShowPixelGrid";
            this.e_graphicShowPixelGrid.Size = new System.Drawing.Size(23, 17);
            this.e_graphicShowPixelGrid.Text = "Pixel Grid";
            this.e_graphicShowPixelGrid.Click += new System.EventHandler(this.e_graphicShowPixelGrid_Click);
            // 
            // toolStripSeparator18
            // 
            this.toolStripSeparator18.Margin = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStripSeparator18.Name = "toolStripSeparator18";
            this.toolStripSeparator18.Size = new System.Drawing.Size(6, 20);
            // 
            // e_subtileDraw
            // 
            this.e_subtileDraw.CheckOnClick = true;
            this.e_subtileDraw.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.e_subtileDraw.Image = global::LAZYSHELL.Properties.Resources.draw_small;
            this.e_subtileDraw.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.e_subtileDraw.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.e_subtileDraw.Name = "e_subtileDraw";
            this.e_subtileDraw.Size = new System.Drawing.Size(23, 17);
            this.e_subtileDraw.Text = "Draw";
            this.e_subtileDraw.Click += new System.EventHandler(this.e_subtileDraw_Click);
            // 
            // e_subtileErase
            // 
            this.e_subtileErase.CheckOnClick = true;
            this.e_subtileErase.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.e_subtileErase.Image = global::LAZYSHELL.Properties.Resources.erase_small;
            this.e_subtileErase.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.e_subtileErase.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.e_subtileErase.Name = "e_subtileErase";
            this.e_subtileErase.Size = new System.Drawing.Size(23, 17);
            this.e_subtileErase.Text = "Erase";
            this.e_subtileErase.Click += new System.EventHandler(this.e_subtileErase_Click);
            // 
            // e_subtileDropper
            // 
            this.e_subtileDropper.CheckOnClick = true;
            this.e_subtileDropper.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.e_subtileDropper.Image = global::LAZYSHELL.Properties.Resources.dropper_small;
            this.e_subtileDropper.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.e_subtileDropper.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.e_subtileDropper.Name = "e_subtileDropper";
            this.e_subtileDropper.Size = new System.Drawing.Size(23, 17);
            this.e_subtileDropper.Text = "Choose Color";
            this.e_subtileDropper.Click += new System.EventHandler(this.e_subtileDropper_Click);
            // 
            // toolStripSeparator19
            // 
            this.toolStripSeparator19.Margin = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStripSeparator19.Name = "toolStripSeparator19";
            this.toolStripSeparator19.Size = new System.Drawing.Size(6, 20);
            // 
            // e_graphicZoomIn
            // 
            this.e_graphicZoomIn.CheckOnClick = true;
            this.e_graphicZoomIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.e_graphicZoomIn.Image = global::LAZYSHELL.Properties.Resources.zoomin_small;
            this.e_graphicZoomIn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.e_graphicZoomIn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.e_graphicZoomIn.Name = "e_graphicZoomIn";
            this.e_graphicZoomIn.Size = new System.Drawing.Size(23, 17);
            this.e_graphicZoomIn.Text = "Zoom In";
            this.e_graphicZoomIn.Click += new System.EventHandler(this.e_graphicZoomIn_Click);
            // 
            // e_graphicZoomOut
            // 
            this.e_graphicZoomOut.CheckOnClick = true;
            this.e_graphicZoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.e_graphicZoomOut.Image = global::LAZYSHELL.Properties.Resources.zoomout_small;
            this.e_graphicZoomOut.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.e_graphicZoomOut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.e_graphicZoomOut.Name = "e_graphicZoomOut";
            this.e_graphicZoomOut.Size = new System.Drawing.Size(23, 17);
            this.e_graphicZoomOut.Text = "Zoom Out";
            this.e_graphicZoomOut.Click += new System.EventHandler(this.e_graphicZoomOut_Click);
            // 
            // labelEffectGraphics
            // 
            this.labelEffectGraphics.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.labelEffectGraphics.BackColor = System.Drawing.SystemColors.ControlDark;
            this.labelEffectGraphics.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.labelEffectGraphics.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEffectGraphics.ForeColor = System.Drawing.SystemColors.Control;
            this.labelEffectGraphics.Location = new System.Drawing.Point(0, 0);
            this.labelEffectGraphics.Name = "labelEffectGraphics";
            this.labelEffectGraphics.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.labelEffectGraphics.Size = new System.Drawing.Size(256, 17);
            this.labelEffectGraphics.TabIndex = 417;
            this.labelEffectGraphics.Text = "IMAGE GRAPHICS...";
            this.labelEffectGraphics.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.labelEffectGraphics, "Click to drag or double-click to maximize / restore");
            this.labelEffectGraphics.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.labelEffectGraphics_MouseDoubleClick);
            this.labelEffectGraphics.MouseDown += new System.Windows.Forms.MouseEventHandler(this.labelEffectGraphics_MouseDown);
            this.labelEffectGraphics.MouseUp += new System.Windows.Forms.MouseEventHandler(this.labelEffectGraphics_MouseUp);
            // 
            // e_graphicSetSize
            // 
            this.e_graphicSetSize.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.e_graphicSetSize.Increment = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.e_graphicSetSize.Location = new System.Drawing.Point(65, 19);
            this.e_graphicSetSize.Maximum = new decimal(new int[] {
            8192,
            0,
            0,
            0});
            this.e_graphicSetSize.Minimum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.e_graphicSetSize.Name = "e_graphicSetSize";
            this.e_graphicSetSize.Size = new System.Drawing.Size(63, 17);
            this.e_graphicSetSize.TabIndex = 16;
            this.e_graphicSetSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.e_graphicSetSize.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.e_graphicSetSize.ValueChanged += new System.EventHandler(this.e_graphicSetSize_ValueChanged);
            // 
            // label90
            // 
            this.label90.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label90.Location = new System.Drawing.Point(129, 19);
            this.label90.Name = "label90";
            this.label90.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label90.Size = new System.Drawing.Size(64, 17);
            this.label90.TabIndex = 394;
            this.label90.Text = "Codec";
            // 
            // label89
            // 
            this.label89.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label89.Location = new System.Drawing.Point(0, 19);
            this.label89.Name = "label89";
            this.label89.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label89.Size = new System.Drawing.Size(64, 17);
            this.label89.TabIndex = 394;
            this.label89.Text = "Size";
            // 
            // panel89
            // 
            this.panel89.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel89.AutoScroll = true;
            this.panel89.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel89.Controls.Add(this.pictureBoxE_Graphics);
            this.panel89.Location = new System.Drawing.Point(0, 73);
            this.panel89.Name = "panel89";
            this.panel89.Size = new System.Drawing.Size(256, 189);
            this.panel89.TabIndex = 524;
            this.panel89.Scroll += new System.Windows.Forms.ScrollEventHandler(this.panel89_Scroll);
            // 
            // pictureBoxE_Graphics
            // 
            this.pictureBoxE_Graphics.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pictureBoxE_Graphics.BackgroundImage = global::LAZYSHELL.Properties.Resources._transparent;
            this.pictureBoxE_Graphics.ContextMenuStrip = this.contextMenuStripGR;
            this.pictureBoxE_Graphics.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxE_Graphics.Name = "pictureBoxE_Graphics";
            this.pictureBoxE_Graphics.Size = new System.Drawing.Size(128, 128);
            this.pictureBoxE_Graphics.TabIndex = 396;
            this.pictureBoxE_Graphics.TabStop = false;
            this.pictureBoxE_Graphics.MouseLeave += new System.EventHandler(this.pictureBoxE_Graphics_MouseLeave);
            this.pictureBoxE_Graphics.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.pictureBoxE_Graphics_PreviewKeyDown);
            this.pictureBoxE_Graphics.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxE_Graphics_MouseMove);
            this.pictureBoxE_Graphics.Click += new System.EventHandler(this.pictureBoxE_Graphics_Click);
            this.pictureBoxE_Graphics.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pictureBoxE_Graphics_MouseDoubleClick);
            this.pictureBoxE_Graphics.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxE_Graphics_MouseDown);
            this.pictureBoxE_Graphics.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxE_Graphics_Paint);
            this.pictureBoxE_Graphics.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBoxE_Graphics_MouseUp);
            this.pictureBoxE_Graphics.MouseEnter += new System.EventHandler(this.pictureBoxE_Graphics_MouseEnter);
            // 
            // panel80
            // 
            this.panel80.BackColor = System.Drawing.SystemColors.ControlText;
            this.panel80.Controls.Add(this.panel85);
            this.panel80.Location = new System.Drawing.Point(6, 135);
            this.panel80.Name = "panel80";
            this.panel80.Size = new System.Drawing.Size(260, 241);
            this.panel80.TabIndex = 400;
            // 
            // panel85
            // 
            this.panel85.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.panel85.Controls.Add(this.label63);
            this.panel85.Controls.Add(this.e_paletteBlueBar);
            this.panel85.Controls.Add(this.label109);
            this.panel85.Controls.Add(this.pictureBoxE_Color);
            this.panel85.Controls.Add(this.pictureBoxE_Palette);
            this.panel85.Controls.Add(this.label82);
            this.panel85.Controls.Add(this.e_paletteSetSize);
            this.panel85.Controls.Add(this.e_paletteBlueNum);
            this.panel85.Controls.Add(this.e_paletteColor);
            this.panel85.Controls.Add(this.label107);
            this.panel85.Controls.Add(this.e_paletteRedNum);
            this.panel85.Controls.Add(this.e_paletteGreenBar);
            this.panel85.Controls.Add(this.label83);
            this.panel85.Controls.Add(this.label84);
            this.panel85.Controls.Add(this.e_paletteGreenNum);
            this.panel85.Controls.Add(this.label85);
            this.panel85.Controls.Add(this.e_paletteRedBar);
            this.panel85.Location = new System.Drawing.Point(2, 2);
            this.panel85.Name = "panel85";
            this.panel85.Size = new System.Drawing.Size(256, 237);
            this.panel85.TabIndex = 7;
            // 
            // label63
            // 
            this.label63.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label63.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label63.ForeColor = System.Drawing.SystemColors.Control;
            this.label63.Location = new System.Drawing.Point(0, 0);
            this.label63.Name = "label63";
            this.label63.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.label63.Size = new System.Drawing.Size(256, 17);
            this.label63.TabIndex = 417;
            this.label63.Text = "IMAGE PALETTE...";
            this.label63.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // e_paletteBlueBar
            // 
            this.e_paletteBlueBar.AutoSize = false;
            this.e_paletteBlueBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.e_paletteBlueBar.LargeChange = 32;
            this.e_paletteBlueBar.Location = new System.Drawing.Point(98, 220);
            this.e_paletteBlueBar.Maximum = 248;
            this.e_paletteBlueBar.Name = "e_paletteBlueBar";
            this.e_paletteBlueBar.Size = new System.Drawing.Size(158, 17);
            this.e_paletteBlueBar.SmallChange = 8;
            this.e_paletteBlueBar.TabIndex = 15;
            this.e_paletteBlueBar.TickFrequency = 8;
            this.e_paletteBlueBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.e_paletteBlueBar.Scroll += new System.EventHandler(this.e_paletteBlueBar_Scroll);
            // 
            // label109
            // 
            this.label109.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label109.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label109.Location = new System.Drawing.Point(129, 19);
            this.label109.Name = "label109";
            this.label109.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label109.Size = new System.Drawing.Size(127, 17);
            this.label109.TabIndex = 525;
            this.label109.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // pictureBoxE_Color
            // 
            this.pictureBoxE_Color.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.pictureBoxE_Color.Location = new System.Drawing.Point(98, 166);
            this.pictureBoxE_Color.Name = "pictureBoxE_Color";
            this.pictureBoxE_Color.Size = new System.Drawing.Size(158, 17);
            this.pictureBoxE_Color.TabIndex = 416;
            this.pictureBoxE_Color.TabStop = false;
            // 
            // pictureBoxE_Palette
            // 
            this.pictureBoxE_Palette.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pictureBoxE_Palette.ContextMenuStrip = this.contextMenuStrip3;
            this.pictureBoxE_Palette.Location = new System.Drawing.Point(0, 37);
            this.pictureBoxE_Palette.Name = "pictureBoxE_Palette";
            this.pictureBoxE_Palette.Size = new System.Drawing.Size(256, 128);
            this.pictureBoxE_Palette.TabIndex = 416;
            this.pictureBoxE_Palette.TabStop = false;
            this.pictureBoxE_Palette.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBoxE_Palette_MouseClick);
            this.pictureBoxE_Palette.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxE_Palette_Paint);
            // 
            // label82
            // 
            this.label82.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label82.Location = new System.Drawing.Point(0, 202);
            this.label82.Name = "label82";
            this.label82.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label82.Size = new System.Drawing.Size(46, 17);
            this.label82.TabIndex = 422;
            this.label82.Text = "Green";
            // 
            // e_paletteSetSize
            // 
            this.e_paletteSetSize.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.e_paletteSetSize.Increment = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.e_paletteSetSize.Location = new System.Drawing.Point(69, 19);
            this.e_paletteSetSize.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.e_paletteSetSize.Minimum = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.e_paletteSetSize.Name = "e_paletteSetSize";
            this.e_paletteSetSize.Size = new System.Drawing.Size(59, 17);
            this.e_paletteSetSize.TabIndex = 16;
            this.e_paletteSetSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.e_paletteSetSize.Value = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.e_paletteSetSize.ValueChanged += new System.EventHandler(this.e_paletteSetSize_ValueChanged);
            // 
            // e_paletteBlueNum
            // 
            this.e_paletteBlueNum.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.e_paletteBlueNum.Increment = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.e_paletteBlueNum.Location = new System.Drawing.Point(47, 220);
            this.e_paletteBlueNum.Maximum = new decimal(new int[] {
            248,
            0,
            0,
            0});
            this.e_paletteBlueNum.Name = "e_paletteBlueNum";
            this.e_paletteBlueNum.Size = new System.Drawing.Size(50, 17);
            this.e_paletteBlueNum.TabIndex = 12;
            this.e_paletteBlueNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.e_paletteBlueNum.ValueChanged += new System.EventHandler(this.e_paletteBlueNum_ValueChanged);
            // 
            // e_paletteColor
            // 
            this.e_paletteColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.e_paletteColor.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.e_paletteColor.Location = new System.Drawing.Point(47, 166);
            this.e_paletteColor.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.e_paletteColor.Name = "e_paletteColor";
            this.e_paletteColor.Size = new System.Drawing.Size(50, 17);
            this.e_paletteColor.TabIndex = 9;
            this.e_paletteColor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.e_paletteColor.ValueChanged += new System.EventHandler(this.e_paletteColor_ValueChanged);
            // 
            // label107
            // 
            this.label107.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label107.Location = new System.Drawing.Point(0, 19);
            this.label107.Name = "label107";
            this.label107.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label107.Size = new System.Drawing.Size(68, 17);
            this.label107.TabIndex = 394;
            this.label107.Text = "Size";
            // 
            // e_paletteRedNum
            // 
            this.e_paletteRedNum.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.e_paletteRedNum.Increment = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.e_paletteRedNum.Location = new System.Drawing.Point(47, 184);
            this.e_paletteRedNum.Maximum = new decimal(new int[] {
            248,
            0,
            0,
            0});
            this.e_paletteRedNum.Name = "e_paletteRedNum";
            this.e_paletteRedNum.Size = new System.Drawing.Size(50, 17);
            this.e_paletteRedNum.TabIndex = 10;
            this.e_paletteRedNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.e_paletteRedNum.ValueChanged += new System.EventHandler(this.e_paletteRedNum_ValueChanged);
            // 
            // e_paletteGreenBar
            // 
            this.e_paletteGreenBar.AutoSize = false;
            this.e_paletteGreenBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.e_paletteGreenBar.LargeChange = 32;
            this.e_paletteGreenBar.Location = new System.Drawing.Point(98, 202);
            this.e_paletteGreenBar.Maximum = 248;
            this.e_paletteGreenBar.Name = "e_paletteGreenBar";
            this.e_paletteGreenBar.Size = new System.Drawing.Size(158, 17);
            this.e_paletteGreenBar.SmallChange = 8;
            this.e_paletteGreenBar.TabIndex = 14;
            this.e_paletteGreenBar.TickFrequency = 8;
            this.e_paletteGreenBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.e_paletteGreenBar.Scroll += new System.EventHandler(this.e_paletteGreenBar_Scroll);
            // 
            // label83
            // 
            this.label83.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label83.Location = new System.Drawing.Point(0, 166);
            this.label83.Name = "label83";
            this.label83.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label83.Size = new System.Drawing.Size(46, 17);
            this.label83.TabIndex = 420;
            this.label83.Text = "Color";
            // 
            // label84
            // 
            this.label84.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label84.Location = new System.Drawing.Point(0, 184);
            this.label84.Name = "label84";
            this.label84.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label84.Size = new System.Drawing.Size(46, 17);
            this.label84.TabIndex = 420;
            this.label84.Text = "Red";
            // 
            // e_paletteGreenNum
            // 
            this.e_paletteGreenNum.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.e_paletteGreenNum.Increment = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.e_paletteGreenNum.Location = new System.Drawing.Point(47, 202);
            this.e_paletteGreenNum.Maximum = new decimal(new int[] {
            248,
            0,
            0,
            0});
            this.e_paletteGreenNum.Name = "e_paletteGreenNum";
            this.e_paletteGreenNum.Size = new System.Drawing.Size(50, 17);
            this.e_paletteGreenNum.TabIndex = 11;
            this.e_paletteGreenNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.e_paletteGreenNum.ValueChanged += new System.EventHandler(this.e_paletteGreenNum_ValueChanged);
            // 
            // label85
            // 
            this.label85.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label85.Location = new System.Drawing.Point(0, 220);
            this.label85.Name = "label85";
            this.label85.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label85.Size = new System.Drawing.Size(46, 17);
            this.label85.TabIndex = 424;
            this.label85.Text = "Blue";
            // 
            // e_paletteRedBar
            // 
            this.e_paletteRedBar.AutoSize = false;
            this.e_paletteRedBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.e_paletteRedBar.LargeChange = 32;
            this.e_paletteRedBar.Location = new System.Drawing.Point(98, 184);
            this.e_paletteRedBar.Maximum = 248;
            this.e_paletteRedBar.Name = "e_paletteRedBar";
            this.e_paletteRedBar.Size = new System.Drawing.Size(158, 17);
            this.e_paletteRedBar.SmallChange = 8;
            this.e_paletteRedBar.TabIndex = 13;
            this.e_paletteRedBar.TickFrequency = 8;
            this.e_paletteRedBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.e_paletteRedBar.Scroll += new System.EventHandler(this.e_paletteRedBar_Scroll);
            // 
            // panel41
            // 
            this.panel41.Controls.Add(this.e_ColorBalance);
            this.panel41.Controls.Add(this.label116);
            this.panel41.Controls.Add(this.label98);
            this.panel41.Controls.Add(this.yNegShift);
            this.panel41.Controls.Add(this.label96);
            this.panel41.Controls.Add(this.xNegShift);
            this.panel41.Controls.Add(this.e_animation);
            this.panel41.Controls.Add(this.e_paletteIndex);
            this.panel41.Controls.Add(this.label2);
            this.panel41.Controls.Add(this.label7);
            this.panel41.Location = new System.Drawing.Point(6, 71);
            this.panel41.Name = "panel41";
            this.panel41.Size = new System.Drawing.Size(260, 58);
            this.panel41.TabIndex = 3;
            // 
            // e_ColorBalance
            // 
            this.e_ColorBalance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.e_ColorBalance.FlatAppearance.BorderSize = 0;
            this.e_ColorBalance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.e_ColorBalance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.e_ColorBalance.Location = new System.Drawing.Point(131, 2);
            this.e_ColorBalance.Name = "e_ColorBalance";
            this.e_ColorBalance.Size = new System.Drawing.Size(127, 17);
            this.e_ColorBalance.TabIndex = 426;
            this.e_ColorBalance.Text = "COLOR MATH...";
            this.e_ColorBalance.UseCompatibleTextRendering = true;
            this.e_ColorBalance.UseVisualStyleBackColor = false;
            this.e_ColorBalance.Click += new System.EventHandler(this.e_ColorBalance_Click);
            // 
            // label116
            // 
            this.label116.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label116.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label116.ForeColor = System.Drawing.SystemColors.Control;
            this.label116.Location = new System.Drawing.Point(2, 2);
            this.label116.Name = "label116";
            this.label116.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.label116.Size = new System.Drawing.Size(128, 17);
            this.label116.TabIndex = 417;
            this.label116.Text = "EFFECT PROPERTIES...";
            this.label116.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label98
            // 
            this.label98.BackColor = System.Drawing.SystemColors.Control;
            this.label98.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label98.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label98.Location = new System.Drawing.Point(131, 39);
            this.label98.Name = "label98";
            this.label98.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label98.Size = new System.Drawing.Size(64, 17);
            this.label98.TabIndex = 396;
            this.label98.Text = "Y shift";
            // 
            // yNegShift
            // 
            this.yNegShift.BackColor = System.Drawing.SystemColors.Control;
            this.yNegShift.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.yNegShift.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yNegShift.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.yNegShift.Location = new System.Drawing.Point(196, 39);
            this.yNegShift.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.yNegShift.Name = "yNegShift";
            this.yNegShift.Size = new System.Drawing.Size(63, 17);
            this.yNegShift.TabIndex = 395;
            this.yNegShift.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.yNegShift.ValueChanged += new System.EventHandler(this.yNegShift_ValueChanged);
            // 
            // label96
            // 
            this.label96.BackColor = System.Drawing.SystemColors.Control;
            this.label96.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label96.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label96.Location = new System.Drawing.Point(131, 21);
            this.label96.Name = "label96";
            this.label96.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label96.Size = new System.Drawing.Size(64, 17);
            this.label96.TabIndex = 396;
            this.label96.Text = "X shift";
            // 
            // xNegShift
            // 
            this.xNegShift.BackColor = System.Drawing.SystemColors.Control;
            this.xNegShift.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.xNegShift.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xNegShift.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.xNegShift.Location = new System.Drawing.Point(196, 21);
            this.xNegShift.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.xNegShift.Name = "xNegShift";
            this.xNegShift.Size = new System.Drawing.Size(63, 17);
            this.xNegShift.TabIndex = 395;
            this.xNegShift.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.xNegShift.ValueChanged += new System.EventHandler(this.xNegShift_ValueChanged);
            // 
            // e_animation
            // 
            this.e_animation.BackColor = System.Drawing.SystemColors.ControlDark;
            this.e_animation.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.e_animation.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.e_animation.ForeColor = System.Drawing.SystemColors.Control;
            this.e_animation.Location = new System.Drawing.Point(71, 21);
            this.e_animation.Maximum = new decimal(new int[] {
            63,
            0,
            0,
            0});
            this.e_animation.Name = "e_animation";
            this.e_animation.Size = new System.Drawing.Size(59, 17);
            this.e_animation.TabIndex = 3;
            this.e_animation.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.e_animation.ValueChanged += new System.EventHandler(this.e_animation_ValueChanged);
            // 
            // e_paletteIndex
            // 
            this.e_paletteIndex.BackColor = System.Drawing.SystemColors.ControlDark;
            this.e_paletteIndex.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.e_paletteIndex.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.e_paletteIndex.ForeColor = System.Drawing.SystemColors.Control;
            this.e_paletteIndex.Location = new System.Drawing.Point(71, 39);
            this.e_paletteIndex.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.e_paletteIndex.Name = "e_paletteIndex";
            this.e_paletteIndex.Size = new System.Drawing.Size(59, 17);
            this.e_paletteIndex.TabIndex = 4;
            this.e_paletteIndex.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.e_paletteIndex.ValueChanged += new System.EventHandler(this.e_paletteIndex_ValueChanged);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(2, 21);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label2.Size = new System.Drawing.Size(68, 17);
            this.label2.TabIndex = 394;
            this.label2.Text = "IMAGE #";
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.Control;
            this.label7.Location = new System.Drawing.Point(2, 39);
            this.label7.Name = "label7";
            this.label7.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label7.Size = new System.Drawing.Size(68, 17);
            this.label7.TabIndex = 394;
            this.label7.Text = "PALETTE +";
            // 
            // panelSearchEffectNames
            // 
            this.panelSearchEffectNames.BackColor = System.Drawing.SystemColors.ControlText;
            this.panelSearchEffectNames.Controls.Add(this.listBoxEffectNames);
            this.panelSearchEffectNames.Controls.Add(this.panel86);
            this.panelSearchEffectNames.Location = new System.Drawing.Point(6, 25);
            this.panelSearchEffectNames.Name = "panelSearchEffectNames";
            this.panelSearchEffectNames.Size = new System.Drawing.Size(254, 326);
            this.panelSearchEffectNames.TabIndex = 520;
            this.panelSearchEffectNames.Visible = false;
            // 
            // listBoxEffectNames
            // 
            this.listBoxEffectNames.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBoxEffectNames.FormattingEnabled = true;
            this.listBoxEffectNames.Location = new System.Drawing.Point(2, 21);
            this.listBoxEffectNames.Name = "listBoxEffectNames";
            this.listBoxEffectNames.Size = new System.Drawing.Size(250, 299);
            this.listBoxEffectNames.TabIndex = 194;
            this.listBoxEffectNames.SelectedIndexChanged += new System.EventHandler(this.listBoxEffectNames_SelectedIndexChanged);
            this.listBoxEffectNames.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listBoxEffectNames_KeyDown);
            // 
            // panel86
            // 
            this.panel86.BackColor = System.Drawing.SystemColors.Window;
            this.panel86.Controls.Add(this.nameTextBoxEffects);
            this.panel86.Location = new System.Drawing.Point(2, 2);
            this.panel86.Name = "panel86";
            this.panel86.Size = new System.Drawing.Size(250, 17);
            this.panel86.TabIndex = 193;
            // 
            // nameTextBoxEffects
            // 
            this.nameTextBoxEffects.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.nameTextBoxEffects.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.nameTextBoxEffects.Location = new System.Drawing.Point(4, 2);
            this.nameTextBoxEffects.MaxLength = 128;
            this.nameTextBoxEffects.Name = "nameTextBoxEffects";
            this.nameTextBoxEffects.Size = new System.Drawing.Size(244, 14);
            this.nameTextBoxEffects.TabIndex = 4;
            this.nameTextBoxEffects.TextChanged += new System.EventHandler(this.nameTextBoxEffects_TextChanged);
            this.nameTextBoxEffects.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nameTextBoxEffects_KeyDown);
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.SystemColors.ControlText;
            this.tabPage3.Controls.Add(this.panel57);
            this.tabPage3.Location = new System.Drawing.Point(175, 4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(809, 658);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "WORLD MAPS";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // panel57
            // 
            this.panel57.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel57.BackgroundImage = global::LAZYSHELL.Properties.Resources._bg;
            this.panel57.Controls.Add(this.panel79);
            this.panel57.Controls.Add(this.panel78);
            this.panel57.Controls.Add(this.panel48);
            this.panel57.Controls.Add(this.panel214);
            this.panel57.Controls.Add(this.panel51);
            this.panel57.Controls.Add(this.panel49);
            this.panel57.Controls.Add(this.panel53);
            this.panel57.Location = new System.Drawing.Point(2, 2);
            this.panel57.Name = "panel57";
            this.panel57.Size = new System.Drawing.Size(805, 654);
            this.panel57.TabIndex = 543;
            // 
            // panel79
            // 
            this.panel79.Controls.Add(this.panel35);
            this.panel79.Location = new System.Drawing.Point(6, 554);
            this.panel79.Name = "panel79";
            this.panel79.Size = new System.Drawing.Size(260, 94);
            this.panel79.TabIndex = 545;
            // 
            // panel35
            // 
            this.panel35.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.panel35.Controls.Add(this.enableNorthPath);
            this.panel35.Controls.Add(this.enableWestPath);
            this.panel35.Controls.Add(this.enableSouthPath);
            this.panel35.Controls.Add(this.enableEastPath);
            this.panel35.Controls.Add(this.label54);
            this.panel35.Controls.Add(this.label26);
            this.panel35.Controls.Add(this.label51);
            this.panel35.Controls.Add(this.toSouthCheckAddress);
            this.panel35.Controls.Add(this.toWestCheckAddress);
            this.panel35.Controls.Add(this.toNorthCheckAddress);
            this.panel35.Controls.Add(this.toEastCheckAddress);
            this.panel35.Controls.Add(this.panel18);
            this.panel35.Controls.Add(this.toEastCheckBit);
            this.panel35.Controls.Add(this.panel20);
            this.panel35.Controls.Add(this.toWestCheckBit);
            this.panel35.Controls.Add(this.panel19);
            this.panel35.Controls.Add(this.toSouthCheckBit);
            this.panel35.Controls.Add(this.toNorthCheckBit);
            this.panel35.Controls.Add(this.panel21);
            this.panel35.Location = new System.Drawing.Point(2, 2);
            this.panel35.Name = "panel35";
            this.panel35.Size = new System.Drawing.Size(256, 90);
            this.panel35.TabIndex = 86;
            // 
            // enableNorthPath
            // 
            this.enableNorthPath.Appearance = System.Windows.Forms.Appearance.Button;
            this.enableNorthPath.BackColor = System.Drawing.SystemColors.Control;
            this.enableNorthPath.FlatAppearance.BorderSize = 0;
            this.enableNorthPath.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(168)))), ((int)(((byte)(168)))));
            this.enableNorthPath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.enableNorthPath.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.enableNorthPath.Location = new System.Drawing.Point(0, 73);
            this.enableNorthPath.Name = "enableNorthPath";
            this.enableNorthPath.Size = new System.Drawing.Size(19, 17);
            this.enableNorthPath.TabIndex = 89;
            this.enableNorthPath.Text = "N";
            this.enableNorthPath.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.enableNorthPath.UseCompatibleTextRendering = true;
            this.enableNorthPath.UseVisualStyleBackColor = false;
            this.enableNorthPath.CheckedChanged += new System.EventHandler(this.enableNorthPath_CheckedChanged);
            // 
            // enableWestPath
            // 
            this.enableWestPath.Appearance = System.Windows.Forms.Appearance.Button;
            this.enableWestPath.BackColor = System.Drawing.SystemColors.Control;
            this.enableWestPath.FlatAppearance.BorderSize = 0;
            this.enableWestPath.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(168)))), ((int)(((byte)(168)))));
            this.enableWestPath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.enableWestPath.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.enableWestPath.Location = new System.Drawing.Point(0, 55);
            this.enableWestPath.Name = "enableWestPath";
            this.enableWestPath.Size = new System.Drawing.Size(19, 17);
            this.enableWestPath.TabIndex = 88;
            this.enableWestPath.Text = "W";
            this.enableWestPath.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.enableWestPath.UseCompatibleTextRendering = true;
            this.enableWestPath.UseVisualStyleBackColor = false;
            this.enableWestPath.CheckedChanged += new System.EventHandler(this.enableWestPath_CheckedChanged);
            // 
            // enableSouthPath
            // 
            this.enableSouthPath.Appearance = System.Windows.Forms.Appearance.Button;
            this.enableSouthPath.BackColor = System.Drawing.SystemColors.Control;
            this.enableSouthPath.FlatAppearance.BorderSize = 0;
            this.enableSouthPath.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(168)))), ((int)(((byte)(168)))));
            this.enableSouthPath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.enableSouthPath.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.enableSouthPath.Location = new System.Drawing.Point(0, 37);
            this.enableSouthPath.Name = "enableSouthPath";
            this.enableSouthPath.Size = new System.Drawing.Size(19, 17);
            this.enableSouthPath.TabIndex = 87;
            this.enableSouthPath.Text = "S";
            this.enableSouthPath.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.enableSouthPath.UseCompatibleTextRendering = true;
            this.enableSouthPath.UseVisualStyleBackColor = false;
            this.enableSouthPath.CheckedChanged += new System.EventHandler(this.enableSouthPath_CheckedChanged);
            // 
            // enableEastPath
            // 
            this.enableEastPath.Appearance = System.Windows.Forms.Appearance.Button;
            this.enableEastPath.BackColor = System.Drawing.SystemColors.Control;
            this.enableEastPath.FlatAppearance.BorderSize = 0;
            this.enableEastPath.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(168)))), ((int)(((byte)(168)))));
            this.enableEastPath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.enableEastPath.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.enableEastPath.Location = new System.Drawing.Point(0, 19);
            this.enableEastPath.Name = "enableEastPath";
            this.enableEastPath.Size = new System.Drawing.Size(19, 17);
            this.enableEastPath.TabIndex = 86;
            this.enableEastPath.Text = "E";
            this.enableEastPath.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.enableEastPath.UseCompatibleTextRendering = true;
            this.enableEastPath.UseVisualStyleBackColor = false;
            this.enableEastPath.CheckedChanged += new System.EventHandler(this.enableEastPath_CheckedChanged);
            // 
            // label54
            // 
            this.label54.BackColor = System.Drawing.SystemColors.Control;
            this.label54.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label54.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label54.Location = new System.Drawing.Point(205, 0);
            this.label54.Name = "label54";
            this.label54.Padding = new System.Windows.Forms.Padding(2, 2, 0, 0);
            this.label54.Size = new System.Drawing.Size(51, 17);
            this.label54.TabIndex = 480;
            this.label54.Text = "BIT SET";
            // 
            // label26
            // 
            this.label26.BackColor = System.Drawing.SystemColors.Control;
            this.label26.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label26.Location = new System.Drawing.Point(130, 0);
            this.label26.Name = "label26";
            this.label26.Padding = new System.Windows.Forms.Padding(2, 2, 0, 0);
            this.label26.Size = new System.Drawing.Size(74, 17);
            this.label26.TabIndex = 480;
            this.label26.Text = "IF MEMORY";
            // 
            // label51
            // 
            this.label51.BackColor = System.Drawing.SystemColors.Control;
            this.label51.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label51.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label51.Location = new System.Drawing.Point(0, 0);
            this.label51.Name = "label51";
            this.label51.Padding = new System.Windows.Forms.Padding(2, 2, 0, 0);
            this.label51.Size = new System.Drawing.Size(129, 17);
            this.label51.TabIndex = 480;
            this.label51.Text = "OPEN PATH...";
            // 
            // toSouthCheckAddress
            // 
            this.toSouthCheckAddress.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.toSouthCheckAddress.Hexadecimal = true;
            this.toSouthCheckAddress.Location = new System.Drawing.Point(130, 37);
            this.toSouthCheckAddress.Maximum = new decimal(new int[] {
            28804,
            0,
            0,
            0});
            this.toSouthCheckAddress.Minimum = new decimal(new int[] {
            28741,
            0,
            0,
            0});
            this.toSouthCheckAddress.Name = "toSouthCheckAddress";
            this.toSouthCheckAddress.Size = new System.Drawing.Size(74, 17);
            this.toSouthCheckAddress.TabIndex = 94;
            this.toSouthCheckAddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toSouthCheckAddress.Value = new decimal(new int[] {
            28741,
            0,
            0,
            0});
            this.toSouthCheckAddress.ValueChanged += new System.EventHandler(this.toSouthCheckAddress_ValueChanged);
            // 
            // toWestCheckAddress
            // 
            this.toWestCheckAddress.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.toWestCheckAddress.Hexadecimal = true;
            this.toWestCheckAddress.Location = new System.Drawing.Point(130, 55);
            this.toWestCheckAddress.Maximum = new decimal(new int[] {
            28804,
            0,
            0,
            0});
            this.toWestCheckAddress.Minimum = new decimal(new int[] {
            28741,
            0,
            0,
            0});
            this.toWestCheckAddress.Name = "toWestCheckAddress";
            this.toWestCheckAddress.Size = new System.Drawing.Size(74, 17);
            this.toWestCheckAddress.TabIndex = 97;
            this.toWestCheckAddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toWestCheckAddress.Value = new decimal(new int[] {
            28741,
            0,
            0,
            0});
            this.toWestCheckAddress.ValueChanged += new System.EventHandler(this.toWestCheckAddress_ValueChanged);
            // 
            // toNorthCheckAddress
            // 
            this.toNorthCheckAddress.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.toNorthCheckAddress.Hexadecimal = true;
            this.toNorthCheckAddress.Location = new System.Drawing.Point(130, 73);
            this.toNorthCheckAddress.Maximum = new decimal(new int[] {
            28804,
            0,
            0,
            0});
            this.toNorthCheckAddress.Minimum = new decimal(new int[] {
            28741,
            0,
            0,
            0});
            this.toNorthCheckAddress.Name = "toNorthCheckAddress";
            this.toNorthCheckAddress.Size = new System.Drawing.Size(74, 17);
            this.toNorthCheckAddress.TabIndex = 100;
            this.toNorthCheckAddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toNorthCheckAddress.Value = new decimal(new int[] {
            28741,
            0,
            0,
            0});
            this.toNorthCheckAddress.ValueChanged += new System.EventHandler(this.toNorthCheckAddress_ValueChanged);
            // 
            // toEastCheckAddress
            // 
            this.toEastCheckAddress.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.toEastCheckAddress.Hexadecimal = true;
            this.toEastCheckAddress.Location = new System.Drawing.Point(130, 19);
            this.toEastCheckAddress.Maximum = new decimal(new int[] {
            28804,
            0,
            0,
            0});
            this.toEastCheckAddress.Minimum = new decimal(new int[] {
            28741,
            0,
            0,
            0});
            this.toEastCheckAddress.Name = "toEastCheckAddress";
            this.toEastCheckAddress.Size = new System.Drawing.Size(74, 17);
            this.toEastCheckAddress.TabIndex = 91;
            this.toEastCheckAddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toEastCheckAddress.Value = new decimal(new int[] {
            28741,
            0,
            0,
            0});
            this.toEastCheckAddress.ValueChanged += new System.EventHandler(this.toEastCheckAddress_ValueChanged);
            // 
            // panel18
            // 
            this.panel18.Controls.Add(this.toEastPoint);
            this.panel18.Location = new System.Drawing.Point(20, 19);
            this.panel18.Name = "panel18";
            this.panel18.Size = new System.Drawing.Size(109, 17);
            this.panel18.TabIndex = 90;
            // 
            // toEastPoint
            // 
            this.toEastPoint.DropDownHeight = 340;
            this.toEastPoint.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toEastPoint.DropDownWidth = 150;
            this.toEastPoint.FormattingEnabled = true;
            this.toEastPoint.IntegralHeight = false;
            this.toEastPoint.Location = new System.Drawing.Point(-2, -2);
            this.toEastPoint.Name = "toEastPoint";
            this.toEastPoint.Size = new System.Drawing.Size(113, 21);
            this.toEastPoint.TabIndex = 400;
            this.toEastPoint.SelectedIndexChanged += new System.EventHandler(this.toEastPoint_SelectedIndexChanged);
            // 
            // toEastCheckBit
            // 
            this.toEastCheckBit.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.toEastCheckBit.Location = new System.Drawing.Point(205, 19);
            this.toEastCheckBit.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.toEastCheckBit.Name = "toEastCheckBit";
            this.toEastCheckBit.Size = new System.Drawing.Size(52, 17);
            this.toEastCheckBit.TabIndex = 92;
            this.toEastCheckBit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toEastCheckBit.ValueChanged += new System.EventHandler(this.toEastCheckBit_ValueChanged);
            // 
            // panel20
            // 
            this.panel20.Controls.Add(this.toWestPoint);
            this.panel20.Location = new System.Drawing.Point(20, 55);
            this.panel20.Name = "panel20";
            this.panel20.Size = new System.Drawing.Size(109, 17);
            this.panel20.TabIndex = 96;
            // 
            // toWestPoint
            // 
            this.toWestPoint.DropDownHeight = 340;
            this.toWestPoint.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toWestPoint.DropDownWidth = 150;
            this.toWestPoint.FormattingEnabled = true;
            this.toWestPoint.IntegralHeight = false;
            this.toWestPoint.Location = new System.Drawing.Point(-2, -2);
            this.toWestPoint.Name = "toWestPoint";
            this.toWestPoint.Size = new System.Drawing.Size(113, 21);
            this.toWestPoint.TabIndex = 400;
            this.toWestPoint.SelectedIndexChanged += new System.EventHandler(this.toWestPoint_SelectedIndexChanged);
            // 
            // toWestCheckBit
            // 
            this.toWestCheckBit.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.toWestCheckBit.Location = new System.Drawing.Point(205, 55);
            this.toWestCheckBit.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.toWestCheckBit.Name = "toWestCheckBit";
            this.toWestCheckBit.Size = new System.Drawing.Size(52, 17);
            this.toWestCheckBit.TabIndex = 98;
            this.toWestCheckBit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toWestCheckBit.ValueChanged += new System.EventHandler(this.toWestCheckbit_ValueChanged);
            // 
            // panel19
            // 
            this.panel19.Controls.Add(this.toSouthPoint);
            this.panel19.Location = new System.Drawing.Point(20, 37);
            this.panel19.Name = "panel19";
            this.panel19.Size = new System.Drawing.Size(109, 17);
            this.panel19.TabIndex = 93;
            // 
            // toSouthPoint
            // 
            this.toSouthPoint.DropDownHeight = 340;
            this.toSouthPoint.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toSouthPoint.DropDownWidth = 150;
            this.toSouthPoint.FormattingEnabled = true;
            this.toSouthPoint.IntegralHeight = false;
            this.toSouthPoint.Location = new System.Drawing.Point(-2, -2);
            this.toSouthPoint.Name = "toSouthPoint";
            this.toSouthPoint.Size = new System.Drawing.Size(113, 21);
            this.toSouthPoint.TabIndex = 400;
            this.toSouthPoint.SelectedIndexChanged += new System.EventHandler(this.toSouthPoint_SelectedIndexChanged);
            // 
            // toSouthCheckBit
            // 
            this.toSouthCheckBit.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.toSouthCheckBit.Location = new System.Drawing.Point(205, 37);
            this.toSouthCheckBit.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.toSouthCheckBit.Name = "toSouthCheckBit";
            this.toSouthCheckBit.Size = new System.Drawing.Size(52, 17);
            this.toSouthCheckBit.TabIndex = 95;
            this.toSouthCheckBit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toSouthCheckBit.ValueChanged += new System.EventHandler(this.toSouthCheckBit_ValueChanged);
            // 
            // toNorthCheckBit
            // 
            this.toNorthCheckBit.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.toNorthCheckBit.Location = new System.Drawing.Point(205, 73);
            this.toNorthCheckBit.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.toNorthCheckBit.Name = "toNorthCheckBit";
            this.toNorthCheckBit.Size = new System.Drawing.Size(52, 17);
            this.toNorthCheckBit.TabIndex = 101;
            this.toNorthCheckBit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toNorthCheckBit.ValueChanged += new System.EventHandler(this.toNorthCheckBit_ValueChanged);
            // 
            // panel21
            // 
            this.panel21.Controls.Add(this.toNorthPoint);
            this.panel21.Location = new System.Drawing.Point(20, 73);
            this.panel21.Name = "panel21";
            this.panel21.Size = new System.Drawing.Size(109, 17);
            this.panel21.TabIndex = 99;
            // 
            // toNorthPoint
            // 
            this.toNorthPoint.DropDownHeight = 340;
            this.toNorthPoint.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toNorthPoint.DropDownWidth = 150;
            this.toNorthPoint.FormattingEnabled = true;
            this.toNorthPoint.IntegralHeight = false;
            this.toNorthPoint.Location = new System.Drawing.Point(-2, -2);
            this.toNorthPoint.Name = "toNorthPoint";
            this.toNorthPoint.Size = new System.Drawing.Size(113, 21);
            this.toNorthPoint.TabIndex = 400;
            this.toNorthPoint.SelectedIndexChanged += new System.EventHandler(this.toNorthPoint_SelectedIndexChanged);
            // 
            // panel78
            // 
            this.panel78.Controls.Add(this.panel34);
            this.panel78.Location = new System.Drawing.Point(6, 470);
            this.panel78.Name = "panel78";
            this.panel78.Size = new System.Drawing.Size(260, 76);
            this.panel78.TabIndex = 544;
            // 
            // panel34
            // 
            this.panel34.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.panel34.Controls.Add(this.label37);
            this.panel34.Controls.Add(this.leadToMapPoint);
            this.panel34.Controls.Add(this.label55);
            this.panel34.Controls.Add(this.label56);
            this.panel34.Controls.Add(this.whichPointCheckAddress);
            this.panel34.Controls.Add(this.whichPointCheckBit);
            this.panel34.Controls.Add(this.label52);
            this.panel34.Controls.Add(this.panel17);
            this.panel34.Controls.Add(this.panel27);
            this.panel34.Location = new System.Drawing.Point(2, 2);
            this.panel34.Name = "panel34";
            this.panel34.Size = new System.Drawing.Size(256, 72);
            this.panel34.TabIndex = 81;
            // 
            // label37
            // 
            this.label37.BackColor = System.Drawing.SystemColors.Control;
            this.label37.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label37.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label37.Location = new System.Drawing.Point(0, 0);
            this.label37.Name = "label37";
            this.label37.Padding = new System.Windows.Forms.Padding(2, 2, 0, 0);
            this.label37.Size = new System.Drawing.Size(129, 17);
            this.label37.TabIndex = 478;
            this.label37.Text = "DESTINATION";
            // 
            // leadToMapPoint
            // 
            this.leadToMapPoint.Appearance = System.Windows.Forms.Appearance.Button;
            this.leadToMapPoint.BackColor = System.Drawing.SystemColors.Control;
            this.leadToMapPoint.FlatAppearance.BorderSize = 0;
            this.leadToMapPoint.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(168)))), ((int)(((byte)(168)))));
            this.leadToMapPoint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.leadToMapPoint.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.leadToMapPoint.Location = new System.Drawing.Point(130, 0);
            this.leadToMapPoint.Name = "leadToMapPoint";
            this.leadToMapPoint.Size = new System.Drawing.Size(126, 17);
            this.leadToMapPoint.TabIndex = 81;
            this.leadToMapPoint.Text = "MAP POINT";
            this.leadToMapPoint.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.leadToMapPoint.UseCompatibleTextRendering = true;
            this.leadToMapPoint.UseVisualStyleBackColor = false;
            this.leadToMapPoint.CheckedChanged += new System.EventHandler(this.leadToMapPoint_CheckedChanged);
            // 
            // label55
            // 
            this.label55.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label55.Location = new System.Drawing.Point(0, 37);
            this.label55.Name = "label55";
            this.label55.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label55.Size = new System.Drawing.Size(129, 17);
            this.label55.TabIndex = 490;
            this.label55.Text = "lead to destination";
            // 
            // label56
            // 
            this.label56.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label56.Location = new System.Drawing.Point(0, 55);
            this.label56.Name = "label56";
            this.label56.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label56.Size = new System.Drawing.Size(129, 17);
            this.label56.TabIndex = 489;
            this.label56.Text = "else lead to destination";
            // 
            // whichPointCheckAddress
            // 
            this.whichPointCheckAddress.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.whichPointCheckAddress.Hexadecimal = true;
            this.whichPointCheckAddress.Location = new System.Drawing.Point(130, 19);
            this.whichPointCheckAddress.Maximum = new decimal(new int[] {
            36932,
            0,
            0,
            0});
            this.whichPointCheckAddress.Minimum = new decimal(new int[] {
            28741,
            0,
            0,
            0});
            this.whichPointCheckAddress.Name = "whichPointCheckAddress";
            this.whichPointCheckAddress.Size = new System.Drawing.Size(74, 17);
            this.whichPointCheckAddress.TabIndex = 82;
            this.whichPointCheckAddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.whichPointCheckAddress.Value = new decimal(new int[] {
            28741,
            0,
            0,
            0});
            this.whichPointCheckAddress.ValueChanged += new System.EventHandler(this.whichPointCheckAddress_ValueChanged);
            // 
            // whichPointCheckBit
            // 
            this.whichPointCheckBit.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.whichPointCheckBit.Location = new System.Drawing.Point(205, 19);
            this.whichPointCheckBit.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.whichPointCheckBit.Name = "whichPointCheckBit";
            this.whichPointCheckBit.Size = new System.Drawing.Size(52, 17);
            this.whichPointCheckBit.TabIndex = 83;
            this.whichPointCheckBit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.whichPointCheckBit.ValueChanged += new System.EventHandler(this.whichPointCheckBit_ValueChanged);
            // 
            // label52
            // 
            this.label52.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label52.Location = new System.Drawing.Point(0, 19);
            this.label52.Name = "label52";
            this.label52.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label52.Size = new System.Drawing.Size(129, 17);
            this.label52.TabIndex = 502;
            this.label52.Text = "If memory bit set";
            // 
            // panel17
            // 
            this.panel17.Controls.Add(this.runEventEdit);
            this.panel17.Controls.Add(this.runEvent);
            this.panel17.Controls.Add(this.goMapPointA);
            this.panel17.Location = new System.Drawing.Point(130, 37);
            this.panel17.Name = "panel17";
            this.panel17.Size = new System.Drawing.Size(127, 17);
            this.panel17.TabIndex = 84;
            // 
            // runEventEdit
            // 
            this.runEventEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.runEventEdit.BackColor = System.Drawing.Color.Lime;
            this.runEventEdit.FlatAppearance.BorderSize = 0;
            this.runEventEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.runEventEdit.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.runEventEdit.Location = new System.Drawing.Point(74, 0);
            this.runEventEdit.Name = "runEventEdit";
            this.runEventEdit.Size = new System.Drawing.Size(52, 17);
            this.runEventEdit.TabIndex = 556;
            this.runEventEdit.Text = "Edit...";
            this.runEventEdit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.runEventEdit.UseCompatibleTextRendering = true;
            this.runEventEdit.UseVisualStyleBackColor = false;
            this.runEventEdit.Click += new System.EventHandler(this.runEventEdit_Click);
            // 
            // runEvent
            // 
            this.runEvent.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.runEvent.Location = new System.Drawing.Point(0, 0);
            this.runEvent.Maximum = new decimal(new int[] {
            4095,
            0,
            0,
            0});
            this.runEvent.Name = "runEvent";
            this.runEvent.Size = new System.Drawing.Size(74, 17);
            this.runEvent.TabIndex = 401;
            this.runEvent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.runEvent.ValueChanged += new System.EventHandler(this.runEvent_ValueChanged);
            // 
            // goMapPointA
            // 
            this.goMapPointA.DropDownHeight = 340;
            this.goMapPointA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.goMapPointA.DropDownWidth = 150;
            this.goMapPointA.FormattingEnabled = true;
            this.goMapPointA.IntegralHeight = false;
            this.goMapPointA.Location = new System.Drawing.Point(-2, -2);
            this.goMapPointA.Name = "goMapPointA";
            this.goMapPointA.Size = new System.Drawing.Size(131, 21);
            this.goMapPointA.TabIndex = 400;
            this.goMapPointA.SelectedIndexChanged += new System.EventHandler(this.goMapPointA_SelectedIndexChanged);
            // 
            // panel27
            // 
            this.panel27.Controls.Add(this.goMapPointB);
            this.panel27.Location = new System.Drawing.Point(130, 55);
            this.panel27.Name = "panel27";
            this.panel27.Size = new System.Drawing.Size(127, 17);
            this.panel27.TabIndex = 85;
            // 
            // goMapPointB
            // 
            this.goMapPointB.DropDownHeight = 340;
            this.goMapPointB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.goMapPointB.DropDownWidth = 150;
            this.goMapPointB.FormattingEnabled = true;
            this.goMapPointB.IntegralHeight = false;
            this.goMapPointB.Items.AddRange(new object[] {
            "Menu",
            "Overworld Dialogue",
            "Menu Descriptions"});
            this.goMapPointB.Location = new System.Drawing.Point(-2, -2);
            this.goMapPointB.Name = "goMapPointB";
            this.goMapPointB.Size = new System.Drawing.Size(131, 21);
            this.goMapPointB.TabIndex = 400;
            this.goMapPointB.SelectedIndexChanged += new System.EventHandler(this.goMapPointB_SelectedIndexChanged);
            // 
            // panel48
            // 
            this.panel48.Controls.Add(this.label39);
            this.panel48.Controls.Add(this.panel26);
            this.panel48.Location = new System.Drawing.Point(6, 6);
            this.panel48.Name = "panel48";
            this.panel48.Size = new System.Drawing.Size(260, 334);
            this.panel48.TabIndex = 524;
            // 
            // label39
            // 
            this.label39.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label39.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label39.ForeColor = System.Drawing.SystemColors.Control;
            this.label39.Location = new System.Drawing.Point(2, 2);
            this.label39.Name = "label39";
            this.label39.Padding = new System.Windows.Forms.Padding(2, 2, 0, 0);
            this.label39.Size = new System.Drawing.Size(256, 17);
            this.label39.TabIndex = 376;
            this.label39.Text = "WORLD MAPS";
            // 
            // panel26
            // 
            this.panel26.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.panel26.Controls.Add(this.showMapPoints);
            this.panel26.Controls.Add(this.panel40);
            this.panel26.Controls.Add(this.label40);
            this.panel26.Controls.Add(this.worldMapNum);
            this.panel26.Controls.Add(this.worldMapYCoord);
            this.panel26.Controls.Add(this.worldMapTileset);
            this.panel26.Controls.Add(this.worldMapXCoord);
            this.panel26.Controls.Add(this.pointCount);
            this.panel26.Controls.Add(this.label47);
            this.panel26.Controls.Add(this.label12);
            this.panel26.Controls.Add(this.label21);
            this.panel26.Controls.Add(this.label46);
            this.panel26.Location = new System.Drawing.Point(2, 21);
            this.panel26.Name = "panel26";
            this.panel26.Size = new System.Drawing.Size(256, 311);
            this.panel26.TabIndex = 69;
            // 
            // showMapPoints
            // 
            this.showMapPoints.Appearance = System.Windows.Forms.Appearance.Button;
            this.showMapPoints.BackColor = System.Drawing.SystemColors.Control;
            this.showMapPoints.Checked = true;
            this.showMapPoints.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showMapPoints.FlatAppearance.BorderSize = 0;
            this.showMapPoints.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(168)))), ((int)(((byte)(168)))));
            this.showMapPoints.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.showMapPoints.Location = new System.Drawing.Point(129, 0);
            this.showMapPoints.Name = "showMapPoints";
            this.showMapPoints.Size = new System.Drawing.Size(127, 17);
            this.showMapPoints.TabIndex = 512;
            this.showMapPoints.Text = "SHOW MAP POINTS";
            this.showMapPoints.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.showMapPoints.UseCompatibleTextRendering = true;
            this.showMapPoints.UseVisualStyleBackColor = false;
            this.showMapPoints.Click += new System.EventHandler(this.showMapPoints_Click);
            // 
            // panel40
            // 
            this.panel40.BackColor = System.Drawing.SystemColors.Control;
            this.panel40.Controls.Add(this.pictureBoxWorldMap);
            this.panel40.Location = new System.Drawing.Point(0, 19);
            this.panel40.Name = "panel40";
            this.panel40.Size = new System.Drawing.Size(256, 256);
            this.panel40.TabIndex = 511;
            // 
            // pictureBoxWorldMap
            // 
            this.pictureBoxWorldMap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.pictureBoxWorldMap.ContextMenuStrip = this.contextMenuStrip;
            this.pictureBoxWorldMap.Cursor = System.Windows.Forms.Cursors.Cross;
            this.pictureBoxWorldMap.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxWorldMap.Name = "pictureBoxWorldMap";
            this.pictureBoxWorldMap.Size = new System.Drawing.Size(256, 256);
            this.pictureBoxWorldMap.TabIndex = 447;
            this.pictureBoxWorldMap.TabStop = false;
            this.pictureBoxWorldMap.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.pictureBoxWorldMap_PreviewKeyDown);
            this.pictureBoxWorldMap.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxWorldMap_MouseMove);
            this.pictureBoxWorldMap.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBoxWorldMap_MouseClick);
            this.pictureBoxWorldMap.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxWorldMap_MouseDown);
            this.pictureBoxWorldMap.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxWorldMap_Paint);
            // 
            // label40
            // 
            this.label40.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label40.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label40.ForeColor = System.Drawing.SystemColors.Control;
            this.label40.Location = new System.Drawing.Point(0, 0);
            this.label40.Name = "label40";
            this.label40.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label40.Size = new System.Drawing.Size(60, 17);
            this.label40.TabIndex = 474;
            this.label40.Text = "MAP #";
            // 
            // worldMapNum
            // 
            this.worldMapNum.BackColor = System.Drawing.SystemColors.ControlDark;
            this.worldMapNum.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.worldMapNum.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.worldMapNum.ForeColor = System.Drawing.SystemColors.Control;
            this.worldMapNum.Location = new System.Drawing.Point(61, 0);
            this.worldMapNum.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.worldMapNum.Name = "worldMapNum";
            this.worldMapNum.Size = new System.Drawing.Size(67, 17);
            this.worldMapNum.TabIndex = 69;
            this.worldMapNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.worldMapNum.ValueChanged += new System.EventHandler(this.worldMapNum_ValueChanged);
            // 
            // worldMapYCoord
            // 
            this.worldMapYCoord.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.worldMapYCoord.Location = new System.Drawing.Point(189, 294);
            this.worldMapYCoord.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.worldMapYCoord.Name = "worldMapYCoord";
            this.worldMapYCoord.Size = new System.Drawing.Size(68, 17);
            this.worldMapYCoord.TabIndex = 73;
            this.worldMapYCoord.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.worldMapYCoord.ValueChanged += new System.EventHandler(this.worldMapYCoord_ValueChanged);
            // 
            // worldMapTileset
            // 
            this.worldMapTileset.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.worldMapTileset.Location = new System.Drawing.Point(61, 294);
            this.worldMapTileset.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.worldMapTileset.Name = "worldMapTileset";
            this.worldMapTileset.Size = new System.Drawing.Size(67, 17);
            this.worldMapTileset.TabIndex = 72;
            this.worldMapTileset.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.worldMapTileset.ValueChanged += new System.EventHandler(this.worldMapTileset_ValueChanged);
            // 
            // worldMapXCoord
            // 
            this.worldMapXCoord.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.worldMapXCoord.Location = new System.Drawing.Point(189, 276);
            this.worldMapXCoord.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.worldMapXCoord.Name = "worldMapXCoord";
            this.worldMapXCoord.Size = new System.Drawing.Size(68, 17);
            this.worldMapXCoord.TabIndex = 71;
            this.worldMapXCoord.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.worldMapXCoord.ValueChanged += new System.EventHandler(this.worldMapXCoord_ValueChanged);
            // 
            // pointCount
            // 
            this.pointCount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.pointCount.Location = new System.Drawing.Point(61, 276);
            this.pointCount.Maximum = new decimal(new int[] {
            56,
            0,
            0,
            0});
            this.pointCount.Name = "pointCount";
            this.pointCount.Size = new System.Drawing.Size(67, 17);
            this.pointCount.TabIndex = 70;
            this.pointCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.pointCount.ValueChanged += new System.EventHandler(this.pointCount_ValueChanged);
            // 
            // label47
            // 
            this.label47.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label47.Location = new System.Drawing.Point(129, 294);
            this.label47.Name = "label47";
            this.label47.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label47.Size = new System.Drawing.Size(59, 17);
            this.label47.TabIndex = 471;
            this.label47.Text = "Vertical";
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label12.Location = new System.Drawing.Point(0, 294);
            this.label12.Name = "label12";
            this.label12.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label12.Size = new System.Drawing.Size(60, 17);
            this.label12.TabIndex = 471;
            this.label12.Text = "Tileset";
            // 
            // label21
            // 
            this.label21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label21.Location = new System.Drawing.Point(129, 276);
            this.label21.Name = "label21";
            this.label21.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label21.Size = new System.Drawing.Size(59, 17);
            this.label21.TabIndex = 471;
            this.label21.Text = "Horizontal";
            // 
            // label46
            // 
            this.label46.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label46.Location = new System.Drawing.Point(0, 276);
            this.label46.Name = "label46";
            this.label46.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label46.Size = new System.Drawing.Size(60, 17);
            this.label46.TabIndex = 471;
            this.label46.Text = "Points";
            // 
            // panel214
            // 
            this.panel214.Controls.Add(this.panel215);
            this.panel214.Location = new System.Drawing.Point(272, 575);
            this.panel214.Name = "panel214";
            this.panel214.Size = new System.Drawing.Size(260, 73);
            this.panel214.TabIndex = 542;
            // 
            // panel215
            // 
            this.panel215.BackColor = System.Drawing.SystemColors.Control;
            this.panel215.Location = new System.Drawing.Point(2, 2);
            this.panel215.Name = "panel215";
            this.panel215.Size = new System.Drawing.Size(256, 69);
            this.panel215.TabIndex = 540;
            // 
            // panel51
            // 
            this.panel51.Controls.Add(this.label36);
            this.panel51.Controls.Add(this.panel50);
            this.panel51.Location = new System.Drawing.Point(272, 346);
            this.panel51.Name = "panel51";
            this.panel51.Size = new System.Drawing.Size(260, 223);
            this.panel51.TabIndex = 529;
            // 
            // label36
            // 
            this.label36.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label36.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label36.ForeColor = System.Drawing.SystemColors.Control;
            this.label36.Location = new System.Drawing.Point(2, 2);
            this.label36.Name = "label36";
            this.label36.Padding = new System.Windows.Forms.Padding(2, 2, 0, 0);
            this.label36.Size = new System.Drawing.Size(256, 17);
            this.label36.TabIndex = 480;
            this.label36.Text = "WORLD MAP PALETTES";
            // 
            // panel50
            // 
            this.panel50.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.panel50.Controls.Add(this.label66);
            this.panel50.Controls.Add(this.wmPaletteRedBar);
            this.panel50.Controls.Add(this.wmPaletteGreenNum);
            this.panel50.Controls.Add(this.label65);
            this.panel50.Controls.Add(this.wmPaletteBlueBar);
            this.panel50.Controls.Add(this.label64);
            this.panel50.Controls.Add(this.pictureBoxWMPaletteColor);
            this.panel50.Controls.Add(this.wmPaletteGreenBar);
            this.panel50.Controls.Add(this.pictureBoxWMPalette);
            this.panel50.Controls.Add(this.wmPaletteRedNum);
            this.panel50.Controls.Add(this.label38);
            this.panel50.Controls.Add(this.wmPaletteColor);
            this.panel50.Controls.Add(this.wmPaletteBlueNum);
            this.panel50.Location = new System.Drawing.Point(2, 21);
            this.panel50.Name = "panel50";
            this.panel50.Size = new System.Drawing.Size(256, 200);
            this.panel50.TabIndex = 522;
            // 
            // label66
            // 
            this.label66.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label66.Location = new System.Drawing.Point(0, 183);
            this.label66.Name = "label66";
            this.label66.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label66.Size = new System.Drawing.Size(46, 17);
            this.label66.TabIndex = 493;
            this.label66.Text = "Blue";
            // 
            // wmPaletteRedBar
            // 
            this.wmPaletteRedBar.AutoSize = false;
            this.wmPaletteRedBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.wmPaletteRedBar.LargeChange = 32;
            this.wmPaletteRedBar.Location = new System.Drawing.Point(98, 147);
            this.wmPaletteRedBar.Maximum = 248;
            this.wmPaletteRedBar.Name = "wmPaletteRedBar";
            this.wmPaletteRedBar.Size = new System.Drawing.Size(158, 17);
            this.wmPaletteRedBar.SmallChange = 8;
            this.wmPaletteRedBar.TabIndex = 106;
            this.wmPaletteRedBar.TickFrequency = 8;
            this.wmPaletteRedBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.wmPaletteRedBar.Scroll += new System.EventHandler(this.wmPaletteRedBar_Scroll);
            // 
            // wmPaletteGreenNum
            // 
            this.wmPaletteGreenNum.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.wmPaletteGreenNum.Increment = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.wmPaletteGreenNum.Location = new System.Drawing.Point(47, 165);
            this.wmPaletteGreenNum.Maximum = new decimal(new int[] {
            248,
            0,
            0,
            0});
            this.wmPaletteGreenNum.Name = "wmPaletteGreenNum";
            this.wmPaletteGreenNum.Size = new System.Drawing.Size(50, 17);
            this.wmPaletteGreenNum.TabIndex = 104;
            this.wmPaletteGreenNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.wmPaletteGreenNum.ValueChanged += new System.EventHandler(this.wmPaletteGreenNum_ValueChanged);
            // 
            // label65
            // 
            this.label65.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label65.Location = new System.Drawing.Point(0, 147);
            this.label65.Name = "label65";
            this.label65.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label65.Size = new System.Drawing.Size(46, 17);
            this.label65.TabIndex = 489;
            this.label65.Text = "Red";
            // 
            // wmPaletteBlueBar
            // 
            this.wmPaletteBlueBar.AutoSize = false;
            this.wmPaletteBlueBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.wmPaletteBlueBar.LargeChange = 32;
            this.wmPaletteBlueBar.Location = new System.Drawing.Point(98, 183);
            this.wmPaletteBlueBar.Maximum = 248;
            this.wmPaletteBlueBar.Name = "wmPaletteBlueBar";
            this.wmPaletteBlueBar.Size = new System.Drawing.Size(158, 17);
            this.wmPaletteBlueBar.SmallChange = 8;
            this.wmPaletteBlueBar.TabIndex = 108;
            this.wmPaletteBlueBar.TickFrequency = 8;
            this.wmPaletteBlueBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.wmPaletteBlueBar.Scroll += new System.EventHandler(this.wmPaletteBlueBar_Scroll);
            // 
            // label64
            // 
            this.label64.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label64.Location = new System.Drawing.Point(0, 129);
            this.label64.Name = "label64";
            this.label64.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label64.Size = new System.Drawing.Size(46, 17);
            this.label64.TabIndex = 488;
            this.label64.Text = "Color";
            // 
            // pictureBoxWMPaletteColor
            // 
            this.pictureBoxWMPaletteColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.pictureBoxWMPaletteColor.Location = new System.Drawing.Point(98, 129);
            this.pictureBoxWMPaletteColor.Name = "pictureBoxWMPaletteColor";
            this.pictureBoxWMPaletteColor.Size = new System.Drawing.Size(158, 17);
            this.pictureBoxWMPaletteColor.TabIndex = 484;
            this.pictureBoxWMPaletteColor.TabStop = false;
            // 
            // wmPaletteGreenBar
            // 
            this.wmPaletteGreenBar.AutoSize = false;
            this.wmPaletteGreenBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.wmPaletteGreenBar.LargeChange = 32;
            this.wmPaletteGreenBar.Location = new System.Drawing.Point(98, 165);
            this.wmPaletteGreenBar.Maximum = 248;
            this.wmPaletteGreenBar.Name = "wmPaletteGreenBar";
            this.wmPaletteGreenBar.Size = new System.Drawing.Size(158, 17);
            this.wmPaletteGreenBar.SmallChange = 8;
            this.wmPaletteGreenBar.TabIndex = 107;
            this.wmPaletteGreenBar.TickFrequency = 8;
            this.wmPaletteGreenBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.wmPaletteGreenBar.Scroll += new System.EventHandler(this.wmPaletteGreenBar_Scroll);
            // 
            // pictureBoxWMPalette
            // 
            this.pictureBoxWMPalette.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.pictureBoxWMPalette.ContextMenuStrip = this.contextMenuStrip3;
            this.pictureBoxWMPalette.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxWMPalette.Name = "pictureBoxWMPalette";
            this.pictureBoxWMPalette.Size = new System.Drawing.Size(256, 128);
            this.pictureBoxWMPalette.TabIndex = 485;
            this.pictureBoxWMPalette.TabStop = false;
            this.pictureBoxWMPalette.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBoxWMPalette_MouseClick);
            this.pictureBoxWMPalette.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxWMPalette_Paint);
            // 
            // wmPaletteRedNum
            // 
            this.wmPaletteRedNum.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.wmPaletteRedNum.Increment = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.wmPaletteRedNum.Location = new System.Drawing.Point(47, 147);
            this.wmPaletteRedNum.Maximum = new decimal(new int[] {
            248,
            0,
            0,
            0});
            this.wmPaletteRedNum.Name = "wmPaletteRedNum";
            this.wmPaletteRedNum.Size = new System.Drawing.Size(50, 17);
            this.wmPaletteRedNum.TabIndex = 103;
            this.wmPaletteRedNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.wmPaletteRedNum.ValueChanged += new System.EventHandler(this.wmPaletteRedNum_ValueChanged);
            // 
            // label38
            // 
            this.label38.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label38.Location = new System.Drawing.Point(0, 165);
            this.label38.Name = "label38";
            this.label38.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label38.Size = new System.Drawing.Size(46, 17);
            this.label38.TabIndex = 491;
            this.label38.Text = "Green";
            // 
            // wmPaletteColor
            // 
            this.wmPaletteColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.wmPaletteColor.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.wmPaletteColor.Location = new System.Drawing.Point(47, 129);
            this.wmPaletteColor.Maximum = new decimal(new int[] {
            127,
            0,
            0,
            0});
            this.wmPaletteColor.Name = "wmPaletteColor";
            this.wmPaletteColor.Size = new System.Drawing.Size(50, 17);
            this.wmPaletteColor.TabIndex = 102;
            this.wmPaletteColor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.wmPaletteColor.ValueChanged += new System.EventHandler(this.wmPaletteColor_ValueChanged);
            // 
            // wmPaletteBlueNum
            // 
            this.wmPaletteBlueNum.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.wmPaletteBlueNum.Increment = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.wmPaletteBlueNum.Location = new System.Drawing.Point(47, 183);
            this.wmPaletteBlueNum.Maximum = new decimal(new int[] {
            248,
            0,
            0,
            0});
            this.wmPaletteBlueNum.Name = "wmPaletteBlueNum";
            this.wmPaletteBlueNum.Size = new System.Drawing.Size(50, 17);
            this.wmPaletteBlueNum.TabIndex = 105;
            this.wmPaletteBlueNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.wmPaletteBlueNum.ValueChanged += new System.EventHandler(this.wmPaletteBlueNum_ValueChanged);
            // 
            // panel49
            // 
            this.panel49.Controls.Add(this.label43);
            this.panel49.Controls.Add(this.panel14);
            this.panel49.Location = new System.Drawing.Point(6, 346);
            this.panel49.Name = "panel49";
            this.panel49.Size = new System.Drawing.Size(260, 116);
            this.panel49.TabIndex = 530;
            // 
            // label43
            // 
            this.label43.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label43.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label43.ForeColor = System.Drawing.SystemColors.Control;
            this.label43.Location = new System.Drawing.Point(2, 2);
            this.label43.Name = "label43";
            this.label43.Padding = new System.Windows.Forms.Padding(2, 2, 0, 0);
            this.label43.Size = new System.Drawing.Size(256, 17);
            this.label43.TabIndex = 479;
            this.label43.Text = "MAP POINTS";
            // 
            // panel14
            // 
            this.panel14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.panel14.Controls.Add(this.panel81);
            this.panel14.Controls.Add(this.panel64);
            this.panel14.Controls.Add(this.mapPointYCoord);
            this.panel14.Controls.Add(this.LabelMonsterName);
            this.panel14.Controls.Add(this.label48);
            this.panel14.Controls.Add(this.panel16);
            this.panel14.Controls.Add(this.label45);
            this.panel14.Controls.Add(this.label44);
            this.panel14.Controls.Add(this.mapPointNum);
            this.panel14.Controls.Add(this.mapPointXCoord);
            this.panel14.Location = new System.Drawing.Point(2, 21);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(256, 93);
            this.panel14.TabIndex = 74;
            // 
            // panel81
            // 
            this.panel81.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.panel81.Controls.Add(this.label50);
            this.panel81.Controls.Add(this.label49);
            this.panel81.Controls.Add(this.label59);
            this.panel81.Controls.Add(this.showCheckAddress);
            this.panel81.Controls.Add(this.label58);
            this.panel81.Controls.Add(this.showCheckBit);
            this.panel81.Location = new System.Drawing.Point(0, 57);
            this.panel81.Name = "panel81";
            this.panel81.Size = new System.Drawing.Size(256, 36);
            this.panel81.TabIndex = 545;
            // 
            // label50
            // 
            this.label50.BackColor = System.Drawing.SystemColors.Control;
            this.label50.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label50.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label50.Location = new System.Drawing.Point(0, 0);
            this.label50.Name = "label50";
            this.label50.Padding = new System.Windows.Forms.Padding(2, 2, 0, 0);
            this.label50.Size = new System.Drawing.Size(130, 17);
            this.label50.TabIndex = 521;
            this.label50.Text = "SHOW POINT";
            // 
            // label49
            // 
            this.label49.BackColor = System.Drawing.SystemColors.Control;
            this.label49.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label49.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label49.Location = new System.Drawing.Point(205, 0);
            this.label49.Name = "label49";
            this.label49.Padding = new System.Windows.Forms.Padding(2, 2, 0, 0);
            this.label49.Size = new System.Drawing.Size(51, 17);
            this.label49.TabIndex = 523;
            this.label49.Text = "BIT SET";
            // 
            // label59
            // 
            this.label59.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label59.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label59.Location = new System.Drawing.Point(0, 19);
            this.label59.Name = "label59";
            this.label59.Padding = new System.Windows.Forms.Padding(2, 2, 0, 0);
            this.label59.Size = new System.Drawing.Size(129, 17);
            this.label59.TabIndex = 521;
            // 
            // showCheckAddress
            // 
            this.showCheckAddress.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.showCheckAddress.Hexadecimal = true;
            this.showCheckAddress.Location = new System.Drawing.Point(130, 19);
            this.showCheckAddress.Maximum = new decimal(new int[] {
            28868,
            0,
            0,
            0});
            this.showCheckAddress.Minimum = new decimal(new int[] {
            28741,
            0,
            0,
            0});
            this.showCheckAddress.Name = "showCheckAddress";
            this.showCheckAddress.Size = new System.Drawing.Size(74, 17);
            this.showCheckAddress.TabIndex = 79;
            this.showCheckAddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.showCheckAddress.Value = new decimal(new int[] {
            28741,
            0,
            0,
            0});
            this.showCheckAddress.ValueChanged += new System.EventHandler(this.showCheckAddress_ValueChanged);
            // 
            // label58
            // 
            this.label58.BackColor = System.Drawing.SystemColors.Control;
            this.label58.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label58.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label58.Location = new System.Drawing.Point(130, 0);
            this.label58.Name = "label58";
            this.label58.Padding = new System.Windows.Forms.Padding(2, 2, 0, 0);
            this.label58.Size = new System.Drawing.Size(74, 17);
            this.label58.TabIndex = 522;
            this.label58.Text = "IF MEMORY";
            // 
            // showCheckBit
            // 
            this.showCheckBit.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.showCheckBit.Location = new System.Drawing.Point(205, 19);
            this.showCheckBit.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.showCheckBit.Name = "showCheckBit";
            this.showCheckBit.Size = new System.Drawing.Size(52, 17);
            this.showCheckBit.TabIndex = 80;
            this.showCheckBit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.showCheckBit.ValueChanged += new System.EventHandler(this.showCheckBit_ValueChanged);
            // 
            // panel64
            // 
            this.panel64.BackColor = System.Drawing.SystemColors.Window;
            this.panel64.Controls.Add(this.textBoxMapPoint);
            this.panel64.Location = new System.Drawing.Point(129, 19);
            this.panel64.Name = "panel64";
            this.panel64.Size = new System.Drawing.Size(127, 17);
            this.panel64.TabIndex = 76;
            // 
            // textBoxMapPoint
            // 
            this.textBoxMapPoint.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxMapPoint.Location = new System.Drawing.Point(4, 2);
            this.textBoxMapPoint.MaxLength = 30;
            this.textBoxMapPoint.Name = "textBoxMapPoint";
            this.textBoxMapPoint.Size = new System.Drawing.Size(119, 14);
            this.textBoxMapPoint.TabIndex = 4;
            this.textBoxMapPoint.TextChanged += new System.EventHandler(this.textBoxMapPoint_TextChanged);
            // 
            // mapPointYCoord
            // 
            this.mapPointYCoord.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.mapPointYCoord.Location = new System.Drawing.Point(205, 38);
            this.mapPointYCoord.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.mapPointYCoord.Name = "mapPointYCoord";
            this.mapPointYCoord.Size = new System.Drawing.Size(52, 17);
            this.mapPointYCoord.TabIndex = 78;
            this.mapPointYCoord.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.mapPointYCoord.ValueChanged += new System.EventHandler(this.mapPointYCoord_ValueChanged);
            // 
            // LabelMonsterName
            // 
            this.LabelMonsterName.BackColor = System.Drawing.SystemColors.Control;
            this.LabelMonsterName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelMonsterName.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.LabelMonsterName.Location = new System.Drawing.Point(0, 19);
            this.LabelMonsterName.Name = "LabelMonsterName";
            this.LabelMonsterName.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.LabelMonsterName.Size = new System.Drawing.Size(128, 17);
            this.LabelMonsterName.TabIndex = 520;
            this.LabelMonsterName.Text = "POINT NAME";
            // 
            // label48
            // 
            this.label48.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label48.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label48.ForeColor = System.Drawing.SystemColors.Control;
            this.label48.Location = new System.Drawing.Point(0, 0);
            this.label48.Name = "label48";
            this.label48.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label48.Size = new System.Drawing.Size(67, 17);
            this.label48.TabIndex = 477;
            this.label48.Text = "POINT #";
            // 
            // panel16
            // 
            this.panel16.Controls.Add(this.mapPointName);
            this.panel16.Location = new System.Drawing.Point(130, 0);
            this.panel16.Name = "panel16";
            this.panel16.Size = new System.Drawing.Size(127, 17);
            this.panel16.TabIndex = 75;
            // 
            // mapPointName
            // 
            this.mapPointName.BackColor = System.Drawing.SystemColors.ControlDark;
            this.mapPointName.DropDownHeight = 366;
            this.mapPointName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mapPointName.DropDownWidth = 158;
            this.mapPointName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mapPointName.ForeColor = System.Drawing.SystemColors.Control;
            this.mapPointName.FormattingEnabled = true;
            this.mapPointName.IntegralHeight = false;
            this.mapPointName.Location = new System.Drawing.Point(-2, -2);
            this.mapPointName.Name = "mapPointName";
            this.mapPointName.Size = new System.Drawing.Size(131, 21);
            this.mapPointName.TabIndex = 400;
            this.mapPointName.SelectedIndexChanged += new System.EventHandler(this.mapPointName_SelectedIndexChanged);
            // 
            // label45
            // 
            this.label45.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label45.Location = new System.Drawing.Point(0, 38);
            this.label45.Name = "label45";
            this.label45.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label45.Size = new System.Drawing.Size(67, 17);
            this.label45.TabIndex = 501;
            this.label45.Text = "X Coord";
            // 
            // label44
            // 
            this.label44.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label44.Location = new System.Drawing.Point(130, 38);
            this.label44.Name = "label44";
            this.label44.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label44.Size = new System.Drawing.Size(74, 17);
            this.label44.TabIndex = 488;
            this.label44.Text = "Y Coord";
            // 
            // mapPointNum
            // 
            this.mapPointNum.BackColor = System.Drawing.SystemColors.ControlDark;
            this.mapPointNum.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.mapPointNum.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mapPointNum.ForeColor = System.Drawing.SystemColors.Control;
            this.mapPointNum.Location = new System.Drawing.Point(68, 0);
            this.mapPointNum.Maximum = new decimal(new int[] {
            55,
            0,
            0,
            0});
            this.mapPointNum.Name = "mapPointNum";
            this.mapPointNum.Size = new System.Drawing.Size(61, 17);
            this.mapPointNum.TabIndex = 74;
            this.mapPointNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.mapPointNum.ValueChanged += new System.EventHandler(this.mapPointNum_ValueChanged);
            // 
            // mapPointXCoord
            // 
            this.mapPointXCoord.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.mapPointXCoord.Location = new System.Drawing.Point(68, 38);
            this.mapPointXCoord.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.mapPointXCoord.Name = "mapPointXCoord";
            this.mapPointXCoord.Size = new System.Drawing.Size(61, 17);
            this.mapPointXCoord.TabIndex = 77;
            this.mapPointXCoord.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.mapPointXCoord.ValueChanged += new System.EventHandler(this.mapPointXCoord_ValueChanged);
            // 
            // panel53
            // 
            this.panel53.Controls.Add(this.panel39);
            this.panel53.Controls.Add(this.label67);
            this.panel53.Location = new System.Drawing.Point(272, 6);
            this.panel53.Name = "panel53";
            this.panel53.Size = new System.Drawing.Size(260, 334);
            this.panel53.TabIndex = 528;
            // 
            // panel39
            // 
            this.panel39.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.panel39.Controls.Add(this.wmShowGrid);
            this.panel39.Controls.Add(this.label78);
            this.panel39.Controls.Add(this.pictureBoxSubtile);
            this.panel39.Controls.Add(this.wmSubtilePalette);
            this.panel39.Controls.Add(this.pictureBoxWMGraphics);
            this.panel39.Controls.Add(this.wmGraphicSet);
            this.panel39.Controls.Add(this.wmSubtile);
            this.panel39.Controls.Add(this.wmSubtileProperties);
            this.panel39.Controls.Add(this.label77);
            this.panel39.Controls.Add(this.pictureBoxTile);
            this.panel39.Controls.Add(this.label69);
            this.panel39.Location = new System.Drawing.Point(2, 21);
            this.panel39.Name = "panel39";
            this.panel39.Size = new System.Drawing.Size(256, 311);
            this.panel39.TabIndex = 109;
            // 
            // wmShowGrid
            // 
            this.wmShowGrid.Appearance = System.Windows.Forms.Appearance.Button;
            this.wmShowGrid.BackColor = System.Drawing.SystemColors.Control;
            this.wmShowGrid.FlatAppearance.BorderSize = 0;
            this.wmShowGrid.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(168)))), ((int)(((byte)(168)))));
            this.wmShowGrid.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.wmShowGrid.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.wmShowGrid.Location = new System.Drawing.Point(0, 0);
            this.wmShowGrid.Name = "wmShowGrid";
            this.wmShowGrid.Size = new System.Drawing.Size(65, 17);
            this.wmShowGrid.TabIndex = 110;
            this.wmShowGrid.Text = "GRID";
            this.wmShowGrid.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.wmShowGrid.UseCompatibleTextRendering = true;
            this.wmShowGrid.UseVisualStyleBackColor = false;
            this.wmShowGrid.CheckedChanged += new System.EventHandler(this.wmShowGrid_CheckedChanged);
            // 
            // label78
            // 
            this.label78.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label78.Location = new System.Drawing.Point(66, 0);
            this.label78.Name = "label78";
            this.label78.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.label78.Size = new System.Drawing.Size(63, 17);
            this.label78.TabIndex = 502;
            this.label78.Text = "Subtile";
            // 
            // pictureBoxSubtile
            // 
            this.pictureBoxSubtile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.pictureBoxSubtile.Location = new System.Drawing.Point(33, 20);
            this.pictureBoxSubtile.Name = "pictureBoxSubtile";
            this.pictureBoxSubtile.Size = new System.Drawing.Size(32, 32);
            this.pictureBoxSubtile.TabIndex = 446;
            this.pictureBoxSubtile.TabStop = false;
            this.pictureBoxSubtile.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxSubtile_Paint);
            // 
            // wmSubtilePalette
            // 
            this.wmSubtilePalette.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.wmSubtilePalette.Location = new System.Drawing.Point(130, 36);
            this.wmSubtilePalette.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.wmSubtilePalette.Name = "wmSubtilePalette";
            this.wmSubtilePalette.Size = new System.Drawing.Size(43, 17);
            this.wmSubtilePalette.TabIndex = 113;
            this.wmSubtilePalette.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.wmSubtilePalette.ValueChanged += new System.EventHandler(this.wmSubtilePalette_ValueChanged);
            // 
            // pictureBoxWMGraphics
            // 
            this.pictureBoxWMGraphics.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.pictureBoxWMGraphics.ContextMenuStrip = this.contextMenuStripGR;
            this.pictureBoxWMGraphics.Location = new System.Drawing.Point(0, 55);
            this.pictureBoxWMGraphics.Name = "pictureBoxWMGraphics";
            this.pictureBoxWMGraphics.Size = new System.Drawing.Size(256, 256);
            this.pictureBoxWMGraphics.TabIndex = 447;
            this.pictureBoxWMGraphics.TabStop = false;
            this.pictureBoxWMGraphics.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxWMGraphics_MouseMove);
            this.pictureBoxWMGraphics.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pictureBoxWMGraphics_MouseDoubleClick);
            this.pictureBoxWMGraphics.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxWMGraphics_Paint);
            // 
            // wmGraphicSet
            // 
            this.wmGraphicSet.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.wmGraphicSet.Location = new System.Drawing.Point(130, 18);
            this.wmGraphicSet.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.wmGraphicSet.Name = "wmGraphicSet";
            this.wmGraphicSet.Size = new System.Drawing.Size(43, 17);
            this.wmGraphicSet.TabIndex = 112;
            this.wmGraphicSet.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.wmGraphicSet.ValueChanged += new System.EventHandler(this.wmGraphicSet_ValueChanged);
            // 
            // wmSubtile
            // 
            this.wmSubtile.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.wmSubtile.Location = new System.Drawing.Point(130, 0);
            this.wmSubtile.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.wmSubtile.Name = "wmSubtile";
            this.wmSubtile.Size = new System.Drawing.Size(43, 17);
            this.wmSubtile.TabIndex = 111;
            this.wmSubtile.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.wmSubtile.ValueChanged += new System.EventHandler(this.wmSubtile_ValueChanged);
            // 
            // wmSubtileProperties
            // 
            this.wmSubtileProperties.BackColor = System.Drawing.SystemColors.Window;
            this.wmSubtileProperties.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.wmSubtileProperties.CheckOnClick = true;
            this.wmSubtileProperties.ColumnWidth = 60;
            this.wmSubtileProperties.IntegralHeight = false;
            this.wmSubtileProperties.Items.AddRange(new object[] {
            "Priority 1",
            "Mirror",
            "Invert"});
            this.wmSubtileProperties.Location = new System.Drawing.Point(174, 0);
            this.wmSubtileProperties.Name = "wmSubtileProperties";
            this.wmSubtileProperties.Size = new System.Drawing.Size(82, 53);
            this.wmSubtileProperties.TabIndex = 114;
            this.wmSubtileProperties.SelectedIndexChanged += new System.EventHandler(this.wmSubtileProperties_SelectedIndexChanged);
            // 
            // label77
            // 
            this.label77.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label77.Location = new System.Drawing.Point(66, 36);
            this.label77.Name = "label77";
            this.label77.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.label77.Size = new System.Drawing.Size(63, 17);
            this.label77.TabIndex = 504;
            this.label77.Text = "Palette";
            // 
            // pictureBoxTile
            // 
            this.pictureBoxTile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.pictureBoxTile.Location = new System.Drawing.Point(0, 20);
            this.pictureBoxTile.Name = "pictureBoxTile";
            this.pictureBoxTile.Size = new System.Drawing.Size(32, 32);
            this.pictureBoxTile.TabIndex = 506;
            this.pictureBoxTile.TabStop = false;
            this.pictureBoxTile.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBoxTile_MouseClick);
            this.pictureBoxTile.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxTile_Paint);
            // 
            // label69
            // 
            this.label69.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label69.Location = new System.Drawing.Point(66, 18);
            this.label69.Name = "label69";
            this.label69.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.label69.Size = new System.Drawing.Size(63, 17);
            this.label69.TabIndex = 505;
            this.label69.Text = "GFX Set";
            // 
            // label67
            // 
            this.label67.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label67.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label67.ForeColor = System.Drawing.SystemColors.Control;
            this.label67.Location = new System.Drawing.Point(2, 2);
            this.label67.Name = "label67";
            this.label67.Padding = new System.Windows.Forms.Padding(2, 2, 0, 0);
            this.label67.Size = new System.Drawing.Size(256, 17);
            this.label67.TabIndex = 480;
            this.label67.Text = "WORLD MAP TILE EDITOR";
            // 
            // tabPage5
            // 
            this.tabPage5.Location = new System.Drawing.Point(175, 4);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(809, 658);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // tabPage6
            // 
            this.tabPage6.Location = new System.Drawing.Point(175, 4);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(809, 658);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // panel55
            // 
            this.panel55.BackColor = System.Drawing.SystemColors.Control;
            this.panel55.Location = new System.Drawing.Point(8, 146);
            this.panel55.Name = "panel55";
            this.panel55.Size = new System.Drawing.Size(166, 55);
            this.panel55.TabIndex = 513;
            // 
            // toolTip1
            // 
            this.toolTip1.Active = false;
            // 
            // PlaybackE_Sequence
            // 
            this.PlaybackE_Sequence.WorkerReportsProgress = true;
            this.PlaybackE_Sequence.WorkerSupportsCancellation = true;
            this.PlaybackE_Sequence.DoWork += new System.ComponentModel.DoWorkEventHandler(this.PlaybackE_Sequence_DoWork);
            this.PlaybackE_Sequence.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.PlaybackE_Sequence_RunWorkerCompleted);
            // 
            // toolTip2
            // 
            this.toolTip2.IsBalloon = true;
            this.toolTip2.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Warning;
            this.toolTip2.ToolTipTitle = "WARNING";
            // 
            // labelToolTip
            // 
            this.labelToolTip.AutoSize = true;
            this.labelToolTip.BackColor = System.Drawing.SystemColors.Info;
            this.labelToolTip.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelToolTip.Location = new System.Drawing.Point(185, 0);
            this.labelToolTip.Name = "labelToolTip";
            this.labelToolTip.Size = new System.Drawing.Size(2, 15);
            this.labelToolTip.TabIndex = 514;
            this.labelToolTip.Visible = false;
            // 
            // labelConvertor
            // 
            this.labelConvertor.AutoSize = true;
            this.labelConvertor.BackColor = System.Drawing.Color.White;
            this.labelConvertor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelConvertor.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelConvertor.Location = new System.Drawing.Point(210, 0);
            this.labelConvertor.Name = "labelConvertor";
            this.labelConvertor.Size = new System.Drawing.Size(2, 15);
            this.labelConvertor.TabIndex = 518;
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
            // Sprites
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 704);
            this.Controls.Add(this.labelConvertor);
            this.Controls.Add(this.labelToolTip);
            this.Controls.Add(this.panel55);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panelColorBalance);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(5, 5);
            this.Name = "Sprites";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "SPRITES - Lazy Shell";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Sprites_FormClosed);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Sprites_FormClosing);
            panel72.ResumeLayout(false);
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            panel2.ResumeLayout(false);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.panelInsertTile.ResumeLayout(false);
            this.panel116.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.insertTileHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.insertTileWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.insertTileAmount)).EndInit();
            this.panel117.ResumeLayout(false);
            this.contextMenuStripCH.ResumeLayout(false);
            this.contextMenuStripGR.ResumeLayout(false);
            this.contextMenuStripSI.ResumeLayout(false);
            this.contextMenuStrip.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.panelDialogues.ResumeLayout(false);
            this.panelSearchDialogue.ResumeLayout(false);
            this.panel82.ResumeLayout(false);
            this.panel76.ResumeLayout(false);
            this.panel76.PerformLayout();
            this.panel77.ResumeLayout(false);
            this.panel65.ResumeLayout(false);
            this.panel66.ResumeLayout(false);
            this.panel47.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.padding)).EndInit();
            this.panel13.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fontSize)).EndInit();
            this.panel70.ResumeLayout(false);
            this.panel32.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.characterHeight)).EndInit();
            this.panel71.ResumeLayout(false);
            this.panel203.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dialogueNum)).EndInit();
            this.contextMenuStrip2.ResumeLayout(false);
            this.panel202.ResumeLayout(false);
            this.panel60.ResumeLayout(false);
            this.panel69.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDialogue)).EndInit();
            this.panel61.ResumeLayout(false);
            this.panelDialogueInsert.ResumeLayout(false);
            this.panelDialogueMemory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dialogueByteValue)).EndInit();
            this.panel201.ResumeLayout(false);
            this.panel62.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBattleDialogue)).EndInit();
            this.panel63.ResumeLayout(false);
            this.panel200.ResumeLayout(false);
            this.panel113.ResumeLayout(false);
            this.panel126.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.battleDialogueNum)).EndInit();
            this.panel59.ResumeLayout(false);
            this.panel58.ResumeLayout(false);
            this.panel12.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDialogueTile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dialogueSubtile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDialogueSubtile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDialogueBG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBattle)).EndInit();
            this.panel9.ResumeLayout(false);
            this.panel30.ResumeLayout(false);
            this.panel114.ResumeLayout(false);
            this.toolStrip7.ResumeLayout(false);
            this.toolStrip7.PerformLayout();
            this.panel112.ResumeLayout(false);
            this.panel112.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFont)).EndInit();
            this.panel25.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFontEditor)).EndInit();
            this.panel15.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fontWidth)).EndInit();
            this.panel46.ResumeLayout(false);
            this.panel23.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFontPalette)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fontPaletteRedBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fontPaletteGreenNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fontPaletteBlueBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fontPaletteRedNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fontPaletteBlueNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fontPaletteGreenBar)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panelColorBalance.ResumeLayout(false);
            this.panel36.ResumeLayout(false);
            this.panel108.ResumeLayout(false);
            this.panel109.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.colEditValueA)).EndInit();
            this.panel110.ResumeLayout(false);
            this.panel111.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panelSprites.ResumeLayout(false);
            this.panelMoldImage.ResumeLayout(false);
            this.panel84.ResumeLayout(false);
            this.toolStrip4.ResumeLayout(false);
            this.toolStrip4.PerformLayout();
            this.panel52.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMold)).EndInit();
            this.panel54.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mapPaletteBlueBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPalette)).EndInit();
            this.contextMenuStrip3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mapPaletteBlueNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mapPaletteColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mapPaletteRedNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mapPaletteGreenBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mapPaletteGreenNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mapPaletteRedBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.paletteOffset)).EndInit();
            this.panel43.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.animationVRAM)).EndInit();
            this.panel8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.animationPacket)).EndInit();
            this.panel29.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.frameMold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.frameDuration)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSequence)).EndInit();
            this.panel42.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel56.ResumeLayout(false);
            this.panel38.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.moldTileCopies)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.moldSubtile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.moldTileYCoord)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.moldTileCopiesOffset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMoldSubtile)).EndInit();
            this.panel10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.moldTileXCoord)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMoldTile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMoldTileset)).EndInit();
            this.panel45.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spriteNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.graphicPalettePacket)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.graphicPalettePacketShift)).EndInit();
            this.panelImageGraphics.ResumeLayout(false);
            this.panelImageGraphicsSub.ResumeLayout(false);
            this.panel31.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.graphicOffset)).EndInit();
            this.panel37.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGraphics)).EndInit();
            this.panelSearchSpriteNames.ResumeLayout(false);
            this.panel28.ResumeLayout(false);
            this.panel28.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.panelEffects.ResumeLayout(false);
            this.panel106.ResumeLayout(false);
            this.panel44.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.effectNum)).EndInit();
            this.panel103.ResumeLayout(false);
            this.panel107.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.e_frameMold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.e_duration)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxE_Sequence)).EndInit();
            this.panel105.ResumeLayout(false);
            this.panel102.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxE_Subtile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxE_Tile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.e_tileSubtile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEffectTileset)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.e_tileSetSize)).EndInit();
            this.panel99.ResumeLayout(false);
            this.panel100.ResumeLayout(false);
            this.toolStrip6.ResumeLayout(false);
            this.toolStrip6.PerformLayout();
            this.panel101.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxE_Mold)).EndInit();
            this.panel90.ResumeLayout(false);
            this.panel91.ResumeLayout(false);
            this.panel94.ResumeLayout(false);
            this.contextMenuStripMD.ResumeLayout(false);
            this.panel95.ResumeLayout(false);
            this.panel92.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.moldFillAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.moldTileIndex)).EndInit();
            this.panel93.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.e_moldHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.e_moldWidth)).EndInit();
            this.panelEffectGraphics.ResumeLayout(false);
            this.panel87.ResumeLayout(false);
            this.panel97.ResumeLayout(false);
            this.panel98.ResumeLayout(false);
            this.panel88.ResumeLayout(false);
            this.toolStrip5.ResumeLayout(false);
            this.toolStrip5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.e_graphicSetSize)).EndInit();
            this.panel89.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxE_Graphics)).EndInit();
            this.panel80.ResumeLayout(false);
            this.panel85.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.e_paletteBlueBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxE_Color)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxE_Palette)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.e_paletteSetSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.e_paletteBlueNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.e_paletteColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.e_paletteRedNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.e_paletteGreenBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.e_paletteGreenNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.e_paletteRedBar)).EndInit();
            this.panel41.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.yNegShift)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xNegShift)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.e_animation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.e_paletteIndex)).EndInit();
            this.panelSearchEffectNames.ResumeLayout(false);
            this.panel86.ResumeLayout(false);
            this.panel86.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.panel57.ResumeLayout(false);
            this.panel79.ResumeLayout(false);
            this.panel35.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.toSouthCheckAddress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toWestCheckAddress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toNorthCheckAddress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toEastCheckAddress)).EndInit();
            this.panel18.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.toEastCheckBit)).EndInit();
            this.panel20.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.toWestCheckBit)).EndInit();
            this.panel19.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.toSouthCheckBit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toNorthCheckBit)).EndInit();
            this.panel21.ResumeLayout(false);
            this.panel78.ResumeLayout(false);
            this.panel34.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.whichPointCheckAddress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.whichPointCheckBit)).EndInit();
            this.panel17.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.runEvent)).EndInit();
            this.panel27.ResumeLayout(false);
            this.panel48.ResumeLayout(false);
            this.panel26.ResumeLayout(false);
            this.panel40.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWorldMap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.worldMapNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.worldMapYCoord)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.worldMapTileset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.worldMapXCoord)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pointCount)).EndInit();
            this.panel214.ResumeLayout(false);
            this.panel51.ResumeLayout(false);
            this.panel50.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.wmPaletteRedBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wmPaletteGreenNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wmPaletteBlueBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWMPaletteColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wmPaletteGreenBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWMPalette)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wmPaletteRedNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wmPaletteColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wmPaletteBlueNum)).EndInit();
            this.panel49.ResumeLayout(false);
            this.panel14.ResumeLayout(false);
            this.panel81.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.showCheckAddress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.showCheckBit)).EndInit();
            this.panel64.ResumeLayout(false);
            this.panel64.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mapPointYCoord)).EndInit();
            this.panel16.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mapPointNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mapPointXCoord)).EndInit();
            this.panel53.ResumeLayout(false);
            this.panel39.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSubtile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wmSubtilePalette)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWMGraphics)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wmGraphicSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wmSubtile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTile)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BackgroundWorker PlaybackSequence;
        private ContextMenuStrip contextMenuStripSI;
        private ToolStripMenuItem saveImageToolStripMenuItem;
        private ContextMenuStrip contextMenuStripGR;
        private ToolStripMenuItem setAsSubtileToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem importToolStripMenuItem;
        private ToolStripMenuItem exportToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem clearToolStripMenuItem1;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripSeparator toolStripSeparator6;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator7;
        private ToolStripMenuItem clearToolStripMenuItem;
        private ToolStripMenuItem allPaletteToolStripMenuItem;
        private ToolStripMenuItem animationsallToolStripMenuItem;
        private ToolStripMenuItem allMapsToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator8;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem allMapPointsToolStripMenuItem;
        private ToolStripMenuItem importToolStripMenuItem1;
        private ToolStripMenuItem allAnimationsToolStripMenuItem;
        private ToolStripMenuItem exportToolStripMenuItem1;
        private ToolStripMenuItem toolStripMenuItem5;
        private ContextMenuStrip contextMenuStripCH;
        private ToolStripMenuItem tsmiZoomInCH;
        private ToolStripMenuItem tsmiZoomOutCH;
        private ToolStripSeparator toolStripSeparator9;
        private ToolStripMenuItem tsmiCutCH;
        private ToolStripMenuItem tsmiCopyCH;
        private ToolStripMenuItem tsmiPasteCH;
        private ToolStripMenuItem tsmiDeleteCH;
        private ContextMenuStrip contextMenuStrip;
        private ToolStripMenuItem cutToolStripMenuItem;
        private ToolStripMenuItem copyToolStripMenuItem;
        private ToolStripMenuItem pasteToolStripMenuItem;
        private ToolStripMenuItem deleteToolStripMenuItem;
        private TabPage tabPage2;
        private Panel panel39;
        private CheckBox wmShowGrid;
        private Label label78;
        private PictureBox pictureBoxSubtile;
        private NumericUpDown wmSubtilePalette;
        private PictureBox pictureBoxWMGraphics;
        private NumericUpDown wmGraphicSet;
        private NumericUpDown wmSubtile;
        private CheckedListBox wmSubtileProperties;
        private Label label77;
        private PictureBox pictureBoxTile;
        private Label label69;
        private TrackBar wmPaletteBlueBar;
        private PictureBox pictureBoxWMPaletteColor;
        private PictureBox pictureBoxWMPalette;
        private Label label38;
        private NumericUpDown wmPaletteBlueNum;
        private NumericUpDown wmPaletteColor;
        private NumericUpDown wmPaletteRedNum;
        private TrackBar wmPaletteGreenBar;
        private Label label64;
        private Label label65;
        private NumericUpDown wmPaletteGreenNum;
        private Label label66;
        private TrackBar wmPaletteRedBar;
        private Label label67;
        private Label label36;
        private Panel panel35;
        private CheckBox enableNorthPath;
        private CheckBox enableWestPath;
        private CheckBox enableSouthPath;
        private CheckBox enableEastPath;
        private Label label51;
        private NumericUpDown toSouthCheckAddress;
        private NumericUpDown toWestCheckAddress;
        private NumericUpDown toNorthCheckAddress;
        private NumericUpDown toEastCheckAddress;
        private Panel panel18;
        private ComboBox toEastPoint;
        private NumericUpDown toEastCheckBit;
        private Panel panel20;
        private ComboBox toWestPoint;
        private NumericUpDown toWestCheckBit;
        private Panel panel19;
        private ComboBox toSouthPoint;
        private NumericUpDown toSouthCheckBit;
        private NumericUpDown toNorthCheckBit;
        private Panel panel21;
        private ComboBox toNorthPoint;
        private Panel panel34;
        private Label label37;
        private CheckBox leadToMapPoint;
        private Label label55;
        private Label label56;
        private NumericUpDown whichPointCheckAddress;
        private NumericUpDown whichPointCheckBit;
        private Label label52;
        private Panel panel17;
        private ComboBox goMapPointA;
        private Panel panel27;
        private ComboBox goMapPointB;
        private Panel panel24;
        private Panel panel22;
        private PictureBox pictureBoxDialogueSubtile;
        private PictureBox pictureBoxDialogueTile;
        private CheckedListBox dialogueProperties;
        private NumericUpDown dialogueSubtile;
        private PictureBox pictureBoxDialogueBG;
        private Label label25;
        private PictureBox pictureBoxBattle;
        private Panel panel30;
        private Panel panel25;
        private PictureBox pictureBoxFontEditor;
        private PictureBox pictureBoxFont;
        private ToolStrip toolStrip2;
        private ToolStripButton fontEditDraw;
        private ToolStripButton fontEditErase;
        private ToolStripButton fontEditChoose;
        private ToolStripButton fontEditZoomIn;
        private ToolStripButton fontEditZoomOut;
        private Label label33;
        private Label label42;
        private Panel panel15;
        private ComboBox fontType;
        private NumericUpDown fontWidth;
        private Panel panel23;
        private Label label35;
        private Label label30;
        private PictureBox pictureBoxFontPalette;
        private TrackBar fontPaletteRedBar;
        private Label label32;
        private NumericUpDown fontPaletteGreenNum;
        private Label label31;
        private TrackBar fontPaletteBlueBar;
        private NumericUpDown fontPaletteRedNum;
        private NumericUpDown fontPaletteBlueNum;
        private Label label29;
        private TrackBar fontPaletteGreenBar;
        private Panel panel1;
        private ComboBox fontPalette;
        private Panel panel14;
        private Panel panel64;
        private TextBox textBoxMapPoint;
        private Label LabelMonsterName;
        private Label label48;
        private Panel panel16;
        private ComboBox mapPointName;
        private Label label44;
        private NumericUpDown mapPointYCoord;
        private NumericUpDown mapPointNum;
        private Label label45;
        private NumericUpDown showCheckBit;
        private NumericUpDown showCheckAddress;
        private NumericUpDown mapPointXCoord;
        private Panel panel26;
        private Panel panel40;
        private PictureBox pictureBoxWorldMap;
        private Label label40;
        private NumericUpDown worldMapNum;
        private NumericUpDown worldMapYCoord;
        private NumericUpDown worldMapTileset;
        private NumericUpDown worldMapXCoord;
        private NumericUpDown pointCount;
        private Label label47;
        private Label label12;
        private Label label21;
        private Label label46;
        private Label label43;
        private Label label39;
        private TabPage tabPage1;
        private Label labelTileOffset;
        private Label animationAvailableBytes;
        private PictureBox pictureBoxGraphics;
        private Panel panel29;
        private ListBox sequenceFrames;
        private Label label8;
        private NumericUpDown frameMold;
        private NumericUpDown frameDuration;
        private Label label16;
        private Label label11;
        private Button frameMoveDown;
        private Button insertFrame;
        private Button deleteFrame;
        private Button frameMoveUp;
        private Panel panel7;
        private Panel panel38;
        private Panel panel31;
        private ToolStrip toolStrip1;
        private ToolStripButton subtileDraw;
        private ToolStripButton subtileErase;
        private ToolStripButton subtileDropper;
        private Label label6;
        private CheckedListBox moldTileProperties;
        private Label label19;
        private Panel panel11;
        private ComboBox moldTileSize;
        private Label label13;
        private Label label20;
        private Label label14;
        private CheckBox quadrantNW;
        private NumericUpDown moldTileCopies;
        private NumericUpDown moldSubtile;
        private NumericUpDown moldTileYCoord;
        private CheckBox quadrantSW;
        private NumericUpDown moldTileCopiesOffset;
        private PictureBox pictureBoxMoldSubtile;
        private Panel panel10;
        private ComboBox comboBox3;
        private CheckBox quadrantNE;
        private NumericUpDown moldTileXCoord;
        private PictureBox pictureBoxMoldTile;
        private CheckBox quadrantSE;
        private PictureBox pictureBoxMoldTileset;
        private ListBox molds;
        private Label label24;
        private Panel panel6;
        private ComboBox moldFormat;
        private Panel panel3;
        private ComboBox comboBox2;
        private Label label15;
        private Button deleteMold;
        private Button insertTile;
        private Button deleteTile;
        private Button insertMold;
        private Label label4;
        private Panel panel8;
        private ListBox sequences;
        private Button insertSequence;
        private Button deleteSequence;
        private Label label22;
        private Panel panel5;
        private Label label88;
        private TrackBar mapPaletteBlueBar;
        private PictureBox pictureBoxColor;
        private PictureBox pictureBoxPalette;
        private Label label80;
        private NumericUpDown mapPaletteBlueNum;
        private NumericUpDown mapPaletteColor;
        private NumericUpDown mapPaletteRedNum;
        private TrackBar mapPaletteGreenBar;
        private Label label17;
        private Label label79;
        private NumericUpDown mapPaletteGreenNum;
        private Label label81;
        private TrackBar mapPaletteRedBar;
        private Label label23;
        private NumericUpDown paletteOffset;
        private Label label9;
        private Label label3;
        private Panel panel4;
        private ComboBox spriteName;
        private NumericUpDown graphicOffset;
        private Label label1;
        private Label label5;
        private Label label18;
        private NumericUpDown animationVRAM;
        private Label label72;
        private NumericUpDown animationPacket;
        private Label label73;
        private Label label71;
        private NumericUpDown graphicPalettePacketShift;
        private NumericUpDown graphicPalettePacket;
        private NumericUpDown spriteNum;
        private Label label10;
        private Button buttonFoward;
        private Button buttonBack;
        private Button buttonStop;
        private Button buttonPlay;
        private PictureBox pictureBoxSequence;
        private TabControl tabControl1;
        private TabPage tabPage3;
        private TabPage tabPage4;
        private TabPage tabPage5;
        private TabPage tabPage6;
        private Label label70;
        private Label label41;
        private Panel panel43;
        private Panel panel42;
        private Panel panel45;
        private Panel panel53;
        private Panel panel51;
        private Panel panel50;
        private Panel panel49;
        private Label label54;
        private Label label26;
        private Label label49;
        private Label label58;
        private Label label59;
        private Label label50;
        private Panel panel48;
        private Panel panel46;
        private Panel panel12;
        private Panel panel54;
        private Panel panel37;
        private Panel panel55;
        private Panel panel214;
        private Panel panel215;
        private Panel panel56;
        private Panel panel33;
        private ToolStripButton graphicShowGrid;
        private ToolStripButton graphicZoomIn;
        private ToolStripButton graphicZoomOut;
        private ToolStripButton fontShowGrid;
        private Panel panel59;
        private Panel panel58;
        private Panel panel9;
        private Panel panel57;
        private Panel panel203;
        private Label label119;
        private NumericUpDown dialogueNum;
        private Panel panel202;
        private Panel panel60;
        private ListBox listBox1;
        private PictureBox pictureBoxDialogue;
        private Button dialoguePreviewPageDown;
        private Label label196;
        private Button dialoguePreviewPageUp;
        private Panel panel61;
        private RichTextBox dialogueTextBox;
        private Panel panel201;
        private Panel panel62;
        private ListBox listBox2;
        private PictureBox pictureBoxBattleDialogue;
        private Button battleDialoguePageUp;
        private Panel panel63;
        private RichTextBox battleDialogueTextBox;
        private Label label187;
        private Button battleDialoguePageDown;
        private Panel panel200;
        private Panel panel126;
        private ComboBox battleDialogueName;
        private NumericUpDown battleDialogueNum;
        private Panel panel65;
        private Panel panel66;
        private Panel panel69;
        private CheckBox byteOrTextView;
        private Label label28;
        private Panel panel70;
        private Label label60;
        private NumericUpDown fontSize;
        private Panel fontTable;
        private ComboBox fontFamily;
        private Button generateFontTableImage;
        private Panel panel71;
        private ToolStrip toolStrip3;
        private ToolStripButton fontBold;
        private ToolStripButton fontItalics;
        private ToolStripButton fontUnderline;
        private Panel panel73;
        private CheckBox autoSetWidths;
        private Panel panel81;
        private Panel panel79;
        private Panel panel78;
        private Panel panel82;
        private Panel panel76;
        private TextBox textBoxSearch;
        private Button searchButton;
        private Panel panel77;
        private RichTextBox searchResults;
        private CheckBox showMapPoints;
        private ToolTip toolTip1;
        private Button shiftTableUp;
        private Button shiftTableDown;
        private Label label61;
        private ToolStripMenuItem saveImageToolStripMenuItem1;
        private Button shiftTableLeft;
        private Button shiftTableRight;
        private Button resetTable;
        private NumericUpDown characterHeight;
        private NumericUpDown padding;
        private Label label76;
        private Label coordsLabel;
        private ToolStripLabel toolStripLabel1;
        private ToolStripSeparator toolStripSeparator10;
        private ToolStripSeparator toolStripSeparator11;
        private ToolStripSeparator toolStripSeparator12;
        private ToolStripButton graphicShowPixelGrid;
        private Panel panel52;
        private Panel panel84;
        private ToolStrip toolStrip4;
        private ToolStripLabel toolStripLabel2;
        private ToolStripSeparator toolStripSeparator13;
        private ToolStripButton moldZoomIn;
        private ToolStripButton moldZoomOut;
        private ToolStripButton showMoldPixelGrid;
        private ToolStripSeparator toolStripSeparator14;
        private Label moldCoordLabel;
        private Panel panelImageGraphics;
        private Label labelImageGraphics;
        private Panel panelSprites;
        private Panel panelImageGraphicsSub;
        private Panel panelMoldImage;
        private Label labelMoldImage;
        private Panel panelDialogues;
        private PictureBox pictureBoxMold;
        private ContextMenuStrip contextMenuStrip3;
        private ToolStripMenuItem importPaletteSetToolStripMenuItem;
        private ToolStripMenuItem exportPaletteSetToolStripMenuItem;
        private Panel panel28;
        private TextBox nameTextBox;
        private ListBox listBoxSpriteNames;
        private Button searchSpriteNames;
        private Panel panelSearchSpriteNames;
        private Label labelSearchDialogue;
        private Panel panelSearchDialogue;
        private ToolStripMenuItem allDialoguesToolStripMenuItem;
        private ToolStripMenuItem allDialoguesToolStripMenuItem1;
        private Panel panelDialogueInsert;
        private Button buttonInsertFD;
        private Label labelDialogueInsert;
        private Panel panelDialogueMemory;
        private ComboBox dialogueMemory;
        private NumericUpDown dialogueByteValue;
        private Panel panel41;
        private Panel panel44;
        private Label label2;
        private Label label7;
        private Label label57;
        private ComboBox effectName;
        private NumericUpDown effectNum;
        private PictureBox pictureBoxEffectTileset;
        private NumericUpDown e_animation;
        private NumericUpDown e_paletteIndex;
        private PictureBox pictureBoxE_Mold;
        private ListBox e_molds;
        private Panel panel88;
        private ToolStrip toolStrip5;
        private ToolStripLabel toolStripLabel3;
        private ToolStripSeparator toolStripSeparator17;
        private ToolStripSeparator toolStripSeparator18;
        private ToolStripSeparator toolStripSeparator19;
        private NumericUpDown e_graphicSetSize;
        private Label label89;
        private Panel panel89;
        private PictureBox pictureBoxE_Graphics;
        private Panel panel80;
        private Panel panel85;
        private Label label63;
        private Label label82;
        private TrackBar e_paletteGreenBar;
        private Label label83;
        private Label label84;
        private Label label85;
        private Panel panel99;
        private Label label103;
        private Label label104;
        private Panel panel100;
        private ToolStrip toolStrip6;
        private ToolStripLabel toolStripLabel4;
        private ToolStripSeparator toolStripSeparator20;
        private ToolStripSeparator toolStripSeparator21;
        private Panel panel101;
        private Panel panel90;
        private Panel panel91;
        private Label label91;
        private Panel panel92;
        private Panel panel93;
        private ComboBox comboBox4;
        private Label label92;
        private Button e_insertMold;
        private Label label93;
        private Panel panel94;
        private Panel panel95;
        private Panel panel96;
        private Label label100;
        private Label label101;
        private Label label102;
        private Label label94;
        private Panel panel97;
        private Panel panel98;
        private ComboBox comboBox6;
        private Label label90;
        private Label label96;
        private Label label97;
        private Panel panel102;
        private Label label98;
        private Panel panel104;
        private Label label99;
        private NumericUpDown yNegShift;
        private NumericUpDown xNegShift;
        private CheckBox moldTileEmpty;
        private CheckedListBox moldTileProp;
        private ComboBox moldTileFormat;
        private NumericUpDown moldTileIndex;
        private Button moldDeleteTile;
        private Button moldInsertTile;
        private Button e_deleteMold;
        private NumericUpDown e_tileSubtile;
        private Panel panel105;
        private ListBox e_tiles;
        private ComboBox e_codec;
        private PictureBox pictureBoxE_Palette;
        private NumericUpDown e_paletteBlueNum;
        private NumericUpDown e_paletteColor;
        private NumericUpDown e_paletteRedNum;
        private NumericUpDown e_paletteGreenNum;
        private TrackBar e_paletteBlueBar;
        private TrackBar e_paletteRedBar;
        private PictureBox pictureBoxE_Tile;
        private Label label105;
        private NumericUpDown e_moldHeight;
        private Label label95;
        private NumericUpDown e_moldWidth;
        private Panel panel103;
        private Label label108;
        private Label label111;
        private Panel panel107;
        private Label label112;
        private Label label113;
        private Label label114;
        private ListBox e_frames;
        private NumericUpDown e_frameMold;
        private NumericUpDown e_duration;
        private Button e_moveFrameDown;
        private Button e_insertFrame;
        private Button e_deleteFrame;
        private Button e_moveFrameUp;
        private Label label106;
        private NumericUpDown moldFillAmount;
        private PictureBox pictureBoxE_Sequence;
        private BackgroundWorker PlaybackE_Sequence;
        private Button e_playSequence;
        private Button e_pauseSequence;
        private Button e_moveBack;
        private Button e_moveFoward;
        private Label label107;
        private Label label109;
        private NumericUpDown e_paletteSetSize;
        private ToolStripButton e_graphicShowGrid;
        private ToolStripButton e_graphicShowPixelGrid;
        private ToolStripButton e_subtileDraw;
        private ToolStripButton e_subtileErase;
        private ToolStripButton e_subtileDropper;
        private ToolStripButton e_graphicZoomIn;
        private ToolStripButton e_graphicZoomOut;
        private Button e_moveTileDown;
        private Button e_moveTileUp;
        private Label label116;
        private Panel panel106;
        private PictureBox pictureBoxE_Color;
        private Label e_availableBytes;
        private ToolStripButton e_moldShowGrid;
        private ToolStripButton e_moldZoomIn;
        private ToolStripButton e_moldZoomOut;
        private PictureBox pictureBoxE_Subtile;
        private Label e_coordsLabel;
        private ToolStripMenuItem allEffectAnimationsToolStripMenuItem;
        private ToolStripMenuItem allEffectAnimationsToolStripMenuItem1;
        private ToolStripMenuItem allEffectsToolStripMenuItem;
        private Label label86;
        private NumericUpDown e_tileSetSize;
        private Label labelEffectGraphics;
        private Panel panelEffectGraphics;
        private Panel panel87;
        private Panel panelEffects;
        private ToolTip toolTip2;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem setMoldTileToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator24;
        private ToolStripSeparator toolStripSeparator26;
        private Label characterNumLabel;
        private ToolStripButton fontEditDelete;
        private ToolStripButton fontEditCopy;
        private ToolStripButton fontEditPaste;
        private ToolStripSeparator toolStripSeparator25;
        private ToolStripSeparator toolStripSeparator27;
        private ToolStripButton fontEditMirror;
        private ToolStripButton fontEditInvert;
        private Label labelToolTip;
        private ToolStripMenuItem enableHelpTipsToolStripMenuItem;
        private Button searchEffectNames;
        private Panel panelSearchEffectNames;
        private ListBox listBoxEffectNames;
        private Panel panel86;
        private TextBox nameTextBoxEffects;
        private ToolStripMenuItem importImageAsTilesetToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator29;
        private Panel panelColorBalance;
        private Button colEditApply;
        private Button colEditReset;
        private Button colEditRedo;
        private Button colEditUndo;
        private Panel panel36;
        private Label label134;
        private Label colEditLabelA;
        private Label colEditLabelB;
        private Panel panel108;
        private ComboBox colEditComboBoxA;
        private Panel panel109;
        private ComboBox colEditComboBoxB;
        private CheckBox colEditBlues;
        private Label colEditLabelC;
        private CheckBox colEditGreens;
        private Label colEditLabelD;
        private CheckBox colEditReds;
        private NumericUpDown colEditValueA;
        private Panel panel110;
        private Label label136;
        private CheckedListBox colEditColors;
        private CheckedListBox colEditRowSelectAll;
        private Button colEditSelectAll;
        private Label label138;
        private Label label143;
        private Button colEditSelectNone;
        private Panel panel111;
        private ComboBox coleditSelectCommand;
        private Label label139;
        private Button colorBalance;
        private Button e_ColorBalance;
        private Label label34;
        private Panel panel112;
        private TextBox charKeystroke;
        private Panel panel47;
        private Panel panel13;
        private Panel panel32;
        private Panel panel113;
        private ComboBox battleDlgType;
        private Panel panel114;
        private ToolStrip toolStrip7;
        private ToolStripButton saveKeystrokes;
        private ToolStripButton openKeystrokes;
        private ContextMenuStrip contextMenuStripMD;
        private ToolStripMenuItem insertTilesToolStripMenuItem;
        private ToolStripMenuItem clearAllTilesToolStripMenuItem;
        private Label label68;
        private Panel panel116;
        private ComboBox insertTileType;
        private NumericUpDown insertTileAmount;
        private Label label87;
        private Panel panel117;
        private ComboBox comboBox5;
        private Button insertTileCancel;
        private Label label110;
        private Button insertTileOK;
        private Panel panelInsertTile;
        private Label label115;
        private NumericUpDown insertTileWidth;
        private NumericUpDown insertTileHeight;
        private Label label117;
        private NumericUpDown runEvent;
        private Button runEventEdit;
        private Label labelConvertor;
        private ToolStripMenuItem showDecHexToolStripMenuItem;
        private ToolStripMenuItem dialoguesToolStripMenuItem;
        private Label label118;
        private Button buttonInsertVAR;
        private ContextMenuStrip contextMenuStrip2;
        private ToolStripMenuItem addThisToNotesDatabaseToolStripMenuItem;
        private ToolStripMenuItem applyBorderToolStripMenuItem;
        private BackgroundWorker backgroundWorker1;
    }
}

