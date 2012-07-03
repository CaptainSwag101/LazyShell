using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms; // remove later
using System.IO;
using System.Security.Cryptography;
using LAZYSHELL.ScriptsEditor;
using LAZYSHELL.DataStructures;
using LAZYSHELL.Properties;

namespace LAZYSHELL
{
    public static class Model
    {
        private static Program program;
        public static Program Program { get { return program; } set { program = value; } }
        private static byte[] data;
        public static byte[] Data
        {
            get { return data; }
            set { data = value; }
        }
        private static HexEditor hexViewer;
        public static HexEditor HexViewer { get { return hexViewer; } set { hexViewer = value; } }
        // For Rom Signature
        private static bool locked = false;
        private static bool published = false;
        public static bool Locked
        {
            get { return locked; }
            set { locked = value; }
        } // Indicates that rom is locked and cannot be edited, not for public static use
        public static bool Published
        {
            get { return published; }
            set { published = value; }
        } // If true, show Author Splash screen on load
        private static long numBytes = 0;
        private static string fileName;
        private static Settings settings = Settings.Default;
        private static NotesDB notes;
        public static NotesDB Notes
        {
            get { return notes; }
            set { notes = value; }
        }
        private static byte[] dataHash;
        public static byte[] DataHash { get { return dataHash; } set { dataHash = value; } }
        private static long checkSum = 0;
        public static string History
        {
            get
            {
                return settings.History;
            }
            set
            {
                StringReader reader = new StringReader(value);
                string lines = "";
                string line;
                for (int i = 0; i < 256 && (line = reader.ReadLine()) != null; i++)
                    lines += line + "\r\n";
                settings.History = lines;
            }
        }
        #region Audio
        private static BRRSample[] audioSamples;
        public static BRRSample[] AudioSamples
        {
            get
            {
                if (audioSamples == null)
                {
                    audioSamples = new BRRSample[116];
                    for (int i = 0; i < audioSamples.Length; i++)
                        audioSamples[i] = new BRRSample(data, i);
                }
                return audioSamples;
            }
            set { audioSamples = value; }
        }
        private static SPC[] spcs;
        public static SPC[] SPCs
        {
            get
            {
                if (spcs == null)
                {
                    spcs = new SPC[73];
                    for (int i = 0; i < spcs.Length; i++)
                        spcs[i] = new SPC(data, i);
                }
                return spcs;
            }
            set { spcs = value; }
        }
        #endregion
        #region Battlefields
        private static byte[][] tileSetsBF = new byte[64][];
        public static byte[][] TileSetsBF
        {
            get
            {
                if (tileSetsBF[0] == null)
                    Decompress(tileSetsBF, 0x150000, 0x160000, 0x2000, "BATTLEFIELD TILE SET", true);
                return tileSetsBF;
            }
            set { tileSetsBF = value; }
        }
        public static bool[] EditTileSetsBF = new bool[64];
        private static Battlefield[] battlefields;
        private static PaletteSet[] paletteSetsBF;
        public static Battlefield[] Battlefields
        {
            get
            {
                if (battlefields == null)
                {
                    battlefields = new Battlefield[64];
                    for (int i = 0; i < battlefields.Length; i++)
                        battlefields[i] = new Battlefield(data, i);
                }
                return battlefields;
            }
            set { battlefields = value; }
        }
        public static PaletteSet[] PaletteSetsBF
        {
            get
            {
                if (paletteSetsBF == null)
                {
                    paletteSetsBF = new PaletteSet[57];
                    for (int i = 0; i < paletteSetsBF.Length; i++)
                        paletteSetsBF[i] = new PaletteSet(data, i, (i * 0xB6) + 0x34CFC4, 8, 16, 30);
                }
                return paletteSetsBF;
            }
            set { paletteSetsBF = value; }
        }
        #endregion
        #region Dialogues
        private static Bitmap battleDialogueTilesetImage;
        private static BattleDialogueTileset battleDialogueTileset;
        private static byte[] battleDialogueTileSet;
        private static byte[] dialogueGraphics;
        public static Bitmap BattleDialogueTilesetImage
        {
            get
            {
                if (battleDialogueTilesetImage == null)
                    battleDialogueTilesetImage = new Bitmap(Do.PixelsToImage(
                        Do.TilesetToPixels(BattleDialogueTileset.TileSetLayer,
                        16, 2, 0, false), 256, 32));
                return battleDialogueTilesetImage;
            }
            set
            {
                battleDialogueTilesetImage = value;
            }
        }
        public static BattleDialogueTileset BattleDialogueTileset
        {
            get
            {
                if (battleDialogueTileset == null)
                    battleDialogueTileset = new BattleDialogueTileset(
                        DialogueGraphics, BattleDialogueTileSet, FontPaletteDialogue);
                return battleDialogueTileset;
            }
            set { battleDialogueTileset = value; }
        }
        public static byte[] BattleDialogueTileSet
        {
            get
            {
                if (battleDialogueTileSet == null)
                    battleDialogueTileSet = Bits.GetByteArray(data, 0x015943, 0x100);
                return battleDialogueTileSet;
            }
            set { battleDialogueTileSet = value; }
        }
        public static byte[] DialogueGraphics
        {
            get
            {
                if (dialogueGraphics == null)
                    dialogueGraphics = Bits.GetByteArray(data, 0x3DF000, 0x700);
                return dialogueGraphics;
            }
            set { dialogueGraphics = value; }
        }
        private static BattleDialogue[] battleDialogues;
        private static BattleDialogue[] battleMessages;
        private static Dialogue[] dialogues;
        public static BattleDialogue[] BattleDialogues
        {
            get
            {
                if (battleDialogues == null)
                {
                    battleDialogues = new BattleDialogue[256];
                    for (int i = 0; i < battleDialogues.Length; i++)
                        battleDialogues[i] = new BattleDialogue(data, i, 0);
                }
                return battleDialogues;
            }
            set { battleDialogues = value; }
        }
        public static BattleDialogue[] BattleMessages
        {
            get
            {
                if (battleMessages == null)
                {
                    battleMessages = new BattleDialogue[46];
                    for (int i = 0; i < battleMessages.Length; i++)
                        battleMessages[i] = new BattleDialogue(data, i, 1);
                }
                return battleMessages;
            }
            set { battleMessages = value; }
        }
        public static Dialogue[] Dialogues
        {
            get
            {
                if (dialogues == null)
                {
                    // create dialogues
                    dialogues = new Dialogue[4096];
                    for (int i = 0; i < dialogues.Length; i++)
                        dialogues[i] = new Dialogue(data, i);
                }
                return dialogues;
            }
            set { dialogues = value; }
        }
        public static Dialogue[] GetDialogues(int start, int end)
        {
            if (dialogues != null)
                return dialogues;
            // create dialogues
            Dialogue[] temp = new Dialogue[end - start];
            for (int i = start; i < end; i++)
                temp[i] = new Dialogue(data, i);
            return temp;
        }
        private static DialogueTable[] dialogueTables;
        public static DialogueTable[] DialogueTables
        {
            get
            {
                if (dialogueTables == null)
                {
                    // create dialogues
                    dialogueTables = new DialogueTable[10];
                    for (int i = 0; i < dialogueTables.Length; i++)
                        dialogueTables[i] = new DialogueTable(data, i);
                }
                return dialogueTables;
            }
            set { dialogueTables = value; }
        }
        #endregion
        #region Effects
        private static Effect[] effects;
        private static E_Animation[] e_animations;
        public static Effect[] Effects
        {
            get
            {
                if (effects == null)
                {
                    // there is an effect animation with the incorrect data block length
                    if (data[0x331EB2] == 0x85)
                        data[0x331EB2] = 0x86;
                    effects = new Effect[128];
                    for (int i = 0; i < effects.Length; i++)
                        effects[i] = new Effect(data, i);
                }
                return effects;
            }
            set { effects = value; }
        }
        public static E_Animation[] E_animations
        {
            get
            {
                if (e_animations == null)
                {
                    e_animations = new E_Animation[64];
                    for (int i = 0; i < e_animations.Length; i++)
                        e_animations[i] = new E_Animation(data, i);
                }
                return e_animations;
            }
            set { e_animations = value; }
        }
        #endregion
        #region Fonts
        private static FontCharacter[] fontDialogue;
        private static FontCharacter[] fontMenu;
        private static FontCharacter[] fontDescription;
        private static FontCharacter[] fontTriangle;
        private static PaletteSet fontPaletteDialogue;
        private static PaletteSet fontPaletteBattle;
        private static PaletteSet fontPaletteMenu;
        public static FontCharacter[] FontDialogue
        {
            get
            {
                if (fontDialogue == null)
                {
                    fontDialogue = new FontCharacter[128];
                    for (int i = 0; i < fontDialogue.Length; i++)
                        fontDialogue[i] = new FontCharacter(data, i, 1);
                }
                return fontDialogue;
            }
            set { fontDialogue = value; }
        }
        public static FontCharacter[] FontMenu
        {
            get
            {
                if (fontMenu == null)
                {
                    fontMenu = new FontCharacter[128];
                    for (int i = 0; i < fontMenu.Length; i++)
                        fontMenu[i] = new FontCharacter(data, i, 0);
                }
                return fontMenu;
            }
            set { fontMenu = value; }
        }
        public static FontCharacter[] FontDescription
        {
            get
            {
                if (fontDescription == null)
                {
                    fontDescription = new FontCharacter[128];
                    for (int i = 0; i < fontDescription.Length; i++)
                        fontDescription[i] = new FontCharacter(data, i, 2);
                }
                return fontDescription;
            }
            set { fontDescription = value; }
        }
        public static FontCharacter[] FontTriangle
        {
            get
            {
                if (fontTriangle == null)
                {
                    fontTriangle = new FontCharacter[14];
                    for (int i = 0; i < fontTriangle.Length; i++)
                        fontTriangle[i] = new FontCharacter(data, i, 3);
                }
                return fontTriangle;
            }
            set { fontTriangle = value; }
        }
        public static PaletteSet FontPaletteDialogue
        {
            get
            {
                if (fontPaletteDialogue == null)
                    fontPaletteDialogue = new PaletteSet(data, 0, 0x3DFEE0, 2, 16, 32);
                return fontPaletteDialogue;
            }
            set { fontPaletteDialogue = value; }
        }
        public static PaletteSet FontPaletteBattle
        {
            get
            {
                if (fontPaletteBattle == null)
                    fontPaletteBattle = new PaletteSet(data, 0, 0x01EF40, 1, 16, 32);
                return fontPaletteBattle;
            }
            set { fontPaletteBattle = value; }
        }
        public static PaletteSet FontPaletteMenu
        {
            get
            {
                if (fontPaletteMenu == null)
                    fontPaletteMenu = new PaletteSet(MenuPalettes, 0, 0, 1, 16, 32);
                return fontPaletteMenu;
            }
            set { palettes = value; }
        }
        #endregion
        #region Levels
        // compressed data
        private static byte[][] graphicSets = new byte[272][];
        private static byte[][] tileSets = new byte[125][];
        private static byte[][] tileMaps = new byte[309][];
        private static byte[][] solidityMaps = new byte[120][];
        public static byte[][] GraphicSets
        {
            get
            {
                if (graphicSets[0] == null)
                    Decompress(graphicSets, 0x0A0000, 0x150000, 0x2000, "GRAPHIC SET", true);
                return graphicSets;
            }
            set { graphicSets = value; }
        }
        public static byte[][] Tilesets
        {
            get
            {
                if (tileSets[0] == null)
                    Decompress(tileSets, 0x3B0000, 0x3E0000, 0x1000, "TILE SET", true);
                return tileSets;
            }
            set { tileSets = value; }
        }
        public static byte[][] Tilemaps
        {
            get
            {
                if (tileMaps[0] == null)
                    Decompress(tileMaps, 0x160000, 0x1B0000, 0x1000, 0x2000, "TILE MAP", 0x40, true);
                return tileMaps;
            }
            set { tileMaps = value; }
        }
        public static byte[][] SolidityMaps
        {
            get
            {
                if (solidityMaps[0] == null)
                    Decompress(solidityMaps, 0x1B0000, 0x1D0000, 0x20C2, "SOLIDITY MAP", true);
                return solidityMaps;
            }
            set { solidityMaps = value; }
        }
        public static bool[] EditGraphicSets = new bool[272];
        public static bool[] EditTileSets = new bool[125];
        public static bool[] EditTileMaps = new bool[309];
        public static bool[] EditSolidityMaps = new bool[120];
        // properties
        private static Level[] levels;
        private static LevelMap[] levelMaps;
        private static PaletteSet[] paletteSets;
        private static PrioritySet[] prioritySets;
        private static SolidityTile[] solidTiles;
        private static NPCProperties[] npcProperties;
        private static NPCSpritePartitions[] npcSpritePartitions;
        private static OverlapTileset overlapTileset;
        public static Level[] Levels
        {
            get
            {
                if (levels == null)
                {
                    levels = new Level[512];
                    for (int i = 0; i < levels.Length; i++)
                        levels[i] = new Level(data, i);
                }
                return levels;
            }
            set { levels = value; }
        }
        public static LevelMap[] LevelMaps
        {
            get
            {
                if (levelMaps == null)
                {
                    levelMaps = new LevelMap[156];
                    for (int i = 0; i < levelMaps.Length; i++)
                        levelMaps[i] = new LevelMap(data, i);
                }
                return levelMaps;
            }
            set { levelMaps = value; }
        }
        public static PaletteSet[] PaletteSets
        {
            get
            {
                if (paletteSets == null)
                {
                    paletteSets = new PaletteSet[94];
                    for (int i = 0; i < paletteSets.Length; i++)
                        paletteSets[i] = new PaletteSet(data, i, (i * 0xD4) + 0x249FE2, 8, 16, 30);
                }
                return paletteSets;
            }
            set { paletteSets = value; }
        }
        public static PrioritySet[] PrioritySets
        {
            get
            {
                if (prioritySets == null)
                {
                    prioritySets = new PrioritySet[16];
                    for (int i = 0; i < prioritySets.Length; i++)
                        prioritySets[i] = new PrioritySet(data, i);
                }
                return prioritySets;
            }
            set { prioritySets = value; }
        }
        public static SolidityTile[] SolidTiles
        {
            get
            {
                if (solidTiles == null)
                {
                    solidTiles = new SolidityTile[1024];
                    for (int i = 0; i < solidTiles.Length; i++)
                        solidTiles[i] = new SolidityTile(data, i);
                }
                return solidTiles;
            }
            set { solidTiles = value; }
        }
        public static NPCProperties[] NPCProperties
        {
            get
            {
                if (npcProperties == null)
                {
                    npcProperties = new NPCProperties[512];
                    for (int i = 0; i < npcProperties.Length; i++)
                        npcProperties[i] = new NPCProperties(data, i);
                }
                return npcProperties;
            }
            set { npcProperties = value; }
        }
        public static NPCSpritePartitions[] NPCSpritePartitions
        {
            get
            {
                if (npcSpritePartitions == null)
                {
                    npcSpritePartitions = new NPCSpritePartitions[120];
                    for (int i = 0; i < npcSpritePartitions.Length; i++)
                        npcSpritePartitions[i] = new NPCSpritePartitions(data, i);
                }
                return npcSpritePartitions;
            }
        }
        public static OverlapTileset OverlapTileset
        {
            get
            {
                if (overlapTileset == null)
                    overlapTileset = new OverlapTileset();
                return overlapTileset;
            }
        }
        #endregion
        #region Menus
        private static byte[] menuBGGraphics;
        private static byte[] menuBGTileset;
        private static byte[] menuFrameGraphics;
        private static byte[] menuCursorGraphics;
        private static byte[] menuPalettes;
        private static PaletteSet cursorPaletteSet;
        public static byte[] MenuBGGraphics
        {
            get
            {
                if (menuBGGraphics == null)
                    menuBGGraphics = Comp.Decompress(data, 0x3E0E69, 0x2000);
                return menuBGGraphics;
            }
            set { menuBGGraphics = value; }
        }
        public static byte[] MenuFrameGraphics
        {
            get
            {
                if (menuFrameGraphics == null)
                    menuFrameGraphics = Comp.Decompress(data, 0x3E2607, 0x200);
                return menuFrameGraphics;
            }
            set { menuFrameGraphics = value; }
        }
        public static byte[] MenuCursorGraphics
        {
            get
            {
                if (menuCursorGraphics == null)
                    menuCursorGraphics = Comp.Decompress(data, 0x3E269E, 0x400);
                return menuCursorGraphics;
            }
            set { menuCursorGraphics = value; }
        }
        public static byte[] MenuBGTileset
        {
            get
            {
                if (menuBGTileset == null)
                    menuBGTileset = Comp.Decompress(data, 0x3E286A, 0x800);
                return menuBGTileset;
            }
            set { menuBGTileset = value; }
        }
        public static byte[] MenuPalettes
        {
            get
            {
                if (menuPalettes == null)
                    menuPalettes = Comp.Decompress(data, 0x3E2D54, 0x200);
                return menuPalettes;
            }
            set { menuPalettes = value; }
        }
        public static PaletteSet CursorPaletteSet
        {
            get
            {
                if (cursorPaletteSet == null)
                    cursorPaletteSet = new PaletteSet(MenuPalettes, 8, 0x100, 1, 16, 32);
                return cursorPaletteSet;
            }
            set { palettes = value; }
        }
        public static bool EditMenuTileSet;
        private static PaletteSet menuFramePalette;
        public static PaletteSet MenuFramePalette
        {
            get
            {
                if (menuFramePalette == null)
                    menuFramePalette = new PaletteSet(data, 0, 0x24C83A, 1, 16, 30);
                return menuFramePalette;
            }
            set { menuFramePalette = value; }
        }
        private static PaletteSet menuBGPalette;
        public static PaletteSet MenuBGPalette
        {
            get
            {
                if (menuBGPalette == null)
                    menuBGPalette = new PaletteSet(data, 0, 0x3E9A28, 1, 16, 32);
                return menuBGPalette;
            }
            set { menuBGPalette = value; }
        }
        private static Bitmap menuBG;
        public static Bitmap MenuBG
        {
            get
            {
                if (menuBG == null)
                    menuBG = Do.PixelsToImage(
                        Do.TilesetToPixels(
                        new MenuTileset(MenuBGPalette, MenuBGTileset, MenuBGGraphics).Tileset, 16, 16, 0, false), 256, 256);
                return menuBG;
            }
            set { menuBG = value; }
        }
        public static Bitmap MenuBG_
        {
            get
            {
                return MenuBG.Clone(new Rectangle(0, 0, 256, 255), System.Drawing.Imaging.PixelFormat.DontCare);
            }
        }
        public static Bitmap MenuBG__(int width, int height)
        {
            if (width > 256) width = 256;
            if (height > 256) height = 256;
            return MenuBG.Clone(new Rectangle(0, 0, width, height), System.Drawing.Imaging.PixelFormat.DontCare);
        }
        //
        private static byte[] gameSelectGraphics;
        private static byte[] gameSelectPalettes;
        private static PaletteSet gameSelectPaletteSet;
        private static byte[] gameSelectTileset;
        private static byte[] gameSelectSpeakers;
        public static byte[] GameSelectGraphics
        {
            get
            {
                if (gameSelectGraphics == null)
                    gameSelectGraphics = Comp.Decompress(data, 0x3E9A4A, 0x2000);
                return gameSelectGraphics;
            }
            set { gameSelectGraphics = value; }
        }
        public static byte[] GameSelectPalettes
        {
            get
            {
                if (gameSelectPalettes == null)
                    gameSelectPalettes = Comp.Decompress(data, 0x3EB510, 0x200);
                return gameSelectPalettes;
            }
            set { gameSelectPalettes = value; }
        }
        public static byte[] GameSelectTileset
        {
            get
            {
                if (gameSelectTileset == null)
                    gameSelectTileset = Comp.Decompress(data, 0x3EB2CE, 0x800);
                return gameSelectTileset;
            }
            set { gameSelectTileset = value; }
        }
        public static PaletteSet GameSelectPaletteSet
        {
            get
            {
                if (gameSelectPaletteSet == null)
                    gameSelectPaletteSet = new PaletteSet(GameSelectPalettes, 0, 0, 16, 16, 32);
                return gameSelectPaletteSet;
            }
            set { gameSelectPaletteSet = value; }
        }
        public static byte[] GameSelectSpeakers
        {
            get
            {
                if (gameSelectSpeakers == null)
                    gameSelectSpeakers = Comp.Decompress(data, 0x3EB625, 0x600);
                return gameSelectSpeakers;
            }
            set { gameSelectSpeakers = value; }
        }
        #endregion
        #region Mini-Games
        // minecart game
        private static byte[] minecartM7Graphics;
        private static byte[] minecartM7TilesetSubtiles;
        private static byte[] minecartM7Palettes;
        private static byte[] minecartM7TilesetPalettes;
        private static PaletteSet minecartM7PaletteSet;
        private static byte[] minecartM7TilemapA;
        private static byte[] minecartM7TilemapB;
        private static byte[] minecartM7TilesetBG;
        private static byte[] minecartObjectGraphics;
        private static byte[] minecartObjectPalettes;
        private static PaletteSet minecartObjectPaletteSet;
        private static byte[] minecartSSGraphics;
        private static byte[] minecartSSTileset;
        private static byte[] minecartSSBGTileset;
        private static byte[] minecartSSPalettes;
        private static PaletteSet minecartSSPaletteSet;
        private static byte[] minecartSSTilemap;
        private static byte[] minecartObjects;
        // accessors
        public static byte[] MinecartM7Graphics
        {
            get
            {
                if (minecartM7Graphics == null)
                    minecartM7Graphics = Decompress(data, 0x388000, 0x388000, 0x2000);
                return minecartM7Graphics;
            }
            set { minecartM7Graphics = value; }
        }
        public static byte[] MinecartM7TilesetSubtiles
        {
            get
            {
                if (minecartM7TilesetSubtiles == null)
                    minecartM7TilesetSubtiles = Decompress(data, 0x388002, 0x388000, 0x400);
                return minecartM7TilesetSubtiles;
            }
            set { minecartM7TilesetSubtiles = value; }
        }
        public static byte[] MinecartM7Palettes
        {
            get
            {
                if (minecartM7Palettes == null)
                    minecartM7Palettes = Decompress(data, 0x388004, 0x388000, 0x100);
                return minecartM7Palettes;
            }
            set { minecartM7Palettes = value; }
        }
        public static byte[] MinecartM7TilesetPalettes
        {
            get
            {
                if (minecartM7TilesetPalettes == null)
                    minecartM7TilesetPalettes = Decompress(data, 0x388006, 0x388000, 0x100);
                return minecartM7TilesetPalettes;
            }
            set { minecartM7TilesetPalettes = value; }
        }
        public static PaletteSet MinecartM7PaletteSet
        {
            get
            {
                if (minecartM7PaletteSet == null)
                    minecartM7PaletteSet = new PaletteSet(MinecartM7Palettes, 0, 0, 8, 16, 32);
                return minecartM7PaletteSet;
            }
            set { minecartM7PaletteSet = value; }
        }
        public static byte[] MinecartM7TilemapA
        {
            get
            {
                if (minecartM7TilemapA == null)
                    minecartM7TilemapA = Decompress(data, 0x388008, 0x388000, 0x1000);
                return minecartM7TilemapA;
            }
            set { minecartM7TilemapA = value; }
        }
        public static byte[] MinecartM7TilemapB
        {
            get
            {
                if (minecartM7TilemapB == null)
                    minecartM7TilemapB = Decompress(data, 0x38800A, 0x388000, 0x1000);
                return minecartM7TilemapB;
            }
            set { minecartM7TilemapB = value; }
        }
        public static byte[] MinecartM7TilesetBG
        {
            get
            {
                if (minecartM7TilesetBG == null)
                    minecartM7TilesetBG = Decompress(data, 0x38800C, 0x388000, 0x800);
                return minecartM7TilesetBG;
            }
            set { minecartM7TilesetBG = value; }
        }
        public static byte[] MinecartObjectGraphics
        {
            get
            {
                if (minecartObjectGraphics == null)
                    minecartObjectGraphics = Decompress(data, 0x38800E, 0x388000, 0x800);
                return minecartObjectGraphics;
            }
            set { minecartObjectGraphics = value; }
        }
        public static byte[] MinecartObjectPalettes
        {
            get
            {
                if (minecartObjectPalettes == null)
                    minecartObjectPalettes = Decompress(data, 0x388010, 0x388000, 0x40);
                return minecartObjectPalettes;
            }
            set { minecartObjectPalettes = value; }
        }
        public static PaletteSet MinecartObjectPaletteSet
        {
            get
            {
                if (minecartObjectPaletteSet == null)
                    minecartObjectPaletteSet = new PaletteSet(MinecartObjectPalettes, 0, 0, 2, 16, 32);
                return minecartObjectPaletteSet;
            }
            set { minecartObjectPaletteSet = value; }
        }
        public static byte[] MinecartSSTilemap
        {
            get
            {
                if (minecartSSTilemap == null)
                    minecartSSTilemap = Decompress(data, 0x388012, 0x388000, 0x1000);
                return minecartSSTilemap;
            }
            set { minecartSSTilemap = value; }
        }
        public static byte[] MinecartSSGraphics
        {
            get
            {
                if (minecartSSGraphics == null)
                    minecartSSGraphics = Decompress(data, 0x388014, 0x388000, 0x4000);
                return minecartSSGraphics;
            }
            set { minecartSSGraphics = value; }
        }
        public static byte[] MinecartSSTileset
        {
            get
            {
                if (minecartSSTileset == null)
                    minecartSSTileset = Decompress(data, 0x388016, 0x388000, 0x800);
                return minecartSSTileset;
            }
            set { minecartSSTileset = value; }
        }
        public static byte[] MinecartSSPalettes
        {
            get
            {
                if (minecartSSPalettes == null)
                    minecartSSPalettes = Decompress(data, 0x388018, 0x388000, 0x100);
                return minecartSSPalettes;
            }
            set { minecartSSPalettes = value; }
        }
        public static PaletteSet MinecartSSPaletteSet
        {
            get
            {
                if (minecartSSPaletteSet == null)
                    minecartSSPaletteSet = new PaletteSet(MinecartSSPalettes, 0, 0, 8, 16, 32);
                return minecartSSPaletteSet;
            }
            set { minecartSSPaletteSet = value; }
        }
        public static byte[] MinecartSSBGTileset
        {
            get
            {
                if (minecartSSBGTileset == null)
                    minecartSSBGTileset = Decompress(data, 0x38801A, 0x388000, 0x1000);
                return minecartSSBGTileset;
            }
            set { minecartSSBGTileset = value; }
        }
        public static byte[] MinecartObjects
        {
            get
            {
                if (minecartObjects == null)
                {
                    byte[] temp = new byte[0x1000];
                    int offset = Bits.GetShort(data, 0x38801C) + 0x388000;
                    int size = Comp.Decompress(data, temp, offset + 1, 0x1000);
                    minecartObjects = new byte[size];
                    Buffer.BlockCopy(temp, 0, minecartObjects, 0, size);
                }
                return minecartObjects;
            }
            set { minecartObjects = value; }
        }
        #endregion
        #region Scripts
        private static BattleScript[] battleScripts;
        private static EventScript[] eventScripts;
        private static ActionQueue[] actionScripts;
        private static AnimationScript[] spellAnimMonsters;
        private static AnimationScript[] spellAnimAllies;
        private static AnimationScript[] attackAnimations;
        private static AnimationScript[] itemAnimations;
        private static AnimationScript[] battleEvents;
        private static AnimationScript[] behaviorAnimations;
        private static AnimationScript[] entranceAnimations;
        private static AnimationScript[] weaponAnimations;
        public static BattleScript[] BattleScripts
        {
            get
            {
                if (battleScripts == null)
                {
                    battleScripts = new BattleScript[256];
                    for (int i = 0; i < battleScripts.Length; i++)
                        battleScripts[i] = new BattleScript(data, i);
                }
                return battleScripts;
            }
            set { battleScripts = value; }
        }
        public static EventScript[] EventScripts
        {
            get
            {
                if (eventScripts == null)
                {
                    eventScripts = new EventScript[4096];
                    for (int i = 0; i < eventScripts.Length; i++)
                        eventScripts[i] = new EventScript(data, i);
                }
                return eventScripts;
            }
            set { eventScripts = value; }
        }
        public static ActionQueue[] ActionScripts
        {
            get
            {
                if (actionScripts == null)
                {
                    actionScripts = new ActionQueue[1024];
                    for (int i = 0; i < actionScripts.Length; i++)
                        actionScripts[i] = new ActionQueue(data, i);
                }
                return actionScripts;
            }
            set { actionScripts = value; }
        }
        public static AnimationScript[] SpellAnimMonsters
        {
            get
            {
                if (spellAnimMonsters == null)
                {
                    spellAnimMonsters = new AnimationScript[45];
                    for (int i = 0; i < spellAnimMonsters.Length; i++)
                        spellAnimMonsters[i] = new AnimationScript(data, i, 1);
                }
                return spellAnimMonsters;
            }
            set { spellAnimMonsters = value; }
        }
        public static AnimationScript[] SpellAnimAllies
        {
            get
            {
                if (spellAnimAllies == null)
                {
                    spellAnimAllies = new AnimationScript[27];
                    for (int i = 0; i < spellAnimAllies.Length; i++)
                        spellAnimAllies[i] = new AnimationScript(data, i, 5);
                }
                return spellAnimAllies;
            }
            set { spellAnimAllies = value; }
        }
        public static AnimationScript[] AttackAnimations
        {
            get
            {
                if (attackAnimations == null)
                {
                    attackAnimations = new AnimationScript[129];
                    for (int i = 0; i < attackAnimations.Length; i++)
                        attackAnimations[i] = new AnimationScript(data, i, 3);
                }
                return attackAnimations;
            }
            set { attackAnimations = value; }
        }
        public static AnimationScript[] ItemAnimations
        {
            get
            {
                if (itemAnimations == null)
                {
                    itemAnimations = new AnimationScript[81];
                    for (int i = 0; i < itemAnimations.Length; i++)
                        itemAnimations[i] = new AnimationScript(data, i, 4);
                }
                return itemAnimations;
            }
            set { itemAnimations = value; }
        }
        public static AnimationScript[] BattleEvents
        {
            get
            {
                if (battleEvents == null)
                {
                    battleEvents = new AnimationScript[102];
                    for (int i = 0; i < battleEvents.Length; i++)
                        battleEvents[i] = new AnimationScript(data, i, 7);
                }
                return battleEvents;
            }
            set { battleEvents = value; }
        }
        public static AnimationScript[] BehaviorAnimations
        {
            get
            {
                if (behaviorAnimations == null)
                {
                    behaviorAnimations = new AnimationScript[54];
                    for (int i = 0; i < behaviorAnimations.Length; i++)
                        behaviorAnimations[i] = new AnimationScript(data, i, 0);
                }
                return behaviorAnimations;
            }
            set { behaviorAnimations = value; }
        }
        public static AnimationScript[] EntranceAnimations
        {
            get
            {
                if (entranceAnimations == null)
                {
                    entranceAnimations = new AnimationScript[16];
                    for (int i = 0; i < entranceAnimations.Length; i++)
                        entranceAnimations[i] = new AnimationScript(data, i, 2);
                }
                return entranceAnimations;
            }
            set { entranceAnimations = value; }
        }
        public static AnimationScript[] WeaponAnimations
        {
            get
            {
                if (weaponAnimations == null)
                {
                    weaponAnimations = new AnimationScript[36];
                    for (int i = 0; i < weaponAnimations.Length; i++)
                        weaponAnimations[i] = new AnimationScript(data, i, 6);
                }
                return weaponAnimations;
            }
            set { weaponAnimations = value; }
        }
        #endregion
        #region Sprites
        private static Sprite[] sprites;
        private static GraphicPalette[] graphicPalettes;
        private static Animation[] animations;
        private static PaletteSet[] spritePalettes;
        private static byte[] spriteGraphics;
        public static Sprite[] Sprites
        {
            get
            {
                if (sprites == null)
                {
                    sprites = new Sprite[1024];
                    for (int i = 0; i < sprites.Length; i++)
                        sprites[i] = new Sprite(data, i);
                }
                return sprites;
            }
            set { sprites = value; }
        }
        public static GraphicPalette[] GraphicPalettes
        {
            get
            {
                if (graphicPalettes == null)
                {
                    graphicPalettes = new GraphicPalette[512];
                    for (int i = 0; i < graphicPalettes.Length; i++)
                        graphicPalettes[i] = new GraphicPalette(data, i);
                }
                return graphicPalettes;
            }
            set { graphicPalettes = value; }
        }
        public static Animation[] Animations
        {
            get
            {
                if (animations == null)
                {
                    animations = new Animation[444];
                    for (int i = 0; i < animations.Length; i++)
                        animations[i] = new Animation(data, i);
                }
                return animations;
            }
            set { animations = value; }
        }
        public static PaletteSet[] SpritePalettes
        {
            get
            {
                if (spritePalettes == null)
                {
                    spritePalettes = new PaletteSet[819];
                    for (int i = 0; i < spritePalettes.Length; i++)
                        spritePalettes[i] = new PaletteSet(data, i, 0x252FFE + (i * 30), 1, 16, 30);
                }
                return spritePalettes;
            }
            set { spritePalettes = value; }
        }
        public static byte[] SpriteGraphics
        {
            get
            {
                if (spriteGraphics == null)
                    spriteGraphics = Bits.GetByteArray(data, 0x280000, 0xB4000);
                return spriteGraphics;
            }
            set { spriteGraphics = value; }
        }
        #endregion
        #region Stats
        private static Attack[] attacks;
        private static Character[] characters;
        private static Formation[] formations;
        private static FormationPack[] formationPacks;
        private static byte[] formationMusics;
        private static Item[] items;
        private static Monster[] monsters;
        private static Shop[] shops;
        private static Slot[] slots;
        private static Spell[] spells;
        public static Attack[] Attacks
        {
            get
            {
                if (attacks == null)
                {
                    attacks = new Attack[129];
                    for (int i = 0; i < attacks.Length; i++)
                        attacks[i] = new Attack(data, i);
                }
                return attacks;
            }
            set { attacks = value; }
        }
        public static Character[] Characters
        {
            get
            {
                if (characters == null)
                {
                    characters = new Character[5];
                    for (int i = 0; i < characters.Length; i++)
                        characters[i] = new Character(data, i);
                }
                return characters;
            }
            set { characters = value; }
        }
        public static Formation[] Formations
        {
            get
            {
                if (formations == null)
                {
                    formations = new Formation[512];
                    for (int i = 0; i < formations.Length; i++)
                        formations[i] = new Formation(data, i);
                }
                return formations;
            }
            set { formations = value; }
        }
        public static FormationPack[] FormationPacks
        {
            get
            {
                if (formationPacks == null)
                {
                    formationPacks = new FormationPack[256];
                    for (int i = 0; i < formationPacks.Length; i++)
                        formationPacks[i] = new FormationPack(data, i);
                }
                return formationPacks;
            }
            set { formationPacks = value; }
        }
        public static byte[] FormationMusics
        {
            get
            {
                if (formationMusics == null)
                {
                    formationMusics = new byte[8];
                    for (int i = 0; i < formationMusics.Length; i++)
                        formationMusics[i] = data[0x029F51 + i];
                }
                return formationMusics;
            }
            set { formationMusics = value; }
        }
        public static Item[] Items
        {
            get
            {
                if (items == null)
                {
                    items = new Item[256];
                    for (int i = 0; i < items.Length; i++)
                        items[i] = new Item(data, i);
                }
                return items;
            }
            set { items = value; }
        }
        public static Monster[] Monsters
        {
            get
            {
                if (monsters == null)
                {
                    monsters = new Monster[256];
                    for (int i = 0; i < monsters.Length; i++)
                        monsters[i] = new Monster(data, i);
                }
                return monsters;
            }
            set { monsters = value; }
        }
        public static Shop[] Shops
        {
            get
            {
                if (shops == null)
                {
                    shops = new Shop[33];
                    for (int i = 0; i < shops.Length; i++)
                        shops[i] = new Shop(data, i);
                }
                return shops;
            }
            set { shops = value; }
        }
        public static Slot[] Slots
        {
            get
            {
                if (slots == null)
                {
                    slots = new Slot[30];
                    for (int i = 0; i < slots.Length; i++)
                        slots[i] = new Slot(data, i);
                }
                return slots;
            }
            set { slots = value; }
        }
        public static Spell[] Spells
        {
            get
            {
                if (spells == null)
                {
                    spells = new Spell[128];
                    for (int i = 0; i < spells.Length; i++)
                        spells[i] = new Spell(data, i);
                }
                return spells;
            }
            set { spells = value; }
        }
        #endregion
        #region Stats Names
        private static DDlistName monsterNames;
        private static DDlistName spellNames;
        private static DDlistName attackNames;
        private static DDlistName itemNames;
        public static DDlistName MonsterNames
        {
            get
            {
                if (monsterNames == null)
                {
                    monsterNames = new DDlistName(Monsters);
                    monsterNames.SortAlpha();
                }
                return monsterNames;
            }
            set
            {
                monsterNames = value;
                if (monsterNames != null)
                    monsterNames.SortAlpha();
            }
        }
        public static DDlistName SpellNames
        {
            get
            {
                if (spellNames == null)
                {
                    spellNames = new DDlistName(Spells);
                    spellNames.SortAlpha();
                }
                return spellNames;
            }
            set
            {
                spellNames = value;
                if (spellNames != null)
                    spellNames.SortAlpha();
            }
        }
        public static DDlistName AttackNames
        {
            get
            {
                if (attackNames == null)
                {
                    attackNames = new DDlistName(Attacks);
                    attackNames.SortAlpha();
                }
                return attackNames;
            }
            set
            {
                attackNames = value;
                if (attackNames != null)
                    attackNames.SortAlpha();
            }
        }
        public static DDlistName ItemNames
        {
            get
            {
                if (itemNames == null)
                {
                    itemNames = new DDlistName(Items);
                    itemNames.SortAlpha();
                }
                return itemNames;
            }
            set
            {
                itemNames = value;
                if (itemNames != null)
                    itemNames.SortAlpha();
            }
        }
        #endregion
        #region Title
        private static byte[] titleData;
        private static TitleTileset titleTileSet;
        private static PaletteSet titlePalettes;
        private static PaletteSet titleSpritePalettes;
        private static byte[] titleSpriteGraphics;
        public static byte[] TitleData
        {
            get
            {
                if (titleData == null)
                    titleData = Comp.Decompress(data, 0x3F216F, 0xDA60);
                return titleData;
            }
            set { titleData = value; }
        }
        public static TitleTileset TitleTileSet
        {
            get
            {
                if (titleTileSet == null)
                    titleTileSet = new TitleTileset(TitlePalettes);
                return titleTileSet;
            }
            set { titleTileSet = value; }
        }
        public static PaletteSet TitlePalettes
        {
            get
            {
                if (titlePalettes == null)
                    titlePalettes = new PaletteSet(data, 0, 0x3F0088, 8, 16, 32);
                return titlePalettes;
            }
            set { titlePalettes = value; }
        }
        public static PaletteSet TitleSpritePalettes
        {
            get
            {
                if (titleSpritePalettes == null)
                    titleSpritePalettes = new PaletteSet(data, 0, 0x3F0188, 5, 16, 32);
                return titleSpritePalettes;
            }
            set { titleSpritePalettes = value; }
        }
        public static byte[] TitleSpriteGraphics
        {
            get
            {
                if (titleSpriteGraphics == null)
                    titleSpriteGraphics = Bits.GetByteArray(titleData, 0x2000, 0x4C00);
                return titleSpriteGraphics;
            }
            set { titleSpriteGraphics = value; }
        }
        #endregion
        #region World Maps
        private static WorldMap[] worldMaps;
        private static MapPoint[] mapPoints;
        private static PaletteSet palettes;
        private static byte[] worldMapGraphics;
        private static byte[] worldMapPalettes;
        private static byte[][] worldMapTileSets = new byte[9][];
        private static byte[] worldMapSprites;
        public static WorldMap[] WorldMaps
        {
            get
            {
                if (worldMaps == null)
                {
                    worldMaps = new WorldMap[9];
                    for (int i = 0; i < worldMaps.Length; i++)
                        worldMaps[i] = new WorldMap(data, i);
                }
                return worldMaps;
            }
            set { worldMaps = value; }
        }
        public static MapPoint[] MapPoints
        {
            get
            {
                if (mapPoints == null)
                {
                    mapPoints = new MapPoint[56];
                    for (int i = 0; i < mapPoints.Length; i++)
                        mapPoints[i] = new MapPoint(data, i);
                }
                return mapPoints;
            }
            set { mapPoints = value; }
        }
        public static PaletteSet Palettes
        {
            get
            {
                if (palettes == null)
                    palettes = new PaletteSet(WorldMapPalettes, 0, 0, 8, 16, 32);
                return palettes;
            }
            set { palettes = value; }
        }
        public static byte[] WorldMapGraphics
        {
            get
            {
                if (worldMapGraphics == null)
                    worldMapGraphics = Comp.Decompress(data, 0x3E2E82, 0x8000);
                return worldMapGraphics;
            }
            set { worldMapGraphics = value; }
        }
        public static byte[] WorldMapPalettes
        {
            get
            {
                if (worldMapPalettes == null)
                    worldMapPalettes = Comp.Decompress(data, 0x3E988D, 0x100);
                return worldMapPalettes;
            }
            set { worldMapPalettes = value; }
        }
        public static byte[][] WorldMapTileSets
        {
            get
            {
                if (worldMapTileSets[0] == null)
                {
                    for (int i = 0; i < 9; i++)
                    {
                        int pointer = Bits.GetShort(data, i * 2 + 0x3E0014);
                        int offset = 0x3E0000 + pointer + 1;
                        worldMapTileSets[i] = Comp.Decompress(data, offset, 0x800);
                    }
                }
                return worldMapTileSets;
            }
            set { worldMapTileSets = value; }
        }
        public static byte[] WorldMapSprites
        {
            get
            {
                if (worldMapSprites == null)
                    worldMapSprites = Comp.Decompress(data, 0x3E90A7, 0x400);
                return worldMapSprites;
            }
            set { worldMapSprites = value; }
        }
        #endregion
        #region Previewer
        #endregion
        // Constructor
        #region Functions
        #region File Handling
        public static bool VerifyRom()
        {
            if (!LAZYSHELL.Properties.Settings.Default.UnverifiedRomWarning) // If the warning is disabled, dont bother checking
                return true;

            // 32 bytes of SMRPG Rom Data at 0xF800
            byte[] original = new byte[]{0x0F,0x1A,0x4A,0x85,0x26,0x64,0x27,0x90,0x06,0xA5,0x28,0x9D,0x00,0x00,0xE8,0xC2,
                                         0x20,0xA5,0x28,0x9D,0x00,0x00,0xE8,0xE8,0xC6,0x26,0x10,0xF7,0xE2,0x20,0xC8,0x80};

            if (data.Length >= 0x400000)
            {
                if (Bits.Compare(original, Bits.GetByteArray(data, 0xF800, 32)))
                    return true;
            }
            return MessageBox.Show("file does not appear to be a Super Mario RPG rom. Use it anyways?", "LAZY SHELL", MessageBoxButtons.YesNo) == DialogResult.Yes;
        }
        public static void CalculateAndSetNewRomChecksum()
        {
            int check = 0;

            for (int i = 0; i < data.Length; i++)
                check += data[i];
            check &= 0xFFFF;

            Bits.SetShort(data, 0x007FDE, (ushort)check);
        }
        public static void CreateNewMD5Checksum()
        {
            MD5 md5Hasher = MD5.Create();

            if (data != null)
                dataHash = md5Hasher.ComputeHash(data);
        }
        public static string GameCode()
        {
            return ByteToStr(Bits.GetByteArray(data, 0x7FB2, 4));
        }
        public static string GetEditorNameWithoutPath()
        {
            int len = GetEditorPath().LastIndexOf('\\') + 1;
            return GetEditorPath().Substring(len, GetEditorPath().Length - len);
        }
        public static string GetEditorPath()
        {
            return Application.ExecutablePath;
        }
        public static string GetEditorPathWithoutFileName()
        {
            return GetEditorPath().Substring(0, GetEditorPath().LastIndexOf('\\') + 1);
        }
        public static string GetFileNameWithoutPath()
        {
            try
            {
                return fileName.Substring(fileName.LastIndexOf('\x5c') + 1);
            }
            catch
            {
                return null;
            }
        }
        public static string GetFileNameWithoutPathOrExtension()
        {
            string ret = fileName.Substring(fileName.LastIndexOf('\x5c') + 1);
            return ret.Substring(0, ret.LastIndexOf('.'));
        }
        public static long GetFileSize()
        {
            return numBytes;
        }
        public static string GetPathWithoutFileName()
        {
            return fileName.Substring(0, fileName.LastIndexOf('\x5c') + 1);
        }
        public static string GetRomName()
        {
            if (HeaderPresent())
                return ByteToStr(Bits.GetByteArray(data, 0x81c0, 21));
            return ByteToStr(Bits.GetByteArray(data, 0x7fc0, 21));
        }
        public static bool HeaderPresent()
        {
            if ((numBytes & (long)0x200) == 0x200)
                return true;
            else
                return false;
        }
        public static bool ReadRom()
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
                hexViewer = new HexEditor(data, Bits.Copy(data));
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Lazy Shell was unable to load the rom.\n\n" + e.Message,
                    "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Error);

