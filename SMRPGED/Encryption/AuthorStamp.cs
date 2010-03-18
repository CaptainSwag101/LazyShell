using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SMRPGED.Encryption
{
    public partial class AuthorStamp : Form
    {
        private byte[] data;
        private Model model;
        private Stamp stamp;
        private Cipher cipher;
        
        public AuthorStamp(Model model, Stamp stamp)
        {
            this.model = model;
            this.data = model.Data;
            this.stamp = stamp;
            stamp.Invalidated = true;


            InitializeComponent();


            cipher = new Cipher(model.Data, model);
        }
        
        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            // Save
            stamp.Clear();

            if (this.passwordTextBox.Text == "")
            {
                MessageBox.Show("Enter a password to publish rom");
                stamp.Invalidated = true;
                return;
            }

            stamp.Name = this.nameTextBox.Text;
            stamp.Comments = this.commentsRichTextBox.Text;
            stamp.Password = this.passwordTextBox.Text;
            stamp.DateStamp = dateStampCheckBox.Checked;
            stamp.Published = publishedCheckBox.Checked;
            stamp.Date = DateTime.Now.ToString();
            stamp.Invalidated = false;

            this.Close();
        }

        private void publishedCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (this.publishedCheckBox.Checked)
                this.publishedCheckBox.ForeColor = Color.FromArgb(0, 0, 0xCC);
            else
                this.publishedCheckBox.ForeColor = Color.FromKnownColor(KnownColor.Control);
        }

        private void dateStampCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (this.dateStampCheckBox.Checked)
            {
                this.dateStampCheckBox.ForeColor = Color.FromArgb(0, 0, 0xCC);
            }
            else
            {
                this.dateStampCheckBox.ForeColor = Color.FromKnownColor(KnownColor.Control);
            }
        }



    }
}