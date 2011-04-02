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
            this.label2 = new System.Windows.Forms.Label();
            this.level = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.maxOutStats = new System.Windows.Forms.CheckBox();
            this.panel28 = new System.Windows.Forms.Panel();
            this.allyWeapon = new System.Windows.Forms.ComboBox();
            this.label133 = new System.Windows.Forms.Label();
            this.panel120 = new System.Windows.Forms.Panel();
            this.allyAccessory = new System.Windows.Forms.ComboBox();
            this.panel119 = new System.Windows.Forms.Panel();
            this.allyArmor = new System.Windows.Forms.ComboBox();
            this.label135 = new System.Windows.Forms.Label();
            this.label134 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.allyName = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.reset = new System.Windows.Forms.Button();
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
            ((System.ComponentModel.ISupportInitialize)(this.level)).BeginInit();
            this.panel28.SuspendLayout();
            this.panel120.SuspendLayout();
            this.panel119.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel7.SuspendLayout();
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
            this.changeEmuButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.changeEmuButton.BackColor = System.Drawing.SystemColors.Control;
            this.changeEmuButton.Location = new System.Drawing.Point(735, 0);
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
            this.eventListBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.eventListBox.FormattingEnabled = true;
            this.eventListBox.IntegralHeight = false;
            this.eventListBox.Location = new System.Drawing.Point(0, 75);
            this.eventListBox.Name = "eventListBox";
            this.eventListBox.Size = new System.Drawing.Size(651, 412);
            this.eventListBox.TabIndex = 2;
            this.eventListBox.SelectedIndexChanged += new System.EventHandler(this.eventListBox_SelectedIndexChanged);
            // 
            // launchButton
            // 
            this.launchButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.launchButton.FlatAppearance.BorderSize = 0;
            this.launchButton.Location = new System.Drawing.Point(654, 464);
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
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.FlatAppearance.BorderSize = 0;
            this.cancelButton.Location = new System.Drawing.Point(733, 464);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 7;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // emuPathTextBox
            // 
            this.emuPathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.emuPathTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.emuPathTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.emuPathTextBox.Location = new System.Drawing.Point(4, 2);
            this.emuPathTextBox.Name = "emuPathTextBox";
            this.emuPathTextBox.ReadOnly = true;
            this.emuPathTextBox.Size = new System.Drawing.Size(597, 14);
            this.emuPathTextBox.TabIndex = 8;
            // 
            // romPathTextBox
            // 
            this.romPathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.romPathTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.romPathTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.romPathTextBox.Location = new System.Drawing.Point(4, 2);
            this.romPathTextBox.Name = "romPathTextBox";
            this.romPathTextBox.ReadOnly = true;
            this.romPathTextBox.Size = new System.Drawing.Size(597, 14);
            this.romPathTextBox.TabIndex = 9;
            // 
            // argsTextBox
            // 
            this.argsTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.argsTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.argsTextBox.Location = new System.Drawing.Point(4, 2);
            this.argsTextBox.Name = "argsTextBox";
            this.argsTextBox.Size = new System.Drawing.Size(597, 14);
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
            this.dynamicROMPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dynamicROMPath.Appearance = System.Windows.Forms.Appearance.Button;
            this.dynamicROMPath.BackColor = System.Drawing.SystemColors.Control;
            this.dynamicROMPath.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.dynamicROMPath.Location = new System.Drawing.Point(735, 18);
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
            this.defaultZSNES.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.defaultZSNES.BackColor = System.Drawing.SystemColors.Control;
            this.defaultZSNES.Location = new System.Drawing.Point(735, 54);
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
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.SystemColors.Window;
            this.panel2.Controls.Add(this.emuPathTextBox);
            this.panel2.Location = new System.Drawing.Point(129, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(605, 17);
            this.panel2.TabIndex = 29;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.Window;
            this.panel1.Controls.Add(this.romPathTextBox);
            this.panel1.Location = new System.Drawing.Point(129, 18);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(605, 17);
            this.panel1.TabIndex = 30;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.SystemColors.Window;
            this.panel3.Controls.Add(this.argsTextBox);
            this.panel3.Location = new System.Drawing.Point(129, 54);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(605, 17);
            this.panel3.TabIndex = 31;
            // 
            // panel11
            // 
            this.panel11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel11.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel11.Controls.Add(this.label1);
            this.panel11.Controls.Add(this.selectNumericUpDown);
            this.panel11.Location = new System.Drawing.Point(653, 77);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(156, 21);
            this.panel11.TabIndex = 37;
            // 
            // panel9
            // 
            this.panel9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel9.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel9.Controls.Add(this.label4);
            this.panel9.Controls.Add(this.panel10);
            this.panel9.Enabled = false;
            this.panel9.Location = new System.Drawing.Point(653, 178);
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
            this.battleBGListBox.SelectedIndexChanged += new System.EventHandler(this.battleBGListBox_SelectedIndexChanged);
            // 
            // panel8
            // 
            this.panel8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel8.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel8.Controls.Add(this.adjustXNumericUpDown);
            this.panel8.Controls.Add(this.label5);
            this.panel8.Controls.Add(this.label9);
            this.panel8.Controls.Add(this.label6);
            this.panel8.Controls.Add(this.adjustYNumericUpDown);
            this.panel8.Controls.Add(this.adjustZNumericUpDown);
            this.panel8.Controls.Add(this.label7);
            this.panel8.Location = new System.Drawing.Point(653, 100);
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
            this.panel6.BackColor = System.Drawing.SystemColors.ControlDarkDark;
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
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(809, 75);
            this.panel6.TabIndex = 35;
            // 
            // panel13
            // 
            this.panel13.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel13.BackColor = System.Drawing.SystemColors.Window;
            this.panel13.Controls.Add(this.textBox1);
            this.panel13.Location = new System.Drawing.Point(129, 36);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(605, 17);
            this.panel13.TabIndex = 31;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Location = new System.Drawing.Point(4, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(597, 14);
            this.textBox1.TabIndex = 17;
            // 
            // defaultSNES9X
            // 
            this.defaultSNES9X.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.defaultSNES9X.BackColor = System.Drawing.SystemColors.Control;
            this.defaultSNES9X.Location = new System.Drawing.Point(735, 36);
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
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.alliesInParty);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Location = new System.Drawing.Point(653, 220);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(156, 87);
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
            this.alliesInParty.SelectedIndexChanged += new System.EventHandler(this.alliesInParty_SelectedIndexChanged);
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
            // level
            // 
            this.level.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.level.Location = new System.Drawing.Point(63, 19);
            this.level.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.level.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.level.Name = "level";
            this.level.Size = new System.Drawing.Size(89, 17);
            this.level.TabIndex = 21;
            this.level.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.level.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.level.ValueChanged += new System.EventHandler(this.level_ValueChanged);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(0, 19);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label3.Size = new System.Drawing.Size(62, 17);
            this.label3.TabIndex = 24;
            this.label3.Text = "Level";
            // 
            // maxOutStats
            // 
            this.maxOutStats.Appearance = System.Windows.Forms.Appearance.Button;
            this.maxOutStats.BackColor = System.Drawing.SystemColors.Control;
            this.maxOutStats.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.maxOutStats.Location = new System.Drawing.Point(0, 109);
            this.maxOutStats.Name = "maxOutStats";
            this.maxOutStats.Size = new System.Drawing.Size(152, 17);
            this.maxOutStats.TabIndex = 28;
            this.maxOutStats.Text = "MAX OUT STATS";
            this.maxOutStats.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.maxOutStats.UseCompatibleTextRendering = true;
            this.maxOutStats.UseVisualStyleBackColor = false;
            this.maxOutStats.CheckedChanged += new System.EventHandler(this.maxOutStats_CheckedChanged);
            // 
            // panel28
            // 
            this.panel28.Controls.Add(this.allyWeapon);
            this.panel28.Location = new System.Drawing.Point(63, 55);
            this.panel28.Name = "panel28";
            this.panel28.Size = new System.Drawing.Size(90, 17);
            this.panel28.TabIndex = 211;
            // 
            // allyWeapon
            // 
            this.allyWeapon.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.allyWeapon.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.allyWeapon.DropDownHeight = 317;
            this.allyWeapon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.allyWeapon.DropDownWidth = 150;
            this.allyWeapon.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.allyWeapon.IntegralHeight = false;
            this.allyWeapon.ItemHeight = 15;
            this.allyWeapon.Location = new System.Drawing.Point(-2, -2);
            this.allyWeapon.Name = "allyWeapon";
            this.allyWeapon.Size = new System.Drawing.Size(93, 21);
            this.allyWeapon.TabIndex = 109;
            this.allyWeapon.Tag = "";
            this.allyWeapon.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.itemName_DrawItem);
            this.allyWeapon.SelectedIndexChanged += new System.EventHandler(this.allyWeapon_SelectedIndexChanged);
            // 
            // label133
            // 
            this.label133.BackColor = System.Drawing.SystemColors.Control;
            this.label133.Location = new System.Drawing.Point(0, 91);
            this.label133.Name = "label133";
            this.label133.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label133.Size = new System.Drawing.Size(62, 17);
            this.label133.TabIndex = 210;
            this.label133.Text = "Accessory";
            // 
            // panel120
            // 
            this.panel120.Controls.Add(this.allyAccessory);
            this.panel120.Location = new System.Drawing.Point(63, 91);
            this.panel120.Name = "panel120";
            this.panel120.Size = new System.Drawing.Size(90, 17);
            this.panel120.TabIndex = 213;
            // 
            // allyAccessory
            // 
            this.allyAccessory.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.allyAccessory.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.allyAccessory.DropDownHeight = 317;
            this.allyAccessory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.allyAccessory.DropDownWidth = 150;
            this.allyAccessory.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.allyAccessory.IntegralHeight = false;
            this.allyAccessory.ItemHeight = 15;
            this.allyAccessory.Location = new System.Drawing.Point(-2, -2);
            this.allyAccessory.Name = "allyAccessory";
            this.allyAccessory.Size = new System.Drawing.Size(93, 21);
            this.allyAccessory.TabIndex = 111;
            this.allyAccessory.Tag = "";
            this.allyAccessory.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.itemName_DrawItem);
            this.allyAccessory.SelectedIndexChanged += new System.EventHandler(this.allyAccessory_SelectedIndexChanged);
            // 
            // panel119
            // 
            this.panel119.Controls.Add(this.allyArmor);
            this.panel119.Location = new System.Drawing.Point(63, 73);
            this.panel119.Name = "panel119";
            this.panel119.Size = new System.Drawing.Size(90, 17);
            this.panel119.TabIndex = 212;
            // 
            // allyArmor
            // 
            this.allyArmor.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.allyArmor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.allyArmor.DropDownHeight = 317;
            this.allyArmor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.allyArmor.DropDownWidth = 150;
            this.allyArmor.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.allyArmor.IntegralHeight = false;
            this.allyArmor.ItemHeight = 15;
            this.allyArmor.Location = new System.Drawing.Point(-2, -2);
            this.allyArmor.Name = "allyArmor";
            this.allyArmor.Size = new System.Drawing.Size(93, 21);
            this.allyArmor.TabIndex = 110;
            this.allyArmor.Tag = "";
            this.allyArmor.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.itemName_DrawItem);
            this.allyArmor.SelectedIndexChanged += new System.EventHandler(this.allyArmor_SelectedIndexChanged);
            // 
            // label135
            // 
            this.label135.BackColor = System.Drawing.SystemColors.Control;
            this.label135.Location = new System.Drawing.Point(0, 55);
            this.label135.Name = "label135";
            this.label135.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label135.Size = new System.Drawing.Size(62, 17);
            this.label135.TabIndex = 208;
            this.label135.Text = "Weapon";
            // 
            // label134
            // 
            this.label134.BackColor = System.Drawing.SystemColors.Control;
            this.label134.Location = new System.Drawing.Point(0, 73);
            this.label134.Name = "label134";
            this.label134.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label134.Size = new System.Drawing.Size(62, 17);
            this.label134.TabIndex = 209;
            this.label134.Text = "Armor";
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel5.Controls.Add(this.panel7);
            this.panel5.Controls.Add(this.panel28);
            this.panel5.Controls.Add(this.label8);
            this.panel5.Controls.Add(this.label133);
            this.panel5.Controls.Add(this.reset);
            this.panel5.Controls.Add(this.label3);
            this.panel5.Controls.Add(this.panel120);
            this.panel5.Controls.Add(this.maxOutStats);
            this.panel5.Controls.Add(this.panel119);
            this.panel5.Controls.Add(this.level);
            this.panel5.Controls.Add(this.label135);
            this.panel5.Controls.Add(this.label134);
            this.panel5.Location = new System.Drawing.Point(653, 309);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(156, 153);
            this.panel5.TabIndex = 38;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.allyName);
            this.panel7.Location = new System.Drawing.Point(0, 37);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(153, 17);
            this.panel7.TabIndex = 212;
            // 
            // allyName
            // 
            this.allyName.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.allyName.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.allyName.DropDownHeight = 317;
            this.allyName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.allyName.DropDownWidth = 150;
            this.allyName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.allyName.IntegralHeight = false;
            this.allyName.ItemHeight = 15;
            this.allyName.Location = new System.Drawing.Point(-2, -2);
            this.allyName.Name = "allyName";
            this.allyName.Size = new System.Drawing.Size(156, 21);
            this.allyName.TabIndex = 109;
            this.allyName.Tag = "";
            this.allyName.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.allyName_DrawItem);
            this.allyName.SelectedIndexChanged += new System.EventHandler(this.allyName_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.SystemColors.Control;
            this.label8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label8.Location = new System.Drawing.Point(0, 0);
            this.label8.Name = "label8";
            this.label8.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label8.Size = new System.Drawing.Size(152, 17);
            this.label8.TabIndex = 20;
            this.label8.Text = "ALLY STATS";
            // 
            // reset
            // 
            this.reset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.reset.BackColor = System.Drawing.SystemColors.Control;
            this.reset.FlatAppearance.BorderSize = 0;
            this.reset.Location = new System.Drawing.Point(0, 126);
            this.reset.Name = "reset";
            this.reset.Size = new System.Drawing.Size(152, 23);
            this.reset.TabIndex = 3;
            this.reset.Text = "Reset all equipment";
            this.reset.UseVisualStyleBackColor = false;
            this.reset.Click += new System.EventHandler(this.reset_Click);
            // 
            // Previewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 487);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.eventListBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.launchButton);
            this.Controls.Add(this.panel11);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel9);
            this.Controls.Add(this.panel8);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            ((System.ComponentModel.ISupportInitialize)(this.level)).EndInit();
            this.panel28.ResumeLayout(false);
            this.panel120.ResumeLayout(false);
            this.panel119.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
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
        private System.Windows.Forms.NumericUpDown level;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel28;
        private System.Windows.Forms.ComboBox allyWeapon;
        private System.Windows.Forms.Label label133;
        private System.Windows.Forms.Panel panel120;
        private System.Windows.Forms.ComboBox allyAccessory;
        private System.Windows.Forms.Panel panel119;
        private System.Windows.Forms.ComboBox allyArmor;
        private System.Windows.Forms.Label label135;
        private System.Windows.Forms.Label label134;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.ComboBox allyName;
        private System.Windows.Forms.Button reset;
    }
}