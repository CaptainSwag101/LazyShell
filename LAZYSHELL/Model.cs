using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms; // remove later
using System.IO;
using System.Security.Cryptography;
using LAZYSHELL.ScriptsEditor;
using LAZYSHELL.StatsEditor;
using LAZYSHELL.Compression;
using LAZYSHELL.DataStructures;
using LAZYSHELL.Properties;
namespace LAZYSHELL
{
    public class Model
    {
        private Program program; public Program Program { get { return this.program; } }

        private byte[] data;
        public byte[] Data
        {
            get { return this.data; }
            set
            {
                this.data = value;
                InitializeCompression(true);
            }
        }
        private long numBytes = 0;
        private string fileName;
        private LSCompression LSCompression = null;
        private LCDecomp lcDecomp;
        private Settings settings;

        private NotesDB notes; public NotesDB Notes { get { return this.notes; } set { this.notes = value; } }

        private StatsModel statsModel; public StatsModel StatsModel { get { return this.statsModel; } }
        private LevelModel levelModel; public LevelModel LevelModel { get { return this.levelModel; } }
        private ScriptsModel scriptsModel; public ScriptsModel ScriptsModel { get { return this.scriptsModel; } }
        private SpriteModel spriteModel; public SpriteModel SpriteModel { get { return this.spriteModel; } }
        private bool assembleStats = false; public bool AssembleStats { get { return assembleStats; } set { assembleStats = value; } }
        private bool assembleLevels = false; public bool AssembleLevels { get { return assembleLevels; } set { assembleLevels = value; } }
        private bool assembleSprites = false; public bool AssembleSprites { get { return assembleSprites; } set { assembleSprites = value; } }
        private bool assembleScripts = false; public bool AssembleScripts { get { return assembleScripts; } set { assembleScripts = value; } }
        private bool assembleFinal = false; public bool AssembleFinal { get { return assembleFinal; } set { assembleFinal = value; } }

        private byte[] dataHash;
        private long checkSum = 0;

        // sprites;
        private byte[] spriteGraphics; public byte[] SpriteGraphics { get { return this.spriteGraphics; } set { this.spriteGraphics = value; } }

        // levels
        private byte[][] graphicSets = new byte[272][]; public byte[][] GraphicSets { get { return graphicSets; } set { graphicSets = value; } }
        private byte[][] tileSets = new byte[125][]; public byte[][] TileSets { get { return tileSets; } set { tileSets = value; } }
        private byte[][] tileSetsBF = new byte[64][]; public byte[][] TileSetsBF { get { return tileSetsBF; } set { tileSetsBF = value; } }
        private byte[][] tileMaps = new byte[309][]; public byte[][] TileMaps { get { return tileMaps; } set { tileMaps = value; } }
        private byte[][] physicalMaps = new byte[120][]; public byte[][] PhysicalMaps { get { return physicalMaps; } set { physicalMaps = value; } }

        public bool[] EditGraphicSets = new bool[272];
        public bool[] EditTileSets = new bool[125];
        public bool[] EditTileSetsBF = new bool[64];
        public bool[] EditTileMaps = new bool[309];
        public bool[] EditPhysicalMaps = new bool[120];

        // overworld menu
        private byte[] menuGraphicSet; public byte[] MenuGraphicSet { get { return menuGraphicSet; } set { menuGraphicSet = value; } }
        private byte[] menuTileset; public byte[] MenuTileset { get { return menuTileset; } set { menuTileset = value; } }
        private byte[] menuFrame; public byte[] MenuFrame { get { return menuFrame; } set { menuFrame = value; } }

        public bool EditMenuTileSet;

        // world maps
        private byte[] worldMapGraphics; public byte[] WorldMapGraphics { get { return worldMapGraphics; } set { worldMapGraphics = value; } }
        private byte[] worldMapPalettes; public byte[] WorldMapPalettes { get { return worldMapPalettes; } set { worldMapPalettes = value; } }
        private byte[][] worldMapTileSets = new byte[9][]; public byte[][] WorldMapTileSets { get { return worldMapTileSets; } set { worldMapTileSets = value; } }
        private byte[] worldMapSprites; public byte[] WorldMapSprites { get { return worldMapSprites; } set { worldMapSprites = value; } }

