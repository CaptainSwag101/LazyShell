namespace LazyShell.Areas
{
    partial class TileSwitchesForm
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
            this.bytesLeft = new System.Windows.Forms.Label();
            this.layers = new System.Windows.Forms.CheckedListBox();
            this.label26 = new System.Windows.Forms.Label();
            this.y = new System.Windows.Forms.NumericUpDown();
            this.label50 = new System.Windows.Forms.Label();
            this.x = new System.Windows.Forms.NumericUpDown();
            this.height = new System.Windows.Forms.NumericUpDown();
            this.label36 = new System.Windows.Forms.Label();
            this.width = new System.Windows.Forms.NumericUpDown();
            this.label27 = new System.Windows.Forms.Label();
            this.treeView = new System.Windows.Forms.TreeView();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.insert = new System.Windows.Forms.ToolStripButton();
            this.insertAlternate = new System.Windows.Forms.ToolStripButton();
            this.delete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.copy = new System.Windows.Forms.ToolStripButton();
            this.paste = new System.Windows.Forms.ToolStripButton();
            this.duplicate = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.moveUp = new System.Windows.Forms.ToolStripButton();
            this.moveDown = new System.Windows.Forms.ToolStripButton();
            this.headerLabel1 = new LazyShell.Controls.HeaderLabel();
            ((System.ComponentModel.ISupportInitialize)(this.y)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.x)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.height)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.width)).BeginInit();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // bytesLeft
            // 
            this.bytesLeft.AutoSize = true;
            this.bytesLeft.Location = new System.Drawing.Point(132, 28);
            this.bytesLeft.Name = "bytesLeft";
            this.bytesLeft.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.bytesLeft.Size = new System.Drawing.Size(64, 16);
            this.bytesLeft.TabIndex = 7;
            this.bytesLeft.Text = "0 bytes left";
            // 
            // layers
            // 
            this.layers.CheckOnClick = true;
            this.layers.ColumnWidth = 60;
            this.layers.Items.AddRange(new object[] {
            "Layer 1",
            "Layer 2",
            "Layer 3",
            "B0b7"});
            this.layers.Location = new System.Drawing.Point(129, 155);
            this.layers.Name = "layers";
            this.layers.Size = new System.Drawing.Size(133, 64);
            this.layers.TabIndex = 8;
            this.layers.SelectedIndexChanged += new System.EventHandler(this.layers_SelectedIndexChanged);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(132, 67);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(45, 13);
            this.label26.TabIndex = 0;
            this.label26.Text = "X Coord";
            // 
            // y
            // 
            this.y.Location = new System.Drawing.Point(192, 86);
            this.y.Maximum = new decimal(new int[] {
            63,
            0,
            0,
            0});
            this.y.Name = "y";
            this.y.Size = new System.Drawing.Size(70, 21);
            this.y.TabIndex = 3;
            this.y.ValueChanged += new System.EventHandler(this.y_ValueChanged);
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.Location = new System.Drawing.Point(132, 130);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(38, 13);
            this.label50.TabIndex = 6;
            this.label50.Text = "Height";
            // 
            // x
            // 
            this.x.Location = new System.Drawing.Point(192, 65);
            this.x.Maximum = new decimal(new int[] {
            63,
            0,
            0,
            0});
            this.x.Name = "x";
            this.x.Size = new System.Drawing.Size(70, 21);
            this.x.TabIndex = 1;
            this.x.ValueChanged += new System.EventHandler(this.x_ValueChanged);
            // 
            // height
            // 
            this.height.Location = new System.Drawing.Point(192, 128);
            this.height.Maximum = new decimal(new int[] {
            63,
            0,
            0,
            0});
            this.height.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.height.Name = "height";
            this.height.Size = new System.Drawing.Size(70, 21);
            this.height.TabIndex = 7;
            this.height.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.height.ValueChanged += new System.EventHandler(this.height_ValueChanged);
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(132, 109);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(40, 13);
            this.label36.TabIndex = 4;
            this.label36.Text = "Length";
            // 
            // width
            // 
            this.width.Location = new System.Drawing.Point(192, 107);
            this.width.Maximum = new decimal(new int[] {
            63,
            0,
            0,
            0});
            this.width.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.width.Name = "width";
            this.width.Size = new System.Drawing.Size(70, 21);
            this.width.TabIndex = 5;
            this.width.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.width.ValueChanged += new System.EventHandler(this.width_ValueChanged);
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(132, 88);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(45, 13);
            this.label27.TabIndex = 2;
            this.label27.Text = "Y Coord";
            // 
            // treeView
            // 
            this.treeView.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeView.HideSelection = false;
            this.treeView.HotTracking = true;
            this.treeView.Location = new System.Drawing.Point(0, 25);
            this.treeView.Name = "treeView";
            this.treeView.ShowRootLines = false;
            this.treeView.Size = new System.Drawing.Size(126, 198);
            this.treeView.TabIndex = 6;
            this.treeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_AfterSelect);
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.insert,
            this.insertAlternate,
            this.delete,
            this.toolStripSeparator11,
            this.copy,
            this.paste,
            this.duplicate,
            this.toolStripSeparator12,
            this.moveUp,
            this.moveDown});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(262, 25);
            this.toolStrip.TabIndex = 5;
            // 
            // insert
            // 
            this.insert.Image = global::LazyShell.Properties.Resources.new_file;
            this.insert.Name = "insert";
            this.insert.Size = new System.Drawing.Size(23, 22);
            this.insert.ToolTipText = "New Tile Switch";
            this.insert.Click += new System.EventHandler(this.insert_Click);
            // 
            // insertAlternate
            // 
            this.insertAlternate.Image = global::LazyShell.Properties.Resources.newInstance;
            this.insertAlternate.Name = "insertAlternate";
            this.insertAlternate.Size = new System.Drawing.Size(23, 22);
            this.insertAlternate.ToolTipText = "New Alternate Tile Switch";
            this.insertAlternate.Click += new System.EventHandler(this.insertAlternate_Click);
            // 
            // delete
            // 
            this.delete.Image = global::LazyShell.Properties.Resources.delete;
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(23, 22);
            this.delete.ToolTipText = "Delete Tile Switch";
            this.delete.Click += new System.EventHandler(this.delete_Click);
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(6, 25);
            // 
            // copy
            // 
            this.copy.Image = global::LazyShell.Properties.Resources.copy;
            this.copy.Name = "copy";
            this.copy.Size = new System.Drawing.Size(23, 22);
            this.copy.ToolTipText = "Copy Tile Switch";
            this.copy.Click += new System.EventHandler(this.copy_Click);
            // 
            // paste
            // 
            this.paste.Image = global::LazyShell.Properties.Resources.paste;
            this.paste.Name = "paste";
            this.paste.Size = new System.Drawing.Size(23, 22);
            this.paste.ToolTipText = "Paste Tile Switch";
            this.paste.Click += new System.EventHandler(this.paste_Click);
            // 
            // duplicate
            // 
            this.duplicate.Image = global::LazyShell.Properties.Resources.duplicate;
            this.duplicate.Name = "duplicate";
            this.duplicate.Size = new System.Drawing.Size(23, 22);
            this.duplicate.ToolTipText = "Duplicate Tile Switch";
            this.duplicate.Click += new System.EventHandler(this.duplicate_Click);
            // 
            // toolStripSeparator12
            // 
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            this.toolStripSeparator12.Size = new System.Drawing.Size(6, 25);
            // 
            // moveUp
            // 
            this.moveUp.Image = global::LazyShell.Properties.Resources.moveup;
            this.moveUp.Name = "moveUp";
            this.moveUp.Size = new System.Drawing.Size(23, 22);
            this.moveUp.ToolTipText = "Move Tile Switch Up";
            this.moveUp.Click += new System.EventHandler(this.moveUp_Click);
            // 
            // moveDown
            // 
            this.moveDown.Image = global::LazyShell.Properties.Resources.movedown;
            this.moveDown.Name = "moveDown";
            this.moveDown.Size = new System.Drawing.Size(23, 22);
            this.moveDown.ToolTipText = "Move Tile Switch Down";
            this.moveDown.Click += new System.EventHandler(this.moveDown_Click);
            // 
            // headerLabel1
            // 
            this.headerLabel1.Location = new System.Drawing.Point(126, 48);
            this.headerLabel1.Name = "headerLabel1";
            this.headerLabel1.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.headerLabel1.Size = new System.Drawing.Size(136, 14);
            this.headerLabel1.TabIndex = 29;
            this.headerLabel1.Text = "Coordinates";
            // 
            // TileSwitchesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(262, 223);
            this.Controls.Add(this.layers);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.y);
            this.Controls.Add(this.label50);
            this.Controls.Add(this.x);
            this.Controls.Add(this.height);
            this.Controls.Add(this.label36);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.width);
            this.Controls.Add(this.headerLabel1);
            this.Controls.Add(this.bytesLeft);
            this.Controls.Add(this.treeView);
            this.Controls.Add(this.toolStrip);
            this.DockAreas = ((WeifenLuo.WinFormsUI.Docking.DockAreas)(((WeifenLuo.WinFormsUI.Docking.DockAreas.Float | WeifenLuo.WinFormsUI.Docking.DockAreas.DockLeft) 
            | WeifenLuo.WinFormsUI.Docking.DockAreas.DockRight)));
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "TileSwitchesForm";
            this.Text = "Tile Switches";
            ((System.ComponentModel.ISupportInitialize)(this.y)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.x)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.height)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.width)).EndInit();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label bytesLeft;
        private System.Windows.Forms.CheckedListBox layers;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.NumericUpDown y;
        private System.Windows.Forms.Label label50;
        private System.Windows.Forms.NumericUpDown x;
        private System.Windows.Forms.NumericUpDown height;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.NumericUpDown width;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton insert;
        private System.Windows.Forms.ToolStripButton insertAlternate;
        private System.Windows.Forms.ToolStripButton delete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
        private System.Windows.Forms.ToolStripButton moveUp;
        private System.Windows.Forms.ToolStripButton moveDown;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator12;
        private System.Windows.Forms.ToolStripButton copy;
        private System.Windows.Forms.ToolStripButton paste;
        private System.Windows.Forms.ToolStripButton duplicate;
        private Controls.HeaderLabel headerLabel1;
    }
}