namespace LAZYSHELL.Previewer
{
    public partial class Previewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Previewer));
            this.emuPathLabel = new System.Windows.Forms.Label();
            this.changeEmuButton = new System.Windows.Forms.Button();
            this.eventListBox = new System.Windows.Forms.ListBox();
            this.launchButton = new System.Windows.Forms.Button();
            this.romLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.selectNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.cancelButton = new System.Windows.Forms.Button();
            this.emuPathTextBox = new System.Windows.Forms.TextBox();
            this.romPathTextBox = new System.Windows.Forms.TextBox();
            this.argsTextBox = new System.Windows.Forms.TextBox();
            this.linkLabelZSNES = new System.Windows.Forms.LinkLabel();
            this.label4 = new System.Windows.Forms.Label();
            this.adjustXNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.adjustYNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.adjustZNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dynamicROMPath = new System.Windows.Forms.CheckBox();
            this.defaultZSNES = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel11 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.battleBGListBox = new System.Windows.Forms.ComboBox();
            this.panel8 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel13 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.defaultSNES9X = new System.Windows.Forms.Button();
            this.linkLabelSNES9X = new System.Windows.Forms.LinkLabel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.alliesInParty = new System.Windows.Forms.CheckedListBox();
            this.maxOutStats = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.selectNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.adjustXNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.adjustYNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.adjustZNumericUpDown)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel13.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // emuPathLabel
            // 
            this.emuPathLabel.BackColor = System.Drawing.SystemColors.Control;
            this.emuPathLabel.Location = new System.Drawing.Point(0, 0);
            this.emuPathLabel.Name = "emuPathLabel";
            this.emuPathLabel.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.emuPathLabel.Size = new System.Drawing.Size(128, 17);
            this.emuPathLabel.TabIndex = 0;
            this.emuPathLabel.Text = "Emulator Path:";
            // 
            // changeEmuButton
            // 
            this.changeEmuButton.BackColor = System.Drawing.SystemColors.Control;
            this.changeEmuButton.Location = new System.Drawing.Point(639, 0);
            this.changeEmuButton.Name = "changeEmuButton";
            this.changeEmuButton.Size = new System.Drawing.Size(70, 17);
            this.changeEmuButton.TabIndex = 1;
            this.changeEmuButton.Text = "...";
            this.changeEmuButton.UseCompatibleTextRendering = true;
            this.changeEmuButton.UseVisualStyleBackColor = false;
            this.changeEmuButton.Click += new System.EventHandler(this.changeEmuButton_Click);
            // 
            // eventListBox
            // 
            this.eventListBox.FormattingEnabled = true;
            this.eventListBox.IntegralHeight = false;
            this.eventListBox.Location = new System.Drawing.Point(12, 93);
            this.eventListBox.Name = "eventListBox";
            this.eventListBox.Size = new System.Drawing.Size(551, 286);
            this.eventListBox.TabIndex = 2;
            this.eventListBox.SelectedIndexChanged += new System.EventHandler(this.eventListBox_SelectedIndexChanged);
            // 
            // launchButton
            // 
            this.launchButton.FlatAppearance.BorderSize = 0;
            this.launchButton.Location = new System.Drawing.Point(569, 356);
            this.launchButton.Name = "launchButton";
            this.launchButton.Size = new System.Drawing.Size(75, 23);
            this.launchButton.TabIndex = 3;
            this.launchButton.Text = "Launch";
            this.launchButton.Click += new System.EventHandler(this.launchButton_Click);
            // 
            // romLabel
            // 
            this.romLabel.BackColor = System.Drawing.SystemColors.Control;
            this.romLabel.Location = new System.Drawing.Point(0, 18);
            this.romLabel.Name = "romLabel";
            this.romLabel.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.romLabel.Size = new System.Drawing.Size(128, 17);
            this.romLabel.TabIndex = 4;
            this.romLabel.Text = "Rom Path:";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label1.Size = new System.Drawing.Size(76, 17);
            this.label1.TabIndex = 6;
            // 
            // selectNumericUpDown
            // 
            this.selectNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.selectNumericUpDown.Location = new System.Drawing.Point(77, 0);
            this.selectNumericUpDown.Maximum = new decimal(new int[] {
            4095,
            0,
            0,
            0});
            this.selectNumericUpDown.Name = "selectNumericUpDown";
            this.selectNumericUpDown.Size = new System.Drawing.Size(75, 17);
            this.selectNumericUpDown.TabIndex = 5;
            this.selectNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.selectNumericUpDown.ValueChanged += new System.EventHandler(this.selectNumericUpDown_ValueChanged);
            // 
            // cancelButton
            // 
            this.cancelButton.FlatAppearance.BorderSize = 0;
            this.cancelButton.Location = new System.Drawing.Point(650, 356);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 7;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // emuPathTextBox
            // 
            this.emuPathTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.emuPathTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.emuPathTextBox.Location = new System.Drawing.Point(4, 2);
            this.emuPathTextBox.Name = "emuPathTextBox";
            this.emuPathTextBox.ReadOnly = true;
            this.emuPathTextBox.Size = new System.Drawing.Size(501, 14);
            this.emuPathTextBox.TabIndex = 8;
            // 
            // romPathTextBox
            // 
            this.romPathTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.romPathTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.romPathTextBox.Location = new System.Drawing.Point(4, 2);
            this.romPathTextBox.Name = "romPathTextBox";
            this.romPathTextBox.ReadOnly = true;
            this.romPathTextBox.Size = new System.Drawing.Size(501, 14);
            this.romPathTextBox.TabIndex = 9;
            // 
            // argsTextBox
            // 
            this.argsTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.argsTextBox.Location = new System.Drawing.Point(4, 2);
            this.argsTextBox.Name = "argsTextBox";
            this.argsTextBox.Size = new System.Drawing.Size(501, 14);
            this.argsTextBox.TabIndex = 17;
            // 
            // linkLabelZSNES
            // 
            this.linkLabelZSNES.BackColor = System.Drawing.SystemColors.Control;
            this.linkLabelZSNES.Location = new System.Drawing.Point(0, 54);
            this.linkLabelZSNES.Name = "linkLabelZSNES";
            this.linkLabelZSNES.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.linkLabelZSNES.Size = new System.Drawing.Size(128, 17);
            this.linkLabelZSNES.TabIndex = 19;
            this.linkLabelZSNES.TabStop = true;
            this.linkLabelZSNES.Tag = "";
            this.linkLabelZSNES.Text = "ZSNESW Cmd-Line Args:";
            this.linkLabelZSNES.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelZSNES_LinkClicked);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.Control;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label4.Size = new System.Drawing.Size(152, 17);
            this.label4.TabIndex = 20;
            this.label4.Text = "BATTLEFIELD";
            // 
            // adjustXNumericUpDown
            // 
            this.adjustXNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.adjustXNumericUpDown.Location = new System.Drawing.Point(77, 19);
            this.adjustXNumericUpDown.Maximum = new decimal(new int[] {
            63,
            0,
            0,
            0});
            this.adjustXNumericUpDown.Name = "adjustXNumericUpDown";
            this.adjustXNumericUpDown.Size = new System.Drawing.Size(75, 17);
            this.adjustXNumericUpDown.TabIndex = 21;
            this.adjustXNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // adjustYNumericUpDown
            // 
            this.adjustYNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.adjustYNumericUpDown.Location = new System.Drawing.Point(77, 37);
            this.adjustYNumericUpDown.Maximum = new decimal(new int[] {
            127,
            0,
            0,
            0});
            this.adjustYNumericUpDown.Name = "adjustYNumericUpDown";
            this.adjustYNumericUpDown.Size = new System.Drawing.Size(75, 17);
            this.adjustYNumericUpDown.TabIndex = 22;
            this.adjustYNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // adjustZNumericUpDown
            // 
            this.adjustZNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.adjustZNumericUpDown.Location = new System.Drawing.Point(77, 55);
            this.adjustZNumericUpDown.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.adjustZNumericUpDown.Name = "adjustZNumericUpDown";
            this.adjustZNumericUpDown.Size = new System.Drawing.Size(75, 17);
            this.adjustZNumericUpDown.TabIndex = 23;
            this.adjustZNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.SystemColors.Control;
            this.label5.Location = new System.Drawing.Point(0, 19);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label5.Size = new System.Drawing.Size(76, 17);
            this.label5.TabIndex = 24;
            this.label5.Text = "X coord";
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.SystemColors.Control;
            this.label6.Location = new System.Drawing.Point(0, 37);
            this.label6.Name = "label6";
            this.label6.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label6.Size = new System.Drawing.Size(76, 17);
            this.label6.TabIndex = 25;
            this.label6.Text = "Y coord";
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.SystemColors.Control;
            this.label7.Location = new System.Drawing.Point(0, 55);
            this.label7.Name = "label7";
            this.label7.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label7.Size = new System.Drawing.Size(76, 17);
            this.label7.TabIndex = 26;
            this.label7.Text = "Z coord";
            // 
            // dynamicROMPath
            // 
            this.dynamicROMPath.Appearance = System.Windows.Forms.Appearance.Button;
            this.dynamicROMPath.BackColor = System.Drawing.SystemColors.Control;
            this.dynamicROMPath.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.dynamicROMPath.Location = new System.Drawing.Point(639, 18);
            this.dynamicROMPath.Name = "dynamicROMPath";
            this.dynamicROMPath.Size = new System.Drawing.Size(70, 17);
            this.dynamicROMPath.TabIndex = 27;
            this.dynamicROMPath.Text = "DYNAMIC";
            this.dynamicROMPath.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.dynamicROMPath.UseCompatibleTextRendering = true;
            this.dynamicROMPath.UseVisualStyleBackColor = false;
            this.dynamicROMPath.CheckedChanged += new System.EventHandler(this.dynamicROMPath_CheckedChanged);
            // 
            // defaultZSNES
            // 
            this.defaultZSNES.BackColor = System.Drawing.SystemColors.Control;
            this.defaultZSNES.Location = new System.Drawing.Point(639, 54);
            this.defaultZSNES.Name = "defaultZSNES";
            this.defaultZSNES.Size = new System.Drawing.Size(70, 17);
            this.defaultZSNES.TabIndex = 28;
            this.defaultZSNES.Text = "DEFAULT";
            this.defaultZSNES.UseCompatibleTextRendering = true;
            this.defaultZSNES.UseVisualStyleBackColor = false;
            this.defaultZSNES.Click += new System.EventHandler(this.defaultZSNES_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Window;
            this.panel2.Controls.Add(this.emuPathTextBox);
            this.panel2.Location = new System.Drawing.Point(129, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(509, 17);
            this.panel2.TabIndex = 29;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Window;
            this.panel1.Controls.Add(this.romPathTextBox);
            this.panel1.Location = new System.Drawing.Point(129, 18);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(509, 17);
            this.panel1.TabIndex = 30;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Window;
            this.panel3.Controls.Add(this.argsTextBox);
            this.panel3.Location = new System.Drawing.Point(129, 54);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(509, 17);
            this.panel3.TabIndex = 31;
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.SystemColors.ControlText;
            this.panel11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel11.Controls.Add(this.label1);
            this.panel11.Controls.Add(this.selectNumericUpDown);
            this.panel11.Location = new System.Drawing.Point(569, 93);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(156, 21);
            this.panel11.TabIndex = 37;
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.SystemColors.ControlText;
            this.panel9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel9.Controls.Add(this.label4);
            this.panel9.Controls.Add(this.panel10);
            this.panel9.Enabled = false;
            this.panel9.Location = new System.Drawing.Point(569, 202);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(156, 40);
            this.panel9.TabIndex = 37;
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.battleBGListBox);
            this.panel10.Location = new System.Drawing.Point(0, 19);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(153, 17);
            this.panel10.TabIndex = 22;
            // 
            // battleBGListBox
            // 
            this.battleBGListBox.DropDownHeight = 392;
            this.battleBGListBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.battleBGListBox.DropDownWidth = 220;
            this.battleBGListBox.FormattingEnabled = true;
            this.battleBGListBox.IntegralHeight = false;
            this.battleBGListBox.Location = new System.Drawing.Point(-2, -2);
            this.battleBGListBox.Name = "battleBGListBox";
            this.battleBGListBox.Size = new System.Drawing.Size(156, 21);
            this.battleBGListBox.TabIndex = 21;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.SystemColors.ControlText;
            this.panel8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel8.Controls.Add(this.adjustXNumericUpDown);
            this.panel8.Controls.Add(this.label5);
            this.panel8.Controls.Add(this.label9);
            this.panel8.Controls.Add(this.label6);
            this.panel8.Controls.Add(this.adjustYNumericUpDown);
            this.panel8.Controls.Add(this.adjustZNumericUpDown);
            this.panel8.Controls.Add(this.label7);
            this.panel8.Location = new System.Drawing.Point(569, 120);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(156, 76);
            this.panel8.TabIndex = 36;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.SystemColors.Control;
            this.label9.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label9.Location = new System.Drawing.Point(0, 0);
            this.label9.Name = "label9";
            this.label9.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label9.Size = new System.Drawing.Size(152, 17);
            this.label9.TabIndex = 20;
            this.label9.Text = "MARIO COORDS";
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.SystemColors.ControlText;
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel6.Controls.Add(this.emuPathLabel);
            this.panel6.Controls.Add(this.changeEmuButton);
            this.panel6.Controls.Add(this.romLabel);
            this.panel6.Controls.Add(this.panel13);
            this.panel6.Controls.Add(this.panel3);
            this.panel6.Controls.Add(this.dynamicROMPath);
            this.panel6.Controls.Add(this.defaultSNES9X);
            this.panel6.Controls.Add(this.defaultZSNES);
            this.panel6.Controls.Add(this.panel2);
            this.panel6.Controls.Add(this.linkLabelSNES9X);
            this.panel6.Controls.Add(this.linkLabelZSNES);
            this.panel6.Controls.Add(this.panel1);
            this.panel6.Location = new System.Drawing.Point(12, 12);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(713, 75);
            this.panel6.TabIndex = 35;
            // 
            // panel13
            // 
            this.panel13.BackColor = System.Drawing.SystemColors.Window;
            this.panel13.Controls.Add(this.textBox1);
            this.panel13.Location = new System.Drawing.Point(129, 36);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(509, 17);
            this.panel13.TabIndex = 31;
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Location = new System.Drawing.Point(4, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(501, 14);
            this.textBox1.TabIndex = 17;
            // 
            // defaultSNES9X
            // 
            this.defaultSNES9X.BackColor = System.Drawing.SystemColors.Control;
            this.defaultSNES9X.Location = new System.Drawing.Point(639, 36);
            this.defaultSNES9X.Name = "defaultSNES9X";
            this.defaultSNES9X.Size = new System.Drawing.Size(70, 17);
            this.defaultSNES9X.TabIndex = 28;
            this.defaultSNES9X.Text = "DEFAULT";
            this.defaultSNES9X.UseCompatibleTextRendering = true;
            this.defaultSNES9X.UseVisualStyleBackColor = false;
            this.defaultSNES9X.Click += new System.EventHandler(this.defaultSNES9X_Click);
            // 
            // linkLabelSNES9X
            // 
            this.linkLabelSNES9X.BackColor = System.Drawing.SystemColors.Control;
            this.linkLabelSNES9X.Location = new System.Drawing.Point(0, 36);
            this.linkLabelSNES9X.Name = "linkLabelSNES9X";
            this.linkLabelSNES9X.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.linkLabelSNES9X.Size = new System.Drawing.Size(128, 17);
            this.linkLabelSNES9X.TabIndex = 19;
            this.linkLabelSNES9X.TabStop = true;
            this.linkLabelSNES9X.Tag = "";
            this.linkLabelSNES9X.Text = "SNES9X Cmd-Line Args:";
            this.linkLabelSNES9X.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelSNES9X_LinkClicked);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ControlText;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.alliesInParty);
            this.panel4.Controls.Add(this.maxOutStats);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Location = new System.Drawing.Point(569, 248);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(156, 104);
            this.panel4.TabIndex = 38;
            // 
            // alliesInParty
            // 
            this.alliesInParty.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.alliesInParty.CheckOnClick = true;
            this.alliesInParty.FormattingEnabled = true;
            this.alliesInParty.Items.AddRange(new object[] {
            "Toadstool",
            "Bowser",
            "Geno",
            "Mallow"});
            this.alliesInParty.Location = new System.Drawing.Point(0, 19);
            this.alliesInParty.Name = "alliesInParty";
            this.alliesInParty.Size = new System.Drawing.Size(152, 64);
            this.alliesInParty.TabIndex = 29;
            // 
            // maxOutStats
            // 
            this.maxOutStats.Appearance = System.Windows.Forms.Appearance.Button;
            this.maxOutStats.BackColor = System.Drawing.SystemColors.Control;
            this.maxOutStats.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.maxOutStats.Location = new System.Drawing.Point(0, 83);
            this.maxOutStats.Name = "maxOutStats";
            this.maxOutStats.Size = new System.Drawing.Size(152, 17);
            this.maxOutStats.TabIndex = 28;
            this.maxOutStats.Text = "MAX OUT STATS";
            this.maxOutStats.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.maxOutStats.UseCompatibleTextRendering = true;
            this.maxOutStats.UseVisualStyleBackColor = false;
            this.maxOutStats.CheckedChanged += new System.EventHandler(this.maxOutStats_CheckedChanged);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label2.Size = new System.Drawing.Size(152, 17);
            this.label2.TabIndex = 20;
            this.label2.Text = "ALLIES IN PARTY";
            // 
            // Previewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(737, 391);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.eventListBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.launchButton);
            this.Controls.Add(this.panel11);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel9);
            this.Controls.Add(this.panel8);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Previewer";
            ((System.ComponentModel.ISupportInitialize)(this.selectNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.adjustXNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.adjustYNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.adjustZNumericUpDown)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel11.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel13.ResumeLayout(false);
            this.panel13.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label emuPathLabel;
        private System.Windows.Forms.Button changeEmuButton;
        private System.Windows.Forms.ListBox eventListBox;
        private System.Windows.Forms.Button launchButton;
        private System.Windows.Forms.Label romLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown selectNumericUpDown;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.TextBox emuPathTextBox;
        private System.Windows.Forms.TextBox romPathTextBox;
        private System.Windows.Forms.TextBox argsTextBox;
        private System.Windows.Forms.LinkLabel linkLabelZSNES;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown adjustXNumericUpDown;
        private System.Windows.Forms.NumericUpDown adjustYNumericUpDown;
        private System.Windows.Forms.NumericUpDown adjustZNumericUpDown;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox dynamicROMPath;
        private System.Windows.Forms.Button defaultZSNES;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.ComboBox battleBGListBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button defaultSNES9X;
        private System.Windows.Forms.LinkLabel linkLabelSNES9X;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckedListBox alliesInParty;
        private System.Windows.Forms.CheckBox maxOutStats;
    }
}