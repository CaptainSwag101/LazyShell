namespace LAZYSHELL.Areas
{
    partial class EventsForm
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
            this.y_half = new System.Windows.Forms.CheckBox();
            this.openEventsForm = new System.Windows.Forms.Button();
            this.x_half = new System.Windows.Forms.CheckBox();
            this.runEvent = new System.Windows.Forms.NumericUpDown();
            this.f = new System.Windows.Forms.ComboBox();
            this.width = new System.Windows.Forms.NumericUpDown();
            this.y = new System.Windows.Forms.NumericUpDown();
            this.label127 = new System.Windows.Forms.Label();
            this.label133 = new System.Windows.Forms.Label();
            this.x = new System.Windows.Forms.NumericUpDown();
            this.z = new System.Windows.Forms.NumericUpDown();
            this.label131 = new System.Windows.Forms.Label();
            this.height = new System.Windows.Forms.NumericUpDown();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.insert = new System.Windows.Forms.ToolStripButton();
            this.delete = new System.Windows.Forms.ToolStripButton();
            this.copy = new System.Windows.Forms.ToolStripButton();
            this.paste = new System.Windows.Forms.ToolStripButton();
            this.duplicate = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator20 = new System.Windows.Forms.ToolStripSeparator();
            this.bytesLeft = new System.Windows.Forms.ToolStripLabel();
            this.listBox = new System.Windows.Forms.ListBox();
            this.headerLabel1 = new LAZYSHELL.Controls.HeaderLabel();
            this.headerLabel2 = new LAZYSHELL.Controls.HeaderLabel();
            ((System.ComponentModel.ISupportInitialize)(this.runEvent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.width)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.y)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.x)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.z)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.height)).BeginInit();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // y_half
            // 
            this.y_half.Appearance = System.Windows.Forms.Appearance.Button;
            this.y_half.BackColor = System.Drawing.SystemColors.Control;
            this.y_half.FlatAppearance.BorderSize = 0;
            this.y_half.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.y_half.ForeColor = System.Drawing.Color.Gray;
            this.y_half.Location = new System.Drawing.Point(132, 94);
            this.y_half.Name = "y_half";
            this.y_half.Size = new System.Drawing.Size(127, 21);
            this.y_half.TabIndex = 14;
            this.y_half.Text = "NE/SW edge active";
            this.y_half.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.y_half.UseCompatibleTextRendering = true;
            this.y_half.UseVisualStyleBackColor = false;
            this.y_half.CheckedChanged += new System.EventHandler(this.y_half_CheckedChanged);
            // 
            // openEventsForm
            // 
            this.openEventsForm.BackColor = System.Drawing.SystemColors.Control;
            this.openEventsForm.FlatAppearance.BorderSize = 0;
            this.openEventsForm.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openEventsForm.Location = new System.Drawing.Point(132, 42);
            this.openEventsForm.Name = "openEventsForm";
            this.openEventsForm.Size = new System.Drawing.Size(63, 21);
            this.openEventsForm.TabIndex = 0;
            this.openEventsForm.Text = "Event #";
            this.openEventsForm.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.openEventsForm.UseCompatibleTextRendering = true;
            this.openEventsForm.UseVisualStyleBackColor = false;
            this.openEventsForm.Click += new System.EventHandler(this.openEventsForm_Click);
            // 
            // x_half
            // 
            this.x_half.Appearance = System.Windows.Forms.Appearance.Button;
            this.x_half.BackColor = System.Drawing.SystemColors.Control;
            this.x_half.FlatAppearance.BorderSize = 0;
            this.x_half.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.x_half.ForeColor = System.Drawing.Color.Gray;
            this.x_half.Location = new System.Drawing.Point(132, 69);
            this.x_half.Name = "x_half";
            this.x_half.Size = new System.Drawing.Size(127, 21);
            this.x_half.TabIndex = 13;
            this.x_half.Text = "NW/SE edge active";
            this.x_half.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.x_half.UseCompatibleTextRendering = true;
            this.x_half.UseVisualStyleBackColor = false;
            this.x_half.CheckedChanged += new System.EventHandler(this.x_half_CheckedChanged);
            // 
            // runEvent
            // 
            this.runEvent.Location = new System.Drawing.Point(201, 42);
            this.runEvent.Maximum = new decimal(new int[] {
            4095,
            0,
            0,
            0});
            this.runEvent.Name = "runEvent";
            this.runEvent.Size = new System.Drawing.Size(58, 21);
            this.runEvent.TabIndex = 1;
            this.runEvent.ValueChanged += new System.EventHandler(this.runEvent_ValueChanged);
            // 
            // f
            // 
            this.f.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.f.Items.AddRange(new object[] {
            "SE",
            "SW"});
            this.f.Location = new System.Drawing.Point(214, 156);
            this.f.Name = "f";
            this.f.Size = new System.Drawing.Size(45, 21);
            this.f.TabIndex = 12;
            this.f.SelectedIndexChanged += new System.EventHandler(this.f_SelectedIndexChanged);
            // 
            // width
            // 
            this.width.Location = new System.Drawing.Point(169, 177);
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
            this.width.TabIndex = 8;
            this.width.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.width.ValueChanged += new System.EventHandler(this.width_ValueChanged);
            // 
            // y
            // 
            this.y.Location = new System.Drawing.Point(214, 135);
            this.y.Maximum = new decimal(new int[] {
            127,
            0,
            0,
            0});
            this.y.Name = "y";
            this.y.Size = new System.Drawing.Size(45, 21);
            this.y.TabIndex = 4;
            this.y.ValueChanged += new System.EventHandler(this.y_ValueChanged);
            // 
            // label127
            // 
            this.label127.AutoSize = true;
            this.label127.Location = new System.Drawing.Point(132, 137);
            this.label127.Name = "label127";
            this.label127.Size = new System.Drawing.Size(23, 13);
            this.label127.TabIndex = 2;
            this.label127.Text = "X,Y";
            // 
            // label133
            // 
            this.label133.AutoSize = true;
            this.label133.Location = new System.Drawing.Point(132, 158);
            this.label133.Name = "label133";
            this.label133.Size = new System.Drawing.Size(23, 13);
            this.label133.TabIndex = 5;
            this.label133.Text = "Z,F";
            // 
            // x
            // 
            this.x.Location = new System.Drawing.Point(169, 135);
            this.x.Maximum = new decimal(new int[] {
            63,
            0,
            0,
            0});
            this.x.Name = "x";
            this.x.Size = new System.Drawing.Size(45, 21);
            this.x.TabIndex = 3;
            this.x.ValueChanged += new System.EventHandler(this.x_ValueChanged);
            // 
            // z
            // 
            this.z.Location = new System.Drawing.Point(169, 156);
            this.z.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.z.Name = "z";
            this.z.Size = new System.Drawing.Size(45, 21);
            this.z.TabIndex = 6;
            this.z.ValueChanged += new System.EventHandler(this.z_ValueChanged);
            // 
            // label131
            // 
            this.label131.AutoSize = true;
            this.label131.Location = new System.Drawing.Point(132, 178);
            this.label131.Name = "label131";
            this.label131.Size = new System.Drawing.Size(28, 13);
            this.label131.TabIndex = 7;
            this.label131.Text = "W/H";
            // 
            // height
            // 
            this.height.Location = new System.Drawing.Point(214, 177);
            this.height.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.height.Name = "height";
            this.height.Size = new System.Drawing.Size(45, 21);
            this.height.TabIndex = 10;
            this.height.ValueChanged += new System.EventHandler(this.height_ValueChanged);
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.insert,
            this.delete,
            this.copy,
            this.paste,
            this.duplicate,
            this.toolStripSeparator20,
            this.bytesLeft});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(262, 25);
            this.toolStrip.TabIndex = 5;
            // 
            // insert
            // 
            this.insert.Image = global::LAZYSHELL.Properties.Resources.eventAdd;
            this.insert.Name = "insert";
            this.insert.Size = new System.Drawing.Size(23, 22);
            this.insert.ToolTipText = "New Event";
            this.insert.Click += new System.EventHandler(this.insert_Click);
            // 
            // delete
            // 
            this.delete.Image = global::LAZYSHELL.Properties.Resources.eventRemove;
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(23, 22);
            this.delete.ToolTipText = "Delete Event";
            this.delete.Click += new System.EventHandler(this.delete_Click);
            // 
            // copy
            // 
            this.copy.Image = global::LAZYSHELL.Properties.Resources.copy;
            this.copy.Name = "copy";
            this.copy.Size = new System.Drawing.Size(23, 22);
            this.copy.ToolTipText = "Copy Event";
            this.copy.Click += new System.EventHandler(this.copy_Click);
            // 
            // paste
            // 
            this.paste.Image = global::LAZYSHELL.Properties.Resources.paste;
            this.paste.Name = "paste";
            this.paste.Size = new System.Drawing.Size(23, 22);
            this.paste.ToolTipText = "Paste Event";
            this.paste.Click += new System.EventHandler(this.paste_Click);
            // 
            // duplicate
            // 
            this.duplicate.Image = global::LAZYSHELL.Properties.Resources.duplicate;
            this.duplicate.Name = "duplicate";
            this.duplicate.Size = new System.Drawing.Size(23, 22);
            this.duplicate.ToolTipText = "Duplicate Event";
            this.duplicate.Click += new System.EventHandler(this.duplicate_Click);
            // 
            // toolStripSeparator20
            // 
            this.toolStripSeparator20.Name = "toolStripSeparator20";
            this.toolStripSeparator20.Size = new System.Drawing.Size(6, 25);
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
            this.listBox.Size = new System.Drawing.Size(126, 176);
            this.listBox.TabIndex = 8;
            this.listBox.SelectedIndexChanged += new System.EventHandler(this.listBox_SelectedIndexChanged);
            // 
            // headerLabel1
            // 
            this.headerLabel1.Location = new System.Drawing.Point(126, 25);
            this.headerLabel1.Name = "headerLabel1";
            this.headerLabel1.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.headerLabel1.Size = new System.Drawing.Size(136, 14);
            this.headerLabel1.TabIndex = 0;
            this.headerLabel1.Text = "Event Properties";
            // 
            // headerLabel2
            // 
            this.headerLabel2.Location = new System.Drawing.Point(126, 118);
            this.headerLabel2.Name = "headerLabel2";
            this.headerLabel2.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.headerLabel2.Size = new System.Drawing.Size(136, 14);
            this.headerLabel2.TabIndex = 15;
            this.headerLabel2.Text = "Coordinates";
            // 
            // EventsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(262, 201);
            this.Controls.Add(this.f);
            this.Controls.Add(this.x);
            this.Controls.Add(this.height);
            this.Controls.Add(this.label131);
            this.Controls.Add(this.z);
            this.Controls.Add(this.width);
            this.Controls.Add(this.label133);
            this.Controls.Add(this.y);
            this.Controls.Add(this.label127);
            this.Controls.Add(this.headerLabel2);
            this.Controls.Add(this.headerLabel1);
            this.Controls.Add(this.y_half);
            this.Controls.Add(this.openEventsForm);
            this.Controls.Add(this.x_half);
            this.Controls.Add(this.runEvent);
            this.Controls.Add(this.listBox);
            this.Controls.Add(this.toolStrip);
            this.DockAreas = ((WeifenLuo.WinFormsUI.Docking.DockAreas)(((WeifenLuo.WinFormsUI.Docking.DockAreas.Float | WeifenLuo.WinFormsUI.Docking.DockAreas.DockLeft) 
            | WeifenLuo.WinFormsUI.Docking.DockAreas.DockRight)));
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "EventsForm";
            this.Text = "Event Triggers";
            ((System.ComponentModel.ISupportInitialize)(this.runEvent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.width)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.y)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.x)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.z)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.height)).EndInit();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox f;
        private System.Windows.Forms.CheckBox y_half;
        private System.Windows.Forms.Button openEventsForm;
        private System.Windows.Forms.CheckBox x_half;
        private System.Windows.Forms.NumericUpDown width;
        private System.Windows.Forms.NumericUpDown y;
        private System.Windows.Forms.Label label127;
        private System.Windows.Forms.Label label133;
        private System.Windows.Forms.NumericUpDown x;
        private System.Windows.Forms.NumericUpDown z;
        private System.Windows.Forms.Label label131;
        private System.Windows.Forms.NumericUpDown runEvent;
        private System.Windows.Forms.NumericUpDown height;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton insert;
        private System.Windows.Forms.ToolStripButton delete;
        private System.Windows.Forms.ToolStripButton copy;
        private System.Windows.Forms.ToolStripButton paste;
        private System.Windows.Forms.ToolStripButton duplicate;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator20;
        private System.Windows.Forms.ToolStripLabel bytesLeft;
        private System.Windows.Forms.ListBox listBox;
        private Controls.HeaderLabel headerLabel1;
        private Controls.HeaderLabel headerLabel2;
    }
}