
namespace LAZYSHELL.WorldMaps
{
    partial class WorldMapsForm
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
            this.name = new System.Windows.Forms.ToolStripComboBox();
            this.worldMapYCoord = new System.Windows.Forms.NumericUpDown();
            this.label46 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.worldMapTileset = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.worldMapXCoord = new System.Windows.Forms.NumericUpDown();
            this.pointCount = new System.Windows.Forms.NumericUpDown();
            this.panel26 = new System.Windows.Forms.Panel();
            this.picture = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuCut = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.menuMirror = new System.Windows.Forms.ToolStripMenuItem();
            this.menuInvert = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.menuSaveImage = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.editSelect = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.editCut = new System.Windows.Forms.ToolStripButton();
            this.editCopy = new System.Windows.Forms.ToolStripButton();
            this.editPaste = new System.Windows.Forms.ToolStripButton();
            this.editDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.editMirror = new System.Windows.Forms.ToolStripButton();
            this.editInvert = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.editUndo = new System.Windows.Forms.ToolStripButton();
            this.editRedo = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toggleLocations = new System.Windows.Forms.ToolStripButton();
            this.toggleBanner = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toggleTileGrid = new System.Windows.Forms.ToolStripButton();
            this.toggleBG = new System.Windows.Forms.ToolStripButton();
            this.openTileEditor = new System.Windows.Forms.ToolStripButton();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.headerLabel1 = new LAZYSHELL.Controls.HeaderLabel();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.worldMapYCoord)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.worldMapTileset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.worldMapXCoord)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pointCount)).BeginInit();
            this.panel26.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picture)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // name
            // 
            this.name.DropDownHeight = 121;
            this.name.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.name.IntegralHeight = false;
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(142, 25);
            this.name.SelectedIndexChanged += new System.EventHandler(this.name_SelectedIndexChanged);
            // 
            // worldMapYCoord
            // 
            this.worldMapYCoord.Location = new System.Drawing.Point(212, 17);
            this.worldMapYCoord.Maximum = new decimal(new int[] {
            127,
            0,
            0,
            0});
            this.worldMapYCoord.Minimum = new decimal(new int[] {
            128,
            0,
            0,
            -2147483648});
            this.worldMapYCoord.Name = "worldMapYCoord";
            this.worldMapYCoord.Size = new System.Drawing.Size(47, 21);
            this.worldMapYCoord.TabIndex = 6;
            this.worldMapYCoord.ValueChanged += new System.EventHandler(this.worldMapYCoord_ValueChanged);
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.BackColor = System.Drawing.SystemColors.Control;
            this.label46.Location = new System.Drawing.Point(2, 19);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(52, 13);
            this.label46.TabIndex = 0;
            this.label46.Text = "Locations";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.BackColor = System.Drawing.SystemColors.Control;
            this.label21.Location = new System.Drawing.Point(125, 19);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(34, 13);
            this.label21.TabIndex = 4;
            this.label21.Text = "(X, Y)";
            // 
            // worldMapTileset
            // 
            this.worldMapTileset.Location = new System.Drawing.Point(65, 38);
            this.worldMapTileset.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.worldMapTileset.Name = "worldMapTileset";
            this.worldMapTileset.Size = new System.Drawing.Size(47, 21);
            this.worldMapTileset.TabIndex = 3;
            this.worldMapTileset.ValueChanged += new System.EventHandler(this.worldMapTileset_ValueChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.SystemColors.Control;
            this.label12.Location = new System.Drawing.Point(2, 40);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(38, 13);
            this.label12.TabIndex = 2;
            this.label12.Text = "Tileset";
            // 
            // worldMapXCoord
            // 
            this.worldMapXCoord.Location = new System.Drawing.Point(165, 17);
            this.worldMapXCoord.Maximum = new decimal(new int[] {
            127,
            0,
            0,
            0});
            this.worldMapXCoord.Minimum = new decimal(new int[] {
            128,
            0,
            0,
            -2147483648});
            this.worldMapXCoord.Name = "worldMapXCoord";
            this.worldMapXCoord.Size = new System.Drawing.Size(47, 21);
            this.worldMapXCoord.TabIndex = 5;
            this.worldMapXCoord.ValueChanged += new System.EventHandler(this.worldMapXCoord_ValueChanged);
            // 
            // pointCount
            // 
            this.pointCount.Location = new System.Drawing.Point(65, 17);
            this.pointCount.Maximum = new decimal(new int[] {
            56,
            0,
            0,
            0});
            this.pointCount.Name = "pointCount";
            this.pointCount.Size = new System.Drawing.Size(47, 21);
            this.pointCount.TabIndex = 1;
            this.pointCount.ValueChanged += new System.EventHandler(this.pointCount_ValueChanged);
            // 
            // panel26
            // 
            this.panel26.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel26.Controls.Add(this.picture);
            this.panel26.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel26.Location = new System.Drawing.Point(26, 0);
            this.panel26.Name = "panel26";
            this.panel26.Size = new System.Drawing.Size(260, 260);
            this.panel26.TabIndex = 3;
            // 
            // picture
            // 
            this.picture.BackgroundImage = global::LAZYSHELL.Properties.Resources._transparent;
            this.picture.ContextMenuStrip = this.contextMenuStrip1;
            this.picture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picture.Location = new System.Drawing.Point(0, 0);
            this.picture.Name = "picture";
            this.picture.Size = new System.Drawing.Size(260, 260);
            this.picture.TabIndex = 447;
            this.picture.TabStop = false;
            this.picture.Paint += new System.Windows.Forms.PaintEventHandler(this.picture_Paint);
            this.picture.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picture_MouseDown);
            this.picture.MouseEnter += new System.EventHandler(this.picture_MouseEnter);
            this.picture.MouseLeave += new System.EventHandler(this.picture_MouseLeave);
            this.picture.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picture_MouseMove);
            this.picture.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picture_MouseUp);
            this.picture.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.picture_PreviewKeyDown);
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
            this.toolStripSeparator7,
            this.menuSaveImage});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(160, 170);
            // 
            // menuCut
            // 
            this.menuCut.Image = global::LAZYSHELL.Properties.Resources.cut;
            this.menuCut.Name = "menuCut";
            this.menuCut.Size = new System.Drawing.Size(159, 22);
            this.menuCut.Text = "Cut";
            this.menuCut.Click += new System.EventHandler(this.editCut_Click);
            // 
            // menuCopy
            // 
            this.menuCopy.Image = global::LAZYSHELL.Properties.Resources.copy;
            this.menuCopy.Name = "menuCopy";
            this.menuCopy.Size = new System.Drawing.Size(159, 22);
            this.menuCopy.Text = "Copy";
            this.menuCopy.Click += new System.EventHandler(this.editCopy_Click);
            // 
            // menuPaste
            // 
            this.menuPaste.Image = global::LAZYSHELL.Properties.Resources.paste;
            this.menuPaste.Name = "menuPaste";
            this.menuPaste.Size = new System.Drawing.Size(159, 22);
            this.menuPaste.Text = "Paste";
            this.menuPaste.Click += new System.EventHandler(this.editPaste_Click);
            // 
            // menuDelete
            // 
            this.menuDelete.Image = global::LAZYSHELL.Properties.Resources.delete;
            this.menuDelete.Name = "menuDelete";
            this.menuDelete.Size = new System.Drawing.Size(159, 22);
            this.menuDelete.Text = "Delete";
            this.menuDelete.Click += new System.EventHandler(this.editDelete_Click);
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
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(156, 6);
            // 
            // menuSaveImage
            // 
            this.menuSaveImage.Image = global::LAZYSHELL.Properties.Resources.exportImage;
            this.menuSaveImage.Name = "menuSaveImage";
            this.menuSaveImage.Size = new System.Drawing.Size(159, 22);
            this.menuSaveImage.Text = "Save Image As...";
            this.menuSaveImage.Click += new System.EventHandler(this.saveImage_Click);
            // 
            // toolStrip2
            // 
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editSelect,
            this.toolStripSeparator5,
            this.editCut,
            this.editCopy,
            this.editPaste,
            this.editDelete,
            this.toolStripSeparator12,
            this.editMirror,
            this.editInvert,
            this.toolStripSeparator11,
            this.editUndo,
            this.editRedo});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(26, 260);
            this.toolStrip2.TabIndex = 2;
            // 
            // editSelect
            // 
            this.editSelect.CheckOnClick = true;
            this.editSelect.Image = global::LAZYSHELL.Properties.Resources.select;
            this.editSelect.Name = "editSelect";
            this.editSelect.Size = new System.Drawing.Size(23, 20);
            this.editSelect.ToolTipText = "Select (S)";
            this.editSelect.Click += new System.EventHandler(this.editSelect_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(23, 6);
            // 
            // editCut
            // 
            this.editCut.Image = global::LAZYSHELL.Properties.Resources.cut;
            this.editCut.Name = "editCut";
            this.editCut.Size = new System.Drawing.Size(23, 20);
            this.editCut.ToolTipText = "Cut (Ctrl+X)";
            this.editCut.Click += new System.EventHandler(this.editCut_Click);
            // 
            // editCopy
            // 
            this.editCopy.Image = global::LAZYSHELL.Properties.Resources.copy;
            this.editCopy.Name = "editCopy";
            this.editCopy.Size = new System.Drawing.Size(23, 20);
            this.editCopy.ToolTipText = "Copy (Ctrl+C)";
            this.editCopy.Click += new System.EventHandler(this.editCopy_Click);
            // 
            // editPaste
            // 
            this.editPaste.Image = global::LAZYSHELL.Properties.Resources.paste;
            this.editPaste.Name = "editPaste";
            this.editPaste.Size = new System.Drawing.Size(23, 20);
            this.editPaste.ToolTipText = "Paste (Ctrl+V)";
            this.editPaste.Click += new System.EventHandler(this.editPaste_Click);
            // 
            // editDelete
            // 
            this.editDelete.Image = global::LAZYSHELL.Properties.Resources.delete;
            this.editDelete.Name = "editDelete";
            this.editDelete.Size = new System.Drawing.Size(23, 20);
            this.editDelete.ToolTipText = "Delete (Del)";
            this.editDelete.Click += new System.EventHandler(this.editDelete_Click);
            // 
            // toolStripSeparator12
            // 
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            this.toolStripSeparator12.Size = new System.Drawing.Size(23, 6);
            // 
            // editMirror
            // 
            this.editMirror.Image = global::LAZYSHELL.Properties.Resources.mirror;
            this.editMirror.Name = "editMirror";
            this.editMirror.Size = new System.Drawing.Size(23, 20);
            this.editMirror.ToolTipText = "Mirror";
            this.editMirror.Click += new System.EventHandler(this.mirror_Click);
            // 
            // editInvert
            // 
            this.editInvert.Image = global::LAZYSHELL.Properties.Resources.flip;
            this.editInvert.Name = "editInvert";
            this.editInvert.Size = new System.Drawing.Size(23, 20);
            this.editInvert.ToolTipText = "Invert";
            this.editInvert.Click += new System.EventHandler(this.invert_Click);
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Margin = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(21, 6);
            // 
            // editUndo
            // 
            this.editUndo.Image = global::LAZYSHELL.Properties.Resources.undo;
            this.editUndo.Name = "editUndo";
            this.editUndo.Size = new System.Drawing.Size(23, 20);
            this.editUndo.ToolTipText = "Undo (Ctrl+Z)";
            this.editUndo.Click += new System.EventHandler(this.editUndo_Click);
            // 
            // editRedo
            // 
            this.editRedo.Image = global::LAZYSHELL.Properties.Resources.redo;
            this.editRedo.Name = "editRedo";
            this.editRedo.Size = new System.Drawing.Size(23, 20);
            this.editRedo.ToolTipText = "Redo (Ctrl+Y)";
            this.editRedo.Click += new System.EventHandler(this.editRedo_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.CanOverflow = false;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.name,
            this.toolStripSeparator3,
            this.toggleLocations,
            this.toggleBanner,
            this.toolStripSeparator1,
            this.toggleTileGrid,
            this.toggleBG,
            this.openTileEditor});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(286, 25);
            this.toolStrip1.TabIndex = 1;
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toggleLocations
            // 
            this.toggleLocations.CheckOnClick = true;
            this.toggleLocations.Image = global::LAZYSHELL.Properties.Resources.location;
            this.toggleLocations.Name = "toggleLocations";
            this.toggleLocations.Size = new System.Drawing.Size(23, 22);
            this.toggleLocations.ToolTipText = "Show Locations";
            this.toggleLocations.Click += new System.EventHandler(this.toggleLocations_Click);
            // 
            // toggleBanner
            // 
            this.toggleBanner.CheckOnClick = true;
            this.toggleBanner.Image = global::LAZYSHELL.Properties.Resources.mapBanner;
            this.toggleBanner.Name = "toggleBanner";
            this.toggleBanner.Size = new System.Drawing.Size(23, 22);
            this.toggleBanner.ToolTipText = "Show Banner";
            this.toggleBanner.Click += new System.EventHandler(this.toggleBanner_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
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
            // toggleBG
            // 
            this.toggleBG.Checked = true;
            this.toggleBG.CheckOnClick = true;
            this.toggleBG.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toggleBG.Name = "toggleBG";
            this.toggleBG.Size = new System.Drawing.Size(26, 22);
            this.toggleBG.Text = "BG";
            this.toggleBG.ToolTipText = "BG Color (B)";
            this.toggleBG.Click += new System.EventHandler(this.toggleBG_Click);
            // 
            // openTileEditor
            // 
            this.openTileEditor.Image = global::LAZYSHELL.Properties.Resources.openTileEditor;
            this.openTileEditor.Name = "openTileEditor";
            this.openTileEditor.Size = new System.Drawing.Size(23, 22);
            this.openTileEditor.ToolTipText = "Tile Editor";
            this.openTileEditor.Click += new System.EventHandler(this.openTileEditor_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.Active = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel26);
            this.panel1.Controls.Add(this.toolStrip2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(286, 260);
            this.panel1.TabIndex = 5;
            // 
            // headerLabel1
            // 
            this.headerLabel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerLabel1.Location = new System.Drawing.Point(0, 0);
            this.headerLabel1.Name = "headerLabel1";
            this.headerLabel1.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.headerLabel1.Size = new System.Drawing.Size(259, 14);
            this.headerLabel1.TabIndex = 448;
            this.headerLabel1.Text = "World Map Properties";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel2.Controls.Add(this.label46);
            this.panel2.Controls.Add(this.label21);
            this.panel2.Controls.Add(this.headerLabel1);
            this.panel2.Controls.Add(this.worldMapYCoord);
            this.panel2.Controls.Add(this.worldMapXCoord);
            this.panel2.Controls.Add(this.pointCount);
            this.panel2.Controls.Add(this.worldMapTileset);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Location = new System.Drawing.Point(26, 289);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(259, 59);
            this.panel2.TabIndex = 449;
            // 
            // WorldMapsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(286, 349);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.KeyPreview = true;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "WorldMapsForm";
            this.Text = "Tileset";
            this.TilesetForm = null;
            this.TilesetForms = new LAZYSHELL.TilesetForm[] {
        null};
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WorldMaps_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.worldMapYCoord)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.worldMapTileset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.worldMapXCoord)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pointCount)).EndInit();
            this.panel26.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picture)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.Panel panel26;
        private System.Windows.Forms.PictureBox picture;
        private System.Windows.Forms.NumericUpDown worldMapYCoord;
        private System.Windows.Forms.NumericUpDown worldMapTileset;
        private System.Windows.Forms.NumericUpDown worldMapXCoord;
        private System.Windows.Forms.NumericUpDown pointCount;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripComboBox name;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toggleLocations;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toggleTileGrid;
        private System.Windows.Forms.ToolStripButton toggleBG;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton editSelect;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton editDelete;
        private System.Windows.Forms.ToolStripButton editCopy;
        private System.Windows.Forms.ToolStripButton editCut;
        private System.Windows.Forms.ToolStripButton editPaste;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
        private System.Windows.Forms.ToolStripButton editUndo;
        private System.Windows.Forms.ToolStripButton editRedo;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuCut;
        private System.Windows.Forms.ToolStripMenuItem menuCopy;
        private System.Windows.Forms.ToolStripMenuItem menuPaste;
        private System.Windows.Forms.ToolStripMenuItem menuDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem menuMirror;
        private System.Windows.Forms.ToolStripMenuItem menuInvert;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem menuSaveImage;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStripButton toggleBanner;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator12;
        private System.Windows.Forms.ToolStripButton editMirror;
        private System.Windows.Forms.ToolStripButton editInvert;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripButton openTileEditor;
        private Controls.HeaderLabel headerLabel1;
        private System.Windows.Forms.Panel panel2;
    }
}