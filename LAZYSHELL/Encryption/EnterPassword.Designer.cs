namespace LAZYSHELL.Encryption
{
    partial class EnterPassword
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
            this.okButton = new System.Windows.Forms.Button();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.panel64 = new System.Windows.Forms.Panel();
            this.panel64.SuspendLayout();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.BackColor = System.Drawing.SystemColors.Window;
            this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.okButton.Location = new System.Drawing.Point(1, 20);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(80, 19);
            this.okButton.TabIndex = 0;
            this.okButton.Text = "OK";
            this.okButton.UseCompatibleTextRendering = true;
            this.okButton.UseVisualStyleBackColor = false;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.passwordTextBox.Location = new System.Drawing.Point(4, 2);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(150, 14);
            this.passwordTextBox.TabIndex = 2;
            this.passwordTextBox.Text = "Enter Password";
            this.passwordTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.passwordTextBox_KeyDown);
            // 
            // cancelButton
            // 
            this.cancelButton.BackColor = System.Drawing.SystemColors.Window;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.Location = new System.Drawing.Point(81, 20);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(80, 19);
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Text = "CANCEL";
            this.cancelButton.UseCompatibleTextRendering = true;
            this.cancelButton.UseVisualStyleBackColor = false;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // panel64
            // 
            this.panel64.BackColor = System.Drawing.SystemColors.Window;
            this.panel64.Controls.Add(this.passwordTextBox);
            this.panel64.Location = new System.Drawing.Point(2, 2);
            this.panel64.Name = "panel64";
            this.panel64.Size = new System.Drawing.Size(158, 17);
            this.panel64.TabIndex = 455;
            // 
            // EnterPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlText;
            this.ClientSize = new System.Drawing.Size(162, 40);
            this.ControlBox = false;
            this.Controls.Add(this.panel64);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EnterPassword";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "ENTER AUTHOR PASSWORD";
            this.TopMost = true;
            this.panel64.ResumeLayout(false);
            this.panel64.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Panel panel64;
    }
}