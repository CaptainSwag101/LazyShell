namespace LazyShell.Areas
{
    partial class ExitsForm
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
            this.destF = new System.Windows.Forms.ComboBox();
            this.type = new System.Windows.Forms.ComboBox();
            this.destZ_Half = new System.Windows.Forms.CheckBox();
            this.destination = new System.Windows.Forms.ComboBox();
            this.label59 = new System.Windows.Forms.Label();
            this.destY = new System.Windows.Forms.NumericUpDown();
            this.showBanner = new System.Windows.Forms.CheckBox();
            this.label124 = new System.Windows.Forms.Label();
            this.label122 = new System.Windows.Forms.Label();
            this.destZ = new System.Windows.Forms.NumericUpDown();
            this.destX = new System.Windows.Forms.NumericUpDown();
            this.y_half = new System.Windows.Forms.CheckBox();
            this.label119 = new System.Windows.Forms.Label();
            this.y = new System.Windows.Forms.NumericUpDown();
            this.f = new System.Windows.Forms.ComboBox();
            this.x = new System.Windows.Forms.NumericUpDown();
            this.height = new System.Windows.Forms.NumericUpDown();
            this.x_half = new System.Windows.Forms.CheckBox();
            this.z = new System.Windows.Forms.NumericUpDown();
            this.label57 = new System.Windows.Forms.Label();
            this.label105 = new System.Windows.Forms.Label();
            this.width = new System.Windows.Forms.NumericUpDown();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.insert = new System.Windows.Forms.ToolStripButton();
            this.delete = new System.Windows.Forms.ToolStripButton();
            this.copy = new System.Windows.Forms.ToolStripButton();
            this.paste = new System.Windows.Forms.ToolStripButton();
            this.duplicate = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator19 = new System.Windows.Forms.ToolStripSeparator();
            this.bytesLeft = new System.Windows.Forms.ToolStripLabel();
            this.listBox = new System.Windows.Forms.ListBox();
            this.headerLabel1 = new LazyShell.Controls.HeaderLabel();
            this.headerLabel2 = new LazyShell.Controls.HeaderLabel();
            ((System.ComponentModel.ISupportInitialize)(this.destY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.destZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.destX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.y)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.x)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.height)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.z)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.width)).BeginInit();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // destF
            // 
            this.destF.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.destF.Items.AddRange(new object[] {
            "E",
            "SE",
            "S",
            "SW",
            "W",
            "NW",
            "N",
            "NE"});
            this.destF.Location = new System.Drawing.Point(170, 295);
            this.destF.Name = "destF";
            this.destF.Size = new System.Drawing.Size(45, 21);
            this.destF.TabIndex = 7;
            this.destF.SelectedIndexChanged += new System.EventHandler(this.dest_F_SelectedIndexChanged);
            // 
            // type
            // 
            this.type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.type.DropDownWidth = 80;
            this.type.Items.AddRange(new object[] {
            "Area",
            "Location"});
            this.type.Location = new System.Drawing.Point(132, 177);
            this.type.Name = "type";
            this.type.Size = new System.Drawing.Size(128, 21);
            this.type.TabIndex = 3;
            this.type.SelectedIndexChanged += new System.EventHandler(this.type_SelectedIndexChanged);
            // 
            // destZ_Half
            // 
            this.destZ_Half.Appearance = System.Windows.Forms.Appearance.Button;
            this.destZ_Half.BackColor = System.Drawing.SystemColors.Control;
            this.destZ_Half.FlatAppearance.BorderSize = 0;
            this.destZ_Half.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.destZ_Half.ForeColor = System.Drawing.Color.Gray;
            this.destZ_Half.Location = new System.Drawing.Point(216, 275);
            this.destZ_Half.Name = "destZ_Half";
            this.destZ_Half.Size = new System.Drawing.Size(43, 19);
            this.destZ_Half.TabIndex = 5;
            this.destZ_Half.Text = "+1/2";
            this.destZ_Half.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.destZ_Half.UseCompatibleTextRendering = true;
            this.destZ_Half.UseVisualStyleBackColor = false;
            this.destZ_Half.CheckedChanged += new System.EventHandler(this.destZ_Half_CheckedChanged);
            // 
            // destination
            // 
            this.destination.DropDownHeight = 431;
            this.destination.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.destination.DropDownWidth = 490;
            this.destination.IntegralHeight = false;
            this.destination.Items.AddRange(new object[] {
            ""});
            this.destination.Location = new System.Drawing.Point(132, 201);
            this.destination.Name = "destination";
            this.destination.Size = new System.Drawing.Size(128, 21);
            this.destination.TabIndex = 0;
            this.destination.SelectedIndexChanged += new System.EventHandler(this.destination_SelectedIndexChanged);
            // 
            // label59
            // 
            this.label59.AutoSize = true;
            this.label59.Location = new System.Drawing.Point(132, 255);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(23, 13);
            this.label59.TabIndex = 0;
            this.label59.Text = "X,Y";
            // 
            // destY
            // 
            this.destY.Location = new System.Drawing.Point(215, 253);
            this.destY.Maximum = new decimal(new int[] {
            127,
            0,
            0,
            0});
            this.destY.Name = "destY";
            this.destY.Size = new System.Drawing.Size(45, 21);
            this.destY.TabIndex = 2;
            this.destY.ValueChanged += new System.EventHandler(this.destY_ValueChanged);
            // 
            // showBanner
            // 
            this.showBanner.Appearance = System.Windows.Forms.Appearance.Button;
            this.showBanner.BackColor = System.Drawing.SystemColors.Control;
            this.showBanner.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showBanner.ForeColor = System.Drawing.Color.Gray;
            this.showBanner.Location = new System.Drawing.Point(132, 226);
            this.showBanner.Name = "showBanner";
            this.showBanner.Size = new System.Drawing.Size(128, 21);
            this.showBanner.TabIndex = 1;
            this.showBanner.Text = "SHOW BANNER";
            this.showBanner.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.showBanner.UseCompatibleTextRendering = true;
            this.showBanner.UseVisualStyleBackColor = false;
            this.showBanner.CheckedChanged += new System.EventHandler(this.showBanner_CheckedChanged);
            // 
            // label124
            // 
            this.label124.AutoSize = true;
            this.label124.Location = new System.Drawing.Point(132, 298);
            this.label124.Name = "label124";
            this.label124.Size = new System.Drawing.Size(13, 13);
            this.label124.TabIndex = 6;
            this.label124.Text = "F";
            // 
            // label122
            // 
            this.label122.AutoSize = true;
            this.label122.Location = new System.Drawing.Point(132, 276);
            this.label122.Name = "label122";
            this.label122.Size = new System.Drawing.Size(13, 13);
            this.label122.TabIndex = 3;
            this.label122.Text = "Z";
            // 
            // destZ
            // 
            this.destZ.Location = new System.Drawing.Point(170, 274);
            this.destZ.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.destZ.Name = "destZ";
            this.destZ.Size = new System.Drawing.Size(45, 21);
            this.destZ.TabIndex = 4;
            this.destZ.ValueChanged += new System.EventHandler(this.destZ_ValueChanged);
            // 
            // destX
            // 
            this.destX.Location = new System.Drawing.Point(170, 253);
            this.destX.Maximum = new decimal(new int[] {
            63,
            0,
            0,
            0});
            this.destX.Name = "destX";
            this.destX.Size = new System.Drawing.Size(45, 21);
            this.destX.TabIndex = 1;
            this.destX.ValueChanged += new System.EventHandler(this.destX_ValueChanged);
            // 
            // y_half
            // 
            this.y_half.Appearance = System.Windows.Forms.Appearance.Button;
            this.y_half.BackColor = System.Drawing.SystemColors.Control;
            this.y_half.FlatAppearance.BorderSize = 0;
            this.y_half.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.y_half.ForeColor = System.Drawing.Color.Gray;
            this.y_half.Location = new System.Drawing.Point(132, 136);
            this.y_half.Name = "y_half";
            this.y_half.Size = new System.Drawing.Size(128, 21);
            this.y_half.TabIndex = 16;
            this.y_half.Text = "NE/SW edge active";
            this.y_half.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.y_half.UseCompatibleTextRendering = true;
            this.y_half.UseVisualStyleBackColor = false;
            this.y_half.CheckedChanged += new System.EventHandler(this.y_half_CheckedChanged);
            // 
            // label119
            // 
            this.label119.AutoSize = true;
            this.label119.Location = new System.Drawing.Point(132, 44);
            this.label119.Name = "label119";
            this.label119.Size = new System.Drawing.Size(23, 13);
            this.label119.TabIndex = 4;
            this.label119.Text = "X,Y";
            // 
            // y
            // 
            this.y.Location = new System.Drawing.Point(215, 42);
            this.y.Maximum = new decimal(new int[] {
            127,
            0,
            0,
            0});
            this.y.Name = "y";
            this.y.Size = new System.Drawing.Size(45, 21);
            this.y.TabIndex = 6;
            this.y.ValueChanged += new System.EventHandler(this.y_ValueChanged);
            // 
            // f
            // 
            this.f.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.f.Items.AddRange(new object[] {
            "SE",
            "SW"});
            this.f.Location = new System.Drawing.Point(215, 63);
            this.f.Name = "f";
            this.f.Size = new System.Drawing.Size(45, 21);
            this.f.TabIndex = 14;
            this.f.SelectedIndexChanged += new System.EventHandler(this.f_SelectedIndexChanged);
            // 
            // x
            // 
            this.x.Location = new System.Drawing.Point(170, 42);
            this.x.Maximum = new decimal(new int[] {
            63,
            0,
            0,
            0});
            this.x.Name = "x";
            this.x.Size = new System.Drawing.Size(45, 21);
            this.x.TabIndex = 5;
            this.x.ValueChanged += new System.EventHandler(this.x_ValueChanged);
            // 
            // height
            // 
            this.height.Location = new System.Drawing.Point(215, 84);
            this.height.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.height.Name = "height";
            this.height.Size = new System.Drawing.Size(45, 21);
            this.height.TabIndex = 12;
            this.height.ValueChanged += new System.EventHandler(this.height_ValueChanged);
            // 
            // x_half
            // 
            this.x_half.Appearance = System.Windows.Forms.Appearance.Button;
            this.x_half.BackColor = System.Drawing.SystemColors.Control;
            this.x_half.FlatAppearance.BorderSize = 0;
            this.x_half.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.x_half.ForeColor = System.Drawing.Color.Gray;
            this.x_half.Location = new System.Drawing.Point(132, 111);
            this.x_half.Name = "x_half";
            this.x_half.Size = new System.Drawing.Size(128, 21);
            this.x_half.TabIndex = 15;
            this.x_half.Text = "NW/SE edge active";
            this.x_half.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.x_half.UseCompatibleTextRendering = true;
            this.x_half.UseVisualStyleBackColor = false;
            this.x_half.CheckedChanged += new System.EventHandler(this.x_half_CheckedChanged);
            // 
            // z
            // 
            this.z.Location = new System.Drawing.Point(170, 63);
            this.z.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.z.Name = "z";
            this.z.Size = new System.Drawing.Size(45, 21);
            this.z.TabIndex = 8;
            this.z.ValueChanged += new System.EventHandler(this.z_ValueChanged);
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.label57.Location = new System.Drawing.Point(132, 65);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(23, 13);
            this.label57.TabIndex = 7;
            this.label57.Text = "Z,F";
            // 
            // label105
            // 
            this.label105.AutoSize = true;
            this.label105.Location = new System.Drawing.Point(132, 86);
            this.label105.Name = "label105";
            this.label105.Size = new System.Drawing.Size(28, 13);
            this.label105.TabIndex = 9;
            this.label105.Text = "W/H";
            // 
            // width
            // 
            this.width.Location = new System.Drawing.Point(170, 84);
            this.width.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.width.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.width.Name = "width";
            this.width.Size = new System.Drawing.Size(45, 21);
            this.width.TabIndex = 10;
            this.width.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.width.ValueChanged += new System.EventHandler(this.width_ValueChanged);
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.insert,
            this.delete,
            this.copy,
            this.paste,
            this.duplicate,
            this.toolStripSeparator19,
            this.bytesLeft});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(262, 25);
            this.toolStrip.TabIndex = 1;
            // 
            // insert
            // 
            this.insert.Image = global::LazyShell.Properties.Resources.exitAdd;
            this.insert.Name = "insert";
            this.insert.Size = new System.Drawing.Size(23, 22);
            this.insert.ToolTipText = "New Exit";
            this.insert.Click += new System.EventHandler(this.insert_Click);
            // 
            // delete
            // 
            this.delete.Image = global::LazyShell.Properties.Resources.exitRemove;
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(23, 22);
            this.delete.ToolTipText = "Delete Exit";
            this.delete.Click += new System.EventHandler(this.delete_Click);
            // 
            // copy
            // 
            this.copy.Image = global::LazyShell.Properties.Resources.copy;
            this.copy.Name = "copy";
            this.copy.Size = new System.Drawing.Size(23, 22);
            this.copy.ToolTipText = "Copy Exit";
            this.copy.Click += new System.EventHandler(this.copy_Click);
            // 
            // paste
            // 
            this.paste.Image = global::LazyShell.Properties.Resources.paste;
            this.paste.Name = "paste";
            this.paste.Size = new System.Drawing.Size(23, 22);
            this.paste.ToolTipText = "Paste Exit";
            this.paste.Click += new System.EventHandler(this.paste_Click);
            // 
            // duplicate
            // 
            this.duplicate.Image = global::LazyShell.Properties.Resources.duplicate;
            this.duplicate.Name = "duplicate";
            this.duplicate.Size = new System.Drawing.Size(23, 22);
            this.duplicate.ToolTipText = "Duplicate Exit";
            this.duplicate.Click += new System.EventHandler(this.duplicate_Click);
            // 
            // toolStripSeparator19
            // 
            this.toolStripSeparator19.Name = "toolStripSeparator19";
            this.toolStripSeparator19.Size = new System.Drawing.Size(6, 25);
            // 
            // bytesLeft
            // 
            this.bytesLeft.Name = "bytesLeft";
            this.bytesLeft.Size = new System.Drawing.Size(55, 22);
            this.bytesLeft.Text = "bytes left";
            // 
            // listBox
            // 
            this.listBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.listBox.FormattingEnabled = true;
            this.listBox.IntegralHeight = false;
            this.listBox.Location = new System.Drawing.Point(0, 25);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(126, 294);
            this.listBox.TabIndex = 5;
            this.listBox.SelectedIndexChanged += new System.EventHandler(this.listBox_SelectedIndexChanged);
            // 
            // headerLabel1
            // 
            this.headerLabel1.Location = new System.Drawing.Point(126, 25);
            this.headerLabel1.Name = "headerLabel1";
            this.headerLabel1.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.headerLabel1.Size = new System.Drawing.Size(136, 14);
            this.headerLabel1.TabIndex = 6;
            this.headerLabel1.Text = "Exit Coordinates";
            // 
            // headerLabel2
            // 
            this.headerLabel2.Location = new System.Drawing.Point(126, 160);
            this.headerLabel2.Name = "headerLabel2";
            this.headerLabel2.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.headerLabel2.Size = new System.Drawing.Size(136, 14);
            this.headerLabel2.TabIndex = 6;
            this.headerLabel2.Text = "Destination Properties";
            // 
            // ExitsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(262, 319);
            this.Controls.Add(this.destF);
            this.Controls.Add(this.type);
            this.Controls.Add(this.destZ_Half);
            this.Controls.Add(this.destination);
            this.Controls.Add(this.label59);
            this.Controls.Add(this.destY);
            this.Controls.Add(this.showBanner);
            this.Controls.Add(this.label124);
            this.Controls.Add(this.label122);
            this.Controls.Add(this.destZ);
            this.Controls.Add(this.destX);
            this.Controls.Add(this.y_half);
            this.Controls.Add(this.label119);
            this.Controls.Add(this.y);
            this.Controls.Add(this.f);
            this.Controls.Add(this.x);
            this.Controls.Add(this.height);
            this.Controls.Add(this.x_half);
            this.Controls.Add(this.z);
            this.Controls.Add(this.width);
            this.Controls.Add(this.label57);
            this.Controls.Add(this.label105);
            this.Controls.Add(this.headerLabel2);
            this.Controls.Add(this.headerLabel1);
            this.Controls.Add(this.listBox);
            this.Controls.Add(this.toolStrip);
            this.DockAreas = ((WeifenLuo.WinFormsUI.Docking.DockAreas)(((WeifenLuo.WinFormsUI.Docking.DockAreas.Float | WeifenLuo.WinFormsUI.Docking.DockAreas.DockLeft) 
            | WeifenLuo.WinFormsUI.Docking.DockAreas.DockRight)));
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "ExitsForm";
            this.Text = "Exit Triggers";
            ((System.ComponentModel.ISupportInitialize)(this.destY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.destZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.destX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.y)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.x)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.height)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.z)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.width)).EndInit();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox destF;
        private System.Windows.Forms.ComboBox type;
        private System.Windows.Forms.CheckBox destZ_Half;
        private System.Windows.Forms.ComboBox destination;
        private System.Windows.Forms.Label label59;
        private System.Windows.Forms.NumericUpDown destY;
        private System.Windows.Forms.CheckBox showBanner;
        private System.Windows.Forms.Label label124;
        private System.Windows.Forms.Label label122;
        private System.Windows.Forms.NumericUpDown destZ;
        private System.Windows.Forms.NumericUpDown destX;
        private System.Windows.Forms.CheckBox y_half;
        private System.Windows.Forms.Label label119;
        private System.Windows.Forms.NumericUpDown y;
        private System.Windows.Forms.ComboBox f;
        private System.Windows.Forms.NumericUpDown x;
        private System.Windows.Forms.NumericUpDown height;
        private System.Windows.Forms.CheckBox x_half;
        private System.Windows.Forms.NumericUpDown z;
        private System.Windows.Forms.Label label57;
        private System.Windows.Forms.Label label105;
        private System.Windows.Forms.NumericUpDown width;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton insert;
        private System.Windows.Forms.ToolStripButton delete;
        private System.Windows.Forms.ToolStripButton copy;
        private System.Windows.Forms.ToolStripButton paste;
        private System.Windows.Forms.ToolStripButton duplicate;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator19;
        private System.Windows.Forms.ToolStripLabel bytesLeft;
        private System.Windows.Forms.ListBox listBox;
        private Controls.HeaderLabel headerLabel1;
        private Controls.HeaderLabel headerLabel2;
    }
}