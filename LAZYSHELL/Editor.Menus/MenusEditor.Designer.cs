namespace LAZYSHELL
{
    partial class MenusEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenusEditor));
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.save = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.menuTextName = new System.Windows.Forms.ToolStripComboBox();
            this.menuTextNum = new LAZYSHELL.ToolStripNumericUpDown();
            this.textView = new System.Windows.Forms.ToolStripButton();
            this.menuTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.charactersLeft = new System.Windows.Forms.ToolStripLabel();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(792, 322);
            this.panel1.TabIndex = 1;
            // 
            // toolStrip2
            // 
            this.toolStrip2.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.save,
            this.toolStripSeparator1,
            this.toolStripLabel1,
            this.menuTextName,
            this.menuTextNum,
            this.textView,
            this.menuTextBox,
            this.charactersLeft});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip2.Size = new System.Drawing.Size(792, 25);
            this.toolStrip2.TabIndex = 0;
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
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(38, 22);
            this.toolStripLabel1.Text = " TEXT ";
            // 
            // menuTextName
            // 
            this.menuTextName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.menuTextName.DropDownWidth = 300;
            this.menuTextName.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.menuTextName.Name = "menuTextName";
            this.menuTextName.Size = new System.Drawing.Size(200, 25);
            this.menuTextName.SelectedIndexChanged += new System.EventHandler(this.menuTextName_SelectedIndexChanged);
            // 
            // menuTextNum
            // 
            this.menuTextNum.AutoSize = false;
            this.menuTextNum.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuTextNum.Hexadecimal = false;
            this.menuTextNum.Location = new System.Drawing.Point(276, 1);
            this.menuTextNum.Maximum = new decimal(new int[] {
            117,
            0,
            0,
            0});
            this.menuTextNum.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.menuTextNum.Name = "menuTextNum";
            this.menuTextNum.Size = new System.Drawing.Size(50, 22);
            this.menuTextNum.Text = "0";
            this.menuTextNum.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.menuTextNum.ValueChanged += new System.EventHandler(this.menuTextNum_ValueChanged);
            // 
            // textView
            // 
            this.textView.CheckOnClick = true;
            this.textView.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.textView.Image = global::LAZYSHELL.Properties.Resources.textView;
            this.textView.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.textView.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.textView.Name = "textView";
            this.textView.Size = new System.Drawing.Size(23, 22);
            this.textView.Text = "Text View";
            this.textView.Visible = false;
            this.textView.CheckedChanged += new System.EventHandler(this.textView_CheckedChanged);
            // 
            // menuTextBox
            // 
            this.menuTextBox.Name = "menuTextBox";
            this.menuTextBox.Size = new System.Drawing.Size(300, 25);
            this.menuTextBox.TextChanged += new System.EventHandler(this.menuTextBox_TextChanged);
            // 
            // charactersLeft
            // 
            this.charactersLeft.Name = "charactersLeft";
            this.charactersLeft.Size = new System.Drawing.Size(84, 22);
            this.charactersLeft.Text = "  characters left";
            // 
            // MenusEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 347);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip2);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(5, 5);
            this.Name = "MenusEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "MENUS - Lazy Shell";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MenusEditor_FormClosing);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripComboBox menuTextName;
        private System.Windows.Forms.ToolStripLabel charactersLeft;
        private System.Windows.Forms.ToolStripTextBox menuTextBox;
        private System.Windows.Forms.ToolStripButton textView;
        private ToolStripNumericUpDown menuTextNum;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton save;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}