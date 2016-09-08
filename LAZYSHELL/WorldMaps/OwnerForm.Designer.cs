namespace LazyShell.WorldMaps
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
			this.toolStrip3 = new System.Windows.Forms.ToolStrip();
			this.save = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.import = new System.Windows.Forms.ToolStripButton();
			this.export = new System.Windows.Forms.ToolStripButton();
			this.clear = new System.Windows.Forms.ToolStripButton();
			this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
			this.resetWorldMap = new System.Windows.Forms.ToolStripMenuItem();
			this.resetLocation = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
			this.helpTips = new System.Windows.Forms.ToolStripButton();
			this.baseConvertor = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
			this.openPalettesWorldMaps = new System.Windows.Forms.ToolStripMenuItem();
			this.openPalettesLogos = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripDropDownButton3 = new System.Windows.Forms.ToolStripDropDownButton();
			this.openGraphicsWorldMaps = new System.Windows.Forms.ToolStripMenuItem();
			this.openGraphicsLogos = new System.Windows.Forms.ToolStripMenuItem();
			this.openGraphicsSprites = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
			this.music = new System.Windows.Forms.ToolStripComboBox();
			this.dockPanel = new WeifenLuo.WinFormsUI.Docking.DockPanel();
			this.toolStrip3.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolStrip3
			// 
			this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.save,
            this.toolStripSeparator4,
            this.import,
            this.export,
            this.clear,
            this.toolStripDropDownButton1,
            this.toolStripSeparator8,
            this.helpTips,
            this.baseConvertor,
            this.toolStripSeparator10,
            this.toolStripDropDownButton2,
            this.toolStripDropDownButton3,
            this.toolStripSeparator1,
            this.toolStripLabel1,
            this.music});
			this.toolStrip3.Location = new System.Drawing.Point(0, 0);
			this.toolStrip3.Name = "toolStrip3";
			this.toolStrip3.Size = new System.Drawing.Size(573, 25);
			this.toolStrip3.TabIndex = 1;
			// 
			// save
			// 
			this.save.Image = global::LazyShell.Properties.Resources.save;
			this.save.Name = "save";
			this.save.Size = new System.Drawing.Size(23, 22);
			this.save.ToolTipText = "Save";
			this.save.Click += new System.EventHandler(this.save_Click);
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
			// 
			// import
			// 
			this.import.Image = global::LazyShell.Properties.Resources.importData;
			this.import.Name = "import";
			this.import.Size = new System.Drawing.Size(23, 22);
			this.import.ToolTipText = "Import";
			this.import.Click += new System.EventHandler(this.import_Click);
			// 
			// export
			// 
			this.export.Image = global::LazyShell.Properties.Resources.exportData;
			this.export.Name = "export";
			this.export.Size = new System.Drawing.Size(23, 22);
			this.export.ToolTipText = "Export";
			this.export.Click += new System.EventHandler(this.export_Click);
			// 
			// clear
			// 
			this.clear.Image = global::LazyShell.Properties.Resources.clear;
			this.clear.Name = "clear";
			this.clear.Size = new System.Drawing.Size(23, 22);
			this.clear.ToolTipText = "Clear";
			this.clear.Click += new System.EventHandler(this.clear_Click);
			// 
			// toolStripDropDownButton1
			// 
			this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.resetWorldMap,
            this.resetLocation});
			this.toolStripDropDownButton1.Image = global::LazyShell.Properties.Resources.reset;
			this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
			this.toolStripDropDownButton1.Size = new System.Drawing.Size(29, 22);
			// 
			// resetWorldMap
			// 
			this.resetWorldMap.Name = "resetWorldMap";
			this.resetWorldMap.Size = new System.Drawing.Size(162, 22);
			this.resetWorldMap.Text = "Reset world map";
			this.resetWorldMap.Click += new System.EventHandler(this.resetWorldMap_Click);
			// 
			// resetLocation
			// 
			this.resetLocation.Name = "resetLocation";
			this.resetLocation.Size = new System.Drawing.Size(162, 22);
			this.resetLocation.Text = "Reset location";
			this.resetLocation.Click += new System.EventHandler(this.resetLocation_Click);
			// 
			// toolStripSeparator8
			// 
			this.toolStripSeparator8.Name = "toolStripSeparator8";
			this.toolStripSeparator8.Size = new System.Drawing.Size(6, 25);
			// 
			// helpTips
			// 
			this.helpTips.CheckOnClick = true;
			this.helpTips.Image = global::LazyShell.Properties.Resources.help;
			this.helpTips.Name = "helpTips";
			this.helpTips.Size = new System.Drawing.Size(23, 22);
			this.helpTips.ToolTipText = "Help Tips";
			// 
			// baseConvertor
			// 
			this.baseConvertor.CheckOnClick = true;
			this.baseConvertor.Image = global::LazyShell.Properties.Resources.baseConversion;
			this.baseConvertor.Name = "baseConvertor";
			this.baseConvertor.Size = new System.Drawing.Size(23, 22);
			this.baseConvertor.ToolTipText = "Base Convertor";
			// 
			// toolStripSeparator10
			// 
			this.toolStripSeparator10.Name = "toolStripSeparator10";
			this.toolStripSeparator10.Size = new System.Drawing.Size(6, 25);
			// 
			// toolStripDropDownButton2
			// 
			this.toolStripDropDownButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openPalettesWorldMaps,
            this.openPalettesLogos});
			this.toolStripDropDownButton2.Image = global::LazyShell.Properties.Resources.openPalettes;
			this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
			this.toolStripDropDownButton2.Size = new System.Drawing.Size(29, 22);
			// 
			// openPalettesWorldMaps
			// 
			this.openPalettesWorldMaps.Name = "openPalettesWorldMaps";
			this.openPalettesWorldMaps.Size = new System.Drawing.Size(188, 22);
			this.openPalettesWorldMaps.Text = "World Map Palettes";
			this.openPalettesWorldMaps.Click += new System.EventHandler(this.openPalettesWorldMaps_Click);
			// 
			// openPalettesLogos
			// 
			this.openPalettesLogos.Name = "openPalettesLogos";
			this.openPalettesLogos.Size = new System.Drawing.Size(188, 22);
			this.openPalettesLogos.Text = "Logo, Banner Palettes";
			this.openPalettesLogos.Click += new System.EventHandler(this.openPalettesLogos_Click);
			// 
			// toolStripDropDownButton3
			// 
			this.toolStripDropDownButton3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openGraphicsWorldMaps,
            this.openGraphicsLogos,
            this.openGraphicsSprites});
			this.toolStripDropDownButton3.Image = global::LazyShell.Properties.Resources.openGraphics;
			this.toolStripDropDownButton3.Name = "toolStripDropDownButton3";
			this.toolStripDropDownButton3.Size = new System.Drawing.Size(29, 22);
			// 
			// openGraphicsWorldMaps
			// 
			this.openGraphicsWorldMaps.Name = "openGraphicsWorldMaps";
			this.openGraphicsWorldMaps.Size = new System.Drawing.Size(193, 22);
			this.openGraphicsWorldMaps.Text = "World Map Graphics";
			this.openGraphicsWorldMaps.Click += new System.EventHandler(this.openGraphicsWorldMaps_Click);
			// 
			// openGraphicsLogos
			// 
			this.openGraphicsLogos.Name = "openGraphicsLogos";
			this.openGraphicsLogos.Size = new System.Drawing.Size(193, 22);
			this.openGraphicsLogos.Text = "Logo, Banner Graphics";
			this.openGraphicsLogos.Click += new System.EventHandler(this.openGraphicsLogos_Click);
			// 
			// openGraphicsSprites
			// 
			this.openGraphicsSprites.Name = "openGraphicsSprites";
			this.openGraphicsSprites.Size = new System.Drawing.Size(193, 22);
			this.openGraphicsSprites.Text = "Sprite Graphics";
			this.openGraphicsSprites.Visible = false;
			this.openGraphicsSprites.Click += new System.EventHandler(this.openGraphicsSprites_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// toolStripLabel1
			// 
			this.toolStripLabel1.Name = "toolStripLabel1";
			this.toolStripLabel1.Size = new System.Drawing.Size(39, 22);
			this.toolStripLabel1.Text = "Music";
			// 
			// music
			// 
			this.music.DropDownHeight = 400;
			this.music.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.music.DropDownWidth = 300;
			this.music.IntegralHeight = false;
			this.music.Name = "music";
			this.music.Size = new System.Drawing.Size(214, 25);
			// 
			// dockPanel
			// 
			this.dockPanel.BackColor = System.Drawing.SystemColors.ControlDark;
			this.dockPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dockPanel.DockRightPortion = 282D;
			this.dockPanel.Location = new System.Drawing.Point(0, 25);
			this.dockPanel.Name = "dockPanel";
			this.dockPanel.Size = new System.Drawing.Size(573, 374);
			this.dockPanel.TabIndex = 3;
			// 
			// OwnerForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(573, 399);
			this.Controls.Add(this.dockPanel);
			this.Controls.Add(this.toolStrip3);
			this.IsMdiContainer = true;
			this.Location = new System.Drawing.Point(0, 0);
			this.Name = "OwnerForm";
			this.Text = "World Maps - Lazy Shell";
			this.toolStrip3.ResumeLayout(false);
			this.toolStrip3.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripButton save;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton import;
        private System.Windows.Forms.ToolStripButton export;
        private System.Windows.Forms.ToolStripButton clear;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem resetWorldMap;
        private System.Windows.Forms.ToolStripMenuItem resetLocation;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripButton helpTips;
        private System.Windows.Forms.ToolStripButton baseConvertor;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton2;
        private System.Windows.Forms.ToolStripMenuItem openPalettesWorldMaps;
        private System.Windows.Forms.ToolStripMenuItem openPalettesLogos;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton3;
        private System.Windows.Forms.ToolStripMenuItem openGraphicsWorldMaps;
        private System.Windows.Forms.ToolStripMenuItem openGraphicsLogos;
        private System.Windows.Forms.ToolStripMenuItem openGraphicsSprites;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox music;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private WeifenLuo.WinFormsUI.Docking.DockPanel dockPanel;
    }
}