                fileName = "Invalid File";
                return false;
            }

        }
        public static bool RemoveHeader()
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
            catch
            {
                MessageBox.Show("Error removing header, please remove manually", "LAZY SHELL");
                return false;
            }
        }
        public static string RomChecksum()
        {
            checkSum = 0;
            for (int i = 0; i < data.Length; i++)
                checkSum += data[i];
            checkSum &= 0xFFFF;

            if ((ushort)checkSum == Bits.GetShort(data, 0x007FDE))
                return "0x" + checkSum.ToString("X") + " (OK)";
            else
                return "0x" + checkSum.ToString("X") + " (FAIL)";
        }
        public static ushort RomChecksumBin()
        {
            checkSum = 0;
            for (int i = 0; i < data.Length; i++)
                checkSum += data[i];
            checkSum &= 0xFFFF;
            return (ushort)checkSum;
        }
        public static string FileName { get { return fileName; } set { fileName = value; } }
        public static bool VerifyMD5Checksum()
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
        public static bool WriteRom()
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
        private static string ByteToStr(byte[] toStr)
        {
            System.Text.Encoding encoding = System.Text.Encoding.UTF8;

            return encoding.GetString(toStr);
        }
        #endregion
        #region Compression
        /// <summary>
        /// 
        /// </summary>
        /// <param name="src">The source ROM.</param>
        /// <param name="pointerOffset">The offset of the pointer.</param>
        /// <param name="baseOffset">The offset to add the pointer to for the final offset.</param>
        /// <param name="maxSize">The uncompressed size of the array.</param>
        /// <returns></returns>
        public static byte[] Decompress(byte[] src, int pointerOffset, int baseOffset, int maxSize)
        {
            int offset = Bits.GetShort(src, pointerOffset) + baseOffset;
            return Comp.Decompress(src, offset + 1, maxSize);
        }
        /// <summary>
        /// Decompresses data to a collection of byte arrays.
        /// </summary>
        /// <param name="arrays">The byte arrays to store the decompressed data to.</param>
        /// <param name="bankStart">The bank where the compressed data begins.</param>
        /// <param name="bankEnd">The bank where the compressed data ends. bank is NOT included in the data.</param>
        /// <param name="decompressedSizeA">The decompressed size of each byte array.</param>
        /// <param name="decompressedSizeB">The second optional decompressed size of all byte arrays starting at indexB.</param>
        /// <param name="label">The label to use in the progress bar. All caps and singular.</param>
        /// <param name="indexB">The starting index of the arrays where decompressedSizeB will start being used.</param>
        public static void Decompress(byte[][] arrays, int bankStart, int bankEnd,
            int decompressedSizeA, int decompressedSizeB, string label, int indexB,
            int start, int end, bool showProgressBar)
        {
            ProgressBar progressBar = new ProgressBar(data, "DECOMPRESSING " + label + "S...", arrays.Length);
            if (showProgressBar)
                progressBar.Show();
            int bank = 0;
            for (int i = start, j = start; i < arrays.Length && i < end; i++)
            {
                j = i * 2;
                for (int k = bankStart; k < bankEnd; k += 0x010000)
                {
                    ushort temp = Bits.GetShort(data, k);
                    if (j >= temp)
                        j -= temp;
                    else
                    {
                        bank = k; break;
                    }
                }
                int pointer = Bits.GetShort(data, bank + j);
                int offset = bank + pointer + 1;
                if (i < indexB)
                    arrays[i] = Comp.Decompress(data, offset, decompressedSizeA);
                else
                    arrays[i] = Comp.Decompress(data, offset, decompressedSizeB);
                if (arrays[i] == null)
                    arrays[i] = new byte[decompressedSizeA];
                progressBar.PerformStep("DECOMPRESSING " + label + " #" + i.ToString("d" + arrays.Length.ToString().Length));
            }
            progressBar.Close();
        }
        public static void Decompress(byte[][] arrays, int bankStart, int bankEnd,
            int decompressedSizeA, int decompressedSizeB, string label, int indexB, bool showProgressBar)
        {
            Decompress(arrays, bankStart, bankEnd, decompressedSizeA, decompressedSizeB, label, indexB, 0, arrays.Length, showProgressBar);
        }
        public static void Decompress(byte[][] arrays, int bankStart, int bankEnd,
            int decompressedSize, string label, int start, int end, bool showProgressBar)
        {
            Decompress(arrays, bankStart, bankEnd, decompressedSize, decompressedSize, label, 0, start, end, showProgressBar);
        }
        public static void Decompress(byte[][] arrays, int bankStart, int bankEnd,
            int decompressedSize, string label, bool showProgressBar)
        {
            Decompress(arrays, bankStart, bankEnd, decompressedSize, decompressedSize, label, 0, 0, arrays.Length, showProgressBar);
        }
        /// <summary>
        /// Compresses a collection of arrays and stores the compressed results to the ROM.
        /// </summary>
        /// <param name="arrays">The arrays to compress.</param>
        /// <param name="edit">The conditions which determine whether or not to recompress an array.</param>
        /// <param name="bankStart">The bank where the compressed data begins.</param>
        /// <param name="lastOffset">The final offset in the ROM of the allocated data containing the compressed arrays.</param>
        /// <param name="label">The label to use in the progress bar. All caps and singular.</param>
        /// <param name="bankIndexes">Each parameter is the index at which the collection of arrays begins writing to that respective bank.
        /// ie. the first parameter is always 0, the second parameter is where the index begins in the second bank, etc.</param>
        public static void Compress(byte[][] arrays, bool[] edit, int bankStart, int lastOffset, string label, params int[] bankIndexes)
        {
            // store original
            int bank = bankStart; // Set bank pointer
            int size = 0;
            byte[][] original = new byte[arrays.Length][];
            ushort temp = Bits.GetShort(data, bankStart);
            for (int i = 0, a = 0; i < arrays.Length; i++)
            {
                a = i * 2;
                for (int b = bankStart; b < lastOffset; b += 0x010000)
                {
                    temp = Bits.GetShort(data, b);
                    if (a >= temp)
                        a -= temp;
                    else
                    {
                        bank = b;
                        break;
                    }
                }
                if (a + 2 == Bits.GetShort(data, bank))
                {
                    if (bank < (lastOffset & 0xFF0000))
                    {
                        size = 0x010000 - Bits.GetShort(data, bank + a);
                        for (int o = 0xFFFF; data[bank + o] != 0xFF; o--)
                            size--;
                    }
                    else
                    {
                        size = (lastOffset & 0xFFFF) - Bits.GetShort(data, bank + a);
                        for (int o = (lastOffset & 0xFFFF) - 1; data[bank + o] != 0xFF; o--)
                            size--;
                    }
                }
                else
                    size = Bits.GetShort(data, bank + a + 2) - Bits.GetShort(data, bank + a);
                original[i] = Bits.GetByteArray(data, bank + Bits.GetShort(data, bank + a), size);
            }
            // create a progress bar
            ProgressBar progressBar = new ProgressBar(data, "COMPRESSING " + label + "S", arrays.Length);
            progressBar.Show();
            // now start compressing the data and storing to ROM
            bank = bankStart;
            for (int indexBank = 0; indexBank < bankIndexes.Length; indexBank++, bank += 0x010000)
            {
                // the index in the array collection to start at
                int index = bankIndexes[indexBank];
                // the index within the current bank
                int bankIndex = 0;
                // is where the pointers end and the compressed data begins
                ushort offset;
                // the maximum index in the current bank
                int endIndex;
                // the maximum offset that can be written to in the current bank
                ushort bounds = bank == (lastOffset & 0xFF0000) ? (ushort)lastOffset : (ushort)0xFFFF;
                if (indexBank + 1 < bankIndexes.Length)
                {
                    offset = (ushort)((bankIndexes[indexBank + 1] - bankIndexes[indexBank]) * 2);
                    endIndex = bankIndexes[indexBank + 1];
                }
                // if at last bank
                else
                {
                    offset = (ushort)((arrays.Length - bankIndexes[indexBank]) * 2);
                    endIndex = arrays.Length;
                }
                for (; index < endIndex; index++, bankIndex++)
                {
                    byte[] compressed = new byte[arrays[index].Length];
                    // Write pointer offset
                    Bits.SetShort(data, bank + (bankIndex * 2), offset);
                    // write new if edit flag set
                    if (edit[index])
                    {
                        edit[index] = false;
                        // Compress data
                        size = Comp.Compress(arrays[index], compressed);
                        if (offset + size > bounds) // Do we pass the bounds of bank?
                        {
                            MessageBox.Show("Could not save all " + label + "S. " +
                                "Stopped saving at " + label + " #" + index.ToString(),
                                "LAZY SHELL");
                            size = Comp.Compress(new byte[arrays[index].Length], compressed);
                        }
                        // Write data to rom
                        Bits.SetByte(data, bank + offset, 1); offset++;
                    }
                    else
                    {
                        size = original[index].Length; original[index].CopyTo(compressed, 0);
                        if (offset + size > bounds) // Do we pass the bounds of bank?
                        {
                            MessageBox.Show("Could not save all " + label + "S. " +
                                "Stopped saving at " + label + " #" + index.ToString(),
                                "LAZY SHELL");
                            size = Comp.Compress(new byte[arrays[index].Length], compressed);
                        }
                    }
                    Bits.SetByteArray(data, bank + offset, compressed, 0, size);
                    offset += (ushort)size; // Move forward in bank
                    progressBar.PerformStep(
                        "COMPRESSING BANK 0x" + (bank >> 32).ToString("X2") + " " + label + " #" + index.ToString("d3"));
                }
                // fill up the rest of the bank with 0x00's
                if (bank < (lastOffset & 0xFF0000))
                    Bits.SetByteArray(data, bank + offset, new byte[0x010000 - offset]);
                else
                    Bits.SetByteArray(data, bank + offset, new byte[(lastOffset & 0xFFFF) - offset]);
            }
            progressBar.Close();
        }
        /// <summary>
        /// Compress and store single array to ROM. Returns success of compression function.
        /// </summary>
        /// <param name="src">The array in the Model class to compress.</param>
        /// <param name="offset">The offset in the ROM to store at.</param>
        /// <param name="maxDecomp">The maximum/standard size of the decompressed data.</param>
        /// <param name="maxComp">The maximum size of the compressed data.</param>
        /// <param name="label">The name/label of the data, title-case.</param>
        /// <returns></returns>
        public static bool Compress(byte[] src, int offset, int maxDecomp, int maxComp, string label)
        {
            byte[] compressed = new byte[maxDecomp];
            int size = Comp.Compress(src, compressed);
            int totalSize = size + 1;
            if (totalSize > maxComp)
            {
                MessageBox.Show(
                    label + " recompressed data exceeds allotted ROM space by " +
                    (totalSize - maxComp).ToString() + " bytes.\n" + label + " was not saved.",
                    "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                Bits.SetByteArray(Model.Data, offset, compressed, 0, size - 1);
                return true;
            }
        }
        public static bool Compress(byte[] src, byte[] dst, ref int offset, int maxComp, string label)
        {
            byte[] comp = new byte[maxComp];
            int size = Comp.Compress(src, comp) + 1;
            if (offset + size >= maxComp)
            {
                MessageBox.Show("Compressed " + label + " too large. Data not saved.");
                return false;
            }
            dst[offset] = 0x01;
            Buffer.BlockCopy(comp, 0, dst, offset + 1, size - 1);
            offset += size;
            return true;
        }
        #endregion
        #region Assemblers
        public static void LoadAll()
        {
            object dummy;
            dummy = ActionScripts;
            dummy = Animations;
            dummy = Attacks;
            dummy = AttackAnimations;
            dummy = AttackNames;
            dummy = AudioSamples;
            dummy = BattleDialogues;
            dummy = BattleDialogueTileset;
            dummy = BattleDialogueTilesetImage;
            dummy = BattleEvents;
            dummy = Battlefields;
            dummy = BattleMessages;
            dummy = BattleScripts;
            dummy = BehaviorAnimations;
            dummy = Characters;
            dummy = DialogueGraphics;
            dummy = Dialogues;
            dummy = E_animations;
            dummy = Effects;
            dummy = EntranceAnimations;
            dummy = EventScripts;
            dummy = FontDescription;
            dummy = FontDialogue;
            dummy = FontMenu;
            dummy = FontPaletteBattle;
            dummy = FontPaletteDialogue;
            dummy = FontTriangle;
            dummy = FormationMusics;
            dummy = FormationPacks;
            dummy = Formations;
            dummy = GameSelectGraphics;
            dummy = GameSelectPalettes;
            dummy = GameSelectPaletteSet;
            dummy = GameSelectSpeakers;
            dummy = GameSelectTileset;
            dummy = GraphicPalettes;
            dummy = GraphicSets[0];
            dummy = ItemAnimations;
            dummy = ItemNames;
            dummy = Items;
            dummy = LevelMaps;
            dummy = Levels;
            dummy = MapPoints;
            dummy = MenuBG;
            dummy = MenuBGPalette;
            dummy = MenuFrameGraphics;
            dummy = MenuFramePalette;
            dummy = MenuBGGraphics;
            dummy = MenuBGTileset;
            dummy = MenuCursorGraphics;
            dummy = MinecartM7Graphics;
            dummy = MinecartM7Palettes;
            dummy = MinecartM7PaletteSet;
            dummy = MinecartM7TilemapA;
            dummy = MinecartM7TilemapB;
            dummy = MinecartM7TilesetBG;
            dummy = MinecartM7TilesetPalettes;
            dummy = MinecartM7TilesetSubtiles;
            dummy = MinecartObjectGraphics;
            dummy = MinecartObjectPalettes;
            dummy = MinecartObjectPaletteSet;
            dummy = MinecartObjects;
            dummy = MinecartSSBGTileset;
            dummy = MinecartSSGraphics;
            dummy = MinecartSSPalettes;
            dummy = MinecartSSPaletteSet;
            dummy = MinecartSSTilemap;
            dummy = MinecartSSTileset;
            dummy = FontPaletteMenu;
            dummy = MonsterNames;
            dummy = Monsters;
            dummy = Notes;
            dummy = NPCProperties;
            dummy = NPCSpritePartitions;
            dummy = OverlapTileset;
            dummy = Palettes;
            dummy = PaletteSets;
            dummy = PaletteSetsBF;
            dummy = SolidityMaps[0];
            dummy = SolidTiles;
            dummy = PrioritySets;
            dummy = Shops;
            dummy = Slots;
            dummy = SpellAnimAllies;
            dummy = SpellAnimMonsters;
            dummy = SpellNames;
            dummy = Spells;
            dummy = SpriteGraphics;
            dummy = SpritePalettes;
            dummy = Sprites;
            dummy = Tilemaps[0];
            dummy = Tilesets[0];
            dummy = TileSetsBF[0];
            dummy = TitleData;
            dummy = TitlePalettes;
            dummy = TitleSpriteGraphics;
            dummy = TitleSpritePalettes;
            dummy = TitleTileSet;
            dummy = WeaponAnimations;
            dummy = WorldMapGraphics;
            dummy = WorldMapPalettes;
            dummy = WorldMaps;
            dummy = WorldMapSprites;
            dummy = WorldMapTileSets[0];
        }
        public static void ClearModel()
        {
            actionScripts = null;
            animations = null;
            attacks = null;
            attackAnimations = null;
            attackNames = null;
            audioSamples = null;
            battleDialogues = null;
            battleDialogueTileset = null;
            battleDialogueTilesetImage = null;
            battleEvents = null;
            battlefields = null;
            battleMessages = null;
            battleScripts = null;
            behaviorAnimations = null;
            characters = null;
            dialogueGraphics = null;
            dialogues = null;
            dialogueTables = null;
            e_animations = null;
            effects = null;
            entranceAnimations = null;
            eventScripts = null;
            fontDescription = null;
            fontDialogue = null;
            fontMenu = null;
            fontPaletteBattle = null;
            fontPaletteDialogue = null;
            fontTriangle = null;
            formationMusics = null;
            formationPacks = null;
            formations = null;
            gameSelectGraphics = null;
            gameSelectPalettes = null;
            gameSelectPaletteSet = null;
            gameSelectSpeakers = null;
            gameSelectTileset = null;
            graphicPalettes = null;
            graphicSets[0] = null;
            itemAnimations = null;
            itemNames = null;
            items = null;
            levelMaps = null;
            levels = null;
            mapPoints = null;
            menuBG = null;
            menuBGPalette = null;
            menuFrameGraphics = null;
            menuFramePalette = null;
            menuBGGraphics = null;
            menuBGTileset = null;
            menuPalettes = null;
            minecartM7Graphics = null;
            minecartM7Palettes = null;
            minecartM7PaletteSet = null;
            minecartM7TilemapA = null;
            minecartM7TilemapB = null;
            minecartM7TilesetBG = null;
            minecartM7TilesetPalettes = null;
            minecartM7TilesetSubtiles = null;
            minecartObjectGraphics = null;
            minecartObjectPalettes = null;
            minecartObjectPaletteSet = null;
            minecartObjects = null;
            minecartSSBGTileset = null;
            minecartSSGraphics = null;
            minecartSSPalettes = null;
            minecartSSPaletteSet = null;
            minecartSSTilemap = null;
            minecartSSTileset = null;
            cursorPaletteSet = null;
            monsterNames = null;
            monsters = null;
            notes = null;
            npcProperties = null;
            npcSpritePartitions = null;
            overlapTileset = null;
            palettes = null;
            paletteSets = null;
            paletteSetsBF = null;
            solidityMaps[0] = null;
            solidTiles = null;
            prioritySets = null;
            shops = null;
            slots = null;
            spellAnimAllies = null;
            spellAnimMonsters = null;
            spellNames = null;
            spells = null;
            spriteGraphics = null;
            spritePalettes = null;
            sprites = null;
            tileMaps[0] = null;
            tileSets[0] = null;
            tileSetsBF[0] = null;
            titleData = null;
            titlePalettes = null;
            titleSpriteGraphics = null;
            titleSpritePalettes = null;
            titleTileSet = null;
            weaponAnimations = null;
            worldMapGraphics = null;
            worldMapPalettes = null;
            worldMaps = null;
            worldMapSprites = null;
            worldMapTileSets[0] = null;
        }
        #endregion
        #endregion
    }
}
