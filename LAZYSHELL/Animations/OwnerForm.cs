using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using LAZYSHELL.EventScripts;
using LAZYSHELL.Properties;
using LAZYSHELL.Undo;

namespace LAZYSHELL.Animations
{
    /// <summary>
    /// Main form of the Animations namespace.
    /// </summary>
    public partial class OwnerForm : Controls.NewForm
    {
        #region Variables

        /// <summary>
        /// The currently loaded set of animation scripts in the form.
        /// </summary>
        public Set CurrentSet
        {
            get
            {
                switch (this.set.SelectedItem as string)
                {
                    case "Ally Spells": return Set.AllySpell;
                    case "Battle Events": return Set.BattleEvent;
                    case "Items": return Set.Item;
                    case "Monster Attacks": return Set.MonsterAttack;
                    case "Monster Behaviors": return Set.MonsterBehavior;
                    case "Monster Entrances": return Set.MonsterEntrance;
                    case "Monster Spells": return Set.MonsterSpell;
                    case "Weapons": return Set.Weapon;
                }
                return 0;
            }
            set
            {
                switch (value)
                {
                    case Set.AllySpell: this.set.SelectedItem = "Ally Spells"; break;
                    case Set.BattleEvent: this.set.SelectedItem = "Battle Events"; break;
                    case Set.Item: this.set.SelectedItem = "Items"; break;
                    case Set.MonsterAttack: this.set.SelectedItem = "Monster Attacks"; break;
                    case Set.MonsterBehavior: this.set.SelectedItem = "Monster Behavior"; break;
                    case Set.MonsterEntrance: this.set.SelectedItem = "Monster Entrances"; break;
                    case Set.MonsterSpell: this.set.SelectedItem = "Monster Spells"; break;
                    case Set.Weapon: this.set.SelectedItem = "Weapons"; break;
                }
            }
        }
        /// <summary>
        /// The index of the currently loaded animation script in its respective collection.
        /// </summary>
        public int Index
        {
            get { return (int)this.num.Value; }
            set { this.num.Value = value; }
        }
        /// <summary>
        /// Command of the currently selected node.
        /// </summary>
        public Command Command
        {
            get
            {
                if (treeView.SelectedNode != null)
                    return treeView.SelectedNode.Tag as Command;
                return null;
            }
            set
            {
                if (treeView.SelectedNode != null)
                {
                    var command = treeView.SelectedNode.Tag as Command;
                    command = value;
                }
            }
        }

        // Elements
        private Script[] scripts
        {
            get
            {
                switch (CurrentSet)
                {
                    case Set.AllySpell: return Model.AllySpells;
                    case Set.BattleEvent: return Model.BattleEvents;
                    case Set.Item: return Model.Items;
                    case Set.MonsterAttack: return Model.MonsterAttacks;
                    case Set.MonsterBehavior: return Model.MonsterBehaviors;
                    case Set.MonsterEntrance: return Model.MonsterEntrances;
                    case Set.MonsterSpell: return Model.MonsterSpells;
                    case Set.Weapon: return Model.Weapons;
                }
                return null;
            }
            set
            {
                switch (CurrentSet)
                {
                    case Set.AllySpell: Model.AllySpells = value; break;
                    case Set.BattleEvent: Model.BattleEvents = value; break;
                    case Set.Item: Model.Items = value; break;
                    case Set.MonsterAttack: Model.MonsterAttacks = value; break;
                    case Set.MonsterBehavior: Model.MonsterBehaviors = value; break;
                    case Set.MonsterEntrance: Model.MonsterEntrances = value; break;
                    case Set.MonsterSpell: Model.MonsterSpells = value; break;
                    case Set.Weapon: Model.Weapons = value; break;
                }
            }
        }
        private Script script
        {
            get { return this.scripts[Index]; }
            set { this.scripts[Index] = value; }
        }

        // Misc
        private delegate void ApplyBinaryChangesFunction(byte[] bytes);
        private TreeViewWrapper treeViewWrapper;
        private UndoStack commandStack;
        private Settings settings;

        // Label forms
        private ToolTipLabel toolTipLabel;
        private EditLabel labelWindow;
        private ByteEditor byteEditor;

