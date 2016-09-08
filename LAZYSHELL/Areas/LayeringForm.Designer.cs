namespace LazyShell.Areas
{
    partial class LayeringForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any global::LazyShell.Properties.Resources being used.
        /// </summary>
        /// <param name="disposing">true if managed global::LazyShell.Properties.Resources should be disposed; otherwise, false.</param>
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
            this.effectsNPC = new System.Windows.Forms.ComboBox();
            this.effectsL3 = new System.Windows.Forms.ComboBox();
            this.label38 = new System.Windows.Forms.Label();
            this.ripplingWater = new System.Windows.Forms.CheckBox();
            this.label39 = new System.Windows.Forms.Label();
            this.scrollSpeedL3 = new System.Windows.Forms.ComboBox();
            this.label83 = new System.Windows.Forms.Label();
            this.infiniteScrolling = new System.Windows.Forms.CheckBox();
            this.scrollL2Bit7 = new System.Windows.Forms.CheckBox();
            this.scrollL3Bit7 = new System.Windows.Forms.CheckBox();
            this.label85 = new System.Windows.Forms.Label();
            this.scrollDirectionL3 = new System.Windows.Forms.ComboBox();
            this.scrollSpeedL2 = new System.Windows.Forms.ComboBox();
            this.scrollDirectionL2 = new System.Windows.Forms.ComboBox();
            this.syncL3_HZ = new System.Windows.Forms.ComboBox();
            this.syncL3_VT = new System.Windows.Forms.ComboBox();
            this.syncL2_HZ = new System.Windows.Forms.ComboBox();
            this.syncL2_VT = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.scrollWrap = new System.Windows.Forms.CheckedListBox();
            this.xNegL2 = new System.Windows.Forms.NumericUpDown();
            this.yNegL2 = new System.Windows.Forms.NumericUpDown();
            this.xNegL3 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.yNegL3 = new System.Windows.Forms.NumericUpDown();
            this.maskHighX = new System.Windows.Forms.NumericUpDown();
            this.maskLock = new System.Windows.Forms.CheckBox();
            this.maskHighY = new System.Windows.Forms.NumericUpDown();
            this.maskLowX = new System.Windows.Forms.NumericUpDown();
            this.maskLowY = new System.Windows.Forms.NumericUpDown();
            this.headerLabel1 = new LazyShell.Controls.HeaderLabel();
            this.headerLabel2 = new LazyShell.Controls.HeaderLabel();
            this.headerLabel3 = new LazyShell.Controls.HeaderLabel();
            this.headerLabel4 = new LazyShell.Controls.HeaderLabel();
            this.headerLabel5 = new LazyShell.Controls.HeaderLabel();
            this.headerLabel6 = new LazyShell.Controls.HeaderLabel();
            ((System.ComponentModel.ISupportInitialize)(this.xNegL2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yNegL2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xNegL3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yNegL3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maskHighX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maskHighY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maskLowX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maskLowY)).BeginInit();
            this.SuspendLayout();
            // 
            // effectsNPC
            // 
            this.effectsNPC.DropDownHeight = 160;
            this.effectsNPC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.effectsNPC.DropDownWidth = 200;
            this.effectsNPC.IntegralHeight = false;
            this.effectsNPC.Items.AddRange(new object[] {
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
            this.effectsNPC.Location = new System.Drawing.Point(52, 371);
            this.effectsNPC.Name = "effectsNPC";
            this.effectsNPC.Size = new System.Drawing.Size(108, 21);
            this.effectsNPC.TabIndex = 4;
            this.effectsNPC.SelectedIndexChanged += new System.EventHandler(this.effectsNPC_SelectedIndexChanged);
            // 
            // effectsL3
            // 
            this.effectsL3.DropDownHeight = 160;
            this.effectsL3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.effectsL3.DropDownWidth = 200;
            this.effectsL3.IntegralHeight = false;
            this.effectsL3.Items.AddRange(new object[] {
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
            this.effectsL3.Location = new System.Drawing.Point(52, 350);
            this.effectsL3.Name = "effectsL3";
            this.effectsL3.Size = new System.Drawing.Size(108, 21);
            this.effectsL3.TabIndex = 1;
            this.effectsL3.SelectedIndexChanged += new System.EventHandler(this.effectsL3_SelectedIndexChanged);
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(6, 373);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(40, 13);
            this.label38.TabIndex = 3;
            this.label38.Text = "Sprites";
            // 
            // ripplingWater
            // 
            this.ripplingWater.Appearance = System.Windows.Forms.Appearance.Button;
            this.ripplingWater.BackColor = System.Drawing.SystemColors.Control;
            this.ripplingWater.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ripplingWater.ForeColor = System.Drawing.Color.Gray;
            this.ripplingWater.Location = new System.Drawing.Point(163, 350);
            this.ripplingWater.Name = "ripplingWater";
            this.ripplingWater.Size = new System.Drawing.Size(96, 21);
            this.ripplingWater.TabIndex = 2;
            this.ripplingWater.Text = "RIPPLING WATER";
            this.ripplingWater.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ripplingWater.UseCompatibleTextRendering = true;
            this.ripplingWater.UseVisualStyleBackColor = false;
            this.ripplingWater.CheckedChanged += new System.EventHandler(this.ripplingWater_CheckedChanged);
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(6, 353);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(18, 13);
            this.label39.TabIndex = 0;
            this.label39.Text = "L3";
            // 
            // scrollSpeedL3
            // 
            this.scrollSpeedL3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.scrollSpeedL3.Items.AddRange(new object[] {
            "(none)",
            "very slow",
            "slow",
            "med slow",
            "med fast",
            "fast",
            "very fast"});
            this.scrollSpeedL3.Location = new System.Drawing.Point(187, 309);
            this.scrollSpeedL3.Name = "scrollSpeedL3";
            this.scrollSpeedL3.Size = new System.Drawing.Size(72, 21);
            this.scrollSpeedL3.TabIndex = 8;
            this.scrollSpeedL3.SelectedIndexChanged += new System.EventHandler(this.scrollSpeedL3_SelectedIndexChanged);
            // 
            // label83
            // 
            this.label83.AutoSize = true;
            this.label83.Location = new System.Drawing.Point(6, 312);
            this.label83.Name = "label83";
            this.label83.Size = new System.Drawing.Size(97, 13);
            this.label83.TabIndex = 6;
            this.label83.Text = "L3 Direction/Speed";
            // 
            // infiniteScrolling
            // 
            this.infiniteScrolling.Appearance = System.Windows.Forms.Appearance.Button;
            this.infiniteScrolling.BackColor = System.Drawing.SystemColors.Control;
            this.infiniteScrolling.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infiniteScrolling.ForeColor = System.Drawing.Color.Gray;
            this.infiniteScrolling.Location = new System.Drawing.Point(3, 261);
            this.infiniteScrolling.Name = "infiniteScrolling";
            this.infiniteScrolling.Size = new System.Drawing.Size(106, 21);
            this.infiniteScrolling.TabIndex = 0;
            this.infiniteScrolling.Text = "INFINITE";
            this.infiniteScrolling.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.infiniteScrolling.UseCompatibleTextRendering = true;
            this.infiniteScrolling.UseVisualStyleBackColor = false;
            this.infiniteScrolling.CheckedChanged += new System.EventHandler(this.infiniteScrolling_CheckedChanged);
            // 
            // scrollL2Bit7
            // 
            this.scrollL2Bit7.Appearance = System.Windows.Forms.Appearance.Button;
            this.scrollL2Bit7.BackColor = System.Drawing.SystemColors.Control;
            this.scrollL2Bit7.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scrollL2Bit7.ForeColor = System.Drawing.Color.Gray;
            this.scrollL2Bit7.Location = new System.Drawing.Point(115, 261);
            this.scrollL2Bit7.Name = "scrollL2Bit7";
            this.scrollL2Bit7.Size = new System.Drawing.Size(72, 21);
            this.scrollL2Bit7.TabIndex = 1;
            this.scrollL2Bit7.Text = "L2 SHIFT";
            this.scrollL2Bit7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.scrollL2Bit7.UseCompatibleTextRendering = true;
            this.scrollL2Bit7.UseVisualStyleBackColor = false;
            this.scrollL2Bit7.CheckedChanged += new System.EventHandler(this.scrollL2Bit7_CheckedChanged);
            // 
            // scrollL3Bit7
            // 
            this.scrollL3Bit7.Appearance = System.Windows.Forms.Appearance.Button;
            this.scrollL3Bit7.BackColor = System.Drawing.SystemColors.Control;
            this.scrollL3Bit7.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scrollL3Bit7.ForeColor = System.Drawing.Color.Gray;
            this.scrollL3Bit7.Location = new System.Drawing.Point(187, 261);
            this.scrollL3Bit7.Name = "scrollL3Bit7";
            this.scrollL3Bit7.Size = new System.Drawing.Size(72, 21);
            this.scrollL3Bit7.TabIndex = 2;
            this.scrollL3Bit7.Text = "L3 SHIFT";
            this.scrollL3Bit7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.scrollL3Bit7.UseCompatibleTextRendering = true;
            this.scrollL3Bit7.UseVisualStyleBackColor = false;
            this.scrollL3Bit7.CheckedChanged += new System.EventHandler(this.scrollL3Bit7_CheckedChanged);
            // 
            // label85
            // 
            this.label85.AutoSize = true;
            this.label85.Location = new System.Drawing.Point(6, 291);
            this.label85.Name = "label85";
            this.label85.Size = new System.Drawing.Size(97, 13);
            this.label85.TabIndex = 3;
            this.label85.Text = "L2 Direction/Speed";
            // 
            // scrollDirectionL3
            // 
            this.scrollDirectionL3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.scrollDirectionL3.Items.AddRange(new object[] {
            "W",
            "NW",
            "N",
            "NE",
            "E",
            "SE",
            "S",
            "SW"});
            this.scrollDirectionL3.Location = new System.Drawing.Point(115, 309);
            this.scrollDirectionL3.Name = "scrollDirectionL3";
            this.scrollDirectionL3.Size = new System.Drawing.Size(72, 21);
            this.scrollDirectionL3.TabIndex = 7;
            this.scrollDirectionL3.SelectedIndexChanged += new System.EventHandler(this.scrollDirectionL3_SelectedIndexChanged);
            // 
            // scrollSpeedL2
            // 
            this.scrollSpeedL2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.scrollSpeedL2.Items.AddRange(new object[] {
            "(none)",
            "very slow",
            "slow",
            "med slow",
            "med fast",
            "fast",
            "very fast"});
            this.scrollSpeedL2.Location = new System.Drawing.Point(187, 288);
            this.scrollSpeedL2.Name = "scrollSpeedL2";
            this.scrollSpeedL2.Size = new System.Drawing.Size(72, 21);
            this.scrollSpeedL2.TabIndex = 5;
            this.scrollSpeedL2.SelectedIndexChanged += new System.EventHandler(this.scrollSpeedL2_SelectedIndexChanged);
            // 
            // scrollDirectionL2
            // 
            this.scrollDirectionL2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.scrollDirectionL2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.scrollDirectionL2.Items.AddRange(new object[] {
            "W",
            "NW",
            "N",
            "NE",
            "E",
            "SE",
            "S",
            "SW"});
            this.scrollDirectionL2.Location = new System.Drawing.Point(115, 288);
            this.scrollDirectionL2.Name = "scrollDirectionL2";
            this.scrollDirectionL2.Size = new System.Drawing.Size(72, 21);
            this.scrollDirectionL2.TabIndex = 4;
            this.scrollDirectionL2.SelectedIndexChanged += new System.EventHandler(this.scrollDirectionL2_SelectedIndexChanged);
            // 
            // syncL3_HZ
            // 
            this.syncL3_HZ.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.syncL3_HZ.Items.AddRange(new object[] {
            "None",
            "Low",
            "Normal",
            "High"});
            this.syncL3_HZ.Location = new System.Drawing.Point(187, 220);
            this.syncL3_HZ.Name = "syncL3_HZ";
            this.syncL3_HZ.Size = new System.Drawing.Size(72, 21);
            this.syncL3_HZ.TabIndex = 5;
            this.syncL3_HZ.SelectedIndexChanged += new System.EventHandler(this.syncL3_HZ_SelectedIndexChanged);
            // 
            // syncL3_VT
            // 
            this.syncL3_VT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.syncL3_VT.Items.AddRange(new object[] {
            "None",
            "Low",
            "Normal",
            "High"});
            this.syncL3_VT.Location = new System.Drawing.Point(115, 220);
            this.syncL3_VT.Name = "syncL3_VT";
            this.syncL3_VT.Size = new System.Drawing.Size(72, 21);
            this.syncL3_VT.TabIndex = 4;
            this.syncL3_VT.SelectedIndexChanged += new System.EventHandler(this.syncL3_VT_SelectedIndexChanged);
            // 
            // syncL2_HZ
            // 
            this.syncL2_HZ.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.syncL2_HZ.Items.AddRange(new object[] {
            "None",
            "Low",
            "Normal",
            "High"});
            this.syncL2_HZ.Location = new System.Drawing.Point(187, 199);
            this.syncL2_HZ.Name = "syncL2_HZ";
            this.syncL2_HZ.Size = new System.Drawing.Size(72, 21);
            this.syncL2_HZ.TabIndex = 2;
            this.syncL2_HZ.SelectedIndexChanged += new System.EventHandler(this.syncL2_HZ_SelectedIndexChanged);
            // 
            // syncL2_VT
            // 
            this.syncL2_VT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.syncL2_VT.Items.AddRange(new object[] {
            "None",
            "Low",
            "Normal",
            "High"});
            this.syncL2_VT.Location = new System.Drawing.Point(115, 199);
            this.syncL2_VT.Name = "syncL2_VT";
            this.syncL2_VT.Size = new System.Drawing.Size(72, 21);
            this.syncL2_VT.TabIndex = 1;
            this.syncL2_VT.SelectedIndexChanged += new System.EventHandler(this.syncL2_VT_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 202);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(95, 13);
            this.label12.TabIndex = 0;
            this.label12.Text = "L2 Vert/Horiz Sync";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 222);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(95, 13);
            this.label11.TabIndex = 3;
            this.label11.Text = "L3 Vert/Horiz Sync";
            // 
            // scrollWrap
            // 
            this.scrollWrap.CheckOnClick = true;
            this.scrollWrap.ColumnWidth = 60;
            this.scrollWrap.Items.AddRange(new object[] {
            "L1 horiz",
            "L1 vert",
            "L2 horiz",
            "L2 vert",
            "L3 horiz",
            "L3 vert",
            "Culex",
            "Culex"});
            this.scrollWrap.Location = new System.Drawing.Point(3, 143);
            this.scrollWrap.MultiColumn = true;
            this.scrollWrap.Name = "scrollWrap";
            this.scrollWrap.Size = new System.Drawing.Size(256, 20);
            this.scrollWrap.TabIndex = 0;
            this.scrollWrap.SelectedIndexChanged += new System.EventHandler(this.scrollWrap_SelectedIndexChanged);
            // 
            // xNegL2
            // 
            this.xNegL2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xNegL2.Location = new System.Drawing.Point(30, 102);
            this.xNegL2.Maximum = new decimal(new int[] {
            63,
            0,
            0,
            0});
            this.xNegL2.Name = "xNegL2";
            this.xNegL2.Size = new System.Drawing.Size(44, 21);
            this.xNegL2.TabIndex = 1;
            this.xNegL2.ValueChanged += new System.EventHandler(this.xNegL2_ValueChanged);
            // 
            // yNegL2
            // 
            this.yNegL2.Location = new System.Drawing.Point(74, 102);
            this.yNegL2.Maximum = new decimal(new int[] {
            63,
            0,
            0,
            0});
            this.yNegL2.Name = "yNegL2";
            this.yNegL2.Size = new System.Drawing.Size(44, 21);
            this.yNegL2.TabIndex = 2;
            this.yNegL2.ValueChanged += new System.EventHandler(this.yNegL2_ValueChanged);
            // 
            // xNegL3
            // 
            this.xNegL3.Location = new System.Drawing.Point(148, 102);
            this.xNegL3.Maximum = new decimal(new int[] {
            63,
            0,
            0,
            0});
            this.xNegL3.Name = "xNegL3";
            this.xNegL3.Size = new System.Drawing.Size(44, 21);
            this.xNegL3.TabIndex = 4;
            this.xNegL3.ValueChanged += new System.EventHandler(this.xNegL3_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(124, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "L3";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(6, 106);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(18, 13);
            this.label23.TabIndex = 0;
            this.label23.Text = "L2";
            // 
            // yNegL3
            // 
            this.yNegL3.Location = new System.Drawing.Point(192, 102);
            this.yNegL3.Maximum = new decimal(new int[] {
            63,
            0,
            0,
            0});
            this.yNegL3.Name = "yNegL3";
            this.yNegL3.Size = new System.Drawing.Size(44, 21);
            this.yNegL3.TabIndex = 5;
            this.yNegL3.ValueChanged += new System.EventHandler(this.yNegL3_ValueChanged);
            // 
            // maskHighX
            // 
            this.maskHighX.Location = new System.Drawing.Point(94, 40);
            this.maskHighX.Maximum = new decimal(new int[] {
            63,
            0,
            0,
            0});
            this.maskHighX.Name = "maskHighX";
            this.maskHighX.Size = new System.Drawing.Size(44, 21);
            this.maskHighX.TabIndex = 2;
            this.maskHighX.ValueChanged += new System.EventHandler(this.maskHighX_ValueChanged);
            // 
            // maskLock
            // 
            this.maskLock.Appearance = System.Windows.Forms.Appearance.Button;
            this.maskLock.BackColor = System.Drawing.SystemColors.Control;
            this.maskLock.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maskLock.ForeColor = System.Drawing.Color.Gray;
            this.maskLock.Location = new System.Drawing.Point(144, 40);
            this.maskLock.Name = "maskLock";
            this.maskLock.Size = new System.Drawing.Size(115, 21);
            this.maskLock.TabIndex = 4;
            this.maskLock.Text = "LOCK SCROLLING";
            this.maskLock.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.maskLock.UseCompatibleTextRendering = true;
            this.maskLock.UseVisualStyleBackColor = false;
            this.maskLock.CheckedChanged += new System.EventHandler(this.maskLock_CheckedChanged);
            // 
            // maskHighY
            // 
            this.maskHighY.Location = new System.Drawing.Point(53, 61);
            this.maskHighY.Maximum = new decimal(new int[] {
            63,
            0,
            0,
            0});
            this.maskHighY.Name = "maskHighY";
            this.maskHighY.Size = new System.Drawing.Size(41, 21);
            this.maskHighY.TabIndex = 3;
            this.maskHighY.ValueChanged += new System.EventHandler(this.maskHighY_ValueChanged);
            // 
            // maskLowX
            // 
            this.maskLowX.Location = new System.Drawing.Point(9, 40);
            this.maskLowX.Maximum = new decimal(new int[] {
            63,
            0,
            0,
            0});
            this.maskLowX.Name = "maskLowX";
            this.maskLowX.Size = new System.Drawing.Size(44, 21);
            this.maskLowX.TabIndex = 1;
            this.maskLowX.ValueChanged += new System.EventHandler(this.maskLowX_ValueChanged);
            // 
            // maskLowY
            // 
            this.maskLowY.Location = new System.Drawing.Point(53, 20);
            this.maskLowY.Maximum = new decimal(new int[] {
            63,
            0,
            0,
            0});
            this.maskLowY.Name = "maskLowY";
            this.maskLowY.Size = new System.Drawing.Size(41, 21);
            this.maskLowY.TabIndex = 0;
            this.maskLowY.ValueChanged += new System.EventHandler(this.maskLowY_ValueChanged);
            // 
            // headerLabel1
            // 
            this.headerLabel1.Location = new System.Drawing.Point(0, 3);
            this.headerLabel1.Name = "headerLabel1";
            this.headerLabel1.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.headerLabel1.Size = new System.Drawing.Size(262, 14);
            this.headerLabel1.TabIndex = 18;
            this.headerLabel1.Text = "Layer Mask Edges";
            // 
            // headerLabel2
            // 
            this.headerLabel2.Location = new System.Drawing.Point(0, 85);
            this.headerLabel2.Name = "headerLabel2";
            this.headerLabel2.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.headerLabel2.Size = new System.Drawing.Size(262, 14);
            this.headerLabel2.TabIndex = 18;
            this.headerLabel2.Text = "Layer -(X,Y) Shifting";
            // 
            // headerLabel3
            // 
            this.headerLabel3.Location = new System.Drawing.Point(0, 126);
            this.headerLabel3.Name = "headerLabel3";
            this.headerLabel3.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.headerLabel3.Size = new System.Drawing.Size(263, 14);
            this.headerLabel3.TabIndex = 18;
            this.headerLabel3.Text = "Layer Scrolling Wrap";
            // 
            // headerLabel4
            // 
            this.headerLabel4.Location = new System.Drawing.Point(0, 182);
            this.headerLabel4.Name = "headerLabel4";
            this.headerLabel4.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.headerLabel4.Size = new System.Drawing.Size(262, 14);
            this.headerLabel4.TabIndex = 18;
            this.headerLabel4.Text = "Layer Scroling Synchronization";
            // 
            // headerLabel5
            // 
            this.headerLabel5.Location = new System.Drawing.Point(0, 244);
            this.headerLabel5.Name = "headerLabel5";
            this.headerLabel5.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.headerLabel5.Size = new System.Drawing.Size(262, 14);
            this.headerLabel5.TabIndex = 18;
            this.headerLabel5.Text = "Layer Auto-Scrolling";
            // 
            // headerLabel6
            // 
            this.headerLabel6.Location = new System.Drawing.Point(0, 333);
            this.headerLabel6.Name = "headerLabel6";
            this.headerLabel6.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.headerLabel6.Size = new System.Drawing.Size(262, 14);
            this.headerLabel6.TabIndex = 18;
            this.headerLabel6.Text = "Layer Animation Effects";
            // 
            // LayeringForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(262, 395);
            this.Controls.Add(this.effectsNPC);
            this.Controls.Add(this.scrollSpeedL3);
            this.Controls.Add(this.effectsL3);
            this.Controls.Add(this.syncL3_HZ);
            this.Controls.Add(this.label38);
            this.Controls.Add(this.label83);
            this.Controls.Add(this.ripplingWater);
            this.Controls.Add(this.label39);
            this.Controls.Add(this.scrollWrap);
            this.Controls.Add(this.infiniteScrolling);
            this.Controls.Add(this.syncL3_VT);
            this.Controls.Add(this.scrollL2Bit7);
            this.Controls.Add(this.xNegL2);
            this.Controls.Add(this.scrollL3Bit7);
            this.Controls.Add(this.label85);
            this.Controls.Add(this.syncL2_HZ);
            this.Controls.Add(this.scrollDirectionL3);
            this.Controls.Add(this.syncL2_VT);
            this.Controls.Add(this.scrollSpeedL2);
            this.Controls.Add(this.headerLabel6);
            this.Controls.Add(this.headerLabel5);
            this.Controls.Add(this.headerLabel4);
            this.Controls.Add(this.scrollDirectionL2);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.headerLabel3);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.headerLabel2);
            this.Controls.Add(this.headerLabel1);
            this.Controls.Add(this.yNegL2);
            this.Controls.Add(this.maskHighX);
            this.Controls.Add(this.yNegL3);
            this.Controls.Add(this.xNegL3);
            this.Controls.Add(this.maskLock);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.maskHighY);
            this.Controls.Add(this.maskLowX);
            this.Controls.Add(this.maskLowY);
            this.DockAreas = ((WeifenLuo.WinFormsUI.Docking.DockAreas)(((WeifenLuo.WinFormsUI.Docking.DockAreas.Float | WeifenLuo.WinFormsUI.Docking.DockAreas.DockLeft) 
            | WeifenLuo.WinFormsUI.Docking.DockAreas.DockRight)));
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "LayeringForm";
            this.Text = "Layering";
            ((System.ComponentModel.ISupportInitialize)(this.xNegL2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yNegL2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xNegL3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yNegL3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maskHighX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maskHighY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maskLowX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maskLowY)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox effectsNPC;
        private System.Windows.Forms.ComboBox effectsL3;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.CheckBox ripplingWater;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.ComboBox scrollSpeedL3;
        private System.Windows.Forms.Label label83;
        private System.Windows.Forms.CheckBox infiniteScrolling;
        private System.Windows.Forms.CheckBox scrollL2Bit7;
        private System.Windows.Forms.CheckBox scrollL3Bit7;
        private System.Windows.Forms.Label label85;
        private System.Windows.Forms.ComboBox scrollDirectionL3;
        private System.Windows.Forms.ComboBox scrollSpeedL2;
        private System.Windows.Forms.ComboBox scrollDirectionL2;
        private System.Windows.Forms.ComboBox syncL3_HZ;
        private System.Windows.Forms.ComboBox syncL3_VT;
        private System.Windows.Forms.ComboBox syncL2_HZ;
        private System.Windows.Forms.ComboBox syncL2_VT;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckedListBox scrollWrap;
        private System.Windows.Forms.NumericUpDown xNegL2;
        private System.Windows.Forms.NumericUpDown yNegL2;
        private System.Windows.Forms.NumericUpDown xNegL3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.NumericUpDown yNegL3;
        private System.Windows.Forms.NumericUpDown maskHighX;
        private System.Windows.Forms.CheckBox maskLock;
        private System.Windows.Forms.NumericUpDown maskHighY;
        private System.Windows.Forms.NumericUpDown maskLowX;
        private System.Windows.Forms.NumericUpDown maskLowY;
        private Controls.HeaderLabel headerLabel1;
        private Controls.HeaderLabel headerLabel2;
        private Controls.HeaderLabel headerLabel3;
        private Controls.HeaderLabel headerLabel4;
        private Controls.HeaderLabel headerLabel5;
        private Controls.HeaderLabel headerLabel6;
    }
}