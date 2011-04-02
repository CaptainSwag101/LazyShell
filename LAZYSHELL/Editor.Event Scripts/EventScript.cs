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
        private int index;
        private byte[] script; public byte[] Script { get { return script; } set { script = value; } }
        private int baseOffset; public int BaseOffset { get { return this.baseOffset; } set { this.baseOffset = value; } }
        public int ScriptLength
        {
            get
            {
                return this.script.Length;
            }
        }

        private ArrayList commands; public ArrayList Commands { get { if (this.commands == null) this.commands = new ArrayList(); return this.commands; } set { this.commands = value; } }
        [NonSerialized()]
        private byte[] data;
        public override byte[] Data { get { return this.data; } set { this.data = value; } }
        public override int Index { get { return index;} set { index = value;} }

        public EventScript(byte[] data, int index)
        {
            this.data = data;
            this.index = index;

            InitializeEventScript(index);
        }
        public EventScript(byte[] data, byte[] eventData, int index)
        {
            this.data = data;
            this.index = index;
            this.script = eventData;
            ParseEventScript(script);

        }
        private void InitializeEventScript(int index)
        {
            //1e0000 - 1e0bff *1536 Events 0 - 1535
            //1f0000 - 1f0bff *1536 Events 1536 - 3071
            //200000 - 2007ff *1024 Events 3072 - 4095

            int bank, length, offset;
            int eventNumTemp = 0;

            if (index >= 0 && index <= 1535)
            {
                bank = 0x1E0000;
                eventNumTemp = index;
            }
            else if (index >= 1536 && index <= 3071)
            {
                bank = 0x1F0000;
                eventNumTemp = index - 1536;
            }
            else if (index >= 3072 && index <= 4095)
            {
                bank = 0x200000;
                eventNumTemp = index - 3072;
            }
            else
                throw new Exception("Invalid EventNum");

            length = GetEventLength(bank, eventNumTemp);

            offset = Bits.GetShort(data, bank + eventNumTemp * 2);

            this.baseOffset = bank + offset;

            script = Bits.GetByteArray(data, bank + offset, length);

            //if (eventNum == 0xD01 || eventNum == 0xE91)
            //    return;

            //try
            //{
            ParseEventScript(script);
            //}
            //catch (Exception e)
            //{
            //    MessageBox.Show("There was a problem parsing event script # " + eventNum + ".\n\n" + e.Message, "LAZY SHELL");
            //    throw new Exception();
            //}
        }
        private int GetEventLength(int bank, int eventNumTemp) // eventNum is relative to bank
        {
            int offset = Bits.GetShort(data, bank + eventNumTemp * 2);
            int length;

            if (index == 1535 || index == 3071)
                length = GetLastLength(bank + 0xFFFF, 0x10000 - offset);
            else if (index == 4095)
                length = GetLastLength(bank + 0xDFFF, 0xe000 - offset);
            else
                length = Bits.GetShort(data, bank + ((eventNumTemp + 1) * 2)) - offset;

            return length;
        }
        private int GetLastLength(int offset, int length)
        {
            while (data[offset] == 0xFF)
            {
                length--;
                offset--;
            }

            return length;
        }
        public void ParseEventScript(byte[] es)
        {
            int offset = 0, len = 0;
            EventScriptCommand temp;

            if (es.Length > 0 && this.commands == null)
                this.commands = new ArrayList();

            while (offset < es.Length)
            {
                switch (index)
                {
                    case 0x1D6: if (offset != 0xA1) goto default; len = 0x6B; goto case 0xE91;
                    case 0x72D: if (offset != 0x22) goto default; len = 0x3B; goto case 0xE91;
                    case 0x72F: if (offset != 0x22) goto default; len = 0x3C; goto case 0xE91;
                    case 0xD01: if (offset != 0x34) goto default; len = 0x87; goto case 0xE91;
                    case 0xE91: if (index == 0xE91) { if (offset != 0x3C4) goto default; len = 0x51; }
                        temp = new EventScriptCommand(Bits.GetByteArray(es, offset, len), this.baseOffset + offset);
                        temp.EmbeddedActionQueue = new ActionQueue(Bits.GetByteArray(temp.EventData, 0, temp.EventData.Length), -1, temp.Offset);
                        temp.IsDummy = true;
                        commands.Add(temp);
                        break;
                    default:
                        len = GetEventOpcodeLength(es, offset);
                        temp = new EventScriptCommand(Bits.GetByteArray(es, offset, len), this.baseOffset + offset);
                        commands.Add(temp);
                        break;
                }

                offset += len;
            }
        }
        public int GetEventOpcodeLength(byte[] es, int offset)
        {
            byte opcode, option, aq_opcode, aq_option;
            int i = 0, len;

            opcode = es[offset];
            if (es.Length - offset > 1)
                option = es[offset + 1];
            else
                option = 0;

            len = ScriptEnums.GetEventOpcodeLength(opcode, option);
            // Handles special case
            if (opcode <= 0x2F && (option == 0xF0 || option == 0xF1) && len == 3)
            {
                if (Bits.GetBit(es[offset + 2], 7))
                    len += es[offset + 2] & 0x3F; // Max value of 63 0x3F
                else
                    len += es[offset + 2] & 0x7F; // Max value of 127 0x7F
            }
            else if (opcode <= 0x2F && option < 0xF0)
            {
                for (i = 0; i < len - 2; )
                {
                    aq_opcode = es[offset + 2 + i];

                    if (es.Length - (offset + i + 2) > 1)
                        aq_option = es[offset + 2 + 1 + i];
                    else
                        aq_option = 0;

                    i += ScriptEnums.GetActionQueueOpcodeLength(aq_opcode, aq_option);
                }
            }
            return len;
        }
        private int StrChr(int offset, byte chr, int maxLen, byte[] data)
        {
            int i = 0;

            while (data[offset + i] != chr && i < maxLen)
                i++;

            return i;
        }
        private int StrShrt(int offset, ushort chr, int maxLen, byte[] data)
        {
            int i = 0;

            while (Bits.GetShort(data, offset + i) != chr && i < maxLen)
                i++;

            return i;
        }
        #region Management Methods
        public void Add(EventScriptCommand esc)
        {
            commands.Add(esc);
        }
        public void Add(int parentIndex, ActionQueueCommand aqc)
        {
            EventScriptCommand esc = (EventScriptCommand)commands[parentIndex];
            if (esc.IsActionQueueTrigger)
            {
                esc.EmbeddedActionQueue.Add(aqc);
            }
        }
        public void Insert(int index, EventScriptCommand esc)
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
        public void Insert(int parentIndex, int childIndex, ActionQueueCommand aqc)
        {
            try
            {
                EventScriptCommand esc = (EventScriptCommand)commands[parentIndex];
                if (esc.IsActionQueueTrigger)
                {
                    esc.EmbeddedActionQueue.Insert(childIndex, aqc);
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
                EventScriptCommand esc = (EventScriptCommand)commands[index];
                int len = esc.EventLength;
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
                EventScriptCommand esc = (EventScriptCommand)commands[parentIndex];
                ActionQueueCommand aqc;
                int len = 0;

                if (esc.IsActionQueueTrigger)
                {
                    aqc = (ActionQueueCommand)esc.EmbeddedActionQueue.Commands[childIndex];
                    len = aqc.QueueLength;
                    esc.EmbeddedActionQueue.RemoveAt(childIndex);

                }
                return len;
            }
            catch
            {
                throw new Exception("Event Script insert index invalid");
            }
        }
        public void Swap(int index1, int index2)
        {
            EventScriptCommand esc = (EventScriptCommand)commands[index1];
            commands[index1] = commands[index2];
            commands[index2] = esc;
        }
        public override void Clear()
        {
            if (commands != null)
                commands.Clear();
            Assemble();
        }
        public void Assemble()
        {
            int offset = 0;

            if (commands == null) { script = new byte[offset]; return; }

            foreach (EventScriptCommand esc in commands)
            {
                esc.Assemble();
                offset += esc.EventLength;
            }
            script = new byte[offset];

            offset = 0;
            foreach (EventScriptCommand esc in commands)
            {
                esc.EventData.CopyTo(script, offset);
                offset += esc.EventLength;
            }
        }
        public void UpdateAllOffsets(int delta, int conditionOffset)
        {
            if (this.baseOffset >= conditionOffset || conditionOffset == 0x7fffffff)
                this.baseOffset += delta;

            if (commands == null)
                return;

            foreach (EventScriptCommand esc in commands)
                esc.ModifyOffset(delta, conditionOffset);
        }
        #endregion
    }
}
