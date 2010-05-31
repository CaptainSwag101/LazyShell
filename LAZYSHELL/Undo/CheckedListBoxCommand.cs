using System;
using System.Collections.Generic;
using System.Text;

namespace LAZYSHELL.Undo
{
    class CheckedListBoxCommand : Command
    {
        private System.Windows.Forms.CheckedListBox sender;
        int index;
        bool value;
        private bool autoRedo = true; public bool AutoRedo() { return this.autoRedo; }
        public CheckedListBoxCommand(object sender, System.Windows.Forms.ItemCheckEventArgs e)
        {
            this.sender = (System.Windows.Forms.CheckedListBox)sender;
            this.index = e.Index;
            this.value = this.sender.GetItemChecked(index);
        }
        public void Execute()
        {
            sender.SetItemChecked(index, value);
        }

    }
}
