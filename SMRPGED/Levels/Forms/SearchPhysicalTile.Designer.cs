using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SMRPGED
{
    partial class SearchPhysicalTile
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
            this.label93 = new System.Windows.Forms.Label();
            this.physicalTileQuadrant = new System.Windows.Forms.CheckedListBox();
            this.panel55 = new System.Windows.Forms.Panel();
            this.specialTile = new System.Windows.Forms.ComboBox();
            this.panel54 = new System.Windows.Forms.Panel();
            this.stairs = new System.Windows.Forms.ComboBox();
            this.panel44 = new System.Windows.Forms.Panel();
            this.conveyor = new System.Windows.Forms.ComboBox();
            this.physicalTilePriority3 = new System.Windows.Forms.CheckedListBox();
            this.physicalTileEdges = new System.Windows.Forms.CheckedListBox();
            this.physicalTileProperties = new System.Windows.Forms.CheckedListBox();
            this.zCoordWater = new System.Windows.Forms.NumericUpDown();
            this.heightOverhead = new System.Windows.Forms.NumericUpDown();
            this.zCoordOverhead = new System.Windows.Forms.NumericUpDown();
            this.heighOfBaseTile = new System.Windows.Forms.NumericUpDown();
            this.checkHeightOfBaseTile = new System.Windows.Forms.CheckedListBox();
            this.checkHeightOverhead = new System.Windows.Forms.CheckedListBox();
            this.checkZCoordOverhead = new System.Windows.Forms.CheckedListBox();
            this.checkZCoordWater = new System.Windows.Forms.CheckedListBox();
            this.checkConveyor = new System.Windows.Forms.CheckedListBox();
            this.checkStairs = new System.Windows.Forms.CheckedListBox();
            this.checkSpecialTile = new System.Windows.Forms.CheckedListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.withProperties = new System.Windows.Forms.RichTextBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.checkDoorFormat = new System.Windows.Forms.CheckedListBox();
            this.unknownBits = new System.Windows.Forms.CheckedListBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.doorFormat = new System.Windows.Forms.ComboBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.searchOptions = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.searchResults = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel55.SuspendLayout();
            this.panel54.SuspendLayout();
            this.panel44.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.zCoordWater)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.heightOverhead)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zCoordOverhead)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.heighOfBaseTile)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label93
            // 
            this.label93.BackColor = System.Drawing.SystemColors.Control;
            this.label93.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label93.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label93.Location = new System.Drawing.Point(2, 40);
            this.label93.Name = "label93";
            this.label93.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.label93.Size = new System.Drawing.Size(156, 17);
            this.label93.TabIndex = 380;
            this.label93.Text = "PROPERTIES";
            this.label93.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // physicalTileQuadrant
            // 
            this.physicalTileQuadrant.BackColor = System.Drawing.SystemColors.Window;
            this.physicalTileQuadrant.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.physicalTileQuadrant.CheckOnClick = true;
            this.physicalTileQuadrant.ColumnWidth = 118;
            this.physicalTileQuadrant.Items.AddRange(new object[] {
            "N quadrant is solid",
            "W quadrant is solid",
            "E quadrant is solid",
            "S quadrant is solid"});
            this.physicalTileQuadrant.Location = new System.Drawing.Point(2, 297);
            this.physicalTileQuadrant.Name = "physicalTileQuadrant";
            this.physicalTileQuadrant.Size = new System.Drawing.Size(227, 64);
            this.physicalTileQuadrant.TabIndex = 386;
            // 
            // panel55
            // 
            this.panel55.BackColor = System.Drawing.SystemColors.Window;
            this.panel55.Controls.Add(this.specialTile);
            this.panel55.Location = new System.Drawing.Point(159, 427);
            this.panel55.Name = "panel55";
            this.panel55.Size = new System.Drawing.Size(71, 17);
            this.panel55.TabIndex = 372;
            // 
            // specialTile
            // 
            this.specialTile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.specialTile.Enabled = false;
            this.specialTile.Items.AddRange(new object[] {
            "(normal)",
            "Vines",
            "Water"});
            this.specialTile.Location = new System.Drawing.Point(-2, -2);
            this.specialTile.Name = "specialTile";
            this.specialTile.Size = new System.Drawing.Size(75, 21);
            this.specialTile.TabIndex = 371;
            // 
            // panel54
            // 
            this.panel54.BackColor = System.Drawing.SystemColors.Window;
            this.panel54.Controls.Add(this.stairs);
            this.panel54.Location = new System.Drawing.Point(159, 279);
            this.panel54.Name = "panel54";
            this.panel54.Size = new System.Drawing.Size(71, 17);
            this.panel54.TabIndex = 370;
            // 
            // stairs
            // 
            this.stairs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.stairs.Enabled = false;
            this.stairs.Items.AddRange(new object[] {
            "(no stairs)",
            "Up-left",
            "Up-right"});
            this.stairs.Location = new System.Drawing.Point(-2, -2);
            this.stairs.Name = "stairs";
            this.stairs.Size = new System.Drawing.Size(75, 21);
            this.stairs.TabIndex = 372;
            // 
            // panel44
            // 
            this.panel44.BackColor = System.Drawing.SystemColors.Window;
            this.panel44.Controls.Add(this.conveyor);
            this.panel44.Location = new System.Drawing.Point(159, 196);
            this.panel44.Name = "panel44";
            this.panel44.Size = new System.Drawing.Size(71, 17);
            this.panel44.TabIndex = 371;
            // 
            // conveyor
            // 
            this.conveyor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.conveyor.Enabled = false;
            this.conveyor.Items.AddRange(new object[] {
            "Right",
            "Down-right",
            "Down",
            "Down-left",
            "Left",
            "Up-left",
            "Up",
            "Up-right"});
            this.conveyor.Location = new System.Drawing.Point(-2, -2);
            this.conveyor.Name = "conveyor";
            this.conveyor.Size = new System.Drawing.Size(75, 21);
            this.conveyor.TabIndex = 370;
            // 
            // physicalTilePriority3
            // 
            this.physicalTilePriority3.BackColor = System.Drawing.SystemColors.Window;
            this.physicalTilePriority3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.physicalTilePriority3.CheckOnClick = true;
            this.physicalTilePriority3.ColumnWidth = 118;
            this.physicalTilePriority3.Items.AddRange(new object[] {
            "Priority 3 for objects on tile edge",
            "Priority 3 for objects above tile edge",
            "Priority 3 for objects on tile",
            "Solid quadrant flag"});
            this.physicalTilePriority3.Location = new System.Drawing.Point(2, 362);
            this.physicalTilePriority3.Name = "physicalTilePriority3";
            this.physicalTilePriority3.Size = new System.Drawing.Size(227, 64);
            this.physicalTilePriority3.TabIndex = 388;
            // 
            // physicalTileEdges
            // 
            this.physicalTileEdges.BackColor = System.Drawing.SystemColors.Window;
            this.physicalTileEdges.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.physicalTileEdges.CheckOnClick = true;
            this.physicalTileEdges.ColumnWidth = 118;
            this.physicalTileEdges.Items.AddRange(new object[] {
            "NW edge is solid",
            "NE edge is solid",
            "SW edge is solid",
            "SE edge is solid"});
            this.physicalTileEdges.Location = new System.Drawing.Point(2, 214);
            this.physicalTileEdges.Name = "physicalTileEdges";
            this.physicalTileEdges.Size = new System.Drawing.Size(227, 64);
            this.physicalTileEdges.TabIndex = 387;
            // 
            // physicalTileProperties
            // 
            this.physicalTileProperties.BackColor = System.Drawing.SystemColors.Window;
            this.physicalTileProperties.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.physicalTileProperties.CheckOnClick = true;
            this.physicalTileProperties.ColumnWidth = 118;
            this.physicalTileProperties.Items.AddRange(new object[] {
            "Conveyor belt, fast",
            "Conveyor belt, normal",
            "Z Coord + 0.5",
            "Solid tile"});
            this.physicalTileProperties.Location = new System.Drawing.Point(2, 131);
            this.physicalTileProperties.Name = "physicalTileProperties";
            this.physicalTileProperties.Size = new System.Drawing.Size(227, 64);
            this.physicalTileProperties.TabIndex = 385;
            // 
            // zCoordWater
            // 
            this.zCoordWater.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.zCoordWater.Enabled = false;
            this.zCoordWater.Location = new System.Drawing.Point(159, 113);
            this.zCoordWater.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.zCoordWater.Name = "zCoordWater";
            this.zCoordWater.Size = new System.Drawing.Size(71, 17);
            this.zCoordWater.TabIndex = 382;
            this.zCoordWater.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // heightOverhead
            // 
            this.heightOverhead.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.heightOverhead.Enabled = false;
            this.heightOverhead.Location = new System.Drawing.Point(159, 77);
            this.heightOverhead.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.heightOverhead.Name = "heightOverhead";
            this.heightOverhead.Size = new System.Drawing.Size(71, 17);
            this.heightOverhead.TabIndex = 383;
            this.heightOverhead.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // zCoordOverhead
            // 
            this.zCoordOverhead.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.zCoordOverhead.Enabled = false;
            this.zCoordOverhead.Location = new System.Drawing.Point(159, 95);
            this.zCoordOverhead.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.zCoordOverhead.Name = "zCoordOverhead";
            this.zCoordOverhead.Size = new System.Drawing.Size(71, 17);
            this.zCoordOverhead.TabIndex = 384;
            this.zCoordOverhead.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // heighOfBaseTile
            // 
            this.heighOfBaseTile.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.heighOfBaseTile.Enabled = false;
            this.heighOfBaseTile.Location = new System.Drawing.Point(159, 59);
            this.heighOfBaseTile.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.heighOfBaseTile.Name = "heighOfBaseTile";
            this.heighOfBaseTile.Size = new System.Drawing.Size(71, 17);
            this.heighOfBaseTile.TabIndex = 381;
            this.heighOfBaseTile.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // checkHeightOfBaseTile
            // 
            this.checkHeightOfBaseTile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.checkHeightOfBaseTile.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.checkHeightOfBaseTile.CheckOnClick = true;
            this.checkHeightOfBaseTile.ColumnWidth = 118;
            this.checkHeightOfBaseTile.IntegralHeight = false;
            this.checkHeightOfBaseTile.Items.AddRange(new object[] {
            "Height of base tile"});
            this.checkHeightOfBaseTile.Location = new System.Drawing.Point(2, 59);
            this.checkHeightOfBaseTile.Name = "checkHeightOfBaseTile";
            this.checkHeightOfBaseTile.Size = new System.Drawing.Size(156, 17);
            this.checkHeightOfBaseTile.TabIndex = 385;
            this.checkHeightOfBaseTile.SelectedIndexChanged += new System.EventHandler(this.checkHeightOfBaseTile_SelectedIndexChanged);
            // 
            // checkHeightOverhead
            // 
            this.checkHeightOverhead.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.checkHeightOverhead.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.checkHeightOverhead.CheckOnClick = true;
            this.checkHeightOverhead.ColumnWidth = 118;
            this.checkHeightOverhead.IntegralHeight = false;
            this.checkHeightOverhead.Items.AddRange(new object[] {
            "Height of overhead tile"});
            this.checkHeightOverhead.Location = new System.Drawing.Point(2, 77);
            this.checkHeightOverhead.Name = "checkHeightOverhead";
            this.checkHeightOverhead.Size = new System.Drawing.Size(156, 17);
            this.checkHeightOverhead.TabIndex = 385;
            this.checkHeightOverhead.SelectedIndexChanged += new System.EventHandler(this.checkHeightOverhead_SelectedIndexChanged);
            // 
            // checkZCoordOverhead
            // 
            this.checkZCoordOverhead.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.checkZCoordOverhead.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.checkZCoordOverhead.CheckOnClick = true;
            this.checkZCoordOverhead.ColumnWidth = 118;
            this.checkZCoordOverhead.IntegralHeight = false;
            this.checkZCoordOverhead.Items.AddRange(new object[] {
            "Z Coord of overhead tile"});
            this.checkZCoordOverhead.Location = new System.Drawing.Point(2, 95);
            this.checkZCoordOverhead.Name = "checkZCoordOverhead";
            this.checkZCoordOverhead.Size = new System.Drawing.Size(156, 17);
            this.checkZCoordOverhead.TabIndex = 385;
            this.checkZCoordOverhead.SelectedIndexChanged += new System.EventHandler(this.checkZCoordOverhead_SelectedIndexChanged);
            // 
            // checkZCoordWater
            // 
            this.checkZCoordWater.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.checkZCoordWater.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.checkZCoordWater.CheckOnClick = true;
            this.checkZCoordWater.ColumnWidth = 118;
            this.checkZCoordWater.IntegralHeight = false;
            this.checkZCoordWater.Items.AddRange(new object[] {
            "Z Coord of water tile"});
            this.checkZCoordWater.Location = new System.Drawing.Point(2, 113);
            this.checkZCoordWater.Name = "checkZCoordWater";
            this.checkZCoordWater.Size = new System.Drawing.Size(156, 17);
            this.checkZCoordWater.TabIndex = 385;
            this.checkZCoordWater.SelectedIndexChanged += new System.EventHandler(this.checkZCoordWater_SelectedIndexChanged);
            // 
            // checkConveyor
            // 
            this.checkConveyor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.checkConveyor.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.checkConveyor.CheckOnClick = true;
            this.checkConveyor.ColumnWidth = 118;
            this.checkConveyor.IntegralHeight = false;
            this.checkConveyor.Items.AddRange(new object[] {
            "Conveyor belt runs"});
            this.checkConveyor.Location = new System.Drawing.Point(2, 196);
            this.checkConveyor.Name = "checkConveyor";
            this.checkConveyor.Size = new System.Drawing.Size(156, 17);
            this.checkConveyor.TabIndex = 385;
            this.checkConveyor.SelectedIndexChanged += new System.EventHandler(this.checkConveyor_SelectedIndexChanged);
            // 
            // checkStairs
            // 
            this.checkStairs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.checkStairs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.checkStairs.CheckOnClick = true;
            this.checkStairs.ColumnWidth = 118;
            this.checkStairs.IntegralHeight = false;
            this.checkStairs.Items.AddRange(new object[] {
            "Stairs lead"});
            this.checkStairs.Location = new System.Drawing.Point(2, 279);
            this.checkStairs.Name = "checkStairs";
            this.checkStairs.Size = new System.Drawing.Size(156, 17);
            this.checkStairs.TabIndex = 385;
            this.checkStairs.SelectedIndexChanged += new System.EventHandler(this.checkStairs_SelectedIndexChanged);
            // 
            // checkSpecialTile
            // 
            this.checkSpecialTile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.checkSpecialTile.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.checkSpecialTile.CheckOnClick = true;
            this.checkSpecialTile.ColumnWidth = 118;
            this.checkSpecialTile.IntegralHeight = false;
            this.checkSpecialTile.Items.AddRange(new object[] {
            "Special tile format"});
            this.checkSpecialTile.Location = new System.Drawing.Point(2, 427);
            this.checkSpecialTile.Name = "checkSpecialTile";
            this.checkSpecialTile.Size = new System.Drawing.Size(156, 17);
            this.checkSpecialTile.TabIndex = 385;
            this.checkSpecialTile.SelectedIndexChanged += new System.EventHandler(this.checkSpecialTile_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Window;
            this.panel1.Controls.Add(this.withProperties);
            this.panel1.Location = new System.Drawing.Point(231, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(227, 193);
            this.panel1.TabIndex = 389;
            // 
            // withProperties
            // 
            this.withProperties.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.withProperties.BackColor = System.Drawing.SystemColors.Window;
            this.withProperties.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.withProperties.Location = new System.Drawing.Point(4, 4);
            this.withProperties.Name = "withProperties";
            this.withProperties.ReadOnly = true;
            this.withProperties.Size = new System.Drawing.Size(219, 185);
            this.withProperties.TabIndex = 328;
            this.withProperties.Text = "";
            // 
            // searchButton
            // 
            this.searchButton.BackColor = System.Drawing.SystemColors.Window;
            this.searchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.searchButton.Location = new System.Drawing.Point(158, 39);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(72, 19);
            this.searchButton.TabIndex = 390;
            this.searchButton.Text = "Search...";
            this.searchButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.searchButton.UseCompatibleTextRendering = true;
            this.searchButton.UseVisualStyleBackColor = false;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // checkDoorFormat
            // 
            this.checkDoorFormat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.checkDoorFormat.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.checkDoorFormat.CheckOnClick = true;
            this.checkDoorFormat.ColumnWidth = 118;
            this.checkDoorFormat.IntegralHeight = false;
            this.checkDoorFormat.Items.AddRange(new object[] {
            "Door format"});
            this.checkDoorFormat.Location = new System.Drawing.Point(2, 478);
            this.checkDoorFormat.Name = "checkDoorFormat";
            this.checkDoorFormat.Size = new System.Drawing.Size(156, 17);
            this.checkDoorFormat.TabIndex = 385;
            this.checkDoorFormat.SelectedIndexChanged += new System.EventHandler(this.checkDoorFormat_SelectedIndexChanged);
            // 
            // unknownBits
            // 
            this.unknownBits.BackColor = System.Drawing.SystemColors.Window;
            this.unknownBits.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.unknownBits.CheckOnClick = true;
            this.unknownBits.ColumnWidth = 74;
            this.unknownBits.Items.AddRange(new object[] {
            "{B5,b0}",
            "{B5,b1}",
            "{B5,b2}",
            "{B5,b3}",
            "{B5,b4}"});
            this.unknownBits.Location = new System.Drawing.Point(2, 445);
            this.unknownBits.MultiColumn = true;
            this.unknownBits.Name = "unknownBits";
            this.unknownBits.Size = new System.Drawing.Size(227, 32);
            this.unknownBits.TabIndex = 388;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Window;
            this.panel3.Controls.Add(this.doorFormat);
            this.panel3.Location = new System.Drawing.Point(159, 478);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(71, 17);
            this.panel3.TabIndex = 372;
            // 
            // doorFormat
            // 
            this.doorFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.doorFormat.Enabled = false;
            this.doorFormat.Items.AddRange(new object[] {
            "(none)",
            "{unknown}",
            "{unknown}",
            "{unknown}",
            "{unknown}",
            "NW / SE",
            "{unknown}",
            "NE / SW"});
            this.doorFormat.Location = new System.Drawing.Point(-2, -2);
            this.doorFormat.Name = "doorFormat";
            this.doorFormat.Size = new System.Drawing.Size(75, 21);
            this.doorFormat.TabIndex = 371;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.Window;
            this.panel4.Controls.Add(this.searchOptions);
            this.panel4.Location = new System.Drawing.Point(2, 21);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(228, 17);
            this.panel4.TabIndex = 371;
            // 
            // searchOptions
            // 
            this.searchOptions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.searchOptions.Items.AddRange(new object[] {
            "search for tiles with ONLY these properties",
            "search for tiles with ANY of these properties"});
            this.searchOptions.Location = new System.Drawing.Point(-2, -2);
            this.searchOptions.Name = "searchOptions";
            this.searchOptions.Size = new System.Drawing.Size(232, 21);
            this.searchOptions.TabIndex = 370;
            this.searchOptions.SelectedIndexChanged += new System.EventHandler(this.searchOptions_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label1.Location = new System.Drawing.Point(2, 2);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.label1.Size = new System.Drawing.Size(227, 17);
            this.label1.TabIndex = 380;
            this.label1.Text = "SEARCH OPTIONS";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // searchResults
            // 
            this.searchResults.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.searchResults.FormattingEnabled = true;
            this.searchResults.IntegralHeight = false;
            this.searchResults.Location = new System.Drawing.Point(231, 216);
            this.searchResults.Name = "searchResults";
            this.searchResults.Size = new System.Drawing.Size(227, 279);
            this.searchResults.TabIndex = 329;
            this.searchResults.SelectedIndexChanged += new System.EventHandler(this.searchResults_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label2.Location = new System.Drawing.Point(231, 197);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.label2.Size = new System.Drawing.Size(227, 17);
            this.label2.TabIndex = 380;
            this.label2.Text = "SEARCH RESULTS...";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SearchPhysicalTile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(460, 497);
            this.Controls.Add(this.searchResults);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label93);
            this.Controls.Add(this.physicalTileQuadrant);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel55);
            this.Controls.Add(this.panel54);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel44);
            this.Controls.Add(this.unknownBits);
            this.Controls.Add(this.physicalTilePriority3);
            this.Controls.Add(this.checkDoorFormat);
            this.Controls.Add(this.physicalTileEdges);
            this.Controls.Add(this.checkSpecialTile);
            this.Controls.Add(this.checkStairs);
            this.Controls.Add(this.checkConveyor);
            this.Controls.Add(this.checkZCoordWater);
            this.Controls.Add(this.checkHeightOverhead);
            this.Controls.Add(this.checkZCoordOverhead);
            this.Controls.Add(this.checkHeightOfBaseTile);
            this.Controls.Add(this.physicalTileProperties);
            this.Controls.Add(this.zCoordWater);
            this.Controls.Add(this.heightOverhead);
            this.Controls.Add(this.zCoordOverhead);
            this.Controls.Add(this.heighOfBaseTile);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SearchPhysicalTile";
            this.ShowIcon = false;
            this.Text = "SEARCH FOR PHYSICAL TILES...";
            this.TopMost = true;
            this.panel55.ResumeLayout(false);
            this.panel54.ResumeLayout(false);
            this.panel44.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.zCoordWater)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.heightOverhead)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zCoordOverhead)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.heighOfBaseTile)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label93;
        private System.Windows.Forms.CheckedListBox physicalTileQuadrant;
        private System.Windows.Forms.Panel panel55;
        private System.Windows.Forms.ComboBox specialTile;
        private System.Windows.Forms.Panel panel54;
        private System.Windows.Forms.ComboBox stairs;
        private System.Windows.Forms.Panel panel44;
        private System.Windows.Forms.ComboBox conveyor;
        private System.Windows.Forms.CheckedListBox physicalTilePriority3;
        private System.Windows.Forms.CheckedListBox physicalTileEdges;
        private System.Windows.Forms.CheckedListBox physicalTileProperties;
        private System.Windows.Forms.NumericUpDown zCoordWater;
        private System.Windows.Forms.NumericUpDown heightOverhead;
        private System.Windows.Forms.NumericUpDown zCoordOverhead;
        private System.Windows.Forms.NumericUpDown heighOfBaseTile;
        private System.Windows.Forms.CheckedListBox checkHeightOfBaseTile;
        private System.Windows.Forms.CheckedListBox checkHeightOverhead;
        private System.Windows.Forms.CheckedListBox checkZCoordOverhead;
        private System.Windows.Forms.CheckedListBox checkConveyor;
        private System.Windows.Forms.CheckedListBox checkStairs;
        private System.Windows.Forms.CheckedListBox checkSpecialTile;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox withProperties;
        private System.Windows.Forms.Button searchButton;
        private CheckedListBox checkDoorFormat;
        private CheckedListBox unknownBits;
        private Panel panel3;
        private ComboBox doorFormat;
        private Panel panel4;
        private ComboBox searchOptions;
        private Label label1;
        private ListBox searchResults;
        private Label label2;
        private CheckedListBox checkZCoordWater;

    }
}