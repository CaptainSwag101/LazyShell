using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LAZYSHELL.Properties;

namespace LAZYSHELL.EventScripts
{
    public partial class CommandForm : Controls.NewForm
    {
        #region Variables

        // Settings
        private Settings settings = Settings.Default;

        // Command
        public EventCommand evc;
        public ActionCommand acc;

        // Command properties
        private ElementType type;
        private string commandText
        {
            get
            {
                int[] tree = commandCategory;
                if (tree != null)
                    return acc == null ?
                        Lists.EventCommands(tree[0])[tree[1]] :
                        Lists.ActionCommands(tree[0])[tree[1]];
                else
                    return "INVALID";
            }
        }
        private int[] commandCategory
        {
            get
            {
                int opcode;
                int param1;
                int[][] listBoxOpcodes;
                int[][] listBoxFDOpcodes;
                if (acc == null)
                {
                    listBoxOpcodes = Lists.EventOpcodes;
                    listBoxFDOpcodes = Lists.EventParams;
                    opcode = evc.Opcode;
                    param1 = evc.Param1;
                    if (opcode <= 0x2F) opcode = 0;
                }
                else
                {
                    listBoxOpcodes = Lists.ActionOpcodes;
                    listBoxFDOpcodes = Lists.ActionParams;
                    opcode = acc.Opcode;
                    param1 = acc.Param1;
                }
                if (opcode >= 0xA0 && opcode <= 0xA2) opcode = 0xA0;
                if (opcode >= 0xA4 && opcode <= 0xA6) opcode = 0xA4;
                if (opcode >= 0xD8 && opcode <= 0xDA) opcode = 0xD8;
                if (opcode >= 0xDC && opcode <= 0xDF) opcode = 0xDC;
                if (opcode != 0xFD)
                    for (int a = 0; a < listBoxOpcodes.Length; a++)
                        for (int b = 0; b < listBoxOpcodes[a].Length; b++)
                            if (opcode == listBoxOpcodes[a][b])
                                return new int[] { a, b };
                if (opcode == 0xFD)
                    for (int a = 0; a < listBoxFDOpcodes.Length; a++)
                        for (int b = 0; b < listBoxFDOpcodes[a].Length; b++)
                            if (param1 == listBoxFDOpcodes[a][b])
                                return new int[] { a, b };
                return null;
            }
        }
        private CommandLimiter commandLimiter;

        #endregion

        /// <summary>
        /// Load the command form inserting a new command.
        /// </summary>
        /// <param name="commandLimiter">The limitations on the type of command that can be inserted.</param>
        public CommandForm(CommandLimiter commandLimiter)
        {
            InitializeComponent();
            InitializeLocation();
            //
            this.commandLimiter = commandLimiter;
            //
            InitializeListControls();
        }
        /// <summary>
        /// Load the command form for editing a specified command.
        /// </summary>
        /// <param name="evc">The event command to modify or the parent event command if editing an 
        /// action command in a queue.</param>
        /// <param name="acc">The action command to modify, if any.</param>
        public CommandForm(EventCommand evc, ActionCommand acc)
        {
            InitializeComponent();
            InitializeLocation();

            // Initialize class variables
            if (evc != null)
                this.evc = evc;
            if (acc != null)
                this.acc = acc;

            // Load command data into controls
            if (acc == null)
                ReadFromEventCommand();
            else
                ReadFromActionCommand();
        }

        #region Methods

        // Initialization
        private void InitializeLocation()
        {
            this.Left = Cursor.Position.X + 10;
            this.Top = Cursor.Position.Y - 10;
        }
        private void InitializeListControls()
        {
            if (commandLimiter == CommandLimiter.EventOnly)
            {
                actionButton.Visible = false;
                categories_es.Visible = true;
                categories_aq.Visible = false;
                categories_es.SelectedIndex = 0;
            }
            else if (commandLimiter == CommandLimiter.ActionOnly)
            {
                actionButton.Visible = false;
                categories_es.Visible = false;
                categories_aq.Visible = true;
                categories_aq.SelectedIndex = 0;
            }
            else if (commandLimiter == CommandLimiter.EventOrAction)
            {
                actionButton.Visible = true;
                categories_es.Visible = true;
                categories_aq.Visible = false;
                categories_es.SelectedIndex = 0;
            }
        }
        private void SwitchCommandType(ElementType type)
        {
            this.type = type;
            commands.Items.Clear();
            if (type == ElementType.EventScript)
                commands.Items.AddRange(Lists.EventCommands(categories_es.SelectedIndex));
            else if (type == ElementType.ActionScript)
                commands.Items.AddRange(Lists.ActionCommands(categories_aq.SelectedIndex));
            commands.Height = commands.PreferredHeight;
            commands.SelectedIndex = 0;
        }

