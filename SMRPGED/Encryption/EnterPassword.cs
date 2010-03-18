using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SMRPGED.Encryption
{
    public partial class EnterPassword : Form
    {
        private Stamp pass;
        public EnterPassword(Stamp stamp)
        {
            pass = stamp;
            InitializeComponent();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            this.pass.Password = this.passwordTextBox.Text;
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.pass.Password = null;
            this.Close();
        }

        private void passwordTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                okButton_Click(null, null);
        }
    }
}