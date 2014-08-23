namespace LAZYSHELL.Formations
{
    partial class OwnerForm
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
            WeifenLuo.WinFormsUI.Docking.DockPanelSkin dockPanelSkin1 = new WeifenLuo.WinFormsUI.Docking.DockPanelSkin();
            WeifenLuo.WinFormsUI.Docking.AutoHideStripSkin autoHideStripSkin1 = new WeifenLuo.WinFormsUI.Docking.AutoHideStripSkin();
            WeifenLuo.WinFormsUI.Docking.DockPanelGradient dockPanelGradient1 = new WeifenLuo.WinFormsUI.Docking.DockPanelGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient1 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.DockPaneStripSkin dockPaneStripSkin1 = new WeifenLuo.WinFormsUI.Docking.DockPaneStripSkin();
            WeifenLuo.WinFormsUI.Docking.DockPaneStripGradient dockPaneStripGradient1 = new WeifenLuo.WinFormsUI.Docking.DockPaneStripGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient2 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.DockPanelGradient dockPanelGradient2 = new WeifenLuo.WinFormsUI.Docking.DockPanelGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient3 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.DockPaneStripToolWindowGradient dockPaneStripToolWindowGradient1 = new WeifenLuo.WinFormsUI.Docking.DockPaneStripToolWindowGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient4 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient5 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.DockPanelGradient dockPanelGradient3 = new WeifenLuo.WinFormsUI.Docking.DockPanelGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient6 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient7 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
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
            this.toggleFormations = new LAZYSHELL.Controls.NewToolStripButton();
            this.togglePacks = new LAZYSHELL.Controls.NewToolStripButton();
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
            this.save.Image = global::LAZYSHELL.Properties.Resources.save;
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
            this.import.Image = global::LAZYSHELL.Properties.Resources.importData;
            this.import.Name = "import";
            this.import.Size = new System.Drawing.Size(29, 22);
            // 
            // importFormations
            // 
            this.importFormations.Name = "importFormations";
            this.importFormations.Size = new System.Drawing.Size(174, 22);
            this.importFormations.Text = "Import Formations...";
            this.importFormations.Click += new System.EventHandler(this.importFormations_Click);
            // 
            // importPacks
            // 
            this.importPacks.Name = "importPacks";
            this.importPacks.Size = new System.Drawing.Size(174, 22);
            this.importPacks.Text = "Import Packs...";
            this.importPacks.Click += new System.EventHandler(this.importPacks_Click);
            // 
            // export
            // 
            this.export.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportFormations,
            this.exportPacks});
            this.export.Image = global::LAZYSHELL.Properties.Resources.exportData;
            this.export.Name = "export";
            this.export.Size = new System.Drawing.Size(29, 22);
            // 
            // exportFormations
            // 
            this.exportFormations.Name = "exportFormations";
            this.exportFormations.Size = new System.Drawing.Size(174, 22);
            this.exportFormations.Text = "Export Formations...";
            this.exportFormations.Click += new System.EventHandler(this.exportFormations_Click);
            // 
            // exportPacks
            // 
            this.exportPacks.Name = "exportPacks";
            this.exportPacks.Size = new System.Drawing.Size(174, 22);
            this.exportPacks.Text = "Export Packs...";
            this.exportPacks.Click += new System.EventHandler(this.exportPacks_Click);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.resetFormation,
            this.resetPack});
            this.toolStripDropDownButton1.Image = global::LAZYSHELL.Properties.Resources.reset;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(29, 22);
            // 
            // resetFormation
            // 
            this.resetFormation.Name = "resetFormation";
            this.resetFormation.Size = new System.Drawing.Size(151, 22);
            this.resetFormation.Text = "Reset formation";
            this.resetFormation.Click += new System.EventHandler(this.resetFormation_Click);
            // 
            // resetPack
            // 
            this.resetPack.Name = "resetPack";
            this.resetPack.Size = new System.Drawing.Size(151, 22);
            this.resetPack.Text = "Reset pack";
            this.resetPack.Click += new System.EventHandler(this.resetPack_Click);
            // 
            // clear
            // 
            this.clear.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearFormations,
            this.clearPacks});
            this.clear.Image = global::LAZYSHELL.Properties.Resources.clear;
            this.clear.Name = "clear";
            this.clear.Size = new System.Drawing.Size(29, 22);
            // 
            // clearFormations
            // 
            this.clearFormations.Name = "clearFormations";
            this.clearFormations.Size = new System.Drawing.Size(167, 22);
            this.clearFormations.Text = "Clear Formations...";
            this.clearFormations.Click += new System.EventHandler(this.clearFormations_Click);
            // 
            // clearPacks
            // 
            this.clearPacks.Name = "clearPacks";
            this.clearPacks.Size = new System.Drawing.Size(167, 22);
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
            this.helpTips.Image = global::LAZYSHELL.Properties.Resources.help;
            this.helpTips.Name = "helpTips";
            this.helpTips.Size = new System.Drawing.Size(23, 22);
            this.helpTips.ToolTipText = "Help Tips";
            // 
            // baseConvertor
            // 
            this.baseConvertor.CheckOnClick = true;
            this.baseConvertor.Image = global::LAZYSHELL.Properties.Resources.baseConversion;
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
            this.toggleFormations.Image = global::LAZYSHELL.Properties.Resources.mainFormations;
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
            this.togglePacks.Image = global::LAZYSHELL.Properties.Resources.openPacks;
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
            this.dockPanel.Size = new System.Drawing.Size(989, 366);
            dockPanelGradient1.EndColor = System.Drawing.SystemColors.ControlLight;
            dockPanelGradient1.StartColor = System.Drawing.SystemColors.ControlLight;
            autoHideStripSkin1.DockStripGradient = dockPanelGradient1;
            tabGradient1.EndColor = System.Drawing.SystemColors.Control;
            tabGradient1.StartColor = System.Drawing.SystemColors.Control;
            tabGradient1.TextColor = System.Drawing.SystemColors.ControlDarkDark;
            autoHideStripSkin1.TabGradient = tabGradient1;
            autoHideStripSkin1.TextFont = new System.Drawing.Font("Tahoma", 8.25F);
            dockPanelSkin1.AutoHideStripSkin = autoHideStripSkin1;
            tabGradient2.EndColor = System.Drawing.SystemColors.ControlLightLight;
            tabGradient2.StartColor = System.Drawing.SystemColors.ControlLightLight;
            tabGradient2.TextColor = System.Drawing.SystemColors.ControlText;
            dockPaneStripGradient1.ActiveTabGradient = tabGradient2;
            dockPanelGradient2.EndColor = System.Drawing.SystemColors.Control;
            dockPanelGradient2.StartColor = System.Drawing.SystemColors.Control;
            dockPaneStripGradient1.DockStripGradient = dockPanelGradient2;
            tabGradient3.EndColor = System.Drawing.SystemColors.ControlLight;
            tabGradient3.StartColor = System.Drawing.SystemColors.ControlLight;
            tabGradient3.TextColor = System.Drawing.SystemColors.ControlText;
            dockPaneStripGradient1.InactiveTabGradient = tabGradient3;
            dockPaneStripSkin1.DocumentGradient = dockPaneStripGradient1;
            dockPaneStripSkin1.TextFont = new System.Drawing.Font("Tahoma", 8.25F);
            tabGradient4.EndColor = System.Drawing.SystemColors.ActiveCaption;
            tabGradient4.LinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            tabGradient4.StartColor = System.Drawing.SystemColors.GradientActiveCaption;
            tabGradient4.TextColor = System.Drawing.SystemColors.ActiveCaptionText;
            dockPaneStripToolWindowGradient1.ActiveCaptionGradient = tabGradient4;
            tabGradient5.EndColor = System.Drawing.SystemColors.Control;
            tabGradient5.StartColor = System.Drawing.SystemColors.Control;
            tabGradient5.TextColor = System.Drawing.SystemColors.ControlText;
            dockPaneStripToolWindowGradient1.ActiveTabGradient = tabGradient5;
            dockPanelGradient3.EndColor = System.Drawing.SystemColors.ControlLight;
            dockPanelGradient3.StartColor = System.Drawing.SystemColors.ControlLight;
            dockPaneStripToolWindowGradient1.DockStripGradient = dockPanelGradient3;
            tabGradient6.EndColor = System.Drawing.SystemColors.InactiveCaption;
            tabGradient6.LinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            tabGradient6.StartColor = System.Drawing.SystemColors.GradientInactiveCaption;
            tabGradient6.TextColor = System.Drawing.SystemColors.InactiveCaptionText;
            dockPaneStripToolWindowGradient1.InactiveCaptionGradient = tabGradient6;
            tabGradient7.EndColor = System.Drawing.Color.Transparent;
            tabGradient7.StartColor = System.Drawing.Color.Transparent;
            tabGradient7.TextColor = System.Drawing.SystemColors.ControlDarkDark;
            dockPaneStripToolWindowGradient1.InactiveTabGradient = tabGradient7;
            dockPaneStripSkin1.ToolWindowGradient = dockPaneStripToolWindowGradient1;
            dockPanelSkin1.DockPaneStripSkin = dockPaneStripSkin1;
            this.dockPanel.Skin = dockPanelSkin1;
            this.dockPanel.TabIndex = 9;
            // 
            // OwnerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(989, 391);
            this.Controls.Add(this.dockPanel);
            this.Controls.Add(this.toolStrip5);
            this.IsMdiContainer = true;
            this.Name = "OwnerForm";
            this.Text = "FORMATIONS - Lazy Shell";
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