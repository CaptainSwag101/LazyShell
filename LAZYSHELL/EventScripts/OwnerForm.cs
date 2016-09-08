using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Forms;
using LazyShell.Properties;

namespace LazyShell.EventScripts
{
    public partial class OwnerForm : Controls.NewForm
    {
        #region Variables

        // Index
        public int Index
        {
            get { return (int)num.Value; }
            set { num.Value = value; }
        }
        public int Type
        {
            get { return scriptType.SelectedIndex; }
            set { scriptType.SelectedIndex = value; }
        }
        public ElementType ElementType
        {
            get
            {
                return Type == 0 ? ElementType.EventScript : ElementType.ActionScript;
            }
        }

        // Settings
        private Settings settings;

        // Forms
        private PreviewerForm previewer;
        private Search searchWindow;
        private EditLabel labelWindow;
        private FindReferences findReferencesForm;
        private TextBoxForm gotoAddressForm;
        private ByteEditor byteEditor;

        // Searching
        private delegate void ApplyBinaryChangesFunction(byte[] bytes);
        private delegate void PerformSearchDelegate(string input, ListBox results, StringComparison stringComparison, bool matchWholeWord);
        private delegate void LoadResultDelegate(Command command);
        private delegate void GotoAddressFunction(int offset);
        private delegate void FindReferencesFunction(TreeView treeView);

        #region Elements

        private EventScript[] eventScripts
        {
            get { return Model.EventScripts; }
            set { Model.EventScripts = value; }
        }
        public EventScript[] EventScripts
        {
            get { return eventScripts; }
            set { eventScripts = value; }
        }
        private ActionScript[] actionScripts
        {
            get { return Model.ActionScripts; }
            set { Model.ActionScripts = value; }
        }
        public ActionScript[] ActionScripts
        {
            get { return actionScripts; }
            set { actionScripts = value; }
        }
        private ActionScript actionScript
        {
            get { return actionScripts[Index]; }
            set { actionScripts[Index] = value; }
        }
        private EventScript eventScript
        {
            get { return eventScripts[Index]; }
            set { eventScripts[Index] = value; }
        }
        private byte[] scriptBuffer
        {
            get
            {
                if (ElementType == ElementType.EventScript)
                    return eventScript.Buffer;
                else
                    return actionScript.Buffer;
            }
        }

        #endregion

        // TreeView
        public TreeViewWrapper TreeViewWrapper { get; set; }
        private TreeNode modifiedNode;
        /// <summary>
        /// Value indicating whether editing should be disabled for irregularly parsed scripts.
        /// </summary>
        private bool EditingDisabled
        {
            get
            {
                if (ElementType == ElementType.ActionScript)
                    return false;
                if (Index == 0x1D6 || Index == 0x72D || Index == 0x72F || Index == 0xD01 || Index == 0xE91)
                    return true;
                return false;
            }
        }

        #region Navigation

        private Stack<Navigate> navigateBackward;
        private Stack<Navigate> navigateForward;
        private Navigate lastNavigate;
        private bool disableNavigate;
        /// <summary>
        /// Contains the indexing data of a script.
        /// </summary>
        private class Navigate
        {
            public int Index;
            public int Type;
            public Navigate(int index, int type)
            {
                this.Index = index;
                this.Type = type;
            }
        }

        #endregion

        // Reference variables
        private EventCommand evc;
        private ActionCommand acc;
        private Undo.UndoStack commandStack;

        #endregion

        /// <summary>
        /// The main form of the Event Scripts component
        /// </summary>
        public OwnerForm()
        {
            InitializeComponent();
            InitializeVariables();
            InitializeNavigators();
            InitializeLabels();
            CreateHelperForms();
            CreateShortcuts();
            SetFreeBytesLabel();
            RefreshControls();

            // Initialize history logger
            this.History = new History(this, null, num);

            // Since the form is still being initialized
            this.Modified = false;
        }

        #region Methods

