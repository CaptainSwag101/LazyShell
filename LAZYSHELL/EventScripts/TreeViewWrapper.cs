using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;
using System.Runtime.InteropServices;

namespace LazyShell.EventScripts
{
    /// <summary>
    /// Incorporates an event or action script into a TreeView control to manage a navigable interface of TreeNodes and their associated script commands.
    /// </summary>
    public class TreeViewWrapper
    {
        #region Variables

        private Controls.NewTreeView treeView;
        public TreeNode SelectedNode { get; set; }
        public TreeNode EditedNode { get; set; }
        public int SelectedIndex
        {
            get { return treeView.GetFullIndex(); }
            set { treeView.SelectNode(value); }
        }
        public EventScript Script { get; set; }
        public ActionScript Action { get; set; }
        public bool ActionScript { get; set; }
        public int ScriptDelta { get; set; }
        private List<Command> commandCopies;

        #endregion

        // Constructor
        public TreeViewWrapper(Controls.NewTreeView control)
        {
            this.treeView = control;
        }

        #region Methods

        /// <summary>
        /// Associates the specified event script with the TreeViewWrapper.
        /// </summary>
        /// <param name="script">The script associated with the TreeViewWrapper.</param>
        public void LoadScript(EventScript script)
        {
            this.Script = script;
            foreach (EventCommand esc in script.Commands)
                esc.ResetOriginalOffset();
            Populate();
        }
        /// <summary>
        /// Associates the specified action script with the TreeViewWrapper.
        /// </summary>
        /// <param name="script">The script associated with the TreeViewWrapper.</param>
        public void LoadScript(ActionScript action)
        {
            this.Action = action;
            foreach (ActionCommand asc in action.Commands)
                asc.ResetOriginalOffset();
            Populate();
        }

        /// <summary>
        /// Populates the TreeView with a collection of nodes generated from the current script's command collection.
        /// </summary>
        /// <param name="suspendDrawing"></param>
        private void Populate()
        {
            this.treeView.Nodes.Clear();
            if (!ActionScript)
            {
                for (int i = 0; i < Script.Commands.Count; i++)
                    Add(Script.Commands[i]);
            }
            else
            {
                for (int i = 0; i < Action.Commands.Count; i++)
                    Add(Action.Commands[i]);
            }
            this.treeView.ExpandAll();
        }

