
namespace LAZYSHELL
{
    partial class TilesetForm
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
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuCut = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator27 = new System.Windows.Forms.ToolStripSeparator();
            this.menuP1Set = new System.Windows.Forms.ToolStripMenuItem();
            this.menuP1Clear = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMirror = new System.Windows.Forms.ToolStripMenuItem();
            this.menuInvert = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.menuSaveImageAs = new System.Windows.Forms.ToolStripMenuItem();
            this.menuImportImage = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toggleTileEditor = new System.Windows.Forms.ToolStripButton();
            this.toggleTileGrid = new System.Windows.Forms.ToolStripButton();
            this.toggleBG = new System.Windows.Forms.ToolStripButton();
            this.toggleP1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
            this.editDelete = new System.Windows.Forms.ToolStripButton();
            this.editCut = new System.Windows.Forms.ToolStripButton();
            this.editCopy = new System.Windows.Forms.ToolStripButton();
            this.editPaste = new System.Windows.Forms.ToolStripButton();
            this.editMirror = new System.Windows.Forms.ToolStripButton();
            this.editInvert = new System.Windows.Forms.ToolStripButton();
            this.buttonUndo = new System.Windows.Forms.ToolStripButton();
            this.buttonRedo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.pictureBoxTileset = new System.Windows.Forms.PictureBox();
            this.lockEditing = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.updateTilemap = new System.Windows.Forms.Button();
            this.autoUpdate = new System.Windows.Forms.CheckBox();
            this.labelTileIndex = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.contextMenuStrip.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTileset)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuCut,
            this.menuCopy,
            this.menuPaste,
            this.menuDelete,
            this.toolStripSeparator27,
            this.menuP1Set,
            this.menuP1Clear,
            this.menuMirror,
            this.menuInvert,
            this.toolStripSeparator3,
            this.menuSaveImageAs,
            this.menuImportImage});
            this.contextMenuStrip.Name = "contextMenuStrip2";
            this.contextMenuStrip.Size = new System.Drawing.Size(160, 236);
            this.contextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip_Opening);
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
            // toolStripSeparator27
            // 
            this.toolStripSeparator27.Name = "toolStripSeparator27";
            this.toolStripSeparator27.Size = new System.Drawing.Size(156, 6);
            // 
            // menuP1Set
            // 
            this.menuP1Set.Image = global::LAZYSHELL.Properties.Resources.priority1ON;
            this.menuP1Set.Name = "menuP1Set";
            this.menuP1Set.Size = new System.Drawing.Size(159, 22);
            this.menuP1Set.Text = "Priority 1 set";
            this.menuP1Set.Click += new System.EventHandler(this.menuP1Set_Click);
            // 
            // menuP1Clear
            // 
            this.menuP1Clear.Image = global::LAZYSHELL.Properties.Resources.priority1OFF;
            this.menuP1Clear.Name = "menuP1Clear";
            this.menuP1Clear.Size = new System.Drawing.Size(159, 22);
            this.menuP1Clear.Text = "Priority 1 clear";
            this.menuP1Clear.Click += new System.EventHandler(this.menuP1Clear_Click);
            // 
            // menuMirror
            // 
            this.menuMirror.Image = global::LAZYSHELL.Properties.Resources.mirror;
            this.menuMirror.Name = "menuMirror";
            this.menuMirror.Size = new System.Drawing.Size(159, 22);
            this.menuMirror.Text = "Mirror";
            this.menuMirror.Click += new System.EventHandler(this.menuMirror_Click);
            // 
            // menuInvert
            // 
            this.menuInvert.Image = global::LAZYSHELL.Properties.Resources.flip;
            this.menuInvert.Name = "menuInvert";
            this.menuInvert.Size = new System.Drawing.Size(159, 22);
            this.menuInvert.Text = "Invert";
            this.menuInvert.Click += new System.EventHandler(this.menuInvert_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(156, 6);
            // 
            // menuSaveImageAs
            // 
            this.menuSaveImageAs.Image = global::LAZYSHELL.Properties.Resources.exportImage;
            this.menuSaveImageAs.Name = "menuSaveImageAs";
            this.menuSaveImageAs.Size = new System.Drawing.Size(159, 22);
            this.menuSaveImageAs.Text = "Save Image As...";
            this.menuSaveImageAs.Click += new System.EventHandler(this.menuSaveImageAs_Click);
            // 
            // menuImportImage
            // 
            this.menuImportImage.Image = global::LAZYSHELL.Properties.Resources.importImage;
            this.menuImportImage.Name = "menuImportImage";
            this.menuImportImage.Size = new System.Drawing.Size(159, 22);
            this.menuImportImage.Text = "Import Image...";
            this.menuImportImage.Click += new System.EventHandler(this.menuImportImage_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toggleTileEditor,
            this.toggleTileGrid,
            this.toggleBG,
            this.toggleP1,
            this.toolStripSeparator13,
            this.editDelete,
            this.editCut,
            this.editCopy,
            this.editPaste,
            this.editMirror,
            this.editInvert,
            this.buttonUndo,
            this.buttonRedo,
            this.toolStripSeparator11});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(256, 25);
            this.toolStrip1.TabIndex = 0;
            // 
            // toggleTileEditor
            // 
            this.toggleTileEditor.Image = global::LAZYSHELL.Properties.Resources.openTileEditor;
            this.toggleTileEditor.Name = "toggleTileEditor";
            this.toggleTileEditor.Size = new System.Drawing.Size(23, 22);
            this.toggleTileEditor.ToolTipText = "Open Tile Editor";
            this.toggleTileEditor.Click += new System.EventHandler(this.toggleTileEditor_Click);
            // 
            // toggleTileGrid
            // 
            this.toggleTileGrid.CheckOnClick = true;
            this.toggleTileGrid.Image = global::LAZYSHELL.Properties.Resources.buttonToggleGrid;
            this.toggleTileGrid.Name = "toggleTileGrid";
            this.toggleTileGrid.Size = new System.Drawing.Size(23, 22);
            this.toggleTileGrid.ToolTipText = "Tile Grid";
            this.toggleTileGrid.Click += new System.EventHandler(this.toggleTileGrid_Click);
            // 
            // toggleBG
            // 
            this.toggleBG.CheckOnClick = true;
            this.toggleBG.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toggleBG.Name = "toggleBG";
            this.toggleBG.Size = new System.Drawing.Size(26, 22);
            this.toggleBG.Text = "BG";
            this.toggleBG.ToolTipText = "BG Color";
            this.toggleBG.Click += new System.EventHandler(this.toggleBG_Click);
            // 
            // toggleP1
            // 
            this.toggleP1.CheckOnClick = true;
            this.toggleP1.Image = global::LAZYSHELL.Properties.Resources.priority1ON;
            this.toggleP1.Name = "toggleP1";
            this.toggleP1.Size = new System.Drawing.Size(23, 22);
            this.toggleP1.ToolTipText = "Priority 1";
            this.toggleP1.Click += new System.EventHandler(this.toggleP1_Click);
            // 
            // toolStripSeparator13
            // 
            this.toolStripSeparator13.Margin = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStripSeparator13.Name = "toolStripSeparator13";
            this.toolStripSeparator13.Size = new System.Drawing.Size(6, 25);
            // 
            // editDelete
            // 
            this.editDelete.Enabled = false;
            this.editDelete.Image = global::LAZYSHELL.Properties.Resources.delete;
            this.editDelete.Name = "editDelete";
            this.editDelete.Size = new System.Drawing.Size(23, 22);
            this.editDelete.ToolTipText = "Delete";
            this.editDelete.Click += new System.EventHandler(this.editDelete_Click);
            // 
            // editCut
            // 
            this.editCut.Enabled = false;
            this.editCut.Image = global::LAZYSHELL.Properties.Resources.cut;
            this.editCut.Name = "editCut";
            this.editCut.Size = new System.Drawing.Size(23, 22);
            this.editCut.ToolTipText = "Cut";
            this.editCut.Click += new System.EventHandler(this.editCut_Click);
            // 
            // editCopy
            // 
            this.editCopy.Enabled = false;
            this.editCopy.Image = global::LAZYSHELL.Properties.Resources.copy;
            this.editCopy.Name = "editCopy";
            this.editCopy.Size = new System.Drawing.Size(23, 22);
            this.editCopy.ToolTipText = "Copy";
            this.editCopy.Click += new System.EventHandler(this.editCopy_Click);
            // 
            // editPaste
            // 
            this.editPaste.Enabled = false;
            this.editPaste.Image = global::LAZYSHELL.Properties.Resources.paste;
            this.editPaste.Name = "editPaste";
            this.editPaste.Size = new System.Drawing.Size(23, 22);
            this.editPaste.ToolTipText = "Paste";
            this.editPaste.Click += new System.EventHandler(this.editPaste_Click);
            // 
            // editMirror
            // 
            this.editMirror.Enabled = false;
            this.editMirror.Image = global::LAZYSHELL.Properties.Resources.mirror;
            this.editMirror.Name = "editMirror";
            this.editMirror.Size = new System.Drawing.Size(23, 22);
            this.editMirror.ToolTipText = "Mirror";
            this.editMirror.Click += new System.EventHandler(this.menuMirror_Click);
            // 
            // editInvert
            // 
            this.editInvert.Enabled = false;
            this.editInvert.Image = global::LAZYSHELL.Properties.Resources.flip;
            this.editInvert.Name = "editInvert";
            this.editInvert.Size = new System.Drawing.Size(23, 22);
            this.editInvert.ToolTipText = "Invert";
            this.editInvert.Click += new System.EventHandler(this.menuInvert_Click);
            // 
            // buttonUndo
            // 
            this.buttonUndo.Image = global::LAZYSHELL.Properties.Resources.undo;
            this.buttonUndo.Name = "buttonUndo";
            this.buttonUndo.Size = new System.Drawing.Size(23, 20);
            this.buttonUndo.ToolTipText = "Undo";
            this.buttonUndo.Visible = false;
            this.buttonUndo.Click += new System.EventHandler(this.editUndo_Click);
            // 
            // buttonRedo
            // 
            this.buttonRedo.Image = global::LAZYSHELL.Properties.Resources.redo;
            this.buttonRedo.Name = "buttonRedo";
            this.buttonRedo.Size = new System.Drawing.Size(23, 20);
            this.buttonRedo.ToolTipText = "Redo";
            this.buttonRedo.Visible = false;
            this.buttonRedo.Click += new System.EventHandler(this.editRedo_Click);
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Margin = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(6, 25);
            this.toolStripSeparator11.Visible = false;
            // 
            // pictureBoxTileset
            // 
            this.pictureBoxTileset.BackgroundImage = global::LAZYSHELL.Properties.Resources._transparent;
            this.pictureBoxTileset.ContextMenuStrip = this.contextMenuStrip;
            this.pictureBoxTileset.Cursor = System.Windows.Forms.Cursors.Cross;
            this.pictureBoxTileset.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxTileset.Name = "pictureBoxTileset";
            this.pictureBoxTileset.Size = new System.Drawing.Size(256, 512);
            this.pictureBoxTileset.TabIndex = 1;
            this.pictureBoxTileset.TabStop = false;
            this.pictureBoxTileset.Paint += new System.Windows.Forms.PaintEventHandler(this.picture_Paint);
            this.pictureBoxTileset.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picture_MouseDown);
            this.pictureBoxTileset.MouseEnter += new System.EventHandler(this.picture_MouseEnter);
            this.pictureBoxTileset.MouseLeave += new System.EventHandler(this.picture_MouseLeave);
            this.pictureBoxTileset.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picture_MouseMove);
            this.pictureBoxTileset.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picture_MouseUp);
            this.pictureBoxTileset.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.picture_PreviewKeyDown);
            // 
            // lockEditing
            // 
            this.lockEditing.AutoSize = true;
            this.lockEditing.Checked = true;
            this.lockEditing.CheckState = System.Windows.Forms.CheckState.Checked;
            this.lockEditing.Dock = System.Windows.Forms.DockStyle.Left;
            this.lockEditing.Location = new System.Drawing.Point(0, 0);
            this.lockEditing.Name = "lockEditing";
            this.lockEditing.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.lockEditing.Size = new System.Drawing.Size(117, 27);
            this.lockEditing.TabIndex = 0;
            this.lockEditing.Text = "Lock tileset editing";
            this.lockEditing.UseVisualStyleBackColor = true;
            this.lockEditing.CheckedChanged += new System.EventHandler(this.lockEditing_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.updateTilemap);
            this.panel1.Controls.Add(this.autoUpdate);
            this.panel1.Controls.Add(this.lockEditing);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 558);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(256, 27);
            this.panel1.TabIndex = 3;
            // 
            // updateTilemap
            // 
            this.updateTilemap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.updateTilemap.Location = new System.Drawing.Point(201, 0);
            this.updateTilemap.Name = "updateTilemap";
            this.updateTilemap.Size = new System.Drawing.Size(55, 27);
            this.updateTilemap.TabIndex = 2;
            this.updateTilemap.Text = "Update";
            this.updateTilemap.UseVisualStyleBackColor = true;
            this.updateTilemap.Click += new System.EventHandler(this.updateTilemap_Click);
            // 
            // autoUpdate
            // 
            this.autoUpdate.AutoSize = true;
            this.autoUpdate.Dock = System.Windows.Forms.DockStyle.Left;
            this.autoUpdate.Location = new System.Drawing.Point(117, 0);
            this.autoUpdate.Name = "autoUpdate";
            this.autoUpdate.Size = new System.Drawing.Size(84, 27);
            this.autoUpdate.TabIndex = 1;
            this.autoUpdate.Text = "Auto update";
            this.autoUpdate.UseVisualStyleBackColor = true;
            // 
            // labelTileIndex
            // 
            this.labelTileIndex.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelTileIndex.Location = new System.Drawing.Point(0, 25);
            this.labelTileIndex.Name = "labelTileIndex";
            this.labelTileIndex.Size = new System.Drawing.Size(256, 21);
            this.labelTileIndex.TabIndex = 1;
            this.labelTileIndex.Text = "Tile index: 0 ($00)";
            this.labelTileIndex.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = global::LAZYSHELL.Properties.Resources._canvas;
            this.panel2.Controls.Add(this.pictureBoxTileset);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 46);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(256, 512);
            this.panel2.TabIndex = 4;
            // 
            // TilesetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(256, 585);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.labelTileIndex);
            this.Controls.Add(this.toolStrip1);
            this.DockAreas = ((WeifenLuo.WinFormsUI.Docking.DockAreas)(((((WeifenLuo.WinFormsUI.Docking.DockAreas.Float | WeifenLuo.WinFormsUI.Docking.DockAreas.DockLeft) 
            | WeifenLuo.WinFormsUI.Docking.DockAreas.DockRight) 
            | WeifenLuo.WinFormsUI.Docking.DockAreas.DockTop) 
            | WeifenLuo.WinFormsUI.Docking.DockAreas.DockBottom)));
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "TilesetForm";
            this.Text = "TILESETS";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TilesetForm_FormClosed);
            this.VisibleChanged += new System.EventHandler(this.TilesetForm_VisibleChanged);
            this.contextMenuStrip.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTileset)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        private System.Windows.Forms.PictureBox pictureBoxTileset;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toggleTileGrid;
        private System.Windows.Forms.ToolStripButton toggleBG;
        private System.Windows.Forms.ToolStripButton toggleP1;
        private System.Windows.Forms.ToolStripButton editDelete;
        private System.Windows.Forms.ToolStripButton editCut;
        private System.Windows.Forms.ToolStripButton editCopy;
        private System.Windows.Forms.ToolStripButton editPaste;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
        private System.Windows.Forms.ToolStripButton buttonUndo;
        private System.Windows.Forms.ToolStripButton buttonRedo;
        private System.Windows.Forms.ToolStripButton toggleTileEditor;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem menuCopy;
        private System.Windows.Forms.ToolStripMenuItem menuPaste;
        private System.Windows.Forms.ToolStripMenuItem menuDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator27;
        private System.Windows.Forms.ToolStripMenuItem menuP1Set;
        private System.Windows.Forms.ToolStripMenuItem menuP1Clear;
        private System.Windows.Forms.ToolStripMenuItem menuSaveImageAs;
        private System.Windows.Forms.ToolStripMenuItem menuMirror;
        private System.Windows.Forms.ToolStripMenuItem menuInvert;
        private System.Windows.Forms.CheckBox lockEditing;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button updateTilemap;
        private System.Windows.Forms.CheckBox autoUpdate;
        private System.Windows.Forms.Label labelTileIndex;
        private System.Windows.Forms.ToolStripMenuItem menuImportImage;
        private System.Windows.Forms.ToolStripMenuItem menuCut;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator13;
        private System.Windows.Forms.ToolStripButton editMirror;
        private System.Windows.Forms.ToolStripButton editInvert;
        private System.Windows.Forms.Panel panel2;
    }
}