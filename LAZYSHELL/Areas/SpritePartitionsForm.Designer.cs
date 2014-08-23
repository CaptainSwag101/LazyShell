
namespace LAZYSHELL.Areas
{
    partial class SpritePartitionsForm
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
            this.byte3 = new System.Windows.Forms.CheckBox();
            this.byte2a = new System.Windows.Forms.ComboBox();
            this.byte3a = new System.Windows.Forms.ComboBox();
            this.byte2b = new System.Windows.Forms.ComboBox();
            this.byte3b = new System.Windows.Forms.ComboBox();
            this.extraSpriteBuffer = new System.Windows.Forms.NumericUpDown();
            this.allyCount = new System.Windows.Forms.NumericUpDown();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.byte4a = new System.Windows.Forms.ComboBox();
            this.byte4b = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.byte4 = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.byte2 = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.noWaterPalettes = new System.Windows.Forms.CheckBox();
            this.extraSprites = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.partitionNum = new System.Windows.Forms.NumericUpDown();
            this.buttonOK = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.headerLabel1 = new LAZYSHELL.Controls.HeaderLabel();
            this.headerLabel2 = new LAZYSHELL.Controls.HeaderLabel();
            this.headerLabel3 = new LAZYSHELL.Controls.HeaderLabel();
            this.headerLabel4 = new LAZYSHELL.Controls.HeaderLabel();
            ((System.ComponentModel.ISupportInitialize)(this.extraSpriteBuffer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.allyCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.partitionNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // byte3
            // 
            this.byte3.AutoSize = true;
            this.byte3.Location = new System.Drawing.Point(7, 271);
            this.byte3.Name = "byte3";
            this.byte3.Size = new System.Drawing.Size(166, 17);
            this.byte3.TabIndex = 4;
            this.byte3.Text = "Sprite indexing in main buffer";
            this.byte3.UseVisualStyleBackColor = false;
            this.byte3.CheckedChanged += new System.EventHandler(this.byte3_CheckedChanged);
            // 
            // byte2a
            // 
            this.byte2a.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.byte2a.IntegralHeight = false;
            this.byte2a.Items.AddRange(new object[] {
            "3 sprites per row",
            "4 sprites per row",
            "treasure chest",
            "empty treasure chest",
            "coins",
            "empty buffer",
            "empty buffer",
            "empty buffer"});
            this.byte2a.Location = new System.Drawing.Point(149, 138);
            this.byte2a.Name = "byte2a";
            this.byte2a.Size = new System.Drawing.Size(124, 21);
            this.byte2a.TabIndex = 1;
            this.byte2a.SelectedIndexChanged += new System.EventHandler(this.byte2a_SelectedIndexChanged);
            // 
            // byte3a
            // 
            this.byte3a.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.byte3a.IntegralHeight = false;
            this.byte3a.Items.AddRange(new object[] {
            "3 sprites per row",
            "4 sprites per row",
            "treasure chest",
            "empty treasure chest",
            "coins",
            "empty buffer",
            "empty buffer",
            "empty buffer"});
            this.byte3a.Location = new System.Drawing.Point(149, 223);
            this.byte3a.Name = "byte3a";
            this.byte3a.Size = new System.Drawing.Size(124, 21);
            this.byte3a.TabIndex = 1;
            this.byte3a.SelectedIndexChanged += new System.EventHandler(this.byte3a_SelectedIndexChanged);
            // 
            // byte2b
            // 
            this.byte2b.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.byte2b.Items.AddRange(new object[] {
            "0 bytes",
            "256 bytes",
            "512 bytes",
            "768 bytes",
            "1024 bytes",
            "1280 bytes",
            "1536 bytes",
            "1792 bytes"});
            this.byte2b.Location = new System.Drawing.Point(149, 159);
            this.byte2b.Name = "byte2b";
            this.byte2b.Size = new System.Drawing.Size(124, 21);
            this.byte2b.TabIndex = 3;
            this.byte2b.SelectedIndexChanged += new System.EventHandler(this.byte2b_SelectedIndexChanged);
            // 
            // byte3b
            // 
            this.byte3b.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.byte3b.Items.AddRange(new object[] {
            "0 bytes",
            "256 bytes",
            "512 bytes",
            "768 bytes",
            "1024 bytes",
            "1280 bytes",
            "1536 bytes",
            "1792 bytes"});
            this.byte3b.Location = new System.Drawing.Point(149, 244);
            this.byte3b.Name = "byte3b";
            this.byte3b.Size = new System.Drawing.Size(124, 21);
            this.byte3b.TabIndex = 3;
            this.byte3b.SelectedIndexChanged += new System.EventHandler(this.byte3b_SelectedIndexChanged);
            // 
            // extraSpriteBuffer
            // 
            this.extraSpriteBuffer.Enabled = false;
            this.extraSpriteBuffer.Location = new System.Drawing.Point(160, 98);
            this.extraSpriteBuffer.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.extraSpriteBuffer.Name = "extraSpriteBuffer";
            this.extraSpriteBuffer.Size = new System.Drawing.Size(113, 21);
            this.extraSpriteBuffer.TabIndex = 4;
            this.extraSpriteBuffer.ValueChanged += new System.EventHandler(this.extraSpriteBuffer_ValueChanged);
            // 
            // allyCount
            // 
            this.allyCount.Location = new System.Drawing.Point(160, 48);
            this.allyCount.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.allyCount.Name = "allyCount";
            this.allyCount.Size = new System.Drawing.Size(113, 21);
            this.allyCount.TabIndex = 1;
            this.allyCount.ValueChanged += new System.EventHandler(this.allyCount_ValueChanged);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(201, 402);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(63, 23);
            this.buttonCancel.TabIndex = 10;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // byte4a
            // 
            this.byte4a.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.byte4a.IntegralHeight = false;
            this.byte4a.Items.AddRange(new object[] {
            "3 sprites per row",
            "4 sprites per row",
            "treasure chest",
            "empty treasure chest",
            "coins",
            "empty buffer",
            "empty buffer",
            "empty buffer"});
            this.byte4a.Location = new System.Drawing.Point(149, 308);
            this.byte4a.Name = "byte4a";
            this.byte4a.Size = new System.Drawing.Size(124, 21);
            this.byte4a.TabIndex = 1;
            this.byte4a.SelectedIndexChanged += new System.EventHandler(this.byte4a_SelectedIndexChanged);
            // 
            // byte4b
            // 
            this.byte4b.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.byte4b.Items.AddRange(new object[] {
            "0 bytes",
            "256 bytes",
            "512 bytes",
            "768 bytes",
            "1024 bytes",
            "1280 bytes",
            "1536 bytes",
            "1792 bytes"});
            this.byte4b.Location = new System.Drawing.Point(149, 329);
            this.byte4b.Name = "byte4b";
            this.byte4b.Size = new System.Drawing.Size(124, 21);
            this.byte4b.TabIndex = 3;
            this.byte4b.SelectedIndexChanged += new System.EventHandler(this.byte4b_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 332);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(114, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = "Use main buffer space";
            // 
            // byte4
            // 
            this.byte4.AutoSize = true;
            this.byte4.Location = new System.Drawing.Point(7, 356);
            this.byte4.Name = "byte4";
            this.byte4.Size = new System.Drawing.Size(166, 17);
            this.byte4.TabIndex = 4;
            this.byte4.Text = "Sprite indexing in main buffer";
            this.byte4.UseVisualStyleBackColor = true;
            this.byte4.CheckedChanged += new System.EventHandler(this.byte4_CheckedChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 311);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Buffer type";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 162);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Use main buffer space";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 141);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Buffer type";
            // 
            // byte2
            // 
            this.byte2.AutoSize = true;
            this.byte2.Location = new System.Drawing.Point(7, 186);
            this.byte2.Name = "byte2";
            this.byte2.Size = new System.Drawing.Size(166, 17);
            this.byte2.TabIndex = 4;
            this.byte2.Text = "Sprite indexing in main buffer";
            this.byte2.UseVisualStyleBackColor = false;
            this.byte2.CheckedChanged += new System.EventHandler(this.byte2_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 247);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(114, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Use main buffer space";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 226);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Buffer type";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Ally sprite buffer size";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Extra sprite buffer size";
            // 
            // noWaterPalettes
            // 
            this.noWaterPalettes.AutoSize = true;
            this.noWaterPalettes.Location = new System.Drawing.Point(7, 379);
            this.noWaterPalettes.Name = "noWaterPalettes";
            this.noWaterPalettes.Size = new System.Drawing.Size(245, 17);
            this.noWaterPalettes.TabIndex = 6;
            this.noWaterPalettes.Text = "8-row palette buffer (no underwater allowed)";
            this.noWaterPalettes.UseVisualStyleBackColor = false;
            this.noWaterPalettes.CheckedChanged += new System.EventHandler(this.noWaterPalettes_CheckedChanged);
            // 
            // extraSprites
            // 
            this.extraSprites.AutoSize = true;
            this.extraSprites.Location = new System.Drawing.Point(7, 76);
            this.extraSprites.Name = "extraSprites";
            this.extraSprites.Size = new System.Drawing.Size(246, 17);
            this.extraSprites.TabIndex = 2;
            this.extraSprites.Text = "Extra sprite buffer (clouds, level-up text, etc)";
            this.extraSprites.UseVisualStyleBackColor = false;
            this.extraSprites.CheckedChanged += new System.EventHandler(this.extraSprites_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Partition #";
            // 
            // partitionNum
            // 
            this.partitionNum.Location = new System.Drawing.Point(73, 7);
            this.partitionNum.Maximum = new decimal(new int[] {
            119,
            0,
            0,
            0});
            this.partitionNum.Name = "partitionNum";
            this.partitionNum.Size = new System.Drawing.Size(58, 21);
            this.partitionNum.TabIndex = 1;
            this.partitionNum.ValueChanged += new System.EventHandler(this.partitionNum_ValueChanged);
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(132, 402);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(63, 23);
            this.buttonOK.TabIndex = 9;
            this.buttonOK.Text = "OK";
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::LAZYSHELL.Properties.Resources._transparent;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(128, 256);
            this.pictureBox1.TabIndex = 507;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(276, 33);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(132, 260);
            this.panel1.TabIndex = 8;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label10.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.Control;
            this.label10.Location = new System.Drawing.Point(276, 9);
            this.label10.Name = "label10";
            this.label10.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.label10.Size = new System.Drawing.Size(132, 23);
            this.label10.TabIndex = 7;
            this.label10.Text = "VRAM PREVIEW";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // headerLabel1
            // 
            this.headerLabel1.Location = new System.Drawing.Point(0, 31);
            this.headerLabel1.Name = "headerLabel1";
            this.headerLabel1.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.headerLabel1.Size = new System.Drawing.Size(276, 14);
            this.headerLabel1.TabIndex = 29;
            this.headerLabel1.Text = "Main Buffer";
            // 
            // headerLabel2
            // 
            this.headerLabel2.Location = new System.Drawing.Point(0, 121);
            this.headerLabel2.Name = "headerLabel2";
            this.headerLabel2.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.headerLabel2.Size = new System.Drawing.Size(276, 14);
            this.headerLabel2.TabIndex = 29;
            this.headerLabel2.Text = "Clone Buffer A";
            // 
            // headerLabel3
            // 
            this.headerLabel3.Location = new System.Drawing.Point(0, 206);
            this.headerLabel3.Name = "headerLabel3";
            this.headerLabel3.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.headerLabel3.Size = new System.Drawing.Size(276, 14);
            this.headerLabel3.TabIndex = 29;
            this.headerLabel3.Text = "Clone Buffer B";
            // 
            // headerLabel4
            // 
            this.headerLabel4.Location = new System.Drawing.Point(0, 291);
            this.headerLabel4.Name = "headerLabel4";
            this.headerLabel4.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.headerLabel4.Size = new System.Drawing.Size(276, 14);
            this.headerLabel4.TabIndex = 29;
            this.headerLabel4.Text = "Clone Buffer C";
            // 
            // SpritePartitionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(276, 434);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.byte4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.byte4a);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.byte3b);
            this.Controls.Add(this.byte4b);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.byte3a);
            this.Controls.Add(this.byte3);
            this.Controls.Add(this.headerLabel4);
            this.Controls.Add(this.headerLabel3);
            this.Controls.Add(this.headerLabel2);
            this.Controls.Add(this.byte2b);
            this.Controls.Add(this.headerLabel1);
            this.Controls.Add(this.byte2a);
            this.Controls.Add(this.byte2);
            this.Controls.Add(this.extraSprites);
            this.Controls.Add(this.allyCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.extraSpriteBuffer);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.partitionNum);
            this.Controls.Add(this.noWaterPalettes);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.buttonCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Location = new System.Drawing.Point(0, 0);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SpritePartitionsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "PARTITIONS - Lazy Shell";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.extraSpriteBuffer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.allyCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.partitionNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox byte3;
        private System.Windows.Forms.ComboBox byte2a;
        private System.Windows.Forms.ComboBox byte3a;
        private System.Windows.Forms.ComboBox byte2b;
        private System.Windows.Forms.ComboBox byte3b;
        private System.Windows.Forms.NumericUpDown extraSpriteBuffer;
        private System.Windows.Forms.NumericUpDown allyCount;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.ComboBox byte4a;
        private System.Windows.Forms.ComboBox byte4b;
        private System.Windows.Forms.CheckBox byte4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown partitionNum;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox byte2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox noWaterPalettes;
        private System.Windows.Forms.CheckBox extraSprites;
        private Controls.HeaderLabel headerLabel1;
        private Controls.HeaderLabel headerLabel2;
        private Controls.HeaderLabel headerLabel3;
        private Controls.HeaderLabel headerLabel4;
    }
}