        /// <summary>
        /// Loads the current event command's data into the controls.
        /// </summary>
        public void ReadFromEventCommand()
        {
            this.Updating = true;
            //
            panelCommand.SuspendDrawing();
            //
            int[] tree = commandCategory;
            if (tree != null)
            {
                categories_es.SelectedIndex = tree[0];
                commands.SelectedIndex = tree[1];
            }
            switch (evc.Opcode)
            {
                #region Objects

                case 0x32:  // If object present...
                case 0x39:  // If Mario on top of object...
                    groupBoxA.Text = commandText;
                    labelEvtA1.Text = "Object";
                    labelEvtA3.Text = "Jump to";
                    evtNameA1.Items.AddRange(Lists.NPCs); evtNameA1.Enabled = true;
                    evtNumA3.Hexadecimal = true; evtNumA3.Maximum = 0xFFFF; evtNumA3.Enabled = true;
                    //
                    evtNameA1.SelectedIndex = evc.Param1;
                    evtNumA3.Value = Bits.GetShort(evc.Data, 2);
                    break;
                case 0x3A:         // If distance between object A and...
                case 0x3B:         // If distance (Z==) between object A and...
                    groupBoxA.Text = commandText;
                    labelEvtA1.Text = "Object A";
                    labelEvtA2.Text = "Object B";
                    labelEvtA3.Text = "Less than X";
                    labelEvtA4.Text = "Less than Y";
                    labelEvtC1.Text = "Jump to";
                    evtNameA1.Items.AddRange(Lists.NPCs); evtNameA1.Enabled = true;
                    evtNameA2.Items.AddRange(Lists.NPCs); evtNameA2.Enabled = true;
                    evtNumA3.Enabled = true;
                    evtNumA4.Enabled = true;
                    evtNumC1.Enabled = true; evtNumC1.Hexadecimal = true; evtNumC1.Maximum = 0xFFFF;
                    //
                    evtNameA1.SelectedIndex = evc.Param1;          // object A
                    evtNameA2.SelectedIndex = evc.Param2;    // object B
                    evtNumA3.Value = evc.Param3;
                    evtNumA4.Value = evc.Param4;
                    evtNumC1.Value = Bits.GetShort(evc.Data, 5);
                    break;
                case 0x3D:         // If Mario in air...
                    groupBoxC.Text = commandText;
                    labelEvtC1.Text = "Jump to";
                    evtNumC1.Enabled = true; evtNumC1.Hexadecimal = true; evtNumC1.Maximum = 0xFFFF;
                    //
                    evtNumC1.Value = Bits.GetShort(evc.Data, 1);
                    break;
                case 0x3E:         // Create NPC packet @ obj coords...
                    groupBoxA.Text = commandText;
                    labelEvtA1.Text = "Object";
                    labelEvtA2.Text = "Packet";
                    groupBoxC.Text = "If null...";
                    labelEvtC1.Text = "Jump to";
                    evtNameA1.Items.AddRange(Lists.NPCs); evtNameA1.Enabled = true;
                    evtNameA2.Items.AddRange(Lists.Numerize(Lists.NPCPackets)); evtNameA2.Enabled = true;
                    evtNameA2.DropDownWidth = 200;
                    evtNumC1.Enabled = true; evtNumC1.Hexadecimal = true; evtNumC1.Maximum = 0xFFFF;
                    //
                    evtNameA1.SelectedIndex = evc.Param2;
                    evtNameA2.SelectedIndex = evc.Param1;
                    evtNumC1.Value = Bits.GetShort(evc.Data, 3);
                    break;
                case 0x3F:         // Create NPC packet...
                    groupBoxA.Text = commandText;
                    labelEvtA2.Text = "Packet";
                    groupBoxC.Text = "If null...";
                    labelEvtC1.Text = "Jump to";
                    evtNameA2.Items.AddRange(Lists.Numerize(Lists.NPCPackets)); evtNameA2.Enabled = true;
                    evtNameA2.DropDownWidth = 200;
                    evtNumC1.Enabled = true; evtNumC1.Hexadecimal = true; evtNumC1.Maximum = 0xFFFF;
                    //
                    evtNameA2.SelectedIndex = evc.Param1;
                    evtNumC1.Value = Bits.GetShort(evc.Data, 2);
                    break;
                case 0x42:         // If Mario on top of an object...
                    groupBoxC.Text = commandText;
                    labelEvtC1.Text = "Jump to";
                    labelEvtC2.Text = "Else jump to";
                    evtNumC1.Enabled = true; evtNumC1.Hexadecimal = true; evtNumC1.Maximum = 0xFFFF;
                    evtNumC2.Enabled = true; evtNumC2.Hexadecimal = true; evtNumC2.Maximum = 0xFFFF;
                    //
                    evtNumC1.Value = Bits.GetShort(evc.Data, 1);
                    evtNumC2.Value = Bits.GetShort(evc.Data, 3);
                    break;
                case 0xF2:         // Set obj presence...  
                case 0xF3:         // Set obj engage type...
                case 0xF8:         // If object in level ..., presence =...
                    groupBoxA.Text = commandText;
                    labelEvtA1.Text = "Level";
                    labelEvtA2.Text = "Object";
                    if (evc.Opcode == 0xF8)
                        labelEvtC1.Text = "Jump to";
                    evtNameA1.Items.AddRange(Lists.Numerize(Lists.Areas)); evtNameA1.Enabled = true;
                    evtNameA1.DropDownWidth = 500;
                    evtNameA2.Items.AddRange(Lists.NPCs); evtNameA2.Enabled = true;
                    evtNumA1.Enabled = true; evtNumA1.Maximum = 511;
                    if (evc.Opcode == 0xF3)
                        evtEffects.Items.AddRange(new object[] { "is enabled" });
                    else
                        evtEffects.Items.AddRange(new object[] { "is present" });
                    evtEffects.Enabled = true;
                    if (evc.Opcode == 0xF8)
                        evtNumC1.Enabled = true; evtNumC1.Hexadecimal = true; evtNumC1.Maximum = 0xFFFF;
                    //
                    evtNumA1.Value = Bits.GetShort(evc.Data, 1) & 0x1FF;
                    evtNameA1.SelectedIndex = (int)evtNumA1.Value;
                    evtNameA2.SelectedIndex = (evc.Param2 >> 1) & 0x3F;
                    evtEffects.SetItemChecked(0, (evc.Param2 & 0x80) == 0x80);
                    if (evc.Opcode == 0xF8)
                        evtNumC1.Value = Bits.GetShort(evc.Data, 3);
                    break;

                #endregion

                #region Joypad

                case 0x34:
                case 0x35:
                    groupBoxB.Text = commandText;
                    evtEffects.Items.AddRange(Lists.ButtonNames); evtEffects.Enabled = true;
                    //
                    for (int i = 1, j = 0; j < 8; i *= 2, j++)
                        evtEffects.SetItemChecked(j, (evc.Param1 & i) == i);
                    break;

                #endregion

                #region Party members

                case 0x36:
                    groupBoxA.Text = commandText;
                    labelEvtA1.Text = "Character";
                    labelEvtA2.Text = "Add/remove";
                    evtNameA1.Items.AddRange(Lists.CharacterNames); evtNameA1.Enabled = true;
                    evtNameA2.Items.AddRange(new string[] { "remove from party", "add to party" }); evtNameA2.Enabled = true;
                    //
                    evtNameA1.SelectedIndex = evc.Param1 & 0x07;
                    evtNameA2.SelectedIndex = evc.Param1 >> 7;
                    break;
                case 0x54:
                    groupBoxA.Text = commandText;
                    labelEvtA1.Text = "Character";
                    labelEvtA2.Text = "Item";
                    evtNameA1.Items.AddRange(Lists.CharacterNames); evtNameA1.Enabled = true;
                    evtNameA2.Items.AddRange(Items.Model.Names.Names); evtNameA2.Enabled = true;
                    evtNameA2.DrawMode = DrawMode.OwnerDrawFixed;
                    evtNumA2.Maximum = 255; evtNumA2.Enabled = true;
                    //
                    evtNameA1.SelectedIndex = evc.Param1 & 7;
                    evtNumA2.Value = evc.Param2;
                    evtNameA2.SelectedIndex = Items.Model.Names.GetSortedIndex((int)evtNumA2.Value);
                    break;
                case 0x56:
                    groupBoxA.Text = commandText;
                    labelEvtA1.Text = "Character";
                    evtNameA1.Items.AddRange(Lists.CharacterNames); evtNameA1.Enabled = true;
                    //
                    evtNameA1.SelectedIndex = evc.Param1 & 7;
                    break;

                #endregion

                #region Inventory

                case 0x50:
                case 0x51:
                    groupBoxA.Text = commandText;
                    labelEvtA1.Text = "Item";
                    evtNameA1.Items.AddRange(Items.Model.Names.Names); evtNameA1.Enabled = true;
                    evtNameA1.DrawMode = DrawMode.OwnerDrawFixed;
                    evtNumA1.Maximum = 255; evtNumA1.Enabled = true;
                    //
                    evtNumA1.Value = evc.Param1;
                    evtNameA1.SelectedIndex = Items.Model.Names.GetSortedIndex((int)evtNumA1.Value);
                    break;
                case 0x52:
                case 0x53:
                    groupBoxA.Text = commandText;
                    labelEvtA1.Text = "Value";
                    evtNumA1.Enabled = true;
                    //
                    evtNumA1.Value = evc.Param1;
                    break;

                #endregion

                #region Battle

                case 0x4A:
                    groupBoxA.Text = commandText;
                    labelEvtA2.Text = "Battlefield";
                    labelEvtA3.Text = "Pack";
                    evtNameA2.Items.AddRange(Lists.Numerize(Lists.Battlefields)); evtNameA2.Enabled = true;
                    evtNameA2.DropDownWidth = 250;
                    evtNumA2.Maximum = 63; evtNumA2.Enabled = true;
                    evtNumA3.Enabled = true;
                    //
                    evtNumA2.Value = evc.Param3;
                    evtNameA2.SelectedIndex = evc.Param3;
                    evtNumA3.Value = evc.Param1;
                    break;

                #endregion

                #region Areas

                case 0x4B:      // Open, world location...
                    groupBoxA.Text = commandText;
                    labelEvtA1.Text = "Location";
                    groupBoxB.Text = "Unknown bits";
                    evtNameA1.Items.AddRange(Lists.Numerize(Lists.Locations)); evtNameA1.Enabled = true;
                    evtNameA1.DropDownWidth = 200;
                    evtEffects.Items.AddRange(new string[] { "bit 5", "bit 6", "bit 7" }); evtEffects.Enabled = true;
                    //
                    evtNameA1.SelectedIndex = evc.Param1;
                    evtEffects.SetItemChecked(0, (evc.Param2 & 0x20) == 0x20);
                    evtEffects.SetItemChecked(1, (evc.Param2 & 0x40) == 0x40);
                    evtEffects.SetItemChecked(2, (evc.Param2 & 0x80) == 0x80);
                    break;
                case 0x68:
                    groupBoxA.Text = commandText;
                    labelEvtA1.Text = "Level";
                    labelEvtA2.Text = "F / Z";
                    labelEvtA3.Text = "X";
                    labelEvtA4.Text = "Y";
                    evtNameA1.Items.AddRange(Lists.Numerize(Lists.Areas)); evtNameA1.Enabled = true;
                    evtNameA1.DropDownWidth = 500;
                    evtNameA2.Items.AddRange(Lists.Directions); evtNameA2.Enabled = true;
                    evtNumA1.Enabled = true; evtNumA1.Maximum = 511;
                    evtNumA2.Enabled = true; evtNumA2.Maximum = 31;
                    evtNumA3.Enabled = true;
                    evtNumA4.Enabled = true;
                    evtEffects.Items.AddRange(new object[] { "show message", "run entrance event", "Z + ½" });
                    evtEffects.Enabled = true;
                    //
                    evtNumA1.Value = Bits.GetShort(evc.Data, 1) & 0x1FF;
                    evtNameA1.SelectedIndex = (int)evtNumA1.Value;
                    evtNumA2.Value = evc.Param5 & 0x1F;
                    evtNameA2.SelectedIndex = (evc.Param5 & 0xE0) >> 5;
                    evtNumA3.Value = evc.Param3;
                    evtNumA4.Value = evc.Param4;
                    evtEffects.SetItemChecked(0, (evc.Param2 & 0x08) == 0x08);
                    evtEffects.SetItemChecked(1, (evc.Param2 & 0x80) == 0x80);
                    evtEffects.SetItemChecked(2, (evc.Param4 & 0x80) == 0x80);
                    break;
                case 0x6A:
                case 0x6B:
                    groupBoxA.Text = commandText;
                    labelEvtA1.Text = "Level";
                    labelEvtA3.Text = "Mod #";
                    evtNameA1.Items.AddRange(Lists.Numerize(Lists.Areas)); evtNameA1.Enabled = true;
                    evtNameA1.DropDownWidth = 500;
                    evtNumA1.Enabled = true; evtNumA1.Maximum = 511;
                    evtNumA3.Enabled = true; evtNumA3.Maximum = 63;
                    //
                    evtNumA1.Value = Bits.GetShort(evc.Data, 1) & 0x1FF;
                    evtNameA1.SelectedIndex = (int)evtNumA1.Value;
                    evtNumA3.Value = (evc.Param2 >> 1) & 0x3F;
                    //
                    if (evc.Opcode == 0x6A)
                        evtEffects.Items.AddRange(new object[] { "alternate" });
                    else
                        evtEffects.Items.AddRange(new object[] { "permanent" });
                    evtEffects.Enabled = true;
                    evtEffects.SetItemChecked(0, (evc.Param2 & 0x80) == 0x80);
                    break;

                #endregion

                #region Open window

                case 0x4C:      // Open, shop menu...
                    groupBoxA.Text = commandText;
                    labelEvtA1.Text = "Shop";
                    evtNameA1.Items.AddRange(Lists.Shops);
                    evtNameA1.DropDownWidth = 200; evtNameA1.Enabled = true;
                    evtNameA1.SelectedIndex = evc.Param1;
                    break;
                case 0x4F:      // Open, window...
                    groupBoxA.Text = commandText;
                    labelEvtA1.Text = "Menu";
                    evtNameA1.Items.AddRange(Lists.Menus);
                    evtNameA1.DropDownWidth = 200;
                    evtNameA1.Enabled = true;
                    evtNameA1.SelectedIndex = evc.Param1;
                    break;

                #endregion

                #region Dialogue

                case 0x60:
                    groupBoxA.Text = commandText;
                    labelEvtA1.Text = "Dialogue";
                    labelEvtA2.Text = "Show above";
                    evtNameA1.Items.AddRange(Model.GetDialogueStubs()); evtNameA1.Enabled = true;
                    evtNameA1.DropDownWidth = 250;
                    evtNumA1.Maximum = 4095; evtNumA1.Enabled = true;
                    evtNameA2.Items.AddRange(Lists.NPCs); evtNameA2.Enabled = true;
                    evtEffects.Items.AddRange(new string[] { "closable", "asynchronous", "multi-line", "background" });
                    evtEffects.Enabled = true;
                    //
                    evtNumA1.Value = Bits.GetShort(evc.Data, 1) & 0xFFF;
                    evtNameA1.SelectedIndex = (int)evtNumA1.Value;
                    evtNameA2.SelectedIndex = evc.Param3 & 0x3F;
                    evtEffects.SetItemChecked(0, (evc.Param2 & 0x20) == 0x20);
                    evtEffects.SetItemChecked(1, (evc.Param2 & 0x80) == 0x80);
                    evtEffects.SetItemChecked(2, (evc.Param3 & 0x40) == 0x40);
                    evtEffects.SetItemChecked(3, (evc.Param3 & 0x80) == 0x80);
                    break;
                case 0x61:
                    groupBoxA.Text = commandText;
                    labelEvtA1.Text = "Show above";
                    evtNameA1.Items.AddRange(Lists.NPCs); evtNameA1.Enabled = true;
                    evtEffects.Items.AddRange(new string[] { "closable", "asynchronous", "multi-line", "background" });
                    evtEffects.Enabled = true;
                    //
                    evtNameA1.SelectedIndex = evc.Param2 & 0x3F;
                    evtEffects.SetItemChecked(0, (evc.Param1 & 0x20) == 0x20);
                    evtEffects.SetItemChecked(1, (evc.Param1 & 0x80) == 0x80);
                    evtEffects.SetItemChecked(2, (evc.Param2 & 0x40) == 0x40);
                    evtEffects.SetItemChecked(3, (evc.Param2 & 0x80) == 0x80);
                    break;
                case 0x62:
                    groupBoxA.Text = commandText;
                    labelEvtA1.Text = "Dialogue";
                    labelEvtA3.Text = "Duration";
                    evtNameA1.Items.AddRange(Model.GetDialogueStubs()); evtNameA1.Enabled = true;
                    evtNameA1.DropDownWidth = 250;
                    evtNumA1.Maximum = 4095; evtNumA1.Enabled = true;
                    evtNumA3.Maximum = 3; evtNumA3.Enabled = true;
                    evtEffects.Items.AddRange(new string[] { "asynchronous" });
                    evtEffects.Enabled = true;
                    //
                    evtNumA1.Value = Bits.GetShort(evc.Data, 1) & 0xFFF;
                    evtNameA1.SelectedIndex = (int)evtNumA1.Value;
                    evtNumA3.Value = (evc.Param2 & 0x60) >> 5;
                    evtEffects.SetItemChecked(0, (evc.Param2 & 0x80) == 0x80);
                    break;
                case 0x63:
                    groupBoxB.Text = commandText;
                    evtEffects.Items.AddRange(new string[] { "closable", "asynchronous" }); evtEffects.Enabled = true;
                    //
                    evtEffects.SetItemChecked(0, (evc.Param1 & 0x20) == 0x20);
                    evtEffects.SetItemChecked(1, (evc.Param1 & 0x80) == 0x80);
                    break;
                case 0x66:
                case 0x67:
                    groupBoxA.Text = commandText;
                    //
                    labelEvtA3.Text = evc.Opcode == 0x66 ? "Jump to" : "If B, jump to";
                    evtNumA3.Maximum = 0xFFFF; evtNumA3.Hexadecimal = true; evtNumA3.Enabled = true;
                    evtNumA3.Value = Bits.GetShort(evc.Data, 1);
                    if (evc.Opcode == 0x67)
                    {
                        labelEvtA4.Text = "If C, jump to";
                        evtNumA4.Maximum = 0xFFFF; evtNumA4.Hexadecimal = true; evtNumA4.Enabled = true;
                        evtNumA4.Value = Bits.GetShort(evc.Data, 3);
                    }
                    break;

                #endregion

                #region Events

                case 0x40:
                    groupBoxA.Text = commandText;
                    labelEvtA3.Text = "Event";
                    evtNumA3.Maximum = 4095; evtNumA3.Enabled = true;
                    evtEffects.Items.AddRange(new string[] { "return on level exit", "bit 6", "bit 7" }); evtEffects.Enabled = true;
                    //
                    evtNumA3.Value = Bits.GetShort(evc.Data, 1) & 0xFFF;
                    evtEffects.SetItemChecked(0, (evc.Param2 & 0x20) == 0x20);
                    evtEffects.SetItemChecked(1, (evc.Param2 & 0x40) == 0x40);
                    evtEffects.SetItemChecked(2, (evc.Param2 & 0x80) == 0x80);
                    break;
                case 0x44:
                case 0x45:
                    groupBoxA.Text = commandText;
                    labelEvtA3.Text = "Event";
                    labelEvtA4.Text = "Timer memory";
                    evtNumA3.Maximum = 4095; evtNumA3.Enabled = true;
                    evtNumA4.Minimum = 0x701C; evtNumA4.Maximum = 0x7022;
                    evtNumA4.Increment = 2; evtNumA4.Hexadecimal = true; evtNumA4.Enabled = true;
                    evtEffects.Items.AddRange(new string[] { "bit 4", "bit 5" }); evtEffects.Enabled = true;
                    //
                    evtNumA3.Value = Bits.GetShort(evc.Data, 1) & 0xFFF;
                    evtNumA4.Value = (evc.Param2 >> 6) * 2 + 0x701C;
                    evtEffects.SetItemChecked(0, (evc.Param2 & 0x10) == 0x10);
                    evtEffects.SetItemChecked(1, (evc.Param2 & 0x20) == 0x20);
                    break;
                case 0x46:
                case 0x47:
                    groupBoxA.Text = commandText;
                    labelEvtA3.Text = "Timer memory";
                    evtNumA3.Minimum = 0x701C; evtNumA3.Maximum = 0x7022;
                    evtNumA3.Increment = 2; evtNumA3.Hexadecimal = true; evtNumA3.Enabled = true;
                    //
                    evtNumA3.Value = evc.Param1 * 2 + 0x701C;
                    break;
                case 0xD0:
                case 0xD1:
                    groupBoxA.Text = commandText;
                    labelEvtA3.Text = "Event";
                    evtNumA3.Maximum = 4095; evtNumA3.Enabled = true;
                    //
                    evtNumA3.Value = Bits.GetShort(evc.Data, 1) & 0xFFF;
                    break;
                case 0x4E:
                    groupBoxA.Text = commandText;
                    labelEvtA1.Text = "Category";
                    evtNameA1.Items.AddRange(Lists.Menus);
                    evtNameA1.DropDownWidth = 200;
                    evtNameA1.Enabled = true;
                    //
                    evtNameA1.SelectedIndex = evc.Param1;
                    switch (evtNameA1.SelectedIndex)
                    {
                        case 2: // open world location
                            labelEvtA2.Text = "Location";
                            evtNameA2.Items.AddRange(Lists.Numerize(Lists.Locations)); evtNameA2.Enabled = true;
                            evtNameA2.SelectedIndex = evc.Param2;
                            break;
                        case 3: // open shop menu
                            labelEvtA3.Text = "Shop menu";
                            evtNumA3.Maximum = 32; evtNumA3.Enabled = true;
                            evtNumA3.Value = evc.Param2;
                            break;
                        case 5: // items maxed out
                            labelEvtA2.Text = "Toss item";
                            evtNameA2.Items.AddRange(Items.Model.Names.Names); evtNameA2.Enabled = true;
                            evtNameA2.DrawMode = DrawMode.OwnerDrawFixed;
                            evtNumA2.Maximum = 255; evtNumA2.Enabled = true;
                            evtNumA2.Value = evc.Param2;
                            evtNameA2.SelectedIndex = Items.Model.Names.GetSortedIndex((int)evtNumA2.Value);
                            break;
                        case 7: // menu tutorial
                            labelEvtA2.Text = "Tutorial";
                            evtNameA2.Items.AddRange(new string[] { "How to equip", "How to use items", "How to switch allies", "How to play beetle mania" });
                            evtNameA2.Enabled = true;
                            evtNameA2.SelectedIndex = evc.Param2;
                            break;
                        case 16:    // world map event
                            labelEvtA2.Text = "Map event";
                            evtNameA2.Items.AddRange(new string[] { "Mario falls to pipehouse", "Mario returns to MK", "Mario takes Nimbus bus" });
                            evtNameA2.Enabled = true;
                            evtNameA2.SelectedIndex = evc.Param2;
                            break;
                    }
                    break;

                #endregion

                #region Jump to

                case 0xD2:
                case 0xD3:
                    groupBoxA.Text = commandText;
                    labelEvtA3.Text = "Address";
                    evtNumA3.Hexadecimal = true; evtNumA3.Maximum = 0xFFFF; evtNumA3.Enabled = true;
                    evtNumA3.Value = Bits.GetShort(evc.Data, 1);
                    break;
                case 0xD4:
                    groupBoxA.Text = commandText;
                    labelEvtA3.Text = "Count";
                    evtNumA3.Enabled = true;
                    evtNumA3.Value = evc.Param1;
                    break;
                case 0xD5:
                    groupBoxA.Text = commandText;
                    labelEvtA3.Text = "Frame timer";
                    evtNumA3.Maximum = 0xFFFF;
                    evtNumA3.Enabled = true;
                    evtNumA3.Value = Bits.GetShort(evc.Data, 1);
                    break;

                #endregion

                #region Screen effects

                case 0x72:
                case 0x73:
                case 0x76:
                case 0x77:
                    groupBoxA.Text = commandText;
                    labelEvtA3.Text = "Duration";
                    evtNumA3.Enabled = true;
                    //
                    evtNumA3.Value = evc.Param1;
                    break;
                case 0x78:
                case 0x79:
                case 0x83:
                    groupBoxA.Text = commandText;
                    labelEvtA1.Text = "Color";
                    evtNameA1.Items.AddRange(Lists.ColorNames); evtNameA1.Enabled = true;
                    if (evc.Opcode != 0x83)
                    {
                        labelEvtA3.Text = "Duration";
                        evtNumA3.Enabled = true;
                        evtNumA3.Value = evc.Param1;
                        evtNameA1.SelectedIndex = evc.Param2;
                    }
                    else
                        evtNameA1.SelectedIndex = evc.Param1;
                    break;
                case 0x80:
                    groupBoxA.Text = commandText;
                    labelEvtA1.Text = "Red";
                    labelEvtA2.Text = "Green";
                    labelEvtA3.Text = "Blue";
                    labelEvtA4.Text = "Speed";
                    groupBoxB.Text = "Tint layers";
                    evtNumA1.Enabled = true;
                    evtNumA2.Enabled = true;
                    evtNumA3.Enabled = true;
                    evtNumA4.Enabled = true;
                    evtEffects.Items.AddRange(Lists.LayerNames); evtEffects.Enabled = true;
                    double multiplier = 8; // 8;
                    ushort color = Bits.GetShort(evc.Data, 1);
                    evtNumA1.Value = (byte)((color % 0x20) * multiplier);
                    evtNumA2.Value = (byte)(((color >> 5) % 0x20) * multiplier);
                    evtNumA3.Value = (byte)(((color >> 10) % 0x20) * multiplier);
                    evtNumA4.Value = evc.Param4;
                    for (int i = 1, j = 0; j < 8; i *= 2, j++)
                        evtEffects.SetItemChecked(j, (evc.Param3 & i) == i);
                    break;
                case 0x81:
                    groupBoxB.Text = "Mainscreen / Subscreen / Color math";
                    evtEffects.ColumnWidth = 66;
                    evtEffects.Items.AddRange(new string[]
                    {
                        "L1","L2","L3","NPC",
                        "L1","L2","L3","NPC",
                        "L1","L2","L3","NPC", "BG", "½ intensity", "Minus subscreen"
                    });
                    evtEffects.Enabled = true;
                    evtEffects.SetItemChecked(0, (evc.Param1 & 0x01) == 0x01);
                    evtEffects.SetItemChecked(1, (evc.Param1 & 0x02) == 0x02);
                    evtEffects.SetItemChecked(2, (evc.Param1 & 0x04) == 0x04);
                    evtEffects.SetItemChecked(3, (evc.Param1 & 0x10) == 0x10);
                    evtEffects.SetItemChecked(4, (evc.Param2 & 0x01) == 0x01);
                    evtEffects.SetItemChecked(5, (evc.Param2 & 0x02) == 0x02);
                    evtEffects.SetItemChecked(6, (evc.Param2 & 0x04) == 0x04);
                    evtEffects.SetItemChecked(7, (evc.Param2 & 0x10) == 0x10);
                    evtEffects.SetItemChecked(8, (evc.Param3 & 0x01) == 0x01);
                    evtEffects.SetItemChecked(9, (evc.Param3 & 0x02) == 0x01);
                    evtEffects.SetItemChecked(10, (evc.Param3 & 0x04) == 0x01);
                    evtEffects.SetItemChecked(11, (evc.Param3 & 0x08) == 0x01);
                    evtEffects.SetItemChecked(12, (evc.Param3 & 0x20) == 0x20);
                    evtEffects.SetItemChecked(13, (evc.Param3 & 0x40) == 0x40);
                    evtEffects.SetItemChecked(14, (evc.Param3 & 0x80) == 0x80);
                    break;
                case 0x84:
                    groupBoxA.Text = commandText;
                    labelEvtA3.Text = "Pixel size";
                    labelEvtA4.Text = "Duration";
                    groupBoxB.Text = "Apply to layers";
                    evtNumA3.Maximum = 15; evtNumA3.Enabled = true;
                    evtNumA4.Maximum = 63; evtNumA4.Enabled = true;
                    evtEffects.Items.AddRange(new string[] { "L1", "L2", "L3", "L4" }); evtEffects.Enabled = true;
                    //
                    evtNumA3.Value = evc.Param1 >> 4;
                    evtNumA4.Value = evc.Param2 & 0x3F;
                    for (int i = 1, j = 0; j < 4; i *= 2, j++)
                        evtEffects.SetItemChecked(j, (evc.Param1 & i) == i);
                    break;
                case 0x89:
                    groupBoxA.Text = commandText;
                    labelEvtA1.Text = "Type";
                    labelEvtA2.Text = "Duration";
                    labelEvtA3.Text = "Palette set";
                    labelEvtA4.Text = "Palette row";
                    evtNameA1.Items.AddRange(new string[] { "nothing", "glow", "set to", "fade to" });
                    evtNameA1.Enabled = true;
                    evtNumA2.Maximum = 15; evtNumA2.Enabled = true;
                    evtNumA3.Enabled = true;
                    evtNumA4.Maximum = 16; evtNumA4.Enabled = true;
                    evtEffects.Enabled = true;
                    //
                    switch (evc.Param1 & 0xE0)
                    {
                        case 0x60: evtNameA1.SelectedIndex = 1; break;
                        case 0xC0: evtNameA1.SelectedIndex = 2; break;
                        case 0xE0: evtNameA1.SelectedIndex = 3; break;
                        default: evtNameA1.SelectedIndex = 0; break;
                    }
                    evtNumA2.Value = evc.Param1 & 0x0F;
                    evtNumA3.Value = evc.Param3;
                    evtNumA4.Value = evc.Param2;
                    break;
                case 0x8A:
                    groupBoxA.Text = commandText;
                    labelEvtA3.Text = "Palette set";
                    labelEvtA4.Text = "Row 0 to";
                    evtNumA3.Enabled = true;
                    evtNumA4.Maximum = 16; evtNumA4.Minimum = 1; evtNumA4.Enabled = true;
                    //
                    evtNumA3.Value = evc.Param2;
                    evtNumA4.Value = (evc.Param1 >> 4) + 1;
                    break;
                case 0x87:
                case 0x8F:
                    groupBoxA.Text = commandText;
                    labelEvtA1.Text = "Object";
                    labelEvtA3.Text = "Width";
                    labelEvtA4.Text = "Speed";
                    evtNameA1.Items.AddRange(Lists.NPCs); evtNameA1.Enabled = true;
                    evtNumA3.Enabled = true;
                    evtNumA4.Enabled = true;
                    //
                    evtNameA1.SelectedIndex = evc.Param1;
                    evtNumA3.Value = evc.Param2;
                    evtNumA4.Value = evc.Param3;
                    break;

                #endregion

                #region Playback audio

                case 0x90:
                case 0x91:
                case 0x92:
                    groupBoxA.Text = commandText;
                    labelEvtA1.Text = "Music";
                    evtNameA1.Items.AddRange(Lists.Numerize(Lists.SPCTracks)); evtNameA1.Enabled = true;
                    evtNameA1.DropDownWidth = 250;
                    //
                    evtNameA1.SelectedIndex = evc.Param1;
                    break;
                case 0x95:
                    groupBoxA.Text = commandText;
                    labelEvtA3.Text = "Time stretch";
                    labelEvtA4.Text = "To volume";
                    evtNumA3.Enabled = true;
                    evtNumA4.Enabled = true;
                    //
                    evtNumA3.Value = evc.Param1;
                    evtNumA4.Value = evc.Param2;
                    break;
                case 0x97:
                    groupBoxA.Text = commandText;
                    labelEvtA1.Text = "Type";
                    labelEvtA3.Text = "Tempo change";
                    labelEvtA4.Text = "Time stretch";
                    evtNameA1.Items.AddRange(new string[] { "slow down", "speed up" }); evtNameA1.Enabled = true;
                    evtNumA3.Enabled = true; evtNumA3.Maximum = 127;
                    evtNumA4.Enabled = true;
                    //
                    evtNameA1.SelectedIndex = (evc.Param2 & 0x80) == 0x80 ? 1 : 0;
                    evtNumA3.Value = Math.Abs((sbyte)evc.Param2);
                    evtNumA4.Value = evc.Param1;
                    break;
                case 0x98:
                    groupBoxA.Text = commandText;
                    labelEvtA1.Text = "Type";
                    labelEvtA3.Text = "Pitch change";
                    labelEvtA4.Text = "Time stretch";
                    evtNameA1.Items.AddRange(new string[] { "raise", "lower" }); evtNameA1.Enabled = true;
                    evtNumA3.Enabled = true; evtNumA3.Maximum = 127;
                    evtNumA4.Enabled = true;
                    //
                    evtNameA1.SelectedIndex = (evc.Param2 & 0x80) == 0x80 ? 1 : 0;
                    evtNumA3.Value = Math.Abs((sbyte)evc.Param2);
                    evtNumA4.Value = evc.Param1;
                    break;
                case 0x9C:
                    groupBoxA.Text = commandText;
                    labelEvtA1.Text = "Sound";
                    evtNameA1.Items.AddRange(Lists.Numerize(Lists.SPCEventSounds)); evtNameA1.Enabled = true;
                    evtNameA1.DropDownWidth = 250;
                    //
                    evtNameA1.SelectedIndex = evc.Param1;
                    break;
                case 0x9D:
                    groupBoxA.Text = commandText;
                    labelEvtA1.Text = "Sound";
                    labelEvtA3.Text = "Balance";
                    evtNameA1.Items.AddRange(Lists.Numerize(Lists.SPCEventSounds)); evtNameA1.Enabled = true;
                    evtNameA1.DropDownWidth = 250;
                    evtNumA3.Enabled = true;
                    evtNameA1.SelectedIndex = evc.Param1;
                    evtNumA3.Value = evc.Param2;
                    break;
                case 0x9E:
                    groupBoxA.Text = commandText;
                    labelEvtA3.Text = "Time stretch";
                    labelEvtA4.Text = "To volume";
                    evtNumA3.Enabled = true;
                    evtNumA4.Enabled = true;
                    evtNumA3.Value = evc.Param1;
                    evtNumA4.Value = evc.Param2;
                    break;

                #endregion

                #region Memory

                case 0xA0:
                case 0xA1:
                case 0xA2:
                case 0xA4:
                case 0xA5:
                case 0xA6:
                    groupBoxA.Text = commandText;
                    labelEvtA3.Text = "Memory";
                    labelEvtA4.Text = "Bit";
                    evtNumA3.Hexadecimal = true;
                    evtNumA3.Maximum = 0x709F; evtNumA3.Minimum = 0x7040;
                    evtNumA3.Enabled = true;
                    evtNumA4.Maximum = 7; evtNumA4.Enabled = true;
                    //
                    if (evc.Opcode < 0xA4)
                        evtNumA3.Value = ((((evc.Opcode - 0xA0) * 0x100) + evc.Param1) >> 3) + 0x7040;
                    else
                        evtNumA3.Value = ((((evc.Opcode - 0xA4) * 0x100) + evc.Param1) >> 3) + 0x7040;
                    evtNumA4.Value = evc.Param1 & 7;
                    break;
                case 0xA8:
                case 0xA9:
                    groupBoxA.Text = commandText;
                    labelEvtA3.Text = "Memory";
                    labelEvtA4.Text = "Value";
                    evtNumA3.Hexadecimal = true;
                    evtNumA3.Maximum = 0x719F; evtNumA3.Minimum = 0x70A0;
                    evtNumA3.Enabled = true;
                    evtNumA4.Enabled = true;
                    //
                    evtNumA3.Value = evc.Param1 + 0x70A0;
                    evtNumA4.Value = evc.Param2;
                    break;
                case 0xAA:
                case 0xAB:
                    groupBoxA.Text = commandText;
                    labelEvtA3.Text = "Memory";
                    evtNumA3.Hexadecimal = true;
                    evtNumA3.Maximum = 0x719F; evtNumA3.Minimum = 0x70A0;
                    evtNumA3.Enabled = true;
                    //
                    evtNumA3.Value = evc.Param1 + 0x70A0;
                    break;
                case 0xB0:
                case 0xB1:
                case 0xC2:
                    groupBoxA.Text = commandText;
                    labelEvtA3.Text = "Memory";
                    labelEvtA4.Text = "Value";
                    evtNumA3.Hexadecimal = true; evtNumA3.Increment = 2;
                    evtNumA3.Maximum = 0x71FE; evtNumA3.Minimum = 0x7000;
                    evtNumA3.Enabled = true;
                    evtNumA4.Maximum = 65535; evtNumA4.Enabled = true;
                    //
                    evtNumA3.Value = (evc.Param1 * 2) + 0x7000;
                    evtNumA4.Value = Bits.GetShort(evc.Data, 2);
                    break;
                case 0xB2:
                case 0xB3:
                case 0xD6:
                case 0xBB:
                    groupBoxA.Text = commandText;
                    labelEvtA3.Text = "Memory";
                    evtNumA3.Hexadecimal = true; evtNumA3.Increment = 2;
                    evtNumA3.Maximum = 0x71FE; evtNumA3.Minimum = 0x7000;
                    evtNumA3.Enabled = true;
                    //
                    evtNumA3.Value = (evc.Param1 * 2) + 0x7000;
                    break;
                case 0xB5:
                    groupBoxA.Text = commandText;
                    labelEvtA3.Text = "Memory";
                    evtNumA3.Hexadecimal = true;
                    evtNumA3.Maximum = 0x719F; evtNumA3.Minimum = 0x70A0;
                    evtNumA3.Enabled = true;
                    evtNumA3.Value = evc.Param1 + 0x70A0;
                    break;
                case 0xB7:
                    groupBoxA.Text = commandText;
                    labelEvtA3.Text = "Memory";
                    labelEvtA4.Text = "Number";
                    evtNumA3.Hexadecimal = true; evtNumA3.Increment = 2;
                    evtNumA3.Maximum = 0x71FE; evtNumA3.Minimum = 0x7000;
                    evtNumA3.Enabled = true;
                    evtNumA4.Maximum = 65535; evtNumA4.Enabled = true;
                    //
                    evtNumA3.Value = (evc.Param1 * 2) + 0x7000;
                    evtNumA4.Value = Bits.GetShort(evc.Data, 2);
                    break;
                case 0xBC:
                case 0xBD:
                    groupBoxA.Text = commandText;
                    labelEvtA3.Text = "Memory A";
                    labelEvtA4.Text = "Memory B";
                    evtNumA3.Hexadecimal = true; evtNumA3.Increment = 2;
                    evtNumA3.Maximum = 0x71FE; evtNumA3.Minimum = 0x7000;
                    evtNumA3.Enabled = true;
                    evtNumA4.Hexadecimal = true; evtNumA4.Increment = 2;
                    evtNumA4.Maximum = 0x71FE; evtNumA4.Minimum = 0x7000;
                    evtNumA4.Enabled = true;
                    //
                    evtNumA3.Value = (evc.Param1 * 2) + 0x7000;
                    evtNumA4.Value = (evc.Param2 * 2) + 0x7000;
                    break;
                case 0xD8:
                case 0xD9:
                case 0xDA:
                case 0xDC:
                case 0xDD:
                case 0xDE:
                    groupBoxA.Text = commandText;
                    labelEvtA3.Text = "Memory";
                    labelEvtA4.Text = "Bit";
                    labelEvtC1.Text = "Jump to";
                    evtNumA3.Hexadecimal = true;
                    evtNumA3.Maximum = 0x709F; evtNumA3.Minimum = 0x7040;
                    evtNumA3.Enabled = true;
                    evtNumA4.Maximum = 7; evtNumA4.Enabled = true;
                    evtNumC1.Hexadecimal = true; evtNumC1.Maximum = 0xFFFF; evtNumC1.Enabled = true;
                    //
                    if (evc.Opcode < 0xDC)
                        evtNumA3.Value = ((((evc.Opcode - 0xD8) * 0x100) + evc.Param1) >> 3) + 0x7040;
                    else
                        evtNumA3.Value = ((((evc.Opcode - 0xDC) * 0x100) + evc.Param1) >> 3) + 0x7040;
                    evtNumA4.Value = evc.Param1 & 7;
                    evtNumC1.Value = Bits.GetShort(evc.Data, 2);
                    break;
                case 0xE0:
                case 0xE1:
                    groupBoxA.Text = commandText;
                    labelEvtA3.Text = "Memory";
                    labelEvtA4.Text = "Value";
                    labelEvtC1.Text = "Jump to";
                    evtNumA3.Hexadecimal = true;
                    evtNumA3.Maximum = 0x719F; evtNumA3.Minimum = 0x70A0;
                    evtNumA3.Enabled = true;
                    evtNumA4.Enabled = true;
                    evtNumC1.Hexadecimal = true; evtNumC1.Maximum = 0xFFFF; evtNumC1.Enabled = true;
                    //
                    evtNumA3.Value = evc.Param1 + 0x70A0;
                    evtNumA4.Value = evc.Param2;
                    evtNumC1.Value = Bits.GetShort(evc.Data, 3);
                    break;
                case 0xE4:
                case 0xE5:
                    groupBoxA.Text = commandText;
                    labelEvtA3.Text = "Memory";
                    labelEvtA4.Text = "Value";
                    labelEvtC1.Text = "Jump to";
                    evtNumA3.Hexadecimal = true; evtNumA3.Increment = 2;
                    evtNumA3.Maximum = 0x71FE; evtNumA3.Minimum = 0x7000;
                    evtNumA3.Enabled = true;
                    evtNumA4.Maximum = 65535; evtNumA4.Enabled = true;
                    evtNumC1.Hexadecimal = true; evtNumC1.Maximum = 0xFFFF; evtNumC1.Enabled = true;
                    //
                    evtNumA3.Value = (evc.Param1 * 2) + 0x7000;
                    evtNumA4.Value = Bits.GetShort(evc.Data, 2);
                    evtNumC1.Value = Bits.GetShort(evc.Data, 4);
                    break;
                case 0xE8:
                    groupBoxA.Text = commandText;
                    labelEvtA3.Text = "Jump to";
                    evtNumA3.Hexadecimal = true; evtNumA3.Maximum = 0xFFFF; evtNumA3.Enabled = true;
                    //
                    evtNumA3.Value = Bits.GetShort(evc.Data, 1);
                    break;
                case 0xE9:
                    groupBoxA.Text = commandText;
                    labelEvtA3.Text = "Jump to";
                    labelEvtA4.Text = "Else jump to";
                    evtNumA3.Hexadecimal = true; evtNumA3.Maximum = 0xFFFF; evtNumA3.Enabled = true;
                    evtNumA4.Hexadecimal = true; evtNumA4.Maximum = 0xFFFF; evtNumA4.Enabled = true;
                    //
                    evtNumA3.Value = Bits.GetShort(evc.Data, 1);
                    evtNumA4.Value = Bits.GetShort(evc.Data, 3);
                    break;

                #endregion

                #region Memory $7000

                case 0x38:
                    groupBoxA.Text = commandText;
                    labelEvtA3.Text = "Slot";
                    evtNumA3.Maximum = 4; evtNumA3.Enabled = true;
                    //
                    if (evc.Param1 < 8) evc.Param1 = 8;
                    evtNumA3.Value = evc.Param1 - 8;
                    break;
                case 0xAC:
                case 0xAD:
                case 0xB6:
                case 0xC0:
                    groupBoxA.Text = commandText;
                    labelEvtA3.Text = "Value";
                    evtNumA3.Maximum = 65535; evtNumA3.Enabled = true;
                    evtNumA3.Value = Bits.GetShort(evc.Data, 1);
                    break;
                case 0xB4:
                    groupBoxA.Text = commandText;
                    labelEvtA3.Text = "Memory";
                    evtNumA3.Hexadecimal = true;
                    evtNumA3.Maximum = 0x719F; evtNumA3.Minimum = 0x70A0;
                    evtNumA3.Enabled = true;
                    evtNumA3.Value = evc.Param1 + 0x70A0;
                    break;
                case 0xB8:
                case 0xB9:
                case 0xBA:
                case 0xC1:
                    groupBoxA.Text = commandText;
                    labelEvtA3.Text = "Memory";
                    evtNumA3.Hexadecimal = true; evtNumA3.Increment = 2;
                    evtNumA3.Maximum = 0x71FE; evtNumA3.Minimum = 0x7000;
                    evtNumA3.Enabled = true;
                    evtNumA3.Value = (evc.Param1 * 2) + 0x7000;
                    break;
                case 0xC4:
                case 0xC5:
                case 0xC6:
                    groupBoxA.Text = commandText;
                    labelEvtA1.Text = "Object";
                    labelEvtA2.Text = "Units";
                    evtNameA1.Items.AddRange(Lists.NPCs); evtNameA1.Enabled = true;
                    evtNameA2.Items.AddRange(new string[] { "pixel", "isometric" }); evtNameA2.Enabled = true;
                    evtNameA1.SelectedIndex = evc.Param1 & 0x3F;
                    evtNameA2.SelectedIndex = (evc.Param1 & 0x40) >> 6;
                    break;
                case 0xC7:
                case 0xC8:
                case 0xC9:
                    groupBoxA.Text = commandText;
                    labelEvtA1.Text = "Object";
                    evtNameA1.Items.AddRange(Lists.NPCs); evtNameA1.Enabled = true;
                    //
                    evtNameA1.SelectedIndex = evc.Param1;
                    break;
                case 0xDB:
                case 0xDF:
                    groupBoxA.Text = commandText;
                    labelEvtA3.Text = "Memory";
                    evtNumA3.Hexadecimal = true; evtNumA3.Maximum = 0xFFFF; evtNumA3.Enabled = true;
                    evtNumA3.Value = Bits.GetShort(evc.Data, 1);
                    break;
                case 0xE2:
                case 0xE3:
                    groupBoxA.Text = commandText;
                    labelEvtA3.Text = "Value";
                    labelEvtA4.Text = "Jump to";
                    evtNumA3.Maximum = 65535; evtNumA3.Enabled = true;
                    evtNumA4.Hexadecimal = true; evtNumA4.Maximum = 0xFFFF; evtNumA4.Enabled = true;
                    //
                    evtNumA3.Value = Bits.GetShort(evc.Data, 1);
                    evtNumA4.Value = Bits.GetShort(evc.Data, 3);
                    break;
                case 0xE6:
                case 0xE7:
                    groupBoxB.Text = commandText;
                    evtEffects.ColumnWidth = 66;
                    evtEffects.Items.AddRange(new string[]{
                        "bit 0","bit 1","bit 2","bit 3","bit 4","bit 5","bit 6","bit 7",
                        "bit 8","bit 9","bit 10","bit 11","bit 12","bit 13","bit 14","bit 15"});
                    evtEffects.Enabled = true;
                    labelEvtC1.Text = "Jump to";
                    evtNumC1.Hexadecimal = true; evtNumC1.Maximum = 0xFFFF; evtNumC1.Enabled = true;
                    //
                    for (int b = 1, i = 0; i < 16; b *= 2, i++)
                        evtEffects.SetItemChecked(i, (Bits.GetShort(evc.Data, 1) & b) == b);
                    evtNumC1.Value = Bits.GetShort(evc.Data, 3);
                    break;
                case 0xEA:
                case 0xEB:
                case 0xEC:
                case 0xED:
                case 0xEE:
                case 0xEF:
                    groupBoxA.Text = commandText;
                    labelEvtA3.Text = "Jump to";
                    evtNumA3.Hexadecimal = true; evtNumA3.Maximum = 0xFFFF; evtNumA3.Enabled = true;
                    evtNumA3.Value = Bits.GetShort(evc.Data, 1);
                    break;

                #endregion

                #region Pause script

                case 0xF0:
                    groupBoxA.Text = commandText;
                    labelEvtA3.Text = "Frames";
                    evtNumA3.Enabled = true;
                    evtNumA3.Minimum = 1; evtNumA3.Maximum = 256;
                    evtNumA3.Value = evc.Param1 + 1;
                    break;
                case 0xF1:
                    groupBoxA.Text = commandText;
                    labelEvtA3.Text = "Frames";
                    evtNumA3.Minimum = 1; evtNumA3.Maximum = 65536; evtNumA3.Enabled = true;
                    evtNumA3.Value = Bits.GetShort(evc.Data, 1) + 1;
                    break;

                #endregion

                default:

                    #region Action queue

                    // Same for all sub-indexes, so no need to do a switch for sub
                    if (evc.Opcode <= 0x2F)
                    {
                        groupBoxA.Text = commandText;
                        labelEvtA1.Text = "Object";
                        labelEvtA2.Text = "Queue";
                        evtNameA1.Items.AddRange(Lists.NPCs);
                        evtNameA2.Items.AddRange(new string[]
                        {                                           // OPTIONS:
                        "action queue",                   // 0x00 - 0x7F
                        "start embedded action script",         // 0xF0
                        "start embedded action script",         // 0xF1
                        "set action script (sync)",             // 0xF2
                        "set action script (async)",         // 0xF3
                        "set temp action script (sync)",        // 0xF4
                        "set temp action script (async)",    // 0xF5
                        "un-sync action script",                // 0xF6
                        "summon to current level @ Mario's coords",         // 0xF7
                        "summon to current level",                          // 0xF8
                        "remove from current level",                        // 0xF9
                        "pause action script",                  // 0xFA
                        "resume action script",                 // 0xFB
                        "enable trigger",                       // 0xFC
                        "disable trigger",                      // 0xFD
                        "stop embedded action script",          // 0xFE
                        "reset coords"          // 0xFF
                        });
                        evtNameA2.DropDownWidth = 210;
                        evtNameA1.Enabled = true;
                        evtNameA2.Enabled = true;
                        evtNameA1.SelectedIndex = evc.Opcode;
                        //
                        if (evc.Param1 >= 0xF2)
                        {
                            evtNameA2.SelectedIndex = evc.Param1 - 0xEF;
                        }
                        else evtNameA2.SelectedIndex = 0;
                        if (evc.Param1 >= 0xF2 && evc.Param1 <= 0xF5)
                        {
                            labelEvtA3.Text = "Action #";
                            evtNumA3.Maximum = 0x3FF; evtNumA3.Enabled = true;
                            evtNumA3.Value = Bits.GetShort(evc.Data, 2);
                        }
                        else if (evc.Param1 < 0xF2)
                        {
                            evtEffects.Items.AddRange(new string[] { "asynchronous" }); evtEffects.Enabled = true;
                            evtEffects.SetItemChecked(0, (evc.Param1 & 0x80) == 0x80);
                        }
                    }

                    #endregion

                    else if (evc.Opcode == 0xFD)
                    {
                        switch (evc.Param1)
                        {
                            #region Objects

                            case 0x33:          // If running action script, object...
                            case 0x34:         // If underwater, object...
                            case 0x3D:         // If in air, object...
                                groupBoxA.Text = commandText;
                                labelEvtA1.Text = "Object";
                                labelEvtA3.Text = "Jump to";
                                evtNameA1.Items.AddRange(Lists.NPCs); evtNameA1.Enabled = true;
                                evtNumA3.Hexadecimal = true; evtNumA3.Maximum = 0xFFFF; evtNumA3.Enabled = true;
                                //
                                evtNameA1.SelectedIndex = evc.Param2;
                                evtNumA3.Value = Bits.GetShort(evc.Data, 3);
                                break;
                            case 0x3E:
                                groupBoxA.Text = commandText;
                                labelEvtA1.Text = "Packet";
                                labelEvtA2.Text = "Event #";
                                groupBoxC.Text = "If null...";
                                labelEvtC1.Text = "Jump to";
                                evtNameA1.Items.AddRange(Lists.Numerize(Lists.NPCPackets)); evtNameA1.Enabled = true;
                                evtNameA1.DropDownWidth = 200;
                                evtNumA2.Maximum = 4095; evtNumA2.Enabled = true;
                                evtNumC1.Hexadecimal = true; evtNumC1.Maximum = 0xFFFF; evtNumC1.Enabled = true;
                                //
                                evtNameA1.SelectedIndex = evc.Param2;
                                evtNumA2.Value = Bits.GetShort(evc.Data, 3) & 0xFFF;
                                evtNumC1.Value = Bits.GetShort(evc.Data, 5);
                                break;

                            #endregion

                            #region Menus

                            case 0x4C:
                                groupBoxA.Text = commandText;
                                labelEvtA1.Text = "Menu";
                                evtNameA1.Items.AddRange(Lists.Tutorials); evtNameA1.Enabled = true;
                                evtNameA1.SelectedIndex = evc.Param2;
                                break;

                            #endregion

                            #region Events

                            case 0x46:
                                groupBoxA.Text = commandText;
                                labelEvtA3.Text = "Event #";
                                evtNumA3.Maximum = 4095;
                                evtNumA3.Enabled = true;
                                evtNumA3.Value = Bits.GetShort(evc.Data, 2);
                                break;
                            case 0x4D:
                                groupBoxA.Text = commandText;
                                labelEvtA3.Text = "Star #";
                                evtNumA3.Maximum = 7; evtNumA3.Minimum = 1; evtNumA3.Enabled = true;
                                if (evc.Param2 < 1)
                                    evc.Param2 = 1;
                                evtNumA3.Value = evc.Param2;
                                break;
                            case 0x66:
                                groupBoxA.Text = commandText;
                                labelEvtA1.Text = "Title";
                                labelEvtA3.Text = "Y";
                                evtNameA1.Items.AddRange(new string[] { "Super Mario", "Princess Toadstool", "King Bowser", "Mallow", "Geno", "In..." });
                                evtNameA1.Enabled = true;
                                evtNumA3.Enabled = true;
                                evtNameA1.SelectedIndex = evc.Param3;
                                evtNumA3.Value = evc.Param2;
                                break;

                            #endregion

                            #region Playback audio

                            case 0x94:
                                groupBoxB.Text = commandText;
                                evtEffects.Items.AddRange(new string[] { "0", "1", "2", "3", "4", "5", "6", "7" });
                                evtEffects.Enabled = true;
                                for (int i = 1, j = 0; j < 8; i *= 2, j++)
                                    evtEffects.SetItemChecked(j, (evc.Param2 & i) == i);
                                break;
                            case 0x96:
                            case 0x97:
                                groupBoxA.Text = commandText;
                                labelEvtA3.Text = "Value";
                                evtNumA3.Enabled = true;
                                evtNumA3.Value = evc.Param2;
                                labelEvtA4.Text = "Jump to";
                                evtNumA4.Enabled = true;
                                evtNumA4.Maximum = 0xFFFF;
                                evtNumA4.Hexadecimal = true;
                                evtNumA4.Value = Bits.GetShort(evc.Data, 3);
                                break;
                            case 0x9C:
                                groupBoxA.Text = commandText;
                                labelEvtA1.Text = "Sound";
                                evtNameA1.Items.AddRange(Lists.Numerize(Lists.SPCEventSounds)); evtNameA1.Enabled = true;
                                evtNameA1.SelectedIndex = evc.Param2;
                                break;

                            #endregion

                            #region Memory

                            case 0xB6:
                                groupBoxA.Text = commandText;
                                labelEvtA3.Text = "Memory";
                                labelEvtA4.Text = "Shift";
                                evtNumA3.Hexadecimal = true; evtNumA3.Increment = 2;
                                evtNumA3.Maximum = 0x71FE; evtNumA3.Minimum = 0x7000;
                                evtNumA3.Enabled = true;
                                evtNumA4.Maximum = 256; evtNumA4.Minimum = 1; evtNumA4.Enabled = true;
                                evtNumA3.Value = (evc.Param2 * 2) + 0x7000;
                                evtNumA4.Value = (evc.Param3 ^ 0xFF) + 1;
                                break;
                            case 0xB7:
                                groupBoxA.Text = commandText;
                                labelEvtA3.Text = "Memory";
                                evtNumA3.Hexadecimal = true; evtNumA3.Increment = 2;
                                evtNumA3.Maximum = 0x71FE; evtNumA3.Minimum = 0x7000;
                                evtNumA3.Enabled = true;
                                evtNumA3.Value = (evc.Param2 * 2) + 0x7000;
                                break;

                            #endregion

                            #region Memory $7000

                            case 0x58:
                                groupBoxA.Text = commandText;
                                labelEvtA1.Text = "Item";
                                evtNameA1.Items.AddRange(Items.Model.Names.Names); evtNameA1.Enabled = true;
                                evtNameA1.DrawMode = DrawMode.OwnerDrawFixed;
                                evtNumA1.Maximum = 255; evtNumA1.Enabled = true;
                                evtNumA1.Value = evc.Param2;
                                evtNameA1.SelectedIndex = Items.Model.Names.GetSortedIndex((int)evtNumA1.Value);
                                break;
                            case 0x5D:
                                groupBoxA.Text = commandText;
                                labelEvtA1.Text = "Character";
                                labelEvtA2.Text = "Type";
                                evtNameA1.Items.AddRange(Lists.CharacterNames); evtNameA1.Enabled = true;
                                evtNameA2.Items.AddRange(new string[] { "weapon", "armor", "accessory" });
                                evtNameA2.Enabled = true;
                                evtNameA1.SelectedIndex = evc.Param2;
                                evtNameA2.SelectedIndex = evc.Param3;
                                break;
                            case 0xAC:
                                groupBoxA.Text = commandText;
                                labelEvtA3.Text = "Memory";
                                evtNumA3.Hexadecimal = true;
                                evtNumA3.Maximum = 0x7FFFFF; evtNumA3.Minimum = 0x7FF800;
                                evtNumA3.Enabled = true;
                                evtNumA3.Value = Bits.GetShort(evc.Data, 2) + 0x7FF800;
                                break;
                            case 0xB0:
                            case 0xB1:
                            case 0xB2:
                                groupBoxA.Text = commandText;
                                labelEvtA3.Text = "Value";
                                evtNumA3.Maximum = 65535; evtNumA3.Enabled = true;
                                evtNumA3.Value = Bits.GetShort(evc.Data, 2);
                                break;
                            case 0xB3:
                            case 0xB4:
                            case 0xB5:
                                groupBoxA.Text = commandText;
                                labelEvtA3.Text = "Memory";
                                evtNumA3.Hexadecimal = true; evtNumA3.Increment = 2;
                                evtNumA3.Maximum = 0x71FE; evtNumA3.Minimum = 0x7000;
                                evtNumA3.Enabled = true;
                                evtNumA3.Value = (evc.Param2 * 2) + 0x7000;
                                break;
                            case 0xF0:
                                groupBoxA.Text = commandText;
                                labelEvtA1.Text = "Level";
                                labelEvtA2.Text = "Object";
                                labelEvtC1.Text = "Jump to";
                                evtNameA1.Items.AddRange(Lists.Numerize(Lists.Areas)); evtNameA1.Enabled = true;
                                evtNameA1.DropDownWidth = 500;
                                evtNameA2.Items.AddRange(Lists.NPCs); evtNameA2.Enabled = true;
                                evtNumA1.Enabled = true; evtNumA1.Maximum = 511;
                                evtEffects.Items.AddRange(new object[] { "is enabled" });
                                evtEffects.Enabled = true;
                                evtNumC1.Enabled = true; evtNumC1.Hexadecimal = true; evtNumC1.Maximum = 0xFFFF;
                                //
                                evtNumA1.Value = Bits.GetShort(evc.Data, 2) & 0x1FF;
                                evtNameA1.SelectedIndex = (int)evtNumA1.Value;
                                evtNameA2.SelectedIndex = (evc.Param3 >> 1) & 0x3F;
                                evtEffects.SetItemChecked(0, (evc.Param3 & 0x80) == 0x80);
                                evtNumC1.Value = Bits.GetShort(evc.Data, 4);
                                break;

                            #endregion

                            default: break;
                        }
                    }

                    break;
            }
            panelCommand.ResumeDrawing();
            //
            this.Updating = false;
            //
            ArrangeControls();
        }
        /// <summary>
        /// Writes the values of the controls to the command's data.
        /// </summary>
        /// <param name="command"></param>
        public void WriteToEventCommand()
        {
            switch (evc.Opcode)
            {
                // Objects
                case 0x32:         // If object present...
                case 0x39:
                    evc.Param1 = (byte)evtNameA1.SelectedIndex;
                    Bits.SetShort(evc.Data, 2, (ushort)evtNumA3.Value);
                    break;
                case 0x3A:         // If distance between object A and...
                case 0x3B:         // If distance (Z==) between object A and...
                    evc.Param1 = (byte)evtNameA1.SelectedIndex;          // object A
                    evc.Param2 = (byte)evtNameA2.SelectedIndex;    // object B
                    evc.Param3 = (byte)evtNumA3.Value;
                    evc.Param4 = (byte)evtNumA4.Value;
                    Bits.SetShort(evc.Data, 5, (ushort)evtNumC1.Value);
                    break;
                case 0x3D:         // If Mario in air...
                    Bits.SetShort(evc.Data, 1, (ushort)evtNumC1.Value);
                    break;
                case 0x3E:         // Create NPC packet @ obj coords...
                    evc.Param2 = (byte)evtNameA1.SelectedIndex;
                    evc.Param1 = (byte)evtNameA2.SelectedIndex;
                    Bits.SetShort(evc.Data, 3, (ushort)evtNumC1.Value);
                    break;
                case 0x3F:         // Create NPC packet...
                    evc.Param1 = (byte)evtNameA2.SelectedIndex;
                    Bits.SetShort(evc.Data, 2, (ushort)evtNumC1.Value);
                    break;
                case 0x42:         // If Mario on top of an object...
                    Bits.SetShort(evc.Data, 1, (ushort)evtNumC1.Value);
                    Bits.SetShort(evc.Data, 3, (ushort)evtNumC2.Value);
                    break;
                case 0xF2:         // Set obj presence...  
                case 0xF3:         // Set obj engage type...
                case 0xF8:         // If object in level ..., presence =...
                    Bits.SetShort(evc.Data, 1, (ushort)evtNumA1.Value);
                    evc.Param2 &= 1; evc.Param2 |= (byte)(evtNameA2.SelectedIndex << 1);
                    Bits.SetBit(evc.Data, 2, 7, evtEffects.GetItemChecked(0));    // set bit 7 if true
                    if (evc.Opcode == 0xF8)
                        Bits.SetShort(evc.Data, 3, (ushort)evtNumC1.Value);
                    break;
                // Joypad
                case 0x34:
                case 0x35:
                    for (int i = 0; i < 8; i++)
                        Bits.SetBit(evc.Data, 1, i, evtEffects.GetItemChecked(i)); // set bit if true
                    break;
                // Party Members
                case 0x36:
                    evc.Param1 = (byte)evtNameA1.SelectedIndex;
                    Bits.SetBit(evc.Data, 1, 7, evtNameA2.SelectedIndex == 1);
                    break;
                case 0x54:
                    evc.Param1 = (byte)evtNameA1.SelectedIndex;
                    evc.Param2 = (byte)evtNumA2.Value;
                    break;
                case 0x56:
                    evc.Param1 = (byte)evtNameA1.SelectedIndex;
                    break;
                // Inventory
                case 0x50:
                case 0x51:
                    evc.Param1 = (byte)evtNumA1.Value;
                    break;
                case 0x52:
                case 0x53:
                    evc.Param1 = (byte)evtNumA1.Value;
                    break;
                // Battle
                case 0x4A:
                    evc.Param1 = (byte)evtNumA3.Value;
                    evc.Param3 = (byte)evtNumA2.Value;
                    break;
                // Levels
                case 0x4B:      // Open, world location...
                    evc.Param1 = (byte)evtNameA1.SelectedIndex;
                    Bits.SetBit(evc.Data, 2, 5, evtEffects.GetItemChecked(0));
                    Bits.SetBit(evc.Data, 2, 6, evtEffects.GetItemChecked(1));
                    Bits.SetBit(evc.Data, 2, 7, evtEffects.GetItemChecked(2));
                    break;
                case 0x68:
                    Bits.SetShort(evc.Data, 1, (ushort)evtNumA1.Value);
                    evc.Param5 = (byte)evtNumA2.Value;
                    evc.Param5 &= 0x1F; evc.Param5 |= (byte)(evtNameA2.SelectedIndex << 5);
                    evc.Param3 = (byte)evtNumA3.Value;
                    evc.Param4 = (byte)evtNumA4.Value;
                    Bits.SetBit(evc.Data, 2, 3, evtEffects.GetItemChecked(0));
                    Bits.SetBit(evc.Data, 2, 7, evtEffects.GetItemChecked(1));
                    Bits.SetBit(evc.Data, 4, 7, evtEffects.GetItemChecked(2));
                    break;
                case 0x6A:
                case 0x6B:
                    Bits.SetShort(evc.Data, 1, (ushort)evtNumA1.Value);
                    Bits.SetBit(evc.Data, 2, 7, evtEffects.GetItemChecked(0));
                    evc.Param2 &= 0x81;
                    evc.Param2 |= (byte)((byte)evtNumA3.Value << 1);
                    break;
                // Open window
                case 0x4C:      // Open, shop menu...
                    evc.Param1 = (byte)evtNameA1.SelectedIndex;
                    break;
                case 0x4F:      // Open, window...
                    evc.Param1 = (byte)evtNameA1.SelectedIndex;
                    break;
                // Dialogue
                case 0x60:
                    Bits.SetShort(evc.Data, 1, (ushort)evtNumA1.Value);
                    evc.Param3 = (byte)evtNameA2.SelectedIndex;
                    Bits.SetBit(evc.Data, 2, 5, evtEffects.GetItemChecked(0));
                    Bits.SetBit(evc.Data, 2, 7, evtEffects.GetItemChecked(1));
                    Bits.SetBit(evc.Data, 3, 6, evtEffects.GetItemChecked(2));
                    Bits.SetBit(evc.Data, 3, 7, evtEffects.GetItemChecked(3));
                    break;
                case 0x61:
                    evc.Param2 = (byte)evtNameA1.SelectedIndex;
                    Bits.SetBit(evc.Data, 1, 5, evtEffects.GetItemChecked(0));
                    Bits.SetBit(evc.Data, 1, 7, evtEffects.GetItemChecked(1));
                    Bits.SetBit(evc.Data, 2, 6, evtEffects.GetItemChecked(2));
                    Bits.SetBit(evc.Data, 2, 7, evtEffects.GetItemChecked(3));
                    break;
                case 0x62:
                    Bits.SetShort(evc.Data, 1, (ushort)evtNumA1.Value);
                    evc.Param2 &= 0x1F; evc.Param2 |= (byte)((byte)evtNumA3.Value << 5);
                    Bits.SetBit(evc.Data, 2, 7, evtEffects.GetItemChecked(0));
                    break;
                case 0x63:
                    Bits.SetBit(evc.Data, 1, 5, evtEffects.GetItemChecked(0));
                    Bits.SetBit(evc.Data, 1, 7, evtEffects.GetItemChecked(1));
                    break;
                case 0x66:
                    Bits.SetShort(evc.Data, 1, (ushort)evtNumA3.Value);
                    break;
                case 0x67:
                    Bits.SetShort(evc.Data, 1, (ushort)evtNumA3.Value);
                    Bits.SetShort(evc.Data, 3, (ushort)evtNumA4.Value);
                    break;
                // Events
                case 0x40:
                    Bits.SetShort(evc.Data, 1, (ushort)evtNumA3.Value);
                    Bits.SetBit(evc.Data, 2, 5, evtEffects.GetItemChecked(0));
                    Bits.SetBit(evc.Data, 2, 6, evtEffects.GetItemChecked(1));
                    Bits.SetBit(evc.Data, 2, 7, evtEffects.GetItemChecked(2));
                    break;
                case 0x44:
                case 0x45:
                    Bits.SetShort(evc.Data, 1, (ushort)evtNumA3.Value);
                    Bits.SetBit(evc.Data, 2, 4, evtEffects.GetItemChecked(0));
                    Bits.SetBit(evc.Data, 2, 5, evtEffects.GetItemChecked(1));
                    evc.Param2 |= (byte)((((int)evtNumA4.Value - 0x701C) / 2) << 6);
                    break;
                case 0x46:
                case 0x47:
                    evc.Param1 = (byte)(((int)evtNumA3.Value - 0x701C) / 2);
                    break;
                case 0xD0:
                case 0xD1:
                    Bits.SetShort(evc.Data, 1, (ushort)evtNumA3.Value);
                    break;
                case 0x4E:
                    evc.Param1 = (byte)evtNameA1.SelectedIndex;
                    switch (evtNameA1.SelectedIndex)
                    {
                        case 2: // open world location
                            evc.Param2 = (byte)evtNameA2.SelectedIndex;
                            break;
                        case 3: // open shop menu
                            evc.Param2 = (byte)evtNameA2.SelectedIndex;
                            break;
                        case 5: // items maxed out
                            evc.Param2 = (byte)evtNumA2.Value;
                            break;
                        case 7: // menu tutorial
                            evc.Param2 = (byte)evtNameA2.SelectedIndex;
                            break;
                        case 8: // add star piece
                        case 13:// run star piece end sequence
                            evc.Param2 = (byte)evtNumA2.Value;
                            break;
                        case 16:    // world map event
                            evc.Param2 = (byte)evtNameA2.SelectedIndex;
                            break;
                    }
                    break;
                // Jump to
                case 0xD2:
                case 0xD3:
                    Bits.SetShort(evc.Data, 1, (ushort)evtNumA3.Value);
                    break;
                case 0xD4:
                    evc.Param1 = (byte)evtNumA3.Value;
                    break;
                case 0xD5:
                    Bits.SetShort(evc.Data, 1, (ushort)evtNumA3.Value);
                    break;
                // Screen effects
                case 0x72:
                case 0x73:
                case 0x76:
                case 0x77:
                    evc.Param1 = (byte)evtNumA3.Value;
                    break;
                case 0x78:
                case 0x79:
                case 0x83:
                    if (evc.Opcode != 0x83)
                    {
                        evc.Param1 = (byte)evtNumA3.Value;
                        evc.Param2 = (byte)evtNameA1.SelectedIndex;
                    }
                    else
                        evc.Param1 = (byte)evtNameA1.SelectedIndex;
                    break;
                case 0x80:
                    ushort color;
                    int r, g, b;
                    r = (int)(evtNumA1.Value / 8);
                    g = (int)(evtNumA2.Value / 8);
                    b = (int)(evtNumA3.Value / 8);
                    color = (ushort)((b << 10) | (g << 5) | r);
                    Bits.SetShort(evc.Data, 1, color);
                    evc.Param4 = (byte)evtNumA4.Value;
                    for (int i = 0; i < 8; i++)
                        Bits.SetBit(evc.Data, 3, i, evtEffects.GetItemChecked(i));
                    break;
                case 0x81:
                    Bits.SetBit(evc.Data, 1, 0, evtEffects.GetItemChecked(0));
                    Bits.SetBit(evc.Data, 1, 1, evtEffects.GetItemChecked(1));
                    Bits.SetBit(evc.Data, 1, 2, evtEffects.GetItemChecked(2));
                    Bits.SetBit(evc.Data, 1, 4, evtEffects.GetItemChecked(3));
                    Bits.SetBit(evc.Data, 2, 0, evtEffects.GetItemChecked(4));
                    Bits.SetBit(evc.Data, 2, 1, evtEffects.GetItemChecked(5));
                    Bits.SetBit(evc.Data, 2, 2, evtEffects.GetItemChecked(6));
                    Bits.SetBit(evc.Data, 2, 4, evtEffects.GetItemChecked(7));
                    Bits.SetBit(evc.Data, 3, 0, evtEffects.GetItemChecked(8));
                    Bits.SetBit(evc.Data, 3, 1, evtEffects.GetItemChecked(9));
                    Bits.SetBit(evc.Data, 3, 2, evtEffects.GetItemChecked(10));
                    Bits.SetBit(evc.Data, 3, 4, evtEffects.GetItemChecked(11));
                    Bits.SetBit(evc.Data, 3, 5, evtEffects.GetItemChecked(12));
                    Bits.SetBit(evc.Data, 3, 6, evtEffects.GetItemChecked(13));
                    Bits.SetBit(evc.Data, 3, 7, evtEffects.GetItemChecked(14));
                    break;
                case 0x84:
                    evc.Param1 = (byte)((byte)evtNumA3.Value << 4);
                    evc.Param2 = (byte)evtNumA4.Value;
                    for (int i = 0; i < 4; i++)
                        Bits.SetBit(evc.Data, 1, i, evtEffects.GetItemChecked(i));
                    break;
                case 0x89:
                    switch (evtNameA1.SelectedIndex)
                    {
                        case 1: evc.Param1 = 0x60; break;
                        case 2: evc.Param1 = 0xC0; break;
                        case 3: evc.Param1 = 0xE0; break;
                        default: evc.Param1 = 0x00; break;
                    }
                    evc.Param1 &= 0xF0; evc.Param1 |= (byte)evtNumA2.Value;
                    evc.Param3 = (byte)evtNumA3.Value;
                    evc.Param2 = (byte)evtNumA4.Value;
                    break;
                case 0x8A:
                    evc.Param2 = (byte)evtNumA3.Value;
                    evc.Param1 = (byte)(((byte)evtNumA4.Value << 4) - 1);
                    break;
                case 0x8F:
                    evc.Param1 = (byte)evtNameA1.SelectedIndex;
                    evc.Param2 = (byte)evtNumA3.Value;
                    evc.Param3 = (byte)evtNumA4.Value;
                    break;
                // Playback audio
                case 0x90:
                case 0x91:
                case 0x92:
                    evc.Param1 = (byte)evtNameA1.SelectedIndex;
                    break;
                case 0x95:
                    evc.Param1 = (byte)evtNumA3.Value;
                    evc.Param2 = (byte)evtNumA4.Value;
                    break;
                case 0x97:
                    if (evtNameA1.SelectedIndex == 0) // slow down
                        evc.Param2 = (byte)evtNumA3.Value;
                    else // speed up
                        evc.Param2 = (byte)((sbyte)-evtNumA3.Value);
                    evc.Param1 = (byte)evtNumA4.Value;
                    break;
                case 0x98:
                    if (evtNameA1.SelectedIndex == 0) // raise
                        evc.Param2 = (byte)evtNumA3.Value;
                    else // lower
                        evc.Param2 = (byte)((sbyte)-evtNumA3.Value);
                    evc.Param1 = (byte)evtNumA4.Value;
                    break;
                case 0x9C:
                    evc.Param1 = (byte)evtNameA1.SelectedIndex;
                    break;
                case 0x9D:
                    evc.Param1 = (byte)evtNameA1.SelectedIndex;
                    evc.Param2 = (byte)evtNumA3.Value;
                    break;
                case 0x9E:
                    evc.Param1 = (byte)evtNumA3.Value;
                    evc.Param2 = (byte)evtNumA4.Value;
                    break;
                // Memory
                case 0xA0:
                case 0xA1:
                case 0xA2:
                    evc.Opcode = (byte)(((((byte)(evtNumA3.Value - 0x7040) << 3) & 0x0F00) >> 8) + 0xA0);
                    evc.Param1 = (byte)(((byte)(evtNumA3.Value - 0x7040) << 3) & 0xF8);
                    evc.Param1 &= 0xF8; evc.Param1 |= (byte)evtNumA4.Value;
                    break;
                case 0xA4:
                case 0xA5:
                case 0xA6:
                    evc.Opcode = (byte)(((((byte)(evtNumA3.Value - 0x7040) << 3) & 0x0F00) >> 8) + 0xA4);
                    evc.Param1 = (byte)(((byte)(evtNumA3.Value - 0x7040) << 3) & 0xF8);
                    evc.Param1 &= 0xF8; evc.Param1 |= (byte)evtNumA4.Value;
                    break;
                case 0xA8:
                case 0xA9:
                    evc.Param1 = (byte)(evtNumA3.Value - 0x70A0);
                    evc.Param2 = (byte)evtNumA4.Value;
                    break;
                case 0xAA:
                case 0xAB:
                    evc.Param1 = (byte)(evtNumA3.Value - 0x70A0);
                    break;
                case 0xB0:
                case 0xB1:
                case 0xC2:
                    evc.Param1 = (byte)((evtNumA3.Value - 0x7000) / 2);
                    Bits.SetShort(evc.Data, 2, (ushort)evtNumA4.Value);
                    break;
                case 0xB2:
                case 0xB3:
                case 0xD6:
                case 0xBB:
                    evc.Param1 = (byte)((evtNumA3.Value - 0x7000) / 2);
                    break;
                case 0xB5:
                    evc.Param1 = (byte)(evtNumA3.Value - 0x70A0);
                    break;
                case 0xB7:
                    evc.Param1 = (byte)((evtNumA3.Value - 0x7000) / 2);
                    Bits.SetShort(evc.Data, 2, (ushort)evtNumA4.Value);
                    break;
                case 0xBC:
                case 0xBD:
                    evc.Param1 = (byte)((evtNumA3.Value - 0x7000) / 2);
                    evc.Param2 = (byte)((evtNumA4.Value - 0x7000) / 2);
                    break;
                case 0xD8:
                case 0xD9:
                case 0xDA:
                    evc.Opcode = (byte)(((((byte)(evtNumA3.Value - 0x7040) << 3) & 0x0F00) >> 8) + 0xD8);
                    evc.Param1 = (byte)(((byte)(evtNumA3.Value - 0x7040) << 3) & 0xF8);
                    evc.Param1 &= 0xF8; evc.Param1 |= (byte)evtNumA4.Value;
                    Bits.SetShort(evc.Data, 2, (ushort)evtNumC1.Value);
                    break;
                case 0xDC:
                case 0xDD:
                case 0xDE:
                    evc.Opcode = (byte)(((((byte)(evtNumA3.Value - 0x7040) << 3) & 0x0F00) >> 8) + 0xDC);
                    evc.Param1 = (byte)(((byte)(evtNumA3.Value - 0x7040) << 3) & 0xF8);
                    evc.Param1 &= 0xF8; evc.Param1 |= (byte)evtNumA4.Value;
                    Bits.SetShort(evc.Data, 2, (ushort)evtNumC1.Value);
                    break;
                case 0xE0:
                case 0xE1:
                    evc.Param1 = (byte)(evtNumA3.Value - 0x70A0);
                    evc.Param2 = (byte)evtNumA4.Value;
                    Bits.SetShort(evc.Data, 3, (ushort)evtNumC1.Value);
                    break;
                case 0xE4:
                case 0xE5:
                    evc.Param1 = (byte)((evtNumA3.Value - 0x7000) / 2);
                    Bits.SetShort(evc.Data, 2, (ushort)evtNumA4.Value);
                    Bits.SetShort(evc.Data, 4, (ushort)evtNumC1.Value);
                    break;
                case 0xE8:
                    Bits.SetShort(evc.Data, 1, (ushort)evtNumA3.Value);
                    break;
                case 0xE9:
                    Bits.SetShort(evc.Data, 1, (ushort)evtNumA3.Value);
                    Bits.SetShort(evc.Data, 3, (ushort)evtNumA4.Value);
                    break;
                // Memory $7000
                case 0x38:
                    if (evc.Param1 < 8) evc.Param1 = 8;
                    evc.Param1 = (byte)(evtNumA3.Value + 8);
                    break;
                case 0xAC:
                case 0xAD:
                case 0xB6:
                case 0xC0:
                    Bits.SetShort(evc.Data, 1, (ushort)evtNumA3.Value);
                    break;
                case 0xB4:
                    evc.Param1 = (byte)(evtNumA3.Value - 0x70A0);
                    break;
                case 0xB8:
                case 0xB9:
                case 0xBA:
                case 0xC1:
                    evc.Param1 = (byte)((evtNumA3.Value - 0x7000) / 2);
                    break;
                case 0xC4:
                case 0xC5:
                case 0xC6:
                    evc.Param1 = (byte)evtNameA1.SelectedIndex;
                    Bits.SetBit(evc.Data, 1, 6, evtNameA2.SelectedIndex == 1);
                    break;
                case 0xC7:
                case 0xC8:
                case 0xC9:
                    evc.Param1 = (byte)evtNameA1.SelectedIndex;
                    break;
                case 0xDB:
                case 0xDF:
                    Bits.SetShort(evc.Data, 1, (ushort)evtNumA3.Value);
                    break;
                case 0xE2:
                case 0xE3:
                    Bits.SetShort(evc.Data, 1, (ushort)evtNumA3.Value);
                    Bits.SetShort(evc.Data, 3, (ushort)evtNumA4.Value);
                    break;
                case 0xE6:
                case 0xE7:
                    for (int i = 0; i < 16; i++)
                        Bits.SetBit(evc.Data, 1, i, evtEffects.GetItemChecked(i));
                    Bits.SetShort(evc.Data, 3, (ushort)evtNumC1.Value);
                    break;
                case 0xEA:
                case 0xEB:
                case 0xEC:
                case 0xED:
                case 0xEE:
                case 0xEF:
                    Bits.SetShort(evc.Data, 1, (ushort)evtNumA3.Value);
                    break;
                // Pause script
                case 0xF0:
                    evc.Param1 = (byte)(evtNumA3.Value - 1);
                    break;
                case 0xF1:
                    Bits.SetShort(evc.Data, 1, (ushort)(evtNumA3.Value - 1));
                    break;
                default:
                    // Action Queue (same for all sub-indexes, so no need to do a switch for sub)
                    if (evc.Opcode <= 0x2F)
                    {
                        byte temp = evc.Opcode;
                        switch (evtNameA2.SelectedIndex)
                        {
                            case 0:
                                evc.Opcode = (byte)evtNameA1.SelectedIndex;
                                Bits.SetBit(evc.Data, 1, 7, evtEffects.GetItemChecked(0));
                                break;
                            case 1:
                            case 2:
                                evc.Data = new byte[3];
                                evc.Opcode = (byte)evtNameA1.SelectedIndex;
                                evc.Param1 = (byte)(evtNameA2.SelectedIndex + 0xEF);
                                Bits.SetBit(evc.Data, 2, 7, evtEffects.GetItemChecked(0));
                                break;
                            case 3:
                            case 4:
                            case 5:
                            case 6:
                                evc.Data = new byte[4];
                                evc.Opcode = (byte)evtNameA1.SelectedIndex;
                                evc.Param1 = (byte)(evtNameA2.SelectedIndex + 0xEF);
                                Bits.SetShort(evc.Data, 2, (ushort)evtNumA3.Value);
                                break;
                            default:
                                evc.Opcode = (byte)evtNameA1.SelectedIndex;
                                evc.Param1 = (byte)(evtNameA2.SelectedIndex + 0xEF);
                                break;
                        }
                        /*
                         * TODO
                         * set evtNumC value and labelEvtC text according to evtNameB.SelectedIndex
                         */
                    }
                    else if (evc.Opcode == 0xFD)
                    {
                        switch (evc.Param1)
                        {
                            // Objects
                            case 0x33:
                            case 0x34:
                            case 0x3D:         // If in air, object...
                                evc.Param2 = (byte)evtNameA1.SelectedIndex;
                                Bits.SetShort(evc.Data, 3, (ushort)evtNumA3.Value);
                                break;
                            case 0x3E:
                                evc.Param2 = (byte)evtNameA1.SelectedIndex;
                                Bits.SetShort(evc.Data, 3, (ushort)evtNumA2.Value);
                                Bits.SetShort(evc.Data, 5, (ushort)evtNumC1.Value);
                                break;
                            case 0xF0:
                                Bits.SetShort(evc.Data, 2, (ushort)evtNumA1.Value);
                                evc.Param3 &= 1; evc.Param3 |= (byte)(evtNameA2.SelectedIndex << 1);
                                Bits.SetBit(evc.Data, 3, 7, evtEffects.GetItemChecked(0));    // set bit 7 if true
                                Bits.SetShort(evc.Data, 4, (ushort)evtNumC1.Value);
                                break;
                            // Menus
                            case 0x4C:
                                evc.Param2 = (byte)evtNameA1.SelectedIndex;
                                break;
                            // Run event
                            case 0x46:
                                Bits.SetShort(evc.Data, 2, (ushort)evtNumA3.Value);
                                break;
                            case 0x4D:
                                evc.Param2 = (byte)evtNumA3.Value;
                                break;
                            case 0x66:
                                evc.Param3 = (byte)evtNameA1.SelectedIndex;
                                evc.Param2 = (byte)evtNumA3.Value;
                                break;
                            // Playback audio
                            case 0x94:
                                for (int i = 0; i < 8; i++)
                                    Bits.SetBit(evc.Data, 2, i, evtEffects.GetItemChecked(i));
                                break;
                            case 0x96:
                            case 0x97:
                                evc.Param2 = (byte)evtNumA3.Value;
                                Bits.SetShort(evc.Data, 3, (ushort)evtNumA4.Value);
                                break;
                            case 0x9C:
                                evc.Param2 = (byte)evtNameA1.SelectedIndex;
                                break;
                            // Memory
                            case 0xB6:
                                evc.Param2 = (byte)((evtNumA3.Value - 0x7000) / 2);
                                evc.Param3 = (byte)((byte)(evtNumA4.Value - 1) ^ 0xFF);
                                break;
                            case 0xB7:
                                evc.Param2 = (byte)((evtNumA3.Value - 0x7000) / 2);
                                break;
                            // Memory $7000
                            case 0x58:
                                evc.Param2 = (byte)evtNumA1.Value;
                                break;
                            case 0x5D:
                                evc.Param2 = (byte)evtNameA1.SelectedIndex;
                                evc.Param3 = (byte)evtNameA2.SelectedIndex;
                                break;
                            case 0xAC:
                                Bits.SetShort(evc.Data, 2, (ushort)(evtNumA3.Value - 0x7FF800));
                                break;
                            case 0xB0:
                            case 0xB1:
                            case 0xB2:
                                Bits.SetShort(evc.Data, 2, (ushort)evtNumA3.Value);
                                break;
                            case 0xB3:
                            case 0xB4:
                            case 0xB5:
                                evc.Param2 = (byte)((evtNumA3.Value - 0x7000) / 2);
                                break;
                            default: break;
                        }
                    }
                    break;
            }
        }
        /// <summary>
        /// Loads the current action command's data into the controls.
        /// </summary>
        public void ReadFromActionCommand()
        {
            this.Updating = true;
            panelCommand.SuspendDrawing();
            int[] tree = commandCategory;
            if (tree != null)
            {
                categories_aq.SelectedIndex = tree[0];
                commands.SelectedIndex = tree[1];
            }
            switch (acc.Opcode)
            {
                // Properties
                case 0x0A:
                case 0x0B:
                case 0x0C:
                case 0x15:
                    groupBoxB.Text = commandText;
                    evtEffects.Items.AddRange(new string[] 
                        { 
                            "bit 0", "can't walk under", "can't pass walls", "can't jump through", 
                            "bit 4", "can't pass NPCs", "can't walk through", "bit 7", 
                        });
                    evtEffects.Enabled = true;
                    for (int i = 1, j = 0; j < 8; i *= 2, j++)
                        evtEffects.SetItemChecked(j, (acc.Param1 & i) == i);
                    break;
                case 0x13:
                    groupBoxA.Text = commandText;
                    labelEvtA3.Text = "VRAM priority";
                    evtNumA3.Maximum = 3; evtNumA3.Enabled = true;
                    evtNumA3.Value = acc.Param1;
                    break;
                case 0x3D:
                    groupBoxA.Text = commandText;
                    labelEvtA3.Text = "Jump to";
                    evtNumA3.Hexadecimal = true; evtNumA3.Maximum = 0xFFFF; evtNumA3.Enabled = true;
                    evtNumA3.Value = Bits.GetShort(acc.Data, 1);
                    break;
                // Palette
                case 0x0D: evtNumA3.Maximum = 15; goto case 0x0E;
                case 0x0E:
                    groupBoxA.Text = commandText;
                    labelEvtA3.Text = "Row";
                    evtNumA3.Enabled = true;
                    evtNumA3.Value = acc.Param1 & 0x0F;
                    break;
                // Sprite Sequence
                case 0x08:
                    groupBoxA.Text = commandText;
                    labelEvtA3.Text = "Sprite +=";
                    evtNumA3.Maximum = 7; evtNumA3.Enabled = true;
                    evtNumA4.Maximum = 127; evtNumA4.Enabled = true;
                    evtEffects.Items.AddRange(new string[]
                    {
                        "read as mold",
                        "looping off",
                        "read as sequence",
                        "mirror sprite"
                    });
                    evtEffects.Enabled = true;
                    evtNumA3.Value = acc.Param1 & 0x07;
                    evtNumA4.Value = acc.Param2 & 0x7F;
                    evtEffects.SetItemChecked(0, (acc.Param1 & 0x08) == 0x08);
                    evtEffects.SetItemChecked(1, (acc.Param1 & 0x10) == 0x10);
                    evtEffects.SetItemChecked(2, (acc.Param1 & 0x40) == 0x40);
                    evtEffects.SetItemChecked(3, (acc.Param2 & 0x80) == 0x80);
                    if (evtEffects.GetItemChecked(0))
                        labelEvtA4.Text = "Mold";
                    else
                        labelEvtA4.Text = "Sequence";
                    break;
                case 0x10:
                    groupBoxA.Text = commandText;
                    labelEvtA1.Text = "Speed";
                    evtNameA1.Items.AddRange(new string[]
                    {
                        "normal",
                        "fast","faster",
                        "very fast", "fastest",
                        "slow", "very slow"
                    });
                    evtNameA1.Enabled = true;
                    evtEffects.Items.AddRange(new string[] { "walking", "sequence" });
                    evtEffects.Enabled = true;
                    //
                    evtNameA1.SelectedIndex = acc.Param1 & 0x0F;
                    evtEffects.SetItemChecked(0, (acc.Param1 & 0x40) == 0x40);
                    evtEffects.SetItemChecked(1, (acc.Param1 & 0x80) == 0x80);
                    break;
                case 0x3E:         // Create NPC packet @ obj coords...
                    groupBoxA.Text = commandText;
                    labelEvtA1.Text = "Object";
                    labelEvtA2.Text = "Packet";
                    groupBoxC.Text = "If null...";
                    labelEvtC1.Text = "Jump to";
                    evtNameA1.Items.AddRange(Lists.NPCs); evtNameA1.Enabled = true;
                    evtNameA2.Items.AddRange(Lists.Numerize(Lists.NPCPackets)); evtNameA2.Enabled = true;
                    evtNameA2.DropDownWidth = 200;
                    evtNumC1.Enabled = true; evtNumC1.Hexadecimal = true; evtNumC1.Maximum = 0xFFFF;
                    //
                    evtNameA1.SelectedIndex = acc.Param2;
                    evtNameA2.SelectedIndex = acc.Param1;
                    evtNumC1.Value = Bits.GetShort(acc.Data, 3);
                    break;
                case 0x3F:         // Create NPC packet...
                    groupBoxA.Text = commandText;
                    labelEvtA2.Text = "Packet";
                    groupBoxC.Text = "If null...";
                    labelEvtC1.Text = "Jump to";
                    evtNameA2.Items.AddRange(Lists.Numerize(Lists.NPCPackets)); evtNameA2.Enabled = true;
                    evtNameA2.DropDownWidth = 200;
                    evtNumC1.Enabled = true; evtNumC1.Hexadecimal = true; evtNumC1.Maximum = 0xFFFF;
                    //
                    evtNameA2.SelectedIndex = acc.Param1;
                    evtNumC1.Value = Bits.GetShort(acc.Data, 2);
                    break;
                case 0xD0:
                    groupBoxA.Text = commandText;
                    labelEvtA3.Text = "Action #";
                    evtNumA3.Maximum = 0x3FF; evtNumA3.Enabled = true;
                    evtNumA3.Value = Bits.GetShort(acc.Data, 1) & 0x3FF;
                    break;
                // Sprite Animation

                // Shift isometric units
                case 0x50:
                case 0x51:
                case 0x52:
                case 0x53:
                case 0x54:
                case 0x55:
                case 0x56:
                case 0x57:
                case 0x58:
                case 0x5A:
                case 0x5B:
                    groupBoxA.Text = commandText;
                    labelEvtA3.Text = "Steps";
                    evtNumA3.Enabled = true;
                    evtNumA3.Value = acc.Param1;
                    break;
                case 0x7E: groupBoxA.Text = commandText; goto case 0x7F;
                case 0x7F:
                    groupBoxA.Text = commandText;
                    labelEvtA3.Text = "Steps";
                    evtNumA3.Maximum = 65535; evtNumA3.Enabled = true;
                    evtNumA3.Value = Bits.GetShort(acc.Data, 1);
                    break;
                // Shift 1px units
                case 0x60:
                case 0x61:
                case 0x62:
                case 0x63:
                case 0x64:
                case 0x65:
                case 0x66:
                case 0x67:
                case 0x68:
                case 0x6A:
                case 0x6B:
                    groupBoxA.Text = commandText;
                    labelEvtA3.Text = "Pixels";
                    evtNumA3.Enabled = true;
                    evtNumA3.Value = acc.Param1;
                    break;
                // Face direction
                case 0x7B:
                    groupBoxA.Text = commandText;
                    labelEvtA3.Text = "Turn amount";
                    evtNumA3.Enabled = true;
                    evtNumA3.Value = acc.Param1;
                    break;
                // Shift to coords
                case 0x80:
                case 0x81:
                case 0x82:
                case 0x83:
                case 0x84:
                    groupBoxA.Text = commandText;
                    labelEvtA3.Text = "X";
                    labelEvtA4.Text = "Y";
                    evtNumA3.Enabled = true;
                    evtNumA4.Enabled = true;
                    if (acc.Opcode != 0x80 && acc.Opcode != 0x82)
                    {
                        evtNumA3.Minimum = evtNumA4.Minimum = -128;
                        evtNumA3.Maximum = evtNumA4.Maximum = 127;
                    }
                    evtNumA3.Value = acc.Param1;
                    evtNumA4.Value = acc.Param2;
                    break;
                case 0x87:
                case 0x95:
                    groupBoxA.Text = commandText;
                    labelEvtA1.Text = "Object";
                    evtNameA1.Items.AddRange(Lists.NPCs); evtNameA1.Enabled = true;
                    evtNameA1.SelectedIndex = acc.Param1;
                    break;
                case 0x90:
                case 0x91:
                    groupBoxA.Text = commandText;
                    labelEvtA1.Text = "Bounce peak";
                    labelEvtA3.Text = "X";
                    labelEvtA4.Text = "Y";
                    evtNumA1.Enabled = true;
                    evtNumA3.Enabled = true;
                    evtNumA4.Enabled = true;
                    if (acc.Opcode != 0x90)
                    {
                        evtNumA3.Minimum = evtNumA4.Minimum = -128;
                        evtNumA3.Maximum = evtNumA4.Maximum = 127;
                    }
                    //
                    evtNumA1.Value = acc.Param3;
                    evtNumA3.Value = acc.Param1;
                    evtNumA4.Value = acc.Param2;
                    break;
                case 0x92:
                case 0x93:
                case 0x94:
                    groupBoxA.Text = commandText;
                    labelEvtA2.Text = "F / Z";
                    labelEvtA3.Text = "X";
                    labelEvtA4.Text = "Y";
                    evtNameA2.Items.AddRange(Lists.Directions); evtNameA2.Enabled = true;
                    evtNumA2.Maximum = 0x31; evtNumA2.Enabled = true;
                    if (acc.Opcode != 0x92)
                    {
                        evtNumA3.Minimum = evtNumA4.Minimum = -128;
                        evtNumA3.Maximum = evtNumA4.Maximum = 127;
                    }
                    evtNumA3.Enabled = true;
                    evtNumA4.Enabled = true;
                    //
                    evtNameA2.SelectedIndex = (acc.Param3 & 0xE0) >> 5;
                    evtNumA2.Value = acc.Param3 & 0x1F;
                    evtNumA3.Value = acc.Param1;
                    evtNumA4.Value = acc.Param2;
                    break;
                // Audio playback
                case 0x9C:
                    groupBoxA.Text = commandText;
                    labelEvtA1.Text = "Sound";
                    evtNameA1.Items.AddRange(Lists.Numerize(Lists.SPCEventSounds)); evtNameA1.Enabled = true;
                    evtNameA1.SelectedIndex = acc.Param1;
                    break;
                case 0x9D:
                    groupBoxA.Text = commandText;
                    labelEvtA1.Text = "Sound";
                    labelEvtA3.Text = "Balance";
                    evtNameA1.Items.AddRange(Lists.Numerize(Lists.SPCEventSounds)); evtNameA1.Enabled = true;
                    evtNumA3.Enabled = true;
                    evtNameA1.SelectedIndex = acc.Param1;
                    evtNumA3.Value = acc.Param2;
                    break;
                case 0x9E:
                    groupBoxA.Text = commandText;
                    labelEvtA3.Text = "Time stretch";
                    labelEvtA4.Text = "To volume";
                    evtNumA3.Enabled = true;
                    evtNumA4.Enabled = true;
                    evtNumA3.Value = acc.Param1;
                    evtNumA4.Value = acc.Param2;
                    break;
                // Memory
                case 0xA0:
                case 0xA1:
                case 0xA2:
                case 0xA4:
                case 0xA5:
                case 0xA6:
                    groupBoxA.Text = commandText;
                    labelEvtA3.Text = "Memory";
                    labelEvtA4.Text = "Bit";
                    evtNumA3.Hexadecimal = true;
                    evtNumA3.Maximum = 0x709F; evtNumA3.Minimum = 0x7040;
                    evtNumA3.Enabled = true;
                    evtNumA4.Maximum = 7; evtNumA4.Enabled = true;
                    //
                    if (acc.Opcode < 0xA4)
                        evtNumA3.Value = ((((acc.Opcode - 0xA0) * 0x100) + acc.Param1) >> 3) + 0x7040;
                    else
                        evtNumA3.Value = ((((acc.Opcode - 0xA4) * 0x100) + acc.Param1) >> 3) + 0x7040;
                    evtNumA4.Value = acc.Param1 & 7;
                    break;
                case 0xA8:
                case 0xA9:
                    groupBoxA.Text = commandText;
                    labelEvtA3.Text = "Memory";
                    labelEvtA4.Text = "Value";
                    evtNumA3.Hexadecimal = true;
                    evtNumA3.Maximum = 0x719F; evtNumA3.Minimum = 0x70A0;
                    evtNumA3.Enabled = true;
                    evtNumA4.Enabled = true;
                    //
                    evtNumA3.Value = acc.Param1 + 0x70A0;
                    evtNumA4.Value = acc.Param2;
                    break;
                case 0xAA:
                case 0xAB:
                    groupBoxA.Text = commandText;
                    labelEvtA3.Text = "Memory";
                    evtNumA3.Hexadecimal = true;
                    evtNumA3.Maximum = 0x719F; evtNumA3.Minimum = 0x70A0;
                    evtNumA3.Enabled = true;
                    evtNumA3.Value = acc.Param1 + 0x70A0;
                    break;
                case 0xB0:
                case 0xB1:
                case 0xC2:
                    groupBoxA.Text = commandText;
                    labelEvtA3.Text = "Memory";
                    labelEvtA4.Text = "Value";
                    evtNumA3.Hexadecimal = true; evtNumA3.Increment = 2;
                    evtNumA3.Maximum = 0x71FE; evtNumA3.Minimum = 0x7000;
                    evtNumA3.Enabled = true;
                    evtNumA4.Maximum = 65535; evtNumA4.Enabled = true;
                    //
                    evtNumA3.Value = (acc.Param1 * 2) + 0x7000;
                    evtNumA4.Value = Bits.GetShort(acc.Data, 2);
                    break;
                case 0xB2:
                case 0xB3:
                case 0xD6:
                case 0xBB:
                    groupBoxA.Text = commandText;
                    labelEvtA3.Text = "Memory";
                    evtNumA3.Hexadecimal = true; evtNumA3.Increment = 2;
                    evtNumA3.Maximum = 0x71FE; evtNumA3.Minimum = 0x7000;
                    evtNumA3.Enabled = true;
                    evtNumA3.Value = (acc.Param1 * 2) + 0x7000;
                    break;
                case 0xB5:
                    groupBoxA.Text = commandText;
                    labelEvtA3.Text = "Memory";
                    evtNumA3.Hexadecimal = true;
                    evtNumA3.Maximum = 0x719F; evtNumA3.Minimum = 0x70A0;
                    evtNumA3.Enabled = true;
                    evtNumA3.Value = acc.Param1 + 0x70A0;
                    break;
                case 0xB7:
                    groupBoxA.Text = commandText;
                    labelEvtA3.Text = "Memory";
                    labelEvtA4.Text = "Number";
                    evtNumA3.Hexadecimal = true; evtNumA3.Increment = 2;
                    evtNumA3.Maximum = 0x71FE; evtNumA3.Minimum = 0x7000;
                    evtNumA3.Enabled = true;
                    evtNumA4.Maximum = 65535; evtNumA4.Enabled = true;
                    //
                    evtNumA3.Value = (acc.Param1 * 2) + 0x7000;
                    evtNumA4.Value = Bits.GetShort(acc.Data, 2);
                    break;
                case 0xBC:
                case 0xBD:
                    groupBoxA.Text = commandText;
                    labelEvtA3.Text = "Memory A";
                    labelEvtA4.Text = "Memory B";
                    evtNumA3.Hexadecimal = true; evtNumA3.Increment = 2;
                    evtNumA3.Maximum = 0x71FE; evtNumA3.Minimum = 0x7000;
                    evtNumA3.Enabled = true;
                    evtNumA4.Hexadecimal = true; evtNumA4.Increment = 2;
                    evtNumA4.Maximum = 0x71FE; evtNumA4.Minimum = 0x7000;
                    evtNumA4.Enabled = true;
                    //
                    evtNumA3.Value = (acc.Param1 * 2) + 0x7000;
                    evtNumA4.Value = (acc.Param2 * 2) + 0x7000;
                    break;
                case 0xD8:
                case 0xD9:
                case 0xDA:
                case 0xDC:
                case 0xDD:
                case 0xDE:
                    groupBoxA.Text = commandText;
                    labelEvtA3.Text = "Memory";
                    labelEvtA4.Text = "Bit";
                    labelEvtC1.Text = "Jump to";
                    evtNumA3.Hexadecimal = true;
                    evtNumA3.Maximum = 0x709F; evtNumA3.Minimum = 0x7040;
                    evtNumA3.Enabled = true;
                    evtNumA4.Maximum = 7; evtNumA4.Enabled = true;
                    evtNumC1.Hexadecimal = true; evtNumC1.Maximum = 0xFFFF; evtNumC1.Enabled = true;
                    if (acc.Opcode < 0xDC) evtNumA3.Value = ((((acc.Opcode - 0xD8) * 0x100) + acc.Param1) >> 3) + 0x7040;
                    else evtNumA3.Value = ((((acc.Opcode - 0xDC) * 0x100) + acc.Param1) >> 3) + 0x7040;
                    evtNumA4.Value = acc.Param1 & 7;
                    evtNumC1.Value = Bits.GetShort(acc.Data, 2);
                    break;
                case 0xE0:
                case 0xE1:
                    groupBoxA.Text = commandText;
                    labelEvtA3.Text = "Memory";
                    labelEvtA4.Text = "Value";
                    labelEvtC1.Text = "Jump to";
                    evtNumA3.Hexadecimal = true;
                    evtNumA3.Maximum = 0x719F; evtNumA3.Minimum = 0x70A0;
                    evtNumA3.Enabled = true;
                    evtNumA4.Enabled = true;
                    evtNumC1.Hexadecimal = true; evtNumC1.Maximum = 0xFFFF; evtNumC1.Enabled = true;
                    //
                    evtNumA3.Value = acc.Param1 + 0x70A0;
                    evtNumA4.Value = acc.Param2;
                    evtNumC1.Value = Bits.GetShort(acc.Data, 3);
                    break;
                case 0xE4:
                case 0xE5:
                    groupBoxA.Text = commandText;
                    labelEvtA3.Text = "Memory";
                    labelEvtA4.Text = "Value";
                    labelEvtC1.Text = "Jump to";
                    evtNumA3.Hexadecimal = true; evtNumA3.Increment = 2;
                    evtNumA3.Maximum = 0x71FE; evtNumA3.Minimum = 0x7000;
                    evtNumA3.Enabled = true;
                    evtNumA4.Maximum = 65535; evtNumA4.Enabled = true;
                    evtNumC1.Hexadecimal = true; evtNumC1.Maximum = 0xFFFF; evtNumC1.Enabled = true;
                    evtNumA3.Value = (acc.Param1 * 2) + 0x7000;
                    evtNumA4.Value = Bits.GetShort(acc.Data, 2);
                    evtNumC1.Value = Bits.GetShort(acc.Data, 4);
                    break;
                case 0xE8:
                    groupBoxA.Text = commandText;
                    labelEvtA3.Text = "Jump to";
                    evtNumA3.Hexadecimal = true; evtNumA3.Maximum = 0xFFFF; evtNumA3.Enabled = true;
                    evtNumA3.Value = Bits.GetShort(acc.Data, 1);
                    break;
                case 0xE9:
                    groupBoxA.Text = commandText;
                    labelEvtA3.Text = "Jump to";
                    labelEvtA4.Text = "Else jump to";
                    evtNumA3.Hexadecimal = true; evtNumA3.Maximum = 0xFFFF; evtNumA3.Enabled = true;
                    evtNumA4.Hexadecimal = true; evtNumA4.Maximum = 0xFFFF; evtNumA4.Enabled = true;
                    evtNumA3.Value = Bits.GetShort(acc.Data, 1);
                    evtNumA4.Value = Bits.GetShort(acc.Data, 3);
                    break;
                // Memory $700C
                case 0xAC:
                case 0xAD:
                case 0xB6:
                case 0xC0:
                    groupBoxA.Text = commandText;
                    labelEvtA3.Text = "Value";
                    evtNumA3.Maximum = 65535; evtNumA3.Enabled = true;
                    evtNumA3.Value = Bits.GetShort(acc.Data, 1);
                    break;
                case 0xB4:
                    groupBoxA.Text = commandText;
                    labelEvtA3.Text = "Memory";
                    evtNumA3.Hexadecimal = true;
                    evtNumA3.Maximum = 0x719F; evtNumA3.Minimum = 0x70A0;
                    evtNumA3.Enabled = true;
                    evtNumA3.Value = acc.Param1 + 0x70A0;
                    break;
                case 0xB8:
                case 0xB9:
                case 0xBA:
                case 0xC1:
                    groupBoxA.Text = commandText;
                    labelEvtA3.Text = "Memory";
                    evtNumA3.Hexadecimal = true; evtNumA3.Increment = 2;
                    evtNumA3.Maximum = 0x71FE; evtNumA3.Minimum = 0x7000;
                    evtNumA3.Enabled = true;
                    evtNumA3.Value = (acc.Param1 * 2) + 0x7000;
                    break;
                case 0xC4:
                case 0xC5:
                case 0xC6:
                    groupBoxA.Text = commandText;
                    labelEvtA1.Text = "Object";
                    labelEvtA2.Text = "Units";
                    evtNameA1.Items.AddRange(Lists.NPCs); evtNameA1.Enabled = true;
                    evtNameA2.Items.AddRange(new string[] { "pixel", "isometric" }); evtNameA2.Enabled = true;
                    evtNameA1.SelectedIndex = acc.Param1 & 0x3F;
                    evtNameA2.SelectedIndex = (acc.Param1 & 0x40) >> 6;
                    break;
                case 0xDB:
                case 0xDF:
                    groupBoxA.Text = commandText;
                    labelEvtA3.Text = "Jump to";
                    evtNumA3.Hexadecimal = true; evtNumA3.Maximum = 0xFFFF; evtNumA3.Enabled = true;
                    evtNumA3.Value = Bits.GetShort(acc.Data, 1);
                    break;
                case 0xE2:
                case 0xE3:
                    groupBoxA.Text = commandText;
                    labelEvtA3.Text = "Value";
                    labelEvtA4.Text = "Jump to";
                    evtNumA3.Maximum = 65535; evtNumA3.Enabled = true;
                    evtNumA4.Hexadecimal = true; evtNumA4.Maximum = 0xFFFF; evtNumA4.Enabled = true;
                    evtNumA3.Value = Bits.GetShort(acc.Data, 1);
                    evtNumA4.Value = Bits.GetShort(acc.Data, 3);
                    break;
                case 0xE6:
                case 0xE7:
                    groupBoxB.Text = commandText;
                    evtEffects.ColumnWidth = 66;
                    evtEffects.Items.AddRange(new string[]{
                        "bit 0","bit 1","bit 2","bit 3","bit 4","bit 5","bit 6","bit 7",
                        "bit 8","bit 9","bit 10","bit 11","bit 12","bit 13","bit 14","bit 15"});
                    evtEffects.Enabled = true;
                    labelEvtC1.Text = "Jump to";
                    evtNumC1.Hexadecimal = true; evtNumC1.Maximum = 0xFFFF; evtNumC1.Enabled = true;
                    //
                    for (int b = 1, i = 0; i < 16; b *= 2, i++)
                        evtEffects.SetItemChecked(i, (Bits.GetShort(acc.Data, 1) & b) == b);
                    evtNumC1.Value = Bits.GetShort(acc.Data, 3);
                    break;
                case 0xEA:
                case 0xEB:
                case 0xEC:
                case 0xED:
                case 0xEE:
                case 0xEF:
                    groupBoxA.Text = commandText;
                    labelEvtA3.Text = "Jump to";
                    evtNumA3.Hexadecimal = true; evtNumA3.Maximum = 0xFFFF; evtNumA3.Enabled = true;
                    evtNumA3.Value = Bits.GetShort(acc.Data, 1);
                    break;
                // Jump to
                case 0xD2:
                case 0xD3:
                    groupBoxA.Text = commandText;
                    labelEvtA3.Text = "Jump to";
                    evtNumA3.Hexadecimal = true; evtNumA3.Maximum = 0xFFFF; evtNumA3.Enabled = true;
                    evtNumA3.Value = Bits.GetShort(acc.Data, 1);
                    break;
                case 0xD4:
                    groupBoxA.Text = commandText;
                    labelEvtA3.Text = "Count";
                    evtNumA3.Enabled = true;
                    evtNumA3.Value = acc.Param1;
                    break;
                // Object memory
                case 0xF2:         // Set obj presence...  
                case 0xF3:         // Set obj engage type...
                case 0xF8:         // If object in level ..., presence =...
                    groupBoxA.Text = commandText;
                    labelEvtA1.Text = "Level";
                    labelEvtA2.Text = "Object";
                    if (evc.Opcode == 0xF8)
                        labelEvtC1.Text = "Jump to";
                    evtNameA1.Items.AddRange(Lists.Numerize(Lists.Areas));
                    evtNameA1.DropDownWidth = 500;
                    evtNameA1.Enabled = true;
                    evtNameA2.Items.AddRange(Lists.NPCs); evtNameA2.Enabled = true;
                    evtNumA1.Enabled = true; evtNumA1.Maximum = 511;
                    if (acc.Opcode == 0xF3)
                        evtEffects.Items.AddRange(new object[] { "is enabled" });
                    else
                        evtEffects.Items.AddRange(new object[] { "is present" });
                    evtEffects.Enabled = true;
                    if (evc.Opcode == 0xF8)
                        evtNumC1.Enabled = true; evtNumC1.Hexadecimal = true; evtNumC1.Maximum = 0xFFFF;
                    //
                    evtNumA1.Value = Bits.GetShort(acc.Data, 1) & 0x1FF;
                    evtNameA1.SelectedIndex = (int)evtNumA1.Value;
                    evtNameA2.SelectedIndex = (acc.Param2 >> 1) & 0x3F;
                    evtEffects.SetItemChecked(0, (acc.Param2 & 0x80) == 0x80);
                    if (acc.Opcode == 0xF8)
                        evtNumC1.Value = Bits.GetShort(acc.Data, 3);
                    break;
                // Pause script
                case 0xF0:
                    groupBoxA.Text = commandText;
                    labelEvtA3.Text = "Frames";
                    evtNumA3.Minimum = 1; evtNumA3.Maximum = 256; evtNumA3.Enabled = true;
                    evtNumA3.Value = acc.Param1 + 1;
                    break;
                case 0xF1:
                    groupBoxA.Text = commandText;
                    labelEvtA3.Text = "Frames";
                    evtNumA3.Minimum = 1; evtNumA3.Maximum = 65536; evtNumA3.Enabled = true;
                    evtNumA3.Value = Bits.GetShort(acc.Data, 1) + 1;
                    break;
                case 0xFD:
                    switch (acc.Param1)
                    {
                        case 0x0F:
                            groupBoxA.Text = commandText;
                            labelEvtA3.Text = "Priority";
                            evtNumA3.Maximum = 3; evtNumA3.Enabled = true;
                            evtNumA3.Value = acc.Param2;
                            break;
                        // Memory
                        case 0xB6:
                            groupBoxA.Text = commandText;
                            labelEvtA3.Text = "Memory";
                            labelEvtA4.Text = "Shift";
                            evtNumA3.Hexadecimal = true; evtNumA3.Increment = 2;
                            evtNumA3.Maximum = 0x71FE; evtNumA3.Minimum = 0x7000;
                            evtNumA3.Enabled = true;
                            evtNumA4.Maximum = 256; evtNumA4.Minimum = 1; evtNumA4.Enabled = true;
                            evtNumA3.Value = (acc.Param2 * 2) + 0x7000;
                            evtNumA4.Value = (acc.Param3 ^ 0xFF) + 1;
                            break;
                        // Memory $700C
                        case 0xB0:
                        case 0xB1:
                        case 0xB2:
                            groupBoxA.Text = commandText;
                            labelEvtA3.Text = "Value";
                            evtNumA3.Maximum = 65535; evtNumA3.Enabled = true;
                            evtNumA3.Value = Bits.GetShort(acc.Data, 2);
                            break;
                        case 0xB3:
                        case 0xB4:
                        case 0xB5:
                            groupBoxA.Text = commandText;
                            labelEvtA3.Text = "Memory";
                            evtNumA3.Hexadecimal = true; evtNumA3.Increment = 2;
                            evtNumA3.Maximum = 0x71FE; evtNumA3.Minimum = 0x7000;
                            evtNumA3.Enabled = true;
                            evtNumA3.Value = (acc.Param2 * 2) + 0x7000;
                            break;
                    }
                    break;
            }
            ArrangeControls();
            panelCommand.ResumeDrawing();
            this.Updating = false;
        }
        /// <summary>
        /// Writes the values of the controls to the command's data.
        /// </summary>
        /// <param name="command"></param>
        public void WriteToActionCommand()
        {
            switch (acc.Opcode)
            {
                // Properties
                case 0x0A:
                case 0x0B:
                case 0x0C:
                case 0x15:
                    for (int i = 0; i < 8; i++)
                        Bits.SetBit(acc.Data, 1, i, evtEffects.GetItemChecked(i));
                    break;
                case 0x13:
                    acc.Param1 = (byte)evtNumA3.Value;
                    break;
                case 0x3D:
                    Bits.SetShort(acc.Data, 1, (ushort)evtNumA3.Value);
                    break;
                // Palette
                case 0x0D:
                case 0x0E:
                    acc.Param1 &= 0xF0;
                    acc.Param1 |= (byte)evtNumA3.Value;
                    break;
                // Sprite Sequence
                case 0x08:
                    acc.Param1 = (byte)evtNumA3.Value;
                    acc.Param2 = (byte)evtNumA4.Value;
                    Bits.SetBit(acc.Data, 1, 3, evtEffects.GetItemChecked(0));
                    Bits.SetBit(acc.Data, 1, 4, evtEffects.GetItemChecked(1));
                    Bits.SetBit(acc.Data, 1, 6, evtEffects.GetItemChecked(2));
                    Bits.SetBit(acc.Data, 2, 7, evtEffects.GetItemChecked(3));
                    break;
                case 0x10:
                    acc.Param1 = (byte)evtNameA1.SelectedIndex;
                    Bits.SetBit(acc.Data, 1, 6, evtEffects.GetItemChecked(0));
                    Bits.SetBit(acc.Data, 1, 7, evtEffects.GetItemChecked(1));
                    break;
                case 0x3E:         // Create NPC packet @ obj coords...
                    acc.Param2 = (byte)evtNameA1.SelectedIndex;
                    acc.Param1 = (byte)evtNameA2.SelectedIndex;
                    Bits.SetShort(acc.Data, 3, (ushort)evtNumC1.Value);
                    break;
                case 0x3F:         // Create NPC packet...
                    acc.Param1 = (byte)evtNameA2.SelectedIndex;
                    Bits.SetShort(acc.Data, 2, (ushort)evtNumC1.Value);
                    break;
                case 0xD0:
                    Bits.SetShort(acc.Data, 1, (ushort)evtNumA3.Value);
                    break;
                // Sprite Animation

                // Shift isometric units
                case 0x50:
                case 0x51:
                case 0x52:
                case 0x53:
                case 0x54:
                case 0x55:
                case 0x56:
                case 0x57:
                case 0x58:
                case 0x5A:
                case 0x5B:
                    acc.Param1 = (byte)evtNumA3.Value;
                    break;
                case 0x7E:
                case 0x7F:
                    Bits.SetShort(acc.Data, 1, (ushort)evtNumA3.Value);
                    break;
                // Shift 1px units
                case 0x60:
                case 0x61:
                case 0x62:
                case 0x63:
                case 0x64:
                case 0x65:
                case 0x66:
                case 0x67:
                case 0x68:
                case 0x6A:
                case 0x6B:
                    acc.Param1 = (byte)evtNumA3.Value;
                    break;
                // Face direction
                case 0x7B:
                    acc.Param1 = (byte)evtNumA3.Value;
                    break;
                // Shift to coords
                case 0x80:
                case 0x81:
                case 0x82:
                case 0x83:
                case 0x84:
                    if (acc.Opcode != 0x80 && acc.Opcode != 0x82)
                    {
                        acc.Param1 = (byte)((sbyte)evtNumA3.Value);
                        acc.Param2 = (byte)((sbyte)evtNumA4.Value);
                    }
                    else
                    {
                        acc.Param1 = (byte)evtNumA3.Value;
                        acc.Param2 = (byte)evtNumA4.Value;
                    }
                    break;
                case 0x87:
                case 0x95:
                    acc.Param1 = (byte)evtNameA1.SelectedIndex;
                    break;
                case 0x90:
                case 0x91:
                    acc.Param3 = (byte)evtNumA1.Value;
                    if (acc.Opcode != 0x90)
                    {
                        acc.Param1 = (byte)((sbyte)evtNumA3.Value);
                        acc.Param2 = (byte)((sbyte)evtNumA4.Value);
                    }
                    else
                    {
                        acc.Param1 = (byte)evtNumA3.Value;
                        acc.Param2 = (byte)evtNumA4.Value;
                    }
                    break;
                case 0x92:
                case 0x93:
                case 0x94:
                    acc.Param3 = (byte)(evtNameA2.SelectedIndex << 5);
                    acc.Param3 &= 0xE0; acc.Param3 |= (byte)evtNumA2.Value;
                    if (acc.Opcode != 0x92)
                    {
                        acc.Param1 = (byte)((sbyte)evtNumA3.Value);
                        acc.Param2 = (byte)((sbyte)evtNumA4.Value);
                    }
                    else
                    {
                        acc.Param1 = (byte)evtNumA3.Value;
                        acc.Param2 = (byte)evtNumA4.Value;
                    }
                    break;
                // Audio playback
                case 0x9C:
                    acc.Param1 = (byte)evtNameA1.SelectedIndex;
                    break;
                case 0x9D:
                    acc.Param1 = (byte)evtNameA1.SelectedIndex;
                    acc.Param2 = (byte)evtNumA3.Value;
                    break;
                case 0x9E:
                    acc.Param1 = (byte)evtNumA3.Value;
                    acc.Param2 = (byte)evtNumA4.Value;
                    break;
                // Memory
                case 0xA0:
                case 0xA1:
                case 0xA2:
                    acc.Opcode = (byte)(((((byte)(evtNumA3.Value - 0x7040) << 3) & 0x0F00) >> 8) + 0xA0);
                    acc.Param1 = (byte)(((byte)(evtNumA3.Value - 0x7040) << 3) & 0xF8);
                    acc.Param1 &= 0xF8; acc.Param1 |= (byte)evtNumA4.Value;
                    break;
                case 0xA4:
                case 0xA5:
                case 0xA6:
                    acc.Opcode = (byte)(((((byte)(evtNumA3.Value - 0x7040) << 3) & 0x0F00) >> 8) + 0xA4);
                    acc.Param1 = (byte)(((byte)(evtNumA3.Value - 0x7040) << 3) & 0xF8);
                    acc.Param1 &= 0xF8; acc.Param1 |= (byte)evtNumA4.Value;
                    break;
                case 0xA8:
                case 0xA9:
                    acc.Param1 = (byte)(evtNumA3.Value - 0x70A0);
                    acc.Param2 = (byte)evtNumA4.Value;
                    break;
                case 0xAA:
                case 0xAB:
                    acc.Param1 = (byte)(evtNumA3.Value - 0x70A0);
                    break;
                case 0xB0:
                case 0xB1:
                case 0xC2:
                    acc.Param1 = (byte)((evtNumA3.Value - 0x7000) / 2);
                    Bits.SetShort(acc.Data, 2, (ushort)evtNumA4.Value);
                    break;
                case 0xB2:
                case 0xB3:
                case 0xD6:
                case 0xBB:
                    acc.Param1 = (byte)((evtNumA3.Value - 0x7000) / 2);
                    break;
                case 0xB5:
                    acc.Param1 = (byte)(evtNumA3.Value - 0x70A0);
                    break;
                case 0xB7:
                    acc.Param1 = (byte)((evtNumA3.Value - 0x7000) / 2);
                    Bits.SetShort(acc.Data, 2, (ushort)evtNumA4.Value);
                    break;
                case 0xBC:
                case 0xBD:
                    acc.Param1 = (byte)((evtNumA3.Value - 0x7000) / 2);
                    acc.Param2 = (byte)((evtNumA4.Value - 0x7000) / 2);
                    break;
                case 0xD8:
                case 0xD9:
                case 0xDA:
                    acc.Opcode = (byte)(((((byte)(evtNumA3.Value - 0x7040) << 3) & 0x0F00) >> 8) + 0xD8);
                    acc.Param1 = (byte)(((byte)(evtNumA3.Value - 0x7040) << 3) & 0xF8);
                    acc.Param1 &= 0xF8; acc.Param1 |= (byte)evtNumA4.Value;
                    Bits.SetShort(acc.Data, 2, (ushort)evtNumC1.Value);
                    break;
                case 0xDC:
                case 0xDD:
                case 0xDE:
                    acc.Opcode = (byte)(((((byte)(evtNumA3.Value - 0x7040) << 3) & 0x0F00) >> 8) + 0xDC);
                    acc.Param1 = (byte)(((byte)(evtNumA3.Value - 0x7040) << 3) & 0xF8);
                    acc.Param1 &= 0xF8; acc.Param1 |= (byte)evtNumA4.Value;
                    Bits.SetShort(acc.Data, 2, (ushort)evtNumC1.Value);
                    break;
                case 0xE0:
                case 0xE1:
                    acc.Param1 = (byte)(evtNumA3.Value - 0x70A0);
                    acc.Param2 = (byte)evtNumA4.Value;
                    Bits.SetShort(acc.Data, 3, (ushort)evtNumC1.Value);
                    break;
                case 0xE4:
                case 0xE5:
                    acc.Param1 = (byte)((evtNumA3.Value - 0x7000) / 2);
                    Bits.SetShort(acc.Data, 2, (ushort)evtNumA4.Value);
                    Bits.SetShort(acc.Data, 4, (ushort)evtNumC1.Value);
                    break;
                case 0xE8:
                    Bits.SetShort(acc.Data, 1, (ushort)evtNumA3.Value);
                    break;
                case 0xE9:
                    Bits.SetShort(acc.Data, 1, (ushort)evtNumA3.Value);
                    Bits.SetShort(acc.Data, 3, (ushort)evtNumA4.Value);
                    break;
                // Memory $700C
                case 0xAC:
                case 0xAD:
                case 0xB6:
                case 0xC0:
                    Bits.SetShort(acc.Data, 1, (ushort)evtNumA3.Value);
                    break;
                case 0xB4:
                    acc.Param1 = (byte)(evtNumA3.Value - 0x70A0);
                    break;
                case 0xB8:
                case 0xB9:
                case 0xBA:
                case 0xC1:
                    acc.Param1 = (byte)((evtNumA3.Value - 0x7000) / 2);
                    break;
                case 0xC4:
                case 0xC5:
                case 0xC6:
                    acc.Param1 = (byte)evtNameA1.SelectedIndex;
                    Bits.SetBit(acc.Data, 1, 6, evtNameA2.SelectedIndex == 1);
                    break;
                case 0xDB:
                case 0xDF:
                    Bits.SetShort(acc.Data, 1, (ushort)evtNumA3.Value);
                    break;
                case 0xE2:
                case 0xE3:
                    Bits.SetShort(acc.Data, 1, (ushort)evtNumA3.Value);
                    Bits.SetShort(acc.Data, 3, (ushort)evtNumA4.Value);
                    break;
                case 0xE6:
                case 0xE7:
                    for (int i = 0; i < 16; i++)
                        Bits.SetBit(acc.Data, 1, i, evtEffects.GetItemChecked(i));
                    Bits.SetShort(acc.Data, 3, (ushort)evtNumC1.Value);
                    break;
                case 0xEA:
                case 0xEB:
                case 0xEC:
                case 0xED:
                case 0xEE:
                case 0xEF:
                    Bits.SetShort(acc.Data, 1, (ushort)evtNumA3.Value);
                    break;
                // Jump to
                case 0xD2:
                case 0xD3:
                    Bits.SetShort(acc.Data, 1, (ushort)evtNumA3.Value);
                    break;
                case 0xD4:
                    acc.Param1 = (byte)evtNumA3.Value;
                    break;
                // Object memory
                case 0xF2:         // Set obj presence...  
                case 0xF3:         // Set obj engage type...
                case 0xF8:         // If object in level ..., presence =...
                    Bits.SetShort(acc.Data, 1, (ushort)evtNumA1.Value);
                    acc.Param2 &= 1; acc.Param2 |= (byte)(evtNameA2.SelectedIndex << 1);
                    Bits.SetBit(acc.Data, 2, 7, evtEffects.GetItemChecked(0));    // set bit 7 if true
                    if (acc.Opcode == 0xF8)
                        Bits.SetShort(acc.Data, 3, (ushort)evtNumC1.Value);
                    /* 
                     * TODO
                     * synchronize evtNameA with evtNumA
                     */
                    break;
                // Pause script
                case 0xF0:
                    acc.Param1 = (byte)(evtNumA3.Value - 1);
                    break;
                case 0xF1:
                    Bits.SetShort(acc.Data, 1, (ushort)(evtNumA3.Value - 1));
                    break;
                case 0xFD:
                    switch (acc.Param1)
                    {
                        case 0x0F:
                            acc.Param2 = (byte)evtNumA3.Value;
                            break;
                        // Memory
                        case 0xB6:
                            acc.Param2 = (byte)((evtNumA3.Value - 0x7000) / 2);
                            acc.Param3 = (byte)((byte)(evtNumA4.Value - 1) ^ 0xFF);
                            break;
                        // Memory $700C
                        case 0xB0:
                        case 0xB1:
                        case 0xB2:
                            Bits.SetShort(acc.Data, 2, (ushort)evtNumA3.Value);
                            break;
                        case 0xB3:
                        case 0xB4:
                        case 0xB5:
                            acc.Param2 = (byte)((evtNumA3.Value - 0x7000) / 2);
                            break;
                    }
                    break;
            }
        }

