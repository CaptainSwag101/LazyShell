using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace LazyShell.EventScripts
{
    [Serializable()]
    public class ActionScript : Element
    {
        #region Variables

        // Buffers
        [NonSerialized()]
        private byte[] rom;
        public byte[] Buffer { get; set; }

        // Index
        public override int Index { get; set; }

        /// <summary>
        /// Gets the total length of the script's binary data.
        /// </summary>
        public int Length
        {
            get { return Buffer.Length; }
        }
        
        // class variables
        public List<ActionCommand> Commands { get; set; }
        public ActionCommand PrevSibling
        {
            get
            {
                if (Commands.Count > 0)
                    return Commands[Commands.Count - 1];
                else
                    return null;
            }
        }

        // Offsets
        public int BaseOffset { get; set; }
        private int finalInternalOffset
        {
            get
            {
                if (PrevSibling != null)
                    return PrevSibling.InternalOffset + PrevSibling.Length;
                return 0;
            }
        }
        private int finalOffset
        {
            get
            {
                if (PrevSibling != null)
                    return PrevSibling.Offset + PrevSibling.Length;
                return 0;
            }
        }

        public bool IsUndoing { get; set; }
        public bool Embedded { get; set; }

        #endregion

        // Constructors
        public ActionScript(int index)
        {
            this.rom = Model.ROM;
            this.Index = index;
            this.Embedded = false;
            ReadFromROM();
        }
        public ActionScript(byte[] buffer, int index, int offset)
        {
            this.Buffer = buffer;
            this.Index = index;
            this.BaseOffset = offset;
            this.Embedded = true;
            ReadFromROM();
        }

        #region Methods

        // Read/write buffer
        private void ReadFromROM()
        {
            int length, offset = 0x210000;
            if (rom != null)
            {
                length = GetBufferSize();
                offset = Bits.GetShort(rom, 0x210000 + (Index * 2));
                this.BaseOffset = 0x210000 + offset;
                this.Buffer = Bits.GetBytes(rom, 0x210000 + offset, length);
            }
            ParseScript();
        }
        /// <summary>
        /// Returns the size of this script's data in the ROM.
        /// </summary>
        /// <returns></returns>
        private int GetBufferSize()
        {
            int offset = Bits.GetShort(rom, 0x210000 + Index * 2);
            int length;
            int start;
            if (Index == 1023)
            {
                length = 0xC000 - offset;
                start = 0x21BFFF;
                while (rom[start] == 0xFF)
                {
                    length--;
                    start--;
                }
                return length;
            }
            else
                return Bits.GetShort(rom, 0x210000 + (Index + 1) * 2) - offset;
        }
        public void WriteToBuffer()
        {
            int offset = 0;
            if (Commands == null)
            {
                Buffer = new byte[offset];
                return;
            }
            foreach (var command in Commands)
            {
                command.WriteToBuffer();
                offset += command.Length;
            }
            Buffer = new byte[offset];
            offset = 0;
            foreach (var command in Commands)
            {
                command.Data.CopyTo(Buffer, offset);
                offset += command.Length;
            }
        }

        /// <summary>
        /// Builds this script's command collection from the buffer data.
        /// </summary>
        public void ParseScript()
        {
            this.Commands = new List<ActionCommand>();
            int offset = 0, length;
            while (offset < Buffer.Length)
            {
                byte param1 = 0;
                if (Buffer.Length - offset > 1)
                    param1 = Buffer[offset + 1];
                length = ScriptEnums.GetActionCommandLength(Buffer[offset], param1);
                Commands.Add(new ActionCommand(Bits.GetBytes(Buffer, offset, length), this.BaseOffset + offset));
                offset += length;
            }
        }

        // Collection editing
        public void Add(ActionCommand asc)
        {
            Commands.Add(asc);
        }
        public void Insert(int index, ActionCommand asc)
        {
            try
            {
                Commands.Insert(index, asc);
            }
            catch
            {
                throw new Exception("Invalid index.");
            }
        }
        public int RemoveAt(int index)
        {
            try
            {
                ActionCommand asc = Commands[index];
                int length = asc.Length;
                Commands.RemoveAt(index);
                return length;
            }
            catch
            {
                throw new Exception("Invalid index.");
            }
        }
        public void Reverse(int index1, int index2)
        {
            ActionCommand asc = Commands[index1];
            Commands[index1] = Commands[index2];
            Commands[index2] = asc;
        }

        /// <summary>
        /// Updates this script's buffer data and all command offsets and pointers in this script.
        /// </summary>
        public void Refresh()
        {
            if (Commands == null)
                return;

            // First, write command properties to buffer
            WriteToBuffer();

            // Refresh offsets to exact values
            int offset = BaseOffset;
            foreach (var command in Commands)
            {
                command.Offset = offset;
                offset += command.Length;
            }

            // Reset flags indicating pointers changed
            var it = new ScriptIterator(this);
            while (!it.IsDone)
            {
                var command = it.Next();
                command.PointerChanged = new bool[256];
            }

            // Update all pointers to each command in this script
            it = new ScriptIterator(this);
            while (!it.IsDone)
            {
                var command = it.Next();
                if (!IsUndoing && State.Instance.AutoPointerUpdate)
                    UpdatePointersToCommand(command);
                command.InternalOffset = command.Offset;
            }

            // Update all pointers after this script
            if (!IsUndoing && State.Instance.AutoPointerUpdate)
                UpdatePointersAfterScript();
        }
        /// <summary>
        /// Updates all of the pointers in this script pointing directly to a given command's offset.
        /// </summary>
        /// <param name="reference">The reference command in this script.</param>
        private void UpdatePointersToCommand(Command reference)
        {
            var it = new ScriptIterator(this);
            while (!it.IsDone)
            {
                var command = it.Next();
                int pointer;
                if (command.Opcode == 0x42 || command.Opcode == 0x67 || command.Opcode == 0xE9)
                {
                    if (command is EventCommand || command.Opcode == 0xE9)
                    {
                        pointer = command.ReadPointerSpecial(0);
                        if (pointer == (reference.InternalOffset & 0xFFFF) && !command.PointerChanged[0])
                        {
                            command.WritePointerSpecial(0, (ushort)(reference.Offset & 0xFFFF));
                            command.PointerChanged[0] = true;
                        }
                        pointer = command.ReadPointerSpecial(1);
                        if (pointer == (reference.InternalOffset & 0xFFFF) && !command.PointerChanged[1])
                        {
                            command.WritePointerSpecial(1, (ushort)(reference.Offset & 0xFFFF));
                            command.PointerChanged[1] = true;
                        }
                    }
                    else
                    {
                        pointer = command.ReadPointer();
                        if (pointer == (reference.InternalOffset & 0xFFFF) && !command.PointerChanged[0])
                        {
                            command.WritePointer((ushort)(reference.Offset & 0xFFFF));
                            command.PointerChanged[0] = true;
                        }
                    }
                }
                else
                {
                    pointer = command.ReadPointer();
                    if (pointer == (reference.InternalOffset & 0xFFFF) && !command.PointerChanged[0])
                    {
                        command.WritePointer((ushort)(reference.Offset & 0xFFFF));
                        command.PointerChanged[0] = true;
                    }
                }
            }
        }
        /// <summary>
        /// Adds the change in this script's size to all of the pointers 
        /// in the script that point to an offset after the script.
        /// </summary>
        private void UpdatePointersAfterScript()
        {
            int delta = this.finalOffset - this.finalInternalOffset;
            //
            var it = new ScriptIterator(this);
            while (!it.IsDone)
            {
                var eac = it.Next();
                int pointer;
                if (eac.Opcode == 0x42 || eac.Opcode == 0x67 || eac.Opcode == 0xE9)
                {
                    if (eac is EventCommand || eac.Opcode == 0xE9)
                    {
                        pointer = eac.ReadPointerSpecial(0);
                        if (pointer >= (this.finalInternalOffset & 0xFFFF) && !eac.PointerChanged[0])
                        {
                            eac.WritePointerSpecial(0, (ushort)(pointer + delta));
                            eac.PointerChanged[0] = true;
                        }
                        pointer = eac.ReadPointerSpecial(1);
                        if (pointer >= (this.finalInternalOffset & 0xFFFF) && !eac.PointerChanged[1])
                        {
                            eac.WritePointerSpecial(1, (ushort)(pointer + delta));
                            eac.PointerChanged[1] = true;
                        }
                    }
                    else
                    {
                        pointer = eac.ReadPointer();
                        if (pointer >= (this.finalInternalOffset & 0xFFFF) && !eac.PointerChanged[0])
                        {
                            eac.WritePointer((ushort)(pointer + delta));
                            eac.PointerChanged[0] = true;
                        }
                    }
                }
                else
                {
                    pointer = eac.ReadPointer();
                    if (pointer >= (this.finalInternalOffset & 0xFFFF) && !eac.PointerChanged[0])
                    {
                        eac.WritePointer((ushort)(pointer + delta));
                        eac.PointerChanged[0] = true;
                    }
                }
            }
        }
        /// <summary>
        /// Adds a delta value to the script's base offset and any pointers 
        /// in the script that point to or after a specified offset.
        /// </summary>
        /// <param name="delta">The value to add to any pointers.</param>
        /// <param name="conditionOffset">The offset to compare to.</param>
        public void UpdateOffsets(int delta, int conditionOffset)
        {
            if (this.BaseOffset >= conditionOffset || conditionOffset == 0x7FFFFFFF)
                this.BaseOffset += delta;
            if (Commands == null)
                return;
            foreach (var command in Commands)
                command.UpdatePointer(delta, conditionOffset);
        }

        /// <summary>
        /// Creates a deep copy of this instance.
        /// </summary>
        /// <returns></returns>
        public ActionScript Copy()
        {
            ActionScript copy = new ActionScript(this.Index);
            return copy;
        }
        public override void Clear()
        {
            if (Commands != null)
                Commands.Clear();
            WriteToBuffer();
        }

        #endregion
    }
}
