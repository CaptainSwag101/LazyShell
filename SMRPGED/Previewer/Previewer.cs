using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Collections;
using SMRPGED.Properties;

namespace SMRPGED.Previewer
{
    public partial class Previewer : Form
    {
        private Settings settings;
        private Model model;
        private string romPath;
        private string emulatorPath = "INVALID";
        private bool rom = false, emulator = false, savestate = false, eventchoice = false, initializing = false;
        private int selectNum;
        private ArrayList eventTriggers;
        private UniversalVariables universal;
        LevelModel levelModel;

        private int behaviour;
        private enum Behaviours
        {
            EventPreviewer,
            LevelPreviewer,
            ActionPreviewer,
            BattlePreviewer
        }
        // 0 = Event Previewer
        // 1 = Level Previewer
        // 2 = Action previewer
        // 3 = Battle previewer
        public Previewer(Model model, int num, int behaviour)
        {
            this.model = model;
            this.settings = Settings.Default;
            this.selectNum = num;
            this.eventTriggers = new ArrayList();
            this.universal = State.Instance.Universal;
            this.behaviour = behaviour;

            if (model.LevelModel == null)
                model.CreateLevelModel();
            this.levelModel = model.LevelModel;

            InitializeComponent();
            InitializePreviewer();

            this.emulator = GetEmulator();
            if (num == 0)
                this.selectNumericUpDown_ValueChanged(null, null);
            UpdateGui();

            if (settings.PreviewFirstTime)
            {
                DialogResult result = MessageBox.Show("The generated Preview ROM should not be used for anything other than Previews.\nDoing so will yield unpredictable results. Do you understand?", "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    settings.PreviewFirstTime = false;
                    settings.Save();
                }
            }
        }
        private void ScanForEvents()
        {
            this.eventTriggers.Clear();
            ScanForEnterEvents();
            ScanForRunEvents();
        }
        private void ScanForEnterEvents()
        {
            foreach (Level lvl in levelModel.Levels)
            {
                if (lvl.LevelEvents.ExitEvent == this.selectNum)
                {
                    ScanForEntrancesToLevel(lvl.LevelNum);
                }
            }
        }
        // Adds all run-event triggers for current eventNum to the eventTrigger arraylist
        private void ScanForRunEvents()
        {
            Entrance ent;
            int save;
            foreach (Level lvl in levelModel.Levels) // For every level
            {
                save = lvl.LevelEvents.CurrentEvent; // Save current index to restore later
                for (int i = 0; i < lvl.LevelEvents.NumberOfEvents; i++) // For every event in each level
                {
                    lvl.LevelEvents.CurrentEvent = i;
                    if (lvl.LevelEvents.RunEvent == this.selectNum)
                    {
                        ent = new Entrance();
                        ent.LevelNum = (ushort)lvl.LevelNum;
                        ent.CoordX = lvl.LevelEvents.FieldCoordX;
                        ent.CoordY = lvl.LevelEvents.FieldCoordY;
                        ent.CoordZ = lvl.LevelEvents.FieldCoordZ;
                        ent.RadialPosition = lvl.LevelEvents.FieldRadialPosition;
                        ent.ShowMessage = false;
                        ent.Flag = false;
                        eventTriggers.Add(ent); // Add the event trigger
                    }
                }
                lvl.LevelEvents.CurrentEvent = save; // Restore current index for this levels events                        
            }
        }
        private void ScanForEntrancesToLevel(int lvlNum)
        {
            Entrance ent;
            int save;

            foreach (Level lvl in levelModel.Levels) // For every level
            {
                save = lvl.LevelExits.CurrentExit; // Save current index to restore later
                for (int i = 0; i < lvl.LevelExits.NumberOfExits; i++) // For every event in each level
                {
                    lvl.LevelExits.CurrentExit = i;
                    if (lvl.LevelExits.Destination == lvlNum) // If this exit points to the level we want
                    {
                        ent = new Entrance();
                        ent.Source = (ushort)lvl.LevelNum;
                        ent.LevelNum = (ushort)lvl.LevelExits.Destination;
                        ent.CoordX = lvl.LevelExits.MarioCoordX;
                        ent.CoordY = lvl.LevelExits.MarioCoordY;
                        ent.CoordZ = lvl.LevelExits.MarioCoordZ;
                        ent.RadialPosition = lvl.LevelExits.MarioRadialPosition;
                        ent.ShowMessage = lvl.LevelExits.ShowMessage;
                        ent.Flag = true; // Indicates an enter event
                        eventTriggers.Add(ent); // Add the event trigger
                    }
                }
                lvl.LevelExits.CurrentExit = save; // Restore current index for this levels events                        
            }

        }
        private void ScanForActionReferences(int actionNum)
        {
            Entrance ent;
            int saveNPC, saveInstance;

            foreach (Level lvl in levelModel.Levels) // For every level
            {
                saveNPC = lvl.LevelNPCs.CurrentNPC;

                for (int i = 0; i < lvl.LevelNPCs.NumberOfNPCs; i++) // For every NPC in each level
                {
                    lvl.LevelNPCs.CurrentNPC = i;
                    if (lvl.LevelNPCs.Movement + lvl.LevelNPCs.PropertyC == actionNum) // If this NPC has our action #
                    {
                        ent = new Entrance();
                        ent.Source = (ushort)lvl.LevelNPCs.NPCID;
                        ent.LevelNum = (ushort)lvl.LevelNum;
                        ent.CoordX = (byte)((lvl.LevelNPCs.CoordX + 2) & 0x3F);
                        ent.CoordY = (byte)((lvl.LevelNPCs.CoordY + 2) & 0x7F);
                        ent.CoordZ = lvl.LevelNPCs.CoordZ;
                        ent.RadialPosition = 7;
                        ent.ShowMessage = false;
                        ent.Flag = true; // Indicates an NPC and not an Instance
                        eventTriggers.Add(ent); // Add the event trigger
                    }

                    saveInstance = lvl.LevelNPCs.CurrentInstance;
                    for (int x = 0; x < lvl.LevelNPCs.NumberOfInstances; x++) // test all instances
                    {
                        lvl.LevelNPCs.CurrentInstance = x;

                        if (lvl.LevelNPCs.Movement + lvl.LevelNPCs.InstancePropertyC == actionNum)
                        {
                            ent = new Entrance();
                            ent.Source = (ushort)lvl.LevelNPCs.NPCID;
                            ent.LevelNum = (ushort)lvl.LevelNum;
                            ent.CoordX = (byte)((lvl.LevelNPCs.InstanceCoordX + 2) & 0x3F);
                            ent.CoordY = (byte)((lvl.LevelNPCs.InstanceCoordY + 2) & 0x7F);
                            ent.CoordZ = lvl.LevelNPCs.InstanceCoordZ;
                            ent.RadialPosition = 7;
                            ent.ShowMessage = false;
                            ent.Flag = false; // Indicates an Instance
                            eventTriggers.Add(ent); // Add the event trigger
                        }
                        lvl.LevelNPCs.CurrentInstance = saveInstance;
                    }

                }
                lvl.LevelNPCs.CurrentNPC = saveNPC;
            }

        }
        private bool ScanFormation(int monsterNum, StatsEditor.Stats.Formation sfm)
        {
            if (sfm.FormationMonster[0] == monsterNum && sfm.FormationUse[0])
                return true;
            else if (sfm.FormationMonster[1] == monsterNum && sfm.FormationUse[1])
                return true;
            else if (sfm.FormationMonster[2] == monsterNum && sfm.FormationUse[2])
                return true;
            else if (sfm.FormationMonster[3] == monsterNum && sfm.FormationUse[3])
                return true;
            else if (sfm.FormationMonster[4] == monsterNum && sfm.FormationUse[4])
                return true;
            else if (sfm.FormationMonster[5] == monsterNum && sfm.FormationUse[5])
                return true;
            else if (sfm.FormationMonster[6] == monsterNum && sfm.FormationUse[6])
                return true;
            else if (sfm.FormationMonster[7] == monsterNum && sfm.FormationUse[7])
                return true;
            return false;
        }
        private void ScanFormationsForMonster(int monsterNum)
        {
            if (model.StatsModel == null)
                model.CreateStatsModel();
            StatsEditor.StatsModel sModel = model.StatsModel;

            Entrance ent = new Entrance();
            StatsEditor.Stats.Formation[] formations = sModel.Formations;
            ent.Source = 0xFFFF;
            ent.msg = "Default: " + universal.MonsterNames.GetNameByNum(monsterNum);
            eventTriggers.Add(ent);

            for (int i = 0; i < formations.Length; i++)
            {
                if (ScanFormation(monsterNum, formations[i]))
                {
                    ent = new Entrance();

                    ent.Source = (ushort)i;

                    ent.msg = "Formation: " + i.ToString() + " - " + formations[i].FormationNameList;
                    ent.LevelNum = 0;
                    ent.CoordX = 5;
                    ent.CoordY = 5;
                    ent.CoordZ = 0;
                    ent.RadialPosition = 7;

                    eventTriggers.Add(ent);
                }
            }
        }
        private void InitializePreviewer()
        {
            this.initializing = true;
            if (behaviour == (int)Behaviours.EventPreviewer)
            {
                this.Text = "PREVIEW EVENT";
                this.label1.Text = "Event #";
                this.label2.Text = "SELECT EVENT TO PREVIEW";
                this.selectNumericUpDown.Maximum = 4095;
            }
            else if (behaviour == (int)Behaviours.LevelPreviewer)
            {
                this.Text = "PREVIEW LEVEL";
                this.label1.Text = "Level #";
                this.label2.Text = "SELECT ENTRANCE TO PREVIEW";
                this.selectNumericUpDown.Maximum = 511;
            }
            else if (behaviour == (int)Behaviours.ActionPreviewer)
            {
                this.Text = "PREVIEW ACTION";
                this.label1.Text = "Action #";
                this.label2.Text = "SELECT ACTION TO PREVIEW";
                this.selectNumericUpDown.Maximum = 1023;
            }
            else if (behaviour == (int)Behaviours.BattlePreviewer)
            {
                this.Text = "PREVIEW BATTLE";
                this.label1.Text = "Monster #";
                this.label2.Text = "SELECT BATTLE TO PREVIEW";
                this.selectNumericUpDown.Maximum = 255;
                this.enterEventCheckBox.Enabled = false;

                this.panel8.Enabled = false;
                this.panel9.Enabled = true;

                this.battleBGListBox.Visible = true;
                this.battleBGListBox.Enabled = true;
                this.battleBGListBox.SelectedIndex = 0;
            }
            this.argsTextBox.Text = settings.PreviewArguments;
            this.checkBox1.Checked = settings.PreviewDynamicRomName;

            this.toggleAssembleLevels.Checked = settings.PreviewAssembleLevels;
            this.toggleAssembleScripts.Checked = settings.PreviewAssembleScripts;
            this.toggleAssembleStats.Checked = settings.PreviewAssembleStats;
            this.toggleAssembleSprites.Checked = settings.PreviewAssembleSprites;
            this.enterEventCheckBox.Checked = settings.PreviewEnterEvent;

            romPath = GetRomPath();
            this.initializing = false;
        }
        private string GetRomPath()
        {
            if (settings.PreviewDynamicRomName)
                return model.GetPathWithoutFileName() + "PreviewROM_" + model.GetFileNameWithoutPath();
            else
                return model.GetEditorPathWithoutFileName() + "PreviewRom.smc";
        }
        private string GetStatePath()
        {
            if (settings.PreviewDynamicRomName)
                return model.GetPathWithoutFileName() + "PreviewROM_" + model.GetFileNameWithoutPathOrExtension() + ".zst";
            else
                return model.GetEditorPathWithoutFileName() + "PreviewRom.zst";
        }
        private void Launch()
        {
            settings.PreviewArguments = argsTextBox.Text;
            settings.Save();
            if (rom && emulator && savestate && eventchoice)
                LaunchZSNES(this.emulatorPath, this.romPath, argsTextBox.Text);
            else
            {
                if (!rom)
                    MessageBox.Show("There was a problem generating the preview rom");
                if (!emulator)
                    MessageBox.Show("There is a problem with the emulator. ZSNESW is the only emulator supported.");
                if (!savestate)
                    MessageBox.Show("There was a problem generating the preview SaveState");
                if (!eventchoice)
                    MessageBox.Show("An invalid destination was selected to preview.");
            }
        }
        private bool Prelaunch()
        {
            this.rom = GeneratePreviewRom();
            this.savestate = GeneratePreviewSaveState();
            return (rom == savestate == true);
        }
        private bool GeneratePreviewSaveState()
        {
            try
            {
                FileInfo fInfo = new FileInfo(model.GetEditorPathWithoutFileName() + "RomPreviewBaseSave.zst");
                if (fInfo.Exists)
                {
                    fInfo = new FileInfo(GetStatePath());

                    if (!fInfo.Exists)
                    {
                        File.Copy(model.GetEditorPathWithoutFileName() + "RomPreviewBaseSave.zst", GetStatePath());
                    }
                }
            }
            catch
            {
                return false;
            }

            return true;
        }
        private bool PrepareImage()
        {
            Entrance ent = new Entrance();
            int index = this.eventListBox.SelectedIndex;

            if ((this.behaviour == (int)Behaviours.EventPreviewer || this.behaviour == (int)Behaviours.ActionPreviewer || this.behaviour == (int)Behaviours.BattlePreviewer) && index < 0 || index >= this.eventTriggers.Count)
            {
                this.eventchoice = false;
                return false;
            }

            LevelExits storage = new LevelExits(model.Data);
            storage.AddNewExit(0, new Point(0, 0));
            storage.CurrentExit = 0;

            if (this.eventTriggers.Count > 0)
            {
                ent = (Entrance)eventTriggers[index];
                storage.Destination = (ushort)ent.LevelNum;
                storage.MarioRadialPosition = ent.RadialPosition;
                storage.ShowMessage = ent.ShowMessage;
            }
            else
            {
                storage.Destination = (ushort)this.selectNumericUpDown.Value;
                storage.MarioRadialPosition = 7;
                storage.ShowMessage = false;
            }
            storage.ExitType = 0;
            storage.FieldCoordY = 10;
            storage.MarioCoordX = (byte)this.adjustXNumericUpDown.Value;
            storage.MarioCoordY = (byte)this.adjustYNumericUpDown.Value;
            storage.MarioCoordZ = (byte)this.adjustZNumericUpDown.Value;
            storage.LengthOverOne = true;

            if (this.settings.PreviewEnterEvent == false || this.behaviour == (int)Behaviours.BattlePreviewer)
            {
                ushort save = this.levelModel.Levels[storage.Destination].LevelEvents.ExitEvent;
                this.levelModel.Levels[storage.Destination].LevelEvents.ExitEvent = 0;
                if (this.behaviour == (int)Behaviours.BattlePreviewer)
                {
                    PrepareBattlePack(ent.Source);
                    byte[] eventData = new byte[] { 0x4a, 0x00, 0x00, 0x00, 0xFE };
                    eventData[3] = (byte)this.battleBGListBox.SelectedIndex;
                    SetEvent(eventData, 0); // Enter battle
                }
                else
                    SetEvent(new byte[] { 0x70, 0xFE }, 0); // Fade in from black

                SaveLevelExitEvents();
                this.levelModel.Levels[storage.Destination].LevelEvents.ExitEvent = save;
            }

            storage.Assemble(0x3166);
            this.eventchoice = true;
            return true;
        }
        private void SetEvent(byte[] eventData, int eventNum)
        {
            if (model.ScriptsModel == null)
                model.CreateScriptsModel();
            SMRPGED.ScriptsEditor.ScriptsModel scriptsModel = model.ScriptsModel;

            SMRPGED.ScriptsEditor.EventScript es = new SMRPGED.ScriptsEditor.EventScript(this.model.Data, eventData, eventNum);
            SMRPGED.ScriptsEditor.EventScript backup = scriptsModel.EventScripts[eventNum];

            scriptsModel.EventScripts[eventNum] = es;

            scriptsModel.AssembleAllEventScripts();

            scriptsModel.EventScripts[eventNum] = backup;

        }
        private void PrepareBattlePack(int formationNum)
        {
            if (model.StatsModel == null)
                model.CreateStatsModel();
            StatsEditor.StatsModel statsModel = model.StatsModel;

            if (formationNum == 0xFFFF)
            {
                int formationIndex = 4;

                byte monster1 = statsModel.Formations[formationIndex].FormationMonster[0];
                byte xcoord = statsModel.Formations[formationIndex].FormationCoordX[0];
                byte ycoord = statsModel.Formations[formationIndex].FormationCoordY[0];
                statsModel.Formations[formationIndex].FormationCoordX[0] = 167;
                statsModel.Formations[formationIndex].FormationCoordY[0] = 135;
                statsModel.Formations[formationIndex].FormationMonster[0] = (byte)this.selectNumericUpDown.Value;
                bool[] uses = new bool[8];
                uses[0] = statsModel.Formations[formationIndex].FormationUse[0];
                uses[1] = statsModel.Formations[formationIndex].FormationUse[1];
                uses[2] = statsModel.Formations[formationIndex].FormationUse[2];
                uses[3] = statsModel.Formations[formationIndex].FormationUse[3];
                uses[4] = statsModel.Formations[formationIndex].FormationUse[4];
                uses[5] = statsModel.Formations[formationIndex].FormationUse[5];
                uses[6] = statsModel.Formations[formationIndex].FormationUse[6];
                uses[7] = statsModel.Formations[formationIndex].FormationUse[7];
                statsModel.Formations[formationIndex].FormationUse[0] = true;
                statsModel.Formations[formationIndex].FormationUse[1] = false;
                statsModel.Formations[formationIndex].FormationUse[2] = false;
                statsModel.Formations[formationIndex].FormationUse[3] = false;
                statsModel.Formations[formationIndex].FormationUse[4] = false;
                statsModel.Formations[formationIndex].FormationUse[5] = false;
                statsModel.Formations[formationIndex].FormationUse[6] = false;
                statsModel.Formations[formationIndex].FormationUse[7] = false;

                statsModel.Formations[formationIndex].Assemble();

                statsModel.Formations[formationIndex].FormationMonster[0] = monster1;
                statsModel.Formations[formationIndex].FormationCoordX[0] = xcoord;
                statsModel.Formations[formationIndex].FormationCoordY[0] = ycoord;
                statsModel.Formations[formationIndex].FormationUse[0] = uses[0];
                statsModel.Formations[formationIndex].FormationUse[1] = uses[1];
                statsModel.Formations[formationIndex].FormationUse[2] = uses[2];
                statsModel.Formations[formationIndex].FormationUse[3] = uses[3];
                statsModel.Formations[formationIndex].FormationUse[4] = uses[4];
                statsModel.Formations[formationIndex].FormationUse[5] = uses[5];
                statsModel.Formations[formationIndex].FormationUse[6] = uses[6];
                statsModel.Formations[formationIndex].FormationUse[7] = uses[7];
                formationNum = formationIndex;
            }

            SMRPGED.StatsEditor.Stats.FormationPack sfp = statsModel.FormationPacks[0];
            byte formation1 = sfp.FormationPackForm[0];
            byte formation2 = sfp.FormationPackForm[0];
            byte formation3 = sfp.FormationPackForm[0];
            byte packset = sfp.FormationPackSet;
            if (formationNum > 255)
                sfp.FormationPackSet = 1;

            sfp.FormationPackForm[0] = (byte)formationNum;
            sfp.FormationPackForm[1] = (byte)formationNum;
            sfp.FormationPackForm[2] = (byte)formationNum;
            sfp.Assemble();
            sfp.FormationPackForm[0] = formation1;
            sfp.FormationPackForm[1] = formation2;
            sfp.FormationPackForm[2] = formation3;
            sfp.FormationPackSet = packset;
        }
        private void SaveLevelExitEvents()
        {
            ushort offsetStart = 0xE400;
            for (int i = 0; i < 512; i++)
                offsetStart = levelModel.Levels[i].LevelEvents.Assemble(offsetStart);
        }
        private bool GeneratePreviewRom()
        {
            // Save all assemble flags
            bool stats = model.AssembleStats;
            bool levels = model.AssembleLevels;
            bool sprites = model.AssembleSprites;
            bool scripts = model.AssembleScripts;
            bool final = model.AssembleFinal;
            bool ret = false;
            // Make backup of current data                
            byte[] backup = new byte[model.Data.Length];
            model.Data.CopyTo(backup, 0);

            // Assemble into backup
            //model.AssembleLevels = settings.PreviewAssembleLevels;
            //model.AssembleScripts = settings.PreviewAssembleScripts;
            //model.AssembleSprites = settings.PreviewAssembleSprites;
            //model.AssembleStats = settings.PreviewAssembleStats;
            model.AssembleFinal = false;

            if (!((this.behaviour == (int)Behaviours.EventPreviewer || this.behaviour == (int)Behaviours.ActionPreviewer) && this.eventListBox.SelectedIndex < 0 || this.eventListBox.SelectedIndex >= this.eventTriggers.Count))
            {
                this.model.Program.Assemble();
                PrepareImage();
                // Backup filename
                string fileNameBackup = model.GetFileName();
                // Generate preview name;
                this.romPath = GetRomPath();
                string oldFileName = model.GetFileName();

                model.SetFileName(romPath);
                ret = model.WriteRom(); // Save temp rom
                // Restore name
                model.SetFileName(oldFileName);
            }

            // Restore assemble flags
            model.AssembleFinal = final;
            model.AssembleLevels = levels;
            model.AssembleScripts = scripts;
            model.AssembleSprites = sprites;
            model.AssembleStats = stats;
            //Restore Rom Image
            //backup.CopyTo(model.Data, 0);

            return ret;
        }
        private void LaunchZSNES(string zsnesPath, string romPath, string args)
        {
            System.Diagnostics.Process proc = new System.Diagnostics.Process();

            proc.EnableRaisingEvents = false;
            proc.StartInfo.FileName = zsnesPath;
            proc.StartInfo.Arguments = args + " " + "\"" + romPath + "\"";
            proc.Start();

            this.Close();
        }
        private string SelectFile(string filter, string initDir, string title)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = filter;
            dialog.InitialDirectory = initDir;
            dialog.Title = title;
            return (dialog.ShowDialog() == DialogResult.OK)
               ? dialog.FileName : null;
        }
        private bool GetEmulator()
        {
            this.emulatorPath = settings.ZSNESPath; // Gets the saved emulator path
            FileInfo fi;
            try
            {
                fi = new FileInfo(this.emulatorPath);

                if (fi.Exists) // Checks if its a valid path
                    return true;
                else
                    throw new Exception();
            }
            catch
            {
                this.emulatorPath = SelectFile("exe files (*.exe)|*.exe|All files (*.*)|*.*", "C:\\", "Select Emulator ZSNESW.exe");

                if (this.emulatorPath == null || !this.emulatorPath.EndsWith(".exe"))
                    return false;

                fi = new FileInfo(this.emulatorPath);

                if (fi.Exists)
                {
                    settings.ZSNESPath = this.emulatorPath;
                    settings.Save();
                    return true;
                }
                else
                    return false;
            }
        }

