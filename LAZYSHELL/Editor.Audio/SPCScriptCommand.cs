using System;
using System.Collections.Generic;
using System.Text;
using LAZYSHELL.ScriptsEditor.Commands;

namespace LAZYSHELL
{
    [Serializable()]
    public class SPCScriptCommand
    {
        private byte[] commandData; public byte[] CommandData { get { return this.commandData; } set { this.commandData = value; } }
        public int Length { get { return commandData.Length; } }
        public byte Opcode
        {
            get
            {
                if (this.Length > 0)
                    return this.commandData[0];
                else
                    return 0;
            }
            set { this.commandData[0] = value; }
        }
        public byte Option
        {
            get
            {
                if (this.Length > 0)
                    return this.commandData[1];
                else
                    return 0;
            }
            set { this.commandData[1] = value; }
        }
        private List<SPCScriptCommand> commands = new List<SPCScriptCommand>();
        public List<SPCScriptCommand> Commands { get { return this.commands; } set { this.commands = value; } }
        private SPCTrack spc;
        private SPCSound sound;
        private int channel; public int Channel { get { return this.channel; } set { this.channel = value; } }
        //
        public SPCScriptCommand(byte[] commandData, SPCTrack spc, int channel)
        {
            this.spc = spc;
            this.commandData = commandData;
            this.channel = channel;
        }
        public SPCScriptCommand(byte[] commandData, SPCSound sound, int channel)
        {
            this.sound = sound;
            this.commandData = commandData;
            this.channel = channel;
        }
        public override string ToString()
        {
            return Interpreter.Instance.InterpretSPCCommand(this);
        }
    }
}
