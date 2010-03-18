namespace SMRPGED.Encryption
{
    partial class SignatureViewer
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
            this.commentsRichTextBox = new System.Windows.Forms.RichTextBox();
            this.okButton = new System.Windows.Forms.Button();
            this.lockedLabel = new System.Windows.Forms.Label();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.passwordPanel = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.passwordPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // commentsRichTextBox
            // 
            this.commentsRichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.commentsRichTextBox.Location = new System.Drawing.Point(2, 21);
            this.commentsRichTextBox.Name = "commentsRichTextBox";
            this.commentsRichTextBox.ReadOnly = true;
            this.commentsRichTextBox.Size = new System.Drawing.Size(234, 121);
            this.commentsRichTextBox.TabIndex = 0;
            this.commentsRichTextBox.Text = "";
            // 
            // okButton
            // 
            this.okButton.BackColor = System.Drawing.SystemColors.Window;
            this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.okButton.Location = new System.Drawing.Point(1, 162);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(118, 19);
            this.okButton.TabIndex = 1;
            this.okButton.Text = "OK";
            this.okButton.UseCompatibleTextRendering = true;
            this.okButton.UseVisualStyleBackColor = false;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // lockedLabel
            // 
            this.lockedLabel.BackColor = System.Drawing.Color.Yellow;
            this.lockedLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lockedLabel.Enabled = false;
            this.lockedLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lockedLabel.ForeColor = System.Drawing.Color.Red;
            this.lockedLabel.Location = new System.Drawing.Point(1, 143);
            this.lockedLabel.Name = "lockedLabel";
            this.lockedLabel.Padding = new System.Windows.Forms.Padding(1, 1, 0, 2);
            this.lockedLabel.Size = new System.Drawing.Size(118, 19);
            this.lockedLabel.TabIndex = 4;
            this.lockedLabel.Text = "This Rom is Locked";
            this.lockedLabel.Visible = false;
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.passwordTextBox.Location = new System.Drawing.Point(4, 2);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(108, 14);
            this.passwordTextBox.TabIndex = 5;
            this.passwordTextBox.Text = "Enter Password";
            this.passwordTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.passwordTextBox_KeyDown);
            // 
            // cancelButton
            // 
            this.cancelButton.BackColor = System.Drawing.SystemColors.Window;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.Location = new System.Drawing.Point(119, 162);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(118, 19);
            this.cancelButton.TabIndex = 7;
            this.cancelButton.Text = "CANCEL";
            this.cancelButton.UseCompatibleTextRendering = true;
            this.cancelButton.UseVisualStyleBackColor = false;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label1.Location = new System.Drawing.Point(2, 2);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 1, 0, 2);
            this.label1.Size = new System.Drawing.Size(234, 17);
            this.label1.TabIndex = 453;
            this.label1.Text = "SIGNATURE INFO";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // passwordPanel
            // 
            this.passwordPanel.BackColor = System.Drawing.SystemColors.Window;
            this.passwordPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.passwordPanel.Controls.Add(this.passwordTextBox);
            this.passwordPanel.Enabled = false;
            this.passwordPanel.Location = new System.Drawing.Point(119, 143);
            this.passwordPanel.Name = "passwordPanel";
            this.passwordPanel.Size = new System.Drawing.Size(118, 19);
            this.passwordPanel.TabIndex = 457;
            this.passwordPanel.Visible = false;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(2, 144);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(0, 1, 0, 2);
            this.label2.Size = new System.Drawing.Size(234, 17);
            this.label2.TabIndex = 458;
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SignatureViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlText;
            this.ClientSize = new System.Drawing.Size(238, 182);
            this.ControlBox = false;
            this.Controls.Add(this.passwordPanel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.lockedLabel);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.commentsRichTextBox);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SignatureViewer";
            this.Text = "Signature Viewer";
            this.passwordPanel.ResumeLayout(false);
            this.passwordPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox commentsRichTextBox;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Label lockedLabel;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel passwordPanel;
        private System.Windows.Forms.Label label2;
    }
}