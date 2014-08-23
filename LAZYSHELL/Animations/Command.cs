using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LAZYSHELL.Animations
{
    /// <summary>
    /// Class for the creation and management of animation script commands in the Mario RPG ROM.
    /// </summary>
    public class Command : LAZYSHELL.Command
    {
        #region Variables

        /// <summary>
        /// Tthe index of this command in its parent collection.
        /// </summary>
        public int Index
        {
            get
            {
                List<Command> commandList;
                if (Parent == null)
                    commandList = Script.Commands;
                else
                    commandList = Parent.Commands;
                return commandList.IndexOf(this);
            }
        }
        /// <summary>
        /// This command's parent script.
        /// </summary>
        public Script Script { get; set; }
        /// <summary>
        /// This command's parent command.
        /// </summary>
        public Command Parent { get; set; }
        /// <summary>
        /// This command's collection of child commands.
        /// </summary>
        public List<Command> Commands { get; set; }

        /// <summary>
        /// This command's next sibling in the parent collection.
        /// </summary>
        public Command NextSibling
        {
            get
            {
                List<Command> commandList;
                if (Parent == null)
                    commandList = Script.Commands;
                else
                    commandList = Parent.Commands;
                int index = commandList.IndexOf(this);
                if (index >= 0 && index + 1 < commandList.Count - 1)
                    return commandList[index + 1];
                return null;
            }
        }
        /// <summary>
        /// This command's previous sibling in the parent collection.
        /// </summary>
        public Command PrevSibling
        {
            get
            {
                List<Command> commandList;
                if (Parent == null)
                    commandList = Script.Commands;
                else
                    commandList = Parent.Commands;
                int index = commandList.IndexOf(this);
                if (index > 0)
                    return commandList[index - 1];
                return null;
            }
        }

        #endregion

        /// <summary>
        /// Initializes an instance of an animation script command from the specified binary data and,
        /// if the command is a subroutine pointer, builds the required child command collection.
        /// </summary>
        /// <param name="data">The command's binary data.</param>
        /// <param name="offset">The offset of the data in the ROM buffer.</param>
        /// <param name="script">The parent script of this instance.</param>
        /// <param name="parent">The parent command of this instance.</param>
        public Command(byte[] data, int offset, Script script, Command parent)
        {
            this.Commands = new List<Command>();
            this.Data = data;
            this.Parent = parent;
            this.Offset = offset;
            this.OriginalOffset = offset;
            this.InternalOffset = offset;
            this.Script = script;
            ParseCommand();
        }

        #region Methods

        /// <summary>
        /// Analyzes the command data and, if necessary, builds the command 
        /// collection from the binary data of a referenced subroutine.
        /// </summary>
        private void ParseCommand()
        {
            int findOffset = 0;
            switch (Opcode)
            {
                case 0xA3:
                    break;
                case 0x09:
                    findOffset = (Offset & 0xFF0000) + Bits.GetShort(Data, 1);
                    if (Parent == null && !ContainsOffset(Script, findOffset))
                        ParseSubroutine((Offset & 0xFF0000) + Bits.GetShort(Data, 1));
                    else if (Parent != null && !Parent.ContainsOffset(Parent, findOffset))
                        ParseSubroutine((Offset & 0xFF0000) + Bits.GetShort(Data, 1));
                    break;
                case 0x10: // Jump to subroutine
                case 0x64: // Run synchronous subroutine, 1-depth
                case 0x68: // Run synchronous subroutine, 2-depth
                    if (Offset == 0x3562C8 ||
                        Offset == 0x3564FC)
                        Script.AMEM = 0; // Reset the action memory
                    if ((Offset & 0xFF0000) == 0x350000 && Bits.GetShort(Data, 1) == 0x8499)
                        Script.AMEM = 0; // Reset the action memory
                    if (Offset == 0x3AA5EE)
                        Script.AMEM = 12; // This points to the only subroutine that has enough pointers
                    ParseSubroutine((Offset & 0xFF0000) + Bits.GetShort(Data, 1));
                    break;
                case 0x5D:
                    ParseSubroutine((Offset & 0xFF0000) + Bits.GetShort(Data, 3));
                    break;
                // Action memory 
                case 0x20:
                case 0x21: if ((Param1 & 0x0F) == 0) Script.AMEM = Param2; break;
                case 0x2C:
                case 0x2D: if ((Param1 & 0x0F) == 0) Script.AMEM += Param2; break;
                case 0x2E:
                case 0x2F: if ((Param1 & 0x0F) == 0) Script.AMEM -= Param2; break;
                case 0x30:
                case 0x31: if ((Param1 & 0x0F) == 0) Script.AMEM++; break;
                case 0x32:
                case 0x33: if ((Param1 & 0x0F) == 0) Script.AMEM--; break;
                case 0x34:
                case 0x35: if ((Param1 & 0x0F) == 0) Script.AMEM = 0; break;
                case 0x6A:
                case 0x6B: if ((Param1 & 0x0F) == 0) Script.AMEM = (byte)(Param2 - 1); break;
                default:
                    if (Opcode >= 0x24 && Opcode <= 0x2B)
                    {
                        findOffset = (Offset & 0xFF0000) + Bits.GetShort(Data, 4);
                        if (Parent == null && !ContainsOffset(Script, findOffset))
                            ParseSubroutine((Offset & 0xFF0000) + Bits.GetShort(Data, 4));
                        else if (Parent != null && !Parent.ContainsOffset(Parent, findOffset))
                            ParseSubroutine((Offset & 0xFF0000) + Bits.GetShort(Data, 4));
                    }
                    break;
            }
        }
        /// <summary>
        /// Builds this command collection from a subroutine's binary data.
        /// </summary>
        /// <param name="offset">The starting offset of the subroutine's binary data.</param>
        private void ParseSubroutine(int offset)
        {
            switch (Opcode)
            {
                case 0x09: // Jump to address
                    int length = 0;
                    while ((offset & 0xFFFF) < 0xFFFF)
                    {
                        // These are unusual cases, seems this is the only way
                        if (offset == 0x356076) break;
                        if (offset == 0x356087) break;
                        if (offset == 0x3560A9) break;
                        if (offset == 0x3560CD) break;
                        if (offset == 0x3560FE) break;
                        if (offset == 0x356131) break;
                        if (offset == 0x356152) break;
                        if (offset == 0x35617A) break;
                        if (offset == 0x3561AD) break;
                        if (offset == 0x3561E0) break;
                        if (offset == 0x356213) break;
                        if (offset == 0x35624B) break;
                        if (offset == 0x3A8A68) break;
                        if (offset == 0x3A8AC0) break;
                        if (offset == 0x3A8C8A) break;
                        if ((offset & 0xFF0000) == 0x3A0000 && offset < 0x3A60D0)
                            break;
                        if (offset < ROM.Length - 2)
                            length = ScriptEnums.GetCommandLength(ROM[offset], ROM[offset + 1]);
                        else
                            length = ScriptEnums.GetCommandLength(ROM[offset], 0);
                        var temp = new Command(Bits.GetBytes(ROM, offset, length), offset, Script, this);
                        Commands.Add(temp);
                        if (ROM[offset] == 0x07 || // End animation packet
                            ROM[offset] == 0x09 || // Jump to address (thus ending this)
                            ROM[offset] == 0x11 || // End subroutine
                            ROM[offset] == 0x5E)   // End sprite subroutine
                            break;
                        offset += length;
                    }
                    break;
                case 0x10: goto case 0x09;
                case 0x5D: goto case 0x09;
                case 0x64:
                    if (Script.AMEM > 0x10)
                    {
                        Script.AMEM = 0;
                        offset = (offset & 0xFF0000) + Bits.GetShort(ROM, offset);
                    }
                    else
                        offset = (offset & 0xFF0000) + Bits.GetShort(ROM, offset + (Script.AMEM * 2));
                    goto case 0x09;
                case 0x68:
                    if (Script.AMEM >= 0x40)
                    {
                        Script.AMEM = 0;
                        offset = (offset & 0xFF0000) + Bits.GetShort(ROM, offset);
                    }
                    else
                        offset = (offset & 0xFF0000) + Bits.GetShort(ROM, offset + (Script.AMEM * 2));
                    //
                    if (offset == 0x356919 ||
                        offset == 0x356969)
                        offset += 2;
                    else
                        offset = (offset & 0xFF0000) + Bits.GetShort(ROM, offset + Data[3]);
                    goto case 0x09;
                default:
                    if (Opcode >= 0x24 && Opcode <= 0x2B)
                    {
                        offset = (offset & 0xFF0000) + Bits.GetShort(Data, 4);
                        goto case 0x09;
                    }
                    break;
            }
        }
        /// <summary>
        /// Returns a value indicating whether a parent command contains a child command with the specified offset.
        /// Searches through the entire hierarchy of commands nested within the specified parent command.
        /// </summary>
        /// <param name="parent">The parent command of the child commands to search through.</param>
        /// <param name="offset">The offset to search for.</param>
        /// <returns></returns>
        public bool ContainsOffset(Command parent, int offset)
        {
            bool found = false;
            foreach (var child in parent.Commands)
            {
                if (child.InternalOffset == offset)
                    return true;
            }
            if (parent.Parent != null)
                found = ContainsOffset(parent.Parent, offset);
            return found;
        }
        /// <summary>
        /// Returns a value indicating whether an animation script contains a child command with the specified offset.
        /// Searches through the entire hierarchy of commands nested within the specified parent script.
        /// </summary>
        /// <param name="parent">The parent command of the child commands to search through.</param>
        /// <param name="offset">The offset to search for.</param>
        /// <returns></returns>
        public bool ContainsOffset(Script script, int offset)
        {
            bool found = false;
            foreach (var command in script.Commands)
            {
                if (command.InternalOffset == offset)
                    return true;
            }
            return found;
        }
        /// <summary>
        /// Returns the available space or final index for replacing this command or any later sibling commands.
        /// </summary>
        /// <param name="needed">The length of the new command (ie. the required space).</param>
        /// <param name="getIndex">Specifies whether to return the available space or the index of the last command to be replaced.</param>
        /// <returns></returns>
        public int AvailableSpace(int needed, bool getIndex)
        {
            int finalIndex = this.Index;
            int available = this.Length;
            Command temp = this;
            while (
                needed > available &&
                temp.NextSibling != null &&
                temp.NextSibling.Opcode != 0x07 &&
                temp.NextSibling.Opcode != 0x11 &&
                temp.NextSibling.Opcode != 0x5E)
            {
                temp = temp.NextSibling;
                finalIndex++;
                available += temp.Length;
            }
            return getIndex ? finalIndex : available;
        }

        /// <summary>
        /// Creates a TreeNode based on this command's parsed descriptive text.
        /// </summary>
        public TreeNode Node
        {
            get
            {
                TreeNode node = new TreeNode("[" + (this.Offset).ToString("X6") + "]   " + ToString());
                switch (this.Opcode)
                {
                    case 0x07:
                    case 0x11:
                    case 0x5E:
                        node.BackColor = Color.FromArgb(255, 255, 255, 200);
                        break;
                    case 0x09:
                    case 0x10:
                    case 0x5D:
                    case 0x64:
                    case 0x68:
                        node.BackColor = Color.FromArgb(255, 224, 232, 255);
                        break;
                    default:
                        if (this.Opcode >= 0x24 && this.Opcode <= 0x2B)
                            node.BackColor = Color.FromArgb(255, 224, 232, 255);
                        break;
                }
                return node;
            }
        }
        /// <summary>
        /// Creates a deep copy of this instance.
        /// </summary>
        /// <returns></returns>
        public Command Copy()
        {
            return new Command(Bits.Copy(Data), this.Offset, this.Script, this.Parent);
        }

        // Override
        public override string ToString()
        {
            return Parser.ParseCommand(this);
        }

        #endregion
    }
}
