namespace LAZYSHELL
{
    partial class HexEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HexEditor));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.viewCurrent = new System.Windows.Forms.ToolStripButton();
            this.viewOriginal = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.gotoAddress = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.searchValues = new System.Windows.Forms.ToolStripTextBox();
            this.save = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.info_sel = new System.Windows.Forms.Label();
            this.info_value = new System.Windows.Forms.Label();
            this.info_offset = new System.Windows.Forms.Label();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.panel2 = new System.Windows.Forms.Panel();
            this.richTextBox2 = new LAZYSHELL.NewRichTextBox();
            this.richTextBox3 = new LAZYSHELL.NewRichTextBox();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.copy = new System.Windows.Forms.ToolStripButton();
            this.paste = new System.Windows.Forms.ToolStripButton();
            this.undo = new System.Windows.Forms.ToolStripButton();
            this.redo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.fillWith = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.baseConvDec = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel5 = new System.Windows.Forms.ToolStripLabel();
            this.baseConvHex = new System.Windows.Forms.ToolStripTextBox();
            this.richTextBox1 = new LAZYSHELL.NewRichTextBox();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewCurrent,
            this.viewOriginal,
            this.toolStripSeparator1,
            this.toolStripLabel1,
            this.gotoAddress,
            this.toolStripLabel2,
            this.searchValues});
            this.toolStrip1.Location = new System.Drawing.Point(0, 25);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(504, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // viewCurrent
            // 
            this.viewCurrent.Checked = true;
            this.viewCurrent.CheckState = System.Windows.Forms.CheckState.Checked;
            this.viewCurrent.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.viewCurrent.Name = "viewCurrent";
            this.viewCurrent.Size = new System.Drawing.Size(75, 22);
            this.viewCurrent.Text = "Current ROM";
            this.viewCurrent.Click += new System.EventHandler(this.viewCurrent_Click);
            // 
            // viewOriginal
            // 
            this.viewOriginal.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.viewOriginal.Name = "viewOriginal";
            this.viewOriginal.Size = new System.Drawing.Size(76, 22);
            this.viewOriginal.Text = "Original ROM";
            this.viewOriginal.Click += new System.EventHandler(this.viewOriginal_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(28, 22);
            this.toolStripLabel1.Text = "Goto";
            // 
            // gotoAddress
            // 
            this.gotoAddress.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.gotoAddress.Font = new System.Drawing.Font("Lucida Console", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gotoAddress.MaxLength = 6;
            this.gotoAddress.Name = "gotoAddress";
            this.gotoAddress.Size = new System.Drawing.Size(74, 25);
            this.gotoAddress.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gotoAddress_KeyDown);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(26, 22);
            this.toolStripLabel2.Text = "Find";
            // 
            // searchValues
            // 
            this.searchValues.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.searchValues.Font = new System.Drawing.Font("Lucida Console", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchValues.MaxLength = 24;
            this.searchValues.Name = "searchValues";
            this.searchValues.Size = new System.Drawing.Size(185, 25);
            this.searchValues.KeyDown += new System.Windows.Forms.KeyEventHandler(this.searchValues_KeyDown);
            // 
            // save
            // 
            this.save.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.save.Image = global::LAZYSHELL.Properties.Resources.save_small;
            this.save.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.save.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(23, 22);
            this.save.Text = "Save changes";
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.info_sel);
            this.panel1.Controls.Add(this.info_value);
            this.panel1.Controls.Add(this.info_offset);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 535);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(504, 15);
            this.panel1.TabIndex = 8;
            // 
            // info_sel
            // 
            this.info_sel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.info_sel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.info_sel.Location = new System.Drawing.Point(260, 0);
            this.info_sel.Name = "info_sel";
            this.info_sel.Size = new System.Drawing.Size(244, 15);
            this.info_sel.TabIndex = 10;
            this.info_sel.Text = "Sel: 0 (0x0) bytes";
            this.info_sel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // info_value
            // 
            this.info_value.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.info_value.Dock = System.Windows.Forms.DockStyle.Left;
            this.info_value.Location = new System.Drawing.Point(130, 0);
            this.info_value.Name = "info_value";
            this.info_value.Size = new System.Drawing.Size(130, 15);
            this.info_value.TabIndex = 9;
            this.info_value.Text = "Value: 0";
            this.info_value.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // info_offset
            // 
            this.info_offset.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.info_offset.Dock = System.Windows.Forms.DockStyle.Left;
            this.info_offset.Location = new System.Drawing.Point(0, 0);
            this.info_offset.Name = "info_offset";
            this.info_offset.Size = new System.Drawing.Size(130, 15);
            this.info_offset.TabIndex = 8;
            this.info_offset.Text = "Offset: 000000";
            this.info_offset.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Dock = System.Windows.Forms.DockStyle.Left;
            this.vScrollBar1.LargeChange = 16;
            this.vScrollBar1.Location = new System.Drawing.Point(488, 50);
            this.vScrollBar1.Maximum = 262144;
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(16, 485);
            this.vScrollBar1.TabIndex = 9;
            this.vScrollBar1.ValueChanged += new System.EventHandler(this.vScrollBar1_ValueChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.richTextBox2);
            this.panel2.Controls.Add(this.richTextBox3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(63, 50);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(425, 485);
            this.panel2.TabIndex = 10;
            // 
            // richTextBox2
            // 
            this.richTextBox2.BackColor = System.Drawing.Color.White;
            this.richTextBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox2.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.richTextBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox2.Font = new System.Drawing.Font("Lucida Console", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox2.ForeColor = System.Drawing.Color.DarkBlue;
            this.richTextBox2.HideSelection = false;
            this.richTextBox2.Location = new System.Drawing.Point(0, 0);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.ReadOnly = true;
            this.richTextBox2.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.richTextBox2.Size = new System.Drawing.Size(425, 485);
            this.richTextBox2.TabIndex = 5;
            this.richTextBox2.Text = "";
            this.richTextBox2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.richTextBox_KeyDown);
            this.richTextBox2.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.richTextBox_MouseWheel);
            this.richTextBox2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.richTextBox_MouseUp);
            this.richTextBox2.SelectionChanged += new System.EventHandler(this.richTextBox_SelectionChanged);
            this.richTextBox2.SizeChanged += new System.EventHandler(this.richTextBox_SizeChanged);
            this.richTextBox2.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.richTextBox_PreviewKeyDown);
            this.richTextBox2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.richTextBox_MouseDown);
            this.richTextBox2.KeyUp += new System.Windows.Forms.KeyEventHandler(this.richTextBox_KeyUp);
            // 
            // richTextBox3
            // 
            this.richTextBox3.BackColor = System.Drawing.Color.White;
            this.richTextBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox3.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.richTextBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox3.Font = new System.Drawing.Font("Lucida Console", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox3.ForeColor = System.Drawing.Color.DarkBlue;
            this.richTextBox3.HideSelection = false;
            this.richTextBox3.Location = new System.Drawing.Point(0, 0);
            this.richTextBox3.Name = "richTextBox3";
            this.richTextBox3.ReadOnly = true;
            this.richTextBox3.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.richTextBox3.Size = new System.Drawing.Size(425, 485);
            this.richTextBox3.TabIndex = 6;
            this.richTextBox3.Text = "";
            this.richTextBox3.Visible = false;
            this.richTextBox3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.richTextBox_KeyDown);
            this.richTextBox3.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.richTextBox_MouseWheel);
            this.richTextBox3.MouseUp += new System.Windows.Forms.MouseEventHandler(this.richTextBox_MouseUp);
            this.richTextBox3.SelectionChanged += new System.EventHandler(this.richTextBox_SelectionChanged);
            this.richTextBox3.SizeChanged += new System.EventHandler(this.richTextBox_SizeChanged);
            this.richTextBox3.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.richTextBox_PreviewKeyDown);
            this.richTextBox3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.richTextBox_MouseDown);
            this.richTextBox3.KeyUp += new System.Windows.Forms.KeyEventHandler(this.richTextBox_KeyUp);
            // 
            // toolStrip2
            // 
            this.toolStrip2.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.save,
            this.toolStripSeparator2,
            this.copy,
            this.paste,
            this.undo,
            this.redo,
            this.toolStripSeparator3,
            this.toolStripLabel3,
            this.fillWith,
            this.toolStripSeparator4,
            this.toolStripLabel4,
            this.baseConvDec,
            this.toolStripLabel5,
            this.baseConvHex});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip2.Size = new System.Drawing.Size(504, 25);
            this.toolStrip2.TabIndex = 11;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // copy
            // 
            this.copy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.copy.Image = global::LAZYSHELL.Properties.Resources.copy_small;
            this.copy.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.copy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.copy.Name = "copy";
            this.copy.Size = new System.Drawing.Size(23, 22);
            this.copy.Text = "Copy";
            this.copy.Click += new System.EventHandler(this.copy_Click);
            // 
            // paste
            // 
            this.paste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.paste.Image = global::LAZYSHELL.Properties.Resources.paste_small;
            this.paste.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.paste.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.paste.Name = "paste";
            this.paste.Size = new System.Drawing.Size(23, 22);
            this.paste.Text = "Paste";
            this.paste.Click += new System.EventHandler(this.paste_Click);
            // 
            // undo
            // 
            this.undo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.undo.Image = global::LAZYSHELL.Properties.Resources.undo_small;
            this.undo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.undo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.undo.Name = "undo";
            this.undo.Size = new System.Drawing.Size(23, 22);
            this.undo.Text = "Undo";
            this.undo.Click += new System.EventHandler(this.undo_Click);
            // 
            // redo
            // 
            this.redo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.redo.Image = global::LAZYSHELL.Properties.Resources.redo_small;
            this.redo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.redo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.redo.Name = "redo";
            this.redo.Size = new System.Drawing.Size(23, 22);
            this.redo.Text = "Redo";
            this.redo.Click += new System.EventHandler(this.redo_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.AutoSize = false;
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(8, 25);
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(56, 22);
            this.toolStripLabel3.Text = "Fill sel. w/";
            // 
            // fillWith
            // 
            this.fillWith.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.fillWith.Font = new System.Drawing.Font("Lucida Console", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fillWith.MaxLength = 2;
            this.fillWith.Name = "fillWith";
            this.fillWith.Size = new System.Drawing.Size(36, 25);
            this.fillWith.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fillWith_KeyDown);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(58, 22);
            this.toolStripLabel4.Text = "Base conv.";
            // 
            // baseConvDec
            // 
            this.baseConvDec.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.baseConvDec.Font = new System.Drawing.Font("Lucida Console", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.baseConvDec.MaxLength = 10;
            this.baseConvDec.Name = "baseConvDec";
            this.baseConvDec.Size = new System.Drawing.Size(80, 25);
            this.baseConvDec.TextChanged += new System.EventHandler(this.baseConvDec_TextChanged);
            // 
            // toolStripLabel5
            // 
            this.toolStripLabel5.Name = "toolStripLabel5";
            this.toolStripLabel5.Size = new System.Drawing.Size(23, 22);
            this.toolStripLabel5.Text = "hex";
            // 
            // baseConvHex
            // 
            this.baseConvHex.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.baseConvHex.Font = new System.Drawing.Font("Lucida Console", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.baseConvHex.MaxLength = 8;
            this.baseConvHex.Name = "baseConvHex";
            this.baseConvHex.Size = new System.Drawing.Size(80, 25);
            this.baseConvHex.TextChanged += new System.EventHandler(this.baseConvHex_TextChanged);
            // 
            // richTextBox1
            // 
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.richTextBox1.Enabled = false;
            this.richTextBox1.Font = new System.Drawing.Font("Lucida Console", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(0, 50);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.richTextBox1.Size = new System.Drawing.Size(63, 485);
            this.richTextBox1.TabIndex = 4;
            this.richTextBox1.Text = "";
            this.richTextBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.richTextBox_KeyDown);
            this.richTextBox1.SizeChanged += new System.EventHandler(this.richTextBox_SizeChanged);
            this.richTextBox1.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.richTextBox_PreviewKeyDown);
            this.richTextBox1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.richTextBox_KeyUp);
            // 
            // HexEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 550);
            this.Controls.Add(this.vScrollBar1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip2);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "HexEditor";
            this.Text = "HEX EDITOR - Lazy Shell";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.HexViewer_FormClosing);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox gotoAddress;
        private LAZYSHELL.NewRichTextBox richTextBox1;
        private LAZYSHELL.NewRichTextBox richTextBox2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton viewOriginal;
        private System.Windows.Forms.ToolStripButton viewCurrent;
        private LAZYSHELL.NewRichTextBox richTextBox3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label info_value;
        private System.Windows.Forms.Label info_offset;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripTextBox searchValues;
        private System.Windows.Forms.VScrollBar vScrollBar1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStripButton save;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton undo;
        private System.Windows.Forms.ToolStripButton redo;
        private System.Windows.Forms.ToolStripButton copy;
        private System.Windows.Forms.ToolStripButton paste;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripTextBox fillWith;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.Label info_sel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
        private System.Windows.Forms.ToolStripTextBox baseConvDec;
        private System.Windows.Forms.ToolStripLabel toolStripLabel5;
        private System.Windows.Forms.ToolStripTextBox baseConvHex;
    }
}