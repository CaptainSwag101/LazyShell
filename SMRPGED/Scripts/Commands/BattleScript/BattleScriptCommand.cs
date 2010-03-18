using System;
using System.Collections.Generic;
using System.Text;
using SMRPGED.ScriptsEditor;

namespace SMRPGED.ScriptsEditor 
{
    public abstract class BattleScriptCommand : ScriptCommand
    {
        // Anything specific to BattleScripts goes here
        // Code, variables, ect. Anything all BattleScripts require
        protected int option; public int Option { get { return this.option; } set { this.option = value; } }
        protected bool set; public bool Set { get { return this.set; } set { this.set = value; } }
        
        public BattleScriptCommand(byte[] commandData)
        {
            this.commandID = commandData[0];
            this.commandData = commandData;
        }

        protected DDlistName names;
        protected string[] targetNames;
        protected string[] battleEventNames;
        protected BattleDialogue[] battleDialogues;
        public DDlistName GetDDlistNames()
        {
            return names;            
        }
        public string[] GetTargetNames()
        {
            return targetNames;
        }
        public string[] GetBattleEventNames()
        {
            return battleEventNames;
        }
        public string[] GetBattleDialogueNames()
        {
            String[] names = new String[battleDialogues.Length];

            for (int i = 0; i < battleDialogues.Length; i++)
                names[i] = battleDialogues[i].GetBattleDialogueStub();

            return names;
        }
    }
}
