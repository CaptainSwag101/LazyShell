using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace LAZYSHELL
{
    public partial class Levels
    {
        #region Variables

        private LevelMap levelMap { get { return levelMaps[level.LevelMap]; } set { levelMaps[level.LevelMap] = value; } }
        public LevelMap LevelMap { get { return levelMap; } }

        private PaletteSet paletteSet
        {
            get { return paletteSets[levelMaps[level.LevelMap].PaletteSet]; }
            set { paletteSets[levelMaps[level.LevelMap].PaletteSet] = value; }
        }
        public PaletteSet PaletteSet { get { return paletteSet; } }

        private TileMap tileMap; public TileMap TileMap { get { return tileMap; } }
        private TileSet tileSet; public TileSet TileSet { get { return tileSet; } }

        private LevelSolidMap physicalMap; public LevelSolidMap PhysicalMap { get { return physicalMap; } }
        #endregion
        #region Methods

        private void InitializeMapProperties()
        {
            updatingProperties = true;

            levelMap = levelMaps[level.LevelMap];
            paletteSet = paletteSets[levelMaps[level.LevelMap].PaletteSet];

            this.mapNum.Value = level.LevelMap;

            this.mapGFXSet1Num.Value = levelMap.GraphicSetA;
            this.mapGFXSet1Name.SelectedIndex = levelMap.GraphicSetA;
            this.mapGFXSet2Num.Value = levelMap.GraphicSetB;
            this.mapGFXSet2Name.SelectedIndex = levelMap.GraphicSetB;
            this.mapGFXSet3Num.Value = levelMap.GraphicSetC;
            this.mapGFXSet3Name.SelectedIndex = levelMap.GraphicSetC;
            this.mapGFXSet4Num.Value = levelMap.GraphicSetD;
            this.mapGFXSet4Name.SelectedIndex = levelMap.GraphicSetD;
            this.mapGFXSet5Num.Value = levelMap.GraphicSetE;
            this.mapGFXSet5Name.SelectedIndex = levelMap.GraphicSetE;
            if (levelMap.GraphicSetL3 > 0x1b)
            {
                this.mapGFXSetL3Num.Value = 0x1c;
                this.mapGFXSetL3Name.SelectedIndex = 0x1c;
            }
            else
            {
                this.mapGFXSetL3Num.Value = levelMap.GraphicSetL3;
                this.mapGFXSetL3Name.SelectedIndex = levelMap.GraphicSetL3;
            }
            this.mapTilesetL1Num.Value = levelMap.TileSetL1;
            this.mapTilesetL1Name.SelectedIndex = levelMap.TileSetL1;
            this.mapTilesetL2Num.Value = levelMap.TileSetL2;
            this.mapTilesetL2Name.SelectedIndex = levelMap.TileSetL2;
            this.mapTilesetL3Num.Value = levelMap.TileSetL3;
            this.mapTilesetL3Name.SelectedIndex = levelMap.TileSetL3;

            this.mapTilemapL1Num.Value = levelMap.TileMapL1;
            this.mapTilemapL1Name.SelectedIndex = levelMap.TileMapL1;
            this.mapTilemapL2Num.Value = levelMap.TileMapL2;
            this.mapTilemapL2Name.SelectedIndex = levelMap.TileMapL2;
            this.mapTilemapL3Num.Value = levelMap.TileMapL3;
            this.mapTilemapL3Name.SelectedIndex = levelMap.TileMapL3;
            this.mapPhysicalMapNum.Value = levelMap.SolidityMap;
            this.mapPhysicalMapName.SelectedIndex = levelMap.SolidityMap;
            this.mapBattlefieldNum.Value = levelMap.Battlefield;
            this.mapBattlefieldName.SelectedIndex = levelMap.Battlefield;

            if (levelMap.GraphicSetL3 > 0x1b)
            {
                this.mapTilesetL3Num.Enabled = false;
                this.mapTilesetL3Name.Enabled = false;
                this.mapTilemapL3Num.Enabled = false;
                this.mapTilemapL3Name.Enabled = false;
            }
            else
            {
                this.mapTilesetL3Num.Enabled = true;
                this.mapTilesetL3Name.Enabled = true;
                this.mapTilemapL3Num.Enabled = true;
                this.mapTilemapL3Name.Enabled = true;
            }

            this.mapSetL3Priority.Checked = levelMap.TopPriorityL3;

            this.mapPaletteSetNum.Value = levelMap.PaletteSet;
            this.mapPaletteSetName.SelectedIndex = levelMap.PaletteSet;

            updatingProperties = false;

        }

        // set images
        private Image SetPaletteOverlay(Size s, Size u, int index)  // s = palette dimen, u = color dimen
        {
            Point p = new Point();
            int colspan = s.Width / u.Width;
            int color;

            p.X = index % colspan * u.Width;
            p.Y = index / colspan * u.Height;

            int[] pixels = new int[s.Width * s.Height];
            for (int x = p.X; x < p.X + u.Width - 1; x++)
            {
                color = x % 2 == 0 ? Color.White.ToArgb() : Color.Black.ToArgb();
                pixels[p.Y * s.Width + x] = color;
                pixels[(p.Y + u.Height - 2) * s.Width + x] = color;
                color = x % 2 == 0 ? Color.Black.ToArgb() : Color.White.ToArgb();
                pixels[(p.Y + 1) * s.Width + x] = color;
                pixels[(p.Y + u.Height - 3) * s.Width + x] = color;
            }
            for (int y = p.Y; y < p.Y + u.Height - 1; y++)
            {
                color = y % 2 == 0 ? Color.White.ToArgb() : Color.Black.ToArgb();
                pixels[y * s.Width + p.X] = color;
                pixels[y * s.Width + u.Width - 2 + p.X] = color;
                color = y % 2 == 0 ? Color.Black.ToArgb() : Color.White.ToArgb();
                pixels[y * s.Width + 1 + p.X] = color;
                pixels[y * s.Width + u.Width - 3 + p.X] = color;
            }
            return Do.PixelsToImage(pixels, s.Width, s.Height);
        }

        // import / export
        private void graphicSetsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BinaryWriter binWriter;
            string path = GetDirectoryPath("Where do you want to save the graphic sets?");

            path += "\\" + Model.GetFileNameWithoutPath() + " - Graphic Sets\\";

            if (!CreateDir(path))
                return;
            if (path == null)
                return;

            try
            {
                for (int i = 0; i < Model.GraphicSets.Length; i++)
                {
                    binWriter = new BinaryWriter(File.Open(path + "graphicSet." + i.ToString("d3") + ".bin", FileMode.Create));
                    binWriter.Write(Model.GraphicSets[i]);
                    binWriter.Close();
                }
            }
            catch (Exception ioexc)
            {
                MessageBox.Show("Lazy Shell was unable to save the graphic sets.\n\n" + ioexc.Message, "LAZY SHELL");
            }

        }
        private void graphicSetsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string filename;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = settings.LastRomPath;
            openFileDialog1.Title = "Import graphic set";
            openFileDialog1.Filter = "Binary files (*.bin)|*.bin|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() != DialogResult.Cancel)
                filename = openFileDialog1.FileName;
            else
                return;

            string num = filename.Substring(filename.LastIndexOf('.') - 2, 2);

            int index = Int32.Parse(num, System.Globalization.NumberStyles.HexNumber);

            try
            {
                FileInfo fInfo = new FileInfo(filename);

                if (fInfo.Length != 8192)
                {
                    MessageBox.Show("File is incorrect size, Graphic Sets are 8192 bytes", "LAZY SHELL");
                    return;
                }

                FileStream fStream = new FileStream(filename, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fStream);
                Model.GraphicSets[index] = br.ReadBytes((int)fInfo.Length);
                Model.EditGraphicSets[index] = true;
                br.Close();
                fStream.Close();

                fullUpdate = true;
                RefreshLevel();

                return;

            }
            catch (Exception ioexc)
            {
                MessageBox.Show("Lazy Shell was unable to Import the Graphic Set.\n\n" + ioexc.Message, "LAZY SHELL");
                return;
            }

        }

        #endregion
        #region Event Handlers

        // MAPS tab
        private void mapNum_ValueChanged(object sender, EventArgs e)
        {
            //SaveMapProperties(); // Save any changes must save changes prior to this point
            // Every property has to save itself
            if (updatingProperties) return;
            tileMap.AssembleIntoModel(); // Assemble the edited tileMap into the model

            level.LevelMap = (int)mapNum.Value; // Set the levels mapNum to the new value

            InitializeMapProperties(); // Load the new Map properties
            if (!updatingLevel)
            {
                fullUpdate = true;
                RefreshLevel();
            }
        }
        private void mapGFXSet1Num_ValueChanged(object sender, EventArgs e)
        {
            if (updatingProperties) return;
            mapGFXSet1Name.SelectedIndex = (int)mapGFXSet1Num.Value;
            levelMap.GraphicSetA = (byte)this.mapGFXSet1Num.Value;
            if (!updatingLevel)
            {
                fullUpdate = true;
                RefreshLevel();
            }
        }
        private void mapGFXSet1Name_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updatingProperties) return;
            mapGFXSet1Num.Value = mapGFXSet1Name.SelectedIndex;
        }
        private void mapGFXSet2Num_ValueChanged(object sender, EventArgs e)
        {
            if (updatingProperties) return;
            mapGFXSet2Name.SelectedIndex = (int)mapGFXSet2Num.Value;
            levelMap.GraphicSetB = (byte)this.mapGFXSet2Num.Value;
            if (!updatingLevel)
            {
                fullUpdate = true;
                RefreshLevel();
            }
        }
        private void mapGFXSet2Name_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updatingProperties) return;
            mapGFXSet2Num.Value = mapGFXSet2Name.SelectedIndex;
        }
        private void mapGFXSet3Num_ValueChanged(object sender, EventArgs e)
        {
            if (updatingProperties) return;
            mapGFXSet3Name.SelectedIndex = (int)mapGFXSet3Num.Value;
            levelMap.GraphicSetC = (byte)this.mapGFXSet3Num.Value;
            if (!updatingLevel)
            {
                fullUpdate = true;
                RefreshLevel();
            }
        }
        private void mapGFXSet3Name_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updatingProperties) return;
            mapGFXSet3Num.Value = mapGFXSet3Name.SelectedIndex;
        }
        private void mapGFXSet4Num_ValueChanged(object sender, EventArgs e)
        {
            if (updatingProperties) return;
            mapGFXSet4Name.SelectedIndex = (int)mapGFXSet4Num.Value;
            levelMap.GraphicSetD = (byte)this.mapGFXSet4Num.Value;
            if (!updatingLevel)
            {
                fullUpdate = true;
                RefreshLevel();
            }
        }
        private void mapGFXSet4Name_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updatingProperties) return;
            mapGFXSet4Num.Value = mapGFXSet4Name.SelectedIndex;
        }
        private void mapGFXSet5Num_ValueChanged(object sender, EventArgs e)
        {
            if (updatingProperties) return;
            mapGFXSet5Name.SelectedIndex = (int)mapGFXSet5Num.Value;
            levelMap.GraphicSetE = (byte)this.mapGFXSet5Num.Value;
            if (!updatingLevel)
            {
                fullUpdate = true;
                RefreshLevel();
            }
        }
        private void mapGFXSet5Name_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updatingProperties) return;
            mapGFXSet5Num.Value = mapGFXSet5Name.SelectedIndex;
        }
        private void mapGFXSetL3Num_ValueChanged(object sender, EventArgs e)
        {
            if (updatingProperties) return;
            mapGFXSetL3Name.SelectedIndex = (int)mapGFXSetL3Num.Value;
            if (this.mapGFXSetL3Num.Value > 0x1b)
            {
                levelMap.GraphicSetL3 = (byte)0xff;
                this.mapTilesetL3Num.Enabled = false;
                this.mapTilesetL3Name.Enabled = false;
                this.mapTilemapL3Num.Enabled = false;
                this.mapTilemapL3Name.Enabled = false;
                if (levelsTileset.Layer == 2)
                    levelsTileset.Layer = 0;
            }
            else
            {
                levelMap.GraphicSetL3 = (byte)this.mapGFXSetL3Num.Value;
                this.mapTilesetL3Num.Enabled = true;
                this.mapTilesetL3Name.Enabled = true;
                this.mapTilemapL3Num.Enabled = true;
                this.mapTilemapL3Name.Enabled = true;
            }
            if (!updatingLevel)
            {
                fullUpdate = true;
                RefreshLevel();
            }
        }
        private void mapGFXSetL3Name_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updatingProperties) return;
            mapGFXSetL3Num.Value = mapGFXSetL3Name.SelectedIndex;
        }
        private void mapTilesetL1Num_ValueChanged(object sender, EventArgs e)
        {
            if (updatingProperties) return;
            mapTilesetL1Name.SelectedIndex = (int)mapTilesetL1Num.Value;
            levelMap.TileSetL1 = (byte)this.mapTilesetL1Num.Value;
            if (!updatingLevel)
            {
                fullUpdate = true;
                RefreshLevel();
            }
        }
        private void mapTilesetL1Name_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updatingProperties) return;
            mapTilesetL1Num.Value = mapTilesetL1Name.SelectedIndex;
        }
        private void mapTilesetL2Num_ValueChanged(object sender, EventArgs e)
        {
            if (updatingProperties) return;
            mapTilesetL2Name.SelectedIndex = (int)mapTilesetL2Num.Value;
            levelMap.TileSetL2 = (byte)this.mapTilesetL2Num.Value;
            if (!updatingLevel)
            {
                fullUpdate = true;
                RefreshLevel();
            }
        }
        private void mapTilesetL2Name_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updatingProperties) return;
            mapTilesetL2Num.Value = mapTilesetL2Name.SelectedIndex;
        }
        private void mapTilesetL3Num_ValueChanged(object sender, EventArgs e)
        {
            if (updatingProperties) return;
            mapTilesetL3Name.SelectedIndex = (int)mapTilesetL3Num.Value;
            levelMap.TileSetL3 = (byte)this.mapTilesetL3Num.Value;
            if (!updatingLevel)
            {
                fullUpdate = true;
                RefreshLevel();
            }
        }
        private void mapTilesetL3Name_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updatingProperties) return;
            mapTilesetL3Num.Value = mapTilesetL3Name.SelectedIndex;
        }
        private void mapTilemapL1Num_ValueChanged(object sender, EventArgs e)
        {
            if (updatingProperties) return;
            mapTilemapL1Name.SelectedIndex = (int)mapTilemapL1Num.Value;
            levelMap.TileMapL1 = (byte)this.mapTilemapL1Num.Value;
            if (!updatingLevel)
            {
                fullUpdate = true;
                RefreshLevel();
            }
        }
        private void mapTilemapL1Name_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updatingProperties) return;
            mapTilemapL1Num.Value = mapTilemapL1Name.SelectedIndex;
        }
        private void mapTilemapL2Num_ValueChanged(object sender, EventArgs e)
        {
            if (updatingProperties) return;
            mapTilemapL2Name.SelectedIndex = (int)mapTilemapL2Num.Value;
            levelMap.TileMapL2 = (byte)this.mapTilemapL2Num.Value;
            if (!updatingLevel)
            {
                fullUpdate = true;
                RefreshLevel();
            }
        }
        private void mapTilemapL2Name_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updatingProperties) return;
            mapTilemapL2Num.Value = mapTilemapL2Name.SelectedIndex;
        }
        private void mapTilemapL3Num_ValueChanged(object sender, EventArgs e)
        {
            if (updatingProperties) return;
            mapTilemapL3Name.SelectedIndex = (int)mapTilemapL3Num.Value;
            levelMap.TileMapL3 = (byte)this.mapTilemapL3Num.Value;
            if (!updatingLevel)
            {
                fullUpdate = true;
                RefreshLevel();
            }
        }
        private void mapTilemapL3Name_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updatingProperties) return;
            mapTilemapL3Num.Value = mapTilemapL3Name.SelectedIndex;
        }
        private void mapBattlefieldNum_ValueChanged(object sender, EventArgs e)
        {
            if (updatingProperties) return;
            levelMap.Battlefield = (byte)this.mapBattlefieldNum.Value;
            mapBattlefieldName.SelectedIndex = (int)mapBattlefieldNum.Value;
        }
        private void mapBattlefieldName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updatingProperties) return;
            mapBattlefieldNum.Value = mapBattlefieldName.SelectedIndex;
        }
        private void mapPhysicalMapNum_ValueChanged(object sender, EventArgs e)
        {
            if (updatingProperties) return;
            mapPhysicalMapName.SelectedIndex = (int)mapPhysicalMapNum.Value;
            levelMap.SolidityMap = (byte)this.mapPhysicalMapNum.Value;
            if (!updatingLevel)
            {
                fullUpdate = true;
                physicalMap = new LevelSolidMap(levelMap);
                physicalMap.Image = null;
                LoadTilemapEditor();
            }
        }
        private void mapPhysicalMapName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updatingProperties) return;
            mapPhysicalMapNum.Value = mapPhysicalMapName.SelectedIndex;
        }
        private void mapSetL3Priority_CheckedChanged(object sender, EventArgs e)
        {
            mapSetL3Priority.ForeColor = mapSetL3Priority.Checked ? Color.Black : Color.Gray;
            levelMap.TopPriorityL3 = mapSetL3Priority.Checked;
            if (!updatingLevel)
            {
                fullUpdate = true;
                RefreshLevel();
            }
        }
        private void mapPaletteSetNum_ValueChanged(object sender, EventArgs e)
        {
            if (updatingProperties) return;
            mapPaletteSetName.SelectedIndex = (int)mapPaletteSetNum.Value;
            levelMap.PaletteSet = (byte)this.mapPaletteSetNum.Value;
            if (!updatingLevel)
            {
                fullUpdate = true;
                RefreshLevel();
            }
        }
        private void mapPaletteSetName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updatingProperties) return;
            mapPaletteSetNum.Value = mapPaletteSetName.SelectedIndex;
        }
        #endregion
    }
}
