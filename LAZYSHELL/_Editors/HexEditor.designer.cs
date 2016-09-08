
namespace LazyShell
{
    partial class HexEditor
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
			this.save = new System.Windows.Forms.ToolStripButton();
			this.panel1 = new System.Windows.Forms.Panel();
			this.info_sel = new System.Windows.Forms.Label();
			this.info_value = new System.Windows.Forms.Label();
			this.info_offset = new System.Windows.Forms.Label();
			this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
			this.panel2 = new System.Windows.Forms.Panel();
			this.currentROMData = new LazyShell.Controls.NewRichTextBox();
			this.originalROMData = new LazyShell.Controls.NewRichTextBox();
			this.toolStrip2 = new System.Windows.Forms.ToolStrip();
			this.viewCurrent = new System.Windows.Forms.ToolStripButton();
			this.viewOriginal = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.helpTips = new System.Windows.Forms.ToolStripButton();
			this.baseConvertor = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.copy = new System.Windows.Forms.ToolStripButton();
			this.paste = new System.Windows.Forms.ToolStripButton();
			this.undo = new System.Windows.Forms.ToolStripButton();
			this.redo = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.gotoAddress = new System.Windows.Forms.ToolStripButton();
			this.search = new System.Windows.Forms.ToolStripButton();
			this.fillBytes = new System.Windows.Forms.ToolStripButton();
			this.ROMOffsets = new LazyShell.Controls.NewRichTextBox();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.toolStrip2.SuspendLayout();
			this.SuspendLayout();
			// 
			// save
			// 
			this.save.Image = global::LazyShell.Properties.Resources.save;
			this.save.Name = "save";
			this.save.Size = new System.Drawing.Size(23, 22);
			this.save.ToolTipText = "Save";
			this.save.Click += new System.EventHandler(this.save_Click);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.info_sel);
			this.panel1.Controls.Add(this.info_value);
			this.panel1.Controls.Add(this.info_offset);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 527);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(505, 23);
			this.panel1.TabIndex = 5;
			// 
			// info_sel
			// 
			this.info_sel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.info_sel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.info_sel.Location = new System.Drawing.Point(260, 0);
			this.info_sel.Name = "info_sel";
			this.info_sel.Size = new System.Drawing.Size(245, 23);
			this.info_sel.TabIndex = 2;
			this.info_sel.Text = "Sel: 0 (0x0) bytes";
			this.info_sel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// info_value
			// 
			this.info_value.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.info_value.Dock = System.Windows.Forms.DockStyle.Left;
			this.info_value.Location = new System.Drawing.Point(130, 0);
			this.info_value.Name = "info_value";
			this.info_value.Size = new System.Drawing.Size(130, 23);
			this.info_value.TabIndex = 1;
			this.info_value.Text = "Value: 0";
			this.info_value.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// info_offset
			// 
			this.info_offset.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.info_offset.Dock = System.Windows.Forms.DockStyle.Left;
			this.info_offset.Location = new System.Drawing.Point(0, 0);
			this.info_offset.Name = "info_offset";
			this.info_offset.Size = new System.Drawing.Size(130, 23);
			this.info_offset.TabIndex = 0;
			this.info_offset.Text = "Offset: 000000";
			this.info_offset.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// vScrollBar1
			// 
			this.vScrollBar1.Dock = System.Windows.Forms.DockStyle.Left;
			this.vScrollBar1.LargeChange = 16;
			this.vScrollBar1.Location = new System.Drawing.Point(488, 25);
			this.vScrollBar1.Maximum = 262144;
			this.vScrollBar1.Name = "vScrollBar1";
			this.vScrollBar1.Size = new System.Drawing.Size(16, 502);
			this.vScrollBar1.TabIndex = 4;
			this.vScrollBar1.ValueChanged += new System.EventHandler(this.vScrollBar1_ValueChanged);
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.currentROMData);
			this.panel2.Controls.Add(this.originalROMData);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel2.Location = new System.Drawing.Point(63, 25);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(425, 502);
			this.panel2.TabIndex = 3;
			// 
			// currentROMData
			// 
			this.currentROMData.BackColor = System.Drawing.Color.White;
			this.currentROMData.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.currentROMData.Cursor = System.Windows.Forms.Cursors.Arrow;
			this.currentROMData.Dock = System.Windows.Forms.DockStyle.Fill;
			this.currentROMData.Font = new System.Drawing.Font("Lucida Console", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.currentROMData.ForeColor = System.Drawing.Color.DarkBlue;
			this.currentROMData.HideSelection = false;
			this.currentROMData.Location = new System.Drawing.Point(0, 0);
			this.currentROMData.Name = "currentROMData";
			this.currentROMData.ReadOnly = true;
			this.currentROMData.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
			this.currentROMData.Size = new System.Drawing.Size(425, 502);
			this.currentROMData.TabIndex = 0;
			this.currentROMData.Text = "";
			this.currentROMData.SelectionChanged += new System.EventHandler(this.richTextBox_SelectionChanged);
			this.currentROMData.SizeChanged += new System.EventHandler(this.richTextBox_SizeChanged);
			this.currentROMData.KeyUp += new System.Windows.Forms.KeyEventHandler(this.richTextBox_KeyUp);
			this.currentROMData.MouseUp += new System.Windows.Forms.MouseEventHandler(this.richTextBox_MouseUp);
			this.currentROMData.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.richTextBox_MouseWheel);
			this.currentROMData.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.richTextBox_PreviewKeyDown);
			// 
			// originalROMData
			// 
			this.originalROMData.BackColor = System.Drawing.Color.White;
			this.originalROMData.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.originalROMData.Cursor = System.Windows.Forms.Cursors.Arrow;
			this.originalROMData.Dock = System.Windows.Forms.DockStyle.Fill;
			this.originalROMData.Font = new System.Drawing.Font("Lucida Console", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.originalROMData.ForeColor = System.Drawing.Color.DarkBlue;
			this.originalROMData.HideSelection = false;
			this.originalROMData.Location = new System.Drawing.Point(0, 0);
			this.originalROMData.Name = "originalROMData";
			this.originalROMData.ReadOnly = true;
			this.originalROMData.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
			this.originalROMData.Size = new System.Drawing.Size(425, 502);
			this.originalROMData.TabIndex = 6;
			this.originalROMData.Text = "";
			this.originalROMData.Visible = false;
			this.originalROMData.SelectionChanged += new System.EventHandler(this.richTextBox_SelectionChanged);
			this.originalROMData.SizeChanged += new System.EventHandler(this.richTextBox_SizeChanged);
			this.originalROMData.KeyUp += new System.Windows.Forms.KeyEventHandler(this.richTextBox_KeyUp);
			this.originalROMData.MouseUp += new System.Windows.Forms.MouseEventHandler(this.richTextBox_MouseUp);
			this.originalROMData.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.richTextBox_MouseWheel);
			this.originalROMData.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.richTextBox_PreviewKeyDown);
			// 
			// toolStrip2
			// 
			this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewCurrent,
            this.viewOriginal,
            this.toolStripSeparator3,
            this.save,
            this.helpTips,
            this.baseConvertor,
            this.toolStripSeparator2,
            this.copy,
            this.paste,
            this.undo,
            this.redo,
            this.toolStripSeparator1,
            this.gotoAddress,
            this.search,
            this.fillBytes});
			this.toolStrip2.Location = new System.Drawing.Point(0, 0);
			this.toolStrip2.Name = "toolStrip2";
			this.toolStrip2.Size = new System.Drawing.Size(505, 25);
			this.toolStrip2.TabIndex = 0;
			// 
			// viewCurrent
			// 
			this.viewCurrent.Checked = true;
			this.viewCurrent.CheckState = System.Windows.Forms.CheckState.Checked;
			this.viewCurrent.Image = global::LazyShell.Properties.Resources.cartridge;
			this.viewCurrent.Name = "viewCurrent";
			this.viewCurrent.Size = new System.Drawing.Size(97, 22);
			this.viewCurrent.Text = "Current ROM";
			this.viewCurrent.ToolTipText = "Current ROM";
			this.viewCurrent.Click += new System.EventHandler(this.viewCurrent_Click);
			// 
			// viewOriginal
			// 
			this.viewOriginal.Image = global::LazyShell.Properties.Resources.cartridge;
			this.viewOriginal.Name = "viewOriginal";
			this.viewOriginal.Size = new System.Drawing.Size(99, 22);
			this.viewOriginal.Text = "Original ROM";
			this.viewOriginal.ToolTipText = "Original ROM";
			this.viewOriginal.Click += new System.EventHandler(this.viewOriginal_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.AutoSize = false;
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(8, 25);
			// 
			// helpTips
			// 
			this.helpTips.CheckOnClick = true;
			this.helpTips.Image = global::LazyShell.Properties.Resources.help;
			this.helpTips.Name = "helpTips";
			this.helpTips.Size = new System.Drawing.Size(23, 22);
			this.helpTips.ToolTipText = "Help Tips";
			// 
			// baseConvertor
			// 
			this.baseConvertor.Image = global::LazyShell.Properties.Resources.baseConversion;
			this.baseConvertor.Name = "baseConvertor";
			this.baseConvertor.Size = new System.Drawing.Size(23, 22);
			this.baseConvertor.ToolTipText = "Open base convertor";
			this.baseConvertor.Click += new System.EventHandler(this.baseConvertor_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
			// 
			// copy
			// 
			this.copy.Image = global::LazyShell.Properties.Resources.copy;
			this.copy.Name = "copy";
			this.copy.Size = new System.Drawing.Size(23, 22);
			this.copy.ToolTipText = "Copy";
			this.copy.Click += new System.EventHandler(this.copy_Click);
			// 
			// paste
			// 
			this.paste.Image = global::LazyShell.Properties.Resources.paste;
			this.paste.Name = "paste";
			this.paste.Size = new System.Drawing.Size(23, 22);
			this.paste.ToolTipText = "Paste";
			this.paste.Click += new System.EventHandler(this.paste_Click);
			// 
			// undo
			// 
			this.undo.Image = global::LazyShell.Properties.Resources.undo;
			this.undo.Name = "undo";
			this.undo.Size = new System.Drawing.Size(23, 22);
			this.undo.ToolTipText = "Undo";
			this.undo.Click += new System.EventHandler(this.undo_Click);
			// 
			// redo
			// 
			this.redo.Image = global::LazyShell.Properties.Resources.redo;
			this.redo.Name = "redo";
			this.redo.Size = new System.Drawing.Size(23, 22);
			this.redo.ToolTipText = "Redo";
			this.redo.Click += new System.EventHandler(this.redo_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// gotoAddress
			// 
			this.gotoAddress.Image = global::LazyShell.Properties.Resources.jumpTo;
			this.gotoAddress.Name = "gotoAddress";
			this.gotoAddress.Size = new System.Drawing.Size(23, 22);
			this.gotoAddress.ToolTipText = "Goto offset";
			this.gotoAddress.Click += new System.EventHandler(this.gotoAddress_Click);
			// 
			// search
			// 
			this.search.Image = global::LazyShell.Properties.Resources.search;
			this.search.Name = "search";
			this.search.Size = new System.Drawing.Size(23, 22);
			this.search.ToolTipText = "Search for value(s)";
			this.search.Click += new System.EventHandler(this.search_Click);
			// 
			// fillBytes
			// 
			this.fillBytes.Image = global::LazyShell.Properties.Resources.fill;
			this.fillBytes.Name = "fillBytes";
			this.fillBytes.Size = new System.Drawing.Size(23, 22);
			this.fillBytes.ToolTipText = "Fill selection with value";
			this.fillBytes.Click += new System.EventHandler(this.fillBytes_Click);
			// 
			// ROMOffsets
			// 
			this.ROMOffsets.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.ROMOffsets.Cursor = System.Windows.Forms.Cursors.Arrow;
			this.ROMOffsets.Dock = System.Windows.Forms.DockStyle.Left;
			this.ROMOffsets.Enabled = false;
			this.ROMOffsets.Font = new System.Drawing.Font("Lucida Console", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ROMOffsets.Location = new System.Drawing.Point(0, 25);
			this.ROMOffsets.Name = "ROMOffsets";
			this.ROMOffsets.ReadOnly = true;
			this.ROMOffsets.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
			this.ROMOffsets.Size = new System.Drawing.Size(63, 502);
			this.ROMOffsets.TabIndex = 2;
			this.ROMOffsets.Text = "";
			this.ROMOffsets.SizeChanged += new System.EventHandler(this.richTextBox_SizeChanged);
			this.ROMOffsets.KeyUp += new System.Windows.Forms.KeyEventHandler(this.richTextBox_KeyUp);
			this.ROMOffsets.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.richTextBox_PreviewKeyDown);
			// 
			// HexEditor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(505, 550);
			this.Controls.Add(this.vScrollBar1);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.ROMOffsets);
			this.Controls.Add(this.toolStrip2);
			this.Controls.Add(this.panel1);
			this.Location = new System.Drawing.Point(0, 0);
			this.Name = "HexEditor";
			this.Text = "Hex Editor - Lazy Shell";
			this.VisibleChanged += new System.EventHandler(this.HexEditor_VisibleChanged);
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.toolStrip2.ResumeLayout(false);
			this.toolStrip2.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }
        #endregion

        private Controls.NewRichTextBox ROMOffsets;
        private Controls.NewRichTextBox currentROMData;
        private Controls.NewRichTextBox originalROMData;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label info_value;
        private System.Windows.Forms.Label info_offset;
        private System.Windows.Forms.VScrollBar vScrollBar1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStripButton save;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton undo;
        private System.Windows.Forms.ToolStripButton redo;
        private System.Windows.Forms.ToolStripButton copy;
        private System.Windows.Forms.ToolStripButton paste;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.Label info_sel;
        private System.Windows.Forms.ToolStripButton viewCurrent;
        private System.Windows.Forms.ToolStripButton viewOriginal;
        private System.Windows.Forms.ToolStripButton helpTips;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton gotoAddress;
        private System.Windows.Forms.ToolStripButton search;
        private System.Windows.Forms.ToolStripButton baseConvertor;
        private System.Windows.Forms.ToolStripButton fillBytes;
    }
}