using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Collections;
using System.Windows.Forms;

namespace LAZYSHELL.EventScripts
{
    [Serializable()]
    public class ActionCommand : Command
    {
        #region Variables

        /// <summary>
        /// Indicates whether this command is embedded in an event script's action queue.
        /// </summary>
        public bool Embedded { get; set; }

        #endregion

        // Constructor
        public ActionCommand(byte[] commandData, int offset)
        {
            this.Data = commandData;
            this.Offset = offset;
            this.OriginalOffset = offset;
            this.InternalOffset = offset;
        }

        #region Methods

        // Read/writer buffer
        public void WriteToBuffer()
        {
        }

        /// <summary>
        /// Adds a delta value to the command's offset and any pointers 
        /// in the command that point to or after a specified offset.
        /// </summary>
        /// <param name="delta">The value to add to any pointers.</param>
        /// <param name="conditionOffset">The offset to compare to.</param>
        public void UpdatePointer(int delta, int conditionOffset)
        {
            ushort pointer;
            if (this.Offset >= conditionOffset || conditionOffset == 0x7FFFFFFF)
            {
                this.Offset += delta;
                this.InternalOffset += delta;   // 2009-01-07
            }
            conditionOffset &= 0xFFFF;
            if (Opcode == 0xE9)
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
            switch (Opcode)
            {
                case 0x3A:
                case 0x3B:
                case 0xE4:
                case 0xE5:
                    return Bits.GetShort(Data, 4);
                case 0x3C:
                case 0x3E:
                case 0xE0:
                case 0xE1:
                case 0xE2:
                case 0xE3:
                case 0xE6:
                case 0xE7:
                case 0xF8:
                    return Bits.GetShort(Data, 3);
                case 0x3F:
                case 0xD8:
                case 0xD9:
                case 0xDA:
                case 0xDC:
                case 0xDD:
                case 0xDE:
                    return Bits.GetShort(Data, 2);
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
                    return Bits.GetShort(Data, 1);
                case 0xE9:
                    throw new Exception("E9");
                case 0xFD:
                    switch (Data[1])
                    {
                        case 0x3D:
                        case 0x3F:
                            return Bits.GetShort(Data, 3);
                        case 0x3E:
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
            if (Opcode != 0xE9)
                throw new Exception("Not Command 0xE9");
            return Bits.GetShort(Data, index * 2 + 1);
        }
        /// <summary>
        /// Writes a value to the command's pointer.
        /// </summary>
        /// <param name="value">The new pointer value.</param>
        public override void WritePointer(ushort value)
        {
            switch (Opcode)
            {
                case 0x3A:
                case 0x3B:
                case 0xE4:
                case 0xE5:
                    Bits.SetShort(Data, 4, value); break;
                case 0x3C:
                case 0x3E:
                case 0xE0:
                case 0xE1:
                case 0xE2:
                case 0xE3:
                case 0xE6:
                case 0xE7:
                case 0xF8:
                    Bits.SetShort(Data, 3, value); break;
                case 0x3F:
                case 0xD8:
                case 0xD9:
                case 0xDA:
                case 0xDC:
                case 0xDD:
                case 0xDE:
                    Bits.SetShort(Data, 2, value); break;
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
                    Bits.SetShort(Data, 1, value); break;
                case 0xE9:
                    throw new Exception("E9");
                case 0xFD:
                    switch (Data[1])
                    {
                        case 0x3D:
                        case 0x3F:
                            Bits.SetShort(Data, 3, value); break;
                        case 0x3E:
                            Bits.SetShort(Data, 5, value); break;
                        default:
                            break;
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
        public override void WritePointerSpecial(int index, ushort value)
        {
            if (Opcode != 0xE9)
                throw new Exception("Not Command 0xE9");
            Bits.SetShort(Data, index * 2 + 1, value);
        }
        /// <summary>
        /// Sets the original offset to the current offset value.
        /// </summary>
        public void ResetOriginalOffset()
        {
            this.OriginalOffset = this.Offset;
        }

        /// <summary>
        /// Creates a TreeNode based on this command's parsed descriptive text.
        /// </summary>
        public TreeNode Node
        {
            get
            {
                TreeNode node = new TreeNode("[" + Offset.ToString("X6") + "]   " + ToString());
                if (Opcode >= 0xFE)
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
        public ActionCommand Copy()
        {
            return new ActionCommand(Bits.Copy(Data), this.Offset);
        }

        // Override
        public override string ToString()
        {
            return Parser.ParseCommand(this);
        }

        #endregion
    }
}
