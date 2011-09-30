using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using LAZYSHELL.Properties;
using LAZYSHELL.ScriptsEditor;
using LAZYSHELL.ScriptsEditor.Commands;

namespace LAZYSHELL
{
    public partial class EventScripts : Form
    {
        #region Variables
        // main

        private long checksum;
        private Settings settings = Settings.Default;
        private EventScript[] eventScripts { get { return Model.EventScripts; } set { Model.EventScripts = value; } }
        public EventScript[] ThisEventScripts { get { return eventScripts; } set { eventScripts = value; } }
        private EventScript eventScript { get { return eventScripts[index]; } set { eventScripts[index] = value; } }
        private bool updatingScript = true;
        private bool updatingControls = false;
        private bool isActionScript = false;
        private bool isActionSelected = false;
        private int index { get { return (int)eventNum.Value; } set { eventNum.Value = value; } }
        private int type { get { return eventName.SelectedIndex; } set { eventName.SelectedIndex = value; } }
        private int currentScript = 0;
        private Stack<Navigate> navigateBackward = new Stack<Navigate>();
        private Stack<Navigate> navigateForward = new Stack<Navigate>();
        private Navigate lastNavigate;
        private bool disableNavigate;
        //
        private EventScriptCommand esc;
        private ActionQueueCommand aqc;
        private TreeViewWrapper treeViewWrapper;
        public TreeViewWrapper TreeViewWrapper { get { return treeViewWrapper; } }
        private TreeNode editedNode;
        // externally accessed controls
        public ToolStripNumericUpDown EventNum { get { return eventNum; } set { eventNum = value; } }
        public System.Windows.Forms.ToolStripComboBox EventName { get { return eventName; } set { eventName = value; } }
        // pointer recalibration
        private FixPointers fixPointers;
        private bool apply; public bool Apply { get { return apply; } set { apply = value; } }
        private int delta; public int Delta { get { return delta; } set { delta = value; } }
        // other
        private Previewer.Previewer ep;
        private ClearElements clearElements;
        private IOElements ioElements;
        private Search searchWindow;
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
        #region Functions
        // Constructor
        public EventScripts()
        {
            settings.Keystrokes[0x20] = "\x20";
            InitializeComponent();
            Do.AddShortcut(toolStrip4, Keys.Control | Keys.S, new EventHandler(save_Click));
            Do.AddShortcut(toolStrip4, Keys.F2, showDecHex);
            InitializeEventScriptsEditor();
            searchWindow = new Search(eventNum, searchLabelsText, searchLabels, settings.EventLabels);
            new ToolTipLabel(this, toolTip1, showDecHex, null);
            new History(this);
            disableNavigate = true;
            if (settings.RememberLastIndex)
            {
                int lastEventScript = settings.LastEventScript;
                type = Math.Max(0, settings.LastEventScriptCat);
                index = Math.Min((int)eventNum.Maximum, lastEventScript);
            }
            else
                type = 0;
            disableNavigate = false;
            lastNavigate = new Navigate(index, type);
            checksum = Do.GenerateChecksum(eventScripts, actionScripts);
        }
        private void InitializeEventScriptsEditor()
        {
            if (settings.EventLabels.Count == 0)
            {
                settings.EventLabels = new System.Collections.Specialized.StringCollection();
                for (int i = 0; i < 4096; i++)
                    settings.EventLabels.Add("EVENT #" + i);
                settings.EventLabels[16] = "Engage in battle (remove permanently after defeat)";
                settings.EventLabels[17] = "Engage in battle (remove temporarily after defeat)";
                settings.EventLabels[18] = "Engage in battle (do not remove after defeat)";
                settings.EventLabels[19] = "Engage in battle (remove permanently after defeat, if ran away, walk through while blinking)";
                settings.EventLabels[20] = "Engage in battle (remove temporarily after defeat, if ran away, walk through while blinking)";
                settings.EventLabels[24] = "Post-battle, check if lost/won, etc.";
                settings.EventLabels[32] = "Hit a treasure with a mushroom/star/flower";
                settings.EventLabels[33] = "Hit a treasure with an item (item bag sprite)";
                settings.EventLabels[34] = "Hit a treasure with coins";
                settings.EventLabels[65] = "Jump on trampoline";
                settings.EventLabels[269] = "Come up from tree trunk";
                settings.EventLabels[1556] = "Jump on wiggler";
            }
            if (settings.ActionLabels.Count == 0)
            {
                settings.ActionLabels = new System.Collections.Specialized.StringCollection();
                for (int i = 0; i < 1024; i++)
                    settings.ActionLabels.Add("ACTION #" + i);
            }
            if (settings.LevelNames.Count == 0)
                settings.LevelNames.AddRange(Lists.LevelNames);
            eventLabel.Text = settings.EventLabels[(int)this.eventNum.Value];

            treeViewWrapper = new TreeViewWrapper(this.EventScriptTree);
            treeViewWrapper.ChangeScript(eventScripts[(int)this.eventNum.Value]);

            this.autoPointerUpdate.Checked = autoPointerUpdate.Checked;

            UpdateEventScriptsFreeSpace();
        }
        private void RefreshEventScript()
        {
            if (isActionScript)
            {
                foreach (ActionQueueCommand aq in actionScripts[currentScript].Commands)
                    aq.Set = false;
            }
            else
            {
                foreach (EventScriptCommand es in eventScripts[currentScript].Commands)
                {
                    es.Set = false;
                    if (es.EmbeddedActionQueue == null) continue;
                    foreach (ActionQueueCommand aq in es.EmbeddedActionQueue.Commands)
                        aq.Set = false;
                }
            }
            // Update Event Script Offsets
            currentScript = (int)this.eventNum.Value;
            ResetAllEventLists();
            if (isActionScript)
            {
                UpdateActionOffsets();
                treeViewWrapper.ChangeScript(actionScripts[(int)this.eventNum.Value]);
            }
            else
            {
                UpdateScriptOffsets();
                treeViewWrapper.ChangeScript(eventScripts[(int)this.eventNum.Value]);
            }
            UpdateCommandData();
            if (isActionScript)
                return;
            switch (currentScript)
            {
                case 0x1D6:
                case 0x72D:
                case 0x72F:
                case 0xD01:
                case 0xE91:
                    EventScriptTree.Enabled = false;
                    categories_es.Enabled = false;
                    categories_aq.Enabled = false;
                    commands.Enabled = false;
                    MessageBox.Show(
                        "Editing of script #" + currentScript.ToString() + " is not allowed due to parsing issues.",
                        "LAZY SHELL",
                        MessageBoxButtons.OK);
                    break;
                default:
                    EventScriptTree.Enabled = true;
                    categories_es.Enabled = true;
                    categories_aq.Enabled = true;
                    commands.Enabled = true;
                    break;
            }
            if (!isActionScript)
                eventLabel.Text = settings.EventLabels[currentScript];
            else
                eventLabel.Text = settings.ActionLabels[currentScript];
        }
        // GUI settings
        private void ControlEventDisasmMethod()
        {
            updatingControls = false;

            switch (esc.Opcode)
            {
                // Objects
                case 0x32:  // If object present...
                case 0x39:  // If Mario on top of object...
                    if (esc.Opcode == 0x39) labelTitleA.Text = "If Mario on top of object...";
                    else labelTitleA.Text = "If object present...";
                    labelEvtA.Text = "object";
                    labelEvtC.Text = "jump to";
                    evtNameA.Items.AddRange(Lists.ObjectNames); evtNameA.Enabled = true;
                    evtNumC.Hexadecimal = true; evtNumC.Maximum = 0xFFFF; evtNumC.Enabled = true;

                    evtNameA.SelectedIndex = esc.Option;
                    evtNumC.Value = Bits.GetShort(esc.EventData, 2);
                    break;
                case 0x3A:         // If distance between object A and...
                case 0x3B:         // If distance (Z==) between object A and...
                    labelTitleA.Text = "If distance between object A and object B...";
                    labelEvtA.Text = "object A";
                    labelEvtB.Text = "object B";
                    labelEvtC.Text = "less than X";
                    labelEvtD.Text = "less than Y";
                    labelEvtE.Text = "jump to";
                    evtNameA.Items.AddRange(Lists.ObjectNames); evtNameA.Enabled = true;
                    evtNameB.Items.AddRange(Lists.ObjectNames); evtNameB.Enabled = true;
                    evtNumC.Enabled = true;
                    evtNumD.Enabled = true;
                    evtNumE.Enabled = true; evtNumE.Hexadecimal = true; evtNumE.Maximum = 0xFFFF;

                    evtNameA.SelectedIndex = esc.Option;          // object A
                    evtNameB.SelectedIndex = esc.EventData[2];    // object B
                    evtNumC.Value = esc.EventData[3];
                    evtNumD.Value = esc.EventData[4];
                    evtNumE.Value = Bits.GetShort(esc.EventData, 5);
                    break;
                case 0x3D:         // If Mario in air...
                    labelTitleC.Text = "If Mario in air...";
                    labelEvtE.Text = "jump to";
                    evtNumE.Enabled = true; evtNumE.Hexadecimal = true; evtNumE.Maximum = 0xFFFF;

                    evtNumE.Value = Bits.GetShort(esc.EventData, 1);
                    break;
                case 0x3E:         // Create NPC packet @ obj coords...
                    labelTitleA.Text = "Create NPC packet @ obj coords...";
                    labelEvtA.Text = "object";
                    labelEvtC.Text = "packet";
                    labelTitleC.Text = "If object null...";
                    labelEvtE.Text = "jump to";
                    evtNameA.Items.AddRange(Lists.ObjectNames); evtNameA.Enabled = true;
                    evtNumC.Enabled = true; evtNumC.Maximum = 79;
                    evtNumE.Enabled = true; evtNumE.Hexadecimal = true; evtNumE.Maximum = 0xFFFF;

                    evtNameA.SelectedIndex = esc.EventData[2];
                    evtNumC.Value = esc.Option;
                    evtNumE.Value = Bits.GetShort(esc.EventData, 3);
                    break;
                case 0x3F:         // Create NPC packet...
                    labelTitleA.Text = "Create NPC packet @ Mario coords...";
                    labelEvtC.Text = "packet";
                    labelTitleC.Text = "If Mario null...";
                    labelEvtE.Text = "jump to";
                    evtNumC.Enabled = true; evtNumC.Maximum = 79;
                    evtNumE.Enabled = true; evtNumE.Hexadecimal = true; evtNumE.Maximum = 0xFFFF;

                    evtNumC.Value = esc.Option;
                    evtNumE.Value = Bits.GetShort(esc.EventData, 2);
                    break;
                case 0x42:         // If Mario on top of an object...
                    labelTitleC.Text = "If Mario on top of an object...";
                    labelEvtE.Text = "jump to";
                    labelEvtF.Text = "else jump to";
                    evtNumE.Enabled = true; evtNumE.Hexadecimal = true; evtNumE.Maximum = 0xFFFF;
                    evtNumF.Enabled = true; evtNumF.Hexadecimal = true; evtNumF.Maximum = 0xFFFF;

                    evtNumE.Value = Bits.GetShort(esc.EventData, 1);
                    evtNumF.Value = Bits.GetShort(esc.EventData, 3);
                    break;
                case 0xF2:         // Set obj presence...  
                case 0xF3:         // Set obj engage type...
                case 0xF8:         // If object in level ..., presence =...
                    if (esc.Opcode == 0xF2)
                    {
                        labelTitleA.Text = "Set presence in...";
                        labelTitleB.Text = "presence is...";
                    }
                    else if (esc.Opcode == 0xF3)
                    {
                        labelTitleA.Text = "Set event trigger...";
                        labelTitleB.Text = "event trigger enabled is...";
                    }
                    else
                    {
                        labelTitleA.Text = "If presence in...";
                        labelTitleB.Text = "presence is...";
                        labelEvtE.Text = "jump to";
                    }
                    labelEvtA.Text = "level";
                    labelEvtB.Text = "for object";
                    evtNameA.Items.AddRange(Lists.Convert(settings.LevelNames)); evtNameA.Enabled = true;
                    evtNameB.Items.AddRange(Lists.ObjectNames); evtNameB.Enabled = true;
                    evtNumA.Enabled = true; evtNumA.Maximum = 511;
                    evtEffects.Items.AddRange(new object[] { "true" }); evtEffects.Enabled = true;
                    if (esc.Opcode == 0xF8)
                        evtNumE.Enabled = true; evtNumE.Hexadecimal = true; evtNumE.Maximum = 0xFFFF;

                    evtNumA.Value = Bits.GetShort(esc.EventData, 1) & 0x1FF;
                    evtNameA.SelectedIndex = (int)evtNumA.Value;
                    evtNameB.SelectedIndex = (esc.EventData[2] >> 1) & 0x3F;
                    evtEffects.SetItemChecked(0, (esc.EventData[2] & 0x80) == 0x80);
                    if (esc.Opcode == 0xF8)
                        evtNumE.Value = Bits.GetShort(esc.EventData, 3);
                    /* 
                     * TODO
                     * synchronize evtNameA with evtNumA
                     */
                    break;

                // Joypad
                case 0x34:
                case 0x35:
                    if (esc.Opcode == 0x34) labelTitleB.Text = "Joypad enable exclusively (reset @ return)...";
                    else labelTitleB.Text = "Joypad enable exclusively...";

                    evtEffects.Items.AddRange(Lists.ButtonNames); evtEffects.Enabled = true;

                    for (int i = 1, j = 0; j < 8; i *= 2, j++)
                        evtEffects.SetItemChecked(j, (esc.Option & i) == i);
                    break;

                // Party Members
                case 0x36:
                    labelTitleA.Text = "Add character to party...";
                    labelEvtA.Text = "character";
                    evtNameA.Items.AddRange(Lists.CharacterNames); evtNameA.Enabled = true;
                    evtEffects.Items.AddRange(new string[] { "increment party capacity" }); evtEffects.Enabled = true;

                    evtNameA.SelectedIndex = esc.Option & 7;
                    evtEffects.SetItemChecked(0, (esc.Option & 0x80) == 0x80);
                    break;
                case 0x54:
                    labelTitleA.Text = "Equip item to character...";
                    labelEvtA.Text = "character";
                    labelEvtB.Text = "item";
                    evtNameA.Items.AddRange(Lists.CharacterNames); evtNameA.Enabled = true;
                    evtNameB.Items.AddRange(Model.ItemNames.GetNames()); evtNameB.Enabled = true;
                    evtNumB.Maximum = 176; evtNumB.Enabled = true;

                    evtNameA.SelectedIndex = esc.Option & 7;
                    evtNumB.Value = esc.EventData[2];
                    evtNameB.SelectedIndex = Model.ItemNames.GetIndexFromNum((int)evtNumB.Value);
                    break;
                /* 
                * TODO
                * synchronize evtNameB with evtNumB
                */
                case 0x56:
                    labelTitleA.Text = "Subtract mem $7000 from character's HP...";
                    labelEvtA.Text = "character";
                    evtNameA.Items.AddRange(Lists.CharacterNames); evtNameA.Enabled = true;

                    evtNameA.SelectedIndex = esc.Option & 7;
                    break;

                // Inventory
                case 0x50:
                case 0x51:
                    if (esc.Opcode == 0x50) labelTitleA.Text = "Put x1 item in inventory...";
                    else labelTitleA.Text = "Remove x1 item in inventory...";

                    labelEvtA.Text = "item";
                    evtNameA.Items.AddRange(Model.ItemNames.GetNames()); evtNameA.Enabled = true;
                    evtNumA.Maximum = 176; evtNumA.Enabled = true;

                    evtNumA.Value = esc.Option;
                    evtNameA.SelectedIndex = Model.ItemNames.GetIndexFromNum((int)evtNumA.Value);
                    break;
                /* 
                * TODO
                * synchronize evtNameA with evtNumA
                */
                case 0x52:
                case 0x53:
                    if (esc.Opcode == 0x52) labelTitleA.Text = "Add to coins...";
                    else labelTitleA.Text = "Add to frog coins...";

                    labelEvtA.Text = "addend";
                    evtNumA.Enabled = true;

                    evtNumA.Value = esc.Option;
                    break;

                // Battle
                case 0x4A:
                    labelTitleA.Text = "Engage in battle with pack...";
                    labelEvtB.Text = "battlefield";
                    labelEvtC.Text = "pack";
                    evtNameB.Items.AddRange(Lists.Numerize(Lists.BattlefieldNames)); evtNameB.Enabled = true;
                    evtNumB.Maximum = 63; evtNumB.Enabled = true;
                    evtNumC.Enabled = true;

                    evtNumB.Value = esc.EventData[3];
                    evtNameB.SelectedIndex = esc.EventData[3];
                    evtNumC.Value = esc.Option;
                    break;

                // Levels
                /* 
                 * TODO
                 * synchronize evtNameA with evtNumA for case 0x68,0x6A,0x6B
                 */
                case 0x4B:      // Open, world map point...
                    labelTitleA.Text = "Open world map point...";
                    labelEvtA.Text = "point";
                    labelTitleB.Text = "unknown bits";
                    evtNameA.Items.AddRange(Lists.Numerize(Lists.MapNames)); evtNameA.Enabled = true;
                    evtEffects.Items.AddRange(new string[] { "bit 5", "bit 6", "bit 7" }); evtEffects.Enabled = true;

                    evtNameA.SelectedIndex = esc.Option;
                    evtEffects.SetItemChecked(0, (esc.EventData[2] & 0x20) == 0x20);
                    evtEffects.SetItemChecked(1, (esc.EventData[2] & 0x40) == 0x40);
                    evtEffects.SetItemChecked(2, (esc.EventData[2] & 0x80) == 0x80);
                    break;
                case 0x68:
                    labelTitleA.Text = "Open level and place Mario @ coords...";
                    labelEvtA.Text = "level";
                    labelEvtB.Text = "radial / Z";
                    labelEvtC.Text = "X";
                    labelEvtD.Text = "Y";
                    evtNameA.Items.AddRange(Lists.Convert(settings.LevelNames)); evtNameA.Enabled = true;
                    evtNameB.Items.AddRange(Lists.Directions); evtNameB.Enabled = true;
                    evtNumA.Enabled = true; evtNumA.Maximum = 511;
                    evtNumB.Enabled = true; evtNumB.Maximum = 31;
                    evtNumC.Enabled = true;
                    evtNumD.Enabled = true;
                    evtEffects.Items.AddRange(new object[] { "show message", "run entrance event", "Z coord +½" });
                    evtEffects.Enabled = true;

                    evtNumA.Value = Bits.GetShort(esc.EventData, 1) & 0x1FF;
                    evtNameA.SelectedIndex = (int)evtNumA.Value;
                    evtNumB.Value = esc.EventData[5] & 0x1F;
                    evtNameB.SelectedIndex = (esc.EventData[5] & 0xE0) >> 5;
                    evtNumC.Value = esc.EventData[3];
                    evtNumD.Value = esc.EventData[4];
                    evtEffects.SetItemChecked(0, (esc.EventData[2] & 0x08) == 0x08);
                    evtEffects.SetItemChecked(1, (esc.EventData[2] & 0x80) == 0x80);
                    evtEffects.SetItemChecked(2, (esc.EventData[4] & 0x80) == 0x80);
                    break;
                case 0x6A:
                case 0x6B:
                    if (esc.Opcode == 0x6A) labelTitleA.Text = "Modify layer of level...";
                    else labelTitleA.Text = "Modify solidity of level...";
                    labelEvtA.Text = "level";
                    labelEvtC.Text = "Mod #";

                    evtNameA.Items.AddRange(Lists.Convert(settings.LevelNames)); evtNameA.Enabled = true;
                    evtNumA.Enabled = true; evtNumA.Maximum = 511;
                    evtNumC.Enabled = true; evtNumC.Maximum = 63;

                    evtNumA.Value = Bits.GetShort(esc.EventData, 1) & 0x1FF;
                    evtNameA.SelectedIndex = (int)evtNumA.Value;
                    evtNumC.Value = (esc.EventData[2] >> 1) & 0x3F;

                    if (esc.Opcode == 0x6A) evtEffects.Items.AddRange(new object[] { "alternate" });
                    else evtEffects.Items.AddRange(new object[] { "permanent" });
                    evtEffects.Enabled = true;
                    evtEffects.SetItemChecked(0, (esc.EventData[2] & 0x80) == 0x80);
                    break;

                // Open window
                case 0x4C:      // Open, shop menu...
                    labelTitleA.Text = "Open shop menu...";
                    labelEvtA.Text = "shop";
                    evtNumA.Enabled = true;

                    evtNumA.Value = esc.Option;
                    break;
                case 0x4F:      // Open, window...
                    labelTitleA.Text = "Open window...";
                    labelEvtA.Text = "window";
                    evtNameA.Items.AddRange(Lists.MenuNames);
                    evtNameA.Enabled = true;

                    evtNameA.SelectedIndex = esc.Option;
                    break;

                // Dialogue
                /* 
                 * TODO
                 * synchronize evtNameA with evtNumA for case 0x60 and 0x62
                 */
                case 0x60:
                    labelTitleA.Text = "Run dialogue...";
                    labelEvtA.Text = "dialogue";
                    labelEvtB.Text = "above obj";
                    labelTitleB.Text = "properties";
                    evtNameA.Items.AddRange(DialogueNames()); evtNameA.Enabled = true;
                    evtNumA.Maximum = 4095; evtNumA.Enabled = true;
                    evtNameB.Items.AddRange(Lists.ObjectNames); evtNameB.Enabled = true;
                    evtEffects.Items.AddRange(new string[] { "closable", "asynchronous", "multi-line", "paper BG" });
                    evtEffects.Enabled = true;

                    evtNumA.Value = Bits.GetShort(esc.EventData, 1) & 0xFFF;
                    evtNameA.SelectedIndex = (int)evtNumA.Value;
                    evtNameB.SelectedIndex = esc.EventData[3] & 0x3F;
                    evtEffects.SetItemChecked(0, (esc.EventData[2] & 0x20) == 0x20);
                    evtEffects.SetItemChecked(1, (esc.EventData[2] & 0x80) == 0x80);
                    evtEffects.SetItemChecked(2, (esc.EventData[3] & 0x40) == 0x40);
                    evtEffects.SetItemChecked(3, (esc.EventData[3] & 0x80) == 0x80);
                    break;
                case 0x61:
                    labelTitleA.Text = "Run dialogue from mem $7000...";
                    labelEvtA.Text = "above obj";
                    labelTitleB.Text = "properties";
                    evtNameA.Items.AddRange(Lists.ObjectNames); evtNameA.Enabled = true;
                    evtEffects.Items.AddRange(new string[] { "closable", "asynchronous", "multi-line", "paper BG" });
                    evtEffects.Enabled = true;

                    evtNameA.SelectedIndex = esc.EventData[2] & 0x3F;
                    evtEffects.SetItemChecked(0, (esc.Option & 0x20) == 0x20);
                    evtEffects.SetItemChecked(1, (esc.Option & 0x80) == 0x80);
                    evtEffects.SetItemChecked(2, (esc.EventData[2] & 0x40) == 0x40);
                    evtEffects.SetItemChecked(3, (esc.EventData[2] & 0x80) == 0x80);
                    break;
                case 0x62:
                    labelTitleA.Text = "Run timed dialogue...";
                    labelEvtA.Text = "dialogue";
                    labelEvtC.Text = "timing";
                    labelTitleB.Text = "properties";
                    evtNameA.Items.AddRange(DialogueNames()); evtNameA.Enabled = true;
                    evtNumA.Maximum = 4095; evtNumA.Enabled = true;
                    evtNumC.Maximum = 3; evtNumC.Enabled = true;
                    evtEffects.Items.AddRange(new string[] { "asynchronous" });
                    evtEffects.Enabled = true;

                    evtNumA.Value = Bits.GetShort(esc.EventData, 1) & 0xFFF;
                    evtNameA.SelectedIndex = (int)evtNumA.Value;
                    evtNumC.Value = (esc.EventData[2] & 0x60) >> 5;
                    evtEffects.SetItemChecked(0, (esc.EventData[2] & 0x80) == 0x80);
                    break;
                case 0x63:
                    labelTitleA.Text = "Append to current dialogue from mem $7000...";
                    labelTitleB.Text = "properties";
                    evtEffects.Items.AddRange(new string[] { "closable", "asynchronous" }); evtEffects.Enabled = true;

                    evtEffects.SetItemChecked(0, (esc.Option & 0x20) == 0x20);
                    evtEffects.SetItemChecked(1, (esc.Option & 0x80) == 0x80);
                    break;
                case 0x66:
                case 0x67:
                    if (esc.Opcode == 0x67)
                    {
                        labelTitleA.Text = "If dialogue option B / C selected, jump to...";
                        labelEvtD.Text = "if C, jump to";
                        evtNumD.Maximum = 0xFFFF; evtNumD.Hexadecimal = true; evtNumD.Enabled = true;
                        evtNumD.Value = Bits.GetShort(esc.EventData, 3);
                    }
                    else
                        labelTitleA.Text = "If dialogue option B selected, jump to...";

                    labelEvtC.Text = "if B, jump to";
                    evtNumC.Maximum = 0xFFFF; evtNumC.Hexadecimal = true; evtNumC.Enabled = true;
                    evtNumC.Value = Bits.GetShort(esc.EventData, 1);
                    break;

                // Events
                case 0x40:
                    labelTitleA.Text = "Run synchronous event...";
                    labelEvtC.Text = "event";
                    labelTitleB.Text = "bits";
                    evtNumC.Maximum = 4095; evtNumC.Enabled = true;
                    evtEffects.Items.AddRange(new string[] { "stop event if exit level", "bit 6", "bit 7" }); evtEffects.Enabled = true;

                    evtNumC.Value = Bits.GetShort(esc.EventData, 1) & 0xFFF;
                    evtEffects.SetItemChecked(0, (esc.EventData[2] & 0x20) == 0x20);
                    evtEffects.SetItemChecked(1, (esc.EventData[2] & 0x40) == 0x40);
                    evtEffects.SetItemChecked(2, (esc.EventData[2] & 0x80) == 0x80);
                    break;
                case 0xD0:
                case 0xD1:
                    if (esc.Opcode == 0xD0) labelTitleA.Text = "Run event (jump to)...";
                    else labelTitleA.Text = "Run event (sub-routine)...";
                    labelEvtC.Text = "event";
                    evtNumC.Maximum = 4095; evtNumC.Enabled = true;

                    evtNumC.Value = Bits.GetShort(esc.EventData, 1) & 0xFFF;
                    break;
                case 0x4E:
                    labelTitleA.Text = "Run common event...";
                    labelEvtA.Text = "category";
                    evtNameA.Items.AddRange(new string[]
                    {
                        "open select game",
                        "open overworld menu",
                        "open world map point",
                        "open shop menu",
                        "open save game",
                        "open items maxed out menu, toss item",
                        "UNK",
                        "open menu tutorial",
                        "star collection star piece add",
                        "moleville mountain cart race",
                        "UNK",
                        "moleville mountain intro",
                        "UNK",
                        "star piece endings",
                        "garden intro",
                        "entering gate to smithy factory",
                        "world map event"
                    });
                    evtNameA.Enabled = true;

                    evtNameA.SelectedIndex = esc.Option;
                    switch (evtNameA.SelectedIndex)
                    {
                        case 2: // open world map point
                            labelEvtB.Text = "map point";
                            evtNameB.Items.AddRange(Lists.Numerize(Lists.MapNames)); evtNameB.Enabled = true;

                            evtNameB.SelectedIndex = esc.EventData[2];
                            break;
                        case 3: // open shop menu
                            labelEvtC.Text = "shop menu";
                            evtNumC.Maximum = 32; evtNumC.Enabled = true;

                            evtNumC.Value = esc.EventData[2];
                            break;
                        case 5: // items maxed out
                            labelEvtB.Text = "toss item";
                            evtNameB.Items.AddRange(Model.ItemNames.GetNames()); evtNameB.Enabled = true;
                            evtNumB.Maximum = 176; evtNumB.Enabled = true;

                            evtNumB.Value = esc.EventData[2];
                            evtNameB.SelectedIndex = Model.ItemNames.GetIndexFromNum((int)evtNumB.Value);
                            break;
                        case 7: // menu tutorial
                            labelEvtB.Text = "tutorial";
                            evtNameB.Items.AddRange(new string[] { "How to equip", "How to use items", "How to switch allies", "How to play beetle mania" });
                            evtNameB.Enabled = true;

                            evtNameB.SelectedIndex = esc.EventData[2];
                            break;
                        case 16:    // world map event
                            labelEvtB.Text = "map event";
                            evtNameB.Items.AddRange(new string[] { "Mario falls to pipehouse", "Mario returns to MK", "Mario takes Nimbus bus" });
                            evtNameB.Enabled = true;

                            evtNameB.SelectedIndex = esc.EventData[2];
                            break;
                    }

                    /* 
                     * TODO
                     * in eventHandler set evtNumC maximum and labelEvtC text 
                     * based on selectedIndex in evtNameA
                     */
                    break;

                // Jump to
                case 0xD2:
                case 0xD3:
                    if (esc.Opcode == 0xD2) labelTitleA.Text = "Jump to address...";
                    else labelTitleA.Text = "Jump to subroutine...";

                    labelEvtC.Text = "address";
                    evtNumC.Hexadecimal = true; evtNumC.Maximum = 0xFFFF; evtNumC.Enabled = true;

                    evtNumC.Value = Bits.GetShort(esc.EventData, 1);
                    break;
                case 0xD4:
                    labelTitleA.Text = "Loop start, loop count...";
                    labelEvtC.Text = "count";
                    evtNumC.Enabled = true;

                    evtNumC.Value = esc.Option;
                    break;

                // Screen effects
                case 0x72:
                case 0x73:
                case 0x76:
                case 0x77:
                    switch (esc.Opcode)
                    {
                        case 0x72: labelTitleA.Text = "Fade in from black (sync), for duration..."; break;
                        case 0x73: labelTitleA.Text = "Fade in from black (async), for duration..."; break;
                        case 0x76: labelTitleA.Text = "Fade out to black (sync), for duration..."; break;
                        case 0x77: labelTitleA.Text = "Fade out to black (async), for duration..."; break;
                    }
                    labelEvtC.Text = "duration";
                    evtNumC.Enabled = true;

                    evtNumC.Value = esc.Option;
                    break;
                case 0x78:
                case 0x79:
                case 0x83:
                    if (esc.Opcode == 0x78) labelTitleA.Text = "Fade in from color...";
                    else if (esc.Opcode == 0x79) labelTitleA.Text = "Fade out to color";
                    else labelTitleA.Text = "Screen flash color...";
                    labelEvtA.Text = "color";
                    evtNameA.Items.AddRange(Lists.ColorNames); evtNameA.Enabled = true;

                    if (esc.Opcode != 0x83)
                    {
                        labelEvtC.Text = "duration";
                        evtNumC.Enabled = true;
                        evtNumC.Value = esc.Option;
                        evtNameA.SelectedIndex = esc.EventData[2];
                    }
                    else
                        evtNameA.SelectedIndex = esc.Option;
                    break;
                case 0x80:
                    labelTitleA.Text = "Layer tinting, color...";
                    labelEvtA.Text = "speed";
                    labelEvtB.Text = "red";
                    labelEvtC.Text = "green";
                    labelEvtD.Text = "blue";
                    labelTitleB.Text = "tint layers...";
                    evtNumA.Enabled = true;
                    evtNumB.Enabled = true;
                    evtNumC.Enabled = true;
                    evtNumD.Enabled = true;
                    evtEffects.Items.AddRange(Lists.LayerNames); evtEffects.Enabled = true;

                    double multiplier = 8; // 8;
                    ushort color = Bits.GetShort(esc.EventData, 1);
                    evtNumB.Value = (byte)((color % 0x20) * multiplier);
                    evtNumC.Value = (byte)(((color >> 5) % 0x20) * multiplier);
                    evtNumD.Value = (byte)(((color >> 10) % 0x20) * multiplier);

                    evtNumA.Value = esc.EventData[4];
                    for (int i = 1, j = 0; j < 8; i *= 2, j++)
                        evtEffects.SetItemChecked(j, (esc.EventData[3] & i) == i);
                    break;
                case 0x81:
                    labelTitleA.Text = "Layer priorities, set...";
                    labelTitleB.Text = "mainscreen / subscreen / color math";
                    evtEffects.ColumnWidth = (int)(evtEffects.ColumnWidth / 2);
                    evtEffects.Items.AddRange(new string[]
                    {
                        "L1","L2","L3","Sprites",
                        "L1","L2","L3","Sprites",
                        "L1","L2","L3","Sprites", "BG", "½ intensity", "Minus sub"
                    });
                    evtEffects.Enabled = true;

                    evtEffects.SetItemChecked(0, (esc.Option & 0x01) == 0x01);
                    evtEffects.SetItemChecked(1, (esc.Option & 0x02) == 0x02);
                    evtEffects.SetItemChecked(2, (esc.Option & 0x04) == 0x04);
                    evtEffects.SetItemChecked(3, (esc.Option & 0x10) == 0x10);
                    evtEffects.SetItemChecked(4, (esc.EventData[2] & 0x01) == 0x01);
                    evtEffects.SetItemChecked(5, (esc.EventData[2] & 0x02) == 0x02);
                    evtEffects.SetItemChecked(6, (esc.EventData[2] & 0x04) == 0x04);
                    evtEffects.SetItemChecked(7, (esc.EventData[2] & 0x10) == 0x10);
                    evtEffects.SetItemChecked(8, (esc.EventData[3] & 0x01) == 0x01);
                    evtEffects.SetItemChecked(9, (esc.EventData[3] & 0x02) == 0x01);
                    evtEffects.SetItemChecked(10, (esc.EventData[3] & 0x04) == 0x01);
                    evtEffects.SetItemChecked(11, (esc.EventData[3] & 0x08) == 0x01);
                    evtEffects.SetItemChecked(12, (esc.EventData[3] & 0x20) == 0x20);
                    evtEffects.SetItemChecked(13, (esc.EventData[3] & 0x40) == 0x40);
                    evtEffects.SetItemChecked(14, (esc.EventData[3] & 0x80) == 0x80);
                    /*
                    * TODO
                    * set evtEffects according to evtNameA.SelectedIndex
                    */
                    break;
                case 0x84:
                    labelTitleA.Text = "Layer pixels, size...";
                    labelEvtC.Text = "size times";
                    labelEvtD.Text = "duration";
                    labelTitleB.Text = "effect layers...";
                    evtNumC.Maximum = 15; evtNumC.Enabled = true;
                    evtNumD.Maximum = 63; evtNumD.Enabled = true;
                    evtEffects.Items.AddRange(new string[] { "L1", "L2", "L3", "L4" }); evtEffects.Enabled = true;

                    evtNumC.Value = esc.Option >> 4;
                    evtNumD.Value = esc.EventData[2] & 0x3F;
                    for (int i = 1, j = 0; j < 4; i *= 2, j++)
                        evtEffects.SetItemChecked(j, (esc.Option & i) == i);
                    break;
                case 0x89:
                    labelTitleA.Text = "Palette set transform...";
                    labelEvtA.Text = "style";
                    labelEvtB.Text = "duration";
                    labelEvtC.Text = "pal set";
                    labelEvtD.Text = "pal index";
                    evtNameA.Items.AddRange(new string[] { "nothing", "glow", "set to", "fade to" });
                    evtNameA.Enabled = true;
                    evtNumB.Maximum = 15; evtNumB.Enabled = true;
                    evtNumC.Enabled = true;
                    evtNumD.Maximum = 16; evtNumD.Enabled = true;
                    evtEffects.Enabled = true;

                    switch (esc.Option & 0xE0)
                    {
                        case 0x60: evtNameA.SelectedIndex = 1; break;
                        case 0xC0: evtNameA.SelectedIndex = 2; break;
                        case 0xE0: evtNameA.SelectedIndex = 3; break;
                        default: evtNameA.SelectedIndex = 0; break;
                    }
                    evtNumB.Value = esc.Option & 0x0F;
                    evtNumC.Value = esc.EventData[3];
                    evtNumD.Value = esc.EventData[2];
                    break;
                case 0x8A:
                    labelTitleA.Text = "Palette set change...";
                    labelEvtC.Text = "pal set";
                    labelEvtD.Text = "index 0 to";
                    evtNumC.Enabled = true;
                    evtNumD.Maximum = 16; evtNumD.Minimum = 1; evtNumD.Enabled = true;

                    evtNumC.Value = esc.EventData[2];
                    evtNumD.Value = (esc.Option >> 4) + 1;
                    break;
                case 0x87: labelTitleA.Text = "Closing circle effect to object (non-static)..."; goto case 0x8F;
                case 0x8F:
                    if (esc.Opcode == 0x8F) labelTitleA.Text = "Closing circle effect to object (static)...";
                    labelEvtA.Text = "object";
                    labelEvtC.Text = "min radius";
                    labelEvtD.Text = "speed";
                    evtNameA.Items.AddRange(Lists.ObjectNames); evtNameA.Enabled = true;
                    evtNumC.Enabled = true;
                    evtNumD.Enabled = true;

                    evtNameA.SelectedIndex = esc.Option;
                    evtNumC.Value = esc.EventData[2];
                    evtNumD.Value = esc.EventData[3];
                    break;

                // Playback audio
                case 0x90:
                case 0x91:
                case 0x92:
                    if (esc.Opcode == 0x90) labelTitleA.Text = "Playback start at current volume, track...";
                    else if (esc.Opcode == 0x91) labelTitleA.Text = "Playback start at default volume, track...";
                    else labelTitleA.Text = "Playback fade-in track...";
                    labelEvtA.Text = "track";
                    evtNameA.Items.AddRange(Lists.Numerize(Lists.MusicNames)); evtNameA.Enabled = true;

                    evtNameA.SelectedIndex = esc.Option;
                    break;
                case 0x95:
                    labelTitleA.Text = "Playback fade-out track...";
                    labelEvtC.Text = "duration";
                    labelEvtD.Text = "to volume";
                    evtNumC.Enabled = true;
                    evtNumD.Enabled = true;

                    evtNumC.Value = esc.Option;
                    evtNumD.Value = esc.EventData[2];
                    break;
                case 0x97:
                    labelTitleA.Text = "Playback adjust track tempo...";
                    labelEvtA.Text = "change type";
                    labelEvtD.Text = "duration";
                    evtNameA.Items.AddRange(new string[] { "slow down", "speed up" }); evtNameA.Enabled = true;
                    evtNumC.Enabled = true;
                    evtNumD.Enabled = true;

                    if (esc.EventData[2] >= 0xA1)
                    {
                        labelEvtC.Text = "speed up";
                        evtNumC.Maximum = 94;

                        evtNameA.SelectedIndex = 1;
                        evtNumC.Value = 0x100 - esc.EventData[2];
                    }
                    else
                    {
                        labelEvtC.Text = "slow down";
                        evtNumC.Maximum = 160;

                        evtNameA.SelectedIndex = 0;
                        evtNumC.Value = esc.EventData[2];
                    }
                    evtNumD.Value = esc.Option;
                    /*
                     * TODO
                     * set labelEvtC text and evtNumC value based on what change type is
                     * if slow down, set max to 160, else set max to 94
                     * if speed up, set value = (0x100 - esc.EventData[2]) - 1
                     */
                    break;
                case 0x98:
                    labelTitleA.Text = "Playback adjust track pitch...";
                    labelEvtA.Text = "change type";
                    labelEvtC.Text = "duration";
                    evtNameA.Items.AddRange(new string[] { "raise", "lower" }); evtNameA.Enabled = true;
                    evtNumC.Enabled = true;

                    evtNameA.SelectedIndex = (esc.EventData[2] & 0x80) == 0x80 ? 1 : 0;
                    evtNumC.Value = esc.Option;
                    break;
                case 0x9C:
                    labelTitleA.Text = "Playback start, sound...";
                    labelEvtA.Text = "sound";
                    evtNameA.Items.AddRange(Lists.Numerize(Lists.SoundNames)); evtNameA.Enabled = true;

                    evtNameA.SelectedIndex = esc.Option;
                    break;
                case 0x9D:
                    labelTitleA.Text = "Playback start (speaker balance), sound...";
                    labelEvtC.Text = "balance";
                    evtNameA.Items.AddRange(Lists.Numerize(Lists.SoundNames)); evtNameA.Enabled = true;
                    evtNumC.Enabled = true;

                    evtNameA.SelectedIndex = esc.Option;
                    evtNumC.Value = esc.EventData[2];
                    break;
                case 0x9E:
                    labelTitleA.Text = "Playback fade-out sound...";
                    labelEvtC.Text = "duration";
                    labelEvtD.Text = "to volume";
                    evtNumC.Enabled = true;
                    evtNumD.Enabled = true;

                    evtNumC.Value = esc.Option;
                    evtNumD.Value = esc.EventData[2];
                    break;

                // Memory
                case 0xA0:
                case 0xA1:
                case 0xA2:
                case 0xA4:
                case 0xA5:
                case 0xA6:
                    if (esc.Opcode < 0xA4) labelTitleA.Text = "Set mem...";
                    else labelTitleA.Text = "Clear mem...";

                    labelEvtC.Text = "address";
                    labelEvtD.Text = "bit";
                    evtNumC.Hexadecimal = true;
                    evtNumC.Maximum = 0x709F; evtNumC.Minimum = 0x7040;
                    evtNumC.Enabled = true;
                    evtNumD.Maximum = 7; evtNumD.Enabled = true;

                    if (esc.Opcode < 0xA4) evtNumC.Value = ((((esc.Opcode - 0xA0) * 0x100) + esc.Option) >> 3) + 0x7040;
                    else evtNumC.Value = ((((esc.Opcode - 0xA4) * 0x100) + esc.Option) >> 3) + 0x7040;
                    evtNumD.Value = esc.Option & 7;
                    break;
                case 0xA8:
                case 0xA9:
                    if (esc.Opcode == 0xA8) labelTitleA.Text = "Store to mem a value (8-bit)...";
                    else labelTitleA.Text = "Add to mem a value (8-bit)...";
                    labelEvtC.Text = "address";
                    labelEvtD.Text = "value";
                    evtNumC.Hexadecimal = true;
                    evtNumC.Maximum = 0x719F; evtNumC.Minimum = 0x70A0;
                    evtNumC.Enabled = true;
                    evtNumD.Enabled = true;

                    evtNumC.Value = esc.Option + 0x70A0;
                    evtNumD.Value = esc.EventData[2];
                    break;
                case 0xAA:
                case 0xAB:
                    if (esc.Opcode == 0xAA) labelTitleA.Text = "Increment mem (8-bit)...";
                    else labelTitleA.Text = "Decrement mem (8-bit)...";
                    labelEvtC.Text = "address";
                    evtNumC.Hexadecimal = true;
                    evtNumC.Maximum = 0x719F; evtNumC.Minimum = 0x70A0;
                    evtNumC.Enabled = true;

                    evtNumC.Value = esc.Option + 0x70A0;
                    break;
                case 0xB0:
                case 0xB1:
                case 0xC2:
                    if (esc.Opcode == 0xB0) labelTitleA.Text = "Store to mem a value (16-bit)...";
                    else if (esc.Opcode == 0xB1) labelTitleA.Text = "Add to mem a value (16-bit)...";
                    else labelTitleA.Text = "Compare to mem a value (16-bit)...";
                    labelEvtC.Text = "address";
                    labelEvtD.Text = "value";
                    evtNumC.Hexadecimal = true; evtNumC.Increment = 2;
                    evtNumC.Maximum = 0x71FE; evtNumC.Minimum = 0x7000;
                    evtNumC.Enabled = true;
                    evtNumD.Maximum = 65535; evtNumD.Enabled = true;

                    evtNumC.Value = (esc.Option * 2) + 0x7000;
                    evtNumD.Value = Bits.GetShort(esc.EventData, 2);
                    break;
                case 0xB2:
                case 0xB3:
                case 0xD6:
                case 0xBB:
                    if (esc.Opcode == 0xB2) labelTitleA.Text = "Increment mem (16-bit)...";
                    else if (esc.Opcode == 0xB3) labelTitleA.Text = "Decrement mem (16-bit)...";
                    else if (esc.Opcode == 0xB6) labelTitleA.Text = "Store to object mem from mem...";
                    else labelTitleA.Text = "Store to mem from mem $7000 (16-bit)...";
                    labelEvtC.Text = "address";
                    evtNumC.Hexadecimal = true; evtNumC.Increment = 2;
                    evtNumC.Maximum = 0x71FE; evtNumC.Minimum = 0x7000;
                    evtNumC.Enabled = true;

                    evtNumC.Value = (esc.Option * 2) + 0x7000;
                    break;
                case 0xB5:
                    labelTitleA.Text = "Store to mem from mem $7000 (8-bit)...";
                    labelEvtC.Text = "address";
                    evtNumC.Hexadecimal = true;
                    evtNumC.Maximum = 0x719F; evtNumC.Minimum = 0x70A0;
                    evtNumC.Enabled = true;

                    evtNumC.Value = esc.Option + 0x70A0;
                    break;
                case 0xB7:
                    labelTitleA.Text = "Store random # less than... to mem...";
                    labelEvtC.Text = "address";
                    labelEvtD.Text = "number <";
                    evtNumC.Hexadecimal = true; evtNumC.Increment = 2;
                    evtNumC.Maximum = 0x71FE; evtNumC.Minimum = 0x7000;
                    evtNumC.Enabled = true;
                    evtNumD.Maximum = 65535; evtNumD.Enabled = true;

                    evtNumC.Value = (esc.Option * 2) + 0x7000;
                    evtNumD.Value = Bits.GetShort(esc.EventData, 2);
                    break;
                case 0xBC:
                case 0xBD:
                    if (esc.Opcode == 0xBC) labelTitleA.Text = "Store to mem A from mem B (choose both, 16-bit)...";
                    else labelTitleA.Text = "Exchange mem A and mem B (16-bit)...";
                    labelEvtC.Text = "address A";
                    labelEvtD.Text = "address B";
                    evtNumC.Hexadecimal = true; evtNumC.Increment = 2;
                    evtNumC.Maximum = 0x71FE; evtNumC.Minimum = 0x7000;
                    evtNumC.Enabled = true;
                    evtNumD.Hexadecimal = true; evtNumD.Increment = 2;
                    evtNumD.Maximum = 0x71FE; evtNumD.Minimum = 0x7000;
                    evtNumD.Enabled = true;

                    evtNumC.Value = (esc.Option * 2) + 0x7000;
                    evtNumD.Value = (esc.EventData[2] * 2) + 0x7000;
                    break;
                case 0xD8:
                case 0xD9:
                case 0xDA:
                case 0xDC:
                case 0xDD:
                case 0xDE:
                    if (esc.Opcode < 0xDC) labelTitleA.Text = "If set, mem...";
                    else labelTitleA.Text = "If clear, mem...";

                    labelEvtC.Text = "address";
                    labelEvtD.Text = "bit";
                    labelEvtE.Text = "then jump to...";
                    evtNumC.Hexadecimal = true;
                    evtNumC.Maximum = 0x709F; evtNumC.Minimum = 0x7040;
                    evtNumC.Enabled = true;
                    evtNumD.Maximum = 7; evtNumD.Enabled = true;
                    evtNumE.Hexadecimal = true; evtNumE.Maximum = 0xFFFF; evtNumE.Enabled = true;

                    if (esc.Opcode < 0xDC) evtNumC.Value = ((((esc.Opcode - 0xD8) * 0x100) + esc.Option) >> 3) + 0x7040;
                    else evtNumC.Value = ((((esc.Opcode - 0xDC) * 0x100) + esc.Option) >> 3) + 0x7040;
                    evtNumD.Value = esc.Option & 7;
                    evtNumE.Value = Bits.GetShort(esc.EventData, 2);
                    break;
                case 0xE0:
                case 0xE1:
                    if (esc.Opcode == 0xE0) labelTitleA.Text = "If mem = (8-bit)...";
                    else labelTitleA.Text = "If mem != (8-bit)...";
                    labelEvtC.Text = "address";
                    labelEvtD.Text = "value";
                    labelEvtE.Text = "then jump to...";
                    evtNumC.Hexadecimal = true;
                    evtNumC.Maximum = 0x719F; evtNumC.Minimum = 0x70A0;
                    evtNumC.Enabled = true;
                    evtNumD.Enabled = true;
                    evtNumE.Hexadecimal = true; evtNumE.Maximum = 0xFFFF; evtNumE.Enabled = true;

                    evtNumC.Value = esc.Option + 0x70A0;
                    evtNumD.Value = esc.EventData[2];
                    evtNumE.Value = Bits.GetShort(esc.EventData, 3);
                    break;
                case 0xE4:
                case 0xE5:
                    if (esc.Opcode == 0xE4) labelTitleA.Text = "If mem = (16-bit)...";
                    else labelTitleA.Text = "If mem != (16-bit)...";
                    labelEvtC.Text = "address";
                    labelEvtD.Text = "value";
                    labelEvtE.Text = "then jump to...";
                    evtNumC.Hexadecimal = true; evtNumC.Increment = 2;
                    evtNumC.Maximum = 0x71FE; evtNumC.Minimum = 0x7000;
                    evtNumC.Enabled = true;
                    evtNumD.Maximum = 65535; evtNumD.Enabled = true;
                    evtNumE.Hexadecimal = true; evtNumE.Maximum = 0xFFFF; evtNumE.Enabled = true;

                    evtNumC.Value = (esc.Option * 2) + 0x7000;
                    evtNumD.Value = Bits.GetShort(esc.EventData, 2);
                    evtNumE.Value = Bits.GetShort(esc.EventData, 4);
                    break;
                case 0xE8:
                    labelTitleA.Text = "If random # > 128, jump to...";
                    labelEvtC.Text = "address";
                    evtNumC.Hexadecimal = true; evtNumC.Maximum = 0xFFFF; evtNumC.Enabled = true;

                    evtNumC.Value = Bits.GetShort(esc.EventData, 1);
                    break;
                case 0xE9:
                    labelTitleA.Text = "If random # > 66, jump to address A, else address B...";
                    labelEvtC.Text = "address A";
                    labelEvtD.Text = "address B";
                    evtNumC.Hexadecimal = true; evtNumC.Maximum = 0xFFFF; evtNumC.Enabled = true;
                    evtNumD.Hexadecimal = true; evtNumD.Maximum = 0xFFFF; evtNumD.Enabled = true;

                    evtNumC.Value = Bits.GetShort(esc.EventData, 1);
                    evtNumD.Value = Bits.GetShort(esc.EventData, 3);
                    break;

                // Memory $7000
                case 0x38:
                    labelTitleA.Text = "Mem $7000 = character @ slot...";
                    labelEvtC.Text = "slot";
                    evtNumC.Maximum = 4; evtNumC.Enabled = true;

                    if (esc.Option < 8) esc.Option = 8;
                    evtNumC.Value = esc.Option - 8;
                    break;
                case 0xAC: labelTitleA.Text = "Mem $7000 =..."; goto case 0xC0;
                case 0xAD: labelTitleA.Text = "Mem $7000 +=..."; goto case 0xC0;
                case 0xB6: labelTitleA.Text = "Mem $7000 = random # less than..."; goto case 0xC0;
                case 0xC0:
                    if (esc.Opcode == 0xC0) labelTitleA.Text = "Mem $7000 compare to...";
                    labelEvtC.Text = "value";
                    evtNumC.Maximum = 65535; evtNumC.Enabled = true;

                    evtNumC.Value = Bits.GetShort(esc.EventData, 1);
                    break;
                case 0xB4:
                    labelTitleA.Text = "Mem $7000 = mem...";
                    labelEvtC.Text = "address";
                    evtNumC.Hexadecimal = true;
                    evtNumC.Maximum = 0x719F; evtNumC.Minimum = 0x70A0;
                    evtNumC.Enabled = true;

                    evtNumC.Value = esc.Option + 0x70A0;
                    break;
                case 0xB8: labelTitleA.Text = "Mem $7000 += mem..."; goto case 0xC1;
                case 0xB9: labelTitleA.Text = "Mem $7000 -= mem..."; goto case 0xC1;
                case 0xBA: labelTitleA.Text = "Mem $7000 = mem..."; goto case 0xC1;
                case 0xC1:
                    if (esc.Opcode == 0xC1) labelTitleA.Text = "Mem $7000 compare to mem...";
                    labelEvtC.Text = "address";
                    evtNumC.Hexadecimal = true; evtNumC.Increment = 2;
                    evtNumC.Maximum = 0x71FE; evtNumC.Minimum = 0x7000;
                    evtNumC.Enabled = true;

                    evtNumC.Value = (esc.Option * 2) + 0x7000;
                    break;
                case 0xC4: labelTitleA.Text = "Mem $7000 = object X coord..."; goto case 0xC6;
                case 0xC5: labelTitleA.Text = "Mem $7000 = object Y coord..."; goto case 0xC6;
                case 0xC6:
                    if (esc.Opcode == 0xC6) labelTitleA.Text = "Mem $7000 = object Z coord...";
                    labelEvtA.Text = "object";
                    evtNameA.Items.AddRange(Lists.ObjectNames); evtNameA.Enabled = true;
                    evtEffects.Items.Add("isometric"); evtEffects.Enabled = true;

                    evtNameA.SelectedIndex = esc.Option & 0x3F;
                    evtEffects.SetItemChecked(0, (esc.Option & 0x80) == 0x80);
                    break;
                case 0xDB: labelTitleA.Text = "If mem $7000 bit(s) set, jump to..."; goto case 0xDF;
                case 0xDF:
                    if (esc.Opcode == 0xDF) labelTitleA.Text = "If mem $7000 bit(s) clear, jump to...";
                    labelEvtC.Text = "address";
                    evtNumC.Hexadecimal = true; evtNumC.Maximum = 0xFFFF; evtNumC.Enabled = true;

                    evtNumC.Value = Bits.GetShort(esc.EventData, 1);
                    break;
                case 0xE2: labelTitleA.Text = "If mem $7000 = value..."; labelEvtC.Text = "value"; goto case 0xE7;
                case 0xE3: labelTitleA.Text = "If mem $7000 != value..."; labelEvtC.Text = "value"; goto case 0xE7;
                case 0xE6: labelTitleA.Text = "If mem $7000 set, no bits..."; goto case 0xE7;
                case 0xE7:
                    if (esc.Opcode == 0xE7) labelTitleA.Text = "If mem $7000 set, any bits...";
                    if (esc.Opcode > 0xE3) labelEvtC.Text = "bits";
                    labelEvtD.Text = "jump to";
                    evtNumC.Maximum = 65535; evtNumC.Enabled = true;
                    evtNumD.Hexadecimal = true; evtNumD.Maximum = 0xFFFF; evtNumD.Enabled = true;

                    evtNumC.Value = Bits.GetShort(esc.EventData, 1);
                    evtNumD.Value = Bits.GetShort(esc.EventData, 3);
                    break;
                case 0xEA: labelTitleA.Text = "If equal to zero, jump to..."; goto case 0xEF;
                case 0xEB: labelTitleA.Text = "If not equal to zero, jump to..."; goto case 0xEF;
                case 0xEC: labelTitleA.Text = "If greater than / equal to, jump to..."; goto case 0xEF;
                case 0xED: labelTitleA.Text = "If less than, jump to..."; goto case 0xEF;
                case 0xEE: labelTitleA.Text = "If negative, jump to..."; goto case 0xEF;
                case 0xEF:
                    if (esc.Opcode == 0xEF) labelTitleA.Text = "If positive, jump to...";
                    labelEvtC.Text = "jump to";
                    evtNumC.Hexadecimal = true; evtNumC.Maximum = 0xFFFF; evtNumC.Enabled = true;

                    evtNumC.Value = Bits.GetShort(esc.EventData, 1);
                    break;

                // Pause script
                case 0xF0:
                    labelTitleA.Text = "Pause script, frame duration (8-bit)...";
                    labelEvtC.Text = "frames";
                    evtNumC.Enabled = true;

                    evtNumC.Value = esc.Option;
                    break;
                case 0xF1:
                    labelTitleA.Text = "Pause script, frame duration (16-bit)...";
                    labelEvtC.Text = "frames";
                    evtNumC.Maximum = 65535; evtNumC.Enabled = true;

                    evtNumC.Value = Bits.GetShort(esc.EventData, 1);
                    break;

                default:
                    // Action Queue (same for all sub-indexes, so no need to do a switch for sub)
                    if (esc.Opcode <= 0x2F)
                    {
                        labelTitleA.Text = "Start action queue for object...";
                        labelEvtA.Text = "Object";
                        labelEvtB.Text = "queue type";
                        evtNameA.Items.AddRange(Lists.ObjectNames);
                        evtNameB.Items.AddRange(new string[]
                        {                                           // OPTIONS:
                        "start action queue",                   // 0x00 - 0x7F
                        "start embedded action script",         // 0xF0
                        "start embedded action script",         // 0xF1
                        "set action script (sync)",             // 0xF2
                        "set action script (async)",         // 0xF3
                        "set temp action script (sync)",        // 0xF4
                        "set temp action script (async)",    // 0xF5
                        "un-sync action script",                // 0xF6
                        "show object @ Mario's coords",         // 0xF7
                        "show object",                          // 0xF8
                        "remove object",                        // 0xF9
                        "pause action script",                  // 0xFA
                        "resume action script",                 // 0xFB
                        "enable trigger",                       // 0xFC
                        "disable trigger",                      // 0xFD
                        "stop embedded action script",          // 0xFE
                        "Set obj coords to default"          // 0xFF
                        });
                        evtNameA.Enabled = true;
                        evtNameB.Enabled = true;

                        evtNameA.SelectedIndex = esc.Opcode;
                        if (esc.Option >= 0xF2)
                        {
                            evtNameB.SelectedIndex = esc.Option - 0xEF;
                        }
                        else evtNameB.SelectedIndex = 0;

                        if (esc.Option >= 0xF2 && esc.Option <= 0xF5)
                        {
                            labelEvtC.Text = "action #";
                            evtNumC.Maximum = 0x3FF; evtNumC.Enabled = true;

                            evtNumC.Value = Bits.GetShort(esc.EventData, 2);
                        }
                        else if (esc.Option < 0xF2)
                        {
                            labelTitleB.Text = "properties...";
                            evtEffects.Items.AddRange(new string[] { "asynchronous" }); evtEffects.Enabled = true;
                            evtEffects.SetItemChecked(0, (esc.Option & 0x80) == 0x80);
                        }

                        /*
                              * TODO
                              * set evtNumC value and labelEvtC text according to evtNameB.SelectedIndex
                              */
                    }
                    else if (esc.Opcode == 0xFD)
                    {
                        switch (esc.Option)
                        {
                            // Objects
                            case 0x33: labelTitleA.Text = "If running action script, object..."; goto case 0x3D;         // If running action script, object...
                            case 0x34: labelTitleA.Text = "If underwater, object..."; goto case 0x3D;        // If underwater, object...
                            case 0x3D:         // If in air, object...
                                if (esc.Option == 0x3D) labelTitleA.Text = "If in air, object...";
                                labelEvtA.Text = "object";
                                labelEvtC.Text = "jump to";
                                evtNameA.Items.AddRange(Lists.ObjectNames); evtNameA.Enabled = true;
                                evtNumC.Hexadecimal = true; evtNumC.Maximum = 0xFFFF; evtNumC.Enabled = true;

                                evtNameA.SelectedIndex = esc.EventData[2];
                                evtNumC.Value = Bits.GetShort(esc.EventData, 3);
                                break;
                            case 0x3E:
                                labelTitleA.Text = "Create NPC packet with event @ Mario coords...";
                                labelEvtC.Text = "packet";
                                labelEvtD.Text = "event #";
                                labelTitleC.Text = "If Mario invalid, jump to...";
                                labelEvtE.Text = "address";
                                evtNumC.Maximum = 79; evtNumC.Enabled = true;
                                evtNumD.Maximum = 4095; evtNumD.Enabled = true;
                                evtNumE.Hexadecimal = true; evtNumE.Maximum = 0xFFFF; evtNumE.Enabled = true;

                                evtNumC.Value = esc.EventData[2];
                                evtNumD.Value = Bits.GetShort(esc.EventData, 3) & 0xFFF;
                                evtNumE.Value = Bits.GetShort(esc.EventData, 5);
                                break;

                            // Menus
                            case 0x4C:
                                labelTitleA.Text = "Open, Toad's menu tutorial...";
                                labelEvtC.Text = "menu";
                                evtNumC.Enabled = true;

                                evtNumC.Value = esc.EventData[2];
                                break;

                            // Run event
                            case 0x4D:
                                labelTitleA.Text = "Run star piece scene...";
                                labelEvtC.Text = "star #";
                                evtNumC.Maximum = 7; evtNumC.Minimum = 1; evtNumC.Enabled = true;

                                if (esc.EventData[2] < 1) esc.EventData[2] = 1;
                                evtNumC.Value = esc.EventData[2];
                                break;
                            case 0x66:
                                labelTitleA.Text = "Run character intro title...";
                                labelEvtA.Text = "title";
                                labelEvtC.Text = "from top";
                                evtNameA.Items.AddRange(new string[] { "Super Mario", "Princess Toadstool", "King Bowser", "Mallow", "Geno", "In..." });
                                evtNameA.Enabled = true;
                                evtNumC.Enabled = true;

                                evtNameA.SelectedIndex = esc.EventData[3];
                                evtNumC.Value = esc.EventData[2];
                                break;

                            // Playback audio
                            case 0x9C:
                                labelTitleA.Text = "Playback start, sound...";
                                labelEvtA.Text = "sound";
                                evtNameA.Items.AddRange(Lists.Numerize(Lists.SoundNames)); evtNameA.Enabled = true;

                                evtNameA.SelectedIndex = esc.EventData[2];
                                break;

                            // Memory
                            case 0xB6:
                                labelTitleA.Text = "Double mem...";
                                labelEvtC.Text = "address";
                                labelEvtD.Text = "doubles";
                                evtNumC.Hexadecimal = true; evtNumC.Increment = 2;
                                evtNumC.Maximum = 0x71FE; evtNumC.Minimum = 0x7000;
                                evtNumC.Enabled = true;
                                evtNumD.Maximum = 256; evtNumD.Minimum = 1; evtNumD.Enabled = true;

                                evtNumC.Value = (esc.EventData[2] * 2) + 0x7000;
                                evtNumD.Value = (esc.EventData[3] ^ 0xFF) + 1;
                                break;
                            case 0xB7:
                                labelTitleA.Text = "Generate random # < mem...";
                                labelEvtC.Text = "address";
                                evtNumC.Hexadecimal = true; evtNumC.Increment = 2;
                                evtNumC.Maximum = 0x71FE; evtNumC.Minimum = 0x7000;
                                evtNumC.Enabled = true;

                                evtNumC.Value = (esc.EventData[2] * 2) + 0x7000;
                                break;

                            // Memory $7000
                            case 0x58:
                                labelTitleA.Text = "Mem $7000 = quantity of item...";
                                labelEvtA.Text = "item";
                                evtNameA.Items.AddRange(Model.ItemNames.GetNames()); evtNameA.Enabled = true;
                                evtNumA.Maximum = 176; evtNumA.Enabled = true;

                                evtNumA.Value = esc.EventData[2];
                                evtNameA.SelectedIndex = Model.ItemNames.GetIndexFromNum((int)evtNumA.Value);
                                break;
                            case 0x5D:
                                labelTitleA.Text = "Mem $7000 = equipment of character...";
                                labelEvtA.Text = "character";
                                labelEvtB.Text = "item type";
                                evtNameA.Items.AddRange(Lists.CharacterNames); evtNameA.Enabled = true;
                                evtNameB.Items.AddRange(new string[] { "weapon", "armor", "accessory" });
                                evtNameB.Enabled = true;

                                evtNameA.SelectedIndex = esc.EventData[2];
                                evtNameB.SelectedIndex = esc.EventData[3];
                                break;
                            case 0xAC:
                                labelTitleA.Text = "Mem $7000 = mem 7F:...";
                                labelEvtC.Text = "address";
                                evtNumC.Hexadecimal = true;
                                evtNumC.Maximum = 0x7FFFFF; evtNumC.Minimum = 0x7FF800;
                                evtNumC.Enabled = true;

                                evtNumC.Value = Bits.GetShort(esc.EventData, 2) + 0x7FF800;
                                break;
                            case 0xB0: labelTitleA.Text = "Mem $7000 isolate bits =..."; goto case 0xB2;
                            case 0xB1: labelTitleA.Text = "Mem $7000 set bits =..."; goto case 0xB2;
                            case 0xB2:
                                if (esc.Option == 0xB2) labelTitleA.Text = "Mem $7000 xor bits =...";
                                labelEvtC.Text = "bits";
                                evtNumC.Maximum = 65535; evtNumC.Enabled = true;

                                evtNumC.Value = Bits.GetShort(esc.EventData, 2);
                                break;
                            case 0xB3: labelTitleA.Text = "Mem $7000 isolate bits = mem..."; goto case 0xB5;
                            case 0xB4: labelTitleA.Text = "Mem $7000 set bits = mem..."; goto case 0xB5;
                            case 0xB5:
                                if (esc.Option == 0xB5) labelTitleA.Text = "Mem $7000 xor bits = mem...";
                                labelEvtC.Text = "address";
                                evtNumC.Hexadecimal = true; evtNumC.Increment = 2;
                                evtNumC.Maximum = 0x71FE; evtNumC.Minimum = 0x7000;
                                evtNumC.Enabled = true;

                                evtNumC.Value = (esc.EventData[2] * 2) + 0x7000;
                                break;

                            default: break;
                        }
                    }
                    break;
            }

            updatingControls = true;
        }
        private void ControlEventAsmMethod()
        {
            switch (esc.Opcode)
            {
                // Objects
                case 0x32:         // If object present...
                case 0x39:
                    esc.Option = (byte)evtNameA.SelectedIndex;
                    Bits.SetShort(esc.EventData, 2, (ushort)evtNumC.Value);
                    break;
                case 0x3A:         // If distance between object A and...
                case 0x3B:         // If distance (Z==) between object A and...
                    esc.Option = (byte)evtNameA.SelectedIndex;          // object A
                    esc.EventData[2] = (byte)evtNameB.SelectedIndex;    // object B
                    esc.EventData[3] = (byte)evtNumC.Value;
                    esc.EventData[4] = (byte)evtNumD.Value;
                    Bits.SetShort(esc.EventData, 5, (ushort)evtNumE.Value);
                    break;
                case 0x3D:         // If Mario in air...
                    Bits.SetShort(esc.EventData, 1, (ushort)evtNumE.Value);
                    break;
                case 0x3E:         // Create NPC packet @ obj coords...
                    esc.EventData[2] = (byte)evtNameA.SelectedIndex;
                    esc.Option = (byte)evtNumC.Value;
                    Bits.SetShort(esc.EventData, 3, (ushort)evtNumE.Value);
                    break;
                case 0x3F:         // Create NPC packet...
                    esc.Option = (byte)evtNumC.Value;
                    Bits.SetShort(esc.EventData, 2, (ushort)evtNumE.Value);
                    break;
                case 0x42:         // If Mario on top of an object...
                    Bits.SetShort(esc.EventData, 1, (ushort)evtNumE.Value);
                    Bits.SetShort(esc.EventData, 3, (ushort)evtNumF.Value);
                    break;
                case 0xF2:         // Set obj presence...  
                case 0xF3:         // Set obj engage type...
                case 0xF8:         // If object in level ..., presence =...
                    Bits.SetShort(esc.EventData, 1, (ushort)evtNumA.Value);
                    esc.EventData[2] &= 1; esc.EventData[2] |= (byte)(evtNameB.SelectedIndex << 1);
                    Bits.SetBit(esc.EventData, 2, 7, evtEffects.GetItemChecked(0));    // set bit 7 if true
                    if (esc.Opcode == 0xF8)
                        Bits.SetShort(esc.EventData, 3, (ushort)evtNumE.Value);
                    /* 
                     * TODO
                     * synchronize evtNameA with evtNumA
                     */
                    break;

                // Joypad
                case 0x34:
                case 0x35:
                    for (int i = 0; i < 8; i++)
                        Bits.SetBit(esc.EventData, 1, i, evtEffects.GetItemChecked(i)); // set bit if true
                    break;

                // Party Members
                case 0x36:
                    esc.Option = (byte)evtNameA.SelectedIndex;
                    Bits.SetBit(esc.EventData, 1, 7, evtEffects.GetItemChecked(0));
                    break;
                case 0x54:
                    esc.Option = (byte)evtNameA.SelectedIndex;
                    esc.EventData[2] = (byte)evtNumB.Value;
                    break;
                /* 
                * TODO
                * synchronize evtNameB with evtNumB
                */
                case 0x56:
                    esc.Option = (byte)evtNameA.SelectedIndex;
                    break;

                // Inventory
                case 0x50:
                case 0x51:
                    esc.Option = (byte)evtNumA.Value;
                    break;
                /* 
                * TODO
                * synchronize evtNameA with evtNumA
                */
                case 0x52:
                case 0x53:
                    esc.Option = (byte)evtNumA.Value;
                    break;

                // Battle
                case 0x4A:
                    esc.Option = (byte)evtNumC.Value;
                    esc.EventData[3] = (byte)evtNumB.Value;
                    break;

                // Levels
                /* 
                 * TODO
                 * synchronize evtNameA with evtNumA for case 0x68,0x6A,0x6B
                 */
                case 0x4B:      // Open, world map point...
                    esc.Option = (byte)evtNameA.SelectedIndex;

                    Bits.SetBit(esc.EventData, 2, 5, evtEffects.GetItemChecked(0));
                    Bits.SetBit(esc.EventData, 2, 6, evtEffects.GetItemChecked(1));
                    Bits.SetBit(esc.EventData, 2, 7, evtEffects.GetItemChecked(2));
                    break;
                case 0x68:
                    Bits.SetShort(esc.EventData, 1, (ushort)evtNumA.Value);
                    esc.EventData[5] = (byte)evtNumB.Value;
                    esc.EventData[5] &= 0x1F; esc.EventData[5] |= (byte)(evtNameB.SelectedIndex << 5);
                    esc.EventData[3] = (byte)evtNumC.Value;
                    esc.EventData[4] = (byte)evtNumD.Value;
                    Bits.SetBit(esc.EventData, 2, 3, evtEffects.GetItemChecked(0));
                    Bits.SetBit(esc.EventData, 2, 7, evtEffects.GetItemChecked(1));
                    Bits.SetBit(esc.EventData, 4, 7, evtEffects.GetItemChecked(2));
                    break;
                case 0x6A:
                case 0x6B:
                    Bits.SetShort(esc.EventData, 1, (ushort)evtNumA.Value);
                    Bits.SetBit(esc.EventData, 2, 7, evtEffects.GetItemChecked(0));
                    esc.EventData[2] &= 0x81;
                    esc.EventData[2] |= (byte)((byte)evtNumC.Value << 1);
                    break;

                // Open window
                case 0x4C:      // Open, shop menu...
                    esc.Option = (byte)evtNumA.Value;
                    break;
                case 0x4F:      // Open, window...
                    esc.Option = (byte)evtNameA.SelectedIndex;
                    break;

                // Dialogue
                /* 
                 * TODO
                 * synchronize evtNameA with evtNumA for case 0x60 and 0x62
                 */
                case 0x60:
                    Bits.SetShort(esc.EventData, 1, (ushort)evtNumA.Value);
                    esc.EventData[3] = (byte)evtNameB.SelectedIndex;
                    Bits.SetBit(esc.EventData, 2, 5, evtEffects.GetItemChecked(0));
                    Bits.SetBit(esc.EventData, 2, 7, evtEffects.GetItemChecked(1));
                    Bits.SetBit(esc.EventData, 3, 6, evtEffects.GetItemChecked(2));
                    Bits.SetBit(esc.EventData, 3, 7, evtEffects.GetItemChecked(3));
                    break;
                case 0x61:
                    esc.EventData[2] = (byte)evtNameA.SelectedIndex;
                    Bits.SetBit(esc.EventData, 1, 5, evtEffects.GetItemChecked(0));
                    Bits.SetBit(esc.EventData, 1, 7, evtEffects.GetItemChecked(1));
                    Bits.SetBit(esc.EventData, 2, 6, evtEffects.GetItemChecked(2));
                    Bits.SetBit(esc.EventData, 2, 7, evtEffects.GetItemChecked(3));
                    break;
                case 0x62:
                    Bits.SetShort(esc.EventData, 1, (ushort)evtNumA.Value);
                    esc.EventData[2] &= 0x1F; esc.EventData[2] |= (byte)((byte)evtNumC.Value << 5);
                    Bits.SetBit(esc.EventData, 2, 7, evtEffects.GetItemChecked(0));
                    break;
                case 0x63:
                    Bits.SetBit(esc.EventData, 1, 5, evtEffects.GetItemChecked(0));
                    Bits.SetBit(esc.EventData, 1, 7, evtEffects.GetItemChecked(1));
                    break;
                case 0x66:
                    Bits.SetShort(esc.EventData, 1, (ushort)evtNumC.Value);
                    break;
                case 0x67:
                    Bits.SetShort(esc.EventData, 1, (ushort)evtNumC.Value);
                    Bits.SetShort(esc.EventData, 3, (ushort)evtNumD.Value);
                    break;

                // Events
                case 0x40:
                    Bits.SetShort(esc.EventData, 1, (ushort)evtNumC.Value);
                    Bits.SetBit(esc.EventData, 2, 5, evtEffects.GetItemChecked(0));
                    Bits.SetBit(esc.EventData, 2, 6, evtEffects.GetItemChecked(1));
                    Bits.SetBit(esc.EventData, 2, 7, evtEffects.GetItemChecked(2));
                    break;
                case 0xD0:
                case 0xD1:
                    Bits.SetShort(esc.EventData, 1, (ushort)evtNumC.Value);
                    break;
                case 0x4E:
                    esc.Option = (byte)evtNameA.SelectedIndex;

                    switch (evtNameA.SelectedIndex)
                    {
                        case 2: // open world map point
                            esc.EventData[2] = (byte)evtNameB.SelectedIndex;
                            break;
                        case 3: // open shop menu
                            esc.EventData[2] = (byte)evtNumC.Value;
                            break;
                        case 5: // items maxed out
                            esc.EventData[2] = (byte)evtNumB.Value;
                            break;
                        case 7: // menu tutorial
                            esc.EventData[2] = (byte)evtNameB.SelectedIndex;
                            break;
                        case 16:    // world map event
                            esc.EventData[2] = (byte)evtNameB.SelectedIndex;
                            break;
                    }

                    /* 
                     * TODO
                     * in eventHandler set evtNumC maximum and labelEvtC text 
                     * based on selectedIndex in evtNameA
                     */
                    break;

                // Jump to
                case 0xD2:
                case 0xD3:
                    Bits.SetShort(esc.EventData, 1, (ushort)evtNumC.Value);
                    break;
                case 0xD4:
                    esc.Option = (byte)evtNumC.Value;
                    break;

                // Screen effects
                case 0x72:
                case 0x73:
                case 0x76:
                case 0x77:
                    esc.Option = (byte)evtNumC.Value;
                    break;
                case 0x78:
                case 0x79:
                case 0x83:
                    if (esc.Opcode != 0x83)
                    {
                        esc.Option = (byte)evtNumC.Value;
                        esc.EventData[2] = (byte)evtNameA.SelectedIndex;
                    }
                    else
                        esc.Option = (byte)evtNameA.SelectedIndex;
                    break;
                case 0x80:
                    ushort color;
                    int r, g, b;
                    r = (int)(evtNumB.Value / 8);
                    g = (int)(evtNumC.Value / 8);
                    b = (int)(evtNumD.Value / 8);
                    color = (ushort)((b << 10) | (g << 5) | r);
                    Bits.SetShort(esc.EventData, 1, color);

                    esc.EventData[4] = (byte)evtNumA.Value;
                    for (int i = 0; i < 8; i++)
                        Bits.SetBit(esc.EventData, 3, i, evtEffects.GetItemChecked(i));
                    break;
                case 0x81:
                    Bits.SetBit(esc.EventData, 1, 0, evtEffects.GetItemChecked(0));
                    Bits.SetBit(esc.EventData, 1, 1, evtEffects.GetItemChecked(1));
                    Bits.SetBit(esc.EventData, 1, 2, evtEffects.GetItemChecked(2));
                    Bits.SetBit(esc.EventData, 1, 4, evtEffects.GetItemChecked(3));
                    Bits.SetBit(esc.EventData, 2, 0, evtEffects.GetItemChecked(4));
                    Bits.SetBit(esc.EventData, 2, 1, evtEffects.GetItemChecked(5));
                    Bits.SetBit(esc.EventData, 2, 2, evtEffects.GetItemChecked(6));
                    Bits.SetBit(esc.EventData, 2, 4, evtEffects.GetItemChecked(7));
                    Bits.SetBit(esc.EventData, 3, 0, evtEffects.GetItemChecked(8));
                    Bits.SetBit(esc.EventData, 3, 1, evtEffects.GetItemChecked(9));
                    Bits.SetBit(esc.EventData, 3, 2, evtEffects.GetItemChecked(10));
                    Bits.SetBit(esc.EventData, 3, 4, evtEffects.GetItemChecked(11));
                    Bits.SetBit(esc.EventData, 3, 5, evtEffects.GetItemChecked(12));
                    Bits.SetBit(esc.EventData, 3, 6, evtEffects.GetItemChecked(13));
                    Bits.SetBit(esc.EventData, 3, 7, evtEffects.GetItemChecked(14));
                    /*
                    * TODO
                    * set evtEffects according to evtNameA.SelectedIndex
                    */
                    break;
                case 0x84:
                    esc.Option = (byte)((byte)evtNumC.Value << 4);
                    esc.EventData[2] = (byte)evtNumD.Value;
                    for (int i = 0; i < 4; i++)
                        Bits.SetBit(esc.EventData, 1, i, evtEffects.GetItemChecked(i));
                    break;
                case 0x89:
                    switch (evtNameA.SelectedIndex)
                    {
                        case 1: esc.Option = 0x60; break;
                        case 2: esc.Option = 0xC0; break;
                        case 3: esc.Option = 0xE0; break;
                        default: esc.Option = 0x00; break;
                    }
                    esc.Option &= 0xF0; esc.Option |= (byte)evtNumB.Value;
                    esc.EventData[3] = (byte)evtNumC.Value;
                    esc.EventData[2] = (byte)evtNumD.Value;
                    break;
                case 0x8A:
                    esc.EventData[2] = (byte)evtNumC.Value;
                    esc.Option = (byte)(((byte)evtNumD.Value << 4) - 1);
                    break;
                case 0x8F:
                    esc.Option = (byte)evtNameA.SelectedIndex;
                    esc.EventData[2] = (byte)evtNumC.Value;
                    esc.EventData[3] = (byte)evtNumD.Value;
                    break;

                // Playback audio
                case 0x90:
                case 0x91:
                case 0x92:
                    esc.Option = (byte)evtNameA.SelectedIndex;
                    break;
                case 0x95:
                    esc.Option = (byte)evtNumC.Value;
                    esc.EventData[2] = (byte)evtNumD.Value;
                    break;
                case 0x97:
                    if (evtNameA.SelectedIndex == 1)
                    {
                        if (evtNumC.Value > 0)
                            esc.EventData[2] = (byte)(0x100 - evtNumC.Value);
                        else esc.EventData[2] = 0;
                    }
                    else
                        esc.EventData[2] = (byte)evtNumC.Value;

                    esc.Option = (byte)evtNumD.Value;
                    /*
                     * TODO
                     * set labelEvtC text and evtNumC value based on what change type is
                     * if slow down, set max to 160, else set max to 94
                     * if speed up, set value = (0x100 - esc.EventData[2]) - 1
                     */
                    break;
                case 0x98:
                    Bits.SetBit(esc.EventData, 2, 7, evtNameA.SelectedIndex == 1);
                    esc.Option = (byte)evtNumC.Value;
                    break;
                case 0x9C:
                    esc.Option = (byte)evtNameA.SelectedIndex;
                    break;
                case 0x9D:
                    esc.Option = (byte)evtNameA.SelectedIndex;
                    esc.EventData[2] = (byte)evtNumC.Value;
                    break;
                case 0x9E:
                    esc.Option = (byte)evtNumC.Value;
                    esc.EventData[2] = (byte)evtNumD.Value;
                    break;

                // Memory
                case 0xA0:
                case 0xA1:
                case 0xA2:
                    esc.Opcode = (byte)(((((byte)(evtNumC.Value - 0x7040) << 3) & 0x0F00) >> 8) + 0xA0);
                    esc.Option = (byte)(((byte)(evtNumC.Value - 0x7040) << 3) & 0xF8);
                    esc.Option &= 0xF8; esc.Option |= (byte)evtNumD.Value;
                    break;
                case 0xA4:
                case 0xA5:
                case 0xA6:
                    esc.Opcode = (byte)(((((byte)(evtNumC.Value - 0x7040) << 3) & 0x0F00) >> 8) + 0xA4);
                    esc.Option = (byte)(((byte)(evtNumC.Value - 0x7040) << 3) & 0xF8);
                    esc.Option &= 0xF8; esc.Option |= (byte)evtNumD.Value;
                    break;
                case 0xA8:
                case 0xA9:
                    esc.Option = (byte)(evtNumC.Value - 0x70A0);
                    esc.EventData[2] = (byte)evtNumD.Value;
                    break;
                case 0xAA:
                case 0xAB:
                    esc.Option = (byte)(evtNumC.Value - 0x70A0);
                    break;
                case 0xB0:
                case 0xB1:
                case 0xC2:
                    esc.Option = (byte)((evtNumC.Value - 0x7000) / 2);
                    Bits.SetShort(esc.EventData, 2, (ushort)evtNumD.Value);
                    break;
                case 0xB2:
                case 0xB3:
                case 0xD6:
                case 0xBB:
                    esc.Option = (byte)((evtNumC.Value - 0x7000) / 2);
                    break;
                case 0xB5:
                    esc.Option = (byte)(evtNumC.Value - 0x70A0);
                    break;
                case 0xB7:
                    esc.Option = (byte)((evtNumC.Value - 0x7000) / 2);
                    Bits.SetShort(esc.EventData, 2, (ushort)evtNumD.Value);
                    break;
                case 0xBC:
                case 0xBD:
                    esc.Option = (byte)((evtNumC.Value - 0x7000) / 2);
                    esc.EventData[2] = (byte)((evtNumD.Value - 0x7000) / 2);
                    break;
                case 0xD8:
                case 0xD9:
                case 0xDA:
                    esc.Opcode = (byte)(((((byte)(evtNumC.Value - 0x7040) << 3) & 0x0F00) >> 8) + 0xD8);
                    esc.Option = (byte)(((byte)(evtNumC.Value - 0x7040) << 3) & 0xF8);
                    esc.Option &= 0xF8; esc.Option |= (byte)evtNumD.Value;
                    Bits.SetShort(esc.EventData, 2, (ushort)evtNumE.Value);
                    break;
                case 0xDC:
                case 0xDD:
                case 0xDE:
                    esc.Opcode = (byte)(((((byte)(evtNumC.Value - 0x7040) << 3) & 0x0F00) >> 8) + 0xDC);
                    esc.Option = (byte)(((byte)(evtNumC.Value - 0x7040) << 3) & 0xF8);
                    esc.Option &= 0xF8; esc.Option |= (byte)evtNumD.Value;
                    Bits.SetShort(esc.EventData, 2, (ushort)evtNumE.Value);
                    break;
                case 0xE0:
                case 0xE1:
                    esc.Option = (byte)(evtNumC.Value - 0x70A0);
                    esc.EventData[2] = (byte)evtNumD.Value;
                    Bits.SetShort(esc.EventData, 3, (ushort)evtNumE.Value);
                    break;
                case 0xE4:
                case 0xE5:
                    esc.Option = (byte)((evtNumC.Value - 0x7000) / 2);
                    Bits.SetShort(esc.EventData, 2, (ushort)evtNumD.Value);
                    Bits.SetShort(esc.EventData, 4, (ushort)evtNumE.Value);
                    break;
                case 0xE8:
                    Bits.SetShort(esc.EventData, 1, (ushort)evtNumC.Value);
                    break;
                case 0xE9:
                    Bits.SetShort(esc.EventData, 1, (ushort)evtNumC.Value);
                    Bits.SetShort(esc.EventData, 3, (ushort)evtNumD.Value);
                    break;

                // Memory $7000
                case 0x38:
                    if (esc.Option < 8) esc.Option = 8;
                    esc.Option = (byte)(evtNumC.Value + 8);
                    break;
                case 0xAC:
                case 0xAD:
                case 0xB6:
                case 0xC0:
                    Bits.SetShort(esc.EventData, 1, (ushort)evtNumC.Value);
                    break;
                case 0xB4:
                    esc.Option = (byte)(evtNumC.Value - 0x70A0);
                    break;
                case 0xB8:
                case 0xB9:
                case 0xBA:
                case 0xC1:
                    esc.Option = (byte)((evtNumC.Value - 0x7000) / 2);
                    break;
                case 0xC4:
                case 0xC5:
                case 0xC6:
                    esc.Option = (byte)evtNameA.SelectedIndex;
                    Bits.SetBit(esc.EventData, 1, 7, evtEffects.GetItemChecked(0));
                    break;
                case 0xDB:
                case 0xDF:
                    Bits.SetShort(esc.EventData, 1, (ushort)evtNumC.Value);
                    break;
                case 0xE2:
                case 0xE3:
                case 0xE6:
                case 0xE7:
                    Bits.SetShort(esc.EventData, 1, (ushort)evtNumC.Value);
                    Bits.SetShort(esc.EventData, 3, (ushort)evtNumD.Value);
                    break;
                case 0xEA:
                case 0xEB:
                case 0xEC:
                case 0xED:
                case 0xEE:
                case 0xEF:
                    Bits.SetShort(esc.EventData, 1, (ushort)evtNumC.Value);
                    break;

                // Pause script
                case 0xF0:
                    esc.Option = (byte)evtNumC.Value;
                    break;
                case 0xF1:
                    Bits.SetShort(esc.EventData, 1, (ushort)evtNumC.Value);
                    break;

                default:
                    // Action Queue (same for all sub-indexes, so no need to do a switch for sub)
                    if (esc.Opcode <= 0x2F)
                    {
                        byte temp = esc.Opcode;
                        switch (evtNameB.SelectedIndex)
                        {
                            case 0:
                                esc.Opcode = (byte)evtNameA.SelectedIndex;
                                Bits.SetBit(esc.EventData, 1, 7, evtEffects.GetItemChecked(0));
                                break;
                            case 1:
                            case 2:
                                esc.EventData = new byte[3];
                                esc.Opcode = (byte)evtNameA.SelectedIndex;
                                esc.Option = (byte)(evtNameB.SelectedIndex + 0xEF);
                                Bits.SetBit(esc.EventData, 2, 7, evtEffects.GetItemChecked(0));
                                break;
                            case 3:
                            case 4:
                            case 5:
                            case 6:
                                esc.EventData = new byte[4];
                                esc.Opcode = (byte)evtNameA.SelectedIndex;
                                esc.Option = (byte)(evtNameB.SelectedIndex + 0xEF);
                                Bits.SetShort(esc.EventData, 2, (ushort)evtNumC.Value);
                                break;
                            default:
                                esc.Opcode = (byte)evtNameA.SelectedIndex;
                                esc.Option = (byte)(evtNameB.SelectedIndex + 0xEF);
                                break;
                        }

                        /*
                         * TODO
                         * set evtNumC value and labelEvtC text according to evtNameB.SelectedIndex
                         */
                    }
                    else if (esc.Opcode == 0xFD)
                    {
                        switch (esc.Option)
                        {
                            // Objects
                            case 0x33:
                            case 0x34:
                            case 0x3D:         // If in air, object...
                                esc.EventData[2] = (byte)evtNameA.SelectedIndex;
                                Bits.SetShort(esc.EventData, 3, (ushort)evtNumC.Value);
                                break;
                            case 0x3E:
                                esc.EventData[2] = (byte)evtNumC.Value;
                                Bits.SetShort(esc.EventData, 3, (ushort)evtNumD.Value);
                                Bits.SetShort(esc.EventData, 5, (ushort)evtNumE.Value);
                                break;

                            // Menus
                            case 0x4C:
                                esc.EventData[2] = (byte)evtNumC.Value;
                                break;

                            // Run event
                            case 0x4D:
                                esc.EventData[2] = (byte)evtNumC.Value;
                                break;
                            case 0x66:
                                esc.EventData[3] = (byte)evtNameA.SelectedIndex;
                                esc.EventData[2] = (byte)evtNumC.Value;
                                break;

                            // Playback audio
                            case 0x9C:
                                esc.EventData[2] = (byte)evtNameA.SelectedIndex;
                                break;

                            // Memory
                            case 0xB6:
                                esc.EventData[2] = (byte)((evtNumC.Value - 0x7000) / 2);
                                esc.EventData[3] = (byte)((byte)(evtNumD.Value - 1) ^ 0xFF);
                                break;
                            case 0xB7:
                                esc.EventData[2] = (byte)((evtNumC.Value - 0x7000) / 2);
                                break;

                            // Memory $7000
                            case 0x58:
                                esc.EventData[2] = (byte)evtNumA.Value;
                                break;
                            case 0x5D:
                                esc.EventData[2] = (byte)evtNameA.SelectedIndex;
                                esc.EventData[3] = (byte)evtNameB.SelectedIndex;
                                break;
                            case 0xAC:
                                Bits.SetShort(esc.EventData, 2, (ushort)(evtNumC.Value - 0x7FF800));
                                break;
                            case 0xB0:
                            case 0xB1:
                            case 0xB2:
                                Bits.SetShort(esc.EventData, 2, (ushort)evtNumC.Value);
                                break;
                            case 0xB3:
                            case 0xB4:
                            case 0xB5:
                                esc.EventData[2] = (byte)((evtNumC.Value - 0x7000) / 2);
                                break;

                            default: break;
                        }
                    }
                    break;
            }
        }
        private string[] DialogueNames()
        {
            String[] names = new String[Model.Dialogues.Length];
            for (int i = 0; i < Model.Dialogues.Length; i++)
                names[i] = Model.Dialogues[i].GetDialogueStub(true);
            return names;
        }
        // Editing
        private void EditCommand(EventScriptCommand dest, bool insert)
        {

        }
        private void EditCommand(ActionQueueCommand dest, bool insert)
        {

        }
        private void InsertEventCommand()
        {
            byte[] temp;
            int opcode;
            int option;

            opcode = Lists.EventListBoxOpcodes[categories_es.SelectedIndex][commands.SelectedIndex];
            option = Lists.EventListBoxFDOpcodes[categories_es.SelectedIndex][commands.SelectedIndex];

            temp = new byte[ScriptEnums.GetEventOpcodeLength(opcode, option)];
            temp[0] = (byte)opcode;
            if (temp.Length > 1)
                temp[1] = (byte)option;
            esc = new EventScriptCommand(temp, 0);

            ControlEventAsmMethod();
            treeViewWrapper.InsertNode(esc);
        }
        private void InsertActionCommand()
        {
            byte[] temp;
            int opcode;
            int option;

            opcode = Lists.ActionListBoxOpcodes[categories_aq.SelectedIndex][commands.SelectedIndex];
            option = Lists.ActionListBoxFDOpcodes[categories_aq.SelectedIndex][commands.SelectedIndex];

            temp = new byte[ScriptEnums.GetActionQueueOpcodeLength(opcode, option)];
            temp[0] = (byte)opcode;
            if (temp.Length > 1)
                temp[1] = (byte)option;
            aqc = new ActionQueueCommand(temp, 0);

            ControlActionAsmMethod();
            treeViewWrapper.InsertNode(aqc);
        }
        // Update offsets
        public void UpdateScriptOffsets()
        {
            int delta = treeViewWrapper.ScriptDelta;
            int eventNum = treeViewWrapper.Script.Index;
            int end, start;
            int conditionOffset = 0;

            if (eventNum >= 0 && eventNum <= 1535)
            {
                start = 0;
                end = 1535; // Bank 1E

                if (eventNum < end)
                    conditionOffset = eventScripts[eventNum + 1].BaseOffset;
                else
                    conditionOffset = eventScripts[eventNum].BaseOffset + eventScripts[eventNum].ScriptLength; // Dont need to update anything after this event if its the last one                    
            }
            else if (eventNum >= 1536 && eventNum <= 3071)
            {
                start = 1536;
                end = 3071; // Bank 1F

                if (eventNum < end)
                    conditionOffset = eventScripts[eventNum + 1].BaseOffset;
                else
                    conditionOffset = eventScripts[eventNum].BaseOffset + eventScripts[eventNum].ScriptLength; // Dont need to update anything after this event if its the last one
            }
            else if (eventNum >= 3072 && eventNum <= 4095)
            {
                start = 3072;
                end = 4095; // Bank 20

                if (eventNum < end)
                    conditionOffset = eventScripts[eventNum + 1].BaseOffset;
                else
                    conditionOffset = eventScripts[eventNum].BaseOffset + eventScripts[eventNum].ScriptLength; // Dont need to update anything after this event if its the last one
            }
            else
                throw new Exception("Invalid event num");

            if (!autoPointerUpdate.Checked)
                conditionOffset = 0x7FFFFFFF;

            if (autoPointerUpdate.Checked)
            {
                // Update all pointers before eventOffset
                for (int i = start; i < eventNum; i++)
                    eventScripts[i].UpdateAllOffsets(delta, conditionOffset);
            }

            // Update all events and pointers after edited event
            for (int i = eventNum + 1; i <= end; i++)
                eventScripts[i].UpdateAllOffsets(delta, conditionOffset);

            if (autoPointerUpdate.Checked)
            {
                // Update all pointers to edited event
                UpdateCurrentScriptReferencePointers();
            }
            treeViewWrapper.ScriptDelta = 0;
        }
        private void UpdateCurrentScriptReferencePointers()
        {

            EventScript es = treeViewWrapper.Script;

            foreach (EventScriptCommand esc in es.Commands)
            {
                if (esc.IsActionQueueTrigger && esc.EmbeddedActionQueue.Commands != null)
                {
                    foreach (ActionQueueCommand aqc in esc.EmbeddedActionQueue.Commands)
                    {
                        if (aqc.CommandDelta != 0)
                            UpdatePointersToCommand(aqc);
                    }
                }
                else
                {
                    if (esc.CommandDelta != 0)
                        UpdatePointersToCommand(esc);
                }
            }
        }
        private void UpdatePointersToCommand(ActionQueueCommand aqcRef)
        {
            ushort pointer;

            foreach (EventScript es in eventScripts)
            {
                /* 12-31-08
                 * UpdateInternalPointers() in TreeViewWrapper.cs already does this
                 * for the current event script; doing it again for the current script
                 * would screw up the pointers in the current script
                 * thus, the following conditional is needed
                 */
                if (es.Index != treeViewWrapper.Script.Index)
                {
                    foreach (EventScriptCommand escIterator in es.Commands)
                    {
                        if (escIterator.IsActionQueueTrigger && escIterator.EmbeddedActionQueue.Commands != null)
                        {
                            foreach (ActionQueueCommand aqcIterator in escIterator.EmbeddedActionQueue.Commands)
                            {
                                if (aqcIterator.Opcode == 0xE9)
                                {
                                    pointer = aqcIterator.ReadPointerSpecial(0);
                                    if (pointer == (aqcRef.OriginalOffset & 0xFFFF))
                                    {
                                        aqcIterator.WritePointerSpecial(0, (ushort)(pointer + aqcRef.CommandDelta));
                                    }
                                    pointer = aqcIterator.ReadPointerSpecial(1);
                                    if (pointer == (aqcRef.OriginalOffset & 0xFFFF))
                                    {
                                        aqcIterator.WritePointerSpecial(1, (ushort)(pointer + aqcRef.CommandDelta));
                                    }
                                }
                                else
                                {
                                    pointer = aqcIterator.ReadPointer();
                                    if (pointer == (aqcRef.OriginalOffset & 0xFFFF))
                                    {
                                        aqcIterator.WritePointer((ushort)(pointer + aqcRef.CommandDelta));
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (escIterator.Opcode == 0x42 || escIterator.Opcode == 0xE9 || escIterator.Opcode == 0x67)
                            {
                                pointer = escIterator.ReadPointerSpecial(0);
                                if (pointer == (aqcRef.OriginalOffset & 0xFFFF))
                                {
                                    escIterator.WritePointerSpecial(0, (ushort)(pointer + aqcRef.CommandDelta));
                                }
                                pointer = escIterator.ReadPointerSpecial(1);
                                if (pointer == (aqcRef.OriginalOffset & 0xFFFF))
                                {
                                    escIterator.WritePointerSpecial(1, (ushort)(pointer + aqcRef.CommandDelta));
                                }
                            }
                            else
                            {
                                pointer = escIterator.ReadPointer();
                                if (pointer == (aqcRef.OriginalOffset & 0xFFFF))
                                {
                                    escIterator.WritePointer((ushort)(pointer + aqcRef.CommandDelta));
                                }
                            }
                        }
                    }
                }
            }
        }
        private void UpdatePointersToCommand(EventScriptCommand escRef)
        {
            ushort pointer;
            foreach (EventScript es in eventScripts)
            {
                if (es.Index != treeViewWrapper.Script.Index)
                {
                    foreach (EventScriptCommand escIterator in es.Commands)
                    {
                        if (escIterator.IsActionQueueTrigger && escIterator.EmbeddedActionQueue.Commands != null)
                        {
                            foreach (ActionQueueCommand aqcIterator in escIterator.EmbeddedActionQueue.Commands)
                            {
                                if (aqcIterator.Opcode == 0xE9)
                                {
                                    pointer = aqcIterator.ReadPointerSpecial(0);
                                    if (pointer == (escRef.OriginalOffset & 0xFFFF))
                                    {
                                        aqcIterator.WritePointerSpecial(0, (ushort)(pointer + escRef.CommandDelta));
                                    }
                                    pointer = aqcIterator.ReadPointerSpecial(1);
                                    if (pointer == (escRef.OriginalOffset & 0xFFFF))
                                    {
                                        aqcIterator.WritePointerSpecial(1, (ushort)(pointer + escRef.CommandDelta));
                                    }
                                }
                                else
                                {
                                    pointer = aqcIterator.ReadPointer();
                                    if (pointer == (escRef.OriginalOffset & 0xFFFF))
                                    {
                                        aqcIterator.WritePointer((ushort)(pointer + escRef.CommandDelta));
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (escIterator.Opcode == 0x42 || escIterator.Opcode == 0xE9 || escIterator.Opcode == 0x67)
                            {
                                pointer = escIterator.ReadPointerSpecial(0);
                                if (pointer == (escRef.OriginalOffset & 0xFFFF))
                                {
                                    escIterator.WritePointerSpecial(0, (ushort)(pointer + escRef.CommandDelta));
                                }
                                pointer = escIterator.ReadPointerSpecial(1);
                                if (pointer == (escRef.OriginalOffset & 0xFFFF))
                                {
                                    escIterator.WritePointerSpecial(1, (ushort)(pointer + escRef.CommandDelta));
                                }
                            }
                            else
                            {
                                pointer = escIterator.ReadPointer();
                                if (pointer == (escRef.OriginalOffset & 0xFFFF))
                                {
                                    escIterator.WritePointer((ushort)(pointer + escRef.CommandDelta));
                                }
                            }
                        }
                    }
                }
            }
        }
        // Update controls
        private void UpdateEventScriptsFreeSpace()
        {
            int left = CalculateEventScriptsLength();
            this.EvtScrLabel3.Text = " " + left.ToString() + " bytes left ";
            this.EvtScrLabel3.BackColor = left < 0 ? Color.Red : SystemColors.Control;
        }
        private int CalculateEventScriptsLength()
        {
            int totalSize;
            int length = 0;
            int min;
            int max;

            if (currentScript < 0x600)
            {
                totalSize = 0x10000 - 0xC00;
                min = 0; max = 0x600;
            }
            else if (currentScript < 0xC00)
            {
                totalSize = 0x10000 - 0xC00;
                min = 0x600; max = 0xC00;
            }
            else
            {
                totalSize = 0xE000 - 0x800;
                min = 0xC00; max = 0x1000;
            }

            for (int i = min; i < max; i++)
                length += eventScripts[i].Script.Length;

            return totalSize - length - 1;
        }
        private void ResetAllEventLists()
        {
            ResetAllEventControls();
            buttonInsertEvent.Enabled = false;
            buttonApplyEvent.Enabled = false;
            if (type == 1)   // Action Scripts
            {
                eventNum.Maximum = 1023;
                categories_aq.BringToFront();
                categories_aq.SelectedIndex = 0;
                categories_aq_SelectedIndexChanged(null, null);
                isActionScript = true;
                treeViewWrapper.ActionScript = true;
            }
            else    // Event Scripts
            {
                eventNum.Maximum = 4095;
                categories_es.BringToFront();
                categories_es.SelectedIndex = 0;
                categories_es_SelectedIndexChanged(null, null);
                isActionScript = false;
                treeViewWrapper.ActionScript = false;
            }
        }
        private void ResetAllEventControls()
        {
            updatingControls = false;

            evtNameA.Items.Clear(); evtNameA.ResetText(); evtNameA.Enabled = false;
            evtNameB.Items.Clear(); evtNameB.ResetText(); evtNameB.Enabled = false;
            evtNumA.Maximum = 255; evtNumA.Hexadecimal = false; evtNumA.Value = 0; evtNumA.Enabled = false;
            evtNumB.Maximum = 255; evtNumB.Hexadecimal = false; evtNumB.Value = 0; evtNumB.Enabled = false;
            evtNumC.Maximum = 255; evtNumC.Hexadecimal = false; evtNumC.Minimum = 0; evtNumC.Increment = 1; evtNumC.Value = 0; evtNumC.Enabled = false;
            evtNumD.Maximum = 255; evtNumD.Hexadecimal = false; evtNumD.Minimum = 0; evtNumD.Increment = 1; evtNumD.Value = 0; evtNumD.Enabled = false;
            evtNumE.Maximum = 255; evtNumE.Hexadecimal = false; evtNumE.Value = 0; evtNumE.Enabled = false;
            evtNumF.Maximum = 255; evtNumF.Value = 0; evtNumF.Enabled = false;
            evtEffects.ColumnWidth = 138; evtEffects.Items.Clear(); evtEffects.Enabled = false;

            labelTitleA.Text = "";
            labelTitleC.Text = "";
            labelTitleB.Text = "";
            labelEvtA.Text = "";
            labelEvtB.Text = "";
            labelEvtC.Text = "";
            labelEvtD.Text = "";
            labelEvtE.Text = "";
            labelEvtF.Text = "";

            updatingControls = true;
        }
        private void UpdateCommandData()
        {
            this.eventHexText.Text = BitConverter.ToString(treeViewWrapper.CurrentNodeData);

            if (!isActionScript)
            {
                eventScripts[currentScript].Assemble();
                UpdateEventScriptsFreeSpace();
            }
            else
            {
                actionScripts[currentScript].Assemble();
                UpdateActionScriptsFreeSpace();
            }
        }
        // Saving
        public void Assemble()
        {
            if (!isActionScript)
                UpdateScriptOffsets();
            else
                UpdateActionOffsets();
            // Save current script first

            settings.Save();

            if (CalculateEventScriptsLength() >= 0)
                AssembleAllEventScripts();
            else
                MessageBox.Show("There is not enough available space to save the event scripts to.\n\nThe event scripts were not saved.", "LAZY SHELL");

            if (CalculateActionScriptsLength() >= 0)
                AssembleAllActionScripts();
            else
                MessageBox.Show("There is not enough available space to save the action scripts to.\n\nThe action scripts were not saved.", "LAZY SHELL");

            if (!isActionScript)
            {
                Model.HexViewer.Offset = eventScript.BaseOffset & 0xFFFFF0;
                Model.HexViewer.SelectionStart = (eventScript.BaseOffset & 15) * 3;
            }
            else
            {
                Model.HexViewer.Offset = actionScript.Offset & 0xFFFFF0;
                Model.HexViewer.SelectionStart = (actionScript.Offset & 15) * 3;
            }
            Model.HexViewer.Compare();
            checksum = Do.GenerateChecksum(eventScripts, actionScripts);
        }
        public void AssembleAllEventScripts()
        {
            foreach (EventScript es in eventScripts)
                es.Assemble();

            int i = 0;
            int pointer = 0;
            int bank = 0x1E0000;
            ushort offset = 0xC00;
            for (; i < 1536; i++, pointer += 2)
            {
                Bits.SetShort(Model.Data, bank + pointer, offset);
                Bits.SetByteArray(Model.Data, bank + offset, eventScripts[i].Script);
                offset += (ushort)eventScripts[i].Script.Length;
            }
            for (int a = offset; a < 0x10000; a++) Model.Data[bank + a] = 0xFF;

            pointer = 0;
            bank = 0x1F0000;
            offset = 0xC00;
            for (; i < 3072; i++, pointer += 2)
            {
                Bits.SetShort(Model.Data, bank + pointer, offset);
                Bits.SetByteArray(Model.Data, bank + offset, eventScripts[i].Script);
                offset += (ushort)eventScripts[i].Script.Length;
            }
            for (int a = offset; a < 0x10000; a++) Model.Data[bank + a] = 0xFF;

            pointer = 0;
            bank = 0x200000;
            offset = 0x800;
            for (; i < 4096; i++, pointer += 2)
            {
                Bits.SetShort(Model.Data, bank + pointer, offset);
                Bits.SetByteArray(Model.Data, bank + offset, eventScripts[i].Script);
                offset += (ushort)eventScripts[i].Script.Length;
            }
            for (int a = offset; a < 0xE000; a++) Model.Data[bank + a] = 0xFF;
        }
        public void AssembleAllActionScripts()
        {
            foreach (ActionQueue ac in actionScripts)
                ac.Assemble();

            int i = 0;
            int pointer = 0;
            int bank = 0x210000;
            ushort offset = 0x800;
            for (; i < actionScripts.Length; i++, pointer += 2)
            {
                Bits.SetShort(Model.Data, bank + pointer, offset);
                Bits.SetByteArray(Model.Data, bank + offset, actionScripts[i].ActionQueueData);
                offset += (ushort)actionScripts[i].ActionQueueData.Length;
            }
        }
        // Other
        private void PreviewEventOrAction()
        {
            if (ep == null || !ep.Visible)
                ep = new Previewer.Previewer(this.currentScript, this.type == 0 ? 0 : 2);
            else
                ep.Reload(this.currentScript, this.type == 0 ? 0 : 2);
            ep.Show();
        }
        private void SaveEventNotes()
        {
            try
            {
                //this.EventScriptNotes.SaveFile(notes.GetPath() + "main-scripts-event.rtf");
            }
            catch
            {
                MessageBox.Show("ERROR saving main-scripts-event.rtf, please report this if it persists");
            }
        }
        #endregion
        #region Event Handlers
        private void eventNum_ValueChanged(object sender, EventArgs e)
        {
            if (!updatingScript) return;
            RefreshEventScript();
            //
            if (!disableNavigate && lastNavigate != null)
            {
                navigateBackward.Push(new Navigate(lastNavigate.Index, lastNavigate.Type));
                navigateBck.Enabled = true;
            }
            if (!disableNavigate)
                lastNavigate = new Navigate(index, type);
            settings.LastEventScript = index;
            settings.LastEventScriptCat = type;
        }
        private void eventName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!updatingScript) return;
            updatingScript = false;
            eventNum.Value = currentScript = 0;
            if (!isActionScript)
                UpdateScriptOffsets();
            else
                UpdateActionOffsets();
            ResetAllEventLists();
            if (isActionScript)
                treeViewWrapper.ChangeScript(actionScripts[(int)this.eventNum.Value]);
            else
                treeViewWrapper.ChangeScript(eventScripts[(int)this.eventNum.Value]);
            UpdateCommandData();
            if (!isActionScript)
                eventLabel.Text = settings.EventLabels[currentScript];
            else
                eventLabel.Text = settings.ActionLabels[currentScript];
            updatingScript = true;
            //
            if (!disableNavigate && lastNavigate != null)
            {
                navigateBackward.Push(new Navigate(lastNavigate.Index, lastNavigate.Type));
                navigateBck.Enabled = true;
            }
            if (!disableNavigate)
                lastNavigate = new Navigate(index, type);
            settings.LastEventScript = index;
            settings.LastEventScriptCat = type;
        }
        private void EventScripts_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Do.GenerateChecksum(eventScripts, actionScripts) == checksum)
                goto Close;
            DialogResult result;

            result = MessageBox.Show("Event Scripts have not been saved.\n\nWould you like to save changes?", "LAZY SHELL", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
                Assemble();
            else if (result == DialogResult.No)
            {
                Model.EventScripts = null;
            }
            else if (result == DialogResult.Cancel)
            {
                e.Cancel = true;
                return;
            }
        Close:
            settings.Save();
            searchWindow.Close();
            if (ep != null)
                ep.Close();
        }
        private void navigateBck_Click(object sender, EventArgs e)
        {
            if (navigateBackward.Count < 1)
                return;
            navigateForward.Push(new Navigate(index, type));
            //
            disableNavigate = true;
            type = navigateBackward.Peek().Type;
            index = navigateBackward.Peek().Index;
            disableNavigate = false;
            //
            RefreshEventScript();
            lastNavigate = new Navigate(index, type);
            navigateBackward.Pop();
            navigateBck.Enabled = navigateBackward.Count > 0;
            navigateFwd.Enabled = true;
        }
        private void navigateFwd_Click(object sender, EventArgs e)
        {
            if (navigateForward.Count < 1)
                return;
            navigateBackward.Push(new Navigate(index, type));
            //
            disableNavigate = true;
            type = navigateForward.Peek().Type;
            index = navigateForward.Peek().Index;
            disableNavigate = false;
            //
            RefreshEventScript();
            lastNavigate = new Navigate(index, type);
            navigateForward.Pop();
            navigateFwd.Enabled = navigateForward.Count > 0;
            navigateBck.Enabled = true;
        }
        private void eventLabel_TextChanged(object sender, EventArgs e)
        {
            if (!isActionScript)
                settings.EventLabels[currentScript] = eventLabel.Text;
            else
                settings.ActionLabels[currentScript] = eventLabel.Text;
        }
        // tree
        private void EventScriptTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (!updatingScript) return;
            if (!EventScriptTree.Enabled)
                return;
            UpdateCommandData();
            // Set command/category listboxes based on selected node
            EventScriptCommand tempEsc;
            // if selecting an action queue/script command
            if (EventScriptTree.SelectedNode.Parent != null || isActionScript)
            {
                button1.Visible = false;
                isActionSelected = true;
                if (categories_aq.Parent.Controls.GetChildIndex(categories_aq) != 0)
                {
                    categories_aq.BringToFront();
                    commands.Items.Clear();
                    commands.Items.AddRange(Lists.ActionListBoxNames(categories_aq.SelectedIndex));
                    categories_aq.SelectedIndex = 0;
                    commands.SelectedIndex = 0;
                }
                if (aqc == null && editedNode == null)    // if an event command is in the COMMAND PROPERTIES panel
                {
                    ResetAllEventControls();
                    buttonInsertEvent.Enabled = false;
                }
            }
            // if selecting an event script command
            else
            {
                tempEsc = (EventScriptCommand)eventScripts[currentScript].Commands[EventScriptTree.SelectedNode.Index];
                button1.Checked = false;
                button1.Visible = tempEsc.Opcode <= 0x2F && tempEsc.Option < 0xF2;
                isActionSelected = false;
                if (categories_es.Parent.Controls.GetChildIndex(categories_es) != 0)
                {
                    categories_es.BringToFront();
                    commands.Items.Clear();
                    commands.Items.AddRange(Lists.EventListBoxNames(categories_es.SelectedIndex));
                    categories_es.SelectedIndex = 0;
                    commands.SelectedIndex = 0;
                }
                if (aqc != null && editedNode == null)    // if an action queue command is in the COMMAND PROPERTIES panel
                {
                    ResetAllEventControls();
                    buttonInsertEvent.Enabled = false;
                }
            }
            treeViewWrapper.SelectedNode = EventScriptTree.SelectedNode;
        }
        private void EventScriptTree_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!EventScriptTree.Enabled)
                return;

            // Edit Event/ActionQueue
            EvtScrEditCommand_Click(null, null);
        }
        private void EventScriptTree_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            Do.AddHistory(this, index, e.Node, "NodeMouseClick");
            //
            EventScriptTree.SelectedNode = e.Node;
            if (e.Button != MouseButtons.Right) return;
            goToToolStripMenuItem.Click -= goToDialogue_Click;
            goToToolStripMenuItem.Click -= goToEvent_Click;
            goToToolStripMenuItem.Click -= goToOffset_Click;
            goToToolStripMenuItem.Click -= addMemoryToNotesDatabase_Click;
            goToToolStripMenuItem.Click -= addMemoryToNotesDatabase_Click;
            if (EventScriptTree.SelectedNode.Tag.GetType() == typeof(EventScriptCommand))
            {
                EventScriptCommand temp = (EventScriptCommand)EventScriptTree.SelectedNode.Tag;
                if (temp.Opcode == 0x60 || temp.Opcode == 0x62)
                {
                    e.Node.ContextMenuStrip = contextMenuStripGoto;
                    goToToolStripMenuItem.Text = "Edit dialogue...";
                    goToToolStripMenuItem.Click += new EventHandler(goToDialogue_Click);
                }
                else if (temp.Opcode == 0x40 || temp.Opcode == 0xD0 || temp.Opcode == 0xD1)
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
                else if (temp.Opcode <= 0x2F && temp.Option >= 0xF2 && temp.Option <= 0xF5)
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
                    goToToolStripMenuItem.Text = "Add to notes database...";
                    goToToolStripMenuItem.Click += new EventHandler(addMemoryToNotesDatabase_Click);
                }
                else if (temp.Opcode == 0xFD)
                {
                    if (temp.Option == 0xD8 || temp.Option == 0xD9 || temp.Option == 0xDA ||
                        temp.Option == 0xDC || temp.Option == 0xDD || temp.Option == 0xDE)
                    {
                        e.Node.ContextMenuStrip = contextMenuStripGoto;
                        goToToolStripMenuItem.Text = "Add to notes database...";
                        goToToolStripMenuItem.Click += new EventHandler(addMemoryToNotesDatabase_Click);
                    }
                }
            }
            else
            {
                ActionQueueCommand temp = (ActionQueueCommand)EventScriptTree.SelectedNode.Tag;
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
                    goToToolStripMenuItem.Text = "Add to notes database...";
                    goToToolStripMenuItem.Click += new EventHandler(addMemoryToNotesDatabase_Click);
                }
            }
        }
        private void EventScriptTree_AfterCheck(object sender, TreeViewEventArgs e)
        {
            EventScriptCommand esc;
            ActionQueueCommand aqc;
            if (e.Node.Parent != null || isActionScript)
            {
                aqc = (ActionQueueCommand)e.Node.Tag;
                aqc.Set = e.Node.Checked;
            }
            else
            {
                esc = (EventScriptCommand)e.Node.Tag;
                esc.Set = e.Node.Checked;
            }
        }
        private void EventScriptTree_KeyDown(object sender, KeyEventArgs e)
        {
            if (!EventScriptTree.Enabled)
                return;
            if (!EventScriptTree.Focused)
                return;

            switch (e.KeyData)
            {
                case Keys.Control | Keys.A: Do.SelectAllNodes(EventScriptTree.Nodes, true); break;
                case Keys.Control | Keys.D: Do.SelectAllNodes(EventScriptTree.Nodes, false); break;
                case Keys.Control | Keys.C: EvtScrCopyCommand_Click(null, null); break;
                case Keys.Control | Keys.V: EvtScrPasteCommand_Click(null, null); break;
                case Keys.Shift | Keys.Up:
                case Keys.Control | Keys.Up: EvtScrMoveUp_Click(null, null); break;
                case Keys.Shift | Keys.Down:
                case Keys.Control | Keys.Down: EvtScrMoveDown_Click(null, null); break;
                case Keys.Delete: EvtScrDeleteCommand_Click(null, null); break;
            }
        }
        // functions
        private void EvtScrMoveUp_Click(object sender, EventArgs e)
        {
            updatingScript = false;

            if (EventScriptTree.SelectedNode == null) return;

            if (EventScriptTree.SelectedNode != editedNode)
            {
                editedNode = null;
                buttonApplyEvent.Enabled = false;
            }
            try
            {
                esc = (EventScriptCommand)eventScripts[currentScript].Commands[EventScriptTree.SelectedNode.Index];
            }
            catch
            {
            }
            treeViewWrapper.MoveUp();
            checksum--;

            updatingScript = true;
            Do.AddHistory(this, index, EventScriptTree.SelectedNode, "MoveUpCommand");
        }
        private void EvtScrMoveDown_Click(object sender, EventArgs e)
        {
            updatingScript = false;

            if (EventScriptTree.SelectedNode == null) return;

            if (EventScriptTree.SelectedNode != editedNode)
            {
                editedNode = null;
                buttonApplyEvent.Enabled = false;
            }

            try
            {
                esc = (EventScriptCommand)eventScripts[currentScript].Commands[EventScriptTree.SelectedNode.Index];
            }
            catch
            {
            }
            treeViewWrapper.MoveDown();
            checksum--;

            updatingScript = true;
            Do.AddHistory(this, index, EventScriptTree.SelectedNode, "MoveDownCommand");
        }
        private void EvtScrCopyCommand_Click(object sender, EventArgs e)
        {
            if (EventScriptTree.SelectedNode == null) return;

            treeViewWrapper.Copy();
            Do.AddHistory(this, index, EventScriptTree.SelectedNode, "CopyCommand");
        }
        private void EvtScrPasteCommand_Click(object sender, EventArgs e)
        {
            if (EventScriptTree.SelectedNode != editedNode)
            {
                editedNode = null;
                buttonApplyEvent.Enabled = false;
            }

            treeViewWrapper.Paste();
            UpdateCommandData();

            EventScriptTree.SelectedNode = treeViewWrapper.SelectedNode;
            Do.AddHistory(this, index, EventScriptTree.SelectedNode, "PasteCommand");
        }
        private void EvtScrDeleteCommand_Click(object sender, EventArgs e)
        {
            //if (EventScriptTree.SelectedNode == null) return;

            if (EventScriptTree.SelectedNode != null && EventScriptTree.SelectedNode == editedNode)
            {
                editedNode = null;
                buttonApplyEvent.Enabled = false;
            }
            treeViewWrapper.RemoveNode();
            UpdateCommandData();

            EventScriptTree.SelectedNode = treeViewWrapper.SelectedNode;
            Do.AddHistory(this, index, EventScriptTree.SelectedNode, "DeleteCommand");
        }
        private void EvtScrEditCommand_Click(object sender, EventArgs e)
        {
            if (EventScriptTree.SelectedNode == null) return;

            ResetAllEventControls();

            // action queue command
            if (EventScriptTree.SelectedNode.Parent != null)
            {
                esc = (EventScriptCommand)eventScripts[currentScript].Commands[EventScriptTree.SelectedNode.Parent.Index];
                aqc = (ActionQueueCommand)esc.EmbeddedActionQueue.Commands[EventScriptTree.SelectedNode.Index];
                ControlActionDisasmMethod();
            }
            // action script command
            else if (isActionScript)
            {
                aqc = (ActionQueueCommand)actionScripts[currentScript].Commands[EventScriptTree.SelectedNode.Index];
                esc = null;
                ControlActionDisasmMethod();
            }
            // event script command
            else
            {
                esc = (EventScriptCommand)eventScripts[currentScript].Commands[EventScriptTree.SelectedNode.Index];
                aqc = null;
                ControlEventDisasmMethod();
            }

            buttonApplyEvent.Enabled = true;

            UpdateCommandData();

            editedNode = EventScriptTree.SelectedNode;
            EventScriptTree.SelectedNode = treeViewWrapper.SelectedNode;

            treeViewWrapper.EditedNode = editedNode;
        }
        private void EvtScrCollapseAll_Click(object sender, EventArgs e)
        {
            treeViewWrapper.CollapseAll();
            UpdateCommandData();
        }
        private void EvtScrExpandAll_Click(object sender, EventArgs e)
        {
            treeViewWrapper.ExpandAll();
            UpdateCommandData();
        }
        private void EvtScrClearAll_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
            "You are about to clear the current script of all commands.\n\nGo ahead with process?",
            "LAZY SHELL", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

            if (result != DialogResult.Yes) return;

            treeViewWrapper.ClearAll();
            UpdateCommandData();
            Do.AddHistory(this, index, "ClearAll");
        }
        private void EventPreview_Click(object sender, EventArgs e)
        {
            PreviewEventOrAction();
        }
        // GUI command editor
        private void categories_es_SelectedIndexChanged(object sender, EventArgs e)
        {
            isActionSelected = false;
            commands.Items.Clear();
            commands.Items.AddRange(Lists.EventListBoxNames(categories_es.SelectedIndex));
            commands.SelectedIndex = 0;
        }
        private void categories_aq_SelectedIndexChanged(object sender, EventArgs e)
        {
            isActionSelected = true;
            commands.Items.Clear();
            commands.Items.AddRange(Lists.ActionListBoxNames(categories_aq.SelectedIndex));
            commands.SelectedIndex = 0;
        }
        private void commands_SelectedIndexChanged(object sender, EventArgs e)
        {
            byte[] temp;
            int opcode;
            int option;

            if (!isActionSelected)
            {
                opcode = Lists.EventListBoxOpcodes[categories_es.SelectedIndex][commands.SelectedIndex];
                option = Lists.EventListBoxFDOpcodes[categories_es.SelectedIndex][commands.SelectedIndex];
                temp = new byte[ScriptEnums.GetEventOpcodeLength(opcode, option)];
                temp[0] = (byte)opcode;
                if (temp.Length > 1)
                    temp[1] = (byte)option;
                esc = new EventScriptCommand(temp, 0);
                aqc = null;
            }
            else
            {
                opcode = Lists.ActionListBoxOpcodes[categories_aq.SelectedIndex][commands.SelectedIndex];
                option = Lists.ActionListBoxFDOpcodes[categories_aq.SelectedIndex][commands.SelectedIndex];
                temp = new byte[ScriptEnums.GetActionQueueOpcodeLength(opcode, option)];
                temp[0] = (byte)opcode;
                if (temp.Length > 1)
                    temp[1] = (byte)option;
                aqc = new ActionQueueCommand(temp, 0);
            }

            editedNode = null;  // the COMMAND PROPERTIES panel now contains a new node instead (2008-11-09)
            ResetAllEventControls();
            if (!isActionSelected)
                ControlEventDisasmMethod();
            else
                ControlActionDisasmMethod();
            buttonInsertEvent.Enabled = true;
            buttonApplyEvent.Enabled = false;
        }
        private void button1_CheckedChanged(object sender, EventArgs e)
        {
            if (button1.Checked)
            {
                categories_aq.BringToFront();
                categories_aq.SelectedIndex = 0;
                categories_aq_SelectedIndexChanged(null, null);
            }
            else
            {
                categories_es.BringToFront();
                categories_es.SelectedIndex = 0;
                categories_es_SelectedIndexChanged(null, null);
            }
        }
        private void evtNameA_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!updatingControls) return;

            if (aqc != null)
            {
                switch (aqc.Opcode)
                {
                    case 0xF2:
                    case 0xF3:
                    case 0xF8:
                        evtNumA.Value = evtNameA.SelectedIndex;  // Level names
                        break;
                }
            }
            else
            {
                switch (esc.Opcode)
                {
                    case 0xF2:
                    case 0xF3:
                    case 0xF8:
                    case 0x68:
                    case 0x6A:
                    case 0x6B:
                    case 0x60:
                    case 0x62:
                        evtNumA.Value = evtNameA.SelectedIndex;  // Level names, Dialogue names
                        break;
                    case 0x50:
                    case 0x51:
                        evtNumA.Value = Model.ItemNames.GetNumFromIndex(evtNameA.SelectedIndex);    // Item names
                        break;
                    case 0x4E:
                        updatingControls = false;

                        labelEvtB.Text = "";
                        labelEvtC.Text = "";
                        evtNameB.Items.Clear(); evtNameB.ResetText(); evtNameB.Enabled = false;
                        evtNumB.Value = 0; evtNumB.Enabled = false;
                        evtNumC.Value = 0; evtNumC.Maximum = 255; evtNumC.Enabled = false;
                        switch (evtNameA.SelectedIndex)
                        {
                            case 2: // open world map point
                                labelEvtB.Text = "map point";
                                evtNameB.Items.Clear(); evtNameB.Items.AddRange(Lists.Numerize(Lists.MapNames)); evtNameB.Enabled = true;

                                evtNameB.SelectedIndex = 0;
                                break;
                            case 3: // open shop menu
                                labelEvtC.Text = "shop menu";
                                evtNumC.Maximum = 32; evtNumC.Enabled = true;
                                break;
                            case 5: // items maxed out
                                labelEvtB.Text = "toss item";
                                evtNameB.Items.Clear(); evtNameB.Items.AddRange(Model.ItemNames.GetNames()); evtNameB.Enabled = true;
                                evtNumB.Enabled = true;

                                evtNameB.SelectedIndex = Model.ItemNames.GetIndexFromNum((int)evtNumB.Value);
                                break;
                            case 7: // menu tutorial
                                labelEvtB.Text = "tutorial";
                                evtNameB.Items.Clear(); evtNameB.Items.AddRange(new string[] { "How to equip", "How to use items", "How to switch allies", "How to play beetle mania" });
                                evtNameB.Enabled = true;

                                evtNameB.SelectedIndex = 0;
                                break;
                            case 16:    // world map event
                                labelEvtB.Text = "map event";
                                evtNameB.Items.Clear(); evtNameB.Items.AddRange(new string[] { "Mario falls to pipehouse", "Mario returns to MK", "Mario takes Nimbus bus" });
                                evtNameB.Enabled = true;

                                evtNameB.SelectedIndex = 0;
                                break;
                        }

                        updatingControls = true;
                        break;
                    case 0x97:
                        if (evtNameA.SelectedIndex == 0) { labelEvtC.Text = "slow down"; evtNumC.Maximum = 160; }
                        else { labelEvtC.Text = "speed up"; evtNumC.Maximum = 94; }
                        break;
                    case 0xFD:
                        switch (esc.Option)
                        {
                            case 0x58:
                                evtNumA.Value = Model.ItemNames.GetNumFromIndex(evtNameA.SelectedIndex);    // Item names
                                break;
                        }
                        break;
                }
            }
        }
        private void evtNumA_ValueChanged(object sender, EventArgs e)
        {
            if (!updatingControls) return;

            if (aqc != null)
            {
                switch (aqc.Opcode)
                {
                    case 0xF2:
                    case 0xF3:
                    case 0xF8:
                        evtNameA.SelectedIndex = (int)evtNumA.Value;  // Level names, Dialogue names
                        break;
                }
            }
            else
            {
                switch (esc.Opcode)
                {
                    case 0xF2:
                    case 0xF3:
                    case 0xF8:
                    case 0x68:
                    case 0x6A:
                    case 0x6B:
                    case 0x60:
                    case 0x62:
                        evtNameA.SelectedIndex = (int)evtNumA.Value;  // Level names, Dialogue names
                        break;
                    case 0x50:
                    case 0x51:
                        evtNameA.SelectedIndex = Model.ItemNames.GetIndexFromNum((int)evtNumA.Value);    // Item names
                        break;
                }
            }
        }
        private void evtNameB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!updatingControls) return;

            if (aqc == null)
            {
                switch (esc.Opcode)
                {
                    case 0x54:
                    case 0x4E:
                        evtNumB.Value = Model.ItemNames.GetNumFromIndex(evtNameB.SelectedIndex);    // Item names
                        break;
                    case 0x4A:
                        evtNumB.Value = evtNameB.SelectedIndex; // battlefields
                        break;
                    default:
                        if (esc.Opcode <= 0x2F)
                        {
                            labelEvtC.Text = "";
                            labelTitleB.Text = "";
                            evtNumC.Value = 0; evtNumC.Maximum = 255; evtNumC.Enabled = false;
                            evtEffects.Items.Clear(); evtEffects.Enabled = false;
                            if (evtNameB.SelectedIndex < 3) // queue options need sync bit
                            {
                                labelTitleB.Text = "properties...";
                                evtEffects.Items.AddRange(new string[] { "asynchronous" }); evtEffects.Enabled = true;
                            }
                            else if (evtNameB.SelectedIndex >= 3 && evtNameB.SelectedIndex <= 6) // options 0xF2-0xF5
                            {
                                labelEvtC.Text = "action #";
                                evtNumC.Maximum = 0x3FF; evtNumC.Enabled = true;
                            }
                            else
                            {
                                labelEvtC.Text = "";
                                evtNumC.Enabled = false;
                            }
                        }
                        break;
                }
            }
        }
        private void evtNumB_ValueChanged(object sender, EventArgs e)
        {
            if (!updatingControls) return;

            if (aqc == null)
            {
                switch (esc.Opcode)
                {
                    case 0x54:
                    case 0x4E:
                        evtNameB.SelectedIndex = Model.ItemNames.GetIndexFromNum((int)evtNumB.Value);    // Item names
                        break;
                    case 0x4A:
                        evtNameB.SelectedIndex = (int)evtNumB.Value;    // battlefields
                        break;
                }
            }
        }
        private void evtEffects_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (aqc != null)
            {
                switch (aqc.Opcode)
                {
                    case 0x08:
                        labelEvtD.Text = evtEffects.GetItemChecked(0) ? "mold" : "sequence";
                        break;
                }
            }
        }
        private void buttonInsertEvent_Click(object sender, EventArgs e)
        {
            EventScriptCommand tempEsc;
            // if editing a non-blank script
            if (EventScriptTree.SelectedNode != null)
            {
                // if inserting action queue/script command
                if (EventScriptTree.SelectedNode.Parent != null || isActionScript)
                    InsertActionCommand();
                else
                {
                    tempEsc = (EventScriptCommand)eventScripts[currentScript].Commands[EventScriptTree.SelectedNode.Index];
                    // if adding action queue command to an empty queue trigger
                    if (tempEsc.IsActionQueueTrigger && isActionSelected)
                        InsertActionCommand();
                    // if inserting an event command
                    else InsertEventCommand();
                }
            }
            // if inserting action command to a blank action script
            else if (isActionScript)
                InsertActionCommand();
            // if inserting event command to a blank event script
            else InsertEventCommand();
            if (!isActionScript)
                UpdateEventScriptsFreeSpace();
            else
                UpdateActionScriptsFreeSpace();
            UpdateCommandData();
        }
        private void buttonApplyEvent_Click(object sender, EventArgs e)
        {
            if (editedNode != null)
            {
                if (editedNode.Parent != null || isActionScript)
                {
                    ControlActionAsmMethod();
                    treeViewWrapper.ReplaceNode(aqc);

                    UpdateActionScriptsFreeSpace();
                }
                else
                {
                    ControlEventAsmMethod();
                    treeViewWrapper.ReplaceNode(esc);

                    UpdateEventScriptsFreeSpace();
                }
            }

            UpdateCommandData();

            EvtScrEditCommand_Click(null, null);
            Do.AddHistory(this, index, EventScriptTree.SelectedNode, "EditCommand");
        }
        // menustrip
        private void save_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Assemble();
            Cursor.Current = Cursors.Arrow;
        }
        private void autoPointerUpdate_Click(object sender, EventArgs e)
        {
            if (autoPointerUpdate.Checked)
            {
                if (MessageBox.Show("AutoUpdatePointer maintains pointer references throughout the Event Scripts and Action Scripts. Disabling it can cause unexpected results. Would you like to disable it?", "LAZY SHELL", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    this.autoPointerUpdate.Checked = !this.autoPointerUpdate.Checked;
                }
            }
            else
                this.autoPointerUpdate.Checked = !this.autoPointerUpdate.Checked;

            this.autoPointerUpdate.Checked = this.autoPointerUpdate.Checked;
        }
        private void recalibratePointersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fixPointers = new FixPointers(this, treeViewWrapper);
            fixPointers.ShowDialog();
            if (!apply) return;
            DialogResult result = MessageBox.Show("Pointer recalibration requires saving. Go ahead with process?",
                "LAZY SHELL", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result != DialogResult.Yes)
            {
                apply = false;
                return;
            }
            treeViewWrapper.ScriptDelta += delta;
            EventScriptTree.BeginUpdate();
            treeViewWrapper.RefreshScript();
            EventScriptTree.EndUpdate();
            eventNum_ValueChanged(null, null);

            apply = false;
            if (CalculateEventScriptsLength() >= 0)
                AssembleAllEventScripts();
            else
                MessageBox.Show("There is not enough available space to save the event scripts to.\n\nThe event scripts were not saved.", "LAZY SHELL");
            this.eventScripts = Model.EventScripts;
            InitializeEventScriptsEditor();
        }
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Form about = new About(this);
            //about.ShowDialog(this);
        }
        private void hexViewer_Click(object sender, EventArgs e)
        {
            if (!isActionScript)
            {
                Model.HexViewer.Offset = eventScript.BaseOffset & 0xFFFFF0;
                Model.HexViewer.SelectionStart = (eventScript.BaseOffset & 15) * 3;
            }
            else
            {
                Model.HexViewer.Offset = actionScript.Offset & 0xFFFFF0;
                Model.HexViewer.SelectionStart = (actionScript.Offset & 15) * 3;
            }
            Model.HexViewer.Compare();
            Model.HexViewer.Show();
        }
        // IO elements
        private void exportAllBattleScripts_Click(object sender, EventArgs e)
        {
            //ioElements = new IOElements(this, (int)monsterNumber.Value, "EXPORT BATTLE SCRIPTS...");
            //ioElements.ShowDialog();
        }
        private void exportAllEventScripts_Click(object sender, EventArgs e)
        {
            ioElements = new IOElements(this, index, "EXPORT EVENT SCRIPTS...");
            ioElements.ShowDialog();
        }
        private void exportAllActionScripts_Click(object sender, EventArgs e)
        {
            ioElements = new IOElements(this, index, "EXPORT ACTION SCRIPTS...");
            ioElements.ShowDialog();
        }
        private void importAllBattleScripts_Click(object sender, EventArgs e)
        {
            //ioElements = new IOElements(this, (int)monsterNumber.Value, "IMPORT BATTLE SCRIPTS...");
            //ioElements.ShowDialog();
            //if (ioElements.DialogResult == DialogResult.Cancel)
            //    return;
        }
        private void importAllEventScripts_Click(object sender, EventArgs e)
        {
            ioElements = new IOElements(this, index, "IMPORT EVENT SCRIPTS...");
            ioElements.ShowDialog();
            if (ioElements.DialogResult == DialogResult.Cancel)
                return;
            eventNum_ValueChanged(null, null);
        }
        private void importAllActionScripts_Click(object sender, EventArgs e)
        {
            ioElements = new IOElements(this, index, "IMPORT ACTION SCRIPTS...");
            ioElements.ShowDialog();
            if (ioElements.DialogResult == DialogResult.Cancel)
                return;
            eventNum_ValueChanged(null, null);
        }
        private void clearAllBattleScripts_Click(object sender, EventArgs e)
        {
            //clearElements = new ClearElements(battleScripts, (int)monsterNumber.Value, "CLEAR BATTLE SCRIPTS...");
            //clearElements.ShowDialog();
            //if (clearElements.DialogResult == DialogResult.Cancel)
            //    return;
        }
        private void clearAllEventScripts_Click(object sender, EventArgs e)
        {
            if (!isActionScript)
                clearElements = new ClearElements(eventScripts, index, "CLEAR EVENT SCRIPTS...");
            else
                clearElements = new ClearElements(eventScripts, 0, "CLEAR EVENT SCRIPTS...");
            clearElements.ShowDialog();
            if (clearElements.DialogResult == DialogResult.Cancel)
                return;

            eventNum_ValueChanged(null, null);
        }
        private void clearAllActionScripts_Click(object sender, EventArgs e)
        {
            if (isActionScript)
                clearElements = new ClearElements(actionScripts, index, "CLEAR ACTION SCRIPTS...");
            else
                clearElements = new ClearElements(actionScripts, 0, "CLEAR ACTION SCRIPTS...");
            clearElements.ShowDialog();
            if (clearElements.DialogResult == DialogResult.Cancel)
                return;

            eventNum_ValueChanged(null, null);
        }
        private void importEventScriptsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int length = eventScript.ScriptLength;
            new IOElements((Element[])Model.EventScripts, index, "IMPORT EVENT SCRIPTS...").ShowDialog();
            treeViewWrapper.ScriptDelta += eventScript.ScriptLength - length;
            treeViewWrapper.RefreshScript();
            treeViewWrapper.ChangeScript(eventScript);
        }
        private void importActionScriptsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int length = actionScript.ActionQueueLength;
            new IOElements((Element[])Model.ActionScripts, index, "IMPORT ACTION SCRIPTS...").ShowDialog();
            treeViewWrapper.ScriptDelta += actionScript.ActionQueueLength - length;
            treeViewWrapper.RefreshScript();
            treeViewWrapper.ChangeScript(actionScript);
        }
        private void exportEventScriptsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new IOElements((Element[])Model.EventScripts, index, "EXPORT EVENT SCRIPTS...").ShowDialog();
        }
        private void exportActionScriptsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new IOElements((Element[])Model.ActionScripts, index, "EXPORT ACTION SCRIPTS...").ShowDialog();
        }
        private void dumpEventScriptTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.FileName = Model.GetFileNameWithoutPath() + " - eventScripts.txt";
            saveFileDialog.RestoreDirectory = true;

            ArrayList scriptCmds;
            ArrayList actionQueues;
            EventScriptCommand esc;
            ActionQueueCommand aqc;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                StreamWriter evtscr = File.CreateText(saveFileDialog.FileName);

                for (int i = 0; i < eventScripts.Length; i++)
                {
                    scriptCmds = eventScripts[i].Commands;

                    evtscr.WriteLine("[" + i.ToString("d4") + "]" +
                        "------------------------------------------------------------>");
                    for (int j = 0; j < scriptCmds.Count; j++)
                    {
                        esc = (EventScriptCommand)scriptCmds[j];
                        evtscr.Write((esc.Offset).ToString("X6") + ": ");

                        if (esc.Opcode <= 0x2F && esc.Option <= 0xF1 && !esc.IsDummy)
                        {
                            if (esc.Option == 0xF0 || esc.Option == 0xF1)
                                evtscr.Write("{" + BitConverter.ToString(esc.EventData, 0, 3) + "}            ");
                            else
                                evtscr.Write("{" + BitConverter.ToString(esc.EventData, 0, 2) + "}               ");

                            evtscr.Write(esc.ToString() + "\n");

                            if (esc.EmbeddedActionQueue.Commands != null)
                            {
                                actionQueues = esc.EmbeddedActionQueue.Commands;
                                for (int k = 0; k < actionQueues.Count; k++)
                                {
                                    aqc = (ActionQueueCommand)actionQueues[k];
                                    evtscr.Write("   " + (aqc.Offset).ToString("X6") + ": ");
                                    evtscr.Write("{" + BitConverter.ToString(aqc.EventData) + "}");
                                    for (int l = aqc.QueueLength; l < 7; l++)
                                        evtscr.Write("   ");
                                    evtscr.Write(aqc.ToString() + "\n");
                                }
                            }
                        }
                        else if (esc.IsDummy)   // 0xd01 and 0xe91 only
                        {
                            evtscr.Write("NON-EMBEDDED ACTION QUEUE\n");
                            if (esc.EmbeddedActionQueue.Commands != null)
                            {
                                actionQueues = esc.EmbeddedActionQueue.Commands;
                                for (int k = 0; k < actionQueues.Count; k++)
                                {
                                    aqc = (ActionQueueCommand)actionQueues[k];
                                    evtscr.Write("   " + (aqc.Offset).ToString("X6") + ": ");
                                    evtscr.Write("{" + BitConverter.ToString(aqc.EventData) + "}");
                                    for (int l = aqc.QueueLength; l < 7; l++)
                                        evtscr.Write("   ");
                                    evtscr.Write(aqc.ToString() + "\n");
                                }
                            }
                        }
                        else
                        {
                            evtscr.Write("{" + BitConverter.ToString(esc.EventData) + "}");
                            for (int k = esc.EventLength; k < 7; k++)
                                evtscr.Write("   ");

                            evtscr.Write(esc.ToString() + "\n");
                        }
                    }
                    evtscr.Write("\n");
                }
                evtscr.Close();
            }
        }
        private void dumpActionScriptTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.FileName = Model.GetFileNameWithoutPath() + " - actionScripts.txt";
            saveFileDialog.RestoreDirectory = true;

            ArrayList scriptCmds;
            ActionQueueCommand aqc;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                StreamWriter actScr = File.CreateText(saveFileDialog.FileName);

                for (int i = 0; i < actionScripts.Length; i++)
                {
                    scriptCmds = actionScripts[i].Commands;

                    actScr.WriteLine("[" + i.ToString("d4") + "]" +
                        "------------------------------------------------------------>");

                    if (scriptCmds != null)
                    {
                        for (int k = 0; k < scriptCmds.Count; k++)
                        {
                            aqc = (ActionQueueCommand)scriptCmds[k];
                            actScr.Write((aqc.Offset).ToString("X6") + ": ");
                            actScr.Write("{" + BitConverter.ToString(aqc.EventData) + "}");
                            for (int l = aqc.QueueLength; l < 7; l++)
                                actScr.Write("   ");
                            actScr.Write(aqc.ToString() + "\n");
                        }
                    }
                    actScr.Write("\n");
                }
                actScr.Close();
            }
        }
        private void clearEventScriptsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ClearElements(Model.EventScripts, index, "CLEAR EVENT SCRIPTS...").ShowDialog();
            eventNum_ValueChanged(null, null);
        }
        private void clearActionScriptsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ClearElements(Model.ActionScripts, index, "CLEAR ACTION SCRIPTS...").ShowDialog();
            eventNum_ValueChanged(null, null);
        }
        private void reset_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("You're about to undo all changes to the current script. Go ahead with reset?",
                "LAZY SHELL", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;
            int length;
            if (!isActionScript)
            {
                length = eventScript.ScriptLength;
                eventScript = new EventScript(Model.Data, index);
                treeViewWrapper.ScriptDelta += eventScript.ScriptLength - length;
                treeViewWrapper.RefreshScript();
                treeViewWrapper.ChangeScript(eventScript);
            }
            else
            {
                length = actionScript.ActionQueueLength;
                actionScript = new ActionQueue(Model.Data, index);
                treeViewWrapper.ScriptDelta += actionScript.ActionQueueLength - length;
                treeViewWrapper.RefreshScript();
                treeViewWrapper.ChangeScript(actionScript);
            }
        }
        // context menustrip
        private void goToDialogue_Click(object sender, EventArgs e)
        {
            if (EventScriptTree.SelectedNode == null) return;

            EventScriptCommand temp = (EventScriptCommand)EventScriptTree.SelectedNode.Tag;
            int num = Bits.GetShort(temp.EventData, 1) & 0xFFF;

            if (Model.Program.Dialogues == null || !Model.Program.Dialogues.Visible)
                Model.Program.CreateDialoguesWindow();

            Model.Program.Dialogues.DialogueNum.Value = num;
            Model.Program.Dialogues.BringToFront();
        }
        private void addMemoryToNotesDatabase_Click(object sender, EventArgs e)
        {
            if (EventScriptTree.SelectedNode == null) return;

            int address = 0x7000;
            int addressBit = 0;
            string label = "";
            string description = "";
            if (EventScriptTree.SelectedNode.Tag.GetType() == typeof(EventScriptCommand))
            {
                EventScriptCommand temp = (EventScriptCommand)EventScriptTree.SelectedNode.Tag;
                if (temp.Opcode >= 0xA0 && temp.Opcode <= 0xA2)
                    address = ((((temp.Opcode * 0x100) + temp.Option) - 0xA000) / 8) + 0x7040;
                if (temp.Opcode >= 0xA4 && temp.Opcode <= 0xA6)
                    address = ((((temp.Opcode * 0x100) + temp.Option) - 0xA400) / 8) + 0x7040;
                if (temp.Opcode >= 0xD8 && temp.Opcode <= 0xDA)
                    address = ((((temp.Opcode * 0x100) + temp.Option) - 0xD800) / 8) + 0x7040;
                if (temp.Opcode >= 0xDC && temp.Opcode <= 0xDE)
                    address = ((((temp.Opcode * 0x100) + temp.Option) - 0xDC00) / 8) + 0x7040;
                addressBit = temp.Option & 0x07;
                if (temp.Option == 0xFD)
                {
                    if (temp.Option >= 0xA0 && temp.Option <= 0xA2)
                        address = ((((temp.Option * 0x100) + temp.EventData[2]) - 0xA000) / 8) + 0x7040;
                    if (temp.Option >= 0xA4 && temp.Option <= 0xA6)
                        address = ((((temp.Option * 0x100) + temp.EventData[2]) - 0xA400) / 8) + 0x7040;
                    if (temp.Option >= 0xD8 && temp.Option <= 0xDA)
                        address = ((((temp.Option * 0x100) + temp.EventData[2]) - 0xD800) / 8) + 0x7040;
                    if (temp.Option >= 0xDC && temp.Option <= 0xDE)
                        address = ((((temp.Option * 0x100) + temp.EventData[2]) - 0xDC00) / 8) + 0x7040;
                    addressBit = temp.EventData[2] & 0x07;
                }
            }
            else
            {
                ActionQueueCommand temp = (ActionQueueCommand)EventScriptTree.SelectedNode.Tag;
                if (temp.Opcode >= 0xA0 && temp.Opcode <= 0xA2)
                    address = ((((temp.Opcode * 0x100) + temp.Option) - 0xA000) / 8) + 0x7040;
                if (temp.Opcode >= 0xA4 && temp.Opcode <= 0xA6)
                    address = ((((temp.Opcode * 0x100) + temp.Option) - 0xA400) / 8) + 0x7040;
                if (temp.Opcode >= 0xD8 && temp.Opcode <= 0xDA)
                    address = ((((temp.Opcode * 0x100) + temp.Option) - 0xD800) / 8) + 0x7040;
                if (temp.Opcode >= 0xDC && temp.Opcode <= 0xDE)
                    address = ((((temp.Opcode * 0x100) + temp.Option) - 0xDC00) / 8) + 0x7040;
                addressBit = temp.Option & 0x07;
            }

            label = description = "[" + address.ToString("X4") + ", bit: " + addressBit.ToString() + "]";

            if (Model.Program.Notes == null || !Model.Program.Notes.Visible)
                Model.Program.CreateNotesWindow();
            Notes note = Model.Program.Notes;
            if (note.ThisNotes == null)
                note.LoadNotes();
            if (note.ThisNotes != null)
            {
                note.AddingFromEditor(7, address, addressBit, label, description);
                note.BringToFront();
            }
            else
            {
                MessageBox.Show("Could not add element to notes database.", "LAZY SHELL",
                    MessageBoxButtons.OK);
            }
        }
        private void addThisToNotesDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void goToEvent_Click(object sender, EventArgs e)
        {
            if (EventScriptTree.SelectedNode == null) return;

            EventScriptCommand temp = (EventScriptCommand)EventScriptTree.SelectedNode.Tag;
            int num = Bits.GetShort(temp.EventData, 1) & 0xFFF;

            eventNum.Value = num;
        }
        private void goToOffset_Click(object sender, EventArgs e)
        {
            if (EventScriptTree.SelectedNode == null) return;
            EventActionCommand temp = (EventActionCommand)EventScriptTree.SelectedNode.Tag;
            int pointer;

            if (isActionScript)
            {
                pointer = temp.ReadPointer() + (actionScript.Offset & 0xFF0000);
                foreach (ActionQueue script in actionScripts)
                {
                    foreach (ActionQueueCommand action in script.Commands)
                    {
                        if (action.Offset + action.EventData.Length > pointer || action.Offset >= pointer)
                        {
                            index = script.Index;
                            treeViewWrapper.SelectNode(action);
                            return;
                        }
                    }
                }
                return;
            }

            pointer = temp.ReadPointer() + (eventScript.BaseOffset & 0xFF0000);
            foreach (EventScript script in eventScripts)
            {
                foreach (EventScriptCommand command in script.Commands)
                {
                    if (command.EmbeddedActionQueue != null)
                    {
                        foreach (ActionQueueCommand action in command.EmbeddedActionQueue.Commands)
                        {
                            if (action.Offset + action.EventData.Length > pointer || action.Offset >= pointer)
                            {
                                if (command.Offset + command.EventLength > pointer || command.Offset >= pointer)
                                {
                                    index = script.Index;
                                    treeViewWrapper.SelectNode(command);
                                    return;
                                }
                                index = script.Index;
                                treeViewWrapper.SelectNode(action);
                                return;
                            }
                        }
                    }
                    if (command.Offset + command.EventLength > pointer || command.Offset >= pointer)
                    {
                        index = script.Index;
                        treeViewWrapper.SelectNode(command);
                        return;
                    }
                }
            }
        }
        private void goToAction_Click(object sender, EventArgs e)
        {
            if (EventScriptTree.SelectedNode == null) return;

            int num = index;
            if (EventScriptTree.SelectedNode.Tag.GetType() == typeof(EventScriptCommand))
            {
                EventScriptCommand temp = (EventScriptCommand)EventScriptTree.SelectedNode.Tag;
                num = Bits.GetShort(temp.EventData, 2);
            }
            else
            {
                ActionQueueCommand temp = (ActionQueueCommand)EventScriptTree.SelectedNode.Tag;
                num = Bits.GetShort(temp.EventData, 1);
            }
            disableNavigate = true;
            type = 1;
            disableNavigate = false;
            eventNum.Value = num;
        }
        #endregion
    }
}
