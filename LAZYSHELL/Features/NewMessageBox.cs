using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LAZYSHELL
{
    public partial class NewMessageBox : Form
    {
        public NewMessageBox(string title, string description, string contents)
        {
            InitializeComponent();
            this.Text = title;
            this.label1.Text = description;
            this.richTextBox1.Text = contents;
        }
        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    public static class NewMessage
    {
        public static void Show(string title, string description, string contents)
        {
            new NewMessageBox(title, description, contents).ShowDialog();
        }
    }
}
