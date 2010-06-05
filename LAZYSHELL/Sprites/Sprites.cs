using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using LAZYSHELL.Properties;

namespace LAZYSHELL
{
    public partial class Sprites : Form
    {
        #region Variables

        private byte[] data;

        private Model model; public Model Model { get { return model; } }
        private State state;
        private SpriteModel spriteModel;
        private Settings settings;
        private Overlay overlay;

        private Bitmap
            paletteImage,
            graphicImage,
            moldImage,
            tilesetImage,
            tileImage,
            subtileImage,
            sequenceImage,
            frameImage;
        private int[]
            palettePixels,
            graphicPixels,
            moldPixels,
            tilesetPixels,
            tilePixels,
            subtilePixels,
            framePixels;

        private int drawBufWidth = 1;
        private int[] drawBuf = new int[] { 0 };

        private string mouseOverControl;

        private bool waitBothCoords = false;
        private bool waitForChange = false;

        // moving panels
        private bool SizeRight, SizeBottom, SizeBottomRight;
        private Point oldMousePosition = new Point();
        private Point mousePos = new Point();
        private bool movingPanelImageGraphics;
        private bool movingPanelMoldImage;
        private bool resizingPanelImageGraphics;
        private bool resizingPanelMoldImage;
        private bool panelImageGraphicsMax;
        private bool panelMoldImageMax;

        private bool movingPanelSearchDialogue;
        private bool resizingPanelSearchDialogue;
        private bool panelSearchDialogueMax;

        private bool movingPanelEffectGraphics;
        private bool resizingPanelEffectGraphics;
        private bool panelEffectGraphicsMax;

        // for accessing controls from outside of Sprites
        public NumericUpDown SpriteNum { get { return spriteNum; } set { spriteNum = value; } }
        public NumericUpDown EffectNum { get { return effectNum; } set { effectNum = value; } }
        public NumericUpDown DialogueNum { get { return dialogueNum; } set { dialogueNum = value; } }
        public TabControl TabControl1 { get { return tabControl1; } set { tabControl1 = value; } }

        private ClearElements clearElements;
        private ImportExportElements ioElements;

        private ProgressBar progressBar;

        #endregion

        public Sprites(Model model)
        {
            this.model = model;
            this.data = model.Data;
            this.state = State.Instance;
            this.settings = Settings.Default;
            this.universal = state.Universal;

            settings.Keystrokes[0x20] = "\x20";
            settings.KeystrokesMenu[0x20] = "\x20";
            settings.KeystrokesDesc[0x20] = "\x20";

            model.CreateSpritesModel();

            this.spriteModel = model.SpriteModel;

            this.overlay = new Overlay();

            InitializeComponent();

            foreach (Control c in this.Controls)
            {
                c.MouseMove += new MouseEventHandler(controlMouseMove);
                SetEventHandlers(c);
            }
            SetToolTips();

            InitializeSpritesEditor();
            InitializeFontEditor();
            InitializeDialogueTilesetEditor();
            InitializeDialogueEditor();
            InitializeBattleDialogueEditor();
            InitializeMapPointEditor();
            InitializeWorldMapEditor();
            InitializeTitleEditor();
            InitializeEffectsEditor();

            coleditSelectCommand.SelectedIndex = 0;
            colEditReds.Checked = true;
            colEditGreens.Checked = true;
            colEditBlues.Checked = true;
        }

        #region Methods

        // tooltips
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
            // Sprites
            this.toolTip1.SetToolTip(this.spriteName,
                "Select the sprite to edit by name. The name is based on a \n" +
                "label assigned by the editor.");

            this.toolTip1.SetToolTip(this.spriteNum,
                "Select the sprite to edit by #. The number is in \n" +
                "hexadecimal.");

            this.toolTip1.SetToolTip(this.graphicPalettePacket,
                "The image # of the currently selected sprite refers to the \n" +
                "set of properties that designate the raw graphics and \n" +
                "palette set to use.\n\n" +
                "Anything in the \"IMAGE PALETTE...\" and \"IMAGE \n" +
                "GRAPHICS...\" panels are part of the sprite's image.");

            this.toolTip1.SetToolTip(this.graphicPalettePacketShift,
                "The index of the palette in the palette set the sprite uses. \n" +
                "This is mostly used for individual sprites that use the same \n" +
                "image (thus, the same palette set) but have a different \n" +
                "individual palette, such as the Sky Troopa and Malakoopa.");

            this.toolTip1.SetToolTip(this.paletteOffset,
                "The palette # the sprite's image's palette set begins at.");

            this.toolTip1.SetToolTip(this.pictureBoxPalette,
                "Click a color to edit it's color values below.");

            this.toolTip1.SetToolTip(this.mapPaletteRedNum,
                "The amount of red in the currently selected color.");
            this.toolTip1.SetToolTip(this.mapPaletteRedBar, toolTip1.GetToolTip(mapPaletteRedNum));

            this.toolTip1.SetToolTip(this.mapPaletteGreenNum,
                "The amount of green in the currently selected color.");
            this.toolTip1.SetToolTip(this.mapPaletteGreenBar, toolTip1.GetToolTip(mapPaletteGreenNum));

            this.toolTip1.SetToolTip(this.mapPaletteBlueNum,
                "The amount of blue in the currently selected color.");
            this.toolTip1.SetToolTip(this.mapPaletteBlueBar, toolTip1.GetToolTip(mapPaletteBlueNum));

            this.toolTip1.SetToolTip(this.graphicOffset,
                "The offset in the ROM (in hexadecimal) that the sprite's \n" +
                "image's raw graphics begin. Increments by 0x20 because \n" +
                "4bpp 8x8 tiles are 0x20 bytes each.");

            this.toolTip1.SetToolTip(this.animationPacket,
                "The animation # of the currently selected sprite refers to \n" +
                "the set of properties that designate the sequences and \n" +
                "molds to assign to the sprite.\n\n" +
                "Anything in the \"ANIMATION SEQUENCES...\" and \n" +
                "\"ANIMATION MOLDS...\" are part of the sprite's animation.");

            this.toolTip1.SetToolTip(this.animationVRAM,
                "Larger VRAM values will allow more space for the sprite's \n" +
                "raw graphics to be stored. Generally, the larger sprites \n" +
                "such as Culex use larger values.");

            this.toolTip1.SetToolTip(this.sequences,
                "The collection of sequences used by the sprite's animation.\n\n" +
                "A sequence is a collection of frames, where each frame is \n" +
                "assigned a mold from the selection of molds under \"MOLDS\" \n" +
                "and a duration, creating an animation that can be played \n" +
                "back in the image to the right.");

            this.toolTip1.SetToolTip(this.insertSequence,
                "Insert a new sequence after the currently selected \n" +
                "sequence.");

            this.toolTip1.SetToolTip(this.deleteSequence,
                "Delete the currently selected sequence.");

            this.toolTip1.SetToolTip(this.sequenceFrames,
                "The collection of frames used by the currently selected \n" +
                "sequence at the left. Each frame is assigned a mold from \n" +
                "the selection of molds under \"MOLDS\" and a duration, \n" +
                "creating an animation that can be played back in the image \n" +
                "to the right.");

            this.toolTip1.SetToolTip(this.insertFrame,
                "Insert a new frame after the currently selected frame.");

            this.toolTip1.SetToolTip(this.deleteFrame,
                "Delete the currently selected frame.");

            this.toolTip1.SetToolTip(this.frameMold,
                "The mold used by the currently selected frame. This value \n" +
                "is based on the collection of molds under \"MOLDS\".");

            this.toolTip1.SetToolTip(this.frameDuration,
                "The duration of the currently selected frame, or how long \n" +
                "the frame will pause before the next frame starts. This \n" +
                "value refers to the # of frames based on a 60-frames-per-\n" +
                "second unit.");

            this.toolTip1.SetToolTip(this.frameMoveUp,
                "Move the currently selected frame up.");

            this.toolTip1.SetToolTip(this.frameMoveDown,
                "Move the currently selected frame down.");

            this.toolTip1.SetToolTip(this.molds,
                "The collection of molds used by the sprite's animation. A \n" +
                "mold is a set of tiles arranged either dynamically or in a \n" +
                "predefined grid to create a complete image that can be \n" +
                "used by an animation sequence.");

            this.toolTip1.SetToolTip(this.insertMold,
                "Insert a new mold after the currently selected mold.");

            this.toolTip1.SetToolTip(this.deleteMold,
                "Delete the currently selected mold.");

            this.toolTip1.SetToolTip(this.moldFormat,
                "The format of the currently selected mold refers to how the \n" +
                "mold will be drawn.\n\n" +
                "\"Gridplane\" will create a predefined grid of 8x8 tiles (its size \n" +
                "is determined in the \"Format\" value under \"TILE \n" +
                "PROPERTIES\"). It is recommended to select this format if \n" +
                "the mold is to be less than 32x32 pixels and more than \n" +
                "24x24 pixels.\n\n" +
                "\"Tilemap\" will create a dynamic collection of 16x16 tiles \n" +
                "where each 16x16 tile has an absolute coordinate on the \n" +
                "screen. The 4 subtiles in the 16x16 tile can be set, 16x16 \n" +
                "tiles can be added / removed under the \"MOLD TILES\" \n" +
                "panel, and more.");

            this.toolTip1.SetToolTip(this.pictureBoxMoldTileset,
                "If the \"Format\" is set to \"Tilemap\", this is the set of 16x16 \n" +
                "tiles in the mold. Select the tile to edit by clicking it.\n\n" +
                "The offset that appears when the mouse is over this image \n" +
                "is the offset of the tile. Use this value when making \n" +
                "\"Copies\" of this tile or any tiles after it.");

            this.toolTip1.SetToolTip(this.insertTile,
                "Insert a new 16x16 tile after the currently selected tile.");

            this.toolTip1.SetToolTip(this.deleteTile,
                "Delete the currently selected tile.");

            this.toolTip1.SetToolTip(this.moldTileSize,
                "If the mold's format is \"Gridplane\" this refers to the size in \n" +
                "pixels of the mold.\n\n" +
                "If the mold's format is \"Tilemap\":\n" +
                "Normal means its a default 16x16 tile with 8-bit subtiles.\n" +
                "16-bit means that subtile #'s (in the \"SUBTILES...\" panel) \n" +
                "above 255 can be used.\n" +
                "Copy means that the tile is a copy of a collection of tiles \n" +
                "from either this or another (usually another) mold. No tiles \n" +
                "in \"Mold 0\" should be set to this, unless copying tiles that \n" +
                "have already been set.");

            this.toolTip1.SetToolTip(this.quadrantNW,
                "The northwest quadrant of the 16x16 tile is visible.\n" +
                "Only used by \"Tilemap\" format.");

            this.toolTip1.SetToolTip(this.quadrantNE,
                "The northeast quadrant of the 16x16 tile is visible.\n" +
                "Only used by \"Tilemap\" format.");

            this.toolTip1.SetToolTip(this.quadrantSW,
                "The southwest quadrant of the 16x16 tile is visible.\n" +
                "Only used by \"Tilemap\" format.");

            this.toolTip1.SetToolTip(this.quadrantSE,
                "The southeast quadrant of the 16x16 tile is visible.\n" +
                "Only used by \"Tilemap\" format.");

            this.toolTip1.SetToolTip(this.moldTileProp,
                "\"Mirror\" will mirror the 16x16 tile (for \"Tilemap\" format only) \n" +
                "or mold (for \"Gridplane\" format only).\n\n" +
                "\"Invert\" will invert the 16x16 tile (for \"Tilemap\" format only) \n" +
                "or mold (for \"Gridplane\" format only).\n\n" +
                "\"Y++\" (\"Gridplane\" format only) will increase the Y coord by \n" +
                "1 pixel.\n\n" +
                "\"Y--\" (\"Gridplane\" format only) will decrease the Y coord by \n" +
                "1 pixel.");

