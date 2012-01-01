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
        private PictureBox picture { get { return levelsTilemap.Picture; } set { levelsTilemap.Picture = value; } }
        private int zoom { get { return levelsTilemap.Zoom; } }
        private Level levelCheck; // Used to verify a level change
        private Overlay overlay = new Overlay(); // Object used to generate all the overlays for levels
        private bool updatingLevel = false; // Indicates that we are currently updating the level so we dont update during an update
        public bool UpdatingLevel { get { return updatingLevel; } set { updatingLevel = value; } }
        private bool fullUpdate = false; // Indicates that we need to do a complete update instead of a fast update
        private bool updatingProperties = false; // indicated whether to update or save properties
        private Previewer.Previewer lp;
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
            Do.AddShortcut(toolStripToggle, Keys.Control | Keys.S, new EventHandler(save_Click));
            Do.AddShortcut(toolStripToggle, Keys.F1, help);
            Do.AddShortcut(toolStripToggle, Keys.F2, baseConversion);
            searchWindow = new Search(levelNum, nameTextBox, searchLevelNames, levelName.Items);

            SetToolTips();
            new ToolTipLabel(this, toolTip1, baseConversion, help);

            if (settings.LevelNames.Count == 0)
                settings.LevelNames.AddRange(Lists.LevelNames);
            this.levelName.Items.AddRange(Lists.Numerize(settings.LevelNames));

            this.layerMessageBox.Items.Add("{NONE}");
            Dialogue[] dialogues = Model.GetDialogues(0, 128);
            for (int i = 0; i < 128; i++)
                this.layerMessageBox.Items.Add(dialogues[i].GetDialogueStub(true));

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

            findNPCNumber = new NPCEditor(this, npcID.Value);
            //
            new History(this);
            lastNavigate = index;
            checksum = Do.GenerateChecksum(levels, levelMaps, Model.GraphicSets, Model.TileSets,
                Model.TileMaps, Model.SolidityMaps, Model.PaletteSets, Model.NPCProperties);
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
        private void SetToolTips()
        {
            // Levels

            this.levelName.ToolTipText =
                "Select the level to edit by name. The name is based on a \n" +
                "label assigned by either the default or user-defined label. \n" +
                "Edit the level's name/label by clicking on \"LABEL\".";

            this.levelNum.ToolTipText =
                "Select the level to edit by #. The number is in hexadecimal.";

            this.changeLevelName.ToolTipText = "Edit the level's name/label.";

            this.toolTip1.SetToolTip(this.layerMessageBox,
                "The dialogue message that appears at the top of the \n" +
                "screen when the level is entered. These can be individually \n" +
                "edited in the \"DIALOGUES\" tab of the \"SPRITES\" editor.\n\n" +
                "In order for a message to show, either the \"SHOW \n" +
                "MESSAGE\" must be enable for any exit field that leads to \n" +
                "the current level or an event script command must be set \n" +
                "for the current level's \"Event #\" in the \"LEVEL \n" +
                "PROPERTIES\" panel in the \"FIELDS\" tab.");

            this.toolTip1.SetToolTip(this.layerPrioritySet,
                "The priority set of the current level is a set of properties \n" +
                "that handle how the layers of the level are drawn. Note \n" +
                "that editing the properties in the \"LAYER PRIORITIES\" for \n" +
                "the currently selected Priority Set will affect all other levels \n" +
                "that use the same Priority Set.\n\n" +
                "\"Mainscreen\" refers to the layers that are drawn opaquely \n" +
                "(ie. normally without 'see-through' effects).\n\n" +
                "\"Subscreen\" refers to the layers that are drawn \n" +
                "translucently (ie. 'see through' effects). Example: many \n" +
                "levels with water (which is translucent) have the water on \n" +
                "L3 (which is commonly used for water, clouds, fog, etc.) \n" +
                "which is enabled in the subscreen.Generally, at least one \n" +
                "(usually all) layer is enabled in the \"Color Math\" that is also \n" +
                "enabled in \"Mainscreen\" in order for the \"Subscreen\" layers \n" +
                "that are enabled to appear at all.\n\n" +
                "\"Color Math\" refers to the layers that the subscreen will \n" +
                "appear over. If nothing is enabled in \"Color Math\" then the \n" +
                "subscreen will not show at all.This is called \"Color Math\" \n" +
                "because the colors of the subscreen are being added to or \n" +
                "subtracted from the colors on the mainscreen, which \n" +
                "creates a translucent effect for the subscreen.");

            this.toolTip1.SetToolTip(this.layerColorMathIntensity,
                "\"Half\" intensity will halve the color values being added to or \n" +
                "subtracted from. Example: if the mainscreen color has 128 \n" +
                "for red and the subscreen color has 64 for red, then it adds \n" +
                "64 + 32 (or subtracts depending on the \"Mode\").This \n" +
                "generally creates a darker effect of the subscreen.\n\n" +
                "\"Full intensity will add or subtract the full values of the \n" +
                "colors. Example: if the mainscreen color has 128 for red \n" +
                "and the subscreen color has 64 for red, then it adds 128 + \n" +
                "64 (or subtracts depending on the \"Mode\").This creates a \n" +
                "much brighter effect than \"Half\" intensity.");

            this.toolTip1.SetToolTip(this.layerColorMathMode,
                "\"Plus\" mode will add the colors of the subscreen \n" +
                "together.\"Minus\" mode will subtract the subscreen colors \n" +
                "from the mainscreen colors. This creates a much darker \n" +
                "effect.\n\n" +
                "In reference to the other \"LAYER PRIORITY\" properties, \n" +
                "anything referring to an either/or case of subtracting or \n" +
                "adding is referring to the \"Mode\" property.");

            this.toolTip1.SetToolTip(this.layerMainscreenL1,
                "Layer 1 of the mainscreen.");

            this.toolTip1.SetToolTip(this.layerMainscreenL2,
                "Layer 2 of the mainscreen.");

            this.toolTip1.SetToolTip(this.layerMainscreenL3,
                "Layer 3 of the mainscreen.");

            this.toolTip1.SetToolTip(this.layerMainscreenNPC,
                "NPC layer of the mainscreen.");

            this.toolTip1.SetToolTip(this.layerSubscreenL1,
                "Layer 1 of the subscreen.");

            this.toolTip1.SetToolTip(this.layerSubscreenL2,
                "Layer 2 of the subscreen.");

            this.toolTip1.SetToolTip(this.layerSubscreenL3,
                "Layer 3 of the subscreen.");

            this.toolTip1.SetToolTip(this.layerSubscreenNPC,
                "NPC layer of the subscreen.");

            this.toolTip1.SetToolTip(this.layerColorMathL1,
                "Add / subtract subscreen from Layer 1 of the mainscreen.");

            this.toolTip1.SetToolTip(this.layerColorMathL2,
                "Add / subtract subscreen from Layer 2 of the mainscreen.");

            this.toolTip1.SetToolTip(this.layerColorMathL3,
                "Add / subtract subscreen from Layer 3 of the mainscreen.");

            this.toolTip1.SetToolTip(this.layerColorMathNPC,
                "Add / subtract subscreen from NPC layer of the \n" +
                "mainscreen.");

            this.toolTip1.SetToolTip(this.layerColorMathBG,
                "Add / subtract subscreen from background layer of the \n" +
                "mainscreen");

            this.toolTip1.SetToolTip(this.layerLockMask,
                "The screen will be unable to scroll past the edge of the \n" +
                "layer mask if it reaches it.\n\n" +
                "The layer mask sets the viewable boundaries of the level. \n" +
                "Anything beyond these boundaries will not appear in-game. \n" +
                "Click the orange box in the toolstrip to show the layer \n" +
                "mask.");

            this.toolTip1.SetToolTip(this.layerMaskHighX,
                "The location of the right edge of the layer mask.");

            this.toolTip1.SetToolTip(this.layerMaskLowX,
                "The location of the left edge of the layer mask.");

            this.toolTip1.SetToolTip(this.layerMaskHighY,
                "The location of the bottom edge of the layer mask.");

            this.toolTip1.SetToolTip(this.layerMaskLowY,
                "The location of the top edge of the layer mask.");

            this.toolTip1.SetToolTip(this.layerL2LeftShift,
                "Manually shift Layer 2 to the left by amount.This and the \n" +
                "other \"LAYER SHIFTING\" properties are rarely used and not \n" +
                "recommended.");

            this.toolTip1.SetToolTip(this.layerL2UpShift,
                "Manually shift Layer 2 upward by amount.This and the \n" +
                "other \"LAYER SHIFTING\" properties are rarely used and not \n" +
                "recommended.");

            this.toolTip1.SetToolTip(this.layerL3LeftShift,
                "Manually shift Layer 3 to the left by amount.This and the \n" +
                "other \"LAYER SHIFTING\" properties are rarely used and not \n" +
                "recommended.");

            this.toolTip1.SetToolTip(this.layerL3UpShift,
                "Manually shift Layer 3 upward by amount.This and the \n" +
                "other \"LAYER SHIFTING\" properties are rarely used and not \n" +
                "recommended.");

            this.toolTip1.SetToolTip(this.layerScrollWrapping,
                "\"SCROLL WRAPPING\" refers to the levels where the layer \n" +
                "will 'wrap' once it completes scrolling and scroll over and \n" +
                "over indefinitely.\n\n" +
                "For practical purposes, \"horizontal\" and \"vertical\" are \n" +
                "generally checked together for a layer if either one is \n" +
                "checked at all.\n\n" +
                "NOTE: The \"SCROLL WRAPPING\" property for a layer is \n" +
                "ignored if the \"Scroll Speed\" under the \"AUTOSCROLLING\" \n" +
                "properties panel for the layer is set to (none).");

            this.toolTip1.SetToolTip(this.layerL2VSync,
                "The amount of layer 2's desynchronization when Mario \n" +
                "walks up/down. This refers to the speed in which the \n" +
                "screen scrolls up/down in the opposite direction when Mario \n" +
                "walks up/down.\n\n" +
                "This rarely used. Example: in Bowser's Castle in the throne \n" +
                "room, where the Chandeliers (layer 2) have a \"Low\" \n" +
                "horizontal and vertical desync value. This means the \n" +
                "chandeliers will move left more slowly when Mario walks to \n" +
                "the right, and move right slowly when Mario walks left. The \n" +
                "same applies vertically.");

            this.toolTip1.SetToolTip(this.layerL2HSync,
                "The amount of layer 2's desynchronization when Mario \n" +
                "walks left/right. This refers to the speed in which the \n" +
                "screen scrolls left/right in the opposite direction when Mario \n" +
                "walks left/right.\n\n" +
                "This rarely used. Example: in Bowser's Castle in the throne \n" +
                "room, where the Chandeliers (layer 2) have a \"Low\" \n" +
                "horizontal and vertical desync value. This means the \n" +
                "chandeliers will move left more slowly when Mario walks to \n" +
                "the right, and move right slowly when Mario walks left. The \n" +
                "same applies vertically.");

            this.toolTip1.SetToolTip(this.layerL3VSync,
                "The amount of layer 3's desynchronization when Mario \n" +
                "walks up/down. This refers to the speed in which the \n" +
                "screen scrolls up/down in the opposite direction when Mario \n" +
                "walks up/down.");

            this.toolTip1.SetToolTip(this.layerL3HSync,
                "The amount of layer 3's desynchronization when Mario \n" +
                "walks left/right. This refers to the speed in which the \n" +
                "screen scrolls left/right in the opposite direction when Mario \n" +
                "walks left/right.");

            this.toolTip1.SetToolTip(this.layerInfiniteAutoscroll,
                "For layers that have autoscrolling enabled (ie. the \"Scroll \n" +
                "Speed\" for the layer is not set to (none)) the layer will scroll \n" +
                "indefinitely.\n\n" +
                "This property is ignored for layers that don't have \"SCROLL \n" +
                "WRAPPING\" enabled.");

            this.toolTip1.SetToolTip(this.layerL2ScrollShift,
                "This will initially shift layer 2 some pixels before starting the \n" +
                "autoscroll. No point is seen to this property, so it is \n" +
                "recommended to leave it alone.");

            this.toolTip1.SetToolTip(this.layerL3ScrollShift,
                "This will initially shift layer 3 some pixels before starting the \n" +
                "autoscroll. No point is seen to this property, so it is \n" +
                "recommended to leave it alone.");

            this.toolTip1.SetToolTip(this.layerL2ScrollDirection,
                "The direction layer 2 will scroll. This property is ignored if \n" +
                "\"L2 Scroll Speed\" is set to (none).");

            this.toolTip1.SetToolTip(this.layerL2ScrollSpeed,
                "The relative speed at which layer 2 will scroll.");

            this.toolTip1.SetToolTip(this.layerL3ScrollDirection,
                "The direction layer 3 will scroll. This property is ignored if \n" +
                "\"L3 Scroll Speed\" is set to (none).");

            this.toolTip1.SetToolTip(this.layerL3ScrollSpeed,
                "The relative speed at which layer 2 will scroll.");

            this.toolTip1.SetToolTip(this.layerWaveEffect,
                "This, if enabled will create a \"rippling water\" effect on the \n" +
                "subscreen layers.");

            this.toolTip1.SetToolTip(this.layerL3Effects,
                "The various animation effects that can be applied to layer \n" +
                "3.");

            this.toolTip1.SetToolTip(this.layerOBJEffects,
                "The various animation effects that are applied to sprites \n" +
                "and other layers.");


            // Maps
            this.toolTip1.SetToolTip(this.mapNum,
                "The map is the collection of properties that set the \n" +
                "tilemaps, palette, and tilesets for the level. Each level is \n" +
                "assigned a \"MAP #\" with all of the properties in the \"MAPS\" \n" +
                "tab.\n\n" +
                "Many levels use the same map as other levels, such as the \n" +
                "Booster Tower levels, because the area which generally \n" +
                "consitutes the viewable boundaries of the level in-game is \n" +
                "merely a portion of the entire map, where the boundaries \n" +
                "are often set by the Layer Mask edges. If the boundaries \n" +
                "are not set, then often when Mario walks to the far edge of \n" +
                "a level, another part of the level's map which constitutes a \n" +
                "different level can be seen.");

            this.toolTip1.SetToolTip(this.mapGFXSet1Num,
                "The 1st graphic set in the current map.\n\n" +
                "A graphic set is a loosely organized collection of 4bpp or \n" +
                "2bpp 8x8 tiles that are read from and organized into 16x16 \n" +
                "tiles by a tileset. They are essentially the raw graphics used \n" +
                "by a level.");
            this.toolTip1.SetToolTip(this.mapGFXSet1Name, this.toolTip1.GetToolTip(mapGFXSet1Num));

            this.toolTip1.SetToolTip(this.mapGFXSet2Num,
                "The 2nd graphic set in the current map.\n\n" +
                "A graphic set is a loosely organized collection of 4bpp or \n" +
                "2bpp 8x8 tiles that are read from and organized into 16x16 \n" +
                "tiles by a tileset. They are essentially the raw graphics used \n" +
                "by a level.");
            this.toolTip1.SetToolTip(this.mapGFXSet2Name, this.toolTip1.GetToolTip(mapGFXSet2Num));

            this.toolTip1.SetToolTip(this.mapGFXSet3Num,
                "The 3rd graphic set in the current map.\n\n" +
                "A graphic set is a loosely organized collection of 4bpp or \n" +
                "2bpp 8x8 tiles that are read from and organized into 16x16 \n" +
                "tiles by a tileset. They are essentially the raw graphics used \n" +
                "by a level.");
            this.toolTip1.SetToolTip(this.mapGFXSet3Name, this.toolTip1.GetToolTip(mapGFXSet3Num));

            this.toolTip1.SetToolTip(this.mapGFXSet4Num,
                "The 4th graphic set in the current map.\n\n" +
                "A graphic set is a loosely organized collection of 4bpp or \n" +
                "2bpp 8x8 tiles that are read from and organized into 16x16 \n" +
                "tiles by a tileset. They are essentially the raw graphics used \n" +
                "by a level.");
            this.toolTip1.SetToolTip(this.mapGFXSet4Name, this.toolTip1.GetToolTip(mapGFXSet4Num));

            this.toolTip1.SetToolTip(this.mapGFXSet5Num,
                "The 5th graphic set in the current map.\n\n" +
                "A graphic set is a loosely organized collection of 4bpp or \n" +
                "2bpp 8x8 tiles that are read from and organized into 16x16 \n" +
                "tiles by a tileset. They are essentially the raw graphics used \n" +
                "by a level.");
            this.toolTip1.SetToolTip(this.mapGFXSet5Name, this.toolTip1.GetToolTip(mapGFXSet5Num));

            this.toolTip1.SetToolTip(this.mapGFXSetL3Num,
                "The graphic set used by Layer 3 in the current map.\n\n" +
                "A graphic set is a loosely organized collection of 4bpp or \n" +
                "2bpp 8x8 tiles that are read from and organized into 16x16 \n" +
                "tiles by a tileset. They are essentially the raw graphics used \n" +
                "by a level.");
            this.toolTip1.SetToolTip(this.mapGFXSetL3Name, this.toolTip1.GetToolTip(mapGFXSetL3Num));

            this.toolTip1.SetToolTip(this.mapTilesetL1Num,
                "The tileset used by Layer 1 in the current map.\n\n" +
                "A tileset is a set of 16x16 tiles (drawn using the graphic \n" +
                "sets) which comprise what is essentially the set of tiles of \n" +
                "which the final level image is drawn. Note that tilesets do \n" +
                "not contain any raw graphics, and are merely each a series \n" +
                "of indexes in which 8x8 tiles are chosen from the graphic \n" +
                "sets in the map.");
            this.toolTip1.SetToolTip(this.mapTilesetL1Name, this.toolTip1.GetToolTip(mapTilesetL1Num));

            this.toolTip1.SetToolTip(this.mapTilesetL2Num,
                "The tileset used by Layer 2 in the current map.\n\n" +
                "A tileset is a set of 16x16 tiles (drawn using the graphic \n" +
                "sets) which comprise what is essentially the set of tiles of \n" +
                "which the final level image is drawn. Note that tilesets do \n" +
                "not contain any raw graphics, and are merely each a series \n" +
                "of indexes in which 8x8 tiles are chosen from the graphic \n" +
                "sets in the map.");
            this.toolTip1.SetToolTip(this.mapTilesetL2Name, this.toolTip1.GetToolTip(mapTilesetL2Num));

            this.toolTip1.SetToolTip(this.mapTilesetL3Num,
                "The tileset used by Layer 3 in the current map.\n\n" +
                "A tileset is a set of 16x16 tiles (drawn using the graphic \n" +
                "sets) which comprise what is essentially the set of tiles of \n" +
                "which the final level image is drawn. Note that tilesets do \n" +
                "not contain any raw graphics, and are merely each a series \n" +
                "of indexes in which 8x8 tiles are chosen from the graphic \n" +
                "sets in the map.");
            this.toolTip1.SetToolTip(this.mapTilesetL3Name, this.toolTip1.GetToolTip(mapTilesetL3Num));

            this.toolTip1.SetToolTip(this.mapSetL3Priority,
                "If enabled, the 8x8 tiles in the tilemap's Layer 3 tiles that \n" +
                "have the \"Priority 1\" property enabled in the Layer 3 tileset \n" +
                "will appear on top of all other tiles of all other layers.");

            this.toolTip1.SetToolTip(this.mapTilemapL1Num,
                "The tilemap used by Layer 1 in the current map. Layer 1 is \n" +
                "most often the \"top\" layer which usually includes things \n" +
                "such as crates, trees, bushes, pipes, etc..\n\n" +
                "A tilemap is a map of 16x16 tiles (drawn using the tilesets) \n" +
                "which comprise what is essentially the final level image (for \n" +
                "that layer only).");
            this.toolTip1.SetToolTip(this.mapTilemapL1Name, this.toolTip1.GetToolTip(mapTilemapL1Num));

            this.toolTip1.SetToolTip(this.mapTilemapL2Num,
                "The tilemap used by Layer 2 in the current map. Layer 2 is \n" +
                "most often the \"ground\" layer which usually includes the \n" +
                "entire floors, grounds, walls, etc. of a level image.\n\n" +
                "A tilemap is a map of 16x16 tiles (drawn using the tilesets) \n" +
                "which comprise what is essentially the final level image (for \n" +
                "that layer only).");
            this.toolTip1.SetToolTip(this.mapTilemapL2Name, this.toolTip1.GetToolTip(mapTilemapL2Num));

            this.toolTip1.SetToolTip(this.mapTilemapL3Num,
                "The tilemap used by Layer 3 in the current map. Layer 3 is \n" +
                "most often the \"effect\" layer which usually includes water, \n" +
                "fog effects, translucent images, clouds, etc..\n\n" +
                "A tilemap is a map of 16x16 tiles (drawn using the tilesets) \n" +
                "which comprise what is essentially the final level image (for \n" +
                "that layer only).");
            this.toolTip1.SetToolTip(this.mapTilemapL3Name, this.toolTip1.GetToolTip(mapTilemapL3Num));

            this.toolTip1.SetToolTip(this.mapPhysicalMapNum,
                "The physical map, also referred to as \"tile solidity\", is a map \n" +
                "of physical tiles in the orientation of an isometric map. An \n" +
                "isometric map is a 2D map that projects a 3D-like image, \n" +
                "which is the entire foundation for SMRPG's somewhat \n" +
                "original appearance.\n\n" +
                "The physical map can be shown (and edited) by click the \n" +
                "grey block-like button in the toolstrip at the top of this \n" +
                "editor.\n\n" +
                "Places where there are no tiles at all can be walk on.Grey \n" +
                "tiles are tiles that can also (generally) be walked on. \n" +
                "Slanted grey tiles are stairs that can be walked on.Pink tiles \n" +
                "are those tiles or portions of tiles that cannot be walked on \n" +
                "at all. White tiles are \"floating\" tiles, or tiles that hover \n" +
                "above a base tile of the same tile. Dark grey tiles are simply \n" +
                "base tiles which have a \"floating\" tile above them.Light blue \n" +
                "tiles are water tiles that can be waded through.Dark blue \n" +
                "tiles are water tiles that can be swum through.Green tiles \n" +
                "are vine tiles that can be climbed.");
            this.toolTip1.SetToolTip(this.mapPhysicalMapName, this.toolTip1.GetToolTip(mapPhysicalMapNum));

            this.toolTip1.SetToolTip(this.mapBattlefieldNum,
                "The battlefield is the background image used by any battles \n" +
                "that are encountered in the level that uses the current \n" +
                "map. A level is assigned a battlefield \"set\" or a group of \n" +
                "battlefields from which one is manually selected through an \n" +
                "event script.");
            this.toolTip1.SetToolTip(this.mapBattlefieldName, this.toolTip1.GetToolTip(mapBattlefieldNum));

            this.toolTip1.SetToolTip(this.mapPaletteSetNum,
                "The palette set is a set of 7 palettes that comprise all of the \n" +
                "colors that the level image uses. In the image below, each \n" +
                "row is a palette, thus 7 rows of palettes.");
            this.toolTip1.SetToolTip(this.mapPaletteSetName, this.toolTip1.GetToolTip(mapPaletteSetNum));

            // NPCs
            this.toolTip1.SetToolTip(this.npcObjectTree,
                "The collection of NPC's in the level. An \"NPC\" is a \"non-\n" +
                "playable character\", or generally referred to as sprites \n" +
                "although the use of the word \"sprites\" for this may be \n" +
                "misleading since some NPC's can be invisible, ie. they have \n" +
                "no sprite.\n\n" +
                "Add NPC's by clicking \"INSERT\" under \"NPC...\" or remove \n" +
                "them by selecting the NPC to remove and clicking \"DELETE\".\n\n" +
                "You will notice in this treeview the \"child nodes\" for certain \n" +
                "NPC's, which here are referred to as \"Instances\" of an \n" +
                "NPC. An NPC instance is an NPC that shares all of the same \n" +
                "properties of its parent NPC (ie. the NPC it is an instance \n" +
                "of) save for those properties in the \"INSTANCE...\" panel. \n" +
                "Each instance has its own set of properties defined in this \n" +
                "panel.\n\n" +
                "Add or remove instances by clicking \"INSERT\" or \"DELETE\" \n" +
                "under \"NPC INSTANCE...\".");

            this.npcMoveUp.ToolTipText =
                "Move an NPC or NPC instance up in the collection.";

            this.npcMoveDown.ToolTipText =
                "Move an NPC or NPC instance down in the collection.";

            this.toolTip1.SetToolTip(this.npcMapHeader,
                "The partition used by a level assigns the partitioning of the \n" +
                "sprite graphics used by an NPC. This refers to the amount \n" +
                "of space and the offset of the sprite's graphics in the VRAM \n" +
                "and all of the sprite's molds (ie. those different sprites of \n" +
                "the same sprite to make an animation).\n\n" +
                "The exact function of every property in a partition has not \n" +
                "been determined.\n\n" +
                "NOTE: if you have problems with NPC sprites displaying \n" +
                "properly in a custom level try changing this value to \n" +
                "something else. Use other existing levels for comparison \n" +
                "and find which one works the best through trial and error. \n" +
                "Notice that even though the sprites might appear fine, \n" +
                "when they playback an animation sequence there might be \n" +
                "problems.");

            this.openPartitions.ToolTipText =
                "Find a partition with specific properties.";

            this.npcInsertObject.ToolTipText =
                "Insert a new NPC after the currently selected NPC.";

            this.npcRemoveObject.ToolTipText =
                "Delete the currently selected NPC.";

            this.npcInsertInstance.ToolTipText =
                "Insert a new instance for the currently selected NPC.";

            this.toolTip1.SetToolTip(this.npcEngageType,
                "The NPC Type refers to the overall behavior and function \n" +
                "of the NPC.\n\n" +
                "\"Object\" is generally used for normal NPC's such as the \n" +
                "characters in a town that trigger dialogue.\n\n" +
                "\"Treasure\" is typically used for treasure chests.\n\n" +
                "\"Battle\" is typically used for monsters that trigger a battle.");

            this.toolTip1.SetToolTip(this.npcEngageTrigger,
                "This refers to how the event (assigned by the \"Event #\") \n" +
                "will be triggered, usually by touching the NPC so to speak.");

            this.toolTip1.SetToolTip(this.npcID,
                "The NPC assigned to the currently selected NPC.");

            this.findNPCNum.ToolTipText =
                "Since NPC's don't refer to the actual Sprite # as seen in the \n" +
                "Sprites editor, this search feature is required to find NPC's \n" +
                "that use a specific sprite #.";

            this.toolTip1.SetToolTip(this.npcEventORPack,
                "If the NPC TYPE is set to \"Object\" or \"Treasure\", this is the \n" +
                "event # that will run when the NPC has been triggered \n" +
                "(based on the \"TRIGGER\" property). \n\n" +
                "Click the green button to the left to edit the event #.\n\n" +
                "If the NPC TYPE is set to \"Battle\", this is the pack # \n" +
                "assigned to the NPC, where a formation is chosen for battle \n" +
                "when the NPC has been triggered (based on the \n" +
                "\"TRIGGER\" property). ");

            this.toolTip1.SetToolTip(this.npcMovement,
                "The action # that is initially assigned to the NPC when the \n" +
                "level is first entered. The action is the general movement \n" +
                "and behavior of the sprite, e.g. walking back / forth \n" +
                "randomly. \n\n" +
                "Click the green button to the left to edit the action #.");

            this.toolTip1.SetToolTip(this.npcSpeedPlus,
                "This will usually increase the speed of the NPC's playback.");

            this.toolTip1.SetToolTip(this.npcVisible,
                "This must be enabled for the NPC to initially appear in the \n" +
                "level.");

            this.toolTip1.SetToolTip(this.npcPropertyA,
                "If the NPC TYPE is set to \"Object\", this value is added to \n" +
                "the NPC # used by the currently selected NPC Instance. \n" +
                "The purpose of this is to allow instances to use a different \n" +
                "NPC # than their parent, but only within an index range of \n" +
                "7.\n" +
                "Example: if \"NPC #+\" is 3 and the \"NPC #\" is 15, then the \n" +
                "instance will be assigned NPC # 18.\n\n" +

                "If the NPC TYPE is set to \"Treasure\", this value is what \n" +
                "memory address $70A7 is set to for use in event scripts \n" +
                "which read $70A7 to determine what the item # or what type \n" +
                "of item (ie. mushroom, super star, flower, etc.) will be \n" +
                "given or shown for the treasure chest.\n\n" +

                "If the NPC TYPE is set to \"Battle\", this value is added to the \n" +
                "\"Action #\" used by the currently selected NPC instance. \n" +
                "The purpose of this is to allow instances to use a different \n" +
                "action # than their parent, but only within an index range \n" +
                "of 15.\n" +
                "Example: if \"Action #+\" is 3 and the \"Action #\" is 15, then \n" +
                "the instance will be assigned Action # 18.");

            this.toolTip1.SetToolTip(this.npcPropertyB,
                "If the NPC TYPE is set to \"Object\", this value is added to \n" +
                "the Event # used by the currently selected NPC Instance. \n" +
                "The purpose of this is to allow instances to use a different \n" +
                "Event # than their parent, but only within an index range \n" +
                "of 7.\n" +
                "Example: if \"Event #+\" is 3 and the \"Event #\" is 15, then \n" +
                "the instance will be assigned Event # 18.\n\n" +

                "If the NPC TYPE is set to \"Treasure\", this value refers to \n" +
                "\"Treasure\" or the type of treasure the NPC will give you if it \n" +
                "is triggered. Here is the default list of treasure types:\n" +
                "0 = mushroom\n" +
                "1 = invincible star\n" +
                "2 = flower\n" +
                "3 = frog coin\n" +
                "Other values might refer to an item # that the treasure \n" +
                "rewards, but this is usually declared by an event script.\n\n" +

                "If the NPC TYPE is set to \"Battle\", this value is added to the \n" +
                "\"Pack #\" used by the currently selected NPC instance. The \n" +
                "purpose of this is to allow instances to use a different \n" +
                "action # than their parent, but only within an index range \n" +
                "of 15.\n" +
                "Example: if \"Pack #+\" is 3 and the \"Pack #\" is 15, then the \n" +
                "instance will be assigned Pack # 18.");

            this.toolTip1.SetToolTip(this.npcPropertyC,
                "If the NPC TYPE is set to \"Object\", this value is added to \n" +
                "the \"Action #\" used by the currently selected NPC instance. \n" +
                "The purpose of this is to allow instances to use a different \n" +
                "action # than their parent, but only within an index range \n" +
                "of 3.\n" +
                "Example: if \"Action #+\" is 3 and the \"Action #\" is 15, then \n" +
                "the instance will be assigned Action # 18.");

            this.toolTip1.SetToolTip(this.npcX,
                "The isometric X coord of the NPC or NPC instance. To \n" +
                "determine the desired placement of the NPC use the values \n" +
                "displayed in the \"Isometric Coords\" label below the level \n" +
                "image.");

            this.toolTip1.SetToolTip(this.npcY,
                "The isometric Y coord of the NPC or NPC instance. To \n" +
                "determine the desired placement of the NPC use the values \n" +
                "displayed in the \"Isometric Coords\" label below the level \n" +
                "image.");

            this.toolTip1.SetToolTip(this.npcZ,
                "The isometric Z coord, or the elevation above the ground, \n" +
                "of the NPC or NPC instance.");

            this.toolTip1.SetToolTip(this.npcZ_half,
                "If enabled, the Z coord is increased by half a unit.");

            this.toolTip1.SetToolTip(this.npcFace,
                "The direction the NPC faces.");

            this.toolTip1.SetToolTip(this.npcAttributes,
                "\"Face on trigger\" will cause the NPC to face Mario when it \n" +
                "has been triggered.\n\n" +
                "\"Sequence playback\" must be enabled for any sprite \n" +
                "sequences (ie. animations) of the NPC to play.\n\n" +
                "\"No floating\" will cause the NPC to fall to the ground if its Z \n" +
                "coord is higher than the top of the floor.\n\n" +
                "\"Can't walk under\" will not let Mario or any NPC's to walk \n" +
                "under the NPC.\n\n" +
                "\"Can't pass walls\" will not let the NPC pass through walls.\n\n" +
                "\"Can't jump through\" will not let Mario or any NPC's beneath \n" +
                "it to jump through the NPC.\n\n" +
                "\"Can't pass NPCs\" will not let the NPC pass through NPCs\n\n" +
                "\"Can't walk through\" will not let Mario or any NPC's to walk \n" +
                "through the NPC.\n\n" +
                "\"Return to area (A)\" is only used for \"Battle\" type NPC's.\n\n" +
                "\"Return to area (B)\" is only used for \"Battle\" type NPC's.\n\n" +
                "\"Do not remove\" is only used for \"Battle\" type NPC's.");


            // Exits
            this.toolTip1.SetToolTip(this.exitsFieldTree,
                "The collection of exits (also referred to as entrances in \n" +
                "other game editors) in the level. An \"Exit\" is an isometric \n" +
                "field that, when walked into, will trigger a level entrance, \n" +
                "ie. the level (designated by the \"DESTINATION\" value) will \n" +
                "be entered.\n\n" +
                "Add Exits by clicking \"INSERT\" or remove them by selecting \n" +
                "the Exit to remove and clicking \"DELETE\".");

            this.exitsInsertField.ToolTipText =
                "Insert a new Exit field.";

            this.exitsDeleteField.ToolTipText =
                "Delete the currently selected Exit field.";

            this.toolTip1.SetToolTip(this.exitDest,
                "The level or overworld point (depending on the \"Exit Type\" \n" +
                "value) that will be entered when the Exit is triggered.");

            this.toolTip1.SetToolTip(this.exitsShowMessage,
                "This will cause a 1-line dialogue to show at the top of the \n" +
                "screen (ie. the message) for the new level that is entered. \n" +
                "Change the message for the entered level in the \"LAYERS\" \n" +
                "tab.");

            this.toolTip1.SetToolTip(this.exitType,
                "The exit type, or whether the exit will lead to a normal \n" +
                "\"Overworld\" level (ie. levels 0 through 1FF) or a \"World \n" +
                "Map\" point.");

            this.toolTip1.SetToolTip(this.exitX,
                "The isometric X coord of the Exit field. To determine the \n" +
                "desired placement of the Exit use the values displayed in \n" +
                "the \"Isometric Coords\" label below the level image.");

            this.toolTip1.SetToolTip(this.exitY,
                "The isometric Y coord of the Exit field. To determine the \n" +
                "desired placement of the Exit use the values displayed in \n" +
                "the \"Isometric Coords\" label below the level image.");

            this.toolTip1.SetToolTip(this.exitZ,
                "The isometric Z coord, or the elevation above the ground, \n" +
                "of the Exit field.");

            this.toolTip1.SetToolTip(this.exitLength,
                "The length (aka the width) of the field. \"LENGTH > 1\" must \n" +
                "be enabled to enter a value over 1.");

            this.toolTip1.SetToolTip(this.exitHeight,
                "The height, in single isometric units, of the Exit.");

            this.toolTip1.SetToolTip(this.exitFace,
                "The direction or orientation the Exit. UR to DL means \"up-\n" +
                "right to down-left\". DR to UL means \"down-right\" to \"up-\n" +
                "left\".");

            this.toolTip1.SetToolTip(this.exits45LengthPlusHalf,
                "This will make the Exit slightly larger on the top-left and \n" +
                "bottom-right sides.");

            this.toolTip1.SetToolTip(this.exits135LengthPlusHalf,
                "This will make the Exit slightly larger on the top-right and \n" +
                "bottom-left sides.");

            this.toolTip1.SetToolTip(this.exitDestX,
                "The isometric X coord that Mario will be initially placed at the \n" +
                "new destination level entered.");

            this.toolTip1.SetToolTip(this.exitDestY,
                "The isometric Y coord that Mario will be initially placed at the \n" +
                "new destination level entered.");

            this.toolTip1.SetToolTip(this.exitDestZ,
                "The isometric Z coord, or the elevation above the ground, \n" +
                "that Mario will be initially placed at the new destination level \n" +
                "entered.");

            this.toolTip1.SetToolTip(this.exitDestFace,
                "The direction Mario will face when the new destination level \n" +
                "is entered.");

            this.toolTip1.SetToolTip(this.marioZCoordPlusHalf,
                "Mario's Z coord at the new destination is increased by half.");


            // Events
            this.eventMusic.ToolTipText =
                "The music that initially plays when the level is first entered. \n" +
                "All levels have a music property, this property is not \n" +
                "assigned to any event fields but instead the level itself.";

            this.eventExit.ToolTipText =
                "The event # that initially runs when the level is first \n" +
                "entered. All levels have an initial event #, this property is \n" +
                "not assigned to any event fields but instead the level itself.\n\n" +
                "Click the green button to the left to edit this Event #.";

            this.toolTip1.SetToolTip(this.eventsList,
                "The collection of event fields in the level. An \"Event field\" is \n" +
                "an isometric field that, when walked into, will trigger an \n" +
                "event # (ie. run an event).\n\n" +
                "Add Event fields by clicking \"INSERT\" or remove them by \n" +
                "selecting the Event field to remove and clicking \"DELETE\".");

            this.eventsInsertField.ToolTipText =
                "Insert a new Event field.";

            this.eventsDeleteField.ToolTipText =
                "Delete the currently selected Event field.";

            this.toolTip1.SetToolTip(this.eventEvent,
                "This is the event # that will run when the event field has \n" +
                "been triggered (ie. touched).");

            this.toolTip1.SetToolTip(this.eventX,
                "The isometric X coord of the Event field. To determine the \n" +
                "desired placement of the Event field use the values \n" +
                "displayed in the \"Isometric Coords\" label below the level \n" +
                "image.");

            this.toolTip1.SetToolTip(this.eventY,
                "The isometric Y coord of the Event field. To determine the \n" +
                "desired placement of the Event field use the values \n" +
                "displayed in the \"Isometric Coords\" label below the level \n" +
                "image.");

            this.toolTip1.SetToolTip(this.eventZ,
                "The isometric Z coord, or the elevation above the ground, \n" +
                "of the Event field.");

            this.toolTip1.SetToolTip(this.eventLength,
                "The length (aka the width) of the field. \"LENGTH > 1\" must \n" +
                "be enabled to enter a value over 1.");

            this.toolTip1.SetToolTip(this.eventHeight,
                "The height, in single isometric units, of the Event field.");

            this.toolTip1.SetToolTip(this.eventFace,
                "The direction or orientation the Event field. UR to DL means \n" +
                "\"up-right to down-left\". DR to UL means \"down-right\" to \n" +
                "\"up-left\". This property is ignored if \"LENGTH > 1\" is not \n" +
                "enabled.");

            this.toolTip1.SetToolTip(this.eventsWidthXPlusHalf,
                "This will make the Event field slightly larger on the top-left \n" +
                "and bottom-right sides.");

            this.toolTip1.SetToolTip(this.eventsWidthYPlusHalf,
                "This will make the Event field slightly larger on the top-right \n" +
                "and bottom-left sides.");

            this.eventsInsertField.ToolTipText =
                "Insert a new Event field.";

            this.eventsDeleteField.ToolTipText =
                "Delete the currently selected Event field.";


            // Overlaps
            this.toolTip1.SetToolTip(this.overlapFieldTree,
                "The collection of overlaps in the level. An \"Overlap\" is an \n" +
                "object in the level that causes Mario and all NPC's that walk \n" +
                "into the overlap to be overlapped by all other layers, but \n" +
                "only by the pixels in the overlap tile. Thus, if the pixel is \n" +
                "empty (ie. transparent) that pixel won't overlap Mario or \n" +
                "the NPC.\n\n" +
                "Click \"OVERLAP TILESET\" to set the currently selected \n" +
                "overlap's tile.\n\n" +
                "Add Overlaps by clicking \"INSERT\" or remove them by \n" +
                "selecting the Overlap to remove and clicking \"DELETE\".");

            this.overlapFieldInsert.ToolTipText =
                "Insert a new Overlap.";

            this.overlapFieldDelete.ToolTipText =
                "Delete the currently selected Overlap.";

            this.toolTip1.SetToolTip(this.overlapType,
                "The tile # assigned to the overlap. Select the tile in the \n" +
                "overlap tileset (toggle it by clicking \"OVERLAP TILESET\").");

            this.toolTip1.SetToolTip(this.overlapX,
                "The isometric X coord of the Overlap. To determine the \n" +
                "desired placement of the Overlap use the values displayed \n" +
                "in the \"Isometric Coords\" label below the level image.");

            this.toolTip1.SetToolTip(this.overlapY,
                "The isometric Y coord of the Overlap. To determine the \n" +
                "desired placement of the Overlap use the values displayed \n" +
                "in the \"Isometric Coords\" label below the level image.");

            this.toolTip1.SetToolTip(this.overlapZ,
                "The isometric Z coord, or the elevation above the ground, \n" +
                "of the Overlap.");

            this.toolTip1.SetToolTip(this.overlapCoordZPlusHalf,
                "The Overlap's Z coord is increased by half a unit.");

            this.toolTip1.SetToolTip(this.overlapUnknownBits,
                "Unknown bits used by the Overlap.");


            // Physical Tiles
            //this.toolTip1.SetToolTip(this.physicalTileNum,
            //    "Select the physical tile to draw with.\n" +
            //    "Note that the physical layer must be visible to draw to it.");

            //this.toolTip1.SetToolTip(this.physicalTileSearchButton,
            //    "Search for a physical tile with specific or general properties.");


            //// Battlefields
            //this.toolTip1.SetToolTip(this.battlefieldNum,
            //    "Select the battlefield to edit by name.\n" +
            //    "A battlefield is simply a background image used in a battle. \n" +
            //    "More technically, it is a tileset and NOT a tilemap as in the \n" +
            //    "levels. It has nothing to do with the currently selected \n" +
            //    "level.");

            //this.toolTip1.SetToolTip(this.battlefieldName,
            //    "Select the battlefield to edit by #.\n" +
            //    "A battlefield is simply a background image used in a battle. \n" +
            //    "More technically, it is a tileset and NOT a tilemap as in the \n" +
            //    "levels. It has nothing to do with the currently selected \n" +
            //    "level.");

            //this.toolTip1.SetToolTip(this.battlefieldGFXSet1Num,
            //    "The 1st graphic set in the current battlefield.\n\n" +
            //    "A graphic set is a loosely organized collection of 4bpp or \n" +
            //    "2bpp 8x8 tiles that are read from and organized into 16x16 \n" +
            //    "tiles by a tileset. They are essentially the raw graphics used \n" +
            //    "by a battlefield.");
            //this.toolTip1.SetToolTip(this.battlefieldGFXSet1Name, this.toolTip1.GetToolTip(this.battlefieldGFXSet1Num));

            //this.toolTip1.SetToolTip(this.battlefieldGFXSet2Num,
            //    "The 2nd graphic set in the current battlefield.\n\n" +
            //    "A graphic set is a loosely organized collection of 4bpp or \n" +
            //    "2bpp 8x8 tiles that are read from and organized into 16x16 \n" +
            //    "tiles by a tileset. They are essentially the raw graphics used \n" +
            //    "by a battlefield.");
            //this.toolTip1.SetToolTip(this.battlefieldGFXSet2Name, this.toolTip1.GetToolTip(this.battlefieldGFXSet2Num));

            //this.toolTip1.SetToolTip(this.battlefieldGFXSet3Num,
            //    "The 3rd graphic set in the current battlefield.\n\n" +
            //    "A graphic set is a loosely organized collection of 4bpp or \n" +
            //    "2bpp 8x8 tiles that are read from and organized into 16x16 \n" +
            //    "tiles by a tileset. They are essentially the raw graphics used \n" +
            //    "by a battlefield.");
            //this.toolTip1.SetToolTip(this.battlefieldGFXSet3Name, this.toolTip1.GetToolTip(this.battlefieldGFXSet3Num));

            //this.toolTip1.SetToolTip(this.battlefieldGFXSet4Num,
            //    "The 4th graphic set in the current battlefield.\n\n" +
            //    "A graphic set is a loosely organized collection of 4bpp or \n" +
            //    "2bpp 8x8 tiles that are read from and organized into 16x16 \n" +
            //    "tiles by a tileset. They are essentially the raw graphics used \n" +
            //    "by a battlefield.");
            //this.toolTip1.SetToolTip(this.battlefieldGFXSet4Name, this.toolTip1.GetToolTip(this.battlefieldGFXSet4Num));

            //this.toolTip1.SetToolTip(this.battlefieldGFXSet5Num,
            //    "The 5th graphic set in the current battlefield.\n\n" +
            //    "A graphic set is a loosely organized collection of 4bpp or \n" +
            //    "2bpp 8x8 tiles that are read from and organized into 16x16 \n" +
            //    "tiles by a tileset. They are essentially the raw graphics used \n" +
            //    "by a battlefield.");
            //this.toolTip1.SetToolTip(this.battlefieldGFXSet5Name, this.toolTip1.GetToolTip(this.battlefieldGFXSet5Num));

            //this.toolTip1.SetToolTip(this.battlefieldTilesetNum,
            //    "The tileset used by the current battlefield.\n\n" +
            //    "A tileset is a set of 16x16 tiles (drawn using the graphic \n" +
            //    "sets) which comprise what is essentially the map of tiles of \n" +
            //    "which the final battlefield image is drawn. Note that tilesets \n" +
            //    "do not contain any raw graphics, and are merely each a \n" +
            //    "series of indexes in which 8x8 tiles are arranged.");
            //this.toolTip1.SetToolTip(this.battlefieldTilesetName, this.toolTip1.GetToolTip(this.battlefieldTilesetNum));

            //this.toolTip1.SetToolTip(this.battlefieldPaletteSetNum,
            //    "The palette set is a set of 7 palettes that comprise all of the \n" +
            //    "colors that the battlefield image uses. In the image below, \n" +
            //    "each row is a palette, thus 7 rows of palettes.");
            //this.toolTip1.SetToolTip(this.battlefieldPaletteSetName, this.toolTip1.GetToolTip(this.battlefieldPaletteSetNum));
        }
        public void RefreshLevel()
        {
            Cursor.Current = Cursors.WaitCursor;
            updatingLevel = true; // Start
            try
            {
                if (levelCheck.Index == index && !fullUpdate)
                {
                    tileSet.RedrawTilesets(); // Redraw all tilesets
                    tileMap.RedrawTileMap();
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
            if (tileMap != null)
                tileMap.AssembleIntoModel();
            tileSet = new TileSet(levelMap, paletteSet);
            tileMap = new TileMap(level, tileSet);
            foreach (Level l in levels)
            {
                l.LevelTileMods.ClearTilemaps();
                l.LevelSolidMods.ClearTilemaps();
            }
            foreach (LevelTileMods.Mod mod in tileMods.Mods)
            {
                mod.TilemapA = new TileMap(level, tileSet, mod, false);
                if (mod.Set)
                    mod.TilemapB = new TileMap(level, tileSet, mod, true);
            }
            foreach (LevelSolidMods.Mod mod in solidMods.Mods)
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
            tileMap.AssembleIntoModel(); // Assemble the edited tileMap into the model

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
            tileMap.AssembleIntoModel();
            Model.Compress(Model.TileMaps, Model.EditTileMaps, 0x160000, 0x1A8000, "TILE MAP",
                0, 109, 163, 219, 275);
            Model.Compress(Model.SolidityMaps, Model.EditSolidityMaps, 0x1B0000, 0x1C8000, "SOLIDITY MAP",
                0, 80);
            Model.Compress(Model.TileSets, Model.EditTileSets, 0x3B0000, 0x3DC000, "TILE SET",
                0, 58, 91);

            Model.HexViewer.Compare();

            checksum = Do.GenerateChecksum(levels, levelMaps, Model.GraphicSets, Model.TileSets,
                Model.TileMaps, Model.SolidityMaps, Model.PaletteSets, Model.NPCProperties);
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
        }
        private void importArchitectureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (new IOArchitecture("import", index, levelMap, paletteSet, tileSet, tileMap, prioritySets[layer.PrioritySet]).ShowDialog() == DialogResult.Cancel)
                return;
            fullUpdate = false;
            RefreshLevel();
            return;
        }
        private void exportArchitectureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new IOArchitecture("export", index, levelMap, paletteSet, tileSet, tileMap, prioritySets[layer.PrioritySet]).ShowDialog();
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
            if (new ClearElements(null, (int)(levelMap.TileSetL1 + 0x20), "CLEAR TILESETS...").ShowDialog() == DialogResult.Cancel)
                return;
            new ClearElements(null, (int)(levelMap.TileSetL2 + 0x20), "CLEAR TILESETS...").buttonOK_Click(null, null);
            if (levelMap.GraphicSetL3 != 0xFF)
                new ClearElements(null, (int)(levelMap.TileSetL3), "CLEAR TILESETS...").buttonOK_Click(null, null);
            fullUpdate = true;
            if (!updatingLevel)
                RefreshLevel();
        }
        private void clearTilemapsAll_Click(object sender, EventArgs e)
        {
            if (new ClearElements(null, (int)(levelMap.TileMapL1 + 0x40), "CLEAR TILEMAPS...").ShowDialog() == DialogResult.Cancel)
                return;
            new ClearElements(null, (int)(levelMap.TileMapL2 + 0x40), "CLEAR TILEMAPS...").buttonOK_Click(null, null);
            if (levelMap.GraphicSetL3 != 0xFF)
                new ClearElements(null, (int)(levelMap.TileMapL3), "CLEAR TILEMAPS...").buttonOK_Click(null, null);
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
            for (int i = 0; i < Model.TileSets.Length; i++)
            {
                if (i < 0x20)
                    Model.TileSets[i] = new byte[0x1000];
                else
                    Model.TileSets[i] = new byte[0x2000];
                Model.EditTileSets[i] = true;
            }
            for (int i = 0; i < Model.TileMaps.Length; i++)
            {
                if (i < 0x40)
                    Model.TileMaps[i] = new byte[0x1000];
                else
                    Model.TileMaps[i] = new byte[0x2000];
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

            Model.TileSets[levelMap.TileSetL1 + 0x20] = new byte[0x2000];
            Model.TileSets[levelMap.TileSetL2 + 0x20] = new byte[0x2000];
            Model.TileSets[levelMap.TileSetL3] = new byte[0x1000];
            Model.EditTileSets[levelMap.TileSetL1 + 0x20] = true;
            Model.EditTileSets[levelMap.TileSetL2 + 0x20] = true;
            Model.EditTileSets[levelMap.TileSetL3] = true;

            Model.TileMaps[levelMap.TileMapL1 + 0x40] = new byte[0x2000];
            Model.TileMaps[levelMap.TileMapL2 + 0x40] = new byte[0x2000];
            Model.TileMaps[levelMap.TileMapL3] = new byte[0x1000];
            Model.EditTileMaps[levelMap.TileMapL1 + 0x40] = true;
            Model.EditTileMaps[levelMap.TileMapL2 + 0x40] = true;
            Model.EditTileMaps[levelMap.TileMapL3] = true;

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

            for (int i = 0; i < Model.TileSets.Length; i++)
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
            bool[] used = new bool[Model.TileSets.Length];
            LevelMap lm;
            foreach (Level lv in levels)
            {
                lm = levelMaps[lv.LevelMap];
                used[lm.TileSetL1 + 0x20] = true;
                used[lm.TileSetL2 + 0x20] = true;
                used[lm.TileSetL3] = true;
            }

            for (int i = 0; i < Model.TileSets.Length; i++)
            {
                if (!used[i])
                {
                    Model.TileSets[i] = new byte[i < 0x20 ? 0x1000 : 0x2000];
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
            bool[] used = new bool[Model.TileMaps.Length];
            LevelMap lm;
            foreach (Level lv in levels)
            {
                lm = levelMaps[lv.LevelMap];
                used[lm.TileMapL1 + 0x40] = true;
                used[lm.TileMapL2 + 0x40] = true;
                used[lm.TileMapL3] = true;
            }

            for (int i = 0; i < Model.TileMaps.Length; i++)
            {
                if (!used[i])
                {
                    Model.TileMaps[i] = new byte[i < 0x40 ? 0x1000 : 0x2000];
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
            for (int i = 0; i < Model.TileMaps.Length; i++)
            {
                CreateDir(fullPath + "Tile Maps\\");
                fs = new FileStream(fullPath + "Tile Maps\\tileMap." + i.ToString("d3") + ".bin", FileMode.Create, FileAccess.ReadWrite);
                bw = new BinaryWriter(fs);
                bw.Write(Model.TileMaps[i], 0, Model.TileMaps[i].Length);
                bw.Close();
                fs.Close();
            }
            for (int i = 0; i < Model.TileSets.Length; i++)
            {
                CreateDir(fullPath + "Tile Sets\\");
                fs = new FileStream(fullPath + "Tile Sets\\tileSet." + i.ToString("d3") + ".bin", FileMode.Create, FileAccess.ReadWrite);
                bw = new BinaryWriter(fs);
                bw.Write(Model.TileSets[i], 0, Model.TileSets[i].Length);
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
                for (int i = 0; i < Model.TileMaps.Length; i++)
                {
                    if (!File.Exists(fullPath + "Tile Maps\\tileMap." + i.ToString("d3") + ".bin"))
                        continue;
                    fs = File.OpenRead(fullPath + "Tile Maps\\tileMap." + i.ToString("d3") + ".bin");
                    br = new BinaryReader(fs);
                    Model.TileMaps[i] = br.ReadBytes(Model.TileMaps[i].Length);
                    br.Close();
                    fs.Close();

                    Model.EditTileMaps[i] = true;
                }
                for (int i = 0; i < Model.TileSets.Length; i++)
                {
                    if (!File.Exists(fullPath + "Tile Sets\\tileSet." + i.ToString("d3") + ".bin"))
                        continue;
                    fs = File.OpenRead(fullPath + "Tile Sets\\tileSet." + i.ToString("d3") + ".bin");
                    br = new BinaryReader(fs);
                    Model.TileSets[i] = br.ReadBytes(Model.TileSets[i].Length);
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
            NPC.Instance tins;
            int offset;
            int cnt;
            string temp;

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

                    for (int k = 0; k < tnpc.Instances.Count; k++)
                    {
                        tins = (NPC.Instance)tnpc.Instances[k];
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
                mod.TilemapA = new TileMap(level, tileSet, mod, false);
                if (mod.Set)
                    mod.TilemapB = new TileMap(level, tileSet, mod, true);
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
            foreach (LevelSolidMods.Mod mod in solidMods.Mods)
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
            Model.Decompress(Model.TileSets, 0x3B0000, 0x3E0000, 0x1000, "", levelMap.TileSetL1 + 0x20, levelMap.TileSetL1 + 0x21, false);
            Model.Decompress(Model.TileSets, 0x3B0000, 0x3E0000, 0x1000, "", levelMap.TileSetL2 + 0x20, levelMap.TileSetL2 + 0x21, false);
            Model.Decompress(Model.TileSets, 0x3B0000, 0x3E0000, 0x1000, "", levelMap.TileSetL3, levelMap.TileSetL2 + 1, false);
            fullUpdate = true;
            if (!updatingLevel)
                RefreshLevel();
        }
        private void resetTilemapsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("You're about to undo all changes to the current tilemaps. Go ahead with reset?",
                "LAZY SHELL", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;
            Model.Decompress(Model.TileMaps, 0x160000, 0x1B0000, 0x1000, 0x2000, "", 0x40, levelMap.TileMapL1 + 0x40, levelMap.TileMapL1 + 0x41, false);
            Model.Decompress(Model.TileMaps, 0x160000, 0x1B0000, 0x1000, 0x2000, "", 0x40, levelMap.TileMapL2 + 0x40, levelMap.TileMapL2 + 0x41, false);
            Model.Decompress(Model.TileMaps, 0x160000, 0x1B0000, 0x1000, 0x2000, "", 0x40, levelMap.TileMapL3, levelMap.TileMapL3 + 1, false);
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
            Model.Decompress(Model.TileSets, 0x3B0000, 0x3E0000, 0x1000, "", levelMap.TileSetL1 + 0x20, levelMap.TileSetL1 + 0x21, false);
            Model.Decompress(Model.TileSets, 0x3B0000, 0x3E0000, 0x1000, "", levelMap.TileSetL2 + 0x20, levelMap.TileSetL2 + 0x21, false);
            Model.Decompress(Model.TileSets, 0x3B0000, 0x3E0000, 0x1000, "", levelMap.TileSetL3, levelMap.TileSetL2 + 1, false);
            Model.Decompress(Model.TileMaps, 0x160000, 0x1B0000, 0x1000, 0x2000, "", 0x40, levelMap.TileMapL1 + 0x40, levelMap.TileMapL1 + 0x41, false);
            Model.Decompress(Model.TileMaps, 0x160000, 0x1B0000, 0x1000, 0x2000, "", 0x40, levelMap.TileMapL2 + 0x40, levelMap.TileMapL2 + 0x41, false);
            Model.Decompress(Model.TileMaps, 0x160000, 0x1B0000, 0x1000, 0x2000, "", 0x40, levelMap.TileMapL3, levelMap.TileMapL3 + 1, false);
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
            toolStripButton1.Visible = changeLevelName.Checked;
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
                toolStripButton1.Visible = false;
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
            if (Do.GenerateChecksum(levels, levelMaps, Model.GraphicSets, Model.TileSets,
                Model.TileMaps, Model.SolidityMaps, Model.PaletteSets, Model.NPCProperties) == checksum)
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
                Model.TileMaps[0] = null;
                Model.TileSets[0] = null;
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
            searchWindow.Dispose();
            levelsTileset.TileEditor.Dispose();
            levelsSolidTiles.SearchSolidTile.Dispose();
            paletteEditor.Dispose();
            graphicEditor.Dispose();
            if (lp != null)
                lp.Close();
            if (sa != null)
                sa.Close();
            if (sp != null)
                sp.Close();
            settings.Save();
        }
        private void Levels_FormClosed(object sender, FormClosedEventArgs e)
        {
            GC.Collect();
        }

        #endregion
    }
}
