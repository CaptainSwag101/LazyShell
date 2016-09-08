
namespace LazyShell.Areas
{
    partial class ChunksForm
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
			this.import = new System.Windows.Forms.ToolStripButton();
			this.export = new System.Windows.Forms.ToolStripButton();
			this.delete = new System.Windows.Forms.ToolStripButton();
			this.copy = new System.Windows.Forms.ToolStripButton();
			this.paste = new System.Windows.Forms.ToolStripButton();
			this.listBox = new System.Windows.Forms.ListBox();
			this.panel114 = new System.Windows.Forms.Panel();
			this.picture = new System.Windows.Forms.PictureBox();
			this.toolStrip3 = new System.Windows.Forms.ToolStrip();
			this.transfer = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator45 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.rename = new System.Windows.Forms.ToolStripButton();
			this.renameText = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.panel114.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.picture)).BeginInit();
			this.toolStrip3.SuspendLayout();
			this.toolStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// import
			// 
			this.import.Image = global::LazyShell.Properties.Resources.open;
			this.import.Name = "import";
			this.import.Size = new System.Drawing.Size(23, 22);
			this.import.ToolTipText = "Load";
			this.import.Click += new System.EventHandler(this.import_Click);
			// 
			// export
			// 
			this.export.Enabled = false;
			this.export.Image = global::LazyShell.Properties.Resources.save;
			this.export.Name = "export";
			this.export.Size = new System.Drawing.Size(23, 22);
			this.export.ToolTipText = "Save";
			this.export.Click += new System.EventHandler(this.export_Click);
			// 
			// delete
			// 
			this.delete.Image = global::LazyShell.Properties.Resources.delete;
			this.delete.Name = "delete";
			this.delete.Size = new System.Drawing.Size(23, 22);
			this.delete.ToolTipText = "Delete chunk";
			this.delete.Click += new System.EventHandler(this.delete_Click);
			// 
			// copy
			// 
			this.copy.Image = global::LazyShell.Properties.Resources.copy;
			this.copy.Name = "copy";
			this.copy.Size = new System.Drawing.Size(23, 22);
			this.copy.ToolTipText = "Copy chunk";
			this.copy.Click += new System.EventHandler(this.copy_Click);
			// 
			// paste
			// 
			this.paste.Image = global::LazyShell.Properties.Resources.paste;
			this.paste.Name = "paste";
			this.paste.Size = new System.Drawing.Size(23, 22);
			this.paste.ToolTipText = "Paste chunk";
			this.paste.Click += new System.EventHandler(this.paste_Click);
			// 
			// listBox
			// 
			this.listBox.Dock = System.Windows.Forms.DockStyle.Top;
			this.listBox.Enabled = false;
			this.listBox.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
			this.listBox.FormattingEnabled = true;
			this.listBox.Location = new System.Drawing.Point(0, 25);
			this.listBox.Name = "listBox";
			this.listBox.Size = new System.Drawing.Size(266, 134);
			this.listBox.TabIndex = 1;
			this.listBox.SelectedIndexChanged += new System.EventHandler(this.listBox_SelectedIndexChanged);
			// 
			// panel114
			// 
			this.panel114.AutoScroll = true;
			this.panel114.BackColor = System.Drawing.SystemColors.ControlDark;
			this.panel114.BackgroundImage = global::LazyShell.Properties.Resources._canvas;
			this.panel114.Controls.Add(this.picture);
			this.panel114.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel114.Location = new System.Drawing.Point(0, 184);
			this.panel114.Name = "panel114";
			this.panel114.Size = new System.Drawing.Size(266, 431);
			this.panel114.TabIndex = 3;
			// 
			// picture
			// 
			this.picture.BackColor = System.Drawing.SystemColors.Control;
			this.picture.BackgroundImage = global::LazyShell.Properties.Resources._transparent;
			this.picture.Location = new System.Drawing.Point(0, 0);
			this.picture.Name = "picture";
			this.picture.Size = new System.Drawing.Size(100, 50);
			this.picture.TabIndex = 450;
			this.picture.TabStop = false;
			this.picture.Paint += new System.Windows.Forms.PaintEventHandler(this.picture_Paint);
			// 
			// toolStrip3
			// 
			this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.transfer,
            this.toolStripSeparator45,
            this.import,
            this.export});
			this.toolStrip3.Location = new System.Drawing.Point(0, 0);
			this.toolStrip3.Name = "toolStrip3";
			this.toolStrip3.Size = new System.Drawing.Size(266, 25);
			this.toolStrip3.TabIndex = 0;
			// 
			// transfer
			// 
			this.transfer.Image = global::LazyShell.Properties.Resources.transfer;
			this.transfer.Name = "transfer";
			this.transfer.Size = new System.Drawing.Size(23, 22);
			this.transfer.ToolTipText = "Create Chunk";
			this.transfer.Click += new System.EventHandler(this.transfer_Click);
			// 
			// toolStripSeparator45
			// 
			this.toolStripSeparator45.Name = "toolStripSeparator45";
			this.toolStripSeparator45.Size = new System.Drawing.Size(6, 25);
			// 
			// toolStrip1
			// 
			this.toolStrip1.Enabled = false;
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rename,
            this.renameText,
            this.toolStripSeparator1,
            this.delete,
            this.copy,
            this.paste});
			this.toolStrip1.Location = new System.Drawing.Point(0, 159);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(266, 25);
			this.toolStrip1.TabIndex = 2;
			// 
			// rename
			// 
			this.rename.Checked = true;
			this.rename.CheckOnClick = true;
			this.rename.CheckState = System.Windows.Forms.CheckState.Checked;
			this.rename.Image = global::LazyShell.Properties.Resources.label;
			this.rename.Name = "rename";
			this.rename.Size = new System.Drawing.Size(23, 22);
			this.rename.ToolTipText = "Set Chunk Name";
			this.rename.Click += new System.EventHandler(this.rename_Click);
			// 
			// renameText
			// 
			this.renameText.Name = "renameText";
			this.renameText.Size = new System.Drawing.Size(140, 25);
			this.renameText.TextChanged += new System.EventHandler(this.renameText_TextChanged);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// ChunksForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(266, 615);
			this.Controls.Add(this.panel114);
			this.Controls.Add(this.toolStrip1);
			this.Controls.Add(this.listBox);
			this.Controls.Add(this.toolStrip3);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.Location = new System.Drawing.Point(0, 0);
			this.Name = "ChunksForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Text = "Chunks";
			this.TopMost = true;
			this.panel114.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.picture)).EndInit();
			this.toolStrip3.ResumeLayout(false);
			this.toolStrip3.PerformLayout();
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }
        #endregion
        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.Panel panel114;
        private System.Windows.Forms.PictureBox picture;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripButton transfer;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator45;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton rename;
        private System.Windows.Forms.ToolStripTextBox renameText;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton import;
        private System.Windows.Forms.ToolStripButton export;
        private System.Windows.Forms.ToolStripButton delete;
        private System.Windows.Forms.ToolStripButton copy;
        private System.Windows.Forms.ToolStripButton paste;
    }
}