            this.toolTip1.SetToolTip(this.moldTileXCoord,
                "The absolute X coordinate of the 16x16 tile.\n" +
                "Only used by \"Tilemap\" format.");

            this.toolTip1.SetToolTip(this.moldTileYCoord,
                "The absolute Y coordinate of the 16x16 tile.\n" +
                "Only used by \"Tilemap\" format.");

            this.toolTip1.SetToolTip(this.moldTileCopies,
                "The number of tiles to use in the copy, if the tile's format is \n" +
                "set to \"Copy\". This value refers to how many 16x16 tiles \n" +
                "will be copied starting from the \"Offset\".\n" +
                "Only used by \"Tilemap\" format.");

            this.toolTip1.SetToolTip(this.moldTileCopiesOffset,
                "The starting offset of the 16x16 tile to be copied.\n\n" +
                "For example, in Cloaker's \"Mold 1\" the first tile is a copy \n" +
                "who's offset is 0x0083. In \"Mold 0\" the tile that has an \n" +
                "offset of 0x0083 is the first tile, thus the copy in \"Mold 1\" \n" +
                "will copy the tiles starting at that 1st tile in \"Mold 0\". 4 tiles \n" +
                "will be copied (since 4 is the value for \"Copies\"). The first \n" +
                "tile in \"Mold 1\" is a copy of Cloaker's shield.\n\n" +
                "Only used by \"Tilemap\" format.");

            this.toolTip1.SetToolTip(this.pictureBoxSubtile,
                "The 8x8 subtiles in the mold (for \"Gridplane\" format) or \n" +
                "16x16 tile (for \"Tilemap\" format). Click the image to select \n" +
                "the subtile to edit.");

            this.toolTip1.SetToolTip(this.moldSubtile,
                "The subtile # assigned to the subtile. This value refers to \n" +
                "the 8x8 tile index in the raw graphics (under \"IMAGE \n" +
                "GRAPHICS...\"). The index of the tile in the raw graphics \n" +
                "can be seen by moving the mouse over it and reading the # \n" +
                "displayed in the label in the upper-right in the \"IMAGE \n" +
                "GRAPHICS...\" panel.");


            // Dialogues

            this.toolTip1.SetToolTip(this.dialogueNum,
                "Select the dialogue to edit.\n\n" +
                "Dialogues must be triggered by an event script command to \n" +
                "show. Generally, most dialogues are \"assigned\" to an NPC, \n" +
                "ie. the NPC has an event # assigned to it, wherein there is \n" +
                "a command to display a specific dialogue # in that event \n" +
                "script. The first few dialogues are by default used as the \n" +
                "message / caption that is shown at the top of some levels. \n\n" +
                "To find a dialogue, use the \"SEARCH DIALOGUE...\" panel \n" +
                "below.");

            this.toolTip1.SetToolTip(this.byteOrTextView,
                "Enable or disable text viewing in the dialogue textbox. This \n" +
                "is for easily identifying what the numerals in [] mean.");

            this.toolTip1.SetToolTip(this.dialogueTextBox,
                "Edit the current dialogue. Insert symbols and commands \n" +
                "using the buttons below and the list to the right.\n\n" +
                "To insert a character based on its #, just type the # \n" +
                "between []. To find out what a font character's # is, just \n" +
                "move the mouse cursor over the character in the font table \n" +
                "to the right in the \"FONT GRAPHICS\" panel.");

            this.toolTip1.SetToolTip(this.listBox1,
                "\"End string\" ([0] or [6]) will terminate the string from the \n" +
                "place it is inserted and onward. All dialogues must have \n" +
                "either a [0] or a [6] (\"End string (A)\") at the end.\n\n" +
                "\"New line\" ([1] or [2]) creates a break and start a new line.\n\n" +
                "\"New page\" ([3] or [4]) creates a break and starts a new \n" +
                "page. A page is what comprises the currently visible \n" +
                "dialogue. A page can have 3 lines maximum.\n\n" +
                "\"Pause (A)\" ([5]) will pause the dialogue until \"A\" is pressed.\n\n" +
                "\"Delay ([12])\" will pause the dialogue 60 frames (1 second).\n\n" +
                "\"Delay...\" will pause the dialogue for a number of frames, \n" +
                "specified by the user.\n\n" +
                "\"Variable...\" will display a value from memory or an item \n" +
                "name from memory.\n\n" +
                "Any command in this list with an (A) means that it will pause \n" +
                "the dialogue until the \"A\" button is pressed.");

            this.toolTip1.SetToolTip(this.battleDialogueNum,
                "Select the battle dialogue to edit by #.\n\n" +
                "Battle dialogues only appear in battles and must be \n" +
                "triggered by a battle script command to be shown.");

            this.toolTip1.SetToolTip(this.battleDialogueName,
                "Select the battle dialogue to edit by name.\n\n" +
                "Battle dialogues only appear in battles and must be \n" +
                "triggered by a battle script command to be shown.");

            this.toolTip1.SetToolTip(this.battleDialogueTextBox,
                "Edit the current battle dialogue. Insert commands using the \n" +
                "list to the right.\n\n" +
                "To insert symbols, type the character # of the symbol \n" +
                "between []. The character # can be found by moving the \n" +
                "mouse over the font character in the font table image in \n" +
                "the \"FONT GRAPHICS\" panel.");

            this.toolTip1.SetToolTip(this.listBox2,
                "\"End string\" ([0]) will terminate the string from the place it is \n" +
                "inserted and onward. Dialogues must have [0] at the end.\n\n" +
                "\"New line\" ([1]) creates a break and start a new line.\n\n" +
                "\"Pause (A)\" ([2]) will pause the dialogue until \"A\" is pressed.\n\n" +
                "\"Delay ([3] or [12])\" will pause the dialogue for 60 frames \n" +
                "(1 second).\n\n" +
                "Any command in this list with an (A) means that it will pause \n" +
                "the dialogue until the \"A\" button is pressed.");


            // Fonts

            this.toolTip1.SetToolTip(this.fontPalette,
                "Select the font palette to edit. There are two types: \n" +
                "dialogue and menu. The dialogue palette is only used in \n" +
                "overworld and battle dialogue, while the menu palette is \n" +
                "used in menus and occasionally in overworld dialogue.");

            this.toolTip1.SetToolTip(this.pictureBoxFontPalette,
                "Click a color to edit it's color values below.");

            this.toolTip1.SetToolTip(this.fontPaletteRedNum,
                "The amount of red in the currently selected color.");
            this.toolTip1.SetToolTip(this.fontPaletteRedBar, toolTip1.GetToolTip(fontPaletteRedNum));

            this.toolTip1.SetToolTip(this.fontPaletteGreenNum,
                "The amount of green in the currently selected color.");
            this.toolTip1.SetToolTip(this.fontPaletteGreenBar, toolTip1.GetToolTip(fontPaletteGreenNum));

            this.toolTip1.SetToolTip(this.fontPaletteBlueNum,
                "The amount of blue in the currently selected color.");
            this.toolTip1.SetToolTip(this.fontPaletteBlueBar, toolTip1.GetToolTip(fontPaletteBlueNum));

            this.toolTip1.SetToolTip(this.fontType,
                "Select the font type to edit.\n\n" +
                "\"Menu\" font is used in the overworld menu.\n" +
                "\"Dialogue\" font is used in overworld and battle dialogue.\n" +
                "\"Description\" font is used in item and spell descriptions in \n" +
                "the overworld menu.\n" +
                "\"Triangles\" are the option triangles used in overworld \n" +
                "dialogue (as seen in button in the dialogue editor).");

            this.toolTip1.SetToolTip(this.characterNumLabel,
                "The index of the font character. Use this number when \n" +
                "inputting the character in [] in the dialogue or battle \n" +
                "dialogue editor.");

            this.toolTip1.SetToolTip(this.fontWidth,
                "The width of the character, in pixels, as drawn in-game.");

            this.toolTip1.SetToolTip(this.pictureBoxFont,
                "Click character to edit.");

            this.toolTip1.SetToolTip(this.fontFamily,
                "Select a system-installed font to use in the new font table.");

            this.toolTip1.SetToolTip(this.fontSize,
                "Set the size of the font to use in the new font table.");

            this.toolTip1.SetToolTip(this.characterHeight,
                "Set the height of all characters in the new font table.");

            this.toolTip1.SetToolTip(this.shiftTableUp,
                "Move the new font table up 1 pixel.");

            this.toolTip1.SetToolTip(this.shiftTableDown,
                "Move the new font table down 1 pixel.");

            this.toolTip1.SetToolTip(this.shiftTableLeft,
                "Move the new font table left 1 pixel.");

            this.toolTip1.SetToolTip(this.shiftTableRight,
                "Move the new font table right 1 pixel.");

            this.toolTip1.SetToolTip(this.resetTable,
                "Reset the new font table's position.");

            this.toolTip1.SetToolTip(this.autoSetWidths,
                "The width of each character will be automatically set based \n" +
                "on a used pixel at the farthest right.");

            this.toolTip1.SetToolTip(this.padding,
                "This value will be added to the automatically set width of \n" +
                "each character in the newly created font table.");

            this.toolTip1.SetToolTip(this.generateFontTableImage,
                "Generate the font table to an image and set as the new \n" +
                "font table in the \"FONT GRAPHICS\".");


            // Dialogue tileset

            this.toolTip1.SetToolTip(this.dialogueSubtile,
                "The # of the currently selected 8x8 subtile in the currently \n" +
                "selected 16x16 tile in the battle dialogue tileset.");

            this.toolTip1.SetToolTip(this.dialogueProperties,
                "\"Priority 1\" is, by default, enabled for all 8x8 tiles in the \n" +
                "battle dialogue tileset and is not recommended to change.\n\n" +
                "\"Mirror\" mirrors the 8x8 tile.\n\n" +
                "\"Invert\" invert (ie. flips) the 8x8 tile.");

            this.toolTip1.SetToolTip(this.pictureBoxDialogueBG,
                "The raw graphics used by the dialogue background. \n" +
                "Right-click this image for importing / exporting options.");


            // World maps

            this.toolTip1.SetToolTip(this.worldMapNum,
                "Select the world map to edit. There are 8 maps total.\n\n" +
                "The map may appear disoriented in correlation with the map \n" +
                "points, because the game engine stretches the map.");

            this.toolTip1.SetToolTip(this.showMapPoints,
                "Show or hide the map points in the image below. If the map \n" +
                "points are shown, they can be clicked to edit them in the \n" +
                "\"MAP POINTS\" panel below.");

            this.toolTip1.SetToolTip(this.pictureBoxWorldMap,
                "Click a 16x16 tile in the image to edit it.");

            this.toolTip1.SetToolTip(this.pointCount,
                "The total # of map points that the current map uses. The \n" +
                "collection of map points used by the map is based on the \n" +
                "points used by the earlier maps.\n\n" +
                "Map #0, for example, by default uses 7 points total, and \n" +
                "since it is the first map that means it will use points #0 - 6 \n" +
                "(as seen in the \"MAP POINTS\" editor panel). Map #1 uses 6 \n" +
                "points, and because the last point in Map #0 is point #6, \n" +
                "then Map #1's points will be points #7 - 12 (ie. 6 total, \n" +
                "starting at #7).");

            this.toolTip1.SetToolTip(this.worldMapTileset,
                "The tileset, or the actual image used by the map.\n\n" +
                "To edit a tile in the tileset, click on the tile in the image \n" +
                "above to edit it in the \"WORLD MAP TILE EDITOR\" panel to \n" +
                "the right.");

            this.toolTip1.SetToolTip(this.worldMapXCoord,
                "The negative X coordinate shift of the map.");

            this.toolTip1.SetToolTip(this.worldMapYCoord,
                "The negative Y coordinate shift of the map.");


            // Map points

            this.toolTip1.SetToolTip(this.mapPointNum,
                "Select the map point to edit by #. If the map point is in the \n" +
                "currently selected world map, then it will be highlighted in \n" +
                "the map.");

