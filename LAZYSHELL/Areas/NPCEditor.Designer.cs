
namespace LAZYSHELL.Areas
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
            this.spritePictureBox = new System.Windows.Forms.PictureBox();
            this.unknownBits = new System.Windows.Forms.CheckedListBox();
            this.layerPriority = new System.Windows.Forms.CheckedListBox();
            this.yPixelShift = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.axisAcute = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.axisObtuse = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.height = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.shadow = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.npcNum = new LAZYSHELL.Controls.NewToolStripNumericUpDown();
            this.search = new LAZYSHELL.Controls.NewToolStripButton();
            this.findReferences = new System.Windows.Forms.ToolStripButton();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.spriteName = new System.Windows.Forms.ToolStripComboBox();
            this.spriteNum = new LAZYSHELL.Controls.NewToolStripNumericUpDown();
            this.editSprite = new System.Windows.Forms.ToolStripButton();
            this.vramStore = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cannotClone = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.vramSize = new System.Windows.Forms.NumericUpDown();
            this.buttonReset = new System.Windows.Forms.Button();
            this.showShadow = new System.Windows.Forms.CheckBox();
            this.headerLabel1 = new LAZYSHELL.Controls.HeaderLabel();
            this.headerLabel2 = new LAZYSHELL.Controls.HeaderLabel();
            this.headerLabel3 = new LAZYSHELL.Controls.HeaderLabel();
            this.headerLabel4 = new LAZYSHELL.Controls.HeaderLabel();
            ((System.ComponentModel.ISupportInitialize)(this.spritePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yPixelShift)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axisAcute)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axisObtuse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.height)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vramSize)).BeginInit();
            this.SuspendLayout();
            // 
            // spritePictureBox
            // 
            this.spritePictureBox.BackgroundImage = global::LAZYSHELL.Properties.Resources._transparent;
            this.spritePictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.spritePictureBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.spritePictureBox.Location = new System.Drawing.Point(0, 25);
            this.spritePictureBox.Name = "spritePictureBox";
            this.spritePictureBox.Size = new System.Drawing.Size(256, 224);
            this.spritePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.spritePictureBox.TabIndex = 451;
            this.spritePictureBox.TabStop = false;
            this.spritePictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.spritePictureBox_Paint);
            // 
            // unknownBits
            // 
            this.unknownBits.CheckOnClick = true;
            this.unknownBits.ColumnWidth = 60;
            this.unknownBits.FormattingEnabled = true;
            this.unknownBits.Items.AddRange(new object[] {
            "B2,b0",
            "B2,b1",
            "B2,b2",
            "B2,b3",
            "B2,b4",
            "B5,b6",
            "B5,b7",
            "B6,b2"});
            this.unknownBits.Location = new System.Drawing.Point(0, 509);
            this.unknownBits.MultiColumn = true;
            this.unknownBits.Name = "unknownBits";
            this.unknownBits.Size = new System.Drawing.Size(256, 36);
            this.unknownBits.TabIndex = 0;
            this.unknownBits.SelectedIndexChanged += new System.EventHandler(this.unknownBits_SelectedIndexChanged);
            // 
            // layerPriority
            // 
            this.layerPriority.CheckOnClick = true;
            this.layerPriority.FormattingEnabled = true;
            this.layerPriority.Items.AddRange(new object[] {
            "priority 0 tiles",
            "priority 1 tiles",
            "priority 2 tiles"});
            this.layerPriority.Location = new System.Drawing.Point(3, 291);
            this.layerPriority.Name = "layerPriority";
            this.layerPriority.Size = new System.Drawing.Size(119, 52);
            this.layerPriority.TabIndex = 0;
            this.layerPriority.SelectedIndexChanged += new System.EventHandler(this.layerPriority_SelectedIndexChanged);
            // 
            // yPixelShift
            // 
            this.yPixelShift.Location = new System.Drawing.Point(196, 312);
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
            this.yPixelShift.Size = new System.Drawing.Size(52, 21);
            this.yPixelShift.TabIndex = 5;
            this.yPixelShift.ValueChanged += new System.EventHandler(this.yPixelShift_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(129, 315);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Y pixel shift";
            // 
            // axisAcute
            // 
            this.axisAcute.Location = new System.Drawing.Point(73, 385);
            this.axisAcute.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.axisAcute.Name = "axisAcute";
            this.axisAcute.Size = new System.Drawing.Size(49, 21);
            this.axisAcute.TabIndex = 1;
            this.axisAcute.ValueChanged += new System.EventHandler(this.axisAcute_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 387);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Acute axis";
            // 
            // axisObtuse
            // 
            this.axisObtuse.Location = new System.Drawing.Point(73, 406);
            this.axisObtuse.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.axisObtuse.Name = "axisObtuse";
            this.axisObtuse.Size = new System.Drawing.Size(49, 21);
            this.axisObtuse.TabIndex = 3;
            this.axisObtuse.ValueChanged += new System.EventHandler(this.axisObtuse_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 408);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Obtuse axis";
            // 
            // height
            // 
            this.height.Location = new System.Drawing.Point(199, 385);
            this.height.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.height.Name = "height";
            this.height.Size = new System.Drawing.Size(49, 21);
            this.height.TabIndex = 5;
            this.height.ValueChanged += new System.EventHandler(this.height_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(129, 387);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Height";
            // 
            // buttonOK
            // 
            this.buttonOK.FlatAppearance.BorderSize = 0;
            this.buttonOK.Location = new System.Drawing.Point(10, 551);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 6;
            this.buttonOK.Text = "Apply";
            this.buttonOK.UseVisualStyleBackColor = false;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.FlatAppearance.BorderSize = 0;
            this.buttonClose.Location = new System.Drawing.Point(172, 551);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 8;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // shadow
            // 
            this.shadow.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.shadow.DropDownWidth = 70;
            this.shadow.IntegralHeight = false;
            this.shadow.Items.AddRange(new object[] {
            "oval (small)",
            "oval (med)",
            "oval (big)",
            "block"});
            this.shadow.Location = new System.Drawing.Point(196, 291);
            this.shadow.Name = "shadow";
            this.shadow.Size = new System.Drawing.Size(52, 21);
            this.shadow.TabIndex = 3;
            this.shadow.SelectedIndexChanged += new System.EventHandler(this.shadow_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(129, 294);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(45, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = "Shadow";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.npcNum,
            this.search,
            this.findReferences});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(256, 25);
            this.toolStrip1.TabIndex = 0;
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(44, 22);
            this.toolStripLabel1.Text = " NPC # ";
            // 
            // npcNum
            // 
            this.npcNum.AutoSize = false;
            this.npcNum.ContextMenuStrip = null;
            this.npcNum.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.npcNum.Hexadecimal = false;
            this.npcNum.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.npcNum.Location = new System.Drawing.Point(51, 2);
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
            this.npcNum.Size = new System.Drawing.Size(60, 21);
            this.npcNum.Text = "0";
            this.npcNum.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.npcNum.ValueChanged += new System.EventHandler(this.npcNum_ValueChanged);
            // 
            // search
            // 
            this.search.CheckOnClick = true;
            this.search.Form = null;
            this.search.Image = global::LAZYSHELL.Properties.Resources.search;
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(23, 22);
            this.search.ToolTipText = "Search NPCs by sprite property";
            // 
            // findReferences
            // 
            this.findReferences.Image = global::LAZYSHELL.Properties.Resources.find_references;
            this.findReferences.Name = "findReferences";
            this.findReferences.Size = new System.Drawing.Size(23, 22);
            this.findReferences.ToolTipText = "Find References to NPC";
            this.findReferences.Click += new System.EventHandler(this.findReferences_Click);
            // 
            // toolStrip2
            // 
            this.toolStrip2.CanOverflow = false;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.spriteName,
            this.spriteNum,
            this.editSprite});
            this.toolStrip2.Location = new System.Drawing.Point(0, 249);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(256, 25);
            this.toolStrip2.TabIndex = 1;
            // 
            // spriteName
            // 
            this.spriteName.AutoSize = false;
            this.spriteName.DropDownHeight = 300;
            this.spriteName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.spriteName.DropDownWidth = 300;
            this.spriteName.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.spriteName.IntegralHeight = false;
            this.spriteName.Name = "spriteName";
            this.spriteName.Size = new System.Drawing.Size(164, 21);
            this.spriteName.SelectedIndexChanged += new System.EventHandler(this.spriteName_SelectedIndexChanged);
            // 
            // spriteNum
            // 
            this.spriteNum.AutoSize = false;
            this.spriteNum.ContextMenuStrip = null;
            this.spriteNum.Hexadecimal = false;
            this.spriteNum.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spriteNum.Location = new System.Drawing.Point(173, 2);
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
            this.spriteNum.Size = new System.Drawing.Size(50, 21);
            this.spriteNum.Text = "0";
            this.spriteNum.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spriteNum.ValueChanged += new System.EventHandler(this.spriteNum_ValueChanged);
            // 
            // editSprite
            // 
            this.editSprite.Image = global::LAZYSHELL.Properties.Resources.mainSprites;
            this.editSprite.Name = "editSprite";
            this.editSprite.Size = new System.Drawing.Size(23, 22);
            this.editSprite.ToolTipText = "Load to Sprites Editor";
            this.editSprite.Click += new System.EventHandler(this.editSprite_Click);
            // 
            // vramStore
            // 
            this.vramStore.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.vramStore.DropDownWidth = 100;
            this.vramStore.IntegralHeight = false;
            this.vramStore.Items.AddRange(new object[] {
            "SW/SE, NW/NE",
            "SW/SE, NW/NE, S",
            "SW/SE",
            "SW/SE, NW/NE",
            "all directions",
            "____",
            "____",
            "all directions"});
            this.vramStore.Location = new System.Drawing.Point(42, 447);
            this.vramStore.Name = "vramStore";
            this.vramStore.Size = new System.Drawing.Size(80, 21);
            this.vramStore.TabIndex = 1;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(3, 449);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(33, 13);
            this.label11.TabIndex = 0;
            this.label11.Text = "Store";
            // 
            // cannotClone
            // 
            this.cannotClone.Appearance = System.Windows.Forms.Appearance.Button;
            this.cannotClone.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cannotClone.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.cannotClone.Location = new System.Drawing.Point(128, 447);
            this.cannotClone.Name = "cannotClone";
            this.cannotClone.Size = new System.Drawing.Size(120, 21);
            this.cannotClone.TabIndex = 4;
            this.cannotClone.Text = "CANNOT CLONE";
            this.cannotClone.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cannotClone.UseVisualStyleBackColor = false;
            this.cannotClone.CheckedChanged += new System.EventHandler(this.cannotClone_CheckedChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(3, 470);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(26, 13);
            this.label12.TabIndex = 2;
            this.label12.Text = "Size";
            // 
            // vramSize
            // 
            this.vramSize.Location = new System.Drawing.Point(42, 468);
            this.vramSize.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.vramSize.Name = "vramSize";
            this.vramSize.Size = new System.Drawing.Size(80, 21);
            this.vramSize.TabIndex = 3;
            // 
            // buttonReset
            // 
            this.buttonReset.FlatAppearance.BorderSize = 0;
            this.buttonReset.Location = new System.Drawing.Point(91, 551);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(75, 23);
            this.buttonReset.TabIndex = 7;
            this.buttonReset.Text = "Reset";
            this.buttonReset.UseVisualStyleBackColor = false;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // showShadow
            // 
            this.showShadow.Appearance = System.Windows.Forms.Appearance.Button;
            this.showShadow.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showShadow.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.showShadow.Location = new System.Drawing.Point(3, 344);
            this.showShadow.Name = "showShadow";
            this.showShadow.Size = new System.Drawing.Size(119, 21);
            this.showShadow.TabIndex = 1;
            this.showShadow.Text = "SHOW SHADOW";
            this.showShadow.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.showShadow.UseVisualStyleBackColor = false;
            this.showShadow.CheckedChanged += new System.EventHandler(this.showShadow_CheckedChanged);
            // 
            // headerLabel1
            // 
            this.headerLabel1.Location = new System.Drawing.Point(0, 274);
            this.headerLabel1.Name = "headerLabel1";
            this.headerLabel1.Size = new System.Drawing.Size(256, 14);
            this.headerLabel1.TabIndex = 452;
            this.headerLabel1.Text = "Priority";
            // 
            // headerLabel2
            // 
            this.headerLabel2.Location = new System.Drawing.Point(0, 368);
            this.headerLabel2.Name = "headerLabel2";
            this.headerLabel2.Size = new System.Drawing.Size(256, 14);
            this.headerLabel2.TabIndex = 452;
            this.headerLabel2.Text = "Collision Field";
            // 
            // headerLabel3
            // 
            this.headerLabel3.Location = new System.Drawing.Point(0, 430);
            this.headerLabel3.Name = "headerLabel3";
            this.headerLabel3.Size = new System.Drawing.Size(256, 14);
            this.headerLabel3.TabIndex = 452;
            this.headerLabel3.Text = "VRAM Buffer";
            // 
            // headerLabel4
            // 
            this.headerLabel4.Location = new System.Drawing.Point(0, 492);
            this.headerLabel4.Name = "headerLabel4";
            this.headerLabel4.Size = new System.Drawing.Size(256, 14);
            this.headerLabel4.TabIndex = 452;
            this.headerLabel4.Text = "Unknown Bits";
            // 
            // NPCEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(256, 582);
            this.Controls.Add(this.unknownBits);
            this.Controls.Add(this.vramStore);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cannotClone);
            this.Controls.Add(this.shadow);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.axisObtuse);
            this.Controls.Add(this.vramSize);
            this.Controls.Add(this.headerLabel4);
            this.Controls.Add(this.headerLabel3);
            this.Controls.Add(this.headerLabel2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.headerLabel1);
            this.Controls.Add(this.axisAcute);
            this.Controls.Add(this.height);
            this.Controls.Add(this.showShadow);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.yPixelShift);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.spritePictureBox);
            this.Controls.Add(this.layerPriority);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonReset);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "NPCEditor";
            this.Text = "NPCS - Lazy Shell";
            ((System.ComponentModel.ISupportInitialize)(this.spritePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yPixelShift)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axisAcute)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axisObtuse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.height)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vramSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        private System.Windows.Forms.PictureBox spritePictureBox;
        private System.Windows.Forms.CheckedListBox unknownBits;
        private System.Windows.Forms.CheckedListBox layerPriority;
        private System.Windows.Forms.NumericUpDown yPixelShift;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown axisAcute;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown axisObtuse;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown height;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.ComboBox shadow;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private Controls.NewToolStripNumericUpDown npcNum;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripComboBox spriteName;
        private System.Windows.Forms.Button buttonReset;
        private Controls.NewToolStripNumericUpDown spriteNum;
        private System.Windows.Forms.CheckBox cannotClone;
        private System.Windows.Forms.CheckBox showShadow;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown vramSize;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox vramStore;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton editSprite;
        private Controls.NewToolStripButton search;
        private System.Windows.Forms.ToolStripButton findReferences;
        private Controls.HeaderLabel headerLabel1;
        private Controls.HeaderLabel headerLabel2;
        private Controls.HeaderLabel headerLabel3;
        private Controls.HeaderLabel headerLabel4;
    }
}