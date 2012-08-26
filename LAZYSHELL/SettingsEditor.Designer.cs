namespace LAZYSHELL
{
    partial class SettingsEditor
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
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.customDirectoryTextBox = new System.Windows.Forms.TextBox();
            this.buttonDefault = new System.Windows.Forms.Button();
            this.buttonApply = new System.Windows.Forms.Button();
            this.visualThemeSystem = new System.Windows.Forms.RadioButton();
            this.visualThemeStandard = new System.Windows.Forms.RadioButton();
            this.undoStackSize = new System.Windows.Forms.NumericUpDown();
            this.patchHTTPServer = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.romDirectory = new System.Windows.Forms.RadioButton();
            this.customDirectory = new System.Windows.Forms.RadioButton();
            this.buttonCustomDirectory = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.undoStackSize)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.CheckOnClick = true;
            this.checkedListBox1.ColumnWidth = 214;
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Items.AddRange(new object[] {
            "Auto-load last used ROM",
            "Auto-create all editor data",
            "Auto-load last used Notes DB",
            "Create back-up ROM on save",
            "Create back-up ROM on load",
            "Verify ROM",
            "Show encryption warnings",
            "Remember last loaded indexes"});
            this.checkedListBox1.Location = new System.Drawing.Point(12, 12);
            this.checkedListBox1.MultiColumn = true;
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(434, 68);
            this.checkedListBox1.TabIndex = 0;
            // 
            // customDirectoryTextBox
            // 
            this.customDirectoryTextBox.Location = new System.Drawing.Point(123, 35);
            this.customDirectoryTextBox.Name = "customDirectoryTextBox";
            this.customDirectoryTextBox.ReadOnly = true;
            this.customDirectoryTextBox.Size = new System.Drawing.Size(272, 21);
            this.customDirectoryTextBox.TabIndex = 2;
            // 
            // buttonDefault
            // 
            this.buttonDefault.Location = new System.Drawing.Point(12, 223);
            this.buttonDefault.Name = "buttonDefault";
            this.buttonDefault.Size = new System.Drawing.Size(75, 23);
            this.buttonDefault.TabIndex = 7;
            this.buttonDefault.Text = "Default...";
            this.buttonDefault.UseVisualStyleBackColor = true;
            this.buttonDefault.Click += new System.EventHandler(this.buttonDefault_Click);
            // 
            // buttonApply
            // 
            this.buttonApply.Location = new System.Drawing.Point(371, 223);
            this.buttonApply.Name = "buttonApply";
            this.buttonApply.Size = new System.Drawing.Size(75, 23);
            this.buttonApply.TabIndex = 10;
            this.buttonApply.Text = "Apply";
            this.buttonApply.UseVisualStyleBackColor = true;
            this.buttonApply.Click += new System.EventHandler(this.buttonApply_Click);
            // 
            // visualThemeSystem
            // 
            this.visualThemeSystem.AutoSize = true;
            this.visualThemeSystem.Location = new System.Drawing.Point(6, 20);
            this.visualThemeSystem.Name = "visualThemeSystem";
            this.visualThemeSystem.Size = new System.Drawing.Size(59, 17);
            this.visualThemeSystem.TabIndex = 0;
            this.visualThemeSystem.TabStop = true;
            this.visualThemeSystem.Text = "System";
            this.visualThemeSystem.UseVisualStyleBackColor = true;
            // 
            // visualThemeStandard
            // 
            this.visualThemeStandard.AutoSize = true;
            this.visualThemeStandard.Location = new System.Drawing.Point(6, 37);
            this.visualThemeStandard.Name = "visualThemeStandard";
            this.visualThemeStandard.Size = new System.Drawing.Size(68, 17);
            this.visualThemeStandard.TabIndex = 1;
            this.visualThemeStandard.TabStop = true;
            this.visualThemeStandard.Text = "Standard";
            this.visualThemeStandard.UseVisualStyleBackColor = true;
            // 
            // undoStackSize
            // 
            this.undoStackSize.Location = new System.Drawing.Point(209, 175);
            this.undoStackSize.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.undoStackSize.Name = "undoStackSize";
            this.undoStackSize.Size = new System.Drawing.Size(55, 21);
            this.undoStackSize.TabIndex = 6;
            this.undoStackSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // patchHTTPServer
            // 
            this.patchHTTPServer.Location = new System.Drawing.Point(209, 154);
            this.patchHTTPServer.Name = "patchHTTPServer";
            this.patchHTTPServer.Size = new System.Drawing.Size(237, 21);
            this.patchHTTPServer.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(107, 157);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Patch HTTP server";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(107, 177);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Undo stack size";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.visualThemeSystem);
            this.groupBox1.Controls.Add(this.visualThemeStandard);
            this.groupBox1.Location = new System.Drawing.Point(12, 154);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(87, 63);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Visual Theme";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.romDirectory);
            this.groupBox2.Controls.Add(this.customDirectory);
            this.groupBox2.Controls.Add(this.customDirectoryTextBox);
            this.groupBox2.Controls.Add(this.buttonCustomDirectory);
            this.groupBox2.Location = new System.Drawing.Point(12, 86);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(434, 62);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Back-up ROM location";
            // 
            // romDirectory
            // 
            this.romDirectory.AutoSize = true;
            this.romDirectory.Location = new System.Drawing.Point(6, 20);
            this.romDirectory.Name = "romDirectory";
            this.romDirectory.Size = new System.Drawing.Size(93, 17);
            this.romDirectory.TabIndex = 0;
            this.romDirectory.TabStop = true;
            this.romDirectory.Text = "ROM directory";
            this.romDirectory.UseVisualStyleBackColor = true;
            // 
            // customDirectory
            // 
            this.customDirectory.AutoSize = true;
            this.customDirectory.Location = new System.Drawing.Point(6, 37);
            this.customDirectory.Name = "customDirectory";
            this.customDirectory.Size = new System.Drawing.Size(106, 17);
            this.customDirectory.TabIndex = 1;
            this.customDirectory.TabStop = true;
            this.customDirectory.Text = "Custom directory:";
            this.customDirectory.UseVisualStyleBackColor = true;
            // 
            // buttonCustomDirectory
            // 
            this.buttonCustomDirectory.Location = new System.Drawing.Point(401, 35);
            this.buttonCustomDirectory.Name = "buttonCustomDirectory";
            this.buttonCustomDirectory.Size = new System.Drawing.Size(27, 21);
            this.buttonCustomDirectory.TabIndex = 3;
            this.buttonCustomDirectory.Text = "...";
            this.buttonCustomDirectory.UseVisualStyleBackColor = true;
            this.buttonCustomDirectory.Click += new System.EventHandler(this.buttonCustomDirectory_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(290, 223);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 9;
            this.buttonClose.Text = "Cancel";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(209, 223);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 8;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // SettingsEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 258);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.undoStackSize);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonApply);
            this.Controls.Add(this.buttonDefault);
            this.Controls.Add(this.patchHTTPServer);
            this.Controls.Add(this.checkedListBox1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsEditor";
            this.ShowInTaskbar = false;
            this.Text = "LAZY SHELL - Settings";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.undoStackSize)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.TextBox customDirectoryTextBox;
        private System.Windows.Forms.Button buttonDefault;
        private System.Windows.Forms.Button buttonApply;
        private System.Windows.Forms.RadioButton visualThemeSystem;
        private System.Windows.Forms.RadioButton visualThemeStandard;
        private System.Windows.Forms.NumericUpDown undoStackSize;
        private System.Windows.Forms.TextBox patchHTTPServer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton romDirectory;
        private System.Windows.Forms.RadioButton customDirectory;
        private System.Windows.Forms.Button buttonCustomDirectory;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonOK;

    }
}