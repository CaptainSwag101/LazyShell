using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms; // remove later
using System.IO;
using System.Security.Cryptography;
using LAZYSHELL.ScriptsEditor;
using LAZYSHELL.Compression;
using LAZYSHELL.DataStructures;
using LAZYSHELL.Properties;

namespace LAZYSHELL
{
    public class Model
    {
        private Program program;
        public Program Program { get { return this.program; } }
        private byte[] data;
        public byte[] Data
        {
            get { return this.data; }
            set { this.data = value; }
        }
        // For Rom Signature
        private bool locked = false;
        private bool published = false;
        public bool Locked
        {
            get { return this.locked; }
            set { this.locked = value; }
        } // Indicates that this rom is locked and cannot be edited, not for public use
        public bool Published
        {
            get { return this.published; }
            set { this.published = value; }
        } // If true, show Author Splash screen on load
        private long numBytes = 0;
        private string fileName;
        private LSCompression LSCompression = null;
        private LCDecomp lcDecomp;
        private LCDecomp LCDecomp
        {
            get
            {
                if (lcDecomp == null)
                    this.lcDecomp = new LCDecomp(data);
                return this.lcDecomp;
            }
        }
        private Settings settings;
        private NotesDB notes;
        public NotesDB Notes
        {
            get { return this.notes; }
            set { this.notes = value; }
        }
        private byte[] dataHash;
        public byte[] DataHash { get { return dataHash; } set { dataHash = value; } }
        private long checkSum = 0;
        #region Battlefields
        private byte[][] tileSetsBF = new byte[64][];
        public byte[][] TileSetsBF
        {
            get
            {
                if (tileSetsBF[0] == null)
                    Decompress(tileSetsBF, 0x150000, 0x160000, 0x2000, "BATTLEFIELD TILE SET");
                return tileSetsBF;
            }
            set { tileSetsBF = value; }
        }
        public bool[] EditTileSetsBF = new bool[64];
        private Battlefield[] battlefields;
        private PaletteSet[] paletteSetsBF;
        public Battlefield[] Battlefields
        {
            get
            {
                if (this.battlefields == null)
                {
                    battlefields = new Battlefield[64];
                    for (int i = 0; i < battlefields.Length; i++)
                        battlefields[i] = new Battlefield(data, i);
                }
                return this.battlefields;
            }
            set { this.battlefields = value; }
        }
        public PaletteSet[] PaletteSetsBF
        {
            get
            {
                if (this.paletteSetsBF == null)
                {
                    paletteSetsBF = new PaletteSet[57];
                    for (int i = 0; i < paletteSetsBF.Length; i++)
                        paletteSetsBF[i] = new PaletteSet(data, i, (i * 0xB6) + 0x34CFC4, 8, 16, 30);
                }
                return this.paletteSetsBF;
            }
            set { this.paletteSetsBF = value; }
        }
        #endregion
        #region Dialogues
        private Bitmap battleDialogueTilesetImage;
        private BattleDialogueTileset battleDialogueTileset;
        private byte[] battleDialogueTileSet;
        private byte[] dialogueGraphics;
        public Bitmap BattleDialogueTilesetImage
        {
            get
            {
                if (battleDialogueTilesetImage == null)
                    battleDialogueTilesetImage = new Bitmap(Do.PixelsToImage(
                        Do.TilesetToPixels(BattleDialogueTileset.TilesetLayer,
                        16, 2, 0, false), 256, 32));
                return battleDialogueTilesetImage;
            }
            set
            {
                battleDialogueTilesetImage = value;
            }
        }
        public BattleDialogueTileset BattleDialogueTileset
        {
            get
            {
                if (this.battleDialogueTileset == null)
                    this.battleDialogueTileset = new BattleDialogueTileset(
                        DialogueGraphics, BattleDialogueTileSet, FontPaletteDialogue);
                return this.battleDialogueTileset;
            }
            set { this.battleDialogueTileset = value; }
        }
        public byte[] BattleDialogueTileSet
        {
            get
            {
                if (this.battleDialogueTileSet == null)
                    battleDialogueTileSet = Bits.GetByteArray(data, 0x015943, 0x100);
                return battleDialogueTileSet;
            }
            set { battleDialogueTileSet = value; }
        }
        public byte[] DialogueGraphics
        {
            get
            {
                if (this.dialogueGraphics == null)
                    dialogueGraphics = Bits.GetByteArray(data, 0x3DF000, 0x700);
                return this.dialogueGraphics;
            }
            set { dialogueGraphics = value; }
        }
        private BattleDialogue[] battleDialogues;
        private BattleDialogue[] battleMessages;
        private Dialogue[] dialogues;
        public BattleDialogue[] BattleDialogues
        {
            get
            {
                if (battleDialogues == null)
                {
                    battleDialogues = new BattleDialogue[256];
                    for (int i = 0; i < battleDialogues.Length; i++)
                        battleDialogues[i] = new BattleDialogue(data, i, 0);
                }
                return this.battleDialogues;
            }
            set { this.battleDialogues = value; }
        }
        public BattleDialogue[] BattleMessages
        {
            get
            {
                if (battleMessages == null)
                {
                    battleMessages = new BattleDialogue[46];
                    for (int i = 0; i < battleMessages.Length; i++)
                        battleMessages[i] = new BattleDialogue(data, i, 1);
                }
                return this.battleMessages;
            }
            set { this.battleMessages = value; }
        }
        public Dialogue[] Dialogues
        {
            get
            {
                if (dialogues == null)
                {
                    //set the charcode to read from table
                    Bits.SetByte(data, 0x6935, 0xEF);
                    Bits.SetByte(data, 0x6937, 0xEF);
                    Bits.SetShort(data, 0x693B, 0x60EF);
                    //set the pointers for the table
                    Bits.SetByte(data, 0x249016, 0x31);
                    Bits.SetByte(data, 0x24901A, 0x36);
                    //set the new text
                    Bits.SetShort(data, 0x24912E, 0x7461);
                    Bits.SetShort(data, 0x249130, 0x6800);
                    Bits.SetShort(data, 0x249132, 0x7265);
                    Bits.SetShort(data, 0x249134, 0x0065);
                    Bits.SetShort(data, 0x249136, 0x6620);
                    Bits.SetShort(data, 0x249138, 0x726F);
                    Bits.SetByte(data, 0x24913A, 0x00);
                    ProgressBar progressBar = new ProgressBar("LOADING DIALOGUES...", 4096);
                    progressBar.Show();
                    // create dialogues
                    dialogues = new Dialogue[4096];
                    for (int i = 0; i < dialogues.Length; i++)
                    {
                        dialogues[i] = new Dialogue(data, i);
                        dialogues[i].SetDialogue(dialogues[i].GetDialogue(true), true);
                        if (i % 32 == 0)
                            progressBar.PerformStep("LOADING DIALOGUE #" + i.ToString("d4"), 32);
                    }
                    progressBar.Close();
                }
                return this.dialogues;
            }
            set { this.dialogues = value; }
        }
        public Dialogue[] GetDialogues(int start, int end)
        {
            if (dialogues != null)
                return dialogues;
            //set the charcode to read from table
            Bits.SetByte(data, 0x6935, 0xEF);
            Bits.SetByte(data, 0x6937, 0xEF);
            Bits.SetShort(data, 0x693B, 0x60EF);
            //set the pointers for the table
            Bits.SetByte(data, 0x249016, 0x31);
            Bits.SetByte(data, 0x24901A, 0x36);
            //set the new text
            Bits.SetShort(data, 0x24912E, 0x7461);
            Bits.SetShort(data, 0x249130, 0x6800);
            Bits.SetShort(data, 0x249132, 0x7265);
            Bits.SetShort(data, 0x249134, 0x0065);
            Bits.SetShort(data, 0x249136, 0x6620);
            Bits.SetShort(data, 0x249138, 0x726F);
            Bits.SetByte(data, 0x24913A, 0x00);
            // create dialogues
            Dialogue[] temp = new Dialogue[end - start];
            for (int i = start; i < end; i++)
            {
                temp[i] = new Dialogue(data, i);
                temp[i].SetDialogue(temp[i].GetDialogue(true), true);
            }
            return temp;
        }
        #endregion
        #region Effects
        private Effect[] effects;
        private E_Animation[] e_animations;
        public Effect[] Effects
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
                return this.effects;
            }
            set { effects = value; }
        }
        public E_Animation[] E_animations
        {
            get
            {
                if (e_animations == null)
                {
                    e_animations = new E_Animation[64];
                    for (int i = 0; i < e_animations.Length; i++)
                        e_animations[i] = new E_Animation(data, i);
                }
                return this.e_animations;
            }
            set { e_animations = value; }
        }
        #endregion
        #region Fonts
        private FontCharacter[] fontDialogue;
        private FontCharacter[] fontMenu;
        private FontCharacter[] fontDescription;
        private FontCharacter[] fontTriangle;
        private PaletteSet fontPaletteDialogue;
        private PaletteSet fontPaletteMenu;
        private PaletteSet fontPaletteBattle;
        public FontCharacter[] FontDialogue
        {
            get
            {
                if (this.fontDialogue == null)
                {
                    fontDialogue = new FontCharacter[128];
                    for (int i = 0; i < fontDialogue.Length; i++)
                        fontDialogue[i] = new FontCharacter(data, i, 1);
                }
                return this.fontDialogue;
            }
            set { this.fontDialogue = value; }
        }
        public FontCharacter[] FontMenu
        {
            get
            {
                if (this.fontMenu == null)
                {
                    fontMenu = new FontCharacter[128];
                    for (int i = 0; i < fontMenu.Length; i++)
                        fontMenu[i] = new FontCharacter(data, i, 0);
                }
                return this.fontMenu;
            }
            set { this.fontMenu = value; }
        }
        public FontCharacter[] FontDescription
        {
            get
            {
                if (this.fontDescription == null)
                {
                    fontDescription = new FontCharacter[128];
                    for (int i = 0; i < fontDescription.Length; i++)
                        fontDescription[i] = new FontCharacter(data, i, 2);
                }
                return this.fontDescription;
            }
            set { this.fontDescription = value; }
        }
        public FontCharacter[] FontTriangle
        {
            get
            {
                if (this.fontTriangle == null)
                {
                    fontTriangle = new FontCharacter[14];
                    for (int i = 0; i < fontTriangle.Length; i++)
                        fontTriangle[i] = new FontCharacter(data, i, 3);
                }
                return this.fontTriangle;
            }
            set { this.fontTriangle = value; }
        }
        public PaletteSet FontPaletteDialogue
        {
            get
            {
                if (this.fontPaletteDialogue == null)
                    fontPaletteDialogue = new PaletteSet(data, 0, 0x3DFEE0, 2, 16, 32);
                return fontPaletteDialogue;
            }
            set { this.fontPaletteDialogue = value; }
        }
        public PaletteSet FontPaletteMenu
        {
            get
            {
                if (this.fontPaletteMenu == null)
                    fontPaletteMenu = new PaletteSet(data, 0, 0x3E2D55, 1, 16, 32);
                return fontPaletteMenu;
            }
            set { this.fontPaletteMenu = value; }
        }
        public PaletteSet FontPaletteBattle
        {
            get
            {
                if (this.fontPaletteBattle == null)
                    fontPaletteBattle = new PaletteSet(data, 0, 0x01EF40, 1, 16, 32);
                return fontPaletteBattle;
            }
            set { this.fontPaletteBattle = value; }
        }
        #endregion
        #region Levels
        // compressed data
        private byte[][] graphicSets = new byte[272][];
        private byte[][] tileSets = new byte[125][];
        private byte[][] tileMaps = new byte[309][];
        private byte[][] physicalMaps = new byte[120][];
        public byte[][] GraphicSets
        {
            get
            {
                if (graphicSets[0] == null)
                    Decompress(graphicSets, 0x0A0000, 0x150000, 0x2000, "GRAPHIC SET");
                return graphicSets;
            }
            set { graphicSets = value; }
        }
        public byte[][] TileSets
        {
            get
            {
                if (tileSets[0] == null)
                    Decompress(tileSets, 0x3B0000, 0x3E0000, 0x1000, "TILE SET");
                return tileSets;
            }
            set { tileSets = value; }
        }
        public byte[][] TileMaps
        {
            get
            {
                if (tileMaps[0] == null)
                    Decompress(tileMaps, 0x160000, 0x1B0000, 0x1000, 0x2000, "TILE MAP", 0x40);
                return tileMaps;
            }
            set { tileMaps = value; }
        }
        public byte[][] PhysicalMaps
        {
            get
            {
                if (physicalMaps[0] == null)
                    Decompress(physicalMaps, 0x1B0000, 0x1D0000, 0x20C2, "PHYSICAL MAP");
                return physicalMaps;
            }
            set { physicalMaps = value; }
        }
        public bool[] EditGraphicSets = new bool[272];
        public bool[] EditTileSets = new bool[125];
        public bool[] EditTileMaps = new bool[309];
        public bool[] EditPhysicalMaps = new bool[120];
        // properties
        private Level[] levels;
        private LevelMap[] levelMaps;
        private PaletteSet[] paletteSets;
        private PrioritySet[] prioritySets;
        private PhysicalTile[] physicalTiles;
        private NPCProperties[] npcProperties;
        private NPCSpritePartitions[] npcSpritePartitions;
        private OverlapTileset overlapTileset;
        public Level[] Levels
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
        public LevelMap[] LevelMaps
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
        public PaletteSet[] PaletteSets
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
        public PrioritySet[] PrioritySets
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
        public PhysicalTile[] PhysicalTiles
        {
            get
            {
                if (physicalTiles == null)
                {
                    physicalTiles = new PhysicalTile[1024];
                    for (int i = 0; i < physicalTiles.Length; i++)
                        physicalTiles[i] = new PhysicalTile(data, i);
                }
                return physicalTiles;
            }
        }
        public NPCProperties[] NPCProperties
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
        public NPCSpritePartitions[] NPCSpritePartitions
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
        public OverlapTileset OverlapTileset
        {
            get
            {
                if (overlapTileset == null)
                    overlapTileset = new OverlapTileset(this);
                return overlapTileset;
            }
        }
        #endregion
        #region Overworld Menu
        private byte[] menuGraphicSet;
        private byte[] menuTileset;
        private byte[] menuFrame;
        public byte[] MenuGraphicSet
        {
            get
            {
                if (menuGraphicSet == null)
                    menuGraphicSet = Decompress(0x3E0E69, 0x2000);
                return menuGraphicSet;
            }
            set { menuGraphicSet = value; }
        }
        public byte[] MenuTileset
        {
            get
            {
                if (menuTileset == null)
                    menuTileset = Decompress(0x3E286A, 0x2000);
                return menuTileset;
            }
            set { menuTileset = value; }
        }
        public byte[] MenuFrame
        {
            get
            {
                if (menuFrame == null)
                    menuFrame = Decompress(0x3E2607, 0x200);
                return menuFrame;
            }
            set { menuFrame = value; }
        }
        public bool EditMenuTileSet;
        private PaletteSet menuFramePalette;
        public PaletteSet MenuFramePalette
        {
            get
            {
                if (menuFramePalette == null)
                    menuFramePalette = new PaletteSet(data, 0, 0x24C83A, 1, 16, 32);
                return menuFramePalette;
            }
            set { menuFramePalette = value; }
        }
        private PaletteSet menuBackgroundPalette;
        public PaletteSet MenuBackgroundPalette
        {
            get
            {
                if (menuBackgroundPalette == null)
                    menuBackgroundPalette = new PaletteSet(data, 0, 0x3E9A28, 1, 16, 32);
                return menuBackgroundPalette;
            }
            set { menuBackgroundPalette = value; }
        }
        private Bitmap menuBackground;
        public Bitmap MenuBackground
        {
            get
            {
                if (menuBackground == null)
                    menuBackground = Do.PixelsToImage(
                        Do.TilesetToPixels(
                        new MenuTileset(this, MenuBackgroundPalette.Palette).Tileset, 16, 16, 0, false), 256, 256);
                return menuBackground;
            }
            set { menuBackground = value; }
        }
        #endregion
        #region Scripts
        private BattleScript[] battleScripts;
        private EventScript[] eventScripts;
        private ActionQueue[] actionScripts;
        private AnimationScript[] spellAnimMonsters;
        private AnimationScript[] spellAnimAllies;
        private AnimationScript[] attackAnimations;
        private AnimationScript[] itemAnimations;
        private AnimationScript[] battleEvents;
        private AnimationScript[] behaviorAnimations;
        private AnimationScript[] entranceAnimations;
        private AnimationScript[] weaponAnimations;
        public BattleScript[] BattleScripts
        {
            get
            {
                if (battleScripts == null)
                {
                    this.battleScripts = new BattleScript[256];
                    for (int i = 0; i < battleScripts.Length; i++)
                        battleScripts[i] = new BattleScript(data, i);
                }
                return this.battleScripts;
            }
            set { battleScripts = value; }
        }
        public EventScript[] EventScripts
        {
            get
            {
                if (eventScripts == null)
                {
                    this.eventScripts = new EventScript[4096];
                    for (int i = 0; i < eventScripts.Length; i++)
                        eventScripts[i] = new EventScript(data, i);
                }
                return this.eventScripts;
            }
            set { eventScripts = value; }
        }
        public ActionQueue[] ActionScripts
        {
            get
            {
                if (actionScripts == null)
                {
                    this.actionScripts = new ActionQueue[1024];
                    for (int i = 0; i < actionScripts.Length; i++)
                        actionScripts[i] = new ActionQueue(data, i);
                }
                return this.actionScripts;
            }
            set { actionScripts = value; }
        }
        public AnimationScript[] SpellAnimMonsters
        {
            get
            {
                if (spellAnimMonsters == null)
                {
                    spellAnimMonsters = new AnimationScript[45];
                    for (int i = 0; i < spellAnimMonsters.Length; i++)
                        spellAnimMonsters[i] = new AnimationScript(data, i, 1);
                }
                return this.spellAnimMonsters;
            }
            set { spellAnimMonsters = value; }
        }
        public AnimationScript[] SpellAnimAllies
        {
            get
            {
                if (spellAnimAllies == null)
                {
                    spellAnimAllies = new AnimationScript[27];
                    for (int i = 0; i < spellAnimAllies.Length; i++)
                        spellAnimAllies[i] = new AnimationScript(data, i, 5);
                }
                return this.spellAnimAllies;
            }
            set { spellAnimAllies = value; }
        }
        public AnimationScript[] AttackAnimations
        {
            get
            {
                if (attackAnimations == null)
                {
                    attackAnimations = new AnimationScript[129];
                    for (int i = 0; i < attackAnimations.Length; i++)
                        attackAnimations[i] = new AnimationScript(data, i, 3);
                }
                return this.attackAnimations;
            }
            set { attackAnimations = value; }
        }
        public AnimationScript[] ItemAnimations
        {
            get
            {
                if (itemAnimations == null)
                {
                    itemAnimations = new AnimationScript[81];
                    for (int i = 0; i < itemAnimations.Length; i++)
                        itemAnimations[i] = new AnimationScript(data, i, 4);
                }
                return this.itemAnimations;
            }
            set { itemAnimations = value; }
        }
        public AnimationScript[] BattleEvents
        {
            get
            {
                if (battleEvents == null)
                {
                    battleEvents = new AnimationScript[102];
                    for (int i = 0; i < battleEvents.Length; i++)
                        battleEvents[i] = new AnimationScript(data, i, 7);
                }
                return this.battleEvents;
            }
            set { battleEvents = value; }
        }
        public AnimationScript[] BehaviorAnimations
        {
            get
            {
                if (behaviorAnimations == null)
                {
                    behaviorAnimations = new AnimationScript[54];
                    for (int i = 0; i < behaviorAnimations.Length; i++)
                        behaviorAnimations[i] = new AnimationScript(data, i, 0);
                }
                return this.behaviorAnimations;
            }
            set { behaviorAnimations = value; }
        }
        public AnimationScript[] EntranceAnimations
        {
            get
            {
                if (entranceAnimations == null)
                {
                    entranceAnimations = new AnimationScript[16];
                    for (int i = 0; i < entranceAnimations.Length; i++)
                        entranceAnimations[i] = new AnimationScript(data, i, 2);
                }
                return this.entranceAnimations;
            }
            set { entranceAnimations = value; }
        }
        public AnimationScript[] WeaponAnimations
        {
            get
            {
                if (weaponAnimations == null)
                {
                    weaponAnimations = new AnimationScript[36];
                    for (int i = 0; i < weaponAnimations.Length; i++)
                        weaponAnimations[i] = new AnimationScript(data, i, 6);
                }
                return this.weaponAnimations;
            }
            set { weaponAnimations = value; }
        }
        #endregion
        #region Sprites
        private Sprite[] sprites;
        private GraphicPalette[] graphicPalettes;
        private Animation[] animations;
        private PaletteSet[] spritePalettes;
        private byte[] spriteGraphics;
        public Sprite[] Sprites
        {
            get
            {
                if (sprites == null)
                {
                    sprites = new Sprite[1024];
                    for (int i = 0; i < sprites.Length; i++)
                        sprites[i] = new Sprite(data, i);
                }
                return this.sprites;
            }
            set { sprites = value; }
        }
        public GraphicPalette[] GraphicPalettes
        {
            get
            {
                if (graphicPalettes == null)
                {
                    graphicPalettes = new GraphicPalette[512];
                    for (int i = 0; i < graphicPalettes.Length; i++)
                        graphicPalettes[i] = new GraphicPalette(data, i);
                }
                return this.graphicPalettes;
            }
            set { graphicPalettes = value; }
        }
        public Animation[] Animations
        {
            get
            {
                if (animations == null)
                {
                    animations = new Animation[444];
                    for (int i = 0; i < animations.Length; i++)
                        animations[i] = new Animation(data, i);
                }
                return this.animations;
            }
            set { animations = value; }
        }
        public PaletteSet[] SpritePalettes
        {
            get
            {
                if (spritePalettes == null)
                {
                    spritePalettes = new PaletteSet[819];
                    for (int i = 0; i < spritePalettes.Length; i++)
                        spritePalettes[i] = new PaletteSet(data, i, 0x252FFE + (i * 30), 1, 16, 30);
                }
                return this.spritePalettes;
            }
            set { spritePalettes = value; }
        }
        public byte[] SpriteGraphics
        {
            get
            {
                if (spriteGraphics == null)
                    this.spriteGraphics = Bits.GetByteArray(data, 0x280000, 0xB4000);
                return spriteGraphics;
            }
            set { spriteGraphics = value; }
        }
        #endregion
        #region Stats
        private Attack[] attacks;
        private Character[] characters;
        private Formation[] formations;
        private FormationPack[] formationPacks;
        private byte[] formationMusics;
        private Item[] items;
        private Monster[] monsters;
        private Shop[] shops;
        private Slot[] slots;
        private Spell[] spells;
        public Attack[] Attacks
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
        public Character[] Characters
        {
            get
            {
                if (characters == null)
                {
                    this.characters = new Character[5];
                    for (int i = 0; i < this.characters.Length; i++)
                        this.characters[i] = new Character(data, i);
                }
                return characters;
            }
            set { characters = value; }
        }
        public Formation[] Formations
        {
            get
            {
                if (formations == null)
                {
                    this.formations = new Formation[512];
                    for (int i = 0; i < this.formations.Length; i++)
                        this.formations[i] = new Formation(data, i);
                }
                return formations;
            }
            set { formations = value; }
        }
        public FormationPack[] FormationPacks
        {
            get
            {
                if (formationPacks == null)
                {
                    this.formationPacks = new FormationPack[256];
                    for (int i = 0; i < this.formationPacks.Length; i++)
                        this.formationPacks[i] = new FormationPack(data, i);
                }
                return formationPacks;
            }
            set { formationPacks = value; }
        }
        public byte[] FormationMusics
        {
            get
            {
                if (formationMusics == null)
                {
                    this.formationMusics = new byte[8];
                    for (int i = 0; i < this.formationMusics.Length; i++)
                        this.formationMusics[i] = data[0x029F51 + i];
                }
                return this.formationMusics;
            }
            set { this.formationMusics = value; }
        }
        public Item[] Items
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
        public Monster[] Monsters
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
        public Shop[] Shops
        {
            get
            {
                if (shops == null)
                {
                    this.shops = new Shop[33];
                    for (int i = 0; i < this.shops.Length; i++)
                        this.shops[i] = new Shop(data, i);
                }
                return shops;
            }
            set { shops = value; }
        }
        public Slot[] Slots
        {
            get
            {
                if (slots == null)
                {
                    this.slots = new Slot[30];
                    for (int i = 0; i < slots.Length; i++)
                        slots[i] = new Slot(data, i);
                }
                return slots;
            }
            set { slots = value; }
        }
        public Spell[] Spells
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
        private DDlistName monsterNames;
        private DDlistName spellNames;
        private DDlistName attackNames;
        private DDlistName itemNames;
        public DDlistName MonsterNames
        {
            get
            {
                if (monsterNames == null)
                {
                    monsterNames = new DDlistName(Monsters);
                    monsterNames.SortAlpha();
                }
                return this.monsterNames;
            }
            set
            {
                this.monsterNames = value;
                if (monsterNames != null)
                    monsterNames.SortAlpha();
            }
        }
        public DDlistName SpellNames
        {
            get
            {
                if (spellNames == null)
                {
                    spellNames = new DDlistName(Spells);
                    spellNames.SortAlpha();
                }
                return this.spellNames;
            }
            set
            {
                this.spellNames = value;
                if (spellNames != null)
                    spellNames.SortAlpha();
            }
        }
        public DDlistName AttackNames
        {
            get
            {
                if (attackNames == null)
                {
                    attackNames = new DDlistName(Attacks);
                    attackNames.SortAlpha();
                }
                return this.attackNames;
            }
            set
            {
                this.attackNames = value;
                if (attackNames != null)
                    attackNames.SortAlpha();
            }
        }
        public DDlistName ItemNames
        {
            get
            {
                if (itemNames == null)
                {
                    itemNames = new DDlistName(Items);
                    itemNames.SortAlpha();
                }
                return this.itemNames;
            }
            set
            {
                this.itemNames = value;
                if (itemNames != null)
                    itemNames.SortAlpha();
            }
        }
        #endregion
        #region Title
        private byte[] titleData;
        private TitleTileset titleTileSet;
        private PaletteSet titlePalettes;
        private PaletteSet titleSpritePalettes;
        private byte[] titleSpriteGraphics;
        public byte[] TitleData
        {
            get
            {
                if (titleData == null)
                    titleData = Decompress(0x3F216F, 0xDA60);
                return titleData;
            }
            set { titleData = value; }
        }
        public TitleTileset TitleTileSet
        {
            get
            {
                if (titleTileSet == null)
                    titleTileSet = new TitleTileset(TitlePalettes, this);
                return titleTileSet;
            }
            set { titleTileSet = value; }
        }
        public PaletteSet TitlePalettes
        {
            get
            {
                if (titlePalettes == null)
                    titlePalettes = new PaletteSet(data, 0, 0x3F0088, 8, 16, 32);
                return titlePalettes;
            }
            set { titlePalettes = value; }
        }
        public PaletteSet TitleSpritePalettes
        {
            get
            {
                if (titleSpritePalettes == null)
                    titleSpritePalettes = new PaletteSet(data, 0, 0x3F0188, 5, 16, 32);
                return titleSpritePalettes;
            }
            set { titleSpritePalettes = value; }
        }
        public byte[] TitleSpriteGraphics
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
        private WorldMap[] worldMaps;
        private MapPoint[] mapPoints;
        private PaletteSet palettes;
        private byte[] worldMapGraphics;
        private byte[] worldMapPalettes;
        private byte[][] worldMapTileSets = new byte[9][];
        private byte[] worldMapSprites;
        public WorldMap[] WorldMaps
        {
            get
            {
                if (worldMaps == null)
                {
                    worldMaps = new WorldMap[9];
                    for (int i = 0; i < worldMaps.Length; i++)
                        worldMaps[i] = new WorldMap(data, i);
                }
                return this.worldMaps;
            }
            set { worldMaps = value; }
        }
        public MapPoint[] MapPoints
        {
            get
            {
                if (mapPoints == null)
                {
                    mapPoints = new MapPoint[56];
                    for (int i = 0; i < mapPoints.Length; i++)
                        mapPoints[i] = new MapPoint(data, i);
                }
                return this.mapPoints;
            }
            set { mapPoints = value; }
        }
        public PaletteSet Palettes
        {
            get
            {
                if (palettes == null)
                    palettes = new PaletteSet(WorldMapPalettes, 0, 0, 8, 16, 32);
                return this.palettes;
            }
            set { palettes = value; }
        }
        public byte[] WorldMapGraphics
        {
            get
            {
                if (worldMapGraphics == null)
                    worldMapGraphics = Decompress(0x3E2E82, 0x8000);
                return worldMapGraphics;
            }
            set { worldMapGraphics = value; }
        }
        public byte[] WorldMapPalettes
        {
            get
            {
                if (worldMapPalettes == null)
                    worldMapPalettes = Decompress(0x3E988D, 0x100);
                return worldMapPalettes;
            }
            set { worldMapPalettes = value; }
        }
        public byte[][] WorldMapTileSets
        {
            get
            {
                if (worldMapTileSets[0] == null)
                {
                    for (int i = 0; i < 9; i++)
                    {
                        int pointer = Bits.GetShort(data, i * 2 + 0x3E0014);
                        int offset = 0x3E0000 + pointer + 1;
                        worldMapTileSets[i] = Decompress(offset, 0x800);
                    }
                }
                return worldMapTileSets;
            }
            set { worldMapTileSets = value; }
        }
        public byte[] WorldMapSprites
        {
            get
            {
                if (worldMapSprites == null)
                    worldMapSprites = Decompress(0x3E90A7, 0x400);
                return worldMapSprites;
            }
            set { worldMapSprites = value; }
        }
        #endregion
        // Constructor
        public Model(Program program)
        {
            this.program = program;
            this.settings = Settings.Default;
        }
        #region Functions
        #region File Handling
        public bool VerifyRom()
        {
            if (!LAZYSHELL.Properties.Settings.Default.UnverifiedRomWarning) // If the warning is disabled, dont bother checking
                return true;

            // 32 bytes of SMRPG Rom Data at 0xF800
            byte[] origional = new byte[]{0x0F,0x1A,0x4A,0x85,0x26,0x64,0x27,0x90,0x06,0xA5,0x28,0x9D,0x00,0x00,0xE8,0xC2,
                                          0x20,0xA5,0x28,0x9D,0x00,0x00,0xE8,0xE8,0xC6,0x26,0x10,0xF7,0xE2,0x20,0xC8,0x80};

            if (data.Length >= 0x400000)
            {
                if (Bits.Compare(origional, Bits.GetByteArray(data, 0xF800, 32)))
                    return true;
            }
            return MessageBox.Show("This file does not appear to be a Super Mario RPG rom. Use it anyways?", "LAZY SHELL", MessageBoxButtons.YesNo) == DialogResult.Yes;
        }
        public void CalculateAndSetNewRomChecksum()
        {
            int check = 0;

            for (int i = 0; i < data.Length; i++)
                check += data[i];
            check &= 0xFFFF;

            Bits.SetShort(data, 0x007FDE, (ushort)check);
        }
        public void CreateNewMD5Checksum()
        {
            MD5 md5Hasher = MD5.Create();

            if (data != null)
                dataHash = md5Hasher.ComputeHash(data);
        }
        public string GameCode()
        {
            return ByteToStr(Bits.GetByteArray(data, 0x7FB2, 4));
        }
        public string GetEditorNameWithoutPath()
        {
            int len = GetEditorPath().LastIndexOf('\\') + 1;
            return GetEditorPath().Substring(len, GetEditorPath().Length - len);
        }
        public string GetEditorPath()
        {
            return Application.ExecutablePath;
        }
        public string GetEditorPathWithoutFileName()
        {
            return GetEditorPath().Substring(0, GetEditorPath().LastIndexOf('\\') + 1);
        }
        public string GetFileName()
        {
            return fileName;
        }
        public string GetFileNameWithoutPath()
        {
            try
            {
                return fileName.Substring(fileName.LastIndexOf('\x5c') + 1);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public string GetFileNameWithoutPathOrExtension()
        {
            string ret = fileName.Substring(fileName.LastIndexOf('\x5c') + 1);
            return ret.Substring(0, ret.LastIndexOf('.'));
        }
        public long GetFileSize()
        {
            return numBytes;
        }
        public string GetPathWithoutFileName()
        {
            return fileName.Substring(0, fileName.LastIndexOf('\x5c') + 1);
        }
        public string GetRomName()
        {
            if (HeaderPresent())
                return ByteToStr(Bits.GetByteArray(data, 0x81c0, 21));
            return ByteToStr(Bits.GetByteArray(data, 0x7fc0, 21));
        }
        public bool HeaderPresent()
        {
            if ((numBytes & (long)0x200) == 0x200)
                return true;
            else
                return false;
        }
        public bool ReadRom()
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
        public bool RemoveHeader()
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
            catch (Exception ex)
            {
                MessageBox.Show("Error removing header, please remove manually", "LAZY SHELL");
                return false;
            }
        }
        public string RomChecksum()
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
        public ushort RomChecksumBin()
        {
            checkSum = 0;
            for (int i = 0; i < data.Length; i++)
                checkSum += data[i];
            checkSum &= 0xFFFF;
            return (ushort)checkSum;
        }
        public void SetFileName(string fileName)
        {
            this.fileName = fileName;
        }
        public bool VerifyMD5Checksum()
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
        public bool WriteRom()
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
        private string ByteToStr(byte[] toStr)
        {
            System.Text.Encoding encoding = System.Text.Encoding.UTF8;

            return encoding.GetString(toStr);
        }
        #endregion
        #region Compression
        public byte[] Decompress(int offset, int maxSize)
        {
            //return LSCompression.Decompress(offset, maxSize);
            return LCDecomp.Decompress(offset, maxSize);
        }
        public int Compress(byte[] source, byte[] dest)
        {
            //return LSCompression.Compress(source, dest, 0);
            return LCDecomp.Compress(source, dest);
        }
        /// <summary>
        /// Decompresses data to a collection of byte arrays.
        /// </summary>
        /// <param name="arrays">The byte arrays to store the decompressed data to.</param>
        /// <param name="bankStart">The bank where the compressed data begins.</param>
        /// <param name="bankEnd">The bank where the compressed data ends. This bank is NOT included in the data.</param>
        /// <param name="decompressedSizeA">The decompressed size of each byte array.</param>
        /// <param name="decompressedSizeB">The second optional decompressed size of all byte arrays starting at indexB.</param>
        /// <param name="label">The label to use in the progress bar. All caps and singular.</param>
        /// <param name="indexB">The starting index of the arrays where decompressedSizeB will start being used.</param>
        public void Decompress(byte[][] arrays, int bankStart, int bankEnd,
            int decompressedSizeA, int decompressedSizeB, string label, int indexB)
        {
            ProgressBar progressBar = new ProgressBar(this, data, "DECOMPRESSING " + label + "S...", arrays.Length);
            progressBar.Show();
            int bank = 0;
            for (int i = 0, j = 0; i < arrays.Length; i++)
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
                    arrays[i] = Decompress(offset, decompressedSizeA);
                else
                    arrays[i] = Decompress(offset, decompressedSizeB);
                if (arrays[i] == null)
                    arrays[i] = new byte[decompressedSizeA];
                progressBar.PerformStep("DECOMPRESSING " + label + " #" + i.ToString("d" + arrays.Length.ToString().Length));
            }
            progressBar.Close();
        }
        public void Decompress(byte[][] arrays, int bankStart, int bankEnd,
            int decompressedSize, string label)
        {
            Decompress(arrays, bankStart, bankEnd, decompressedSize, decompressedSize, label, 0);
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
        public void Compress(byte[][] arrays, bool[] edit, int bankStart, int lastOffset, string label, params int[] bankIndexes)
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
            ProgressBar progressBar = new ProgressBar(this, data, "COMPRESSING " + label + "S", arrays.Length);
            progressBar.Show();
            // now start compressing the data and storing to ROM
            bank = bankStart;
            for (int indexBank = 0; indexBank < bankIndexes.Length; indexBank++, bank += 0x010000)
            {
                // the index in the array collection to start at
                int index = bankIndexes[indexBank];
                // the index within the current bank
                int bankIndex = 0;
                // this is where the pointers end and the compressed data begins
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
                        size = Compress(arrays[index], compressed);
                        if (offset + size > bounds) // Do we pass the bounds of this bank?
                        {
                            MessageBox.Show("Could not save all " + label + "S. " +
                                "Stopped saving at " + label + " #" + index.ToString(),
                                "LAZY SHELL");
                            size = Compress(new byte[arrays[index].Length], compressed);
                        }
                        // Write data to rom
                        Bits.SetByte(data, bank + offset, 1); offset++;
                    }
                    else
                    {
                        size = original[index].Length; original[index].CopyTo(compressed, 0);
                        if (offset + size > bounds) // Do we pass the bounds of this bank?
                        {
                            MessageBox.Show("Could not save all " + label + "S. " +
                                "Stopped saving at " + label + " #" + index.ToString(),
                                "LAZY SHELL");
                            size = Compress(new byte[arrays[index].Length], compressed);
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
        #endregion
        #region Assemblers
        public void LoadAll()
        {
            object dummy;
            dummy = LSCompression;
            dummy = LCDecomp;
            dummy = ActionScripts;
            dummy = Animations;
            dummy = Attacks;
            dummy = AttackAnimations;
            dummy = AttackNames;
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
            dummy = FontPaletteMenu;
            dummy = FontTriangle;
            dummy = FormationMusics;
            dummy = FormationPacks;
            dummy = Formations;
            dummy = GraphicPalettes;
            dummy = GraphicSets[0];
            dummy = ItemAnimations;
            dummy = ItemNames;
            dummy = Items;
            dummy = LevelMaps;
            dummy = Levels;
            dummy = MapPoints;
            dummy = MenuBackground;
            dummy = MenuBackgroundPalette;
            dummy = MenuFrame;
            dummy = MenuFramePalette;
            dummy = MenuGraphicSet;
            dummy = MenuTileset;
            dummy = MonsterNames;
            dummy = Monsters;
            dummy = Notes;
            dummy = NPCProperties;
            dummy = NPCSpritePartitions;
            dummy = OverlapTileset;
            dummy = Palettes;
            dummy = PaletteSets;
            dummy = PaletteSetsBF;
            dummy = PhysicalMaps[0];
            dummy = PhysicalTiles;
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
            dummy = TileMaps[0];
            dummy = TileSets[0];
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
        public void ClearModel()
        {
            LSCompression = null;
            lcDecomp = null;
            actionScripts = null;
            animations = null;
            attacks = null;
            attackAnimations = null;
            attackNames = null;
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
            e_animations = null;
            effects = null;
            entranceAnimations = null;
            eventScripts = null;
            fontDescription = null;
            fontDialogue = null;
            fontMenu = null;
            fontPaletteBattle = null;
            fontPaletteDialogue = null;
            fontPaletteMenu = null;
            fontTriangle = null;
            formationMusics = null;
            formationPacks = null;
            formations = null;
            graphicPalettes = null;
            graphicSets[0] = null;
            itemAnimations = null;
            itemNames = null;
            items = null;
            levelMaps = null;
            levels = null;
            mapPoints = null;
            menuBackground = null;
            menuBackgroundPalette = null;
            menuFrame = null;
            menuFramePalette = null;
            menuGraphicSet = null;
            menuTileset = null;
            monsterNames = null;
            monsters = null;
            notes = null;
            npcProperties = null;
            npcSpritePartitions = null;
            overlapTileset = null;
            palettes = null;
            paletteSets = null;
            paletteSetsBF = null;
            physicalMaps[0] = null;
            physicalTiles = null;
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
