namespace LAZYSHELL
{
    partial class Effects
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Effects));
            this.number = new LAZYSHELL.ToolStripNumericUpDown();
            this.panel106 = new System.Windows.Forms.Panel();
            this.label98 = new System.Windows.Forms.Label();
            this.yNegShift = new System.Windows.Forms.NumericUpDown();
            this.label96 = new System.Windows.Forms.Label();
            this.xNegShift = new System.Windows.Forms.NumericUpDown();
            this.e_paletteIndex = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.panel80 = new System.Windows.Forms.Panel();
            this.panel85 = new System.Windows.Forms.Panel();
            this.panel97 = new System.Windows.Forms.Panel();
            this.e_codec = new System.Windows.Forms.ComboBox();
            this.e_availableBytes = new System.Windows.Forms.Label();
            this.label63 = new System.Windows.Forms.Label();
            this.panel98 = new System.Windows.Forms.Panel();
            this.comboBox6 = new System.Windows.Forms.ComboBox();
            this.e_paletteSetSize = new System.Windows.Forms.NumericUpDown();
            this.label107 = new System.Windows.Forms.Label();
            this.imageNum = new System.Windows.Forms.NumericUpDown();
            this.label90 = new System.Windows.Forms.Label();
            this.e_graphicSetSize = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label89 = new System.Windows.Forms.Label();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.save = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.import = new System.Windows.Forms.ToolStripButton();
            this.export = new System.Windows.Forms.ToolStripButton();
            this.reset = new System.Windows.Forms.ToolStripButton();
            this.clear = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.enableHelpTips = new System.Windows.Forms.ToolStripButton();
            this.showDecHex = new System.Windows.Forms.ToolStripButton();
            this.cullAnimations = new System.Windows.Forms.ToolStripButton();
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.name = new System.Windows.Forms.ToolStripComboBox();
            this.searchText = new System.Windows.Forms.ToolStripTextBox();
            this.searchEffectNames = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.showMain = new System.Windows.Forms.ToolStripButton();
            this.openMolds = new System.Windows.Forms.ToolStripButton();
            this.openSequences = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.openPalettes = new System.Windows.Forms.ToolStripButton();
            this.openGraphics = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel106.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.yNegShift)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xNegShift)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.e_paletteIndex)).BeginInit();
            this.panel80.SuspendLayout();
            this.panel85.SuspendLayout();
            this.panel97.SuspendLayout();
            this.panel98.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.e_paletteSetSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.e_graphicSetSize)).BeginInit();
            this.toolStrip2.SuspendLayout();
            this.toolStrip3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // number
            // 
            this.number.AutoSize = false;
            this.number.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.number.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.number.ForeColor = System.Drawing.SystemColors.Control;
            this.number.Hexadecimal = false;
            this.number.Location = new System.Drawing.Point(219, 2);
            this.number.Maximum = new decimal(new int[] {
            127,
            0,
            0,
            0});
            this.number.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.number.Name = "number";
            this.number.Size = new System.Drawing.Size(50, 17);
            this.number.Text = "0";
            this.number.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.number.ValueChanged += new System.EventHandler(this.number_ValueChanged);
            // 
            // panel106
            // 
            this.panel106.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel106.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel106.Controls.Add(this.label98);
            this.panel106.Controls.Add(this.yNegShift);
            this.panel106.Controls.Add(this.label96);
            this.panel106.Controls.Add(this.xNegShift);
            this.panel106.Controls.Add(this.e_paletteIndex);
            this.panel106.Controls.Add(this.label7);
            this.panel106.Location = new System.Drawing.Point(3, 3);
            this.panel106.Name = "panel106";
            this.panel106.Size = new System.Drawing.Size(260, 57);
            this.panel106.TabIndex = 519;
            // 
            // label98
            // 
            this.label98.BackColor = System.Drawing.SystemColors.Control;
            this.label98.Location = new System.Drawing.Point(0, 36);
            this.label98.Name = "label98";
            this.label98.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label98.Size = new System.Drawing.Size(128, 17);
            this.label98.TabIndex = 396;
            this.label98.Text = "Tile Shift Up";
            // 
            // yNegShift
            // 
            this.yNegShift.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.yNegShift.Location = new System.Drawing.Point(129, 36);
            this.yNegShift.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.yNegShift.Name = "yNegShift";
            this.yNegShift.Size = new System.Drawing.Size(127, 17);
            this.yNegShift.TabIndex = 395;
            this.yNegShift.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.yNegShift.ValueChanged += new System.EventHandler(this.yNegShift_ValueChanged);
            // 
            // label96
            // 
            this.label96.BackColor = System.Drawing.SystemColors.Control;
            this.label96.Location = new System.Drawing.Point(0, 18);
            this.label96.Name = "label96";
            this.label96.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label96.Size = new System.Drawing.Size(128, 17);
            this.label96.TabIndex = 396;
            this.label96.Text = "Tile Shift Left";
            // 
            // xNegShift
            // 
            this.xNegShift.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.xNegShift.Location = new System.Drawing.Point(129, 18);
            this.xNegShift.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.xNegShift.Name = "xNegShift";
            this.xNegShift.Size = new System.Drawing.Size(127, 17);
            this.xNegShift.TabIndex = 395;
            this.xNegShift.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.xNegShift.ValueChanged += new System.EventHandler(this.xNegShift_ValueChanged);
            // 
            // e_paletteIndex
            // 
            this.e_paletteIndex.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.e_paletteIndex.Location = new System.Drawing.Point(129, 0);
            this.e_paletteIndex.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.e_paletteIndex.Name = "e_paletteIndex";
            this.e_paletteIndex.Size = new System.Drawing.Size(127, 17);
            this.e_paletteIndex.TabIndex = 4;
            this.e_paletteIndex.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.e_paletteIndex.ValueChanged += new System.EventHandler(this.e_paletteIndex_ValueChanged);
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.SystemColors.Control;
            this.label7.Location = new System.Drawing.Point(0, 0);
            this.label7.Name = "label7";
            this.label7.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label7.Size = new System.Drawing.Size(128, 17);
            this.label7.TabIndex = 394;
            this.label7.Text = "Palette Index";
            // 
            // panel80
            // 
            this.panel80.BackColor = System.Drawing.SystemColors.ControlText;
            this.panel80.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel80.Controls.Add(this.panel85);
            this.panel80.Location = new System.Drawing.Point(3, 62);
            this.panel80.Name = "panel80";
            this.panel80.Size = new System.Drawing.Size(260, 111);
            this.panel80.TabIndex = 400;
            // 
            // panel85
            // 
            this.panel85.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel85.Controls.Add(this.panel97);
            this.panel85.Controls.Add(this.e_availableBytes);
            this.panel85.Controls.Add(this.label63);
            this.panel85.Controls.Add(this.panel98);
            this.panel85.Controls.Add(this.e_paletteSetSize);
            this.panel85.Controls.Add(this.label107);
            this.panel85.Controls.Add(this.imageNum);
            this.panel85.Controls.Add(this.label90);
            this.panel85.Controls.Add(this.e_graphicSetSize);
            this.panel85.Controls.Add(this.label2);
            this.panel85.Controls.Add(this.label89);
            this.panel85.Location = new System.Drawing.Point(0, 0);
            this.panel85.Name = "panel85";
            this.panel85.Size = new System.Drawing.Size(256, 110);
            this.panel85.TabIndex = 7;
            // 
            // panel97
            // 
            this.panel97.Controls.Add(this.e_codec);
            this.panel97.Location = new System.Drawing.Point(129, 90);
            this.panel97.Name = "panel97";
            this.panel97.Size = new System.Drawing.Size(128, 17);
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
            this.e_codec.Size = new System.Drawing.Size(131, 21);
            this.e_codec.TabIndex = 41;
            this.e_codec.SelectedIndexChanged += new System.EventHandler(this.e_codec_SelectedIndexChanged);
            // 
            // e_availableBytes
            // 
            this.e_availableBytes.BackColor = System.Drawing.Color.Lime;
            this.e_availableBytes.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.e_availableBytes.ForeColor = System.Drawing.SystemColors.ControlText;
            this.e_availableBytes.Location = new System.Drawing.Point(0, 38);
            this.e_availableBytes.Name = "e_availableBytes";
            this.e_availableBytes.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.e_availableBytes.Size = new System.Drawing.Size(256, 14);
            this.e_availableBytes.TabIndex = 451;
            this.e_availableBytes.Text = "0 bytes free";
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
            this.label63.Text = "EFFECT IMAGE";
            this.label63.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel98
            // 
            this.panel98.Controls.Add(this.comboBox6);
            this.panel98.Location = new System.Drawing.Point(129, 90);
            this.panel98.Name = "panel98";
            this.panel98.Size = new System.Drawing.Size(128, 17);
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
            // e_paletteSetSize
            // 
            this.e_paletteSetSize.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.e_paletteSetSize.Increment = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.e_paletteSetSize.Location = new System.Drawing.Point(129, 54);
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
            this.e_paletteSetSize.Size = new System.Drawing.Size(127, 17);
            this.e_paletteSetSize.TabIndex = 16;
            this.e_paletteSetSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.e_paletteSetSize.Value = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.e_paletteSetSize.ValueChanged += new System.EventHandler(this.e_paletteSetSize_ValueChanged);
            // 
            // label107
            // 
            this.label107.BackColor = System.Drawing.SystemColors.Control;
            this.label107.Location = new System.Drawing.Point(0, 54);
            this.label107.Name = "label107";
            this.label107.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label107.Size = new System.Drawing.Size(128, 17);
            this.label107.TabIndex = 394;
            this.label107.Text = "Palette Size";
            // 
            // imageNum
            // 
            this.imageNum.BackColor = System.Drawing.SystemColors.Control;
            this.imageNum.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.imageNum.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.imageNum.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.imageNum.Location = new System.Drawing.Point(129, 19);
            this.imageNum.Maximum = new decimal(new int[] {
            63,
            0,
            0,
            0});
            this.imageNum.Name = "imageNum";
            this.imageNum.Size = new System.Drawing.Size(127, 17);
            this.imageNum.TabIndex = 3;
            this.imageNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.imageNum.ValueChanged += new System.EventHandler(this.imageNum_ValueChanged);
            // 
            // label90
            // 
            this.label90.BackColor = System.Drawing.SystemColors.Control;
            this.label90.Location = new System.Drawing.Point(0, 90);
            this.label90.Name = "label90";
            this.label90.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label90.Size = new System.Drawing.Size(128, 17);
            this.label90.TabIndex = 394;
            this.label90.Text = "BPP Codec";
            // 
            // e_graphicSetSize
            // 
            this.e_graphicSetSize.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.e_graphicSetSize.Increment = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.e_graphicSetSize.Location = new System.Drawing.Point(129, 72);
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
            this.e_graphicSetSize.Size = new System.Drawing.Size(127, 17);
            this.e_graphicSetSize.TabIndex = 16;
            this.e_graphicSetSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.e_graphicSetSize.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.e_graphicSetSize.ValueChanged += new System.EventHandler(this.e_graphicSetSize_ValueChanged);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label2.Location = new System.Drawing.Point(0, 19);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label2.Size = new System.Drawing.Size(128, 17);
            this.label2.TabIndex = 394;
            this.label2.Text = "Image";
            // 
            // label89
            // 
            this.label89.BackColor = System.Drawing.SystemColors.Control;
            this.label89.Location = new System.Drawing.Point(0, 72);
            this.label89.Name = "label89";
            this.label89.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label89.Size = new System.Drawing.Size(128, 17);
            this.label89.TabIndex = 394;
            this.label89.Text = "Graphic Size";
            // 
            // toolStrip2
            // 
            this.toolStrip2.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.save,
            this.toolStripSeparator1,
            this.import,
            this.export,
            this.reset,
            this.clear,
            this.cullAnimations,
            this.toolStripSeparator12,
            this.enableHelpTips,
            this.showDecHex});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip2.Size = new System.Drawing.Size(843, 25);
            this.toolStrip2.TabIndex = 2;
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
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
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
            this.export.Image = global::LAZYSHELL.Properties.Resources.export_small;
            this.export.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.export.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.export.Name = "export";
            this.export.Size = new System.Drawing.Size(23, 22);
            this.export.ToolTipText = "Export";
            this.export.Click += new System.EventHandler(this.export_Click);
            // 
            // reset
            // 
            this.reset.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.reset.Image = global::LAZYSHELL.Properties.Resources.reset;
            this.reset.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.reset.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.reset.Name = "reset";
            this.reset.Size = new System.Drawing.Size(23, 22);
            this.reset.Text = "Reset";
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
            // cullAnimations
            // 
            this.cullAnimations.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cullAnimations.Image = global::LAZYSHELL.Properties.Resources.broom;
            this.cullAnimations.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cullAnimations.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cullAnimations.Name = "cullAnimations";
            this.cullAnimations.Size = new System.Drawing.Size(23, 22);
            this.cullAnimations.ToolTipText = "Clean unused animation data";
            this.cullAnimations.Click += new System.EventHandler(this.cullAnimations_Click);
            // 
            // toolStrip3
            // 
            this.toolStrip3.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.name,
            this.number,
            this.searchText,
            this.searchEffectNames,
            this.toolStripSeparator2,
            this.showMain,
            this.openMolds,
            this.openSequences,
            this.toolStripSeparator4,
            this.openPalettes,
            this.openGraphics});
            this.toolStrip3.Location = new System.Drawing.Point(0, 25);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip3.Size = new System.Drawing.Size(843, 25);
            this.toolStrip3.TabIndex = 3;
            this.toolStrip3.Text = "toolStrip3";
            // 
            // name
            // 
            this.name.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.name.DropDownHeight = 500;
            this.name.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.name.DropDownWidth = 310;
            this.name.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.name.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.name.ForeColor = System.Drawing.SystemColors.Control;
            this.name.IntegralHeight = false;
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(210, 25);
            this.name.SelectedIndexChanged += new System.EventHandler(this.name_SelectedIndexChanged);
            // 
            // searchText
            // 
            this.searchText.Name = "searchText";
            this.searchText.Size = new System.Drawing.Size(200, 25);
            // 
            // searchEffectNames
            // 
            this.searchEffectNames.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.searchEffectNames.Image = global::LAZYSHELL.Properties.Resources.search;
            this.searchEffectNames.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.searchEffectNames.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.searchEffectNames.Name = "searchEffectNames";
            this.searchEffectNames.Size = new System.Drawing.Size(23, 22);
            this.searchEffectNames.Text = "Search for effect";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
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
            this.openMolds.Image = global::LAZYSHELL.Properties.Resources.mainEffects;
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
            this.openSequences.Image = global::LAZYSHELL.Properties.Resources.openEffectSequences;
            this.openSequences.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.openSequences.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openSequences.Name = "openSequences";
            this.openSequences.Size = new System.Drawing.Size(23, 22);
            this.openSequences.ToolTipText = "Frames";
            this.openSequences.Click += new System.EventHandler(this.openSequences_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
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
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 50);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(843, 651);
            this.panel1.TabIndex = 520;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.Controls.Add(this.panel106);
            this.panel2.Controls.Add(this.panel80);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(266, 647);
            this.panel2.TabIndex = 520;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            this.panel2.SizeChanged += new System.EventHandler(this.panel2_SizeChanged);
            // 
            // toolTip1
            // 
            this.toolTip1.Active = false;
            // 
            // Effects
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 701);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip3);
            this.Controls.Add(this.toolStrip2);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(5, 5);
            this.Name = "Effects";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "EFFECTS - Lazy Shell";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Effects_FormClosing);
            this.panel106.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.yNegShift)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xNegShift)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.e_paletteIndex)).EndInit();
            this.panel80.ResumeLayout(false);
            this.panel85.ResumeLayout(false);
            this.panel97.ResumeLayout(false);
            this.panel98.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.e_paletteSetSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.e_graphicSetSize)).EndInit();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel106;
        private System.Windows.Forms.Label label98;
        private System.Windows.Forms.NumericUpDown yNegShift;
        private System.Windows.Forms.Label label96;
        private System.Windows.Forms.NumericUpDown xNegShift;
        private System.Windows.Forms.NumericUpDown e_paletteIndex;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel80;
        private System.Windows.Forms.Panel panel85;
        private System.Windows.Forms.Panel panel97;
        private System.Windows.Forms.ComboBox e_codec;
        private System.Windows.Forms.Label e_availableBytes;
        private System.Windows.Forms.Label label63;
        private System.Windows.Forms.Panel panel98;
        private System.Windows.Forms.ComboBox comboBox6;
        private System.Windows.Forms.NumericUpDown e_paletteSetSize;
        private System.Windows.Forms.Label label107;
        private System.Windows.Forms.NumericUpDown imageNum;
        private System.Windows.Forms.Label label90;
        private System.Windows.Forms.NumericUpDown e_graphicSetSize;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label89;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton save;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton import;
        private System.Windows.Forms.ToolStripButton export;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripComboBox name;
        private System.Windows.Forms.ToolStripButton searchEffectNames;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton openPalettes;
        private System.Windows.Forms.ToolStripButton openGraphics;
        private System.Windows.Forms.ToolStripButton openSequences;
        private System.Windows.Forms.ToolStripButton openMolds;
        private System.Windows.Forms.ToolStripTextBox searchText;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStripButton showMain;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton clear;
        private ToolStripNumericUpDown number;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator12;
        private System.Windows.Forms.ToolStripButton enableHelpTips;
        private System.Windows.Forms.ToolStripButton showDecHex;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStripButton reset;
        private System.Windows.Forms.ToolStripButton cullAnimations;
    }
}