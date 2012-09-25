using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using LAZYSHELL.Properties;
using LAZYSHELL.Undo;

namespace LAZYSHELL
{
    public partial class Levels : Form
    {
        #region Variables

        public long checksum;
        private int index { get { return (int)levelNum.Value; } set { levelNum.Value = value; } }
        public int Index { get { return index; } set { index = value; } }
        private Stack<int> navigateBackward = new Stack<int>();
        private Stack<int> navigateForward = new Stack<int>();
        private int lastNavigate = 0;
        private bool disableNavigate = false;
        private State state = State.Instance;
        private Settings settings = Settings.Default;
        private Solidity solidity = Solidity.Instance;
        // elements
        private Level[] levels { get { return Model.Levels; } set { Model.Levels = value; } }
        private LevelMap[] levelMaps { get { return Model.LevelMaps; } set { Model.LevelMaps = value; } }
        private PaletteSet[] paletteSets { get { return Model.PaletteSets; } set { Model.PaletteSets = value; } }
        private PrioritySet[] prioritySets { get { return Model.PrioritySets; } set { Model.PrioritySets = value; } }
        private SolidityTile[] solidTiles { get { return Model.SolidTiles; } set { Model.SolidTiles = value; } }
        private NPCSpritePartitions[] npcSpritePartitions { get { return Model.NPCSpritePartitions; } }
        private NPCProperties[] npcProperties { get { return Model.NPCProperties; } set { Model.NPCProperties = value; } }
        //
        private Level level { get { return levels[index]; } set { levels[index] = value; } }
        public Level Level { get { return level; } set { level = value; } }
        public System.Windows.Forms.ToolStripComboBox LevelName { get { return levelName; } set { levelName = value; } }
        public PictureBox picture { get { return levelsTilemap.Picture; } set { levelsTilemap.Picture = value; } }
        private int zoom { get { return levelsTilemap.Zoom; } }
        private Level levelCheck; // Used to verify a level change
        public Overlay overlay = new Overlay(); // Object used to generate all the overlays for levels
        private bool updatingLevel = false; // Indicates that we are currently updating the level so we dont update during an update
        public bool UpdatingLevel { get { return updatingLevel; } set { updatingLevel = value; } }
        private bool fullUpdate = false; // Indicates that we need to do a complete update instead of a fast update
        private bool updatingProperties = false; // indicated whether to update or save properties
        // for the separate physical tile search window
        public NumericUpDown NPCMapHeader { get { return npcMapHeader; } set { npcMapHeader = value; } }
        public NumericUpDown NPCID { get { return npcID; } set { npcID = value; } }
        private string fullPath; public string FullPath { set { fullPath = value; } }
        public ToolStripNumericUpDown LevelNum { get { return levelNum; } set { levelNum = value; } }
        public TabControl TabControl { get { return tabControl; } set { tabControl = value; } }
        private Search searchWindow;
        private SpaceAnalyzer sa;
        #endregion
        // Constructor
        public Levels()
        {
            settings.Keystrokes[0x20] = "\x20";

            InitializeComponent();
            this.levelInfo.Columns.AddRange(new ColumnHeader[] { new ColumnHeader(), new ColumnHeader() });
            Do.AddShortcut(toolStripToggle, Keys.Control | Keys.S, new EventHandler(save_Click));
            Do.AddShortcut(toolStripToggle, Keys.F1, helpTips);
            Do.AddShortcut(toolStripToggle, Keys.F2, baseConvertor);
            searchWindow = new Search(levelNum, nameTextBox, searchLevelNames, levelName.Items);

            if (settings.LevelNames.Count == 0)
                settings.LevelNames.AddRange(Lists.LevelNames);
            this.levelName.Items.AddRange(Lists.Numerize(settings.LevelNames));

            this.layerMessageBox.Items.Add("{NONE}");
            Dialogue[] dialogues = Model.GetDialogues(0, 128);
            string[] tables = Model.DTEStr(true);
            for (int i = 0; i < 128; i++)
                this.layerMessageBox.Items.Add(dialogues[i].GetDialogueStub(true, tables));

            this.mapGFXSet1Name.Items.AddRange(Lists.Numerize(Lists.GraphicSetNames));
            this.mapGFXSet2Name.Items.AddRange(Lists.Numerize(Lists.GraphicSetNames));
            this.mapGFXSet3Name.Items.AddRange(Lists.Numerize(Lists.GraphicSetNames));
            this.mapGFXSet4Name.Items.AddRange(Lists.Numerize(Lists.GraphicSetNames));
            this.mapGFXSet5Name.Items.AddRange(Lists.Numerize(Lists.GraphicSetNames));
            this.mapTilesetL1Name.Items.AddRange(Lists.Numerize(Lists.TileSetNames));
            this.mapTilesetL2Name.Items.AddRange(Lists.Numerize(Lists.TileSetNames));
            this.mapTilesetL3Name.Items.AddRange(Lists.Numerize(Lists.TileSetL3Names));
            this.mapTilemapL1Name.Items.AddRange(Lists.Numerize(Lists.TileMapNames));
            this.mapTilemapL2Name.Items.AddRange(Lists.Numerize(Lists.TileMapNames));
            this.mapTilemapL3Name.Items.AddRange(Lists.Numerize(Lists.TileMapL3Names));
            this.mapPhysicalMapName.Items.AddRange(Lists.Numerize(Lists.SolidityMapNames));
            this.mapPaletteSetName.Items.AddRange(Lists.Numerize(Lists.PaletteSetNames));
            this.eventMusic.Items.AddRange(Lists.Numerize(Lists.MusicNames));

            updatingLevel = true;
            if (settings.RememberLastIndex)
            {
                levelNum.Value = settings.LastLevel;
                levelName.SelectedIndex = settings.LastLevel;
            }
            else
                levelName.SelectedIndex = 0;
            updatingLevel = false;

            LoadSolidityTileset();
            if (!updatingLevel)
                RefreshLevel();

            updatingLevel = true;
            InitializeSettings(); // Sets initial control settings
            updatingLevel = false;

            new ToolTipLabel(this, baseConvertor, helpTips);
            findNPCNumber = new NPCEditor(this, npcID.Value);
            new ToolTipLabel(findNPCNumber, baseConvertor, helpTips);
            //
            new History(this);
            lastNavigate = index;
            checksum = Do.GenerateChecksum(levels, levelMaps, Model.GraphicSets, Model.Tilesets,
                Model.Tilemaps, Model.SolidityMaps, Model.PaletteSets, Model.NPCProperties);
        }
        #region Functions
        private void InitializeSettings()
        {
            InitializeLayerProperties();
            InitializeMapProperties();
            InitializeNPCProperties();
            InitializeExitFieldProperties();
            InitializeEventFieldProperties();
            InitializeOverlapProperties();
            InitializeTileModProperties();
            InitializeSolidModProperties();

            overlapTileset = Model.OverlapTileset;

            // load the individual editors

            levelsTileset.TopLevel = false;
            levelsTilemap.TopLevel = false;
            levelsSolidTiles.TopLevel = false;
            levelsTemplate.TopLevel = false;
            levelsTileset.Dock = DockStyle.Right;
            levelsTilemap.Dock = DockStyle.Fill;
            levelsSolidTiles.Dock = DockStyle.Right;
            levelsTemplate.Dock = DockStyle.Right;
            panelLevels.Controls.Add(levelsTileset);
            panelLevels.Controls.Add(levelsTilemap);
            panelLevels.Controls.Add(levelsSolidTiles);
            panelLevels.Controls.Add(levelsTemplate);

            openTilemap.Checked = true;
            openTilemap_Click(null, null);
            openTileset.Checked = true;
            openTileset_Click(null, null);

            levelsTileset.BringToFront();
            levelsTilemap.BringToFront();
        }
        public void RefreshLevel()
        {
            Cursor.Current = Cursors.WaitCursor;
            updatingLevel = true; // Start
            try
            {
                if (levelCheck.Index == index && !fullUpdate)
                {
                    tileset.RedrawTilesets(); // Redraw all tilesets
                    tilemap.RedrawTilemaps();
                    tileMods.RedrawTilemaps();
                    LoadTemplateEditor();
                    LoadTilesetEditor();
                    LoadTilemapEditor();
                }
                else
                {
                    CreateNewLevelData();
                    InitializeLayerProperties();
                    InitializeMapProperties();
                    InitializeNPCProperties();
                    InitializeExitFieldProperties();
                    InitializeEventFieldProperties();
                    InitializeOverlapProperties();
                    InitializeTileModProperties();
                    InitializeSolidModProperties();
                }
            }
            catch
            {
                CreateNewLevelData();
            }
            updatingLevel = false; // Done
            Cursor.Current = Cursors.Arrow;
        }
        private void CreateNewLevelData()
        {
            levelCheck = level;
            if (tilemap != null)
                tilemap.Assemble();
            tileset = new Tileset(levelMap, paletteSet);
            tilemap = new LevelTilemap(level, tileset);
            foreach (Level l in levels)
            {
                l.LevelTileMods.ClearTilemaps();
                l.LevelSolidMods.ClearTilemaps();
            }
            foreach (LevelTileMods.Mod mod in tileMods.Mods)
            {
                mod.TilemapA = new LevelTilemap(level, tileset, mod, false);
                if (mod.Set)
                    mod.TilemapB = new LevelTilemap(level, tileset, mod, true);
            }
            foreach (LevelSolidMods.LevelMod mod in solidMods.Mods)
                mod.Pixels = solidity.GetTilemapPixels(mod);
            solidityMap = new LevelSolidMap(levelMap);
            fullUpdate = false;

            // load the individual editors
            LoadPaletteEditor();
            LoadGraphicEditor();
            LoadTemplateEditor();
            LoadTilesetEditor();
            LoadTilemapEditor();

            SetLevelInfo();
        }
        private void LevelChange()
        {
            // Code that must happen before a level changes goes here
            tilemap.Assemble(); // Assemble the edited tileMap into the model

            ResetOverlay();
            RefreshLevel();

            if (levelsTileset.Layer == 2 && levelMap.GraphicSetL3 == 0xFF)
                levelsTileset.Layer = 0;

            // load the individual editors
            LoadPaletteEditor();
            LoadGraphicEditor();
            LoadTemplateEditor();
            LoadTilesetEditor();
            LoadTilemapEditor();

            GC.Collect();
        }
        private void ResetOverlay()
        {
            overlay.NPCImages = null;
        }
        private void SetLevelInfo()
        {
            List<string[]> items = new List<string[]>();
            items.Add(new string[] { "Layer", ((index * 18) + 0x1D0040).ToString("X6") });
            items.Add(new string[] { "Map", ((index * 2) + 0x148000).ToString("X6") });
            int pointer = Bits.GetShort(Model.Data, (index * 2) + 0x148000);
            int offset = Bits.GetShort(Model.Data, pointer);
            items.Add(new string[] { "NPC", (offset + 0x140000).ToString("X6") });
            pointer = (index * 2) + 0x1D2D64;
            offset = Bits.GetShort(Model.Data, pointer);
            items.Add(new string[] { "Exit", (offset + 0x1D0000).ToString("X6") });
            pointer = (index * 2) + 0x20E000;
            offset = Bits.GetShort(Model.Data, pointer);
            items.Add(new string[] { "Event", (offset + 0x200000).ToString("X6") });
            pointer = (index * 2) + 0x1D4905;
            offset = Bits.GetShort(Model.Data, pointer);
            items.Add(new string[] { "Overlap", (offset + 0x1D0000).ToString("X6") });
            pointer = (index * 2) + 0x1D5EBD;
            offset = Bits.GetShort(Model.Data, pointer);
            items.Add(new string[] { "Tile mod", (offset + 0x1D0000).ToString("X6") });
            pointer = (index * 2) + 0x1D8DB0;
            offset = Bits.GetShort(Model.Data, pointer);
            items.Add(new string[] { "Solid mod", (offset + 0x1D0000).ToString("X6") });
            ListViewItem[] listViewItems = new ListViewItem[items.Count];
            for (int i = 0; i < items.Count; i++)
                listViewItems[i] = new ListViewItem(items[i]);
            levelInfo.Columns[0].Text = "Element";
            levelInfo.Columns[1].Text = "Offset";
            levelInfo.Items.Clear();
            levelInfo.Items.AddRange(listViewItems);
        }
        public void AlertLabel()
        {
            //Do.AlertLabel(labelAlert, "Move the mouse cursor over the selection to click and drag.", Color.Lime);
        }
        // directories
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
                MessageBox.Show("Sorry, there was an error trying to create the directory : " + dir, "LAZY SHELL");
                return false;
            }
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
        // assemblers
        public void Assemble()
        {
            LevelChange();
            settings.Save();
            foreach (Level l in levels)
                l.Assemble();
            foreach (PrioritySet ps in prioritySets)
                ps.Assemble();
            foreach (LevelMap lm in levelMaps)
                lm.Assemble();
            foreach (PaletteSet ps in paletteSets)
                ps.Assemble(1);
            foreach (NPCProperties np in npcProperties)
                np.Assemble();
            foreach (SolidityTile st in solidTiles)
                st.Assemble();
            foreach (NPCSpritePartitions sp in npcSpritePartitions)
                sp.Assemble();

            ushort offsetStart = 0x3166;
            if (CalculateFreeExitSpace() >= 0)
            {
                for (int i = 0; i < 512; i++)
                    offsetStart = levels[i].LevelExits.Assemble(offsetStart);
            }
            else
                MessageBox.Show("Exit fields were not saved because they exceed the maximum alotted space.", "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Information);

            offsetStart = 0xE400;
            if (CalculateFreeEventSpace() >= 6)
            {
                for (int i = 0; i < 512; i++)
                    offsetStart = levels[i].LevelEvents.Assemble(offsetStart);
            }
            else
                MessageBox.Show("Event fields were not saved because they exceed the maximum alotted space.", "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Information);

            offsetStart = 0x8400;
            if (CalculateFreeNPCSpace() >= 4)
            {
                for (int i = 0; i < 512; i++)
                    offsetStart = levels[i].LevelNPCs.Assemble(offsetStart);
            }
            else
                MessageBox.Show("NPCs were not saved because they exceed the maximum alotted space.", "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Information);

            offsetStart = 0x4D05;
            if (CalculateFreeOverlapSpace() >= 0)
            {
                for (int i = 0; i < 512; i++)
                    offsetStart = levels[i].LevelOverlaps.Assemble(offsetStart);
            }
            else
                MessageBox.Show("Overlaps were not saved because they exceed the maximum alotted space.", "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Information);

            int offset = 0x1D62BD;
            if (CalculateFreeTileModSpace() >= 0)
            {
                for (int i = 0; i < 512; i++)
                    levels[i].LevelTileMods.Assemble(ref offset);
            }
            else
                MessageBox.Show("Tile mods were not saved because they exceed the maximum alotted space.", "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Information);
            offset = 0x1D91B0;
            if (CalculateFreeSolidModSpace() >= 0)
            {
                for (int i = 0; i < 512; i++)
                    levels[i].LevelSolidMods.Assemble(ref offset);
            }
            else
                MessageBox.Show("Solid mods were not saved because they exceed the maximum alotted space.", "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Model.Compress(Model.GraphicSets, Model.EditGraphicSets, 0x0A0000, 0x146000, "GRAPHIC SET",
                0, 78, 94, 111, 129, 147, 167, 184, 204, 236, 261);
            tilemap.Assemble();
            Model.Compress(Model.Tilemaps, Model.EditTileMaps, 0x160000, 0x1A8000, "TILE MAP",
                0, 109, 163, 219, 275);
            Model.Compress(Model.SolidityMaps, Model.EditSolidityMaps, 0x1B0000, 0x1C8000, "SOLIDITY MAP",
                0, 80);
            Model.Compress(Model.Tilesets, Model.EditTileSets, 0x3B0000, 0x3DC000, "TILE SET",
                0, 58, 91);

            Model.HexViewer.Compare();

            checksum = Do.GenerateChecksum(levels, levelMaps, Model.GraphicSets, Model.Tilesets,
                Model.Tilemaps, Model.SolidityMaps, Model.PaletteSets, Model.NPCProperties);
        }
        #endregion
        #region Event Handlers
        private void levelNum_ValueChanged(object sender, EventArgs e)
        {
            if (updatingLevel) return;
            levelName.SelectedIndex = (int)levelNum.Value;
            LevelChange();
            levelNum.Focus();
            settings.LastLevel = (int)levelNum.Value;
            //
            if (!disableNavigate)
            {
                navigateBackward.Push(lastNavigate);
                navigateBck.Enabled = true;
                lastNavigate = index;
            }
        }
        private void levelName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updatingLevel) return;
            levelNum.Value = levelName.SelectedIndex;
        }
        private void addThisLevelToNotesDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Model.Program.Notes == null || !Model.Program.Notes.Visible)
                Model.Program.CreateNotesWindow();
            Notes temp = Model.Program.Notes;
            if (temp.ThisNotes == null)
                temp.LoadNotes();
            if (temp.ThisNotes != null)
            {
                temp.AddingFromEditor(1, index, settings.LevelNames[index], settings.LevelNames[index]);
                temp.BringToFront();
            }
            else
            {
                MessageBox.Show("Could not add element to notes database.", "LAZY SHELL",
                    MessageBoxButtons.OK);
            }
        }
        private void navigateBck_Click(object sender, EventArgs e)
        {
            if (navigateBackward.Count < 1)
                return;
            navigateForward.Push(index);
            //
            updatingLevel = true;
            index = navigateBackward.Peek();
            levelName.SelectedIndex = index;
            updatingLevel = false;
            //
            LevelChange();
            levelNum.Focus();
            settings.LastLevel = (int)levelNum.Value;
            lastNavigate = index;
            navigateBackward.Pop();
            navigateBck.Enabled = navigateBackward.Count > 0;
            navigateFwd.Enabled = true;
        }
        private void navigateFwd_Click(object sender, EventArgs e)
        {
            if (navigateForward.Count < 1)
                return;
            navigateBackward.Push(index);
            //
            updatingLevel = true;
            index = navigateForward.Peek();
            levelName.SelectedIndex = index;
            updatingLevel = false;
            //
            LevelChange();
            levelNum.Focus();
            settings.LastLevel = (int)levelNum.Value;
            lastNavigate = index;
            navigateForward.Pop();
            navigateFwd.Enabled = navigateForward.Count > 0;
            navigateBck.Enabled = true;
        }
        // toolstrip menu items : File
        private void save_Click(object sender, EventArgs e)
        {
            Assemble();
        }
        private void import_ButtonClick(object sender, EventArgs e)
        {

        }
        private void export_ButtonClick(object sender, EventArgs e)
        {

        }
        private void clear_ButtonClick(object sender, EventArgs e)
        {

        }
        private void spaceAnalyzer_Click(object sender, EventArgs e)
        {
            LevelChange();
            sa = new SpaceAnalyzer();
            sa.Show();
            new ToolTipLabel(sa, baseConvertor, helpTips);
        }
        private void importArchitectureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (new IOArchitecture("import", index, levelMap, paletteSet, tileset, tilemap, prioritySets[layer.PrioritySet]).ShowDialog() == DialogResult.Cancel)
                return;
            fullUpdate = true;
            if (!updatingLevel)
                RefreshLevel();
        }
        private void exportArchitectureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new IOArchitecture("export", index, levelMap, paletteSet, tileset, tilemap, prioritySets[layer.PrioritySet]).ShowDialog();
        }
        private void importLevelDataAll_Click(object sender, EventArgs e)
        {
            IOElements ioElements = new IOElements(this, (int)levelNum.Value, "IMPORT LEVEL DATA...");
            if (ioElements.ShowDialog() == DialogResult.Cancel)
                return;
            fullUpdate = true;
            if (!updatingLevel)
                RefreshLevel();

            if (CalculateFreeNPCSpace() < 0)
                MessageBox.Show("The total number of NPCs for all levels has exceeded the maximum allotted space.", "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (CalculateFreeExitSpace() < 0)
                MessageBox.Show("The total number of exit fields for all levels has exceeded the maximum allotted space.", "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (CalculateFreeEventSpace() < 0)
                MessageBox.Show("The total number of event fields for all levels has exceeded the maximum allotted space.", "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (CalculateFreeOverlapSpace() < 0)
                MessageBox.Show("The total number of overlaps for all levels has exceeded the maximum allotted space.", "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void exportLevelDataAll_Click(object sender, EventArgs e)
        {
            new IOElements(this, (int)levelNum.Value, "EXPORT LEVELS...").ShowDialog();
        }
        private void exportLevelImagesAll_Click(object sender, EventArgs e)
        {
            ExportImages exportImages = new ExportImages(index, "levels");
            exportImages.ShowDialog();
        }
        private void clearLevelDataAll_Click(object sender, EventArgs e)
        {
            if (new ClearElements(null, (int)levelNum.Value, "CLEAR LEVEL DATA...").ShowDialog() == DialogResult.Cancel)
                return;
            fullUpdate = true;
            if (!updatingLevel)
                RefreshLevel();
        }
        private void clearTilesetsAll_Click(object sender, EventArgs e)
        {
            if (new ClearElements(null, (int)(levelMap.TilesetL1 + 0x20), "CLEAR TILESETS...").ShowDialog() == DialogResult.Cancel)
                return;
            new ClearElements(null, (int)(levelMap.TilesetL2 + 0x20), "CLEAR TILESETS...").buttonOK_Click(null, null);
            if (levelMap.GraphicSetL3 != 0xFF)
                new ClearElements(null, (int)(levelMap.TilesetL3), "CLEAR TILESETS...").buttonOK_Click(null, null);
            fullUpdate = true;
            if (!updatingLevel)
                RefreshLevel();
        }
        private void clearTilemapsAll_Click(object sender, EventArgs e)
        {
            if (new ClearElements(null, (int)(levelMap.TilemapL1 + 0x40), "CLEAR TILEMAPS...").ShowDialog() == DialogResult.Cancel)
                return;
            new ClearElements(null, (int)(levelMap.TilemapL2 + 0x40), "CLEAR TILEMAPS...").buttonOK_Click(null, null);
            if (levelMap.GraphicSetL3 != 0xFF)
                new ClearElements(null, (int)(levelMap.TilemapL3), "CLEAR TILEMAPS...").buttonOK_Click(null, null);
            fullUpdate = true;
            if (!updatingLevel)
                RefreshLevel();
        }
        private void clearPhysicalMapsAll_Click(object sender, EventArgs e)
        {
            if (new ClearElements(null, (int)mapPhysicalMapNum.Value, "CLEAR SOLIDITY MAPS...").ShowDialog() == DialogResult.Cancel)
                return;
            fullUpdate = true;
            solidityMap = new LevelSolidMap(levelMap);
            solidityMap.Image = null;
            LoadTilemapEditor();
        }
        private void clearAllComponentsAll_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "You are about to clear all level data, tilesets, tilemaps, physical maps and battlefields.\n" +
                "This will essentially wipe the slate clean for anything having to do with levels.\n\n" +
                "Are you sure you want to do this?", "LAZY SHELL", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result != DialogResult.Yes) return;

            for (int i = 0; i < 510; i++)
            {
                levels[i].Layer.Clear();
                levels[i].LevelEvents.Clear();
                levels[i].LevelExits.Clear();
                levels[i].LevelNPCs.Clear();
                levels[i].LevelOverlaps.Clear();
            }
            for (int i = 0; i < Model.Tilesets.Length; i++)
            {
                if (i < 0x20)
                    Model.Tilesets[i] = new byte[0x1000];
                else
                    Model.Tilesets[i] = new byte[0x2000];
                Model.EditTileSets[i] = true;
            }
            for (int i = 0; i < Model.Tilemaps.Length; i++)
            {
                if (i < 0x40)
                    Model.Tilemaps[i] = new byte[0x1000];
                else
                    Model.Tilemaps[i] = new byte[0x2000];
                Model.EditTileMaps[i] = true;
            }
            for (int i = 0; i < Model.SolidityMaps.Length; i++)
            {
                Model.SolidityMaps[i] = new byte[0x20C2];
                Model.EditSolidityMaps[i] = true;
            }
            for (int i = 0; i < Model.TileSetsBF.Length; i++)
            {
                Model.TileSetsBF[i] = new byte[0x2000];
                Model.EditTileSetsBF[i] = true;
            }

            fullUpdate = true;
            if (!updatingLevel)
                RefreshLevel();
            solidityMap.Image = null;
        }
        private void clearAllComponentsCurrent_Click(object sender, EventArgs e)
        {
            level.Layer.Clear();
            level.LevelEvents.Clear();
            level.LevelExits.Clear();
            level.LevelNPCs.Clear();
            level.LevelOverlaps.Clear();

            Model.Tilesets[levelMap.TilesetL1 + 0x20] = new byte[0x2000];
            Model.Tilesets[levelMap.TilesetL2 + 0x20] = new byte[0x2000];
            Model.Tilesets[levelMap.TilesetL3] = new byte[0x1000];
            Model.EditTileSets[levelMap.TilesetL1 + 0x20] = true;
            Model.EditTileSets[levelMap.TilesetL2 + 0x20] = true;
            Model.EditTileSets[levelMap.TilesetL3] = true;

            Model.Tilemaps[levelMap.TilemapL1 + 0x40] = new byte[0x2000];
            Model.Tilemaps[levelMap.TilemapL2 + 0x40] = new byte[0x2000];
            Model.Tilemaps[levelMap.TilemapL3] = new byte[0x1000];
            Model.EditTileMaps[levelMap.TilemapL1 + 0x40] = true;
            Model.EditTileMaps[levelMap.TilemapL2 + 0x40] = true;
            Model.EditTileMaps[levelMap.TilemapL3] = true;

            solidityMap.Clear(1);

            fullUpdate = true;
            if (!updatingLevel)
                RefreshLevel();
            solidityMap.Image = null;
        }
        private void unusedGraphicSetsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "You are about to clear all UNUSED graphic sets.\n\n" +
                "Do you wish to continue?",
                "LAZY SHELL", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.No)
                return;

            // Clear unused tilesets
            bool[] used = new bool[Model.GraphicSets.Length];
            LevelMap lm;
            foreach (Level lv in levels)
            {
                lm = levelMaps[lv.LevelMap];
                used[lm.GraphicSetA + 0x48] = true;
                used[lm.GraphicSetB + 0x48] = true;
                used[lm.GraphicSetC + 0x48] = true;
                used[lm.GraphicSetD + 0x48] = true;
                used[lm.GraphicSetE + 0x48] = true;
                used[lm.GraphicSetL3] = true;
            }

            for (int i = 0; i < Model.Tilesets.Length; i++)
            {
                if (!used[i])
                {
                    Model.GraphicSets[i] = new byte[Model.GraphicSets[i].Length];
                    Model.EditGraphicSets[i] = true;
                }
            }

            fullUpdate = true;
            if (!updatingLevel)
                RefreshLevel();
        }
        private void unusedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "You are about to clear all UNUSED tilesets.\n\n" +
                "Do you wish to continue?",
                "LAZY SHELL", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.No)
                return;

            // Clear unused tilesets
            bool[] used = new bool[Model.Tilesets.Length];
            LevelMap lm;
            foreach (Level lv in levels)
            {
                lm = levelMaps[lv.LevelMap];
                used[lm.TilesetL1 + 0x20] = true;
                used[lm.TilesetL2 + 0x20] = true;
                used[lm.TilesetL3] = true;
            }

            for (int i = 0; i < Model.Tilesets.Length; i++)
            {
                if (!used[i])
                {
                    Model.Tilesets[i] = new byte[i < 0x20 ? 0x1000 : 0x2000];
                    Model.EditTileSets[i] = true;
                }
            }

            fullUpdate = true;
            if (!updatingLevel)
                RefreshLevel();
        }
        private void unusedToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
              "You are about to clear all UNUSED tilemaps.\n\n" +
              "Do you wish to continue?",
              "LAZY SHELL", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.No)
                return;

            // Clear unused tilemaps
            bool[] used = new bool[Model.Tilemaps.Length];
            LevelMap lm;
            foreach (Level lv in levels)
            {
                lm = levelMaps[lv.LevelMap];
                used[lm.TilemapL1 + 0x40] = true;
                used[lm.TilemapL2 + 0x40] = true;
                used[lm.TilemapL3] = true;
            }

            for (int i = 0; i < Model.Tilemaps.Length; i++)
            {
                if (!used[i])
                {
                    Model.Tilemaps[i] = new byte[i < 0x40 ? 0x1000 : 0x2000];
                    Model.EditTileMaps[i] = true;
                }
            }

            fullUpdate = true;
            if (!updatingLevel)
                RefreshLevel();
        }
        private void unusedToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
              "You are about to clear all UNUSED solidity maps.\n\n" +
              "Do you wish to continue?",
              "LAZY SHELL", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.No)
                return;

            // Clear unused physical maps
            bool[] used = new bool[Model.SolidityMaps.Length];
            LevelMap lm;
            foreach (Level lv in levels)
            {
                lm = levelMaps[lv.LevelMap];
                used[lm.SolidityMap] = true;
            }

            for (int i = 0; i < Model.SolidityMaps.Length; i++)
            {
                if (!used[i])
                {
                    Model.SolidityMaps[i] = new byte[0x20C2];
                    Model.EditSolidityMaps[i] = true;
                }
            }

            fullUpdate = true;
            if (!updatingLevel)
                RefreshLevel();
        }
        private void unusedToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            // Clear all unused components
            unusedGraphicSetsToolStripMenuItem_Click(null, null);
            unusedToolStripMenuItem_Click(null, null);
            unusedToolStripMenuItem1_Click(null, null);
            unusedToolStripMenuItem2_Click(null, null);
        }
        private void arraysToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fullPath = GetDirectoryPath("Select directory to export arrays to...");
            fullPath += "\\" + Model.GetFileNameWithoutPath() + " - Arrays\\";

            // Create Level Data directory
            if (!CreateDir(fullPath)) return;

            FileStream fs;
            BinaryWriter bw;
            //try
            //{
            // Create the file to store the level data
            for (int i = 0; i < Model.GraphicSets.Length; i++)
            {
                CreateDir(fullPath + "Graphic Sets\\");
                fs = new FileStream(fullPath + "Graphic Sets\\graphicSet." + i.ToString("d3") + ".bin", FileMode.Create, FileAccess.ReadWrite);
                bw = new BinaryWriter(fs);
                bw.Write(Model.GraphicSets[i], 0, Model.GraphicSets[i].Length);
                bw.Close();
                fs.Close();
            }
            for (int i = 0; i < Model.SolidityMaps.Length; i++)
            {
                CreateDir(fullPath + "Solidity Maps\\");
                fs = new FileStream(fullPath + "Solidity Maps\\solidMap." + i.ToString("d3") + ".bin", FileMode.Create, FileAccess.ReadWrite);
                bw = new BinaryWriter(fs);
                bw.Write(Model.SolidityMaps[i], 0, Model.SolidityMaps[i].Length);
                bw.Close();
                fs.Close();
            }
            for (int i = 0; i < Model.Tilemaps.Length; i++)
            {
                CreateDir(fullPath + "Tile Maps\\");
                fs = new FileStream(fullPath + "Tile Maps\\tileMap." + i.ToString("d3") + ".bin", FileMode.Create, FileAccess.ReadWrite);
                bw = new BinaryWriter(fs);
                bw.Write(Model.Tilemaps[i], 0, Model.Tilemaps[i].Length);
                bw.Close();
                fs.Close();
            }
            for (int i = 0; i < Model.Tilesets.Length; i++)
            {
                CreateDir(fullPath + "Tile Sets\\");
                fs = new FileStream(fullPath + "Tile Sets\\tileSet." + i.ToString("d3") + ".bin", FileMode.Create, FileAccess.ReadWrite);
                bw = new BinaryWriter(fs);
                bw.Write(Model.Tilesets[i], 0, Model.Tilesets[i].Length);
                bw.Close();
                fs.Close();
            }
            for (int i = 0; i < Model.TileSetsBF.Length; i++)
            {
                CreateDir(fullPath + "Battlefield Tile Sets\\");
                fs = new FileStream(fullPath + "Battlefield Tile Sets\\tileSetBF." + i.ToString("d3") + ".bin", FileMode.Create, FileAccess.ReadWrite);
                bw = new BinaryWriter(fs);
                bw.Write(Model.TileSetsBF[i], 0, Model.TileSetsBF[i].Length);
                bw.Close();
                fs.Close();
            }
            //}
            //catch
            //{
            //    MessageBox.Show("There was a problem exporting the arrays.");
            //}
        }
        private void arraysToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            fullPath = GetDirectoryPath("Select directory to import arrays from...");
            fullPath += "\\";

            FileStream fs;
            BinaryReader br;
            try
            {
                // Create the file to store the level data
                for (int i = 0; i < Model.GraphicSets.Length; i++)
                {
                    if (!File.Exists(fullPath + "Graphic Sets\\graphicSet." + i.ToString("d3") + ".bin"))
                        continue;
                    fs = File.OpenRead(fullPath + "Graphic Sets\\graphicSet." + i.ToString("d3") + ".bin");
                    br = new BinaryReader(fs);
                    Model.GraphicSets[i] = br.ReadBytes(Model.GraphicSets[i].Length);
                    br.Close();
                    fs.Close();

                    Model.EditGraphicSets[i] = true;
                }
                for (int i = 0; i < Model.SolidityMaps.Length; i++)
                {
                    if (!File.Exists(fullPath + "Solidity Maps\\solidMap." + i.ToString("d3") + ".bin"))
                        continue;
                    fs = File.OpenRead(fullPath + "Solidity Maps\\solidMap." + i.ToString("d3") + ".bin");
                    br = new BinaryReader(fs);
                    Model.SolidityMaps[i] = br.ReadBytes(Model.SolidityMaps[i].Length);
                    br.Close();
                    fs.Close();

                    Model.EditSolidityMaps[i] = true;
                }
                for (int i = 0; i < Model.Tilemaps.Length; i++)
                {
                    if (!File.Exists(fullPath + "Tile Maps\\tileMap." + i.ToString("d3") + ".bin"))
                        continue;
                    fs = File.OpenRead(fullPath + "Tile Maps\\tileMap." + i.ToString("d3") + ".bin");
                    br = new BinaryReader(fs);
                    Model.Tilemaps[i] = br.ReadBytes(Model.Tilemaps[i].Length);
                    br.Close();
                    fs.Close();

                    Model.EditTileMaps[i] = true;
                }
                for (int i = 0; i < Model.Tilesets.Length; i++)
                {
                    if (!File.Exists(fullPath + "Tile Sets\\tileSet." + i.ToString("d3") + ".bin"))
                        continue;
                    fs = File.OpenRead(fullPath + "Tile Sets\\tileSet." + i.ToString("d3") + ".bin");
                    br = new BinaryReader(fs);
                    Model.Tilesets[i] = br.ReadBytes(Model.Tilesets[i].Length);
                    br.Close();
                    fs.Close();

                    Model.EditTileSets[i] = true;
                }
                for (int i = 0; i < Model.TileSetsBF.Length; i++)
                {
                    if (!File.Exists(fullPath + "Battlefield Tile Sets\\tileSetBF." + i.ToString("d3") + ".bin"))
                        continue;
                    fs = File.OpenRead(fullPath + "Battlefield Tile Sets\\tileSetBF." + i.ToString("d3") + ".bin");
                    br = new BinaryReader(fs);
                    Model.TileSetsBF[i] = br.ReadBytes(Model.TileSetsBF[i].Length);
                    br.Close();
                    fs.Close();

                    Model.EditTileSetsBF[i] = true;
                }

                fullUpdate = true;
                RefreshLevel();
            }
            catch
            {
                MessageBox.Show("There was a problem importing the arrays.", "LAZY SHELL");
            }
        }
        private void dumpTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.FileName = Model.GetFileNameWithoutPath() + " - NPCS.txt";
            saveFileDialog.RestoreDirectory = true;
            if (saveFileDialog.ShowDialog() != DialogResult.OK)
                return;

            StreamWriter npcrip = File.CreateText(saveFileDialog.FileName);
            Level tlvl;
            NPC tnpc;
            NPC.Clone tins;
            int offset;
            int cnt;
            string temp;
            //
            //for (int i = 0; i < Lists.LevelNames.Length; i++)
            //{
            //    npcrip.WriteLine("{" + levels[i].LevelNPCs.MapHeader.ToString("d3") + "} " + Lists.Numerize(Lists.LevelNames, i, 3));
            //}
            //npcrip.Close();
            //return;
            //
            for (int i = 0; i < levels.Length; i++)
            {
                cnt = 0;
                tlvl = levels[i];
                offset = tlvl.LevelNPCs.StartingOffset;

                npcrip.WriteLine("[" + i.ToString("d3") + "]" +
                    "------------------------------------------------------------>");

                for (int j = 0; j < tlvl.LevelNPCs.Npcs.Count; j++)
                {
                    tnpc = (NPC)tlvl.LevelNPCs.Npcs[j];
                    if (tnpc.EngageType == 0) temp = (tnpc.EventORpack + tnpc.PropertyB).ToString("d4");
                    else temp = "N/A";

                    npcrip.Write("NPC #" + cnt.ToString("d2") + ", event: " + temp +
                        ", action: " + (tnpc.Movement + tnpc.PropertyC).ToString("d4") + "\n");

                    for (int k = 0; k < tnpc.Clones.Count; k++)
                    {
                        tins = (NPC.Clone)tnpc.Clones[k];
                        if (tnpc.EngageType == 0) temp = (tins.PropertyB + tnpc.EventORpack).ToString("d4");
                        else temp = "N/A";

                        npcrip.Write("NPC #" + (cnt + 1).ToString("d2") + ", event: " + temp +
                        ", action: " + (tnpc.Movement + tins.PropertyC).ToString("d4") + "\n");

                        cnt++;
                    }

                    cnt++;
                }

                npcrip.Write("\n");
            }

            npcrip.Close();
        }
        // hex editor
        private void hexEditor_Click(object sender, EventArgs e)
        {
            Model.HexViewer.Offset = ((index * 18) + 0x1D0040) & 0xFFFFF0;
            Model.HexViewer.SelectionStart = (((index * 18) + 0x1D0040) & 15) * 3;
            Model.HexViewer.Compare();
            Model.HexViewer.Show();
        }
        // reset
        private void resetLevelMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("You're about to undo all changes to the current level map. Go ahead with reset?",
                "LAZY SHELL", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;
            levelMap = new LevelMap(Model.Data, level.LevelMap);
            mapNum_ValueChanged(null, null);
        }
        private void resetLayerDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("You're about to undo all changes to the current layer data. Go ahead with reset?",
                "LAZY SHELL", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;
            layer = new LevelLayer(Model.Data, index);
            levelNum_ValueChanged(null, null);
        }
        private void resetNPCDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("You're about to undo all changes to the current NPCs. Go ahead with reset?",
                "LAZY SHELL", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;
            npcs = new LevelNPCs(Model.Data, index);
            overlay.NPCImages = null;
            InitializeNPCProperties();
        }
        private void resetEventDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("You're about to undo all changes to the current events. Go ahead with reset?",
                "LAZY SHELL", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;
            events = new LevelEvents(Model.Data, index);
            InitializeEventFieldProperties();
        }
        private void resetExitDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("You're about to undo all changes to the current exits. Go ahead with reset?",
                "LAZY SHELL", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;
            exits = new LevelExits(Model.Data, index);
            InitializeExitFieldProperties();
        }
        private void resetOverlapDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("You're about to undo all changes to the current overlaps. Go ahead with reset?",
                "LAZY SHELL", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;
            overlaps = new LevelOverlaps(Model.Data, index);
            InitializeOverlapProperties();
        }
        private void resetTilemapModsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("You're about to undo all changes to the current tilemap mods. Go ahead with reset?",
                "LAZY SHELL", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;
            tileMods = new LevelTileMods(Model.Data, index);
            foreach (Level l in levels)
                l.LevelTileMods.ClearTilemaps();
            foreach (LevelTileMods.Mod mod in tileMods.Mods)
            {
                mod.TilemapA = new LevelTilemap(level, tileset, mod, false);
                if (mod.Set)
                    mod.TilemapB = new LevelTilemap(level, tileset, mod, true);
            }
            InitializeTileModProperties();
        }
        private void resetSolidityModsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("You're about to undo all changes to the current solidity mods. Go ahead with reset?",
                "LAZY SHELL", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;
            solidMods = new LevelSolidMods(Model.Data, index);
            foreach (Level l in levels)
                l.LevelSolidMods.ClearTilemaps();
            foreach (LevelSolidMods.LevelMod mod in solidMods.Mods)
                mod.Pixels = solidity.GetTilemapPixels(mod);
            InitializeSolidModProperties();
        }
        private void resetGraphicSetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("You're about to undo all changes to the current graphic sets. Go ahead with reset?",
                "LAZY SHELL", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;
            Model.Decompress(Model.GraphicSets, 0x0A0000, 0x150000, 0x2000, "", levelMap.GraphicSetA + 0x48, levelMap.GraphicSetA + 0x49, false);
            Model.Decompress(Model.GraphicSets, 0x0A0000, 0x150000, 0x2000, "", levelMap.GraphicSetB + 0x48, levelMap.GraphicSetB + 0x49, false);
            Model.Decompress(Model.GraphicSets, 0x0A0000, 0x150000, 0x2000, "", levelMap.GraphicSetC + 0x48, levelMap.GraphicSetC + 0x49, false);
            Model.Decompress(Model.GraphicSets, 0x0A0000, 0x150000, 0x2000, "", levelMap.GraphicSetD + 0x48, levelMap.GraphicSetD + 0x49, false);
            Model.Decompress(Model.GraphicSets, 0x0A0000, 0x150000, 0x2000, "", levelMap.GraphicSetE + 0x48, levelMap.GraphicSetE + 0x49, false);
            fullUpdate = true;
            if (!updatingLevel)
                RefreshLevel();
        }
        private void resetPaletteSetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("You're about to undo all changes to the current palette set. Go ahead with reset?",
                "LAZY SHELL", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;
            int palette = levelMap.PaletteSet;
            paletteSet = new PaletteSet(Model.Data, palette, (palette * 0xD4) + 0x249FE2, 8, 16, 30);
            fullUpdate = true;
            if (!updatingLevel)
                RefreshLevel();
        }
        private void resetTilesetsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("You're about to undo all changes to the current tilesets. Go ahead with reset?",
                "LAZY SHELL", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;
            Model.Decompress(Model.Tilesets, 0x3B0000, 0x3E0000, 0x1000, "", levelMap.TilesetL1 + 0x20, levelMap.TilesetL1 + 0x21, false);
            Model.Decompress(Model.Tilesets, 0x3B0000, 0x3E0000, 0x1000, "", levelMap.TilesetL2 + 0x20, levelMap.TilesetL2 + 0x21, false);
            Model.Decompress(Model.Tilesets, 0x3B0000, 0x3E0000, 0x1000, "", levelMap.TilesetL3, levelMap.TilesetL2 + 1, false);
            fullUpdate = true;
            if (!updatingLevel)
                RefreshLevel();
        }
        private void resetTilemapsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("You're about to undo all changes to the current tilemaps. Go ahead with reset?",
                "LAZY SHELL", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;
            Model.Decompress(Model.Tilemaps, 0x160000, 0x1B0000, 0x1000, 0x2000, "", 0x40, levelMap.TilemapL1 + 0x40, levelMap.TilemapL1 + 0x41, false);
            Model.Decompress(Model.Tilemaps, 0x160000, 0x1B0000, 0x1000, 0x2000, "", 0x40, levelMap.TilemapL2 + 0x40, levelMap.TilemapL2 + 0x41, false);
            Model.Decompress(Model.Tilemaps, 0x160000, 0x1B0000, 0x1000, 0x2000, "", 0x40, levelMap.TilemapL3, levelMap.TilemapL3 + 1, false);
            fullUpdate = true;
            if (!updatingLevel)
                RefreshLevel();
        }
        private void resetSolidityMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("You're about to undo all changes to the current solidity map. Go ahead with reset?",
                "LAZY SHELL", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;
            Model.Decompress(Model.SolidityMaps, 0x1B0000, 0x1D0000, 0x20C2, "", levelMap.SolidityMap, levelMap.SolidityMap + 1, false);
            fullUpdate = true;
            solidityMap = new LevelSolidMap(levelMap);
            solidityMap.Image = null;
            LoadTilemapEditor();
        }
        private void resetAllComponentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("You're about to undo all changes to all components. Go ahead with reset?",
                "LAZY SHELL", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;
            levelMap = new LevelMap(Model.Data, level.LevelMap);
            layer = new LevelLayer(Model.Data, index);
            npcs = new LevelNPCs(Model.Data, index);
            overlay.NPCImages = null;
            events = new LevelEvents(Model.Data, index);
            exits = new LevelExits(Model.Data, index);
            overlaps = new LevelOverlaps(Model.Data, index);
            tileMods = new LevelTileMods(Model.Data, index);
            solidMods = new LevelSolidMods(Model.Data, index);
            int palette = levelMap.PaletteSet;
            paletteSet = new PaletteSet(Model.Data, palette, (palette * 0xD4) + 0x249FE2, 8, 16, 30);
            Model.Decompress(Model.GraphicSets, 0x0A0000, 0x150000, 0x2000, "", levelMap.GraphicSetA + 0x48, levelMap.GraphicSetA + 0x49, false);
            Model.Decompress(Model.GraphicSets, 0x0A0000, 0x150000, 0x2000, "", levelMap.GraphicSetB + 0x48, levelMap.GraphicSetB + 0x49, false);
            Model.Decompress(Model.GraphicSets, 0x0A0000, 0x150000, 0x2000, "", levelMap.GraphicSetC + 0x48, levelMap.GraphicSetC + 0x49, false);
            Model.Decompress(Model.GraphicSets, 0x0A0000, 0x150000, 0x2000, "", levelMap.GraphicSetD + 0x48, levelMap.GraphicSetD + 0x49, false);
            Model.Decompress(Model.GraphicSets, 0x0A0000, 0x150000, 0x2000, "", levelMap.GraphicSetE + 0x48, levelMap.GraphicSetE + 0x49, false);
            Model.Decompress(Model.Tilesets, 0x3B0000, 0x3E0000, 0x1000, "", levelMap.TilesetL1 + 0x20, levelMap.TilesetL1 + 0x21, false);
            Model.Decompress(Model.Tilesets, 0x3B0000, 0x3E0000, 0x1000, "", levelMap.TilesetL2 + 0x20, levelMap.TilesetL2 + 0x21, false);
            Model.Decompress(Model.Tilesets, 0x3B0000, 0x3E0000, 0x1000, "", levelMap.TilesetL3, levelMap.TilesetL2 + 1, false);
            Model.Decompress(Model.Tilemaps, 0x160000, 0x1B0000, 0x1000, 0x2000, "", 0x40, levelMap.TilemapL1 + 0x40, levelMap.TilemapL1 + 0x41, false);
            Model.Decompress(Model.Tilemaps, 0x160000, 0x1B0000, 0x1000, 0x2000, "", 0x40, levelMap.TilemapL2 + 0x40, levelMap.TilemapL2 + 0x41, false);
            Model.Decompress(Model.Tilemaps, 0x160000, 0x1B0000, 0x1000, 0x2000, "", 0x40, levelMap.TilemapL3, levelMap.TilemapL3 + 1, false);
            Model.Decompress(Model.SolidityMaps, 0x1B0000, 0x1D0000, 0x20C2, "", levelMap.SolidityMap, levelMap.SolidityMap + 1, false);
            fullUpdate = true;
            RefreshLevel();
        }
        // toolstrip buttons
        private void SpaceAnalyzerMenuItem_Click(object sender, EventArgs e)
        {
            LevelChange();

            SpaceAnalyzer sa = new SpaceAnalyzer();
            sa.Show();

        }
        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        // level name editor
        private void changeLevelName_Click(object sender, EventArgs e)
        {
            toolStripTextBox1.Visible = changeLevelName.Checked;
            reset.Visible = changeLevelName.Checked;
            if (toolStripTextBox1.Visible)
            {
                toolStripTextBox1.Focus();
                toolStripTextBox1.Text = settings.LevelNames[index];
            }
        }
        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            settings.LevelNames[index] = this.toolStripTextBox1.Text;
            updatingLevel = true;
            levelName.BeginUpdate();
            levelName.Items.Clear();
            levelName.Items.AddRange(Lists.Numerize(Lists.Convert(settings.LevelNames)));
            levelName.SelectedIndex = index;
            levelName.EndUpdate();
            updatingLevel = false;
        }
        private void toolStripTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                changeLevelName.Checked = false;
                toolStripTextBox1.Visible = false;
                reset.Visible = false;
            }
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            toolStripTextBox1.Text = Lists.LevelNames[index];
        }
        //
        private void Levels_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyData == Keys.Escape)
            //    ResetTileReplace();
        }
        private void Levels_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Do.GenerateChecksum(levels, levelMaps, Model.GraphicSets, Model.Tilesets,
                Model.Tilemaps, Model.SolidityMaps, Model.PaletteSets, Model.NPCProperties) == checksum)
                goto Close;
            state.Draw = false;
            state.Erase = false;
            state.Select = false;
            state.Dropper = false;
            state.Fill = false;
            state.CartesianGrid = false;
            state.IsometricGrid = false;
            DialogResult result;
            result = MessageBox.Show("Levels have not been saved.\n\nWould you like to save changes?", "LAZY SHELL", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
                Assemble();
            else if (result == DialogResult.No)
            {
                Model.Levels = null;
                Model.LevelMaps = null;
                Model.NPCProperties = null;
                Model.PaletteSets = null;
                Model.PrioritySets = null;
                Model.Tilemaps[0] = null;
                Model.Tilesets[0] = null;
                Model.GraphicSets[0] = null;
                Model.SolidityMaps[0] = null;
            }
            else if (result == DialogResult.Cancel)
            {
                e.Cancel = true;
                return;
            }
        Close:
            searchWindow.Close();
            levelsTileset.TileEditor.Close();
            levelsSolidTiles.SearchSolidTile.Close();
            paletteEditor.Close();
            graphicEditor.Close();
            findNPCNumber.Close();
            searchWindow.Dispose();
            levelsTileset.TileEditor.Dispose();
            levelsSolidTiles.SearchSolidTile.Dispose();
            paletteEditor.Dispose();
            graphicEditor.Dispose();
            findNPCNumber.Dispose();
            if (lp != null)
                lp.Close();
            if (sa != null)
                sa.Close();
            if (partitionBrowser != null)
                partitionBrowser.Close();
            settings.Save();
        }
        private void Levels_FormClosed(object sender, FormClosedEventArgs e)
        {
            GC.Collect();
        }
        #endregion
    }
}
