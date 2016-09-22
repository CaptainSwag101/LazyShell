namespace LazyShell.Minecart
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
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.save = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripDropDownButton3 = new System.Windows.Forms.ToolStripDropDownButton();
			this.importTilesets = new System.Windows.Forms.ToolStripMenuItem();
			this.importTilemaps = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripDropDownButton4 = new System.Windows.Forms.ToolStripDropDownButton();
			this.exportTilesets = new System.Windows.Forms.ToolStripMenuItem();
			this.exportTilemaps = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripDropDownButton5 = new System.Windows.Forms.ToolStripDropDownButton();
			this.resetAllObjects = new System.Windows.Forms.ToolStripMenuItem();
			this.resetCurrentTileset = new System.Windows.Forms.ToolStripMenuItem();
			this.resetCurrentTilemap = new System.Windows.Forms.ToolStripMenuItem();
			this.helpTips = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
			this.toggleScreens = new LazyShell.Controls.NewToolStripButton();
			this.toggleTilemap = new LazyShell.Controls.NewToolStripButton();
			this.toggleTileset = new LazyShell.Controls.NewToolStripButton();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
			this.openPalettesStage = new System.Windows.Forms.ToolStripMenuItem();
			this.openPalettesSprites = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
			this.openGraphicsStage = new System.Windows.Forms.ToolStripMenuItem();
			this.openGraphicsSprites = new System.Windows.Forms.ToolStripMenuItem();
			this.openPreviewer = new System.Windows.Forms.ToolStripButton();
			this.minecartAreaName = new System.Windows.Forms.ToolStripComboBox();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
			this.music = new System.Windows.Forms.ToolStripComboBox();
			this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
			this.dockPanel = new WeifenLuo.WinFormsUI.Docking.DockPanel();
			this.toolStrip2 = new System.Windows.Forms.ToolStrip();
			this.labelStartXY = new System.Windows.Forms.ToolStripLabel();
			this.startX = new LazyShell.Controls.NewToolStripNumericUpDown();
			this.startY = new LazyShell.Controls.NewToolStripNumericUpDown();
			this.toolStrip1.SuspendLayout();
			this.toolStrip2.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.save,
            this.toolStripSeparator2,
            this.toolStripDropDownButton3,
            this.toolStripDropDownButton4,
            this.toolStripDropDownButton5,
            this.helpTips,
            this.toolStripSeparator6,
            this.toggleScreens,
            this.toggleTilemap,
            this.toggleTileset,
            this.toolStripSeparator3,
            this.toolStripDropDownButton2,
            this.toolStripDropDownButton1,
            this.openPreviewer});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(1063, 25);
			this.toolStrip1.TabIndex = 1;
			// 
			// save
			// 
			this.save.Image = global::LazyShell.Properties.Resources.save;
			this.save.Name = "save";
			this.save.Size = new System.Drawing.Size(23, 22);
			this.save.ToolTipText = "Save";
			this.save.Click += new System.EventHandler(this.save_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
			// 
			// toolStripDropDownButton3
			// 
			this.toolStripDropDownButton3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importTilesets,
            this.importTilemaps});
			this.toolStripDropDownButton3.Image = global::LazyShell.Properties.Resources.importBinary;
			this.toolStripDropDownButton3.Name = "toolStripDropDownButton3";
			this.toolStripDropDownButton3.Size = new System.Drawing.Size(29, 22);
			// 
			// importTilesets
			// 
			this.importTilesets.Name = "importTilesets";
			this.importTilesets.Size = new System.Drawing.Size(178, 22);
			this.importTilesets.Text = "Import Tileset(s)...";
			this.importTilesets.Click += new System.EventHandler(this.importTilesets_Click);
			// 
			// importTilemaps
			// 
			this.importTilemaps.Name = "importTilemaps";
			this.importTilemaps.Size = new System.Drawing.Size(178, 22);
			this.importTilemaps.Text = "Import Tilemap(s)...";
			this.importTilemaps.Click += new System.EventHandler(this.importTilemaps_Click);
			// 
			// toolStripDropDownButton4
			// 
			this.toolStripDropDownButton4.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportTilesets,
            this.exportTilemaps});
			this.toolStripDropDownButton4.Image = global::LazyShell.Properties.Resources.exportBinary;
			this.toolStripDropDownButton4.Name = "toolStripDropDownButton4";
			this.toolStripDropDownButton4.Size = new System.Drawing.Size(29, 22);
			// 
			// exportTilesets
			// 
			this.exportTilesets.Name = "exportTilesets";
			this.exportTilesets.Size = new System.Drawing.Size(175, 22);
			this.exportTilesets.Text = "Export Tileset(s)...";
			this.exportTilesets.Click += new System.EventHandler(this.exportTilesets_Click);
			// 
			// exportTilemaps
			// 
			this.exportTilemaps.Name = "exportTilemaps";
			this.exportTilemaps.Size = new System.Drawing.Size(175, 22);
			this.exportTilemaps.Text = "Export Tilemap(s)...";
			this.exportTilemaps.Click += new System.EventHandler(this.exportTilemaps_Click);
			// 
			// toolStripDropDownButton5
			// 
			this.toolStripDropDownButton5.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.resetAllObjects,
            this.resetCurrentTileset,
            this.resetCurrentTilemap});
			this.toolStripDropDownButton5.Image = global::LazyShell.Properties.Resources.reset;
			this.toolStripDropDownButton5.Name = "toolStripDropDownButton5";
			this.toolStripDropDownButton5.Size = new System.Drawing.Size(29, 22);
			// 
			// resetAllObjects
			// 
			this.resetAllObjects.Name = "resetAllObjects";
			this.resetAllObjects.Size = new System.Drawing.Size(186, 22);
			this.resetAllObjects.Text = "Reset all objects";
			this.resetAllObjects.Click += new System.EventHandler(this.resetAllObjects_Click);
			// 
			// resetCurrentTileset
			// 
			this.resetCurrentTileset.Name = "resetCurrentTileset";
			this.resetCurrentTileset.Size = new System.Drawing.Size(186, 22);
			this.resetCurrentTileset.Text = "Reset current tileset";
			this.resetCurrentTileset.Click += new System.EventHandler(this.resetCurrentTileset_Click);
			// 
			// resetCurrentTilemap
			// 
			this.resetCurrentTilemap.Name = "resetCurrentTilemap";
			this.resetCurrentTilemap.Size = new System.Drawing.Size(186, 22);
			this.resetCurrentTilemap.Text = "Reset current tilemap";
			this.resetCurrentTilemap.Click += new System.EventHandler(this.resetCurrentTilemap_Click);
			// 
			// helpTips
			// 
			this.helpTips.CheckOnClick = true;
			this.helpTips.Image = global::LazyShell.Properties.Resources.help;
			this.helpTips.Name = "helpTips";
			this.helpTips.Size = new System.Drawing.Size(23, 22);
			this.helpTips.ToolTipText = "Help Tips";
			// 
			// toolStripSeparator6
			// 
			this.toolStripSeparator6.Name = "toolStripSeparator6";
			this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
			// 
			// toggleScreens
			// 
			this.toggleScreens.CheckOnClick = true;
			this.toggleScreens.Form = null;
			this.toggleScreens.Image = global::LazyShell.Properties.Resources.toggleScreens;
			this.toggleScreens.Name = "toggleScreens";
			this.toggleScreens.Size = new System.Drawing.Size(23, 22);
			this.toggleScreens.ToolTipText = "Screens Window";
			// 
			// toggleTilemap
			// 
			this.toggleTilemap.CheckOnClick = true;
			this.toggleTilemap.Form = null;
			this.toggleTilemap.Image = global::LazyShell.Properties.Resources.openMap;
			this.toggleTilemap.Name = "toggleTilemap";
			this.toggleTilemap.Size = new System.Drawing.Size(23, 22);
			this.toggleTilemap.ToolTipText = "Tilemap Window";
			// 
			// toggleTileset
			// 
			this.toggleTileset.CheckOnClick = true;
			this.toggleTileset.Form = null;
			this.toggleTileset.Image = global::LazyShell.Properties.Resources.toggleTilesetL1;
			this.toggleTileset.Name = "toggleTileset";
			this.toggleTileset.Size = new System.Drawing.Size(23, 22);
			this.toggleTileset.ToolTipText = "Tileset Window";
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
			// 
			// toolStripDropDownButton2
			// 
			this.toolStripDropDownButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openPalettesStage,
            this.openPalettesSprites});
			this.toolStripDropDownButton2.Image = global::LazyShell.Properties.Resources.openPalettes;
			this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
			this.toolStripDropDownButton2.Size = new System.Drawing.Size(29, 22);
			// 
			// openPalettesStage
			// 
			this.openPalettesStage.Name = "openPalettesStage";
			this.openPalettesStage.Size = new System.Drawing.Size(148, 22);
			this.openPalettesStage.Text = "Stage Palettes";
			this.openPalettesStage.Click += new System.EventHandler(this.openPalettesStage_Click);
			// 
			// openPalettesSprites
			// 
			this.openPalettesSprites.Name = "openPalettesSprites";
			this.openPalettesSprites.Size = new System.Drawing.Size(148, 22);
			this.openPalettesSprites.Text = "Sprite Palettes";
			this.openPalettesSprites.Click += new System.EventHandler(this.openPalettesSprites_Click);
			// 
			// toolStripDropDownButton1
			// 
			this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openGraphicsStage,
            this.openGraphicsSprites});
			this.toolStripDropDownButton1.Image = global::LazyShell.Properties.Resources.openGraphics;
			this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
			this.toolStripDropDownButton1.Size = new System.Drawing.Size(29, 22);
			// 
			// openGraphicsStage
			// 
			this.openGraphicsStage.Name = "openGraphicsStage";
			this.openGraphicsStage.Size = new System.Drawing.Size(153, 22);
			this.openGraphicsStage.Text = "Stage Graphics";
			this.openGraphicsStage.Click += new System.EventHandler(this.openGraphicsStage_Click);
			// 
			// openGraphicsSprites
			// 
			this.openGraphicsSprites.Name = "openGraphicsSprites";
			this.openGraphicsSprites.Size = new System.Drawing.Size(153, 22);
			this.openGraphicsSprites.Text = "Sprite Graphics";
			this.openGraphicsSprites.Click += new System.EventHandler(this.openGraphicsSprites_Click);
			// 
			// openPreviewer
			// 
			this.openPreviewer.Image = global::LazyShell.Properties.Resources.preview;
			this.openPreviewer.Name = "openPreviewer";
			this.openPreviewer.Size = new System.Drawing.Size(23, 22);
			this.openPreviewer.ToolTipText = "Previewer";
			this.openPreviewer.Click += new System.EventHandler(this.openPreviewer_Click);
			// 
			// minecartAreaName
			// 
			this.minecartAreaName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.minecartAreaName.IntegralHeight = false;
			this.minecartAreaName.Items.AddRange(new object[] {
            "Mode7, Map A",
            "Mode7, Map B",
            "Side-scroller, Map A",
            "Side-scroller, Map B"});
			this.minecartAreaName.Name = "minecartAreaName";
			this.minecartAreaName.Size = new System.Drawing.Size(160, 25);
			this.minecartAreaName.SelectedIndexChanged += new System.EventHandler(this.name_SelectedIndexChanged);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// toolStripLabel1
			// 
			this.toolStripLabel1.Name = "toolStripLabel1";
			this.toolStripLabel1.Size = new System.Drawing.Size(45, 22);
			this.toolStripLabel1.Text = " Music ";
			// 
			// music
			// 
			this.music.DropDownHeight = 400;
			this.music.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.music.DropDownWidth = 300;
			this.music.IntegralHeight = false;
			this.music.Name = "music";
			this.music.Size = new System.Drawing.Size(160, 25);
			this.music.SelectedIndexChanged += new System.EventHandler(this.music_SelectedIndexChanged);
			// 
			// toolStripSeparator5
			// 
			this.toolStripSeparator5.Name = "toolStripSeparator5";
			this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
			// 
			// dockPanel
			// 
			this.dockPanel.BackColor = System.Drawing.SystemColors.ControlDark;
			this.dockPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dockPanel.DockBottomPortion = 0.5D;
			this.dockPanel.DockTopPortion = 0.5D;
			this.dockPanel.Location = new System.Drawing.Point(0, 50);
			this.dockPanel.Name = "dockPanel";
			this.dockPanel.Size = new System.Drawing.Size(1063, 643);
			this.dockPanel.TabIndex = 3;
			// 
			// toolStrip2
			// 
			this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.minecartAreaName,
            this.toolStripSeparator1,
            this.toolStripLabel1,
            this.music,
            this.toolStripSeparator5,
            this.labelStartXY,
            this.startX,
            this.startY});
			this.toolStrip2.Location = new System.Drawing.Point(0, 25);
			this.toolStrip2.Name = "toolStrip2";
			this.toolStrip2.Size = new System.Drawing.Size(1063, 25);
			this.toolStrip2.TabIndex = 6;
			this.toolStrip2.Text = "toolStrip2";
			// 
			// labelStartXY
			// 
			this.labelStartXY.Name = "labelStartXY";
			this.labelStartXY.Size = new System.Drawing.Size(62, 22);
			this.labelStartXY.Text = "Start (X,Y) ";
			// 
			// startX
			// 
			this.startX.AutoSize = false;
			this.startX.ContextMenuStrip = null;
			this.startX.Hexadecimal = false;
			this.startX.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.startX.Location = new System.Drawing.Point(452, 1);
			this.startX.Maximum = new decimal(new int[] {
            1023,
            0,
            0,
            0});
			this.startX.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
			this.startX.Name = "startX";
			this.startX.Size = new System.Drawing.Size(60, 21);
			this.startX.Text = "0";
			this.startX.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
			// 
			// startY
			// 
			this.startY.AutoSize = false;
			this.startY.ContextMenuStrip = null;
			this.startY.Hexadecimal = false;
			this.startY.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.startY.Location = new System.Drawing.Point(512, 1);
			this.startY.Maximum = new decimal(new int[] {
            1023,
            0,
            0,
            0});
			this.startY.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
			this.startY.Name = "startY";
			this.startY.Size = new System.Drawing.Size(60, 21);
			this.startY.Text = "0";
			this.startY.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
			// 
			// OwnerForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1063, 693);
			this.Controls.Add(this.dockPanel);
			this.Controls.Add(this.toolStrip2);
			this.Controls.Add(this.toolStrip1);
			this.IsMdiContainer = true;
			this.Location = new System.Drawing.Point(0, 0);
			this.Name = "OwnerForm";
			this.Text = "Minecart Minigame - Lazy Shell";
			this.TilesetForms = new LazyShell.TilesetForm[] {
        null};
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OwnerForm_FormClosing);
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.toolStrip2.ResumeLayout(false);
			this.toolStrip2.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton save;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton3;
        private System.Windows.Forms.ToolStripMenuItem importTilesets;
        private System.Windows.Forms.ToolStripMenuItem importTilemaps;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton4;
        private System.Windows.Forms.ToolStripMenuItem exportTilesets;
        private System.Windows.Forms.ToolStripMenuItem exportTilemaps;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton5;
        private System.Windows.Forms.ToolStripMenuItem resetAllObjects;
        private System.Windows.Forms.ToolStripMenuItem resetCurrentTileset;
        private System.Windows.Forms.ToolStripMenuItem resetCurrentTilemap;
        private System.Windows.Forms.ToolStripButton helpTips;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripComboBox minecartAreaName;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox music;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton2;
        private System.Windows.Forms.ToolStripMenuItem openPalettesStage;
        private System.Windows.Forms.ToolStripMenuItem openPalettesSprites;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem openGraphicsStage;
        private System.Windows.Forms.ToolStripMenuItem openGraphicsSprites;
        private System.Windows.Forms.ToolStripButton openPreviewer;
        private WeifenLuo.WinFormsUI.Docking.DockPanel dockPanel;
        private Controls.NewToolStripButton toggleScreens;
        private Controls.NewToolStripButton toggleTilemap;
        private Controls.NewToolStripButton toggleTileset;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripLabel labelStartXY;
        private Controls.NewToolStripNumericUpDown startX;
        private Controls.NewToolStripNumericUpDown startY;
    }
}