        // Previewer form
        private PreviewerForm previewerForm;

        // Buffers for script data
        private byte[] animationBank;
        private byte[] battleBank;

        #endregion

        // Constructor
        public OwnerForm()
        {
            InitializeComponent();
            //
            CreateShortcuts();
            CreateHelperForms();
            InitializeListControls();
            InitializeVariables();
            InitializeNavigators();
            EnableControls();
            LoadScript();
            //
            this.History = new History(this, name, num);
        }

        #region Methods

        // Initializing
        private void CreateShortcuts()
        {
            Do.AddShortcut(toolStrip4, Keys.Control | Keys.S, new EventHandler(save_Click));
            Do.AddShortcut(toolStrip4, Keys.F1, helpTips);
            Do.AddShortcut(toolStrip4, Keys.F2, baseConvertor);
        }
        private void CreateHelperForms()
        {
            toolTipLabel = new ToolTipLabel(this, baseConvertor, helpTips);
            labelWindow = new EditLabel(name, num, "Battle Events", true);
            byteEditor = new ByteEditor(new ApplyBinaryChangesFunction(ApplyBinaryChanges), false);
            byteEditor.ToggleButton = toggleByteEditor;
            byteEditor.Owner = this;
        }
        private void InitializeListControls()
        {
        }
        private void InitializeVariables()
        {
            this.settings = Settings.Default;
            this.commandStack = new UndoStack();
            // Create buffers for the original animation script binary data
            this.animationBank = Bits.GetBytes(Model.ROM, 0x350000, 0x10000);
            this.battleBank = Bits.GetBytes(Model.ROM, 0x3A6000, 0xA000);
            //
            this.treeViewWrapper = new TreeViewWrapper(this.treeView);
        }
        private void InitializeNavigators()
        {
            this.Updating = true;

            // Load the last animation script set from the settings
            if (settings.RememberLastIndex)
                this.set.SelectedIndex = settings.LastAnimationCat;
            else
                this.set.SelectedIndex = 0;

            if (this.name.Items.Count == 0)
                SetListControls();

            // Load the last animation script index from the settings
            if (this.settings.RememberLastIndex)
                this.num.Value = Math.Min((int)num.Maximum, settings.LastAnimation);

            // Finished
            this.Updating = false;
        }

