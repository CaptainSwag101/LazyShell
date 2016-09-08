
namespace LazyShell
{
    partial class GraphicEditor
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
			this.panelColor = new System.Windows.Forms.Panel();
			this.pictureBoxColor = new System.Windows.Forms.PictureBox();
			this.panelGraphics = new System.Windows.Forms.Panel();
			this.panelGraphicSet = new LazyShell.Controls.NewPanel();
			this.pictureBoxGraphicSet = new LazyShell.Controls.NewPictureBox();
			this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator36 = new System.Windows.Forms.ToolStripSeparator();
			this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.applyBorderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStrip3 = new System.Windows.Forms.ToolStrip();
			this.editDraw = new System.Windows.Forms.ToolStripButton();
			this.editErase = new System.Windows.Forms.ToolStripButton();
			this.editSelect = new System.Windows.Forms.ToolStripButton();
			this.editDropper = new System.Windows.Forms.ToolStripButton();
			this.editFill = new System.Windows.Forms.ToolStripButton();
			this.editReplaceColor = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator34 = new System.Windows.Forms.ToolStripSeparator();
			this.editCut = new System.Windows.Forms.ToolStripButton();
			this.editCopy = new System.Windows.Forms.ToolStripButton();
			this.editPaste = new System.Windows.Forms.ToolStripButton();
			this.editDelete = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
			this.mirror = new System.Windows.Forms.ToolStripButton();
			this.invert = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.undo = new System.Windows.Forms.ToolStripButton();
			this.redo = new System.Windows.Forms.ToolStripButton();
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
			this.labelBrushSize = new System.Windows.Forms.ToolStripLabel();
			this.brushSize = new LazyShell.Controls.NewToolStripNumericUpDown();
			this.contiguous = new LazyShell.Controls.NewToolStripCheckBox();
			this.coordsLabel = new System.Windows.Forms.Label();
			this.panelPaletteSet = new System.Windows.Forms.Panel();
			this.pictureBoxPalette = new System.Windows.Forms.PictureBox();
			this.panelColorBack = new System.Windows.Forms.Panel();
			this.pictureBoxColorBack = new System.Windows.Forms.PictureBox();
			this.buttonReset = new System.Windows.Forms.Button();
			this.buttonOK = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.buttonUpdate = new System.Windows.Forms.Button();
			this.autoUpdate = new System.Windows.Forms.CheckBox();
			this.alwaysOnTop = new System.Windows.Forms.CheckBox();
			this.switchColors = new System.Windows.Forms.PictureBox();
			this.sizeLabel = new System.Windows.Forms.Label();
			this.panelPalettes = new System.Windows.Forms.Panel();
			this.panelButtons = new System.Windows.Forms.Panel();
			this.panelLabels = new System.Windows.Forms.Panel();
			this.panelColor.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxColor)).BeginInit();
			this.panelGraphics.SuspendLayout();
			this.panelGraphicSet.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxGraphicSet)).BeginInit();
			this.contextMenuStrip.SuspendLayout();
			this.toolStrip3.SuspendLayout();
			this.toolStrip2.SuspendLayout();
			this.panelPaletteSet.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxPalette)).BeginInit();
			this.panelColorBack.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxColorBack)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.switchColors)).BeginInit();
			this.panelPalettes.SuspendLayout();
			this.panelButtons.SuspendLayout();
			this.panelLabels.SuspendLayout();
			this.SuspendLayout();
			// 
			// panelColor
			// 
			this.panelColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panelColor.Controls.Add(this.pictureBoxColor);
			this.panelColor.Location = new System.Drawing.Point(202, 0);
			this.panelColor.Name = "panelColor";
			this.panelColor.Size = new System.Drawing.Size(44, 44);
			this.panelColor.TabIndex = 1;
			// 
			// pictureBoxColor
			// 
			this.pictureBoxColor.BackgroundImage = global::LazyShell.Properties.Resources._transparent;
			this.pictureBoxColor.Location = new System.Drawing.Point(0, 0);
			this.pictureBoxColor.Name = "pictureBoxColor";
			this.pictureBoxColor.Size = new System.Drawing.Size(40, 40);
			this.pictureBoxColor.TabIndex = 499;
			this.pictureBoxColor.TabStop = false;
			this.pictureBoxColor.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxColor_Paint);
			// 
			// panelGraphics
			// 
			this.panelGraphics.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panelGraphics.Controls.Add(this.panelGraphicSet);
			this.panelGraphics.Controls.Add(this.toolStrip3);
			this.panelGraphics.Controls.Add(this.toolStrip2);
			this.panelGraphics.Location = new System.Drawing.Point(12, 118);
			this.panelGraphics.Name = "panelGraphics";
			this.panelGraphics.Size = new System.Drawing.Size(418, 396);
			this.panelGraphics.TabIndex = 4;
			this.panelGraphics.Scroll += new System.Windows.Forms.ScrollEventHandler(this.panelGraphicSet_Scroll);
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
			this.panelGraphicSet.Size = new System.Drawing.Size(392, 371);
			this.panelGraphicSet.TabIndex = 3;
			this.panelGraphicSet.Scroll += new System.Windows.Forms.ScrollEventHandler(this.panelGraphicSet_Scroll);
			this.panelGraphicSet.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelGraphicSet_MouseDown);
			this.panelGraphicSet.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.panelGraphicSet_PreviewKeyDown);
			// 
			// pictureBoxGraphicSet
			// 
			this.pictureBoxGraphicSet.BackgroundImage = global::LazyShell.Properties.Resources._transparent;
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
			this.pictureBoxGraphicSet.ZoomEnabled = true;
			this.pictureBoxGraphicSet.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxGraphicSet_Paint);
			this.pictureBoxGraphicSet.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxGraphicSet_MouseDown);
			this.pictureBoxGraphicSet.MouseEnter += new System.EventHandler(this.pictureBoxGraphicSet_MouseEnter);
			this.pictureBoxGraphicSet.MouseLeave += new System.EventHandler(this.pictureBoxGraphicSet_MouseLeave);
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
			this.contextMenuStrip.Size = new System.Drawing.Size(144, 120);
			this.contextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip_Opening);
			// 
			// importToolStripMenuItem
			// 
			this.importToolStripMenuItem.Image = global::LazyShell.Properties.Resources.importImage;
			this.importToolStripMenuItem.Name = "importToolStripMenuItem";
			this.importToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
			this.importToolStripMenuItem.Text = "Import...";
			this.importToolStripMenuItem.Click += new System.EventHandler(this.importToolStripMenuItem_Click);
			// 
			// exportToolStripMenuItem
			// 
			this.exportToolStripMenuItem.Image = global::LazyShell.Properties.Resources.exportBinary;
			this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
			this.exportToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
			this.exportToolStripMenuItem.Text = "Export...";
			this.exportToolStripMenuItem.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
			// 
			// saveImageToolStripMenuItem
			// 
			this.saveImageToolStripMenuItem.Image = global::LazyShell.Properties.Resources.exportImage;
			this.saveImageToolStripMenuItem.Name = "saveImageToolStripMenuItem";
			this.saveImageToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
			this.saveImageToolStripMenuItem.Text = "Save image...";
			this.saveImageToolStripMenuItem.Click += new System.EventHandler(this.saveImageToolStripMenuItem_Click);
			// 
			// toolStripSeparator36
			// 
			this.toolStripSeparator36.Name = "toolStripSeparator36";
			this.toolStripSeparator36.Size = new System.Drawing.Size(140, 6);
			// 
			// clearToolStripMenuItem
			// 
			this.clearToolStripMenuItem.Image = global::LazyShell.Properties.Resources.clear;
			this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
			this.clearToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
			this.clearToolStripMenuItem.Text = "Clear";
			this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
			// 
			// applyBorderToolStripMenuItem
			// 
			this.applyBorderToolStripMenuItem.Enabled = false;
			this.applyBorderToolStripMenuItem.Name = "applyBorderToolStripMenuItem";
			this.applyBorderToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
			this.applyBorderToolStripMenuItem.Text = "Apply border";
			// 
			// toolStrip3
			// 
			this.toolStrip3.Dock = System.Windows.Forms.DockStyle.Left;
			this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editDraw,
            this.editErase,
            this.editSelect,
            this.editDropper,
            this.editFill,
            this.editReplaceColor,
            this.toolStripSeparator34,
            this.editCut,
            this.editCopy,
            this.editPaste,
            this.editDelete,
            this.toolStripSeparator5,
            this.mirror,
            this.invert,
            this.toolStripSeparator3,
            this.undo,
            this.redo});
			this.toolStrip3.Location = new System.Drawing.Point(0, 25);
			this.toolStrip3.Name = "toolStrip3";
			this.toolStrip3.Size = new System.Drawing.Size(26, 371);
			this.toolStrip3.TabIndex = 6;
			// 
			// editDraw
			// 
			this.editDraw.CheckOnClick = true;
			this.editDraw.Image = global::LazyShell.Properties.Resources.draw;
			this.editDraw.Name = "editDraw";
			this.editDraw.Size = new System.Drawing.Size(23, 20);
			this.editDraw.ToolTipText = "Draw (D)";
			this.editDraw.Click += new System.EventHandler(this.editDraw_Click);
			// 
			// editErase
			// 
			this.editErase.CheckOnClick = true;
			this.editErase.Image = global::LazyShell.Properties.Resources.erase;
			this.editErase.Name = "editErase";
			this.editErase.Size = new System.Drawing.Size(23, 20);
			this.editErase.ToolTipText = "Erase (E)";
			this.editErase.Click += new System.EventHandler(this.editErase_Click);
			// 
			// editSelect
			// 
			this.editSelect.CheckOnClick = true;
			this.editSelect.Image = global::LazyShell.Properties.Resources.select;
			this.editSelect.Name = "editSelect";
			this.editSelect.Size = new System.Drawing.Size(23, 20);
			this.editSelect.ToolTipText = "Select (S)";
			this.editSelect.Click += new System.EventHandler(this.editSelect_Click);
			// 
			// editDropper
			// 
			this.editDropper.CheckOnClick = true;
			this.editDropper.Image = global::LazyShell.Properties.Resources.dropper;
			this.editDropper.Name = "editDropper";
			this.editDropper.Size = new System.Drawing.Size(23, 20);
			this.editDropper.ToolTipText = "Dropper (P)";
			this.editDropper.Click += new System.EventHandler(this.editDropper_Click);
			// 
			// editFill
			// 
			this.editFill.CheckOnClick = true;
			this.editFill.Image = global::LazyShell.Properties.Resources.fill;
			this.editFill.Name = "editFill";
			this.editFill.Size = new System.Drawing.Size(23, 20);
			this.editFill.ToolTipText = "Fill (F)";
			this.editFill.Click += new System.EventHandler(this.editFill_Click);
			// 
			// editReplaceColor
			// 
			this.editReplaceColor.CheckOnClick = true;
			this.editReplaceColor.Image = global::LazyShell.Properties.Resources.colorreplace;
			this.editReplaceColor.Name = "editReplaceColor";
			this.editReplaceColor.Size = new System.Drawing.Size(23, 20);
			this.editReplaceColor.ToolTipText = "Color Replace (R)";
			this.editReplaceColor.Click += new System.EventHandler(this.editReplaceColor_Click);
			// 
			// toolStripSeparator34
			// 
			this.toolStripSeparator34.Margin = new System.Windows.Forms.Padding(0, 0, 2, 0);
			this.toolStripSeparator34.Name = "toolStripSeparator34";
			this.toolStripSeparator34.Size = new System.Drawing.Size(21, 6);
			// 
			// editCut
			// 
			this.editCut.Image = global::LazyShell.Properties.Resources.cut;
			this.editCut.Name = "editCut";
			this.editCut.Size = new System.Drawing.Size(23, 20);
			this.editCut.ToolTipText = "Cut (Ctrl+X)";
			this.editCut.Click += new System.EventHandler(this.editCut_Click);
			// 
			// editCopy
			// 
			this.editCopy.Image = global::LazyShell.Properties.Resources.copy;
			this.editCopy.Name = "editCopy";
			this.editCopy.Size = new System.Drawing.Size(23, 20);
			this.editCopy.ToolTipText = "Copy (Ctrl+C)";
			this.editCopy.Click += new System.EventHandler(this.editCopy_Click);
			// 
			// editPaste
			// 
			this.editPaste.Image = global::LazyShell.Properties.Resources.paste;
			this.editPaste.Name = "editPaste";
			this.editPaste.Size = new System.Drawing.Size(23, 20);
			this.editPaste.ToolTipText = "Paste (Ctrl+V)";
			this.editPaste.Click += new System.EventHandler(this.editPaste_Click);
			// 
			// editDelete
			// 
			this.editDelete.Image = global::LazyShell.Properties.Resources.delete;
			this.editDelete.Name = "editDelete";
			this.editDelete.Size = new System.Drawing.Size(23, 20);
			this.editDelete.ToolTipText = "Delete (Del)";
			this.editDelete.Click += new System.EventHandler(this.editDelete_Click);
			// 
			// toolStripSeparator5
			// 
			this.toolStripSeparator5.Name = "toolStripSeparator5";
			this.toolStripSeparator5.Size = new System.Drawing.Size(23, 6);
			// 
			// mirror
			// 
			this.mirror.Image = global::LazyShell.Properties.Resources.mirror;
			this.mirror.Name = "mirror";
			this.mirror.Size = new System.Drawing.Size(23, 20);
			this.mirror.ToolTipText = "Mirror Selection";
			this.mirror.Click += new System.EventHandler(this.mirror_Click);
			// 
			// invert
			// 
			this.invert.Image = global::LazyShell.Properties.Resources.flip;
			this.invert.Name = "invert";
			this.invert.Size = new System.Drawing.Size(23, 20);
			this.invert.ToolTipText = "Invert Selection";
			this.invert.Click += new System.EventHandler(this.invert_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(23, 6);
			// 
			// undo
			// 
			this.undo.Image = global::LazyShell.Properties.Resources.undo;
			this.undo.Name = "undo";
			this.undo.Size = new System.Drawing.Size(23, 20);
			this.undo.ToolTipText = "Undo (Ctrl+Z)";
			this.undo.Click += new System.EventHandler(this.undo_Click);
			// 
			// redo
			// 
			this.redo.Image = global::LazyShell.Properties.Resources.redo;
			this.redo.Name = "redo";
			this.redo.Size = new System.Drawing.Size(23, 20);
			this.redo.ToolTipText = "Redo (Ctrl+Y)";
			this.redo.Click += new System.EventHandler(this.redo_Click);
			// 
			// toolStrip2
			// 
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
            this.labelBrushSize,
            this.brushSize,
            this.contiguous});
			this.toolStrip2.Location = new System.Drawing.Point(0, 0);
			this.toolStrip2.Name = "toolStrip2";
			this.toolStrip2.Padding = new System.Windows.Forms.Padding(0);
			this.toolStrip2.Size = new System.Drawing.Size(418, 25);
			this.toolStrip2.TabIndex = 0;
			this.toolStrip2.TabStop = true;
			// 
			// helpTips
			// 
			this.helpTips.CheckOnClick = true;
			this.helpTips.Image = global::LazyShell.Properties.Resources.help;
			this.helpTips.Name = "helpTips";
			this.helpTips.Size = new System.Drawing.Size(23, 22);
			this.helpTips.ToolTipText = "Help Tips";
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
			// 
			// graphicShowGrid
			// 
			this.graphicShowGrid.CheckOnClick = true;
			this.graphicShowGrid.Image = global::LazyShell.Properties.Resources.buttonToggleGrid;
			this.graphicShowGrid.Name = "graphicShowGrid";
			this.graphicShowGrid.Size = new System.Drawing.Size(23, 22);
			this.graphicShowGrid.ToolTipText = "Tile Grid (G)";
			this.graphicShowGrid.Click += new System.EventHandler(this.graphicShowGrid_Click);
			// 
			// graphicShowPixelGrid
			// 
			this.graphicShowPixelGrid.CheckOnClick = true;
			this.graphicShowPixelGrid.Image = global::LazyShell.Properties.Resources.buttonTogglePixelGrid;
			this.graphicShowPixelGrid.Name = "graphicShowPixelGrid";
			this.graphicShowPixelGrid.Size = new System.Drawing.Size(23, 22);
			this.graphicShowPixelGrid.ToolTipText = "Pixel Grid (T)";
			this.graphicShowPixelGrid.Click += new System.EventHandler(this.graphicShowPixelGrid_Click);
			// 
			// showBG
			// 
			this.showBG.CheckOnClick = true;
			this.showBG.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.showBG.Name = "showBG";
			this.showBG.Size = new System.Drawing.Size(26, 22);
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
			this.graphicZoomIn.Image = global::LazyShell.Properties.Resources.zoomin;
			this.graphicZoomIn.Name = "graphicZoomIn";
			this.graphicZoomIn.Size = new System.Drawing.Size(23, 22);
			this.graphicZoomIn.ToolTipText = "Zoom In (Ctrl+Up)";
			this.graphicZoomIn.Click += new System.EventHandler(this.graphicZoomIn_Click);
			// 
			// graphicZoomOut
			// 
			this.graphicZoomOut.CheckOnClick = true;
			this.graphicZoomOut.Image = global::LazyShell.Properties.Resources.zoomout;
			this.graphicZoomOut.Name = "graphicZoomOut";
			this.graphicZoomOut.Size = new System.Drawing.Size(23, 22);
			this.graphicZoomOut.ToolTipText = "Zoom Out (Ctrl+Down)";
			this.graphicZoomOut.Click += new System.EventHandler(this.graphicZoomOut_Click);
			// 
			// toggleZoomBox
			// 
			this.toggleZoomBox.CheckOnClick = true;
			this.toggleZoomBox.Image = global::LazyShell.Properties.Resources.zoomBox;
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
			this.widthDecrease.Image = global::LazyShell.Properties.Resources.widthDecrease;
			this.widthDecrease.Name = "widthDecrease";
			this.widthDecrease.Size = new System.Drawing.Size(17, 17);
			this.widthDecrease.ToolTipText = "Decrease Width";
			this.widthDecrease.Click += new System.EventHandler(this.widthDecrease_Click);
			// 
			// widthIncrease
			// 
			this.widthIncrease.AutoSize = false;
			this.widthIncrease.Image = global::LazyShell.Properties.Resources.widthIncrease;
			this.widthIncrease.Name = "widthIncrease";
			this.widthIncrease.Size = new System.Drawing.Size(17, 17);
			this.widthIncrease.ToolTipText = "Increase Width";
			this.widthIncrease.Click += new System.EventHandler(this.widthIncrease_Click);
			// 
			// heightDecrease
			// 
			this.heightDecrease.AutoSize = false;
			this.heightDecrease.Image = global::LazyShell.Properties.Resources.heightDecrease;
			this.heightDecrease.Name = "heightDecrease";
			this.heightDecrease.Size = new System.Drawing.Size(17, 17);
			this.heightDecrease.ToolTipText = "Decrease Height";
			this.heightDecrease.Click += new System.EventHandler(this.heightDecrease_Click);
			// 
			// heightIncrease
			// 
			this.heightIncrease.AutoSize = false;
			this.heightIncrease.Image = global::LazyShell.Properties.Resources.heightIncrease;
			this.heightIncrease.Name = "heightIncrease";
			this.heightIncrease.Size = new System.Drawing.Size(17, 17);
			this.heightIncrease.ToolTipText = "Increase Height";
			this.heightIncrease.Click += new System.EventHandler(this.heightIncrease_Click);
			// 
			// toolStripSeparator33
			// 
			this.toolStripSeparator33.Margin = new System.Windows.Forms.Padding(0, 0, 2, 0);
			this.toolStripSeparator33.Name = "toolStripSeparator33";
			this.toolStripSeparator33.Size = new System.Drawing.Size(6, 26);
			this.toolStripSeparator33.Visible = false;
			// 
			// labelBrushSize
			// 
			this.labelBrushSize.Name = "labelBrushSize";
			this.labelBrushSize.Size = new System.Drawing.Size(33, 23);
			this.labelBrushSize.Text = " Size ";
			this.labelBrushSize.Visible = false;
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
			this.brushSize.Location = new System.Drawing.Point(259, 2);
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
			this.brushSize.Size = new System.Drawing.Size(40, 21);
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
			this.contiguous.BackColor = System.Drawing.Color.Transparent;
			this.contiguous.Checked = true;
			this.contiguous.Name = "contiguous";
			this.contiguous.Padding = new System.Windows.Forms.Padding(4, 0, 0, 4);
			this.contiguous.Size = new System.Drawing.Size(92, 23);
			this.contiguous.Text = "Contiguous";
			this.contiguous.ToolTipText = "Fill only adjacent pixels";
			this.contiguous.Visible = false;
			this.contiguous.VisibleChanged += new System.EventHandler(this.contiguous_VisibleChanged);
			// 
			// coordsLabel
			// 
			this.coordsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.coordsLabel.BackColor = System.Drawing.SystemColors.Control;
			this.coordsLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.coordsLabel.Location = new System.Drawing.Point(75, 0);
			this.coordsLabel.Name = "coordsLabel";
			this.coordsLabel.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
			this.coordsLabel.Size = new System.Drawing.Size(343, 21);
			this.coordsLabel.TabIndex = 4;
			this.coordsLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// panelPaletteSet
			// 
			this.panelPaletteSet.BackColor = System.Drawing.SystemColors.ControlText;
			this.panelPaletteSet.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panelPaletteSet.Controls.Add(this.pictureBoxPalette);
			this.panelPaletteSet.Location = new System.Drawing.Point(0, 0);
			this.panelPaletteSet.Name = "panelPaletteSet";
			this.panelPaletteSet.Size = new System.Drawing.Size(196, 100);
			this.panelPaletteSet.TabIndex = 0;
			// 
			// pictureBoxPalette
			// 
			this.pictureBoxPalette.BackgroundImage = global::LazyShell.Properties.Resources._transparent;
			this.pictureBoxPalette.Location = new System.Drawing.Point(0, 0);
			this.pictureBoxPalette.Name = "pictureBoxPalette";
			this.pictureBoxPalette.Size = new System.Drawing.Size(192, 96);
			this.pictureBoxPalette.TabIndex = 450;
			this.pictureBoxPalette.TabStop = false;
			this.pictureBoxPalette.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxPalette_Paint);
			this.pictureBoxPalette.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxPalette_MouseDown);
			// 
			// panelColorBack
			// 
			this.panelColorBack.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panelColorBack.Controls.Add(this.pictureBoxColorBack);
			this.panelColorBack.Location = new System.Drawing.Point(236, 24);
			this.panelColorBack.Name = "panelColorBack";
			this.panelColorBack.Size = new System.Drawing.Size(44, 44);
			this.panelColorBack.TabIndex = 2;
			// 
			// pictureBoxColorBack
			// 
			this.pictureBoxColorBack.BackgroundImage = global::LazyShell.Properties.Resources._transparent;
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
			this.buttonReset.Location = new System.Drawing.Point(343, 0);
			this.buttonReset.Name = "buttonReset";
			this.buttonReset.Size = new System.Drawing.Size(75, 23);
			this.buttonReset.TabIndex = 9;
			this.buttonReset.Text = "Reset";
			this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
			// 
			// buttonOK
			// 
			this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonOK.FlatAppearance.BorderSize = 0;
			this.buttonOK.Location = new System.Drawing.Point(181, 0);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(75, 23);
			this.buttonOK.TabIndex = 7;
			this.buttonOK.Text = "OK";
			this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonCancel.FlatAppearance.BorderSize = 0;
			this.buttonCancel.Location = new System.Drawing.Point(262, 0);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 8;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// buttonUpdate
			// 
			this.buttonUpdate.Location = new System.Drawing.Point(0, 0);
			this.buttonUpdate.Name = "buttonUpdate";
			this.buttonUpdate.Size = new System.Drawing.Size(75, 23);
			this.buttonUpdate.TabIndex = 5;
			this.buttonUpdate.Text = "Update";
			this.buttonUpdate.UseVisualStyleBackColor = true;
			this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
			// 
			// autoUpdate
			// 
			this.autoUpdate.AutoSize = true;
			this.autoUpdate.Checked = true;
			this.autoUpdate.CheckState = System.Windows.Forms.CheckState.Checked;
			this.autoUpdate.Location = new System.Drawing.Point(81, 6);
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
			this.alwaysOnTop.Location = new System.Drawing.Point(324, 0);
			this.alwaysOnTop.Name = "alwaysOnTop";
			this.alwaysOnTop.Size = new System.Drawing.Size(94, 17);
			this.alwaysOnTop.TabIndex = 3;
			this.alwaysOnTop.Text = "Always on top";
			this.alwaysOnTop.UseVisualStyleBackColor = true;
			this.alwaysOnTop.CheckedChanged += new System.EventHandler(this.alwaysOnTop_CheckedChanged);
			// 
			// switchColors
			// 
			this.switchColors.BackgroundImage = global::LazyShell.Properties.Resources._switch;
			this.switchColors.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.switchColors.Location = new System.Drawing.Point(206, 52);
			this.switchColors.Name = "switchColors";
			this.switchColors.Size = new System.Drawing.Size(16, 16);
			this.switchColors.TabIndex = 10;
			this.switchColors.TabStop = false;
			this.switchColors.MouseDown += new System.Windows.Forms.MouseEventHandler(this.switchColors_MouseDown);
			// 
			// sizeLabel
			// 
			this.sizeLabel.BackColor = System.Drawing.SystemColors.Control;
			this.sizeLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.sizeLabel.Location = new System.Drawing.Point(0, 0);
			this.sizeLabel.Name = "sizeLabel";
			this.sizeLabel.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
			this.sizeLabel.Size = new System.Drawing.Size(75, 21);
			this.sizeLabel.TabIndex = 11;
			// 
			// panelPalettes
			// 
			this.panelPalettes.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.panelPalettes.Controls.Add(this.panelColor);
			this.panelPalettes.Controls.Add(this.panelPaletteSet);
			this.panelPalettes.Controls.Add(this.panelColorBack);
			this.panelPalettes.Controls.Add(this.switchColors);
			this.panelPalettes.Controls.Add(this.alwaysOnTop);
			this.panelPalettes.Location = new System.Drawing.Point(12, 12);
			this.panelPalettes.Name = "panelPalettes";
			this.panelPalettes.Size = new System.Drawing.Size(418, 100);
			this.panelPalettes.TabIndex = 12;
			// 
			// panelButtons
			// 
			this.panelButtons.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panelButtons.Controls.Add(this.buttonUpdate);
			this.panelButtons.Controls.Add(this.buttonReset);
			this.panelButtons.Controls.Add(this.buttonCancel);
			this.panelButtons.Controls.Add(this.buttonOK);
			this.panelButtons.Controls.Add(this.autoUpdate);
			this.panelButtons.Location = new System.Drawing.Point(12, 541);
			this.panelButtons.Name = "panelButtons";
			this.panelButtons.Size = new System.Drawing.Size(418, 23);
			this.panelButtons.TabIndex = 13;
			// 
			// panelLabels
			// 
			this.panelLabels.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panelLabels.Controls.Add(this.sizeLabel);
			this.panelLabels.Controls.Add(this.coordsLabel);
			this.panelLabels.Location = new System.Drawing.Point(12, 514);
			this.panelLabels.Name = "panelLabels";
			this.panelLabels.Size = new System.Drawing.Size(418, 21);
			this.panelLabels.TabIndex = 14;
			// 
			// GraphicEditor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(442, 576);
			this.Controls.Add(this.panelLabels);
			this.Controls.Add(this.panelButtons);
			this.Controls.Add(this.panelPalettes);
			this.Controls.Add(this.panelGraphics);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.Location = new System.Drawing.Point(0, 0);
			this.MinimizeBox = false;
			this.Name = "GraphicEditor";
			this.Text = "Graphics Editor - Lazy Shell";
			this.TopMost = true;
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GraphicEditor_FormClosing);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GraphicEditor_KeyDown);
			this.panelColor.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxColor)).EndInit();
			this.panelGraphics.ResumeLayout(false);
			this.panelGraphics.PerformLayout();
			this.panelGraphicSet.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxGraphicSet)).EndInit();
			this.contextMenuStrip.ResumeLayout(false);
			this.toolStrip3.ResumeLayout(false);
			this.toolStrip3.PerformLayout();
			this.toolStrip2.ResumeLayout(false);
			this.toolStrip2.PerformLayout();
			this.panelPaletteSet.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxPalette)).EndInit();
			this.panelColorBack.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxColorBack)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.switchColors)).EndInit();
			this.panelPalettes.ResumeLayout(false);
			this.panelPalettes.PerformLayout();
			this.panelButtons.ResumeLayout(false);
			this.panelButtons.PerformLayout();
			this.panelLabels.ResumeLayout(false);
			this.ResumeLayout(false);

        }
        #endregion
        private System.Windows.Forms.Panel panelColor;
        private System.Windows.Forms.PictureBox pictureBoxColor;
        private System.Windows.Forms.Panel panelGraphics;
        private Controls.NewPanel panelGraphicSet;
        private Controls.NewPictureBox pictureBoxGraphicSet;
        private System.Windows.Forms.Label coordsLabel;
        private System.Windows.Forms.Panel panelPaletteSet;
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
        private System.Windows.Forms.Panel panelColorBack;
        private System.Windows.Forms.PictureBox pictureBoxColorBack;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton graphicShowGrid;
        private System.Windows.Forms.ToolStripButton graphicShowPixelGrid;
        private System.Windows.Forms.ToolStripButton editDraw;
        private System.Windows.Forms.ToolStripButton editErase;
        private System.Windows.Forms.ToolStripButton editDropper;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator34;
        private System.Windows.Forms.ToolStripButton graphicZoomIn;
        private System.Windows.Forms.ToolStripButton graphicZoomOut;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton widthDecrease;
        private System.Windows.Forms.ToolStripButton widthIncrease;
        private System.Windows.Forms.ToolStripButton heightDecrease;
        private System.Windows.Forms.ToolStripButton heightIncrease;
        private System.Windows.Forms.ToolStripButton editFill;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.CheckBox autoUpdate;
        private System.Windows.Forms.CheckBox alwaysOnTop;
        private System.Windows.Forms.ToolStripButton editReplaceColor;
        private System.Windows.Forms.ToolStripButton helpTips;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.PictureBox switchColors;
        private System.Windows.Forms.ToolStripButton undo;
        private System.Windows.Forms.ToolStripButton redo;
        private Controls.NewToolStripNumericUpDown brushSize;
        private System.Windows.Forms.ToolStripLabel labelBrushSize;
        private Controls.NewToolStripCheckBox contiguous;
        private System.Windows.Forms.ToolStripButton editSelect;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator33;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton editCut;
        private System.Windows.Forms.ToolStripButton editCopy;
        private System.Windows.Forms.ToolStripButton editPaste;
        private System.Windows.Forms.ToolStripButton editDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.Label sizeLabel;
        private System.Windows.Forms.ToolStripButton showBG;
        private System.Windows.Forms.ToolStripButton toggleZoomBox;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton mirror;
        private System.Windows.Forms.ToolStripButton invert;
        private System.Windows.Forms.Panel panelPalettes;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Panel panelLabels;
    }
}