namespace LazyShell
{
    partial class BaseConvertorForm
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
			this.baseConvHex = new System.Windows.Forms.TextBox();
			this.baseConvDec = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// baseConvHex
			// 
			this.baseConvHex.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.baseConvHex.Location = new System.Drawing.Point(35, 23);
			this.baseConvHex.Name = "baseConvHex";
			this.baseConvHex.Size = new System.Drawing.Size(121, 18);
			this.baseConvHex.TabIndex = 3;
			this.baseConvHex.Text = "0";
			this.baseConvHex.TextChanged += new System.EventHandler(this.baseConvHex_TextChanged);
			// 
			// baseConvDec
			// 
			this.baseConvDec.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.baseConvDec.Location = new System.Drawing.Point(35, 2);
			this.baseConvDec.Name = "baseConvDec";
			this.baseConvDec.Size = new System.Drawing.Size(121, 18);
			this.baseConvDec.TabIndex = 1;
			this.baseConvDec.Text = "0";
			this.baseConvDec.TextChanged += new System.EventHandler(this.baseConvDec_TextChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(4, 3);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(25, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Dec";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(4, 24);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(26, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Hex";
			// 
			// BaseConvertorForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(156, 46);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.baseConvDec);
			this.Controls.Add(this.baseConvHex);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Location = new System.Drawing.Point(0, 0);
			this.Name = "BaseConvertorForm";
			this.Text = "Base Converter";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BaseConvertorForm_FormClosing);
			this.VisibleChanged += new System.EventHandler(this.BaseConvertorForm_VisibleChanged);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox baseConvHex;
        private System.Windows.Forms.TextBox baseConvDec;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}