        // Updating
        private void SetListControls()
        {
            this.Updating = true;
            //
            this.name.Items.Clear();
            switch (CurrentSet)
            {
                case Set.AllySpell:
                    for (int i = 0; i < scripts.Length; i++)
                        this.name.Items.Add(Magic.Model.Names.GetUnsortedName(i));
                    this.name.DropDownWidth = this.name.Width;
                    this.name.DrawMode = DrawMode.OwnerDrawFixed;
                    this.name.BackColor = SystemColors.ControlDarkDark;
                    break;
                case Set.BattleEvent:
                    this.name.Items.AddRange(Lists.Numerize(Lists.BattleEvents));
                    this.name.DropDownWidth = 400;
                    this.name.DrawMode = DrawMode.Normal;
                    this.name.BackColor = SystemColors.Window;
                    break;
                case Set.Item:
                    for (int i = 0; i < scripts.Length; i++)
                        this.name.Items.Add(Items.Model.Names.GetUnsortedName(i + 0x60));
                    this.name.DropDownWidth = this.name.Width;
                    this.name.DrawMode = DrawMode.OwnerDrawFixed;
                    this.name.BackColor = SystemColors.ControlDarkDark;
                    break;
                case Set.MonsterAttack:
                    this.name.Items.AddRange(Attacks.Model.Names.Names);
                    this.name.DropDownWidth = this.name.Width;
                    this.name.DrawMode = DrawMode.OwnerDrawFixed;
                    this.name.BackColor = SystemColors.ControlDarkDark;
                    break;
                case Set.MonsterBehavior:
                    for (int i = 0; i < scripts.Length; i++)
                        this.name.Items.Add("Script #" + i.ToString());
                    this.name.DropDownWidth = this.name.Width;
                    this.name.DrawMode = DrawMode.Normal;
                    this.name.BackColor = SystemColors.Window;
                    break;
                case Set.MonsterEntrance:
                    this.name.Items.AddRange(Lists.BattleEntrances);
                    this.name.DropDownWidth = this.name.Width;
                    this.name.DrawMode = DrawMode.Normal;
                    this.name.BackColor = SystemColors.Window;
                    break;
                case Set.MonsterSpell:
                    for (int i = 0; i < scripts.Length; i++)
                        this.name.Items.Add(Magic.Model.Names.GetUnsortedName(i + 0x40));
                    this.name.DropDownWidth = this.name.Width;
                    this.name.DrawMode = DrawMode.OwnerDrawFixed;
                    this.name.BackColor = SystemColors.ControlDarkDark;
                    break;
                case Set.Weapon:
                    for (int i = 0; i < scripts.Length; i++)
                        this.name.Items.Add(Items.Model.Names.GetUnsortedName(i));
                    this.name.DropDownWidth = this.name.Width;
                    this.name.DrawMode = DrawMode.OwnerDrawFixed;
                    this.name.BackColor = SystemColors.ControlDarkDark;
                    break;
            }
            this.num.Maximum = scripts.Length - 1;
            this.name.SelectedIndex = 0;
            //
            if (this.treeView.Nodes.Count > 0)
                this.treeView.SelectedNode = this.treeView.Nodes[0];
            // Finished
            this.Updating = false;
        }
        /// <summary>
        /// Sets the Enabled status of this form's controls based
        /// on the currently loaded animation script set.
        /// </summary>
        private void EnableControls()
        {
            // Enable or disable label editing
            this.name.ContextMenuStrip.Enabled = this.CurrentSet == Set.BattleEvent;
            this.num.ContextMenuStrip.Enabled = this.CurrentSet == Set.BattleEvent;
            this.labelWindow.Disable = this.CurrentSet != Set.BattleEvent;
            // Enable or disable previewer access
            this.openPreviewer.Enabled =
                this.CurrentSet == Set.AllySpell ||
                this.CurrentSet == Set.MonsterAttack ||
                this.CurrentSet == Set.MonsterSpell;
        }
        private void LoadScript()
        {
            LoadScript(true);
        }
        private void LoadScript(bool suspendDrawing)
        {
            this.Updating = true;
            //
            Cursor.Current = Cursors.WaitCursor;
            this.script.ParseScript();
            this.treeViewWrapper.LoadScript(script, suspendDrawing);
            Cursor.Current = Cursors.Arrow;
            //
            this.Updating = false;
            //
            UpdateNumericControls();
        }
        private void SaveLastLoadedIndex()
        {
            this.settings.LastAnimationCat = this.set.SelectedIndex;
            this.settings.LastAnimation = this.Index;
        }
        /// <summary>
        /// Prepares the numeric controls and buttons in the byte editor for editing a command's binary data.
        /// </summary>
        private void UpdateNumericControls()
        {
            this.byteEditor.LoadBytes(Bits.Copy(Command.Data));
            this.textBoxHex.Text = BitConverter.ToString(Command.Data);
        }
        private void UpdateTreeViewNodes()
        {
            this.treeView.BeginUpdate();

            // Backup properties for reselecting node
            int internalOffset = this.Command.InternalOffset;
            int fullParentIndex = this.treeView.GetFullParentIndex();

            // Reload the script -- drawing must stay suspended until the node is reselected below
            LoadScript(false);

            // Reselect the node
            this.treeViewWrapper.Select(internalOffset, fullParentIndex);
            this.treeView.EndUpdate();
        }

        // Opening
        private void OpenPreviewerForm()
        {
            if (previewerForm == null || !previewerForm.Visible)
            {
                previewerForm = new PreviewerForm(set.SelectedIndex, Index, true);
                previewerForm.Owner = this;
            }
            else
                previewerForm.Reload(set.SelectedIndex, Index, true);
            previewerForm.Show();
            previewerForm.BringToFront();
        }

