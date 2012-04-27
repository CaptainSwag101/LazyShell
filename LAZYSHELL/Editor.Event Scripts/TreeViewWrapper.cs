using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;
using System.Runtime.InteropServices;
using LAZYSHELL.ScriptsEditor.Commands;

namespace LAZYSHELL.ScriptsEditor
{
    public class TreeViewWrapper
    {
        #region Variables
        private TreeView treeView;
        private TreeNode selectedNode; public TreeNode SelectedNode { get { return selectedNode; } set { selectedNode = value; } }
        private TreeNode editedNode; public TreeNode EditedNode { get { return editedNode; } set { editedNode = value; } }
        public byte[] CurrentNodeData
        {
            get
            {
                EventScriptCommand esc;
                ActionQueueCommand aqc;

                TreeNode node = treeView.SelectedNode;
                if (node == null)
                    return new byte[0];
                int index = node.Index;

                if (!IsRootNode(node))  // we are editing an embedded action queue command
                {
                    node = node.Parent;
                }
                else if (actionScript)  // we are editing an action script command
                {
                    aqc = (ActionQueueCommand)action.Commands[index];
                    return aqc.EventData;
                }
                else    // we are editing an event script command
                {
                    esc = (EventScriptCommand)script.Commands[index];
                    return esc.EventData;
                }
                if (!IsRootNode(node))
                    throw new Exception();

                esc = (EventScriptCommand)script.Commands[node.Index];
                aqc = (ActionQueueCommand)esc.EmbeddedActionQueue.Commands[index];
                return aqc.EventData;
            }
        }
        private EventScript script; public EventScript Script { get { return this.script; } set { this.script = value; } }
        private ActionQueue action; public ActionQueue Action { get { return this.action; } set { this.action = value; } }
        private bool actionScript; public bool ActionScript { get { return this.actionScript; } set { this.actionScript = value; } }
        private int scriptDelta = 0; public int ScriptDelta { get { return this.scriptDelta; } set { this.scriptDelta = value; } }
        public int conditionOffset = 0;
        private ArrayList commandCopies;
        // Get / set the scrollbar position of the treeview
        private const int SB_HORZ = 0x0;
        private const int SB_VERT = 0x1;
        [DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        public static extern int GetScrollPos(int hWnd, int nBar);
        [DllImport("user32.dll")]
        static extern int SetScrollPos(IntPtr hWnd, int nBar, int nPos, bool bRedraw);
        #endregion
        // constructor
        public TreeViewWrapper(TreeView control)
        {
            this.treeView = control;
        }
        #region Functions
        public void ChangeScript(EventScript script)
        {
            this.script = script;
            foreach (EventScriptCommand esc in script.Commands)
                esc.ResetOriginalOffset();
            Populate();
        }
        public void ChangeScript(ActionQueue action)
        {
            //this.eventCopies = null;
            this.action = action;
            foreach (ActionQueueCommand aqc in action.Commands)
                aqc.ResetOriginalOffset();
            Populate();
        }
        private void Populate()
        {
            this.treeView.BeginUpdate();

            ArrayList scriptcmds;
            ArrayList actionCmds;

            this.treeView.Nodes.Clear();

            if (!actionScript)
            {
                scriptcmds = script.Commands;
                for (int i = 0; i < scriptcmds.Count; i++)
                    AddEventScriptCommand((EventScriptCommand)scriptcmds[i]);
            }
            else
            {
                actionCmds = action.Commands;
                for (int i = 0; i < actionCmds.Count; i++)
                    AddEventScriptCommand((ActionQueueCommand)actionCmds[i]);
            }

            this.treeView.ExpandAll();
            this.treeView.EndUpdate();
        }
        private void AddEventScriptCommand(EventScriptCommand esc)
        {
            this.treeView.Nodes.Add("[" + (esc.Offset).ToString("X6") + "]   " + esc.ToString()); // Add command

            TreeNode node;
            TreeNode childNode;

            node = treeView.Nodes[treeView.Nodes.Count - 1];
            node.Tag = esc;
            if (node.Checked = esc.Set)
                node.ForeColor = Color.Red;

            if (esc.IsActionQueueTrigger || esc.IsDummy)
            {
                node.BackColor = Color.FromArgb(255, 192, 224, 255);
                if (esc.IsDummy) node.Text = "NON-EMBEDDED ACTION QUEUE";

                if (esc.EmbeddedActionQueue == null) return;

                ArrayList actionQueues = esc.EmbeddedActionQueue.Commands;
                ActionQueueCommand aqc;

                for (int i = 0; actionQueues != null && i < actionQueues.Count; i++)
                {
                    aqc = (ActionQueueCommand)actionQueues[i];
                    node.Nodes.Add("[" + (aqc.Offset).ToString("X6") + "]   " + aqc.ToString());

                    childNode = node.Nodes[node.Nodes.Count - 1];
                    childNode.Tag = aqc;
                    if (childNode.Checked = aqc.Set)
                        childNode.ForeColor = Color.Red;

                    if (aqc.Opcode >= 0xFE)
                        childNode.BackColor = Color.FromArgb(255, 255, 255, 160);
                }
            }
            if (esc.Opcode >= 0xFE)
                node.BackColor = Color.FromArgb(255, 255, 255, 160);
        }
        private void AddEventScriptCommand(ActionQueueCommand aqc)
        {
            this.treeView.Nodes.Add("[" + (aqc.Offset).ToString("X6") + "]   " + aqc.ToString()); // Add command

            TreeNode node;

            node = treeView.Nodes[treeView.Nodes.Count - 1];
            node.Tag = aqc;
            if (node.Checked = aqc.Set)
                node.ForeColor = Color.Red;

            if (aqc.Opcode >= 0xFE)
                node.BackColor = Color.FromArgb(255, 255, 255, 160);
        }
        public void InsertNode(EventScriptCommand esc)
        {
            try
            {
                if (actionScript)
                {
                    foreach (ActionQueueCommand aq in action.Commands)
                        aq.Set = false;
                }
                else
                {
                    foreach (EventScriptCommand es in script.Commands)
                    {
                        es.Set = false;
                        if (es.EmbeddedActionQueue == null) continue;
                        foreach (ActionQueueCommand aq in es.EmbeddedActionQueue.Commands)
                            aq.Set = false;
                    }
                }

                this.treeView.BeginUpdate();
                TreeNode node = treeView.SelectedNode;
                int index;

                // Get index to insert at
                index = node != null ? treeView.SelectedNode.Index + 1 : 0;

                if (node == null || IsRootNode(node)) // EvenScript Command
                {
                    // Insert into treeview
                    if (esc.IsActionQueueTrigger)
                    {
                        selectedNode = new TreeNode("[" + (esc.Offset).ToString("X6") + "]   " + esc.ToString());
                        selectedNode.BackColor = Color.FromArgb(255, 192, 224, 255);
                    }
                    else if (esc.Opcode >= 0xFE)
                    {
                        selectedNode = new TreeNode("[" + (esc.Offset).ToString("X6") + "]   " + esc.ToString());
                        selectedNode.BackColor = Color.FromArgb(255, 255, 255, 160);
                    }
                    else
                        selectedNode = new TreeNode("[" + (esc.Offset).ToString("X6") + "]   " + esc.ToString());

                    this.treeView.Nodes.Insert(index, selectedNode);

                    // Insert into script at same index
                    esc.Set = true;
                    this.script.Insert(index, esc);
                    this.scriptDelta += esc.EventLength;
                }
            }
            finally
            {
                bool isChild = false;
                int parent = 0, child = 0;
                if (this.treeView.Nodes.Count != 0)
                {
                    isChild = treeView.TopNode.Parent != null;
                    parent = isChild ? treeView.TopNode.Parent.Index : treeView.TopNode.Index;
                    child = isChild ? treeView.TopNode.Index : 0;
                }

                RefreshScript(); // Update offsets and descriptions
                this.conditionOffset = esc.Offset;

                this.treeView.EndUpdate();

                if (this.treeView.Nodes.Count != 0)
                    treeView.TopNode = isChild ? this.treeView.Nodes[parent].Nodes[child] : this.treeView.Nodes[parent];
            }
        }
        public void InsertNode(ActionQueueCommand aqc)
        {
            try
            {
                if (actionScript)
                {
                    foreach (ActionQueueCommand aq in action.Commands)
                        aq.Set = false;
                }
                else
                {
                    foreach (EventScriptCommand es in script.Commands)
                    {
                        es.Set = false;
                        if (es.EmbeddedActionQueue == null) continue;
                        foreach (ActionQueueCommand aq in es.EmbeddedActionQueue.Commands)
                            aq.Set = false;
                    }
                }

                this.treeView.BeginUpdate();
                int index;

                TreeNode node = treeView.SelectedNode;
                EventScriptCommand esc;

                // Insert embedded action queue command
                if (!actionScript)
                {
                    if (node == null)
                        return;

                    // Get index to insert at
                    index = treeView.SelectedNode.Index + 1;

                    if (node == null)
                        return;
                    if (node.Parent == null)
                    {
                        if (((EventScriptCommand)script.Commands[treeView.SelectedNode.Index]).IsActionQueueTrigger)
                            index = 0;
                        else
                        {
                            MessageBox.Show(
                                "Cannot insert an action queue command outside of an action queue.",
                                "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                    else
                        node = node.Parent;

                    // Increase queue length option byte
                    int bit7;   // if bit7 set, then max lenght is 111, else 127
                    esc = ((EventScriptCommand)script.Commands[node.Index]);
                    if (esc.Option < 0xF0)
                    {
                        if ((esc.Option & 0x80) == 0x80) bit7 = 111;
                        else bit7 = 127;

                        if ((esc.EventLength - 2 + aqc.QueueLength) > bit7)
                        {
                            MessageBox.Show(
                                "Could not add any more action queue commands to the queue trigger.",
                                "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        esc.Option += (byte)aqc.QueueLength;
                    }
                    else
                    {
                        if ((esc.EventData[2] & 0x80) == 0x80) bit7 = 111;
                        else bit7 = 127;

                        if ((esc.EventLength - 3 + aqc.QueueLength) > bit7)
                        {
                            MessageBox.Show(
                                "Could not add any more action queue commands to the queue trigger.",
                                "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        esc.EventData[2] += (byte)aqc.QueueLength;
                    }

                    // Insert into treeview
                    if (aqc.Opcode >= 0xFE)
                    {
                        selectedNode = new TreeNode("[" + (aqc.Offset).ToString("X6") + "]   " + aqc.ToString());
                        selectedNode.BackColor = Color.FromArgb(255, 255, 255, 160);
                    }
                    else
                        selectedNode = new TreeNode("[" + (aqc.Offset).ToString("X6") + "]   " + aqc.ToString());

                    node.Nodes.Insert(index, selectedNode);

                    // Insert into action queue at same index
                    aqc.Set = true;
                    this.script.Insert(node.Index, index, aqc);
                    this.scriptDelta += aqc.QueueLength;

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

                    if (node == null || IsRootNode(node)) // ActionScript Command
                    {
                        // Insert into treeview
                        if (aqc.Opcode >= 0xFE)
                        {
                            selectedNode = new TreeNode("[" + (aqc.Offset).ToString("X6") + "]   " + aqc.ToString());
                            selectedNode.BackColor = Color.FromArgb(255, 255, 255, 160);
                        }
                        else
                            selectedNode = new TreeNode("[" + (aqc.Offset).ToString("X6") + "]   " + aqc.ToString());

                        treeView.Nodes.Insert(index, selectedNode);

                        // Insert into script at same index
                        aqc.Set = true;
                        this.action.Insert(index, aqc);
                        this.scriptDelta += aqc.QueueLength;
                    }
                }
            }
            finally
            {
                bool isChild = false;
                int parent = 0, child = 0;
                if (this.treeView.Nodes.Count != 0)
                {
                    isChild = treeView.TopNode.Parent != null;
                    parent = isChild ? treeView.TopNode.Parent.Index : treeView.TopNode.Index;
                    child = isChild ? treeView.TopNode.Index : 0;
                }

                RefreshScript(); // Update offsets and descriptions
                this.conditionOffset = aqc.Offset;

                this.treeView.EndUpdate();

                if (this.treeView.Nodes.Count != 0)
                    treeView.TopNode = isChild ? this.treeView.Nodes[parent].Nodes[child] : this.treeView.Nodes[parent];
            }
        }
        public void ReplaceNode(EventScriptCommand esc)
        {
            try
            {
                this.treeView.BeginUpdate();

                TreeNode node = editedNode;
                // Get index to insert at
                if (node == null)
                    return;
                int index = editedNode.Index;

                selectedNode = new TreeNode(esc.ToString());

                if (IsRootNode(node)) // EvenScript Command
                {
                    // Insert into treeview
                    this.treeView.Nodes.RemoveAt(index); // Adjust for remove
                    this.treeView.Nodes.Insert(index, esc.ToString());
                    // Insert into script at same index
                    this.script.RemoveAt(index);
                    this.script.Insert(index, esc);
                    treeView.SelectedNode = this.treeView.Nodes[index];
                }
            }
            finally
            {
                bool isChild = false;
                int parent = 0, child = 0;
                if (this.treeView.Nodes.Count != 0)
                {
                    isChild = treeView.TopNode.Parent != null;
                    parent = isChild ? treeView.TopNode.Parent.Index : treeView.TopNode.Index;
                    child = isChild ? treeView.TopNode.Index : 0;
                }

                RefreshScript(); // Update offsets and descriptions

                this.treeView.EndUpdate();

                if (this.treeView.Nodes.Count != 0)
                    treeView.TopNode = isChild ? this.treeView.Nodes[parent].Nodes[child] : this.treeView.Nodes[parent];
            }
        }
        public void ReplaceNode(ActionQueueCommand aqc)
        {
            try
            {
                this.treeView.BeginUpdate();

                TreeNode node = editedNode;
                if (node == null)
                    return;
                // Get index to insert at
                int index = editedNode.Index;

                selectedNode = new TreeNode(aqc.ToString());

                if (!actionScript)
                {
                    if (IsRootNode(node))
                        return;
                    node = node.Parent;
                    if (IsRootNode(node))
                    {
                        // Insert into treeview
                        node.Nodes.RemoveAt(index);
                        node.Nodes.Insert(index, aqc.ToString());
                        // Insert into action queue at same index
                        this.script.RemoveAt(node.Index, index);
                        this.script.Insert(node.Index, index, aqc);
                        treeView.SelectedNode = node.Nodes[index];
                    }
                }
                else
                {
                    if (IsRootNode(node)) // ActionScript Command
                    {
                        // Insert into treeview
                        this.treeView.Nodes.RemoveAt(index); // Adjust for remove
                        this.treeView.Nodes.Insert(index, aqc.ToString());
                        // Insert into script at same index
                        this.action.RemoveAt(node.Index);
                        this.action.Insert(index, aqc);
                        treeView.SelectedNode = this.treeView.Nodes[index];
                    }
                }
            }
            finally
            {
                bool isChild = false;
                int parent = 0, child = 0;
                if (this.treeView.Nodes.Count != 0)
                {
                    isChild = treeView.TopNode.Parent != null;
                    parent = isChild ? treeView.TopNode.Parent.Index : treeView.TopNode.Index;
                    child = isChild ? treeView.TopNode.Index : 0;
                }

                RefreshScript(); // Update offsets and descriptions

                this.treeView.EndUpdate();

                if (this.treeView.Nodes.Count != 0)
                    treeView.TopNode = isChild ? this.treeView.Nodes[parent].Nodes[child] : this.treeView.Nodes[parent];
            }
        }
        public void RemoveNode()
        {
            try
            {
                EventScriptCommand esc;
                ActionQueueCommand aqc;

                this.treeView.BeginUpdate();
                int delta, index;
                TreeNode node;

                TreeNode tn, child;
                for (int i = treeView.Nodes.Count - 1; i >= 0; i--)
                {
                    tn = treeView.Nodes[i];

                    for (int a = tn.Nodes.Count - 1; a >= 0; a--)
                    {
                        child = tn.Nodes[a];

                        if (!child.Checked) continue;

                        this.treeView.SelectedNode = child;
                        delta = CurrentNodeData.Length * -1;

                        node = this.treeView.SelectedNode;
                        if (node == null)
                            return;
                        index = this.treeView.SelectedNode.Index;

                        node = node.Parent;

                        // Decrease queue length option byte
                        esc = ((EventScriptCommand)script.Commands[node.Index]);
                        aqc = (ActionQueueCommand)esc.EmbeddedActionQueue.Commands[index];
                        if (esc.Option < 0xF0)
                            esc.Option -= (byte)aqc.QueueLength;
                        else
                            esc.EventData[2] -= (byte)aqc.QueueLength;

                        // Remove action command
                        child.Remove();
                        this.script.RemoveAt(tn.Index, child.Index);

                        this.scriptDelta += delta;
                    }
                    if (!tn.Checked) continue;

                    this.treeView.SelectedNode = tn;
                    delta = CurrentNodeData.Length * -1;

                    node = this.treeView.SelectedNode;
                    if (node == null)
                        return;
                    index = this.treeView.SelectedNode.Index;

                    tn.Remove();
                    if (!actionScript)
                        this.script.RemoveAt(tn.Index);
                    else
                        this.action.RemoveAt(tn.Index);
                    this.scriptDelta += delta;
                }
            }
            finally
            {
                bool isChild = false;
                int parent = 0, child = 0;
                if (this.treeView.Nodes.Count != 0)
                {
                    isChild = treeView.TopNode.Parent != null;
                    parent = isChild ? treeView.TopNode.Parent.Index : treeView.TopNode.Index;
                    child = isChild ? treeView.TopNode.Index : 0;
                }

                RefreshScript(); // Update offsets and descriptions

                this.treeView.EndUpdate();

                if (this.treeView.Nodes.Count != 0)
                    treeView.TopNode = isChild ? this.treeView.Nodes[parent].Nodes[child] : this.treeView.Nodes[parent];
            }
        }
        public void MoveUp()
        {
            try
            {
                this.treeView.BeginUpdate();

                int index1, index2;

                foreach (TreeNode tn in treeView.Nodes)
                {
                    foreach (TreeNode child in tn.Nodes)
                    {
                        if (!child.Checked) continue;
                        if (child.Index == 0) break;

                        treeView.SelectedNode = child;

                        if (treeView.SelectedNode == null)
                            return;
                        index1 = treeView.SelectedNode.Index;

                        if (treeView.SelectedNode.PrevNode == null)
                            return;
                        index2 = treeView.SelectedNode.PrevNode.Index;

                        Move(index1, index2);
                    }

                    if (!tn.Checked) continue;
                    if (tn.Index == 0) break;

                    treeView.SelectedNode = tn;

                    if (treeView.SelectedNode == null)
                        return;
                    index1 = treeView.SelectedNode.Index;

                    if (treeView.SelectedNode.PrevNode == null)
                        return;
                    index2 = treeView.SelectedNode.PrevNode.Index;

                    Move(index1, index2);
                }
            }
            finally
            {
                bool isChild = false;
                int parent = 0, child = 0;
                if (this.treeView.Nodes.Count != 0)
                {
                    isChild = treeView.TopNode.Parent != null;
                    parent = isChild ? treeView.TopNode.Parent.Index : treeView.TopNode.Index;
                    child = isChild ? treeView.TopNode.Index : 0;
                }

                RefreshScript(); // Update offsets and descriptions

                this.treeView.EndUpdate();

                if (this.treeView.Nodes.Count != 0)
                {
                    if (isChild && treeView.Nodes[parent].Nodes.Count != 0)
                        treeView.TopNode = this.treeView.Nodes[parent].Nodes[child];
                    else
                        treeView.TopNode = this.treeView.Nodes[parent];
                }
            }
        }
        public void MoveDown()
        {
            try
            {
                this.treeView.BeginUpdate();
                int index1, index2;
                TreeNode tn, child;
                for (int i = treeView.Nodes.Count - 1; i >= 0; i--)
                {
                    tn = treeView.Nodes[i];
                    for (int a = tn.Nodes.Count - 1; a >= 0; a--)
                    {
                        child = tn.Nodes[a];
                        if (!child.Checked) continue;
                        if (child.Index == tn.Nodes.Count - 1) break;
                        treeView.SelectedNode = child;
                        if (treeView.SelectedNode == null)
                            return;
                        index1 = treeView.SelectedNode.Index;
                        if (treeView.SelectedNode.NextNode == null)
                            return;
                        index2 = treeView.SelectedNode.NextNode.Index;
                        Move(index1, index2);
                    }
                    //
                    if (!tn.Checked) continue;
                    if (tn.Index == treeView.Nodes.Count - 1) break;
                    treeView.SelectedNode = tn;
                    if (treeView.SelectedNode == null)
                        return;
                    index1 = treeView.SelectedNode.Index;
                    if (treeView.SelectedNode.NextNode == null)
                        return;
                    index2 = treeView.SelectedNode.NextNode.Index;
                    Move(index1, index2);
                }
            }
            finally
            {
                bool isChild = false;
                int parent = 0, child = 0;
                if (this.treeView.Nodes.Count != 0)
                {
                    isChild = treeView.TopNode.Parent != null;
                    parent = isChild ? treeView.TopNode.Parent.Index : treeView.TopNode.Index;
                    child = isChild ? treeView.TopNode.Index : 0;
                }
                // Update offsets and descriptions
                RefreshScript(); 
                this.treeView.EndUpdate();
                if (this.treeView.Nodes.Count != 0)
                {
                    if (isChild && treeView.Nodes[parent].Nodes.Count != 0)
                        treeView.TopNode = this.treeView.Nodes[parent].Nodes[child];
                    else
                        treeView.TopNode = this.treeView.Nodes[parent];
                }
            }
        }
        public void SelectNode(EventActionCommand eac)
        {
            if (eac != null)
            {
                foreach (TreeNode node in treeView.Nodes)
                {
                    if (node.Tag == eac)
                    {
                        treeView.SelectedNode = node;
                        return;
                    }
                    foreach (TreeNode child in node.Nodes)
                    {
                        if (child.Tag == eac)
                        {
                            treeView.SelectedNode = child;
                            return;
                        }
                    }
                }
            }
        }
        private void Move(int index1, int index2)
        {
            if (IsRootNode(treeView.SelectedNode))
            {
                if (!actionScript) script.Swap(index1, index2);
                else action.Swap(index1, index2);

                selectedNode = treeView.Nodes[index2];
            }
            else
            {
                int parent = treeView.SelectedNode.Parent.Index;

                EventScriptCommand esc = (EventScriptCommand)script.Commands[parent];
                esc.EmbeddedActionQueue.Swap(index1, index2);

                selectedNode = treeView.Nodes[parent].Nodes[index2];
            }
        }
        private bool IsRootNode(TreeNode node)
        {
            if (node == null)
                return false;
            return node.Text.CompareTo(node.FullPath) == 0;
        }
        public void ExpandAll()
        {
            this.treeView.ExpandAll();
        }
        public void CollapseAll()
        {
            this.treeView.CollapseAll();
        }
        public void ClearAll()
        {
            this.script.Assemble();

            this.treeView.BeginUpdate();

            if (actionScript)
            {
                this.scriptDelta -= action.ActionQueueLength;
                this.action.Clear();
            }
            else
            {
                this.scriptDelta -= script.ScriptLength;
                this.script.Clear();
            }

            RefreshScript();
            this.treeView.EndUpdate();
        }
        public void Copy()
        {
            try
            {
                this.treeView.BeginUpdate();

                EventScriptCommand esc, escCopy;
                ActionQueueCommand aqc, aqcCopy;

                TreeNode node = this.treeView.SelectedNode;
                if (node == null)
                    return;
                int index = this.treeView.SelectedNode.Index;

                byte[] temp;
                bool tnChecked = false, childChecked = false;
                commandCopies = new ArrayList();
                foreach (TreeNode tn in treeView.Nodes)
                {
                    foreach (TreeNode child in tn.Nodes)
                    {
                        if (!child.Checked) continue;

                        childChecked = true;

                        if (tnChecked)
                        {
                            MessageBox.Show(
                                "Cannot create a copy buffer that contains both event and action\n" +
                                "commands. Please uncheck all action OR event commands.",
                                "LAZY SHELL");
                            commandCopies = null;
                            return;
                        }

                        aqc = (ActionQueueCommand)child.Tag; aqc.Assemble();
                        temp = new byte[aqc.EventData.Length]; aqc.EventData.CopyTo(temp, 0);
                        aqcCopy = new ActionQueueCommand(temp, aqc.Offset);
                        commandCopies.Add(aqcCopy);
                    }
                    if (!tn.Checked) continue;

                    tnChecked = true;

                    if (childChecked)
                    {
                        MessageBox.Show(
                            "Cannot create a copy buffer that contains both event and action\n" +
                            "commands. Please uncheck all action OR event commands.",
                            "LAZY SHELL");
                        commandCopies = null;
                        return;
                    }

                    if (!actionScript)
                    {
                        esc = (EventScriptCommand)tn.Tag; esc.Assemble();
                        temp = new byte[esc.EventData.Length]; esc.EventData.CopyTo(temp, 0);
                        escCopy = new EventScriptCommand(temp, esc.Offset);
                        commandCopies.Add(escCopy);
                    }
                    else
                    {
                        aqc = (ActionQueueCommand)tn.Tag; aqc.Assemble();
                        temp = new byte[aqc.EventData.Length]; aqc.EventData.CopyTo(temp, 0);
                        aqcCopy = new ActionQueueCommand(temp, aqc.Offset);
                        commandCopies.Add(aqcCopy);
                    }
                }
            }
            finally
            {
                this.treeView.Select();
                this.treeView.EndUpdate();
            }
        }
        public void Paste()
        {
            foreach (TreeNode tn in treeView.Nodes)
            {
                tn.Checked = false;
                foreach (TreeNode child in tn.Nodes)
                    child.Checked = false;
            }

            byte[] commandData;
            int offset;
            TreeNode temp = treeView.SelectedNode;
            // pasting event command in event script
            if (commandCopies != null && !actionScript && (treeView.SelectedNode == null || IsRootNode(treeView.SelectedNode)))
            {
                try
                {
                    foreach (EventScriptCommand escCopy in commandCopies)
                    {
                        commandData = new byte[escCopy.EventData.Length];
                        escCopy.EventData.CopyTo(commandData, 0); offset = escCopy.Offset;
                        InsertNode(new EventScriptCommand(commandData, offset));
                        treeView.SelectedNode = temp;
                    }
                }
                catch
                {
                    if (treeView.SelectedNode != null && treeView.SelectedNode.BackColor == Color.FromArgb(255, 192, 224, 255))
                    {
                        foreach (ActionQueueCommand aqcCopy in commandCopies)
                        {
                            commandData = new byte[aqcCopy.EventData.Length];
                            aqcCopy.EventData.CopyTo(commandData, 0); offset = aqcCopy.Offset;
                            InsertNode(new ActionQueueCommand(commandData, offset));
                            treeView.SelectedNode = temp;
                        }
                    }
                    else
                    {
                        MessageBox.Show(
                            "You cannot paste action queue commands outside of an action queue.",
                            "LAZY SHELL");
                        return;
                    }
                }
            }
            // pasting action command in event script
            else if (commandCopies != null)
            {
                try
                {
                    foreach (ActionQueueCommand aqcCopy in commandCopies)
                    {
                        commandData = new byte[aqcCopy.EventData.Length];
                        aqcCopy.EventData.CopyTo(commandData, 0); offset = aqcCopy.Offset;
                        InsertNode(new ActionQueueCommand(commandData, offset));
                        treeView.SelectedNode = temp;
                    }
                }
                catch
                {
                    MessageBox.Show(
                        "You cannot paste event commands inside of an action queue.",
                        "LAZY SHELL");
                    return;
                }
            }

            this.treeView.Select();
        }
        //
        public void RefreshScript()
        {
            Point p = GetTreeViewScrollPos(treeView);
            RefreshOffsets();
            UpdateInternalPointers();
            Populate();
            //
            if (treeView.Nodes.Count != 0 && selectedNode != null)
            {
                if (selectedNode.Parent != null)
                    selectedNode = treeView.Nodes[selectedNode.Parent.Index].Nodes[selectedNode.Index];
                else
                    selectedNode = treeView.Nodes[selectedNode.Index];

                treeView.SelectedNode = selectedNode;
            }
            p.X = 0;
            SetTreeViewScrollPos(treeView, p);
        }
        private void RefreshOffsets()
        {
            int offset = actionScript ? action.Offset : script.BaseOffset;

            if (!actionScript)
            {
                foreach (EventScriptCommand esc in script.Commands)
                {
                    esc.RefreshOffsets(offset);
                    offset += esc.EventLength;
                }
            }
            else
            {
                foreach (ActionQueueCommand aqc in action.Commands)
                {
                    aqc.Offset = offset;
                    offset += aqc.QueueLength;
                }
            }
        }
        private void UpdateInternalPointers()
        {
            ScriptIterator it;
            EventActionCommand eac;
            if (actionScript)
                it = new ScriptIterator(action);
            else
                it = new ScriptIterator(script);
            while (!it.IsDone)
            {
                eac = it.Next();
                eac.PointerChangedA = false;
                eac.PointerChangedB = false;
            }
            if (actionScript)
                it = new ScriptIterator(action);
            else
                it = new ScriptIterator(script);
            while (!it.IsDone)
            {
                eac = it.Next();
                if (State.Instance.AutoPointerUpdate)
                    UpdatePointersToCommand(eac);
                eac.InternalOffset = eac.Offset;
            }
        }
        private void UpdatePointersToCommand(EventActionCommand referencedCommand)
        {
            ushort pointer;
            ScriptIterator it;
            EventActionCommand eac;
            if (actionScript)
                it = new ScriptIterator(action);
            else
                it = new ScriptIterator(script);
            while (!it.IsDone)
            {
                eac = it.Next();
                if (eac.Opcode == 0x42 || eac.Opcode == 0x67 || eac.Opcode == 0xE9)
                {
                    if (eac.GetType() == typeof(EventScriptCommand) || eac.Opcode == 0xE9)
                    {
                        pointer = eac.ReadPointerSpecial(0);
                        if (pointer == (referencedCommand.InternalOffset & 0xFFFF) && !eac.PointerChangedA)
                        {
                            eac.WritePointerSpecial(0, (ushort)(referencedCommand.Offset & 0xFFFF));
                            eac.PointerChangedA = true;
                        }
                        pointer = eac.ReadPointerSpecial(1);
                        if (pointer == (referencedCommand.InternalOffset & 0xFFFF) && !eac.PointerChangedB)
                        {
                            eac.WritePointerSpecial(1, (ushort)(referencedCommand.Offset & 0xFFFF));
                            eac.PointerChangedB = true;
                        }
                    }
                    else
                    {
                        pointer = eac.ReadPointer();
                        if (pointer == (referencedCommand.InternalOffset & 0xFFFF) && !eac.PointerChangedA)
                        {
                            eac.WritePointer((ushort)(referencedCommand.Offset & 0xFFFF));
                            eac.PointerChangedA = true;
                        }
                    }
                }
                else
                {
                    pointer = eac.ReadPointer();
                    if (pointer == (referencedCommand.InternalOffset & 0xFFFF) && !eac.PointerChangedA)
                    {
                        eac.WritePointer((ushort)(referencedCommand.Offset & 0xFFFF));
                        eac.PointerChangedA = true;
                    }
                }
            }
        }
        //
        private Point GetTreeViewScrollPos(TreeView treeView)
        {
            return new Point(
                GetScrollPos((int)treeView.Handle, SB_HORZ),
                GetScrollPos((int)treeView.Handle, SB_VERT));
        }
        private void SetTreeViewScrollPos(TreeView treeView, Point scrollPosition)
        {
            SetScrollPos((IntPtr)treeView.Handle, SB_HORZ, scrollPosition.X, true);
            SetScrollPos((IntPtr)treeView.Handle, SB_VERT, scrollPosition.Y, true);
        }
        #endregion
    }
}
