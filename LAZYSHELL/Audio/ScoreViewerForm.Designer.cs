namespace LAZYSHELL.Audio
{
    partial class ScoreViewerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScoreViewerForm));
            this.panel2 = new System.Windows.Forms.Panel();
            this.scoreViewPanel = new LAZYSHELL.Controls.NewPanel();
            this.picture = new LAZYSHELL.Controls.NewPictureBox();
            this.hScrollBar = new System.Windows.Forms.HScrollBar();
            this.labelNote = new System.Windows.Forms.Label();
            this.toolStripAction = new System.Windows.Forms.ToolStrip();
            this.draw = new System.Windows.Forms.ToolStripButton();
            this.erase = new System.Windows.Forms.ToolStripButton();
            this.select = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator19 = new System.Windows.Forms.ToolStripSeparator();
            this.cut = new System.Windows.Forms.ToolStripButton();
            this.copy = new System.Windows.Forms.ToolStripButton();
            this.paste = new System.Windows.Forms.ToolStripButton();
            this.delete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator20 = new System.Windows.Forms.ToolStripSeparator();
            this.undo = new System.Windows.Forms.ToolStripButton();
            this.redo = new System.Windows.Forms.ToolStripButton();
            this.toolStripNote = new System.Windows.Forms.ToolStrip();
            this.sharp = new System.Windows.Forms.ToolStripButton();
            this.flat = new System.Windows.Forms.ToolStripButton();
            this.natural = new System.Windows.Forms.ToolStripButton();
            this.tie = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator17 = new System.Windows.Forms.ToolStripSeparator();
            this.noteWhole = new System.Windows.Forms.ToolStripButton();
            this.noteHalfD = new System.Windows.Forms.ToolStripButton();
            this.noteHalf = new System.Windows.Forms.ToolStripButton();
            this.noteQuarterD = new System.Windows.Forms.ToolStripButton();
            this.noteQuarter = new System.Windows.Forms.ToolStripButton();
            this.noteQuarterT = new System.Windows.Forms.ToolStripButton();
            this.note8thD = new System.Windows.Forms.ToolStripButton();
            this.note8th = new System.Windows.Forms.ToolStripButton();
            this.note8thT = new System.Windows.Forms.ToolStripButton();
            this.note16th = new System.Windows.Forms.ToolStripButton();
            this.note16thT = new System.Windows.Forms.ToolStripButton();
            this.note32nd = new System.Windows.Forms.ToolStripButton();
            this.note64th = new System.Windows.Forms.ToolStripButton();
            this.ticksNoteButton = new System.Windows.Forms.ToolStripButton();
            this.ticksNoteValue = new LAZYSHELL.Controls.NewToolStripNumericUpDown();
            this.toolStripSeparator18 = new System.Windows.Forms.ToolStripSeparator();
            this.restWhole = new System.Windows.Forms.ToolStripButton();
            this.restHalfD = new System.Windows.Forms.ToolStripButton();
            this.restHalf = new System.Windows.Forms.ToolStripButton();
            this.restQuarterD = new System.Windows.Forms.ToolStripButton();
            this.restQuarter = new System.Windows.Forms.ToolStripButton();
            this.restQuarterT = new System.Windows.Forms.ToolStripButton();
            this.rest8thD = new System.Windows.Forms.ToolStripButton();
            this.rest8th = new System.Windows.Forms.ToolStripButton();
            this.rest8thT = new System.Windows.Forms.ToolStripButton();
            this.rest16th = new System.Windows.Forms.ToolStripButton();
            this.rest16thT = new System.Windows.Forms.ToolStripButton();
            this.rest32nd = new System.Windows.Forms.ToolStripButton();
            this.rest64th = new System.Windows.Forms.ToolStripButton();
            this.ticksRestButton = new System.Windows.Forms.ToolStripButton();
            this.ticksRestValue = new LAZYSHELL.Controls.NewToolStripNumericUpDown();
            this.toolStripMain = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel10 = new System.Windows.Forms.ToolStripLabel();
            this.clefName = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.keySV = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel7 = new System.Windows.Forms.ToolStripLabel();
            this.timeBeatsSV = new LAZYSHELL.Controls.NewToolStripNumericUpDown();
            this.timeValueSV = new LAZYSHELL.Controls.NewToolStripNumericUpDown();
            this.toolStripSeparator21 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel6 = new System.Windows.Forms.ToolStripLabel();
            this.staffHeightSV = new LAZYSHELL.Controls.NewToolStripNumericUpDown();
            this.toolStripLabel8 = new System.Windows.Forms.ToolStripLabel();
            this.noteSpacingSV = new LAZYSHELL.Controls.NewToolStripNumericUpDown();
            this.showRests = new LAZYSHELL.Controls.NewToolStripCheckBox();
            this.panel2.SuspendLayout();
            this.scoreViewPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picture)).BeginInit();
            this.toolStripAction.SuspendLayout();
            this.toolStripNote.SuspendLayout();
            this.toolStripMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.scoreViewPanel);
            this.panel2.Controls.Add(this.hScrollBar);
            this.panel2.Location = new System.Drawing.Point(24, 50);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(868, 404);
            this.panel2.TabIndex = 21;
            // 
            // scoreViewPanel
            // 
            this.scoreViewPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.scoreViewPanel.AutoScroll = true;
            this.scoreViewPanel.Controls.Add(this.picture);
            this.scoreViewPanel.Location = new System.Drawing.Point(0, 0);
            this.scoreViewPanel.Name = "scoreViewPanel";
            this.scoreViewPanel.Size = new System.Drawing.Size(864, 384);
            this.scoreViewPanel.TabIndex = 0;
            // 
            // picture
            // 
            this.picture.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.picture.Dock = System.Windows.Forms.DockStyle.Top;
            this.picture.Location = new System.Drawing.Point(0, 0);
            this.picture.Name = "picture";
            this.picture.Size = new System.Drawing.Size(848, 768);
            this.picture.TabIndex = 2;
            this.picture.TabStop = false;
            this.picture.Zoom = 1;
            this.picture.ZoomBoxEnabled = false;
            this.picture.ZoomBoxPosition = new System.Drawing.Point(32, 32);
            this.picture.ZoomBoxZoom = 4;
            this.picture.ZoomEnabled = false;
            this.picture.Paint += new System.Windows.Forms.PaintEventHandler(this.picture_Paint);
            this.picture.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picture_MouseDown);
            this.picture.MouseEnter += new System.EventHandler(this.picture_MouseEnter);
            this.picture.MouseLeave += new System.EventHandler(this.picture_MouseLeave);
            this.picture.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picture_MouseMove);
            // 
            // hScrollBar
            // 
            this.hScrollBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hScrollBar.LargeChange = 100;
            this.hScrollBar.Location = new System.Drawing.Point(0, 384);
            this.hScrollBar.Name = "hScrollBar";
            this.hScrollBar.Size = new System.Drawing.Size(848, 16);
            this.hScrollBar.SmallChange = 10;
            this.hScrollBar.TabIndex = 1;
            this.hScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar_Scroll);
            // 
            // labelNote
            // 
            this.labelNote.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelNote.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelNote.Location = new System.Drawing.Point(24, 455);
            this.labelNote.Name = "labelNote";
            this.labelNote.Size = new System.Drawing.Size(868, 21);
            this.labelNote.TabIndex = 2;
            this.labelNote.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripAction
            // 
            this.toolStripAction.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolStripAction.Enabled = false;
            this.toolStripAction.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.draw,
            this.erase,
            this.select,
            this.toolStripSeparator19,
            this.cut,
            this.copy,
            this.paste,
            this.delete,
            this.toolStripSeparator20,
            this.undo,
            this.redo});
            this.toolStripAction.Location = new System.Drawing.Point(0, 50);
            this.toolStripAction.Name = "toolStripAction";
            this.toolStripAction.Size = new System.Drawing.Size(24, 426);
            this.toolStripAction.TabIndex = 23;
            // 
            // draw
            // 
            this.draw.CheckOnClick = true;
            this.draw.Image = global::LAZYSHELL.Properties.Resources.draw;
            this.draw.Name = "draw";
            this.draw.Size = new System.Drawing.Size(21, 20);
            this.draw.ToolTipText = "Draw (D)";
            this.draw.CheckedChanged += new System.EventHandler(this.draw_CheckedChanged);
            // 
            // erase
            // 
            this.erase.CheckOnClick = true;
            this.erase.Image = global::LAZYSHELL.Properties.Resources.erase;
            this.erase.Name = "erase";
            this.erase.Size = new System.Drawing.Size(21, 20);
            this.erase.ToolTipText = "Erase (E)";
            this.erase.CheckedChanged += new System.EventHandler(this.erase_CheckedChanged);
            // 
            // select
            // 
            this.select.CheckOnClick = true;
            this.select.Image = global::LAZYSHELL.Properties.Resources.select;
            this.select.Name = "select";
            this.select.Size = new System.Drawing.Size(21, 20);
            this.select.ToolTipText = "Select (S)";
            this.select.CheckedChanged += new System.EventHandler(this.select_CheckedChanged);
            // 
            // toolStripSeparator19
            // 
            this.toolStripSeparator19.Name = "toolStripSeparator19";
            this.toolStripSeparator19.Size = new System.Drawing.Size(21, 6);
            // 
            // cut
            // 
            this.cut.Image = global::LAZYSHELL.Properties.Resources.cut;
            this.cut.Name = "cut";
            this.cut.Size = new System.Drawing.Size(21, 20);
            this.cut.ToolTipText = "Cut (Ctrl+X)";
            // 
            // copy
            // 
            this.copy.Image = global::LAZYSHELL.Properties.Resources.copy;
            this.copy.Name = "copy";
            this.copy.Size = new System.Drawing.Size(21, 20);
            this.copy.ToolTipText = "Copy (Ctrl+C)";
            // 
            // paste
            // 
            this.paste.CheckOnClick = true;
            this.paste.Image = global::LAZYSHELL.Properties.Resources.paste;
            this.paste.Name = "paste";
            this.paste.Size = new System.Drawing.Size(21, 20);
            this.paste.ToolTipText = "Paste (Ctrl+V)";
            this.paste.CheckedChanged += new System.EventHandler(this.paste_CheckedChanged);
            // 
            // delete
            // 
            this.delete.Image = global::LAZYSHELL.Properties.Resources.delete;
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(21, 20);
            this.delete.ToolTipText = "Delete (Del)";
            this.delete.Click += new System.EventHandler(this.delete_Click);
            // 
            // toolStripSeparator20
            // 
            this.toolStripSeparator20.Name = "toolStripSeparator20";
            this.toolStripSeparator20.Size = new System.Drawing.Size(21, 6);
            // 
            // undo
            // 
            this.undo.Image = global::LAZYSHELL.Properties.Resources.undo;
            this.undo.Name = "undo";
            this.undo.Size = new System.Drawing.Size(21, 20);
            this.undo.ToolTipText = "Undo (Ctrl+Z)";
            this.undo.Click += new System.EventHandler(this.undo_Click);
            // 
            // redo
            // 
            this.redo.Image = global::LAZYSHELL.Properties.Resources.redo;
            this.redo.Name = "redo";
            this.redo.Size = new System.Drawing.Size(21, 20);
            this.redo.ToolTipText = "Redo (Ctrl+Y)";
            this.redo.Click += new System.EventHandler(this.redo_Click);
            // 
            // toolStripNote
            // 
            this.toolStripNote.Enabled = false;
            this.toolStripNote.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sharp,
            this.flat,
            this.natural,
            this.tie,
            this.toolStripSeparator17,
            this.noteWhole,
            this.noteHalfD,
            this.noteHalf,
            this.noteQuarterD,
            this.noteQuarter,
            this.noteQuarterT,
            this.note8thD,
            this.note8th,
            this.note8thT,
            this.note16th,
            this.note16thT,
            this.note32nd,
            this.note64th,
            this.ticksNoteButton,
            this.ticksNoteValue,
            this.toolStripSeparator18,
            this.restWhole,
            this.restHalfD,
            this.restHalf,
            this.restQuarterD,
            this.restQuarter,
            this.restQuarterT,
            this.rest8thD,
            this.rest8th,
            this.rest8thT,
            this.rest16th,
            this.rest16thT,
            this.rest32nd,
            this.rest64th,
            this.ticksRestButton,
            this.ticksRestValue});
            this.toolStripNote.Location = new System.Drawing.Point(0, 25);
            this.toolStripNote.Name = "toolStripNote";
            this.toolStripNote.Size = new System.Drawing.Size(892, 25);
            this.toolStripNote.TabIndex = 22;
            // 
            // sharp
            // 
            this.sharp.AutoSize = false;
            this.sharp.CheckOnClick = true;
            this.sharp.Image = global::LAZYSHELL.Properties.Resources.sharp;
            this.sharp.Name = "sharp";
            this.sharp.Size = new System.Drawing.Size(23, 22);
            this.sharp.ToolTipText = "Sharp";
            this.sharp.Click += new System.EventHandler(this.note_Click);
            // 
            // flat
            // 
            this.flat.CheckOnClick = true;
            this.flat.Image = global::LAZYSHELL.Properties.Resources.flat;
            this.flat.Name = "flat";
            this.flat.Size = new System.Drawing.Size(23, 22);
            this.flat.ToolTipText = "Flat";
            this.flat.Click += new System.EventHandler(this.note_Click);
            // 
            // natural
            // 
            this.natural.CheckOnClick = true;
            this.natural.Image = global::LAZYSHELL.Properties.Resources.natural;
            this.natural.Name = "natural";
            this.natural.Size = new System.Drawing.Size(23, 22);
            this.natural.ToolTipText = "Natural";
            this.natural.Click += new System.EventHandler(this.note_Click);
            // 
            // tie
            // 
            this.tie.CheckOnClick = true;
            this.tie.Image = ((System.Drawing.Image)(resources.GetObject("tie.Image")));
            this.tie.Name = "tie";
            this.tie.Size = new System.Drawing.Size(23, 22);
            this.tie.ToolTipText = "Tie";
            this.tie.Click += new System.EventHandler(this.note_Click);
            // 
            // toolStripSeparator17
            // 
            this.toolStripSeparator17.Name = "toolStripSeparator17";
            this.toolStripSeparator17.Size = new System.Drawing.Size(6, 25);
            // 
            // noteWhole
            // 
            this.noteWhole.CheckOnClick = true;
            this.noteWhole.Image = global::LAZYSHELL.Properties.Resources.noteWhole;
            this.noteWhole.Name = "noteWhole";
            this.noteWhole.Size = new System.Drawing.Size(23, 22);
            this.noteWhole.ToolTipText = "Whole Note";
            this.noteWhole.Click += new System.EventHandler(this.note_Click);
            // 
            // noteHalfD
            // 
            this.noteHalfD.CheckOnClick = true;
            this.noteHalfD.Image = global::LAZYSHELL.Properties.Resources.noteHalfDotted;
            this.noteHalfD.Name = "noteHalfD";
            this.noteHalfD.Size = new System.Drawing.Size(23, 22);
            this.noteHalfD.ToolTipText = "Dotted Half Note";
            this.noteHalfD.Click += new System.EventHandler(this.note_Click);
            // 
            // noteHalf
            // 
            this.noteHalf.CheckOnClick = true;
            this.noteHalf.Image = global::LAZYSHELL.Properties.Resources.noteHalf;
            this.noteHalf.Name = "noteHalf";
            this.noteHalf.Size = new System.Drawing.Size(23, 22);
            this.noteHalf.ToolTipText = "Half Note";
            this.noteHalf.Click += new System.EventHandler(this.note_Click);
            // 
            // noteQuarterD
            // 
            this.noteQuarterD.CheckOnClick = true;
            this.noteQuarterD.Image = global::LAZYSHELL.Properties.Resources.noteDotted;
            this.noteQuarterD.Name = "noteQuarterD";
            this.noteQuarterD.Size = new System.Drawing.Size(23, 22);
            this.noteQuarterD.ToolTipText = "Dotted Quarter Note";
            this.noteQuarterD.Click += new System.EventHandler(this.note_Click);
            // 
            // noteQuarter
            // 
            this.noteQuarter.CheckOnClick = true;
            this.noteQuarter.Image = global::LAZYSHELL.Properties.Resources.noteQuarter;
            this.noteQuarter.Name = "noteQuarter";
            this.noteQuarter.Size = new System.Drawing.Size(23, 22);
            this.noteQuarter.ToolTipText = "Quarter Note";
            this.noteQuarter.Click += new System.EventHandler(this.note_Click);
            // 
            // noteQuarterT
            // 
            this.noteQuarterT.CheckOnClick = true;
            this.noteQuarterT.Image = global::LAZYSHELL.Properties.Resources.noteQuarterTriplet;
            this.noteQuarterT.Name = "noteQuarterT";
            this.noteQuarterT.Size = new System.Drawing.Size(23, 22);
            this.noteQuarterT.ToolTipText = "Triplet 8th Note (x3 = one half note)";
            this.noteQuarterT.Click += new System.EventHandler(this.note_Click);
            // 
            // note8thD
            // 
            this.note8thD.CheckOnClick = true;
            this.note8thD.Image = global::LAZYSHELL.Properties.Resources.note8thDotted;
            this.note8thD.Name = "note8thD";
            this.note8thD.Size = new System.Drawing.Size(23, 22);
            this.note8thD.ToolTipText = "Dotted 8th Note";
            this.note8thD.Click += new System.EventHandler(this.note_Click);
            // 
            // note8th
            // 
            this.note8th.CheckOnClick = true;
            this.note8th.Image = global::LAZYSHELL.Properties.Resources.note8th;
            this.note8th.Name = "note8th";
            this.note8th.Size = new System.Drawing.Size(23, 22);
            this.note8th.ToolTipText = "8th note";
            this.note8th.Click += new System.EventHandler(this.note_Click);
            // 
            // note8thT
            // 
            this.note8thT.CheckOnClick = true;
            this.note8thT.Image = global::LAZYSHELL.Properties.Resources.note8thTriplet;
            this.note8thT.Name = "note8thT";
            this.note8thT.Size = new System.Drawing.Size(23, 22);
            this.note8thT.ToolTipText = "Triplet 8th Note (x3 = one quarter note)";
            this.note8thT.Click += new System.EventHandler(this.note_Click);
            // 
            // note16th
            // 
            this.note16th.CheckOnClick = true;
            this.note16th.Image = global::LAZYSHELL.Properties.Resources.note16th;
            this.note16th.Name = "note16th";
            this.note16th.Size = new System.Drawing.Size(23, 22);
            this.note16th.ToolTipText = "16th Note";
            this.note16th.Click += new System.EventHandler(this.note_Click);
            // 
            // note16thT
            // 
            this.note16thT.CheckOnClick = true;
            this.note16thT.Image = global::LAZYSHELL.Properties.Resources.note16thTriplet;
            this.note16thT.Name = "note16thT";
            this.note16thT.Size = new System.Drawing.Size(23, 22);
            this.note16thT.ToolTipText = "Triplet 16th Note (x3 = one 8th note)";
            this.note16thT.Click += new System.EventHandler(this.note_Click);
            // 
            // note32nd
            // 
            this.note32nd.CheckOnClick = true;
            this.note32nd.Image = global::LAZYSHELL.Properties.Resources.note32nd;
            this.note32nd.Name = "note32nd";
            this.note32nd.Size = new System.Drawing.Size(23, 22);
            this.note32nd.ToolTipText = "32nd Note";
            this.note32nd.Click += new System.EventHandler(this.note_Click);
            // 
            // note64th
            // 
            this.note64th.CheckOnClick = true;
            this.note64th.Image = global::LAZYSHELL.Properties.Resources.note64th;
            this.note64th.Name = "note64th";
            this.note64th.Size = new System.Drawing.Size(23, 22);
            this.note64th.ToolTipText = "64th Note";
            this.note64th.Click += new System.EventHandler(this.note_Click);
            // 
            // ticksNoteButton
            // 
            this.ticksNoteButton.CheckOnClick = true;
            this.ticksNoteButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ticksNoteButton.Image = ((System.Drawing.Image)(resources.GetObject("ticksNoteButton.Image")));
            this.ticksNoteButton.Name = "ticksNoteButton";
            this.ticksNoteButton.Size = new System.Drawing.Size(34, 22);
            this.ticksNoteButton.Text = "Ticks";
            this.ticksNoteButton.Click += new System.EventHandler(this.note_Click);
            // 
            // ticksNoteValue
            // 
            this.ticksNoteValue.AutoSize = false;
            this.ticksNoteValue.ContextMenuStrip = null;
            this.ticksNoteValue.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ticksNoteValue.Hexadecimal = false;
            this.ticksNoteValue.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ticksNoteValue.Location = new System.Drawing.Point(438, 2);
            this.ticksNoteValue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.ticksNoteValue.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ticksNoteValue.Name = "noteSpacingSW";
            this.ticksNoteValue.Size = new System.Drawing.Size(44, 21);
            this.ticksNoteValue.Text = "0";
            this.ticksNoteValue.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // toolStripSeparator18
            // 
            this.toolStripSeparator18.Name = "toolStripSeparator18";
            this.toolStripSeparator18.Size = new System.Drawing.Size(6, 25);
            // 
            // restWhole
            // 
            this.restWhole.CheckOnClick = true;
            this.restWhole.Image = global::LAZYSHELL.Properties.Resources.restWhole;
            this.restWhole.Name = "restWhole";
            this.restWhole.Size = new System.Drawing.Size(23, 22);
            this.restWhole.ToolTipText = "Whole Rest";
            this.restWhole.Click += new System.EventHandler(this.note_Click);
            // 
            // restHalfD
            // 
            this.restHalfD.CheckOnClick = true;
            this.restHalfD.Image = global::LAZYSHELL.Properties.Resources.restHalfDotted;
            this.restHalfD.Name = "restHalfD";
            this.restHalfD.Size = new System.Drawing.Size(23, 22);
            this.restHalfD.ToolTipText = "Dotted Half Rest";
            this.restHalfD.Click += new System.EventHandler(this.note_Click);
            // 
            // restHalf
            // 
            this.restHalf.CheckOnClick = true;
            this.restHalf.Image = global::LAZYSHELL.Properties.Resources.restHalf;
            this.restHalf.Name = "restHalf";
            this.restHalf.Size = new System.Drawing.Size(23, 22);
            this.restHalf.ToolTipText = "Half Rest";
            this.restHalf.Click += new System.EventHandler(this.note_Click);
            // 
            // restQuarterD
            // 
            this.restQuarterD.CheckOnClick = true;
            this.restQuarterD.Image = global::LAZYSHELL.Properties.Resources.restDotted;
            this.restQuarterD.Name = "restQuarterD";
            this.restQuarterD.Size = new System.Drawing.Size(23, 22);
            this.restQuarterD.ToolTipText = "Dotted Quarter Rest";
            this.restQuarterD.Click += new System.EventHandler(this.note_Click);
            // 
            // restQuarter
            // 
            this.restQuarter.CheckOnClick = true;
            this.restQuarter.Image = global::LAZYSHELL.Properties.Resources.restQuarter;
            this.restQuarter.Name = "restQuarter";
            this.restQuarter.Size = new System.Drawing.Size(23, 22);
            this.restQuarter.ToolTipText = "Quarter Rest";
            this.restQuarter.Click += new System.EventHandler(this.note_Click);
            // 
            // restQuarterT
            // 
            this.restQuarterT.CheckOnClick = true;
            this.restQuarterT.Image = global::LAZYSHELL.Properties.Resources.restQuarterTriplet;
            this.restQuarterT.Name = "restQuarterT";
            this.restQuarterT.Size = new System.Drawing.Size(23, 22);
            this.restQuarterT.ToolTipText = "Triplet Quarter Rest (x3 = one half rest)";
            this.restQuarterT.Click += new System.EventHandler(this.note_Click);
            // 
            // rest8thD
            // 
            this.rest8thD.CheckOnClick = true;
            this.rest8thD.Image = global::LAZYSHELL.Properties.Resources.rest8thDotted;
            this.rest8thD.Name = "rest8thD";
            this.rest8thD.Size = new System.Drawing.Size(23, 22);
            this.rest8thD.ToolTipText = "Dotted 8th Rest";
            this.rest8thD.Click += new System.EventHandler(this.note_Click);
            // 
            // rest8th
            // 
            this.rest8th.CheckOnClick = true;
            this.rest8th.Image = global::LAZYSHELL.Properties.Resources.rest8th;
            this.rest8th.Name = "rest8th";
            this.rest8th.Size = new System.Drawing.Size(23, 22);
            this.rest8th.ToolTipText = "8th Rest";
            this.rest8th.Click += new System.EventHandler(this.note_Click);
            // 
            // rest8thT
            // 
            this.rest8thT.CheckOnClick = true;
            this.rest8thT.Image = global::LAZYSHELL.Properties.Resources.rest8thTriplet;
            this.rest8thT.Name = "rest8thT";
            this.rest8thT.Size = new System.Drawing.Size(23, 22);
            this.rest8thT.ToolTipText = "Triplet 8th Rest (x3 = one quarter rest)";
            this.rest8thT.Click += new System.EventHandler(this.note_Click);
            // 
            // rest16th
            // 
            this.rest16th.CheckOnClick = true;
            this.rest16th.Image = global::LAZYSHELL.Properties.Resources.rest16th;
            this.rest16th.Name = "rest16th";
            this.rest16th.Size = new System.Drawing.Size(23, 22);
            this.rest16th.ToolTipText = "16th Rest";
            this.rest16th.Click += new System.EventHandler(this.note_Click);
            // 
            // rest16thT
            // 
            this.rest16thT.CheckOnClick = true;
            this.rest16thT.Image = global::LAZYSHELL.Properties.Resources.rest16thTriplet;
            this.rest16thT.Name = "rest16thT";
            this.rest16thT.Size = new System.Drawing.Size(23, 22);
            this.rest16thT.ToolTipText = "Triplet 16th Rest (x3 = one 8th rest)";
            this.rest16thT.Click += new System.EventHandler(this.note_Click);
            // 
            // rest32nd
            // 
            this.rest32nd.CheckOnClick = true;
            this.rest32nd.Image = global::LAZYSHELL.Properties.Resources.rest32nd;
            this.rest32nd.Name = "rest32nd";
            this.rest32nd.Size = new System.Drawing.Size(23, 22);
            this.rest32nd.ToolTipText = "32nd Rest";
            this.rest32nd.Click += new System.EventHandler(this.note_Click);
            // 
            // rest64th
            // 
            this.rest64th.CheckOnClick = true;
            this.rest64th.Image = global::LAZYSHELL.Properties.Resources.rest64th;
            this.rest64th.Name = "rest64th";
            this.rest64th.Size = new System.Drawing.Size(23, 22);
            this.rest64th.ToolTipText = "64th Rest";
            this.rest64th.Click += new System.EventHandler(this.note_Click);
            // 
            // ticksRestButton
            // 
            this.ticksRestButton.CheckOnClick = true;
            this.ticksRestButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ticksRestButton.Image = ((System.Drawing.Image)(resources.GetObject("ticksRestButton.Image")));
            this.ticksRestButton.Name = "ticksRestButton";
            this.ticksRestButton.Size = new System.Drawing.Size(34, 22);
            this.ticksRestButton.Text = "Ticks";
            this.ticksRestButton.Click += new System.EventHandler(this.note_Click);
            // 
            // ticksRestValue
            // 
            this.ticksRestValue.AutoSize = false;
            this.ticksRestValue.ContextMenuStrip = null;
            this.ticksRestValue.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ticksRestValue.Hexadecimal = false;
            this.ticksRestValue.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ticksRestValue.Location = new System.Drawing.Point(821, 2);
            this.ticksRestValue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.ticksRestValue.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ticksRestValue.Name = "noteSpacingSW";
            this.ticksRestValue.Size = new System.Drawing.Size(44, 21);
            this.ticksRestValue.Text = "0";
            this.ticksRestValue.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // toolStripMain
            // 
            this.toolStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel10,
            this.clefName,
            this.toolStripLabel2,
            this.keySV,
            this.toolStripLabel7,
            this.timeBeatsSV,
            this.timeValueSV,
            this.toolStripSeparator21,
            this.toolStripLabel6,
            this.staffHeightSV,
            this.toolStripLabel8,
            this.noteSpacingSV,
            this.showRests});
            this.toolStripMain.Location = new System.Drawing.Point(0, 0);
            this.toolStripMain.Name = "toolStripMain";
            this.toolStripMain.Size = new System.Drawing.Size(892, 25);
            this.toolStripMain.TabIndex = 20;
            // 
            // toolStripLabel10
            // 
            this.toolStripLabel10.Name = "toolStripLabel10";
            this.toolStripLabel10.Size = new System.Drawing.Size(29, 22);
            this.toolStripLabel10.Text = " Clef";
            // 
            // clefName
            // 
            this.clefName.AutoSize = false;
            this.clefName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.clefName.Items.AddRange(new object[] {
            "Treble",
            "Bass"});
            this.clefName.Name = "clefName";
            this.clefName.Size = new System.Drawing.Size(70, 21);
            this.clefName.ToolTipText = "Clef";
            this.clefName.SelectedIndexChanged += new System.EventHandler(this.clefSV_SelectedIndexChanged);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(28, 22);
            this.toolStripLabel2.Text = " Key";
            // 
            // keySV
            // 
            this.keySV.AutoSize = false;
            this.keySV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.keySV.Items.AddRange(new object[] {
            "C major",
            "G major",
            "D major",
            "A major",
            "E major",
            "B major",
            "F# major",
            "C# major",
            "F major",
            "Bb major",
            "Eb major",
            "Ab major",
            "Db major",
            "Gb major",
            "Cb major",
            "A minor",
            "E minor",
            "B minor",
            "F# minor",
            "C# minor",
            "G# minor",
            "D# minor",
            "A# minor",
            "D minor",
            "G minor",
            "C minor",
            "F minor",
            "Bb minor",
            "Eb minor",
            "Ab minor"});
            this.keySV.Name = "keySV";
            this.keySV.Size = new System.Drawing.Size(70, 21);
            this.keySV.ToolTipText = "Key";
            this.keySV.SelectedIndexChanged += new System.EventHandler(this.keySV_SelectedIndexChanged);
            // 
            // toolStripLabel7
            // 
            this.toolStripLabel7.Name = "toolStripLabel7";
            this.toolStripLabel7.Size = new System.Drawing.Size(32, 22);
            this.toolStripLabel7.Text = " Time";
            // 
            // timeBeatsSV
            // 
            this.timeBeatsSV.AutoSize = false;
            this.timeBeatsSV.ContextMenuStrip = null;
            this.timeBeatsSV.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeBeatsSV.Hexadecimal = false;
            this.timeBeatsSV.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.timeBeatsSV.Location = new System.Drawing.Point(240, 2);
            this.timeBeatsSV.Maximum = new decimal(new int[] {
            64,
            0,
            0,
            0});
            this.timeBeatsSV.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.timeBeatsSV.Name = "timeBeatsSV";
            this.timeBeatsSV.Size = new System.Drawing.Size(40, 21);
            this.timeBeatsSV.Text = "4";
            this.timeBeatsSV.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // timeValueSV
            // 
            this.timeValueSV.AutoSize = false;
            this.timeValueSV.ContextMenuStrip = null;
            this.timeValueSV.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeValueSV.Hexadecimal = false;
            this.timeValueSV.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.timeValueSV.Location = new System.Drawing.Point(280, 2);
            this.timeValueSV.Maximum = new decimal(new int[] {
            64,
            0,
            0,
            0});
            this.timeValueSV.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.timeValueSV.Name = "timeValueSV";
            this.timeValueSV.Size = new System.Drawing.Size(40, 21);
            this.timeValueSV.Text = "4";
            this.timeValueSV.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.timeValueSV.ValueChanged += new System.EventHandler(this.time_ValueChanged);
            // 
            // toolStripSeparator21
            // 
            this.toolStripSeparator21.Name = "toolStripSeparator21";
            this.toolStripSeparator21.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel6
            // 
            this.toolStripLabel6.Name = "toolStripLabel6";
            this.toolStripLabel6.Size = new System.Drawing.Size(68, 22);
            this.toolStripLabel6.Text = " Staff Height";
            // 
            // staffHeightSV
            // 
            this.staffHeightSV.AutoSize = false;
            this.staffHeightSV.ContextMenuStrip = null;
            this.staffHeightSV.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.staffHeightSV.Hexadecimal = false;
            this.staffHeightSV.Increment = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.staffHeightSV.Location = new System.Drawing.Point(394, 2);
            this.staffHeightSV.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.staffHeightSV.Minimum = new decimal(new int[] {
            64,
            0,
            0,
            0});
            this.staffHeightSV.Name = "staffHeightSV";
            this.staffHeightSV.Size = new System.Drawing.Size(50, 21);
            this.staffHeightSV.Text = "96";
            this.staffHeightSV.Value = new decimal(new int[] {
            96,
            0,
            0,
            0});
            this.staffHeightSV.ValueChanged += new System.EventHandler(this.staffHeightChannel_ValueChanged);
            // 
            // toolStripLabel8
            // 
            this.toolStripLabel8.Name = "toolStripLabel8";
            this.toolStripLabel8.Size = new System.Drawing.Size(87, 22);
            this.toolStripLabel8.Text = " Note Spacing %";
            // 
            // noteSpacingSV
            // 
            this.noteSpacingSV.AutoSize = false;
            this.noteSpacingSV.ContextMenuStrip = null;
            this.noteSpacingSV.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noteSpacingSV.Hexadecimal = false;
            this.noteSpacingSV.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.noteSpacingSV.Location = new System.Drawing.Point(531, 2);
            this.noteSpacingSV.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.noteSpacingSV.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.noteSpacingSV.Name = "noteSpacingSV";
            this.noteSpacingSV.Size = new System.Drawing.Size(50, 21);
            this.noteSpacingSV.Text = "100";
            this.noteSpacingSV.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.noteSpacingSV.ValueChanged += new System.EventHandler(this.noteSpacing_ValueChanged);
            // 
            // showRests
            // 
            this.showRests.BackColor = System.Drawing.Color.Transparent;
            this.showRests.Checked = true;
            this.showRests.Margin = new System.Windows.Forms.Padding(2, 2, 0, 0);
            this.showRests.Name = "showRests";
            this.showRests.Padding = new System.Windows.Forms.Padding(4, 0, 0, 4);
            this.showRests.Size = new System.Drawing.Size(86, 23);
            this.showRests.Text = "Show Rests";
            this.showRests.CheckedChanged += new System.EventHandler(this.showRests_CheckedChanged);
            // 
            // ScoreViewerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 476);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.toolStripAction);
            this.Controls.Add(this.labelNote);
            this.Controls.Add(this.toolStripNote);
            this.Controls.Add(this.toolStripMain);
            this.Name = "ScoreViewerForm";
            this.Text = "Score Viewer";
            this.panel2.ResumeLayout(false);
            this.scoreViewPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picture)).EndInit();
            this.toolStripAction.ResumeLayout(false);
            this.toolStripAction.PerformLayout();
            this.toolStripNote.ResumeLayout(false);
            this.toolStripNote.PerformLayout();
            this.toolStripMain.ResumeLayout(false);
            this.toolStripMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private Controls.NewPanel scoreViewPanel;
        private Controls.NewPictureBox picture;
        private System.Windows.Forms.HScrollBar hScrollBar;
        private System.Windows.Forms.Label labelNote;
        private System.Windows.Forms.ToolStrip toolStripAction;
        private System.Windows.Forms.ToolStripButton draw;
        private System.Windows.Forms.ToolStripButton erase;
        private System.Windows.Forms.ToolStripButton select;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator19;
        private System.Windows.Forms.ToolStripButton cut;
        private System.Windows.Forms.ToolStripButton copy;
        private System.Windows.Forms.ToolStripButton paste;
        private System.Windows.Forms.ToolStripButton delete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator20;
        private System.Windows.Forms.ToolStripButton undo;
        private System.Windows.Forms.ToolStripButton redo;
        private System.Windows.Forms.ToolStrip toolStripNote;
        private System.Windows.Forms.ToolStripButton sharp;
        private System.Windows.Forms.ToolStripButton flat;
        private System.Windows.Forms.ToolStripButton natural;
        private System.Windows.Forms.ToolStripButton tie;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator17;
        private System.Windows.Forms.ToolStripButton noteWhole;
        private System.Windows.Forms.ToolStripButton noteHalfD;
        private System.Windows.Forms.ToolStripButton noteHalf;
        private System.Windows.Forms.ToolStripButton noteQuarterD;
        private System.Windows.Forms.ToolStripButton noteQuarter;
        private System.Windows.Forms.ToolStripButton noteQuarterT;
        private System.Windows.Forms.ToolStripButton note8thD;
        private System.Windows.Forms.ToolStripButton note8th;
        private System.Windows.Forms.ToolStripButton note8thT;
        private System.Windows.Forms.ToolStripButton note16th;
        private System.Windows.Forms.ToolStripButton note16thT;
        private System.Windows.Forms.ToolStripButton note32nd;
        private System.Windows.Forms.ToolStripButton note64th;
        private System.Windows.Forms.ToolStripButton ticksNoteButton;
        private Controls.NewToolStripNumericUpDown ticksNoteValue;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator18;
        private System.Windows.Forms.ToolStripButton restWhole;
        private System.Windows.Forms.ToolStripButton restHalfD;
        private System.Windows.Forms.ToolStripButton restHalf;
        private System.Windows.Forms.ToolStripButton restQuarterD;
        private System.Windows.Forms.ToolStripButton restQuarter;
        private System.Windows.Forms.ToolStripButton restQuarterT;
        private System.Windows.Forms.ToolStripButton rest8thD;
        private System.Windows.Forms.ToolStripButton rest8th;
        private System.Windows.Forms.ToolStripButton rest8thT;
        private System.Windows.Forms.ToolStripButton rest16th;
        private System.Windows.Forms.ToolStripButton rest16thT;
        private System.Windows.Forms.ToolStripButton rest32nd;
        private System.Windows.Forms.ToolStripButton rest64th;
        private System.Windows.Forms.ToolStripButton ticksRestButton;
        private Controls.NewToolStripNumericUpDown ticksRestValue;
        private System.Windows.Forms.ToolStrip toolStripMain;
        private System.Windows.Forms.ToolStripLabel toolStripLabel10;
        private System.Windows.Forms.ToolStripComboBox clefName;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripComboBox keySV;
        private System.Windows.Forms.ToolStripLabel toolStripLabel7;
        private Controls.NewToolStripNumericUpDown timeBeatsSV;
        private Controls.NewToolStripNumericUpDown timeValueSV;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator21;
        private System.Windows.Forms.ToolStripLabel toolStripLabel6;
        private Controls.NewToolStripNumericUpDown staffHeightSV;
        private System.Windows.Forms.ToolStripLabel toolStripLabel8;
        private Controls.NewToolStripNumericUpDown noteSpacingSV;
        private Controls.NewToolStripCheckBox showRests;
    }
}