using System;
using System.Collections.Generic;
using System.Text;
using LAZYSHELL.ScriptsEditor.Commands;

namespace LAZYSHELL
{
    [Serializable()]
    public class SPCCommand
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
        public byte Param1
        {
            get
            {
                if (this.Length > 1)
                    return this.commandData[1];
                else
                    return 0;
            }
            set { this.commandData[1] = value; }
        }
        public byte Param2
        {
            get
            {
                if (this.Length > 2)
                    return this.commandData[2];
                else
                    return 0;
            }
            set { this.commandData[2] = value; }
        }
        public byte Param3
        {
            get
            {
                if (this.Length > 3)
                    return this.commandData[3];
                else
                    return 0;
            }
            set { this.commandData[3] = value; }
        }
        private List<SPCCommand> commands = new List<SPCCommand>();
        public List<SPCCommand> Commands { get { return this.commands; } set { this.commands = value; } }
        private SPC spc;
        private int channel; public int Channel { get { return this.channel; } set { this.channel = value; } }
        //
        public SPCCommand(byte[] commandData, SPC spc, int channel)
        {
            this.spc = spc;
            this.commandData = commandData;
            this.channel = channel;
        }
        public SPCCommand Copy()
        {
            return new SPCCommand(Bits.Copy(commandData), this.spc, this.channel);
        }
        public override string ToString()
        {
            return Interpreter.Instance.InterpretSPCCommand(this);
        }
    }
}