            this.toolTip1.SetToolTip(this.mapPointName,
                "Select the map point to edit by name. If the map point is in \n" +
                "the currently selected world map, then it will be highlighted \n" +
                "in the map.");

            this.toolTip1.SetToolTip(this.textBoxMapPoint,
                "Edit the map point's name, as it appears at the bottom of \n" +
                "the screen when the Mario sprite is over the point.");

            this.toolTip1.SetToolTip(this.mapPointXCoord,
                "The absolute X coordinate of the map point.");

            this.toolTip1.SetToolTip(this.mapPointYCoord,
                "The absolute Y coordinate of the map point.");

            this.toolTip1.SetToolTip(this.showCheckAddress,
                "If the bit (under \"BIT SET\") of this memory address is set, \n" +
                "then the point is enabled / visible in-game.\n\n" +
                "Example: by default point #9 (Mushroom Way) is not \n" +
                "enabled or visible until bit 2 of memory address 00:7065 is \n" +
                "set. This bit is set at the end of event script #1396.\n\n" +
                "These bits are always set in an event script.");

            this.toolTip1.SetToolTip(this.showCheckBit,
                "If this bit of a memory address (under \"IF MEMORY\") is set, \n" +
                "then the point is enabled / visible in-game.\n\n" +
                "Example: by default point #9 (Mushroom Way) is not \n" +
                "enabled or visible until bit 2 of memory address 00:7065 is \n" +
                "set. This bit is set at the end of event script #1396.\n\n" +
                "These bits are always set in an event script.");

            this.toolTip1.SetToolTip(this.leadToMapPoint,
                "If this is enabled, the destination will be another map point \n" +
                "(typically a point in different one of the 8 maps). If not \n" +
                "enabled, then the destination will be a level #.");

            this.toolTip1.SetToolTip(this.whichPointCheckAddress,
                "If the bit (at the right) of this memory address is set, then \n" +
                "the point will lead to the first destination (next to \"lead to \n" +
                "destionation\"), otherwise it will lead to the second one.\n" +
                "This is ignored if \"MAP POINT\" is disabled.");

            this.toolTip1.SetToolTip(this.whichPointCheckBit,
                "If this bit of the memory address (at the left) is set, then \n" +
                "the point will lead to the first destination (next to \"lead to \n" +
                "destionation\"), otherwise it will lead to the second one.\n" +
                "This is ignored if \"MAP POINT\" is disabled.");

            this.toolTip1.SetToolTip(this.goMapPointA,
                "The destination the map point leads to.");

            this.toolTip1.SetToolTip(this.goMapPointB,
                "The alternate destination the map point leads to, if a \n" +
                "memory's bit is not set.\n" +
                "This is ignored if \"MAP POINT\" is disabled.");

            this.toolTip1.SetToolTip(this.enableEastPath,
                "Enable the eastern path of the map point, or the path to \n" +
                "the point the Mario sprite moves to when RIGHT is pressed \n" +
                "on the d-pad.");

            this.toolTip1.SetToolTip(this.enableSouthPath,
                "Enable the southern path of the map point, or the path to \n" +
                "the point the Mario sprite moves to when DOWN is pressed \n" +
                "on the d-pad.");

            this.toolTip1.SetToolTip(this.enableWestPath,
                "Enable the western path of the map point, or the path to \n" +
                "the point the Mario sprite moves to when LEFT is pressed \n" +
                "on the d-pad.");

            this.toolTip1.SetToolTip(this.enableNorthPath,
                "Enable the northern path of the map point, or the path to \n" +
                "the point the Mario sprite moves to when UP is pressed on \n" +
                "the d-pad.");

            this.toolTip1.SetToolTip(this.toEastPoint,
                "The map point the eastern path leads to, or the point the \n" +
                "Mario sprite moves to when RIGHT is pressed on the d-pad.");

            this.toolTip1.SetToolTip(this.toSouthPoint,
                "The map point the southern path leads to, or the point the \n" +
                "Mario sprite moves to when DOWN is pressed on the d-pad.");

            this.toolTip1.SetToolTip(this.toWestPoint,
                "The map point the western path leads to, or the point the \n" +
                "Mario sprite moves to when LEFT is pressed on the d-pad.");

            this.toolTip1.SetToolTip(this.toNorthPoint,
                "The map point the northern path leads to, or the point the \n" +
                "Mario sprite moves to when UP is pressed on the d-pad.");

            this.toolTip1.SetToolTip(this.toEastCheckAddress,
                "If the bit (at the right) of this memory address is set, then \n" +
                "the eastern path will be open.");

            this.toolTip1.SetToolTip(this.toSouthCheckAddress,
                "If the bit (at the right) of this memory address is set, then \n" +
                "the southern path will be open.");

            this.toolTip1.SetToolTip(this.toWestCheckAddress,
                "If the bit (at the right) of this memory address is set, then \n" +
                "the western path will be open.");

            this.toolTip1.SetToolTip(this.toNorthCheckAddress,
                "If the bit (at the right) of this memory address is set, then \n" +
                "the northern path will be open.");

            this.toolTip1.SetToolTip(this.toEastCheckBit,
                "If this bit of the memory address (to the left) is set, then \n" +
                "the eastern path will be open.");

            this.toolTip1.SetToolTip(this.toSouthCheckBit,
                "If this bit of the memory address (to the left) is set, then \n" +
                "the southern path will be open.");

            this.toolTip1.SetToolTip(this.toWestCheckBit,
                "If this bit of the memory address (to the left) is set, then \n" +
                "the western path will be open.");

            this.toolTip1.SetToolTip(this.toNorthCheckBit,
                "If this bit of the memory address (to the left) is set, then \n" +
                "the northern path will be open.");


            // World map tile editor

            this.toolTip1.SetToolTip(this.wmShowGrid,
                "Enable the 8x8 tile grid for the world map tile editor and \n" +
                "raw graphics.");

            this.toolTip1.SetToolTip(this.wmSubtile,
                "The # of the currently selected 8x8 subtile in the currently \n" +
                "selected 16x16 tile in the world map tileset.");

            this.toolTip1.SetToolTip(this.wmGraphicSet,
                "The \"GFX Set\" is the raw graphic set of the currently \n" +
                "selected 8x8 subtile. There are 4 total (ie. 0-3) available \n" +
                "graphic sets used by the world maps.");

            this.toolTip1.SetToolTip(this.wmSubtilePalette,
                "The \"Palette\" is the palette index in the palette set (at the \n" +
                "right) that the 8x8 subtile uses. The index corresponds to \n" +
                "the row # in the set.");

            this.toolTip1.SetToolTip(this.wmSubtileProperties,
                "\"Priority 1\" is, by default, enabled for all 8x8 tiles in the \n" +
                "battle dialogue tileset and is not recommended to change.\n\n" +
                "\"Mirror\" mirrors the 8x8 tile.\n\n" +
                "\"Invert\" invert (ie. flips) the 8x8 tile.");

            this.toolTip1.SetToolTip(this.pictureBoxWMGraphics,
                "The raw graphics used by the world map.\n" +
                "Right-click this image for importing / exporting options.");

            this.toolTip1.SetToolTip(this.pictureBoxWMPalette,
                "Click a color to edit it's color values below.");

            this.toolTip1.SetToolTip(this.wmPaletteRedNum,
                "The amount of red in the currently selected color.");
            this.toolTip1.SetToolTip(this.wmPaletteRedBar, toolTip1.GetToolTip(wmPaletteRedNum));

            this.toolTip1.SetToolTip(this.wmPaletteGreenNum,
                "The amount of green in the currently selected color.");
            this.toolTip1.SetToolTip(this.wmPaletteGreenBar, toolTip1.GetToolTip(wmPaletteGreenNum));

            this.toolTip1.SetToolTip(this.wmPaletteBlueNum,
                "The amount of blue in the currently selected color.");
            this.toolTip1.SetToolTip(this.wmPaletteBlueBar, toolTip1.GetToolTip(wmPaletteBlueNum));


            // Spell effects

            this.toolTip1.SetToolTip(this.effectNum,
                "Select the spell effect to edit by #.\n\n" +
                "A spell effect is not the entire spell animation itself, but an \n" +
                "animation sequence used in spell animations. Spell \n" +
                "animations can use more than one different spell effect, for \n" +
                "example, the \"Boulder\" spell uses spell effect 26 (boulder) \n" +
                "and 53 (black flash).");

            this.toolTip1.SetToolTip(this.effectName,
                "Select the spell effect to edit by name.\n\n" +
                "A spell effect is not the entire spell animation itself, but an \n" +
                "animation sequence used in spell animations. Spell \n" +
                "animations can use more than one different spell effect, for \n" +
                "example, the \"Boulder\" spell uses spell effect 26 (boulder) \n" +
                "and 53 (black flash).");

            this.toolTip1.SetToolTip(this.e_animation,
                "The image # of the currently selected spell effect refers to \n" +
                "the set of properties that designate the raw graphics and \n" +
                "palette set to use.\n\n" +
                "Anything in the \"IMAGE PALETTE...\", \"IMAGE \n" +
                "GRAPHICS...\" and \"IMAGE TILESET\" panels are part of the \n" +
                "spell effect's image.");

            this.toolTip1.SetToolTip(this.e_paletteIndex,
                "The index of the palette in the palette set the spell effect \n" +
                "uses. This is mostly used for individual spell effects that use \n" +
                "the same image (thus, the same palette set) but have a \n" +
                "different individual palette, such as the star rain and black \n" +
                "star rain.");

            this.toolTip1.SetToolTip(this.xNegShift,
                "The X shift is the number of pixels to shift the spell effect \n" +
                "animation to the left.");

            this.toolTip1.SetToolTip(this.yNegShift,
                "The Y shift is the number of pixels to shift the spell effect \n" +
                "animation up.");

            this.toolTip1.SetToolTip(this.e_paletteSetSize,
                "The size of the palette in bytes. The total number of \n" +
                "palettes in the spell effect image's palette set equals the \n" +
                "size divided by 32.");

            this.toolTip1.SetToolTip(this.pictureBoxE_Palette,
                "Click a color to edit it's color values below.");

            this.toolTip1.SetToolTip(this.e_paletteRedNum,
                "The amount of red in the currently selected color.");
            this.toolTip1.SetToolTip(this.e_paletteRedBar, toolTip1.GetToolTip(e_paletteRedNum));

            this.toolTip1.SetToolTip(this.e_paletteGreenNum,
                "The amount of green in the currently selected color.");
            this.toolTip1.SetToolTip(this.e_paletteGreenBar, toolTip1.GetToolTip(e_paletteGreenNum));

            this.toolTip1.SetToolTip(this.e_paletteBlueNum,
                "The amount of blue in the currently selected color.");
            this.toolTip1.SetToolTip(this.e_paletteBlueBar, toolTip1.GetToolTip(e_paletteBlueNum));

            this.toolTip1.SetToolTip(this.e_graphicSetSize,
                "The size of the raw graphics in bytes (hexadecimal). Every \n" +
                "0x20 bytes is one or two 8x8 tiles.");

            this.toolTip1.SetToolTip(this.e_codec,
                "The codec refers to how the graphics are read by the game \n" +
                "engine. 4bpp uses up to 16 colors total, while 2bpp only \n" +
                "uses 4 colors total.");

            this.toolTip1.SetToolTip(this.e_tileSetSize,
                "The size of the tileset in hexadecimal bytes. The total \n" +
                "number of tiles in the spell effect image's tileset equals the \n" +
                "size (in hexadecimal) divided by 8.");

            this.toolTip1.SetToolTip(this.e_tileSubtile,
                "The # of the currently selected 8x8 subtile in the currently \n" +
                "selected 16x16 tile in the world map tileset.");

