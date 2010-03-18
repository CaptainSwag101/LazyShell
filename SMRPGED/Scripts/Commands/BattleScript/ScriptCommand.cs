using System;
using System.Collections.Generic;
using System.Text;
using SMRPGED.ScriptsEditor;

namespace SMRPGED.ScriptsEditor{
    public abstract class ScriptCommand
    {
        public bool editable = false;
        protected bool validCommand = false; public bool ValidCommand { get { return this.validCommand; } set { validCommand = value; } }
        protected int length; public int Length { get { return this.length; } set { length = value; } }
        protected int commandID; public int CommandID { get { return commandID; } set { commandID = value; } }
        protected byte[] commandData; public byte[] CommandData { get { return commandData; } set { commandData = value; } }

        public abstract void ModifyCommand(int offset, byte change);
        public abstract override string ToString();
    }
}
