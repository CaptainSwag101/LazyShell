namespace LAZYSHELL
{
    partial class Attacks
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.attackName = new LAZYSHELL.ToolStripComboBox();
            this.attackNum = new LAZYSHELL.ToolStripNumericUpDown();
            this.TextBoxMonsterName = new System.Windows.Forms.ToolStripTextBox();
            this.panel169 = new System.Windows.Forms.Panel();
            this.panel166 = new System.Windows.Forms.Panel();
            this.label54 = new System.Windows.Forms.Label();
            this.attackAtkType = new System.Windows.Forms.CheckedListBox();
            this.panel168 = new System.Windows.Forms.Panel();
            this.panel165 = new System.Windows.Forms.Panel();
            this.label53 = new System.Windows.Forms.Label();
            this.attackStatusUp = new System.Windows.Forms.CheckedListBox();
            this.panel167 = new System.Windows.Forms.Panel();
            this.panel164 = new System.Windows.Forms.Panel();
            this.label52 = new System.Windows.Forms.Label();
            this.attackStatusEffect = new System.Windows.Forms.CheckedListBox();
            this.panel162 = new System.Windows.Forms.Panel();
            this.panel85 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.attackAtkLevel = new System.Windows.Forms.NumericUpDown();
            this.attackHitRate = new System.Windows.Forms.NumericUpDown();
            this.label57 = new System.Windows.Forms.Label();
            this.label58 = new System.Windows.Forms.Label();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.textBoxAttackName = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.panel169.SuspendLayout();
            this.panel166.SuspendLayout();
            this.panel168.SuspendLayout();
            this.panel165.SuspendLayout();
            this.panel167.SuspendLayout();
            this.panel164.SuspendLayout();
            this.panel162.SuspendLayout();
            this.panel85.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.attackAtkLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.attackHitRate)).BeginInit();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.CanOverflow = false;
            this.toolStrip1.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.attackName,
            this.attackNum,
            this.TextBoxMonsterName});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(203, 25);
            this.toolStrip1.TabIndex = 472;
            // 
            // attackName
            // 
            this.attackName.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.attackName.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.attackName.DropDownHeight = 506;
            this.attackName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.attackName.DropDownWidth = 200;
            this.attackName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.attackName.ForeColor = System.Drawing.SystemColors.Control;
            this.attackName.ItemHeight = 15;
            this.attackName.Location = new System.Drawing.Point(7, 1);
            this.attackName.Name = "attackName";
            this.attackName.SelectedIndex = -1;
            this.attackName.SelectedItem = null;
            this.attackName.Size = new System.Drawing.Size(146, 22);
            this.attackName.SelectedIndexChanged += new System.EventHandler(this.attackName_SelectedIndexChanged);
            this.attackName.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.attackName_DrawItem);
            // 
            // attackNum
            // 
            this.attackNum.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.attackNum.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.attackNum.ForeColor = System.Drawing.SystemColors.Control;
            this.attackNum.Hexadecimal = false;
            this.attackNum.Location = new System.Drawing.Point(153, 1);
            this.attackNum.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.attackNum.Name = "attackNum";
            this.attackNum.Size = new System.Drawing.Size(48, 22);
            this.attackNum.Text = "0";
            this.attackNum.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.attackNum.ValueChanged += new System.EventHandler(this.attackNum_ValueChanged);
            // 
            // TextBoxMonsterName
            // 
            this.TextBoxMonsterName.Name = "TextBoxMonsterName";
            this.TextBoxMonsterName.Size = new System.Drawing.Size(130, 25);
            // 
            // panel169
            // 
            this.panel169.BackColor = System.Drawing.SystemColors.ControlText;
            this.panel169.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel169.Controls.Add(this.panel166);
            this.panel169.Location = new System.Drawing.Point(12, 351);
            this.panel169.Name = "panel169";
            this.panel169.Size = new System.Drawing.Size(179, 87);
            this.panel169.TabIndex = 476;
            // 
            // panel166
            // 
            this.panel166.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.panel166.Controls.Add(this.label54);
            this.panel166.Controls.Add(this.attackAtkType);
            this.panel166.Location = new System.Drawing.Point(0, 0);
            this.panel166.Name = "panel166";
            this.panel166.Size = new System.Drawing.Size(175, 83);
            this.panel166.TabIndex = 514;
            // 
            // label54
            // 
            this.label54.BackColor = System.Drawing.SystemColors.Control;
            this.label54.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label54.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label54.Location = new System.Drawing.Point(0, 0);
            this.label54.Name = "label54";
            this.label54.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.label54.Size = new System.Drawing.Size(175, 17);
            this.label54.TabIndex = 487;
            this.label54.Text = "ATTACK TYPE";
            this.label54.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // attackAtkType
            // 
            this.attackAtkType.BackColor = System.Drawing.SystemColors.Window;
            this.attackAtkType.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.attackAtkType.CheckOnClick = true;
            this.attackAtkType.Items.AddRange(new object[] {
            "9999 Damage",
            "No damage",
            "Hide Battle Numerals",
            "No damage"});
            this.attackAtkType.Location = new System.Drawing.Point(0, 19);
            this.attackAtkType.Name = "attackAtkType";
            this.attackAtkType.Size = new System.Drawing.Size(175, 64);
            this.attackAtkType.TabIndex = 127;
            this.attackAtkType.SelectedIndexChanged += new System.EventHandler(this.attackAtkType_SelectedIndexChanged);
            // 
            // panel168
            // 
            this.panel168.BackColor = System.Drawing.SystemColors.ControlText;
            this.panel168.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel168.Controls.Add(this.panel165);
            this.panel168.Location = new System.Drawing.Point(12, 258);
            this.panel168.Name = "panel168";
            this.panel168.Size = new System.Drawing.Size(179, 87);
            this.panel168.TabIndex = 475;
            // 
            // panel165
            // 
            this.panel165.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.panel165.Controls.Add(this.label53);
            this.panel165.Controls.Add(this.attackStatusUp);
            this.panel165.Location = new System.Drawing.Point(0, 0);
            this.panel165.Name = "panel165";
            this.panel165.Size = new System.Drawing.Size(175, 83);
            this.panel165.TabIndex = 513;
            // 
            // label53
            // 
            this.label53.BackColor = System.Drawing.SystemColors.Control;
            this.label53.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label53.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label53.Location = new System.Drawing.Point(0, 0);
            this.label53.Name = "label53";
            this.label53.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.label53.Size = new System.Drawing.Size(175, 17);
            this.label53.TabIndex = 188;
            this.label53.Text = "STATUS UP";
            this.label53.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // attackStatusUp
            // 
            this.attackStatusUp.BackColor = System.Drawing.SystemColors.Window;
            this.attackStatusUp.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.attackStatusUp.CheckOnClick = true;
            this.attackStatusUp.Items.AddRange(new object[] {
            "Attack",
            "Defense",
            "Magic Attack",
            "Magic Defense"});
            this.attackStatusUp.Location = new System.Drawing.Point(0, 19);
            this.attackStatusUp.Name = "attackStatusUp";
            this.attackStatusUp.Size = new System.Drawing.Size(175, 64);
            this.attackStatusUp.TabIndex = 126;
            this.attackStatusUp.SelectedIndexChanged += new System.EventHandler(this.attackStatusUp_SelectedIndexChanged);
            // 
            // panel167
            // 
            this.panel167.BackColor = System.Drawing.SystemColors.ControlText;
            this.panel167.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel167.Controls.Add(this.panel164);
            this.panel167.Location = new System.Drawing.Point(12, 117);
            this.panel167.Name = "panel167";
            this.panel167.Size = new System.Drawing.Size(179, 135);
            this.panel167.TabIndex = 474;
            // 
            // panel164
            // 
            this.panel164.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.panel164.Controls.Add(this.label52);
            this.panel164.Controls.Add(this.attackStatusEffect);
            this.panel164.Location = new System.Drawing.Point(0, 0);
            this.panel164.Name = "panel164";
            this.panel164.Size = new System.Drawing.Size(175, 131);
            this.panel164.TabIndex = 512;
            // 
            // label52
            // 
            this.label52.BackColor = System.Drawing.SystemColors.Control;
            this.label52.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label52.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label52.Location = new System.Drawing.Point(0, 0);
            this.label52.Name = "label52";
            this.label52.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.label52.Size = new System.Drawing.Size(175, 17);
            this.label52.TabIndex = 187;
            this.label52.Text = "EFFECT INFLICT";
            this.label52.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // attackStatusEffect
            // 
            this.attackStatusEffect.BackColor = System.Drawing.SystemColors.Window;
            this.attackStatusEffect.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.attackStatusEffect.CheckOnClick = true;
            this.attackStatusEffect.ColumnWidth = 97;
            this.attackStatusEffect.Items.AddRange(new object[] {
            "Mute",
            "Sleep",
            "Poison",
            "Fear",
            "Mushroom",
            "Scarecrow",
            "Invincible"});
            this.attackStatusEffect.Location = new System.Drawing.Point(0, 19);
            this.attackStatusEffect.Name = "attackStatusEffect";
            this.attackStatusEffect.Size = new System.Drawing.Size(175, 112);
            this.attackStatusEffect.TabIndex = 125;
            this.attackStatusEffect.SelectedIndexChanged += new System.EventHandler(this.attackStatusEffect_SelectedIndexChanged);
            // 
            // panel162
            // 
            this.panel162.BackColor = System.Drawing.SystemColors.ControlText;
            this.panel162.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel162.Controls.Add(this.panel85);
            this.panel162.Location = new System.Drawing.Point(12, 53);
            this.panel162.Name = "panel162";
            this.panel162.Size = new System.Drawing.Size(179, 58);
            this.panel162.TabIndex = 473;
            // 
            // panel85
            // 
            this.panel85.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.panel85.Controls.Add(this.label11);
            this.panel85.Controls.Add(this.attackAtkLevel);
            this.panel85.Controls.Add(this.attackHitRate);
            this.panel85.Controls.Add(this.label57);
            this.panel85.Controls.Add(this.label58);
            this.panel85.Location = new System.Drawing.Point(0, 0);
            this.panel85.Name = "panel85";
            this.panel85.Size = new System.Drawing.Size(175, 54);
            this.panel85.TabIndex = 123;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.SystemColors.Control;
            this.label11.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label11.Location = new System.Drawing.Point(0, 0);
            this.label11.Name = "label11";
            this.label11.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.label11.Size = new System.Drawing.Size(175, 17);
            this.label11.TabIndex = 190;
            this.label11.Text = "STATS";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // attackAtkLevel
            // 
            this.attackAtkLevel.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.attackAtkLevel.Location = new System.Drawing.Point(100, 37);
            this.attackAtkLevel.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.attackAtkLevel.Name = "attackAtkLevel";
            this.attackAtkLevel.Size = new System.Drawing.Size(76, 17);
            this.attackAtkLevel.TabIndex = 124;
            this.attackAtkLevel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.attackAtkLevel.ValueChanged += new System.EventHandler(this.attackAtkLevel_ValueChanged);
            // 
            // attackHitRate
            // 
            this.attackHitRate.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.attackHitRate.Location = new System.Drawing.Point(100, 19);
            this.attackHitRate.Name = "attackHitRate";
            this.attackHitRate.Size = new System.Drawing.Size(76, 17);
            this.attackHitRate.TabIndex = 123;
            this.attackHitRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.attackHitRate.ValueChanged += new System.EventHandler(this.attackHitRate_ValueChanged);
            // 
            // label57
            // 
            this.label57.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label57.Location = new System.Drawing.Point(0, 37);
            this.label57.Name = "label57";
            this.label57.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label57.Size = new System.Drawing.Size(99, 17);
            this.label57.TabIndex = 182;
            this.label57.Text = "Attack Level";
            // 
            // label58
            // 
            this.label58.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label58.Location = new System.Drawing.Point(0, 19);
            this.label58.Name = "label58";
            this.label58.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label58.Size = new System.Drawing.Size(99, 17);
            this.label58.TabIndex = 181;
            this.label58.Text = "Hit Rate%";
            // 
            // toolStrip2
            // 
            this.toolStrip2.CanOverflow = false;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.textBoxAttackName,
            this.toolStripButton1});
            this.toolStrip2.Location = new System.Drawing.Point(0, 25);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip2.Size = new System.Drawing.Size(203, 25);
            this.toolStrip2.TabIndex = 477;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // textBoxAttackName
            // 
            this.textBoxAttackName.MaxLength = 13;
            this.textBoxAttackName.Name = "textBoxAttackName";
            this.textBoxAttackName.Size = new System.Drawing.Size(144, 25);
            this.textBoxAttackName.TextChanged += new System.EventHandler(this.textBoxAttackName_TextChanged);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::LAZYSHELL.Properties.Resources.label;
            this.toolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            // 
            // Attacks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(203, 450);
            this.ControlBox = false;
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.panel169);
            this.Controls.Add(this.panel168);
            this.Controls.Add(this.panel167);
            this.Controls.Add(this.panel162);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Attacks";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel169.ResumeLayout(false);
            this.panel166.ResumeLayout(false);
            this.panel168.ResumeLayout(false);
            this.panel165.ResumeLayout(false);
            this.panel167.ResumeLayout(false);
            this.panel164.ResumeLayout(false);
            this.panel162.ResumeLayout(false);
            this.panel85.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.attackAtkLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.attackHitRate)).EndInit();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private LAZYSHELL.ToolStripComboBox attackName;
        private System.Windows.Forms.ToolStripTextBox TextBoxMonsterName;
        private System.Windows.Forms.Panel panel169;
        private System.Windows.Forms.Panel panel166;
        private System.Windows.Forms.Label label54;
        private System.Windows.Forms.CheckedListBox attackAtkType;
        private System.Windows.Forms.Panel panel168;
        private System.Windows.Forms.Panel panel165;
        private System.Windows.Forms.Label label53;
        private System.Windows.Forms.CheckedListBox attackStatusUp;
        private System.Windows.Forms.Panel panel167;
        private System.Windows.Forms.Panel panel164;
        private System.Windows.Forms.Label label52;
        private System.Windows.Forms.CheckedListBox attackStatusEffect;
        private System.Windows.Forms.Panel panel162;
        private System.Windows.Forms.Panel panel85;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown attackAtkLevel;
        private System.Windows.Forms.NumericUpDown attackHitRate;
        private System.Windows.Forms.Label label57;
        private System.Windows.Forms.Label label58;
        private ToolStripNumericUpDown attackNum;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripTextBox textBoxAttackName;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
    }
}