namespace LAZYSHELL.Areas
{
    partial class CollisionSwitchesForm
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
            this.label14 = new System.Windows.Forms.Label();
            this.y = new System.Windows.Forms.NumericUpDown();
            this.label67 = new System.Windows.Forms.Label();
            this.label51 = new System.Windows.Forms.Label();
            this.label64 = new System.Windows.Forms.Label();
            this.x = new System.Windows.Forms.NumericUpDown();
            this.width = new System.Windows.Forms.NumericUpDown();
            this.height = new System.Windows.Forms.NumericUpDown();
            this.bytesLeft = new System.Windows.Forms.Label();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.insert = new System.Windows.Forms.ToolStripButton();
            this.delete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
            this.moveUp = new System.Windows.Forms.ToolStripButton();
            this.moveDown = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator14 = new System.Windows.Forms.ToolStripSeparator();
            this.copy = new System.Windows.Forms.ToolStripButton();
            this.paste = new System.Windows.Forms.ToolStripButton();
            this.duplicate = new System.Windows.Forms.ToolStripButton();
            this.listBox = new System.Windows.Forms.ListBox();
            this.headerLabel1 = new LAZYSHELL.Controls.HeaderLabel();
            ((System.ComponentModel.ISupportInitialize)(this.y)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.x)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.width)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.height)).BeginInit();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(132, 68);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(45, 13);
            this.label14.TabIndex = 0;
            this.label14.Text = "X Coord";
            // 
            // y
            // 
            this.y.Location = new System.Drawing.Point(183, 87);
            this.y.Maximum = new decimal(new int[] {
            127,
            0,
            0,
            0});
            this.y.Name = "y";
            this.y.Size = new System.Drawing.Size(79, 21);
            this.y.TabIndex = 3;
            this.y.ValueChanged += new System.EventHandler(this.y_ValueChanged);
            // 
            // label67
            // 
            this.label67.AutoSize = true;
            this.label67.Location = new System.Drawing.Point(132, 131);
            this.label67.Name = "label67";
            this.label67.Size = new System.Drawing.Size(38, 13);
            this.label67.TabIndex = 6;
            this.label67.Text = "Height";
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.Location = new System.Drawing.Point(132, 89);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(45, 13);
            this.label51.TabIndex = 2;
            this.label51.Text = "Y Coord";
            // 
            // label64
            // 
            this.label64.AutoSize = true;
            this.label64.Location = new System.Drawing.Point(132, 110);
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size(40, 13);
            this.label64.TabIndex = 4;
            this.label64.Text = "Length";
            // 
            // x
            // 
            this.x.Location = new System.Drawing.Point(183, 66);
            this.x.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.x.Name = "x";
            this.x.Size = new System.Drawing.Size(79, 21);
            this.x.TabIndex = 1;
            this.x.ValueChanged += new System.EventHandler(this.x_ValueChanged);
            // 
            // width
            // 
            this.width.Location = new System.Drawing.Point(183, 108);
            this.width.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.width.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.width.Name = "width";
            this.width.Size = new System.Drawing.Size(79, 21);
            this.width.TabIndex = 5;
            this.width.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.width.ValueChanged += new System.EventHandler(this.width_ValueChanged);
            // 
            // height
            // 
            this.height.Location = new System.Drawing.Point(183, 129);
            this.height.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.height.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.height.Name = "height";
            this.height.Size = new System.Drawing.Size(79, 21);
            this.height.TabIndex = 7;
            this.height.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.height.ValueChanged += new System.EventHandler(this.height_ValueChanged);
            // 
            // bytesLeft
            // 
            this.bytesLeft.AutoSize = true;
            this.bytesLeft.Location = new System.Drawing.Point(132, 28);
            this.bytesLeft.Name = "bytesLeft";
            this.bytesLeft.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.bytesLeft.Size = new System.Drawing.Size(55, 16);
            this.bytesLeft.TabIndex = 7;
            this.bytesLeft.Text = "bytes left";
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.insert,
            this.delete,
            this.toolStripSeparator13,
            this.moveUp,
            this.moveDown,
            this.toolStripSeparator14,
            this.copy,
            this.paste,
            this.duplicate});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(262, 25);
            this.toolStrip.TabIndex = 5;
            // 
            // insert
            // 
            this.insert.Image = global::LAZYSHELL.Properties.Resources.new_file;
            this.insert.Name = "insert";
            this.insert.Size = new System.Drawing.Size(23, 22);
            this.insert.ToolTipText = "New Collision Mod";
            this.insert.Click += new System.EventHandler(this.insert_Click);
            // 
            // delete
            // 
            this.delete.Image = global::LAZYSHELL.Properties.Resources.delete;
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(23, 22);
            this.delete.ToolTipText = "Delete Collision Mod";
            this.delete.Click += new System.EventHandler(this.delete_Click);
            // 
            // toolStripSeparator13
            // 
            this.toolStripSeparator13.Name = "toolStripSeparator13";
            this.toolStripSeparator13.Size = new System.Drawing.Size(6, 25);
            // 
            // moveUp
            // 
            this.moveUp.Image = global::LAZYSHELL.Properties.Resources.moveup;
            this.moveUp.Name = "moveUp";
            this.moveUp.Size = new System.Drawing.Size(23, 22);
            this.moveUp.ToolTipText = "Move Collision Mod Up";
            this.moveUp.Click += new System.EventHandler(this.moveUp_Click);
            // 
            // moveDown
            // 
            this.moveDown.Image = global::LAZYSHELL.Properties.Resources.movedown;
            this.moveDown.Name = "moveDown";
            this.moveDown.Size = new System.Drawing.Size(23, 22);
            this.moveDown.ToolTipText = "Move Collision Mod Down";
            this.moveDown.Click += new System.EventHandler(this.moveDown_Click);
            // 
            // toolStripSeparator14
            // 
            this.toolStripSeparator14.Name = "toolStripSeparator14";
            this.toolStripSeparator14.Size = new System.Drawing.Size(6, 25);
            // 
            // copy
            // 
            this.copy.Image = global::LAZYSHELL.Properties.Resources.copy;
            this.copy.Name = "copy";
            this.copy.Size = new System.Drawing.Size(23, 22);
            this.copy.ToolTipText = "Copy Collision Mod";
            this.copy.Click += new System.EventHandler(this.copy_Click);
            // 
            // paste
            // 
            this.paste.Image = global::LAZYSHELL.Properties.Resources.paste;
            this.paste.Name = "paste";
            this.paste.Size = new System.Drawing.Size(23, 22);
            this.paste.ToolTipText = "Paste Collision Mod";
            this.paste.Click += new System.EventHandler(this.paste_Click);
            // 
            // duplicate
            // 
            this.duplicate.Image = global::LAZYSHELL.Properties.Resources.duplicate;
            this.duplicate.Name = "duplicate";
            this.duplicate.Size = new System.Drawing.Size(23, 22);
            this.duplicate.ToolTipText = "Duplicate Collision Mod";
            this.duplicate.Click += new System.EventHandler(this.duplicate_Click);
            // 
            // listBox
            // 
            this.listBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.listBox.FormattingEnabled = true;
            this.listBox.Location = new System.Drawing.Point(0, 25);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(126, 127);
            this.listBox.TabIndex = 9;
            this.listBox.SelectedIndexChanged += new System.EventHandler(this.listBox_SelectedIndexChanged);
            // 
            // headerLabel1
            // 
            this.headerLabel1.Location = new System.Drawing.Point(126, 49);
            this.headerLabel1.Name = "headerLabel1";
            this.headerLabel1.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.headerLabel1.Size = new System.Drawing.Size(136, 14);
            this.headerLabel1.TabIndex = 10;
            this.headerLabel1.Text = "Coordinates";
            // 
            // CollisionSwitchesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(262, 152);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.y);
            this.Controls.Add(this.label67);
            this.Controls.Add(this.label51);
            this.Controls.Add(this.label64);
            this.Controls.Add(this.x);
            this.Controls.Add(this.width);
            this.Controls.Add(this.height);
            this.Controls.Add(this.headerLabel1);
            this.Controls.Add(this.listBox);
            this.Controls.Add(this.bytesLeft);
            this.Controls.Add(this.toolStrip);
            this.DockAreas = ((WeifenLuo.WinFormsUI.Docking.DockAreas)(((WeifenLuo.WinFormsUI.Docking.DockAreas.Float | WeifenLuo.WinFormsUI.Docking.DockAreas.DockLeft) 
            | WeifenLuo.WinFormsUI.Docking.DockAreas.DockRight)));
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "CollisionSwitchesForm";
            this.Text = "Collision Switches";
            ((System.ComponentModel.ISupportInitialize)(this.y)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.x)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.width)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.height)).EndInit();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.NumericUpDown y;
        private System.Windows.Forms.Label label67;
        private System.Windows.Forms.Label label51;
        private System.Windows.Forms.Label label64;
        private System.Windows.Forms.NumericUpDown x;
        private System.Windows.Forms.NumericUpDown width;
        private System.Windows.Forms.NumericUpDown height;
        private System.Windows.Forms.Label bytesLeft;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton insert;
        private System.Windows.Forms.ToolStripButton delete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator13;
        private System.Windows.Forms.ToolStripButton moveUp;
        private System.Windows.Forms.ToolStripButton moveDown;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator14;
        private System.Windows.Forms.ToolStripButton copy;
        private System.Windows.Forms.ToolStripButton paste;
        private System.Windows.Forms.ToolStripButton duplicate;
        private System.Windows.Forms.ListBox listBox;
        private Controls.HeaderLabel headerLabel1;
    }
}