        /// <summary>
        /// Resets the values of all controls linked to the command's properties.
        /// </summary>
        public void ResetControls()
        {
            this.Updating = true;

            // evtNameA1
            evtNameA1.DropDownWidth = evtNameA1.Width; 
            evtNameA1.Items.Clear();
            evtNameA1.ResetText(); 
            evtNameA1.Enabled = false;
            evtNameA1.DrawMode = DrawMode.Normal; 
            evtNameA1.ItemHeight = 13;
            evtNameA1.BackColor = SystemColors.Window;

            // evtNameA2
            evtNameA2.DropDownWidth = evtNameA2.Width;
            evtNameA2.Items.Clear(); 
            evtNameA2.ResetText(); 
            evtNameA2.Enabled = false;
            evtNameA2.DrawMode = DrawMode.Normal; 
            evtNameA2.ItemHeight = 13; 
            evtNameA2.BackColor = SystemColors.Window;

            // evtNumA1
            evtNumA1.Maximum = 255; 
            evtNumA1.Hexadecimal = false;
            evtNumA1.Value = 0; 
            evtNumA1.Enabled = false;

            // evtNumA2
            evtNumA2.Maximum = 255; 
            evtNumA2.Hexadecimal = false; 
            evtNumA2.Value = 0;
            evtNumA2.Enabled = false;

            // evtNumA3
            evtNumA3.Maximum = 255; 
            evtNumA3.Hexadecimal = false; 
            evtNumA3.Minimum = 0; 
            evtNumA3.Increment = 1;
            evtNumA3.Value = 0; 
            evtNumA3.Enabled = false;

            // evtNumA4
            evtNumA4.Maximum = 255; 
            evtNumA4.Hexadecimal = false; 
            evtNumA4.Minimum = 0;
            evtNumA4.Increment = 1; 
            evtNumA4.Value = 0; 
            evtNumA4.Enabled = false;

            // evtNumC1
            evtNumC1.Maximum = 255;
            evtNumC1.Hexadecimal = false;
            evtNumC1.Value = 0; 
            evtNumC1.Enabled = false;

            // evtNumC2
            evtNumC2.Maximum = 255;
            evtNumC2.Hexadecimal = false;
            evtNumC2.Value = 0;
            evtNumC2.Enabled = false;

            // evtEffects
            evtEffects.Height = 68; 
            evtEffects.ColumnWidth = 132;
            evtEffects.Items.Clear(); 
            evtEffects.Enabled = false;

            // groupBoxes
            groupBoxA.Text = "";
            groupBoxB.Text = "";
            groupBoxC.Text = "";

            // labels
            labelEvtA1.Text = "";
            labelEvtA2.Text = "";
            labelEvtA3.Text = "";
            labelEvtA4.Text = "";
            labelEvtC1.Text = "";
            labelEvtC2.Text = "";

            // Finished
            this.Updating = false;
        }
        /// <summary>
        /// Arranges and organizes the controls in the proper order according to the
        /// available options in the current command's properties.
        /// </summary>
        public void ArrangeControls()
        {
            this.Updating = true;

            // Visibility : groupBoxes
            groupBoxA.Visible =
            groupBoxA.Text != "" ||
            labelEvtA1.Text != "" ||
            labelEvtA2.Text != "" ||
            labelEvtA3.Text != "" ||
            labelEvtA4.Text != "";
            groupBoxB.Visible =
                groupBoxB.Text != "" ||
                evtEffects.Items.Count > 0;
            groupBoxC.Visible =
                groupBoxC.Text != "" ||
                labelEvtC1.Text != "" ||
                labelEvtC2.Text != "";

            // Visibility : panels
            panelEvtA1.Visible = evtNumA1.Enabled || evtNameA1.Enabled;
            panelEvtA2.Visible = evtNumA2.Enabled || evtNameA2.Enabled;
            panelEvtA3_4.Visible = evtNumA3.Enabled || evtNumA4.Enabled;

            // evtEffects height
            if (evtEffects.Items.Count < 4)
                evtEffects.Height = evtEffects.Items.Count * 16 + 4;
            else
                evtEffects.Height = 68;

            // Visibility : labels
            labelEvtA1.Visible = labelEvtA1.Text != "";
            labelEvtA2.Visible = labelEvtA2.Text != "";
            labelEvtA3.Visible = labelEvtA3.Text != "";
            labelEvtA4.Visible = labelEvtA4.Text != "";

            // Visibility : controls
            evtNumA1.Visible = evtNumA1.Enabled;
            evtNumA2.Visible = evtNumA2.Enabled;
            evtNumA3.Visible = evtNumA3.Enabled;
            evtNumA4.Visible = evtNumA4.Enabled;
            evtNameA1.Visible = evtNameA1.Enabled;
            evtNameA2.Visible = evtNameA2.Enabled;
            evtNumC2.Visible = evtNumC2.Enabled;

            // Organize Z order
            groupBoxA.BringToFront();
            groupBoxB.BringToFront();
            groupBoxC.BringToFront();
            panelCommand.BringToFront();
            labelEvtA1.BringToFront();
            evtNameA1.BringToFront();
            evtNumA1.BringToFront();
            labelEvtA2.BringToFront();
            evtNameA2.BringToFront();
            evtNumA2.BringToFront();
            labelEvtA3.BringToFront();
            evtNumA3.BringToFront();
            labelEvtA4.BringToFront();
            evtNumA4.BringToFront();
            labelEvtC1.BringToFront();
            evtNumC1.BringToFront();
            labelEvtC2.BringToFront();
            evtNumC2.BringToFront();
            panelButtons.BringToFront();

            // evtName
            if (evtNameA1.DrawMode == DrawMode.OwnerDrawFixed)
            {
                evtNameA1.BackColor = SystemColors.ControlDarkDark;
                evtNameA1.ItemHeight = 15;
            }
            if (evtNameA2.DrawMode == DrawMode.OwnerDrawFixed)
            {
                evtNameA2.BackColor = SystemColors.ControlDarkDark;
                evtNameA2.ItemHeight = 15;
            }

            // Set CommandForm height based on control visibility/sizes
            this.Height = panelCommand.Bottom + panelCommand.Margin.Bottom + this.TitleHeight;

            // Finished
            this.Updating = false;
        }

