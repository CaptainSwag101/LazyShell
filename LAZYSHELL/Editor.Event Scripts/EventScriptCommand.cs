using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace LAZYSHELL.ScriptsEditor.Commands
{
    [Serializable()]
    public class EventScriptCommand : EventActionCommand
    {
        private byte[] eventData; public byte[] EventData { get { return this.eventData; } set { this.eventData = value; } }
        private ActionQueue embeddedActionQueue; public ActionQueue EmbeddedActionQueue { get { return this.embeddedActionQueue; } set { this.embeddedActionQueue = value; } }
        private bool set; public bool Set { get { return this.set; } set { this.set = value; } }
        public int EventLength
        {
            get
            {
                return this.eventData.Length;
            }
        }
        protected override byte GetOpcode()
        {
            if (this.eventData.Length > 0)
                return this.eventData[0];
            else
                return 0;
        }
        protected override void SetOpcode(byte opcode)
        {
            this.eventData[0] = opcode;
        }
        protected override byte GetOption()
        {
            if (this.eventData.Length > 1)
                return this.eventData[1];
            else
                return 0;
        }
        protected override void SetOption(byte option)
        {
            this.eventData[1] = option;
        }

        public bool IsActionQueueTrigger { get { return (eventData[0] >= 0 && eventData[0] <= 0x2F && eventData[1] <= 0xF1); } }

        // this is only used for the two instances in 0xd01 and 0xe91
        private bool isDummy; public bool IsDummy { get { return isDummy; } set { isDummy = value; } }

        public EventScriptCommand(byte[] eventData, int offset)
        {
            this.eventData = eventData;
            this.offset = offset;
            this.originalOffset = offset;
            this.internalOffset = offset;

            if (eventData.Length >= 2)
            {
                if (eventData[0] >= 0 && eventData[0] <= 0x2F && eventData[1] <= 0xF1)
                {
                    if (eventData[1] == 0xF0 || eventData[1] == 0xF1)
                        embeddedActionQueue = new ActionQueue(Bits.GetByteArray(eventData, 3, eventData.Length - 3), -1, offset + 3);
                    else
                        embeddedActionQueue = new ActionQueue(Bits.GetByteArray(eventData, 2, eventData.Length - 2), -1, offset + 2);
                }
            }
        }
        public void ModifyByte(int byteToSet, byte value)
        {
            eventData[byteToSet] = value;
        }
        public void ModifyBit(int byteToSet, int bitToSet, bool bit)
        {
            Bits.SetBit(eventData, byteToSet, bitToSet, bit);
        }
        public void Assemble()
        {
            // Assembles this command back to binary data
            // Stores it in byte[]eventData
            int start;

            if (IsDummy)   // for events 0xD01 and 0xE91 only
            {
                start = 0;
                foreach (ActionQueueCommand aqc in embeddedActionQueue.Commands)
                {
                    aqc.EventData.CopyTo(eventData, start);
                    start += aqc.QueueLength;
                }
            }
            else if (IsActionQueueTrigger && embeddedActionQueue != null)
            {
                int offset = start = Option < 0xF0 ? 2 : 3;
                byte a = 0, b = 0, c = 0;
                a = eventData[0];
                b = eventData[1];
                if (Option >= 0xF0)
                    c = eventData[2];

                foreach (ActionQueueCommand aqc in embeddedActionQueue.Commands)
                {
                    aqc.Assemble();
                    offset += aqc.QueueLength;
                }

                eventData = new byte[offset];
                eventData[0] = a;
                eventData[1] = b;
                if (Option >= 0xF0)
                    eventData[2] = c;

                foreach (ActionQueueCommand aqc in embeddedActionQueue.Commands)
                {
                    aqc.EventData.CopyTo(eventData, start);
                    start += aqc.QueueLength;
                }
            }
        }
        public void RefreshOffsets(int offset)
        {
            this.offset = offset;

            Assemble(); // added 2008-12-20

            if (IsDummy)
            {
                foreach (ActionQueueCommand aqc in embeddedActionQueue.Commands)
                {
                    aqc.Offset = offset;
                    offset += aqc.QueueLength;
                }
            }
            if (IsActionQueueTrigger && embeddedActionQueue != null)
            {
                offset += eventData[1] == 0xF0 || eventData[1] == 0xF1 ? 3 : 2;
                foreach (ActionQueueCommand aqc in embeddedActionQueue.Commands)
                {
                    aqc.Offset = offset;
                    offset += aqc.QueueLength;
                }
            }
        }
        public void ModifyOffset(int delta, int conditionOffset)
        {
            ushort pointer;

            if (this.offset >= conditionOffset || conditionOffset == 0x7FFFFFFF)
            {
                this.offset += delta;
                this.internalOffset += delta;   // 2009-01-07
            }

            if ((this.IsDummy || this.IsActionQueueTrigger) && this.embeddedActionQueue != null)
                embeddedActionQueue.UpdateAllOffsets(delta, conditionOffset);

            conditionOffset &= 0xFFFF; // convert to pointer

            if (eventData[0] == 0xE9 || eventData[0] == 0x42 || eventData[0] == 0x67)
            {
                pointer = ReadPointerSpecial(0);
                if (pointer >= conditionOffset)
                    WritePointerSpecial(0, (ushort)(pointer + delta));
                pointer = ReadPointerSpecial(1);
                if (pointer >= conditionOffset)
                    WritePointerSpecial(1, (ushort)(pointer + delta));
            }
            else
            {
                pointer = ReadPointer();
                if (pointer >= conditionOffset)
                    WritePointer((ushort)(pointer + delta));
            }
        }
        public override void WritePointerSpecial(int index, ushort write)
        {
            if (eventData[0] != 0xE9 && eventData[0] != 0x42 && eventData[0] != 0x67)
                throw new Exception("Not Command 0xE9, 0x42 or 0x67");

            if (index == 0)
                Bits.SetShort(eventData, 1, write);
            else if (index == 1)
                Bits.SetShort(eventData, 3, write);
        }
        public override ushort ReadPointerSpecial(int index)
        {
            if (eventData[0] != 0xE9 && eventData[0] != 0x42 && eventData[0] != 0x67)
                throw new Exception("Not Command 0xE9, 0x42 or 0x67");
            if (index == 0)
                return Bits.GetShort(eventData, 1);
            else if (index == 1)
                return Bits.GetShort(eventData, 3);
            return 0;
        }
        public override ushort ReadPointer()
        {
            switch (eventData[0])
            {
                case 0x3D:  // 1
                case 0x41:
                case 0x5C:
                case 0x66:
                case 0xD2:
                case 0xD3:
                case 0xDB:
                case 0xDF:
                case 0xE8:
                case 0xEA:
                case 0xEB:
                case 0xEC:
                case 0xED:
                case 0xEE:
                case 0xEF:
                    return Bits.GetShort(eventData, 1);
                case 0x32:  // 2
                case 0x39:
                case 0x3F:
                case 0xD8:
                case 0xD9:
                case 0xDA:
                case 0xDC:
                case 0xDD:
                case 0xDE:
                    return Bits.GetShort(eventData, 2);
                case 0x3E:  // 3
                case 0xE0:
                case 0xE1:
                case 0xE2:
                case 0xE3:
                case 0xE6:
                case 0xE7:
                case 0xF8:
                    return Bits.GetShort(eventData, 3);
                case 0x3C:  // 4
                case 0xE4:
                case 0xE5:
                    return Bits.GetShort(eventData, 4);
                case 0x3A:  // 5
                case 0x3B:
                    return Bits.GetShort(eventData, 5);
                case 0x42:  // 1,3
                case 0x67:
                case 0xE9:
                    throw new Exception("E9");
                case 0xFD:
                    switch (eventData[1])
                    {
                        case 0x3F:  // 2
                        case 0x62:
                            return Bits.GetShort(eventData, 2);
                        case 0x33:  // 3
                        case 0x34:
                        case 0x3D:
                        case 0x96:
                        case 0x97:
                            return Bits.GetShort(eventData, 3);
                        case 0xF0:  // 4
                            return Bits.GetShort(eventData, 4);
                        case 0x3E:  // 5
                            return Bits.GetShort(eventData, 5);
                        default:
                            return 0;

                    }
                default:
                    return 0;
            }
        }
        public override void WritePointer(ushort pointer)
        {
            switch (eventData[0])
            {
                case 0x3D:  // 1
                case 0x41:
                case 0x5C:
                case 0x66:
                case 0xD2:
                case 0xD3:
                case 0xDB:
                case 0xDF:
                case 0xE8:
                case 0xEA:
                case 0xEB:
                case 0xEC:
                case 0xED:
                case 0xEE:
                case 0xEF:
                    Bits.SetShort(eventData, 1, pointer); break;
                case 0x32:  // 2
                case 0x39:
                case 0x3F:
                case 0xD8:
                case 0xD9:
                case 0xDA:
                case 0xDC:
                case 0xDD:
                case 0xDE:
                    Bits.SetShort(eventData, 2, pointer); break;
                case 0x3E:  // 3
                case 0xE0:
                case 0xE1:
                case 0xE2:
                case 0xE3:
                case 0xE6:
                case 0xE7:
                case 0xF8:
                    Bits.SetShort(eventData, 3, pointer); break;
                case 0x3C:  // 4
                case 0xE4:
                case 0xE5:
                    Bits.SetShort(eventData, 4, pointer); break;
                case 0x3A:  // 5
                case 0x3B:
                    Bits.SetShort(eventData, 5, pointer); break;
                case 0x42:  // 1,3
                case 0x67:
                case 0xE9:
                    throw new Exception("E9");
                case 0xFD:
                    switch (eventData[1])
                    {
                        case 0x3F:  // 2
                        case 0x62:
                            Bits.SetShort(eventData, 2, pointer); break;
                        case 0x33:  // 3
                        case 0x34:
                        case 0x3D:
                        case 0x96:
                        case 0x97:
                            Bits.SetShort(eventData, 3, pointer); break;
                        case 0xF0:  // 4
                            Bits.SetShort(eventData, 4, pointer); break;
                        case 0x3E:  // 5
                            Bits.SetShort(eventData, 5, pointer); break;
                        default: break;
                    }
                    break;
                default:
                    break;
            }

        }
        public override string ToString()
        {
            return Interpreter.Instance.InterpretEventCommand(this);
        }
        public void ResetOriginalOffset()
        {
            this.originalOffset = this.offset;

            if (this.IsActionQueueTrigger && this.embeddedActionQueue != null && this.embeddedActionQueue.Commands != null)
            {
                foreach (ActionQueueCommand aqc in embeddedActionQueue.Commands)
                    aqc.ResetOriginalOffset();
            }
        }
    }
}
