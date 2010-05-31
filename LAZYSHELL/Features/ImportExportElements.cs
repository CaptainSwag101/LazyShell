using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Forms;
using LAZYSHELL.Properties;
using LAZYSHELL.ScriptsEditor;
using LAZYSHELL.ScriptsEditor.Commands;

namespace LAZYSHELL
{
    public partial class ImportExportElements : Form
    {
        private Settings settings;
        private object element;
        private int currentIndex;
        private string fullPath;
        private Type type;

        private ProgressBar progressBar;

        public ImportExportElements(object element, int currentIndex, string title)
        {
            this.settings = Settings.Default;
            this.element = element;
            this.currentIndex = currentIndex;
            this.type = element.GetType();

            this.TopLevel = true;

            InitializeComponent();

            this.Text = title;
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
                MessageBox.Show("There was a problem creating directory \"" + dir + "\".", "LAZY SHELL");
                return false;
            }
        }

        private void radioButtonCurrent_CheckedChanged(object sender, EventArgs e)
        {
            browseAll.Enabled = false;
            textBoxAll.Enabled = false;
            browseCurrent.Enabled = true;
            textBoxCurrent.Enabled = true;

            if (radioButtonCurrent.Checked)
            {
                buttonOK.Enabled = textBoxCurrent.Text != "";
            }
            fullPath = textBoxCurrent.Text;
        }
        private void radioButtonAll_CheckedChanged(object sender, EventArgs e)
        {
            browseCurrent.Enabled = false;
            textBoxCurrent.Enabled = false;
            browseAll.Enabled = true;
            textBoxAll.Enabled = true;
            buttonOK.Enabled = true;

            if (radioButtonAll.Checked)
            {
                buttonOK.Enabled = textBoxAll.Text != "";
            }
            fullPath = textBoxAll.Text;
        }
        private void browseCurrent_Click(object sender, EventArgs e)
        {
            if (this.Text.Substring(0, 6) == "EXPORT")
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Title = "Select directory to " + this.Text;
                if (this.Text == "EXPORT LEVEL DATA...") saveFileDialog.FileName = "levelData." + currentIndex.ToString("d3") + ".dat";
                if (this.Text == "EXPORT EVENT SCRIPTS...") saveFileDialog.FileName = "eventScript." + currentIndex.ToString("d4") + ".bin";
                if (this.Text == "EXPORT ACTION SCRIPTS...") saveFileDialog.FileName = "actionScript." + currentIndex.ToString("d4") + ".bin";
                if (this.Text == "EXPORT BATTLE SCRIPTS...") saveFileDialog.FileName = "battleScript." + currentIndex.ToString("d3") + ".bin";
                if (this.Text == "EXPORT SPRITE ANIMATIONS...") saveFileDialog.FileName = "spriteAnimation." + currentIndex.ToString("d3") + ".bin";
                if (this.Text == "EXPORT EFFECT ANIMATIONS...") saveFileDialog.FileName = "effectAnimation." + currentIndex.ToString("d3") + ".bin";
                if (this.Text != "EXPORT LEVEL DATA...") saveFileDialog.Filter = "Binary files (*.bin)|*.bin|All files (*.*)|*.*";
                else saveFileDialog.Filter = "Data files (*.dat)|*.dat|All files (*.*)|*.*";
                saveFileDialog.FilterIndex = 0;
                saveFileDialog.RestoreDirectory = true;

                if (saveFileDialog.ShowDialog() != DialogResult.OK) return;
                textBoxCurrent.Text = saveFileDialog.FileName;
            }
            else
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.InitialDirectory = settings.LastRomPath;
                openFileDialog.Title = "Select file from which to " + this.Text;
                if (this.Text == "IMPORT LEVEL DATA...")
                    openFileDialog.Filter = "Data files (*.dat)|*.dat|All files (*.*)|*.*";
                if (this.Text == "IMPORT EVENT SCRIPTS..." ||
                    this.Text == "IMPORT ACTION SCRIPTS..." ||
                    this.Text == "IMPORT BATTLE SCRIPTS..." ||
                    this.Text == "IMPORT SPRITE ANIMATIONS..." ||
                    this.Text == "IMPORT EFFECT ANIMATIONS...")
                    openFileDialog.Filter = "Binary files (*.bin)|*.bin|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 0;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() != DialogResult.OK) return;
                textBoxCurrent.Text = openFileDialog.FileName;
            }
            fullPath = textBoxCurrent.Text;
            buttonOK.Enabled = true;
        }
        private void browseAll_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

            folderBrowserDialog.SelectedPath = settings.LastDirectory;
            if (this.Text.Substring(0, 6) == "EXPORT")
                folderBrowserDialog.Description = "Select directory to which to " + this.Text;
            else
                folderBrowserDialog.Description = "Select directory from which to " + this.Text;

            // Display the openFile dialog.
            DialogResult result = folderBrowserDialog.ShowDialog();

            if (result != DialogResult.OK) return;

            settings.LastDirectory = folderBrowserDialog.SelectedPath;
            textBoxAll.Text = folderBrowserDialog.SelectedPath;
            fullPath = textBoxAll.Text;
            buttonOK.Enabled = true;
        }
        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (this.Text == "EXPORT LEVEL DATA...")
            {
                progressBar = new ProgressBar(
                    ((Levels)element).Model, ((Levels)element).Model.Data,
                    "EXPORTING LEVEL DATA...", 509, ExportLevelData);
                progressBar.Show();

                this.Enabled = false;
                ExportLevelData.RunWorkerAsync();
            }
            if (this.Text == "IMPORT LEVEL DATA...")
            {
                progressBar = new ProgressBar(
                    ((Levels)element).Model, ((Levels)element).Model.Data,
                    "IMPORTING LEVEL DATA...", 509, ImportLevelData);
                progressBar.Show();

                this.Enabled = false;
                ImportLevelData.RunWorkerAsync();
            }
            if (this.Text == "EXPORT BATTLE SCRIPTS...") ExportBattleScript();
            if (this.Text == "IMPORT BATTLE SCRIPTS...") ImportBattleScript();
            if (this.Text == "EXPORT EVENT SCRIPTS...")
            {
                progressBar = new ProgressBar(
                    ((Scripts)element).Model, ((Scripts)element).Model.Data,
                    "EXPORTING EVENT SCRIPTS...", 4095, ExportEventScripts);
                progressBar.Show();

                this.Enabled = false;
                ExportEventScripts.RunWorkerAsync();
            }
            if (this.Text == "IMPORT EVENT SCRIPTS...")
            {
                progressBar = new ProgressBar(
                    ((Scripts)element).Model, ((Scripts)element).Model.Data,
                    "IMPORTING EVENT SCRIPTS...", 4095, ImportEventScripts);
                progressBar.Show();

                this.Enabled = false;
                ImportEventScripts.RunWorkerAsync();
            }
            if (this.Text == "EXPORT ACTION SCRIPTS...") ExportActionScript();
            if (this.Text == "IMPORT ACTION SCRIPTS...") ImportActionScript();
            if (this.Text == "EXPORT SPRITE ANIMATIONS...") ExportAnimation();
            if (this.Text == "IMPORT SPRITE ANIMATIONS...") ImportAnimation();
            if (this.Text == "EXPORT EFFECT ANIMATIONS...") ExportAnimation();
            if (this.Text == "IMPORT EFFECT ANIMATIONS...") ImportAnimation();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void ExportLevelData_DoWork(object sender, DoWorkEventArgs e)
        {
            Levels levels = (Levels)element;

            SerializedLevel sLevel = new SerializedLevel();
            LevelMap lMap;
            levels.TileMap.AssembleIntoModel();

            Stream s;
            BinaryFormatter b = new BinaryFormatter();

            if (radioButtonCurrent.Checked)
            {
                try
                {
                    // Create the file to store the level data
                    s = File.Create(fullPath);

                    // Set the LevelLayer field
                    levels.ThisLevels[currentIndex].Layer.Data = null;
                    sLevel.levelLayer = levels.ThisLevels[currentIndex].Layer;

                    // Set the LevelMap field
                    sLevel.levelMapNum = levels.ThisLevels[currentIndex].LevelMap;
                    lMap = levels.LevelMaps[levels.ThisLevels[currentIndex].LevelMap];
                    lMap.Data = null;// Clear the data field
                    sLevel.levelMap = lMap;// Add it to serialized level data object

                    // Set the tileSet fields (uncompressed data from buffers)
                    sLevel.tileSetL1 = levels.Model.TileSets[lMap.TileSetL1 + 0x20];
                    sLevel.tileSetL2 = levels.Model.TileSets[lMap.TileSetL2 + 0x20];
                    sLevel.tileSetL3 = levels.Model.TileSets[lMap.TileSetL3];

                    // Set the tileMap fields (uncompressed data from buffers)
                    sLevel.tileMapL1 = levels.Model.TileMaps[lMap.TileMapL1 + 0x40];
                    sLevel.tileMapL2 = levels.Model.TileMaps[lMap.TileMapL2 + 0x40];
                    sLevel.tileMapL3 = levels.Model.TileMaps[lMap.TileMapL3];

                    // Set the physical map fields
                    sLevel.physicalMap = levels.Model.PhysicalMaps[lMap.PhysicalMap];

                    // Set the LevelNPCs field
                    levels.ThisLevels[currentIndex].LevelNPCs.Data = null;
                    sLevel.levelNPCs = levels.ThisLevels[currentIndex].LevelNPCs;

                    // Set the LevelExits field
                    levels.ThisLevels[currentIndex].LevelExits.Data = null;
                    sLevel.levelExits = levels.ThisLevels[currentIndex].LevelExits;

                    // Set the LevelEvents field
                    levels.ThisLevels[currentIndex].LevelEvents.Data = null;
                    sLevel.levelEvents = levels.ThisLevels[currentIndex].LevelEvents;

                    // Set the LevelOverlaps field
                    levels.ThisLevels[currentIndex].LevelOverlaps.Data = null;
                    sLevel.levelOverlaps = levels.ThisLevels[currentIndex].LevelOverlaps;

                    // Serialize object
                    b.Serialize(s, sLevel);
                    s.Close();

                    // Reset Data fields
                    lMap.Data = levels.Model.Data;
                    levels.ThisLevels[currentIndex].Layer.Data = levels.Model.Data;
                    levels.ThisLevels[currentIndex].LevelNPCs.Data = levels.Model.Data;
                    levels.ThisLevels[currentIndex].LevelExits.Data = levels.Model.Data;
                    levels.ThisLevels[currentIndex].LevelEvents.Data = levels.Model.Data;
                    levels.ThisLevels[currentIndex].LevelOverlaps.Data = levels.Model.Data;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("There was a problem exporting.\n\n" + ex.Message, "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                try
                {
                    fullPath += "\\" + levels.Model.GetFileNameWithoutPath() + " - Level Data\\";
                    if (!CreateDir(fullPath))
                        return;
                    for (int i = 0; i < 510; i++)
                    {
                        if (ExportLevelData.CancellationPending) break;

                        // Create the file to store the level data
                        s = File.Create(fullPath + "levelData." + i.ToString("d3") + ".dat"); // Create level data file

                        // Set the LevelLayer field
                        levels.ThisLevels[currentIndex].Layer.Data = null;
                        sLevel.levelLayer = levels.ThisLevels[currentIndex].Layer;

                        // Set the LevelMap field
                        sLevel.levelMapNum = levels.ThisLevels[currentIndex].LevelMap;
                        lMap = levels.LevelMaps[levels.ThisLevels[currentIndex].LevelMap];
                        lMap.Data = null;// Clear the data field
                        sLevel.levelMap = lMap;// Add it to serialized level data object

                        // Set the tileSet fields (uncompressed data from buffers)
                        sLevel.tileSetL1 = levels.Model.TileSets[lMap.TileSetL1 + 0x20];
                        sLevel.tileSetL2 = levels.Model.TileSets[lMap.TileSetL2 + 0x20];
                        sLevel.tileSetL3 = levels.Model.TileSets[lMap.TileSetL3];

                        // Set the tileMap fields (uncompressed data from buffers)
                        sLevel.tileMapL1 = levels.Model.TileMaps[lMap.TileMapL1 + 0x40];
                        sLevel.tileMapL2 = levels.Model.TileMaps[lMap.TileMapL2 + 0x40];
                        sLevel.tileMapL3 = levels.Model.TileMaps[lMap.TileMapL3];

                        // Set the physical map fields
                        sLevel.physicalMap = levels.Model.PhysicalMaps[lMap.PhysicalMap];

                        // Set the LevelNPCs field
                        levels.ThisLevels[currentIndex].LevelNPCs.Data = null;
                        sLevel.levelNPCs = levels.ThisLevels[currentIndex].LevelNPCs;

                        // Set the LevelExits field
                        levels.ThisLevels[currentIndex].LevelExits.Data = null;
                        sLevel.levelExits = levels.ThisLevels[currentIndex].LevelExits;

                        // Set the LevelEvents field
                        levels.ThisLevels[currentIndex].LevelEvents.Data = null;
                        sLevel.levelEvents = levels.ThisLevels[currentIndex].LevelEvents;

                        // Set the LevelOverlaps field
                        levels.ThisLevels[currentIndex].LevelOverlaps.Data = null;
                        sLevel.levelOverlaps = levels.ThisLevels[currentIndex].LevelOverlaps;

                        // Serialize object
                        b.Serialize(s, sLevel);
                        s.Close();

                        // Reset Data fields
                        lMap.Data = levels.Model.Data;
                        levels.ThisLevels[currentIndex].Layer.Data = levels.Model.Data;
                        levels.ThisLevels[currentIndex].LevelNPCs.Data = levels.Model.Data;
                        levels.ThisLevels[currentIndex].LevelExits.Data = levels.Model.Data;
                        levels.ThisLevels[currentIndex].LevelEvents.Data = levels.Model.Data;
                        levels.ThisLevels[currentIndex].LevelOverlaps.Data = levels.Model.Data;

                        ExportLevelData.ReportProgress(i);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("There was a problem exporting.\n\n" + ex.Message, "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void ExportLevelData_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar.PerformStep("EXPORTING LEVEL DATA FOR LEVEL #" + e.ProgressPercentage.ToString("d3"));
        }
        private void ExportLevelData_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBar.Close();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private void ImportLevelData_DoWork(object sender, DoWorkEventArgs e)
        {
            Levels levels = (Levels)element;

            SerializedLevel sLevel = new SerializedLevel();
            LevelMap lMap;

            Stream s;
            BinaryFormatter b = new BinaryFormatter();

            if (radioButtonCurrent.Checked)
            {
                try
                {
                    s = File.OpenRead(fullPath);
                    sLevel = (SerializedLevel)b.Deserialize(s);
                    s.Close();

                    // Set the LevelLayer
                    levels.ThisLevels[currentIndex].Layer = sLevel.levelLayer;
                    levels.ThisLevels[currentIndex].Layer.LevelNum = currentIndex;
                    levels.ThisLevels[currentIndex].Layer.Data = levels.Model.Data;

                    // Set the LevelMap
                    levels.ThisLevels[currentIndex].LevelMap = sLevel.levelMapNum;
                    lMap = sLevel.levelMap;
                    lMap.Data = levels.Model.Data;
                    levels.LevelMaps[levels.ThisLevels[currentIndex].LevelMap] = lMap;
                    //levelMaps[levels.ThisLevels[start].LevelMap].LevelMapNum = sLevel.levelMapNum;

                    // Set the TileSets
                    levels.Model.TileSets[lMap.TileSetL1 + 0x20] = sLevel.tileSetL1;
                    levels.Model.TileSets[lMap.TileSetL2 + 0x20] = sLevel.tileSetL2;
                    levels.Model.TileSets[lMap.TileSetL3] = sLevel.tileSetL3;

                    levels.Model.EditTileSets[lMap.TileSetL1 + 0x20] = true;
                    levels.Model.EditTileSets[lMap.TileSetL2 + 0x20] = true;
                    levels.Model.EditTileSets[lMap.TileSetL3] = true;

                    // Set the TileMaps
                    levels.Model.TileMaps[lMap.TileMapL1 + 0x40] = sLevel.tileMapL1;
                    levels.Model.TileMaps[lMap.TileMapL2 + 0x40] = sLevel.tileMapL2;
                    levels.Model.TileMaps[lMap.TileMapL3] = sLevel.tileMapL3;

                    levels.Model.EditTileMaps[lMap.TileMapL1 + 0x40] = true;
                    levels.Model.EditTileMaps[lMap.TileMapL2 + 0x40] = true;
                    levels.Model.EditTileMaps[lMap.TileMapL3] = true;

                    // Set the PhysicalMap
                    levels.Model.PhysicalMaps[lMap.PhysicalMap] = sLevel.physicalMap;

                    levels.Model.EditPhysicalMaps[lMap.PhysicalMap] = true;

                    // Set the LevelNPCs
                    levels.ThisLevels[currentIndex].LevelNPCs = sLevel.levelNPCs;
                    levels.ThisLevels[currentIndex].LevelNPCs.LevelNum = currentIndex;
                    levels.ThisLevels[currentIndex].LevelNPCs.Data = levels.Model.Data;

                    // Set the LevelExits
                    levels.ThisLevels[currentIndex].LevelExits = sLevel.levelExits;
                    levels.ThisLevels[currentIndex].LevelExits.LevelNum = currentIndex;
                    levels.ThisLevels[currentIndex].LevelExits.Data = levels.Model.Data;

                    // Set The LevelEvents
                    levels.ThisLevels[currentIndex].LevelEvents = sLevel.levelEvents;
                    levels.ThisLevels[currentIndex].LevelEvents.LevelNum = currentIndex;
                    levels.ThisLevels[currentIndex].LevelEvents.Data = levels.Model.Data;

                    // Set the leveloverlaps
                    levels.ThisLevels[currentIndex].LevelOverlaps = sLevel.levelOverlaps;
                    levels.ThisLevels[currentIndex].LevelOverlaps.LevelNum = currentIndex;
                    levels.ThisLevels[currentIndex].LevelOverlaps.Data = levels.Model.Data;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("There was a problem importing.\n\n" + ex.Message, "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                try
                {
                    fullPath += "\\";

                    for (int i = 0; i < 510; i++)
                    {
                        if (ImportLevelData.CancellationPending) break;

                        if (!File.Exists(fullPath + "levelData." + i.ToString("d3") + ".dat"))
                        {
                            ImportLevelData.ReportProgress(i);
                            continue;
                        }

                        s = File.OpenRead(fullPath + "levelData." + i.ToString("d3") + ".dat");

                        sLevel = (SerializedLevel)b.Deserialize(s);
                        s.Close();

                        // Set the LevelLayer
                        levels.ThisLevels[i].Layer = sLevel.levelLayer;
                        levels.ThisLevels[i].Layer.Data = levels.Model.Data;

                        // Set the LevelMap
                        levels.ThisLevels[i].LevelMap = sLevel.levelMapNum;
                        lMap = sLevel.levelMap;
                        lMap.Data = levels.Model.Data;
                        levels.LevelMaps[levels.ThisLevels[i].LevelMap] = lMap;

                        // Set the TileSets
                        levels.Model.TileSets[lMap.TileSetL1 + 0x20] = sLevel.tileSetL1;
                        levels.Model.TileSets[lMap.TileSetL2 + 0x20] = sLevel.tileSetL2;
                        levels.Model.TileSets[lMap.TileSetL3] = sLevel.tileSetL3;

                        levels.Model.EditTileSets[lMap.TileSetL1 + 0x20] = true;
                        levels.Model.EditTileSets[lMap.TileSetL2 + 0x20] = true;
                        levels.Model.EditTileSets[lMap.TileSetL3] = true;

                        // Set the TileMaps
                        levels.Model.TileMaps[lMap.TileMapL1 + 0x40] = sLevel.tileMapL1;
                        levels.Model.TileMaps[lMap.TileMapL2 + 0x40] = sLevel.tileMapL2;
                        levels.Model.TileMaps[lMap.TileMapL3] = sLevel.tileMapL3;

                        levels.Model.EditTileMaps[lMap.TileMapL1 + 0x40] = true;
                        levels.Model.EditTileMaps[lMap.TileMapL2 + 0x40] = true;
                        levels.Model.EditTileMaps[lMap.TileMapL3] = true;

                        // Set the PhysicalMap
                        levels.Model.PhysicalMaps[lMap.PhysicalMap] = sLevel.physicalMap;

                        levels.Model.EditPhysicalMaps[lMap.PhysicalMap] = true;

                        // Set the LevelNPCs
                        levels.ThisLevels[i].LevelNPCs = sLevel.levelNPCs;
                        levels.ThisLevels[i].LevelNPCs.Data = levels.Model.Data;

                        // Set the LevelExits
                        levels.ThisLevels[i].LevelExits = sLevel.levelExits;
                        levels.ThisLevels[i].LevelExits.Data = levels.Model.Data;

                        // Set The LevelEvents
                        levels.ThisLevels[i].LevelEvents = sLevel.levelEvents;
                        levels.ThisLevels[i].LevelEvents.Data = levels.Model.Data;

                        ImportLevelData.ReportProgress(i);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("There was a problem importing.\n\n" + ex.Message, "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void ImportLevelData_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar.PerformStep("IMPORTING LEVEL DATA FOR LEVEL #" + e.ProgressPercentage.ToString("d3"));
        }
        private void ImportLevelData_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBar.Close();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void ExportBattleScript()
        {
            Scripts scripts = (Scripts)element;
            scripts.ScriptsModel.AssembleAllBattleScripts();

            FileStream fs;
            BinaryWriter bw;
            if (radioButtonCurrent.Checked)
            {
                try
                {
                    // Create the file to store the level data
                    fs = new FileStream(fullPath, FileMode.Create, FileAccess.ReadWrite); // Create data file
                    bw = new BinaryWriter(fs);
                    bw.Write(scripts.BattleScripts[currentIndex].Script);
                    bw.Close();
                    fs.Close();

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("There was a problem exporting.\n\n" + ex.Message, "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                fullPath += "\\" + scripts.Model.GetFileNameWithoutPath() + " - Battle Scripts\\";
                if (!CreateDir(fullPath))
                    return;
                try
                {
                    for (int i = 0; i <= 255; i++)
                    {
                        // Create the file to store the level data
                        fs = new FileStream(fullPath + "battleScript." + i.ToString("d3") + ".bin", FileMode.Create, FileAccess.ReadWrite); // Create data file
                        bw = new BinaryWriter(fs);
                        bw.Write(scripts.BattleScripts[i].Script);
                        bw.Close();
                        fs.Close();
                    }
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("There was a problem exporting.\n\n" + ex.Message, "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void ImportBattleScript()
        {
            Scripts scripts = (Scripts)element;
            scripts.ScriptsModel.AssembleAllBattleScripts();

            FileStream fs;
            BinaryReader br;
            if (radioButtonCurrent.Checked)
            {
                try
                {
                    fs = File.OpenRead(fullPath);
                    br = new BinaryReader(fs);
                    scripts.BattleScripts[currentIndex].Script = new byte[fs.Length];
                    br.ReadBytes((int)fs.Length).CopyTo(scripts.BattleScripts[currentIndex].Script, 0);
                    br.Close();
                    fs.Close();

                    scripts.ParseBattleScript(scripts.BattleScripts[currentIndex]);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("There was a problem importing.\n\n" + ex.Message, "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                try
                {
                    for (int i = 0; i <= 255; i++)
                    {
                        if (!File.Exists(fullPath + "battleScript." + i.ToString("d3") + ".bin"))
                            continue;
                        fs = File.OpenRead(fullPath + "battleScript." + i.ToString("d3") + ".bin");
                        br = new BinaryReader(fs);
                        scripts.BattleScripts[i].Script = new byte[fs.Length];
                        br.ReadBytes((int)fs.Length).CopyTo(scripts.BattleScripts[i].Script, 0);
                        br.Close();
                        fs.Close();

                        scripts.ParseBattleScript(scripts.BattleScripts[i]);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("There was a problem importing.\n\n" + ex.Message, "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void ExportActionScript()
        {
            Scripts scripts = (Scripts)element;
            scripts.ScriptsModel.AssembleAllActionScripts();

            FileStream fs;
            BinaryWriter bw;
            if (radioButtonCurrent.Checked)
            {
                try
                {
                    // Create the file to store the level data
                    fs = new FileStream(fullPath, FileMode.Create, FileAccess.ReadWrite); // Create data file
                    bw = new BinaryWriter(fs);
                    bw.Write(scripts.ActionScripts[currentIndex].ActionQueueData);
                    bw.Close();
                    fs.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("There was a problem exporting.\n\n" + ex.Message, "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                fullPath += "\\" + scripts.Model.GetFileNameWithoutPath() + " - Action Scripts\\";
                if (!CreateDir(fullPath))
                    return;
                try
                {
                    for (int i = 0; i <= 1023; i++)
                    {
                        // Create the file to store the level data
                        fs = new FileStream(fullPath + "actionScript." + i.ToString("d4") + ".bin", FileMode.Create, FileAccess.ReadWrite); // Create data file
                        bw = new BinaryWriter(fs);
                        bw.Write(scripts.ActionScripts[i].ActionQueueData);
                        bw.Close();
                        fs.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("There was a problem exporting.\n\n" + ex.Message, "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void ImportActionScript()
        {
            Scripts scripts = (Scripts)element;
            scripts.ScriptsModel.AssembleAllActionScripts();

            FileStream fs;
            BinaryReader br;
            int baseOffset, len;
            EventActionCommand eac;

            if (radioButtonCurrent.Checked)
            {
                try
                {
                    fs = File.OpenRead(fullPath);
                    br = new BinaryReader(fs);

                    baseOffset = scripts.ActionScripts[currentIndex].Offset;
                    len = scripts.ActionScripts[currentIndex].ActionQueueLength;

                    scripts.ActionScripts[currentIndex].ActionQueueData = new byte[fs.Length];
                    br.ReadBytes((int)fs.Length).CopyTo(scripts.ActionScripts[currentIndex].ActionQueueData, 0);
                    br.Close();
                    fs.Close();

                    scripts.TreeViewWrapper.ScriptDelta = scripts.ActionScripts[currentIndex].ActionQueueLength - len;
                    scripts.ActionScripts[currentIndex].Data = scripts.Model.Data;

                    scripts.ActionScripts[currentIndex].ParseActionQueue(scripts.ActionScripts[currentIndex].ActionQueueData);

                    ScriptIterator it = new ScriptIterator(scripts.ActionScripts[currentIndex]);
                    while (!it.IsDone)
                    {
                        eac = it.Next();
                        eac.Offset = (eac.Offset - scripts.ActionScripts[currentIndex].Offset) + baseOffset;
                        eac.OriginalOffset = eac.Offset;
                    }

                    scripts.ActionScripts[currentIndex].Offset = baseOffset;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("There was a problem importing.\n\n" + ex.Message, "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                try
                {
                    for (int i = 0; i <= 1023; i++)
                    {
                        if (!File.Exists(fullPath + "actionScript." + i.ToString("d4") + ".bin"))
                            continue;
                        fs = File.OpenRead(fullPath + "actionScript." + i.ToString("d4") + ".bin");
                        br = new BinaryReader(fs);
                        scripts.ActionScripts[i].ActionQueueData = new byte[fs.Length];
                        br.ReadBytes((int)fs.Length).CopyTo(scripts.ActionScripts[i].ActionQueueData, 0);
                        br.Close();
                        fs.Close();

                        scripts.ActionScripts[i].Data = scripts.Model.Data;

                        scripts.ActionScripts[i].ParseActionQueue(scripts.ActionScripts[i].ActionQueueData);
                    }
                    scripts.TreeViewWrapper.ScriptDelta = 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("There was a problem importing.\n\n" + ex.Message, "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ExportEventScripts_DoWork(object sender, DoWorkEventArgs e)
        {
            Scripts scripts = (Scripts)element;
            scripts.ScriptsModel.AssembleAllEventScripts();

            FileStream fs;
            BinaryWriter bw;
            if (radioButtonCurrent.Checked)
            {
                try
                {
                    // Create the file to store the level data
                    fs = new FileStream(fullPath, FileMode.Create, FileAccess.ReadWrite); // Create data file
                    bw = new BinaryWriter(fs);
                    bw.Write(scripts.EventScripts[currentIndex].Script);
                    bw.Close();
                    fs.Close();

                    ExportEventScripts.ReportProgress(currentIndex);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("There was a problem exporting.\n\n" + ex.Message, "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                fullPath += "\\" + scripts.Model.GetFileNameWithoutPath() + " - Event Scripts\\";
                if (!CreateDir(fullPath))
                    return;
                try
                {
                    for (int i = 0; i <= 4095; i++)
                    {
                        if (ExportEventScripts.CancellationPending) break;

                        // Create the file to store the level data
                        fs = new FileStream(fullPath + "eventScript." + i.ToString("d4") + ".bin", FileMode.Create, FileAccess.ReadWrite); // Create data file
                        bw = new BinaryWriter(fs);
                        bw.Write(scripts.EventScripts[i].Script);
                        bw.Close();
                        fs.Close();

                        ExportEventScripts.ReportProgress(i);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("There was a problem exporting.\n\n" + ex.Message, "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void ExportEventScripts_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar.PerformStep("EXPORTING EVENT SCRIPTS FOR EVENT #" + e.ProgressPercentage.ToString("d4"));
        }
        private void ExportEventScripts_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBar.Close();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private void ImportEventScripts_DoWork(object sender, DoWorkEventArgs e)
        {
            Scripts scripts = (Scripts)element;
            scripts.ScriptsModel.AssembleAllEventScripts();

            FileStream fs;
            BinaryReader br;
            int baseOffset, len;
            EventActionCommand eac;

            if (radioButtonCurrent.Checked)
            {
                try
                {
                    fs = File.OpenRead(fullPath);
                    br = new BinaryReader(fs);

                    baseOffset = scripts.EventScripts[currentIndex].BaseOffset;
                    len = scripts.EventScripts[currentIndex].ScriptLength;

                    scripts.EventScripts[currentIndex].ClearAll();
                    scripts.EventScripts[currentIndex].Script = new byte[fs.Length];
                    br.ReadBytes((int)fs.Length).CopyTo(scripts.EventScripts[currentIndex].Script, 0);
                    br.Close();
                    fs.Close();

                    scripts.TreeViewWrapper.ScriptDelta = scripts.EventScripts[currentIndex].ScriptLength - len;
                    scripts.EventScripts[currentIndex].Data = scripts.Model.Data;

                    scripts.EventScripts[currentIndex].ParseEventScript(scripts.EventScripts[currentIndex].Script);

                    ScriptIterator it = new ScriptIterator(scripts.EventScripts[currentIndex]);
                    while (!it.IsDone)
                    {
                        eac = it.Next();
                        eac.Offset = (eac.Offset - scripts.EventScripts[currentIndex].BaseOffset) + baseOffset;
                        eac.OriginalOffset = eac.Offset;
                    }

                    scripts.EventScripts[currentIndex].BaseOffset = baseOffset;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("There was a problem importing.\n\n" + ex.Message, "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                try
                {
                    for (int i = 0; i <= 4095; i++)
                    {
                        if (ImportEventScripts.CancellationPending) break;

                        if (!File.Exists(fullPath + "eventScript." + i.ToString("d4") + ".bin"))
                        {
                            ImportEventScripts.ReportProgress(i);
                            continue;
                        }
                        fs = File.OpenRead(fullPath + "eventScript." + i.ToString("d4") + ".bin");
                        br = new BinaryReader(fs);

                        scripts.EventScripts[i].ClearAll();
                        scripts.EventScripts[i].Script = new byte[fs.Length];
                        br.ReadBytes((int)fs.Length).CopyTo(scripts.EventScripts[i].Script, 0);
                        br.Close();
                        fs.Close();

                        scripts.EventScripts[i].Data = scripts.Model.Data;

                        scripts.EventScripts[i].ParseEventScript(scripts.EventScripts[i].Script);

                        ImportEventScripts.ReportProgress(i);
                    }
                    scripts.TreeViewWrapper.ScriptDelta = 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("There was a problem importing.\n\n" + ex.Message, "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void ImportEventScripts_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar.PerformStep("IMPORTING EVENT SCRIPTS FOR EVENT #" + e.ProgressPercentage.ToString("d4"));
        }
        private void ImportEventScripts_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBar.Close();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void ExportAnimation()
        {
            Sprites sprites = (Sprites)element;
            sprites.AssembleAllAnimations();

            FileStream fs;
            BinaryWriter bw;
            if (radioButtonCurrent.Checked)
            {
                try
                {
                    // Create the file to store the level data
                    fs = new FileStream(fullPath, FileMode.Create, FileAccess.ReadWrite); // Create data file
                    bw = new BinaryWriter(fs);
                    bw.Write(sprites.Animations[currentIndex].SM);
                    bw.Close();
                    fs.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("There was a problem exporting.\n\n" + ex.Message, "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                try
                {
                    fullPath += "\\" + sprites.Model.GetFileNameWithoutPath() + " - Sprite Animations\\";
                    if (!CreateDir(fullPath))
                        return;
                    for (int i = 0; i < sprites.Animations.Length; i++)
                    {
                        fs = new FileStream(fullPath + "spriteAnimation." + i.ToString("d3") + ".bin", FileMode.Create, FileAccess.ReadWrite); // Create data file
                        bw = new BinaryWriter(fs);
                        bw.Write(sprites.Animations[i].SM);
                        bw.Close();
                        fs.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("There was a problem exporting.\n\n" + ex.Message, "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void ImportAnimation()
        {
            Sprites sprites = (Sprites)element;
            sprites.AssembleAllAnimations();

            FileStream fs;
            BinaryReader br;
            if (radioButtonCurrent.Checked)
            {
                try
                {
                    fs = File.OpenRead(fullPath);
                    br = new BinaryReader(fs);
                    sprites.Animations[currentIndex].SM = br.ReadBytes((int)fs.Length);
                    sprites.Animations[currentIndex].Clear();
                    sprites.Animations[currentIndex].Refresh();
                    br.Close();
                    fs.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("There was a problem importing.\n\n" + ex.Message, "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                try
                {
                    for (int i = 0; i < sprites.Animations.Length; i++)
                    {
                        if (!File.Exists(fullPath + "spriteAnimation." + i.ToString("d3") + ".bin"))
                            continue;
                        fs = File.OpenRead(fullPath + "spriteAnimation." + i.ToString("d3") + ".bin");
                        br = new BinaryReader(fs);
                        sprites.Animations[i].SM = br.ReadBytes((int)fs.Length);
                        sprites.Animations[i].Clear();
                        sprites.Animations[i].Refresh();
                        br.Close();
                        fs.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("There was a problem importing.\n\n" + ex.Message, "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void ExportE_Animation()
        {
            Sprites sprites = (Sprites)element;
            sprites.AssembleAllE_Animations();

            FileStream fs;
            BinaryWriter bw;
            if (radioButtonCurrent.Checked)
            {
                try
                {
                    // Create the file to store the level data
                    fs = new FileStream(fullPath, FileMode.Create, FileAccess.ReadWrite); // Create data file
                    bw = new BinaryWriter(fs);
                    bw.Write(sprites.E_animations[currentIndex].SM);
                    bw.Close();
                    fs.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("There was a problem exporting.\n\n" + ex.Message, "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                try
                {
                    fullPath += "\\" + sprites.Model.GetFileNameWithoutPath() + " - Effect Animations\\";
                    if (!CreateDir(fullPath))
                        return;
                    for (int i = 0; i < sprites.E_animations.Length; i++)
                    {
                        fs = new FileStream(fullPath + "effectAnimation." + i.ToString("d3") + ".bin", FileMode.Create, FileAccess.ReadWrite); // Create data file
                        bw = new BinaryWriter(fs);
                        bw.Write(sprites.E_animations[i].SM);
                        bw.Close();
                        fs.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("There was a problem exporting.\n\n" + ex.Message, "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void ImportE_Animation()
        {
            Sprites sprites = (Sprites)element;
            sprites.AssembleAllE_Animations();

            FileStream fs;
            BinaryReader br;
            if (radioButtonCurrent.Checked)
            {
                try
                {
                    fs = File.OpenRead(fullPath);
                    br = new BinaryReader(fs);
                    sprites.E_animations[currentIndex].SM = br.ReadBytes((int)fs.Length);
                    sprites.E_animations[currentIndex].Clear();
                    sprites.E_animations[currentIndex].Refresh();
                    br.Close();
                    fs.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("There was a problem importing.\n\n" + ex.Message, "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                try
                {
                    for (int i = 0; i < sprites.E_animations.Length; i++)
                    {
                        if (!File.Exists(fullPath + "effectAnimation." + i.ToString("d3") + ".bin"))
                            continue;
                        fs = File.OpenRead(fullPath + "effectAnimation." + i.ToString("d3") + ".bin");
                        br = new BinaryReader(fs);
                        sprites.E_animations[i].SM = br.ReadBytes((int)fs.Length);
                        sprites.E_animations[i].Clear();
                        sprites.E_animations[i].Refresh();
                        br.Close();
                        fs.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("There was a problem importing.\n\n" + ex.Message, "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
