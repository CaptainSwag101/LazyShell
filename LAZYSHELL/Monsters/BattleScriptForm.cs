using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using LazyShell.Properties;
using LazyShell.EventScripts;
using LazyShell.Undo;
//

namespace LazyShell.Monsters
{
    public partial class BattleScriptForm : Controls.DockForm
    {
        #region Variables
        
        private OwnerForm ownerForm;

        // Index
        public int index
        {
            get { return ownerForm.Index; }
            set { ownerForm.Index = value; }
        }
        
        // Elements
        public BattleScript[] battleScripts
        {
            get { return Model.BattleScripts; }
            set { Model.BattleScripts = value; }
        }
        private BattleScript battleScript
        {
            get { return battleScripts[index]; }
            set { battleScripts[index] = value; }
        }
        public BattleScript BattleScript
        {
            get { return battleScript; }
            set { battleScript = value; }
        }
        private Monster[] monsters
        {
            get { return Model.Monsters; }
            set { Model.Monsters = value; }
        }
        private Monster monster
        {
            get { return monsters[index]; }
            set { monsters[index] = value; }
        }

        // Commands
        private Command command;
        private List<Command> commandCopies;
        private UndoStack commandStack;
        private TreeNode modifiedNode;

        #endregion

        // Constructor
        public BattleScriptForm(OwnerForm ownerForm)
        {
            this.ownerForm = ownerForm;
            InitializeVariables();
            InitializeComponent();
            InitializeControls();
        }

        #region Methods

        private void InitializeVariables()
        {
            this.commandStack = new UndoStack();
        }
        public void InitializeControls()
        {
            Cursor.Current = Cursors.WaitCursor;
            LoadScript();
            UpdateFreeBytesLabel();
            Cursor.Current = Cursors.Arrow;
        }
        public void LoadScript()
        {
            LoadScript(-1);
        }
        public void LoadScript(int selectedIndex)
        {
            var buffer = new List<byte>();

            foreach (var bsc in battleScript.Commands)
                buffer.AddRange(bsc.Data);

            battleScript.Buffer = buffer.ToArray();

            // Begin building TreeView nodes
            commandTree.BeginUpdate();
            commandTree.Nodes.Clear();
            TreeNode parent = null;
            TreeNode firstCounter = null;
            bool startCounter = false;
            foreach (var bsc in battleScript.Commands)
            {
                if (bsc.Opcode == 0xFF)
                    parent = null;
                var node = bsc.Node;
                if (parent == null)
                    commandTree.Nodes.Add(node);
                else
                    parent.Nodes.Add(node);
                if (bsc.Opcode == 0xFC) // add child nodes
                    parent = node;
                else if (bsc.Opcode == 0xFF && !startCounter)
                {
                    parent = node;
                    firstCounter = node;
                    startCounter = true;
                }
                else if (bsc.Opcode == 0xFE) // end all if hierarchies
                    parent = startCounter ? firstCounter : null;
            }
            commandTree.ExpandAll();
            if (selectedIndex >= 0 && selectedIndex < commandTree.GetNodeCount(true))
                commandTree.SelectNode(selectedIndex);
            commandTree.EndUpdate();
            //
            UpdateFreeBytesLabel();
        }

