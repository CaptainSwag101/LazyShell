namespace LazyShell
{
    partial class About
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(About));
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.copyrightTextBox = new System.Windows.Forms.RichTextBox();
			this.infoTextBox = new System.Windows.Forms.RichTextBox();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.button1 = new System.Windows.Forms.Button();
			this.panel3 = new System.Windows.Forms.Panel();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
			this.panel3.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.SystemColors.ControlText;
			this.panel1.Controls.Add(this.panel2);
			this.panel1.Controls.Add(this.pictureBox2);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(478, 453);
			this.panel1.TabIndex = 0;
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.SystemColors.Control;
			this.panel2.BackgroundImage = global::LazyShell.Properties.Resources.HAMMER;
			this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.panel2.Controls.Add(this.copyrightTextBox);
			this.panel2.Controls.Add(this.infoTextBox);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(0, 56);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(478, 397);
			this.panel2.TabIndex = 0;
			// 
			// copyrightTextBox
			// 
			this.copyrightTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.copyrightTextBox.BackColor = System.Drawing.SystemColors.Control;
			this.copyrightTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.copyrightTextBox.Cursor = System.Windows.Forms.Cursors.Default;
			this.copyrightTextBox.Location = new System.Drawing.Point(65, 7);
			this.copyrightTextBox.Name = "copyrightTextBox";
			this.copyrightTextBox.ReadOnly = true;
			this.copyrightTextBox.Size = new System.Drawing.Size(407, 76);
			this.copyrightTextBox.TabIndex = 1;
			this.copyrightTextBox.Text = "Lazy Shell, Version 4.0.1b\nCopyright © 2007-2015 giangurgolo & Omega\n\nCreated by " +
    "Omega & giangurgolo\nMaintained by CaptainSwag101";
			// 
			// infoTextBox
			// 
			this.infoTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.infoTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.infoTextBox.Location = new System.Drawing.Point(65, 85);
			this.infoTextBox.Name = "infoTextBox";
			this.infoTextBox.ReadOnly = true;
			this.infoTextBox.Size = new System.Drawing.Size(407, 310);
			this.infoTextBox.TabIndex = 0;
			this.infoTextBox.Text = resources.GetString("infoTextBox.Text");
			this.infoTextBox.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.richTextBox1_LinkClicked);
			// 
			// pictureBox2
			// 
			this.pictureBox2.BackgroundImage = global::LazyShell.Properties.Resources.TITLE_BG;
			this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Top;
			this.pictureBox2.Image = global::LazyShell.Properties.Resources.TITLE_FG;
			this.pictureBox2.Location = new System.Drawing.Point(0, 0);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(478, 56);
			this.pictureBox2.TabIndex = 314;
			this.pictureBox2.TabStop = false;
			// 
			// button1
			// 
			this.button1.BackColor = System.Drawing.SystemColors.Control;
			this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.button1.FlatAppearance.BorderSize = 0;
			this.button1.Location = new System.Drawing.Point(0, 0);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(478, 23);
			this.button1.TabIndex = 1;
			this.button1.Text = "Close";
			this.button1.UseVisualStyleBackColor = false;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.button1);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel3.Location = new System.Drawing.Point(0, 453);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(478, 23);
			this.panel3.TabIndex = 3;
			// 
			// About
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(478, 476);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.panel3);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Location = new System.Drawing.Point(100, 100);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "About";
			this.ShowInTaskbar = false;
			this.Text = "About Lazy Shell...";
			this.Load += new System.EventHandler(this.About_Load);
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
			this.panel3.ResumeLayout(false);
			this.ResumeLayout(false);

        }
        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RichTextBox infoTextBox;
        private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.RichTextBox copyrightTextBox;
	}
}