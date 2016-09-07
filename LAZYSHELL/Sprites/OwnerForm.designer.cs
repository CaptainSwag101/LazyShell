using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LAZYSHELL.Sprites
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
			this.components = new System.ComponentModel.Container();
			this.num = new LAZYSHELL.Controls.NewToolStripNumericUpDown();
			this.PlaybackSequence = new System.ComponentModel.BackgroundWorker();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
			this.characterNumLabel = new System.Windows.Forms.Label();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
			this.toolStrip2 = new System.Windows.Forms.ToolStrip();
			this.save = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
			this.import = new System.Windows.Forms.ToolStripButton();
			this.export = new System.Windows.Forms.ToolStripDropDownButton();
			this.exportAnimations = new System.Windows.Forms.ToolStripMenuItem();
			this.exportMoldImages = new System.Windows.Forms.ToolStripMenuItem();
			this.reset = new System.Windows.Forms.ToolStripButton();
			this.clear = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
			this.helpTips = new System.Windows.Forms.ToolStripButton();
			this.baseConvertor = new System.Windows.Forms.ToolStripButton();
			this.hexEditor = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.npcPacketButton = new System.Windows.Forms.ToolStripButton();
			this.toolStrip3 = new System.Windows.Forms.ToolStrip();
			this.name = new System.Windows.Forms.ToolStripComboBox();
			this.searchEffectNames = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.toggleProperties = new LAZYSHELL.Controls.NewToolStripButton();
			this.toggleMolds = new LAZYSHELL.Controls.NewToolStripButton();
			this.toggleSequences = new LAZYSHELL.Controls.NewToolStripButton();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.openPalettes = new System.Windows.Forms.ToolStripButton();
			this.openGraphics = new System.Windows.Forms.ToolStripButton();
			this.findReferences = new System.Windows.Forms.ToolStripButton();
			this.toolTip3 = new System.Windows.Forms.ToolTip(this.components);
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
            1023,
            0,
            0,
            0});
			this.num.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
			this.num.Name = "number";
			this.num.Size = new System.Drawing.Size(50, 21);
			this.num.Text = "0";
			this.num.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
			this.num.ValueChanged += new System.EventHandler(this.num_ValueChanged);
			// 
			// PlaybackSequence
			// 
			this.PlaybackSequence.WorkerReportsProgress = true;
			this.PlaybackSequence.WorkerSupportsCancellation = true;
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Padding = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.toolStripMenuItem1.Size = new System.Drawing.Size(31, 20);
			this.toolStripMenuItem1.Text = "File";
			// 
			// toolStripSeparator5
			// 
			this.toolStripSeparator5.Name = "toolStripSeparator5";
			this.toolStripSeparator5.Size = new System.Drawing.Size(149, 6);
			// 
			// toolStripSeparator6
			// 
			this.toolStripSeparator6.Name = "toolStripSeparator6";
			this.toolStripSeparator6.Size = new System.Drawing.Size(149, 6);
			// 
			// toolStripSeparator7
			// 
			this.toolStripSeparator7.Name = "toolStripSeparator7";
			this.toolStripSeparator7.Size = new System.Drawing.Size(149, 6);
			// 
			// toolStripSeparator8
			// 
			this.toolStripSeparator8.Name = "toolStripSeparator8";
			this.toolStripSeparator8.Size = new System.Drawing.Size(149, 6);
			// 
			// characterNumLabel
			// 
			this.characterNumLabel.BackColor = System.Drawing.SystemColors.Info;
			this.characterNumLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.characterNumLabel.Location = new System.Drawing.Point(234, 0);
			this.characterNumLabel.Name = "characterNumLabel";
			this.characterNumLabel.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
			this.characterNumLabel.Size = new System.Drawing.Size(100, 18);
			this.characterNumLabel.TabIndex = 5;
			this.characterNumLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.characterNumLabel.Visible = false;
			// 
			// toolTip1
			// 
			this.toolTip1.Active = false;
			// 
			// toolTip2
			// 
			this.toolTip2.IsBalloon = true;
			this.toolTip2.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Warning;
			this.toolTip2.ToolTipTitle = "WARNING";
			// 
			// toolStrip2
			// 
			this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.save,
            this.toolStripSeparator11,
            this.import,
            this.export,
            this.reset,
            this.clear,
            this.toolStripSeparator12,
            this.helpTips,
            this.baseConvertor,
            this.hexEditor,
            this.toolStripSeparator2,
            this.npcPacketButton});
			this.toolStrip2.Location = new System.Drawing.Point(0, 0);
			this.toolStrip2.Name = "toolStrip2";
			this.toolStrip2.Size = new System.Drawing.Size(989, 25);
			this.toolStrip2.TabIndex = 0;
			// 
			// save
			// 
			this.save.Image = global::LAZYSHELL.Properties.Resources.save;
			this.save.Name = "save";
			this.save.Size = new System.Drawing.Size(23, 22);
			this.save.ToolTipText = "Save";
			this.save.Click += new System.EventHandler(this.save_Click);
			// 
			// toolStripSeparator11
			// 
			this.toolStripSeparator11.Name = "toolStripSeparator11";
			this.toolStripSeparator11.Size = new System.Drawing.Size(6, 25);
			// 
			// import
			// 
			this.import.Image = global::LAZYSHELL.Properties.Resources.importData;
			this.import.Name = "import";
			this.import.Size = new System.Drawing.Size(23, 22);
			this.import.ToolTipText = "Import";
			this.import.Click += new System.EventHandler(this.import_Click);
			// 
			// export
			// 
			this.export.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportAnimations,
            this.exportMoldImages});
			this.export.Image = global::LAZYSHELL.Properties.Resources.exportData;
			this.export.Name = "export";
			this.export.Size = new System.Drawing.Size(29, 22);
			// 
			// exportAnimations
			// 
			this.exportAnimations.Name = "exportAnimations";
			this.exportAnimations.Size = new System.Drawing.Size(162, 22);
			this.exportAnimations.Text = "Animation(s)...";
			this.exportAnimations.Click += new System.EventHandler(this.export_Click);
			// 
			// exportMoldImages
			// 
			this.exportMoldImages.Image = global::LAZYSHELL.Properties.Resources.exportImage;
			this.exportMoldImages.Name = "exportMoldImages";
			this.exportMoldImages.Size = new System.Drawing.Size(162, 22);
			this.exportMoldImages.Text = "Sprite image(s)...";
			this.exportMoldImages.Click += new System.EventHandler(this.exportMoldImages_Click);
			// 
			// reset
			// 
			this.reset.Image = global::LAZYSHELL.Properties.Resources.reset;
			this.reset.Name = "reset";
			this.reset.Size = new System.Drawing.Size(23, 22);
			this.reset.ToolTipText = "Reset";
			this.reset.Click += new System.EventHandler(this.reset_Click);
			// 
			// clear
			// 
			this.clear.Image = global::LAZYSHELL.Properties.Resources.clear;
			this.clear.Name = "clear";
			this.clear.Size = new System.Drawing.Size(23, 22);
			this.clear.ToolTipText = "Clear";
			this.clear.Click += new System.EventHandler(this.clear_Click);
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
			// hexEditor
			// 
			this.hexEditor.Image = global::LAZYSHELL.Properties.Resources.hexEditor;
			this.hexEditor.Name = "hexEditor";
			this.hexEditor.Size = new System.Drawing.Size(23, 22);
			this.hexEditor.ToolTipText = "Hex Editor";
			this.hexEditor.Click += new System.EventHandler(this.hexViewer_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
			// 
			// npcPacketButton
			// 
			this.npcPacketButton.Image = global::LAZYSHELL.Properties.Resources.openPackets;
			this.npcPacketButton.Name = "npcPacketButton";
			this.npcPacketButton.Size = new System.Drawing.Size(23, 22);
			this.npcPacketButton.ToolTipText = "NPC Packets";
			this.npcPacketButton.Click += new System.EventHandler(this.openNPCPackets_Click);
			// 
			// toolStrip3
			// 
			this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.name,
            this.searchEffectNames,
            this.num,
            this.toolStripSeparator1,
            this.toggleProperties,
            this.toggleMolds,
            this.toggleSequences,
            this.toolStripSeparator3,
            this.openPalettes,
            this.openGraphics,
            this.findReferences});
			this.toolStrip3.Location = new System.Drawing.Point(0, 25);
			this.toolStrip3.Name = "toolStrip3";
			this.toolStrip3.Size = new System.Drawing.Size(989, 25);
			this.toolStrip3.TabIndex = 1;
			// 
			// name
			// 
			this.name.DropDownHeight = 500;
			this.name.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.name.DropDownWidth = 350;
			this.name.IntegralHeight = false;
			this.name.Name = "name";
			this.name.Size = new System.Drawing.Size(214, 25);
			this.name.SelectedIndexChanged += new System.EventHandler(this.name_SelectedIndexChanged);
			// 
			// searchEffectNames
			// 
			this.searchEffectNames.Image = global::LAZYSHELL.Properties.Resources.search;
			this.searchEffectNames.Name = "searchEffectNames";
			this.searchEffectNames.Size = new System.Drawing.Size(23, 22);
			this.searchEffectNames.ToolTipText = "Search for sprite";
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// toggleProperties
			// 
			this.toggleProperties.CheckOnClick = true;
			this.toggleProperties.Form = null;
			this.toggleProperties.Image = global::LAZYSHELL.Properties.Resources.showMain;
			this.toggleProperties.Name = "toggleProperties";
			this.toggleProperties.Size = new System.Drawing.Size(23, 22);
			this.toggleProperties.ToolTipText = "Main";
			// 
			// toggleMolds
			// 
			this.toggleMolds.CheckOnClick = true;
			this.toggleMolds.Form = null;
			this.toggleMolds.Image = global::LAZYSHELL.Properties.Resources.openMolds;
			this.toggleMolds.Name = "toggleMolds";
			this.toggleMolds.Size = new System.Drawing.Size(23, 22);
			this.toggleMolds.ToolTipText = "Molds";
			this.toggleMolds.Click += new System.EventHandler(this.openMolds_Click);
			// 
			// toggleSequences
			// 
			this.toggleSequences.CheckOnClick = true;
			this.toggleSequences.Form = null;
			this.toggleSequences.Image = global::LAZYSHELL.Properties.Resources.openSequences;
			this.toggleSequences.Name = "toggleSequences";
			this.toggleSequences.Size = new System.Drawing.Size(23, 22);
			this.toggleSequences.ToolTipText = "Sequences";
			this.toggleSequences.Click += new System.EventHandler(this.openSequences_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
			// 
			// openPalettes
			// 
			this.openPalettes.Image = global::LAZYSHELL.Properties.Resources.openPalettes;
			this.openPalettes.Name = "openPalettes";
			this.openPalettes.Size = new System.Drawing.Size(23, 22);
			this.openPalettes.ToolTipText = "Palettes";
			this.openPalettes.Click += new System.EventHandler(this.openPalettes_Click);
			// 
			// openGraphics
			// 
			this.openGraphics.Image = global::LAZYSHELL.Properties.Resources.openGraphics;
			this.openGraphics.Name = "openGraphics";
			this.openGraphics.Size = new System.Drawing.Size(23, 22);
			this.openGraphics.ToolTipText = "BPP Graphics";
			this.openGraphics.Click += new System.EventHandler(this.openGraphics_Click);
			// 
			// findReferences
			// 
			this.findReferences.Image = global::LAZYSHELL.Properties.Resources.findReferences;
			this.findReferences.Name = "findReferences";
			this.findReferences.Size = new System.Drawing.Size(23, 22);
			this.findReferences.ToolTipText = "Find all references to sprite";
			this.findReferences.Click += new System.EventHandler(this.findReferences_Click);
			// 
			// toolTip3
			// 
			this.toolTip3.Active = false;
			// 
			// dockPanel
			// 
			this.dockPanel.BackColor = System.Drawing.SystemColors.ControlDark;
			this.dockPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dockPanel.Location = new System.Drawing.Point(0, 50);
			this.dockPanel.Name = "dockPanel";
			this.dockPanel.Size = new System.Drawing.Size(989, 626);
			this.dockPanel.TabIndex = 6;
			// 
			// OwnerForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(989, 676);
			this.Controls.Add(this.dockPanel);
			this.Controls.Add(this.toolStrip3);
			this.Controls.Add(this.toolStrip2);
			this.Controls.Add(this.characterNumLabel);
			this.IsMdiContainer = true;
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(0, 0);
			this.Name = "OwnerForm";
			this.Text = "SPRITES - Lazy Shell";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OwnerForm_FormClosing);
			this.toolStrip2.ResumeLayout(false);
			this.toolStrip2.PerformLayout();
			this.toolStrip3.ResumeLayout(false);
			this.toolStrip3.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }
        #endregion
        private BackgroundWorker PlaybackSequence;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripSeparator toolStripSeparator6;
        private ToolStripSeparator toolStripSeparator7;
        private ToolStripSeparator toolStripSeparator8;
        private ToolTip toolTip1;
        private ToolTip toolTip2;
        private Label characterNumLabel;
        private ToolStrip toolStrip2;
        private ToolStripButton save;
        private ToolStripSeparator toolStripSeparator11;
        private ToolStripButton import;
        private ToolStripButton clear;
        private ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripComboBox name;
        private ToolStripButton searchEffectNames;
        private ToolStripSeparator toolStripSeparator1;
        private Controls.NewToolStripButton toggleProperties;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripButton openPalettes;
        private ToolStripButton openGraphics;
        private Controls.NewToolStripButton toggleMolds;
        private Controls.NewToolStripButton toggleSequences;
        private ToolStripSeparator toolStripSeparator12;
        private ToolStripButton helpTips;
        private ToolStripButton baseConvertor;
        private ToolStripDropDownButton export;
        private ToolStripMenuItem exportMoldImages;
        private ToolStripMenuItem exportAnimations;
        private Controls.NewToolStripNumericUpDown num;
        private ToolTip toolTip3;
        private ToolStripButton hexEditor;
        private ToolStripButton reset;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton npcPacketButton;
        private ToolStripButton findReferences;
        private WeifenLuo.WinFormsUI.Docking.DockPanel dockPanel;
    }
}

