using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using LAZYSHELL.ScriptsEditor.Commands;

namespace LAZYSHELL.ScriptsEditor
{
    [Serializable()]
    public class EventScript : Element
    {
        // universal variables
        private int index; public override int Index { get { return index; } set { index = value; } }
        private byte[] rom { get { return Model.ROM; } set { Model.ROM = value; } }
        // class variables, accessors
        private byte[] script; public byte[] Script { get { return script; } set { script = value; } }
        private List<EventCommand> commands;
        public List<EventCommand> Commands
        {
            get
            {
                if (this.commands == null)
                    this.commands = new List<EventCommand>();
                return this.commands;
            }
            set { this.commands = value; }
        }
        private int baseOffset; public int BaseOffset { get { return this.baseOffset; } set { this.baseOffset = value; } }
        public int Length
        {
            get
            {
                return this.script.Length;
            }
        }
        // constructors
        public EventScript(int index)
        {
            this.index = index;
            Disassemble();
        }
        // assemblers
        private void Disassemble()
        {
            int bank;
            int indexinbank = 0;
            if (index >= 0 && index <= 1535)
            {
                bank = 0x1E0000;
                indexinbank = index;
            }
            else if (index >= 1536 && index <= 3071)
            {
                bank = 0x1F0000;
                indexinbank = index - 1536;
            }
            else if (index >= 3072 && index <= 4095)
            {
                bank = 0x200000;
                indexinbank = index - 3072;
            }
            else
                throw new Exception("Invalid index.");
            //
            int length = GetLength(bank, indexinbank);
            int offset = Bits.GetShort(rom, bank + indexinbank * 2);
            this.baseOffset = bank + offset;
            this.script = Bits.GetByteArray(rom, bank + offset, length);
            //
            ParseScript();
        }
        public void Assemble()
        {
            int offset = 0;
            if (commands == null)
            {
                script = new byte[offset];
                return;
            }
            foreach (EventCommand esc in commands)
            {
                esc.Assemble();
                offset += esc.Length;
            }
            script = new byte[offset];
            offset = 0;
            foreach (EventCommand esc in commands)
            {
                esc.CommandData.CopyTo(script, offset);
                offset += esc.Length;
            }
        }
        // class functions
        private void ParseScript()
        {
            int offset = 0, length = 0;
            if (script.Length > 0 && this.commands == null)
                this.commands = new List<EventCommand>();
            //
            EventCommand esc;
            while (offset < script.Length)
            {
                switch (index)
                {
                    case 0x1D6: if (offset != 0xA1) goto default; length = 0x6B; goto case 0xE91;
                    case 0x72D: if (offset != 0x22) goto default; length = 0x3B; goto case 0xE91;
                    case 0x72F: if (offset != 0x22) goto default; length = 0x3C; goto case 0xE91;
                    case 0xD01: if (offset != 0x34) goto default; length = 0x87; goto case 0xE91;
                    case 0xE91: if (index == 0xE91) { if (offset != 0x3C4) goto default; length = 0x51; }
                        esc = new EventCommand(Bits.GetByteArray(script, offset, length), this.baseOffset + offset);
                        esc.Queue = new ActionScript(Bits.GetByteArray(esc.CommandData, 0, esc.Length), -1, esc.Offset);
                        esc.Locked = true;
                        commands.Add(esc);
                        break;
                    default:
                        length = GetCommandLength(script, offset);
                        esc = new EventCommand(Bits.GetByteArray(script, offset, length), this.baseOffset + offset);
                        commands.Add(esc);
                        break;
                }
                offset += length;
            }
        }
        private int GetCommandLength(byte[] script, int offset)
        {
            byte opcode = script[offset];
            byte param1;
            if (script.Length - offset > 1)
                param1 = script[offset + 1];
            else
                param1 = 0;
            int length = ScriptEnums.GetEventCommandLength(opcode, param1);
            // Handles special case
            if (opcode <= 0x2F && (param1 == 0xF0 || param1 == 0xF1) && length == 3)
            {
                if (Bits.GetBit(script[offset + 2], 7))
                    length += script[offset + 2] & 0x3F; // Max value of 63 0x3F
                else
                    length += script[offset + 2] & 0x7F; // Max value of 127 0x7F
            }
            else if (opcode <= 0x2F && param1 < 0xF0)
            {
                for (int i = 0; i < length - 2; )
                {
                    opcode = script[offset + 2 + i];
                    if (script.Length - (offset + i + 2) > 1)
                        param1 = script[offset + 2 + 1 + i];
                    else
                        param1 = 0;
                    i += ScriptEnums.GetActionCommandLength(opcode, param1);
                }
            }
            return length;
        }
        private int GetLength(int bank, int indexinbank)
        {
            int offset = Bits.GetShort(rom, bank + indexinbank * 2);
            int length;
            if (this.index == 1535 || this.index == 3071)
                length = GetPrevLength(bank + 0xFFFF, 0x10000 - offset);
            else if (this.index == 4095)
                length = GetPrevLength(bank + 0xDFFF, 0xe000 - offset);
            else
                length = Bits.GetShort(rom, bank + ((indexinbank + 1) * 2)) - offset;
            return length;
        }
        private int GetPrevLength(int offset, int length)
        {
            while (rom[offset] == 0xFF)
            {
                length--;
                offset--;
            }
            return length;
        }
        // list managers
        public void Add(EventCommand esc)
        {
            commands.Add(esc);
        }
        public void Add(int parentIndex, ActionCommand asc)
        {
            EventCommand esc = commands[parentIndex];
            if (esc.QueueTrigger)
                esc.Queue.Add(asc);
        }
        public void Insert(int index, EventCommand esc)
        {
            try
            {
                commands.Insert(index, esc);
            }
            catch
            {
                throw new Exception("Event Script insert index invalid");
            }
        }
        public void Insert(int parentIndex, int childIndex, ActionCommand asc)
        {
            try
            {
                EventCommand esc = commands[parentIndex];
                if (esc.QueueTrigger)
                {
                    esc.Queue.Insert(childIndex, asc);
                }
            }
            catch
            {
                throw new Exception("Event Script insert index invalid");
            }
        }
        public int RemoveAt(int index)
        {
            try
            {
                EventCommand esc = commands[index];
                int len = esc.Length;
                commands.RemoveAt(index);
                return len;
            }
            catch
            {
                throw new Exception("Event Script remove index invalid");
            }
        }
        public int RemoveAt(int parentIndex, int childIndex)
        {
            try
            {
                EventCommand esc = commands[parentIndex];
                int length = 0;
                if (esc.QueueTrigger)
                {
                    ActionCommand aqc = esc.Queue.Commands[childIndex];
                    length = aqc.Length;
                    esc.Queue.RemoveAt(childIndex);

                }
                return length;
            }
            catch
            {
                throw new Exception("Event Script insert index invalid.");
            }
        }
        public void Reverse(int index1, int index2)
        {
            EventCommand esc = (EventCommand)commands[index1];
            commands[index1] = commands[index2];
            commands[index2] = esc;
        }
        public override void Clear()
        {
            if (commands != null)
                commands.Clear();
            Assemble();
        }
        // public functions
        public void UpdateAllOffsets(int delta, int conditionOffset)
        {
            if (this.baseOffset >= conditionOffset || conditionOffset == 0x7fffffff)
                this.baseOffset += delta;

            if (commands == null)
                return;

            foreach (EventCommand esc in commands)
                esc.ModifyOffset(delta, conditionOffset);
        }
    }
}
