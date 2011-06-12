namespace LAZYSHELL
{
    partial class NPCEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NPCEditor));
            this.spritePictureBox = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.unknownBits = new System.Windows.Forms.CheckedListBox();
            this.layerPriority = new System.Windows.Forms.CheckedListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.yPixelShift = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.axisAcute = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.axisObtuse = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.height = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.shadow = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.searchResults = new System.Windows.Forms.ListBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.npcNum = new LAZYSHELL.ToolStripNumericUpDown();
            this.spriteNameTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.searchSpriteNames = new System.Windows.Forms.ToolStripButton();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.spriteName = new System.Windows.Forms.ToolStripComboBox();
            this.spriteNum = new LAZYSHELL.ToolStripNumericUpDown();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.buttonReset = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.searchSpriteName = new System.Windows.Forms.ToolStripComboBox();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.spritePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yPixelShift)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axisAcute)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axisObtuse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.height)).BeginInit();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel6.SuspendLayout();
            this.toolStrip3.SuspendLayout();
            this.SuspendLayout();
            // 
            // spritePictureBox
            // 
            this.spritePictureBox.BackColor = System.Drawing.SystemColors.ControlDark;
            this.spritePictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.spritePictureBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.spritePictureBox.Location = new System.Drawing.Point(0, 25);
            this.spritePictureBox.Name = "spritePictureBox";
            this.spritePictureBox.Size = new System.Drawing.Size(260, 256);
            this.spritePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.spritePictureBox.TabIndex = 451;
            this.spritePictureBox.TabStop = false;
            this.spritePictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.spritePictureBox_Paint);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label1.Size = new System.Drawing.Size(118, 17);
            this.label1.TabIndex = 461;
            this.label1.Text = "UNKNOWN BITS";
            // 
            // unknownBits
            // 
            this.unknownBits.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.unknownBits.CheckOnClick = true;
            this.unknownBits.ColumnWidth = 55;
            this.unknownBits.FormattingEnabled = true;
            this.unknownBits.IntegralHeight = false;
            this.unknownBits.Items.AddRange(new object[] {
            "B1,b2",
            "B1,b3",
            "B1,b4",
            "B1,b5",
            "B1,b6",
            "B1,b7",
            "B2,b0",
            "B2,b1",
            "B2,b2",
            "B2,b3",
            "B2,b4",
            "B3,b7",
            "B5,b5",
            "B5,b6",
            "B5,b7",
            "B6,b2"});
            this.unknownBits.Location = new System.Drawing.Point(0, 19);
            this.unknownBits.MultiColumn = true;
            this.unknownBits.Name = "unknownBits";
            this.unknownBits.Size = new System.Drawing.Size(118, 162);
            this.unknownBits.TabIndex = 464;
            this.unknownBits.SelectedIndexChanged += new System.EventHandler(this.unknownBits_SelectedIndexChanged);
            // 
            // layerPriority
            // 
            this.layerPriority.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.layerPriority.CheckOnClick = true;
            this.layerPriority.FormattingEnabled = true;
            this.layerPriority.Items.AddRange(new object[] {
            "priority 0 tiles",
            "priority 1 tiles",
            "priority 2 tiles"});
            this.layerPriority.Location = new System.Drawing.Point(0, 19);
            this.layerPriority.Name = "layerPriority";
            this.layerPriority.Size = new System.Drawing.Size(129, 48);
            this.layerPriority.TabIndex = 465;
            this.layerPriority.SelectedIndexChanged += new System.EventHandler(this.layerPriority_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label2.Size = new System.Drawing.Size(129, 17);
            this.label2.TabIndex = 461;
            this.label2.Text = "OVERLAP PRIORITY";
            // 
            // yPixelShift
            // 
            this.yPixelShift.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.yPixelShift.Location = new System.Drawing.Point(70, 87);
            this.yPixelShift.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.yPixelShift.Minimum = new decimal(new int[] {
            16,
            0,
            0,
            -2147483648});
            this.yPixelShift.Name = "yPixelShift";
            this.yPixelShift.Size = new System.Drawing.Size(59, 17);
            this.yPixelShift.TabIndex = 454;
            this.yPixelShift.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.yPixelShift.ValueChanged += new System.EventHandler(this.yPixelShift_ValueChanged);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(0, 87);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label3.Size = new System.Drawing.Size(69, 17);
            this.label3.TabIndex = 461;
            this.label3.Text = "Y pixel shift";
            // 
            // axisAcute
            // 
            this.axisAcute.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.axisAcute.Location = new System.Drawing.Point(70, 19);
            this.axisAcute.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.axisAcute.Name = "axisAcute";
            this.axisAcute.Size = new System.Drawing.Size(59, 17);
            this.axisAcute.TabIndex = 454;
            this.axisAcute.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.axisAcute.ValueChanged += new System.EventHandler(this.axisAcute_ValueChanged);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(0, 19);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label4.Size = new System.Drawing.Size(69, 17);
            this.label4.TabIndex = 461;
            this.label4.Text = "Acute axis";
            // 
            // axisObtuse
            // 
            this.axisObtuse.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.axisObtuse.Location = new System.Drawing.Point(70, 37);
            this.axisObtuse.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.axisObtuse.Name = "axisObtuse";
            this.axisObtuse.Size = new System.Drawing.Size(59, 17);
            this.axisObtuse.TabIndex = 454;
            this.axisObtuse.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.axisObtuse.ValueChanged += new System.EventHandler(this.axisObtuse_ValueChanged);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.SystemColors.Control;
            this.label5.Location = new System.Drawing.Point(0, 37);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label5.Size = new System.Drawing.Size(69, 17);
            this.label5.TabIndex = 461;
            this.label5.Text = "Obtuse axis";
            // 
            // height
            // 
            this.height.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.height.Location = new System.Drawing.Point(70, 55);
            this.height.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.height.Name = "height";
            this.height.Size = new System.Drawing.Size(59, 17);
            this.height.TabIndex = 454;
            this.height.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.height.ValueChanged += new System.EventHandler(this.height_ValueChanged);
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.SystemColors.Control;
            this.label6.Location = new System.Drawing.Point(0, 55);
            this.label6.Name = "label6";
            this.label6.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label6.Size = new System.Drawing.Size(69, 17);
            this.label6.TabIndex = 461;
            this.label6.Text = "Height";
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.SystemColors.Control;
            this.label7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label7.Location = new System.Drawing.Point(0, 0);
            this.label7.Name = "label7";
            this.label7.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label7.Size = new System.Drawing.Size(129, 17);
            this.label7.TabIndex = 461;
            this.label7.Text = "SOLIDITY FIELD";
            // 
            // buttonOK
            // 
            this.buttonOK.BackColor = System.Drawing.SystemColors.Control;
            this.buttonOK.FlatAppearance.BorderSize = 0;
            this.buttonOK.Location = new System.Drawing.Point(23, 500);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 453;
            this.buttonOK.Text = "Apply";
            this.buttonOK.UseVisualStyleBackColor = false;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.BackColor = System.Drawing.SystemColors.Control;
            this.buttonCancel.FlatAppearance.BorderSize = 0;
            this.buttonCancel.Location = new System.Drawing.Point(185, 500);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 453;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = false;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Window;
            this.panel1.Controls.Add(this.shadow);
            this.panel1.Location = new System.Drawing.Point(70, 69);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(59, 17);
            this.panel1.TabIndex = 460;
            // 
            // shadow
            // 
            this.shadow.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.shadow.IntegralHeight = false;
            this.shadow.Items.AddRange(new object[] {
            "{NONE}",
            "circle (small)",
            "circle (med)",
            "block"});
            this.shadow.Location = new System.Drawing.Point(-2, -2);
            this.shadow.Name = "shadow";
            this.shadow.Size = new System.Drawing.Size(63, 21);
            this.shadow.TabIndex = 370;
            this.shadow.SelectedIndexChanged += new System.EventHandler(this.shadow_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.SystemColors.Control;
            this.label9.Location = new System.Drawing.Point(0, 69);
            this.label9.Name = "label9";
            this.label9.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label9.Size = new System.Drawing.Size(69, 17);
            this.label9.TabIndex = 461;
            this.label9.Text = "Shadow";
            // 
            // searchResults
            // 
            this.searchResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.searchResults.FormattingEnabled = true;
            this.searchResults.IntegralHeight = false;
            this.searchResults.Location = new System.Drawing.Point(2, 60);
            this.searchResults.Name = "searchResults";
            this.searchResults.Size = new System.Drawing.Size(228, 464);
            this.searchResults.TabIndex = 329;
            this.searchResults.SelectedIndexChanged += new System.EventHandler(this.searchResults_SelectedIndexChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.npcNum});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(260, 25);
            this.toolStrip1.TabIndex = 467;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // npcNum
            // 
            this.npcNum.AutoSize = false;
            this.npcNum.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.npcNum.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.npcNum.ForeColor = System.Drawing.SystemColors.Control;
            this.npcNum.Hexadecimal = false;
            this.npcNum.Location = new System.Drawing.Point(7, 1);
            this.npcNum.Maximum = new decimal(new int[] {
            511,
            0,
            0,
            0});
            this.npcNum.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.npcNum.Name = "npcNum";
            this.npcNum.Size = new System.Drawing.Size(70, 22);
            this.npcNum.Text = "0";
            this.npcNum.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.npcNum.ValueChanged += new System.EventHandler(this.npcNum_ValueChanged);
            // 
            // spriteNameTextBox
            // 
            this.spriteNameTextBox.Name = "spriteNameTextBox";
            this.spriteNameTextBox.Size = new System.Drawing.Size(200, 21);
            // 
            // searchSpriteNames
            // 
            this.searchSpriteNames.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.searchSpriteNames.Image = global::LAZYSHELL.Properties.Resources.search;
            this.searchSpriteNames.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.searchSpriteNames.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.searchSpriteNames.Name = "searchSpriteNames";
            this.searchSpriteNames.Size = new System.Drawing.Size(23, 17);
            this.searchSpriteNames.Text = "Find sprite";
            // 
            // toolStrip2
            // 
            this.toolStrip2.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip2.CanOverflow = false;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.spriteName,
            this.spriteNum});
            this.toolStrip2.Location = new System.Drawing.Point(0, 281);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip2.Size = new System.Drawing.Size(260, 25);
            this.toolStrip2.TabIndex = 468;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // spriteName
            // 
            this.spriteName.AutoSize = false;
            this.spriteName.DropDownHeight = 200;
            this.spriteName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.spriteName.DropDownWidth = 400;
            this.spriteName.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.spriteName.IntegralHeight = false;
            this.spriteName.Name = "spriteName";
            this.spriteName.Size = new System.Drawing.Size(190, 21);
            this.spriteName.SelectedIndexChanged += new System.EventHandler(this.spriteName_SelectedIndexChanged);
            // 
            // spriteNum
            // 
            this.spriteNum.AutoSize = false;
            this.spriteNum.Hexadecimal = false;
            this.spriteNum.Location = new System.Drawing.Point(199, 2);
            this.spriteNum.Maximum = new decimal(new int[] {
            1023,
            0,
            0,
            0});
            this.spriteNum.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spriteNum.Name = "spriteNum";
            this.spriteNum.Size = new System.Drawing.Size(60, 20);
            this.spriteNum.Text = "0";
            this.spriteNum.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spriteNum.ValueChanged += new System.EventHandler(this.spriteNum_ValueChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.buttonCancel);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.buttonReset);
            this.panel2.Controls.Add(this.buttonOK);
            this.panel2.Controls.Add(this.toolStrip2);
            this.panel2.Controls.Add(this.spritePictureBox);
            this.panel2.Controls.Add(this.toolStrip1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(260, 524);
            this.panel2.TabIndex = 469;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel5.Controls.Add(this.label1);
            this.panel5.Controls.Add(this.unknownBits);
            this.panel5.Location = new System.Drawing.Point(138, 309);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(122, 185);
            this.panel5.TabIndex = 471;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.label7);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.axisObtuse);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.axisAcute);
            this.panel4.Controls.Add(this.height);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Location = new System.Drawing.Point(3, 418);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(133, 76);
            this.panel4.TabIndex = 470;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.layerPriority);
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.yPixelShift);
            this.panel3.Location = new System.Drawing.Point(3, 309);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(133, 108);
            this.panel3.TabIndex = 469;
            // 
            // buttonReset
            // 
            this.buttonReset.BackColor = System.Drawing.SystemColors.Control;
            this.buttonReset.FlatAppearance.BorderSize = 0;
            this.buttonReset.Location = new System.Drawing.Point(104, 500);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(75, 23);
            this.buttonReset.TabIndex = 453;
            this.buttonReset.Text = "Reset";
            this.buttonReset.UseVisualStyleBackColor = false;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.searchResults);
            this.panel6.Controls.Add(this.toolStrip3);
            this.panel6.Controls.Add(this.label8);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(260, 0);
            this.panel6.Name = "panel6";
            this.panel6.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.panel6.Size = new System.Drawing.Size(230, 524);
            this.panel6.TabIndex = 470;
            // 
            // toolStrip3
            // 
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.searchSpriteName,
            this.spriteNameTextBox,
            this.searchSpriteNames});
            this.toolStrip3.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.toolStrip3.Location = new System.Drawing.Point(2, 18);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip3.Size = new System.Drawing.Size(228, 42);
            this.toolStrip3.TabIndex = 0;
            this.toolStrip3.Text = "toolStrip3";
            // 
            // searchSpriteName
            // 
            this.searchSpriteName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.searchSpriteName.DropDownWidth = 400;
            this.searchSpriteName.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.searchSpriteName.Name = "searchSpriteName";
            this.searchSpriteName.Size = new System.Drawing.Size(200, 21);
            this.searchSpriteName.SelectedIndexChanged += new System.EventHandler(this.searchSpriteName_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label8.Dock = System.Windows.Forms.DockStyle.Top;
            this.label8.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(2, 0);
            this.label8.Name = "label8";
            this.label8.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label8.Size = new System.Drawing.Size(228, 18);
            this.label8.TabIndex = 462;
            this.label8.Text = "FIND NPCS CONTAINING SPRITE...";
            this.label8.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // NPCEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 524);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel2);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NPCEditor";
            this.Text = "NPCS - Lazy Shell";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NPCEditor_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.spritePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yPixelShift)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axisAcute)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axisObtuse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.height)).EndInit();
            this.panel1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox spritePictureBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox unknownBits;
        private System.Windows.Forms.CheckedListBox layerPriority;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown yPixelShift;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown axisAcute;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown axisObtuse;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown height;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox shadow;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ListBox searchResults;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private LAZYSHELL.ToolStripNumericUpDown npcNum;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripComboBox spriteName;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStripTextBox spriteNameTextBox;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.ToolStripButton searchSpriteNames;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripComboBox searchSpriteName;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.Label label8;
        private ToolStripNumericUpDown spriteNum;
    }
}