        private void launchButton_Click(object sender, EventArgs e)
        {
            if (Prelaunch())
                Launch();
        }

        private void changeEmuButton_Click(object sender, EventArgs e)
        {
            string path = SelectFile("exe files (*.exe)|*.exe|All files (*.*)|*.*", "C:\\", "Select Emulator ZSNESW.exe");

            if (path == null || !path.EndsWith(".exe"))
                return;

            FileInfo fi = new FileInfo(path);

            if (fi.Exists)
            {
                this.emulatorPath = path;
                this.emulator = true;
                settings.ZSNESPath = this.emulatorPath;
                settings.Save();
                UpdateGui();
            }
        }
        private void UpdateGui()
        {
            this.emuPathTextBox.Text = this.emulatorPath;
            this.romPathTextBox.Text = this.romPath;
            this.selectNumericUpDown.Value = this.selectNum;
            this.eventListBox.Items.Clear();
            Entrance ent;

            for (int i = 0; i < eventTriggers.Count; i++)
            {
                ent = (Entrance)eventTriggers[i];
                if (this.behaviour == (int)Behaviours.EventPreviewer)
                {
                    if (ent.Flag)
                        this.eventListBox.Items.Add("Enter Event - X:" + ent.CoordX.ToString("00") + " Y:" + ent.CoordY.ToString("000") + " Z:" + ent.CoordZ.ToString("00") + " - Area: " + universal.GetLevelName(ent.LevelNum));
                    else // A run event
                        this.eventListBox.Items.Add("Run Event - X:" + ent.CoordX.ToString("00") + " Y:" + ent.CoordY.ToString("000") + " Z:" + ent.CoordZ.ToString("00") + " - Area: " + universal.GetLevelName(ent.LevelNum));
                }
                else if (this.behaviour == (int)Behaviours.LevelPreviewer)
                {
                    this.eventListBox.Items.Add("Enter - X:" + ent.CoordX.ToString("00") + " Y:" + ent.CoordY.ToString("000") + " Z:" + ent.CoordZ.ToString("00") + " - From Area: " + universal.GetLevelName(ent.Source));
                }
                else if (this.behaviour == (int)Behaviours.ActionPreviewer)
                {
                    if (ent.Flag)
                        this.eventListBox.Items.Add("NPC-ID: " + ent.Source.ToString() + " - NPC Action - Enter X:" + (ent.CoordX).ToString("00") + " Y:" + ent.CoordY.ToString("000") + " Z:" + ent.CoordZ.ToString("00") + " - Area: " + universal.GetLevelName(ent.LevelNum));
                    else
                        this.eventListBox.Items.Add("NPC-ID: " + ent.Source.ToString() + " - NPC Instance Action - Enter X:" + ent.CoordX.ToString("00") + " Y:" + ent.CoordY.ToString("000") + " Z:" + ent.CoordZ.ToString("00") + " - Area: " + universal.GetLevelName(ent.LevelNum));
                }
                else if (this.behaviour == (int)Behaviours.BattlePreviewer)
                {
                    this.eventListBox.Items.Add(ent.msg);
                }

            }
            if (this.eventListBox.Items.Count > 0)
                this.eventListBox.SelectedIndex = 0;
        }
        private void selectNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            this.selectNum = (int)selectNumericUpDown.Value;
            if (this.behaviour == (int)Behaviours.EventPreviewer)
                ScanForEvents();
            else if (this.behaviour == (int)Behaviours.LevelPreviewer)
            {
                this.eventTriggers.Clear();
                ScanForEntrancesToLevel((int)selectNumericUpDown.Value);
            }
            else if (this.behaviour == (int)Behaviours.ActionPreviewer)
            {
                this.eventTriggers.Clear();
                ScanForActionReferences((int)selectNumericUpDown.Value);
            }
            else if (this.behaviour == (int)Behaviours.BattlePreviewer)
            {
                this.eventTriggers.Clear();
                ScanFormationsForMonster((int)this.selectNumericUpDown.Value);
            }
            UpdateGui();
        }
        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toggleAssembleStats_Click(object sender, EventArgs e)
        {
            this.toggleAssembleStats.ForeColor = toggleAssembleStats.Checked ? SystemColors.ControlText : SystemColors.ControlDark;
            if (!this.initializing)
            {
                this.settings.PreviewAssembleStats = !this.settings.PreviewAssembleStats;
                this.settings.Save();
            }
        }
        private void toggleAssembleLevels_Click(object sender, EventArgs e)
        {
            this.toggleAssembleLevels.ForeColor = toggleAssembleLevels.Checked ? SystemColors.ControlText : SystemColors.ControlDark;
            if (!this.initializing)
            {
                this.settings.PreviewAssembleLevels = !this.settings.PreviewAssembleLevels;
                this.settings.Save();
            }
        }
        private void toggleAssembleScripts_Click(object sender, EventArgs e)
        {
            this.toggleAssembleScripts.ForeColor = toggleAssembleScripts.Checked ? SystemColors.ControlText : SystemColors.ControlDark;
            if (!this.initializing)
            {
                this.settings.PreviewAssembleScripts = !this.settings.PreviewAssembleScripts;
                this.settings.Save();
            }
        }
        private void toggleAssembleSprites_Click(object sender, EventArgs e)
        {
            this.toggleAssembleSprites.ForeColor = toggleAssembleSprites.Checked ? SystemColors.ControlText : SystemColors.ControlDark;
            if (!this.initializing)
            {
                this.settings.PreviewAssembleSprites = !this.settings.PreviewAssembleSprites;
                this.settings.Save();
            }

        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            this.checkBox1.ForeColor = checkBox1.Checked ? SystemColors.ControlText : SystemColors.ControlDark;
            if (!this.initializing)
            {
                settings.PreviewDynamicRomName = checkBox1.Checked;
                settings.Save();
                this.romPath = GetRomPath();
            }
            UpdateGui();
        }
        private void enterEventCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            this.enterEventCheckBox.ForeColor = enterEventCheckBox.Checked ? SystemColors.ControlText : SystemColors.ControlDark;
            if (!this.initializing)
            {
                this.settings.PreviewEnterEvent = enterEventCheckBox.Checked;
                settings.Save();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://zsnes-docs.sourceforge.net/html/advanced.htm#command_line");
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.argsTextBox.Text = settings.PreviewArgsDefault;
        }

        private void eventListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = this.eventListBox.SelectedIndex;

            if (index < 0 || index >= this.eventTriggers.Count)
                return;

            // Set the XYZ values
            this.adjustXNumericUpDown.Value = ((Entrance)eventTriggers[index]).CoordX;
            this.adjustYNumericUpDown.Value = ((Entrance)eventTriggers[index]).CoordY;
            this.adjustZNumericUpDown.Value = ((Entrance)eventTriggers[index]).CoordZ;
        }
        public struct Entrance
        {
            public ushort Source;
            public bool ShowMessage;
            public byte CoordX;
            public byte CoordY;
            public byte CoordZ;
            public byte RadialPosition;
            public ushort LevelNum;
            public bool Flag;
            public string msg;
        }

    }
}