        private byte[] dialogueGraphics; public byte[] DialogueGraphics { get { return dialogueGraphics; } set { dialogueGraphics = value; } }
        private byte[] battleDialogueTileset; public byte[] BattleDialogueTileset { get { return battleDialogueTileset; } set { battleDialogueTileset = value; } }

        // For Rom Signature
        private bool locked = false; public bool Locked { get { return this.locked; } set { this.locked = value; } } // Indicates that this rom is locked and cannot be edited, not for public use
        private bool published = false; public bool Published { get { return this.published; } set { this.published = value; } } // If true, show Author Splash screen on load

        public Model(Program program)
        {
            this.program = program;
            this.settings = Settings.Default;
        }

        /************************************************************************************
        * File Handling Methods
        * *********************************************************************************/
        public bool VerifyRom()
        {
            if (!LAZYSHELL.Properties.Settings.Default.UnverifiedRomWarning) // If the warning is disabled, dont bother checking
                return true;

            // 32 bytes of SMRPG Rom Data at 0xF800
            byte[] origional = new byte[]{0x0F,0x1A,0x4A,0x85,0x26,0x64,0x27,0x90,0x06,0xA5,0x28,0x9D,0x00,0x00,0xE8,0xC2,
                                          0x20,0xA5,0x28,0x9D,0x00,0x00,0xE8,0xE8,0xC6,0x26,0x10,0xF7,0xE2,0x20,0xC8,0x80};

            if (data.Length >= 0x400000)
            {
                if (BitManager.Compare(origional, BitManager.GetByteArray(data, 0xF800, 32)))
                    return true;
            }
            return MessageBox.Show("This file does not appear to be a Super Mario RPG rom. Use it anyways?", "LAZY SHELL", MessageBoxButtons.YesNo) == DialogResult.Yes;
        }
        public bool HeaderPresent()
        {
            if ((numBytes & (long)0x200) == 0x200)
                return true;
            else
                return false;
        }
        public bool RemoveHeader()
        {
            try
            {
                byte[] noHeader = new byte[numBytes - 0x200];

                for (int i = 0; i < numBytes - 0x200; i++)
                {
                    noHeader[i] = data[i + 0x200];

                }
                numBytes -= 0x200;
                data = noHeader;

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error removing header, please remove manually", "LAZY SHELL");
                return false;
            }
        }
        public long GetFileSize()
        {
            return numBytes;
        }
        public void SetFileName(string fileName)
        {
            this.fileName = fileName;
        }
        public string GetFileName()
        {
            return fileName;
        }
        public string GetFileNameWithoutPath()
        {
            try
            {
                return fileName.Substring(fileName.LastIndexOf('\x5c') + 1);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public string GetFileNameWithoutPathOrExtension()
        {
            string ret = fileName.Substring(fileName.LastIndexOf('\x5c') + 1);
            return ret.Substring(0, ret.LastIndexOf('.'));
        }
        public string GetPathWithoutFileName()
        {
            return fileName.Substring(0, fileName.LastIndexOf('\x5c') + 1);
        }
        public string GetRomName()
        {
            if (HeaderPresent())
                return ByteToStr(BitManager.GetByteArray(data, 0x81c0, 21));
            return ByteToStr(BitManager.GetByteArray(data, 0x7fc0, 21));
        }
        public string RomChecksum()
        {
            byte[] stamp = RemoveStamp();

            checkSum = 0;
            for (int i = 0; i < data.Length; i++)
                checkSum += data[i];
            checkSum &= 0xFFFF;

            RestoreStamp(stamp);

            if ((ushort)checkSum == BitManager.GetShort(data, 0x007FDE))
                return "0x" + checkSum.ToString("X") + " (OK)";
            else
                return "0x" + checkSum.ToString("X") + " (FAIL)";
        }
        public ushort RomChecksumBin()
        {
            byte[] stamp = RemoveStamp();

            checkSum = 0;
            for (int i = 0; i < data.Length; i++)
                checkSum += data[i];
            checkSum &= 0xFFFF;

            RestoreStamp(stamp);

            return (ushort)checkSum;
        }
        public string GetEditorPath()
        {
            return Application.ExecutablePath;
        }
        public string GetEditorPathWithoutFileName()
        {
            return GetEditorPath().Substring(0, GetEditorPath().LastIndexOf('\\') + 1);
        }
        public string GetEditorNameWithoutPath()
        {
            int len = GetEditorPath().LastIndexOf('\\') + 1;
            return GetEditorPath().Substring(len, GetEditorPath().Length - len);
        }
        /*
         * This code does not work because we essentially are 
         * modifying the data after calculating the new checksum thus changing it
         */
        public void CalculateAndSetNewRomChecksum()
        {
            int check = 0;

            for (int i = 0; i < data.Length; i++)
                check += data[i];
            check &= 0xFFFF;

            BitManager.SetShort(data, 0x007FDE, (ushort)check);
        }
        public void CreateNewMD5Checksum()
        {
            MD5 md5Hasher = MD5.Create();

            if (data != null)
                dataHash = md5Hasher.ComputeHash(data);
        }
        public bool VerifyMD5Checksum()
        {
            MD5 md5Hasher = MD5.Create();
            byte[] hash;

            if (dataHash != null)
                hash = md5Hasher.ComputeHash(data);
            else
                return true;

            for (int i = 0; i < dataHash.Length && i < hash.Length; i++)
                if (dataHash[i] != hash[i])
                    return false;

            return true;
        }
        public string GameCode()
        {
            return ByteToStr(BitManager.GetByteArray(data, 0x7FB2, 4));
        }
        public bool ReadRom()
        {
            try
            {
                FileInfo fInfo = new FileInfo(fileName);
                numBytes = fInfo.Length;
                FileStream fStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fStream);
                data = br.ReadBytes((int)numBytes);
                br.Close();
                fStream.Close();

                if (settings.CreateBackupROM)
                {
                    DateTime currentTime = DateTime.Now;
                    string backup = " (open @ " +
                        currentTime.Year.ToString("d4") + currentTime.Month.ToString("d2") + currentTime.Day.ToString("d2") + "_" +
                        currentTime.Hour.ToString("d2") + "h" + currentTime.Minute.ToString("d2") + "m" + currentTime.Second.ToString("d2") + "s" +
                        ").bak";
                    BinaryWriter bw;
                    if (settings.BackupROMDirectory == "")
                    {
                        bw = new BinaryWriter(File.Create(fileName + backup));
                        bw.Write(data);
                        bw.Close();
                    }
                    else
                    {
                        DirectoryInfo di = new DirectoryInfo(settings.BackupROMDirectory);
                        if (di.Exists)
                        {
                            bw = new BinaryWriter(File.Create(settings.BackupROMDirectory + GetFileNameWithoutPath() + backup));
                            bw.Write(data);
                            bw.Close();
                        }
                        else
                            MessageBox.Show("Could not create backup ROM.\n\nThe backup ROM directory has been moved, renamed, or no longer exists.", "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                return true;

            }
            catch (Exception e)
            {
                MessageBox.Show("Lazy Shell was unable to load the rom.\n\n" + e.Message, "LAZY SHELL");

                fileName = "Invalid File";
                return false;
            }

        }
        public bool WriteRom()
        {
            try
            {
                BinaryWriter binWriter = new BinaryWriter(File.Open(fileName, FileMode.Create));
                binWriter.Write(data);
                binWriter.Close();

                if (Settings.Default.CreateBackupROMSave)
                {
                    DateTime currentTime = DateTime.Now;
                    string backup = " (save @ " +
                        currentTime.Year.ToString("d4") + currentTime.Month.ToString("d2") + currentTime.Day.ToString("d2") + "_" +
                        currentTime.Hour.ToString("d2") + "h" + currentTime.Minute.ToString("d2") + "m" + currentTime.Second.ToString("d2") + "s" +
                        ").bak";
                    BinaryWriter bw;
                    if (settings.BackupROMDirectory == "")
                    {
                        bw = new BinaryWriter(File.Create(fileName + backup));
                        bw.Write(data);
                        bw.Close();
                    }
                    else
                    {
                        DirectoryInfo di = new DirectoryInfo(settings.BackupROMDirectory);
                        if (di.Exists)
                        {
                            bw = new BinaryWriter(File.Create(settings.BackupROMDirectory + GetFileNameWithoutPath() + backup));
                            bw.Write(data);
                            bw.Close();
                        }
                        else
                            MessageBox.Show("Could not create backup ROM.\n\nThe backup ROM directory has been moved, renamed, or no longer exists.", "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lazy Shell was unable to write to the file.\n\n" + ex.Message, "LAZY SHELL");
                return false;
            }

        }

        public byte[] Decompress(int offset, int maxSize)
        {
            //return LSCompression.Decompress(offset, maxSize);
            return lcDecomp.Decompress(offset, maxSize);
        }
        public int Compress(byte[] source, byte[] dest)
        {
            //return LSCompression.Compress(source, dest, 0);
            return lcDecomp.Compress(source, dest);
        }
        public void ClearLevelData()
        {
            for (int i = 0; i < graphicSets.Length; i++)
                graphicSets[i] = null;
            for (int i = 0; i < tileSets.Length; i++)
                tileSets[i] = null;
            for (int i = 0; i < tileSetsBF.Length; i++)
                tileSetsBF[i] = null;
            for (int i = 0; i < tileMaps.Length; i++)
                tileMaps[i] = null;
            for (int i = 0; i < physicalMaps.Length; i++)
                physicalMaps[i] = null;
        }

        public void CreateStatsModel()
        {
            InitializeCompression(false);
            statsModel = new StatsEditor.StatsModel(data);
        }
        public void CreateLevelModel()
        {
            InitializeCompression(false);
            levelModel = new LevelModel(data, this);
        }
        public void CreateScriptsModel()
        {
            scriptsModel = new ScriptsModel(data, this);
        }
        public void CreateSpritesModel()
        {
            InitializeCompression(false);
            spriteGraphics = BitManager.GetByteArray(data, 0x280000, 0xB4000);
            spriteModel = new SpriteModel(data, this);
        }
        private void InitializeCompression(bool refresh)
        {
            if (refresh == false && this.LSCompression != null /* && this.lcDecomp != null */)
                return;

            this.LSCompression = new LSCompression(this.data);
            this.lcDecomp = new LCDecomp(data);
        }
        private string ByteToStr(byte[] toStr)
        {
            System.Text.Encoding encoding = System.Text.Encoding.UTF8;

            return encoding.GetString(toStr);
        }

        public void ClearModel()
        {
            this.statsModel = null;
            this.levelModel = null;
            this.scriptsModel = null;
            this.spriteModel = null;
            this.LSCompression = null;
            this.lcDecomp = null;
        }
        public LAZYSHELL.Encryption.Stamp DecryptRomSignature()
        {
            // Decrypt and get the stamp
            LAZYSHELL.Encryption.Cipher cipher = new LAZYSHELL.Encryption.Cipher(this.data, this);
            LAZYSHELL.Encryption.Stamp stamp = cipher.DecryptSignature();

            this.locked = stamp.Locked;
            this.published = stamp.Published;

            return stamp;
        }
        public void EncryptRomSignature()
        {
            LAZYSHELL.Encryption.Cipher cipher = new LAZYSHELL.Encryption.Cipher(this.data, this);
            LAZYSHELL.Encryption.Stamp stamp = DecryptRomSignature(); // Get stamp Info

            if (!stamp.Invalidated) // if valid stamp
            {
                cipher.EncryptSignature(stamp, false);
            }
        }
        public void ViewSignature(LAZYSHELL.Encryption.Stamp signature)
        {
            LAZYSHELL.Encryption.SignatureViewer sView = new LAZYSHELL.Encryption.SignatureViewer(signature, this, false);
            sView.Show();
        }
        public void ViewSignature()
        {
            ViewSignature(DecryptRomSignature());
        }

        private byte[] RemoveStamp()
        {
            byte[] stamp = BitManager.GetByteArray(data, 0x3DE000, 0x700);
            for (int i = 0; i < 0x700; i++)
            {
                data[0x3DE000 + i] = 0;
            }

            return stamp;
        }
        private void RestoreStamp(byte[] stamp)
        {
            BitManager.SetByteArray(data, 0x3DE000, stamp);
        }
    }

}
