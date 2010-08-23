namespace LAZYSHELL
{
    partial class SpaceAnalyzer
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tileMapPage = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.sizeLeftListBox = new LAZYSHELL.SpaceAnalyzer.NewListBox();
            this.tileMapListBox = new LAZYSHELL.SpaceAnalyzer.NewListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.compressedDataSizeListBox = new LAZYSHELL.SpaceAnalyzer.NewListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dataOffsetListBox = new LAZYSHELL.SpaceAnalyzer.NewListBox();
            this.pointerOffsetListBox = new LAZYSHELL.SpaceAnalyzer.NewListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.bankListBox = new LAZYSHELL.SpaceAnalyzer.NewListBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label7 = new System.Windows.Forms.Label();
            this.sizeLeftListBox1 = new LAZYSHELL.SpaceAnalyzer.NewListBox();
            this.physMapListBox = new LAZYSHELL.SpaceAnalyzer.NewListBox();
            this.label8 = new System.Windows.Forms.Label();
            this.compressedDataSizeListBox1 = new LAZYSHELL.SpaceAnalyzer.NewListBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.dataOffsetListBox1 = new LAZYSHELL.SpaceAnalyzer.NewListBox();
            this.pointerOffsetListBox1 = new LAZYSHELL.SpaceAnalyzer.NewListBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.bankListBox1 = new LAZYSHELL.SpaceAnalyzer.NewListBox();
            this.tabControl1.SuspendLayout();
            this.tileMapPage.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tileMapPage);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(585, 411);
            this.tabControl1.TabIndex = 0;
            // 
            // tileMapPage
            // 
            this.tileMapPage.BackColor = System.Drawing.SystemColors.ControlText;
            this.tileMapPage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tileMapPage.Controls.Add(this.label6);
            this.tileMapPage.Controls.Add(this.sizeLeftListBox);
            this.tileMapPage.Controls.Add(this.tileMapListBox);
            this.tileMapPage.Controls.Add(this.label5);
            this.tileMapPage.Controls.Add(this.compressedDataSizeListBox);
            this.tileMapPage.Controls.Add(this.label4);
            this.tileMapPage.Controls.Add(this.label3);
            this.tileMapPage.Controls.Add(this.dataOffsetListBox);
            this.tileMapPage.Controls.Add(this.pointerOffsetListBox);
            this.tileMapPage.Controls.Add(this.label2);
            this.tileMapPage.Controls.Add(this.label1);
            this.tileMapPage.Controls.Add(this.bankListBox);
            this.tileMapPage.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tileMapPage.Location = new System.Drawing.Point(4, 20);
            this.tileMapPage.Name = "tileMapPage";
            this.tileMapPage.Padding = new System.Windows.Forms.Padding(3);
            this.tileMapPage.Size = new System.Drawing.Size(577, 387);
            this.tileMapPage.TabIndex = 0;
            this.tileMapPage.Text = "TILE MAPS";
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.SystemColors.Control;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label6.Location = new System.Drawing.Point(482, 0);
            this.label6.Name = "label6";
            this.label6.Padding = new System.Windows.Forms.Padding(2, 2, 0, 0);
            this.label6.Size = new System.Drawing.Size(91, 17);
            this.label6.TabIndex = 13;
            this.label6.Text = "BYTES LEFT";
            // 
            // sizeLeftListBox
            // 
            this.sizeLeftListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.sizeLeftListBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.sizeLeftListBox.FormattingEnabled = true;
            this.sizeLeftListBox.Location = new System.Drawing.Point(482, 19);
            this.sizeLeftListBox.Name = "sizeLeftListBox";
            this.sizeLeftListBox.Size = new System.Drawing.Size(91, 364);
            this.sizeLeftListBox.TabIndex = 12;
            this.sizeLeftListBox.SelectedIndexChanged += new System.EventHandler(this.sizeLeftListBox_SelectedIndexChanged);
            // 
            // tileMapListBox
            // 
            this.tileMapListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tileMapListBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.tileMapListBox.FormattingEnabled = true;
            this.tileMapListBox.Location = new System.Drawing.Point(0, 19);
            this.tileMapListBox.Name = "tileMapListBox";
            this.tileMapListBox.Size = new System.Drawing.Size(113, 364);
            this.tileMapListBox.TabIndex = 11;
            this.tileMapListBox.SelectedIndexChanged += new System.EventHandler(this.tileMapListBox_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.SystemColors.Control;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label5.Location = new System.Drawing.Point(368, 0);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(2, 2, 0, 0);
            this.label5.Size = new System.Drawing.Size(112, 17);
            this.label5.TabIndex = 10;
            this.label5.Text = "COMPRESSED SIZE";
            // 
            // compressedDataSizeListBox
            // 
            this.compressedDataSizeListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.compressedDataSizeListBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.compressedDataSizeListBox.FormattingEnabled = true;
            this.compressedDataSizeListBox.Location = new System.Drawing.Point(368, 19);
            this.compressedDataSizeListBox.Name = "compressedDataSizeListBox";
            this.compressedDataSizeListBox.Size = new System.Drawing.Size(112, 364);
            this.compressedDataSizeListBox.TabIndex = 9;
            this.compressedDataSizeListBox.SelectedIndexChanged += new System.EventHandler(this.compressedDataSizeListBox_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.Control;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label4.Location = new System.Drawing.Point(283, 0);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(2, 2, 0, 0);
            this.label4.Size = new System.Drawing.Size(83, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "DATA OFFSET";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label3.Location = new System.Drawing.Point(196, 0);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(2, 2, 0, 0);
            this.label3.Size = new System.Drawing.Size(85, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "POINTER OFFSET";
            // 
            // dataOffsetListBox
            // 
            this.dataOffsetListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataOffsetListBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.dataOffsetListBox.FormattingEnabled = true;
            this.dataOffsetListBox.Location = new System.Drawing.Point(283, 19);
            this.dataOffsetListBox.Name = "dataOffsetListBox";
            this.dataOffsetListBox.Size = new System.Drawing.Size(83, 364);
            this.dataOffsetListBox.TabIndex = 6;
            this.dataOffsetListBox.SelectedIndexChanged += new System.EventHandler(this.dataOffsetListBox_SelectedIndexChanged);
            // 
            // pointerOffsetListBox
            // 
            this.pointerOffsetListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.pointerOffsetListBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.pointerOffsetListBox.FormattingEnabled = true;
            this.pointerOffsetListBox.Location = new System.Drawing.Point(196, 19);
            this.pointerOffsetListBox.Name = "pointerOffsetListBox";
            this.pointerOffsetListBox.Size = new System.Drawing.Size(85, 364);
            this.pointerOffsetListBox.TabIndex = 5;
            this.pointerOffsetListBox.SelectedIndexChanged += new System.EventHandler(this.pointerOffsetListBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label2.Location = new System.Drawing.Point(115, 0);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(2, 2, 0, 0);
            this.label2.Size = new System.Drawing.Size(79, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "BANK";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(2, 2, 0, 0);
            this.label1.Size = new System.Drawing.Size(113, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "TILE MAP";
            // 
            // bankListBox
            // 
            this.bankListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.bankListBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.bankListBox.FormattingEnabled = true;
            this.bankListBox.Location = new System.Drawing.Point(115, 19);
            this.bankListBox.Name = "bankListBox";
            this.bankListBox.Size = new System.Drawing.Size(79, 364);
            this.bankListBox.TabIndex = 2;
            this.bankListBox.SelectedIndexChanged += new System.EventHandler(this.bankListBox_SelectedIndexChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.ControlText;
            this.tabPage2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.sizeLeftListBox1);
            this.tabPage2.Controls.Add(this.physMapListBox);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.compressedDataSizeListBox1);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.dataOffsetListBox1);
            this.tabPage2.Controls.Add(this.pointerOffsetListBox1);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.bankListBox1);
            this.tabPage2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage2.Location = new System.Drawing.Point(4, 20);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(577, 387);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "PHYSICAL MAPS";
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.SystemColors.Control;
            this.label7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label7.Location = new System.Drawing.Point(482, 0);
            this.label7.Name = "label7";
            this.label7.Padding = new System.Windows.Forms.Padding(2, 2, 0, 0);
            this.label7.Size = new System.Drawing.Size(91, 17);
            this.label7.TabIndex = 25;
            this.label7.Text = "BYTES LEFT";
            // 
            // sizeLeftListBox1
            // 
            this.sizeLeftListBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.sizeLeftListBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.sizeLeftListBox1.FormattingEnabled = true;
            this.sizeLeftListBox1.Location = new System.Drawing.Point(482, 19);
            this.sizeLeftListBox1.Name = "sizeLeftListBox1";
            this.sizeLeftListBox1.Size = new System.Drawing.Size(91, 364);
            this.sizeLeftListBox1.TabIndex = 24;
            this.sizeLeftListBox1.SelectedIndexChanged += new System.EventHandler(this.sizeLeftListBox1_SelectedIndexChanged);
            // 
            // physMapListBox
            // 
            this.physMapListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.physMapListBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.physMapListBox.FormattingEnabled = true;
            this.physMapListBox.Location = new System.Drawing.Point(0, 19);
            this.physMapListBox.Name = "physMapListBox";
            this.physMapListBox.Size = new System.Drawing.Size(113, 364);
            this.physMapListBox.TabIndex = 23;
            this.physMapListBox.SelectedIndexChanged += new System.EventHandler(this.physMapListBox_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.SystemColors.Control;
            this.label8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label8.Location = new System.Drawing.Point(368, 0);
            this.label8.Name = "label8";
            this.label8.Padding = new System.Windows.Forms.Padding(2, 2, 0, 0);
            this.label8.Size = new System.Drawing.Size(112, 17);
            this.label8.TabIndex = 22;
            this.label8.Text = "COMPRESSED SIZE";
            // 
            // compressedDataSizeListBox1
            // 
            this.compressedDataSizeListBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.compressedDataSizeListBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.compressedDataSizeListBox1.FormattingEnabled = true;
            this.compressedDataSizeListBox1.Location = new System.Drawing.Point(368, 19);
            this.compressedDataSizeListBox1.Name = "compressedDataSizeListBox1";
            this.compressedDataSizeListBox1.Size = new System.Drawing.Size(112, 364);
            this.compressedDataSizeListBox1.TabIndex = 21;
            this.compressedDataSizeListBox1.SelectedIndexChanged += new System.EventHandler(this.compressedDataSizeListBox1_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.SystemColors.Control;
            this.label9.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label9.Location = new System.Drawing.Point(283, 0);
            this.label9.Name = "label9";
            this.label9.Padding = new System.Windows.Forms.Padding(2, 2, 0, 0);
            this.label9.Size = new System.Drawing.Size(83, 17);
            this.label9.TabIndex = 20;
            this.label9.Text = "DATA OFFSET";
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.SystemColors.Control;
            this.label10.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label10.Location = new System.Drawing.Point(196, 0);
            this.label10.Name = "label10";
            this.label10.Padding = new System.Windows.Forms.Padding(2, 2, 0, 0);
            this.label10.Size = new System.Drawing.Size(85, 17);
            this.label10.TabIndex = 19;
            this.label10.Text = "POINTER OFFSET";
            // 
            // dataOffsetListBox1
            // 
            this.dataOffsetListBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataOffsetListBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.dataOffsetListBox1.FormattingEnabled = true;
            this.dataOffsetListBox1.Location = new System.Drawing.Point(283, 19);
            this.dataOffsetListBox1.Name = "dataOffsetListBox1";
            this.dataOffsetListBox1.Size = new System.Drawing.Size(83, 364);
            this.dataOffsetListBox1.TabIndex = 18;
            this.dataOffsetListBox1.SelectedIndexChanged += new System.EventHandler(this.dataOffsetListBox1_SelectedIndexChanged);
            // 
            // pointerOffsetListBox1
            // 
            this.pointerOffsetListBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.pointerOffsetListBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.pointerOffsetListBox1.FormattingEnabled = true;
            this.pointerOffsetListBox1.Location = new System.Drawing.Point(196, 19);
            this.pointerOffsetListBox1.Name = "pointerOffsetListBox1";
            this.pointerOffsetListBox1.Size = new System.Drawing.Size(85, 364);
            this.pointerOffsetListBox1.TabIndex = 17;
            this.pointerOffsetListBox1.SelectedIndexChanged += new System.EventHandler(this.pointerOffsetListBox1_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.SystemColors.Control;
            this.label11.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label11.Location = new System.Drawing.Point(115, 0);
            this.label11.Name = "label11";
            this.label11.Padding = new System.Windows.Forms.Padding(2, 2, 0, 0);
            this.label11.Size = new System.Drawing.Size(79, 17);
            this.label11.TabIndex = 16;
            this.label11.Text = "BANK";
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.SystemColors.Control;
            this.label12.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label12.Location = new System.Drawing.Point(0, 0);
            this.label12.Name = "label12";
            this.label12.Padding = new System.Windows.Forms.Padding(2, 2, 0, 0);
            this.label12.Size = new System.Drawing.Size(113, 17);
            this.label12.TabIndex = 15;
            this.label12.Text = "PHYSICAL MAP";
            // 
            // bankListBox1
            // 
            this.bankListBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.bankListBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.bankListBox1.FormattingEnabled = true;
            this.bankListBox1.Location = new System.Drawing.Point(115, 19);
            this.bankListBox1.Name = "bankListBox1";
            this.bankListBox1.Size = new System.Drawing.Size(79, 364);
            this.bankListBox1.TabIndex = 14;
            this.bankListBox1.SelectedIndexChanged += new System.EventHandler(this.bankListBox1_SelectedIndexChanged);
            // 
            // SpaceAnalyzer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 411);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SpaceAnalyzer";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "SPACE ANALYZER";
            this.TopMost = true;
            this.tabControl1.ResumeLayout(false);
            this.tileMapPage.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tileMapPage;
        private System.Windows.Forms.TabPage tabPage2;
        private NewListBox bankListBox;
        private SpaceAnalyzer.NewListBox dataOffsetListBox;
        private SpaceAnalyzer.NewListBox pointerOffsetListBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private SpaceAnalyzer.NewListBox compressedDataSizeListBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private SpaceAnalyzer.NewListBox tileMapListBox;
        private System.Windows.Forms.Label label6;
        private SpaceAnalyzer.NewListBox sizeLeftListBox;
        private System.Windows.Forms.Label label7;
        private SpaceAnalyzer.NewListBox sizeLeftListBox1;
        private SpaceAnalyzer.NewListBox physMapListBox;
        private System.Windows.Forms.Label label8;
        private SpaceAnalyzer.NewListBox compressedDataSizeListBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private SpaceAnalyzer.NewListBox dataOffsetListBox1;
        private SpaceAnalyzer.NewListBox pointerOffsetListBox1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private SpaceAnalyzer.NewListBox bankListBox1;
    }
}