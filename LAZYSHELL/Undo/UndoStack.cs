using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace LazyShell.Undo
{
    class UndoStack
    {
        #region Variables

        private Edit[] edits;
        private Stack<Edit> redoStack;
        private Stack<int> undoCount;
        private Stack<int> redoCount;
        private int index = 0;
        private int undo = 0;
        private bool undoing = false;
        private bool redoing = false;
        private bool manualCount = false;

        #endregion

        /// <summary>
        /// Create a new edit stack.
        /// </summary>
        /// <param name="manualCount">Sets whether to manually accept execution counts or automatically assign single instances.</param>
        public UndoStack(bool manualCount)
        {
            edits = new Edit[65535];
            redoStack = new Stack<Edit>();
            undoCount = new Stack<int>();
            redoCount = new Stack<int>();
            this.manualCount = manualCount;
        }
        public UndoStack()
        {
            edits = new Edit[65535];
            redoStack = new Stack<Edit>();
            undoCount = new Stack<int>();
            redoCount = new Stack<int>();
        }

        #region Methods

        // Set maps
        public void SetTilemaps(Tilemap tilemap)
        {
            foreach (TilemapEdit edit in edits)
                if (edit != null)
                    edit.Tilemap = tilemap;
        }
        public void SetCollisionMaps(Tilemap tilemap)
        {
            foreach (CollisionEdit edit in edits)
                if (edit != null)
                    edit.Tilemap = tilemap;
        }

        /// <summary>
        /// Undo the last action.
        /// </summary>
        /// <returns></returns>
        public bool UndoCommand()
        {
            if (this.undoCount.Count <= 0 ||
                edits[index] == null ||
                edits.Length < 1 ||
                undo <= 0)
                return false;
            //
            undoing = true;
            int undoCount = this.undoCount.Pop();
            int redoCount = 0;
            for (; undoCount > 0; undoCount--, redoCount++)
            {
                if (index > 0 && edits[index] != null) // not going to wrap
                {
                    edits[index].Execute();
                    if (!edits[index].AutoRedo)
                        redoStack.Push(edits[index]);
                    index--;
                    undo--;
                }
                else if (index == 0 && edits[index] != null) // wrap
                {
                    edits[index].Execute();
                    if (!edits[index].AutoRedo)
                        redoStack.Push(edits[index]);
                    index = edits.Length - 1;
                    undo--;
                }
            }
            this.redoCount.Push(redoCount);
            undoing = false;
            //
            return true;
        }
        /// <summary>
        /// Redo the last action that was undone.
        /// </summary>
        /// <returns></returns>
        public bool RedoCommand()
        {
            if (this.redoCount.Count <= 0 ||
                redoStack.Count == 0)
                return false;
            //
            redoing = true;
            int redoCount = this.redoCount.Pop();
            int undoCount = 0;
            for (; redoCount > 0; redoCount--, undoCount++)
            {
                if (redoStack.Count > 0)
                {
                    Edit cmd = redoStack.Pop();
                    cmd.Execute();
                    if (!cmd.AutoRedo)
                        Push(cmd);
                }
            }
            this.undoCount.Push(undoCount);
            redoing = false;
            //
            return true;
        }
        /// <summary>
        /// Push an action onto the undo stack.
        /// </summary>
        /// <param name="cmd">The action to push.</param>
        public void Push(Edit cmd)
        {
            if (edits.Length <= 0)
                return;
            if (undoing)
            {
                redoStack.Push(cmd);
                return;
            }
            if (redoStack.Count != 0 && !redoing)
                redoStack.Clear();
            //
            index++;
            if (index < edits.Length)
            {
                edits[index] = cmd;
                if (undo < edits.Length)
                    undo++;
            }
            else if (index >= edits.Length)
            {
                // We have filled the whole array and are now overwriting the old commands
                index = 0;
                edits[index] = cmd;
                if (undo < edits.Length)
                    undo++;
            }
            if (!manualCount)
                undoCount.Push(1);
        }
        /// <summary>
        /// Push an action onto the undo or redo stack.
        /// </summary>
        /// <param name="count">The number of actions to push.</param>
        public void Push(int count)
        {
            if (edits.Length <= 0)
                return;
            if (undoing)
            {
                redoCount.Push(count);
                return;
            }
            if (redoCount.Count != 0 && !redoing)
                redoCount.Clear();
            //
            undoCount.Push(count);
        }

        /// <summary>
        /// Clears the undo and redo command stacks.
        /// </summary>
        public void Clear()
        {
            for (int i = 0; i < edits.Length; i++)
                edits[i] = null;
            redoStack.Clear();
            undoCount.Clear();
            redoCount.Clear();
            //
            index = 0;
            undo = 0;
        }

        #endregion
    }
}
