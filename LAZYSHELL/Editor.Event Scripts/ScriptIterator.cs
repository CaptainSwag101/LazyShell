using System;
using System.Collections.Generic;
using System.Text;
using LAZYSHELL.ScriptsEditor.Commands;

namespace LAZYSHELL.ScriptsEditor
{
    class ScriptIterator
    {
        private EventScript es = null;
        private ActionQueue aq = null;

        private int parentIndex = 0; public int ParentIndex { get { return this.parentIndex; } }
        private int childIndex = -1; public int ChildIndex { get { return this.childIndex; } }

        public ScriptIterator(EventScript es)
        {
            this.es = es;
        }
        public ScriptIterator(ActionQueue aq)
        {
            this.aq = aq;
        }
        /* 
         * Returns the next command in the EventScript or ActionScript
         * Will throw an exception if were at an invalid index, so check the IsDone before calling this
         */
        public EventActionCommand Next()
        {
            EventScriptCommand esc;
            ActionQueueCommand aqc;
            if (es != null)
            {
                esc = (EventScriptCommand)es.Commands[parentIndex];

                if (esc.IsActionQueueTrigger && esc.EmbeddedActionQueue.Commands.Count > 0)
                {
                    if (childIndex < esc.EmbeddedActionQueue.Commands.Count)
                    {
                        if (childIndex != -1)
                        {
                            aqc = (ActionQueueCommand)esc.EmbeddedActionQueue.Commands[childIndex];

                            childIndex++;

                            if (childIndex == esc.EmbeddedActionQueue.Commands.Count)
                            {
                                childIndex = -1;
                                parentIndex++;
                            }

                            return (EventActionCommand)aqc;
                        }

                        childIndex++;
                        return (EventActionCommand)esc;
                    }
                }

                childIndex = -1;
                parentIndex++;
                return (EventActionCommand)esc;
            }
            else if (aq != null)
            {
                aqc = (ActionQueueCommand)aq.Commands[parentIndex];
                parentIndex++;
                return (EventActionCommand)aqc;
            }
            throw new Exception("Invalid Script");
        }
        public bool IsDone
        {
            get
            {
                if (es != null)
                {
                    if (parentIndex < es.Commands.Count)
                        return false; // if its not the last command, were not done
                    if (es.Commands.Count <= 0)
                        return true;

                    // Get the last command to check child index
                    EventScriptCommand esc = (EventScriptCommand)es.Commands[es.Commands.Count - 1];

                    if (esc.IsActionQueueTrigger && esc.EmbeddedActionQueue.Commands.Count > 0)
                    {
                        if (childIndex != -1 && childIndex < esc.EmbeddedActionQueue.Commands.Count)
                            return false;
                    }
                }
                else if (aq != null)
                {
                    if (parentIndex < aq.Commands.Count)
                        return false;
                }

                return true;
            }
        }
    }
}
