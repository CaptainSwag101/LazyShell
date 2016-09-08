namespace LazyShell.Areas
{
    partial class OpacityForm
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
			this.opacityLevel = new System.Windows.Forms.TrackBar();
			((System.ComponentModel.ISupportInitialize)(this.opacityLevel)).BeginInit();
			this.SuspendLayout();
			// 
			// opacityLevel
			// 
			this.opacityLevel.AutoSize = false;
			this.opacityLevel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.opacityLevel.Location = new System.Drawing.Point(0, 0);
			this.opacityLevel.Maximum = 100;
			this.opacityLevel.Name = "opacityLevel";
			this.opacityLevel.Size = new System.Drawing.Size(292, 11);
			this.opacityLevel.TabIndex = 2;
			this.opacityLevel.TickStyle = System.Windows.Forms.TickStyle.None;
			this.opacityLevel.Value = 100;
			this.opacityLevel.ValueChanged += new System.EventHandler(this.opacityLevel_ValueChanged);
			// 
			// OpacityForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(292, 11);
			this.Controls.Add(this.opacityLevel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.Location = new System.Drawing.Point(0, 0);
			this.MaximumSize = new System.Drawing.Size(1600, 50);
			this.MinimumSize = new System.Drawing.Size(40, 40);
			this.Name = "OpacityForm";
			this.ShowInTaskbar = false;
			this.Text = "Opacity Level  =  100%";
			this.TopMost = true;
			this.VisibleChanged += new System.EventHandler(this.OpacityForm_VisibleChanged);
			((System.ComponentModel.ISupportInitialize)(this.opacityLevel)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TrackBar opacityLevel;
    }
}