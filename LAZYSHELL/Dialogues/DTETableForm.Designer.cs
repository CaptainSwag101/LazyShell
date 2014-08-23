namespace LAZYSHELL.Dialogues
{
    partial class DTETableForm
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
            this.toolStrip7 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.freeTableBytes = new System.Windows.Forms.ToolStripLabel();
            this.dct19 = new System.Windows.Forms.TextBox();
            this.dct18 = new System.Windows.Forms.TextBox();
            this.dct17 = new System.Windows.Forms.TextBox();
            this.dct16 = new System.Windows.Forms.TextBox();
            this.dct0E = new System.Windows.Forms.TextBox();
            this.dct11 = new System.Windows.Forms.TextBox();
            this.dct10 = new System.Windows.Forms.TextBox();
            this.dct0F = new System.Windows.Forms.TextBox();
            this.dct12 = new System.Windows.Forms.TextBox();
            this.dct15 = new System.Windows.Forms.TextBox();
            this.dct14 = new System.Windows.Forms.TextBox();
            this.dct13 = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.toolStrip7.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip7
            // 
            this.toolStrip7.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip7.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel4,
            this.freeTableBytes});
            this.toolStrip7.Location = new System.Drawing.Point(0, 0);
            this.toolStrip7.Name = "toolStrip7";
            this.toolStrip7.Size = new System.Drawing.Size(258, 25);
            this.toolStrip7.TabIndex = 13;
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(103, 22);
            this.toolStripLabel4.Text = " Compression Table ";
            // 
            // freeTableBytes
            // 
            this.freeTableBytes.Name = "freeTableBytes";
            this.freeTableBytes.Size = new System.Drawing.Size(85, 22);
            this.freeTableBytes.Text = "(characters left)";
            // 
            // dct19
            // 
            this.dct19.Location = new System.Drawing.Point(129, 133);
            this.dct19.Name = "dct19";
            this.dct19.Size = new System.Drawing.Size(129, 21);
            this.dct19.TabIndex = 25;
            this.dct19.TextChanged += new System.EventHandler(this.dct_TextChanged);
            this.dct19.Leave += new System.EventHandler(this.dct_Leave);
            // 
            // dct18
            // 
            this.dct18.Location = new System.Drawing.Point(129, 112);
            this.dct18.Name = "dct18";
            this.dct18.Size = new System.Drawing.Size(129, 21);
            this.dct18.TabIndex = 24;
            this.dct18.TextChanged += new System.EventHandler(this.dct_TextChanged);
            this.dct18.Leave += new System.EventHandler(this.dct_Leave);
            // 
            // dct17
            // 
            this.dct17.Location = new System.Drawing.Point(129, 91);
            this.dct17.Name = "dct17";
            this.dct17.Size = new System.Drawing.Size(129, 21);
            this.dct17.TabIndex = 23;
            this.dct17.TextChanged += new System.EventHandler(this.dct_TextChanged);
            this.dct17.Leave += new System.EventHandler(this.dct_Leave);
            // 
            // dct16
            // 
            this.dct16.Location = new System.Drawing.Point(129, 70);
            this.dct16.Name = "dct16";
            this.dct16.Size = new System.Drawing.Size(129, 21);
            this.dct16.TabIndex = 22;
            this.dct16.TextChanged += new System.EventHandler(this.dct_TextChanged);
            this.dct16.Leave += new System.EventHandler(this.dct_Leave);
            // 
            // dct0E
            // 
            this.dct0E.Location = new System.Drawing.Point(0, 28);
            this.dct0E.Name = "dct0E";
            this.dct0E.Size = new System.Drawing.Size(129, 21);
            this.dct0E.TabIndex = 14;
            this.dct0E.TextChanged += new System.EventHandler(this.dct_TextChanged);
            this.dct0E.Leave += new System.EventHandler(this.dct_Leave);
            // 
            // dct11
            // 
            this.dct11.Location = new System.Drawing.Point(0, 91);
            this.dct11.Name = "dct11";
            this.dct11.Size = new System.Drawing.Size(129, 21);
            this.dct11.TabIndex = 17;
            this.dct11.TextChanged += new System.EventHandler(this.dct_TextChanged);
            this.dct11.Leave += new System.EventHandler(this.dct_Leave);
            // 
            // dct10
            // 
            this.dct10.Location = new System.Drawing.Point(0, 70);
            this.dct10.Name = "dct10";
            this.dct10.Size = new System.Drawing.Size(129, 21);
            this.dct10.TabIndex = 16;
            this.dct10.TextChanged += new System.EventHandler(this.dct_TextChanged);
            this.dct10.Leave += new System.EventHandler(this.dct_Leave);
            // 
            // dct0F
            // 
            this.dct0F.Location = new System.Drawing.Point(0, 49);
            this.dct0F.Name = "dct0F";
            this.dct0F.Size = new System.Drawing.Size(129, 21);
            this.dct0F.TabIndex = 15;
            this.dct0F.TextChanged += new System.EventHandler(this.dct_TextChanged);
            this.dct0F.Leave += new System.EventHandler(this.dct_Leave);
            // 
            // dct12
            // 
            this.dct12.Location = new System.Drawing.Point(0, 112);
            this.dct12.Name = "dct12";
            this.dct12.Size = new System.Drawing.Size(129, 21);
            this.dct12.TabIndex = 18;
            this.dct12.TextChanged += new System.EventHandler(this.dct_TextChanged);
            this.dct12.Leave += new System.EventHandler(this.dct_Leave);
            // 
            // dct15
            // 
            this.dct15.Location = new System.Drawing.Point(129, 49);
            this.dct15.Name = "dct15";
            this.dct15.Size = new System.Drawing.Size(129, 21);
            this.dct15.TabIndex = 21;
            this.dct15.TextChanged += new System.EventHandler(this.dct_TextChanged);
            this.dct15.Leave += new System.EventHandler(this.dct_Leave);
            // 
            // dct14
            // 
            this.dct14.Location = new System.Drawing.Point(129, 28);
            this.dct14.Name = "dct14";
            this.dct14.Size = new System.Drawing.Size(129, 21);
            this.dct14.TabIndex = 20;
            this.dct14.TextChanged += new System.EventHandler(this.dct_TextChanged);
            this.dct14.Leave += new System.EventHandler(this.dct_Leave);
            // 
            // dct13
            // 
            this.dct13.Location = new System.Drawing.Point(0, 133);
            this.dct13.Name = "dct13";
            this.dct13.Size = new System.Drawing.Size(129, 21);
            this.dct13.TabIndex = 19;
            this.dct13.TextChanged += new System.EventHandler(this.dct_TextChanged);
            this.dct13.Leave += new System.EventHandler(this.dct_Leave);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(0, 155);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(258, 23);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 26;
            // 
            // DTETableForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(258, 178);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.toolStrip7);
            this.Controls.Add(this.dct19);
            this.Controls.Add(this.dct18);
            this.Controls.Add(this.dct17);
            this.Controls.Add(this.dct16);
            this.Controls.Add(this.dct0E);
            this.Controls.Add(this.dct11);
            this.Controls.Add(this.dct10);
            this.Controls.Add(this.dct0F);
            this.Controls.Add(this.dct12);
            this.Controls.Add(this.dct15);
            this.Controls.Add(this.dct14);
            this.Controls.Add(this.dct13);
            this.Name = "DTETableForm";
            this.Text = "DTE Table";
            this.Leave += new System.EventHandler(this.DTETableForm_Leave);
            this.toolStrip7.ResumeLayout(false);
            this.toolStrip7.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip7;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
        private System.Windows.Forms.ToolStripLabel freeTableBytes;
        private System.Windows.Forms.TextBox dct19;
        private System.Windows.Forms.TextBox dct18;
        private System.Windows.Forms.TextBox dct17;
        private System.Windows.Forms.TextBox dct16;
        private System.Windows.Forms.TextBox dct0E;
        private System.Windows.Forms.TextBox dct11;
        private System.Windows.Forms.TextBox dct10;
        private System.Windows.Forms.TextBox dct0F;
        private System.Windows.Forms.TextBox dct12;
        private System.Windows.Forms.TextBox dct15;
        private System.Windows.Forms.TextBox dct14;
        private System.Windows.Forms.TextBox dct13;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}