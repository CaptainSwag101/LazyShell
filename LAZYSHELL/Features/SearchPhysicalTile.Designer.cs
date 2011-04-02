using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LAZYSHELL
{
    partial class SearchSolidTile
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
            this.panel55 = new System.Windows.Forms.Panel();
            this.specialTile = new System.Windows.Forms.ComboBox();
            this.panel54 = new System.Windows.Forms.Panel();
            this.stairs = new System.Windows.Forms.ComboBox();
            this.panel44 = new System.Windows.Forms.Panel();
            this.conveyor = new System.Windows.Forms.ComboBox();
            this.withProperties = new System.Windows.Forms.RichTextBox();
            this.unknownBits = new System.Windows.Forms.CheckedListBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.doorFormat = new System.Windows.Forms.ComboBox();
            this.searchResults = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.searchButton = new System.Windows.Forms.Button();
            this.panel27 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.panel23 = new System.Windows.Forms.Panel();
            this.heightOfBaseTile = new System.Windows.Forms.NumericUpDown();
            this.zCoordOverhead = new System.Windows.Forms.NumericUpDown();
            this.heightOverhead = new System.Windows.Forms.NumericUpDown();
            this.zCoordWater = new System.Windows.Forms.NumericUpDown();
            this.checkZCoordOverhead = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.checkHeightOverhead = new System.Windows.Forms.CheckBox();
            this.checkHeightOfBaseTile = new System.Windows.Forms.CheckBox();
            this.panel24 = new System.Windows.Forms.Panel();
            this.zCoordPlusHalf = new System.Windows.Forms.ComboBox();
            this.checkZCoordWater = new System.Windows.Forms.CheckBox();
            this.checkZCoordPlusHalf = new System.Windows.Forms.CheckBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.checkStairs = new System.Windows.Forms.CheckBox();
            this.checkDoorFormat = new System.Windows.Forms.CheckBox();
            this.checkSpecialTile = new System.Windows.Forms.CheckBox();
            this.panel12 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.checkConveyor = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.conveyorBeltFast = new System.Windows.Forms.ComboBox();
            this.checkConveyorBeltNormal = new System.Windows.Forms.CheckBox();
            this.checkConveyorBeltFast = new System.Windows.Forms.CheckBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.conveyorBeltNormal = new System.Windows.Forms.ComboBox();
            this.panel19 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.checkP3OnEdge = new System.Windows.Forms.CheckBox();
            this.panel20 = new System.Windows.Forms.Panel();
            this.p3OverEdge = new System.Windows.Forms.ComboBox();
            this.checkP3OnTile = new System.Windows.Forms.CheckBox();
            this.panel21 = new System.Windows.Forms.Panel();
            this.p3OnEdge = new System.Windows.Forms.ComboBox();
            this.checkP3OverEdge = new System.Windows.Forms.CheckBox();
            this.panel22 = new System.Windows.Forms.Panel();
            this.p3OnTile = new System.Windows.Forms.ComboBox();
            this.panel13 = new System.Windows.Forms.Panel();
            this.checkSolidQuadrantN = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.checkSolidQuadrant = new System.Windows.Forms.CheckBox();
            this.checkSolidTile = new System.Windows.Forms.CheckBox();
            this.panel14 = new System.Windows.Forms.Panel();
            this.solidQuadrantE = new System.Windows.Forms.ComboBox();
            this.panel15 = new System.Windows.Forms.Panel();
            this.solidQuadrantW = new System.Windows.Forms.ComboBox();
            this.checkSolidQuadrantW = new System.Windows.Forms.CheckBox();
            this.panel18 = new System.Windows.Forms.Panel();
            this.solidQuadrant = new System.Windows.Forms.ComboBox();
            this.panel16 = new System.Windows.Forms.Panel();
            this.solidQuadrantS = new System.Windows.Forms.ComboBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.solidTile = new System.Windows.Forms.ComboBox();
            this.panel17 = new System.Windows.Forms.Panel();
            this.solidQuadrantN = new System.Windows.Forms.ComboBox();
            this.checkSolidQuadrantS = new System.Windows.Forms.CheckBox();
            this.checkSolidQuadrantE = new System.Windows.Forms.CheckBox();
            this.panel11 = new System.Windows.Forms.Panel();
            this.checkSolidEdgeNW = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.solidEdgeSW = new System.Windows.Forms.ComboBox();
            this.panel8 = new System.Windows.Forms.Panel();
            this.solidEdgeNE = new System.Windows.Forms.ComboBox();
            this.checkSolidEdgeNE = new System.Windows.Forms.CheckBox();
            this.panel9 = new System.Windows.Forms.Panel();
            this.solidEdgeSE = new System.Windows.Forms.ComboBox();
            this.panel10 = new System.Windows.Forms.Panel();
            this.solidEdgeNW = new System.Windows.Forms.ComboBox();
            this.checkSolidEdgeSE = new System.Windows.Forms.CheckBox();
            this.checkSolidEdgeSW = new System.Windows.Forms.CheckBox();
            this.selectAll = new System.Windows.Forms.Button();
            this.deselectAll = new System.Windows.Forms.Button();
            this.panel55.SuspendLayout();
            this.panel54.SuspendLayout();
            this.panel44.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel27.SuspendLayout();
            this.panel23.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.heightOfBaseTile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zCoordOverhead)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.heightOverhead)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zCoordWater)).BeginInit();
            this.panel24.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel12.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel19.SuspendLayout();
            this.panel20.SuspendLayout();
            this.panel21.SuspendLayout();
            this.panel22.SuspendLayout();
            this.panel13.SuspendLayout();
            this.panel14.SuspendLayout();
            this.panel15.SuspendLayout();
            this.panel18.SuspendLayout();
            this.panel16.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel17.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel10.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel55
            // 
            this.panel55.BackColor = System.Drawing.SystemColors.Window;
            this.panel55.Controls.Add(this.specialTile);
            this.panel55.Location = new System.Drawing.Point(154, 37);
            this.panel55.Name = "panel55";
            this.panel55.Size = new System.Drawing.Size(51, 17);
            this.panel55.TabIndex = 372;
            // 
            // specialTile
            // 
            this.specialTile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.specialTile.Enabled = false;
            this.specialTile.Items.AddRange(new object[] {
            "{none}",
            "vines",
            "water"});
            this.specialTile.Location = new System.Drawing.Point(-2, -2);
            this.specialTile.Name = "specialTile";
            this.specialTile.Size = new System.Drawing.Size(55, 21);
            this.specialTile.TabIndex = 371;
            // 
            // panel54
            // 
            this.panel54.BackColor = System.Drawing.SystemColors.Window;
            this.panel54.Controls.Add(this.stairs);
            this.panel54.Location = new System.Drawing.Point(154, 19);
            this.panel54.Name = "panel54";
            this.panel54.Size = new System.Drawing.Size(51, 17);
            this.panel54.TabIndex = 370;
            // 
            // stairs
            // 
            this.stairs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.stairs.Enabled = false;
            this.stairs.Items.AddRange(new object[] {
            "{none}",
            "NW,SE",
            "NE,SW"});
            this.stairs.Location = new System.Drawing.Point(-2, -2);
            this.stairs.Name = "stairs";
            this.stairs.Size = new System.Drawing.Size(55, 21);
            this.stairs.TabIndex = 372;
            // 
            // panel44
            // 
            this.panel44.BackColor = System.Drawing.SystemColors.Window;
            this.panel44.Controls.Add(this.conveyor);
            this.panel44.Location = new System.Drawing.Point(154, 19);
            this.panel44.Name = "panel44";
            this.panel44.Size = new System.Drawing.Size(51, 17);
            this.panel44.TabIndex = 371;
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
            this.conveyor.Location = new System.Drawing.Point(-2, -2);
            this.conveyor.Name = "conveyor";
            this.conveyor.Size = new System.Drawing.Size(55, 21);
            this.conveyor.TabIndex = 370;
            // 
            // withProperties
            // 
            this.withProperties.BackColor = System.Drawing.SystemColors.Window;
            this.withProperties.Dock = System.Windows.Forms.DockStyle.Top;
            this.withProperties.Location = new System.Drawing.Point(214, 23);
            this.withProperties.Name = "withProperties";
            this.withProperties.ReadOnly = true;
            this.withProperties.Size = new System.Drawing.Size(229, 268);
            this.withProperties.TabIndex = 328;
            this.withProperties.Text = "";
            // 
            // unknownBits
            // 
            this.unknownBits.BackColor = System.Drawing.SystemColors.Window;
            this.unknownBits.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.unknownBits.CheckOnClick = true;
            this.unknownBits.ColumnWidth = 66;
            this.unknownBits.Items.AddRange(new object[] {
            "{B5,b0}",
            "{B5,b1}",
            "{B5,b2}",
            "{B5,b3}",
            "{B5,b4}"});
            this.unknownBits.Location = new System.Drawing.Point(0, 19);
            this.unknownBits.MultiColumn = true;
            this.unknownBits.Name = "unknownBits";
            this.unknownBits.Size = new System.Drawing.Size(205, 32);
            this.unknownBits.TabIndex = 388;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Window;
            this.panel3.Controls.Add(this.doorFormat);
            this.panel3.Location = new System.Drawing.Point(154, 55);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(51, 17);
            this.panel3.TabIndex = 372;
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
            "NE,SE",
            "{unknown}",
            "NE,SW"});
            this.doorFormat.Location = new System.Drawing.Point(-2, -2);
            this.doorFormat.Name = "doorFormat";
            this.doorFormat.Size = new System.Drawing.Size(55, 21);
            this.doorFormat.TabIndex = 371;
            // 
            // searchResults
            // 
            this.searchResults.Dock = System.Windows.Forms.DockStyle.Right;
            this.searchResults.FormattingEnabled = true;
            this.searchResults.IntegralHeight = false;
            this.searchResults.Location = new System.Drawing.Point(214, 291);
            this.searchResults.Name = "searchResults";
            this.searchResults.Size = new System.Drawing.Size(229, 367);
            this.searchResults.TabIndex = 329;
            this.searchResults.SelectedIndexChanged += new System.EventHandler(this.searchResults_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.deselectAll);
            this.panel1.Controls.Add(this.selectAll);
            this.panel1.Controls.Add(this.panel27);
            this.panel1.Controls.Add(this.panel23);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel12);
            this.panel1.Controls.Add(this.panel19);
            this.panel1.Controls.Add(this.panel13);
            this.panel1.Controls.Add(this.panel11);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(214, 658);
            this.panel1.TabIndex = 391;
            // 
            // searchButton
            // 
            this.searchButton.BackColor = System.Drawing.SystemColors.Control;
            this.searchButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.searchButton.Location = new System.Drawing.Point(214, 0);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(229, 23);
            this.searchButton.TabIndex = 397;
            this.searchButton.Text = "Search for tiles w/checked properties";
            this.searchButton.UseVisualStyleBackColor = false;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // panel27
            // 
            this.panel27.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel27.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel27.Controls.Add(this.label6);
            this.panel27.Controls.Add(this.unknownBits);
            this.panel27.Location = new System.Drawing.Point(2, 601);
            this.panel27.Name = "panel27";
            this.panel27.Size = new System.Drawing.Size(209, 55);
            this.panel27.TabIndex = 395;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.SystemColors.Control;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Name = "label6";
            this.label6.Padding = new System.Windows.Forms.Padding(2, 2, 0, 0);
            this.label6.Size = new System.Drawing.Size(205, 17);
            this.label6.TabIndex = 393;
            this.label6.Text = "UNKNOWN";
            // 
            // panel23
            // 
            this.panel23.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel23.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel23.Controls.Add(this.heightOfBaseTile);
            this.panel23.Controls.Add(this.zCoordOverhead);
            this.panel23.Controls.Add(this.heightOverhead);
            this.panel23.Controls.Add(this.zCoordWater);
            this.panel23.Controls.Add(this.checkZCoordOverhead);
            this.panel23.Controls.Add(this.label4);
            this.panel23.Controls.Add(this.checkHeightOverhead);
            this.panel23.Controls.Add(this.checkHeightOfBaseTile);
            this.panel23.Controls.Add(this.panel24);
            this.panel23.Controls.Add(this.checkZCoordWater);
            this.panel23.Controls.Add(this.checkZCoordPlusHalf);
            this.panel23.Location = new System.Drawing.Point(3, 25);
            this.panel23.Name = "panel23";
            this.panel23.Size = new System.Drawing.Size(209, 112);
            this.panel23.TabIndex = 396;
            // 
            // heightOfBaseTile
            // 
            this.heightOfBaseTile.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.heightOfBaseTile.Enabled = false;
            this.heightOfBaseTile.Location = new System.Drawing.Point(154, 19);
            this.heightOfBaseTile.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.heightOfBaseTile.Name = "heightOfBaseTile";
            this.heightOfBaseTile.Size = new System.Drawing.Size(51, 17);
            this.heightOfBaseTile.TabIndex = 394;
            this.heightOfBaseTile.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // zCoordOverhead
            // 
            this.zCoordOverhead.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.zCoordOverhead.Enabled = false;
            this.zCoordOverhead.Location = new System.Drawing.Point(154, 55);
            this.zCoordOverhead.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.zCoordOverhead.Name = "zCoordOverhead";
            this.zCoordOverhead.Size = new System.Drawing.Size(51, 17);
            this.zCoordOverhead.TabIndex = 397;
            this.zCoordOverhead.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // heightOverhead
            // 
            this.heightOverhead.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.heightOverhead.Enabled = false;
            this.heightOverhead.Location = new System.Drawing.Point(154, 37);
            this.heightOverhead.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.heightOverhead.Name = "heightOverhead";
            this.heightOverhead.Size = new System.Drawing.Size(51, 17);
            this.heightOverhead.TabIndex = 396;
            this.heightOverhead.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // zCoordWater
            // 
            this.zCoordWater.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.zCoordWater.Enabled = false;
            this.zCoordWater.Location = new System.Drawing.Point(154, 73);
            this.zCoordWater.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.zCoordWater.Name = "zCoordWater";
            this.zCoordWater.Size = new System.Drawing.Size(51, 17);
            this.zCoordWater.TabIndex = 395;
            this.zCoordWater.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // checkZCoordOverhead
            // 
            this.checkZCoordOverhead.BackColor = System.Drawing.SystemColors.Control;
            this.checkZCoordOverhead.Location = new System.Drawing.Point(1, 55);
            this.checkZCoordOverhead.Name = "checkZCoordOverhead";
            this.checkZCoordOverhead.Size = new System.Drawing.Size(152, 17);
            this.checkZCoordOverhead.TabIndex = 389;
            this.checkZCoordOverhead.Text = "Z coord of overhead tile";
            this.checkZCoordOverhead.UseVisualStyleBackColor = false;
            this.checkZCoordOverhead.CheckedChanged += new System.EventHandler(this.checkControl_CheckedChanged);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.Control;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(2, 2, 0, 0);
            this.label4.Size = new System.Drawing.Size(205, 17);
            this.label4.TabIndex = 393;
            this.label4.Text = "SIZE / COORDS";
            // 
            // checkHeightOverhead
            // 
            this.checkHeightOverhead.BackColor = System.Drawing.SystemColors.Control;
            this.checkHeightOverhead.Location = new System.Drawing.Point(1, 37);
            this.checkHeightOverhead.Name = "checkHeightOverhead";
            this.checkHeightOverhead.Size = new System.Drawing.Size(152, 17);
            this.checkHeightOverhead.TabIndex = 389;
            this.checkHeightOverhead.Text = "Height of overhead tile";
            this.checkHeightOverhead.UseVisualStyleBackColor = false;
            this.checkHeightOverhead.CheckedChanged += new System.EventHandler(this.checkControl_CheckedChanged);
            // 
            // checkHeightOfBaseTile
            // 
            this.checkHeightOfBaseTile.BackColor = System.Drawing.SystemColors.Control;
            this.checkHeightOfBaseTile.Location = new System.Drawing.Point(1, 19);
            this.checkHeightOfBaseTile.Name = "checkHeightOfBaseTile";
            this.checkHeightOfBaseTile.Size = new System.Drawing.Size(152, 17);
            this.checkHeightOfBaseTile.TabIndex = 389;
            this.checkHeightOfBaseTile.Text = "Height of base tile";
            this.checkHeightOfBaseTile.UseVisualStyleBackColor = false;
            this.checkHeightOfBaseTile.CheckedChanged += new System.EventHandler(this.checkControl_CheckedChanged);
            // 
            // panel24
            // 
            this.panel24.BackColor = System.Drawing.SystemColors.Window;
            this.panel24.Controls.Add(this.zCoordPlusHalf);
            this.panel24.Location = new System.Drawing.Point(154, 91);
            this.panel24.Name = "panel24";
            this.panel24.Size = new System.Drawing.Size(51, 17);
            this.panel24.TabIndex = 371;
            // 
            // zCoordPlusHalf
            // 
            this.zCoordPlusHalf.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.zCoordPlusHalf.Enabled = false;
            this.zCoordPlusHalf.Items.AddRange(new object[] {
            "false",
            "true"});
            this.zCoordPlusHalf.Location = new System.Drawing.Point(-2, -2);
            this.zCoordPlusHalf.Name = "zCoordPlusHalf";
            this.zCoordPlusHalf.Size = new System.Drawing.Size(55, 21);
            this.zCoordPlusHalf.TabIndex = 370;
            // 
            // checkZCoordWater
            // 
            this.checkZCoordWater.BackColor = System.Drawing.SystemColors.Control;
            this.checkZCoordWater.Location = new System.Drawing.Point(1, 73);
            this.checkZCoordWater.Name = "checkZCoordWater";
            this.checkZCoordWater.Size = new System.Drawing.Size(152, 17);
            this.checkZCoordWater.TabIndex = 389;
            this.checkZCoordWater.Text = "Z coord of water tile";
            this.checkZCoordWater.UseVisualStyleBackColor = false;
            this.checkZCoordWater.CheckedChanged += new System.EventHandler(this.checkControl_CheckedChanged);
            // 
            // checkZCoordPlusHalf
            // 
            this.checkZCoordPlusHalf.BackColor = System.Drawing.SystemColors.Control;
            this.checkZCoordPlusHalf.Location = new System.Drawing.Point(1, 91);
            this.checkZCoordPlusHalf.Name = "checkZCoordPlusHalf";
            this.checkZCoordPlusHalf.Size = new System.Drawing.Size(152, 17);
            this.checkZCoordPlusHalf.TabIndex = 389;
            this.checkZCoordPlusHalf.Text = "Z coord plus 1/2";
            this.checkZCoordPlusHalf.UseVisualStyleBackColor = false;
            this.checkZCoordPlusHalf.CheckedChanged += new System.EventHandler(this.checkControl_CheckedChanged);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel5.Controls.Add(this.label5);
            this.panel5.Controls.Add(this.checkStairs);
            this.panel5.Controls.Add(this.panel55);
            this.panel5.Controls.Add(this.panel54);
            this.panel5.Controls.Add(this.checkDoorFormat);
            this.panel5.Controls.Add(this.panel3);
            this.panel5.Controls.Add(this.checkSpecialTile);
            this.panel5.Location = new System.Drawing.Point(3, 523);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(209, 76);
            this.panel5.TabIndex = 395;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.SystemColors.Control;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(2, 2, 0, 0);
            this.label5.Size = new System.Drawing.Size(205, 17);
            this.label5.TabIndex = 393;
            this.label5.Text = "OTHER";
            // 
            // checkStairs
            // 
            this.checkStairs.BackColor = System.Drawing.SystemColors.Control;
            this.checkStairs.Location = new System.Drawing.Point(1, 19);
            this.checkStairs.Name = "checkStairs";
            this.checkStairs.Size = new System.Drawing.Size(152, 17);
            this.checkStairs.TabIndex = 389;
            this.checkStairs.Text = "Stairs lead";
            this.checkStairs.UseVisualStyleBackColor = false;
            this.checkStairs.CheckedChanged += new System.EventHandler(this.checkControl_CheckedChanged);
            // 
            // checkDoorFormat
            // 
            this.checkDoorFormat.BackColor = System.Drawing.SystemColors.Control;
            this.checkDoorFormat.Location = new System.Drawing.Point(1, 55);
            this.checkDoorFormat.Name = "checkDoorFormat";
            this.checkDoorFormat.Size = new System.Drawing.Size(152, 17);
            this.checkDoorFormat.TabIndex = 389;
            this.checkDoorFormat.Text = "Door format";
            this.checkDoorFormat.UseVisualStyleBackColor = false;
            this.checkDoorFormat.CheckedChanged += new System.EventHandler(this.checkControl_CheckedChanged);
            // 
            // checkSpecialTile
            // 
            this.checkSpecialTile.BackColor = System.Drawing.SystemColors.Control;
            this.checkSpecialTile.Location = new System.Drawing.Point(1, 37);
            this.checkSpecialTile.Name = "checkSpecialTile";
            this.checkSpecialTile.Size = new System.Drawing.Size(152, 17);
            this.checkSpecialTile.TabIndex = 389;
            this.checkSpecialTile.Text = "Special tile format";
            this.checkSpecialTile.UseVisualStyleBackColor = false;
            this.checkSpecialTile.CheckedChanged += new System.EventHandler(this.checkControl_CheckedChanged);
            // 
            // panel12
            // 
            this.panel12.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel12.Controls.Add(this.label1);
            this.panel12.Controls.Add(this.checkConveyor);
            this.panel12.Controls.Add(this.panel2);
            this.panel12.Controls.Add(this.checkConveyorBeltNormal);
            this.panel12.Controls.Add(this.panel44);
            this.panel12.Controls.Add(this.checkConveyorBeltFast);
            this.panel12.Controls.Add(this.panel4);
            this.panel12.Location = new System.Drawing.Point(3, 445);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(209, 76);
            this.panel12.TabIndex = 395;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(2, 2, 0, 0);
            this.label1.Size = new System.Drawing.Size(205, 17);
            this.label1.TabIndex = 393;
            this.label1.Text = "CONVEYOR BELT";
            // 
            // checkConveyor
            // 
            this.checkConveyor.BackColor = System.Drawing.SystemColors.Control;
            this.checkConveyor.Location = new System.Drawing.Point(1, 19);
            this.checkConveyor.Name = "checkConveyor";
            this.checkConveyor.Size = new System.Drawing.Size(152, 17);
            this.checkConveyor.TabIndex = 389;
            this.checkConveyor.Text = "Conveyor belt runs";
            this.checkConveyor.UseVisualStyleBackColor = false;
            this.checkConveyor.CheckedChanged += new System.EventHandler(this.checkControl_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Window;
            this.panel2.Controls.Add(this.conveyorBeltFast);
            this.panel2.Location = new System.Drawing.Point(154, 37);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(51, 17);
            this.panel2.TabIndex = 371;
            // 
            // conveyorBeltFast
            // 
            this.conveyorBeltFast.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.conveyorBeltFast.Enabled = false;
            this.conveyorBeltFast.Items.AddRange(new object[] {
            "false",
            "true"});
            this.conveyorBeltFast.Location = new System.Drawing.Point(-2, -2);
            this.conveyorBeltFast.Name = "conveyorBeltFast";
            this.conveyorBeltFast.Size = new System.Drawing.Size(55, 21);
            this.conveyorBeltFast.TabIndex = 370;
            // 
            // checkConveyorBeltNormal
            // 
            this.checkConveyorBeltNormal.BackColor = System.Drawing.SystemColors.Control;
            this.checkConveyorBeltNormal.Location = new System.Drawing.Point(1, 55);
            this.checkConveyorBeltNormal.Name = "checkConveyorBeltNormal";
            this.checkConveyorBeltNormal.Size = new System.Drawing.Size(152, 17);
            this.checkConveyorBeltNormal.TabIndex = 389;
            this.checkConveyorBeltNormal.Text = "Conveyor belt, normal";
            this.checkConveyorBeltNormal.UseVisualStyleBackColor = false;
            this.checkConveyorBeltNormal.CheckedChanged += new System.EventHandler(this.checkControl_CheckedChanged);
            // 
            // checkConveyorBeltFast
            // 
            this.checkConveyorBeltFast.BackColor = System.Drawing.SystemColors.Control;
            this.checkConveyorBeltFast.Location = new System.Drawing.Point(1, 37);
            this.checkConveyorBeltFast.Name = "checkConveyorBeltFast";
            this.checkConveyorBeltFast.Size = new System.Drawing.Size(152, 17);
            this.checkConveyorBeltFast.TabIndex = 389;
            this.checkConveyorBeltFast.Text = "Conveyor belt, fast";
            this.checkConveyorBeltFast.UseVisualStyleBackColor = false;
            this.checkConveyorBeltFast.CheckedChanged += new System.EventHandler(this.checkControl_CheckedChanged);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.Window;
            this.panel4.Controls.Add(this.conveyorBeltNormal);
            this.panel4.Location = new System.Drawing.Point(154, 55);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(51, 17);
            this.panel4.TabIndex = 371;
            // 
            // conveyorBeltNormal
            // 
            this.conveyorBeltNormal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.conveyorBeltNormal.Enabled = false;
            this.conveyorBeltNormal.Items.AddRange(new object[] {
            "false",
            "true"});
            this.conveyorBeltNormal.Location = new System.Drawing.Point(-2, -2);
            this.conveyorBeltNormal.Name = "conveyorBeltNormal";
            this.conveyorBeltNormal.Size = new System.Drawing.Size(55, 21);
            this.conveyorBeltNormal.TabIndex = 370;
            // 
            // panel19
            // 
            this.panel19.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel19.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel19.Controls.Add(this.label3);
            this.panel19.Controls.Add(this.checkP3OnEdge);
            this.panel19.Controls.Add(this.panel20);
            this.panel19.Controls.Add(this.checkP3OnTile);
            this.panel19.Controls.Add(this.panel21);
            this.panel19.Controls.Add(this.checkP3OverEdge);
            this.panel19.Controls.Add(this.panel22);
            this.panel19.Location = new System.Drawing.Point(3, 367);
            this.panel19.Name = "panel19";
            this.panel19.Size = new System.Drawing.Size(209, 76);
            this.panel19.TabIndex = 395;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(2, 2, 0, 0);
            this.label3.Size = new System.Drawing.Size(205, 17);
            this.label3.TabIndex = 393;
            this.label3.Text = "PRIORITY";
            // 
            // checkP3OnEdge
            // 
            this.checkP3OnEdge.BackColor = System.Drawing.SystemColors.Control;
            this.checkP3OnEdge.Location = new System.Drawing.Point(1, 19);
            this.checkP3OnEdge.Name = "checkP3OnEdge";
            this.checkP3OnEdge.Size = new System.Drawing.Size(152, 17);
            this.checkP3OnEdge.TabIndex = 389;
            this.checkP3OnEdge.Text = "P3 for object on edge";
            this.checkP3OnEdge.UseVisualStyleBackColor = false;
            this.checkP3OnEdge.CheckedChanged += new System.EventHandler(this.checkControl_CheckedChanged);
            // 
            // panel20
            // 
            this.panel20.BackColor = System.Drawing.SystemColors.Window;
            this.panel20.Controls.Add(this.p3OverEdge);
            this.panel20.Location = new System.Drawing.Point(154, 37);
            this.panel20.Name = "panel20";
            this.panel20.Size = new System.Drawing.Size(51, 17);
            this.panel20.TabIndex = 371;
            // 
            // p3OverEdge
            // 
            this.p3OverEdge.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.p3OverEdge.Enabled = false;
            this.p3OverEdge.Items.AddRange(new object[] {
            "false",
            "true"});
            this.p3OverEdge.Location = new System.Drawing.Point(-2, -2);
            this.p3OverEdge.Name = "p3OverEdge";
            this.p3OverEdge.Size = new System.Drawing.Size(55, 21);
            this.p3OverEdge.TabIndex = 370;
            // 
            // checkP3OnTile
            // 
            this.checkP3OnTile.BackColor = System.Drawing.SystemColors.Control;
            this.checkP3OnTile.Location = new System.Drawing.Point(1, 55);
            this.checkP3OnTile.Name = "checkP3OnTile";
            this.checkP3OnTile.Size = new System.Drawing.Size(152, 17);
            this.checkP3OnTile.TabIndex = 389;
            this.checkP3OnTile.Text = "P3 for object on tile";
            this.checkP3OnTile.UseVisualStyleBackColor = false;
            this.checkP3OnTile.CheckedChanged += new System.EventHandler(this.checkControl_CheckedChanged);
            // 
            // panel21
            // 
            this.panel21.BackColor = System.Drawing.SystemColors.Window;
            this.panel21.Controls.Add(this.p3OnEdge);
            this.panel21.Location = new System.Drawing.Point(154, 19);
            this.panel21.Name = "panel21";
            this.panel21.Size = new System.Drawing.Size(51, 17);
            this.panel21.TabIndex = 371;
            // 
            // p3OnEdge
            // 
            this.p3OnEdge.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.p3OnEdge.Enabled = false;
            this.p3OnEdge.Items.AddRange(new object[] {
            "false",
            "true"});
            this.p3OnEdge.Location = new System.Drawing.Point(-2, -2);
            this.p3OnEdge.Name = "p3OnEdge";
            this.p3OnEdge.Size = new System.Drawing.Size(55, 21);
            this.p3OnEdge.TabIndex = 370;
            // 
            // checkP3OverEdge
            // 
            this.checkP3OverEdge.BackColor = System.Drawing.SystemColors.Control;
            this.checkP3OverEdge.Location = new System.Drawing.Point(1, 37);
            this.checkP3OverEdge.Name = "checkP3OverEdge";
            this.checkP3OverEdge.Size = new System.Drawing.Size(152, 17);
            this.checkP3OverEdge.TabIndex = 389;
            this.checkP3OverEdge.Text = "P3 for object over edge";
            this.checkP3OverEdge.UseVisualStyleBackColor = false;
            this.checkP3OverEdge.CheckedChanged += new System.EventHandler(this.checkControl_CheckedChanged);
            // 
            // panel22
            // 
            this.panel22.BackColor = System.Drawing.SystemColors.Window;
            this.panel22.Controls.Add(this.p3OnTile);
            this.panel22.Location = new System.Drawing.Point(154, 55);
            this.panel22.Name = "panel22";
            this.panel22.Size = new System.Drawing.Size(51, 17);
            this.panel22.TabIndex = 371;
            // 
            // p3OnTile
            // 
            this.p3OnTile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.p3OnTile.Enabled = false;
            this.p3OnTile.Items.AddRange(new object[] {
            "false",
            "true"});
            this.p3OnTile.Location = new System.Drawing.Point(-2, -2);
            this.p3OnTile.Name = "p3OnTile";
            this.p3OnTile.Size = new System.Drawing.Size(55, 21);
            this.p3OnTile.TabIndex = 370;
            // 
            // panel13
            // 
            this.panel13.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel13.Controls.Add(this.checkSolidQuadrantN);
            this.panel13.Controls.Add(this.label2);
            this.panel13.Controls.Add(this.checkSolidQuadrant);
            this.panel13.Controls.Add(this.checkSolidTile);
            this.panel13.Controls.Add(this.panel14);
            this.panel13.Controls.Add(this.panel15);
            this.panel13.Controls.Add(this.checkSolidQuadrantW);
            this.panel13.Controls.Add(this.panel18);
            this.panel13.Controls.Add(this.panel16);
            this.panel13.Controls.Add(this.panel6);
            this.panel13.Controls.Add(this.panel17);
            this.panel13.Controls.Add(this.checkSolidQuadrantS);
            this.panel13.Controls.Add(this.checkSolidQuadrantE);
            this.panel13.Location = new System.Drawing.Point(3, 139);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(209, 130);
            this.panel13.TabIndex = 395;
            // 
            // checkSolidQuadrantN
            // 
            this.checkSolidQuadrantN.BackColor = System.Drawing.SystemColors.Control;
            this.checkSolidQuadrantN.Location = new System.Drawing.Point(1, 55);
            this.checkSolidQuadrantN.Name = "checkSolidQuadrantN";
            this.checkSolidQuadrantN.Size = new System.Drawing.Size(152, 17);
            this.checkSolidQuadrantN.TabIndex = 389;
            this.checkSolidQuadrantN.Text = "N quadrant solid";
            this.checkSolidQuadrantN.UseVisualStyleBackColor = false;
            this.checkSolidQuadrantN.CheckedChanged += new System.EventHandler(this.checkControl_CheckedChanged);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(2, 2, 0, 0);
            this.label2.Size = new System.Drawing.Size(205, 17);
            this.label2.TabIndex = 393;
            this.label2.Text = "SOLID QUADRANTS";
            // 
            // checkSolidQuadrant
            // 
            this.checkSolidQuadrant.BackColor = System.Drawing.SystemColors.Control;
            this.checkSolidQuadrant.Location = new System.Drawing.Point(1, 37);
            this.checkSolidQuadrant.Name = "checkSolidQuadrant";
            this.checkSolidQuadrant.Size = new System.Drawing.Size(152, 17);
            this.checkSolidQuadrant.TabIndex = 389;
            this.checkSolidQuadrant.Text = "Solid quadrant flag";
            this.checkSolidQuadrant.UseVisualStyleBackColor = false;
            this.checkSolidQuadrant.CheckedChanged += new System.EventHandler(this.checkControl_CheckedChanged);
            // 
            // checkSolidTile
            // 
            this.checkSolidTile.BackColor = System.Drawing.SystemColors.Control;
            this.checkSolidTile.Location = new System.Drawing.Point(1, 19);
            this.checkSolidTile.Name = "checkSolidTile";
            this.checkSolidTile.Size = new System.Drawing.Size(152, 17);
            this.checkSolidTile.TabIndex = 389;
            this.checkSolidTile.Text = "Solid tile";
            this.checkSolidTile.UseVisualStyleBackColor = false;
            this.checkSolidTile.CheckedChanged += new System.EventHandler(this.checkControl_CheckedChanged);
            // 
            // panel14
            // 
            this.panel14.BackColor = System.Drawing.SystemColors.Window;
            this.panel14.Controls.Add(this.solidQuadrantE);
            this.panel14.Location = new System.Drawing.Point(154, 91);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(51, 17);
            this.panel14.TabIndex = 371;
            // 
            // solidQuadrantE
            // 
            this.solidQuadrantE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.solidQuadrantE.Enabled = false;
            this.solidQuadrantE.Items.AddRange(new object[] {
            "false",
            "true"});
            this.solidQuadrantE.Location = new System.Drawing.Point(-2, -2);
            this.solidQuadrantE.Name = "solidQuadrantE";
            this.solidQuadrantE.Size = new System.Drawing.Size(55, 21);
            this.solidQuadrantE.TabIndex = 370;
            // 
            // panel15
            // 
            this.panel15.BackColor = System.Drawing.SystemColors.Window;
            this.panel15.Controls.Add(this.solidQuadrantW);
            this.panel15.Location = new System.Drawing.Point(154, 73);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(51, 17);
            this.panel15.TabIndex = 371;
            // 
            // solidQuadrantW
            // 
            this.solidQuadrantW.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.solidQuadrantW.Enabled = false;
            this.solidQuadrantW.Items.AddRange(new object[] {
            "false",
            "true"});
            this.solidQuadrantW.Location = new System.Drawing.Point(-2, -2);
            this.solidQuadrantW.Name = "solidQuadrantW";
            this.solidQuadrantW.Size = new System.Drawing.Size(55, 21);
            this.solidQuadrantW.TabIndex = 370;
            // 
            // checkSolidQuadrantW
            // 
            this.checkSolidQuadrantW.BackColor = System.Drawing.SystemColors.Control;
            this.checkSolidQuadrantW.Location = new System.Drawing.Point(1, 73);
            this.checkSolidQuadrantW.Name = "checkSolidQuadrantW";
            this.checkSolidQuadrantW.Size = new System.Drawing.Size(152, 17);
            this.checkSolidQuadrantW.TabIndex = 389;
            this.checkSolidQuadrantW.Text = "W quadrant solid";
            this.checkSolidQuadrantW.UseVisualStyleBackColor = false;
            this.checkSolidQuadrantW.CheckedChanged += new System.EventHandler(this.checkControl_CheckedChanged);
            // 
            // panel18
            // 
            this.panel18.BackColor = System.Drawing.SystemColors.Window;
            this.panel18.Controls.Add(this.solidQuadrant);
            this.panel18.Location = new System.Drawing.Point(154, 37);
            this.panel18.Name = "panel18";
            this.panel18.Size = new System.Drawing.Size(51, 17);
            this.panel18.TabIndex = 371;
            // 
            // solidQuadrant
            // 
            this.solidQuadrant.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.solidQuadrant.Enabled = false;
            this.solidQuadrant.Items.AddRange(new object[] {
            "false",
            "true"});
            this.solidQuadrant.Location = new System.Drawing.Point(-2, -2);
            this.solidQuadrant.Name = "solidQuadrant";
            this.solidQuadrant.Size = new System.Drawing.Size(55, 21);
            this.solidQuadrant.TabIndex = 370;
            // 
            // panel16
            // 
            this.panel16.BackColor = System.Drawing.SystemColors.Window;
            this.panel16.Controls.Add(this.solidQuadrantS);
            this.panel16.Location = new System.Drawing.Point(154, 109);
            this.panel16.Name = "panel16";
            this.panel16.Size = new System.Drawing.Size(51, 17);
            this.panel16.TabIndex = 371;
            // 
            // solidQuadrantS
            // 
            this.solidQuadrantS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.solidQuadrantS.Enabled = false;
            this.solidQuadrantS.Items.AddRange(new object[] {
            "false",
            "true"});
            this.solidQuadrantS.Location = new System.Drawing.Point(-2, -2);
            this.solidQuadrantS.Name = "solidQuadrantS";
            this.solidQuadrantS.Size = new System.Drawing.Size(55, 21);
            this.solidQuadrantS.TabIndex = 370;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.SystemColors.Window;
            this.panel6.Controls.Add(this.solidTile);
            this.panel6.Location = new System.Drawing.Point(154, 19);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(51, 17);
            this.panel6.TabIndex = 371;
            // 
            // solidTile
            // 
            this.solidTile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.solidTile.Enabled = false;
            this.solidTile.Items.AddRange(new object[] {
            "false",
            "true"});
            this.solidTile.Location = new System.Drawing.Point(-2, -2);
            this.solidTile.Name = "solidTile";
            this.solidTile.Size = new System.Drawing.Size(55, 21);
            this.solidTile.TabIndex = 370;
            // 
            // panel17
            // 
            this.panel17.BackColor = System.Drawing.SystemColors.Window;
            this.panel17.Controls.Add(this.solidQuadrantN);
            this.panel17.Location = new System.Drawing.Point(154, 55);
            this.panel17.Name = "panel17";
            this.panel17.Size = new System.Drawing.Size(51, 17);
            this.panel17.TabIndex = 371;
            // 
            // solidQuadrantN
            // 
            this.solidQuadrantN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.solidQuadrantN.Enabled = false;
            this.solidQuadrantN.Items.AddRange(new object[] {
            "false",
            "true"});
            this.solidQuadrantN.Location = new System.Drawing.Point(-2, -2);
            this.solidQuadrantN.Name = "solidQuadrantN";
            this.solidQuadrantN.Size = new System.Drawing.Size(55, 21);
            this.solidQuadrantN.TabIndex = 370;
            // 
            // checkSolidQuadrantS
            // 
            this.checkSolidQuadrantS.BackColor = System.Drawing.SystemColors.Control;
            this.checkSolidQuadrantS.Location = new System.Drawing.Point(1, 109);
            this.checkSolidQuadrantS.Name = "checkSolidQuadrantS";
            this.checkSolidQuadrantS.Size = new System.Drawing.Size(152, 17);
            this.checkSolidQuadrantS.TabIndex = 389;
            this.checkSolidQuadrantS.Text = "S quadrant solid";
            this.checkSolidQuadrantS.UseVisualStyleBackColor = false;
            this.checkSolidQuadrantS.CheckedChanged += new System.EventHandler(this.checkControl_CheckedChanged);
            // 
            // checkSolidQuadrantE
            // 
            this.checkSolidQuadrantE.BackColor = System.Drawing.SystemColors.Control;
            this.checkSolidQuadrantE.Location = new System.Drawing.Point(1, 91);
            this.checkSolidQuadrantE.Name = "checkSolidQuadrantE";
            this.checkSolidQuadrantE.Size = new System.Drawing.Size(152, 17);
            this.checkSolidQuadrantE.TabIndex = 389;
            this.checkSolidQuadrantE.Text = "E quadrant solid";
            this.checkSolidQuadrantE.UseVisualStyleBackColor = false;
            this.checkSolidQuadrantE.CheckedChanged += new System.EventHandler(this.checkControl_CheckedChanged);
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel11.Controls.Add(this.checkSolidEdgeNW);
            this.panel11.Controls.Add(this.label12);
            this.panel11.Controls.Add(this.panel7);
            this.panel11.Controls.Add(this.panel8);
            this.panel11.Controls.Add(this.checkSolidEdgeNE);
            this.panel11.Controls.Add(this.panel9);
            this.panel11.Controls.Add(this.panel10);
            this.panel11.Controls.Add(this.checkSolidEdgeSE);
            this.panel11.Controls.Add(this.checkSolidEdgeSW);
            this.panel11.Location = new System.Drawing.Point(3, 271);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(209, 94);
            this.panel11.TabIndex = 394;
            // 
            // checkSolidEdgeNW
            // 
            this.checkSolidEdgeNW.BackColor = System.Drawing.SystemColors.Control;
            this.checkSolidEdgeNW.Location = new System.Drawing.Point(1, 19);
            this.checkSolidEdgeNW.Name = "checkSolidEdgeNW";
            this.checkSolidEdgeNW.Size = new System.Drawing.Size(152, 17);
            this.checkSolidEdgeNW.TabIndex = 389;
            this.checkSolidEdgeNW.Text = "NW edge solid";
            this.checkSolidEdgeNW.UseVisualStyleBackColor = false;
            this.checkSolidEdgeNW.CheckedChanged += new System.EventHandler(this.checkControl_CheckedChanged);
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.SystemColors.Control;
            this.label12.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label12.Location = new System.Drawing.Point(0, 0);
            this.label12.Name = "label12";
            this.label12.Padding = new System.Windows.Forms.Padding(2, 2, 0, 0);
            this.label12.Size = new System.Drawing.Size(205, 17);
            this.label12.TabIndex = 393;
            this.label12.Text = "SOLID EDGES";
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.SystemColors.Window;
            this.panel7.Controls.Add(this.solidEdgeSW);
            this.panel7.Location = new System.Drawing.Point(154, 55);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(51, 17);
            this.panel7.TabIndex = 371;
            // 
            // solidEdgeSW
            // 
            this.solidEdgeSW.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.solidEdgeSW.Enabled = false;
            this.solidEdgeSW.Items.AddRange(new object[] {
            "false",
            "true"});
            this.solidEdgeSW.Location = new System.Drawing.Point(-2, -2);
            this.solidEdgeSW.Name = "solidEdgeSW";
            this.solidEdgeSW.Size = new System.Drawing.Size(55, 21);
            this.solidEdgeSW.TabIndex = 370;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.SystemColors.Window;
            this.panel8.Controls.Add(this.solidEdgeNE);
            this.panel8.Location = new System.Drawing.Point(154, 37);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(51, 17);
            this.panel8.TabIndex = 371;
            // 
            // solidEdgeNE
            // 
            this.solidEdgeNE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.solidEdgeNE.Enabled = false;
            this.solidEdgeNE.Items.AddRange(new object[] {
            "false",
            "true"});
            this.solidEdgeNE.Location = new System.Drawing.Point(-2, -2);
            this.solidEdgeNE.Name = "solidEdgeNE";
            this.solidEdgeNE.Size = new System.Drawing.Size(55, 21);
            this.solidEdgeNE.TabIndex = 370;
            // 
            // checkSolidEdgeNE
            // 
            this.checkSolidEdgeNE.BackColor = System.Drawing.SystemColors.Control;
            this.checkSolidEdgeNE.Location = new System.Drawing.Point(1, 37);
            this.checkSolidEdgeNE.Name = "checkSolidEdgeNE";
            this.checkSolidEdgeNE.Size = new System.Drawing.Size(152, 17);
            this.checkSolidEdgeNE.TabIndex = 389;
            this.checkSolidEdgeNE.Text = "NE edge solid";
            this.checkSolidEdgeNE.UseVisualStyleBackColor = false;
            this.checkSolidEdgeNE.CheckedChanged += new System.EventHandler(this.checkControl_CheckedChanged);
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.SystemColors.Window;
            this.panel9.Controls.Add(this.solidEdgeSE);
            this.panel9.Location = new System.Drawing.Point(154, 73);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(51, 17);
            this.panel9.TabIndex = 371;
            // 
            // solidEdgeSE
            // 
            this.solidEdgeSE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.solidEdgeSE.Enabled = false;
            this.solidEdgeSE.Items.AddRange(new object[] {
            "false",
            "true"});
            this.solidEdgeSE.Location = new System.Drawing.Point(-2, -2);
            this.solidEdgeSE.Name = "solidEdgeSE";
            this.solidEdgeSE.Size = new System.Drawing.Size(55, 21);
            this.solidEdgeSE.TabIndex = 370;
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.SystemColors.Window;
            this.panel10.Controls.Add(this.solidEdgeNW);
            this.panel10.Location = new System.Drawing.Point(154, 19);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(51, 17);
            this.panel10.TabIndex = 371;
            // 
            // solidEdgeNW
            // 
            this.solidEdgeNW.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.solidEdgeNW.Enabled = false;
            this.solidEdgeNW.Items.AddRange(new object[] {
            "false",
            "true"});
            this.solidEdgeNW.Location = new System.Drawing.Point(-2, -2);
            this.solidEdgeNW.Name = "solidEdgeNW";
            this.solidEdgeNW.Size = new System.Drawing.Size(55, 21);
            this.solidEdgeNW.TabIndex = 370;
            // 
            // checkSolidEdgeSE
            // 
            this.checkSolidEdgeSE.BackColor = System.Drawing.SystemColors.Control;
            this.checkSolidEdgeSE.Location = new System.Drawing.Point(1, 73);
            this.checkSolidEdgeSE.Name = "checkSolidEdgeSE";
            this.checkSolidEdgeSE.Size = new System.Drawing.Size(152, 17);
            this.checkSolidEdgeSE.TabIndex = 389;
            this.checkSolidEdgeSE.Text = "SE edge solid";
            this.checkSolidEdgeSE.UseVisualStyleBackColor = false;
            this.checkSolidEdgeSE.CheckedChanged += new System.EventHandler(this.checkControl_CheckedChanged);
            // 
            // checkSolidEdgeSW
            // 
            this.checkSolidEdgeSW.BackColor = System.Drawing.SystemColors.Control;
            this.checkSolidEdgeSW.Location = new System.Drawing.Point(1, 55);
            this.checkSolidEdgeSW.Name = "checkSolidEdgeSW";
            this.checkSolidEdgeSW.Size = new System.Drawing.Size(152, 17);
            this.checkSolidEdgeSW.TabIndex = 389;
            this.checkSolidEdgeSW.Text = "SW edge solid";
            this.checkSolidEdgeSW.UseVisualStyleBackColor = false;
            this.checkSolidEdgeSW.CheckedChanged += new System.EventHandler(this.checkControl_CheckedChanged);
            // 
            // selectAll
            // 
            this.selectAll.Location = new System.Drawing.Point(3, 0);
            this.selectAll.Name = "selectAll";
            this.selectAll.Size = new System.Drawing.Size(104, 23);
            this.selectAll.TabIndex = 398;
            this.selectAll.Text = "Select All";
            this.selectAll.UseVisualStyleBackColor = true;
            this.selectAll.Click += new System.EventHandler(this.selectAll_Click);
            // 
            // deselectAll
            // 
            this.deselectAll.Location = new System.Drawing.Point(108, 0);
            this.deselectAll.Name = "deselectAll";
            this.deselectAll.Size = new System.Drawing.Size(104, 23);
            this.deselectAll.TabIndex = 398;
            this.deselectAll.Text = "Deselect All";
            this.deselectAll.UseVisualStyleBackColor = true;
            this.deselectAll.Click += new System.EventHandler(this.deselectAll_Click);
            // 
            // SearchSolidTile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlText;
            this.ClientSize = new System.Drawing.Size(443, 658);
            this.Controls.Add(this.searchResults);
            this.Controls.Add(this.withProperties);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SearchSolidTile";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "SEARCH FOR SOLID TILES...";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SearchPhysicalTile_FormClosing);
            this.panel55.ResumeLayout(false);
            this.panel54.ResumeLayout(false);
            this.panel44.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel27.ResumeLayout(false);
            this.panel23.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.heightOfBaseTile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zCoordOverhead)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.heightOverhead)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zCoordWater)).EndInit();
            this.panel24.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel12.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel19.ResumeLayout(false);
            this.panel20.ResumeLayout(false);
            this.panel21.ResumeLayout(false);
            this.panel22.ResumeLayout(false);
            this.panel13.ResumeLayout(false);
            this.panel14.ResumeLayout(false);
            this.panel15.ResumeLayout(false);
            this.panel18.ResumeLayout(false);
            this.panel16.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel17.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.ResumeLayout(false);

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
        private ComboBox solidEdgeNE;
        private ComboBox solidEdgeNW;
        private ComboBox solidEdgeSE;
        private ComboBox solidEdgeSW;
        private ComboBox solidQuadrant;
        private ComboBox solidQuadrantE;
        private ComboBox solidQuadrantN;
        private ComboBox solidQuadrantS;
        private ComboBox solidQuadrantW;
        private ComboBox solidTile;
        private ComboBox specialTile;
        private ComboBox stairs;
        private ComboBox zCoordPlusHalf;
        private Label label1;
        private Label label12;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private ListBox searchResults;
        private NumericUpDown heightOfBaseTile;
        private NumericUpDown heightOverhead;
        private NumericUpDown zCoordOverhead;
        private NumericUpDown zCoordWater;
        private Panel panel1;
        private Panel panel10;
        private Panel panel11;
        private Panel panel12;
        private Panel panel13;
        private Panel panel14;
        private Panel panel15;
        private Panel panel16;
        private Panel panel17;
        private Panel panel18;
        private Panel panel19;
        private Panel panel2;
        private Panel panel20;
        private Panel panel21;
        private Panel panel22;
        private Panel panel23;
        private Panel panel24;
        private Panel panel27;
        private Panel panel3;
        private Panel panel4;
        private Panel panel44;
        private Panel panel5;
        private Panel panel54;
        private Panel panel55;
        private Panel panel6;
        private Panel panel7;
        private Panel panel8;
        private Panel panel9;
        private RichTextBox withProperties;
        private Button searchButton;
        private Button deselectAll;
        private Button selectAll;
    }
}