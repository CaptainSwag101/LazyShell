namespace LAZYSHELL.EventScripts
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
            this.commands = new System.Windows.Forms.ComboBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.categories_aq = new System.Windows.Forms.ToolStripComboBox();
            this.categories_es = new System.Windows.Forms.ToolStripComboBox();
            this.actionButton = new System.Windows.Forms.ToolStripButton();
            this.panelCommand = new Controls.NewPanel();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.groupBoxC = new System.Windows.Forms.GroupBox();
            this.evtNumC2 = new System.Windows.Forms.NumericUpDown();
            this.labelEvtC2 = new System.Windows.Forms.Label();
            this.evtNumC1 = new System.Windows.Forms.NumericUpDown();
            this.labelEvtC1 = new System.Windows.Forms.Label();
            this.groupBoxB = new System.Windows.Forms.GroupBox();
            this.evtEffects = new System.Windows.Forms.CheckedListBox();
            this.groupBoxA = new System.Windows.Forms.GroupBox();
            this.panelEvtA3_4 = new System.Windows.Forms.Panel();
            this.evtNumA4 = new System.Windows.Forms.NumericUpDown();
            this.labelEvtA4 = new System.Windows.Forms.Label();
            this.evtNumA3 = new System.Windows.Forms.NumericUpDown();
            this.labelEvtA3 = new System.Windows.Forms.Label();
            this.panelEvtA2 = new System.Windows.Forms.Panel();
            this.evtNumA2 = new System.Windows.Forms.NumericUpDown();
            this.evtNameA2 = new System.Windows.Forms.ComboBox();
            this.labelEvtA2 = new System.Windows.Forms.Label();
            this.panelEvtA1 = new System.Windows.Forms.Panel();
            this.evtNumA1 = new System.Windows.Forms.NumericUpDown();
            this.evtNameA1 = new System.Windows.Forms.ComboBox();
            this.labelEvtA1 = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.panelCommand.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.groupBoxC.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.evtNumC2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.evtNumC1)).BeginInit();
            this.groupBoxB.SuspendLayout();
            this.groupBoxA.SuspendLayout();
            this.panelEvtA3_4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.evtNumA4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.evtNumA3)).BeginInit();
            this.panelEvtA2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.evtNumA2)).BeginInit();
            this.panelEvtA1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.evtNumA1)).BeginInit();
            this.SuspendLayout();
            // 
            // commands
            // 
            this.commands.Dock = System.Windows.Forms.DockStyle.Top;
            this.commands.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.commands.FormattingEnabled = true;
            this.commands.Location = new System.Drawing.Point(0, 25);
            this.commands.Name = "commands";
            this.commands.Size = new System.Drawing.Size(281, 21);
            this.commands.TabIndex = 3;
            this.commands.SelectedIndexChanged += new System.EventHandler(this.commands_SelectedIndexChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.categories_aq,
            this.categories_es,
            this.actionButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(281, 25);
            this.toolStrip1.TabIndex = 13;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(84, 22);
            this.toolStripLabel1.Text = "Select Category";
            // 
            // categories_aq
            // 
            this.categories_aq.Items.AddRange(new object[] {
            "Properties",
            "Palette",
            "Sequence/speed",
            "Animation routine",
            "Walk 1 step",
            "Walk {xx} steps",
            "Walk {xx} pixels",
            "Face direction",
            "Move to (x,y,z)",
            "Audio",
            "Memory",
            "Memory $700C",
            "Jump to",
            "Object memory",
            "Pause",
            "Return"});
            this.categories_aq.Name = "categories_aq";
            this.categories_aq.Size = new System.Drawing.Size(130, 25);
            this.categories_aq.Visible = false;
            this.categories_aq.SelectedIndexChanged += new System.EventHandler(this.categories_aq_SelectedIndexChanged);
            // 
            // categories_es
            // 
            this.categories_es.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.categories_es.Items.AddRange(new object[] {
            "Objects",
            "Joypad",
            "Party members",
            "Inventory",
            "Battle",
            "Levels",
            "Menus",
            "Dialogues",
            "Events",
            "Jump to",
            "Screen effects",
            "Audio",
            "Memory",
            "Memory $7000",
            "Pause script",
            "Return"});
            this.categories_es.Name = "categories_es";
            this.categories_es.Size = new System.Drawing.Size(130, 25);
            this.categories_es.SelectedIndexChanged += new System.EventHandler(this.categories_es_SelectedIndexChanged);
            // 
            // actionButton
            // 
            this.actionButton.Name = "actionButton";
            this.actionButton.Size = new System.Drawing.Size(50, 22);
            this.actionButton.Text = "ACTION";
            this.actionButton.Click += new System.EventHandler(this.actionButton_CheckedChanged);
            // 
            // panelCommand
            // 
            this.panelCommand.AutoSize = true;
            this.panelCommand.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelCommand.Controls.Add(this.panelButtons);
            this.panelCommand.Controls.Add(this.groupBoxC);
            this.panelCommand.Controls.Add(this.groupBoxB);
            this.panelCommand.Controls.Add(this.groupBoxA);
            this.panelCommand.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCommand.Location = new System.Drawing.Point(0, 46);
            this.panelCommand.Name = "panelCommand";
            this.panelCommand.Size = new System.Drawing.Size(281, 183);
            this.panelCommand.TabIndex = 14;
            // 
            // panelButtons
            // 
            this.panelButtons.Controls.Add(this.buttonCancel);
            this.panelButtons.Controls.Add(this.buttonOK);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelButtons.Location = new System.Drawing.Point(0, 154);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(281, 29);
            this.panelButtons.TabIndex = 16;
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(144, 3);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(135, 23);
            this.buttonCancel.TabIndex = 0;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = false;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.BackColor = System.Drawing.SystemColors.Control;
            this.buttonOK.Location = new System.Drawing.Point(3, 3);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(135, 23);
            this.buttonOK.TabIndex = 0;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = false;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // groupBoxC
            // 
            this.groupBoxC.Controls.Add(this.evtNumC2);
            this.groupBoxC.Controls.Add(this.labelEvtC2);
            this.groupBoxC.Controls.Add(this.evtNumC1);
            this.groupBoxC.Controls.Add(this.labelEvtC1);
            this.groupBoxC.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxC.Location = new System.Drawing.Point(0, 110);
            this.groupBoxC.Name = "groupBoxC";
            this.groupBoxC.Size = new System.Drawing.Size(281, 44);
            this.groupBoxC.TabIndex = 15;
            this.groupBoxC.TabStop = false;
            this.groupBoxC.Visible = false;
            // 
            // evtNumC2
            // 
            this.evtNumC2.Dock = System.Windows.Forms.DockStyle.Left;
            this.evtNumC2.Enabled = false;
            this.evtNumC2.Location = new System.Drawing.Point(226, 17);
            this.evtNumC2.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.evtNumC2.Name = "evtNumC2";
            this.evtNumC2.Size = new System.Drawing.Size(49, 21);
            this.evtNumC2.TabIndex = 3;
            // 
            // labelEvtC2
            // 
            this.labelEvtC2.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelEvtC2.Location = new System.Drawing.Point(134, 17);
            this.labelEvtC2.Name = "labelEvtC2";
            this.labelEvtC2.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.labelEvtC2.Size = new System.Drawing.Size(92, 24);
            this.labelEvtC2.TabIndex = 2;
            this.labelEvtC2.Text = "...";
            this.labelEvtC2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // evtNumC1
            // 
            this.evtNumC1.Dock = System.Windows.Forms.DockStyle.Left;
            this.evtNumC1.Enabled = false;
            this.evtNumC1.Location = new System.Drawing.Point(85, 17);
            this.evtNumC1.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.evtNumC1.Name = "evtNumC1";
            this.evtNumC1.Size = new System.Drawing.Size(49, 21);
            this.evtNumC1.TabIndex = 1;
            // 
            // labelEvtC1
            // 
            this.labelEvtC1.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelEvtC1.Location = new System.Drawing.Point(3, 17);
            this.labelEvtC1.Name = "labelEvtC1";
            this.labelEvtC1.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.labelEvtC1.Size = new System.Drawing.Size(82, 24);
            this.labelEvtC1.TabIndex = 0;
            this.labelEvtC1.Text = "...";
            this.labelEvtC1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBoxB
            // 
            this.groupBoxB.AutoSize = true;
            this.groupBoxB.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBoxB.Controls.Add(this.evtEffects);
            this.groupBoxB.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxB.Location = new System.Drawing.Point(0, 86);
            this.groupBoxB.Name = "groupBoxB";
            this.groupBoxB.Size = new System.Drawing.Size(281, 24);
            this.groupBoxB.TabIndex = 14;
            this.groupBoxB.TabStop = false;
            this.groupBoxB.Visible = false;
            // 
            // evtEffects
            // 
            this.evtEffects.CheckOnClick = true;
            this.evtEffects.ColumnWidth = 132;
            this.evtEffects.Dock = System.Windows.Forms.DockStyle.Top;
            this.evtEffects.Enabled = false;
            this.evtEffects.FormattingEnabled = true;
            this.evtEffects.Items.AddRange(new object[] {
            "..."});
            this.evtEffects.Location = new System.Drawing.Point(3, 17);
            this.evtEffects.MultiColumn = true;
            this.evtEffects.Name = "evtEffects";
            this.evtEffects.Size = new System.Drawing.Size(275, 4);
            this.evtEffects.TabIndex = 0;
            this.evtEffects.SelectedIndexChanged += new System.EventHandler(this.evtEffects_SelectedIndexChanged);
            // 
            // groupBoxA
            // 
            this.groupBoxA.AutoSize = true;
            this.groupBoxA.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBoxA.Controls.Add(this.panelEvtA3_4);
            this.groupBoxA.Controls.Add(this.panelEvtA2);
            this.groupBoxA.Controls.Add(this.panelEvtA1);
            this.groupBoxA.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxA.Location = new System.Drawing.Point(0, 0);
            this.groupBoxA.Name = "groupBoxA";
            this.groupBoxA.Padding = new System.Windows.Forms.Padding(3, 3, 3, 6);
            this.groupBoxA.Size = new System.Drawing.Size(281, 86);
            this.groupBoxA.TabIndex = 13;
            this.groupBoxA.TabStop = false;
            this.groupBoxA.Visible = false;
            // 
            // panelEvtA3_4
            // 
            this.panelEvtA3_4.Controls.Add(this.evtNumA4);
            this.panelEvtA3_4.Controls.Add(this.labelEvtA4);
            this.panelEvtA3_4.Controls.Add(this.evtNumA3);
            this.panelEvtA3_4.Controls.Add(this.labelEvtA3);
            this.panelEvtA3_4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEvtA3_4.Location = new System.Drawing.Point(3, 59);
            this.panelEvtA3_4.Name = "panelEvtA3_4";
            this.panelEvtA3_4.Size = new System.Drawing.Size(275, 21);
            this.panelEvtA3_4.TabIndex = 5;
            this.panelEvtA3_4.Visible = false;
            // 
            // evtNumA4
            // 
            this.evtNumA4.Dock = System.Windows.Forms.DockStyle.Left;
            this.evtNumA4.Enabled = false;
            this.evtNumA4.Location = new System.Drawing.Point(223, 0);
            this.evtNumA4.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.evtNumA4.Name = "evtNumA4";
            this.evtNumA4.Size = new System.Drawing.Size(49, 21);
            this.evtNumA4.TabIndex = 9;
            // 
            // labelEvtA4
            // 
            this.labelEvtA4.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelEvtA4.Location = new System.Drawing.Point(131, 0);
            this.labelEvtA4.Name = "labelEvtA4";
            this.labelEvtA4.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.labelEvtA4.Size = new System.Drawing.Size(92, 21);
            this.labelEvtA4.TabIndex = 8;
            this.labelEvtA4.Text = "...";
            this.labelEvtA4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // evtNumA3
            // 
            this.evtNumA3.Dock = System.Windows.Forms.DockStyle.Left;
            this.evtNumA3.Enabled = false;
            this.evtNumA3.Location = new System.Drawing.Point(82, 0);
            this.evtNumA3.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.evtNumA3.Name = "evtNumA3";
            this.evtNumA3.Size = new System.Drawing.Size(49, 21);
            this.evtNumA3.TabIndex = 7;
            // 
            // labelEvtA3
            // 
            this.labelEvtA3.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelEvtA3.Location = new System.Drawing.Point(0, 0);
            this.labelEvtA3.Name = "labelEvtA3";
            this.labelEvtA3.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.labelEvtA3.Size = new System.Drawing.Size(82, 21);
            this.labelEvtA3.TabIndex = 6;
            this.labelEvtA3.Text = "...";
            this.labelEvtA3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelEvtA2
            // 
            this.panelEvtA2.Controls.Add(this.evtNumA2);
            this.panelEvtA2.Controls.Add(this.evtNameA2);
            this.panelEvtA2.Controls.Add(this.labelEvtA2);
            this.panelEvtA2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEvtA2.Location = new System.Drawing.Point(3, 38);
            this.panelEvtA2.Name = "panelEvtA2";
            this.panelEvtA2.Size = new System.Drawing.Size(275, 21);
            this.panelEvtA2.TabIndex = 5;
            this.panelEvtA2.Visible = false;
            // 
            // evtNumA2
            // 
            this.evtNumA2.Dock = System.Windows.Forms.DockStyle.Left;
            this.evtNumA2.Enabled = false;
            this.evtNumA2.Location = new System.Drawing.Point(223, 0);
            this.evtNumA2.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.evtNumA2.Name = "evtNumA2";
            this.evtNumA2.Size = new System.Drawing.Size(49, 21);
            this.evtNumA2.TabIndex = 5;
            this.evtNumA2.ValueChanged += new System.EventHandler(this.evtNumA2_ValueChanged);
            // 
            // evtNameA2
            // 
            this.evtNameA2.Dock = System.Windows.Forms.DockStyle.Left;
            this.evtNameA2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.evtNameA2.Enabled = false;
            this.evtNameA2.FormattingEnabled = true;
            this.evtNameA2.Location = new System.Drawing.Point(82, 0);
            this.evtNameA2.Name = "evtNameA2";
            this.evtNameA2.Size = new System.Drawing.Size(141, 21);
            this.evtNameA2.TabIndex = 4;
            this.evtNameA2.SelectedIndexChanged += new System.EventHandler(this.evtNameA2_SelectedIndexChanged);
            // 
            // labelEvtA2
            // 
            this.labelEvtA2.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelEvtA2.Location = new System.Drawing.Point(0, 0);
            this.labelEvtA2.Name = "labelEvtA2";
            this.labelEvtA2.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.labelEvtA2.Size = new System.Drawing.Size(82, 21);
            this.labelEvtA2.TabIndex = 3;
            this.labelEvtA2.Text = "...";
            this.labelEvtA2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelEvtA1
            // 
            this.panelEvtA1.Controls.Add(this.evtNumA1);
            this.panelEvtA1.Controls.Add(this.evtNameA1);
            this.panelEvtA1.Controls.Add(this.labelEvtA1);
            this.panelEvtA1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEvtA1.Location = new System.Drawing.Point(3, 17);
            this.panelEvtA1.Name = "panelEvtA1";
            this.panelEvtA1.Size = new System.Drawing.Size(275, 21);
            this.panelEvtA1.TabIndex = 5;
            this.panelEvtA1.Visible = false;
            // 
            // evtNumA1
            // 
            this.evtNumA1.Dock = System.Windows.Forms.DockStyle.Left;
            this.evtNumA1.Enabled = false;
            this.evtNumA1.Location = new System.Drawing.Point(223, 0);
            this.evtNumA1.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.evtNumA1.Name = "evtNumA1";
            this.evtNumA1.Size = new System.Drawing.Size(49, 21);
            this.evtNumA1.TabIndex = 2;
            this.evtNumA1.ValueChanged += new System.EventHandler(this.evtNumA1_ValueChanged);
            // 
            // evtNameA1
            // 
            this.evtNameA1.Dock = System.Windows.Forms.DockStyle.Left;
            this.evtNameA1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.evtNameA1.Enabled = false;
            this.evtNameA1.FormattingEnabled = true;
            this.evtNameA1.Location = new System.Drawing.Point(82, 0);
            this.evtNameA1.Name = "evtNameA1";
            this.evtNameA1.Size = new System.Drawing.Size(141, 21);
            this.evtNameA1.TabIndex = 1;
            this.evtNameA1.SelectionChangeCommitted += new System.EventHandler(this.evtNameA1_SelectedIndexChanged);
            // 
            // labelEvtA1
            // 
            this.labelEvtA1.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelEvtA1.Location = new System.Drawing.Point(0, 0);
            this.labelEvtA1.Name = "labelEvtA1";
            this.labelEvtA1.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.labelEvtA1.Size = new System.Drawing.Size(82, 21);
            this.labelEvtA1.TabIndex = 0;
            this.labelEvtA1.Text = "...";
            this.labelEvtA1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CommandForm
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(281, 228);
            this.Controls.Add(this.panelCommand);
            this.Controls.Add(this.commands);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MinimizeBox = false;
            this.Name = "CommandForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SnapToEdges = true;
            this.Text = "COMMANDS";
            this.Resize += new System.EventHandler(this.CommandForm_Resize);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panelCommand.ResumeLayout(false);
            this.panelCommand.PerformLayout();
            this.panelButtons.ResumeLayout(false);
            this.groupBoxC.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.evtNumC2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.evtNumC1)).EndInit();
            this.groupBoxB.ResumeLayout(false);
            this.groupBoxA.ResumeLayout(false);
            this.panelEvtA3_4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.evtNumA4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.evtNumA3)).EndInit();
            this.panelEvtA2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.evtNumA2)).EndInit();
            this.panelEvtA1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.evtNumA1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox commands;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox categories_aq;
        private System.Windows.Forms.ToolStripComboBox categories_es;
        private System.Windows.Forms.ToolStripButton actionButton;
        private Controls.NewPanel panelCommand;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.GroupBox groupBoxC;
        private System.Windows.Forms.NumericUpDown evtNumC2;
        private System.Windows.Forms.Label labelEvtC2;
        private System.Windows.Forms.NumericUpDown evtNumC1;
        private System.Windows.Forms.Label labelEvtC1;
        private System.Windows.Forms.GroupBox groupBoxB;
        private System.Windows.Forms.CheckedListBox evtEffects;
        private System.Windows.Forms.GroupBox groupBoxA;
        private System.Windows.Forms.Panel panelEvtA3_4;
        private System.Windows.Forms.NumericUpDown evtNumA4;
        private System.Windows.Forms.Label labelEvtA4;
        private System.Windows.Forms.NumericUpDown evtNumA3;
        private System.Windows.Forms.Label labelEvtA3;
        private System.Windows.Forms.Panel panelEvtA2;
        private System.Windows.Forms.NumericUpDown evtNumA2;
        private System.Windows.Forms.ComboBox evtNameA2;
        private System.Windows.Forms.Label labelEvtA2;
        private System.Windows.Forms.Panel panelEvtA1;
        private System.Windows.Forms.NumericUpDown evtNumA1;
        private System.Windows.Forms.ComboBox evtNameA1;
        private System.Windows.Forms.Label labelEvtA1;
        private System.Windows.Forms.Button buttonCancel;
    }
}