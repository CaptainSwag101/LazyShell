using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using LAZYSHELL.Properties;
using LAZYSHELL.ScriptsEditor;
using LAZYSHELL.ScriptsEditor.Commands;

namespace LAZYSHELL
{
    public partial class IOElements : Form
    {
        private Model model = State.Instance.Model;
        private Settings settings = Settings.Default;
        private object element;
        private int currentIndex;
        private string fullPath;
        private Type type;

        public IOElements(object element, int currentIndex, string title)
        {
            this.element = element;
            this.currentIndex = currentIndex;
            this.type = element.GetType();

            this.TopLevel = true;

            InitializeComponent();

            this.Text = title;
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
            TextInfo textInfo = Thread.CurrentThread.CurrentCulture.TextInfo;
            string name = this.Text.ToLower().Substring(7, this.Text.Length - 7 - 4);
            string ext = ".dat";
            string filter = "Data files (*.dat)|*.dat|All files (*.*)|*.*";
            if (name == "sample")
            {
                ext = ".wav";
                filter = "Wav files (*.wav)|*.wav|All files (*.*)|*.*";
            }
            if (this.Text.Substring(0, 6) == "EXPORT")
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Title = "Select directory to export to";
                saveFileDialog.Filter = filter;
                try
                {
                    saveFileDialog.FileName = name + "." + currentIndex.ToString(
                        "d" + ((object[])element).Length.ToString().Length) + ext;
                }
                catch
                {
                    saveFileDialog.FileName = name + "." + currentIndex.ToString("d4") + ext;
                }
                saveFileDialog.FilterIndex = 0;
                saveFileDialog.RestoreDirectory = true;

                if (saveFileDialog.ShowDialog() != DialogResult.OK) return;
                textBoxCurrent.Text = saveFileDialog.FileName;
            }
            else
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.InitialDirectory = settings.LastRomPath;
                openFileDialog.Title = "Select file to import from";
                openFileDialog.Filter = filter;
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
                folderBrowserDialog.Description = "Select directory to export to";
            else
                folderBrowserDialog.Description = "Select directory to import from";

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
            #region Levels
            if (this.Text == "EXPORT LEVEL DATA...")
            {
                this.Enabled = false;
                if (radioButtonCurrent.Checked)
                {
                    // create the serialized level
                    SerializedLevel sLevel = new SerializedLevel();
                    sLevel.levelLayer = model.Levels[currentIndex].Layer;
                    sLevel.levelMapNum = model.Levels[currentIndex].LevelMap;
                    LevelMap lMap = model.LevelMaps[model.Levels[currentIndex].LevelMap];
                    sLevel.levelMap = lMap;// Add it to serialized level data object
                    sLevel.tileSetL1 = model.TileSets[lMap.TileSetL1 + 0x20];
                    sLevel.tileSetL2 = model.TileSets[lMap.TileSetL2 + 0x20];
                    sLevel.tileSetL3 = model.TileSets[lMap.TileSetL3];
                    sLevel.tileMapL1 = model.TileMaps[lMap.TileMapL1 + 0x40];
                    sLevel.tileMapL2 = model.TileMaps[lMap.TileMapL2 + 0x40];
                    sLevel.tileMapL3 = model.TileMaps[lMap.TileMapL3];
                    sLevel.physicalMap = model.SolidityMaps[lMap.PhysicalMap];
                    sLevel.levelNPCs = model.Levels[currentIndex].LevelNPCs;
                    sLevel.levelExits = model.Levels[currentIndex].LevelExits;
                    sLevel.levelEvents = model.Levels[currentIndex].LevelEvents;
                    sLevel.levelOverlaps = model.Levels[currentIndex].LevelOverlaps;
                    // finally export the serialized levels
                    Do.Export(sLevel, null, fullPath);
                }
                else
                {
                    // create the serialized level
                    SerializedLevel[] sLevels = new SerializedLevel[510];
                    for (int i = 0; i < sLevels.Length; i++)
                    {
                        sLevels[i] = new SerializedLevel();
                        sLevels[i].levelLayer = model.Levels[i].Layer;
                        sLevels[i].levelMapNum = model.Levels[i].LevelMap;
                        LevelMap lMap = model.LevelMaps[model.Levels[i].LevelMap];
                        sLevels[i].levelMap = lMap;// Add it to serialized level data object
                        sLevels[i].tileSetL1 = model.TileSets[lMap.TileSetL1 + 0x20];
                        sLevels[i].tileSetL2 = model.TileSets[lMap.TileSetL2 + 0x20];
                        sLevels[i].tileSetL3 = model.TileSets[lMap.TileSetL3];
                        sLevels[i].tileMapL1 = model.TileMaps[lMap.TileMapL1 + 0x40];
                        sLevels[i].tileMapL2 = model.TileMaps[lMap.TileMapL2 + 0x40];
                        sLevels[i].tileMapL3 = model.TileMaps[lMap.TileMapL3];
                        sLevels[i].physicalMap = model.SolidityMaps[lMap.PhysicalMap];
                        sLevels[i].levelNPCs = model.Levels[i].LevelNPCs;
                        sLevels[i].levelExits = model.Levels[i].LevelExits;
                        sLevels[i].levelEvents = model.Levels[i].LevelEvents;
                        sLevels[i].levelOverlaps = model.Levels[i].LevelOverlaps;
                    }
                    // finally export the serialized levels
                    Do.Export(sLevels,
                        fullPath + "\\" + model.GetFileNameWithoutPath() + " - Levels\\" + "level", "LEVEL", true);
                }
            }
            if (this.Text == "IMPORT LEVEL DATA...")
            {
                this.Enabled = false;
                if (radioButtonCurrent.Checked)
                {
                    SerializedLevel sLevel = new SerializedLevel();
                    sLevel = (SerializedLevel)Do.Import(sLevel, fullPath);
                    model.Levels[currentIndex].Layer = sLevel.levelLayer;
                    model.Levels[currentIndex].LevelMap = sLevel.levelMapNum;
                    LevelMap lMap = sLevel.levelMap;
                    model.LevelMaps[model.Levels[currentIndex].LevelMap] = lMap;
                    model.TileSets[lMap.TileSetL1 + 0x20] = sLevel.tileSetL1;
                    model.TileSets[lMap.TileSetL2 + 0x20] = sLevel.tileSetL2;
                    model.TileSets[lMap.TileSetL3] = sLevel.tileSetL3;
                    model.EditTileSets[lMap.TileSetL1 + 0x20] = true;
                    model.EditTileSets[lMap.TileSetL2 + 0x20] = true;
                    model.EditTileSets[lMap.TileSetL3] = true;
                    model.TileMaps[lMap.TileMapL1 + 0x40] = sLevel.tileMapL1;
                    model.TileMaps[lMap.TileMapL2 + 0x40] = sLevel.tileMapL2;
                    model.TileMaps[lMap.TileMapL3] = sLevel.tileMapL3;
                    model.EditTileMaps[lMap.TileMapL1 + 0x40] = true;
                    model.EditTileMaps[lMap.TileMapL2 + 0x40] = true;
                    model.EditTileMaps[lMap.TileMapL3] = true;
                    model.SolidityMaps[lMap.PhysicalMap] = sLevel.physicalMap;
                    model.EditPhysicalMaps[lMap.PhysicalMap] = true;
                    model.Levels[currentIndex].LevelNPCs = sLevel.levelNPCs;
                    model.Levels[currentIndex].LevelExits = sLevel.levelExits;
                    model.Levels[currentIndex].LevelEvents = sLevel.levelEvents;
                }
                else
                {
                    SerializedLevel[] sLevels = new SerializedLevel[510];
                    for (int i = 0; i < sLevels.Length; i++)
                        sLevels[i] = new SerializedLevel();
                    Do.Import(sLevels, fullPath + "\\" + "level", "LEVEL", true);
                    for (int i = 0; i < sLevels.Length; i++)
                    {
                        model.Levels[i].Layer = sLevels[i].levelLayer;
                        model.Levels[i].LevelMap = sLevels[i].levelMapNum;
                        LevelMap lMap = sLevels[i].levelMap;
                        model.LevelMaps[model.Levels[i].LevelMap] = lMap;
                        model.TileSets[lMap.TileSetL1 + 0x20] = sLevels[i].tileSetL1;
                        model.TileSets[lMap.TileSetL2 + 0x20] = sLevels[i].tileSetL2;
                        model.TileSets[lMap.TileSetL3] = sLevels[i].tileSetL3;
                        model.EditTileSets[lMap.TileSetL1 + 0x20] = true;
                        model.EditTileSets[lMap.TileSetL2 + 0x20] = true;
                        model.EditTileSets[lMap.TileSetL3] = true;
                        model.TileMaps[lMap.TileMapL1 + 0x40] = sLevels[i].tileMapL1;
                        model.TileMaps[lMap.TileMapL2 + 0x40] = sLevels[i].tileMapL2;
                        model.TileMaps[lMap.TileMapL3] = sLevels[i].tileMapL3;
                        model.EditTileMaps[lMap.TileMapL1 + 0x40] = true;
                        model.EditTileMaps[lMap.TileMapL2 + 0x40] = true;
                        model.EditTileMaps[lMap.TileMapL3] = true;
                        model.SolidityMaps[lMap.PhysicalMap] = sLevels[i].physicalMap;
                        model.EditPhysicalMaps[lMap.PhysicalMap] = true;
                        model.Levels[i].LevelNPCs = sLevels[i].levelNPCs;
                        model.Levels[i].LevelExits = sLevels[i].levelExits;
                        model.Levels[i].LevelEvents = sLevels[i].levelEvents;
                    }
                }
            }
            #endregion
            #region Battlefields
            if (this.Text == "EXPORT BATTLEFIELDS...")
            {
                Battlefield[] battlefields = model.Battlefields;
                SerializedBattlefield[] serialized = new SerializedBattlefield[battlefields.Length];
                PaletteSet[] paletteSets = model.PaletteSetsBF;
                int i = 0;
                foreach (Battlefield battlefield in battlefields)
                    serialized[i] = new SerializedBattlefield(model.TileSetsBF[battlefields[i].TileSet],
                        paletteSets[battlefields[i++].PaletteSet], battlefield);
                if (radioButtonCurrent.Checked)
                    Do.Export(serialized[currentIndex], "battlefield." + currentIndex.ToString("d2") + ".dat");
                else
                    Do.Export(serialized,
                        fullPath + "\\" + model.GetFileNameWithoutPath() + " - Battlefields\\" + "battlefield",
                        "BATTLEFIELD", true);
            }
            if (this.Text == "IMPORT BATTLEFIELDS...")
            {
                Battlefield[] battlefields = model.Battlefields;
                if (radioButtonCurrent.Checked)
                {
                    SerializedBattlefield battlefield = new SerializedBattlefield();
                    battlefield = (SerializedBattlefield)Do.Import(battlefield, fullPath);
                    model.TileSetsBF[battlefields[currentIndex].TileSet] = battlefield.tileset;
                    battlefields[currentIndex].GraphicSetA = battlefield.graphicSetA;
                    battlefields[currentIndex].GraphicSetB = battlefield.graphicSetB;
                    battlefields[currentIndex].GraphicSetC = battlefield.graphicSetC;
                    battlefields[currentIndex].GraphicSetD = battlefield.graphicSetD;
                    battlefields[currentIndex].GraphicSetE = battlefield.graphicSetE;
                    model.PaletteSetsBF[battlefields[currentIndex].PaletteSet] = battlefield.paletteSet;
                    battlefields[currentIndex].Index = currentIndex;
                }
                else
                {
                    SerializedBattlefield[] battlefield = new SerializedBattlefield[battlefields.Length];
                    for (int i = 0; i < battlefield.Length; i++)
                        battlefield[i] = new SerializedBattlefield();
                    Do.Import(battlefield, fullPath + "\\" + "battlefield", "BATTLEFIELD", true);
                    for (int i = 0; i < battlefield.Length; i++)
                    {
                        model.TileSetsBF[battlefields[i].TileSet] = battlefield[i].tileset;
                        battlefields[i].GraphicSetA = battlefield[i].graphicSetA;
                        battlefields[i].GraphicSetB = battlefield[i].graphicSetB;
                        battlefields[i].GraphicSetC = battlefield[i].graphicSetC;
                        battlefields[i].GraphicSetD = battlefield[i].graphicSetD;
                        battlefields[i].GraphicSetE = battlefield[i].graphicSetE;
                        model.PaletteSetsBF[battlefields[i].PaletteSet] = battlefield[i].paletteSet;
                        battlefields[i].Index = i;
                    }
                }
            }
            #endregion
            #region Samples
            if (this.Text == "EXPORT SAMPLES...")
            {
                if (radioButtonCurrent.Checked)
                    Do.Export(BRR.Decode(model.AudioSamples[currentIndex].Sample, 8000),
                        "sample." + currentIndex.ToString("d3") + ".wav", fullPath);
                else
                {
                    byte[][] samples = new byte[model.AudioSamples.Length][];
                    int i = 0;
                    foreach (BRRSample s in model.AudioSamples)
                        samples[i++] = BRR.Decode(s.Sample, 8000);
                    Do.Export(samples,
                        fullPath + "\\" + model.GetFileNameWithoutPath() + " - Samples\\" + "sample",
                        "SAMPLE", true);
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
                return;
            }
            if (this.Text == "IMPORT SAMPLES...")
            {
                if (radioButtonCurrent.Checked)
                {
                    byte[] sample = (byte[])Do.Import(new byte[1], fullPath);
                    model.AudioSamples[currentIndex].Sample = BRR.Encode(sample);
                }
                else
                {
                    byte[][] samples = new byte[model.AudioSamples.Length][];
                    Do.Import(samples, fullPath + "\\" + "sample", "SAMPLE", true);
                    int i = 0;
                    foreach (BRRSample sample in model.AudioSamples)
                        sample.Sample = BRR.Encode(samples[i++]);
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
                return;
            }
            #endregion
            #region Other
            try
            {
                Element[] array = (Element[])element;
                TextInfo textInfo = Thread.CurrentThread.CurrentCulture.TextInfo;
                string name = this.Text.ToLower().Substring(7, this.Text.Length - 7 - 4);
                if (this.Text.Substring(0, 6) == "EXPORT")
                {
                    if (radioButtonCurrent.Checked)
                        Do.Export(array[currentIndex], name + "s." + currentIndex.ToString("d2") + ".dat");
                    else
                        Do.Export(array,
                            fullPath + "\\" + model.GetFileNameWithoutPath() + " - " +
                            textInfo.ToTitleCase(name) + "s" + "\\" + name,
                            name.ToUpper(), true);
                }
                if (this.Text.Substring(0, 6) == "IMPORT")
                {
                    if (radioButtonCurrent.Checked)
                    {
                        array[currentIndex] = (Element)Do.Import(array[currentIndex], fullPath);
                        array[currentIndex].Index = currentIndex;
                        array[currentIndex].Data = model.Data;
                    }
                    else
                    {
                        Do.Import(array, fullPath + "\\" + name, name.ToUpper(), true);
                        int i = 0;
                        foreach (Element item in array)
                        {
                            item.Data = model.Data;
                            item.Index = i++;
                        }
                    }
                }
            }
            catch { }
            #endregion
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
