using System;
using System.Collections.Generic;
using System.Text;

namespace LAZYSHELL.Undo
{
    class ComboBoxCommand : Command
    {
        private System.Windows.Forms.ComboBox sender;
        private int value;
        private bool autoRedo = true; public bool AutoRedo() { return this.autoRedo; }

        public ComboBoxCommand(object sender, int value)
        {
            this.sender = (System.Windows.Forms.ComboBox)sender;
            this.value = value;
        }
        public void Execute()
        {
            sender.SelectedIndex = value;
        }

    }
}
