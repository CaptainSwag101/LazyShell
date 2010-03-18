using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SMRPGED.Encryption
{
    public partial class HashCheckFail : Form
    {
        private Stamp pass = null;
        public HashCheckFail(string message, Stamp pass)
        {
            this.pass = pass;
            InitializeComponent();
            this.messageRTB.Text = message;
        }
        public HashCheckFail(string message)
        {
            InitializeComponent();
            this.messageRTB.Text = message;
            this.cancelButton.Enabled = false;
            this.passwordTextBox.Enabled = false;
        }
        private void okButton_Click(object sender, EventArgs e)
        {
            if(pass != null)
                pass.Password = this.passwordTextBox.Text;
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            pass.Password = null;
            this.Close();
        }

        private void passwordTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                okButton_Click(null, null);
        }
    }
}