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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GraphicEditor));
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBoxColor = new System.Windows.Forms.PictureBox();
            this.panelImageGraphics = new System.Windows.Forms.Panel();
            this.contiguous = new System.Windows.Forms.CheckBox();
            this.panel109 = new System.Windows.Forms.Panel();
            this.pictureBoxGraphicSet = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator36 = new System.Windows.Forms.ToolStripSeparator();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.applyBorderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sizeLabel = new System.Windows.Forms.Label();
            this.coordsLabel = new System.Windows.Forms.Label();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.graphicShowGrid = new System.Windows.Forms.ToolStripButton();
            this.graphicShowPixelGrid = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator33 = new System.Windows.Forms.ToolStripSeparator();
            this.subtileDraw = new System.Windows.Forms.ToolStripButton();
            this.subtileErase = new System.Windows.Forms.ToolStripButton();
            this.subtileDropper = new System.Windows.Forms.ToolStripButton();
            this.subtileFill = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator34 = new System.Windows.Forms.ToolStripSeparator();
            this.graphicZoomIn = new System.Windows.Forms.ToolStripButton();
            this.graphicZoomOut = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.widthDecrease = new System.Windows.Forms.ToolStripButton();
            this.widthIncrease = new System.Windows.Forms.ToolStripButton();
            this.heightDecrease = new System.Windows.Forms.ToolStripButton();
            this.heightIncrease = new System.Windows.Forms.ToolStripButton();
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
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxColor)).BeginInit();
            this.panelImageGraphics.SuspendLayout();
            this.panel109.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGraphicSet)).BeginInit();
            this.contextMenuStrip.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.panel110.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPalette)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxColorBack)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.pictureBoxColor);
            this.panel3.Location = new System.Drawing.Point(150, 12);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(52, 52);
            this.panel3.TabIndex = 500;
            // 
            // pictureBoxColor
            // 
            this.pictureBoxColor.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxColor.Name = "pictureBoxColor";
            this.pictureBoxColor.Size = new System.Drawing.Size(48, 48);
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
            this.panelImageGraphics.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelImageGraphics.Controls.Add(this.contiguous);
            this.panelImageGraphics.Controls.Add(this.panel109);
            this.panelImageGraphics.Controls.Add(this.sizeLabel);
            this.panelImageGraphics.Controls.Add(this.coordsLabel);
            this.panelImageGraphics.Controls.Add(this.toolStrip2);
            this.panelImageGraphics.Location = new System.Drawing.Point(12, 86);
            this.panelImageGraphics.Name = "panelImageGraphics";
            this.panelImageGraphics.Size = new System.Drawing.Size(418, 467);
            this.panelImageGraphics.TabIndex = 498;
            this.panelImageGraphics.Scroll += new System.Windows.Forms.ScrollEventHandler(this.panel109_Scroll);
            // 
            // contiguous
            // 
            this.contiguous.BackColor = System.Drawing.SystemColors.Control;
            this.contiguous.Checked = true;
            this.contiguous.CheckState = System.Windows.Forms.CheckState.Checked;
            this.contiguous.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contiguous.Location = new System.Drawing.Point(3, 25);
            this.contiguous.Name = "contiguous";
            this.contiguous.Size = new System.Drawing.Size(80, 17);
            this.contiguous.TabIndex = 499;
            this.contiguous.Text = "Contiguous";
            this.contiguous.UseVisualStyleBackColor = false;
            this.contiguous.Visible = false;
            // 
            // panel109
            // 
            this.panel109.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel109.AutoScroll = true;
            this.panel109.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel109.Controls.Add(this.pictureBoxGraphicSet);
            this.panel109.Location = new System.Drawing.Point(0, 43);
            this.panel109.Name = "panel109";
            this.panel109.Size = new System.Drawing.Size(414, 402);
            this.panel109.TabIndex = 498;
            this.panel109.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.panel109_PreviewKeyDown);
            this.panel109.Scroll += new System.Windows.Forms.ScrollEventHandler(this.panel109_Scroll);
            this.panel109.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel109_MouseDown);
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
            this.pictureBoxGraphicSet.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxGraphicSet_MouseMove);
            this.pictureBoxGraphicSet.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pictureBoxGraphicSet_MouseDoubleClick);
            this.pictureBoxGraphicSet.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxGraphicSet_MouseDown);
            this.pictureBoxGraphicSet.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxGraphicSet_Paint);
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
            this.contextMenuStrip.ShowImageMargin = false;
            this.contextMenuStrip.Size = new System.Drawing.Size(117, 120);
            this.contextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip_Opening);
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.importToolStripMenuItem.Text = "Import...";
            this.importToolStripMenuItem.Click += new System.EventHandler(this.importToolStripMenuItem_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.exportToolStripMenuItem.Text = "Export...";
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
            // 
            // saveImageToolStripMenuItem
            // 
            this.saveImageToolStripMenuItem.Name = "saveImageToolStripMenuItem";
            this.saveImageToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.saveImageToolStripMenuItem.Text = "Save image...";
            this.saveImageToolStripMenuItem.Click += new System.EventHandler(this.saveImageToolStripMenuItem_Click);
            // 
            // toolStripSeparator36
            // 
            this.toolStripSeparator36.Name = "toolStripSeparator36";
            this.toolStripSeparator36.Size = new System.Drawing.Size(113, 6);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.clearToolStripMenuItem.Text = "Clear";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // applyBorderToolStripMenuItem
            // 
            this.applyBorderToolStripMenuItem.Enabled = false;
            this.applyBorderToolStripMenuItem.Name = "applyBorderToolStripMenuItem";
            this.applyBorderToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.applyBorderToolStripMenuItem.Text = "Apply border";
            // 
            // sizeLabel
            // 
            this.sizeLabel.BackColor = System.Drawing.SystemColors.Control;
            this.sizeLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.sizeLabel.Location = new System.Drawing.Point(0, 446);
            this.sizeLabel.Name = "sizeLabel";
            this.sizeLabel.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.sizeLabel.Size = new System.Drawing.Size(414, 17);
            this.sizeLabel.TabIndex = 497;
            this.sizeLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // coordsLabel
            // 
            this.coordsLabel.BackColor = System.Drawing.SystemColors.Control;
            this.coordsLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.coordsLabel.Location = new System.Drawing.Point(0, 25);
            this.coordsLabel.Name = "coordsLabel";
            this.coordsLabel.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.coordsLabel.Size = new System.Drawing.Size(414, 17);
            this.coordsLabel.TabIndex = 497;
            this.coordsLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // toolStrip2
            // 
            this.toolStrip2.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip2.CanOverflow = false;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.graphicShowGrid,
            this.graphicShowPixelGrid,
            this.toolStripSeparator33,
            this.subtileDraw,
            this.subtileErase,
            this.subtileDropper,
            this.subtileFill,
            this.toolStripSeparator34,
            this.graphicZoomIn,
            this.graphicZoomOut,
            this.toolStripSeparator1,
            this.widthDecrease,
            this.widthIncrease,
            this.heightDecrease,
            this.heightIncrease});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Padding = new System.Windows.Forms.Padding(0);
            this.toolStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip2.Size = new System.Drawing.Size(414, 25);
            this.toolStrip2.TabIndex = 51;
            this.toolStrip2.TabStop = true;
            this.toolStrip2.Text = "toolStrip2";
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
            this.graphicShowGrid.Text = "Grid";
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
            this.graphicShowPixelGrid.Click += new System.EventHandler(this.graphicShowPixelGrid_Click);
            // 
            // toolStripSeparator33
            // 
            this.toolStripSeparator33.Margin = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStripSeparator33.Name = "toolStripSeparator33";
            this.toolStripSeparator33.Size = new System.Drawing.Size(6, 25);
            // 
            // subtileDraw
            // 
            this.subtileDraw.CheckOnClick = true;
            this.subtileDraw.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.subtileDraw.Image = global::LAZYSHELL.Properties.Resources.draw_small;
            this.subtileDraw.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.subtileDraw.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.subtileDraw.Name = "subtileDraw";
            this.subtileDraw.Size = new System.Drawing.Size(23, 22);
            this.subtileDraw.Text = "Draw";
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
            this.subtileErase.Size = new System.Drawing.Size(23, 22);
            this.subtileErase.Text = "Erase";
            this.subtileErase.Click += new System.EventHandler(this.subtileErase_Click);
            // 
            // subtileDropper
            // 
            this.subtileDropper.CheckOnClick = true;
            this.subtileDropper.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.subtileDropper.Image = global::LAZYSHELL.Properties.Resources.dropper_small;
            this.subtileDropper.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.subtileDropper.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.subtileDropper.Name = "subtileDropper";
            this.subtileDropper.Size = new System.Drawing.Size(23, 22);
            this.subtileDropper.Text = "Choose Color";
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
            this.subtileFill.Size = new System.Drawing.Size(23, 22);
            this.subtileFill.Text = "Fill";
            this.subtileFill.Click += new System.EventHandler(this.subtileFill_Click);
            // 
            // toolStripSeparator34
            // 
            this.toolStripSeparator34.Margin = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStripSeparator34.Name = "toolStripSeparator34";
            this.toolStripSeparator34.Size = new System.Drawing.Size(6, 25);
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
            this.graphicZoomIn.Text = "Zoom In";
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
            this.graphicZoomOut.Text = "Zoom Out";
            this.graphicZoomOut.Click += new System.EventHandler(this.graphicZoomOut_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
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
            // panel110
            // 
            this.panel110.BackColor = System.Drawing.SystemColors.ControlText;
            this.panel110.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel110.Controls.Add(this.pictureBoxPalette);
            this.panel110.Location = new System.Drawing.Point(12, 12);
            this.panel110.Name = "panel110";
            this.panel110.Size = new System.Drawing.Size(132, 68);
            this.panel110.TabIndex = 497;
            // 
            // pictureBoxPalette
            // 
            this.pictureBoxPalette.BackgroundImage = global::LAZYSHELL.Properties.Resources._transparent;
            this.pictureBoxPalette.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxPalette.Name = "pictureBoxPalette";
            this.pictureBoxPalette.Size = new System.Drawing.Size(128, 64);
            this.pictureBoxPalette.TabIndex = 450;
            this.pictureBoxPalette.TabStop = false;
            this.pictureBoxPalette.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxPalette_MouseDown);
            this.pictureBoxPalette.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxPalette_Paint);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.pictureBoxColorBack);
            this.panel1.Location = new System.Drawing.Point(184, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(52, 52);
            this.panel1.TabIndex = 500;
            // 
            // pictureBoxColorBack
            // 
            this.pictureBoxColorBack.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxColorBack.Name = "pictureBoxColorBack";
            this.pictureBoxColorBack.Size = new System.Drawing.Size(48, 48);
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
            this.buttonReset.TabIndex = 503;
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
            this.buttonOK.TabIndex = 501;
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
            this.buttonCancel.TabIndex = 502;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonUpdate.Location = new System.Drawing.Point(12, 559);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(75, 23);
            this.buttonUpdate.TabIndex = 536;
            this.buttonUpdate.Text = "Update";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // autoUpdate
            // 
            this.autoUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.autoUpdate.AutoSize = true;
            this.autoUpdate.BackColor = System.Drawing.SystemColors.Control;
            this.autoUpdate.Checked = true;
            this.autoUpdate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.autoUpdate.Location = new System.Drawing.Point(93, 565);
            this.autoUpdate.Name = "autoUpdate";
            this.autoUpdate.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.autoUpdate.Size = new System.Drawing.Size(91, 17);
            this.autoUpdate.TabIndex = 535;
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
            this.alwaysOnTop.TabIndex = 537;
            this.alwaysOnTop.Text = "Always on top";
            this.alwaysOnTop.UseVisualStyleBackColor = true;
            this.alwaysOnTop.CheckedChanged += new System.EventHandler(this.alwaysOnTop_CheckedChanged);
            // 
            // GraphicEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 594);
            this.Controls.Add(this.alwaysOnTop);
            this.Controls.Add(this.buttonUpdate);
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
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "GraphicEditor";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "GRAPHICS EDITOR - Lazy Shell";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GraphicEditor_FormClosing);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxColor)).EndInit();
            this.panelImageGraphics.ResumeLayout(false);
            this.panelImageGraphics.PerformLayout();
            this.panel109.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGraphicSet)).EndInit();
            this.contextMenuStrip.ResumeLayout(false);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.panel110.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPalette)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxColorBack)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBoxColor;
        private System.Windows.Forms.Panel panelImageGraphics;
        private System.Windows.Forms.Panel panel109;
        private System.Windows.Forms.PictureBox pictureBoxGraphicSet;
        private System.Windows.Forms.Label sizeLabel;
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
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator33;
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
        private System.Windows.Forms.CheckBox contiguous;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.CheckBox autoUpdate;
        private System.Windows.Forms.CheckBox alwaysOnTop;

    }
}