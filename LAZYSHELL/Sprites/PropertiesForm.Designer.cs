namespace LAZYSHELL.Sprites
{
    partial class PropertiesForm
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
            this.paletteIndex = new System.Windows.Forms.NumericUpDown();
            this.label71 = new System.Windows.Forms.Label();
            this.label73 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.paletteOffset = new System.Windows.Forms.NumericUpDown();
            this.graphicOffset = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.label72 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.animationAvailableBytes = new System.Windows.Forms.Label();
            this.animationVRAM = new System.Windows.Forms.NumericUpDown();
            this.imageNum = new System.Windows.Forms.NumericUpDown();
            this.animationPacket = new System.Windows.Forms.NumericUpDown();
            this.findReferencesAnimation = new System.Windows.Forms.Button();
            this.findReferencesImage = new System.Windows.Forms.Button();
            this.headerLabel2 = new LAZYSHELL.Controls.HeaderLabel();
            this.headerLabel1 = new LAZYSHELL.Controls.HeaderLabel();
            ((System.ComponentModel.ISupportInitialize)(this.paletteIndex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.paletteOffset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.graphicOffset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.animationVRAM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.animationPacket)).BeginInit();
            this.SuspendLayout();
            // 
            // paletteIndex
            // 
            this.paletteIndex.Location = new System.Drawing.Point(71, 7);
            this.paletteIndex.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.paletteIndex.Name = "paletteIndex";
            this.paletteIndex.Size = new System.Drawing.Size(76, 21);
            this.paletteIndex.TabIndex = 11;
            // 
            // label71
            // 
            this.label71.AutoSize = true;
            this.label71.Location = new System.Drawing.Point(5, 30);
            this.label71.Name = "label71";
            this.label71.Size = new System.Drawing.Size(37, 13);
            this.label71.TabIndex = 8;
            this.label71.Text = "Image";
            // 
            // label73
            // 
            this.label73.AutoSize = true;
            this.label73.Location = new System.Drawing.Point(5, 9);
            this.label73.Name = "label73";
            this.label73.Size = new System.Drawing.Size(41, 13);
            this.label73.TabIndex = 10;
            this.label73.Text = "Palette";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(5, 72);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(60, 13);
            this.label23.TabIndex = 0;
            this.label23.Text = "Palette Set";
            // 
            // paletteOffset
            // 
            this.paletteOffset.Location = new System.Drawing.Point(71, 70);
            this.paletteOffset.Maximum = new decimal(new int[] {
            818,
            0,
            0,
            0});
            this.paletteOffset.Name = "paletteOffset";
            this.paletteOffset.Size = new System.Drawing.Size(104, 21);
            this.paletteOffset.TabIndex = 1;
            // 
            // graphicOffset
            // 
            this.graphicOffset.Hexadecimal = true;
            this.graphicOffset.Increment = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.graphicOffset.Location = new System.Drawing.Point(71, 91);
            this.graphicOffset.Maximum = new decimal(new int[] {
            3342320,
            0,
            0,
            0});
            this.graphicOffset.Minimum = new decimal(new int[] {
            2621440,
            0,
            0,
            0});
            this.graphicOffset.Name = "graphicOffset";
            this.graphicOffset.Size = new System.Drawing.Size(104, 21);
            this.graphicOffset.TabIndex = 3;
            this.graphicOffset.Value = new decimal(new int[] {
            2621440,
            0,
            0,
            0});
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(5, 93);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = "GFX Offset";
            // 
            // label72
            // 
            this.label72.AutoSize = true;
            this.label72.Location = new System.Drawing.Point(5, 134);
            this.label72.Name = "label72";
            this.label72.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label72.Size = new System.Drawing.Size(56, 16);
            this.label72.TabIndex = 13;
            this.label72.Text = "Animation";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(5, 182);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(57, 13);
            this.label18.TabIndex = 1;
            this.label18.Text = "VRAM Size";
            // 
            // animationAvailableBytes
            // 
            this.animationAvailableBytes.BackColor = System.Drawing.Color.Lime;
            this.animationAvailableBytes.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.animationAvailableBytes.ForeColor = System.Drawing.SystemColors.ControlText;
            this.animationAvailableBytes.Location = new System.Drawing.Point(0, 157);
            this.animationAvailableBytes.Name = "animationAvailableBytes";
            this.animationAvailableBytes.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.animationAvailableBytes.Size = new System.Drawing.Size(180, 20);
            this.animationAvailableBytes.TabIndex = 0;
            this.animationAvailableBytes.Text = "0 bytes free";
            this.animationAvailableBytes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // animationVRAM
            // 
            this.animationVRAM.Increment = new decimal(new int[] {
            2048,
            0,
            0,
            0});
            this.animationVRAM.Location = new System.Drawing.Point(71, 180);
            this.animationVRAM.Maximum = new decimal(new int[] {
            8192,
            0,
            0,
            0});
            this.animationVRAM.Minimum = new decimal(new int[] {
            2048,
            0,
            0,
            0});
            this.animationVRAM.Name = "animationVRAM";
            this.animationVRAM.Size = new System.Drawing.Size(104, 21);
            this.animationVRAM.TabIndex = 2;
            this.animationVRAM.Value = new decimal(new int[] {
            2048,
            0,
            0,
            0});
            // 
            // imageNum
            // 
            this.imageNum.Location = new System.Drawing.Point(71, 28);
            this.imageNum.Maximum = new decimal(new int[] {
            511,
            0,
            0,
            0});
            this.imageNum.Name = "imageNum";
            this.imageNum.Size = new System.Drawing.Size(76, 21);
            this.imageNum.TabIndex = 9;
            // 
            // animationPacket
            // 
            this.animationPacket.Location = new System.Drawing.Point(71, 132);
            this.animationPacket.Maximum = new decimal(new int[] {
            443,
            0,
            0,
            0});
            this.animationPacket.Name = "animationPacket";
            this.animationPacket.Size = new System.Drawing.Size(76, 21);
            this.animationPacket.TabIndex = 14;
            // 
            // findReferencesAnimation
            // 
            this.findReferencesAnimation.AutoSize = true;
            this.findReferencesAnimation.FlatAppearance.BorderSize = 0;
            this.findReferencesAnimation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.findReferencesAnimation.Image = global::LAZYSHELL.Properties.Resources.find_references;
            this.findReferencesAnimation.Location = new System.Drawing.Point(153, 132);
            this.findReferencesAnimation.Name = "findReferencesAnimation";
            this.findReferencesAnimation.Size = new System.Drawing.Size(22, 22);
            this.findReferencesAnimation.TabIndex = 16;
            this.findReferencesAnimation.UseVisualStyleBackColor = true;
            this.findReferencesAnimation.Click += new System.EventHandler(this.findReferencesAnimation_Click);
            // 
            // findReferencesImage
            // 
            this.findReferencesImage.AutoSize = true;
            this.findReferencesImage.FlatAppearance.BorderSize = 0;
            this.findReferencesImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.findReferencesImage.Image = global::LAZYSHELL.Properties.Resources.find_references;
            this.findReferencesImage.Location = new System.Drawing.Point(150, 27);
            this.findReferencesImage.Name = "findReferencesImage";
            this.findReferencesImage.Size = new System.Drawing.Size(22, 22);
            this.findReferencesImage.TabIndex = 16;
            this.findReferencesImage.UseVisualStyleBackColor = true;
            this.findReferencesImage.Click += new System.EventHandler(this.findReferencesImage_Click);
            // 
            // headerLabel2
            // 
            this.headerLabel2.Location = new System.Drawing.Point(0, 53);
            this.headerLabel2.Name = "headerLabel2";
            this.headerLabel2.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.headerLabel2.Size = new System.Drawing.Size(180, 14);
            this.headerLabel2.TabIndex = 17;
            this.headerLabel2.Text = "Image Settings";
            // 
            // headerLabel1
            // 
            this.headerLabel1.Location = new System.Drawing.Point(0, 115);
            this.headerLabel1.Name = "headerLabel1";
            this.headerLabel1.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.headerLabel1.Size = new System.Drawing.Size(180, 14);
            this.headerLabel1.TabIndex = 17;
            this.headerLabel1.Text = "Animation Properties";
            // 
            // PropertiesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(179, 206);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.animationVRAM);
            this.Controls.Add(this.animationAvailableBytes);
            this.Controls.Add(this.headerLabel1);
            this.Controls.Add(this.headerLabel2);
            this.Controls.Add(this.paletteOffset);
            this.Controls.Add(this.findReferencesImage);
            this.Controls.Add(this.graphicOffset);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.findReferencesAnimation);
            this.Controls.Add(this.paletteIndex);
            this.Controls.Add(this.label71);
            this.Controls.Add(this.label73);
            this.Controls.Add(this.label72);
            this.Controls.Add(this.imageNum);
            this.Controls.Add(this.animationPacket);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "PropertiesForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "SPRITE SETTINGS";
            ((System.ComponentModel.ISupportInitialize)(this.paletteIndex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.paletteOffset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.graphicOffset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.animationVRAM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.animationPacket)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown paletteIndex;
        private System.Windows.Forms.Label label71;
        private System.Windows.Forms.Label label73;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.NumericUpDown paletteOffset;
        private System.Windows.Forms.NumericUpDown graphicOffset;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label72;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label animationAvailableBytes;
        private System.Windows.Forms.NumericUpDown animationVRAM;
        private System.Windows.Forms.NumericUpDown imageNum;
        private System.Windows.Forms.NumericUpDown animationPacket;
        private System.Windows.Forms.Button findReferencesAnimation;
        private System.Windows.Forms.Button findReferencesImage;
        private Controls.HeaderLabel headerLabel2;
        private Controls.HeaderLabel headerLabel1;
    }
}