        // Editing
        private void EditCommand()
        {
            if (this.treeView.SelectedNode == null)
                return;
            // Open the command dialog and load the command
            var commandForm = new CommandForm(this.Command);
            var result = commandForm.ShowDialog(this);
            // Only if closed through OK button
            if (result == DialogResult.OK && commandForm.Tag != null)
            {
                var command = commandForm.Tag as Command;
                // Variable for number of bytes to replace and/or wipe clean w/0x0A's                
                int available = this.Command.AvailableSpace(command.Length, false);
                byte[] changes = new byte[available];
                for (int i = 0; i < available; i++)
                    changes[i] = (byte)(i < command.Length ? command.Data[i] : 0x0A);
                this.commandStack.Push(new AnimationEdit(this, command, command.InternalOffset, changes));
                // Redraw the TreeView
                UpdateTreeViewNodes();
            }
        }
        private void MoveUpCommand()
        {
            int topOffset = 0;
            var copy = Command.Copy();
            byte[] changes = treeViewWrapper.MoveUp(Command, ref topOffset);
            if (changes == null)
                return;
            commandStack.Push(new AnimationEdit(this, copy, topOffset, changes));
            //
            UpdateTreeViewNodes();
        }
        private void MoveDownCommand()
        {
            int topOffset = 0;
            var copy = Command.Copy();
            byte[] changes = treeViewWrapper.MoveDown(Command, ref topOffset);
            if (changes == null)
                return;
            commandStack.Push(new AnimationEdit(this, copy, topOffset, changes));
            //
            UpdateTreeViewNodes();
        }
        private void UndoEdit()
        {
            if (!commandStack.UndoCommand())
                return;
            UpdateTreeViewNodes();
        }
        private void RedoEdit()
        {
            if (!commandStack.RedoCommand())
                return;
            UpdateTreeViewNodes();
        }

