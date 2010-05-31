using System;
using System.Collections.Generic;
using System.Text;

namespace LAZYSHELL.Undo
{
    class TrackBarCommand : Command
    {
        System.Windows.Forms.TrackBar sender;
        int value;
        private bool autoRedo = true; public bool AutoRedo() { return this.autoRedo; }

        public TrackBarCommand(object sender, int value)
        {
            this.sender = (System.Windows.Forms.TrackBar)sender;
            this.value = value;
        }
        public void Execute()
        {
            sender.Value = value;
        }

    }
}
