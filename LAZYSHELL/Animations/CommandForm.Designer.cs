namespace LazyShell.Animations
{
    partial class CommandForm
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.commands = new System.Windows.Forms.ToolStripComboBox();
            this.panelCommand = new LazyShell.Controls.NewPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.aniTitleD = new System.Windows.Forms.GroupBox();
            this.aniBits = new System.Windows.Forms.CheckedListBox();
            this.aniTitleC = new System.Windows.Forms.GroupBox();
            this.aniPanelC2 = new System.Windows.Forms.Panel();
            this.aniNumC2 = new System.Windows.Forms.NumericUpDown();
            this.aniLabelC2 = new System.Windows.Forms.Label();
            this.aniPanelC1 = new System.Windows.Forms.Panel();
            this.aniNumC1 = new System.Windows.Forms.NumericUpDown();
            this.aniLabelC1 = new System.Windows.Forms.Label();
            this.aniTitleB = new System.Windows.Forms.GroupBox();
            this.aniPanelB2 = new System.Windows.Forms.Panel();
            this.aniNumB2 = new System.Windows.Forms.NumericUpDown();
            this.aniLabelB2 = new System.Windows.Forms.Label();
            this.aniPanelB1 = new System.Windows.Forms.Panel();
            this.aniNumB1 = new System.Windows.Forms.NumericUpDown();
            this.aniLabelB1 = new System.Windows.Forms.Label();
            this.aniTitleA = new System.Windows.Forms.GroupBox();
            this.aniPanelA2 = new System.Windows.Forms.Panel();
            this.aniNumA2 = new System.Windows.Forms.NumericUpDown();
            this.aniNameA2 = new System.Windows.Forms.ComboBox();
            this.aniLabelA2 = new System.Windows.Forms.Label();
            this.aniPanelA1 = new System.Windows.Forms.Panel();
            this.aniNumA1 = new System.Windows.Forms.NumericUpDown();
            this.aniNameA1 = new System.Windows.Forms.ComboBox();
            this.aniLabelA1 = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.panelCommand.SuspendLayout();
            this.panel1.SuspendLayout();
            this.aniTitleD.SuspendLayout();
            this.aniTitleC.SuspendLayout();
            this.aniPanelC2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.aniNumC2)).BeginInit();
            this.aniPanelC1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.aniNumC1)).BeginInit();
            this.aniTitleB.SuspendLayout();
            this.aniPanelB2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.aniNumB2)).BeginInit();
            this.aniPanelB1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.aniNumB1)).BeginInit();
            this.aniTitleA.SuspendLayout();
            this.aniPanelA2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.aniNumA2)).BeginInit();
            this.aniPanelA1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.aniNumA1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.commands});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(284, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(86, 22);
            this.toolStripLabel1.Text = "Select Command";
            // 
            // commands
            // 
            this.commands.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.commands.Name = "commands";
            this.commands.Size = new System.Drawing.Size(170, 25);
            this.commands.SelectedIndexChanged += new System.EventHandler(this.commands_SelectedIndexChanged);
            // 
            // panelCommand
            // 
            this.panelCommand.AutoSize = true;
            this.panelCommand.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelCommand.Controls.Add(this.panel1);
            this.panelCommand.Controls.Add(this.aniTitleD);
            this.panelCommand.Controls.Add(this.aniTitleC);
            this.panelCommand.Controls.Add(this.aniTitleB);
            this.panelCommand.Controls.Add(this.aniTitleA);
            this.panelCommand.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCommand.Location = new System.Drawing.Point(0, 25);
            this.panelCommand.Name = "panelCommand";
            this.panelCommand.Size = new System.Drawing.Size(284, 243);
            this.panelCommand.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonCancel);
            this.panel1.Controls.Add(this.buttonOK);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 216);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(284, 27);
            this.panel1.TabIndex = 10;
            // 
            // buttonCancel
            // 
            this.buttonCancel.BackColor = System.Drawing.SystemColors.Control;
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(144, 3);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(137, 22);
            this.buttonCancel.TabIndex = 4;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = false;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.BackColor = System.Drawing.SystemColors.Control;
            this.buttonOK.Location = new System.Drawing.Point(3, 3);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(137, 22);
            this.buttonOK.TabIndex = 4;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = false;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // aniTitleD
            // 
            this.aniTitleD.AutoSize = true;
            this.aniTitleD.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.aniTitleD.Controls.Add(this.aniBits);
            this.aniTitleD.Dock = System.Windows.Forms.DockStyle.Top;
            this.aniTitleD.Location = new System.Drawing.Point(0, 192);
            this.aniTitleD.Name = "aniTitleD";
            this.aniTitleD.Size = new System.Drawing.Size(284, 24);
            this.aniTitleD.TabIndex = 9;
            this.aniTitleD.TabStop = false;
            // 
            // aniBits
            // 
            this.aniBits.CheckOnClick = true;
            this.aniBits.ColumnWidth = 134;
            this.aniBits.Dock = System.Windows.Forms.DockStyle.Top;
            this.aniBits.Enabled = false;
            this.aniBits.FormattingEnabled = true;
            this.aniBits.Location = new System.Drawing.Point(3, 17);
            this.aniBits.MultiColumn = true;
            this.aniBits.Name = "aniBits";
            this.aniBits.Size = new System.Drawing.Size(278, 4);
            this.aniBits.TabIndex = 0;
            // 
            // aniTitleC
            // 
            this.aniTitleC.AutoSize = true;
            this.aniTitleC.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.aniTitleC.Controls.Add(this.aniPanelC2);
            this.aniTitleC.Controls.Add(this.aniPanelC1);
            this.aniTitleC.Dock = System.Windows.Forms.DockStyle.Top;
            this.aniTitleC.Location = new System.Drawing.Point(0, 128);
            this.aniTitleC.Name = "aniTitleC";
            this.aniTitleC.Padding = new System.Windows.Forms.Padding(3, 3, 3, 4);
            this.aniTitleC.Size = new System.Drawing.Size(284, 64);
            this.aniTitleC.TabIndex = 8;
            this.aniTitleC.TabStop = false;
            // 
            // aniPanelC2
            // 
            this.aniPanelC2.Controls.Add(this.aniNumC2);
            this.aniPanelC2.Controls.Add(this.aniLabelC2);
            this.aniPanelC2.Dock = System.Windows.Forms.DockStyle.Top;
            this.aniPanelC2.Location = new System.Drawing.Point(3, 38);
            this.aniPanelC2.Name = "aniPanelC2";
            this.aniPanelC2.Size = new System.Drawing.Size(278, 22);
            this.aniPanelC2.TabIndex = 6;
            // 
            // aniNumC2
            // 
            this.aniNumC2.Dock = System.Windows.Forms.DockStyle.Left;
            this.aniNumC2.Enabled = false;
            this.aniNumC2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.aniNumC2.Location = new System.Drawing.Point(147, 0);
            this.aniNumC2.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.aniNumC2.Name = "aniNumC2";
            this.aniNumC2.Size = new System.Drawing.Size(128, 21);
            this.aniNumC2.TabIndex = 3;
            // 
            // aniLabelC2
            // 
            this.aniLabelC2.Dock = System.Windows.Forms.DockStyle.Left;
            this.aniLabelC2.Location = new System.Drawing.Point(0, 0);
            this.aniLabelC2.Name = "aniLabelC2";
            this.aniLabelC2.Padding = new System.Windows.Forms.Padding(3, 0, 0, 3);
            this.aniLabelC2.Size = new System.Drawing.Size(147, 22);
            this.aniLabelC2.TabIndex = 2;
            this.aniLabelC2.Text = "...";
            this.aniLabelC2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // aniPanelC1
            // 
            this.aniPanelC1.Controls.Add(this.aniNumC1);
            this.aniPanelC1.Controls.Add(this.aniLabelC1);
            this.aniPanelC1.Dock = System.Windows.Forms.DockStyle.Top;
            this.aniPanelC1.Location = new System.Drawing.Point(3, 17);
            this.aniPanelC1.Name = "aniPanelC1";
            this.aniPanelC1.Size = new System.Drawing.Size(278, 21);
            this.aniPanelC1.TabIndex = 6;
            // 
            // aniNumC1
            // 
            this.aniNumC1.Dock = System.Windows.Forms.DockStyle.Left;
            this.aniNumC1.Enabled = false;
            this.aniNumC1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.aniNumC1.Location = new System.Drawing.Point(147, 0);
            this.aniNumC1.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.aniNumC1.Name = "aniNumC1";
            this.aniNumC1.Size = new System.Drawing.Size(128, 21);
            this.aniNumC1.TabIndex = 1;
            // 
            // aniLabelC1
            // 
            this.aniLabelC1.Dock = System.Windows.Forms.DockStyle.Left;
            this.aniLabelC1.Location = new System.Drawing.Point(0, 0);
            this.aniLabelC1.Name = "aniLabelC1";
            this.aniLabelC1.Padding = new System.Windows.Forms.Padding(3, 0, 0, 3);
            this.aniLabelC1.Size = new System.Drawing.Size(147, 21);
            this.aniLabelC1.TabIndex = 0;
            this.aniLabelC1.Text = "...";
            this.aniLabelC1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // aniTitleB
            // 
            this.aniTitleB.AutoSize = true;
            this.aniTitleB.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.aniTitleB.Controls.Add(this.aniPanelB2);
            this.aniTitleB.Controls.Add(this.aniPanelB1);
            this.aniTitleB.Dock = System.Windows.Forms.DockStyle.Top;
            this.aniTitleB.Location = new System.Drawing.Point(0, 64);
            this.aniTitleB.Name = "aniTitleB";
            this.aniTitleB.Padding = new System.Windows.Forms.Padding(3, 3, 3, 4);
            this.aniTitleB.Size = new System.Drawing.Size(284, 64);
            this.aniTitleB.TabIndex = 7;
            this.aniTitleB.TabStop = false;
            // 
            // aniPanelB2
            // 
            this.aniPanelB2.Controls.Add(this.aniNumB2);
            this.aniPanelB2.Controls.Add(this.aniLabelB2);
            this.aniPanelB2.Dock = System.Windows.Forms.DockStyle.Top;
            this.aniPanelB2.Location = new System.Drawing.Point(3, 38);
            this.aniPanelB2.Name = "aniPanelB2";
            this.aniPanelB2.Size = new System.Drawing.Size(278, 22);
            this.aniPanelB2.TabIndex = 6;
            // 
            // aniNumB2
            // 
            this.aniNumB2.Dock = System.Windows.Forms.DockStyle.Left;
            this.aniNumB2.Enabled = false;
            this.aniNumB2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.aniNumB2.Location = new System.Drawing.Point(147, 0);
            this.aniNumB2.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.aniNumB2.Name = "aniNumB2";
            this.aniNumB2.Size = new System.Drawing.Size(128, 21);
            this.aniNumB2.TabIndex = 3;
            // 
            // aniLabelB2
            // 
            this.aniLabelB2.Dock = System.Windows.Forms.DockStyle.Left;
            this.aniLabelB2.Location = new System.Drawing.Point(0, 0);
            this.aniLabelB2.Name = "aniLabelB2";
            this.aniLabelB2.Padding = new System.Windows.Forms.Padding(3, 0, 0, 3);
            this.aniLabelB2.Size = new System.Drawing.Size(147, 22);
            this.aniLabelB2.TabIndex = 2;
            this.aniLabelB2.Text = "...";
            this.aniLabelB2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // aniPanelB1
            // 
            this.aniPanelB1.Controls.Add(this.aniNumB1);
            this.aniPanelB1.Controls.Add(this.aniLabelB1);
            this.aniPanelB1.Dock = System.Windows.Forms.DockStyle.Top;
            this.aniPanelB1.Location = new System.Drawing.Point(3, 17);
            this.aniPanelB1.Name = "aniPanelB1";
            this.aniPanelB1.Size = new System.Drawing.Size(278, 21);
            this.aniPanelB1.TabIndex = 6;
            // 
            // aniNumB1
            // 
            this.aniNumB1.Dock = System.Windows.Forms.DockStyle.Left;
            this.aniNumB1.Enabled = false;
            this.aniNumB1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.aniNumB1.Location = new System.Drawing.Point(147, 0);
            this.aniNumB1.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.aniNumB1.Name = "aniNumB1";
            this.aniNumB1.Size = new System.Drawing.Size(128, 21);
            this.aniNumB1.TabIndex = 1;
            // 
            // aniLabelB1
            // 
            this.aniLabelB1.Dock = System.Windows.Forms.DockStyle.Left;
            this.aniLabelB1.Location = new System.Drawing.Point(0, 0);
            this.aniLabelB1.Name = "aniLabelB1";
            this.aniLabelB1.Padding = new System.Windows.Forms.Padding(3, 0, 0, 3);
            this.aniLabelB1.Size = new System.Drawing.Size(147, 21);
            this.aniLabelB1.TabIndex = 0;
            this.aniLabelB1.Text = "...";
            this.aniLabelB1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // aniTitleA
            // 
            this.aniTitleA.AutoSize = true;
            this.aniTitleA.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.aniTitleA.Controls.Add(this.aniPanelA2);
            this.aniTitleA.Controls.Add(this.aniPanelA1);
            this.aniTitleA.Dock = System.Windows.Forms.DockStyle.Top;
            this.aniTitleA.Location = new System.Drawing.Point(0, 0);
            this.aniTitleA.Name = "aniTitleA";
            this.aniTitleA.Padding = new System.Windows.Forms.Padding(3, 3, 3, 4);
            this.aniTitleA.Size = new System.Drawing.Size(284, 64);
            this.aniTitleA.TabIndex = 6;
            this.aniTitleA.TabStop = false;
            // 
            // aniPanelA2
            // 
            this.aniPanelA2.Controls.Add(this.aniNumA2);
            this.aniPanelA2.Controls.Add(this.aniNameA2);
            this.aniPanelA2.Controls.Add(this.aniLabelA2);
            this.aniPanelA2.Dock = System.Windows.Forms.DockStyle.Top;
            this.aniPanelA2.Location = new System.Drawing.Point(3, 38);
            this.aniPanelA2.Name = "aniPanelA2";
            this.aniPanelA2.Size = new System.Drawing.Size(278, 22);
            this.aniPanelA2.TabIndex = 6;
            // 
            // aniNumA2
            // 
            this.aniNumA2.Dock = System.Windows.Forms.DockStyle.Left;
            this.aniNumA2.Enabled = false;
            this.aniNumA2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.aniNumA2.Location = new System.Drawing.Point(217, 0);
            this.aniNumA2.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.aniNumA2.Name = "aniNumA2";
            this.aniNumA2.Size = new System.Drawing.Size(58, 21);
            this.aniNumA2.TabIndex = 5;
            // 
            // aniNameA2
            // 
            this.aniNameA2.BackColor = System.Drawing.SystemColors.Window;
            this.aniNameA2.Dock = System.Windows.Forms.DockStyle.Left;
            this.aniNameA2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.aniNameA2.Enabled = false;
            this.aniNameA2.FormattingEnabled = true;
            this.aniNameA2.Items.AddRange(new object[] {
            "initialize action queue",
            "[F0] unknown",
            "[F1] unknown",
            "[F2] apply action to object",
            "[F3] apply action to object",
            "[F4] action?",
            "[F5] action?",
            "[F6] unknown",
            "[F7] unknown",
            "[F8] show object",
            "[F9] remove object",
            "[FA] null object action",
            "[FB] unknown",
            "[FC] unknown",
            "[FD] unknown",
            "[FE] end object queue",
            "[FF] initialize object coords?"});
            this.aniNameA2.Location = new System.Drawing.Point(81, 0);
            this.aniNameA2.Name = "aniNameA2";
            this.aniNameA2.Size = new System.Drawing.Size(136, 21);
            this.aniNameA2.TabIndex = 4;
            // 
            // aniLabelA2
            // 
            this.aniLabelA2.Dock = System.Windows.Forms.DockStyle.Left;
            this.aniLabelA2.Location = new System.Drawing.Point(0, 0);
            this.aniLabelA2.Name = "aniLabelA2";
            this.aniLabelA2.Padding = new System.Windows.Forms.Padding(3, 0, 0, 3);
            this.aniLabelA2.Size = new System.Drawing.Size(81, 22);
            this.aniLabelA2.TabIndex = 3;
            this.aniLabelA2.Text = "...";
            this.aniLabelA2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // aniPanelA1
            // 
            this.aniPanelA1.Controls.Add(this.aniNumA1);
            this.aniPanelA1.Controls.Add(this.aniNameA1);
            this.aniPanelA1.Controls.Add(this.aniLabelA1);
            this.aniPanelA1.Dock = System.Windows.Forms.DockStyle.Top;
            this.aniPanelA1.Location = new System.Drawing.Point(3, 17);
            this.aniPanelA1.Name = "aniPanelA1";
            this.aniPanelA1.Size = new System.Drawing.Size(278, 21);
            this.aniPanelA1.TabIndex = 6;
            // 
            // aniNumA1
            // 
            this.aniNumA1.Dock = System.Windows.Forms.DockStyle.Left;
            this.aniNumA1.Enabled = false;
            this.aniNumA1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.aniNumA1.Location = new System.Drawing.Point(217, 0);
            this.aniNumA1.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.aniNumA1.Name = "aniNumA1";
            this.aniNumA1.Size = new System.Drawing.Size(58, 21);
            this.aniNumA1.TabIndex = 2;
            this.aniNumA1.ValueChanged += new System.EventHandler(this.aniNumA1_ValueChanged);
            // 
            // aniNameA1
            // 
            this.aniNameA1.BackColor = System.Drawing.SystemColors.Window;
            this.aniNameA1.Dock = System.Windows.Forms.DockStyle.Left;
            this.aniNameA1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.aniNameA1.Enabled = false;
            this.aniNameA1.FormattingEnabled = true;
            this.aniNameA1.Location = new System.Drawing.Point(81, 0);
            this.aniNameA1.Name = "aniNameA1";
            this.aniNameA1.Size = new System.Drawing.Size(136, 21);
            this.aniNameA1.TabIndex = 1;
            this.aniNameA1.SelectedIndexChanged += new System.EventHandler(this.aniNameA1_SelectedIndexChanged);
            // 
            // aniLabelA1
            // 
            this.aniLabelA1.Dock = System.Windows.Forms.DockStyle.Left;
            this.aniLabelA1.Location = new System.Drawing.Point(0, 0);
            this.aniLabelA1.Name = "aniLabelA1";
            this.aniLabelA1.Padding = new System.Windows.Forms.Padding(3, 0, 0, 3);
            this.aniLabelA1.Size = new System.Drawing.Size(81, 21);
            this.aniLabelA1.TabIndex = 0;
            this.aniLabelA1.Text = "...";
            this.aniLabelA1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CommandForm
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(284, 283);
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
            this.panel1.ResumeLayout(false);
            this.aniTitleD.ResumeLayout(false);
            this.aniTitleC.ResumeLayout(false);
            this.aniPanelC2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.aniNumC2)).EndInit();
            this.aniPanelC1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.aniNumC1)).EndInit();
            this.aniTitleB.ResumeLayout(false);
            this.aniPanelB2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.aniNumB2)).EndInit();
            this.aniPanelB1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.aniNumB1)).EndInit();
            this.aniTitleA.ResumeLayout(false);
            this.aniPanelA2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.aniNumA2)).EndInit();
            this.aniPanelA1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.aniNumA1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox commands;
        private Controls.NewPanel panelCommand;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.GroupBox aniTitleD;
        private System.Windows.Forms.CheckedListBox aniBits;
        private System.Windows.Forms.GroupBox aniTitleC;
        private System.Windows.Forms.Panel aniPanelC2;
        private System.Windows.Forms.NumericUpDown aniNumC2;
        private System.Windows.Forms.Label aniLabelC2;
        private System.Windows.Forms.Panel aniPanelC1;
        private System.Windows.Forms.NumericUpDown aniNumC1;
        private System.Windows.Forms.Label aniLabelC1;
        private System.Windows.Forms.GroupBox aniTitleB;
        private System.Windows.Forms.Panel aniPanelB2;
        private System.Windows.Forms.NumericUpDown aniNumB2;
        private System.Windows.Forms.Label aniLabelB2;
        private System.Windows.Forms.Panel aniPanelB1;
        private System.Windows.Forms.NumericUpDown aniNumB1;
        private System.Windows.Forms.Label aniLabelB1;
        private System.Windows.Forms.GroupBox aniTitleA;
        private System.Windows.Forms.Panel aniPanelA2;
        private System.Windows.Forms.NumericUpDown aniNumA2;
        private System.Windows.Forms.ComboBox aniNameA2;
        private System.Windows.Forms.Label aniLabelA2;
        private System.Windows.Forms.Panel aniPanelA1;
        private System.Windows.Forms.NumericUpDown aniNumA1;
        private System.Windows.Forms.ComboBox aniNameA1;
        private System.Windows.Forms.Label aniLabelA1;
    }
}