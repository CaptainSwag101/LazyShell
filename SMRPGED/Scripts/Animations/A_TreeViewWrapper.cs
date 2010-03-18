using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SMRPGED.ScriptsEditor.Commands;

namespace SMRPGED.ScriptsEditor
{
    class A_TreeViewWrapper
    {
        TreeView treeView;
        private AnimationScript script; public AnimationScript Script { get { return script; } set { script = value; } }
        private TreeNode selectedNode; public TreeNode SelectedNode { get { return selectedNode; } set { selectedNode = value; } }
        public A_TreeViewWrapper(TreeView control)
        {
            this.treeView = control;
        }
        public void ChangeScript(AnimationScript script)
        {
            this.script = script;
            Populate();
        }
        private void Populate()
        {
            this.treeView.BeginUpdate();

            ArrayList scriptcmds;

            this.treeView.Nodes.Clear();

            scriptcmds = script.Commands;
            for (int i = 0; i < scriptcmds.Count; i++)
                AddAnimationScriptCommand((AnimationScriptCommand)scriptcmds[i]);

            this.treeView.ExpandAll();
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
                    node.BackColor = Color.FromArgb(255, 255, 255, 0); break;

                case 0x09:
                case 0x10:
                case 0x5D:
                case 0x64:
                case 0x68:
                    node.BackColor = Color.FromArgb(255, 128, 160, 255);
                    AddNode(asc, node);
                    break;
                default:
                    if (asc.Opcode >= 0x24 && asc.Opcode <= 0x2B)
                    {
                        node.BackColor = Color.FromArgb(255, 128, 160, 255);
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
                        child.BackColor = Color.FromArgb(255, 255, 255, 0); break;

                    case 0x09:
                    case 0x10:
                    case 0x5D:
                    case 0x64:
                    case 0x68:
                        child.BackColor = Color.FromArgb(255, 128, 160, 255);
                        AddNode(sub, child);
                        break;
                    default:
                        if (sub.Opcode >= 0x24 && sub.Opcode <= 0x2B)
                        {
                            child.BackColor = Color.FromArgb(255, 128, 160, 255);
                            AddNode(sub, child);
                        }
                        break;
                }
            }
        }
    }
}
