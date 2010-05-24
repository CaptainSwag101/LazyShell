using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SMRPGED.Encryption
{
    public partial class SignatureViewer : Form
    {
        private Stamp stamp;
        private Model model;

        public SignatureViewer(Stamp stamp, Model model, bool passEntry)
        {
            this.stamp = stamp;
            this.model = model;

            InitializeComponent();
            
            InitializeInfo(passEntry);
        }
        private void InitializeInfo(bool passEntry)
        {
            this.commentsRichTextBox.Text = "Author: " + stamp.Name + "\n";
            this.commentsRichTextBox.Text += "Publish Date: " + stamp.Date + "\n\n";
            this.commentsRichTextBox.Text += stamp.Comments;

            if (stamp.Locked)
            {
                this.lockedLabel.Enabled = true;
                this.lockedLabel.Visible = true;
                this.passwordPanel.Enabled = true;
                this.passwordPanel.Visible = true;
            }
            if (!passEntry)
            {
                this.passwordPanel.Enabled = false;
                this.okButton.Enabled = false;
            }
        }
        private void okButton_Click(object sender, EventArgs e)
        {
            if (stamp.Locked)
            {
                Cipher cipher = new Cipher(model.Data, model);
                if (cipher.CheckPassword(this.passwordTextBox.Text))
                {
                    stamp.Locked = false;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Invalid Password", "LAZY SHELL"); // Notify user some other way
                }

            }
            else
                this.Close();
            
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void passwordTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                okButton_Click(null, null);
        }
    }
}