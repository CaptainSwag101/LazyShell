
namespace LazyShell.Fonts
{
    partial class NewFontTable
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
			this.toolStrip3 = new System.Windows.Forms.ToolStrip();
			this.fontFamily = new System.Windows.Forms.ToolStripComboBox();
			this.fontSize = new LazyShell.Controls.NewToolStripNumericUpDown();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.fontBold = new System.Windows.Forms.ToolStripButton();
			this.fontItalics = new System.Windows.Forms.ToolStripButton();
			this.fontUnderline = new System.Windows.Forms.ToolStripButton();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.shiftTableUp = new System.Windows.Forms.ToolStripButton();
			this.shiftTableDown = new System.Windows.Forms.ToolStripButton();
			this.shiftTableLeft = new System.Windows.Forms.ToolStripButton();
			this.shiftTableRight = new System.Windows.Forms.ToolStripButton();
			this.resetTable = new System.Windows.Forms.ToolStripButton();
			this.panel71 = new System.Windows.Forms.Panel();
			this.fontTable = new System.Windows.Forms.Panel();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.autoSetWidths = new System.Windows.Forms.CheckBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.characterHeight = new System.Windows.Forms.NumericUpDown();
			this.padding = new System.Windows.Forms.NumericUpDown();
			this.generateFontTableImage = new System.Windows.Forms.Button();
			this.toolStrip3.SuspendLayout();
			this.toolStrip1.SuspendLayout();
			this.panel71.SuspendLayout();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.characterHeight)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.padding)).BeginInit();
			this.SuspendLayout();
			// 
			// toolStrip3
			// 
			this.toolStrip3.CanOverflow = false;
			this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fontFamily,
            this.fontSize,
            this.toolStripSeparator3,
            this.fontBold,
            this.fontItalics,
            this.fontUnderline});
			this.toolStrip3.Location = new System.Drawing.Point(0, 0);
			this.toolStrip3.Name = "toolStrip3";
			this.toolStrip3.Size = new System.Drawing.Size(318, 25);
			this.toolStrip3.TabIndex = 0;
			this.toolStrip3.TabStop = true;
			// 
			// fontFamily
			// 
			this.fontFamily.DropDownHeight = 400;
			this.fontFamily.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.fontFamily.DropDownWidth = 250;
			this.fontFamily.IntegralHeight = false;
			this.fontFamily.Name = "fontFamily";
			this.fontFamily.Size = new System.Drawing.Size(180, 25);
			this.fontFamily.SelectedIndexChanged += new System.EventHandler(this.fontFamily_SelectedIndexChanged);
			// 
			// fontSize
			// 
			this.fontSize.AutoSize = false;
			this.fontSize.ContextMenuStrip = null;
			this.fontSize.Hexadecimal = false;
			this.fontSize.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.fontSize.Location = new System.Drawing.Point(191, 1);
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
			this.fontSize.Size = new System.Drawing.Size(50, 22);
			this.fontSize.Text = "8";
			this.fontSize.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
			this.fontSize.ValueChanged += new System.EventHandler(this.fontSize_ValueChanged);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
			// 
			// fontBold
			// 
			this.fontBold.AutoSize = false;
			this.fontBold.CheckOnClick = true;
			this.fontBold.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.fontBold.Name = "fontBold";
			this.fontBold.Size = new System.Drawing.Size(20, 20);
			this.fontBold.Text = "B";
			this.fontBold.ToolTipText = "Bold";
			this.fontBold.Click += new System.EventHandler(this.fontBold_Click);
			// 
			// fontItalics
			// 
			this.fontItalics.AutoSize = false;
			this.fontItalics.CheckOnClick = true;
			this.fontItalics.Font = new System.Drawing.Font("Times New Roman", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.fontItalics.Name = "fontItalics";
			this.fontItalics.Size = new System.Drawing.Size(20, 20);
			this.fontItalics.Text = "I";
			this.fontItalics.ToolTipText = "Italic";
			this.fontItalics.Click += new System.EventHandler(this.fontItalics_Click);
			// 
			// fontUnderline
			// 
			this.fontUnderline.AutoSize = false;
			this.fontUnderline.CheckOnClick = true;
			this.fontUnderline.Font = new System.Drawing.Font("Times New Roman", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.fontUnderline.Name = "fontUnderline";
			this.fontUnderline.Size = new System.Drawing.Size(20, 20);
			this.fontUnderline.Text = "U";
			this.fontUnderline.ToolTipText = "Underline";
			this.fontUnderline.Click += new System.EventHandler(this.fontUnderline_Click);
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.shiftTableUp,
            this.shiftTableDown,
            this.shiftTableLeft,
            this.shiftTableRight,
            this.resetTable});
			this.toolStrip1.Location = new System.Drawing.Point(3, 17);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(173, 25);
			this.toolStrip1.TabIndex = 2;
			// 
			// shiftTableUp
			// 
			this.shiftTableUp.Image = global::LazyShell.Properties.Resources.moveup;
			this.shiftTableUp.Name = "shiftTableUp";
			this.shiftTableUp.Size = new System.Drawing.Size(23, 22);
			this.shiftTableUp.ToolTipText = "Shift Table Up";
			this.shiftTableUp.Click += new System.EventHandler(this.shiftTableUp_Click);
			// 
			// shiftTableDown
			// 
			this.shiftTableDown.Image = global::LazyShell.Properties.Resources.movedown;
			this.shiftTableDown.Name = "shiftTableDown";
			this.shiftTableDown.Size = new System.Drawing.Size(23, 22);
			this.shiftTableDown.ToolTipText = "Shift Table Down";
			this.shiftTableDown.Click += new System.EventHandler(this.shiftTableDown_Click);
			// 
			// shiftTableLeft
			// 
			this.shiftTableLeft.Image = global::LazyShell.Properties.Resources.back;
			this.shiftTableLeft.Name = "shiftTableLeft";
			this.shiftTableLeft.Size = new System.Drawing.Size(23, 22);
			this.shiftTableLeft.ToolTipText = "Shift Table Left";
			this.shiftTableLeft.Click += new System.EventHandler(this.shiftTableLeft_Click);
			// 
			// shiftTableRight
			// 
			this.shiftTableRight.Image = global::LazyShell.Properties.Resources.foward;
			this.shiftTableRight.Name = "shiftTableRight";
			this.shiftTableRight.Size = new System.Drawing.Size(23, 22);
			this.shiftTableRight.ToolTipText = "Shift Table Right";
			this.shiftTableRight.Click += new System.EventHandler(this.shiftTableRight_Click);
			// 
			// resetTable
			// 
			this.resetTable.Image = global::LazyShell.Properties.Resources.reset;
			this.resetTable.Name = "resetTable";
			this.resetTable.Size = new System.Drawing.Size(23, 22);
			this.resetTable.ToolTipText = "Reset Table";
			this.resetTable.Click += new System.EventHandler(this.resetTable_Click);
			// 
			// panel71
			// 
			this.panel71.BackColor = System.Drawing.SystemColors.Control;
			this.panel71.Controls.Add(this.fontTable);
			this.panel71.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel71.Location = new System.Drawing.Point(0, 25);
			this.panel71.Name = "panel71";
			this.panel71.Size = new System.Drawing.Size(128, 192);
			this.panel71.TabIndex = 1;
			// 
			// fontTable
			// 
			this.fontTable.Location = new System.Drawing.Point(0, 0);
			this.fontTable.Name = "fontTable";
			this.fontTable.Size = new System.Drawing.Size(128, 192);
			this.fontTable.TabIndex = 0;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.autoSetWidths);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.toolStrip1);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.characterHeight);
			this.groupBox1.Controls.Add(this.padding);
			this.groupBox1.Location = new System.Drawing.Point(136, 28);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(179, 117);
			this.groupBox1.TabIndex = 4;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Font Table Settings";
			// 
			// autoSetWidths
			// 
			this.autoSetWidths.AutoSize = true;
			this.autoSetWidths.Location = new System.Drawing.Point(9, 93);
			this.autoSetWidths.Name = "autoSetWidths";
			this.autoSetWidths.Size = new System.Drawing.Size(108, 17);
			this.autoSetWidths.TabIndex = 2;
			this.autoSetWidths.Text = "Auto-crop widths";
			this.autoSetWidths.UseVisualStyleBackColor = true;
			this.autoSetWidths.CheckedChanged += new System.EventHandler(this.autoSetWidths_CheckedChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(9, 68);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(88, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "Character height";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(9, 47);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(45, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Padding";
			// 
			// characterHeight
			// 
			this.characterHeight.Location = new System.Drawing.Point(110, 66);
			this.characterHeight.Name = "characterHeight";
			this.characterHeight.Size = new System.Drawing.Size(63, 21);
			this.characterHeight.TabIndex = 0;
			this.characterHeight.ValueChanged += new System.EventHandler(this.characterHeight_ValueChanged);
			// 
			// padding
			// 
			this.padding.Location = new System.Drawing.Point(110, 45);
			this.padding.Name = "padding";
			this.padding.Size = new System.Drawing.Size(63, 21);
			this.padding.TabIndex = 0;
			// 
			// generateFontTableImage
			// 
			this.generateFontTableImage.BackColor = System.Drawing.SystemColors.Control;
			this.generateFontTableImage.FlatAppearance.BorderSize = 0;
			this.generateFontTableImage.Location = new System.Drawing.Point(136, 195);
			this.generateFontTableImage.Name = "generateFontTableImage";
			this.generateFontTableImage.Size = new System.Drawing.Size(179, 23);
			this.generateFontTableImage.TabIndex = 3;
			this.generateFontTableImage.Text = "Generate Image";
			this.generateFontTableImage.UseVisualStyleBackColor = false;
			this.generateFontTableImage.Click += new System.EventHandler(this.generateFontTableImage_Click);
			// 
			// NewFontTable
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(318, 217);
			this.Controls.Add(this.generateFontTableImage);
			this.Controls.Add(this.panel71);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.toolStrip3);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Location = new System.Drawing.Point(0, 0);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "NewFontTable";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Text = "New Font Table";
			this.TopMost = true;
			this.toolStrip3.ResumeLayout(false);
			this.toolStrip3.PerformLayout();
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.panel71.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.characterHeight)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.padding)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripButton fontBold;
        private System.Windows.Forms.ToolStripButton fontItalics;
        private System.Windows.Forms.ToolStripButton fontUnderline;
        private System.Windows.Forms.Panel panel71;
        private System.Windows.Forms.Panel fontTable;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton shiftTableUp;
        private System.Windows.Forms.ToolStripButton shiftTableDown;
        private System.Windows.Forms.ToolStripButton shiftTableLeft;
        private System.Windows.Forms.ToolStripButton shiftTableRight;
        private System.Windows.Forms.ToolStripButton resetTable;
        private Controls.NewToolStripNumericUpDown fontSize;
        private System.Windows.Forms.ToolStripComboBox fontFamily;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox autoSetWidths;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown characterHeight;
        private System.Windows.Forms.NumericUpDown padding;
        private System.Windows.Forms.Button generateFontTableImage;
    }
}