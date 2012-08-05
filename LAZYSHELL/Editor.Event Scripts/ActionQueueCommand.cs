using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace LAZYSHELL.ScriptsEditor.Commands
{
    [Serializable()]
    public class ActionQueueCommand : EventActionCommand
    {

        private byte[] eventData; public byte[] EventData { get { return this.eventData; } set { this.eventData = value; } }

        public int CommandLength { get { return this.eventData.Length; } }
        private bool isEmbedded = false; public bool IsEmbedded { get { return this.isEmbedded; } set { this.isEmbedded = value; } }
        private bool set; public bool Set { get { return this.set; } set { this.set = value; } }

        protected override byte GetOpcode()
        {
            if (this.eventData.Length > 0) return this.eventData[0]; else return 0; 
        }
        protected override void SetOpcode(byte opcode)
        {
            this.eventData[0] = opcode;
        }
        protected override byte GetOption()
        {
            if (this.eventData.Length > 1) return this.eventData[1]; else return 0; 
        }
        protected override void SetOption(byte option)
        {
            this.eventData[1] = option; 
        } 

        public ActionQueueCommand(byte[] eventData, int offset)
        {
            this.eventData = eventData;
            this.offset = offset;
            this.originalOffset = offset;
            this.internalOffset = offset;
        }
        public void ModifyByte(int byteToSet, byte value)
        {
            eventData[byteToSet] = value;
        }
        public void ModifyBit(int byteToSet, int bitToSet, bool bit)
        {
            Bits.SetBit(eventData, byteToSet, bitToSet, bit);
        }
        public override string ToString()
        {
            return Interpreter.Instance.InterpretActionQueue(this);
        }
        public void Assemble()
        {
            // Assembles this Action Queue Command back into binary data
            // Stores it in byte[] queueData
        }
        public void ModifyOffset(int delta, int conditionOffset)
        {
            ushort pointer;

            if (this.offset >= conditionOffset || conditionOffset == 0x7FFFFFFF)
            {
                this.offset += delta;
                this.internalOffset += delta;   // 2009-01-07
            }

            conditionOffset &= 0xFFFF;

            if (eventData[0] == 0xE9)
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
            if (eventData[0] != 0xE9)
                throw new Exception("Not Command 0xE9");

            if (index == 0)
                Bits.SetShort(eventData, 1, write);
            else if (index == 1)
                Bits.SetShort(eventData, 3, write);
        }
        public override ushort ReadPointerSpecial(int index)
        {
            if (eventData[0] != 0xE9)
                throw new Exception("Not Command 0xE9");
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
                case 0x3A:
                case 0x3B:
                case 0xE4:
                case 0xE5:
                    return Bits.GetShort(eventData, 4);
                case 0x3C:
                case 0x3E:
                case 0xE0:
                case 0xE1:
                case 0xE2:
                case 0xE3:
                case 0xE6:
                case 0xE7:
                case 0xF8:
                    return Bits.GetShort(eventData, 3);
                case 0x3F:
                case 0xD8:
                case 0xD9:
                case 0xDA:
                case 0xDC:
                case 0xDD:
                case 0xDE:
                    return Bits.GetShort(eventData, 2);
                case 0x3D:
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
                case 0xE9:
                    throw new Exception("E9"); 
                case 0xFD:
                    switch (eventData[1])
                    {
                        case 0x3D:
                        case 0x3F:
                            return Bits.GetShort(eventData, 3);
                        case 0x3E:
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
                case 0x3A:
                case 0x3B:
                case 0xE4:
                case 0xE5: 
                    Bits.SetShort(eventData, 4, pointer); break;
                case 0x3C:
                case 0x3E:
                case 0xE0:
                case 0xE1:
                case 0xE2:
                case 0xE3:
                case 0xE6:
                case 0xE7:
                case 0xF8: 
                    Bits.SetShort(eventData, 3, pointer); break;
                case 0x3F:
                case 0xD8:
                case 0xD9:
                case 0xDA:
                case 0xDC:
                case 0xDD:
                case 0xDE: 
                    Bits.SetShort(eventData, 2, pointer); break;
                case 0x3D:
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
                case 0xE9:
                    throw new Exception("E9");
                case 0xFD:
                    switch (eventData[1])
                    {
                        case 0x3D:
                        case 0x3F: 
                            Bits.SetShort(eventData, 3, pointer); break;
                        case 0x3E: 
                            Bits.SetShort(eventData, 5, pointer); break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }
        }
        public void ResetOriginalOffset()
        {
            this.originalOffset = this.offset;
        }
        public ActionQueueCommand Copy()
        {
            return new ActionQueueCommand(Bits.Copy(eventData), this.offset);
        }
    }
}
