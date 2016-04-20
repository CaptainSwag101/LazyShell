namespace LAZYSHELL.Dialogues
{
    partial class DialoguesForm
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
            this.textBox = new System.Windows.Forms.RichTextBox();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.newLine = new System.Windows.Forms.ToolStripButton();
            this.newLineA = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.newPage = new System.Windows.Forms.ToolStripButton();
            this.newPageA = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.endString = new System.Windows.Forms.ToolStripButton();
            this.endStringA = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.option = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.pause60f = new System.Windows.Forms.ToolStripButton();
            this.pauseA = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.pageUp = new System.Windows.Forms.ToolStripButton();
            this.pageDown = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.textView = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.freeBytes = new System.Windows.Forms.ToolStripLabel();
            this.panel69 = new System.Windows.Forms.Panel();
            this.picture = new System.Windows.Forms.PictureBox();
            this.toolStrip5 = new System.Windows.Forms.ToolStrip();
            this.num = new LAZYSHELL.Controls.NewToolStripNumericUpDown();
            this.search = new System.Windows.Forms.ToolStripButton();
            this.findReferences = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.import = new System.Windows.Forms.ToolStripButton();
            this.export = new System.Windows.Forms.ToolStripButton();
            this.clear = new System.Windows.Forms.ToolStripButton();
            this.reset = new System.Windows.Forms.ToolStripButton();
            this.toolStrip4 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.pauseFrameNum = new LAZYSHELL.Controls.NewToolStripNumericUpDown();
            this.pauseFramesInsert = new System.Windows.Forms.ToolStripButton();
            this.toolStrip6 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.variables = new System.Windows.Forms.ToolStripComboBox();
            this.variablesInsert = new System.Windows.Forms.ToolStripButton();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.toolStrip2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panel69.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picture)).BeginInit();
            this.toolStrip5.SuspendLayout();
            this.toolStrip4.SuspendLayout();
            this.toolStrip6.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox
            // 
            this.textBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox.Location = new System.Drawing.Point(0, 106);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(224, 233);
            this.textBox.TabIndex = 11;
            this.textBox.Text = "";
            this.textBox.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            this.textBox.Enter += new System.EventHandler(this.textBox_Enter);
            this.textBox.Leave += new System.EventHandler(this.textBox_Leave);
            // 
            // toolStrip2
            // 
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.Right;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newLine,
            this.newLineA,
            this.toolStripSeparator5,
            this.newPage,
            this.newPageA,
            this.toolStripSeparator6,
            this.endString,
            this.endStringA,
            this.toolStripSeparator9,
            this.option,
            this.toolStripSeparator7,
            this.pause60f,
            this.pauseA});
            this.toolStrip2.Location = new System.Drawing.Point(224, 106);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(24, 233);
            this.toolStrip2.TabIndex = 12;
            // 
            // newLine
            // 
            this.newLine.Image = global::LAZYSHELL.Properties.Resources.newLine;
            this.newLine.Name = "newLine";
            this.newLine.Size = new System.Drawing.Size(21, 20);
            this.newLine.ToolTipText = "New Line";
            this.newLine.Click += new System.EventHandler(this.newLine_Click);
            // 
            // newLineA
            // 
            this.newLineA.Image = global::LAZYSHELL.Properties.Resources.newLineA;
            this.newLineA.Name = "newLineA";
            this.newLineA.Size = new System.Drawing.Size(21, 20);
            this.newLineA.ToolTipText = "New Line, wait for input";
            this.newLineA.Click += new System.EventHandler(this.newLineA_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(21, 6);
            // 
            // newPage
            // 
            this.newPage.Image = global::LAZYSHELL.Properties.Resources.pageBreak;
            this.newPage.Name = "newPage";
            this.newPage.Size = new System.Drawing.Size(21, 20);
            this.newPage.ToolTipText = "New Page";
            this.newPage.Click += new System.EventHandler(this.newPage_Click);
            // 
            // newPageA
            // 
            this.newPageA.Image = global::LAZYSHELL.Properties.Resources.pageBreakA;
            this.newPageA.Name = "newPageA";
            this.newPageA.Size = new System.Drawing.Size(21, 20);
            this.newPageA.ToolTipText = "New Page, wait for input";
            this.newPageA.Click += new System.EventHandler(this.newPageA_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(21, 6);
            // 
            // endString
            // 
            this.endString.Image = global::LAZYSHELL.Properties.Resources.endString;
            this.endString.Name = "endString";
            this.endString.Size = new System.Drawing.Size(21, 20);
            this.endString.ToolTipText = "End String";
            this.endString.Click += new System.EventHandler(this.endString_Click);
            // 
            // endStringA
            // 
            this.endStringA.Image = global::LAZYSHELL.Properties.Resources.endStringA;
            this.endStringA.Name = "endStringA";
            this.endStringA.Size = new System.Drawing.Size(21, 20);
            this.endStringA.ToolTipText = "End String, wait for input";
            this.endStringA.Click += new System.EventHandler(this.endStringA_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(21, 6);
            // 
            // option
            // 
            this.option.Name = "option";
            this.option.Size = new System.Drawing.Size(21, 4);
            this.option.ToolTipText = "Option Triangle";
            this.option.Click += new System.EventHandler(this.option_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(21, 6);
            // 
            // pause60f
            // 
            this.pause60f.Image = global::LAZYSHELL.Properties.Resources.pause60f;
            this.pause60f.Name = "pause60f";
            this.pause60f.Size = new System.Drawing.Size(21, 20);
            this.pause60f.ToolTipText = "Pause 1 second";
            this.pause60f.Click += new System.EventHandler(this.pause60f_Click);
            // 
            // pauseA
            // 
            this.pauseA.Image = global::LAZYSHELL.Properties.Resources.pauseA;
            this.pauseA.Name = "pauseA";
            this.pauseA.Size = new System.Drawing.Size(21, 20);
            this.pauseA.ToolTipText = "Pause, wait for input";
            this.pauseA.Click += new System.EventHandler(this.pauseA_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pageUp,
            this.pageDown,
            this.toolStripSeparator1,
            this.textView,
            this.toolStripSeparator2,
            this.freeBytes});
            this.toolStrip1.Location = new System.Drawing.Point(0, 81);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(248, 25);
            this.toolStrip1.TabIndex = 10;
            // 
            // pageUp
            // 
            this.pageUp.Image = global::LAZYSHELL.Properties.Resources.pageUp;
            this.pageUp.Name = "pageUp";
            this.pageUp.Size = new System.Drawing.Size(23, 22);
            this.pageUp.ToolTipText = "Back 1 Page";
            this.pageUp.Click += new System.EventHandler(this.pageUp_Click);
            // 
            // pageDown
            // 
            this.pageDown.Image = global::LAZYSHELL.Properties.Resources.pageDown;
            this.pageDown.Name = "pageDown";
            this.pageDown.Size = new System.Drawing.Size(23, 22);
            this.pageDown.ToolTipText = "Foward 1 Page";
            this.pageDown.Click += new System.EventHandler(this.pageDown_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // textView
            // 
            this.textView.CheckOnClick = true;
            this.textView.Image = global::LAZYSHELL.Properties.Resources.textView;
            this.textView.Name = "textView";
            this.textView.Size = new System.Drawing.Size(23, 22);
            this.textView.ToolTipText = "Text View";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // freeBytes
            // 
            this.freeBytes.Name = "freeBytes";
            this.freeBytes.Size = new System.Drawing.Size(81, 22);
            this.freeBytes.Text = "characters left";
            // 
            // panel69
            // 
            this.panel69.Controls.Add(this.picture);
            this.panel69.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel69.Location = new System.Drawing.Point(0, 25);
            this.panel69.Name = "panel69";
            this.panel69.Size = new System.Drawing.Size(248, 56);
            this.panel69.TabIndex = 9;
            // 
            // picture
            // 
            this.picture.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picture.BackgroundImage = global::LAZYSHELL.Properties.Resources._transparent;
            this.picture.Location = new System.Drawing.Point(-8, 0);
            this.picture.Name = "picture";
            this.picture.Size = new System.Drawing.Size(256, 56);
            this.picture.TabIndex = 521;
            this.picture.TabStop = false;
            this.picture.Paint += new System.Windows.Forms.PaintEventHandler(this.picture_Paint);
            // 
            // toolStrip5
            // 
            this.toolStrip5.AutoSize = false;
            this.toolStrip5.CanOverflow = false;
            this.toolStrip5.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.num,
            this.search,
            this.findReferences,
            this.toolStripSeparator3,
            this.import,
            this.export,
            this.clear,
            this.reset});
            this.toolStrip5.Location = new System.Drawing.Point(0, 0);
            this.toolStrip5.Name = "toolStrip5";
            this.toolStrip5.Size = new System.Drawing.Size(248, 25);
            this.toolStrip5.TabIndex = 8;
            // 
            // num
            // 
            this.num.AutoSize = false;
            this.num.ContextMenuStrip = null;
            this.num.Hexadecimal = false;
            this.num.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num.Location = new System.Drawing.Point(9, 1);
            this.num.Maximum = new decimal(new int[] {
            4095,
            0,
            0,
            0});
            this.num.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.num.Name = "dialogueNum";
            this.num.Size = new System.Drawing.Size(60, 20);
            this.num.Text = "0";
            this.num.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.num.ValueChanged += new System.EventHandler(this.num_ValueChanged);
            // 
            // search
            // 
            this.search.Image = global::LAZYSHELL.Properties.Resources.search;
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(23, 22);
            this.search.ToolTipText = "Search For Dialogue";
            // 
            // findReferences
            // 
            this.findReferences.Image = global::LAZYSHELL.Properties.Resources.findReferences;
            this.findReferences.Name = "findReferences";
            this.findReferences.Size = new System.Drawing.Size(23, 22);
            this.findReferences.ToolTipText = "Find references to dialogue";
            this.findReferences.Click += new System.EventHandler(this.findReferences_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // import
            // 
            this.import.Image = global::LAZYSHELL.Properties.Resources.importText;
            this.import.Name = "import";
            this.import.Size = new System.Drawing.Size(23, 22);
            this.import.Click += new System.EventHandler(this.import_Click);
            // 
            // export
            // 
            this.export.Image = global::LAZYSHELL.Properties.Resources.exportText;
            this.export.Name = "export";
            this.export.Size = new System.Drawing.Size(23, 22);
            this.export.Click += new System.EventHandler(this.export_Click);
            // 
            // clear
            // 
            this.clear.Image = global::LAZYSHELL.Properties.Resources.clear;
            this.clear.Name = "clear";
            this.clear.Size = new System.Drawing.Size(23, 22);
            this.clear.Click += new System.EventHandler(this.clear_Click);
            // 
            // reset
            // 
            this.reset.Image = global::LAZYSHELL.Properties.Resources.reset;
            this.reset.Name = "reset";
            this.reset.Size = new System.Drawing.Size(23, 22);
            this.reset.Click += new System.EventHandler(this.reset_Click);
            // 
            // toolStrip4
            // 
            this.toolStrip4.CanOverflow = false;
            this.toolStrip4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip4.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel2,
            this.pauseFrameNum,
            this.pauseFramesInsert});
            this.toolStrip4.Location = new System.Drawing.Point(0, 339);
            this.toolStrip4.Name = "toolStrip4";
            this.toolStrip4.Size = new System.Drawing.Size(248, 25);
            this.toolStrip4.TabIndex = 13;
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.AutoSize = false;
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(86, 22);
            this.toolStripLabel2.Text = "Pause Frames";
            this.toolStripLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pauseFrameNum
            // 
            this.pauseFrameNum.AutoSize = false;
            this.pauseFrameNum.ContextMenuStrip = null;
            this.pauseFrameNum.Hexadecimal = false;
            this.pauseFrameNum.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.pauseFrameNum.Location = new System.Drawing.Point(96, 1);
            this.pauseFrameNum.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.pauseFrameNum.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.pauseFrameNum.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.pauseFrameNum.Name = "pauseFrameNum";
            this.pauseFrameNum.Size = new System.Drawing.Size(128, 21);
            this.pauseFrameNum.Text = "0";
            this.pauseFrameNum.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // pauseFramesInsert
            // 
            this.pauseFramesInsert.Image = global::LAZYSHELL.Properties.Resources.insertIntoText;
            this.pauseFramesInsert.Name = "pauseFramesInsert";
            this.pauseFramesInsert.Size = new System.Drawing.Size(23, 22);
            this.pauseFramesInsert.ToolTipText = "Insert into text";
            this.pauseFramesInsert.Click += new System.EventHandler(this.pauseFramesInsert_Click);
            // 
            // toolStrip6
            // 
            this.toolStrip6.CanOverflow = false;
            this.toolStrip6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip6.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.variables,
            this.variablesInsert});
            this.toolStrip6.Location = new System.Drawing.Point(0, 364);
            this.toolStrip6.Name = "toolStrip6";
            this.toolStrip6.Size = new System.Drawing.Size(248, 25);
            this.toolStrip6.TabIndex = 14;
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.AutoSize = false;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(86, 22);
            this.toolStripLabel1.Text = "Memory Value";
            this.toolStripLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // variables
            // 
            this.variables.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.variables.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.variables.Items.AddRange(new object[] {
            "Item name @ $70A7",
            "Value @ $7000",
            "Value @ $7024",
            "Timer @ $7000",
            "Game slot\'s name"});
            this.variables.Name = "variables";
            this.variables.Size = new System.Drawing.Size(128, 25);
            // 
            // variablesInsert
            // 
            this.variablesInsert.Image = global::LAZYSHELL.Properties.Resources.insertIntoText;
            this.variablesInsert.Name = "variablesInsert";
            this.variablesInsert.Size = new System.Drawing.Size(23, 22);
            this.variablesInsert.ToolTipText = "Insert into text";
            this.variablesInsert.Click += new System.EventHandler(this.variablesInsert_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.progressBar1.Location = new System.Drawing.Point(0, 389);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(222, 20);
            this.progressBar1.TabIndex = 16;
            // 
            // DialoguesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(248, 389);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.panel69);
            this.Controls.Add(this.toolStrip5);
            this.Controls.Add(this.toolStrip4);
            this.Controls.Add(this.toolStrip6);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "DialoguesForm";
            this.Text = "Dialogues";
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel69.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picture)).EndInit();
            this.toolStrip5.ResumeLayout(false);
            this.toolStrip5.PerformLayout();
            this.toolStrip4.ResumeLayout(false);
            this.toolStrip4.PerformLayout();
            this.toolStrip6.ResumeLayout(false);
            this.toolStrip6.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox textBox;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton newLine;
        private System.Windows.Forms.ToolStripButton newLineA;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton newPage;
        private System.Windows.Forms.ToolStripButton newPageA;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton endString;
        private System.Windows.Forms.ToolStripButton endStringA;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripButton option;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripButton pause60f;
        private System.Windows.Forms.ToolStripButton pauseA;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton pageUp;
        private System.Windows.Forms.ToolStripButton pageDown;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton textView;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel freeBytes;
        private System.Windows.Forms.Panel panel69;
        private System.Windows.Forms.PictureBox picture;
        private System.Windows.Forms.ToolStrip toolStrip5;
        private Controls.NewToolStripNumericUpDown num;
        private System.Windows.Forms.ToolStripButton search;
        private System.Windows.Forms.ToolStrip toolStrip4;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private Controls.NewToolStripNumericUpDown pauseFrameNum;
        private System.Windows.Forms.ToolStripButton pauseFramesInsert;
        private System.Windows.Forms.ToolStrip toolStrip6;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox variables;
        private System.Windows.Forms.ToolStripButton variablesInsert;
        private System.Windows.Forms.ToolStripButton findReferences;
        private System.Windows.Forms.ToolStripButton reset;
        private System.Windows.Forms.ToolStripButton import;
        private System.Windows.Forms.ToolStripButton export;
        private System.Windows.Forms.ToolStripButton clear;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    }
}