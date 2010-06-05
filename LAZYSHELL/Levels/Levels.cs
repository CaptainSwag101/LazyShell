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

        private Model model; public Model Model { get { return this.model; } }
        private LevelModel levelModel;
        //private Notes notes;
        private State state;
        private Settings settings;
        private CommandStack commandStack;
        private UniversalVariables universal;

        private int currentLevel;
        private Level[] levels; public Level[] ThisLevels { get { return this.levels; } } // Array of levels
        public ComboBox LevelName { get { return levelName; } set { levelName = value; } }
        public NumericUpDown LevelNum { get { return levelNum; } set { levelNum = value; } }

        private ProgressBar pBar;

        private int[] levelPixels;
        private Bitmap levelImage, priority1Tint;
        private Bitmap templateImage;

        private Level levelCheck; // Used to verify a level change
        private Overlay overlay; // Object used to generate all the overlays for levels

        private bool updatingLevel = false; // Indicates that we are currently updating the level so we dont update during an update
        private bool fullUpdate = false; // Indicates that we need to do a complete update instead of a fast update
        private bool updatingProperties = false; // indicated whether to update or save properties

        private bool isOverSomething = false;
        private bool waitBothCoords = false;
        private bool waitForChange = false;
        private bool mouseMoveStart = false;

        private Point overTile;
        private Point overPhysTile;
        private bool mouseEnter;
        private Size moveDiff;

        private Bitmap moveImage;
        private bool insideSelection;
        private int zoom = 1;

        // dragging panels
        private bool panelTilesetsMax;
        private bool panelBattlefieldTilesetMax;
        private bool movingPanelBattlefieldTileset;
        private bool resizingPanelBattlefieldTileset;
        private bool SizeRight, SizeBottom, SizeBottomRight;
        private Point mousePos = new Point();
        private Point oldMousePosition = new Point();

        private bool replaceChoose;
        private bool replaceSet;
        private int replaceTile;
        private int replaceWith;

        private ArrayList templates = new ArrayList();
        private LevelTemplate template;
        private LevelTemplate templateC;

        // for the separate physical tile search window
        public NumericUpDown PhysicalTileNum { get { return physicalTileNum; } set { physicalTileNum = value; } }
        public NumericUpDown NPCMapHeader { get { return npcMapHeader; } set { npcMapHeader = value; } }
        public NumericUpDown NPCID { get { return npcID; } set { npcID = value; } }

        private ClearElements clearElements;
        private ImportExportElements ioElements;
        private string fullPath; public string FullPath { set { fullPath = value; } }

        #endregion

        public Levels(Model model)
        {
            this.model = model;
            this.state = State.Instance;
            this.settings = Settings.Default;
            this.overlay = new Overlay();
            this.commandStack = new CommandStack(settings.UndoStackSize);
            this.universal = state.Universal;

            settings.Keystrokes[0x20] = "\x20";

            model.CreateLevelModel();
            levelModel = model.LevelModel;

            DecompressLevelData();

            DrawPhysicalTiles();

            InitializeComponent();

            foreach (Control c in this.Controls)
            {
                c.MouseMove += new MouseEventHandler(controlMouseMove);
                SetEventHandlers(c);
            }
            SetToolTips();

            this.levelName.Items.AddRange(universal.LevelNames);

            if (model.SpriteModel == null)
                model.CreateSpritesModel();
            this.universal.Dialogues = model.SpriteModel.Dialogues;
            this.layerMessageBox.Items.Add("{NONE}");
            for (int i = 0; i < 128; i++)
                this.layerMessageBox.Items.Add(universal.Dialogues[i].GetDialogueStub(true));

            this.mapGFXSet1Name.Items.AddRange(graphicSetNames);
            this.mapGFXSet2Name.Items.AddRange(graphicSetNames);
            this.mapGFXSet3Name.Items.AddRange(graphicSetNames);
            this.mapGFXSet4Name.Items.AddRange(graphicSetNames);
            this.mapGFXSet5Name.Items.AddRange(graphicSetNames);
            this.battlefieldGFXSet1Name.Items.AddRange(graphicSetNames); battlefieldGFXSet1Name.Items.Add("{NONE}");
            this.battlefieldGFXSet2Name.Items.AddRange(graphicSetNames); battlefieldGFXSet2Name.Items.Add("{NONE}");
            this.battlefieldGFXSet3Name.Items.AddRange(graphicSetNames); battlefieldGFXSet3Name.Items.Add("{NONE}");
            this.battlefieldGFXSet4Name.Items.AddRange(graphicSetNames); battlefieldGFXSet4Name.Items.Add("{NONE}");
            this.battlefieldGFXSet5Name.Items.AddRange(graphicSetNames); battlefieldGFXSet5Name.Items.Add("{NONE}");
            this.mapTilesetL1Name.Items.AddRange(tileSetNames);
            this.mapTilesetL2Name.Items.AddRange(tileSetNames);
            this.mapTilemapL1Name.Items.AddRange(tileMapNames);
            this.mapTilemapL2Name.Items.AddRange(tileMapNames);

            levels = levelModel.Levels;
            levelMaps = levelModel.LevelMaps;
            paletteSets = levelModel.PaletteSets;
            prioritySets = levelModel.PrioritySets;
            battlefields = levelModel.Battlefields;
            physicalTiles = levelModel.PhysicalTiles;
            npcSpritePartitions = levelModel.NPCSpritePartitions;
            npcProperties = levelModel.NPCProperties;

            rightEdge = panelTileEditor.Right;

            if (!updatingLevel)
                UpdateLevel();

            updatingLevel = true;

            InitializeSettings(); // Sets initial control settings

            updatingLevel = false;
        }

        #region Methods

        private void InitializeSettings()
        {
            this.levelName.SelectedIndex = 0;

            buttonToggleProperties.Checked = true;

            buttonToggleCartGrid.Checked = state.CartesianGrid;
            buttonToggleOrthGrid.Checked = state.OrthographicGrid;
            buttonToggleBG.Checked = state.BG;
            buttonToggleMask.Checked = state.Mask;
            buttonToggleL1.Checked = state.Layer1;
            buttonToggleL2.Checked = state.Layer2;
            buttonToggleL3.Checked = state.Layer3;
            buttonToggleP1.Checked = state.Priority1;
            buttonTogglePhys.Checked = state.PhysicalLayer;
            buttonToggleNPCs.Checked = state.Objects;
            buttonToggleExits.Checked = state.Exits;
            buttonToggleEvents.Checked = state.Events;
            buttonToggleOverlaps.Checked = state.Overlaps;

            buttonEditDraw.Checked = state.Draw;
            buttonEditSelect.Checked = state.Select;
            buttonEditErase.Checked = state.Erase;
            buttonEditDropper.Checked = state.Dropper;

            overlay.PhysTilePoint = new Point(1024, 1024);

            cartesianGridToolStripMenuItem.Checked = state.CartesianGrid;
            orthographicGridToolStripMenuItem.Checked = state.OrthographicGrid;
            backgroundToolStripMenuItem.Checked = state.BG;
            maskToolStripMenuItem.Checked = state.Mask;
            layer1ToolStripMenuItem.Checked = state.Layer1;
            layer2ToolStripMenuItem.Checked = state.Layer2;
            layer3ToolStripMenuItem.Checked = state.Layer3;
            physicalMapToolStripMenuItem.Checked = state.PhysicalLayer;
            npcsToolStripMenuItem.Checked = state.Objects;
            exitFieldsToolStripMenuItem.Checked = state.Exits;
            eventFieldsToolStripMenuItem.Checked = state.Events;

            InitializeLayerProperties();
            InitializeMapProperties();
            InitializeNPCProperties();
            InitializeExitFieldProperties();
            InitializeEventFieldProperties();
            InitializeOverlapProperties();
            RefreshBattlefield();
            InitializeTileEditor();

            commandStack.Clear();

            coleditSelectCommand.SelectedIndex = 0;
            colEditReds.Checked = true;
            colEditGreens.Checked = true;
            colEditBlues.Checked = true;

            overlapTileset = new OverlapTileset(model);
        }

        private void SetEventHandlers(Control control)
        {
            foreach (Control c in control.Controls)
            {
                c.MouseMove += new MouseEventHandler(controlMouseMove);
                SetEventHandlers(c);
            }
        }
        private void SetToolTips()
        {
            toolTip1.SetToolTip(colorBalance,
                "Color math effects are designed to easily alter the color\n" +
                "scheme of the entire level by modifying color values and / or\n" +
                "switching them en masse or individually.\n");
            toolTip1.SetToolTip(paletteUpdate,
                "Update the level image after modifying the palette.");
            toolTip1.SetToolTip(overlapShowTileset,
                "Show / hide the overlap tileset.");
            toolTip1.SetToolTip(pictureBoxOverlaps,
                "Select the overlap tile to set to the current overlap.");

            // Levels

            this.toolTip1.SetToolTip(this.levelName,
                "Select the level to edit by name. The name is based on a \n" +
                "label assigned by either the default or user-defined label. \n" +
                "Edit the level's name/label by clicking on \"LABEL\".");

            this.toolTip1.SetToolTip(this.levelNum,
                "Select the level to edit by #. The number is in hexadecimal.");

            this.toolTip1.SetToolTip(this.changeLevelName,
                "Edit the level's name/label.");

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

            this.toolTip1.SetToolTip(this.pictureBoxPalette,
                "Click a color to edit it's color values below.");

            this.toolTip1.SetToolTip(this.mapPaletteRedNum,
                "The amount of red in the currently selected color.");
            this.toolTip1.SetToolTip(this.mapPaletteRedBar, this.toolTip1.GetToolTip(mapPaletteRedNum));

            this.toolTip1.SetToolTip(this.mapPaletteGreenNum,
                "The amount of green in the currently selected color.");
            this.toolTip1.SetToolTip(this.mapPaletteGreenBar, this.toolTip1.GetToolTip(mapPaletteGreenNum));

            this.toolTip1.SetToolTip(this.mapPaletteBlueNum,
                "The amount of blue in the currently selected color.");
            this.toolTip1.SetToolTip(this.mapPaletteBlueBar, this.toolTip1.GetToolTip(mapPaletteBlueNum));


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

            this.toolTip1.SetToolTip(this.npcMoveUp,
                "Move an NPC or NPC instance up in the collection.");

            this.toolTip1.SetToolTip(this.npcMoveDown,
                "Move an NPC or NPC instance down in the collection.");

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

            this.toolTip1.SetToolTip(this.openPartitions,
                "Find a partition with specific properties.");

            this.toolTip1.SetToolTip(this.npcInsertObject,
                "Insert a new NPC after the currently selected NPC.");

            this.toolTip1.SetToolTip(this.npcRemoveObject,
                "Delete the currently selected NPC.");

            this.toolTip1.SetToolTip(this.npcInsertInstance,
                "Insert a new instance for the currently selected NPC.");

            this.toolTip1.SetToolTip(this.npcRemoveInstance,
                "Delete the currently selected NPC instance.");

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

            this.toolTip1.SetToolTip(this.findNPCNum,
                "Since NPC's don't refer to the actual Sprite # as seen in the \n" +
                "Sprites editor, this search feature is required to find NPC's \n" +
                "that use a specific sprite #.");

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

            this.toolTip1.SetToolTip(this.npcsShowNPC,
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
                "memory address 00:70A7 is set to for use in event scripts \n" +
                "which read 00:70A7 to determine what the item # or what type \n" +
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

            this.toolTip1.SetToolTip(this.npcXCoord,
                "The isometric X coord of the NPC or NPC instance. To \n" +
                "determine the desired placement of the NPC use the values \n" +
                "displayed in the \"Isometric Coords\" label below the level \n" +
                "image.");

            this.toolTip1.SetToolTip(this.npcYCoord,
                "The isometric Y coord of the NPC or NPC instance. To \n" +
                "determine the desired placement of the NPC use the values \n" +
                "displayed in the \"Isometric Coords\" label below the level \n" +
                "image.");

            this.toolTip1.SetToolTip(this.npcZCoord,
                "The isometric Z coord, or the elevation above the ground, \n" +
                "of the NPC or NPC instance.");

            this.toolTip1.SetToolTip(this.npcsZCoordPlusHalf,
                "If enabled, the Z coord is increased by half a unit.");

            this.toolTip1.SetToolTip(this.npcRadialPosition,
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

            this.toolTip1.SetToolTip(this.exitsInsertField,
                "Insert a new Exit field.");

            this.toolTip1.SetToolTip(this.exitsDeleteField,
                "Delete the currently selected Exit field.");

            this.toolTip1.SetToolTip(this.exitsLengthOverOne,
                "This must be enabled for the \"Length\" to be greater than 1.");

            this.toolTip1.SetToolTip(this.exitsDestination,
                "The level or overworld point (depending on the \"Exit Type\" \n" +
                "value) that will be entered when the Exit is triggered.");

            this.toolTip1.SetToolTip(this.exitsShowMessage,
                "This will cause a 1-line dialogue to show at the top of the \n" +
                "screen (ie. the message) for the new level that is entered. \n" +
                "Change the message for the entered level in the \"LAYERS\" \n" +
                "tab.");

            this.toolTip1.SetToolTip(this.exitsType,
                "The exit type, or whether the exit will lead to a normal \n" +
                "\"Overworld\" level (ie. levels 0 through 1FF) or a \"World \n" +
                "Map\" point.");

            this.toolTip1.SetToolTip(this.exitsFieldXCoord,
                "The isometric X coord of the Exit field. To determine the \n" +
                "desired placement of the Exit use the values displayed in \n" +
                "the \"Isometric Coords\" label below the level image.");

            this.toolTip1.SetToolTip(this.exitsFieldYCoord,
                "The isometric Y coord of the Exit field. To determine the \n" +
                "desired placement of the Exit use the values displayed in \n" +
                "the \"Isometric Coords\" label below the level image.");

            this.toolTip1.SetToolTip(this.exitsFieldZCoord,
                "The isometric Z coord, or the elevation above the ground, \n" +
                "of the Exit field.");

            this.toolTip1.SetToolTip(this.exitsFieldLength,
                "The length (aka the width) of the field. \"LENGTH > 1\" must \n" +
                "be enabled to enter a value over 1.");

            this.toolTip1.SetToolTip(this.exitsFieldHeight,
                "The height, in single isometric units, of the Exit.");

            this.toolTip1.SetToolTip(this.exitsFieldRadialPosition,
                "The direction or orientation the Exit. UR to DL means \"up-\n" +
                "right to down-left\". DR to UL means \"down-right\" to \"up-\n" +
                "left\".");

            this.toolTip1.SetToolTip(this.exits45LengthPlusHalf,
                "This will make the Exit slightly larger on the top-left and \n" +
                "bottom-right sides.");

            this.toolTip1.SetToolTip(this.exits135LengthPlusHalf,
                "This will make the Exit slightly larger on the top-right and \n" +
                "bottom-left sides.");

            this.toolTip1.SetToolTip(this.exitsMarioXCoord,
                "The isometric X coord that Mario will be initially placed at the \n" +
                "new destination level entered.");

            this.toolTip1.SetToolTip(this.exitsMarioYCoord,
                "The isometric Y coord that Mario will be initially placed at the \n" +
                "new destination level entered.");

            this.toolTip1.SetToolTip(this.exitsMarioZCoord,
                "The isometric Z coord, or the elevation above the ground, \n" +
                "that Mario will be initially placed at the new destination level \n" +
                "entered.");

            this.toolTip1.SetToolTip(this.exitsMarioRadialPosition,
                "The direction Mario will face when the new destination level \n" +
                "is entered.");

            this.toolTip1.SetToolTip(this.marioZCoordPlusHalf,
                "Mario's Z coord at the new destination is increased by half.");


            // Events
            this.toolTip1.SetToolTip(this.eventsAreaMusic,
                "The music that initially plays when the level is first entered. \n" +
                "All levels have a music property, this property is not \n" +
                "assigned to any event fields but instead the level itself.");

            this.toolTip1.SetToolTip(this.eventsExitEvent,
                "The event # that initially runs when the level is first \n" +
                "entered. All levels have an initial event #, this property is \n" +
                "not assigned to any event fields but instead the level itself.\n\n" +
                "Click the green button to the left to edit this Event #.");

            this.toolTip1.SetToolTip(this.eventsFieldTree,
                "The collection of event fields in the level. An \"Event field\" is \n" +
                "an isometric field that, when walked into, will trigger an \n" +
                "event # (ie. run an event).\n\n" +
                "Add Event fields by clicking \"INSERT\" or remove them by \n" +
                "selecting the Event field to remove and clicking \"DELETE\".");

            this.toolTip1.SetToolTip(this.eventsInsertField,
                "Insert a new Event field.");

            this.toolTip1.SetToolTip(this.eventsDeleteField,
                "Delete the currently selected Event field.");

            this.toolTip1.SetToolTip(this.eventsLengthOverOne,
                "This must be enabled for the \"Length\" to be greater than 1.");

            this.toolTip1.SetToolTip(this.eventsRunEvent,
                "This is the event # that will run when the event field has \n" +
                "been triggered (ie. touched).");

            this.toolTip1.SetToolTip(this.eventsFieldXCoord,
                "The isometric X coord of the Event field. To determine the \n" +
                "desired placement of the Event field use the values \n" +
                "displayed in the \"Isometric Coords\" label below the level \n" +
                "image.");

            this.toolTip1.SetToolTip(this.eventsFieldYCoord,
                "The isometric Y coord of the Event field. To determine the \n" +
                "desired placement of the Event field use the values \n" +
                "displayed in the \"Isometric Coords\" label below the level \n" +
                "image.");

            this.toolTip1.SetToolTip(this.eventsFieldZCoord,
                "The isometric Z coord, or the elevation above the ground, \n" +
                "of the Event field.");

            this.toolTip1.SetToolTip(this.eventsFieldLength,
                "The length (aka the width) of the field. \"LENGTH > 1\" must \n" +
                "be enabled to enter a value over 1.");

            this.toolTip1.SetToolTip(this.eventsFieldHeight,
                "The height, in single isometric units, of the Event field.");

            this.toolTip1.SetToolTip(this.eventsFieldRadialPosition,
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

            this.toolTip1.SetToolTip(this.eventsInsertField,
                "Insert a new Event field.");

            this.toolTip1.SetToolTip(this.eventsDeleteField,
                "Delete the currently selected Event field.");


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

            this.toolTip1.SetToolTip(this.overlapFieldInsert,
                "Insert a new Overlap.");

            this.toolTip1.SetToolTip(this.overlapFieldDelete,
                "Delete the currently selected Overlap.");

            this.toolTip1.SetToolTip(this.overlapType,
                "The tile # assigned to the overlap. Select the tile in the \n" +
                "overlap tileset (toggle it by clicking \"OVERLAP TILESET\").");

            this.toolTip1.SetToolTip(this.overlapCoordX,
                "The isometric X coord of the Overlap. To determine the \n" +
                "desired placement of the Overlap use the values displayed \n" +
                "in the \"Isometric Coords\" label below the level image.");

            this.toolTip1.SetToolTip(this.overlapCoordY,
                "The isometric Y coord of the Overlap. To determine the \n" +
                "desired placement of the Overlap use the values displayed \n" +
                "in the \"Isometric Coords\" label below the level image.");

            this.toolTip1.SetToolTip(this.overlapCoordZ,
                "The isometric Z coord, or the elevation above the ground, \n" +
                "of the Overlap.");

            this.toolTip1.SetToolTip(this.overlapCoordZPlusHalf,
                "The Overlap's Z coord is increased by half a unit.");

            this.toolTip1.SetToolTip(this.overlapUnknownBits,
                "Unknown bits used by the Overlap.");


            // Physical Tiles
            this.toolTip1.SetToolTip(this.physicalTileNum,
                "Select the physical tile to draw with.\n" +
                "Note that the physical layer must be visible to draw to it.");

            this.toolTip1.SetToolTip(this.physicalTileSearchButton,
                "Search for a physical tile with specific or general properties.");


            // Battlefields
            this.toolTip1.SetToolTip(this.battlefieldNum,
                "Select the battlefield to edit by name.\n" +
                "A battlefield is simply a background image used in a battle. \n" +
                "More technically, it is a tileset and NOT a tilemap as in the \n" +
                "levels. It has nothing to do with the currently selected \n" +
                "level.");

            this.toolTip1.SetToolTip(this.battlefieldName,
                "Select the battlefield to edit by #.\n" +
                "A battlefield is simply a background image used in a battle. \n" +
                "More technically, it is a tileset and NOT a tilemap as in the \n" +
                "levels. It has nothing to do with the currently selected \n" +
                "level.");

            this.toolTip1.SetToolTip(this.battlefieldGFXSet1Num,
                "The 1st graphic set in the current battlefield.\n\n" +
                "A graphic set is a loosely organized collection of 4bpp or \n" +
                "2bpp 8x8 tiles that are read from and organized into 16x16 \n" +
                "tiles by a tileset. They are essentially the raw graphics used \n" +
                "by a battlefield.");
            this.toolTip1.SetToolTip(this.battlefieldGFXSet1Name, this.toolTip1.GetToolTip(this.battlefieldGFXSet1Num));

            this.toolTip1.SetToolTip(this.battlefieldGFXSet2Num,
                "The 2nd graphic set in the current battlefield.\n\n" +
                "A graphic set is a loosely organized collection of 4bpp or \n" +
                "2bpp 8x8 tiles that are read from and organized into 16x16 \n" +
                "tiles by a tileset. They are essentially the raw graphics used \n" +
                "by a battlefield.");
            this.toolTip1.SetToolTip(this.battlefieldGFXSet2Name, this.toolTip1.GetToolTip(this.battlefieldGFXSet2Num));

            this.toolTip1.SetToolTip(this.battlefieldGFXSet3Num,
                "The 3rd graphic set in the current battlefield.\n\n" +
                "A graphic set is a loosely organized collection of 4bpp or \n" +
                "2bpp 8x8 tiles that are read from and organized into 16x16 \n" +
                "tiles by a tileset. They are essentially the raw graphics used \n" +
                "by a battlefield.");
            this.toolTip1.SetToolTip(this.battlefieldGFXSet3Name, this.toolTip1.GetToolTip(this.battlefieldGFXSet3Num));

            this.toolTip1.SetToolTip(this.battlefieldGFXSet4Num,
                "The 4th graphic set in the current battlefield.\n\n" +
                "A graphic set is a loosely organized collection of 4bpp or \n" +
                "2bpp 8x8 tiles that are read from and organized into 16x16 \n" +
                "tiles by a tileset. They are essentially the raw graphics used \n" +
                "by a battlefield.");
            this.toolTip1.SetToolTip(this.battlefieldGFXSet4Name, this.toolTip1.GetToolTip(this.battlefieldGFXSet4Num));

            this.toolTip1.SetToolTip(this.battlefieldGFXSet5Num,
                "The 5th graphic set in the current battlefield.\n\n" +
                "A graphic set is a loosely organized collection of 4bpp or \n" +
                "2bpp 8x8 tiles that are read from and organized into 16x16 \n" +
                "tiles by a tileset. They are essentially the raw graphics used \n" +
                "by a battlefield.");
            this.toolTip1.SetToolTip(this.battlefieldGFXSet5Name, this.toolTip1.GetToolTip(this.battlefieldGFXSet5Num));

            this.toolTip1.SetToolTip(this.battlefieldTilesetNum,
                "The tileset used by the current battlefield.\n\n" +
                "A tileset is a set of 16x16 tiles (drawn using the graphic \n" +
                "sets) which comprise what is essentially the map of tiles of \n" +
                "which the final battlefield image is drawn. Note that tilesets \n" +
                "do not contain any raw graphics, and are merely each a \n" +
                "series of indexes in which 8x8 tiles are arranged.");
            this.toolTip1.SetToolTip(this.battlefieldTilesetName, this.toolTip1.GetToolTip(this.battlefieldTilesetNum));

            this.toolTip1.SetToolTip(this.battlefieldPaletteSetNum,
                "The palette set is a set of 7 palettes that comprise all of the \n" +
                "colors that the battlefield image uses. In the image below, \n" +
                "each row is a palette, thus 7 rows of palettes.");
            this.toolTip1.SetToolTip(this.battlefieldPaletteSetName, this.toolTip1.GetToolTip(this.battlefieldPaletteSetNum));

            this.toolTip1.SetToolTip(this.bfPalettePictureBox,
                "Click a color to edit it's color values below.");

            this.toolTip1.SetToolTip(this.bfPaletteRedNum,
                "The amount of red in the currently selected color.");
            this.toolTip1.SetToolTip(this.bfPaletteRedBar, this.toolTip1.GetToolTip(this.bfPaletteRedNum));

            this.toolTip1.SetToolTip(this.bfPaletteGreenNum,
                "The amount of green in the currently selected color.");
            this.toolTip1.SetToolTip(this.bfPaletteGreenBar, this.toolTip1.GetToolTip(this.bfPaletteGreenNum));

            this.toolTip1.SetToolTip(this.bfPaletteBlueNum,
                "The amount of blue in the currently selected color.");
            this.toolTip1.SetToolTip(this.bfPaletteBlueBar, this.toolTip1.GetToolTip(this.bfPaletteBlueNum));
        }
        private void controlMouseMove(object sender, MouseEventArgs e)
        {
            if (sender == this) return;

            Control control = (Control)sender;

            if (enableHelpTipsToolStripMenuItem.Checked)
            {
                if (toolTip1.GetToolTip(control) != "")
                {
                    Control parent = (Control)control.Parent;
                    Point p = control.Location;
                    Point l = new Point();
                    while (parent.Parent != this)
                    {
                        p.X += parent.Location.X;
                        p.Y += parent.Location.Y;
                        parent = parent.Parent;
                    }

                    labelToolTip.Text = toolTip1.GetToolTip(control);
                    l = new Point(p.X + e.X + 50, p.Y + e.Y + 50);
                    if (l.X + labelToolTip.Width + 50 > this.Width)
                        l.X -= labelToolTip.Width + 75;
                    if (l.Y + labelToolTip.Height + 50 > this.Height)
                        l.Y -= labelToolTip.Height + 50;
                    labelToolTip.Location = l;
                    labelToolTip.BringToFront();
                    labelToolTip.Visible = true;
                }
                else
                    labelToolTip.Visible = false;
            }
            else
                labelToolTip.Visible = false;

            if (showDecHexToolStripMenuItem.Checked)
            {
                if (control.GetType().Name == "UpDownEdit" || control.GetType().Name == "NumericUpDown")
                {
                    Control parent = (Control)control.Parent;
                    Point p = control.Location;
                    Point l = new Point();
                    while (parent.Parent != this)
                    {
                        p.X += parent.Location.X;
                        p.Y += parent.Location.Y;
                        parent = parent.Parent;
                    }

                    NumericUpDown numericUpDown;
                    if (control.GetType().Name == "UpDownEdit")
                    {
                        Control temp = GetNextControl(control, false);
                        numericUpDown = (NumericUpDown)GetNextControl(temp, false);
                    }
                    else
                        numericUpDown = (NumericUpDown)control;

                    if (numericUpDown.Hexadecimal)
                        labelConvertor.Text = "DEC:  " + ((int)numericUpDown.Value).ToString("d");
                    else
                        labelConvertor.Text = "HEX:  0x" + ((int)numericUpDown.Value).ToString("X4");

                    l = new Point(p.X + e.X + 50, p.Y + e.Y + 50);
                    if (l.X + labelConvertor.Width + 50 > this.Width)
                        l.X -= labelConvertor.Width + 75;
                    if (l.Y + labelConvertor.Height + 50 > this.Height)
                        l.Y -= labelConvertor.Height + 50;
                    labelConvertor.Location = l;
                    labelConvertor.BringToFront();
                    labelConvertor.Visible = true;
                }
                else
                    labelConvertor.Visible = false;
            }
            else
                labelConvertor.Visible = false;
        }

        private void CreateNewLevelData()
        {
            levelCheck = levels[currentLevel];

            levelMap = levelMaps[levels[currentLevel].LevelMap];
            paletteSet = paletteSets[levelMaps[levels[currentLevel].LevelMap].PaletteSet];

            tileSet = new Tileset(levelMap, paletteSet, model);
            layer = levels[currentLevel].Layer;
            npcs = levels[currentLevel].LevelNPCs;
            exits = levels[currentLevel].LevelExits;
            events = levels[currentLevel].LevelEvents;
            overlaps = levels[currentLevel].LevelOverlaps;
            tileMap = new TileMap(levelMap, paletteSet, tileSet, layer, prioritySets, model);
            physicalMap = new PhysicalMap(levelMap,
                    model,
                    quadBasePixels,
                    quadBlockPixels,
                    halfQuadBlockPixels,
                    stairsUpLeftLowPixels,
                    stairsUpLeftHighPixels,
                    stairsUpRightLowPixels,
                    stairsUpRightHighPixels);
            physicalMap.SetOrthographic();

            fullUpdate = false;
        }
        private void GetCurrentLevelData()
        {
            try
            {
                if (levelCheck.LevelNum == currentLevel && !fullUpdate)
                {
                    tileSet.RedrawTilesets(tabControl2.SelectedIndex); // Redraw all tilesets
                    tileMap.RedrawTileMap();
                    InitializeTileEditor();
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
                    InitializeTileEditor();
                }
            }
            catch (Exception ex)
            {
                CreateNewLevelData();
            }
        }
        private void LevelChange()
        {
            state.Layer1 = buttonToggleL1.Checked = layer1ToolStripMenuItem.Checked = true;
            state.Layer2 = buttonToggleL2.Checked = layer2ToolStripMenuItem.Checked = true;
            state.Layer3 = buttonToggleL3.Checked = layer3ToolStripMenuItem.Checked = true;
            state.BG = buttonToggleBG.Checked = backgroundToolStripMenuItem.Checked = true;

            // Code that must happen before a level changes goes here
            tileMap.AssembleIntoModel(); // Assemble the edited tileMap into the model

            ResetOverlay();
            UpdateLevel();

            if (tabControl2.SelectedIndex == 2 && levelMap.GraphicSetL3 == 0xFF)
                tabControl2.SelectedIndex = 0;

            overEventField = 0;
            overExitField = 0;
            overNPC = 0;
            isOverSomething = false;

            GC.Collect();
        }
        public void UpdateLevel()
        {
            //ClearCopyBuffers();
            clearSelectionToolStripMenuItem_Click(null, null);

            updatingLevel = true; // Start

            currentLevel = (int)levelNum.Value; // Get level number

            GetCurrentLevelData(); // Get the new data if required

            levelPixels = tileMap.Mainscreen;
            levelImage = new Bitmap(Drawing.PixelArrayToImage(levelPixels, 1024, 1024));

            priority1Tint = null;

            // Get the pixel arrays
            if (tabControl2.SelectedIndex < 3)
            {
                try
                {
                    tileSetPixels = tileSet.GetTilesetPixelArray(tileSet.TileSetLayers[tabControl2.SelectedIndex], tabControl2.SelectedIndex);
                    tileSetImage = new Bitmap(Drawing.PixelArrayToImage(tileSetPixels, 256, 512));
                }
                catch (Exception ex)
                {
                    /*no layer 3*/
                    tileSetImage = null;
                }
            }

            paletteSetPixels = paletteSet.GetPaletteSetPixels();
            paletteSetImage = null;
            paletteSetImage = new Bitmap(Drawing.PixelArrayToImage(paletteSetPixels, 240, 105));

            // Set the images
            SetLevelImages();

            updatingLevel = false; // Done

            pictureBoxLevel.Invalidate();

            // templates
            if (template != null)
            {
                templateImage = new Bitmap(Drawing.PixelArrayToImage(template.GetTemplatePixels(
                    this.levelMap, this.paletteSet, this.tileSet, this.layer, this.prioritySets),
                    template.Size.Width, template.Size.Height));
                pictureBoxTemplate.Invalidate();
            }
        }
        private void ResetOverlay()
        {
            overlay.ExitsImage = null;
            overlay.EventsImage = null;
            overlay.NPCsImage = null;
            overlay.OverlapsImage = null;
        }

        // set images
        private void SetLevelImages()
        {
            // If were viewing the tilesets
            switch (tabControl2.SelectedIndex)
            {
                case 0: pictureBoxTilesetL1.Invalidate(); break;
                case 1: pictureBoxTilesetL2.Invalidate(); break;
                case 2: pictureBoxTilesetL3.Invalidate(); break;
                case 4:
                    pictureBoxBattlefield.Invalidate();
                    pictureBoxBattlefield.BackColor = Color.FromArgb(paletteSetBF.GetBGColorBF());
                    break;
                default:
                    break;
            }

            if (Priorities.SelectedIndex == 1)
                palettePictureBox.Invalidate();
        }
        public void DrawLevelWithoutUpdate()
        {
            if (!state.PhysicalLayer && overlay.DragStop.X == overlay.DragStart.X && overlay.DragStart.Y == overlay.DragStop.Y)
                pictureBoxLevel.Invalidate();
            else if (state.PhysicalLayer && overlay.PhysTilePoint.X == 1024 && overlay.PhysTilePoint.Y == 1024)
                pictureBoxLevel.Invalidate();

            levelPixels = tileMap.Mainscreen;
            levelImage = new Bitmap(Drawing.PixelArrayToImage(levelPixels, 1024, 1024));
            priority1Tint = null;

            overlay.ClearSelection = false;

            pictureBoxLevel.Invalidate();
        }

        private void UpdateCoordLabels(Point p)
        {
            int x = Math.Min(Math.Max(p.X / zoom, 0), 1023);
            int y = Math.Min(Math.Max(p.Y / zoom, 0), 1023);

            if (state.PhysicalLayer)
                waitForChange = overPhysicalTile == physicalMap.OrthTileNum[y * 1024 + x];
            else
                waitForChange = overTile == new Point((x / 16) * 16, (y / 16) * 16);

            int tileNum = tileMap.GetTileNum(tabControl2.SelectedIndex, overTile.X, overTile.Y);
            overTile = new Point((x / 16) * 16, (y / 16) * 16);

            this.labelPixelCoords.Text = "(" + x + ", " + y + ")  Pixel Coords";
            mouse.X = x;
            mouse.Y = y;
            this.labelTileCoords.Text = "(" + (x / 16) + ", " + (y / 16) + ")  Tile Coords";

            if (x >= 0 && x < 1024 && y >= 0 && y < 1024)
            {
                overPhysicalTile = physicalMap.OrthTileNum[y * 1024 + x];
                orthCoordX = physicalMap.OrthCoordsX[y * 1024 + x];
                orthCoordY = physicalMap.OrthCoordsY[y * 1024 + x];

                overPhysTile = new Point(orthCoordX, orthCoordY);

                string physTileNumString = System.Convert.ToString(overPhysicalTile);
                string orthCoordXString = System.Convert.ToString(orthCoordX);
                string orthCoordYString = System.Convert.ToString(orthCoordY);

                this.labelOrthCoords.Text = "(" + orthCoordXString + ", " + orthCoordYString + ")  Isometric Coords";
            }
        }

        private void LoadSearch()
        {
            listBoxLevelNames.BeginUpdate();
            listBoxLevelNames.Items.Clear();

            for (int i = 0; i < levelName.Items.Count; i++)
            {
                if (Contains(levelName.Items[i].ToString(), nameTextBox.Text, StringComparison.CurrentCultureIgnoreCase))
                    listBoxLevelNames.Items.Add(levelName.Items[i]);
            }
            listBoxLevelNames.EndUpdate();
        }

        public static bool Contains(string original, string value, StringComparison comparisionType)
        {
            return original.IndexOf(value, comparisionType) >= 0;
        }

        public void CreateNewCommandStack()
        {
            this.commandStack = new CommandStack(settings.UndoStackSize);
        }

        private void PreviewLevel()
        {
            Previewer.Previewer lp = new LAZYSHELL.Previewer.Previewer(model, (int)this.levelNum.Value, 1);
            lp.Show();
        }
        public string OpenDialogFile(string title)
        {
            string filename;

            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = settings.LastRomPath;
            openFileDialog1.Title = "Select the " + title + " to Import";
            openFileDialog1.Filter = "Binary files (*.bin)|*.bin|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() != DialogResult.Cancel)
                filename = openFileDialog1.FileName;
            else
                filename = null;

            return filename;
        }
        private string SelectFile(string title, string filter)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = settings.LastRomPath;
            openFileDialog1.Title = title;
            openFileDialog1.Filter = filter;
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() != DialogResult.Cancel)
                return openFileDialog1.FileName;
            return null;
        }

        // assemblers
        public void Assemble()
        {
            LevelChange();

            if (!model.AssembleLevels)
                return;
            if (model.AssembleFinal)
                model.AssembleLevels = false;

            settings.Save();

            foreach (Level l in levels)
            {
                l.Assemble();
            }
            foreach (PrioritySet ps in prioritySets)
            {
                ps.Assemble();
            }
            foreach (LevelMap lm in levelMaps)
            {
                lm.Assemble();
            }
            foreach (PaletteSet ps in paletteSets)
            {
                ps.Assemble();
            }
            foreach (Battlefield bf in battlefields)
            {
                bf.Assemble();
            }
            foreach (NPCProperties np in npcProperties)
            {
                np.Assemble();
            }

            int temp = 0, temp2 = 0;

            ushort offsetStart = 0x3166;
            if (exits.NumberOfExits > 0)
                exits.CurrentExit = temp;
            if (!CalculateFreeExitSpace(false))
            {
                for (int i = 0; i < 512; i++)
                {
                    offsetStart = levels[i].LevelExits.Assemble(offsetStart);
                }
            }
            else
                MessageBox.Show("Exit fields were not saved because they exceed the maximum alotted space.", "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            if (exits.NumberOfExits > 0)
                exits.CurrentExit = temp;

            offsetStart = 0xE400;
            if (events.NumberOfEvents > 0)
                temp = events.CurrentEvent;
            if (!CalculateFreeEventSpace(false))
            {
                for (int i = 0; i < 512; i++)
                {
                    offsetStart = levels[i].LevelEvents.Assemble(offsetStart);
                }
            }
            else
                MessageBox.Show("Event fields were not saved because they exceed the maximum alotted space.", "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            if (events.NumberOfEvents > 0)
                events.CurrentEvent = temp;

            offsetStart = 0x8400;
            if (npcs.NumberOfNPCs > 0)
            {
                temp = npcs.CurrentNPC;
                if (npcs.NumberOfInstances > 0)
                    temp2 = npcs.CurrentInstance;
            }
            if (!CalculateFreeNPCSpace(4, false))
            {
                for (int i = 0; i < 512; i++)
                {
                    offsetStart = levels[i].LevelNPCs.Assemble(offsetStart);
                }
            }
            else
                MessageBox.Show("NPCs were not saved because they exceed the maximum alotted space.", "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            if (npcs.NumberOfNPCs > 0)
            {
                npcs.CurrentNPC = temp;
                if (npcs.NumberOfInstances > 0)
                    npcs.CurrentInstance = temp2;
            }

            offsetStart = 0x4D05;
            if (overlaps.NumberOfOverlaps > 0)
                temp = overlaps.CurrentOverlap;
            if (!CalculateFreeOverlapSpace(false))
            {
                for (int i = 0; i < 512; i++)
                {
                    offsetStart = levels[i].LevelOverlaps.Assemble(offsetStart);
                }
            }
            else
                MessageBox.Show("Overlaps were not saved because they exceed the maximum alotted space.", "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            if (overlaps.NumberOfOverlaps > 0)
                overlaps.CurrentOverlap = temp;

            // ASSEMBLE THE TILEMAPS
            RecompressLevelData();
        }

        #endregion

        #region Event Handlers

        private void levelNum_ValueChanged(object sender, EventArgs e)
        {
            levelNum.Enabled = false;
            levelName.Enabled = false;
            if (levelName.SelectedIndex == (int)levelNum.Value)
            {
                if (!updatingLevel)
                {
                    LevelChange();
                }
            }
            else
                levelName.SelectedIndex = (int)levelNum.Value;
            levelNum.Enabled = true;
            levelName.Enabled = true;
        }
        private void levelName_SelectedIndexChanged(object sender, EventArgs e)
        {
            levelNum.Enabled = false;
            levelName.Enabled = false;
            if (levelName.SelectedIndex == (int)levelNum.Value)
            {
                if (!updatingLevel)
                {
                    LevelChange();
                }
            }
            else
                levelNum.Value = levelName.SelectedIndex;
            levelNum.Enabled = true;
            levelName.Enabled = true;
        }
        private void addThisLevelToNotesDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (model.Program.Notes == null || !model.Program.Notes.Visible)
                model.Program.CreateNotesWindow();
            Notes temp = model.Program.Notes;
            if (temp.ThisNotes == null)
                temp.LoadNotes();
            if (temp.ThisNotes != null)
            {
                temp.AddingFromEditor(1, currentLevel, settings.LevelNames[currentLevel], settings.LevelNames[currentLevel]);
                temp.BringToFront();
            }
            else
            {
                MessageBox.Show("Could not add element to notes database.", "LAZY SHELL",
                    MessageBoxButtons.OK);
            }
        }

        // toolstrip menu items : File
        private void saveLevels_Click(object sender, EventArgs e)
        {
            Assemble();
        }
        private void exitLevels_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private void helpTopics_Click(object sender, EventArgs e)
        {

        }
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form about = new About(this);
            about.ShowDialog(this);
        }

        private void importLevelDataAll_Click(object sender, EventArgs e)
        {
            ioElements = new ImportExportElements(this, (int)levelNum.Value, "IMPORT LEVEL DATA...");
            ioElements.ShowDialog();
            if (clearElements.DialogResult == DialogResult.Cancel)
                return;
            fullUpdate = true;
            if (!updatingLevel)
                UpdateLevel();

            if (CalculateFreeNPCSpace(4, false))
                MessageBox.Show("The total number of NPCs for all levels has exceeded the maximum allotted space.", "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (CalculateFreeExitSpace(false))
                MessageBox.Show("The total number of exit fields for all levels has exceeded the maximum allotted space.", "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (CalculateFreeEventSpace(false))
                MessageBox.Show("The total number of event fields for all levels has exceeded the maximum allotted space.", "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (CalculateFreeOverlapSpace(false))
                MessageBox.Show("The total number of overlaps for all levels has exceeded the maximum allotted space.", "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void exportLevelDataAll_Click(object sender, EventArgs e)
        {
            ioElements = new ImportExportElements(this, (int)levelNum.Value, "EXPORT LEVEL DATA...");
            ioElements.ShowDialog();
        }
        private void exportLevelImagesAll_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

            folderBrowserDialog.SelectedPath = settings.LastDirectory;
            folderBrowserDialog.Description = "Select directory to save level images to...";

            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result != DialogResult.OK) return;

            settings.LastDirectory = folderBrowserDialog.SelectedPath;
            fullPath = folderBrowserDialog.SelectedPath;

            pBar = new ProgressBar(
                this.model, this.model.Data,
                "SAVING LEVEL IMAGES...", 509, ExportLevelImages);
            pBar.Show();
            this.Enabled = false;

            ExportLevelImages.RunWorkerAsync();
        }
        private void exportLevelImagesCurrent_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PNG files (*.png)|*.png|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.FileName = "level." + currentLevel.ToString("d3") + ".png";
            saveFileDialog.RestoreDirectory = true;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
                levelImage.Save(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Png);
        }
        private void clearLevelDataAll_Click(object sender, EventArgs e)
        {
            clearElements = new ClearElements(model, (int)levelNum.Value, "CLEAR LEVEL DATA...");
            clearElements.ShowDialog();
            if (clearElements.DialogResult == DialogResult.Cancel)
                return;
            fullUpdate = true;
            if (!updatingLevel)
                UpdateLevel();
        }
        private void clearTilesetsAll_Click(object sender, EventArgs e)
        {
            clearElements = new ClearElements(model, (int)mapTilesetL1Num.Value, "CLEAR TILESETS...");
            clearElements.ShowDialog();
            if (clearElements.DialogResult == DialogResult.Cancel)
                return;
            fullUpdate = true;
            if (!updatingLevel)
                UpdateLevel();
        }
        private void clearTilemapsAll_Click(object sender, EventArgs e)
        {
            clearElements = new ClearElements(model, (int)mapTilemapL1Num.Value, "CLEAR TILEMAPS...");
            clearElements.ShowDialog();
            if (clearElements.DialogResult == DialogResult.Cancel)
                return;
            fullUpdate = true;
            if (!updatingLevel)
                UpdateLevel();
        }
        private void clearPhysicalMapsAll_Click(object sender, EventArgs e)
        {
            clearElements = new ClearElements(model, (int)mapPhysicalMapNum.Value, "CLEAR PHYSICAL MAPS...");
            clearElements.ShowDialog();
            if (clearElements.DialogResult == DialogResult.Cancel)
                return;
            fullUpdate = true;
            physicalMap.DrawPhysicalMap();
            pictureBoxLevel.Invalidate();
        }
        private void clearBattlefieldsAll_Click(object sender, EventArgs e)
        {
            clearElements = new ClearElements(model, (int)battlefieldNum.Value, "CLEAR BATTLEFIELD TILESETS...");
            clearElements.ShowDialog();
            if (clearElements.DialogResult == DialogResult.Cancel)
                return;
            RefreshBattlefield();
            pictureBoxBattlefield.Invalidate();
            pictureBoxBattlefield.BackColor = Color.FromArgb(paletteSetBF.GetBGColorBF());
            bfPalettePictureBox.Invalidate();
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
            for (int i = 0; i < model.TileSets.Length; i++)
            {
                if (i < 0x20)
                    model.TileSets[i] = new byte[0x1000];
                else
                    model.TileSets[i] = new byte[0x2000];
                model.EditTileSets[i] = true;
            }
            for (int i = 0; i <= model.TileMaps.Length; i++)
            {
                if (i < 0x40)
                    model.TileMaps[i] = new byte[0x1000];
                else
                    model.TileMaps[i] = new byte[0x2000];
                model.EditTileMaps[i] = true;
            }
            for (int i = 0; i < model.PhysicalMaps.Length; i++)
            {
                model.PhysicalMaps[i] = new byte[0x20C2];
                model.EditPhysicalMaps[i] = true;
            }
            for (int i = 0; i < model.TileSetsBF.Length; i++)
            {
                model.TileSetsBF[i] = new byte[0x2000];
                model.EditTileSetsBF[i] = true;
            }

            fullUpdate = true;
            if (!updatingLevel)
                UpdateLevel();
            physicalMap.DrawPhysicalMap();
            pictureBoxLevel.Invalidate();
        }
        private void clearAllComponentsCurrent_Click(object sender, EventArgs e)
        {
            levels[currentLevel].Layer.Clear();
            levels[currentLevel].LevelEvents.Clear();
            levels[currentLevel].LevelExits.Clear();
            levels[currentLevel].LevelNPCs.Clear();
            levels[currentLevel].LevelOverlaps.Clear();

            model.TileSets[levelMap.TileSetL1 + 0x20] = new byte[0x2000];
            model.TileSets[levelMap.TileSetL2 + 0x20] = new byte[0x2000];
            model.TileSets[levelMap.TileSetL3] = new byte[0x1000];
            model.EditTileSets[levelMap.TileSetL1 + 0x20] = true;
            model.EditTileSets[levelMap.TileSetL2 + 0x20] = true;
            model.EditTileSets[levelMap.TileSetL3] = true;

            model.TileMaps[levelMap.TileMapL1 + 0x40] = new byte[0x2000];
            model.TileMaps[levelMap.TileMapL2 + 0x40] = new byte[0x2000];
            model.TileMaps[levelMap.TileMapL3] = new byte[0x1000];
            model.EditTileMaps[levelMap.TileMapL1 + 0x40] = true;
            model.EditTileMaps[levelMap.TileMapL2 + 0x40] = true;
            model.EditTileMaps[levelMap.TileMapL3] = true;

            physicalMap.Clear(1);

            model.TileSetsBF[battlefields[(int)battlefieldNum.Value].TileSet] = new byte[0x2000];
            model.EditTileSetsBF[battlefields[(int)battlefieldNum.Value].TileSet] = true;

            fullUpdate = true;
            if (!updatingLevel)
                UpdateLevel();
            physicalMap.DrawPhysicalMap();
            pictureBoxLevel.Invalidate();
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
            bool[] used = new bool[model.TileSets.Length];
            LevelMap lm;
            foreach (Level lv in levels)
            {
                lm = levelMaps[lv.LevelMap];
                used[lm.TileSetL1 + 0x20] = true;
                used[lm.TileSetL2 + 0x20] = true;
                used[lm.TileSetL3] = true;
            }

            for (int i = 0; i < model.TileSets.Length; i++)
            {
                if (!used[i])
                {
                    model.TileSets[i] = new byte[i < 0x20 ? 0x1000 : 0x2000];
                    model.EditTileSets[i] = true;
                }
            }

            fullUpdate = true;
            if (!updatingLevel)
                UpdateLevel();
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
            bool[] used = new bool[model.TileMaps.Length];
            LevelMap lm;
            foreach (Level lv in levels)
            {
                lm = levelMaps[lv.LevelMap];
                used[lm.TileMapL1 + 0x40] = true;
                used[lm.TileMapL2 + 0x40] = true;
                used[lm.TileMapL3] = true;
            }

            for (int i = 0; i < model.TileMaps.Length; i++)
            {
                if (!used[i])
                {
                    model.TileMaps[i] = new byte[i < 0x40 ? 0x1000 : 0x2000];
                    model.EditTileMaps[i] = true;
                }
            }

            fullUpdate = true;
            if (!updatingLevel)
                UpdateLevel();
        }
        private void unusedToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
              "You are about to clear all UNUSED physical maps.\n\n" +
              "Do you wish to continue?",
              "LAZY SHELL", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.No)
                return;

            // Clear unused physical maps
            bool[] used = new bool[model.PhysicalMaps.Length];
            LevelMap lm;
            foreach (Level lv in levels)
            {
                lm = levelMaps[lv.LevelMap];
                used[lm.PhysicalMap] = true;
            }

            for (int i = 0; i < model.PhysicalMaps.Length; i++)
            {
                if (!used[i])
                {
                    model.PhysicalMaps[i] = new byte[0x20C2];
                    model.EditPhysicalMaps[i] = true;
                }
            }

            fullUpdate = true;
            if (!updatingLevel)
                UpdateLevel();
        }
        private void unusedToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            // Clear all unused components
            unusedToolStripMenuItem_Click(null, null);
            unusedToolStripMenuItem1_Click(null, null);
            unusedToolStripMenuItem2_Click(null, null);
        }
        private void arraysToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fullPath = GetDirectoryPath("Select directory to export arrays to...");
            fullPath += "\\" + model.GetFileNameWithoutPath() + " - Arrays\\";

            // Create Level Data directory
            if (!CreateDir(fullPath)) return;

            FileStream fs;
            BinaryWriter bw;
            //try
            //{
            // Create the file to store the level data
            for (int i = 0; i < model.GraphicSets.Length; i++)
            {
                CreateDir(fullPath + "Graphic Sets\\");
                fs = new FileStream(fullPath + "Graphic Sets\\graphicSet." + i.ToString("d3") + ".bin", FileMode.Create, FileAccess.ReadWrite);
                bw = new BinaryWriter(fs);
                bw.Write(model.GraphicSets[i], 0, model.GraphicSets[i].Length);
                bw.Close();
                fs.Close();
            }
            for (int i = 0; i < model.PhysicalMaps.Length; i++)
            {
                CreateDir(fullPath + "Physical Maps\\");
                fs = new FileStream(fullPath + "Physical Maps\\physicalMap." + i.ToString("d3") + ".bin", FileMode.Create, FileAccess.ReadWrite);
                bw = new BinaryWriter(fs);
                bw.Write(model.PhysicalMaps[i], 0, model.PhysicalMaps[i].Length);
                bw.Close();
                fs.Close();
            }
            for (int i = 0; i < model.TileMaps.Length; i++)
            {
                CreateDir(fullPath + "Tile Maps\\");
                fs = new FileStream(fullPath + "Tile Maps\\tileMap." + i.ToString("d3") + ".bin", FileMode.Create, FileAccess.ReadWrite);
                bw = new BinaryWriter(fs);
                bw.Write(model.TileMaps[i], 0, model.TileMaps[i].Length);
                bw.Close();
                fs.Close();
            }
            for (int i = 0; i < model.TileSets.Length; i++)
            {
                CreateDir(fullPath + "Tile Sets\\");
                fs = new FileStream(fullPath + "Tile Sets\\tileSet." + i.ToString("d3") + ".bin", FileMode.Create, FileAccess.ReadWrite);
                bw = new BinaryWriter(fs);
                bw.Write(model.TileSets[i], 0, model.TileSets[i].Length);
                bw.Close();
                fs.Close();
            }
            for (int i = 0; i < model.TileSetsBF.Length; i++)
            {
                CreateDir(fullPath + "Battlefield Tile Sets\\");
                fs = new FileStream(fullPath + "Battlefield Tile Sets\\tileSetBF." + i.ToString("d3") + ".bin", FileMode.Create, FileAccess.ReadWrite);
                bw = new BinaryWriter(fs);
                bw.Write(model.TileSetsBF[i], 0, model.TileSetsBF[i].Length);
                bw.Close();
                fs.Close();
            }
            //}
            //catch (Exception ex)
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
                for (int i = 0; i < model.GraphicSets.Length; i++)
                {
                    if (!File.Exists(fullPath + "Graphic Sets\\graphicSet." + i.ToString("d3") + ".bin"))
                        continue;
                    fs = File.OpenRead(fullPath + "Graphic Sets\\graphicSet." + i.ToString("d3") + ".bin");
                    br = new BinaryReader(fs);
                    model.GraphicSets[i] = br.ReadBytes(model.GraphicSets[i].Length);
                    br.Close();
                    fs.Close();

                    model.EditGraphicSets[i] = true;
                }
                for (int i = 0; i < model.PhysicalMaps.Length; i++)
                {
                    if (!File.Exists(fullPath + "Physical Maps\\physicalMap." + i.ToString("d3") + ".bin"))
                        continue;
                    fs = File.OpenRead(fullPath + "Physical Maps\\physicalMap." + i.ToString("d3") + ".bin");
                    br = new BinaryReader(fs);
                    model.PhysicalMaps[i] = br.ReadBytes(model.PhysicalMaps[i].Length);
                    br.Close();
                    fs.Close();

                    model.EditPhysicalMaps[i] = true;
                }
                for (int i = 0; i < model.TileMaps.Length; i++)
                {
                    if (!File.Exists(fullPath + "Tile Maps\\tileMap." + i.ToString("d3") + ".bin"))
                        continue;
                    fs = File.OpenRead(fullPath + "Tile Maps\\tileMap." + i.ToString("d3") + ".bin");
                    br = new BinaryReader(fs);
                    model.TileMaps[i] = br.ReadBytes(model.TileMaps[i].Length);
                    br.Close();
                    fs.Close();

                    model.EditTileMaps[i] = true;
                }
                for (int i = 0; i < model.TileSets.Length; i++)
                {
                    if (!File.Exists(fullPath + "Tile Sets\\tileSet." + i.ToString("d3") + ".bin"))
                        continue;
                    fs = File.OpenRead(fullPath + "Tile Sets\\tileSet." + i.ToString("d3") + ".bin");
                    br = new BinaryReader(fs);
                    model.TileSets[i] = br.ReadBytes(model.TileSets[i].Length);
                    br.Close();
                    fs.Close();

                    model.EditTileSets[i] = true;
                }
                for (int i = 0; i < model.TileSetsBF.Length; i++)
                {
                    if (!File.Exists(fullPath + "Battlefield Tile Sets\\tileSetBF." + i.ToString("d3") + ".bin"))
                        continue;
                    fs = File.OpenRead(fullPath + "Battlefield Tile Sets\\tileSetBF." + i.ToString("d3") + ".bin");
                    br = new BinaryReader(fs);
                    model.TileSetsBF[i] = br.ReadBytes(model.TileSetsBF[i].Length);
                    br.Close();
                    fs.Close();

                    model.EditTileSetsBF[i] = true;
                }

                fullUpdate = true;
                UpdateLevel();
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was a problem importing the arrays.", "LAZY SHELL");
            }
        }

        private void dumpTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.FileName = "NPCS.txt";
            saveFileDialog.RestoreDirectory = true;
            if (saveFileDialog.ShowDialog() != DialogResult.OK)
                return;

            StreamWriter npcrip = File.CreateText(saveFileDialog.FileName);
            Level tlvl;
            LevelNPCs.NPC tnpc;
            LevelNPCs.NPC.Instance tins;
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

                for (int j = 0; j < tlvl.LevelNPCs.npcs.Count; j++)
                {
                    tnpc = (LevelNPCs.NPC)tlvl.LevelNPCs.npcs[j];
                    if (tnpc.EngageType == 0) temp = (tnpc.EventORpack + tnpc.PropertyB).ToString("d4");
                    else temp = "N/A";

                    npcrip.Write("NPC #" + cnt.ToString("d2") + ", event: " + temp +
                        ", action: " + (tnpc.Movement + tnpc.PropertyC).ToString("d4") + "\n");

                    for (int k = 0; k < tnpc.Instances.Count; k++)
                    {
                        tins = (LevelNPCs.NPC.Instance)tnpc.Instances[k];
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

        // toolstrip menu items : View
        private void cartesianGridToolStripMenuItem_Click(object sender, EventArgs e)
        {
            state.CartesianGrid = cartesianGridToolStripMenuItem.Checked;
            buttonToggleCartGrid.Checked = state.CartesianGrid;
            state.OrthographicGrid = buttonToggleOrthGrid.Checked = false;
            pictureBoxLevel.Invalidate();
            pictureBoxTilesetL1.Invalidate();
            pictureBoxTilesetL2.Invalidate();
            pictureBoxTilesetL3.Invalidate();
            pictureBoxBattlefield.Invalidate();
            pictureBoxOverlaps.Invalidate();
        }
        private void orthographicGridToolStripMenuItem_Click(object sender, EventArgs e)
        {
            state.OrthographicGrid = orthographicGridToolStripMenuItem.Checked;
            buttonToggleOrthGrid.Checked = state.OrthographicGrid;
            state.CartesianGrid = buttonToggleCartGrid.Checked = false;
            pictureBoxLevel.Invalidate();
            pictureBoxTilesetL1.Invalidate();
            pictureBoxTilesetL2.Invalidate();
            pictureBoxTilesetL3.Invalidate();
            pictureBoxBattlefield.Invalidate();
        }
        private void backgroundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            state.BG = backgroundToolStripMenuItem.Checked;
            buttonToggleBG.Checked = state.BG;
            if (!updatingLevel)
                UpdateLevel();
        }
        private void maskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            state.Mask = maskToolStripMenuItem.Checked;
            buttonToggleMask.Checked = state.Mask;

            pictureBoxLevel.Invalidate();
        }
        private void layer1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            state.Layer1 = layer1ToolStripMenuItem.Checked;
            buttonToggleL1.Checked = state.Layer1;
            if (!updatingLevel)
                UpdateLevel();
        }
        private void layer2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            state.Layer2 = layer2ToolStripMenuItem.Checked;
            buttonToggleL2.Checked = state.Layer2;
            if (!updatingLevel)
                UpdateLevel();
        }
        private void layer3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            state.Layer3 = layer3ToolStripMenuItem.Checked;
            buttonToggleL3.Checked = state.Layer3;
            if (!updatingLevel)
                UpdateLevel();
        }
        private void priority1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            state.Priority1 = priority1ToolStripMenuItem.Checked;
            buttonToggleP1.Checked = state.Priority1;
            pictureBoxLevel.Invalidate();
            switch (tabControl2.SelectedIndex)
            {
                case 0: pictureBoxTilesetL1.Invalidate(); break;
                case 1: pictureBoxTilesetL2.Invalidate(); break;
                case 2: pictureBoxTilesetL3.Invalidate(); break;
            }
        }
        private void physicalMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            state.PhysicalLayer = physicalMapToolStripMenuItem.Checked;
            buttonTogglePhys.Checked = state.PhysicalLayer;
            pictureBoxLevel.Invalidate();
        }
        private void npcsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            state.Objects = npcsToolStripMenuItem.Checked;
            buttonToggleNPCs.Checked = state.Objects;
            pictureBoxLevel.Invalidate();
            if (npcs.NumberOfNPCs > 0)
            {
                if (npcObjectTree.SelectedNode.Parent != null)
                {
                    npcs.CurrentNPC = npcObjectTree.SelectedNode.Parent.Index;
                    npcs.CurrentInstance = npcObjectTree.SelectedNode.Index;
                }
                else
                    npcs.CurrentNPC = npcObjectTree.SelectedNode.Index;
            }
        }
        private void exitFieldsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            state.Exits = exitFieldsToolStripMenuItem.Checked;
            buttonToggleExits.Checked = state.Exits;
            pictureBoxLevel.Invalidate();

            if (exits.NumberOfExits > 0)
                exits.CurrentExit = this.exitsFieldTree.SelectedNode.Index;
        }
        private void eventFieldsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            state.Events = eventFieldsToolStripMenuItem.Checked;
            buttonToggleEvents.Checked = state.Events;
            pictureBoxLevel.Invalidate();

            if (events.NumberOfEvents > 0)
                events.CurrentEvent = this.eventsFieldTree.SelectedNode.Index;
        }

        // toolstrip menu items : Edit
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (state.Move)
            {
                moveImage = null;
                state.Move = false;
                overlay.DragStart = new Point(0, 0);
                overlay.DragStop = new Point(0, 0);
                pictureBoxLevel.Invalidate();
            }
            else if (state.Select)
            {
                MakeEditDelete();
            }
        }
        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (state.Select && !state.PhysicalLayer && overlay.DragStart.X != overlay.DragStop.X)
            {
                PasteFinal();
                Cut();
            }
        }
        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (state.Select && !state.PhysicalLayer && overlay.DragStart.X != overlay.DragStop.X)
            {
                PasteFinal();
                Copy();
            }
        }
        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PasteFinal();

            Point p;
            if (state.Select && !state.PhysicalLayer && moveImage != null)
            {
                overlay.SelectionSize = moveImage.Size;

                p = new Point();
                p.X = (panelLevelPicture.HorizontalScroll.Value / zoom) / 16 * 16;
                p.Y = (panelLevelPicture.VerticalScroll.Value / zoom) / 16 * 16;
                overlay.DragStart = p;
                overlay.DragStop = new Point(p.X + moveImage.Width, p.Y + moveImage.Height);

                state.Move = true;

                pictureBoxLevel.Invalidate();
            }
        }
        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (state.Move) // 2009-04-06
                return;

            Undo();
            overlay.DragStart = new Point(0, 0);
            overlay.DragStop = new Point(0, 0);
            overlay.PhysTilePoint = new Point(1024, 1024);
            pictureBoxLevel.Invalidate();
        }
        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (state.Move) // 2009-04-06
                return;

            Redo();
        }
        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            buttonEditSelect.Checked = true;
            buttonEditSelect_Click(null, null);
            overlay.DragStart = new Point(0, 0);
            overlay.DragStop = new Point(1024, 1024);
            pictureBoxLevel.Invalidate();
        }
        private void clearSelectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PasteFinal();

            overlay.DragStart = new Point(0, 0);
            overlay.DragStop = new Point(0, 0);
            overlay.PhysTilePoint = new Point(1024, 1024);
            overlay.TileSetDragStart = new Point(0, 0);
            overlay.TileSetDragStop = new Point(0, 0);
            overlay.TileSelected = 0;
            drawBuf = drawBufBuf = new int[][] { new int[] { 0 }, new int[] { 0 }, new int[] { 0 }, new int[] { 0 } };
            drawBufWidth = drawBufWidthBuf = 1;
            pictureBoxLevel.Invalidate();
            pictureBoxTilesetL1.Invalidate();
            pictureBoxTilesetL2.Invalidate();
            pictureBoxTilesetL3.Invalidate();
            pictureBoxBattlefield.Invalidate();
        }
        private void replaceTilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            labelTilesets.ForeColor = Color.Black;
            labelTilesets.BackColor = Color.Orange;
            labelTilesets.Text = "SELECT TILE # TO REPLACE IN TILEMAP...";

            replaceChoose = true;
        }
        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            if (state.PhysicalLayer)
            {
                tabControl2.SelectedIndex = 3;
                physicalTileNum.Value = BitManager.GetShort(physicalMap.ThePhysicalMap, physicalMap.OrthTileNum[mouse.Y * 1024 + mouse.X] * 2);
                return;
            }

            int tile = tileMap.GetTileNum(tabControl2.SelectedIndex, mouse.X, mouse.Y);
            int tilex = (tile % 16);
            int tiley = (tile / 16);

            overlay.TileSelected = tile;
            overlay.TileSetDragStart = new Point(tilex * 16, tiley * 16);
            overlay.TileSetDragStop = new Point(tilex * 16 + 16, tiley * 16 + 16);

            if (tabControl2.SelectedIndex < 3)
                drawBufWidth = GetTileSetSelection(ref this.drawBuf[tabControl2.SelectedIndex]);

            // Generates a new image if we need one
            switch (tabControl2.SelectedIndex) // Set the image to the correct pictureBox
            {
                case 0: pictureBoxTilesetL1.Invalidate(); break;
                case 1: pictureBoxTilesetL2.Invalidate(); break;
                case 2: pictureBoxTilesetL3.Invalidate(); break;
                case 4: pictureBoxBattlefield.Invalidate(); break;
                default: break;
            }

            InitializeTileEditor();
        }

        // toolstrip buttons
        private void buttonToggleProperties_Click(object sender, EventArgs e)
        {
            if (this.areaPropertiesPanel.Visible == true)
            {
                this.areaPropertiesPanel.Visible = false;
                this.panelLevelPicture.Left -= areaPropertiesPanel.Width;
                this.panelLevelPicture.Width += areaPropertiesPanel.Width;
                this.label67.Left -= areaPropertiesPanel.Width;
                this.label67.Width += areaPropertiesPanel.Width;
                this.labelTileCoords.Left -= areaPropertiesPanel.Width;
                this.labelTileCoords.Width += areaPropertiesPanel.Width;
                this.buttonToggleProperties.Checked = false;
            }
            else if (this.areaPropertiesPanel.Visible == false)
            {
                this.areaPropertiesPanel.Visible = true;
                this.panelLevelPicture.Left += areaPropertiesPanel.Width;
                this.panelLevelPicture.Width -= areaPropertiesPanel.Width;
                this.label67.Left += areaPropertiesPanel.Width;
                this.label67.Width -= areaPropertiesPanel.Width;
                this.labelTileCoords.Left += areaPropertiesPanel.Width;
                this.labelTileCoords.Width -= areaPropertiesPanel.Width;
                this.buttonToggleProperties.Checked = true;
            }
        }
        private void buttonToggleTileEditor_Click(object sender, EventArgs e)
        {
            panelTileEditor.Visible = !panelTileEditor.Visible;
        }
        private void buttonToggleTemplates_Click(object sender, EventArgs e)
        {
            panelTemplates.Visible = !panelTemplates.Visible;
        }
        private void buttonToggleCartGrid_Click(object sender, EventArgs e)
        {
            state.CartesianGrid = buttonToggleCartGrid.Checked;
            cartesianGridToolStripMenuItem.Checked = state.CartesianGrid;
            state.OrthographicGrid = buttonToggleOrthGrid.Checked = false;
            pictureBoxLevel.Invalidate();
            pictureBoxTilesetL1.Invalidate();
            pictureBoxTilesetL2.Invalidate();
            pictureBoxTilesetL3.Invalidate();
            pictureBoxBattlefield.Invalidate();
            pictureBoxOverlaps.Invalidate();
        }
        private void buttonToggleOrthGrid_Click(object sender, EventArgs e)
        {
            state.OrthographicGrid = buttonToggleOrthGrid.Checked;
            state.CartesianGrid = buttonToggleCartGrid.Checked = false;
            pictureBoxLevel.Invalidate();
            pictureBoxTilesetL1.Invalidate();
            pictureBoxTilesetL2.Invalidate();
            pictureBoxTilesetL3.Invalidate();
            pictureBoxBattlefield.Invalidate();
        }
        private void buttonToggleBG_Click(object sender, EventArgs e)
        {
            state.BG = buttonToggleBG.Checked;
            backgroundToolStripMenuItem.Checked = state.BG;
            if (!updatingLevel)
                UpdateLevel();
        }
        private void buttonToggleMask_Click(object sender, EventArgs e)
        {
            state.Mask = buttonToggleMask.Checked;
            maskToolStripMenuItem.Checked = state.Mask;

            pictureBoxLevel.Invalidate();
        }
        private void buttonToggleL1_Click(object sender, EventArgs e)
        {
            state.Layer1 = buttonToggleL1.Checked;
            layer1ToolStripMenuItem.Checked = state.Layer1;
            if (!updatingLevel)
                UpdateLevel();
        }
        private void buttonToggleL2_Click(object sender, EventArgs e)
        {
            state.Layer2 = buttonToggleL2.Checked;
            layer2ToolStripMenuItem.Checked = state.Layer2;
            if (!updatingLevel)
                UpdateLevel();
        }
        private void buttonToggleL3_Click(object sender, EventArgs e)
        {
            state.Layer3 = buttonToggleL3.Checked;
            layer3ToolStripMenuItem.Checked = state.Layer3;
            if (!updatingLevel)
                UpdateLevel();
        }
        private void buttonToggleP1_Click(object sender, EventArgs e)
        {
            state.Priority1 = buttonToggleP1.Checked;
            priority1ToolStripMenuItem.Checked = state.Priority1;
            pictureBoxLevel.Invalidate();
            switch (tabControl2.SelectedIndex)
            {
                case 0: pictureBoxTilesetL1.Invalidate(); break;
                case 1: pictureBoxTilesetL2.Invalidate(); break;
                case 2: pictureBoxTilesetL3.Invalidate(); break;
            }
        }
        private void buttonTogglePhys_Click(object sender, EventArgs e)
        {
            state.PhysicalLayer = buttonTogglePhys.Checked;
            if (state.PhysicalLayer)
                tabControl2.SelectedIndex = 3;
            physicalMapToolStripMenuItem.Checked = state.PhysicalLayer;
            pictureBoxLevel.Invalidate();
        }
        private void buttonToggleNPCs_Click(object sender, EventArgs e)
        {
            state.Objects = buttonToggleNPCs.Checked;
            npcsToolStripMenuItem.Checked = state.Objects;

            pictureBoxLevel.Invalidate();

            if (npcs.NumberOfNPCs > 0)
            {
                if (npcObjectTree.SelectedNode != null && npcObjectTree.SelectedNode.Parent != null)
                {
                    npcs.CurrentNPC = npcObjectTree.SelectedNode.Parent.Index;
                    npcs.CurrentInstance = npcObjectTree.SelectedNode.Index;
                    npcs.SelectedInstance = npcs.CurrentInstance;
                }
                else if (npcObjectTree.SelectedNode != null)
                {
                    npcs.CurrentNPC = npcObjectTree.SelectedNode.Index;
                    npcs.SelectedNPC = npcs.CurrentNPC;
                }
            }
        }
        private void buttonToggleExits_Click(object sender, EventArgs e)
        {
            state.Exits = buttonToggleExits.Checked;
            exitFieldsToolStripMenuItem.Checked = state.Exits;

            pictureBoxLevel.Invalidate();

            if (exits.NumberOfExits > 0 && this.exitsFieldTree.SelectedNode != null)
                exits.CurrentExit = this.exitsFieldTree.SelectedNode.Index;
        }
        private void buttonToggleEvents_Click(object sender, EventArgs e)
        {
            state.Events = buttonToggleEvents.Checked;
            eventFieldsToolStripMenuItem.Checked = state.Events;

            pictureBoxLevel.Invalidate();

            if (events.NumberOfEvents > 0 && eventsFieldTree.SelectedNode != null)
                events.CurrentEvent = this.eventsFieldTree.SelectedNode.Index;
        }
        private void buttonToggleOverlaps_Click(object sender, EventArgs e)
        {
            state.Overlaps = buttonToggleOverlaps.Checked;
            pictureBoxLevel.Invalidate();

            if (overlaps.NumberOfOverlaps > 0 & overlapFieldTree.SelectedNode != null)
                overlaps.CurrentOverlap = this.overlapFieldTree.SelectedNode.Index;
        }
        private void buttonEditTemplate_Click(object sender, EventArgs e)
        {
            state.Template = buttonEditTemplate.Checked;
            buttonEditDraw.Checked = false;
            buttonEditSelect.Checked = false;
            buttonEditErase.Checked = false;
            buttonEditDropper.Checked = false;
            buttonZoomIn.Checked = false;
            buttonZoomOut.Checked = false;
            if (buttonEditTemplate.Checked)
                this.pictureBoxLevel.Cursor = new System.Windows.Forms.Cursor(GetType(), "CursorTemplate.cur");
            else if (!buttonEditTemplate.Checked)
                this.pictureBoxLevel.Cursor = System.Windows.Forms.Cursors.Arrow;

            overlay.ClearSelection = true;
        }
        private void buttonEditDraw_Click(object sender, EventArgs e)
        {
            state.Draw = buttonEditDraw.Checked;
            buttonEditTemplate.Checked = false;
            buttonEditSelect.Checked = false;
            buttonEditErase.Checked = false;
            buttonEditDropper.Checked = false;
            buttonZoomIn.Checked = false;
            buttonZoomOut.Checked = false;
            if (buttonEditDraw.Checked)
                this.pictureBoxLevel.Cursor = new System.Windows.Forms.Cursor(GetType(), "CursorDraw.cur");
            else if (!buttonEditDraw.Checked)
                this.pictureBoxLevel.Cursor = System.Windows.Forms.Cursors.Arrow;

            overlay.ClearSelection = true;
        }
        private void buttonEditSelect_Click(object sender, EventArgs e)
        {
            state.Select = buttonEditSelect.Checked;
            buttonEditTemplate.Checked = false;
            buttonEditDraw.Checked = false;
            buttonEditErase.Checked = false;
            buttonEditDropper.Checked = false;
            buttonZoomIn.Checked = false;
            buttonZoomOut.Checked = false;
            if (state.Select)
                this.pictureBoxLevel.Cursor = System.Windows.Forms.Cursors.Cross;
            else if (!state.Select)
                this.pictureBoxLevel.Cursor = System.Windows.Forms.Cursors.Arrow;

            overlay.ClearSelection = true;
        }
        private void buttonEditErase_Click(object sender, EventArgs e)
        {
            state.Erase = buttonEditErase.Checked;
            buttonEditTemplate.Checked = false;
            buttonEditDraw.Checked = false;
            buttonEditSelect.Checked = false;
            buttonEditDropper.Checked = false;
            buttonZoomIn.Checked = false;
            buttonZoomOut.Checked = false;
            if (state.Erase)
                this.pictureBoxLevel.Cursor = new System.Windows.Forms.Cursor(GetType(), "CursorErase.cur");
            else if (!state.Erase)
                this.pictureBoxLevel.Cursor = System.Windows.Forms.Cursors.Arrow;

            overlay.ClearSelection = true;
        }
        private void buttonEditDropper_Click(object sender, EventArgs e)
        {
            state.Dropper = buttonEditDropper.Checked;
            buttonEditTemplate.Checked = false;
            buttonEditDraw.Checked = false;
            buttonEditSelect.Checked = false;
            buttonEditErase.Checked = false;
            buttonZoomIn.Checked = false;
            buttonZoomOut.Checked = false;

            if (state.Dropper)
                this.pictureBoxLevel.Cursor = new System.Windows.Forms.Cursor(GetType(), "CursorDropper.cur");
            else if (!state.Dropper)
                this.pictureBoxLevel.Cursor = System.Windows.Forms.Cursors.Arrow;

            overlay.ClearSelection = true;
        }
        private void buttonEditDelete_Click(object sender, EventArgs e)
        {
            deleteToolStripMenuItem_Click(null, null);
        }
        private void buttonEditUndo_Click(object sender, EventArgs e)
        {
            undoToolStripMenuItem_Click(null, null);
        }
        private void buttonEditRedo_Click(object sender, EventArgs e)
        {
            redoToolStripMenuItem_Click(null, null);
        }
        private void buttonEditCut_Click(object sender, EventArgs e)
        {
            cutToolStripMenuItem_Click(null, null);
        }
        private void buttonEditCopy_Click(object sender, EventArgs e)
        {
            copyToolStripMenuItem_Click(null, null);
        }
        private void buttonEditPaste_Click(object sender, EventArgs e)
        {
            pasteToolStripMenuItem_Click(null, null);
        }
        private void buttonZoomIn_Click(object sender, EventArgs e)
        {
            buttonEditTemplate.Checked = false;
            buttonEditDraw.Checked = false;
            buttonEditErase.Checked = false;
            buttonEditDropper.Checked = false;
            buttonEditSelect.Checked = false;
            buttonZoomOut.Checked = false;
            if (buttonZoomIn.Checked)
                this.pictureBoxLevel.Cursor = new System.Windows.Forms.Cursor(GetType(), "CursorZoomIn.cur");
            else if (!buttonZoomIn.Checked)
                this.pictureBoxLevel.Cursor = System.Windows.Forms.Cursors.Arrow;
        }
        private void buttonZoomOut_Click(object sender, EventArgs e)
        {
            buttonEditTemplate.Checked = false;
            buttonEditDraw.Checked = false;
            buttonEditErase.Checked = false;
            buttonEditDropper.Checked = false;
            buttonEditSelect.Checked = false;
            buttonZoomIn.Checked = false;
            if (buttonZoomOut.Checked)
                this.pictureBoxLevel.Cursor = new System.Windows.Forms.Cursor(GetType(), "CursorZoomOut.cur");
            else if (!buttonZoomOut.Checked)
                this.pictureBoxLevel.Cursor = System.Windows.Forms.Cursors.Arrow;
        }
        private void buttonZoomIn_CheckedChanged(object sender, EventArgs e)
        {
            if (buttonZoomIn.Checked)
                pictureBoxLevel.ContextMenuStrip = null;
            else
                pictureBoxLevel.ContextMenuStrip = contextMenuStrip1;
        }
        private void buttonZoomOut_CheckedChanged(object sender, EventArgs e)
        {
            if (buttonZoomOut.Checked)
                pictureBoxLevel.ContextMenuStrip = null;
            else
                pictureBoxLevel.ContextMenuStrip = contextMenuStrip1;
        }
        private void levelPreviewToolStripButton_Click(object sender, EventArgs e)
        {
            PreviewLevel();
        }
        private void opacityToolStripButton_Click(object sender, EventArgs e)
        {
            panelOpacity.Visible = !panelOpacity.Visible;
        }
        private void overlayOpacity_Scroll(object sender, EventArgs e)
        {
            labelOverlayOpacity.Text = overlayOpacity.Value + "%";
            overlay.alpha = overlayOpacity.Value * 255 / 100;
            pictureBoxLevel.Invalidate();
        }

        // templates
        private void templateTransfer_Click(object sender, EventArgs e)
        {
            if (overlay.DragStart.X == overlay.DragStop.X || overlay.DragStart.Y == overlay.DragStop.Y)
            {
                MessageBox.Show("Need to make a selection before creating a new template.",
                    "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            panel1.Enabled = false;
            panelTemplateName.BringToFront();
            panelTemplateName.Show();
            templateName.Focus();
        }
        private void templateImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = settings.LastRomPath;
            openFileDialog1.Title = "Select the template .dat files that you want to import.";
            openFileDialog1.Filter = "Template data files (*.dat)|*.dat|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.Multiselect = true;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;

            Stream s;
            BinaryFormatter b = new BinaryFormatter();

            LevelTemplate temp;
            templates.Clear();
            templatesLoaded.Items.Clear();
            try
            {
                foreach (string path in openFileDialog1.FileNames)
                {
                    s = File.OpenRead(path);
                    temp = (LevelTemplate)b.Deserialize(s);
                    templates.Add(temp);
                    templatesLoaded.Items.Add(temp.Name);
                    s.Close();
                }
                templatesLoaded.Enabled = true;
                templateRenameText.Enabled = true;
                templateRename.Enabled = true;

                if (templatesLoaded.Items.Count > 0)
                    templatesLoaded.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was a problem loading the templates", "LAZY SHELL");
            }
        }
        private void templateExport_Click(object sender, EventArgs e)
        {
            if (templates.Count == 0)
                return;

            string path = GetDirectoryPath("Select the directory that you want to export the templates to.");
            path += "\\" + model.GetFileNameWithoutPath() + " - Level Templates\\";
            if (!CreateDir(path))
                return;

            Stream s;
            BinaryFormatter b = new BinaryFormatter();
            try
            {
                foreach (LevelTemplate lt in templates)
                {
                    s = File.Create(path + lt.Name + ".dat");
                    b.Serialize(s, lt);
                    s.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was a problem saving the templates", "LAZY SHELL");
            }
        }
        private void templateDelete_Click(object sender, EventArgs e)
        {
            if (template == null || templates.Count == 0)
                return;

            templates.Remove(template);
            int temp = templatesLoaded.SelectedIndex;

            templatesLoaded.BeginUpdate();

            templatesLoaded.Items.Clear();
            foreach (LevelTemplate lt in templates)
                templatesLoaded.Items.Add(lt.Name);

            templatesLoaded.EndUpdate();

            if (templates.Count == 0)
            {
                templatesLoaded.Enabled = false;
                templateRenameText.Enabled = false;
                templateRenameText.Text = "";
                templateRename.Enabled = false;
                templateImage = null;
                pictureBoxTemplate.Invalidate();
                template = null;
            }
            else if (templates.Count == temp)
                templatesLoaded.SelectedIndex = temp - 1;
            else
                templatesLoaded.SelectedIndex = temp;
        }
        private void templateCopy_Click(object sender, EventArgs e)
        {
            if (template == null || templates.Count == 0)
                return;

            templateC = template;
        }
        private void templatePaste_Click(object sender, EventArgs e)
        {
            if (templateC == null || templates.Count == 0)
                return;

            template = templateC;
            templates.Add(template);

            templatesLoaded.Items.Add(template.Name);
            templatesLoaded.SelectedIndex = templatesLoaded.Items.Count - 1;
            templatesLoaded.Enabled = true;
            templateRenameText.Enabled = true;
            templateRename.Enabled = true;

            templateRenameText.Text = template.Name;
        }
        private void templatesLoaded_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (templatesLoaded.SelectedIndex == -1) return;

            template = (LevelTemplate)templates[templatesLoaded.SelectedIndex];
            templateRenameText.Text = template.Name;

            pictureBoxTemplate.Size = template.Size;
            templateImage = new Bitmap(Drawing.PixelArrayToImage(template.GetTemplatePixels(
                this.levelMap, this.paletteSet, this.tileSet, this.layer, this.prioritySets),
                template.Size.Width, template.Size.Height));
            pictureBoxTemplate.Invalidate();
        }
        private void templateRename_Click(object sender, EventArgs e)
        {
            if (templateRenameText.Text == "")
            {
                MessageBox.Show("A template name cannot be empty.", "LAZY SHELL");
                return;
            }
            foreach (LevelTemplate lt in templates)
            {
                if (template != lt && templateRenameText.Text == lt.Name)
                {
                    MessageBox.Show("Cannot rename " + lt.Name + ". A template with the name you specified already exists.",
                       "LAZY SHELL");
                    return;
                }
                else if (template == lt && template.Name == templateRenameText.Text)
                    return;
            }

            int index = templatesLoaded.SelectedIndex;
            template.Name = templateRenameText.Text;
            templatesLoaded.Items[index] = template.Name;
        }
        private void pictureBoxTemplate_Paint(object sender, PaintEventArgs e)
        {
            if (templateImage != null)
                e.Graphics.DrawImage(templateImage, 0, 0);
        }

        private void templateName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                buttonTemplateOK_Click(null, null);
        }
        private void buttonTemplateOK_Click(object sender, EventArgs e)
        {
            if (templateName.Text == "")
            {
                MessageBox.Show("A template name cannot be empty.", "LAZY SHELL");
                return;
            }

            panelTemplateName.Hide();

            panel1.Enabled = true;

            template = new LevelTemplate();

            // can't have templates with the same name
            int ctr = 0;
            string temp = templateName.Text;
            foreach (LevelTemplate lt in templates)
            {
                if (lt.Name == templateName.Text)
                {
                    templateName.Text = temp + ctr.ToString();
                    ctr++;
                }
            }

            template.Name = templateName.Text;
            templates.Add(template);

            templateRenameText.Enabled = true;
            templateRename.Enabled = true;

            tileMap.AssembleIntoModel();

            Point stop = overlay.DragStop;
            if (((overlay.DragStop.X - overlay.DragStart.X) / 16) % 2 != 0)
                stop.X += 16;
            template.Transfer(tileMap.TileMaps, levelMap, physicalMap, overlay.DragStart, stop);

            templateName.Text = "";

            templatesLoaded.Items.Add(template.Name);
            templatesLoaded.SelectedIndex = templatesLoaded.Items.Count - 1;
            templatesLoaded.Enabled = true;
        }
        private void buttonTemplateCancel_Click(object sender, EventArgs e)
        {
            panelTemplateName.Hide();
            templateName.Text = "";

            panel1.Enabled = true;
        }

        // pictureBoxLevel
        private void pictureBoxLevel_MouseDown(object sender, MouseEventArgs e)
        {
            Point p = new Point();

            p.X = Math.Abs(panelLevelPicture.AutoScrollPosition.X);
            p.Y = Math.Abs(panelLevelPicture.AutoScrollPosition.Y);

            if ((buttonZoomIn.Checked && e.Button == MouseButtons.Left) || (buttonZoomOut.Checked && e.Button == MouseButtons.Right))
            {
                if (zoom < 8)
                {
                    zoom *= 2;

                    p = new Point(Math.Abs(pictureBoxLevel.Left), Math.Abs(pictureBoxLevel.Top));
                    p.X += e.X;
                    p.Y += e.Y;

                    pictureBoxLevel.Width = 1024 * zoom;
                    pictureBoxLevel.Height = 1024 * zoom;
                    panelLevelPicture.Focus();
                    panelLevelPicture.AutoScrollPosition = p;
                    panelLevelPicture.VerticalScroll.SmallChange *= 2;
                    panelLevelPicture.HorizontalScroll.SmallChange *= 2;
                    panelLevelPicture.VerticalScroll.LargeChange *= 2;
                    panelLevelPicture.HorizontalScroll.LargeChange *= 2;
                    pictureBoxLevel.Invalidate();
                    return;
                }
                return;
            }
            else if ((buttonZoomOut.Checked && e.Button == MouseButtons.Left) || (buttonZoomIn.Checked && e.Button == MouseButtons.Right))
            {
                if (zoom > 1)
                {
                    zoom /= 2;

                    p = new Point(Math.Abs(pictureBoxLevel.Left), Math.Abs(pictureBoxLevel.Top));
                    p.X -= e.X / 2;
                    p.Y -= e.Y / 2;

                    pictureBoxLevel.Width = 1024 * zoom;
                    pictureBoxLevel.Height = 1024 * zoom;
                    panelLevelPicture.Focus();
                    panelLevelPicture.AutoScrollPosition = p;
                    panelLevelPicture.VerticalScroll.SmallChange /= 2;
                    panelLevelPicture.HorizontalScroll.SmallChange /= 2;
                    panelLevelPicture.VerticalScroll.LargeChange /= 2;
                    panelLevelPicture.HorizontalScroll.LargeChange /= 2;
                    pictureBoxLevel.Invalidate();
                    return;
                }
                return;
            }

            if (e.Button == MouseButtons.Right) return;

            mouseMoveStart = true;

            // DRAWING, ERASING, SELECTING

            int x = e.X / (16 * zoom) * (16 * zoom);
            int y = e.Y / (16 * zoom) * (16 * zoom);

            if (state.Move && !insideSelection)
            {
                Paste(new Point(overlay.DragStart.X, overlay.DragStart.Y));

                copyPaste = copyPasteBuf;
                drawBuf = drawBufBuf;
                drawBufWidth = drawBufWidthBuf;

                state.Move = false;
            }

            if (state.Select)
            {
                panelLevelPicture.Focus();
                if (!state.PhysicalLayer)
                {
                    if (!insideSelection)   // if we're not inside a current selection to move it, create a new selection
                    {
                        overlay.DragStart = new Point(x / zoom, y / zoom);
                        overlay.DragStop = new Point(x / zoom + 16, y / zoom + 16);
                        overlay.SelectionSize = new Size(16, 16);
                    }
                    else if (overlay.SelectionSize.Width != 0 && overlay.SelectionSize.Height != 0 && insideSelection)
                    {
                        moveDiff = new Size((x / zoom) - overlay.DragStart.X, (y / zoom) - overlay.DragStart.Y);

                        if (!state.Move)    // only do this if the current selection has not been initially moved
                        {
                            state.Move = true;

                            Size s = new Size(overlay.DragStop.X - overlay.DragStart.X, overlay.DragStop.Y - overlay.DragStart.Y);
                            overlay.SelectionSize = s;

                            Cut();
                        }
                    }
                }
                else if (state.PhysicalLayer)
                {
                    selectPhysicalTile = physicalMap.OrthTileNum[(e.Y / zoom) * 1024 + (e.X / zoom)];
                    overlay.PhysTilePoint = new Point(physicalMap.OrthTilePosX[selectPhysicalTile], physicalMap.OrthTilePosY[selectPhysicalTile]);
                    selectPhysicalTileNum = BitManager.GetShort(physicalMap.ThePhysicalMap, selectPhysicalTile * 2);
                    overlay.PhysTileTotalHeight = physicalTiles[selectPhysicalTileNum].PhysicalTileTotalHeight;
                }
            }

            MouseEventArgs m = new MouseEventArgs(e.Button, e.Clicks, (int)(e.X / zoom), (int)(e.Y / zoom), e.Delta);
            if (e.Button == MouseButtons.Left)
            {
                if (state.Dropper)
                {
                    MakeSelectColor(m);
                    return;
                }
                if (state.Template)
                {
                    MakeEditTemplate(m, pictureBoxLevel.CreateGraphics());

                    panelLevelPicture.AutoScrollPosition = p;
                    return;
                }
                if (state.Draw)
                {
                    MakeEditDraw(m, pictureBoxLevel.CreateGraphics());

                    panelLevelPicture.AutoScrollPosition = p;
                    return;
                }
                if (state.Erase)
                {
                    MakeEditErase(m, pictureBoxLevel.CreateGraphics());

                    panelLevelPicture.AutoScrollPosition = p;
                    return;
                }
            }

            // OBJECT SELECTING

            if (!state.Template && !state.Draw && !state.Select && !state.Erase && e.Button == MouseButtons.Left)
            {
                if (state.Exits && overExitField != 0)
                {
                    this.exitsFieldTree.Focus();
                    clickExitField = overExitField;
                    exits.CurrentExit = clickExitField - 1;
                    exits.SelectedExit = clickExitField - 1;

                    this.exitsFieldTree.SelectedNode = this.exitsFieldTree.Nodes[exits.CurrentExit];
                    if (!exitsFieldTree.Created)
                        exitsFieldTree_AfterSelect(null, null);

                    exits.CurrentExit = clickExitField - 1;
                }
                if (state.Events && overEventField != 0 && clickExitField == 0)
                {
                    this.eventsFieldTree.Focus();
                    clickEventField = overEventField;
                    events.CurrentEvent = clickEventField - 1;
                    events.SelectedEvent = clickEventField - 1;

                    this.eventsFieldTree.SelectedNode = this.eventsFieldTree.Nodes[events.CurrentEvent];
                    if (!eventsFieldTree.Created)
                        eventsFieldTree_AfterSelect(null, null);

                    events.CurrentEvent = clickEventField - 1;
                }
                if (state.Objects && overNPC != 0 && clickExitField == 0 && clickEventField == 0)
                {
                    this.npcObjectTree.ExpandAll();
                    this.npcObjectTree.Focus();
                    if (overInstance == 0)
                    {
                        clickNPC = overNPC;
                        npcs.CurrentNPC = clickNPC - 1;
                        npcs.SelectedNPC = clickNPC - 1;
                        npcs.IsInstanceSelected = false;

                        npcObjectTree.SelectedNode = npcObjectTree.Nodes[npcs.CurrentNPC];
                        if (!npcObjectTree.Created)
                            npcObjectTree_AfterSelect(null, null);

                        npcs.CurrentNPC = clickNPC - 1;
                    }
                    else if (overInstance != 0)
                    {
                        clickNPC = overNPC;
                        clickInstance = overInstance;
                        npcs.CurrentNPC = clickNPC - 1;
                        npcs.SelectedNPC = clickNPC - 1;
                        npcs.CurrentInstance = clickInstance - 1;
                        npcs.SelectedInstance = clickInstance - 1;
                        npcs.IsInstanceSelected = true;

                        npcObjectTree.SelectedNode = npcObjectTree.Nodes[npcs.CurrentNPC].Nodes[npcs.CurrentInstance];
                        if (!npcObjectTree.Created)
                            npcObjectTree_AfterSelect(null, new TreeViewEventArgs(npcObjectTree.SelectedNode));

                        npcs.CurrentNPC = clickNPC - 1;
                        npcs.CurrentInstance = clickInstance - 1;
                    }
                }
                if (state.Overlaps && overOverlap != 0 &&
                    clickExitField == 0 && clickEventField == 0 && clickNPC == 0 && clickInstance == 0)
                {
                    this.overlapFieldTree.Focus();
                    clickOverlap = overOverlap;
                    overlaps.CurrentOverlap = clickOverlap - 1;
                    overlaps.SelectedOverlap = clickOverlap - 1;

                    this.overlapFieldTree.SelectedNode = this.overlapFieldTree.Nodes[overlaps.CurrentOverlap];
                    if (!overlapFieldTree.Created)
                        overlapFieldTree_AfterSelect(null, null);

                    overlaps.CurrentOverlap = clickOverlap - 1;
                }
            }

            panelLevelPicture.AutoScrollPosition = p;

            pictureBoxLevel.Invalidate();
        }
        private void pictureBoxLevel_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (state.Select && state.PhysicalLayer)
                this.physicalTileNum.Value = selectPhysicalTileNum;

            clickExitField = 0;
            clickEventField = 0;
            clickNPC = 0;
            clickInstance = 0;
            clickOverlap = 0;

            if (state.Draw || state.Erase)
            {
                if (!state.PhysicalLayer)
                    DrawLevelWithoutUpdate();
                else
                    pictureBoxLevel.Invalidate();
            }
        }
        private void pictureBoxLevel_MouseMove(object sender, MouseEventArgs e)
        {
            mousePos = e.Location;

            // set zoom box
            if (state.Dropper)
            {
                Control parent = (Control)pictureBoxLevel.Parent;
                Point p = pictureBoxLevel.Location;
                while (parent.Parent != this)
                {
                    p.X += parent.Location.X;
                    p.Y += parent.Location.Y;
                    parent = parent.Parent;
                }
                Point l = new Point(p.X + e.X + 100, p.Y + e.Y + 150);
                if (l.X + panelLevelZoom.Width + 50 > this.Width)
                    l.X -= panelLevelZoom.Width + 100;
                if (l.Y + panelLevelZoom.Height + 50 > this.Height)
                    l.Y -= panelLevelZoom.Height + 150;
                panelLevelZoom.Location = l;
                pictureBoxLevelZoom.Invalidate();

                panelLevelZoom.Visible = true;
            }
            //

            Point tile = overTile;

            // for making quick jumps in the mouse movement when dragging something
            Point previous = new Point(orthCoordX, orthCoordY);

            UpdateCoordLabels(e.Location);

            MouseEventArgs m = new MouseEventArgs(e.Button, e.Clicks, e.X / zoom, e.Y / zoom, e.Delta);
            int x = e.X / (16 * zoom) * (16 * zoom);
            int y = e.Y / (16 * zoom) * (16 * zoom);
            insideSelection = false;

            if (buttonZoomIn.Checked || buttonZoomOut.Checked)
            {
                pictureBoxLevel.Invalidate();
                return;
            }

            if (!state.PhysicalLayer)
            {
                if (state.Draw && e.Button == MouseButtons.Left)
                {
                    MakeEditDraw(m, pictureBoxLevel.CreateGraphics());
                    return;
                }
                else if (state.Select)
                {
                    if (!state.Move)
                    {
                        if (overlay.DragStop == new Point(x / zoom, y / zoom)) return;

                        if (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right)
                        {
                            overlay.DragStop = new Point(x / zoom + 16, y / zoom + 16);
                            overlay.SelectionSize = new Size(overlay.DragStop.X - overlay.DragStart.X, overlay.DragStop.Y - overlay.DragStart.Y);
                        }
                    }
                    else
                    {
                        if (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right)
                        {
                            overlay.DragStart = new Point((x / zoom) - moveDiff.Width, (y / zoom) - moveDiff.Height);
                            Point tp = new Point((x / zoom) - moveDiff.Width, (y / zoom) - moveDiff.Height);
                            overlay.DragStop = new Point(tp.X + overlay.SelectionSize.Width, tp.Y + overlay.SelectionSize.Height);
                        }
                    }
                    if ((e.Button == MouseButtons.None || state.Move) &&
                        overlay.DragStart != overlay.DragStop &&
                        x / zoom >= overlay.DragStart.X &&
                        x / zoom < overlay.DragStop.X &&
                        y / zoom >= overlay.DragStart.Y &&
                        y / zoom < overlay.DragStop.Y)
                    {
                        insideSelection = true;
                        pictureBoxLevel.Cursor = Cursors.SizeAll;
                    }
                    else
                    {
                        pictureBoxLevel.Cursor = Cursors.Cross;
                    }

                    pictureBoxLevel.Invalidate();

                    return;
                }
                else if (state.Erase && e.Button == MouseButtons.Left)
                {
                    MakeEditErase(m, pictureBoxLevel.CreateGraphics());
                    return;
                }
            }
            else if (state.PhysicalLayer)
            {
                if (!waitForChange || mouseMoveStart)
                {
                    if (state.Draw && e.Button == MouseButtons.Left)
                    {
                        MakeEditDraw(m, pictureBoxLevel.CreateGraphics());
                    }
                    if (state.Erase && e.Button == MouseButtons.Left)
                    {
                        MakeEditErase(m, pictureBoxLevel.CreateGraphics());
                    }
                    if (state.Dropper && e.Button == MouseButtons.Left)
                    {
                        MakeSelectColor(m);
                    }
                }
            }

            // check if over a field
            if (!state.Template && !state.Draw && !state.Select && !state.Erase && !state.Dropper)
            {
                if (e.Button == MouseButtons.Left)  // if dragging a field
                {
                    if (clickExitField != 0)
                    {
                        if (Math.Abs(orthCoordX - previous.X) > 0 || Math.Abs(orthCoordY - previous.Y) > 0)
                            return;
                        if (exitsFieldXCoord.Value != orthCoordX && exitsFieldYCoord.Value != orthCoordY)
                            waitBothCoords = true;
                        this.exitsFieldXCoord.Value = orthCoordX;
                        waitBothCoords = false;
                        this.exitsFieldYCoord.Value = orthCoordY;
                    }
                    if (clickEventField != 0)
                    {
                        if (Math.Abs(orthCoordX - previous.X) > 0 || Math.Abs(orthCoordY - previous.Y) > 0)
                            return;
                        if (eventsFieldXCoord.Value != orthCoordX && eventsFieldYCoord.Value != orthCoordY)
                            waitBothCoords = true;
                        this.eventsFieldXCoord.Value = orthCoordX;
                        waitBothCoords = false;
                        this.eventsFieldYCoord.Value = orthCoordY;
                    }
                    if (clickNPC != 0)
                    {
                        if (Math.Abs(orthCoordX - previous.X) > 0 || Math.Abs(orthCoordY - previous.Y) > 0)
                            return;
                        if (npcXCoord.Value != orthCoordX && npcYCoord.Value != orthCoordY)
                            waitBothCoords = true;
                        this.npcXCoord.Value = orthCoordX;
                        waitBothCoords = false;
                        this.npcYCoord.Value = orthCoordY;
                    }
                    if (clickOverlap != 0)
                    {
                        if (Math.Abs(orthCoordX - previous.X) > 0 || Math.Abs(orthCoordY - previous.Y) > 0)
                            return;
                        if (overlapCoordX.Value != orthCoordX && overlapCoordY.Value != orthCoordY)
                            waitBothCoords = true;
                        this.overlapCoordX.Value = orthCoordX;
                        waitBothCoords = false;
                        this.overlapCoordY.Value = orthCoordY;
                    }
                    pictureBoxLevel.Invalidate();
                    return;
                }
                else
                {
                    pictureBoxLevel.Cursor = Cursors.Arrow;
                    if (state.Exits && exits.NumberOfExits != 0)
                        SetOverExit();
                    if (state.Events && events.NumberOfEvents != 0 && !isOverSomething)
                        SetOverEvent();
                    if (state.Objects && npcs.NumberOfNPCs != 0 && !isOverSomething)
                        SetOverNPC();
                    if (state.Overlaps && overlaps.NumberOfOverlaps != 0 && !isOverSomething)
                        SetOverOverlap();
                }
            }

            if (!state.PhysicalLayer && !state.Objects && !state.Exits && !state.Events && !state.Overlaps && tile != overTile)
                pictureBoxLevel.Invalidate();
            else if ((state.PhysicalLayer || state.Objects || state.Exits || state.Events || state.Overlaps))
                pictureBoxLevel.Invalidate();

            isOverSomething = false;
            mouseMoveStart = false;
        }
        private void pictureBoxLevel_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            toolStripMenuItem5_Click(null, null);
        }
        private void pictureBoxLevel_MouseEnter(object sender, EventArgs e)
        {
            mouseEnter = true;
            pictureBoxLevel.Invalidate();
        }
        private void pictureBoxLevel_MouseLeave(object sender, EventArgs e)
        {
            mouseEnter = false;
            panelLevelZoom.Visible = false;
            pictureBoxLevel.Invalidate();
        }
        private void pictureBoxLevel_Paint(object sender, PaintEventArgs e)
        {
            RectangleF clone = e.ClipRectangle;
            SizeF remainder = new SizeF((int)(clone.Width % zoom), (int)(clone.Height % zoom));
            clone.Location = new PointF((int)(clone.X / zoom), (int)(clone.Y / zoom));
            clone.Size = new SizeF((int)(clone.Width / zoom), (int)(clone.Height / zoom));
            clone.Width += (int)(remainder.Width * zoom) + 1;
            clone.Height += (int)(remainder.Height * zoom) + 1;
            RectangleF source, dest;

            // old
            float[][] matrixItems ={ 
               new float[] {1, 0, 0, 0, 0},
               new float[] {0, 1, 0, 0, 0},
               new float[] {0, 0, 1, 0, 0},
               new float[] {0, 0, 0, (float)overlayOpacity.Value / 100, 0}, 
               new float[] {0, 0, 0, 0, 1}};
            ColorMatrix cm = new ColorMatrix(matrixItems);
            ImageAttributes ia = new ImageAttributes();
            if (overlayOpacity.Value < 100)
                ia.SetColorMatrix(cm, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

            Rectangle rdst = new Rectangle(0, 0, zoom * 1024, zoom * 1024);

            e.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;

            if (levelImage != null)
            {
                clone.Width = Math.Min(levelImage.Width, clone.X + clone.Width) - clone.X;
                clone.Height = Math.Min(levelImage.Height, clone.Y + clone.Height) - clone.Y;

                source = clone; source.Location = new PointF(0, 0);
                dest = new RectangleF((int)(clone.X * zoom), (int)(clone.Y * zoom), (int)(clone.Width * zoom), (int)(clone.Height * zoom));

                e.Graphics.DrawImage(levelImage.Clone(clone, PixelFormat.DontCare), dest, source, GraphicsUnit.Pixel);
            }

            if (state.Move)
                MakeEditMove(e.Graphics);

            if (state.Priority1)
            {
                cm.Matrix33 = 0.50F;
                ia.SetColorMatrix(cm, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

                if (priority1Tint == null)
                    priority1Tint = new Bitmap(Drawing.PixelArrayToImage(tileMap.GetPriority1Pixels(), 1024, 1024));

                e.Graphics.DrawImage(priority1Tint, rdst, 0, 0, 1024, 1024, GraphicsUnit.Pixel, ia);
            }

            if (state.PhysicalLayer)
            {
                if (physicalMap.PhysicalMapImage == null)
                    physicalMap.DrawPhysicalMap();
                if (overlayOpacity.Value < 100)
                    e.Graphics.DrawImage(physicalMap.PhysicalMapImage, rdst, 0, 0, 1024, 1024, GraphicsUnit.Pixel, ia);
                else
                    e.Graphics.DrawImage(physicalMap.PhysicalMapImage, rdst, 0, 0, 1024, 1024, GraphicsUnit.Pixel);
            }

            if (state.Exits)
            {
                if (overlay.ExitsImage == null)
                    overlay.DrawLevelExits(exits);
                if (overlayOpacity.Value < 100)
                    e.Graphics.DrawImage(overlay.ExitsImage, rdst, 0, 0, 1024, 1024, GraphicsUnit.Pixel, ia);
                else
                    e.Graphics.DrawImage(overlay.ExitsImage, rdst, 0, 0, 1024, 1024, GraphicsUnit.Pixel);
            }
            if (state.Events)
            {
                if (overlay.EventsImage == null)
                    overlay.DrawLevelEvents(events);
                if (overlayOpacity.Value < 100)
                    e.Graphics.DrawImage(overlay.EventsImage, rdst, 0, 0, 1024, 1024, GraphicsUnit.Pixel, ia);
                else
                    e.Graphics.DrawImage(overlay.EventsImage, rdst, 0, 0, 1024, 1024, GraphicsUnit.Pixel);
            }

            if (state.Objects)
            {
                if (overlay.NPCsImage == null)
                    overlay.DrawLevelNPCs(npcs, npcProperties);
                if (overlayOpacity.Value < 100)
                    e.Graphics.DrawImage(overlay.NPCsImage, rdst, 0, 0, 1024, 1024, GraphicsUnit.Pixel, ia);
                else
                    e.Graphics.DrawImage(overlay.NPCsImage, rdst, 0, 0, 1024, 1024, GraphicsUnit.Pixel);
            }

            if (state.Overlaps)
            {
                if (overlay.OverlapsImage == null)
                    overlay.DrawLevelOverlaps(overlaps, overlapTileset);
                if (overlayOpacity.Value < 100)
                    e.Graphics.DrawImage(overlay.OverlapsImage, rdst, 0, 0, 1024, 1024, GraphicsUnit.Pixel, ia);
                else
                    e.Graphics.DrawImage(overlay.OverlapsImage, rdst, 0, 0, 1024, 1024, GraphicsUnit.Pixel);
            }

            if (!state.Dropper && mouseEnter)
                MakeHoverBox(e.Graphics);

            if (state.CartesianGrid)
                overlay.DrawCartographicGrid(e.Graphics, Color.Gray, pictureBoxLevel.Size, new Size(16, 16), zoom);

            if (state.OrthographicGrid)
                overlay.DrawOrthographicGrid(e.Graphics, Color.Gray, pictureBoxLevel.Size, new Size(16, 16), zoom);

            if (state.Mask)
                overlay.DrawLevelMask(e.Graphics, new Point(layer.MaskHighX, layer.MaskHighY), new Point(layer.MaskLowX, layer.MaskLowY), zoom);

            if (state.Select)
            {
                if (!state.PhysicalLayer)
                    overlay.DrawSelectionBox(e.Graphics, new Point(overlay.DragStop.X, overlay.DragStop.Y), new Point(overlay.DragStart.X + 1, overlay.DragStart.Y + 1), zoom);
                else
                    overlay.DrawOrthographicSelection(e.Graphics, overlay.PhysTilePoint, new Size(32, 784), zoom);
            }
        }
        private void pictureBoxLevel_LostFocus(object sender, EventArgs e)
        {
            //clearSelectionToolStripMenuItem_Click(null, null);
        }
        private void panelLevelPicture_Scroll(object sender, ScrollEventArgs e)
        {
            pictureBoxLevel.Invalidate();
        }
        private void pictureBoxLevelZoom_Paint(object sender, PaintEventArgs e)
        {
            if (levelImage != null)
            {
                int z = 4;
                RectangleF source, dest, clone;
                source = new RectangleF(0, 0, 32, 32);
                dest = new RectangleF(0, 0, 32 * z, 32 * z);
                clone = new RectangleF(
                    Math.Min(992, Math.Max(0, (mousePos.X / zoom) - 16)),
                    Math.Min(992, Math.Max(0, (mousePos.Y / zoom) - 16)), 32, 32);

                e.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;
                e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;

                e.Graphics.DrawImage(new Bitmap(levelImage.Clone(clone, PixelFormat.DontCare)), dest, source, GraphicsUnit.Pixel);

                if (state.CartesianGrid)
                {
                    Pen p = new Pen(new SolidBrush(Color.Gray));
                    Point h = new Point(0, (int)(z * 16 - (z * (clone.Y % 16))));
                    Point v = new Point((int)(z * 16 - (z * (clone.X % 16))), 0);
                    for (; h.Y < 128; h.Y += z * 16)
                        e.Graphics.DrawLine(p, h, new Point(h.X + 128, h.Y));
                    for (; v.X < 128; v.X += z * 16)
                        e.Graphics.DrawLine(p, v, new Point(v.X, v.Y + 128));
                }
                if (state.OrthographicGrid)
                {
                    Pen p = new Pen(new SolidBrush(Color.Gray));
                    Point n = new Point();

                    n.Y = (int)(z * 16 - (8 * z) - (z * (clone.Y % 16)));
                    n.Y -= (int)(2 * (clone.X % 32));
                    for (; n.Y < 128 * 2; n.Y += z * 16)
                        e.Graphics.DrawLine(p, n, new Point(n.Y * 2, 0));

                    n.Y = (int)(z * 16 - (8 * z) - (z * (clone.Y % 16)));
                    n.Y += (int)(2 * (clone.X % 32));
                    n.X = 128;
                    for (; n.Y < 128 * 2; n.Y += z * 16)
                        e.Graphics.DrawLine(p, n, new Point(128 - (n.Y * 2), 0));
                }

                Rectangle cursorBounds;
                if (Cursor.Current != Cursors.Arrow && Cursor.Current != Cursors.Cross)
                    cursorBounds = new Rectangle(16 * z, z, 16 * z, 16 * z);
                else
                    cursorBounds = new Rectangle(6 * z, 6 * z, 32 * z, 32 * z);
                if (Cursor.Current != null)
                    Cursor.Current.DrawStretched(e.Graphics, cursorBounds);
            }
        }

        // dragging panels
        private void panelBattlefields_MouseMove(object sender, MouseEventArgs e)
        {
            if (movingPanelBattlefieldTileset)
            {
                panelBattlefieldTileset.Left = e.X - mousePos.X - 2;
                panelBattlefieldTileset.Top = e.Y - mousePos.Y - 2;
                pictureBoxBattlefield.Invalidate();
            }
        }
        private void panelBattlefields_MouseUp(object sender, MouseEventArgs e)
        {
            movingPanelBattlefieldTileset = false;
        }
        private void labelTilesets_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            panelTilesets.BringToFront();
            panelTilesetsMax = !panelTilesetsMax;

            if (!panelTilesetsMax)
            {
                label67.Visible = true;
                panelTilesets.Size = new Size(270, panel1.Height - 3);
                panelTilesets.Location = new Point(panel1.Width - panelTilesets.Width - 1, 1);
                panelTilesets.Anchor = (AnchorStyles)(AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right);
            }
            else
            {
                Size s = panel1.Size;
                label67.Visible = false;
                panelTilesets.Location = new Point(1, 1);
                panelTilesets.Size = new Size(s.Width - 2, s.Height - 3);
                panelTilesets.Anchor = (AnchorStyles)(AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
            }
        }
        private void labelBattlefieldTileset_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            panelBattlefieldTileset.BringToFront();
            panelBattlefieldTilesetMax = !panelBattlefieldTilesetMax;

            if (!panelBattlefieldTilesetMax)
            {
                panelBattlefieldTileset.Location = new Point(-2, 36);
                panelBattlefieldTileset.Size = new Size(260, panelBattlefields.Height - 385);
                panelBattlefieldTileset.Anchor = (AnchorStyles)(AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left);
            }
            else
            {
                Size s = panelBattlefields.Size;
                panelBattlefieldTileset.Location = new Point(-2, -2);
                panelBattlefieldTileset.Size = new Size(s.Width + 4, s.Height + 4);
                panelBattlefieldTileset.Anchor = (AnchorStyles)(AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
            }
        }
        private void labelBattlefieldTileset_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Clicks > 1)
                return;

            //movingPanelMoldImage = false;
            //resizingPanelMoldImage = false;

            mousePos.X = e.X;
            mousePos.Y = e.Y;

            panelBattlefieldTileset.BringToFront();
            movingPanelBattlefieldTileset = true;

            panelBattlefields.Capture = true;
        }
        private void labelBattlefieldTileset_MouseUp(object sender, MouseEventArgs e)
        {
            movingPanelBattlefieldTileset = false;
        }
        private void panelBattlefieldTileset_MouseDown(object sender, MouseEventArgs e)
        {
            //movingPanelMoldImage = false;
            //resizingPanelMoldImage = false;

            resizingPanelBattlefieldTileset = true;
            SizeRight = SizeBottom = SizeBottomRight = false;

            Size s = panelBattlefieldTileset.Size;

            if (e.X > s.Width - 4 && e.Y > s.Height - 4)
                SizeBottomRight = true;
            else if (e.X > s.Width - 4)
                SizeRight = true;
            else if (e.Y > s.Height - 4)
                SizeBottom = true;
            else
            {
                resizingPanelBattlefieldTileset = false;
                return;
            }

            panelBattlefieldTileset.BringToFront();
        }
        private void panelBattlefieldTileset_MouseMove(object sender, MouseEventArgs e)
        {
            //if (resizingPanelBattlefieldTileset) return;

            Point newMousePosition = new Point(e.X, e.Y);
            if (e.Button == MouseButtons.Left && resizingPanelBattlefieldTileset)
            {
                int deltaX = newMousePosition.X - oldMousePosition.X;
                int deltaY = newMousePosition.Y - oldMousePosition.Y;

                // resize bottom
                if (SizeBottom || SizeBottomRight)
                    panelBattlefieldTileset.Height += deltaY;
                // resize right
                if (SizeRight || SizeBottomRight)
                    panelBattlefieldTileset.Width += deltaX;

                pictureBoxBattlefield.Invalidate();
            }
            else
                resizingPanelBattlefieldTileset = false;

            oldMousePosition = newMousePosition;

            if (resizingPanelBattlefieldTileset)
                return;

            Size s = panelBattlefieldTileset.Size;

            if (e.X > s.Width - 4 && e.Y > s.Height - 4)
                panelBattlefieldTileset.Cursor = Cursors.SizeNWSE;
            else if (e.X > s.Width - 4 && e.Y < 4)
                panelBattlefieldTileset.Cursor = Cursors.SizeNESW;
            else if (e.X > s.Width - 4)
                panelBattlefieldTileset.Cursor = Cursors.SizeWE;
            else if (e.Y > s.Height - 4)
                panelBattlefieldTileset.Cursor = Cursors.SizeNS;
            else
                panelBattlefieldTileset.Cursor = Cursors.Arrow;
        }
        private void panelBattlefieldTileset_MouseLeave(object sender, EventArgs e)
        {
            panelBattlefieldTileset.Cursor = Cursors.Arrow;
            resizingPanelBattlefieldTileset = false;
            movingPanelBattlefieldTileset = false;
            SizeRight = SizeBottom = SizeBottomRight = false;
        }

        private void SpaceAnalyzerMenuItem_Click(object sender, EventArgs e)
        {
            LevelChange();

            SpaceAnalyzer sa = new SpaceAnalyzer(model);
            sa.Show();

        }

        private void Priorities_SelectedIndexChanged(object sender, EventArgs e)
        {
            panelColorBalance.Visible = false;
            panelOverlapTileset.Visible = false;
        }
        private void tabControl2_SelectedIndexChanged(object sender, EventArgs e)
        {
            panelColorBalance.Visible = false;

            if (tabControl2.SelectedIndex < 3)
            {
                tileSet.RedrawTilesets(tabControl2.SelectedIndex);
                try
                {
                    tileSetPixels = tileSet.GetTilesetPixelArray(tileSet.TileSetLayers[tabControl2.SelectedIndex], tabControl2.SelectedIndex);
                    if (tileSetPixels != null)
                        tileSetImage = new Bitmap(Drawing.PixelArrayToImage(tileSetPixels, 256, 512));
                }
                catch (Exception ex)
                {
                    /* no layer 3 */
                    tileSetImage = null;
                }
            }
            else if (tabControl2.SelectedIndex == 3)
                UpdatePhysicalTile();
            else if (tabControl2.SelectedIndex == 4)
                RefreshBattlefield();

            overlay.bfield = false;
            overlay.bdlg = false;
            switch (tabControl2.SelectedIndex)
            {
                case 0: break;
                case 1: break;
                case 2: break;
                case 4:
                    overlay.bfield = true;
                    overlay.bdlg = false;
                    pictureBoxBattlefield.BackColor = Color.FromArgb(paletteSetBF.GetBGColorBF());
                    break;
                default:
                    break;
            }

            if (tabControl2.SelectedIndex < 3)
                this.label26.Text = "EDITING: LAYER " + (tabControl2.SelectedIndex + 1).ToString();
            else if (tabControl2.SelectedIndex == 4)
                this.label26.Text = "EDITING: BATTLEFIELD";
            else this.label26.Text = "EDITING: {NONE}";

            InitializeTileEditor();
        }
        private void tabControl2_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPageIndex == 2 && levelMap.GraphicSetL3 == 0xFF)
                e.Cancel = true;
            if (state.PhysicalLayer && e.TabPageIndex != 3)
                e.Cancel = true;
        }

        // level name editor
        private void changeLevelName_Click(object sender, EventArgs e)
        {
            panelChangeLevelName.Visible = !panelChangeLevelName.Visible;
            if (panelChangeLevelName.Visible)
            {
                textBox1.Focus();
                textBox1.Text = settings.LevelNames[currentLevel];
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            settings.LevelNames[currentLevel] = this.textBox1.Text;
            State.Instance.Universal.RefreshLevelName(currentLevel);
            RefreshLevelName();
        }
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
                panelChangeLevelName.Visible = false;
        }
        private void textBox1_Leave(object sender, EventArgs e)
        {
            //settings.Save();
        }
        private void defaultName_Click(object sender, EventArgs e)
        {
            textBox1.Text = settings.LevelNamesDefault[currentLevel];
        }
        private void panelChangeLevelName_VisibleChanged(object sender, EventArgs e)
        {
            searchLevelNames.Enabled = !panelChangeLevelName.Visible;
        }

        // level name search
        private void searchLevelNames_Click(object sender, EventArgs e)
        {
            panelSearchLevelNames.Visible = !panelSearchLevelNames.Visible;
            if (panelSearchLevelNames.Visible)
                nameTextBox.Focus();
        }
        private void searchButton_Click(object sender, EventArgs e)
        {
            LoadSearch();
        }
        private void listBoxLevelNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                levelName.SelectedItem = listBoxLevelNames.SelectedItem;
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was a problem loading the search item. Try doing another search.", "LAZY SHELL");
            }
        }
        private void nameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
                panelSearchLevelNames.Visible = false;
        }
        private void nameTextBox_TextChanged(object sender, EventArgs e)
        {
            LoadSearch();
        }
        private void listBoxLevelNames_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
                panelSearchLevelNames.Visible = false;
        }
        private void searchButton_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
                panelSearchLevelNames.Visible = false;
        }
        private void panelSearchLevelNames_VisibleChanged(object sender, EventArgs e)
        {
            changeLevelName.Enabled = !panelSearchLevelNames.Visible;
        }

        // Draw border
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Tileset aTileset;
            PaletteSet aPaletteSet;
            foreach (LevelMap lm in levelMaps)
            {
                if (backgroundWorker1.CancellationPending) break;
                aPaletteSet = paletteSets[lm.PaletteSet];
                aTileset = new Tileset(lm, aPaletteSet, model);
                for (int l = 0; l < 2; l++) // for each layer in the tilesets
                {
                    if (backgroundWorker1.CancellationPending) break;
                    for (int b = 0; b < 32; b++)    // for each row of 16 16x16 tiles in the tileset
                    {
                        for (int a = 0; a < 16; a++)    // for each 16x16 in a row in the tileset
                        {
                            for (int c = 0; c < 4; c++) // for each subtile
                            {
                                // first create the Tile8x8
                                Tile8x8 temp = aTileset.TileSetLayers[l][b * 16 + a].GetSubtile(c);
                                // in case mirrored or inverted, must use original unmodded tile
                                int tileOffset = (temp.TileNum * 0x20) + (temp.GfxSetIndex * 0x2000);
                                if (tileOffset > aTileset.GraphicSets.Length) tileOffset = 0;
                                Tile8x8 tile = new Tile8x8(
                                    temp.TileNum, aTileset.GraphicSets, tileOffset,
                                    aPaletteSet.Get4bppPalette(temp.PaletteSetIndex - 1),
                                    temp.Mirrored, temp.Inverted, false, false);
                                tile.PaletteSetIndex = temp.PaletteSetIndex;
                                if (tile.Mirrored || tile.Inverted) continue;

                                // next find the darkest color in the palette
                                int darkestAverage = 248;
                                int darkestColor = 0;
                                for (int i = 0; i < 16; i++)
                                {
                                    int index = tile.PaletteSetIndex - 1;
                                    if (index < 0) index = 0;
                                    int average =
                                        (aPaletteSet.PaletteColorRed[(index * 16) + i] +
                                        aPaletteSet.PaletteColorGreen[(index * 16) + i] +
                                        aPaletteSet.PaletteColorBlue[(index * 16) + i]) / 3;
                                    if (average < darkestAverage && average != 0)
                                    {
                                        darkestColor = i;
                                        darkestAverage = average;
                                    }
                                }
                                // next draw the border around the tile
                                for (int i = 0; i < 64; i++)
                                {
                                    // if pixel is empty, don't attempt to draw a border
                                    if (tile.Pixels[i] == 0) continue;
                                    // if not first or last in row, check previous and next pixel in row
                                    if ((i % 8) > 0 && (i % 8) < 7 && tile.Colors[i - 1] == 0)
                                    {
                                        tile.Colors[i] = darkestColor;   // the inner border
                                        tile.Colors[i + 1] = darkestColor;   // the outer border
                                    }
                                    if ((i % 8) < 7 && (i % 8) > 0 && tile.Colors[i + 1] == 0)
                                    {
                                        tile.Colors[i] = darkestColor;
                                        tile.Colors[i - 1] = darkestColor;   // the outer border
                                    }
                                    // if not first or last in column, check previous and next pixel in column
                                    if (i > 7 && i < 56 && tile.Colors[i - 8] == 0)
                                    {
                                        tile.Colors[i] = darkestColor;
                                        tile.Colors[i + 8] = darkestColor;   // the outer border
                                    }
                                    if (i < 56 && i > 7 && tile.Colors[i + 8] == 0)
                                    {
                                        tile.Colors[i] = darkestColor;
                                        tile.Colors[i - 8] = darkestColor;   // the outer border
                                    }
                                }
                                // finally, draw the Tile8x8 back to the 4bpp array
                                byte[] array = aTileset.GraphicSets;
                                for (int y = 0; y < 8; y++)
                                {
                                    for (int x = 0; x < 8; x++)
                                    {
                                        int offset = tileOffset + (y * 2);
                                        int color = tile.Colors[y * 8 + x];
                                        byte bit = (byte)(x ^ 7);
                                        BitManager.SetBit(array, offset, bit, (color & 1) == 1);
                                        BitManager.SetBit(array, offset + 1, bit, (color & 2) == 2);
                                        BitManager.SetBit(array, offset + 16, bit, (color & 4) == 4);
                                        BitManager.SetBit(array, offset + 17, bit, (color & 8) == 8);
                                    }
                                }
                            }
                        }
                    }
                }
                // finally, store the fused graphicSets into the model.GraphicSets
                Buffer.BlockCopy(aTileset.GraphicSets, 0, model.GraphicSets[lm.GraphicSetA + 0x48], 0, 0x2000);
                Buffer.BlockCopy(aTileset.GraphicSets, 0x2000, model.GraphicSets[lm.GraphicSetB + 0x48], 0, 0x1000);
                Buffer.BlockCopy(aTileset.GraphicSets, 0x3000, model.GraphicSets[lm.GraphicSetC + 0x48], 0, 0x1000);
                Buffer.BlockCopy(aTileset.GraphicSets, 0x4000, model.GraphicSets[lm.GraphicSetD + 0x48], 0, 0x1000);
                Buffer.BlockCopy(aTileset.GraphicSets, 0x5000, model.GraphicSets[lm.GraphicSetE + 0x48], 0, 0x1000);

                backgroundWorker1.ReportProgress(lm.LevelMapNum);
            }
        }
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pBar.PerformStep("DRAWING BORDER FOR LEVEL MAP #" + e.ProgressPercentage + " OF 156");
        }
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pBar.Close();
            this.Enabled = true;

            UpdateLevel();
        }
        private void applyBorderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            pBar = new ProgressBar(this.model, model.Data, "DRAWING BORDER AROUND LEVEL MAP GRAPHICS...", 156, backgroundWorker1);
            pBar.Show();
            backgroundWorker1.RunWorkerAsync();
        }

        // levels form
        private void Levels_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyData == Keys.Escape)
            //    ResetTileReplace();
        }
        private void Levels_FormClosing(object sender, FormClosingEventArgs e)
        {
            ExportLevelImages.CancelAsync(); // if exporting images, cancel when form closed
            state.Draw = false;
            state.Erase = false;
            state.Select = false;
            state.CartesianGrid = false;
            state.OrthographicGrid = false;

            DialogResult result;

            if (model.AssembleLevels)
            {
                result = MessageBox.Show("Levels have not been saved.\n\nWould you like to save changes?", "LAZY SHELL", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                    saveLevels_Click(null, null);
                else if (result == DialogResult.No)
                    return;
                else if (result == DialogResult.Cancel)
                {
                    e.Cancel = true;
                    return;
                }
            }
            model.AssembleLevels = false;
            settings.Save();
        }
        private void Levels_FormClosed(object sender, FormClosedEventArgs e)
        {
            GC.Collect();
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
        }
        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
        }
        private void Levels_MouseMove(object sender, MouseEventArgs e)
        {
            if (movingPanelTileEditor)
            {
                panelTileEditor.Left = Math.Min(Math.Max(e.X - mousePos.X - 2, panel1.Left), panel1.Right - panelTileEditor.Width);
                panelTileEditor.Top = Math.Min(Math.Max(e.Y - mousePos.Y - 2, panel1.Top), panel1.Bottom - panelTileEditor.Height);
                pictureBoxGraphicSet.Invalidate();
            }
        }
        private void Levels_MouseUp(object sender, MouseEventArgs e)
        {
            movingPanelTileEditor = false;
        }

        #endregion
    }
}
