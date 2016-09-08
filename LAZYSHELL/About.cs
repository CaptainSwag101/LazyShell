using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LazyShell
{
    public partial class About : Controls.NewForm
    {
        // Variables
        private MainForm ownerForm;

        // Constructor
        public About(MainForm ownerForm)
        {
            this.ownerForm = ownerForm;
            InitializeComponent();
        }

        // Event Handlers
        private void richTextBox1_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.LinkText);
        }
        private void button1_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

		private void About_Load(object sender, EventArgs e)
		{
			if (Environment.Is64BitProcess)
			{
				copyrightTextBox.Text = "Lazy Shell, Version 4.0.0.2 64-bit" +
										"\nCopyright © 2007-2015 giangurgolo & Omega" +
										"\n" +
										"\nCreated by Omega & giangurgolo" +
										"\nMaintained by CaptainSwag101";
			}
			else
			{
				copyrightTextBox.Text = "Lazy Shell, Version 4.0.0.2" +
										"\nCopyright © 2007-2015 giangurgolo & Omega" +
				                        "\n" +
										"\nCreated by Omega & giangurgolo" +
										"\nMaintained by CaptainSwag101";
			}
		}
	}
}