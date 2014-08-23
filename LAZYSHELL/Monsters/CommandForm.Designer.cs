namespace LAZYSHELL.Monsters
{
    partial class CommandForm
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.listBoxCommands = new System.Windows.Forms.ToolStripComboBox();
            this.panelCommand = new LAZYSHELL.Controls.NewPanel();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.panelAttack = new System.Windows.Forms.GroupBox();
            this.panelAttackC = new System.Windows.Forms.Panel();
            this.nameC = new System.Windows.Forms.ComboBox();
            this.numC = new System.Windows.Forms.NumericUpDown();
            this.doNothingC = new System.Windows.Forms.CheckBox();
            this.panelAttackB = new System.Windows.Forms.Panel();
            this.nameB = new System.Windows.Forms.ComboBox();
            this.numB = new System.Windows.Forms.NumericUpDown();
            this.doNothingB = new System.Windows.Forms.CheckBox();
            this.panelAttackA = new System.Windows.Forms.Panel();
            this.nameA = new System.Windows.Forms.ComboBox();
            this.doNothingA = new System.Windows.Forms.CheckBox();
            this.numA = new System.Windows.Forms.NumericUpDown();
            this.panelMemory = new System.Windows.Forms.GroupBox();
            this.panelMemoryC = new System.Windows.Forms.Panel();
            this.labelMemoryC = new System.Windows.Forms.Label();
            this.panelBits = new System.Windows.Forms.Panel();
            this.bit0 = new System.Windows.Forms.CheckBox();
            this.bit7 = new System.Windows.Forms.CheckBox();
            this.bit4 = new System.Windows.Forms.CheckBox();
            this.bit3 = new System.Windows.Forms.CheckBox();
            this.bit2 = new System.Windows.Forms.CheckBox();
            this.bit6 = new System.Windows.Forms.CheckBox();
            this.bit5 = new System.Windows.Forms.CheckBox();
            this.bit1 = new System.Windows.Forms.CheckBox();
            this.panelMemoryB = new System.Windows.Forms.Panel();
            this.labelMemoryB = new System.Windows.Forms.Label();
            this.comparison = new System.Windows.Forms.NumericUpDown();
            this.panelMemoryA = new System.Windows.Forms.Panel();
            this.labelMemoryA = new System.Windows.Forms.Label();
            this.memory = new System.Windows.Forms.NumericUpDown();
            this.panelTarget = new System.Windows.Forms.GroupBox();
            this.effects = new System.Windows.Forms.CheckedListBox();
            this.panelTargetB = new System.Windows.Forms.Panel();
            this.labelTargetB = new System.Windows.Forms.Label();
            this.targetNum = new System.Windows.Forms.NumericUpDown();
            this.panelTargetA = new System.Windows.Forms.Panel();
            this.target = new System.Windows.Forms.ComboBox();
            this.labelTargetA = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.panelCommand.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.panelAttack.SuspendLayout();
            this.panelAttackC.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numC)).BeginInit();
            this.panelAttackB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numB)).BeginInit();
            this.panelAttackA.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numA)).BeginInit();
            this.panelMemory.SuspendLayout();
            this.panelMemoryC.SuspendLayout();
            this.panelBits.SuspendLayout();
            this.panelMemoryB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comparison)).BeginInit();
            this.panelMemoryA.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memory)).BeginInit();
            this.panelTarget.SuspendLayout();
            this.panelTargetB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.targetNum)).BeginInit();
            this.panelTargetA.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.listBoxCommands});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(262, 25);
            this.toolStrip1.TabIndex = 8;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(96, 22);
            this.toolStripLabel1.Text = "Select command";
            // 
            // listBoxCommands
            // 
            this.listBoxCommands.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.listBoxCommands.Items.AddRange(new object[] {
            "Command disable",
            "Command enable",
            "Do 1 attack",
            "Do 1 of 3 attacks",
            "Do 1 of 3 spells",
            "Do 1 spell",
            "Exit battle",
            "Memory = random # <",
            "If attack phase =",
            "If attacked",
            "If attacked by command",
            "If attacked by element",
            "If attacked by item",
            "If attacked by spell",
            "If HP is below",
            "If in formation",
            "If memory bits clear",
            "If memory bits set",
            "If memory greater than",
            "If memory less than",
            "If only one alive",
            "If target affected by",
            "If target alive",
            "If target dead",
            "If target HP is below",
            "If target not affected by",
            "Memory clear",
            "Memory clear bits",
            "Memory decrement",
            "Memory increment",
            "Memory set bits",
            "Run battle dialogue",
            "Run battle event",
            "Run object sequence",
            "Set items",
            "Target call",
            "Target disable",
            "Target enable",
            "Target null invincibility",
            "Target remove",
            "Target set",
            "Target set invicibility",
            "Wait 1 turn",
            "Wait 1 turn, return all"});
            this.listBoxCommands.Name = "listBoxCommands";
            this.listBoxCommands.Size = new System.Drawing.Size(150, 25);
            this.listBoxCommands.SelectedIndexChanged += new System.EventHandler(this.listBoxCommands_SelectedIndexChanged);
            // 
            // panelCommand
            // 
            this.panelCommand.AutoSize = true;
            this.panelCommand.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelCommand.Controls.Add(this.panelButtons);
            this.panelCommand.Controls.Add(this.panelAttack);
            this.panelCommand.Controls.Add(this.panelMemory);
            this.panelCommand.Controls.Add(this.panelTarget);
            this.panelCommand.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCommand.Location = new System.Drawing.Point(0, 25);
            this.panelCommand.Name = "panelCommand";
            this.panelCommand.Size = new System.Drawing.Size(262, 287);
            this.panelCommand.TabIndex = 9;
            // 
            // panelButtons
            // 
            this.panelButtons.Controls.Add(this.buttonCancel);
            this.panelButtons.Controls.Add(this.buttonOK);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelButtons.Location = new System.Drawing.Point(0, 252);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(262, 35);
            this.panelButtons.TabIndex = 9;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(134, 6);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(121, 23);
            this.buttonCancel.TabIndex = 0;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = false;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(7, 6);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(121, 23);
            this.buttonOK.TabIndex = 0;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = false;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // panelAttack
            // 
            this.panelAttack.AutoSize = true;
            this.panelAttack.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelAttack.Controls.Add(this.panelAttackC);
            this.panelAttack.Controls.Add(this.panelAttackB);
            this.panelAttack.Controls.Add(this.panelAttackA);
            this.panelAttack.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelAttack.Location = new System.Drawing.Point(0, 169);
            this.panelAttack.Name = "panelAttack";
            this.panelAttack.Size = new System.Drawing.Size(262, 83);
            this.panelAttack.TabIndex = 11;
            this.panelAttack.TabStop = false;
            this.panelAttack.Visible = false;
            // 
            // panelAttackC
            // 
            this.panelAttackC.Controls.Add(this.nameC);
            this.panelAttackC.Controls.Add(this.numC);
            this.panelAttackC.Controls.Add(this.doNothingC);
            this.panelAttackC.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelAttackC.Location = new System.Drawing.Point(3, 59);
            this.panelAttackC.Name = "panelAttackC";
            this.panelAttackC.Size = new System.Drawing.Size(256, 21);
            this.panelAttackC.TabIndex = 3;
            // 
            // nameC
            // 
            this.nameC.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.nameC.Cursor = System.Windows.Forms.Cursors.Default;
            this.nameC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.nameC.FormattingEnabled = true;
            this.nameC.Location = new System.Drawing.Point(0, 0);
            this.nameC.Name = "nameC";
            this.nameC.Size = new System.Drawing.Size(137, 21);
            this.nameC.TabIndex = 8;
            this.nameC.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.name_DrawItem);
            this.nameC.SelectedIndexChanged += new System.EventHandler(this.nameC_SelectedIndexChanged);
            // 
            // numC
            // 
            this.numC.Location = new System.Drawing.Point(137, 0);
            this.numC.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numC.Name = "numC";
            this.numC.Size = new System.Drawing.Size(53, 21);
            this.numC.TabIndex = 9;
            this.numC.ValueChanged += new System.EventHandler(this.numC_ValueChanged);
            // 
            // doNothingC
            // 
            this.doNothingC.Appearance = System.Windows.Forms.Appearance.Button;
            this.doNothingC.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.doNothingC.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.doNothingC.Location = new System.Drawing.Point(192, 0);
            this.doNothingC.Name = "doNothingC";
            this.doNothingC.Size = new System.Drawing.Size(64, 21);
            this.doNothingC.TabIndex = 10;
            this.doNothingC.Text = "NOTHING";
            this.doNothingC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.doNothingC.UseCompatibleTextRendering = true;
            this.doNothingC.UseVisualStyleBackColor = false;
            this.doNothingC.CheckedChanged += new System.EventHandler(this.doNothingC_CheckedChanged);
            // 
            // panelAttackB
            // 
            this.panelAttackB.Controls.Add(this.nameB);
            this.panelAttackB.Controls.Add(this.numB);
            this.panelAttackB.Controls.Add(this.doNothingB);
            this.panelAttackB.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelAttackB.Location = new System.Drawing.Point(3, 38);
            this.panelAttackB.Name = "panelAttackB";
            this.panelAttackB.Size = new System.Drawing.Size(256, 21);
            this.panelAttackB.TabIndex = 3;
            // 
            // nameB
            // 
            this.nameB.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.nameB.Cursor = System.Windows.Forms.Cursors.Default;
            this.nameB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.nameB.FormattingEnabled = true;
            this.nameB.Location = new System.Drawing.Point(0, 0);
            this.nameB.Name = "nameB";
            this.nameB.Size = new System.Drawing.Size(137, 21);
            this.nameB.TabIndex = 5;
            this.nameB.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.name_DrawItem);
            this.nameB.SelectedIndexChanged += new System.EventHandler(this.nameB_SelectedIndexChanged);
            // 
            // numB
            // 
            this.numB.Location = new System.Drawing.Point(137, 0);
            this.numB.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numB.Name = "numB";
            this.numB.Size = new System.Drawing.Size(53, 21);
            this.numB.TabIndex = 6;
            this.numB.ValueChanged += new System.EventHandler(this.numB_ValueChanged);
            // 
            // doNothingB
            // 
            this.doNothingB.Appearance = System.Windows.Forms.Appearance.Button;
            this.doNothingB.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.doNothingB.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.doNothingB.Location = new System.Drawing.Point(192, 0);
            this.doNothingB.Name = "doNothingB";
            this.doNothingB.Size = new System.Drawing.Size(64, 21);
            this.doNothingB.TabIndex = 7;
            this.doNothingB.Text = "NOTHING";
            this.doNothingB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.doNothingB.UseCompatibleTextRendering = true;
            this.doNothingB.UseVisualStyleBackColor = false;
            this.doNothingB.CheckedChanged += new System.EventHandler(this.doNothingB_CheckedChanged);
            // 
            // panelAttackA
            // 
            this.panelAttackA.Controls.Add(this.nameA);
            this.panelAttackA.Controls.Add(this.doNothingA);
            this.panelAttackA.Controls.Add(this.numA);
            this.panelAttackA.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelAttackA.Location = new System.Drawing.Point(3, 17);
            this.panelAttackA.Name = "panelAttackA";
            this.panelAttackA.Size = new System.Drawing.Size(256, 21);
            this.panelAttackA.TabIndex = 3;
            // 
            // nameA
            // 
            this.nameA.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.nameA.Cursor = System.Windows.Forms.Cursors.Default;
            this.nameA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.nameA.FormattingEnabled = true;
            this.nameA.Location = new System.Drawing.Point(0, 0);
            this.nameA.Name = "nameA";
            this.nameA.Size = new System.Drawing.Size(137, 21);
            this.nameA.TabIndex = 2;
            this.nameA.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.name_DrawItem);
            this.nameA.SelectedIndexChanged += new System.EventHandler(this.nameA_SelectedIndexChanged);
            // 
            // doNothingA
            // 
            this.doNothingA.Appearance = System.Windows.Forms.Appearance.Button;
            this.doNothingA.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.doNothingA.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.doNothingA.Location = new System.Drawing.Point(192, 0);
            this.doNothingA.Name = "doNothingA";
            this.doNothingA.Size = new System.Drawing.Size(64, 21);
            this.doNothingA.TabIndex = 4;
            this.doNothingA.Text = "NOTHING";
            this.doNothingA.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.doNothingA.UseCompatibleTextRendering = true;
            this.doNothingA.UseVisualStyleBackColor = false;
            this.doNothingA.CheckedChanged += new System.EventHandler(this.doNothingA_CheckedChanged);
            // 
            // numA
            // 
            this.numA.Location = new System.Drawing.Point(137, 0);
            this.numA.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numA.Name = "numA";
            this.numA.Size = new System.Drawing.Size(53, 21);
            this.numA.TabIndex = 3;
            this.numA.ValueChanged += new System.EventHandler(this.numA_ValueChanged);
            // 
            // panelMemory
            // 
            this.panelMemory.AutoSize = true;
            this.panelMemory.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelMemory.Controls.Add(this.panelMemoryC);
            this.panelMemory.Controls.Add(this.panelMemoryB);
            this.panelMemory.Controls.Add(this.panelMemoryA);
            this.panelMemory.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMemory.Location = new System.Drawing.Point(0, 84);
            this.panelMemory.Name = "panelMemory";
            this.panelMemory.Size = new System.Drawing.Size(262, 85);
            this.panelMemory.TabIndex = 10;
            this.panelMemory.TabStop = false;
            this.panelMemory.Visible = false;
            // 
            // panelMemoryC
            // 
            this.panelMemoryC.Controls.Add(this.labelMemoryC);
            this.panelMemoryC.Controls.Add(this.panelBits);
            this.panelMemoryC.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMemoryC.Location = new System.Drawing.Point(3, 61);
            this.panelMemoryC.Name = "panelMemoryC";
            this.panelMemoryC.Size = new System.Drawing.Size(256, 21);
            this.panelMemoryC.TabIndex = 3;
            // 
            // labelMemoryC
            // 
            this.labelMemoryC.AutoSize = true;
            this.labelMemoryC.Location = new System.Drawing.Point(3, 3);
            this.labelMemoryC.Name = "labelMemoryC";
            this.labelMemoryC.Size = new System.Drawing.Size(19, 13);
            this.labelMemoryC.TabIndex = 4;
            this.labelMemoryC.Text = "...";
            // 
            // panelBits
            // 
            this.panelBits.Controls.Add(this.bit0);
            this.panelBits.Controls.Add(this.bit7);
            this.panelBits.Controls.Add(this.bit4);
            this.panelBits.Controls.Add(this.bit3);
            this.panelBits.Controls.Add(this.bit2);
            this.panelBits.Controls.Add(this.bit6);
            this.panelBits.Controls.Add(this.bit5);
            this.panelBits.Controls.Add(this.bit1);
            this.panelBits.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelBits.Location = new System.Drawing.Point(135, 1);
            this.panelBits.Name = "panelBits";
            this.panelBits.Size = new System.Drawing.Size(122, 20);
            this.panelBits.TabIndex = 5;
            // 
            // bit0
            // 
            this.bit0.Appearance = System.Windows.Forms.Appearance.Button;
            this.bit0.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.bit0.Location = new System.Drawing.Point(1, 0);
            this.bit0.Name = "bit0";
            this.bit0.Size = new System.Drawing.Size(15, 20);
            this.bit0.TabIndex = 0;
            this.bit0.Text = "0";
            this.bit0.UseCompatibleTextRendering = true;
            this.bit0.UseVisualStyleBackColor = false;
            // 
            // bit7
            // 
            this.bit7.Appearance = System.Windows.Forms.Appearance.Button;
            this.bit7.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.bit7.Location = new System.Drawing.Point(106, 0);
            this.bit7.Name = "bit7";
            this.bit7.Size = new System.Drawing.Size(15, 20);
            this.bit7.TabIndex = 7;
            this.bit7.Text = "7";
            this.bit7.UseCompatibleTextRendering = true;
            this.bit7.UseVisualStyleBackColor = false;
            // 
            // bit4
            // 
            this.bit4.Appearance = System.Windows.Forms.Appearance.Button;
            this.bit4.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.bit4.Location = new System.Drawing.Point(61, 0);
            this.bit4.Name = "bit4";
            this.bit4.Size = new System.Drawing.Size(15, 20);
            this.bit4.TabIndex = 4;
            this.bit4.Text = "4";
            this.bit4.UseCompatibleTextRendering = true;
            this.bit4.UseVisualStyleBackColor = false;
            // 
            // bit3
            // 
            this.bit3.Appearance = System.Windows.Forms.Appearance.Button;
            this.bit3.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.bit3.Location = new System.Drawing.Point(46, 0);
            this.bit3.Name = "bit3";
            this.bit3.Size = new System.Drawing.Size(15, 20);
            this.bit3.TabIndex = 3;
            this.bit3.Text = "3";
            this.bit3.UseCompatibleTextRendering = true;
            this.bit3.UseVisualStyleBackColor = false;
            // 
            // bit2
            // 
            this.bit2.Appearance = System.Windows.Forms.Appearance.Button;
            this.bit2.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.bit2.Location = new System.Drawing.Point(31, 0);
            this.bit2.Name = "bit2";
            this.bit2.Size = new System.Drawing.Size(15, 20);
            this.bit2.TabIndex = 2;
            this.bit2.Text = "2";
            this.bit2.UseCompatibleTextRendering = true;
            this.bit2.UseVisualStyleBackColor = false;
            // 
            // bit6
            // 
            this.bit6.Appearance = System.Windows.Forms.Appearance.Button;
            this.bit6.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.bit6.Location = new System.Drawing.Point(91, 0);
            this.bit6.Name = "bit6";
            this.bit6.Size = new System.Drawing.Size(15, 20);
            this.bit6.TabIndex = 6;
            this.bit6.Text = "6";
            this.bit6.UseCompatibleTextRendering = true;
            this.bit6.UseVisualStyleBackColor = false;
            // 
            // bit5
            // 
            this.bit5.Appearance = System.Windows.Forms.Appearance.Button;
            this.bit5.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.bit5.Location = new System.Drawing.Point(76, 0);
            this.bit5.Name = "bit5";
            this.bit5.Size = new System.Drawing.Size(15, 20);
            this.bit5.TabIndex = 5;
            this.bit5.Text = "5";
            this.bit5.UseCompatibleTextRendering = true;
            this.bit5.UseVisualStyleBackColor = false;
            // 
            // bit1
            // 
            this.bit1.Appearance = System.Windows.Forms.Appearance.Button;
            this.bit1.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.bit1.Location = new System.Drawing.Point(16, 0);
            this.bit1.Name = "bit1";
            this.bit1.Size = new System.Drawing.Size(15, 20);
            this.bit1.TabIndex = 1;
            this.bit1.Text = "1";
            this.bit1.UseCompatibleTextRendering = true;
            this.bit1.UseVisualStyleBackColor = false;
            // 
            // panelMemoryB
            // 
            this.panelMemoryB.Controls.Add(this.labelMemoryB);
            this.panelMemoryB.Controls.Add(this.comparison);
            this.panelMemoryB.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMemoryB.Location = new System.Drawing.Point(3, 39);
            this.panelMemoryB.Name = "panelMemoryB";
            this.panelMemoryB.Size = new System.Drawing.Size(256, 22);
            this.panelMemoryB.TabIndex = 3;
            // 
            // labelMemoryB
            // 
            this.labelMemoryB.AutoSize = true;
            this.labelMemoryB.Location = new System.Drawing.Point(3, 3);
            this.labelMemoryB.Name = "labelMemoryB";
            this.labelMemoryB.Size = new System.Drawing.Size(19, 13);
            this.labelMemoryB.TabIndex = 2;
            this.labelMemoryB.Text = "...";
            // 
            // comparison
            // 
            this.comparison.Location = new System.Drawing.Point(136, 0);
            this.comparison.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.comparison.Name = "comparison";
            this.comparison.Size = new System.Drawing.Size(120, 21);
            this.comparison.TabIndex = 3;
            // 
            // panelMemoryA
            // 
            this.panelMemoryA.Controls.Add(this.labelMemoryA);
            this.panelMemoryA.Controls.Add(this.memory);
            this.panelMemoryA.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMemoryA.Location = new System.Drawing.Point(3, 17);
            this.panelMemoryA.Name = "panelMemoryA";
            this.panelMemoryA.Size = new System.Drawing.Size(256, 22);
            this.panelMemoryA.TabIndex = 3;
            // 
            // labelMemoryA
            // 
            this.labelMemoryA.AutoSize = true;
            this.labelMemoryA.Location = new System.Drawing.Point(3, 3);
            this.labelMemoryA.Name = "labelMemoryA";
            this.labelMemoryA.Size = new System.Drawing.Size(19, 13);
            this.labelMemoryA.TabIndex = 0;
            this.labelMemoryA.Text = "...";
            // 
            // memory
            // 
            this.memory.Hexadecimal = true;
            this.memory.Location = new System.Drawing.Point(136, 0);
            this.memory.Maximum = new decimal(new int[] {
            8314895,
            0,
            0,
            0});
            this.memory.Minimum = new decimal(new int[] {
            8314880,
            0,
            0,
            0});
            this.memory.Name = "memory";
            this.memory.Size = new System.Drawing.Size(120, 21);
            this.memory.TabIndex = 1;
            this.memory.Value = new decimal(new int[] {
            8314880,
            0,
            0,
            0});
            // 
            // panelTarget
            // 
            this.panelTarget.AutoSize = true;
            this.panelTarget.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelTarget.Controls.Add(this.effects);
            this.panelTarget.Controls.Add(this.panelTargetB);
            this.panelTarget.Controls.Add(this.panelTargetA);
            this.panelTarget.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTarget.Location = new System.Drawing.Point(0, 0);
            this.panelTarget.Name = "panelTarget";
            this.panelTarget.Size = new System.Drawing.Size(262, 84);
            this.panelTarget.TabIndex = 8;
            this.panelTarget.TabStop = false;
            this.panelTarget.Visible = false;
            // 
            // effects
            // 
            this.effects.CheckOnClick = true;
            this.effects.ColumnWidth = 120;
            this.effects.Dock = System.Windows.Forms.DockStyle.Top;
            this.effects.FormattingEnabled = true;
            this.effects.Location = new System.Drawing.Point(3, 61);
            this.effects.MultiColumn = true;
            this.effects.Name = "effects";
            this.effects.Size = new System.Drawing.Size(256, 20);
            this.effects.TabIndex = 5;
            // 
            // panelTargetB
            // 
            this.panelTargetB.Controls.Add(this.labelTargetB);
            this.panelTargetB.Controls.Add(this.targetNum);
            this.panelTargetB.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTargetB.Location = new System.Drawing.Point(3, 39);
            this.panelTargetB.Name = "panelTargetB";
            this.panelTargetB.Size = new System.Drawing.Size(256, 22);
            this.panelTargetB.TabIndex = 3;
            // 
            // labelTargetB
            // 
            this.labelTargetB.AutoSize = true;
            this.labelTargetB.Location = new System.Drawing.Point(3, 3);
            this.labelTargetB.Name = "labelTargetB";
            this.labelTargetB.Size = new System.Drawing.Size(19, 13);
            this.labelTargetB.TabIndex = 2;
            this.labelTargetB.Text = "...";
            // 
            // targetNum
            // 
            this.targetNum.Increment = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.targetNum.Location = new System.Drawing.Point(136, 0);
            this.targetNum.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.targetNum.Name = "targetNum";
            this.targetNum.Size = new System.Drawing.Size(120, 21);
            this.targetNum.TabIndex = 3;
            // 
            // panelTargetA
            // 
            this.panelTargetA.Controls.Add(this.target);
            this.panelTargetA.Controls.Add(this.labelTargetA);
            this.panelTargetA.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTargetA.Location = new System.Drawing.Point(3, 17);
            this.panelTargetA.Name = "panelTargetA";
            this.panelTargetA.Size = new System.Drawing.Size(256, 22);
            this.panelTargetA.TabIndex = 3;
            // 
            // target
            // 
            this.target.BackColor = System.Drawing.SystemColors.Window;
            this.target.Cursor = System.Windows.Forms.Cursors.Default;
            this.target.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.target.DropDownWidth = 150;
            this.target.FormattingEnabled = true;
            this.target.Location = new System.Drawing.Point(136, 0);
            this.target.Name = "target";
            this.target.Size = new System.Drawing.Size(120, 21);
            this.target.TabIndex = 1;
            // 
            // labelTargetA
            // 
            this.labelTargetA.AutoSize = true;
            this.labelTargetA.Location = new System.Drawing.Point(3, 3);
            this.labelTargetA.Name = "labelTargetA";
            this.labelTargetA.Size = new System.Drawing.Size(19, 13);
            this.labelTargetA.TabIndex = 0;
            this.labelTargetA.Text = "...";
            // 
            // CommandForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(262, 311);
            this.Controls.Add(this.panelCommand);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Location = new System.Drawing.Point(0, 0);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CommandForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "COMMAND";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panelCommand.ResumeLayout(false);
            this.panelCommand.PerformLayout();
            this.panelButtons.ResumeLayout(false);
            this.panelAttack.ResumeLayout(false);
            this.panelAttackC.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numC)).EndInit();
            this.panelAttackB.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numB)).EndInit();
            this.panelAttackA.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numA)).EndInit();
            this.panelMemory.ResumeLayout(false);
            this.panelMemoryC.ResumeLayout(false);
            this.panelMemoryC.PerformLayout();
            this.panelBits.ResumeLayout(false);
            this.panelMemoryB.ResumeLayout(false);
            this.panelMemoryB.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comparison)).EndInit();
            this.panelMemoryA.ResumeLayout(false);
            this.panelMemoryA.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memory)).EndInit();
            this.panelTarget.ResumeLayout(false);
            this.panelTargetB.ResumeLayout(false);
            this.panelTargetB.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.targetNum)).EndInit();
            this.panelTargetA.ResumeLayout(false);
            this.panelTargetA.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox listBoxCommands;
        private Controls.NewPanel panelCommand;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.GroupBox panelAttack;
        private System.Windows.Forms.Panel panelAttackC;
        private System.Windows.Forms.ComboBox nameC;
        private System.Windows.Forms.NumericUpDown numC;
        private System.Windows.Forms.CheckBox doNothingC;
        private System.Windows.Forms.Panel panelAttackB;
        private System.Windows.Forms.ComboBox nameB;
        private System.Windows.Forms.NumericUpDown numB;
        private System.Windows.Forms.CheckBox doNothingB;
        private System.Windows.Forms.Panel panelAttackA;
        private System.Windows.Forms.ComboBox nameA;
        private System.Windows.Forms.CheckBox doNothingA;
        private System.Windows.Forms.NumericUpDown numA;
        private System.Windows.Forms.GroupBox panelMemory;
        private System.Windows.Forms.Panel panelMemoryC;
        private System.Windows.Forms.Label labelMemoryC;
        private System.Windows.Forms.Panel panelBits;
        private System.Windows.Forms.CheckBox bit0;
        private System.Windows.Forms.CheckBox bit7;
        private System.Windows.Forms.CheckBox bit4;
        private System.Windows.Forms.CheckBox bit3;
        private System.Windows.Forms.CheckBox bit2;
        private System.Windows.Forms.CheckBox bit6;
        private System.Windows.Forms.CheckBox bit5;
        private System.Windows.Forms.CheckBox bit1;
        private System.Windows.Forms.Panel panelMemoryB;
        private System.Windows.Forms.Label labelMemoryB;
        private System.Windows.Forms.NumericUpDown comparison;
        private System.Windows.Forms.Panel panelMemoryA;
        private System.Windows.Forms.Label labelMemoryA;
        private System.Windows.Forms.NumericUpDown memory;
        private System.Windows.Forms.GroupBox panelTarget;
        private System.Windows.Forms.CheckedListBox effects;
        private System.Windows.Forms.Panel panelTargetB;
        private System.Windows.Forms.Label labelTargetB;
        private System.Windows.Forms.NumericUpDown targetNum;
        private System.Windows.Forms.Panel panelTargetA;
        private System.Windows.Forms.ComboBox target;
        private System.Windows.Forms.Label labelTargetA;
    }
}