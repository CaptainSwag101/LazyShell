namespace SMRPGED.Encryption
{
    partial class HashCheckFail
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
            this.messageRTB = new System.Windows.Forms.RichTextBox();
            this.label78 = new System.Windows.Forms.Label();
            this.panel64 = new System.Windows.Forms.Panel();
            this.panel64.SuspendLayout();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.BackColor = System.Drawing.SystemColors.Window;
            this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.okButton.Location = new System.Drawing.Point(1, 100);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(126, 19);
            this.okButton.TabIndex = 2;
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
            this.passwordTextBox.Size = new System.Drawing.Size(144, 14);
            this.passwordTextBox.TabIndex = 3;
            this.passwordTextBox.Text = "14zy5h311";
            this.passwordTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.passwordTextBox_KeyDown);
            // 
            // cancelButton
            // 
            this.cancelButton.BackColor = System.Drawing.SystemColors.Window;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.Location = new System.Drawing.Point(127, 100);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(126, 19);
            this.cancelButton.TabIndex = 5;
            this.cancelButton.Tag = " ";
            this.cancelButton.Text = "CANCEL";
            this.cancelButton.UseCompatibleTextRendering = true;
            this.cancelButton.UseVisualStyleBackColor = false;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // messageRTB
            // 
            this.messageRTB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.messageRTB.Location = new System.Drawing.Point(2, 2);
            this.messageRTB.Name = "messageRTB";
            this.messageRTB.ReadOnly = true;
            this.messageRTB.Size = new System.Drawing.Size(250, 78);
            this.messageRTB.TabIndex = 6;
            this.messageRTB.Text = "";
            // 
            // label78
            // 
            this.label78.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label78.Location = new System.Drawing.Point(2, 82);
            this.label78.Name = "label78";
            this.label78.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.label78.Size = new System.Drawing.Size(96, 17);
            this.label78.TabIndex = 444;
            this.label78.Text = "Author Password";
            // 
            // panel64
            // 
            this.panel64.BackColor = System.Drawing.SystemColors.Window;
            this.panel64.Controls.Add(this.passwordTextBox);
            this.panel64.Location = new System.Drawing.Point(100, 82);
            this.panel64.Name = "panel64";
            this.panel64.Size = new System.Drawing.Size(152, 17);
            this.panel64.TabIndex = 456;
            // 
            // HashCheckFail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlText;
            this.ClientSize = new System.Drawing.Size(254, 120);
            this.ControlBox = false;
            this.Controls.Add(this.panel64);
            this.Controls.Add(this.label78);
            this.Controls.Add(this.messageRTB);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HashCheckFail";
            this.Text = "Signature Check Failed";
            this.TopMost = true;
            this.panel64.ResumeLayout(false);
            this.panel64.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.RichTextBox messageRTB;
        private System.Windows.Forms.Label label78;
        private System.Windows.Forms.Panel panel64;
    }
}