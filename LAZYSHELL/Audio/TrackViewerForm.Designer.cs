namespace LazyShell.Audio
{
    partial class TrackViewerForm
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.picture = new System.Windows.Forms.PictureBox();
            this.hScrollBar = new System.Windows.Forms.HScrollBar();
            this.toolStrip4 = new System.Windows.Forms.ToolStrip();
            this.findCommandText = new System.Windows.Forms.ToolStripTextBox();
            this.findCommand = new System.Windows.Forms.ToolStripButton();
            this.labelCommand = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.labelBits = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator16 = new System.Windows.Forms.ToolStripSeparator();
            this.labelIndex = new System.Windows.Forms.ToolStripLabel();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.newCommands = new System.Windows.Forms.ToolStripComboBox();
            this.newNote = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.delete = new System.Windows.Forms.ToolStripButton();
            this.copy = new System.Windows.Forms.ToolStripButton();
            this.paste = new System.Windows.Forms.ToolStripButton();
            this.duplicate = new System.Windows.Forms.ToolStripButton();
            this.moveLeft = new System.Windows.Forms.ToolStripButton();
            this.moveRight = new System.Windows.Forms.ToolStripButton();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panelParameters = new System.Windows.Forms.Panel();
            this.labelOpcode1 = new System.Windows.Forms.Label();
            this.labelParameter3 = new System.Windows.Forms.Label();
            this.labelParameter2 = new System.Windows.Forms.Label();
            this.parameterByte3 = new System.Windows.Forms.NumericUpDown();
            this.labelParameter1 = new System.Windows.Forms.Label();
            this.opcodeByte1 = new System.Windows.Forms.NumericUpDown();
            this.parameterByte2 = new System.Windows.Forms.NumericUpDown();
            this.parameterByte1 = new System.Windows.Forms.NumericUpDown();
            this.parameterName3 = new System.Windows.Forms.ComboBox();
            this.parameterName1 = new System.Windows.Forms.ComboBox();
            this.parameterName2 = new System.Windows.Forms.ComboBox();
            this.panelNotes = new System.Windows.Forms.Panel();
            this.labelBeat = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.noteNames = new System.Windows.Forms.ComboBox();
            this.noteLengthName = new System.Windows.Forms.ComboBox();
            this.noteLengthByte = new System.Windows.Forms.NumericUpDown();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exportScript = new System.Windows.Forms.ToolStripMenuItem();
            this.importScript = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.clearChannel = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picture)).BeginInit();
            this.toolStrip4.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panelParameters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.parameterByte3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.opcodeByte1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.parameterByte2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.parameterByte1)).BeginInit();
            this.panelNotes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.noteLengthByte)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.picture);
            this.panel1.Controls.Add(this.hScrollBar);
            this.panel1.Location = new System.Drawing.Point(26, 28);
            this.panel1.Margin = new System.Windows.Forms.Padding(30, 3, 3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(366, 329);
            this.panel1.TabIndex = 6;
            // 
            // picture
            // 
            this.picture.BackColor = System.Drawing.SystemColors.Window;
            this.picture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picture.Location = new System.Drawing.Point(0, 0);
            this.picture.Name = "picture";
            this.picture.Size = new System.Drawing.Size(362, 309);
            this.picture.TabIndex = 2;
            this.picture.TabStop = false;
            this.picture.Paint += new System.Windows.Forms.PaintEventHandler(this.picture_Paint);
            this.picture.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picture_MouseDown);
            this.picture.MouseEnter += new System.EventHandler(this.picture_MouseEnter);
            this.picture.MouseLeave += new System.EventHandler(this.picture_MouseLeave);
            this.picture.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picture_MouseMove);
            // 
            // hScrollBar
            // 
            this.hScrollBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.hScrollBar.LargeChange = 100;
            this.hScrollBar.Location = new System.Drawing.Point(0, 309);
            this.hScrollBar.Name = "hScrollBar";
            this.hScrollBar.Size = new System.Drawing.Size(362, 16);
            this.hScrollBar.SmallChange = 10;
            this.hScrollBar.TabIndex = 0;
            this.hScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar_Scroll);
            // 
            // toolStrip4
            // 
            this.toolStrip4.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.findCommandText,
            this.findCommand,
            this.labelCommand,
            this.toolStripSeparator1,
            this.labelBits,
            this.toolStripSeparator16,
            this.labelIndex});
            this.toolStrip4.Location = new System.Drawing.Point(0, 0);
            this.toolStrip4.Name = "toolStrip4";
            this.toolStrip4.Size = new System.Drawing.Size(392, 25);
            this.toolStrip4.TabIndex = 7;
            // 
            // findCommandText
            // 
            this.findCommandText.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.findCommandText.Font = new System.Drawing.Font("Lucida Console", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.findCommandText.MaxLength = 2;
            this.findCommandText.Name = "findCommandText";
            this.findCommandText.Size = new System.Drawing.Size(30, 25);
            this.findCommandText.Visible = false;
            // 
            // findCommand
            // 
            this.findCommand.Image = global::LazyShell.Properties.Resources.search;
            this.findCommand.Name = "findCommand";
            this.findCommand.Size = new System.Drawing.Size(23, 22);
            this.findCommand.ToolTipText = "Find command";
            this.findCommand.Visible = false;
            // 
            // labelCommand
            // 
            this.labelCommand.Name = "labelCommand";
            this.labelCommand.Size = new System.Drawing.Size(19, 22);
            this.labelCommand.Text = "...";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // labelBits
            // 
            this.labelBits.Name = "labelBits";
            this.labelBits.Size = new System.Drawing.Size(19, 22);
            this.labelBits.Text = "...";
            // 
            // toolStripSeparator16
            // 
            this.toolStripSeparator16.Name = "toolStripSeparator16";
            this.toolStripSeparator16.Size = new System.Drawing.Size(6, 25);
            // 
            // labelIndex
            // 
            this.labelIndex.Name = "labelIndex";
            this.labelIndex.Size = new System.Drawing.Size(19, 22);
            this.labelIndex.Text = "...";
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newCommands,
            this.newNote,
            this.toolStripSeparator7,
            this.delete,
            this.copy,
            this.paste,
            this.duplicate,
            this.moveLeft,
            this.moveRight});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(392, 25);
            this.toolStrip2.TabIndex = 5;
            // 
            // newCommands
            // 
            this.newCommands.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.newCommands.Name = "newCommands";
            this.newCommands.Size = new System.Drawing.Size(165, 25);
            // 
            // newNote
            // 
            this.newNote.Image = global::LazyShell.Properties.Resources.new_file;
            this.newNote.Name = "newNote";
            this.newNote.Size = new System.Drawing.Size(23, 22);
            this.newNote.ToolTipText = "New";
            this.newNote.Click += new System.EventHandler(this.newNote_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 25);
            // 
            // delete
            // 
            this.delete.Image = global::LazyShell.Properties.Resources.delete;
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(23, 22);
            this.delete.ToolTipText = "Delete";
            this.delete.Click += new System.EventHandler(this.delete_Click);
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
            // duplicate
            // 
            this.duplicate.Image = global::LazyShell.Properties.Resources.duplicate;
            this.duplicate.Name = "duplicate";
            this.duplicate.Size = new System.Drawing.Size(23, 22);
            this.duplicate.ToolTipText = "Duplicate";
            this.duplicate.Click += new System.EventHandler(this.duplicate_Click);
            // 
            // moveLeft
            // 
            this.moveLeft.Image = global::LazyShell.Properties.Resources.back;
            this.moveLeft.Name = "moveLeft";
            this.moveLeft.Size = new System.Drawing.Size(23, 22);
            this.moveLeft.ToolTipText = "Move Left";
            this.moveLeft.Click += new System.EventHandler(this.moveLeft_Click);
            // 
            // moveRight
            // 
            this.moveRight.Image = global::LazyShell.Properties.Resources.foward;
            this.moveRight.Name = "moveRight";
            this.moveRight.Size = new System.Drawing.Size(23, 22);
            this.moveRight.ToolTipText = "Move Right";
            this.moveRight.Click += new System.EventHandler(this.moveRight_Click);
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.Controls.Add(this.toolStrip4);
            this.panel5.Controls.Add(this.panelParameters);
            this.panel5.Controls.Add(this.panelNotes);
            this.panel5.Location = new System.Drawing.Point(0, 360);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(392, 110);
            this.panel5.TabIndex = 8;
            // 
            // panelParameters
            // 
            this.panelParameters.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelParameters.Controls.Add(this.labelOpcode1);
            this.panelParameters.Controls.Add(this.labelParameter3);
            this.panelParameters.Controls.Add(this.labelParameter2);
            this.panelParameters.Controls.Add(this.parameterByte3);
            this.panelParameters.Controls.Add(this.labelParameter1);
            this.panelParameters.Controls.Add(this.opcodeByte1);
            this.panelParameters.Controls.Add(this.parameterByte2);
            this.panelParameters.Controls.Add(this.parameterByte1);
            this.panelParameters.Controls.Add(this.parameterName3);
            this.panelParameters.Controls.Add(this.parameterName1);
            this.panelParameters.Controls.Add(this.parameterName2);
            this.panelParameters.Location = new System.Drawing.Point(0, 27);
            this.panelParameters.Name = "panelParameters";
            this.panelParameters.Size = new System.Drawing.Size(392, 83);
            this.panelParameters.TabIndex = 0;
            // 
            // labelOpcode1
            // 
            this.labelOpcode1.AutoSize = true;
            this.labelOpcode1.Location = new System.Drawing.Point(6, 9);
            this.labelOpcode1.Name = "labelOpcode1";
            this.labelOpcode1.Size = new System.Drawing.Size(44, 13);
            this.labelOpcode1.TabIndex = 0;
            this.labelOpcode1.Text = "Opcode";
            // 
            // labelParameter3
            // 
            this.labelParameter3.AutoSize = true;
            this.labelParameter3.Location = new System.Drawing.Point(121, 59);
            this.labelParameter3.Name = "labelParameter3";
            this.labelParameter3.Size = new System.Drawing.Size(66, 13);
            this.labelParameter3.TabIndex = 6;
            this.labelParameter3.Text = "Parameter 3";
            // 
            // labelParameter2
            // 
            this.labelParameter2.AutoSize = true;
            this.labelParameter2.Location = new System.Drawing.Point(121, 34);
            this.labelParameter2.Name = "labelParameter2";
            this.labelParameter2.Size = new System.Drawing.Size(66, 13);
            this.labelParameter2.TabIndex = 4;
            this.labelParameter2.Text = "Parameter 2";
            // 
            // parameterByte3
            // 
            this.parameterByte3.Enabled = false;
            this.parameterByte3.Location = new System.Drawing.Point(225, 56);
            this.parameterByte3.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.parameterByte3.Name = "parameterByte3";
            this.parameterByte3.Size = new System.Drawing.Size(124, 21);
            this.parameterByte3.TabIndex = 7;
            this.parameterByte3.ValueChanged += new System.EventHandler(this.parameterByte3_ValueChanged);
            // 
            // labelParameter1
            // 
            this.labelParameter1.AutoSize = true;
            this.labelParameter1.Location = new System.Drawing.Point(121, 9);
            this.labelParameter1.Name = "labelParameter1";
            this.labelParameter1.Size = new System.Drawing.Size(66, 13);
            this.labelParameter1.TabIndex = 2;
            this.labelParameter1.Text = "Parameter 1";
            // 
            // opcodeByte1
            // 
            this.opcodeByte1.Enabled = false;
            this.opcodeByte1.Location = new System.Drawing.Point(65, 6);
            this.opcodeByte1.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.opcodeByte1.Name = "opcodeByte1";
            this.opcodeByte1.Size = new System.Drawing.Size(50, 21);
            this.opcodeByte1.TabIndex = 1;
            this.opcodeByte1.ValueChanged += new System.EventHandler(this.opcodeByte1_ValueChanged);
            // 
            // parameterByte2
            // 
            this.parameterByte2.Enabled = false;
            this.parameterByte2.Location = new System.Drawing.Point(225, 31);
            this.parameterByte2.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.parameterByte2.Name = "parameterByte2";
            this.parameterByte2.Size = new System.Drawing.Size(124, 21);
            this.parameterByte2.TabIndex = 5;
            this.parameterByte2.ValueChanged += new System.EventHandler(this.parameterByte2_ValueChanged);
            // 
            // parameterByte1
            // 
            this.parameterByte1.Enabled = false;
            this.parameterByte1.Location = new System.Drawing.Point(225, 6);
            this.parameterByte1.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.parameterByte1.Name = "parameterByte1";
            this.parameterByte1.Size = new System.Drawing.Size(124, 21);
            this.parameterByte1.TabIndex = 3;
            this.parameterByte1.ValueChanged += new System.EventHandler(this.parameterByte1_ValueChanged);
            // 
            // parameterName3
            // 
            this.parameterName3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.parameterName3.DropDownWidth = 200;
            this.parameterName3.Enabled = false;
            this.parameterName3.FormattingEnabled = true;
            this.parameterName3.Location = new System.Drawing.Point(225, 56);
            this.parameterName3.Name = "parameterName3";
            this.parameterName3.Size = new System.Drawing.Size(124, 21);
            this.parameterName3.TabIndex = 22;
            // 
            // parameterName1
            // 
            this.parameterName1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.parameterName1.DropDownWidth = 200;
            this.parameterName1.Enabled = false;
            this.parameterName1.FormattingEnabled = true;
            this.parameterName1.Location = new System.Drawing.Point(225, 6);
            this.parameterName1.Name = "parameterName1";
            this.parameterName1.Size = new System.Drawing.Size(124, 21);
            this.parameterName1.TabIndex = 17;
            // 
            // parameterName2
            // 
            this.parameterName2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.parameterName2.DropDownWidth = 200;
            this.parameterName2.Enabled = false;
            this.parameterName2.FormattingEnabled = true;
            this.parameterName2.Location = new System.Drawing.Point(225, 31);
            this.parameterName2.Name = "parameterName2";
            this.parameterName2.Size = new System.Drawing.Size(124, 21);
            this.parameterName2.TabIndex = 22;
            // 
            // panelNotes
            // 
            this.panelNotes.Controls.Add(this.labelBeat);
            this.panelNotes.Controls.Add(this.label12);
            this.panelNotes.Controls.Add(this.noteNames);
            this.panelNotes.Controls.Add(this.noteLengthName);
            this.panelNotes.Controls.Add(this.noteLengthByte);
            this.panelNotes.Location = new System.Drawing.Point(0, 27);
            this.panelNotes.Name = "panelNotes";
            this.panelNotes.Size = new System.Drawing.Size(362, 77);
            this.panelNotes.TabIndex = 0;
            // 
            // labelBeat
            // 
            this.labelBeat.AutoSize = true;
            this.labelBeat.Location = new System.Drawing.Point(115, 9);
            this.labelBeat.Name = "labelBeat";
            this.labelBeat.Size = new System.Drawing.Size(29, 13);
            this.labelBeat.TabIndex = 1;
            this.labelBeat.Text = "Beat";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(9, 9);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(30, 13);
            this.label12.TabIndex = 1;
            this.label12.Text = "Note";
            // 
            // noteNames
            // 
            this.noteNames.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.noteNames.FormattingEnabled = true;
            this.noteNames.Items.AddRange(new object[] {
            "C",
            "C# / Db",
            "D",
            "D# / Eb",
            "E / Fb",
            "F",
            "F# / Gb",
            "G",
            "G# / Ab",
            "A",
            "A# / Bb",
            "B / Cb",
            "Rest",
            "Tie"});
            this.noteNames.Location = new System.Drawing.Point(46, 6);
            this.noteNames.Name = "noteNames";
            this.noteNames.Size = new System.Drawing.Size(61, 21);
            this.noteNames.TabIndex = 0;
            this.noteNames.SelectedIndexChanged += new System.EventHandler(this.noteNames_SelectedIndexChanged);
            // 
            // noteLengthName
            // 
            this.noteLengthName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.noteLengthName.FormattingEnabled = true;
            this.noteLengthName.Items.AddRange(new object[] {
            "whole",
            "half.",
            "half",
            "quarter.",
            "quarter",
            "8th.",
            "quarter triplet",
            "8th",
            "8th triplet",
            "16th",
            "16th triplet",
            "32nd",
            "64th"});
            this.noteLengthName.Location = new System.Drawing.Point(166, 6);
            this.noteLengthName.Name = "noteLengthName";
            this.noteLengthName.Size = new System.Drawing.Size(81, 21);
            this.noteLengthName.TabIndex = 1;
            this.noteLengthName.SelectedIndexChanged += new System.EventHandler(this.noteLengthName_SelectedIndexChanged);
            // 
            // noteLengthByte
            // 
            this.noteLengthByte.Location = new System.Drawing.Point(166, 6);
            this.noteLengthByte.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.noteLengthByte.Name = "noteLengthByte";
            this.noteLengthByte.Size = new System.Drawing.Size(81, 21);
            this.noteLengthByte.TabIndex = 6;
            this.noteLengthByte.ValueChanged += new System.EventHandler(this.noteLengthByte_ValueChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportScript,
            this.importScript,
            this.toolStripSeparator6,
            this.clearChannel});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(191, 76);
            // 
            // exportScript
            // 
            this.exportScript.Image = global::LazyShell.Properties.Resources.exportText;
            this.exportScript.Name = "exportScript";
            this.exportScript.Size = new System.Drawing.Size(190, 22);
            this.exportScript.Text = "Export Channel Script...";
            // 
            // importScript
            // 
            this.importScript.Image = global::LazyShell.Properties.Resources.importText;
            this.importScript.Name = "importScript";
            this.importScript.Size = new System.Drawing.Size(190, 22);
            this.importScript.Text = "Import Channel Script...";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(187, 6);
            // 
            // clearChannel
            // 
            this.clearChannel.Image = global::LazyShell.Properties.Resources.clear;
            this.clearChannel.Name = "clearChannel";
            this.clearChannel.Size = new System.Drawing.Size(190, 22);
            this.clearChannel.Text = "Clear Channel";
            // 
            // TrackViewerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 470);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.panel5);
            this.Name = "TrackViewerForm";
            this.Text = "Channel Tracks";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picture)).EndInit();
            this.toolStrip4.ResumeLayout(false);
            this.toolStrip4.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panelParameters.ResumeLayout(false);
            this.panelParameters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.parameterByte3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.opcodeByte1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.parameterByte2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.parameterByte1)).EndInit();
            this.panelNotes.ResumeLayout(false);
            this.panelNotes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.noteLengthByte)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox picture;
        private System.Windows.Forms.HScrollBar hScrollBar;
        private System.Windows.Forms.ToolStrip toolStrip4;
        private System.Windows.Forms.ToolStripTextBox findCommandText;
        private System.Windows.Forms.ToolStripButton findCommand;
        private System.Windows.Forms.ToolStripLabel labelCommand;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel labelBits;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator16;
        private System.Windows.Forms.ToolStripLabel labelIndex;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripComboBox newCommands;
        private System.Windows.Forms.ToolStripButton newNote;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripButton delete;
        private System.Windows.Forms.ToolStripButton copy;
        private System.Windows.Forms.ToolStripButton paste;
        private System.Windows.Forms.ToolStripButton duplicate;
        private System.Windows.Forms.ToolStripButton moveLeft;
        private System.Windows.Forms.ToolStripButton moveRight;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panelParameters;
        private System.Windows.Forms.Label labelOpcode1;
        private System.Windows.Forms.Label labelParameter3;
        private System.Windows.Forms.Label labelParameter2;
        private System.Windows.Forms.NumericUpDown parameterByte3;
        private System.Windows.Forms.Label labelParameter1;
        private System.Windows.Forms.NumericUpDown opcodeByte1;
        private System.Windows.Forms.NumericUpDown parameterByte2;
        private System.Windows.Forms.NumericUpDown parameterByte1;
        private System.Windows.Forms.ComboBox parameterName3;
        private System.Windows.Forms.ComboBox parameterName1;
        private System.Windows.Forms.ComboBox parameterName2;
        private System.Windows.Forms.Panel panelNotes;
        private System.Windows.Forms.Label labelBeat;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox noteNames;
        private System.Windows.Forms.ComboBox noteLengthName;
        private System.Windows.Forms.NumericUpDown noteLengthByte;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem exportScript;
        private System.Windows.Forms.ToolStripMenuItem importScript;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem clearChannel;
    }
}