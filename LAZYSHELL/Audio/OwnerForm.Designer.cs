
namespace LazyShell.Audio
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
			this.soundType = new System.Windows.Forms.ToolStripComboBox();
			this.trackName = new System.Windows.Forms.ToolStripComboBox();
			this.findReferences = new System.Windows.Forms.ToolStripButton();
			this.trackNum = new LazyShell.Controls.NewToolStripNumericUpDown();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.freeSpace = new System.Windows.Forms.ToolStripLabel();
			this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
			this.toggleInstruments = new LazyShell.Controls.NewToolStripButton();
			this.toggleScoreViewer = new LazyShell.Controls.NewToolStripButton();
			this.toggleTrackViewer = new LazyShell.Controls.NewToolStripButton();
			this.toggleScoreWriter = new LazyShell.Controls.NewToolStripButton();
			this.import = new System.Windows.Forms.ToolStripDropDownButton();
			this.importSPC = new System.Windows.Forms.ToolStripMenuItem();
			this.importMML = new System.Windows.Forms.ToolStripMenuItem();
			this.export = new System.Windows.Forms.ToolStripDropDownButton();
			this.exportSPC = new System.Windows.Forms.ToolStripMenuItem();
			this.exportMML = new System.Windows.Forms.ToolStripMenuItem();
			this.clear = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
			this.reset = new System.Windows.Forms.ToolStripButton();
			this.openHexEditor = new System.Windows.Forms.ToolStripButton();
			this.openPreviewer = new System.Windows.Forms.ToolStripButton();
			this.autoLaunch = new LazyShell.Controls.NewToolStripCheckBox();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.importScoreFiles = new System.Windows.Forms.ToolStripButton();
			this.importSPCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.importMMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exportSPCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exportMMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStrip2 = new System.Windows.Forms.ToolStrip();
			this.save = new System.Windows.Forms.ToolStripButton();
			this.helpTips = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.toggleSamples = new LazyShell.Controls.NewToolStripButton();
			this.dockPanel = new WeifenLuo.WinFormsUI.Docking.DockPanel();
			this.toolStrip1.SuspendLayout();
			this.toolStrip2.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolStrip1
			// 
			this.toolStrip1.CanOverflow = false;
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.soundType,
            this.trackName,
            this.findReferences,
            this.trackNum,
            this.toolStripSeparator4,
            this.freeSpace});
			this.toolStrip1.Location = new System.Drawing.Point(0, 25);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(1192, 25);
			this.toolStrip1.TabIndex = 0;
			// 
			// soundType
			// 
			this.soundType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.soundType.Items.AddRange(new object[] {
            "SPC music tracks",
            "Event Sound FX",
            "Battle Sound FX"});
			this.soundType.Name = "soundType";
			this.soundType.Size = new System.Drawing.Size(130, 25);
			this.soundType.SelectedIndexChanged += new System.EventHandler(this.soundType_SelectedIndexChanged);
			// 
			// trackName
			// 
			this.trackName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.trackName.DropDownWidth = 250;
			this.trackName.Name = "trackName";
			this.trackName.Size = new System.Drawing.Size(170, 25);
			this.trackName.SelectedIndexChanged += new System.EventHandler(this.trackName_SelectedIndexChanged);
			// 
			// findReferences
			// 
			this.findReferences.Image = global::LazyShell.Properties.Resources.findReferences;
			this.findReferences.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.findReferences.Name = "findReferences";
			this.findReferences.Size = new System.Drawing.Size(23, 22);
			this.findReferences.ToolTipText = "Find all references to SPC";
			this.findReferences.Click += new System.EventHandler(this.findReferences_Click);
			// 
			// trackNum
			// 
			this.trackNum.AutoSize = false;
			this.trackNum.ContextMenuStrip = null;
			this.trackNum.Hexadecimal = false;
			this.trackNum.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.trackNum.Location = new System.Drawing.Point(336, 1);
			this.trackNum.Maximum = new decimal(new int[] {
            73,
            0,
            0,
            0});
			this.trackNum.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
			this.trackNum.Name = "trackNum";
			this.trackNum.Size = new System.Drawing.Size(50, 21);
			this.trackNum.Text = "0";
			this.trackNum.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
			this.trackNum.ValueChanged += new System.EventHandler(this.trackNum_ValueChanged);
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
			// 
			// freeSpace
			// 
			this.freeSpace.Name = "freeSpace";
			this.freeSpace.Size = new System.Drawing.Size(93, 22);
			this.freeSpace.Text = "0 available bytes";
			// 
			// toolStripSeparator9
			// 
			this.toolStripSeparator9.Name = "toolStripSeparator9";
			this.toolStripSeparator9.Size = new System.Drawing.Size(6, 25);
			// 
			// toggleInstruments
			// 
			this.toggleInstruments.CheckOnClick = true;
			this.toggleInstruments.Form = null;
			this.toggleInstruments.Image = global::LazyShell.Properties.Resources.instrument;
			this.toggleInstruments.Name = "toggleInstruments";
			this.toggleInstruments.Size = new System.Drawing.Size(23, 22);
			this.toggleInstruments.ToolTipText = "Instruments Window";
			// 
			// toggleScoreViewer
			// 
			this.toggleScoreViewer.CheckOnClick = true;
			this.toggleScoreViewer.Form = null;
			this.toggleScoreViewer.Image = global::LazyShell.Properties.Resources.scoreView;
			this.toggleScoreViewer.Name = "toggleScoreViewer";
			this.toggleScoreViewer.Size = new System.Drawing.Size(23, 22);
			this.toggleScoreViewer.ToolTipText = "Score Viewer Window";
			// 
			// toggleTrackViewer
			// 
			this.toggleTrackViewer.CheckOnClick = true;
			this.toggleTrackViewer.Form = null;
			this.toggleTrackViewer.Image = global::LazyShell.Properties.Resources.trackViewer;
			this.toggleTrackViewer.Name = "toggleTrackViewer";
			this.toggleTrackViewer.Size = new System.Drawing.Size(23, 22);
			this.toggleTrackViewer.ToolTipText = "Track Viewer Window";
			// 
			// toggleScoreWriter
			// 
			this.toggleScoreWriter.CheckOnClick = true;
			this.toggleScoreWriter.Form = null;
			this.toggleScoreWriter.Image = global::LazyShell.Properties.Resources.scoreWriter;
			this.toggleScoreWriter.Name = "toggleScoreWriter";
			this.toggleScoreWriter.Size = new System.Drawing.Size(23, 22);
			this.toggleScoreWriter.ToolTipText = "Score Writer Window";
			// 
			// import
			// 
			this.import.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importSPC,
            this.importMML});
			this.import.Image = global::LazyShell.Properties.Resources.importData;
			this.import.Name = "import";
			this.import.Size = new System.Drawing.Size(29, 22);
			// 
			// importSPC
			// 
			this.importSPC.Name = "importSPC";
			this.importSPC.Size = new System.Drawing.Size(150, 22);
			this.importSPC.Text = "Import SPC...";
			// 
			// importMML
			// 
			this.importMML.Image = global::LazyShell.Properties.Resources.importText;
			this.importMML.Name = "importMML";
			this.importMML.Size = new System.Drawing.Size(150, 22);
			this.importMML.Text = "Import MML...";
			this.importMML.Click += new System.EventHandler(this.importMML_Click);
			// 
			// export
			// 
			this.export.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportSPC,
            this.exportMML});
			this.export.Image = global::LazyShell.Properties.Resources.exportData;
			this.export.Name = "export";
			this.export.Size = new System.Drawing.Size(29, 22);
			// 
			// exportSPC
			// 
			this.exportSPC.Name = "exportSPC";
			this.exportSPC.Size = new System.Drawing.Size(147, 22);
			this.exportSPC.Text = "Export SPC...";
			// 
			// exportMML
			// 
			this.exportMML.Image = global::LazyShell.Properties.Resources.exportText;
			this.exportMML.Name = "exportMML";
			this.exportMML.Size = new System.Drawing.Size(147, 22);
			this.exportMML.Text = "Export MML...";
			this.exportMML.Click += new System.EventHandler(this.exportMML_Click);
			// 
			// clear
			// 
			this.clear.Image = global::LazyShell.Properties.Resources.clear;
			this.clear.Name = "clear";
			this.clear.Size = new System.Drawing.Size(23, 22);
			this.clear.ToolTipText = "Clear";
			// 
			// toolStripSeparator5
			// 
			this.toolStripSeparator5.Name = "toolStripSeparator5";
			this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
			// 
			// reset
			// 
			this.reset.Image = global::LazyShell.Properties.Resources.reset;
			this.reset.Name = "reset";
			this.reset.Size = new System.Drawing.Size(23, 22);
			this.reset.ToolTipText = "Reset SPC";
			this.reset.Click += new System.EventHandler(this.reset_Click);
			// 
			// openHexEditor
			// 
			this.openHexEditor.Image = global::LazyShell.Properties.Resources.hexEditor;
			this.openHexEditor.Name = "openHexEditor";
			this.openHexEditor.Size = new System.Drawing.Size(23, 22);
			this.openHexEditor.ToolTipText = "Open Hex Editor";
			this.openHexEditor.Click += new System.EventHandler(this.openHexEditor_Click);
			// 
			// openPreviewer
			// 
			this.openPreviewer.Image = global::LazyShell.Properties.Resources.preview;
			this.openPreviewer.Name = "openPreviewer";
			this.openPreviewer.Size = new System.Drawing.Size(23, 22);
			this.openPreviewer.ToolTipText = "Preview SPC";
			this.openPreviewer.Click += new System.EventHandler(this.openPreviewer_Click);
			// 
			// autoLaunch
			// 
			this.autoLaunch.BackColor = System.Drawing.Color.Transparent;
			this.autoLaunch.Checked = true;
			this.autoLaunch.Margin = new System.Windows.Forms.Padding(2, 2, 0, 0);
			this.autoLaunch.Name = "autoLaunch";
			this.autoLaunch.Padding = new System.Windows.Forms.Padding(4, 0, 0, 4);
			this.autoLaunch.Size = new System.Drawing.Size(97, 23);
			this.autoLaunch.Text = "Auto-launch";
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
			// 
			// importScoreFiles
			// 
			this.importScoreFiles.Image = global::LazyShell.Properties.Resources.importText;
			this.importScoreFiles.Name = "importScoreFiles";
			this.importScoreFiles.Size = new System.Drawing.Size(23, 22);
			this.importScoreFiles.Text = "Import Staffs";
			// 
			// importSPCToolStripMenuItem
			// 
			this.importSPCToolStripMenuItem.Image = global::LazyShell.Properties.Resources.importData;
			this.importSPCToolStripMenuItem.Name = "importSPCToolStripMenuItem";
			this.importSPCToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.importSPCToolStripMenuItem.Text = "Import SPC";
			// 
			// importMMLToolStripMenuItem
			// 
			this.importMMLToolStripMenuItem.Image = global::LazyShell.Properties.Resources.importText;
			this.importMMLToolStripMenuItem.Name = "importMMLToolStripMenuItem";
			this.importMMLToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.importMMLToolStripMenuItem.Text = "Import MML";
			// 
			// exportSPCToolStripMenuItem
			// 
			this.exportSPCToolStripMenuItem.Image = global::LazyShell.Properties.Resources.exportData;
			this.exportSPCToolStripMenuItem.Name = "exportSPCToolStripMenuItem";
			this.exportSPCToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.exportSPCToolStripMenuItem.Text = "Export SPC";
			// 
			// exportMMLToolStripMenuItem
			// 
			this.exportMMLToolStripMenuItem.Image = global::LazyShell.Properties.Resources.exportText;
			this.exportMMLToolStripMenuItem.Name = "exportMMLToolStripMenuItem";
			this.exportMMLToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.exportMMLToolStripMenuItem.Text = "Export MML";
			// 
			// toolStrip2
			// 
			this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.save,
            this.helpTips,
            this.toolStripSeparator1,
            this.import,
            this.export,
            this.clear,
            this.toolStripSeparator5,
            this.reset,
            this.openHexEditor,
            this.openPreviewer,
            this.autoLaunch,
            this.toolStripSeparator9,
            this.toggleScoreViewer,
            this.toggleScoreWriter,
            this.toggleTrackViewer,
            this.toggleInstruments,
            this.toggleSamples});
			this.toolStrip2.Location = new System.Drawing.Point(0, 0);
			this.toolStrip2.Name = "toolStrip2";
			this.toolStrip2.Size = new System.Drawing.Size(1192, 25);
			this.toolStrip2.TabIndex = 1;
			this.toolStrip2.Text = "toolStrip2";
			// 
			// save
			// 
			this.save.Image = global::LazyShell.Properties.Resources.save;
			this.save.Name = "save";
			this.save.Size = new System.Drawing.Size(23, 22);
			this.save.ToolTipText = "Save";
			this.save.Click += new System.EventHandler(this.save_Click);
			// 
			// helpTips
			// 
			this.helpTips.CheckOnClick = true;
			this.helpTips.Image = global::LazyShell.Properties.Resources.help;
			this.helpTips.Name = "helpTips";
			this.helpTips.Size = new System.Drawing.Size(23, 22);
			this.helpTips.ToolTipText = "Help Tips";
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// toggleSamples
			// 
			this.toggleSamples.CheckOnClick = true;
			this.toggleSamples.Form = null;
			this.toggleSamples.Image = global::LazyShell.Properties.Resources.openSamples;
			this.toggleSamples.Name = "toggleSamples";
			this.toggleSamples.Size = new System.Drawing.Size(23, 22);
			this.toggleSamples.ToolTipText = "Samples Window";
			// 
			// dockPanel
			// 
			this.dockPanel.BackColor = System.Drawing.SystemColors.ControlDark;
			this.dockPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.dockPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dockPanel.DockBottomPortion = 167D;
			this.dockPanel.DockRightPortion = 400D;
			this.dockPanel.Location = new System.Drawing.Point(0, 50);
			this.dockPanel.Name = "dockPanel";
			this.dockPanel.Size = new System.Drawing.Size(1192, 623);
			this.dockPanel.TabIndex = 3;
			// 
			// OwnerForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1192, 673);
			this.Controls.Add(this.dockPanel);
			this.Controls.Add(this.toolStrip1);
			this.Controls.Add(this.toolStrip2);
			this.DockPanel = this.dockPanel;
			this.IsMdiContainer = true;
			this.Location = new System.Drawing.Point(0, 0);
			this.Name = "OwnerForm";
			this.Text = "Audio - Lazy Shell";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OwnerForm_FormClosing);
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.toolStrip2.ResumeLayout(false);
			this.toolStrip2.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }
        #endregion
        private Controls.NewToolStripCheckBox autoLaunch;
        private Controls.NewToolStripNumericUpDown trackNum;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton clear;
        private System.Windows.Forms.ToolStripButton findReferences;
        private System.Windows.Forms.ToolStripButton helpTips;
        private System.Windows.Forms.ToolStripButton openHexEditor;
        private System.Windows.Forms.ToolStripButton importScoreFiles;
        private System.Windows.Forms.ToolStripButton openPreviewer;
        private System.Windows.Forms.ToolStripButton reset;
        private System.Windows.Forms.ToolStripButton save;
        private Controls.NewToolStripButton toggleInstruments;
        private Controls.NewToolStripButton toggleSamples;
        private Controls.NewToolStripButton toggleScoreViewer;
        private Controls.NewToolStripButton toggleScoreWriter;
        private Controls.NewToolStripButton toggleTrackViewer;
        private System.Windows.Forms.ToolStripComboBox soundType;
        private System.Windows.Forms.ToolStripComboBox trackName;
        private System.Windows.Forms.ToolStripDropDownButton export;
        private System.Windows.Forms.ToolStripDropDownButton import;
        private System.Windows.Forms.ToolStripLabel freeSpace;
        private System.Windows.Forms.ToolStripMenuItem exportMML;
        private System.Windows.Forms.ToolStripMenuItem exportMMLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportSPC;
        private System.Windows.Forms.ToolStripMenuItem exportSPCToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importMML;
        private System.Windows.Forms.ToolStripMenuItem importMMLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importSPC;
        private System.Windows.Forms.ToolStripMenuItem importSPCToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private WeifenLuo.WinFormsUI.Docking.DockPanel dockPanel;
    }
}