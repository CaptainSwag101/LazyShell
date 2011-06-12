using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LAZYSHELL.ScriptsEditor;

namespace LAZYSHELL
{
    public partial class FixPointers : Form
    {
        private EventScripts scripts;
        private TreeViewWrapper treeViewWrapper;
        // constructor
        public FixPointers(EventScripts scripts, TreeViewWrapper treeViewWrapper)
        {
            this.scripts = scripts;
            this.treeViewWrapper = treeViewWrapper;
            InitializeComponent();
            //comboBox1.SelectedIndex = 0;
        }
        // event handlers
        private void button1_Click(object sender, EventArgs e)
        {
            scripts.Delta = (int)numericUpDown1.Value;
            scripts.Apply = true;
            this.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            scripts.Apply = false;
            this.Close();
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDown1.Hexadecimal = checkBox1.Checked;
        }
    }
}