        // Commands
        private void AddCommand(Command bsc)
        {
            foreach (var command in battleScript.Commands)
                command.Modified = false;
            //
            commandTree.ExpandAll();
            int fullIndex = commandTree.GetFullIndex();
            if (fullIndex < 0)
            {
                MessageBox.Show("Must select a command in the command tree on the left before inserting a new command.",
                    "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (fullIndex + 1 < this.commandTree.GetNodeCount(true))
                battleScript.Insert(++fullIndex, bsc);
            else if (fullIndex + 1 == this.commandTree.GetNodeCount(true))
                battleScript.Insert(fullIndex, bsc);
            else
                battleScript.Insert(0, bsc);
            bsc.Modified = true;
            //
            LoadScript(fullIndex);
        }
        private void ReplaceCommand(Command bsc)
        {
            foreach (var command in battleScript.Commands)
                command.Modified = false;
            bsc = (Command)modifiedNode.Tag;
            bsc.Modified = true;
            //
            LoadScript(commandTree.GetFullIndex());
        }
        private void Remove()
        {
            for (int i = battleScript.Commands.Count - 1; i >= 0; i--)
            {
                TreeNode node = commandTree.GetNode(i);
                if (node.Checked)
                    battleScript.RemoveAt(i);
            }
        }
        private void RemoveAll()
        {
            battleScript.Clear();
            //
            LoadScript();
        }
        private void MoveUp()
        {
            for (int i = 0; i < battleScript.Commands.Count; i++)
            {
                TreeNode node = commandTree.GetNode(i);
                if (node.Checked)
                    battleScript.Reverse(i - 1, 2);
            }
        }
        private void MoveDown()
        {
            if (battleScript.Commands.Count <= 0)
                return;
            for (int i = battleScript.Commands.Count - 1; i >= 0; i--)
            {
                TreeNode node = commandTree.GetNode(i);
                if (node.Checked)
                    battleScript.Reverse(i, 2);
            }
        }
        private void CopyCommands(TreeNodeCollection nodes)
        {
            foreach (TreeNode node in nodes)
            {
                if (node.Checked)
                {
                    Command bsc = (Command)node.Tag;
                    commandCopies.Add(bsc.Copy());
                }
                CopyCommands(node.Nodes);
            }
        }
        public void PushCommand(byte[] oldScript)
        {
            commandStack.Push(new CommandEdit(battleScripts, index, oldScript, this, commandTree.GetFullIndex()));
        }

        // Free bytes
        private void UpdateFreeBytesLabel()
        {
            int freeBytes = Model.FreeBattlescriptSpace();
            this.bytesLeft.Text = " " + freeBytes.ToString() + " bytes left";
            this.bytesLeft.BackColor = freeBytes < 0 ? Color.Red : SystemColors.Control;
        }
        
        // Data management
        public void Import()
        {
            byte[] oldScript = Bits.Copy(battleScript.Buffer);
            //
            new IOElements(Model.BattleScripts, IOMode.Import, index, "IMPORT BATTLE SCRIPTS...").ShowDialog();
            InitializeControls();
            //
            if (!Bits.Compare(oldScript, battleScript.Buffer))
                PushCommand(oldScript);
        }
        public void Export()
        {
            new IOElements(Model.BattleScripts, IOMode.Export, index, "EXPORT BATTLE SCRIPTS...").ShowDialog();
            InitializeControls();
        }
        public void Clear()
        {
            byte[] oldScript = Bits.Copy(battleScript.Buffer);
            //
            new ClearElements(Model.BattleScripts, index, "CLEAR BATTLE SCRIPTS...").ShowDialog();
            InitializeControls();
            //
            if (!Bits.Compare(oldScript, battleScript.Buffer))
                PushCommand(oldScript);
        }

        // Saving
        public void WriteToROM()
        {
            if (Model.FreeBattlescriptSpace() >= 0)
            {
                // Assemble BattleScript Data
                int i = 0;
                int pointerTable = 0x3930AA;
                // Block 1
                int offset = 0x3932AA;
                for (; i < battleScripts.Length && offset + battleScripts[i].Length <= 0x3959F3; i++)
                {
                    Bits.SetShort(Model.ROM, pointerTable + (i * 2), offset & 0xFFFF);
                    battleScripts[i].WriteToROM(ref offset);
                }
                // Block 2
                offset = 0x39F400;
                for (; i < battleScripts.Length && offset + battleScripts[i].Length <= 0x39FFFF; i++)
                {
                    Bits.SetShort(Model.ROM, pointerTable + (i * 2), offset & 0xFFFF);
                    battleScripts[i].WriteToROM(ref offset);
                }
                if (i != battleScripts.Length)
                    MessageBox.Show("Not enough space to save all battlescripts.",
                        "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
                MessageBox.Show("There is not enough available space to save the battle scripts to. The battle scripts were not saved.", 
                    "LAZY SHELL");
        }
        public void DumpScriptText()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.FileName = LazyShell.Model.GetFileNameWithoutPath() + " - battleScripts.txt";
            saveFileDialog.RestoreDirectory = true;
            if (saveFileDialog.ShowDialog() != DialogResult.OK)
                return;
            //
            var writer = File.CreateText(saveFileDialog.FileName);
            foreach (var script in battleScripts)
            {
                int level = 0;
                bool startCounter = false;
                string name = Model.Names.NumerizeUnsorted(script.Index, Lists.KeystrokesMenu);
                writer.WriteLine(name + "------------------------------------------------------------>");
                writer.WriteLine();
                foreach (Command bsc in script.Commands)
                {
                    if (bsc.Opcode == 0xFF)
                        level = 0;
                    string padding = "".PadLeft(level * 3);
                    writer.WriteLine(padding + bsc.ToString());
                    if (bsc.Opcode == 0xFC)
                        level++;
                    if (bsc.Opcode == 0xFF && !startCounter)
                    {
                        level++;
                        startCounter = true;
                    }
                    if (bsc.Opcode == 0xFE)
                        level = startCounter ? 1 : 0;
                }
                writer.WriteLine();
                writer.WriteLine();
            }
            writer.Close();
        }

        #endregion

        #region Event Handlers

        private void BattleScriptForm_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        // TreeView
        private void commandTree_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Control | Keys.Z: undo.PerformClick(); break;
                case Keys.Control | Keys.Y: redo.PerformClick(); break;
                case Keys.Control | Keys.A: Do.SelectAllNodes(commandTree.Nodes, true); break;
                case Keys.Control | Keys.D: Do.SelectAllNodes(commandTree.Nodes, false); break;
                case Keys.Control | Keys.C: copy.PerformClick(); break;
                case Keys.Control | Keys.V: paste.PerformClick(); break;
                case Keys.Control | Keys.Up:
                case Keys.Shift | Keys.Up:
                    e.SuppressKeyPress = true;
                    moveUp.PerformClick();
                    break;
                case Keys.Control | Keys.Down:
                case Keys.Shift | Keys.Down:
                    e.SuppressKeyPress = true;
                    moveDown.PerformClick();
                    break;
                case Keys.Delete: delete.PerformClick(); break;
            }
        }
        private void commandTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Command bsc = (Command)e.Node.Tag;
            //
            hexText.Text = BitConverter.ToString(bsc.Data);
        }
        private void commandTree_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            edit.PerformClick();
        }
        private void commandTree_AfterCheck(object sender, TreeViewEventArgs e)
        {
            Command bsc = (Command)e.Node.Tag;
            if (bsc.Opcode != 0xFF)
                bsc.Modified = e.Node.Checked;
        }
        private void commandTree_BeforeCheck(object sender, TreeViewCancelEventArgs e)
        {
            Command bsc = (Command)e.Node.Tag;
            if (bsc.Opcode == 0xFF)
            {
                MessageBox.Show(
                    "Cannot check command(s).\n\nThe two counter command barriers cannot be removed, modified, or moved.",
                    "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true;
            }
        }
        private void commandTree_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            commandTree.SelectedNode = e.Node;
            if (e.Button != MouseButtons.Right)
                return;
            goToToolStripMenuItem.Click -= goToDialogue_Click;
            goToToolStripMenuItem.Click -= goToEvent_Click;
            Command temp = (Command)commandTree.SelectedNode.Tag;
            if (temp.Opcode == 0xE3)
            {
                e.Node.ContextMenuStrip = contextMenuStripGoto;
                goToToolStripMenuItem.Text = "Edit dialogue...";
                goToToolStripMenuItem.Click += new EventHandler(goToDialogue_Click);
            }
            else if (temp.Opcode == 0xE5)
            {
                e.Node.ContextMenuStrip = contextMenuStripGoto;
                goToToolStripMenuItem.Text = "Edit event...";
                goToToolStripMenuItem.Click += new EventHandler(goToEvent_Click);
            }
        }

