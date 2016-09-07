using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace LAZYSHELL.Areas
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
			this.importAreaData = new System.Windows.Forms.ToolStripMenuItem();
			this.areaInfo = new LAZYSHELL.Controls.NewToolStripListView();
			this.areaName = new System.Windows.Forms.ToolStripComboBox();
			this.areaNum = new LAZYSHELL.Controls.NewToolStripNumericUpDown();
			this.exportArrays = new System.Windows.Forms.ToolStripMenuItem();
			this.importArrays = new System.Windows.Forms.ToolStripMenuItem();
			this.baseConvertor = new LAZYSHELL.Controls.NewToolStripButton();
			this.clear = new System.Windows.Forms.ToolStripDropDownButton();
			this.clearAllAreaData = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator38 = new System.Windows.Forms.ToolStripSeparator();
			this.clearAllTilesets = new System.Windows.Forms.ToolStripMenuItem();
			this.clearAllTilemaps = new System.Windows.Forms.ToolStripMenuItem();
			this.clearAllCollisionMaps = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator29 = new System.Windows.Forms.ToolStripSeparator();
			this.clearUnusedGraphicSets = new System.Windows.Forms.ToolStripMenuItem();
			this.clearUnusedTilesets = new System.Windows.Forms.ToolStripMenuItem();
			this.clearUnusedTilemaps = new System.Windows.Forms.ToolStripMenuItem();
			this.clearUnusedCollisionMaps = new System.Windows.Forms.ToolStripMenuItem();
			this.clearUnusedAll = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
			this.clearAllComponentsAll = new System.Windows.Forms.ToolStripMenuItem();
			this.clearAllComponentsCurrent = new System.Windows.Forms.ToolStripMenuItem();
			this.dumpText = new System.Windows.Forms.ToolStripMenuItem();
			this.export = new System.Windows.Forms.ToolStripDropDownButton();
			this.exportAreaData = new System.Windows.Forms.ToolStripMenuItem();
			this.exportArchitecture = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator28 = new System.Windows.Forms.ToolStripSeparator();
			this.exportGraphicSets = new System.Windows.Forms.ToolStripMenuItem();
			this.exportImages = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator32 = new System.Windows.Forms.ToolStripSeparator();
			this.importGraphicSet = new System.Windows.Forms.ToolStripMenuItem();
			this.helpTips = new LAZYSHELL.Controls.NewToolStripButton();
			this.hexEditor = new LAZYSHELL.Controls.NewToolStripButton();
			this.import = new System.Windows.Forms.ToolStripDropDownButton();
			this.importArchitecture = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator30 = new System.Windows.Forms.ToolStripSeparator();
			this.navigateBck = new LAZYSHELL.Controls.NewToolStripButton();
			this.navigateFwd = new LAZYSHELL.Controls.NewToolStripButton();
			this.openSpaceAnalyzer = new LAZYSHELL.Controls.NewToolStripButton();
			this.reset = new System.Windows.Forms.ToolStripDropDownButton();
			this.resetMap = new System.Windows.Forms.ToolStripMenuItem();
			this.resetLayering = new System.Windows.Forms.ToolStripMenuItem();
			this.resetNPCs = new System.Windows.Forms.ToolStripMenuItem();
			this.resetEvents = new System.Windows.Forms.ToolStripMenuItem();
			this.resetExits = new System.Windows.Forms.ToolStripMenuItem();
			this.resetOverlaps = new System.Windows.Forms.ToolStripMenuItem();
			this.resetTileSwitches = new System.Windows.Forms.ToolStripMenuItem();
			this.resetCollisionSwitches = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.resetPaletteSet = new System.Windows.Forms.ToolStripMenuItem();
			this.resetGraphicSet = new System.Windows.Forms.ToolStripMenuItem();
			this.resetTilesets = new System.Windows.Forms.ToolStripMenuItem();
			this.resetTilemaps = new System.Windows.Forms.ToolStripMenuItem();
			this.resetCollisionMap = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.resetAllElements = new System.Windows.Forms.ToolStripMenuItem();
			this.save = new LAZYSHELL.Controls.NewToolStripButton();
			this.searchLocationNames = new LAZYSHELL.Controls.NewToolStripButton();
			this.toggleChunksForm = new LAZYSHELL.Controls.NewToolStripButton();
			this.toggleCollisionSwitchesForm = new LAZYSHELL.Controls.NewToolStripButton();
			this.toggleCollisionTileForm = new LAZYSHELL.Controls.NewToolStripButton();
			this.toggleEventsForm = new LAZYSHELL.Controls.NewToolStripButton();
			this.toggleExitsForm = new LAZYSHELL.Controls.NewToolStripButton();
			this.openGraphicEditor = new LAZYSHELL.Controls.NewToolStripButton();
			this.toggleLayeringForm = new LAZYSHELL.Controls.NewToolStripButton();
			this.toggleMapForm = new LAZYSHELL.Controls.NewToolStripButton();
			this.toggleNPCsForm = new LAZYSHELL.Controls.NewToolStripButton();
			this.toggleOverlapsForm = new LAZYSHELL.Controls.NewToolStripButton();
			this.openPaletteEditor = new LAZYSHELL.Controls.NewToolStripButton();
			this.openPreviewerForm = new LAZYSHELL.Controls.NewToolStripButton();
			this.togglePriorityForm = new LAZYSHELL.Controls.NewToolStripButton();
			this.togglePropertiesForm = new LAZYSHELL.Controls.NewToolStripButton();
			this.toggleTileSwitchesForm = new LAZYSHELL.Controls.NewToolStripButton();
			this.toggleTilemapForm = new LAZYSHELL.Controls.NewToolStripButton();
			this.toggleTilesetL1Form = new LAZYSHELL.Controls.NewToolStripButton();
			this.toolStripArea = new System.Windows.Forms.ToolStrip();
			this.findReferences = new System.Windows.Forms.ToolStripButton();
			this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripSeparator15 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripToggle = new System.Windows.Forms.ToolStrip();
			this.statistics = new System.Windows.Forms.ToolStripButton();
			this.viewAreaInfo = new System.Windows.Forms.ToolStripDropDownButton();
			this.toggleTilesetL2Form = new LAZYSHELL.Controls.NewToolStripButton();
			this.toggleTilesetL3Form = new LAZYSHELL.Controls.NewToolStripButton();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.dockPanel = new WeifenLuo.WinFormsUI.Docking.DockPanel();
			this.dockPanel.Theme = new VS2013BlueTheme();
			this.toolStripArea.SuspendLayout();
			this.toolStripToggle.SuspendLayout();
			this.SuspendLayout();
			// 
			// importAreaData
			// 
			this.importAreaData.Name = "importAreaData";
			this.importAreaData.Size = new System.Drawing.Size(187, 22);
			this.importAreaData.Text = "Import Area Data...";
			this.importAreaData.Click += new System.EventHandler(this.importAreaData_Click);
			// 
			// areaInfo
			// 
			this.areaInfo.AutoSize = false;
			this.areaInfo.Name = "areaInfo";
			this.areaInfo.Size = new System.Drawing.Size(140, 160);
			this.areaInfo.View = System.Windows.Forms.View.Details;
			// 
			// areaName
			// 
			this.areaName.AutoSize = false;
			this.areaName.DropDownHeight = 500;
			this.areaName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.areaName.DropDownWidth = 500;
			this.areaName.IntegralHeight = false;
			this.areaName.Name = "areaName";
			this.areaName.Size = new System.Drawing.Size(280, 23);
			this.areaName.SelectedIndexChanged += new System.EventHandler(this.areaName_SelectedIndexChanged);
			// 
			// areaNum
			// 
			this.areaNum.AutoSize = false;
			this.areaNum.ContextMenuStrip = null;
			this.areaNum.Hexadecimal = false;
			this.areaNum.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.areaNum.Location = new System.Drawing.Point(314, 1);
			this.areaNum.Maximum = new decimal(new int[] {
            509,
            0,
            0,
            0});
			this.areaNum.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
			this.areaNum.Name = "areaNum";
			this.areaNum.Size = new System.Drawing.Size(60, 21);
			this.areaNum.Text = "0";
			this.areaNum.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
			this.areaNum.ValueChanged += new System.EventHandler(this.areaNum_ValueChanged);
			// 
			// exportArrays
			// 
			this.exportArrays.Image = global::LAZYSHELL.Properties.Resources.exportBinary;
			this.exportArrays.Name = "exportArrays";
			this.exportArrays.Size = new System.Drawing.Size(186, 22);
			this.exportArrays.Text = "Export Arrays...";
			this.exportArrays.Click += new System.EventHandler(this.exportArrays_Click);
			// 
			// importArrays
			// 
			this.importArrays.Image = global::LAZYSHELL.Properties.Resources.importBinary;
			this.importArrays.Name = "importArrays";
			this.importArrays.Size = new System.Drawing.Size(187, 22);
			this.importArrays.Text = "Import Arrays...";
			this.importArrays.Click += new System.EventHandler(this.importArrays_Click);
			// 
			// baseConvertor
			// 
			this.baseConvertor.CheckOnClick = true;
			this.baseConvertor.Form = null;
			this.baseConvertor.Image = global::LAZYSHELL.Properties.Resources.baseConversion;
			this.baseConvertor.Name = "baseConvertor";
			this.baseConvertor.Size = new System.Drawing.Size(23, 22);
			this.baseConvertor.ToolTipText = "Base Convertor";
			// 
			// clear
			// 
			this.clear.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearAllAreaData,
            this.toolStripSeparator38,
            this.clearAllTilesets,
            this.clearAllTilemaps,
            this.clearAllCollisionMaps,
            this.toolStripSeparator29,
            this.clearUnusedGraphicSets,
            this.clearUnusedTilesets,
            this.clearUnusedTilemaps,
            this.clearUnusedCollisionMaps,
            this.clearUnusedAll,
            this.toolStripSeparator8,
            this.clearAllComponentsAll,
            this.clearAllComponentsCurrent});
			this.clear.Image = global::LAZYSHELL.Properties.Resources.clear;
			this.clear.Name = "clear";
			this.clear.Size = new System.Drawing.Size(29, 22);
			// 
			// clearAllAreaData
			// 
			this.clearAllAreaData.Name = "clearAllAreaData";
			this.clearAllAreaData.Size = new System.Drawing.Size(218, 22);
			this.clearAllAreaData.Text = "Area Data...";
			this.clearAllAreaData.Click += new System.EventHandler(this.clearAllAreaData_Click);
			// 
			// toolStripSeparator38
			// 
			this.toolStripSeparator38.Name = "toolStripSeparator38";
			this.toolStripSeparator38.Size = new System.Drawing.Size(215, 6);
			// 
			// clearAllTilesets
			// 
			this.clearAllTilesets.Name = "clearAllTilesets";
			this.clearAllTilesets.Size = new System.Drawing.Size(218, 22);
			this.clearAllTilesets.Text = "Tilesets...";
			this.clearAllTilesets.Click += new System.EventHandler(this.clearAllTilesets_Click);
			// 
			// clearAllTilemaps
			// 
			this.clearAllTilemaps.Name = "clearAllTilemaps";
			this.clearAllTilemaps.Size = new System.Drawing.Size(218, 22);
			this.clearAllTilemaps.Text = "Tilemaps...";
			this.clearAllTilemaps.Click += new System.EventHandler(this.clearAllTilemaps_Click);
			// 
			// clearAllCollisionMaps
			// 
			this.clearAllCollisionMaps.Name = "clearAllCollisionMaps";
			this.clearAllCollisionMaps.Size = new System.Drawing.Size(218, 22);
			this.clearAllCollisionMaps.Text = "Collision Maps...";
			this.clearAllCollisionMaps.Click += new System.EventHandler(this.clearAllCollisionMaps_Click);
			// 
			// toolStripSeparator29
			// 
			this.toolStripSeparator29.Name = "toolStripSeparator29";
			this.toolStripSeparator29.Size = new System.Drawing.Size(215, 6);
			// 
			// clearUnusedGraphicSets
			// 
			this.clearUnusedGraphicSets.Name = "clearUnusedGraphicSets";
			this.clearUnusedGraphicSets.Size = new System.Drawing.Size(218, 22);
			this.clearUnusedGraphicSets.Text = "Unused graphic sets...";
			this.clearUnusedGraphicSets.Click += new System.EventHandler(this.clearUnusedGraphicSets_Click);
			// 
			// clearUnusedTilesets
			// 
			this.clearUnusedTilesets.Name = "clearUnusedTilesets";
			this.clearUnusedTilesets.Size = new System.Drawing.Size(218, 22);
			this.clearUnusedTilesets.Text = "Unused tilesets...";
			this.clearUnusedTilesets.Click += new System.EventHandler(this.clearUnusedTilesets_Click);
			// 
			// clearUnusedTilemaps
			// 
			this.clearUnusedTilemaps.Name = "clearUnusedTilemaps";
			this.clearUnusedTilemaps.Size = new System.Drawing.Size(218, 22);
			this.clearUnusedTilemaps.Text = "Unused tilemaps...";
			this.clearUnusedTilemaps.Click += new System.EventHandler(this.clearUnusedTilemaps_Click);
			// 
			// clearUnusedCollisionMaps
			// 
			this.clearUnusedCollisionMaps.Name = "clearUnusedCollisionMaps";
			this.clearUnusedCollisionMaps.Size = new System.Drawing.Size(218, 22);
			this.clearUnusedCollisionMaps.Text = "Unused collision maps...";
			this.clearUnusedCollisionMaps.Click += new System.EventHandler(this.clearUnusedCollisionMaps_Click);
			// 
			// clearUnusedAll
			// 
			this.clearUnusedAll.Name = "clearUnusedAll";
			this.clearUnusedAll.Size = new System.Drawing.Size(218, 22);
			this.clearUnusedAll.Text = "Unused (all components)...";
			this.clearUnusedAll.Click += new System.EventHandler(this.clearUnusedAll_Click);
			// 
			// toolStripSeparator8
			// 
			this.toolStripSeparator8.Name = "toolStripSeparator8";
			this.toolStripSeparator8.Size = new System.Drawing.Size(215, 6);
			// 
			// clearAllComponentsAll
			// 
			this.clearAllComponentsAll.Name = "clearAllComponentsAll";
			this.clearAllComponentsAll.Size = new System.Drawing.Size(218, 22);
			this.clearAllComponentsAll.Text = "All Components (all)...";
			this.clearAllComponentsAll.Click += new System.EventHandler(this.clearAllComponentsAll_Click);
			// 
			// clearAllComponentsCurrent
			// 
			this.clearAllComponentsCurrent.Name = "clearAllComponentsCurrent";
			this.clearAllComponentsCurrent.Size = new System.Drawing.Size(218, 22);
			this.clearAllComponentsCurrent.Text = "All Components (current)...";
			this.clearAllComponentsCurrent.Click += new System.EventHandler(this.clearAllComponentsCurrent_Click);
			// 
			// dumpText
			// 
			this.dumpText.Image = global::LAZYSHELL.Properties.Resources.exportText;
			this.dumpText.Name = "dumpText";
			this.dumpText.Size = new System.Drawing.Size(186, 22);
			this.dumpText.Text = "Dump NPCs to Text...";
			this.dumpText.Click += new System.EventHandler(this.dumpText_Click);
			// 
			// export
			// 
			this.export.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportAreaData,
            this.exportArchitecture,
            this.toolStripSeparator28,
            this.exportArrays,
            this.exportGraphicSets,
            this.exportImages,
            this.toolStripSeparator32,
            this.dumpText});
			this.export.Image = global::LAZYSHELL.Properties.Resources.exportData;
			this.export.Name = "export";
			this.export.Size = new System.Drawing.Size(29, 22);
			// 
			// exportAreaData
			// 
			this.exportAreaData.Name = "exportAreaData";
			this.exportAreaData.Size = new System.Drawing.Size(186, 22);
			this.exportAreaData.Text = "Export Area Data...";
			this.exportAreaData.Click += new System.EventHandler(this.exportAreaData_Click);
			// 
			// exportArchitecture
			// 
			this.exportArchitecture.Image = global::LAZYSHELL.Properties.Resources.exportBinary;
			this.exportArchitecture.Name = "exportArchitecture";
			this.exportArchitecture.Size = new System.Drawing.Size(186, 22);
			this.exportArchitecture.Text = "Export Architecture...";
			this.exportArchitecture.Click += new System.EventHandler(this.exportArchitecture_Click);
			// 
			// toolStripSeparator28
			// 
			this.toolStripSeparator28.Name = "toolStripSeparator28";
			this.toolStripSeparator28.Size = new System.Drawing.Size(183, 6);
			// 
			// exportGraphicSets
			// 
			this.exportGraphicSets.Image = global::LAZYSHELL.Properties.Resources.exportBinary;
			this.exportGraphicSets.Name = "exportGraphicSets";
			this.exportGraphicSets.Size = new System.Drawing.Size(186, 22);
			this.exportGraphicSets.Text = "Export Graphic Sets...";
			this.exportGraphicSets.Click += new System.EventHandler(this.exportGraphicSets_Click);
			// 
			// exportImages
			// 
			this.exportImages.Image = global::LAZYSHELL.Properties.Resources.exportImage;
			this.exportImages.Name = "exportImages";
			this.exportImages.Size = new System.Drawing.Size(186, 22);
			this.exportImages.Text = "Export Area Images...";
			this.exportImages.Click += new System.EventHandler(this.exportImages_Click);
			// 
			// toolStripSeparator32
			// 
			this.toolStripSeparator32.Name = "toolStripSeparator32";
			this.toolStripSeparator32.Size = new System.Drawing.Size(183, 6);
			// 
			// importGraphicSet
			// 
			this.importGraphicSet.Image = global::LAZYSHELL.Properties.Resources.importBinary;
			this.importGraphicSet.Name = "importGraphicSet";
			this.importGraphicSet.Size = new System.Drawing.Size(187, 22);
			this.importGraphicSet.Text = "Import Graphic Set...";
			this.importGraphicSet.Click += new System.EventHandler(this.importGraphicSet_Click);
			// 
			// helpTips
			// 
			this.helpTips.CheckOnClick = true;
			this.helpTips.Form = null;
			this.helpTips.Image = global::LAZYSHELL.Properties.Resources.help;
			this.helpTips.Name = "helpTips";
			this.helpTips.Size = new System.Drawing.Size(23, 22);
			this.helpTips.ToolTipText = "Help Tips";
			// 
			// hexEditor
			// 
			this.hexEditor.Form = null;
			this.hexEditor.Image = global::LAZYSHELL.Properties.Resources.hexEditor;
			this.hexEditor.Name = "hexEditor";
			this.hexEditor.Size = new System.Drawing.Size(23, 22);
			this.hexEditor.ToolTipText = "Hex Editor";
			this.hexEditor.Click += new System.EventHandler(this.hexEditor_Click);
			// 
			// import
			// 
			this.import.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importAreaData,
            this.importArchitecture,
            this.toolStripSeparator30,
            this.importArrays,
            this.importGraphicSet});
			this.import.Image = global::LAZYSHELL.Properties.Resources.importData;
			this.import.Name = "import";
			this.import.Size = new System.Drawing.Size(29, 22);
			// 
			// importArchitecture
			// 
			this.importArchitecture.Image = global::LAZYSHELL.Properties.Resources.importBinary;
			this.importArchitecture.Name = "importArchitecture";
			this.importArchitecture.Size = new System.Drawing.Size(187, 22);
			this.importArchitecture.Text = "Import Architecture...";
			this.importArchitecture.Click += new System.EventHandler(this.importArchitecture_Click);
			// 
			// toolStripSeparator30
			// 
			this.toolStripSeparator30.Name = "toolStripSeparator30";
			this.toolStripSeparator30.Size = new System.Drawing.Size(184, 6);
			// 
			// navigateBck
			// 
			this.navigateBck.Enabled = false;
			this.navigateBck.Form = null;
			this.navigateBck.Image = global::LAZYSHELL.Properties.Resources.back;
			this.navigateBck.Name = "navigateBck";
			this.navigateBck.Size = new System.Drawing.Size(23, 22);
			this.navigateBck.ToolTipText = "Navigate Backward";
			this.navigateBck.Click += new System.EventHandler(this.navigateBck_Click);
			// 
			// navigateFwd
			// 
			this.navigateFwd.Enabled = false;
			this.navigateFwd.Form = null;
			this.navigateFwd.Image = global::LAZYSHELL.Properties.Resources.foward;
			this.navigateFwd.Name = "navigateFwd";
			this.navigateFwd.Size = new System.Drawing.Size(23, 22);
			this.navigateFwd.ToolTipText = "Navigate Forward";
			this.navigateFwd.Click += new System.EventHandler(this.navigateFwd_Click);
			// 
			// openSpaceAnalyzer
			// 
			this.openSpaceAnalyzer.Form = null;
			this.openSpaceAnalyzer.Image = global::LAZYSHELL.Properties.Resources.spaceAnalyzer;
			this.openSpaceAnalyzer.Name = "openSpaceAnalyzer";
			this.openSpaceAnalyzer.Size = new System.Drawing.Size(23, 22);
			this.openSpaceAnalyzer.ToolTipText = "Open space analyzer";
			this.openSpaceAnalyzer.Click += new System.EventHandler(this.openSpaceAnalyzer_Click);
			// 
			// reset
			// 
			this.reset.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.resetMap,
            this.resetLayering,
            this.resetNPCs,
            this.resetEvents,
            this.resetExits,
            this.resetOverlaps,
            this.resetTileSwitches,
            this.resetCollisionSwitches,
            this.toolStripSeparator3,
            this.resetPaletteSet,
            this.resetGraphicSet,
            this.resetTilesets,
            this.resetTilemaps,
            this.resetCollisionMap,
            this.toolStripSeparator4,
            this.resetAllElements});
			this.reset.Image = global::LAZYSHELL.Properties.Resources.reset;
			this.reset.Name = "reset";
			this.reset.Size = new System.Drawing.Size(29, 22);
			// 
			// resetMap
			// 
			this.resetMap.Name = "resetMap";
			this.resetMap.Size = new System.Drawing.Size(203, 22);
			this.resetMap.Text = "Reset map properties";
			this.resetMap.Click += new System.EventHandler(this.resetMap_Click);
			// 
			// resetLayering
			// 
			this.resetLayering.Name = "resetLayering";
			this.resetLayering.Size = new System.Drawing.Size(203, 22);
			this.resetLayering.Text = "Reset layering properties";
			this.resetLayering.Click += new System.EventHandler(this.resetLayering_Click);
			// 
			// resetNPCs
			// 
			this.resetNPCs.Name = "resetNPCs";
			this.resetNPCs.Size = new System.Drawing.Size(203, 22);
			this.resetNPCs.Text = "Reset NPC collection";
			this.resetNPCs.Click += new System.EventHandler(this.resetNPCs_Click);
			// 
			// resetEvents
			// 
			this.resetEvents.Name = "resetEvents";
			this.resetEvents.Size = new System.Drawing.Size(203, 22);
			this.resetEvents.Text = "Reset event triggers";
			this.resetEvents.Click += new System.EventHandler(this.resetEvents_Click);
			// 
			// resetExits
			// 
			this.resetExits.Name = "resetExits";
			this.resetExits.Size = new System.Drawing.Size(203, 22);
			this.resetExits.Text = "Reset exit triggers";
			// 
			// resetOverlaps
			// 
			this.resetOverlaps.Name = "resetOverlaps";
			this.resetOverlaps.Size = new System.Drawing.Size(203, 22);
			this.resetOverlaps.Text = "Reset overlaps";
			this.resetOverlaps.Click += new System.EventHandler(this.resetOverlaps_Click);
			// 
			// resetTileSwitches
			// 
			this.resetTileSwitches.Name = "resetTileSwitches";
			this.resetTileSwitches.Size = new System.Drawing.Size(203, 22);
			this.resetTileSwitches.Text = "Reset tilemap switches";
			this.resetTileSwitches.Click += new System.EventHandler(this.resetTileSwitches_Click);
			// 
			// resetCollisionSwitches
			// 
			this.resetCollisionSwitches.Name = "resetCollisionSwitches";
			this.resetCollisionSwitches.Size = new System.Drawing.Size(203, 22);
			this.resetCollisionSwitches.Text = "Reset collision switches";
			this.resetCollisionSwitches.Click += new System.EventHandler(this.resetCollisionSwitches_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(200, 6);
			// 
			// resetPaletteSet
			// 
			this.resetPaletteSet.Name = "resetPaletteSet";
			this.resetPaletteSet.Size = new System.Drawing.Size(203, 22);
			this.resetPaletteSet.Text = "Reset palette set";
			this.resetPaletteSet.Click += new System.EventHandler(this.resetPaletteSet_Click);
			// 
			// resetGraphicSet
			// 
			this.resetGraphicSet.Name = "resetGraphicSet";
			this.resetGraphicSet.Size = new System.Drawing.Size(203, 22);
			this.resetGraphicSet.Text = "Reset graphic set";
			this.resetGraphicSet.Click += new System.EventHandler(this.resetGraphicSet_Click);
			// 
			// resetTilesets
			// 
			this.resetTilesets.Name = "resetTilesets";
			this.resetTilesets.Size = new System.Drawing.Size(203, 22);
			this.resetTilesets.Text = "Reset tilesets";
			this.resetTilesets.Click += new System.EventHandler(this.resetTilesets_Click);
			// 
			// resetTilemaps
			// 
			this.resetTilemaps.Name = "resetTilemaps";
			this.resetTilemaps.Size = new System.Drawing.Size(203, 22);
			this.resetTilemaps.Text = "Reset tilemaps";
			this.resetTilemaps.Click += new System.EventHandler(this.resetTilemaps_Click);
			// 
			// resetCollisionMap
			// 
			this.resetCollisionMap.Name = "resetCollisionMap";
			this.resetCollisionMap.Size = new System.Drawing.Size(203, 22);
			this.resetCollisionMap.Text = "Reset collision map";
			this.resetCollisionMap.Click += new System.EventHandler(this.resetCollisionMap_Click);
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(200, 6);
			// 
			// resetAllElements
			// 
			this.resetAllElements.Name = "resetAllElements";
			this.resetAllElements.Size = new System.Drawing.Size(203, 22);
			this.resetAllElements.Text = "Reset all elements";
			this.resetAllElements.Click += new System.EventHandler(this.resetAllElements_Click);
			// 
			// save
			// 
			this.save.Form = null;
			this.save.Image = global::LAZYSHELL.Properties.Resources.save;
			this.save.Name = "save";
			this.save.Size = new System.Drawing.Size(23, 22);
			this.save.ToolTipText = "Save";
			this.save.Click += new System.EventHandler(this.save_Click);
			// 
			// searchLocationNames
			// 
			this.searchLocationNames.Form = null;
			this.searchLocationNames.Image = global::LAZYSHELL.Properties.Resources.search;
			this.searchLocationNames.Name = "searchLocationNames";
			this.searchLocationNames.Size = new System.Drawing.Size(23, 22);
			this.searchLocationNames.ToolTipText = "Search Area Names";
			// 
			// toggleChunksForm
			// 
			this.toggleChunksForm.CheckOnClick = true;
			this.toggleChunksForm.Form = null;
			this.toggleChunksForm.Image = global::LAZYSHELL.Properties.Resources.openTemplates;
			this.toggleChunksForm.Name = "toggleChunksForm";
			this.toggleChunksForm.Size = new System.Drawing.Size(23, 22);
			this.toggleChunksForm.ToolTipText = "Chunk Collection Window";
			// 
			// toggleCollisionSwitchesForm
			// 
			this.toggleCollisionSwitchesForm.CheckOnClick = true;
			this.toggleCollisionSwitchesForm.Form = null;
			this.toggleCollisionSwitchesForm.Image = global::LAZYSHELL.Properties.Resources.toggleCollisionSwitches;
			this.toggleCollisionSwitchesForm.Name = "toggleCollisionSwitchesForm";
			this.toggleCollisionSwitchesForm.Size = new System.Drawing.Size(23, 22);
			this.toggleCollisionSwitchesForm.ToolTipText = "Collision Switches Window";
			// 
			// toggleCollisionTileForm
			// 
			this.toggleCollisionTileForm.CheckOnClick = true;
			this.toggleCollisionTileForm.Form = null;
			this.toggleCollisionTileForm.Image = global::LAZYSHELL.Properties.Resources.buttonPhysicalTiles;
			this.toggleCollisionTileForm.Name = "toggleCollisionTileForm";
			this.toggleCollisionTileForm.Size = new System.Drawing.Size(23, 22);
			this.toggleCollisionTileForm.ToolTipText = "Collision Tile Window";
			// 
			// toggleEventsForm
			// 
			this.toggleEventsForm.CheckOnClick = true;
			this.toggleEventsForm.Form = null;
			this.toggleEventsForm.Image = global::LAZYSHELL.Properties.Resources.toggleEvents;
			this.toggleEventsForm.Name = "toggleEventsForm";
			this.toggleEventsForm.Size = new System.Drawing.Size(23, 22);
			this.toggleEventsForm.ToolTipText = "Event Triggers Window";
			// 
			// toggleExitsForm
			// 
			this.toggleExitsForm.CheckOnClick = true;
			this.toggleExitsForm.Form = null;
			this.toggleExitsForm.Image = global::LAZYSHELL.Properties.Resources.toggleExits;
			this.toggleExitsForm.Name = "toggleExitsForm";
			this.toggleExitsForm.Size = new System.Drawing.Size(23, 22);
			this.toggleExitsForm.ToolTipText = "Exit Triggers Window";
			// 
			// openGraphicEditor
			// 
			this.openGraphicEditor.Form = null;
			this.openGraphicEditor.Image = global::LAZYSHELL.Properties.Resources.openGraphics;
			this.openGraphicEditor.Name = "openGraphicEditor";
			this.openGraphicEditor.Size = new System.Drawing.Size(23, 22);
			this.openGraphicEditor.ToolTipText = "Graphics Editor";
			this.openGraphicEditor.Click += new System.EventHandler(this.openGraphicEditor_Click);
			// 
			// toggleLayeringForm
			// 
			this.toggleLayeringForm.CheckOnClick = true;
			this.toggleLayeringForm.Form = null;
			this.toggleLayeringForm.Image = global::LAZYSHELL.Properties.Resources.toggleLayering;
			this.toggleLayeringForm.Name = "toggleLayeringForm";
			this.toggleLayeringForm.Size = new System.Drawing.Size(23, 22);
			this.toggleLayeringForm.ToolTipText = "Layer Properties Window";
			// 
			// toggleMapForm
			// 
			this.toggleMapForm.CheckOnClick = true;
			this.toggleMapForm.Form = null;
			this.toggleMapForm.Image = global::LAZYSHELL.Properties.Resources.toggleMap;
			this.toggleMapForm.Name = "toggleMapForm";
			this.toggleMapForm.Size = new System.Drawing.Size(23, 22);
			this.toggleMapForm.ToolTipText = "Map Properties Window";
			// 
			// toggleNPCsForm
			// 
			this.toggleNPCsForm.CheckOnClick = true;
			this.toggleNPCsForm.Form = null;
			this.toggleNPCsForm.Image = global::LAZYSHELL.Properties.Resources.toggleNPCs;
			this.toggleNPCsForm.Name = "toggleNPCsForm";
			this.toggleNPCsForm.Size = new System.Drawing.Size(23, 22);
			this.toggleNPCsForm.ToolTipText = "NPCs Window";
			// 
			// toggleOverlapsForm
			// 
			this.toggleOverlapsForm.CheckOnClick = true;
			this.toggleOverlapsForm.Form = null;
			this.toggleOverlapsForm.Image = global::LAZYSHELL.Properties.Resources.toggleOverlaps;
			this.toggleOverlapsForm.Name = "toggleOverlapsForm";
			this.toggleOverlapsForm.Size = new System.Drawing.Size(23, 22);
			this.toggleOverlapsForm.ToolTipText = "Overlaps Window";
			// 
			// openPaletteEditor
			// 
			this.openPaletteEditor.Form = null;
			this.openPaletteEditor.Image = global::LAZYSHELL.Properties.Resources.openPalettes;
			this.openPaletteEditor.Name = "openPaletteEditor";
			this.openPaletteEditor.Size = new System.Drawing.Size(23, 22);
			this.openPaletteEditor.ToolTipText = "Palette Editor";
			this.openPaletteEditor.Click += new System.EventHandler(this.openPaletteEditor_Click);
			// 
			// openPreviewerForm
			// 
			this.openPreviewerForm.Form = null;
			this.openPreviewerForm.Image = global::LAZYSHELL.Properties.Resources.preview;
			this.openPreviewerForm.Name = "openPreviewerForm";
			this.openPreviewerForm.Size = new System.Drawing.Size(23, 22);
			this.openPreviewerForm.ToolTipText = "Previewer";
			this.openPreviewerForm.Click += new System.EventHandler(this.openPreviewerForm_Click);
			// 
			// togglePriorityForm
			// 
			this.togglePriorityForm.CheckOnClick = true;
			this.togglePriorityForm.Form = null;
			this.togglePriorityForm.Image = global::LAZYSHELL.Properties.Resources.togglePriority;
			this.togglePriorityForm.Name = "togglePriorityForm";
			this.togglePriorityForm.Size = new System.Drawing.Size(23, 22);
			this.togglePriorityForm.ToolTipText = "Priority Settings Window";
			// 
			// togglePropertiesForm
			// 
			this.togglePropertiesForm.CheckOnClick = true;
			this.togglePropertiesForm.Form = null;
			this.togglePropertiesForm.Image = global::LAZYSHELL.Properties.Resources.showMain;
			this.togglePropertiesForm.Name = "togglePropertiesForm";
			this.togglePropertiesForm.Size = new System.Drawing.Size(23, 22);
			this.togglePropertiesForm.ToolTipText = "Area Properties Window";
			// 
			// toggleTileSwitchesForm
			// 
			this.toggleTileSwitchesForm.CheckOnClick = true;
			this.toggleTileSwitchesForm.Form = null;
			this.toggleTileSwitchesForm.Image = global::LAZYSHELL.Properties.Resources.toggleTileSwitches;
			this.toggleTileSwitchesForm.Name = "toggleTileSwitchesForm";
			this.toggleTileSwitchesForm.Size = new System.Drawing.Size(23, 22);
			this.toggleTileSwitchesForm.ToolTipText = "Tile Switches Window";
			// 
			// toggleTilemapForm
			// 
			this.toggleTilemapForm.CheckOnClick = true;
			this.toggleTilemapForm.Form = null;
			this.toggleTilemapForm.Image = global::LAZYSHELL.Properties.Resources.openMap;
			this.toggleTilemapForm.Name = "toggleTilemapForm";
			this.toggleTilemapForm.Size = new System.Drawing.Size(23, 22);
			this.toggleTilemapForm.ToolTipText = "Tilemap Editor";
			// 
			// toggleTilesetL1Form
			// 
			this.toggleTilesetL1Form.CheckOnClick = true;
			this.toggleTilesetL1Form.Form = null;
			this.toggleTilesetL1Form.Image = global::LAZYSHELL.Properties.Resources.toggleTilesetL1;
			this.toggleTilesetL1Form.Name = "toggleTilesetL1Form";
			this.toggleTilesetL1Form.Size = new System.Drawing.Size(23, 22);
			this.toggleTilesetL1Form.ToolTipText = "Tileset L1 Editor";
			// 
			// toolStripArea
			// 
			this.toolStripArea.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.areaName,
            this.searchLocationNames,
            this.areaNum,
            this.navigateBck,
            this.navigateFwd,
            this.findReferences});
			this.toolStripArea.Location = new System.Drawing.Point(0, 25);
			this.toolStripArea.Name = "toolStripArea";
			this.toolStripArea.Size = new System.Drawing.Size(1043, 25);
			this.toolStripArea.TabIndex = 1;
			// 
			// findReferences
			// 
			this.findReferences.Image = global::LAZYSHELL.Properties.Resources.findReferences;
			this.findReferences.Name = "findReferences";
			this.findReferences.Size = new System.Drawing.Size(23, 22);
			this.findReferences.ToolTipText = "Find all references to area";
			this.findReferences.Click += new System.EventHandler(this.findReferences_Click);
			// 
			// toolStripMenuItem6
			// 
			this.toolStripMenuItem6.Name = "toolStripMenuItem6";
			this.toolStripMenuItem6.Size = new System.Drawing.Size(152, 22);
			this.toolStripMenuItem6.Text = "toolStripMenuItem6";
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// toolStripSeparator15
			// 
			this.toolStripSeparator15.Name = "toolStripSeparator15";
			this.toolStripSeparator15.Size = new System.Drawing.Size(6, 25);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
			// 
			// toolStripSeparator5
			// 
			this.toolStripSeparator5.Name = "toolStripSeparator5";
			this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
			// 
			// toolStripSeparator6
			// 
			this.toolStripSeparator6.Name = "toolStripSeparator6";
			this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
			// 
			// toolStripSeparator7
			// 
			this.toolStripSeparator7.Name = "toolStripSeparator7";
			this.toolStripSeparator7.Size = new System.Drawing.Size(6, 25);
			// 
			// toolStripToggle
			// 
			this.toolStripToggle.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.save,
            this.statistics,
            this.toolStripSeparator5,
            this.import,
            this.export,
            this.reset,
            this.clear,
            this.toolStripSeparator6,
            this.viewAreaInfo,
            this.helpTips,
            this.baseConvertor,
            this.hexEditor,
            this.toolStripSeparator15,
            this.togglePropertiesForm,
            this.toggleMapForm,
            this.toggleLayeringForm,
            this.togglePriorityForm,
            this.toggleNPCsForm,
            this.toggleExitsForm,
            this.toggleEventsForm,
            this.toggleOverlapsForm,
            this.toggleTileSwitchesForm,
            this.toggleCollisionSwitchesForm,
            this.toolStripSeparator7,
            this.toggleTilemapForm,
            this.toggleTilesetL1Form,
            this.toggleTilesetL2Form,
            this.toggleTilesetL3Form,
            this.toggleCollisionTileForm,
            this.toggleChunksForm,
            this.toolStripSeparator1,
            this.openPaletteEditor,
            this.openGraphicEditor,
            this.toolStripSeparator2,
            this.openPreviewerForm,
            this.openSpaceAnalyzer});
			this.toolStripToggle.Location = new System.Drawing.Point(0, 0);
			this.toolStripToggle.Name = "toolStripToggle";
			this.toolStripToggle.Size = new System.Drawing.Size(1043, 25);
			this.toolStripToggle.TabIndex = 0;
			// 
			// statistics
			// 
			this.statistics.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.statistics.Image = global::LAZYSHELL.Properties.Resources.statistics;
			this.statistics.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.statistics.Name = "statistics";
			this.statistics.Size = new System.Drawing.Size(23, 22);
			this.statistics.ToolTipText = "Area Statistics";
			this.statistics.Click += new System.EventHandler(this.statistics_Click);
			// 
			// viewAreaInfo
			// 
			this.viewAreaInfo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.areaInfo});
			this.viewAreaInfo.Image = global::LAZYSHELL.Properties.Resources.about;
			this.viewAreaInfo.Name = "viewAreaInfo";
			this.viewAreaInfo.Size = new System.Drawing.Size(29, 22);
			this.viewAreaInfo.ToolTipText = "View Area Offsets";
			// 
			// toggleTilesetL2Form
			// 
			this.toggleTilesetL2Form.CheckOnClick = true;
			this.toggleTilesetL2Form.Form = null;
			this.toggleTilesetL2Form.Image = global::LAZYSHELL.Properties.Resources.toggleTilesetL2;
			this.toggleTilesetL2Form.Name = "toggleTilesetL2Form";
			this.toggleTilesetL2Form.Size = new System.Drawing.Size(23, 22);
			this.toggleTilesetL2Form.ToolTipText = "Tileset L2 Editor";
			// 
			// toggleTilesetL3Form
			// 
			this.toggleTilesetL3Form.CheckOnClick = true;
			this.toggleTilesetL3Form.Form = null;
			this.toggleTilesetL3Form.Image = global::LAZYSHELL.Properties.Resources.toggleTilesetL3;
			this.toggleTilesetL3Form.Name = "toggleTilesetL3Form";
			this.toggleTilesetL3Form.Size = new System.Drawing.Size(23, 22);
			// 
			// toolTip1
			// 
			this.toolTip1.Active = false;
			// 
			// dockPanel
			// 
			this.dockPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dockPanel.DockBackColor = System.Drawing.SystemColors.AppWorkspace;
			this.dockPanel.DockLeftPortion = 266D;
			this.dockPanel.DockRightPortion = 264D;
			this.dockPanel.Location = new System.Drawing.Point(0, 50);
			this.dockPanel.Name = "dockPanel";
			this.dockPanel.Size = new System.Drawing.Size(1043, 630);
			this.dockPanel.TabIndex = 5;
			// 
			// OwnerForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1043, 680);
			this.Controls.Add(this.dockPanel);
			this.Controls.Add(this.toolStripArea);
			this.Controls.Add(this.toolStripToggle);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.IsMdiContainer = true;
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(20, 20);
			this.Name = "OwnerForm";
			this.Text = "AREAS - Lazy Shell";
			this.TilesetForms = new LAZYSHELL.TilesetForm[] {
        null,
        null,
        null};
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OwnerForm_FormClosing);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OwnerForm_FormClosed);
			this.toolStripArea.ResumeLayout(false);
			this.toolStripArea.PerformLayout();
			this.toolStripToggle.ResumeLayout(false);
			this.toolStripToggle.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }
        #endregion

        private ToolStrip toolStripArea;
        private Controls.NewToolStripButton openPreviewerForm;
        private Controls.NewToolStripButton openGraphicEditor;
        private Controls.NewToolStripButton openPaletteEditor;
        private Controls.NewToolStripButton toggleTilemapForm;
        private Controls.NewToolStripButton toggleTilesetL1Form;
        private ToolStripMenuItem importAreaData;
        private ToolStripMenuItem exportArrays;
        private ToolStripMenuItem importArrays;
        private ToolStripMenuItem clearAllComponentsAll;
        private ToolStripMenuItem clearAllComponentsCurrent;
        private ToolStripMenuItem clearAllAreaData;
        private ToolStripMenuItem clearAllCollisionMaps;
        private ToolStripMenuItem clearAllTilemaps;
        private ToolStripMenuItem clearAllTilesets;
        private ToolStripMenuItem dumpText;
        private ToolStripMenuItem exportImages;
        private ToolStripMenuItem exportGraphicSets;
        private ToolStripMenuItem importGraphicSet;
        private ToolStripMenuItem exportAreaData;
        private ToolStripMenuItem toolStripMenuItem6;
        private ToolStripMenuItem clearUnusedTilesets;
        private ToolStripMenuItem clearUnusedTilemaps;
        private ToolStripMenuItem clearUnusedCollisionMaps;
        private ToolStripMenuItem clearUnusedAll;
        private ToolStripSeparator toolStripSeparator28;
        private ToolStripSeparator toolStripSeparator29;
        private ToolStripSeparator toolStripSeparator30;
        private ToolStripSeparator toolStripSeparator32;
        private ToolStripSeparator toolStripSeparator38;
        private ToolStripSeparator toolStripSeparator8;
        private ToolTip toolTip1;
        private Controls.NewToolStripButton toggleCollisionTileForm;
        private Controls.NewToolStripButton toggleChunksForm;
        private System.Windows.Forms.ToolStripComboBox areaName;
        private Controls.NewToolStripButton searchLocationNames;
        private ToolStrip toolStripToggle;
        private Controls.NewToolStripButton save;
        private ToolStripDropDownButton import;
        private ToolStripDropDownButton export;
        private ToolStripDropDownButton clear;
        private Controls.NewToolStripButton openSpaceAnalyzer;
        public Controls.NewToolStripButton helpTips;
        public Controls.NewToolStripButton baseConvertor;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripSeparator toolStripSeparator2;
        private Controls.NewToolStripButton togglePropertiesForm;
        private Controls.NewToolStripNumericUpDown areaNum;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripSeparator toolStripSeparator6;
        private ToolStripSeparator toolStripSeparator15;
        private ToolStripMenuItem clearUnusedGraphicSets;
        private ToolStripMenuItem importArchitecture;
        private ToolStripMenuItem exportArchitecture;
        private Controls.NewToolStripButton hexEditor;
        private ToolStripDropDownButton reset;
        private ToolStripMenuItem resetNPCs;
        private ToolStripMenuItem resetEvents;
        private ToolStripMenuItem resetExits;
        private ToolStripMenuItem resetOverlaps;
        private ToolStripMenuItem resetLayering;
        private ToolStripMenuItem resetTileSwitches;
        private ToolStripMenuItem resetCollisionSwitches;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem resetTilesets;
        private ToolStripMenuItem resetTilemaps;
        private ToolStripMenuItem resetCollisionMap;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripMenuItem resetAllElements;
        private ToolStripMenuItem resetPaletteSet;
        private ToolStripMenuItem resetGraphicSet;
        private ToolStripDropDownButton viewAreaInfo;
        private Controls.NewToolStripListView areaInfo;
        private Controls.NewToolStripButton navigateBck;
        private Controls.NewToolStripButton navigateFwd;
        private Controls.NewToolStripButton toggleLayeringForm;
        private Controls.NewToolStripButton toggleMapForm;
        private Controls.NewToolStripButton togglePriorityForm;
        private Controls.NewToolStripButton toggleNPCsForm;
        private Controls.NewToolStripButton toggleExitsForm;
        private Controls.NewToolStripButton toggleEventsForm;
        private Controls.NewToolStripButton toggleOverlapsForm;
        private Controls.NewToolStripButton toggleTileSwitchesForm;
        private Controls.NewToolStripButton toggleCollisionSwitchesForm;
        private ToolStripSeparator toolStripSeparator7;
        private ToolStripButton findReferences;
        private ToolStripButton statistics;
        private ToolStripMenuItem resetMap;
        private WeifenLuo.WinFormsUI.Docking.DockPanel dockPanel;
        private Controls.NewToolStripButton toggleTilesetL2Form;
        private Controls.NewToolStripButton toggleTilesetL3Form;
	}
}

