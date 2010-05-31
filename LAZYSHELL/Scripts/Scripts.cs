using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using LAZYSHELL.Properties;
using LAZYSHELL.ScriptsEditor;
using LAZYSHELL.ScriptsEditor.Commands;

namespace LAZYSHELL.ScriptsEditor
{
    public partial class Scripts : Form
    {
        #region Variables
        private Model model; public Model Model { get { return model; } }
        //private Notes notes;
        private Settings settings;
        private byte[] data;
        private ScriptsModel scriptsModel; public ScriptsModel ScriptsModel { get { return scriptsModel; } }
        private bool updatingProperties = false;
        private bool updatingScript = true;
        private bool actionScript = false;
        private bool actionSelected = false;
        private UniversalVariables universal;
        private State state;

        // externally accessed controls
        public NumericUpDown EventNum { get { return EventNumber; } set { EventNumber = value; } }
        public ComboBox EventName { get { return eventName; } set { eventName = value; } }
        public NumericUpDown MonsterNumber { get { return monsterNumber; } set { monsterNumber = value; } }
        public TabControl TabControlScripts { get { return tabControlScripts; } set { tabControlScripts = value; } }

        // pointer recalibration
        private FixPointers fixPointers;
        private bool apply; public bool Apply { get { return apply; } set { apply = value; } }
        private int delta; public int Delta { get { return delta; } set { delta = value; } }

        private ClearElements clearElements;
        private ImportExportElements ioElements;
        #endregion

        public Scripts(Model model)
        {
            this.model = model;
            this.data = model.Data;
            this.state = State.Instance;
            this.universal = state.Universal;
            this.settings = Settings.Default;

            model.CreateScriptsModel();

            this.scriptsModel = model.ScriptsModel;
            this.battleScripts = scriptsModel.BattleScripts;
            this.eventScripts = scriptsModel.EventScripts;
            this.actionScripts = scriptsModel.ActionScripts;

            this.animationScripts = scriptsModel.SpellAnimMonsters;

            VerifyScriptStats();

            InitializeComponent();

            foreach (Control c in this.Controls)
            {
                c.MouseMove += new MouseEventHandler(controlMouseMove);
                SetEventHandlers(c);
            }

            monsterName.Items.AddRange(universal.MonsterNames.GetNames());
            monsterName.SelectedIndex = universal.MonsterNames.GetIndexFromNum((int)monsterNumber.Value);

            InitializeScriptEditor();
        }

        #region Methods
        private void InitializeScriptEditor()
        {
            InitializeBattleScriptsEditor();
            InitializeEventScriptsEditor();
            InitializeAnimationScriptsEditor();
        }

