
namespace LAZYSHELL.Patches
{
    partial class PatchesForm
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
            this.ImagePictureBox = new System.Windows.Forms.PictureBox();
            this.listBox = new System.Windows.Forms.ListBox();
            this.AuthorLabel = new System.Windows.Forms.Label();
            this.DateCreatedLabel = new System.Windows.Forms.Label();
            this.PatchNameLabel = new System.Windows.Forms.Label();
            this.SizeLabel = new System.Windows.Forms.Label();
            this.applyButton = new System.Windows.Forms.Button();
            this.downloadingLabel = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.clock = new System.ComponentModel.BackgroundWorker();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.labelDate = new System.Windows.Forms.Label();
            this.labelSize = new System.Windows.Forms.Label();
            this.labelAuthor = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.gameHack = new System.Windows.Forms.CheckBox();
            this.freshROM = new System.Windows.Forms.CheckBox();
            this.assemblyHack = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.textBox1 = new System.Windows.Forms.RichTextBox();
            this.panelPatch = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.ImagePictureBox)).BeginInit();
            this.panel3.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.panelPatch.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ImagePictureBox
            // 
            this.ImagePictureBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.ImagePictureBox.Location = new System.Drawing.Point(0, 0);
            this.ImagePictureBox.Name = "ImagePictureBox";
            this.ImagePictureBox.Size = new System.Drawing.Size(256, 224);
            this.ImagePictureBox.TabIndex = 2;
            this.ImagePictureBox.TabStop = false;
            // 
            // listBox
            // 
            this.listBox.FormattingEnabled = true;
            this.listBox.HorizontalScrollbar = true;
            this.listBox.IntegralHeight = false;
            this.listBox.Location = new System.Drawing.Point(6, 6);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(147, 254);
            this.listBox.TabIndex = 0;
            this.listBox.SelectedIndexChanged += new System.EventHandler(this.listBox_SelectedIndexChanged);
            // 
            // AuthorLabel
            // 
            this.AuthorLabel.AutoSize = true;
            this.AuthorLabel.Location = new System.Drawing.Point(142, 347);
            this.AuthorLabel.Name = "AuthorLabel";
            this.AuthorLabel.Size = new System.Drawing.Size(0, 13);
            this.AuthorLabel.TabIndex = 4;
            // 
            // DateCreatedLabel
            // 
            this.DateCreatedLabel.AutoSize = true;
            this.DateCreatedLabel.Location = new System.Drawing.Point(142, 360);
            this.DateCreatedLabel.Name = "DateCreatedLabel";
            this.DateCreatedLabel.Size = new System.Drawing.Size(0, 13);
            this.DateCreatedLabel.TabIndex = 5;
            // 
            // PatchNameLabel
            // 
            this.PatchNameLabel.AutoSize = true;
            this.PatchNameLabel.Location = new System.Drawing.Point(142, 334);
            this.PatchNameLabel.Name = "PatchNameLabel";
            this.PatchNameLabel.Size = new System.Drawing.Size(0, 13);
            this.PatchNameLabel.TabIndex = 7;
            // 
            // SizeLabel
            // 
            this.SizeLabel.AutoSize = true;
            this.SizeLabel.Location = new System.Drawing.Point(142, 373);
            this.SizeLabel.Name = "SizeLabel";
            this.SizeLabel.Size = new System.Drawing.Size(0, 13);
            this.SizeLabel.TabIndex = 8;
            // 
            // applyButton
            // 
            this.applyButton.Enabled = false;
            this.applyButton.Location = new System.Drawing.Point(6, 266);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(147, 21);
            this.applyButton.TabIndex = 1;
            this.applyButton.Text = "APPLY PATCH";
            this.applyButton.UseCompatibleTextRendering = true;
            this.applyButton.UseVisualStyleBackColor = false;
            this.applyButton.Click += new System.EventHandler(this.applyButton_Click);
            // 
            // downloadingLabel
            // 
            this.downloadingLabel.Location = new System.Drawing.Point(187, 117);
            this.downloadingLabel.Name = "downloadingLabel";
            this.downloadingLabel.Size = new System.Drawing.Size(176, 21);
            this.downloadingLabel.TabIndex = 3;
            this.downloadingLabel.Text = "Initializing...";
            this.downloadingLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.ImagePictureBox);
            this.panel3.Location = new System.Drawing.Point(8, 22);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(256, 224);
            this.panel3.TabIndex = 4;
            // 
            // clock
            // 
            this.clock.WorkerReportsProgress = true;
            this.clock.WorkerSupportsCancellation = true;
            this.clock.DoWork += new System.ComponentModel.DoWorkEventHandler(this.clock_DoWork);
            this.clock.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.clock_ProgressChanged);
            this.clock.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.clock_RunWorkerCompleted);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.panel3);
            this.groupBox3.Location = new System.Drawing.Point(278, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(272, 254);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Screen";
            // 
            // labelDate
            // 
            this.labelDate.AutoSize = true;
            this.labelDate.Location = new System.Drawing.Point(6, 55);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(34, 13);
            this.labelDate.TabIndex = 12;
            this.labelDate.Text = "Date:";
            // 
            // labelSize
            // 
            this.labelSize.AutoSize = true;
            this.labelSize.Location = new System.Drawing.Point(6, 74);
            this.labelSize.Name = "labelSize";
            this.labelSize.Size = new System.Drawing.Size(30, 13);
            this.labelSize.TabIndex = 12;
            this.labelSize.Text = "Size:";
            // 
            // labelAuthor
            // 
            this.labelAuthor.AutoSize = true;
            this.labelAuthor.Location = new System.Drawing.Point(6, 36);
            this.labelAuthor.Name = "labelAuthor";
            this.labelAuthor.Size = new System.Drawing.Size(44, 13);
            this.labelAuthor.TabIndex = 12;
            this.labelAuthor.Text = "Author:";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(6, 17);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(41, 13);
            this.labelName.TabIndex = 12;
            this.labelName.Text = "Name: ";
            // 
            // gameHack
            // 
            this.gameHack.AutoSize = true;
            this.gameHack.Location = new System.Drawing.Point(188, 14);
            this.gameHack.Name = "gameHack";
            this.gameHack.Size = new System.Drawing.Size(78, 17);
            this.gameHack.TabIndex = 13;
            this.gameHack.Text = "Game hack";
            this.gameHack.UseVisualStyleBackColor = true;
            // 
            // freshROM
            // 
            this.freshROM.AutoSize = true;
            this.freshROM.Location = new System.Drawing.Point(107, 14);
            this.freshROM.Name = "freshROM";
            this.freshROM.Size = new System.Drawing.Size(79, 17);
            this.freshROM.TabIndex = 13;
            this.freshROM.Text = "Fresh ROM";
            this.freshROM.UseVisualStyleBackColor = true;
            // 
            // assemblyHack
            // 
            this.assemblyHack.AutoSize = true;
            this.assemblyHack.Location = new System.Drawing.Point(9, 14);
            this.assemblyHack.Name = "assemblyHack";
            this.assemblyHack.Size = new System.Drawing.Size(96, 17);
            this.assemblyHack.TabIndex = 13;
            this.assemblyHack.Text = "Assembly hack";
            this.assemblyHack.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.labelName);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.linkLabel1);
            this.groupBox4.Controls.Add(this.labelAuthor);
            this.groupBox4.Controls.Add(this.labelSize);
            this.groupBox4.Controls.Add(this.labelDate);
            this.groupBox4.Location = new System.Drawing.Point(0, 0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(272, 114);
            this.groupBox4.TabIndex = 14;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Attributes";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Direct link:";
            // 
            // linkLabel1
            // 
            this.linkLabel1.Location = new System.Drawing.Point(69, 93);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(197, 13);
            this.linkLabel1.TabIndex = 15;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "linkLabel1";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(3, 17);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.textBox1.Size = new System.Drawing.Size(266, 80);
            this.textBox1.TabIndex = 0;
            // 
            // panelPatch
            // 
            this.panelPatch.Controls.Add(this.groupBox2);
            this.panelPatch.Controls.Add(this.groupBox4);
            this.panelPatch.Controls.Add(this.groupBox3);
            this.panelPatch.Controls.Add(this.groupBox1);
            this.panelPatch.Location = new System.Drawing.Point(159, 6);
            this.panelPatch.Name = "panelPatch";
            this.panelPatch.Size = new System.Drawing.Size(550, 254);
            this.panelPatch.TabIndex = 15;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.assemblyHack);
            this.groupBox2.Controls.Add(this.gameHack);
            this.groupBox2.Controls.Add(this.freshROM);
            this.groupBox2.Location = new System.Drawing.Point(0, 217);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(272, 37);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Location = new System.Drawing.Point(0, 117);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(272, 100);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Description";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.downloadingLabel);
            this.panel1.Location = new System.Drawing.Point(159, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(550, 254);
            this.panel1.TabIndex = 16;
            // 
            // PatchesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 294);
            this.Controls.Add(this.listBox);
            this.Controls.Add(this.applyButton);
            this.Controls.Add(this.SizeLabel);
            this.Controls.Add(this.PatchNameLabel);
            this.Controls.Add(this.DateCreatedLabel);
            this.Controls.Add(this.AuthorLabel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelPatch);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Location = new System.Drawing.Point(0, 0);
            this.MaximizeBox = false;
            this.Name = "PatchesForm";
            this.Text = "PATCHES - Lazy Shell";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GamePatches_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.ImagePictureBox)).EndInit();
            this.panel3.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.panelPatch.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        private System.Windows.Forms.PictureBox ImagePictureBox;
        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.Label AuthorLabel;
        private System.Windows.Forms.Label DateCreatedLabel;
        private System.Windows.Forms.Label PatchNameLabel;
        private System.Windows.Forms.Label SizeLabel;
        private System.Windows.Forms.Button applyButton;
        private System.Windows.Forms.Label downloadingLabel;
        private System.Windows.Forms.Panel panel3;
        private System.ComponentModel.BackgroundWorker clock;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label labelDate;
        private System.Windows.Forms.Label labelSize;
        private System.Windows.Forms.Label labelAuthor;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.CheckBox gameHack;
        private System.Windows.Forms.CheckBox freshROM;
        private System.Windows.Forms.CheckBox assemblyHack;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RichTextBox textBox1;
        private System.Windows.Forms.Panel panelPatch;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}