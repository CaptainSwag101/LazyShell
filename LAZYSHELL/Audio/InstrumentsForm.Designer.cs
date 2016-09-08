namespace LazyShell.Audio
{
    partial class InstrumentsForm
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
            this.label3 = new System.Windows.Forms.Label();
            this.delayTime = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.echo = new System.Windows.Forms.NumericUpDown();
            this.decayFactor = new System.Windows.Forms.NumericUpDown();
            this.panelPercussions = new System.Windows.Forms.Panel();
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.newPercussive = new System.Windows.Forms.ToolStripButton();
            this.deletePercussive = new System.Windows.Forms.ToolStripButton();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.percussiveName = new System.Windows.Forms.ComboBox();
            this.headerLabel3 = new LazyShell.Controls.HeaderLabel();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.percussiveBalance = new System.Windows.Forms.NumericUpDown();
            this.percussiveVolume = new System.Windows.Forms.NumericUpDown();
            this.percussives = new System.Windows.Forms.ListBox();
            this.percussivePitch = new System.Windows.Forms.ComboBox();
            this.percussivePitchIndex = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.headerLabel1 = new LazyShell.Controls.HeaderLabel();
            this.headerLabel2 = new LazyShell.Controls.HeaderLabel();
            this.lineSeparator1 = new LazyShell.LineSeparator();
            this.panelReverberation = new System.Windows.Forms.Panel();
            this.panelInstruments = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.delayTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.echo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.decayFactor)).BeginInit();
            this.panelPercussions.SuspendLayout();
            this.toolStrip3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.percussiveBalance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.percussiveVolume)).BeginInit();
            this.panelReverberation.SuspendLayout();
            this.panelInstruments.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Delay Time";
            // 
            // delayTime
            // 
            this.delayTime.Location = new System.Drawing.Point(79, 17);
            this.delayTime.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.delayTime.Name = "delayTime";
            this.delayTime.Size = new System.Drawing.Size(50, 20);
            this.delayTime.TabIndex = 1;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(131, 42);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(31, 13);
            this.label11.TabIndex = 4;
            this.label11.Text = ": 128";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 41);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(66, 13);
            this.label10.TabIndex = 2;
            this.label10.Text = "Decay Ratio";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 63);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 13);
            this.label9.TabIndex = 4;
            this.label9.Text = "Echo Volume";
            // 
            // echo
            // 
            this.echo.Location = new System.Drawing.Point(79, 61);
            this.echo.Maximum = new decimal(new int[] {
            127,
            0,
            0,
            0});
            this.echo.Minimum = new decimal(new int[] {
            128,
            0,
            0,
            -2147483648});
            this.echo.Name = "echo";
            this.echo.Size = new System.Drawing.Size(50, 20);
            this.echo.TabIndex = 5;
            // 
            // decayFactor
            // 
            this.decayFactor.Location = new System.Drawing.Point(79, 39);
            this.decayFactor.Maximum = new decimal(new int[] {
            127,
            0,
            0,
            0});
            this.decayFactor.Name = "decayFactor";
            this.decayFactor.Size = new System.Drawing.Size(50, 20);
            this.decayFactor.TabIndex = 3;
            // 
            // panelPercussions
            // 
            this.panelPercussions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelPercussions.Controls.Add(this.toolStrip3);
            this.panelPercussions.Controls.Add(this.label8);
            this.panelPercussions.Controls.Add(this.label7);
            this.panelPercussions.Controls.Add(this.label4);
            this.panelPercussions.Controls.Add(this.percussiveName);
            this.panelPercussions.Controls.Add(this.headerLabel3);
            this.panelPercussions.Controls.Add(this.label6);
            this.panelPercussions.Controls.Add(this.label5);
            this.panelPercussions.Controls.Add(this.percussiveBalance);
            this.panelPercussions.Controls.Add(this.percussiveVolume);
            this.panelPercussions.Controls.Add(this.percussives);
            this.panelPercussions.Controls.Add(this.percussivePitch);
            this.panelPercussions.Controls.Add(this.percussivePitchIndex);
            this.panelPercussions.Location = new System.Drawing.Point(221, 102);
            this.panelPercussions.Name = "panelPercussions";
            this.panelPercussions.Size = new System.Drawing.Size(167, 366);
            this.panelPercussions.TabIndex = 5;
            this.panelPercussions.Text = "Percussives";
            // 
            // toolStrip3
            // 
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newPercussive,
            this.deletePercussive});
            this.toolStrip3.Location = new System.Drawing.Point(0, 14);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.Size = new System.Drawing.Size(167, 25);
            this.toolStrip3.TabIndex = 0;
            // 
            // newPercussive
            // 
            this.newPercussive.Image = global::LazyShell.Properties.Resources.new_file;
            this.newPercussive.Name = "newPercussive";
            this.newPercussive.Size = new System.Drawing.Size(23, 22);
            this.newPercussive.ToolTipText = "New";
            // 
            // deletePercussive
            // 
            this.deletePercussive.Image = global::LazyShell.Properties.Resources.delete;
            this.deletePercussive.Name = "deletePercussive";
            this.deletePercussive.Size = new System.Drawing.Size(23, 22);
            this.deletePercussive.ToolTipText = "Delete";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 347);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "Sp. Balance";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 325);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Volume";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 256);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Instrument";
            // 
            // percussiveName
            // 
            this.percussiveName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.percussiveName.DropDownWidth = 200;
            this.percussiveName.FormattingEnabled = true;
            this.percussiveName.Location = new System.Drawing.Point(7, 274);
            this.percussiveName.Name = "percussiveName";
            this.percussiveName.Size = new System.Drawing.Size(157, 21);
            this.percussiveName.TabIndex = 5;
            // 
            // headerLabel3
            // 
            this.headerLabel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerLabel3.Location = new System.Drawing.Point(0, 0);
            this.headerLabel3.Name = "headerLabel3";
            this.headerLabel3.Size = new System.Drawing.Size(167, 14);
            this.headerLabel3.TabIndex = 6;
            this.headerLabel3.Text = "Percussives";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 304);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Pitch";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 230);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Pitch Index";
            // 
            // percussiveBalance
            // 
            this.percussiveBalance.Location = new System.Drawing.Point(76, 345);
            this.percussiveBalance.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.percussiveBalance.Name = "percussiveBalance";
            this.percussiveBalance.Size = new System.Drawing.Size(88, 20);
            this.percussiveBalance.TabIndex = 11;
            // 
            // percussiveVolume
            // 
            this.percussiveVolume.Location = new System.Drawing.Point(76, 323);
            this.percussiveVolume.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.percussiveVolume.Name = "percussiveVolume";
            this.percussiveVolume.Size = new System.Drawing.Size(88, 20);
            this.percussiveVolume.TabIndex = 9;
            // 
            // percussives
            // 
            this.percussives.FormattingEnabled = true;
            this.percussives.Location = new System.Drawing.Point(6, 45);
            this.percussives.Name = "percussives";
            this.percussives.Size = new System.Drawing.Size(158, 173);
            this.percussives.TabIndex = 1;
            // 
            // percussivePitch
            // 
            this.percussivePitch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.percussivePitch.FormattingEnabled = true;
            this.percussivePitch.Location = new System.Drawing.Point(76, 301);
            this.percussivePitch.Name = "percussivePitch";
            this.percussivePitch.Size = new System.Drawing.Size(88, 21);
            this.percussivePitch.TabIndex = 7;
            // 
            // percussivePitchIndex
            // 
            this.percussivePitchIndex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.percussivePitchIndex.FormattingEnabled = true;
            this.percussivePitchIndex.Items.AddRange(new object[] {
            "C",
            "C# / Db",
            "D",
            "D# / Eb",
            "E / Fb",
            "F",
            "F# / Gb",
            "G",
            "G# / Ab",
            "A",
            "A# / Bb",
            "B / Cb"});
            this.percussivePitchIndex.Location = new System.Drawing.Point(76, 227);
            this.percussivePitchIndex.Name = "percussivePitchIndex";
            this.percussivePitchIndex.Size = new System.Drawing.Size(88, 21);
            this.percussivePitchIndex.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(129, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Volume";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sample";
            // 
            // headerLabel1
            // 
            this.headerLabel1.Location = new System.Drawing.Point(0, 0);
            this.headerLabel1.Name = "headerLabel1";
            this.headerLabel1.Size = new System.Drawing.Size(207, 14);
            this.headerLabel1.TabIndex = 6;
            this.headerLabel1.Text = "Instruments";
            // 
            // headerLabel2
            // 
            this.headerLabel2.Location = new System.Drawing.Point(0, 0);
            this.headerLabel2.Name = "headerLabel2";
            this.headerLabel2.Size = new System.Drawing.Size(173, 14);
            this.headerLabel2.TabIndex = 6;
            this.headerLabel2.Text = "Reverberation";
            // 
            // lineSeparator1
            // 
            this.lineSeparator1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lineSeparator1.LineDirection = LazyShell.LineDirection.Vertical;
            this.lineSeparator1.Location = new System.Drawing.Point(213, 6);
            this.lineSeparator1.MaximumSize = new System.Drawing.Size(2, 2000);
            this.lineSeparator1.MinimumSize = new System.Drawing.Size(2, 0);
            this.lineSeparator1.Name = "lineSeparator1";
            this.lineSeparator1.Size = new System.Drawing.Size(2, 462);
            this.lineSeparator1.TabIndex = 7;
            // 
            // panelReverberation
            // 
            this.panelReverberation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelReverberation.Controls.Add(this.headerLabel2);
            this.panelReverberation.Controls.Add(this.decayFactor);
            this.panelReverberation.Controls.Add(this.label3);
            this.panelReverberation.Controls.Add(this.echo);
            this.panelReverberation.Controls.Add(this.label9);
            this.panelReverberation.Controls.Add(this.delayTime);
            this.panelReverberation.Controls.Add(this.label10);
            this.panelReverberation.Controls.Add(this.label11);
            this.panelReverberation.Location = new System.Drawing.Point(221, 6);
            this.panelReverberation.Name = "panelReverberation";
            this.panelReverberation.Size = new System.Drawing.Size(167, 82);
            this.panelReverberation.TabIndex = 8;
            // 
            // panelInstruments
            // 
            this.panelInstruments.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelInstruments.Controls.Add(this.headerLabel1);
            this.panelInstruments.Controls.Add(this.label1);
            this.panelInstruments.Controls.Add(this.label2);
            this.panelInstruments.Location = new System.Drawing.Point(0, 6);
            this.panelInstruments.Name = "panelInstruments";
            this.panelInstruments.Size = new System.Drawing.Size(207, 462);
            this.panelInstruments.TabIndex = 9;
            // 
            // InstrumentsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 471);
            this.Controls.Add(this.panelInstruments);
            this.Controls.Add(this.panelReverberation);
            this.Controls.Add(this.lineSeparator1);
            this.Controls.Add(this.panelPercussions);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "InstrumentsForm";
            this.Text = "Instruments";
            ((System.ComponentModel.ISupportInitialize)(this.delayTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.echo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.decayFactor)).EndInit();
            this.panelPercussions.ResumeLayout(false);
            this.panelPercussions.PerformLayout();
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.percussiveBalance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.percussiveVolume)).EndInit();
            this.panelReverberation.ResumeLayout(false);
            this.panelReverberation.PerformLayout();
            this.panelInstruments.ResumeLayout(false);
            this.panelInstruments.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown delayTime;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown echo;
        private System.Windows.Forms.NumericUpDown decayFactor;
        private System.Windows.Forms.Panel panelPercussions;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripButton newPercussive;
        private System.Windows.Forms.ToolStripButton deletePercussive;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox percussiveName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown percussiveBalance;
        private System.Windows.Forms.NumericUpDown percussiveVolume;
        private System.Windows.Forms.ListBox percussives;
        private System.Windows.Forms.ComboBox percussivePitch;
        private System.Windows.Forms.ComboBox percussivePitchIndex;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Controls.HeaderLabel headerLabel1;
        private Controls.HeaderLabel headerLabel2;
        private LineSeparator lineSeparator1;
        private Controls.HeaderLabel headerLabel3;
        private System.Windows.Forms.Panel panelReverberation;
        private System.Windows.Forms.Panel panelInstruments;
    }
}