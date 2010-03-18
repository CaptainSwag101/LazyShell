using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.ComponentModel;

namespace SMRPGED
{
    public partial class Levels
    {
        private int exportProgress = 0;
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
        private void ExportLevelImages_DoWork(object sender, DoWorkEventArgs e)
        {
            if (start < 0 || start > 512 || count < 1 || count > 512 - start)
            {
                MessageBox.Show("Argument error in ExportLevelImages() method, please report this");
                return;
            }

            string dataPath = "level.";

            path += "\\" + model.GetFileNameWithoutPath() + " - Level Images\\";

            // Create Level Data directory
            if (!CreateDir(path))
                return;

            path += dataPath;

            LevelLayer layr;
            Tileset set;
            TileMap map;
            LevelMap lmap;
            PaletteSet palSet;
            int[] pixels;
            Image image = null;
            int i = 0;
            float fuckYou;
            int percent;

            for (i = start; i < start + count; i++)
            {
                if (ExportLevelImages.CancellationPending) break;

                layr = levels[i].Layer;
                lmap = levelMaps[levels[i].LevelMap];
                palSet = paletteSets[levelMaps[levels[i].LevelMap].PaletteSet];

                set = new Tileset(lmap, palSet, model);
                map = new TileMap(lmap, palSet, set, layr, prioritySets, model);

                pixels = map.Mainscreen;

                unsafe
                {
                    fixed (void* firstPixel = &pixels[0])
                    {
                        IntPtr ip = new IntPtr(firstPixel);
                        if (image != null)
                            image.Dispose();
                        image = new Bitmap(1024, 1024, 1024 * 4, System.Drawing.Imaging.PixelFormat.Format32bppPArgb, ip);

                    }
                }

                pictureBoxLevel.CreateGraphics().DrawImage(new Bitmap(image), 0, 0);

                fuckYou = ((float)(progressBar1.Value) / progressBar1.Maximum) * 100;
                percent = (int)fuckYou;

                image.Save(path + i.ToString("X3") + ".png", System.Drawing.Imaging.ImageFormat.Png);

                ExportLevelImages.ReportProgress(percent);
            }
        }
        private void ExportLevelImages_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pictureBoxLevel.Invalidate();
            exportProgress = 0;
            this.Update();

            this.label27.Text = "";
            this.panel1.Enabled = true;
            this.toolStrip1.Enabled = true;
            this.menuStrip1.Enabled = true;
            this.TopMost = false;