        /// <summary>
        /// Adds a command to the end of the TreeView.
        /// </summary>
        /// <param name="command">The command to add.</param>
        private void Add(EventCommand command)
        {
            var node = command.Node;
            if (command.QueueTrigger || command.Locked)
            {
                if (command.Queue == null)
                    return;
                var queue = command.Queue.Commands;
                for (int i = 0; queue != null && i < queue.Count; i++)
                {
                    var asc = queue[i];
                    var child = asc.Node;
                    node.Nodes.Add(child);
                }
            }
            // Add command
            this.treeView.Nodes.Add(node);
        }
        /// <summary>
        /// Adds a command to the end of the TreeView.
        /// </summary>
        /// <param name="command">The command to add.</param>
        private void Add(ActionCommand command)
        {
            // Add command
            this.treeView.Nodes.Add(command.Node);
        }
        /// <summary>
        /// Inserts an event command after the selected node in the TreeView.
        /// </summary>
        /// <param name="command">The command to insert into the TreeView.</param>
        public void Insert(EventCommand command)
        {
            try
            {
                if (ActionScript)
                {
                    foreach (var acc in Action.Commands)
                        acc.Modified = false;
                }
                else
                {
                    foreach (var evc in Script.Commands)
                    {
                        evc.Modified = false;
                        if (evc.Queue == null) continue;
                        foreach (var acc in evc.Queue.Commands)
                            acc.Modified = false;
                    }
                }
                this.treeView.BeginUpdate();
                var node = treeView.SelectedNode;

                // Get index to insert at
                int index = node != null ? treeView.SelectedNode.Index + 1 : 0;

                // Only add if script empty or is NOT an action command
                if (node == null || IsRootNode(node))
                {
                    // Insert into treeview
                    SelectedNode = command.Node;
                    this.treeView.Nodes.Insert(index, SelectedNode);

                    // Insert into script at same index
                    command.Modified = true;
                    this.Script.Insert(index, command);
                    this.ScriptDelta += command.Length;
                }
            }
            finally
            {
                RefreshScript(); // Update offsets and descriptions
                this.treeView.EndUpdate();
            }
        }
        /// <summary>
        /// Inserts an action command after the selected node in the TreeView.
        /// </summary>
        /// <param name="command">The command to insert into the TreeView.</param>
        public void Insert(ActionCommand command)
        {
            try
            {
                if (ActionScript)
                {
                    foreach (var acc in Action.Commands)
                        acc.Modified = false;
                }
                else
                {
                    foreach (var evc in Script.Commands)
                    {
                        evc.Modified = false;
                        if (evc.Queue == null) continue;
                        foreach (var aqc in evc.Queue.Commands)
                            aqc.Modified = false;
                    }
                }
                this.treeView.BeginUpdate();
                int index;
                TreeNode node = treeView.SelectedNode;
                // embedded action queue
                if (!ActionScript)
                {
                    if (node == null)
                        return;
                    // Get index to insert at
                    index = treeView.SelectedNode.Index + 1;
                    if (node.Parent == null)
                    {
                        if ((Script.Commands[treeView.SelectedNode.Index]).QueueTrigger)
                            index = 0;
                        else
                        {
                            MessageBox.Show(
                                "Cannot insert an action command outside of an action queue.",
                                "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                    else
                        node = node.Parent;
                    //
                    int maxLength;
                    EventCommand esc = (Script.Commands[node.Index]);
                    if (esc.Param1 < 0xF0)
                    {
                        maxLength = (esc.Param1 & 0x80) == 0x80 ? 111 : 127;
                        if ((esc.Length - 2 + command.Length) > maxLength)
                        {
                            MessageBox.Show(
                                "Could not add any more action commands to the queue.",
                                "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        esc.Param1 += (byte)command.Length;
                    }
                    else
                    {
                        maxLength = (esc.Param2 & 0x80) == 0x80 ? 111 : 127;
                        if ((esc.Length - 3 + command.Length) > maxLength)
                        {
                            MessageBox.Show(
                                "Could not add any more action commands to the queue.",
                                "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        esc.Param2 += (byte)command.Length;
                    }
                    // Insert into treeview
                    SelectedNode = command.Node;
                    node.Nodes.Insert(index, SelectedNode);
                    // Insert into action queue at same index
                    command.Modified = true;
                    this.Script.Insert(node.Index, index, command);
                    this.ScriptDelta += command.Length;
                    //
                    treeView.ExpandAll();
                }
                // Insert action script command
                else
                {
                    // Get index to insert at
                    if (node == null)
                        index = 0;
                    else
                        index = treeView.SelectedNode.Index + 1;
                    // ActionScript Command
                    if (node == null || IsRootNode(node))
                    {
                        // Insert into treeview
                        SelectedNode = command.Node;
                        treeView.Nodes.Insert(index, SelectedNode);
                        // Insert into script at same index
                        command.Modified = true;
                        this.Action.Insert(index, command);
                        this.ScriptDelta += command.Length;
                    }
                }
            }
            finally
            {
                // Update offsets and descriptions
                RefreshScript();
                this.treeView.EndUpdate();
            }
        }
        /// <summary>
        /// Replaces the selected node in the TreeView control with a specified event command.
        /// </summary>
        /// <param name="command">The command to insert into the TreeView.</param>
        public void Replace(EventCommand command)
        {
            try
            {
                TreeNode node = EditedNode;
                if (node == null)
                    return;
                this.treeView.BeginUpdate();
                // Get index to insert at
                int index = EditedNode.Index;
                SelectedNode = new TreeNode(command.ToString());
                // EvenScript Command
                if (IsRootNode(node))
                {
                    // Insert into treeview
                    this.treeView.Nodes.RemoveAt(index);
                    this.treeView.Nodes.Insert(index, command.ToString());
                    // Insert into script at same index
                    this.Script.RemoveAt(index);
                    this.Script.Insert(index, command);
                    treeView.SelectedNode = this.treeView.Nodes[index];
                }
            }
            finally
            {
                // Update offsets and descriptions
                RefreshScript();
                this.treeView.EndUpdate();
            }
        }
        /// <summary>
        /// Replaces the selected node in the TreeView control with a specified action command.
        /// </summary>
        /// <param name="esc">The command to insert into the TreeView.</param>
        public void Replace(ActionCommand command)
        {
            try
            {
                this.treeView.BeginUpdate();
                TreeNode node = EditedNode;
                if (node == null)
                    return;
                // Get index to insert at
                int index = EditedNode.Index;
                SelectedNode = new TreeNode(command.ToString());
                if (!ActionScript)
                {
                    if (IsRootNode(node))
                        return;
                    node = node.Parent;
                    if (IsRootNode(node))
                    {
                        // Insert into treeview
                        node.Nodes.RemoveAt(index);
                        node.Nodes.Insert(index, command.ToString());
                        // Insert into action queue at same index
                        this.Script.RemoveAt(node.Index, index);
                        this.Script.Insert(node.Index, index, command);
                        treeView.SelectedNode = node.Nodes[index];
                    }
                }
                else
                {
                    // ActionScript Command
                    if (IsRootNode(node))
                    {
                        // Insert into treeview
                        this.treeView.Nodes.RemoveAt(index);
                        this.treeView.Nodes.Insert(index, command.ToString());
                        // Insert into script at same index
                        this.Action.RemoveAt(node.Index);
                        this.Action.Insert(index, command);
                        treeView.SelectedNode = this.treeView.Nodes[index];
                    }
                }
            }
            finally
            {
                // Update offsets and descriptions
                RefreshScript();
                this.treeView.EndUpdate();
            }
        }
        /// <summary>
        /// Removes the selected node in the TreeView control.
        /// </summary>
        public void Remove()
        {
            try
            {
                this.treeView.BeginUpdate();
                int delta, index;
                TreeNode node;
                TreeNode parent, child;
                for (int i = treeView.Nodes.Count - 1; i >= 0; i--)
                {
                    parent = treeView.Nodes[i];
                    for (int a = parent.Nodes.Count - 1; a >= 0; a--)
                    {
                        child = parent.Nodes[a];
                        if (!child.Checked)
                            continue;
                        delta = -((ActionCommand)child.Tag).Data.Length;
                        node = child;
                        if (node == null)
                            return;
                        index = child.Index;
                        node = node.Parent;
                        // Decrease queue length option byte
                        EventCommand esc = Script.Commands[node.Index];
                        ActionCommand aqc = esc.Queue.Commands[index];
                        if (esc.Param1 < 0xF0)
                            esc.Param1 -= (byte)aqc.Length;
                        else
                            esc.Param2 -= (byte)aqc.Length;
                        // Remove action command
                        child.Remove();
                        this.Script.RemoveAt(parent.Index, child.Index);
                        this.ScriptDelta += delta;
                    }
                    if (!parent.Checked)
                        continue;
                    if (!ActionScript)
                        delta = -((EventCommand)parent.Tag).Data.Length;
                    else
                        delta = -((ActionCommand)parent.Tag).Data.Length;
                    node = parent;
                    if (node == null)
                        return;
                    index = parent.Index;
                    // Remove event command
                    parent.Remove();
                    if (!ActionScript)
                        this.Script.RemoveAt(parent.Index);
                    else
                        this.Action.RemoveAt(parent.Index);
                    this.ScriptDelta += delta;
                }
            }
            finally
            {
                // Update offsets and descriptions
                RefreshScript();
                this.treeView.EndUpdate();
            }
        }
        /// <summary>
        /// Moves the selected node up in the TreeView control.
        /// </summary>
        public void MoveUp()
        {
            this.treeView.BeginUpdate();
            try
            {
                int index1, index2;
                foreach (TreeNode parent in treeView.Nodes)
                {
                    foreach (TreeNode child in parent.Nodes)
                    {
                        if (!child.Checked)
                            continue;
                        if (child.Index == 0)
                            break;
                        if (child == null)
                            return;
                        index1 = child.Index;
                        if (child.PrevNode == null)
                            return;
                        index2 = child.PrevNode.Index;
                        Reverse(index1, index2);
                        // if selected node is one of the checked ones
                        if (child == SelectedNode)
                            SelectedNode = child.PrevNode;
                    }
                    if (!parent.Checked)
                        continue;
                    if (parent.Index == 0)
                        break;
                    if (parent == null)
                        return;
                    index1 = parent.Index;
                    if (parent.PrevNode == null)
                        return;
                    index2 = parent.PrevNode.Index;
                    Reverse(index1, index2);
                    // if selected node is one of the checked ones
                    if (parent == SelectedNode)
                        SelectedNode = parent.PrevNode;
                }
            }
            finally
            {
                // Update offsets and descriptions
                RefreshScript();
            }
            this.treeView.EndUpdate();
        }
        /// <summary>
        /// Moves the selected node down in the TreeView control.
        /// </summary>
        public void MoveDown()
        {
            this.treeView.BeginUpdate();
            try
            {
                int index1, index2;
                TreeNode parent, child;
                for (int i = treeView.Nodes.Count - 1; i >= 0; i--)
                {
                    parent = treeView.Nodes[i];
                    for (int a = parent.Nodes.Count - 1; a >= 0; a--)
                    {
                        child = parent.Nodes[a];
                        if (!child.Checked)
                            continue;
                        if (child.Index == parent.Nodes.Count - 1)
                            break;
                        if (child == null)
                            return;
                        index1 = child.Index;
                        if (child.NextNode == null)
                            return;
                        index2 = child.NextNode.Index;
                        Reverse(index1, index2);
                        // if selected node is one of the checked ones
                        if (child == SelectedNode)
                            SelectedNode = child.NextNode;
                    }
                    //
                    if (!parent.Checked)
                        continue;
                    if (parent.Index == treeView.Nodes.Count - 1)
                        break;
                    if (parent == null)
                        return;
                    index1 = parent.Index;
                    if (parent.NextNode == null)
                        return;
                    index2 = parent.NextNode.Index;
                    Reverse(index1, index2);
                    // if selected node is one of the checked ones
                    if (parent == SelectedNode)
                        SelectedNode = parent.NextNode;
                }
            }
            finally
            {
                // Update offsets and descriptions
                RefreshScript();
            }
            this.treeView.EndUpdate();
        }
        /// <summary>
        /// Switches the position of two commands in the script's command collection.
        /// </summary>
        /// <param name="commandA">The index of the first command.</param>
        /// <param name="commandB">The index of the second command.</param>
        /// <returns></returns>
        private void Reverse(int index1, int index2)
        {
            if (IsRootNode(treeView.SelectedNode))
            {
                if (!ActionScript)
                    Script.Reverse(index1, index2);
                else
                    Action.Reverse(index1, index2);
            }
            else
            {
                int parent = treeView.SelectedNode.Parent.Index;
                EventCommand esc = Script.Commands[parent];
                esc.Queue.Reverse(index1, index2);
            }
        }
        /// <summary>
        /// Copies a node's command and any child commands.
        /// </summary>
        public void Copy()
        {
            try
            {
                this.treeView.BeginUpdate();

                // Get selected node in treeView
                var node = this.treeView.SelectedNode;
                if (node == null)
                    return;

                // Set properties of selected node
                int index = this.treeView.SelectedNode.Index;
                bool parentChecked = false;
                bool childChecked = false;

                // Build copied command collection
                commandCopies = new List<Command>();
                foreach (TreeNode parent in treeView.Nodes)
                {
                    foreach (TreeNode child in parent.Nodes)
                    {
                        if (!child.Checked)
                            continue;
                        childChecked = true;
                        if (parentChecked)
                        {
                            MessageBox.Show(
                                "Cannot create a copy buffer that contains both event and action\n" +
                                "commands. Please uncheck all action OR event commands.",
                                "LAZY SHELL");
                            commandCopies = null;
                            return;
                        }
                        var asc = child.Tag as ActionCommand;
                        asc.WriteToBuffer();
                        commandCopies.Add(asc.Copy());
                    }
                    if (!parent.Checked)
                        continue;
                    parentChecked = true;
                    if (childChecked)
                    {
                        MessageBox.Show(
                            "Cannot create a copy buffer that contains both event and action\n" +
                            "commands. Please uncheck all action OR event commands.",
                            "LAZY SHELL");
                        commandCopies = null;
                        return;
                    }
                    if (!ActionScript)
                    {
                        var esc = parent.Tag as EventCommand;
                        esc.WriteToBuffer();
                        commandCopies.Add(esc.Copy());
                    }
                    else
                    {
                        var asc = parent.Tag as ActionCommand;
                        asc.WriteToBuffer();
                        commandCopies.Add(asc.Copy());
                    }
                }
            }
            finally
            {
                this.treeView.Select();
                this.treeView.EndUpdate();
            }
        }
        /// <summary>
        /// Pastes the copied node(s) after/into the selected command.
        /// </summary>
        public void Paste()
        {
            // Uncheck all nodes in treeView
            foreach (TreeNode parent in treeView.Nodes)
            {
                if (parent.Checked)
                    parent.Checked = false;
                foreach (TreeNode child in parent.Nodes)
                    if (child.Checked)
                        child.Checked = false;
            }

            // Backup selected node
            TreeNode selectedNode = treeView.SelectedNode;

            // Pasting event command into event script
            if (commandCopies != null && !ActionScript && (selectedNode == null || IsRootNode(selectedNode)))
            {
                try
                {
                    foreach (EventCommand copy in commandCopies)
                    {
                        Insert(copy.Copy());
                        treeView.SelectedNode = selectedNode;
                    }
                }
                catch
                {
                    // Pasting action command into queue trigger
                    if (selectedNode != null && selectedNode.BackColor == Color.FromArgb(192, 224, 255))
                    {
                        foreach (ActionCommand copy in commandCopies)
                        {
                            Insert(copy.Copy());
                            treeView.SelectedNode = selectedNode;
                        }
                    }
                    else
                    {
                        MessageBox.Show("You cannot paste action commands outside of an action queue.", "LAZY SHELL");
                        return;
                    }
                }
            }
            // Pasting action command into action script or action queue
            else if (commandCopies != null)
            {
                try
                {
                    foreach (ActionCommand ascCopy in commandCopies)
                    {
                        Insert(ascCopy.Copy());
                        treeView.SelectedNode = selectedNode;
                    }
                }
                catch
                {
                    MessageBox.Show("You cannot paste event commands into an action script or action queue.", "LAZY SHELL");
                    return;
                }
            }
            this.treeView.Select();
        }
        /// <summary>
        /// Selects a node in the treeView, tagged with the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        public void Select(Command command)
        {
            if (command != null)
            {
                foreach (TreeNode node in treeView.Nodes)
                {
                    if (node.Tag == command)
                    {
                        treeView.SelectedNode = node;
                        return;
                    }
                    foreach (TreeNode child in node.Nodes)
                    {
                        if (child.Tag == command)
                        {
                            treeView.SelectedNode = child;
                            return;
                        }
                    }
                }
            }
        }

        // Expand / Collapse treeView
        public void ExpandAll()
        {
            this.treeView.ExpandAll();
        }
        public void CollapseAll()
        {
            this.treeView.CollapseAll();
        }

        /// <summary>
        /// Clears the command collection and removes all nodes from the treeView.
        /// </summary>
        public void Clear()
        {
            this.Script.WriteToBuffer();
            this.treeView.BeginUpdate();
            if (ActionScript)
            {
                this.ScriptDelta -= Action.Length;
                this.Action.Clear();
            }
            else
            {
                this.ScriptDelta -= Script.Length;
                this.Script.Clear();
            }
            RefreshScript();
            this.treeView.EndUpdate();
        }

        /// <summary>
        /// Refreshes the script.
        /// </summary>
        public void RefreshScript()
        {
            if (!ActionScript)
                Script.Refresh();
            else
                Action.Refresh();
            Populate();
            //
            if (treeView.Nodes.Count != 0 && SelectedNode != null)
            {
                if (SelectedNode.Parent != null)
                    SelectedNode = treeView.Nodes[SelectedNode.Parent.Index].Nodes[SelectedNode.Index];
                else
                    SelectedNode = treeView.Nodes[SelectedNode.Index];
                treeView.SelectedNode = SelectedNode;
            }
        }
        /// <summary>
        /// Refreshes the script and sets the selected node to the specified (full) index.
        /// </summary>
        /// <param name="selectedIndex">The full index of the node to select.</param>
        public void RefreshScript(int selectedIndex)
        {
            if (!ActionScript)
                Script.Refresh();
            else
                Action.Refresh();
            Populate();
            //
            treeView.SelectNode(selectedIndex);
        }

        /// <summary>
        /// Returns a value indicating whether a specified node is a parent node.
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private bool IsRootNode(TreeNode node)
        {
            if (node == null)
                return false;
            return node.Text.CompareTo(node.FullPath) == 0;
        }

        #endregion
    }
}
