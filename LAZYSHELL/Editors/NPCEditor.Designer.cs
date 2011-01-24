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
            this.searchButton = new System.Windows.Forms.ToolStripButton();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.spriteName = new System.Windows.Forms.ToolStripComboBox();
            this.searchSpriteNames = new System.Windows.Forms.ToolStripButton();
            this.spriteNameTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.spritePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yPixelShift)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axisAcute)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axisObtuse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.height)).BeginInit();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // spritePictureBox
            // 
            this.spritePictureBox.BackColor = System.Drawing.SystemColors.ControlDark;
            this.spritePictureBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.spritePictureBox.Location = new System.Drawing.Point(0, 0);
            this.spritePictureBox.Name = "spritePictureBox";
            this.spritePictureBox.Size = new System.Drawing.Size(256, 256);
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
            this.label1.Location = new System.Drawing.Point(130, 283);
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
            this.unknownBits.Location = new System.Drawing.Point(130, 302);
            this.unknownBits.MultiColumn = true;
            this.unknownBits.Name = "unknownBits";
            this.unknownBits.Size = new System.Drawing.Size(126, 159);
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
            this.layerPriority.Location = new System.Drawing.Point(0, 302);
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
            this.label2.Location = new System.Drawing.Point(0, 283);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label2.Size = new System.Drawing.Size(128, 17);
            this.label2.TabIndex = 461;
            this.label2.Text = "OVERLAP PRIORITY";
            // 
            // yPixelShift
            // 
            this.yPixelShift.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.yPixelShift.Location = new System.Drawing.Point(70, 370);
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
            this.label3.Location = new System.Drawing.Point(0, 370);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label3.Size = new System.Drawing.Size(69, 17);
            this.label3.TabIndex = 461;
            this.label3.Text = "Y pixel shift";
            // 
            // axisAcute
            // 
            this.axisAcute.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.axisAcute.Location = new System.Drawing.Point(70, 408);
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
            this.label4.Location = new System.Drawing.Point(0, 408);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label4.Size = new System.Drawing.Size(69, 17);
            this.label4.TabIndex = 461;
            this.label4.Text = "Acute axis";
            // 
            // axisObtuse
            // 
            this.axisObtuse.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.axisObtuse.Location = new System.Drawing.Point(70, 426);
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
            this.label5.Location = new System.Drawing.Point(0, 426);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label5.Size = new System.Drawing.Size(69, 17);
            this.label5.TabIndex = 461;
            this.label5.Text = "Obtuse axis";
            // 
            // height
            // 
            this.height.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.height.Location = new System.Drawing.Point(70, 444);
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
            this.label6.Location = new System.Drawing.Point(0, 444);
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
            this.label7.Location = new System.Drawing.Point(0, 389);
            this.label7.Name = "label7";
            this.label7.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label7.Size = new System.Drawing.Size(128, 17);
            this.label7.TabIndex = 461;
            this.label7.Text = "SOLIDITY FIELD";
            // 
            // buttonOK
            // 
            this.buttonOK.BackColor = System.Drawing.SystemColors.Control;
            this.buttonOK.FlatAppearance.BorderSize = 0;
            this.buttonOK.Location = new System.Drawing.Point(319, 455);
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
            this.buttonCancel.Location = new System.Drawing.Point(400, 455);
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
            this.panel1.Location = new System.Drawing.Point(70, 352);
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
            this.label9.Location = new System.Drawing.Point(0, 352);
            this.label9.Name = "label9";
            this.label9.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label9.Size = new System.Drawing.Size(69, 17);
            this.label9.TabIndex = 461;
            this.label9.Text = "Shadow";
            // 
            // searchResults
            // 
            this.searchResults.Dock = System.Windows.Forms.DockStyle.Top;
            this.searchResults.FormattingEnabled = true;
            this.searchResults.IntegralHeight = false;
            this.searchResults.Location = new System.Drawing.Point(260, 25);
            this.searchResults.Name = "searchResults";
            this.searchResults.Size = new System.Drawing.Size(227, 424);
            this.searchResults.TabIndex = 329;
            this.searchResults.SelectedIndexChanged += new System.EventHandler(this.searchResults_SelectedIndexChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.npcNum,
            this.searchButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(487, 25);
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
            // searchButton
            // 
            this.searchButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.searchButton.Image = global::LAZYSHELL.Properties.Resources.search;
            this.searchButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.searchButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(23, 22);
            this.searchButton.Text = "Search NPCs";
            // 
            // toolStrip2
            // 
            this.toolStrip2.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip2.CanOverflow = false;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.spriteName,
            this.searchSpriteNames,
            this.spriteNameTextBox});
            this.toolStrip2.Location = new System.Drawing.Point(0, 256);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip2.Size = new System.Drawing.Size(256, 25);
            this.toolStrip2.TabIndex = 468;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // spriteName
            // 
            this.spriteName.AutoSize = false;
            this.spriteName.DropDownHeight = 200;
            this.spriteName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.spriteName.DropDownWidth = 300;
            this.spriteName.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.spriteName.IntegralHeight = false;
            this.spriteName.Name = "spriteName";
            this.spriteName.Size = new System.Drawing.Size(120, 21);
            this.spriteName.SelectedIndexChanged += new System.EventHandler(this.spriteName_SelectedIndexChanged);
            // 
            // searchSpriteNames
            // 
            this.searchSpriteNames.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.searchSpriteNames.Image = global::LAZYSHELL.Properties.Resources.search;
            this.searchSpriteNames.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.searchSpriteNames.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.searchSpriteNames.Name = "searchSpriteNames";
            this.searchSpriteNames.Size = new System.Drawing.Size(23, 22);
            this.searchSpriteNames.Text = "toolStripButton1";
            // 
            // spriteNameTextBox
            // 
            this.spriteNameTextBox.Name = "spriteNameTextBox";
            this.spriteNameTextBox.Size = new System.Drawing.Size(100, 25);
            this.spriteNameTextBox.Visible = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlText;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.toolStrip2);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.spritePictureBox);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.yPixelShift);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.layerPriority);
            this.panel2.Controls.Add(this.axisAcute);
            this.panel2.Controls.Add(this.unknownBits);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.height);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.axisObtuse);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 25);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(260, 465);
            this.panel2.TabIndex = 469;
            // 
            // NPCEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 490);
            this.Controls.Add(this.searchResults);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.toolStrip1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NPCEditor";
            this.Text = "NPCS - Lazy Shell";
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
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.ToolStripButton searchButton;
        private LAZYSHELL.ToolStripNumericUpDown npcNum;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripComboBox spriteName;
        private System.Windows.Forms.ToolStripButton searchSpriteNames;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStripTextBox spriteNameTextBox;
    }
}