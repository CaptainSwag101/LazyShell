﻿namespace LAZYSHELL
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
            this.panel1 = new System.Windows.Forms.Panel();
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
            this.panel4 = new System.Windows.Forms.Panel();
            this.pictureBoxFontTable = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveImageAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.insertIntoTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.insertIntoBattleDialogueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fontTable = new LAZYSHELL.NewPanel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toggleKeystrokes = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.indexLabel = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.reset = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.showGrid = new System.Windows.Forms.ToolStripButton();
            this.showBG = new System.Windows.Forms.ToolStripButton();
            this.toolStrip7 = new System.Windows.Forms.ToolStrip();
            this.fontType = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.openNewFontTable = new System.Windows.Forms.ToolStripButton();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.numeralGraphicsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.battleMenuGraphicsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.numeralPalettesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.battleMenuPalettesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel30.SuspendLayout();
            this.panel25.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFontCharacter)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.colors)).BeginInit();
            this.toolStrip2.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFontTable)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.toolStrip7.SuspendLayout();
            this.SuspendLayout();
            // 
            // fontWidth
            // 
            this.fontWidth.AutoSize = false;
            this.fontWidth.BackColor = System.Drawing.SystemColors.Window;
            this.fontWidth.ContextMenuStrip = null;
            this.fontWidth.Hexadecimal = false;
            this.fontWidth.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.fontWidth.Location = new System.Drawing.Point(200, 3);
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
            this.fontWidth.Size = new System.Drawing.Size(40, 21);
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
            this.panel30.Controls.Add(this.panel4);
            this.panel30.Controls.Add(this.toolStrip1);
            this.panel30.Controls.Add(this.toolStrip7);
            this.panel30.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel30.Location = new System.Drawing.Point(0, 0);
            this.panel30.Name = "panel30";
            this.panel30.Size = new System.Drawing.Size(416, 315);
            this.panel30.TabIndex = 0;
            // 
            // panel25
            // 
            this.panel25.AutoScroll = true;
            this.panel25.BackColor = System.Drawing.SystemColors.Control;
            this.panel25.Controls.Add(this.panel2);
            this.panel25.Controls.Add(this.panel1);
            this.panel25.Controls.Add(this.toolStrip2);
            this.panel25.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel25.Location = new System.Drawing.Point(132, 50);
            this.panel25.Name = "panel25";
            this.panel25.Size = new System.Drawing.Size(284, 265);
            this.panel25.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.pictureBoxFontCharacter);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(24, 20);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(260, 245);
            this.panel2.TabIndex = 3;
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
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.colors);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(24, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(260, 20);
            this.panel1.TabIndex = 448;
            // 
            // colors
            // 
            this.colors.BackgroundImage = global::LAZYSHELL.Properties.Resources._transparent;
            this.colors.Location = new System.Drawing.Point(0, 0);
            this.colors.Name = "colors";
            this.colors.Size = new System.Drawing.Size(64, 16);
            this.colors.TabIndex = 0;
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
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip2.Size = new System.Drawing.Size(24, 265);
            this.toolStrip2.TabIndex = 2;
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
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.pictureBoxFontTable);
            this.panel4.Controls.Add(this.fontTable);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(0, 50);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(132, 265);
            this.panel4.TabIndex = 448;
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
            this.pictureBoxFontTable.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxFontTable_MouseDown);
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
            this.contextMenuStrip1.Size = new System.Drawing.Size(199, 120);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.Image = global::LAZYSHELL.Properties.Resources.importImage;
            this.importToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.importToolStripMenuItem.Text = "Import...";
            this.importToolStripMenuItem.Click += new System.EventHandler(this.importToolStripMenuItem_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Image = global::LAZYSHELL.Properties.Resources.exportBinary;
            this.exportToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.exportToolStripMenuItem.Text = "Export...";
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
            // 
            // saveImageAsToolStripMenuItem
            // 
            this.saveImageAsToolStripMenuItem.Image = global::LAZYSHELL.Properties.Resources.exportImage;
            this.saveImageAsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.saveImageAsToolStripMenuItem.Name = "saveImageAsToolStripMenuItem";
            this.saveImageAsToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.saveImageAsToolStripMenuItem.Text = "Save Image As...";
            this.saveImageAsToolStripMenuItem.Click += new System.EventHandler(this.saveImageAsToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(195, 6);
            // 
            // insertIntoTextToolStripMenuItem
            // 
            this.insertIntoTextToolStripMenuItem.Image = global::LAZYSHELL.Properties.Resources.notepad;
            this.insertIntoTextToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.insertIntoTextToolStripMenuItem.Name = "insertIntoTextToolStripMenuItem";
            this.insertIntoTextToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.insertIntoTextToolStripMenuItem.Text = "Insert into dialogue";
            this.insertIntoTextToolStripMenuItem.Click += new System.EventHandler(this.insertIntoTextToolStripMenuItem_Click);
            // 
            // insertIntoBattleDialogueToolStripMenuItem
            // 
            this.insertIntoBattleDialogueToolStripMenuItem.Image = global::LAZYSHELL.Properties.Resources.notepad;
            this.insertIntoBattleDialogueToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.insertIntoBattleDialogueToolStripMenuItem.Name = "insertIntoBattleDialogueToolStripMenuItem";
            this.insertIntoBattleDialogueToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.insertIntoBattleDialogueToolStripMenuItem.Text = "Insert into battle dialogue";
            this.insertIntoBattleDialogueToolStripMenuItem.Click += new System.EventHandler(this.insertIntoBattleDialogueToolStripMenuItem_Click);
            // 
            // fontTable
            // 
            this.fontTable.Location = new System.Drawing.Point(0, 0);
            this.fontTable.Name = "fontTable";
            this.fontTable.Size = new System.Drawing.Size(128, 192);
            this.fontTable.TabIndex = 448;
            this.fontTable.Visible = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip1.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toggleKeystrokes,
            this.toolStripSeparator1,
            this.indexLabel,
            this.toolStripSeparator2,
            this.reset,
            this.toolStripSeparator6,
            this.toolStripLabel3,
            this.fontWidth,
            this.showGrid,
            this.showBG});
            this.toolStrip1.Location = new System.Drawing.Point(0, 25);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(416, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toggleKeystrokes
            // 
            this.toggleKeystrokes.CheckOnClick = true;
            this.toggleKeystrokes.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toggleKeystrokes.Image = global::LAZYSHELL.Properties.Resources.keystrokes;
            this.toggleKeystrokes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toggleKeystrokes.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toggleKeystrokes.Name = "toggleKeystrokes";
            this.toggleKeystrokes.Size = new System.Drawing.Size(23, 22);
            this.toggleKeystrokes.ToolTipText = "Show/hide keystrokes";
            this.toggleKeystrokes.CheckedChanged += new System.EventHandler(this.toggleKeystrokes_CheckedChanged);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // indexLabel
            // 
            this.indexLabel.AutoSize = false;
            this.indexLabel.Name = "indexLabel";
            this.indexLabel.Size = new System.Drawing.Size(90, 22);
            this.indexLabel.Text = "[256]";
            this.indexLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
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
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(39, 22);
            this.toolStripLabel3.Text = " Width ";
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
            // toolStrip7
            // 
            this.toolStrip7.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip7.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip7.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fontType,
            this.toolStripSeparator4,
            this.openNewFontTable,
            this.toolStripDropDownButton1});
            this.toolStrip7.Location = new System.Drawing.Point(0, 0);
            this.toolStrip7.Name = "toolStrip7";
            this.toolStrip7.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip7.Size = new System.Drawing.Size(416, 25);
            this.toolStrip7.TabIndex = 0;
            this.toolStrip7.TabStop = true;
            this.toolStrip7.Text = "toolStrip1";
            // 
            // fontType
            // 
            this.fontType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fontType.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.fontType.Items.AddRange(new object[] {
            "Dialogue",
            "Menu",
            "Descriptions",
            "Triangles"});
            this.fontType.Name = "fontType";
            this.fontType.Size = new System.Drawing.Size(126, 25);
            this.fontType.SelectedIndexChanged += new System.EventHandler(this.fontType_SelectedIndexChanged);
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
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.numeralGraphicsToolStripMenuItem,
            this.battleMenuGraphicsToolStripMenuItem,
            this.numeralPalettesToolStripMenuItem,
            this.battleMenuPalettesToolStripMenuItem});
            this.toolStripDropDownButton1.Image = global::LAZYSHELL.Properties.Resources.numerals;
            this.toolStripDropDownButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(29, 22);
            this.toolStripDropDownButton1.Text = "Battle Numerals";
            // 
            // numeralGraphicsToolStripMenuItem
            // 
            this.numeralGraphicsToolStripMenuItem.Image = global::LAZYSHELL.Properties.Resources.openGraphics;
            this.numeralGraphicsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.numeralGraphicsToolStripMenuItem.Name = "numeralGraphicsToolStripMenuItem";
            this.numeralGraphicsToolStripMenuItem.Size = new System.Drawing.Size(178, 24);
            this.numeralGraphicsToolStripMenuItem.Text = "Numeral Graphics";
            this.numeralGraphicsToolStripMenuItem.Click += new System.EventHandler(this.numeralGraphicsToolStripMenuItem_Click);
            // 
            // battleMenuGraphicsToolStripMenuItem
            // 
            this.battleMenuGraphicsToolStripMenuItem.Image = global::LAZYSHELL.Properties.Resources.openGraphics;
            this.battleMenuGraphicsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.battleMenuGraphicsToolStripMenuItem.Name = "battleMenuGraphicsToolStripMenuItem";
            this.battleMenuGraphicsToolStripMenuItem.Size = new System.Drawing.Size(178, 24);
            this.battleMenuGraphicsToolStripMenuItem.Text = "Battle Menu Graphics";
            this.battleMenuGraphicsToolStripMenuItem.Click += new System.EventHandler(this.battleMenuGraphicsToolStripMenuItem_Click);
            // 
            // numeralPalettesToolStripMenuItem
            // 
            this.numeralPalettesToolStripMenuItem.Image = global::LAZYSHELL.Properties.Resources.openPalettes;
            this.numeralPalettesToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.numeralPalettesToolStripMenuItem.Name = "numeralPalettesToolStripMenuItem";
            this.numeralPalettesToolStripMenuItem.Size = new System.Drawing.Size(178, 24);
            this.numeralPalettesToolStripMenuItem.Text = "Numeral Palettes";
            this.numeralPalettesToolStripMenuItem.Click += new System.EventHandler(this.numeralPalettesToolStripMenuItem_Click);
            // 
            // battleMenuPalettesToolStripMenuItem
            // 
            this.battleMenuPalettesToolStripMenuItem.Image = global::LAZYSHELL.Properties.Resources.openPalettes;
            this.battleMenuPalettesToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.battleMenuPalettesToolStripMenuItem.Name = "battleMenuPalettesToolStripMenuItem";
            this.battleMenuPalettesToolStripMenuItem.Size = new System.Drawing.Size(178, 24);
            this.battleMenuPalettesToolStripMenuItem.Text = "Battle Menu Palettes";
            this.battleMenuPalettesToolStripMenuItem.Click += new System.EventHandler(this.battleMenuPalettesToolStripMenuItem_Click);
            // 
            // Fonts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 315);
            this.ControlBox = false;
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
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.colors)).EndInit();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFontTable)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
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
        private System.Windows.Forms.ToolStripButton showGrid;
        private System.Windows.Forms.ToolStrip toolStrip7;
        private System.Windows.Forms.ToolStripComboBox fontType;
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
        private System.Windows.Forms.ToolStripButton fontEditFill;
        private System.Windows.Forms.ToolStripMenuItem insertIntoBattleDialogueToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem numeralGraphicsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem numeralPalettesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem battleMenuGraphicsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem battleMenuPalettesToolStripMenuItem;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ToolStripButton reset;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private NewPanel fontTable;
        private System.Windows.Forms.ToolStripLabel indexLabel;
        private System.Windows.Forms.ToolStripButton toggleKeystrokes;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox colors;
    }
}