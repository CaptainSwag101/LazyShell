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
using SMRPGED.Properties;
using SMRPGED.ScriptsEditor;
using SMRPGED.ScriptsEditor.Commands;

namespace SMRPGED.ScriptsEditor
{
    public partial class Scripts : Form
    {
        #region Variables
        private Model model;
        private Notes notes;
        private Settings settings;
        private byte[] data;
        private ScriptsModel scriptsModel;
        private bool updatingProperties = false;
        private bool updatingScript = true;
        private bool actionScript = false;
        private bool actionSelected = false;
        private UniversalVariables universal;
        private State state;

        // externally accessed controls
        public NumericUpDown EventNum { get { return EventNumber; } set { EventNumber = value; } }
        public ComboBox EventName { get { return eventName; } set { eventName = value; } }
        public TabControl TabControlScripts { get { return tabControlScripts; } set { tabControlScripts = value; } }
        #endregion

        public Scripts(Model model)
        {
            this.model = model;
            this.notes = Notes.Instance;
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

            monsterName.Items.AddRange(universal.MonsterNames.GetNames());
            monsterName.SelectedIndex = universal.MonsterNames.GetIndexFromNum((int)monsterNumber.Value);

            LoadNotes();

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
            catch
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
            catch
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

        // Notes Methods
        private void LoadNotes()
        {
            if (!notes.GetLoadNotes())
            {
                return;
            }
            try
            {
                // Notes load example
                this.BattleScriptNotes.LoadFile(notes.GetPath() + "main-scripts-battle.rtf");
                this.EventScriptNotes.LoadFile(notes.GetPath() + "main-scripts-event.rtf");
            }
            catch
            {
                if (MessageBox.Show("Could not load notes for this ROM, would you like to create a set of notes for it?\nThis will not overwrite any existing notes", "Create Notes?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (notes.CreateNoteSet())
                        LoadNotes();
                }
                else
                {
                    notes.SetLoadNotes(false);
                }

            }
        }
        private void SaveNotes()
        {
            SaveBattleNotes();
            SaveEventNotes();
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

            if (notes.GetLoadNotes())
                SaveNotes();

            settings.Save();

            if (CalculateBattleScriptsLength() >= 0)
                this.scriptsModel.AssembleAllBattleScripts();
            else
                MessageBox.Show("There is not enough available space to save the battle scripts to.\n\nThe battle scripts were not saved.", "WARNING: NOT ENOUGH BATTLE SCRIPT SPACE", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            if (CalculateEventScriptsLength() >= 0)
                this.scriptsModel.AssembleAllEventScripts();
            else
                MessageBox.Show("There is not enough available space to save the event scripts to.\n\nThe event scripts were not saved.", "WARNING: NOT ENOUGH EVENT SCRIPT SPACE", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            if (CalculateActionScriptsLength() >= 0)
                this.scriptsModel.AssembleAllActionScripts();
            else
                MessageBox.Show("There is not enough available space to save the action scripts to.\n\nThe action scripts were not saved.", "WARNING: NOT ENOUGH ACTION SCRIPT SPACE", MessageBoxButtons.OK, MessageBoxIcon.Warning);

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
        private void SelectAllNodes(TreeNodeCollection nodes, bool selected)
        {
            foreach (TreeNode tn in nodes)
            {
                tn.Checked = selected;
                SelectAllNodes(tn.Nodes, selected);
            }
        }
        private void Scripts_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            DialogResult result;

            if (model.AssembleScripts)
            {
                result = MessageBox.Show("Would you like to save changes?", "Save and quit Scripts Editor?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    Assemble();
                }
                else if (result == DialogResult.Cancel)
                {
                    Buffer.BlockCopy(animationBank, 0, data, 0x350000, 0x10000);
                    Buffer.BlockCopy(battleBank, 0, data, 0x3A6000, 0xA000);
                    e.Cancel = true;
                    return;
                }

            }
            model.AssembleScripts = false;

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
        private void scriptsHelpTopicsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form about = new About(this);
            about.ShowDialog(this);
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void dumpTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ArrayList scriptCmds;
            ArrayList actionQueues;
            EventScriptCommand esc;
            ActionQueueCommand aqc;

            StreamWriter evtscr = File.CreateText("EventScripts.log");
            for (int i = 0; i < eventScripts.Length; i++)
            {
                scriptCmds = eventScripts[i].Commands;

                evtscr.WriteLine("[" + i.ToString("X3") + "]" +
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

            // Write the action scripts
            /**/
            StreamWriter actScr = File.CreateText("ActionScripts.log"); ;
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
            /**/
        }
        private void dumpAnimationTexToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int i = 0;
            StreamWriter evtscr = File.CreateText("AnimationScripts.log");
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
                if (MessageBox.Show("AutoUpdatePointer maintains pointer references throughout the Event Scripts and Action Scripts. Disabling it can cause unexpected results. Would you like to disable it?", "Disable AutoPointerUpdate?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    this.state.AutoPointerUpdate = !this.state.AutoPointerUpdate;
                }
            }
            else
                this.state.AutoPointerUpdate = !this.state.AutoPointerUpdate;

            this.autoPointerUpdateToolStripMenuItem.Checked = this.state.AutoPointerUpdate;
        }

        // FORM EVENT HANDLERS
        private void exportCurrentBattleScript_Click(object sender, EventArgs e)
        {
            string path = GetDirectoryPath("Select the directory that you want to export the current Battle Script to.");

            if (path != null)
                ExportBattleScript(this.currentBattleScript, 1, path);
        }
        private void exportAllBattleScripts_Click(object sender, EventArgs e)
        {
            string path = GetDirectoryPath("Select the directory that you want to export the Battle Scripts to.");

            if (path != null)
                ExportBattleScript(0, 256, path);
        }
        private void exportCurrentEventScript_Click(object sender, EventArgs e)
        {
            if (actionScript)
                return;
            string path = GetDirectoryPath("Select the directory that you want to export the current Event Script to.");

            if (path != null)
                ExportEventScript((int)this.EventNumber.Value, 1, path);
        }
        private void exportAllEventScripts_Click(object sender, EventArgs e)
        {
            string path = GetDirectoryPath("Select the directory that you want to export the Event Scripts to.");

            if (path != null)
                ExportEventScript(0, 4096, path);
        }
        private void exportCurrentActionScript_Click(object sender, EventArgs e)
        {
            if (!actionScript)
                return;

            string path = GetDirectoryPath("Select the directory that you want to export the current Action Script to.");

            if (path != null)
                ExportActionScript((int)this.EventNumber.Value, 1, path);
        }
        private void exportAllActionScripts_Click(object sender, EventArgs e)
        {
            string path = GetDirectoryPath("Select the directory that you want to export the Action Scripts to.");

            if (path != null)
                ExportActionScript(0, 1024, path);
        }
        private void importCurrentBattleScript_Click(object sender, EventArgs e)
        {
            string path = SelectFile("Select the Battle Script to import", "Battle Script files (*.dat)|*.dat|All files (*.*)|*.*");

            if (path != null)
                ImportBattleScript(this.currentBattleScript, 1, path);
        }
        private void importAllBattleScripts_Click(object sender, EventArgs e)
        {
            string path = GetDirectoryPath("Select the directory that contains the Battle Scripts to import.");
            if (path != null)
                ImportBattleScript(0, 256, path + "\\");
        }
        private void importCurrentEventScript_Click(object sender, EventArgs e)
        {
            if (actionScript)
                return;

            string path = SelectFile("Select the Event Script to import", "Event Script files (*.dat)|*.dat|All files (*.*)|*.*");

            if (path != null)
                ImportEventScript((int)this.EventNumber.Value, 1, path);

        }
        private void importAllEventScripts_Click(object sender, EventArgs e)
        {
            string path = GetDirectoryPath("Select the directory that contains the Event Scripts to import.");
            if (path != null)
                ImportEventScript(0, 4096, path + "\\");
        }
        private void importCurrentActionScript_Click(object sender, EventArgs e)
        {
            if (!actionScript)
                return;

            string path = SelectFile("Select the Action Script to import", "Action Script files (*.dat)|*.dat|All files (*.*)|*.*");

            if (path != null)
                ImportActionScript((int)this.EventNumber.Value, 1, path);

        }
        private void importAllActionScripts_Click(object sender, EventArgs e)
        {
            string path = GetDirectoryPath("Select the directory that contains the Action Scripts to import.");
            if (path != null)
                ImportActionScript(0, 1024, path + "\\");
        }
        private void clearAllBattleScripts_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "You are about to delete all commands in all battle scripts.\n\nProceed?",
                "CLEAR ALL BATTLE SCRIPTS",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            RemoveAllCommands();
            foreach (BattleScript bs in battleScripts)
                bs.ClearAll();
            UpdateBattleScriptsFreeSpace();
        }
        private void clearAllEventScripts_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "You are about to delete all commands in all event scripts.\n\nProceed?",
                "CLEAR ALL EVENT SCRIPTS",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            treeViewWrapper.ClearAll();
            foreach (EventScript es in eventScripts)
                es.ClearAll();
            UpdateCommandData();
        }
        private void clearAllActionScripts_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
             "You are about to delete all commands in all action scripts.\n\nProceed?",
                "CLEAR ALL ACTION SCRIPTS",
             MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            treeViewWrapper.ClearAll();
            foreach (ActionQueue aq in actionScripts)
                aq.ClearAll();
            UpdateCommandData();
        }
        #endregion
    }
}