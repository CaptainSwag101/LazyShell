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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Sprites));
            this.number = new LAZYSHELL.ToolStripNumericUpDown();
            this.PlaybackSequence = new System.ComponentModel.BackgroundWorker();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addThisToNotesDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.characterNumLabel = new System.Windows.Forms.Label();
            this.panelSprites = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.paletteIndex = new System.Windows.Forms.NumericUpDown();
            this.label71 = new System.Windows.Forms.Label();
            this.label73 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label23 = new System.Windows.Forms.Label();
            this.paletteOffset = new System.Windows.Forms.NumericUpDown();
            this.graphicOffset = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.label72 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label18 = new System.Windows.Forms.Label();
            this.animationAvailableBytes = new System.Windows.Forms.Label();
            this.animationVRAM = new System.Windows.Forms.NumericUpDown();
            this.imageNum = new System.Windows.Forms.NumericUpDown();
            this.animationPacket = new System.Windows.Forms.NumericUpDown();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.labelToolTip = new System.Windows.Forms.Label();
            this.labelConvertor = new System.Windows.Forms.Label();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.save = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.import = new System.Windows.Forms.ToolStripButton();
            this.export = new System.Windows.Forms.ToolStripDropDownButton();
            this.animationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allMoldImagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reset = new System.Windows.Forms.ToolStripButton();
            this.clear = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.enableHelpTips = new System.Windows.Forms.ToolStripButton();
            this.showDecHex = new System.Windows.Forms.ToolStripButton();
            this.hexViewer = new System.Windows.Forms.ToolStripButton();
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.name = new System.Windows.Forms.ToolStripComboBox();
            this.nameTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.searchEffectNames = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.showMain = new System.Windows.Forms.ToolStripButton();
            this.openMolds = new System.Windows.Forms.ToolStripButton();
            this.openSequences = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.openPalettes = new System.Windows.Forms.ToolStripButton();
            this.openGraphics = new System.Windows.Forms.ToolStripButton();
            this.toolTip3 = new System.Windows.Forms.ToolTip(this.components);
            this.contextMenuStrip2.SuspendLayout();
            this.panelSprites.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paletteIndex)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paletteOffset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.graphicOffset)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.animationVRAM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.animationPacket)).BeginInit();
            this.toolStrip2.SuspendLayout();
            this.toolStrip3.SuspendLayout();
            this.SuspendLayout();
            // 
            // number
            // 
            this.number.AutoSize = false;
            this.number.Hexadecimal = false;
            this.number.Location = new System.Drawing.Point(223, 2);
            this.number.Maximum = new decimal(new int[] {
            1023,
            0,
            0,
            0});
            this.number.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.number.Name = "number";
            this.number.Size = new System.Drawing.Size(50, 21);
            this.number.Text = "0";
            this.number.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.number.ValueChanged += new System.EventHandler(this.number_ValueChanged);
            // 
            // PlaybackSequence
            // 
            this.PlaybackSequence.WorkerReportsProgress = true;
            this.PlaybackSequence.WorkerSupportsCancellation = true;
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
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(149, 6);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(149, 6);
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
            // 
            // characterNumLabel
            // 
            this.characterNumLabel.BackColor = System.Drawing.SystemColors.Info;
            this.characterNumLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.characterNumLabel.Location = new System.Drawing.Point(234, 0);
            this.characterNumLabel.Name = "characterNumLabel";
            this.characterNumLabel.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.characterNumLabel.Size = new System.Drawing.Size(100, 18);
            this.characterNumLabel.TabIndex = 526;
            this.characterNumLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.characterNumLabel.Visible = false;
            // 
            // panelSprites
            // 
            this.panelSprites.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panelSprites.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelSprites.Controls.Add(this.panel1);
            this.panelSprites.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSprites.Location = new System.Drawing.Point(0, 50);
            this.panelSprites.Name = "panelSprites";
            this.panelSprites.Size = new System.Drawing.Size(1015, 684);
            this.panelSprites.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.paletteIndex);
            this.panel1.Controls.Add(this.label71);
            this.panel1.Controls.Add(this.label73);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.label72);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.imageNum);
            this.panel1.Controls.Add(this.animationPacket);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(221, 680);
            this.panel1.TabIndex = 516;
            this.panel1.SizeChanged += new System.EventHandler(this.panel1_SizeChanged);
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // paletteIndex
            // 
            this.paletteIndex.Location = new System.Drawing.Point(161, 6);
            this.paletteIndex.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.paletteIndex.Name = "paletteIndex";
            this.paletteIndex.Size = new System.Drawing.Size(49, 21);
            this.paletteIndex.TabIndex = 4;
            this.paletteIndex.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.paletteIndex.ValueChanged += new System.EventHandler(this.paletteIndex_ValueChanged);
            // 
            // label71
            // 
            this.label71.AutoSize = true;
            this.label71.Location = new System.Drawing.Point(10, 10);
            this.label71.Name = "label71";
            this.label71.Size = new System.Drawing.Size(37, 13);
            this.label71.TabIndex = 394;
            this.label71.Text = "Image";
            // 
            // label73
            // 
            this.label73.AutoSize = true;
            this.label73.Location = new System.Drawing.Point(112, 10);
            this.label73.Name = "label73";
            this.label73.Size = new System.Drawing.Size(41, 13);
            this.label73.TabIndex = 394;
            this.label73.Text = "Palette";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label23);
            this.groupBox2.Controls.Add(this.paletteOffset);
            this.groupBox2.Controls.Add(this.graphicOffset);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Location = new System.Drawing.Point(3, 33);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(215, 69);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Image Properties";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(6, 22);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(60, 13);
            this.label23.TabIndex = 394;
            this.label23.Text = "Palette Set";
            // 
            // paletteOffset
            // 
            this.paletteOffset.Location = new System.Drawing.Point(111, 20);
            this.paletteOffset.Maximum = new decimal(new int[] {
            818,
            0,
            0,
            0});
            this.paletteOffset.Name = "paletteOffset";
            this.paletteOffset.Size = new System.Drawing.Size(83, 21);
            this.paletteOffset.TabIndex = 8;
            this.paletteOffset.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.paletteOffset.ValueChanged += new System.EventHandler(this.paletteOffset_ValueChanged);
            // 
            // graphicOffset
            // 
            this.graphicOffset.Hexadecimal = true;
            this.graphicOffset.Increment = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.graphicOffset.Location = new System.Drawing.Point(111, 41);
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
            this.graphicOffset.Size = new System.Drawing.Size(83, 21);
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
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 43);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(81, 13);
            this.label9.TabIndex = 394;
            this.label9.Text = "BPP GFX Offset";
            // 
            // label72
            // 
            this.label72.AutoSize = true;
            this.label72.Location = new System.Drawing.Point(10, 114);
            this.label72.Name = "label72";
            this.label72.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label72.Size = new System.Drawing.Size(56, 16);
            this.label72.TabIndex = 394;
            this.label72.Text = "Animation";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.animationAvailableBytes);
            this.groupBox1.Controls.Add(this.animationVRAM);
            this.groupBox1.Location = new System.Drawing.Point(3, 139);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(215, 67);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Animation Properties";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(6, 43);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(57, 13);
            this.label18.TabIndex = 394;
            this.label18.Text = "VRAM Size";
            // 
            // animationAvailableBytes
            // 
            this.animationAvailableBytes.BackColor = System.Drawing.Color.Lime;
            this.animationAvailableBytes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.animationAvailableBytes.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.animationAvailableBytes.ForeColor = System.Drawing.SystemColors.ControlText;
            this.animationAvailableBytes.Location = new System.Drawing.Point(6, 17);
            this.animationAvailableBytes.Name = "animationAvailableBytes";
            this.animationAvailableBytes.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.animationAvailableBytes.Size = new System.Drawing.Size(203, 20);
            this.animationAvailableBytes.TabIndex = 451;
            this.animationAvailableBytes.Text = "0 bytes free";
            this.animationAvailableBytes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // animationVRAM
            // 
            this.animationVRAM.Increment = new decimal(new int[] {
            2048,
            0,
            0,
            0});
            this.animationVRAM.Location = new System.Drawing.Point(71, 39);
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
            this.animationVRAM.Size = new System.Drawing.Size(60, 21);
            this.animationVRAM.TabIndex = 6;
            this.animationVRAM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.animationVRAM.Value = new decimal(new int[] {
            2048,
            0,
            0,
            0});
            this.animationVRAM.ValueChanged += new System.EventHandler(this.animationVRAM_ValueChanged);
            // 
            // imageNum
            // 
            this.imageNum.Location = new System.Drawing.Point(55, 6);
            this.imageNum.Maximum = new decimal(new int[] {
            511,
            0,
            0,
            0});
            this.imageNum.Name = "imageNum";
            this.imageNum.Size = new System.Drawing.Size(49, 21);
            this.imageNum.TabIndex = 3;
            this.imageNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.imageNum.ValueChanged += new System.EventHandler(this.imageNum_ValueChanged);
            // 
            // animationPacket
            // 
            this.animationPacket.Location = new System.Drawing.Point(72, 112);
            this.animationPacket.Maximum = new decimal(new int[] {
            443,
            0,
            0,
            0});
            this.animationPacket.Name = "animationPacket";
            this.animationPacket.Size = new System.Drawing.Size(49, 21);
            this.animationPacket.TabIndex = 5;
            this.animationPacket.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.animationPacket.ValueChanged += new System.EventHandler(this.animationPacket_ValueChanged);
            // 
            // toolTip1
            // 
            this.toolTip1.Active = false;
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
            // toolStrip2
            // 
            this.toolStrip2.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.save,
            this.toolStripSeparator11,
            this.import,
            this.export,
            this.reset,
            this.clear,
            this.toolStripSeparator12,
            this.enableHelpTips,
            this.showDecHex,
            this.hexViewer});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip2.Size = new System.Drawing.Size(1015, 25);
            this.toolStrip2.TabIndex = 527;
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
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(6, 25);
            // 
            // import
            // 
            this.import.Image = global::LAZYSHELL.Properties.Resources.import_small;
            this.import.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.import.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.import.Name = "import";
            this.import.Size = new System.Drawing.Size(23, 22);
            this.import.ToolTipText = "Import";
            this.import.Click += new System.EventHandler(this.import_Click);
            // 
            // export
            // 
            this.export.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.animationsToolStripMenuItem,
            this.allMoldImagesToolStripMenuItem});
            this.export.Image = global::LAZYSHELL.Properties.Resources.export_small;
            this.export.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.export.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.export.Name = "export";
            this.export.Size = new System.Drawing.Size(26, 22);
            this.export.ToolTipText = "Export";
            // 
            // animationsToolStripMenuItem
            // 
            this.animationsToolStripMenuItem.Name = "animationsToolStripMenuItem";
            this.animationsToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.animationsToolStripMenuItem.Text = "Animation(s)...";
            this.animationsToolStripMenuItem.Click += new System.EventHandler(this.export_Click);
            // 
            // allMoldImagesToolStripMenuItem
            // 
            this.allMoldImagesToolStripMenuItem.Name = "allMoldImagesToolStripMenuItem";
            this.allMoldImagesToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.allMoldImagesToolStripMenuItem.Text = "Sprite image(s)...";
            this.allMoldImagesToolStripMenuItem.Click += new System.EventHandler(this.allMoldImagesToolStripMenuItem_Click);
            // 
            // reset
            // 
            this.reset.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.reset.Image = global::LAZYSHELL.Properties.Resources.reset;
            this.reset.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.reset.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.reset.Name = "reset";
            this.reset.Size = new System.Drawing.Size(23, 22);
            this.reset.ToolTipText = "Reset";
            this.reset.Click += new System.EventHandler(this.reset_Click);
            // 
            // clear
            // 
            this.clear.Image = global::LAZYSHELL.Properties.Resources.clear_small;
            this.clear.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.clear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.clear.Name = "clear";
            this.clear.Size = new System.Drawing.Size(23, 22);
            this.clear.ToolTipText = "Clear";
            this.clear.Click += new System.EventHandler(this.clear_Click);
            // 
            // toolStripSeparator12
            // 
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            this.toolStripSeparator12.Size = new System.Drawing.Size(6, 25);
            // 
            // enableHelpTips
            // 
            this.enableHelpTips.CheckOnClick = true;
            this.enableHelpTips.Image = global::LAZYSHELL.Properties.Resources.help_small;
            this.enableHelpTips.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.enableHelpTips.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.enableHelpTips.Name = "enableHelpTips";
            this.enableHelpTips.Size = new System.Drawing.Size(23, 22);
            this.enableHelpTips.ToolTipText = "Show Help Tips";
            // 
            // showDecHex
            // 
            this.showDecHex.CheckOnClick = true;
            this.showDecHex.Image = global::LAZYSHELL.Properties.Resources.baseConversion;
            this.showDecHex.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.showDecHex.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.showDecHex.Name = "showDecHex";
            this.showDecHex.Size = new System.Drawing.Size(23, 22);
            this.showDecHex.ToolTipText = "Show Base Conversion";
            // 
            // hexViewer
            // 
            this.hexViewer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.hexViewer.Image = global::LAZYSHELL.Properties.Resources.hexEditor;
            this.hexViewer.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.hexViewer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.hexViewer.Name = "hexViewer";
            this.hexViewer.Size = new System.Drawing.Size(23, 22);
            this.hexViewer.Text = "Open Hex Editor";
            this.hexViewer.Click += new System.EventHandler(this.hexViewer_Click);
            // 
            // toolStrip3
            // 
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.name,
            this.number,
            this.nameTextBox,
            this.searchEffectNames,
            this.toolStripSeparator1,
            this.showMain,
            this.openMolds,
            this.openSequences,
            this.toolStripSeparator3,
            this.openPalettes,
            this.openGraphics});
            this.toolStrip3.Location = new System.Drawing.Point(0, 25);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip3.Size = new System.Drawing.Size(1015, 25);
            this.toolStrip3.TabIndex = 529;
            // 
            // name
            // 
            this.name.DropDownHeight = 500;
            this.name.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.name.DropDownWidth = 400;
            this.name.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.name.IntegralHeight = false;
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(214, 25);
            this.name.SelectedIndexChanged += new System.EventHandler(this.name_SelectedIndexChanged);
            // 
            // nameTextBox
            // 
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(200, 25);
            // 
            // searchEffectNames
            // 
            this.searchEffectNames.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.searchEffectNames.Image = global::LAZYSHELL.Properties.Resources.search;
            this.searchEffectNames.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.searchEffectNames.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.searchEffectNames.Name = "searchEffectNames";
            this.searchEffectNames.Size = new System.Drawing.Size(23, 22);
            this.searchEffectNames.Text = "Search for sprite";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // showMain
            // 
            this.showMain.Checked = true;
            this.showMain.CheckOnClick = true;
            this.showMain.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showMain.Image = global::LAZYSHELL.Properties.Resources.showMain;
            this.showMain.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.showMain.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.showMain.Name = "showMain";
            this.showMain.Size = new System.Drawing.Size(23, 22);
            this.showMain.ToolTipText = "Main";
            this.showMain.Click += new System.EventHandler(this.showMain_Click);
            // 
            // openMolds
            // 
            this.openMolds.CheckOnClick = true;
            this.openMolds.Image = global::LAZYSHELL.Properties.Resources.openMolds;
            this.openMolds.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.openMolds.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openMolds.Name = "openMolds";
            this.openMolds.Size = new System.Drawing.Size(23, 22);
            this.openMolds.ToolTipText = "Molds";
            this.openMolds.Click += new System.EventHandler(this.openMolds_Click);
            // 
            // openSequences
            // 
            this.openSequences.CheckOnClick = true;
            this.openSequences.Image = global::LAZYSHELL.Properties.Resources.openSequences;
            this.openSequences.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.openSequences.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openSequences.Name = "openSequences";
            this.openSequences.Size = new System.Drawing.Size(23, 22);
            this.openSequences.ToolTipText = "Sequences";
            this.openSequences.Click += new System.EventHandler(this.openSequences_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // openPalettes
            // 
            this.openPalettes.Image = global::LAZYSHELL.Properties.Resources.openPalettes;
            this.openPalettes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.openPalettes.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openPalettes.Name = "openPalettes";
            this.openPalettes.Size = new System.Drawing.Size(23, 22);
            this.openPalettes.ToolTipText = "Palettes";
            this.openPalettes.Click += new System.EventHandler(this.openPalettes_Click);
            // 
            // openGraphics
            // 
            this.openGraphics.Image = global::LAZYSHELL.Properties.Resources.openGraphics;
            this.openGraphics.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.openGraphics.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openGraphics.Name = "openGraphics";
            this.openGraphics.Size = new System.Drawing.Size(23, 22);
            this.openGraphics.ToolTipText = "BPP Graphics";
            this.openGraphics.Click += new System.EventHandler(this.openGraphics_Click);
            // 
            // toolTip3
            // 
            this.toolTip3.Active = false;
            // 
            // Sprites
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1015, 734);
            this.Controls.Add(this.panelSprites);
            this.Controls.Add(this.toolStrip3);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.labelConvertor);
            this.Controls.Add(this.labelToolTip);
            this.Controls.Add(this.characterNumLabel);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(5, 5);
            this.Name = "Sprites";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "SPRITES - Lazy Shell";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Sprites_FormClosing);
            this.contextMenuStrip2.ResumeLayout(false);
            this.panelSprites.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paletteIndex)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paletteOffset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.graphicOffset)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.animationVRAM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.animationPacket)).EndInit();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BackgroundWorker PlaybackSequence;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripSeparator toolStripSeparator6;
        private ToolStripSeparator toolStripSeparator7;
        private ToolStripSeparator toolStripSeparator8;
        private Label animationAvailableBytes;
        private Label label23;
        private NumericUpDown paletteOffset;
        private Label label9;
        private NumericUpDown graphicOffset;
        private Label label18;
        private NumericUpDown animationVRAM;
        private Label label72;
        private NumericUpDown animationPacket;
        private Label label73;
        private Label label71;
        private NumericUpDown paletteIndex;
        private NumericUpDown imageNum;
        private ToolTip toolTip1;
        private Panel panelSprites;
        private ToolTip toolTip2;
        private Label characterNumLabel;
        private Label labelToolTip;
        private Label labelConvertor;
        private ContextMenuStrip contextMenuStrip2;
        private ToolStripMenuItem addThisToNotesDatabaseToolStripMenuItem;
        private ToolStrip toolStrip2;
        private ToolStripButton save;
        private ToolStripSeparator toolStripSeparator11;
        private ToolStripButton import;
        private ToolStripButton clear;
        private ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripComboBox name;
        private ToolStripButton searchEffectNames;
        private ToolStripTextBox nameTextBox;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton showMain;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripButton openPalettes;
        private ToolStripButton openGraphics;
        private ToolStripButton openMolds;
        private ToolStripButton openSequences;
        private Panel panel1;
        private ToolStripSeparator toolStripSeparator12;
        private ToolStripButton enableHelpTips;
        private ToolStripButton showDecHex;
        private ToolStripDropDownButton export;
        private ToolStripMenuItem allMoldImagesToolStripMenuItem;
        private ToolStripMenuItem animationsToolStripMenuItem;
        private ToolStripNumericUpDown number;
        private ToolTip toolTip3;
        private ToolStripButton hexViewer;
        private ToolStripButton reset;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
    }
}