        /// <summary>
        /// Applies any changes made in the numeric controls to 
        /// the currently selected command's binary data.
        /// </summary>
        private void ApplyBinaryChanges(byte[] bytes)
        {
            int offset = Command.InternalOffset;
            byte[] data = Bits.Copy(Command.Data);
            try
            {
                int available = Command.Length;
                byte[] changes = new byte[available];
                for (int i = 0; i < bytes.Length; i++)
                {
                    // set the new value for the command
                    Command.Data[i] = bytes[i];
                    changes[i] = bytes[i];
                }
                commandStack.Push(new AnimationEdit(this, Command, Command.InternalOffset, changes));
                // check multiple instances of command in current script, and change each accordingly
                script.ParseScript();
            }
            catch
            {
                for (int i = 0; i < data.Length; i++)
                    Model.ROM[offset + i] = data[i];
                data.CopyTo(Command.Data, 0);
                // check multiple instances of command in current script, and change each accordingly
                script.ParseScript();
                MessageBox.Show("Failed to modify command data -- the new command data cannot be parsed. Reverting back to original command.",
                    "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            UpdateTreeViewNodes();
        }

        // IO
        private void DumpAnimationText()
        {
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.FileName = "animationScripts.txt";
            saveFileDialog.RestoreDirectory = true;
            if (saveFileDialog.ShowDialog() != DialogResult.OK)
                return;
            int i = 0;
            var evtscr = File.CreateText(saveFileDialog.FileName);
            evtscr.WriteLine("**************");
            evtscr.WriteLine("MONSTER SPELLS");
            evtscr.WriteLine("**************\n");
            foreach (var ans in Model.MonsterSpells)
            {
                evtscr.WriteLine("\nMONSTER SPELL {" + i.ToString("d3") + "} " + Magic.Model.Names.GetUnsortedName(i + 64).Substring(1).Trim() +
                    "------------------------------------------------------------>\n");
                foreach (var asc in ans.Commands)
                {
                    evtscr.Write((asc.Offset).ToString("X6") + ": ");
                    evtscr.Write("{" + BitConverter.ToString(asc.Data) + "}\n");
                    DumpAnimationText(asc, evtscr, 1);
                }
                i++;
            }
            i = 0;
            evtscr.WriteLine("\n***********");
            evtscr.WriteLine("ALLY SPELLS");
            evtscr.WriteLine("***********\n");
            foreach (var ans in Model.AllySpells)
            {
                evtscr.WriteLine("\nALLY SPELL {" + i.ToString("d3") + "} " + Magic.Model.Names.GetUnsortedName(i).Substring(1).Trim() +
                    "------------------------------------------------------------>\n");
                foreach (var asc in ans.Commands)
                {
                    evtscr.Write((asc.Offset).ToString("X6") + ": ");
                    evtscr.Write("{" + BitConverter.ToString(asc.Data) + "}\n");
                    DumpAnimationText(asc, evtscr, 1);
                }
                i++;
            }
            i = 0;
            evtscr.WriteLine("\n*******");
            evtscr.WriteLine("ATTACKS");
            evtscr.WriteLine("*******\n");
            foreach (var ans in Model.MonsterAttacks)
            {
                evtscr.WriteLine("\nATTACK {" + i.ToString("d3") + "} " + Attacks.Model.Names.GetUnsortedName(i).Trim() +
                    "------------------------------------------------------------>\n");
                foreach (var asc in ans.Commands)
                {
                    evtscr.Write((asc.Offset).ToString("X6") + ": ");
                    evtscr.Write("{" + BitConverter.ToString(asc.Data) + "}\n");
                    DumpAnimationText(asc, evtscr, 1);
                }
                i++;
            }
            i = 0;
            evtscr.WriteLine("\n*****");
            evtscr.WriteLine("ITEMS");
            evtscr.WriteLine("*****\n");
            foreach (var ans in Model.Items)
            {
                evtscr.WriteLine("\nITEM {" + i.ToString("d3") + "} " + Items.Model.Names.GetUnsortedName(i + 96).Substring(1).Trim() +
                    "------------------------------------------------------------>\n");
                foreach (var asc in ans.Commands)
                {
                    evtscr.Write((asc.Offset).ToString("X6") + ": ");
                    evtscr.Write("{" + BitConverter.ToString(asc.Data) + "}\n");
                    DumpAnimationText(asc, evtscr, 1);
                }
                i++;
            }
            i = 0;
            evtscr.WriteLine("\n*************");
            evtscr.WriteLine("BATTLE EVENTS");
            evtscr.WriteLine("*************\n");
            foreach (var ans in Model.BattleEvents)
            {
                evtscr.WriteLine("\nBATTLE EVENT {" + i.ToString("d3") + "} " +
                    "------------------------------------------------------------>\n");
                foreach (var asc in ans.Commands)
                {
                    evtscr.Write((asc.Offset).ToString("X6") + ": ");
                    evtscr.Write("{" + BitConverter.ToString(asc.Data) + "}\n");
                    DumpAnimationText(asc, evtscr, 1);
                }
                i++;
            }
            i = 0;
            evtscr.WriteLine("\n*********");
            evtscr.WriteLine("BEHAVIORS");
            evtscr.WriteLine("*********\n");
            foreach (var ans in Model.MonsterBehaviors)
            {
                evtscr.WriteLine("\nBEHAVIOR {" + i.ToString("d3") + "} " +
                    "------------------------------------------------------------>\n");
                foreach (var asc in ans.Commands)
                {
                    evtscr.Write((asc.Offset).ToString("X6") + ": ");
                    evtscr.Write("{" + BitConverter.ToString(asc.Data) + "}\n");
                    DumpAnimationText(asc, evtscr, 1);
                }
                i++;
            }
            i = 0;
            evtscr.WriteLine("\n*********");
            evtscr.WriteLine("ENTRANCES");
            evtscr.WriteLine("*********\n");
            foreach (var ans in Model.MonsterEntrances)
            {
                evtscr.WriteLine("\nENTRANCE {" + i.ToString("d3") + "} " +
                    "------------------------------------------------------------>\n");
                foreach (var asc in ans.Commands)
                {
                    evtscr.Write((asc.Offset).ToString("X6") + ": ");
                    evtscr.Write("{" + BitConverter.ToString(asc.Data) + "}\n");
                    DumpAnimationText(asc, evtscr, 1);
                }
                i++;
            }
            i = 0;
            evtscr.WriteLine("\n*******");
            evtscr.WriteLine("WEAPONS");
            evtscr.WriteLine("*******\n");
            foreach (var ans in Model.Weapons)
            {
                evtscr.WriteLine("\nWEAPON {" + i.ToString("d3") + "} " + Items.Model.Names.GetUnsortedName(i).Substring(1).Trim() +
                    "------------------------------------------------------------>\n");
                foreach (var asc in ans.Commands)
                {
                    evtscr.Write((asc.Offset).ToString("X6") + ": ");
                    evtscr.Write("{" + BitConverter.ToString(asc.Data) + "}\n");
                    DumpAnimationText(asc, evtscr, 1);
                }
                i++;
            }
        }
        private void DumpAnimationText(Command parent, StreamWriter textWriter, int level)
        {
            foreach (var command in parent.Commands)
            {
                for (int i = 0; i < level; i++)
                    textWriter.Write("\t");
                textWriter.Write((command.Offset).ToString("X6") + ": ");
                textWriter.Write("{" + BitConverter.ToString(command.Data) + "}\n");
                DumpAnimationText(command, textWriter, level + 1);
            }
        }

        // Saving
        public void WriteToROM()
        {
        }

        #endregion

        #region Event Handlers

        // OwnerForm
        private void OwnerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!this.Modified)
                return;
            var result = MessageBox.Show("Animations have not been saved.\n\nWould you like to save changes?",
                "LAZY SHELL", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                WriteToROM();
                this.Modified = false;
            }
            else if (result == DialogResult.No)
            {
                Buffer.BlockCopy(animationBank, 0, Model.ROM, 0x350000, 0x10000);
                Buffer.BlockCopy(battleBank, 0, Model.ROM, 0x3A6000, 0xA000);
                Model.ClearAll();
            }
            else if (result == DialogResult.Cancel)
                e.Cancel = true;
        }

