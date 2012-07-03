namespace LAZYSHELL
{
    partial class Fonts
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
            this.fontWidth = new LAZYSHELL.ToolStripNumericUpDown();
            this.panel30 = new System.Windows.Forms.Panel();
            this.panel25 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBoxFontCharacter = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.colors = new System.Windows.Forms.PictureBox();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.fontEditZoomIn = new System.Windows.Forms.ToolStripButton();
            this.fontEditZoomOut = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator25 = new System.Windows.Forms.ToolStripSeparator();
            this.fontEditDraw = new System.Windows.Forms.ToolStripButton();
            this.fontEditErase = new System.Windows.Forms.ToolStripButton();
            this.fontEditChoose = new System.Windows.Forms.ToolStripButton();
            this.fontEditFill = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator26 = new System.Windows.Forms.ToolStripSeparator();
            this.fontEditDelete = new System.Windows.Forms.ToolStripButton();
            this.fontEditCopy = new System.Windows.Forms.ToolStripButton();
            this.fontEditPaste = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator27 = new System.Windows.Forms.ToolStripSeparator();
            this.fontEditMirror = new System.Windows.Forms.ToolStripButton();
            this.fontEditInvert = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.charKeystroke = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.showGrid = new System.Windows.Forms.ToolStripButton();
            this.showBG = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBoxFontTable = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveImageAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.insertIntoTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.insertIntoBattleDialogueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip7 = new System.Windows.Forms.ToolStrip();
            this.fontType = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.openKeystrokes = new System.Windows.Forms.ToolStripButton();
            this.saveKeystrokes = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.openNewFontTable = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.reset = new System.Windows.Forms.ToolStripButton();
            this.indexLabel = new System.Windows.Forms.Label();
            this.panel30.SuspendLayout();
            this.panel25.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFontCharacter)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.colors)).BeginInit();
            this.toolStrip2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFontTable)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.toolStrip7.SuspendLayout();
            this.SuspendLayout();
            // 
            // fontWidth
            // 
            this.fontWidth.AutoSize = false;
            this.fontWidth.BackColor = System.Drawing.SystemColors.Window;
            this.fontWidth.Hexadecimal = false;
            this.fontWidth.Location = new System.Drawing.Point(40, 3);
            this.fontWidth.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.fontWidth.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.fontWidth.Name = "fontWidth";
            this.fontWidth.Size = new System.Drawing.Size(40, 18);
            this.fontWidth.Text = "0";
            this.fontWidth.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.fontWidth.ValueChanged += new System.EventHandler(this.fontWidth_ValueChanged);
            // 
            // panel30
            // 
            this.panel30.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel30.Controls.Add(this.panel25);
            this.panel30.Controls.Add(this.panel1);
            this.panel30.Controls.Add(this.toolStrip7);
            this.panel30.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel30.Location = new System.Drawing.Point(0, 0);
            this.panel30.Name = "panel30";
            this.panel30.Size = new System.Drawing.Size(416, 315);
            this.panel30.TabIndex = 61;
            // 
            // panel25
            // 
            this.panel25.AutoScroll = true;
            this.panel25.BackColor = System.Drawing.SystemColors.Control;
            this.panel25.Controls.Add(this.panel2);
            this.panel25.Controls.Add(this.panel3);
            this.panel25.Controls.Add(this.toolStrip2);
            this.panel25.Controls.Add(this.toolStrip1);
            this.panel25.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel25.Location = new System.Drawing.Point(132, 25);
            this.panel25.Name = "panel25";
            this.panel25.Size = new System.Drawing.Size(284, 290);
            this.panel25.TabIndex = 523;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.pictureBoxFontCharacter);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(24, 45);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(260, 245);
            this.panel2.TabIndex = 525;
            // 
            // pictureBoxFontCharacter
            // 
            this.pictureBoxFontCharacter.BackgroundImage = global::LAZYSHELL.Properties.Resources._transparent;
            this.pictureBoxFontCharacter.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxFontCharacter.Name = "pictureBoxFontCharacter";
            this.pictureBoxFontCharacter.Size = new System.Drawing.Size(16, 12);
            this.pictureBoxFontCharacter.TabIndex = 447;
            this.pictureBoxFontCharacter.TabStop = false;
            this.pictureBoxFontCharacter.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxFontCharacter_Paint);
            this.pictureBoxFontCharacter.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxFontCharacter_MouseDown);
            this.pictureBoxFontCharacter.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxFontCharacter_MouseMove);
            this.pictureBoxFontCharacter.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBoxFontCharacter_MouseUp);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.colors);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(24, 25);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(260, 20);
            this.panel3.TabIndex = 449;
            // 
            // colors
            // 
            this.colors.BackgroundImage = global::LAZYSHELL.Properties.Resources._transparent;
            this.colors.Location = new System.Drawing.Point(0, 0);
            this.colors.Name = "colors";
            this.colors.Size = new System.Drawing.Size(256, 16);
            this.colors.TabIndex = 448;
            this.colors.TabStop = false;
            this.colors.Paint += new System.Windows.Forms.PaintEventHandler(this.colors_Paint);
            this.colors.MouseDown += new System.Windows.Forms.MouseEventHandler(this.colors_MouseDown);
            // 
            // toolStrip2
            // 
            this.toolStrip2.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fontEditZoomIn,
            this.fontEditZoomOut,
            this.toolStripSeparator25,
            this.fontEditDraw,
            this.fontEditErase,
            this.fontEditChoose,
            this.fontEditFill,
            this.toolStripSeparator26,
            this.fontEditDelete,
            this.fontEditCopy,
            this.fontEditPaste,
            this.toolStripSeparator27,
            this.fontEditMirror,
            this.fontEditInvert});
            this.toolStrip2.Location = new System.Drawing.Point(0, 25);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip2.Size = new System.Drawing.Size(24, 265);
            this.toolStrip2.TabIndex = 0;
            this.toolStrip2.TabStop = true;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // fontEditZoomIn
            // 
            this.fontEditZoomIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.fontEditZoomIn.Image = global::LAZYSHELL.Properties.Resources.zoomin_small;
            this.fontEditZoomIn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.fontEditZoomIn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.fontEditZoomIn.Name = "fontEditZoomIn";
            this.fontEditZoomIn.Size = new System.Drawing.Size(21, 17);
            this.fontEditZoomIn.Text = "Zoom In";
            this.fontEditZoomIn.Click += new System.EventHandler(this.fontEditZoomIn_Click);
            // 
            // fontEditZoomOut
            // 
            this.fontEditZoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.fontEditZoomOut.Image = global::LAZYSHELL.Properties.Resources.zoomout_small;
            this.fontEditZoomOut.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.fontEditZoomOut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.fontEditZoomOut.Name = "fontEditZoomOut";
            this.fontEditZoomOut.Size = new System.Drawing.Size(21, 17);
            this.fontEditZoomOut.Text = "Zoom Out";
            this.fontEditZoomOut.Click += new System.EventHandler(this.fontEditZoomOut_Click);
            // 
            // toolStripSeparator25
            // 
            this.toolStripSeparator25.Name = "toolStripSeparator25";
            this.toolStripSeparator25.Size = new System.Drawing.Size(21, 6);
            // 
            // fontEditDraw
            // 
            this.fontEditDraw.CheckOnClick = true;
            this.fontEditDraw.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.fontEditDraw.Image = global::LAZYSHELL.Properties.Resources.draw_small;
            this.fontEditDraw.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.fontEditDraw.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.fontEditDraw.Name = "fontEditDraw";
            this.fontEditDraw.Size = new System.Drawing.Size(21, 17);
            this.fontEditDraw.Text = "Draw";
            this.fontEditDraw.Click += new System.EventHandler(this.fontEditDraw_Click);
            // 
            // fontEditErase
            // 
            this.fontEditErase.CheckOnClick = true;
            this.fontEditErase.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.fontEditErase.Image = global::LAZYSHELL.Properties.Resources.erase_small;
            this.fontEditErase.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.fontEditErase.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.fontEditErase.Name = "fontEditErase";
            this.fontEditErase.Size = new System.Drawing.Size(21, 17);
            this.fontEditErase.Text = "Erase";
            this.fontEditErase.Click += new System.EventHandler(this.fontEditErase_Click);
            // 
            // fontEditChoose
            // 
            this.fontEditChoose.CheckOnClick = true;
            this.fontEditChoose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.fontEditChoose.Image = global::LAZYSHELL.Properties.Resources.dropper_small;
            this.fontEditChoose.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.fontEditChoose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.fontEditChoose.Name = "fontEditChoose";
            this.fontEditChoose.Size = new System.Drawing.Size(21, 17);
            this.fontEditChoose.Text = "Choose Color";
            this.fontEditChoose.Click += new System.EventHandler(this.fontEditChoose_Click);
            // 
            // fontEditFill
            // 
            this.fontEditFill.CheckOnClick = true;
            this.fontEditFill.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.fontEditFill.Image = global::LAZYSHELL.Properties.Resources.fill_small;
            this.fontEditFill.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.fontEditFill.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.fontEditFill.Name = "fontEditFill";
            this.fontEditFill.Size = new System.Drawing.Size(21, 17);
            this.fontEditFill.Text = "Fill";
            this.fontEditFill.Visible = false;
            this.fontEditFill.Click += new System.EventHandler(this.fontEditFill_Click);
            // 
            // toolStripSeparator26
            // 
            this.toolStripSeparator26.Name = "toolStripSeparator26";
            this.toolStripSeparator26.Size = new System.Drawing.Size(21, 6);
            // 
            // fontEditDelete
            // 
            this.fontEditDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.fontEditDelete.Image = global::LAZYSHELL.Properties.Resources.delete_small;
            this.fontEditDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.fontEditDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.fontEditDelete.Name = "fontEditDelete";
            this.fontEditDelete.Size = new System.Drawing.Size(21, 15);
            this.fontEditDelete.Text = "Clear Character";
            this.fontEditDelete.ToolTipText = "Clear Character";
            this.fontEditDelete.Click += new System.EventHandler(this.fontEditDelete_Click);
            // 
            // fontEditCopy
            // 
            this.fontEditCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.fontEditCopy.Image = global::LAZYSHELL.Properties.Resources.copy_small;
            this.fontEditCopy.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.fontEditCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.fontEditCopy.Name = "fontEditCopy";
            this.fontEditCopy.Size = new System.Drawing.Size(21, 17);
            this.fontEditCopy.Text = "Copy Character";
            this.fontEditCopy.ToolTipText = "Copy Character";
            this.fontEditCopy.Click += new System.EventHandler(this.fontEditCopy_Click);
            // 
            // fontEditPaste
            // 
            this.fontEditPaste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.fontEditPaste.Image = global::LAZYSHELL.Properties.Resources.paste_small;
            this.fontEditPaste.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.fontEditPaste.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.fontEditPaste.Name = "fontEditPaste";
            this.fontEditPaste.Size = new System.Drawing.Size(21, 17);
            this.fontEditPaste.Text = "Paste Character";
            this.fontEditPaste.Click += new System.EventHandler(this.fontEditPaste_Click);
            // 
            // toolStripSeparator27
            // 
            this.toolStripSeparator27.Name = "toolStripSeparator27";
            this.toolStripSeparator27.Size = new System.Drawing.Size(21, 6);
            // 
            // fontEditMirror
            // 
            this.fontEditMirror.AutoSize = false;
            this.fontEditMirror.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.fontEditMirror.Image = global::LAZYSHELL.Properties.Resources.mirror_small;
            this.fontEditMirror.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.fontEditMirror.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.fontEditMirror.Name = "fontEditMirror";
            this.fontEditMirror.Size = new System.Drawing.Size(21, 18);
            this.fontEditMirror.Text = "Mirror Character";
            this.fontEditMirror.Click += new System.EventHandler(this.fontEditMirror_Click);
            // 
            // fontEditInvert
            // 
            this.fontEditInvert.AutoSize = false;
            this.fontEditInvert.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.fontEditInvert.Image = global::LAZYSHELL.Properties.Resources.flip_small;
            this.fontEditInvert.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.fontEditInvert.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.fontEditInvert.Name = "fontEditInvert";
            this.fontEditInvert.Size = new System.Drawing.Size(21, 18);
            this.fontEditInvert.Text = "Invert Character";
            this.fontEditInvert.Click += new System.EventHandler(this.fontEditInvert_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip1.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel3,
            this.fontWidth,
            this.toolStripSeparator2,
            this.toolStripLabel2,
            this.charKeystroke,
            this.toolStripSeparator3,
            this.showGrid,
            this.showBG});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(284, 25);
            this.toolStrip1.TabIndex = 524;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(33, 22);
            this.toolStripLabel3.Text = "Width";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(24, 22);
            this.toolStripLabel2.Text = "Key";
            // 
            // charKeystroke
            // 
            this.charKeystroke.MaxLength = 1;
            this.charKeystroke.Name = "charKeystroke";
            this.charKeystroke.Size = new System.Drawing.Size(25, 25);
            this.charKeystroke.TextChanged += new System.EventHandler(this.charKeystroke_TextChanged);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // showGrid
            // 
            this.showGrid.CheckOnClick = true;
            this.showGrid.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.showGrid.Image = global::LAZYSHELL.Properties.Resources.buttonTogglePixelGrid;
            this.showGrid.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.showGrid.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.showGrid.Name = "showGrid";
            this.showGrid.Size = new System.Drawing.Size(23, 22);
            this.showGrid.Text = "Show/hide grid";
            this.showGrid.Click += new System.EventHandler(this.showGrid_Click);
            // 
            // showBG
            // 
            this.showBG.CheckOnClick = true;
            this.showBG.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.showBG.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.showBG.Name = "showBG";
            this.showBG.Size = new System.Drawing.Size(23, 22);
            this.showBG.Text = "BG";
            this.showBG.Click += new System.EventHandler(this.showBG_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.pictureBoxFontTable);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(132, 290);
            this.panel1.TabIndex = 524;
            // 
            // pictureBoxFontTable
            // 
            this.pictureBoxFontTable.ContextMenuStrip = this.contextMenuStrip1;
            this.pictureBoxFontTable.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxFontTable.Name = "pictureBoxFontTable";
            this.pictureBoxFontTable.Size = new System.Drawing.Size(128, 192);
            this.pictureBoxFontTable.TabIndex = 447;
            this.pictureBoxFontTable.TabStop = false;
            this.pictureBoxFontTable.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxFontTable_Paint);
            this.pictureBoxFontTable.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBoxFontTable_MouseClick);
            this.pictureBoxFontTable.MouseEnter += new System.EventHandler(this.pictureBoxFontTable_MouseEnter);
            this.pictureBoxFontTable.MouseLeave += new System.EventHandler(this.pictureBoxFontTable_MouseLeave);
            this.pictureBoxFontTable.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxFontTable_MouseMove);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importToolStripMenuItem,
            this.exportToolStripMenuItem,
            this.saveImageAsToolStripMenuItem,
            this.toolStripSeparator5,
            this.insertIntoTextToolStripMenuItem,
            this.insertIntoBattleDialogueToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.contextMenuStrip1.ShowImageMargin = false;
            this.contextMenuStrip1.Size = new System.Drawing.Size(174, 142);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.importToolStripMenuItem.Text = "Import...";
            this.importToolStripMenuItem.Click += new System.EventHandler(this.importToolStripMenuItem_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.exportToolStripMenuItem.Text = "Export...";
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
            // 
            // saveImageAsToolStripMenuItem
            // 
            this.saveImageAsToolStripMenuItem.Name = "saveImageAsToolStripMenuItem";
            this.saveImageAsToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.saveImageAsToolStripMenuItem.Text = "Save Image As...";
            this.saveImageAsToolStripMenuItem.Click += new System.EventHandler(this.saveImageAsToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(170, 6);
            // 
            // insertIntoTextToolStripMenuItem
            // 
            this.insertIntoTextToolStripMenuItem.Name = "insertIntoTextToolStripMenuItem";
            this.insertIntoTextToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.insertIntoTextToolStripMenuItem.Text = "Insert into dialogue";
            this.insertIntoTextToolStripMenuItem.Click += new System.EventHandler(this.insertIntoTextToolStripMenuItem_Click);
            // 
            // insertIntoBattleDialogueToolStripMenuItem
            // 
            this.insertIntoBattleDialogueToolStripMenuItem.Name = "insertIntoBattleDialogueToolStripMenuItem";
            this.insertIntoBattleDialogueToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.insertIntoBattleDialogueToolStripMenuItem.Text = "Insert into battle dialogue";
            this.insertIntoBattleDialogueToolStripMenuItem.Click += new System.EventHandler(this.insertIntoBattleDialogueToolStripMenuItem_Click);
            // 
            // toolStrip7
            // 
            this.toolStrip7.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip7.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip7.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fontType,
            this.toolStripSeparator1,
            this.openKeystrokes,
            this.saveKeystrokes,
            this.toolStripSeparator4,
            this.openNewFontTable,
            this.toolStripSeparator6,
            this.reset});
            this.toolStrip7.Location = new System.Drawing.Point(0, 0);
            this.toolStrip7.Name = "toolStrip7";
            this.toolStrip7.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip7.Size = new System.Drawing.Size(416, 25);
            this.toolStrip7.TabIndex = 51;
            this.toolStrip7.TabStop = true;
            this.toolStrip7.Text = "toolStrip1";
            // 
            // fontType
            // 
            this.fontType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fontType.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.fontType.Items.AddRange(new object[] {
            "Menu",
            "Dialogue",
            "Descriptions",
            "Triangles"});
            this.fontType.Name = "fontType";
            this.fontType.Size = new System.Drawing.Size(126, 25);
            this.fontType.SelectedIndexChanged += new System.EventHandler(this.fontType_SelectedIndexChanged);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // openKeystrokes
            // 
            this.openKeystrokes.Image = global::LAZYSHELL.Properties.Resources.keys_load;
            this.openKeystrokes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.openKeystrokes.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openKeystrokes.Name = "openKeystrokes";
            this.openKeystrokes.Size = new System.Drawing.Size(23, 22);
            this.openKeystrokes.ToolTipText = "Load Keystroke Table";
            this.openKeystrokes.Click += new System.EventHandler(this.openKeystrokes_Click);
            // 
            // saveKeystrokes
            // 
            this.saveKeystrokes.Image = global::LAZYSHELL.Properties.Resources.keys_save;
            this.saveKeystrokes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.saveKeystrokes.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveKeystrokes.Name = "saveKeystrokes";
            this.saveKeystrokes.Size = new System.Drawing.Size(23, 22);
            this.saveKeystrokes.ToolTipText = "Save Keystroke Table";
            this.saveKeystrokes.Click += new System.EventHandler(this.saveKeystrokes_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // openNewFontTable
            // 
            this.openNewFontTable.Image = global::LAZYSHELL.Properties.Resources.openNewFontTable;
            this.openNewFontTable.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.openNewFontTable.Name = "openNewFontTable";
            this.openNewFontTable.Size = new System.Drawing.Size(23, 22);
            this.openNewFontTable.ToolTipText = "New Font Table";
            this.openNewFontTable.Click += new System.EventHandler(this.openNewFontTable_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // reset
            // 
            this.reset.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.reset.Image = global::LAZYSHELL.Properties.Resources.reset;
            this.reset.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.reset.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.reset.Name = "reset";
            this.reset.Size = new System.Drawing.Size(23, 22);
            this.reset.Text = "Reset";
            this.reset.Click += new System.EventHandler(this.reset_Click);
            // 
            // indexLabel
            // 
            this.indexLabel.BackColor = System.Drawing.SystemColors.Info;
            this.indexLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.indexLabel.Location = new System.Drawing.Point(0, 0);
            this.indexLabel.Name = "indexLabel";
            this.indexLabel.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.indexLabel.Size = new System.Drawing.Size(100, 18);
            this.indexLabel.TabIndex = 527;
            this.indexLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.indexLabel.Visible = false;
            // 
            // Fonts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 315);
            this.ControlBox = false;
            this.Controls.Add(this.indexLabel);
            this.Controls.Add(this.panel30);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Fonts";
            this.panel30.ResumeLayout(false);
            this.panel30.PerformLayout();
            this.panel25.ResumeLayout(false);
            this.panel25.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFontCharacter)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.colors)).EndInit();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFontTable)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.toolStrip7.ResumeLayout(false);
            this.toolStrip7.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel30;
        private System.Windows.Forms.PictureBox pictureBoxFontTable;
        private System.Windows.Forms.Panel panel25;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBoxFontCharacter;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton fontEditZoomIn;
        private System.Windows.Forms.ToolStripButton fontEditZoomOut;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator25;
        private System.Windows.Forms.ToolStripButton fontEditDraw;
        private System.Windows.Forms.ToolStripButton fontEditErase;
        private System.Windows.Forms.ToolStripButton fontEditChoose;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator26;
        private System.Windows.Forms.ToolStripButton fontEditDelete;
        private System.Windows.Forms.ToolStripButton fontEditCopy;
        private System.Windows.Forms.ToolStripButton fontEditPaste;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator27;
        private System.Windows.Forms.ToolStripButton fontEditMirror;
        private System.Windows.Forms.ToolStripButton fontEditInvert;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripTextBox charKeystroke;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton showGrid;
        private System.Windows.Forms.ToolStrip toolStrip7;
        private System.Windows.Forms.ToolStripComboBox fontType;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton openKeystrokes;
        private System.Windows.Forms.ToolStripButton saveKeystrokes;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox colors;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ToolStripButton showBG;
        private ToolStripNumericUpDown fontWidth;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton openNewFontTable;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem insertIntoTextToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveImageAsToolStripMenuItem;
        private System.Windows.Forms.Label indexLabel;
        private System.Windows.Forms.ToolStripButton fontEditFill;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton reset;
        private System.Windows.Forms.ToolStripMenuItem insertIntoBattleDialogueToolStripMenuItem;
    }
}