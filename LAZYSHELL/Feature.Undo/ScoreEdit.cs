using System;
using System.Collections.Generic;
using System.Text;

namespace LAZYSHELL.Undo
{
    public enum ScoreEdit
    {
        InsertNote,
        EraseNote,
        AddStaff,
        DeleteStaff
    }
    class ScoreEditCommand : Command
    {
        // class variables and accessors
        private object items;
        private ScoreEdit scoreEdit;
        private int index;
        private object item;
        private bool autoRedo = false; public bool AutoRedo() { return this.autoRedo; }
        // constructor
        public ScoreEditCommand(ScoreEdit scoreEdit, object items, int index, object item)
        {
            this.items = items;
            this.scoreEdit = scoreEdit;
            this.index = index;
            this.item = item;
            Execute();
        }
        // execute
        public void Execute()
        {
            if (scoreEdit == ScoreEdit.EraseNote)
            {
                scoreEdit = ScoreEdit.InsertNote;
                ((List<object>)items).Remove(item);
            }
            else if (scoreEdit == ScoreEdit.InsertNote)
            {
                scoreEdit = ScoreEdit.EraseNote;
                ((List<object>)items).Insert(index, item);
            }
            else if (scoreEdit == ScoreEdit.AddStaff)
            {
                scoreEdit = ScoreEdit.DeleteStaff;
                ((List<Staff>)items).Insert(index, (Staff)item);
            }
            else if (scoreEdit == ScoreEdit.DeleteStaff)
            {
                scoreEdit = ScoreEdit.AddStaff;
                ((List<Staff>)items).Remove((Staff)item);
            }
        }
    }
}
