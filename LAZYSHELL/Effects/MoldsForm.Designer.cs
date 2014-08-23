
namespace LAZYSHELL.Effects
{
    partial class MoldsForm
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
            this.moldWidth = new LAZYSHELL.Controls.NewToolStripNumericUpDown();
            this.moldHeight = new LAZYSHELL.Controls.NewToolStripNumericUpDown();
            this.panelMoldImage = new LAZYSHELL.Controls.NewPanel();
            this.pictureBoxMold = new LAZYSHELL.Controls.NewPictureBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuCut = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.menuMirror = new System.Windows.Forms.ToolStripMenuItem();
            this.menuInvert = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.menuSaveImageAs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip6 = new System.Windows.Forms.ToolStrip();
            this.draw = new System.Windows.Forms.ToolStripButton();
            this.erase = new System.Windows.Forms.ToolStripButton();
            this.select = new System.Windows.Forms.ToolStripButton();
            this.selectAll = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.cut = new System.Windows.Forms.ToolStripButton();
            this.copy = new System.Windows.Forms.ToolStripButton();
            this.paste = new System.Windows.Forms.ToolStripButton();
            this.delete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.undoButton = new System.Windows.Forms.ToolStripButton();
            this.redoButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mirror = new System.Windows.Forms.ToolStripButton();
            this.invert = new System.Windows.Forms.ToolStripButton();
            this.toggleTileGrid = new System.Windows.Forms.ToolStripButton();
            this.zoomIn = new System.Windows.Forms.ToolStripButton();
            this.zoomOut = new System.Windows.Forms.ToolStripButton();
            this.panel105 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBoxTileset = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuTilesetSaveImageAs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.openTileEditor = new System.Windows.Forms.ToolStripButton();
            this.label86 = new System.Windows.Forms.Label();
            this.tilesetSize = new System.Windows.Forms.NumericUpDown();
            this.listBox = new LAZYSHELL.Controls.NewListBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.importIntoTilemap = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.newMold = new System.Windows.Forms.ToolStripButton();
            this.deleteMold = new System.Windows.Forms.ToolStripButton();
            this.duplicateMold = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.toggleBG = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.toggleZoomBox = new System.Windows.Forms.ToolStripButton();
            this.labelCoords = new System.Windows.Forms.Label();
            this.panelMoldImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMold)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.toolStrip6.SuspendLayout();
            this.panel105.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTileset)).BeginInit();
            this.contextMenuStrip2.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tilesetSize)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // moldWidth
            // 
            this.moldWidth.AutoSize = false;
            this.moldWidth.ContextMenuStrip = null;
            this.moldWidth.Hexadecimal = false;
            this.moldWidth.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.moldWidth.Location = new System.Drawing.Point(140, 1);
            this.moldWidth.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.moldWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.moldWidth.Name = "e_moldWidth";
            this.moldWidth.Size = new System.Drawing.Size(40, 21);
            this.moldWidth.Text = "1";
            this.moldWidth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.moldWidth.ValueChanged += new System.EventHandler(this.moldWidth_ValueChanged);
            // 
            // moldHeight
            // 
            this.moldHeight.AutoSize = false;
            this.moldHeight.ContextMenuStrip = null;
            this.moldHeight.Hexadecimal = false;
            this.moldHeight.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.moldHeight.Location = new System.Drawing.Point(180, 1);
            this.moldHeight.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.moldHeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.moldHeight.Name = "e_moldHeight";
            this.moldHeight.Size = new System.Drawing.Size(40, 21);
            this.moldHeight.Text = "1";
            this.moldHeight.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.moldHeight.ValueChanged += new System.EventHandler(this.moldHeight_ValueChanged);
            // 
            // panelMoldImage
            // 
            this.panelMoldImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelMoldImage.AutoScroll = true;
            this.panelMoldImage.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panelMoldImage.BackgroundImage = global::LAZYSHELL.Properties.Resources._canvas;
            this.panelMoldImage.Controls.Add(this.pictureBoxMold);
            this.panelMoldImage.Location = new System.Drawing.Point(102, 25);
            this.panelMoldImage.Name = "panelMoldImage";
            this.panelMoldImage.Size = new System.Drawing.Size(438, 287);
            this.panelMoldImage.TabIndex = 3;
            // 
            // pictureBoxMold
            // 
            this.pictureBoxMold.BackgroundImage = global::LAZYSHELL.Properties.Resources._transparent;
            this.pictureBoxMold.ContextMenuStrip = this.contextMenuStrip1;
            this.pictureBoxMold.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxMold.Name = "pictureBoxMold";
            this.pictureBoxMold.Size = new System.Drawing.Size(256, 256);
            this.pictureBoxMold.TabIndex = 399;
            this.pictureBoxMold.TabStop = false;
            this.pictureBoxMold.Zoom = 1;
            this.pictureBoxMold.ZoomBoxEnabled = false;
            this.pictureBoxMold.ZoomBoxPosition = new System.Drawing.Point(32, 32);
            this.pictureBoxMold.ZoomBoxZoom = 4;
            this.pictureBoxMold.ZoomEnabled = true;
            this.pictureBoxMold.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxMold_Paint);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuCut,
            this.menuCopy,
            this.menuPaste,
            this.menuDelete,
            this.toolStripSeparator6,
            this.menuMirror,
            this.menuInvert,
            this.toolStripSeparator5,
            this.menuSaveImageAs});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(160, 170);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // menuCut
            // 
            this.menuCut.Image = global::LAZYSHELL.Properties.Resources.cut;
            this.menuCut.Name = "menuCut";
            this.menuCut.Size = new System.Drawing.Size(159, 22);
            this.menuCut.Text = "Cut";
            this.menuCut.Click += new System.EventHandler(this.cut_Click);
            // 
            // menuCopy
            // 
            this.menuCopy.Image = global::LAZYSHELL.Properties.Resources.copy;
            this.menuCopy.Name = "menuCopy";
            this.menuCopy.Size = new System.Drawing.Size(159, 22);
            this.menuCopy.Text = "Copy";
            this.menuCopy.Click += new System.EventHandler(this.copy_Click);
            // 
            // menuPaste
            // 
            this.menuPaste.Image = global::LAZYSHELL.Properties.Resources.paste;
            this.menuPaste.Name = "menuPaste";
            this.menuPaste.Size = new System.Drawing.Size(159, 22);
            this.menuPaste.Text = "Paste";
            this.menuPaste.Click += new System.EventHandler(this.paste_Click);
            // 
            // menuDelete
            // 
            this.menuDelete.Image = global::LAZYSHELL.Properties.Resources.delete;
            this.menuDelete.Name = "menuDelete";
            this.menuDelete.Size = new System.Drawing.Size(159, 22);
            this.menuDelete.Text = "Delete";
            this.menuDelete.Click += new System.EventHandler(this.delete_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(156, 6);
            // 
            // menuMirror
            // 
            this.menuMirror.Image = global::LAZYSHELL.Properties.Resources.mirror;
            this.menuMirror.Name = "menuMirror";
            this.menuMirror.Size = new System.Drawing.Size(159, 22);
            this.menuMirror.Text = "Mirror";
            this.menuMirror.Click += new System.EventHandler(this.mirror_Click);
            // 
            // menuInvert
            // 
            this.menuInvert.Image = global::LAZYSHELL.Properties.Resources.flip;
            this.menuInvert.Name = "menuInvert";
            this.menuInvert.Size = new System.Drawing.Size(159, 22);
            this.menuInvert.Text = "Invert";
            this.menuInvert.Click += new System.EventHandler(this.invert_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(156, 6);
            // 
            // menuSaveImageAs
            // 
            this.menuSaveImageAs.Image = global::LAZYSHELL.Properties.Resources.exportImage;
            this.menuSaveImageAs.Name = "menuSaveImageAs";
            this.menuSaveImageAs.Size = new System.Drawing.Size(159, 22);
            this.menuSaveImageAs.Text = "Save Image As...";
            this.menuSaveImageAs.Click += new System.EventHandler(this.menuSaveImageAs_Click);
            // 
            // toolStrip6
            // 
            this.toolStrip6.AutoSize = false;
            this.toolStrip6.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolStrip6.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.draw,
            this.erase,
            this.select,
            this.selectAll,
            this.toolStripSeparator4,
            this.cut,
            this.copy,
            this.paste,
            this.delete,
            this.toolStripSeparator1,
            this.undoButton,
            this.redoButton,
            this.toolStripSeparator2,
            this.mirror,
            this.invert});
            this.toolStrip6.Location = new System.Drawing.Point(78, 25);
            this.toolStrip6.Name = "toolStrip6";
            this.toolStrip6.Size = new System.Drawing.Size(24, 311);
            this.toolStrip6.TabIndex = 2;
            this.toolStrip6.TabStop = true;
            // 
            // draw
            // 
            this.draw.CheckOnClick = true;
            this.draw.Image = global::LAZYSHELL.Properties.Resources.draw;
            this.draw.Name = "draw";
            this.draw.Size = new System.Drawing.Size(22, 20);
            this.draw.ToolTipText = "Draw (D)";
            this.draw.Click += new System.EventHandler(this.draw_Click);
            // 
            // erase
            // 
            this.erase.CheckOnClick = true;
            this.erase.Image = global::LAZYSHELL.Properties.Resources.erase;
            this.erase.Name = "erase";
            this.erase.Size = new System.Drawing.Size(22, 20);
            this.erase.ToolTipText = "Erase (E)";
            this.erase.Click += new System.EventHandler(this.erase_Click);
            // 
            // select
            // 
            this.select.CheckOnClick = true;
            this.select.Image = global::LAZYSHELL.Properties.Resources.select;
            this.select.Name = "select";
            this.select.Size = new System.Drawing.Size(22, 20);
            this.select.ToolTipText = "Select (S)";
            this.select.Click += new System.EventHandler(this.select_Click);
            // 
            // selectAll
            // 
            this.selectAll.Image = global::LAZYSHELL.Properties.Resources.select_all;
            this.selectAll.Name = "selectAll";
            this.selectAll.Size = new System.Drawing.Size(22, 20);
            this.selectAll.ToolTipText = "Select All (Ctrl+A)";
            this.selectAll.Click += new System.EventHandler(this.selectAll_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(22, 6);
            // 
            // cut
            // 
            this.cut.Image = global::LAZYSHELL.Properties.Resources.cut;
            this.cut.Name = "cut";
            this.cut.Size = new System.Drawing.Size(22, 20);
            this.cut.ToolTipText = "Cut (Ctrl+X)";
            this.cut.Click += new System.EventHandler(this.cut_Click);
            // 
            // copy
            // 
            this.copy.Image = global::LAZYSHELL.Properties.Resources.copy;
            this.copy.Name = "copy";
            this.copy.Size = new System.Drawing.Size(22, 20);
            this.copy.ToolTipText = "Copy (Ctrl+C)";
            this.copy.Click += new System.EventHandler(this.copy_Click);
            // 
            // paste
            // 
            this.paste.Image = global::LAZYSHELL.Properties.Resources.paste;
            this.paste.Name = "paste";
            this.paste.Size = new System.Drawing.Size(22, 20);
            this.paste.ToolTipText = "Paste (Ctrl+V)";
            this.paste.Click += new System.EventHandler(this.paste_Click);
            // 
            // delete
            // 
            this.delete.Image = global::LAZYSHELL.Properties.Resources.delete;
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(22, 20);
            this.delete.ToolTipText = "Delete (Del)";
            this.delete.Click += new System.EventHandler(this.delete_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(22, 6);
            // 
            // undoButton
            // 
            this.undoButton.Image = global::LAZYSHELL.Properties.Resources.undo;
            this.undoButton.Name = "undoButton";
            this.undoButton.Size = new System.Drawing.Size(22, 20);
            this.undoButton.ToolTipText = "Undo (Ctrl+Z)";
            this.undoButton.Click += new System.EventHandler(this.undoButton_Click);
            // 
            // redoButton
            // 
            this.redoButton.Image = global::LAZYSHELL.Properties.Resources.redo;
            this.redoButton.Name = "redoButton";
            this.redoButton.Size = new System.Drawing.Size(22, 20);
            this.redoButton.ToolTipText = "Redo (Ctrl+Y)";
            this.redoButton.Click += new System.EventHandler(this.redoButton_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(22, 6);
            // 
            // mirror
            // 
            this.mirror.Image = global::LAZYSHELL.Properties.Resources.mirror;
            this.mirror.Name = "mirror";
            this.mirror.Size = new System.Drawing.Size(22, 20);
            this.mirror.ToolTipText = "Mirror Selection";
            this.mirror.Click += new System.EventHandler(this.mirror_Click);
            // 
            // invert
            // 
            this.invert.Image = global::LAZYSHELL.Properties.Resources.flip;
            this.invert.Name = "invert";
            this.invert.Size = new System.Drawing.Size(22, 20);
            this.invert.ToolTipText = "Invert Selection";
            this.invert.Click += new System.EventHandler(this.invert_Click);
            // 
            // toggleTileGrid
            // 
            this.toggleTileGrid.CheckOnClick = true;
            this.toggleTileGrid.Image = global::LAZYSHELL.Properties.Resources.buttonToggleGrid;
            this.toggleTileGrid.Name = "toggleTileGrid";
            this.toggleTileGrid.Size = new System.Drawing.Size(23, 22);
            this.toggleTileGrid.ToolTipText = "Tile Grid (G)";
            this.toggleTileGrid.Click += new System.EventHandler(this.toggleTileGrid_Click);
            // 
            // zoomIn
            // 
            this.zoomIn.CheckOnClick = true;
            this.zoomIn.Image = global::LAZYSHELL.Properties.Resources.zoomin;
            this.zoomIn.Name = "zoomIn";
            this.zoomIn.Size = new System.Drawing.Size(23, 22);
            this.zoomIn.ToolTipText = "Zoom In (Ctrl+Up)";
            this.zoomIn.Click += new System.EventHandler(this.zoomIn_Click);
            // 
            // zoomOut
            // 
            this.zoomOut.CheckOnClick = true;
            this.zoomOut.Image = global::LAZYSHELL.Properties.Resources.zoomout;
            this.zoomOut.Name = "zoomOut";
            this.zoomOut.Size = new System.Drawing.Size(23, 22);
            this.zoomOut.ToolTipText = "Zoom Out (Ctrl+Down)";
            this.zoomOut.Click += new System.EventHandler(this.zoomOut_Click);
            // 
            // panel105
            // 
            this.panel105.BackColor = System.Drawing.SystemColors.ControlText;
            this.panel105.Controls.Add(this.panel1);
            this.panel105.Controls.Add(this.toolStrip2);
            this.panel105.Controls.Add(this.label86);
            this.panel105.Controls.Add(this.tilesetSize);
            this.panel105.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel105.Location = new System.Drawing.Point(540, 25);
            this.panel105.Name = "panel105";
            this.panel105.Size = new System.Drawing.Size(132, 311);
            this.panel105.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.BackgroundImage = global::LAZYSHELL.Properties.Resources._canvas;
            this.panel1.Controls.Add(this.pictureBoxTileset);
            this.panel1.Location = new System.Drawing.Point(0, 46);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(132, 265);
            this.panel1.TabIndex = 3;
            // 
            // pictureBoxTileset
            // 
            this.pictureBoxTileset.BackgroundImage = global::LAZYSHELL.Properties.Resources._transparent;
            this.pictureBoxTileset.ContextMenuStrip = this.contextMenuStrip2;
            this.pictureBoxTileset.Cursor = System.Windows.Forms.Cursors.Cross;
            this.pictureBoxTileset.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBoxTileset.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxTileset.Name = "pictureBoxTileset";
            this.pictureBoxTileset.Size = new System.Drawing.Size(132, 128);
            this.pictureBoxTileset.TabIndex = 397;
            this.pictureBoxTileset.TabStop = false;
            this.pictureBoxTileset.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxTileset_Paint);
            this.pictureBoxTileset.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxTileset_MouseDown);
            this.pictureBoxTileset.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxTileset_MouseMove);
            this.pictureBoxTileset.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBoxTileset_MouseUp);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuTilesetSaveImageAs});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(160, 26);
            // 
            // menuTilesetSaveImageAs
            // 
            this.menuTilesetSaveImageAs.Image = global::LAZYSHELL.Properties.Resources.exportImage;
            this.menuTilesetSaveImageAs.Name = "menuTilesetSaveImageAs";
            this.menuTilesetSaveImageAs.Size = new System.Drawing.Size(159, 22);
            this.menuTilesetSaveImageAs.Text = "Save Image As...";
            this.menuTilesetSaveImageAs.Click += new System.EventHandler(this.menuTilesetSaveImageAs_Click);
            // 
            // toolStrip2
            // 
            this.toolStrip2.AutoSize = false;
            this.toolStrip2.CanOverflow = false;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openTileEditor});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(132, 25);
            this.toolStrip2.TabIndex = 0;
            this.toolStrip2.TabStop = true;
            // 
            // openTileEditor
            // 
            this.openTileEditor.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openTileEditor.Image = global::LAZYSHELL.Properties.Resources.openTileEditor;
            this.openTileEditor.Name = "openTileEditor";
            this.openTileEditor.Size = new System.Drawing.Size(23, 22);
            this.openTileEditor.ToolTipText = "Tile Editor";
            this.openTileEditor.Click += new System.EventHandler(this.openTileEditor_Click);
            // 
            // label86
            // 
            this.label86.BackColor = System.Drawing.SystemColors.Control;
            this.label86.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label86.Location = new System.Drawing.Point(0, 25);
            this.label86.Name = "label86";
            this.label86.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.label86.Size = new System.Drawing.Size(67, 21);
            this.label86.TabIndex = 1;
            this.label86.Text = "Size";
            this.label86.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tilesetSize
            // 
            this.tilesetSize.Increment = new decimal(new int[] {
            64,
            0,
            0,
            0});
            this.tilesetSize.Location = new System.Drawing.Point(67, 25);
            this.tilesetSize.Maximum = new decimal(new int[] {
            512,
            0,
            0,
            0});
            this.tilesetSize.Minimum = new decimal(new int[] {
            64,
            0,
            0,
            0});
            this.tilesetSize.Name = "tilesetSize";
            this.tilesetSize.Size = new System.Drawing.Size(65, 20);
            this.tilesetSize.TabIndex = 2;
            this.tilesetSize.Value = new decimal(new int[] {
            64,
            0,
            0,
            0});
            this.tilesetSize.ValueChanged += new System.EventHandler(this.tileSetSize_ValueChanged);
            // 
            // listBox
            // 
            this.listBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.listBox.FormattingEnabled = true;
            this.listBox.IntegralHeight = false;
            this.listBox.LastSelectedIndex = -1;
            this.listBox.Location = new System.Drawing.Point(0, 25);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(78, 311);
            this.listBox.TabIndex = 1;
            this.listBox.SelectedIndexChanged += new System.EventHandler(this.listBox_SelectedIndexChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importIntoTilemap,
            this.toolStripSeparator9,
            this.newMold,
            this.deleteMold,
            this.duplicateMold,
            this.toolStripSeparator3,
            this.toolStripLabel1,
            this.moldWidth,
            this.moldHeight,
            this.toolStripSeparator7,
            this.toggleTileGrid,
            this.toggleBG,
            this.toolStripSeparator8,
            this.zoomIn,
            this.zoomOut,
            this.toggleZoomBox});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(672, 25);
            this.toolStrip1.TabIndex = 0;
            // 
            // importIntoTilemap
            // 
            this.importIntoTilemap.Image = global::LAZYSHELL.Properties.Resources.importImage;
            this.importIntoTilemap.Name = "importIntoTilemap";
            this.importIntoTilemap.Size = new System.Drawing.Size(23, 22);
            this.importIntoTilemap.ToolTipText = "Import Image(s)";
            this.importIntoTilemap.Click += new System.EventHandler(this.importIntoTilemap_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(6, 25);
            // 
            // newMold
            // 
            this.newMold.Image = global::LAZYSHELL.Properties.Resources.new_file;
            this.newMold.Name = "newMold";
            this.newMold.Size = new System.Drawing.Size(23, 22);
            this.newMold.ToolTipText = "New Mold";
            this.newMold.Click += new System.EventHandler(this.newMold_Click);
            // 
            // deleteMold
            // 
            this.deleteMold.Image = global::LAZYSHELL.Properties.Resources.delete;
            this.deleteMold.Name = "deleteMold";
            this.deleteMold.Size = new System.Drawing.Size(23, 22);
            this.deleteMold.ToolTipText = "Delete Mold";
            this.deleteMold.Click += new System.EventHandler(this.deleteMold_Click);
            // 
            // duplicateMold
            // 
            this.duplicateMold.Image = global::LAZYSHELL.Properties.Resources.duplicate;
            this.duplicateMold.Name = "duplicateMold";
            this.duplicateMold.Size = new System.Drawing.Size(23, 22);
            this.duplicateMold.ToolTipText = "Duplicate Mold";
            this.duplicateMold.Click += new System.EventHandler(this.duplicateMold_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(27, 22);
            this.toolStripLabel1.Text = "Size";
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 25);
            // 
            // toggleBG
            // 
            this.toggleBG.CheckOnClick = true;
            this.toggleBG.Name = "toggleBG";
            this.toggleBG.Size = new System.Drawing.Size(26, 22);
            this.toggleBG.Text = "BG";
            this.toggleBG.ToolTipText = "BG Color (B)";
            this.toggleBG.Click += new System.EventHandler(this.toggleBG_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 25);
            // 
            // toggleZoomBox
            // 
            this.toggleZoomBox.CheckOnClick = true;
            this.toggleZoomBox.Image = global::LAZYSHELL.Properties.Resources.zoomBox;
            this.toggleZoomBox.Name = "toggleZoomBox";
            this.toggleZoomBox.Size = new System.Drawing.Size(23, 22);
            this.toggleZoomBox.ToolTipText = "Zoom Box (Z)";
            this.toggleZoomBox.Click += new System.EventHandler(this.toggleZoomBox_Click);
            // 
            // labelCoords
            // 
            this.labelCoords.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelCoords.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelCoords.Location = new System.Drawing.Point(102, 312);
            this.labelCoords.Name = "labelCoords";
            this.labelCoords.Padding = new System.Windows.Forms.Padding(0, 0, 2, 2);
            this.labelCoords.Size = new System.Drawing.Size(438, 24);
            this.labelCoords.TabIndex = 4;
            this.labelCoords.Text = "(x: 0, y: 0) Pixel";
            this.labelCoords.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // MoldsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(672, 336);
            this.Controls.Add(this.panelMoldImage);
            this.Controls.Add(this.labelCoords);
            this.Controls.Add(this.panel105);
            this.Controls.Add(this.toolStrip6);
            this.Controls.Add(this.listBox);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "MoldsForm";
            this.Text = "Molds";
            this.TilesetForm = null;
            this.TilesetForms = new LAZYSHELL.TilesetForm[] {
        null};
            this.panelMoldImage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMold)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.toolStrip6.ResumeLayout(false);
            this.toolStrip6.PerformLayout();
            this.panel105.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTileset)).EndInit();
            this.contextMenuStrip2.ResumeLayout(false);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tilesetSize)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        private Controls.NewPanel panelMoldImage;
        private Controls.NewPictureBox pictureBoxMold;
        private System.Windows.Forms.ToolStrip toolStrip6;
        private System.Windows.Forms.ToolStripButton toggleTileGrid;
        private System.Windows.Forms.ToolStripButton draw;
        private System.Windows.Forms.ToolStripButton erase;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton zoomIn;
        private System.Windows.Forms.ToolStripButton zoomOut;
        private System.Windows.Forms.Panel panel105;
        private System.Windows.Forms.PictureBox pictureBoxTileset;
        private System.Windows.Forms.Label label86;
        private System.Windows.Forms.NumericUpDown tilesetSize;
        private Controls.NewListBox listBox;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton newMold;
        private System.Windows.Forms.ToolStripButton deleteMold;
        private System.Windows.Forms.ToolStripButton duplicateMold;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripButton select;
        private System.Windows.Forms.ToolStripButton cut;
        private System.Windows.Forms.ToolStripButton copy;
        private System.Windows.Forms.ToolStripButton paste;
        private System.Windows.Forms.ToolStripButton delete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton undoButton;
        private System.Windows.Forms.ToolStripButton redoButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton openTileEditor;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuCut;
        private System.Windows.Forms.ToolStripMenuItem menuCopy;
        private System.Windows.Forms.ToolStripMenuItem menuPaste;
        private System.Windows.Forms.ToolStripMenuItem menuDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem menuMirror;
        private System.Windows.Forms.ToolStripMenuItem menuInvert;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem menuSaveImageAs;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripButton mirror;
        private System.Windows.Forms.ToolStripButton invert;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripButton selectAll;
        private Controls.NewToolStripNumericUpDown moldWidth;
        private Controls.NewToolStripNumericUpDown moldHeight;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem menuTilesetSaveImageAs;
        private System.Windows.Forms.ToolStripButton toggleBG;
        private System.Windows.Forms.ToolStripButton importIntoTilemap;
        private System.Windows.Forms.Label labelCoords;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripButton toggleZoomBox;
    }
}