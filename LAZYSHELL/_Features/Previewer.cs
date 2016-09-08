using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Collections;
using LazyShell.Properties;
using LazyShell.EventScripts;

namespace LazyShell
{
    public partial class PreviewerForm : Controls.NewForm
    {
        #region Variables

        private Settings settings = Settings.Default;
        private string romPath;
        private string emulatorPath = "INVALID";
        private const string warning =
            "The generated Preview ROM should not be used for anything other than Previews. " +
            "Doing so will yield unpredictable results.\n\nDo you understand?";
        private bool rom = false;
        private bool emulator = false;
        private bool savestate = false;
        private bool eventchoice = false;
        private bool initializing = false;
        private int selectNum;
        private List<Entrance> eventTriggers;
        private bool snes9x;
        private ElementType behavior;
        private int category;
        private int index;
        private bool automatic = false;
        private byte[] soundFX;
        //
        private byte[] maxStats = new byte[]
        {
            0x1E,0xE7,0x03,0xE7,0x03,0xFF,0xFF,0xFF,0xFF,0xFF,0x0F,0x27,0x21,0x45,0x51,0x00,0x3F,0x00,0x00,0x00,
            0x1E,0xE7,0x03,0xE7,0x03,0xFF,0xFF,0xFF,0xFF,0xFF,0x0F,0x27,0x22,0x44,0x5E,0x00,0xC0,0x0F,0x00,0x00,
            0x1E,0xE7,0x03,0xE7,0x03,0xFF,0xFF,0xFF,0xFF,0xFF,0x0F,0x27,0x1E,0x43,0x5A,0x00,0x00,0xF0,0x00,0x00,
            0x1E,0xE7,0x03,0xE7,0x03,0xFF,0xFF,0xFF,0xFF,0xFF,0x0F,0x27,0x1F,0x42,0x4D,0x00,0x00,0x00,0x1F,0x00,
            0x1E,0xE7,0x03,0xE7,0x03,0xFF,0xFF,0xFF,0xFF,0xFF,0x0F,0x27,0x20,0x41,0x4B,0x00,0x00,0x00,0xE0,0x07
        };

        // Windows messages
        private const uint WM_KEYDOWN = 0x0100;
        private const uint WM_KEYUP = 0x0101;
        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool PostMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        #endregion

        #region Constructors

