using System;
using System.Collections.Generic;
using System.Text;
using LAZYSHELL.ScriptsEditor;
using LAZYSHELL.ScriptsEditor.Commands;

namespace LAZYSHELL.Undo
{
    class AnimationEdit : Command
    {
        private AnimationScripts form;
        private AnimationCommand asc;
        private int offset;
        private byte[] data;
        private bool autoRedo = false;
        public bool AutoRedo() { return this.autoRedo; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="asc">The command being modified.</param>
        /// <param name="offset">The offset of the data.</param>
        /// <param name="internalOffset">The internal offset of the command.</param>
        /// <param name="data">The ROM data.</param>
        public AnimationEdit(AnimationScripts form, AnimationCommand asc, int offset, byte[] data)
        {
            this.form = form;
            this.asc = asc;
            this.offset = offset;
            this.data = data;
            Execute(true);
        }
        public void Execute()
        {
            Execute(false);
        }
        public void Execute(bool push)
        {
            for (int i = 0; i < data.Length; i++)
            {
                byte temp = Model.ROM[offset + i];
                Model.ROM[offset + i] = data[i];
                data[i] = temp;
            }
            if (!push)
            {
                AnimationCommand temp = this.asc;
                this.asc = this.form.ASC;
                this.form.ASC = temp;
            }
        }
    }
}
