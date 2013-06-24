using System;
using System.Collections.Generic;
using System.Text;
using LAZYSHELL.ScriptsEditor;
using LAZYSHELL.ScriptsEditor.Commands;

namespace LAZYSHELL.Undo
{
    class GraphicEdit : Command
    {
        private byte[] changes;
        private byte[] graphics;
        private bool autoRedo = false;
        public bool AutoRedo() { return this.autoRedo; }
        //
        public GraphicEdit(byte[] graphics, byte[] changes)
        {
            this.graphics = graphics;
            this.changes = changes;
        }
        public void Execute()
        {
            byte[] temp = Bits.Copy(graphics);
            changes.CopyTo(graphics, 0);
            temp.CopyTo(changes, 0);
        }
    }
}
