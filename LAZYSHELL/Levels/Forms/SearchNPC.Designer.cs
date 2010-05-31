namespace LAZYSHELL
{
    partial class SearchNPC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchNPC));
            this.spritePictureBox = new System.Windows.Forms.PictureBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.label93 = new System.Windows.Forms.Label();
            this.panel44 = new System.Windows.Forms.Panel();
            this.spriteName = new System.Windows.Forms.ComboBox();
            this.label78 = new System.Windows.Forms.Label();
            this.searchSpriteNames = new System.Windows.Forms.Button();
            this.panelSearchSpriteNames = new System.Windows.Forms.Panel();
            this.listBoxSpriteNames = new System.Windows.Forms.ListBox();
            this.panel58 = new System.Windows.Forms.Panel();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.unknownBits = new System.Windows.Forms.CheckedListBox();
            this.layerPriority = new System.Windows.Forms.CheckedListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.yPixelShift = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.shift16pxDown = new System.Windows.Forms.CheckBox();
            this.axisAcute = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.axisObtuse = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.height = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.npcNum = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.shadow = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.searchResults = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.spritePictureBox)).BeginInit();
            this.panel44.SuspendLayout();
            this.panelSearchSpriteNames.SuspendLayout();
            this.panel58.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.yPixelShift)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axisAcute)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axisObtuse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.height)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.npcNum)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // spritePictureBox
            // 
            this.spritePictureBox.BackColor = System.Drawing.SystemColors.ControlDark;
            this.spritePictureBox.Location = new System.Drawing.Point(2, 59);
            this.spritePictureBox.Name = "spritePictureBox";
            this.spritePictureBox.Size = new System.Drawing.Size(256, 256);
            this.spritePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.spritePictureBox.TabIndex = 451;
            this.spritePictureBox.TabStop = false;
            this.spritePictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.spritePictureBox_Paint);
            // 
            // searchButton
            // 
            this.searchButton.BackColor = System.Drawing.SystemColors.Window;
            this.searchButton.FlatAppearance.BorderSize = 0;
            this.searchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.searchButton.Location = new System.Drawing.Point(188, 21);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(70, 17);
            this.searchButton.TabIndex = 453;
            this.searchButton.Text = "SEARCH";
            this.searchButton.UseCompatibleTextRendering = true;
            this.searchButton.UseVisualStyleBackColor = false;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // label93
            // 
            this.label93.BackColor = System.Drawing.SystemColors.Control;
            this.label93.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label93.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label93.Location = new System.Drawing.Point(2, 21);
            this.label93.Name = "label93";
            this.label93.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.label93.Size = new System.Drawing.Size(184, 17);
            this.label93.TabIndex = 452;
            this.label93.Text = "NPC PROPERTIES";
            this.label93.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel44
            // 
            this.panel44.BackColor = System.Drawing.SystemColors.Window;
            this.panel44.Controls.Add(this.spriteName);
            this.panel44.Location = new System.Drawing.Point(68, 40);
            this.panel44.Name = "panel44";
            this.panel44.Size = new System.Drawing.Size(170, 17);
            this.panel44.TabIndex = 460;
            // 
            // spriteName
            // 
            this.spriteName.DropDownHeight = 496;
            this.spriteName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.spriteName.DropDownWidth = 300;
            this.spriteName.IntegralHeight = false;
            this.spriteName.Location = new System.Drawing.Point(-2, -2);
            this.spriteName.Name = "spriteName";
            this.spriteName.Size = new System.Drawing.Size(174, 21);
            this.spriteName.TabIndex = 370;
            this.spriteName.SelectedIndexChanged += new System.EventHandler(this.spriteName_SelectedIndexChanged);
            // 
            // label78
            // 
            this.label78.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label78.Location = new System.Drawing.Point(2, 40);
            this.label78.Name = "label78";
            this.label78.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label78.Size = new System.Drawing.Size(65, 17);
            this.label78.TabIndex = 461;
            this.label78.Text = "Sprite #";
            // 
            // searchSpriteNames
            // 
            this.searchSpriteNames.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.searchSpriteNames.BackColor = System.Drawing.SystemColors.ControlDark;
            this.searchSpriteNames.BackgroundImage = global::LAZYSHELL.Properties.Resources.search;
            this.searchSpriteNames.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.searchSpriteNames.FlatAppearance.BorderSize = 0;
            this.searchSpriteNames.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.searchSpriteNames.Location = new System.Drawing.Point(239, 40);
            this.searchSpriteNames.Name = "searchSpriteNames";
            this.searchSpriteNames.Size = new System.Drawing.Size(19, 17);
            this.searchSpriteNames.TabIndex = 462;
            this.searchSpriteNames.UseCompatibleTextRendering = true;
            this.searchSpriteNames.UseVisualStyleBackColor = false;
            this.searchSpriteNames.Click += new System.EventHandler(this.searchSpriteNames_Click);
            // 
            // panelSearchSpriteNames
            // 
            this.panelSearchSpriteNames.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelSearchSpriteNames.BackColor = System.Drawing.SystemColors.ControlText;
            this.panelSearchSpriteNames.Controls.Add(this.listBoxSpriteNames);
            this.panelSearchSpriteNames.Controls.Add(this.panel58);
            this.panelSearchSpriteNames.Location = new System.Drawing.Point(237, 57);
            this.panelSearchSpriteNames.Name = "panelSearchSpriteNames";
            this.panelSearchSpriteNames.Size = new System.Drawing.Size(240, 257);
            this.panelSearchSpriteNames.TabIndex = 463;
            this.panelSearchSpriteNames.Visible = false;
            // 
            // listBoxSpriteNames
            // 
            this.listBoxSpriteNames.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBoxSpriteNames.FormattingEnabled = true;
            this.listBoxSpriteNames.Location = new System.Drawing.Point(2, 21);
            this.listBoxSpriteNames.Name = "listBoxSpriteNames";
            this.listBoxSpriteNames.Size = new System.Drawing.Size(236, 234);
            this.listBoxSpriteNames.TabIndex = 194;
            this.listBoxSpriteNames.SelectedIndexChanged += new System.EventHandler(this.listBoxSpriteNames_SelectedIndexChanged);
            this.listBoxSpriteNames.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listBoxSpriteNames_KeyDown);
            // 
            // panel58
            // 
            this.panel58.BackColor = System.Drawing.SystemColors.Window;
            this.panel58.Controls.Add(this.nameTextBox);
            this.panel58.Location = new System.Drawing.Point(2, 2);
            this.panel58.Name = "panel58";
            this.panel58.Size = new System.Drawing.Size(236, 17);
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
            this.nameTextBox.Size = new System.Drawing.Size(228, 14);
            this.nameTextBox.TabIndex = 4;
            this.nameTextBox.TextChanged += new System.EventHandler(this.nameTextBox_TextChanged);
            this.nameTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nameTextBox_KeyDown);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label1.Location = new System.Drawing.Point(132, 336);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label1.Size = new System.Drawing.Size(126, 17);
            this.label1.TabIndex = 461;
            this.label1.Text = "UNKNOWN BITS";
            // 
            // unknownBits
            // 
            this.unknownBits.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.unknownBits.CheckOnClick = true;
            this.unknownBits.ColumnWidth = 60;
            this.unknownBits.FormattingEnabled = true;
            this.unknownBits.IntegralHeight = false;
            this.unknownBits.Items.AddRange(new object[] {
            "{B1,b2}",
            "{B1,b3}",
            "{B1,b4}",
            "{B1,b5}",
            "{B1,b6}",
            "{B1,b7}",
            "{B2,b0}",
            "{B2,b1}",
            "{B2,b2}",
            "{B2,b3}",
            "{B2,b4}",
            "{B3,b7}",
            "{B5,b5}",
            "{B5,b6}",
            "{B5,b7}",
            "{B6,b2}"});
            this.unknownBits.Location = new System.Drawing.Point(132, 355);
            this.unknownBits.MultiColumn = true;
            this.unknownBits.Name = "unknownBits";
            this.unknownBits.Size = new System.Drawing.Size(126, 141);
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
            this.layerPriority.Location = new System.Drawing.Point(2, 336);
            this.layerPriority.Name = "layerPriority";
            this.layerPriority.Size = new System.Drawing.Size(128, 48);
            this.layerPriority.TabIndex = 465;
            this.layerPriority.SelectedIndexChanged += new System.EventHandler(this.layerPriority_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label2.Location = new System.Drawing.Point(2, 317);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label2.Size = new System.Drawing.Size(128, 17);
            this.label2.TabIndex = 461;
            this.label2.Text = "OVERLAP PRIORITY";
            // 
            // yPixelShift
            // 
            this.yPixelShift.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.yPixelShift.Location = new System.Drawing.Point(78, 386);
            this.yPixelShift.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.yPixelShift.Name = "yPixelShift";
            this.yPixelShift.Size = new System.Drawing.Size(53, 17);
            this.yPixelShift.TabIndex = 454;
            this.yPixelShift.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.yPixelShift.ValueChanged += new System.EventHandler(this.yPixelShift_ValueChanged);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label3.Location = new System.Drawing.Point(2, 386);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label3.Size = new System.Drawing.Size(75, 17);
            this.label3.TabIndex = 461;
            this.label3.Text = "Y pixel shift";
            // 
            // shift16pxDown
            // 
            this.shift16pxDown.Appearance = System.Windows.Forms.Appearance.Button;
            this.shift16pxDown.BackColor = System.Drawing.SystemColors.Control;
            this.shift16pxDown.FlatAppearance.BorderSize = 0;
            this.shift16pxDown.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(168)))), ((int)(((byte)(168)))));
            this.shift16pxDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.shift16pxDown.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.shift16pxDown.Location = new System.Drawing.Point(2, 405);
            this.shift16pxDown.Name = "shift16pxDown";
            this.shift16pxDown.Size = new System.Drawing.Size(128, 17);
            this.shift16pxDown.TabIndex = 466;
            this.shift16pxDown.Text = "SHIFT 16px DOWN";
            this.shift16pxDown.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.shift16pxDown.UseCompatibleTextRendering = true;
            this.shift16pxDown.UseVisualStyleBackColor = false;
            this.shift16pxDown.CheckedChanged += new System.EventHandler(this.shift16pxDown_CheckedChanged);
            // 
            // axisAcute
            // 
            this.axisAcute.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.axisAcute.Location = new System.Drawing.Point(78, 443);
            this.axisAcute.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.axisAcute.Name = "axisAcute";
            this.axisAcute.Size = new System.Drawing.Size(53, 17);
            this.axisAcute.TabIndex = 454;
            this.axisAcute.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.axisAcute.ValueChanged += new System.EventHandler(this.axisAcute_ValueChanged);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label4.Location = new System.Drawing.Point(2, 443);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label4.Size = new System.Drawing.Size(75, 17);
            this.label4.TabIndex = 461;
            this.label4.Text = "Acute axis";
            // 
            // axisObtuse
            // 
            this.axisObtuse.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.axisObtuse.Location = new System.Drawing.Point(78, 461);
            this.axisObtuse.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.axisObtuse.Name = "axisObtuse";
            this.axisObtuse.Size = new System.Drawing.Size(53, 17);
            this.axisObtuse.TabIndex = 454;
            this.axisObtuse.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.axisObtuse.ValueChanged += new System.EventHandler(this.axisObtuse_ValueChanged);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label5.Location = new System.Drawing.Point(2, 461);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label5.Size = new System.Drawing.Size(75, 17);
            this.label5.TabIndex = 461;
            this.label5.Text = "Obtuse axis";
            // 
            // height
            // 
            this.height.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.height.Location = new System.Drawing.Point(78, 479);
            this.height.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.height.Name = "height";
            this.height.Size = new System.Drawing.Size(53, 17);
            this.height.TabIndex = 454;
            this.height.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.height.ValueChanged += new System.EventHandler(this.height_ValueChanged);
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label6.Location = new System.Drawing.Point(2, 479);
            this.label6.Name = "label6";
            this.label6.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label6.Size = new System.Drawing.Size(75, 17);
            this.label6.TabIndex = 461;
            this.label6.Text = "Height";
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.SystemColors.Control;
            this.label7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label7.Location = new System.Drawing.Point(2, 424);
            this.label7.Name = "label7";
            this.label7.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label7.Size = new System.Drawing.Size(128, 17);
            this.label7.TabIndex = 461;
            this.label7.Text = "PHYSICAL FIELD";
            // 
            // npcNum
            // 
            this.npcNum.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.npcNum.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.npcNum.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.npcNum.ForeColor = System.Drawing.SystemColors.Control;
            this.npcNum.Location = new System.Drawing.Point(132, 2);
            this.npcNum.Maximum = new decimal(new int[] {
            511,
            0,
            0,
            0});
            this.npcNum.Name = "npcNum";
            this.npcNum.Size = new System.Drawing.Size(127, 17);
            this.npcNum.TabIndex = 454;
            this.npcNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.npcNum.ValueChanged += new System.EventHandler(this.npcNum_ValueChanged);
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.Control;
            this.label8.Location = new System.Drawing.Point(2, 2);
            this.label8.Name = "label8";
            this.label8.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label8.Size = new System.Drawing.Size(128, 17);
            this.label8.TabIndex = 461;
            this.label8.Text = "NPC #";
            // 
            // buttonOK
            // 
            this.buttonOK.BackColor = System.Drawing.Color.Lime;
            this.buttonOK.FlatAppearance.BorderSize = 0;
            this.buttonOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonOK.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonOK.Location = new System.Drawing.Point(2, 498);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(128, 17);
            this.buttonOK.TabIndex = 453;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseCompatibleTextRendering = true;
            this.buttonOK.UseVisualStyleBackColor = false;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.BackColor = System.Drawing.Color.Lime;
            this.buttonCancel.FlatAppearance.BorderSize = 0;
            this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancel.Location = new System.Drawing.Point(132, 498);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(126, 17);
            this.buttonCancel.TabIndex = 453;
            this.buttonCancel.Text = "CANCEL";
            this.buttonCancel.UseCompatibleTextRendering = true;
            this.buttonCancel.UseVisualStyleBackColor = false;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Window;
            this.panel1.Controls.Add(this.shadow);
            this.panel1.Location = new System.Drawing.Point(183, 317);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(75, 17);
            this.panel1.TabIndex = 460;
            // 
            // shadow
            // 
            this.shadow.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.shadow.IntegralHeight = false;
            this.shadow.Items.AddRange(new object[] {
            "{NONE}",
            "small circle",
            "medium circle",
            "large block"});
            this.shadow.Location = new System.Drawing.Point(-2, -2);
            this.shadow.Name = "shadow";
            this.shadow.Size = new System.Drawing.Size(79, 21);
            this.shadow.TabIndex = 370;
            this.shadow.SelectedIndexChanged += new System.EventHandler(this.shadow_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label9.Location = new System.Drawing.Point(132, 317);
            this.label9.Name = "label9";
            this.label9.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label9.Size = new System.Drawing.Size(49, 17);
            this.label9.TabIndex = 461;
            this.label9.Text = "Shadow";
            // 
            // searchResults
            // 
            this.searchResults.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.searchResults.FormattingEnabled = true;
            this.searchResults.IntegralHeight = false;
            this.searchResults.Location = new System.Drawing.Point(260, 2);
            this.searchResults.Name = "searchResults";
            this.searchResults.Size = new System.Drawing.Size(227, 513);
            this.searchResults.TabIndex = 329;
            this.searchResults.SelectedIndexChanged += new System.EventHandler(this.searchResults_SelectedIndexChanged);
            // 
            // SearchNPC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowText;
            this.ClientSize = new System.Drawing.Size(489, 517);
            this.Controls.Add(this.shift16pxDown);
            this.Controls.Add(this.layerPriority);
            this.Controls.Add(this.unknownBits);
            this.Controls.Add(this.searchSpriteNames);
            this.Controls.Add(this.panelSearchSpriteNames);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.axisObtuse);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.height);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.axisAcute);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.yPixelShift);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label78);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.npcNum);
            this.Controls.Add(this.panel44);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.label93);
            this.Controls.Add(this.spritePictureBox);
            this.Controls.Add(this.searchResults);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SearchNPC";
            this.Text = "NPCS - Lazy Shell...";
            ((System.ComponentModel.ISupportInitialize)(this.spritePictureBox)).EndInit();
            this.panel44.ResumeLayout(false);
            this.panelSearchSpriteNames.ResumeLayout(false);
            this.panel58.ResumeLayout(false);
            this.panel58.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.yPixelShift)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axisAcute)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axisObtuse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.height)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.npcNum)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox spritePictureBox;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Label label93;
        private System.Windows.Forms.Panel panel44;
        private System.Windows.Forms.ComboBox spriteName;
        private System.Windows.Forms.Label label78;
        private System.Windows.Forms.Button searchSpriteNames;
        private System.Windows.Forms.Panel panelSearchSpriteNames;
        private System.Windows.Forms.ListBox listBoxSpriteNames;
        private System.Windows.Forms.Panel panel58;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox unknownBits;
        private System.Windows.Forms.CheckedListBox layerPriority;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown yPixelShift;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox shift16pxDown;
        private System.Windows.Forms.NumericUpDown axisAcute;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown axisObtuse;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown height;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown npcNum;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox shadow;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ListBox searchResults;
    }
}