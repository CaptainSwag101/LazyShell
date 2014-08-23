using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LAZYSHELL.Animations
{
    /// <summary>
    /// Incorporates an animation script into a TreeView control to manage a navigable user interface of TreeNodes and their associated script commands.
    /// </summary>
    public class TreeViewWrapper
    {
        #region Variables

        public Controls.NewTreeView TreeView { get; set; }
        public Script Script { get; set; }
        public TreeNode SelectedNode { get; set; }

        #endregion

        // Constructor
        public TreeViewWrapper(Controls.NewTreeView control)
        {
            this.TreeView = control;
        }

        #region Methods

        /// <summary>
        /// Associates the specified animation script with the TreeViewWrapper and populates 
        /// the TreeView with a collection of nodes generated from the script's commands.
        /// </summary>
        /// <param name="script">The script associated with the TreeViewWrapper.</param>
        /// <param name="suspendDrawing">Specifies whether to suspend all drawing operations in the 
        /// TreeView when repopulating, resuming after the operation is complete.</param>
        public void LoadScript(Script script, bool suspendDrawing)
        {
            this.Script = script;
            Populate(suspendDrawing);
            // Select the first node, if any, when finished
            if (this.TreeView.Nodes.Count > 0)
                this.TreeView.SelectedNode = this.TreeView.Nodes[0];
        }
        /// <summary>
        /// Associates the specified animation script with the TreeViewWrapper and populates 
        /// the TreeView with a collection of nodes generated from the script's commands.
        /// </summary>
        /// <param name="script">The script associated with the TreeViewWrapper.</param>
        public void LoadScript(Script script)
        {
            LoadScript(script, true);
        }

        /// <summary>
        /// Populates the TreeView with a collection of nodes generated from the current script's command collection.
        /// </summary>
        /// <param name="suspendDrawing"></param>
        private void Populate(bool suspendDrawing)
        {
            if (suspendDrawing)
                this.TreeView.BeginUpdate();
            this.TreeView.Nodes.Clear();
            //
            var commands = Script.Commands;
            for (int i = 0; i < commands.Count; i++)
                Add(commands[i]);
            //
            this.TreeView.ExpandAll();
            if (suspendDrawing)
                this.TreeView.EndUpdate();
        }

        /// <summary>
        /// Adds a command to the end of the TreeView.
        /// </summary>
        /// <param name="command">The command to add.</param>
        private void Add(Command command)
        {
            // Add node
            var node = command.Node;
            this.TreeView.Nodes.Add(node);
            node.Tag = command;
            //
            switch (command.Opcode)
            {
                case 0x09:
                case 0x10:
                case 0x5D:
                case 0x64:
                case 0x68:
                    Add(command, node);
                    break;
                default:
                    if (command.Opcode >= 0x24 && command.Opcode <= 0x2B)
                        Add(command, node);
                    break;
            }
        }
        /// <summary>
        /// Adds a command's child commands to its associated node in the TreeView.
        /// </summary>
        /// <param name="command">The command containing the child commands to add.</param>
        /// <param name="node">The node associated with the command.</param>
        private void Add(Command command, TreeNode node)
        {
            foreach (var childCommand in command.Commands)
            {
                var childNode = childCommand.Node;
                node.Nodes.Add(childNode);
                childNode = node.Nodes[node.Nodes.Count - 1];
                childNode.Tag = childCommand;
                //
                switch (childCommand.Opcode)
                {
                    case 0x09:
                    case 0x10:
                    case 0x5D:
                    case 0x64:
                    case 0x68:
                        Add(childCommand, childNode);
                        break;
                    default:
                        if (childCommand.Opcode >= 0x24 && childCommand.Opcode <= 0x2B)
                            Add(childCommand, childNode);
                        break;
                }
            }
        }
        /// <summary>
        /// Moves a command down in the collection and returns the raw bytes of the 
        /// two reversed commands resulting from the operation.
        /// </summary>
        /// <param name="command">The command to move.</param>
        /// <param name="topOffset">The offset of the previous command before the operation.
        /// This parameter's reference should be initialized to 0.</param>
        /// <returns></returns>
        public byte[] MoveUp(Command command, ref int topOffset)
        {
            if (SelectedNode.PrevNode == null)
                return null;
            if (command.Opcode == 0x07 ||
                command.Opcode == 0x11 ||
                command.Opcode == 0x5E)
                return null;
            var prevCommand = (Command)SelectedNode.PrevNode.Tag;
            if (prevCommand.Opcode == 0x07 ||
                prevCommand.Opcode == 0x11 ||
                prevCommand.Opcode == 0x5E)
                return null;
            if (SelectedNode.Index == 0)
                return null;
            return Reverse(prevCommand, command, ref topOffset);
        }
        /// <summary>
        /// Moves a command up in the collection and returns the raw bytes of the 
        /// two reversed commands resulting from the operation.
        /// </summary>
        /// <param name="command">The command to move.</param>
        /// <param name="topOffset">The offset of the command before the operation. 
        /// This parameter's reference should be initialized to 0.</param>
        /// <returns></returns>
        public byte[] MoveDown(Command command, ref int topOffset)
        {
            if (SelectedNode.NextNode == null)
                return null;
            if (command.Opcode == 0x07 ||
                command.Opcode == 0x11 ||
                command.Opcode == 0x5E)
                return null;
            var nextCommand = (Command)SelectedNode.NextNode.Tag;
            if (nextCommand.Opcode == 0x07 ||
                nextCommand.Opcode == 0x11 ||
                nextCommand.Opcode == 0x5E)
                return null;
            if (SelectedNode.Parent != null)
            {
                if (SelectedNode.Index >= SelectedNode.Parent.Nodes.Count - 1)
                    return null;
            }
            else if (SelectedNode.Index >= TreeView.Nodes.Count - 1)
                return null;
            return Reverse(command, nextCommand, ref topOffset);
        }
        /// <summary>
        /// Switches the position of two commands in the script's command collection.
        /// </summary>
        /// <param name="commandA">The first command.</param>
        /// <param name="commandB">The second command.</param>
        /// <param name="topOffset">The offset of the first command before the operation.
        /// This parameter's reference should be initialized to 0.</param>
        /// <returns></returns>
        private byte[] Reverse(Command commandA, Command commandB, ref int topOffset)
        {
            // reverse the bytes of the two commands
            byte[] byteA = Bits.Copy(commandB.Data);
            byte[] byteB = Bits.Copy(commandA.Data);
            commandA.Data = byteA;
            commandB.Data = byteB;
            // 
            int offset = commandA.InternalOffset;
            topOffset = commandA.InternalOffset;
            byte[] changes = new byte[commandA.Length + commandB.Length];
            for (int i = 0; i < byteA.Length; i++, offset++)
                changes[i] = commandA.Data[i];
            int temp = commandB.InternalOffset;
            commandB.InternalOffset = commandA.InternalOffset;
            commandA.InternalOffset = offset;
            int index = byteA.Length;
            for (int i = 0; i < byteB.Length; i++, offset++)
                changes[index++] = commandB.Data[i];
            commandA.Offset = commandA.OriginalOffset = commandA.InternalOffset;
            commandB.Offset = commandB.OriginalOffset = commandB.InternalOffset;
            return changes;
        }

        // Expand / Collapse treeView
        public void ExpandAll()
        {
            this.TreeView.ExpandAll();
        }
        public void CollapseAll()
        {
            this.TreeView.CollapseAll();
        }

        /// <summary>
        /// Selects a node in the treeView with a specified internalOffset.
        /// </summary>
        /// <param name="internalOffset">The internal offset of the node's command.</param>
        /// <param name="index">The full parent index of the node.</param>
        public void Select(int internalOffset, int fullParentIndex)
        {
            SelectedNode = null;
            int parentIndex = -1; // root has no parent
            int index = 0; // the current full index
            foreach (TreeNode node in this.TreeView.Nodes)
            {
                var asc = node.Tag as Command;
                if (internalOffset == asc.InternalOffset && parentIndex == fullParentIndex)
                {
                    SelectedNode = node;
                    break;
                }
                else
                    SelectChild(node, internalOffset, fullParentIndex, ref index);
                if (SelectedNode != null)
                    break;
            }
            this.TreeView.SelectedNode = SelectedNode;
        }
        private void SelectChild(TreeNode parent, int internalOffset, int fullParentIndex, ref int index)
        {
            int parentIndex = parent.Nodes.Count > 0 ? index++ : index;
            foreach (TreeNode child in parent.Nodes)
            {
                var asc = child.Tag as Command;
                if (internalOffset == asc.InternalOffset && parentIndex == fullParentIndex)
                {
                    SelectedNode = child;
                    break;
                }
                else
                    SelectChild(child, internalOffset, fullParentIndex, ref index);
                if (SelectedNode != null)
                    break;
            }
        }

        #endregion
    }
}
