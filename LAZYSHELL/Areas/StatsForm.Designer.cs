namespace LAZYSHELL.Areas
{
    partial class StatsForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.npcCountTotal = new System.Windows.Forms.Label();
            this.npcMostCommon = new System.Windows.Forms.Label();
            this.npcCountAverage = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.exitCountTotal = new System.Windows.Forms.Label();
            this.exitMostCommon = new System.Windows.Forms.Label();
            this.exitCountAverage = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.eventCountTotal = new System.Windows.Forms.Label();
            this.eventMostCommon = new System.Windows.Forms.Label();
            this.eventCountAverage = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.npcCountTotal);
            this.groupBox1.Controls.Add(this.npcMostCommon);
            this.groupBox1.Controls.Add(this.npcCountAverage);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(268, 86);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "NPC Statistics";
            // 
            // npcCountTotal
            // 
            this.npcCountTotal.AutoSize = true;
            this.npcCountTotal.Location = new System.Drawing.Point(124, 23);
            this.npcCountTotal.Name = "npcCountTotal";
            this.npcCountTotal.Size = new System.Drawing.Size(13, 13);
            this.npcCountTotal.TabIndex = 1;
            this.npcCountTotal.Text = "0";
            // 
            // npcMostCommon
            // 
            this.npcMostCommon.AutoSize = true;
            this.npcMostCommon.Location = new System.Drawing.Point(124, 61);
            this.npcMostCommon.Name = "npcMostCommon";
            this.npcMostCommon.Size = new System.Drawing.Size(13, 13);
            this.npcMostCommon.TabIndex = 1;
            this.npcMostCommon.Text = "0";
            // 
            // npcCountAverage
            // 
            this.npcCountAverage.AutoSize = true;
            this.npcCountAverage.Location = new System.Drawing.Point(124, 42);
            this.npcCountAverage.Name = "npcCountAverage";
            this.npcCountAverage.Size = new System.Drawing.Size(13, 13);
            this.npcCountAverage.TabIndex = 1;
            this.npcCountAverage.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Most common NPC #:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Average NPC count:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Total NPC count:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.exitCountTotal);
            this.groupBox2.Controls.Add(this.exitMostCommon);
            this.groupBox2.Controls.Add(this.exitCountAverage);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(12, 104);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(268, 86);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Exit Statistics";
            // 
            // exitCountTotal
            // 
            this.exitCountTotal.AutoSize = true;
            this.exitCountTotal.Location = new System.Drawing.Point(146, 23);
            this.exitCountTotal.Name = "exitCountTotal";
            this.exitCountTotal.Size = new System.Drawing.Size(13, 13);
            this.exitCountTotal.TabIndex = 1;
            this.exitCountTotal.Text = "0";
            // 
            // exitMostCommon
            // 
            this.exitMostCommon.AutoSize = true;
            this.exitMostCommon.Location = new System.Drawing.Point(146, 61);
            this.exitMostCommon.Name = "exitMostCommon";
            this.exitMostCommon.Size = new System.Drawing.Size(13, 13);
            this.exitMostCommon.TabIndex = 1;
            this.exitMostCommon.Text = "0";
            // 
            // exitCountAverage
            // 
            this.exitCountAverage.AutoSize = true;
            this.exitCountAverage.Location = new System.Drawing.Point(146, 42);
            this.exitCountAverage.Name = "exitCountAverage";
            this.exitCountAverage.Size = new System.Drawing.Size(13, 13);
            this.exitCountAverage.TabIndex = 1;
            this.exitCountAverage.Text = "0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(8, 61);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(132, 13);
            this.label11.TabIndex = 0;
            this.label11.Text = "Most common destination:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Average exit count:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Total exit count:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.eventCountTotal);
            this.groupBox3.Controls.Add(this.eventMostCommon);
            this.groupBox3.Controls.Add(this.eventCountAverage);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Location = new System.Drawing.Point(12, 196);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(268, 86);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Event Statistics";
            // 
            // eventCountTotal
            // 
            this.eventCountTotal.AutoSize = true;
            this.eventCountTotal.Location = new System.Drawing.Point(132, 23);
            this.eventCountTotal.Name = "eventCountTotal";
            this.eventCountTotal.Size = new System.Drawing.Size(13, 13);
            this.eventCountTotal.TabIndex = 1;
            this.eventCountTotal.Text = "0";
            // 
            // eventMostCommon
            // 
            this.eventMostCommon.AutoSize = true;
            this.eventMostCommon.Location = new System.Drawing.Point(132, 61);
            this.eventMostCommon.Name = "eventMostCommon";
            this.eventMostCommon.Size = new System.Drawing.Size(13, 13);
            this.eventMostCommon.TabIndex = 1;
            this.eventMostCommon.Text = "0";
            // 
            // eventCountAverage
            // 
            this.eventCountAverage.AutoSize = true;
            this.eventCountAverage.Location = new System.Drawing.Point(132, 42);
            this.eventCountAverage.Name = "eventCountAverage";
            this.eventCountAverage.Size = new System.Drawing.Size(13, 13);
            this.eventCountAverage.TabIndex = 1;
            this.eventCountAverage.Text = "0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 61);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(118, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Most common event #:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 42);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(113, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Average event count:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 23);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(96, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Total event count:";
            // 
            // StatsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 294);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "StatsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "STATISTICS FOR ALL AREAS";
            this.TopMost = true;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label npcCountTotal;
        private System.Windows.Forms.Label npcCountAverage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label exitCountTotal;
        private System.Windows.Forms.Label exitCountAverage;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label eventCountTotal;
        private System.Windows.Forms.Label eventCountAverage;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label npcMostCommon;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label exitMostCommon;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label eventMostCommon;
        private System.Windows.Forms.Label label10;
    }
}