
namespace LazyShell.Attacks
{
    partial class OwnerForm
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
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.name = new LazyShell.Controls.NewToolStripComboBox();
			this.num = new LazyShell.Controls.NewToolStripNumericUpDown();
			this.attackType = new System.Windows.Forms.CheckedListBox();
			this.statusUp = new System.Windows.Forms.CheckedListBox();
			this.statusEffect = new System.Windows.Forms.CheckedListBox();
			this.attackLevel = new System.Windows.Forms.NumericUpDown();
			this.hitRate = new System.Windows.Forms.NumericUpDown();
			this.label57 = new System.Windows.Forms.Label();
			this.label58 = new System.Windows.Forms.Label();
			this.toolStrip2 = new System.Windows.Forms.ToolStrip();
			this.nameText = new System.Windows.Forms.ToolStripTextBox();
			this.toolStrip3 = new System.Windows.Forms.ToolStrip();
			this.save = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.import = new System.Windows.Forms.ToolStripButton();
			this.export = new System.Windows.Forms.ToolStripButton();
			this.reset = new System.Windows.Forms.ToolStripButton();
			this.clear = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.damageCalculator = new System.Windows.Forms.ToolStripButton();
			this.baseConvertor = new System.Windows.Forms.ToolStripButton();
			this.helpTips = new System.Windows.Forms.ToolStripButton();
			this.panelAttackPower = new System.Windows.Forms.Panel();
			this.headerLabel2 = new LazyShell.Controls.HeaderLabel();
			this.panelEffectInflict = new System.Windows.Forms.Panel();
			this.headerLabel1 = new LazyShell.Controls.HeaderLabel();
			this.panelStatusUp = new System.Windows.Forms.Panel();
			this.headerLabel3 = new LazyShell.Controls.HeaderLabel();
			this.panelAttackType = new System.Windows.Forms.Panel();
			this.headerLabel4 = new LazyShell.Controls.HeaderLabel();
			this.toolStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.attackLevel)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.hitRate)).BeginInit();
			this.toolStrip2.SuspendLayout();
			this.toolStrip3.SuspendLayout();
			this.panelAttackPower.SuspendLayout();
			this.panelEffectInflict.SuspendLayout();
			this.panelStatusUp.SuspendLayout();
			this.panelAttackType.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolStrip1
			// 
			this.toolStrip1.CanOverflow = false;
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.name,
            this.num});
			this.toolStrip1.Location = new System.Drawing.Point(0, 25);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(209, 26);
			this.toolStrip1.TabIndex = 0;
			// 
			// name
			// 
			this.name.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			this.name.ContextMenuStrip = null;
			this.name.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.name.DropDownHeight = 497;
			this.name.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.name.DropDownWidth = 146;
			this.name.ItemHeight = 15;
			this.name.Location = new System.Drawing.Point(9, 2);
			this.name.Name = "name";
			this.name.SelectedIndex = -1;
			this.name.SelectedItem = null;
			this.name.Size = new System.Drawing.Size(150, 23);
			this.name.SelectedIndexChanged += new System.EventHandler(this.name_SelectedIndexChanged);
			this.name.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.name_DrawItem);
			// 
			// num
			// 
			this.num.ContextMenuStrip = null;
			this.num.Hexadecimal = false;
			this.num.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.num.Location = new System.Drawing.Point(159, 1);
			this.num.Maximum = new decimal(new int[] {
            128,
            0,
            0,
            0});
			this.num.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
			this.num.Name = "attackNum";
			this.num.Size = new System.Drawing.Size(41, 23);
			this.num.Text = "0";
			this.num.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
			this.num.ValueChanged += new System.EventHandler(this.num_ValueChanged);
			// 
			// attackType
			// 
			this.attackType.CheckOnClick = true;
			this.attackType.Items.AddRange(new object[] {
            "9999 Damage",
            "No damage",
            "Hide Battle Numerals",
            "No damage"});
			this.attackType.Location = new System.Drawing.Point(3, 15);
			this.attackType.Name = "attackType";
			this.attackType.Size = new System.Drawing.Size(203, 68);
			this.attackType.TabIndex = 0;
			this.attackType.SelectedIndexChanged += new System.EventHandler(this.attackType_SelectedIndexChanged);
			// 
			// statusUp
			// 
			this.statusUp.CheckOnClick = true;
			this.statusUp.Items.AddRange(new object[] {
            "Attack",
            "Defense",
            "Magic Attack",
            "Magic Defense"});
			this.statusUp.Location = new System.Drawing.Point(3, 15);
			this.statusUp.Name = "statusUp";
			this.statusUp.Size = new System.Drawing.Size(203, 68);
			this.statusUp.TabIndex = 0;
			this.statusUp.SelectedIndexChanged += new System.EventHandler(this.statusUp_SelectedIndexChanged);
			// 
			// statusEffect
			// 
			this.statusEffect.CheckOnClick = true;
			this.statusEffect.ColumnWidth = 90;
			this.statusEffect.Items.AddRange(new object[] {
            "Mute",
            "Sleep",
            "Poison",
            "Fear",
            "Mushroom",
            "Scarecrow",
            "Invincible"});
			this.statusEffect.Location = new System.Drawing.Point(3, 15);
			this.statusEffect.MultiColumn = true;
			this.statusEffect.Name = "statusEffect";
			this.statusEffect.Size = new System.Drawing.Size(203, 68);
			this.statusEffect.TabIndex = 0;
			this.statusEffect.SelectedIndexChanged += new System.EventHandler(this.statusEffect_SelectedIndexChanged);
			// 
			// attackLevel
			// 
			this.attackLevel.Location = new System.Drawing.Point(93, 37);
			this.attackLevel.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
			this.attackLevel.Name = "attackLevel";
			this.attackLevel.Size = new System.Drawing.Size(113, 21);
			this.attackLevel.TabIndex = 3;
			this.attackLevel.ValueChanged += new System.EventHandler(this.attackLevel_ValueChanged);
			// 
			// hitRate
			// 
			this.hitRate.Location = new System.Drawing.Point(93, 16);
			this.hitRate.Name = "hitRate";
			this.hitRate.Size = new System.Drawing.Size(113, 21);
			this.hitRate.TabIndex = 1;
			this.hitRate.ValueChanged += new System.EventHandler(this.hitRate_ValueChanged);
			// 
			// label57
			// 
			this.label57.AutoSize = true;
			this.label57.Location = new System.Drawing.Point(7, 39);
			this.label57.Name = "label57";
			this.label57.Size = new System.Drawing.Size(66, 13);
			this.label57.TabIndex = 2;
			this.label57.Text = "Attack Level";
			// 
			// label58
			// 
			this.label58.AutoSize = true;
			this.label58.Location = new System.Drawing.Point(7, 18);
			this.label58.Name = "label58";
			this.label58.Size = new System.Drawing.Size(57, 13);
			this.label58.TabIndex = 0;
			this.label58.Text = "Hit Rate%";
			// 
			// toolStrip2
			// 
			this.toolStrip2.CanOverflow = false;
			this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nameText});
			this.toolStrip2.Location = new System.Drawing.Point(0, 51);
			this.toolStrip2.Name = "toolStrip2";
			this.toolStrip2.Size = new System.Drawing.Size(209, 25);
			this.toolStrip2.TabIndex = 1;
			// 
			// nameText
			// 
			this.nameText.MaxLength = 13;
			this.nameText.Name = "nameText";
			this.nameText.Size = new System.Drawing.Size(192, 25);
			this.nameText.TextChanged += new System.EventHandler(this.nameText_TextChanged);
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
            this.damageCalculator,
            this.baseConvertor,
            this.helpTips});
			this.toolStrip3.Location = new System.Drawing.Point(0, 0);
			this.toolStrip3.Name = "toolStrip3";
			this.toolStrip3.Size = new System.Drawing.Size(209, 25);
			this.toolStrip3.TabIndex = 6;
			this.toolStrip3.Text = "toolStrip3";
			// 
			// save
			// 
			this.save.Image = global::LazyShell.Properties.Resources.save;
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
			this.import.Image = global::LazyShell.Properties.Resources.importData;
			this.import.Name = "import";
			this.import.Size = new System.Drawing.Size(23, 22);
			this.import.ToolTipText = "Import attack";
			this.import.Click += new System.EventHandler(this.import_Click);
			// 
			// export
			// 
			this.export.Image = global::LazyShell.Properties.Resources.exportData;
			this.export.Name = "export";
			this.export.Size = new System.Drawing.Size(23, 22);
			this.export.ToolTipText = "Export attack";
			this.export.Click += new System.EventHandler(this.export_Click);
			// 
			// reset
			// 
			this.reset.Image = global::LazyShell.Properties.Resources.reset;
			this.reset.Name = "reset";
			this.reset.Size = new System.Drawing.Size(23, 22);
			this.reset.ToolTipText = "Reset attack";
			this.reset.Click += new System.EventHandler(this.reset_Click);
			// 
			// clear
			// 
			this.clear.Image = global::LazyShell.Properties.Resources.clear;
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
			// damageCalculator
			// 
			this.damageCalculator.Image = global::LazyShell.Properties.Resources.calculator;
			this.damageCalculator.Name = "damageCalculator";
			this.damageCalculator.Size = new System.Drawing.Size(23, 22);
			this.damageCalculator.ToolTipText = "Damage Calculator";
			this.damageCalculator.Click += new System.EventHandler(this.damageCalculator_Click);
			// 
			// baseConvertor
			// 
			this.baseConvertor.Image = global::LazyShell.Properties.Resources.baseConversion;
			this.baseConvertor.Name = "baseConvertor";
			this.baseConvertor.Size = new System.Drawing.Size(23, 22);
			this.baseConvertor.ToolTipText = "Show/hide base conversion label";
			// 
			// helpTips
			// 
			this.helpTips.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.helpTips.Image = global::LazyShell.Properties.Resources.about;
			this.helpTips.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.helpTips.Name = "helpTips";
			this.helpTips.Size = new System.Drawing.Size(23, 22);
			this.helpTips.ToolTipText = "Show/hide help tips label";
			// 
			// panelAttackPower
			// 
			this.panelAttackPower.Controls.Add(this.headerLabel2);
			this.panelAttackPower.Controls.Add(this.hitRate);
			this.panelAttackPower.Controls.Add(this.label57);
			this.panelAttackPower.Controls.Add(this.attackLevel);
			this.panelAttackPower.Controls.Add(this.label58);
			this.panelAttackPower.Location = new System.Drawing.Point(0, 76);
			this.panelAttackPower.Margin = new System.Windows.Forms.Padding(1);
			this.panelAttackPower.Name = "panelAttackPower";
			this.panelAttackPower.Padding = new System.Windows.Forms.Padding(1);
			this.panelAttackPower.Size = new System.Drawing.Size(209, 59);
			this.panelAttackPower.TabIndex = 7;
			// 
			// headerLabel2
			// 
			this.headerLabel2.Location = new System.Drawing.Point(0, 0);
			this.headerLabel2.Name = "headerLabel2";
			this.headerLabel2.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
			this.headerLabel2.Size = new System.Drawing.Size(209, 14);
			this.headerLabel2.TabIndex = 7;
			this.headerLabel2.Text = "Attack Power";
			// 
			// panelEffectInflict
			// 
			this.panelEffectInflict.Controls.Add(this.headerLabel1);
			this.panelEffectInflict.Controls.Add(this.statusEffect);
			this.panelEffectInflict.Location = new System.Drawing.Point(0, 136);
			this.panelEffectInflict.Margin = new System.Windows.Forms.Padding(1);
			this.panelEffectInflict.Name = "panelEffectInflict";
			this.panelEffectInflict.Padding = new System.Windows.Forms.Padding(1);
			this.panelEffectInflict.Size = new System.Drawing.Size(209, 84);
			this.panelEffectInflict.TabIndex = 8;
			// 
			// headerLabel1
			// 
			this.headerLabel1.Location = new System.Drawing.Point(0, 0);
			this.headerLabel1.Name = "headerLabel1";
			this.headerLabel1.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
			this.headerLabel1.Size = new System.Drawing.Size(209, 14);
			this.headerLabel1.TabIndex = 8;
			this.headerLabel1.Text = "Effect Inflict";
			// 
			// panelStatusUp
			// 
			this.panelStatusUp.Controls.Add(this.headerLabel3);
			this.panelStatusUp.Controls.Add(this.statusUp);
			this.panelStatusUp.Location = new System.Drawing.Point(0, 221);
			this.panelStatusUp.Margin = new System.Windows.Forms.Padding(1);
			this.panelStatusUp.Name = "panelStatusUp";
			this.panelStatusUp.Padding = new System.Windows.Forms.Padding(1);
			this.panelStatusUp.Size = new System.Drawing.Size(209, 84);
			this.panelStatusUp.TabIndex = 9;
			// 
			// headerLabel3
			// 
			this.headerLabel3.Location = new System.Drawing.Point(0, 0);
			this.headerLabel3.Name = "headerLabel3";
			this.headerLabel3.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
			this.headerLabel3.Size = new System.Drawing.Size(209, 14);
			this.headerLabel3.TabIndex = 9;
			this.headerLabel3.Text = "Status Up";
			// 
			// panelAttackType
			// 
			this.panelAttackType.Controls.Add(this.headerLabel4);
			this.panelAttackType.Controls.Add(this.attackType);
			this.panelAttackType.Location = new System.Drawing.Point(0, 306);
			this.panelAttackType.Name = "panelAttackType";
			this.panelAttackType.Size = new System.Drawing.Size(209, 84);
			this.panelAttackType.TabIndex = 0;
			// 
			// headerLabel4
			// 
			this.headerLabel4.Location = new System.Drawing.Point(0, 0);
			this.headerLabel4.Name = "headerLabel4";
			this.headerLabel4.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
			this.headerLabel4.Size = new System.Drawing.Size(209, 14);
			this.headerLabel4.TabIndex = 9;
			this.headerLabel4.Text = "Attack Type";
			// 
			// OwnerForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(209, 392);
			this.Controls.Add(this.panelAttackType);
			this.Controls.Add(this.panelStatusUp);
			this.Controls.Add(this.panelEffectInflict);
			this.Controls.Add(this.panelAttackPower);
			this.Controls.Add(this.toolStrip2);
			this.Controls.Add(this.toolStrip1);
			this.Controls.Add(this.toolStrip3);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Location = new System.Drawing.Point(5, 5);
			this.MaximizeBox = false;
			this.Name = "OwnerForm";
			this.Text = "Attacks - Lazy Shell";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OwnerForm_FormClosing);
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.attackLevel)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.hitRate)).EndInit();
			this.toolStrip2.ResumeLayout(false);
			this.toolStrip2.PerformLayout();
			this.toolStrip3.ResumeLayout(false);
			this.toolStrip3.PerformLayout();
			this.panelAttackPower.ResumeLayout(false);
			this.panelAttackPower.PerformLayout();
			this.panelEffectInflict.ResumeLayout(false);
			this.panelStatusUp.ResumeLayout(false);
			this.panelAttackType.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

        }
        #endregion
        private System.Windows.Forms.ToolStrip toolStrip1;
        private Controls.NewToolStripComboBox name;
        private System.Windows.Forms.CheckedListBox attackType;
        private System.Windows.Forms.CheckedListBox statusUp;
        private System.Windows.Forms.CheckedListBox statusEffect;
        private System.Windows.Forms.NumericUpDown attackLevel;
        private System.Windows.Forms.NumericUpDown hitRate;
        private System.Windows.Forms.Label label57;
        private System.Windows.Forms.Label label58;
        private Controls.NewToolStripNumericUpDown num;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripTextBox nameText;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripButton save;
        private System.Windows.Forms.ToolStripButton import;
        private System.Windows.Forms.ToolStripButton export;
        private System.Windows.Forms.ToolStripButton reset;
        private System.Windows.Forms.ToolStripButton clear;
        private System.Windows.Forms.ToolStripButton helpTips;
        private System.Windows.Forms.ToolStripButton baseConvertor;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton damageCalculator;
        private System.Windows.Forms.Panel panelAttackPower;
        private System.Windows.Forms.Panel panelEffectInflict;
        private System.Windows.Forms.Panel panelStatusUp;
        private System.Windows.Forms.Panel panelAttackType;
        private Controls.HeaderLabel headerLabel2;
        private Controls.HeaderLabel headerLabel1;
        private Controls.HeaderLabel headerLabel3;
        private Controls.HeaderLabel headerLabel4;
    }
}