            this.label67.Visible = true;
            this.panel8.Visible = false;
            this.labelExportPercent.Visible = false;
            this.cancelButton.Visible = false;
            this.cancelButton.Enabled = false;
            this.panel1.Enabled = true;
        }
        private void ExportLevelImages_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.label27.Text = "Saving level #" + (start + exportProgress).ToString("X3");
            this.labelExportPercent.Text = e.ProgressPercentage.ToString() + "%";
            progressBar1.PerformStep();
            exportProgress++;
        }

        /*
            * This method uses object serialization to export the level data for a variable number of levels
            * 
            * Will need to be updated to include all relevant level data after
            *      ie. Objects and events, ect
            * 
            * Currently only supports Layers and Maps
            * 
            * @param start - the level to start exporting data at
            * @param count - the number of levels to export data for
            */
        private void ExportLevelData_DoWork(object sender, DoWorkEventArgs e)
        {
            if (start < 0 || start > 512 || count < 1 || count > 512 - start)
            {
                MessageBox.Show("Argument error in ExportLevelData() method, please report this");
                return;
            }

            SerializedLevel sLevel = new SerializedLevel();
            LevelMap lMap;

            float fuckYou;
            int percent;

            this.tileMap.AssembleIntoModel();

            string dataPath = "level.";

            path += "\\" + model.GetFileNameWithoutPath() + " - Level Data\\";

            // Create Level Data directory
            if (!CreateDir(path))
                return;

            Stream s;
            BinaryFormatter b = new BinaryFormatter();
            s = File.Create(path + "Do Not Modify This Directory Or Files Contained Within.txt");
            s.Close();

            path += dataPath;

            try
            {

                for (int i = start; i < start + count; i++)
                {
                    if (ExportLevelData.CancellationPending) break;

                    // Create Level Data Level directory
                    if (!CreateDir(path + i.ToString("X3") + "\\")) // Change this to i
                        return;

                    // Create the file to store the level data
                    s = File.Create(path + i.ToString("X3") + "\\" + "levelData.dat"); // Create level data file

                    // Set the LevelLayer field
                    levels[i].Layer.Data = null;
                    sLevel.levelLayer = levels[i].Layer;

                    // Set the LevelMap field
                    sLevel.levelMapNum = levels[i].LevelMap;
                    lMap = levelMaps[levels[i].LevelMap];
                    lMap.Data = null;// Clear the data field
                    sLevel.levelMap = lMap;// Add it to serialized level data object

                    // Set the tileSet fields (uncompressed data from buffers)
                    sLevel.tileSetL1 = model.TileSets[lMap.TileSetL1 + 0x20];
                    sLevel.tileSetL2 = model.TileSets[lMap.TileSetL2 + 0x20];
                    sLevel.tileSetL3 = model.TileSets[lMap.TileSetL3];

                    // Set the tileMap fields (uncompressed data from buffers)
                    sLevel.tileMapL1 = model.TileMaps[lMap.TileMapL1 + 0x40];
                    sLevel.tileMapL2 = model.TileMaps[lMap.TileMapL2 + 0x40];
                    sLevel.tileMapL3 = model.TileMaps[lMap.TileMapL3];

                    // Set the physical map fields
                    sLevel.physicalMap = model.PhysicalMaps[lMap.PhysicalMap];

                    // Set the LevelNPCs field
                    levels[i].LevelNPCs.Data = null;
                    sLevel.levelNPCs = levels[i].LevelNPCs;

                    // Set the LevelExits field
                    levels[i].LevelExits.Data = null;
                    sLevel.levelExits = levels[i].LevelExits;

                    // Set the LevelEvents field
                    levels[i].LevelEvents.Data = null;
                    sLevel.levelEvents = levels[i].LevelEvents;

                    // Set the LevelOverlaps field
                    levels[i].LevelOverlaps.Data = null;
                    sLevel.levelOverlaps = levels[i].LevelOverlaps;

                    // Serialize object
                    b.Serialize(s, sLevel);
                    s.Close();

                    // Reset Data fields
                    lMap.Data = model.Data;
                    levels[i].Layer.Data = model.Data;
                    levels[i].LevelNPCs.Data = model.Data;
                    levels[i].LevelExits.Data = model.Data;
                    levels[i].LevelEvents.Data = model.Data;
                    levels[i].LevelOverlaps.Data = model.Data;

                    fuckYou = ((float)(progressBar1.Value) / progressBar1.Maximum) * 100;
                    percent = (int)fuckYou;

                    ExportLevelData.ReportProgress(percent);
                }
            }
            catch
            {
                MessageBox.Show("There was a problem exporting");
            }
        }
        private void ExportLevelData_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.label27.Text = "Saving level #" + (start + exportProgress).ToString("X3");
            this.labelExportPercent.Text = "%" + e.ProgressPercentage.ToString();
            progressBar1.PerformStep();
            exportProgress++;
        }
        private void ExportLevelData_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pictureBoxLevel.Invalidate();
            exportProgress = 0;
            this.Update();

            this.label27.Text = "";
            this.panel1.Enabled = true;
            this.toolStrip1.Enabled = true;
            this.menuStrip1.Enabled = true;
            this.TopMost = false;

            this.label67.Visible = true;
            this.panel8.Visible = false;
            this.labelExportPercent.Visible = false;
            this.cancelButton.Visible = false;
            this.cancelButton.Enabled = false;
            this.panel1.Enabled = true;
        }

        /*
           * This method uses object serialization to import level data for a variable number of levels
           * 
           * Will need to be updated to include all relevant level data after
           *      ie. Objects and events, ect
           * 
           * Currently only supports Layers and Maps
           * 
           * @param start - the level to start exporting data at
           * @param count - the number of levels to export data for
           */
        private void ImportLevelData_DoWork(object sender, DoWorkEventArgs e)
        {
            if (start < 0 || start > 512 || count < 1 || count > 512 - start)
            {
                MessageBox.Show("Argument error in ImportLevelData() method, please report this");
                return;
            }
            string dataPath = "level.";

            SerializedLevel sLevel = new SerializedLevel();
            LevelMap lMap;

            path += "\\";

            Stream s;
            BinaryFormatter b = new BinaryFormatter();

            float fuckYou;
            int percent;

            if (count == 1)
            {
                try
                {
                    s = File.OpenRead(path + "levelData.dat");
                    sLevel = (SerializedLevel)b.Deserialize(s);
                    s.Close();

                    // Set the LevelLayer
                    levels[start].Layer = sLevel.levelLayer;
                    levels[start].Layer.LevelNum = start;
                    levels[start].Layer.Data = model.Data;

                    // Set the LevelMap
                    levels[start].LevelMap = sLevel.levelMapNum;
                    lMap = sLevel.levelMap;
                    lMap.Data = model.Data;
                    levelMaps[levels[start].LevelMap] = lMap;
                    //levelMaps[levels[start].LevelMap].LevelMapNum = sLevel.levelMapNum;

                    // Set the TileSets
                    model.TileSets[lMap.TileSetL1 + 0x20] = sLevel.tileSetL1;
                    model.TileSets[lMap.TileSetL2 + 0x20] = sLevel.tileSetL2;
                    model.TileSets[lMap.TileSetL3] = sLevel.tileSetL3;

                    model.EditTileSets[lMap.TileSetL1 + 0x20] = true;
                    model.EditTileSets[lMap.TileSetL2 + 0x20] = true;
                    model.EditTileSets[lMap.TileSetL3] = true;

                    // Set the TileMaps
                    model.TileMaps[lMap.TileMapL1 + 0x40] = sLevel.tileMapL1;
                    model.TileMaps[lMap.TileMapL2 + 0x40] = sLevel.tileMapL2;
                    model.TileMaps[lMap.TileMapL3] = sLevel.tileMapL3;

                    model.EditTileMaps[lMap.TileMapL1 + 0x40] = true;
                    model.EditTileMaps[lMap.TileMapL2 + 0x40] = true;
                    model.EditTileMaps[lMap.TileMapL3] = true;

                    // Set the PhysicalMap
                    model.PhysicalMaps[lMap.PhysicalMap] = sLevel.physicalMap;

                    model.EditPhysicalMaps[lMap.PhysicalMap] = true;

                    // Set the LevelNPCs
                    levels[start].LevelNPCs = sLevel.levelNPCs;
                    levels[start].LevelNPCs.LevelNum = start;
                    levels[start].LevelNPCs.Data = model.Data;

                    // Set the LevelExits
                    levels[start].LevelExits = sLevel.levelExits;
                    levels[start].LevelExits.LevelNum = start;
                    levels[start].LevelExits.Data = model.Data;

                    // Set The LevelEvents
                    levels[start].LevelEvents = sLevel.levelEvents;
                    levels[start].LevelEvents.LevelNum = start;
                    levels[start].LevelEvents.Data = model.Data;

                    // Set the leveloverlaps
                    levels[start].LevelOverlaps = sLevel.levelOverlaps;
                    levels[start].LevelOverlaps.LevelNum = start;
                    levels[start].LevelOverlaps.Data = model.Data;

                    fuckYou = ((float)(progressBar1.Value) / progressBar1.Maximum) * 100;
                    percent = (int)fuckYou;

                    ImportLevelData.ReportProgress(percent);
                }
                catch
                {
                    MessageBox.Show("There was a problem loading level data. Verify that the level data is correctly named and in the specified folder");
                    return;
                }
            }
            else
            {
                try
                {
                    path += dataPath;

                    for (int i = start; i < start + count; i++)
                    {
                        if (ImportLevelData.CancellationPending) break;

                        if (!File.Exists(path + i.ToString("X3") + "\\levelData.dat"))
                        {
                            fuckYou = ((float)(progressBar1.Value) / progressBar1.Maximum) * 100;
                            percent = (int)fuckYou;
                            ImportLevelData.ReportProgress(percent);
                            continue;
                        }

                        s = File.OpenRead(path + i.ToString("X3") + "\\levelData.dat");

                        sLevel = (SerializedLevel)b.Deserialize(s);
                        s.Close();

                        // Set the LevelLayer
                        levels[i].Layer = sLevel.levelLayer;
                        levels[i].Layer.Data = model.Data;

                        // Set the LevelMap
                        levels[i].LevelMap = sLevel.levelMapNum;
                        lMap = sLevel.levelMap;
                        lMap.Data = model.Data;
                        levelMaps[levels[i].LevelMap] = lMap;

                        // Set the TileSets
                        model.TileSets[lMap.TileSetL1 + 0x20] = sLevel.tileSetL1;
                        model.TileSets[lMap.TileSetL2 + 0x20] = sLevel.tileSetL2;
                        model.TileSets[lMap.TileSetL3] = sLevel.tileSetL3;

                        model.EditTileSets[lMap.TileSetL1 + 0x20] = true;
                        model.EditTileSets[lMap.TileSetL2 + 0x20] = true;
                        model.EditTileSets[lMap.TileSetL3] = true;

                        // Set the TileMaps
                        model.TileMaps[lMap.TileMapL1 + 0x40] = sLevel.tileMapL1;
                        model.TileMaps[lMap.TileMapL2 + 0x40] = sLevel.tileMapL2;
                        model.TileMaps[lMap.TileMapL3] = sLevel.tileMapL3;

                        model.EditTileMaps[lMap.TileMapL1 + 0x40] = true;
                        model.EditTileMaps[lMap.TileMapL2 + 0x40] = true;
                        model.EditTileMaps[lMap.TileMapL3] = true;

                        // Set the PhysicalMap
                        model.PhysicalMaps[lMap.PhysicalMap] = sLevel.physicalMap;

                        model.EditPhysicalMaps[lMap.PhysicalMap] = true;

                        // Set the LevelNPCs
                        levels[i].LevelNPCs = sLevel.levelNPCs;
                        levels[i].LevelNPCs.Data = model.Data;

                        // Set the LevelExits
                        levels[i].LevelExits = sLevel.levelExits;
                        levels[i].LevelExits.Data = model.Data;

                        // Set The LevelEvents
                        levels[i].LevelEvents = sLevel.levelEvents;
                        levels[i].LevelEvents.Data = model.Data;

                        fuckYou = ((float)(progressBar1.Value) / progressBar1.Maximum) * 100;
                        percent = (int)fuckYou;

                        ImportLevelData.ReportProgress(percent);
                    }
                }
                catch
                {
                    MessageBox.Show("There was a problem loading level data. Verify that the " +
                    "level data folders are correctly named and that the level data files are in the correctly named " +
                    " subfolders of the specified folder");
                }
            }
        }
        private void ImportLevelData_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pictureBoxLevel.Invalidate();
            exportProgress = 0;
            this.Update();

            fullUpdate = true;
            UpdateLevel();

            this.label27.Text = "";
            this.panel1.Enabled = true;
            this.toolStrip1.Enabled = true;
            this.menuStrip1.Enabled = true;
            this.TopMost = false;

            this.label67.Visible = true;
            this.panel8.Visible = false;
            this.labelExportPercent.Visible = false;
            this.cancelButton.Visible = false;
            this.cancelButton.Enabled = false;
            this.panel1.Enabled = true;
        }
        private void ImportLevelData_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.label27.Text = "Importing #" + (start + exportProgress).ToString("X3") + "..";

            this.labelExportPercent.Text = "%" + e.ProgressPercentage.ToString();
            progressBar1.PerformStep();
            exportProgress++;
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
        public void RefreshLevelName()
        {
            updatingLevel = true;
            levelName.BeginUpdate();
            levelName.Items.Clear();
            levelName.Items.AddRange(universal.LevelNames);
            levelName.SelectedIndex = currentLevel;
            levelName.EndUpdate();
            updatingLevel = false;
        }
    }
}
