namespace LazyShell.Effects
{
    partial class PropertiesForm
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
			this.yNegShift = new System.Windows.Forms.NumericUpDown();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.e_codec = new System.Windows.Forms.ComboBox();
			this.e_availableBytes = new System.Windows.Forms.Label();
			this.label89 = new System.Windows.Forms.Label();
			this.graphicSetSize = new System.Windows.Forms.NumericUpDown();
			this.label90 = new System.Windows.Forms.Label();
			this.e_paletteSetSize = new System.Windows.Forms.NumericUpDown();
			this.label107 = new System.Windows.Forms.Label();
			this.label96 = new System.Windows.Forms.Label();
			this.xNegShift = new System.Windows.Forms.NumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			this.e_paletteIndex = new System.Windows.Forms.NumericUpDown();
			this.imageNum = new System.Windows.Forms.NumericUpDown();
			this.label7 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.yNegShift)).BeginInit();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.graphicSetSize)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.e_paletteSetSize)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.xNegShift)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.e_paletteIndex)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.imageNum)).BeginInit();
			this.SuspendLayout();
			// 
			// yNegShift
			// 
			this.yNegShift.Location = new System.Drawing.Point(125, 7);
			this.yNegShift.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
			this.yNegShift.Name = "yNegShift";
			this.yNegShift.Size = new System.Drawing.Size(43, 20);
			this.yNegShift.TabIndex = 15;
			this.yNegShift.ValueChanged += new System.EventHandler(this.yNegShift_ValueChanged);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.e_codec);
			this.groupBox1.Controls.Add(this.e_availableBytes);
			this.groupBox1.Controls.Add(this.label89);
			this.groupBox1.Controls.Add(this.graphicSetSize);
			this.groupBox1.Controls.Add(this.label90);
			this.groupBox1.Controls.Add(this.e_paletteSetSize);
			this.groupBox1.Controls.Add(this.label107);
			this.groupBox1.Location = new System.Drawing.Point(3, 76);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(172, 109);
			this.groupBox1.TabIndex = 12;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Image Settings";
			// 
			// e_codec
			// 
			this.e_codec.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.e_codec.FormattingEnabled = true;
			this.e_codec.Items.AddRange(new object[] {
            "4bpp",
            "2bpp"});
			this.e_codec.Location = new System.Drawing.Point(79, 82);
			this.e_codec.Name = "e_codec";
			this.e_codec.Size = new System.Drawing.Size(86, 21);
			this.e_codec.TabIndex = 6;
			this.e_codec.SelectedIndexChanged += new System.EventHandler(this.e_codec_SelectedIndexChanged);
			// 
			// e_availableBytes
			// 
			this.e_availableBytes.BackColor = System.Drawing.Color.Lime;
			this.e_availableBytes.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.e_availableBytes.ForeColor = System.Drawing.SystemColors.ControlText;
			this.e_availableBytes.Location = new System.Drawing.Point(6, 17);
			this.e_availableBytes.Name = "e_availableBytes";
			this.e_availableBytes.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
			this.e_availableBytes.Size = new System.Drawing.Size(159, 20);
			this.e_availableBytes.TabIndex = 0;
			this.e_availableBytes.Text = "0 bytes free";
			this.e_availableBytes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label89
			// 
			this.label89.AutoSize = true;
			this.label89.Location = new System.Drawing.Point(6, 63);
			this.label89.Name = "label89";
			this.label89.Size = new System.Drawing.Size(67, 13);
			this.label89.TabIndex = 3;
			this.label89.Text = "Graphic Size";
			// 
			// graphicSetSize
			// 
			this.graphicSetSize.Increment = new decimal(new int[] {
            32,
            0,
            0,
            0});
			this.graphicSetSize.Location = new System.Drawing.Point(79, 61);
			this.graphicSetSize.Maximum = new decimal(new int[] {
            8192,
            0,
            0,
            0});
			this.graphicSetSize.Minimum = new decimal(new int[] {
            16,
            0,
            0,
            0});
			this.graphicSetSize.Name = "graphicSetSize";
			this.graphicSetSize.Size = new System.Drawing.Size(86, 20);
			this.graphicSetSize.TabIndex = 4;
			this.graphicSetSize.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
			this.graphicSetSize.ValueChanged += new System.EventHandler(this.e_graphicSetSize_ValueChanged);
			// 
			// label90
			// 
			this.label90.AutoSize = true;
			this.label90.Location = new System.Drawing.Point(6, 84);
			this.label90.Name = "label90";
			this.label90.Size = new System.Drawing.Size(62, 13);
			this.label90.TabIndex = 5;
			this.label90.Text = "BPP Codec";
			// 
			// e_paletteSetSize
			// 
			this.e_paletteSetSize.Increment = new decimal(new int[] {
            32,
            0,
            0,
            0});
			this.e_paletteSetSize.Location = new System.Drawing.Point(79, 40);
			this.e_paletteSetSize.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
			this.e_paletteSetSize.Minimum = new decimal(new int[] {
            32,
            0,
            0,
            0});
			this.e_paletteSetSize.Name = "e_paletteSetSize";
			this.e_paletteSetSize.Size = new System.Drawing.Size(86, 20);
			this.e_paletteSetSize.TabIndex = 2;
			this.e_paletteSetSize.Value = new decimal(new int[] {
            32,
            0,
            0,
            0});
			this.e_paletteSetSize.ValueChanged += new System.EventHandler(this.e_paletteSetSize_ValueChanged);
			// 
			// label107
			// 
			this.label107.AutoSize = true;
			this.label107.Location = new System.Drawing.Point(6, 42);
			this.label107.Name = "label107";
			this.label107.Size = new System.Drawing.Size(63, 13);
			this.label107.TabIndex = 1;
			this.label107.Text = "Palette Size";
			// 
			// label96
			// 
			this.label96.AutoSize = true;
			this.label96.Location = new System.Drawing.Point(12, 9);
			this.label96.Name = "label96";
			this.label96.Size = new System.Drawing.Size(30, 13);
			this.label96.TabIndex = 13;
			this.label96.Text = "(X,Y)";
			// 
			// xNegShift
			// 
			this.xNegShift.Location = new System.Drawing.Point(82, 7);
			this.xNegShift.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
			this.xNegShift.Name = "xNegShift";
			this.xNegShift.Size = new System.Drawing.Size(43, 20);
			this.xNegShift.TabIndex = 14;
			this.xNegShift.ValueChanged += new System.EventHandler(this.xNegShift_ValueChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 51);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(36, 13);
			this.label2.TabIndex = 8;
			this.label2.Text = "Image";
			// 
			// e_paletteIndex
			// 
			this.e_paletteIndex.Location = new System.Drawing.Point(82, 28);
			this.e_paletteIndex.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
			this.e_paletteIndex.Name = "e_paletteIndex";
			this.e_paletteIndex.Size = new System.Drawing.Size(86, 20);
			this.e_paletteIndex.TabIndex = 11;
			this.e_paletteIndex.ValueChanged += new System.EventHandler(this.e_paletteIndex_ValueChanged);
			// 
			// imageNum
			// 
			this.imageNum.Location = new System.Drawing.Point(82, 49);
			this.imageNum.Maximum = new decimal(new int[] {
            63,
            0,
            0,
            0});
			this.imageNum.Name = "imageNum";
			this.imageNum.Size = new System.Drawing.Size(86, 20);
			this.imageNum.TabIndex = 9;
			this.imageNum.ValueChanged += new System.EventHandler(this.imageNum_ValueChanged);
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(12, 30);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(40, 13);
			this.label7.TabIndex = 10;
			this.label7.Text = "Palette";
			// 
			// PropertiesForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(179, 189);
			this.Controls.Add(this.yNegShift);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.label96);
			this.Controls.Add(this.xNegShift);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.e_paletteIndex);
			this.Controls.Add(this.imageNum);
			this.Controls.Add(this.label7);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Location = new System.Drawing.Point(0, 0);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "PropertiesForm";
			this.Text = "Effect Settings";
			((System.ComponentModel.ISupportInitialize)(this.yNegShift)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.graphicSetSize)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.e_paletteSetSize)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.xNegShift)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.e_paletteIndex)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.imageNum)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown yNegShift;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox e_codec;
        private System.Windows.Forms.Label e_availableBytes;
        private System.Windows.Forms.Label label89;
        private System.Windows.Forms.NumericUpDown graphicSetSize;
        private System.Windows.Forms.Label label90;
        private System.Windows.Forms.NumericUpDown e_paletteSetSize;
        private System.Windows.Forms.Label label107;
        private System.Windows.Forms.Label label96;
        private System.Windows.Forms.NumericUpDown xNegShift;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown e_paletteIndex;
        private System.Windows.Forms.NumericUpDown imageNum;
        private System.Windows.Forms.Label label7;
    }
}