            this.toolTip1.SetToolTip(this.e_frames,
                "The collection of frames used by the spell effect animation. \n" +
                "Each frame is assigned a mold from the selection of molds \n" +
                "under \"MOLDS\" and a duration, creating an animation that \n" +
                "can be played back in the image to the right.");

            this.toolTip1.SetToolTip(this.e_insertFrame,
                "Insert a new frame after the currently selected frame.");

            this.toolTip1.SetToolTip(this.e_deleteFrame,
                "Delete the currently selected frame.");

            this.toolTip1.SetToolTip(this.e_frameMold,
                "The mold used by the currently selected frame. This value \n" +
                "is based on the collection of molds under \"MOLDS\".");

            this.toolTip1.SetToolTip(this.e_duration,
                "The duration of the currently selected frame, or how long \n" +
                "the frame will pause before the next frame starts. This \n" +
                "value refers to the # of frames based on a 60-frames-per-\n" +
                "second unit.");

            this.toolTip1.SetToolTip(this.e_moveFrameUp,
                "Move the currently selected frame up.");

            this.toolTip1.SetToolTip(this.e_moveFrameDown,
                "Move the currently selected frame down.");

            this.toolTip1.SetToolTip(this.e_moldWidth,
                "The width of all spell effect animation molds, in 16x16 tiles.");

            this.toolTip1.SetToolTip(this.e_moldHeight,
                "The height of all spell effect animation molds, in 16x16 tiles.");

            this.toolTip1.SetToolTip(this.e_molds,
                "The collection of molds used by the spell effect's animation. \n" +
                "A spell effect animation's mold is a set of tiles arranged in a \n" +
                "sequence, from left to right and top to bottom in rows \n" +
                "(much like how text wraps to the next line in your typical \n" +
                "text editor). The number of tiles in a row is the value set \n" +
                "for the \"Width\" property above.");

            this.toolTip1.SetToolTip(this.e_insertMold,
                "Insert a new mold after the currently selected mold.");

            this.toolTip1.SetToolTip(this.e_deleteMold,
                "Delete the currently selected mold.");

            this.toolTip1.SetToolTip(this.e_moveTileUp,
                "Move the currently selected tile up.");

            this.toolTip1.SetToolTip(this.e_moveTileDown,
                "Move the currently selected tile down.");

            this.toolTip1.SetToolTip(this.e_tiles,
                "The collection of 16x16 tiles used by the currently selected \n" +
                "mold to the left. The collection of tiles is drawn in a \n" +
                "sequence, from left to right and top to bottom in rows \n" +
                "(much like how text wraps to the next line in your typical \n" +
                "text editor). The number of tiles in a row is the value set \n" +
                "for the \"Width\" property above.\n\n" +
                "The currently selected tile (or filler tile) in the image to the \n" +
                "right is outlined by a red box.");

            this.toolTip1.SetToolTip(this.moldInsertTile,
                "Insert a new tile after the currently selected tile.");

            this.toolTip1.SetToolTip(this.moldDeleteTile,
                "Delete the currently selected tile.");

            this.toolTip1.SetToolTip(this.moldTileFormat,
                "The format of the currently selected tile. It can be either \n" +
                "\"normal\" or \"filler\".\n\n" +
                "The \"filler\" format fills up a number of tiles with the same \n" +
                "tile, which is set by the \"Tile #\" (or it could be an \"EMPTY \n" +
                "TILE\"). The number of tiles to fill is set by the \"Fill amount\".");

            this.toolTip1.SetToolTip(this.moldTileIndex,
                "The currently selected tile's tile # is correlated with the tile \n" +
                "in the tileset in the \"IMAGE TILESET\" panel.");

            this.toolTip1.SetToolTip(this.moldFillAmount,
                "This refers to the number of tiles to fill for the currently \n" +
                "selected tile. The fill amount is valid only if the \"filler\" format \n" +
                "is chosen. ");

            this.toolTip1.SetToolTip(this.moldTileEmpty,
                "If enabled, the currently selected tile is empty.");

            this.toolTip1.SetToolTip(this.moldTileProp,
                "\"Mirror\" will mirror the currently selected tile.\n" +
                "\"Invert\" will invert (ie. flip) the currently selected tile.");
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

