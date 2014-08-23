using System;
using System.Collections.Generic;
using System.Collections;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LAZYSHELL.EventScripts
{
    [Serializable()]
    public class EventCommand : Command
    {
        #region Variables

        // Queue
        public ActionScript Queue { get; set; }
        public bool QueueTrigger
        {
            get
            {
                return (
                    Data[0] >= 0 &&
                    Data[0] <= 0x2F &&
                    Data[1] <= 0xF1);
            }
        }

        /// <summary>
        /// Indicates that the command is locked for editing.
        /// Only set in scripts 3329 and 3729 by default.
        /// </summary>
        public bool Locked { get; set; }

        #endregion

        // Constructor
        public EventCommand(byte[] data, int offset)
        {
            this.Data = data;
            this.Offset = offset;
            this.OriginalOffset = offset;
            this.InternalOffset = offset;
            if (data.Length >= 2)
            {
                if (data[0] >= 0 && data[0] <= 0x2F && data[1] <= 0xF1)
                {
                    if (data[1] == 0xF0 || data[1] == 0xF1)
                        Queue = new ActionScript(Bits.GetBytes(data, 3, data.Length - 3), -1, offset + 3);
                    else
                        Queue = new ActionScript(Bits.GetBytes(data, 2, data.Length - 2), -1, offset + 2);
                }
            }
            if (Opcode == 0xFD && Parser.EventCommandsFD[Param1] == "")
            {
                Model.MostCommonEventsFD[Param1].Opcode = Opcode;
                Model.MostCommonEventsFD[Param1].Param1 = Param1;
                Model.MostCommonEventsFD[Param1].Frequency++;
            }
            else if (Opcode != 0xFD && Parser.EventCommands[Opcode] == "")
            {
                Model.MostCommonEvents[Opcode].Opcode = Opcode;
                Model.MostCommonEvents[Opcode].Param1 = Param1;
                Model.MostCommonEvents[Opcode].Frequency++;
            }
        }

        #region Methods

        /// <summary>
        /// Writes the command data of any queue commands to this command's
        /// data buffer.
        /// </summary>
        public void WriteToBuffer()
        {
            int start;
            if (Locked)
            {
                start = 0;
                foreach (var command in Queue.Commands)
                {
                    command.Data.CopyTo(Data, start);
                    start += command.Length;
                }
            }
            else if (QueueTrigger && Queue != null)
            {
                int offset = start = Param1 < 0xF0 ? 2 : 3;
                byte opcode = 0;
                byte param1 = 0;
                byte param2 = 0;
                opcode = Data[0];
                param1 = Data[1];
                if (Param1 >= 0xF0)
                    param2 = Data[2];
                foreach (var command in Queue.Commands)
                {
                    command.WriteToBuffer();
                    offset += command.Length;
                }
                Data = new byte[offset];
                Data[0] = opcode;
                Data[1] = param1;
                if (Param1 >= 0xF0)
                    Data[2] = param2;
                foreach (var command in Queue.Commands)
                {
                    command.Data.CopyTo(Data, start);
                    start += command.Length;
                }
            }
        }

        #region Pointers

        /// <summary>
        /// Adds/subtracts a value from the command's offset and any pointers in the command that point to or after a given offset.
        /// </summary>
        /// <param name="delta">The value to add/subtract from any pointers.</param>
        /// <param name="conditionOffset">The offset to compare to.</param>
        public void UpdatePointer(int delta, int conditionOffset)
        {
            ushort pointer;
            if (this.Offset >= conditionOffset || conditionOffset == 0x7FFFFFFF)
            {
                this.Offset += delta;
                this.InternalOffset += delta;   // 2009-01-07
            }
            if ((this.Locked || this.QueueTrigger) && this.Queue != null)
                Queue.UpdateOffsets(delta, conditionOffset);
            conditionOffset &= 0xFFFF; // convert to pointer
            if (Data[0] == 0x42 || Data[0] == 0x67 || Data[0] == 0xE9)
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
        /// <summary>
        /// Returns this command's pointer, if it has one.
        /// </summary>
        /// <returns></returns>
        public override ushort ReadPointer()
        {
            switch (Data[0])
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
                    return Bits.GetShort(Data, 1);
                case 0x32:  // 2
                case 0x39:
                case 0x3F:
                case 0xD8:
                case 0xD9:
                case 0xDA:
                case 0xDC:
                case 0xDD:
                case 0xDE:
                    return Bits.GetShort(Data, 2);
                case 0x3E:  // 3
                case 0xE0:
                case 0xE1:
                case 0xE2:
                case 0xE3:
                case 0xE6:
                case 0xE7:
                case 0xF8:
                    return Bits.GetShort(Data, 3);
                case 0x3C:  // 4
                case 0xE4:
                case 0xE5:
                    return Bits.GetShort(Data, 4);
                case 0x3A:  // 5
                case 0x3B:
                    return Bits.GetShort(Data, 5);
                case 0x42:  // 1,3
                case 0x67:
                case 0xE9:
                    throw new Exception("E9");
                case 0xFD:
                    switch (Data[1])
                    {
                        case 0x3F:  // 2
                        case 0x62:
                            return Bits.GetShort(Data, 2);
                        case 0x33:  // 3
                        case 0x34:
                        case 0x3D:
                        case 0x96:
                        case 0x97:
                            return Bits.GetShort(Data, 3);
                        case 0xF0:  // 4
                            return Bits.GetShort(Data, 4);
                        case 0x3E:  // 5
                            return Bits.GetShort(Data, 5);
                        default:
                            return 0;
                    }
                default:
                    return 0;
            }
        }
        /// <summary>
        /// Returns one of the pointers in this command.
        /// </summary>
        /// <param name="index">The index of the pointer to read.</param>
        /// <returns></returns>
        public override ushort ReadPointerSpecial(int index)
        {
            if (Data[0] != 0xE9 && Data[0] != 0x42 && Data[0] != 0x67)
                throw new Exception("Not Command 0xE9, 0x42 or 0x67");
            return Bits.GetShort(Data, index * 2 + 1);
        }
        /// <summary>
        /// Writes a value to the command's pointer.
        /// </summary>
        /// <param name="value">The new pointer value.</param>
        public override void WritePointer(ushort pointer)
        {
            switch (Data[0])
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
                    Bits.SetShort(Data, 1, pointer); break;
                case 0x32:  // 2
                case 0x39:
                case 0x3F:
                case 0xD8:
                case 0xD9:
                case 0xDA:
                case 0xDC:
                case 0xDD:
                case 0xDE:
                    Bits.SetShort(Data, 2, pointer); break;
                case 0x3E:  // 3
                case 0xE0:
                case 0xE1:
                case 0xE2:
                case 0xE3:
                case 0xE6:
                case 0xE7:
                case 0xF8:
                    Bits.SetShort(Data, 3, pointer); break;
                case 0x3C:  // 4
                case 0xE4:
                case 0xE5:
                    Bits.SetShort(Data, 4, pointer); break;
                case 0x3A:  // 5
                case 0x3B:
                    Bits.SetShort(Data, 5, pointer); break;
                case 0x42:  // 1,3
                case 0x67:
                case 0xE9:
                    throw new Exception("E9");
                case 0xFD:
                    switch (Data[1])
                    {
                        case 0x3F:  // 2
                        case 0x62:
                            Bits.SetShort(Data, 2, pointer); break;
                        case 0x33:  // 3
                        case 0x34:
                        case 0x3D:
                        case 0x96:
                        case 0x97:
                            Bits.SetShort(Data, 3, pointer); break;
                        case 0xF0:  // 4
                            Bits.SetShort(Data, 4, pointer); break;
                        case 0x3E:  // 5
                            Bits.SetShort(Data, 5, pointer); break;
                        default: break;
                    }
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// Writes a value to one of the command's pointers.
        /// </summary>
        /// <param name="index">The pointer to write to.</param>
        /// <param name="value">The new pointer value.</param>
        public override void WritePointerSpecial(int index, ushort pointer)
        {
            if (Data[0] != 0xE9 && Data[0] != 0x42 && Data[0] != 0x67)
                throw new Exception("Not Command 0xE9, 0x42 or 0x67");
            Bits.SetShort(Data, index * 2 + 1, pointer);
        }

        #endregion

        /// <summary>
        /// Writes the command data of any queue commands to this command's
        /// data buffer and updates their offsets.
        /// </summary>
        public void RefreshOffsets(int offset)
        {
            this.Offset = offset;
            WriteToBuffer();
            if (Locked)
            {
                foreach (var command in Queue.Commands)
                {
                    command.Offset = offset;
                    offset += command.Length;
                }
            }
            if (QueueTrigger && Queue != null)
            {
                offset += Data[1] == 0xF0 || Data[1] == 0xF1 ? 3 : 2;
                foreach (var command in Queue.Commands)
                {
                    command.Offset = offset;
                    offset += command.Length;
                }
            }
        }
        /// <summary>
        /// Sets the original offset of this command and any
        /// queue commands to the current offset value.
        /// </summary>
        public void ResetOriginalOffset()
        {
            this.OriginalOffset = this.Offset;
            if (this.QueueTrigger && this.Queue != null && this.Queue.Commands != null)
            {
                foreach (var command in Queue.Commands)
                    command.ResetOriginalOffset();
            }
        }

        /// <summary>
        /// Creates a TreeNode based on this command's parsed descriptive text.
        /// </summary>
        public TreeNode Node
        {
            get
            {
                var node = new TreeNode("[" + Offset.ToString("X6") + "]   " + ToString());
                if (Locked)
                    node.Text = "NON-EMBEDDED ACTION QUEUE";
                if (QueueTrigger)
                    node.BackColor = Color.FromArgb(224, 232, 255);
                else if (Opcode >= 0xFE)
                    node.BackColor = Color.FromArgb(255, 255, 200);
                node.ForeColor = Modified ? Color.Red : SystemColors.ControlText;
                node.Checked = Modified;
                node.Tag = this;
                return node;
            }
        }
        /// <summary>
        /// Creates a deep copy of this instance.
        /// </summary>
        /// <returns></returns>
        public EventCommand Copy()
        {
            return new EventCommand(Bits.Copy(Data), this.Offset);
        }

        // Override
        public override string ToString()
        {
            return Parser.ParseCommand(this);
        }

        #endregion
    }
}
