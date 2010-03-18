namespace SMRPGED
{
    partial class ProgressBar
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
            this.loadingWhat = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.panel8.SuspendLayout();
            this.SuspendLayout();
            // 
            // loadingWhat
            // 
            this.loadingWhat.BackColor = System.Drawing.SystemColors.ControlDark;
            this.loadingWhat.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadingWhat.ForeColor = System.Drawing.SystemColors.Control;
            this.loadingWhat.Location = new System.Drawing.Point(2, 2);
            this.loadingWhat.Name = "loadingWhat";
            this.loadingWhat.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.loadingWhat.Size = new System.Drawing.Size(422, 17);
            this.loadingWhat.TabIndex = 388;
            this.loadingWhat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.SystemColors.Control;
            this.panel8.Controls.Add(this.progressBar1);
            this.panel8.Location = new System.Drawing.Point(2, 21);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(422, 18);
            this.panel8.TabIndex = 389;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(-1, -1);
            this.progressBar1.Maximum = 890;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(424, 20);
            this.progressBar1.Step = 1;
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 0;
            // 
            // ProgressBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlText;
            this.ClientSize = new System.Drawing.Size(426, 41);
            this.ControlBox = false;
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.loadingWhat);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProgressBar";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "...";
            this.TopMost = true;
            this.panel8.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label loadingWhat;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}