        // Initialization
        private void InitializeNavigators()
        {
            this.Updating = true;
            //
            disableNavigate = true;
            if (settings.RememberLastIndex)
            {
                int lastEventScript = settings.LastEventScript;
                Type = Math.Max(0, settings.LastEventScriptCat);
                Index = Math.Min((int)num.Maximum, lastEventScript);
            }
            else
                Type = 0;
            disableNavigate = false;
            lastNavigate = new Navigate(Index, Type);
            //
            this.Updating = false;
        }
        private void InitializeVariables()
        {
            settings = Settings.Default;
            commandStack = new Undo.UndoStack();
            navigateBackward = new Stack<Navigate>();
            navigateForward = new Stack<Navigate>();
            TreeViewWrapper = new TreeViewWrapper(this.commandTree);
        }
        private void InitializeLabels()
        {
            // set event labels
            for (int i = 0; i < Lists.EventLabels.Length; i++)
            {
                // only set to default value if no user-specified value
                if (Lists.EventLabels[i] != null)
                    continue;
                switch (i)
                {
                    case 16: Lists.EventLabels[i] = "Engage in battle (remove permanently after defeat)"; break;
                    case 17: Lists.EventLabels[i] = "Engage in battle (remove temporarily after defeat)"; break;
                    case 18: Lists.EventLabels[i] = "Engage in battle (do not remove after defeat)"; break;
                    case 19: Lists.EventLabels[i] = "Engage in battle (remove permanently after defeat, if ran away, walk through while blinking)"; break;
                    case 20: Lists.EventLabels[i] = "Engage in battle (remove temporarily after defeat, if ran away, walk through while blinking)"; break;
                    case 24: Lists.EventLabels[i] = "Post-battle, check if lost/won, etc."; break;
                    case 32: Lists.EventLabels[i] = "Hit a treasure with a mushroom/star/flower"; break;
                    case 33: Lists.EventLabels[i] = "Hit a treasure with an item (item bag sprite)"; break;
                    case 34: Lists.EventLabels[i] = "Hit a treasure with coins"; break;
                    case 65: Lists.EventLabels[i] = "Jump on trampoline"; break;
                    case 269: Lists.EventLabels[i] = "Come up from tree trunk"; break;
                    case 1556: Lists.EventLabels[i] = "Jump on wiggler"; break;
                    default: Lists.EventLabels[i] = "EVENT #" + i; break;
                }
            }
            // set action labels
            for (int i = 0; i < Lists.ActionLabels.Length; i++)
            {
                // only set to default value if no user-specified value
                if (Lists.ActionLabels[i] != null)
                    continue;
                Lists.ActionLabels[i] = "ACTION #" + i;
            }
            scriptLabel.Text = Lists.EventLabels[Index];
        }
        private void CreateShortcuts()
        {
            Do.AddShortcut(toolStrip4, Keys.Control | Keys.S, new EventHandler(save_Click));
            Do.AddShortcut(toolStrip4, Keys.F2, baseConvertor);
        }
        private void CreateHelperForms()
        {
            searchWindow = new Search(searchScripts, new PerformSearchDelegate(PerformSearch), new LoadResultDelegate(LoadSearchResult));
            labelWindow = new EditLabel(scriptLabel, num, "Event Scripts", true);
            new ToolTipLabel(this, baseConvertor, helpTips);
            byteEditor = new ByteEditor(new ApplyBinaryChangesFunction(ApplyBinaryChanges), true);
            byteEditor.ToggleButton = toggleByteEditor;
            byteEditor.Owner = this;
        }
        private void RefreshControls()
        {
            // save value for restoration at return
            bool modified = this.Modified;

            // alert user if cannot edit script
            if (EditingDisabled)
            {
                this.commandTree.Enabled = false;
                MessageBox.Show("Editing of script #" + Index + " is not allowed due to parsing issues.\n\n" +
                    "This is not an error but merely an issue with the ROM's original default settings.",
                    "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // reset modified flags for all commands
            if (ElementType == ElementType.ActionScript)
            {
                foreach (var acc in actionScripts[Index].Commands)
                    acc.Modified = false;
                num.Maximum = 1023;
            }
            else
            {
                foreach (var evc in eventScripts[Index].Commands)
                {
                    evc.Modified = false;
                    if (evc.Queue == null) continue;
                    foreach (var acc in evc.Queue.Commands)
                        acc.Modified = false;
                }
                num.Maximum = 4095;
            }

            // update offsets before changing the script in the TreeViewWrapper
            commandTree.BeginUpdate();
            if (ElementType == ElementType.EventScript)
            {
                UpdateScriptOffsets();
                TreeViewWrapper.LoadScript(eventScript);
            }
            else
            {
                UpdateActionOffsets();
                TreeViewWrapper.LoadScript(actionScript);
            }
            commandTree.EndUpdate();

            // update raw hex and text label controls
            UpdateCommandInfo();
            if (ElementType == ElementType.EventScript)
                scriptLabel.Text = Lists.EventLabels[Index];
            else
                scriptLabel.Text = Lists.ActionLabels[Index];

            // restore value in case it was changed
            this.Modified = modified;
        }

        #region Collection editing

        /// <summary>
        /// Opens the command dialog and inserts a new command with the user-specified settings into the command collection.
        /// </summary>
        private void InsertCommand()
        {
            CommandLimiter commandLimiter;
            // if editing a non-blank script
            if (commandTree.SelectedNode != null)
            {
                // if inserting action queue/script command
                if (commandTree.SelectedNode.Parent != null || ElementType == ElementType.ActionScript)
                    commandLimiter = CommandLimiter.ActionOnly;
                else
                {
                    var evc = eventScript.Commands[commandTree.SelectedNode.Index];
                    // if adding action queue command to an empty queue trigger
                    if (evc.QueueTrigger)
                        commandLimiter = CommandLimiter.EventOrAction;
                    // if inserting an event command
                    else
                        commandLimiter = CommandLimiter.EventOnly;
                }
            }
            // if inserting action command to a blank action script
            else if (ElementType == ElementType.ActionScript)
                commandLimiter = CommandLimiter.ActionOnly;
            // if inserting event command to a blank event script
            else
                commandLimiter = CommandLimiter.EventOnly;
            // load the command form to specify the new command's settings
            var commandForm = new CommandForm(commandLimiter);
            var result = commandForm.ShowDialog(this);
            if (result != DialogResult.OK)
                return;
            var command = (Command)commandForm.Tag;
            // insert the command into the collection and TreeView
            var buffer = new ScriptBuffer(Bits.Copy(scriptBuffer), TreeViewWrapper.SelectedIndex);
            if (command is EventCommand)
                InsertCommand((EventCommand)command);
            else
                InsertCommand((ActionCommand)command);
            // update info text for controls
            SetFreeBytesLabel();
            UpdateCommandInfo();
            //
            if (modifiedNode != null)
            {
                modifiedNode = commandTree.SelectedNode;
                TreeViewWrapper.EditedNode = modifiedNode;
            }
            //
            PushCommand(buffer);
        }
        /// <summary>
        /// Inserts a specified command as a node into the command TreeView.
        /// </summary>
        /// <param name="cmd">The command to insert into the TreeView.</param>
        private void InsertCommand(Command cmd)
        {
            if (cmd is EventCommand)
            {
                this.evc = evc.Copy();
                TreeViewWrapper.Insert(evc);
            }
            else
            {
                this.acc = acc.Copy();
                TreeViewWrapper.Insert(acc);
            }
        }
        /// <summary>
        /// Opens the command dialog for editing the selected command in the treeview.
        /// </summary>
        public void EditCommand()
        {
            if (!commandTree.Enabled || commandTree.SelectedNode == null)
                return;

            // get the command from the treeview's selected node
            EventCommand evc = null;
            ActionCommand acc = null;

            // action queue command
            if (commandTree.SelectedNode.Parent != null)
            {
                evc = eventScript.Commands[commandTree.SelectedNode.Parent.Index];
                acc = evc.Queue.Commands[commandTree.SelectedNode.Index];
            }
            // action script command
            else if (ElementType == ElementType.ActionScript)
                acc = actionScript.Commands[commandTree.SelectedNode.Index];
            // event script command
            else
                evc = eventScript.Commands[commandTree.SelectedNode.Index];
            UpdateCommandInfo();

            // open the command dialog and load the command
            var commandForm = new CommandForm(evc, acc);
            var result = commandForm.ShowDialog(this);

            // only if closed through OK button
            if (result == DialogResult.OK && commandForm.Tag != null)
            {
                modifiedNode = commandTree.SelectedNode;
                commandTree.SelectedNode = TreeViewWrapper.SelectedNode;
                TreeViewWrapper.EditedNode = modifiedNode;

                // buffer for undo/redo
                var buffer = new ScriptBuffer(Bits.Copy(scriptBuffer), TreeViewWrapper.SelectedIndex);

                // update the command and replace the node
                if (evc != null)
                    TreeViewWrapper.Replace(evc);
                else if (acc != null)
                    TreeViewWrapper.Replace(acc);
                SetFreeBytesLabel();
                UpdateCommandInfo();
                Do.AddHistory(this, Index, commandTree.SelectedNode, "EditCommand");

                // push buffer data to undo/redo stacks
                PushCommand(buffer);
            }
        }
        /// <summary>
        /// Pushes a command change to the undo/redo stack.
        /// </summary>
        /// <param name="buffer"></param>
        private void PushCommand(ScriptBuffer buffer)
        {
            if (ElementType == ElementType.EventScript)
                commandStack.Push(new CommandEdit(eventScripts, Index, buffer, this));
            else
                commandStack.Push(new CommandEdit(actionScripts, Index, buffer, this));
        }

        #endregion

        #region Updating offsets

        private void UpdateScriptOffsets()
        {
            UpdateScriptOffsets(Index);
        }
        private void UpdateScriptOffsets(int index)
        {
            int start = 0;
            int end = 4095;
            // set the index boundaries of the scripts to update based on the current script's ROM bank
            if (index >= 0 && index < 1536)
            {
                start = 0; end = 1535; // bank 0x1E
            }
            else if (index >= 1536 && index < 3072)
            {
                start = 1536; end = 3071; // bank 0x1F
            }
            else if (index >= 3072 && index < 4096)
            {
                start = 3072; end = 4095; // bank 0x20
            }
            //
            int conditionOffset = 0;
            if (index < end)
                conditionOffset = eventScripts[index + 1].BaseOffset;
            else
                conditionOffset = eventScripts[index].BaseOffset + eventScripts[index].Length;
            // set the conditionOffset based on the earliest command whose offset was changed in the current script
            foreach (var esc in eventScripts[index].Commands)
            {
                if (esc.Offset != esc.OriginalOffset)
                {
                    conditionOffset = esc.Offset;
                    break;
                }
            }
            foreach (var script in eventScripts)
            {
                if (script.Index > end)
                    break;
                if (script.Index >= start && script.Index != index)
                    script.UpdateAllOffsets(TreeViewWrapper.ScriptDelta, conditionOffset);
            }
            TreeViewWrapper.ScriptDelta = 0;
        }
        public void UpdateActionOffsets()
        {
            UpdateActionOffsets(TreeViewWrapper.Action.Index);
        }
        public void UpdateActionOffsets(int index)
        {
            int conditionOffset = 0;
            if (index < 1023)
                conditionOffset = actionScripts[index + 1].BaseOffset;
            // don't need to update offsets after the current script if it's the last index
            else
                conditionOffset = actionScripts[index].BaseOffset + actionScripts[index].Length;
            // set the conditionOffset based on the earliest command whose offset was changed in the current script
            foreach (var asc in actionScripts[index].Commands)
            {
                if (asc.Offset != asc.OriginalOffset)
                {
                    conditionOffset = asc.Offset;
                    break;
                }
            }
            foreach (var script in actionScripts)
            {
                if (script.Index >= 0 && script.Index != index)
                    script.UpdateOffsets(TreeViewWrapper.ScriptDelta, conditionOffset);
            }
            TreeViewWrapper.ScriptDelta = 0;
        }

        #endregion

        // Update controls
        public void SetFreeBytesLabel()
        {
            if (ElementType == ElementType.EventScript)
            {
                int left = Model.FreeEventScriptBytes(Index);
                this.labelBytesLeft.Text = " " + left.ToString() + " bytes left ";
                this.labelBytesLeft.BackColor = left < 0 ? Color.Red : SystemColors.Control;
            }
            else
            {
                int left = Model.FreeActionScriptBytes();
                this.labelBytesLeft.Text = " " + left.ToString() + " bytes left ";
                this.labelBytesLeft.BackColor = left < 0 ? Color.Red : SystemColors.Control;
            }
        }
        public void UpdateCommandInfo()
        {
            if (commandTree.SelectedNode != null)
            {
                var command = commandTree.SelectedNode.Tag as Command;
                this.byteEditor.LoadBytes(Bits.Copy(command.Data));
                this.eventHexText.Text = BitConverter.ToString(command.Data);
            }
            else
                this.eventHexText.Text = "";

            // Update binary data
            if (ElementType == ElementType.EventScript)
                eventScript.WriteToBuffer();
            else
                actionScript.WriteToBuffer();
            SetFreeBytesLabel();
        }
        /// <summary>
        /// Applies any changes made in the numeric controls to 
        /// the currently selected command's binary data.
        /// </summary>
        private void ApplyBinaryChanges(byte[] bytes)
        {
            if (!commandTree.Enabled || commandTree.SelectedNode == null)
                return;

            // get the command from the treeview's selected node
            Command command = null;

            // action queue command
            if (commandTree.SelectedNode.Parent != null)
            {
                var evc = eventScript.Commands[commandTree.SelectedNode.Parent.Index];
                command = evc.Queue.Commands[commandTree.SelectedNode.Index];
            }
            // action script command
            else if (ElementType == ElementType.ActionScript)
                command = actionScript.Commands[commandTree.SelectedNode.Index];
            // event script command
            else
                command = eventScript.Commands[commandTree.SelectedNode.Index];

            int offset = command.InternalOffset;
            byte[] data = Bits.Copy(command.Data);
            try
            {
                int available = command.Length;
                byte[] changes = new byte[available];
                for (int i = 0; i < bytes.Length; i++)
                {
                    // set the new value for the command
                    command.Data[i] = bytes[i];
                    changes[i] = bytes[i];
                }

                modifiedNode = commandTree.SelectedNode;
                commandTree.SelectedNode = TreeViewWrapper.SelectedNode;
                TreeViewWrapper.EditedNode = modifiedNode;

                // buffer for undo/redo
                var buffer = new ScriptBuffer(Bits.Copy(scriptBuffer), TreeViewWrapper.SelectedIndex);

                // update the command and replace the node
                if (command is EventCommand)
                    TreeViewWrapper.Replace(evc);
                else if (command is ActionCommand)
                    TreeViewWrapper.Replace(acc);
                SetFreeBytesLabel();
                UpdateCommandInfo();
                Do.AddHistory(this, Index, commandTree.SelectedNode, "EditCommand");

                // push buffer data to undo/redo stacks
                PushCommand(buffer);
            }
            catch
            {
                for (int i = 0; i < data.Length; i++)
                    Model.ROM[offset + i] = data[i];
                data.CopyTo(command.Data, 0);
                MessageBox.Show("Failed to modify command data -- the new command data cannot be parsed. Reverting back to original command.",
                    "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        #region Searching

        private void GotoAddress(int offset)
        {
            if (ElementType == ElementType.ActionScript)
            {
                if (offset < 0x210000)
                {
                    MessageBox.Show("Action script offset too low. Must be between $210000 and $21BFFF.",
                        "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (offset >= 0x21C000)
                {
                    MessageBox.Show("Action script offset too high. Must be between $210000 and $21BFFF.",
                        "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                foreach (var script in actionScripts)
                {
                    foreach (var action in script.Commands)
                    {
                        if (action.Offset + action.Data.Length > offset || action.Offset >= offset)
                        {
                            Index = script.Index;
                            TreeViewWrapper.Select(action);
                            return;
                        }
                    }
                }
            }
            else
            {
                if (offset < 0x1E0000)
                {
                    MessageBox.Show("Event script offset too low. Must be between $1E0000 and $20FFFF.",
                        "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (offset >= 0x210000)
                {
                    MessageBox.Show("Event script offset too high. Must be between $1E0000 and $20FFFF.",
                        "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                foreach (var script in eventScripts)
                {
                    foreach (var command in script.Commands)
                    {
                        if (command.Queue != null)
                        {
                            foreach (var action in command.Queue.Commands)
                            {
                                if (action.Offset + action.Data.Length > offset || action.Offset >= offset)
                                {
                                    Index = script.Index;
                                    TreeViewWrapper.Select(action);
                                    return;
                                }
                            }
                        }
                        if (command.Offset + command.Length > offset || command.Offset >= offset)
                        {
                            Index = script.Index;
                            TreeViewWrapper.Select(command);
                            return;
                        }
                    }
                }
            }
        }
        private void PerformSearch(string input, ListBox results, StringComparison stringComparison, bool matchWholeWord)
        {
            results.BeginUpdate();
            results.Items.Clear();
            if (input == "")
            {
                results.EndUpdate();
                return;
            }
            if (ElementType == ElementType.EventScript)
            {
                foreach (var eventScript in eventScripts)
                {
                    foreach (var command in eventScript.Commands)
                    {
                        string commandString = command.ToString();
                        if (Do.Contains(commandString, input, stringComparison, matchWholeWord))
                            results.Items.Add(command);
                    }
                }
            }
            else
            {
                foreach (var actionScript in actionScripts)
                {
                    foreach (var command in actionScript.Commands)
                    {
                        string commandString = command.ToString();
                        if (Do.Contains(commandString, input, stringComparison, matchWholeWord))
                            results.Items.Add(command);
                    }
                }
            }
            results.EndUpdate();
        }
        private void FindReferences(TreeView treeView)
        {
            // look through event scripts
            var eventScriptResults = new TreeNode();
            foreach (var eventScript in Model.EventScripts)
            {
                foreach (var command in eventScript.Commands)
                {
                    byte opcode = command.Opcode;
                    byte param1 = command.Param1;
                    if (opcode == 0x40 || opcode == 0x44 || opcode == 0x45 ||
                        opcode == 0xD0 || opcode == 0xD1 || (opcode == 0xFD && param1 == 0x46))
                    {
                        int pointToEvent = 0;
                        if (opcode != 0xFD)
                            pointToEvent = Bits.GetShort(command.Data, 1) & 0xFFF;
                        else
                            pointToEvent = Bits.GetShort(command.Data, 2) & 0xFFF;
                        // if points to this event, create a node from result and add to the parent node
                        if (pointToEvent == this.Index)
                        {
                            var result = command.Node;
                            result.Tag = command;
                            eventScriptResults.Nodes.Add(result);
                        }
                    }
                }
            }
            if (eventScriptResults.Nodes.Count > 0)
            {
                eventScriptResults.Text = "EVENT SCRIPTS — found " + eventScriptResults.Nodes.Count + " results";
                treeView.Nodes.Add(eventScriptResults);
            }
            // look through areas
            var areaEventResults = new TreeNode();
            var areaNPCResults = new TreeNode();
            foreach (var area in Areas.Model.Areas)
            {
                foreach (var npc in area.NPCObjects)
                {
                    if (npc.EngageType != Areas.EngageType.Battle && npc.Event == this.Index)
                    {
                        int npcIndex = area.NPCObjects.NPCObjects.IndexOf(npc);
                        var result = new TreeNode("NPC #" + npcIndex + " in " + Lists.Numerize(Lists.Areas, area.Index));
                        result.Tag = area;
                        areaNPCResults.Nodes.Add(result);
                    }
                }
                if (area.EventTriggers.StartEvent == this.Index)
                {
                    var result = new TreeNode("Auto-start in " + Lists.Numerize(Lists.Areas, area.Index));
                    result.Tag = area;
                    areaEventResults.Nodes.Add(result);
                }
                foreach (var eventField in area.EventTriggers.Triggers)
                {
                    if (eventField.RunEvent == this.Index)
                    {
                        int eventIndex = area.EventTriggers.Triggers.IndexOf(eventField);
                        var result = new TreeNode("Event #" + eventIndex + " in " + Lists.Numerize(Lists.Areas, area.Index));
                        result.Tag = area;
                        areaEventResults.Nodes.Add(result);
                    }
                }
            }
            if (areaNPCResults.Nodes.Count > 0)
            {
                areaNPCResults.Text = "AREA NPCs — found " + areaNPCResults.Nodes.Count + " results";
                treeView.Nodes.Add(areaNPCResults);
            }
            if (areaEventResults.Nodes.Count > 0)
            {
                areaEventResults.Text = "AREA EVENTS — found " + areaEventResults.Nodes.Count + " results";
                treeView.Nodes.Add(areaEventResults);
            }
        }
        private void LoadSearchResult(Command searchResult)
        {
            GotoAddress(searchResult.Offset);
        }

        #endregion

        #region Saving

        public void WriteToROM()
        {
            // update offsets first
            if (ElementType == ElementType.EventScript)
                UpdateScriptOffsets();
            else
                UpdateActionOffsets();
            // save all event or action scripts
            if (Model.FreeEventScriptBytes(Index) >= 0)
                WriteEventScriptsToROM();
            else
                MessageBox.Show("There is not enough available space to save the event scripts to.\n\nThe event scripts were not saved.",
                    "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (Model.FreeActionScriptBytes() >= 0)
                WriteActionScriptsToROM();
            else
                MessageBox.Show("There is not enough available space to save the action scripts to.\n\nThe action scripts were not saved.",
                    "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // update hex editor form
            if (ElementType == ElementType.EventScript)
                LazyShell.Model.HexEditor.SetOffset(eventScript.BaseOffset);
            else
                LazyShell.Model.HexEditor.SetOffset(actionScript.BaseOffset);
            LazyShell.Model.HexEditor.HighlightChanges();
            this.Modified = false; // reset modified flag after saving changes
            settings.Save();
        }
        public void WriteEventScriptsToROM()
        {
            foreach (var script in eventScripts)
                script.WriteToBuffer();
            int i = 0;
            int pointer = 0;
            int bank = 0x1E0000;
            ushort offset = 0xC00;
            for (; i < 1536; i++, pointer += 2)
            {
                Bits.SetShort(Model.ROM, bank + pointer, offset);
                Bits.SetBytes(Model.ROM, bank + offset, eventScripts[i].Buffer);
                offset += (ushort)eventScripts[i].Buffer.Length;
            }
            for (int a = offset; a < 0x10000; a++) Model.ROM[bank + a] = 0xFF;
            pointer = 0;
            bank = 0x1F0000;
            offset = 0xC00;
            for (; i < 3072; i++, pointer += 2)
            {
                Bits.SetShort(Model.ROM, bank + pointer, offset);
                Bits.SetBytes(Model.ROM, bank + offset, eventScripts[i].Buffer);
                offset += (ushort)eventScripts[i].Buffer.Length;
            }
            for (int a = offset; a < 0x10000; a++) Model.ROM[bank + a] = 0xFF;
            pointer = 0;
            bank = 0x200000;
            offset = 0x800;
            for (; i < 4096; i++, pointer += 2)
            {
                Bits.SetShort(Model.ROM, bank + pointer, offset);
                Bits.SetBytes(Model.ROM, bank + offset, eventScripts[i].Buffer);
                offset += (ushort)eventScripts[i].Buffer.Length;
            }
            for (int a = offset; a < 0xE000; a++) Model.ROM[bank + a] = 0xFF;
        }
        public void WriteActionScriptsToROM()
        {
            foreach (var script in actionScripts)
                script.WriteToBuffer();
            int i = 0;
            int pointer = 0;
            int bank = 0x210000;
            ushort offset = 0x800;
            for (; i < actionScripts.Length; i++, pointer += 2)
            {
                Bits.SetShort(Model.ROM, bank + pointer, offset);
                Bits.SetBytes(Model.ROM, bank + offset, actionScripts[i].Buffer);
                offset += (ushort)actionScripts[i].Buffer.Length;
            }
        }

        #endregion

        // Previewer
        private void PreviewScript()
        {
            if (previewer == null || !previewer.Visible)
                previewer = new PreviewerForm(this.Index, this.ElementType);
            else
                previewer.Reload(this.Index, this.ElementType);
            previewer.Show();
            previewer.BringToFront();
        }

        #endregion

        #region Event Handlers

        // OwnerForm
        private void OwnerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!this.Modified)
            {
                settings.Save();
                return;
            }
            var result = MessageBox.Show("Event Scripts have not been saved.\n\nWould you like to save changes?",
                "LAZY SHELL", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
                WriteToROM();
            else if (result == DialogResult.No)
                Model.ClearAll();
            else if (result == DialogResult.Cancel)
            {
                e.Cancel = true;
                return;
            }
            settings.Save();
        }

        // Navigators
        private void num_ValueChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            RefreshControls();
            //
            if (!disableNavigate && lastNavigate != null)
            {
                navigateBackward.Push(new Navigate(lastNavigate.Index, lastNavigate.Type));
                navigateBck.Enabled = true;
            }
            if (!disableNavigate)
                lastNavigate = new Navigate(Index, Type);
            settings.LastEventScript = Index;
            settings.LastEventScriptCat = Type;
        }
        private void type_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            this.Updating = true;
            num.Value = 0;
            if (ElementType == ElementType.EventScript)
            {
                UpdateScriptOffsets();
                num.Maximum = 4095;
                TreeViewWrapper.LoadScript(eventScript);
                scriptLabel.Text = Lists.EventLabels[Index];
                labelWindow.SetElement("Event Scripts");
            }
            else
            {
                UpdateActionOffsets();
                num.Maximum = 1023;
                TreeViewWrapper.LoadScript(actionScript);
                scriptLabel.Text = Lists.ActionLabels[Index];
                labelWindow.SetElement("Action Scripts");
            }
            UpdateCommandInfo();
            this.Updating = false;
            //
            if (!disableNavigate && lastNavigate != null)
            {
                navigateBackward.Push(new Navigate(lastNavigate.Index, lastNavigate.Type));
                navigateBck.Enabled = true;
            }
            if (!disableNavigate)
                lastNavigate = new Navigate(Index, Type);
            settings.LastEventScript = Index;
            settings.LastEventScriptCat = Type;
        }
        private void navigateBck_Click(object sender, EventArgs e)
        {
            if (navigateBackward.Count < 1)
                return;
            navigateForward.Push(new Navigate(Index, Type));
            //
            disableNavigate = true;
            Type = navigateBackward.Peek().Type;
            Index = navigateBackward.Peek().Index;
            disableNavigate = false;
            //
            RefreshControls();
            lastNavigate = new Navigate(Index, Type);
            navigateBackward.Pop();
            navigateBck.Enabled = navigateBackward.Count > 0;
            navigateFwd.Enabled = true;
        }
        private void navigateFwd_Click(object sender, EventArgs e)
        {
            if (navigateForward.Count < 1)
                return;
            navigateBackward.Push(new Navigate(Index, Type));
            //
            disableNavigate = true;
            Type = navigateForward.Peek().Type;
            Index = navigateForward.Peek().Index;
            disableNavigate = false;
            //
            RefreshControls();
            lastNavigate = new Navigate(Index, Type);
            navigateForward.Pop();
            navigateFwd.Enabled = navigateForward.Count > 0;
            navigateBck.Enabled = true;
        }

        // Data management
        private void save_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            WriteToROM();
            Cursor.Current = Cursors.Arrow;
        }

        // Forms
        private void openHexEditor_Click(object sender, EventArgs e)
        {
            if (ElementType == ElementType.EventScript)
                LazyShell.Model.HexEditor.SetOffset(eventScript.BaseOffset);
            else
                LazyShell.Model.HexEditor.SetOffset(actionScript.BaseOffset);
            LazyShell.Model.HexEditor.HighlightChanges();
            LazyShell.Model.HexEditor.Show();
        }
        private void openPreviewer_Click(object sender, EventArgs e)
        {
            PreviewScript();
        }

        // IO elements
        private void importEventScripts_Click(object sender, EventArgs e)
        {

        }
        private void importActionScripts_Click(object sender, EventArgs e)
        {
            var buffer = new ScriptBuffer(Bits.Copy(scriptBuffer), TreeViewWrapper.SelectedIndex);
            //
            int[] baseOffsets = new int[Model.ActionScripts.Length];
            int[] lengths = new int[Model.ActionScripts.Length];
            for (int i = 0; i < lengths.Length; i++)
            {
                baseOffsets[i] = Model.ActionScripts[i].BaseOffset;
                lengths[i] = Model.ActionScripts[i].Length;
            }
            //
            var ioelements = new IOElements(Model.ActionScripts, IOMode.Import, Index, "IMPORT ACTION SCRIPTS...");
            ioelements.ShowDialog(this);
            if (ioelements.DialogResult != DialogResult.OK)
                return;
            bool importAll = (bool)ioelements.Tag;
            if (importAll)
            {
                // first, update offsets for any changes made in current script
                if (TreeViewWrapper.ScriptDelta != 0)
                    UpdateActionOffsets();
                // now, update offsets following each newly imported script w/new length
                int baseOffset = 0x210800;
                int lastImported = 1;
                for (int i = 0; i < 1024; i++)
                {
                    int delta = Model.ActionScripts[i].Length - lengths[i];
                    TreeViewWrapper.ScriptDelta += delta;
                    Model.ActionScripts[i].BaseOffset = baseOffset;
                    // only refresh script if a new one was imported
                    if (delta != 0 || baseOffset != baseOffsets[i])
                        Model.ActionScripts[i].Refresh();
                    // only need to update if new length
                    if (delta != 0 && lastImported != i - 1)
                    {
                        lastImported = i;
                        UpdateActionOffsets(i);
                        TreeViewWrapper.ScriptDelta = 0;
                    }
                    baseOffset += Model.ActionScripts[i].Length;
                }
            }
            else if (!importAll) // if importing single script into current
            {
                UpdateActionOffsets(Index);
                actionScript.BaseOffset = baseOffsets[Index];
            }
            TreeViewWrapper.LoadScript(actionScript);
            TreeViewWrapper.RefreshScript();
            //
            if (!Bits.Compare(buffer.OldScript, scriptBuffer))
                PushCommand(buffer);
        }
        private void exportEventScripts_Click(object sender, EventArgs e)
        {
            new IOElements(Model.EventScripts, IOMode.Export, Index, "EXPORT EVENT SCRIPTS...").ShowDialog();
        }
        private void exportActionScripts_Click(object sender, EventArgs e)
        {
            new IOElements(Model.ActionScripts, IOMode.Export, Index, "EXPORT ACTION SCRIPTS...").ShowDialog();
        }
        private void dumpEventScriptText_Click(object sender, EventArgs e)
        {
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.FileName = LazyShell.Model.GetFileNameWithoutPath() + " - eventScripts.txt";
            saveFileDialog.RestoreDirectory = true;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                var writer = File.CreateText(saveFileDialog.FileName);
                for (int i = 0; i < eventScripts.Length; i++)
                {
                    var commands = eventScripts[i].Commands;
                    writer.WriteLine("[" + i.ToString("d4") + "]" +
                        "------------------------------------------------------------>");
                    for (int j = 0; j < commands.Count; j++)
                    {
                        var evc = commands[j];
                        writer.Write((evc.Offset).ToString("X6") + ": ");
                        if (evc.Opcode <= 0x2F && evc.Param1 <= 0xF1 && !evc.Locked)
                        {
                            if (evc.Param1 == 0xF0 || evc.Param1 == 0xF1)
                                writer.Write("{" + BitConverter.ToString(evc.Data, 0, 3) + "}            ");
                            else
                                writer.Write("{" + BitConverter.ToString(evc.Data, 0, 2) + "}               ");
                            writer.Write(evc.ToString() + "\n");
                            if (evc.Queue.Commands != null)
                            {
                                var queue = evc.Queue.Commands;
                                for (int k = 0; k < queue.Count; k++)
                                {
                                    var acc = queue[k];
                                    writer.Write("   " + (acc.Offset).ToString("X6") + ": ");
                                    writer.Write("{" + BitConverter.ToString(acc.Data) + "}");
                                    for (int l = acc.Length; l < 7; l++)
                                        writer.Write("   ");
                                    writer.Write(acc.ToString() + "\n");
                                }
                            }
                        }
                        else if (evc.Locked)   // 0xd01 and 0xe91 only
                        {
                            writer.Write("NON-EMBEDDED ACTION QUEUE\n");
                            if (evc.Queue.Commands != null)
                            {
                                var queue = evc.Queue.Commands;
                                for (int k = 0; k < queue.Count; k++)
                                {
                                    var acc = queue[k];
                                    writer.Write("   " + (acc.Offset).ToString("X6") + ": ");
                                    writer.Write("{" + BitConverter.ToString(acc.Data) + "}");
                                    for (int l = acc.Length; l < 7; l++)
                                        writer.Write("   ");
                                    writer.Write(acc.ToString() + "\n");
                                }
                            }
                        }
                        else
                        {
                            writer.Write("{" + BitConverter.ToString(evc.Data) + "}");
                            for (int k = evc.Length; k < 7; k++)
                                writer.Write("   ");
                            writer.Write(evc.ToString() + "\n");
                        }
                    }
                    writer.Write("\n");
                }
                writer.Close();
            }
        }
        private void dumpActionScriptText_Click(object sender, EventArgs e)
        {
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.FileName = LazyShell.Model.GetFileNameWithoutPath() + " - actionScripts.txt";
            saveFileDialog.RestoreDirectory = true;
            if (saveFileDialog.ShowDialog() != DialogResult.OK)
                return;
            //
            ActionCommand asc;
            List<ActionCommand> commands;
            StreamWriter writer = File.CreateText(saveFileDialog.FileName);
            for (int i = 0; i < actionScripts.Length; i++)
            {
                commands = actionScripts[i].Commands;
                writer.WriteLine("[" + i.ToString("d4") + "]" +
                    "------------------------------------------------------------>");
                if (commands != null)
                {
                    for (int k = 0; k < commands.Count; k++)
                    {
                        asc = commands[k];
                        writer.Write((asc.Offset).ToString("X6") + ": ");
                        writer.Write("{" + BitConverter.ToString(asc.Data) + "}");
                        for (int l = asc.Length; l < 7; l++)
                            writer.Write("   ");
                        writer.Write(asc.ToString() + "\n");
                    }
                }
                writer.Write("\n");
            }
            writer.Close();
        }
        private void clearEventScripts_Click(object sender, EventArgs e)
        {
            var buffer = new ScriptBuffer(Bits.Copy(scriptBuffer), TreeViewWrapper.SelectedIndex);
            //
            int[] lengths = new int[Model.EventScripts.Length];
            for (int i = 0; i < lengths.Length; i++)
                lengths[i] = Model.EventScripts[i].Length;
            //
            var window = new ClearElements(Model.EventScripts, Index, "CLEAR EVENT SCRIPTS...");
            window.ShowDialog(this);
            if (window.DialogResult != DialogResult.OK)
                return;
            //
            var tag = (Point)window.Tag;
            int start = tag.X;
            int end = tag.Y;
            for (int i = start; i <= end; i++)
            {
                TreeViewWrapper.ScriptDelta += Model.EventScripts[i].Length - lengths[i];
                if (i == 1535 && end >= 1536)
                {
                    UpdateScriptOffsets(start);
                    TreeViewWrapper.ScriptDelta = 0;
                    start = 1536;
                }
                if (i == 3071 && end >= 3072)
                {
                    UpdateScriptOffsets(start);
                    TreeViewWrapper.ScriptDelta = 0;
                    start = 3072;
                }
            }
            UpdateScriptOffsets(start);
            TreeViewWrapper.RefreshScript();
            //
            if (!Bits.Compare(buffer.OldScript, scriptBuffer))
                PushCommand(buffer);
        }
        private void clearActionScripts_Click(object sender, EventArgs e)
        {
            var buffer = new ScriptBuffer(Bits.Copy(scriptBuffer), TreeViewWrapper.SelectedIndex);
            //
            int[] lengths = new int[Model.ActionScripts.Length];
            for (int i = 0; i < lengths.Length; i++)
                lengths[i] = Model.ActionScripts[i].Length;
            //
            var window = new ClearElements(Model.ActionScripts, Index, "CLEAR ACTION SCRIPTS...");
            window.ShowDialog(this);
            if (window.DialogResult != DialogResult.OK)
                return;
            //
            var tag = (Point)window.Tag;
            int start = tag.X;
            int end = tag.Y;
            for (int i = start; i <= end; i++)
                TreeViewWrapper.ScriptDelta += Model.ActionScripts[i].Length - lengths[i];
            UpdateActionOffsets(start);
            TreeViewWrapper.RefreshScript();
            //
            if (!Bits.Compare(buffer.OldScript, scriptBuffer))
                PushCommand(buffer);
        }
        private void reset_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("You're about to undo all changes to the current script. Go ahead with reset?",
                "LAZY SHELL", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;
            commandStack.Clear();
            commandTree.BeginUpdate();
            if (ElementType == ElementType.EventScript)
            {
                int length = eventScript.Length;
                int baseOffset = eventScript.BaseOffset;
                eventScript = new EventScript(Index);
                eventScript.BaseOffset = baseOffset;
                TreeViewWrapper.SelectedNode = null;
                TreeViewWrapper.ScriptDelta += eventScript.Length - length;
                TreeViewWrapper.LoadScript(eventScript);
                TreeViewWrapper.RefreshScript();
            }
            else
            {
                int length = actionScript.Length;
                int baseOffset = actionScript.BaseOffset;
                actionScript = new ActionScript(Index);
                actionScript.BaseOffset = baseOffset;
                TreeViewWrapper.SelectedNode = null;
                TreeViewWrapper.ScriptDelta += actionScript.Length - length;
                TreeViewWrapper.LoadScript(actionScript);
                TreeViewWrapper.RefreshScript();
            }
            commandTree.EndUpdate();
        }

        // Search
        private void gotoAddress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Enter)
                return;
            gotoAddrButton.PerformClick();
        }
        private void gotoAddrButton_Click(object sender, EventArgs e)
        {
            if (gotoAddressForm == null)
            {
                gotoAddressForm = new TextBoxForm(true, false, true, 6, new GotoAddressFunction(GotoAddress), "GOTO ADDRESS");
                gotoAddressForm.Owner = this;
            }
            gotoAddressForm.Show();
        }
        private void findReferences_Click(object sender, EventArgs e)
        {
            if (findReferencesForm == null)
            {
                findReferencesForm = new FindReferences(new FindReferencesFunction(FindReferences), null);
                findReferencesForm.Owner = this;
            }
            else
                findReferencesForm.Reload();
            findReferencesForm.Show();
        }
        private void eventLabel_TextChanged(object sender, EventArgs e)
        {
            if (ElementType == ElementType.EventScript)
                Lists.EventLabels[Index] = scriptLabel.Text;
            else
                Lists.ActionLabels[Index] = scriptLabel.Text;
        }

        // TreeView
        private void commandTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            UpdateCommandInfo();
        }
        private void commandTree_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            EditCommand();
        }
        private void commandTree_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            Do.AddHistory(this, Index, e.Node, "NodeMouseClick");
            //
            commandTree.SelectedNode = e.Node;
            if (e.Button != MouseButtons.Right)
                return;
            goToToolStripMenuItem.Click -= goToDialogue_Click;
            goToToolStripMenuItem.Click -= goToEvent_Click;
            goToToolStripMenuItem.Click -= goToOffset_Click;
            goToToolStripMenuItem.Click -= goToAction_Click;
            goToToolStripMenuItem.Click -= addMemoryToNotesDatabase_Click;
            goToToolStripMenuItem.Click -= addMemoryToNotesDatabase_Click;
            if (commandTree.SelectedNode.Tag is EventCommand)
            {
                var temp = commandTree.SelectedNode.Tag as EventCommand;
                if (temp.Opcode == 0x60 || temp.Opcode == 0x62)
                {
                    e.Node.ContextMenuStrip = contextMenuStripGoto;
                    goToToolStripMenuItem.Text = "Edit dialogue...";
                    goToToolStripMenuItem.Click += new EventHandler(goToDialogue_Click);
                }
                else if (temp.Opcode == 0x40 || temp.Opcode == 0x44 || temp.Opcode == 0x45 ||
                    temp.Opcode == 0xD0 || temp.Opcode == 0xD1 || (temp.Opcode == 0xFD && temp.Param1 == 0x46))
                {
                    e.Node.ContextMenuStrip = contextMenuStripGoto;
                    goToToolStripMenuItem.Text = "Goto event...";
                    goToToolStripMenuItem.Click += new EventHandler(goToEvent_Click);
                }
                else if (temp.ReadPointer() != 0)
                {
                    e.Node.ContextMenuStrip = contextMenuStripGoto;
                    goToToolStripMenuItem.Text = "Goto offset...";
                    goToToolStripMenuItem.Click += new EventHandler(goToOffset_Click);
                }
                else if (temp.Opcode <= 0x2F && temp.Param1 >= 0xF2 && temp.Param1 <= 0xF5)
                {
                    e.Node.ContextMenuStrip = contextMenuStripGoto;
                    goToToolStripMenuItem.Text = "Edit action script...";
                    goToToolStripMenuItem.Click += new EventHandler(goToAction_Click);
                }
                // 0xa0 - 0xa6  // 0xd8 - 0xde
                else if (temp.Opcode == 0xA0 || temp.Opcode == 0xA1 || temp.Opcode == 0xA2 ||
                    temp.Opcode == 0xA4 || temp.Opcode == 0xA5 || temp.Opcode == 0xA6 ||
                    temp.Opcode == 0xD8 || temp.Opcode == 0xD9 || temp.Opcode == 0xDA ||
                    temp.Opcode == 0xDC || temp.Opcode == 0xDD || temp.Opcode == 0xDE)
                {
                    e.Node.ContextMenuStrip = contextMenuStripGoto;
                    goToToolStripMenuItem.Text = "Add to project database...";
                    goToToolStripMenuItem.Click += new EventHandler(addMemoryToNotesDatabase_Click);
                }
                else if (temp.Opcode == 0xFD)
                {
                    if (temp.Param1 == 0xD8 || temp.Param1 == 0xD9 || temp.Param1 == 0xDA ||
                        temp.Param1 == 0xDC || temp.Param1 == 0xDD || temp.Param1 == 0xDE)
                    {
                        e.Node.ContextMenuStrip = contextMenuStripGoto;
                        goToToolStripMenuItem.Text = "Add to project database...";
                        goToToolStripMenuItem.Click += new EventHandler(addMemoryToNotesDatabase_Click);
                    }
                }
            }
            else
            {
                var temp = commandTree.SelectedNode.Tag as ActionCommand;
                if (temp.ReadPointer() != 0)
                {
                    e.Node.ContextMenuStrip = contextMenuStripGoto;
                    goToToolStripMenuItem.Text = "Goto offset...";
                    goToToolStripMenuItem.Click += new EventHandler(goToOffset_Click);
                }
                else if (temp.Opcode == 0xD0)
                {
                    e.Node.ContextMenuStrip = contextMenuStripGoto;
                    goToToolStripMenuItem.Text = "Edit action script...";
                    goToToolStripMenuItem.Click += new EventHandler(goToAction_Click);
                }
                // 0xa0 - 0xa6  // 0xd8 - 0xde
                else if (temp.Opcode == 0xA0 || temp.Opcode == 0xA1 || temp.Opcode == 0xA2 ||
                    temp.Opcode == 0xA4 || temp.Opcode == 0xA5 || temp.Opcode == 0xA6 ||
                    temp.Opcode == 0xD8 || temp.Opcode == 0xD9 || temp.Opcode == 0xDA ||
                    temp.Opcode == 0xDC || temp.Opcode == 0xDD || temp.Opcode == 0xDE)
                {
                    e.Node.ContextMenuStrip = contextMenuStripGoto;
                    goToToolStripMenuItem.Text = "Add to project database...";
                    goToToolStripMenuItem.Click += new EventHandler(addMemoryToNotesDatabase_Click);
                }
            }
        }
        private void commandTree_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Parent != null || ElementType == ElementType.ActionScript)
            {
                var asc = (ActionCommand)e.Node.Tag;
                asc.Modified = e.Node.Checked;
            }
            else
            {
                var esc = (EventCommand)e.Node.Tag;
                esc.Modified = e.Node.Checked;
            }
        }
        private void commandTree_KeyDown(object sender, KeyEventArgs e)
        {
            if (!commandTree.Enabled || !commandTree.Focused)
                return;
            //
            switch (e.KeyData)
            {
                case Keys.Control | Keys.A: Do.SelectAllNodes(commandTree.Nodes, true); break;
                case Keys.Control | Keys.D: Do.SelectAllNodes(commandTree.Nodes, false); break;
                case Keys.Control | Keys.C: copy.PerformClick(); break;
                case Keys.Control | Keys.V: paste.PerformClick(); break;
                case Keys.Shift | Keys.Up:
                case Keys.Control | Keys.Up:
                    e.SuppressKeyPress = true;
                    moveUp.PerformClick();
                    break;
                case Keys.Shift | Keys.Down:
                case Keys.Control | Keys.Down:
                    e.SuppressKeyPress = true;
                    moveDown.PerformClick();
                    break;
                case Keys.Delete: delete.PerformClick(); break;
                case Keys.Control | Keys.Z: undo.PerformClick(); break;
                case Keys.Control | Keys.Y: redo.PerformClick(); break;
            }
        }

        // Command editing
        private void insert_Click(object sender, EventArgs e)
        {
            InsertCommand();
        }
        private void edit_Click(object sender, EventArgs e)
        {
            EditCommand();
        }
        private void moveUp_Click(object sender, EventArgs e)
        {
            if (commandTree.SelectedNode == null)
                return;
            this.Updating = true;
            var buffer = new ScriptBuffer(Bits.Copy(scriptBuffer), TreeViewWrapper.SelectedIndex);
            //
            if (commandTree.SelectedNode != modifiedNode)
                modifiedNode = null;
            try
            {
                this.evc = eventScript.Commands[commandTree.SelectedNode.Index];
            }
            catch
            {
            }
            TreeViewWrapper.MoveUp();
            this.Updating = false;
            Do.AddHistory(this, Index, commandTree.SelectedNode, "MoveUpCommand");
            //
            PushCommand(buffer);
        }
        private void moveDown_Click(object sender, EventArgs e)
        {
            if (commandTree.SelectedNode == null)
                return;
            this.Updating = true;
            var buffer = new ScriptBuffer(Bits.Copy(scriptBuffer), TreeViewWrapper.SelectedIndex);
            //
            if (commandTree.SelectedNode != modifiedNode)
                modifiedNode = null;
            try
            {
                this.evc = eventScript.Commands[commandTree.SelectedNode.Index];
            }
            catch
            {
            }
            TreeViewWrapper.MoveDown();
            this.Updating = false;
            Do.AddHistory(this, Index, commandTree.SelectedNode, "MoveDownCommand");
            //
            PushCommand(buffer);
        }
        private void copyCommand_Click(object sender, EventArgs e)
        {
            if (commandTree.SelectedNode == null)
                return;
            TreeViewWrapper.Copy();
            Do.AddHistory(this, Index, commandTree.SelectedNode, "CopyCommand");
        }
        private void pasteCommand_Click(object sender, EventArgs e)
        {
            var buffer = new ScriptBuffer(Bits.Copy(scriptBuffer), TreeViewWrapper.SelectedIndex);
            //
            if (commandTree.SelectedNode != modifiedNode)
                modifiedNode = null;
            TreeViewWrapper.Paste();
            UpdateCommandInfo();
            //
            commandTree.SelectedNode = TreeViewWrapper.SelectedNode;
            Do.AddHistory(this, Index, commandTree.SelectedNode, "PasteCommand");
            //
            PushCommand(buffer);
        }
        private void deleteCommand_Click(object sender, EventArgs e)
        {
            var buffer = new ScriptBuffer(Bits.Copy(scriptBuffer), TreeViewWrapper.SelectedIndex);
            //
            if (commandTree.SelectedNode == modifiedNode)
                modifiedNode = null;
            TreeViewWrapper.Remove();
            UpdateCommandInfo();
            //
            commandTree.SelectedNode = TreeViewWrapper.SelectedNode;
            Do.AddHistory(this, Index, commandTree.SelectedNode, "DeleteCommand");
            //
            PushCommand(buffer);
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

        // Expand / Collapse
        private void collapseAll_Click(object sender, EventArgs e)
        {
            TreeViewWrapper.CollapseAll();
            UpdateCommandInfo();
        }
        private void expandAll_Click(object sender, EventArgs e)
        {
            TreeViewWrapper.ExpandAll();
            UpdateCommandInfo();
        }

        // ContextMenuStrip
        private void goToDialogue_Click(object sender, EventArgs e)
        {
            if (commandTree.SelectedNode == null)
                return;
            var evc = (EventCommand)commandTree.SelectedNode.Tag;
            int num = Bits.GetShort(evc.Data, 1) & 0xFFF;
            if (LazyShell.Model.Program.Dialogues == null || !LazyShell.Model.Program.Dialogues.Visible)
                LazyShell.Model.Program.CreateDialoguesWindow();
            LazyShell.Model.Program.Dialogues.DialoguesForm.Index = num;
            LazyShell.Model.Program.Dialogues.BringToFront();
        }
        private void addMemoryToNotesDatabase_Click(object sender, EventArgs e)
        {
            if (commandTree.SelectedNode == null)
                return;
            int address = 0x7000;
            int addressBit = 0;
            string label = "";
            string description = "";
            if (commandTree.SelectedNode.Tag is EventCommand)
            {
                EventCommand temp = (EventCommand)commandTree.SelectedNode.Tag;
                if (temp.Opcode >= 0xA0 && temp.Opcode <= 0xA2)
                    address = ((((temp.Opcode * 0x100) + temp.Param1) - 0xA000) / 8) + 0x7040;
                if (temp.Opcode >= 0xA4 && temp.Opcode <= 0xA6)
                    address = ((((temp.Opcode * 0x100) + temp.Param1) - 0xA400) / 8) + 0x7040;
                if (temp.Opcode >= 0xD8 && temp.Opcode <= 0xDA)
                    address = ((((temp.Opcode * 0x100) + temp.Param1) - 0xD800) / 8) + 0x7040;
                if (temp.Opcode >= 0xDC && temp.Opcode <= 0xDE)
                    address = ((((temp.Opcode * 0x100) + temp.Param1) - 0xDC00) / 8) + 0x7040;
                addressBit = temp.Param1 & 0x07;
                if (temp.Param1 == 0xFD)
                {
                    if (temp.Param1 >= 0xA0 && temp.Param1 <= 0xA2)
                        address = ((((temp.Param1 * 0x100) + temp.Param2) - 0xA000) / 8) + 0x7040;
                    if (temp.Param1 >= 0xA4 && temp.Param1 <= 0xA6)
                        address = ((((temp.Param1 * 0x100) + temp.Param2) - 0xA400) / 8) + 0x7040;
                    if (temp.Param1 >= 0xD8 && temp.Param1 <= 0xDA)
                        address = ((((temp.Param1 * 0x100) + temp.Param2) - 0xD800) / 8) + 0x7040;
                    if (temp.Param1 >= 0xDC && temp.Param1 <= 0xDE)
                        address = ((((temp.Param1 * 0x100) + temp.Param2) - 0xDC00) / 8) + 0x7040;
                    addressBit = temp.Param2 & 0x07;
                }
            }
            else
            {
                ActionCommand temp = (ActionCommand)commandTree.SelectedNode.Tag;
                if (temp.Opcode >= 0xA0 && temp.Opcode <= 0xA2)
                    address = ((((temp.Opcode * 0x100) + temp.Param1) - 0xA000) / 8) + 0x7040;
                if (temp.Opcode >= 0xA4 && temp.Opcode <= 0xA6)
                    address = ((((temp.Opcode * 0x100) + temp.Param1) - 0xA400) / 8) + 0x7040;
                if (temp.Opcode >= 0xD8 && temp.Opcode <= 0xDA)
                    address = ((((temp.Opcode * 0x100) + temp.Param1) - 0xD800) / 8) + 0x7040;
                if (temp.Opcode >= 0xDC && temp.Opcode <= 0xDE)
                    address = ((((temp.Opcode * 0x100) + temp.Param1) - 0xDC00) / 8) + 0x7040;
                addressBit = temp.Param1 & 0x07;
            }
            label = description = "[" + address.ToString("X4") + ", bit: " + addressBit.ToString() + "]";
            if (LazyShell.Model.Program.Project == null || !LazyShell.Model.Program.Project.Visible)
                LazyShell.Model.Program.CreateProjectWindow();
            var project = LazyShell.Model.Program.Project;
            if (LazyShell.Model.Project == null)
                project.OpenProjectFile();
            if (LazyShell.Model.Project != null)
            {
                project.AddingFromEditor("Memory Bits", address, addressBit, label, description);
                project.BringToFront();
            }
            else
            {
                MessageBox.Show("Could not add element to notes database.", "LAZY SHELL",
                    MessageBoxButtons.OK);
            }
        }
        private void goToEvent_Click(object sender, EventArgs e)
        {
            if (commandTree.SelectedNode == null)
                return;
            var command = commandTree.SelectedNode.Tag as EventCommand;
            int index = 0;
            if (command.Opcode != 0xFD)
                index = Bits.GetShort(command.Data, 1) & 0xFFF;
            else
                index = Bits.GetShort(command.Data, 2) & 0xFFF;
            this.num.Value = index;
        }
        private void goToOffset_Click(object sender, EventArgs e)
        {
            if (commandTree.SelectedNode == null)
                return;
            int pointer = 0;
            var temp = commandTree.SelectedNode.Tag as Command;
            if (ElementType == ElementType.ActionScript)
            {
                pointer = temp.ReadPointer() + (actionScript.BaseOffset & 0xFF0000);
                foreach (var script in actionScripts)
                {
                    foreach (var action in script.Commands)
                    {
                        if (action.Offset + action.Data.Length > pointer || action.Offset >= pointer)
                        {
                            Index = script.Index;
                            TreeViewWrapper.Select(action);
                            return;
                        }
                    }
                }
                return;
            }
            pointer = temp.ReadPointer() + (eventScript.BaseOffset & 0xFF0000);
            foreach (var script in eventScripts)
            {
                foreach (var command in script.Commands)
                {
                    if (command.Queue != null)
                    {
                        foreach (var action in command.Queue.Commands)
                        {
                            if (action.Offset + action.Data.Length > pointer || action.Offset >= pointer)
                            {
                                if (command.Offset + command.Length > pointer || command.Offset >= pointer)
                                {
                                    Index = script.Index;
                                    TreeViewWrapper.Select(command);
                                    return;
                                }
                                Index = script.Index;
                                TreeViewWrapper.Select(action);
                                return;
                            }
                        }
                    }
                    if (command.Offset + command.Length > pointer || command.Offset >= pointer)
                    {
                        Index = script.Index;
                        TreeViewWrapper.Select(command);
                        return;
                    }
                }
            }
        }
        private void goToAction_Click(object sender, EventArgs e)
        {
            if (commandTree.SelectedNode == null)
                return;
            int index = Index;
            if (commandTree.SelectedNode.Tag is EventCommand)
            {
                var command = (EventCommand)commandTree.SelectedNode.Tag;
                index = Bits.GetShort(command.Data, 2);
            }
            else
            {
                var command = (ActionCommand)commandTree.SelectedNode.Tag;
                index = Bits.GetShort(command.Data, 1);
            }
            disableNavigate = true;
            Type = 1;
            disableNavigate = false;
            this.num.Value = index;
        }

        #endregion
    }

    /// <summary>
    /// Class containing the data and methods for changing a script's command data.
    /// </summary>
    public class CommandEdit : LazyShell.Undo.Edit
    {
        #region Variables

        private int index;
        private OwnerForm form;
        private ScriptBuffer buffer;
        private EventScript[] eventScripts;
        private ActionScript[] actionScripts;
        private TreeViewWrapper treeViewWrapper;
        public bool AutoRedo { get; set; }

        #endregion

        // Constructors
        public CommandEdit(EventScript[] eventScripts, int index, ScriptBuffer buffer, OwnerForm form)
        {
            this.form = form;
            this.index = index;
            this.buffer = buffer;
            this.eventScripts = eventScripts;
            this.treeViewWrapper = form.TreeViewWrapper;
        }
        public CommandEdit(ActionScript[] actionScripts, int index, ScriptBuffer buffer, OwnerForm form)
        {
            this.form = form;
            this.index = index;
            this.buffer = buffer;
            this.actionScripts = actionScripts;
            this.treeViewWrapper = form.TreeViewWrapper;
        }

        /// <summary>
        /// Edits the script data.
        /// </summary>
        public void Execute()
        {
            if (eventScripts != null)
            {
                eventScripts[index].Undoing = true;

                // Navigate to script in form
                this.form.Type = 0; // first switch back to event scripts
                this.form.Index = index; // then switch back to script in index

                // Now get difference between old and new script data size
                int length = eventScripts[index].Length;
                int delta = buffer.OldScript.Length - length;
                treeViewWrapper.ScriptDelta += delta;

                // Next, switch old and new script data
                byte[] temp = Bits.Copy(eventScripts[index].Buffer);
                eventScripts[index].Buffer = Bits.Copy(buffer.OldScript);
                eventScripts[index].Commands = null;
                eventScripts[index].ParseScript();
                buffer.OldScript = temp;

                // Reload the script
                int newSelectedIndex = treeViewWrapper.SelectedIndex;
                treeViewWrapper.RefreshScript(buffer.OldSelectedIndex);
                buffer.OldSelectedIndex = newSelectedIndex;

                // Finished
                eventScripts[index].Undoing = false;
            }
            else if (actionScripts != null)
            {
                actionScripts[index].IsUndoing = true;

                // Navigate to script in form
                this.form.Type = 1; // first switch back to action scripts
                this.form.Index = index; // then switch back to script index

                // Now get difference between old and new script data size
                int length = actionScripts[index].Length;
                int delta = buffer.OldScript.Length - length;
                treeViewWrapper.ScriptDelta += delta;

                // Next, switch old and new script data
                byte[] temp = Bits.Copy(actionScripts[index].Buffer);
                actionScripts[index].Buffer = Bits.Copy(buffer.OldScript);
                actionScripts[index].Commands = null;
                actionScripts[index].ParseScript();
                buffer.OldScript = temp;

                // Reload the script
                treeViewWrapper.RefreshScript(buffer.OldSelectedIndex);
                buffer.OldSelectedIndex = treeViewWrapper.SelectedIndex;

                // Finished
                actionScripts[index].IsUndoing = false;
            }
        }
    }

    /// <summary>
    /// Contains the backup data of a script's buffer for undo/redo operations.
    /// </summary>
    public class ScriptBuffer
    {
        #region Variables

        public byte[] OldScript;
        public int OldSelectedIndex;

        #endregion

        // Constructor
        public ScriptBuffer(byte[] oldScript, int oldSelectedIndex)
        {
            this.OldScript = oldScript;
            this.OldSelectedIndex = oldSelectedIndex;
        }
    }
}