        public PreviewerForm(int num, ElementType behavior)
        {
            this.selectNum = num;
            this.eventTriggers = new List<Entrance>();
            this.behavior = behavior;
            InitializeComponent();
            InitializePreviewer();
            this.emulator = GetEmulator();
            if (num == 0)
                this.selectNumericUpDown_ValueChanged(null, null);
            UpdateGUI();
            if (settings.PreviewFirstTime)
            {
                var result = MessageBox.Show(warning, "LAZY SHELL", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    settings.PreviewFirstTime = false;
                    settings.Save();
                }
            }
            Do.AddShortcut(toolStrip1, Keys.F1, helpTips);
            Do.AddShortcut(toolStrip1, Keys.F2, baseConvertor);
            new ToolTipLabel(this, baseConvertor, helpTips);
        }
        public PreviewerForm(int category, int index, bool automatic)
        {
            this.category = category;
            this.index = index;
            this.selectNum = index;
            this.eventTriggers = new List<Entrance>();
            this.behavior = ElementType.AnimationScript;
            InitializeComponent();
            InitializePreviewer();
            this.emulator = GetEmulator();
            if (index == 0)
                this.selectNumericUpDown_ValueChanged(null, null);
            UpdateGUI();
            if (settings.PreviewFirstTime)
            {
                var result = MessageBox.Show(warning, "LAZY SHELL", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    settings.PreviewFirstTime = false;
                    settings.Save();
                }
            }
            Do.AddShortcut(toolStrip1, Keys.F1, helpTips);
            Do.AddShortcut(toolStrip1, Keys.F2, baseConvertor);
            new ToolTipLabel(this, baseConvertor, helpTips);
        }
        public PreviewerForm(int index, bool automatic, ElementType behavior) // SPC Previewer
        {
            this.index = index;
            this.selectNum = index;
            this.eventTriggers = new List<Entrance>();
            this.behavior = behavior;
            this.automatic = automatic;
            InitializeComponent();
            InitializePreviewer();
            this.emulator = GetEmulator();
            if (index == 0)
                this.selectNumericUpDown_ValueChanged(null, null);
            UpdateGUI();
            if (settings.PreviewFirstTime)
            {
                var result = MessageBox.Show(warning, "LAZY SHELL", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    settings.PreviewFirstTime = false;
                    settings.Save();
                }
            }
            Do.AddShortcut(toolStrip1, Keys.F1, helpTips);
            Do.AddShortcut(toolStrip1, Keys.F2, baseConvertor);
            new ToolTipLabel(this, baseConvertor, helpTips);
            if (automatic)
                launchButton_Click(null, null);
        }
        public void Reload(int num, ElementType behavior)
        {
            if (this.selectNum == num && this.behavior == behavior)
                return;
            this.selectNum = num;
            this.eventTriggers = new List<Entrance>();
            this.behavior = behavior;
            InitializePreviewer();
            this.emulator = GetEmulator();
            if (this.selectIndex.Value == selectNum)
                this.selectNumericUpDown_ValueChanged(null, null);
            UpdateGUI();
            if (settings.PreviewFirstTime)
            {
                var result = MessageBox.Show(warning, "LAZY SHELL", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
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
            this.eventTriggers = new List<Entrance>();
            this.behavior = ElementType.AnimationScript;
            InitializePreviewer();
            this.emulator = GetEmulator();
            if (index == 0)
                this.selectNumericUpDown_ValueChanged(null, null);
            UpdateGUI();
            if (settings.PreviewFirstTime)
            {
                var result = MessageBox.Show(warning, "LAZY SHELL", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    settings.PreviewFirstTime = false;
                    settings.Save();
                }
            }
        }
        public void Reload(int index, bool automatic, ElementType behavior)
        {
            this.index = index;
            this.selectNum = index;
            this.eventTriggers = new List<Entrance>();
            this.behavior = behavior;
            this.automatic = automatic;
            InitializePreviewer();
            this.emulator = GetEmulator();
            if (index == 0)
                this.selectNumericUpDown_ValueChanged(null, null);
            UpdateGUI();
            if (settings.PreviewFirstTime)
            {
                var result = MessageBox.Show(warning, "LAZY SHELL", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    settings.PreviewFirstTime = false;
                    settings.Save();
                }
            }
            if (automatic)
                launchButton_Click(null, null);
        }

        #endregion

        #region Methods

        private void InitializePreviewer()
        {
            this.initializing = true;
            this.zsnesArgs.Text = settings.PreviewArguments;
            this.dynamicROMPath.Checked = settings.PreviewDynamicRomName;
            this.level.Value = settings.PreviewArea;
            if (behavior == ElementType.EventScript)
            {
                this.Text = "PREVIEW EVENT - Lazy Shell";
                this.label1.Text = "Event #";
                this.selectIndex.Maximum = 4095;
                this.groupBox2.Enabled = false;
            }
            else if (behavior == ElementType.Area)
            {
                this.Text = "PREVIEW LEVEL - Lazy Shell";
                this.label1.Text = "Level #";
                this.selectIndex.Maximum = 511;
                this.groupBox2.Enabled = false;
            }
            else if (behavior == ElementType.MineCart)
            {
                this.Text = "PREVIEW MINE CART - Lazy Shell";
                this.selectIndex.Enabled = false;
                this.groupBox1.Enabled = false;
                this.groupBox2.Enabled = false;
            }
            else if (behavior == ElementType.ActionScript)
            {
                this.Text = "PREVIEW ACTION - Lazy Shell";
                this.label1.Text = "Action #";
                this.selectIndex.Maximum = 1023;
                this.groupBox2.Enabled = false;
            }
            else if (behavior == ElementType.BattleScript)
            {
                this.Text = "PREVIEW BATTLE - Lazy Shell";
                this.label1.Text = "Monster #";
                this.selectIndex.Maximum = 255;
                this.groupBox1.Enabled = false;
                this.groupBox2.Enabled = true;
                this.battleBG.Items.AddRange(Lists.Numerize(Lists.Battlefields));
                this.battleBG.Enabled = true;
                this.battleBG.Enabled = true;
                this.battleBG.SelectedIndex = settings.PreviewBattlefield;
            }
            else if (behavior == ElementType.SPCBattle ||
                behavior == ElementType.SPCEvent ||
                behavior == ElementType.SPCTrack)
            {
                groupBox1.Enabled = false;
                groupBox2.Enabled = false;
            }
            else if (behavior == ElementType.AnimationScript)
            {
                this.Text = "PREVIEW ANIMATION - Lazy Shell";
                this.label1.Text = "Monster #";
                this.selectIndex.Maximum = 255;
                if (category == 1)
                    index += 64;
                else if (category == 4)
                {
                    index += 96;
                    this.selectIndex.Value = 0;
                    goto Finish;
                }
                foreach (var script in Monsters.Model.BattleScripts)
                {
                    foreach (var bsc in script.Commands)
                    {
                        switch (category)
                        {
                            case 1:
                                if (bsc.Opcode == 0xEF && bsc.Param1 == index)
                                {
                                    this.selectIndex.Value = script.Index;
                                    goto Finish;
                                }
                                if (bsc.Opcode == 0xF0 && (bsc.Param1 == index || bsc.Param2 == index || bsc.Param3 == index))
                                {
                                    this.selectIndex.Value = script.Index;
                                    goto Finish;
                                }
                                break;
                            case 2:
                                if (bsc.Opcode < 0xE0 && bsc.Opcode == index)
                                {
                                    this.selectIndex.Value = script.Index;
                                    goto Finish;
                                }
                                if (bsc.Opcode == 0xE0 && (bsc.Param1 == index || bsc.Param2 == index || bsc.Param3 == index))
                                {
                                    this.selectIndex.Value = script.Index;
                                    goto Finish;
                                }
                                break;
                            default:
                                break;
                        }
                    }
                }
            Finish:
                this.groupBox1.Enabled = false;
                this.battleBG.Items.AddRange(Lists.Numerize(Lists.Battlefields));
                this.battleBG.Enabled = true;
                this.battleBG.SelectedIndex = settings.PreviewBattlefield;
            }
            // ally stats
            this.allyName.Items.Clear();
            for (int i = 0; i < NewGame.Model.Allies.Length; i++)
                this.allyName.Items.Add(new string(NewGame.Model.Allies[i].Name));
            this.allyName.SelectedIndex = 0;
            this.allyWeapon.Items.Clear();
            this.allyWeapon.Items.AddRange(Items.Model.Names.Names);
            this.allyArmor.Items.Clear();
            this.allyArmor.Items.AddRange(Items.Model.Names.Names);
            this.allyAccessory.Items.Clear();
            this.allyAccessory.Items.AddRange(Items.Model.Names.Names);
            //
            this.Updating = true;
            this.allyWeapon.SelectedIndex = Items.Model.Names.GetSortedIndex(Bits.StringToByte(settings.AllyEquipment, allyName.SelectedIndex * 3));
            this.allyArmor.SelectedIndex = Items.Model.Names.GetSortedIndex(Bits.StringToByte(settings.AllyEquipment, allyName.SelectedIndex * 3 + 1));
            this.allyAccessory.SelectedIndex = Items.Model.Names.GetSortedIndex(Bits.StringToByte(settings.AllyEquipment, allyName.SelectedIndex * 3 + 2));
            //
            this.maxOutStats.Checked = settings.PreviewMaxStats;
            for (int i = 0; i < 4; i++)
                alliesInParty.SetItemChecked(i, Bits.GetBit(settings.PreviewAllies, i));
            this.enableDebug.Checked = settings.EnableDebug;
            //
            this.Updating = false;
            //
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
            this.selectIndex.Value = this.selectNum;
            this.eventListBox.Items.Clear();
            Entrance ent;
            for (int i = 0; i < eventTriggers.Count; i++)
            {
                ent = eventTriggers[i];
                if (this.behavior == ElementType.EventScript)
                {
                    if (ent.Flag)
                        this.eventListBox.Items.Add(
                            "Enter event (x:" + ent.X.ToString() +
                            " y:" + ent.Y.ToString() +
                            " z:" + ent.Z.ToString() +
                            ") " + Lists.Numerize(Lists.Areas, ent.Destination));
                    else if (ent.MSG != "NPC") // A run event
                        this.eventListBox.Items.Add(
                            "Event field (x:" + ent.X.ToString() +
                            " y:" + ent.Y.ToString() +
                            " z:" + ent.Z.ToString() +
                            ") " + Lists.Numerize(Lists.Areas, ent.Destination));
                    else if (ent.MSG == "NPC")
                        this.eventListBox.Items.Add(
                            "NPC #" + ent.Source + " event (x:" + ent.X.ToString() +
                            " y:" + ent.Y.ToString() +
                            " z:" + ent.Z.ToString() +
                            ") " + Lists.Numerize(Lists.Areas, ent.Destination));
                }
                else if (this.behavior == ElementType.Area)
                {
                    this.eventListBox.Items.Add(
                        "(x:" + ent.X.ToString() +
                        " y:" + ent.Y.ToString() +
                        " z:" + ent.Z.ToString() +
                        ") " + Lists.Numerize(Lists.Areas, ent.Source));
                }
                else if (this.behavior == ElementType.MineCart)
                {
                }
                else if (this.behavior == ElementType.ActionScript)
                {
                    if (ent.Flag)
                        this.eventListBox.Items.Add(
                            "NPC #" + ent.Source.ToString() +
                            " (x:" + ent.X.ToString() +
                            " y:" + ent.Y.ToString() +
                            " z:" + ent.Z.ToString() +
                            ") " + Lists.Numerize(Lists.Areas, ent.Destination));
                    else
                        this.eventListBox.Items.Add(
                            "NPC #" + ent.Source.ToString() +
                            " (x:" + ent.X.ToString() +
                            " y:" + ent.Y.ToString() +
                            " z:" + ent.Z.ToString() +
                            ") " + Lists.Numerize(Lists.Areas, ent.Destination));
                }
                else if (this.behavior == ElementType.BattleScript)
                {
                    this.eventListBox.Items.Add(ent.MSG);
                }
            }
            if (this.eventListBox.Items.Count > 0)
            {
                if (this.behavior == ElementType.BattleScript && this.eventListBox.Items.Count > 1)
                    this.eventListBox.SelectedIndex = 1;
                else
                    this.eventListBox.SelectedIndex = 0;
            }
        }

        // Launching
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
            byte[] backup = Bits.Copy(Model.ROM);
            bool[] editGraphicSets = Bits.Copy(Areas.Model.Modify_GraphicSets);
            bool[] editTilesets = Bits.Copy(Areas.Model.Modify_Tilesets);
            bool[] editTilemaps = Bits.Copy(Areas.Model.Modify_Tilemaps);
            bool[] editCollisionMaps = Bits.Copy(Areas.Model.Modify_CollisionMaps);
            //
            if (!((this.behavior == ElementType.EventScript || this.behavior == ElementType.ActionScript) &&
                this.eventListBox.SelectedIndex < 0 || this.eventListBox.SelectedIndex >= this.eventTriggers.Count))
            {
                if (this.behavior == ElementType.BattleScript)
                    LazyShell.Model.Program.Monsters.WriteToROM();
                if (this.behavior == ElementType.EventScript ||
                    this.behavior == ElementType.ActionScript)
                    LazyShell.Model.Program.EventScripts.WriteToROM();
                if (this.behavior == ElementType.Area)
                    LazyShell.Model.Program.Areas.WriteToROM();
                if (this.behavior == ElementType.MineCart)
                    LazyShell.Model.Program.Minecart.WriteToROM();
                if (this.behavior == ElementType.SPCTrack ||
                    this.behavior == ElementType.SPCEvent ||
                    this.behavior == ElementType.SPCBattle)
                {
                    LazyShell.Model.Program.Audio.WriteToROM(false);
                    if (this.behavior == ElementType.SPCEvent)
                        soundFX = Bits.GetBytes(Model.ROM, 0x042826, 0x1600);
                    else if (this.behavior == ElementType.SPCBattle)
                        soundFX = Bits.GetBytes(Model.ROM, 0x043E26, 0x1600);
                }
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
            backup.CopyTo(Model.ROM, 0);
            editGraphicSets.CopyTo(Areas.Model.Modify_GraphicSets, 0);
            editTilesets.CopyTo(Areas.Model.Modify_Tilesets, 0);
            editTilemaps.CopyTo(Areas.Model.Modify_Tilemaps, 0);
            editCollisionMaps.CopyTo(Areas.Model.Modify_CollisionMaps, 0);
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
                        lc = global::LazyShell.Properties.Resources.RomPreviewBaseSave;
                    else
                        lc = global::LazyShell.Properties.Resources.RomPreviewBaseSave1;
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
                    foreach (var ally in NewGame.Model.Allies)
                    {
                        int hp = ally.CurrentHP;
                        int attack = ally.Attack;
                        int defense = ally.Defense;
                        int mgAttack = ally.MgAttack;
                        int mgDefense = ally.MgDefense;
                        int experience = ally.Experience;
                        bool[] spells = new bool[128];
                        for (int i = 0; i < ally.Magic.Length; i++)
                            spells[i] = ally.Magic[i];
                        //
                        foreach (var level in LevelUps.Model.LevelUps)
                        {
                            if (level == null) continue;
                            if (level.Index > this.level.Value) break;
                            var levelUpAlly = level.Allies[ally.Index];
                            hp += levelUpAlly.HpPlus;
                            attack += levelUpAlly.AttackPlus;
                            defense += levelUpAlly.DefensePlus;
                            mgAttack += levelUpAlly.MgAttackPlus;
                            mgDefense += levelUpAlly.MgDefensePlus;
                            // Use balanced level-up bonus
                            if (levelUpAlly.AttackPlusBonus > levelUpAlly.MgAttackPlusBonus)
                            {
                                attack += levelUpAlly.AttackPlusBonus;
                                defense += levelUpAlly.DefensePlusBonus;
                            }
                            else if (levelUpAlly.MgAttackPlusBonus > levelUpAlly.AttackPlusBonus)
                            {
                                mgAttack += levelUpAlly.MgAttackPlusBonus;
                                mgDefense += levelUpAlly.MgDefensePlusBonus;
                            }
                            else
                                hp += levelUpAlly.HpPlusBonus;
                            experience = level.ExpNeeded;
                            spells[levelUpAlly.SpellLearned] = levelUpAlly.SpellLearned != 0xFF;
                        }
                        offset = snes9x ? 0x30487 : 0x20413;
                        offset += ally.Index * 20;
                        state[offset++] = Math.Max(ally.Level, (byte)this.level.Value);
                        Bits.SetShort(state, offset, (ushort)hp); offset += 2;
                        Bits.SetShort(state, offset, (ushort)hp); offset += 2;
                        offset++;
                        state[offset++] = (byte)attack;
                        state[offset++] = (byte)defense;
                        state[offset++] = (byte)mgAttack;
                        state[offset++] = (byte)mgDefense;
                        Bits.SetShort(state, offset, experience); offset += 2;
                        state[offset++] = Bits.StringToByte(settings.AllyEquipment, ally.Index * 3);
                        state[offset++] = Bits.StringToByte(settings.AllyEquipment, ally.Index * 3 + 1);
                        state[offset++] = Bits.StringToByte(settings.AllyEquipment, ally.Index * 3 + 2);
                        offset++;   // unused byte
                        double p = 0;
                        for (int i = 0; i < 32; i++, p += 0.125)
                            Bits.SetBit(state, offset + (int)p, i & 7, spells[i]);
                    }
                }
                // if previewing item, add item to inventory
                if (behavior == ElementType.AnimationScript && category == 4)
                    state[snes9x ? 0x30509 : 0x20495] = (byte)index;
                if (behavior == ElementType.SPCEvent ||
                    behavior == ElementType.SPCBattle)
                    Buffer.BlockCopy(soundFX, 0, state, snes9x ? 0x5BDA4 : 0x33C13, 0x1600);
                //
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
                //
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
            if ((this.behavior == ElementType.EventScript ||
                this.behavior == ElementType.ActionScript ||
                this.behavior == ElementType.BattleScript) &&
                index < 0 || index >= this.eventTriggers.Count)
            {
                this.eventchoice = false;
                return false;
            }
            //
            var storage = new Areas.ExitTriggerCollection();
            storage.Insert(0, new Point(0, 0));
            if (this.eventTriggers.Count > 0)
            {
                ent = eventTriggers[index];
                storage[0].DstF = ent.F;
                storage[0].ShowBanner = ent.ShowMessage;
            }
            else
            {
                storage[0].DstF = 7;
                storage[0].ShowBanner = false;
            }
            if (this.behavior == ElementType.Area)
                storage[0].Destination = Math.Min((ushort)509, (ushort)this.selectIndex.Value);
            else if (this.behavior == ElementType.EventScript || this.behavior == ElementType.ActionScript)
                storage[0].Destination = ent.Destination;
            storage[0].ExitType = 0;
            storage[0].Y = 10;
            storage[0].DstX = (byte)this.adjustX.Value;
            storage[0].DstY = (byte)this.adjustY.Value;
            storage[0].DstZ = (byte)this.adjustZ.Value;
            //
            ushort save = Areas.Model.Areas[storage[0].Destination].EventTriggers.StartEvent;
            byte saveMusic = Areas.Model.Areas[storage[0].Destination].EventTriggers.StartMusic;
            Areas.Model.Areas[storage[0].Destination].EventTriggers.StartEvent = 0;
            //
            if (this.behavior == ElementType.BattleScript)
            {
                PrepareBattlePack(ent.Source);
                byte[] eventData = new byte[] { 0x4A, 0x00, 0x00, 0x00, 0xFE };
                eventData[3] = (byte)this.battleBG.SelectedIndex;
                eventData.CopyTo(Model.ROM, 0x1E0C00);
            }
            else if (this.behavior == ElementType.Area)
            {
                byte[] command = new byte[] { 0xD0, 0, 0 };
                Bits.SetShort(command, 1, save);
                command.CopyTo(Model.ROM, 0x1E0C00);
            }
            else if (this.behavior == ElementType.MineCart)
            {
                byte[] eventData = new byte[] { 0xFD, 0x4E };
                eventData.CopyTo(Model.ROM, 0x1E0C00);
                switch (this.selectNum)
                {
                    case 0: Model.ROM[0x0393EA] = 1; break;
                    case 1: Model.ROM[0x0393EA] = 3; break;
                    case 2: Model.ROM[0x0393EA] = 2; break;
                    case 3: Model.ROM[0x0393EA] = 4; break;
                }
            }
            else if (this.behavior == ElementType.AnimationScript)
            {
                int monsterNum = (int)selectIndex.Value;
                PrepareBattlePack(0xFFFF);
                byte[] eventData = new byte[] { 0x4A, 0x00, 0x00, 0x00, 0xFE };
                eventData[3] = (byte)this.battleBG.SelectedIndex;
                eventData.CopyTo(Model.ROM, 0x1E0C00);
                if (category == 1 || category == 2)
                {
                    int pointer = Bits.GetShort(Model.ROM, 0x390026 + monsterNum * 2);
                    int offset = 0x390000 + pointer;
                    Model.ROM[offset + 2] = 255;
                    Model.ROM[offset + 7] = 255;
                    pointer = Bits.GetShort(Model.ROM, 0x3930AA + (monsterNum * 2));
                    offset = 0x390000 + pointer;
                    if (category == 1)
                        new byte[] { 0xEF, (byte)this.index, 0xEC, 0xFF, 0xFF }.CopyTo(Model.ROM, offset);
                    else if (category == 2)
                        new byte[] { (byte)this.index, 0xEC, 0xFF, 0xFF }.CopyTo(Model.ROM, offset);
                }
            }
            else if (this.behavior == ElementType.SPCTrack)
            {
                Areas.Model.Areas[storage[0].Destination].EventTriggers.StartMusic = (byte)this.index;
            }
            else if (this.behavior == ElementType.SPCEvent)
            {
                Areas.Model.Areas[storage[0].Destination].EventTriggers.StartMusic = 53;
                new byte[] { 0x9C, (byte)this.index }.CopyTo(Model.ROM, 0x1E0C00);
            }
            else if (this.behavior == ElementType.SPCBattle)
            {
                Areas.Model.Areas[0].EventTriggers.StartMusic = 53;
                new byte[] { 0x9C, (byte)this.index }.CopyTo(Model.ROM, 0x1E0C00);
            }
            else
            {
                Areas.Model.Areas[storage[0].Destination].EventTriggers.StartEvent = save;
                Areas.Model.Areas[storage[0].Destination].EventTriggers.StartMusic = saveMusic;
            }
            //
            SaveLevelExitEvents();
            Areas.Model.Areas[storage[0].Destination].EventTriggers.StartEvent = save;
            Areas.Model.Areas[storage[0].Destination].EventTriggers.StartMusic = saveMusic;
            //
            storage[0].WriteToROM(0x1DF000);
            this.eventchoice = true;
            //
            if (enableDebug.Checked)
                Model.ROM[0x0106AF] = 0x80;
            //
            return true;
        }
        private void PrepareBattlePack(int formationNum)
        {
            if (formationNum == 0xFFFF)
            {
                int formationIndex = 4;
                byte monster1 = Formations.Model.Formations[formationIndex].Monsters[0];
                byte xcoord = Formations.Model.Formations[formationIndex].X[0];
                byte ycoord = Formations.Model.Formations[formationIndex].Y[0];
                Formations.Model.Formations[formationIndex].X[0] = 167;
                Formations.Model.Formations[formationIndex].Y[0] = 135;
                Formations.Model.Formations[formationIndex].Monsters[0] = (byte)this.selectIndex.Value;
                bool[] uses = new bool[8];
                uses[0] = Formations.Model.Formations[formationIndex].Active[0];
                uses[1] = Formations.Model.Formations[formationIndex].Active[1];
                uses[2] = Formations.Model.Formations[formationIndex].Active[2];
                uses[3] = Formations.Model.Formations[formationIndex].Active[3];
                uses[4] = Formations.Model.Formations[formationIndex].Active[4];
                uses[5] = Formations.Model.Formations[formationIndex].Active[5];
                uses[6] = Formations.Model.Formations[formationIndex].Active[6];
                uses[7] = Formations.Model.Formations[formationIndex].Active[7];
                Formations.Model.Formations[formationIndex].Active[0] = true;
                Formations.Model.Formations[formationIndex].Active[1] = false;
                Formations.Model.Formations[formationIndex].Active[2] = false;
                Formations.Model.Formations[formationIndex].Active[3] = false;
                Formations.Model.Formations[formationIndex].Active[4] = false;
                Formations.Model.Formations[formationIndex].Active[5] = false;
                Formations.Model.Formations[formationIndex].Active[6] = false;
                Formations.Model.Formations[formationIndex].Active[7] = false;
                Formations.Model.Formations[formationIndex].WriteToROM();
                Formations.Model.Formations[formationIndex].Monsters[0] = monster1;
                Formations.Model.Formations[formationIndex].X[0] = xcoord;
                Formations.Model.Formations[formationIndex].Y[0] = ycoord;
                Formations.Model.Formations[formationIndex].Active[0] = uses[0];
                Formations.Model.Formations[formationIndex].Active[1] = uses[1];
                Formations.Model.Formations[formationIndex].Active[2] = uses[2];
                Formations.Model.Formations[formationIndex].Active[3] = uses[3];
                Formations.Model.Formations[formationIndex].Active[4] = uses[4];
                Formations.Model.Formations[formationIndex].Active[5] = uses[5];
                Formations.Model.Formations[formationIndex].Active[6] = uses[6];
                Formations.Model.Formations[formationIndex].Active[7] = uses[7];
                formationNum = formationIndex;
            }
            var sfp = Formations.Model.Packs[0];
            ushort formation1 = sfp.Formations[0];
            ushort formation2 = sfp.Formations[0];
            ushort formation3 = sfp.Formations[0];
            sfp.Formations[0] = (ushort)formationNum;
            sfp.Formations[1] = (ushort)formationNum;
            sfp.Formations[2] = (ushort)formationNum;
            sfp.WriteToROM();
            sfp.Formations[0] = formation1;
            sfp.Formations[1] = formation2;
            sfp.Formations[2] = formation3;
        }
        private void SaveLevelExitEvents()
        {
            int offsetStart = 0xE400;
            for (int i = 0; i < Areas.Model.Areas.Length; i++)
                Areas.Model.Areas[i].EventTriggers.WriteToROM(ref offsetStart);
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

        // Scanning data
        private void ScanForEvents()
        {
            this.eventTriggers.Clear();
            ScanForNPCEvents();
            ScanForEnterEvents();
            ScanForRunEvents();
        }
        private void ScanForEnterEvents()
        {
            foreach (var area in Areas.Model.Areas)
            {
                if (area.EventTriggers.StartEvent == this.selectNum)
                {
                    ScanForEntrancesToLevel(area.Index);
                }
            }
        }
        private void ScanForRunEvents()
        {
            Entrance ent;
            foreach (var area in Areas.Model.Areas) // For every level
            {
                foreach (var EVENT in area.EventTriggers.Triggers)
                {
                    if (EVENT.RunEvent == this.selectNum) // If this exit points to the level we want
                    {
                        ent = new Entrance();
                        ent.Destination = (ushort)area.Index;
                        ent.X = EVENT.X;
                        ent.Y = EVENT.Y;
                        ent.Z = EVENT.Z;
                        ent.F = EVENT.F;
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
            foreach (var area in Areas.Model.Areas) // For every level
            {
                foreach (var exit in area.ExitTriggers.Triggers)
                {
                    if (exit.Destination == lvlNum) // If this exit points to the level we want
                    {
                        ent = new Entrance();
                        ent.Source = (ushort)area.Index;
                        ent.Destination = (ushort)exit.Destination;
                        ent.X = exit.DstX;
                        ent.Y = exit.DstY;
                        ent.Z = exit.DstZ;
                        ent.F = exit.DstF;
                        ent.ShowMessage = exit.ShowBanner;
                        ent.Flag = true; // Indicates an enter event
                        eventTriggers.Add(ent); // Add the event trigger
                    }
                }
            }
        }
        private void ScanForNPCEvents()
        {
            Entrance ent;
            foreach (var area in Areas.Model.Areas) // For every level
            {
                int index = 0;
                for (int i = 0; i < area.NPCObjects.Count; i++, index++)
                {
                    var npc = area.NPCObjects.NPCObjects[i];
                    if (npc.EngageType == Areas.EngageType.Battle) // skip if battle trigger
                        continue;
                    if (npc.Event == this.selectNum)
                    {
                        ent = new Entrance();
                        ent.Destination = (ushort)area.Index;
                        ent.X = npc.X;
                        ent.Y = npc.Y;
                        ent.Z = npc.Z;
                        ent.MSG = "NPC";
                        ent.ShowMessage = false;
                        ent.Source = index;
                        ent.Flag = false;
                        eventTriggers.Add(ent); // Add the event trigger
                    }
                }
            }
        }
        private void ScanForActionReferences(int actionNum)
        {
            Entrance ent;
            foreach (var area in Areas.Model.Areas) // For every level
            {
                int counter = 0;
                foreach (var npc in area.NPCObjects.NPCObjects) // For every NPC in each level
                {
                    if (npc.Action == actionNum) // If this NPC has our action #
                    {
                        ent = new Entrance();
                        ent.Source = counter++;
                        ent.Destination = (ushort)area.Index;
                        ent.X = (byte)((npc.X + 2) & 0x3F);
                        ent.Y = (byte)((npc.Y + 2) & 0x7F);
                        ent.Z = npc.Z;
                        ent.F = 7;
                        ent.ShowMessage = false;
                        ent.Flag = true; // Indicates an NPC and not an Instance
                        eventTriggers.Add(ent); // Add the event trigger
                    }
                }
            }
        }
        private bool ScanFormation(int monsterNum, Formations.Formation sfm)
        {
            if (sfm.Monsters[0] == monsterNum && sfm.Active[0])
                return true;
            else if (sfm.Monsters[1] == monsterNum && sfm.Active[1])
                return true;
            else if (sfm.Monsters[2] == monsterNum && sfm.Active[2])
                return true;
            else if (sfm.Monsters[3] == monsterNum && sfm.Active[3])
                return true;
            else if (sfm.Monsters[4] == monsterNum && sfm.Active[4])
                return true;
            else if (sfm.Monsters[5] == monsterNum && sfm.Active[5])
                return true;
            else if (sfm.Monsters[6] == monsterNum && sfm.Active[6])
                return true;
            else if (sfm.Monsters[7] == monsterNum && sfm.Active[7])
                return true;
            return false;
        }
        private void ScanFormationsForMonster(int monsterNum)
        {
            Entrance ent = new Entrance();
            var formations = Formations.Model.Formations;
            ent.Source = 0xFFFF;
            ent.MSG = "Default: " + Monsters.Model.Names.GetUnsortedName(monsterNum);
            eventTriggers.Add(ent);
            for (int i = 0; i < formations.Length; i++)
            {
                if (ScanFormation(monsterNum, formations[i]))
                {
                    ent = new Entrance();
                    ent.Source = (ushort)i;
                    ent.MSG = "Formation: " + i.ToString() + " - " + formations[i].ToString();
                    ent.Destination = 0;
                    ent.X = 0;
                    ent.Y = 0;
                    ent.Z = 0;
                    ent.F = 0;
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
            string path = SelectFile("exe files (*.exe)|*.exe|All files (*.*)|*.*", settings.LastDirectory, "Select Emulator");
            if (path == null || !path.EndsWith(".exe"))
                return;
            FileInfo fi = new FileInfo(path);
            if (fi.Exists)
            {
                settings.LastDirectory = Path.GetDirectoryName(path);
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
            this.adjustX.Value = eventTriggers[index].X;
            this.adjustY.Value = eventTriggers[index].Y;
            this.adjustZ.Value = eventTriggers[index].Z;
        }
        private void selectNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            this.selectNum = (int)selectIndex.Value;
            if (this.behavior == ElementType.EventScript)
                ScanForEvents();
            else if (this.behavior == ElementType.Area)
            {
                this.eventTriggers.Clear();
                ScanForEntrancesToLevel((int)selectIndex.Value);
            }
            else if (this.behavior == ElementType.ActionScript)
            {
                this.eventTriggers.Clear();
                ScanForActionReferences((int)selectIndex.Value);
            }
            else if (this.behavior == ElementType.BattleScript)
            {
                this.eventTriggers.Clear();
                ScanFormationsForMonster((int)this.selectIndex.Value);
            }
            UpdateGUI();
        }
        private void battleBGListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Updating || initializing)
                return;
            settings.PreviewBattlefield = battleBG.SelectedIndex;
            settings.Save();
        }
        //
        private void alliesInParty_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Updating || initializing)
                return;
            byte bits = settings.PreviewAllies;
            for (int i = 0; i < 4; i++)
                Bits.SetBit(ref bits, i, alliesInParty.GetItemChecked(i));
            settings.PreviewAllies = bits;
            settings.Save();
        }
        private void level_ValueChanged(object sender, EventArgs e)
        {
            if (this.Updating || initializing)
                return;
            settings.PreviewArea = (int)level.Value;
            settings.Save();
        }
        private void allyName_DrawItem(object sender, DrawItemEventArgs e)
        {
            Do.DrawName(
                sender, e, new BattleDialoguePreview(), Lists.Convert(NewGame.Model.Allies),
                Fonts.Model.Menu, Fonts.Model.Palette_Menu.Palettes[0], 8, 10, 0, 0, false, false, Menus.Model.MenuBG_256x255);
        }
        private void itemName_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0)
                return;
            Do.DrawName(
                sender, e, new BattleDialoguePreview(), Items.Model.Names, Fonts.Model.Menu,
                Fonts.Model.Palette_Menu.Palettes[0], 8, 10, 0, 128, true, false, Menus.Model.MenuBG_256x255);
        }
        private void allyName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Updating || initializing)
                return;
            this.Updating = true;
            this.allyWeapon.SelectedIndex = Items.Model.Names.GetSortedIndex(Bits.StringToByte(settings.AllyEquipment, allyName.SelectedIndex * 3));
            this.allyArmor.SelectedIndex = Items.Model.Names.GetSortedIndex(Bits.StringToByte(settings.AllyEquipment, allyName.SelectedIndex * 3 + 1));
            this.allyAccessory.SelectedIndex = Items.Model.Names.GetSortedIndex(Bits.StringToByte(settings.AllyEquipment, allyName.SelectedIndex * 3 + 2));
            this.Updating = false;
        }
        private void allyWeapon_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Updating || initializing)
                return;
            byte number = (byte)Items.Model.Names.GetUnsortedIndex(allyWeapon.SelectedIndex);
            settings.AllyEquipment = settings.AllyEquipment.Remove((allyName.SelectedIndex * 3) * 2, 2);
            settings.AllyEquipment = settings.AllyEquipment.Insert((allyName.SelectedIndex * 3) * 2, number.ToString("X2"));
            settings.Save();
        }
        private void allyArmor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Updating || initializing)
                return;
            byte number = (byte)Items.Model.Names.GetUnsortedIndex(allyArmor.SelectedIndex);
            settings.AllyEquipment = settings.AllyEquipment.Remove((allyName.SelectedIndex * 3 + 1) * 2, 2);
            settings.AllyEquipment = settings.AllyEquipment.Insert((allyName.SelectedIndex * 3 + 1) * 2, number.ToString("X2"));
            settings.Save();
        }
        private void allyAccessory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Updating || initializing)
                return;
            byte number = (byte)Items.Model.Names.GetUnsortedIndex(allyAccessory.SelectedIndex);
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
            if (this.Updating || initializing)
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
            this.allyWeapon.SelectedIndex = Items.Model.Names.GetSortedIndex(Bits.StringToByte(settings.AllyEquipment, allyName.SelectedIndex * 3));
            this.allyArmor.SelectedIndex = Items.Model.Names.GetSortedIndex(Bits.StringToByte(settings.AllyEquipment, allyName.SelectedIndex * 3 + 1));
            this.allyAccessory.SelectedIndex = Items.Model.Names.GetSortedIndex(Bits.StringToByte(settings.AllyEquipment, allyName.SelectedIndex * 3 + 2));
        }
        private void enableDebug_CheckedChanged(object sender, EventArgs e)
        {
            if (this.Updating || initializing)
                return;
            settings.EnableDebug = enableDebug.Checked;
            settings.Save();
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
            public byte X;
            public byte Y;
            public byte Z;
            public byte F;
            public ushort Destination;
            public bool Flag;
            public string MSG;
        }
    }
}
