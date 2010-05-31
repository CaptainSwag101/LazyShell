using System;
using System.Collections.Generic;
using System.Text;

namespace LAZYSHELL.Undo
{
    class NumericUpDownCommand : Command
    {
        System.Windows.Forms.NumericUpDown sender;
        int value;
        private bool autoRedo = true; public bool AutoRedo() { return this.autoRedo; }

        public NumericUpDownCommand(object sender, int value)
        {
            this.sender = (System.Windows.Forms.NumericUpDown)sender;
            this.value = value;
        }
        public void Execute()
        {
            sender.Value = value;
        }
    }
}