        #endregion

        #region Event Handlers

        // CommandForm
        private void CommandForm_Resize(object sender, EventArgs e)
        {
            panelCommand.Invalidate();
        }

        // Command selection
        private void categories_es_SelectedIndexChanged(object sender, EventArgs e)
        {
            SwitchCommandType(ElementType.EventScript);
        }
        private void categories_aq_SelectedIndexChanged(object sender, EventArgs e)
        {
            SwitchCommandType(ElementType.ActionScript);
        }
        private void commands_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;

            // Set the current event and/or action command
            if (type == ElementType.EventScript)
            {
                var opcode = Lists.EventOpcodes[categories_es.SelectedIndex][commands.SelectedIndex];
                var param1 = Lists.EventParams[categories_es.SelectedIndex][commands.SelectedIndex];
                var data = new byte[ScriptEnums.GetEventCommandLength(opcode, param1)];
                data[0] = (byte)opcode;
                if (data.Length > 1)
                    data[1] = (byte)param1;
                this.evc = new EventCommand(data, 0);
                this.acc = null;
            }
            else
            {
                var opcode = Lists.ActionOpcodes[categories_aq.SelectedIndex][commands.SelectedIndex];
                var param1 = Lists.ActionParams[categories_aq.SelectedIndex][commands.SelectedIndex];
                var data = new byte[ScriptEnums.GetActionCommandLength(opcode, param1)];
                data[0] = (byte)opcode;
                if (data.Length > 1)
                    data[1] = (byte)param1;
                this.acc = new ActionCommand(data, 0);
            }
            //
            panelCommand.SuspendDrawing();
            //
            ResetControls();
            if (type == ElementType.EventScript)
                ReadFromEventCommand();
            else
                ReadFromActionCommand();
            //
            panelCommand.ResumeDrawing();
        }
        private void actionButton_CheckedChanged(object sender, EventArgs e)
        {
            this.Updating = true;
            //
            if (actionButton.Checked)
            {
                categories_es.Visible = false;
                categories_aq.Visible = true;
                categories_aq.SelectedIndex = 0;
                SwitchCommandType(ElementType.ActionScript);
            }
            else
            {
                categories_aq.Visible = false;
                categories_es.Visible = true;
                categories_es.SelectedIndex = 0;
                SwitchCommandType(ElementType.EventScript);
            }
            //
            this.Updating = false;
        }

