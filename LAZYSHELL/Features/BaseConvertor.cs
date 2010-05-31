using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LAZYSHELL
{
    public partial class BaseConvertor : Form
    {
        public BaseConvertor()
        {
            InitializeComponent();
        }

        bool updating;
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (updating) return;
            updating = true;
            numericUpDown2.Value = numericUpDown1.Value;
            updating = false;
        }
        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            if (updating) return;
            updating = true;
            numericUpDown1.Value = numericUpDown2.Value;
            updating = false;
        }
        private void numericUpDown1_KeyUp(object sender, KeyEventArgs e)
        {
            if (updating) return;
            updating = true;
            numericUpDown2.Value = numericUpDown1.Value;
            updating = false;
        }
        private void numericUpDown2_KeyUp(object sender, KeyEventArgs e)
        {
            if (updating) return;
            updating = true;
            numericUpDown1.Value = numericUpDown2.Value;
            updating = false;
        }
    }
}
