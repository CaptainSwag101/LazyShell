namespace LAZYSHELL.WorldMaps
{
    partial class LocationsForm
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
            this.locationYCoord = new System.Windows.Forms.NumericUpDown();
            this.showCheckAddress = new System.Windows.Forms.NumericUpDown();
            this.label59 = new System.Windows.Forms.Label();
            this.showCheckBit = new System.Windows.Forms.NumericUpDown();
            this.locationXCoord = new System.Windows.Forms.NumericUpDown();
            this.label45 = new System.Windows.Forms.Label();
            this.toolStrip5 = new System.Windows.Forms.ToolStrip();
            this.textBoxLocation = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.nameFreeSpace = new System.Windows.Forms.ToolStripLabel();
            this.toolStrip4 = new System.Windows.Forms.ToolStrip();
            this.name = new LAZYSHELL.Controls.NewToolStripComboBox();
            this.num = new LAZYSHELL.Controls.NewToolStripNumericUpDown();
            this.leadToLocation = new System.Windows.Forms.CheckBox();
            this.label52 = new System.Windows.Forms.Label();
            this.panel17 = new System.Windows.Forms.Panel();
            this.runEvent = new System.Windows.Forms.NumericUpDown();
            this.runEventEdit = new System.Windows.Forms.Button();
            this.goLocationA = new System.Windows.Forms.ComboBox();
            this.whichPointCheckBit = new System.Windows.Forms.NumericUpDown();
            this.goLocationB = new System.Windows.Forms.ComboBox();
            this.whichPointCheckAddress = new System.Windows.Forms.NumericUpDown();
            this.label56 = new System.Windows.Forms.Label();
            this.label55 = new System.Windows.Forms.Label();
            this.enableEastPath = new System.Windows.Forms.CheckBox();
            this.toSouthCheckBit = new System.Windows.Forms.NumericUpDown();
            this.toNorthCheckBit = new System.Windows.Forms.NumericUpDown();
            this.toWestCheckBit = new System.Windows.Forms.NumericUpDown();
            this.toNorthPoint = new System.Windows.Forms.ComboBox();
            this.toEastCheckBit = new System.Windows.Forms.NumericUpDown();
            this.toEastCheckAddress = new System.Windows.Forms.NumericUpDown();
            this.toNorthCheckAddress = new System.Windows.Forms.NumericUpDown();
            this.toWestCheckAddress = new System.Windows.Forms.NumericUpDown();
            this.enableNorthPath = new System.Windows.Forms.CheckBox();
            this.toSouthCheckAddress = new System.Windows.Forms.NumericUpDown();
            this.toEastPoint = new System.Windows.Forms.ComboBox();
            this.enableSouthPath = new System.Windows.Forms.CheckBox();
            this.toWestPoint = new System.Windows.Forms.ComboBox();
            this.toSouthPoint = new System.Windows.Forms.ComboBox();
            this.enableWestPath = new System.Windows.Forms.CheckBox();
            this.headerLabel1 = new LAZYSHELL.Controls.HeaderLabel();
            this.headerLabel2 = new LAZYSHELL.Controls.HeaderLabel();
            this.headerLabel3 = new LAZYSHELL.Controls.HeaderLabel();
            ((System.ComponentModel.ISupportInitialize)(this.locationYCoord)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.showCheckAddress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.showCheckBit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.locationXCoord)).BeginInit();
            this.toolStrip5.SuspendLayout();
            this.toolStrip4.SuspendLayout();
            this.panel17.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.runEvent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.whichPointCheckBit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.whichPointCheckAddress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toSouthCheckBit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toNorthCheckBit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toWestCheckBit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toEastCheckBit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toEastCheckAddress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toNorthCheckAddress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toWestCheckAddress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toSouthCheckAddress)).BeginInit();
            this.SuspendLayout();
            // 
            // locationYCoord
            // 
            this.locationYCoord.Location = new System.Drawing.Point(199, 67);
            this.locationYCoord.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.locationYCoord.Name = "locationYCoord";
            this.locationYCoord.Size = new System.Drawing.Size(71, 21);
            this.locationYCoord.TabIndex = 4;
            this.locationYCoord.ValueChanged += new System.EventHandler(this.y_ValueChanged);
            // 
            // showCheckAddress
            // 
            this.showCheckAddress.Hexadecimal = true;
            this.showCheckAddress.Location = new System.Drawing.Point(128, 88);
            this.showCheckAddress.Maximum = new decimal(new int[] {
            28868,
            0,
            0,
            0});
            this.showCheckAddress.Minimum = new decimal(new int[] {
            28741,
            0,
            0,
            0});
            this.showCheckAddress.Name = "showCheckAddress";
            this.showCheckAddress.Size = new System.Drawing.Size(71, 21);
            this.showCheckAddress.TabIndex = 6;
            this.showCheckAddress.Value = new decimal(new int[] {
            28741,
            0,
            0,
            0});
            this.showCheckAddress.ValueChanged += new System.EventHandler(this.showCheckAddress_ValueChanged);
            // 
            // label59
            // 
            this.label59.AutoSize = true;
            this.label59.Location = new System.Drawing.Point(4, 90);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(116, 13);
            this.label59.TabIndex = 5;
            this.label59.Text = "Show if memory bit set";
            // 
            // showCheckBit
            // 
            this.showCheckBit.Location = new System.Drawing.Point(199, 88);
            this.showCheckBit.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.showCheckBit.Name = "showCheckBit";
            this.showCheckBit.Size = new System.Drawing.Size(71, 21);
            this.showCheckBit.TabIndex = 7;
            this.showCheckBit.ValueChanged += new System.EventHandler(this.showCheckBit_ValueChanged);
            // 
            // locationXCoord
            // 
            this.locationXCoord.Location = new System.Drawing.Point(128, 67);
            this.locationXCoord.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.locationXCoord.Name = "locationXCoord";
            this.locationXCoord.Size = new System.Drawing.Size(71, 21);
            this.locationXCoord.TabIndex = 3;
            this.locationXCoord.ValueChanged += new System.EventHandler(this.x_ValueChanged);
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Location = new System.Drawing.Point(4, 69);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(64, 13);
            this.label45.TabIndex = 2;
            this.label45.Text = "(X, Y) coord";
            // 
            // toolStrip5
            // 
            this.toolStrip5.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.textBoxLocation,
            this.toolStripSeparator9,
            this.nameFreeSpace});
            this.toolStrip5.Location = new System.Drawing.Point(0, 25);
            this.toolStrip5.Name = "toolStrip5";
            this.toolStrip5.Size = new System.Drawing.Size(274, 25);
            this.toolStrip5.TabIndex = 1;
            // 
            // textBoxLocation
            // 
            this.textBoxLocation.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxLocation.Name = "textBoxLocation";
            this.textBoxLocation.Size = new System.Drawing.Size(164, 25);
            this.textBoxLocation.TextChanged += new System.EventHandler(this.nameText_TextChanged);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(6, 25);
            // 
            // nameFreeSpace
            // 
            this.nameFreeSpace.Name = "nameFreeSpace";
            this.nameFreeSpace.Size = new System.Drawing.Size(90, 22);
            this.nameFreeSpace.Text = "0 characters left";
            // 
            // toolStrip4
            // 
            this.toolStrip4.CanOverflow = false;
            this.toolStrip4.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.name,
            this.num});
            this.toolStrip4.Location = new System.Drawing.Point(0, 0);
            this.toolStrip4.Name = "toolStrip4";
            this.toolStrip4.Size = new System.Drawing.Size(274, 25);
            this.toolStrip4.TabIndex = 0;
            // 
            // name
            // 
            this.name.AutoSize = false;
            this.name.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.name.ContextMenuStrip = null;
            this.name.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.name.DropDownHeight = 453;
            this.name.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.name.DropDownWidth = 170;
            this.name.ItemHeight = 15;
            this.name.Location = new System.Drawing.Point(9, 2);
            this.name.Name = "name";
            this.name.SelectedIndex = -1;
            this.name.SelectedItem = null;
            this.name.Size = new System.Drawing.Size(182, 21);
            this.name.SelectedIndexChanged += new System.EventHandler(this.name_SelectedIndexChanged);
            this.name.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.name_DrawItem);
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
            this.num.Location = new System.Drawing.Point(191, 2);
            this.num.Maximum = new decimal(new int[] {
            55,
            0,
            0,
            0});
            this.num.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.num.Name = "locationNum";
            this.num.Size = new System.Drawing.Size(70, 21);
            this.num.Text = "0";
            this.num.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.num.ValueChanged += new System.EventHandler(this.num_ValueChanged);
            // 
            // leadToLocation
            // 
            this.leadToLocation.Appearance = System.Windows.Forms.Appearance.Button;
            this.leadToLocation.BackColor = System.Drawing.SystemColors.Control;
            this.leadToLocation.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.leadToLocation.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.leadToLocation.Location = new System.Drawing.Point(151, 129);
            this.leadToLocation.Name = "leadToLocation";
            this.leadToLocation.Size = new System.Drawing.Size(120, 21);
            this.leadToLocation.TabIndex = 0;
            this.leadToLocation.Text = "LOCATION";
            this.leadToLocation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.leadToLocation.UseCompatibleTextRendering = true;
            this.leadToLocation.UseVisualStyleBackColor = false;
            this.leadToLocation.CheckedChanged += new System.EventHandler(this.leadToLocation_CheckedChanged);
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Location = new System.Drawing.Point(4, 158);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(89, 13);
            this.label52.TabIndex = 1;
            this.label52.Text = "If memory bit set";
            // 
            // panel17
            // 
            this.panel17.Controls.Add(this.runEvent);
            this.panel17.Controls.Add(this.runEventEdit);
            this.panel17.Controls.Add(this.goLocationA);
            this.panel17.Location = new System.Drawing.Point(129, 175);
            this.panel17.Name = "panel17";
            this.panel17.Size = new System.Drawing.Size(142, 21);
            this.panel17.TabIndex = 5;
            // 
            // runEvent
            // 
            this.runEvent.Location = new System.Drawing.Point(0, 0);
            this.runEvent.Maximum = new decimal(new int[] {
            4095,
            0,
            0,
            0});
            this.runEvent.Name = "runEvent";
            this.runEvent.Size = new System.Drawing.Size(70, 21);
            this.runEvent.TabIndex = 0;
            this.runEvent.ValueChanged += new System.EventHandler(this.runEvent_ValueChanged);
            // 
            // runEventEdit
            // 
            this.runEventEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.runEventEdit.BackColor = System.Drawing.SystemColors.Control;
            this.runEventEdit.FlatAppearance.BorderSize = 0;
            this.runEventEdit.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.runEventEdit.Location = new System.Drawing.Point(70, 0);
            this.runEventEdit.Name = "runEventEdit";
            this.runEventEdit.Size = new System.Drawing.Size(71, 21);
            this.runEventEdit.TabIndex = 1;
            this.runEventEdit.Text = "EDIT";
            this.runEventEdit.UseCompatibleTextRendering = true;
            this.runEventEdit.UseVisualStyleBackColor = false;
            this.runEventEdit.Click += new System.EventHandler(this.runEventEdit_Click);
            // 
            // goLocationA
            // 
            this.goLocationA.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.goLocationA.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.goLocationA.DropDownHeight = 340;
            this.goLocationA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.goLocationA.DropDownWidth = 158;
            this.goLocationA.FormattingEnabled = true;
            this.goLocationA.IntegralHeight = false;
            this.goLocationA.ItemHeight = 15;
            this.goLocationA.Location = new System.Drawing.Point(0, 0);
            this.goLocationA.Name = "goLocationA";
            this.goLocationA.Size = new System.Drawing.Size(142, 21);
            this.goLocationA.TabIndex = 2;
            this.goLocationA.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.name_DrawItem);
            this.goLocationA.SelectedIndexChanged += new System.EventHandler(this.goLocationA_SelectedIndexChanged);
            // 
            // whichPointCheckBit
            // 
            this.whichPointCheckBit.Location = new System.Drawing.Point(199, 154);
            this.whichPointCheckBit.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.whichPointCheckBit.Name = "whichPointCheckBit";
            this.whichPointCheckBit.Size = new System.Drawing.Size(71, 21);
            this.whichPointCheckBit.TabIndex = 3;
            this.whichPointCheckBit.ValueChanged += new System.EventHandler(this.whichPointCheckBit_ValueChanged);
            // 
            // goLocationB
            // 
            this.goLocationB.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.goLocationB.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.goLocationB.DropDownHeight = 333;
            this.goLocationB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.goLocationB.DropDownWidth = 158;
            this.goLocationB.FormattingEnabled = true;
            this.goLocationB.IntegralHeight = false;
            this.goLocationB.ItemHeight = 15;
            this.goLocationB.Location = new System.Drawing.Point(129, 197);
            this.goLocationB.Name = "goLocationB";
            this.goLocationB.Size = new System.Drawing.Size(142, 21);
            this.goLocationB.TabIndex = 7;
            this.goLocationB.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.name_DrawItem);
            this.goLocationB.SelectedIndexChanged += new System.EventHandler(this.goLocationB_SelectedIndexChanged);
            // 
            // whichPointCheckAddress
            // 
            this.whichPointCheckAddress.Hexadecimal = true;
            this.whichPointCheckAddress.Location = new System.Drawing.Point(129, 154);
            this.whichPointCheckAddress.Maximum = new decimal(new int[] {
            36932,
            0,
            0,
            0});
            this.whichPointCheckAddress.Minimum = new decimal(new int[] {
            28741,
            0,
            0,
            0});
            this.whichPointCheckAddress.Name = "whichPointCheckAddress";
            this.whichPointCheckAddress.Size = new System.Drawing.Size(70, 21);
            this.whichPointCheckAddress.TabIndex = 2;
            this.whichPointCheckAddress.Value = new decimal(new int[] {
            28741,
            0,
            0,
            0});
            this.whichPointCheckAddress.ValueChanged += new System.EventHandler(this.whichPointCheckAddress_ValueChanged);
            // 
            // label56
            // 
            this.label56.AutoSize = true;
            this.label56.Location = new System.Drawing.Point(4, 200);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(118, 13);
            this.label56.TabIndex = 6;
            this.label56.Text = "else lead to destination";
            // 
            // label55
            // 
            this.label55.AutoSize = true;
            this.label55.Location = new System.Drawing.Point(4, 179);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(96, 13);
            this.label55.TabIndex = 4;
            this.label55.Text = "lead to destination";
            // 
            // enableEastPath
            // 
            this.enableEastPath.Appearance = System.Windows.Forms.Appearance.Button;
            this.enableEastPath.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enableEastPath.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.enableEastPath.Location = new System.Drawing.Point(3, 236);
            this.enableEastPath.Name = "enableEastPath";
            this.enableEastPath.Size = new System.Drawing.Size(47, 20);
            this.enableEastPath.TabIndex = 0;
            this.enableEastPath.Text = "EAST";
            this.enableEastPath.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.enableEastPath.UseCompatibleTextRendering = true;
            this.enableEastPath.UseVisualStyleBackColor = false;
            this.enableEastPath.CheckedChanged += new System.EventHandler(this.enableEastPath_CheckedChanged);
            // 
            // toSouthCheckBit
            // 
            this.toSouthCheckBit.Location = new System.Drawing.Point(232, 258);
            this.toSouthCheckBit.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.toSouthCheckBit.Name = "toSouthCheckBit";
            this.toSouthCheckBit.Size = new System.Drawing.Size(39, 21);
            this.toSouthCheckBit.TabIndex = 7;
            this.toSouthCheckBit.ValueChanged += new System.EventHandler(this.toSouthCheckBit_ValueChanged);
            // 
            // toNorthCheckBit
            // 
            this.toNorthCheckBit.Location = new System.Drawing.Point(232, 300);
            this.toNorthCheckBit.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.toNorthCheckBit.Name = "toNorthCheckBit";
            this.toNorthCheckBit.Size = new System.Drawing.Size(39, 21);
            this.toNorthCheckBit.TabIndex = 15;
            this.toNorthCheckBit.ValueChanged += new System.EventHandler(this.toNorthCheckBit_ValueChanged);
            // 
            // toWestCheckBit
            // 
            this.toWestCheckBit.Location = new System.Drawing.Point(232, 279);
            this.toWestCheckBit.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.toWestCheckBit.Name = "toWestCheckBit";
            this.toWestCheckBit.Size = new System.Drawing.Size(39, 21);
            this.toWestCheckBit.TabIndex = 11;
            this.toWestCheckBit.ValueChanged += new System.EventHandler(this.toWestCheckBit_ValueChanged);
            // 
            // toNorthPoint
            // 
            this.toNorthPoint.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.toNorthPoint.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.toNorthPoint.DropDownHeight = 333;
            this.toNorthPoint.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toNorthPoint.DropDownWidth = 158;
            this.toNorthPoint.FormattingEnabled = true;
            this.toNorthPoint.IntegralHeight = false;
            this.toNorthPoint.ItemHeight = 15;
            this.toNorthPoint.Location = new System.Drawing.Point(52, 300);
            this.toNorthPoint.Name = "toNorthPoint";
            this.toNorthPoint.Size = new System.Drawing.Size(130, 21);
            this.toNorthPoint.TabIndex = 13;
            this.toNorthPoint.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.name_DrawItem);
            this.toNorthPoint.SelectedIndexChanged += new System.EventHandler(this.toNorthPoint_SelectedIndexChanged);
            // 
            // toEastCheckBit
            // 
            this.toEastCheckBit.Location = new System.Drawing.Point(232, 237);
            this.toEastCheckBit.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.toEastCheckBit.Name = "toEastCheckBit";
            this.toEastCheckBit.Size = new System.Drawing.Size(39, 21);
            this.toEastCheckBit.TabIndex = 3;
            this.toEastCheckBit.ValueChanged += new System.EventHandler(this.toEastCheckBit_ValueChanged);
            // 
            // toEastCheckAddress
            // 
            this.toEastCheckAddress.Hexadecimal = true;
            this.toEastCheckAddress.Location = new System.Drawing.Point(182, 237);
            this.toEastCheckAddress.Maximum = new decimal(new int[] {
            28804,
            0,
            0,
            0});
            this.toEastCheckAddress.Minimum = new decimal(new int[] {
            28741,
            0,
            0,
            0});
            this.toEastCheckAddress.Name = "toEastCheckAddress";
            this.toEastCheckAddress.Size = new System.Drawing.Size(50, 21);
            this.toEastCheckAddress.TabIndex = 2;
            this.toEastCheckAddress.Value = new decimal(new int[] {
            28741,
            0,
            0,
            0});
            this.toEastCheckAddress.ValueChanged += new System.EventHandler(this.toEastCheckAddress_ValueChanged);
            // 
            // toNorthCheckAddress
            // 
            this.toNorthCheckAddress.Hexadecimal = true;
            this.toNorthCheckAddress.Location = new System.Drawing.Point(182, 300);
            this.toNorthCheckAddress.Maximum = new decimal(new int[] {
            28804,
            0,
            0,
            0});
            this.toNorthCheckAddress.Minimum = new decimal(new int[] {
            28741,
            0,
            0,
            0});
            this.toNorthCheckAddress.Name = "toNorthCheckAddress";
            this.toNorthCheckAddress.Size = new System.Drawing.Size(50, 21);
            this.toNorthCheckAddress.TabIndex = 14;
            this.toNorthCheckAddress.Value = new decimal(new int[] {
            28741,
            0,
            0,
            0});
            this.toNorthCheckAddress.ValueChanged += new System.EventHandler(this.toNorthCheckAddress_ValueChanged);
            // 
            // toWestCheckAddress
            // 
            this.toWestCheckAddress.Hexadecimal = true;
            this.toWestCheckAddress.Location = new System.Drawing.Point(182, 279);
            this.toWestCheckAddress.Maximum = new decimal(new int[] {
            28804,
            0,
            0,
            0});
            this.toWestCheckAddress.Minimum = new decimal(new int[] {
            28741,
            0,
            0,
            0});
            this.toWestCheckAddress.Name = "toWestCheckAddress";
            this.toWestCheckAddress.Size = new System.Drawing.Size(50, 21);
            this.toWestCheckAddress.TabIndex = 10;
            this.toWestCheckAddress.Value = new decimal(new int[] {
            28741,
            0,
            0,
            0});
            this.toWestCheckAddress.ValueChanged += new System.EventHandler(this.toWestCheckAddress_ValueChanged);
            // 
            // enableNorthPath
            // 
            this.enableNorthPath.Appearance = System.Windows.Forms.Appearance.Button;
            this.enableNorthPath.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enableNorthPath.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.enableNorthPath.Location = new System.Drawing.Point(3, 299);
            this.enableNorthPath.Name = "enableNorthPath";
            this.enableNorthPath.Size = new System.Drawing.Size(47, 20);
            this.enableNorthPath.TabIndex = 12;
            this.enableNorthPath.Text = "NORTH";
            this.enableNorthPath.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.enableNorthPath.UseCompatibleTextRendering = true;
            this.enableNorthPath.UseVisualStyleBackColor = false;
            this.enableNorthPath.CheckedChanged += new System.EventHandler(this.enableNorthPath_CheckedChanged);
            // 
            // toSouthCheckAddress
            // 
            this.toSouthCheckAddress.Hexadecimal = true;
            this.toSouthCheckAddress.Location = new System.Drawing.Point(182, 258);
            this.toSouthCheckAddress.Maximum = new decimal(new int[] {
            28804,
            0,
            0,
            0});
            this.toSouthCheckAddress.Minimum = new decimal(new int[] {
            28741,
            0,
            0,
            0});
            this.toSouthCheckAddress.Name = "toSouthCheckAddress";
            this.toSouthCheckAddress.Size = new System.Drawing.Size(50, 21);
            this.toSouthCheckAddress.TabIndex = 6;
            this.toSouthCheckAddress.Value = new decimal(new int[] {
            28741,
            0,
            0,
            0});
            this.toSouthCheckAddress.ValueChanged += new System.EventHandler(this.toSouthCheckAddress_ValueChanged);
            // 
            // toEastPoint
            // 
            this.toEastPoint.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.toEastPoint.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.toEastPoint.DropDownHeight = 333;
            this.toEastPoint.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toEastPoint.DropDownWidth = 158;
            this.toEastPoint.FormattingEnabled = true;
            this.toEastPoint.IntegralHeight = false;
            this.toEastPoint.ItemHeight = 15;
            this.toEastPoint.Location = new System.Drawing.Point(52, 237);
            this.toEastPoint.Name = "toEastPoint";
            this.toEastPoint.Size = new System.Drawing.Size(130, 21);
            this.toEastPoint.TabIndex = 1;
            this.toEastPoint.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.name_DrawItem);
            this.toEastPoint.SelectedIndexChanged += new System.EventHandler(this.toEastPoint_SelectedIndexChanged);
            // 
            // enableSouthPath
            // 
            this.enableSouthPath.Appearance = System.Windows.Forms.Appearance.Button;
            this.enableSouthPath.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enableSouthPath.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.enableSouthPath.Location = new System.Drawing.Point(3, 257);
            this.enableSouthPath.Name = "enableSouthPath";
            this.enableSouthPath.Size = new System.Drawing.Size(47, 20);
            this.enableSouthPath.TabIndex = 4;
            this.enableSouthPath.Text = "SOUTH";
            this.enableSouthPath.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.enableSouthPath.UseCompatibleTextRendering = true;
            this.enableSouthPath.UseVisualStyleBackColor = false;
            this.enableSouthPath.CheckedChanged += new System.EventHandler(this.enableSouthPath_CheckedChanged);
            // 
            // toWestPoint
            // 
            this.toWestPoint.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.toWestPoint.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.toWestPoint.DropDownHeight = 333;
            this.toWestPoint.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toWestPoint.DropDownWidth = 158;
            this.toWestPoint.FormattingEnabled = true;
            this.toWestPoint.IntegralHeight = false;
            this.toWestPoint.ItemHeight = 15;
            this.toWestPoint.Location = new System.Drawing.Point(52, 279);
            this.toWestPoint.Name = "toWestPoint";
            this.toWestPoint.Size = new System.Drawing.Size(130, 21);
            this.toWestPoint.TabIndex = 9;
            this.toWestPoint.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.name_DrawItem);
            this.toWestPoint.SelectedIndexChanged += new System.EventHandler(this.toWestPoint_SelectedIndexChanged);
            // 
            // toSouthPoint
            // 
            this.toSouthPoint.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.toSouthPoint.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.toSouthPoint.DropDownHeight = 333;
            this.toSouthPoint.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toSouthPoint.DropDownWidth = 158;
            this.toSouthPoint.FormattingEnabled = true;
            this.toSouthPoint.IntegralHeight = false;
            this.toSouthPoint.ItemHeight = 15;
            this.toSouthPoint.Location = new System.Drawing.Point(52, 258);
            this.toSouthPoint.Name = "toSouthPoint";
            this.toSouthPoint.Size = new System.Drawing.Size(130, 21);
            this.toSouthPoint.TabIndex = 5;
            this.toSouthPoint.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.name_DrawItem);
            this.toSouthPoint.SelectedIndexChanged += new System.EventHandler(this.toSouthPoint_SelectedIndexChanged);
            // 
            // enableWestPath
            // 
            this.enableWestPath.Appearance = System.Windows.Forms.Appearance.Button;
            this.enableWestPath.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enableWestPath.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.enableWestPath.Location = new System.Drawing.Point(3, 278);
            this.enableWestPath.Name = "enableWestPath";
            this.enableWestPath.Size = new System.Drawing.Size(47, 20);
            this.enableWestPath.TabIndex = 8;
            this.enableWestPath.Text = "WEST";
            this.enableWestPath.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.enableWestPath.UseCompatibleTextRendering = true;
            this.enableWestPath.UseVisualStyleBackColor = false;
            this.enableWestPath.CheckedChanged += new System.EventHandler(this.enableWestPath_CheckedChanged);
            // 
            // headerLabel1
            // 
            this.headerLabel1.Location = new System.Drawing.Point(0, 50);
            this.headerLabel1.Name = "headerLabel1";
            this.headerLabel1.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.headerLabel1.Size = new System.Drawing.Size(274, 14);
            this.headerLabel1.TabIndex = 8;
            this.headerLabel1.Text = "Location Properties";
            // 
            // headerLabel2
            // 
            this.headerLabel2.Location = new System.Drawing.Point(0, 112);
            this.headerLabel2.Name = "headerLabel2";
            this.headerLabel2.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.headerLabel2.Size = new System.Drawing.Size(274, 14);
            this.headerLabel2.TabIndex = 8;
            this.headerLabel2.Text = "Destination";
            // 
            // headerLabel3
            // 
            this.headerLabel3.Location = new System.Drawing.Point(0, 220);
            this.headerLabel3.Name = "headerLabel3";
            this.headerLabel3.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.headerLabel3.Size = new System.Drawing.Size(274, 14);
            this.headerLabel3.TabIndex = 8;
            this.headerLabel3.Text = "Open path if memory bit set";
            // 
            // LocationsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(274, 324);
            this.Controls.Add(this.enableEastPath);
            this.Controls.Add(this.leadToLocation);
            this.Controls.Add(this.toSouthCheckBit);
            this.Controls.Add(this.label52);
            this.Controls.Add(this.toNorthCheckBit);
            this.Controls.Add(this.headerLabel3);
            this.Controls.Add(this.toWestCheckBit);
            this.Controls.Add(this.headerLabel2);
            this.Controls.Add(this.toNorthPoint);
            this.Controls.Add(this.panel17);
            this.Controls.Add(this.toEastCheckBit);
            this.Controls.Add(this.toEastCheckAddress);
            this.Controls.Add(this.headerLabel1);
            this.Controls.Add(this.toNorthCheckAddress);
            this.Controls.Add(this.whichPointCheckBit);
            this.Controls.Add(this.toWestCheckAddress);
            this.Controls.Add(this.locationYCoord);
            this.Controls.Add(this.enableNorthPath);
            this.Controls.Add(this.goLocationB);
            this.Controls.Add(this.toSouthCheckAddress);
            this.Controls.Add(this.showCheckAddress);
            this.Controls.Add(this.toEastPoint);
            this.Controls.Add(this.whichPointCheckAddress);
            this.Controls.Add(this.enableSouthPath);
            this.Controls.Add(this.label59);
            this.Controls.Add(this.toWestPoint);
            this.Controls.Add(this.label56);
            this.Controls.Add(this.toSouthPoint);
            this.Controls.Add(this.toolStrip5);
            this.Controls.Add(this.enableWestPath);
            this.Controls.Add(this.label55);
            this.Controls.Add(this.showCheckBit);
            this.Controls.Add(this.locationXCoord);
            this.Controls.Add(this.label45);
            this.Controls.Add(this.toolStrip4);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "LocationsForm";
            this.Text = "Location";
            ((System.ComponentModel.ISupportInitialize)(this.locationYCoord)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.showCheckAddress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.showCheckBit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.locationXCoord)).EndInit();
            this.toolStrip5.ResumeLayout(false);
            this.toolStrip5.PerformLayout();
            this.toolStrip4.ResumeLayout(false);
            this.toolStrip4.PerformLayout();
            this.panel17.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.runEvent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.whichPointCheckBit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.whichPointCheckAddress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toSouthCheckBit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toNorthCheckBit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toWestCheckBit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toEastCheckBit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toEastCheckAddress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toNorthCheckAddress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toWestCheckAddress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toSouthCheckAddress)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown locationYCoord;
        private System.Windows.Forms.ToolStrip toolStrip5;
        private System.Windows.Forms.ToolStripTextBox textBoxLocation;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripLabel nameFreeSpace;
        private System.Windows.Forms.NumericUpDown showCheckAddress;
        private System.Windows.Forms.Label label59;
        private System.Windows.Forms.NumericUpDown showCheckBit;
        private System.Windows.Forms.ToolStrip toolStrip4;
        private Controls.NewToolStripComboBox name;
        private Controls.NewToolStripNumericUpDown num;
        private System.Windows.Forms.NumericUpDown locationXCoord;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.CheckBox leadToLocation;
        private System.Windows.Forms.Label label52;
        private System.Windows.Forms.Panel panel17;
        private System.Windows.Forms.NumericUpDown runEvent;
        private System.Windows.Forms.Button runEventEdit;
        private System.Windows.Forms.ComboBox goLocationA;
        private System.Windows.Forms.NumericUpDown whichPointCheckBit;
        private System.Windows.Forms.ComboBox goLocationB;
        private System.Windows.Forms.NumericUpDown whichPointCheckAddress;
        private System.Windows.Forms.Label label56;
        private System.Windows.Forms.Label label55;
        private System.Windows.Forms.CheckBox enableEastPath;
        private System.Windows.Forms.NumericUpDown toSouthCheckBit;
        private System.Windows.Forms.NumericUpDown toNorthCheckBit;
        private System.Windows.Forms.NumericUpDown toWestCheckBit;
        private System.Windows.Forms.ComboBox toNorthPoint;
        private System.Windows.Forms.NumericUpDown toEastCheckBit;
        private System.Windows.Forms.NumericUpDown toEastCheckAddress;
        private System.Windows.Forms.NumericUpDown toNorthCheckAddress;
        private System.Windows.Forms.NumericUpDown toWestCheckAddress;
        private System.Windows.Forms.CheckBox enableNorthPath;
        private System.Windows.Forms.NumericUpDown toSouthCheckAddress;
        private System.Windows.Forms.ComboBox toEastPoint;
        private System.Windows.Forms.CheckBox enableSouthPath;
        private System.Windows.Forms.ComboBox toWestPoint;
        private System.Windows.Forms.ComboBox toSouthPoint;
        private System.Windows.Forms.CheckBox enableWestPath;
        private Controls.HeaderLabel headerLabel1;
        private Controls.HeaderLabel headerLabel2;
        private Controls.HeaderLabel headerLabel3;
    }
}