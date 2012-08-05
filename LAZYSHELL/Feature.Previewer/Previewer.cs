using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;
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
        private string romPath;
        private string emulatorPath = "INVALID";
        private bool rom = false, emulator = false, savestate = false, eventchoice = false, initializing = false;
        private int selectNum;
        private ArrayList eventTriggers;
        private bool snes9x;
        private int behavior;
        private bool updating = false;
        private int category;
        private int index;
        //
        private enum Behaviors
        {
            EventPreviewer,
            LevelPreviewer,
            ActionPreviewer,
            BattlePreviewer,
            AnimationPreviewer,
            MineCartPreviewer
        }
        private byte[] maxStats = new byte[]
        {
            0x1E,0xE7,0x03,0xE7,0x03,0xFF,0xFF,0xFF,0xFF,0xFF,0x0F,0x27,0x21,0x45,0x51,0x00,0x3F,0x00,0x00,0x00,
            0x1E,0xE7,0x03,0xE7,0x03,0xFF,0xFF,0xFF,0xFF,0xFF,0x0F,0x27,0x22,0x44,0x5E,0x00,0xC0,0x0F,0x00,0x00,
            0x1E,0xE7,0x03,0xE7,0x03,0xFF,0xFF,0xFF,0xFF,0xFF,0x0F,0x27,0x1E,0x43,0x5A,0x00,0x00,0xF0,0x00,0x00,
            0x1E,0xE7,0x03,0xE7,0x03,0xFF,0xFF,0xFF,0xFF,0xFF,0x0F,0x27,0x1F,0x42,0x4D,0x00,0x00,0x00,0x1F,0x00,
            0x1E,0xE7,0x03,0xE7,0x03,0xFF,0xFF,0xFF,0xFF,0xFF,0x0F,0x27,0x20,0x41,0x4B,0x00,0x00,0x00,0xE0,0x07
        };
        //
        private const uint WM_KEYDOWN = 0x0100;
        private const uint WM_KEYUP = 0x0101;
        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool PostMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);
        #endregion
        // Constructor
        public Previewer(int num, int behaviour)
        {
            this.selectNum = num;
            this.eventTriggers = new ArrayList();
            this.behavior = behaviour;

            InitializeComponent();
            InitializePreviewer();

            this.emulator = GetEmulator();
            if (num == 0)
                this.selectNumericUpDown_ValueChanged(null, null);
            UpdateGUI();

            if (settings.PreviewFirstTime)
            {
                DialogResult result = MessageBox.Show("The generated Preview ROM should not be used for anything other than Previews. Doing so will yield unpredictable results.\n\nDo you understand?", "LAZY SHELL", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    settings.PreviewFirstTime = false;
                    settings.Save();
                }
            }
        }
        public Previewer(int category, int index, bool automatic)
        {
            this.category = category;
            this.index = index;

            this.selectNum = index;
            this.eventTriggers = new ArrayList();
            this.behavior = 4;
            InitializeComponent();
            InitializePreviewer();
            this.emulator = GetEmulator();
            if (index == 0)
                this.selectNumericUpDown_ValueChanged(null, null);
            UpdateGUI();
            if (settings.PreviewFirstTime)
            {
                DialogResult result = MessageBox.Show("The generated Preview ROM should not be used for anything other than Previews. Doing so will yield unpredictable results.\n\nDo you understand?", "LAZY SHELL", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    settings.PreviewFirstTime = false;
                    settings.Save();
                }
            }
        }
        public void Reload(int num, int behaviour)
        {
            if (this.selectNum == num && this.behavior == behaviour)
                return;
            this.selectNum = num;
            this.eventTriggers = new ArrayList();
            this.behavior = behaviour;

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
        public void Reload(int category, int index, bool automatic)
        {
            this.category = category;
            this.index = index;

            this.selectNum = index;
            this.eventTriggers = new ArrayList();
            this.behavior = 4;
            InitializePreviewer();
            this.emulator = GetEmulator();
            if (index == 0)
                this.selectNumericUpDown_ValueChanged(null, null);
            UpdateGUI();
            if (settings.PreviewFirstTime)
            {
                DialogResult result = MessageBox.Show("The generated Preview ROM should not be used for anything other than Previews. Doing so will yield unpredictable results.\n\nDo you understand?", "LAZY SHELL", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
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
            this.zsnesArgs.Text = settings.PreviewArguments;
            this.dynamicROMPath.Checked = settings.PreviewDynamicRomName;
            this.level.Value = settings.PreviewLevel;
            if (behavior == (int)Behaviors.EventPreviewer)
            {
                this.Text = "PREVIEW EVENT - Lazy Shell";
                this.label1.Text = "Event #";
                this.selectNumericUpDown.Maximum = 4095;
                this.groupBox2.Visible = false;
            }
            else if (behavior == (int)Behaviors.LevelPreviewer)
            {
                this.Text = "PREVIEW LEVEL - Lazy Shell";
                this.label1.Text = "Level #";
                this.selectNumericUpDown.Maximum = 511;
                this.groupBox2.Visible = false;
            }
            else if (behavior == (int)Behaviors.MineCartPreviewer)
            {
                this.Text = "PREVIEW MINE CART - Lazy Shell";
                this.selectNumericUpDown.Enabled = false;
                this.groupBox1.Visible = false;
                this.groupBox2.Visible = false;
            }
            else if (behavior == (int)Behaviors.ActionPreviewer)
            {
                this.Text = "PREVIEW ACTION - Lazy Shell";
                this.label1.Text = "Action #";
                this.selectNumericUpDown.Maximum = 1023;
                this.groupBox2.Visible = false;
            }
            else if (behavior == (int)Behaviors.BattlePreviewer)
            {
                this.Text = "PREVIEW BATTLE - Lazy Shell";
                this.label1.Text = "Monster #";
                this.selectNumericUpDown.Maximum = 255;

                this.groupBox1.Visible = false;
                this.groupBox2.Enabled = true;

                this.battleBGListBox.Items.AddRange(Lists.Numerize(Lists.BattlefieldNames));
                this.battleBGListBox.Visible = true;
                this.battleBGListBox.Enabled = true;
                this.battleBGListBox.SelectedIndex = settings.PreviewBattlefield;
            }
            else if (behavior == (int)Behaviors.AnimationPreviewer)
            {
                this.Text = "PREVIEW ANIMATION - Lazy Shell";
                this.label1.Text = "Monster #";
                this.selectNumericUpDown.Maximum = 255;
                if (category == 1)
                    index += 64;
                else if (category == 4)
                {
                    index += 96;
                    this.selectNumericUpDown.Value = 0;
                    goto Finish;
                }
                foreach (BattleScript bs in Model.BattleScripts)
                {
                    byte[] command = null;
                    while ((command = bs.NextCommand()) != null)
                    {
                        switch (category)
                        {
                            case 1:
                                if (command[0] == 0xEF && command[1] == index)
                                {
                                    this.selectNumericUpDown.Value = bs.Index;
                                    bs.CommandIndex = 0;
                                    goto Finish;
                                }
                                if (command[0] == 0xF0 && (command[1] == index || command[2] == index || command[3] == index))
                                {
                                    this.selectNumericUpDown.Value = bs.Index;
                                    bs.CommandIndex = 0;
                                    goto Finish;
                                }
                                break;
                            case 2:
                                if (command[0] < 0xE0 && command[0] == index)
                                {
                                    this.selectNumericUpDown.Value = bs.Index;
                                    bs.CommandIndex = 0;
                                    goto Finish;
                                }
                                if (command[0] == 0xE0 && (command[1] == index || command[2] == index || command[3] == index))
                                {
                                    this.selectNumericUpDown.Value = bs.Index;
                                    bs.CommandIndex = 0;
                                    goto Finish;
                                }
                                break;
                            default:
                                break;
                        }
                    }
                    bs.CommandIndex = 0;
                }
            Finish:
                this.groupBox1.Enabled = false;
                this.groupBox2.Enabled = true;

                this.battleBGListBox.Items.AddRange(Lists.Numerize(Lists.BattlefieldNames));
                this.battleBGListBox.Visible = true;
                this.battleBGListBox.Enabled = true;
                this.battleBGListBox.SelectedIndex = settings.PreviewBattlefield;
            }
            // ally stats
            this.allyName.Items.Clear();
            for (int i = 0; i < Model.Characters.Length; i++)
                this.allyName.Items.Add(new string(Model.Characters[i].Name));
            this.allyName.SelectedIndex = 0;
            this.allyWeapon.Items.Clear();
            this.allyWeapon.Items.AddRange(Model.ItemNames.GetNames());
            this.allyArmor.Items.Clear();
            this.allyArmor.Items.AddRange(Model.ItemNames.GetNames());
            this.allyAccessory.Items.Clear();
            this.allyAccessory.Items.AddRange(Model.ItemNames.GetNames());
            //settings.AllyEquipment = "FFFFFFFFFFFFFFFFFFFFFFFFFFFFFF";
            //settings.Save();
            updating = true;
            this.allyWeapon.SelectedIndex = Model.ItemNames.GetIndexFromNum(StringToByte(settings.AllyEquipment, allyName.SelectedIndex * 3));
            this.allyArmor.SelectedIndex = Model.ItemNames.GetIndexFromNum(StringToByte(settings.AllyEquipment, allyName.SelectedIndex * 3 + 1));
            this.allyAccessory.SelectedIndex = Model.ItemNames.GetIndexFromNum(StringToByte(settings.AllyEquipment, allyName.SelectedIndex * 3 + 2));
            //
            this.maxOutStats.Checked = settings.PreviewMaxStats;
            for (int i = 0; i < 4; i++)
                alliesInParty.SetItemChecked(i, Bits.GetBit(settings.PreviewAllies, i));
            updating = false;
            romPath = GetRomPath();
            this.initializing = false;
        }
        private byte StringToByte(string value, int index)
        {
            string substring = value.Substring(index * 2, 2);
            byte equipment = Convert.ToByte(substring, 16);
            return equipment;
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
                if (this.behavior == (int)Behaviors.EventPreviewer)
                {
                    if (ent.Flag)
                        this.eventListBox.Items.Add(
                            "Enter Event (x:" + ent.CoordX.ToString() +
                            " y:" + ent.CoordY.ToString() +
                            " z:" + ent.CoordZ.ToString() +
                            ") " + Lists.Numerize(settings.LevelNames, ent.LevelNum));
                    else // A run event
                        this.eventListBox.Items.Add(
                            "Run Event (x:" + ent.CoordX.ToString() +
                            " y:" + ent.CoordY.ToString() +
                            " z:" + ent.CoordZ.ToString() +
                            ") " + Lists.Numerize(settings.LevelNames, ent.LevelNum));
                }
                else if (this.behavior == (int)Behaviors.LevelPreviewer)
                {
                    this.eventListBox.Items.Add(
                        "(x:" + ent.CoordX.ToString() +
                        " y:" + ent.CoordY.ToString() +
                        " z:" + ent.CoordZ.ToString() +
                        ") " + Lists.Numerize(settings.LevelNames, ent.Source));
                }
                else if (this.behavior == (int)Behaviors.MineCartPreviewer)
                {

                }
                else if (this.behavior == (int)Behaviors.ActionPreviewer)
                {
                    if (ent.Flag)
                        this.eventListBox.Items.Add(
                            "NPC #" + ent.Source.ToString() +
                            " (x:" + (ent.CoordX).ToString() +
                            " y:" + ent.CoordY.ToString() +
                            " z:" + ent.CoordZ.ToString() +
                            ") " + Lists.Numerize(settings.LevelNames, ent.LevelNum));
                    else
                        this.eventListBox.Items.Add(
                            "NPC #" + ent.Source.ToString() +
                            " (x:" + ent.CoordX.ToString() +
                            " y:" + ent.CoordY.ToString() +
                            " z:" + ent.CoordZ.ToString() +
                            ") " + Lists.Numerize(settings.LevelNames, ent.LevelNum));
                }
                else if (this.behavior == (int)Behaviors.BattlePreviewer)
                {
                    this.eventListBox.Items.Add(ent.msg);
                }
            }
            if (this.eventListBox.Items.Count > 0)
            {
                if (this.behavior == (int)Behaviors.BattlePreviewer && this.eventListBox.Items.Count > 1)
                    this.eventListBox.SelectedIndex = 1;
                else
                    this.eventListBox.SelectedIndex = 0;
            }
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
            settings.PreviewArguments = zsnesArgs.Text;
            settings.Save();
            if (rom && emulator && savestate && eventchoice)
                LaunchEmulator(this.emulatorPath, this.romPath, snes9x ? snes9xArgs.Text : zsnesArgs.Text);
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
            byte[] backup = new byte[Model.Data.Length];
            bool[] editGraphicSets = new bool[272];
            bool[] editTileSets = new bool[125];
            bool[] editTileMaps = new bool[309];
            bool[] editSolidityMaps = new bool[120];
            Model.Data.CopyTo(backup, 0);
            Model.EditGraphicSets.CopyTo(editGraphicSets, 0);
            Model.EditTileSets.CopyTo(editTileSets, 0);
            Model.EditTileMaps.CopyTo(editTileMaps, 0);
            Model.EditSolidityMaps.CopyTo(editSolidityMaps, 0);
            if (!((this.behavior == (int)Behaviors.EventPreviewer || this.behavior == (int)Behaviors.ActionPreviewer) &&
                this.eventListBox.SelectedIndex < 0 || this.eventListBox.SelectedIndex >= this.eventTriggers.Count))
            {
                if (this.behavior == (int)Behaviors.BattlePreviewer)
                    Model.Program.Monsters.Assemble();
                if (this.behavior == (int)Behaviors.EventPreviewer ||
                    this.behavior == (int)Behaviors.ActionPreviewer)
                    Model.Program.EventScripts.Assemble();
                if (this.behavior == (int)Behaviors.LevelPreviewer)
                    Model.Program.Levels.Assemble();
                if (this.behavior == (int)Behaviors.MineCartPreviewer)
                    Model.Program.MiniGames.Assemble();
                PrepareImage();
                // Backup filename
                string fileNameBackup = Model.FileName;
                // Generate preview name;
                this.romPath = GetRomPath();
                string oldFileName = Model.FileName;
                Model.FileName = romPath;
                ret = Model.WriteRom(); // Save temp rom
                // Restore name
                Model.FileName = oldFileName;
            }
            //Restore Rom Image
            backup.CopyTo(Model.Data, 0);
            editGraphicSets.CopyTo(Model.EditGraphicSets, 0);
            editTileSets.CopyTo(Model.EditTileSets, 0);
            editTileMaps.CopyTo(Model.EditTileMaps, 0);
            editSolidityMaps.CopyTo(Model.EditSolidityMaps, 0);
            return ret;
        }
        private bool GeneratePreviewSaveState()
        {
            try
            {
                snes9x = Do.Contains(this.emulatorPath, "snes9x", StringComparison.CurrentCultureIgnoreCase);
                string ext = snes9x ? ".000" : ".zst";
                FileInfo fInfo = new FileInfo(Model.GetEditorPathWithoutFileName() + "RomPreviewBaseSave" + ext);
                if (!fInfo.Exists)
                {
                    byte[] lc;
                    if (snes9x)
                        lc = Resources.RomPreviewBaseSave;
                    else
                        lc = Resources.RomPreviewBaseSave1;
                    File.WriteAllBytes(Model.GetEditorPathWithoutFileName() + "RomPreviewBaseSave" + ext, lc);
                }
                FileStream fs = fInfo.OpenRead();
                BinaryReader br = new BinaryReader(fs);
                byte[] state = br.ReadBytes((int)fs.Length);
                br.Close();
                fs.Close();

                int offset = 0;
                // modify zst if needed
                if (maxOutStats.Checked)
                    maxStats.CopyTo(state, snes9x ? 0x30487 : 0x20413);
                else
                {
                    foreach (Character character in Model.Characters)
                    {
                        int hp = character.StartingCurrentHP;
                        int attack = character.StartingAttack;
                        int defense = character.StartingDefense;
                        int mgAttack = character.StartingMgAttack;
                        int mgDefense = character.StartingMgDefense;
                        int experience = character.StartingExperience;
                        bool[] spells = new bool[128];
                        spells[0] = character.Jump;
                        spells[1] = character.FireOrb;
                        spells[2] = character.SuperJump;
                        spells[3] = character.SuperFlame;
                        spells[4] = character.UltraJump;
                        spells[5] = character.UltraFlame;
                        spells[6] = character.Therapy;
                        spells[7] = character.GroupHug;
                        spells[8] = character.SleepyTime;
                        spells[9] = character.ComeBack;
                        spells[10] = character.Mute;
                        spells[11] = character.PsychBomb;
                        spells[12] = character.Terrorize;
                        spells[13] = character.PoisonGas;
                        spells[14] = character.Crusher;
                        spells[15] = character.BowserCrush;
                        spells[16] = character.GenoBeam;
                        spells[17] = character.GenoBoost;
                        spells[18] = character.GenoWhirl;
                        spells[19] = character.GenoBlast;
                        spells[20] = character.GenoFlash;
                        spells[21] = character.Thunderbolt;
                        spells[22] = character.HPRain;
                        spells[23] = character.Psychopath;
                        spells[24] = character.Shocker;
                        spells[25] = character.Snowy;
                        spells[26] = character.StarRain;
                        spells[27] = character.Dummy27;
                        spells[28] = character.Dummy28;
                        spells[29] = character.Dummy29;
                        spells[30] = character.Dummy30;
                        spells[31] = character.Dummy31;

                        foreach (Character.Level level in character.Levels)
                        {
                            if (level == null) continue;
                            if (level.Index > this.level.Value) break;
                            hp += level.HpPlus;
                            attack += level.AttackPlus;
                            defense += level.DefensePlus;
                            mgAttack += level.MgAttackPlus;
                            mgDefense += level.MgDefensePlus;
                            // used balanced level-up bonus
                            if (level.AttackPlusBonus > level.MgAttackPlusBonus)
                            {
                                attack += level.AttackPlusBonus;
                                defense += level.DefensePlusBonus;
                            }
                            else if (level.MgAttackPlusBonus > level.AttackPlusBonus)
                            {
                                mgAttack += level.MgAttackPlusBonus;
                                mgDefense += level.MgDefensePlusBonus;
                            }
                            else
                                hp += level.HpPlusBonus;
                            experience = level.ExpNeeded;
                            spells[level.SpellLearned] = level.SpellLearned != 0xFF;
                        }
                        offset = snes9x ? 0x30487 : 0x20413;
                        offset += character.Index * 20;
                        state[offset++] = Math.Max(character.StartingLevel, (byte)this.level.Value);
                        Bits.SetShort(state, offset, (ushort)hp); offset += 2;
                        Bits.SetShort(state, offset, (ushort)hp); offset += 2;
                        offset++;
                        state[offset++] = (byte)attack;
                        state[offset++] = (byte)defense;
                        state[offset++] = (byte)mgAttack;
                        state[offset++] = (byte)mgDefense;
                        Bits.SetShort(state, offset, experience); offset += 2;
                        state[offset++] = StringToByte(settings.AllyEquipment, character.Index * 3);
                        state[offset++] = StringToByte(settings.AllyEquipment, character.Index * 3 + 1);
                        state[offset++] = StringToByte(settings.AllyEquipment, character.Index * 3 + 2);
                        offset++;   // unused byte
                        double p = 0;
                        for (int i = 0; i < 32; i++, p += 0.125)
                            Bits.SetBit(state, offset + (int)p, i & 7, spells[i]);
                    }
                }
                // if previewing item, add item to inventory
                if (behavior == (int)Behaviors.AnimationPreviewer && category == 4)
                    state[snes9x ? 0x30509 : 0x20495] = (byte)index;

                offset = snes9x ? 0x53C9D : 0x41533;

                byte allyCount = 1;
                for (byte i = 0, a = 1; i < alliesInParty.Items.Count; i++)
                {
                    if (alliesInParty.GetItemChecked(i))
                    {
                        state[offset + 0x33 + a] = (byte)(i + 1);
                        a++; allyCount++;
                    }
                }
                state[offset + 0x32] = allyCount;
                state[offset + 0x33] = 0;   // Mario always in party and in first slot
                state[offset + 0x3F] &= 0xFC;
                state[offset + 0x3F] |= Math.Min((byte)3, allyCount);

                fInfo = new FileInfo(GetStatePath());
                fs = fInfo.OpenWrite();
                BinaryWriter bw = new BinaryWriter(fs);
                bw.Write(state);
                bw.Close();
                fs.Close();
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

            if ((this.behavior == (int)Behaviors.EventPreviewer ||
                this.behavior == (int)Behaviors.ActionPreviewer ||
                this.behavior == (int)Behaviors.BattlePreviewer) &&
                index < 0 || index >= this.eventTriggers.Count)
            {
                this.eventchoice = false;
                return false;
            }

            LevelExits storage = new LevelExits(Model.Data);
            storage.AddNewExit(0, new Point(0, 0));
            storage.CurrentExit = 0;
            if (this.eventTriggers.Count > 0)
            {
                ent = (Entrance)eventTriggers[index];
                storage.DestFace = ent.RadialPosition;
                storage.ShowMessage = ent.ShowMessage;
            }
            else
            {
                storage.DestFace = 7;
                storage.ShowMessage = false;
            }
            if (this.behavior == (int)Behaviors.LevelPreviewer)
                storage.Destination = Math.Min((ushort)509, (ushort)this.selectNumericUpDown.Value);
            else if (this.behavior == (int)Behaviors.EventPreviewer || this.behavior == (int)Behaviors.ActionPreviewer)
                storage.Destination = ent.LevelNum;
            storage.ExitType = 0;
            storage.Y = 10;
            storage.DestX = (byte)this.adjustXNumericUpDown.Value;
            storage.DestY = (byte)this.adjustYNumericUpDown.Value;
            storage.DestZ = (byte)this.adjustZNumericUpDown.Value;

            ushort save = Model.Levels[storage.Destination].LevelEvents.ExitEvent;
            Model.Levels[storage.Destination].LevelEvents.ExitEvent = 0;
            if (this.behavior == (int)Behaviors.BattlePreviewer)
            {
                PrepareBattlePack(ent.Source);
                byte[] eventData = new byte[] { 0x4A, 0x00, 0x00, 0x00, 0xFE };
                eventData[3] = (byte)this.battleBGListBox.SelectedIndex;
                eventData.CopyTo(Model.Data, 0x1E0C00);
            }
            else if (this.behavior == (int)Behaviors.MineCartPreviewer)
            {
                byte[] eventData = new byte[] { 0xFD, 0x4E };
                eventData.CopyTo(Model.Data, 0x1E0C00);
                switch (this.selectNum)
                {
                    case 0: Model.Data[0x0393EA] = 1; break;
                    case 1: Model.Data[0x0393EA] = 3; break;
                    case 2: Model.Data[0x0393EA] = 2; break;
                    case 3: Model.Data[0x0393EA] = 4; break;
                }
            }
            else if (this.behavior == (int)Behaviors.AnimationPreviewer)
            {
                int monsterNum = (int)selectNumericUpDown.Value;
                PrepareBattlePack(0xFFFF);
                byte[] eventData = new byte[] { 0x4A, 0x00, 0x00, 0x00, 0xFE };
                eventData[3] = (byte)this.battleBGListBox.SelectedIndex;
                eventData.CopyTo(Model.Data, 0x1E0C00);
                if (category == 1 || category == 2)
                {
                    int pointer = Bits.GetShort(Model.Data, 0x390026 + monsterNum * 2);
                    int offset = 0x390000 + pointer; //ByteManage.GetShort(data, monsterStatPtrA);
                    Model.Data[offset + 2] = 255;
                    Model.Data[offset + 7] = 255;
                    pointer = Bits.GetShort(Model.Data, 0x3930AA + (monsterNum * 2));
                    offset = 0x390000 + pointer;
                    if (category == 1)
                        new byte[] { 0xEF, (byte)this.index, 0xEC, 0xFF, 0xFF }.CopyTo(Model.Data, offset);
                    else if (category == 2)
                        new byte[] { (byte)this.index, 0xEC, 0xFF, 0xFF }.CopyTo(Model.Data, offset);
                }
            }
            else
                new byte[] { 0x70, 0xFE }.CopyTo(Model.Data, 0x1E0C00);

            SaveLevelExitEvents();
            Model.Levels[storage.Destination].LevelEvents.ExitEvent = save;

            storage.Assemble(0x3166);
            this.eventchoice = true;
            return true;
        }
        private void PrepareBattlePack(int formationNum)
        {
            if (formationNum == 0xFFFF)
            {
                int formationIndex = 4;

                byte monster1 = Model.Formations[formationIndex].FormationMonster[0];
                byte xcoord = Model.Formations[formationIndex].FormationCoordX[0];
                byte ycoord = Model.Formations[formationIndex].FormationCoordY[0];
                Model.Formations[formationIndex].FormationCoordX[0] = 167;
                Model.Formations[formationIndex].FormationCoordY[0] = 135;
                Model.Formations[formationIndex].FormationMonster[0] = (byte)this.selectNumericUpDown.Value;
                bool[] uses = new bool[8];
                uses[0] = Model.Formations[formationIndex].FormationUse[0];
                uses[1] = Model.Formations[formationIndex].FormationUse[1];
                uses[2] = Model.Formations[formationIndex].FormationUse[2];
                uses[3] = Model.Formations[formationIndex].FormationUse[3];
                uses[4] = Model.Formations[formationIndex].FormationUse[4];
                uses[5] = Model.Formations[formationIndex].FormationUse[5];
                uses[6] = Model.Formations[formationIndex].FormationUse[6];
                uses[7] = Model.Formations[formationIndex].FormationUse[7];
                Model.Formations[formationIndex].FormationUse[0] = true;
                Model.Formations[formationIndex].FormationUse[1] = false;
                Model.Formations[formationIndex].FormationUse[2] = false;
                Model.Formations[formationIndex].FormationUse[3] = false;
                Model.Formations[formationIndex].FormationUse[4] = false;
                Model.Formations[formationIndex].FormationUse[5] = false;
                Model.Formations[formationIndex].FormationUse[6] = false;
                Model.Formations[formationIndex].FormationUse[7] = false;

                Model.Formations[formationIndex].Assemble();

                Model.Formations[formationIndex].FormationMonster[0] = monster1;
                Model.Formations[formationIndex].FormationCoordX[0] = xcoord;
                Model.Formations[formationIndex].FormationCoordY[0] = ycoord;
                Model.Formations[formationIndex].FormationUse[0] = uses[0];
                Model.Formations[formationIndex].FormationUse[1] = uses[1];
                Model.Formations[formationIndex].FormationUse[2] = uses[2];
                Model.Formations[formationIndex].FormationUse[3] = uses[3];
                Model.Formations[formationIndex].FormationUse[4] = uses[4];
                Model.Formations[formationIndex].FormationUse[5] = uses[5];
                Model.Formations[formationIndex].FormationUse[6] = uses[6];
                Model.Formations[formationIndex].FormationUse[7] = uses[7];
                formationNum = formationIndex;
            }

            FormationPack sfp = Model.FormationPacks[0];
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
                offsetStart = Model.Levels[i].LevelEvents.Assemble(offsetStart);
        }
        private string GetRomPath()
        {
            if (settings.PreviewDynamicRomName)
                return Model.GetPathWithoutFileName() + "PreviewROM_" + Model.GetFileNameWithoutPath();
            else
                return Model.GetEditorPathWithoutFileName() + "PreviewRom.smc";
        }
        private string GetStatePath()
        {
            string ext = snes9x ? ".000" : ".zst";
            if (settings.PreviewDynamicRomName)
                return Model.GetPathWithoutFileName() + "PreviewROM_" + Model.GetFileNameWithoutPathOrExtension() + ext;
            else
                return Model.GetEditorPathWithoutFileName() + "PreviewRom" + ext;
        }
        private void LaunchEmulator(string emulatorPath, string romPath, string args)
        {
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.EnableRaisingEvents = false;
            proc.StartInfo.FileName = emulatorPath;
            proc.StartInfo.Arguments = args + " " + "\"" + romPath + "\"";
            proc.Start();
            if (snes9x)
            {
                //PostMessage(proc.MainWindowHandle, WM_KEYDOWN, (IntPtr)Keys.F1, (IntPtr)0x003B0001);
                //PostMessage(proc.MainWindowHandle, WM_KEYUP, (IntPtr)Keys.F1, (IntPtr)0x003B0001);
            }
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
            foreach (Level lvl in Model.Levels)
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
            foreach (Level lvl in Model.Levels) // For every level
            {
                foreach (Event event_ in lvl.LevelEvents.Events)
                {
                    if (event_.RunEvent == this.selectNum) // If this exit points to the level we want
                    {
                        ent = new Entrance();
                        ent.LevelNum = (ushort)lvl.Index;
                        ent.CoordX = event_.X;
                        ent.CoordY = event_.Y;
                        ent.CoordZ = event_.Z;
                        ent.RadialPosition = event_.Face;
                        ent.ShowMessage = false;
                        ent.Flag = false;
                        eventTriggers.Add(ent); // Add the event trigger
                    }
                }
            }
        }
        private void ScanForEntrancesToLevel(int lvlNum)
        {
            Entrance ent;
            foreach (Level lvl in Model.Levels) // For every level
            {
                foreach (Exit exit in lvl.LevelExits.Exits)
                {
                    if (exit.Destination == lvlNum) // If this exit points to the level we want
                    {
                        ent = new Entrance();
                        ent.Source = (ushort)lvl.Index;
                        ent.LevelNum = (ushort)exit.Destination;
                        ent.CoordX = exit.DestX;
                        ent.CoordY = exit.DestY;
                        ent.CoordZ = exit.DestZ;
                        ent.RadialPosition = exit.DestFace;
                        ent.ShowMessage = exit.ShowMessage;
                        ent.Flag = true; // Indicates an enter event
                        eventTriggers.Add(ent); // Add the event trigger
                    }
                }
            }
        }
        private void ScanForActionReferences(int actionNum)
        {
            Entrance ent;
            foreach (Level lvl in Model.Levels) // For every level
            {
                int counter = 0;
                foreach (NPC npc in lvl.LevelNPCs.Npcs) // For every NPC in each level
                {
                    if (npc.Movement + npc.PropertyC == actionNum) // If this NPC has our action #
                    {
                        ent = new Entrance();
                        ent.Source = counter++;
                        ent.LevelNum = (ushort)lvl.Index;
                        ent.CoordX = (byte)((npc.X + 2) & 0x3F);
                        ent.CoordY = (byte)((npc.Y + 2) & 0x7F);
                        ent.CoordZ = npc.Z;
                        ent.RadialPosition = 7;
                        ent.ShowMessage = false;
                        ent.Flag = true; // Indicates an NPC and not an Instance
                        eventTriggers.Add(ent); // Add the event trigger
                    }
                    foreach (NPC.Instance instance in npc.Instances) // test all instances
                    {
                        if (instance.Movement + instance.PropertyC == actionNum)
                        {
                            ent = new Entrance();
                            ent.Source = counter++;
                            ent.LevelNum = (ushort)lvl.Index;
                            ent.CoordX = (byte)((instance.X + 2) & 0x3F);
                            ent.CoordY = (byte)((instance.Y + 2) & 0x7F);
                            ent.CoordZ = instance.Z;
                            ent.RadialPosition = 7;
                            ent.ShowMessage = false;
                            ent.Flag = false; // Indicates an Instance
                            eventTriggers.Add(ent); // Add the event trigger
                        }
                    }
                }
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
            Formation[] formations = Model.Formations;
            ent.Source = 0xFFFF;
            ent.msg = "Default: " + Model.MonsterNames.GetNameByNum(monsterNum);
            eventTriggers.Add(ent);

            for (int i = 0; i < formations.Length; i++)
            {
                if (ScanFormation(monsterNum, formations[i]))
                {
                    ent = new Entrance();

                    ent.Source = (ushort)i;

                    ent.msg = "Formation: " + i.ToString() + " - " + formations[i].ToString();
                    ent.LevelNum = 0;
                    ent.CoordX = 0;
                    ent.CoordY = 0;
                    ent.CoordZ = 0;
                    ent.RadialPosition = 0;

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
            this.zsnesArgs.Text = settings.PreviewArgsDefault;
        }
        private void defaultSNES9X_Click(object sender, EventArgs e)
        {
            this.snes9xArgs.Text = "";
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
        //
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
            if (this.behavior == (int)Behaviors.EventPreviewer)
                ScanForEvents();
            else if (this.behavior == (int)Behaviors.LevelPreviewer)
            {
                this.eventTriggers.Clear();
                ScanForEntrancesToLevel((int)selectNumericUpDown.Value);
            }
            else if (this.behavior == (int)Behaviors.ActionPreviewer)
            {
                this.eventTriggers.Clear();
                ScanForActionReferences((int)selectNumericUpDown.Value);
            }
            else if (this.behavior == (int)Behaviors.BattlePreviewer)
            {
                this.eventTriggers.Clear();
                ScanFormationsForMonster((int)this.selectNumericUpDown.Value);
            }
            UpdateGUI();
        }
        private void battleBGListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updating || initializing)
                return;
            settings.PreviewBattlefield = battleBGListBox.SelectedIndex;
            settings.Save();
        }
        //
        private void alliesInParty_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updating || initializing)
                return;
            byte bits = settings.PreviewAllies;
            for (int i = 0; i < 4; i++)
                Bits.SetBit(ref bits, i, alliesInParty.GetItemChecked(i));
            settings.PreviewAllies = bits;
            settings.Save();
        }
        private void level_ValueChanged(object sender, EventArgs e)
        {
            if (updating || initializing)
                return;
            settings.PreviewLevel = (int)level.Value;
            settings.Save();
        }
        private void allyName_DrawItem(object sender, DrawItemEventArgs e)
        {
            Do.DrawName(
                sender, e, new BattleDialoguePreview(), Lists.Convert(Model.Characters),
                Model.FontMenu, Model.FontPaletteMenu.Palettes[0], 8, 10, 0, 0, false, false, Model.MenuBG_);
        }
        private void itemName_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;
            Do.DrawName(
                sender, e, new BattleDialoguePreview(), Model.ItemNames, Model.FontMenu,
                Model.FontPaletteMenu.Palettes[0], 8, 10, 0, 128, true, false, Model.MenuBG_);
        }
        private void allyName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updating || initializing)
                return;
            updating = true;
            this.allyWeapon.SelectedIndex = Model.ItemNames.GetIndexFromNum(StringToByte(settings.AllyEquipment, allyName.SelectedIndex * 3));
            this.allyArmor.SelectedIndex = Model.ItemNames.GetIndexFromNum(StringToByte(settings.AllyEquipment, allyName.SelectedIndex * 3 + 1));
            this.allyAccessory.SelectedIndex = Model.ItemNames.GetIndexFromNum(StringToByte(settings.AllyEquipment, allyName.SelectedIndex * 3 + 2));
            updating = false;
        }
        private void allyWeapon_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updating || initializing)
                return;
            byte number = (byte)Model.ItemNames.GetNumFromIndex(allyWeapon.SelectedIndex);
            settings.AllyEquipment = settings.AllyEquipment.Remove((allyName.SelectedIndex * 3) * 2, 2);
            settings.AllyEquipment = settings.AllyEquipment.Insert((allyName.SelectedIndex * 3) * 2, number.ToString("X2"));
            settings.Save();
        }
        private void allyArmor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updating || initializing)
                return;
            byte number = (byte)Model.ItemNames.GetNumFromIndex(allyArmor.SelectedIndex);
            settings.AllyEquipment = settings.AllyEquipment.Remove((allyName.SelectedIndex * 3 + 1) * 2, 2);
            settings.AllyEquipment = settings.AllyEquipment.Insert((allyName.SelectedIndex * 3 + 1) * 2, number.ToString("X2"));
            settings.Save();
        }
        private void allyAccessory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updating || initializing)
                return;
            byte number = (byte)Model.ItemNames.GetNumFromIndex(allyAccessory.SelectedIndex);
            settings.AllyEquipment = settings.AllyEquipment.Remove((allyName.SelectedIndex * 3 + 2) * 2, 2);
            settings.AllyEquipment = settings.AllyEquipment.Insert((allyName.SelectedIndex * 3 + 2) * 2, number.ToString("X2"));
            settings.Save();
        }
        private void maxOutStats_CheckedChanged(object sender, EventArgs e)
        {
            maxOutStats.ForeColor = maxOutStats.Checked ? SystemColors.ControlText : SystemColors.ControlDark;
            level.Enabled = !maxOutStats.Checked;
            allyName.Enabled = !maxOutStats.Checked;
            allyWeapon.Enabled = !maxOutStats.Checked;
            allyArmor.Enabled = !maxOutStats.Checked;
            allyAccessory.Enabled = !maxOutStats.Checked;
            if (updating || initializing)
                return;
            settings.PreviewMaxStats = maxOutStats.Checked;
            settings.Save();
        }
        private void reset_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("You're about to clear all equipement for all allies. Go ahead with process?",
                "LAZY SHELL", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;
            settings.AllyEquipment = "FFFFFFFFFFFFFFFFFFFFFFFFFFFFFF";
            settings.Save();
            this.allyWeapon.SelectedIndex = Model.ItemNames.GetIndexFromNum(StringToByte(settings.AllyEquipment, allyName.SelectedIndex * 3));
            this.allyArmor.SelectedIndex = Model.ItemNames.GetIndexFromNum(StringToByte(settings.AllyEquipment, allyName.SelectedIndex * 3 + 1));
            this.allyAccessory.SelectedIndex = Model.ItemNames.GetIndexFromNum(StringToByte(settings.AllyEquipment, allyName.SelectedIndex * 3 + 2));
        }
        //
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
            public int Source;
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
