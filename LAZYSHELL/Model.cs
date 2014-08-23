using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms; // remove later
using System.IO;
using System.Security.Cryptography;
using System.Xml;
using LAZYSHELL.Properties;

namespace LAZYSHELL
{
    public static class Model
    {
        #region Variables

        // ROM buffer
        public static byte[] ROM { get; set; }

        // Program
        public static Program Program { get; set; }

        // Settings
        private static Settings settings = Settings.Default;

        // Forms
        public static HexEditor HexEditor
        {
            get
            {
                if (Program.HexEditor == null)
                    Program.CreateHexEditor();
                return Program.HexEditor;
            }
            set
            {
                Program.HexEditor = value;
            }
        }
        private static BaseConvertorForm baseConvertorForm;
        public static BaseConvertorForm BaseConvertorForm
        {
            get
            {
                if (baseConvertorForm == null)
                    baseConvertorForm = new BaseConvertorForm();
                return baseConvertorForm;
            }
            set { baseConvertorForm = value; }
        }

        // Help
        private static XmlDocument lazyshell_xml;
        public static XmlDocument LAZYSHELL_xml
        {
            get
            {
                if (lazyshell_xml == null)
                {
                    lazyshell_xml = new XmlDocument();
                    lazyshell_xml.LoadXml(Resources.LAZYSHELL_xml);
                }
                return lazyshell_xml;
            }
        }

        // History
        public static string History
        {
            get { return settings.History; }
            set
            {
                var reader = new StringReader(value);
                string lines = "";
                string line;
                for (int i = 0; i < 256 && (line = reader.ReadLine()) != null; i++)
                    lines += line + "\r\n";
                settings.History = lines;
            }
        }
        public static bool Crashing { get; set; }

        #region ROM Header, Signature

        private static byte[] header;
        private static int romLength = 0;
        private static long checkSum = 0;
        public static string FileName { get; set; }
        public static bool Locked { get; set; }
        public static bool Published { get; set; }
        public static byte[] ROMHash { get; set; }

        #endregion

        #endregion

        #region Methods

        #region File Handling

        // Verification
        public static bool VerifyRom()
        {
            // If the warning is disabled, don't bother checking
            if (!Settings.Default.UnverifiedRomWarning)
                return true;
            // 32 bytes of binary data at 0xF800
            var original = new byte[]
            {
                0x0F,0x1A,0x4A,0x85,0x26,0x64,0x27,0x90,0x06,0xA5,0x28,0x9D,0x00,0x00,0xE8,0xC2,
                0x20,0xA5,0x28,0x9D,0x00,0x00,0xE8,0xE8,0xC6,0x26,0x10,0xF7,0xE2,0x20,0xC8,0x80
            };
            if (ROM.Length >= 0x400000)
            {
                if (Bits.Compare(original, Bits.GetBytes(ROM, 0xF800, 32)))
                    return true;
            }
            return MessageBox.Show("File does not appear to be a Super Mario RPG rom. Use it anyways?",
                "LAZY SHELL", MessageBoxButtons.YesNo) == DialogResult.Yes;
        }
        public static bool VerifyMD5Checksum()
        {
            var md5Hasher = MD5.Create();
            byte[] hash;
            if (ROMHash != null)
                hash = md5Hasher.ComputeHash(ROM);
            else
                return true;
            for (int i = 0; i < ROMHash.Length && i < hash.Length; i++)
                if (ROMHash[i] != hash[i])
                    return false;
            return true;
        }
        public static void CreateNewMD5Checksum()
        {
            var md5Hasher = MD5.Create();
            if (ROM != null)
                ROMHash = md5Hasher.ComputeHash(ROM);
        }
        public static string GameCode()
        {
            var encoding = Encoding.UTF8;
            return encoding.GetString(Bits.GetBytes(ROM, 0x7FB2, 4));
        }

