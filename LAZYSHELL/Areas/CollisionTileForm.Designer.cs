
namespace LAZYSHELL.Areas
{
    partial class CollisionTileForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CollisionTileForm));
            this.panelPhysicalTile = new System.Windows.Forms.Panel();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.collisionTileNum = new LAZYSHELL.Controls.NewToolStripNumericUpDown();
            this.reset = new System.Windows.Forms.ToolStripButton();
            this.search = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.unknownBits = new System.Windows.Forms.CheckedListBox();
            this.doorFormat = new System.Windows.Forms.ComboBox();
            this.conveyorBeltNormal = new System.Windows.Forms.CheckBox();
            this.p3OnTile = new System.Windows.Forms.CheckBox();
            this.specialTile = new System.Windows.Forms.ComboBox();
            this.conveyorBeltFast = new System.Windows.Forms.CheckBox();
            this.stairs = new System.Windows.Forms.ComboBox();
            this.checkStairs = new System.Windows.Forms.Label();
            this.solidEdgeNE = new System.Windows.Forms.CheckBox();
            this.checkSpecialTile = new System.Windows.Forms.Label();
            this.conveyor = new System.Windows.Forms.ComboBox();
            this.checkDoorFormat = new System.Windows.Forms.Label();
            this.checkConveyor = new System.Windows.Forms.Label();
            this.p3OverEdge = new System.Windows.Forms.CheckBox();
            this.headerLabel5 = new LAZYSHELL.Controls.HeaderLabel();
            this.headerLabel4 = new LAZYSHELL.Controls.HeaderLabel();
            this.headerLabel3 = new LAZYSHELL.Controls.HeaderLabel();
            this.p3OnEdge = new System.Windows.Forms.CheckBox();
            this.headerLabel2 = new LAZYSHELL.Controls.HeaderLabel();
            this.solidQuadrantS = new System.Windows.Forms.CheckBox();
            this.headerLabel1 = new LAZYSHELL.Controls.HeaderLabel();
            this.solidEdgeSW = new System.Windows.Forms.CheckBox();
            this.heightOfBaseTile = new System.Windows.Forms.NumericUpDown();
            this.solidEdgeSE = new System.Windows.Forms.CheckBox();
            this.solidQuadrant = new System.Windows.Forms.CheckBox();
            this.zCoordOverhead = new System.Windows.Forms.NumericUpDown();
            this.solidTile = new System.Windows.Forms.CheckBox();
            this.solidEdgeNW = new System.Windows.Forms.CheckBox();
            this.solidQuadrantE = new System.Windows.Forms.CheckBox();
            this.checkHeightOfBaseTile = new System.Windows.Forms.Label();
            this.solidQuadrantW = new System.Windows.Forms.CheckBox();
            this.heightOverhead = new System.Windows.Forms.NumericUpDown();
            this.solidQuadrantN = new System.Windows.Forms.CheckBox();
            this.zCoordPlusHalf = new System.Windows.Forms.CheckBox();
            this.zCoordWater = new System.Windows.Forms.NumericUpDown();
            this.checkZCoordWater = new System.Windows.Forms.Label();
            this.checkZCoordOverhead = new System.Windows.Forms.Label();
            this.checkHeightOverhead = new System.Windows.Forms.Label();
            this.panelPhysicalTile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.heightOfBaseTile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zCoordOverhead)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.heightOverhead)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zCoordWater)).BeginInit();
            this.SuspendLayout();
            // 
            // panelPhysicalTile
            // 
            this.panelPhysicalTile.Controls.Add(this.pictureBox);
            this.panelPhysicalTile.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelPhysicalTile.Location = new System.Drawing.Point(224, 25);
            this.panelPhysicalTile.Name = "panelPhysicalTile";
            this.panelPhysicalTile.Size = new System.Drawing.Size(36, 516);
            this.panelPhysicalTile.TabIndex = 2;
            // 
            // pictureBox
            // 
            this.pictureBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pictureBox.BackgroundImage = global::LAZYSHELL.Properties.Resources._transparent;
            this.pictureBox.Location = new System.Drawing.Point(2, -268);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(32, 784);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            this.pictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox_Paint);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.collisionTileNum,
            this.reset,
            this.search});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(260, 25);
            this.toolStrip1.TabIndex = 0;
            // 
            // collisionTileNum
            // 
            this.collisionTileNum.AutoSize = false;
            this.collisionTileNum.ContextMenuStrip = null;
            this.collisionTileNum.Hexadecimal = false;
            this.collisionTileNum.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.collisionTileNum.Location = new System.Drawing.Point(9, 1);
            this.collisionTileNum.Maximum = new decimal(new int[] {
            1023,
            0,
            0,
            0});
            this.collisionTileNum.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.collisionTileNum.Name = "physicalTileNum";
            this.collisionTileNum.Size = new System.Drawing.Size(60, 21);
            this.collisionTileNum.Text = "0";
            this.collisionTileNum.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.collisionTileNum.ValueChanged += new System.EventHandler(this.collisionTileNum_ValueChanged);
            // 
            // reset
            // 
            this.reset.Image = global::LAZYSHELL.Properties.Resources.reset;
            this.reset.Name = "reset";
            this.reset.Size = new System.Drawing.Size(23, 22);
            this.reset.ToolTipText = "Reset";
            this.reset.Click += new System.EventHandler(this.reset_Click);
            // 
            // search
            // 
            this.search.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.search.Image = global::LAZYSHELL.Properties.Resources.search;
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(23, 22);
            this.search.ToolTipText = "Search For Collision Tiles";
            this.search.Click += new System.EventHandler(this.search_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.unknownBits);
            this.panel1.Controls.Add(this.doorFormat);
            this.panel1.Controls.Add(this.conveyorBeltNormal);
            this.panel1.Controls.Add(this.p3OnTile);
            this.panel1.Controls.Add(this.specialTile);
            this.panel1.Controls.Add(this.conveyorBeltFast);
            this.panel1.Controls.Add(this.stairs);
            this.panel1.Controls.Add(this.checkStairs);
            this.panel1.Controls.Add(this.solidEdgeNE);
            this.panel1.Controls.Add(this.checkSpecialTile);
            this.panel1.Controls.Add(this.conveyor);
            this.panel1.Controls.Add(this.checkDoorFormat);
            this.panel1.Controls.Add(this.checkConveyor);
            this.panel1.Controls.Add(this.p3OverEdge);
            this.panel1.Controls.Add(this.headerLabel5);
            this.panel1.Controls.Add(this.headerLabel4);
            this.panel1.Controls.Add(this.headerLabel3);
            this.panel1.Controls.Add(this.p3OnEdge);
            this.panel1.Controls.Add(this.headerLabel2);
            this.panel1.Controls.Add(this.solidQuadrantS);
            this.panel1.Controls.Add(this.headerLabel1);
            this.panel1.Controls.Add(this.solidEdgeSW);
            this.panel1.Controls.Add(this.heightOfBaseTile);
            this.panel1.Controls.Add(this.solidEdgeSE);
            this.panel1.Controls.Add(this.solidQuadrant);
            this.panel1.Controls.Add(this.zCoordOverhead);
            this.panel1.Controls.Add(this.solidTile);
            this.panel1.Controls.Add(this.solidEdgeNW);
            this.panel1.Controls.Add(this.solidQuadrantE);
            this.panel1.Controls.Add(this.checkHeightOfBaseTile);
            this.panel1.Controls.Add(this.solidQuadrantW);
            this.panel1.Controls.Add(this.heightOverhead);
            this.panel1.Controls.Add(this.solidQuadrantN);
            this.panel1.Controls.Add(this.zCoordPlusHalf);
            this.panel1.Controls.Add(this.zCoordWater);
            this.panel1.Controls.Add(this.checkZCoordWater);
            this.panel1.Controls.Add(this.checkZCoordOverhead);
            this.panel1.Controls.Add(this.checkHeightOverhead);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(226, 516);
            this.panel1.TabIndex = 1;
            // 
            // unknownBits
            // 
            this.unknownBits.CheckOnClick = true;
            this.unknownBits.ColumnWidth = 100;
            this.unknownBits.Items.AddRange(new object[] {
            "{B5,b0}",
            "{B5,b1}",
            "{B5,b2}",
            "{B5,b3}",
            "{B5,b4}"});
            this.unknownBits.Location = new System.Drawing.Point(3, 446);
            this.unknownBits.MultiColumn = true;
            this.unknownBits.Name = "unknownBits";
            this.unknownBits.Size = new System.Drawing.Size(217, 64);
            this.unknownBits.TabIndex = 6;
            this.unknownBits.SelectedIndexChanged += new System.EventHandler(this.unknownBits_SelectedIndexChanged);
            // 
            // doorFormat
            // 
            this.doorFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.doorFormat.Items.AddRange(new object[] {
            "{none}",
            "{unknown}",
            "{unknown}",
            "{unknown}",
            "{unknown}",
            "NE,SW",
            "{unknown}",
            "NW,SE"});
            this.doorFormat.Location = new System.Drawing.Point(130, 419);
            this.doorFormat.Name = "doorFormat";
            this.doorFormat.Size = new System.Drawing.Size(90, 21);
            this.doorFormat.TabIndex = 5;
            this.doorFormat.SelectedIndexChanged += new System.EventHandler(this.doorFormat_SelectedIndexChanged);
            // 
            // conveyorBeltNormal
            // 
            this.conveyorBeltNormal.AutoSize = true;
            this.conveyorBeltNormal.Location = new System.Drawing.Point(3, 339);
            this.conveyorBeltNormal.Name = "conveyorBeltNormal";
            this.conveyorBeltNormal.Size = new System.Drawing.Size(133, 17);
            this.conveyorBeltNormal.TabIndex = 12;
            this.conveyorBeltNormal.Text = "Conveyor belt, normal";
            this.conveyorBeltNormal.UseVisualStyleBackColor = true;
            this.conveyorBeltNormal.CheckedChanged += new System.EventHandler(this.conveyorBeltNormal_CheckedChanged);
            // 
            // p3OnTile
            // 
            this.p3OnTile.AutoSize = true;
            this.p3OnTile.Location = new System.Drawing.Point(3, 258);
            this.p3OnTile.Name = "p3OnTile";
            this.p3OnTile.Size = new System.Drawing.Size(151, 17);
            this.p3OnTile.TabIndex = 12;
            this.p3OnTile.Text = "Priority 3 for object on tile";
            this.p3OnTile.UseVisualStyleBackColor = true;
            this.p3OnTile.CheckedChanged += new System.EventHandler(this.p3OnTile_CheckedChanged);
            // 
            // specialTile
            // 
            this.specialTile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.specialTile.Items.AddRange(new object[] {
            "{none}",
            "vines",
            "water"});
            this.specialTile.Location = new System.Drawing.Point(130, 398);
            this.specialTile.Name = "specialTile";
            this.specialTile.Size = new System.Drawing.Size(90, 21);
            this.specialTile.TabIndex = 3;
            this.specialTile.SelectedIndexChanged += new System.EventHandler(this.specialTile_SelectedIndexChanged);
            // 
            // conveyorBeltFast
            // 
            this.conveyorBeltFast.AutoSize = true;
            this.conveyorBeltFast.Location = new System.Drawing.Point(3, 320);
            this.conveyorBeltFast.Name = "conveyorBeltFast";
            this.conveyorBeltFast.Size = new System.Drawing.Size(120, 17);
            this.conveyorBeltFast.TabIndex = 12;
            this.conveyorBeltFast.Text = "Conveyor belt, fast";
            this.conveyorBeltFast.UseVisualStyleBackColor = true;
            this.conveyorBeltFast.CheckedChanged += new System.EventHandler(this.conveyorBeltFast_CheckedChanged);
            // 
            // stairs
            // 
            this.stairs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.stairs.Items.AddRange(new object[] {
            "{none}",
            "NW,SE",
            "NE,SW"});
            this.stairs.Location = new System.Drawing.Point(130, 377);
            this.stairs.Name = "stairs";
            this.stairs.Size = new System.Drawing.Size(90, 21);
            this.stairs.TabIndex = 1;
            this.stairs.SelectedIndexChanged += new System.EventHandler(this.stairs_SelectedIndexChanged);
            // 
            // checkStairs
            // 
            this.checkStairs.AutoSize = true;
            this.checkStairs.Location = new System.Drawing.Point(3, 380);
            this.checkStairs.Name = "checkStairs";
            this.checkStairs.Size = new System.Drawing.Size(57, 13);
            this.checkStairs.TabIndex = 0;
            this.checkStairs.Text = "Stairs lead";
            // 
            // solidEdgeNE
            // 
            this.solidEdgeNE.Appearance = System.Windows.Forms.Appearance.Button;
            this.solidEdgeNE.Location = new System.Drawing.Point(67, 140);
            this.solidEdgeNE.Name = "solidEdgeNE";
            this.solidEdgeNE.Size = new System.Drawing.Size(32, 20);
            this.solidEdgeNE.TabIndex = 0;
            this.solidEdgeNE.UseVisualStyleBackColor = true;
            this.solidEdgeNE.CheckedChanged += new System.EventHandler(this.solidEdgeNE_CheckedChanged);
            // 
            // checkSpecialTile
            // 
            this.checkSpecialTile.AutoSize = true;
            this.checkSpecialTile.Location = new System.Drawing.Point(3, 401);
            this.checkSpecialTile.Name = "checkSpecialTile";
            this.checkSpecialTile.Size = new System.Drawing.Size(92, 13);
            this.checkSpecialTile.TabIndex = 2;
            this.checkSpecialTile.Text = "Special tile format";
            // 
            // conveyor
            // 
            this.conveyor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.conveyor.Items.AddRange(new object[] {
            "E",
            "SE",
            "S",
            "SW",
            "W",
            "NW",
            "N",
            "NE"});
            this.conveyor.Location = new System.Drawing.Point(130, 295);
            this.conveyor.Name = "conveyor";
            this.conveyor.Size = new System.Drawing.Size(90, 21);
            this.conveyor.TabIndex = 1;
            this.conveyor.SelectedIndexChanged += new System.EventHandler(this.conveyor_SelectedIndexChanged);
            // 
            // checkDoorFormat
            // 
            this.checkDoorFormat.AutoSize = true;
            this.checkDoorFormat.Location = new System.Drawing.Point(3, 422);
            this.checkDoorFormat.Name = "checkDoorFormat";
            this.checkDoorFormat.Size = new System.Drawing.Size(65, 13);
            this.checkDoorFormat.TabIndex = 4;
            this.checkDoorFormat.Text = "Door format";
            // 
            // checkConveyor
            // 
            this.checkConveyor.AutoSize = true;
            this.checkConveyor.Location = new System.Drawing.Point(3, 298);
            this.checkConveyor.Name = "checkConveyor";
            this.checkConveyor.Size = new System.Drawing.Size(99, 13);
            this.checkConveyor.TabIndex = 0;
            this.checkConveyor.Text = "Conveyor belt runs";
            // 
            // p3OverEdge
            // 
            this.p3OverEdge.AutoSize = true;
            this.p3OverEdge.Location = new System.Drawing.Point(3, 239);
            this.p3OverEdge.Name = "p3OverEdge";
            this.p3OverEdge.Size = new System.Drawing.Size(171, 17);
            this.p3OverEdge.TabIndex = 12;
            this.p3OverEdge.Text = "Priority 3 for object over edge";
            this.p3OverEdge.UseVisualStyleBackColor = true;
            this.p3OverEdge.CheckedChanged += new System.EventHandler(this.p3OverEdge_CheckedChanged);
            // 
            // headerLabel5
            // 
            this.headerLabel5.Location = new System.Drawing.Point(0, 360);
            this.headerLabel5.Name = "headerLabel5";
            this.headerLabel5.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.headerLabel5.Size = new System.Drawing.Size(224, 14);
            this.headerLabel5.TabIndex = 3;
            this.headerLabel5.Text = "Other";
            // 
            // headerLabel4
            // 
            this.headerLabel4.Location = new System.Drawing.Point(0, 278);
            this.headerLabel4.Name = "headerLabel4";
            this.headerLabel4.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.headerLabel4.Size = new System.Drawing.Size(224, 14);
            this.headerLabel4.TabIndex = 3;
            this.headerLabel4.Text = "Conveyor Belt";
            // 
            // headerLabel3
            // 
            this.headerLabel3.Location = new System.Drawing.Point(0, 203);
            this.headerLabel3.Name = "headerLabel3";
            this.headerLabel3.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.headerLabel3.Size = new System.Drawing.Size(224, 14);
            this.headerLabel3.TabIndex = 3;
            this.headerLabel3.Text = "Priority 3";
            // 
            // p3OnEdge
            // 
            this.p3OnEdge.AutoSize = true;
            this.p3OnEdge.Location = new System.Drawing.Point(3, 220);
            this.p3OnEdge.Name = "p3OnEdge";
            this.p3OnEdge.Size = new System.Drawing.Size(161, 17);
            this.p3OnEdge.TabIndex = 12;
            this.p3OnEdge.Text = "Priority 3 for object on edge";
            this.p3OnEdge.UseVisualStyleBackColor = true;
            this.p3OnEdge.CheckedChanged += new System.EventHandler(this.p3OnEdge_CheckedChanged);
            // 
            // headerLabel2
            // 
            this.headerLabel2.Location = new System.Drawing.Point(0, 123);
            this.headerLabel2.Name = "headerLabel2";
            this.headerLabel2.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.headerLabel2.Size = new System.Drawing.Size(224, 14);
            this.headerLabel2.TabIndex = 3;
            this.headerLabel2.Text = "Quadrant / edge solidity";
            // 
            // solidQuadrantS
            // 
            this.solidQuadrantS.Appearance = System.Windows.Forms.Appearance.Button;
            this.solidQuadrantS.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.solidQuadrantS.Image = ((System.Drawing.Image)(resources.GetObject("solidQuadrantS.Image")));
            this.solidQuadrantS.Location = new System.Drawing.Point(35, 180);
            this.solidQuadrantS.Name = "solidQuadrantS";
            this.solidQuadrantS.Size = new System.Drawing.Size(32, 20);
            this.solidQuadrantS.TabIndex = 12;
            this.solidQuadrantS.UseVisualStyleBackColor = true;
            this.solidQuadrantS.CheckedChanged += new System.EventHandler(this.solidQuadrantS_CheckedChanged);
            // 
            // headerLabel1
            // 
            this.headerLabel1.Location = new System.Drawing.Point(0, 0);
            this.headerLabel1.Name = "headerLabel1";
            this.headerLabel1.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.headerLabel1.Size = new System.Drawing.Size(224, 14);
            this.headerLabel1.TabIndex = 3;
            this.headerLabel1.Text = "Tile height / coordinates";
            // 
            // solidEdgeSW
            // 
            this.solidEdgeSW.Appearance = System.Windows.Forms.Appearance.Button;
            this.solidEdgeSW.Location = new System.Drawing.Point(3, 180);
            this.solidEdgeSW.Name = "solidEdgeSW";
            this.solidEdgeSW.Size = new System.Drawing.Size(32, 20);
            this.solidEdgeSW.TabIndex = 0;
            this.solidEdgeSW.UseVisualStyleBackColor = true;
            this.solidEdgeSW.CheckedChanged += new System.EventHandler(this.solidEdgeSW_CheckedChanged);
            // 
            // heightOfBaseTile
            // 
            this.heightOfBaseTile.Location = new System.Drawing.Point(130, 17);
            this.heightOfBaseTile.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.heightOfBaseTile.Name = "heightOfBaseTile";
            this.heightOfBaseTile.Size = new System.Drawing.Size(90, 21);
            this.heightOfBaseTile.TabIndex = 1;
            this.heightOfBaseTile.ValueChanged += new System.EventHandler(this.heightOfBaseTile_ValueChanged);
            // 
            // solidEdgeSE
            // 
            this.solidEdgeSE.Appearance = System.Windows.Forms.Appearance.Button;
            this.solidEdgeSE.Location = new System.Drawing.Point(67, 180);
            this.solidEdgeSE.Name = "solidEdgeSE";
            this.solidEdgeSE.Size = new System.Drawing.Size(32, 20);
            this.solidEdgeSE.TabIndex = 0;
            this.solidEdgeSE.UseVisualStyleBackColor = true;
            this.solidEdgeSE.CheckedChanged += new System.EventHandler(this.solidEdgeSE_CheckedChanged);
            // 
            // solidQuadrant
            // 
            this.solidQuadrant.AutoSize = true;
            this.solidQuadrant.Location = new System.Drawing.Point(114, 163);
            this.solidQuadrant.Name = "solidQuadrant";
            this.solidQuadrant.Size = new System.Drawing.Size(95, 17);
            this.solidQuadrant.TabIndex = 12;
            this.solidQuadrant.Text = "Solid quadrant";
            this.solidQuadrant.UseVisualStyleBackColor = true;
            this.solidQuadrant.CheckedChanged += new System.EventHandler(this.solidQuadrant_CheckedChanged);
            // 
            // zCoordOverhead
            // 
            this.zCoordOverhead.Location = new System.Drawing.Point(130, 59);
            this.zCoordOverhead.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.zCoordOverhead.Name = "zCoordOverhead";
            this.zCoordOverhead.Size = new System.Drawing.Size(90, 21);
            this.zCoordOverhead.TabIndex = 5;
            this.zCoordOverhead.ValueChanged += new System.EventHandler(this.zCoordOverhead_ValueChanged);
            // 
            // solidTile
            // 
            this.solidTile.AutoSize = true;
            this.solidTile.Location = new System.Drawing.Point(114, 143);
            this.solidTile.Name = "solidTile";
            this.solidTile.Size = new System.Drawing.Size(65, 17);
            this.solidTile.TabIndex = 12;
            this.solidTile.Text = "Solid tile";
            this.solidTile.UseVisualStyleBackColor = false;
            this.solidTile.CheckedChanged += new System.EventHandler(this.solidTile_CheckedChanged);
            // 
            // solidEdgeNW
            // 
            this.solidEdgeNW.Appearance = System.Windows.Forms.Appearance.Button;
            this.solidEdgeNW.Location = new System.Drawing.Point(3, 140);
            this.solidEdgeNW.Name = "solidEdgeNW";
            this.solidEdgeNW.Size = new System.Drawing.Size(32, 20);
            this.solidEdgeNW.TabIndex = 0;
            this.solidEdgeNW.UseVisualStyleBackColor = true;
            this.solidEdgeNW.CheckedChanged += new System.EventHandler(this.solidEdgeNW_CheckedChanged);
            // 
            // solidQuadrantE
            // 
            this.solidQuadrantE.Appearance = System.Windows.Forms.Appearance.Button;
            this.solidQuadrantE.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.solidQuadrantE.Image = ((System.Drawing.Image)(resources.GetObject("solidQuadrantE.Image")));
            this.solidQuadrantE.Location = new System.Drawing.Point(67, 160);
            this.solidQuadrantE.Name = "solidQuadrantE";
            this.solidQuadrantE.Size = new System.Drawing.Size(32, 20);
            this.solidQuadrantE.TabIndex = 12;
            this.solidQuadrantE.UseVisualStyleBackColor = true;
            this.solidQuadrantE.CheckedChanged += new System.EventHandler(this.solidQuadrantE_CheckedChanged);
            // 
            // checkHeightOfBaseTile
            // 
            this.checkHeightOfBaseTile.AutoSize = true;
            this.checkHeightOfBaseTile.Location = new System.Drawing.Point(3, 19);
            this.checkHeightOfBaseTile.Name = "checkHeightOfBaseTile";
            this.checkHeightOfBaseTile.Size = new System.Drawing.Size(94, 13);
            this.checkHeightOfBaseTile.TabIndex = 0;
            this.checkHeightOfBaseTile.Text = "Height of base tile";
            // 
            // solidQuadrantW
            // 
            this.solidQuadrantW.Appearance = System.Windows.Forms.Appearance.Button;
            this.solidQuadrantW.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.solidQuadrantW.Image = ((System.Drawing.Image)(resources.GetObject("solidQuadrantW.Image")));
            this.solidQuadrantW.Location = new System.Drawing.Point(3, 160);
            this.solidQuadrantW.Name = "solidQuadrantW";
            this.solidQuadrantW.Size = new System.Drawing.Size(32, 20);
            this.solidQuadrantW.TabIndex = 12;
            this.solidQuadrantW.UseVisualStyleBackColor = true;
            this.solidQuadrantW.CheckedChanged += new System.EventHandler(this.solidQuadrantW_CheckedChanged);
            // 
            // heightOverhead
            // 
            this.heightOverhead.Location = new System.Drawing.Point(130, 38);
            this.heightOverhead.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.heightOverhead.Name = "heightOverhead";
            this.heightOverhead.Size = new System.Drawing.Size(90, 21);
            this.heightOverhead.TabIndex = 3;
            this.heightOverhead.ValueChanged += new System.EventHandler(this.heightOverhead_ValueChanged);
            // 
            // solidQuadrantN
            // 
            this.solidQuadrantN.Appearance = System.Windows.Forms.Appearance.Button;
            this.solidQuadrantN.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.solidQuadrantN.Image = global::LAZYSHELL.Properties.Resources.quadBase;
            this.solidQuadrantN.Location = new System.Drawing.Point(35, 140);
            this.solidQuadrantN.Name = "solidQuadrantN";
            this.solidQuadrantN.Size = new System.Drawing.Size(32, 20);
            this.solidQuadrantN.TabIndex = 12;
            this.solidQuadrantN.UseVisualStyleBackColor = true;
            this.solidQuadrantN.CheckedChanged += new System.EventHandler(this.solidQuadrantN_CheckedChanged);
            // 
            // zCoordPlusHalf
            // 
            this.zCoordPlusHalf.AutoSize = true;
            this.zCoordPlusHalf.Location = new System.Drawing.Point(6, 103);
            this.zCoordPlusHalf.Name = "zCoordPlusHalf";
            this.zCoordPlusHalf.Size = new System.Drawing.Size(103, 17);
            this.zCoordPlusHalf.TabIndex = 12;
            this.zCoordPlusHalf.Text = "Z coord plus 1/2";
            this.zCoordPlusHalf.UseVisualStyleBackColor = true;
            this.zCoordPlusHalf.CheckedChanged += new System.EventHandler(this.zCoordPlusHalf_CheckedChanged);
            // 
            // zCoordWater
            // 
            this.zCoordWater.Location = new System.Drawing.Point(130, 80);
            this.zCoordWater.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.zCoordWater.Name = "zCoordWater";
            this.zCoordWater.Size = new System.Drawing.Size(90, 21);
            this.zCoordWater.TabIndex = 7;
            this.zCoordWater.ValueChanged += new System.EventHandler(this.zCoordWater_ValueChanged);
            // 
            // checkZCoordWater
            // 
            this.checkZCoordWater.AutoSize = true;
            this.checkZCoordWater.Location = new System.Drawing.Point(3, 82);
            this.checkZCoordWater.Name = "checkZCoordWater";
            this.checkZCoordWater.Size = new System.Drawing.Size(104, 13);
            this.checkZCoordWater.TabIndex = 6;
            this.checkZCoordWater.Text = "Z coord of water tile";
            // 
            // checkZCoordOverhead
            // 
            this.checkZCoordOverhead.AutoSize = true;
            this.checkZCoordOverhead.Location = new System.Drawing.Point(3, 61);
            this.checkZCoordOverhead.Name = "checkZCoordOverhead";
            this.checkZCoordOverhead.Size = new System.Drawing.Size(122, 13);
            this.checkZCoordOverhead.TabIndex = 4;
            this.checkZCoordOverhead.Text = "Z coord of overhead tile";
            // 
            // checkHeightOverhead
            // 
            this.checkHeightOverhead.AutoSize = true;
            this.checkHeightOverhead.Location = new System.Drawing.Point(3, 40);
            this.checkHeightOverhead.Name = "checkHeightOverhead";
            this.checkHeightOverhead.Size = new System.Drawing.Size(117, 13);
            this.checkHeightOverhead.TabIndex = 2;
            this.checkHeightOverhead.Text = "Height of overhead tile";
            // 
            // CollisionTileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(260, 541);
            this.Controls.Add(this.panelPhysicalTile);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "CollisionTileForm";
            this.Text = "Collision Tile";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CollisionTileForm_FormClosed);
            this.panelPhysicalTile.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.heightOfBaseTile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zCoordOverhead)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.heightOverhead)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zCoordWater)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        private System.Windows.Forms.Panel panelPhysicalTile;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton search;
        private Controls.NewToolStripNumericUpDown collisionTileNum;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckedListBox unknownBits;
        private System.Windows.Forms.NumericUpDown heightOfBaseTile;
        private System.Windows.Forms.NumericUpDown zCoordOverhead;
        private System.Windows.Forms.NumericUpDown heightOverhead;
        private System.Windows.Forms.NumericUpDown zCoordWater;
        private System.Windows.Forms.Label checkZCoordOverhead;
        private System.Windows.Forms.Label checkHeightOverhead;
        private System.Windows.Forms.Label checkHeightOfBaseTile;
        private System.Windows.Forms.Label checkZCoordWater;
        private System.Windows.Forms.Label checkStairs;
        private System.Windows.Forms.ComboBox specialTile;
        private System.Windows.Forms.ComboBox stairs;
        private System.Windows.Forms.Label checkDoorFormat;
        private System.Windows.Forms.ComboBox doorFormat;
        private System.Windows.Forms.Label checkSpecialTile;
        private System.Windows.Forms.Label checkConveyor;
        private System.Windows.Forms.ComboBox conveyor;
        private System.Windows.Forms.ToolStripButton reset;
        private System.Windows.Forms.CheckBox solidQuadrantS;
        private System.Windows.Forms.CheckBox solidQuadrant;
        private System.Windows.Forms.CheckBox solidTile;
        private System.Windows.Forms.CheckBox solidQuadrantE;
        private System.Windows.Forms.CheckBox solidQuadrantW;
        private System.Windows.Forms.CheckBox solidQuadrantN;
        private System.Windows.Forms.CheckBox zCoordPlusHalf;
        private System.Windows.Forms.CheckBox solidEdgeNE;
        private System.Windows.Forms.CheckBox solidEdgeSE;
        private System.Windows.Forms.CheckBox solidEdgeSW;
        private System.Windows.Forms.CheckBox solidEdgeNW;
        private System.Windows.Forms.CheckBox conveyorBeltNormal;
        private System.Windows.Forms.CheckBox conveyorBeltFast;
        private System.Windows.Forms.CheckBox p3OnTile;
        private System.Windows.Forms.CheckBox p3OverEdge;
        private Controls.HeaderLabel headerLabel5;
        private Controls.HeaderLabel headerLabel4;
        private Controls.HeaderLabel headerLabel3;
        private System.Windows.Forms.CheckBox p3OnEdge;
        private Controls.HeaderLabel headerLabel2;
        private Controls.HeaderLabel headerLabel1;
    }
}