        // Command properties
        private void evtNameA1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            //
            panelCommand.SuspendDrawing();
            //
            if (acc != null)
            {
                switch (acc.Opcode)
                {
                    case 0xF2:
                    case 0xF3:
                    case 0xF8:
                        evtNumA1.Value = evtNameA1.SelectedIndex;  // Area names
                        break;
                }
            }
            else
            {
                switch (evc.Opcode)
                {
                    case 0xF2:
                    case 0xF3:
                    case 0xF8:
                    case 0x68:
                    case 0x6A:
                    case 0x6B:
                    case 0x60:
                    case 0x62:
                        evtNumA1.Value = evtNameA1.SelectedIndex;  // Area names, Dialogue names
                        break;
                    case 0x50:
                    case 0x51:
                        evtNumA1.Value = Items.Model.Names.GetUnsortedIndex(evtNameA1.SelectedIndex);    // Item names
                        break;
                    case 0x4E:
                        this.Updating = true;

                        // Reset controls
                        labelEvtA2.Text = "";
                        labelEvtA3.Text = "";
                        evtNameA2.Items.Clear();
                        evtNameA2.ResetText();
                        evtNameA2.Enabled = false;
                        evtNameA2.DropDownWidth = evtNameA2.Width;
                        evtNameA2.DrawMode = DrawMode.Normal;
                        evtNameA2.BackColor = SystemColors.Window;
                        evtNameA2.ItemHeight = 13;
                        evtNumA2.Value = 0;
                        evtNumA2.Maximum = 255;
                        evtNumA2.Enabled = false;
                        evtNumA3.Value = 0;
                        evtNumA3.Maximum = 255;
                        evtNumA3.Enabled = false;

                        // Load properties
                        switch (evtNameA1.SelectedIndex)
                        {
                            case 2: // open world location
                                labelEvtA2.Text = "Location";
                                evtNameA2.Items.AddRange(Lists.Numerize(Lists.Locations));
                                evtNameA2.DropDownWidth = 200; evtNameA2.Enabled = true;
                                evtNameA2.SelectedIndex = 0;
                                break;
                            case 3: // open shop menu
                                labelEvtA2.Text = "Shop menu";
                                evtNameA2.Items.AddRange(Lists.Shops);
                                evtNameA2.DropDownWidth = 200; evtNameA2.Enabled = true;
                                evtNameA2.SelectedIndex = 0;
                                break;
                            case 5: // items maxed out
                                labelEvtA2.Text = "Toss item";
                                evtNameA2.Items.AddRange(Items.Model.Names.Names);
                                evtNameA2.DrawMode = DrawMode.OwnerDrawFixed; evtNameA2.Enabled = true;
                                evtNumA2.Enabled = true;
                                evtNameA2.SelectedIndex = Items.Model.Names.GetSortedIndex((int)evtNumA2.Value);
                                break;
                            case 7: // menu tutorial
                                labelEvtA2.Text = "Tutorial";
                                evtNameA2.Items.AddRange(Lists.Tutorials);
                                evtNameA2.Enabled = true;
                                evtNameA2.SelectedIndex = 0;
                                break;
                            case 8: // add star piece
                            case 13:// run star piece end sequence
                                labelEvtA2.Text = "Star Piece";
                                evtNumA2.Enabled = true;
                                evtNumA2.Maximum = 7;
                                break;
                            case 16:    // world map event
                                labelEvtA2.Text = "Map event";
                                evtNameA2.Items.AddRange(new string[] 
                                { 
                                    "Mario falls to pipehouse", 
                                    "Mario returns to MK",
                                    "Mario takes Nimbus bus" 
                                });
                                evtNameA2.Enabled = true;
                                evtNameA2.SelectedIndex = 0;
                                break;
                        }
                        ArrangeControls();
                        //
                        this.Updating = false;
                        break;
                    case 0x97:
                        labelEvtA3.Text = evtNameA1.SelectedIndex == 0 ? "Slow down" : "Speed up";
                        break;
                    case 0xFD:
                        switch (evc.Param1)
                        {
                            case 0x58:
                                evtNumA1.Value = Items.Model.Names.GetUnsortedIndex(evtNameA1.SelectedIndex);    // Item names
                                break;
                        }
                        break;
                }
            }
            //
            panelCommand.ResumeDrawing();
        }
        private void evtNameA1_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0)
                return;
            Do.DrawName(sender, e, new BattleDialoguePreview(), Items.Model.Names, Fonts.Model.Menu,
                Fonts.Model.Palette_Menu.Palettes[0], 8, 10, 0, 128, true, false, Menus.Model.MenuBG_256x255);
        }
        private void evtNumA1_ValueChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            //
            if (acc != null)
            {
                switch (acc.Opcode)
                {
                    case 0xF2:
                    case 0xF3:
                    case 0xF8:
                        evtNameA1.SelectedIndex = (int)evtNumA1.Value;  // Level names, Dialogue names
                        break;
                }
            }
            else
            {
                switch (evc.Opcode)
                {
                    case 0xF2:
                    case 0xF3:
                    case 0xF8:
                    case 0x68:
                    case 0x6A:
                    case 0x6B:
                    case 0x60:
                    case 0x62:
                        evtNameA1.SelectedIndex = (int)evtNumA1.Value;  // Level names, Dialogue names
                        break;
                    case 0x50:
                    case 0x51:
                        evtNameA1.SelectedIndex = Items.Model.Names.GetSortedIndex((int)evtNumA1.Value);    // Item names
                        break;
                }
            }
        }
        private void evtNameA2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            if (acc != null)
                return;
            //
            switch (evc.Opcode)
            {
                case 0x54:
                case 0x4E:
                    evtNumA2.Value = Items.Model.Names.GetUnsortedIndex(evtNameA2.SelectedIndex);    // Item names
                    break;
                case 0x4A:
                    evtNumA2.Value = evtNameA2.SelectedIndex; // battlefields
                    break;
                default:
                    if (evc.Opcode <= 0x2F)
                    {
                        labelEvtA3.Text = "";
                        groupBoxB.Text = "";
                        evtNumA3.Value = 0; evtNumA3.Maximum = 255; evtNumA3.Enabled = false;
                        evtEffects.Items.Clear(); evtEffects.Enabled = false;
                        if (evtNameA2.SelectedIndex < 3) // queue options need sync bit
                        {
                            evtEffects.Items.AddRange(new string[] { "asynchronous" });
                            evtEffects.Enabled = true;
                        }
                        else if (evtNameA2.SelectedIndex >= 3 && evtNameA2.SelectedIndex <= 6) // options 0xF2-0xF5
                        {
                            labelEvtA3.Text = "Action #";
                            evtNumA3.Maximum = 0x3FF; evtNumA3.Enabled = true;
                        }
                        else
                        {
                            labelEvtA3.Text = "";
                            evtNumA3.Enabled = false;
                        }
                    }
                    break;
            }
            ArrangeControls();
        }
        private void evtNameA2_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0)
                return;
            Do.DrawName(sender, e, new BattleDialoguePreview(), Items.Model.Names, Fonts.Model.Menu,
                Fonts.Model.Palette_Menu.Palettes[0], 8, 10, 0, 128, true, false, Menus.Model.MenuBG_256x255);
        }
        private void evtNumA2_ValueChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            if (acc == null)
            {
                switch (evc.Opcode)
                {
                    case 0x54:
                    case 0x4E:
                        if (evtNameA1.SelectedIndex != 8 &&
                            evtNameA1.SelectedIndex != 13)
                            evtNameA2.SelectedIndex = Items.Model.Names.GetSortedIndex((int)evtNumA2.Value);    // Item names
                        break;
                    case 0x4A:
                        evtNameA2.SelectedIndex = (int)evtNumA2.Value;    // battlefields
                        break;
                }
            }
        }
        private void evtEffects_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (acc != null)
            {
                switch (acc.Opcode)
                {
                    case 0x08:
                        labelEvtA4.Text = evtEffects.GetItemChecked(0) ? "Mold" : "Sequence";
                        break;
                }
            }
        }

        // Buttons
        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            if (type == ElementType.EventScript)
            {
                WriteToEventCommand();
                this.evc.Modified = true;
                this.Tag = this.evc;
            }
            else
            {
                WriteToActionCommand();
                this.acc.Modified = true;
                this.Tag = this.acc;
            }
            this.Close();
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        #endregion
    }
}