        // Get file info
        public static string GetEditorNameWithoutPath()
        {
            int len = GetEditorPath().LastIndexOf('\\') + 1;
            return GetEditorPath().Substring(len, GetEditorPath().Length - len);
        }
        public static string GetEditorPath()
        {
            return Application.ExecutablePath;
        }
        public static string GetEditorPathWithoutFileName()
        {
            return GetEditorPath().Substring(0, GetEditorPath().LastIndexOf('\\') + 1);
        }
        public static string GetFileNameWithoutPath()
        {
            try
            {
                return FileName.Substring(FileName.LastIndexOf('\x5c') + 1);
            }
            catch
            {
                return null;
            }
        }
        public static string GetFileNameWithoutPathOrExtension()
        {
            string ret = FileName.Substring(FileName.LastIndexOf('\x5c') + 1);
            return ret.Substring(0, ret.LastIndexOf('.'));
        }
        public static long GetFileSize()
        {
            return romLength;
        }
        public static string GetPathWithoutFileName()
        {
            return FileName.Substring(0, FileName.LastIndexOf('\x5c') + 1);
        }
        public static string GetRomName()
        {
            var encoding = Encoding.UTF8;
            if (HeaderPresent())
                return encoding.GetString(Bits.GetBytes(ROM, 0x81c0, 21));
            return encoding.GetString(Bits.GetBytes(ROM, 0x7fc0, 21));
        }

        // Header
        public static bool HeaderPresent()
        {
            if ((romLength & (long)0x200) == 0x200)
                return true;
            else
                return false;
        }
        public static bool RemoveHeader()
        {
            header = null;
            if ((romLength & 0x200) != 0x200)
                return false;
            try
            {
                romLength -= 0x200;
                header = Bits.GetBytes(ROM, 0, 0x200);
                var temp = Bits.GetBytes(ROM, 0x200, romLength);
                ROM = temp;
                return true;
            }
            catch
            {
                MessageBox.Show("Error removing header; please remove manually.");
                return false;
            }
        }
        public static bool AddHeader()
        {
            if (header == null) return false;
            try
            {
                romLength += 0x200;
                var temp = new byte[ROM.Length];
                header.CopyTo(temp, 0);
                ROM.CopyTo(temp, 0x200);
                ROM = temp;
                return true;
            }
            catch
            {
                return false;
            }
        }

