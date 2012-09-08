namespace LAZYSHELL
{
    partial class SampleEditor
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
            this.sampleName = new System.Windows.Forms.ToolStripComboBox();
            this.sampleNum = new LAZYSHELL.ToolStripNumericUpDown();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.import = new System.Windows.Forms.ToolStripMenuItem();
            this.importBRR = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.export = new System.Windows.Forms.ToolStripMenuItem();
            this.exportBRR = new System.Windows.Forms.ToolStripMenuItem();
            this.clear = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.play = new System.Windows.Forms.ToolStripButton();
            this.pause = new System.Windows.Forms.ToolStripButton();
            this.back = new System.Windows.Forms.ToolStripButton();
            this.foward = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.infiniteLoop = new LAZYSHELL.ToolStripCheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.sampleRateName = new System.Windows.Forms.ComboBox();
            this.rateManualValue = new System.Windows.Forms.NumericUpDown();
            this.rateFixed = new System.Windows.Forms.RadioButton();
            this.rateManual = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.toolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rateManualValue)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sampleName,
            this.sampleNum,
            this.toolStripSeparator4,
            this.toolStripDropDownButton1,
            this.toolStripDropDownButton2,
            this.clear,
            this.toolStripSeparator2,
            this.play,
            this.pause,
            this.back,
            this.foward,
            this.toolStripSeparator1,
            this.infiniteLoop});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(737, 25);
            this.toolStrip1.TabIndex = 0;
            // 
            // sampleName
            // 
            this.sampleName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sampleName.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.sampleName.Name = "sampleName";
            this.sampleName.Size = new System.Drawing.Size(200, 25);
            this.sampleName.SelectedIndexChanged += new System.EventHandler(this.sampleName_SelectedIndexChanged);
            // 
            // sampleNum
            // 
            this.sampleNum.AutoSize = false;
            this.sampleNum.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sampleNum.Hexadecimal = false;
            this.sampleNum.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.sampleNum.Location = new System.Drawing.Point(209, 2);
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
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.import,
            this.importBRR});
            this.toolStripDropDownButton1.Image = global::LAZYSHELL.Properties.Resources.importWAV;
            this.toolStripDropDownButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(27, 22);
            // 
            // import
            // 
            this.import.Image = global::LAZYSHELL.Properties.Resources.importWAV;
            this.import.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.import.Name = "import";
            this.import.Size = new System.Drawing.Size(152, 22);
            this.import.Text = "Import WAV...";
            this.import.Click += new System.EventHandler(this.import_Click);
            // 
            // importBRR
            // 
            this.importBRR.Image = global::LAZYSHELL.Properties.Resources.importBinary;
            this.importBRR.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.importBRR.Name = "importBRR";
            this.importBRR.Size = new System.Drawing.Size(152, 22);
            this.importBRR.Text = "Import BRR...";
            this.importBRR.Click += new System.EventHandler(this.importBRR_Click);
            // 
            // toolStripDropDownButton2
            // 
            this.toolStripDropDownButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.export,
            this.exportBRR});
            this.toolStripDropDownButton2.Image = global::LAZYSHELL.Properties.Resources.exportWAV;
            this.toolStripDropDownButton2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
            this.toolStripDropDownButton2.Size = new System.Drawing.Size(27, 22);
            // 
            // export
            // 
            this.export.Image = global::LAZYSHELL.Properties.Resources.exportWAV;
            this.export.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.export.Name = "export";
            this.export.Size = new System.Drawing.Size(152, 22);
            this.export.Text = "Export WAV...";
            this.export.Click += new System.EventHandler(this.export_Click);
            // 
            // exportBRR
            // 
            this.exportBRR.Image = global::LAZYSHELL.Properties.Resources.exportBinary;
            this.exportBRR.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.exportBRR.Name = "exportBRR";
            this.exportBRR.Size = new System.Drawing.Size(152, 22);
            this.exportBRR.Text = "Export BRR...";
            this.exportBRR.Click += new System.EventHandler(this.exportBRR_Click);
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
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // infiniteLoop
            // 
            this.infiniteLoop.Checked = false;
            this.infiniteLoop.Name = "infiniteLoop";
            this.infiniteLoop.Size = new System.Drawing.Size(85, 22);
            this.infiniteLoop.Text = "Infinite loop";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.sampleRateName);
            this.groupBox1.Controls.Add(this.rateManualValue);
            this.groupBox1.Controls.Add(this.rateFixed);
            this.groupBox1.Controls.Add(this.rateManual);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(104, 115);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sample Rate";
            // 
            // sampleRateName
            // 
            this.sampleRateName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sampleRateName.FormattingEnabled = true;
            this.sampleRateName.Items.AddRange(new object[] {
            "1000 Hz",
            "2000 Hz",
            "4000 Hz",
            "8000 Hz",
            "16000 Hz",
            "32000 Hz",
            "64000 Hz",
            "128000 Hz"});
            this.sampleRateName.Location = new System.Drawing.Point(6, 41);
            this.sampleRateName.Name = "sampleRateName";
            this.sampleRateName.Size = new System.Drawing.Size(92, 21);
            this.sampleRateName.TabIndex = 7;
            this.sampleRateName.SelectedIndexChanged += new System.EventHandler(this.sampleRateName_SelectedIndexChanged);
            // 
            // rateManualValue
            // 
            this.rateManualValue.Enabled = false;
            this.rateManualValue.Location = new System.Drawing.Point(6, 88);
            this.rateManualValue.Maximum = new decimal(new int[] {
            128000,
            0,
            0,
            0});
            this.rateManualValue.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.rateManualValue.Name = "rateManualValue";
            this.rateManualValue.Size = new System.Drawing.Size(92, 21);
            this.rateManualValue.TabIndex = 6;
            this.rateManualValue.Value = new decimal(new int[] {
            32000,
            0,
            0,
            0});
            this.rateManualValue.ValueChanged += new System.EventHandler(this.rateManualValue_ValueChanged);
            // 
            // rateFixed
            // 
            this.rateFixed.AutoSize = true;
            this.rateFixed.Checked = true;
            this.rateFixed.Location = new System.Drawing.Point(6, 20);
            this.rateFixed.Name = "rateFixed";
            this.rateFixed.Size = new System.Drawing.Size(79, 17);
            this.rateFixed.TabIndex = 5;
            this.rateFixed.TabStop = true;
            this.rateFixed.Text = "Fixed Rate:";
            this.rateFixed.UseVisualStyleBackColor = true;
            this.rateFixed.CheckedChanged += new System.EventHandler(this.sampleRate_CheckedChanged);
            // 
            // rateManual
            // 
            this.rateManual.AutoSize = true;
            this.rateManual.Location = new System.Drawing.Point(6, 68);
            this.rateManual.Name = "rateManual";
            this.rateManual.Size = new System.Drawing.Size(54, 17);
            this.rateManual.TabIndex = 5;
            this.rateManual.Text = "Other:";
            this.rateManual.UseVisualStyleBackColor = true;
            this.rateManual.CheckedChanged += new System.EventHandler(this.sampleRate_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(104, 25);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(633, 115);
            this.panel2.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Black;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(629, 111);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.SizeChanged += new System.EventHandler(this.pictureBox1_SizeChanged);
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // SampleEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(737, 140);
            this.ControlBox = false;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "SampleEditor";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rateManualValue)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
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
        private System.Windows.Forms.ToolStripButton clear;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.RadioButton rateManual;
        private System.Windows.Forms.NumericUpDown rateManualValue;
        private System.Windows.Forms.ToolStripComboBox sampleName;
        private System.Windows.Forms.ComboBox sampleRateName;
        private System.Windows.Forms.RadioButton rateFixed;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private ToolStripCheckBox infiniteLoop;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem import;
        private System.Windows.Forms.ToolStripMenuItem importBRR;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton2;
        private System.Windows.Forms.ToolStripMenuItem export;
        private System.Windows.Forms.ToolStripMenuItem exportBRR;
    }
}