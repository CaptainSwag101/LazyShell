namespace LazyShell
{
    partial class ByteEditor
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
			this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
			this.apply = new System.Windows.Forms.Button();
			this.cancel = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.empty = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
			this.SuspendLayout();
			// 
			// numericUpDown1
			// 
			this.numericUpDown1.Location = new System.Drawing.Point(93, 12);
			this.numericUpDown1.Name = "numericUpDown1";
			this.numericUpDown1.Size = new System.Drawing.Size(75, 21);
			this.numericUpDown1.TabIndex = 1;
			// 
			// apply
			// 
			this.apply.Location = new System.Drawing.Point(93, 39);
			this.apply.Name = "apply";
			this.apply.Size = new System.Drawing.Size(75, 23);
			this.apply.TabIndex = 2;
			this.apply.Text = "Apply";
			this.apply.UseVisualStyleBackColor = true;
			this.apply.Click += new System.EventHandler(this.apply_Click);
			// 
			// cancel
			// 
			this.cancel.Location = new System.Drawing.Point(174, 39);
			this.cancel.Name = "cancel";
			this.cancel.Size = new System.Drawing.Size(75, 23);
			this.cancel.TabIndex = 2;
			this.cancel.Text = "Cancel";
			this.cancel.UseVisualStyleBackColor = true;
			this.cancel.Click += new System.EventHandler(this.cancel_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 14);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(38, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "Byte 0";
			// 
			// empty
			// 
			this.empty.Location = new System.Drawing.Point(12, 39);
			this.empty.Name = "empty";
			this.empty.Size = new System.Drawing.Size(75, 23);
			this.empty.TabIndex = 2;
			this.empty.Text = "Empty";
			this.empty.UseVisualStyleBackColor = true;
			this.empty.Click += new System.EventHandler(this.empty_Click);
			// 
			// ByteEditor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(261, 74);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.cancel);
			this.Controls.Add(this.empty);
			this.Controls.Add(this.apply);
			this.Controls.Add(this.numericUpDown1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Location = new System.Drawing.Point(0, 0);
			this.Name = "ByteEditor";
			this.ShowInTaskbar = false;
			this.Text = "Byte Editor";
			this.TopMost = true;
			this.VisibleChanged += new System.EventHandler(this.ByteEditor_VisibleChanged);
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Button apply;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button empty;
    }
}