        // file management
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
                MessageBox.Show("Sorry, there was an error trying to create the directory : " + dir, "Error");
                return false;
            }
        }
        private string SelectFile(string title, string filter, int index)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = settings.LastRomPath;
            openFileDialog1.Title = title;
            openFileDialog1.Filter = filter;
            openFileDialog1.FilterIndex = index;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() != DialogResult.Cancel)
                return openFileDialog1.FileName;
            return null;
        }

        // drawing
        private int[] ImageToArray(Bitmap image, Size max)
        {
            int w = image.Width / 8 * 8;
            int h = image.Height / 8 * 8;
            int[] temp = new int[w * h];
            for (int y = 0; y < max.Height && y < h; y++)
            {
                for (int x = 0; x < max.Width && x < w; x++)
                    temp[y * w + x] = image.GetPixel(x, y).ToArgb();
            }
            return temp;
        }
        private byte[] ArrayTo4bppTile(int[] array, int w, int h, int[] palette)
        {
            byte[] temp = new byte[(w * h) * 0x20];
            Point p;
            int offset;
            byte bit;

            ArrayToSnesPalette(array, palette);

            for (int i = 0; i < w * h; i++)   // draw each 8x8 tile
            {
                for (int y = 0; y < 8; y++)
                {
                    for (int x = 0; x < 8; x++)
                    {
                        p = new Point(i % w * 8 + x, i / w * 8 + y);
                        bit = (byte)(x ^ 7);
                        offset = i * 0x20;
                        offset += y * 2;
                        BitManager.SetBit(temp, offset, bit, (array[p.Y * (w * 8) + p.X] & 1) == 1);
                        BitManager.SetBit(temp, offset + 1, bit, (array[p.Y * (w * 8) + p.X] & 2) == 2);
                        BitManager.SetBit(temp, offset + 16, bit, (array[p.Y * (w * 8) + p.X] & 4) == 4);
                        BitManager.SetBit(temp, offset + 17, bit, (array[p.Y * (w * 8) + p.X] & 8) == 8);
                    }
                }
            }
            return temp;
        }
        private byte[] ArrayTo2bppTile(int[] array, int w, int h, int[] palette)
        {
            byte[] temp = new byte[(w * h) * 0x20];
            Point p;
            int offset;
            byte bit;

            ArrayToSnesPalette(array, palette);

            for (int i = 0; i < w * h; i++)   // draw each 8x8 tile
            {
                for (int y = 0; y < 8; y++)
                {
                    for (int x = 0; x < 8; x++)
                    {
                        p = new Point(i % w * 8 + x, i / w * 8 + y);
                        bit = (byte)(x ^ 7);
                        offset = i * 0x10;
                        offset += y * 2;
                        BitManager.SetBit(temp, offset, bit, (array[p.Y * (w * 8) + p.X] & 1) == 1);
                        BitManager.SetBit(temp, offset + 1, bit, (array[p.Y * (w * 8) + p.X] & 2) == 2);
                    }
                }
            }
            return temp;
        }
        private void ArrayToSnesPalette(int[] array, int[] palette)
        {
            Color[] colors = new Color[palette.Length];

            double distance = 500.0;
            double temp;

            double r, g, b;
            double dbl_test_red;
            double dbl_test_green;
            double dbl_test_blue;

            for (int i = 0; i < palette.Length; i++)
                colors[i] = Color.FromArgb(palette[i]);

            for (int i = 0; i < array.Length; i++)
            {
                distance = 500;
                r = Convert.ToDouble(Color.FromArgb(array[i]).R);
                g = Convert.ToDouble(Color.FromArgb(array[i]).G);
                b = Convert.ToDouble(Color.FromArgb(array[i]).B);
                int nearest_color = 0;
                Color o;

                for (int v = 1; v < colors.Length; v++)
                {
                    o = colors[v];

                    dbl_test_red = Math.Pow(Convert.ToDouble(((Color)o).R) - r, 2.0);
                    dbl_test_green = Math.Pow(Convert.ToDouble(((Color)o).G) - g, 2.0);
                    dbl_test_blue = Math.Pow(Convert.ToDouble(((Color)o).B) - b, 2.0);

                    temp = Math.Sqrt(dbl_test_blue + dbl_test_green + dbl_test_red);

                    // explore the result and store the nearest color
                    if (temp == 0.0)
                    {
                        nearest_color = v;
                        break;
                    }
                    else if (temp < distance)
                    {
                        distance = temp;
                        nearest_color = v;
                    }
                }
                if (array[i] != 0)
                    array[i] = nearest_color;
            }
        }

        private void CopyOverGraphicBlock(byte[] src, byte[] dest, Size s, int colspan, int tileSize, int x, int y, int offset)
        {
            Point p;
            for (int b = 0; b < s.Height; b++)
            {
                for (int a = 0; a < s.Width; a++)
                {
                    p = new Point(x + a, y + b);

                    for (int i = 0; i < tileSize; i++)
                    {
                        if ((p.Y * colspan * tileSize + (p.X * tileSize) + i + offset) >= dest.Length) return;

                        dest[p.Y * colspan * tileSize + (p.X * tileSize) + i + offset] = src[b * s.Width * tileSize + (a * tileSize) + i];
                    }
                }
            }
        }

        private Image SetPaletteOverlay(Size s, Size u, int index)
        {
            // s is palette dimen, u is color dimen

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
            return Drawing.PixelArrayToImage(pixels, s.Width, s.Height);
        }

        // editing
        private void TileSetDown(MouseEventArgs e)
        {
            int x = e.X / 16 * 16;
            int y = e.Y / 16 * 16;

            overlay.TileSetDragStart = new Point(x, y);
            overlay.TileSetDragStop = new Point(x + 16, y + 16);
        }
        private void TileSetSelect(MouseEventArgs e)
        {
            int x = e.X / 16 * 16;
            int y = e.Y / 16 * 16;

            overlay.TileSetDragStop = new Point(x, y);

            drawBufWidth = GetTileSetSelection(ref this.drawBuf);
        }
        private int GetTileSetSelection(ref int[] dest)
        {
            int dx = (overlay.TileSetDragStop.X - overlay.TileSetDragStart.X) / 16;
            int dy = (overlay.TileSetDragStop.Y - overlay.TileSetDragStart.Y) / 16;

            dest = new int[dx * dy];
            int entry;

            for (int i = 0; i < dest.Length; i++)
            {
                entry = currentDialogueTile;
                dest[i] = entry;
            }

            return dx;
        }

        // assembler
        public void Assemble()
        {
            if (!dialogueTextBox.IsDisposed && !dialogueTextBox.Text.EndsWith("[0]") && !dialogueTextBox.Text.EndsWith("[6]"))
            {
                dialogueTextBox.SelectionStart = dialogueTextBox.Text.Length;
                InsertIntoDialogueText("[0]");
            }
            if (!battleDialogueTextBox.IsDisposed && !battleDialogueTextBox.Text.EndsWith("[0]"))
            {
                battleDialogueTextBox.SelectionStart = battleDialogueTextBox.Text.Length;
                InsertIntoBattleDialogueText("[0]");
            }

            if (!model.AssembleSprites)
                return;
            if (model.AssembleFinal)
                model.AssembleSprites = false;

            spriteGraphics.CopyTo(data, 0x280000);

            foreach (Sprite s in sprites)
                s.Assemble();
            AssembleAllGraphicPalettes();
            AssembleAllAnimations();
            AssembleAllSpritePalettes();

            AssembleFonts();
            AssembleDialogues();

            AssembleAllWorldMaps();
            AssembleAllMapPoints();

            foreach (Effect e in effects)
                e.Assemble();
            AssembleAllE_Animations();

            AssembleTitle();
        }

        #endregion

        #region Eventhandlers

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Assemble();
        }
        // Clear elements
        private void animationsallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clearElements = new ClearElements(animations, (int)animationPacket.Value, "CLEAR SPRITE ANIMATIONS...");
            clearElements.ShowDialog();
            animationPacket_ValueChanged(null, null);
        }
        private void allPaletteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clearElements = new ClearElements(spritePalettes, (int)paletteOffset.Value, "CLEAR SPRITE PALETTES...");
            clearElements.ShowDialog();
            paletteOffset_ValueChanged(null, null);
        }
        private void allMapsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clearElements = new ClearElements(worldMaps, (int)worldMapNum.Value, "CLEAR WORLD MAPS...");
            clearElements.ShowDialog();
            DialogResult result = MessageBox.Show(
                "Clear all world map tilesets also?", "CLEAR ALL WORLD MAP TILESETS?",
                MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                for (int i = 0; i < model.WorldMapTileSets.Length; i++)
                    model.WorldMapTileSets[i] = new byte[0x2000];
            }
            worldMapNum_ValueChanged(null, null);
        }
        private void allMapPointsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clearElements = new ClearElements(mapPoints, (int)mapPointNum.Value, "CLEAR WORLD MAP POINTS...");
            clearElements.ShowDialog();
            mapPointNum_ValueChanged(null, null);
        }
        private void dialoguesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clearElements = new ClearElements(universal.Dialogues, (int)dialogueNum.Value, "CLEAR DIALOGUES...");
            clearElements.ShowDialog();
            dialogueNum_ValueChanged(null, null);
        }
        // Import/export elements
        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            ioElements = new ImportExportElements(this, (int)animationPacket.Value, "EXPORT SPRITE ANIMATIONS...");
            ioElements.ShowDialog();
        }
        private void allAnimationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ioElements = new ImportExportElements(this, (int)animationPacket.Value, "IMPORT SPRITE ANIMATIONS...");
            ioElements.ShowDialog();
            if (ioElements.DialogResult != DialogResult.OK)
                return;
            animationPacket_ValueChanged(null, null);
        }
        private void allDialoguesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "EXPORT DIALOGUES INTO TEXT FILE...";
            saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.FileName = "dialogues";
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                StreamWriter dialogues = File.CreateText(saveFileDialog.FileName);
                for (int i = 0; i < universal.Dialogues.Length; i++)
                {
                    dialogues.WriteLine(
                        "{" + i.ToString("d4") + "}\t" +
                        universal.Dialogues[i].GetDialogue(true));
                }
                dialogues.Close();
            }
        }
        private void allDialoguesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "IMPORT DIALOGUES FROM TEXT FILE...";
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 0;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() != DialogResult.OK)
                return;

            string path = openFileDialog.FileName;
            TextReader tr;
            BinaryFormatter b = new BinaryFormatter();
            try
            {
                tr = new StreamReader(path);
                while (tr.Peek() != -1)
                {
                    string line = tr.ReadLine();
                    int number = Convert.ToInt32(line.Substring(1, 4), 10);
                    line = line.Remove(0, 7);
                    if (!line.EndsWith("[0]") && !line.EndsWith("[6]"))
                        line += "[0]";
                    universal.Dialogues[number].SetDialogue(line, true);
                    universal.Dialogues[number].Data = model.Data;
                }
                dialogueNum_ValueChanged(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "There was a problem loading Dialogue data. Verify that the lines in the\n" +
                    "text file are correctly named.\n\n" +
                    "Each line must begin with the 4-digit dialogue number enclosed in {},\n" +
                    "followed by a tab character, then the raw dialogue itself.",
                    "LAZY SHELL");
            }
        }
        private void allEffectAnimationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ioElements = new ImportExportElements(this, (int)e_animation.Value, "IMPORT EFFECT ANIMATIONS...");
            ioElements.ShowDialog();
            if (ioElements.DialogResult != DialogResult.OK)
                return;
            e_animation_ValueChanged(null, null);
        }
        private void allEffectAnimationsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ioElements = new ImportExportElements(this, (int)e_animation.Value, "EXPORT EFFECT ANIMATIONS...");
            ioElements.ShowDialog();
        }
        private void allEffectsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clearElements = new ClearElements(e_animations, (int)e_animation.Value, "CLEAR SPELL EFFECTS...");
            clearElements.ShowDialog();
            e_animation_ValueChanged(null, null);
        }

        private void contextMenuStripGR_Opening(object sender, CancelEventArgs e)
        {
            if (mouseOverControl == "pictureBoxFont")
                setAsSubtileToolStripMenuItem.Text = "Insert into dialogue";
            else
                setAsSubtileToolStripMenuItem.Text = "Set subtile";
            if (contextMenuStripGR.SourceControl == pictureBoxTitleLogo)
                setAsSubtileToolStripMenuItem.Enabled = false;
            else
                setAsSubtileToolStripMenuItem.Enabled = true;
        }
        private void setAsSubtileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch (mouseOverControl)
            {
                case "pictureBoxGraphics":
                    if (animations[currentAnimation].SubTiles != null)
                        moldSubtile.Value = mouseOverSubtile;
                    break;
                case "pictureBoxDialogueBG": dialogueSubtile.Value = mouseOverSubtile; break;
                case "pictureBoxWMGraphics": wmSubtile.Value = mouseOverSubtile; break;
                case "pictureBoxE_Graphics": e_tileSubtile.Value = mouseOverSubtile; break;
                case "pictureBoxFont":
                    if (currentKS[overFontChar] == "")
                        InsertIntoDialogueText("[" + overFontChar + "]");
                    else
                        InsertIntoDialogueText(currentKS[overFontChar]);
                    break;
            }
        }
        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path;
            string filter = "Image files (*.bmp,*.png,*.gif,*.jpg)|*.bmp;*.png;*.gif;*.jpg|All files (*.*)|*.*";

            switch (contextMenuStripGR.SourceControl.Name)
            {
                case "pictureBoxGraphics":
                    path = SelectFile("Select the graphic block to import", filter, 2);
                    if (path != null)
                        ImportGraphicBlock(path); graphicOffset_ValueChanged(null, null); break;
                case "pictureBoxFont":
                    path = SelectFile("Select the graphic block to import", filter, 2);
                    if (path != null)
                        ImportFontGraphic(path); fontType_SelectedIndexChanged(null, null); break;
                case "pictureBoxDialogueBG":
                    path = SelectFile("Select the graphic block to import", filter, 2);
                    if (path != null)
                    {
                        ImportDialogueGraphic(path);
                        RefreshDialogueTilesets();
                        SetBattleDialogueTilesetImage();
                        SetDialogueGraphicImage();
                        SetDialogueTileImage();
                        SetDialogueSubtileImage();
                        SetDialogueBGImage();
                    }
                    break;
                case "pictureBoxWMGraphics":
                    path = SelectFile("Select the graphic block to import", filter, 2);
                    if (path != null)
                        ImportWorldMapGraphic(path); worldMapTileset_ValueChanged(null, null); break;
                case "pictureBoxE_Graphics":
                    path = SelectFile("Select the graphic block to import", filter, 2);
                    if (path != null)
                        ImportE_GraphicBlock(path); break;
                case "pictureBoxTitleL1":
                    ImportTitle(); break;
                case "pictureBoxTitleL2":
                    ImportTitle(); break;
                case "pictureBoxTitleLogo":
                    path = SelectFile("Select the image to import", filter, 2);
                    ImportTitleLogo(path); break;
            }
        }
        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch (contextMenuStripGR.SourceControl.Name)
            {
                case "pictureBoxGraphics": ExportGraphicBlock(); break;
                case "pictureBoxFont": ExportFontGraphic(); break;
                case "pictureBoxDialogueBG": ExportDialogueGraphic(); break;
                case "pictureBoxWMGraphics": ExportWorldMapGraphic(); break;
                case "pictureBoxE_Graphics": ExportE_GraphicBlock(); break;
                case "pictureBoxTitleLogo": ExportTitleLogo(); break;
            }
        }
        private void saveImageToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PNG files (*.png)|*.png|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;
            switch (contextMenuStripGR.SourceControl.Name)
            {
                case "pictureBoxGraphics":
                    saveFileDialog.FileName = "spriteGraphic." + graphicPalettes[currentGraphicPalette].GraphicOffset.ToString("X6") + ".png";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        graphicImage.Save(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Png);
                    break;
                case "pictureBoxFont":
                    saveFileDialog.FileName = "fontGraphic.png";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        fontTableImage.Save(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Png);
                    break;
                case "pictureBoxDialogueBG":
                    saveFileDialog.FileName = "dialogueGraphic.png";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        dialogueGraphicImage.Save(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Png);
                    break;
                case "pictureBoxWMGraphics":
                    saveFileDialog.FileName = "worldMapGraphic.png";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        graphicSetImage.Save(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Png);
                    break;
                case "pictureBoxE_Graphics":
                    saveFileDialog.FileName = "effectGraphic." + e_currentAnimation.ToString("d3") + ".png";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        e_graphicImage.Save(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Png);
                    break;
                case "pictureBoxTitleL1":
                    saveFileDialog.FileName = "titleL1.png";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        titleL1Image.Save(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Png);
                    break;
                case "pictureBoxTitleL2":
                    saveFileDialog.FileName = "titleL2.png";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        titleL2Image.Save(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Png);
                    break;
                case "pictureBoxTitleLogo":
                    saveFileDialog.FileName = "titleLogo.png";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        titleLogoImage.Save(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Png);
                    break;
            }
        }
        private void clearToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "This will erase all of the graphics in the current image.\nAre you sure you want to do this?",
                "LAZY SHELL", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result != DialogResult.Yes) return;

            switch (contextMenuStripGR.SourceControl.Name)
            {
                case "pictureBoxGraphics":
                    byte[] temp = new byte[0x4000];
                    temp.CopyTo(spriteGraphics, graphicPalettes[currentGraphicPalette].GraphicOffset - 0x280000);
                    graphicOffset_ValueChanged(null, null);
                    break;
                case "pictureBoxFont":
                    switch (fontType.SelectedIndex)
                    {
                        case 0: foreach (FontCharacter f in fontMenu) f.Graphics = new byte[0xC00]; break;
                        case 1: foreach (FontCharacter f in fontDialogue) f.Graphics = new byte[0x1800]; break;
                        case 2: foreach (FontCharacter f in fontDescription) f.Graphics = new byte[0x800]; break;
                        case 3: foreach (FontCharacter f in fontTriangle) f.Graphics = new byte[0x1C0]; break;
                    }
                    fontType_SelectedIndexChanged(null, null);
                    break;
                case "pictureBoxDialogueBG":
                    model.DialogueGraphics = new byte[0x700];
                    RefreshDialogueTilesets();
                    SetBattleDialogueTilesetImage();
                    SetDialogueGraphicImage();
                    SetDialogueTileImage();
                    SetDialogueSubtileImage();
                    SetDialogueBGImage();
                    break;
                case "pictureBoxWMGraphics":
                    model.WorldMapGraphics = new byte[0x8000]; worldMapTileset_ValueChanged(null, null);
                    break;
                case "pictureBoxE_Graphics":
                    e_animations[e_currentAnimation].GraphicSet = new byte[e_animations[e_currentAnimation].GraphicSetLength];
                    SetE_GraphicImage();
                    SetE_TilesetImage();
                    SetE_MoldImage();
                    SetE_SequenceFrameImages();
                    break;
                case "pictureBoxTitleLogo":
                    BitManager.SetByteArray(model.TitleData, 0xBEA0, new byte[0x1BC0]);
                    break;
            }
        }
        // draw border
        private void applyBorderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            progressBar = new ProgressBar(this.model, model.Data, "DRAWING BORDER AROUND IMAGE GRAPHICS...", 512, backgroundWorker1);
            progressBar.Show();
            backgroundWorker1.RunWorkerAsync();
        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            byte[] array = spriteGraphics;
            foreach (GraphicPalette gp in graphicPalettes)
            {
                if (backgroundWorker1.CancellationPending) break;

                Tile8x8 tile;
                int offset, color;
                byte bit;
                int[] palette = spritePalettes[gp.PaletteNum].Get4bppPalette();
                int darkestAverage = 248;
                int darkestColor = 0;
                // find the darkest color in the palette
                for (int i = 0; i < 16; i++)
                {
                    int average =
                        spritePalettes[gp.PaletteNum].PaletteColorRed[i] +
                        spritePalettes[gp.PaletteNum].PaletteColorGreen[i] +
                        spritePalettes[gp.PaletteNum].PaletteColorBlue[i] / 3;
                    if (average < darkestAverage && average != 0)
                    {
                        darkestColor = i;
                        darkestAverage = average;
                    }
                }
                for (int b = 0; b < 32; b++)
                {
                    for (int a = 0; a < 16; a++)
                    {
                        offset = gp.GraphicOffset + ((b * 16 + a) * 0x20) - 0x280000;
                        // first create the Tile8x8 and draw the border around it
                        tile = new Tile8x8(b * 16 + a, array, offset, palette, false, false, false, false);
                        for (int i = 0; i < 64; i++)
                        {
                            // if pixel is empty, don't attempt to draw a border
                            if (tile.Pixels[i] == 0) continue;
                            // if not first or last in row, check previous and next pixel in row
                            if ((i % 8) > 0 && tile.Colors[i - 1] == 0)
                            {
                                tile.Colors[i] = darkestColor;   // the inner border
                            }
                            if ((i % 8) < 7 && tile.Colors[i + 1] == 0)
                            {
                                tile.Colors[i] = darkestColor;
                            }
                            // if not first or last in column, check previous and next pixel in column
                            if (i > 7 && tile.Colors[i - 8] == 0)
                            {
                                tile.Colors[i] = darkestColor;
                            }
                            if (i < 56 && tile.Colors[i + 8] == 0)
                            {
                                tile.Colors[i] = darkestColor;
                            }
                        }
                        // finally, draw the Tile8x8 back to the 4bpp array
                        for (int y = 0; y < 8; y++)
                        {
                            for (int x = 0; x < 8; x++)
                            {
                                color = tile.Colors[y * 8 + x];
                                bit = (byte)(x ^ 7);
                                offset = gp.GraphicOffset + ((b * 16 + a) * 0x20) + (y * 2) - 0x280000;
                                BitManager.SetBit(array, offset, bit, (color & 1) == 1);
                                BitManager.SetBit(array, offset + 1, bit, (color & 2) == 2);
                                BitManager.SetBit(array, offset + 16, bit, (color & 4) == 4);
                                BitManager.SetBit(array, offset + 17, bit, (color & 8) == 8);
                            }
                        }
                    }
                }

                backgroundWorker1.ReportProgress(gp.GraphicPaletteNum);
            }
        }
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar.PerformStep("DRAWING BORDER FOR IMAGE #" + e.ProgressPercentage + " OF 512");
        }
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBar.Close();
            this.Enabled = true;

            UpdateAllTile8x8SubTiles();
            SetGraphicImage();
            SetMoldImage();
            SetTileImage();
            SetTilesetImage();
            animations[currentAnimation].Set8x8Tiles(
                BitManager.GetByteArray(spriteGraphics, graphicPalettes[currentGraphicPalette].GraphicOffset - 0x280000, 0x4000),
                spritePalettes[currentPalette + currentPaletteShift].Get4bppPalette(),
                animations[currentAnimation].Gridplane);
            SetSubtileImage();
            SetSequenceFrameImages();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch (((Control)sender).Name)
            {
                case "molds":
                    moldCopy = (Mold)animations[currentAnimation].Molds[currentMold]; return;
                default: break;
            }
            switch (ActiveControl.Name)
            {
                case "pictureBoxBattle": CopyBattleDialogue(); break;
                case "pictureBoxWorldMap": CopyWorldMap(); break;
            }
        }
        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch (((Control)sender).Name)
            {
                case "molds":
                    return;
                default: break;
            }
            switch (ActiveControl.Name)
            {
                case "pictureBoxBattle": PasteBattleDialogue(); break;
                case "pictureBoxWorldMap": PasteWorldMap(); break;
            }
        }
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch (ActiveControl.Name)
            {
                case "pictureBoxBattle": DeleteBattleDialogue(); break;
                case "pictureBoxWorldMap": DeleteWorldMap(); break;
            }
        }
        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch (ActiveControl.Name)
            {
                case "pictureBoxBattle": CutBattleDialogue(); break;
                case "pictureBoxWorldMap": CutWorldMap(); break;
            }
        }

        private void importPaletteSetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = SelectFile("Select the file to import", "Binary files (*.bin)|*.bin|MS Palette file (*.pal)|*.pal|All files (*.*)|*.*", 3);

            FileStream fs;
            BinaryReader br;

            byte[] buffer = new byte[1024];

            try
            {
                fs = File.OpenRead(path);

                if (Path.GetExtension(path) == ".pal")
                {
                    br = new BinaryReader(fs);
                    if (fs.Length > buffer.Length)
                        buffer = br.ReadBytes(buffer.Length);
                    else
                        br.ReadBytes((int)fs.Length).CopyTo(buffer, 0);

                    if (contextMenuStrip3.SourceControl == pictureBoxPalette)
                    {
                        for (int j = 0; j < 16; j++) // 16 colors in palette
                        {
                            spritePalettes[currentPalette].PaletteColorRed[j] = buffer[(j * 4) + 1 + 0x17];
                            spritePalettes[currentPalette].PaletteColorGreen[j] = buffer[(j * 4) + 2 + 0x17];
                            spritePalettes[currentPalette].PaletteColorBlue[j] = buffer[(j * 4) + 3 + 0x17];
                        }
                    }
                    else if (contextMenuStrip3.SourceControl == pictureBoxWMPalette)
                    {
                        for (int i = 0; i < 8; i++) // 7 palettes in set
                        {
                            for (int j = 0; j < 16; j++) // 16 colors in palette
                            {
                                worldMapPalettes.PaletteColorRed[(i * 16) + j] = buffer[(i * 64) + (j * 4) + 1 + 0x17];
                                worldMapPalettes.PaletteColorGreen[(i * 16) + j] = buffer[(i * 64) + (j * 4) + 2 + 0x17];
                                worldMapPalettes.PaletteColorBlue[(i * 16) + j] = buffer[(i * 64) + (j * 4) + 3 + 0x17];
                            }
                        }
                        wmPaletteRedNum_ValueChanged(null, null);
                    }
                    else if (contextMenuStrip3.SourceControl == pictureBoxE_Palette)
                    {
                        for (int i = 0; i < e_animations[e_currentAnimation].PaletteSetLength / 32; i++)
                        {
                            for (int j = 0; j < 16; j++) // 16 colors in palette
                            {
                                e_animations[e_currentAnimation].PaletteColorRed[(i * 16) + j] = buffer[(i * 64) + (j * 4) + 1 + 0x17];
                                e_animations[e_currentAnimation].PaletteColorGreen[(i * 16) + j] = buffer[(i * 64) + (j * 4) + 2 + 0x17];
                                e_animations[e_currentAnimation].PaletteColorBlue[(i * 16) + j] = buffer[(i * 64) + (j * 4) + 3 + 0x17];
                            }
                        }
                    }
                }
                else
                {
                    br = new BinaryReader(fs);
                    if (fs.Length > buffer.Length)
                        buffer = br.ReadBytes(buffer.Length);
                    else
                        br.ReadBytes((int)fs.Length).CopyTo(buffer, 0);

                    double multiplier = 8; // 8;
                    ushort color = 0;

                    if (contextMenuStrip3.SourceControl == pictureBoxPalette)
                    {
                        for (int j = 0; j < 16; j++) // 16 colors in palette
                        {
                            color = BitManager.GetShort(buffer, (j * 2));

                            spritePalettes[currentPalette].PaletteColorRed[j] = (byte)((color % 0x20) * multiplier);
                            spritePalettes[currentPalette].PaletteColorGreen[j] = (byte)(((color >> 5) % 0x20) * multiplier);
                            spritePalettes[currentPalette].PaletteColorBlue[j] = (byte)(((color >> 10) % 0x20) * multiplier);
                        }
                    }
                    else if (contextMenuStrip3.SourceControl == pictureBoxWMPalette)
                    {
                        for (int i = 0; i < 8; i++) // 7 palettes in set
                        {
                            for (int j = 0; j < 16; j++) // 16 colors in palette
                            {
                                color = BitManager.GetShort(buffer, (i * 32) + (j * 2));

                                worldMapPalettes.PaletteColorRed[(i * 16) + j] = (byte)((color % 0x20) * multiplier);
                                worldMapPalettes.PaletteColorGreen[(i * 16) + j] = (byte)(((color >> 5) % 0x20) * multiplier);
                                worldMapPalettes.PaletteColorBlue[(i * 16) + j] = (byte)(((color >> 10) % 0x20) * multiplier);
                            }
                        }
                        wmPaletteRedNum_ValueChanged(null, null);
                    }
                    else if (contextMenuStrip3.SourceControl == pictureBoxE_Palette)
                    {
                        for (int i = e_currentColor / 16, a = 0; i < e_animations[e_currentAnimation].PaletteSetLength / 32 && a < buffer.Length / 32; i++, a++) // 7 palettes in set
                        {
                            for (int j = 0; j < 16; j++) // 16 colors in palette
                            {
                                color = BitManager.GetShort(buffer, (a * 32) + (j * 2));

                                e_animations[e_currentAnimation].PaletteColorRed[(i * 16) + j] = (byte)((color % 0x20) * multiplier);
                                e_animations[e_currentAnimation].PaletteColorGreen[(i * 16) + j] = (byte)(((color >> 5) % 0x20) * multiplier);
                                e_animations[e_currentAnimation].PaletteColorBlue[(i * 16) + j] = (byte)(((color >> 10) % 0x20) * multiplier);
                            }
                        }
                    }
                }
                if (contextMenuStrip3.SourceControl == pictureBoxPalette)
                    paletteOffset_ValueChanged(null, null);
                else if (contextMenuStrip3.SourceControl == pictureBoxWMPalette)
                    worldMapNum_ValueChanged(null, null);
                else if (contextMenuStrip3.SourceControl == pictureBoxE_Palette)
                    e_paletteRedNum_ValueChanged(null, null);

                br.Close();
                fs.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was a problem loading the file.", "LAZY SHELL");
                return;
            }
        }
        private void exportPaletteSetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Binary files (*.bin)|*.bin|MS Palette file (*.pal)|*.pal|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 0;
            if (contextMenuStrip3.SourceControl == pictureBoxPalette)
                saveFileDialog.FileName = "paletteSetSprite." + currentPalette;
            else if (contextMenuStrip3.SourceControl == pictureBoxWMPalette)
                saveFileDialog.FileName = "paletteSetWM";
            else if (contextMenuStrip3.SourceControl == pictureBoxE_Palette)
                saveFileDialog.FileName = "paletteSetEffectAnimation." + e_currentAnimation;
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                FileStream fs;
                BinaryWriter bw;
                byte[] buffer = new byte[1024];

                if (saveFileDialog.FilterIndex == 2)
                {
                    byte[] temp = new byte[]
                    {
                        0x52, 0x49, 0x46, 0x46, 0x14, 0x04, 0x00, 0x00, 
                        0x50, 0x41, 0x4C, 0x20, 0x64, 0x61, 0x74, 0x61
                    };
                    temp.CopyTo(buffer, 0);

                    BitManager.SetShort(buffer, 0x10, 448 + 3);

                    if (contextMenuStrip3.SourceControl == pictureBoxPalette)
                    {
                        for (int j = 0; j < 16; j++) // 16 colors in palette
                        {
                            buffer[(j * 4) + 1 + 0x17] = (byte)spritePalettes[currentPalette].PaletteColorRed[j];
                            buffer[(j * 4) + 2 + 0x17] = (byte)spritePalettes[currentPalette].PaletteColorGreen[j];
                            buffer[(j * 4) + 3 + 0x17] = (byte)spritePalettes[currentPalette].PaletteColorBlue[j];
                        }
                    }
                    else if (contextMenuStrip3.SourceControl == pictureBoxWMPalette)
                    {
                        for (int i = 0; i < 8; i++) // 7 palettes in set
                        {
                            for (int j = 0; j < 16; j++) // 16 colors in palette
                            {
                                buffer[(i * 64) + (j * 4) + 1 + 0x17] = (byte)worldMapPalettes.PaletteColorRed[(i * 16) + j];
                                buffer[(i * 64) + (j * 4) + 2 + 0x17] = (byte)worldMapPalettes.PaletteColorGreen[(i * 16) + j];
                                buffer[(i * 64) + (j * 4) + 3 + 0x17] = (byte)worldMapPalettes.PaletteColorBlue[(i * 16) + j];
                            }
                        }
                    }
                    else if (contextMenuStrip3.SourceControl == pictureBoxE_Palette)
                    {
                        for (int i = 0; i < e_animations[e_currentAnimation].PaletteSetLength / 32; i++) // 7 palettes in set
                        {
                            for (int j = 0; j < 16; j++) // 16 colors in palette
                            {
                                buffer[(i * 64) + (j * 4) + 1 + 0x17] = (byte)e_animations[e_currentAnimation].PaletteColorRed[(i * 16) + j];
                                buffer[(i * 64) + (j * 4) + 2 + 0x17] = (byte)e_animations[e_currentAnimation].PaletteColorGreen[(i * 16) + j];
                                buffer[(i * 64) + (j * 4) + 3 + 0x17] = (byte)e_animations[e_currentAnimation].PaletteColorBlue[(i * 16) + j];
                            }
                        }
                    }

                    fs = new FileStream(saveFileDialog.FileName + ".pal", FileMode.Create, FileAccess.ReadWrite);
                    bw = new BinaryWriter(fs);
                    bw.Write(buffer, 0, 448 + 0x17);
                    bw.Close();
                    fs.Close();
                }
                else
                {
                    ushort color = 0;
                    int r, g, b;

                    if (contextMenuStrip3.SourceControl == pictureBoxPalette)
                    {
                        for (int j = 0; j < 16; j++) // 16 colors in palette
                        {
                            r = (int)(spritePalettes[currentPalette].PaletteColorRed[j] / 8);
                            g = (int)(spritePalettes[currentPalette].PaletteColorGreen[j] / 8);
                            b = (int)(spritePalettes[currentPalette].PaletteColorBlue[j] / 8);
                            color = (ushort)((b << 10) | (g << 5) | r);
                            BitManager.SetShort(buffer, (j * 2), color);
                        }
                    }
                    else if (contextMenuStrip3.SourceControl == pictureBoxWMPalette)
                    {
                        for (int i = 0; i < 8; i++) // 7 palettes in set
                        {
                            for (int j = 0; j < 16; j++) // 16 colors in palette
                            {
                                r = (int)(worldMapPalettes.PaletteColorRed[(i * 16) + j] / 8);
                                g = (int)(worldMapPalettes.PaletteColorGreen[(i * 16) + j] / 8);
                                b = (int)(worldMapPalettes.PaletteColorBlue[(i * 16) + j] / 8);
                                color = (ushort)((b << 10) | (g << 5) | r);
                                BitManager.SetShort(buffer, (i * 32) + (j * 2), color);
                            }
                        }
                    }
                    else if (contextMenuStrip3.SourceControl == pictureBoxE_Palette)
                    {
                        for (int i = 0; i < e_animations[e_currentAnimation].PaletteSetLength / 32; i++)
                        {
                            for (int j = 0; j < 16; j++) // 16 colors in palette
                            {
                                r = (int)(e_animations[e_currentAnimation].PaletteColorRed[(i * 16) + j] / 8);
                                g = (int)(e_animations[e_currentAnimation].PaletteColorGreen[(i * 16) + j] / 8);
                                b = (int)(e_animations[e_currentAnimation].PaletteColorBlue[(i * 16) + j] / 8);
                                color = (ushort)((b << 10) | (g << 5) | r);
                                BitManager.SetShort(buffer, (i * 30) + (j * 2), color);
                            }
                        }
                    }

                    fs = new FileStream(saveFileDialog.FileName + ".bin", FileMode.Create, FileAccess.ReadWrite);
                    bw = new BinaryWriter(fs);
                    bw.Write(buffer, 0, 0xE0);
                    bw.Close();
                    fs.Close();
                }
            }
        }

        // help menu
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form about = new About(this);
            about.ShowDialog(this);
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            panelColorBalance.Visible = false;

            overlay.TileSetDragStart = new Point(0, 0);
            overlay.TileSetDragStop = new Point(0, 0);
        }
        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            string tabName = this.tabControl1.TabPages[e.Index].Text;
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Near;
            Font f = new Font(e.Font, FontStyle.Bold);

            SolidBrush s, b;
            if (e.Index == tabControl1.SelectedIndex)
            {
                s = new SolidBrush(SystemColors.ControlDarkDark);
                b = new SolidBrush(SystemColors.Control);
            }
            else
            {
                s = new SolidBrush(Color.FromArgb(236, 232, 224));
                b = new SolidBrush(SystemColors.ControlText);
            }
            Rectangle r = new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height);
            e.Graphics.FillRectangle(s, r);
            r.X += 3; r.Y += 3;
            e.Graphics.DrawString(tabName, f, b, r, sf);
            sf.Dispose();
        }
        private void Sprites_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            DialogResult result;

            if (model.AssembleSprites)
            {
                result = MessageBox.Show("Sprites have not been saved.\n\nWould you like to save changes?", "LAZY SHELL", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    Assemble();
                }
                else if (result == DialogResult.No)
                    return;
                else if (result == DialogResult.Cancel)
                {
                    e.Cancel = true;
                    return;
                }
            }
            model.AssembleSprites = false;
            settings.Save();
        }
        private void Sprites_FormClosed(object sender, FormClosedEventArgs e)
        {
            GC.Collect();
        }

        // moving panels
        private void panelSprites_MouseMove(object sender, MouseEventArgs e)
        {
            if (movingPanelImageGraphics)
            {
                panelImageGraphics.Left = e.X - mousePos.X - 2;
                panelImageGraphics.Top = e.Y - mousePos.Y - 2;
                pictureBoxGraphics.Invalidate();
            }
            else if (movingPanelMoldImage)
            {
                panelMoldImage.Left = e.X - mousePos.X - 2;
                panelMoldImage.Top = e.Y - mousePos.Y - 2;
                pictureBoxMold.Invalidate();
            }
        }
        private void panelSprites_MouseUp(object sender, MouseEventArgs e)
        {
            movingPanelImageGraphics = false;
            movingPanelMoldImage = false;
        }

        private void labelImageGraphics_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Clicks > 1)
                return;

            movingPanelMoldImage = false;
            resizingPanelMoldImage = false;

            mousePos.X = e.X;
            mousePos.Y = e.Y;

            panelImageGraphics.BringToFront();
            movingPanelImageGraphics = true;

            panelSprites.Capture = true;
        }
        private void labelImageGraphics_MouseUp(object sender, MouseEventArgs e)
        {
            movingPanelImageGraphics = false;
        }
        private void labelImageGraphics_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            panelImageGraphics.BringToFront();
            panelImageGraphicsMax = !panelImageGraphicsMax;

            if (!panelImageGraphicsMax)
            {
                panelImageGraphics.Location = new Point(6, 254);
                panelImageGraphics.Size = new Size(260, 394);
                panelImageGraphics.Anchor = (AnchorStyles)(AnchorStyles.Top | AnchorStyles.Left);
            }
            else
            {
                Size s = panelSprites.Size;
                panelImageGraphics.Location = new Point(-2, -2);
                panelImageGraphics.Size = new Size(s.Width + 4, s.Height + 4);
                panelImageGraphics.Anchor = (AnchorStyles)(AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
            }
        }
        private void panelImageGraphics_MouseDown(object sender, MouseEventArgs e)
        {
            movingPanelMoldImage = false;
            resizingPanelMoldImage = false;

            resizingPanelImageGraphics = true;
            SizeRight = SizeBottom = SizeBottomRight = false;

            Size s = panelImageGraphics.Size;

            if (e.X > s.Width - 4 && e.Y > s.Height - 4)
                SizeBottomRight = true;
            else if (e.X > s.Width - 4)
                SizeRight = true;
            else if (e.Y > s.Height - 4)
                SizeBottom = true;
            else
            {
                resizingPanelImageGraphics = false;
                return;
            }

            panelImageGraphics.BringToFront();
        }
        private void panelImageGraphics_MouseMove(object sender, MouseEventArgs e)
        {
            if (resizingPanelMoldImage) return;

            Point newMousePosition = new Point(e.X, e.Y);
            if (e.Button == MouseButtons.Left && resizingPanelImageGraphics)
            {
                int deltaX = newMousePosition.X - oldMousePosition.X;
                int deltaY = newMousePosition.Y - oldMousePosition.Y;

                // resize bottom
                if (SizeBottom || SizeBottomRight)
                    panelImageGraphics.Height += deltaY;
                // resize right
                if (SizeRight || SizeBottomRight)
                    panelImageGraphics.Width += deltaX;

                pictureBoxGraphics.Invalidate();
            }
            else
                resizingPanelImageGraphics = false;

            oldMousePosition = newMousePosition;

            if (resizingPanelImageGraphics)
                return;

            Size s = panelImageGraphics.Size;

            if (e.X > s.Width - 4 && e.Y > s.Height - 4)
                panelImageGraphics.Cursor = Cursors.SizeNWSE;
            else if (e.X > s.Width - 4 && e.Y < 4)
                panelImageGraphics.Cursor = Cursors.SizeNESW;
            else if (e.X > s.Width - 4)
                panelImageGraphics.Cursor = Cursors.SizeWE;
            else if (e.Y > s.Height - 4)
                panelImageGraphics.Cursor = Cursors.SizeNS;
            else
                panelImageGraphics.Cursor = Cursors.Arrow;
        }
        private void panelImageGraphics_MouseLeave(object sender, EventArgs e)
        {
            panelImageGraphics.Cursor = Cursors.Arrow;
            resizingPanelImageGraphics = false;
            movingPanelImageGraphics = false;
            SizeRight = SizeBottom = SizeBottomRight = false;
        }

        private void labelMoldImage_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Clicks > 1)
                return;

            movingPanelImageGraphics = false;
            resizingPanelImageGraphics = false;

            mousePos.X = e.X;
            mousePos.Y = e.Y;

            panelMoldImage.BringToFront();
            movingPanelMoldImage = true;

            panelSprites.Capture = true;
        }
        private void labelMoldImage_MouseUp(object sender, MouseEventArgs e)
        {
            movingPanelMoldImage = false;
            labelMoldImage.Capture = true;
        }
        private void labelMoldImage_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            panelMoldImage.BringToFront();
            panelMoldImageMax = !panelMoldImageMax;

            if (!panelMoldImageMax)
            {
                panelMoldImage.Location = new Point(538, 329);
                panelMoldImage.Size = new Size(260, 319);
                panelMoldImage.Anchor = (AnchorStyles)(AnchorStyles.Top | AnchorStyles.Left);
            }
            else
            {
                Size s = panelSprites.Size;
                panelMoldImage.Location = new Point(-2, -2);
                panelMoldImage.Size = new Size(s.Width + 4, s.Height + 4);
                panelMoldImage.Anchor = (AnchorStyles)(AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
            }
        }
        private void panelMoldImage_MouseDown(object sender, MouseEventArgs e)
        {
            movingPanelImageGraphics = false;
            resizingPanelImageGraphics = false;

            resizingPanelMoldImage = true;
            SizeRight = SizeBottom = SizeBottomRight = false;

            Size s = panelMoldImage.Size;

            if (e.X > s.Width - 4 && e.Y > s.Height - 4)
                SizeBottomRight = true;
            else if (e.X > s.Width - 4)
                SizeRight = true;
            else if (e.Y > s.Height - 4)
                SizeBottom = true;
            else
            {
                resizingPanelMoldImage = false;
                return;
            }

            panelMoldImage.BringToFront();
        }
        private void panelMoldImage_MouseLeave(object sender, EventArgs e)
        {
            panelMoldImage.Cursor = Cursors.Arrow;
            resizingPanelMoldImage = false;
            movingPanelMoldImage = false;
            SizeRight = SizeBottom = SizeBottomRight = false;
        }
        private void panelMoldImage_MouseMove(object sender, MouseEventArgs e)
        {
            if (resizingPanelImageGraphics) return;

            Point newMousePosition = new Point(e.X, e.Y);
            if (e.Button == MouseButtons.Left && resizingPanelMoldImage)
            {
                int deltaX = newMousePosition.X - oldMousePosition.X;
                int deltaY = newMousePosition.Y - oldMousePosition.Y;

                // resize bottom
                if (SizeBottom || SizeBottomRight)
                    panelMoldImage.Height += deltaY;
                // resize right
                if (SizeRight || SizeBottomRight)
                    panelMoldImage.Width += deltaX;

                pictureBoxMold.Invalidate();
            }
            else
                resizingPanelMoldImage = false;

            oldMousePosition = newMousePosition;

            if (resizingPanelMoldImage)
                return;

            Size s = panelMoldImage.Size;

            if (e.X > s.Width - 4 && e.Y > s.Height - 4)
                panelMoldImage.Cursor = Cursors.SizeNWSE;
            else if (e.X > s.Width - 4 && e.Y < 4)
                panelMoldImage.Cursor = Cursors.SizeNESW;
            else if (e.X > s.Width - 4)
                panelMoldImage.Cursor = Cursors.SizeWE;
            else if (e.Y > s.Height - 4)
                panelMoldImage.Cursor = Cursors.SizeNS;
            else
                panelMoldImage.Cursor = Cursors.Arrow;
        }

        private void panelDialogues_MouseMove(object sender, MouseEventArgs e)
        {
            if (movingPanelSearchDialogue)
            {
                panelSearchDialogue.Left = e.X - mousePos.X - 2;
                panelSearchDialogue.Top = e.Y - mousePos.Y - 2;
            }
        }
        private void panelDialogues_MouseUp(object sender, MouseEventArgs e)
        {
            movingPanelSearchDialogue = false;
        }

        private void labelSearchDialogue_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            panelSearchDialogue.BringToFront();
            panelSearchDialogueMax = !panelSearchDialogueMax;

            if (!panelSearchDialogueMax)
            {
                panelSearchDialogue.Location = new Point(6, 286);
                panelSearchDialogue.Size = new Size(260, 188);
                panelSearchDialogue.Anchor = (AnchorStyles)(AnchorStyles.Top | AnchorStyles.Left);
            }
            else
            {
                Size s = panelDialogues.Size;
                panelSearchDialogue.Location = new Point(-2, -2);
                panelSearchDialogue.Size = new Size(s.Width + 4, s.Height + 4);
                panelSearchDialogue.Anchor = (AnchorStyles)(AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
            }
        }
        private void labelSearchDialogue_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Clicks > 1)
                return;

            mousePos.X = e.X;
            mousePos.Y = e.Y;

            panelSearchDialogue.BringToFront();
            movingPanelSearchDialogue = true;

            panelDialogues.Capture = true;
        }
        private void labelSearchDialogue_MouseUp(object sender, MouseEventArgs e)
        {
            movingPanelSearchDialogue = false;
        }
        private void panelSearchDialogue_MouseDown(object sender, MouseEventArgs e)
        {
            resizingPanelSearchDialogue = true;
            SizeRight = SizeBottom = SizeBottomRight = false;

            Size s = panelSearchDialogue.Size;

            if (e.X > s.Width - 4 && e.Y > s.Height - 4)
                SizeBottomRight = true;
            else if (e.X > s.Width - 4)
                SizeRight = true;
            else if (e.Y > s.Height - 4)
                SizeBottom = true;
            else
            {
                resizingPanelSearchDialogue = false;
                return;
            }

            panelSearchDialogue.BringToFront();
        }
        private void panelSearchDialogue_MouseLeave(object sender, EventArgs e)
        {
            panelSearchDialogue.Cursor = Cursors.Arrow;
            resizingPanelSearchDialogue = false;
            movingPanelSearchDialogue = false;
            SizeRight = SizeBottom = SizeBottomRight = false;
        }
        private void panelSearchDialogue_MouseMove(object sender, MouseEventArgs e)
        {
            Point newMousePosition = new Point(e.X, e.Y);
            if (e.Button == MouseButtons.Left && resizingPanelSearchDialogue)
            {
                int deltaX = newMousePosition.X - oldMousePosition.X;
                int deltaY = newMousePosition.Y - oldMousePosition.Y;

                // resize bottom
                if (SizeBottom || SizeBottomRight)
                    panelSearchDialogue.Height += deltaY;
                // resize right
                if (SizeRight || SizeBottomRight)
                    panelSearchDialogue.Width += deltaX;

                pictureBoxGraphics.Invalidate();
            }
            else
                resizingPanelSearchDialogue = false;

            oldMousePosition = newMousePosition;

            if (resizingPanelSearchDialogue)
                return;

            Size s = panelSearchDialogue.Size;

            if (e.X > s.Width - 4 && e.Y > s.Height - 4)
                panelSearchDialogue.Cursor = Cursors.SizeNWSE;
            else if (e.X > s.Width - 4 && e.Y < 4)
                panelSearchDialogue.Cursor = Cursors.SizeNESW;
            else if (e.X > s.Width - 4)
                panelSearchDialogue.Cursor = Cursors.SizeWE;
            else if (e.Y > s.Height - 4)
                panelSearchDialogue.Cursor = Cursors.SizeNS;
            else
                panelSearchDialogue.Cursor = Cursors.Arrow;
        }

        private void panelEffects_MouseMove(object sender, MouseEventArgs e)
        {
            if (movingPanelEffectGraphics)
            {
                panelEffectGraphics.Left = e.X - mousePos.X - 2;
                panelEffectGraphics.Top = e.Y - mousePos.Y - 2;
                pictureBoxE_Graphics.Invalidate();
            }
            //else if (movingPanelMoldImage)
            //{
            //    panelMoldImage.Left = e.X - mousePos.X - 2;
            //    panelMoldImage.Top = e.Y - mousePos.Y - 2;
            //    pictureBoxMold.Invalidate();
            //}
        }
        private void panelEffects_MouseUp(object sender, MouseEventArgs e)
        {
            movingPanelEffectGraphics = false;
            //movingPanelMoldImage = false;
        }

        private void labelEffectGraphics_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            panelEffectGraphics.BringToFront();
            panelEffectGraphicsMax = !panelEffectGraphicsMax;

            if (!panelEffectGraphicsMax)
            {
                panelEffectGraphics.Location = new Point(6, 363);
                panelEffectGraphics.Size = new Size(260, 285);
                panelEffectGraphics.Anchor = (AnchorStyles)(AnchorStyles.Top | AnchorStyles.Left);
            }
            else
            {
                Size s = panelEffects.Size;
                panelEffectGraphics.Location = new Point(-2, -2);
                panelEffectGraphics.Size = new Size(s.Width + 4, s.Height + 4);
                panelEffectGraphics.Anchor = (AnchorStyles)(AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
            }
        }
        private void labelEffectGraphics_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Clicks > 1)
                return;

            //movingPanelMoldImage = false;
            //resizingPanelMoldImage = false;

            mousePos.X = e.X;
            mousePos.Y = e.Y;

            panelEffectGraphics.BringToFront();
            movingPanelEffectGraphics = true;

            panelEffects.Capture = true;
        }
        private void labelEffectGraphics_MouseUp(object sender, MouseEventArgs e)
        {
            movingPanelEffectGraphics = false;
        }
        private void panelEffectGraphics_MouseDown(object sender, MouseEventArgs e)
        {
            //movingPanelMoldImage = false;
            //resizingPanelMoldImage = false;

            resizingPanelEffectGraphics = true;
            SizeRight = SizeBottom = SizeBottomRight = false;

            Size s = panelEffectGraphics.Size;

            if (e.X > s.Width - 4 && e.Y > s.Height - 4)
                SizeBottomRight = true;
            else if (e.X > s.Width - 4)
                SizeRight = true;
            else if (e.Y > s.Height - 4)
                SizeBottom = true;
            else
            {
                resizingPanelEffectGraphics = false;
                return;
            }

            panelEffectGraphics.BringToFront();
        }
        private void panelEffectGraphics_MouseLeave(object sender, EventArgs e)
        {
            panelEffectGraphics.Cursor = Cursors.Arrow;
            resizingPanelEffectGraphics = false;
            movingPanelEffectGraphics = false;
            SizeRight = SizeBottom = SizeBottomRight = false;
        }
        private void panelEffectGraphics_MouseMove(object sender, MouseEventArgs e)
        {
            //if (resizingPanelMoldImage) return;

            Point newMousePosition = new Point(e.X, e.Y);
            if (e.Button == MouseButtons.Left && resizingPanelEffectGraphics)
            {
                int deltaX = newMousePosition.X - oldMousePosition.X;
                int deltaY = newMousePosition.Y - oldMousePosition.Y;

                // resize bottom
                if (SizeBottom || SizeBottomRight)
                    panelEffectGraphics.Height += deltaY;
                // resize right
                if (SizeRight || SizeBottomRight)
                    panelEffectGraphics.Width += deltaX;

                pictureBoxE_Graphics.Invalidate();
            }
            else
                resizingPanelEffectGraphics = false;

            oldMousePosition = newMousePosition;

            if (resizingPanelEffectGraphics)
                return;

            Size s = panelEffectGraphics.Size;

            if (e.X > s.Width - 4 && e.Y > s.Height - 4)
                panelEffectGraphics.Cursor = Cursors.SizeNWSE;
            else if (e.X > s.Width - 4 && e.Y < 4)
                panelEffectGraphics.Cursor = Cursors.SizeNESW;
            else if (e.X > s.Width - 4)
                panelEffectGraphics.Cursor = Cursors.SizeWE;
            else if (e.Y > s.Height - 4)
                panelEffectGraphics.Cursor = Cursors.SizeNS;
            else
                panelEffectGraphics.Cursor = Cursors.Arrow;
        }

        private void addThisToNotesDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int type = 0;
            int index = 0;
            string label = "";
            string description = "";

            if (contextMenuStrip2.SourceControl.Name == "spriteName")
            {
                type = 10;
                index = (int)spriteNum.Value;
                label = description = settings.SpriteNames[(int)spriteNum.Value];
            }
            if (contextMenuStrip2.SourceControl.Name == "effectName")
            {
                type = 11;
                index = (int)effectNum.Value;
                label = description = effectName.Text.Substring(7);
            }
            if (contextMenuStrip2.SourceControl.Name == "dialogueNum")
            {
                type = 12;
                index = (int)dialogueNum.Value;
                label = "Dialogue #" + ((int)dialogueNum.Value).ToString("d4");
                description = dialogueTextBox.Text;
            }

            if (type == 0) return;

            if (model.Program.Notes == null || !model.Program.Notes.Visible)
                model.Program.CreateNotesWindow();
            Notes temp = model.Program.Notes;
            if (temp.ThisNotes == null)
                temp.LoadNotes();
            if (temp.ThisNotes != null)
            {
                temp.AddingFromEditor(type, index, label, description);
                temp.BringToFront();
            }
            else
            {
                MessageBox.Show("Could not add element to notes database.", "LAZY SHELL",
                    MessageBoxButtons.OK);
            }
        }

        #endregion
    }
}