        // ContextMenuStrip
        private void goToDialogue_Click(object sender, EventArgs e)
        {
            if (commandTree.SelectedNode == null)
                return;
            //
            Command temp = (Command)commandTree.SelectedNode.Tag;
            int num = temp.Data[1];
            //
            if (LazyShell.Model.Program.Dialogues == null || !LazyShell.Model.Program.Dialogues.Visible)
                LazyShell.Model.Program.CreateDialoguesWindow();
            //
            LazyShell.Model.Program.Dialogues.BattleDialoguesForm.Index = num;
            LazyShell.Model.Program.Dialogues.BringToFront();
        }
        private void goToEvent_Click(object sender, EventArgs e)
        {
            if (commandTree.SelectedNode == null)
                return;
            //
            Command temp = (Command)commandTree.SelectedNode.Tag;
            int num = temp.Data[1];
            //
            if (LazyShell.Model.Program.Animations == null || !LazyShell.Model.Program.Animations.Visible)
                LazyShell.Model.Program.CreateAnimationsWindow();
            //
            LazyShell.Model.Program.Animations.CurrentSet = Animations.Set.BattleEvent;
            LazyShell.Model.Program.Animations.Index = num;
            LazyShell.Model.Program.Animations.BringToFront();
        }

        // Edit command
        private void copy_Click(object sender, EventArgs e)
        {
            commandCopies = new List<Command>();
            commandTree.ExpandAll();
            CopyCommands(commandTree.Nodes);
        }
        private void paste_Click(object sender, EventArgs e)
        {
            byte[] oldScript = Bits.Copy(battleScript.Buffer);
            //
            if (commandCopies == null)
                return;
            foreach (Command bsc in commandCopies)
                AddCommand(bsc.Copy());
            //
            LoadScript(commandTree.GetFullIndex() + 1);
            //
            PushCommand(oldScript);
        }
        private void delete_Click(object sender, EventArgs e)
        {
            byte[] oldScript = Bits.Copy(battleScript.Buffer);
            //
            Remove();
            LoadScript(commandTree.GetFullIndex());
            //
            PushCommand(oldScript);
        }
        private void insert_Click(object sender, EventArgs e)
        {
            // load the command form to specify the new command's settings
            var commandForm = new CommandForm();
            var result = commandForm.ShowDialog(this);
            if (result != DialogResult.OK)
                return;
            var command = (Command)commandForm.Tag;
            // insert the command into the collection and TreeView
            byte[] oldScript = Bits.Copy(battleScript.Buffer);
            AddCommand(command);
            // update info text for controls
            UpdateFreeBytesLabel();
            //
            if (modifiedNode != null)
                modifiedNode = commandTree.SelectedNode;
            //
            PushCommand(oldScript);
        }
        private void moveUp_Click(object sender, EventArgs e)
        {
            byte[] oldScript = Bits.Copy(battleScript.Buffer);
            //
            if (battleScript.Commands.Count < 3)
                return;
            if (battleScript.Commands[0].Modified)
                return;
            MoveUp();
            LoadScript(commandTree.GetFullIndex() - 1);
            //
            PushCommand(oldScript);
        }
        private void moveDown_Click(object sender, EventArgs e)
        {
            byte[] oldScript = Bits.Copy(battleScript.Buffer);
            //
            if (battleScript.Commands.Count < 3)
                return;
            if (battleScript.Commands[battleScript.Commands.Count - 2].Modified)
                return;
            MoveDown();
            LoadScript(commandTree.GetFullIndex() + 1);
            //
            PushCommand(oldScript);
        }
        private void edit_Click(object sender, EventArgs e)
        {
            if (commandTree.SelectedNode == null)
                return;
            // get the command from the treeview's selected node
            this.command = (Command)commandTree.SelectedNode.Tag;
            if (command.Opcode == 0xFF)
            {
                MessageBox.Show(
                    "Cannot edit command(s).\n\nThe two counter command barriers cannot be removed, modified, or moved.",
                    "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                commandTree.SelectedNode.Checked = false;
                return;
            }
            // open the command dialog and load the command
            var commandForm = new CommandForm(command);
            var result = commandForm.ShowDialog(this);
            // only if closed through OK button
            if (result == DialogResult.OK && commandForm.Tag != null)
            {
                this.modifiedNode = commandTree.SelectedNode;
                byte[] oldScript = Bits.Copy(battleScript.Buffer);
                LoadScript(commandTree.GetFullIndex());
                UpdateFreeBytesLabel();
                PushCommand(oldScript);
            }
        }
        private void undo_Click(object sender, EventArgs e)
        {
            commandTree.BeginUpdate();
            commandStack.UndoCommand();
            commandTree.EndUpdate();
        }
        private void redo_Click(object sender, EventArgs e)
        {
            commandTree.BeginUpdate();
            commandStack.RedoCommand();
            commandTree.EndUpdate();
        }

        // Expand / Collapse nodes
        private void expandAll_Click(object sender, EventArgs e)
        {
            commandTree.ExpandAll();
        }
        private void collapseAll_Click(object sender, EventArgs e)
        {
            commandTree.CollapseAll();
        }

        #endregion

        private class CommandEdit : LazyShell.Undo.Edit
        {
            #region Variables

            private int index;
            private byte[] oldScript;
            private int selectedIndex;
            private BattleScriptForm form;
            private BattleScript[] battleScripts;
            public bool AutoRedo { get; set; }

            #endregion

            // Constructor
            public CommandEdit(BattleScript[] battleScripts, int index, byte[] oldScript, BattleScriptForm form, int selectedIndex)
            {
                this.index = index;
                this.oldScript = oldScript;
                this.battleScripts = battleScripts;
                this.selectedIndex = selectedIndex;
                this.form = form;
            }

            // Methods
            public void Execute()
            {
                if (battleScripts != null)
                {
                    this.form.index = index; // first switch back to script in index
                    // next, switch the scripts
                    byte[] temp = Bits.Copy(battleScripts[index].Buffer);
                    battleScripts[index].Buffer = Bits.Copy(oldScript);
                    battleScripts[index].Commands = null;
                    battleScripts[index].ParseScript();
                    oldScript = temp;
                    //
                    form.LoadScript(selectedIndex);
                }
            }
        }
    }
}
