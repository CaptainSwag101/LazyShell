using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Collections;
using LAZYSHELL.Properties;
using LAZYSHELL.ScriptsEditor;

namespace LAZYSHELL.Previewer
{
    public partial class Previewer : Form
    {
        #region Variables
        private Settings settings = Settings.Default;
        private Model model = State.Instance.Model;
        private string romPath;
        private string emulatorPath = "INVALID";
        private bool rom = false, emulator = false, savestate = false, eventchoice = false, initializing = false;
        private int selectNum;
        private ArrayList eventTriggers;
        private bool snes9x;
        private int behaviour;
        private enum Behaviours
        {
            EventPreviewer,
            LevelPreviewer,
            ActionPreviewer,
            BattlePreviewer
        }
        #endregion
        // Constructor
        public Previewer(int num, int behaviour)
        {
            this.selectNum = num;
            this.eventTriggers = new ArrayList();
            this.behaviour = behaviour;

            InitializeComponent();
            InitializePreviewer();

            this.emulator = GetEmulator();
            if (num == 0)
                this.selectNumericUpDown_ValueChanged(null, null);
            UpdateGUI();

            if (settings.PreviewFirstTime)
            {
                DialogResult result = MessageBox.Show("The generated Preview ROM should not be used for anything other than Previews.\nDoing so will yield unpredictable results. Do you understand?", "LAZY SHELL", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    settings.PreviewFirstTime = false;
                    settings.Save();
                }
            }
        }
        public void Reload(int num, int behaviour)
        {
            this.selectNum = num;
            this.eventTriggers = new ArrayList();
            this.behaviour = behaviour;

            InitializePreviewer();

            this.emulator = GetEmulator();
            if (num == 0)
                this.selectNumericUpDown_ValueChanged(null, null);
            UpdateGUI();

            if (settings.PreviewFirstTime)
            {
                DialogResult result = MessageBox.Show("The generated Preview ROM should not be used for anything other than Previews.\nDoing so will yield unpredictable results. Do you understand?", "LAZY SHELL", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    settings.PreviewFirstTime = false;
                    settings.Save();
                }
            }
        }
        #region Functions
        private void InitializePreviewer()
        {
            this.initializing = true;
            if (behaviour == (int)Behaviours.EventPreviewer)
            {
                this.Text = "PREVIEW EVENT - Lazy Shell";
                this.label1.Text = "Event #";
                this.selectNumericUpDown.Maximum = 4095;
            }
            else if (behaviour == (int)Behaviours.LevelPreviewer)
            {
                this.Text = "PREVIEW LEVEL - Lazy Shell";
                this.label1.Text = "Level #";
                this.selectNumericUpDown.Maximum = 511;
            }
            else if (behaviour == (int)Behaviours.ActionPreviewer)
            {
                this.Text = "PREVIEW ACTION - Lazy Shell";
                this.label1.Text = "Action #";
                this.selectNumericUpDown.Maximum = 1023;
            }
            else if (behaviour == (int)Behaviours.BattlePreviewer)
            {
                this.Text = "PREVIEW BATTLE - Lazy Shell";
                this.label1.Text = "Monster #";
                this.selectNumericUpDown.Maximum = 255;

                this.panel8.Enabled = false;
                this.panel9.Enabled = true;

                this.battleBGListBox.Items.AddRange(Lists.Numerize(Lists.BattlefieldNames));
                this.battleBGListBox.Visible = true;
                this.battleBGListBox.Enabled = true;
                this.battleBGListBox.SelectedIndex = 0;
            }
            this.argsTextBox.Text = settings.PreviewArguments;
            this.dynamicROMPath.Checked = settings.PreviewDynamicRomName;

            romPath = GetRomPath();
            this.initializing = false;
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
            catch (Exception ex)
            {
                this.emulatorPath = SelectFile("exe files (*.exe)|*.exe|All files (*.*)|*.*", "C:\\", "Select Emulator");

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
        private string SelectFile(string filter, string initDir, string title)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = filter;
            dialog.InitialDirectory = initDir;
            dialog.Title = title;
            return (dialog.ShowDialog() == DialogResult.OK) ? dialog.FileName : null;
        }
        private void UpdateGUI()
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
                        this.eventListBox.Items.Add(
                            "Enter Event - X:" + ent.CoordX.ToString("00") +
                            " Y:" + ent.CoordY.ToString("000") +
                            " Z:" + ent.CoordZ.ToString("00") +
                            " - Area: [" + ent.LevelNum.ToString("d3") + "]" + settings.LevelNames[ent.LevelNum]);
                    else // A run event
                        this.eventListBox.Items.Add(
                            "Run Event - X:" + ent.CoordX.ToString("00") +
                            " Y:" + ent.CoordY.ToString("000") +
                            " Z:" + ent.CoordZ.ToString("00") +
                            " - Area: [" + ent.LevelNum.ToString("d3") + "]" + settings.LevelNames[ent.LevelNum]);
                }
                else if (this.behaviour == (int)Behaviours.LevelPreviewer)
                {
                    this.eventListBox.Items.Add(
                        "Enter - X:" + ent.CoordX.ToString("00") +
                        " Y:" + ent.CoordY.ToString("000") +
                        " Z:" + ent.CoordZ.ToString("00") +
                        " - From Area: [" + ent.LevelNum.ToString("d3") + "]" + settings.LevelNames[ent.LevelNum]);
                }
                else if (this.behaviour == (int)Behaviours.ActionPreviewer)
                {
                    if (ent.Flag)
                        this.eventListBox.Items.Add(
                            "NPC-ID: " + ent.Source.ToString() +
                            " - NPC Action - Enter X:" + (ent.CoordX).ToString("00") +
                            " Y:" + ent.CoordY.ToString("000") +
                            " Z:" + ent.CoordZ.ToString("00") +
                            " - Area: [" + ent.LevelNum.ToString("d3") + "]" + settings.LevelNames[ent.LevelNum]);
                    else
                        this.eventListBox.Items.Add(
                            "NPC-ID: " + ent.Source.ToString() +
                            " - NPC Instance Action - Enter X:" + ent.CoordX.ToString("00") +
                            " Y:" + ent.CoordY.ToString("000") +
                            " Z:" + ent.CoordZ.ToString("00") +
                            " - Area: [" + ent.LevelNum.ToString("d3") + "]" + settings.LevelNames[ent.LevelNum]);
                }
                else if (this.behaviour == (int)Behaviours.BattlePreviewer)
                {
                    this.eventListBox.Items.Add(ent.msg);
                }

            }
            if (this.eventListBox.Items.Count > 0)
                this.eventListBox.SelectedIndex = 0;
        }
        // launching
        private bool Prelaunch()
        {
            this.rom = GeneratePreviewRom();
            this.savestate = GeneratePreviewSaveState();
            return (rom == savestate == true);
        }
        private void Launch()
        {
            settings.PreviewArguments = argsTextBox.Text;
            settings.Save();
            if (rom && emulator && savestate && eventchoice)
                LaunchEmulator(this.emulatorPath, this.romPath, snes9x ? textBox1.Text : argsTextBox.Text);
            else
            {
                if (!rom)
                    MessageBox.Show("There was a problem generating the preview rom", "LAZY SHELL");
                if (!emulator)
                    MessageBox.Show("There is a problem with the emulator.\nSNES9X and ZSNESW are the only emulators supported.", "LAZY SHELL");
                if (!savestate)
                    MessageBox.Show("There was a problem generating the preview save state.", "LAZY SHELL");
                if (!eventchoice)
                    MessageBox.Show("An invalid destination was selected to preview.", "LAZY SHELL");
            }
        }
        private bool GeneratePreviewRom()
        {
            bool ret = false;
            // Make backup of current data                
            byte[] backup = new byte[model.Data.Length];
            model.Data.CopyTo(backup, 0);
            if (!((this.behaviour == (int)Behaviours.EventPreviewer || this.behaviour == (int)Behaviours.ActionPreviewer) &&
                this.eventListBox.SelectedIndex < 0 || this.eventListBox.SelectedIndex >= this.eventTriggers.Count))
            {
                if (this.behaviour == (int)Behaviours.BattlePreviewer)
                    this.model.Program.BattleScripts.Assemble();
                if (this.behaviour == (int)Behaviours.EventPreviewer ||
                    this.behaviour == (int)Behaviours.ActionPreviewer)
                    this.model.Program.EventScripts.Assemble();
                if (this.behaviour == (int)Behaviours.LevelPreviewer)
                    this.model.Program.Levels.Assemble();
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
            //Restore Rom Image
            backup.CopyTo(model.Data, 0);
            return ret;
        }
        private byte[] maxStats = new byte[]
        {
            0x1E,0xE7,0x03,0xE7,0x03,0xFF,0xFF,0xFF,0xFF,0xFF,0x0F,0x27,0x21,0x45,0x51,0x00,0x3F,0x00,0x00,0x00,
            0x1E,0xE7,0x03,0xE7,0x03,0xFF,0xFF,0xFF,0xFF,0xFF,0x0F,0x27,0x22,0x44,0x5E,0x00,0xC0,0x0F,0x00,0x00,
            0x1E,0xE7,0x03,0xE7,0x03,0xFF,0xFF,0xFF,0xFF,0xFF,0x0F,0x27,0x1E,0x43,0x5A,0x00,0x00,0xF0,0x00,0x00,
            0x1E,0xE7,0x03,0xE7,0x03,0xFF,0xFF,0xFF,0xFF,0xFF,0x0F,0x27,0x1F,0x42,0x4D,0x00,0x00,0x00,0x1F,0x00,
            0x1E,0xE7,0x03,0xE7,0x03,0xFF,0xFF,0xFF,0xFF,0xFF,0x0F,0x27,0x20,0x41,0x4B,0x00,0x00,0x00,0xE0,0x07
        };
        private bool GeneratePreviewSaveState()
        {
            try
            {
                snes9x = Do.Contains(this.emulatorPath, "snes9x", StringComparison.CurrentCultureIgnoreCase);
                string ext = snes9x ? ".000" : ".zst";
                FileInfo fInfo = new FileInfo(model.GetEditorPathWithoutFileName() + "RomPreviewBaseSave" + ext);
                if (fInfo.Exists)
                {
                    FileStream fs = fInfo.OpenRead();
                    BinaryReader br = new BinaryReader(fs);
                    byte[] state = br.ReadBytes((int)fs.Length);
                    br.Close();
                    fs.Close();

                    // modify zst if needed
                    if (maxOutStats.Checked)
                        maxStats.CopyTo(state, snes9x ? 0x30487 : 0x20413);
                    int offset = snes9x ? 0x53C9D : 0x41533;

                    byte allyCount = 1;
                    for (byte i = 0; i < alliesInParty.Items.Count; i++)
                        if (alliesInParty.GetItemChecked(i))
                        {
                            state[offset + 0x32 + i] = (byte)(i + 1);
                            allyCount++;
                        }
                    state[offset + 0x32] = allyCount;
                    state[offset + 0x3F] &= 0xFC;
                    state[offset + 0x3F] |= Math.Min((byte)3, allyCount);

                    fInfo = new FileInfo(GetStatePath());
                    fs = fInfo.OpenWrite();
                    BinaryWriter bw = new BinaryWriter(fs);
                    bw.Write(state);
                    bw.Close();
                    fs.Close();
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
        private bool PrepareImage()
        {
            Entrance ent = new Entrance();
            int index = this.eventListBox.SelectedIndex;

            if ((this.behaviour == (int)Behaviours.EventPreviewer ||
                this.behaviour == (int)Behaviours.ActionPreviewer ||
                this.behaviour == (int)Behaviours.BattlePreviewer) &&
                index < 0 || index >= this.eventTriggers.Count)
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
                storage.DestFace = ent.RadialPosition;
                storage.ShowMessage = ent.ShowMessage;
            }
            else
            {
                storage.Destination = (ushort)this.selectNumericUpDown.Value;
                storage.DestFace = 7;
                storage.ShowMessage = false;
            }
            storage.ExitType = 0;
            storage.Y = 10;
            storage.DestX = (byte)this.adjustXNumericUpDown.Value;
            storage.DestY = (byte)this.adjustYNumericUpDown.Value;
            storage.DestZ = (byte)this.adjustZNumericUpDown.Value;

            ushort save = this.model.Levels[storage.Destination].LevelEvents.ExitEvent;
            this.model.Levels[storage.Destination].LevelEvents.ExitEvent = 0;
            if (this.behaviour == (int)Behaviours.BattlePreviewer)
            {
                PrepareBattlePack(ent.Source);
                byte[] eventData = new byte[] { 0x4A, 0x00, 0x00, 0x00, 0xFE };
                eventData[3] = (byte)this.battleBGListBox.SelectedIndex;
                eventData.CopyTo(model.Data, 0x1E0C00);
            }
            else
                new byte[] { 0x70, 0xFE }.CopyTo(model.Data, 0x1E0C00);

            SaveLevelExitEvents();
            this.model.Levels[storage.Destination].LevelEvents.ExitEvent = save;

            storage.Assemble(0x3166);
            this.eventchoice = true;
            return true;
        }
        private void PrepareBattlePack(int formationNum)
        {
            if (formationNum == 0xFFFF)
            {
                int formationIndex = 4;

                byte monster1 = model.Formations[formationIndex].FormationMonster[0];
                byte xcoord = model.Formations[formationIndex].FormationCoordX[0];
                byte ycoord = model.Formations[formationIndex].FormationCoordY[0];
                model.Formations[formationIndex].FormationCoordX[0] = 167;
                model.Formations[formationIndex].FormationCoordY[0] = 135;
                model.Formations[formationIndex].FormationMonster[0] = (byte)this.selectNumericUpDown.Value;
                bool[] uses = new bool[8];
                uses[0] = model.Formations[formationIndex].FormationUse[0];
                uses[1] = model.Formations[formationIndex].FormationUse[1];
                uses[2] = model.Formations[formationIndex].FormationUse[2];
                uses[3] = model.Formations[formationIndex].FormationUse[3];
                uses[4] = model.Formations[formationIndex].FormationUse[4];
                uses[5] = model.Formations[formationIndex].FormationUse[5];
                uses[6] = model.Formations[formationIndex].FormationUse[6];
                uses[7] = model.Formations[formationIndex].FormationUse[7];
                model.Formations[formationIndex].FormationUse[0] = true;
                model.Formations[formationIndex].FormationUse[1] = false;
                model.Formations[formationIndex].FormationUse[2] = false;
                model.Formations[formationIndex].FormationUse[3] = false;
                model.Formations[formationIndex].FormationUse[4] = false;
                model.Formations[formationIndex].FormationUse[5] = false;
                model.Formations[formationIndex].FormationUse[6] = false;
                model.Formations[formationIndex].FormationUse[7] = false;

                model.Formations[formationIndex].Assemble();

                model.Formations[formationIndex].FormationMonster[0] = monster1;
                model.Formations[formationIndex].FormationCoordX[0] = xcoord;
                model.Formations[formationIndex].FormationCoordY[0] = ycoord;
                model.Formations[formationIndex].FormationUse[0] = uses[0];
                model.Formations[formationIndex].FormationUse[1] = uses[1];
                model.Formations[formationIndex].FormationUse[2] = uses[2];
                model.Formations[formationIndex].FormationUse[3] = uses[3];
                model.Formations[formationIndex].FormationUse[4] = uses[4];
                model.Formations[formationIndex].FormationUse[5] = uses[5];
                model.Formations[formationIndex].FormationUse[6] = uses[6];
                model.Formations[formationIndex].FormationUse[7] = uses[7];
                formationNum = formationIndex;
            }

            FormationPack sfp = model.FormationPacks[0];
            ushort formation1 = sfp.PackFormations[0];
            ushort formation2 = sfp.PackFormations[0];
            ushort formation3 = sfp.PackFormations[0];
            sfp.PackFormations[0] = (ushort)formationNum;
            sfp.PackFormations[1] = (ushort)formationNum;
            sfp.PackFormations[2] = (ushort)formationNum;
            sfp.Assemble();
            sfp.PackFormations[0] = formation1;
            sfp.PackFormations[1] = formation2;
            sfp.PackFormations[2] = formation3;
        }
        private void SaveLevelExitEvents()
        {
            ushort offsetStart = 0xE400;
            for (int i = 0; i < 512; i++)
                offsetStart = model.Levels[i].LevelEvents.Assemble(offsetStart);
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
            string ext = snes9x ? ".000" : ".zst";
            if (settings.PreviewDynamicRomName)
                return model.GetPathWithoutFileName() + "PreviewROM_" + model.GetFileNameWithoutPathOrExtension() + ext;
            else
                return model.GetEditorPathWithoutFileName() + "PreviewRom" + ext;
        }
        private void LaunchEmulator(string zsnesPath, string romPath, string args)
        {
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.EnableRaisingEvents = false;
            proc.StartInfo.FileName = zsnesPath;
            proc.StartInfo.Arguments = args + " " + "\"" + romPath + "\"";
            proc.Start();
        }
        // scanning data
        private void ScanForEvents()
        {
            this.eventTriggers.Clear();
            ScanForEnterEvents();
            ScanForRunEvents();
        }
        private void ScanForEnterEvents()
        {
            foreach (Level lvl in model.Levels)
            {
                if (lvl.LevelEvents.ExitEvent == this.selectNum)
                {
                    ScanForEntrancesToLevel(lvl.Index);
                }
            }
        }
        private void ScanForRunEvents()
        {
            Entrance ent;
            int save;
            foreach (Level lvl in model.Levels) // For every level
            {
                save = lvl.LevelEvents.CurrentEvent; // Save current index to restore later
                for (int i = 0; i < lvl.LevelEvents.NumberOfEvents; i++) // For every event in each level
                {
                    lvl.LevelEvents.CurrentEvent = i;
                    if (lvl.LevelEvents.RunEvent == this.selectNum)
                    {
                        ent = new Entrance();
                        ent.LevelNum = (ushort)lvl.Index;
                        ent.CoordX = lvl.LevelEvents.X;
                        ent.CoordY = lvl.LevelEvents.Y;
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

            foreach (Level lvl in model.Levels) // For every level
            {
                save = lvl.LevelExits.CurrentExit; // Save current index to restore later
                for (int i = 0; i < lvl.LevelExits.NumberOfExits; i++) // For every event in each level
                {
                    lvl.LevelExits.CurrentExit = i;
                    if (lvl.LevelExits.Destination == lvlNum) // If this exit points to the level we want
                    {
                        ent = new Entrance();
                        ent.Source = (ushort)lvl.Index;
                        ent.LevelNum = (ushort)lvl.LevelExits.Destination;
                        ent.CoordX = lvl.LevelExits.DestX;
                        ent.CoordY = lvl.LevelExits.DestY;
                        ent.CoordZ = lvl.LevelExits.DestZ;
                        ent.RadialPosition = lvl.LevelExits.DestFace;
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

            foreach (Level lvl in model.Levels) // For every level
            {
                saveNPC = lvl.LevelNPCs.CurrentNPC;

                for (int i = 0; i < lvl.LevelNPCs.NumberOfNPCs; i++) // For every NPC in each level
                {
                    lvl.LevelNPCs.CurrentNPC = i;
                    if (lvl.LevelNPCs.Movement + lvl.LevelNPCs.PropertyC == actionNum) // If this NPC has our action #
                    {
                        ent = new Entrance();
                        ent.Source = (ushort)lvl.LevelNPCs.NPCID;
                        ent.LevelNum = (ushort)lvl.Index;
                        ent.CoordX = (byte)((lvl.LevelNPCs.X + 2) & 0x3F);
                        ent.CoordY = (byte)((lvl.LevelNPCs.Y + 2) & 0x7F);
                        ent.CoordZ = lvl.LevelNPCs.Z;
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
                            ent.LevelNum = (ushort)lvl.Index;
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
        private bool ScanFormation(int monsterNum, Formation sfm)
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
            Entrance ent = new Entrance();
            Formation[] formations = model.Formations;
            ent.Source = 0xFFFF;
            ent.msg = "Default: " + model.MonsterNames.GetNameByNum(monsterNum);
            eventTriggers.Add(ent);

            for (int i = 0; i < formations.Length; i++)
            {
                if (ScanFormation(monsterNum, formations[i]))
                {
                    ent = new Entrance();

                    ent.Source = (ushort)i;

                    ent.msg = "Formation: " + i.ToString() + " - " + formations[i].ToString();
                    ent.LevelNum = 0;
                    ent.CoordX = 5;
                    ent.CoordY = 5;
                    ent.CoordZ = 0;
                    ent.RadialPosition = 7;

                    eventTriggers.Add(ent);
                }
            }
        }
        #endregion
        #region Event Handlers
        private void linkLabelZSNES_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://zsnes-docs.sourceforge.net/html/advanced.htm#command_line");
        }
        private void linkLabelSNES9X_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.snes9x.com/phpbb2/viewtopic.php?t=3020");
        }
        private void defaultZSNES_Click(object sender, EventArgs e)
        {
            this.argsTextBox.Text = settings.PreviewArgsDefault;
        }
        private void defaultSNES9X_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = "";
        }
        private void dynamicROMPath_CheckedChanged(object sender, EventArgs e)
        {
            this.dynamicROMPath.ForeColor = dynamicROMPath.Checked ? SystemColors.ControlText : SystemColors.ControlDark;
            if (!this.initializing)
            {
                settings.PreviewDynamicRomName = dynamicROMPath.Checked;
                settings.Save();
                this.romPath = GetRomPath();
            }
            UpdateGUI();
        }
        private void changeEmuButton_Click(object sender, EventArgs e)
        {
            string path = SelectFile("exe files (*.exe)|*.exe|All files (*.*)|*.*", "C:\\", "Select Emulator");

            if (path == null || !path.EndsWith(".exe"))
                return;

            FileInfo fi = new FileInfo(path);

            if (fi.Exists)
            {
                this.emulatorPath = path;
                this.emulator = true;
                settings.ZSNESPath = this.emulatorPath;
                settings.Save();
                UpdateGUI();
            }
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
            UpdateGUI();
        }
        private void maxOutStats_CheckedChanged(object sender, EventArgs e)
        {
            maxOutStats.ForeColor = maxOutStats.Checked ? SystemColors.ControlText : SystemColors.ControlDark;
        }
        private void launchButton_Click(object sender, EventArgs e)
        {
            if (Prelaunch())
                Launch();
        }
        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
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

        private void alliesInParty_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
