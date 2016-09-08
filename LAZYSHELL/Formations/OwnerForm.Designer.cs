namespace LazyShell.Formations
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
			this.toolStrip5 = new System.Windows.Forms.ToolStrip();
			this.save = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.import = new System.Windows.Forms.ToolStripDropDownButton();
			this.importFormations = new System.Windows.Forms.ToolStripMenuItem();
			this.importPacks = new System.Windows.Forms.ToolStripMenuItem();
			this.export = new System.Windows.Forms.ToolStripDropDownButton();
			this.exportFormations = new System.Windows.Forms.ToolStripMenuItem();
			this.exportPacks = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
			this.resetFormation = new System.Windows.Forms.ToolStripMenuItem();
			this.resetPack = new System.Windows.Forms.ToolStripMenuItem();
			this.clear = new System.Windows.Forms.ToolStripDropDownButton();
			this.clearFormations = new System.Windows.Forms.ToolStripMenuItem();
			this.clearPacks = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
			this.helpTips = new System.Windows.Forms.ToolStripButton();
			this.baseConvertor = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
			this.toggleFormations = new LazyShell.Controls.NewToolStripButton();
			this.togglePacks = new LazyShell.Controls.NewToolStripButton();
			this.dockPanel = new WeifenLuo.WinFormsUI.Docking.DockPanel();
			this.toolStrip5.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolStrip5
			// 
			this.toolStrip5.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.save,
            this.toolStripSeparator4,
            this.import,
            this.export,
            this.toolStripDropDownButton1,
            this.clear,
            this.toolStripSeparator12,
            this.helpTips,
            this.baseConvertor,
            this.toolStripSeparator5,
            this.toggleFormations,
            this.togglePacks});
			this.toolStrip5.Location = new System.Drawing.Point(0, 0);
			this.toolStrip5.Name = "toolStrip5";
			this.toolStrip5.Size = new System.Drawing.Size(989, 25);
			this.toolStrip5.TabIndex = 7;
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
			this.import.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importFormations,
            this.importPacks});
			this.import.Image = global::LazyShell.Properties.Resources.importData;
			this.import.Name = "import";
			this.import.Size = new System.Drawing.Size(29, 22);
			// 
			// importFormations
			// 
			this.importFormations.Name = "importFormations";
			this.importFormations.Size = new System.Drawing.Size(182, 22);
			this.importFormations.Text = "Import Formations...";
			this.importFormations.Click += new System.EventHandler(this.importFormations_Click);
			// 
			// importPacks
			// 
			this.importPacks.Name = "importPacks";
			this.importPacks.Size = new System.Drawing.Size(182, 22);
			this.importPacks.Text = "Import Packs...";
			this.importPacks.Click += new System.EventHandler(this.importPacks_Click);
			// 
			// export
			// 
			this.export.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportFormations,
            this.exportPacks});
			this.export.Image = global::LazyShell.Properties.Resources.exportData;
			this.export.Name = "export";
			this.export.Size = new System.Drawing.Size(29, 22);
			// 
			// exportFormations
			// 
			this.exportFormations.Name = "exportFormations";
			this.exportFormations.Size = new System.Drawing.Size(179, 22);
			this.exportFormations.Text = "Export Formations...";
			this.exportFormations.Click += new System.EventHandler(this.exportFormations_Click);
			// 
			// exportPacks
			// 
			this.exportPacks.Name = "exportPacks";
			this.exportPacks.Size = new System.Drawing.Size(179, 22);
			this.exportPacks.Text = "Export Packs...";
			this.exportPacks.Click += new System.EventHandler(this.exportPacks_Click);
			// 
			// toolStripDropDownButton1
			// 
			this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.resetFormation,
            this.resetPack});
			this.toolStripDropDownButton1.Image = global::LazyShell.Properties.Resources.reset;
			this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
			this.toolStripDropDownButton1.Size = new System.Drawing.Size(29, 22);
			// 
			// resetFormation
			// 
			this.resetFormation.Name = "resetFormation";
			this.resetFormation.Size = new System.Drawing.Size(158, 22);
			this.resetFormation.Text = "Reset formation";
			this.resetFormation.Click += new System.EventHandler(this.resetFormation_Click);
			// 
			// resetPack
			// 
			this.resetPack.Name = "resetPack";
			this.resetPack.Size = new System.Drawing.Size(158, 22);
			this.resetPack.Text = "Reset pack";
			this.resetPack.Click += new System.EventHandler(this.resetPack_Click);
			// 
			// clear
			// 
			this.clear.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearFormations,
            this.clearPacks});
			this.clear.Image = global::LazyShell.Properties.Resources.clear;
			this.clear.Name = "clear";
			this.clear.Size = new System.Drawing.Size(29, 22);
			// 
			// clearFormations
			// 
			this.clearFormations.Name = "clearFormations";
			this.clearFormations.Size = new System.Drawing.Size(173, 22);
			this.clearFormations.Text = "Clear Formations...";
			this.clearFormations.Click += new System.EventHandler(this.clearFormations_Click);
			// 
			// clearPacks
			// 
			this.clearPacks.Name = "clearPacks";
			this.clearPacks.Size = new System.Drawing.Size(173, 22);
			this.clearPacks.Text = "Clear Packs...";
			this.clearPacks.Click += new System.EventHandler(this.clearPacks_Click);
			// 
			// toolStripSeparator12
			// 
			this.toolStripSeparator12.Name = "toolStripSeparator12";
			this.toolStripSeparator12.Size = new System.Drawing.Size(6, 25);
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
			// toolStripSeparator5
			// 
			this.toolStripSeparator5.Name = "toolStripSeparator5";
			this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
			// 
			// toggleFormations
			// 
			this.toggleFormations.Checked = true;
			this.toggleFormations.CheckState = System.Windows.Forms.CheckState.Checked;
			this.toggleFormations.Form = null;
			this.toggleFormations.Image = global::LazyShell.Properties.Resources.mainFormations;
			this.toggleFormations.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toggleFormations.Name = "toggleFormations";
			this.toggleFormations.Size = new System.Drawing.Size(23, 22);
			this.toggleFormations.ToolTipText = "Show/hide formations";
			// 
			// togglePacks
			// 
			this.togglePacks.Checked = true;
			this.togglePacks.CheckOnClick = true;
			this.togglePacks.CheckState = System.Windows.Forms.CheckState.Checked;
			this.togglePacks.Form = null;
			this.togglePacks.Image = global::LazyShell.Properties.Resources.openPacks;
			this.togglePacks.Name = "togglePacks";
			this.togglePacks.Size = new System.Drawing.Size(23, 22);
			this.togglePacks.ToolTipText = "Formation Packs";
			// 
			// dockPanel
			// 
			this.dockPanel.BackColor = System.Drawing.SystemColors.ControlDark;
			this.dockPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dockPanel.Location = new System.Drawing.Point(0, 25);
			this.dockPanel.Name = "dockPanel";
			this.dockPanel.Size = new System.Drawing.Size(989, 374);
			this.dockPanel.TabIndex = 9;
			// 
			// OwnerForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(989, 399);
			this.Controls.Add(this.dockPanel);
			this.Controls.Add(this.toolStrip5);
			this.IsMdiContainer = true;
			this.Location = new System.Drawing.Point(0, 0);
			this.Name = "OwnerForm";
			this.Text = "Formations - Lazy Shell";
			this.toolStrip5.ResumeLayout(false);
			this.toolStrip5.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip5;
        private System.Windows.Forms.ToolStripButton save;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripDropDownButton import;
        private System.Windows.Forms.ToolStripMenuItem importFormations;
        private System.Windows.Forms.ToolStripMenuItem importPacks;
        private System.Windows.Forms.ToolStripDropDownButton export;
        private System.Windows.Forms.ToolStripMenuItem exportFormations;
        private System.Windows.Forms.ToolStripMenuItem exportPacks;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem resetFormation;
        private System.Windows.Forms.ToolStripMenuItem resetPack;
        private System.Windows.Forms.ToolStripDropDownButton clear;
        private System.Windows.Forms.ToolStripMenuItem clearFormations;
        private System.Windows.Forms.ToolStripMenuItem clearPacks;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator12;
        private System.Windows.Forms.ToolStripButton helpTips;
        private System.Windows.Forms.ToolStripButton baseConvertor;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private Controls.NewToolStripButton toggleFormations;
        private Controls.NewToolStripButton togglePacks;
        private WeifenLuo.WinFormsUI.Docking.DockPanel dockPanel;
    }
}