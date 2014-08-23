using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LAZYSHELL.Areas
{
    partial class SearchCollisionTileForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchCollisionTileForm));
            this.specialTile = new System.Windows.Forms.ComboBox();
            this.stairs = new System.Windows.Forms.ComboBox();
            this.conveyor = new System.Windows.Forms.ComboBox();
            this.unknownBits = new System.Windows.Forms.CheckedListBox();
            this.doorFormat = new System.Windows.Forms.ComboBox();
            this.searchResults = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkStairs = new System.Windows.Forms.CheckBox();
            this.checkSpecialTile = new System.Windows.Forms.CheckBox();
            this.checkDoorFormat = new System.Windows.Forms.CheckBox();
            this.conveyorBeltNormal = new System.Windows.Forms.ComboBox();
            this.conveyorBeltFast = new System.Windows.Forms.ComboBox();
            this.checkConveyor = new System.Windows.Forms.CheckBox();
            this.checkConveyorBeltFast = new System.Windows.Forms.CheckBox();
            this.checkConveyorBeltNormal = new System.Windows.Forms.CheckBox();
            this.p3OnTile = new System.Windows.Forms.ComboBox();
            this.p3OverEdge = new System.Windows.Forms.ComboBox();
            this.p3OnEdge = new System.Windows.Forms.ComboBox();
            this.checkP3OnEdge = new System.Windows.Forms.CheckBox();
            this.checkP3OverEdge = new System.Windows.Forms.CheckBox();
            this.checkP3OnTile = new System.Windows.Forms.CheckBox();
            this.checkSolidQuadrantS = new System.Windows.Forms.CheckBox();
            this.checkSolidQuadrantE = new System.Windows.Forms.CheckBox();
            this.checkSolidQuadrantN = new System.Windows.Forms.CheckBox();
            this.checkSolidEdgeNW = new System.Windows.Forms.CheckBox();
            this.checkSolidEdgeSW = new System.Windows.Forms.CheckBox();
            this.checkSolidQuadrantW = new System.Windows.Forms.CheckBox();
            this.checkSolidEdgeSE = new System.Windows.Forms.CheckBox();
            this.checkSolidEdgeNE = new System.Windows.Forms.CheckBox();
            this.solidEdgeNE = new System.Windows.Forms.CheckBox();
            this.solidQuadrantS = new System.Windows.Forms.CheckBox();
            this.solidEdgeSW = new System.Windows.Forms.CheckBox();
            this.solidEdgeSE = new System.Windows.Forms.CheckBox();
            this.solidEdgeNW = new System.Windows.Forms.CheckBox();
            this.solidQuadrantE = new System.Windows.Forms.CheckBox();
            this.solidQuadrantW = new System.Windows.Forms.CheckBox();
            this.solidQuadrantN = new System.Windows.Forms.CheckBox();
            this.solidQuadrant = new System.Windows.Forms.ComboBox();
            this.solidTile = new System.Windows.Forms.ComboBox();
            this.checkSolidTile = new System.Windows.Forms.CheckBox();
            this.checkSolidQuadrant = new System.Windows.Forms.CheckBox();
            this.zCoordPlusHalf = new System.Windows.Forms.ComboBox();
            this.heightOfBaseTile = new System.Windows.Forms.NumericUpDown();
            this.zCoordOverhead = new System.Windows.Forms.NumericUpDown();
            this.checkHeightOfBaseTile = new System.Windows.Forms.CheckBox();
            this.heightOverhead = new System.Windows.Forms.NumericUpDown();
            this.checkZCoordPlusHalf = new System.Windows.Forms.CheckBox();
            this.zCoordWater = new System.Windows.Forms.NumericUpDown();
            this.checkZCoordWater = new System.Windows.Forms.CheckBox();
            this.checkHeightOverhead = new System.Windows.Forms.CheckBox();
            this.checkZCoordOverhead = new System.Windows.Forms.CheckBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.selectAll = new System.Windows.Forms.ToolStripButton();
            this.deselectAll = new System.Windows.Forms.ToolStripButton();
            this.search = new System.Windows.Forms.ToolStripButton();
            this.withProperties = new System.Windows.Forms.RichTextBox();
            this.headerLabel5 = new LAZYSHELL.Controls.HeaderLabel();
            this.headerLabel4 = new LAZYSHELL.Controls.HeaderLabel();
            this.headerLabel3 = new LAZYSHELL.Controls.HeaderLabel();
            this.headerLabel2 = new LAZYSHELL.Controls.HeaderLabel();
            this.headerLabel1 = new LAZYSHELL.Controls.HeaderLabel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.heightOfBaseTile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zCoordOverhead)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.heightOverhead)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zCoordWater)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // specialTile
            // 
            this.specialTile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.specialTile.Enabled = false;
            this.specialTile.Items.AddRange(new object[] {
            "{none}",
            "vines",
            "water"});
            this.specialTile.Location = new System.Drawing.Point(154, 490);
            this.specialTile.Name = "specialTile";
            this.specialTile.Size = new System.Drawing.Size(69, 21);
            this.specialTile.TabIndex = 4;
            // 
            // stairs
            // 
            this.stairs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.stairs.Enabled = false;
            this.stairs.Items.AddRange(new object[] {
            "{none}",
            "NW,SE",
            "NE,SW"});
            this.stairs.Location = new System.Drawing.Point(154, 469);
            this.stairs.Name = "stairs";
            this.stairs.Size = new System.Drawing.Size(69, 21);
            this.stairs.TabIndex = 3;
            // 
            // conveyor
            // 
            this.conveyor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.conveyor.Enabled = false;
            this.conveyor.Items.AddRange(new object[] {
            "E",
            "SE",
            "S",
            "SW",
            "W",
            "NW",
            "N",
            "NE"});
            this.conveyor.Location = new System.Drawing.Point(154, 386);
            this.conveyor.Name = "conveyor";
            this.conveyor.Size = new System.Drawing.Size(69, 21);
            this.conveyor.TabIndex = 3;
            // 
            // unknownBits
            // 
            this.unknownBits.CheckOnClick = true;
            this.unknownBits.ColumnWidth = 64;
            this.unknownBits.Items.AddRange(new object[] {
            "{B5,b0}",
            "{B5,b1}",
            "{B5,b2}",
            "{B5,b3}",
            "{B5,b4}"});
            this.unknownBits.Location = new System.Drawing.Point(6, 538);
            this.unknownBits.MultiColumn = true;
            this.unknownBits.Name = "unknownBits";
            this.unknownBits.Size = new System.Drawing.Size(217, 36);
            this.unknownBits.TabIndex = 6;
            // 
            // doorFormat
            // 
            this.doorFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.doorFormat.Enabled = false;
            this.doorFormat.Items.AddRange(new object[] {
            "{none}",
            "{unknown}",
            "{unknown}",
            "{unknown}",
            "{unknown}",
            "NE,SW",
            "{unknown}",
            "NW,SE"});
            this.doorFormat.Location = new System.Drawing.Point(154, 511);
            this.doorFormat.Name = "doorFormat";
            this.doorFormat.Size = new System.Drawing.Size(69, 21);
            this.doorFormat.TabIndex = 5;
            // 
            // searchResults
            // 
            this.searchResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.searchResults.FormattingEnabled = true;
            this.searchResults.IntegralHeight = false;
            this.searchResults.Location = new System.Drawing.Point(229, 154);
            this.searchResults.Name = "searchResults";
            this.searchResults.Size = new System.Drawing.Size(227, 450);
            this.searchResults.TabIndex = 3;
            this.searchResults.SelectedIndexChanged += new System.EventHandler(this.searchResults_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.unknownBits);
            this.panel1.Controls.Add(this.doorFormat);
            this.panel1.Controls.Add(this.headerLabel5);
            this.panel1.Controls.Add(this.conveyorBeltNormal);
            this.panel1.Controls.Add(this.specialTile);
            this.panel1.Controls.Add(this.p3OnTile);
            this.panel1.Controls.Add(this.stairs);
            this.panel1.Controls.Add(this.checkStairs);
            this.panel1.Controls.Add(this.conveyorBeltFast);
            this.panel1.Controls.Add(this.checkSpecialTile);
            this.panel1.Controls.Add(this.headerLabel4);
            this.panel1.Controls.Add(this.checkDoorFormat);
            this.panel1.Controls.Add(this.conveyor);
            this.panel1.Controls.Add(this.checkConveyor);
            this.panel1.Controls.Add(this.checkSolidQuadrantS);
            this.panel1.Controls.Add(this.checkConveyorBeltFast);
            this.panel1.Controls.Add(this.p3OverEdge);
            this.panel1.Controls.Add(this.checkConveyorBeltNormal);
            this.panel1.Controls.Add(this.zCoordPlusHalf);
            this.panel1.Controls.Add(this.p3OnEdge);
            this.panel1.Controls.Add(this.checkP3OnEdge);
            this.panel1.Controls.Add(this.headerLabel3);
            this.panel1.Controls.Add(this.checkP3OverEdge);
            this.panel1.Controls.Add(this.checkSolidQuadrantE);
            this.panel1.Controls.Add(this.checkP3OnTile);
            this.panel1.Controls.Add(this.checkSolidQuadrantN);
            this.panel1.Controls.Add(this.checkSolidEdgeNW);
            this.panel1.Controls.Add(this.headerLabel2);
            this.panel1.Controls.Add(this.checkSolidEdgeSW);
            this.panel1.Controls.Add(this.heightOfBaseTile);
            this.panel1.Controls.Add(this.checkSolidQuadrantW);
            this.panel1.Controls.Add(this.headerLabel1);
            this.panel1.Controls.Add(this.checkSolidEdgeSE);
            this.panel1.Controls.Add(this.zCoordOverhead);
            this.panel1.Controls.Add(this.checkSolidEdgeNE);
            this.panel1.Controls.Add(this.solidEdgeNE);
            this.panel1.Controls.Add(this.solidQuadrantS);
            this.panel1.Controls.Add(this.solidEdgeSW);
            this.panel1.Controls.Add(this.checkHeightOfBaseTile);
            this.panel1.Controls.Add(this.solidEdgeSE);
            this.panel1.Controls.Add(this.checkZCoordOverhead);
            this.panel1.Controls.Add(this.solidEdgeNW);
            this.panel1.Controls.Add(this.checkHeightOverhead);
            this.panel1.Controls.Add(this.solidQuadrantE);
            this.panel1.Controls.Add(this.heightOverhead);
            this.panel1.Controls.Add(this.solidQuadrantW);
            this.panel1.Controls.Add(this.checkZCoordWater);
            this.panel1.Controls.Add(this.solidQuadrantN);
            this.panel1.Controls.Add(this.zCoordWater);
            this.panel1.Controls.Add(this.solidQuadrant);
            this.panel1.Controls.Add(this.checkZCoordPlusHalf);
            this.panel1.Controls.Add(this.solidTile);
            this.panel1.Controls.Add(this.checkSolidQuadrant);
            this.panel1.Controls.Add(this.checkSolidTile);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(229, 579);
            this.panel1.TabIndex = 0;
            // 
            // checkStairs
            // 
            this.checkStairs.AutoSize = true;
            this.checkStairs.Location = new System.Drawing.Point(8, 471);
            this.checkStairs.Name = "checkStairs";
            this.checkStairs.Size = new System.Drawing.Size(76, 17);
            this.checkStairs.TabIndex = 0;
            this.checkStairs.Text = "Stairs lead";
            this.checkStairs.UseVisualStyleBackColor = false;
            this.checkStairs.CheckedChanged += new System.EventHandler(this.checkControl_CheckedChanged);
            // 
            // checkSpecialTile
            // 
            this.checkSpecialTile.AutoSize = true;
            this.checkSpecialTile.Location = new System.Drawing.Point(8, 491);
            this.checkSpecialTile.Name = "checkSpecialTile";
            this.checkSpecialTile.Size = new System.Drawing.Size(111, 17);
            this.checkSpecialTile.TabIndex = 1;
            this.checkSpecialTile.Text = "Special tile format";
            this.checkSpecialTile.UseVisualStyleBackColor = false;
            this.checkSpecialTile.CheckedChanged += new System.EventHandler(this.checkControl_CheckedChanged);
            // 
            // checkDoorFormat
            // 
            this.checkDoorFormat.AutoSize = true;
            this.checkDoorFormat.Location = new System.Drawing.Point(8, 511);
            this.checkDoorFormat.Name = "checkDoorFormat";
            this.checkDoorFormat.Size = new System.Drawing.Size(84, 17);
            this.checkDoorFormat.TabIndex = 2;
            this.checkDoorFormat.Text = "Door format";
            this.checkDoorFormat.UseVisualStyleBackColor = false;
            this.checkDoorFormat.CheckedChanged += new System.EventHandler(this.checkControl_CheckedChanged);
            // 
            // conveyorBeltNormal
            // 
            this.conveyorBeltNormal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.conveyorBeltNormal.Enabled = false;
            this.conveyorBeltNormal.Items.AddRange(new object[] {
            "false",
            "true"});
            this.conveyorBeltNormal.Location = new System.Drawing.Point(154, 428);
            this.conveyorBeltNormal.Name = "conveyorBeltNormal";
            this.conveyorBeltNormal.Size = new System.Drawing.Size(69, 21);
            this.conveyorBeltNormal.TabIndex = 5;
            // 
            // conveyorBeltFast
            // 
            this.conveyorBeltFast.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.conveyorBeltFast.Enabled = false;
            this.conveyorBeltFast.Items.AddRange(new object[] {
            "false",
            "true"});
            this.conveyorBeltFast.Location = new System.Drawing.Point(154, 407);
            this.conveyorBeltFast.Name = "conveyorBeltFast";
            this.conveyorBeltFast.Size = new System.Drawing.Size(69, 21);
            this.conveyorBeltFast.TabIndex = 4;
            // 
            // checkConveyor
            // 
            this.checkConveyor.AutoSize = true;
            this.checkConveyor.Location = new System.Drawing.Point(6, 388);
            this.checkConveyor.Name = "checkConveyor";
            this.checkConveyor.Size = new System.Drawing.Size(118, 17);
            this.checkConveyor.TabIndex = 0;
            this.checkConveyor.Text = "Conveyor belt runs";
            this.checkConveyor.UseVisualStyleBackColor = false;
            this.checkConveyor.CheckedChanged += new System.EventHandler(this.checkControl_CheckedChanged);
            // 
            // checkConveyorBeltFast
            // 
            this.checkConveyorBeltFast.AutoSize = true;
            this.checkConveyorBeltFast.Location = new System.Drawing.Point(6, 408);
            this.checkConveyorBeltFast.Name = "checkConveyorBeltFast";
            this.checkConveyorBeltFast.Size = new System.Drawing.Size(120, 17);
            this.checkConveyorBeltFast.TabIndex = 1;
            this.checkConveyorBeltFast.Text = "Conveyor belt, fast";
            this.checkConveyorBeltFast.UseVisualStyleBackColor = false;
            this.checkConveyorBeltFast.CheckedChanged += new System.EventHandler(this.checkControl_CheckedChanged);
            // 
            // checkConveyorBeltNormal
            // 
            this.checkConveyorBeltNormal.AutoSize = true;
            this.checkConveyorBeltNormal.Location = new System.Drawing.Point(6, 428);
            this.checkConveyorBeltNormal.Name = "checkConveyorBeltNormal";
            this.checkConveyorBeltNormal.Size = new System.Drawing.Size(133, 17);
            this.checkConveyorBeltNormal.TabIndex = 2;
            this.checkConveyorBeltNormal.Text = "Conveyor belt, normal";
            this.checkConveyorBeltNormal.UseVisualStyleBackColor = false;
            this.checkConveyorBeltNormal.CheckedChanged += new System.EventHandler(this.checkControl_CheckedChanged);
            // 
            // p3OnTile
            // 
            this.p3OnTile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.p3OnTile.Enabled = false;
            this.p3OnTile.Items.AddRange(new object[] {
            "false",
            "true"});
            this.p3OnTile.Location = new System.Drawing.Point(154, 345);
            this.p3OnTile.Name = "p3OnTile";
            this.p3OnTile.Size = new System.Drawing.Size(69, 21);
            this.p3OnTile.TabIndex = 5;
            // 
            // p3OverEdge
            // 
            this.p3OverEdge.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.p3OverEdge.Enabled = false;
            this.p3OverEdge.Items.AddRange(new object[] {
            "false",
            "true"});
            this.p3OverEdge.Location = new System.Drawing.Point(154, 324);
            this.p3OverEdge.Name = "p3OverEdge";
            this.p3OverEdge.Size = new System.Drawing.Size(69, 21);
            this.p3OverEdge.TabIndex = 4;
            // 
            // p3OnEdge
            // 
            this.p3OnEdge.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.p3OnEdge.Enabled = false;
            this.p3OnEdge.Items.AddRange(new object[] {
            "false",
            "true"});
            this.p3OnEdge.Location = new System.Drawing.Point(154, 303);
            this.p3OnEdge.Name = "p3OnEdge";
            this.p3OnEdge.Size = new System.Drawing.Size(69, 21);
            this.p3OnEdge.TabIndex = 3;
            // 
            // checkP3OnEdge
            // 
            this.checkP3OnEdge.AutoSize = true;
            this.checkP3OnEdge.Location = new System.Drawing.Point(6, 305);
            this.checkP3OnEdge.Name = "checkP3OnEdge";
            this.checkP3OnEdge.Size = new System.Drawing.Size(130, 17);
            this.checkP3OnEdge.TabIndex = 0;
            this.checkP3OnEdge.Text = "P3 for object on edge";
            this.checkP3OnEdge.UseVisualStyleBackColor = false;
            this.checkP3OnEdge.CheckedChanged += new System.EventHandler(this.checkControl_CheckedChanged);
            // 
            // checkP3OverEdge
            // 
            this.checkP3OverEdge.AutoSize = true;
            this.checkP3OverEdge.Location = new System.Drawing.Point(6, 325);
            this.checkP3OverEdge.Name = "checkP3OverEdge";
            this.checkP3OverEdge.Size = new System.Drawing.Size(140, 17);
            this.checkP3OverEdge.TabIndex = 1;
            this.checkP3OverEdge.Text = "P3 for object over edge";
            this.checkP3OverEdge.UseVisualStyleBackColor = false;
            this.checkP3OverEdge.CheckedChanged += new System.EventHandler(this.checkControl_CheckedChanged);
            // 
            // checkP3OnTile
            // 
            this.checkP3OnTile.AutoSize = true;
            this.checkP3OnTile.Location = new System.Drawing.Point(6, 345);
            this.checkP3OnTile.Name = "checkP3OnTile";
            this.checkP3OnTile.Size = new System.Drawing.Size(120, 17);
            this.checkP3OnTile.TabIndex = 2;
            this.checkP3OnTile.Text = "P3 for object on tile";
            this.checkP3OnTile.UseVisualStyleBackColor = false;
            this.checkP3OnTile.CheckedChanged += new System.EventHandler(this.checkControl_CheckedChanged);
            // 
            // checkSolidQuadrantS
            // 
            this.checkSolidQuadrantS.AutoSize = true;
            this.checkSolidQuadrantS.Location = new System.Drawing.Point(61, 223);
            this.checkSolidQuadrantS.Name = "checkSolidQuadrantS";
            this.checkSolidQuadrantS.Size = new System.Drawing.Size(15, 14);
            this.checkSolidQuadrantS.TabIndex = 6;
            this.checkSolidQuadrantS.UseVisualStyleBackColor = false;
            this.checkSolidQuadrantS.CheckedChanged += new System.EventHandler(this.checkControl_CheckedChanged);
            // 
            // checkSolidQuadrantE
            // 
            this.checkSolidQuadrantE.AutoSize = true;
            this.checkSolidQuadrantE.Location = new System.Drawing.Point(118, 185);
            this.checkSolidQuadrantE.Name = "checkSolidQuadrantE";
            this.checkSolidQuadrantE.Size = new System.Drawing.Size(15, 14);
            this.checkSolidQuadrantE.TabIndex = 4;
            this.checkSolidQuadrantE.UseVisualStyleBackColor = false;
            this.checkSolidQuadrantE.CheckedChanged += new System.EventHandler(this.checkControl_CheckedChanged);
            // 
            // checkSolidQuadrantN
            // 
            this.checkSolidQuadrantN.AutoSize = true;
            this.checkSolidQuadrantN.Location = new System.Drawing.Point(61, 147);
            this.checkSolidQuadrantN.Name = "checkSolidQuadrantN";
            this.checkSolidQuadrantN.Size = new System.Drawing.Size(15, 14);
            this.checkSolidQuadrantN.TabIndex = 0;
            this.checkSolidQuadrantN.UseVisualStyleBackColor = false;
            this.checkSolidQuadrantN.CheckedChanged += new System.EventHandler(this.checkControl_CheckedChanged);
            // 
            // checkSolidEdgeNW
            // 
            this.checkSolidEdgeNW.AutoSize = true;
            this.checkSolidEdgeNW.Location = new System.Drawing.Point(6, 147);
            this.checkSolidEdgeNW.Name = "checkSolidEdgeNW";
            this.checkSolidEdgeNW.Size = new System.Drawing.Size(15, 14);
            this.checkSolidEdgeNW.TabIndex = 0;
            this.checkSolidEdgeNW.UseVisualStyleBackColor = false;
            this.checkSolidEdgeNW.CheckedChanged += new System.EventHandler(this.checkControl_CheckedChanged);
            // 
            // checkSolidEdgeSW
            // 
            this.checkSolidEdgeSW.AutoSize = true;
            this.checkSolidEdgeSW.Location = new System.Drawing.Point(6, 222);
            this.checkSolidEdgeSW.Name = "checkSolidEdgeSW";
            this.checkSolidEdgeSW.Size = new System.Drawing.Size(15, 14);
            this.checkSolidEdgeSW.TabIndex = 2;
            this.checkSolidEdgeSW.UseVisualStyleBackColor = false;
            this.checkSolidEdgeSW.CheckedChanged += new System.EventHandler(this.checkControl_CheckedChanged);
            // 
            // checkSolidQuadrantW
            // 
            this.checkSolidQuadrantW.AutoSize = true;
            this.checkSolidQuadrantW.Location = new System.Drawing.Point(6, 184);
            this.checkSolidQuadrantW.Name = "checkSolidQuadrantW";
            this.checkSolidQuadrantW.Size = new System.Drawing.Size(15, 14);
            this.checkSolidQuadrantW.TabIndex = 2;
            this.checkSolidQuadrantW.UseVisualStyleBackColor = false;
            this.checkSolidQuadrantW.CheckedChanged += new System.EventHandler(this.checkControl_CheckedChanged);
            // 
            // checkSolidEdgeSE
            // 
            this.checkSolidEdgeSE.AutoSize = true;
            this.checkSolidEdgeSE.Location = new System.Drawing.Point(118, 222);
            this.checkSolidEdgeSE.Name = "checkSolidEdgeSE";
            this.checkSolidEdgeSE.Size = new System.Drawing.Size(15, 14);
            this.checkSolidEdgeSE.TabIndex = 6;
            this.checkSolidEdgeSE.UseVisualStyleBackColor = false;
            this.checkSolidEdgeSE.CheckedChanged += new System.EventHandler(this.checkControl_CheckedChanged);
            // 
            // checkSolidEdgeNE
            // 
            this.checkSolidEdgeNE.AutoSize = true;
            this.checkSolidEdgeNE.Location = new System.Drawing.Point(118, 147);
            this.checkSolidEdgeNE.Name = "checkSolidEdgeNE";
            this.checkSolidEdgeNE.Size = new System.Drawing.Size(15, 14);
            this.checkSolidEdgeNE.TabIndex = 4;
            this.checkSolidEdgeNE.UseVisualStyleBackColor = false;
            this.checkSolidEdgeNE.CheckedChanged += new System.EventHandler(this.checkControl_CheckedChanged);
            // 
            // solidEdgeNE
            // 
            this.solidEdgeNE.Appearance = System.Windows.Forms.Appearance.Button;
            this.solidEdgeNE.Enabled = false;
            this.solidEdgeNE.Location = new System.Drawing.Point(84, 161);
            this.solidEdgeNE.Name = "solidEdgeNE";
            this.solidEdgeNE.Size = new System.Drawing.Size(32, 20);
            this.solidEdgeNE.TabIndex = 16;
            this.solidEdgeNE.UseVisualStyleBackColor = true;
            // 
            // solidQuadrantS
            // 
            this.solidQuadrantS.Appearance = System.Windows.Forms.Appearance.Button;
            this.solidQuadrantS.Enabled = false;
            this.solidQuadrantS.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.solidQuadrantS.Image = ((System.Drawing.Image)(resources.GetObject("solidQuadrantS.Image")));
            this.solidQuadrantS.Location = new System.Drawing.Point(52, 201);
            this.solidQuadrantS.Name = "solidQuadrantS";
            this.solidQuadrantS.Size = new System.Drawing.Size(32, 20);
            this.solidQuadrantS.TabIndex = 19;
            this.solidQuadrantS.UseVisualStyleBackColor = true;
            // 
            // solidEdgeSW
            // 
            this.solidEdgeSW.Appearance = System.Windows.Forms.Appearance.Button;
            this.solidEdgeSW.Enabled = false;
            this.solidEdgeSW.Location = new System.Drawing.Point(20, 201);
            this.solidEdgeSW.Name = "solidEdgeSW";
            this.solidEdgeSW.Size = new System.Drawing.Size(32, 20);
            this.solidEdgeSW.TabIndex = 15;
            this.solidEdgeSW.UseVisualStyleBackColor = true;
            // 
            // solidEdgeSE
            // 
            this.solidEdgeSE.Appearance = System.Windows.Forms.Appearance.Button;
            this.solidEdgeSE.Enabled = false;
            this.solidEdgeSE.Location = new System.Drawing.Point(84, 201);
            this.solidEdgeSE.Name = "solidEdgeSE";
            this.solidEdgeSE.Size = new System.Drawing.Size(32, 20);
            this.solidEdgeSE.TabIndex = 13;
            this.solidEdgeSE.UseVisualStyleBackColor = true;
            // 
            // solidEdgeNW
            // 
            this.solidEdgeNW.Appearance = System.Windows.Forms.Appearance.Button;
            this.solidEdgeNW.Enabled = false;
            this.solidEdgeNW.Location = new System.Drawing.Point(20, 161);
            this.solidEdgeNW.Name = "solidEdgeNW";
            this.solidEdgeNW.Size = new System.Drawing.Size(32, 20);
            this.solidEdgeNW.TabIndex = 14;
            this.solidEdgeNW.UseVisualStyleBackColor = true;
            // 
            // solidQuadrantE
            // 
            this.solidQuadrantE.Appearance = System.Windows.Forms.Appearance.Button;
            this.solidQuadrantE.Enabled = false;
            this.solidQuadrantE.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.solidQuadrantE.Image = ((System.Drawing.Image)(resources.GetObject("solidQuadrantE.Image")));
            this.solidQuadrantE.Location = new System.Drawing.Point(84, 181);
            this.solidQuadrantE.Name = "solidQuadrantE";
            this.solidQuadrantE.Size = new System.Drawing.Size(32, 20);
            this.solidQuadrantE.TabIndex = 20;
            this.solidQuadrantE.UseVisualStyleBackColor = true;
            // 
            // solidQuadrantW
            // 
            this.solidQuadrantW.Appearance = System.Windows.Forms.Appearance.Button;
            this.solidQuadrantW.Enabled = false;
            this.solidQuadrantW.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.solidQuadrantW.Image = ((System.Drawing.Image)(resources.GetObject("solidQuadrantW.Image")));
            this.solidQuadrantW.Location = new System.Drawing.Point(20, 181);
            this.solidQuadrantW.Name = "solidQuadrantW";
            this.solidQuadrantW.Size = new System.Drawing.Size(32, 20);
            this.solidQuadrantW.TabIndex = 17;
            this.solidQuadrantW.UseVisualStyleBackColor = true;
            // 
            // solidQuadrantN
            // 
            this.solidQuadrantN.Appearance = System.Windows.Forms.Appearance.Button;
            this.solidQuadrantN.Enabled = false;
            this.solidQuadrantN.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.solidQuadrantN.Image = global::LAZYSHELL.Properties.Resources.quadBase;
            this.solidQuadrantN.Location = new System.Drawing.Point(52, 161);
            this.solidQuadrantN.Name = "solidQuadrantN";
            this.solidQuadrantN.Size = new System.Drawing.Size(32, 20);
            this.solidQuadrantN.TabIndex = 18;
            this.solidQuadrantN.UseVisualStyleBackColor = true;
            // 
            // solidQuadrant
            // 
            this.solidQuadrant.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.solidQuadrant.Enabled = false;
            this.solidQuadrant.Items.AddRange(new object[] {
            "false",
            "true"});
            this.solidQuadrant.Location = new System.Drawing.Point(154, 262);
            this.solidQuadrant.Name = "solidQuadrant";
            this.solidQuadrant.Size = new System.Drawing.Size(69, 21);
            this.solidQuadrant.TabIndex = 11;
            // 
            // solidTile
            // 
            this.solidTile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.solidTile.Enabled = false;
            this.solidTile.Items.AddRange(new object[] {
            "false",
            "true"});
            this.solidTile.Location = new System.Drawing.Point(154, 241);
            this.solidTile.Name = "solidTile";
            this.solidTile.Size = new System.Drawing.Size(69, 21);
            this.solidTile.TabIndex = 10;
            // 
            // checkSolidTile
            // 
            this.checkSolidTile.AutoSize = true;
            this.checkSolidTile.Location = new System.Drawing.Point(6, 243);
            this.checkSolidTile.Name = "checkSolidTile";
            this.checkSolidTile.Size = new System.Drawing.Size(65, 17);
            this.checkSolidTile.TabIndex = 8;
            this.checkSolidTile.Text = "Solid tile";
            this.checkSolidTile.UseVisualStyleBackColor = false;
            this.checkSolidTile.CheckedChanged += new System.EventHandler(this.checkControl_CheckedChanged);
            // 
            // checkSolidQuadrant
            // 
            this.checkSolidQuadrant.AutoSize = true;
            this.checkSolidQuadrant.Location = new System.Drawing.Point(6, 263);
            this.checkSolidQuadrant.Name = "checkSolidQuadrant";
            this.checkSolidQuadrant.Size = new System.Drawing.Size(95, 17);
            this.checkSolidQuadrant.TabIndex = 9;
            this.checkSolidQuadrant.Text = "Solid quadrant";
            this.checkSolidQuadrant.UseVisualStyleBackColor = false;
            this.checkSolidQuadrant.CheckedChanged += new System.EventHandler(this.checkControl_CheckedChanged);
            // 
            // zCoordPlusHalf
            // 
            this.zCoordPlusHalf.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.zCoordPlusHalf.Enabled = false;
            this.zCoordPlusHalf.Items.AddRange(new object[] {
            "false",
            "true"});
            this.zCoordPlusHalf.Location = new System.Drawing.Point(163, 104);
            this.zCoordPlusHalf.Name = "zCoordPlusHalf";
            this.zCoordPlusHalf.Size = new System.Drawing.Size(63, 21);
            this.zCoordPlusHalf.TabIndex = 9;
            // 
            // heightOfBaseTile
            // 
            this.heightOfBaseTile.Enabled = false;
            this.heightOfBaseTile.Location = new System.Drawing.Point(163, 20);
            this.heightOfBaseTile.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.heightOfBaseTile.Name = "heightOfBaseTile";
            this.heightOfBaseTile.Size = new System.Drawing.Size(63, 21);
            this.heightOfBaseTile.TabIndex = 5;
            // 
            // zCoordOverhead
            // 
            this.zCoordOverhead.Enabled = false;
            this.zCoordOverhead.Location = new System.Drawing.Point(163, 62);
            this.zCoordOverhead.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.zCoordOverhead.Name = "zCoordOverhead";
            this.zCoordOverhead.Size = new System.Drawing.Size(63, 21);
            this.zCoordOverhead.TabIndex = 7;
            // 
            // checkHeightOfBaseTile
            // 
            this.checkHeightOfBaseTile.AutoSize = true;
            this.checkHeightOfBaseTile.Location = new System.Drawing.Point(6, 24);
            this.checkHeightOfBaseTile.Name = "checkHeightOfBaseTile";
            this.checkHeightOfBaseTile.Size = new System.Drawing.Size(113, 17);
            this.checkHeightOfBaseTile.TabIndex = 0;
            this.checkHeightOfBaseTile.Text = "Height of base tile";
            this.checkHeightOfBaseTile.CheckedChanged += new System.EventHandler(this.checkControl_CheckedChanged);
            // 
            // heightOverhead
            // 
            this.heightOverhead.Enabled = false;
            this.heightOverhead.Location = new System.Drawing.Point(163, 41);
            this.heightOverhead.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.heightOverhead.Name = "heightOverhead";
            this.heightOverhead.Size = new System.Drawing.Size(63, 21);
            this.heightOverhead.TabIndex = 6;
            // 
            // checkZCoordPlusHalf
            // 
            this.checkZCoordPlusHalf.AutoSize = true;
            this.checkZCoordPlusHalf.Location = new System.Drawing.Point(6, 104);
            this.checkZCoordPlusHalf.Name = "checkZCoordPlusHalf";
            this.checkZCoordPlusHalf.Size = new System.Drawing.Size(103, 17);
            this.checkZCoordPlusHalf.TabIndex = 4;
            this.checkZCoordPlusHalf.Text = "Z coord plus 1/2";
            this.checkZCoordPlusHalf.CheckedChanged += new System.EventHandler(this.checkControl_CheckedChanged);
            // 
            // zCoordWater
            // 
            this.zCoordWater.Enabled = false;
            this.zCoordWater.Location = new System.Drawing.Point(163, 83);
            this.zCoordWater.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.zCoordWater.Name = "zCoordWater";
            this.zCoordWater.Size = new System.Drawing.Size(63, 21);
            this.zCoordWater.TabIndex = 8;
            // 
            // checkZCoordWater
            // 
            this.checkZCoordWater.AutoSize = true;
            this.checkZCoordWater.Location = new System.Drawing.Point(6, 84);
            this.checkZCoordWater.Name = "checkZCoordWater";
            this.checkZCoordWater.Size = new System.Drawing.Size(123, 17);
            this.checkZCoordWater.TabIndex = 3;
            this.checkZCoordWater.Text = "Z coord of water tile";
            this.checkZCoordWater.CheckedChanged += new System.EventHandler(this.checkControl_CheckedChanged);
            // 
            // checkHeightOverhead
            // 
            this.checkHeightOverhead.AutoSize = true;
            this.checkHeightOverhead.Location = new System.Drawing.Point(6, 44);
            this.checkHeightOverhead.Name = "checkHeightOverhead";
            this.checkHeightOverhead.Size = new System.Drawing.Size(136, 17);
            this.checkHeightOverhead.TabIndex = 1;
            this.checkHeightOverhead.Text = "Height of overhead tile";
            this.checkHeightOverhead.CheckedChanged += new System.EventHandler(this.checkControl_CheckedChanged);
            // 
            // checkZCoordOverhead
            // 
            this.checkZCoordOverhead.AutoSize = true;
            this.checkZCoordOverhead.Location = new System.Drawing.Point(6, 64);
            this.checkZCoordOverhead.Name = "checkZCoordOverhead";
            this.checkZCoordOverhead.Size = new System.Drawing.Size(141, 17);
            this.checkZCoordOverhead.TabIndex = 2;
            this.checkZCoordOverhead.Text = "Z coord of overhead tile";
            this.checkZCoordOverhead.CheckedChanged += new System.EventHandler(this.checkControl_CheckedChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectAll,
            this.deselectAll,
            this.search});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(456, 25);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // selectAll
            // 
            this.selectAll.Image = global::LAZYSHELL.Properties.Resources.checkAll;
            this.selectAll.Name = "selectAll";
            this.selectAll.Size = new System.Drawing.Size(23, 22);
            this.selectAll.ToolTipText = "Check All";
            this.selectAll.Click += new System.EventHandler(this.selectAll_Click);
            // 
            // deselectAll
            // 
            this.deselectAll.Image = global::LAZYSHELL.Properties.Resources.uncheckAll;
            this.deselectAll.Name = "deselectAll";
            this.deselectAll.Size = new System.Drawing.Size(23, 22);
            this.deselectAll.ToolTipText = "Uncheck All";
            this.deselectAll.Click += new System.EventHandler(this.deselectAll_Click);
            // 
            // search
            // 
            this.search.Image = global::LAZYSHELL.Properties.Resources.search;
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(23, 22);
            this.search.ToolTipText = "Search for tiles w/checked properties";
            this.search.Click += new System.EventHandler(this.search_Click);
            // 
            // withProperties
            // 
            this.withProperties.BackColor = System.Drawing.SystemColors.Window;
            this.withProperties.Dock = System.Windows.Forms.DockStyle.Top;
            this.withProperties.Location = new System.Drawing.Point(229, 25);
            this.withProperties.Name = "withProperties";
            this.withProperties.ReadOnly = true;
            this.withProperties.Size = new System.Drawing.Size(227, 129);
            this.withProperties.TabIndex = 2;
            this.withProperties.Text = "";
            // 
            // headerLabel5
            // 
            this.headerLabel5.Location = new System.Drawing.Point(0, 452);
            this.headerLabel5.Name = "headerLabel5";
            this.headerLabel5.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.headerLabel5.Size = new System.Drawing.Size(229, 14);
            this.headerLabel5.TabIndex = 8;
            this.headerLabel5.Text = "Other";
            // 
            // headerLabel4
            // 
            this.headerLabel4.Location = new System.Drawing.Point(1, 369);
            this.headerLabel4.Name = "headerLabel4";
            this.headerLabel4.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.headerLabel4.Size = new System.Drawing.Size(228, 14);
            this.headerLabel4.TabIndex = 9;
            this.headerLabel4.Text = "Conveyor Belt";
            // 
            // headerLabel3
            // 
            this.headerLabel3.Location = new System.Drawing.Point(0, 286);
            this.headerLabel3.Name = "headerLabel3";
            this.headerLabel3.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.headerLabel3.Size = new System.Drawing.Size(229, 14);
            this.headerLabel3.TabIndex = 7;
            this.headerLabel3.Text = "Priority 3";
            // 
            // headerLabel2
            // 
            this.headerLabel2.Location = new System.Drawing.Point(0, 128);
            this.headerLabel2.Name = "headerLabel2";
            this.headerLabel2.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.headerLabel2.Size = new System.Drawing.Size(229, 14);
            this.headerLabel2.TabIndex = 5;
            this.headerLabel2.Text = "Quadrant / edge solidity";
            // 
            // headerLabel1
            // 
            this.headerLabel1.Location = new System.Drawing.Point(0, 3);
            this.headerLabel1.Name = "headerLabel1";
            this.headerLabel1.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.headerLabel1.Size = new System.Drawing.Size(229, 14);
            this.headerLabel1.TabIndex = 6;
            this.headerLabel1.Text = "Tile height / coordinates";
            // 
            // SearchCollisionTileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 604);
            this.Controls.Add(this.searchResults);
            this.Controls.Add(this.withProperties);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Location = new System.Drawing.Point(0, 0);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SearchCollisionTileForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "SEARCH FOR COLLISION TILE";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SearchCollisionTileForm_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.heightOfBaseTile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zCoordOverhead)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.heightOverhead)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zCoordWater)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        private CheckBox checkConveyor;
        private CheckBox checkConveyorBeltFast;
        private CheckBox checkConveyorBeltNormal;
        private CheckBox checkDoorFormat;
        private CheckBox checkHeightOfBaseTile;
        private CheckBox checkHeightOverhead;
        private CheckBox checkP3OnEdge;
        private CheckBox checkP3OnTile;
        private CheckBox checkP3OverEdge;
        private CheckBox checkSolidEdgeNE;
        private CheckBox checkSolidEdgeNW;
        private CheckBox checkSolidEdgeSE;
        private CheckBox checkSolidEdgeSW;
        private CheckBox checkSolidQuadrant;
        private CheckBox checkSolidQuadrantE;
        private CheckBox checkSolidQuadrantN;
        private CheckBox checkSolidQuadrantS;
        private CheckBox checkSolidQuadrantW;
        private CheckBox checkSolidTile;
        private CheckBox checkSpecialTile;
        private CheckBox checkStairs;
        private CheckBox checkZCoordOverhead;
        private CheckBox checkZCoordPlusHalf;
        private CheckBox checkZCoordWater;
        private CheckedListBox unknownBits;
        private ComboBox conveyor;
        private ComboBox conveyorBeltFast;
        private ComboBox conveyorBeltNormal;
        private ComboBox doorFormat;
        private ComboBox p3OnEdge;
        private ComboBox p3OnTile;
        private ComboBox p3OverEdge;
        private ComboBox solidQuadrant;
        private ComboBox solidTile;
        private ComboBox specialTile;
        private ComboBox stairs;
        private ComboBox zCoordPlusHalf;
        private ListBox searchResults;
        private NumericUpDown heightOfBaseTile;
        private NumericUpDown heightOverhead;
        private NumericUpDown zCoordOverhead;
        private NumericUpDown zCoordWater;
        private Panel panel1;
        private ToolStrip toolStrip1;
        private ToolStripButton selectAll;
        private ToolStripButton deselectAll;
        private ToolStripButton search;
        private RichTextBox withProperties;
        private CheckBox solidEdgeNE;
        private CheckBox solidQuadrantS;
        private CheckBox solidEdgeSW;
        private CheckBox solidEdgeSE;
        private CheckBox solidEdgeNW;
        private CheckBox solidQuadrantE;
        private CheckBox solidQuadrantW;
        private CheckBox solidQuadrantN;
        private Controls.HeaderLabel headerLabel2;
        private Controls.HeaderLabel headerLabel1;
        private Controls.HeaderLabel headerLabel5;
        private Controls.HeaderLabel headerLabel4;
        private Controls.HeaderLabel headerLabel3;
    }
}