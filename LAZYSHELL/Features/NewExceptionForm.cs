using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace LAZYSHELL
{
    public partial class NewExceptionForm : Form
    {
        public NewExceptionForm(Exception exception)
        {
            InitializeComponent();
            Bitmap icon = SystemIcons.Error.ToBitmap();
            pictureBox1.Size = icon.Size;
            pictureBox1.Image = icon;
            string forumthread = "http://acmlm.no-ip.org/board/thread.php?id=7005";
            label1.Text = "Lazy Shell has encountered an error. Please copy the contents of the box below and post them as a new reply to this thread:\n\n";
            label1.Links.Add(label1.Text.Length, forumthread.Length, forumthread);
            label1.Text += forumthread;
            //
            Assembly assembly = Assembly.GetExecutingAssembly();
            richTextBox1.Text = assembly.ToString() + "\r\n\r\n";
            richTextBox1.Text += "**************Exception Text**************\r\n";
            richTextBox1.Text += exception.Message + "\r\n";
            StringReader reader = new StringReader(exception.StackTrace);
            string line;
            int number = 0;
            while ((line = reader.ReadLine()) != null)
            {
                if (!line.StartsWith("   at LAZYSHELL"))
                    continue;
                richTextBox1.Text += line + "\r\n";
            }
            richTextBox1.Text += "\r\n";
            //
            richTextBox1.Text += "**************Recent Event History**************\r\n";
            reader = new StringReader(Model.History);
            line = null;
            number = 0;
            while ((line = reader.ReadLine()) != null && number++ < 10)
                richTextBox1.Text += line + "\r\n";
        }
        //
        private void copyContents_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(richTextBox1.Text);
        }
        private void ignoreError_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void saveAndClose_Click(object sender, EventArgs e)
        {

        }
        private void saveAsAndClose_Click(object sender, EventArgs e)
        {

        }
        private void close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void label1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.Link.LinkData.ToString());
        }
    }
}
