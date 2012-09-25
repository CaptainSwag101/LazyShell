using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LAZYSHELL.ScriptsEditor.Commands;

namespace LAZYSHELL.ScriptsEditor
{
    class A_TreeViewWrapper
    {
        NewTreeView treeView;
        private AnimationScript script; public AnimationScript Script { get { return script; } set { script = value; } }
        private TreeNode selectedNode; public TreeNode SelectedNode { get { return selectedNode; } set { selectedNode = value; } }
        public A_TreeViewWrapper(NewTreeView control)
        {
            this.treeView = control;
        }
        public void ChangeScript(AnimationScript script, bool update)
        {
            this.script = script;
            Populate(update);
        }
        public void ChangeScript(AnimationScript script)
        {
            ChangeScript(script, true);
        }
        private void Populate(bool update)
        {
            if (update)
                this.treeView.BeginUpdate();

            ArrayList scriptcmds;

            this.treeView.Nodes.Clear();

            scriptcmds = script.Commands;
            for (int i = 0; i < scriptcmds.Count; i++)
                AddAnimationScriptCommand((AnimationScriptCommand)scriptcmds[i]);

            this.treeView.ExpandAll();
            if (update)
                this.treeView.EndUpdate();
        }
        private void AddAnimationScriptCommand(AnimationScriptCommand asc)
        {
            this.treeView.Nodes.Add("[" + (asc.Offset).ToString("X6") + "]   " + asc.ToString()); // Add command
            TreeNode node = treeView.Nodes[treeView.Nodes.Count - 1];

            node.Tag = asc;

            switch (asc.Opcode)
            {
                case 0x07:
                case 0x11:
                case 0x5E:
                    node.BackColor = Color.FromArgb(255, 255, 255, 160); break;

                case 0x09:
                case 0x10:
                case 0x5D:
                case 0x64:
                case 0x68:
                    node.BackColor = Color.FromArgb(255, 192, 224, 255);
                    AddNode(asc, node);
                    break;
                default:
                    if (asc.Opcode >= 0x24 && asc.Opcode <= 0x2B)
                    {
                        node.BackColor = Color.FromArgb(255, 192, 224, 255);
                        AddNode(asc, node);
                    }
                    break;
            }
            //AddNode(asc, node); // add any multiple child nodes
        }
        private void AddNode(AnimationScriptCommand asc, TreeNode node)
        {
            TreeNode child;
            foreach (AnimationScriptCommand sub in asc.Commands)
            {
                node.Nodes.Add("[" + (sub.Offset).ToString("X6") + "]   " + sub.ToString());
                child = node.Nodes[node.Nodes.Count - 1];

                child.Tag = sub;

                switch (sub.Opcode)
                {
                    case 0x07:
                    case 0x11:
                    case 0x5E:
                        child.BackColor = Color.FromArgb(255, 255, 255, 160); break;

                    case 0x09:
                    case 0x10:
                    case 0x5D:
                    case 0x64:
                    case 0x68:
                        child.BackColor = Color.FromArgb(255, 192, 224, 255);
                        AddNode(sub, child);
                        break;
                    default:
                        if (sub.Opcode >= 0x24 && sub.Opcode <= 0x2B)
                        {
                            child.BackColor = Color.FromArgb(255, 192, 224, 255);
                            AddNode(sub, child);
                        }
                        break;
                }
            }
        }
        public void MoveUp(AnimationScriptCommand asc)
        {
            if (selectedNode.PrevNode == null)
                return;
            if (asc.Opcode == 0x07 ||
                asc.Opcode == 0x11 ||
                asc.Opcode == 0x5E)
                return;
            AnimationScriptCommand prev = (AnimationScriptCommand)selectedNode.PrevNode.Tag;
            if (prev.Opcode == 0x07 ||
                prev.Opcode == 0x11 ||
                prev.Opcode == 0x5E)
                return;
            if (selectedNode.Index == 0)
                return;
            Move((AnimationScriptCommand)selectedNode.PrevNode.Tag, asc, 1, "up");
        }
        public void MoveDown(AnimationScriptCommand asc)
        {
            if (selectedNode.NextNode == null)
                return;
            if (asc.Opcode == 0x07 ||
                asc.Opcode == 0x11 ||
                asc.Opcode == 0x5E)
                return;
            AnimationScriptCommand next = (AnimationScriptCommand)selectedNode.NextNode.Tag;
            if (next.Opcode == 0x07 ||
                next.Opcode == 0x11 ||
                next.Opcode == 0x5E)
                return;
            if (selectedNode.Parent != null)
            {
                if (selectedNode.Index >= selectedNode.Parent.Nodes.Count - 1)
                    return;
            }
            else
            {
                if (selectedNode.Index >= treeView.Nodes.Count - 1)
                    return;
            }
            Move(asc, (AnimationScriptCommand)selectedNode.NextNode.Tag, 0, "down");
        }
        private void Move(AnimationScriptCommand tempA, AnimationScriptCommand tempB, int select, string direction)
        {
            treeView.BeginUpdate();
            treeView.EnablePaint = false;
            Point p = Do.GetTreeViewScrollPos(treeView);

            byte[] byteA = new byte[tempB.AnimationData.Length];
            byte[] byteB = new byte[tempA.AnimationData.Length];
            for (int i = 0; i < byteA.Length; i++)
                byteA[i] = tempB.AnimationData[i];
            for (int i = 0; i < byteB.Length; i++)
                byteB[i] = tempA.AnimationData[i];
            tempA.AnimationData = byteA;
            tempB.AnimationData = byteB;

            int offset = tempA.InternalOffset;
            for (int i = 0; i < byteA.Length; i++, offset++)
                Model.Data[offset] = tempA.AnimationData[i];
            int temp = tempB.InternalOffset;
            tempB.InternalOffset = tempA.InternalOffset;
            tempA.InternalOffset = offset;
            for (int i = 0; i < byteB.Length; i++, offset++)
                Model.Data[offset] = tempB.AnimationData[i];
            tempA.Offset = tempA.OriginalOffset = tempA.InternalOffset;
            tempB.Offset = tempB.OriginalOffset = tempB.InternalOffset;

            // check multiple instances of command in current script, and change each accordingly
            script.RefreshAnimationScript();

            // redraw the treeview
            ChangeScript(script, false);
            treeView.EnablePaint = true;
            treeView.EndUpdate();

            // set the selected node
            int internalOffset = select == 0 ? tempA.InternalOffset : tempB.InternalOffset;
            SetSelectedNode(internalOffset);
            p.X = 0;
            Do.SetTreeViewScrollPos(treeView, p);
        }
        public void ExpandAll()
        {
            this.treeView.ExpandAll();
        }
        public void CollapseAll()
        {
            this.treeView.CollapseAll();
        }
        public void SetSelectedNode(int internalOffset)
        {
            foreach (TreeNode tn in this.treeView.Nodes)
            {
                if (internalOffset == ((AnimationScriptCommand)tn.Tag).InternalOffset)
                {
                    this.treeView.SelectedNode = tn;
                    break;
                }
                else
                    SearchForNodeWithTag(tn, internalOffset);
            }
        }
        private void SearchForNodeWithTag(TreeNode node, int offset)
        {
            foreach (TreeNode tn in node.Nodes)
            {
                if (offset == ((AnimationScriptCommand)tn.Tag).InternalOffset)
                {
                    this.treeView.SelectedNode = tn;
                    break;
                }
                else
                    SearchForNodeWithTag(tn, offset);
            }
        }
    }
}
