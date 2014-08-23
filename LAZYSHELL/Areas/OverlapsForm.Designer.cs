namespace LAZYSHELL.Areas
{
    partial class OverlapsForm
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.z_half = new System.Windows.Forms.CheckBox();
            this.label109 = new System.Windows.Forms.Label();
            this.type = new System.Windows.Forms.NumericUpDown();
            this.x = new System.Windows.Forms.NumericUpDown();
            this.y = new System.Windows.Forms.NumericUpDown();
            this.label103 = new System.Windows.Forms.Label();
            this.z = new System.Windows.Forms.NumericUpDown();
            this.label107 = new System.Windows.Forms.Label();
            this.headerLabel1 = new LAZYSHELL.Controls.HeaderLabel();
            this.listBox = new System.Windows.Forms.ListBox();
            this.unknownBits = new System.Windows.Forms.CheckedListBox();
            this.toolStrip4 = new System.Windows.Forms.ToolStrip();
            this.insert = new System.Windows.Forms.ToolStripButton();
            this.delete = new System.Windows.Forms.ToolStripButton();
            this.copy = new System.Windows.Forms.ToolStripButton();
            this.paste = new System.Windows.Forms.ToolStripButton();
            this.duplicate = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator18 = new System.Windows.Forms.ToolStripSeparator();
            this.bytesLeft = new System.Windows.Forms.ToolStripLabel();
            this.panelTileset = new System.Windows.Forms.Panel();
            this.pictureBoxTileset = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.saveOverlapsImage = new System.Windows.Forms.ToolStripMenuItem();
            this.importOverlapsImage = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.type)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.x)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.y)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.z)).BeginInit();
            this.toolStrip4.SuspendLayout();
            this.panelTileset.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTileset)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.z_half);
            this.panel1.Controls.Add(this.label109);
            this.panel1.Controls.Add(this.type);
            this.panel1.Controls.Add(this.x);
            this.panel1.Controls.Add(this.y);
            this.panel1.Controls.Add(this.label103);
            this.panel1.Controls.Add(this.z);
            this.panel1.Controls.Add(this.label107);
            this.panel1.Controls.Add(this.headerLabel1);
            this.panel1.Controls.Add(this.listBox);
            this.panel1.Controls.Add(this.unknownBits);
            this.panel1.Controls.Add(this.toolStrip4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(262, 183);
            this.panel1.TabIndex = 2;
            // 
            // z_half
            // 
            this.z_half.Appearance = System.Windows.Forms.Appearance.Button;
            this.z_half.BackColor = System.Drawing.SystemColors.Control;
            this.z_half.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.z_half.ForeColor = System.Drawing.Color.Gray;
            this.z_half.Location = new System.Drawing.Point(216, 85);
            this.z_half.Name = "z_half";
            this.z_half.Size = new System.Drawing.Size(43, 19);
            this.z_half.TabIndex = 7;
            this.z_half.Text = "+1/2";
            this.z_half.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.z_half.UseCompatibleTextRendering = true;
            this.z_half.UseVisualStyleBackColor = false;
            this.z_half.CheckedChanged += new System.EventHandler(this.z_half_CheckedChanged);
            // 
            // label109
            // 
            this.label109.AutoSize = true;
            this.label109.Location = new System.Drawing.Point(132, 44);
            this.label109.Name = "label109";
            this.label109.Size = new System.Drawing.Size(23, 13);
            this.label109.TabIndex = 0;
            this.label109.Text = "Tile";
            // 
            // type
            // 
            this.type.Location = new System.Drawing.Point(169, 42);
            this.type.Maximum = new decimal(new int[] {
            103,
            0,
            0,
            0});
            this.type.Name = "type";
            this.type.Size = new System.Drawing.Size(90, 21);
            this.type.TabIndex = 1;
            this.type.ValueChanged += new System.EventHandler(this.type_ValueChanged);
            // 
            // x
            // 
            this.x.Location = new System.Drawing.Point(169, 63);
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
            // y
            // 
            this.y.Location = new System.Drawing.Point(214, 63);
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
            // label103
            // 
            this.label103.AutoSize = true;
            this.label103.Location = new System.Drawing.Point(132, 65);
            this.label103.Name = "label103";
            this.label103.Size = new System.Drawing.Size(23, 13);
            this.label103.TabIndex = 2;
            this.label103.Text = "X,Y";
            // 
            // z
            // 
            this.z.Location = new System.Drawing.Point(169, 84);
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
            // label107
            // 
            this.label107.AutoSize = true;
            this.label107.Location = new System.Drawing.Point(132, 86);
            this.label107.Name = "label107";
            this.label107.Size = new System.Drawing.Size(13, 13);
            this.label107.TabIndex = 5;
            this.label107.Text = "Z";
            // 
            // headerLabel1
            // 
            this.headerLabel1.Location = new System.Drawing.Point(126, 25);
            this.headerLabel1.Name = "headerLabel1";
            this.headerLabel1.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.headerLabel1.Size = new System.Drawing.Size(136, 14);
            this.headerLabel1.TabIndex = 5;
            this.headerLabel1.Text = "Tile Properties";
            // 
            // listBox
            // 
            this.listBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.listBox.FormattingEnabled = true;
            this.listBox.IntegralHeight = false;
            this.listBox.Location = new System.Drawing.Point(0, 25);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(126, 158);
            this.listBox.TabIndex = 4;
            this.listBox.SelectedIndexChanged += new System.EventHandler(this.listBox_SelectedIndexChanged);
            // 
            // unknownBits
            // 
            this.unknownBits.CheckOnClick = true;
            this.unknownBits.ColumnWidth = 60;
            this.unknownBits.IntegralHeight = false;
            this.unknownBits.Items.AddRange(new object[] {
            "overlap tile edges",
            "{B2,b5}",
            "{B2,b6}",
            "{B2,b7}"});
            this.unknownBits.Location = new System.Drawing.Point(130, 110);
            this.unknownBits.Name = "unknownBits";
            this.unknownBits.Size = new System.Drawing.Size(129, 69);
            this.unknownBits.TabIndex = 3;
            this.unknownBits.SelectedIndexChanged += new System.EventHandler(this.unknownBits_SelectedIndexChanged);
            // 
            // toolStrip4
            // 
            this.toolStrip4.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.insert,
            this.delete,
            this.copy,
            this.paste,
            this.duplicate,
            this.toolStripSeparator18,
            this.bytesLeft});
            this.toolStrip4.Location = new System.Drawing.Point(0, 0);
            this.toolStrip4.Name = "toolStrip4";
            this.toolStrip4.Size = new System.Drawing.Size(262, 25);
            this.toolStrip4.TabIndex = 0;
            // 
            // insert
            // 
            this.insert.Image = global::LAZYSHELL.Properties.Resources.overlapAdd;
            this.insert.Name = "insert";
            this.insert.Size = new System.Drawing.Size(23, 22);
            this.insert.ToolTipText = "Insert overlap";
            this.insert.Click += new System.EventHandler(this.insert_Click);
            // 
            // delete
            // 
            this.delete.Image = global::LAZYSHELL.Properties.Resources.overlapRemove;
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(23, 22);
            this.delete.ToolTipText = "Delete overlap";
            this.delete.Click += new System.EventHandler(this.delete_Click);
            // 
            // copy
            // 
            this.copy.Image = global::LAZYSHELL.Properties.Resources.copy;
            this.copy.Name = "copy";
            this.copy.Size = new System.Drawing.Size(23, 22);
            this.copy.ToolTipText = "Copy Overlap";
            this.copy.Click += new System.EventHandler(this.copy_Click);
            // 
            // paste
            // 
            this.paste.Image = global::LAZYSHELL.Properties.Resources.paste;
            this.paste.Name = "paste";
            this.paste.Size = new System.Drawing.Size(23, 22);
            this.paste.ToolTipText = "Paste Overlap";
            this.paste.Click += new System.EventHandler(this.paste_Click);
            // 
            // duplicate
            // 
            this.duplicate.Image = global::LAZYSHELL.Properties.Resources.duplicate;
            this.duplicate.Name = "duplicate";
            this.duplicate.Size = new System.Drawing.Size(23, 22);
            this.duplicate.ToolTipText = "Duplicate Overlap";
            this.duplicate.Click += new System.EventHandler(this.duplicate_Click);
            // 
            // toolStripSeparator18
            // 
            this.toolStripSeparator18.Name = "toolStripSeparator18";
            this.toolStripSeparator18.Size = new System.Drawing.Size(6, 25);
            // 
            // bytesLeft
            // 
            this.bytesLeft.Name = "bytesLeft";
            this.bytesLeft.Size = new System.Drawing.Size(55, 22);
            this.bytesLeft.Text = "bytes left";
            // 
            // panelTileset
            // 
            this.panelTileset.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelTileset.Controls.Add(this.pictureBoxTileset);
            this.panelTileset.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTileset.Enabled = false;
            this.panelTileset.Location = new System.Drawing.Point(0, 183);
            this.panelTileset.Name = "panelTileset";
            this.panelTileset.Size = new System.Drawing.Size(262, 435);
            this.panelTileset.TabIndex = 3;
            this.panelTileset.Visible = false;
            // 
            // pictureBoxTileset
            // 
            this.pictureBoxTileset.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBoxTileset.BackgroundImage = global::LAZYSHELL.Properties.Resources._transparent;
            this.pictureBoxTileset.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxTileset.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxTileset.Name = "pictureBoxTileset";
            this.pictureBoxTileset.Size = new System.Drawing.Size(258, 431);
            this.pictureBoxTileset.TabIndex = 0;
            this.pictureBoxTileset.TabStop = false;
            this.pictureBoxTileset.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxTileset_Paint);
            this.pictureBoxTileset.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxTileset_MouseDown);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveOverlapsImage,
            this.importOverlapsImage});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(203, 48);
            // 
            // saveOverlapsImage
            // 
            this.saveOverlapsImage.Image = global::LAZYSHELL.Properties.Resources.exportImage;
            this.saveOverlapsImage.Name = "saveOverlapsImage";
            this.saveOverlapsImage.Size = new System.Drawing.Size(202, 22);
            this.saveOverlapsImage.Text = "Save overlaps image...";
            this.saveOverlapsImage.Click += new System.EventHandler(this.saveOverlapsImage_Click);
            // 
            // importOverlapsImage
            // 
            this.importOverlapsImage.Image = global::LAZYSHELL.Properties.Resources.importImage;
            this.importOverlapsImage.Name = "importOverlapsImage";
            this.importOverlapsImage.Size = new System.Drawing.Size(202, 22);
            this.importOverlapsImage.Text = "Import overlaps image...";
            this.importOverlapsImage.Click += new System.EventHandler(this.importOverlapsImage_Click);
            // 
            // OverlapsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(262, 618);
            this.Controls.Add(this.panelTileset);
            this.Controls.Add(this.panel1);
            this.DockAreas = ((WeifenLuo.WinFormsUI.Docking.DockAreas)(((WeifenLuo.WinFormsUI.Docking.DockAreas.Float | WeifenLuo.WinFormsUI.Docking.DockAreas.DockLeft) 
            | WeifenLuo.WinFormsUI.Docking.DockAreas.DockRight)));
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "OverlapsForm";
            this.Text = "Overlaps";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.type)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.x)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.y)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.z)).EndInit();
            this.toolStrip4.ResumeLayout(false);
            this.toolStrip4.PerformLayout();
            this.panelTileset.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTileset)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox z_half;
        private System.Windows.Forms.Label label109;
        private System.Windows.Forms.NumericUpDown type;
        private System.Windows.Forms.NumericUpDown x;
        private System.Windows.Forms.NumericUpDown y;
        private System.Windows.Forms.Label label103;
        private System.Windows.Forms.NumericUpDown z;
        private System.Windows.Forms.Label label107;
        private System.Windows.Forms.CheckedListBox unknownBits;
        private System.Windows.Forms.ToolStrip toolStrip4;
        private System.Windows.Forms.ToolStripButton insert;
        private System.Windows.Forms.ToolStripButton delete;
        private System.Windows.Forms.ToolStripButton copy;
        private System.Windows.Forms.ToolStripButton paste;
        private System.Windows.Forms.ToolStripButton duplicate;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator18;
        private System.Windows.Forms.ToolStripLabel bytesLeft;
        private System.Windows.Forms.Panel panelTileset;
        private System.Windows.Forms.PictureBox pictureBoxTileset;
        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem saveOverlapsImage;
        private System.Windows.Forms.ToolStripMenuItem importOverlapsImage;
        private Controls.HeaderLabel headerLabel1;
    }
}