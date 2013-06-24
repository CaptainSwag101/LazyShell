namespace LAZYSHELL
{
    partial class GraphicEditor
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBoxColor = new System.Windows.Forms.PictureBox();
            this.panelImageGraphics = new System.Windows.Forms.Panel();
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.subtileDraw = new System.Windows.Forms.ToolStripButton();
            this.subtileErase = new System.Windows.Forms.ToolStripButton();
            this.subtileSelect = new System.Windows.Forms.ToolStripButton();
            this.subtileDropper = new System.Windows.Forms.ToolStripButton();
            this.subtileFill = new System.Windows.Forms.ToolStripButton();
            this.subtileReplaceColor = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator34 = new System.Windows.Forms.ToolStripSeparator();
            this.subtileCut = new System.Windows.Forms.ToolStripButton();
            this.subtileCopy = new System.Windows.Forms.ToolStripButton();
            this.subtilePaste = new System.Windows.Forms.ToolStripButton();
            this.subtileDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.mirror = new System.Windows.Forms.ToolStripButton();
            this.invert = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.undo = new System.Windows.Forms.ToolStripButton();
            this.redo = new System.Windows.Forms.ToolStripButton();
            this.panelGraphicSet = new LAZYSHELL.NewPanel();
            this.pictureBoxGraphicSet = new LAZYSHELL.NewPictureBox();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator36 = new System.Windows.Forms.ToolStripSeparator();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.applyBorderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.helpTips = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.graphicShowGrid = new System.Windows.Forms.ToolStripButton();
            this.graphicShowPixelGrid = new System.Windows.Forms.ToolStripButton();
            this.showBG = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.graphicZoomIn = new System.Windows.Forms.ToolStripButton();
            this.graphicZoomOut = new System.Windows.Forms.ToolStripButton();
            this.toggleZoomBox = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.widthDecrease = new System.Windows.Forms.ToolStripButton();
            this.widthIncrease = new System.Windows.Forms.ToolStripButton();
            this.heightDecrease = new System.Windows.Forms.ToolStripButton();
            this.heightIncrease = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator33 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.brushSize = new LAZYSHELL.ToolStripNumericUpDown();
            this.contiguous = new LAZYSHELL.ToolStripCheckBox();
            this.coordsLabel = new System.Windows.Forms.Label();
            this.panel110 = new System.Windows.Forms.Panel();
            this.pictureBoxPalette = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBoxColorBack = new System.Windows.Forms.PictureBox();
            this.buttonReset = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.autoUpdate = new System.Windows.Forms.CheckBox();
            this.alwaysOnTop = new System.Windows.Forms.CheckBox();
            this.switchColors = new System.Windows.Forms.PictureBox();
            this.sizeLabel = new System.Windows.Forms.Label();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxColor)).BeginInit();
            this.panelImageGraphics.SuspendLayout();
            this.toolStrip3.SuspendLayout();
            this.panelGraphicSet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGraphicSet)).BeginInit();
            this.contextMenuStrip.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.panel110.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPalette)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxColorBack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.switchColors)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.pictureBoxColor);
            this.panel3.Location = new System.Drawing.Point(150, 12);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(44, 44);
            this.panel3.TabIndex = 1;
            // 
            // pictureBoxColor
            // 
            this.pictureBoxColor.BackgroundImage = global::LAZYSHELL.Properties.Resources._transparent;
            this.pictureBoxColor.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxColor.Name = "pictureBoxColor";
            this.pictureBoxColor.Size = new System.Drawing.Size(40, 40);
            this.pictureBoxColor.TabIndex = 499;
            this.pictureBoxColor.TabStop = false;
            this.pictureBoxColor.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxColor_Paint);
            // 
            // panelImageGraphics
            // 
            this.panelImageGraphics.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelImageGraphics.BackColor = System.Drawing.SystemColors.ControlText;
            this.panelImageGraphics.Controls.Add(this.toolStrip3);
            this.panelImageGraphics.Controls.Add(this.panelGraphicSet);
            this.panelImageGraphics.Controls.Add(this.toolStrip2);
            this.panelImageGraphics.Location = new System.Drawing.Point(12, 86);
            this.panelImageGraphics.Name = "panelImageGraphics";
            this.panelImageGraphics.Size = new System.Drawing.Size(418, 446);
            this.panelImageGraphics.TabIndex = 4;
            this.panelImageGraphics.Scroll += new System.Windows.Forms.ScrollEventHandler(this.panelGraphicSet_Scroll);
            // 
            // toolStrip3
            // 
            this.toolStrip3.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip3.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.subtileDraw,
            this.subtileErase,
            this.subtileSelect,
            this.subtileDropper,
            this.subtileFill,
            this.subtileReplaceColor,
            this.toolStripSeparator34,
            this.subtileCut,
            this.subtileCopy,
            this.subtilePaste,
            this.subtileDelete,
            this.toolStripSeparator5,
            this.mirror,
            this.invert,
            this.toolStripSeparator3,
            this.undo,
            this.redo});
            this.toolStrip3.Location = new System.Drawing.Point(0, 25);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip3.Size = new System.Drawing.Size(26, 421);
            this.toolStrip3.TabIndex = 6;
            this.toolStrip3.Text = "toolStrip3";
            // 
            // subtileDraw
            // 
            this.subtileDraw.CheckOnClick = true;
            this.subtileDraw.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.subtileDraw.Image = global::LAZYSHELL.Properties.Resources.draw_small;
            this.subtileDraw.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.subtileDraw.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.subtileDraw.Name = "subtileDraw";
            this.subtileDraw.Size = new System.Drawing.Size(23, 17);
            this.subtileDraw.Text = "Draw (D)";
            this.subtileDraw.Click += new System.EventHandler(this.subtileDraw_Click);
            // 
            // subtileErase
            // 
            this.subtileErase.CheckOnClick = true;
            this.subtileErase.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.subtileErase.Image = global::LAZYSHELL.Properties.Resources.erase_small;
            this.subtileErase.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.subtileErase.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.subtileErase.Name = "subtileErase";
            this.subtileErase.Size = new System.Drawing.Size(23, 17);
            this.subtileErase.Text = "Erase (E)";
            this.subtileErase.Click += new System.EventHandler(this.subtileErase_Click);
            // 
            // subtileSelect
            // 
            this.subtileSelect.CheckOnClick = true;
            this.subtileSelect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.subtileSelect.Image = global::LAZYSHELL.Properties.Resources.select_small;
            this.subtileSelect.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.subtileSelect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.subtileSelect.Name = "subtileSelect";
            this.subtileSelect.Size = new System.Drawing.Size(23, 17);
            this.subtileSelect.Text = "Select (S)";
            this.subtileSelect.Click += new System.EventHandler(this.subtileSelect_Click);
            // 
            // subtileDropper
            // 
            this.subtileDropper.CheckOnClick = true;
            this.subtileDropper.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.subtileDropper.Image = global::LAZYSHELL.Properties.Resources.dropper_small;
            this.subtileDropper.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.subtileDropper.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.subtileDropper.Name = "subtileDropper";
            this.subtileDropper.Size = new System.Drawing.Size(23, 17);
            this.subtileDropper.Text = "Dropper (P)";
            this.subtileDropper.Click += new System.EventHandler(this.subtileDropper_Click);
            // 
            // subtileFill
            // 
            this.subtileFill.CheckOnClick = true;
            this.subtileFill.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.subtileFill.Image = global::LAZYSHELL.Properties.Resources.fill_small;
            this.subtileFill.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.subtileFill.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.subtileFill.Name = "subtileFill";
            this.subtileFill.Size = new System.Drawing.Size(23, 17);
            this.subtileFill.Text = "Fill (F)";
            this.subtileFill.Click += new System.EventHandler(this.subtileFill_Click);
            // 
            // subtileReplaceColor
            // 
            this.subtileReplaceColor.CheckOnClick = true;
            this.subtileReplaceColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.subtileReplaceColor.Image = global::LAZYSHELL.Properties.Resources.colorreplace;
            this.subtileReplaceColor.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.subtileReplaceColor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.subtileReplaceColor.Name = "subtileReplaceColor";
            this.subtileReplaceColor.Size = new System.Drawing.Size(23, 18);
            this.subtileReplaceColor.Text = "Color Replace (R)";
            this.subtileReplaceColor.Click += new System.EventHandler(this.subtileReplaceColor_Click);
            // 
            // toolStripSeparator34
            // 
            this.toolStripSeparator34.Margin = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStripSeparator34.Name = "toolStripSeparator34";
            this.toolStripSeparator34.Size = new System.Drawing.Size(21, 6);
            // 
            // subtileCut
            // 
            this.subtileCut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.subtileCut.Image = global::LAZYSHELL.Properties.Resources.cut_small;
            this.subtileCut.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.subtileCut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.subtileCut.Name = "subtileCut";
            this.subtileCut.Size = new System.Drawing.Size(23, 17);
            this.subtileCut.Text = "Cut (Ctrl+X)";
            this.subtileCut.Click += new System.EventHandler(this.subtileCut_Click);
            // 
            // subtileCopy
            // 
            this.subtileCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.subtileCopy.Image = global::LAZYSHELL.Properties.Resources.copy_small;
            this.subtileCopy.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.subtileCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.subtileCopy.Name = "subtileCopy";
            this.subtileCopy.Size = new System.Drawing.Size(23, 17);
            this.subtileCopy.Text = "Copy (Ctrl+C)";
            this.subtileCopy.Click += new System.EventHandler(this.subtileCopy_Click);
            // 
            // subtilePaste
            // 
            this.subtilePaste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.subtilePaste.Image = global::LAZYSHELL.Properties.Resources.paste_small;
            this.subtilePaste.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.subtilePaste.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.subtilePaste.Name = "subtilePaste";
            this.subtilePaste.Size = new System.Drawing.Size(23, 17);
            this.subtilePaste.Text = "Paste (Ctrl+V)";
            this.subtilePaste.Click += new System.EventHandler(this.subtilePaste_Click);
            // 
            // subtileDelete
            // 
            this.subtileDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.subtileDelete.Image = global::LAZYSHELL.Properties.Resources.delete_small;
            this.subtileDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.subtileDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.subtileDelete.Name = "subtileDelete";
            this.subtileDelete.Size = new System.Drawing.Size(23, 15);
            this.subtileDelete.Text = "Delete (Del)";
            this.subtileDelete.Click += new System.EventHandler(this.subtileDelete_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(23, 6);
            // 
            // mirror
            // 
            this.mirror.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mirror.Image = global::LAZYSHELL.Properties.Resources.mirror_small;
            this.mirror.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mirror.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mirror.Name = "mirror";
            this.mirror.Size = new System.Drawing.Size(23, 15);
            this.mirror.Text = "Mirror Selection";
            this.mirror.Click += new System.EventHandler(this.mirror_Click);
            // 
            // invert
            // 
            this.invert.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.invert.Image = global::LAZYSHELL.Properties.Resources.flip_small;
            this.invert.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.invert.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.invert.Name = "invert";
            this.invert.Size = new System.Drawing.Size(23, 17);
            this.invert.Text = "Invert Selection";
            this.invert.Click += new System.EventHandler(this.invert_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(23, 6);
            // 
            // undo
            // 
            this.undo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.undo.Image = global::LAZYSHELL.Properties.Resources.undo_small;
            this.undo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.undo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.undo.Name = "undo";
            this.undo.Size = new System.Drawing.Size(23, 12);
            this.undo.Text = "Undo (Ctrl+Z)";
            this.undo.Click += new System.EventHandler(this.undo_Click);
            // 
            // redo
            // 
            this.redo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.redo.Image = global::LAZYSHELL.Properties.Resources.redo_small;
            this.redo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.redo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.redo.Name = "redo";
            this.redo.Size = new System.Drawing.Size(23, 12);
            this.redo.Text = "Redo (Ctrl+Y)";
            this.redo.Click += new System.EventHandler(this.redo_Click);
            // 
            // panelGraphicSet
            // 
            this.panelGraphicSet.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelGraphicSet.AutoScroll = true;
            this.panelGraphicSet.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panelGraphicSet.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelGraphicSet.Controls.Add(this.pictureBoxGraphicSet);
            this.panelGraphicSet.Location = new System.Drawing.Point(26, 25);
            this.panelGraphicSet.Name = "panelGraphicSet";
            this.panelGraphicSet.Size = new System.Drawing.Size(392, 421);
            this.panelGraphicSet.TabIndex = 3;
            this.panelGraphicSet.Scroll += new System.Windows.Forms.ScrollEventHandler(this.panelGraphicSet_Scroll);
            this.panelGraphicSet.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelGraphicSet_MouseDown);
            this.panelGraphicSet.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.panelGraphicSet_PreviewKeyDown);
            // 
            // pictureBoxGraphicSet
            // 
            this.pictureBoxGraphicSet.BackgroundImage = global::LAZYSHELL.Properties.Resources._transparent;
            this.pictureBoxGraphicSet.ContextMenuStrip = this.contextMenuStrip;
            this.pictureBoxGraphicSet.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxGraphicSet.Name = "pictureBoxGraphicSet";
            this.pictureBoxGraphicSet.Size = new System.Drawing.Size(256, 768);
            this.pictureBoxGraphicSet.TabIndex = 450;
            this.pictureBoxGraphicSet.TabStop = false;
            this.pictureBoxGraphicSet.Zoom = 2;
            this.pictureBoxGraphicSet.ZoomBoxEnabled = false;
            this.pictureBoxGraphicSet.ZoomBoxPosition = new System.Drawing.Point(32, 32);
            this.pictureBoxGraphicSet.ZoomBoxZoom = 4;
            this.pictureBoxGraphicSet.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxGraphicSet_Paint);
            this.pictureBoxGraphicSet.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxGraphicSet_MouseDown);
            this.pictureBoxGraphicSet.MouseEnter += new System.EventHandler(this.pictureBoxGraphicSet_MouseEnter);
            this.pictureBoxGraphicSet.MouseLeave += new System.EventHandler(this.pictureBoxGraphicSet_MouseLeave);
            this.pictureBoxGraphicSet.MouseHover += new System.EventHandler(this.pictureBoxGraphicSet_MouseHover);
            this.pictureBoxGraphicSet.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxGraphicSet_MouseMove);
            this.pictureBoxGraphicSet.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBoxGraphicSet_MouseUp);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importToolStripMenuItem,
            this.exportToolStripMenuItem,
            this.saveImageToolStripMenuItem,
            this.toolStripSeparator36,
            this.clearToolStripMenuItem,
            this.applyBorderToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip1";
            this.contextMenuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.contextMenuStrip.Size = new System.Drawing.Size(142, 120);
            this.contextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip_Opening);
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.Image = global::LAZYSHELL.Properties.Resources.importImage;
            this.importToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.importToolStripMenuItem.Text = "Import...";
            this.importToolStripMenuItem.Click += new System.EventHandler(this.importToolStripMenuItem_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Image = global::LAZYSHELL.Properties.Resources.exportBinary;
            this.exportToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.exportToolStripMenuItem.Text = "Export...";
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
            // 
            // saveImageToolStripMenuItem
            // 
            this.saveImageToolStripMenuItem.Image = global::LAZYSHELL.Properties.Resources.exportImage;
            this.saveImageToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.saveImageToolStripMenuItem.Name = "saveImageToolStripMenuItem";
            this.saveImageToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.saveImageToolStripMenuItem.Text = "Save image...";
            this.saveImageToolStripMenuItem.Click += new System.EventHandler(this.saveImageToolStripMenuItem_Click);
            // 
            // toolStripSeparator36
            // 
            this.toolStripSeparator36.Name = "toolStripSeparator36";
            this.toolStripSeparator36.Size = new System.Drawing.Size(138, 6);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Image = global::LAZYSHELL.Properties.Resources.clear_small;
            this.clearToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.clearToolStripMenuItem.Text = "Clear";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // applyBorderToolStripMenuItem
            // 
            this.applyBorderToolStripMenuItem.Enabled = false;
            this.applyBorderToolStripMenuItem.Name = "applyBorderToolStripMenuItem";
            this.applyBorderToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.applyBorderToolStripMenuItem.Text = "Apply border";
            // 
            // toolStrip2
            // 
            this.toolStrip2.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip2.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpTips,
            this.toolStripSeparator2,
            this.graphicShowGrid,
            this.graphicShowPixelGrid,
            this.showBG,
            this.toolStripSeparator1,
            this.graphicZoomIn,
            this.graphicZoomOut,
            this.toggleZoomBox,
            this.toolStripSeparator4,
            this.widthDecrease,
            this.widthIncrease,
            this.heightDecrease,
            this.heightIncrease,
            this.toolStripSeparator33,
            this.toolStripLabel1,
            this.brushSize,
            this.contiguous});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Padding = new System.Windows.Forms.Padding(0);
            this.toolStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip2.Size = new System.Drawing.Size(418, 25);
            this.toolStrip2.TabIndex = 0;
            this.toolStrip2.TabStop = true;
            this.toolStrip2.Text = "Replace All";
            // 
            // helpTips
            // 
            this.helpTips.CheckOnClick = true;
            this.helpTips.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.helpTips.Image = global::LAZYSHELL.Properties.Resources.help_small;
            this.helpTips.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.helpTips.Name = "helpTips";
            this.helpTips.Size = new System.Drawing.Size(23, 22);
            this.helpTips.Text = "Help Tips";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // graphicShowGrid
            // 
            this.graphicShowGrid.CheckOnClick = true;
            this.graphicShowGrid.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.graphicShowGrid.Image = global::LAZYSHELL.Properties.Resources.buttonToggleGrid;
            this.graphicShowGrid.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.graphicShowGrid.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.graphicShowGrid.Name = "graphicShowGrid";
            this.graphicShowGrid.Size = new System.Drawing.Size(23, 22);
            this.graphicShowGrid.Text = "Tile Grid";
            this.graphicShowGrid.ToolTipText = "Tile Grid (G)";
            this.graphicShowGrid.Click += new System.EventHandler(this.graphicShowGrid_Click);
            // 
            // graphicShowPixelGrid
            // 
            this.graphicShowPixelGrid.CheckOnClick = true;
            this.graphicShowPixelGrid.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.graphicShowPixelGrid.Image = global::LAZYSHELL.Properties.Resources.buttonTogglePixelGrid;
            this.graphicShowPixelGrid.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.graphicShowPixelGrid.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.graphicShowPixelGrid.Name = "graphicShowPixelGrid";
            this.graphicShowPixelGrid.Size = new System.Drawing.Size(23, 22);
            this.graphicShowPixelGrid.Text = "Pixel Grid";
            this.graphicShowPixelGrid.ToolTipText = "Pixel Grid (T)";
            this.graphicShowPixelGrid.Click += new System.EventHandler(this.graphicShowPixelGrid_Click);
            // 
            // showBG
            // 
            this.showBG.CheckOnClick = true;
            this.showBG.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.showBG.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.showBG.Name = "showBG";
            this.showBG.Size = new System.Drawing.Size(23, 22);
            this.showBG.Text = "BG";
            this.showBG.ToolTipText = "BG Color (B)";
            this.showBG.Click += new System.EventHandler(this.showBG_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // graphicZoomIn
            // 
            this.graphicZoomIn.CheckOnClick = true;
            this.graphicZoomIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.graphicZoomIn.Image = global::LAZYSHELL.Properties.Resources.zoomin_small;
            this.graphicZoomIn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.graphicZoomIn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.graphicZoomIn.Name = "graphicZoomIn";
            this.graphicZoomIn.Size = new System.Drawing.Size(23, 22);
            this.graphicZoomIn.Text = "Zoom In (Ctrl+Up)";
            this.graphicZoomIn.Click += new System.EventHandler(this.graphicZoomIn_Click);
            // 
            // graphicZoomOut
            // 
            this.graphicZoomOut.CheckOnClick = true;
            this.graphicZoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.graphicZoomOut.Image = global::LAZYSHELL.Properties.Resources.zoomout_small;
            this.graphicZoomOut.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.graphicZoomOut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.graphicZoomOut.Name = "graphicZoomOut";
            this.graphicZoomOut.Size = new System.Drawing.Size(23, 22);
            this.graphicZoomOut.Text = "Zoom Out (Ctrl+Down)";
            this.graphicZoomOut.Click += new System.EventHandler(this.graphicZoomOut_Click);
            // 
            // toggleZoomBox
            // 
            this.toggleZoomBox.CheckOnClick = true;
            this.toggleZoomBox.Image = global::LAZYSHELL.Properties.Resources.zoomBox;
            this.toggleZoomBox.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toggleZoomBox.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toggleZoomBox.Name = "toggleZoomBox";
            this.toggleZoomBox.Size = new System.Drawing.Size(23, 22);
            this.toggleZoomBox.ToolTipText = "Zoom Box (Z)";
            this.toggleZoomBox.Click += new System.EventHandler(this.toggleZoomBox_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // widthDecrease
            // 
            this.widthDecrease.AutoSize = false;
            this.widthDecrease.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.widthDecrease.Image = global::LAZYSHELL.Properties.Resources.widthDecrease;
            this.widthDecrease.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.widthDecrease.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.widthDecrease.Name = "widthDecrease";
            this.widthDecrease.Size = new System.Drawing.Size(17, 17);
            this.widthDecrease.ToolTipText = "Decrease Width";
            this.widthDecrease.Click += new System.EventHandler(this.widthDecrease_Click);
            // 
            // widthIncrease
            // 
            this.widthIncrease.AutoSize = false;
            this.widthIncrease.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.widthIncrease.Image = global::LAZYSHELL.Properties.Resources.widthIncrease;
            this.widthIncrease.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.widthIncrease.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.widthIncrease.Name = "widthIncrease";
            this.widthIncrease.Size = new System.Drawing.Size(17, 17);
            this.widthIncrease.ToolTipText = "Increase Width";
            this.widthIncrease.Click += new System.EventHandler(this.widthIncrease_Click);
            // 
            // heightDecrease
            // 
            this.heightDecrease.AutoSize = false;
            this.heightDecrease.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.heightDecrease.Image = global::LAZYSHELL.Properties.Resources.heightDecrease;
            this.heightDecrease.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.heightDecrease.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.heightDecrease.Name = "heightDecrease";
            this.heightDecrease.Size = new System.Drawing.Size(17, 17);
            this.heightDecrease.ToolTipText = "Decrease Height";
            this.heightDecrease.Click += new System.EventHandler(this.heightDecrease_Click);
            // 
            // heightIncrease
            // 
            this.heightIncrease.AutoSize = false;
            this.heightIncrease.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.heightIncrease.Image = global::LAZYSHELL.Properties.Resources.heightIncrease;
            this.heightIncrease.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.heightIncrease.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.heightIncrease.Name = "heightIncrease";
            this.heightIncrease.Size = new System.Drawing.Size(17, 17);
            this.heightIncrease.ToolTipText = "Increase Height";
            this.heightIncrease.Click += new System.EventHandler(this.heightIncrease_Click);
            // 
            // toolStripSeparator33
            // 
            this.toolStripSeparator33.Margin = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStripSeparator33.Name = "toolStripSeparator33";
            this.toolStripSeparator33.Size = new System.Drawing.Size(6, 25);
            this.toolStripSeparator33.Visible = false;
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(31, 22);
            this.toolStripLabel1.Text = " Size ";
            this.toolStripLabel1.Visible = false;
            // 
            // brushSize
            // 
            this.brushSize.AutoSize = false;
            this.brushSize.ContextMenuStrip = null;
            this.brushSize.Hexadecimal = false;
            this.brushSize.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.brushSize.Location = new System.Drawing.Point(293, 3);
            this.brushSize.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.brushSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.brushSize.Name = "spriteNum";
            this.brushSize.Size = new System.Drawing.Size(40, 18);
            this.brushSize.Text = "1";
            this.brushSize.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.brushSize.Visible = false;
            this.brushSize.ValueChanged += new System.EventHandler(this.brushSize_ValueChanged);
            this.brushSize.VisibleChanged += new System.EventHandler(this.brushSize_VisibleChanged);
            // 
            // contiguous
            // 
            this.contiguous.Checked = true;
            this.contiguous.Name = "contiguous";
            this.contiguous.Padding = new System.Windows.Forms.Padding(4, 0, 0, 4);
            this.contiguous.Size = new System.Drawing.Size(84, 21);
            this.contiguous.Text = "Contiguous";
            this.contiguous.ToolTipText = "Fill only adjacent pixels";
            this.contiguous.Visible = false;
            this.contiguous.VisibleChanged += new System.EventHandler(this.contiguous_VisibleChanged);
            // 
            // coordsLabel
            // 
            this.coordsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.coordsLabel.BackColor = System.Drawing.SystemColors.Control;
            this.coordsLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.coordsLabel.Location = new System.Drawing.Point(87, 532);
            this.coordsLabel.Name = "coordsLabel";
            this.coordsLabel.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.coordsLabel.Size = new System.Drawing.Size(343, 21);
            this.coordsLabel.TabIndex = 4;
            this.coordsLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // panel110
            // 
            this.panel110.BackColor = System.Drawing.SystemColors.ControlText;
            this.panel110.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel110.Controls.Add(this.pictureBoxPalette);
            this.panel110.Location = new System.Drawing.Point(12, 12);
            this.panel110.Name = "panel110";
            this.panel110.Size = new System.Drawing.Size(132, 68);
            this.panel110.TabIndex = 0;
            // 
            // pictureBoxPalette
            // 
            this.pictureBoxPalette.BackgroundImage = global::LAZYSHELL.Properties.Resources._transparent;
            this.pictureBoxPalette.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxPalette.Name = "pictureBoxPalette";
            this.pictureBoxPalette.Size = new System.Drawing.Size(128, 64);
            this.pictureBoxPalette.TabIndex = 450;
            this.pictureBoxPalette.TabStop = false;
            this.pictureBoxPalette.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxPalette_Paint);
            this.pictureBoxPalette.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxPalette_MouseDown);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.pictureBoxColorBack);
            this.panel1.Location = new System.Drawing.Point(184, 36);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(44, 44);
            this.panel1.TabIndex = 2;
            // 
            // pictureBoxColorBack
            // 
            this.pictureBoxColorBack.BackgroundImage = global::LAZYSHELL.Properties.Resources._transparent;
            this.pictureBoxColorBack.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxColorBack.Name = "pictureBoxColorBack";
            this.pictureBoxColorBack.Size = new System.Drawing.Size(40, 40);
            this.pictureBoxColorBack.TabIndex = 499;
            this.pictureBoxColorBack.TabStop = false;
            this.pictureBoxColorBack.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxColorBack_Paint);
            // 
            // buttonReset
            // 
            this.buttonReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonReset.FlatAppearance.BorderSize = 0;
            this.buttonReset.Location = new System.Drawing.Point(355, 559);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(75, 23);
            this.buttonReset.TabIndex = 9;
            this.buttonReset.Text = "Reset";
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOK.FlatAppearance.BorderSize = 0;
            this.buttonOK.Location = new System.Drawing.Point(193, 559);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 7;
            this.buttonOK.Text = "OK";
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.FlatAppearance.BorderSize = 0;
            this.buttonCancel.Location = new System.Drawing.Point(274, 559);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 8;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonUpdate.Location = new System.Drawing.Point(12, 559);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(75, 23);
            this.buttonUpdate.TabIndex = 5;
            this.buttonUpdate.Text = "Update";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // autoUpdate
            // 
            this.autoUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.autoUpdate.AutoSize = true;
            this.autoUpdate.Checked = true;
            this.autoUpdate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.autoUpdate.Location = new System.Drawing.Point(93, 565);
            this.autoUpdate.Name = "autoUpdate";
            this.autoUpdate.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.autoUpdate.Size = new System.Drawing.Size(91, 17);
            this.autoUpdate.TabIndex = 6;
            this.autoUpdate.Text = "Auto-update";
            this.autoUpdate.UseVisualStyleBackColor = false;
            // 
            // alwaysOnTop
            // 
            this.alwaysOnTop.AutoSize = true;
            this.alwaysOnTop.Checked = true;
            this.alwaysOnTop.CheckState = System.Windows.Forms.CheckState.Checked;
            this.alwaysOnTop.Location = new System.Drawing.Point(336, 12);
            this.alwaysOnTop.Name = "alwaysOnTop";
            this.alwaysOnTop.Size = new System.Drawing.Size(94, 17);
            this.alwaysOnTop.TabIndex = 3;
            this.alwaysOnTop.Text = "Always on top";
            this.alwaysOnTop.UseVisualStyleBackColor = true;
            this.alwaysOnTop.CheckedChanged += new System.EventHandler(this.alwaysOnTop_CheckedChanged);
            // 
            // switchColors
            // 
            this.switchColors.BackgroundImage = global::LAZYSHELL.Properties.Resources._switch;
            this.switchColors.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.switchColors.Location = new System.Drawing.Point(161, 60);
            this.switchColors.Name = "switchColors";
            this.switchColors.Size = new System.Drawing.Size(16, 16);
            this.switchColors.TabIndex = 10;
            this.switchColors.TabStop = false;
            this.switchColors.MouseDown += new System.Windows.Forms.MouseEventHandler(this.switchColors_MouseDown);
            // 
            // sizeLabel
            // 
            this.sizeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.sizeLabel.BackColor = System.Drawing.SystemColors.Control;
            this.sizeLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.sizeLabel.Location = new System.Drawing.Point(12, 532);
            this.sizeLabel.Name = "sizeLabel";
            this.sizeLabel.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.sizeLabel.Size = new System.Drawing.Size(75, 21);
            this.sizeLabel.TabIndex = 11;
            // 
            // GraphicEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 594);
            this.Controls.Add(this.sizeLabel);
            this.Controls.Add(this.switchColors);
            this.Controls.Add(this.alwaysOnTop);
            this.Controls.Add(this.buttonUpdate);
            this.Controls.Add(this.coordsLabel);
            this.Controls.Add(this.autoUpdate);
            this.Controls.Add(this.panelImageGraphics);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.panel110);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.buttonCancel);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = global::LAZYSHELL.Properties.Resources.LAZYSHELL_icon;
            this.MinimizeBox = false;
            this.Name = "GraphicEditor";
            this.Text = "GRAPHICS EDITOR - Lazy Shell";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GraphicEditor_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GraphicEditor_KeyDown);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxColor)).EndInit();
            this.panelImageGraphics.ResumeLayout(false);
            this.panelImageGraphics.PerformLayout();
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            this.panelGraphicSet.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGraphicSet)).EndInit();
            this.contextMenuStrip.ResumeLayout(false);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.panel110.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPalette)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxColorBack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.switchColors)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBoxColor;
        private System.Windows.Forms.Panel panelImageGraphics;
        private LAZYSHELL.NewPanel panelGraphicSet;
        private LAZYSHELL.NewPictureBox pictureBoxGraphicSet;
        private System.Windows.Forms.Label coordsLabel;
        private System.Windows.Forms.Panel panel110;
        private System.Windows.Forms.PictureBox pictureBoxPalette;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator36;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem applyBorderToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBoxColorBack;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton graphicShowGrid;
        private System.Windows.Forms.ToolStripButton graphicShowPixelGrid;
        private System.Windows.Forms.ToolStripButton subtileDraw;
        private System.Windows.Forms.ToolStripButton subtileErase;
        private System.Windows.Forms.ToolStripButton subtileDropper;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator34;
        private System.Windows.Forms.ToolStripButton graphicZoomIn;
        private System.Windows.Forms.ToolStripButton graphicZoomOut;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton widthDecrease;
        private System.Windows.Forms.ToolStripButton widthIncrease;
        private System.Windows.Forms.ToolStripButton heightDecrease;
        private System.Windows.Forms.ToolStripButton heightIncrease;
        private System.Windows.Forms.ToolStripButton subtileFill;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.CheckBox autoUpdate;
        private System.Windows.Forms.CheckBox alwaysOnTop;
        private System.Windows.Forms.ToolStripButton subtileReplaceColor;
        private System.Windows.Forms.ToolStripButton helpTips;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.PictureBox switchColors;
        private System.Windows.Forms.ToolStripButton undo;
        private System.Windows.Forms.ToolStripButton redo;
        private ToolStripNumericUpDown brushSize;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private ToolStripCheckBox contiguous;
        private System.Windows.Forms.ToolStripButton subtileSelect;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator33;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton subtileCut;
        private System.Windows.Forms.ToolStripButton subtileCopy;
        private System.Windows.Forms.ToolStripButton subtilePaste;
        private System.Windows.Forms.ToolStripButton subtileDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.Label sizeLabel;
        private System.Windows.Forms.ToolStripButton showBG;
        private System.Windows.Forms.ToolStripButton toggleZoomBox;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton mirror;
        private System.Windows.Forms.ToolStripButton invert;
    }
}