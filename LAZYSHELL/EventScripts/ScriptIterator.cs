using System;
using System.Collections.Generic;
using System.Text;
using LAZYSHELL.EventScripts;

namespace LAZYSHELL.EventScripts
{
    class ScriptIterator
    {
        #region Variables

        private EventScript script = null;
        private ActionScript action = null;
        /// <summary>
        /// Gets or sets the index in the script's command collection
        /// that this iterator is currently at.
        /// </summary>
        public int ParentIndex { get; set; }
        /// <summary>
        /// Gets or sets the index in the current parent command's queue
        /// that this iterator is currently at.
        /// </summary>
        public int ChildIndex { get; set; }

        #endregion

        // Constructors
        public ScriptIterator(EventScript script)
        {
            this.script = script;
            this.ChildIndex = -1;
        }
        public ScriptIterator(ActionScript action)
        {
            this.action = action;
            this.ChildIndex = -1;
        }

        #region Methods

        /// <summary>
        /// Returns the next command in the EventScript or ActionScript.
        /// Throws an exception if at an invalid index -- check IsDone before calling this.
        /// </summary>
        /// <returns></returns>
        public Command Next()
        {
            if (script != null)
            {
                var esc = script.Commands[ParentIndex];
                if (esc.QueueTrigger && esc.Queue.Commands.Count > 0)
                {
                    if (ChildIndex < esc.Queue.Commands.Count)
                    {
                        if (ChildIndex != -1)
                        {
                            var asc = esc.Queue.Commands[ChildIndex++];
                            if (ChildIndex == esc.Queue.Commands.Count)
                            {
                                ChildIndex = -1;
                                ParentIndex++;
                            }
                            return asc;
                        }
                        ChildIndex++;
                        return esc;
                    }
                }
                ChildIndex = -1;
                ParentIndex++;
                return esc;
            }
            else if (action != null)
                return action.Commands[ParentIndex++];
            throw new Exception("Invalid Script");
        }
        /// <summary>
        /// Checks if the iterator has went beyond the bounds of the script's command collection.
        /// </summary>
        public bool IsDone
        {
            get
            {
                if (script != null)
                {
                    // If not the last command, then not done
                    if (ParentIndex < script.Commands.Count)
                        return false; 
                    if (script.Commands.Count <= 0)
                        return true;

                    // Get the last command to check child index
                    var esc = script.Commands[script.Commands.Count - 1];
                    if (esc.QueueTrigger && esc.Queue.Commands.Count > 0)
                    {
                        if (ChildIndex != -1 && ChildIndex < esc.Queue.Commands.Count)
                            return false;
                    }
                }
                else if (action != null)
                {
                    if (ParentIndex < action.Commands.Count)
                        return false;
                }
                return true;
            }
        }

        #endregion
    }
}
