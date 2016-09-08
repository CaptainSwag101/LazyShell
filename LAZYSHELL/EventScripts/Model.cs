using System;
using System.Collections.Generic;
using System.Text;

namespace LazyShell.EventScripts
{
    public static class Model
    {
        #region Variables

        // ROM buffer
        public static byte[] ROM
        {
            get { return LazyShell.Model.ROM; }
            set { LazyShell.Model.ROM = value; }
        }

        // Elements
        private static EventScript[] eventScripts;
        private static ActionScript[] actionScripts;
        public static EventScript[] EventScripts
        {
            get
            {
                if (eventScripts == null)
                {
                    eventScripts = new EventScript[4096];
                    for (int i = 0; i < eventScripts.Length; i++)
                        eventScripts[i] = new EventScript(i);
                }
                return eventScripts;
            }
            set { eventScripts = value; }
        }
        public static ActionScript[] ActionScripts
        {
            get
            {
                if (actionScripts == null)
                {
                    actionScripts = new ActionScript[1024];
                    for (int i = 0; i < actionScripts.Length; i++)
                        actionScripts[i] = new ActionScript(i);
                }
                return actionScripts;
            }
            set { actionScripts = value; }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Returns the number of available bytes in the current event script's bank.
        /// </summary>
        /// <returns></returns>
        public static int FreeEventScriptBytes(int currentIndex)
        {
            int maxSize;
            int start = 0;
            int end = 4096;
            if (currentIndex < 1536)
            {
                maxSize = 0x10000 - 0xC00;
                start = 0; end = 1536;
            }
            else if (currentIndex < 3072)
            {
                maxSize = 0x10000 - 0xC00;
                start = 1536; end = 3072;
            }
            else
            {
                maxSize = 0xE000 - 0x800;
                start = 3072; end = 4096;
            }
            int totalSize = 0;
            for (int i = start; i < end; i++)
                totalSize += eventScripts[i].Buffer.Length;
            return maxSize - totalSize - 1;
        }
        /// <summary>
        /// Returns the number of available bytes in the action script bank.
        /// </summary>
        /// <returns></returns>
        public static int FreeActionScriptBytes()
        {
            int totalSize = 0;
            for (int i = 0; i < actionScripts.Length; i++)
                totalSize += actionScripts[i].Buffer.Length;
            int maxSize = 0xC000 - 0x800;
            return maxSize - totalSize - 1;
        }
        /// <summary>
        /// Returns a string array of the dialogues, parsed and reduced to 37-byte length.
        /// </summary>
        /// <returns></returns>
        public static string[] GetDialogueStubs()
        {
            string[] tables = Dialogues.Model.DTEStr(true);
            string[] names = new string[Dialogues.Model.Dialogues.Length];
            for (int i = 0; i < Dialogues.Model.Dialogues.Length; i++)
                names[i] = Dialogues.Model.Dialogues[i].GetStub(true, tables);
            return names;
        }

        // Data management
        public static void ClearAll()
        {
            actionScripts = null;
            eventScripts = null;
        }
        public static void LoadAll()
        {
            object dummy;
            dummy = ActionScripts;
            dummy = EventScripts;
        }

        #endregion

        #region Temporary

        public static MostCommon[] MostCommonEvents = new MostCommon[256];
        public static MostCommon[] MostCommonEventsFD = new MostCommon[256];
        public struct MostCommon
        {
            public int Opcode;
            public int Param1;
            public int Frequency;
            public override string ToString()
            {
                return Opcode.ToString("X2") + "-" + Param1.ToString("X2") + ", frequency: " + Frequency;
            }
        }

        #endregion
    }
}