        private void VerifyScriptStats()
        {
            // Get all the stats
            try
            {
                // If any of these throws an exception, refresh all the universal data Scripts uses
                DDlistName test = universal.AttackNames;
                test = universal.ItemNames;
                test = universal.MonsterNames;
                test = universal.SpellNames;
                BattleDialogue[] sbd = universal.BattleDialogues;
                Dialogue[] sd = universal.Dialogues;
            }
            catch (Exception ex)
            {
                // Create the Stats Model
                if (model.StatsModel == null)
                    model.CreateStatsModel();
                this.universal.MonsterNames = new DDlistName(model.StatsModel.Monsters);
                this.universal.SpellNames = new DDlistName(model.StatsModel.Spells);
                this.universal.AttackNames = new DDlistName(model.StatsModel.Attacks);
                this.universal.ItemNames = new DDlistName(model.StatsModel.Items);

                if (model.SpriteModel == null)
                    model.CreateSpritesModel();
                this.universal.BattleDialogues = model.SpriteModel.BattleDialogues;
                this.universal.Dialogues = model.SpriteModel.Dialogues;
            }

            targetNames = GetTargetNames();
            battleEventNames = GetBattleEventNames();

        }
        private void UpdateCommandData()
        {
            this.eventHexText.Text = BitConverter.ToString(treeViewWrapper.CurrentNodeData);

            if (!actionScript)
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
        private void SelectAllNodes(TreeNodeCollection nodes, bool selected)
        {
            foreach (TreeNode tn in nodes)
            {
                tn.Checked = selected;
                SelectAllNodes(tn.Nodes, selected);
            }
        }

        private Bitmap DrawImageFromIntArr(int[] arr, int width, int height)
        {
            Bitmap image = null;
            unsafe
            {
                fixed (void* firstPixel = &arr[0])
                {
                    IntPtr ip = new IntPtr(firstPixel);
                    if (image != null)
                        image.Dispose();
                    image = new Bitmap(width, height, width * 4, System.Drawing.Imaging.PixelFormat.Format32bppPArgb, ip);

                }
            }
            return image;
        }

        private string GetDirectoryPath(string caption)
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();

            folderBrowserDialog1.SelectedPath = settings.LastDirectory;
            folderBrowserDialog1.Description = caption;

            // Display the openFile dialog.
            DialogResult result = folderBrowserDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                settings.LastDirectory = folderBrowserDialog1.SelectedPath;
                return folderBrowserDialog1.SelectedPath;
            }
            else
                return null;
        }
        private bool CreateDir(string dir)
        {
            DirectoryInfo di = new DirectoryInfo(dir);

            try
            {
                if (!di.Exists)
                {
                    di.Create();
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sorry, there was an error trying to create the directory : " + dir, "Error");
                return false;
            }
        }
        private string SelectFile(string title, string filter)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = settings.LastRomPath;
            openFileDialog1.Title = title;
            openFileDialog1.Filter = filter;
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() != DialogResult.Cancel)
                return openFileDialog1.FileName;
            return null;
        }

        public void Assemble()
        {
            if (!actionScript)
                UpdateScriptOffsets();
            else
                UpdateActionOffsets();
            // Save current script first

            if (!model.AssembleScripts)
                return;
            if (model.AssembleFinal)
                model.AssembleScripts = false;

            settings.Save();

            if (CalculateBattleScriptsLength() >= 0)
                this.scriptsModel.AssembleAllBattleScripts();
            else
                MessageBox.Show("There is not enough available space to save the battle scripts to.\n\nThe battle scripts were not saved.", "LAZY SHELL");

            if (CalculateEventScriptsLength() >= 0)
                this.scriptsModel.AssembleAllEventScripts();
            else
                MessageBox.Show("There is not enough available space to save the event scripts to.\n\nThe event scripts were not saved.", "LAZY SHELL");

            if (CalculateActionScriptsLength() >= 0)
                this.scriptsModel.AssembleAllActionScripts();
            else
                MessageBox.Show("There is not enough available space to save the action scripts to.\n\nThe action scripts were not saved.", "LAZY SHELL");

        }

        private void SetEventHandlers(Control control)
        {
            foreach (Control c in control.Controls)
            {
                c.MouseMove += new MouseEventHandler(controlMouseMove);
                SetEventHandlers(c);
            }
        }
        #endregion

        #region Event Handlers

        private void Scripts_FormClosed(object sender, FormClosedEventArgs e)
        {
            GC.Collect();
        }
        private void Scripts_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.tabControlScripts.SelectedIndex == 0 && !panel11.Enabled)
                return;
            if (!BattleScriptTree.Focused && !EventScriptTree.Focused)
                return;

            if (this.tabControlScripts.SelectedIndex == 0)
            {
                switch (e.KeyData)
                {
                    case Keys.Control | Keys.A: SelectAllNodes(EventScriptTree.Nodes, true); break;
                    case Keys.Control | Keys.D: SelectAllNodes(EventScriptTree.Nodes, false); break;
                    case Keys.Control | Keys.C: EvtScrCopyCommand_Click(null, null); break;
                    case Keys.Control | Keys.V: EvtScrPasteCommand_Click(null, null); break;
                    case Keys.Control | Keys.Up: EvtScrMoveUp_Click(null, null); break;
                    case Keys.Control | Keys.Down: EvtScrMoveDown_Click(null, null); break;
                    case Keys.Delete: EvtScrDeleteCommand_Click(null, null); break;
                }
            }
            else
            {
                switch (e.KeyData)
                {
                    case Keys.Control | Keys.A: SelectAllNodes(BattleScriptTree.Nodes, true); break;
                    case Keys.Control | Keys.D: SelectAllNodes(BattleScriptTree.Nodes, false); break;
                    case Keys.Control | Keys.C: BatScrCopyCommand_Click(null, null); break;
                    case Keys.Control | Keys.V: BatScrPasteCommand_Click(null, null); break;
                    case Keys.Control | Keys.Up: BatScrMoveUp_Click(null, null); break;
                    case Keys.Control | Keys.Down: BatScrMoveDown_Click(null, null); break;
                    case Keys.Delete: BatScrDeleteCommand_Click(null, null); break;
                }
            }
        }
        private void Scripts_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            DialogResult result;

            if (model.AssembleScripts)
            {
                result = MessageBox.Show("Scripts have not been saved.\n\nWould you like to save changes?", "LAZY SHELL", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    Assemble();
                }
                else if (result == DialogResult.No)
                {
                    Buffer.BlockCopy(animationBank, 0, data, 0x350000, 0x10000);
                    Buffer.BlockCopy(battleBank, 0, data, 0x3A6000, 0xA000);
                }
                else if (result == DialogResult.Cancel)
                {
                    e.Cancel = true;
                    return;
                }
            }
            model.AssembleScripts = false;
            settings.Save();
        }

        private void tabControlScripts_DrawItem(object sender, DrawItemEventArgs e)
        {
            string tabName = this.tabControlScripts.TabPages[e.Index].Text;
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Near;
            Font f = new Font(e.Font, FontStyle.Bold);

            SolidBrush s, b;
            if (e.Index == tabControlScripts.SelectedIndex)
            {
                s = new SolidBrush(SystemColors.ControlDarkDark);
                b = new SolidBrush(SystemColors.Control);
            }
            else
            {
                s = new SolidBrush(Color.FromArgb(236, 232, 224));
                b = new SolidBrush(SystemColors.ControlText);
            }
            Rectangle r = new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height);
            e.Graphics.FillRectangle(s, r);
            r.X += 3; r.Y += 3;
            e.Graphics.DrawString(tabName, f, b, r, sf);
            sf.Dispose();
        }

        private void EventScriptTree_NodeMouseHover(object sender, TreeNodeMouseHoverEventArgs e)
        {

        }
        private void EventScriptTree_MouseDown(object sender, MouseEventArgs e)
        {

        }
        private void EventScriptTree_MouseUp(object sender, MouseEventArgs e)
        {

        }
        private void EventScriptTree_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void saveScriptsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Assemble();
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void dumpTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.FileName = "eventScripts.txt";
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

                            if (esc.EmbeddedActionQueue.ActionQueueCommands != null)
                            {
                                actionQueues = esc.EmbeddedActionQueue.ActionQueueCommands;
                                for (int k = 0; k < actionQueues.Count; k++)
                                {
                                    aqc = (ActionQueueCommand)actionQueues[k];
                                    evtscr.Write("   " + (aqc.Offset).ToString("X6") + ": ");
                                    evtscr.Write("{" + BitConverter.ToString(aqc.QueueData) + "}");
                                    for (int l = aqc.QueueLength; l < 7; l++)
                                        evtscr.Write("   ");
                                    evtscr.Write(aqc.ToString() + "\n");
                                }
                            }
                        }
                        else if (esc.IsDummy)   // 0xd01 and 0xe91 only
                        {
                            evtscr.Write("NON-EMBEDDED ACTION QUEUE\n");
                            if (esc.EmbeddedActionQueue.ActionQueueCommands != null)
                            {
                                actionQueues = esc.EmbeddedActionQueue.ActionQueueCommands;
                                for (int k = 0; k < actionQueues.Count; k++)
                                {
                                    aqc = (ActionQueueCommand)actionQueues[k];
                                    evtscr.Write("   " + (aqc.Offset).ToString("X6") + ": ");
                                    evtscr.Write("{" + BitConverter.ToString(aqc.QueueData) + "}");
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

            // Write the action scripts
            /**/
            saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.FileName = "actionScripts.txt";
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                StreamWriter actScr = File.CreateText(saveFileDialog.FileName);

                for (int i = 0; i < actionScripts.Length; i++)
                {
                    scriptCmds = actionScripts[i].ActionQueueCommands;

                    actScr.WriteLine("[" + i.ToString("d4") + "]" +
                        "------------------------------------------------------------>");

                    if (scriptCmds != null)
                    {
                        for (int k = 0; k < scriptCmds.Count; k++)
                        {
                            aqc = (ActionQueueCommand)scriptCmds[k];
                            actScr.Write((aqc.Offset).ToString("X6") + ": ");
                            actScr.Write("{" + BitConverter.ToString(aqc.QueueData) + "}");
                            for (int l = aqc.QueueLength; l < 7; l++)
                                actScr.Write("   ");
                            actScr.Write(aqc.ToString() + "\n");
                        }
                    }
                    actScr.Write("\n");
                }
                actScr.Close();
            }
            /**/
        }
        private void dumpAnimationTexToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.FileName = "animationScripts.txt";
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() != DialogResult.OK) return;

            int i = 0;
            StreamWriter evtscr = File.CreateText(saveFileDialog.FileName);
            evtscr.WriteLine("**************");
            evtscr.WriteLine("MONSTER SPELLS");
            evtscr.WriteLine("**************\n");
            foreach (AnimationScript ans in scriptsModel.SpellAnimMonsters)
            {
                evtscr.WriteLine("\nMONSTER SPELL [" + i.ToString("d3") + "]" +
                    "------------------------------------------------------------>\n");
                foreach (AnimationScriptCommand asc in ans.Commands)
                {
                    evtscr.Write((asc.Offset).ToString("X6") + ": ");
                    evtscr.Write("{" + BitConverter.ToString(asc.AnimationData) + "}\n");

                    dumpAnimationLoop(asc, evtscr, 1);
                }
                i++;
            }
            i = 0;
            evtscr.WriteLine("\n***********");
            evtscr.WriteLine("ALLY SPELLS");
            evtscr.WriteLine("***********\n");
            foreach (AnimationScript ans in scriptsModel.SpellAnimAllies)
            {
                evtscr.WriteLine("\nALLY SPELL [" + i.ToString("d3") + "]" +
                    "------------------------------------------------------------>\n");
                foreach (AnimationScriptCommand asc in ans.Commands)
                {
                    evtscr.Write((asc.Offset).ToString("X6") + ": ");
                    evtscr.Write("{" + BitConverter.ToString(asc.AnimationData) + "}\n");

                    dumpAnimationLoop(asc, evtscr, 1);
                }
                i++;
            }
            i = 0;
            evtscr.WriteLine("\n*******");
            evtscr.WriteLine("ATTACKS");
            evtscr.WriteLine("*******\n");
            foreach (AnimationScript ans in scriptsModel.AttackAnimations)
            {
                evtscr.WriteLine("\nATTACK [" + i.ToString("d3") + "]" +
                    "------------------------------------------------------------>\n");
                foreach (AnimationScriptCommand asc in ans.Commands)
                {
                    evtscr.Write((asc.Offset).ToString("X6") + ": ");
                    evtscr.Write("{" + BitConverter.ToString(asc.AnimationData) + "}\n");

                    dumpAnimationLoop(asc, evtscr, 1);
                }
                i++;
            }
            i = 0;
            evtscr.WriteLine("\n*****");
            evtscr.WriteLine("ITEMS");
            evtscr.WriteLine("*****\n");
            foreach (AnimationScript ans in scriptsModel.ItemAnimations)
            {
                evtscr.WriteLine("\nITEM [" + i.ToString("d3") + "]" +
                    "------------------------------------------------------------>\n");
                foreach (AnimationScriptCommand asc in ans.Commands)
                {
                    evtscr.Write((asc.Offset).ToString("X6") + ": ");
                    evtscr.Write("{" + BitConverter.ToString(asc.AnimationData) + "}\n");

                    dumpAnimationLoop(asc, evtscr, 1);
                }
                i++;
            }
            i = 0;
            evtscr.WriteLine("\n*************");
            evtscr.WriteLine("BATTLE EVENTS");
            evtscr.WriteLine("*************\n");
            foreach (AnimationScript ans in scriptsModel.BattleEvents)
            {
                evtscr.WriteLine("\nBATTLE EVENT [" + i.ToString("d3") + "]" +
                    "------------------------------------------------------------>\n");
                foreach (AnimationScriptCommand asc in ans.Commands)
                {
                    evtscr.Write((asc.Offset).ToString("X6") + ": ");
                    evtscr.Write("{" + BitConverter.ToString(asc.AnimationData) + "}\n");

                    dumpAnimationLoop(asc, evtscr, 1);
                }
                i++;
            }
            i = 0;
            evtscr.WriteLine("\n*********");
            evtscr.WriteLine("BEHAVIORS");
            evtscr.WriteLine("*********\n");
            foreach (AnimationScript ans in scriptsModel.BehaviorAnimations)
            {
                evtscr.WriteLine("\nBEHAVIOR [" + i.ToString("d3") + "]" +
                    "------------------------------------------------------------>\n");
                foreach (AnimationScriptCommand asc in ans.Commands)
                {
                    evtscr.Write((asc.Offset).ToString("X6") + ": ");
                    evtscr.Write("{" + BitConverter.ToString(asc.AnimationData) + "}\n");

                    dumpAnimationLoop(asc, evtscr, 1);
                }
                i++;
            }
            i = 0;
            evtscr.WriteLine("\n*********");
            evtscr.WriteLine("ENTRANCES");
            evtscr.WriteLine("*********\n");
            foreach (AnimationScript ans in scriptsModel.EntranceAnimations)
            {
                evtscr.WriteLine("\nENTRANCE [" + i.ToString("d3") + "]" +
                    "------------------------------------------------------------>\n");
                foreach (AnimationScriptCommand asc in ans.Commands)
                {
                    evtscr.Write((asc.Offset).ToString("X6") + ": ");
                    evtscr.Write("{" + BitConverter.ToString(asc.AnimationData) + "}\n");

                    dumpAnimationLoop(asc, evtscr, 1);
                }
                i++;
            }
            i = 0;
            evtscr.WriteLine("\n*******");
            evtscr.WriteLine("WEAPONS");
            evtscr.WriteLine("*******\n");
            foreach (AnimationScript ans in scriptsModel.WeaponAnimations)
            {
                evtscr.WriteLine("\nWEAPON[" + i.ToString("d3") + "]" +
                    "------------------------------------------------------------>\n");
                foreach (AnimationScriptCommand asc in ans.Commands)
                {
                    evtscr.Write((asc.Offset).ToString("X6") + ": ");
                    evtscr.Write("{" + BitConverter.ToString(asc.AnimationData) + "}\n");

                    dumpAnimationLoop(asc, evtscr, 1);
                }
                i++;
            }
        }
        private void dumpAnimationLoop(AnimationScriptCommand com, StreamWriter evtscr, int level)
        {
            foreach (AnimationScriptCommand asc in com.Commands)
            {
                for (int i = 0; i < level; i++)
                    evtscr.Write("\t");

                evtscr.Write((asc.Offset).ToString("X6") + ": ");
                evtscr.Write("{" + BitConverter.ToString(asc.AnimationData) + "}\n");

                dumpAnimationLoop(asc, evtscr, level + 1);
            }
        }
        private void autoPointerUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (state.AutoPointerUpdate)
            {
                if (MessageBox.Show("AutoUpdatePointer maintains pointer references throughout the Event Scripts and Action Scripts. Disabling it can cause unexpected results. Would you like to disable it?", "LAZY SHELL", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    this.state.AutoPointerUpdate = !this.state.AutoPointerUpdate;
                }
            }
            else
                this.state.AutoPointerUpdate = !this.state.AutoPointerUpdate;

            this.autoPointerUpdateToolStripMenuItem.Checked = this.state.AutoPointerUpdate;
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
            EventNumber_ValueChanged(null, null);

            apply = false;
            if (CalculateEventScriptsLength() >= 0)
                this.scriptsModel.AssembleAllEventScripts();
            else
                MessageBox.Show("There is not enough available space to save the event scripts to.\n\nThe event scripts were not saved.", "LAZY SHELL");
            scriptsModel.CreateEventScripts();
            this.eventScripts = scriptsModel.EventScripts;
            InitializeEventScriptsEditor();
        }
        // help menu
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form about = new About(this);
            about.ShowDialog(this);
        }

        // FORM EVENT HANDLERS
        private void exportAllBattleScripts_Click(object sender, EventArgs e)
        {
            ioElements = new ImportExportElements(this, (int)monsterNumber.Value, "EXPORT BATTLE SCRIPTS...");
            ioElements.ShowDialog();
        }
        private void exportAllEventScripts_Click(object sender, EventArgs e)
        {
            ioElements = new ImportExportElements(this, (int)EventNumber.Value, "EXPORT EVENT SCRIPTS...");
            ioElements.ShowDialog();
        }
        private void exportAllActionScripts_Click(object sender, EventArgs e)
        {
            ioElements = new ImportExportElements(this, (int)EventNumber.Value, "EXPORT ACTION SCRIPTS...");
            ioElements.ShowDialog();
        }
        private void importAllBattleScripts_Click(object sender, EventArgs e)
        {
            ioElements = new ImportExportElements(this, (int)monsterNumber.Value, "IMPORT BATTLE SCRIPTS...");
            ioElements.ShowDialog();
            if (ioElements.DialogResult == DialogResult.Cancel)
                return;
            RefreshBattleScriptsEditor();
        }
        private void importAllEventScripts_Click(object sender, EventArgs e)
        {
            ioElements = new ImportExportElements(this, (int)EventNumber.Value, "IMPORT EVENT SCRIPTS...");
            ioElements.ShowDialog();
            if (ioElements.DialogResult == DialogResult.Cancel)
                return;
            EventNumber_ValueChanged(null, null);
        }
        private void importAllActionScripts_Click(object sender, EventArgs e)
        {
            ioElements = new ImportExportElements(this, (int)EventNumber.Value, "IMPORT ACTION SCRIPTS...");
            ioElements.ShowDialog();
            if (ioElements.DialogResult == DialogResult.Cancel)
                return;
            EventNumber_ValueChanged(null, null);
        }
        private void clearAllBattleScripts_Click(object sender, EventArgs e)
        {
            clearElements = new ClearElements(battleScripts, (int)monsterNumber.Value, "CLEAR BATTLE SCRIPTS...");
            clearElements.ShowDialog();
            if (clearElements.DialogResult == DialogResult.Cancel)
                return;
            RefreshBattleScriptsEditor();
        }
        private void clearAllEventScripts_Click(object sender, EventArgs e)
        {
            if (!actionScript)
                clearElements = new ClearElements(eventScripts, (int)EventNumber.Value, "CLEAR EVENT SCRIPTS...");
            else
                clearElements = new ClearElements(eventScripts, 0, "CLEAR EVENT SCRIPTS...");
            clearElements.ShowDialog();
            if (clearElements.DialogResult == DialogResult.Cancel)
                return;

            EventNumber_ValueChanged(null, null);
        }
        private void clearAllActionScripts_Click(object sender, EventArgs e)
        {
            if (actionScript)
                clearElements = new ClearElements(actionScripts, (int)EventNumber.Value, "CLEAR ACTION SCRIPTS...");
            else
                clearElements = new ClearElements(actionScripts, 0, "CLEAR ACTION SCRIPTS...");
            clearElements.ShowDialog();
            if (clearElements.DialogResult == DialogResult.Cancel)
                return;

            EventNumber_ValueChanged(null, null);
        }

        private void controlMouseMove(object sender, MouseEventArgs e)
        {
            if (sender == this) return;

            Control control = (Control)sender;

            //if (enableHelpTipsToolStripMenuItem.Checked)
            //{
            //    if (toolTip1.GetToolTip(control) != "")
            //    {
            //        Control parent = (Control)control.Parent;
            //        Point p = control.Location;
            //        Point l = new Point();
            //        while (parent.Parent != this)
            //        {
            //            p.X += parent.Location.X;
            //            p.Y += parent.Location.Y;
            //            parent = parent.Parent;
            //        }

            //        labelToolTip.Text = toolTip1.GetToolTip(control);
            //        l = new Point(p.X + e.X + 50, p.Y + e.Y + 50);
            //        if (l.X + labelToolTip.Width + 50 > this.Width)
            //            l.X -= labelToolTip.Width + 75;
            //        if (l.Y + labelToolTip.Height + 50 > this.Height)
            //            l.Y -= labelToolTip.Height + 50;
            //        labelToolTip.Location = l;
            //        labelToolTip.BringToFront();
            //        labelToolTip.Visible = true;
            //    }
            //    else
            //        labelToolTip.Visible = false;
            //}
            //else
            //    labelToolTip.Visible = false;

            if (showDecHexToolStripMenuItem.Checked)
            {
                if (control.GetType().Name == "UpDownEdit" || control.GetType().Name == "NumericUpDown")
                {
                    Control parent = (Control)control.Parent;
                    Point p = control.Location;
                    Point l = new Point();
                    while (parent.Parent != this)
                    {
                        p.X += parent.Location.X;
                        p.Y += parent.Location.Y;
                        parent = parent.Parent;
                    }

                    NumericUpDown numericUpDown;
                    if (control.GetType().Name == "UpDownEdit")
                    {
                        Control temp = GetNextControl(control, false);
                        numericUpDown = (NumericUpDown)GetNextControl(temp, false);
                    }
                    else
                        numericUpDown = (NumericUpDown)control;

                    if (numericUpDown.Hexadecimal)
                        labelConvertor.Text = "DEC:  " + ((int)numericUpDown.Value).ToString("d");
                    else
                        labelConvertor.Text = "HEX:  0x" + ((int)numericUpDown.Value).ToString("X4");

                    l = new Point(p.X + e.X + 50, p.Y + e.Y + 50);
                    if (l.X + labelConvertor.Width + 50 > this.Width)
                        l.X -= labelConvertor.Width + 75;
                    if (l.Y + labelConvertor.Height + 50 > this.Height)
                        l.Y -= labelConvertor.Height + 50;
                    labelConvertor.Location = l;
                    labelConvertor.BringToFront();
                    labelConvertor.Visible = true;
                }
                else
                    labelConvertor.Visible = false;
            }
            else
                labelConvertor.Visible = false;
        }

        #endregion
    }
}