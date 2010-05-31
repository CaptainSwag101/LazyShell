using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace LAZYSHELL.ScriptsEditor.Commands
{
    [Serializable()]
    public class ActionQueueCommand : EventActionCommand
    {

        private byte[] queueData; public byte[] QueueData { get { return this.queueData; } set { this.queueData = value; } }

        public int QueueLength { get { return this.queueData.Length; } }
        private bool isEmbedded = false; public bool IsEmbedded { get { return this.isEmbedded; } set { this.isEmbedded = value; } }
        private bool set; public bool Set { get { return this.set; } set { this.set = value; } }

        protected override byte GetOpcode()
        {
            if (this.queueData.Length > 0) return this.queueData[0]; else return 0; 
        }
        protected override void SetOpcode(byte opcode)
        {
            this.queueData[0] = opcode;
        }
        protected override byte GetOption()
        {
            if (this.queueData.Length > 1) return this.queueData[1]; else return 0; 
        }
        protected override void SetOption(byte option)
        {
            this.queueData[1] = option; 
        } 

        public ActionQueueCommand(byte[] queueData, int offset)
        {
            this.queueData = queueData;
            this.offset = offset;
            this.originalOffset = offset;
            this.internalOffset = offset;
        }
        public void ModifyByte(int byteToSet, byte value)
        {
            queueData[byteToSet] = value;
        }
        public void ModifyBit(int byteToSet, int bitToSet, bool bit)
        {
            BitManager.SetBit(queueData, byteToSet, bitToSet, bit);
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

            if (queueData[0] == 0xE9)
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
            if (queueData[0] != 0xE9)
                throw new Exception("Not Command 0xE9");

            if (index == 0)
                BitManager.SetShort(queueData, 1, write);
            else if (index == 1)
                BitManager.SetShort(queueData, 3, write);
        }
        public override ushort ReadPointerSpecial(int index)
        {
            if (queueData[0] != 0xE9)
                throw new Exception("Not Command 0xE9");
            if (index == 0)
                return BitManager.GetShort(queueData, 1);
            else if (index == 1)
                return BitManager.GetShort(queueData, 3);
            return 0;
        }
        public override ushort ReadPointer()
        {
            switch (queueData[0])
            {
                case 0x3A:
                case 0x3B:
                case 0xE4:
                case 0xE5:
                    return BitManager.GetShort(queueData, 4);
                case 0x3C:
                case 0x3E:
                case 0xE0:
                case 0xE1:
                case 0xE2:
                case 0xE3:
                case 0xE6:
                case 0xE7:
                case 0xF8:
                    return BitManager.GetShort(queueData, 3);
                case 0x3F:
                case 0xD8:
                case 0xD9:
                case 0xDA:
                case 0xDC:
                case 0xDD:
                case 0xDE:
                    return BitManager.GetShort(queueData, 2);
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
                    return BitManager.GetShort(queueData, 1);
                case 0xE9:
                    throw new Exception("E9"); 
                case 0xFD:
                    switch (queueData[1])
                    {
                        case 0x3D:
                        case 0x3F:
                            return BitManager.GetShort(queueData, 3);
                        case 0x3E:
                            return BitManager.GetShort(queueData, 5);
                        default:
                            return 0;
                    }
                default: 
                    return 0;
            }
        }
        public override void WritePointer(ushort pointer)
        {
            switch (queueData[0])
            {
                case 0x3A:
                case 0x3B:
                case 0xE4:
                case 0xE5: 
                    BitManager.SetShort(queueData, 4, pointer); break;
                case 0x3C:
                case 0x3E:
                case 0xE0:
                case 0xE1:
                case 0xE2:
                case 0xE3:
                case 0xE6:
                case 0xE7:
                case 0xF8: 
                    BitManager.SetShort(queueData, 3, pointer); break;
                case 0x3F:
                case 0xD8:
                case 0xD9:
                case 0xDA:
                case 0xDC:
                case 0xDD:
                case 0xDE: 
                    BitManager.SetShort(queueData, 2, pointer); break;
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
                    BitManager.SetShort(queueData, 1, pointer); break;
                case 0xE9:
                    throw new Exception("E9");
                case 0xFD:
                    switch (queueData[1])
                    {
                        case 0x3D:
                        case 0x3F: 
                            BitManager.SetShort(queueData, 3, pointer); break;
                        case 0x3E: 
                            BitManager.SetShort(queueData, 5, pointer); break;
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
    }
}
