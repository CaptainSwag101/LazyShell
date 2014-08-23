
namespace LAZYSHELL.LevelUps
{
    partial class OwnerForm
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
            this.spellLearned = new System.Windows.Forms.ComboBox();
            this.label137 = new System.Windows.Forms.Label();
            this.hpPlusBonus = new System.Windows.Forms.NumericUpDown();
            this.label113 = new System.Windows.Forms.Label();
            this.defensePlusBonus = new System.Windows.Forms.NumericUpDown();
            this.attackPlusBonus = new System.Windows.Forms.NumericUpDown();
            this.label114 = new System.Windows.Forms.Label();
            this.label116 = new System.Windows.Forms.Label();
            this.mgDefensePlusBonus = new System.Windows.Forms.NumericUpDown();
            this.mgAttackPlusBonus = new System.Windows.Forms.NumericUpDown();
            this.label115 = new System.Windows.Forms.Label();
            this.hpPlus = new System.Windows.Forms.NumericUpDown();
            this.attackPlus = new System.Windows.Forms.NumericUpDown();
            this.label122 = new System.Windows.Forms.Label();
            this.label121 = new System.Windows.Forms.Label();
            this.mgAttackPlus = new System.Windows.Forms.NumericUpDown();
            this.label120 = new System.Windows.Forms.Label();
            this.label117 = new System.Windows.Forms.Label();
            this.defensePlus = new System.Windows.Forms.NumericUpDown();
            this.mgDefensePlus = new System.Windows.Forms.NumericUpDown();
            this.label118 = new System.Windows.Forms.Label();
            this.expNeeded = new System.Windows.Forms.NumericUpDown();
            this.label124 = new System.Windows.Forms.Label();
            this.allyName = new System.Windows.Forms.ComboBox();
            this.headerLabel1 = new LAZYSHELL.Controls.HeaderLabel();
            this.headerLabel2 = new LAZYSHELL.Controls.HeaderLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.levelNum = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.save = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.import = new System.Windows.Forms.ToolStripButton();
            this.export = new System.Windows.Forms.ToolStripButton();
            this.reset = new System.Windows.Forms.ToolStripButton();
            this.clear = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.baseConvertor = new System.Windows.Forms.ToolStripButton();
            this.helpTips = new System.Windows.Forms.ToolStripButton();
            this.headerLabelEffects = new LAZYSHELL.Controls.HeaderLabel();
            ((System.ComponentModel.ISupportInitialize)(this.hpPlusBonus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.defensePlusBonus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.attackPlusBonus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mgDefensePlusBonus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mgAttackPlusBonus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hpPlus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.attackPlus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mgAttackPlus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.defensePlus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mgDefensePlus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.expNeeded)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.levelNum)).BeginInit();
            this.toolStrip3.SuspendLayout();
            this.SuspendLayout();
            // 
            // spellLearned
            // 
            this.spellLearned.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.spellLearned.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.spellLearned.DropDownHeight = 317;
            this.spellLearned.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.spellLearned.DropDownWidth = 150;
            this.spellLearned.IntegralHeight = false;
            this.spellLearned.ItemHeight = 15;
            this.spellLearned.Location = new System.Drawing.Point(89, 225);
            this.spellLearned.Name = "spellLearned";
            this.spellLearned.Size = new System.Drawing.Size(205, 21);
            this.spellLearned.TabIndex = 0;
            this.spellLearned.Tag = "";
            this.spellLearned.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.spellLearned_DrawItem);
            this.spellLearned.SelectedIndexChanged += new System.EventHandler(this.spellLearned_SelectedIndexChanged);
            // 
            // label137
            // 
            this.label137.AutoSize = true;
            this.label137.Location = new System.Drawing.Point(158, 179);
            this.label137.Name = "label137";
            this.label137.Size = new System.Drawing.Size(67, 13);
            this.label137.TabIndex = 6;
            this.label137.Text = "Mg. Attack+";
            // 
            // hpPlusBonus
            // 
            this.hpPlusBonus.Location = new System.Drawing.Point(240, 114);
            this.hpPlusBonus.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.hpPlusBonus.Name = "hpPlusBonus";
            this.hpPlusBonus.Size = new System.Drawing.Size(54, 21);
            this.hpPlusBonus.TabIndex = 1;
            this.hpPlusBonus.ValueChanged += new System.EventHandler(this.hpPlusBonus_ValueChanged);
            // 
            // label113
            // 
            this.label113.AutoSize = true;
            this.label113.Location = new System.Drawing.Point(158, 200);
            this.label113.Name = "label113";
            this.label113.Size = new System.Drawing.Size(76, 13);
            this.label113.TabIndex = 8;
            this.label113.Text = "Mg. Defense+";
            // 
            // defensePlusBonus
            // 
            this.defensePlusBonus.Location = new System.Drawing.Point(240, 156);
            this.defensePlusBonus.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.defensePlusBonus.Name = "defensePlusBonus";
            this.defensePlusBonus.Size = new System.Drawing.Size(54, 21);
            this.defensePlusBonus.TabIndex = 5;
            this.defensePlusBonus.ValueChanged += new System.EventHandler(this.defensePlusBonus_ValueChanged);
            // 
            // attackPlusBonus
            // 
            this.attackPlusBonus.Location = new System.Drawing.Point(240, 135);
            this.attackPlusBonus.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.attackPlusBonus.Name = "attackPlusBonus";
            this.attackPlusBonus.Size = new System.Drawing.Size(54, 21);
            this.attackPlusBonus.TabIndex = 3;
            this.attackPlusBonus.ValueChanged += new System.EventHandler(this.attackPlusBonus_ValueChanged);
            // 
            // label114
            // 
            this.label114.AutoSize = true;
            this.label114.Location = new System.Drawing.Point(158, 158);
            this.label114.Name = "label114";
            this.label114.Size = new System.Drawing.Size(55, 13);
            this.label114.TabIndex = 4;
            this.label114.Text = "Defense+";
            // 
            // label116
            // 
            this.label116.AutoSize = true;
            this.label116.Location = new System.Drawing.Point(158, 116);
            this.label116.Name = "label116";
            this.label116.Size = new System.Drawing.Size(28, 13);
            this.label116.TabIndex = 0;
            this.label116.Text = "HP+";
            // 
            // mgDefensePlusBonus
            // 
            this.mgDefensePlusBonus.Location = new System.Drawing.Point(240, 198);
            this.mgDefensePlusBonus.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.mgDefensePlusBonus.Name = "mgDefensePlusBonus";
            this.mgDefensePlusBonus.Size = new System.Drawing.Size(54, 21);
            this.mgDefensePlusBonus.TabIndex = 9;
            this.mgDefensePlusBonus.ValueChanged += new System.EventHandler(this.mgDefensePlusBonus_ValueChanged);
            // 
            // mgAttackPlusBonus
            // 
            this.mgAttackPlusBonus.Location = new System.Drawing.Point(240, 177);
            this.mgAttackPlusBonus.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.mgAttackPlusBonus.Name = "mgAttackPlusBonus";
            this.mgAttackPlusBonus.Size = new System.Drawing.Size(54, 21);
            this.mgAttackPlusBonus.TabIndex = 7;
            this.mgAttackPlusBonus.ValueChanged += new System.EventHandler(this.mgAttackPlusBonus_ValueChanged);
            // 
            // label115
            // 
            this.label115.AutoSize = true;
            this.label115.Location = new System.Drawing.Point(158, 137);
            this.label115.Name = "label115";
            this.label115.Size = new System.Drawing.Size(46, 13);
            this.label115.TabIndex = 2;
            this.label115.Text = "Attack+";
            // 
            // hpPlus
            // 
            this.hpPlus.Location = new System.Drawing.Point(89, 114);
            this.hpPlus.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.hpPlus.Name = "hpPlus";
            this.hpPlus.Size = new System.Drawing.Size(54, 21);
            this.hpPlus.TabIndex = 1;
            this.hpPlus.ValueChanged += new System.EventHandler(this.hpPlus_ValueChanged);
            // 
            // attackPlus
            // 
            this.attackPlus.Location = new System.Drawing.Point(89, 135);
            this.attackPlus.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.attackPlus.Name = "attackPlus";
            this.attackPlus.Size = new System.Drawing.Size(54, 21);
            this.attackPlus.TabIndex = 3;
            this.attackPlus.ValueChanged += new System.EventHandler(this.attackPlus_ValueChanged);
            // 
            // label122
            // 
            this.label122.AutoSize = true;
            this.label122.Location = new System.Drawing.Point(7, 116);
            this.label122.Name = "label122";
            this.label122.Size = new System.Drawing.Size(28, 13);
            this.label122.TabIndex = 0;
            this.label122.Text = "HP+";
            // 
            // label121
            // 
            this.label121.AutoSize = true;
            this.label121.Location = new System.Drawing.Point(7, 137);
            this.label121.Name = "label121";
            this.label121.Size = new System.Drawing.Size(46, 13);
            this.label121.TabIndex = 2;
            this.label121.Text = "Attack+";
            // 
            // mgAttackPlus
            // 
            this.mgAttackPlus.Location = new System.Drawing.Point(89, 177);
            this.mgAttackPlus.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.mgAttackPlus.Name = "mgAttackPlus";
            this.mgAttackPlus.Size = new System.Drawing.Size(54, 21);
            this.mgAttackPlus.TabIndex = 7;
            this.mgAttackPlus.ValueChanged += new System.EventHandler(this.mgAttackPlus_ValueChanged);
            // 
            // label120
            // 
            this.label120.AutoSize = true;
            this.label120.Location = new System.Drawing.Point(7, 158);
            this.label120.Name = "label120";
            this.label120.Size = new System.Drawing.Size(55, 13);
            this.label120.TabIndex = 4;
            this.label120.Text = "Defense+";
            // 
            // label117
            // 
            this.label117.AutoSize = true;
            this.label117.Location = new System.Drawing.Point(7, 179);
            this.label117.Name = "label117";
            this.label117.Size = new System.Drawing.Size(67, 13);
            this.label117.TabIndex = 6;
            this.label117.Text = "Mg. Attack+";
            // 
            // defensePlus
            // 
            this.defensePlus.Location = new System.Drawing.Point(89, 156);
            this.defensePlus.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.defensePlus.Name = "defensePlus";
            this.defensePlus.Size = new System.Drawing.Size(54, 21);
            this.defensePlus.TabIndex = 5;
            this.defensePlus.ValueChanged += new System.EventHandler(this.defensePlus_ValueChanged);
            // 
            // mgDefensePlus
            // 
            this.mgDefensePlus.Location = new System.Drawing.Point(89, 198);
            this.mgDefensePlus.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.mgDefensePlus.Name = "mgDefensePlus";
            this.mgDefensePlus.Size = new System.Drawing.Size(54, 21);
            this.mgDefensePlus.TabIndex = 9;
            this.mgDefensePlus.ValueChanged += new System.EventHandler(this.mgDefensePlus_ValueChanged);
            // 
            // label118
            // 
            this.label118.AutoSize = true;
            this.label118.Location = new System.Drawing.Point(7, 200);
            this.label118.Name = "label118";
            this.label118.Size = new System.Drawing.Size(76, 13);
            this.label118.TabIndex = 8;
            this.label118.Text = "Mg. Defense+";
            // 
            // expNeeded
            // 
            this.expNeeded.Location = new System.Drawing.Point(240, 32);
            this.expNeeded.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.expNeeded.Name = "expNeeded";
            this.expNeeded.Size = new System.Drawing.Size(54, 21);
            this.expNeeded.TabIndex = 1;
            this.expNeeded.ValueChanged += new System.EventHandler(this.expNeeded_ValueChanged);
            // 
            // label124
            // 
            this.label124.AutoSize = true;
            this.label124.Location = new System.Drawing.Point(135, 34);
            this.label124.Name = "label124";
            this.label124.Size = new System.Drawing.Size(99, 13);
            this.label124.TabIndex = 0;
            this.label124.Text = "Experience needed";
            // 
            // allyName
            // 
            this.allyName.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.allyName.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.allyName.DropDownHeight = 317;
            this.allyName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.allyName.DropDownWidth = 150;
            this.allyName.IntegralHeight = false;
            this.allyName.ItemHeight = 15;
            this.allyName.Location = new System.Drawing.Point(3, 73);
            this.allyName.Name = "allyName";
            this.allyName.Size = new System.Drawing.Size(140, 21);
            this.allyName.TabIndex = 0;
            this.allyName.Tag = "";
            this.allyName.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.allyName_DrawItem);
            this.allyName.SelectedIndexChanged += new System.EventHandler(this.allyName_SelectedIndexChanged);
            // 
            // headerLabel1
            // 
            this.headerLabel1.Location = new System.Drawing.Point(157, 97);
            this.headerLabel1.Name = "headerLabel1";
            this.headerLabel1.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.headerLabel1.Size = new System.Drawing.Size(141, 14);
            this.headerLabel1.TabIndex = 18;
            this.headerLabel1.Text = "Bonus Increments";
            // 
            // headerLabel2
            // 
            this.headerLabel2.Location = new System.Drawing.Point(0, 97);
            this.headerLabel2.Name = "headerLabel2";
            this.headerLabel2.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.headerLabel2.Size = new System.Drawing.Size(157, 14);
            this.headerLabel2.TabIndex = 19;
            this.headerLabel2.Text = "Status Increments";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 228);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Learned Spell";
            // 
            // levelNum
            // 
            this.levelNum.Location = new System.Drawing.Point(56, 32);
            this.levelNum.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.levelNum.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.levelNum.Name = "levelNum";
            this.levelNum.Size = new System.Drawing.Size(54, 21);
            this.levelNum.TabIndex = 1;
            this.levelNum.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.levelNum.ValueChanged += new System.EventHandler(this.levelNum_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Level #";
            // 
            // toolStrip3
            // 
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.save,
            this.toolStripSeparator1,
            this.import,
            this.export,
            this.reset,
            this.clear,
            this.toolStripSeparator2,
            this.baseConvertor,
            this.helpTips});
            this.toolStrip3.Location = new System.Drawing.Point(0, 0);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.Size = new System.Drawing.Size(298, 25);
            this.toolStrip3.TabIndex = 9;
            this.toolStrip3.Text = "toolStrip3";
            // 
            // save
            // 
            this.save.Image = global::LAZYSHELL.Properties.Resources.save;
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
            this.import.Image = global::LAZYSHELL.Properties.Resources.importData;
            this.import.Name = "import";
            this.import.Size = new System.Drawing.Size(23, 22);
            this.import.ToolTipText = "Import attack";
            this.import.Click += new System.EventHandler(this.import_Click);
            // 
            // export
            // 
            this.export.Image = global::LAZYSHELL.Properties.Resources.exportData;
            this.export.Name = "export";
            this.export.Size = new System.Drawing.Size(23, 22);
            this.export.ToolTipText = "Export attack";
            this.export.Click += new System.EventHandler(this.export_Click);
            // 
            // reset
            // 
            this.reset.Image = global::LAZYSHELL.Properties.Resources.reset;
            this.reset.Name = "reset";
            this.reset.Size = new System.Drawing.Size(23, 22);
            this.reset.ToolTipText = "Reset attack";
            this.reset.Click += new System.EventHandler(this.reset_Click);
            // 
            // clear
            // 
            this.clear.Image = global::LAZYSHELL.Properties.Resources.clear;
            this.clear.Name = "clear";
            this.clear.Size = new System.Drawing.Size(23, 22);
            this.clear.ToolTipText = "Clear";
            this.clear.Click += new System.EventHandler(this.clear_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // baseConvertor
            // 
            this.baseConvertor.Image = global::LAZYSHELL.Properties.Resources.baseConversion;
            this.baseConvertor.Name = "baseConvertor";
            this.baseConvertor.Size = new System.Drawing.Size(23, 22);
            this.baseConvertor.ToolTipText = "Show/hide base conversion label";
            // 
            // helpTips
            // 
            this.helpTips.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.helpTips.Image = global::LAZYSHELL.Properties.Resources.about;
            this.helpTips.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.helpTips.Name = "helpTips";
            this.helpTips.Size = new System.Drawing.Size(23, 22);
            this.helpTips.ToolTipText = "Show/hide help tips label";
            // 
            // headerLabelEffects
            // 
            this.headerLabelEffects.Location = new System.Drawing.Point(0, 56);
            this.headerLabelEffects.Name = "headerLabelEffects";
            this.headerLabelEffects.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.headerLabelEffects.Size = new System.Drawing.Size(298, 14);
            this.headerLabelEffects.TabIndex = 17;
            this.headerLabelEffects.Text = "Ally Status Change";
            // 
            // OwnerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(298, 249);
            this.Controls.Add(this.label116);
            this.Controls.Add(this.headerLabelEffects);
            this.Controls.Add(this.label122);
            this.Controls.Add(this.toolStrip3);
            this.Controls.Add(this.label137);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.headerLabel1);
            this.Controls.Add(this.label124);
            this.Controls.Add(this.label115);
            this.Controls.Add(this.hpPlus);
            this.Controls.Add(this.levelNum);
            this.Controls.Add(this.hpPlusBonus);
            this.Controls.Add(this.expNeeded);
            this.Controls.Add(this.mgAttackPlusBonus);
            this.Controls.Add(this.spellLearned);
            this.Controls.Add(this.label118);
            this.Controls.Add(this.label120);
            this.Controls.Add(this.label113);
            this.Controls.Add(this.mgAttackPlus);
            this.Controls.Add(this.headerLabel2);
            this.Controls.Add(this.label117);
            this.Controls.Add(this.mgDefensePlusBonus);
            this.Controls.Add(this.label121);
            this.Controls.Add(this.attackPlus);
            this.Controls.Add(this.allyName);
            this.Controls.Add(this.defensePlusBonus);
            this.Controls.Add(this.defensePlus);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.attackPlusBonus);
            this.Controls.Add(this.label114);
            this.Controls.Add(this.mgDefensePlus);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Location = new System.Drawing.Point(0, 0);
            this.MaximizeBox = false;
            this.Name = "OwnerForm";
            this.Text = "LEVEL-UPS - Lazy Shell";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OwnerForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.hpPlusBonus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.defensePlusBonus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.attackPlusBonus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mgDefensePlusBonus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mgAttackPlusBonus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hpPlus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.attackPlus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mgAttackPlus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.defensePlus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mgDefensePlus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.expNeeded)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.levelNum)).EndInit();
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        private System.Windows.Forms.ComboBox spellLearned;
        private System.Windows.Forms.Label label137;
        private System.Windows.Forms.NumericUpDown hpPlusBonus;
        private System.Windows.Forms.Label label113;
        private System.Windows.Forms.NumericUpDown defensePlusBonus;
        private System.Windows.Forms.NumericUpDown attackPlusBonus;
        private System.Windows.Forms.Label label114;
        private System.Windows.Forms.Label label116;
        private System.Windows.Forms.NumericUpDown mgDefensePlusBonus;
        private System.Windows.Forms.NumericUpDown mgAttackPlusBonus;
        private System.Windows.Forms.Label label115;
        private System.Windows.Forms.NumericUpDown hpPlus;
        private System.Windows.Forms.NumericUpDown attackPlus;
        private System.Windows.Forms.Label label122;
        private System.Windows.Forms.Label label121;
        private System.Windows.Forms.NumericUpDown mgAttackPlus;
        private System.Windows.Forms.Label label120;
        private System.Windows.Forms.Label label117;
        private System.Windows.Forms.NumericUpDown defensePlus;
        private System.Windows.Forms.NumericUpDown mgDefensePlus;
        private System.Windows.Forms.Label label118;
        private System.Windows.Forms.NumericUpDown expNeeded;
        private System.Windows.Forms.Label label124;
        private System.Windows.Forms.ComboBox allyName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown levelNum;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripButton save;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton import;
        private System.Windows.Forms.ToolStripButton export;
        private System.Windows.Forms.ToolStripButton reset;
        private System.Windows.Forms.ToolStripButton clear;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton baseConvertor;
        private System.Windows.Forms.ToolStripButton helpTips;
        private Controls.HeaderLabel headerLabel1;
        private Controls.HeaderLabel headerLabel2;
        private Controls.HeaderLabel headerLabelEffects;
    }
}