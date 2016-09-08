
namespace LazyShell.Formations
{
    partial class FormationsForm
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
            this.panel10 = new System.Windows.Forms.Panel();
            this.picture = new System.Windows.Forms.PictureBox();
            this.cantRun = new System.Windows.Forms.CheckBox();
            this.label176 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.unknown = new System.Windows.Forms.NumericUpDown();
            this.musicTrack = new System.Windows.Forms.ComboBox();
            this.musicTheme = new System.Windows.Forms.ComboBox();
            this.label150 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.name = new System.Windows.Forms.ToolStripComboBox();
            this.search = new System.Windows.Forms.ToolStripButton();
            this.num = new LazyShell.Controls.NewToolStripNumericUpDown();
            this.startEvent = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.saveImage = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toggleAllies = new System.Windows.Forms.ToolStripButton();
            this.isometricGrid = new System.Windows.Forms.ToolStripButton();
            this.snapIsometricLeft = new System.Windows.Forms.ToolStripButton();
            this.snapIsometricRight = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.select = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.undo = new System.Windows.Forms.ToolStripButton();
            this.redo = new System.Windows.Forms.ToolStripButton();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toggleBG = new System.Windows.Forms.ToolStripButton();
            this.battlefieldName = new System.Windows.Forms.ToolStripComboBox();
            this.labelCoords = new System.Windows.Forms.ToolStripLabel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.monsterName = new System.Windows.Forms.ComboBox();
            this.monsterNum = new System.Windows.Forms.NumericUpDown();
            this.x = new System.Windows.Forms.NumericUpDown();
            this.y = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStrip4 = new System.Windows.Forms.ToolStrip();
            this.active = new System.Windows.Forms.ToolStripButton();
            this.hide = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.moveUp = new System.Windows.Forms.ToolStripButton();
            this.moveDown = new System.Windows.Forms.ToolStripButton();
            this.headerLabel1 = new LazyShell.Controls.HeaderLabel();
            this.lineSeparator1 = new LazyShell.LineSeparator();
            this.headerLabel2 = new LazyShell.Controls.HeaderLabel();
            this.panel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.unknown)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.toolStrip3.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.monsterNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.x)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.y)).BeginInit();
            this.toolStrip4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.picture);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel10.Location = new System.Drawing.Point(0, 25);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(260, 233);
            this.panel10.TabIndex = 1;
            // 
            // picture
            // 
            this.picture.BackgroundImage = global::LazyShell.Properties.Resources._transparent;
            this.picture.Location = new System.Drawing.Point(0, -32);
            this.picture.Name = "picture";
            this.picture.Size = new System.Drawing.Size(512, 512);
            this.picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picture.TabIndex = 286;
            this.picture.TabStop = false;
            this.picture.Paint += new System.Windows.Forms.PaintEventHandler(this.picture_Paint);
            this.picture.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.picture_MouseDoubleClick);
            this.picture.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picture_MouseDown);
            this.picture.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picture_MouseMove);
            this.picture.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picture_MouseUp);
            this.picture.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.picture_PreviewKeyDown);
            // 
            // cantRun
            // 
            this.cantRun.AutoSize = true;
            this.cantRun.Location = new System.Drawing.Point(6, 317);
            this.cantRun.Name = "cantRun";
            this.cantRun.Size = new System.Drawing.Size(126, 17);
            this.cantRun.TabIndex = 4;
            this.cantRun.Text = "Can\'t run from battle";
            this.cantRun.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cantRun.UseVisualStyleBackColor = false;
            this.cantRun.CheckedChanged += new System.EventHandler(this.cantRun_CheckedChanged);
            // 
            // label176
            // 
            this.label176.AutoSize = true;
            this.label176.Location = new System.Drawing.Point(274, 256);
            this.label176.Name = "label176";
            this.label176.Size = new System.Drawing.Size(62, 13);
            this.label176.TabIndex = 0;
            this.label176.Text = "Start Event";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(274, 277);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Unknown";
            // 
            // unknown
            // 
            this.unknown.Location = new System.Drawing.Point(344, 274);
            this.unknown.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.unknown.Name = "unknown";
            this.unknown.Size = new System.Drawing.Size(131, 21);
            this.unknown.TabIndex = 3;
            this.unknown.ValueChanged += new System.EventHandler(this.unknown_ValueChanged);
            // 
            // musicTrack
            // 
            this.musicTrack.DropDownHeight = 262;
            this.musicTrack.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.musicTrack.DropDownWidth = 250;
            this.musicTrack.IntegralHeight = false;
            this.musicTrack.Location = new System.Drawing.Point(344, 316);
            this.musicTrack.Name = "musicTrack";
            this.musicTrack.Size = new System.Drawing.Size(131, 21);
            this.musicTrack.TabIndex = 3;
            this.musicTrack.SelectedIndexChanged += new System.EventHandler(this.musicTrack_SelectedIndexChanged);
            // 
            // musicTheme
            // 
            this.musicTheme.DropDownHeight = 150;
            this.musicTheme.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.musicTheme.DropDownWidth = 100;
            this.musicTheme.IntegralHeight = false;
            this.musicTheme.Items.AddRange(new object[] {
            "Normal",
            "Boss 1",
            "Boss 2",
            "Smithy 1",
            "Moleville Mountain",
            "Booster Hill",
            "Barrel Volcano",
            "Culex",
            "{CURRENT}"});
            this.musicTheme.Location = new System.Drawing.Point(344, 295);
            this.musicTheme.Name = "musicTheme";
            this.musicTheme.Size = new System.Drawing.Size(131, 21);
            this.musicTheme.TabIndex = 1;
            this.musicTheme.SelectedIndexChanged += new System.EventHandler(this.musicTheme_SelectedIndexChanged);
            // 
            // label150
            // 
            this.label150.AutoSize = true;
            this.label150.Location = new System.Drawing.Point(274, 319);
            this.label150.Name = "label150";
            this.label150.Size = new System.Drawing.Size(64, 13);
            this.label150.TabIndex = 2;
            this.label150.Text = "Track Index";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(274, 298);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(62, 13);
            this.label16.TabIndex = 0;
            this.label16.Text = "Battle Song";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.name,
            this.search,
            this.num});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(482, 25);
            this.toolStrip1.TabIndex = 0;
            // 
            // name
            // 
            this.name.DropDownHeight = 506;
            this.name.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.name.DropDownWidth = 500;
            this.name.IntegralHeight = false;
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(380, 25);
            this.name.SelectedIndexChanged += new System.EventHandler(this.name_SelectedIndexChanged);
            // 
            // search
            // 
            this.search.Image = global::LazyShell.Properties.Resources.search;
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(23, 22);
            this.search.ToolTipText = "Search for formation";
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
            this.num.Location = new System.Drawing.Point(414, 1);
            this.num.Maximum = new decimal(new int[] {
            511,
            0,
            0,
            0});
            this.num.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.num.Name = "formationNum";
            this.num.Size = new System.Drawing.Size(60, 21);
            this.num.Text = "0";
            this.num.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.num.ValueChanged += new System.EventHandler(this.num_ValueChanged);
            // 
            // startEvent
            // 
            this.startEvent.DropDownHeight = 300;
            this.startEvent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.startEvent.DropDownWidth = 400;
            this.startEvent.IntegralHeight = false;
            this.startEvent.Location = new System.Drawing.Point(344, 253);
            this.startEvent.Name = "startEvent";
            this.startEvent.Size = new System.Drawing.Size(131, 21);
            this.startEvent.TabIndex = 1;
            this.startEvent.SelectedIndexChanged += new System.EventHandler(this.startEvent_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel10);
            this.panel1.Controls.Add(this.toolStrip3);
            this.panel1.Controls.Add(this.toolStrip2);
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(260, 283);
            this.panel1.TabIndex = 1;
            // 
            // toolStrip3
            // 
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveImage,
            this.toolStripSeparator4,
            this.toggleAllies,
            this.isometricGrid,
            this.snapIsometricLeft,
            this.snapIsometricRight,
            this.toolStripSeparator1,
            this.select,
            this.toolStripSeparator2,
            this.undo,
            this.redo});
            this.toolStrip3.Location = new System.Drawing.Point(0, 0);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.Size = new System.Drawing.Size(260, 25);
            this.toolStrip3.TabIndex = 0;
            this.toolStrip3.Text = "s";
            // 
            // saveImage
            // 
            this.saveImage.Image = global::LazyShell.Properties.Resources.exportImage;
            this.saveImage.Name = "saveImage";
            this.saveImage.Size = new System.Drawing.Size(23, 22);
            this.saveImage.ToolTipText = "Save Formation Image...";
            this.saveImage.Click += new System.EventHandler(this.saveImage_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // toggleAllies
            // 
            this.toggleAllies.CheckOnClick = true;
            this.toggleAllies.Image = global::LazyShell.Properties.Resources.marioicon;
            this.toggleAllies.Name = "toggleAllies";
            this.toggleAllies.Size = new System.Drawing.Size(23, 22);
            this.toggleAllies.ToolTipText = "Show/hide Allies";
            this.toggleAllies.Click += new System.EventHandler(this.toggleAllies_Click);
            // 
            // isometricGrid
            // 
            this.isometricGrid.CheckOnClick = true;
            this.isometricGrid.Image = global::LazyShell.Properties.Resources.buttonToggleOrthGrid;
            this.isometricGrid.Name = "isometricGrid";
            this.isometricGrid.Size = new System.Drawing.Size(23, 22);
            this.isometricGrid.ToolTipText = "Isometric Grid (G)";
            this.isometricGrid.Click += new System.EventHandler(this.isometricGrid_Click);
            // 
            // snapIsometricLeft
            // 
            this.snapIsometricLeft.CheckOnClick = true;
            this.snapIsometricLeft.Image = global::LazyShell.Properties.Resources.snapIsometricLeft;
            this.snapIsometricLeft.Name = "snapIsometricLeft";
            this.snapIsometricLeft.Size = new System.Drawing.Size(23, 22);
            this.snapIsometricLeft.ToolTipText = "Snap to left";
            // 
            // snapIsometricRight
            // 
            this.snapIsometricRight.CheckOnClick = true;
            this.snapIsometricRight.Image = global::LazyShell.Properties.Resources.snapIsometricRight;
            this.snapIsometricRight.Name = "snapIsometricRight";
            this.snapIsometricRight.Size = new System.Drawing.Size(23, 22);
            this.snapIsometricRight.ToolTipText = "Snap to right";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // select
            // 
            this.select.CheckOnClick = true;
            this.select.Image = global::LazyShell.Properties.Resources.select;
            this.select.Name = "select";
            this.select.Size = new System.Drawing.Size(23, 22);
            this.select.ToolTipText = "Select (S)";
            this.select.Click += new System.EventHandler(this.select_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // undo
            // 
            this.undo.Image = global::LazyShell.Properties.Resources.undo;
            this.undo.Name = "undo";
            this.undo.Size = new System.Drawing.Size(23, 22);
            this.undo.ToolTipText = "Undo (Ctrl+Z)";
            this.undo.Click += new System.EventHandler(this.undo_Click);
            // 
            // redo
            // 
            this.redo.Image = global::LazyShell.Properties.Resources.redo;
            this.redo.Name = "redo";
            this.redo.Size = new System.Drawing.Size(23, 22);
            this.redo.ToolTipText = "Redo (Ctrl+Y)";
            this.redo.Click += new System.EventHandler(this.redo_Click);
            // 
            // toolStrip2
            // 
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toggleBG,
            this.battlefieldName,
            this.labelCoords});
            this.toolStrip2.Location = new System.Drawing.Point(0, 258);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(260, 25);
            this.toolStrip2.TabIndex = 2;
            // 
            // toggleBG
            // 
            this.toggleBG.Checked = true;
            this.toggleBG.CheckOnClick = true;
            this.toggleBG.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toggleBG.Name = "toggleBG";
            this.toggleBG.Size = new System.Drawing.Size(26, 22);
            this.toggleBG.Text = "BG";
            this.toggleBG.Click += new System.EventHandler(this.toggleBG_Click);
            // 
            // battlefieldName
            // 
            this.battlefieldName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.battlefieldName.DropDownWidth = 250;
            this.battlefieldName.Name = "battlefieldName";
            this.battlefieldName.Size = new System.Drawing.Size(130, 25);
            this.battlefieldName.SelectedIndexChanged += new System.EventHandler(this.battlefieldName_SelectedIndexChanged);
            // 
            // labelCoords
            // 
            this.labelCoords.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.labelCoords.Name = "labelCoords";
            this.labelCoords.Size = new System.Drawing.Size(56, 22);
            this.labelCoords.Text = "(x: 0, y: 0)";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.listBox1);
            this.panel2.Controls.Add(this.monsterName);
            this.panel2.Controls.Add(this.monsterNum);
            this.panel2.Controls.Add(this.x);
            this.panel2.Controls.Add(this.y);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.toolStrip4);
            this.panel2.Controls.Add(this.headerLabel1);
            this.panel2.Location = new System.Drawing.Point(271, 28);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(211, 205);
            this.panel2.TabIndex = 5;
            // 
            // listBox1
            // 
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.listBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 15;
            this.listBox1.Items.AddRange(new object[] {
            "-",
            "-",
            "-",
            "-",
            "-",
            "-",
            "-",
            "-"});
            this.listBox1.Location = new System.Drawing.Point(0, 39);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(211, 124);
            this.listBox1.TabIndex = 21;
            this.listBox1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listBox1_DrawItem);
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // monsterName
            // 
            this.monsterName.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.monsterName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.monsterName.DropDownWidth = 100;
            this.monsterName.IntegralHeight = false;
            this.monsterName.ItemHeight = 15;
            this.monsterName.Location = new System.Drawing.Point(0, 163);
            this.monsterName.Name = "monsterName";
            this.monsterName.Size = new System.Drawing.Size(147, 21);
            this.monsterName.TabIndex = 15;
            this.monsterName.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.monsterName_DrawItem);
            this.monsterName.SelectedIndexChanged += new System.EventHandler(this.monsterName_SelectedIndexChanged);
            // 
            // monsterNum
            // 
            this.monsterNum.Location = new System.Drawing.Point(147, 163);
            this.monsterNum.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.monsterNum.Name = "monsterNum";
            this.monsterNum.Size = new System.Drawing.Size(57, 21);
            this.monsterNum.TabIndex = 17;
            this.monsterNum.ValueChanged += new System.EventHandler(this.monsterNum_ValueChanged);
            // 
            // x
            // 
            this.x.Location = new System.Drawing.Point(90, 184);
            this.x.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.x.Name = "x";
            this.x.Size = new System.Drawing.Size(57, 21);
            this.x.TabIndex = 18;
            this.x.ValueChanged += new System.EventHandler(this.x_ValueChanged);
            // 
            // y
            // 
            this.y.Location = new System.Drawing.Point(147, 184);
            this.y.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.y.Name = "y";
            this.y.Size = new System.Drawing.Size(57, 21);
            this.y.TabIndex = 16;
            this.y.ValueChanged += new System.EventHandler(this.y_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 187);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "(X,Y) coord";
            // 
            // toolStrip4
            // 
            this.toolStrip4.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.active,
            this.hide,
            this.toolStripSeparator3,
            this.moveUp,
            this.moveDown});
            this.toolStrip4.Location = new System.Drawing.Point(0, 14);
            this.toolStrip4.Name = "toolStrip4";
            this.toolStrip4.Size = new System.Drawing.Size(211, 25);
            this.toolStrip4.TabIndex = 22;
            this.toolStrip4.Text = "toolStrip4";
            // 
            // active
            // 
            this.active.CheckOnClick = true;
            this.active.Image = global::LazyShell.Properties.Resources.inactive;
            this.active.Name = "active";
            this.active.Size = new System.Drawing.Size(23, 22);
            this.active.ToolTipText = "Active in formation";
            this.active.CheckedChanged += new System.EventHandler(this.active_CheckedChanged);
            // 
            // hide
            // 
            this.hide.CheckOnClick = true;
            this.hide.Image = global::LazyShell.Properties.Resources.hideMonster;
            this.hide.Name = "hide";
            this.hide.Size = new System.Drawing.Size(23, 22);
            this.hide.ToolTipText = "Hide at battle start";
            this.hide.CheckedChanged += new System.EventHandler(this.hide_CheckedChanged);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // moveUp
            // 
            this.moveUp.Image = global::LazyShell.Properties.Resources.moveup;
            this.moveUp.Name = "moveUp";
            this.moveUp.Size = new System.Drawing.Size(23, 22);
            this.moveUp.ToolTipText = "Move monster up";
            this.moveUp.Click += new System.EventHandler(this.moveUp_Click);
            // 
            // moveDown
            // 
            this.moveDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.moveDown.Image = global::LazyShell.Properties.Resources.movedown;
            this.moveDown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.moveDown.Name = "moveDown";
            this.moveDown.Size = new System.Drawing.Size(23, 22);
            this.moveDown.ToolTipText = "Move monster down";
            this.moveDown.Click += new System.EventHandler(this.moveDown_Click);
            // 
            // headerLabel1
            // 
            this.headerLabel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerLabel1.Location = new System.Drawing.Point(0, 0);
            this.headerLabel1.Name = "headerLabel1";
            this.headerLabel1.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.headerLabel1.Size = new System.Drawing.Size(211, 14);
            this.headerLabel1.TabIndex = 7;
            this.headerLabel1.Text = "Formation Monsters";
            // 
            // lineSeparator1
            // 
            this.lineSeparator1.LineDirection = LazyShell.LineDirection.Vertical;
            this.lineSeparator1.Location = new System.Drawing.Point(269, 28);
            this.lineSeparator1.MaximumSize = new System.Drawing.Size(2, 2000);
            this.lineSeparator1.MinimumSize = new System.Drawing.Size(2, 0);
            this.lineSeparator1.Name = "lineSeparator1";
            this.lineSeparator1.Size = new System.Drawing.Size(2, 310);
            this.lineSeparator1.TabIndex = 6;
            // 
            // headerLabel2
            // 
            this.headerLabel2.Location = new System.Drawing.Point(271, 236);
            this.headerLabel2.Name = "headerLabel2";
            this.headerLabel2.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.headerLabel2.Size = new System.Drawing.Size(212, 14);
            this.headerLabel2.TabIndex = 8;
            this.headerLabel2.Text = "Formation Properties";
            // 
            // FormationsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 337);
            this.Controls.Add(this.musicTrack);
            this.Controls.Add(this.startEvent);
            this.Controls.Add(this.musicTheme);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.unknown);
            this.Controls.Add(this.label150);
            this.Controls.Add(this.headerLabel2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lineSeparator1);
            this.Controls.Add(this.label176);
            this.Controls.Add(this.cantRun);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "FormationsForm";
            this.Text = "Formations";
            this.panel10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.unknown)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.monsterNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.x)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.y)).EndInit();
            this.toolStrip4.ResumeLayout(false);
            this.toolStrip4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.PictureBox picture;
        private System.Windows.Forms.CheckBox cantRun;
        private System.Windows.Forms.ComboBox musicTrack;
        private System.Windows.Forms.ComboBox musicTheme;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown unknown;
        private System.Windows.Forms.Label label176;
        private System.Windows.Forms.Label label150;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripComboBox name;
        private System.Windows.Forms.ToolStripButton search;
        private Controls.NewToolStripNumericUpDown num;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripComboBox battlefieldName;
        private System.Windows.Forms.ComboBox startEvent;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripButton isometricGrid;
        private System.Windows.Forms.ToolStripButton snapIsometricLeft;
        private System.Windows.Forms.ToolStripButton snapIsometricRight;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton select;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStripButton undo;
        private System.Windows.Forms.ToolStripButton redo;
        private System.Windows.Forms.ToolStripLabel labelCoords;
        private System.Windows.Forms.ToolStripButton toggleAllies;
        private System.Windows.Forms.ToolStripButton toggleBG;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ComboBox monsterName;
        private System.Windows.Forms.NumericUpDown monsterNum;
        private System.Windows.Forms.NumericUpDown x;
        private System.Windows.Forms.NumericUpDown y;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStrip toolStrip4;
        private System.Windows.Forms.ToolStripButton active;
        private System.Windows.Forms.ToolStripButton hide;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton moveUp;
        private System.Windows.Forms.ToolStripButton moveDown;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton saveImage;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private LineSeparator lineSeparator1;
        private Controls.HeaderLabel headerLabel1;
        private Controls.HeaderLabel headerLabel2;
    }
}