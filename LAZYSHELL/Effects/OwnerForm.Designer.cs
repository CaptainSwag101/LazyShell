
namespace LazyShell.Effects
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
			this.num = new LazyShell.Controls.NewToolStripNumericUpDown();
			this.toolStrip2 = new System.Windows.Forms.ToolStrip();
			this.save = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.import = new System.Windows.Forms.ToolStripButton();
			this.export = new System.Windows.Forms.ToolStripButton();
			this.reset = new System.Windows.Forms.ToolStripButton();
			this.clear = new System.Windows.Forms.ToolStripButton();
			this.cullAnimations = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
			this.helpTips = new System.Windows.Forms.ToolStripButton();
			this.baseConvertor = new System.Windows.Forms.ToolStripButton();
			this.toolStrip3 = new System.Windows.Forms.ToolStrip();
			this.name = new System.Windows.Forms.ToolStripComboBox();
			this.searchEffectNames = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.toggleProperties = new LazyShell.Controls.NewToolStripButton();
			this.toggleMolds = new LazyShell.Controls.NewToolStripButton();
			this.toggleSequences = new LazyShell.Controls.NewToolStripButton();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.openPalettes = new System.Windows.Forms.ToolStripButton();
			this.openGraphics = new System.Windows.Forms.ToolStripButton();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.dockPanel = new WeifenLuo.WinFormsUI.Docking.DockPanel();
			this.toolStrip2.SuspendLayout();
			this.toolStrip3.SuspendLayout();
			this.SuspendLayout();
			// 
			// num
			// 
			this.num.AutoSize = false;
			this.num.ContextMenuStrip = null;
			this.num.Hexadecimal = false;
			this.num.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.num.Location = new System.Drawing.Point(248, 1);
			this.num.Maximum = new decimal(new int[] {
            127,
            0,
            0,
            0});
			this.num.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
			this.num.Name = "number";
			this.num.Size = new System.Drawing.Size(50, 20);
			this.num.Text = "0";
			this.num.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
			this.num.ValueChanged += new System.EventHandler(this.num_ValueChanged);
			// 
			// toolStrip2
			// 
			this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.save,
            this.toolStripSeparator1,
            this.import,
            this.export,
            this.reset,
            this.clear,
            this.cullAnimations,
            this.toolStripSeparator12,
            this.helpTips,
            this.baseConvertor});
			this.toolStrip2.Location = new System.Drawing.Point(0, 0);
			this.toolStrip2.Name = "toolStrip2";
			this.toolStrip2.Size = new System.Drawing.Size(989, 25);
			this.toolStrip2.TabIndex = 0;
			// 
			// save
			// 
			this.save.Image = global::LazyShell.Properties.Resources.save;
			this.save.Name = "save";
			this.save.Size = new System.Drawing.Size(23, 22);
			this.save.ToolTipText = "Save";
			this.save.Click += new System.EventHandler(this.save_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
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
			// reset
			// 
			this.reset.Image = global::LazyShell.Properties.Resources.reset;
			this.reset.Name = "reset";
			this.reset.Size = new System.Drawing.Size(23, 22);
			this.reset.ToolTipText = "Reset";
			this.reset.Click += new System.EventHandler(this.reset_Click);
			// 
			// clear
			// 
			this.clear.Image = global::LazyShell.Properties.Resources.clear;
			this.clear.Name = "clear";
			this.clear.Size = new System.Drawing.Size(23, 22);
			this.clear.ToolTipText = "Clear";
			this.clear.Click += new System.EventHandler(this.clear_Click);
			// 
			// cullAnimations
			// 
			this.cullAnimations.Image = global::LazyShell.Properties.Resources.broom;
			this.cullAnimations.Name = "cullAnimations";
			this.cullAnimations.Size = new System.Drawing.Size(23, 22);
			this.cullAnimations.ToolTipText = "Clean unused animation data";
			this.cullAnimations.Click += new System.EventHandler(this.cullAnimations_Click);
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
			// toolStrip3
			// 
			this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.name,
            this.searchEffectNames,
            this.num,
            this.toolStripSeparator2,
            this.toggleProperties,
            this.toggleMolds,
            this.toggleSequences,
            this.toolStripSeparator4,
            this.openPalettes,
            this.openGraphics});
			this.toolStrip3.Location = new System.Drawing.Point(0, 25);
			this.toolStrip3.Name = "toolStrip3";
			this.toolStrip3.Size = new System.Drawing.Size(989, 25);
			this.toolStrip3.TabIndex = 1;
			// 
			// name
			// 
			this.name.DropDownHeight = 500;
			this.name.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.name.DropDownWidth = 310;
			this.name.IntegralHeight = false;
			this.name.Name = "name";
			this.name.Size = new System.Drawing.Size(214, 25);
			this.name.SelectedIndexChanged += new System.EventHandler(this.name_SelectedIndexChanged);
			// 
			// searchEffectNames
			// 
			this.searchEffectNames.Image = global::LazyShell.Properties.Resources.search;
			this.searchEffectNames.Name = "searchEffectNames";
			this.searchEffectNames.Size = new System.Drawing.Size(23, 22);
			this.searchEffectNames.ToolTipText = "Search for effect";
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
			// 
			// toggleProperties
			// 
			this.toggleProperties.CheckOnClick = true;
			this.toggleProperties.Form = null;
			this.toggleProperties.Image = global::LazyShell.Properties.Resources.showMain;
			this.toggleProperties.Name = "toggleProperties";
			this.toggleProperties.Size = new System.Drawing.Size(23, 22);
			this.toggleProperties.ToolTipText = "Main";
			// 
			// toggleMolds
			// 
			this.toggleMolds.CheckOnClick = true;
			this.toggleMolds.Form = null;
			this.toggleMolds.Image = global::LazyShell.Properties.Resources.mainEffects;
			this.toggleMolds.Name = "toggleMolds";
			this.toggleMolds.Size = new System.Drawing.Size(23, 22);
			this.toggleMolds.ToolTipText = "Molds";
			// 
			// toggleSequences
			// 
			this.toggleSequences.CheckOnClick = true;
			this.toggleSequences.Form = null;
			this.toggleSequences.Image = global::LazyShell.Properties.Resources.openEffectSequences;
			this.toggleSequences.Name = "toggleSequences";
			this.toggleSequences.Size = new System.Drawing.Size(23, 22);
			this.toggleSequences.ToolTipText = "Frames";
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
			// 
			// openPalettes
			// 
			this.openPalettes.Image = global::LazyShell.Properties.Resources.openPalettes;
			this.openPalettes.Name = "openPalettes";
			this.openPalettes.Size = new System.Drawing.Size(23, 22);
			this.openPalettes.ToolTipText = "Palettes";
			this.openPalettes.Click += new System.EventHandler(this.openPalettes_Click);
			// 
			// openGraphics
			// 
			this.openGraphics.Image = global::LazyShell.Properties.Resources.openGraphics;
			this.openGraphics.Name = "openGraphics";
			this.openGraphics.Size = new System.Drawing.Size(23, 22);
			this.openGraphics.ToolTipText = "BPP Graphics";
			this.openGraphics.Click += new System.EventHandler(this.openGraphics_Click);
			// 
			// toolTip1
			// 
			this.toolTip1.Active = false;
			// 
			// dockPanel
			// 
			this.dockPanel.BackColor = System.Drawing.SystemColors.ControlDark;
			this.dockPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dockPanel.Location = new System.Drawing.Point(0, 50);
			this.dockPanel.Name = "dockPanel";
			this.dockPanel.Size = new System.Drawing.Size(989, 626);
			this.dockPanel.TabIndex = 3;
			// 
			// OwnerForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(989, 676);
			this.Controls.Add(this.dockPanel);
			this.Controls.Add(this.toolStrip3);
			this.Controls.Add(this.toolStrip2);
			this.IsMdiContainer = true;
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(0, 0);
			this.MaximizeBox = false;
			this.Name = "OwnerForm";
			this.Text = "Effects - Lazy Shell";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OwnerForm_FormClosing);
			this.toolStrip2.ResumeLayout(false);
			this.toolStrip2.PerformLayout();
			this.toolStrip3.ResumeLayout(false);
			this.toolStrip3.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton save;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton import;
        private System.Windows.Forms.ToolStripButton export;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripComboBox name;
        private System.Windows.Forms.ToolStripButton searchEffectNames;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton openPalettes;
        private System.Windows.Forms.ToolStripButton openGraphics;
        private Controls.NewToolStripButton toggleSequences;
        private Controls.NewToolStripButton toggleMolds;
        private Controls.NewToolStripButton toggleProperties;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton clear;
        private Controls.NewToolStripNumericUpDown num;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator12;
        private System.Windows.Forms.ToolStripButton helpTips;
        private System.Windows.Forms.ToolStripButton baseConvertor;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStripButton reset;
        private System.Windows.Forms.ToolStripButton cullAnimations;
        private WeifenLuo.WinFormsUI.Docking.DockPanel dockPanel;
    }
}