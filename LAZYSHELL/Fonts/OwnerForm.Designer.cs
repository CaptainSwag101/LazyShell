
namespace LazyShell.Fonts
{
    partial class OwnerForm
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
			this.panel30 = new System.Windows.Forms.Panel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel4 = new System.Windows.Forms.Panel();
			this.picture = new System.Windows.Forms.PictureBox();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.import = new System.Windows.Forms.ToolStripMenuItem();
			this.export = new System.Windows.Forms.ToolStripMenuItem();
			this.saveImageAs = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
			this.insertIntoText = new System.Windows.Forms.ToolStripMenuItem();
			this.insertIntoBattleDialogueText = new System.Windows.Forms.ToolStripMenuItem();
			this.fontTable = new LazyShell.Controls.NewPanel();
			this.toolStrip2 = new System.Windows.Forms.ToolStrip();
			this.reset = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
			this.fontWidth = new LazyShell.Controls.NewToolStripNumericUpDown();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.toggleTileGrid = new System.Windows.Forms.ToolStripButton();
			this.toggleFontBorder = new System.Windows.Forms.ToolStripButton();
			this.toggleKeystrokes = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.zoomIn = new System.Windows.Forms.ToolStripButton();
			this.zoomOut = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.indexLabel = new System.Windows.Forms.ToolStripLabel();
			this.toolStrip7 = new System.Windows.Forms.ToolStrip();
			this.save = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.fontType = new System.Windows.Forms.ToolStripComboBox();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.openNewFontTable = new System.Windows.Forms.ToolStripButton();
			this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
			this.openGraphicsNumerals = new System.Windows.Forms.ToolStripMenuItem();
			this.openGraphicsBattleMenu = new System.Windows.Forms.ToolStripMenuItem();
			this.openPalettesNumerals = new System.Windows.Forms.ToolStripMenuItem();
			this.openPalettesBattleMenu = new System.Windows.Forms.ToolStripMenuItem();
			this.panel30.SuspendLayout();
			this.panel1.SuspendLayout();
			this.panel4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.picture)).BeginInit();
			this.contextMenuStrip1.SuspendLayout();
			this.toolStrip2.SuspendLayout();
			this.toolStrip1.SuspendLayout();
			this.toolStrip7.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel30
			// 
			this.panel30.Controls.Add(this.panel1);
			this.panel30.Controls.Add(this.toolStrip7);
			this.panel30.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel30.Location = new System.Drawing.Point(0, 0);
			this.panel30.Name = "panel30";
			this.panel30.Size = new System.Drawing.Size(313, 507);
			this.panel30.TabIndex = 0;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.panel4);
			this.panel1.Controls.Add(this.toolStrip2);
			this.panel1.Controls.Add(this.toolStrip1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 25);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(313, 482);
			this.panel1.TabIndex = 449;
			// 
			// panel4
			// 
			this.panel4.AutoScroll = true;
			this.panel4.BackColor = System.Drawing.SystemColors.ControlDark;
			this.panel4.Controls.Add(this.picture);
			this.panel4.Controls.Add(this.fontTable);
			this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel4.Location = new System.Drawing.Point(0, 25);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(313, 432);
			this.panel4.TabIndex = 448;
			// 
			// picture
			// 
			this.picture.BackgroundImage = global::LazyShell.Properties.Resources._transparent;
			this.picture.ContextMenuStrip = this.contextMenuStrip1;
			this.picture.Location = new System.Drawing.Point(0, 0);
			this.picture.Name = "picture";
			this.picture.Size = new System.Drawing.Size(128, 192);
			this.picture.TabIndex = 447;
			this.picture.TabStop = false;
			this.picture.Paint += new System.Windows.Forms.PaintEventHandler(this.picture_Paint);
			this.picture.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picture_MouseDown);
			this.picture.MouseLeave += new System.EventHandler(this.picture_MouseLeave);
			this.picture.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picture_MouseMove);
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.import,
            this.export,
            this.saveImageAs,
            this.toolStripSeparator5,
            this.insertIntoText,
            this.insertIntoBattleDialogueText});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(210, 120);
			this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
			// 
			// import
			// 
			this.import.Image = global::LazyShell.Properties.Resources.importImage;
			this.import.Name = "import";
			this.import.Size = new System.Drawing.Size(209, 22);
			this.import.Text = "Import...";
			this.import.Click += new System.EventHandler(this.import_Click);
			// 
			// export
			// 
			this.export.Image = global::LazyShell.Properties.Resources.exportBinary;
			this.export.Name = "export";
			this.export.Size = new System.Drawing.Size(209, 22);
			this.export.Text = "Export...";
			this.export.Click += new System.EventHandler(this.export_Click);
			// 
			// saveImageAs
			// 
			this.saveImageAs.Image = global::LazyShell.Properties.Resources.exportImage;
			this.saveImageAs.Name = "saveImageAs";
			this.saveImageAs.Size = new System.Drawing.Size(209, 22);
			this.saveImageAs.Text = "Save Image As...";
			this.saveImageAs.Click += new System.EventHandler(this.saveImageAs_Click);
			// 
			// toolStripSeparator5
			// 
			this.toolStripSeparator5.Name = "toolStripSeparator5";
			this.toolStripSeparator5.Size = new System.Drawing.Size(206, 6);
			// 
			// insertIntoText
			// 
			this.insertIntoText.Image = global::LazyShell.Properties.Resources.notepad;
			this.insertIntoText.Name = "insertIntoText";
			this.insertIntoText.Size = new System.Drawing.Size(209, 22);
			this.insertIntoText.Text = "Insert into dialogue";
			this.insertIntoText.Click += new System.EventHandler(this.insertIntoText_Click);
			// 
			// insertIntoBattleDialogueText
			// 
			this.insertIntoBattleDialogueText.Image = global::LazyShell.Properties.Resources.notepad;
			this.insertIntoBattleDialogueText.Name = "insertIntoBattleDialogueText";
			this.insertIntoBattleDialogueText.Size = new System.Drawing.Size(209, 22);
			this.insertIntoBattleDialogueText.Text = "Insert into battle dialogue";
			this.insertIntoBattleDialogueText.Click += new System.EventHandler(this.insertIntoBattleDialogueText_Click);
			// 
			// fontTable
			// 
			this.fontTable.Location = new System.Drawing.Point(0, 0);
			this.fontTable.Name = "fontTable";
			this.fontTable.Size = new System.Drawing.Size(128, 192);
			this.fontTable.TabIndex = 448;
			this.fontTable.Visible = false;
			// 
			// toolStrip2
			// 
			this.toolStrip2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reset,
            this.toolStripSeparator6,
            this.toolStripLabel3,
            this.fontWidth});
			this.toolStrip2.Location = new System.Drawing.Point(0, 457);
			this.toolStrip2.Name = "toolStrip2";
			this.toolStrip2.Size = new System.Drawing.Size(313, 25);
			this.toolStrip2.TabIndex = 449;
			// 
			// reset
			// 
			this.reset.Image = global::LazyShell.Properties.Resources.reset;
			this.reset.Name = "reset";
			this.reset.Size = new System.Drawing.Size(23, 22);
			this.reset.ToolTipText = "Reset Glyph";
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
			this.toolStripLabel3.Size = new System.Drawing.Size(45, 22);
			this.toolStripLabel3.Text = " Width ";
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
			this.fontWidth.Location = new System.Drawing.Point(83, 2);
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
			this.fontWidth.Size = new System.Drawing.Size(50, 21);
			this.fontWidth.Text = "0";
			this.fontWidth.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
			this.fontWidth.ValueChanged += new System.EventHandler(this.fontWidth_ValueChanged);
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toggleTileGrid,
            this.toggleFontBorder,
            this.toggleKeystrokes,
            this.toolStripSeparator2,
            this.zoomIn,
            this.zoomOut,
            this.toolStripSeparator1,
            this.indexLabel});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(313, 25);
			this.toolStrip1.TabIndex = 0;
			// 
			// toggleTileGrid
			// 
			this.toggleTileGrid.CheckOnClick = true;
			this.toggleTileGrid.Image = global::LazyShell.Properties.Resources.buttonToggleGrid;
			this.toggleTileGrid.Name = "toggleTileGrid";
			this.toggleTileGrid.Size = new System.Drawing.Size(23, 22);
			this.toggleTileGrid.ToolTipText = "Letter Grid";
			this.toggleTileGrid.Click += new System.EventHandler(this.toggleTileGrid_Click);
			// 
			// toggleFontBorder
			// 
			this.toggleFontBorder.CheckOnClick = true;
			this.toggleFontBorder.Image = global::LazyShell.Properties.Resources.toggleFontBorder;
			this.toggleFontBorder.Name = "toggleFontBorder";
			this.toggleFontBorder.Size = new System.Drawing.Size(23, 22);
			this.toggleFontBorder.ToolTipText = "Show/hide font border";
			this.toggleFontBorder.Click += new System.EventHandler(this.toggleFontBorder_Click);
			// 
			// toggleKeystrokes
			// 
			this.toggleKeystrokes.CheckOnClick = true;
			this.toggleKeystrokes.Image = global::LazyShell.Properties.Resources.keystrokes;
			this.toggleKeystrokes.Name = "toggleKeystrokes";
			this.toggleKeystrokes.Size = new System.Drawing.Size(23, 22);
			this.toggleKeystrokes.ToolTipText = "Show/hide keystrokes";
			this.toggleKeystrokes.CheckedChanged += new System.EventHandler(this.toggleKeystrokes_CheckedChanged);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
			// 
			// zoomIn
			// 
			this.zoomIn.Image = global::LazyShell.Properties.Resources.zoomin;
			this.zoomIn.Name = "zoomIn";
			this.zoomIn.Size = new System.Drawing.Size(23, 22);
			this.zoomIn.ToolTipText = "Zoom In";
			this.zoomIn.Click += new System.EventHandler(this.zoomIn_Click);
			// 
			// zoomOut
			// 
			this.zoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.zoomOut.Image = global::LazyShell.Properties.Resources.zoomout;
			this.zoomOut.Name = "zoomOut";
			this.zoomOut.Size = new System.Drawing.Size(23, 22);
			this.zoomOut.ToolTipText = "Zoom Out";
			this.zoomOut.Click += new System.EventHandler(this.zoomOut_Click);
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
			// toolStrip7
			// 
			this.toolStrip7.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.save,
            this.toolStripSeparator3,
            this.fontType,
            this.toolStripSeparator4,
            this.openNewFontTable,
            this.toolStripDropDownButton1});
			this.toolStrip7.Location = new System.Drawing.Point(0, 0);
			this.toolStrip7.Name = "toolStrip7";
			this.toolStrip7.Size = new System.Drawing.Size(313, 25);
			this.toolStrip7.TabIndex = 0;
			this.toolStrip7.TabStop = true;
			// 
			// save
			// 
			this.save.Image = global::LazyShell.Properties.Resources.save;
			this.save.Name = "save";
			this.save.Size = new System.Drawing.Size(23, 22);
			this.save.ToolTipText = "Save";
			this.save.Click += new System.EventHandler(this.save_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
			// 
			// fontType
			// 
			this.fontType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
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
			this.openNewFontTable.Image = global::LazyShell.Properties.Resources.openNewFontTable;
			this.openNewFontTable.Name = "openNewFontTable";
			this.openNewFontTable.Size = new System.Drawing.Size(23, 22);
			this.openNewFontTable.ToolTipText = "New Font Table";
			this.openNewFontTable.Click += new System.EventHandler(this.openNewFontTable_Click);
			// 
			// toolStripDropDownButton1
			// 
			this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openGraphicsNumerals,
            this.openGraphicsBattleMenu,
            this.openPalettesNumerals,
            this.openPalettesBattleMenu});
			this.toolStripDropDownButton1.Image = global::LazyShell.Properties.Resources.numerals;
			this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
			this.toolStripDropDownButton1.Size = new System.Drawing.Size(29, 22);
			this.toolStripDropDownButton1.ToolTipText = "Battle Numerals";
			// 
			// openGraphicsNumerals
			// 
			this.openGraphicsNumerals.Image = global::LazyShell.Properties.Resources.openGraphics;
			this.openGraphicsNumerals.Name = "openGraphicsNumerals";
			this.openGraphicsNumerals.Size = new System.Drawing.Size(187, 22);
			this.openGraphicsNumerals.Text = "Numeral Graphics";
			this.openGraphicsNumerals.Click += new System.EventHandler(this.openGraphicsNumerals_Click);
			// 
			// openGraphicsBattleMenu
			// 
			this.openGraphicsBattleMenu.Image = global::LazyShell.Properties.Resources.openGraphics;
			this.openGraphicsBattleMenu.Name = "openGraphicsBattleMenu";
			this.openGraphicsBattleMenu.Size = new System.Drawing.Size(187, 22);
			this.openGraphicsBattleMenu.Text = "Battle Menu Graphics";
			this.openGraphicsBattleMenu.Click += new System.EventHandler(this.openGraphicsBattleMenu_Click);
			// 
			// openPalettesNumerals
			// 
			this.openPalettesNumerals.Image = global::LazyShell.Properties.Resources.openPalettes;
			this.openPalettesNumerals.Name = "openPalettesNumerals";
			this.openPalettesNumerals.Size = new System.Drawing.Size(187, 22);
			this.openPalettesNumerals.Text = "Numeral Palettes";
			this.openPalettesNumerals.Click += new System.EventHandler(this.openPalettesNumerals_Click);
			// 
			// openPalettesBattleMenu
			// 
			this.openPalettesBattleMenu.Image = global::LazyShell.Properties.Resources.openPalettes;
			this.openPalettesBattleMenu.Name = "openPalettesBattleMenu";
			this.openPalettesBattleMenu.Size = new System.Drawing.Size(187, 22);
			this.openPalettesBattleMenu.Text = "Battle Menu Palettes";
			this.openPalettesBattleMenu.Click += new System.EventHandler(this.openPalettesBattleMenu_Click);
			// 
			// OwnerForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(313, 527);
			this.Controls.Add(this.panel30);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.Location = new System.Drawing.Point(0, 0);
			this.MinimizeBox = false;
			this.Name = "OwnerForm";
			this.Padding = new System.Windows.Forms.Padding(0, 0, 0, 20);
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
			this.Text = "Fonts - Lazy Shell";
			this.panel30.ResumeLayout(false);
			this.panel30.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel4.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.picture)).EndInit();
			this.contextMenuStrip1.ResumeLayout(false);
			this.toolStrip2.ResumeLayout(false);
			this.toolStrip2.PerformLayout();
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.toolStrip7.ResumeLayout(false);
			this.toolStrip7.PerformLayout();
			this.ResumeLayout(false);

        }
        #endregion
        private System.Windows.Forms.Panel panel30;
        private System.Windows.Forms.PictureBox picture;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStrip toolStrip7;
        private System.Windows.Forms.ToolStripComboBox fontType;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton openNewFontTable;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem import;
        private System.Windows.Forms.ToolStripMenuItem export;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem insertIntoText;
        private System.Windows.Forms.ToolStripMenuItem saveImageAs;
        private System.Windows.Forms.ToolStripMenuItem insertIntoBattleDialogueText;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem openGraphicsNumerals;
        private System.Windows.Forms.ToolStripMenuItem openPalettesNumerals;
        private System.Windows.Forms.ToolStripMenuItem openGraphicsBattleMenu;
        private System.Windows.Forms.ToolStripMenuItem openPalettesBattleMenu;
        private System.Windows.Forms.Panel panel4;
        private Controls.NewPanel fontTable;
        private System.Windows.Forms.ToolStripLabel indexLabel;
        private System.Windows.Forms.ToolStripButton toggleKeystrokes;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toggleTileGrid;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton reset;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private Controls.NewToolStripNumericUpDown fontWidth;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton zoomIn;
        private System.Windows.Forms.ToolStripButton zoomOut;
        private System.Windows.Forms.ToolStripButton toggleFontBorder;
        private System.Windows.Forms.ToolStripButton save;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    }
}