        // Read/write ROM
        public static bool ReadRom()
        {
        Retry:
            try
            {
                var fi = new FileInfo(FileName);
                romLength = (int)fi.Length;
                var fs = new FileStream(FileName, FileMode.Open, FileAccess.Read);
                var br = new BinaryReader(fs);
                ROM = br.ReadBytes(romLength);
                br.Close();
                fs.Close();
                if (settings.CreateBackupROM)
                {
                    var currentTime = DateTime.Now;
                    string backup = " (open @ " +
                        currentTime.Year.ToString("d4") +
                        currentTime.Month.ToString("d2") +
                        currentTime.Day.ToString("d2") + "_" +
                        currentTime.Hour.ToString("d2") + "h" +
                        currentTime.Minute.ToString("d2") + "m" +
                        currentTime.Second.ToString("d2") + "s" + ").bak";
                    if (settings.BackupROMDirectory == "")
                    {
                        var bw = new BinaryWriter(File.Create(FileName + backup));
                        bw.Write(ROM);
                        bw.Close();
                    }
                    else
                    {
                        var di = new DirectoryInfo(settings.BackupROMDirectory);
                        if (di.Exists)
                        {
                            var bw = new BinaryWriter(File.Create(settings.BackupROMDirectory + GetFileNameWithoutPath() + backup));
                            bw.Write(ROM);
                            bw.Close();
                        }
                        else
                            MessageBox.Show("Could not create backup ROM.\n\nThe backup ROM directory has been moved, renamed, or no longer exists.", "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                RemoveHeader();
                return true;
            }
            catch (Exception e)
            {
                if (MessageBox.Show("Lazy Shell was unable to load the rom.\n\n" + e.Message,
                    "LAZY SHELL", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) != DialogResult.Cancel)
                    goto Retry;
                FileName = "Invalid File";
                return false;
            }
        }
        public static bool WriteRom()
        {
            try
            {
                UpdateRomChecksum();
                AddHeader();
                var binWriter = new BinaryWriter(File.Open(FileName, FileMode.Create));
                binWriter.Write(ROM);
                binWriter.Close();
                if (Settings.Default.CreateBackupROMSave)
                {
                    var currentTime = DateTime.Now;
                    string backup = " (save @ " +
                        currentTime.Year.ToString("d4") + currentTime.Month.ToString("d2") + currentTime.Day.ToString("d2") + "_" +
                        currentTime.Hour.ToString("d2") + "h" + currentTime.Minute.ToString("d2") + "m" + currentTime.Second.ToString("d2") + "s" +
                        ").bak";
                    BinaryWriter bw;
                    if (settings.BackupROMDirectory == "")
                    {
                        bw = new BinaryWriter(File.Create(FileName + backup));
                        bw.Write(ROM);
                        bw.Close();
                    }
                    else
                    {
                        var di = new DirectoryInfo(settings.BackupROMDirectory);
                        if (di.Exists)
                        {
                            bw = new BinaryWriter(File.Create(settings.BackupROMDirectory + GetFileNameWithoutPath() + backup));
                            bw.Write(ROM);
                            bw.Close();
                        }
                        else
                            MessageBox.Show("Could not create backup ROM.\n\nThe backup ROM directory has been moved, renamed, or no longer exists.", "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                RemoveHeader();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lazy Shell was unable to write to the file.\n\n" + ex.Message, "LAZY SHELL");
                return false;
            }
        }

        // Checksum
        public static string GetRomChecksum()
        {
            checkSum = 0;
            for (int i = 0; i < ROM.Length; i++)
                checkSum += ROM[i];
            checkSum &= 0xFFFF;
            if ((ushort)checkSum == Bits.GetShort(ROM, 0x007FDE))
                return "0x" + checkSum.ToString("X") + " (OK)";
            else
                return "0x" + checkSum.ToString("X") + " (FAIL)";
        }
        public static ushort GetRomChecksumBin()
        {
            checkSum = 0;
            for (int i = 0; i < ROM.Length; i++)
                checkSum += ROM[i];
            checkSum &= 0xFFFF;
            return (ushort)checkSum;
        }
        public static void UpdateRomChecksum()
        {
            checkSum = 0;
            for (int i = 0; i < ROM.Length; i++)
                checkSum += ROM[i];
            checkSum &= 0xFFFF;
            Bits.SetShort(ROM, 0x007FDE, (int)(checkSum & 0xFFFF));
            Bits.SetShort(ROM, 0x007FDC, (int)(checkSum ^ 0xFFFF));
        }

        #endregion

        #region Data management

        // Load, Clear
        public static void LoadAll()
        {
            Animations.Model.LoadAll();
            Areas.Model.LoadAll();
            Attacks.Model.LoadAll();
            Audio.Model.LoadAll();
            Battlefields.Model.LoadAll();
            Dialogues.Model.LoadAll();
            Effects.Model.LoadAll();
            EventScripts.Model.LoadAll();
            Fonts.Model.LoadAll();
            Formations.Model.LoadAll();
            Intro.Model.LoadAll();
            Items.Model.LoadAll();
            LevelUps.Model.LoadAll();
            Magic.Model.LoadAll();
            Menus.Model.LoadAll();
            Minecart.Model.LoadAll();
            Monsters.Model.LoadAll();
            NewGame.Model.LoadAll();
            Shops.Model.LoadAll();
            Sprites.Model.LoadAll();
            WorldMaps.Model.LoadAll();
            object dummy;
            dummy = Project;
        }
        public static void ClearAll()
        {
            Animations.Model.ClearAll();
            Areas.Model.ClearAll();
            Attacks.Model.ClearAll();
            Audio.Model.ClearAll();
            Battlefields.Model.ClearAll();
            Dialogues.Model.ClearAll();
            Effects.Model.ClearAll();
            EventScripts.Model.ClearAll();
            Fonts.Model.ClearAll();
            Formations.Model.ClearAll();
            Intro.Model.ClearAll();
            Items.Model.ClearAll();
            LevelUps.Model.ClearAll();
            Magic.Model.ClearAll();
            Menus.Model.ClearAll();
            Minecart.Model.ClearAll();
            Monsters.Model.ClearAll();
            NewGame.Model.ClearAll();
            Shops.Model.ClearAll();
            Sprites.Model.ClearAll();
            WorldMaps.Model.ClearAll();
        }

        #endregion

        #endregion

        #region Project

        // Variables
        private static ProjectDB project;
        public static ProjectDB Project
        {
            get
            {
                if (project == null)
                    project = new ProjectDB();
                return project;
            }
            set
            {
                project = value;
            }
        }
        public static List<EList> ELists;
        public static string[] Keystrokes;
        public static string[] KeystrokesMenu;
        public static string[] KeystrokesDesc;

        // List collections
        public static void CreateListCollections()
        {
            // Create element lists
            ELists = new List<EList>();
            ELists.Add(new EList("Action Scripts", Lists.Copy(Lists.ActionLabels)));
            ELists.Add(new EList("Battle Events", Lists.Copy(Lists.BattleEvents)));
            ELists.Add(new EList("Battlefields", Lists.Copy(Lists.Battlefields)));
            ELists.Add(new EList("Effects", Lists.Copy(Lists.Effects)));
            ELists.Add(new EList("Event Scripts", Lists.Copy(Lists.EventLabels)));
            ELists.Add(new EList("Graphic Sets", Lists.Copy(Lists.GraphicSets)));
            ELists.Add(new EList("Levels", Lists.Copy(Lists.Areas)));
            ELists.Add(new EList("Samples", Lists.Copy(Lists.Samples)));
            ELists.Add(new EList("Shops", Lists.Copy(Lists.Shops)));
            ELists.Add(new EList("Collision Maps", Lists.Copy(Lists.CollisionMaps)));
            ELists.Add(new EList("Songs", Lists.Copy(Lists.SPCTracks)));
            ELists.Add(new EList("Sound FX (Event)", Lists.Copy(Lists.SPCEventSounds)));
            ELists.Add(new EList("Sound FX (Battle)", Lists.Copy(Lists.SPCBattleSounds)));
            ELists.Add(new EList("Sprites", Lists.Copy(Lists.Sprites)));
            ELists.Add(new EList("Tilesets", Lists.Copy(Lists.TileSetNames)));
            ELists.Add(new EList("Tilemaps", Lists.Copy(Lists.Tilemaps)));
            ELists.Add(new EList("World Maps", Lists.Copy(Lists.WorldMaps)));

            // Create deep copy of keystrokes
            Keystrokes = Lists.Copy(Lists.Keystrokes);
            KeystrokesMenu = Lists.Copy(Lists.KeystrokesMenu);
            KeystrokesDesc = Lists.Copy(Lists.KeystrokesDesc);
        }
        public static void ResetListCollections()
        {
            foreach (var elist in ELists)
                TransferListCollection(elist, elist.Name);
            Keystrokes.CopyTo(Lists.Keystrokes, 0);
            KeystrokesMenu.CopyTo(Lists.KeystrokesMenu, 0);
            KeystrokesDesc.CopyTo(Lists.KeystrokesDesc, 0);
        }
        public static void RefreshListCollections()
        {
            foreach (var elist in project.ELists)
                TransferListCollection(elist, elist.Name);
            project.Keystrokes.CopyTo(Lists.Keystrokes, 0);
            project.KeystrokesMenu.CopyTo(Lists.KeystrokesMenu, 0);
            project.KeystrokesDesc.CopyTo(Lists.KeystrokesDesc, 0);
        }
        private static void TransferListCollection(EList elist, string name)
        {
            switch (name)
            {
                case "Action Scripts": elist.Labels.CopyTo(Lists.ActionLabels, 0); break;
                case "Battle Events": elist.Labels.CopyTo(Lists.BattleEvents, 0); break;
                case "Battlefields": elist.Labels.CopyTo(Lists.Battlefields, 0); break;
                case "Effects": elist.Labels.CopyTo(Lists.Effects, 0); break;
                case "Event Scripts": elist.Labels.CopyTo(Lists.EventLabels, 0); break;
                case "Graphic Sets": elist.Labels.CopyTo(Lists.GraphicSets, 0); break;
                case "Levels": elist.Labels.CopyTo(Lists.Areas, 0); break;
                case "Samples": elist.Labels.CopyTo(Lists.Samples, 0); break;
                case "Shops": elist.Labels.CopyTo(Lists.Shops, 0); break;
                case "Collision Maps": elist.Labels.CopyTo(Lists.CollisionMaps, 0); break;
                case "Songs": elist.Labels.CopyTo(Lists.SPCTracks, 0); break;
                case "Sound FX (Event)": elist.Labels.CopyTo(Lists.SPCEventSounds, 0); break;
                case "Sound FX (Battle)": elist.Labels.CopyTo(Lists.SPCBattleSounds, 0); break;
                case "Sprites": elist.Labels.CopyTo(Lists.Sprites, 0); break;
                case "Tilesets": elist.Labels.CopyTo(Lists.TileSetNames, 0); break;
                case "Tilemaps": elist.Labels.CopyTo(Lists.Tilemaps, 0); break;
                case "World Maps": elist.Labels.CopyTo(Lists.WorldMaps, 0); break;
            }
        }

        // Check if project loaded
        public static bool CheckLoadedProject()
        {
            if (project == null)
            {
                if (MessageBox.Show("No project file has been loaded. Would you like to load a project file?",
                    "LAZY SHELL", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ProjectForm temp = Program.Project;
                    if (temp == null)
                        temp = new ProjectForm();
                    if (project == null)
                        temp.OpenProjectFile();
                }
                if (project == null)
                {
                    MessageBox.Show("A project file must be loaded to edit labels or keystrokes.",
                        "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    return false;
                }
            }
            return true;
        }

        #endregion
    }
}
