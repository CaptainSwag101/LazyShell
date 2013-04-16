using System;
using System.Collections.Generic;
using System.Text;

namespace LAZYSHELL.Undo
{
    public enum ScoreEdit
    {
        InsertNote,
        EraseNote,
        PasteNotes,
        DeleteNotes,
        AddStaff,
        DeleteStaff
    }
    class ScoreEditCommand : Command
    {
        // class variables and accessors
        private object collection;
        private ScoreEdit scoreEdit;
        private int index;
        private object itemA;
        private object itemB;
        private object itemC;
        private object items;
        private bool autoRedo = false; public bool AutoRedo() { return this.autoRedo; }
        // constructor
        public ScoreEditCommand(ScoreEdit scoreEdit, object collection, int index, object item)
        {
            this.collection = collection;
            this.scoreEdit = scoreEdit;
            this.index = index;
            this.itemB = item;
            Execute();
        }
        public ScoreEditCommand(ScoreEdit scoreEdit, object collection, object items, int index)
        {
            this.collection = collection;
            this.scoreEdit = scoreEdit;
            this.index = index;
            this.items = items;
            Execute();
        }
        /// <summary>
        /// If inserting a note at a different octave
        /// </summary>
        /// <param name="scoreEdit"></param>
        /// <param name="collection"></param>
        /// <param name="index"></param>
        /// <param name="itemA"></param>
        /// <param name="itemB"></param>
        public ScoreEditCommand(ScoreEdit scoreEdit, object collection, int index, object itemA, object itemB, object itemC)
        {
            this.collection = collection;
            this.scoreEdit = scoreEdit;
            this.index = index;
            this.itemA = itemA;
            this.itemB = itemB;
            this.itemC = itemC;
            Execute();
        }
        // execute
        public void Execute()
        {
            if (scoreEdit == ScoreEdit.EraseNote)
            {
                scoreEdit = ScoreEdit.InsertNote;
                try
                {
                    ((List<object>)collection).Remove(itemB);
                }
                catch
                {
                    if (itemA != null)
                        ((List<SPCCommand>)collection).Remove((SPCCommand)itemA);
                    ((List<SPCCommand>)collection).Remove((SPCCommand)itemB);
                    if (itemC != null)
                        ((List<SPCCommand>)collection).Remove((SPCCommand)itemC);
                }
            }
            else if (scoreEdit == ScoreEdit.InsertNote)
            {
                scoreEdit = ScoreEdit.EraseNote;
                try
                {
                    ((List<object>)collection).Insert(index, itemB);
                }
                catch
                {
                    if (itemC != null)
                        ((List<SPCCommand>)collection).Insert(index, (SPCCommand)itemC);
                    ((List<SPCCommand>)collection).Insert(index, (SPCCommand)itemB);
                    if (itemA != null)
                        ((List<SPCCommand>)collection).Insert(index, (SPCCommand)itemA);
                }
            }
            else if (scoreEdit == ScoreEdit.PasteNotes)
            {
                scoreEdit = ScoreEdit.DeleteNotes;
                try
                {
                    ((List<object>)collection).InsertRange(index, (List<object>)items);
                }
                catch
                {
                    ((List<SPCCommand>)collection).InsertRange(index, (List<SPCCommand>)items);
                }
            }
            else if (scoreEdit == ScoreEdit.DeleteNotes)
            {
                scoreEdit = ScoreEdit.PasteNotes;
                try
                {
                    ((List<object>)collection).RemoveRange(index, ((List<object>)items).Count);
                }
                catch
                {
                    ((List<SPCCommand>)collection).RemoveRange(index, ((List<SPCCommand>)items).Count);
                }
            }
            else if (scoreEdit == ScoreEdit.AddStaff)
            {
                scoreEdit = ScoreEdit.DeleteStaff;
                ((List<Staff>)collection).Insert(index, (Staff)itemB);
            }
            else if (scoreEdit == ScoreEdit.DeleteStaff)
            {
                scoreEdit = ScoreEdit.AddStaff;
                ((List<Staff>)collection).Remove((Staff)itemB);
            }
        }
    }
}
