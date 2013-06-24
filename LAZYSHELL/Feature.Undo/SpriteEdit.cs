using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LAZYSHELL.Undo
{
    class SpriteEdit : Command
    {
        private List<Mold> molds;
        private ListBox listbox;
        private Mold moldA;
        private Mold moldB;
        private int index;
        private int indexB;
        private SpriteAction action;
        private bool autoRedo = false;
        public bool AutoRedo() { return this.autoRedo; }
        public SpriteEdit(SpriteAction action, List<Mold> molds, ListBox listbox, Mold moldA, Mold moldB, int index, int indexB)
        {
            this.action = action;
            this.molds = molds;
            this.listbox = listbox;
            this.moldA = moldA.Copy();
            this.moldB = moldB.Copy();
            this.index = index;
            this.indexB = indexB;
        }
        public void Execute()
        {
            if (action == SpriteAction.Edit)
            {
                this.molds[index] = this.moldB.Copy();
                Mold temp = this.moldA.Copy();
                this.moldA = this.moldB.Copy();
                this.moldB = temp;
                this.listbox.SelectedIndex = this.index;
            }
            else if (action == SpriteAction.Create)
            {
                this.molds.RemoveAt(index);
                this.listbox.Items.RemoveAt(index);
                this.listbox.SelectedIndex = Math.Min(this.index, this.listbox.Items.Count - 1);
                this.action = SpriteAction.Delete;
            }
            else if (action == SpriteAction.Delete)
            {
                this.molds.Insert(index, moldB.Copy());
                this.listbox.Items.Insert(index, "Mold " + index);
                this.listbox.SelectedIndex = Math.Min(this.index, this.listbox.Items.Count - 1);
                this.action = SpriteAction.Create;
            }
            else if (action == SpriteAction.MoveDown)
            {
                this.molds.Reverse(index, 2);
                this.listbox.SelectedIndex = index;
                this.action = SpriteAction.MoveUp;
            }
            else if (action == SpriteAction.MoveUp)
            {
                this.molds.Reverse(index, 2);
                this.listbox.SelectedIndex = index + 1;
                this.action = SpriteAction.MoveDown;
            }
            else if (action == SpriteAction.IndexChange)
            {
                this.listbox.SelectedIndex = this.indexB;
                int index = this.index;
                this.index = this.indexB;
                this.indexB = index;
            }
            //
        }
    }
    enum SpriteAction
    {
        Edit, MoveUp, MoveDown, Delete, Create, IndexChange
    }
}
