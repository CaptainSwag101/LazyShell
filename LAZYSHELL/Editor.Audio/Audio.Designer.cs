namespace LAZYSHELL
{
    partial class Audio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Audio));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.sampleNum = new LAZYSHELL.ToolStripNumericUpDown();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.save = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.import = new System.Windows.Forms.ToolStripButton();
            this.export = new System.Windows.Forms.ToolStripButton();
            this.clear = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.play = new System.Windows.Forms.ToolStripButton();
            this.pause = new System.Windows.Forms.ToolStripButton();
            this.back = new System.Windows.Forms.ToolStripButton();
            this.foward = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rateManualValue = new System.Windows.Forms.NumericUpDown();
            this.rate8000Hz = new System.Windows.Forms.RadioButton();
            this.rateManual = new System.Windows.Forms.RadioButton();
            this.rate32000Hz = new System.Windows.Forms.RadioButton();
            this.rate44100Hz = new System.Windows.Forms.RadioButton();
            this.rate22050Hz = new System.Windows.Forms.RadioButton();
            this.rate16000Hz = new System.Windows.Forms.RadioButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.label1 = new System.Windows.Forms.RichTextBox();
            this.toolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rateManualValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sampleNum,
            this.toolStripSeparator4,
            this.save,
            this.toolStripSeparator1,
            this.import,
            this.export,
            this.clear,
            this.toolStripSeparator2,
            this.play,
            this.pause,
            this.back,
            this.foward});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(572, 25);
            this.toolStrip1.TabIndex = 398;
            // 
            // sampleNum
            // 
            this.sampleNum.AutoSize = false;
            this.sampleNum.Hexadecimal = false;
            this.sampleNum.Location = new System.Drawing.Point(7, 2);
            this.sampleNum.Maximum = new decimal(new int[] {
            115,
            0,
            0,
            0});
            this.sampleNum.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.sampleNum.Name = "sampleNum";
            this.sampleNum.Size = new System.Drawing.Size(60, 21);
            this.sampleNum.Text = "0";
            this.sampleNum.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.sampleNum.ValueChanged += new System.EventHandler(this.sampleNum_ValueChanged);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // save
            // 
            this.save.Image = global::LAZYSHELL.Properties.Resources.save_small;
            this.save.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.save.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(23, 22);
            this.save.ToolTipText = "Save";
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // import
            // 
            this.import.Image = global::LAZYSHELL.Properties.Resources.import_small;
            this.import.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.import.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.import.Name = "import";
            this.import.Size = new System.Drawing.Size(23, 22);
            this.import.ToolTipText = "Import";
            this.import.Click += new System.EventHandler(this.import_Click);
            // 
            // export
            // 
            this.export.Image = global::LAZYSHELL.Properties.Resources.export_small;
            this.export.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.export.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.export.Name = "export";
            this.export.Size = new System.Drawing.Size(23, 22);
            this.export.ToolTipText = "Export";
            this.export.Click += new System.EventHandler(this.export_Click);
            // 
            // clear
            // 
            this.clear.Image = global::LAZYSHELL.Properties.Resources.clear_small;
            this.clear.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.clear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.clear.Name = "clear";
            this.clear.Size = new System.Drawing.Size(23, 22);
            this.clear.ToolTipText = "Clear";
            this.clear.Click += new System.EventHandler(this.clear_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // play
            // 
            this.play.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.play.Image = global::LAZYSHELL.Properties.Resources.play;
            this.play.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.play.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.play.Name = "play";
            this.play.Size = new System.Drawing.Size(23, 22);
            this.play.Text = "Play";
            this.play.Click += new System.EventHandler(this.play_Click);
            // 
            // pause
            // 
            this.pause.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.pause.Image = global::LAZYSHELL.Properties.Resources.stop;
            this.pause.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.pause.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pause.Name = "pause";
            this.pause.Size = new System.Drawing.Size(23, 22);
            this.pause.Text = "Stop";
            this.pause.Click += new System.EventHandler(this.pause_Click);
            // 
            // back
            // 
            this.back.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.back.Image = global::LAZYSHELL.Properties.Resources.back;
            this.back.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.back.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(23, 22);
            this.back.Text = "Play Previous";
            this.back.Click += new System.EventHandler(this.back_Click);
            // 
            // foward
            // 
            this.foward.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.foward.Image = global::LAZYSHELL.Properties.Resources.foward;
            this.foward.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.foward.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.foward.Name = "foward";
            this.foward.Size = new System.Drawing.Size(23, 22);
            this.foward.Text = "Play Next";
            this.foward.Click += new System.EventHandler(this.foward_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rateManualValue);
            this.groupBox1.Controls.Add(this.rate8000Hz);
            this.groupBox1.Controls.Add(this.rateManual);
            this.groupBox1.Controls.Add(this.rate32000Hz);
            this.groupBox1.Controls.Add(this.rate44100Hz);
            this.groupBox1.Controls.Add(this.rate22050Hz);
            this.groupBox1.Controls.Add(this.rate16000Hz);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(104, 146);
            this.groupBox1.TabIndex = 399;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sample Rate";
            // 
            // rateManualValue
            // 
            this.rateManualValue.Enabled = false;
            this.rateManualValue.Location = new System.Drawing.Point(7, 119);
            this.rateManualValue.Maximum = new decimal(new int[] {
            48000,
            0,
            0,
            0});
            this.rateManualValue.Minimum = new decimal(new int[] {
            8000,
            0,
            0,
            0});
            this.rateManualValue.Name = "rateManualValue";
            this.rateManualValue.Size = new System.Drawing.Size(91, 21);
            this.rateManualValue.TabIndex = 267;
            this.rateManualValue.Value = new decimal(new int[] {
            32000,
            0,
            0,
            0});
            this.rateManualValue.ValueChanged += new System.EventHandler(this.rateManualValue_ValueChanged);
            // 
            // rate8000Hz
            // 
            this.rate8000Hz.AutoSize = true;
            this.rate8000Hz.Location = new System.Drawing.Point(6, 20);
            this.rate8000Hz.Name = "rate8000Hz";
            this.rate8000Hz.Size = new System.Drawing.Size(65, 17);
            this.rate8000Hz.TabIndex = 263;
            this.rate8000Hz.Text = "8000 Hz";
            this.rate8000Hz.UseVisualStyleBackColor = true;
            this.rate8000Hz.CheckedChanged += new System.EventHandler(this.sampleRate_CheckedChanged);
            // 
            // rateManual
            // 
            this.rateManual.AutoSize = true;
            this.rateManual.Location = new System.Drawing.Point(6, 100);
            this.rateManual.Name = "rateManual";
            this.rateManual.Size = new System.Drawing.Size(54, 17);
            this.rateManual.TabIndex = 266;
            this.rateManual.Text = "Other:";
            this.rateManual.UseVisualStyleBackColor = true;
            this.rateManual.CheckedChanged += new System.EventHandler(this.sampleRate_CheckedChanged);
            // 
            // rate32000Hz
            // 
            this.rate32000Hz.AutoSize = true;
            this.rate32000Hz.Checked = true;
            this.rate32000Hz.Location = new System.Drawing.Point(6, 68);
            this.rate32000Hz.Name = "rate32000Hz";
            this.rate32000Hz.Size = new System.Drawing.Size(71, 17);
            this.rate32000Hz.TabIndex = 265;
            this.rate32000Hz.TabStop = true;
            this.rate32000Hz.Text = "32000 Hz";
            this.rate32000Hz.UseVisualStyleBackColor = true;
            this.rate32000Hz.CheckedChanged += new System.EventHandler(this.sampleRate_CheckedChanged);
            // 
            // rate44100Hz
            // 
            this.rate44100Hz.AutoSize = true;
            this.rate44100Hz.Location = new System.Drawing.Point(6, 84);
            this.rate44100Hz.Name = "rate44100Hz";
            this.rate44100Hz.Size = new System.Drawing.Size(71, 17);
            this.rate44100Hz.TabIndex = 266;
            this.rate44100Hz.Text = "44100 Hz";
            this.rate44100Hz.UseVisualStyleBackColor = true;
            this.rate44100Hz.CheckedChanged += new System.EventHandler(this.sampleRate_CheckedChanged);
            // 
            // rate22050Hz
            // 
            this.rate22050Hz.AutoSize = true;
            this.rate22050Hz.Location = new System.Drawing.Point(6, 52);
            this.rate22050Hz.Name = "rate22050Hz";
            this.rate22050Hz.Size = new System.Drawing.Size(71, 17);
            this.rate22050Hz.TabIndex = 265;
            this.rate22050Hz.Text = "22050 Hz";
            this.rate22050Hz.UseVisualStyleBackColor = true;
            this.rate22050Hz.CheckedChanged += new System.EventHandler(this.sampleRate_CheckedChanged);
            // 
            // rate16000Hz
            // 
            this.rate16000Hz.AutoSize = true;
            this.rate16000Hz.Location = new System.Drawing.Point(6, 36);
            this.rate16000Hz.Name = "rate16000Hz";
            this.rate16000Hz.Size = new System.Drawing.Size(71, 17);
            this.rate16000Hz.TabIndex = 264;
            this.rate16000Hz.Text = "16000 Hz";
            this.rate16000Hz.UseVisualStyleBackColor = true;
            this.rate16000Hz.CheckedChanged += new System.EventHandler(this.sampleRate_CheckedChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Black;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(464, 142);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.SizeChanged += new System.EventHandler(this.pictureBox1_SizeChanged);
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(104, 25);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(468, 146);
            this.panel2.TabIndex = 400;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Location = new System.Drawing.Point(0, 171);
            this.label1.Name = "label1";
            this.label1.ReadOnly = true;
            this.label1.Size = new System.Drawing.Size(572, 245);
            this.label1.TabIndex = 401;
            this.label1.Text = resources.GetString("label1.Text");
            this.label1.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.label1_LinkClicked);
            // 
            // Audio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 416);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Audio";
            this.Text = "AUDIO - Lazy Shell";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Audio_FormClosing);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rateManualValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private ToolStripNumericUpDown sampleNum;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton play;
        private System.Windows.Forms.ToolStripButton pause;
        private System.Windows.Forms.ToolStripButton back;
        private System.Windows.Forms.ToolStripButton foward;
        private System.Windows.Forms.ToolStripButton save;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton import;
        private System.Windows.Forms.ToolStripButton export;
        private System.Windows.Forms.ToolStripButton clear;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.RadioButton rate44100Hz;
        private System.Windows.Forms.RadioButton rate32000Hz;
        private System.Windows.Forms.RadioButton rate16000Hz;
        private System.Windows.Forms.RadioButton rate8000Hz;
        private System.Windows.Forms.Panel panel2;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.RichTextBox label1;
        private System.Windows.Forms.RadioButton rateManual;
        private System.Windows.Forms.RadioButton rate22050Hz;
        private System.Windows.Forms.NumericUpDown rateManualValue;
    }
}