        // Data management
        private void save_Click(object sender, System.EventArgs e)
        {
            WriteToROM();
        }
        private void export_Click(object sender, EventArgs e)
        {
            DumpAnimationText();
        }

        // Open forms
        private void openPreviewer_Click(object sender, EventArgs e)
        {
            OpenPreviewerForm();
        }

        // Navigating
        private void set_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                // Save last loaded index to settings
                SaveLastLoadedIndex();

                // Start updating
                this.Updating = true;
                this.Index = 0;    // New set loaded, start from 0
                SetListControls(); // Set name list for set
                LoadScript();      // Load the script for editing

                // Finish updating
                this.Updating = false;
            }
        }
        private void num_ValueChanged(object sender, EventArgs e)
        {
            // Update ComboBox's SelectedIndex
            if (CurrentSet == Set.MonsterAttack)
                this.name.SelectedIndex = Attacks.Model.Names.GetSortedIndex(this.Index);
            else
                this.name.SelectedIndex = this.Index;
            if (!this.Updating)
            {
                // Save last loaded index to settings
                SaveLastLoadedIndex();
                // Load the script for editing
                LoadScript();
            }
        }
        private void name_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Update NumericUpDown's Value
            if (this.CurrentSet == Set.MonsterAttack)
                this.Index = Attacks.Model.Names.GetUnsortedIndex(this.name.SelectedIndex);
            else
                this.Index = this.name.SelectedIndex;
        }
        private void name_DrawItem(object sender, DrawItemEventArgs e)
        {
            var bgimage = Menus.Model.MenuBG_256x255;
            if (e.Index < 0 || e.Index >= this.name.Items.Count)
                return;
            int[] temp;
            if (this.CurrentSet == Set.AllySpell ||
                this.CurrentSet == Set.Item ||
                this.CurrentSet == Set.MonsterAttack ||
                this.CurrentSet == Set.MonsterSpell ||
                this.CurrentSet == Set.Weapon)
            {
                char[] name;
                switch (CurrentSet)
                {
                    case Set.AllySpell: // Ally spells
                        name = Magic.Model.Names.GetUnsortedName(e.Index).ToCharArray();
                        temp = new MenuTextPreview().GetPreview(Fonts.Model.Menu, Fonts.Model.Palette_Battle.Palette, name, true);
                        break;
                    case Set.Item: // Items
                        name = Items.Model.Names.GetUnsortedName(e.Index + 0x60).ToCharArray();
                        temp = new MenuTextPreview().GetPreview(Fonts.Model.Menu, Fonts.Model.Palette_Battle.Palette, name, true);
                        break;
                    case Set.MonsterAttack: // Monster attacks
                        name = Attacks.Model.Names.Names[e.Index].ToCharArray();
                        temp = new BattleDialoguePreview().GetPreview(Fonts.Model.Dialogue, Fonts.Model.Palette_Battle.Palette, name, false);
                        break;
                    case Set.MonsterSpell: // Monster spells
                        name = Magic.Model.Names.GetUnsortedName(e.Index + 0x40).ToCharArray();
                        temp = new BattleDialoguePreview().GetPreview(Fonts.Model.Dialogue, Fonts.Model.Palette_Battle.Palette, name, false);
                        break;
                    case Set.Weapon: // Weapons
                        name = Items.Model.Names.GetUnsortedName(e.Index).ToCharArray();
                        temp = new MenuTextPreview().GetPreview(Fonts.Model.Menu, Fonts.Model.Palette_Battle.Palette, name, true);
                        break;
                    default: // Battle events, Monster behaviors
                        name = new char[1];
                        temp = new MenuTextPreview().GetPreview(Fonts.Model.Menu, Fonts.Model.Palette_Battle.Palette, name, true); break;
                }

                //
                var background = new Rectangle(0, e.Index * 15 % bgimage.Height, bgimage.Width, 15);
                e.Graphics.DrawImage(bgimage, e.Bounds.X, e.Bounds.Y, background, GraphicsUnit.Pixel);

                // set the pixels
                if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                    e.DrawBackground();
                int[] pixels;
                Bitmap icon;
                if (this.CurrentSet == Set.MonsterAttack ||
                    this.CurrentSet == Set.MonsterSpell)
                {
                    pixels = new int[256 * 32];
                    for (int y = 2, c = 10; c < 32; y++, c++)
                    {
                        for (int x = 2, a = 8; a < 256; x++, a++)
                            pixels[y * 256 + x] = temp[c * 256 + a];
                    }
                    icon = Do.PixelsToImage(pixels, 256, 32);
                }
                else
                {
                    pixels = new int[256 * 14];
                    for (int y = 2, c = 0; y < 14; y++, c++)
                    {
                        for (int x = 2, a = 0; x < 256; x++, a++)
                            pixels[y * 256 + x] = temp[c * 256 + a];
                    }
                    icon = Do.PixelsToImage(pixels, 256, 14);
                }
                e.Graphics.DrawImage(new Bitmap(icon), new Point(e.Bounds.X, e.Bounds.Y));
            }
            else
            {
                e.DrawBackground();
                e.Graphics.DrawString(name.Items[e.Index].ToString(), e.Font, new SolidBrush(name.ForeColor), e.Bounds);
            }
        }

        // TreeView
        private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (!this.Updating)
            {
                treeViewWrapper.SelectedNode = e.Node;
                UpdateNumericControls();
            }
        }
        private void treeView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            EditCommand();
        }
        private void treeView_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Control | Keys.Up:
                case Keys.Shift | Keys.Up:
                    e.SuppressKeyPress = true;
                    MoveUpCommand();
                    break;
                case Keys.Control | Keys.Down:
                case Keys.Shift | Keys.Down:
                    e.SuppressKeyPress = true;
                    MoveDownCommand();
                    break;
                case Keys.Control | Keys.Z:
                    UndoEdit();
                    break;
                case Keys.Control | Keys.Y:
                    RedoEdit();
                    break;
            }
        }

        // Modification
        private void edit_Click(object sender, EventArgs e)
        {
            EditCommand();
        }
        private void moveDown_Click(object sender, EventArgs e)
        {
            MoveDownCommand();
        }
        private void moveUp_Click(object sender, EventArgs e)
        {
            MoveUpCommand();
        }
        private void undo_Click(object sender, EventArgs e)
        {
            UndoEdit();
        }
        private void redo_Click(object sender, EventArgs e)
        {
            RedoEdit();
        }

        // TreeView nodes
        private void expandAll_Click(object sender, EventArgs e)
        {
            treeViewWrapper.ExpandAll();
            UpdateNumericControls();
        }
        private void collapseAll_Click(object sender, EventArgs e)
        {
            treeViewWrapper.CollapseAll();
            UpdateNumericControls();
        }

        #endregion
    }
}
