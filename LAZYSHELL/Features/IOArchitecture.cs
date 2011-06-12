using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LAZYSHELL
{
    public partial class IOArchitecture : Form
    {
        private string action;
        private int index;
        private LevelMap levelMap;
        private PaletteSet paletteSet;
        private TileSet tileSet;
        private TileMap tileMap;
        private PrioritySet prioritySet;
        private string fullPath;
        // constructor
        public IOArchitecture(string action, int index, LevelMap levelMap, PaletteSet paletteSet, TileSet tileSet, TileMap tileMap, PrioritySet prioritySet)
        {
            this.action = action;
            this.index = index;
            this.levelMap = levelMap;
            this.paletteSet = paletteSet;
            this.tileSet = tileSet;
            this.tileMap = tileMap;
            this.prioritySet = prioritySet;
            InitializeComponent();
            if (action == "import")
                groupBox1.Text = "Import the following elements from architecture file";
            else
                groupBox1.Text = "Export the following elements to architecture file";
        }
        // functions
        private void Export_Architecture()
        {
            byte[] array = new byte[0x80000];
            ExportPalette(array, 0);
            ExportGraphics(array, 0x200);
            ExportTileset(array, 0, 0x10200);
            ExportTileset(array, 1, 0x11200);
            ExportTileset(array, 2, 0x12200);
            ExportTilemap(array, 0, 0x13200);
            ExportTilemap(array, 1, 0x33200);
            ExportTilemap(array, 2, 0x53200);
            ExportPriority(array, 0x73200);
            Do.Export(array, "", fullPath);
        }
        private void ExportPalette(byte[] array, int offset)
        {
            for (int i = 0; checkBox1.Checked && i < paletteSet.Palettes.Length; i++)
            {
                for (int a = 0; a < 16; a++)
                {
                    Bits.Set24Bit(array, offset, paletteSet.Palettes[i][a]);
                    offset += 3;
                }
            }
        }
        private void ExportGraphics(byte[] array, int offset)
        {
            if (checkBox2.Checked)
                Buffer.BlockCopy(tileSet.Graphics, 0, array, offset, tileSet.Graphics.Length);
        }
        private void ExportTileset(byte[] array, int layer, int offset)
        {
            if (checkBox3.Checked && tileSet.TileSetLayers.Length >= layer + 1 && tileSet.TileSetLayers[layer] != null)
                foreach (Tile16x16 tile in tileSet.TileSetLayers[layer])
                {
                    foreach (Tile8x8 subtile in tile.Subtiles)
                    {
                        Bits.SetShort(array, offset, subtile.TileIndex);
                        offset += 2;
                        array[offset] = (byte)subtile.PaletteIndex;
                        Bits.SetBit(array, offset, 5, subtile.PriorityOne);
                        Bits.SetBit(array, offset, 6, subtile.Mirror);
                        Bits.SetBit(array, offset, 7, subtile.Invert);
                        offset++;
                    }
                }
        }
        private void ExportTilemap(byte[] array, int layer, int offset)
        {
            if (checkBox4.Checked && tileMap.Layers.Length >= 1 && tileMap.Layers[layer] != null)
                foreach (Tile16x16 tile in tileMap.Layers[layer])
                {
                    if (tile == null)
                    {
                        offset += 2;
                        continue;
                    }
                    Bits.SetShort(array, offset, tile.TileIndex); offset++;
                    Bits.SetBit(array, offset, 6, tile.Mirror);
                    Bits.SetBit(array, offset, 7, tile.Invert); offset++;
                }
        }
        private void ExportPriority(byte[] array, int offset)
        {
            if (checkBox5.Checked)
            {
                array[offset++] = (byte)(prioritySet.MainscreenL1 ? 0x01 : 0x00);
                array[offset++] = (byte)(prioritySet.MainscreenL2 ? 0x01 : 0x00);
                array[offset++] = (byte)(prioritySet.MainscreenL3 ? 0x01 : 0x00);
                array[offset++] = (byte)(prioritySet.MainscreenOBJ ? 0x01 : 0x00);
                array[offset++] = (byte)(prioritySet.SubscreenL1 ? 0x01 : 0x00);
                array[offset++] = (byte)(prioritySet.SubscreenL2 ? 0x01 : 0x00);
                array[offset++] = (byte)(prioritySet.SubscreenL3 ? 0x01 : 0x00);
                array[offset++] = (byte)(prioritySet.SubscreenOBJ ? 0x01 : 0x00);
                array[offset++] = (byte)(prioritySet.ColorMathL1 ? 0x01 : 0x00);
                array[offset++] = (byte)(prioritySet.ColorMathL2 ? 0x01 : 0x00);
                array[offset++] = (byte)(prioritySet.ColorMathL3 ? 0x01 : 0x00);
                array[offset++] = (byte)(prioritySet.ColorMathOBJ ? 0x01 : 0x00);
                array[offset++] = (byte)(prioritySet.ColorMathBG ? 0x01 : 0x00);
                array[offset++] = prioritySet.ColorMathHalfIntensity;
                array[offset++] = prioritySet.ColorMathMinusSubscreen;
            }
        }
        private void Import_Architecture()
        {
            byte[] array = new byte[0x80000];
            array = (byte[])Do.Import(array, fullPath);
            ImportPalette(array, 0);
            ImportGraphics(array, 0x200);
            ImportTileset(array, 0, 0x10200);
            ImportTileset(array, 1, 0x11200);
            ImportTileset(array, 2, 0x12200);
            ImportTilemap(array, 0, 0x13200);
            ImportTilemap(array, 1, 0x33200);
            ImportTilemap(array, 2, 0x53200);
            ImportPriority(array, 0x73200);
        }
        private void ImportPalette(byte[] array, int offset)
        {
            for (int i = 0; checkBox1.Checked && i < paletteSet.Palettes.Length; i++)
            {
                for (int a = 0; a < 16; a++)
                {
                    paletteSet.Blues[i * 16 + a] = array[offset++];
                    paletteSet.Greens[i * 16 + a] = array[offset++];
                    paletteSet.Reds[i * 16 + a] = array[offset++];
                }
            }
        }
        private void ImportGraphics(byte[] array, int offset)
        {
            if (checkBox2.Checked)
                Buffer.BlockCopy(array, 0x200, tileSet.Graphics, 0, tileSet.Graphics.Length);
        }
        private void ImportTileset(byte[] array, int layer, int offset)
        {
            if (!checkBox3.Checked || tileSet.TileSetLayers[layer] == null)
                return;
            byte format = (byte)(layer != 2 ? 0x20 : 0x10);
            foreach (Tile16x16 tile in tileSet.TileSetLayers[layer])
            {
                if (tile == null)
                {
                    offset += 3;
                    continue;
                }
                foreach (Tile8x8 subtile in tile.Subtiles)
                {
                    subtile.TileIndex = Bits.GetShort(array, offset);
                    if (subtile.TileIndex * format >= (layer != 2 ? tileSet.Graphics.Length : tileSet.GraphicsL3.Length))
                        subtile.TileIndex = 0;
                    offset += 2;
                    subtile.PaletteIndex = array[offset] & 7;
                    subtile.PriorityOne = Bits.GetBit(array, offset, 5);
                    subtile.Mirror = Bits.GetBit(array, offset, 6);
                    subtile.Invert = Bits.GetBit(array, offset, 7);
                    offset++;
                }
            }
        }
        private void ImportTilemap(byte[] array, int layer, int offset)
        {
            if (!checkBox4.Checked || tileMap.Layers[layer] == null)
                return;
            int counter = 0;
            int extratiles = 256;
            bool mirror, invert;
            for (int i = 0; i < tileMap.Layers[layer].Length; i++)
            {
                int tile = Bits.GetShort(array, offset) & 0x1FF;
                mirror = Bits.GetBit(array, offset + 1, 6);
                invert = Bits.GetBit(array, offset + 1, 7);
                tileMap.Layers[layer][i] = tileSet.TileSetLayers[layer][tile];
                if (layer != 2)
                {
                    Bits.SetShort(tileMap.TileMaps[layer], counter, tile);
                    counter += 2; offset += 2;
                }
                else
                {
                    tileMap.TileMaps[layer][counter] = (byte)tile;
                    counter++; offset += 2;
                }
                if (tileSet.TileSetLayers[layer] == null || tileSet.TileSetLayers[layer].Length != 512)
                    continue;
                if (mirror || invert)
                {
                    Tile16x16 copy = tileSet.TileSetLayers[layer][tile].Copy();
                    if (mirror)
                        Do.FlipHorizontal(copy);
                    if (invert)
                        Do.FlipVertical(copy);
                    Tile16x16 contains = Do.Contains(tileSet.TileSetLayers[layer], copy);
                    if (contains == null)
                    {
                        tileSet.TileSetLayers[layer][extratiles] = copy;
                        tileSet.TileSetLayers[layer][extratiles].TileIndex = extratiles;
                        tileMap.Layers[layer][i] = tileSet.TileSetLayers[layer][extratiles];
                        Bits.SetShort(tileMap.TileMaps[layer], counter - 2, extratiles);
                        extratiles++;
                    }
                    else
                    {
                        tileMap.Layers[layer][i] = tileSet.TileSetLayers[layer][contains.TileIndex];
                        Bits.SetShort(tileMap.TileMaps[layer], counter - 2, contains.TileIndex);
                    }
                }
            }
        }
        private void ImportPriority(byte[] array, int offset)
        {
            if (checkBox5.Checked)
            {
                prioritySet.MainscreenL1 = array[offset++] == 0x01;
                prioritySet.MainscreenL2 = array[offset++] == 0x01;
                prioritySet.MainscreenL3 = array[offset++] == 0x01;
                prioritySet.MainscreenOBJ = array[offset++] == 0x01;
                prioritySet.SubscreenL1 = array[offset++] == 0x01;
                prioritySet.SubscreenL2 = array[offset++] == 0x01;
                prioritySet.SubscreenL3 = array[offset++] == 0x01;
                prioritySet.SubscreenOBJ = array[offset++] == 0x01;
                prioritySet.ColorMathL1 = array[offset++] == 0x01;
                prioritySet.ColorMathL2 = array[offset++] == 0x01;
                prioritySet.ColorMathL3 = array[offset++] == 0x01;
                prioritySet.ColorMathBG = array[offset++] == 0x01;
                prioritySet.ColorMathOBJ = array[offset++] == 0x01;
                prioritySet.ColorMathHalfIntensity = array[offset++];
                prioritySet.ColorMathMinusSubscreen = array[offset++];
            }
            Model.EditTileMaps[levelMap.TileMapL1 + 0x40] = true;
            Model.EditTileMaps[levelMap.TileMapL2 + 0x40] = true;
            Model.EditTileMaps[levelMap.TileMapL3] = true;
            Model.EditTileSets[levelMap.TileSetL1 + 0x20] = true;
            Model.EditTileSets[levelMap.TileSetL2 + 0x20] = true;
            Model.EditTileSets[levelMap.TileSetL3] = true;
            Model.EditGraphicSets[levelMap.GraphicSetA + 0x48] = true;
            Model.EditGraphicSets[levelMap.GraphicSetB + 0x48] = true;
            Model.EditGraphicSets[levelMap.GraphicSetC + 0x48] = true;
            Model.EditGraphicSets[levelMap.GraphicSetD + 0x48] = true;
            Model.EditGraphicSets[levelMap.GraphicSetE + 0x48] = true;
            Model.EditGraphicSets[levelMap.GraphicSetL3] = true;
            tileSet.AssembleIntoModel(16);
            tileMap.AssembleIntoModel();
        }
        // event handlers
        private void browseCurrent_Click(object sender, EventArgs e)
        {
            string filter = "Binary files (*.bin)|*.bin|All files (*.*)|*.*";
            if (action == "export")
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Title = "Select directory to export to";
                saveFileDialog.Filter = filter;
                saveFileDialog.FileName = "architecture.SMRPG.level." + index.ToString("d4");
                saveFileDialog.FilterIndex = 0;
                saveFileDialog.RestoreDirectory = true;

                if (saveFileDialog.ShowDialog() != DialogResult.OK) return;
                textBoxCurrent.Text = saveFileDialog.FileName;
            }
            else
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.InitialDirectory = LAZYSHELL.Properties.Settings.Default.LastRomPath;
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
        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (action == "import")
                Import_Architecture();
            else
                Export_Architecture();
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
