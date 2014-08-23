
namespace LAZYSHELL.Formations
{
    partial class PacksForm
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
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.num = new LAZYSHELL.Controls.NewToolStripNumericUpDown();
            this.search = new System.Windows.Forms.ToolStripButton();
            this.findReferences = new System.Windows.Forms.ToolStripButton();
            this.formation1 = new System.Windows.Forms.NumericUpDown();
            this.load1 = new System.Windows.Forms.Button();
            this.formation1Monsters = new System.Windows.Forms.RichTextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.load2 = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.formation2Monsters = new System.Windows.Forms.RichTextBox();
            this.formation2 = new System.Windows.Forms.NumericUpDown();
            this.load3 = new System.Windows.Forms.Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.formation3Monsters = new System.Windows.Forms.RichTextBox();
            this.formation3 = new System.Windows.Forms.NumericUpDown();
            this.toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.formation1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.formation2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.formation3)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip2
            // 
            this.toolStrip2.CanOverflow = false;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.num,
            this.search,
            this.findReferences});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(490, 25);
            this.toolStrip2.TabIndex = 0;
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
            255,
            0,
            0,
            0});
            this.num.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.num.Name = "packNum";
            this.num.Size = new System.Drawing.Size(60, 21);
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
            this.search.ToolTipText = "Search for effect";
            // 
            // findReferences
            // 
            this.findReferences.Image = global::LAZYSHELL.Properties.Resources.find_references;
            this.findReferences.Name = "findReferences";
            this.findReferences.Size = new System.Drawing.Size(23, 22);
            this.findReferences.ToolTipText = "Find all references to pack";
            this.findReferences.Click += new System.EventHandler(this.findReferences_Click);
            // 
            // formation1
            // 
            this.formation1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.formation1.Location = new System.Drawing.Point(0, 182);
            this.formation1.Maximum = new decimal(new int[] {
            511,
            0,
            0,
            0});
            this.formation1.Name = "formation1";
            this.formation1.Size = new System.Drawing.Size(163, 21);
            this.formation1.TabIndex = 0;
            this.formation1.ValueChanged += new System.EventHandler(this.formation1_ValueChanged);
            // 
            // load1
            // 
            this.load1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.load1.FlatAppearance.BorderSize = 0;
            this.load1.Location = new System.Drawing.Point(2, 314);
            this.load1.Name = "load1";
            this.load1.Size = new System.Drawing.Size(160, 22);
            this.load1.TabIndex = 2;
            this.load1.Text = "LOAD";
            this.load1.UseVisualStyleBackColor = false;
            this.load1.Click += new System.EventHandler(this.load1_Click);
            // 
            // formation1Monsters
            // 
            this.formation1Monsters.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.formation1Monsters.BackColor = System.Drawing.SystemColors.Window;
            this.formation1Monsters.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.formation1Monsters.Location = new System.Drawing.Point(0, 203);
            this.formation1Monsters.Name = "formation1Monsters";
            this.formation1Monsters.ReadOnly = true;
            this.formation1Monsters.Size = new System.Drawing.Size(163, 109);
            this.formation1Monsters.TabIndex = 1;
            this.formation1Monsters.Text = "";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox1.BackgroundImage = global::LAZYSHELL.Properties.Resources._transparent;
            this.pictureBox1.Location = new System.Drawing.Point(0, 24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(163, 157);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // load2
            // 
            this.load2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.load2.FlatAppearance.BorderSize = 0;
            this.load2.Location = new System.Drawing.Point(166, 314);
            this.load2.Name = "load2";
            this.load2.Size = new System.Drawing.Size(160, 22);
            this.load2.TabIndex = 2;
            this.load2.Text = "LOAD";
            this.load2.UseVisualStyleBackColor = false;
            this.load2.Click += new System.EventHandler(this.load2_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox2.BackgroundImage = global::LAZYSHELL.Properties.Resources._transparent;
            this.pictureBox2.Location = new System.Drawing.Point(164, 24);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(163, 157);
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox2_Paint);
            // 
            // formation2Monsters
            // 
            this.formation2Monsters.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.formation2Monsters.BackColor = System.Drawing.SystemColors.Window;
            this.formation2Monsters.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.formation2Monsters.Location = new System.Drawing.Point(164, 203);
            this.formation2Monsters.Name = "formation2Monsters";
            this.formation2Monsters.ReadOnly = true;
            this.formation2Monsters.Size = new System.Drawing.Size(163, 109);
            this.formation2Monsters.TabIndex = 1;
            this.formation2Monsters.Text = "";
            // 
            // formation2
            // 
            this.formation2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.formation2.Location = new System.Drawing.Point(164, 182);
            this.formation2.Maximum = new decimal(new int[] {
            511,
            0,
            0,
            0});
            this.formation2.Name = "formation2";
            this.formation2.Size = new System.Drawing.Size(163, 21);
            this.formation2.TabIndex = 0;
            this.formation2.ValueChanged += new System.EventHandler(this.formation2_ValueChanged);
            // 
            // load3
            // 
            this.load3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.load3.FlatAppearance.BorderSize = 0;
            this.load3.Location = new System.Drawing.Point(331, 314);
            this.load3.Name = "load3";
            this.load3.Size = new System.Drawing.Size(159, 22);
            this.load3.TabIndex = 2;
            this.load3.Text = "LOAD";
            this.load3.UseVisualStyleBackColor = false;
            this.load3.Click += new System.EventHandler(this.load3_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox3.BackgroundImage = global::LAZYSHELL.Properties.Resources._transparent;
            this.pictureBox3.Location = new System.Drawing.Point(328, 24);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(162, 157);
            this.pictureBox3.TabIndex = 7;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox3_Paint);
            // 
            // formation3Monsters
            // 
            this.formation3Monsters.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.formation3Monsters.BackColor = System.Drawing.SystemColors.Window;
            this.formation3Monsters.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.formation3Monsters.Location = new System.Drawing.Point(328, 203);
            this.formation3Monsters.Name = "formation3Monsters";
            this.formation3Monsters.ReadOnly = true;
            this.formation3Monsters.Size = new System.Drawing.Size(162, 109);
            this.formation3Monsters.TabIndex = 1;
            this.formation3Monsters.Text = "";
            // 
            // formation3
            // 
            this.formation3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.formation3.Location = new System.Drawing.Point(328, 182);
            this.formation3.Maximum = new decimal(new int[] {
            511,
            0,
            0,
            0});
            this.formation3.Name = "formation3";
            this.formation3.Size = new System.Drawing.Size(162, 21);
            this.formation3.TabIndex = 0;
            this.formation3.ValueChanged += new System.EventHandler(this.formation3_ValueChanged);
            // 
            // PacksForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 337);
            this.Controls.Add(this.formation3);
            this.Controls.Add(this.formation2);
            this.Controls.Add(this.formation1);
            this.Controls.Add(this.formation3Monsters);
            this.Controls.Add(this.formation2Monsters);
            this.Controls.Add(this.formation1Monsters);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.load3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.load2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.load1);
            this.Controls.Add(this.toolStrip2);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "PacksForm";
            this.Text = "Packs";
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.formation1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.formation2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.formation3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        private System.Windows.Forms.ToolStrip toolStrip2;
        private Controls.NewToolStripNumericUpDown num;
        private System.Windows.Forms.ToolStripButton search;
        private System.Windows.Forms.NumericUpDown formation1;
        private System.Windows.Forms.Button load1;
        private System.Windows.Forms.RichTextBox formation1Monsters;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button load2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.RichTextBox formation2Monsters;
        private System.Windows.Forms.NumericUpDown formation2;
        private System.Windows.Forms.Button load3;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.RichTextBox formation3Monsters;
        private System.Windows.Forms.NumericUpDown formation3;
        private System.Windows.Forms.ToolStripButton findReferences;
    }
}