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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.argsTextBox = new System.Windows.Forms.TextBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label4 = new System.Windows.Forms.Label();
            this.adjustXNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.adjustYNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.adjustZNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.toggleAssembleLevels = new System.Windows.Forms.CheckBox();
            this.toggleAssembleScripts = new System.Windows.Forms.CheckBox();
            this.toggleAssembleSprites = new System.Windows.Forms.CheckBox();
            this.toggleAssembleStats = new System.Windows.Forms.CheckBox();
            this.enterEventCheckBox = new System.Windows.Forms.CheckBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel11 = new System.Windows.Forms.Panel();
            this.panel12 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.battleBGListBox = new System.Windows.Forms.ComboBox();
            this.panel8 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.panel13 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.panel5 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.selectNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.adjustXNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.adjustYNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.adjustZNumericUpDown)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel12.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel13.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // emuPathLabel
            // 
            this.emuPathLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.emuPathLabel.Location = new System.Drawing.Point(2, 21);
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
            this.changeEmuButton.FlatAppearance.BorderSize = 0;
            this.changeEmuButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.changeEmuButton.Location = new System.Drawing.Point(645, 21);
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
            this.eventListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.eventListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.eventListBox.FormattingEnabled = true;
            this.eventListBox.IntegralHeight = false;
            this.eventListBox.Location = new System.Drawing.Point(2, 21);
            this.eventListBox.Name = "eventListBox";
            this.eventListBox.Size = new System.Drawing.Size(560, 277);
            this.eventListBox.TabIndex = 2;
            this.eventListBox.SelectedIndexChanged += new System.EventHandler(this.eventListBox_SelectedIndexChanged);
            // 
            // launchButton
            // 
            this.launchButton.BackColor = System.Drawing.SystemColors.Window;
            this.launchButton.FlatAppearance.BorderSize = 0;
            this.launchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.launchButton.Location = new System.Drawing.Point(2, 2);
            this.launchButton.Name = "launchButton";
            this.launchButton.Size = new System.Drawing.Size(70, 17);
            this.launchButton.TabIndex = 3;
            this.launchButton.Text = "LAUNCH";
            this.launchButton.UseCompatibleTextRendering = true;
            this.launchButton.UseVisualStyleBackColor = false;
            this.launchButton.Click += new System.EventHandler(this.launchButton_Click);
            // 
            // romLabel
            // 
            this.romLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.romLabel.Location = new System.Drawing.Point(2, 39);
            this.romLabel.Name = "romLabel";
            this.romLabel.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.romLabel.Size = new System.Drawing.Size(128, 17);
            this.romLabel.TabIndex = 4;
            this.romLabel.Text = "Rom Path:";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label1.Location = new System.Drawing.Point(2, 2);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label1.Size = new System.Drawing.Size(72, 17);
            this.label1.TabIndex = 6;
            // 
            // selectNumericUpDown
            // 
            this.selectNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.selectNumericUpDown.Location = new System.Drawing.Point(75, 2);
            this.selectNumericUpDown.Maximum = new decimal(new int[] {
            4095,
            0,
            0,
            0});
            this.selectNumericUpDown.Name = "selectNumericUpDown";
            this.selectNumericUpDown.Size = new System.Drawing.Size(71, 17);
            this.selectNumericUpDown.TabIndex = 5;
            this.selectNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.selectNumericUpDown.ValueChanged += new System.EventHandler(this.selectNumericUpDown_ValueChanged);
            // 
            // cancelButton
            // 
            this.cancelButton.BackColor = System.Drawing.SystemColors.Window;
            this.cancelButton.FlatAppearance.BorderSize = 0;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.Location = new System.Drawing.Point(74, 2);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(71, 17);
            this.cancelButton.TabIndex = 7;
            this.cancelButton.Text = "CANCEL";
            this.cancelButton.UseCompatibleTextRendering = true;
            this.cancelButton.UseVisualStyleBackColor = false;
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
            this.emuPathTextBox.Size = new System.Drawing.Size(505, 14);
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
            this.romPathTextBox.Size = new System.Drawing.Size(505, 14);
            this.romPathTextBox.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label2.Location = new System.Drawing.Point(2, 2);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label2.Size = new System.Drawing.Size(560, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "SELECT ENTRANCE TO PREVIEW";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label3.Location = new System.Drawing.Point(2, 2);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label3.Size = new System.Drawing.Size(143, 17);
            this.label3.TabIndex = 15;
            this.label3.Text = "Assemble for preview:";
            // 
            // argsTextBox
            // 
            this.argsTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.argsTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.argsTextBox.Location = new System.Drawing.Point(4, 2);
            this.argsTextBox.Name = "argsTextBox";
            this.argsTextBox.Size = new System.Drawing.Size(505, 14);
            this.argsTextBox.TabIndex = 17;
            // 
            // linkLabel1
            // 
            this.linkLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.linkLabel1.Location = new System.Drawing.Point(2, 75);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.linkLabel1.Size = new System.Drawing.Size(128, 17);
            this.linkLabel1.TabIndex = 19;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Tag = "";
            this.linkLabel1.Text = "ZSNESW Cmd-Line Args:";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.Control;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label4.Location = new System.Drawing.Point(2, 2);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label4.Size = new System.Drawing.Size(143, 17);
            this.label4.TabIndex = 20;
            this.label4.Text = "BATTLEFIELD";
            // 
            // adjustXNumericUpDown
            // 
            this.adjustXNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.adjustXNumericUpDown.Location = new System.Drawing.Point(75, 21);
            this.adjustXNumericUpDown.Maximum = new decimal(new int[] {
            63,
            0,
            0,
            0});
            this.adjustXNumericUpDown.Name = "adjustXNumericUpDown";
            this.adjustXNumericUpDown.Size = new System.Drawing.Size(71, 17);
            this.adjustXNumericUpDown.TabIndex = 21;
            this.adjustXNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // adjustYNumericUpDown
            // 
            this.adjustYNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.adjustYNumericUpDown.Location = new System.Drawing.Point(75, 39);
            this.adjustYNumericUpDown.Maximum = new decimal(new int[] {
            127,
            0,
            0,
            0});
            this.adjustYNumericUpDown.Name = "adjustYNumericUpDown";
            this.adjustYNumericUpDown.Size = new System.Drawing.Size(71, 17);
            this.adjustYNumericUpDown.TabIndex = 22;
            this.adjustYNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // adjustZNumericUpDown
            // 
            this.adjustZNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.adjustZNumericUpDown.Location = new System.Drawing.Point(75, 57);
            this.adjustZNumericUpDown.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.adjustZNumericUpDown.Name = "adjustZNumericUpDown";
            this.adjustZNumericUpDown.Size = new System.Drawing.Size(71, 17);
            this.adjustZNumericUpDown.TabIndex = 23;
            this.adjustZNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label5.Location = new System.Drawing.Point(2, 21);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label5.Size = new System.Drawing.Size(72, 17);
            this.label5.TabIndex = 24;
            this.label5.Text = "X coord";
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label6.Location = new System.Drawing.Point(2, 39);
            this.label6.Name = "label6";
            this.label6.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label6.Size = new System.Drawing.Size(72, 17);
            this.label6.TabIndex = 25;
            this.label6.Text = "Y coord";
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label7.Location = new System.Drawing.Point(2, 57);
            this.label7.Name = "label7";
            this.label7.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label7.Size = new System.Drawing.Size(72, 17);
            this.label7.TabIndex = 26;
            this.label7.Text = "Z coord";
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox1.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox1.BackColor = System.Drawing.SystemColors.Control;
            this.checkBox1.FlatAppearance.BorderSize = 0;
            this.checkBox1.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(168)))), ((int)(((byte)(168)))));
            this.checkBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox1.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.checkBox1.Location = new System.Drawing.Point(645, 39);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(70, 17);
            this.checkBox1.TabIndex = 27;
            this.checkBox1.Text = "DYNAMIC";
            this.checkBox1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBox1.UseCompatibleTextRendering = true;
            this.checkBox1.UseVisualStyleBackColor = false;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.SystemColors.Window;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(168)))), ((int)(((byte)(168)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(645, 75);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(70, 17);
            this.button1.TabIndex = 28;
            this.button1.Text = "DEFAULT";
            this.button1.UseCompatibleTextRendering = true;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.SystemColors.Window;
            this.panel2.Controls.Add(this.emuPathTextBox);
            this.panel2.Location = new System.Drawing.Point(131, 21);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(513, 17);
            this.panel2.TabIndex = 29;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.Window;
            this.panel1.Controls.Add(this.romPathTextBox);
            this.panel1.Location = new System.Drawing.Point(131, 39);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(513, 17);
            this.panel1.TabIndex = 30;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.SystemColors.Window;
            this.panel3.Controls.Add(this.argsTextBox);
            this.panel3.Location = new System.Drawing.Point(131, 75);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(513, 17);
            this.panel3.TabIndex = 31;
            // 
            // toggleAssembleLevels
            // 
            this.toggleAssembleLevels.Appearance = System.Windows.Forms.Appearance.Button;
            this.toggleAssembleLevels.BackColor = System.Drawing.SystemColors.Control;
            this.toggleAssembleLevels.FlatAppearance.BorderSize = 0;
            this.toggleAssembleLevels.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(168)))), ((int)(((byte)(168)))));
            this.toggleAssembleLevels.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.toggleAssembleLevels.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.toggleAssembleLevels.Location = new System.Drawing.Point(2, 39);
            this.toggleAssembleLevels.Name = "toggleAssembleLevels";
            this.toggleAssembleLevels.Size = new System.Drawing.Size(143, 17);
            this.toggleAssembleLevels.TabIndex = 27;
            this.toggleAssembleLevels.Text = "Levels";
            this.toggleAssembleLevels.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toggleAssembleLevels.UseCompatibleTextRendering = true;
            this.toggleAssembleLevels.UseVisualStyleBackColor = false;
            this.toggleAssembleLevels.CheckedChanged += new System.EventHandler(this.toggleAssembleLevels_Click);
            // 
            // toggleAssembleScripts
            // 
            this.toggleAssembleScripts.Appearance = System.Windows.Forms.Appearance.Button;
            this.toggleAssembleScripts.BackColor = System.Drawing.SystemColors.Control;
            this.toggleAssembleScripts.FlatAppearance.BorderSize = 0;
            this.toggleAssembleScripts.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(168)))), ((int)(((byte)(168)))));
            this.toggleAssembleScripts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.toggleAssembleScripts.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.toggleAssembleScripts.Location = new System.Drawing.Point(2, 57);
            this.toggleAssembleScripts.Name = "toggleAssembleScripts";
            this.toggleAssembleScripts.Size = new System.Drawing.Size(143, 17);
            this.toggleAssembleScripts.TabIndex = 27;
            this.toggleAssembleScripts.Text = "Scripts";
            this.toggleAssembleScripts.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toggleAssembleScripts.UseCompatibleTextRendering = true;
            this.toggleAssembleScripts.UseVisualStyleBackColor = false;
            this.toggleAssembleScripts.CheckedChanged += new System.EventHandler(this.toggleAssembleScripts_Click);
            // 
            // toggleAssembleSprites
            // 
            this.toggleAssembleSprites.Appearance = System.Windows.Forms.Appearance.Button;
            this.toggleAssembleSprites.BackColor = System.Drawing.SystemColors.Control;
            this.toggleAssembleSprites.FlatAppearance.BorderSize = 0;
            this.toggleAssembleSprites.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(168)))), ((int)(((byte)(168)))));
            this.toggleAssembleSprites.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.toggleAssembleSprites.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.toggleAssembleSprites.Location = new System.Drawing.Point(2, 75);
            this.toggleAssembleSprites.Name = "toggleAssembleSprites";
            this.toggleAssembleSprites.Size = new System.Drawing.Size(143, 17);
            this.toggleAssembleSprites.TabIndex = 27;
            this.toggleAssembleSprites.Text = "Sprites";
            this.toggleAssembleSprites.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toggleAssembleSprites.UseCompatibleTextRendering = true;
            this.toggleAssembleSprites.UseVisualStyleBackColor = false;
            this.toggleAssembleSprites.CheckedChanged += new System.EventHandler(this.toggleAssembleSprites_Click);
            // 
            // toggleAssembleStats
            // 
            this.toggleAssembleStats.Appearance = System.Windows.Forms.Appearance.Button;
            this.toggleAssembleStats.BackColor = System.Drawing.SystemColors.Control;
            this.toggleAssembleStats.FlatAppearance.BorderSize = 0;
            this.toggleAssembleStats.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(168)))), ((int)(((byte)(168)))));
            this.toggleAssembleStats.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.toggleAssembleStats.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.toggleAssembleStats.Location = new System.Drawing.Point(2, 21);
            this.toggleAssembleStats.Name = "toggleAssembleStats";
            this.toggleAssembleStats.Size = new System.Drawing.Size(143, 17);
            this.toggleAssembleStats.TabIndex = 27;
            this.toggleAssembleStats.Text = "Stats";
            this.toggleAssembleStats.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toggleAssembleStats.UseCompatibleTextRendering = true;
            this.toggleAssembleStats.UseVisualStyleBackColor = false;
            this.toggleAssembleStats.CheckedChanged += new System.EventHandler(this.toggleAssembleStats_Click);
            // 
            // enterEventCheckBox
            // 
            this.enterEventCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.enterEventCheckBox.BackColor = System.Drawing.SystemColors.Control;
            this.enterEventCheckBox.FlatAppearance.BorderSize = 0;
            this.enterEventCheckBox.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(168)))), ((int)(((byte)(168)))));
            this.enterEventCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.enterEventCheckBox.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.enterEventCheckBox.Location = new System.Drawing.Point(2, 93);
            this.enterEventCheckBox.Name = "enterEventCheckBox";
            this.enterEventCheckBox.Size = new System.Drawing.Size(143, 17);
            this.enterEventCheckBox.TabIndex = 32;
            this.enterEventCheckBox.Tag = "Replaces Event Script 0 with a Generated Event";
            this.enterEventCheckBox.Text = "Enter Event";
            this.enterEventCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.enterEventCheckBox.UseCompatibleTextRendering = true;
            this.enterEventCheckBox.UseVisualStyleBackColor = false;
            this.enterEventCheckBox.CheckedChanged += new System.EventHandler(this.enterEventCheckBox_CheckedChanged);
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BackgroundImage = global::LAZYSHELL.Properties.Resources._bg;
            this.panel4.Controls.Add(this.panel11);
            this.panel4.Controls.Add(this.panel12);
            this.panel4.Controls.Add(this.panel7);
            this.panel4.Controls.Add(this.panel9);
            this.panel4.Controls.Add(this.panel8);
            this.panel4.Controls.Add(this.panel6);
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Location = new System.Drawing.Point(2, 2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(730, 412);
            this.panel4.TabIndex = 34;
            // 
            // panel11
            // 
            this.panel11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel11.Controls.Add(this.label1);
            this.panel11.Controls.Add(this.selectNumericUpDown);
            this.panel11.Location = new System.Drawing.Point(576, 106);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(147, 21);
            this.panel11.TabIndex = 37;
            // 
            // panel12
            // 
            this.panel12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel12.Controls.Add(this.label3);
            this.panel12.Controls.Add(this.toggleAssembleLevels);
            this.panel12.Controls.Add(this.toggleAssembleStats);
            this.panel12.Controls.Add(this.toggleAssembleSprites);
            this.panel12.Controls.Add(this.toggleAssembleScripts);
            this.panel12.Controls.Add(this.enterEventCheckBox);
            this.panel12.Location = new System.Drawing.Point(576, 261);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(147, 112);
            this.panel12.TabIndex = 35;
            // 
            // panel7
            // 
            this.panel7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel7.Controls.Add(this.launchButton);
            this.panel7.Controls.Add(this.cancelButton);
            this.panel7.Location = new System.Drawing.Point(576, 385);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(147, 21);
            this.panel7.TabIndex = 35;
            // 
            // panel9
            // 
            this.panel9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel9.Controls.Add(this.label4);
            this.panel9.Controls.Add(this.panel10);
            this.panel9.Enabled = false;
            this.panel9.Location = new System.Drawing.Point(576, 215);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(147, 40);
            this.panel9.TabIndex = 37;
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.battleBGListBox);
            this.panel10.Location = new System.Drawing.Point(2, 21);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(144, 17);
            this.panel10.TabIndex = 22;
            // 
            // battleBGListBox
            // 
            this.battleBGListBox.DropDownHeight = 392;
            this.battleBGListBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.battleBGListBox.DropDownWidth = 220;
            this.battleBGListBox.FormattingEnabled = true;
            this.battleBGListBox.IntegralHeight = false;
            this.battleBGListBox.Items.AddRange(new object[] {
            "Forest Maze",
            "Forest Maze: Bowyer\'s Pad",
            "Bean Valley: Beanstalks",
            "Sunken Ship: King Calamari\'s Cellar",
            "Sunken Ship",
            "Moleville Mines",
            "___mines",
            "Bowser\'s Keep",
            "Barrel Volcano: Czar Dragon\'s Pad",
            "Grasslands",
            "Mountains",
            "Mushroom Kingdom House",
            "Booster Tower",
            "Mushroom Kingdom Castle",
            "Kero Sewers: Underwater",
            "Mushroom Kingdom Castle",
            "Bowser\'s Keep Turret: Exor",
            "Booster Tower: Balcony",
            "Smithy Factory: Count Down\'s Pad",
            "Smithy Factory",
            "Barrel Volcano",
            "Kero Sewers",
            "Nimbus Castle",
            "Nimbus Castle: Birdo\'s Room",
            "Nimbus Land",
            "Underground",
            "___uses Mushroom Kingdom tiles",
            "___forested area with unique trees",
            "Mushroom Kingdom",
            "Bowser\'s Keep: Chandeliers",
            "Forest Maze: Path to Bowyer",
            "Level Up foreground",
            "Level Up background",
            "Grasslands",
            "___sea enclave",
            "Marrymore Chapel Sanctuary",
            "Star Hill",
            "Seaside Town Beach",
            "Sea",
            "Blade: Axem Rangers",
            "Smithy Factory: Domino & Cloaker\'s Pad",
            "Bean Valley: Grasslands",
            "Belome Temple",
            "Land\'s End Desert",
            "Factory Grounds: Smithy\'s Pad",
            "Smithy\'s Final Form",
            "Jinx\'s Dojo",
            "Culex",
            "Factory Grounds",
            "Bean Valley: Pipe Room",
            "_____",
            "_____",
            "_____",
            "_____",
            "_____",
            "_____",
            "_____",
            "_____",
            "_____",
            "_____",
            "_____",
            "_____",
            "_____",
            "_____"});
            this.battleBGListBox.Location = new System.Drawing.Point(-2, -2);
            this.battleBGListBox.Name = "battleBGListBox";
            this.battleBGListBox.Size = new System.Drawing.Size(148, 21);
            this.battleBGListBox.TabIndex = 21;
            // 
            // panel8
            // 
            this.panel8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel8.Controls.Add(this.adjustXNumericUpDown);
            this.panel8.Controls.Add(this.label5);
            this.panel8.Controls.Add(this.label9);
            this.panel8.Controls.Add(this.label6);
            this.panel8.Controls.Add(this.adjustYNumericUpDown);
            this.panel8.Controls.Add(this.adjustZNumericUpDown);
            this.panel8.Controls.Add(this.label7);
            this.panel8.Location = new System.Drawing.Point(576, 133);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(147, 76);
            this.panel8.TabIndex = 36;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.SystemColors.Control;
            this.label9.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label9.Location = new System.Drawing.Point(2, 2);
            this.label9.Name = "label9";
            this.label9.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label9.Size = new System.Drawing.Size(143, 17);
            this.label9.TabIndex = 20;
            this.label9.Text = "MARIO COORDS";
            // 
            // panel6
            // 
            this.panel6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel6.Controls.Add(this.label8);
            this.panel6.Controls.Add(this.emuPathLabel);
            this.panel6.Controls.Add(this.changeEmuButton);
            this.panel6.Controls.Add(this.romLabel);
            this.panel6.Controls.Add(this.panel13);
            this.panel6.Controls.Add(this.panel3);
            this.panel6.Controls.Add(this.checkBox1);
            this.panel6.Controls.Add(this.button2);
            this.panel6.Controls.Add(this.button1);
            this.panel6.Controls.Add(this.panel2);
            this.panel6.Controls.Add(this.linkLabel2);
            this.panel6.Controls.Add(this.linkLabel1);
            this.panel6.Controls.Add(this.panel1);
            this.panel6.Location = new System.Drawing.Point(6, 6);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(717, 94);
            this.panel6.TabIndex = 35;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.BackColor = System.Drawing.SystemColors.Control;
            this.label8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label8.Location = new System.Drawing.Point(2, 2);
            this.label8.Name = "label8";
            this.label8.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label8.Size = new System.Drawing.Size(713, 17);
            this.label8.TabIndex = 10;
            this.label8.Text = "DIRECTORIES";
            // 
            // panel13
            // 
            this.panel13.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel13.BackColor = System.Drawing.SystemColors.Window;
            this.panel13.Controls.Add(this.textBox1);
            this.panel13.Location = new System.Drawing.Point(131, 57);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(513, 17);
            this.panel13.TabIndex = 31;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Location = new System.Drawing.Point(4, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(505, 14);
            this.textBox1.TabIndex = 17;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.BackColor = System.Drawing.SystemColors.Window;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(168)))), ((int)(((byte)(168)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(645, 57);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(70, 17);
            this.button2.TabIndex = 28;
            this.button2.Text = "DEFAULT";
            this.button2.UseCompatibleTextRendering = true;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // linkLabel2
            // 
            this.linkLabel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.linkLabel2.Location = new System.Drawing.Point(2, 57);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.linkLabel2.Size = new System.Drawing.Size(128, 17);
            this.linkLabel2.TabIndex = 19;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Tag = "";
            this.linkLabel2.Text = "SNES9X Cmd-Line Args:";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.Controls.Add(this.label2);
            this.panel5.Controls.Add(this.eventListBox);
            this.panel5.Location = new System.Drawing.Point(6, 106);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(564, 300);
            this.panel5.TabIndex = 0;
            // 
            // Previewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlText;
            this.ClientSize = new System.Drawing.Size(734, 416);
            this.Controls.Add(this.panel4);
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
            this.panel4.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            this.panel12.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel13.ResumeLayout(false);
            this.panel13.PerformLayout();
            this.panel5.ResumeLayout(false);
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox argsTextBox;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown adjustXNumericUpDown;
        private System.Windows.Forms.NumericUpDown adjustYNumericUpDown;
        private System.Windows.Forms.NumericUpDown adjustZNumericUpDown;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.CheckBox toggleAssembleScripts;
        private System.Windows.Forms.CheckBox toggleAssembleSprites;
        private System.Windows.Forms.CheckBox toggleAssembleStats;
        private System.Windows.Forms.CheckBox toggleAssembleLevels;
        private System.Windows.Forms.CheckBox enterEventCheckBox;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.ComboBox battleBGListBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.LinkLabel linkLabel2;
    }
}