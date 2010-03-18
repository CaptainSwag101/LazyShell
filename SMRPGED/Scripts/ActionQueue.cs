using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using SMRPGED.ScriptsEditor.Commands;
using SMRPGED.ScriptsEditor;

namespace SMRPGED.ScriptsEditor
{
    [Serializable()]
    public class ActionQueue
    {
        private int actionQueueNum; public int ActionQueueNum { get { return this.actionQueueNum; } set { this.actionQueueNum = value; } }
        private ArrayList actionQueueCommands; public ArrayList ActionQueueCommands { get { return this.actionQueueCommands; } }
        private byte[] actionQueueData; public byte[] ActionQueueData { get { return actionQueueData; } set { actionQueueData = value; } }
        private byte[] data = null; public byte[] Data { get { return data; } set { data = value; } }

        public int ActionQueueLength
        {
            get
            {
                return actionQueueData.Length;
            }
        }
        private int offset; public int Offset { get { return this.offset; } set { this.offset = value; } }
        private bool isEmbedded = false; public bool IsEmbedded { get { return this.isEmbedded; } set { this.isEmbedded = value; } }

        public ActionQueue(byte[] data, int actionQueueNum)
        {
            this.data = data;
            this.actionQueueNum = actionQueueNum;
            this.isEmbedded = false;

            InitializeActionQueue(actionQueueNum);
        }
        public ActionQueue(byte[] actionQueueData, int actionQueueNum, int offset)
        {
            this.actionQueueData = actionQueueData;
            this.actionQueueNum = actionQueueNum;
            this.offset = offset;

            this.isEmbedded = true;

            InitializeActionQueue(actionQueueNum);
        }
        private void InitializeActionQueue(int actionQueueNum)
        {
            int length, offset = 0x210000;

            if (data != null)
            {
                length = GetActionQueueLength(actionQueueNum);

                offset = BitManager.GetShort(data, 0x210000 + (actionQueueNum * 2));

                this.offset = 0x210000 + offset;

                this.actionQueueData = BitManager.GetByteArray(data, 0x210000 + offset, length);
            }

            this.actionQueueCommands = new ArrayList();

            ParseActionQueue(actionQueueData);
        }
        private void ParseActionQueue(byte[] aq)
        {
            int offset = 0, len;

            while (offset < aq.Length)
            {
                len = GetActionQueueOpcodeLength(aq, offset);

                actionQueueCommands.Add(new ActionQueueCommand(BitManager.GetByteArray(aq, offset, len), this.offset + offset));
                offset += len;
            }
        }
        private int GetActionQueueLength(int num)
        {
            int offset = BitManager.GetShort(data, 0x210000 + num * 2);
            int length;
            int start;

            if (num == 1023)
            {
                length = 0xC000 - offset;
                start = 0x21BFFF;
                while (BitManager.GetByte(data, start) == 0xFF)
                {
                    length--;
                    start--;
                }
                return length;
            }
            else
                return BitManager.GetShort(data, 0x210000 + (num + 1) * 2) - offset;


        }
        private int GetActionQueueOpcodeLength(byte[] aq, int offset)
        {
            byte opcode, option;

            opcode = aq[offset];
            if (aq.Length - offset > 1)
                option = aq[offset + 1];
            else
                option = 0;

            return ScriptEnums.GetActionQueueOpcodeLength(opcode, option);
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

            while (BitManager.GetShort(data, offset + i) != chr && i < maxLen)
                i++;

            return i;
        }
        public ActionQueueCommand GetActionQueueCommandFromOffset(int offset)
        {
            /*
            foreach (ActionQueueCommand aqc in actionQueueCommands)
            {
                if (aqc.Offset == offset)
                    return aqc;
            }
             */
            return null;
        }
        #region Management Methods
        public void Add(ActionQueueCommand aqc)
        {
            actionQueueCommands.Add(aqc);
        }
        public void Insert(int index, ActionQueueCommand aqc)
        {
            try
            {
                actionQueueCommands.Insert(index, aqc);
            }
            catch
            {
                throw new Exception("Action Queue insert index invalid");
            }
        }
        public int RemoveAt(int index)
        {
            try
            {
                ActionQueueCommand aqc = (ActionQueueCommand)actionQueueCommands[index];
                int len = aqc.QueueLength;
                actionQueueCommands.RemoveAt(index);
                return len;
            }
            catch
            {
                throw new Exception("Action Script remove index invalid");
            }
        }
        public void Swap(int index1, int index2)
        {
            ActionQueueCommand aqc = (ActionQueueCommand)actionQueueCommands[index1];
            actionQueueCommands[index1] = actionQueueCommands[index2];
            actionQueueCommands[index2] = aqc;
        }
        public void ClearAll()
        {
            if (actionQueueCommands != null)
                actionQueueCommands.Clear();
            Assemble();
        }
        public void Assemble()
        {
            int offset = 0;

            if (actionQueueCommands == null) { actionQueueData = new byte[offset]; return; }

            foreach (ActionQueueCommand aqc in actionQueueCommands)
            {
                aqc.Assemble();
                offset += aqc.QueueLength;
            }
            actionQueueData = new byte[offset];

            offset = 0;
            foreach (ActionQueueCommand aqc in actionQueueCommands)
            {
                aqc.QueueData.CopyTo(actionQueueData, offset);
                offset += aqc.QueueLength;
            }
        }
        public void UpdateAllOffsets(int delta, int conditionOffset)
        {
            if (this.offset >= conditionOffset || conditionOffset == 0x7FFFFFFF)
                this.offset += delta;

            if (actionQueueCommands == null)
                return;

            foreach (ActionQueueCommand aqc in actionQueueCommands)
                aqc.ModifyOffset(delta, conditionOffset);
        }

        #endregion
    }
}
