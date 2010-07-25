using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LAZYSHELL
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
            this.withProperties = new System.Windows.Forms.RichTextBox();
            this.checkDoorFormat = new System.Windows.Forms.CheckedListBox();
            this.unknownBits = new System.Windows.Forms.CheckedListBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.doorFormat = new System.Windows.Forms.ComboBox();
            this.searchResults = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.searchOptions = new System.Windows.Forms.ToolStripComboBox();
            this.searchButton = new System.Windows.Forms.ToolStripButton();
            this.panel55.SuspendLayout();
            this.panel54.SuspendLayout();
            this.panel44.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.zCoordWater)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.heightOverhead)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zCoordOverhead)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.heighOfBaseTile)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
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
            this.physicalTileQuadrant.Location = new System.Drawing.Point(0, 238);
            this.physicalTileQuadrant.Name = "physicalTileQuadrant";
            this.physicalTileQuadrant.Size = new System.Drawing.Size(227, 64);
            this.physicalTileQuadrant.TabIndex = 386;
            // 
            // panel55
            // 
            this.panel55.BackColor = System.Drawing.SystemColors.Window;
            this.panel55.Controls.Add(this.specialTile);
            this.panel55.Location = new System.Drawing.Point(157, 368);
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
            this.panel54.Location = new System.Drawing.Point(157, 220);
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
            this.panel44.Location = new System.Drawing.Point(157, 137);
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
            this.physicalTilePriority3.Location = new System.Drawing.Point(0, 303);
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
            this.physicalTileEdges.Location = new System.Drawing.Point(0, 155);
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
            this.physicalTileProperties.Location = new System.Drawing.Point(0, 72);
            this.physicalTileProperties.Name = "physicalTileProperties";
            this.physicalTileProperties.Size = new System.Drawing.Size(227, 64);
            this.physicalTileProperties.TabIndex = 385;
            // 
            // zCoordWater
            // 
            this.zCoordWater.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.zCoordWater.Enabled = false;
            this.zCoordWater.Location = new System.Drawing.Point(157, 54);
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
            this.heightOverhead.Location = new System.Drawing.Point(157, 18);
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
            this.zCoordOverhead.Location = new System.Drawing.Point(157, 36);
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
            this.heighOfBaseTile.Location = new System.Drawing.Point(157, 0);
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
            this.checkHeightOfBaseTile.Location = new System.Drawing.Point(0, 0);
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
            this.checkHeightOverhead.Location = new System.Drawing.Point(0, 18);
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
            this.checkZCoordOverhead.Location = new System.Drawing.Point(0, 36);
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
            this.checkZCoordWater.Location = new System.Drawing.Point(0, 54);
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
            this.checkConveyor.Location = new System.Drawing.Point(0, 137);
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
            this.checkStairs.Location = new System.Drawing.Point(0, 220);
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
            this.checkSpecialTile.Location = new System.Drawing.Point(0, 368);
            this.checkSpecialTile.Name = "checkSpecialTile";
            this.checkSpecialTile.Size = new System.Drawing.Size(156, 17);
            this.checkSpecialTile.TabIndex = 385;
            this.checkSpecialTile.SelectedIndexChanged += new System.EventHandler(this.checkSpecialTile_SelectedIndexChanged);
            // 
            // withProperties
            // 
            this.withProperties.BackColor = System.Drawing.SystemColors.Window;
            this.withProperties.Dock = System.Windows.Forms.DockStyle.Top;
            this.withProperties.Location = new System.Drawing.Point(232, 25);
            this.withProperties.Name = "withProperties";
            this.withProperties.ReadOnly = true;
            this.withProperties.Size = new System.Drawing.Size(229, 185);
            this.withProperties.TabIndex = 328;
            this.withProperties.Text = "";
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
            this.checkDoorFormat.Location = new System.Drawing.Point(0, 419);
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
            this.unknownBits.Location = new System.Drawing.Point(0, 386);
            this.unknownBits.MultiColumn = true;
            this.unknownBits.Name = "unknownBits";
            this.unknownBits.Size = new System.Drawing.Size(227, 32);
            this.unknownBits.TabIndex = 388;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Window;
            this.panel3.Controls.Add(this.doorFormat);
            this.panel3.Location = new System.Drawing.Point(157, 419);
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
            // searchResults
            // 
            this.searchResults.Dock = System.Windows.Forms.DockStyle.Right;
            this.searchResults.FormattingEnabled = true;
            this.searchResults.IntegralHeight = false;
            this.searchResults.Location = new System.Drawing.Point(232, 210);
            this.searchResults.Name = "searchResults";
            this.searchResults.Size = new System.Drawing.Size(229, 255);
            this.searchResults.TabIndex = 329;
            this.searchResults.SelectedIndexChanged += new System.EventHandler(this.searchResults_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.checkHeightOfBaseTile);
            this.panel1.Controls.Add(this.heighOfBaseTile);
            this.panel1.Controls.Add(this.zCoordOverhead);
            this.panel1.Controls.Add(this.heightOverhead);
            this.panel1.Controls.Add(this.zCoordWater);
            this.panel1.Controls.Add(this.physicalTileQuadrant);
            this.panel1.Controls.Add(this.physicalTileProperties);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.checkZCoordOverhead);
            this.panel1.Controls.Add(this.panel55);
            this.panel1.Controls.Add(this.checkHeightOverhead);
            this.panel1.Controls.Add(this.panel54);
            this.panel1.Controls.Add(this.checkZCoordWater);
            this.panel1.Controls.Add(this.panel44);
            this.panel1.Controls.Add(this.checkConveyor);
            this.panel1.Controls.Add(this.unknownBits);
            this.panel1.Controls.Add(this.checkStairs);
            this.panel1.Controls.Add(this.physicalTilePriority3);
            this.panel1.Controls.Add(this.checkSpecialTile);
            this.panel1.Controls.Add(this.checkDoorFormat);
            this.panel1.Controls.Add(this.physicalTileEdges);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(232, 440);
            this.panel1.TabIndex = 391;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.searchOptions,
            this.searchButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(461, 25);
            this.toolStrip1.TabIndex = 392;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // searchOptions
            // 
            this.searchOptions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.searchOptions.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.searchOptions.Items.AddRange(new object[] {
            "search for tiles with ONLY these properties",
            "search for tiles with ANY of these properties"});
            this.searchOptions.Name = "searchOptions";
            this.searchOptions.Size = new System.Drawing.Size(200, 25);
            this.searchOptions.SelectedIndexChanged += new System.EventHandler(this.searchOptions_SelectedIndexChanged);
            // 
            // searchButton
            // 
            this.searchButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.searchButton.Image = global::LAZYSHELL.Properties.Resources.search;
            this.searchButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.searchButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(23, 22);
            this.searchButton.ToolTipText = "Search";
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // SearchPhysicalTile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(461, 465);
            this.Controls.Add(this.searchResults);
            this.Controls.Add(this.withProperties);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SearchPhysicalTile";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "SEARCH FOR PHYSICAL TILES...";
            this.panel55.ResumeLayout(false);
            this.panel54.ResumeLayout(false);
            this.panel44.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.zCoordWater)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.heightOverhead)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zCoordOverhead)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.heighOfBaseTile)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

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
        private System.Windows.Forms.RichTextBox withProperties;
        private CheckedListBox checkDoorFormat;
        private CheckedListBox unknownBits;
        private Panel panel3;
        private ComboBox doorFormat;
        private ListBox searchResults;
        private CheckedListBox checkZCoordWater;
        private Panel panel1;
        private ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripComboBox searchOptions;
        private ToolStripButton searchButton;

    }
}