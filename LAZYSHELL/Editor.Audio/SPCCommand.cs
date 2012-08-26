using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LAZYSHELL
{
    public partial class SPCCommand : Form
    {
        public int Opcode;
        public SPCCommand()
        {
            InitializeComponent();
            comboBox1.Items.AddRange(Lists.SPCCommands);
        }
        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
                return;
            if (comboBox1.SelectedIndex == 0)
                this.Opcode = 0;
            else
                this.Opcode = comboBox1.SelectedIndex + 0xC3;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        private void SPCCommand_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                buttonOK.PerformClick();
            else if (e.KeyData == Keys.Escape)
                buttonCancel.PerformClick();
        }
    }
}
